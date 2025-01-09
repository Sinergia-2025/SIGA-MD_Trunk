#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class CajasNombresDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.CajaNombre)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Campos"

   Private _publicos As Publicos
   Private _publicosCont As ContabilidadPublicos
   Private _titUsuarios As Dictionary(Of String, String)
   Dim _usuariosCajas As DataTable

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)


      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.CierraAutomaticamente = True

      Me._publicos.CargaComboSucursales(Me.cmbSucursales)
      Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

      Me._publicosCont = New ContabilidadPublicos
      Me._publicosCont.CargaComboPlanes(cmbPlan, False)

      Me._publicos.CargaComboTiposComprobantes(Me.cmbComprobantesF3, False, "VENTAS", , , "SI", True)
      'Copio la lista de tipos de comprobante para no acceder 4 veces a buscar los mismo ya que los 4 combos muestran lo mismo.
      Dim lst2 As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)(DirectCast(cmbComprobantesF3.DataSource, List(Of Entidades.TipoComprobante)))
      Me._publicos.CargaComboTiposComprobantes(Me.cmbComprobantesF4, lst2)
      lst2 = New List(Of Entidades.TipoComprobante)(DirectCast(cmbComprobantesF3.DataSource, List(Of Entidades.TipoComprobante)))
      Me._publicos.CargaComboTiposComprobantes(Me.cmbComprobantesF7Destino, lst2)
      lst2 = New List(Of Entidades.TipoComprobante)(DirectCast(cmbComprobantesF3.DataSource, List(Of Entidades.TipoComprobante)))
      Me._publicos.CargaComboTiposComprobantes(Me.cmbComprobantesF7Origen, lst2)


      If Publicos.TieneModuloContabilidad Then
         Me._publicosCont.CargaComboPlanes(cmbPlan, False)
         Me.gpoContabilidad.Visible = True
         'Me.Width = 621
         'Me.Height = 604
      Else
         Me.gpoContabilidad.Visible = False
         'Me.Width = 621
         'Me.Height = 526

      End If

      Me.BindearControles(Me._entidad)

      Me.cmbSucursales.SelectedValue = actual.Sucursal.Id
      DirectCast(Me._entidad, Entidades.CajaNombre).IdSucursal = actual.Sucursal.Id

      Dim oUsu As Reglas.Usuarios = New Reglas.Usuarios()
      _titUsuarios = GetColumnasVisiblesGrilla(dgvUsuarios)

      With Me.dgvUsuarios
         .DataSource = oUsu.GetAll("CadenaSegura")
      End With
      AjustarColumnasGrilla(dgvUsuarios, _titUsuarios)
      Me.dgvUsuarios.Refresh()

      Me.CargarUsuariosCajas()

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
         DirectCast(Me._entidad, Entidades.CajaNombre).Usuario = actual.Nombre
      Else
         If Me.txtNombrePC.Text.Trim.Length > 0 Then
            Me.chbNombrePC.Checked = True
         End If

         chbColor.Checked = DirectCast(Me._entidad, Entidades.CajaNombre).Color.HasValue
         btnColor.Enabled = chbColor.Checked
         txtColor.Enabled = chbColor.Checked

         If DirectCast(Me._entidad, Entidades.CajaNombre).Color.HasValue Then
            Me.txtColor.BackColor = System.Drawing.Color.FromArgb(DirectCast(Me._entidad, Entidades.CajaNombre).Color.Value)
         Else
            Me.txtColor.BackColor = Nothing
         End If

      End If
      If Publicos.TieneModuloContabilidad Then
         If Me.bscCodCuenta.Text <> "0" Then
            Me.bscCodCuenta.PresionarBoton()
         End If
      End If
      If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.CajaNombre).IdUsuario) Then
         Me.chbUsuario.Checked = True
      End If

      If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.CajaNombre).IdTipoComprobanteF3) Then
         Me.chbTeclaF3.Checked = True
      End If

      If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.CajaNombre).IdTipoComprobanteF4) Then
         Me.chbTeclaF4.Checked = True
      End If

      If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.CajaNombre).IdTipoComprobanteF10Origen) Then
         Me.chbTeclaF10.Checked = True
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CajasNombres
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Me.chbNombrePC.Checked And Me.txtNombrePC.Text.Trim.Length = 0 Then
         Me.txtNombrePC.Focus()
         Return "ATENCION: Activo la PC por Defecto. Debe elegir una."
      End If

      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      Me.HayError = False

      If Me._usuariosCajas IsNot Nothing Then
         Me._usuariosCajas.AcceptChanges()
      End If
      If Not Publicos.TieneModuloContabilidad Then
         DirectCast(Me._entidad, Entidades.CajaNombre).IdPlanCuenta = 1
      Else
         If CInt(Me.cmbPlan.SelectedValue) = 0 Then
            DirectCast(Me._entidad, Entidades.CajaNombre).IdPlanCuenta = 1
         Else
            DirectCast(Me._entidad, Entidades.CajaNombre).IdPlanCuenta = Integer.Parse(Me.cmbPlan.SelectedValue.ToString())
            DirectCast(Me._entidad, Entidades.CajaNombre).IdCuentaContable = Long.Parse(Me.bscCodCuenta.Text)
         End If
      End If

      If Not chbColor.Checked Then
         DirectCast(Me._entidad, Entidades.CajaNombre).Color = Nothing
      End If

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
            Dim oWS As Reglas.CajasNombres = New Reglas.CajasNombres()
            'Inserto un registro
            If Me.StateForm = StateForm.Insertar Then
               oWS.InsertarUna(Me._entidad, _usuariosCajas)
               MessageBox.Show("Se ingreso el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               If Not Me.CierraAutomaticamente Then
                  Me.LimpiarControles()
               End If
            Else

               'Modifico un registro
               'If Not Me.CierraAutomaticamente Then     --Dejo el funcionamiento Original de Editar en lugar de Visualizar
               oWS.ActualizarUna(Me._entidad, _usuariosCajas)
               MessageBox.Show("Se actualizo el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               'End If
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

   Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
      If Not Me.chbUsuario.Checked Then
         Me.cmbUsuario.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.CajaNombre).IdUsuario = String.Empty
      End If
      Me.cmbUsuario.Enabled = Me.chbUsuario.Checked
   End Sub

   Private Sub chbNombrePC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNombrePC.CheckedChanged

      If Not Me.chbNombrePC.Checked Then
         Me.txtNombrePC.Text = ""
         DirectCast(Me._entidad, Entidades.CajaNombre).NombrePC = ""
      End If

      Me.txtNombrePC.Enabled = Me.chbNombrePC.Checked

   End Sub

   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
      If Me.dgvUsuarios.SelectedRows.Count > 0 Then
         For Each dg As DataGridViewRow In Me.dgvUsuarios.SelectedRows
            If Me._usuariosCajas.Select("IdUsuario = '" & dg.Cells("Id").Value.ToString() & "'").Length = 0 Then
               Dim dr As DataRow = Me._usuariosCajas.NewRow()
               dr(0) = Me.cmbSucursales.SelectedValue
               dr(1) = Me.txtIdCaja.Text
               dr(2) = dg.Cells("Id").Value
               dr(3) = dg.Cells("Nombre").Value
               dr(4) = Me.ChbPermitirEscritura.Checked
               Me._usuariosCajas.Rows.Add(dr)
            End If
         Next

      End If
   End Sub

   Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
      If Me.dgvUsuariosCajas.SelectedCells.Count > 0 Then
         Me.dgvUsuariosCajas.Rows.Remove(Me.dgvUsuariosCajas.SelectedRows(0))
      End If
   End Sub

   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
      Try
         Me.cdColor.Color = Me.txtColor.BackColor

         If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtColor.Key = Me.cdColor.Color.ToArgb().ToString()
            DirectCast(Me._entidad, Entidades.CajaNombre).Color = Me.cdColor.Color.ToArgb()
            Me.txtColor.BackColor = Me.cdColor.Color
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbColor_CheckedChanged(sender As Object, e As EventArgs) Handles chbColor.CheckedChanged
      btnColor.Enabled = chbColor.Checked
      txtColor.Enabled = chbColor.Checked
      If chbColor.Checked Then
         btnColor.Focus()
      End If
   End Sub

   Private Sub chbTeclaF3_CheckedChanged(sender As Object, e As EventArgs) Handles chbTeclaF3.CheckedChanged
      If Not Me.chbTeclaF3.Checked Then
         Me.cmbComprobantesF3.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.CajaNombre).IdTipoComprobanteF3 = String.Empty
      End If
      Me.cmbComprobantesF3.Enabled = Me.chbTeclaF3.Checked
   End Sub

   Private Sub chbTeclaF4_CheckedChanged(sender As Object, e As EventArgs) Handles chbTeclaF4.CheckedChanged
      If Not Me.chbTeclaF4.Checked Then
         Me.cmbComprobantesF4.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.CajaNombre).IdTipoComprobanteF4 = String.Empty
      End If
      Me.cmbComprobantesF4.Enabled = Me.chbTeclaF4.Checked
   End Sub

   Private Sub chbTeclaF7_CheckedChanged(sender As Object, e As EventArgs) Handles chbTeclaF10.CheckedChanged
      If Not Me.chbTeclaF10.Checked Then
         Me.cmbComprobantesF7Origen.SelectedIndex = -1
         Me.cmbComprobantesF7Destino.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.CajaNombre).IdTipoComprobanteF10Origen = String.Empty
         DirectCast(Me._entidad, Entidades.CajaNombre).IdTipoComprobanteF10Destino = String.Empty
      End If
      Me.cmbComprobantesF7Origen.Enabled = Me.chbTeclaF10.Checked
      Me.cmbComprobantesF7Destino.Enabled = Me.chbTeclaF10.Checked
   End Sub

