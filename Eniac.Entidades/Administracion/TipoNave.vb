Option Strict On
Option Explicit On

Public Class TipoNave
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
        IdTipoNave
        NombreTipoNave
        Seco
    End Enum

   'Public Class Estados
   '   Public Const Alta As String = "ALTA"
   '   Public Const Ocupado As String = "OCUPADO"
   'End Class

#Region "Propiedades"
   Private _idTipoNave As Short

   Public Property IdTipoNave() As Short
      Get
         Return _idTipoNave
      End Get
      Set(ByVal value As Short)
         _idTipoNave = value
      End Set
   End Property

   Private _nombreTipoNave As String

   Public Property NombreTipoNave() As String
        Get
            Return _nombreTipoNave
        End Get
        Set(ByVal value As String)
            _nombreTipoNave = value
        End Set
    End Property

    Private _seco As Boolean

   Public Property Seco() As Boolean
        Get
            Return _seco
        End Get
        Set(ByVal value As Boolean)
            _seco = value
        End Set
    End Property
#End Region
End Class
