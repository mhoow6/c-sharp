using System;
using System.Collections;


/* yield
 * 호출자 (Caller)에게 컬렉션 데이터를 하나씩 리턴할 때 사용한다.
 * 
 * Enumerable 클래스에서 GetEnumerator() 메서드를 구현할 때
 * yield return을 사용하여 컬렉선 데이터를 순차적으로 넘겨주는 코드를 구현하여
 * 별도의 Enumerator 클래스를 작성할 필요없이 전달할 수 있다.
 */

public class MyList
{
    private int[] data = { 1, 2, 3, 4, 5 };

    public IEnumerator GetEnumerator()
    {
        int i = 0;
        while (i < data.Length)
        {
            yield return data[i];
            i++;
        }
    }
}


class yieldExample
{
    static void Main(string[] args)
    {
        var list = new MyList();

        // 1. For each를 사용한 Iteration
        foreach (var item in list)
            Console.WriteLine(item);

        // 2. 수동 Iteration
        IEnumerator it = list.GetEnumerator();
        it.MoveNext();
        Console.WriteLine(it.Current);
        it.MoveNext();
        Console.WriteLine(it.Current);
    }
}

