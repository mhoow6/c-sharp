using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace VeryFastCode
{
    public class PerformanceTest
    {
        const int DEFAULT_REPTITONS = 1;
        public string Name { get; }
        public string Description { get; }
        public int Iterations { get; set; }
        public bool RunBaseline { get; set; }

        public PerformanceTest()
        {

        }

        public PerformanceTest(string name, string descrptiion, int interactions)
        {
            Name = name;
            Description = descrptiion;
            Iterations = interactions;
        }
        
        /// <summary>
        /// 느린 코드
        /// </summary>
        /// <returns></returns>
        protected virtual bool MeasureTestA()
        {
            return false;
        }

        /// <summary>
        /// 빠른 코드
        /// </summary>
        /// <returns></returns>
        protected virtual bool MeasureTestB()
        {
            return false;
        }

        /// <summary>
        /// 빠른 코드
        /// </summary>
        /// <returns></returns>
        protected virtual bool MeasureTestC()
        {
            return false;
        }

        public virtual void Progress() { }

        /// <summary>
        /// 퍼포먼스 테스트
        /// </summary>
        /// <returns></returns>
        public (int, int, int) Measure()
        {
            long totalA = 0, totalB = 0, totalC = 0;

            var stopWatch = new Stopwatch();

            // 기본 코드테스트 (방법 A)
            if (RunBaseline)
            {
                for (long i = 0; i < DEFAULT_REPTITONS; i++)
                {
                    stopWatch.Restart();
                    var implemented = MeasureTestA();
                    stopWatch.Stop();
                    if (implemented)
                        totalA += stopWatch.ElapsedMilliseconds;
                }
            }

            // 최적화된 코드테스트 (방법 B)
            for (long i = 0; i < DEFAULT_REPTITONS; i++)
            {
                stopWatch.Restart();
                var implemented = MeasureTestB();
                stopWatch.Stop();
                if (implemented)
                    totalB += stopWatch.ElapsedMilliseconds;
            }

            // 최적화된 코드테스트 (방법 C)
            for (long i = 0; i < DEFAULT_REPTITONS; i++)
            {
                stopWatch.Restart();
                var implemented = MeasureTestC();
                stopWatch.Stop();
                if (implemented)
                    totalC += stopWatch.ElapsedMilliseconds;
            }

            return (
                (int)(totalA / DEFAULT_REPTITONS),
                (int)(totalB / DEFAULT_REPTITONS),
                (int)(totalC / DEFAULT_REPTITONS)
                );
        }
    }

    /// <summary>
    /// 아주 많은 데이터가 파싱이 안되어 Exception을 발생시키지 않는 이상, Parse보다 TryParse의 성능이 훨씬 좋다.
    /// </summary>
    public class ExceptionTest : PerformanceTest
    {
        // 상수들
        const int DEFAULT_ITERATIONS = 100;
        const int LIST_SIZE = 1000;
        const int NUMBER_SIZE = 5;

        // 멤버 변수들
        // 마지막에 'X'를 넣어 파싱이 불가능하게 한다.
        char[] digitArray = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'X' };
        List<string> numbers = new List<string>();

        public ExceptionTest() : base("Exceptions", "A:Parse, B:TryParse", DEFAULT_ITERATIONS)
        {
            Random rnd = new Random();
            for (int i = 0; i < LIST_SIZE; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < NUMBER_SIZE; j++)
                {
                    // digitArray.Length 안에서의 랜덤 인덱스 추출
                    int index = rnd.Next(digitArray.Length);
                    sb.Append(digitArray[index]);
                }
                numbers.Add(sb.ToString());
            }
        }

        public override void Progress()
        {
            Console.Write($"How many iterations? ({Iterations}) ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Iterations = number;
            }

            Console.WriteLine($"Running '{Description}' with {Iterations}...");
            var result = Measure();
            Console.WriteLine($"A: {result.Item1}ms, B: {result.Item2}ms");
            Console.WriteLine("-----------------------------------------");
        }

        protected override bool MeasureTestA()
        {
            // 무지성 파싱
            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < LIST_SIZE; j++)
                {
                    try
                    {
                        // 'X'를 파싱할려고 시도할때 exception
                        int.Parse(numbers[j]);
                    }
                    catch (FormatException)
                    {

                    }
                }
            }
            return true;
        }

        protected override bool MeasureTestB()
        {
            // Parse 대신 TryParse이용
            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < LIST_SIZE; j++)
                {
                    var success = int.TryParse(numbers[j], out _);
                }
            }
            return true;
        }

        protected override bool MeasureTestC()
        {
            return base.MeasureTestA();
        }
    }
}
