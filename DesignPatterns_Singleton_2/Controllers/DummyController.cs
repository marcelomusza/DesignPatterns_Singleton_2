using DesignPatterns_Singleton_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns_Singleton_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        [HttpGet]
        [Route("/List")]
        public IActionResult ListUserAccounts()
        {
            var usersListInstance = UserAccountList.GetInstance();

            var list = usersListInstance.ListUsers();
            return Ok(list);
        }

        [HttpPost]
        [Route("/Add")]
        public IActionResult AddUserAccount(string name)
        {
            var user = new UserAccount { Name = name };

            var usersListInstance = UserAccountList.GetInstance();

            usersListInstance.AddUsers(user);

            return Ok("User Added to instance");
        }

        [HttpDelete]
        [Route("/Remove")]
        public IActionResult RemoveUserAccount(string name)
        {
            var usersListInstance = UserAccountList.GetInstance();

            var list = usersListInstance.ListUsers();
            var user = list.SingleOrDefault(x => x.Name == name);

            if(user != null)
            {
                usersListInstance.RemoveUsers(user);
                return Ok("User Removed from Instance");
            }
            return BadRequest("No User found under that name");
                
        }


    }
}
