<Serializable()>
Public Class SueldosPersonaConcepto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idLegajo
      idTipoConcepto
      idConcepto
      Valor
      Aguinaldo
      Periodos
      IdTipoRecibo
   End Enum

#Region "Campos"

   Private _idLegajo As Integer
   Private _idTipoConcepto As Integer
   Private _idConcepto As Integer
   Private _Valor As System.Decimal
   Private _Aguinaldo As String
   Private _Periodos As Integer

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

   Public Property Aguinaldo() As String
      Get
         Return Me._Aguinaldo
      End Get
      Set(ByVal value As String)
         Me._Aguinaldo = value
      End Set
   End Property

   Public Property Periodos() As Integer
      Get
         Return Me._Periodos
      End Get
      Set(ByVal value As Integer)
         Me._Periodos = value
      End Set
   End Property

   Private _tipoRecibo As Entidades.SueldosTipoRecibo
   Public Property TipoRecibo() As Entidades.SueldosTipoRecibo
      Get
         If Me._tipoRecibo Is Nothing Then
            Me._tipoRecibo = New Entidades.SueldosTipoRecibo()
         End If
         Return _tipoRecibo
      End Get
      Set(ByVal value As Entidades.SueldosTipoRecibo)
         _tipoRecibo = value
      End Set
   End Property



#End Region

End Class