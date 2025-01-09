Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfCargos

#Region "Campos"

   Private _publicos As Publicos
   Private _expensas As DataTable
   Private _conceptos As DataTable
   Private _adicionales As DataTable
   Private _voucher As DataTable
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos
         Me._publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)
         Me.cmbTiposLiquidacion.SelectedIndex = 0
         Me._publicos.CargaComboDesdeEnum(Me.cmbLiquidado, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbLiquidado.SelectedValue = Entidades.Publicos.SiNoTodos.SI

         Me.FechaLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

         cmbTiposComprobantes.Initializar(False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         With Me.cboLetra
            .DisplayMember = "LetraFiscal"
            .ValueMember = "LetraFiscal"
            .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
            .SelectedIndex = -1
         End With

         With Me.cmbEmisor
            .DisplayMember = "CentroEmisor"
            .ValueMember = "CentroEmisor"
            .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
            .SelectedIndex = -1
         End With

         Me._publicos.CargaComboCategorias(Me.cmbCategorias)

         ugDetalle.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                         Entidades.Cliente.Columnas.NombreDeFantasia.ToString()})
         ugDetalle.AgregarTotalesSuma({Entidades.LiquidacionCargo.Columnas.ImporteTotal.ToString()})



         'Hay que colocarlo del CargarColumnasASumar porque sino da error.
         Me.LeerPreferencias()

         ''Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
         Me._estaCargando = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfCargos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Filtros = "Filtros: Rango de Periodos: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If Me.chbCliente.Checked Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscNombreCliente.Text.Trim()
         End If

         If Me.chbCategoria.Checked Then
            Filtros = Filtros & " / Categoria: " & Me.cmbCategorias.Text
         End If

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraGridPrintDocument1.Grid = Me.ugDetalle

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try

         Dim grid As UltraGrid = New UltraGrid()
         Dim Nombre As String = String.Empty

         grid = Me.ugDetalle

         Me.sfdExportar.FileName = Me.Name + Nombre & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"

         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.Cursor = Cursors.WaitCursor
               Me.UltraGridExcelExporter1.Export(grid, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try

         Dim grid As UltraGrid = New UltraGrid()
         Dim Nombre As String = String.Empty

         grid = Me.ugDetalle

         Me.sfdExportar.FileName = Me.Name + Nombre & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"

         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.Cursor = Cursors.WaitCursor
               Me.UltraGridDocumentExporter1.Export(grid, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbCategoria.CheckedChanged
      Me.cmbCategorias.Enabled = Me.chbCategoria.Checked

      If Me.chbCliente.Checked Then
         Me.cmbCategorias.Focus()
      Else
         Me.cmbCategorias.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscNombreCliente.Enabled = Me.chbCliente.Checked

      If Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Focus()
      Else
         Me.bscCodigoCliente.Text = String.Empty
         Me.bscNombreCliente.Text = String.Empty
      End If

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Dim entidad As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         'Me.bscCodigoCliente.Datos = entidad.GetFiltradoPorCodigo(Me.bscCodigoCliente.Text)
         Dim codigoCliente As Long = -1
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If

         Me.bscCodigoCliente.Datos = entidad.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      Try
         Dim entidad As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes(Me.bscNombreCliente)
         Me.bscNombreCliente.Datos = entidad.GetFiltradoPorNombre(Me.bscNombreCliente.Text, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscNombreCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCategoria.Checked And Me.cmbCategorias.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Categoría aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbCategorias.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscNombreCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un tipo de comprobante aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

   Private Sub ugdDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

      'e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      'e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      'e.Layout.Override.SpecialRowSeparatorHeight = 6

      'e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      'e.Layout.ViewStyle = ViewStyle.SingleBand

   End Sub

   Private Sub ugdDetalle_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs)

      'Try
      '   If e.Cell.Column.Index = 23 And e.Cell.Row.Index <> -1 Then
      '      Try
      '         'Imprimo expensas
      '         'Busco la expensa por el numero de comprobante

      '         Dim exp As DataTable
      '         Dim oexp As Reglas.Expensas = New Reglas.Expensas()
      '         exp = oexp.GetExpensas(Integer.Parse(Me.ugdDetalle.Rows(e.Cell.Row.Index).Cells("PeriodoLiquidacion").Value.ToString()), _
      '                                Integer.Parse(Me.ugdDetalle.Rows(e.Cell.Row.Index).Cells("IdInmueble").Value.ToString()), _
      '                                             Me.ugdDetalle.Rows(e.Cell.Row.Index).Cells("TipoDocPropietario").Value.ToString(), _
      '                                             Long.Parse(Me.ugdDetalle.Rows(e.Cell.Row.Index).Cells("NroDocPropietario").Value.ToString()))


      '         Dim adiexp As DataTable
      '         Dim voucherexp As DataTable

      '         Dim oadiexp As Reglas.ExpensasAdicionales = New Reglas.ExpensasAdicionales()
      '         adiexp = oadiexp.GetAdicionales(Integer.Parse(Me.ugdDetalle.Rows(e.Cell.Row.Index).Cells("PeriodoLiquidacion").Value.ToString()), _
      '                                Integer.Parse(Me.ugdDetalle.Rows(e.Cell.Row.Index).Cells("IdInmueble").Value.ToString()))

      '         voucherexp = oadiexp.GetAdicionalesVoucher(Integer.Parse(Me.ugdDetalle.Rows(e.Cell.Row.Index).Cells("PeriodoLiquidacion").Value.ToString()), _
      '                                Integer.Parse(Me.ugdDetalle.Rows(e.Cell.Row.Index).Cells("IdInmueble").Value.ToString()))

      '         Dim PeriodoLiquidacion1 As Integer
      '         PeriodoLiquidacion1 = Integer.Parse(Me.ugdDetalle.Rows(e.Cell.Row.Index).Cells("PeriodoLiquidacion").Value.ToString())

      '         Dim liq As DataTable
      '         Dim oliq As Reglas.MovimientosLiquidacion = New Reglas.MovimientosLiquidacion()

      '         liq = oliq.GetLiquidacion(PeriodoLiquidacion1)

      '         Dim dt As DataTable
      '         Dim dt1 As DataTable
      '         Dim dt2 As DataTable
      '         Dim dt3 As DataTable

      '         dt = DirectCast(exp, DataTable).Copy()
      '         dt.TableName = "SistemaDataSet_Expensas"

      '         dt1 = DirectCast(liq, DataTable).Copy()
      '         dt1.TableName = "SistemaDataSet_Conceptos"
      '         dt2 = DirectCast(adiexp, DataTable).Copy()
      '         dt2.TableName = "SistemaDataSet_Adicionales"
      '         dt3 = DirectCast(voucherexp, DataTable).Copy()
      '         dt3.TableName = "SistemaDataSet_Voucher"

      '         Dim pub As Publicos = New Publicos()
      '         'pub.ImprimirExpensa(dt, dt1, dt2, PeriodoLiquidacion.ToString().Substring(PeriodoLiquidacion.ToString().Length - 2) + "/" + PeriodoLiquidacion.ToString().Substring(0, 4))
      '         pub.ImprimirExpensa(dt, dt1, dt2, dt3, PeriodoLiquidacion1.ToString("MM/yyyy"))

      '      Catch ex As Exception
      '         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '      Finally
      '         Me.Cursor = Cursors.Default
      '      End Try

      '   End If
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
   '   Try
   ''      If TabControl1.SelectedTab Is Me.TabPage1 Then
   '         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
   ''      ElseIf TabControl1.SelectedTab Is Me.TabPage2 Then
   ''         Me.tssRegistros.Text = Me.ugClientes.Rows.Count.ToString() & " Registros"
   ''      ElseIf TabControl1.SelectedTab Is Me.TabPage3 Then
   ''         Me.tssRegistros.Text = Me.ugEmbarcaciones.Rows.Count.ToString() & " Registros"
   ''      End If
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

#End Region

#Region "Metodos"

   Private Sub FechaLiquidacion(ByVal IdTipoLiquidacion As Integer)

      Dim oliq As Reglas.Liquidaciones = New Reglas.Liquidaciones()
      Dim UltimaLiquidacion As Integer

      UltimaLiquidacion = oliq.GetUltimoPeriodoLiquidacion(IdTipoLiquidacion)

      Dim Fecha As Date
      If UltimaLiquidacion > 1 Then
         Fecha = Date.Parse(UltimaLiquidacion.ToString.Substring(0, 4) & "-" & UltimaLiquidacion.ToString.Substring(4, 2) & "-01")
      Else
         Fecha = Date.Now.AddMonths(-1)
      End If

      Me.dtpDesde.Value = Fecha
      Me.dtpHasta.Value = Fecha

   End Sub

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True

      If Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Count = 0 Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Total:"

      End If

   End Sub

   Private Sub CargarCliente(ByVal dr As DataGridViewRow)
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Enabled = False
      Me.bscNombreCliente.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.FechaLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

      Me.chbCategoria.Checked = False
      Me.chbCliente.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.chbTipoComprobante.Checked = False
      Me.chbNumero.Checked = False
      Me.chbLetra.Checked = False
      Me.chbEmisor.Checked = False
      Me.cmbLiquidado.SelectedValue = Entidades.Publicos.SiNoTodos.SI

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Me.ugDetalle.DisplayLayout.ClearGroupByColumns()

      'Dim clCargos As Reglas.Cargos = New Reglas.Cargos()
      Dim Liquidaciones As Reglas.Liquidaciones = New Reglas.Liquidaciones()
      Dim LiquidacionesCargos As Reglas.LiquidacionesCargos = New Reglas.LiquidacionesCargos()

      Dim periodoDesde As Integer
      Dim periodoHasta As Integer

      Dim nombreCategoria As String = ""
      Dim codigoCliente As Long = 0

      periodoDesde = Integer.Parse(Me.dtpDesde.Value.ToString("yyyyMM"))
      periodoHasta = Integer.Parse(Me.dtpHasta.Value.ToString("yyyyMM"))

      Dim Letra As String = ""
      Dim emisor As Integer = 0
      Dim NumeroComprobante As Long = 0

      If Me.chbCategoria.Checked Then
         nombreCategoria = Me.cmbCategorias.Text.ToString()
      End If

      If Me.chbCliente.Checked Then
         codigoCliente = Long.Parse(Me.bscCodigoCliente.Text)
      End If


      If Me.chbNumero.Checked Then
         NumeroComprobante = Long.Parse(Me.txtNumero.Text)
      End If

      If Me.cboLetra.Enabled Then
         Letra = Me.cboLetra.SelectedValue.ToString()
      End If

      If Me.cmbEmisor.Enabled Then
         emisor = Integer.Parse(Me.cmbEmisor.SelectedValue.ToString())
      End If

      Dim liquidado As Entidades.Publicos.SiNoTodos = DirectCast(Me.cmbLiquidado.SelectedValue, Entidades.Publicos.SiNoTodos)
      Dim tiposComprobantes As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)()
      tiposComprobantes.AddRange(cmbTiposComprobantes.GetTiposComprobantes())

      'Paso una lista de sucursales con la sucursal actual para tenerlo listo para cuando pidan filtrar por múltiples sucursales
      Me.ugDetalle.DataSource = LiquidacionesCargos.GetPorRangoFechas({actual.Sucursal},
                                                                      periodoDesde, periodoHasta, nombreCategoria,
                                                                      codigoCliente, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()),
                                                                      NumeroComprobante, Letra, emisor, tiposComprobantes, liquidado)

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Me.AjustarColumnasGrilla()

   End Sub


   Private Overloads Sub AjustarColumnasGrilla()

      Dim tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()

      tit.Add(Entidades.LiquidacionCargo.Columnas.Selecciono.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.PeriodoLiquidacion.ToString(), "")
      tit.Add(Entidades.Cliente.Columnas.CodigoCliente.ToString(), "")
      tit.Add(Entidades.Cliente.Columnas.NombreCliente.ToString(), "")
      tit.Add(Entidades.Cliente.Columnas.NombreDeFantasia.ToString(), "")
      tit.Add(Entidades.Categoria.Columnas.NombreCategoria.ToString(), "")
      tit.Add(Entidades.ZonaGeografica.Columnas.NombreZonaGeografica.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.ImporteTotal.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.IdTipoComprobante.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.Letra.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.CentroEmisor.ToString(), "")
      tit.Add(Entidades.LiquidacionCargo.Columnas.NumeroComprobante.ToString(), "")

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
         If Not tit.ContainsKey(col.Key) Then
            col.Hidden = True
         End If
      Next

   End Sub

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

   Private Sub cmbTiposLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposLiquidacion.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            Me.FechaLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            'Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
            '_listaTipoComprobante = New List(Of Entidades.TipoComprobante)()
         Else
            Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      Me.cboLetra.Enabled = Me.chbLetra.Checked
      If Not Me.chbLetra.Checked Then
         Me.cboLetra.SelectedIndex = -1
      Else
         If Me.cboLetra.Items.Count > 0 Then
            Me.cboLetra.SelectedIndex = 0
         End If
      End If
      Me.cboLetra.Focus()

   End Sub

   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      Me.cmbEmisor.Enabled = Me.chbEmisor.Checked
      If Not Me.chbEmisor.Checked Then
         Me.cmbEmisor.SelectedIndex = -1
      Else
         If Me.cmbEmisor.Items.Count > 0 Then
            Me.cmbEmisor.SelectedIndex = 0
         End If
      End If
      Me.cmbEmisor.Focus()

   End Sub

End Class