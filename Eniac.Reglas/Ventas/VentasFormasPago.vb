Public Class VentasFormasPago
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.VentaFormaPago.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(vfp As Entidades.VentaFormaPago, tipo As TipoSP)

      Dim sql = New SqlServer.VentasFormasPago(da)
      Select Case tipo
         Case TipoSP._I
            sql.VentasFormasPago_I(vfp.IdFormasPago, vfp.DescripcionFormasPago,
                                   vfp.Dias, vfp.EsTarjeta, vfp.OrdenVentas,
                                   vfp.OrdenCompras, vfp.OrdenFichas, vfp.CantidadCuotas,
                                   vfp.DiasPrimerCuota,
                                   vfp.FechaBaseProximaCuota, vfp.ExcluyeSabados, vfp.ExcluyeDomingos, vfp.ExcluyeFeriados, vfp.Porcentaje,
                                   vfp.RequierePesos, vfp.RequiereDolares, vfp.RequiereTickets,
                                   vfp.RequiereTransferencia, vfp.RequiereCheques,
                                   vfp.RequiereTarjetaDebito, vfp.RequiereTarjetaCredito, vfp.RequiereTarjetaCredito1Pago, vfp.IdListaPrecios,
                                   vfp.IdTipoComprobantes, vfp.IdTipoComprobantesFR, vfp.IdCuentaBancariaEfectivo, vfp.ArchivoComplementario,
                                   vfp.ArchivoAImprimirEmbebido, vfp.AplicanOfertas, vfp.Descripcion)

            ' # Vinculo la nueva FP a todas las sucursales
            Dim rVentasFormasPagoSucursales = New VentasFormasPagoSucursales(da)
            rVentasFormasPagoSucursales.VincularTodas(vfp.IdFormasPago)

         Case TipoSP._U
            sql.VentasFormasPago_U(vfp.IdFormasPago, vfp.DescripcionFormasPago,
                                   vfp.Dias, vfp.EsTarjeta, vfp.OrdenVentas,
                                   vfp.OrdenCompras, vfp.OrdenFichas, vfp.CantidadCuotas,
                                   vfp.DiasPrimerCuota,
                                   vfp.FechaBaseProximaCuota, vfp.ExcluyeSabados, vfp.ExcluyeDomingos, vfp.ExcluyeFeriados, vfp.Porcentaje,
                                   vfp.RequierePesos, vfp.RequiereDolares, vfp.RequiereTickets,
                                   vfp.RequiereTransferencia, vfp.RequiereCheques,
                                   vfp.RequiereTarjetaDebito, vfp.RequiereTarjetaCredito, vfp.RequiereTarjetaCredito1Pago, vfp.IdListaPrecios,
                                   vfp.IdTipoComprobantes, vfp.IdTipoComprobantesFR, vfp.IdCuentaBancariaEfectivo, vfp.ArchivoComplementario,
                                   vfp.ArchivoAImprimirEmbebido, vfp.AplicanOfertas, vfp.Descripcion)
         Case TipoSP._D

            ' # Borrar todas las FP vinculadas a la sucursal
            Dim rVentasFormasPagoSucursales = New VentasFormasPagoSucursales(da)
            rVentasFormasPagoSucursales.BorrarTodas(vfp.IdFormasPago, True)

            sql.VentasFormasPago_D(vfp.IdFormasPago)
      End Select
   End Sub

   Private Sub CargarUno(dr As DataRow, o As Entidades.VentaFormaPago)
      With o
         .IdFormasPago = dr.Field(Of Integer)("IdFormasPago")
         .DescripcionFormasPago = dr.Field(Of String)("DescripcionFormasPago").IfNull()
         .Dias = dr.Field(Of Integer)("Dias")
         .EsTarjeta = dr.Field(Of Boolean)("EsTarjeta")
         .OrdenVentas = dr.Field(Of Integer)("OrdenVentas")
         .OrdenCompras = dr.Field(Of Integer)("OrdenCompras")
         .OrdenFichas = dr.Field(Of Integer)("OrdenFichas")
         .CantidadCuotas = dr.Field(Of Integer)("CantidadCuotas")
         .DiasPrimerCuota = dr.Field(Of Integer)("DiasPrimerCuota")

         .FechaBaseProximaCuota = dr.Field(Of String)(Entidades.VentaFormaPago.Columnas.FechaBaseProximaCuota.ToString()).
                                       StringToEnum(Entidades.VentaFormaPago.ProximaCuota.REAL)

         '.FechaBaseProximaCuota = DirectCast([Enum].Parse(GetType(Entidades.VentaFormaPago.ProximaCuota),
         '                                                  dr(Entidades.VentaFormaPago.Columnas.FechaBaseProximaCuota.ToString()).ToString()),
         '                                     Entidades.VentaFormaPago.ProximaCuota)
         .ExcluyeSabados = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.ExcluyeSabados.ToString())
         .ExcluyeDomingos = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.ExcluyeDomingos.ToString())
         .ExcluyeFeriados = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.ExcluyeFeriados.ToString())

         .Porcentaje = dr.Field(Of Decimal)(Entidades.VentaFormaPago.Columnas.Porcentaje.ToString())

         .RequierePesos = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.RequierePesos.ToString)
         .RequiereDolares = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.RequiereDolares.ToString)
         .RequiereTickets = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.RequiereTickets.ToString)
         .RequiereTransferencia = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.RequiereTransferencia.ToString)
         .RequiereCheques = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.RequiereCheques.ToString)
         .RequiereTarjetaDebito = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.RequiereTarjetaDebito.ToString)
         .RequiereTarjetaCredito = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.RequiereTarjetaCredito.ToString)
         .RequiereTarjetaCredito1Pago = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.RequiereTarjetaCredito1Pago.ToString)

         .IdListaPrecios = dr.Field(Of Integer?)(Entidades.VentaFormaPago.Columnas.IdListaPrecios.ToString())

         '-- REQ-33317.- --------------------------------------------------------------------------------------------------
         .IdTipoComprobantes = dr.Field(Of String)(Entidades.VentaFormaPago.Columnas.IdTipoComprobantes.ToString())
         '-- REQ-33409- --------------------------------------------------------------------------------------------------
         .IdTipoComprobantesFR = dr.Field(Of String)(Entidades.VentaFormaPago.Columnas.IdTipoComprobantesFR.ToString())
         '-----------------------------------------------------------------------------------------------------------------
         .IdCuentaBancariaEfectivo = dr.Field(Of Integer?)(Entidades.VentaFormaPago.Columnas.IdCuentaBancariaEfectivo.ToString())
         '-- REQ-35955- --------------------------------------------------------------------------------------------------
         .ArchivoComplementario = dr.Field(Of String)(Entidades.VentaFormaPago.Columnas.ArchivoComplementario.ToString())
         .ArchivoAImprimirEmbebido = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.ArchivoAImprimirEmbebido.ToString)
         '-----------------------------------------------------------------------------------------------------------------
         .AplicanOfertas = dr.Field(Of Boolean)(Entidades.VentaFormaPago.Columnas.AplicanOfertas.ToString)
         .Descripcion = dr.Field(Of String)("Descripcion").IfNull()

      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Function _Insertar(descripcionFormasPago As String) As Entidades.VentaFormaPago
      Try
         Dim entidad = New Entidades.VentaFormaPago() With
            {
               .IdFormasPago = GetCodigoMaximo() + 1,
               .DescripcionFormasPago = descripcionFormasPago
            }
         EjecutaSP(entidad, TipoSP._I)
         Return entidad
      Catch ex As Exception
         Throw
      End Try
   End Function
   Public Sub _Insertar(entidad As Entidades.VentaFormaPago)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.VentaFormaPago)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.VentaFormaPago)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetTodas(tipo As String, contado As Boolean?) As List(Of Entidades.VentaFormaPago)
      Return CargaLista(GetPorTipo(tipo, contado),
                        Sub(o, dr) CargarUno(dr, o), Function() New Entidades.VentaFormaPago())
   End Function

   Public Function GetTodasOrdenadas() As List(Of Entidades.VentaFormaPago)
      Return CargaLista(GetAll(),
                        Sub(o, dr) CargarUno(dr, o), Function() New Entidades.VentaFormaPago())
   End Function

   Public Function GetUna(idFormaPago As Integer) As Entidades.VentaFormaPago
      Return CargaEntidad(New SqlServer.VentasFormasPago(da).VentasFormasPago_G1(idFormaPago),
                          Sub(o, dr) CargarUno(dr, o), Function() New Entidades.VentaFormaPago(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe forma de pago con Código {0}", idFormaPago))
   End Function

   Public Function GetUna(tipo As String, esContado As Boolean) As Entidades.VentaFormaPago
      Return CargaEntidad(GetPorTipo(tipo, esContado),
                          Sub(o, dr) CargarUno(dr, o), Function() New Entidades.VentaFormaPago(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe forma de pago Tipo '{0}' y {1}es Contado", tipo, If(esContado, "", "NO ")))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.VentasFormasPago(da).GetCodigoMaximo()
   End Function
   Public Function GetPorCodigo(idFormaPago As Integer, tipo As String, esContado As Boolean?) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.VentasFormasPago(da)
            Return sql.GetPorCodigo(idFormaPago:=idFormaPago, descripcion:=String.Empty, tipo:=tipo, esContado:=esContado, idSucursal:=actual.Sucursal.Id)
         End Function)
   End Function

   Public Function GetPorDescripcion(descripcion As String, tipo As String, esContado As Boolean?) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.VentasFormasPago(da)
            Return sql.GetPorCodigo(idFormaPago:=0, descripcion:=descripcion, tipo:=tipo, esContado:=esContado, idSucursal:=actual.Sucursal.Id)
         End Function)
   End Function

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.VentaFormaPago), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.VentaFormaPago), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.VentaFormaPago), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.VentasFormasPago(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.VentasFormasPago(da).VentasFormasPago_GA()
   End Function
   Public Function GetPorTipo(tipo As String, contado As Boolean?) As System.Data.DataTable
      Return New SqlServer.VentasFormasPago(da).VentasFormasPagoTipo(tipo, contado, idSucursal:=actual.Sucursal.Id)
   End Function
#End Region

End Class