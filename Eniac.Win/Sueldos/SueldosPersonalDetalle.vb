Option Strict Off
Imports Eniac.Reglas
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class SueldosPersonalDetalle

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos
   Private _publicosSueldos As Publicos
    Private _EstaCargando As Boolean = True

#End Region

#Region "Constructores"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
   End Sub

    Public Sub New(ByVal entidad As Entidades.SueldosPersonal)
        Me.InitializeComponent()
        Me._entidad = entidad
    End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Eniac.Win.Publicos()
      Me._publicosSueldos = New Publicos()

      Me._publicos.CargaComboTipoDocumento(Me.cmbTipoDoc)
      Me.cmbTipoDoc.SelectedIndex = -1

      Me._publicos.CargaComboLocalidades(Me.cmbLocalidad)
      Me._publicosSueldos.CargaComboSueldosCategorias(Me.cmbCategoria)
      Me._publicosSueldos.CargaComboSueldosEstadoCivil(Me.cmbEstadoCivil)
      Me._publicosSueldos.CargaComboObraSocial(Me.cmbObraSocial)
      Me._publicosSueldos.CargaComboSueldosMotivosBaja(Me.cmbMotivoBaja)
      Me._publicosSueldos.CargaComboSueldosLugaresActividad(Me.cmbLugarActividad)
      Me._publicosSueldos.CargaComboVinculoFamiliar(Me.cmbVinculoFamiliar)
      Me._publicos.CargaComboBancos(Me.cmbBanco)
      Me._publicos.CargaComboCuentasBancariasClase(Me.cmbClaseDeCuenta)
      '-.PE-31892.-
      Me._publicos.CargaComboNacionalidades(Me.cmbNacionalidad)

      Me.dtpFechaBaja.MinDate = DateTime.MinValue

      Me._liSources.Add("MotivoBaja", DirectCast(Me._entidad, Entidades.SueldosPersonal).MotivoBaja)
      Me._liSources.Add("LugarActividad", DirectCast(Me._entidad, Entidades.SueldosPersonal).LugarActividad)
      Me._liSources.Add("Banco", DirectCast(Me._entidad, Entidades.SueldosPersonal).Banco)
      Me._liSources.Add("CuentaBancariaClase", DirectCast(Me._entidad, Entidades.SueldosPersonal).CuentaBancariaClase)

      Me.BindearControles(Me._entidad, Me._liSources)

      Dim reg As Reglas.SueldosPersonalFamiliares
      reg = New Reglas.SueldosPersonalFamiliares()
      Me._familiaresPersonal = reg.GetSueldosPersonalFamiliares(Me.txtLegajo.Text)
      Me.dgvPersonalFamiliares.DataSource = Me._familiaresPersonal
      Me.dgvPersonalFamiliares.Columns("IdTipoVinculoFamiliar").Visible = False

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()

         Me.cmbTipoDoc.Text = reglas.Publicos.TipoDocumentoProveedor()
         '   Me.chbActivo.Checked = True

         'Me.cmbLocalidad.SelectedValue = actual.Sucursal.Localidad.IdLocalidad
         Me.cmbLocalidad.SelectedValue = actual.Sucursal.LocalidadComercial.IdLocalidad

         DirectCast(Me._entidad, Entidades.SueldosPersonal).Sexo = "M"
         Me.RadioSexoMasculino.Checked = True

         Me.cmbMotivoBaja.Enabled = False
         Me.dtpFechaBaja.Enabled = False

      Else
         If DirectCast(Me._entidad, Entidades.SueldosPersonal).FechaBaja = Nothing Then
            Me.chbFechaBaja.Checked = False
         Else
            Me.chbFechaBaja.Checked = True
         End If
         Me.cmbMotivoBaja.Enabled = Me.chbFechaBaja.Checked
         Me.dtpFechaBaja.Enabled = Me.chbFechaBaja.Checked

         If DirectCast(Me._entidad, Entidades.SueldosPersonal).Sexo = "M" Then
            Me.RadioSexoMasculino.Checked = True
         Else
            Me.RadioSexoFemenino.Checked = True
         End If
      End If

      Me._EstaCargando = False

   End Sub

   Private Sub CargarProximoNumero()
      Dim Obj As Reglas.SueldosPersonal = New Reglas.SueldosPersonal()
      Me.txtLegajo.Text = (Obj.GetCodigoMaximo() + 1).ToString("####0")
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosPersonal
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Me.cmbTipoDoc.Text = "CUIT" Or Me.cmbTipoDoc.Text = "CUIL" Then
         If Me.txtNroDoc.Text.Length <> 11 Then
            Return "El número de " & Me.cmbTipoDoc.Text & " ingresado es inválido, deben ser 11 caracteres y posee " & Me.txtNroDoc.Text.Length.ToString() & "."
         End If
         If Not Eniac.Win.Publicos.EsCuitValido(Me.txtNroDoc.Text) Then
            Return "El número de " & Me.cmbTipoDoc.Text & " ingresado es inválido."
         End If
      End If

      If Me.txtCuil.Text <> "" Then
         If Me.txtCuil.Text.Length <> 11 Then
            Return "El número de CUIT ingresado es inválido, deben ser 11 caracteres y posee " & Me.txtCuil.Text.Length.ToString() & "."
         End If
         If Not Eniac.Win.Publicos.EsCuitValido(Me.txtCuil.Text) Then
            Return "El número de CUIT ingresado es inválido."
         End If
      End If

      If Decimal.Parse(Me.txtSueldoBasico.Text) <= 0 Then
         Return "Debe cargar el Sueldo Básico."
      End If

      MyBase.ValidarDetalle()

      Return String.Empty

   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
      Me.cmbTipoDoc.Text = Reglas.Publicos.TipoDocumentoProveedor()
      Me.cmbLocalidad.SelectedIndex = -1
      Me.cmbCategoria.SelectedIndex = -1
      Me.cmbNacionalidad.SelectedIndex = -1
      '   Me.chbActivo.Checked = True
   End Sub

   Protected Overrides Sub Aceptar()
      HayError = False

      Try
         Dim res As String
         res = Me.ValidarControles().Trim()
         If Me.ValidarDetalle() <> "" Then
            If res = "" Then
               res = Me.ValidarDetalle()
            Else
               res += Convert.ToChar(Keys.Enter) & Me.ValidarDetalle()
            End If
         End If
         If res = "" Then
            Dim oWS As Reglas.SueldosPersonal = Me.GetReglas()
            'Inserto un registro
            If Me.StateForm = StateForm.Insertar Then
               DirectCast(Me._entidad, Entidades.SueldosPersonal).Familiares = Me._familiaresPersonal
               oWS.Insertar2(Me._entidad)
               MessageBox.Show("Se ingreso el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               If Not Me.CierraAutomaticamente Then
                  Me.LimpiarControles()
               End If
            Else
               'Modifico un registro
               DirectCast(Me._entidad, Entidades.SueldosPersonal).Familiares = Me._familiaresPersonal
               oWS.Actualizar2(Me._entidad)
               MessageBox.Show("Se actualizo el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.DialogResult = Windows.Forms.DialogResult.OK
               Me.Close()
            End If
         Else
            MessageBox.Show(res, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            HayError = True
         End If
         If Not Me.HayError And Me.CierraAutomaticamente Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
         End If
      Catch exSql As System.Data.SqlClient.SqlException
         If exSql.Message.Contains("Cannot insert duplicate key in object") Then
         ElseIf exSql.Message.Contains("No puede insertar valores duplicados") Then 'este mensaje cambiarlo por el correcto
            MessageBox.Show("El código ingresado ya existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         ElseIf exSql.Message.Contains("Expire time") Then
            MessageBox.Show("Expiro el tiempo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         ElseIf exSql.Message.Contains("Time out") Then
            MessageBox.Show("Expiro el tiempo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(exSql.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
         HayError = True
      Catch ex As Exception
         MessageBox.Show(ex.Message)
         HayError = True
      End Try

   End Sub



#End Region

#Region "Eventos"

   Private Sub txtNroDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroDoc.LostFocus
      If Me.StateForm = Eniac.Win.StateForm.Insertar And (Me.cmbTipoDoc.Text = "CUIL" Or Me.cmbTipoDoc.Text = "CUIT") Then
         '       Me.txtCuil.Text = Me.txtNroDoc.Text
      End If
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

      If Not Me.HayError Then Me.Close()



      Me.cmbTipoDoc.Focus()
   End Sub

   Private Sub cmbTipoDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDoc.SelectedIndexChanged
      Try
         If Me.cmbTipoDoc.SelectedIndex >= 0 And Me.StateForm = Eniac.Win.StateForm.Insertar Then

            Dim oRegTipoDoc As Eniac.Reglas.TiposDocumento = New Eniac.Reglas.TiposDocumento()
            Dim oTipoDoc As Eniac.Entidades.TipoDocumento

            oTipoDoc = oRegTipoDoc.GetUno(Me.cmbTipoDoc.SelectedValue.ToString())

            If oTipoDoc.EsAutoincremental Then

               Dim oRegProveedor As Reglas.SueldosPersonal = New Reglas.SueldosPersonal()

               Dim ProximoProveedor As Long

               '   ProximoProveedor = oRegProveedor.GetNroDocumentoMaximo(Me.cmbTipoDoc.SelectedValue.ToString()) + 1

               Me.txtNroDoc.Text = ProximoProveedor.ToString()

            End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub RadioSexoMasculino_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSexoMasculino.CheckedChanged
      If Me._EstaCargando Then Exit Sub

      If Me.RadioSexoMasculino.Checked = True Then

         DirectCast(Me._entidad, Entidades.SueldosPersonal).Sexo = "M"
      End If


   End Sub

   Private Sub RadioSexoFemenino_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSexoFemenino.CheckedChanged
      If Me._EstaCargando Then Exit Sub

      If Me.RadioSexoFemenino.Checked = True Then

         DirectCast(Me._entidad, Entidades.SueldosPersonal).Sexo = "F"
      End If

   End Sub

   Private Sub txtCBU_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCBU.Leave
      Try
         If Not String.IsNullOrEmpty(Me.txtCBU.Text) Then
            If Not Double.Parse(Me.txtCBU.Text) = 0 Then
               If Not Eniac.Win.Publicos.EsCBUValido(Me.txtCBU.Text) Then
                  MessageBox.Show("El Nro. de CBU no es Válido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.txtCBU.Focus()
               End If
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaBaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFechaBaja.CheckedChanged
      Try
         Me.cmbMotivoBaja.Enabled = Me.chbFechaBaja.Checked
         Me.dtpFechaBaja.Enabled = Me.chbFechaBaja.Checked
         Me.cmbMotivoBaja.IsRequired = Me.cmbMotivoBaja.Enabled
         If Me.chbFechaBaja.Enabled = False Then
            DirectCast(Me._entidad, Entidades.SueldosPersonal).MotivoBaja.IdMotivoBaja = 0
            DirectCast(Me._entidad, Entidades.SueldosPersonal).FechaBaja = Nothing
            Me.cmbMotivoBaja.SelectedIndex = -1
         Else
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertarFamiliar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarFamiliar.Click
      Try

         If Me.txtCuilFamiliar.Text.Trim() = "" Then
            MessageBox.Show("El CUIT no puede quedar en blanco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCuilFamiliar.Focus()
            Exit Sub
         End If

         If Me.txtNombreFamiliar.Text.Trim() = "" Then
            MessageBox.Show("El Nombre no puede quedar en blanco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNombreFamiliar.Focus()
            Exit Sub
         End If

         If Me.cmbSexoFamiliar.SelectedIndex = -1 Then
            MessageBox.Show("Deje Elegir el Sexo del Familia.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbSexoFamiliar.Focus()
            Exit Sub
         End If

         If Me.cmbVinculoFamiliar.SelectedIndex = -1 Then
            MessageBox.Show("El Vínculo no puede quedar en blanco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbVinculoFamiliar.Focus()
            Exit Sub
         End If

         If Me.ExisteFamiliar(Me.txtCuilFamiliar.Text) Then
            MessageBox.Show("Ya existe el Familiar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCuilFamiliar.Focus()
            Exit Sub
         Else
            If Me.dtpFechaNacFamiliar.Text > Date.Today() Then
               MessageBox.Show("La fecha de Nacimiento del Familiar es mayor a la fecha actual", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.dtpFechaNacFamiliar.Focus()
               Exit Sub
            End If
            If Me.txtCuilFamiliar.Text.Length <> 11 Then
               MessageBox.Show("El número de CUIL del Familiar ingresado es inválido, deben ser 11 caracteres y posee " & Me.txtCuilFamiliar.Text.Length.ToString() & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtCuilFamiliar.Focus()
               Exit Sub
            End If
            If Not Eniac.Win.Publicos.EsCuitValido(Me.txtCuilFamiliar.Text) Then
               MessageBox.Show("El número de CUIL ingresado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtCuilFamiliar.Focus()
               Exit Sub
            End If
         End If

         Me.AgregarFamiliar()
         Me.LimpiarCamposFamiliar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarFamiliar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarFamiliar.Click
      Try
         If Me.dgvPersonalFamiliares.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el Familiar seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaFamiliar()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnRefrescarFamiliar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescarFamiliar.Click
      Try
         Me.LimpiarCamposFamiliar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvPersonalFamiliares_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPersonalFamiliares.CellDoubleClick

      Try
         'limpia los textbox, y demas controles
         Me.LimpiarCamposFamiliar()

         'carga el Familiar seleccionado de la grilla en los textbox 
         Me.CargarFamiliarCompleto(Me.dgvPersonalFamiliares.Rows(e.RowIndex))

         'elimina el Familiar de la grilla
         Me.EliminarLineaFamiliar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Métodos"

   Private _familiaresPersonal As DataTable

   Private Function ExisteFamiliar(ByVal CuilFamiliar As Long) As Boolean
      If Me.dgvPersonalFamiliares.Rows.Count > 0 Then
         For Each dr As DataGridViewRow In Me.dgvPersonalFamiliares.Rows
            If Long.Parse(dr.Cells("Cuil").Value.ToString()) = CuilFamiliar Then
               Return True
            End If
         Next
      End If

      Return False

   End Function

   Private Sub AgregarFamiliar()

      Dim dr As DataRow = Me._familiaresPersonal.NewRow()

      dr(0) = Me.txtLegajo.Text
      dr(1) = Me.txtCuilFamiliar.Text
      dr(2) = Me.txtNombreFamiliar.Text
      dr(3) = Me.dtpFechaNacFamiliar.Value
      dr(4) = Me.cmbSexoFamiliar.SelectedItem.ToString()
      dr(5) = DirectCast(Me.cmbVinculoFamiliar.SelectedItem, Eniac.Entidades.SueldosTiposVinculoFamiliar).idTipoVinculoFamiliar
      dr(6) = DirectCast(Me.cmbVinculoFamiliar.SelectedItem, Eniac.Entidades.SueldosTiposVinculoFamiliar).NombreVinculoFamiliar

      Me._familiaresPersonal.Rows.Add(dr)
      Me.dgvPersonalFamiliares.DataSource = Me._familiaresPersonal

   End Sub

   Private Sub EliminarLineaFamiliar()
      Me._familiaresPersonal.Rows(Me.dgvPersonalFamiliares.SelectedRows(0).Index).Delete()
      Me.dgvPersonalFamiliares.DataSource = Me._familiaresPersonal
   End Sub

   Private Sub LimpiarCamposFamiliar()
      Me.txtCuilFamiliar.Text = ""
      Me.txtNombreFamiliar.Text = ""
      Me.dtpFechaNacFamiliar.Value = Date.Now
      Me.cmbSexoFamiliar.SelectedIndex = -1
      Me.cmbVinculoFamiliar.SelectedIndex = -1
   End Sub

   Private Sub CargarFamiliarCompleto(ByVal dr As DataGridViewRow)

      Me.txtCuilFamiliar.Text = dr.Cells("Cuil").Value.ToString.Trim()
      Me.txtNombreFamiliar.Text = dr.Cells("NombreFamiliar").Value.ToString.Trim()
      Me.dtpFechaNacFamiliar.Value = Date.Parse(dr.Cells("FechaNacimientoFamiliar").Value.ToString.Trim())
      Me.cmbSexoFamiliar.SelectedValue = dr.Cells("SexoFamiliar").Value.ToString().Trim()
      Me.cmbVinculoFamiliar.SelectedValue = dr.Cells("VinculoFamiliar").Value.ToString().Trim()
   End Sub

#End Region

End Class
