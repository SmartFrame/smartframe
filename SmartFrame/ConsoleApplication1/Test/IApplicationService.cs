using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFrame.Core.Infrastructure.Dependency;

namespace ConsoleApplication1.Test
{
    public interface IApplicationService : ITransientDependency
    {
    }
}
