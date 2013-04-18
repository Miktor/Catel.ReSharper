// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyDataBuilderBase.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Builders
{
    using System.Collections.Generic;

    using JetBrains.ReSharper.Feature.Services.CSharp.Generate;
    using JetBrains.ReSharper.Feature.Services.Generate;

    /// <summary>
    /// The property data builder base.
    /// </summary>
    internal abstract class PropertyDataBuilderBase : GeneratorBuilderBase<CSharpGeneratorContext>
    {
#if R70 || R71 || R80

        /// <summary>
        /// Get global options.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The collection of <see cref="IGeneratorOption"/>.
        /// </returns>
        protected override IList<IGeneratorOption> GetGlobalOptions(CSharpGeneratorContext context)
        {
            return GetGeneratorOptions();
        }

#elif R61
    
    
        /// <summary>
        /// Get global options.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The collection of <see cref="IGeneratorOption"/>.
        /// </returns>
        public override IList<IGeneratorOption> GetGlobalOptions(CSharpGeneratorContext context)
        {
            return GetGeneratorOptions();
        }
#endif

        /// <summary>
        /// The get generator options.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.IList`1[T -&gt; JetBrains.ReSharper.Feature.Services.Generate.IGeneratorOption].
        /// </returns>
        private static IList<IGeneratorOption> GetGeneratorOptions()
        {
            return new List<IGeneratorOption>
                {
                    new GeneratorOptionBoolean(OptionIds.IncludePropertyInSerialization, OptionTitles.IncludePropertyInSerialization, true) { Persist = false }, 
                    new GeneratorOptionBoolean(OptionIds.ImplementPropertyChangedNotificationMethod, OptionTitles.ImplementPropertyChangedNotificationMethod, false) { Persist = false }, 
                    new GeneratorOptionBoolean(OptionIds.ForwardEventArgumentToImplementedPropertyChangedNotificationMethod, OptionTitles.ForwardEventArgumentToImplementedPropertyChangedNotificationMethod, false) { Persist = false }
                };
        }

        /// <summary>
        /// The option titles
        /// </summary>
        protected static class OptionTitles
        {
            /// <summary>
            /// Forward the event argument to implemented property changed notification method option title.
            /// </summary>
            public const string ForwardEventArgumentToImplementedPropertyChangedNotificationMethod = "Forward the event argument to property changed notification method";

            /// <summary>
            /// Implement property changed notification method option title.
            /// </summary>
            public const string ImplementPropertyChangedNotificationMethod = "Implement property changed &notification method";

            /// <summary>
            /// The include property in serialization title.
            /// </summary>
            public const string IncludePropertyInSerialization = "Include property on &serialization";
        }

        /// <summary>
        /// The option ids
        /// </summary>
        protected static class OptionIds
        {
            /// <summary>
            /// The implement property changed event handler method option id
            /// </summary>
            public const string ImplementPropertyChangedNotificationMethod = "ImplementPropertyChangedNotificationMethod";

            /// <summary>
            /// The forward event argument to implemented property changed event handler method option id
            /// </summary>
            public const string ForwardEventArgumentToImplementedPropertyChangedNotificationMethod = "ForwardEventArgumentToImplementedPropertyChangedNotificationMethod";

            /// <summary>
            /// The include property in serialization id.
            /// </summary>
            public const string IncludePropertyInSerialization = "IncludePropertyOnSerialization";
        }
    }
}