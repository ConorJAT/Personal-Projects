using System;
using System.Collections.Generic;

namespace UaD_River_Scorekeeper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            List<Player> shifted = new List<Player>();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("    ===== Up and Down the River Scorekeeper =====\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" > How many players: ");
            Console.ForegroundColor = ConsoleColor.White;
            int numPlayers = int.Parse(Console.ReadLine());


            // Enters a Loop Infinitely Until an Acceptable Number of Players is Entered:

            while (numPlayers > 6 || numPlayers < 2) 
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                if (numPlayers > 6)
                {
                    Console.Write(" > Too many players! Please enter fewer players: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    numPlayers = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.Write(" > Too few players! Please enter more players: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    numPlayers = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("");


            // Creates a New Player Object for up to the Total Amount of Players:

            for (int i = 1; i <= numPlayers; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" > Player " + i + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                if (numPlayers <= 5)
                {
                    players.Add(new Player(Console.ReadLine(), new int[10], new int[9]));
                    shifted.Add(players[i-1]);
                }
                else
                {
                    players.Add(new Player(Console.ReadLine(), new int[8], new int[8]));
                    shifted.Add(players[i-1]);
                }
            }
            Console.Clear();


            int trickCheck;
            int roundCount = 0;


            // Going Up the River:

            for (int i = 0; i < players[0].UpScore.Length; i++)
            {
                PrintScores(numPlayers, players, roundCount);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"  === Round {(roundCount + 1)} ===\n");
                

                // Getting Everyone's Bids:

                for (int j = 0; j < players.Count; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"> Bid for {shifted[j].Name}: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    shifted[j].UpScore[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("\n");
                PrintScores(numPlayers, players, roundCount + 1);


                // Getting Everyone's Trick Count and Awards Points Appropriately:

                for (int j = 0; j < players.Count; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"> Tricks taken by {players[j].Name}: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    trickCheck = int.Parse(Console.ReadLine());
                    players[j].GiveUpPoints(trickCheck, i);
                }


                // Outputs Scores for the Round and Shifts the Bidding Order:

                Console.WriteLine("\n");
                PrintScores(numPlayers, players, roundCount + 1);
                roundCount++;
                shifted = ShiftBidOrder(shifted);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("> Press any key to proceed to the next round");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(); Console.Clear();
            }


            // Going Down the River:

            for (int i = 0; i < players[0].DnScore.Length; i++)
            {
                PrintScores(numPlayers, players, roundCount);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"  === Round {(roundCount + 1)} ===\n");


                // Getting Everyone's Bids:

                for (int j = 0; j < players.Count; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"> Bid for {shifted[j].Name}: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    shifted[j].DnScore[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("\n");
                PrintScores(numPlayers, players, roundCount + 1);


                // Getting Everyone's Trick Count and Awards Points Appropriately:

                for (int j = 0; j < players.Count; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"> Tricks taken by {players[j].Name}: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    trickCheck = int.Parse(Console.ReadLine());
                    players[j].GiveDownPoints(trickCheck, i);
                }


                // Outputs Scores for the Round and Shifts the Bidding Order:

                Console.WriteLine("\n");
                PrintScores(numPlayers, players, roundCount + 1);
                roundCount++;
                shifted = ShiftBidOrder(shifted);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("> Press any key to proceed to the next round");
                Console.ReadKey(); Console.Clear();
            }
        }



        public static void PrintScores(int numPlayers, List<Player> people, int round)
        {
            
            // Creates a Specialized Score Chart for 2-5 Players:

            if (numPlayers <= 5)
            {
                Console.WriteLine("Name:\t\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10");

                for (int i = 0; i < people.Count; i++)
                {
                    people[i].PrintUpScores(round);
                    Console.WriteLine("");
                }

                Console.WriteLine("");


                Console.WriteLine("Name:\t\t9\t8\t7\t6\t5\t4\t3\t2\t1");

                for (int i = 0; i < people.Count; i++)
                {
                    Console.Write($"{people[i].Name}\t\t");
                    if (round >= people[0].UpScore.Length)
                    {
                        people[i].PrintDownScores(round);
                    }   

                    Console.WriteLine("");
                }
            }


            // Creates a Specialized Score Chart for 6 Players:

            else
            {
                Console.WriteLine("Name:\t\t1\t2\t3\t4\t5\t6\t7\t8");

                for (int i = 0; i < people.Count; i++)
                {
                    people[i].PrintUpScores(round);
                    Console.WriteLine("");
                }

                Console.WriteLine("");


                Console.WriteLine("Name:\t\t8\t7\t6\t5\t4\t3\t2\t1");

                for (int i = 0; i < people.Count; i++)
                {
                    Console.Write($"{people[i].Name}\t\t");
                    if (round >= people[0].UpScore.Length)
                    {
                        people[i].PrintDownScores(round);
                    }

                    Console.WriteLine("");
                }
            }

            Console.WriteLine("");
        }

        public static List<Player> ShiftBidOrder(List<Player> people)
        {
            Player hold = people[0];

            for (int i = 0; i < people.Count - 1; i++)
            {
                people[i] = people[i + 1];
            }

            people[people.Count - 1] = hold;
            return people;
        }
    }
}
