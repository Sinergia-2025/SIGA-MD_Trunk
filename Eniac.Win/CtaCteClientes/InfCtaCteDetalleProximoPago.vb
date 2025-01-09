Public Class InfCtaCteDetalleProximoPago

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre
   Private _utilizaIntereses As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         _utilizaIntereses = New Reglas.Categorias().CategoriasConInteres().Count > 0

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
         If IdUsuario = "" Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            Me.chbVendedor.Checked = True
            Me.chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)

         Me._publicos.CargaComboTiposComprobantesCtaCteClientes(Me.cmbTiposComprobantes)
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0
         Me._publicos.CargaComboProvincias(Me.cmbProvincia)

         Me._publicos.CargaComboGrupos(Me.cmbGrupos)
         Me.cmbGrupos.SelectedIndex = -1

         Me._publicos.CargaComboGrupoCategoria(Me.cmbGrupoCategoria)

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreZonaGeografica").Hidden = (Me.cmbZonaGeografica.Items.Count = 1)

         Me.CargarColumnasASumar()

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("Interes").Hidden = Not _utilizaIntereses

         Me.LeerPreferencias()

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled

         If Reglas.Publicos.CtaCte.PintaColumaCuotaCtaCteCliente Then
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("CuotaNumero").CellAppearance.BackColor = Color.LightCyan
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ugDetalle_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      If e.Cell.Row.Index <> -1 And e.Cell.Column.Header.Caption = "Ver" Then
         Try
            Me.Cursor = Cursors.WaitCursor

            Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
            oTipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString())

            If oTipoComprobante.EsRecibo Or oTipoComprobante.EsAnticipo Then
               Dim IdTipoComprobante As String = IIf(oTipoComprobante.EsRecibo, oTipoComprobante.IdTipoComprobante, oTipoComprobante.IdTipoComprobanteSecundario).ToString()
               Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
               Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()),
                              IdTipoComprobante,
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(),
                              Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()),
                              Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))
               Dim imp As RecibosImprimir = New RecibosImprimir()
               imp.ImprimirRecibo(ctacte, True)
            Else
               Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
               Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()),
                           Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(),
                           Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(),
                           Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()),
                           Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))

               Dim oImpr As Impresion = New Impresion(venta)

               If Not oTipoComprobante.EsFiscal Then
                  oImpr.ImprimirComprobanteNoFiscal(True)
               Else
                  oImpr.ReImprimirComprobanteFiscal()
               End If
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If
   End Sub

   Private Sub InfCtaCteClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.Cursor = Cursors.WaitCursor

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: "
         Dim stb As StringBuilder = New StringBuilder()
         cmbSucursal.CargarFiltrosImpresionSucursales(stb, True, False)
         Filtros = Filtros + stb.ToString()
         Filtros = Filtros + "Rango de Fecha: desde el " & Me.dtpDesde.Text

         If Me.chbCliente.Checked Then
            Filtros = Filtros & " - Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            Filtros = Filtros & " - Tipo Comprobante: " & Me.cmbTiposComprobantes.Text
         End If

         If Me.chbVendedor.Checked Then
            Dim IdVendedor As Integer
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
            Filtros = Filtros & " - Vendedor: " & IdVendedor & " - " & Me.cmbVendedor.Text
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            Filtros = "Zona Geografica: " & Me.cmbZonaGeografica.Text
         End If

         If Me.chbCategoria.Checked Then
            Filtros = Filtros & " - Categoría: " & Me.cmbCategoria.Text
         End If

         If Me.cmbGrabanLibro.SelectedIndex > 0 Then
            Filtros = Filtros & " - Graban Libro: " & Me.cmbGrabanLibro.Text
         End If

         If Me.chbProvincia.Checked Then
            Filtros = Filtros & " - Provincia: " & Me.cmbProvincia.Text
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            Filtros = Filtros & " - Excluir Saldos Negativos"
         End If

         If Me.chbExcluirAnticipos.Checked Then
            Filtros = Filtros & " - Excluir Anticipos"
         End If

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraPrintPreviewDialog1.Name = Me.Text
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimirPrediseñado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPrediseñado.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.Cursor = Cursors.WaitCursor

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: "
         Dim stb As StringBuilder = New StringBuilder()
         cmbSucursal.CargarFiltrosImpresionSucursales(stb, True, False)
         Filtros = Filtros + stb.ToString()
         Filtros = Filtros + "Rango de Fecha: desde el " & Me.dtpDesde.Text

         If Me.chbCliente.Checked Then
            Filtros = Filtros & " - Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            Filtros = Filtros & " - Tipo Comprobante: " & Me.cmbTiposComprobantes.Text
         End If

         If Me.chbVendedor.Checked Then
            Dim IdVendedor As Integer
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
            Filtros = Filtros & " - Vendedor: " & IdVendedor & " - " & Me.cmbVendedor.Text
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            Filtros = "Zona Geografica: " & Me.cmbZonaGeografica.Text
         End If

         If Me.chbCategoria.Checked Then
            Filtros = Filtros & " - Categoría: " & Me.cmbCategoria.Text
         End If

         If Me.cmbGrabanLibro.SelectedIndex > 0 Then
            Filtros = Filtros & " - Graban Libro: " & Me.cmbGrabanLibro.Text
         End If

         If Me.chbProvincia.Checked Then
            Filtros = Filtros & " - Provincia: " & Me.cmbProvincia.Text
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            Filtros = Filtros & " - Excluir Saldos Negativos"
         End If

         If Me.chbExcluirAnticipos.Checked Then
            Filtros = Filtros & " - Excluir Anticipos"
         End If

         Dim dt As DataTable

         'dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)
         dt = DirectCast(Me.ugDetalle.DataSource, DataTable).Copy()


         Dim destinatarios = String.Empty
         If chbCliente.Checked Then
            If bscCodigoCliente.Selecciono Then
               destinatarios = bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
            ElseIf bscCliente.Selecciono Then
               destinatarios = bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
            End If
         End If


         Dim imprimir = New CtasCtesClientesComunes()
         imprimir.ImprimirInformeCtaCteDetalleClientes(dt, Filtros, esPorCliente:=bscCodigoCliente.Text.Length > 0 And bscCliente.Text.Length > 0,
                                                       nombreArchivoDestino:=String.Empty, esImpresionNormal:=True, tituloPantalla:=Text, visualiza:=True, destinatarios)


         '' 'La impresion utiliza el campo que tiene otros datos (Direccion, Localidad, Cuit, Telefono+Celular, Correo y Transporte.
         ''For Each dr As DataRow In dt.Rows
         ''   dr("NombreCliente") = dr("NombreCliente2")
         ''Next

         ''Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
         ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
         ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Titulo", Text))

         ''Dim frmImprime As VisorReportes

         ''If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
         ''   frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteDetalleClientes.rdlc", "SistemaDataSet_CuentasCorrientesPagos", dt, parm, True, 1) '# 1 = Cantidad Copias
         ''Else
         ''   'If Me.rbtImpresionNormal.Checked Then
         ''   frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteDetalleClientesPorVendedor.rdlc", "SistemaDataSet_CuentasCorrientesPagos", dt, parm, True, 1) '# 1 = Cantidad Copias
         ''   'Else
         ''   '   frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteDetalleClientes1PorHoja.rdlc", "SistemaDataSet_CuentasCorrientesPagos", dt, parm, True)
         ''   'End If
         ''End If

         ''frmImprime.Text = Me.Text
         ''frmImprime.WindowState = FormWindowState.Maximized
         ''If chbCliente.Checked Then
         ''   If bscCodigoCliente.Selecciono Then
         ''      If Not String.IsNullOrWhiteSpace(bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
         ''         frmImprime.Destinatarios = bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
         ''      End If
         ''   ElseIf bscCliente.Selecciono Then
         ''      If Not String.IsNullOrWhiteSpace(bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
         ''         frmImprime.Destinatarios = bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
         ''      End If
         ''   End If
         ''End If
         ''frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub


   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub


   'Private Sub tsbImprimir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

   '   Try

   '      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

   '      Dim Filtros As String = String.Empty

   '      Dim dt As DataTable

   '      Me.Cursor = Cursors.WaitCursor

   '      If Me.cmbVendedor.SelectedIndex >= 0 Then
   '         Filtros = "Vendedor: " & Me.cmbVendedor.Text
   '      End If

   '      If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
   '         If Filtros.Length > 0 Then Filtros = Filtros & " - "
   '         Filtros = Filtros & "Zona G.: " & Me.cmbZonaGeografica.Text
   '      End If

   '      If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
   '         If Filtros.Length > 0 Then Filtros = Filtros & " - "
   '         Filtros = Filtros & "Cliente: " & Me.bscCodigoCliente.Text & " - " & Me.bscCliente.Text
   '      End If


   '      If Me.chbCategoria.Checked Then
   '         If Filtros.Length > 0 Then Filtros = Filtros & " - "
   '         Filtros = Filtros & "Categoría: " & Me.cmbCategoria.Text
   '      End If

   '      '0 Es TODOS
   '      If Me.cmbGrabanLibro.SelectedIndex > 0 Then
   '         If Filtros.Length > 0 Then Filtros = Filtros & " - "
   '         Filtros = Filtros & "Graban Libro: " & Me.cmbGrabanLibro.Text
   '      End If

   '      'If Filtros.Length > 0 Then Filtros = Filtros & " - "
   '      'If Me.optConSaldo.Checked Then
   '      '   Filtros = Filtros & "Comprobantes con Saldo Pend."
   '      'Else
   '      '   Filtros = Filtros & "Comprobantes con y sin Saldo Pend."
   '      'End If

   '      'If Filtros.Length > 0 Then Filtros = Filtros & " - "
   '      'If Me.optVencVencidos.Checked Then
   '      '   If Filtros.Length > 0 Then Filtros = Filtros & " - "
   '      '   Filtros = Filtros & "Comprobantes Vencidos"
   '      'End If

   '      If Me.chbProvincia.Checked Then
   '         If Filtros.Length > 0 Then Filtros = Filtros & " - "
   '         Filtros = Filtros & "Provincia: " & Me.cmbProvincia.Text
   '      End If

   '      dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

   '      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

   '      Dim frmImprime As VisorReportes
   '      'If Not Me.chbFecha.Checked Then
   '      '   If Me.cmbVendedor.SelectedIndex >= 0 Then
   '      '      frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientes.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True)
   '      '   Else
   '      '      frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientesPorVendedor.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True)
   '      '   End If
   '      'Else
   '      '   If Me.cmbVendedor.SelectedIndex >= 0 Then
   '      '      frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientesT.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True)
   '      '   Else
   '      '      frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientesPorVendedorT.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True)
   '      '   End If
   '      'End If

   '      frmImprime.Text = Me.Text
   '      frmImprime.WindowState = FormWindowState.Maximized
   '      frmImprime.Show()

   '      Me.Cursor = Cursors.Default

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

   '   End Try

   'End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged

      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If

         Me.cmbZonaGeografica.Focus()

      End If

   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCodigoCliente.Text = ""
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
         Else
            If Me.cmbTiposComprobantes.Items.Count > 0 Then
               Me.cmbTiposComprobantes.SelectedIndex = 0
            End If
         End If

         Me.cmbTiposComprobantes.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
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

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub



   Private Sub chbCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      Try
         Me.cmbGrupos.Enabled = Me.chbGrupo.Checked

         If Not Me.chbGrupo.Checked Then
            Me.cmbGrupos.SelectedIndex = -1
         Else
            If Me.cmbGrupos.Items.Count > 0 Then
               Me.cmbGrupos.SelectedIndex = 0
            End If
         End If

         Me.cmbGrupos.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged

      Me.cmbProvincia.Enabled = Me.chbProvincia.Checked

      If Not Me.chbProvincia.Checked Then
         Me.cmbProvincia.SelectedIndex = -1
      Else
         If Me.cmbProvincia.Items.Count > 0 Then
            Me.cmbProvincia.SelectedIndex = 0
         End If
         Me.cmbProvincia.Focus()
      End If

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region

