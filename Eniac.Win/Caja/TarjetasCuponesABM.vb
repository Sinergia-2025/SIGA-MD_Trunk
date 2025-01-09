Public Class TarjetasCuponesABM


#Region "Campos"
   Private cargando As Boolean = False
   Private _publicos As Publicos

#End Region
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Try
         tsbBorrar.Visible = False
         tstColumnas.Visible = False
         tstBuscar.Visible = False
         tsbFiltrar.Visible = False
         tsbImprimirDirecto.Visible = False
         tsbImprimir.Visible = False
         tsbPrePrint.Visible = False
         tsbVistaEspecial.Visible = False

         Me._publicos = New Publicos()
         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = False, blnCajasModificables As Boolean = True

         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)
         Me.cmbCajas.SelectedIndex = -1

         Me._publicos.CargaComboBancos(Me.cmbBanco)

         Me._publicos.CargaComboDesdeEnum(cmbEstado, GetType(Entidades.TarjetaCupon.Estados))
         Me.cmbEstado.SelectedIndex = -1

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         _publicos.CargaComboSituacion(cmbSituacionTarjetaCupones)
         cmbSituacionTarjetaCupones.SelectedIndex = -1
      Catch ex As Exception
         ShowError(ex)
      End Try

      MyBase.OnLoad(e)

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TarjetasCupones()
   End Function

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TarjetasCuponesDetalle(DirectCast(GetEntidad(), Entidades.TarjetaCupon))
      End If
      Return New TarjetasCuponesDetalle(New Entidades.TarjetaCupon())
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
         Sub()
            Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

            'Dim frmImprime = New VisorReportes("Eniac.Win.ChequesDeTerceros.rdlc", "SistemaDataSet_Cheques", dtDatos, parm, True, 1) '# 1 = Cantidad Copias
            'frmImprime.Text = Text
            'frmImprime.WindowState = FormWindowState.Maximized
            'frmImprime.Show()
         End Sub)
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim oTarCup = New Entidades.TarjetaCupon()

      With Me.dgvDatos.ActiveRow
         oTarCup = New Reglas.TarjetasCupones().GetUno(Integer.Parse(.Cells("IdTarjetaCupon").Value.ToString()))
      End With

      Return oTarCup
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return CargaGrillaDetalle()
      'Return DirectCast(rg, Reglas.TarjetasCupones).GetAll()
   End Function

   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable

      'Return DirectCast(rg, Reglas.TarjetasCupones).Buscar(bus)
   End Function
   Protected Overrides Sub FormatearGrilla()

      With dgvDatos.DisplayLayout.Bands(0)
         dgvDatos.OcultaTodasLasColumnas()

         Dim pos As Integer = 0
         .Columns("IdTarjetaCupon").Hidden = True
         .Columns("IdSucursal").FormatearColumna("Suc", pos, 50, HAlign.Right)
         .Columns("IdTarjeta").Hidden = True
         .Columns("NombreTarjeta").FormatearColumna("Tarjeta", pos, 150, HAlign.Left)
         .Columns("IdBanco").Hidden = True
         .Columns("NombreBanco").FormatearColumna("Banco", pos, 150, HAlign.Left)

         .Columns("Monto").FormatearColumna("Importe", pos, 70, HAlign.Right, False, "N2")
         .Columns("Cuotas").FormatearColumna("Cuota", pos, 50, HAlign.Right)
         .Columns("NumeroLote").FormatearColumna("Lote", pos, 50, HAlign.Right)
         .Columns("NumeroCupon").FormatearColumna("Cupon", pos, 50, HAlign.Right)

         .Columns("IdEstadoTarjeta").FormatearColumna("Estado", pos, 100)
         .Columns("NombreSituacionCupon").FormatearColumna("Situacion", pos, 100)

         .Columns("NombreCajaIngreso").FormatearColumna("Caja Ingreso", pos, 100)

         .Columns("FechaEmision").FormatearColumna("Emision", pos, 100, HAlign.Center)

         .Columns("IdCliente").Hidden = True
         .Columns("CodigoCliente").Hidden = True
         .Columns("NombreCliente").FormatearColumna("Nombre Cliente", pos, 200)

         .Columns("IdSituacionCupon").Hidden = True
      End With
      dgvDatos.AgregarFiltroEnLinea({"Titular", "NombreCliente", "NombreProveedor"})
   End Sub

   Private Sub chbFechaIngreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFechaIngreso.CheckedChanged
      If Not Me.chbFechaIngreso.Checked Then
         Me.dtpIngresoDesde.Value = Date.Now
         Me.dtpIngresoHasta.Value = Date.Now
      End If
      Me.dtpIngresoDesde.Enabled = Me.chbFechaIngreso.Checked
      Me.dtpIngresoHasta.Enabled = Me.chbFechaIngreso.Checked
   End Sub
   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      If Not Me.chbEstado.Checked Then
         Me.cmbEstado.SelectedIndex = -1
      End If
      Me.cmbEstado.Enabled = Me.chbEstado.Checked
   End Sub
   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumeroCupon.CheckedChanged
      Me.txtNumeroCupon.Enabled = Me.chbNumeroCupon.Checked
      If Not Me.chbNumeroCupon.Checked Then
         Me.txtNumeroCupon.Text = ""
      Else
         Me.txtNumeroCupon.Focus()
      End If
   End Sub
   Private Sub chbNumeroLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroLote.CheckedChanged
      Me.txtNumeroLote.Enabled = Me.chbNumeroLote.Checked
      If Not Me.chbNumeroLote.Checked Then
         Me.txtNumeroLote.Text = ""
      Else
         Me.txtNumeroLote.Focus()
      End If
   End Sub
   Private Sub chbFechaEnCarteraAl_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEnCarteraAl.CheckedChanged
      If Not Me.chbFechaEnCarteraAl.Checked Then
         Me.dtpFechaEnCarteraAl.Value = Date.Now
      End If
      Me.dtpFechaEnCarteraAl.Enabled = Me.chbFechaEnCarteraAl.Checked
   End Sub
   Private Sub chbCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCaja.CheckedChanged
      Try
         If Not Me.chbCaja.Checked Then
            Me.cmbCajas.SelectedIndex = -1
         Else
            Me.cmbCajas.Focus()
         End If
         Me.cmbCajas.Enabled = Me.chbCaja.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbBanco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbBanco.CheckedChanged
      If Not Me.chbBanco.Checked Then
         Me.cmbBanco.SelectedIndex = -1
      End If
      Me.cmbBanco.Enabled = Me.chbBanco.Checked
   End Sub
   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         If Me.chbCaja.Checked And Me.cmbCajas.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Caja aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbCajas.Focus()
            Exit Sub
         End If

         If Me.chbBanco.Checked And Me.cmbBanco.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Banco aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbBanco.Focus()
            Exit Sub
         End If

         If Me.chbNumeroCupon.Checked And (Me.txtNumeroCupon.Text = "" OrElse Long.Parse(Me.txtNumeroCupon.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroCupon.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbEstado.Checked And Me.cmbEstado.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Estado aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbEstado.Focus()
            Exit Sub
         End If

         If Me.chbNumeroCupon.Checked And (Me.txtNumeroCupon.Text = "" OrElse Integer.Parse(Me.txtNumeroCupon.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero de Cupon aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroCupon.Focus()
            Exit Sub
         End If

         If Me.chbNumeroLote.Checked And (Me.txtNumeroLote.Text = "" OrElse Integer.Parse(Me.txtNumeroLote.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero de Lote aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroLote.Focus()
            Exit Sub
         End If

         If Me.chbSituacion.Checked And Me.cmbSituacionTarjetaCupones.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Situacion aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbSituacionTarjetaCupones.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.dgvDatos.DataSource = CargaGrillaDetalle()
         FormatearGrilla()

         Me.tssRegistros.Text = Me.dgvDatos.Rows.Count.ToString() & " Registros"

         If Me.dgvDatos.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Protected Overrides Sub LimpiarFiltros()
      MyBase.LimpiarFiltros()
      Try
         cargando = True
         Me.RefrescarDatosGrilla()
      Finally
         cargando = False
      End Try
   End Sub

   Private Sub RefrescarDatosGrilla()
      Me.chbCaja.Checked = False
      Me.chbNumeroCupon.Checked = False
      Me.chbBanco.Checked = False
      Me.chbEstado.Checked = False
      Me.chbFechaIngreso.Checked = True
      Me.chbFechaEnCarteraAl.Checked = False
      Me.chbNumeroCupon.Checked = False
      Me.chbNumeroLote.Checked = False
      Me.chbBanco.Checked = False
      Me.chbCliente.Checked = False

      cmbSucursal.Refrescar()

      If Not Me.dgvDatos.DataSource Is Nothing Then
         DirectCast(Me.dgvDatos.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()

   End Sub
   Private Function CargaGrillaDetalle() As DataTable

      Dim idCaja As Integer = 0

      Dim fechaIngresoDesde As Date? = Nothing
      Dim fechaIngresoHasta As Date? = Nothing

      Dim enCarteraAl As Date? = Nothing

      Dim idBanco As Integer = 0


      Dim idCliente As Long = 0

      Dim numeroCupon As Integer = 0
      Dim numeroLote As Integer = 0
      Dim idTarjeta As Integer = 0
      Dim estadoCupon As Entidades.TarjetaCupon.Estados
      Dim oCupones As Reglas.TarjetasCupones = New Reglas.TarjetasCupones()

      Dim idSituacion As Integer = 0

      If Me.chbFechaIngreso.Checked Then
         fechaIngresoDesde = Me.dtpIngresoDesde.Value
         fechaIngresoHasta = Me.dtpIngresoHasta.Value
      End If

      If Me.chbFechaEnCarteraAl.Checked Then
         enCarteraAl = Me.dtpFechaEnCarteraAl.Value
      End If

      If Me.chbCaja.Checked Then
         idCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
      End If

      If Me.chbBanco.Checked Then
         idBanco = Integer.Parse(Me.cmbBanco.SelectedValue.ToString())
      End If

      If Me.chbNumeroCupon.Checked Then
         numeroCupon = Integer.Parse(Me.txtNumeroCupon.Text)
      End If

      If Me.chbNumeroLote.Checked Then
         numeroLote = Integer.Parse(Me.txtNumeroLote.Text)
      End If

      If Me.chbCliente.Checked Then
         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If Me.chbEstado.Checked Then
         estadoCupon = DirectCast([Enum].Parse(GetType(Entidades.TarjetaCupon.Estados), Me.cmbEstado.SelectedValue.ToString()), Entidades.TarjetaCupon.Estados)
      Else
         estadoCupon = Entidades.TarjetaCupon.Estados.NINGUNO
      End If
      If chbSituacion.Checked Then
         idSituacion = Integer.Parse(cmbSituacionTarjetaCupones.SelectedValue.ToString())
      End If

      Return oCupones.GetInformeCupones(cmbSucursal.GetSucursales(),
                                        0,
                                        fechaIngresoDesde,
                                        fechaIngresoHasta,
                                        estadoCupon.ToString(),
                                        Nothing,
                                        Nothing,
                                        numeroCupon,
                                        numeroLote,
                                        enCarteraAl,
                                        idCaja,
                                        idBanco,
                                        idCliente,
                                        idTarjeta,
                                        idSituacion)


   End Function

   Private Sub chbSituacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbSituacion.CheckedChanged
      Try
         If Not Me.chbSituacion.Checked Then
            Me.cmbSituacionTarjetaCupones.SelectedIndex = -1
         Else
            Me.cmbSituacionTarjetaCupones.Focus()
         End If
         Me.cmbSituacionTarjetaCupones.Enabled = Me.chbSituacion.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

End Class