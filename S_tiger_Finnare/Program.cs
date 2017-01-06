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
            int pathLengthG = 0;
            int searchedNodesG = 0;

            int pathLengthA = 0;
            int searchedNodesA = 0;

            Console.Write("Stigfinnaren\n");

            Map map = new Map(100);
            for (int i = 0; i < 10000; i++)
            {
                map = new Map(100);
                map.generateMap();

                map.searchGreedy();

                //map.printMap();

                pathLengthG += map.getPathLength();
                searchedNodesG += map.getSearchedNodes();

                Console.Write(i + "\n");

                map.reset();

                map.searchAStar();

                //map.printMap();

                pathLengthA += map.getPathLength();
                searchedNodesA += map.getSearchedNodes();

                map.reset();
            }

            Console.Write("Path length greedy: " + pathLengthG + " Searched nodes: " + searchedNodesG);
            Console.WriteLine(" - Path length Astar: " + pathLengthA + " Searched nodes: " + searchedNodesA);
            
            Console.Read();
            Console.Read();
        }
    }

}