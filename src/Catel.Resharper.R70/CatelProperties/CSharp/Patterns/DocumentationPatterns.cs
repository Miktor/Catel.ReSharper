// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationPatterns.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Patterns
{
    /// <summary>
    /// The xml doc patterns
    /// </summary>
    internal static class DocumentationPatterns
    {
        /// <summary>
        /// The property data xml doc pattern
        /// </summary>
        public const string PropertyData = "<summary>Register the {0} property so it is known in the class.</summary>";

        /// <summary>
        /// The property changed notification method xml doc pattern.
        /// </summary>
        public const string PropertyChangedNotification = "<summary>Occurs when the value of the {0} property is changed.</summary>";

        /// <summary>
        /// The property changed notification method xml doc pattern.
        /// </summary>
        public const string PropertyChangedNotificationMethodWithEventArgument = "<summary>Occurs when the value of the {0} property is changed.</summary>\n<param name=\"e\">The event argument</param>";
    }
}