using System;
using System.Collections.Generic;
using System.Text;

/***********************************
 * const 키워드
 * 컴파일 타입의 상수
 * 내장자료형 (정수형, 실수형, Enum, String)에 대해서만 사용가능
 * 변수 선언과 동시에 값을 할당
 * 메모리 할당 위치는 Stack Memory
 * 변경될 수 있는 값에 const 쓰는거 아님
 ***********************************/


namespace atentscsharp
{
    class SampleClass
    {
        public int x;
        public int y;
        public const int C1 = 5;
        public const int C2 =  C1 + 5;
        public SampleClass(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
    class const_1
    {
        static void Main(string[] args)
        {
            var mC = new SampleClass(11, 22);
            Console.WriteLine($"x = {mC.x}, y = {mC.y}"); // 11, 22
            Console.WriteLine($"C1 = {SampleClass.C1}, y = {SampleClass.C2}"); // 5, 10
        }
    }
}
