using System;
using System.Collections.Generic;
using System.Text;

namespace Self_Study
{
    interface IPoint
    {
        int X
        {
            get;
            set;
        }

        int Y
        {
            get;
            set;
        }

        double Distance
        {
            get;
        }
    }

    public struct Circle : IPoint
    {
        public Circle(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public double Distance => Math.Sqrt(X * X + Y * Y);
    }

    class interface_2
    {
        static void Main(string[] args)
        {
            IPoint p = new Circle();

            p.X = 2;
            p.Y = 2;

            Console.WriteLine($"Circle's Distance: {p.Distance}");
        }
    }
}
