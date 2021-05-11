using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Type
{

}

public class TypeA : Type
{
    public TypeA()
    {
        Debug.Log("Type A 持失");
    }
}

public class TypeB : Type
{
    public TypeB()
    {
        Debug.Log("Type B 持失");
    }
}

public class TypeC : Type
{
    public TypeC()
    {
        Debug.Log("Type C 持失");
    }
}

public class ClassA
{
    public Type createType(string type)
    {
        Type returnType = null;
        
        switch (type)
        {
            case "A":
                returnType = new TypeA();
                break;

            case "B":
                returnType = new TypeB();
                break;

            case "C":
                returnType = new TypeC();
                break;

        }

        return returnType;
    }
}

public class FactoryMethod2 : MonoBehaviour
{
    private void Start()
    {
        ClassA classA = new ClassA();
        classA.createType("A");
        classA.createType("C");
    }
}
