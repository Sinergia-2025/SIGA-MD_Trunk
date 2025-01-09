Public Class AntecedentesDetalle

#Region "Campos"

   Private pub As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Antecedente)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      pub = New Publicos()

      pub.CargarComboTiposAntecedentes(Me.cmbTipoAntecedente)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.txtCodigo.Text = New Reglas.Antecedentes().GetProximoId().ToString()
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Antecedentes()
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
        Me.txtCodigo.Text = New Reglas.Antecedentes().GetProximoId().ToString()
         Me.txtCodigo.Focus()
      End If

   End Sub

#End Region

End Class