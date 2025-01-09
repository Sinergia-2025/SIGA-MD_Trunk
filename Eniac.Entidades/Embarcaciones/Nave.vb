Public Class Nave
   Inherits Entidades.Entidad

   Public Enum Columnas
      IdNave
      NombreNave
      NombrePC
      EnMantenimiento
      LimiteDeKilos
      IdTipoNave

   End Enum
   Private _tipoNave As TipoNave
   Public Property TipoNave() As TipoNave
      Get
         Return _tipoNave
      End Get
      Set(ByVal value As TipoNave)
         _tipoNave = value
      End Set
   End Property
   Public Property IdNave As Short
   Public Property NombreNave As String
   Public Property NombrePC As String
   Public Property EnMantenimiento As Boolean
   Public Property LimiteDeKilos As Integer
   Public Property IdTipoNave As Short

End Class