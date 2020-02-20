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
    }
}
