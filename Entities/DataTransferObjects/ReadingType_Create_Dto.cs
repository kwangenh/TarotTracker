using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ReadingType_Create_Dto
    {
        //[Index(IsUnique = true)]
        public string Name { get; set; }
        public int CardCount { get; set; }
    }
}
