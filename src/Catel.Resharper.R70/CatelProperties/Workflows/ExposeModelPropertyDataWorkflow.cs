// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExposeModelPropertyDataWorkflow.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CatelProperties.Workflows
{
    using Catel.Logging;
    using Catel.ReSharper.CatelProperties.Actions;

    using JetBrains.Application.DataContext;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.Generate;
    using JetBrains.ReSharper.Feature.Services.Generate.Actions;
    using JetBrains.ReSharper.Psi;
#if R70 || R71 || R80
    using JetBrains.UI.Icons;
#elif R61
    using System.Drawing;
#endif

    using DataConstants = JetBrains.ProjectModel.DataContext.DataConstants;

    /// <summary>
    /// The generate model property data workflow.
    /// </summary>
    public class ExposeModelPropertyDataWorkflow : StandardGenerateActionWorkflow
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The description.
        /// </summary>
        private const string Description = "Expose properties from available models";

        /// <summary>
        /// The window title.
        /// </summary>
        private const string WindowTitle = "Expose model properties";

        /// <summary>
        /// The menu text.
        /// </summary>
        private const string MenuText = "Expose model properties";

#if R70 || R71 || R80

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposeModelPropertyDataWorkflow"/> class.
        /// </summary>
        /// <param name="icon">
        /// The icon.
        /// </param>
        public ExposeModelPropertyDataWorkflow(IconId icon)
            : base(WellKnownGenerationActionKinds.ExposeModelPropertiesAsCatelDataProperties, icon, MenuText, GenerateActionGroup.CLR_LANGUAGE, WindowTitle, Description, GeneratePropertyDataAction.Id)
#elif R61

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposeModelPropertyDataWorkflow"/> class.
        /// </summary>
        /// <param name="icon">
        /// The icon.
        /// </param>
        public ExposeModelPropertyDataWorkflow(Image icon)
            : base(WellKnownGenerationActionKinds.ExposeModelPropertiesAsCatelDataProperties, icon, MenuText, GenerateActionGroup.CLR_LANGUAGE, WindowTitle, Description, GeneratePropertyDataAction.Id)
#endif
        {
        }


        /// <summary>
        /// Gets the order.
        /// </summary>
        public override double Order
        {
            get { return 101; }
        }

        /// <summary>
        /// The is available.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        /// <returns>
        /// <c>true</c> if is avalable, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="dataContext"/> is <c>null</c>.</exception>
        public override bool IsAvailable(IDataContext dataContext)
        {
            Argument.IsNotNull("dataContext", dataContext);
            IGeneratorContextFactory generatorContextFactory = null;

            ISolution solution = dataContext.GetData(DataConstants.SOLUTION);
            if (solution != null)
            {
                GeneratorManager generatorManager = GeneratorManager.GetInstance(solution);
                if (generatorManager != null)
                {
                    PsiLanguageType languageType = generatorManager.GetPsiLanguageFromContext(dataContext);
                    if (languageType != null)
                    {
                        generatorContextFactory = LanguageManager.Instance.TryGetService<IGeneratorContextFactory>(languageType);
                    }
                }
            }

            return generatorContextFactory != null;
        }
    }
}