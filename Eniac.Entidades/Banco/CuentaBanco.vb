<Serializable()>
Public Class CuentaBanco
   Inherits Entidad
   Public Const NombreTabla As String = "CuentasBancos"

   Public Enum Columnas
      IdCuentaBanco
      NombreCuentaBanco
      IdTipoCuenta
      EsPosdatado
      PideCheque
      IdCuentaContable
      IdGrupoCuenta
      IdCentroCosto
      IdConceptoCM05

   End Enum

#Region "Propiedades"

   Public Property IdCuentaBanco As Integer
   Public Property NombreCuentaBanco As String
   Public Property IdTipoCuenta As String
   Public Property EsPosdatado As Boolean
   Public Property PideCheque As Boolean
   Public Property IdCuentaContable As Integer
   Public Property IdGrupoCuenta As String
   Public Property CentroCosto As ContabilidadCentroCosto
   Public Property IdConceptoCM05 As Integer?

#End Region

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdCentroCosto As Integer?
      Get
         If CentroCosto Is Nothing Then Return Nothing
         Return CentroCosto.IdCentroCosto
      End Get
   End Property

   Public ReadOnly Property NombreCentroCosto As String
      Get
         If CentroCosto Is Nothing Then Return String.Empty
         Return CentroCosto.NombreCentroCosto
      End Get
   End Property
#End Region

End Class