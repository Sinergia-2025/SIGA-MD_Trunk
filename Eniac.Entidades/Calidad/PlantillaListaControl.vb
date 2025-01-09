<Serializable()>
Public Class PlantillaListaControl
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdPlantillaCalidad
      NombrePlantillaCalidad
   End Enum

#Region "Campos"

   Private _IdPlantillaCalidad As Integer
   Private _NombrePlantillaCalidad As String
   Private _ListasControl As DataTable

#End Region

#Region "Propiedades"

   Public Property IdPlantillaCalidad() As Integer
      Get
         Return _IdPlantillaCalidad
      End Get
      Set(ByVal value As Integer)
         _IdPlantillaCalidad = value
      End Set
   End Property

   Public Property NombrePlantillaCalidad() As String
      Get
         Return _NombrePlantillaCalidad
      End Get
      Set(ByVal value As String)
         _NombrePlantillaCalidad = value
      End Set
   End Property


   Public Property ListasControl() As DataTable
      Get
         Return Me._ListasControl
      End Get
      Set(ByVal value As DataTable)
         Me._ListasControl = value
      End Set
   End Property

#End Region

End Class