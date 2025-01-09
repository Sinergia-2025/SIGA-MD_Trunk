<Serializable()> _
Public Class ClienteDescuentoRubro
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdRubro
      DescuentoRecargoPorc1
      DescuentoRecargoPorc2
      IdCliente
   End Enum

#Region "Propiedades"
   Private _idRubro As Integer
   Public Property IdRubro() As Integer
      Get
         Return _idRubro
      End Get
      Set(ByVal value As Integer)
         _idRubro = value
      End Set
   End Property
   Private _descuentoRecargoPorc1 As Decimal
   Public Property DescuentoRecargoPorc1() As Decimal
      Get
         Return _descuentoRecargoPorc1
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoPorc1 = value
      End Set
   End Property
   Private _descuentoRecargoPorc2 As Decimal
   Public Property DescuentoRecargoPorc2() As Decimal
      Get
         Return _descuentoRecargoPorc2
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoPorc2 = value
      End Set
   End Property
   Private _idCliente As Long
   Public Property IdCliente() As Long
      Get
         Return _idCliente
      End Get
      Set(ByVal value As Long)
         _idCliente = value
      End Set
   End Property
#End Region

End Class