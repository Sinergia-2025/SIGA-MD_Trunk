
Public Class TipoDeExension
    Inherits Eniac.Entidades.Entidad

    Public Enum Columnas
        IdTipoDeExension
        NombreTipoDeExension
        NombreTipoDeExensionAbrev
        Activo
    End Enum

#Region "Propiedades"

    Private _idTipoDeExension As Short = 0

    Public Property IdTipoDeExension() As Short
        Get
            Return _idTipoDeExension
        End Get
        Set(ByVal value As Short)
            _idTipoDeExension = value
        End Set
    End Property

    Private _nombreTipoDeExension As String = ""

    Public Property NombreTipoDeExension() As String
        Get
            Return _nombreTipoDeExension
        End Get
        Set(ByVal value As String)
            _nombreTipoDeExension = value
        End Set
    End Property

    Private _nombreTipoDeExensionAbrev As String

    Public Property NombreTipoDeExensionAbrev() As String
        Get
            Return _nombreTipoDeExensionAbrev
        End Get
        Set(ByVal value As String)
            _nombreTipoDeExensionAbrev = value
        End Set
    End Property

    Private _activo As Boolean = False

    Public Property Activo() As Boolean
        Get
            Return Me._activo
        End Get
        Set(ByVal value As Boolean)
            Me._activo = value
        End Set
    End Property

#End Region

End Class
