using System;
using System.Runtime.InteropServices; // Marshal
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 6. 단일 스택 프레임의 블록 또는 메모리를 작업하기 위해 ref struct 형식을 사용합니다.
 * -> Span<T> 자료구조 사용
 * 
 * 
 * 6-1. Span<T> 구조체
 * 인접한 임의의 메모리 영역에 대한 형식 및 안전 표현 제공
 * 관리형 힙이 아닌 스택에 할당되는 ref 구조체
 * 스택 전용 형식이므로 힙에서 버퍼에 대한 참조를 저장해야하는 시나리오에는 적합하지 않음
 * 
 * 6-2. ref 구조체
 * ref 구조체 형식의 인스턴스는 스택에 할당되며 관리형 힙으로 escape할 수 없다.
 * 
 * 6-2-1. 컴파일러가 ref 구조체에게 주는 제한사항
 * 1) 배열의 요소에 포함시킬수 없음
 * 2) ref 구조체는 클래스의 필드일 수 없음
 * 3) ref 구조체는 인터페이스를 구현할 수 없음. 그냥 구조체도 안 됨
 * 4) ref 구조체는 boxing 할 수 없다
 * 5) ref 구조체는 형식 인수일 수 없다.
 *      매개변수로 ref a 안 된다는 뜻
 * 6) 람다식 또는 로컬 함수에서 ref 구조체 변수를 캡처할 수 없다.
 *      클로져안에 ref 구조체 변수를 사용할 수 없다는 뜻
 * 7) async 메서드에서는 ref 구조체를 사용할 수 없다.
 * 
 * 6-3. Marshal 클래스 
 * 관리되지 않은 메모리를 할당하고, 복사하는 등 비관리코드와 상호작용할 때 사용
 */

namespace ConsoleAppSpan
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 1. Span<T> 기본 사용 예제 */
            var array = new byte[100];
            var arraySpan = new Span<byte>(array);

            byte data = 0;
            for (int ctr = 0; ctr < arraySpan.Length; ctr++)
                arraySpan[ctr] = data++;

            int arraySum = 0;
            foreach (var value in array)
                arraySum += value;

            Console.WriteLine($"The sum is {arraySum}");
            // Output:  The sum is 4950

            /********************************************************************************************/

            /* 2. 네이티브 메모리에서 100byte를 가져오는 예제 */
            // Native Memory는 운영체제에서 애플리케이션 프로세스에 제공하는 메모리를 의미
            // 힙 스토리지 및 기타 용도로 사용됨
            
            var native = Marshal.AllocHGlobal(100); // Create a span from native memory.
            Span<byte> nativeSpan;

            // unsafe: 포인터와 관련된 작업에 사용되는 컨텍스트
            // 프로젝트 - ConsoleAppSpan 설정 - 디버그 - 안전하지 않은 코드 허용
            unsafe
            {
                nativeSpan = new Span<byte>(native.ToPointer(), 100);
            }
            byte data2 = 0;
            for (int ctr = 0; ctr < nativeSpan.Length; ctr++)
                nativeSpan[ctr] = data2++;

            int nativeSum = 0;
            foreach (var value in nativeSpan)
                nativeSum += value;

            Console.WriteLine($"The sum is {nativeSum}");
            Marshal.FreeHGlobal(native);
            // Output:  The sum is 4950

            /********************************************************************************************/

            /* 3.  stackalloc 키워드를 사용하여 스택에서 100 바이트의 메모리를 할당하는 예제 */
            byte data3 = 0;
            Span<byte> stackSpan = stackalloc byte[100];
            for (int ctr = 0; ctr < stackSpan.Length; ctr++)
                stackSpan[ctr] = data3++;

            int stackSum = 0;
            foreach (var value in stackSpan)
                stackSum += value;

            Console.WriteLine($"The sum is {stackSum}");
            // Output:  The sum is 4950

        }
    }
}
