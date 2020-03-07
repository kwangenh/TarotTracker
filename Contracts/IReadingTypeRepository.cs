using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IReadingTypeRepository : IRepositoryBase<ReadingType>
    {
        IEnumerable<ReadingType> GetReadingTypesByName(string name);
        ReadingType GetReadingTypeById(Guid id);
        IEnumerable<ReadingType> GetAllReadingTypes();
    }
}
