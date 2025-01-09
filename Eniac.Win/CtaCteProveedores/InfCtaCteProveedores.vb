#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
#End Region
Public Class InfCtaCteProveedores

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre
   Private _mailProveedor As String = String.Empty

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboCategoriasProveedores(Me.cmbCategoria)

         Me._publicos.CargaComboTiposComprobantesCtaCteProveedores(Me.cmbTiposComprobantes)
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreProveedor", "Observacion"}, {"Ver"})

         Me.CargarColumnasASumar()

         Me.LeerPreferencias()

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         If Not Publicos.TieneModuloContabilidad Then
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdPlanCuenta").Hidden = True
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdAsiento").Hidden = True
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ugDetalle_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      If e.Cell.Row.Index <> -1 Then
         If e.Cell.Column.Index = 0 Then
            Try
               Me.Cursor = Cursors.WaitCursor

               Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
               oTipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString())

               If oTipoComprobante.EsRecibo = True Then

                  'If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString() = "PAGO" Or _
                  '   Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString() = "PAGOPROV" Then
                  Dim reg As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
                  Dim ctacte As Entidades.CuentaCorrienteProv = reg.GetUna(actual.Sucursal.Id, _
                                 Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdProveedor").Value.ToString()), _
                                Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                                Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                                Int32.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                                Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))
                  Dim imp As PagosImprimir = New PagosImprimir()
                  imp.ImprimirPago(ctacte, True)
               Else
                  Dim oCompras As Reglas.Compras = New Reglas.Compras()
                  Dim Compra As Entidades.Compra = oCompras.GetUna(actual.Sucursal.Id, _
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()), _
                              Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdProveedor").Value.ToString()))

                  Dim oImpr As ImpresionCompra = New ImpresionCompra(Compra)

                  oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)
               End If
            Catch ex As Exception
               MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
               Me.Cursor = Cursors.Default
            End Try
         End If
      End If
   End Sub

   Private Sub InfCtaCteProveedores_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion

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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
     Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
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
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.chbProveedor.Checked Then
            filtro.AppendFormat(" - Proveedor: {0} - {1}", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If

         If Me.chbFecha.Checked Then
            filtro.AppendFormat(" - Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         End If

         If Me.chbCategoria.Checked Then
            filtro.AppendFormat(" - Categoria: {0}", Me.cmbCategoria.Text)
         End If

         If Me.cmbGrabanLibro.SelectedIndex > -1 Then
            filtro.AppendFormat(" - Graba Libro: {0}", Me.cmbGrabanLibro.Text)
         End If

         If Me.chbTipoComprobante.Checked Then
            filtro.AppendFormat(" - Tipo de Comprobante: {0}", Me.cmbTiposComprobantes.Text)
         End If

         If Me.optConSaldo.Checked Then
            filtro.AppendFormat(" - Saldo: {0}", Me.optConSaldo.Text)
         End If
         If Me.optTodos.Checked Then
            filtro.AppendFormat(" - Saldo: {0}", Me.optTodos.Text)
         End If
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbImprimirPrediseñado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirPrediseñado.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", CargarFiltrosImpresion()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("OcultarSaldo", Me.chbFecha.Checked.ToString()))

         Dim frmImprime As VisorReportes

         If Me.bscCodigoProveedor.Text.Length > 0 And Me.bscProveedor.Text.Length > 0 Then
            frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteProveedores.rdlc", "SistemaDataSet_CuentasCorrientesProv", dt, parm, True, 1) '# 1 = Cantidad Copias
         Else
            frmImprime = New VisorReportes("Eniac.Win.ConsultarCtaCteProveedoresPorProveedor.rdlc", "SistemaDataSet_CuentasCorrientesProv", dt, parm, True, 1) '# 1 = Cantidad Copias
         End If

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         If Me.chbProveedor.Checked Then
            If Not String.IsNullOrEmpty(Me._mailProveedor) Then
               frmImprime.Destinatarios = Me._mailProveedor
            End If
         End If
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub


   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged
      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      If Not Me.chbProveedor.Checked Then
         Me.bscCodigoProveedor.Tag = Nothing
         Me.bscCodigoProveedor.Text = ""
         Me.bscProveedor.Text = ""
      Else
         Me.bscCodigoProveedor.Focus()
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

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chkFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged

      Me.dtpDesde.Enabled = Me.chbFecha.Checked
      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If Me.chbFecha.Checked Then
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now
      End If

      Me.dtpDesde.Focus()

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

         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Proveedor, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
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

#End Region

#Region "Metodos"

   Private Sub CargarColumnasASumar()
      Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"ImporteTotal", "Saldo"})
   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
   End Sub


   Private Sub RefrescarDatosGrilla()

      Me.chbProveedor.Checked = False
      Me.chbFecha.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now
      Me.chbCategoria.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.optConSaldo.Checked = True

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCtaCteProv As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()

      Dim decTotal As Decimal = 0
      Dim decSaldo As Decimal = 0
      Dim decSaldoProveedor As Decimal = 0

      Dim idProveedor As Long = 0

      Dim Desde As Date = Nothing
      Dim Hasta As Date = Nothing

      Dim IdTipoComprobante As String = String.Empty

      Dim TipoSaldo As String = String.Empty

      Dim IdCategoria As Integer = 0

      Try

         If Me.bscCodigoProveedor.Tag IsNot Nothing Then
            idProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         If Me.chbFecha.Checked Then
            Desde = Me.dtpDesde.Value
            Hasta = Me.dtpHasta.Value
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         TipoSaldo = IIf(Me.optTodos.Checked, "TODOS", "SOLOSALDO").ToString()

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oCtaCteProv.GetDetalle(actual.Sucursal.Id, _
                                            Desde, Hasta, _
                                            idProveedor, _
                                            IdTipoComprobante, _
                                            TipoSaldo, _
                                            IdCategoria, _
                                            Me.cmbGrabanLibro.Text)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            If Long.Parse(dr("IdProveedor").ToString()) <> idProveedor Then
               idProveedor = Long.Parse(dr("IdProveedor").ToString())
               decSaldoProveedor = 0
            End If

            drCl("Ver") = "..."
            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("IdProveedor") = Long.Parse(dr("IdProveedor").ToString())
            drCl("CodigoProveedor") = Long.Parse(dr("CodigoProveedor").ToString())
            drCl("NombreProveedor") = dr("NombreProveedor").ToString()
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())

            drCl("RefProveedor") = dr("RefProveedor").ToString()

            drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

            If Not Me.chbFecha.Checked Then
               drCl("Saldo") = Decimal.Parse(dr("Saldo").ToString())
               decSaldo = decSaldo + Decimal.Parse(dr("Saldo").ToString())

               Ayudante.Grilla.QuitarTotalSumaColumna(ugDetalle, "Saldo")
               Ayudante.Grilla.AgregarTotalSumaColumna(ugDetalle, "Saldo") '.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            Else
               decSaldoProveedor += Decimal.Parse(dr("ImporteTotal").ToString())
               drCl("Saldo") = decSaldoProveedor
               decSaldo += Decimal.Parse(dr("ImporteTotal").ToString())

               Ayudante.Grilla.QuitarTotalSumaColumna(ugDetalle, "Saldo")
               If chbProveedor.Checked Then
                  Ayudante.Grilla.AgregarTotalCustomColumna(ugDetalle, "Saldo", New Ayudante.CustomSummaries.SummaryUltimoValorColumna(dt, "Saldo")) _
                                 .SummaryDisplayArea = SummaryDisplayAreas.RootRowsFootersOnly Or SummaryDisplayAreas.BottomFixed
               End If
            End If

            drCl("Observacion") = dr("Observacion").ToString()

            dt.Rows.Add(drCl)

            decTotal += Decimal.Parse(dr("ImporteTotal").ToString())

            drCl("IdPlanCuenta") = dr("IdPlanCuenta")
            drCl("IdAsiento") = dr("IdAsiento")

            drCl(Entidades.CuentaCorrienteProv.Columnas.MetodoGrabacion.ToString()) = dr(Entidades.CuentaCorrienteProv.Columnas.MetodoGrabacion.ToString())
            drCl(Entidades.CuentaCorrienteProv.Columnas.IdFuncion.ToString()) = dr(Entidades.CuentaCorrienteProv.Columnas.IdFuncion.ToString())
            drCl(Entidades.Proveedor.Columnas.TelefonoProveedor.ToString()) = dr(Entidades.Proveedor.Columnas.TelefonoProveedor.ToString())

         Next


         Me.ugDetalle.DataSource = dt

         If Me.ugDetalle.Rows.Count = 1 Then
            Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registro"
         Else
            Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdProveedor", GetType(Long))
         .Columns.Add("CodigoProveedor", GetType(Long))
         .Columns.Add("NombreProveedor", GetType(String))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("Fecha", GetType(DateTime))
         .Columns.Add("FechaVencimiento", GetType(DateTime))

         .Columns.Add("RefProveedor", GetType(String))

         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("Saldo", GetType(Decimal))
         .Columns.Add("Observacion", GetType(String))

         .Columns.Add("IdPlanCuenta", GetType(Integer))
         .Columns.Add("IdAsiento", GetType(Integer))

         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.MetodoGrabacion.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.IdFuncion.ToString(), GetType(String))
         .Columns.Add(Entidades.Proveedor.Columnas.TelefonoProveedor.ToString(), GetType(String))
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

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

   End Sub
#End Region
End Class