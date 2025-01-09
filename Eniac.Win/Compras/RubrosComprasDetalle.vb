Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class RubrosComprasDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.RubroCompra)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Eniac.Win.Publicos()

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.CargarProximoNumero()
            DirectCast(Me._entidad, Entidades.RubroCompra).Usuario = actual.Nombre
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.RubrosCompras
   End Function

   Protected Overrides Function ValidarDetalle() As String

      'If Not Me.bscCuentaCaja.Selecciono And Not Me.bscNombreCuentaCaja.Selecciono Then
      '   'Me.tbcDetalle.SelectedTab = Me.tbpAgrupacion
      '   Me.bscCuentaCaja.Focus()
      '   Return "No selecciono la Cuenta de Caja."
      'End If

      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdRubro.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oRubro As Reglas.RubrosCompras = New Reglas.RubrosCompras()
      Me.txtIdRubro.Text = (oRubro.GetCodigoMaximo() + 1).ToString("####0")
   End Sub

#End Region

End Class
