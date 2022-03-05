using System.Collections.Generic;

namespace Tetris
{
    class Physics
    {
        public static List<Point> getArea(int x1, int y1, int x2 , int y2)
        {
            List<Point> map = new List<Point>();

            for(int x = x1; x < x2; x++)
            {
                for(int y = y1; y < y2; y++)
                {
                    map.Add(new Point(x, y));
                }
            }

            return map;
        }
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
        public static bool CheckCollisions(List<Point> a, List<Point> b)
        {
            foreach(Point point in a)
            {
                foreach(Point p in b)
                {
                    if (CheckCollisions(point, p)) return true;
                }
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
