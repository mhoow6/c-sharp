using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 탬플릿 메소드 패턴
 * 알고리즘의 구조를 메소드에 정의하고, 알고리즘 구조의 변경없이
 * 알고리즘을 재정의 하는 패턴
 * 알고리즘이 단계별로 나뉘어 지거나, 같은 역할을 하는 메소드이지만
 * 여러곳에서 다른형태로 사용이 필요할 경우 유용한 패턴
 * 
 * Reference
 * https://yaboong.github.io/design-pattern/2018/09/27/template-method-pattern/
 */

public abstract class AbstractClass
{
    public void templateMethod()
    {
        hook1();
        hook2();
    }

    protected abstract void hook1();
    protected abstract void hook2();
}

public class ConcreteClass : AbstractClass
{
    #region Override
    protected override void hook1()
    {
        Debug.Log("Abstract hook1 implementation");
    }

    protected override void hook2()
    {
        Debug.Log("Abstract hook2 implementation");
    }
    #endregion

}

public class TemplateMethod : MonoBehaviour
{
    ConcreteClass concrete = new ConcreteClass();

    private void Start()
    {
        concrete.templateMethod(); // templateMethod 구조 자체 변경 불가
    }
}
