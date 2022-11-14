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
        
        static CardHand Player1 = new CardHand();
        static CardHand Player2 = new CardHand();
        static int Player1Score, Player2Score; //Player scores to be able to accessed.

        static void Main(string[] args)
        {
            //declare variable
            double wager;
            //Display
            Console.WriteLine("Welcome to Black Jack");

            //Console.WriteLine("User turn");

            wager = UserDeal();

            if (Player1Score > 21)
            {
                Console.WriteLine($"User lost,Over 21 - {wager}");
            }
            else if (Player1Score <= 21)
            {
                Console.WriteLine("Dealer turn");
                DealerDeal();

                //Reads in scores and decides winner
                if (Player2Score > 21 || Player2Score < Player1Score)
                {
                    Console.WriteLine($"User Wins, + {wager}");

                }
                else if (Player1Score < Player2Score)
                {
                    Console.WriteLine($"User Loses, - {wager}");
                }
                else if (Player2Score == Player1Score)
                {
                    Console.WriteLine("Its a tie both players have the same value.");
                }
            }
            
            

            Console.ReadLine();
        }
        /// <summary>
        /// User(you) cards are randomised
        /// </summary>
        static double UserDeal()
        {
            //prompts user to enter a wager amount
            Console.Write("Enter wager: ");
            double wager = double.Parse(Console.ReadLine());

            string st;
            //Array to hold information about cards
            string[] cardNo = new string[20];
            string[] cardSuit = new string[20];
            int[] cardValue = new int[20];


            Random rng = new Random();
            

            cardNo[0] = GetCardNumber(rng.Next(1,13));
            cardSuit[0] = GetCardSuit(rng.Next(1,4));
            cardValue[0] = GetCardValue(cardNo[0]);
            if (cardValue[0] == 1 && Player1Score <= 10)//to assign the ace to be 1 or 11.
            {
                cardValue[0] = 11;
            }
            Player1Score += cardValue[0];
            
            Player1.Cards.Add(new Card() { CardNumber = cardNo[0], CardSuits = cardSuit[0], CardValue = cardValue[0] }); //Adds Card to list
            Console.WriteLine(Player1.Cards[0].ToString());

            Console.WriteLine($"Your score is {Player1Score}");
            cardNo[1] = GetCardNumber(rng.Next(1, 13));
            cardSuit[1] = GetCardSuit(rng.Next(1, 4));
            cardValue[1] = GetCardValue(cardNo[1]);
            if (cardValue[1] == 1 && Player1Score <= 10)//to assign the ace to be 1 or 11.
            {
                cardValue[1] = 11;
            }
            Player1Score += cardValue[1];

            Player1.Cards.Add(new Card() { CardNumber = cardNo[1], CardSuits = cardSuit[1], CardValue = cardValue[1] }); //Adds Card to list
            Console.WriteLine(Player1.Cards[1].ToString());
            Console.WriteLine($"Your score is {Player1Score}");
            int i = 2;
            while (Player1Score <= 21)//to keep asking user to stick or twist until either satisfied or bust.
            {
                
                Console.Write("Do you want to stick or twist or double down - s/t/d?");//prompt to keep stick, twist or double down.
                st = Console.ReadLine().ToLower();

                if (st == "t")
                {
                    cardNo[i] = GetCardNumber(rng.Next(1,13));
                    cardSuit[i] = GetCardSuit(rng.Next(1, 4));
                    cardValue[i] = GetCardValue(cardNo[i]);
                    if (cardValue[i] == 1 && Player1Score <= 10)//to assign the ace to be 1 or 11.
                    {
                        cardValue[i] = 11;
                    }
                    Player1Score += cardValue[i];
                    
                    Player1.Cards.Add(new Card() { CardNumber = cardNo[i], CardSuits = cardSuit[i], CardValue = cardValue[i] });
                    Console.WriteLine(Player1.Cards[i].ToString());
                    i++;
                    Console.WriteLine($"Your score is {Player1Score}");
                }
                else if (st == "s")//when chosen stick the program will exit this method
                {                   
                    return wager;
                    
                }
                else if(st == "d")
                {
                    wager = wager * 2; //double down x2 the wager amount and does not allow user to hit anymore after their next card.

                    cardNo[2] = GetCardNumber(rng.Next(1, 13));
                    cardSuit[2] = GetCardSuit(rng.Next(1, 4));
                    cardValue[2] = GetCardValue(cardNo[2]);
                    if (cardValue[2] == 1 && Player1Score <= 10)//to assign the ace to be 1 or 11.
                    {
                        cardValue[2] = 11;
                    }
                    Player1Score += cardValue[2];

                    Player1.Cards.Add(new Card() { CardNumber = cardNo[2], CardSuits = cardSuit[2], CardValue = cardValue[2] }); //Adds Card to list
                    Console.WriteLine(Player1.Cards[2].ToString());
                    Console.WriteLine($"Your score is {Player1Score}");
                    Console.WriteLine($"You have double downed therefore your wager has been doubled {wager} and you can no longer hit.");
                    break;
                }


                
            }
            return wager;
        }
        /// <summary>
        /// Dealer Plays
        /// </summary>
        static void DealerDeal()
        {
            //Array to store information
            string[] cardNo = new string[20];
            string[] cardSuit = new string[20];
            int[] cardValue = new int[20];
            

            Random rng = new Random();
            

            cardNo[0] = GetCardNumber(rng.Next(1,13));
            cardSuit[0] = GetCardSuit(rng.Next(1,4));
            cardValue[0] = GetCardValue(cardNo[0]);
            if (cardValue[0] == 1 && Player2Score <= 10)//to assign the ace to be 1 or 11.
            {
                cardValue[0] = 11;
            }
            Player2Score += cardValue[0];
            Player2.Cards.Add(new Card() { CardNumber = cardNo[0], CardSuits = cardSuit[0], CardValue = cardValue[0] });
            Console.WriteLine(Player2.Cards[0].ToString());
            Console.WriteLine($"Dealer score is {Player2Score}");
            int i = 1;
            while (Player2Score <= Player1Score)//The dealer keeps playing until it beats the users score or goes bust
            {
                
                cardNo[i] = GetCardNumber(rng.Next(1,13));
                cardSuit[i] = GetCardSuit(rng.Next(1,4));
                cardValue[i] = GetCardValue(cardNo[i]);
                if (cardValue[i] == 1 && Player2Score <= 10)
                {
                    cardValue[i] = 11;
                }
                Player2Score += cardValue[i];
                
                Player2.Cards.Add(new Card() { CardNumber = cardNo[i], CardSuits = cardSuit[i], CardValue = cardValue[i] });
                Console.WriteLine(Player2.Cards[i].ToString());
                i++;
                Console.WriteLine($"Dealer score is {Player2Score}");
                
            }
            
            
        }
        /// <summary>
        /// Create the card number
        /// </summary>
        /// <returns></returns>
        static string GetCardNumber(int num)
        {
            string cardNumber;
            

           

            cardNumber = num.ToString();
            
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
        static string GetCardSuit(int num)
        {
            string cardSuit;
            ;
            

            cardSuit = num.ToString(); //turn to string so output will be string
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
