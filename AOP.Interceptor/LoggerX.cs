using System;
using System.IO;
using System.Linq;
using Castle.DynamicProxy;

namespace AOP.Interceptor
{
    public class LoggerX : IInterceptor
    {
        TextWriter writer;
        public LoggerX(TextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                Console.WriteLine("On Start");
                invocation.Proceed(); //Intercepted method is executed here.
                
                Console.WriteLine("On Success");              
            }
            catch (Exception e)
            {
                Console.WriteLine("On Exception");
                throw;
            }
            finally
            {
                Console.WriteLine("On Exit");
            }
        }
    }
}