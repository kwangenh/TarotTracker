using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TestDataBuilder
    {
        private IRepositoryWrapper _repoWrapper;
        public TestDataBuilder(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        public void BuildCardsAndReadingTypes()
        {
            var majorCards = BuildMajorCards();

            var minorCards = BuildWands()
                            .Concat(BuildSwords())
                            .Concat(BuildCups())
                            .Concat(BuildPentacles())
                                .ToList();

            var readingTypes = BuildTestReadingTypes();

            foreach(var minorCard in minorCards)
            {
                _repoWrapper.Card.Create(minorCard);
            }

            foreach(var majorCard in majorCards)
            {
                _repoWrapper.Card.Create(majorCard);
            }

            foreach(var readingType in readingTypes)
            {
                _repoWrapper.ReadingType.Create(readingType);
            }

            _repoWrapper.Save();
        }

        public List<ReadingType> BuildTestReadingTypes()
        {
            return new List<ReadingType>
            {
                new ReadingType { Name = "Daily Reading", CardCount = 1},
                new ReadingType { Name = "Past, Present, Future Reading", CardCount = 3},
                new ReadingType { Name = "Yearly Reading", CardCount = 12},
            };
        }

        public List<Card> BuildMajorCards()
        {
            var cards = new List<Card>
            {
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Zero, CardName = "The Fool", MajorName = MajorName.TheFool },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.One, CardName = "The Magician", MajorName = MajorName.TheMagician },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Two, CardName = "The High Priestess", MajorName = MajorName.TheHighPriestess },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Three, CardName = "The Empress", MajorName = MajorName.TheEmpress },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Four, CardName = "The Emperor", MajorName = MajorName.TheEmperor },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Five, CardName = "The Hierophant", MajorName = MajorName.TheHierophant },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Six, CardName = "The Lovers", MajorName = MajorName.TheLovers },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Seven, CardName = "The Chariot", MajorName = MajorName.TheChariot },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Eight, CardName = "Strength", MajorName = MajorName.Strength },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Nine, CardName = "The Hermit", MajorName = MajorName.TheHermit },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Ten, CardName = "Wheel of Fortune", MajorName = MajorName.WheelOfFortune },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Eleven, CardName = "Justice", MajorName = MajorName.Justice },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Twelve, CardName = "The Hanged Man", MajorName = MajorName.TheHangedMan },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Thirteen, CardName = "Death", MajorName = MajorName.Death },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Fourteen, CardName = "Temperance", MajorName = MajorName.Temperance },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Fifteen, CardName = "The Devil", MajorName = MajorName.TheDevil },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Sixteen, CardName = "The Tower", MajorName = MajorName.TheTower },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Seventeen, CardName = "The Star", MajorName = MajorName.TheStar },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Eighteen, CardName = "The Moon", MajorName = MajorName.TheMoon },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Nineteen, CardName = "The Sun", MajorName = MajorName.TheSun },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.Twenty, CardName = "Judgement", MajorName = MajorName.Judgement },
                new Card { Arcana = Arcana.Major, MajorNumber = MajorNumber.TwentyOne, CardName = "The World", MajorName = MajorName.TheWorld }
            };

            return cards;
        }
        public List<Card> BuildPentacles()
        {
            var cards = new List<Card>
            {
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Ace, Suit = Suit.Pentacles, CardName = "Ace of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Two, Suit = Suit.Pentacles, CardName = "Two of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Three, Suit = Suit.Pentacles, CardName = "Three of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Four, Suit = Suit.Pentacles, CardName = "Four of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Five, Suit = Suit.Pentacles, CardName = "Five of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Six, Suit = Suit.Pentacles, CardName = "Six of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Seven, Suit = Suit.Pentacles, CardName = "Seven of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Eight, Suit = Suit.Pentacles, CardName = "Eight of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Nine, Suit = Suit.Pentacles, CardName = "Nine of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Ten, Suit = Suit.Pentacles, CardName = "Ten of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Page, Suit = Suit.Pentacles, CardName = "Page of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Knight, Suit = Suit.Pentacles, CardName = "Knight of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Queen, Suit = Suit.Pentacles, CardName = "Queen of Penatacles" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.King, Suit = Suit.Pentacles, CardName = "King of Penatacles" }
            };

            return cards;
        }

        public List<Card> BuildSwords()
        {
            var cards = new List<Card>
            {
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Ace, Suit = Suit.Swords, CardName = "Ace of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Two, Suit = Suit.Swords, CardName = "Two of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Three, Suit = Suit.Swords, CardName = "Three of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Four, Suit = Suit.Swords, CardName = "Four of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Five, Suit = Suit.Swords, CardName = "Five of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Six, Suit = Suit.Swords, CardName = "Six of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Seven, Suit = Suit.Swords, CardName = "Seven of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Eight, Suit = Suit.Swords, CardName = "Eight of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Nine, Suit = Suit.Swords, CardName = "Nine of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Ten, Suit = Suit.Swords, CardName = "Ten of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Page, Suit = Suit.Swords, CardName = "Page of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Knight, Suit = Suit.Swords, CardName = "Knight of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Queen, Suit = Suit.Swords, CardName = "Queen of Swords" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.King, Suit = Suit.Swords, CardName = "King of Swords" }
            };

            return cards;
        }

        public List<Card> BuildWands()
        {
            var cards = new List<Card>
            {
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Ace, Suit = Suit.Wands, CardName = "Ace of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Two, Suit = Suit.Wands, CardName = "Two of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Three, Suit = Suit.Wands, CardName = "Three of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Four, Suit = Suit.Wands, CardName = "Four of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Five, Suit = Suit.Wands, CardName = "Five of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Six, Suit = Suit.Wands, CardName = "Six of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Seven, Suit = Suit.Wands, CardName = "Seven of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Eight, Suit = Suit.Wands, CardName = "Eight of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Nine, Suit = Suit.Wands, CardName = "Nine of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Ten, Suit = Suit.Wands, CardName = "Ten of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Page, Suit = Suit.Wands, CardName = "Page of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Knight, Suit = Suit.Wands, CardName = "Knight of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Queen, Suit = Suit.Wands, CardName = "Queen of Wands" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.King, Suit = Suit.Wands, CardName = "King of Wands" }
            };

            return cards;
        }

        public List<Card> BuildCups()
        {
            var cards = new List<Card>
            {
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Ace, Suit = Suit.Cups, CardName = "Ace of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Two, Suit = Suit.Cups, CardName = "Two of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Three, Suit = Suit.Cups, CardName = "Three of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Four, Suit = Suit.Cups, CardName = "Four of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Five, Suit = Suit.Cups, CardName = "Five of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Six, Suit = Suit.Cups, CardName = "Six of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Seven, Suit = Suit.Cups, CardName = "Seven of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Eight, Suit = Suit.Cups, CardName = "Eight of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Nine, Suit = Suit.Cups, CardName = "Nine of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Ten, Suit = Suit.Cups, CardName = "Ten of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Page, Suit = Suit.Cups, CardName = "Page of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Knight, Suit = Suit.Cups, CardName = "Knight of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.Queen, Suit = Suit.Cups, CardName = "Queen of Cups" },
                new Card { Arcana = Arcana.Minor, MinorNumber = MinorNumber.King, Suit = Suit.Cups, CardName = "King of Cups" }
            };

            return cards;
        }
    }
}
