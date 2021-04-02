using System;
using System.Collections.Generic;
using System.Text;

/***************************
 * ref
 * 참조로 전달되는 값을 나타내는 키워드
 * 초기화를 하고 전달한다.
 * 참조(주소)로 전달하는거지, 참조 형식으로 값을 넘기는 건 아니기 때문에 boxing은 일어나지 않음
 * 
 * out
 * ref와 사용용도 동일
 * 초기화를 안 하고 전달 가능
 ***************************/

namespace Self_Study
{
    class ref_1
    {
        static void SampleMethod(ref int refArgument)
        {
            refArgument = refArgument + 44;
        }

        // ref와 out 오버로드 불가능
        static void SampleMethod2(out int refArgument)
        {
            refArgument = 44;
        }
        static void Main(string[] args)
        {
            int number = 1;
            SampleMethod(ref number); // number의 주소 전달
            Console.WriteLine(number); // Output: 45

            int number2;
            // Console.WriteLine(number2); number2가 할당되지않아 사용 불가
            SampleMethod2(out number2);
            Console.WriteLine(number2);
        }
    }
}
