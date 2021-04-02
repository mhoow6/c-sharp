using System;
using System.Collections.Generic;
using System.Text;

namespace Self_Study
{
    class Point3D
    {
        // 인스턴스 상관없이 유일하다
        public static string desc = "3차원에서의 점";

        // get, set 프로퍼티가 없으면 접근 불가
        private double x;
        private double y;
        private double z;

        // x,y값을 바꾸고 싶으면 인스턴스를 만든 후,
        // X와 Y를 통해서 바꾸어야 한다.
        public double X {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get => y;

            set
            {
                y = value;
            }
        }

        public double Z
        {
            get
            {
                return z;
            }
        }

    }

    class get_set
    {
        static void Main(string[] args)
        {
            Point3D p = new Point3D();

            p.X = 4;
            p.Y = 3;
            Console.WriteLine("p의 x좌표: {0}", p.X);
            Console.WriteLine("p의 y좌표: {0}", p.Y);

            // p.Z = 3; // Z은 읽기전용이므로 쓰기불가
            Console.WriteLine("p의 z좌표: {0}", p.Z);

            Console.WriteLine("Point3D는 무엇을 나타낼까요? {0}", Point3D.desc);
        }
    }
}
