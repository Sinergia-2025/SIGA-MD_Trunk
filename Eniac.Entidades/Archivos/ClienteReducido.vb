Public Class ClienteReducido
   Inherits Eniac.Entidades.Entidad



#Region "Primaria"

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

   Private _codigoCliente As Long
   Public Property CodigoCliente() As Long
      Get
         Return _codigoCliente
      End Get
      Set(ByVal value As Long)
         _codigoCliente = value
      End Set
   End Property

   Private _nombreCliente As String
   Public Property NombreCliente() As String
      Get
         Return _nombreCliente
      End Get
      Set(ByVal value As String)
         _nombreCliente = value
      End Set
   End Property

   Private _categoria As Entidades.Categoria
   Public Property Categoria() As Entidades.Categoria
      Get
         If Me._categoria Is Nothing Then
            Me._categoria = New Entidades.Categoria()
         End If
         Return _categoria
      End Get
      Set(ByVal value As Entidades.Categoria)
         _categoria = value
      End Set
   End Property

   Private _direccion As String
   Public Property Direccion() As String
      Get
         Return _direccion
      End Get
      Set(ByVal value As String)
         _direccion = value
      End Set
   End Property

   Private _saldoCtaCte As Decimal
   Public Property SaldoCtaCte() As Decimal
      Get
         Return _saldoCtaCte
      End Get
      Set(ByVal value As Decimal)
         _saldoCtaCte = value
      End Set
   End Property


End Class
