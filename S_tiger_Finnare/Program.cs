using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_tiger_Finnare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("tiger Finnare ><><\n");
            int[,] map = new int[10,10];
            List<Node> open = new List<Node>();
            List<Node> closed = new List<Node>();
            int goalX, goalY;
            int startX, startY;
            Random rnd = new Random();

            goalX = rnd.Next(10);
            goalY = rnd.Next(10);
            startX = rnd.Next(10);
            startY = rnd.Next(10);

            for (int i = 0; i < 10; i++) {
                for (int k = 0; k < 10; k++) {
                    map[i,k] = rnd.Next(0,2);
                    if (goalX == i && goalY == k) {
                        Console.Write("X");
                    } else if (startX == i && startY == k) {
                        Console.Write("Y");
                    } else {
                        Console.Write("{0}", map[i, k]);
                    }
                }
                Console.Write("\n");
            }
            Console.Read();
        }
    }

    class Node {
        public int X, Y;
        public Node(/*Tomt*/) {
            //hu
            //etiska varden
            X = 0;
            Y = 0;
        }
    }
}