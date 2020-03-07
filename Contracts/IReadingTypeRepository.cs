using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IReadingTypeRepository : IRepositoryBase<ReadingType>
    {
        ReadingType GetReadingTypeByName(string name);
        ReadingType GetReadingTypeById(Guid id);
        IEnumerable<ReadingType> GetAllReadingTypes();
    }
}
