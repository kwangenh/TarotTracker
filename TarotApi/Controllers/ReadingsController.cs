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

                // does not catch duplicate uqniue string - need to add logic to handle that somewhere else
                /* 
                 * if(NameExists)
                 * {
                 *  _loggingManager.LogError("Reading Type name already exists");
                 *  return BadRequest("Reading Type name already exists");
                 */

                if (_repoWrapper.ReadingType.GetReadingTypesByName(readingType.Name).Any())
                {
                    _loggingManager.LogError("That name already exists");
                    return BadRequest("That reading type name already exists");
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

        public IActionResult CreateReading([FromBody]ReadingForCreationDto reading)
        {
            try
            {
                if (reading == null)
                {
                    _loggingManager.LogError("Reading DTO is null");
                    return BadRequest("Reading DTO is null");
                }

                if (!ModelState.IsValid)
                {
                    _loggingManager.LogError("Invalid Reading DTO model");
                    return BadRequest("Invalid Reading DTO model");
                }

                // probably need to adjust ReadingForCreationDto so that it only takes a GUID for each card/card types
                var readingEntity = _mapper.Map<Reading>(reading);
                _repoWrapper.Reading.Create(readingEntity);
                _repoWrapper.Save();

                var createdReadingDto = _mapper.Map<ReadingForCreationDto>(readingEntity);

                return Ok(createdReadingDto);
            }
            
            catch(Exception ex)
            {
                _loggingManager.LogError($"Something went wrong in the CreateReading action : {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }


        
        /*
         *{
	        "ReadingType": 
		        {
			        "Id": 6063CFEF-EEE4-400E-DE69-08D7C2D5FEC2,
			        "Name": "Just a Test for all cards",
			        "CardCount": 78
		        },
	        "ReadingCards": [
		        {"CardId": "", "CardName": "", "Arcana": "", "Suit":"", "MinorNumber":"", "MajorNumber":""},
		        {"CardId": "", "CardName": "", "Arcana": "", "Suit":"", "MinorNumber":"", "MajorNumber":""},
		        {"CardId": "", "CardName": "", "Arcana": "", "Suit":"", "MinorNumber":"", "MajorNumber":""}
		    ]
	        }*/
    }
}

 