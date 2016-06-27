using System;
using SmartFrame.Core.Infrastructure.Dependency;
using SmartFrame.Core.Infrastructure.Dependency.Installers;

namespace SmartFrame.Core
{
    /// <summary>
    /// Prepares dependency injection and registers core components needed for startup.
    /// It must be instantiated and initialized (see <see cref="Initialize"/>) first in an application.
    /// </summary>
    public class SmartFrameBootstrapper : IDisposable
    {
        /// <summary>
        /// Gets IIocManager object used by this class.
        /// </summary>
        public IIocManager IocManager { get; private set; }

        /// <summary>
        /// Is this object disposed before?
        /// </summary>
        protected bool IsDisposed;

        //todo private IAbpModuleManager _moduleManager;

        
        public SmartFrameBootstrapper()
            : this(Infrastructure.Dependency.IocManager.Instance)
        {

        }

        /// <summary>
        /// Creates a new <see cref="SmartFrameBootstrapper"/> instance.
        /// </summary>
        /// <param name="iocManager">IIocManager that is used to bootstrap the ABP system</param>
        public SmartFrameBootstrapper(IIocManager iocManager)
        {
            IocManager = iocManager;
        }

        /// <summary>
        /// Initializes the ABP system.
        /// </summary>
        public virtual void Initialize()
        {
            IocManager.IocContainer.Install(new SmartFrameCoreInstaller());

            //todo IocManager.Resolve<AbpStartupConfiguration>().Initialize();

            //_moduleManager = IocManager.Resolve<IAbpModuleManager>();
            //_moduleManager.InitializeModules();
        }

        /// <summary>
        /// Disposes the  system.
        /// </summary>
        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            //todo 
            //if (_moduleManager != null)
            //{
            //    _moduleManager.ShutdownModules();
            //}
        }
    }
}
