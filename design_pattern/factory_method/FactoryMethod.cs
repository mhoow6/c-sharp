using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 팩토리 메서드 패턴
 * 부모 클래스에 알려지지 않은 구체 클래스를 생성하는 패턴
 * 자식 클래스가 어떤 객체를 생성할지 결정하도록 하는 패턴
 * 분기에 따른 객체의 생성을 직접하지 않고, 팩토리라는 클래스에 위임하여
 * 팩토리 클래스가 객체를 생성하도록 하는 방식
 * 상속을 사용하지만 부모 클래스를 확장하지 않음
 * 상속 관계를 남발하게 되면 프로그램의 엔트로피가 높아질 수 있으니 주의
 * 
 * 1. 구체(구상, Concrete) 클래스
 * new 키워드를 사용하여 인스턴스를 만드는 클래스를 구상 클래스
 * 클래스 내에 모든 메소드가 모두 구현이 되어있어야함.
 * 
 * 2. demical
 * 고정 소수점 방식
 * 부동소수점 방식은 작은 메모리공간에 큰 소수를 저장가능하지만 정확성이 떨어지고
 * 고정소수점 방식은 연산 속도가 빠르고 정확성이 높지만 큰 수를 저장할때 메모리를 많이 차지함
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
                return new HamAndMushroomPizza(); // 알려지지 않은 구체 클래스 생성

            case PizzaType.Deluxe:
                return new DeluxePizza(); // 알려지지 않은 구체 클래스 생성

            case PizzaType.Seafood:
                return new SeafoodPizza(); // 알려지지 않은 구체 클래스 생성
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
