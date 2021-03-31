using System;

/***************************
 * 델리게이트(Delegate)
 * 대리자
 * 메소드를 참조를 포함할 수 있게 함
 * 대리자 인스턴스를 통해 메서드를 호출
 * 매개변수의 데이터 형식과 반환형의 데이터 형식이 맞아야 사용가능
 ***************************/


namespace Lesson_2
{
    class derija
    {
        // delegate 반환명 델리게이트명(매개변수..)
        delegate int PDelegate(int a, int b);

        static int Plus(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            // 대리자에 Plus 함수 참조하여 대리자를 인스턴스화
            PDelegate pd1 = Plus;

            // 무명함수를 참조하여 대리자를 인스턴스화
            PDelegate pd2 = delegate (int a, int b)
            {
                return a / b;
            };

            Console.WriteLine("pd1의 값: " + pd1(10, 5));
            Console.WriteLine("pd2의 값: " + pd2(10, 5));
        }
    }
}
