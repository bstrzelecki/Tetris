using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Physics
    {
        public static List<Point> ToWorldPosition(List<Point> obj, Point pos){
            List<Point> temp = new List<Point>();

            foreach(Point point in obj)
            {
                temp.Add(new Point(point.x + pos.x, point.y + pos.y));
            }
            return temp;
        }

        public static bool CheckCollisions(Point a, Point b)
        {
            if (a.x == b.x && a.y == b.y) return true;
            return false;
        }
        public static bool CheckCollisions(List<Point> points, Point b)
        {
            foreach (Point point in points)
            {
                if (CheckCollisions(point, b)) return true;
            }
            return false;
        }
        public static bool CheckCollisions(Point a, int b)
        {
            if (a.x == b) return true;
            return false;
        }
        public static bool CheckCollisions(List<Point> points, int b)
        {
            foreach (Point point in points)
            {
                if(CheckCollisions(point, b))return true;
            }
            return false;
        }
    }
}
