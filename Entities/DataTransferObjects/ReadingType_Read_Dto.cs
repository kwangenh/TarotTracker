using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ReadingType_Read_Dto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CardCount { get; set; }
    }
}
