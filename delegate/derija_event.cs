using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_2
{
    // 대리자 선언
    public delegate void MyEventHandler(string message);
    class Publisher
    {
        // event 한정자인, MyEventHandler 형 대리자 Active 
        public event MyEventHandler Active;
        public void DoActive(int number)
        {
            if (number % 10 == 0)
                Active("Active!" + number);
            else
                Console.WriteLine(number);
        }
    }
    class Subscriber
    {
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();

            // addEventListener('active', () => MyHandler);
            publisher.Active += new MyEventHandler(MyHandler);

            for (int i = 1; i < 50; i++)
                publisher.DoActive(i);
        }
    }


}
