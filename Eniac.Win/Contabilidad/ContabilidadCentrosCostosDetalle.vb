Option Explicit On
Option Strict On

Public Class ContabilidadCentrosCostosDetalle

#Region "Campos"

   Private _publicos As ContabilidadPublicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ContabilidadCentroCosto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New ContabilidadPublicos()

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarValoresIniciales()
         Me.txtCodigo.Focus()
      End If

      If Me.StateForm = Eniac.Win.StateForm.Actualizar And CInt(Me.txtCodigo.Text) = 1 Then
         MessageBox.Show("Este centro de costo no es editable", "Centro Costo", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Close()
      End If


   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadCentrosCostos
   End Function

#End Region

#Region "Eventos"

   'Private Sub lnkMarcaVehiculo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMarcaVehiculo.LinkClicked
   '    Try
   '        Dim MarcaVehic As MarcasVehiculosDetalle = New MarcasVehiculosDetalle(New Entidades.MarcaVehiculo())
   '        MarcaVehic.StateForm = Eniac.Win.StateForm.Insertar
   '        MarcaVehic.ShowDialog()
   '        Me._publicos.CargaComboMarcasVehiculos(Me.cmbMarcaVehiculo)
   '        Me.cmbMarcaVehiculo.SelectedIndex = -1
   '        'Me.cmbMarcaVehiculo.Enabled = (Me.cmbMarcaVehiculo.Items.Count > 0)
   '        'If Me.cmbMarcaVehiculo.Enabled Then
   '        '   Me.cmbMarcaVehiculo.SelectedIndex = 0
   '        'End If
   '    Catch ex As Exception
   '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '    End Try
   'End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.CargarValoresIniciales()
      'End If
      Me.txtCodigo.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      Me.CargarProximoNumero()
      'Me.cmbMarcaVehiculo.SelectedIndex = -1
   End Sub

   Private Sub CargarProximoNumero()
      Dim oCentroCosto As Reglas.ContabilidadCentrosCostos = New Reglas.ContabilidadCentrosCostos()
      Dim ProximoID As Integer
      ProximoID = oCentroCosto.GetIdMaximo() + 1
      Me.txtCodigo.Text = ProximoID.ToString()
   End Sub

#End Region

End Class