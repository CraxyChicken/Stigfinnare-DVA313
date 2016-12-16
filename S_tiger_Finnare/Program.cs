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
            Console.Write("Stigfinnaren\n");

            //Node start = new Node(0, 0, true, 'x');
            //Node end = new Node(1, 1, true, 'y');

            Map map = new Map(6);
            map.generateMap();
            

            map.searchGreedy();

            map.printMap();
            Console.Read();
        }
    }

}