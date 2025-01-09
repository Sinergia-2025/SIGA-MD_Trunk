<Obsolete("Se reemplaza por MovimientosStockProductosNroSerie", True)>
Public Class MovimientosVentasProductosNrosSerie
   Inherits Reglas.Base

   Public Sub New()
      Me.NombreEntidad = Entidades.MovimientoVentaProductoNroSerie.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.MovimientoVentaProductoNroSerie.NombreTabla
      da = accesoDatos
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.MovimientoVentaProductoNroSerie)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualiza(DirectCast(entidad, Entidades.MovimientoVentaProductoNroSerie)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borra(DirectCast(entidad, Entidades.MovimientoVentaProductoNroSerie)))
   End Sub

   Public Sub _Inserta(entidad As Entidades.MovimientoVentaProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualiza(entidad As Entidades.MovimientoVentaProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borra(entidad As Entidades.MovimientoVentaProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.MovimientoVentaProductoNroSerie, tipo As TipoSP)
      Dim sMovimientosVentasProductosNrosSerie As SqlServer.MovimientosVentasProductosNrosSerie = New SqlServer.MovimientosVentasProductosNrosSerie(da)
      Select Case tipo
         Case TipoSP._I
            sMovimientosVentasProductosNrosSerie.MovimientosVentasProductosNrosSerie_I(en.IdSucursal, en.IdTipoMovimiento, en.NumeroMovimiento, en.Orden,
                                                                                       en.IdProducto, en.NroSerie, en.Cantidad)
         Case TipoSP._U
            sMovimientosVentasProductosNrosSerie.MovimientosVentasProductosNrosSerie_U(en.IdSucursal, en.IdTipoMovimiento, en.NumeroMovimiento, en.Orden,
                                                                                       en.IdProducto, en.NroSerie, en.Cantidad)
         Case TipoSP._D
            sMovimientosVentasProductosNrosSerie.MovimientosVentasProductosNrosSerie_D(en.IdSucursal, en.IdTipoMovimiento, en.NumeroMovimiento)
      End Select
   End Sub

   Public Overrides Function GetAll() As DataTable
      Dim sMVPNS As SqlServer.MovimientosVentasProductosNrosSerie = New SqlServer.MovimientosVentasProductosNrosSerie(da)
      Return sMVPNS.MovimientosVentasProductosNrosSerie_GA()
   End Function

   Public Function GetUltimoNumeroDeMovimiento(idSucursal As Integer,
                                               idTipoMovimiento As String) As Integer
      Return New SqlServer.MovimientosVentasProductosNrosSerie(da).GetUltimoNumeroDeMovimiento(idSucursal, idTipoMovimiento)
   End Function

   Public Function GetUno(idSucursal As Integer,
                          idTipoMovimiento As String,
                          numeroMovimiento As Long,
                          orden As Integer,
                          idProducto As String,
                          nroSerie As String) As Entidades.MovimientoVentaProductoNroSerie
      Dim sMovimientosVentasProductosNrosSerie As SqlServer.MovimientosVentasProductosNrosSerie = New SqlServer.MovimientosVentasProductosNrosSerie(da)
      Return CargaEntidad(sMovimientosVentasProductosNrosSerie.MovimientosVentasProductosNrosSerie_G1(idSucursal, idTipoMovimiento, numeroMovimiento, orden,
                                                                                                       idProducto, nroSerie),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MovimientoVentaProductoNroSerie(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Producto con Nro Serie: {0}", nroSerie))
   End Function

   Private Sub CargarUno(eMVPNS As Entidades.MovimientoVentaProductoNroSerie, dr As DataRow)
      With eMVPNS
         .IdSucursal = dr.Field(Of Integer)(Entidades.MovimientoVentaProductoNroSerie.Columnas.IdSucursal.ToString())
         .IdTipoMovimiento = dr.Field(Of String)(Entidades.MovimientoVentaProductoNroSerie.Columnas.IdTipoMovimiento.ToString())
         .NumeroMovimiento = dr.Field(Of Long)(Entidades.MovimientoVentaProductoNroSerie.Columnas.NumeroMovimiento.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.MovimientoVentaProductoNroSerie.Columnas.Orden.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.MovimientoVentaProductoNroSerie.Columnas.IdProducto.ToString())
         .NroSerie = dr.Field(Of String)(Entidades.MovimientoVentaProductoNroSerie.Columnas.NroSerie.ToString())
         .Cantidad = dr.Field(Of Integer)(Entidades.MovimientoVentaProductoNroSerie.Columnas.Cantidad.ToString())
      End With
   End Sub

End Class
