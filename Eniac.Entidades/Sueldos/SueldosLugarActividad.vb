<Serializable()> _
Public Class SueldosLugarActividad
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdLugarActividad
      NombreLugarActividad
   End Enum

#Region "Propiedades"

   Private _idLugarActividad As Integer
   Public Property IdLugarActividad() As Integer
      Get
         Return _idLugarActividad
      End Get
      Set(ByVal value As Integer)
         _idLugarActividad = value
      End Set
   End Property

   Private _nombreLugarActividad As String
   Public Property NombreLugarActividad() As String
      Get
         Return _nombreLugarActividad
      End Get
      Set(ByVal value As String)
         _nombreLugarActividad = value
      End Set
   End Property

#End Region

End Class
