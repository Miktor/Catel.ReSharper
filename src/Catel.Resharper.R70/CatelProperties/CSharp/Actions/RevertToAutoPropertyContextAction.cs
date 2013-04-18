// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RevertToAutoPropertyContextAction.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Actions
{
    using System;

    using Catel.ReSharper.CatelProperties.CSharp.Extensions;

    using JetBrains.Application.Progress;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.TextControl;

    /// <summary>
    ///     The revert to auto property context action.
    /// </summary>
    [ContextAction(Name = Name, Group = "C#", Description = Description, Priority = -23)]
    public sealed class RevertToAutoPropertyContextAction : FieldContextActionBase
    {
        #region Constants

        /// <summary>
        /// The description.
        /// </summary>
        private const string Description = "RevertToAutoPropertyContextActionDescription";

        /// <summary>
        /// The name.
        /// </summary>
        private const string Name = "RevertToAutoPropertyContextAction";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RevertToAutoPropertyContextAction"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        public RevertToAutoPropertyContextAction(ICSharpContextActionDataProvider provider)
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
                return "To auto property";
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

            this.PropertyDeclaration.AccessorDeclarations[0].SetBody(null);
            this.PropertyDeclaration.AccessorDeclarations[1].SetBody(null);

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
            return this.PropertyDeclaration.HasDefaultCatelImplementation();
        }

        #endregion
    }
}