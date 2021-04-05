using System;
using System.Collections.Generic;
using System.Text;

/***************
 * in 한정자를 System.IntPtr.Size보다 큰 readonly struct 매개변수에 적용
 * 
 * IntPtr.Size = 32비트 프로세서에서 4, 64비트 프로세서에서 8
 * in 키워드는 인수를 참조로 전달하도록 지정하지만 호출된 메서드는 값을 수정하지 않음
 * 설계 의도를 표현하기 위한 용도
 * ref,out,in 한정자는 변수가 참조로 전달되도록 지정하여 복사를 방지함. 각 한정자는 다른 의도가 있음
 *      ref: 매개 변수로 사용되는 인수의 값을 설정할 수 있음
 *      out: 인수의 값을 초기화해서 보내지 않아도 됨. 메서드 안에서 반드시 설정하고 리턴해줘야 함
 *      in: 인수의 값을 수정할 수 없음
 * IntPtr.Size보다 큰 읽기 전용 값 형식들에 대한 성능을 향상시킴.
 ***************/

namespace Self_Study
{
    public struct Point3D
    {
        private static Point3D origin = new Point3D(0, 0, 0);

        public static ref readonly Point3D Origin => ref origin;
        public Point3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        private double _x;
        public double X
        {
            readonly get => _x;
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
    class safe_and_efficient_4
    {
        private static double CalculateDistance(in Point3D point1, in Point3D point2)
        {
            // 각 인수에 CPU 아키텍처에 따라 4byte or 8byte 참조를 보냄
            double xDiffer = point1.X - point2.X;
            double yDiffer = point1.Y - point2.Y;
            double zDiffer = point1.Z - point2.Z;

            return Math.Sqrt(xDiffer * xDiffer + yDiffer * yDiffer + zDiffer * zDiffer);
        }
    }
}
