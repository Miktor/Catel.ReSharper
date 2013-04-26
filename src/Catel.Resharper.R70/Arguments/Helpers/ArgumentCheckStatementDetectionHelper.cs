// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArgumentCheckStatementDetectionHelper.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// <summary>
//   The argument invocation detection helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments.Helpers
{
    using System.Text.RegularExpressions;

    using Catel.ReSharper.Arguments.Patterns;

    /// <summary>
    /// The argument invocation detection helper.
    /// </summary>
    internal static class ArgumentCheckStatementDetectionHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// The is maximal range invoked.
        /// </summary>
        /// <param name="methodBody">
        /// The method body.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is maximal range invoked, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsMaximunInvoked(string methodBody, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsMaximum, argumentName), RegexOptions.IgnorePatternWhitespace) || Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsMaximum2, argumentName), RegexOptions.IgnorePatternWhitespace);
        }

        /// <summary>
        /// The is minimal range invoked.
        /// </summary>
        /// <param name="methodBody">
        /// The method body.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is minimal range invoked, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsMinimalInvoked(string methodBody, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsMinimal, argumentName), RegexOptions.IgnorePatternWhitespace) || Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsMinimal2, argumentName), RegexOptions.IgnorePatternWhitespace);
        }

        /// <summary>
        /// The is not null invoked.
        /// </summary>
        /// <param name="methodBody">
        /// The method body.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is not null invoked, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsNotNullInvoked(string methodBody, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsNotNull, argumentName), RegexOptions.IgnorePatternWhitespace) || Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsNotNull2, argumentName), RegexOptions.IgnorePatternWhitespace);
        }

        /// <summary>
        /// The is not null or empty array invoked.
        /// </summary>
        /// <param name="methodBody">
        /// The method body.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is not null or empty array invoked, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsNotNullOrEmptyArrayInvoked(string methodBody, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsNotNullOrEmptyArray, argumentName), RegexOptions.IgnorePatternWhitespace) || Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsNotNullOrEmptyArray2, argumentName), RegexOptions.IgnorePatternWhitespace);
        }

        /// <summary>
        /// The is not null or empty invoked.
        /// </summary>
        /// <param name="methodBody">
        /// The method body.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is not null or empty invoked, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsNotNullOrEmptyInvoked(string methodBody, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsNotNullOrEmpty, argumentName), RegexOptions.IgnorePatternWhitespace) || Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsNotNullOrEmpty2, argumentName), RegexOptions.IgnorePatternWhitespace);
        }

        /// <summary>
        /// The is not null or whitespace invoked.
        /// </summary>
        /// <param name="methodBody">
        /// The method body.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c>if the is not null or whitespace invoked, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsNotNullOrWhitespaceInvoked(string methodBody, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsNotNullOrWhitespace, argumentName), RegexOptions.IgnorePatternWhitespace) || Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsNotNullOrWhitespace2, argumentName), RegexOptions.IgnorePatternWhitespace);
        }

        /// <summary>
        /// The is not out of range invoked.
        /// </summary>
        /// <param name="methodBody">
        /// The method body.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is not out of range invoked, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsNotOutOfRangeInvoked(string methodBody, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsNotOutOfRange, argumentName), RegexOptions.IgnorePatternWhitespace) || Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsNotOutOfRange2, argumentName), RegexOptions.IgnorePatternWhitespace);
        }

        /// <summary>
        /// The is of type invoked.
        /// </summary>
        /// <param name="methodBody">
        /// The method body.
        /// </param>
        /// <param name="argumentName">
        /// The argument name.
        /// </param>
        /// <returns>
        /// <c>true</c> if the is of type invoked, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// The <paramref name="argumentName"/> is <c>null</c> or whitespace.
        /// </exception>
        public static bool IsOfTypeInvoked(string methodBody, string argumentName)
        {
            Argument.IsNotNullOrWhitespace("argumentName", argumentName);

            return Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsOfType, argumentName), RegexOptions.IgnorePatternWhitespace) || Regex.IsMatch(methodBody, string.Format(ArgumentCheckStatementDetectionPatterns.IsOfType2, argumentName), RegexOptions.IgnorePatternWhitespace);
        }

        #endregion
    }
}