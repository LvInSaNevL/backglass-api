using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USER_API.Controllers
{
    [ApiController]
    [Route("user/[controller]")]
    public class NewUserController : ControllerBase
    {
        private readonly ILogger<NewUserController> _logger;

        public NewUserController(ILogger<NewUserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Tuple<UserInfo, UserIFPAStats> Get()
        {
            // Get current IFPA info
            return Tuple.Create(
                // Our data
                new UserInfo
                {
                    FirstName = "foo",
                    LastName = "bar",
                    Email = "foo@bar.com",
                    Phone = "2604146076",
                    Password = "superStronkpassword1",
                    Home = "Wizards World"
                },
                IFPA.GetUser("Lukas", "Bakle").Result
            ); 
        }
    }
}
