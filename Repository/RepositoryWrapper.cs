using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    // by defining a single repo wrapper, can make CRUD operations on multiple entities in a single method 
    // and then call repo.Save() to commit the changes to the DB
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IAccountRepository _account;
        private ICardRepository _card;
        public IReadingTypeRepository _readingType;
        public IReadingRepository _reading;

        public IAccountRepository Account
        { get
            {
                if(_account == null)
                {
                    _account = new AccountRepository(_repositoryContext);
                }
                return _account;
            }

        }

        public ICardRepository Card
        {
            get
            {
                if(_card == null)
                {
                    _card = new CardRepository(_repositoryContext);
                }
                return _card;
            }
        }

        public IReadingTypeRepository ReadingType
        {
            get
            {
                if(_readingType == null)
                {
                    _readingType = new ReadingTypeRepository(_repositoryContext);
                }
                return _readingType;
            }
        }

        public IReadingRepository Reading
        {
            get
            {
                if(_reading == null)
                {
                    _reading = new ReadingRepository(_repositoryContext);
                }
                return _reading;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
