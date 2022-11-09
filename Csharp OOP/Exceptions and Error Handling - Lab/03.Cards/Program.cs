using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] cardsDetails = Console.ReadLine().Split(", ");

            foreach (var card in cardsDetails)
            {
                string[] currentCardDetails = card.Split(" ");
                string cardFace = currentCardDetails[0];
                string cardSuit = currentCardDetails[1];

                try
                {
                    cards.Add(CreateCard(cardFace, cardSuit));
                }
                catch (ArgumentException)
                {

                    Console.WriteLine("Invalid card!");
                }

                
            }
        

            PrintCards(cards);
        }

        private static Card CreateCard(string cardFace, string cardSuit)
        {

            Card curentCard = new Card(cardFace, cardSuit);
            return curentCard;
        }

        private static void PrintCards(List<Card> cards)
        {
            
            foreach (var item in cards)
            {
                Console.Write($"{item} ");
            }
        }

        public class Card
        {
            private string face;
            private string suit;
            private HashSet<string> faces = new HashSet<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            private HashSet<string> suits = new HashSet<string> { "S", "H", "D", "C" };

            public Card(string face, string suit)
            {
                this.Face = face;
                this.Suit = suit;
            }

            public string Face
            {
                get { return face; }
                set
                {
                    if (!faces.Any(f => f == value))
                    {
                        throw new ArgumentException();
                    }

                    face = value;
                }
            }

            public string Suit
            {
                get { return suit; }
                set
                {
                    if (!suits.Any(f => f == value))
                    {
                        throw new ArgumentException();
                    }

                    if (value == "S")
                    {
                        suit = char.ToString('\u2660');
                    }
                    else if (value == "H")
                    {
                        suit = char.ToString('\u2665');
                    }
                    else if (value == "D")
                    {
                        suit = char.ToString('\u2666');
                    }
                    else if (value == "C")
                    {
                        suit = char.ToString('\u2663');
                    }

                }
            }

            public override string ToString()
            {
                return $"[{this.Face}{this.Suit}]";
            }
        }
    }
}
