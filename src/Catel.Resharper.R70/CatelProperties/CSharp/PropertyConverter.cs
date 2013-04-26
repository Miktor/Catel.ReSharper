// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyConverter.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.CSharp
{
    using System;
    using System.Linq;

    using Catel.Logging;
    using Catel.ReSharper.CatelProperties.CSharp.Patterns;
    using Catel.ReSharper.CatelProperties.Patterns;
    using Catel.ReSharper.Identifiers;

    using JetBrains.Annotations;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
#if R80
    using JetBrains.ReSharper.Psi.Modules;
#endif
    using JetBrains.ReSharper.Psi.Tree;

    /// <summary>
    ///     The property converter.
    /// </summary>
    public class PropertyConverter
    {
        #region Static Fields

        /// <summary>
        ///     The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Fields

        /// <summary>
        ///     The class declaration.
        /// </summary>
        private readonly IClassDeclaration classDeclaration;

        /// <summary>
        ///     The factory.
        /// </summary>
        private readonly CSharpElementFactory factory;

        /// <summary>
        ///     The psi module.
        /// </summary>
        private readonly IPsiModule psiModule;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyConverter"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="psiModule">
        /// The psi Module.
        /// </param>
        /// <param name="classDeclaration">
        /// The class declaration.
        /// </param>
        public PropertyConverter(CSharpElementFactory factory, IPsiModule psiModule, IClassDeclaration classDeclaration)
        {
            Argument.IsNotNull("factory", factory);
            Argument.IsNotNull("psiModule", psiModule);
            Argument.IsNotNull("classDeclaration", classDeclaration);

            this.factory = factory;
            this.psiModule = psiModule;
            this.classDeclaration = classDeclaration;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="propertyDeclaration">
        /// The property declaration.
        /// </param>
        /// <param name="includeInSerialization">
        /// Includes the property in serialization
        /// </param>
        /// <param name="notificationMethod">
        /// The notification method.
        /// </param>
        /// <param name="forwardEventArgument">
        /// The forward event argument.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="propertyDeclaration"/> is not an auto property
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="propertyDeclaration"/> is <c>null</c>.
        /// </exception>
        public void Convert(
            [NotNull] IPropertyDeclaration propertyDeclaration, 
            bool includeInSerialization = true, 
            bool notificationMethod = false, 
            bool forwardEventArgument = false)
        {
            Argument.IsNotNull("propertyDeclaration", propertyDeclaration);

#if R80
            IDeclaredType propertyDataType = TypeFactory.CreateTypeByCLRName(CatelCore.PropertyData, this.psiModule, propertyDeclaration.GetResolveContext());
#else
            IDeclaredType propertyDataType = TypeFactory.CreateTypeByCLRName(CatelCore.PropertyData, this.psiModule);
#endif

            if (!propertyDeclaration.IsAuto)
            {
                throw new ArgumentException("The 'propertyDeclaration' is not auto");
            }

            string propertyName = propertyDeclaration.DeclaredName;
            string propertyDataName = this.ComputeMemberName(string.Format(NamePatterns.PropertyDataName, propertyName));

            IFieldDeclaration propertyDataMemberDeclaration;

            if (notificationMethod)
            {
                string methodName =
                    this.ComputeMemberName(string.Format(NamePatterns.NotificationMethodName, propertyName));

                IMethodDeclaration methodDeclaration;
                IDocCommentBlockNode methodComment;
                if (forwardEventArgument)
                {
                    if (includeInSerialization)
                    {
                        propertyDataMemberDeclaration =
                            (IFieldDeclaration)
                            this.factory.CreateTypeMemberDeclaration(
                                ImplementationPatterns.PropertyDataWithNotificationMethodForwardingEventArgument, 
                                propertyName, 
                                propertyDataName, 
                                propertyDeclaration.DeclaredElement.Type, 
                                this.classDeclaration.DeclaredName, 
                                propertyDataType.GetTypeElement(), 
                                methodName);
                    }
                    else
                    {
                        propertyDataMemberDeclaration =
                            (IFieldDeclaration)
                            this.factory.CreateTypeMemberDeclaration(
                                ImplementationPatterns
                                .PropertyDataNonSerializedWithNotificationMethodForwardingEventArgument, 
                                propertyName, 
                                propertyDataName, 
                                propertyDeclaration.DeclaredElement.Type, 
                                this.classDeclaration.DeclaredName, 
                                propertyDataType.GetTypeElement(), 
                                methodName);
                    }

#if R80
                    IDeclaredType advancedPropertyChangedEventArgsType = TypeFactory.CreateTypeByCLRName(CatelCore.AdvancedPropertyChangedEventArgs, this.psiModule, propertyDeclaration.GetResolveContext());
#else
                    IDeclaredType advancedPropertyChangedEventArgsType = TypeFactory.CreateTypeByCLRName(CatelCore.AdvancedPropertyChangedEventArgs, this.psiModule);
#endif
                    methodDeclaration =
                        (IMethodDeclaration)
                        this.factory.CreateTypeMemberDeclaration(
                            ImplementationPatterns.PropertyChangedNotificationMethodWithEventArgs, 
                            methodName, 
                            advancedPropertyChangedEventArgsType.GetTypeElement());
                    methodComment =
                        this.factory.CreateDocCommentBlock(
                            string.Format(
                                DocumentationPatterns.PropertyChangedNotificationMethodWithEventArgument, propertyName));
                }
                else
                {
                    if (includeInSerialization)
                    {
                        propertyDataMemberDeclaration =
                            (IFieldDeclaration)
                            this.factory.CreateTypeMemberDeclaration(
                                ImplementationPatterns.PropertyDataPlusNotificationMethod, 
                                propertyName, 
                                propertyDataName, 
                                propertyDeclaration.DeclaredElement.Type, 
                                this.classDeclaration.DeclaredName, 
                                propertyDataType.GetTypeElement(), 
                                methodName);
                    }
                    else
                    {
                        propertyDataMemberDeclaration =
                            (IFieldDeclaration)
                            this.factory.CreateTypeMemberDeclaration(
                                ImplementationPatterns.PropertyDataNonSerializedPlusNotificationMethod, 
                                propertyName, 
                                propertyDataName, 
                                propertyDeclaration.DeclaredElement.Type, 
                                this.classDeclaration.DeclaredName, 
                                propertyDataType.GetTypeElement(), 
                                methodName);
                    }

                    methodDeclaration =
                        (IMethodDeclaration)
                        this.factory.CreateTypeMemberDeclaration(
                            ImplementationPatterns.PropertyChangedNotificationMethod, methodName);
                    methodComment =
                        this.factory.CreateDocCommentBlock(
                            string.Format(DocumentationPatterns.PropertyChangedNotification, propertyName));
                }

                methodDeclaration = ModificationUtil.AddChildAfter(
                    this.classDeclaration, propertyDeclaration, methodDeclaration);

                // context.PutMemberDeclaration(methodDeclaration, null, declaration => new GeneratorDeclarationElement(declaration));
                // NOTE: Add xml doc to a method
                // TODO: Move this to an extension method
                // ICSharpTypeMemberDeclaration pushedMethodDeclaration = context.ClassDeclaration.MemberDeclarations.FirstOrDefault(declaration => declaration.DeclaredName == methodName);
                if (methodDeclaration != null && methodDeclaration.Parent != null)
                {
                    ModificationUtil.AddChildBefore(
                        methodDeclaration.Parent, methodDeclaration.FirstChild, methodComment);
                }
            }
            else if (includeInSerialization)
            {
                propertyDataMemberDeclaration =
                    (IFieldDeclaration)
                    this.factory.CreateTypeMemberDeclaration(
                        ImplementationPatterns.PropertyData, 
                        propertyName, 
                        propertyDeclaration.DeclaredElement.Type, 
                        propertyDataType.GetTypeElement(),
                        this.classDeclaration.DeclaredName);
            }
            else
            {
                propertyDataMemberDeclaration =
                    (IFieldDeclaration)
                    this.factory.CreateTypeMemberDeclaration(
                        ImplementationPatterns.PropertyDataNonSerialized, 
                        propertyName, 
                        propertyDeclaration.DeclaredElement.Type, 
                        propertyDataType.GetTypeElement(),
                        this.classDeclaration.DeclaredName);
            }

            // context.PutMemberDeclaration(propertyDataMemberDeclaration, null, declaration => new GeneratorDeclarationElement(declaration));
            var multipleFieldDeclaration =
                (IMultipleFieldDeclaration)
                ModificationUtil.AddChildBefore(
                    this.classDeclaration, propertyDeclaration, propertyDataMemberDeclaration.Parent);

            // NOTE: Add xml doc to a property
            // TODO: Move this to an extension method
            // ICSharpTypeMemberDeclaration pushedPropertyDataMemberDeclaration = context.ClassDeclaration.MemberDeclarations.FirstOrDefault(declaration => declaration.DeclaredName == propertyDataName);
            if (multipleFieldDeclaration != null && multipleFieldDeclaration.Parent != null)
            {
                IDocCommentBlockNode propertyComment =
                    this.factory.CreateDocCommentBlock(string.Format(DocumentationPatterns.PropertyData, propertyName));
                ModificationUtil.AddChildBefore(
                    multipleFieldDeclaration, multipleFieldDeclaration.FirstChild, propertyComment);
            }

            // TODO: Move this behavoir to an extension method or helper class is duplicated.
            foreach (IAccessorDeclaration accessorDeclaration in propertyDeclaration.AccessorDeclarations)
            {
                accessorDeclaration.SetBody(
                    accessorDeclaration.Kind == AccessorKind.GETTER
                        ? this.factory.CreateBlock(
                            ImplementationPatterns.PropertyGetAccessor, 
                            propertyDeclaration.DeclaredElement.Type, 
                            propertyName)
                        : this.factory.CreateBlock(ImplementationPatterns.PropertySetAccessor, propertyName));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The compute member name.
        /// </summary>
        /// <param name="memberNameBase">
        /// The member name base.
        /// </param>
        /// <returns>
        /// The System.String.
        /// </returns>
        private string ComputeMemberName(string memberNameBase)
        {
            string memberName = memberNameBase;
            int idx = 0;
            while (
                this.classDeclaration.MemberDeclarations.ToList()
                    .Exists(declaration => declaration.DeclaredName == memberName))
            {
                memberName = memberNameBase + idx;
                idx++;
            }

            return memberName;
        }

        #endregion
    }
}