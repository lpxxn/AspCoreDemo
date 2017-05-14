using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspCoreDemo.ClassEx;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // DELETE api/values/5
        [HttpGet("Error")]
        public void Error()
        {
            throw new InvalidExpressionException("Error");
        }


        #region TestSession

        private const string SessionKeyDate = "testSessionKey";
        [HttpGet("TestSessionSetDate")]
        public IActionResult SetDate()
        {
            // Requires you add the Set extension method mentioned in the article.
            HttpContext.Session.Set<DateTime>(SessionKeyDate, DateTime.Now);
            return RedirectToAction("GetDate");
        }

        [HttpGet("TestSessionGetData")]
        public IActionResult GetDate()
        {
            // Requires you add the Get extension method mentioned in the article.
            var date = HttpContext.Session.Get<DateTime>(SessionKeyDate);
            var sessionTime = date.TimeOfDay.ToString();
            var currentTime = DateTime.Now.TimeOfDay.ToString();

            return Content($"Current time: {currentTime} - "
                         + $"session time: {sessionTime}");
        }

        #endregion
    }
}
