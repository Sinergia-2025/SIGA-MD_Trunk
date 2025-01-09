Public Class PedidosProductosTiendasWeb
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.PedidoProductoTiendaWeb.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.PedidoProductoTiendaWeb.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoProductoTiendaWeb), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoProductoTiendaWeb), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoProductoTiendaWeb), TipoSP._D))
   End Sub

   Public Sub _Inserta(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoProductoTiendaWeb), TipoSP._I)
   End Sub

   Public Sub _Actualiza(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoProductoTiendaWeb), TipoSP._U)
   End Sub

   Public Sub _Borra(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoProductoTiendaWeb), TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return Nothing
   End Function

   Public Overloads Function GetAll(sistemaDestino As String, id As String) As DataTable
      Return New SqlServer.PedidosProductosTiendasWeb(da).PedidosProductosTiendasWeb_GA(sistemaDestino, id)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Me.GetAll(Nothing, Nothing)
   End Function

#End Region

#Region "Métodos Públicos"

   Public Function GetUno(id As String, sistemaDestino As String, idProductoTiendaWeb As String) As Entidades.PedidoProductoTiendaWeb
      Dim sPedidosProductosTiendasWeb As SqlServer.PedidosProductosTiendasWeb = New SqlServer.PedidosProductosTiendasWeb(da)
      Return CargaEntidad(sPedidosProductosTiendasWeb.PedidosProductosTiendasWeb_G1(id, sistemaDestino, idProductoTiendaWeb),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoProductoTiendaWeb(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Producto {0} {1} {2}", id, sistemaDestino, idProductoTiendaWeb))
   End Function

   Public Function GetTodos() As List(Of Entidades.PedidoProductoTiendaWeb)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) Me.CargarUno(o, dr),
                        Function() New Entidades.PedidoProductoTiendaWeb)
      Return Nothing
   End Function

   Public Function GetPedidosProductosAImportar(sistemaDestino As String, estados As String(), nroPedido As Long?, desde As DateTime?, hasta As DateTime?, tipoFechaFiltro As String) As DataTable
      Return New SqlServer.PedidosProductosTiendasWeb(da).GetPedidosProductosAImportar(sistemaDestino, estados, nroPedido, desde, hasta, tipoFechaFiltro)
   End Function
#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.PedidoProductoTiendaWeb, tipo As TipoSP)
      Dim sPedidosProductosTiendasWeb As SqlServer.PedidosProductosTiendasWeb = New SqlServer.PedidosProductosTiendasWeb(da)
      Select Case tipo
         Case TipoSP._I
            sPedidosProductosTiendasWeb.PedidosProductosTiendasWeb_I(en.Id, en.SistemaDestino, en.Numero, en.IdProductoTiendaWeb, en.NombreProductoTiendaWeb, en.Precio, en.Cantidad)
         Case TipoSP._U
            sPedidosProductosTiendasWeb.PedidosProductosTiendasWeb_U(en.Id, en.SistemaDestino, en.Numero, en.IdProductoTiendaWeb, en.Precio, en.Cantidad)
         Case TipoSP._D
            sPedidosProductosTiendasWeb.PedidosProductosTiendasWeb_D(en.Id, en.SistemaDestino, en.IdProductoTiendaWeb)
      End Select
   End Sub

   Private Sub CargarUno(ePedidoProductoTiendaWeb As Entidades.PedidoProductoTiendaWeb, dr As DataRow)
      With ePedidoProductoTiendaWeb
         .Id = dr.Field(Of String)(Entidades.PedidoProductoTiendaWeb.Columnas.Id.ToString())
         .SistemaDestino = dr.Field(Of String)(Entidades.PedidoProductoTiendaWeb.Columnas.SistemaDestino.ToString())
         .Numero = dr.Field(Of Long)(Entidades.PedidoProductoTiendaWeb.Columnas.Numero.ToString())
         .IdProductoTiendaWeb = dr.Field(Of String)(Entidades.PedidoProductoTiendaWeb.Columnas.IdProductoTiendaWeb.ToString())
         .NombreProductoTiendaWeb = dr.Field(Of String)(Entidades.PedidoProductoTiendaWeb.Columnas.NombreProductoTiendaWeb.ToString())
         .Precio = dr.Field(Of Decimal)(Entidades.PedidoProductoTiendaWeb.Columnas.Precio.ToString())
         .Cantidad = dr.Field(Of Decimal)(Entidades.PedidoProductoTiendaWeb.Columnas.Cantidad.ToString())
      End With
   End Sub

#End Region

End Class
