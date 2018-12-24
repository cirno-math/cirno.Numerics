# Imperiodic

cirno.Numerics는 [Imperiodic Number](/cirno.Numerics/ImperiodicNumber.cs) 라는 자료형을 구현하고 이를 매우 기본적인 수를 표현하는 자료형으로 사용한다. 이 자료형은 **순환소수가 아닌 유리수** 이며 생성될 때 순환소수가 아닌 유리수임을 검증한다. 물론 연산을 할 때에도 순환소수가 아닌 유리수가 확실한지 검증하며, 최종적으로 `AsDecimal` 함수를 통해 정수부 / 소수부의 유리수 형태로 사용될 수 있게 한다.
