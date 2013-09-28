// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryWithKeyStringOfListOfTextRangeOrDocumentRangeExtensions.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.ReSharper.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
#if R80
    using JetBrains.DocumentModel;
#endif
    using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
    using JetBrains.ReSharper.LiveTemplates;
#if !R80
    using JetBrains.Util;
#endif

    /// <summary>
    /// The extension method of Dictionary{string, List{TextRange}} or Dictionary{string, List{DocumentRange}}.
    /// </summary>
    internal static class DictionaryWithKeyStringOfListOfTextRangeOrDocumentRangeExtensions
    {
        #region Public Methods and Operators
#if R80
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
        public static HotspotInfo[] AsHotspotInfos(this Dictionary<string, List<DocumentRange>> @this)
        {
            Argument.IsNotNull(() => @this);

            return (from fieldName in @this.Keys
                    let nameSuggestionsExpression = new NameSuggestionsExpression(new[] { " " })
                    let field = new TemplateField(fieldName, nameSuggestionsExpression, 0)
                    where @this[fieldName].Count > 0
                    select new HotspotInfo(field, @this[fieldName])).ToArray();
        }
#else

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
            Argument.IsNotNull(() => @this);

            return (from fieldName in @this.Keys
                    let nameSuggestionsExpression = new NameSuggestionsExpression(new[] { " " })
                    let field = new TemplateField(fieldName, nameSuggestionsExpression, 0)
                    where @this[fieldName].Count > 0
                    select new HotspotInfo(field, @this[fieldName])).ToArray();
        }
#endif

#if R80
        public static void Merge(this Dictionary<string, List<DocumentRange>> @this, Dictionary<string, List<DocumentRange>> fields)
        {
            Argument.IsNotNull(() => @this);

            if (fields != null)
            {
                foreach (var fieldName in fields.Keys)
                {
                    List<DocumentRange> textRanges = fields[fieldName];
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

#else
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
        public static void Merge(this Dictionary<string, List<TextRange>> @this, Dictionary<string, List<TextRange>> fields)
        {
            Argument.IsNotNull(() => @this);

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
#endif

        #endregion
    }
}