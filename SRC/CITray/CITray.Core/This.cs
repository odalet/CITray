using System;
using System.ComponentModel.Design;

namespace CITray.Core
{
    /// <summary>
    /// This "This" class represents a central point containing services and
    /// global objects/methods needed throughout the entire application.
    /// </summary>
    internal class This
    {
        private static readonly object locker = new object();
        private static readonly This instance = new This();
        private static bool initialized = false;

        private ServiceContainer serviceContainer = null;

        /// <summary>
        /// Bootstraps the application.
        /// </summary>
        public static void Bootstrap()
        {
            if (initialized) throw new ApplicationException(string.Format(
                "Already initialized: this method ({0}.Bootstrap) should be called once and only once.", 
                typeof(This)));
            
            lock(locker)
            {
                instance.Initialize();
                initialized = true;
            }            
        }

        /// <summary>
        /// Gets the global services for the application.
        /// </summary>
        /// <value>The services.</value>
        public static IServiceContainer Services
        {
            get { return instance.serviceContainer; }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            serviceContainer = new ServiceContainer();

            // add global services

        }
    }
}
