// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IncludePropertyOnSerializationContextAction.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Actions
{
    using System;

    using JetBrains.Application.Progress;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.ReSharper.Psi.CSharp.Parsing;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.TextControl;

    /// <summary>
    ///     The remove property context action.
    /// </summary>
    [ContextAction(Name = Name, Group = "C#", Description = Description, Priority = -22)]
    public sealed class IncludePropertyOnSerializationContextAction : FieldContextActionBase
    {
        #region Constants

        /// <summary>
        /// The description.
        /// </summary>
        private const string Description = "IncludePropertyOnSerializationContextActionDescription";

        /// <summary>
        /// The name.
        /// </summary>
        private const string Name = "IncludePropertyOnSerializationContextAction";

        #endregion

        #region Fields

        /// <summary>
        ///     The _invocation expression.
        /// </summary>
        private IInvocationExpression invocationExpression;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IncludePropertyOnSerializationContextAction"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        public IncludePropertyOnSerializationContextAction(ICSharpContextActionDataProvider provider)
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
                return "Include on serialization";
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
            if (this.invocationExpression.ArgumentList.Arguments.Count == 5)
            {
                this.invocationExpression.RemoveArgument(this.invocationExpression.ArgumentList.Arguments[4]);
            }

            if (this.invocationExpression.ArgumentList.Arguments.Count == 4
                && (this.invocationExpression.ArgumentList.Arguments[3].Value is ICSharpLiteralExpression)
                && (this.invocationExpression.ArgumentList.Arguments[3].Value as ICSharpLiteralExpression).Literal.GetTokenType() == CSharpTokenType.NULL_KEYWORD)
            {
                this.invocationExpression.RemoveArgument(this.invocationExpression.ArgumentList.Arguments[3]);
            }

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
            var expressionInitializer = this.FieldDeclaration.Initial as IExpressionInitializer;
            this.invocationExpression = null;
            if (expressionInitializer != null)
            {
                this.invocationExpression = expressionInitializer.Value as IInvocationExpression;
            }

            return this.invocationExpression != null
                   && (this.invocationExpression.ArgumentList.Arguments.Count == 5
                       && ((this.invocationExpression.ArgumentList.Arguments[4].Value is ICSharpLiteralExpression)
                           && (this.invocationExpression.ArgumentList.Arguments[4].Value as ICSharpLiteralExpression).Literal.GetTokenType() == CSharpTokenType.FALSE_KEYWORD));
        }

        #endregion
    }
}