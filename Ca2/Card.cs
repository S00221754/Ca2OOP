/*Troy Shilton
 * S00221754
 * 03/11/22
 * Ca2 BlackJack
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ca2
{
    public class Card
    {
        public string CardNumber { get;  set; }
        public string CardSuits { get;  set; }
        public int CardValue { get;  set; }

        public override string ToString()
        {
            //Displays output score
            return string.Format($"Card dealt is the {CardNumber} {CardSuits}, value of {CardValue}");
        }

    }
}
