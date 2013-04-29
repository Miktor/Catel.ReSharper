// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassLikeDeclarationExtensions.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Catel.ReSharper.CatelProperties.CSharp.Helpers;

    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Parsing;
    using JetBrains.ReSharper.Psi.CSharp.Tree;

    /// <summary>
    ///     The IClassLikeDeclaration extension methods.
    /// </summary>
    internal static class ClassLikeDeclarationExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Get the registered property names.
        /// </summary>
        /// <param name="classLikeDeclaration">
        /// The class like declaration instance.
        /// </param>
        /// <returns>
        /// A collection with the name of the registered properties.
        /// </returns>
        /// <remarks>
        /// The name of the property is retrieved from the first argument of the invoke expression of <c>RegisterProperty</c>.
        ///     <code>
        /// <![CDATA[
        /// public class PersonViewModel : ViewModelBase
        /// {
        ///     /// <summary>Register the Name property so it is known in the class.</summary>
        ///     public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string), default(string), (s, e) => ((PersonViewModel)s).OnNameChanged());
        /// 
        ///     <summary>Register the LastName property so it is known in the class.</summary>
        ///     public static readonly PropertyData LastNameProperty = RegisterProperty("LastName", typeof(string), default(string), (s, e) => ((PersonViewModel)s).OnLastNameChanged());
        /// }
        /// ]]>
        /// </code>
        /// The result of this examples the result is {"Name", "LastName"}. If the property is not registered on the declaration statement expression then the property name is not detected.
        /// </remarks>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="classLikeDeclaration"/> is <c>null</c>.
        /// </exception>
        public static List<string> GetCSharpRegisterPropertyNames(this IClassLikeDeclaration classLikeDeclaration)
        {
            Argument.IsNotNull(() => classLikeDeclaration);

            return
                (from argument in
                     (from fieldDeclaration in
                          classLikeDeclaration.Body.FieldDeclarations.Where(
                              multipleFieldDeclaration => multipleFieldDeclaration != null)
                                              .SelectMany(
                                                  multipleFieldDeclaration => multipleFieldDeclaration.Declarators)
                                              .OfType<IFieldDeclaration>()
                      select fieldDeclaration
                      into declaration 
                      where declaration.Initial is IExpressionInitializer
                      select declaration.Initial as IExpressionInitializer
                      into invocationExpression 
                      where invocationExpression.Value is IInvocationExpression
                      select invocationExpression.Value as IInvocationExpression
                      into expression 
                      where expression.InvokedExpression is IReferenceExpression
                      let referenceExpression = expression.InvokedExpression as IReferenceExpression
                      where
                          referenceExpression.NameIdentifier != null
                          && referenceExpression.NameIdentifier.GetText()
                          == RegisterPropertyExpressionHelper.RegisterPropertyMethodName
                      select expression.Arguments[0].Value).OfType<ICSharpLiteralExpression>()
                 select argument into sharpLiteralExpression 
                 select sharpLiteralExpression.ConstantValue
                 into constantValue 
                 where constantValue != null && constantValue.Type.IsString()
                 select (string)constantValue.Value).ToList();
        }

        /// <summary>
        /// Gets a value indicating whether the class is static.
        /// </summary>
        /// <param name="classLikeDeclaration">
        /// The class declaration.
        /// </param>
        /// <returns>
        /// <c>true</c> if the modifier <c>static</c> is used, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="classLikeDeclaration"/> is <c>null</c>.
        /// </exception>
        public static bool IsStaticEx(this IClassLikeDeclaration classLikeDeclaration)
        {
            Argument.IsNotNull(() => classLikeDeclaration);

            return classLikeDeclaration.ModifiersList.HasModifier(CSharpTokenType.STATIC_KEYWORD);
        }

        #endregion
    }
}