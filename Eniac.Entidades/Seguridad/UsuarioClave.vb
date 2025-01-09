<Serializable()> _
Public Class UsuarioClave
   Inherits Eniac.Entidades.Entidad

#Region "Enum"

    Public Enum Columnas
        Id
        FechaModContraseña
        Clave
    End Enum

#End Region

#Region "Campos"

    Private _id As String = ""
    Private _fechaModContraseña As DateTime
    Private _clave As String = ""

#End Region

#Region "Propiedades"

    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            If value.Length > 50 Then
                Throw New Exception("El ancho del id debe ser menor de 50")
            End If
            _id = value
        End Set
    End Property

    Public Property FechaModContraseña() As DateTime
        Get
            Return Me._fechaModContraseña
        End Get
        Set(ByVal value As DateTime)
            Me._fechaModContraseña = value
        End Set
    End Property

    Public Property Clave() As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property
#End Region

End Class


