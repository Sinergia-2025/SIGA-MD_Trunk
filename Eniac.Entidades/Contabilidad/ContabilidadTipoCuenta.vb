Option Strict On
Option Explicit On

<Serializable()> _
<System.ComponentModel.Description("ContabilidadTipoCuenta")> _
Public Class ContabilidadTipoCuenta
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoCuenta
      NombreTipoCuenta
   End Enum

   Private _idTipoCuenta As Integer
   Public Property IdTipoCuenta() As Integer
      Get
         Return _idTipoCuenta
      End Get
      Set(ByVal value As Integer)
         _idTipoCuenta = value
      End Set
   End Property

   Private _nombreTipoCuenta As String
   Public Property NombreTipoCuenta() As String
      Get
         Return _nombreTipoCuenta
      End Get
      Set(ByVal value As String)
         _nombreTipoCuenta = value
      End Set
   End Property
End Class
