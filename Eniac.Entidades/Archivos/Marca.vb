<Serializable()> _
Public Class Marca
   Inherits Entidad
   Implements IComboBoxMultipleSeleccionElement

   Public Const NombreTabla As String = "Marcas"
   Public Enum Columnas
      IdMarca
      NombreMarca
      ComisionPorVenta
      DescuentoRecargoPorc1
      DescuentoRecargoPorc2
   End Enum

#Region "Propiedades"

   Private _idMarca As Integer
   Public Property IdMarca() As Integer
      Get
         Return Me._idMarca
      End Get
      Set(ByVal value As Integer)
         Me._idMarca = value
      End Set
   End Property

   Private _nombreMarca As String
   Public Property NombreMarca() As String
      Get
         Return Me._nombreMarca
      End Get
      Set(ByVal value As String)
         Me._nombreMarca = value
      End Set
   End Property

   Private _comisionPorVenta As Decimal
   Public Property ComisionPorVenta() As Decimal
      Get
         Return Me._comisionPorVenta
      End Get
      Set(ByVal value As Decimal)
         Me._comisionPorVenta = value
      End Set
   End Property

   Private _descuentoRecargoPorc1 As Decimal
   Public Property DescuentoRecargoPorc1() As Decimal
      Get
         Return Me._descuentoRecargoPorc1
      End Get
      Set(ByVal value As Decimal)
         Me._descuentoRecargoPorc1 = value
      End Set
   End Property

   Private _descuentoRecargoPorc2 As Decimal
   Public Property DescuentoRecargoPorc2() As Decimal
      Get
         Return Me._descuentoRecargoPorc2
      End Get
      Set(ByVal value As Decimal)
         Me._descuentoRecargoPorc2 = value
      End Set
   End Property

#End Region

#Region "Propiedades IComboBoxMultipleSeleccionElement"
   Private ReadOnly Property IComboBoxMultipleSeleccionElement_Id As String Implements IComboBoxMultipleSeleccionElement.Id
      Get
         Return IdMarca.ToString()
      End Get
   End Property

   Private ReadOnly Property IComboBoxMultipleSeleccionElement_Nombre As String Implements IComboBoxMultipleSeleccionElement.Nombre
      Get
         Return NombreMarca
      End Get
   End Property
#End Region

End Class