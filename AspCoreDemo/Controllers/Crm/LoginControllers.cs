using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AspCoreDemo.AttributeEx;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreDemo.Controllers.Crm
{
    [AllRight]
    public class LoginControllers : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody, Required] LoginInfo info)
        {
            return await Task.FromResult(new ContentResult());
        }
    }

    public class LoginInfo
    {
        [Required]
        public string Name;
        [Required]
        public string Pwd;
        
    }
}
