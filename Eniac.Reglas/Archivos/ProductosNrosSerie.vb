Public Class ProductosNrosSerie
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("ProductosNrosSerie", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.ProductoNroSerie)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualiza(DirectCast(entidad, Entidades.ProductoNroSerie)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borra(DirectCast(entidad, Entidades.ProductoNroSerie)))
   End Sub

   Public Sub _Inserta(entidad As Entidades.ProductoNroSerie)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualiza(entidad As Entidades.ProductoNroSerie)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borra(entidad As Entidades.ProductoNroSerie)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ProductosNrosSerie(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ProductosNrosSerie(da).ProductosNrosSerie_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProductoNroSerie, tipo As TipoSP)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      Select Case tipo
         Case TipoSP._I
            If Existe(en.Producto.IdProducto, en.NroSerie) Then
               Throw New Exception(String.Format("Existe el Nro. de Serie {0} para el producto {1}.", en.NroSerie, en.Producto.IdProducto))
            End If
            sql.ProductosNrosSerie_I(en.Producto.IdProducto, en.NroSerie, en.Sucursal.IdSucursal, en.IdDeposito, en.IdUbicacion,
                                     en.Vendido, en.TipoComprobante.IdTipoComprobante,
                                     en.Letra, en.CentroEmisor, en.NumeroComprobante, en.OrdenCompra, en.Proveedor.IdProveedor)
         Case TipoSP._U
            sql.ProductosNrosSerie_U(en.Producto.IdProducto, en.NroSerie, en.Sucursal.IdSucursal, en.TipoComprobante.IdTipoComprobante,
                                     en.Letra, en.CentroEmisor, en.NumeroComprobante, en.Vendido, en.OrdenVenta, en.OrdenCompra, en.FechaDevolucionVenta)
         Case TipoSP._D
            sql.ProductosNrosSerie_D(en.Producto.IdProducto, en.NroSerie)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.ProductoNroSerie, dr As DataRow)
      With o
         .Producto = New Productos(da).GetUno(dr.Field(Of String)(Entidades.ProductoNroSerie.Columnas.IdProducto.ToString()))
         .Sucursal = New Sucursales(da).GetUna(dr.Field(Of Integer)(Entidades.ProductoNroSerie.Columnas.IdSucursal.ToString()), False)
         .NroSerie = dr.Field(Of String)(Entidades.ProductoNroSerie.Columnas.NroSerie.ToString())
         .Vendido = dr.Field(Of Boolean)(Entidades.ProductoNroSerie.Columnas.Vendido.ToString())
         .OrdenCompra = dr.Field(Of Integer?)(Entidades.ProductoNroSerie.Columnas.OrdenCompra.ToString())
         .OrdenVenta = dr.Field(Of Integer?)(Entidades.ProductoNroSerie.Columnas.OrdenVenta.ToString())
         .FechaDevolucionVenta = dr.Field(Of Date?)(Entidades.ProductoNroSerie.Columnas.FechaDevolucionVenta.ToString())

         Dim idProveedor = dr.Field(Of Long?)(Entidades.Proveedor.Columnas.IdProveedor.ToString())
         If idProveedor.HasValue Then
            .Proveedor = New Proveedores(da)._GetUno(idProveedor.Value)
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub ActualizaCambioSucursal(idProducto As String, nroSerie As String, idSucursal As Integer)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      sql.ProductosNrosSerie_U_CambioSucursal(idProducto, nroSerie, idSucursal)
   End Sub

   Public Sub InsertoVariosNrosSerie(productosNrosSerie As List(Of Entidades.ProductoNroSerie))
      For Each ps In productosNrosSerie
         EjecutaSP(ps, TipoSP._I)
      Next
   End Sub

   Public Function GetTodos() As List(Of Entidades.ProductoNroSerie)
      Return EjecutaConConexion(Function() CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoNroSerie()))
   End Function

   Public Function GetUno(idProducto As String, nroSerie As String) As Entidades.ProductoNroSerie
      Return EjecutaConConexion(Function() _GetUno(idProducto, nroSerie, AccionesSiNoExisteRegistro.Nulo))
   End Function
   Public Function GetUno(idProducto As String, nroSerie As String, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoNroSerie
      Return EjecutaConConexion(Function() _GetUno(idProducto, nroSerie, accion))
   End Function

   Friend Function _GetUno(idProducto As String, nroSerie As String, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoNroSerie
      Return CargaEntidad(New SqlServer.ProductosNrosSerie(da).ProductosNrosSerie_G1(idProducto, nroSerie),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoNroSerie(),
                          accion, Function() String.Format("No existe el Nro. de Serie {0} para el producto {1}.", nroSerie, idProducto))
   End Function

   Public Sub EliminarNrosSerie(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                idProveedor As Long)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      sql.ProductosNrosSerie_DComp(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
   End Sub

   Public Sub ProductosNrosSerie_UDevolucion(idProducto As String, nroSerie As String)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      sql.ProductosNrosSerie_UDevolucion(idProducto, nroSerie)
   End Sub
   Public Sub ActualizaVendidoMPPorGeneraPT(idProducto As String, nroSerie As String)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      sql.ProductosNrosSerie_U_VendidoMPPorGeneraPT(idProducto, nroSerie, True)
   End Sub
   Public Sub ActualizaDepositoVendido(idProducto As String, nroSerie As String, iddeposito As Integer,
                                       idubicacion As Integer, vendido As Boolean)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      sql.ProductosNrosSerie_U_DepositoVendido(idProducto, nroSerie, iddeposito, idubicacion, vendido)
   End Sub

   Public Sub ActualizarNrosSerie(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      sql.ProductosNrosSerie_UVenta(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Sub
   Public Sub ActualizarComprobantePorComprobanteDeNrosSerie(vtaActual As Entidades.Venta, vtaNueva As Entidades.Venta)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      sql.ProductosNrosSerie_ActualizarComprobantePorComprobante(vtaActual.IdSucursal,
                  vtaActual.IdTipoComprobante, vtaActual.LetraComprobante, vtaActual.CentroEmisor, vtaActual.NumeroComprobante,
                  vtaNueva.IdTipoComprobante, vtaNueva.LetraComprobante, vtaNueva.CentroEmisor, vtaNueva.NumeroComprobante)
   End Sub
   Public Sub EliminarNroSerie(idProducto As String, nroSerie As String)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      sql.ProductosNrosSerie_D(idProducto, nroSerie)
   End Sub

   Public Function GetVendidos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                               idProveedor As Long) As DataTable
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      Return sql.GetVendidos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
   End Function

   Public Function GetVendido(idProducto As String, nroSerie As String) As DataTable
      Throw New NotImplementedException("El método GetVendido no está correctamente implementado, si lo está usando por favor revise la lógica del mismo.")
      'Dim sql As SqlServer.ProductosNrosSerie = New SqlServer.ProductosNrosSerie(da)

      'Dim dt As DataTable
      'dt = sql.GetVendido(IdProducto, NroSerie)

      'Return dt

   End Function
   '-- REQ-32489.- ---------------------------------------------------------
   Public Function GetNrosSerieProducto(eSucursal As Entidades.Sucursal, idDeposito As Integer, idUbicacion As Integer, idProducto As String) As DataTable
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      'Dim oSucursal As String
      'If Not String.IsNullOrEmpty(eSucursal.IdSucursalAsociada.ToString()) Then
      '   oSucursal = String.Format("({0},{1})", eSucursal.IdSucursal.ToString(), eSucursal.IdSucursalAsociada.ToString())
      'Else
      '   oSucursal = String.Format("({0})", eSucursal.IdSucursal.ToString())
      'End If
      Return sql.GetNrosSerieProducto(eSucursal.IdSucursal, idDeposito, idUbicacion, idProducto)
      '-----------------------------------------------------------------------
   End Function
   Public Function GetNrosSerieProducto(eSucursal As Entidades.Sucursal, idDeposito As Integer, idUbicacion As Integer, idProducto As String, nrosSerie As List(Of String)) As DataTable
      Return GetNrosSerieProducto(eSucursal, idDeposito, idUbicacion, idProducto, nrosSerie, Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Function GetNrosSerieProducto(eSucursal As Entidades.Sucursal, idDeposito As Integer, idUbicacion As Integer, idProducto As String, nrosSerie As IEnumerable(Of String), vendido As Entidades.Publicos.SiNoTodos) As DataTable
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      Return sql.GetNrosSerieProducto(eSucursal.IdSucursal, idDeposito, idUbicacion, idProducto, nrosSerie, vendido)
      '-----------------------------------------------------------------------
   End Function

   Public Function GetNrosSerieProducto_Comprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                                    idProveedor As Long, idProducto As String) As List(Of Entidades.ProductoNroSerie)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      Using dt = sql.GetNrosSerieProducto_Comprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                      idProveedor, idProducto)
         Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoNroSerie())
      End Using
   End Function

   Public Function GetNrosSerieProducto_ComprobanteVenta(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                                         idProducto As String) As List(Of Entidades.ProductoNroSerie)
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      Using dt = sql.GetNrosSerieProducto_ComprobanteVenta(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto)
         Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoNroSerie())
      End Using
   End Function

   Public Function GetNrosSerieProductoConsulta(idSucursal As Integer, idProducto As String,
                                                marca As Integer, rubro As Integer, idSubRubro As Integer,
                                                vendidos As Boolean, todos As Boolean, enStock As Boolean) As DataTable
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      Return sql.GetNrosSerieProductoConsulta(idSucursal, idProducto, marca, rubro, idSubRubro, vendidos, todos, enStock)
   End Function

   Public Function GetNrosSerieProductoClienteVendido(idSucursal As Integer, idProducto As String, idCliente As Long) As DataTable
      Dim sql = New SqlServer.ProductosNrosSerie(da)
      Return sql.GetNrosSerieProductoClienteVendido(idSucursal, idProducto, idCliente)
   End Function

   Public Function EstaVendido(idProducto As String, nroSerie As String, vendido As Boolean) As Boolean
      Return New SqlServer.ProductosNrosSerie(da).EstaVendido(idProducto, nroSerie, vendido)
   End Function

   Public Function GetEstadoComprobanteAnteriorAFecha(idSucursal As Integer, idTipoComprobante As String,
                                                      idProducto As String, nroSerie As String,
                                                      fecha As Date, esDeVenta As Boolean) As DataTable
      Return New SqlServer.ProductosNrosSerie(da).GetEstadoComprobanteAnteriorAFecha(idSucursal, idTipoComprobante,
                                                                                     idProducto, nroSerie,
                                                                                     fecha, esDeVenta)
   End Function

   Public Function Existe(idProducto As String, nroSerie As String) As Boolean
      Return New SqlServer.ProductosNrosSerie(da).Existe(idProducto, nroSerie)
   End Function

#End Region

End Class