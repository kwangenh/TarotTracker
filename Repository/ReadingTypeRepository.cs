using Contracts;
using Entities;
using Entities.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ReadingTypeRepository : RepositoryBase<ReadingType>, IReadingTypeRepository
    {
        public ReadingTypeRepository(RepositoryContext repoContext) : base(repoContext)
        {

        }

        public ReadingType GetReadingTypeByName(string name)
        {
            return FindByCondition(readingType => readingType.Name.Equals(name)).FirstOrDefault();
        }

        public ReadingType GetReadingTypeById(Guid id)
        {
            return FindByCondition(readingType => readingType.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<ReadingType> GetAllReadingTypes()
        {
            return FindAll();
        }   
    }
}
