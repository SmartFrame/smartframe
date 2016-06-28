using System.Collections.Generic;
using System.Reflection;

namespace SmartFrame.Core.Infrastructure.Reflection
{
  public  interface IAssemblyFinder
    {
        /// <summary>
        /// This method should return all assemblies used by application.
        /// </summary>
        /// <returns>List of assemblies</returns>
        List<Assembly> GetAllAssemblies();
    }
}
