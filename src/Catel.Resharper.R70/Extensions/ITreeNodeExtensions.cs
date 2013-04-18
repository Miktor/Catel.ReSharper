// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITreeNodeExtensions.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.ReSharper.Extensions
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.Util;

    /// <summary>
    /// The i tree node extensions.
    /// </summary>
    internal static class ITreeNodeExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Get the fields.
        /// </summary>
        /// <param name="this">
        /// The self instance.
        /// </param>
        /// <returns>
        /// The fields
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="this"/> is <c>null</c>.
        /// </exception>
        public static Dictionary<string, List<TextRange>> GetFields(this ITreeNode @this)
        {
            Argument.IsNotNull("@this", @this);
            var fields = new Dictionary<string, List<TextRange>>();

            // NOTE: The expression 'field' pattern.
            const string FieldPattern = "/[*]([^*]+?)[*]/";
            var regex = new Regex(FieldPattern, RegexOptions.IgnorePatternWhitespace);
            string noteText = @this.GetText();
            MatchCollection commentMatchCollection = regex.Matches(noteText);
            foreach (Match match in commentMatchCollection)
            {
                string fieldName = match.Groups[1].Value;
                if (!fields.ContainsKey(fieldName))
                {
                    fields.Add(fieldName, new List<TextRange>());
                }

                int startOffSet = @this.GetTreeStartOffset().Offset + match.Index;
                int endOffSet = startOffSet + match.Length;

                const string TypeOfValueExpressionPattern = "typeof[(]\\s" + FieldPattern + "[)]";
                if (Regex.IsMatch(noteText, TypeOfValueExpressionPattern))
                {
                    // PATCH: When "typeof(/*Value*/)" is introduced the editor overreact and convert it to "typeof( /*Value*/)", note the awkward space, so...
                    startOffSet--;
                }

                fields[fieldName].Add(@this.GetDocumentRange().SetStartTo(startOffSet).SetEndTo(endOffSet).TextRange);
            }

            return fields;
        }

        #endregion
    }
}