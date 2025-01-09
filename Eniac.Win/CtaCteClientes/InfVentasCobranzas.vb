#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
#End Region
Public Class InfVentasCobranzas

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)

         Me._publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
         Me.cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento

         If IdUsuario = "" Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            Me.chbVendedor.Checked = True
            Me.chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
            Me.cmbOrigenVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         Me._publicos.CargaComboDesdeEnum(cmbOrigenCobrador, GetType(Entidades.OrigenFK))
         Me.cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Movimiento

         ugDetalle.AgregarTotalesSuma({"ImporteTotal", "ImporteCobrar", "ImporteTotalContado", "ImporteTotalCuentaCorriente", "ImporteCobrado", "ImporteCobradoSinVencer", "ImporteCobradoVencido", "ImporteCalculado"})
         ugDetalle.AgregarTotalCustomColumna("CoeficienteCobranza", New Ayudante.CustomSummaries.SummaryMargen("ImporteCalculado", "ImporteTotal", "CoeficienteCobranza"))
         ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         Me.PreferenciasLeer(ugDetalle, tsbPreferencias)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
#End Region

#Region "Eventos"
   Private Sub ConsultarRecibosAClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         .AppendFormat("Fechas: desde " & Date.Parse(dtpDesde.Text).ToString("dd/MM/yyyy") & " hasta " & Date.Parse(dtpHasta.Text).ToString("dd/MM/yyyy"))

         If Me.chbCliente.Checked And (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            .AppendFormat(" Cliente: " & Me.bscCodigoCliente.Text & " - " & Me.bscCliente.Text)
         End If

         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: " & Me.cmbVendedor.Text)
         End If
         If Me.chbCobrador.Checked Then
            .AppendFormat(" Cobrador: " & Me.cmbCobrador.Text)
         End If
      End With


      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count() = 0 Then Exit Sub

         Me.Cursor = Cursors.WaitCursor

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, CargarFiltrosImpresion)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Try
         chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta)
      Catch ex As Exception
         Me.chkMesCompleto.Checked = False
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Try
         chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
      Try
         chbVendedor.FiltroCheckedChanged(cmbVendedor)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbCobrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCobrador.CheckedChanged
      Try
         chbCobrador.FiltroCheckedChanged(cmbCobrador)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Eventos Foraneos"
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
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Cliente pero NO selecciono", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If
         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un Vendedor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbVendedor.Focus()
            Exit Sub
         End If
         If Me.chbCobrador.Checked And Me.cmbCobrador.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un Cobrador aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbCobrador.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

#End Region

#Region "Metodos"
   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.chbCliente.Checked = False
      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
         Me.cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento
      End If

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.chbCobrador.Checked = False
      Me.cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Movimiento

      If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      cmbSucursal.Refrescar()

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try
         Dim dtDetalle As DataTable
         Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

         Dim IdCliente As Long = If(Me.chbCliente.Checked And (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono), Long.Parse(Me.bscCodigoCliente.Tag.ToString()), 0)

         Dim origenVendedor As Entidades.OrigenFK = DirectCast(cmbOrigenVendedor.SelectedValue, Entidades.OrigenFK)
         Dim IdVendedor As Integer = If(Me.cmbVendedor.Enabled, DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado, 0)

         Dim origenCobrador As Entidades.OrigenFK = DirectCast(cmbOrigenCobrador.SelectedValue, Entidades.OrigenFK)
         Dim IdCobrador As Integer = If(Me.cmbCobrador.Enabled, Integer.Parse(Me.cmbCobrador.SelectedValue.ToString()), 0)



         dtDetalle = oCtaCte.GetInfVentasCobranzas(Me.dtpDesde.Value,
                                                   Me.dtpHasta.Value,
                                                   IdCliente,
                                                   IdVendedor,
                                                   origenVendedor,
                                                   IdCobrador,
                                                   origenCobrador,
                                                   Me.cmbSucursal.GetSucursales())

         Me.ugDetalle.DataSource = dtDetalle

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class