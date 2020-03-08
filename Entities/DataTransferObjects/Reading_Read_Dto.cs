using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Reading_Read_Dto
    {
        public String Name { get; set; }
        public List<ReadingCard> Cards { get; set; }
    }
}
