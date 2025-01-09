<TestClass()> Public Class ProbarMetodoParaGenerarCodigoDeBarras
   Private Const dpIdentificacionUsuario As Long = 47977932
   Private Const dpIdentificadorConcepto As Integer = 1
   Private dpFechaVenc1 As DateTime = New Date(2020, 1, 31)
   Private Const dpImporteVenc1 As Decimal = 3350.0
   Private dpFechaVenc2 As DateTime = New Date(2020, 2, 28)
   Private Const dpDiasHastaVenc2 As Integer = 28
   Private Const dpImporteVenc2 As Decimal = 3355.0
   Private dpFechaVenc3 As DateTime = New Date(2020, 4, 30)
   Private Const dpDiasHastaVenc3 As Integer = 62
   Private Const dpImporteVenc3 As Decimal = 3400.0
   Private Const dpIdentificadorDeCuenta As Long = 5120084114
   Private Const datoResultado = "04471479779322001310335000280335500620340000512008411400"

   <TestMethod()> Public Sub ArmarCodigoDeBarras()
      Dim rDigitosVerificadores As Reglas.Ayudante.DigitosVerificadores.IDAutomationHL25 = New Reglas.Ayudante.DigitosVerificadores.IDAutomationHL25
      Dim codigo As String = Banco.DebitosDirectos.RoelaSiro.
                                    ArmarCodigoBarras(dpIdentificacionUsuario,
                                                      dpIdentificadorConcepto,
                                                      dpFechaVenc1,
                                                      dpImporteVenc1,
                                                      dpFechaVenc2,
                                                      dpImporteVenc2,
                                                      dpFechaVenc3,
                                                      dpImporteVenc3,
                                                      dpIdentificadorDeCuenta)
      Assert.AreEqual(datoResultado, codigo)
   End Sub
   <TestMethod> Public Sub ArmarCodigoDeBarrasIncorrecto()
      Dim datoResultado As String = "044714797793220013103350002803355006201390000512002811400"
      Dim rDigitosVerificadores As Reglas.Ayudante.DigitosVerificadores.IDAutomationHL25 = New Reglas.Ayudante.DigitosVerificadores.IDAutomationHL25
      Dim codigo As String = Banco.DebitosDirectos.RoelaSiro.
                                    ArmarCodigoBarras(dpIdentificacionUsuario,
                                                      dpIdentificadorConcepto,
                                                      dpFechaVenc1,
                                                      dpImporteVenc1,
                                                      dpFechaVenc2,
                                                      dpImporteVenc2,
                                                      dpFechaVenc3,
                                                      dpImporteVenc3,
                                                      dpIdentificadorDeCuenta)
      Assert.AreNotEqual(datoResultado, codigo)
   End Sub
End Class