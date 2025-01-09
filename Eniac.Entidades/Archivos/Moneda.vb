<Serializable()> _
Public Class Moneda
   Inherits Eniac.Entidades.Entidad

   Public Const Peso As Integer = 1
   Public Const Dolar As Integer = 2

   Public Const NombreTabla As String = "Monedas"

   Public Enum Columnas
      IdMoneda
      NombreMoneda
      IdTipoMoneda
      OperadorConversion
      FactorConversion
      IdBanco
      Simbolo
      Predeterminada
   End Enum

   Private _nombreMoneda As String
   Public Property NombreMoneda() As String
      Get
         Return _nombreMoneda
      End Get
      Set(ByVal value As String)
         _nombreMoneda = value
      End Set
   End Property

   Private _idMoneda As Integer
   Public Property IdMoneda() As Integer
      Get
         Return _idMoneda
      End Get
      Set(ByVal value As Integer)
         _idMoneda = value
      End Set
   End Property

   Private _idTipoMoneda As String
   Public Property IdTipoMoneda() As String
      Get
         Return _idTipoMoneda
      End Get
      Set(ByVal value As String)
         _idTipoMoneda = value
      End Set
   End Property

   Private _operadorConversion As String
   Public Property OperadorConversion() As String
      Get
         Return _operadorConversion
      End Get
      Set(ByVal value As String)
         _operadorConversion = value
      End Set
   End Property

   Private _factorConversion As Decimal
   Public Property FactorConversion() As Decimal
      Get
         Return _factorConversion
      End Get
      Set(ByVal value As Decimal)
         _factorConversion = value
      End Set
   End Property


   'Para que existe este campo!!!???
   Private _idBanco As Integer
   Public Property IdBanco() As Integer
      Get
         Return _idBanco
      End Get
      Set(ByVal value As Integer)
         _idBanco = value
      End Set
   End Property

   Private _simbolo As String
   Public Property Simbolo() As String
      Get
         Return _simbolo
      End Get
      Set(ByVal value As String)
         _simbolo = value
      End Set
   End Property

   Public Property Predeterminada As Boolean

   Public Function GetCopia() As Entidades.Moneda
      Dim copia As Entidades.Moneda = New Entidades.Moneda()
      With copia
         .FactorConversion = Me._factorConversion
         .IdBanco = Me._idBanco
         .IdMoneda = Me._idMoneda
         .IdSucursal = Me.IdSucursal
         .IdTipoMoneda = Me._idTipoMoneda
         .NombreMoneda = Me._nombreMoneda
         .OperadorConversion = Me._operadorConversion
         .Password = Me.Password
         .Usuario = Me.Usuario
      End With
      Return copia
   End Function

End Class