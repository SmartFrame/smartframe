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
            bootstrapper.Initialize();
            bootstrapper.IocManager.Register<Interface1, Class1>();
            
            var service = bootstrapper.IocManager.Resolve<Interface1>();
            Console.WriteLine(service.SayHello());



            bootstrapper.IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());
            bootstrapper.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            var service1 = bootstrapper.IocManager.Resolve<IPerson>();
            Console.WriteLine(service1.PersonName());

            
            var service2 = bootstrapper.IocManager.IocContainer.Resolve<IAutoMapperObjectMapper>();
            Console.WriteLine(service2.Test());


            AutoMapperHelper.CreateMap(typeof(MyClass1));
            AutoMapperHelper.CreateMap(typeof(MyClass2));


            MyClass1 obj1 = null;
            var obj2 = obj1.MapTo<MyClass2>();
            


            Console.ReadLine();

        }
    }


    [AutoMap(typeof(MyClass2), typeof(MyClass3))]
    public class MyClass1
    {
        public string TestProp { get; set; }
    }

    [AutoMapTo(typeof(MyClass3))]
    public class MyClass2
    {
        public string TestProp { get; set; }
    }

    public class MyClass3
    {
        public string TestProp { get; set; }
    }
}
