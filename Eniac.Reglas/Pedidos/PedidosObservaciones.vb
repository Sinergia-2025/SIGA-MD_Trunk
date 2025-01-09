Public Class PedidosObservaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "PedidosObservaciones"
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.PedidoObservacion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.PedidoObservacion)))
   End Sub
   <Obsolete("Usar GetAll(Integer, String, String, Integer, Long", True)>
   Public Overrides Function GetAll() As DataTable
      Return MyBase.GetAll()
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As DataTable
      Return New SqlServer.PedidosObservaciones(da).PedidosObservaciones_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
   End Function
#End Region

#Region "Metodos"

   Public Sub Inserta(entidad As Entidades.PedidoObservacion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Borra(entidad As Entidades.PedidoObservacion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub Borra(pedido As Entidades.Pedido)
      Borra(New Entidades.PedidoObservacion() With
            {
               .IdSucursal = pedido.IdSucursal,
               .IdTipoComprobante = pedido.IdTipoComprobante,
               .Letra = pedido.LetraComprobante,
               .CentroEmisor = pedido.CentroEmisor,
               .NumeroPedido = pedido.NumeroPedido
            })
   End Sub

   Public Sub InsertaObservacionesDesdePedido(oPedidos As Entidades.Pedido)
      Dim orden As Integer = 0
      For Each observacion As Entidades.PedidoObservacion In oPedidos.PedidosObservaciones
         orden += 1
         observacion.IdSucursal = oPedidos.IdSucursal
         observacion.IdTipoComprobante = oPedidos.IdTipoComprobante
         observacion.Letra = oPedidos.LetraComprobante
         observacion.CentroEmisor = oPedidos.CentroEmisor
         observacion.NumeroPedido = oPedidos.NumeroPedido
         observacion.Linea = orden
         Inserta(observacion)
      Next
   End Sub

   Public Sub ActualizaObservacionesDesdePedido(oPedidos As Entidades.Pedido)
      Borra(oPedidos)
      InsertaObservacionesDesdePedido(oPedidos)
   End Sub

   Friend Sub EjecutaSP(ent As Entidades.PedidoObservacion, tipo As TipoSP)
      Dim sql As SqlServer.PedidosObservaciones = New SqlServer.PedidosObservaciones(da)
      Select Case tipo
         Case TipoSP._I
            sql.PedidosObservaciones_I(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroPedido, ent.Linea, ent.Observacion,
                                       ent.IdTipoObservacion)

            'Case TipoSP._U

         Case TipoSP._D
            sql.PedidosObservaciones_D(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroPedido, 0)
      End Select
   End Sub

   Private Sub CargarUna(o As Entidades.PedidoObservacion, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.PedidoObservacion.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.PedidoObservacion.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.PedidoObservacion.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.PedidoObservacion.Columnas.Linea.ToString()).ToShort()
         .NumeroPedido = dr.Field(Of Integer)(Entidades.PedidoObservacion.Columnas.NumeroPedido.ToString())
         .Linea = dr.Field(Of Integer)(Entidades.PedidoObservacion.Columnas.Linea.ToString())
         .Observacion = dr.Field(Of String)(Entidades.PedidoObservacion.Columnas.Observacion.ToString())
         .IdTipoObservacion = dr.Field(Of Short)(Entidades.PedidoObservacion.Columnas.IdTipoObservacion.ToString())
         .DescripcionTipoObservacion = dr.Field(Of String)(Entidades.TipoObservacion.Columnas.Descripcion.ToString())
      End With
   End Sub

   Public Function GetUna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          linea As Integer) As Entidades.PedidoObservacion
      Return GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, linea)
   End Function

   Public Function GetUna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          linea As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.PedidoObservacion
      Return CargaEntidad(New SqlServer.PedidosObservaciones(da).PedidosObservaciones_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, linea),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.PedidoObservacion(),
                          accion, Function() "No existe la Observación del Pedido.")
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As List(Of Entidades.PedidoObservacion)
      Return CargaLista(GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.PedidoObservacion())
   End Function
#End Region

End Class