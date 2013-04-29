// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyDeclarationExtension.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Extensions
{
    using System.Text.RegularExpressions;

    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;

    /// <summary>
    ///     The property declaration extension.
    /// </summary>
    public static class PropertyDeclarationExtension
    {
        #region Constants

        /// <summary>
        ///     The default getter implementation pattern.
        /// </summary>
        private const string DefaultGetterImplementationPattern = @"\A{\s*return\s+(this\.)?GetValue\s*<[^>]+>\s*\([^)]+\);\s*}\Z";

        /// <summary>
        ///     The default setter implementation pattern.
        /// </summary>
        private const string DefaultSetterImplementationPattern = @"\A{\s*(this\.)?SetValue\([^,]+,\s*value\)\s*;\s*}\Z";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Indicates whether the property has default property data implementation.
        /// </summary>
        /// <param name="propertyDeclaration">
        /// The property declaration.
        /// </param>
        /// <returns>
        /// <c>true</c> if has a default property data implementation, otherwise <c>false</c>
        /// </returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="propertyDeclaration"/> is <c>null</c>.</exception>
        public static bool HasDefaultCatelImplementation(this IPropertyDeclaration propertyDeclaration)
        {
            Argument.IsNotNull(() => propertyDeclaration);

            bool defaultImplementation = true;

            int i = 0;
            while (defaultImplementation && i < propertyDeclaration.AccessorDeclarations.Count)
            {
                IAccessorDeclaration accessorDeclaration = propertyDeclaration.AccessorDeclarations[i];
                if (accessorDeclaration.Kind == AccessorKind.GETTER)
                {
                    defaultImplementation = accessorDeclaration.Body != null
                                            && Regex.IsMatch(
                                                accessorDeclaration.Body.GetText().Trim(), 
                                                DefaultGetterImplementationPattern);
                }
                else
                {
                    defaultImplementation = accessorDeclaration.Body != null
                                            && Regex.IsMatch(
                                                accessorDeclaration.Body.GetText(), DefaultSetterImplementationPattern);
                }

                i++;
            }

            return defaultImplementation;
        }

        #endregion
    }
}