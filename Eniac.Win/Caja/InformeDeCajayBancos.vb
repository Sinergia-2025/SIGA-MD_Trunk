#Region "Imports/Option"
Option Explicit On
Option Strict On

Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
#End Region

Public Class InformeDeCajayBancos

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = False
   Private _blnCajasModificables As Boolean = False
   Private _entro As Boolean = True
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Eniac.Win.Publicos()

         Me._publicos.CargaComboGruposDeCuentas(Me.cmbGrupos)

         Me.cmbEsModificable.Items.Insert(0, "TODOS")
         Me.cmbEsModificable.Items.Insert(1, "SI")
         Me.cmbEsModificable.Items.Insert(2, "NO")
         Me.cmbEsModificable.SelectedIndex = 0

         Me.PreferenciasLeer(ugDetalle, tsbPreferencias)

         Me.CargarColumnasASumar()

         If Not Reglas.Publicos.TieneModuloContabilidad Then
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdPlanCuenta").Hidden = True
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdAsiento").Hidden = True
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("GeneraContabilidad").Hidden = True
         End If

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         InicializaCajas()

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled
         ugDetalle.AgregarFiltroEnLinea({"Observacion"})
         Me.dtpDesde.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub


#End Region

#Region "Eventos"
   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      TryCatched(Sub() InicializaCajas())
   End Sub

   Private Sub ConsultarMovimientosCaja_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar.PerformClick()
      End If
   End Sub

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

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

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

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged
      Try
         chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta)
      Catch ex As Exception
         chkMesCompleto.Checked = False
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbCuentaDeCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCuentaDeCaja.CheckedChanged
      Try
         chbCuentaDeCaja.FiltroCheckedChanged(bscCuentaCaja, bscNombreCuentaCaja)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCuentaCaja_BuscadorClick() Handles bscCuentaCaja.BuscadorClick
      Try
         Me._publicos.PreparaGrillaCuentasDeCajas(Me.bscCuentaCaja)

         Dim oCuentasDeCaja As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas()

         Me.bscCuentaCaja.Datos = oCuentasDeCaja.GetTodas(Me.bscCuentaCaja.Text)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCuentaCaja_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCuentaCaja.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCuentaDeCaja(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreCuentaCaja_BuscadorClick() Handles bscNombreCuentaCaja.BuscadorClick
      Try
         Me._publicos.PreparaGrillaCuentasDeCajas(Me.bscNombreCuentaCaja)

         Dim oCuentasDeCaja As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas()

         bscNombreCuentaCaja.Datos = oCuentasDeCaja.GetPorNombre(Me.bscNombreCuentaCaja.Text)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreCuentaCaja_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreCuentaCaja.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCuentaDeCaja(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbGrupo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbGrupo.CheckedChanged
      Try
         chbGrupo.FiltroCheckedChanged(cmbGrupos)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCuentaDeCaja.Checked And Not Me.bscCuentaCaja.Selecciono And Not Me.bscNombreCuentaCaja.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó una Cuenta aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCuentaCaja.Focus()
            Exit Sub
         End If

         If Me.chbGrupo.Checked And Me.cmbGrupos.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Grupo aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbGrupos.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
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
      If chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton

      If e.Cell.Row.Index <> -1 Then

         Try
            Select Case e.Cell.Column.Index
               Case 0, 1

                  Me.Cursor = Cursors.WaitCursor

                  Dim CDetalle As CajaDetalles = New CajaDetalles()

                  CDetalle.Operacion = Reglas.CajaDetalles.TipoOperacion.Consulta

                  CDetalle.IdSucursalMovimiento = Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString())
                  CDetalle.CajaNombre.IdCaja = Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdCaja").Value.ToString())
                  CDetalle.CajaNombre.NombreCaja = Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NombreCaja").Value.ToString()

                  CDetalle.NumeroPlanilla = Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroPlanilla").Value.ToString())
                  CDetalle.NroDeMovimiento = Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroMovimiento").Value.ToString())

                  CDetalle.btnAceptar.Visible = False



                  If e.Cell.Column.Index = 0 Then
                     CDetalle.ShowDialog()
                  Else
                     Dim numeroPlanilla As Integer = CDetalle.NumeroPlanilla
                     Dim numeroMovimiento As Integer = CDetalle.NroDeMovimiento

                     Dim imp = New ImprimirMovimientoCaja()
                     imp.Imprimir(actual.Sucursal.IdSucursal, CDetalle.CajaNombre.IdCaja, numeroPlanilla, numeroMovimiento, visualiza:=True)
                  End If

               Case Else
            End Select

         Catch ex As Exception
            ShowError(ex)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarDatosCuentaDeCaja(ByVal dr As DataGridViewRow)
      Me.bscNombreCuentaCaja.Text = dr.Cells("NombreCuentaCaja").Value.ToString()
      Me.bscCuentaCaja.Text = dr.Cells("IdCuentaCaja").Value.ToString()
      Me.bscNombreCuentaCaja.Enabled = False
      Me.bscCuentaCaja.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now

      rdbFechaMovimiento.Checked = True
      chbSaldoIniciales.Checked = True
      chbCuentaDeCaja.Checked = False
      chbGrupo.Checked = False
      cmbEsModificable.SelectedIndex = 0

      'If Not Me._filtroMultiplesCajas.dgvDatos.DataSource Is Nothing Then
      '   ReseteaCajas()
      'End If
      _entro = False
      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False
      'Limpio la Grilla.
      ugDetalle.ClearFilas()
      ugDetalle.DisplayLayout.Bands(0).Columns("Caja").Hidden = False

      'Se puede resetear el control de Sucursal de dos formas
      '1.- Seleccionando el valor         - Si tenemos que llevarlo a un valor que no sea el default
      'cmbSucursal.SelectedValue = actual.Sucursal.IdSucursal
      '2.- Ejecutando el método Refrescar - Si tenemos que llevarlo al valor default
      cmbSucursal.Refrescar()
      cmbCajas.Refrescar()

      dtpDesde.Focus()

   End Sub

   Private Sub CargarColumnasASumar()


      ugDetalle.AgregarTotalesSuma({"INGRESOS", "EGRESOS", "I_Ef_$", "E_Ef_$", "I_Ch_$", "E_Ch_$", "I_Ba_$", "E_Ba_$", _
                                    "I_Ta_$", "E_Ta_$", "I_Dol_u$s", "E_Dol_u$s", "I_Ret_$", "E_Ret_$", "Saldo_Ef_$", _
                                    "Saldo_Ch_$", "Saldo_Ta_$", "Saldo_Dol_u$s", "Saldo_Ret_$", "Saldo_Ba_$", "SaldoTotalCaja", "SaldoGeneral"})

      'Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      'Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      'Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales movimientos:"

   End Sub

   Private Sub CargaGrillaDetalle()
      Try
         Dim rCajaDet As Reglas.CajaDetalles = New Reglas.CajaDetalles()
         Dim dtDetalle = rCajaDet.InformeCajayBancos(cmbSucursal.GetSucursales(),
                                                     cmbCajas.GetCajas(True),
                                                     dtpDesde.Value, dtpHasta.Value,
                                                     rdbFechaMovimiento.Checked,
                                                     If(chbCuentaDeCaja.Checked, Integer.Parse(bscCuentaCaja.Text), 0),
                                                     If(chbGrupo.Checked, cmbGrupos.SelectedValue.ToString(), String.Empty),
                                                     cmbEsModificable.Text,
                                                     chbSaldoIniciales.Checked)

         Me.ugDetalle.DataSource = dtDetalle

         Me.tssRegistros.Text = dtDetalle.Rows.Count.ToString() & " Registros"
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
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         .AppendFormat(" - Fecha {0}: Desde {1:dd/MM/yyyy} Hasta {2:dd/MM/yyyy} - ", If(Me.rdbFechaMovimiento.Checked, "Movimiento", "Planilla"), Me.dtpDesde.Value, dtpHasta.Value)

         cmbCajas.CargarFiltrosImpresionCajaNombres(filtro, False, True)

         If Me.chbCuentaDeCaja.Checked Then
            .AppendFormat("Cuenta: {0} - {1} - ", Me.bscCuentaCaja.Text, Me.bscNombreCuentaCaja.Text)
         End If

         If Me.chbGrupo.Checked Then
            .AppendFormat("Grupo: {0} - ", Me.cmbGrupos.Text)
         End If

         If cmbEsModificable.SelectedIndex > 0 Then
            .AppendFormat("Es Modif.: {0} - ", Me.cmbEsModificable.Text)
         End If

         If chbSaldoIniciales.Checked Then
            .AppendFormat("{0} - ", chbSaldoIniciales.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Private Sub InicializaCajas()
      cmbCajas.Inicializar(cmbSucursal.GetSucursales(), blnMiraUsuario:=True, blnMiraPC:=False, blnCajasModificables:=False)
   End Sub

#End Region


End Class