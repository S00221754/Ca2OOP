/*Troy Shilton
 * S00221754
 * 03/11/22
 * Ca2 BlackJack
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ca2
{

    public class Program

    {
        /// <summary>
        /// Static lists so all methods below can access it
        /// </summary>
        static List<CardHand> Player = new List<CardHand>();
        static CardHand Player1 = new CardHand();
        static CardHand Player2 = new CardHand();
        static int Player1Score, Player2Score; //Player scores to be able to accessed.
        static void Main(string[] args)
        {
            //Display
            Console.WriteLine("Welcome to Black Jack");
            Console.WriteLine("User turn");
            UserDeal();
            Console.WriteLine("Dealer turn");
            DealerDeal();

            //Reads in scores and decides winner
            if (Player2Score > 21 || Player2Score < Player1Score)
            {
                Console.WriteLine("User Wins");

            }
            else if (Player1Score > 21 || Player1Score < Player2Score)
            {
                Console.WriteLine("User Loses");
            }
            Console.ReadLine();
        }
        /// <summary>
        /// User(you) cards are randomised
        /// </summary>
        static void UserDeal()
        {
            string st;
            //Array to hold information about cards
            string[] cardNo = new string[5];
            string[] cardSuit = new string[5];
            int[] cardValue = new int[5];
            int totalCardValue=0;
            

            cardNo[0] = GetCardNumber();
            cardSuit[0] = GetCardSuit();
            cardValue[0] = GetCardValue(GetCardNumber());
            totalCardValue += cardValue[0];
            if (cardValue[0] == 1 && totalCardValue <= 10)//to assign the ace to be 1 or 11.
            {
                cardValue[0] = 11;
            }
            Player1.Cards.Add(new Card() { CardNumber = cardNo[0], CardSuits = cardSuit[0], CardValue = cardValue[0] }); //Adds Card to list
            Console.WriteLine(Player1.Cards[0].ToString());
            Console.WriteLine($"Your score is {totalCardValue}");
            
            while(totalCardValue <= 21)//to keep asking user to stick or twist until either satisfied or bust.
            {
                int i = 1;
                Console.Write("Do you want to stick or twist - s/t?");//prompt to keep playing
                st = Console.ReadLine();

                if (st == "t")
                {
                    cardNo[i] = GetCardNumber();
                    cardSuit[i] = GetCardSuit();
                    cardValue[i] = GetCardValue(GetCardNumber());
                    totalCardValue += cardValue[i];
                    if (cardValue[i] == 1 && totalCardValue <= 10)//to assign the ace to be 1 or 11.
                    {
                        cardValue[i] = 11;
                    }
                    Player1.Cards.Add(new Card() { CardNumber = cardNo[i], CardSuits = cardSuit[i], CardValue = cardValue[i] });
                    Console.WriteLine(Player1.Cards[i].ToString());
                    i++;
                    Console.WriteLine($"Your score is {totalCardValue}");
                }
                else if (st == "s")//when chosen stick the program will exit this method
                {
                    Player1Score = totalCardValue;
                    break;
                }

                
            }
        }
        /// <summary>
        /// Dealer Plays
        /// </summary>
        static void DealerDeal()
        {
            //Array to store information
            string[] cardNo = new string[5];
            string[] cardSuit = new string[5];
            int[] cardValue = new int[5];
            int totalCardValue = 0;


            cardNo[0] = GetCardNumber();
            cardSuit[0] = GetCardSuit();
            cardValue[0] = GetCardValue(GetCardNumber());
            totalCardValue += cardValue[0];
            Player2.Cards.Add(new Card() { CardNumber = cardNo[0], CardSuits = cardSuit[0], CardValue = cardValue[0] });
            Console.WriteLine(Player2.Cards[0].ToString());
            Console.WriteLine($"Dealer score is {totalCardValue}");

            while(Player2Score <= Player1Score)//The dealer keeps playing until it beats the users score or goes bust
            {
                int i = 1;
                cardNo[i] = GetCardNumber();
                cardSuit[i] = GetCardSuit();
                cardValue[i] = GetCardValue(GetCardNumber());
                totalCardValue += cardValue[1];
                if (cardValue[i] == 1 && totalCardValue <= 10)
                {
                    cardValue[i] = 11;
                }
                Player2.Cards.Add(new Card() { CardNumber = cardNo[i], CardSuits = cardSuit[i], CardValue = cardValue[i] });
                Console.WriteLine(Player2.Cards[i].ToString());
                i++;
                Console.WriteLine($"Dealer score is {totalCardValue}");
                Player2Score = totalCardValue;
            }
            
            
        }
        /// <summary>
        /// Create the card number
        /// </summary>
        /// <returns></returns>
        static string GetCardNumber()
        {
            string cardNumber;
            int cardNum;

            Random cardNo = new Random();
            cardNum = cardNo.Next(1, 13);

            cardNumber = cardNum.ToString();
            
            if (cardNumber == "11")//Used to card when higher than 10
            {
                cardNumber = "Jack";
            }
            else if (cardNumber == "12")
            {
                cardNumber = "Queen";
            }
            else if (cardNumber == "13")
            {
                cardNumber = "King";
            }
            else if (cardNumber == "1")
            {
                cardNumber = "Ace";
            }
            return cardNumber;
        }
        /// <summary>
        /// Gets the card suit
        /// </summary>
        /// <returns></returns>
        static string GetCardSuit()
        {
            string cardSuit;
            int cardSuitNum;
            Random cardSuitNo = new Random();
            cardSuitNum = cardSuitNo.Next(1, 4);

            cardSuit = cardSuitNum.ToString(); //turn to string so output will be string
            if (cardSuit == "1")
            {
                cardSuit = "of Clubs";
            }
            else if (cardSuit == "2")
            {
                cardSuit = "of Diamonds";
            }
            else if (cardSuit == "3")
            {
                cardSuit = "of Hearts";
            }
            else if (cardSuit == "4")
            {
                cardSuit = "of Spades";
            }
            return cardSuit;
        }
        /// <summary>
        /// Get the card number and assigns its value
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        static int GetCardValue(string cardNumber)
        {
            int cardValue;
            if(cardNumber == "Queen" || cardNumber == "King" || cardNumber == "Jack")
            {
                cardValue = 10;
            }
            else if(cardNumber == "Ace")
            {
                cardValue = 1;
            }
            else
            {
                cardValue = int.Parse(cardNumber);//does not need to change so gets converted to int.
            }
            return cardValue;
            

        }


    }
}
