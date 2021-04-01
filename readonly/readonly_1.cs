using System;
using System.Collections.Generic;
using System.Text;

/*****************************
 * readonly
 * 런타임 상수
 * exe 또는 dll을 사용할 때 변수의 값을 가져온다
 * 모든 자료형에 사용가능하며, 생성과 동시에 초기화할 필요는 없음
 * 단 생성자 단계에서 1번의 할당을 통해 초기화
 * 메모리 할당 위치는 Heap Memory
 ******************************/

namespace atentscsharp
{
    public class SamplePoint
    {
        public int x;
        // Initialize a readonly field
        public readonly int y = 25;
        public readonly int z;

        // readonly는 선언부 또는 생성자에서만 초기화 가능
        public SamplePoint()
        {
            // Initialize a readonly instance field
            z = 24;
        }

        public SamplePoint(int p1, int p2, int p3)
        {
            x = p1;
            y = p2;
            z = p3;
        }
    }

        class readonly_1
    {
        static void Main(string[] args)
        {
            SamplePoint p1 = new SamplePoint(11, 21, 32);
            Console.WriteLine($"p1: x = {p1.x}, y = {p1.y}, z = {p1.z}"); // 11, 21, 32
            SamplePoint p2 = new SamplePoint();
            p2.x = 55; // public이라서 OK
            Console.WriteLine($"p2: x = {p2.x}, y = {p2.y}, z = {p2.z}"); // 55, 25, 24
        }
    }
}
