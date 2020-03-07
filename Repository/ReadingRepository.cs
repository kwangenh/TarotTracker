using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ReadingRepository : RepositoryBase<Reading>, IReadingRepository
    {
        public ReadingRepository(RepositoryContext repoContext) : base(repoContext)
        {
            
        }
    }
}
