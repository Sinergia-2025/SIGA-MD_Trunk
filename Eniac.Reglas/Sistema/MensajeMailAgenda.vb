Namespace Sistema
   Public Class MensajeMailAgenda
      Inherits Base
      Public Const UsuariosTableName As String = "Usuarios"
      Public Const ClientesTableName As String = "Clientes"
      Public Const ProveedoresTableName As String = "Proveedores"

#Region "Constructores"
      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub
      Public Sub New(accesoDatos As Datos.DataAccess)
         MyBase.New(String.Empty, accesoDatos)
      End Sub
#End Region
      Public Function GetAgendaCompleta() As DataSet
         Return EjecutaConConexion(Function() _GetAgendaCompleta())
      End Function
      Public Function _GetAgendaCompleta() As DataSet
         Dim ds = New DataSet()
         ds.Tables.Add(UsuariosTableName, GetAgendaUsuarios())
         ds.Tables.Add(ClientesTableName, GetAgendaClientes())
         ds.Tables.Add(ProveedoresTableName, GetAgendaProveedores())
         Return ds
      End Function

      Public Function GetAgendaUsuarios() As DataTable
         Return New SqlServer.Sistema.MensajeMailAgenda(da).GetAgendaUsuarios()
      End Function
      Public Function GetAgendaClientes() As DataTable
         Return New SqlServer.Sistema.MensajeMailAgenda(da).GetAgendaClientes()
      End Function
      Public Function GetAgendaProveedores() As DataTable
         Return New SqlServer.Sistema.MensajeMailAgenda(da).GetAgendaProveedores()
      End Function
   End Class
End Namespace