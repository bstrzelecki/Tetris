using System;
using System.Collections.Generic;

namespace Tetris
{
    public abstract class Figure
    {
        public abstract List<Point> Rotate(int i);
        public abstract List<Point> getFigure();
        public static Figure getRandomFigure()
        {
            Random rng = new Random();
            switch (rng.Next(7)){
                case 0:
                    return new TheT();
                case 1:
                    return new TheSquare();
                case 2:
                    return new TheStick();
                case 3:
                    return new TheDogLeft();
                case 4:
                    return new TheDogRight();
                case 5:
                    return new TheLLeft();
                case 6:
                    return new TheLRight();
            }
            return new TheT();
        }
    }
    public struct Point
    {
        public int x;
        public int y;
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
            if (rotation < 0) rotation = 3;
            return getFigure();
        }
    }
    public class TheLLeft : Figure
    {
        protected int rotation = 0;
        public override List<Point> getFigure()
        {
            List<Point> points = new List<Point>();
            switch (rotation)
            {
                case 0:
                    points.Add(new Point(0, 2));
                    points.Add(new Point(1, 0));
                    points.Add(new Point(1, 1));
                    points.Add(new Point(1, 2));
                    break;
                case 1:
                    points.Add(new Point(0, 0));
                    points.Add(new Point(0, 1));
                    points.Add(new Point(1, 1));
                    points.Add(new Point(2, 1));
                    break;
                case 2:
                    points.Add(new Point(0, 0));
                    points.Add(new Point(0, 1));
                    points.Add(new Point(0, 2));
                    points.Add(new Point(1, 0));
                    break;
                case 3:
                    points.Add(new Point(0, 0));
                    points.Add(new Point(1, 0));
                    points.Add(new Point(2, 0));
                    points.Add(new Point(2, 1));
                    break;
            }
            return points;
        }
        public override List<Point> Rotate(int i)
        {
            rotation += i;
            if (rotation > 3) rotation = 0;
            if (rotation < 0) rotation = 3;
            return getFigure();
        }
    }
    public class TheLRight : Figure
    {
        protected int rotation = 0;
        public override List<Point> getFigure()
        {
            List<Point> points = new List<Point>();
            switch (rotation)
            {
                case 0:
                    points.Add(new Point(0, 0));
                    points.Add(new Point(0, 1));
                    points.Add(new Point(0, 2));
                    points.Add(new Point(1, 2));
                    break;
                case 1:
                    points.Add(new Point(0, 0));
                    points.Add(new Point(1, 0));
                    points.Add(new Point(2, 0));
                    points.Add(new Point(0, 1));
                    break;
                case 2:
                    points.Add(new Point(0, 0));
                    points.Add(new Point(1, 0));
                    points.Add(new Point(1, 1));
                    points.Add(new Point(1, 2));
                    break;
                case 3:
                    points.Add(new Point(0, 1));
                    points.Add(new Point(1, 1));
                    points.Add(new Point(2, 0));
                    points.Add(new Point(2, 1));
                    break;
            }
            return points;
        }
        public override List<Point> Rotate(int i)
        {
            rotation += i;
            if (rotation > 3) rotation = 0;
            if (rotation < 0) rotation = 3;
            return getFigure();
        }
    }
    public class TheStick : Figure
    {
        protected int rotation = 0;
        public override List<Point> getFigure()
        {
            List<Point> points = new List<Point>();
            switch (rotation)
            {
                case 0:
                    points.Add(new Point(0,0));
                    points.Add(new Point(0,1));
                    points.Add(new Point(0,2));
                    points.Add(new Point(0,3));
                    break;
                case 1:
                    points.Add(new Point(0,0));
                    points.Add(new Point(1,0));
                    points.Add(new Point(2,0));
                    points.Add(new Point(3,0));
                    break;
            }
            return points;
        }

        public override List<Point> Rotate(int i)
        {
            rotation+=i;
            if (rotation > 1) rotation = 0;
            if (rotation < 0) rotation = 1;
            return getFigure();
        }
    }
    public class TheDogLeft : Figure
    {
        protected int rotation = 0;
        public override List<Point> getFigure()
        {
            List<Point> points = new List<Point>();
            switch (rotation)
            {
                case 0:
                    points.Add(new Point(0,0));
                    points.Add(new Point(1,0));
                    points.Add(new Point(1,1));
                    points.Add(new Point(2,1));

                    break;
                case 1:
                    points.Add(new Point(2,0));
                    points.Add(new Point(1,1));
                    points.Add(new Point(2,1));
                    points.Add(new Point(1,2));

                    break;
            }
            return points;
        }

        public override List<Point> Rotate(int i)
        {
            rotation += i;
            if (rotation > 1) rotation = 0;
            if (rotation < 0) rotation = 1;
            return getFigure();
        }
    }
    public class TheDogRight : Figure
    {
        protected int rotation = 0;
        public override List<Point> getFigure()
        {
            List<Point> points = new List<Point>();
            switch (rotation)
            {
                case 0:
                    points.Add(new Point(2, 0));
                    points.Add(new Point(1, 0));
                    points.Add(new Point(1, 1));
                    points.Add(new Point(0, 1));

                    break;
                case 1:
                    points.Add(new Point(0, 0));
                    points.Add(new Point(1, 1));
                    points.Add(new Point(0, 1));
                    points.Add(new Point(1, 2));

                    break;
            }
            return points;
        }

        public override List<Point> Rotate(int i)
        {
            rotation += i;
            if (rotation > 1) rotation = 0;
            if (rotation < 0) rotation = 1;
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
