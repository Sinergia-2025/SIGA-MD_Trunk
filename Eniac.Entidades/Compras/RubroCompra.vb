<Serializable()>
Public Class RubroCompra
   Inherits Eniac.Entidades.Entidad
   Implements IComboBoxMultipleSeleccionElement

#Region "Campos"

   Private _idRubro As Integer
   Private _nombreRubro As String

#End Region

#Region "Propiedades"

   Public Property IdRubro() As Integer
      Get
         Return _idRubro
      End Get
      Set(ByVal value As Integer)
         _idRubro = value
      End Set
   End Property

   Public Property NombreRubro() As String
      Get
         Return _nombreRubro
      End Get
      Set(ByVal value As String)
         _nombreRubro = value
      End Set
   End Property

#End Region

   Public Function GetCopia() As Entidades.RubroCompra
      Dim copia As Entidades.RubroCompra = New Entidades.RubroCompra()
      With copia
         .IdRubro = Me._idRubro
         .IdSucursal = Me.IdSucursal
         .NombreRubro = Me._nombreRubro
         .Password = Me.Password
         .Usuario = Me.Usuario
      End With
      Return copia
   End Function


#Region "Propiedades IComboBoxMultipleSeleccionElement"
   Private ReadOnly Property IComboBoxMultipleSeleccionElement_Id As String Implements IComboBoxMultipleSeleccionElement.Id
      Get
         Return IdRubro.ToString()
      End Get
   End Property

   Private ReadOnly Property IComboBoxMultipleSeleccionElement_Nombre As String Implements IComboBoxMultipleSeleccionElement.Nombre
      Get
         Return NombreRubro
      End Get
   End Property
#End Region

End Class