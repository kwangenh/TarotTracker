﻿using Contracts;
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
