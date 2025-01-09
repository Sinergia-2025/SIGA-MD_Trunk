Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfHistoricoConsultaProductos

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me._publicos.CargaComboMarcas(Me.cmbMarca)
      Me._publicos.CargaComboRubros(Me.cmbRubro)
      Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

      Me.Refrescar()

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfHistoricoDePrecios_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If Me.chbProducto.Checked Then
                Filtros = Filtros & " / Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text
            End If

            If Me.chbMarca.Checked Then
                Filtros = Filtros & " / Marca: " & Me.cmbMarca.Text
            End If

            If Me.chbRubro.Checked Then
                Filtros = Filtros & " / Rubro: " & Me.cmbRubro.Text
            End If

            If Me.cmbUsuario.Enabled Then
                Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.SelectedValue.ToString()
            End If

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

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

        Dim FechaTemp As Date

        Try

            If chkMesCompleto.Checked Then

                FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
                Me.dtpDesde.Value = FechaTemp

                'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
                FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
                dtpHasta.Value = FechaTemp

            End If

            Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
            Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

        Catch ex As Exception

            chkMesCompleto.Checked = False

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

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

    Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
        Me.cmbUsuario.Enabled = Me.chbUsuario.Checked
        If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
        Else
            Me.cmbUsuario.SelectedIndex = 0
        End If
        Me.cmbUsuario.Focus()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        Try

            If Me.chbMarca.Checked And Me.cmbMarca.SelectedIndex = -1 Then
                MessageBox.Show("ATENCION: NO seleccionó una Marca aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbMarca.Focus()
                Exit Sub
            End If

            If Me.chbRubro.Checked And Me.cmbRubro.SelectedIndex = -1 Then
                MessageBox.Show("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbRubro.Focus()
                Exit Sub
            End If

            If Me.chbProducto.Checked And Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
                MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.bscCodigoProducto2.Focus()
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
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

#End Region

#Region "Metodos"

    Private Sub Refrescar()

        Me._publicos.CargarSucursalesACheckListBox(Me.clbSucursales)

        Me.chkMesCompleto.Checked = False
        Me.dtpDesde.Value = DateTime.Today
        Me.dtpHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

        Me.chbProducto.Checked = False
        Me.chbMarca.Checked = False
        Me.chbRubro.Checked = False
        Me.chbProducto.Checked = False

        Me.chbUsuario.Checked = False

        Me.chkExpandAll.Checked = False
        Me.chkExpandAll.Enabled = False

        If Me.ugDetalle.Rows.Count > 0 Then
            DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
        End If

        Me.dtpDesde.Focus()

    End Sub

    Private Sub CargarProducto(ByVal dr As DataGridViewRow)

        Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
        Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
        Me.bscProducto2.Enabled = False
        Me.bscCodigoProducto2.Enabled = False

    End Sub

    Private Sub CargaGrillaDetalle()

        Dim reg As Reglas.HistorialConsultaProductos = New Reglas.HistorialConsultaProductos()

        Dim TotalNeto As Decimal = 0
        Dim TotalImpuestos As Decimal = 0
        Dim Total As Decimal = 0

        Dim idProducto As String = String.Empty
        Dim IdMarca As Integer = 0
        Dim IdRubro As Integer = 0
        Dim IdUsuario As String = String.Empty

        If Me.chbProducto.Checked Then
            idProducto = Me.bscCodigoProducto2.Text.Trim()
        End If

        If Me.chbMarca.Checked Then
            IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
        End If

        If Me.chbRubro.Checked Then
            IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
        End If

        If Me.chbUsuario.Checked Then
            'IdUsuario = DirectCast(Me.cmbUsuario.SelectedItem, Entidades.Usuario).Usuario
            IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
        End If

        Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

        Dim suc As List(Of Integer) = New List(Of Integer)
        For Each ite As Object In Me.clbSucursales.CheckedItems
            suc.Add(DirectCast(ite, Entidades.Sucursal).Id)
        Next

        dtDetalle = reg.GetHistorialConsultaProductos(suc.ToArray(), _
                                            Me.dtpDesde.Value, Me.dtpHasta.Value, _
                                            idProducto, _
                                            IdMarca, _
                                            IdRubro, _
                                            IdUsuario)

        dt = Me.CrearDT()

        For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("IdProducto") = dr("IdProducto").ToString()
            drCl("NombreProducto") = dr("NombreProducto").ToString()
            drCl("NombreMarca") = dr("NombreMarca").ToString()
            drCl("NombreRubro") = dr("NombreRubro").ToString()
            drCl("FechaHora") = Date.Parse(dr("FechaHora").ToString())
            drCl("Usuario") = dr("Usuario").ToString()

            dt.Rows.Add(drCl)

            'TotalImpuestos = TotalImpuestos + Decimal.Parse(drCl("ImporteImpuesto").ToString())
            'Total = Total + Decimal.Parse(drCl("ImporteTotalNeto").ToString())

            'TotalNeto = TotalNeto + (Decimal.Parse(drCl("ImporteTotalNeto").ToString()) - Decimal.Parse(drCl("ImporteImpuesto").ToString()))

        Next

        'txtSubtotal.Text = TotalNeto.ToString("#,##0.00")
        'txtImpuestos.Text = TotalImpuestos.ToString("#,##0.00")
        'txtTotal.Text = Total.ToString("#,##0.00")


        Me.ugDetalle.DataSource = dt

    End Sub

    Private Function CrearDT() As DataTable

        Dim dtTemp As DataTable = New DataTable()

        With dtTemp
            .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
            .Columns.Add("IdProducto", System.Type.GetType("System.String"))
            .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
            .Columns.Add("IdMarca", System.Type.GetType("System.Int32"))
            .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
            .Columns.Add("IdRubro", System.Type.GetType("System.Int32"))
            .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
            .Columns.Add("FechaHora", System.Type.GetType("System.DateTime"))
            .Columns.Add("Usuario", System.Type.GetType("System.String"))
        End With

        Return dtTemp

    End Function

#End Region

End Class