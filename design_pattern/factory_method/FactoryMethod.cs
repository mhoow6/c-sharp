using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ���丮 �޼��� ����
 * �θ� Ŭ������ �˷����� ���� ��ü Ŭ������ �����ϴ� ����
 * �ڽ� Ŭ������ � ��ü�� �������� �����ϵ��� �ϴ� ����
 * �б⿡ ���� ��ü�� ������ �������� �ʰ�, ���丮��� Ŭ������ �����Ͽ�
 * ���丮 Ŭ������ ��ü�� �����ϵ��� �ϴ� ���
 * ����� ��������� �θ� Ŭ������ Ȯ������ ����
 * ��� ���踦 �����ϰ� �Ǹ� ���α׷��� ��Ʈ���ǰ� ������ �� ������ ����
 * 
 * 1. ��ü(����, Concrete) Ŭ����
 * new Ű���带 ����Ͽ� �ν��Ͻ��� ����� Ŭ������ ���� Ŭ����
 * Ŭ���� ���� ��� �޼ҵ尡 ��� ������ �Ǿ��־����.
 * 
 * 2. demical
 * ���� �Ҽ��� ���
 * �ε��Ҽ��� ����� ���� �޸𸮰����� ū �Ҽ��� ���尡�������� ��Ȯ���� ��������
 * �����Ҽ��� ����� ���� �ӵ��� ������ ��Ȯ���� ������ ū ���� �����Ҷ� �޸𸮸� ���� ������
 */

public abstract class Pizza
{
    public abstract decimal GetPrice();

    public enum PizzaType
    {
        HamMushroom, Deluxe, Seafood
    }

    public static Pizza PizzaFactory(PizzaType pizzaType)
    {
        switch (pizzaType)
        {
            case PizzaType.HamMushroom:
                return new HamAndMushroomPizza(); // �˷����� ���� ��ü Ŭ���� ����

            case PizzaType.Deluxe:
                return new DeluxePizza(); // �˷����� ���� ��ü Ŭ���� ����

            case PizzaType.Seafood:
                return new SeafoodPizza(); // �˷����� ���� ��ü Ŭ���� ����
        }

        throw new System.NotSupportedException("The pizza type " + pizzaType.ToString() + " is not recognized.");
    }
}

public class HamAndMushroomPizza : Pizza
{
    private decimal price = 8.5M;
    public override decimal GetPrice() { return price; }
}

public class DeluxePizza : Pizza
{
    private decimal price = 10.5M;
    public override decimal GetPrice() { return price; }
}

public class SeafoodPizza : Pizza
{
    private decimal price = 11.5M;
    public override decimal GetPrice() { return price; }
}

public class FactoryMethod : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(Pizza.PizzaFactory(Pizza.PizzaType.Seafood).GetPrice());
    }
}
