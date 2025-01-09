<Serializable()> _
Public Class RolFuncion
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      IdFuncion
      IdRol
   End Enum

#Region "Campos"

   Private _idFuncion As String = ""
   Private _idRol As String = ""

#End Region

#Region "Propiedades"

   Public Property IdFuncion() As String
      Get
         Return _idFuncion
      End Get
      Set(ByVal value As String)
         _idFuncion = value
      End Set
   End Property
   Public Property IdRol() As String
      Get
         Return _idRol
      End Get
      Set(ByVal value As String)
         _idRol = value
      End Set
   End Property

#End Region

End Class
