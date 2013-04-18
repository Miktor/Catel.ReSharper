// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerListener.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.ReSharper
{
    using Catel.Logging;

    using JetBrains.Util;
#if R80
    using JetBrains.Util.Logging;
#endif

    /// <summary>
    /// The logger listener.
    /// </summary>
    public class LoggerListener : LogListenerBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerListener"/> class.
        /// </summary>
        public LoggerListener()
        {
#if DEBUG        
            Logger.AppendListener(new DebugOutputLogEventListener("CatelR#"));
#endif
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when a <see cref="F:Catel.Logging.LogEvent.Debug"/> message is written to the log.
        /// </summary>
        /// <param name="log">
        /// The log.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void Debug(ILog log, string message)
        {
            Logger.LogMessage(message);
        }

        /// <summary>
        /// Called when a <see cref="F:Catel.Logging.LogEvent.Error"/> message is written to the log.
        /// </summary>
        /// <param name="log">
        /// The log.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void Error(ILog log, string message)
        {
            Logger.LogError(message);
        }

        /// <summary>
        /// Called when a <see cref="F:Catel.Logging.LogEvent.Info"/> message is written to the log.
        /// </summary>
        /// <param name="log">
        /// The log.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void Info(ILog log, string message)
        {
            Logger.LogMessage(message);
        }

        /// <summary>
        /// Called when a <see cref="F:Catel.Logging.LogEvent.Warning"/> message is written to the log.
        /// </summary>
        /// <param name="log">
        /// The log.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void Warning(ILog log, string message)
        {
            Logger.LogMessage(message);
        }

        #endregion
    }
}