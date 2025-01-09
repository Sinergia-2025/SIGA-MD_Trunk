Option Explicit On
Option Strict On
Public Class ContabilidadCuentasTitulosDetalle
   Private _publicos As ContabilidadPublicos


#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ContabilidadCuentaTitulo)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Propiedades"

   Private _idCuenta As Integer
   Public Property IdCuenta() As Integer
      Get
         Return _idCuenta
      End Get
      Set(ByVal value As Integer)
         _idCuenta = value
      End Set
   End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New ContabilidadPublicos()

         Me._publicos.CargaComboCuentasXnivel(Me.cmbNivel1, 1, 1)
         Me.cmbNivel1.SelectedValue = DirectCast(DirectCast(DirectCast(Me.cmbNivel1.SelectedItem, System.Object), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(0)

         Me._publicos.CargaComboCuentasXnivel(Me.cmbNivel2, 2, 1, Me.cmbNivel1.SelectedValue.ToString())
         If Me.cmbNivel2.SelectedIndex > -1 Then
            Me.cmbNivel2.SelectedIndex = 0
         End If
         Me._publicos.CargaComboCuentasXnivel(Me.cmbNivel3, 3, 1, , Me.cmbNivel2.SelectedValue.ToString())
         If Me.cmbNivel3.SelectedIndex > -1 Then
            Me.cmbNivel3.SelectedIndex = 0
         End If

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.CargarValoresIniciales()
         End If

         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
            Me.cmbNivel1.SelectedValue = CInt(IdCuenta.ToString().Substring(0, 1) & "0000000")
            Me.cmbNivel2.SelectedValue = CInt(IdCuenta.ToString().Substring(0, 1) & IdCuenta.ToString.Substring(1, 2) & "00000")
            Me.cmbNivel3.SelectedValue = CInt(IdCuenta.ToString().Substring(0, 5) & "000")

            Me.cmbNivel1.Enabled = False
            Me.cmbNivel2.Enabled = False
            Me.cmbNivel3.Enabled = False

            Me.txtdscCuenta.Enabled = True
            Me.cmdAgregar.Enabled = False
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadCuentasTitulo()
   End Function

   Protected Overrides Sub Aceptar()
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.cmdGuardar.PerformClick()
         Me.Close()
      Else
         MyBase.Aceptar()
      End If



   End Sub

#End Region

#Region "Privados"

   Private Sub CargarValoresIniciales()
      'Me.CargarProximoNumero()
      'Me.lblEmpresa.Text = Me._publicos.NombreEmpresa.ToString
      'dtGrilla = crearTablaGrilla()

   End Sub

   Private Sub RefrescarJerarquia()
      Dim nivel1 As String = String.Empty
      Dim nivel2 As String = String.Empty
      Dim nivel3 As String = String.Empty

      If Me.cmbNivel1.SelectedIndex <> -1 Then
         nivel1 = Me.cmbNivel1.SelectedValue.ToString().Substring(0, 1)
      End If

      If Me.cmbNivel2.SelectedIndex <> -1 Then
         nivel2 = Me.cmbNivel2.SelectedValue.ToString().Substring(1, 2)
      End If

      If Me.cmbNivel3.SelectedIndex <> -1 Then
         nivel3 = Me.cmbNivel3.SelectedValue.ToString().Substring(3, 2)
      End If

      Me.lblJerarquia.Text = nivel1 & "." & nivel2 & "." & nivel3

   End Sub

#End Region

#Region "eventos"


   Private Sub cmdAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
      Try
         If Me.cmbNivel1.SelectedIndex = -1 Or Me.cmbNivel2.SelectedIndex = -1 Then
            MessageBox.Show("Para agregar Cuentas de Nivel 3 debe Seleccionar Cuentas de Nivel 1 y Nivel 2 previamente", "Cuentas Nivel 3", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         Me.cmbNivel1.Enabled = False
         Me.cmbNivel2.Enabled = False
         Me.cmbNivel3.Enabled = False
         Me.lbldsc.Enabled = True
         Me.txtdscCuenta.Enabled = True
         Me.cmdGuardar.Enabled = True
         Me.cmdCancelar.Enabled = True
         Me.txtdscCuenta.Focus()
         Me.cmdAgregar.Enabled = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click

      Me.cmbNivel1.Enabled = True
      Me.cmbNivel2.Enabled = True
      Me.cmbNivel3.Enabled = True

      Me.lbldsc.Enabled = False
      Me.txtdscCuenta.Text = String.Empty
      Me.txtdscCuenta.Enabled = False
      Me.cmdGuardar.Enabled = False
      Me.cmdCancelar.Enabled = False
      Me.cmdAgregar.Enabled = True
   End Sub

   Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
      Try
         If Me.txtdscCuenta.Text = String.Empty Then
            MessageBox.Show("Ingrese una descripción para la cuenta", "Cuenta Nivel 3", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtdscCuenta.Focus()
            Exit Sub
         End If

         'Guardar cuenta
         Dim oCuenta As Reglas.ContabilidadCuentasTitulo = New Reglas.ContabilidadCuentasTitulo()
         oCuenta.GuardarCuentaNivel3(Me.lblJerarquia.Text.Replace(".", ""), Me.txtdscCuenta.Text)

         MessageBox.Show("Se Ha creado la cuenta", "Cuentas Nivel 3", MessageBoxButtons.OK, MessageBoxIcon.Information)

         'refrescar combo
         Me._publicos.CargaComboCuentasXnivel(Me.cmbNivel3, 3, 1, , CStr(cmbNivel2.SelectedValue))

         Me.lbldsc.Enabled = False
         Me.txtdscCuenta.Text = String.Empty
         Me.txtdscCuenta.Enabled = False
         Me.cmdGuardar.Enabled = False
         Me.cmdCancelar.Enabled = False
         Me.cmdAgregar.Enabled = True

         Me.cmbNivel1.Enabled = True
         Me.cmbNivel2.Enabled = True
         Me.cmbNivel3.Enabled = True
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbNivel1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNivel1.SelectedIndexChanged
      Try
         Me._publicos.CargaComboCuentasXnivel(Me.cmbNivel2, 2, 1, CStr(cmbNivel1.SelectedValue))
         Me.RefrescarJerarquia()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub cmbNivel2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNivel2.SelectedIndexChanged
      Try
         Me._publicos.CargaComboCuentasXnivel(Me.cmbNivel3, 3, 1, , CStr(cmbNivel2.SelectedValue))
         Me.RefrescarJerarquia()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbNivel3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNivel3.SelectedIndexChanged
      Try
         Me.RefrescarJerarquia()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region



End Class