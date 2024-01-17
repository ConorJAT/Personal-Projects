using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UaD_River_Scorekeeper
{
    class Player
    {
        private string name;
        private int totalScore;
        private int[] upScores;
        private int[] dnScores;

        public Player(string name, int[] upScores, int[] dnScores)
        {
            this.name = name;
            totalScore = 0;
            this.upScores = upScores;
            this.dnScores = dnScores;
        }

        public string Name { get { return name; } }

        public int Total { get { return totalScore; } set { totalScore = value; } }

        public int[] UpScore { get { return upScores; } }

        public int[] DnScore { get { return dnScores; } }

        public void PrintUpScores(int round)
        {
            Console.Write($"{name}\t\t");
            for (int i = 0; i < round; i++)
            {
                if (i == upScores.Length)
                {
                    break;
                }
                Console.Write($"{upScores[i]}\t");
            }
        }

        public void PrintDownScores(int round)
        {
            for (int i = 0; i < round - upScores.Length; i++)
            {
                Console.Write($"{dnScores[i]}\t");
            }
        }

        public void GiveUpPoints(int tricks, int index)
        {
            if (tricks == upScores[index])
            {
                totalScore += 10 + upScores[index];
                upScores[index] = totalScore;
            }
            else if (tricks > upScores[index])
            {
                totalScore += upScores[index];
                upScores[index] = totalScore;
            }
            else
            {
                upScores[index] = totalScore;
            }         
        }

        public void GiveDownPoints(int tricks, int index)
        {
            if (tricks == dnScores[index])
            {
                totalScore += 10 + dnScores[index];
                dnScores[index] = totalScore;
            }
            else if (tricks > dnScores[index])
            {
                totalScore += dnScores[index];
                dnScores[index] = totalScore;
            }
            else
            {
                dnScores[index] = totalScore;
            }
        }
    }
}
