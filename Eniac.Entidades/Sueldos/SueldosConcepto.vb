<Serializable()>
Public Class SueldosConcepto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idConcepto
      idTipoConcepto
      NombreConcepto
      Valor
      Tipo
      Aguinaldo
      idQuepide
      Formula
      LiquidacionAnual
      LiquidacionMeses
      CodigoConcepto
      MostrarEnRecibo
      EsContempladoAguinaldo
   End Enum

   'Public Enum QuePide
   '    Nada = 1
   '    Cantidad = 2
   '    Importe = 3
   '    Porcentaje = 4
   'End Enum

#Region "Campos"
   Private _idConcepto As Integer
   Private _idTipoConcepto As Integer
   Private _NombreConcepto As String
   Private _Valor As System.Decimal
   Private _Tipo As String
   Private _Aguinaldo As String
   Private _idQuepide As Integer   'QuePide
   Private _Calculo1 As String
   Private _Formula As String
   Private _LiquidacionAnual As Boolean
   Private _LiquidacionMeses As String
   Private _CodigoConcepto As Integer
   Private _MostrarEnRecibo As Boolean
   Private _EsContempladoAguinaldo As Boolean
#End Region

#Region "Propiedades"
   Public Property idConcepto() As Integer
      Get
         Return Me._idConcepto
      End Get
      Set(ByVal value As Integer)
         Me._idConcepto = value
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

   Public Property NombreConcepto() As String
      Get
         Return Me._NombreConcepto
      End Get
      Set(ByVal value As String)
         Me._NombreConcepto = value
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

   Public Property Tipo() As String
      Get
         Return Me._Tipo
      End Get
      Set(ByVal value As String)
         Me._Tipo = value
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

   'Public Property idQuepide() As QuePide
   '   Get
   '      Return Me._idQuepide
   '   End Get
   '   Set(ByVal value As QuePide)
   '      Me._idQuepide = value
   '   End Set
   'End Property

   Public Property idQuepide() As Integer
      Get
         Return Me._idQuepide
      End Get
      Set(ByVal value As Integer)
         Me._idQuepide = value
      End Set
   End Property

   Public Property Formula() As String
      Get
         Return Me._Formula
      End Get
      Set(ByVal value As String)
         Me._Formula = value
      End Set
   End Property

   Public Property LiquidacionAnual() As Boolean
      Get
         Return Me._LiquidacionAnual
      End Get
      Set(ByVal value As Boolean)
         Me._LiquidacionAnual = value
      End Set
   End Property

   Public Property LiquidacionMeses() As String
      Get
         Return Me._LiquidacionMeses
      End Get
      Set(ByVal value As String)
         Me._LiquidacionMeses = value
      End Set
   End Property

   Public Property CodigoConcepto() As Integer
      Get
         Return Me._CodigoConcepto
      End Get
      Set(ByVal value As Integer)
         Me._CodigoConcepto = value
      End Set
   End Property

   Public Property MostrarEnRecibo() As Boolean
      Get
         Return Me._MostrarEnRecibo
      End Get
      Set(ByVal value As Boolean)
         Me._MostrarEnRecibo = value
      End Set
   End Property


   Public Property EsContempladoAguinaldo() As Boolean
      Get
         Return Me._EsContempladoAguinaldo
      End Get
      Set(ByVal value As Boolean)
         Me._EsContempladoAguinaldo = value
      End Set
   End Property

#End Region

End Class