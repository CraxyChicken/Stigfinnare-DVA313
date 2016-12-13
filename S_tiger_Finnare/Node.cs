using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_tiger_Finnare
{
    class Node
    {
        public int x, y;
        public int herustic, moveCost, total;
        public bool walkable;
        public char graphic;

        // Vi måste veta vilken node vi kommer ifrån, och detta görs genom en parent node
        public Node parent;

        public Node()
        {
            x = 0;
            y = 0;
            herustic = 0;
            moveCost = 1;
        }
        public Node(int x, int y, bool walkable, char graphic)
        {
            if(x < 0) this.x = 0; else this.x = x;
            if(y < 0) this.y = 0; else this.y = y;
            this.walkable = walkable;
            this.graphic = graphic;
        }

        public int getHeurestic(Node end)
        {
            // Heurestic kommer användas i A*
            // Den här heuristiska metoden heter Manhattan och är den vanligaste
            return Math.Abs(end.x - this.x) + Math.Abs(end.y - this.y);
        }

        public int getTotalCost()
        {
            /* Eftersom att heuristic alltid är noll i breath first
             * så kommer vi bara att räkna på vad det kostar att förflytta sig
             * vertikalt och horisentalt;
             * 
             * I vårat fall 0 + 1
            */
            return herustic + moveCost;
        }

        public override string ToString()
        {
            return graphic.ToString();
        }
    }
}
