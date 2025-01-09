Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class CuentasCorrientesPagos_CalculaCuotasSegunFormaPago

   <TestMethod()> Public Sub EjecutaConCuentaCorrienteNull()
      Dim r = New Reglas.CuentasCorrientesPagos(Nothing)

      Dim ex1 As Exception = Nothing
      Try
         r.CalculaCuotasSegunFormaPago(Nothing, 2)
      Catch ex As Exception
         ex1 = ex
      End Try
      Assert.IsNotNull(ex1)
   End Sub
   <TestMethod()> Public Sub EjecutaConPagosEnCuentaCorrienteNull()
      Dim r = New Reglas.CuentasCorrientesPagos(Nothing)

      Dim ex1 As Exception = Nothing
      Try
         r.CalculaCuotasSegunFormaPago(New Entidades.CuentaCorriente(), 2)
      Catch ex As Exception
         ex1 = ex
      End Try
      Assert.IsNotNull(ex1)
   End Sub
   <TestMethod()> Public Sub EjecutaConFormaPagoEnCuentasCorrientesNull()
      Dim r = New Reglas.CuentasCorrientesPagos(Nothing)

      Dim ex1 As Exception = Nothing
      Try
         r.CalculaCuotasSegunFormaPago(New Entidades.CuentaCorriente() With {.Pagos = New List(Of Entidades.CuentaCorrientePago)()}, 2)
      Catch ex As Exception
         ex1 = ex
      End Try
      Assert.IsNotNull(ex1)
   End Sub

   <TestMethod()> Public Sub EjecutaCalculoCuotasCorrecto_0_30_30()
      Dim r = New Reglas.CuentasCorrientesPagos(Nothing)
      Dim ctacte = New Entidades.CuentaCorriente() With {.Pagos = New List(Of Entidades.CuentaCorrientePago)()}
      ctacte.Fecha = Today
      ctacte.ImporteTotal = 10000
      ctacte.FormaPago = New Entidades.VentaFormaPago() With {.Dias = 30, .CantidadCuotas = 3, .DiasPrimerCuota = 0}

      Dim result = r.CalculaCuotasSegunFormaPago(ctacte, 2)

      Assert.AreEqual(3, result.Count)
      Assert.AreEqual(10000D, result.Sum(Function(p) p.ImporteCuota))
      Assert.AreEqual(10000D, result.Sum(Function(p) p.SaldoCuota))
      Assert.AreNotEqual(result.First().ImporteCuota, result.Last().ImporteCuota)
      Assert.AreEqual(Today.AddDays(0 + (30 * 2)), result.Last().FechaVencimiento)

   End Sub
   <TestMethod()> Public Sub EjecutaCalculoCuotasCorrecto_20_30_30()
      Dim r = New Reglas.CuentasCorrientesPagos(Nothing)
      Dim ctacte = New Entidades.CuentaCorriente() With {.Pagos = New List(Of Entidades.CuentaCorrientePago)()}
      ctacte.Fecha = Today
      ctacte.ImporteTotal = 10000
      ctacte.FormaPago = New Entidades.VentaFormaPago() With {.Dias = 30, .CantidadCuotas = 3, .DiasPrimerCuota = 20}

      Dim result = r.CalculaCuotasSegunFormaPago(ctacte, 2)

      Assert.AreEqual(3, result.Count)
      Assert.AreEqual(10000D, result.Sum(Function(p) p.ImporteCuota))
      Assert.AreEqual(10000D, result.Sum(Function(p) p.SaldoCuota))
      Assert.AreNotEqual(result.First().ImporteCuota, result.Last().ImporteCuota)
      Assert.AreEqual(Today.AddDays(20 + (30 * 2)), result.Last().FechaVencimiento)

   End Sub

End Class