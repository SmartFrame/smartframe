using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SmartFrame.Core.Infrastructure.Reflection
{
    public class CurrentDomainAssemblyFinder : IAssemblyFinder
    {

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static CurrentDomainAssemblyFinder Instance { get { return SingletonInstance; } }
        private static readonly CurrentDomainAssemblyFinder SingletonInstance = new CurrentDomainAssemblyFinder();

        public List<Assembly> GetAllAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().ToList();
        }
    }
}
