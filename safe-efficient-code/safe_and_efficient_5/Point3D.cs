using System;

namespace SafeEfficientCode
{
    public struct Point3D
    {
        public double X;
        public double Y;
        public double Z;

        #region OriginReference
        private static Point3D origin = new Point3D();
        public static ref readonly Point3D Origin => ref origin;
        #endregion
    }

    // readonly struct를 선언하여 형식이 변경 불가능임을 표현
    // 이를 통해 컴파일러는 in 매개 변수를 사용할 때 방어형 복사본을 저장할 수 있음
    #region ReadonlyOnlyPoint3D
    readonly public struct ReadonlyPoint3D
    {
        public ReadonlyPoint3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        // 형식을 변경할 수 없는 멤버를 readonly로 선언하여 상태가 변하지 않음을 알림
        private static readonly ReadonlyPoint3D origin = new ReadonlyPoint3D();

        // 반환값이 IntPtr.Size보다 크므로 ref 키워드를 사용하여 참조를 전달하게 함
        // readonly 키워드를 붙여 Origin이 origin(원점)을 수정할 수 없도록 함
        public static ref readonly ReadonlyPoint3D Origin => ref origin;
    }
    #endregion
}
