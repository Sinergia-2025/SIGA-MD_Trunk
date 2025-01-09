Option Explicit On
Option Strict On

Public Class ContabilidadCuentasDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _publicosContabilidad As ContabilidadPublicos
   Private _initializing As Boolean

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ContabilidadCuenta)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _initializing = True
         Me._publicosContabilidad = New ContabilidadPublicos()
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbTipoCuenta, GetType(Entidades.ContabilidadCuenta.TipoCuentaContable))

         Me.CierraAutomaticamente = True

         Dim cta As Entidades.ContabilidadCuenta = DirectCast(Me._entidad, Entidades.ContabilidadCuenta)

         Dim nivelActual As Integer = 1

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Win.StateForm.Insertar Then
            'Me.CargarProximoNumero()
            Me.CargarValoresIniciales()
            Me.cmbNivel.Text = nivelActual.ToString()
         Else
            nivelActual = (cta.Nivel - 1)
            Me.cmbNivel.Enabled = False
            Me.RefrescarJerarquia()
            Me.bscDescripcionPadre.Text = cta.Padre.NombreCuenta
         End If
         Me.cmbNivel.Text = nivelActual.ToString()


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         _initializing = False
      End Try


   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadCuentas()
   End Function

   Protected Overrides Sub Aceptar()
      Dim ni As Integer = 1
      If Not String.IsNullOrEmpty(Me.cmbNivel.Text) Then
         ni = Int32.Parse(Me.cmbNivel.Text) + 1
      End If
      If Me.txtCuentaPadre.Text = "0" Then
         MessageBox.Show("Debe seleccionar una cuenta Padre para la cuenta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If
      DirectCast(Me._entidad, Entidades.ContabilidadCuenta).Nivel = ni
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub cmdPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlan.Click
      Try
         Using frmtree As ContabilidadPlanesCuentasPreView = New ContabilidadPlanesCuentasPreView()
            ''frmtree.IdCuenta = Me.txtCuentaPadre.Text
            If frmtree.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso frmtree.Cuenta IsNot Nothing Then
               If frmtree.Cuenta.EsImputable Then
                  MessageBox.Show(String.Format("La cuenta {0} - {1} es imputable. No puede ser madre de otra cuenta. Por favor reintente.",
                                                frmtree.Cuenta.IdCuenta, frmtree.Cuenta.NombreCuenta))
                  Exit Sub
               End If
               cmbNivel.SelectedItem = frmtree.Cuenta.Nivel.ToString()
               txtCuentaPadre.Text = frmtree.Cuenta.IdCuenta.ToString()
               bscDescripcionPadre.Text = frmtree.Cuenta.NombreCuenta
               DirectCast(Me._entidad, Entidades.ContabilidadCuenta).Padre = frmtree.Cuenta

               Me.RefrescarJerarquia()
               Me.txtCodigo.Focus()

            End If
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbNivel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNivel.SelectedIndexChanged
      Try
         If String.IsNullOrEmpty(Me.cmbNivel.Text) Then
            Exit Sub
         End If
         If Not _initializing Then
            txtCuentaPadre.Text = String.Empty
            bscDescripcionPadre.Text = String.Empty
            DirectCast(Me._entidad, Entidades.ContabilidadCuenta).Padre = Nothing

            Me.RefrescarJerarquia()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCodigo_Leave(sender As Object, e As EventArgs) Handles txtCodigo.Leave
      Try
         Me.RefrescarJerarquia()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtdscCuenta_Leave(sender As Object, e As EventArgs) Handles txtdscCuenta.Leave
      Try
         Me.RefrescarJerarquia()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcion_BuscadorClick() Handles bscDescripcionPadre.BuscadorClick
      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicosContabilidad.PreparaGrillaCuentas(Me.bscDescripcionPadre)
         Me.bscDescripcionPadre.Datos = oAsientos.GetCuentasXNivelDescripcion(Int32.Parse(Me.cmbNivel.Text), Me.bscDescripcionPadre.Text)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcion_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscDescripcionPadre.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.txtCuentaPadre.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()
            Me.bscDescripcionPadre.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()

            DirectCast(Me._entidad, Entidades.ContabilidadCuenta).Padre = New Reglas.ContabilidadCuentas().GetUna(Long.Parse(e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()))

            Me.RefrescarJerarquia()
            Me.txtCodigo.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      Me.chbActiva.Checked = True
      Me.chbImputable.Checked = True
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      'TODO: tengo que validar que si estoy editando y esta cuenta tiene hijos no puede ser nunca imputable.

      'TODO: tengo que validar que si estoy insertando no puedo seleccionar una cuenta Padre que sea imputable.

      If Me.txtdscCuenta.Text = String.Empty Then
         Me.txtdscCuenta.Focus()
         Return "Ingrese una descripción para la cuenta."
      End If

      If cmbTipoCuenta.SelectedIndex < 0 OrElse DirectCast(cmbTipoCuenta.SelectedValue, Entidades.ContabilidadCuenta.TipoCuentaContable) = Entidades.ContabilidadCuenta.TipoCuentaContable.NULL Then
         cmbTipoCuenta.Focus()
         Return "Debe definir el tipo de cuenta"
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Private Sub RefrescarJerarquia()
      Dim texto As System.Text.StringBuilder = New System.Text.StringBuilder()
      RefrescarJerarquia(texto, DirectCast(Me._entidad, Entidades.ContabilidadCuenta), 0)
      Me.lblJerarquia.Text = texto.ToString()
   End Sub
   Private Sub RefrescarJerarquia(stb As StringBuilder, cuenta As Entidades.ContabilidadCuenta, tab As Integer)
      stb.AppendFormatLine("{2}{0}-{1}", cuenta.IdCuenta, cuenta.NombreCuenta, New String(">"c, tab))
      If cuenta.Padre IsNot Nothing AndAlso cuenta.Padre.IdCuenta <> 0 Then
         RefrescarJerarquia(stb, cuenta.Padre, tab + 2)
      End If
   End Sub

   Private Sub CargarProximoNumero()
      If String.IsNullOrEmpty(Me.cmbNivel.Text) Then
         Exit Sub
      End If
      Dim oCuenta As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
      Dim ProximoID As Integer
      ProximoID = oCuenta.GetIdMaximo(Int32.Parse(Me.cmbNivel.Text) + 1) + 1
      Me.txtCodigo.Text = ProximoID.ToString()
   End Sub

#End Region

End Class