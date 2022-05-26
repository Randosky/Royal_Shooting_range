using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Shooting_range
{
    public class Map
    {
        public Size scale;
        public int[,] map;
        public int Size;
        public Map(int size)
        {
            this.Size = size;
            map = new int[11, 15] {
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
                { 2,2,2,2,2,1,1,1,1,1,1,1,1,1,1 },
            };
        }
    }
}
