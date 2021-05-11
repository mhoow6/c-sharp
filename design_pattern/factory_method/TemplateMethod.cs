using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ���ø� �޼ҵ� ����
 * �˰����� ������ �޼ҵ忡 �����ϰ�, �˰��� ������ �������
 * �˰����� ������ �ϴ� ����
 * �˰����� �ܰ躰�� ������ ���ų�, ���� ������ �ϴ� �޼ҵ�������
 * ���������� �ٸ����·� ����� �ʿ��� ��� ������ ����
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
        concrete.templateMethod(); // templateMethod ���� ��ü ���� �Ұ�
    }
}
