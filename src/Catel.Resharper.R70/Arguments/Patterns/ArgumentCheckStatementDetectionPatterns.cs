// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArgumentCheckStatementDetectionPatterns.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments.Patterns
{
    /// <summary>
    ///     The invocation patterns.
    /// </summary>
    internal static class ArgumentCheckStatementDetectionPatterns
    {
        #region Constants

        /// <summary>
        ///     The is maximal.
        /// </summary>
        public const string IsMaximum = @"(Catel\s*[.]\s*)?Argument\s*[.]\s*IsMaximum\s*[(]\s*[""]{0}[""]\s*,\s*{0}\s*,[^)]+[)]\s*;";

        /// <summary>
        ///     The is minimal.
        /// </summary>
        public const string IsMinimal = @"(Catel\s*[.]\s*)?Argument\s*[.]\s*IsMinimal\s*[(]\s*[""]{0}[""]\s*,\s*{0}\s*,[^)]+[)]\s*;";

        /// <summary>
        ///     The argument is not null call pattern.
        /// </summary>
        public const string IsNotNull = @"(Catel\s*[.]\s*)?Argument\s*[.]\s*IsNotNull\s*[(]\s*[""]{0}[""]\s*,\s*{0}\s*[)]\s*;";

        /// <summary>
        ///     The argument is not null or empty invocation pattern.
        /// </summary>
        public const string IsNotNullOrEmpty = @"(Catel\s*[.]\s*)?Argument\s*[.]\s*IsNotNullOrEmpty\s*[(]\s*[""]{0}[""]\s*,\s*{0}\s*[)]\s*;";

        /// <summary>
        ///     The argument is not null or empty array invocation pattern.
        /// </summary>
        public const string IsNotNullOrEmptyArray = @"(Catel\s*[.]\s*)?Argument\s*[.]\s*IsNotNullOrEmptyArray\s*[(]\s*[""]{0}[""]\s*,\s*{0}\s*[)]\s*;";

        /// <summary>
        ///     The argument is not null or whitespace invocation pattern.
        /// </summary>
        public const string IsNotNullOrWhitespace = @"(Catel\s*[.]\s*)?Argument\s*[.]\s*IsNotNullOrWhitespace\s*[(]\s*[""]{0}[""]\s*,\s*{0}\s*[)]\s*;";

        /// <summary>
        ///     The is not out of range.
        /// </summary>
        public const string IsNotOutOfRange = @"(Catel\s*[.]\s*)?Argument\s*[.]\s*IsNotOutOfRange\s*[(]\s*[""]{0}[""]\s*,\s*{0}\s*,[^,]+,[^)]+[)]\s*;";

        /// <summary>
        ///     The is of type.
        /// </summary>
        public const string IsOfType = @"(Catel\s*[.]\s*)?Argument\s*[.]\s*IsOfType\s*[(]\s*[""]{0}[""]\s*,\s*{0}\s*,\s*(typeof\s*[(][^)]+[)]\s*[)]|[^)]+[)])";

        #endregion
    }
}