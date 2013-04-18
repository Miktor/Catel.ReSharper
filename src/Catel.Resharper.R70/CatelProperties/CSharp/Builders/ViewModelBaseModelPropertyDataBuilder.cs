// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBaseModelPropertyDataBuilder.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Builders
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Catel.Logging;
    using Catel.ReSharper.CatelProperties.CSharp.Patterns;
    using Catel.ReSharper.Identifiers;

    using JetBrains.ReSharper.Feature.Services.CSharp.Generate;
    using JetBrains.ReSharper.Feature.Services.Generate;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
#if R80
    using JetBrains.ReSharper.Psi.Tree;
#endif
    using JetBrains.Util;

    /// <summary>
    /// The model property data builder.
    /// </summary>
    [GeneratorBuilder(WellKnownGenerationActionKinds.ExposeModelPropertiesAsCatelDataProperties, typeof(CSharpLanguage))]
    internal sealed class ViewModelBaseModelPropertyDataBuilder : PropertyDataBuilderBase
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the priority.
        /// </summary>
        public override double Priority
        {
            get { return 0; }
        }

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
#if R80
            IDeclaredType viewModelToModelAttributeClrType = TypeFactory.CreateTypeByCLRName(CatelMVVM.ViewModelToModelAttribute, context.PsiModule, context.Anchor.GetResolveContext());
#else
            IDeclaredType viewModelToModelAttributeClrType = TypeFactory.CreateTypeByCLRName(CatelMVVM.ViewModelToModelAttribute, context.PsiModule);
#endif

            List<GeneratorDeclaredElement> declaredElements = context.InputElements.OfType<GeneratorDeclaredElement>().ToList();
            IClassLikeDeclaration classLikeDeclaration = context.ClassDeclaration;

            bool includeInSerialization = bool.Parse(context.GetGlobalOptionValue(OptionIds.IncludePropertyInSerialization));
            bool notificationMethod = bool.Parse(context.GetGlobalOptionValue(OptionIds.ImplementPropertyChangedNotificationMethod));
            bool forwardEventArgument = bool.Parse(context.GetGlobalOptionValue(OptionIds.ForwardEventArgumentToImplementedPropertyChangedNotificationMethod));
            var propertyConverter = new PropertyConverter(factory, context.PsiModule, (IClassDeclaration)classLikeDeclaration);
            foreach (GeneratorDeclaredElement declaredElement in declaredElements)
            {
                var model = (IProperty)declaredElement.GetGroupingObject();
                var modelProperty = (IProperty)declaredElement.DeclaredElement;
                if (model != null)
                {
                    Log.Debug("Computing property name");
                    string propertyName = string.Empty;
                    if (!classLikeDeclaration.MemberDeclarations.ToList().Exists(declaration => declaration.DeclaredName == modelProperty.ShortName))
                    {
                        propertyName = modelProperty.ShortName;
                    }

                    if (string.IsNullOrEmpty(propertyName) && !classLikeDeclaration.MemberDeclarations.ToList().Exists(declaration => declaration.DeclaredName == model.ShortName + modelProperty.ShortName))
                    {
                        propertyName = model.ShortName + modelProperty.ShortName;
                    }

                    int idx = 0;
                    while (string.IsNullOrEmpty(propertyName))
                    {
                        if (!classLikeDeclaration.MemberDeclarations.ToList().Exists(declaration => declaration.DeclaredName == model.ShortName + modelProperty.ShortName + idx.ToString(CultureInfo.InvariantCulture)))
                        {
                            propertyName = model.ShortName + modelProperty.ShortName + idx.ToString(CultureInfo.InvariantCulture);
                        }

                        idx++;
                    }

                    Log.Debug("Adding property '{0}'", propertyName);
                    var propertyDeclaration = (IPropertyDeclaration)factory.CreateTypeMemberDeclaration(ImplementationPatterns.AutoProperty, modelProperty.Type, propertyName);
                    propertyDeclaration = ModificationUtil.AddChildAfter(classLikeDeclaration, model.GetDeclarations().FirstOrDefault(), propertyDeclaration);
#if R80
                    var fixedArguments = new List<AttributeValue> { new AttributeValue(ClrConstantValueFactory.CreateStringValue(model.ShortName, context.PsiModule, context.Anchor.GetResolveContext())) };
#else
                    var fixedArguments = new List<AttributeValue> { new AttributeValue(ClrConstantValueFactory.CreateStringValue(model.ShortName, context.PsiModule)) };
#endif
                    if (propertyName != modelProperty.ShortName)
                    {
#if R80
                        fixedArguments.Add(new AttributeValue(ClrConstantValueFactory.CreateStringValue(model.ShortName, context.PsiModule, context.Anchor.GetResolveContext())));
#else
                        fixedArguments.Add(new AttributeValue(ClrConstantValueFactory.CreateStringValue(model.ShortName, context.PsiModule)));
#endif
                    }

                    Log.Debug("Adding attribute ViewModelToModel to property '{0}'", propertyName);
                    IAttribute attribute = factory.CreateAttribute(viewModelToModelAttributeClrType.GetTypeElement(), fixedArguments.ToArray(), new Pair<string, AttributeValue>[] { });
                    propertyDeclaration.AddAttributeAfter(attribute, null);
                    propertyConverter.Convert(propertyDeclaration, includeInSerialization, notificationMethod, forwardEventArgument);
                }
            }
        }
    }
}