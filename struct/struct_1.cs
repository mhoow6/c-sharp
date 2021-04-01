using System;
using System.Collections.Generic;
using System.Text;

/******************************
 * 구조체
 * 값 타입
 * 원본 데이터를 변경할 이유가 없는 데이터를 모아두는데 사용
 * 스택 메모리에 저장된다.
 * 유니티의 최적화를 고려한다면 스택메모리를 적극 활용해야 함
 ******************************/

namespace atentscsharp
{
    public struct Coords
    {
        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; } // get만 하면 읽기전용
        public double Y { get; }

        public override string ToString() => $"({X}, {Y})";
    }
    class struct_1
    {
        static void Main(string[] args)
        {
            Coords p = new Coords(3, 4); // 구조체 인스턴스화

            Console.WriteLine($"Current Coordinate: {p.ToString()}");
        }
    }
}
