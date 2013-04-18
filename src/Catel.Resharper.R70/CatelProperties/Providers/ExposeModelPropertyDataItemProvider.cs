// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExposeModelPropertyDataItemProvider.cs" company="Catel development team">
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
    /// The generate model property data item provider.
    /// </summary>
    [GenerateProvider]
    public class ExposeModelPropertyDataItemProvider : IGenerateActionProvider
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The create workflow.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; JetBrains.ReSharper.Feature.Services.Generate.Actions.IGenerateActionWorkflow].
        /// </returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="dataContext"/> is <c>null</c>.</exception>
        public IEnumerable<IGenerateActionWorkflow> CreateWorkflow(IDataContext dataContext)
        {
            Argument.IsNotNull("dataContext", dataContext);

            ISolution solution = dataContext.GetData(DataConstants.SOLUTION);
            var iconManager = solution.GetComponent<PsiIconManager>();
            #if R70 || R71 || R80
            IconId icon = iconManager.GetImage(CLRDeclaredElementType.PROPERTY);
            #endif
            #if R61
            Image icon = iconManager.GetImage(CLRDeclaredElementType.PROPERTY);
            #endif

            yield return new ExposeModelPropertyDataWorkflow(icon);
        }
    }
}