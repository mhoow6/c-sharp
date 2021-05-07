using System;
using System.Collections;

/* IEnumerator (이뉴머레이터)
 * 제네릭이 아닌 컬렉션을 단순하게 반복할 수 있도록 지원하는 인터페이스
 */

public class Person
{
    public Person(string fName, string lName)
    {
        this.firstName = fName;
        this.lastName = lName;
    }

    public string firstName;
    public string lastName;
}

// Person 객체의 컬렉션
// 이 클래스는 열거가능(IEnumerable)하게 만들어져
// ForEach 구문에 사용할 수 있도록 한다.
public class People : IEnumerable
{
    private Person[] _people;
    public People(Person[] pArray)
    {
        _people = new Person[pArray.Length];

        for (int i = 0; i < pArray.Length; i++)
        {
            _people[i] = pArray[i];
        }
    }

    // 컬렉션을 반복하는 열거자 반환
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public PeopleEnum GetEnumerator()
    {
        return new PeopleEnum(_people);
    }
}

// IEnumerable을 구현할 경우 , IEnumerator 또한 구현해야함.
public class PeopleEnum : IEnumerator
{
    public Person[] _people;

    // MoveNext() 호출이 있을 때까지 열거자는 첫 번째 요소 앞에 위치한다
    int position = -1;

    public PeopleEnum(Person[] list)
    {
        _people = list;
    }

    // 열거자를 컬렉션의 다음 요소로 이동
    public bool MoveNext()
    {
        position++;
        return (position < _people.Length);
    }

    // 컬렉션의 첫 번째 요소 앞의 초기 위치에 열거자를 설정
    public void Reset()
    {
        position = -1;
    }

    // 컬렉션에서 열거자의 현재 위치에 있는 요소를 가져옴
    // MoveNext 또는 Reset이 호출될 때까지 동일한 개체를 반환
    public Person Current
    {
        get
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }
}

class IEnumeratorExample
{
    static void Main()
    {
        Person[] peopleArray = new Person[3]
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };

        People peopleList = new People(peopleArray);
        foreach (Person p in peopleList)
            Console.WriteLine(p.firstName + " " + p.lastName);
    }
}

