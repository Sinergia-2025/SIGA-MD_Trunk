Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class SectoresDetalle

#Region "Campos"

    Private _publicos As Publicos

#End Region

#Region "Constructores"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal entidad As Entidades.Sector)
        Me.InitializeComponent()
        Me._entidad = entidad
    End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()


         Me._publicos.CargaComboAreaComun(cmbAreaComun)

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then

            Me.CargarProximoNumero()
            DirectCast(Me._entidad, Entidades.Sector).Usuario = actual.Nombre

         Else
            chkAreaComun.Checked = DirectCast(Me._entidad, Entidades.Sector).AreaComun IsNot Nothing
            cmbAreaComun.SelectedValue = DirectCast(Me._entidad, Entidades.Sector).IdAreaComun
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Sectores()
   End Function

   Protected Overrides Function ValidarDetalle() As String
        If Me.chkAreaComun.Checked AndAlso Me.cmbAreaComun.SelectedIndex < 0 Then
            Return "Indicó que el sector pertenece a un area común, pero no ha seleccionado ninguna."
        End If

        Return MyBase.ValidarDetalle()
    End Function

   Protected Overrides Sub Aceptar()
      If chkAreaComun.Checked AndAlso cmbAreaComun.SelectedItem IsNot Nothing Then
         DirectCast(Me._entidad, Entidades.Sector).AreaComun = New Entidades.AreaComun()
         DirectCast(Me._entidad, Entidades.Sector).AreaComun.IdAreaComun = DirectCast(cmbAreaComun.SelectedItem, DataRowView).Row(Entidades.AreaComun.Columnas.IdAreaComun.ToString()).ToString()
      End If
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not Me.HayError Then Me.Close()
        Me.txtNombre.Focus()
    End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oSector As Reglas.Sectores = New Reglas.Sectores()
      Me.txtId.Text = (oSector.GetCodigoMaximo() + 1).ToString()
   End Sub

   Private Sub chkAreaComun_CheckedChanged(sender As Object, e As EventArgs) Handles chkAreaComun.CheckedChanged
        cmbAreaComun.Enabled = chkAreaComun.Checked
        cmbAreaComun.IsRequired = chkAreaComun.Checked
    End Sub
#End Region

End Class