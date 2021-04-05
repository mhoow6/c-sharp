using System;
using System.Collections.Generic;
using System.Text;

/*****************************************
 * https://docs.microsoft.com/ko-kr/dotnet/csharp/write-safe-efficient-code
 * 주의! 소스코드가 C# 7.2에 추가된 기능을 사용함
 * 
 * 효율적인 리소스 관리를 위한 기술에 중점을 둠
 * 값 형식을 사용할 경우 힙 할당을 할 필요가 없다는 장점이 있지만 단점으로 값으로만 복사된다는 점임.
 * C# 7.2 새로운 언어 기능은 값 형식에 대한 참조를 사용하여
 * 안전하고 효율적인 코드를 가능하게 하는 매커니즘을 제공
 *****************************************/

namespace Self_Study
{
    // readonly 한정자를 사용하여 struct를 선언하여
    // 컴파일러에게 변경할 수 없는 형식이라고 알림
    // 구조체 디자인 의도가 변경할 수 없는 값 형식을 만들 때 사용
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

    }


    class safe_and_efficient_1
    {
    }
}
