<Serializable()>
Public Class SueldosCierreLiquidacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idLegajo
      idTipoConcepto
      idCodigo
      Valor
      Importe
      NroLiquidacion
      Aguinaldo
      PeriodoLiquidacion
   End Enum

   Private _idLegajo As Integer
   Public Property idLegajo() As Integer
      Get
         Return Me._idLegajo
      End Get
      Set(ByVal value As Integer)
         Me._idLegajo = value
      End Set
   End Property

   Private _idTipoConcepto As Integer
   Public Property idTipoConcepto() As Integer
      Get
         Return Me._idTipoConcepto
      End Get
      Set(ByVal value As Integer)
         Me._idTipoConcepto = value
      End Set
   End Property

   Private _idCodigo As Integer
   Public Property idCodigo() As Integer
      Get
         Return Me._idCodigo
      End Get
      Set(ByVal value As Integer)
         Me._idCodigo = value
      End Set
   End Property

   Private _Valor As System.Decimal
   Public Property Valor() As System.Decimal
      Get
         Return Me._Valor
      End Get
      Set(ByVal value As System.Decimal)
         Me._Valor = value
      End Set
   End Property

   Private _Importe As System.Decimal
   Public Property Importe() As System.Decimal
      Get
         Return Me._Importe
      End Get
      Set(ByVal value As System.Decimal)
         Me._Importe = value
      End Set
   End Property

   Private _PeriodoLiquidacion As Integer
   Public Property PeriodoLiquidacion() As Integer
      Get
         Return Me._PeriodoLiquidacion
      End Get
      Set(ByVal value As Integer)
         Me._PeriodoLiquidacion = value
      End Set
   End Property

   Private _Aguinaldo As String
   Public Property Aguinaldo() As String
      Get
         Return Me._Aguinaldo
      End Get
      Set(ByVal value As String)
         Me._Aguinaldo = value
      End Set
   End Property

   Private _NroLiquidacion As Integer
   Public Property NroLiquidacion() As Integer
      Get
         Return Me._NroLiquidacion
      End Get
      Set(ByVal value As Integer)
         Me._NroLiquidacion = value
      End Set
   End Property

End Class