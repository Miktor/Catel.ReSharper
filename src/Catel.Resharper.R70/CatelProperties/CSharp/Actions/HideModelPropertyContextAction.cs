// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HideModelPropertyContextAction.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Actions
{
    using System;
    using System.Linq;

    using Catel.ReSharper.CatelProperties.CSharp.Extensions;
    using Catel.ReSharper.Identifiers;

    using JetBrains.Application.Progress;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
#if R80
    using JetBrains.ReSharper.Psi.Tree;
#endif
    using JetBrains.TextControl;

    /// <summary>
    ///     The remove property context action.
    /// </summary>
    [ContextAction(Name = Name, Group = "C#", Description = Description, Priority = -23)]
    public sealed class HideModelPropertyContextAction : FieldContextActionBase
    {
        #region Constants

        /// <summary>
        /// The description.
        /// </summary>
        private const string Description = "HideModelPropertyContextActionDescription";

        /// <summary>
        /// The name.
        /// </summary>
        private const string Name = "HideModelPropertyContextAction";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HideModelPropertyContextAction"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        public HideModelPropertyContextAction(ICSharpContextActionDataProvider provider)
            : base(provider)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the text.
        /// </summary>
        public override string Text
        {
            get
            {
                return "Hide model property";
            }
        }

        #endregion

        #region Methods

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
            this.ClassDeclaration.RemoveClassMemberDeclaration(this.FieldDeclaration);
            this.ClassDeclaration.RemoveClassMemberDeclaration(this.PropertyDeclaration);
            return null;
        }

        /// <summary>
        ///     Indicates whether the the action is available.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if is available, otherwise <c>false</c>.
        /// </returns>
        protected override bool IsAvailable()
        {
            ITypeElement typeElement;
            IAttribute viewModelToModelAttribute = null;
#if R80
            if (CatelMVVM.TryGetViewModelToModelAttributeTypeElement(this.Provider.PsiModule, this.Provider.SelectedElement.GetResolveContext(), out typeElement))
#else
            if (CatelMVVM.TryGetViewModelToModelAttributeTypeElement(this.Provider.PsiModule, out typeElement))
#endif
            {
                viewModelToModelAttribute = (from attribute in this.PropertyDeclaration.Attributes
                                             where
                                                 attribute.TypeReference != null
                                                 && attribute.TypeReference.CurrentResolveResult != null
                                                 && typeElement.Equals(
                                                     attribute.TypeReference.CurrentResolveResult.DeclaredElement)
                                             select attribute).FirstOrDefault();
            }

            return viewModelToModelAttribute != null && this.PropertyDeclaration.HasDefaultCatelImplementation();
        }

        #endregion
    }
}