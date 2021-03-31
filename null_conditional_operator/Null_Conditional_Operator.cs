using System;
using System.Collections.Generic;
using System.Linq;

/*****************************
 * Null 조건부 연산자
 * ? 앞에 있는 객체가 NULL인지 체크해서 NULL이면 그냥 NULL을 리턴하고, 그렇지 않으면 ? 다음의 속성이나 메서드를 실행
 * 피연산자가 null이 아니면 액세스
 * 그렇지 않으면 null 반환
 * 단락 연산자
 * ex) A?.B?.Do(C) 에서 A가 null이면 B는 평가 안 됨
 *****************************/


namespace Lesson_2
{
    class Null_Conditional_Operator
    {
        static void Main(string[] args)
        {
            double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
            {
                // A ?? B -> A가 null이면 B 반환
                return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
            }

            var sum1 = SumNumbers(null, 0);
            Console.WriteLine(sum1);  // output: NaN

            var numberSets = new List<double[]>
            {
                new[] { 1.0, 2.0, 3.0 },
                null
            };

            //
            var sum2 = SumNumbers(numberSets, 0);
            Console.WriteLine(sum2);  // output: 6

            var sum3 = SumNumbers(numberSets, 1);
            Console.WriteLine(sum3);  // output: NaN
        }
    }
}
