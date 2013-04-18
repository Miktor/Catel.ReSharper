// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryWithKeyStringOfListOfTextRangeExtensions.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.ReSharper.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
    using JetBrains.ReSharper.LiveTemplates;
    using JetBrains.Util;

    /// <summary>
    /// The extension method of Dictionary{string, List{TextRange}}.
    /// </summary>
    internal static class DictionaryWithKeyStringOfListOfTextRangeExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the hotspot information.
        /// </summary>
        /// <param name="this">
        /// The instance.
        /// </param>
        /// <returns>
        /// Hotspot information
        /// </returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="this"/> is <c>null</c>.</exception>
        public static HotspotInfo[] AsHotspotInfos(this Dictionary<string, List<TextRange>> @this)
        {
            Argument.IsNotNull("@this", @this);

            return (from fieldName in @this.Keys
                    let nameSuggestionsExpression = new NameSuggestionsExpression(new[] { " " })
                    let field = new TemplateField(fieldName, nameSuggestionsExpression, 0)
                    where @this[fieldName].Count > 0
                    select new HotspotInfo(field, @this[fieldName])).ToArray();
        }

        /// <summary>
        /// The merge.
        /// </summary>
        /// <param name="this">
        /// The self instance.
        /// </param>
        /// <param name="fields">
        /// The comment fields.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="this"/> is <c>null</c>.
        /// </exception>
        public static void Merge(
            this Dictionary<string, List<TextRange>> @this, Dictionary<string, List<TextRange>> fields)
        {
            Argument.IsNotNull("@this", @this);

            if (fields != null)
            {
                foreach (var fieldName in fields.Keys)
                {
                    List<TextRange> textRanges = fields[fieldName];
                    if (@this.ContainsKey(fieldName))
                    {
                        @this[fieldName].AddRange(textRanges);
                    }
                    else
                    {
                        @this.Add(fieldName, textRanges);
                    }
                }
            }
        }

        #endregion
    }
}