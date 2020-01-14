using System;


namespace Blackjack
{
    class Blackjack
    {
        static string[] playerCards = new string[11];
        static string hitOrStay = "";
        static int total = 0, count = 1, dealerTotal = 0;
        static Random cardRandomizer = new Random();

        static void Main(string[] args)
        {
          StartGame();
        }
        static void StartGame()
        {
            dealerTotal = cardRandomizer.Next(15, 22);
            playerCards[0] = DealCard();
            playerCards[1] = DealCard();
            DisplayWelcomeMessage();
            do
            {
               Console.WriteLine("Would you like to (H)it or (S)tay?") ;
                hitOrStay = Console.ReadLine().ToUpper();
            }
            while (!hitOrStay.Equals("H") && !hitOrStay.Equals("S"));
            StartGameLoop();
        }

        private static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Blackjack! You were dealt the cards : {0} and {1} ", playerCards[0], playerCards[1]);
            Console.WriteLine("Your total is {0} ", total);
        }

        static void StartGameLoop()
        {
            if (hitOrStay.Equals("H"))
            {
                Hit();
            }
            else if (hitOrStay.Equals("S"))
            {
                if (total > dealerTotal && total <= 21)
                {
                    Console.WriteLine("Congrats! You won the game! The dealer's total was {0} ", dealerTotal); 
                    Console.WriteLine("Would you like to play again? y/n");
                    PlayAgain();
                }
                else if (total < dealerTotal)
                {
                    Console.WriteLine("\nSorry, you lost! The dealer's total was " + dealerTotal + ".\nWould you like to play again? y/n");
                    PlayAgain();
                }
            }
            Console.ReadLine();
        }

        static string DealCard()
        {
           
            int cards = cardRandomizer.Next(1, 14);
            string Card = GetCardValue(cards);
            return Card;
        }

        static string GetCardValue(int cards)
        {
            string Card;

                    switch (cards)
                    {
                        case 1:
                            Card = "Two"; total += 2;
                            break;
                        case 2:
                            Card = "Three"; total += 3;
                            break;
                        case 3:
                            Card = "Four"; total += 4;
                            break;
                        case 4:
                            Card = "Five"; total += 5;
                            break;
                        case 5:
                            Card = "Six"; total += 6;
                            break;
                        case 6:
                            Card = "Seven"; total += 7;
                            break;
                        case 7:
                            Card = "Eight"; total += 8;
                            break;
                        case 8:
                            Card = "Nine"; total += 9;
                            break;
                        case 9:
                            Card = "Ten"; total += 10;
                            break;
                        case 10:
                            Card = "Jack"; total += 10;
                            break;
                        case 11:
                            Card = "Queen"; total += 10;
                            break;
                        case 12:
                            Card = "King"; total += 10;
                            break;
                        case 13:
                            Card = "Ace"; total += 11;
                            break;
                        default:
                            Card = "2"; total += 2;
                            break;
                    }
            return Card;
        }

        static void Hit()
        {
            count += 1;
            playerCards[count] = DealCard();
            Console.WriteLine("You card is  a(n) {0}  and your new total is {1}. ", playerCards[count] , total);

            if (total.Equals(21))
            {
                Console.WriteLine("You got Blackjack! The dealer's total was {0}. \nWould you like to play again? ", dealerTotal );
                PlayAgain();
            }
            else if (total > 21)
            {
                Console.WriteLine("\nYou busted!  Sorry!. The dealer's total was {0} .\nWould you like to play again? y/n",  dealerTotal );
                PlayAgain();
            }
            else if (total < 21)
            {
                do
                {
                    Console.WriteLine("\nWould you like to hit or stay? h for hit s for stay");
                    hitOrStay = Console.ReadLine().ToUpper();
                }
                while (!hitOrStay.Equals("H") && !hitOrStay.Equals("S"));
                StartGame();
            }
        }

        static void PlayAgain()
        {
            string playAgain = "";

            do
            {
                playAgain = Console.ReadLine().ToUpper();
            }
            while (!playAgain.Equals("Y") && !playAgain.Equals("N"));

            if (playAgain.Equals("Y"))
            {
                Console.WriteLine("\nPress enter to restart the game!");
                Console.ReadLine();
                Console.Clear();
                dealerTotal = 0;
                count = 1;
                total = 0;

                StartGameLoop();
            }
            else if (playAgain.Equals("N"))
            {
      

                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Enter)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Read();
                    Environment.Exit(0);
                }
            }
        }
    }
}