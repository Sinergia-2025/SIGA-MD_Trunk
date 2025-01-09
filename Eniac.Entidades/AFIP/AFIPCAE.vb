Public Class AFIPCAE

   Public Enum EstadoElectronicos
      ConCAE
      SinCAE
      Todos
   End Enum

   Public Enum IdiomasComprobantes As Short
      Español = 1
      Ingles = 2
      Portugues = 3
   End Enum

   Public Enum TipoExportacion As Short
      Bienes = 1
      Servicios = 2
      Otros = 4
   End Enum

   Public Enum Secuencia
      PrimeraVez
      SegundaVez
   End Enum

   Private _cae As String
   Public Property CAE() As String
      Get
         Return _cae
      End Get
      Set(ByVal value As String)
         _cae = value
      End Set
   End Property

   Private _CAEVencimiento As DateTime
   Public Property CAEVencimiento() As DateTime
      Get
         Return _CAEVencimiento
      End Get
      Set(ByVal value As DateTime)
         _CAEVencimiento = value
      End Set
   End Property

End Class
