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

        [HttpGet]
        public IActionResult GetAllReadingTypes()
        {
            try
            {
                var readingTypes = _repoWrapper.ReadingType.GetAllReadingTypes();
                if(readingTypes == null)
                {
                    _loggingManager.LogError("There was an error retrieving ReadingType.FindAll() : null value");
                    return BadRequest("There was an error retrieving Reading Types");
                }

                var readingTypeDtos = _mapper.Map<IEnumerable<ReadingType_Read_Dto>>(readingTypes);
                return Ok(readingTypeDtos);
            }
            catch(Exception ex)
            {
                _loggingManager.LogError($"There was an error in the GetAllReadingTypes action : {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult CreateReadingType([FromBody]ReadingType_Create_Dto readingType)
        {
            // should these try calls be factored into Business Level Layer ?
            try
            {
                if(readingType == null)
                {
                    _loggingManager.LogError("Reading Type object is null");
                    return BadRequest("Reading Type Object is Null");
                }

                // if name already exists, then throw error for duplicate name
                if(_repoWrapper.ReadingType.GetReadingTypesByName(readingType.Name).Any())
                {
                    _loggingManager.LogError("That name already exists");
                    return BadRequest("That reading type name already exists");
                }

                if(!ModelState.IsValid)
                {
                    _loggingManager.LogError("Reading Type object is invalid");
                    return BadRequest("Reading Type object is not valid");
                }

                var readingEntity = _mapper.Map<ReadingType>(readingType);

                _repoWrapper.ReadingType.Create(readingEntity);
                _repoWrapper.Save();

                var createdReadingType = _mapper.Map<ReadingType_Create_Dto>(readingEntity);

                return Ok(createdReadingType);
            }
            catch(Exception ex)
            {
                _loggingManager.LogError($"Something went wrong in the CreateReadingType action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        public IActionResult CreateReading([FromBody]Reading_Create_Dto reading)
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

                if(reading.ReadingType.CardCount > reading.ReadingCards.Count)
                {
                    _loggingManager.LogError($"More cards than this type of reading requires: {reading.ReadingType.CardCount} cards required but {reading.ReadingCards.Count} added.");
                    return BadRequest($"More cards than this type of reading requires: {reading.ReadingType.CardCount} cards required but {reading.ReadingCards.Count} added.");
                }

                if (reading.ReadingType.CardCount < reading.ReadingCards.Count)
                {
                    _loggingManager.LogError($"Less cards than this type of reading requires: {reading.ReadingType.CardCount} cards required but {reading.ReadingCards.Count} added.");
                    return BadRequest($"Less cards than this type of reading requires: {reading.ReadingType.CardCount} cards required but {reading.ReadingCards.Count} added.");
                }

                // pretty sure for this to work, the ReadingCard.ReadCard object [Card] (should be Card_Read_Dto or something other than actual Entity obj) will need to be populated
                foreach(var readingCard in reading.ReadingCards)
                {
                    if (_repoWrapper.Card.GetCardById(readingCard.CardId) == null)
                    {
                        _loggingManager.LogError("Invalid card ID provided for reading card in CreateReading action.");
                        return BadRequest("Invalid Card ID provided for Reading Card.");
                    }
                }

                if(_repoWrapper.ReadingType.GetReadingTypeById(reading.ReadingType.Id) == null)
                {
                    _loggingManager.LogError("Invalid ReadingType object provided in CreateReading action.");
                    return BadRequest("Invalid Reading Type provided.");
                }

                // create Reading.ReadingCards (?) unsure if those should be part of the model instead of having to be created here
                // if going to be part of model, will need first method to call GetAllCards then another to build the ReadingCard_Create_Dto objs to send to client

                // probably need to adjust ReadingForCreationDto so that it only takes a GUID for each card/card types
                var readingEntity = _mapper.Map<Reading>(reading);
                _repoWrapper.Reading.Create(readingEntity);
                _repoWrapper.Save();

                var createdReadingDto = _mapper.Map<Reading_Create_Dto>(readingEntity);

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

        // pass cards to front end for "create reading" view
        // pass reading type to front end for "create reading" view
        // select card objects as part of "create reading" action
        // post ReadingToCreateDto object containing List of Cards and the Reading Type
        // validate the Reading object is not null
        // validate Reading ModelState is legit
        // validate number of ReadingCards matches number of cards in the ReadingType.CardCount value
        // validate Cards are legit by Guid
        // validate the Reading Type is legit by Guid
        // map the ReadingToCreateDto to the Reading Entity
        // create the Reading object using repo
        // map the ReadingCardDtos to ReadingCard Entities
        // create the ReadingCards

    }
}

 