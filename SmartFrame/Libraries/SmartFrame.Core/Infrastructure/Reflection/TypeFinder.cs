using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SmartFrame.Core.Infrastructure.Reflection
{
    public class TypeFinder : ITypeFinder
    {



        public IAssemblyFinder AssemblyFinder { get; set; }

        public TypeFinder()
        {
            AssemblyFinder = CurrentDomainAssemblyFinder.Instance;
        }

        public Type[] Find(Func<Type, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Type[] FindAll()
        {
            throw new NotImplementedException();
        }

        private List<Assembly> GetAllTypes()
        {
            var allTypes=new List<Assembly>();

            foreach (var source in AssemblyFinder.GetAllAssemblies().Distinct())
            {
                Type[] typesInThisAssembly;

                try
                {
                    typesInThisAssembly = source.GetTypes();
                }
                catch (ReflectionTypeLoadException e)
                {
                    typesInThisAssembly = e.Types;
                }

                if (typesInThisAssembly != null && typesInThisAssembly.Any())
                {
                    //allTypes.AddRange(typesInThisAssembly.Where(type => type != null));
                }
            }

            return allTypes;

        }
    }
}
