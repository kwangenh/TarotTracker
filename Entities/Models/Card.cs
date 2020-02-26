using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Card")]
    public class Card
    {
        public Guid CardId { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string CardName { get; set; }        
        // ToDo: public Category CardType { get; set; }
        // need to include cup, wand, pentacle, sword and major arcana perhaps as enum ?
    }
}
