using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(RepositoryContext repoContext) : base(repoContext)
        {

        }

        public IEnumerable<Card> GetAllCards()
        {
            return FindAll().OrderBy(card => card.CardName).ToList();
        }

        public Card GetCardById(Guid id)
        {
            return FindByCondition(card => card.CardId.Equals(id)).FirstOrDefault();
        }
    }
}
