Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class CobradoresDetalle

   Private ReadOnly Property Cobrador As Entidades.Cobrador
      Get
         Return DirectCast(_entidad, Entidades.Cobrador)
      End Get
   End Property

#Region "Campos"
   Private _Publicos As Publicos
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.Cobrador)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._Publicos = New Eniac.Win.Publicos()

      Me._Publicos.CargaComboBancos(Me.cmbBanco)
      _Publicos.CargaComboCajas(cmbCaja, {actual.Sucursal}, False, False, False)

      _liSources.Add("CobradorSucursal", Cobrador.CobradorSucursal)

      Me.BindearControles(Me._entidad, _liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
      Else
         chbCaja.Checked = Cobrador.IdCaja.HasValue
      End If

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Cobradores()
   End Function

   Protected Overrides Sub Aceptar()
      If Not chbCaja.Checked Then
         Cobrador.IdCaja = Nothing
      End If

      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      If Me.chbDebitoDirecto.Checked Then
         If Me.cmbBanco.Text = "" Then
            Me.cmbBanco.Focus()
            Return "Debe ingresar un Banco para Debito Directo"
         End If
      End If

      Return vacio

   End Function
#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdCobrador.Focus()
   End Sub

   Private Sub chbDebitoDirecto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDebitoDirecto.CheckedChanged
      Try

         Me.cmbBanco.Enabled = Me.chbDebitoDirecto.Checked

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCaja.CheckedChanged
      Try

         Me.cmbCaja.Enabled = Me.chbCaja.Checked

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lblCaja_Click(sender As Object, e As EventArgs) Handles lblCaja.Click
      chbCaja.Checked = Not chbCaja.Checked
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oCobradores As Reglas.Cobradores = New Reglas.Cobradores()
      Me.txtIdCobrador.Text = (oCobradores.GetIdMaximo() + 1).ToString("####0")
   End Sub

#End Region

End Class