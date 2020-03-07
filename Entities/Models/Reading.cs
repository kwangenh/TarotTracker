using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{    
    public class Reading
    {
        public Guid ReadingId { get; set; }        
        public DateTime ReadingDate { get; set; }
        public List<ReadingCard> ReadingCards { get; set; }
        public ReadingType ReadingType { get; set; }
    }
}
