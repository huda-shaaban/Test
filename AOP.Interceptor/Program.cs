using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Interceptor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var builder = new ContainerBuilder();

                builder.Register(i => new Logger(Console.Out));
                builder.Register(i => new LoggerX(Console.Out));

                /*Enable Interception on Types*/
                builder.RegisterType<Calculator>()
                       .As<ICalculator>()
                       .EnableInterfaceInterceptors()
                       .InterceptedBy(typeof(LoggerX))
                       .InterceptedBy(typeof(Logger));
                       
                var container = builder.Build();

                var calc = container.Resolve<ICalculator>();

                calc.Add(5, 2);

                Console.WriteLine();

                calc.Divide(3, 0);
            }
            catch (Exception ex)
            {
            }
            

            Console.ReadLine();
        }
    }
}
