<Serializable()> _
Public Class CuentaBancariaClase
   Inherits Eniac.Entidades.Entidad

    Public Enum Columnas
        IdCuentaBancariaClase
        NombreCuentaBancariaClase
    End Enum

    Public Property IdCuentaBancariaClase As Integer
    Public Property NombreCuentaBancariaClase As String

    'Private _nombreCuentaBancariaClase As String
    'Public Property NombreCuentaBancariaClase() As String
    '   Get
    '      Return _nombreCuentaBancariaClase
    '   End Get
    '   Set(ByVal value As String)
    '      _nombreCuentaBancariaClase = value
    '   End Set
    'End Property

    'Private _idCuentaBancariaClase As Integer
    'Public Property IdCuentaBancariaClase() As Integer
    '   Get
    '      Return _idCuentaBancariaClase
    '   End Get
    '   Set(ByVal value As Integer)
    '      _idCuentaBancariaClase = value
    '   End Set
    'End Property

End Class
