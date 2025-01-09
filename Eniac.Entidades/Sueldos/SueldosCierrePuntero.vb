<Serializable()>
Public Class SueldosCierrePuntero
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      NroPerson
      Caja
      Inscripcion
      NroLiqui
      LiqQuincela
      LiqMes
      LiqAno
      FechaPago
      FechaDeposito
      DepositoLapso
      DepositoBano
   End Enum

#Region "Campos"
   Private _NroPerson As Integer
   Private _Caja As String
   Private _Inscripcion As String
   Private _NroLiqui As Integer
   Private _LiqQuincela As Integer
   Private _LiqMes As Integer
   Private _LiqAno As Integer
   Private _FechaPago As DateTime
   Private _FechaDeposito As DateTime
   Private _DepositoLapso As String
   Private _DepositoBano As String

#End Region
#Region "Propiedades"
   Public Property NroPerson() As Integer
      Get
         Return Me._NroPerson
      End Get
      Set(ByVal value As Integer)
         Me._NroPerson = value
      End Set
   End Property

   Public Property Caja() As String
      Get
         Return Me._Caja
      End Get
      Set(ByVal value As String)
         Me._Caja = value
      End Set
   End Property

   Public Property Inscripcion() As String
      Get
         Return Me._Inscripcion
      End Get
      Set(ByVal value As String)
         Me._Inscripcion = value
      End Set
   End Property

   Public Property NroLiqui() As Integer
      Get
         Return Me._NroLiqui
      End Get
      Set(ByVal value As Integer)
         Me._NroLiqui = value
      End Set
   End Property

   Public Property LiqQuincela() As Integer
      Get
         Return Me._LiqQuincela
      End Get
      Set(ByVal value As Integer)
         Me._LiqQuincela = value
      End Set
   End Property

   Public Property LiqMes() As Integer
      Get
         Return Me._LiqMes
      End Get
      Set(ByVal value As Integer)
         Me._LiqMes = value
      End Set
   End Property

   Public Property LiqAno() As Integer
      Get
         Return Me._LiqAno
      End Get
      Set(ByVal value As Integer)
         Me._LiqAno = value
      End Set
   End Property

   Public Property FechaPago() As DateTime
      Get
         Return Me._FechaPago
      End Get
      Set(ByVal value As DateTime)
         Me._FechaPago = value
      End Set
   End Property

   Public Property FechaDeposito() As DateTime
      Get
         Return Me._FechaDeposito
      End Get
      Set(ByVal value As DateTime)
         Me._FechaDeposito = value
      End Set
   End Property

   Public Property DepositoLapso() As String
      Get
         Return Me._DepositoLapso
      End Get
      Set(ByVal value As String)
         Me._DepositoLapso = value
      End Set
   End Property

   Public Property DepositoBano() As String
      Get
         Return Me._DepositoBano
      End Get
      Set(ByVal value As String)
         Me._DepositoBano = value
      End Set
   End Property


#End Region

End Class