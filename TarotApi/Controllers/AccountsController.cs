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
    public class AccountsController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public AccountsController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public void Create(Account newAccount)
        {
            _repoWrapper.Account.Create(newAccount);
        }

        [HttpGet]
        public void Create()
        {

        }
    }
}