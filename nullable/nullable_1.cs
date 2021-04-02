using System;
using System.Collections.Generic;
using System.Text;

/*********************************
 * Nullable
 * 값 타입 변수에 null을 대입하게 해줌
 * T? 변수이름 = null;
 *********************************/

namespace Self_Study
{
    class nullable_1
    {
        static void Main(string[] args)
        {
            int a = 41;
            object aBoxed = a;
            int? aNullable = (int?)aBoxed; // boxing 발생
            Console.WriteLine($"Value of aNullable: {aNullable}");

            int?[] arr = new int?[10];

            foreach (int? element in arr)
            {
                Console.WriteLine($"what is in element?: {element}");
            }
        }
    }
}
