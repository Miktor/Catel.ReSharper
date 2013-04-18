// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeneratePropertyDataAction.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.Actions
{
    using Catel.Logging;
    using Catel.ReSharper.CatelProperties.Providers;

    using JetBrains.ActionManagement;
    using JetBrains.ReSharper.Feature.Services.Generate.Actions;
    using JetBrains.UI.RichText;

    /// <summary>
    /// Generate property data action.
    /// </summary>
    [ActionHandler(Id)]
    public class GeneratePropertyDataAction : GenerateActionBase<GeneratePropertyDataItemProvider>
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The generate property data action id
        /// </summary>
        public const string Id = "Generate.PropertyData";

        /// <summary>
        /// Gets Caption.
        /// </summary>
        /// <remarks>Where this caption is shown?</remarks>
        protected override RichText Caption
        {
            get { return "Generate Catel properties"; }
        }

        /// <summary>
        /// Gets a value indicating whether ShowMenuWithOneItem.
        /// </summary>
        protected override bool ShowMenuWithOneItem
        {
            get { return true; }
        }
    }
}