// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArgumentContextActionBase.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.Arguments
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Catel.Logging;
    using Catel.ReSharper.CSharp;
    using Catel.ReSharper.Extensions;
    using Catel.ReSharper.Identifiers;

    using JetBrains.Application;
    using JetBrains.Application.Progress;
#if R80
    using JetBrains.DocumentModel;
#endif
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
    using JetBrains.ReSharper.Feature.Services.LiveTemplates.LiveTemplates;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;
    using JetBrains.Util;

    /// <summary>
    ///     The argument context action base.
    /// </summary>
    public abstract class ArgumentContextActionBase : ContextActionBase
    {
        #region Static Fields

        /// <summary>
        ///     The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Fields

        /// <summary>
        ///     The method declaration.
        /// </summary>
        private ICSharpFunctionDeclaration methodDeclaration;

        /// <summary>
        ///     The parameter declaration.
        /// </summary>
        private IRegularParameterDeclaration parameterDeclaration;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentContextActionBase"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        protected ArgumentContextActionBase(ICSharpContextActionDataProvider provider)
            : base(provider)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the availability of the command.
        /// </summary>
        /// <param name="cache">
        /// The cache.
        /// </param>
        /// <returns>
        /// <c>true</c> whether the command is available, otherwise <c>false</c>.
        /// </returns>
        public override sealed bool IsAvailable(IUserDataHolder cache)
        {
            using (ReadLockCookie.Create())
            {
                if (this.Provider.SelectedElement != null)
                {
#if R80
                    IDeclaredType catelArgumentType = TypeFactory.CreateTypeByCLRName(CatelCore.Argument, this.Provider.PsiModule, this.Provider.SelectedElement.GetResolveContext());
#else
                    IDeclaredType catelArgumentType = TypeFactory.CreateTypeByCLRName(CatelCore.Argument, this.Provider.PsiModule);
#endif
                    this.parameterDeclaration = null;
                    this.methodDeclaration = null;

                    if (catelArgumentType.GetTypeElement() != null)
                    {
                        if (this.Provider.SelectedElement != null && this.Provider.SelectedElement.Parent is IRegularParameterDeclaration)
                        {
                            this.parameterDeclaration = this.Provider.SelectedElement.Parent as IRegularParameterDeclaration;
                            if (this.parameterDeclaration.Parent != null && this.parameterDeclaration.Parent != null
                                && this.parameterDeclaration.Parent.Parent is ICSharpFunctionDeclaration)
                            {
                                this.methodDeclaration =
                                    this.parameterDeclaration.Parent.Parent as ICSharpFunctionDeclaration;
                            }
                        }
                    }
                    
                }
            }

            return this.parameterDeclaration != null && this.IsArgumentTypeTheExpected(this.parameterDeclaration.Type)
                   && this.methodDeclaration != null
                   && !this.IsArgumentChecked(this.methodDeclaration, this.parameterDeclaration);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the argument check statement.
        /// </summary>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The argument check statement
        /// </returns>
        /// <remarks>
        /// This method needs to be overridden
        /// </remarks>
        protected abstract ICSharpStatement CreateArgumentCheckStatement(
            IRegularParameterDeclaration parameterDeclaration);

        /// <summary>
        /// Gets argument check xml doc line.
        /// </summary>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The argument check xml doc line.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs.
        /// </exception>
        /// <remarks>
        /// This method needs to be overridden
        /// </remarks>
        protected abstract string CreateExceptionXmlDoc(IRegularParameterDeclaration parameterDeclaration);

        /// <summary>
        /// Executes QuickFix or ContextAction. Returns post-execute method.
        /// </summary>
        /// <param name="solution">
        /// The solution.
        /// </param>
        /// <param name="progress">
        /// The progress.
        /// </param>
        /// <returns>
        /// Action to execute after document and PSI transaction finish. Use to open TextControls, navigate caret, etc.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an error occurs 
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="solution"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="progress"/> is <c>null</c>.
        /// </exception>
        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            Argument.IsNotNull(() => solution);
            Argument.IsNotNull(() => progress);

            IDocCommentBlockNode exceptionCommentBlock = null;
            XmlNode xmlDoc = this.methodDeclaration.GetXMLDoc(false);
            if (xmlDoc == null || !this.IsArgumentCheckDocumented(xmlDoc, this.parameterDeclaration))
            {
                // TODO: Move out the initialization of the exception block down (CreateExceptionXmlDoc).
                exceptionCommentBlock =
                    this.Provider.ElementFactory.CreateDocCommentBlock(
                        this.CreateExceptionXmlDoc(this.parameterDeclaration));

                // TODO: Detect the right position to insert the document node.
                if (this.methodDeclaration.FirstChild is IDocCommentBlockNode)
                {
                    ITreeNode lastChild = this.methodDeclaration.FirstChild.LastChild;
                    if (lastChild != null)
                    {
                        exceptionCommentBlock = ModificationUtil.AddChildAfter(lastChild, exceptionCommentBlock);
                    }
                }
                else if (this.methodDeclaration.Parent != null)
                {
                    exceptionCommentBlock = ModificationUtil.AddChildBefore(this.methodDeclaration.Parent, this.methodDeclaration.FirstChild, exceptionCommentBlock);
                }
            }

            // TODO: Detect the right position to insert the code.
            ITreeNode methodBodyFirstChild = this.methodDeclaration.Body.FirstChild;
#if R80
            Dictionary<string, List<DocumentRange>> fields = null;
#else
            Dictionary<string, List<TextRange>> fields = null;
#endif
            if (methodBodyFirstChild != null)
            {
                ICSharpStatement checkStatement = ModificationUtil.AddChildAfter(methodBodyFirstChild, this.CreateArgumentCheckStatement(this.parameterDeclaration));
                fields = checkStatement.GetFields();
                if (exceptionCommentBlock != null)
                {
                    fields.Merge(exceptionCommentBlock.GetFields());
                }
            }
            
           
            HotspotInfo[] hotspotInfos = fields != null ? fields.AsHotspotInfos() : new HotspotInfo[] { };
            return hotspotInfos.Length == 0
                       ? (Action<ITextControl>)null
                       : textControl =>
                       {
                           HotspotSession hotspotSession =
                               Shell.Instance.GetComponent<LiveTemplatesManager>()
                                    .CreateHotspotSessionAtopExistingText(
                                        solution,
                                        TextRange.InvalidRange,
                                        textControl,
                                        LiveTemplatesManager.EscapeAction.LeaveTextAndCaret,
                                        hotspotInfos);
                           hotspotSession.Execute();
                       };
        }

        /// <summary>
        /// The is argument check documented.
        /// </summary>
        /// <param name="xmlDocOfTheMethod">
        /// The xml Doc Of The Method.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// <c>true</c> whether the <paramref name="xmlDocOfTheMethod"/> is <c>null</c>.
        /// </returns>
        /// <remarks>
        /// This method needs to be overridden
        /// </remarks>
        protected abstract bool IsArgumentCheckDocumented(XmlNode xmlDocOfTheMethod, IRegularParameterDeclaration parameterDeclaration);

        /// <summary>
        /// Gets is argument checked.
        /// </summary>
        /// <param name="methodDeclaration">
        /// The method declaration.
        /// </param>
        /// <param name="parameterDeclaration">
        /// The parameter declaration.
        /// </param>
        /// <returns>
        /// The get is argument checked.
        /// </returns>
        /// <remarks>
        /// This method needs to be overridden
        /// </remarks>
        protected abstract bool IsArgumentChecked(ICSharpFunctionDeclaration methodDeclaration, IRegularParameterDeclaration parameterDeclaration);

        /// <summary>
        /// Gets a value indicating whether IsArgumentTypeCompatible.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// <c>true</c> if the argument type is of the expected type, otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method needs to be overridden
        /// </remarks>
        protected abstract bool IsArgumentTypeTheExpected(IType type);

        #endregion
    }
}