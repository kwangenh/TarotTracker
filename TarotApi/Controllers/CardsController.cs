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
using Repository;

namespace TarotApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private ILoggingManager _loggingManager;
        private IMapper _mapper;

        public CardsController(IRepositoryWrapper repoWrapper, ILoggingManager loggingManager, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _loggingManager = loggingManager;
            _mapper = mapper;
        }

        [HttpPost]
        public void Create(Card newCard)
        {
            try
            {
                _repoWrapper.Card.Create(newCard);
                _repoWrapper.Save();
            }
            
            catch(Exception ex)
            {
                _loggingManager.LogError(ex.ToString());
            }
        }           

        [HttpGet]
        public void Create()
        {
            TestDataBuilder builder = new TestDataBuilder(_repoWrapper);

            try
            {
                builder.BuildCardsAndReadingTypes();
            }
            catch (Exception ex)
            {
                _loggingManager.LogWarning(ex.ToString());
            }
        }

       // [Route("api/Cards/GetAllCards")]
        [HttpGet]
        public IActionResult GetAllCards()
        {
            try
            {
                var cards = _repoWrapper.Card.GetAllCards();                
                _loggingManager.LogInfo($"Returned all cards from database");

                var cardDtos = _mapper.Map<IEnumerable<Card_Read_Dto>>(cards);
                return Ok(cardDtos);
            }
            catch(Exception ex)
            {
                _loggingManager.LogError($"Something went wrong in the GetAllCards action : {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        
        [HttpGet("{id}")]
        // .../api/cards/getcardbyid/{id}
        public IActionResult GetCardById(Guid id)
        {
            try
            {
                var card = _repoWrapper.Card.GetCardById(id);
                if(card == null)
                {
                    _loggingManager.LogError($"Owner with id: {id} has not been found in the database.");
                    return NotFound();
                }
                else
                {
                    _loggingManager.LogInfo($"Returned card with id {id}");
                    return Ok(card);
                }
            }
            catch(Exception ex)
            {
                _loggingManager.LogError($"Something went wrong in the GetCardById action : {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}