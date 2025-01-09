<TestClass()> Public Class ProbarCodigoBarrasGetPrecioModalidadPeso
   Private Const CodigoBarra As String = "2001324001054"
   <TestMethod()> Public Sub CodigoBarraCorto2dec()
      Reglas.Publicos.VerificaConfiguracionRegional()
      Dim codigoBarra As String = "1234567890"
      Dim valor As Decimal = Reglas.Productos.CodigoBarras.GetValorPesoPrecio(codigoBarra, 2)
      Assert.AreEqual(0D, valor)
   End Sub

   <TestMethod()> Public Sub CodigoBarra2dec()
      Reglas.Publicos.VerificaConfiguracionRegional()
      Dim valor As Decimal = Reglas.Productos.CodigoBarras.GetValorPesoPrecio(CodigoBarra, 2)
      Assert.AreEqual(1.05D, valor)
   End Sub

   <TestMethod()> Public Sub CodigoBarra3dec()
      Reglas.Publicos.VerificaConfiguracionRegional()
      Dim valor As Decimal = Reglas.Productos.CodigoBarras.GetValorPesoPrecio(CodigoBarra, 3)
      Assert.AreEqual(0.105D, valor)
   End Sub

   <TestMethod()> Public Sub CodigoBarraPRECIO()
      Reglas.Publicos.VerificaConfiguracionRegional()
      Dim valor As Decimal = Reglas.Productos.CodigoBarras.GetValorSegunModalidad(CodigoBarra, Entidades.Producto.Modalidades.PRECIO)
      Assert.AreEqual(1.05D, valor)
   End Sub

   <TestMethod()> Public Sub CodigoBarraPESO()
      Reglas.Publicos.VerificaConfiguracionRegional()
      Dim valor As Decimal = Reglas.Productos.CodigoBarras.GetValorSegunModalidad(CodigoBarra, Entidades.Producto.Modalidades.PESO)
      Assert.AreEqual(0.105D, valor)
   End Sub

   <TestMethod()> Public Sub CodigoBarraNORMAL()
      Reglas.Publicos.VerificaConfiguracionRegional()
      Dim valor As Decimal = Reglas.Productos.CodigoBarras.GetValorSegunModalidad(CodigoBarra, Entidades.Producto.Modalidades.NORMAL)
      Assert.AreEqual(0D, valor)
   End Sub

   <TestMethod()> Public Sub SegunFacturacionV2()
      Reglas.Publicos.VerificaConfiguracionRegional()
      Dim _codigoBarrasCompleto As String = CodigoBarra
      Dim valor As Decimal
      If _codigoBarrasCompleto.Length = 13 Then
         valor = Decimal.Parse(_codigoBarrasCompleto.Substring(7, 5).Insert(2, "."))
      Else
         valor = 0
      End If
      Assert.AreEqual(0.105D, valor)
   End Sub

End Class
