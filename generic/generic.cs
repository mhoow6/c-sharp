// using System;

// namespace Test {
//     class TestGenericClass<T> {
//         public TestGenericClass(T value) {
//             Value = value;
//         }
        
//         public T Value { get; set; }
//     }
//     class Program {
//         public static void Main() {
            
//             // Int32, String 그리고 Boolean 형식을 가진 제네릭 클래스 선언
//             TestGenericClass<Int32>        intClass    = new TestGenericClass<Int32>(12345);
//             TestGenericClass<String>    stringClass    = new TestGenericClass<String>("12345");
//             TestGenericClass<Boolean>    boolClass    = new TestGenericClass<Boolean>(true);
            
//             // 각 클래스의 이름과 값을 출력해본다.
//             Console.WriteLine("클래스의 이름:");
//             Console.WriteLine("\tIntClass   : {0}", intClass.GetType());
//             Console.WriteLine("\tStringClass: {0}", stringClass.GetType());
//             Console.WriteLine("\tBoolClass  : {0}\n", boolClass.GetType());
            
//             Console.WriteLine("Value 속성의 반환 값:");
//             Console.WriteLine("\tIntClass   : {0} (형식: {1})", intClass.Value, intClass.Value.GetType());
//             Console.WriteLine("\tStringClass: {0} (형식: {1})", stringClass.Value, stringClass.Value.GetType());
//             Console.WriteLine("\tBoolClass  : {0} (형식: {1})", boolClass.Value, boolClass.Value.GetType());
            
//             Console.ReadKey(true);
//         }
//     }
// }