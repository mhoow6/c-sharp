using System;
using System.Collections.Generic;
using System.Text;

/************************
 * 박싱과 언박싱
 * 박싱: 값 형식이 참조 형식으로 변환되는 것
 * 
 * 박싱 과정
 * 값 타입을 힙에 생성하기 위해 메모리를 힙 영역에 생성
 * 값을 힙 영역에 할당된 메모리로 복사
 * 참조할 변수에 할당된 메모리 주소를 스택 영역에 할당
 * 
 * 
 * 언박싱: 참조형식을 값형식으로 변환되는 것
 * 
 * 언박싱 과정
 * 박싱값인지 확인
 * 박싱된 값이라면 값 타입 변수에 데이터를 복사
 * 박싱한 메모리와 언박싱한 메모리가 2개씩이나 존재하게 됨
 * 
 ************************/

namespace Self_Study
{
    class boxing_unboxing
    {
        static void Main(string[] args)
        {
            int i = 93;

            // 박싱
            // 스택에 있는 데이터가 힙으로 복사됨
            object s = i; 
            Console.WriteLine(s);

            // 언박싱
            // 힙에 있는 데이터가 스택으로 복사됨
            int j = (int)s;

        }
    }
}
