// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatelCore.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Identifiers
{
    using Catel.ReSharper.Helpers;

    using JetBrains.Metadata.Reader.API;
    using JetBrains.ReSharper.Psi;
#if R80
    using JetBrains.ReSharper.Psi.Modules;
#endif

    /// <summary>
    /// The well known type names.
    /// </summary>
    internal static class CatelCore
    {
        /// <summary>
        /// The AdvancedPropertyChangedEventArgs type name.
        /// </summary>
        public const string AdvancedPropertyChangedEventArgs = "Catel.Data.AdvancedPropertyChangedEventArgs";

        /// <summary>
        /// The DataObjectBase type name
        /// </summary>
        public const string DataObjectBase = "Catel.Data.DataObjectBase";

        /// <summary>
        /// The ModelBase type name
        /// </summary>
        public const string ModelBase = "Catel.Data.ModelBase";

        /// <summary>
        /// Argument type name.
        /// </summary>
        public const string Argument = "Catel.Argument";

        /// <summary>
        /// The PropertyData type name .
        /// </summary>
        public const string PropertyData = "Catel.Data.PropertyData";
#if R80
        /// <summary>
        /// Try get model base type element.
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
        public static bool TryGetModelBaseTypeElement(IPsiModule psiModule, IModuleReferenceResolveContext moduleReferenceResolveContext, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(ModelBase, psiModule, moduleReferenceResolveContext, out typeElement);
        }

        /// <summary>
        /// The get model base type element.
        /// </summary>
        /// <param name="psiModule">
        /// The psi module.
        /// </param>
        /// <returns>
        /// The JetBrains.ReSharper.Psi.ITypeElement.
        /// </returns>
        public static ITypeElement GetModelBaseTypeElement(IPsiModule psiModule, IModuleReferenceResolveContext moduleReferenceResolveContext)
        {
            ITypeElement result;
            TryGetModelBaseTypeElement(psiModule, moduleReferenceResolveContext, out result);
            return result;
        }

        /// <summary>
        /// The try get data object base.
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
        public static bool TryGetDataObjectBaseTypeElement(IPsiModule psiModule, IModuleReferenceResolveContext moduleReferenceResolveContext, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(DataObjectBase, psiModule, moduleReferenceResolveContext, out typeElement);
        }

        /// <summary>
        /// The try get argument type element.
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
        public static bool TryGetArgumentTypeElement(IPsiModule psiModule, IModuleReferenceResolveContext moduleReferenceResolveContext, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(Argument, psiModule, moduleReferenceResolveContext, out typeElement);
        }

        /// <summary>
        /// The try get property data type element.
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
        public static bool TryGetPropertyDataTypeElement(IPsiModule psiModule, IModuleReferenceResolveContext moduleReferenceResolveContext, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(PropertyData, psiModule, moduleReferenceResolveContext, out typeElement);
        }

        /// <summary>
        /// The try get advanced property changed event args type element.
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
        public static bool TryGetAdvancedPropertyChangedEventArgsTypeElement(IPsiModule psiModule, IModuleReferenceResolveContext moduleReferenceResolveContext, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(AdvancedPropertyChangedEventArgs, psiModule, moduleReferenceResolveContext, out typeElement);
        }

        /// <summary>
        /// The get data object base type element.
        /// </summary>
        /// <param name="psiModule">
        /// The psi module.
        /// </param>
        /// <returns>
        /// The JetBrains.ReSharper.Psi.ITypeElement.
        /// </returns>
        public static ITypeElement GetDataObjectBaseTypeElement(IPsiModule psiModule, IModuleReferenceResolveContext moduleReferenceResolveContext)
        {
            ITypeElement result;
            TryGetDataObjectBaseTypeElement(psiModule, moduleReferenceResolveContext, out result);
            return result;
        }
#else
        /// <summary>
        /// Try get model base type element.
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
        public static bool TryGetModelBaseTypeElement(IPsiModule psiModule, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(ModelBase, psiModule, out typeElement);
        }

        /// <summary>
        /// The get model base type element.
        /// </summary>
        /// <param name="psiModule">
        /// The psi module.
        /// </param>
        /// <returns>
        /// The JetBrains.ReSharper.Psi.ITypeElement.
        /// </returns>
        public static ITypeElement GetModelBaseTypeElement(IPsiModule psiModule)
        {
            ITypeElement result;
            TryGetModelBaseTypeElement(psiModule, out result);
            return result;
        }

        /// <summary>
        /// The try get data object base.
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
        public static bool TryGetDataObjectBaseTypeElement(IPsiModule psiModule, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(DataObjectBase, psiModule, out typeElement);
        }

        /// <summary>
        /// The try get argument type element.
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
        public static bool TryGetArgumentTypeElement(IPsiModule psiModule, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(Argument, psiModule, out typeElement);
        }

        /// <summary>
        /// The try get property data type element.
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
        public static bool TryGetPropertyDataTypeElement(IPsiModule psiModule, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(PropertyData, psiModule, out typeElement);
        }

        /// <summary>
        /// The try get advanced property changed event args type element.
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
        public static bool TryGetAdvancedPropertyChangedEventArgsTypeElement(IPsiModule psiModule, out ITypeElement typeElement)
        {
            return TypeHelper.TryGetTypeElement(AdvancedPropertyChangedEventArgs, psiModule, out typeElement);
        }

        /// <summary>
        /// The get data object base type element.
        /// </summary>
        /// <param name="psiModule">
        /// The psi module.
        /// </param>
        /// <returns>
        /// The JetBrains.ReSharper.Psi.ITypeElement.
        /// </returns>
        public static ITypeElement GetDataObjectBaseTypeElement(IPsiModule psiModule)
        {
            ITypeElement result;
            TryGetDataObjectBaseTypeElement(psiModule, out result);
            return result;
        }
#endif
    }
}