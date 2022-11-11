using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ca2
{
    internal class CardHand
    {
        public string CardNumber { get;  set; }
        public string CardSuits { get;  set; }
        public int CardValue { get;  set; }

        
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Puts cards into a list
        /// </summary>
        public CardHand()
        {
            Cards = new List<Card>();
        }
        
    }
}
