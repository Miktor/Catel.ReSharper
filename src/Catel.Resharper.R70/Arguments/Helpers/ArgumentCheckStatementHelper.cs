// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArgumentCheckStatementHelper.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments.Helpers
{
    using Catel.ReSharper.Arguments.Patterns;
    using Catel.ReSharper.Identifiers;

    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
#if R80
    using JetBrains.ReSharper.Psi.Tree;
#endif

    /// <summary>
    /// The argument statement helper.
    /// </summary>
    internal static class ArgumentCheckStatementHelper
    {
        /// <summary>
        /// The create is of type argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The is of type argument check statement
        /// </returns>
        public static ICSharpStatement CreateIsOfTypeArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.IsOfType, parameterDeclaration);
        }

        /// <summary>
        /// The create implements interface argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The c sharp context action data provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The implements interface argument check statement
        /// </returns>
        public static ICSharpStatement CreateImplementsInterfaceArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.ImplementsInterface, parameterDeclaration);
        }

        /// <summary>
        /// The create is maximum argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The c sharp context action data provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The is maximun argument check statement
        /// </returns>
        public static ICSharpStatement CreateIsMaximumArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.IsMaximum, parameterDeclaration);
        }

        /// <summary>
        /// The create is minimal argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The c sharp context action data provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The is minimal argument check statement.
        /// </returns>
        public static ICSharpStatement CreateIsMinimalArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.IsMinimal, parameterDeclaration);
        }

        /// <summary>
        /// The create is not null argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The c sharp context action data provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The is not null argument check statement.
        /// </returns>
        public static ICSharpStatement CreateIsNotNullArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.IsNotNull, parameterDeclaration);
        }

        /// <summary>
        /// The create is not null or empty array argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The c sharp context action data provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The is not null or empty array argument check statement.
        /// </returns>
        public static ICSharpStatement CreateIsNotNullOrEmptyArrayArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.IsNotNullOrEmptyArray, parameterDeclaration);
        }

        /// <summary>
        /// The create is not null or empty argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The c sharp context action data provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The is not null or empty argument check statement.
        /// </returns>
        public static ICSharpStatement CreateIsNotNullOrEmptyArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.IsNotNullOrEmpty, parameterDeclaration);
        }

        /// <summary>
        /// The create is not null or whitespace argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The c sharp context action data provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The is not null or whitespace argument check statement.
        /// </returns>
        public static ICSharpStatement CreateIsNotNullOrWhitespaceArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.IsNotNullOrWhitespace, parameterDeclaration);
        }

        /// <summary>
        /// The create is not out of range argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The c sharp context action data provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The is not out of rangel argument check statement.
        /// </returns>
        public static ICSharpStatement CreateIsNotOutOfRangeArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.IsNotOutOfRange, parameterDeclaration);
        }

        /// <summary>
        /// Creates the is not match argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The <see cref="ICSharpStatement"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="provider"/> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="parameterDeclaration"/> is <c>null</c>.</exception>
        public static ICSharpStatement CreateIsNotMatchArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.IsNotMatch, parameterDeclaration);
        }

        /// <summary>
        /// Creates the is match argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The <see cref="ICSharpStatement"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="provider"/> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="parameterDeclaration"/> is <c>null</c>.</exception>
        public static ICSharpStatement CreateIsMatchArgumentCheckStatement(ICSharpContextActionDataProvider provider, IRegularParameterDeclaration parameterDeclaration)
        {
            return CreateArgumentCheckStatement(provider, ArgumentCheckStatementPatterns.IsMatch, parameterDeclaration);
        }


        /// <summary>
        /// Gets create argument check statement.
        /// </summary>
        /// <param name="provider">
        /// The c sharp context action data provider.
        /// </param>
        /// <param name="pattern">
        /// The implementsinterface typeof value.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The argument check statement.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="provider"/> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentException">The <paramref name="pattern"/> is <c>null</c> or whitespace.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="parameterDeclaration"/> is <c>null</c>.</exception>
        private static ICSharpStatement CreateArgumentCheckStatement(ICSharpContextActionDataProvider provider, string pattern, IRegularParameterDeclaration parameterDeclaration)
        {
            Argument.IsNotNull(() => provider);
            Argument.IsNotNullOrWhitespace(() => pattern);
            Argument.IsNotNull(() => parameterDeclaration);

#if R80
            IDeclaredType catelArgumentType = TypeFactory.CreateTypeByCLRName(CatelCore.Argument, provider.PsiModule, provider.SelectedElement.GetResolveContext());
#else
            IDeclaredType catelArgumentType = TypeFactory.CreateTypeByCLRName(CatelCore.Argument, provider.PsiModule);
#endif
            return provider.ElementFactory.CreateStatement(pattern, catelArgumentType.GetTypeElement(), parameterDeclaration.DeclaredName);
        }
    }
}