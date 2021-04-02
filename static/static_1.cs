using System;
using System.Collections.Generic;
using System.Text;

/***************************************
 * static
 * 이 키워드가 붙어 있는 클래스, 함수, 변수는 프로그램이 시작할 때
 * stack 메모리에 등록을 함 -> 인스턴스 호출하지 않아도 사용가능
 * 
 * 
 * static 클래스
 * 정적 클래스는 입력 매개변수에 대해서만 작동하고
 * 내부 인스턴스 필드를 가져오거나 설정할 필요가 없는
 * 메서드 집합에 대한 편리한 컨테이너로 사용할 수 있음
 * 특정 인스턴스에 고유한 데이터를 저장하거나 검색할 필요 없이 기능을 수행하는 용도
 ***************************************/

namespace Self_Study
{
    class static_1
    {
        static void main(string[] args)
        {
            double dub = -3.14;

            // Math 클래스는 정적 클래스라서 
            // 인스턴스화 한 객체가 없음에도 사용가능 
            Console.WriteLine(Math.Abs(dub));
            Console.WriteLine(Math.Floor(dub));
            Console.WriteLine(Math.Round(Math.Abs(dub)));
        }
    }
}
