using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ResourceManager�� ������Ʈ������ �����ϴ� ������ ��ü Ŭ�����̴�.
public class ResourceManager : SingleTon<ResourceManager>
{
    public void LoadMap(string mapname)
    {
        Debug.Log(mapname + "�ε�");
    }
}
