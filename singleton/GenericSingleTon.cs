using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SingleTon Ŭ���� ���� (Genereic���)
// ����ü ����
// ������Ʈ �������� �ϳ��� �ν��Ͻ��� ������ �� �ְ� �Ѵ�.
// where�� T�� ���������� �ǹ��� : class�� ���������̾�� �Ѵ�, new�� �Ű������� ���� �����ڸ� �ǹ�

public class SingleTon<T> where T: class, new()
{
    private static T inst = null;

    public SingleTon()
    {

    }

    public static T instance
    {
        get
        {
            if (inst == null)
                inst = new T();
            return inst;
        }
    }
}