#End Region

#Region "Buscadores"

   Private Sub bscCodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicosCont.PreparaGrillaCuentas(Me.bscCodCuenta)
         Me.bscCodCuenta.Datos = oAsientos.GetCuentasImputablesXCodigo(Long.Parse(Me.bscCodCuenta.Text.Trim()))

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodCuenta_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodCuenta.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
            Me.bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescCuenta_BuscadorClick() Handles bscDescCuenta.BuscadorClick
      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicosCont.PreparaGrillaCuentas(Me.bscDescCuenta)
         Me.bscDescCuenta.Datos = oAsientos.GetCuentasImputablesXNombre(Me.bscDescCuenta.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescCuenta_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscDescCuenta.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
            Me.bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oCajas As Reglas.CajasNombres = New Reglas.CajasNombres()
      Me.txtIdCaja.Text = (oCajas.GetCodigoMaximo(Integer.Parse(Me.cmbSucursales.SelectedValue.ToString())) + 1).ToString("####0")
   End Sub


   Private Sub CargarUsuariosCajas()
      Dim oUsuCaj As Reglas.CajasUsuarios = New Reglas.CajasUsuarios()
      With Me.dgvUsuariosCajas
         If Me.cmbSucursales.SelectedIndex > -1 Then
            Me._usuariosCajas = oUsuCaj.GetUsuariosPorCaja(Me.txtIdCaja.Text, Integer.Parse(Me.cmbSucursales.SelectedValue.ToString()))
         Else
            Me._usuariosCajas = oUsuCaj.GetUsuariosPorCaja(Me.txtIdCaja.Text, 0)
         End If
         .DataSource = Me._usuariosCajas
      End With
      Me.FormatearGrillaUsuariosCajas()
   End Sub

   Private Sub FormatearGrillaUsuariosCajas()
      With Me.dgvUsuariosCajas
         .Columns("Nombre").HeaderText = "Usuario"
         .Columns("Nombre").Width = 140
         .Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
         .Columns("IdUsuario").HeaderText = "Id"
         .Columns("IdUsuario").Width = 60
         .Columns("IdSucursal").Visible = False
         .Columns("IdCaja").Visible = False
         .Columns("PermitirEscritura").HeaderText = "Permitir Escritura"
         .Columns("PermitirEscritura").Width = 50
      End With
   End Sub

#End Region


End Class