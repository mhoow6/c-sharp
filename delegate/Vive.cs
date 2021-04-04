using System;
using System.Collections.Generic;
using System.Text;

namespace Self_Study
{
    public class HeadMountedDisplay
    {
        // object를 매개변수로 받고, 리턴이 없는 대리자 선언
        public delegate void SignalHandler(object sender);

        // delegate도 Type이므로 SignalHandler 인스턴스 생성
        // event는 "+=" 로 등록, "-="로 제거
        public event SignalHandler signal;

        public void signaltest()
        {
            // 이벤트가 등록되있다면
            if (signal != null)
            {
                // 이벤트 발생
                signal(this);
            }
        }
    }
    
    class Vive
    {
        static void Main(string[] args)
        {
            HeadMountedDisplay vive = new HeadMountedDisplay();

            // 이벤트 등록
            vive.signal += readyforVR;

            // signaltest 함수 내에서 조건이 만족하면 이벤트(signal) 발생
            vive.signaltest(); 
        }

        // 대리자에 등록할 함수
        static void readyforVR(object sender)
        {
            Console.WriteLine("VR connected.");
        }
    }
}
