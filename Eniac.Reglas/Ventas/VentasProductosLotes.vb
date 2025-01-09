Public Class VentasProductosLotes
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("VentasProductosLotes", accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.VentaProductoLote)))
   End Sub
#End Region

#Region "Metodos"
   Public Sub _Inserta(ent As Entidades.VentaProductoLote)
      EjecutaSP(ent, TipoSP._I)
   End Sub
   Public Sub _Actualiza(ent As Entidades.VentaProductoLote)
      Throw New NotImplementedException()
   End Sub
   Public Sub _Borra(ent As Entidades.VentaProductoLote)
      EjecutaSP(ent, TipoSP._D)
   End Sub
   Friend Sub EjecutaSP(ent As Entidades.VentaProductoLote, tipo As TipoSP)
      Dim sql = New SqlServer.VentasProductosLotes(da)
      Select Case tipo
         Case TipoSP._I
            sql.VentasProductosLotes_I(ent.IdSucursal, ent.TipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                       ent.Producto.IdProducto, ent.IdLote,
                                       ent.IdDeposito, ent.IdUbicacion,
                                       ent.FechaVencimiento, ent.Cantidad, ent.Orden)
         'Case TipoSP._U
         Case TipoSP._D
            sql.VentasProductosLotes_D(ent.IdSucursal, ent.TipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                       ent.Producto.IdProducto, ent.IdLote, ent.Orden)
      End Select
   End Sub

   Public Function GetUna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idProducto As String, idLote As String) As Entidades.VentaProductoLote
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden:=0, idLote, idProducto),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaProductoLote(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() "No existe este comprobante de Lotes de Productos de Venta.")
   End Function
   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer) As DataTable
      Return Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                  orden, idLote:=String.Empty, idProducto:=String.Empty)
   End Function
   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                        orden As Integer, idLote As String, idProducto As String) As DataTable
      Return New SqlServer.VentasProductosLotes(da).Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden, idLote, idProducto)
   End Function

   Public Overrides Function GetAll() As DataTable
      Return GetAll(idSucursal:=0, idTipoComprobante:=Nothing, letra:=Nothing, centroEmisor:=Nothing, numeroComprobante:=0, idProducto:=Nothing, orden:=0)
   End Function

   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProducto As String, orden As Integer) As DataTable
      Return New SqlServer.VentasProductosLotes(da).GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden)
   End Function

   Private Sub CargarUno(o As Entidades.VentaProductoLote, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")
         .TipoComprobante = dr.Field(Of String)("IdTipoComprobante")
         .Letra = dr.Field(Of String)("Letra")
         .CentroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
         .NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")
         .Orden = dr.Field(Of Integer)("Orden")
         .Producto = New Productos(da).GetUno(dr.Field(Of String)("IdProducto"))
         .IdLote = dr.Field(Of String)("idLote")
         .FechaVencimiento = dr.Field(Of Date?)("FechaVencimiento")
         .Cantidad = dr.Field(Of Decimal)("Cantidad")
         .IdDeposito = dr.Field(Of Integer)("IdDeposito")
         .IdUbicacion = dr.Field(Of Integer)("IdUbicacion")
      End With
   End Sub

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                            idProducto As String, orden As Integer) As List(Of Entidades.VentaProductoLote)
      Return CargaLista(GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaProductoLote())
   End Function
#End Region

End Class