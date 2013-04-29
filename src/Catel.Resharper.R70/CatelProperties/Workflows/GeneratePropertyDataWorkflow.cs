// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeneratePropertyDataWorkflow.cs" company="Catel development team">
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
    /// The generate property data workflow.
    /// </summary>
    public class GeneratePropertyDataWorkflow : StandardGenerateActionWorkflow
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The description.
        /// </summary>
        private const string Description = "Generate Catel properties from available auto properties";

        /// <summary>
        /// The window title.
        /// </summary>
        private const string WindowTitle = "Generate Catel properties";

        /// <summary>
        /// The menu text.
        /// </summary>
        private const string MenuText = "Catel properties";

        #region Constructors and Destructors

#if R70 || R71 || R80

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratePropertyDataWorkflow"/> class. 
        /// </summary>
        /// <param name="icon">
        /// The icon.
        /// </param>
        public GeneratePropertyDataWorkflow(IconId icon)
            : base(WellKnownGenerationActionKinds.GenerateCatelDataProperties, icon, MenuText, GenerateActionGroup.CLR_LANGUAGE, WindowTitle, Description, GeneratePropertyDataAction.Id)
#elif R61

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratePropertyDataWorkflow"/> class. 
        /// </summary>
        /// <param name="icon">
        /// The icon.
        /// </param>
        public GeneratePropertyDataWorkflow(Image icon)
            : base(WellKnownGenerationActionKinds.GenerateCatelDataProperties, icon, MenuText, GenerateActionGroup.CLR_LANGUAGE, WindowTitle, Description, GeneratePropertyDataAction.Id)
#endif
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets Order.
        /// </summary>
        public override double Order
        {
            get { return 100; }
        }
        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The is available.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        /// <returns>
        /// <c>true</c> if is avalable, otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="dataContext"/> is <c>null</c>.
        /// </exception>
        public override bool IsAvailable(IDataContext dataContext)
        {
            Argument.IsNotNull(() => dataContext);

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

        #endregion
    }
}