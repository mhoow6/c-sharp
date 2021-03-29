using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    // Actor 클래스를 상속받음
    public class Player : Actor
    {
        public string move()
        {
            return "플레이어는 움직입니다.";
        }
    }
}
