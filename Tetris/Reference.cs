using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Reference
    {    
        public static List<Point> getStartMap(int sizeX, int sizeY)
        {
            List<Point> map = new List<Point>();
            for(int i = 0; i < sizeX; i++)
            {
                map.Add(new Point(i, sizeY));
            }
            return map;
        }
     
    }
}
