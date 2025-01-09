Option Strict On
Option Explicit On

Public Class TipoMotor
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
        IdTipoMotor
        NombreTipoMotor
    End Enum

#Region "Propiedades"
    Private _idTipoMotor As Short

   Public Property IdTipoMotor() As Short
        Get
            Return _idTipoMotor
        End Get
        Set(ByVal value As Short)
            _idTipoMotor = value
        End Set
    End Property

    Private _nombreTipoMotor As String

   Public Property NombreTipoMotor() As String
        Get
            Return _nombreTipoMotor
        End Get
        Set(ByVal value As String)
            _nombreTipoMotor = value
        End Set
    End Property
#End Region
End Class
