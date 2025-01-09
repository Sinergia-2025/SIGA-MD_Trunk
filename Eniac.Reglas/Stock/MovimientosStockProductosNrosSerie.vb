Public Class MovimientosStockProductosNrosSerie
   Inherits Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.MovimientoStockProductoNrosSerie.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.MovimientoStockProductoNrosSerie)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualiza(DirectCast(entidad, Entidades.MovimientoStockProductoNrosSerie)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borra(DirectCast(entidad, Entidades.MovimientoStockProductoNrosSerie)))
   End Sub

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MovimientoStockProductoNrosSerie, tipo As TipoSP)
      Dim sMSPNrosSerie = New SqlServer.MovimientosStockProductosNrosSerie(da)
      Select Case tipo
         Case TipoSP._I
            sMSPNrosSerie.MovimientosStockProductosNrosSerie_I(en.IdSucursal, en.IdDeposito, en.IdUbicacion, en.IdTipoMovimiento, en.NumeroMovimiento,
                                                               en.Orden, en.IdProducto, en.NroSerie, en.Cantidad, en.Cantidad2)
         Case TipoSP._U
            sMSPNrosSerie.MovimientosStockProductosNrosSerie_U(en.IdSucursal, en.IdDeposito, en.IdUbicacion, en.IdTipoMovimiento, en.NumeroMovimiento,
                                                                en.Orden, en.IdProducto, en.NroSerie, en.Cantidad, en.Cantidad2)
         Case TipoSP._D
            sMSPNrosSerie.MovimientosStockProductosNrosSerie_D(en.IdSucursal, en.IdDeposito, en.IdUbicacion, en.IdTipoMovimiento, en.NumeroMovimiento)
      End Select
   End Sub
   Private Sub CargarUno(eMSPNS As Entidades.MovimientoStockProductoNrosSerie, dr As DataRow)
      With eMSPNS
         .IdSucursal = dr.Field(Of Integer)(Entidades.MovimientoStockProductoNrosSerie.Columnas.IdSucursal.ToString())
         .IdDeposito = dr.Field(Of Integer)(Entidades.MovimientoStockProductoNrosSerie.Columnas.IdDeposito.ToString())
         .IdUbicacion = dr.Field(Of Integer)(Entidades.MovimientoStockProductoNrosSerie.Columnas.IdUbicacion.ToString())
         .IdTipoMovimiento = dr.Field(Of String)(Entidades.MovimientoStockProductoNrosSerie.Columnas.IdTipoMovimiento.ToString())
         .NumeroMovimiento = dr.Field(Of Long)(Entidades.MovimientoStockProductoNrosSerie.Columnas.NumeroMovimiento.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.MovimientoStockProductoNrosSerie.Columnas.Orden.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.MovimientoStockProductoNrosSerie.Columnas.IdProducto.ToString())
         .NroSerie = dr.Field(Of String)(Entidades.MovimientoStockProductoNrosSerie.Columnas.NroSerie.ToString())
         .Cantidad = dr.Field(Of Decimal)(Entidades.MovimientoStockProductoNrosSerie.Columnas.Cantidad.ToString())
         .Cantidad2 = dr.Field(Of Decimal)(Entidades.MovimientoStockProductoNrosSerie.Columnas.Cantidad2.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub _Inserta(entidad As Entidades.MovimientoStockProductoNrosSerie)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualiza(entidad As Entidades.MovimientoStockProductoNrosSerie)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borra(entidad As Entidades.MovimientoStockProductoNrosSerie)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function GetAll() As DataTable
      Dim sMSPNrosSerie = New SqlServer.MovimientosStockProductosNrosSerie(da)
      Return sMSPNrosSerie.MovimientosStockProductosNrosSerie_GA()
   End Function
   Public Function GetTodos(idSucursal As Integer,
                            idDeposito As Integer,
                            idUbicacion As Integer,
                            idTipoMovimiento As String,
                            numeroMovimiento As Long,
                            orden As Integer,
                            idProducto As String) As List(Of Entidades.MovimientoStockProductoNrosSerie)

      Return CargaLista(New SqlServer.MovimientosStockProductosNrosSerie(da).MovimientosStockProductosNrosSerie_GA(idSucursal,
                                                                                                                   idDeposito,
                                                                                                                   idUbicacion,
                                                                                                                   idTipoMovimiento,
                                                                                                                   numeroMovimiento,
                                                                                                                   orden,
                                                                                                                   idProducto),
                        Sub(o, dr) CargarUno(o, dr),
                        Function() New Entidades.MovimientoStockProductoNrosSerie())
   End Function
   Public Function GetUno(idSucursal As Integer,
                          idDeposito As Integer,
                          idUbicacion As Integer,
                          idTipoMovimiento As String,
                          numeroMovimiento As Long,
                          orden As Integer,
                          idProducto As String,
                          nroSerie As String) As Entidades.MovimientoStockProductoNrosSerie

      Dim sMSPNrosSerie = New SqlServer.MovimientosStockProductosNrosSerie(da)

      Return CargaEntidad(sMSPNrosSerie.MovimientosStockProductosNrosSerie_G1(idSucursal, idDeposito, idUbicacion, idTipoMovimiento,
                                                                              numeroMovimiento, orden, idProducto, nroSerie),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MovimientoStockProductoNrosSerie(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Producto con Nro Serie: {0}", nroSerie))
   End Function
   Public Function GetUltimoNumeroDeMovimiento(idSucursal As Integer,
                                               idDeposito As Integer,
                                               idUbicacion As Integer,
                                               idTipoMovimiento As String) As Integer
      Return New SqlServer.MovimientosStockProductosNrosSerie(da).GetUltimoNumeroDeMovimiento(idSucursal, idDeposito, idUbicacion, idTipoMovimiento)
   End Function
#End Region

End Class
