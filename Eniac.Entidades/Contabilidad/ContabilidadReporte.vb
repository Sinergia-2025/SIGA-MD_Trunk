<Serializable()>
<Description("ContabilidadReporte")>
Public Class ContabilidadReporte
   Inherits Eniac.Entidades.Entidad

   Public Enum TipoRegistro As Integer
      DEFINITIVO = 0
      TEMPORAL = 1
   End Enum

   Private _detallesAsiento As DataTable
   Private _libroMayor As DataTable
   Private _Balance As DataTable
   Private _BalanceN4 As DataTable

   Private _libroDiario As DataTable

   Private _saldoAnterior As Decimal

   Public Enum ColumnasBalance As Integer
      <Description("Tres Columnas")> TresColumnas = 3
      <Description("Cuatro Columnas")> CuatroColumnas = 4
   End Enum

   Public Enum Columnas
      detallesAsiento
      libroMayor
      Balance
      BalanceN4
      saldoAnterior
   End Enum


   Public Property detallesAsiento() As DataTable
      Get
         Return _detallesAsiento
      End Get
      Set(ByVal value As DataTable)
         _detallesAsiento = value
      End Set
   End Property

   Public Property libroMayor() As DataTable
      Get
         Return _libroMayor
      End Get
      Set(ByVal value As DataTable)
         _libroMayor = value
      End Set
   End Property

   Public Property Balance() As DataTable
      Get
         Return _Balance
      End Get
      Set(ByVal value As DataTable)
         _Balance = value
      End Set
   End Property

   Public Property BalanceN4() As DataTable
      Get
         Return _BalanceN4
      End Get
      Set(ByVal value As DataTable)
         _BalanceN4 = value
      End Set
   End Property
   Public Property SaldoAnterior() As Decimal
      Get
         Return _saldoAnterior
      End Get
      Set(ByVal value As Decimal)
         _saldoAnterior = value
      End Set
   End Property


   Public Property LibroDiario() As DataTable
      Get
         Return _libroDiario
      End Get
      Set(ByVal value As DataTable)
         _libroDiario = value
      End Set
   End Property

End Class