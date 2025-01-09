Public Class PlanTarjeta
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      IdPlanTarjeta
      NombrePlanTarjeta
      CuotasDesde
      CuotasHasta
      PorcDescRec
      IdTarjeta
      IdBanco
      Activo
      PorcDescRecDom
      PorcDescRecLun
      PorcDescRecMar
      PorcDescRecMie
      PorcDescRecJue
      PorcDescRecVie
      PorcDescRecSab
   End Enum

   Public Sub New()
      Activo = True
   End Sub

#Region "Propiedades"
   Public Property IdPlanTarjeta As Integer
   Public Property NombrePlanTarjeta As String
   Public Property CuotasDesde As Integer
   Public Property CuotasHasta As Integer
   Public Property PorcDescRec As Decimal
   Public Property Tarjeta As Tarjeta
   Public Property Banco As Banco
   Public Property Activo As Boolean
   Public Property PorcDescRecDom As Boolean
   Public Property PorcDescRecLun As Boolean
   Public Property PorcDescRecMar As Boolean
   Public Property PorcDescRecMie As Boolean
   Public Property PorcDescRecJue As Boolean
   Public Property PorcDescRecVie As Boolean
   Public Property PorcDescRecSab As Boolean


   Public Property IdTarjeta() As Integer
      Get
         If Tarjeta Is Nothing Then Tarjeta = New Tarjeta()
         Return Tarjeta.IdTarjeta
      End Get
      Set(ByVal value As Integer)
         If Tarjeta Is Nothing Then Tarjeta = New Tarjeta()
         Tarjeta.IdTarjeta = value
      End Set
   End Property
   Public Property NombreTarjeta() As String
      Get
         If Tarjeta Is Nothing Then Tarjeta = New Tarjeta()
         Return Tarjeta.NombreTarjeta
      End Get
      Set(ByVal value As String)
         If Tarjeta Is Nothing Then Tarjeta = New Tarjeta()
         Tarjeta.NombreTarjeta = value
      End Set
   End Property

   Public Property IdBanco() As Integer
      Get
         If Banco Is Nothing Then Banco = New Banco()
         Return Banco.IdBanco
      End Get
      Set(ByVal value As Integer)
         If Banco Is Nothing Then Banco = New Banco()
         Banco.IdBanco = value
      End Set
   End Property
   Public Property NombreBanco() As String
      Get
         If Banco Is Nothing Then Banco = New Banco()
         Return Banco.NombreBanco
      End Get
      Set(ByVal value As String)
         If Banco Is Nothing Then Banco = New Banco()
         Banco.NombreBanco = value
      End Set
   End Property


#End Region

End Class