Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

Public Class ConsultarLotesDeProductos

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         'Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         'If Not Publicos.ProductoTieneSubRubro Then
         '   Me.chbSubRubro.Visible = False
         '   Me.cmbSubRubro.Visible = False
         'End If

         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         Me.CargarSucursales()

         _publicos.CargaComboDesdeEnum(cmbTipoDeposito, Entidades.SucursalDeposito.TiposDepositos.OPERATIVO)
         cmbDepositos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, {})


         AgregarFiltroEnLinea(Me.dgvDetalle, {"IdProducto", "NombreProducto", "IdLote"})

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultaLotes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub


   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = Me.CargarFiltrosImpresion()

            Dim Titulo As String

            Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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
            Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
            Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

            UltraPrintPreviewD.MdiParent = Me.MdiParent
            UltraPrintPreviewD.Show()
            UltraPrintPreviewD.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged

        Me.cmbMarca.Enabled = Me.chbMarca.Checked

        If Not Me.chbMarca.Checked Then
            Me.cmbMarca.SelectedIndex = -1
        Else
            If Me.cmbMarca.Items.Count > 0 Then
                Me.cmbMarca.SelectedIndex = 0
            End If
            'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
            'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
            Me.chbProducto.Checked = False
        End If

        Me.cmbMarca.Focus()

    End Sub

    Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged

        Me.cmbRubro.Enabled = Me.chbRubro.Checked

        If Not Me.chbRubro.Checked Then
            Me.cmbRubro.SelectedIndex = -1
        Else
            If Me.cmbRubro.Items.Count > 0 Then
                Me.cmbRubro.SelectedIndex = 0
            End If
            'Si elijo una marca, limpio el producto seleccionado (hipotericamente)
            'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
            Me.chbProducto.Checked = False
        End If

        Me.cmbRubro.Focus()

    End Sub

    Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSubRubro.CheckedChanged
        Try
            Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

            If Not Me.chbSubRubro.Checked Then
                Me.cmbSubRubro.SelectedIndex = -1
            Else
                If Me.cmbSubRubro.Items.Count > 0 Then
                    Me.cmbSubRubro.SelectedIndex = 0
                End If
            End If

            Me.cmbSubRubro.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    'Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSubRubro.CheckedChanged
    '   Try
    '      Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

    '      If Not Me.chbSubRubro.Checked Then
    '         Me.cmbSubRubro.SelectedIndex = -1
    '      Else
    '         If Me.cmbSubRubro.Items.Count > 0 Then
    '            Me.cmbSubRubro.SelectedIndex = 0
    '         End If
    '      End If

    '      Me.cmbSubRubro.Focus()
    '   Catch ex As Exception
    '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '   End Try

    'End Sub

    Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged

        Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
        Me.bscProducto2.Enabled = Me.chbProducto.Checked

        'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
        If Not Me.chbProducto.Checked Then
            Me.bscCodigoProducto2.Text = String.Empty
            Me.bscProducto2.Text = String.Empty
        Else
            'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
            chbMarca.Checked = False
            chbRubro.Checked = False
        End If

        Me.bscCodigoProducto2.Focus()

    End Sub

    Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
            Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub chkFechaLote_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFechaLote.CheckedChanged

        Me.dtpDesde.Enabled = Me.chkFechaLote.Checked
        Me.dtpHasta.Enabled = Me.chkFechaLote.Checked

        If Me.chkFechaLote.Checked Then
            Me.dtpDesde.Value = Date.Now
            Me.dtpHasta.Value = Date.Now
        End If

        Me.dtpDesde.Focus()
    End Sub

    Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
        If chkExpandAll.Checked Then
            Me.dgvDetalle.Rows.ExpandAll(True)
        Else
            Me.dgvDetalle.Rows.CollapseAll(True)
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        Try

            If Me.chbMarca.Checked And Me.cmbMarca.SelectedIndex = -1 Then
                MessageBox.Show("ATENCION: NO seleccionó una Marca aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbMarca.Focus()
                Exit Sub
            End If

            If Me.chbRubro.Checked And Me.cmbRubro.SelectedIndex = -1 Then
                MessageBox.Show("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbRubro.Focus()
                Exit Sub
            End If

            If Me.chbProducto.Checked And Me.bscCodigoProducto2.Text.Length = 0 Then
                MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.bscCodigoProducto2.Focus()
                Exit Sub
            End If

            If Me.chbProducto.Checked Then
                'Actualiza el stock actual queda la pantalla levantada un tiempo y vuelve a "consultar"
                Me.bscCodigoProducto2.PresionarBoton()
            End If

            Me.Cursor = Cursors.WaitCursor

            Me.CargaGrillaDetalle()

            If dgvDetalle.Rows.Count > 0 Then
                Me.btnConsultar.Focus()
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
         myWorksheet.Rows(1).Cells(0).Value = Me.Text
         myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(dgvDetalle, myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
    End Sub

    Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim r As New Report()
               Dim sec As ISection = r.AddSection()
               sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
               sec.AddText.AddContent(Me.Text + System.Environment.NewLine)
               sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               Me.UltraGridDocumentExporter1.Export(Me.dgvDetalle, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

    End Sub

    Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
        Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
    End Sub
#End Region

#Region "Metodos"

    Private Sub CargarProducto(ByVal dr As DataGridViewRow)
        Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
        Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
        Me.bscProducto2.Enabled = False
        Me.bscCodigoProducto2.Enabled = False
    End Sub

    Private Sub RefrescarDatosGrilla()

        Me.chkFechaLote.Checked = False

        dtpDesde.Value = Date.Now
        dtpHasta.Value = Date.Now

        Me.chbProducto.Checked = False

        Me.chbMarca.Checked = False
        Me.chbRubro.Checked = False
        Me.optVencTodos.Checked = True
      'Me.chbSubRubro.Checked = False
      Me.chbConStock.Checked = True
      cmbDepositos.Refrescar()
      chbTipoDeposito.Checked = False

      If Not Me.dgvDetalle.DataSource Is Nothing Then
            DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
        End If

    End Sub

    Private Sub CargarSucursales()

      Dim lis As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(False)

        For Each suc As Entidades.Sucursal In lis

            Me.clbSucursales.Items.Add(suc)

            'Marco en forma predeterminada la Sucursal donde estoy parado. Ahorra trabajo, sobre todo si solo hay 1, tiene mas sentido.
            If suc.Id = actual.Sucursal.Id Then
                Me.clbSucursales.SetItemChecked(Me.clbSucursales.Items.Count - 1, True)
            End If

        Next

    End Sub

    Private Sub CargaGrillaDetalle()

      Dim Desde As Date = Nothing   'Me.dtpDesde.Value
        Dim Hasta As Date = Nothing

        Dim oStock As Reglas.Stock = New Reglas.Stock()

        Dim TipoMovimiento As String = String.Empty

        Dim sucursales(Me.clbSucursales.Items.Count) As Integer

        Dim IdMarca As Integer = 0
        Dim IdRubro As Integer = 0
        Dim IdSubRubro As Integer = 0
        Dim Producto As String = ""

        If Me.bscCodigoProducto2.Selecciono Or Me.bscProducto2.Selecciono Then
            Producto = Me.bscCodigoProducto2.Text
        End If
        If Me.bscCodigoProducto2.Selecciono Then
            Producto = Me.bscCodigoProducto2.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim()
        End If

        If Me.chbMarca.Checked Then
            IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
        End If

        If Me.chbRubro.Checked Then
            IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
        End If

        Dim con As Integer = 0
        For Each ite As Object In Me.clbSucursales.CheckedItems
            sucursales(con) = DirectCast(ite, Entidades.Sucursal).Id
            con += 1
        Next

        If Me.cmbSubRubro.Enabled Then
            IdSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
        End If

        If Me.chkFechaLote.Checked Then
            Desde = Me.dtpDesde.Value
            Hasta = Me.dtpHasta.Value
        End If

      Dim tipoOperacion = If(chbTipoDeposito.Checked, cmbTipoDeposito.ValorSeleccionado(Of Entidades.SucursalDeposito.TiposDepositos), DirectCast(Nothing, Entidades.SucursalDeposito.TiposDepositos?))

      Dim dtDetalle As DataTable

        Try

         dtDetalle = oStock.GetProductosLotes(sucursales,
                                                  Desde,
                                                  Hasta,
                                                  Me.optVencVencidos.Checked,
                                                  Producto,
                                                  IdMarca,
                                                  IdRubro,
                                                  IdSubRubro,
                                                  Me.chbConStock.Checked,
                                                  cmbDepositos.GetDepositos(todosVacio:=False),
                                                  chbStockUnificado.Checked, tipoOperacion)

         Me.dgvDetalle.DataSource = dtDetalle

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         If Me.bscCodigoProducto2.Text.Length > 0 And Me.bscProducto2.Text.Length > 0 Then
            .AppendFormat(" Producto: {0} - {1} - ", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If

         If Me.chbMarca.Checked Then
            .AppendFormat(" Marca: {0} -", Me.cmbMarca.SelectedValue.ToString())
         End If

         If Me.chbRubro.Checked Then
            .AppendFormat(" Rubro: {0} -", Me.cmbRubro.SelectedValue.ToString())
         End If

         If Me.chbSubRubro.Checked Then
            .AppendFormat(" SubRubro: {0} -", Me.cmbSubRubro.SelectedValue.ToString())
         End If

         .AppendFormat(" Con Stock: {0} -", IIf(chbConStock.Checked, "SI", "TODOS"))

         If Me.chkFechaLote.Checked Then
            .AppendFormat("Fecha Desde: {0} Hasta: {1} -", dtpDesde.ToString(), dtpHasta.ToString())
         End If

         .AppendFormat(" Vencimientos: {0}", IIf(optVencTodos.Checked, "TODOS", "VENCIDOS"))

      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub chbTipoDeposito_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoDeposito.CheckedChanged
      TryCatched(Sub() chbTipoDeposito.FiltroCheckedChanged(cmbTipoDeposito))
   End Sub

#End Region

End Class