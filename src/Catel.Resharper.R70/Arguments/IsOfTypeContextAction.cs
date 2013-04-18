// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsOfTypeContextAction.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments
{
    using System;
    using System.Xml;

    using Catel.Logging;
    using Catel.ReSharper.Arguments.Helpers;

    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;

    /// <summary>
    ///     The is of type context action.
    /// </summary>
    [ContextAction(Name = Name, Group = "C#", Description = Description, Priority = -20)]
    public sealed class IsOfTypeContextAction : ArgumentContextActionBase
    {
        #region Constants

        /// <summary>
        /// The description.
        /// </summary>
        private const string Description = "IsOfTypeContextActionDescription";

        /// <summary>
        /// The name.
        /// </summary>
        private const string Name = "IsOfTypeContextAction";

        #endregion

        #region Static Fields

        /// <summary>
        ///     The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IsOfTypeContextAction"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        public IsOfTypeContextAction(ICSharpContextActionDataProvider provider)
            : base(provider)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets Text.
        /// </summary>
        public override string Text
        {
            get
            {
                return "Add \"Argument.IsOfType\"";
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the argument check statement.
        /// </summary>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The argument check statement
        /// </returns>
        protected override ICSharpStatement CreateArgumentCheckStatement(
            IRegularParameterDeclaration parameterDeclaration)
        {
            return ArgumentCheckStatementHelper.CreateIsOfTypeArgumentCheckStatement(
                this.Provider, parameterDeclaration);
        }

        /// <summary>
        /// Gets the argument check exception documentation.
        /// </summary>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The argument check exception documentation.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occur
        /// </exception>
        protected override string CreateExceptionXmlDoc(IRegularParameterDeclaration parameterDeclaration)
        {
            return ExceptionXmlDocHelper.GetIsOfTypeExceptionXmlDoc(parameterDeclaration.DeclaredName);
        }

        /// <summary>
        /// Gets is argument check documented.
        /// </summary>
        /// <param name="xmlDocOfTheMethod">
        /// The xml doc of the method.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// <c>true</c> if the argument check exception is documented, otherwise <c>false</c>.
        /// </returns>
        protected override bool IsArgumentCheckDocumented(
            XmlNode xmlDocOfTheMethod, IRegularParameterDeclaration parameterDeclaration)
        {
            return ExceptionXmlDocDetectionHelper.IsOfTypeDocumented(
                xmlDocOfTheMethod.InnerXml, parameterDeclaration.DeclaredName);
        }

        /// <summary>
        /// Gets whether the argument checked is already done.
        /// </summary>
        /// <param name="methodDeclaration">
        /// The method declaration.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// <c>true</c> if the argument type checked is already done, otherwise <c>false</c>.
        /// </returns>
        protected override bool IsArgumentChecked(
            ICSharpFunctionDeclaration methodDeclaration, IRegularParameterDeclaration parameterDeclaration)
        {
            return ArgumentCheckStatementDetectionHelper.IsOfTypeInvoked(
                methodDeclaration.Body.GetText(), parameterDeclaration.DeclaredName);
        }

        /// <summary>
        /// Gets whether the argument type the expected one.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// <c>true</c> if the argument type is the expected one, otherwise <c>false</c>.
        /// </returns>
        protected override bool IsArgumentTypeTheExpected(IType type)
        {
            return type != null && type.Classify == TypeClassification.REFERENCE_TYPE && !type.IsNullable()
                   && !(type is IArrayType || type.IsString());
        }

        #endregion
    }
}