using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }        
        public string Email { get; set; }
        // password will come later
    }
}
