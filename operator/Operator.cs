using System;
using System.Linq;
using System.Collections.Generic;

namespace Lesson_2
{
    class Operator
    {
        static void Main(string[] args)
        {
            // 보간된 문자열 식
            var r = 2.3;
            var message = $"The area of a circle with radius {r} is {Math.PI * r * r:F3}.";
            Console.WriteLine(message);

            // 람다식 (익명함수)
            int[] numbers = { 2, 3, 4, 5 };
            var maximumSquare = numbers.Max(x => x * x);
            Console.WriteLine(maximumSquare);

            // 쿼리식
            var scores = new[] { 90, 97, 78, 68, 85 };
            IEnumerable<int> highScoresQuery =
                from score in scores
                where score > 80
                orderby score descending
                select score;
            Console.WriteLine(string.Join(" ", highScoresQuery));
        }
    }
}
