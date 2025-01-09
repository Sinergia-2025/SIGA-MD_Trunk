Option Strict On
Option Explicit On


Public Class AreaComun
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
        IdAreaComun
        NombreAreaComun
        ParticipaExpensas
        IdNave
        IdCliente
        Superficie
        Coeficiente
    End Enum

    Private _idAreaComun As String = String.Empty
    Public Property IdAreaComun() As String
        Get
            Return _idAreaComun
        End Get
        Set(ByVal value As String)
            _idAreaComun = value
        End Set
    End Property

    Private _nombreAreaComun As String = String.Empty
    Public Property NombreAreaComun() As String
        Get
            Return _nombreAreaComun
        End Get
        Set(ByVal value As String)
            _nombreAreaComun = value
        End Set
    End Property

    Private _participaExpensas As Boolean
    Public Property ParticipaExpensas() As Boolean
        Get
            Return _participaExpensas
        End Get
        Set(ByVal value As Boolean)
            _participaExpensas = value
        End Set
    End Property

    Private _nave As Nave
    Public Property Nave() As Nave
        Get
            Return _nave
        End Get
        Set(ByVal value As Nave)
            _nave = value
        End Set
    End Property

    Public ReadOnly Property IdNave() As Short?
        Get
            If Nave Is Nothing Then
                Return Nothing
            End If
            Return Nave.IdNave
        End Get
    End Property
    Public ReadOnly Property NombreNave() As String
        Get
            If Nave Is Nothing Then
                Return String.Empty
            End If
            Return Nave.NombreNave
        End Get
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
            If Cliente Is Nothing Then
                Return Nothing
            End If
            Return Cliente.IdCliente
        End Get
    End Property
    Public ReadOnly Property NombreCliente() As String
        Get
            If Cliente Is Nothing Then
                Return String.Empty
            End If
            Return Cliente.NombreCliente
        End Get
    End Property

    Private _superficie As Integer
    Public Property Superficie() As Integer
        Get
            Return _superficie
        End Get
        Set(ByVal value As Integer)
            _superficie = value
        End Set
    End Property

    Private _coeficiente As Decimal
    Public Property Coeficiente() As Decimal
        Get
            Return _coeficiente
        End Get
        Set(ByVal value As Decimal)
            _coeficiente = value
        End Set
    End Property

End Class
