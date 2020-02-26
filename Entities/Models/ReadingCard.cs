using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ReadingCard
    {        
        public Guid ReadingCardId { get; set; }
        public Card ReadCard { get; set; }
        public Reading CardReading { get; set; }
    }
}
