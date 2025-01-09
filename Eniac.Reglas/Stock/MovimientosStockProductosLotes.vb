Public Class MovimientosStockProductosLotes
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.MovimientoStockProductoLotes.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.MovimientoStockProductoLotes)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualiza(DirectCast(entidad, Entidades.MovimientoStockProductoLotes)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borra(DirectCast(entidad, Entidades.MovimientoStockProductoLotes)))
   End Sub
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MovimientoStockProductoLotes, tipo As TipoSP)
      Dim sMSPLotes = New SqlServer.MovimientosStockProductosLotes(da)
      Select Case tipo
         Case TipoSP._I
            sMSPLotes.MovimientosStockProductosLotes_I(en.IdSucursal, en.IdDeposito, en.IdUbicacion, en.IdTipoMovimiento, en.NumeroMovimiento,
                                                       en.Orden, en.IdProducto, en.IdLote, en.Cantidad, en.Cantidad2)
         Case TipoSP._U
            sMSPLotes.MovimientosStockProductosLotes_U(en.IdSucursal, en.IdDeposito, en.IdUbicacion, en.IdTipoMovimiento, en.NumeroMovimiento,
                                                       en.Orden, en.IdProducto, en.IdLote, en.Cantidad, en.Cantidad2)
         Case TipoSP._D
            sMSPLotes.MovimientosStockProductosLotes_D(en.IdSucursal, en.IdDeposito, en.IdUbicacion, en.IdTipoMovimiento, en.NumeroMovimiento)
      End Select
   End Sub
   Private Sub CargarUno(eMSPL As Entidades.MovimientoStockProductoLotes, dr As DataRow)
      With eMSPL
         .IdSucursal = dr.Field(Of Integer)(Entidades.MovimientoStockProductoLotes.Columnas.IdSucursal.ToString())
         .IdDeposito = dr.Field(Of Integer)(Entidades.MovimientoStockProductoLotes.Columnas.IdDeposito.ToString())
         .IdUbicacion = dr.Field(Of Integer)(Entidades.MovimientoStockProductoLotes.Columnas.IdUbicacion.ToString())
         .IdTipoMovimiento = dr.Field(Of String)(Entidades.MovimientoStockProductoLotes.Columnas.IdTipoMovimiento.ToString())
         .NumeroMovimiento = dr.Field(Of Long)(Entidades.MovimientoStockProductoLotes.Columnas.NumeroMovimiento.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.MovimientoStockProductoLotes.Columnas.Orden.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.MovimientoStockProductoLotes.Columnas.IdProducto.ToString())
         .IdLote = dr.Field(Of String)(Entidades.MovimientoStockProductoLotes.Columnas.IdLote.ToString())
         .Cantidad = dr.Field(Of Decimal)(Entidades.MovimientoStockProductoLotes.Columnas.Cantidad.ToString())
         .Cantidad2 = dr.Field(Of Decimal)(Entidades.MovimientoStockProductoLotes.Columnas.Cantidad2.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"

   Public Sub _Inserta(entidad As Entidades.MovimientoStockProductoLotes)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualiza(entidad As Entidades.MovimientoStockProductoLotes)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borra(entidad As Entidades.MovimientoStockProductoLotes)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.MovimientosStockProductosLotes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString()).Copy()
   End Function

   Public Function GetPorMovimientoStock(ByVal idSucursal As Integer,
                                         ByVal idDeposito As Integer,
                                         ByVal idUbicacion As Integer,
                                         ByVal idTipoMovimiento As String,
                                         ByVal numeroMovimiento As Long) As DataTable
      Return New SqlServer.MovimientosStockProductosLotes(Me.da).GetPorMovimientoStock(idSucursal, idDeposito, idUbicacion, idTipoMovimiento, numeroMovimiento)
   End Function

   Public Function GetUno(idSucursal As Integer,
                          idDeposito As Integer,
                          idUbicacion As Integer,
                          idTipoMovimiento As String,
                          NumeroMovimiento As Long,
                          Orden As Integer,
                          idProducto As String,
                          idLote As String) As Entidades.MovimientoStockProductoLotes

      Return CargaEntidad(New SqlServer.MovimientosStockProductosLotes(da).MovimientosStockProductosLotes_G1(idSucursal, idDeposito, idUbicacion, idTipoMovimiento, NumeroMovimiento, Orden, idProducto, idLote),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MovimientoStockProductoLotes(),
                          AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe Producto {0} con Lote: {1}", idProducto, idLote))

   End Function

   Public Sub EliminarPorProduccionLote(mcp As Entidades.MovimientoStockProducto)
      Dim sql = New SqlServer.MovimientosStockProductosLotes(da)
      sql.MovimientosStockProductosLotes_D(mcp.IdSucursal, mcp.IdDeposito, mcp.IdUbicacion,
                                           mcp.TipoMovimiento.IdTipoMovimiento, mcp.NumeroMovimiento)
   End Sub
#End Region
End Class
