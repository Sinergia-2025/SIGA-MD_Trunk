Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports Infragistics.Win.UltraWinGrid
Public Class PlanesTarjetasDetalle

   Private _publicos As Publicos
   Public ReadOnly Property PlanTarjeta() As Entidades.PlanTarjeta
      Get
         Return DirectCast(Me._entidad, PlanTarjeta)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.PlanTarjeta)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboTarjetas(Me.cmbTarjeta, True)

         Me.BindearControles(Me._entidad)

         chbTarjeta.Checked = True
         chbTarjeta.Checked = False
         chbBanco.Checked = True
         chbBanco.Checked = False

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdPlanTarjeta.Text = (DirectCast(GetReglas(), Reglas.PlanesTarjetas).GetCodigoMaximo() + 1).ToString()
            'chbActivo.Checked = True
         Else
            If PlanTarjeta.IdTarjeta > 0 Then
               cmbTarjeta.SelectedValue = PlanTarjeta.IdTarjeta
               chbTarjeta.Checked = True
            Else
               chbTarjeta.Checked = False
            End If
            If PlanTarjeta.IdBanco > 0 Then
               bscBanco.Text = PlanTarjeta.NombreBanco
               bscBanco.Tag = PlanTarjeta.IdBanco
               bscBanco.Selecciono = True
               chbBanco.Checked = True
            Else
               chbBanco.Checked = False
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.PlanesTarjetas
   End Function
   Protected Overrides Function ValidarDetalle() As String

      MyBase.ValidarDetalle()

      If Integer.Parse(Me.txtCuotasDesde.Text) = 0 Then
         Return "Cuota Desde No puede ser cero."
      End If

      If Integer.Parse(Me.txtCuotasHasta.Text) = 0 Then
         Return "Cuota Hasta No puede ser cero."
      End If

      If Integer.Parse(Me.txtCuotasDesde.Text) > Integer.Parse(Me.txtCuotasHasta.Text) Then
         Return "Rango de Cuotas es Invalido."
      End If

      If Me.chbTarjeta.Checked AndAlso Me.cmbTarjeta.SelectedIndex = -1 Then
         Return "Ha indicado que el Plan está asociado a una Tarjeta y no seleccionó ninguna."
      End If

      If Me.chbBanco.Checked AndAlso Me.bscBanco.Tag Is Nothing Then
         Return "Ha indicado que el Plan está asociado a un Banco y no seleccionó ningun."
      End If

      Return String.Empty

   End Function


   Protected Overrides Sub Aceptar()
      If chbBanco.Checked AndAlso bscBanco.Tag IsNot Nothing Then
         PlanTarjeta.IdBanco = Integer.Parse(bscBanco.Tag.ToString())
      Else
         PlanTarjeta.Banco = Nothing
      End If

      If chbTarjeta.Checked AndAlso cmbTarjeta.SelectedValue IsNot Nothing Then
         PlanTarjeta.IdTarjeta = Integer.Parse(cmbTarjeta.SelectedValue.ToString())
      Else
         PlanTarjeta.Tarjeta = Nothing
      End If

      MyBase.Aceptar()

      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If
   End Sub
#End Region

#Region "Eventos"
   Private Sub PlanesTarjetasDetalle_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F4
            Me.btnAceptar.PerformClick()
      End Select
   End Sub

   Private Sub bscBanco_BuscadorClick() Handles bscBanco.BuscadorClick
      Try
         Me._publicos.PreparaGrillaBancos(Me.bscBanco)
         Dim oBanco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()
         Me.bscBanco.Datos = oBanco.GetFiltradoPorNombre(Me.bscBanco.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscBanco_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscBanco.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosBancos(e.FilaDevuelta)
            Me.chbActivo.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub txtIdPlanTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdPlanTarjeta.KeyDown, txtNombrePlanTarjeta.KeyDown, txtPorcDescRec.KeyDown, txtCuotasDesde.KeyDown, txtCuotasHasta.KeyDown, cmbTarjeta.KeyDown, btnAceptar.KeyDown
      Try
         PresionarTab(e)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles chbTarjeta.CheckedChanged
      If chbTarjeta.Checked Then
         cmbTarjeta.Enabled = True
      Else
         cmbTarjeta.Enabled = False
         cmbTarjeta.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbBanco_CheckedChanged(sender As Object, e As EventArgs) Handles chbBanco.CheckedChanged
      If chbBanco.Checked Then
         bscBanco.Enabled = True
      Else
         bscBanco.Enabled = False
         bscBanco.Text = String.Empty
         bscBanco.Tag = Nothing
         bscBanco.Selecciono = False
      End If
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarDatosBancos(ByVal dr As DataGridViewRow)
      Me.bscBanco.Text = dr.Cells("NombreBanco").Value.ToString()
      Me.bscBanco.Tag = dr.Cells("IdBanco").Value.ToString()
   End Sub
#End Region

End Class