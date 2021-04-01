using System;
using System.Collections.Generic;
using System.Text;

/*************************************************
 * abstract 한정자
 * 누락되거나 불완전한 구현이 있음을 알리는 키워드
 * 자체에서 인스턴스화되는게 아닌 파생 클래스에서 구현
 * 파생 클래스가 추상(abstract) 클래스이면 안 됨
 * abstract은 virtual과 다르게 자식 클래스에서 반드시 구현
 * ***********************************************/

namespace Self_Study
{
    abstract class Shape
    {
        public abstract int GetArea();
    }

    class Square : Shape
    {
        int side;

        public Square(int n) => side = n;

        // 반드시 구현해야 함
        public override int GetArea()
        {
            return side * side;
        }
    }

    class abstract_1
    {  
        static void Main(string[] args)
        {
            // 추상 클래스는 인스턴스화 불가
            /*Shape shape = new Shape();*/

            Square square = new Square(4);
            Console.WriteLine($"넓이: {square.GetArea()}");
        }
    }
}
