# cirno.Numerics

수 체계 라이브러리

유리수에 대해서 확실한 결과값을 보장하고 무리수 연산은 유리수가 되기 전까지 lazy 하게 계산, 그 전까지는 값을 트리로 저장하는 수 자료구조를 구현하는 것이 가장 중요한 목표

```csharp
var pi = ConstNumbers.pi;
var e = ConstNumbers.e;
var i = Number.parse("i");

var euler = e.Pow(pi * i);
Assert.Equals(new Numbers(-1), euler.Eval());
```

```csharp
var bigNum = Number.parse("43243151995...verylong");
var sqrt3 = bigNum.Sqrt3();
var bigNumAgain = sqrt3 * sqrt3 * sqrt3;
Assert.Equals(bigNum, bigNumAgain.Eval());
```

