# 제네릭 <T>

형식 매개변수
형식을 매개변수처럼 넘겨줌

```cs
interface IGenericInterface<T> {
    T Add(T num);
    T Sub(T num);
    T Mul(T num);
    T Div(T num);
}
```

사용 시 T에 형식을 기입
