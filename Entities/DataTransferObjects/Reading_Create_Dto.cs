using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Reading_Create_Dto
    {           
        public ReadingType_Read_Dto ReadingType {get; set;}
        public List<Card_Read_Dto> ReadingCards { get; set; }  
        
    }
}
