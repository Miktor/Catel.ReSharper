// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBaseModelPropertyProvider.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Catel.Logging;
    using Catel.ReSharper.Identifiers;

    using JetBrains.ReSharper.Feature.Services.CSharp.Generate;
    using JetBrains.ReSharper.Feature.Services.Generate;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Resolve;
#if R80
    using JetBrains.ReSharper.Psi.Tree;
#endif
    using JetBrains.ReSharper.Psi.Util;
    using JetBrains.Util;

    /// <summary>
    /// The view model base model property provider.
    /// </summary>
    [GeneratorElementProvider(WellKnownGenerationActionKinds.ExposeModelPropertiesAsCatelDataProperties, typeof(CSharpLanguage))]
    public class ViewModelBaseModelPropertyProvider : GeneratorProviderBase<CSharpGeneratorContext>
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

        /// <summary>
        /// The populate.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="context"/> is <c>null</c>.</exception>
        public override void Populate(CSharpGeneratorContext context)
        {
            Argument.IsNotNull(() => context);

            if (context.Anchor.Parent != null && context.Anchor.Parent.Parent is IClassLikeDeclaration)
            {
                IClassLikeDeclaration classLikeDeclaration = context.ClassDeclaration;
                ITypeElement declaredElement = classLikeDeclaration.DeclaredElement;
#if R80
                var moduleReferenceResolveContext = context.Anchor.GetResolveContext();
                ITypeElement viewModelBaseElement = TypeFactory.CreateTypeByCLRName(CatelMVVM.ViewModelBase, context.PsiModule, moduleReferenceResolveContext).GetTypeElement();
#else
                ITypeElement viewModelBaseElement = TypeFactory.CreateTypeByCLRName(CatelMVVM.ViewModelBase, context.PsiModule).GetTypeElement();
#endif
                if (declaredElement is IClass && declaredElement.IsDescendantOf(viewModelBaseElement))
                {
#if R80
                IDeclaredType modelAttributeClrType = TypeFactory.CreateTypeByCLRName(CatelMVVM.ModelAttribute, context.PsiModule, moduleReferenceResolveContext);
                IDeclaredType viewModelToModelAttributeClrType = TypeFactory.CreateTypeByCLRName(CatelMVVM.ViewModelToModelAttribute, context.PsiModule, moduleReferenceResolveContext);
#else
                    IDeclaredType modelAttributeClrType = TypeFactory.CreateTypeByCLRName(CatelMVVM.ModelAttribute, context.PsiModule);
                    IDeclaredType viewModelToModelAttributeClrType = TypeFactory.CreateTypeByCLRName(CatelMVVM.ViewModelToModelAttribute, context.PsiModule);
#endif
                    var properties = new List<IProperty>();
                    ITypeElement element = declaredElement;
                    do
                    {
                        properties.AddRange(element.GetMembers().OfType<IProperty>());
                        var declaredType = element.GetSuperTypes().FirstOrDefault(type => type.GetClrName().FullName != CatelMVVM.ViewModelBase);
                        element = declaredType != null ? declaredType.GetTypeElement() : null;
                    }
                    while (element != null);

                    Log.Debug("Looking for ViewModelToModel properties");
                    var viewModelProperties = new Dictionary<string, List<string>>();
                    foreach (IProperty property in properties)
                    {
#if R80
                    IAttributeInstance viewModelToModel = property.GetAttributeInstances(false).FirstOrDefault(instance => Equals(instance.GetAttributeType(), viewModelToModelAttributeClrType));
#else
                        IAttributeInstance viewModelToModel = property.GetAttributeInstances(false).FirstOrDefault(instance => Equals(instance.AttributeType, viewModelToModelAttributeClrType));
#endif
                        if (viewModelToModel != null)
                        {
                            var positionParameters = viewModelToModel.PositionParameters().ToList();
                            var modelName = (string)positionParameters[0].ConstantValue.Value;
                            var propertyName = (string)positionParameters[1].ConstantValue.Value;
                            if (string.IsNullOrEmpty(propertyName))
                            {
                                propertyName = property.ShortName;
                            }

                            if (!viewModelProperties.ContainsKey(modelName))
                            {
                                viewModelProperties.Add(modelName, new List<string>());
                            }

                            viewModelProperties[modelName].Add(propertyName);
                        }
                    }

                    Log.Debug("Looking for Model properties");

                    foreach (IProperty property in properties)
                    {
#if R80
                    if (property.GetAttributeInstances(false).FirstOrDefault(instance => Equals(instance.GetAttributeType(), modelAttributeClrType)) != null)
#else
                        if (property.GetAttributeInstances(false).FirstOrDefault(instance => Equals(instance.AttributeType, modelAttributeClrType)) != null)
#endif
                        {
                            var propertyDeclaration = property.GetDeclarations().FirstOrDefault() as IPropertyDeclaration;
                            if (propertyDeclaration != null && propertyDeclaration.Type is IDeclaredType)
                            {
                                var declaredType = propertyDeclaration.Type as IDeclaredType;
                                var typeElement = declaredType.GetTypeElement();
                                if (typeElement != null)
                                {
                                    IProperty copyProperty = property;
                                    context.ProvidedElements.AddRange(from member in typeElement.GetMembers().OfType<IProperty>() where !viewModelProperties.ContainsKey(copyProperty.ShortName) || !viewModelProperties[copyProperty.ShortName].Contains(member.ShortName) select new GeneratorDeclaredElement(member, EmptySubstitution.INSTANCE, copyProperty));
                                }
                            }
                        }
                    }
                }                
            }
        }

        #endregion
    }
}