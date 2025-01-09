Option Strict On
Option Explicit On

Public Class Casillero
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCasillero
      CodigoCasillero
      IdSector
      FilaCasillero
      ColumnaCasillero
      IdCliente
      Activo
   End Enum

   Public Sub New()
      Activo = True
   End Sub
   Public Sub New(sector As Sector)
      Me.New()
      _sector = sector
   End Sub

#Region "Propiedades"
   Private _idCasillero As Integer

   Public Property IdCasillero() As Integer
      Get
         Return _idCasillero
      End Get
      Set(ByVal value As Integer)
         _idCasillero = value
      End Set
   End Property

   Private _codigoCasillero As Integer

   Public Property CodigoCasillero() As Integer
      Get
         Return _codigoCasillero
      End Get
      Set(ByVal value As Integer)
         _codigoCasillero = value
      End Set
   End Property

   Private _sector As Sector
   Public Property Sector() As Entidades.Sector
      Get
         If _sector Is Nothing Then
            _sector = New Entidades.Sector()
         End If
         Return _sector
      End Get
      Set(value As Entidades.Sector)
         _sector = value
      End Set
   End Property

   Public ReadOnly Property IdSector() As Long?
      Get
         If Sector Is Nothing Then Return Nothing
         Return Sector.IdSector
      End Get
   End Property

   Public ReadOnly Property NombreSector() As String
      Get
         If Sector Is Nothing Then Return String.Empty
         Return Sector.NombreSector
      End Get
   End Property

   Private _filaCasillero As Short
   Public Property FilaCasillero() As Short
      Get
         Return _filaCasillero
      End Get
      Set(ByVal value As Short)
         _filaCasillero = value
      End Set
   End Property

   Private _columnaCasillero As Short
   Public Property ColumnaCasillero() As Short
      Get
         Return _columnaCasillero
      End Get
      Set(ByVal value As Short)
         _columnaCasillero = value
      End Set
   End Property

   Private _cliente As Cliente
   Public Property Cliente() As Cliente
      Get
         Return _cliente
      End Get
      Set(ByVal value As Cliente)
         _cliente = value
      End Set
   End Property

   Public ReadOnly Property IdCliente() As Long?
      Get
         If Cliente Is Nothing Then Return Nothing
         Return Cliente.IdCliente
      End Get
   End Property

   Public ReadOnly Property CodigoCliente() As Long?
      Get
         If Cliente Is Nothing Then Return Nothing
         Return Cliente.CodigoCliente
      End Get
   End Property

   Public ReadOnly Property NombreCliente() As String
      Get
         If Cliente Is Nothing Then Return String.Empty
         Return Cliente.NombreCliente
      End Get
   End Property

   Private _activo As Boolean


   Public Property Activo() As Boolean
      Get
         Return _activo
      End Get
      Set(ByVal value As Boolean)
         _activo = value
      End Set
   End Property

#End Region

End Class
