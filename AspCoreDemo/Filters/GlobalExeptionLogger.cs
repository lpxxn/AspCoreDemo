using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NLog;

namespace AspCoreDemo.Filters
{
    public class GlobalExeptionLogger : IExceptionFilter
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public GlobalExeptionLogger()
        {
            
        }
        public void OnException(ExceptionContext context)
        {
            Logger.Error(context.Exception.Message);
        }
    }
}
