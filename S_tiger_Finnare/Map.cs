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


        public void searchGreedy()
        {
            open.Add(start);
            open[0].herustic = open[0].getDistance(end);
            open[0].visited = true;

            while (open.Count > 0)
            {
                // Hitta det lägsta distansen till end noden
                int lowestH = Int32.MaxValue;
                Node pointer = null;
                
                for (int i = 0; i < open.Count(); i++)
                {
                    if (open[i].herustic < lowestH)
                    {
                        pointer = open[i];
                        lowestH = open[i].herustic;
                    }
                }


                // Över
                if (pointer.y  < size - 1)
                {
                    if (!closed.Contains(map[pointer.x, pointer.y + 1]) && map[pointer.x, pointer.y + 1].walkable)
                    {
                        open.Add(map[pointer.x, pointer.y + 1]);
                        open[open.Count() - 1].parent = pointer;
                        open[open.Count() - 1].herustic = open[open.Count() - 1].getDistance(end);
                        open[open.Count() - 1].visited = true;
                    }
                }
                // Under
                if (pointer.y >= 1)
                {
                    if (!closed.Contains(map[pointer.x, pointer.y - 1]) && map[pointer.x, pointer.y - 1].walkable)
                    {
                        open.Add(map[pointer.x, pointer.y - 1]);
                        open[open.Count() - 1].parent = pointer;
                        open[open.Count() - 1].herustic = open[open.Count() - 1].getDistance(end);
                        open[open.Count() - 1].visited = true;
                    }
                }
                // Höger
                if (pointer.x < size - 1)
                {
                    if (!closed.Contains(map[pointer.x + 1, pointer.y]) && map[pointer.x + 1, pointer.y].walkable)
                    {
                        open.Add(map[pointer.x + 1, pointer.y]);
                        open[open.Count() - 1].parent = pointer;
                        open[open.Count() - 1].herustic = open[open.Count() - 1].getDistance(end);
                        open[open.Count() - 1].visited = true;
                    }
                }
                // Vänster
                if (pointer.x >= 1)
                {
                    if (!closed.Contains(map[pointer.x - 1, pointer.y]) && map[pointer.x - 1, pointer.y].walkable)
                    {
                        open.Add(map[pointer.x - 1, pointer.y]);
                        open[open.Count() - 1].parent = pointer;
                        open[open.Count() - 1].herustic = open[open.Count() - 1].getDistance(end);
                        open[open.Count() - 1].visited = true;
                    }
                }

                closed.Add(pointer);
                open.Remove(pointer);
                

                foreach (Node n in open)
                {
                    if (n.herustic == 0)
                        break;
                }


                if(closed.Contains(end)) 
                    break;
            }


        }


        public void generateMap()
        {
            // Skapar en slumpmässig map
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    int value = rnd.Next(0, 3);
                    if (value <= 1) map[k, i] = new Node(k,i, true, '.');   // Skapar en node som är walkable
                    else map[k, i] = new Node(k, i, false, '#');            // Skapar en node som INTE är walkable 
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
            map[end.x, end.y] = end;
        }


        public bool findPath(Node n)
        {
            Node pointer = end;
            while (pointer.parent != null)
            {
                if (pointer == n)
                    return true;
                pointer = pointer.parent;
            }
            return false;
        }

        public void printMap()
        {
            
            // Printar varje node i mappen
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (map[k, i].visited)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (findPath(map[k, i]))
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write("{0}", map[k, i].ToString());
                    
                    Console.ResetColor();
                }
                Console.Write("\n");
            }
        }

    }
}
