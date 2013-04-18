// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImplementationPatterns.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Patterns
{
    /// <summary>
    /// The implementation patterns
    /// </summary>
    /// <remarks>
    /// The format of this pattern is compatible with the ReSharper SDK's element factory methods that used dollar $n notation
    /// </remarks>
    internal static class ImplementationPatterns
    {
        /// <summary>
        /// The property changed notification method with event argument implementation pattern
        /// </summary>
        public const string PropertyChangedNotificationMethodWithEventArgs = "private void $0($1 e) { throw new System.NotImplementedException(); }";

        /// <summary>
        /// The property changed notification method implementation pattern
        /// </summary>
        public const string PropertyChangedNotificationMethod = "private void $0() { throw new System.NotImplementedException(); }";

        /// <summary>
        ///  Property data member declaration pattern
        /// </summary>
        public const string PropertyData = "public static readonly $2 $0Property = RegisterProperty(\"$0\", typeof($1));";

        /// <summary>
        ///  Property data non serialized member declaration pattern
        /// </summary>
        public const string PropertyDataNonSerialized = "public static readonly $2 $0Property = RegisterProperty(\"$0\", typeof($1), default($1), null, false);";

        /// <summary>
        ///  Property data member plus notification method declaration pattern
        /// </summary>
        public const string PropertyDataPlusNotificationMethod = "public static readonly $4 $1 = RegisterProperty(\"$0\", typeof($2), default($2), (s, e) => (($3)s).$5());";

        /// <summary>
        ///  Property data member plus notification method relaying event argument declaration pattern
        /// </summary>
        public const string PropertyDataWithNotificationMethodForwardingEventArgument = "public static readonly $4 $1 = RegisterProperty(\"$0\", typeof($2), default($2), (s, e) => (($3)s).$5(e));";

        /// <summary>
        /// The set accessor body pattern
        /// </summary>
        public const string PropertySetAccessor = "{ SetValue($0Property, value); }";

        /// <summary>
        /// The get accessor body pattern
        /// </summary>
        public const string PropertyGetAccessor = "{ return GetValue<$0>($1Property); }";

        /// <summary>
        /// The auto property.
        /// </summary>
        public const string AutoProperty = "public $0 $1 { get; set; }";

        /// <summary>
        ///  Property data non serialized member plus notification method relaying event argument declaration pattern
        /// </summary>
        public const string PropertyDataNonSerializedWithNotificationMethodForwardingEventArgument = "public static readonly $4 $1 = RegisterProperty(\"$0\", typeof($2), default($2), (s, e) => (($3)s).$5(e), false);";

        /// <summary>
        ///  Property data non serialized member plus notification method declaration pattern
        /// </summary>
        public const string PropertyDataNonSerializedPlusNotificationMethod = "public static readonly $4 $1 = RegisterProperty(\"$0\", typeof($2), default($2), (s, e) => (($3)s).$5(), false);";
    }
}