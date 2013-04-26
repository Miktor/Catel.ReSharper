// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArgumentCheckStatementPatterns.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// <summary>
//   The catel argument statement patterns.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments.Patterns
{
    /// <summary>
    /// The catel argument statement patterns.
    /// </summary>
    internal static class ArgumentCheckStatementPatterns
    {
        #region Constants

        /// <summary>
        /// The implements interface.
        /// </summary>
        public const string ImplementsInterface = "$0.ImplementsInterface(() => $1, typeof(/*Value*/));";

        /// <summary>
        /// The is maximal.
        /// </summary>
        public const string IsMaximum = "$0.IsMaximum(() => $1, /*Value*/);";

        /// <summary>
        /// The is miminal.
        /// </summary>
        public const string IsMinimal = "$0.IsMinimal(() => $1, /*Value*/);";

        /// <summary>
        /// The catel argument is not null statement pattern.
        /// </summary>
        public const string IsNotNull = "$0.IsNotNull(() => $1);";

        /// <summary>
        /// The is not null or empty.
        /// </summary>
        public const string IsNotNullOrEmpty = "$0.IsNotNullOrEmpty(() => $1);";

        /// <summary>
        /// The is not null or empty array.
        /// </summary>
        public const string IsNotNullOrEmptyArray = "$0.IsNotNullOrEmptyArray(() => $1);";

        /// <summary>
        /// The is not null or whitespace.
        /// </summary>
        public const string IsNotNullOrWhitespace = "$0.IsNotNullOrWhitespace(() => $1);";

        /// <summary>
        /// The is not out of range.
        /// </summary>
        public const string IsNotOutOfRange = "$0.IsNotOutOfRange(() => $1, /*MinValue*/, /*MaxValue*/);";

        /// <summary>
        /// The is of type.
        /// </summary>
        public const string IsOfType = "$0.IsOfType(() => $1, typeof(/*Value*/));";

        #endregion
    }
}