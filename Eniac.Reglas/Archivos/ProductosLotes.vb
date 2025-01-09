Public Class ProductosLotes

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ProductosLotes"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProductoLote), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProductoLote), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProductoLote), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ProductosLotes(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ProductosLotes(da).ProductosLotes_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Public Sub EjecutaSP(en As Entidades.ProductoLote, tipo As TipoSP)
      Dim sql = New SqlServer.ProductosLotes(da)
      Select Case tipo
         Case TipoSP._I
            sql.ProductosLotes_I(en.IdLote, en.ProductoSucursal.Producto.IdProducto,
                                 en.ProductoSucursal.Sucursal.IdSucursal, en.IdDeposito, en.IdUbicacion,
                                 en.FechaIngreso, en.FechaVencimiento,
                                 en.CantidadInicial, en.CantidadActual,
                                 en.Habilitado,
                                 en.PrecioCosto)
         Case TipoSP._U
            sql.ProductosLotes_U(en.IdLote, en.ProductoSucursal.Producto.IdProducto,
                                 en.ProductoSucursal.Sucursal.IdSucursal, en.IdDeposito, en.IdUbicacion,
                                 en.FechaIngreso, en.FechaVencimiento,
                                 en.CantidadInicial, en.CantidadActual,
                                 en.Habilitado,
                                 en.PrecioCosto)
         Case TipoSP._D
            sql.ProductosLotes_D(en.ProductoSucursal.Producto.IdProducto, en.IdLote, en.ProductoSucursal.Sucursal.IdSucursal, en.IdDeposito, en.IdUbicacion)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.ProductoLote, dr As DataRow, cargaProductoSucursal As Boolean)
      With o
         .IdLote = dr.Field(Of String)(Entidades.ProductoLote.Columnas.IdLote.ToString())
         If cargaProductoSucursal Then
            .ProductoSucursal = New ProductosSucursales(da)._GetUno(dr.Field(Of Integer)(Entidades.ProductoLote.Columnas.IdSucursal.ToString()),
                                                                    dr.Field(Of String)(Entidades.ProductoLote.Columnas.IdProducto.ToString()))
         End If
         .IdDeposito = dr.Field(Of Integer)(Entidades.ProductoLote.Columnas.IdDeposito.ToString())
         .IdUbicacion = dr.Field(Of Integer)(Entidades.ProductoLote.Columnas.IdUbicacion.ToString())
         .FechaIngreso = dr.Field(Of Date)(Entidades.ProductoLote.Columnas.FechaIngreso.ToString())
         .FechaVencimiento = dr.Field(Of Date?)(Entidades.ProductoLote.Columnas.FechaVencimiento.ToString())
         .CantidadInicial = dr.Field(Of Decimal)(Entidades.ProductoLote.Columnas.CantidadInicial.ToString())
         .CantidadActual = dr.Field(Of Decimal)(Entidades.ProductoLote.Columnas.CantidadActual.ToString())
         .Habilitado = dr.Field(Of Boolean)(Entidades.ProductoLote.Columnas.Habilitado.ToString())
         .PrecioCosto = dr.Field(Of Decimal)(Entidades.ProductoLote.Columnas.PrecioCosto.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Friend"

   Public Function Get1(idProducto As String, idLote As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer) As DataRow
      Return New SqlServer.ProductosLotes(da).ProductosLotes_G1(idProducto, idLote, idSucursal, idDeposito, idUbicacion).FirstOrDefault()
   End Function
   Public Function _GetUno(idProducto As String, idLote As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer) As Entidades.ProductoLote
      Return _GetUno(idProducto, idLote, idSucursal, idDeposito, idUbicacion, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function _GetUno(idProducto As String, idLote As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoLote
      Return _GetUno(idProducto, idLote, idSucursal, idDeposito, idUbicacion, cargaProductoSucursal:=True, accion:=accion)
   End Function
   Public Function _GetUno(idProducto As String, idLote As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, cargaProductoSucursal As Boolean, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoLote
      Return CargaEntidad(New SqlServer.ProductosLotes(da).ProductosLotes_G1(idProducto, idLote, idSucursal, idDeposito, idUbicacion),
                          Sub(o, dr) CargarUno(o, dr, cargaProductoSucursal), Function() New Entidades.ProductoLote(),
                          accion, Function() String.Format("No existe Lote {0} para el producto {1} en la sucursal {2}, deposito {3} y ubicación {4}", idLote, idProducto, idSucursal, idDeposito, idUbicacion))
   End Function

#End Region

#Region "Metodos Publicos"

   Public Sub ProductosLotes_UCantidadActual(idLote As String, idProducto As String,
                                             idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                             cantidadActual As Decimal)
      Dim sql = New SqlServer.ProductosLotes(da)
      sql.ProductosLotes_UCantidadActual(idLote, idProducto, idSucursal, idDeposito, idUbicacion, cantidadActual)
   End Sub
   Public Sub ProductosLotes_UCantidad_Delta(idLote As String, idSucursal As Integer, idProducto As String, cantidad As Decimal)
      Dim sql = New SqlServer.ProductosLotes(da)
      sql.ProductosLotes_UCantidadActual_Delta(idLote, idSucursal, idProducto, cantidad)
   End Sub

   Public Sub ActualizoLotes(productosLotes As List(Of Entidades.ProductoLote))
      Dim pl1 As Entidades.ProductoLote
      For Each pl As Entidades.ProductoLote In productosLotes
         'tengo que controlar si el lote existe, en ese caso que lo actualice ya que un proveedor puede enviar
         'en varias facturas productos de un mismo lote
         pl1 = Me._GetUno(pl.ProductoSucursal.Producto.IdProducto, pl.IdLote, pl.ProductoSucursal.Sucursal.IdSucursal, pl.IdDeposito, pl.IdUbicacion)
         If pl1 Is Nothing Then
            EjecutaSP(pl, TipoSP._I)
         Else
            If pl1.CantidadInicial <> 0 Then
               pl.CantidadInicial += pl1.CantidadInicial
            End If
            pl.CantidadActual += pl1.CantidadActual
            If pl.CantidadActual < 0 Then
               Throw New Exception("El Lote '" & pl.IdLote & "' tiene en Stock " & pl1.CantidadActual.ToString() & " quedaría en Cantidad Negativa en caso de Restarle " & Math.Abs(pl.CantidadActualOriginal).ToString() & ".")
            End If
            EjecutaSP(pl, TipoSP._U)
         End If
      Next
   End Sub

   Public Function GetLoteMasViejoADescontar(idProducto As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer) As Entidades.ProductoLote
      Return CargaEntidad(New SqlServer.ProductosLotes(da).GetLoteMasViejoADescontar(idProducto, idSucursal, idDeposito, idUbicacion),
                          Sub(o, dr) CargarUno(o, dr, cargaProductoSucursal:=True), Function() New Entidades.ProductoLote(),
                          accion:=AccionesSiNoExisteRegistro.Vacio, Function() String.Empty)
   End Function

   Public Function GetTodos() As List(Of Entidades.ProductoLote)
      Return EjecutaConTransaccion(
         Function()
            Return CargaLista(GetAll(),
                              Sub(o, dr) CargarUno(o, dr, cargaProductoSucursal:=True), Function() New Entidades.ProductoLote())
         End Function)
   End Function
   Public Function GetTodos(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, parteIdLote As String, validarStock As Boolean) As List(Of Entidades.ProductoLote)
      Return CargaLista(New SqlServer.ProductosLotes(da).GetPorProducto(idSucursal, idDeposito, idUbicacion, idProducto, parteIdLote, validarStock),
                        Sub(o, dr) CargarUno(o, dr, cargaProductoSucursal:=True), Function() New Entidades.ProductoLote())
   End Function

   Public Function GetUno(idProducto As String, idLote As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer) As Entidades.ProductoLote
      Return EjecutaConConexion(Function() _GetUno(idProducto, idLote, idSucursal, idDeposito, idUbicacion))
   End Function


   Public Function GetFiltradoPorId(idLote As String, idSucursal As Integer) As System.Data.DataTable
      Return New SqlServer.ProductosLotes(da).GetFiltradoPorId(idLote, idSucursal)
   End Function

   Public Function GetPorProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, parteIdLote As String) As DataTable
      Return EjecutaConConexion(Function() _GetPorProducto(idSucursal, idDeposito, idUbicacion, idProducto, parteIdLote))
   End Function
   Public Function GetPorProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, parteIdLote As String, validarStock As Boolean) As DataTable
      Return EjecutaConConexion(Function() _GetPorProducto(idSucursal, idDeposito, idUbicacion, idProducto, parteIdLote, validarStock))
   End Function
   'Public Function GetPorProducto(idSucursal As Integer, idProducto As String, parteIdLote As String, validarStock As Boolean) As DataTable
   '   Return EjecutaConConexion(Function() _GetPorProducto(idSucursal, idDeposito:=0, idUbicacion:=0, idProducto, parteIdLote, validarStock))
   'End Function

   Private Function _GetPorProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, parteIdLote As String) As DataTable
      Return _GetPorProducto(idSucursal, idDeposito, idUbicacion, idProducto, parteIdLote, validarStock:=False)
   End Function

   Private Function _GetPorProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, parteIdLote As String, validarStock As Boolean) As DataTable
      Return New SqlServer.ProductosLotes(da).GetPorProducto(idSucursal, idDeposito, idUbicacion, idProducto, parteIdLote, validarStock)
   End Function

   Public Function GetDisponiblePorProducto(idSucursal As Integer, idProducto As String) As Decimal
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.ProductosLotes(da)

            Using dt = sql.GetPorProducto(idSucursal, idDeposito:=0, idUbicacion:=0, idProducto, parteIdLote:=String.Empty, validarStock:=True)
               Return dt.AsEnumerable().Sum(Function(dr) dr.Field(Of Decimal?)("CantidadActual").IfNull())
            End Using
         End Function)
   End Function

   Public Sub EliminarLote(o As Entidades.ProductoLote)
      Dim sql = New SqlServer.ProductosLotes(da)
      sql.ProductosLotes_D(o.ProductoSucursal.Producto.IdProducto, o.IdLote, o.ProductoSucursal.Sucursal.IdSucursal, o.IdDeposito, o.IdUbicacion)
   End Sub


   Public Sub LimpiarLote(o As Entidades.ProductoLote)
      Dim sql = New SqlServer.ProductosLotes(da)
      sql.LimpiarLote(o.ProductoSucursal.Producto.IdProducto, o.IdLote, o.ProductoSucursal.Sucursal.IdSucursal, o.IdDeposito, o.IdUbicacion)
   End Sub

   Public Function GetStockLote(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, idLote As String) As Decimal
      Return New SqlServer.ProductosLotes(da).GetStockLote(idSucursal, idDeposito, idUbicacion, idProducto, idLote)
   End Function
#End Region

End Class