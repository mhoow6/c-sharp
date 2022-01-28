#region 튜플 (System.ValueTuple) 설명
/* 
 * 1. C# 7.0 이상에서 사용가능 
 * 2. 여러 데이터 요소를 그룹화하는 구문
 * 3. System.Tuple과 다르게 값 형식이고, 데이터 멤버는 필드이다.
 */
#endregion

// -------------------------------------------------------------------

/* 1. 기본적인 사용예시 */
(int, byte) tuple1 = (1, 0b01);
Console.WriteLine($"이 튜플은 {tuple1.Item1}와 {tuple1.Item2}로 이루어져 있습니다.");

// -------------------------------------------------------------------

/* 2. 튜플은 일반적으로 메서드 반환을 복수 개의 값으로 하고 싶을때 쓴다 */
// 튜플 필드에 이름을 새길 수 있다.
(int min, int max) FindMinMax(int[] input)
{
    int min = int.MaxValue;
    int max = int.MinValue;

    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] < min)
            min = input[i];

        if (input[i] > max)
            max = input[i];
    }

    return (min, max);
}

int[] exampleNumbers = new int[] { 1, 2, 3, };
var result = FindMinMax(exampleNumbers);
Console.WriteLine($"최소값: {result.min}, {result.max}");

// -------------------------------------------------------------------

/* 3. 튜플을 할당 및 분해시킬 수 있다. */
var ex1 = ("내 집", 10);
var (destination, distance) = ex1;
//(string destination, double distance) = ex1;
Console.WriteLine($"{destination}까지 {distance}km가 걸립니다.");