// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatelMVVM.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Identifiers
{
    using Catel.ReSharper.Helpers;

    using JetBrains.ReSharper.Psi;
#if R80
    using JetBrains.Metadata.Reader.API;
    using JetBrains.ReSharper.Psi.Modules;
#endif

    /// <summary>
    /// The MVVM well known type names.
    /// </summary>
    public static class CatelMVVM
    {
        /// <summary>
        /// The view model base type name.
        /// </summary>
        public const string ViewModelBase = "Catel.MVVM.ViewModelBase";

        /// <summary>
        /// The model attribute type name.
        /// </summary>
        public const string ModelAttribute = "Catel.MVVM.ModelAttribute";

        /// <summary>
        /// The view model to model attribute.
        /// </summary>
        public const string ViewModelToModelAttribute = "Catel.MVVM.ViewModelToModelAttribute";
#if R80
        /// <summary>
        /// The try get view model to model attribute type element.
        /// </summary>
        /// <param name="psiModule">
        /// The psi module.
        /// </param>
        /// <param name="typeElement">
        /// The type element.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public static bool TryGetViewModelToModelAttributeTypeElement(IPsiModule psiModule, IModuleReferenceResolveContext moduleReferenceResolveContext, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(ViewModelToModelAttribute, psiModule, moduleReferenceResolveContext, out typeElement);
        }

        /// <summary>
        /// The try get model attribute type element.
        /// </summary>
        /// <param name="psiModule">
        /// The psi module.
        /// </param>
        /// <param name="typeElement">
        /// The type element.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public static bool TryGetModelAttributeTypeElement(IPsiModule psiModule, IModuleReferenceResolveContext moduleReferenceResolveContext, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(ModelAttribute, psiModule, moduleReferenceResolveContext, out typeElement);
        }

        /// <summary>
        /// The try get view model base type element.
        /// </summary>
        /// <param name="psiModule">
        /// The psi module.
        /// </param>
        /// <param name="typeElement">
        /// The type element.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public static bool TryGetViewModelBaseTypeElement(IPsiModule psiModule, IModuleReferenceResolveContext moduleReferenceResolveContext, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(ViewModelBase, psiModule, moduleReferenceResolveContext, out typeElement);
        }       

#else

        /// <summary>
        /// The try get view model to model attribute type element.
        /// </summary>
        /// <param name="psiModule">
        /// The psi module.
        /// </param>
        /// <param name="typeElement">
        /// The type element.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public static bool TryGetViewModelToModelAttributeTypeElement(IPsiModule psiModule, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(ViewModelToModelAttribute, psiModule, out typeElement);
        }

        /// <summary>
        /// The try get model attribute type element.
        /// </summary>
        /// <param name="psiModule">
        /// The psi module.
        /// </param>
        /// <param name="typeElement">
        /// The type element.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public static bool TryGetModelAttributeTypeElement(IPsiModule psiModule, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(ModelAttribute, psiModule, out typeElement);
        }

        /// <summary>
        /// The try get view model base type element.
        /// </summary>
        /// <param name="psiModule">
        /// The psi module.
        /// </param>
        /// <param name="typeElement">
        /// The type element.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public static bool TryGetViewModelBaseTypeElement(IPsiModule psiModule, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(ViewModelBase, psiModule, out typeElement);
        }
#endif
    }
}