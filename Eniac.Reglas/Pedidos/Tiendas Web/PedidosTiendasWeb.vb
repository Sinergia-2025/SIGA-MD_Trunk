Public Class PedidosTiendasWeb
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.PedidoTiendaWeb.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.PedidoTiendaWeb.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoTiendaWeb), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoTiendaWeb), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoTiendaWeb), TipoSP._D))
   End Sub

   Public Sub _Inserta(entidad As Entidades.Entidad)
      Me._Inserta(entidad, soloTransaccion:=False)
   End Sub

   Public Sub _Inserta(entidad As Entidades.Entidad, soloTransaccion As Boolean)
      If soloTransaccion Then
         Me.EjecutaSoloConTransaccion(Function()
                                         Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoTiendaWeb), TipoSP._I)
                                         Return True
                                      End Function)
      Else
         Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoTiendaWeb), TipoSP._I)
      End If
   End Sub

   Public Sub _Actualiza(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoTiendaWeb), TipoSP._U)
   End Sub

   Public Sub _Borra(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.PedidoTiendaWeb), TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return Nothing
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sPedidosTiendasWeb As SqlServer.PedidosTiendasWeb = New SqlServer.PedidosTiendasWeb(da)
      Return sPedidosTiendasWeb.PedidosTiendasWeb_GA()
   End Function

#End Region

#Region "Métodos Públicos"

   Public Function GetUno(id As String, sistemaDestino As String) As Entidades.PedidoTiendaWeb
      Dim sPedidosTiendasWeb As SqlServer.PedidosTiendasWeb = New SqlServer.PedidosTiendasWeb(da)
      Return CargaEntidad(sPedidosTiendasWeb.PedidosTiendasWeb_G1(id, sistemaDestino),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoTiendaWeb(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Pedido: {0} {1}", id, sistemaDestino))
   End Function

   Public Function GetTodos() As List(Of Entidades.PedidoTiendaWeb)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) Me.CargarUno(o, dr),
                        Function() New Entidades.PedidoTiendaWeb)
      Return Nothing
   End Function

   Public Function GetMaxId(sistemaDestino As String) As Long
      Dim dt As DataTable = New SqlServer.PedidosTiendasWeb(da).GetMaxId(sistemaDestino)
      If dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0)("Id")) Then Return Convert.ToInt64(dt.Rows(0)("Id").ToString())
      Return 0
   End Function

   Public Function ExistePedido(id As String, sistemaDestino As String) As Boolean
      Return New SqlServer.PedidosTiendasWeb(da).ExistePedido(id, sistemaDestino)
   End Function

   Public Function GetPedidosAImportar(sistemaDestino As String, estados As String(), nroPedido As Long?, desde As DateTime?, hasta As DateTime?, tipoFechaFiltro As String) As DataTable
      Return New SqlServer.PedidosTiendasWeb(da).GetPedidosAImportar(sistemaDestino, estados, nroPedido, desde, hasta, tipoFechaFiltro)
   End Function

   Public Sub _ActualizarEstadoPedidoTiendaWeb(id As String, sistemaDestino As String, estado As String, quitarMensajeError As Boolean)
      Me.EjecutaConTransaccion(Sub() ActualizarEstadoPedidoTiendaWeb(id, sistemaDestino, estado, quitarMensajeError))
   End Sub

   Public Sub ActualizarEstadoPedidoTiendaWeb(id As String, sistemaDestino As String, estado As String, quitarMensajeError As Boolean)
      Dim sql As New SqlServer.PedidosTiendasWeb(da)
      sql.ActualizarEstadoPedidoTiendaWeb(id, sistemaDestino, estado, quitarMensajeError)
   End Sub
