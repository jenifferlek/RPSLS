//2 players (2 inputs); continuous 5 rounds; display results for each round; show overall winner after final round
//error handling for invalid inputs (valid inputs: 0-4)

using System;
using System.Collections.Generic;

namespace Rock_Paper_Scissors_Lizard_Spock
{
    //to handle player's data
    abstract class Player
    {
        public List<string> shape = new List<string>() { "Rock", "Paper", "Scissors", "Lizard", "Spock" };
        public string playerShape;
        public int point = 0;
        public abstract void SelectShape();
    }

    class Human : Player
    {
        //Override the SelectShape method to retrieve the shape selected by the player
        public override void SelectShape()
        {
            Console.WriteLine(" 0:Rock\n 1:Paper\n 2:Scissors\n 3:Lizard\n 4.Spock\n");

            int input = 0;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("The input value is not an integer. Please attempt again.");
                }
                else
                {
                    if (input >= 0 && input <= 4)
                    {
                        break;
                    }
                    Console.WriteLine("Please only input an integer between 0 and 4.\n");
                }
            }
            playerShape = shape[input];
        }
    }

    public class RPSLS
    {
        public int point = 0;
        Player playerA = new Human();
        Player playerB = new Human();

        public void Start()
        {
            int i = 1;
            while (i <= 5) //loop for 5 rounds
            {
                Console.WriteLine("|Round {0}", i + "|\n");
                Console.WriteLine("Hi Player A, please choose your shape: \n");
                playerA.SelectShape();
                Console.WriteLine("\nHi Player B, please choose your shape: \n");
                playerB.SelectShape();
                Compare();
                Console.WriteLine("|Results of Round {0}", i + "|\nPlayer A : Player B - " + playerA.point + " : " + playerB.point + "\n"); //display the results of each round for both players
                i++;
            }
            if (playerA.point > playerB.point)
            {
                Console.WriteLine("---Final Result: The overall winner is Player A!---");
            }
            else if (playerA.point < playerB.point)
            {
                Console.WriteLine("---Final Result: The overall winner is Player B!---");
            }
            else
            {
                Console.WriteLine("---Final Result: No winner since it's a draw!---");
            }
        }

        public void Compare()
        {
            //rock X scissors; rock X lizard
            //paper X rock; paper X spock
            //scissors X paper; scissors X lizard
            //lizard X paper; lizard X spock
            //spock X scissors; spock X rock

            if ((playerA.playerShape == "Rock" && playerB.playerShape == "Scissors" || playerA.playerShape == "Rock" && playerB.playerShape == "Lizard" ||
               (playerA.playerShape == "Paper" && playerB.playerShape == "Rock" || playerA.playerShape == "Paper" && playerB.playerShape == "Spock") ||
               (playerA.playerShape == "Scissors" && playerB.playerShape == "Paper" || playerA.playerShape == "Scissors" && playerB.playerShape == "Lizard") ||
               (playerA.playerShape == "Lizard" && playerB.playerShape == "Paper" || playerA.playerShape == "Lizard" && playerB.playerShape == "Spock") ||
               (playerA.playerShape == "Spock" && playerB.playerShape == "Scissors" || playerA.playerShape == "Spock" && playerB.playerShape == "Rock")) == true)
            {
                Console.WriteLine("\n Player A wins!\n");
                playerA.point++;
            }
            else if (playerA.playerShape == playerB.playerShape)
            {
                Console.WriteLine("\nIt's a draw!\n");
            }
            else
            {
                Console.WriteLine("\n Player B wins!\n");
                playerB.point++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Rock Paper Scissor Lizard Spock.\n");
            Console.WriteLine("Scissors cuts Paper,\nPaper covers Rock,\nRock crushes Lizard,\nLizard poisons Spock,\n" +
                "Spock smashes Scissors,\nScissors decapitates Lizard,\nLizard eats Paper,\nPaper disproves Spock,\n" +
                "Spock vaporizes Rock,\nAnd as it always has, Rock crushes Scissors\n");
            RPSLS game = new RPSLS();
            game.Start();
        }
    }
}