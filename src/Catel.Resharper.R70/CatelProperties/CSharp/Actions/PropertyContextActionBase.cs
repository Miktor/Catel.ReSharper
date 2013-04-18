// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyContextActionBase.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Actions
{
    using System;

    using Catel.Logging;
    using Catel.ReSharper.CSharp;
    using Catel.ReSharper.Identifiers;

    using JetBrains.Application;
    using JetBrains.Application.Progress;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;
    using JetBrains.Util;

    /// <summary>
    ///     The property context action base.
    /// </summary>
    public abstract class PropertyContextActionBase : ContextActionBase
    {
        #region Static Fields

        /// <summary>
        ///     The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Fields

        /// <summary>
        ///     Gets the property declaration.
        /// </summary>
        private IPropertyDeclaration propertyDeclaration;

        /// <summary>
        ///     Gets the class declaration.
        /// </summary>
        private IClassDeclaration classDeclaration;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyContextActionBase"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        protected PropertyContextActionBase(ICSharpContextActionDataProvider provider)
            : base(provider)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Indicates whether the the action is available.
        /// </summary>
        /// <param name="cache">
        /// The cache.
        /// </param>
        /// <returns>
        /// <c>true</c> if the action is available, otherwise <c>false</c>.
        /// </returns>
        public override sealed bool IsAvailable(IUserDataHolder cache)
        {
#if R8
            IModuleReferenceResolveContext moduleReferenceResolveContext;
#endif
            using (ReadLockCookie.Create())
            {
                ITreeNode selectedElement = this.Provider.SelectedElement;
#if R8
                moduleReferenceResolveContext = selectedElement.GetResolveContext();
#endif
                if (selectedElement != null && selectedElement.Parent is IPropertyDeclaration)
                {
                    this.propertyDeclaration = selectedElement.Parent as IPropertyDeclaration;
                    if (this.propertyDeclaration.IsAuto && this.propertyDeclaration.Parent != null
                        && this.propertyDeclaration.Parent.Parent is IClassDeclaration)
                    {
                        this.classDeclaration = this.propertyDeclaration.Parent.Parent as IClassDeclaration;
                    }
                }
            }
#if R80
            return this.classDeclaration != null && this.classDeclaration.DeclaredElement != null
                   && (this.classDeclaration.DeclaredElement.IsDescendantOf(CatelCore.GetDataObjectBaseTypeElement(this.Provider.PsiModule, classDeclaration.GetResolveContext()))
                       || this.classDeclaration.DeclaredElement.IsDescendantOf(CatelCore.GetModelBaseTypeElement(this.Provider.PsiModule, classDeclaration.GetResolveContext())));
#else
            return this.classDeclaration != null && this.classDeclaration.DeclaredElement != null
                   && (this.classDeclaration.DeclaredElement.IsDescendantOf(CatelCore.GetDataObjectBaseTypeElement(this.Provider.PsiModule))
                       || this.classDeclaration.DeclaredElement.IsDescendantOf(CatelCore.GetModelBaseTypeElement(this.Provider.PsiModule)));
#endif
        }

        #endregion

        #region Methods

        /// <summary>
        /// The modify class body.
        /// </summary>
        /// <param name="propertyConverter">
        /// The property Converter.
        /// </param>
        /// <param name="propertyDeclaration">
        /// The property declaration.
        /// </param>
        protected abstract void ConvertProperty(
            PropertyConverter propertyConverter, IPropertyDeclaration propertyDeclaration);

        /// <summary>
        /// The execute psi transaction.
        /// </summary>
        /// <param name="solution">
        /// The solution.
        /// </param>
        /// <param name="progress">
        /// The progress.
        /// </param>
        /// <returns>
        /// Returns <c>null</c> or Nothing
        /// </returns>
        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            using (WriteLockCookie.Create())
            {
                this.ConvertProperty(
                    new PropertyConverter(this.Provider.ElementFactory, this.Provider.PsiModule, this.classDeclaration), 
                    this.propertyDeclaration);
            }

            return null;
        }

        #endregion
    }
}