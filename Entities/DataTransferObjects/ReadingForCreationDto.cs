using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ReadingForCreationDto
    {    
        // public DateTime ReadingDate { get; set; }
        public ReadingType ReadingType {get; set;}
        public List<ReadingCard> ReadingCards { get; set; }          
    }
}
