// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeneratePropertyDataItemProvider.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.Providers
{
    using System.Collections.Generic;

    using Catel.Logging;
    using Catel.ReSharper.CatelProperties.Workflows;

    using JetBrains.Application.DataContext;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.Generate.Actions;
    using JetBrains.ReSharper.Psi;
#if R70 || R71 || R80
    using JetBrains.UI.Icons;
#elif R61
    using System.Drawing;
    using JetBrains.ReSharper.Psi.DeclaredElements;
#endif

    using DataConstants = JetBrains.ProjectModel.DataContext.DataConstants;

    /// <summary>
    /// The generate property data item provider.
    /// </summary>
    [GenerateProvider]
    public class GeneratePropertyDataItemProvider : IGenerateActionProvider
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        #region Public Methods and Operators

        /// <summary>
        /// The create workflow.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="dataContext"/> is <c>null</c>.</exception>
        public IEnumerable<IGenerateActionWorkflow> CreateWorkflow(IDataContext dataContext)
        {
            Argument.IsNotNull(() => dataContext);

            ISolution solution = dataContext.GetData(DataConstants.SOLUTION);
            var iconManager = solution.GetComponent<PsiIconManager>();
#if R70 || R71 || R80
            IconId icon = iconManager.GetImage(CLRDeclaredElementType.PROPERTY);
#elif R61
            Image icon = iconManager.GetImage(CLRDeclaredElementType.PROPERTY);
#endif

            yield return new GeneratePropertyDataWorkflow(icon);
        }

        #endregion
    }
}