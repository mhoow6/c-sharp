using System;
using System.Collections.Generic;
using System.Text;

/********************************
 * virtual 키워드
 * 파생 클래스에서 재정의하도록 허용하는데 사용하는 키워드
 ********************************/

namespace Lesson_2
{
    class gasang
    {
        public class Shape
        {
            public const double PI = Math.PI;
            protected double x, y;

            public Shape()
            {
            }

            public Shape(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            // virtual 키워드 사용시
            // 상속받은 자식 클래스들이 따로 구현해야 해야 된다
            public virtual double Area()
            {
                return x * y;
            }
        }

        public class Circle : Shape
        {
            // base 키워드는 파생 클래스 내에서 기본 클래스 멤버에 액세스하는데 사용
            public Circle(double r) : base(r, 0)
            {
            }

            // virtual -> override
            public override double Area()
            {
                return PI * x * x;
            }
        }

        class Sphere : Shape
        {
            public Sphere(double r) : base(r, 0)
            {
            }

            public override double Area()
            {
                return 4 * PI * x * x;
            }
        }

        class Cylinder : Shape
        {
            public Cylinder(double r, double h) : base(r, h)
            {
            }

            public override double Area()
            {
                return 2 * PI * x * x + 2 * PI * x * y;
            }
        }

        static void Main()
        {
            double r = 3.0, h = 5.0;
            Shape c = new Circle(r);
            Shape s = new Sphere(r);
            Shape l = new Cylinder(r, h);
            // Display results.
            Console.WriteLine("Area of Circle   = {0:F2}", c.Area());
            Console.WriteLine("Area of Sphere   = {0:F2}", s.Area());
            Console.WriteLine("Area of Cylinder = {0:F2}", l.Area());
        }
    }
