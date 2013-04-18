// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleInitializer.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.ReSharper
{
    using Catel.Logging;

    /// <summary>
    /// Class that gets called as soon as the module is loaded.
    /// </summary>
    /// <remarks>
    /// This is made possible thanks to Fody.
    /// </remarks>
    public static class ModuleInitializer
    {
        #region Constants and Fields

        /// <summary>
        /// The log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Initializes the module
        /// </summary>
        public static void Initialize()
        {
#if DEBUG
            LogManager.RegisterDebugListener();
#endif
            LogManager.AddListener(new LoggerListener());
            
            Log.Debug("Loading Catel.ReSharper");
        }

        #endregion
    }
}