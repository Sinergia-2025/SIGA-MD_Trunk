#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class AFIPReferenciaTransferenciaDetalle

#Region "Campos"
   Private _Publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Eniac.Entidades.AFIPReferenciaTransferencia)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._Publicos = New Eniac.Win.Publicos()

      Me.BindearControles(Me._entidad, _liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         'txtId.Text = (DirectCast(GetReglas(), Reglas.AFIPReferenciasTransferencias).Get)
      End If

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.AFIPReferenciasTransferencias()
   End Function
#End Region
End Class