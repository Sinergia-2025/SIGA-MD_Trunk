Public Class EstadoPedidoRol
   Inherits Entidad
   Public Enum Columnas
      TipoEstadoPedido
      IdEstado
      IdRol
      PermitirEscritura
   End Enum

   Public Sub New()
      TipoEstadoPedido = String.Empty
      IdEstado = String.Empty
      Rol = New Rol()
      PermitirEscritura = True
   End Sub

   Public Property TipoEstadoPedido As String
   Public Property IdEstado As String
   Public Property Rol As Rol
   Public Property PermitirEscritura As Boolean

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdRol As String
      Get
         Return If(Rol IsNot Nothing, Rol.Id, String.Empty)
      End Get
   End Property
   Public ReadOnly Property NombreRol As String
      Get
         Return If(Rol IsNot Nothing, Rol.Nombre, String.Empty)
      End Get
   End Property
#End Region
End Class