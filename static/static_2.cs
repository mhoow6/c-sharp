using System;
using System.Collections.Generic;
using System.Text;

/**********************
 * static 멤버
 * 생성된 클래스 인스턴스 개수에 관계 없이 정적 멤버는 한 개만 존재
 * 전체 클래스를 static으로 선언하는 것보다 일부 정적 멤버가 포함된
 * 비정적 클래스를 선언하는 것이 일반적
 * 
 * 정적 필드의 두 가지 일반적인 사용은 인스턴스화된 개체 개수를 유지하거나
 * 모든 인스턴스 간에 공유해야 하는 값을 저장하는 것
 **********************/


namespace Self_Study
{
    public class Automobile
    {
        public static int NumberOfWheels = 4;

        public static int SizeOfGasTank
        {
            get
            {
                return 15;
            }
        }

        public static void Drive() { }

        public int engineVer { get; set; }
    }
    class static_2
    {
       static void Main(string[] args)
        {
            Automobile auto = new Automobile();

            auto.engineVer = 12;
            Console.WriteLine($"{auto.engineVer}");

            Automobile.NumberOfWheels = 2; // static 필드는 인스턴스로 액세스 못함
            Console.WriteLine($"{Automobile.NumberOfWheels}");
        }

       
    }
}
