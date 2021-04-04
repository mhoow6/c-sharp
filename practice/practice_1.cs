using System;
using System.Collections.Generic;
using System.Text;

namespace Self_Study
{
    /* 추상 클래스 상속 예제 (abstract) */
    public abstract class Behavior
    {
        public abstract void walk();
        public abstract void run();
    }

    /* 추상 클래스 상속 예제 (virtual) */
    public class Information
    {
        public virtual string birthday(int year, int month, int day) => $"{year}-{month}-{day}";
    }

    /* 추상 클래스 상속 예제 (abstract) */
    public class Person : Behavior
    {
        public override void run()
        {
            Console.WriteLine("Run!!");
        }

        public override void walk()
        {
            Console.WriteLine("Walking..");
        }
    }

    /* 추상 클래스 상속 예제 (virtual) */
    public class Human : Information
    {
        // abstract와 다르게 구현 오류 발생 X
    }

    /* get, set 프로퍼티, 생성자 예제 */
    public class Monster
    {
        private ushort mobcode; // 0 ~ 65,535
        private uint hp; // 0 ~ 4,294,967,295
        private string name;
        
        public Monster(ushort mobcode, uint hp)
        {
            this.mobcode = mobcode;
            this.hp = hp;
        }

        public uint HP { get => hp; }

        public ushort MOBCODE
        {
            get { return mobcode; }
        }

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

    }

    /* const, 열거체 예제 */
    public enum TCP_UDP_PORT
    {
        FTP = 20,
        SMTP = 25,
        DNS = 53,
        HTTP = 80,
        DUMMY1,
        DUMMY2
    }

    class practice_1
    {
        /* delegate 예제 */
        delegate int Calculate(int a, int b);
        delegate void Print(int a, int b);

        static int plus(int a, int b) => a + b;
        static int minus(int a, int b) => a - b;
        static void printplus(int a, int b) => Console.WriteLine($"{a} + {b} = {a+b}");
        static void printminus(int a, int b) => Console.WriteLine($"{a} - {b} = {a - b}");

        static void Main(string[] args)
        {
            /* 추상 클래스 상속 예제 */
            Person person = new Person();
            person.run();

            Human human = new Human();
            Console.WriteLine(human.birthday(1997, 06, 13));
            Console.WriteLine("------------------------------------------------------------------------------------------");

            /* 배열 예제 */
            int[] array = new int[5];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
                Console.WriteLine($"array{i}: {array[i]}");
            }
            Console.WriteLine("------------------------------------------------------------------------------------------");

            /* 리스트 예제, foreach 예제 */
            // List<int> errcodes = new List<int>();
            List<int> errcodes = new List<int> { 400, 401, 402, 403 };

            errcodes.Add(404);
            errcodes.RemoveAt(4);

            foreach(int code in errcodes)
            {
                Console.WriteLine("errcodes: {0}", code);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------");

            /* 연산자 예제 */
            byte cloud = 10;
            byte degree = 16;
            bool isSunnyToday = cloud <= 20 && degree > 15;

            Console.WriteLine("Is Sunny Today? {0}", isSunnyToday);
            Console.WriteLine("------------------------------------------------------------------------------------------");

            /* get, set 프로퍼티 예제 */
            Monster monster = new Monster(00001, 100);
            monster.NAME = "Goblin";

            Console.WriteLine("monster's code: {0}\n" +
                "monster's hp: {1}\n" +
                "monster's name: {2}", monster.MOBCODE, monster.HP, monster.NAME);
            Console.WriteLine("------------------------------------------------------------------------------------------");

            /* 언박싱, 박싱 예제 */
            int box = 100;
            object container = box;
            Console.WriteLine($"box's value: {box}, container's value: {container}"); // 박싱

            Console.WriteLine($"So.. box and container are same?? {box == (int)container}"); // 언박싱
            Console.WriteLine("------------------------------------------------------------------------------------------");

            /* const, 열거체 예제 */
            const byte FTP = 20;

            Console.WriteLine("FTP Port: {0}, SMTP Port: {1}", FTP, (int)TCP_UDP_PORT.SMTP);
            Console.WriteLine($"Dummy like.. {(int)TCP_UDP_PORT.DUMMY1}, {(int)TCP_UDP_PORT.DUMMY2}");
            Console.WriteLine("------------------------------------------------------------------------------------------");

            /* delegate 예제 */
            Calculate cal = plus;
            Console.WriteLine("3 + 2 = {0}", cal(3, 2));

            cal = minus;
            Console.WriteLine("3 - 2 = {0}", cal(3, 2));

            Print print = (Print)Delegate.Combine(new Print(printplus), new Print(printminus));
            print(3, 2);
            Console.WriteLine("------------------------------------------------------------------------------------------");

            /* dictionary 예제 */
            Dictionary<string, string> json = new Dictionary<string, string>();

            json.Add("Apple", "사과");
            json.Add("Banana", "바나나");
            json["Cat"] = "고양이";

            foreach (KeyValuePair<string, string> kvp in json)
            {
                Console.WriteLine("What is in json? {0}", kvp);
            }

            /*Dictionary<string, string>.ValueCollection jsonValue = json.Values;*/

            foreach (string value in json.Values)
            {
                Console.WriteLine("Value = {0}", value);
            }

            /*Dictionary<string, string>.KeyCollection jsonValue = json.Keys;*/

            foreach (string key in json.Keys)
            {
                Console.WriteLine("Key = {0}", key);
            }

            if (json.ContainsKey("Cat"))
                json.Remove("Cat");

            foreach (KeyValuePair<string, string> kvp in json)
            {
                Console.WriteLine("What is in json? {0}", kvp);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------");
            /* Generic 예제 */
        }
    }
}
