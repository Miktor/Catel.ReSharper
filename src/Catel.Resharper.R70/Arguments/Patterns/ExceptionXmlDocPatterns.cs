// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionXmlDocPatterns.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments.Patterns
{
    /// <summary>
    /// The xml doc patterns.
    /// </summary>
    /// <remarks>
    /// TODO: Move out as parameters the exception types
    /// </remarks>
    internal static class ExceptionXmlDocPatterns
    {
        /// <summary>
        /// The implements interface.
        /// </summary>
        public const string ImplementsInterface = "<exception cref=\"System.ArgumentException\">The <paramref name=\"{0}\"/> does not implement the <see cref=\"/*Value*/\"/> interface.</exception>";

        /// <summary>
        /// The is of type.
        /// </summary>
        public const string IsOfType = "<exception cref=\"System.ArgumentException\">The <paramref name=\"{0}\"/> is not of type <see cref=\"/*Value*/\"/>.</exception>";

        /// <summary>
        /// The is minimal.
        /// </summary>
        public const string IsMinimal = "<exception cref=\"System.ArgumentOutOfRangeException\">The <paramref name=\"{0}\"/> is larger than <c>/*Value*/</c>.</exception>";

        /// <summary>
        /// The is maximal.
        /// </summary>
        public const string IsMaximum = "<exception cref=\"System.ArgumentOutOfRangeException\">The <paramref name=\"{0}\"/> is smaller than <c>/*Value*/</c>.</exception>";

        /// <summary>
        /// The is not out of range.
        /// </summary>
        public const string IsNotOutOfRange = "<exception cref=\"System.ArgumentOutOfRangeException\">The <paramref name=\"{0}\"/> is not between <c>/*MinValue*/</c> and <c>/*MaxValue*/</c>.</exception>";

        /// <summary>
        /// The not null or empty doc pattern.
        /// </summary>
        public const string IsNotNullOrWhitespace = "<exception cref=\"System.ArgumentException\">The <paramref name=\"{0}\"/> is <c>null</c> or whitespace.</exception>";

        /// <summary>
        /// The not null or empty doc pattern.
        /// </summary>
        public const string IsNotNullOrEmpty = "<exception cref=\"System.ArgumentException\">The <paramref name=\"{0}\"/> is <c>null</c> or empty.</exception>";

        /// <summary>
        /// The not null or empty array doc pattern.
        /// </summary>
        public const string IsNotNullOrEmptyArray = "<exception cref=\"System.ArgumentException\">The <paramref name=\"{0}\"/> is <c>null</c> or an empty array.</exception>";

        /// <summary>
        /// The argument is not null xml doc pattern.
        /// </summary>
        public const string IsNotNull = "<exception cref=\"System.ArgumentNullException\">The <paramref name=\"{0}\"/> is <c>null</c>.</exception>";
    }
}