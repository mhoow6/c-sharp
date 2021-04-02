using System;
using System.Collections.Generic;
using System.Text;

/*******************************
 * interface
 * 계약을 정의함
 * 해당 계약을 구현하는 class or struct는 인터페이스에 정의된 구성원의 구현을 제공해야함
 *******************************/


namespace Self_Study
{
    interface ISampleInterface
    {
        void SampleMethod();
    }

    class ImplementationClass : ISampleInterface
    {
        public void SampleMethod()
        {
            Console.WriteLine("Implementation completed.");
        }
    }

    class interface_1
    {
        static void Main()
        {
            // Declare an interface instance.
            ISampleInterface obj = new ImplementationClass();

            // Call the member.
            obj.SampleMethod();
        }
    }
}
