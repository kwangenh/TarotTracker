using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TarotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public ReadingsController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            /*
             * _logger.LogInfo("Here is info message from the controller.");
            _logger.LogDebug("Here is debug message from the controller.");
            _logger.LogWarning("Here is warn message from the controller.");
            _logger.LogError("Here is error message from the controller.");
            */

            // test to create account
            var newAccount = new Account();
            newAccount.Name = "BigBoy";
            newAccount.Email = "myemail@test.com";

            _repoWrapper.Account.Create(newAccount);
            _repoWrapper.Save();

            var thisAccount = _repoWrapper.Account.FindByCondition(x => x.AccountId.Equals(1));
            var accounts = _repoWrapper.Account.FindAll();

            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public void Post(Reading thisAccount)
        {

        }
    }
}