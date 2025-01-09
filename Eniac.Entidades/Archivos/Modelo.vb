<Serializable()>
Public Class Modelo
   Inherits Entidad
   Implements IComboBoxMultipleSeleccionElement

   Public Const NombreTabla As String = "Modelos"
   Public Enum Columnas
      IdModelo
      NombreModelo
      IdMarca
      Orden
   End Enum

   Public Property IdModelo As Integer
   Public Property NombreModelo As String
   Public Property IdMarca As Integer
   Public Property NombreMarca As String
   Public Property Orden As Integer

   Public ReadOnly Property NombreMarcaModelo As String
      Get
         If String.IsNullOrWhiteSpace(NombreMarca) Then Return NombreModelo
         Return NombreMarca + " - " + NombreModelo
      End Get
   End Property

#Region "Propiedades IComboBoxMultipleSeleccionElement"
   Private ReadOnly Property IComboBoxMultipleSeleccionElement_Id As String Implements IComboBoxMultipleSeleccionElement.Id
      Get
         Return IdModelo.ToString()
      End Get
   End Property

   Private ReadOnly Property IComboBoxMultipleSeleccionElement_Nombre As String Implements IComboBoxMultipleSeleccionElement.Nombre
      Get
         Return NombreModelo
      End Get
   End Property
#End Region

End Class