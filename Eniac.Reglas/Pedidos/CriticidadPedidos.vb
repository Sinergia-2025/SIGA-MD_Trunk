Public Class PedidosCriticidades
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("PedidosCriticidades", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CriticidadPedido)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CriticidadPedido)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CriticidadPedido)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.PedidosCriticidades(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.PedidosCriticidades(da).PedidosCriticidades_GA(False)
   End Function
   Public Overloads Function GetAll(todos As Boolean) As DataTable
      Return New SqlServer.PedidosCriticidades(da).PedidosCriticidades_GA(todos)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CriticidadPedido, tipo As TipoSP)
      Dim sql = New SqlServer.PedidosCriticidades(da)
      Select Case tipo

         Case TipoSP._I
            sql.PedidosCriticidades_I(en.IdCriticidad, en.Orden)

         Case TipoSP._U
            sql.PedidosCriticidades_U(en.IdCriticidad, en.Orden)

         Case TipoSP._D
            sql.PedidosCriticidades_D(en.IdCriticidad)

      End Select
   End Sub

   Private Sub CargarUna(o As Entidades.CriticidadPedido, dr As DataRow)
      With o
         .IdCriticidad = dr.Field(Of String)(Entidades.CriticidadPedido.Columnas.IdCriticidad.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.CriticidadPedido.Columnas.Orden.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.CriticidadPedido), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.CriticidadPedido), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.CriticidadPedido), TipoSP._D)
   End Sub

   Public Function GetTodosPorOrden() As DataTable
      Return New SqlServer.PedidosCriticidades(da).GetTodosPorOrden()
   End Function
   Public Function GetTodos() As List(Of Entidades.CriticidadPedido)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.CriticidadPedido())
   End Function
   Public Function GetUno(idCriticidad As String) As Entidades.CriticidadPedido
      Return GetUno(idCriticidad, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idCriticidad As String, accion As AccionesSiNoExisteRegistro) As Entidades.CriticidadPedido
      Return CargaEntidad(GetAll(), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.CriticidadPedido(),
                          accion, Function() String.Format("No esite Criticidad con Id '{0}'", idCriticidad))
   End Function
   Public Function Get1(IdCriticidad As String) As DataTable
      Return New SqlServer.PedidosCriticidades(da).PedidosCriticidades_G1(IdCriticidad)
   End Function
   Public Function GetTodosPorOrden(IdCriticidad As String) As DataTable
      Return New SqlServer.PedidosCriticidades(da).GetTodosPorOrden()
   End Function

#End Region

End Class