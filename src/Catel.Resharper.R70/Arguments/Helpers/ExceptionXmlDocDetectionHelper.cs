// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionXmlDocDetectionHelper.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments.Helpers
{
    using System.Text.RegularExpressions;

    using Catel.ReSharper.Arguments.Patterns;

    /// <summary>
    /// The argument documentation detection helper.
    /// </summary>
    internal static class ExceptionXmlDocDetectionHelper
    {
        /// <summary>
        /// The is not null documented.
        /// </summary>
        /// <param name="xmlDoc">
        /// The xml doc.
        /// </param>
        /// <param name="argumentName">
        /// The declared name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is not null is documented, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsNotNullDocumented(string xmlDoc, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return IsMatch(ExceptionXmlDocDectectionPatterns.IsNotNull, argumentName, xmlDoc);
        }

        /// <summary>
        /// The not null or empty array documented.
        /// </summary>
        /// <param name="xmlDoc">
        /// The xml doc.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the not null or empty array is documented, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool NotNullOrEmptyArrayDocumented(string xmlDoc, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return IsMatch(ExceptionXmlDocDectectionPatterns.NotNullOrEmptyArray, argumentName, xmlDoc);
        }

        /// <summary>
        /// The not null or empty documented.
        /// </summary>
        /// <param name="xmlDoc">
        /// The xml doc.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the not null or empty is documented, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool NotNullOrEmptyDocumented(string xmlDoc, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return IsMatch(ExceptionXmlDocDectectionPatterns.NotNullOrEmpty, argumentName, xmlDoc);
        }

        /// <summary>
        /// The not null or whitespace documented.
        /// </summary>
        /// <param name="xmlDoc">
        /// The xml doc.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c>if the not null or whitespace is documented, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool NotNullOrWhitespaceDocumented(string xmlDoc, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return IsMatch(ExceptionXmlDocDectectionPatterns.NotNullOrEmpty, argumentName, xmlDoc);
        }

        /// <summary>
        /// The is not out of range documented.
        /// </summary>
        /// <param name="xmlDoc">
        /// The xml doc.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is not out of range is documented, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsNotOutOfRangeDocumented(string xmlDoc, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return IsMatch(ExceptionXmlDocDectectionPatterns.IsNotOutOfRange, argumentName, xmlDoc);
        }

        /// <summary>
        /// The is maximal documented.
        /// </summary>
        /// <param name="xmlDoc">
        /// The xml doc.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is maximal is documented, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsMaximumDocumented(string xmlDoc, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return IsMatch(ExceptionXmlDocDectectionPatterns.IsMaximum, argumentName, xmlDoc);
        }

        /// <summary>
        /// The is minimal documented.
        /// </summary>
        /// <param name="xmlDoc">
        /// The xml doc.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is minimal is documented, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsMinimalDocumented(string xmlDoc, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return IsMatch(ExceptionXmlDocDectectionPatterns.IsMinimal, argumentName, xmlDoc);
        }

        /// <summary>
        /// The is of type documented.
        /// </summary>
        /// <param name="xmlDoc">
        /// The xml doc.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is of type is documented, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsOfTypeDocumented(string xmlDoc, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return IsMatch(ExceptionXmlDocDectectionPatterns.IsOfType, argumentName, xmlDoc);
        }

        /// <summary>
        /// The is match.
        /// </summary>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <param name="xmlDoc">
        /// The documentation.
        /// </param>
        /// <returns>
        /// <c>true</c> if the formatted <paramref name="pattern"/> with the <paramref name="argumentName"/> match with the <paramref name="xmlDoc"/>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="pattern"/> is <c>null</c> or whitespace.
        /// </exception>
        /// <exception cref="System.ArgumentException">The <paramref name="argumentName"/> is <c>null</c> or whitespace.</exception>
        private static bool IsMatch(string pattern, string argumentName, string xmlDoc)
        {
            Argument.IsNotNullOrWhitespace("pattern", pattern);
            
            return Regex.IsMatch(xmlDoc, string.Format(pattern, argumentName), RegexOptions.IgnorePatternWhitespace);
        }
    }
}