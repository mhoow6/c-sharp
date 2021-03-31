using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_2
{
    class derija_chain
    {
        delegate void PDelegate(int a, int b); // 대리자 선언
        static void Plus(int a, int b) { Console.WriteLine("{0} + {1} = {2}", a, b, a + b); }
        static void Minus(int a, int b) { Console.WriteLine("{0} - {1} = {2}", a, b, a - b); }
        static void Div(int a, int b) { Console.WriteLine("{0} / {1} = {2}", a, b, a / b); }
        static void Mul(int a, int b) { Console.WriteLine("{0} * {1} = {2}", a, b, a * b); }
        
        static void Main(string[] args)
        {
            // Delegate.Combine 을 이용하여 대리자 호출 목록 연결
            PDelegate pd = (PDelegate)Delegate.Combine(new PDelegate(Plus), new PDelegate(Minus), new PDelegate(Div), new PDelegate(Mul));

            pd(20, 10);
        }
    }
}
