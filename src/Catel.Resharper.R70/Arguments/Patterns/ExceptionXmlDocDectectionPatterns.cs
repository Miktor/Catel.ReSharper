// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionXmlDocDectectionPatterns.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// <summary>
//   The xml doc dectection pattern.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments.Patterns
{
    /// <summary>
    /// The xml doc dectection pattern.
    /// </summary>
    internal static class ExceptionXmlDocDectectionPatterns
    {
        #region Constants

        /// <summary>
        /// The is match.
        /// </summary>
        public const string IsMatch = @"<exception\s+cref=""(System\.)?ArgumentException"">\s*The\s+<paramref\s+name=""{0}""\s*/>\s+doesn't\s+match\s+with\s+pattern\s+<c><!\[CDATA\[[^]+]\]\]></c>\s*\.\s*</exception>";

        /// <summary>
        /// The is maximal.
        /// </summary>
        public const string IsMaximum = @"<exception\s+cref=""(System\.)?ArgumentOutOfRangeException"">\s*If\s+<paramref\s+name=""{0}""\s*/>\s+is\s+larger\s+than\s+<c>[^<]+</c>\s*\.\s*</exception>";

        /// <summary>
        /// The is minimal.
        /// </summary>
        public const string IsMinimal = @"<exception\s+cref=""(System\.)?ArgumentOutOfRangeException"">\s*If\s+<paramref\s+name=""{0}""\s*/>\s+is\s+smaller\s+than\s+<c>[^<]+</c>\s*\.\s*</exception>";

        /// <summary>
        /// The is not match.
        /// </summary>
        public const string IsNotMatch = @"<exception\s+cref=""(System\.)?ArgumentException"">\s*The\s+<paramref\s+name=""{0}""\s*/>\s+does\s+match\s+with\s+pattern\s+<c><!\[CDATA\[[^]+]\]\]></c>\s*\.\s*</exception>";

        /// <summary>
        /// The argument is not null doc pattern.
        /// </summary>
        public const string IsNotNull = @"<exception\s+cref=""(System\.)?ArgumentNullException"">\s*If\s+<paramref\s+name=""{0}""\s*/>\s+is\s+<c>null</c>\s*\.\s*</exception>";

        /// <summary>
        /// The is not out of range.
        /// </summary>
        public const string IsNotOutOfRange = @"<exception\s+cref=""(System\.)?ArgumentOutOfRangeException"">\s*If\s+<paramref\s+name=""{0}""\s*/>\s+is\s+not\s+between\s+<c>[^<]+</c>\s+and\s+<c>[^<]+</c>\s*\.\s*</exception>";

        /// <summary>
        /// The is of type.
        /// </summary>
        public const string IsOfType = @"<exception\s+cref=""(System\.)?ArgumentException"">\s*If\s+<paramref\s+name=""{0}""\s*/>\s+is\s+not\s+of\s+type\s+<see\s+cref[^/]+/>\s*\.\s*</exception>";

        /// <summary>
        /// The argument not null or empty doc pattern.
        /// </summary>
        public const string NotNullOrEmpty = @"<exception\s+cref=""(System\.)?ArgumentException"">\s*If\s+<paramref\s+name=""{0}""\s*/>\s+is\s+<c>null</c>or\s+an\s+empty\s*\.\s*</exception>";

        /// <summary>
        /// The argument not null or empty array doc pattern.
        /// </summary>
        public const string NotNullOrEmptyArray = @"<exception\s+cref=""(System\.)?ArgumentException"">\s*If\s+<paramref\s+name=""{0}""\s*/>\s+is\s+<c>null</c>or\s+an\s+empty\s+array\s*\.\s*</exception>";

        #endregion
    }
}