using System;
using System.IO;
using System.Linq;
using Castle.DynamicProxy;

namespace AOP.Interceptor
{
    public class Logger : IInterceptor
    {
        TextWriter writer;
        public Logger(TextWriter writer)
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
                Console.WriteLine($"Start: {invocation.Method.DeclaringType}.{invocation.Method.Name}");
                Console.WriteLine($"Args: {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()))}");
                
                invocation.Proceed(); //Intercepted method is executed here.
                
                Console.WriteLine($"Success: result was {invocation.ReturnValue}");              
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                throw;
            }
            finally
            {
                Console.WriteLine($"Exit: {invocation.Method.DeclaringType}.{invocation.Method.Name}");
            }
        }
    }
}