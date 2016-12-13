using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace S_tiger_Finnare
{
    class Map
    {
        public int size;

        public Node start;
        public Node end;

        Node[,] map;

        public List<Node> open = new List<Node>();
        public List<Node> closed = new List<Node>();

        public Map(int size)
        {
            this.size = size;
            map = new Node[size, size];
        }

        public Map(int size, Node start, Node end)
        {
            /* Skapar en map, och felhanterar om man skulle skicka in en start
             * och end node som är utanför mappens kordinater
            */
            this.size = size;
            map = new Node[size, size];
            if (start.x >= size || start.y >= size || end.x >= size || end.y >= size) return;
            this.start = start;
            this.end = end;
        }

        public void searchBreadth()
        {
            closed.Add(start);
        }


        public void generateMap()
        {
            // Skapar en slumpmässig map
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    int value = rnd.Next(0, 2);
                    if (value == 1) map[i, k] = new Node(i,k, true, '.');   // Skapar en node som är walkable
                    else map[i, k] = new Node(i, k, false, '#');            // Skapar en node som INTE är walkable 
                }
            }

            generateStartEnd();
        }

        private void generateStartEnd()
        {
            // Om det INTE finns ett start och end, skapa dem
            if (start == null && end == null)
            {
                Random rnd = new Random();
                start = new Node(rnd.Next(size), rnd.Next(size), true, 'x');
                end = new Node(rnd.Next(size), rnd.Next(size), true, 'y');
            }

            // Tilldele start och end till map
            map[start.x, start.y] = start;
            map[end.y, end.y] = end;
        }

        public void printMap()
        {
            // Printar varje node i mappen
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    Console.Write("{0}", map[i, k].ToString());
                }
                Console.Write("\n");
            }
        }

    }
}