#Region "Metodos"

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteCuota")
      Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteCuota", SummaryType.Sum, columnToSummarize1)
      summary1.DisplayFormat = "{0:N2}"
      summary1.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("SaldoCuota")
      Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("SaldoCuota", SummaryType.Sum, columnToSummarize2)
      summary2.DisplayFormat = "{0:N2}"
      summary2.Appearance.TextHAlign = HAlign.Right

      With Me.ugDetalle.DisplayLayout.Bands(0)
         summary2 = .Summaries.Add("Interes", SummaryType.Sum, .Columns("Interes"))
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right
      End With

      Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If

      Me.rbtVenActual.Checked = False

      Me.chbCliente.Checked = False

      Me.dtpDesde.Value = Date.Now

      Me.chbMuestraDeudaAnterior.Checked = True

      Me.chbZonaGeografica.Checked = False
      Me.chbCategoria.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      'Me.optConSaldo.Checked = True
      'Me.optVencTodos.Checked = True
      Me.chbGrupo.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.chbExcluirSaldosNegativos.Checked = False
      Me.chbExcluirAnticipos.Checked = False
      Me.chbExcluirPreComprobantes.Checked = False
      Me.chbProvincia.Checked = False
      Me.rbtCatActual.Checked = True
      Me.rbtVenActual.Checked = True
      Me.chbAgruparIdClienteCtaCte.Checked = False
      Me.chbMostrarDetalle.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False
      Me.chbGrupoCategoria.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdClienteHijo").Hidden = True
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("CodigoClienteHijo").Hidden = Not Me.chbAgruparIdClienteCtaCte.Checked
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreClienteHijo").Hidden = Not Me.chbAgruparIdClienteCtaCte.Checked

         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      'Se puede resetear el control de Sucursal de dos formas
      '1.- Seleccionando el valor         - Si tenemos que llevarlo a un valor que no sea el default
      'cmbSucursal.SelectedValue = actual.Sucursal.IdSucursal
      '2.- Ejecutando el método Refrescar - Si tenemos que llevarlo al valor default
      cmbSucursal.Refrescar()

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim IdVendedor As Integer = 0

      Dim idCliente As Long = 0
      Dim idZonaGeografica As String = String.Empty
      Dim tipoComprobante As String = String.Empty
      Dim tipoSaldo As String = String.Empty
      Dim vencimiento As String = String.Empty
      Dim idCategoria As Integer = 0
      Dim grupo As String = String.Empty
      Dim excluirSaldosNegativos As String = "NO"
      Dim excluirAnticipos As String = "NO"
      Dim excluirPreComprobantes As String = "NO"
      Dim idProvincia As String = String.Empty
      Dim tipoCategoria As String = String.Empty
      Dim tipoVendedor As String = String.Empty
      Dim GrupoCategoria As String = String.Empty

      Dim total As Decimal = 0
      Dim excluirMinutas As String = "NO"

      Try

         '---------------------------------------------------------------------------------------------

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbZonaGeografica.Enabled Then
            idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         Dim desde As Date = Me.dtpDesde.Value

         Dim hasta As Date?
         If dtpHasta.Checked Then
            hasta = dtpHasta.Value
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            tipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.cmbCategoria.Enabled Then
            idCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.cmbGrupos.Enabled Then
            grupo = Me.cmbGrupos.SelectedValue.ToString()
         End If

         If Me.cmbGrupoCategoria.Enabled Then
            GrupoCategoria = Me.cmbGrupoCategoria.Text.ToString()
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            excluirSaldosNegativos = "SI"
         End If
         If Me.chbExcluirAnticipos.Checked Then
            excluirAnticipos = "SI"
         End If

         If Me.chbExcluirPreComprobantes.Checked Then
            excluirPreComprobantes = "SI"
         End If

         If Me.chbProvincia.Checked Then
            idProvincia = Me.cmbProvincia.SelectedValue.ToString()
         End If

         tipoSaldo = "SOLOSALDO"
         vencimiento = "TODOS"
         tipoCategoria = If(Me.rbtCatMovimiento.Checked, "MOVIMIENTO", "ACTUAL")
         tipoVendedor = If(Me.rbtVenMovimiento.Checked, "MOVIMIENTO", "ACTUAL")

         If Me.chbExcluirMinutas.Checked Then
            excluirMinutas = "SI"
         End If

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos()
         dtDetalle = oCtaCteDet.GetDetalleProximoPago(cmbSucursal.GetSucursales,
                                                      desde,
                                                      hasta,
                                                      IdVendedor,
                                                      idCliente,
                                                      tipoComprobante,
                                                      tipoSaldo,
                                                      vencimiento,
                                                      idZonaGeografica,
                                                      idCategoria,
                                                      Me.cmbGrabanLibro.Text,
                                                      grupo,
                                                      excluirSaldosNegativos,
                                                      excluirAnticipos,
                                                      excluirPreComprobantes,
                                                      idProvincia, tipoCategoria, tipoVendedor,
                                                      excluirMinutas,
                                                      Me.chbMuestraDeudaAnterior.Checked,
                                                      Me.chbAgruparIdClienteCtaCte.Checked,
                                                      GrupoCategoria)


         dt = Me.CrearDT()

         If dtDetalle.Rows.Count > 0 Then
            Dim MontoMinimoInteresPermitido As Decimal = Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido
            Dim IdCliente2 As Long = Long.Parse(dtDetalle.Rows(0)("IdCliente").ToString())

            For Each dr As DataRow In dtDetalle.Rows

               drCl = dt.NewRow()

               'If dr("TipoImpresora").ToString() = "NORMAL" Then
               '   drCl("Ver") = "..."
               'ElseIf dr("TipoImpresora").ToString() = "FISCAL" Then
               '   drCl("Ver") = "( F )"
               'ElseIf String.IsNullOrEmpty(dr("TipoImpresora").ToString()) Then
               '   drCl("Ver") = "CC"
               'End If
               drCl("Ver") = "..."

               'drCl("TipoImpresora") = dr("TipoImpresora").ToString()
               drCl("IdSucursal") = dr("IdSucursal")
               drCl("IdVendedor") = dr("IdVendedor").ToString()
               '  drCl("NroDocVendedor") = dr("NroDocVendedor").ToString()
               drCl("NombreVendedor") = dr("NombreVendedor").ToString()
               drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
               drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
               drCl("NombreCliente") = dr("NombreCliente").ToString()
               drCl("NombreCliente2") = dr("NombreCliente2").ToString()

               drCl("IdClienteHijo") = dr("IdClienteHijo")
               drCl("CodigoClienteHijo") = dr("CodigoClienteHijo")
               drCl("NombreClienteHijo") = dr("NombreClienteHijo")


               drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
               'drCl("DescripcionTipoComprobante") = dr("DescripcionTipoComprobante").ToString()
               drCl("Letra") = dr("Letra").ToString()
               drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
               drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
               drCl("CuotaNumero") = Integer.Parse(dr("CuotaNumero").ToString())
               drCl("Fecha") = Date.Parse(dr("Fecha").ToString())

               If Decimal.Parse(dr("SaldoCuota").ToString()) <> 0 Then   '' DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()).Date, Date.Today) > 0 And 
                  Dim diasFactura As Integer = Math.Max(CInt(DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()).Date, Date.Today)), 0)
                  drCl("DiasFactura") = diasFactura
               End If

               drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())

               'drCl("CantDias") = Integer.Parse(DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()), Date.Today).ToString()) + 1

               If Decimal.Parse(dr("SaldoCuota").ToString()) <> 0 Then  '' DateDiff(DateInterval.Day, Date.Parse(dr("FechaVencimiento").ToString()).Date, Date.Today) > 0 And 
                  Dim diasVencido As Integer = Math.Max(CInt(DateDiff(DateInterval.Day, Date.Parse(dr("FechaVencimiento").ToString()).Date, Date.Today)), 0)
                  drCl("DiasVencido") = diasVencido
               End If

               'drCl("DescripcionFormasPago") = dr("DescripcionFormasPago").ToString()
               drCl("ImporteCuota") = Decimal.Parse(dr("ImporteCuota").ToString())
               drCl("SaldoCuota") = Decimal.Parse(dr("SaldoCuota").ToString())

               If IdCliente2 <> Long.Parse(dr("IdCliente").ToString()) Then
                  total = 0
               End If

               If tipoSaldo = "TODOS" Then
                  If MontoMinimoInteresPermitido < Decimal.Parse(dr("Interes").ToString()) Then
                     total += Decimal.Parse(dr("ImporteCuota").ToString()) + Decimal.Parse(dr("Interes").ToString())
                     drCl("Interes") = dr("Interes")
                  Else
                     total += Decimal.Parse(dr("ImporteCuota").ToString())
                     drCl("Interes") = 0
                  End If
               Else
                  If MontoMinimoInteresPermitido < Decimal.Parse(dr("Interes").ToString()) Then
                     total += Decimal.Parse(dr("SaldoCuota").ToString()) + Decimal.Parse(dr("Interes").ToString())
                     drCl("Interes") = dr("Interes")
                  Else
                     total += Decimal.Parse(dr("SaldoCuota").ToString())
                     drCl("Interes") = 0
                  End If
               End If

               drCl("Total") = total

               drCl("Observacion") = dr("Observacion").ToString()
               drCl("NombreCategoria") = dr("NombreCategoria").ToString()

               'drCl("Interes") = dr("Interes")

               IdCliente2 = Long.Parse(dr("IdCliente").ToString())

               'Dim Productos As DataTable = New DataTable()
               'Dim oVP As Reglas.VentasProductos = New Reglas.VentasProductos()
               'Productos = oVP.GetNombresProductos(Integer.Parse(dr("IdSucursal").ToString()), dr("IdTipoComprobante").ToString(), dr("Letra").ToString(),
               '                              Short.Parse(dr("CentroEmisor").ToString()), Long.Parse(dr("NumeroComprobante").ToString()))
               'Dim ProductosDetalle As String = String.Empty
               'For Each dr2 As DataRow In Productos.Rows
               '   If Productos.Rows.Count = 1 Then
               '      ProductosDetalle = dr2("NombreProducto").ToString()
               '   Else
               '      ProductosDetalle += dr2("NombreProducto").ToString() & " / "
               '   End If

               'Next

               drCl("NombreProducto") = dr("NombreProductos").ToString()
               'drCl("NombreProducto") = ProductosDetalle
               dt.Rows.Add(drCl)

            Next
         End If

         'If TipoSaldo = "TODOS" Then
         '   Me.ugDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = True
         'Else
         '   Me.ugDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = False
         'End If

         Me.ugDetalle.DataSource = dt

         Me.tssRegistros.Text = dt.Rows.Count.ToString() & " Registros"

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdClienteHijo").Hidden = True
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("CodigoClienteHijo").Hidden = Not Me.chbAgruparIdClienteCtaCte.Checked
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreClienteHijo").Hidden = Not Me.chbAgruparIdClienteCtaCte.Checked
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreProducto").Hidden = Not Me.chbMostrarDetalle.Checked

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         '.Columns.Add("Ver", System.Type.GetType("System.String"))
         '.Columns.Add("TipoImpresora", System.Type.GetType("System.String"))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdVendedor", System.Type.GetType("System.Int32"))
         '.Columns.Add("NroDocVendedor", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreCliente2", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         '.Columns.Add("DescripcionTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("CuotaNumero", System.Type.GetType("System.Int32"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("DiasFactura", System.Type.GetType("System.Int32"))
         .Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("DiasVencido", System.Type.GetType("System.Int32"))
         '.Columns.Add("IdFormasPago", System.Type.GetType("System.Int32"))
         '.Columns.Add("DescripcionFormasPago", System.Type.GetType("System.String"))
         .Columns.Add("ImporteCuota", System.Type.GetType("System.Decimal"))
         .Columns.Add("SaldoCuota", System.Type.GetType("System.Decimal"))
         .Columns.Add("Total", System.Type.GetType("System.Decimal"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("Interes", GetType(Decimal))
         .Columns.Add("IdClienteHijo", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoClienteHijo", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreClienteHijo", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

   'Private Function optConSaldo() As Object
   '   Throw New NotImplementedException
   'End Function

   Private Sub chbGrupoCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupoCategoria.CheckedChanged
      Try
         Me.cmbGrupoCategoria.Enabled = Me.chbGrupoCategoria.Checked

         If Not Me.chbGrupoCategoria.Checked Then
            Me.cmbGrupoCategoria.SelectedIndex = -1
         Else
            If Me.cmbGrupoCategoria.Items.Count > 0 Then
               Me.cmbGrupoCategoria.SelectedIndex = 0
            End If
            Me.cmbGrupoCategoria.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class