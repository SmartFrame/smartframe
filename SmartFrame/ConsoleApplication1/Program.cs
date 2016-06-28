using System;
using System.Reflection;
using ConsoleApplication1.Test;
using SmartFrame.Core;
using SmartFrame.Core.Infrastructure.AutoMapper;
using SmartFrame.Core.Infrastructure.Dependency;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartFrameBootstrapper bootstrapper = new SmartFrameBootstrapper();
            bootstrapper.IocManager.Register<Interface1, Class1>();
            
            var service = bootstrapper.IocManager.Resolve<Interface1>();
            Console.WriteLine(service.SayHello());



            bootstrapper.IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());
            bootstrapper.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            var service1 = bootstrapper.IocManager.Resolve<IPerson>();
            Console.WriteLine(service1.PersonName());

            bootstrapper.IocManager.Register<IAutoMapperObjectMapper, AutoMapperObjectMapper>();
            var service2 = bootstrapper.IocManager.IocContainer.Resolve<IAutoMapperObjectMapper>();
            Console.WriteLine(service2.MapperTest());
            Console.ReadLine();

        }
    }
}
