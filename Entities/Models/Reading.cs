using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{

    // [Table("Reading")]
    public class Reading
    {
        public Guid ReadingId { get; set; }
        public string ReadingType { get; set; }
        public DateTime ReadingDate { get; set; }
        public List<ReadingCard> ReadingCards { get; set; }
    }
}
