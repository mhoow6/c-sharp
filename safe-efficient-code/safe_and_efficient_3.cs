using System;
using System.Collections.Generic;
using System.Text;

/**********************
 * 가능하면 큰 구조체에 ref readonly return문 사용
 * 1. return으로 구조체가 아닌 참조만 복사됨
 * 2. ref readonly로 반환 시 더 큰 구조체 복사본을 저정하고
 * 내부 데이터 멤버의 불변성을 유지할 수 있음
 **********************/

namespace Self_Study
{
    public struct Point3
    {
        private float x;
        private float y;
        private float z;
        private static Point3 origin = new Point3(0, 0, 0);

        // 구조체는 생성자 선언시 반드시 모든 필드를 초기화시켜야 함
        public Point3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // 변동될 수 있는 참조를 반환하는 것은 매우 위험하다.
        // public ref Point3 Origin => ref origin;

        // Origin을 호출하는 호출자가 원점을 수정하지 않도록 ref readonly로 값을 반환
        public static ref readonly Point3 Origin => ref origin;
    }

    class safe_and_efficient_3
    {
        static void Main(string[] args)
        {
            // Origin의 복사본을 만들어서 point3에 저장
            Point3 originValue = Point3.Origin;

            // Origin의 참조를 할당
            // 참조를 수정할 수 없도록 readonly
            ref readonly Point3 originRef = ref Point3.Origin;

            Console.WriteLine(originValue);
            Console.WriteLine(originRef);
            
        }
    }
}
