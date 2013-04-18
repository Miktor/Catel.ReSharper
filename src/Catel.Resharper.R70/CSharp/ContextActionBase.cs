// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContextActionBase.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.ReSharper.CSharp
{
#if R70 || R71 || R80
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;

#elif R61
    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Feature.Services.CSharp.Bulbs;
    using JetBrains.Util;
#endif

    /// <summary>
    /// The action base.
    /// </summary>
    public abstract class ContextActionBase :
#if R70 || R71 || R80
        JetBrains.ReSharper.Intentions.Extensibility.ContextActionBase
#elif R61
        BulbItemImpl, IContextAction
#endif
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextActionBase"/> class. 
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="provider"/> is <c>null</c>.
        /// </exception>
        protected ContextActionBase(ICSharpContextActionDataProvider provider)
        {
            Argument.IsNotNull("provider", provider);

            Provider = provider;
        }

        /// <summary>
        /// Gets Provider.
        /// </summary>
        protected ICSharpContextActionDataProvider Provider { get; private set; }

#if R61
    
    /// <summary>
    /// The is available.
    /// </summary>
    /// <param name="cache">
    /// The cache.
    /// </param>
    /// <returns>
    /// The System.Boolean.
    /// </returns>
        public abstract bool IsAvailable(IUserDataHolder cache);
#endif
    }
}