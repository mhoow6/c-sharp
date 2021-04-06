using System;
using System.Collections.Generic;
using System.Text;
using SafeEfficientCode;

/*
 * 변경 가능한 구조체를 in 인수로 사용하지 마세요
 * 
 * 1. in으로 매개변수를 받는 경우, in 한정자는 인수를 읽기 전용으로 만들어버리기 때문에 컴파일러는 방어 복사본을 만듬
 * 컴파일러는 readonly 한정자를 사용하여 표시되지 않은 모든 멤버를 호출하기 전에 인수의 임시 복사본을 만들어야 함
 * 
 * 2. 임시 스토리지(임시 메모리, 임시 복사본)을 스택에서 만들어지고, 인수 값이 임시 스토리지에 복사되며 
 * 값이 this 인수로 각 멤버 액세스에 대한 스택으로 복사됨
 * 
 * 방어형 복사본 만드는 과정 정리:
 * in 매개변수 메모리 -> readonly 메모리가 스택에 생성(방어형 복사본) ->
 * readonly 메모리에 값 복사 -> 각 멤버의 메모리 스택에 방어형 복사본의 값을 복사
 * 
 * 3. 인수형식이 readonly struct가 아니고, 메서드 또한 readonly 가 아닌 멤버를 호출하는 경우
 * 값으로 전달하는 방식이 참조로 전달하는 방식보다 빠른 정도로 성능을 저하시킴.
 */

namespace Self_Study
{
    class safe_and_efficient_5
    {
        #region CalculateDistance
        private static double CalculateDistance(in Point3D point1, in Point3D point2)
        {
            
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
        }
        #endregion

        #region CalculateDistanceReadonly
        private static double CalculateDistance3(in ReadonlyPoint3D point1, in ReadonlyPoint3D point2 = default)
        {
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
        }
        #endregion
    }
}
