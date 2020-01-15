using System;


namespace Blackjack
{
    class Blackjack
    {
        //Player cards is an array that holds the cards that were dealt to the user. 
        static string[] playerCards = new string[11];
        //users to store the player choice (hit or stay)
        static string playerChoice = "";
        
        static int playerTotal = 0;
        static int  cardCount = 1; 
        static int  dealerTotal = 0;
        static Random cardRandomizer = new Random();
        static string playAgain ="Y";

        static void Main(string[] args)
        {
            //Main loop: playagain is always yes unless they choose no 
            while (playAgain.ToUpper() == "Y")
            {
                //Deal cards and display a welcome message
                StartGame();
                //handle the loop which plays out the users hand (Hit or stay)
                StartGameLoop();

                Console.WriteLine("Would you like to play again? (Y)es or (N)o?");
                PlayAgain();
            }
        }
        //startGane Deals the player and the dealer cards . Displays a welcome message and asks the player if they would like to hit or stay
        static void StartGame()
        {
            dealerTotal = cardRandomizer.Next(15, 22);
            playerCards[0] = DealCard();
            playerCards[1] = DealCard();
            DisplayWelcomeMessage();
            //Do this until the player chooses a valid option
       
        }

        private static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Blackjack! You were dealt the cards : {0} and {1} ", playerCards[0], playerCards[1]);
            Console.WriteLine("Your playerTotall is {0} ", playerTotal);
        }

        static void StartGameLoop()
        {

            do
            {
                Console.WriteLine("Would you like to (H)it or (S)tay?");
                playerChoice = Console.ReadLine().ToUpper();
            }
            while (!playerChoice.Equals("H") && !playerChoice.Equals("S"));
          
            
            if (playerChoice.Equals("H"))
            {
                //hit will get them a card / check the total and ask for another hit 
                Hit();
            }

            if (playerChoice.Equals("S"))
            {
                if (playerTotal > dealerTotal && playerTotal <= 21)
                {
                    Console.WriteLine("Congrats! You won the game! The dealer's playerTotal was {0} ", dealerTotal); 
                }
                else if (playerTotal < dealerTotal)
                {
                    Console.WriteLine("Sorry, you lost! The dealer's playerTotal was {0}", dealerTotal);
                }
            }
         
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
                            Card = "Two"; playerTotal += 2;
                            break;
                        case 2:
                            Card = "Three"; playerTotal += 3;
                            break;
                        case 3:
                            Card = "Four"; playerTotal += 4;
                            break;
                        case 4:
                            Card = "Five"; playerTotal += 5;
                            break;
                        case 5:
                            Card = "Six"; playerTotal += 6;
                            break;
                        case 6:
                            Card = "Seven"; playerTotal += 7;
                            break;
                        case 7:
                            Card = "Eight"; playerTotal += 8;
                            break;
                        case 8:
                            Card = "Nine"; playerTotal += 9;
                            break;
                        case 9:
                            Card = "Ten"; playerTotal += 10;
                            break;
                        case 10:
                            Card = "Jack"; playerTotal += 10;
                            break;
                        case 11:
                            Card = "Queen"; playerTotal += 10;
                            break;
                        case 12:
                            Card = "King"; playerTotal += 10;
                            break;
                        case 13:
                            Card = "Ace"; playerTotal += 11;
                            break;
                        default:
                            Card = "2"; playerTotal += 2;
                            break;
                    }
            return Card;
        }

        static void Hit()
        {
            cardCount += 1;
            playerCards[cardCount] = DealCard();
            Console.WriteLine("You card is  a(n) {0}  and your new playerTotall is {1}. ", playerCards[cardCount] , playerTotal);

            if (playerTotal.Equals(21))
            {
                Console.WriteLine("You got Blackjack! The dealer's playerTotall was {0}. ", dealerTotal );
                
               
            }
            else if (playerTotal > 21)
            {
                Console.WriteLine("You busted!  Sorry!. The dealer's playerTotall was {0}",dealerTotal );
               
            }
            else if (playerTotal < 21)
            {
                do
                {
                    Console.WriteLine("Would you like to hit or stay? h for hit s for stay");
                    playerChoice = Console.ReadLine().ToUpper();
                }
              while (!playerChoice.Equals("H") && !playerChoice.Equals("S"));
                if (playerChoice.ToUpper() == "H")
                {
                    Hit();
                }
               
            }
        }

        static void PlayAgain()
        {

            //Loop until they make a valid choice 
            do
            {
                playAgain = Console.ReadLine().ToUpper();
            }
            while (!playAgain.Equals("Y") && !playAgain.Equals("N"));

            if (playAgain.Equals("Y"))
            {
                Console.WriteLine("Press enter to restart the game!");
                Console.ReadLine();
                Console.Clear();
                dealerTotal = 0;
                cardCount = 1;
                playerTotal = 0;
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