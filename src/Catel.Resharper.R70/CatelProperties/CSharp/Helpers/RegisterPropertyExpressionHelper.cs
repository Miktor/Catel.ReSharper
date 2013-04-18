// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterPropertyExpressionHelper.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Helpers
{
    using System.Linq;

    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;

    /// <summary>
    ///     The register property expression helper.
    /// </summary>
    internal static class RegisterPropertyExpressionHelper
    {
        #region Constants

        /// <summary>
        ///     The register property method name.
        /// </summary>
        public const string RegisterPropertyMethodName = "RegisterProperty";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get property declaration.
        /// </summary>
        /// <param name="classDeclaration">
        /// The class declaration.
        /// </param>
        /// <param name="invocationExpression">
        /// The invocation expression.
        /// </param>
        /// <returns>
        /// The JetBrains.ReSharper.Psi.CSharp.Tree.IPropertyDeclaration.
        /// </returns>
        public static IPropertyDeclaration GetPropertyDeclaration(
            IClassDeclaration classDeclaration, IInvocationExpression invocationExpression)
        {
            IPropertyDeclaration propertyDeclaration = null;
            if (invocationExpression.ArgumentList.Arguments.Count >= 1)
            {
                ICSharpArgument argument = invocationExpression.ArgumentList.Arguments[0];
                if (argument.Value != null && argument.Value.ConstantValue != null)
                {
                    string propertyName = argument.Value.ConstantValue.Value.ToString();
                    if (classDeclaration.DeclaredElement != null)
                    {
                        IProperty firstOrDefault =
                            (from member in classDeclaration.DeclaredElement.GetMembers().OfType<IProperty>()
                             where member.ShortName == propertyName
                             select member).FirstOrDefault();
                        if (firstOrDefault != null)
                        {
                            propertyDeclaration =
                                (IPropertyDeclaration)firstOrDefault.GetDeclarations().FirstOrDefault();
                        }
                    }
                }
            }

            return propertyDeclaration;
        }

        #endregion
    }
}