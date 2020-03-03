using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace TarotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private ILoggingManager _loggingManager;
        public CardsController(IRepositoryWrapper repoWrapper, ILoggingManager loggingManager)
        {
            _repoWrapper = repoWrapper;
            _loggingManager = loggingManager;
        }

        /*[HttpGet]
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
        */

        [HttpGet]
        public void Create()
        {
            var newCard = new Card();
            newCard.CardName = "Ace of Wands";
            newCard.MinorNumber = MinorNumber.Ace;
            newCard.Suit = Suit.Wands;

            try
            {
                _repoWrapper.Card.Create(newCard);
                _repoWrapper.Save();
            }
            catch (Exception ex)
            {
                _loggingManager.LogWarning(ex.ToString());
            }
        }
    }
}