<Serializable()>
<Description("ucCuentaDHvb")>
Public Class ucCuentaDHvb

   Inherits Eniac.Entidades.Entidad


   'vml 20/05/13 - contabilidad
   Public _idCuentaDebe As Long
   Public _idCuentaHaber As Long

   Public _Origen As String

   Public _idRubro As Integer
   Public _Tipo As String
   Public _idPlanCuenta As Integer

   'vml 20/05/13 - contabilidad
   Public Property idCuentaDebe() As Long
      Get
         Return _idCuentaDebe
      End Get
      Set(ByVal value As Long)
         _idCuentaDebe = value
      End Set
   End Property

   'vml 20/05/13 - contabilidad
   Public Property idCuentaHaber() As Long
      Get
         Return _idCuentaHaber
      End Get
      Set(ByVal value As Long)
         _idCuentaHaber = value
      End Set
   End Property

   Public Property IdPlanCuenta() As Integer
      Get
         Return _idPlanCuenta
      End Get
      Set(ByVal value As Integer)
         _idPlanCuenta = value
      End Set
   End Property

   Public Property idRubro() As Integer
      Get
         Return _idRubro
      End Get
      Set(ByVal value As Integer)
         _idRubro = value
      End Set
   End Property

   Public Property Tipo() As String
      Get
         Return _Tipo
      End Get
      Set(ByVal value As String)
         _Tipo = value
      End Set
   End Property

   Public Property Origen() As String
      Get
         Return _Origen
      End Get
      Set(ByVal value As String)
         _Origen = value
      End Set
   End Property

End Class