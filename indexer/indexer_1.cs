using System;
using System.Collections.Generic;
using System.Text;

/**************************************
 * 인덱서 (indexer)
 * 클라이언트 애플리케이션이 class, struct, interface가 배열처럼 액세스하게끔 만들어주는 구문
 * 내부 컬렉션 또는 배열을 캡슐화하는데 주로 사용되는 형식
 **************************************/

namespace Self_Study
{
    public class TempRecord
    {
        float[] temps = new float[10]
        {
            56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
            61.7F, 65.9F, 62.1F, 59.2F, 57.5F
        };

        public int Length => temps.Length;

        // 클라이언트가 TempRecord 인스턴스 온도에
        // 인덱서를 이용하여 접근하게 함
        public float this[int index]
        {
            get => temps[index];
            set => temps[index] = value;
        }

    }
    class indexer_1
    {
        static void Main()
        {
            var tempRecord = new TempRecord();

            tempRecord[3] = 58.3F;

            for(int i = 0; i < tempRecord.Length; i++)
            {
                Console.WriteLine($"Element #{i} = {tempRecord[i]}");
            }
        }
    }
}
