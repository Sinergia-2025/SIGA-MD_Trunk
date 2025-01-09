<TestClass()> Public Class ProbarNormalizarDescripcion
   <TestMethod()> Public Sub CodigoBarraCorto2dec()
      Reglas.Publicos.VerificaConfiguracionRegional()
      Dim valorOrigen As String = "CASTORINA FERÑANDO"
      Dim valorDestino As String = Reglas.Publicos.NormalizarDescripcion(valorOrigen)
      Assert.AreEqual("CASTORINA FERNANDO", valorDestino)
   End Sub

End Class
