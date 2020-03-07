using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TarotApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private ILoggingManager _loggingManager;
        private IMapper _mapper;

        public ReadingsController(IRepositoryWrapper repoWrapper, ILoggingManager loggingManager, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _loggingManager = loggingManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
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
        public IActionResult CreateReadingType([FromBody]ReadingTypeForCreationDto readingType)
        {
            try
            {
                if(readingType == null)
                {
                    _loggingManager.LogError("Reading Type object is null");
                    return BadRequest("Reading Type Object is Null");
                }
                if (!ModelState.IsValid)
                {
                    _loggingManager.LogError("Reading Type object is invalid");
                    return BadRequest("Reading Type object is not valid");
                }

                var readingEntity = _mapper.Map<ReadingType>(readingType);

                _repoWrapper.ReadingType.Create(readingEntity);
                _repoWrapper.Save();

                var createdReadingType = _mapper.Map<ReadingTypeForCreationDto>(readingEntity);

                return Ok(createdReadingType);
            }
            catch(Exception ex)
            {
                _loggingManager.LogError($"Something went wrong in the CreateReadingType action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}