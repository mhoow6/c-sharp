using System;

/*
 * 클로져
 * 함수 안의 함수를 로컬함수라 부름
 * 무명메서드나 람다식을 정의하고 있는 메서드의 로컬변수(int key)를 사용하고 있을 때
 * 이러한 무명메서드나 람다식을 Closure라고 부름
 */

namespace ConsoleAppClosure
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = 10;
            
            // delegate is Closure
            Action<string> print = delegate (string msg) {
                string str = key + msg;
                Console.WriteLine(str);
            };

            print("A");
        }
    }
}
