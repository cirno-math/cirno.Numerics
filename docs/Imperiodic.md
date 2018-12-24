# Imperiodic

cirno.Numerics는 [Imperiodic Number](/cirno.Numerics/ImperiodicNumber.cs) 라는 자료형을 구현하고 이를 매우 기본적인 수를 표현하는 자료형으로 사용한다. 이 자료형은 **순환소수가 아닌 유리수** 이며 생성될 때 순환소수가 아닌 유리수임을 검증한다. 물론 연산을 할 때에도 순환소수가 아닌 유리수가 확실한지 검증하며, 최종적으로 `AsDecimal` 함수를 통해 정수부 / 소수부의 유리수 형태로 사용될 수 있게 한다.

헷갈리기 쉽지만, Imperiodic Number 는 이 프레임워크를 사용할때 유저가 직접 사용하는 자료형이 아니다. 내부에서 데이터를 저장하는데 사용하는 자료형이며, 그래서 연산자 오버로딩과 같은 유저 친화적 인터페이스는 굳이 추가하지 않는다.

## Closed Operation

Imperiodic Number 자료형은 덧셈, 뺄셈, 곱셈에 대해 닫혀있지만 나눗셈에 대해 닫혀있지 않다. 닫혀있지 않은 꼴은 [`INumberValue`](/cirno.Numerics/Inners/NumberValue) 자료형을 통해 나타내어 질 것이며 연산은 미뤄진다. 닫혀있지 않은 연산은 `Try..` 패턴으로 나타내어 지며 이는 연산때마다 검증을 하여 자료형이 언제나 Imperiodic 함을 유지할 수 있게 한다.
