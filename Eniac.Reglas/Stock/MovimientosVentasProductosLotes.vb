<Obsolete("Se reemplaza por MovimientosStockOroductosLotes", True)>
Public Class MovimientosVentasProductosLotes
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = "MovimientosVentasProductosLotes"
      da = New Eniac.Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "MovimientosVentasProductosLotes"
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Sub _Inserta(entidad As Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualiza(entidad As Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borra(entidad As Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaConTransaccion(Sub() _Inserta(entidad))
   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaConTransaccion(Sub() _Actualiza(entidad))
   End Sub
   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaConTransaccion(Sub() _Borra(entidad))
   End Sub
   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.MovimientosVentasProductosLotes = New SqlServer.MovimientosVentasProductosLotes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString()).Copy()
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MovimientosVentasProductosLotes(Me.da).MovimientosVentasProductosLotes_GA()
   End Function

   Public Function GetPorMovimientoVenta(ByVal idSucursal As Integer, ByVal idTipoMovimiento As String, ByVal numeroMovimiento As Long) As DataTable
      Return New SqlServer.MovimientosVentasProductosLotes(Me.da).GetPorMovimientoVenta(idSucursal, idTipoMovimiento, numeroMovimiento)
   End Function

   Public Function GetUno(IdSucursal As Integer,
                          IdTipoMovimiento As String,
                          NumeroMovimiento As Long,
                          Orden As Integer,
                          IdProducto As String,
                          IdLote As String) As Entidades.MovimientoVentaProductoLote

      Return CargaEntidad(New SqlServer.MovimientosVentasProductosLotes(da).MovimientosVentasProductosLotes_G1(IdSucursal, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto, IdLote),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MovimientoVentaProductoLote(),
                          AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe Producto {0} con Lote: {1}", IdProducto, IdLote))

   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.MovimientoVentaProductoLote = DirectCast(entidad, Entidades.MovimientoVentaProductoLote)

      Dim sql As SqlServer.MovimientosVentasProductosLotes = New SqlServer.MovimientosVentasProductosLotes(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.MovimientosVentasProductosLotes_I(en.IdSucursal,
                                                  en.IdTipoMovimiento,
                                                  en.NumeroMovimiento,
                                                  en.Orden,
                                                  en.IdProducto,
                                                  en.IdLote,
                                                  en.Cantidad)
         Case TipoSP._U
            sql.MovimientosVentasProductosLotes_U(en.IdSucursal,
                                                  en.IdTipoMovimiento,
                                                  en.NumeroMovimiento,
                                                  en.Orden,
                                                  en.IdProducto,
                                                  en.IdLote,
                                                  en.Cantidad)
         Case TipoSP._D
            sql.MovimientosVentasProductosLotes_D(en.IdSucursal,
                                                  en.IdTipoMovimiento,
                                                en.NumeroMovimiento,
                                                en.Orden,
                                                en.IdProducto,
                                                en.IdLote)
      End Select

   End Sub

   Private Sub CargarUno(eMVPL As Entidades.MovimientoVentaProductoLote, ByVal dr As DataRow)
      With eMVPL
         .IdSucursal = dr.Field(Of Integer)(Entidades.MovimientoVentaProductoLote.Columnas.IdSucursal.ToString())
         .IdTipoMovimiento = dr.Field(Of String)(Entidades.MovimientoVentaProductoLote.Columnas.IdTipoMovimiento.ToString())
         .NumeroMovimiento = dr.Field(Of Long)(Entidades.MovimientoVentaProductoLote.Columnas.NumeroMovimiento.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.MovimientoVentaProductoLote.Columnas.Orden.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.MovimientoVentaProductoLote.Columnas.IdProducto.ToString())
         .IdLote = dr.Field(Of String)(Entidades.MovimientoVentaProductoLote.Columnas.IdLote.ToString())
         .Cantidad = dr.Field(Of Decimal)(Entidades.MovimientoVentaProductoLote.Columnas.Cantidad.ToString())
      End With
   End Sub

#End Region

End Class
