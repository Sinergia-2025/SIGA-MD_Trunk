Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class PruebaCalculoIDAutomationHL25S
   Private Const datoPrueba = "044714797793220013103350002803355006203400005120084114"
   Private Const datoPrueba2 = "044711234567813041501490801601510151801614801234567890"
   Private Const datoResultado = "04471479779322001310335000280335500620340000512008411400"
   Private Const datoResultado2 = "04471123456781304150149080160151015180161480123456789088"

   <TestMethod()> Public Sub PruebaLecturaExitosa()
      Dim codigoString As String = datoPrueba

      Dim codigoBarraDocumento As String = New Reglas.Ayudante.DigitosVerificadores.IDAutomationHL25().Calcular(codigoString)

      Assert.AreEqual(datoResultado, codigoBarraDocumento)
   End Sub

   <TestMethod()> Public Sub PruebaLecturaErroneo()
      Dim codigoString As String = datoPrueba2

      Dim codigoBarraDocumento As String = New Reglas.Ayudante.DigitosVerificadores.IDAutomationHL25().Calcular(codigoString)

      Assert.AreNotEqual(datoResultado, codigoBarraDocumento)
   End Sub

   <TestMethod()> Public Sub PruebaLecturaExitosa2()
      Dim codigoString As String = datoPrueba2

      Dim codigoBarraDocumento As String = New Reglas.Ayudante.DigitosVerificadores.IDAutomationHL25().Calcular(codigoString)

      Assert.AreEqual(datoResultado2, codigoBarraDocumento)
   End Sub

   <TestMethod()> Public Sub PruebaLecturaErroneo2()
      Dim codigoString As String = datoPrueba

      Dim codigoBarraDocumento As String = New Reglas.Ayudante.DigitosVerificadores.IDAutomationHL25().Calcular(codigoString)

      Assert.AreNotEqual(datoResultado2, codigoBarraDocumento)
   End Sub

End Class