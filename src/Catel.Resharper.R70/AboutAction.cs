// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutAction.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper
{
    using System.Windows.Forms;

    using JetBrains.ActionManagement;
    using JetBrains.Application.DataContext;

    /// <summary>
    /// The about action
    /// </summary>
    [ActionHandler("Catel.ReSharper.About")]
    public class AboutAction : IActionHandler
    {
        #region IActionHandler Members

        /// <summary>
        /// Updates the status of the action.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="presentation">
        /// The presentation.
        /// </param>
        /// <param name="nextUpdate">
        /// The next update.
        /// </param>
        /// <returns>
        /// return <c>true</c> or <c>false</c> to enable/disable this action.
        /// </returns>
        public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
        {
            return true;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="nextExecute">
        /// The next execute.
        /// </param>
        public void Execute(IDataContext context, DelegateExecute nextExecute)
        {
            MessageBox.Show("Catel.ReSharper\nCatel development team\n\nReSharper plugin for Catel", "About Catel.ReSharper", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}