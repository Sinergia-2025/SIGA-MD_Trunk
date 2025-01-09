Imports System.ComponentModel
<Serializable()>
<System.ComponentModel.Description("ContabilidadCuenta")>
Public Class ContabilidadCuenta
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCuenta
      NombreCuenta
      Nivel
      EsImputable
      Activa
      IdCuentaPadre
      AjustaPorInflacion
      TipoCuenta
   End Enum
   Public Enum TipoCuentaContable
      <Description("Sin definir")> NULL
      <Description("Patrimonio")> PATRIMONIO
      <Description("Resultado")> RESULTADO
   End Enum

   Public Sub New()
      TipoCuenta = TipoCuentaContable.NULL
   End Sub

   Public Property IdCuenta As Long
   Public Property NombreCuenta As String
   Public Property EsImputable As Boolean
   Public Property Nivel As Integer
   Public Property Activa As Boolean
   Public Property AjustaPorInflacion As Boolean
   Public Property TipoCuenta As TipoCuentaContable

   Private Property _padre As Entidades.ContabilidadCuenta
   Public Property Padre As Entidades.ContabilidadCuenta
      Get
         If Me._padre Is Nothing And _IdCuenta <> 0 Then
            Me._padre = New Entidades.ContabilidadCuenta()
         End If
         Return Me._padre
      End Get
      Set(value As Entidades.ContabilidadCuenta)
         Me._padre = value
      End Set
   End Property

   Public ReadOnly Property IdCuentaPadre As Long
      Get
         If Padre Is Nothing Then Return 0
         Return Me.Padre.IdCuenta
      End Get
   End Property

End Class