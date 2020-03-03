﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        ICardRepository Card { get; }
        void Save();
    }
}