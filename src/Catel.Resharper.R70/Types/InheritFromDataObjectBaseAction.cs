// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InheritFromDataObjectBaseAction.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Types
{
    using Catel.ReSharper.Identifiers;

    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;

    /// <summary>
    ///     The convert to data object base action.
    /// </summary>
    [ContextAction(Name = Name, Group = "C#", Description = Description, Priority = -20)]
    public sealed class InheritFromDataObjectBaseAction : InheritFromActionBase
    {
        #region Constants

        /// <summary>
        /// The description.
        /// </summary>
        private const string Description = "InheritFromDataObjectBaseActionDescription";

        /// <summary>
        /// The name.
        /// </summary>
        private const string Name = "InheritFromDataObjectBaseAction";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InheritFromDataObjectBaseAction"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        public InheritFromDataObjectBaseAction(ICSharpContextActionDataProvider provider)
            : base(provider)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets SuperTypeName.
        /// </summary>
        protected override string SuperTypeName
        {
            get
            {
                return CatelCore.DataObjectBase;
            }
        }

        #endregion
    }
}