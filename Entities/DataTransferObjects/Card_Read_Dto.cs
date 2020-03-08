using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Card_Read_Dto
    {
        public Guid CardId { get; set; }
        //[Required(ErrorMessage = "Name is Required")]
        public string CardName { get; set; }
        //[Required(ErrorMessage = "Must Provide Arcanum Type")]
        public Arcana Arcana { get; set; }
        public Suit? Suit { get; set; }
        public MinorNumber? MinorNumber { get; set; }
        public MajorNumber? MajorNumber { get; set; }
        public MajorName? MajorName { get; set; }

    }

        public enum Arcana
        {
            Major,
            Minor
        };

        public enum Suit
        {
            Pentacles,
            Cups,
            Wands,
            Swords
        }

        public enum MinorNumber
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Page,
            Queen,
            Knight,
            King
        }

        public enum MajorNumber
        {
            Zero = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Eleven = 11,
            Twelve = 12,
            Thirteen = 13,
            Fourteen = 14,
            Fifteen = 15,
            Sixteen = 16,
            Seventeen = 17,
            Eighteen = 18,
            Nineteen = 19,
            Twenty = 20,
            TwentyOne = 21
        }

        public enum MajorName
        {
            TheFool,
            TheMagician,
            TheHighPriestess,
            TheEmpress,
            TheEmperor,
            TheHierophant,
            TheLovers,
            TheChariot,
            Strength,
            TheHermit,
            WheelOfFortune,
            Justice,
            TheHangedMan,
            Death,
            Temperance,
            TheDevil,
            TheTower,
            TheStar,
            TheMoon,
            TheSun,
            Judgement,
            TheWorld
        }    
}
