Public Class Nacionalidad
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "Nacionalidades"
   Public Enum Columnas
      IdNacionalidad
      NombreNacionalidad
   End Enum

#Region "Propiedades"

   Private _idNacionalidad As Integer
   Public Property IdNacionalidad() As Integer
      Get
         Return _idNacionalidad
      End Get
      Set(ByVal value As Integer)
         _idNacionalidad = value
      End Set
   End Property

   Private _nombreNacionalidad As String
   Public Property NombreNacionalidad() As String
      Get
         Return _nombreNacionalidad
      End Get
      Set(ByVal value As String)
         _nombreNacionalidad = value
      End Set
   End Property

#End Region
End Class
