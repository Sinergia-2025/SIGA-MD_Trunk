Option Strict Off
Imports Infragistics.Win.UltraWinGrid
Public Class ExcepcionesDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Excepcion)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      _publicos = New Publicos()
      _publicos.CargaComboTiposListasControl(cmbTipoListaControl)
      _publicos.CargaComboTiposExcepciones(cmbTiposExcepciones)
      _publicos.CargaComboUsuarios(cmbSolicitante)
      _publicos.CargaComboUsuarios(cmbAutorizante1)
      _publicos.CargaComboUsuarios(cmbAutorizante2)
      _publicos.CargaComboUsuarios(cmbAutorizante3)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()

         DirectCast(Me._entidad, Entidades.Excepcion).IdUsuario = actual.Nombre
         DirectCast(Me._entidad, Entidades.Excepcion).FechaExcepcion = Date.Now

         Me.txtNombreExcepcionTipo.Focus()
      Else
         If DirectCast(Me._entidad, Entidades.Excepcion).FechaUsuario1 <> Nothing Then
            Me.chbAutorizante1.Checked = True
         End If
         If DirectCast(Me._entidad, Entidades.Excepcion).FechaUsuario2 <> Nothing Then
            Me.chbAutorizante2.Checked = True
         End If
         If DirectCast(Me._entidad, Entidades.Excepcion).FechaUsuario3 <> Nothing Then
            Me.chbAutorizante3.Checked = True
         End If

      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Excepciones()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()
      If chbAutorizante1.Checked Then
         DirectCast(Me._entidad, Entidades.Excepcion).FechaUsuario1 = dtpFechaAutorizante1.Value
      End If
      If chbAutorizante2.Checked Then
         DirectCast(Me._entidad, Entidades.Excepcion).FechaUsuario2 = dtpFechaAutorizante1.Value
      End If
      If chbAutorizante3.Checked Then
         DirectCast(Me._entidad, Entidades.Excepcion).FechaUsuario3 = dtpFechaAutorizante1.Value
      End If

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub CargarProximoNumero()
      Me.txtIdExcepcion.Text = New Reglas.Excepciones().GetCodigoMaximo().ToString()
   End Sub

   Private Sub chbAutorizante1_CheckedChanged(sender As Object, e As EventArgs) Handles chbAutorizante1.CheckedChanged
      Try
         Me.dtpFechaAutorizante1.Enabled = Me.chbAutorizante1.Checked
         Me.cmbAutorizante1.Enabled = Me.chbAutorizante1.Checked
         If Not Me.chbAutorizante1.Checked Then
            DirectCast(Me._entidad, Entidades.Excepcion).IdUsuario1 = Nothing
            DirectCast(Me._entidad, Entidades.Excepcion).FechaUsuario1 = Nothing
            Me.cmbAutorizante1.SelectedIndex = -1
            Me.dtpFechaAutorizante1.Value = Date.Today
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAutorizante2_CheckedChanged(sender As Object, e As EventArgs) Handles chbAutorizante2.CheckedChanged
      Try
         Me.dtpFechaAutorizante2.Enabled = Me.chbAutorizante2.Checked
         Me.cmbAutorizante2.Enabled = Me.chbAutorizante2.Checked
         If Not Me.chbAutorizante2.Checked Then
            DirectCast(Me._entidad, Entidades.Excepcion).IdUsuario2 = Nothing
            DirectCast(Me._entidad, Entidades.Excepcion).FechaUsuario2 = Nothing
            Me.cmbAutorizante2.SelectedIndex = -1
            Me.dtpFechaAutorizante2.Value = Date.Today
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAutorizante3_CheckedChanged(sender As Object, e As EventArgs) Handles chbAutorizante3.CheckedChanged
      Try
         Me.dtpFechaAutorizante3.Enabled = Me.chbAutorizante3.Checked
         Me.cmbAutorizante3.Enabled = Me.chbAutorizante3.Checked
         If Not Me.chbAutorizante3.Checked Then
            DirectCast(Me._entidad, Entidades.Excepcion).IdUsuario3 = Nothing
            DirectCast(Me._entidad, Entidades.Excepcion).FechaUsuario3 = Nothing
            Me.cmbAutorizante3.SelectedIndex = -1
            Me.dtpFechaAutorizante3.Value = Date.Today
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region

End Class