Option Strict On
Option Explicit On
Namespace ServiciosRest.CobranzasMovil
   Public Class CuentasCorrientes
      Public Function GetCuentasCorrientes(idEmpresa As Integer) As List(Of Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientes)
         Dim result As List(Of Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientes) = New List(Of Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientes)()
         Using dtCuentasCorrientes As DataTable = New Reglas.CuentasCorrientes().GetParaSincronizacionMovil()
            Dim o As Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientes
            For Each dr As DataRow In dtCuentasCorrientes.Rows
               o = New Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientes(idEmpresa)
               o.IdSucursal = Integer.Parse(dr(Entidades.CuentaCorriente.Columnas.IdSucursal.ToString()).ToString())
               o.IdTipoComprobante = dr(Entidades.Venta.Columnas.IdTipoComprobante.ToString()).ToString()
               o.Letra = dr(Entidades.CuentaCorriente.Columnas.Letra.ToString()).ToString()
               o.CentroEmisor = Short.Parse(dr(Entidades.CuentaCorriente.Columnas.CentroEmisor.ToString()).ToString())
               o.NumeroComprobante = Long.Parse(dr(Entidades.CuentaCorriente.Columnas.NumeroComprobante.ToString()).ToString())
               o.CuotaNumero = Integer.Parse(dr(Entidades.CuentaCorrientePago.Columnas.CuotaNumero.ToString()).ToString())
               o.DescripcionAbrevTipoComp = dr(Entidades.TipoComprobante.Columnas.DescripcionAbrev.ToString()).ToString()
               o.Fecha = DateTime.Parse(dr(Entidades.CuentaCorrientePago.Columnas.Fecha.ToString()).ToString())
               o.FechaVencimiento = DateTime.Parse(dr(Entidades.CuentaCorrientePago.Columnas.FechaVencimiento.ToString()).ToString())
               o.ImporteCuota = Decimal.Parse(dr(Entidades.CuentaCorrientePago.Columnas.ImporteCuota.ToString()).ToString())
               o.SaldoCuota = Decimal.Parse(dr(Entidades.CuentaCorrientePago.Columnas.SaldoCuota.ToString()).ToString())
               o.NombrePrimerProducto = dr(Entidades.VentaProducto.Columnas.NombreProducto.ToString()).ToString()
               o.IdCliente = Long.Parse(dr(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString())
               result.Add(o)
            Next
         End Using
         Return result
      End Function

      Public Function GetCuentasCorrientesDebeHaber(idEmpresa As Integer, ejecucion As Entidades.JSonEntidades.CobranzasMovil.Temp_Ejecuciones) As List(Of Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientesDebeHaber)
         Dim meses As Integer = Reglas.Publicos.Simovil.MesesEnviarCuentasCorrientesDebeHaber
         'Dim fechaDesde As DateTime = Today.AddMonths(-meses)
         'Dim fechaHasta As DateTime = Today.UltimoSegundoDelDia()
         Dim sucs As IEnumerable(Of Integer) = If(ejecucion Is Nothing, Nothing, ejecucion.Sucursales.ToList().ConvertAll(Function(s) s.IdSucursal))

         Dim result As List(Of Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientesDebeHaber) = New List(Of Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientesDebeHaber)()
         Using dtCuentasCorrientes = New Reglas.CuentasCorrientes().GetParaSincronizacionMovilDebeHaber(meses, sucs)
            Using dtCuentasCorrientesPago = New Reglas.CuentasCorrientesPagos().GetParaSincronizacionMovilDebeHaber(meses, sucs)
               Dim o As Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientesDebeHaber
               For Each dr As DataRow In dtCuentasCorrientes.Rows
                  o = New Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientesDebeHaber(idEmpresa, ejecucion)
                  o.CuitEmisor = dr(Entidades.Empresa.Columnas.CuitEmpresa.ToString()).ToString()
                  o.IdSucursal = Integer.Parse(dr(Entidades.CuentaCorriente.Columnas.IdSucursal.ToString()).ToString())
                  o.IdTipoComprobante = dr(Entidades.Venta.Columnas.IdTipoComprobante.ToString()).ToString()
                  o.Letra = dr(Entidades.CuentaCorriente.Columnas.Letra.ToString()).ToString()
                  o.CentroEmisor = Short.Parse(dr(Entidades.CuentaCorriente.Columnas.CentroEmisor.ToString()).ToString())
                  o.NumeroComprobante = Long.Parse(dr(Entidades.CuentaCorriente.Columnas.NumeroComprobante.ToString()).ToString())
                  o.CuotaNumero = Integer.Parse(dr(Entidades.CuentaCorrientePago.Columnas.CuotaNumero.ToString()).ToString())
                  o.DescripcionTipoComp = dr(Entidades.TipoComprobante.Columnas.Descripcion.ToString()).ToString()
                  o.DescripcionAbrevTipoComp = dr(Entidades.TipoComprobante.Columnas.DescripcionAbrev.ToString()).ToString()

                  o.IdCliente = Long.Parse(dr(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString())
                  o.CodigoCliente = Long.Parse(dr(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString())
                  o.NombreCliente = dr(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString()

                  o.Fecha = DateTime.Parse(dr(Entidades.CuentaCorrientePago.Columnas.Fecha.ToString()).ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)
                  o.FechaVencimiento = DateTime.Parse(dr(Entidades.CuentaCorrientePago.Columnas.FechaVencimiento.ToString()).ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)

                  o.ImporteCuota = Decimal.Parse(dr(Entidades.CuentaCorrientePago.Columnas.ImporteCuota.ToString()).ToString())
                  o.SaldoCuota = Decimal.Parse(dr(Entidades.CuentaCorrientePago.Columnas.SaldoCuota.ToString()).ToString())
                  o.Debe = Decimal.Parse(dr("Debe").ToString())
                  o.Haber = Decimal.Parse(dr("Haber").ToString())

                  o.IdFormasPago = Integer.Parse(dr(Entidades.VentaFormaPago.Columnas.IdFormasPago.ToString()).ToString())
                  o.DescripcionFormasPago = dr(Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString()).ToString()
                  o.Dias = Integer.Parse(dr(Entidades.VentaFormaPago.Columnas.Dias.ToString()).ToString())

                  o.Observacion = dr(Entidades.CuentaCorriente.Columnas.Observacion.ToString()).ToString()

                  o.GrabaLibro = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.GrabaLibro.ToString()).ToString())
                  o.EsSaldoInicial = False
                  o.NombreProductos = dr.Field(Of String)("NombreProductos")

                  For Each drPago As DataRow In dtCuentasCorrientesPago.Select(String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                                                                                             o.IdSucursal, o.IdTipoComprobante, o.Letra, o.CentroEmisor, o.NumeroComprobante))
                     Dim oP = New Entidades.JSonEntidades.CobranzasMovil.CuentasCorrientesPagos(o.IdEmpresa) With
                                 {
                                    .IdSucursal = o.IdSucursal,
                                    .IdTipoComprobante = o.IdTipoComprobante,
                                    .Letra = o.Letra,
                                    .CentroEmisor = o.CentroEmisor,
                                    .NumeroComprobante = o.NumeroComprobante,
                                    .CuotaNumero = drPago.Field(Of Integer)(Entidades.CuentaCorrientePago.Columnas.CuotaNumero.ToString()),
                                    .Fecha = drPago.Field(Of DateTime)(Entidades.CuentaCorrientePago.Columnas.Fecha.ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas),
                                    .FechaVencimiento = drPago.Field(Of DateTime)(Entidades.CuentaCorrientePago.Columnas.FechaVencimiento.ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas),
                                    .ImporteCuota = drPago.Field(Of Decimal)(Entidades.CuentaCorrientePago.Columnas.ImporteCuota.ToString()),
                                    .SaldoCuota = drPago.Field(Of Decimal)(Entidades.CuentaCorrientePago.Columnas.SaldoCuota.ToString())
                                 }
                     o.Pagos.Add(oP)
                  Next

                  result.Add(o)
               Next
            End Using
         End Using
         Return result
      End Function
   End Class
End Namespace