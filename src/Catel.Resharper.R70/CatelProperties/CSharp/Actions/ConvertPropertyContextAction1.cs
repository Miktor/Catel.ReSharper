// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConvertPropertyContextAction1.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Actions
{
    using Catel.Logging;

    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.ReSharper.Psi.CSharp.Tree;

    /// <summary>
    ///     Convert to property data with changed notification context action
    /// </summary>
    [ContextAction(Name = Name, Group = "C#", Description = Description, Priority = -21)]
    public sealed class ConvertPropertyContextAction1 : PropertyContextActionBase
    {
        #region Constants

        /// <summary>
        /// The description.
        /// </summary>
        private const string Description = "ConvertPropertyContextAction1Description";

        /// <summary>
        /// The name.
        /// </summary>
        private const string Name = "ConvertPropertyContextAction1";

        #endregion

        #region Static Fields

        /// <summary>
        ///     The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConvertPropertyContextAction1"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider
        /// </param>
        public ConvertPropertyContextAction1(ICSharpContextActionDataProvider provider)
            : base(provider)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets Text.
        /// </summary>
        public override string Text
        {
            get
            {
                return "To Catel property with property changed notification method";
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The modify class body.
        /// </summary>
        /// <param name="propertyConverter">
        /// The property converter.
        /// </param>
        /// <param name="propertyDeclaration">
        /// The property declaration.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="propertyConverter"/> is <c>null</c>.
        /// </exception>
        protected override void ConvertProperty(
            PropertyConverter propertyConverter, IPropertyDeclaration propertyDeclaration)
        {
            Argument.IsNotNull("propertyConverter", propertyConverter);

            propertyConverter.Convert(propertyDeclaration, true, true);
        }

        #endregion
    }
}