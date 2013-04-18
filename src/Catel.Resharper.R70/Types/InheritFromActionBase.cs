// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InheritFromActionBase.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Types
{
    using System;

    using Catel.ReSharper.CatelProperties.CSharp.Extensions;
    using Catel.ReSharper.CSharp;

    using JetBrains.Application;
    using JetBrains.Application.Progress;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
#if R80
    using JetBrains.ReSharper.Psi.Tree;
#endif
    using JetBrains.TextControl;
    using JetBrains.Util;

    /// <summary>
    /// The inherit from action base.
    /// </summary>
    public abstract class InheritFromActionBase : ContextActionBase
    {
        /// <summary>
        /// The inherit from text pattern.
        /// </summary>
        private const string InheritFromTextPattern = "Inherit from '{0}'";

        /// <summary>
        /// The _class declaration.
        /// </summary>
        private IClassDeclaration _classDeclaration;

        /// <summary>
        /// The _super type.
        /// </summary>
        private IDeclaredType _superType;

        /// <summary>
        /// Initializes a new instance of the <see cref="InheritFromActionBase"/> class. 
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        protected InheritFromActionBase(ICSharpContextActionDataProvider provider)
            : base(provider)
        {
        }

        /// <summary>
        /// Popup menu item text
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if an interal error occur.</exception>
        public override string Text
        {
            get
            {
                return string.Format(InheritFromTextPattern, SuperTypeName);
            }
        }

        /// <summary>
        /// Gets SuperTypeName.
        /// </summary>
        protected abstract string SuperTypeName { get; }

        /// <summary>
        /// Gets the action availability.
        /// </summary>
        /// <param name="cache">
        /// The cache.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is action is available, otherwise <c>false</c>.
        /// </returns>
        public override bool IsAvailable(IUserDataHolder cache)
        {
            using (ReadLockCookie.Create())
            {
                if (Provider.SelectedElement != null)
                {
#if R80
                    _superType = TypeFactory.CreateTypeByCLRName(this.SuperTypeName, this.Provider.PsiModule, this.Provider.SelectedElement.GetResolveContext());
#else
                	_superType = TypeFactory.CreateTypeByCLRName(SuperTypeName, Provider.PsiModule);
#endif
                    if (_superType.GetTypeElement() != null)
                    {
                        _classDeclaration = Provider.SelectedElement.Parent as IClassDeclaration;
                    }
                }
            }

            // !this._classDeclaration.IsStatic doesn't work, IsStatic is returns true
            return _classDeclaration != null && !_classDeclaration.IsStaticEx() && _classDeclaration.SuperTypes.IsEmpty();
        }

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
        /// The System.Action`1[T -&gt; JetBrains.TextControl.ITextControl].
        /// </returns>
        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            _classDeclaration.SetSuperClass(_superType);
            return null;
        }
    }
}