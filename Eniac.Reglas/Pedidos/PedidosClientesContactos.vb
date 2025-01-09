Public Class PedidosClientesContactos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "PedidosClientesContactos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.PedidoClienteContacto)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.PedidoClienteContacto)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.PedidoClienteContacto)))
   End Sub

   Public Sub Inserta(entidad As Entidades.PedidoClienteContacto)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(entidad As Entidades.PedidoClienteContacto)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Borra(entidad As Entidades.PedidoClienteContacto)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.PedidosClientesContactos(da).PedidosClientesContactos_GA()
   End Function

   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long) As DataTable
      Return New SqlServer.PedidosClientesContactos(da).PedidosClientesContactos_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.PedidoClienteContacto, tipo As TipoSP)
      Dim sqlC = New SqlServer.PedidosClientesContactos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.PedidosClientesContactos_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroPedido, en.IdCliente, en.IdContacto)
         Case TipoSP._U
            sqlC.PedidosClientesContactos_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroPedido, en.IdCliente, en.IdContacto)
         Case TipoSP._D
            sqlC.PedidosClientesContactos_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroPedido, en.IdCliente, en.IdContacto)
      End Select
   End Sub

   Public Sub InsertaContactosDesdePedido(pedido As Entidades.Pedido)
      For Each contacto In pedido.PedidosContactos
         contacto.IdSucursal = pedido.IdSucursal
         contacto.IdTipoComprobante = pedido.IdTipoComprobante
         contacto.Letra = pedido.LetraComprobante
         contacto.CentroEmisor = pedido.CentroEmisor
         contacto.NumeroPedido = pedido.NumeroPedido
         Inserta(contacto)
      Next
   End Sub
   Public Sub ActualizaContactosDesdePedido(pedido As Entidades.Pedido)
      BorraContactosDesdePedido(pedido)
      InsertaContactosDesdePedido(pedido)
   End Sub
   Public Sub BorraContactosDesdePedido(pedido As Entidades.Pedido)
      Borra(New Entidades.PedidoClienteContacto() With
            {
               .IdSucursal = pedido.IdSucursal,
               .IdTipoComprobante = pedido.IdTipoComprobante,
               .Letra = pedido.LetraComprobante,
               .CentroEmisor = pedido.CentroEmisor,
               .NumeroPedido = pedido.NumeroPedido
            })
   End Sub
   Private Sub CargarUno(o As Entidades.PedidoClienteContacto, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.PedidoClienteContacto.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.PedidoClienteContacto.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.PedidoClienteContacto.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.PedidoClienteContacto.Columnas.CentroEmisor.ToString()).ToShort()
         .NumeroPedido = dr.Field(Of Integer)(Entidades.PedidoClienteContacto.Columnas.NumeroPedido.ToString())
         If IsNumeric(dr(Entidades.PedidoClienteContacto.Columnas.IdCliente.ToString())) And
            IsNumeric(dr(Entidades.PedidoClienteContacto.Columnas.IdContacto.ToString())) Then
            .Contacto = New Reglas.ClientesContactos(da).GetUno(dr.Field(Of Long)(Entidades.PedidoClienteContacto.Columnas.IdCliente.ToString()),
                                                                dr.Field(Of Integer)(Entidades.PedidoClienteContacto.Columnas.IdContacto.ToString()))
         End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long,
                          idCliente As Long, idContacto As Integer) As Entidades.PedidoClienteContacto
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idCliente, idContacto, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long,
                          idCliente As Long, idContacto As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.PedidoClienteContacto
      Return CargaEntidad(New SqlServer.PedidosClientesContactos(da).PedidosClientesContactos_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                                                                 idCliente, idContacto),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoClienteContacto(),
                          accion, Function() String.Format("No existe contacto para el pedido/cliente {0}/{1} {2} {3:0000}-{4:00000000}, id cliente {5} orden {6}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idCliente, idContacto))
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long) As List(Of Entidades.PedidoClienteContacto)
      Return CargaLista(GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoClienteContacto())
   End Function

   Public Function GetContactosCliente(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Return New SqlServer.PedidosClientesContactos(da).PedidosClientesContactos_GetParaInforme(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function

#End Region
End Class