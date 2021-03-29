using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class Program
    {
        public static void Main()
        {
            /* 그룹형 변수 */
            int[] monsterlevel = new int[3];

            // 리스트
            // 기능이 추가된 가변형 그룹형 변수
            // <> 안에 Type을 추가 
            List<string> items = new List<string>();

            // 아이템 추가
            items.Add("생명물약30");
            items.Add("마나물약30");

            // 콘솔 출력
            Console.WriteLine("가지고 있는 아이템");
            Console.WriteLine(items[0]);
            Console.WriteLine(items[1]);

            // 아이템 삭제
            items.RemoveAt(0);

            // 콘솔 출력
            Console.WriteLine("가지고 있는 아이템");
            Console.WriteLine(items[0]);
            // Console.WriteLine(items[1]); // 인덱스 범위 벗어남


            /* 연산자 */
            int health = 100;
            int mana = 25;
            bool isBadCondition = health <= 50 || mana <= 20;
            string condition = isBadCondition ? "나쁨" : "좋음";

            // 콘솔 출력
            Console.WriteLine("지금 나의 컨디션: {0}", condition);


            /* For Each */
            string[] monsters = { "고블린", "해골", "좀비" };
            foreach (string monster in monsters)
            {
                Console.WriteLine("이 지역에 있는 몬스터: " + monster);
            }


            /* 클래스 */

            // 인스턴스화
            // 정의된 클래스를 변수 초기화로 실체화
            Player player = new Player();
            player.id = 0;
            player.name = "마법사";
            player.title = "현명한";
            player.strength = 2.4f;
            player.weapon = "나무 지팡이";

            Console.WriteLine(player.talk());
            Console.WriteLine(player.HasWeapon());

            player.LevelUp();
            Console.WriteLine(player.name + "의 레벨은 " + player.level + " 입니다.");

            Console.WriteLine(player.move());

        }
    }
}
