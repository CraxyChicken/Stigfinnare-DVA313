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


                // Höger
                if (pointer.x < size - 1)
                {
                    if (!closed.Contains(map[pointer.x + 1, pointer.y]) && !open.Contains(map[pointer.x + 1, pointer.y]) && map[pointer.x + 1, pointer.y].walkable)
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
                    if (!closed.Contains(map[pointer.x - 1, pointer.y]) && !open.Contains(map[pointer.x - 1, pointer.y]) && map[pointer.x - 1, pointer.y].walkable)
                    {
                        open.Add(map[pointer.x - 1, pointer.y]);
                        open[open.Count() - 1].parent = pointer;
                        open[open.Count() - 1].herustic = open[open.Count() - 1].getDistance(end);
                        open[open.Count() - 1].visited = true;
                    }
                }
                // Över
                if (pointer.y < size - 1)
                {
                    if (!closed.Contains(map[pointer.x, pointer.y + 1]) && !open.Contains(map[pointer.x, pointer.y + 1]) && map[pointer.x, pointer.y + 1].walkable)
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
                    if (!closed.Contains(map[pointer.x, pointer.y - 1]) && !open.Contains(map[pointer.x, pointer.y - 1]) && map[pointer.x, pointer.y - 1].walkable)
                    {
                        open.Add(map[pointer.x, pointer.y - 1]);
                        open[open.Count() - 1].parent = pointer;
                        open[open.Count() - 1].herustic = open[open.Count() - 1].getDistance(end);
                        open[open.Count() - 1].visited = true;
                    }
                }

                closed.Add(pointer);
                open.Remove(pointer);

                if (closed.Contains(end))
                    break;
            }


        }

        public void searchAStar()
        {
            open.Add(start);
            open[0].herustic = open[0].getDistanceAndDistance(end, start);
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


                // Höger
                if (pointer.x < size - 1)
                {
                    if (!closed.Contains(map[pointer.x + 1, pointer.y]) && !open.Contains(map[pointer.x + 1, pointer.y]) && map[pointer.x + 1, pointer.y].walkable)
                    {
                        open.Add(map[pointer.x + 1, pointer.y]);
                        open[open.Count() - 1].parent = pointer;
                        open[open.Count() - 1].herustic = open[open.Count() - 1].getDistanceAndDistance(end, start);
                        open[open.Count() - 1].visited = true;
                    }
                }
                // Vänster
                if (pointer.x >= 1)
                {
                    if (!closed.Contains(map[pointer.x - 1, pointer.y]) && !open.Contains(map[pointer.x - 1, pointer.y]) && map[pointer.x - 1, pointer.y].walkable)
                    {
                        open.Add(map[pointer.x - 1, pointer.y]);
                        open[open.Count() - 1].parent = pointer;
                        open[open.Count() - 1].herustic = open[open.Count() - 1].getDistanceAndDistance(end, start);
                        open[open.Count() - 1].visited = true;
                    }
                }
                // Över
                if (pointer.y < size - 1)
                {
                    if (!closed.Contains(map[pointer.x, pointer.y + 1]) && !open.Contains(map[pointer.x, pointer.y + 1]) && map[pointer.x, pointer.y + 1].walkable)
                    {
                        open.Add(map[pointer.x, pointer.y + 1]);
                        open[open.Count() - 1].parent = pointer;
                        open[open.Count() - 1].herustic = open[open.Count() - 1].getDistanceAndDistance(end, start);
                        open[open.Count() - 1].visited = true;
                    }
                }
                // Under
                if (pointer.y >= 1)
                {
                    if (!closed.Contains(map[pointer.x, pointer.y - 1]) && !open.Contains(map[pointer.x, pointer.y - 1]) && map[pointer.x, pointer.y - 1].walkable)
                    {
                        open.Add(map[pointer.x, pointer.y - 1]);
                        open[open.Count() - 1].parent = pointer;
                        open[open.Count() - 1].herustic = open[open.Count() - 1].getDistanceAndDistance(end, start);
                        open[open.Count() - 1].visited = true;
                    }
                }

                closed.Add(pointer);
                open.Remove(pointer);

                if (closed.Contains(end))
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

            /* Rad 1 och 2
            for (int i = 0; i < 15; i++)
                map[i, 0] = new Node(i, 0, true, '.');
            for (int i = 0; i < 15; i++)
                map[i, 1] = new Node(i, 1, true, '.');
            // Rad 3
            for (int i = 0; i < 5; i++)
                map[i, 2] = new Node(i, 2, true, '.');
            for (int i = 5; i < 13; i++)
                map[i, 2] = new Node(i, 2, false, '#');
            map[13, 2] = new Node(13, 2, true, '.'); map[14, 2] = new Node(14, 2, true, '.');
            // Rad 4 till 12
            for (int k = 3; k < 12; k++) {
                for (int i = 0; i < 13; i++) {
                    if (i < 12 || i > 12)
                        map[i, k] = new Node(i, k, true, '.');
                    else
                        map[i, k] = new Node(i, k, false, '#');
                }
                map[13, k] = new Node(13, k, true, '.'); map[14, k] = new Node(14, k, true, '.');
            }
            // Rad 13
            for (int i = 0; i < 2; i++)
                map[i, 12] = new Node(i, 12, true, '.');
            for (int i = 2; i < 13; i++)
                map[i, 12] = new Node(i, 12, false, '#');
            map[13, 12] = new Node(13, 12, true, '.'); map[14, 12] = new Node(14, 12, true, '.');
            // Rad 14 och 15
            for (int i = 0; i < 15; i++)
                map[i, 13] = new Node(i, 13, true, '.');
            for (int i = 0; i < 15; i++)
                map[i, 14] = new Node(i, 14, true, '.');
                

            //

            start = new Node(0, 12, true, 'x');
            end = new Node(14, 1, true, 'y');

            map[0, 12] = start;
            map[14, 1] = end;*/

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

        public int getPathLength()
        {
            int pathLength = 0;
            Node pointer = end;
            while (pointer.parent != null)
            {
                if (pointer == start)
                    break;
                pathLength++;
                pointer = pointer.parent;
            }
            return pathLength;
        }

        public int getSearchedNodes()
        {
            return closed.Count();
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

        public void reset()
        {
            open.Clear();
            closed.Clear();
        }
    }
}
