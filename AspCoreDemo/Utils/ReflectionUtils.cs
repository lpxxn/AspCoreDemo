using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspCoreDemo.Controllers;

namespace AspCoreDemo.Utils
{
    public class ReflectionUtils
    {
        public void GetAllControlModules()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(BaseController));
            foreach (var moudleType in types)
            {
                
            }
        }
    }
}