#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.PedidoTiendaWeb, tipo As TipoSP)
      Dim sPedidosTiendasWeb As SqlServer.PedidosTiendasWeb = New SqlServer.PedidosTiendasWeb(da)
      Select Case tipo
         Case TipoSP._I
            sPedidosTiendasWeb.PedidosTiendasWeb_I(en.Id, en.SistemaDestino, en.Numero, en.IdClienteTiendaWeb, en.NombreClienteTiendaWeb, en.ObservacionesTiendaWeb, en.IdMoneda,
                                                   en.TipoEnvio, en.DireccionEnvio, en.FechaPedido, en.CostoEnvio, en.ImporteTotal, en.SubTotal, en.IdUsuarioEstado, en.FechaEstado,
                                                   en.IdUsuarioDescarga, en.FechaDescarga, en.IdEstadoPedidoTiendaWeb, en.MensajeError, en.JSON, en.NroDocCliente, en.Email, en.Telefono,
                                                   en.DireccionCalle, en.DireccionNumero, en.Adicional, en.CodigoPostal, en.Localidad, en.Provincia, en.Observacion, en.PacksIdTiendaWeb)

            '# Productos
            Dim rPPTW As Reglas.PedidosProductosTiendasWeb = New Reglas.PedidosProductosTiendasWeb(da)
            For Each p As Entidades.PedidoProductoTiendaWeb In en.Productos
               rPPTW._Inserta(p)
            Next

         Case TipoSP._U
            sPedidosTiendasWeb.PedidosTiendasWeb_U(en.Id, en.SistemaDestino, en.Numero, en.IdClienteTiendaWeb, en.NombreClienteTiendaWeb, en.ObservacionesTiendaWeb, en.IdMoneda,
                                                   en.TipoEnvio, en.DireccionEnvio, en.FechaPedido, en.CostoEnvio, en.ImporteTotal, en.SubTotal, en.IdUsuarioEstado, en.FechaEstado,
                                                   en.IdUsuarioDescarga, en.FechaDescarga, en.IdEstadoPedidoTiendaWeb, en.MensajeError, en.JSON, en.NroDocCliente, en.Email, en.Telefono,
                                                   en.DireccionCalle, en.DireccionNumero, en.Adicional, en.CodigoPostal, en.Localidad, en.Provincia, en.Observacion, en.PacksIdTiendaWeb)
         Case TipoSP._D
            sPedidosTiendasWeb.PedidosTiendasWeb_D(en.Id, en.SistemaDestino)
      End Select
   End Sub

   Private Sub CargarUno(ePedidoTiendaWeb As Entidades.PedidoTiendaWeb, dr As DataRow)
      With ePedidoTiendaWeb
         .Id = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString())
         .SistemaDestino = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.SistemaDestino.ToString())
         .Numero = dr.Field(Of Long)(Entidades.PedidoTiendaWeb.Columnas.Numero.ToString())
         .IdClienteTiendaWeb = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdClienteTiendaWeb.ToString())
         .NombreClienteTiendaWeb = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.NombreClienteTiendaWeb.ToString())
         .ObservacionesTiendaWeb = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.ObservacionesTiendaWeb.ToString())
         .IdMoneda = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdMoneda.ToString())
         .TipoEnvio = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.TipoEnvio.ToString())
         .DireccionEnvio = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionEnvio.ToString())
         .FechaPedido = dr.Field(Of DateTime)(Entidades.PedidoTiendaWeb.Columnas.FechaPedido.ToString())
         .CostoEnvio = dr.Field(Of Decimal)(Entidades.PedidoTiendaWeb.Columnas.CostoEnvio.ToString())
         .ImporteTotal = dr.Field(Of Decimal)(Entidades.PedidoTiendaWeb.Columnas.ImporteTotal.ToString())
         .SubTotal = dr.Field(Of Decimal)(Entidades.PedidoTiendaWeb.Columnas.SubTotal.ToString())
         .IdUsuarioEstado = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdUsuarioEstado.ToString())
         .FechaEstado = dr.Field(Of DateTime)(Entidades.PedidoTiendaWeb.Columnas.FechaEstado.ToString())
         .IdUsuarioDescarga = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdUsuarioDescarga.ToString())
         .FechaDescarga = dr.Field(Of DateTime)(Entidades.PedidoTiendaWeb.Columnas.FechaDescarga.ToString())
         .IdEstadoPedidoTiendaWeb = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdEstadoPedidoTiendaWeb.ToString())
         .MensajeError = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.MensajeError.ToString())
         .JSON = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.JSON.ToString())
         .NroDocCliente = dr.Field(Of Long?)(Entidades.PedidoTiendaWeb.Columnas.NroDocCliente.ToString())
         .Email = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Email.ToString())
         .Telefono = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Telefono.ToString())
         .DireccionCalle = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionCalle.ToString())
         .DireccionNumero = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionNumero.ToString())
         .Adicional = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Adicional.ToString())
         .CodigoPostal = dr.Field(Of Integer?)(Entidades.PedidoTiendaWeb.Columnas.CodigoPostal.ToString())
         .Localidad = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Localidad.ToString())
         .Provincia = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Provincia.ToString())
         .Observacion = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.ObservacionesTiendaWeb.ToString())
         .PacksIdTiendaWeb = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.PacksIdTiendaWeb.ToString())
      End With
   End Sub

   Public Sub GrabarMensajeError(id As String, sistemaDestino As String, mensaje As String)
      Me.EjecutaSoloConTransaccion(Function()
                                      Me._GrabarMensajeError(id, sistemaDestino, mensaje)
                                      Return True
                                   End Function)
   End Sub

   Public Sub _GrabarMensajeError(id As String, sistemaDestino As String, mensaje As String)
      Dim sql As SqlServer.PedidosTiendasWeb = New SqlServer.PedidosTiendasWeb(da)
      sql.GrabarMensajeError(id, sistemaDestino, mensaje)
   End Sub

#End Region

End Class
