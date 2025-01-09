<Obsolete("Se reemplaza por MovimientosStockProductosNrosSerie", True)>
Public Class MovimientosComprasProductosNrosSerie
   Inherits Reglas.Base

   Public Sub New()
      Me.NombreEntidad = Entidades.MovimientoCompraProductoNroSerie.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.MovimientoCompraProductoNroSerie.NombreTabla
      da = accesoDatos
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.MovimientoCompraProductoNroSerie)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualiza(DirectCast(entidad, Entidades.MovimientoCompraProductoNroSerie)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borra(DirectCast(entidad, Entidades.MovimientoCompraProductoNroSerie)))
   End Sub

   Public Sub _Inserta(entidad As Entidades.MovimientoCompraProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualiza(entidad As Entidades.MovimientoCompraProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borra(entidad As Entidades.MovimientoCompraProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.MovimientoCompraProductoNroSerie, tipo As TipoSP)
      Dim sMovimientosComprasProductosNrosSerie As SqlServer.MovimientosComprasProductosNrosSerie = New SqlServer.MovimientosComprasProductosNrosSerie(da)
      Select Case tipo
         Case TipoSP._I
            sMovimientosComprasProductosNrosSerie.MovimientosComprasProductosNrosSerie_I(en.IdSucursal, en.IdTipoMovimiento, en.NumeroMovimiento, en.Orden, en.Cantidad,
                                                                                       en.IdProducto, en.NroSerie)
         Case TipoSP._U
            sMovimientosComprasProductosNrosSerie.MovimientosComprasProductosNrosSerie_U(en.IdSucursal, en.IdTipoMovimiento, en.NumeroMovimiento, en.Orden, en.Cantidad,
                                                                                       en.IdProducto, en.NroSerie)
         Case TipoSP._D
            sMovimientosComprasProductosNrosSerie.MovimientosComprasProductosNrosSerie_D(en.IdSucursal, en.IdTipoMovimiento, en.NumeroMovimiento)
      End Select
   End Sub

   Public Overrides Function GetAll() As DataTable
      Dim sMVPNS As SqlServer.MovimientosComprasProductosNrosSerie = New SqlServer.MovimientosComprasProductosNrosSerie(da)
      Return sMVPNS.MovimientosComprasProductosNrosSerie_GA()
   End Function

   Public Function GetTodos(idSucursal As Integer,
                            idTipoMovimiento As String,
                            numeroMovimiento As Long,
                            orden As Integer,
                            idProducto As String) As List(Of Entidades.MovimientoCompraProductoNroSerie)
      Return CargaLista(New SqlServer.MovimientosComprasProductosNrosSerie(da).MovimientosComprasProductosNrosSerie_GA(idSucursal, idTipoMovimiento, numeroMovimiento, orden, idProducto),
                        Sub(o, dr) CargarUno(o, dr),
                        Function() New Entidades.MovimientoCompraProductoNroSerie())
   End Function

   Public Function GetUno(idSucursal As Integer,
                          idTipoMovimiento As String,
                          numeroMovimiento As Long,
                          orden As Integer,
                          cantidad As Integer,
                          idProducto As String,
                          nroSerie As String) As Entidades.MovimientoCompraProductoNroSerie
      Dim sMovimientosComprasProductosNrosSerie As SqlServer.MovimientosComprasProductosNrosSerie = New SqlServer.MovimientosComprasProductosNrosSerie(da)
      Return CargaEntidad(sMovimientosComprasProductosNrosSerie.MovimientosComprasProductosNrosSerie_G1(idSucursal, idTipoMovimiento, numeroMovimiento, orden, cantidad,
                                                                                                       idProducto, nroSerie),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MovimientoCompraProductoNroSerie(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Producto con Nro Serie: {0}", nroSerie))
   End Function

   Private Sub CargarUno(eMVPNS As Entidades.MovimientoCompraProductoNroSerie, dr As DataRow)
      With eMVPNS
         .IdSucursal = dr.Field(Of Integer)(Entidades.MovimientoCompraProductoNroSerie.Columnas.IdSucursal.ToString())
         .IdTipoMovimiento = dr.Field(Of String)(Entidades.MovimientoCompraProductoNroSerie.Columnas.IdTipoMovimiento.ToString())
         .NumeroMovimiento = dr.Field(Of Long)(Entidades.MovimientoCompraProductoNroSerie.Columnas.NumeroMovimiento.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.MovimientoCompraProductoNroSerie.Columnas.Orden.ToString())
         .Cantidad = dr.Field(Of Integer)(Entidades.MovimientoCompraProductoNroSerie.Columnas.Cantidad.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.MovimientoCompraProductoNroSerie.Columnas.IdProducto.ToString())
         .NroSerie = dr.Field(Of String)(Entidades.MovimientoCompraProductoNroSerie.Columnas.NroSerie.ToString())
      End With
   End Sub

End Class

