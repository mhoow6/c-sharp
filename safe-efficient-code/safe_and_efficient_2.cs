using System;
using System.Collections.Generic;
using System.Text;

/*******************
 * 구조체를 변경할 수 없는 경우 readonly 멤버 선언
 * 장점
 * 1. 해당 멤버는 구조체의 상태를 변경할 수 없음
 * 2. 컴파일러에서 readonly 멤버에 액세스할 때 in 매개변수의 방어형 복사본을 만들지 않음
 *******************/

namespace Self_Study
{
    // 구조체가 가변성을 지원해야될 경우
    public struct Point3D
    {
        public Point3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        private double _x;
        public double X
        {
            readonly get => _x; // 수정하지 않아야 되는 멤버만 readonly
            set => _x = value;
        }

        private double _y;
        public double Y
        {
            readonly get => _y;
            set => _y = value;
        }

        private double _z;
        public double Z
        {
            readonly get => _z;
            set => _z = value;
        }

        public readonly double Distance => Math.Sqrt(X * X + Y * Y + Z * Z);
        public readonly override string ToString() => $"{X}, {Y}, {Z}";
    }


    class safe_and_efficient_2
    {
    }
}
