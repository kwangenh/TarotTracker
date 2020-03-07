using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ReadingTypeForCreationDto
    {
        //[Index(IsUnique = true)]
        public string Name { get; set; }
        public int CardCount { get; set; }
    }
}
