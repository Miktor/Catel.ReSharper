// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataObjectBaseOrModelBasePropertyProvider.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp
{
    using System.Linq;

    using Catel.Logging;
    using Catel.ReSharper.Identifiers;

    using JetBrains.ReSharper.Feature.Services.CSharp.Generate;
    using JetBrains.ReSharper.Feature.Services.Generate;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
#if R80
    using JetBrains.ReSharper.Psi.Tree;
#endif
    using JetBrains.Util;

    /// <summary>
    /// The c sharp view model base property provider.
    /// </summary>
    [GeneratorElementProvider(WellKnownGenerationActionKinds.GenerateCatelDataProperties, typeof(CSharpLanguage))]
    public class DataObjectBaseOrModelBasePropertyProvider : GeneratorProviderBase<CSharpGeneratorContext>
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
            get
            {
                return 0;
            }
        }
        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The populate.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="context"/> is <c>null</c>.
        /// </exception>
        public override void Populate(CSharpGeneratorContext context)
        {
            Argument.IsNotNull("context", context);

            IClassLikeDeclaration classLikeDeclaration = context.ClassDeclaration;
            ITypeElement declaredElement = classLikeDeclaration.DeclaredElement;
#if R80
            if (declaredElement is IClass && (declaredElement.IsDescendantOf(CatelCore.GetDataObjectBaseTypeElement(context.PsiModule, classLikeDeclaration.GetResolveContext())) || declaredElement.IsDescendantOf(CatelCore.GetModelBaseTypeElement(context.PsiModule, classLikeDeclaration.GetResolveContext()))))
#else
            if (declaredElement is IClass && (declaredElement.IsDescendantOf(CatelCore.GetDataObjectBaseTypeElement(context.PsiModule)) || declaredElement.IsDescendantOf(CatelCore.GetModelBaseTypeElement(context.PsiModule))))
#endif
            {
                // TODO: Consider remove or improve this restriction, walking to super types declaration. 
                // (declaredElement.GetSuperTypes().FirstOrDefault().GetTypeElement().GetDeclarations().FirstOrDefault() as IClassLikeDeclaration).GetCSharpRegisterPropertyNames();
                // List<string> registeredPropertyNames = classLikeDeclaration.GetCSharpRegisterPropertyNames();

                // NOTE: ProvidedElements collection only includes auto properties which it name is not used to register a data property.
                // context.ProvidedElements.AddRange(from member in declaredElement.GetMembers().OfType<IProperty>() let propertyDeclaration = member.GetDeclarations().FirstOrDefault() as IPropertyDeclaration where propertyDeclaration != null && (!registeredPropertyNames.Contains(member.ShortName) && propertyDeclaration.IsAuto) select new GeneratorDeclaredElement<ITypeOwner>(member));
                context.ProvidedElements.AddRange(from member in declaredElement.GetMembers().OfType<IProperty>() let propertyDeclaration = member.GetDeclarations().FirstOrDefault() as IPropertyDeclaration where propertyDeclaration != null && propertyDeclaration.IsAuto select new GeneratorDeclaredElement<ITypeOwner>(member));
            }
        }

        #endregion
    }
}