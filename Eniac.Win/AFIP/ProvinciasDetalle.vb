Imports Eniac.Reglas
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class ProvinciasDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.Provincia)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Provincias
   End Function

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      _publicos.CargaComboPais(cmbPais)

      Me.BindearControles(Me._entidad)



      If Me.StateForm = Eniac.Win.StateForm.Insertar Then

         'Me.chbEsAgentePercepcion.Checked = DirectCast(Me._entidad, Entidades.Provincia).EsAgentePercepcion
      Else

         If Publicos.TieneModuloContabilidad Then
            UcCuentasCompras.Cuenta = DirectCast(Me._entidad, Entidades.Provincia).CuentaCompras
            UcCuentasVentas.Cuenta = DirectCast(Me._entidad, Entidades.Provincia).CuentaVentas
         Else
            UcCuentasCompras.Visible = False
            UcCuentasVentas.Visible = False
            GroupBox1.Visible = False
            GroupBox2.Visible = False
         End If

      End If

     
      Me._estaCargando = False


   End Sub

   Protected Overrides Sub Aceptar()

      If Publicos.TieneModuloContabilidad Then
         DirectCast(_entidad, Entidades.Provincia).CuentaCompras = UcCuentasCompras.Cuenta
         DirectCast(_entidad, Entidades.Provincia).CuentaVentas = UcCuentasVentas.Cuenta
      Else
         DirectCast(_entidad, Entidades.Provincia).CuentaCompras = Nothing
         DirectCast(_entidad, Entidades.Provincia).CuentaVentas = Nothing
      End If

      MyBase.Aceptar()

      If Not Me.HayError Then Me.Close()

   End Sub

   Protected Overrides Function ValidarDetalle() As String
      If Publicos.TieneModuloContabilidad Then
         If UcCuentasCompras.Cuenta Is Nothing OrElse UcCuentasCompras.Cuenta.IdCuenta = 0 Then
            UcCuentasCompras.Focus()
            Return "Debe indicar una cuenta contable para Compras."
         End If
         If UcCuentasVentas.Cuenta Is Nothing OrElse UcCuentasVentas.Cuenta.IdCuenta = 0 Then
            UcCuentasVentas.Focus()
            Return "Debe indicar una cuenta contable para Ventas."
         End If
      End If
      If txtJurisdiccion.Text = "0" Then
         txtJurisdiccion.Focus()
         Return "Debe indicar una Jurisdicción distinta de cero"
      End If

      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
      Me.txtAgenteIngBrutos.Text = ""
      Me.txtIngBrutos.Text = ""
      Me.chbEsAgentePercepcion.Checked = False

   End Sub
#End Region

#Region "Eventos"
   Private Sub ProvinciasDetalle_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
      Try
         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
            Me.txtIngBrutos.Focus()
         Else
            Me.chbEsAgentePercepcion.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbEsAgentePercepcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsAgentePercepcion.CheckedChanged
      If chbEsAgentePercepcion.Checked = False Then
         txtIngBrutos.Text = ""
         txtAgenteIngBrutos.Text = ""
      End If
      Me.txtIngBrutos.Enabled = Me.chbEsAgentePercepcion.Checked
      Me.txtAgenteIngBrutos.Enabled = Me.chbEsAgentePercepcion.Checked
   End Sub

#End Region

End Class