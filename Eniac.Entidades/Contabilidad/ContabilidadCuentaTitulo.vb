Option Strict On
Option Explicit On

<Serializable()> _
<System.ComponentModel.Description("ContabilidadCuentaTitulo")> _
Public Class ContabilidadCuentaTitulo
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCuenta
      NombreCuenta
      Nivel
      IdCentroCosto
      EsImputable
      Activa
   End Enum

   Private _idCuenta As Long
   Public Property IdCuenta() As Long
      Get
         Return _idCuenta
      End Get
      Set(ByVal value As Long)
         _idCuenta = value
      End Set
   End Property

   Private _nombreCuenta As String
   Public Property NombreCuenta() As String
      Get
         Return _nombreCuenta
      End Get
      Set(ByVal value As String)
         _nombreCuenta = value
      End Set
   End Property

   Private _idCentroCosto As Integer
   Public Property IdCentroCosto() As Integer
      Get
         Return _idCentroCosto
      End Get
      Set(ByVal value As Integer)
         _idCentroCosto = value
      End Set
   End Property

   Private _esImputable As Boolean
   Public Property EsImputable() As Boolean
      Get
         Return _esImputable
      End Get
      Set(ByVal value As Boolean)
         _esImputable = value
      End Set
   End Property

   Private _nivel As Integer
   Public Property Nivel() As Integer
      Get
         Return _nivel
      End Get
      Set(ByVal value As Integer)
         _nivel = value
      End Set
   End Property

   Private _activa As Boolean
   Public Property Activa() As Boolean
      Get
         Return _activa
      End Get
      Set(ByVal value As Boolean)
         _activa = value
      End Set
   End Property

End Class
