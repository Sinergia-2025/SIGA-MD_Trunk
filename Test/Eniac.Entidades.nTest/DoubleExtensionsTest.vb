Imports Eniac.Entidades.Extensiones
Imports NUnit.Framework

Namespace Eniac.Entidades.nTest

   Public Class DoubleExtensionsTest

      <SetUp>
      Public Sub Setup()
      End Sub

      <TestCase(100, 100)>
      <TestCase(101, 100)>
      <TestCase(102, 100)>
      <TestCase(103, 100)>
      <TestCase(104, 100)>
      <TestCase(105, 110)>
      <TestCase(106, 110)>
      <TestCase(107, 110)>
      <TestCase(108, 110)>
      <TestCase(109, 110)>
      <TestCase(110, 110)>
      <TestCase(111, 110)>
      <TestCase(112, 110)>
      <TestCase(113, 110)>
      <TestCase(114, 110)>
      <TestCase(115, 120)>
      <TestCase(116, 120)>
      <TestCase(117, 120)>
      <TestCase(118, 120)>
      <TestCase(119, 120)>
      <TestCase(120, 120)>
      Public Sub MidRound_1_0_10_Round_Success(valorARedondear As Decimal, valorEsperado As Decimal)
         Dim result = valorARedondear.MidRound(1, 0, 10, MidRoundBehaviour.Round)

         Assert.AreEqual(valorEsperado, result)
      End Sub
      <TestCase(100, 100)>
      <TestCase(101, 110)>
      <TestCase(102, 110)>
      <TestCase(103, 110)>
      <TestCase(104, 110)>
      <TestCase(105, 110)>
      <TestCase(106, 110)>
      <TestCase(107, 110)>
      <TestCase(108, 110)>
      <TestCase(109, 110)>
      <TestCase(110, 110)>
      <TestCase(111, 120)>
      <TestCase(112, 120)>
      <TestCase(113, 120)>
      <TestCase(114, 120)>
      <TestCase(115, 120)>
      <TestCase(116, 120)>
      <TestCase(117, 120)>
      <TestCase(118, 120)>
      <TestCase(119, 120)>
      <TestCase(120, 120)>
      Public Sub MidRound_1_0_10_Ceiling_Success(valorARedondear As Decimal, valorEsperado As Decimal)
         Dim result = valorARedondear.MidRound(1, 0, 10, MidRoundBehaviour.Ceiling)

         Assert.AreEqual(valorEsperado, result)
      End Sub
      <TestCase(100, 100)>
      <TestCase(101, 100)>
      <TestCase(102, 100)>
      <TestCase(103, 100)>
      <TestCase(104, 100)>
      <TestCase(105, 100)>
      <TestCase(106, 100)>
      <TestCase(107, 100)>
      <TestCase(108, 100)>
      <TestCase(109, 100)>
      <TestCase(110, 110)>
      <TestCase(111, 110)>
      <TestCase(112, 110)>
      <TestCase(113, 110)>
      <TestCase(114, 110)>
      <TestCase(115, 110)>
      <TestCase(116, 110)>
      <TestCase(117, 110)>
      <TestCase(118, 110)>
      <TestCase(119, 110)>
      <TestCase(120, 120)>
      Public Sub MidRound_1_0_10_Floor_Success(valorARedondear As Decimal, valorEsperado As Decimal)
         Dim result = valorARedondear.MidRound(1, 0, 10, MidRoundBehaviour.Floor)

         Assert.AreEqual(valorEsperado, result)
      End Sub

   End Class

End Namespace