using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Figure
    {
        public abstract List<Point> Rotate(int i);
        public abstract List<Point> getFigure();
    }
    public struct Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class TheT : Figure
    {
        int rotation = 0;

        public override List<Point> getFigure()
        {
            List<Point> points = new List<Point>();
            switch (rotation)
            {
                case 0:
                    points.Add(new Point(0,1));
                    points.Add(new Point(1,0));
                    points.Add(new Point(1,1));
                    points.Add(new Point(2,1));
                    break;
                case 1:
                    points.Add(new Point(1,0));
                    points.Add(new Point(1,1));
                    points.Add(new Point(1,2));
                    points.Add(new Point(2,1));
                    break;
                case 2:
                    points.Add(new Point(0,0));
                    points.Add(new Point(1,0));
                    points.Add(new Point(2,0));
                    points.Add(new Point(1,1));
                    break;
                case 3:
                    points.Add(new Point(0,1));
                    points.Add(new Point(1,0));
                    points.Add(new Point(1,1));
                    points.Add(new Point(1,2));
                    break;
            }
            return points;
        }
        public override List<Point> Rotate(int i)
        {
            rotation += i;
            if (rotation > 3) rotation = 0;
            return getFigure();
        }
    }
    public class TheSquare : Figure
    {
        public override List<Point> getFigure()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(0,0));
            points.Add(new Point(0,1));
            points.Add(new Point(1,0));
            points.Add(new Point(1,1));
            return points;
        }

        public override List<Point> Rotate(int i)
        {
            return getFigure();
        }
    }
}
