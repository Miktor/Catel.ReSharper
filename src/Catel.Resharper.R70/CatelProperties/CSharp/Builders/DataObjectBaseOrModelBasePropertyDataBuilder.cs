// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataObjectBasePropertyDataBuilder.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Builders
{
    using System.Collections.Generic;
    using System.Linq;

    using Catel.Logging;

    using JetBrains.ReSharper.Feature.Services.CSharp.Generate;
    using JetBrains.ReSharper.Feature.Services.Generate;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Tree;

    /// <summary>
    /// The c sharp property data builder.
    /// </summary>
    [GeneratorBuilder(WellKnownGenerationActionKinds.GenerateCatelDataProperties, typeof(CSharpLanguage))]
    internal sealed class DataObjectBaseOrModelBasePropertyDataBuilder : PropertyDataBuilderBase
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        #region Public Properties

        /// <summary>
        /// Gets Priority.
        /// </summary>
        public override double Priority
        {
            get { return 0; }
        }
        #endregion

        #region Public Methods and Operators

#if R70 || R71 || R80
    
        /// <summary>
        /// The process.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="context"/> is <c>null</c>.</exception>
        protected override void Process(CSharpGeneratorContext context)

#elif R61

        /// <summary>
        /// The process.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="context"/> is <c>null</c>.
        /// </exception>
        public override void Process(CSharpGeneratorContext context)
#endif
        {
            Argument.IsNotNull("context", context);

            CSharpElementFactory factory = CSharpElementFactory.GetInstance(context.Root.GetPsiModule());
            List<GeneratorDeclaredElement<ITypeOwner>> typeOwners = context.InputElements.OfType<GeneratorDeclaredElement<ITypeOwner>>().ToList();

            bool includeInSerialization = bool.Parse(context.GetGlobalOptionValue(OptionIds.IncludePropertyInSerialization));
            bool notificationMethod = bool.Parse(context.GetGlobalOptionValue(OptionIds.ImplementPropertyChangedNotificationMethod));
            bool forwardEventArgument = bool.Parse(context.GetGlobalOptionValue(OptionIds.ForwardEventArgumentToImplementedPropertyChangedNotificationMethod));

            var propertyConverter = new PropertyConverter(factory, context.PsiModule, (IClassDeclaration)context.ClassDeclaration);
            foreach (var typeOwner in typeOwners)
            {
                ITypeOwner propertyDeclaredElement = typeOwner.DeclaredElement;
                var propertyDeclaration = (IPropertyDeclaration)propertyDeclaredElement.GetDeclarations().FirstOrDefault();
                if (propertyDeclaration != null)
                {
                    propertyConverter.Convert(propertyDeclaration, includeInSerialization, notificationMethod, forwardEventArgument);
                }
            }
        }

        #endregion
    }
}