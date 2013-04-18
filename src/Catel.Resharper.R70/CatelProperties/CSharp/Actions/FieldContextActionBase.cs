// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldContextActionBase.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Actions
{
    using Catel.ReSharper.CatelProperties.CSharp.Extensions;
    using Catel.ReSharper.CatelProperties.CSharp.Helpers;
    using Catel.ReSharper.CSharp;
    using Catel.ReSharper.Identifiers;

    using JetBrains.Application;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.Util;

    /// <summary>
    ///     The field context action base.
    /// </summary>
    public abstract class FieldContextActionBase : ContextActionBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldContextActionBase"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        protected FieldContextActionBase(ICSharpContextActionDataProvider provider)
            : base(provider)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the class declaration.
        /// </summary>
        protected IClassDeclaration ClassDeclaration { get; private set; }

        /// <summary>
        ///     Gets the field declaration.
        /// </summary>
        protected IFieldDeclaration FieldDeclaration { get; private set; }

        /// <summary>
        ///     Gets the property declaration.
        /// </summary>
        protected IPropertyDeclaration PropertyDeclaration { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Indicates whether the the action is available.
        /// </summary>
        /// <param name="cache">
        ///     The cache.
        /// </param>
        /// <returns>
        ///     <c>true</c> if is available, otherwise <c>false</c>.
        /// </returns>
        public override bool IsAvailable(IUserDataHolder cache)
        {
            this.ClassDeclaration = null;
            this.PropertyDeclaration = null;
            this.FieldDeclaration = null;

            using (ReadLockCookie.Create())
            {
                ITreeNode selectedElement = this.Provider.SelectedElement;
                if (selectedElement != null && selectedElement.Parent != null
                    && selectedElement.Parent is IFieldDeclaration)
                {
                    this.FieldDeclaration = selectedElement.Parent as IFieldDeclaration;
                    if (this.FieldDeclaration.Parent != null && this.FieldDeclaration.Parent.Parent != null
                        && this.FieldDeclaration.Parent.Parent.Parent is IClassDeclaration)
                    {
                        this.ClassDeclaration = this.FieldDeclaration.Parent.Parent.Parent as IClassDeclaration;
                        ITypeElement classDeclaredElement = this.ClassDeclaration.DeclaredElement;
#if R80
                        if (classDeclaredElement != null && (classDeclaredElement.IsDescendantOf(CatelCore.GetDataObjectBaseTypeElement(this.Provider.PsiModule, selectedElement.GetResolveContext())) || classDeclaredElement.IsDescendantOf(CatelCore.GetModelBaseTypeElement(this.Provider.PsiModule, selectedElement.GetResolveContext()))) && (this.FieldDeclaration.IsStatic && this.FieldDeclaration.Initial is IExpressionInitializer))
#else
                        if (classDeclaredElement != null && (classDeclaredElement.IsDescendantOf(CatelCore.GetDataObjectBaseTypeElement(this.Provider.PsiModule)) || classDeclaredElement.IsDescendantOf(CatelCore.GetModelBaseTypeElement(this.Provider.PsiModule))) && (this.FieldDeclaration.IsStatic && this.FieldDeclaration.Initial is IExpressionInitializer))
#endif
                        {
                            var expressionInitializer = this.FieldDeclaration.Initial as IExpressionInitializer;
                            if (expressionInitializer.Value is IInvocationExpression)
                            {
                                var invocationExpression = expressionInitializer.Value as IInvocationExpression;
                                if (invocationExpression.InvokedExpression is IReferenceExpression)
                                {
                                    var referenceExpression =
                                        invocationExpression.InvokedExpression as IReferenceExpression;
                                    if (referenceExpression.NameIdentifier != null
                                        && referenceExpression.NameIdentifier.GetText() == RegisterPropertyExpressionHelper.RegisterPropertyMethodName)
                                    {
                                        this.PropertyDeclaration =
                                            RegisterPropertyExpressionHelper.GetPropertyDeclaration(
                                                this.ClassDeclaration, invocationExpression);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return this.ClassDeclaration != null && this.FieldDeclaration != null && this.PropertyDeclaration != null
                   && this.IsAvailable();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Indicates whether the the action is available.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if is available, otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        ///     This method needs be overridden.
        /// </remarks>
        protected abstract bool IsAvailable();

        #endregion
    }
}