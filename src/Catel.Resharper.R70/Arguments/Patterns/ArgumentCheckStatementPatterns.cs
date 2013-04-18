// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArgumentCheckStatementPatterns.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments.Patterns
{
    /// <summary>
    /// The catel argument statement patterns.
    /// </summary>
    internal static class ArgumentCheckStatementPatterns
    {
        /// <summary>
        /// The implements interface.
        /// </summary>
        public const string ImplementsInterface = "$0.ImplementsInterface(\"$1\", $1, typeof(/*Value*/));";

        /// <summary>
        /// The is of type.
        /// </summary>
        public const string IsOfType = "$0.IsOfType(\"$1\", $1, typeof(/*Value*/));";

        /// <summary>
        /// The is maximal.
        /// </summary>
        public const string IsMaximum = "$0.IsMaximum(\"$1\", $1, /*Value*/);";

        /// <summary>
        /// The is miminal.
        /// </summary>
        public const string IsMinimal = "$0.IsMinimal(\"$1\", $1, /*Value*/);";

        /// <summary>
        /// The is not out of range.
        /// </summary>
        public const string IsNotOutOfRange = "$0.IsNotOutOfRange(\"$1\", $1, /*MinValue*/, /*MaxValue*/);";

        /// <summary>
        /// The is not null or empty.
        /// </summary>
        public const string IsNotNullOrEmpty = "$0.IsNotNullOrEmpty(\"$1\", $1);";

        /// <summary>
        /// The is not null or whitespace.
        /// </summary>
        public const string IsNotNullOrWhitespace = "$0.IsNotNullOrWhitespace(\"$1\", $1);";

        /// <summary>
        /// The is not null or empty array.
        /// </summary>
        public const string IsNotNullOrEmptyArray = "$0.IsNotNullOrEmptyArray(\"$1\", $1);";

        /// <summary>
        /// The catel argument is not null statement pattern.
        /// </summary>
        public const string IsNotNull = "$0.IsNotNull(\"$1\", $1);";
    }
}