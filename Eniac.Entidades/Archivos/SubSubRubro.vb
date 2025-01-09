<Serializable()> _
Public Class SubSubRubro
   Inherits Entidad
   Implements IComboBoxMultipleSeleccionElement

   Public Const NombreTabla As String = "SubSubRubros"
   Public Enum Columnas
      IdSubSubRubro
      NombreSubSubRubro
      IdSubRubro
      FechaActualizacionWeb
      IdSubSubRubroTiendaNube
      IdSubSubRubroMercadoLibre
      IdSubSubRubroArborea
   End Enum

   Public Property IdRubro As Integer
   Public Property IdSubRubro As Integer
   Public Property IdSubSubRubro As Integer
   Public Property NombreSubSubRubro As String

   Public Property NombreRubro As String
   Public Property NombreSubRubro As String
   Public Property IdSubSubRubroTiendaNube As String
   Public Property IdSubSubRubroMercadoLibre As String
   Public Property IdSubSubRubroArborea As String

   Public ReadOnly Property NombreConcatenado As String
      Get
         Return String.Format("{0} - {1}", NombreRubro, NombreSubRubro)
      End Get
   End Property

#Region "Propiedades ReadOnly"
   Public ReadOnly Property NombreRubroSubRubroSubSubRubro As String
      Get
         If String.IsNullOrWhiteSpace(NombreRubro) Then Return NombreSubSubRubro
         Return String.Format("{0} - {1} - {2}", NombreRubro, NombreSubRubro, NombreSubSubRubro)
      End Get
   End Property
#End Region

#Region "Propiedades IComboBoxMultipleSeleccionElement"
   Private ReadOnly Property IComboBoxMultipleSeleccionElement_Id As String Implements IComboBoxMultipleSeleccionElement.Id
      Get
         Return IdSubSubRubro.ToString()
      End Get
   End Property

   Private ReadOnly Property IComboBoxMultipleSeleccionElement_Nombre As String Implements IComboBoxMultipleSeleccionElement.Nombre
      Get
         Return NombreSubSubRubro
      End Get
   End Property
#End Region

End Class