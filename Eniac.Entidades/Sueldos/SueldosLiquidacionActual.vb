<Serializable()>
Public Class SueldosLiquidacionActual
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idLegajo
      idTipoConcepto
      idConcepto
      Valor
      Importe
      NroLiquidacion
      Aguinaldo
   End Enum

#Region "Campos"
   Private _idLegajo As Integer
   Private _idTipoConcepto As Integer
   Private _idConcepto As Integer
   Private _Valor As System.Decimal
   Private _Importe As System.Decimal
   Private _NroLiquidacion As Integer
   Private _Aguinaldo As String

#End Region
#Region "Propiedades"
   Public Property idLegajo() As Integer
      Get
         Return Me._idLegajo
      End Get
      Set(ByVal value As Integer)
         Me._idLegajo = value
      End Set
   End Property

   Public Property idTipoConcepto() As Integer
      Get
         Return Me._idTipoConcepto
      End Get
      Set(ByVal value As Integer)
         Me._idTipoConcepto = value
      End Set
   End Property

   Public Property idConcepto() As Integer
      Get
         Return Me._idConcepto
      End Get
      Set(ByVal value As Integer)
         Me._idConcepto = value
      End Set
   End Property

   Public Property Valor() As System.Decimal
      Get
         Return Me._Valor
      End Get
      Set(ByVal value As System.Decimal)
         Me._Valor = value
      End Set
   End Property

   Public Property Importe() As System.Decimal
      Get
         Return Me._Importe
      End Get
      Set(ByVal value As System.Decimal)
         Me._Importe = value
      End Set
   End Property

   Public Property NroLiquidacion() As Integer
      Get
         Return Me._NroLiquidacion
      End Get
      Set(ByVal value As Integer)
         Me._NroLiquidacion = value
      End Set
   End Property

   Public Property Aguinaldo() As String
      Get
         Return Me._Aguinaldo
      End Get
      Set(ByVal value As String)
         Me._Aguinaldo = value
      End Set
   End Property


#End Region

End Class