Option Explicit On
Option Strict On

Imports System
Imports Eniac.Service.Reglas
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section


Public Class AdministracionNotasRecepcion

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me.CargaComboEstados()

         Me._publicos = New Eniac.Win.Publicos()

         Ayudante.Grilla.AgregarFiltroEnLinea(Me.ugDetalle, {"NombreProducto", "NombreCliente", "NombreProductoPrestado", "NombreProveedor", "DefectoProducto", "Observacion", "ObservacionPrestamo"})

         Me.CargarValoresIniciales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub AdministracionNotasRecepcionV_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tslRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbEditarNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditarNota.Click

      Try



         Dim nota As Eniac.Entidades.RecepcionNota = New Eniac.Entidades.RecepcionNota()
         Dim rNotas As Eniac.Reglas.RecepcionNotas = New Eniac.Reglas.RecepcionNotas()

         nota = rNotas.GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NroNota").Value.ToString()))

         'Quien lo esta modificando ahora.
         nota.Usuario = actual.Nombre

         'abre el formulario de nota de recepcion enviandole la nota
         Dim frm As NotaRecepcion = New NotaRecepcion(nota)

         frm.StateForm = Eniac.Win.StateForm.Actualizar
         frm.ShowDialog()

         Me.btnConsultar.PerformClick()



      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbImprimirNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirNota.Click

      Try

         Dim nota As Eniac.Entidades.RecepcionNota = New Eniac.Entidades.RecepcionNota()
         nota = New Eniac.Reglas.RecepcionNotas().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NroNota").Value.ToString()))
         Dim IdEstado As Integer = Integer.Parse(Me.ugDetalle.ActiveRow.Cells("IdEstado").Value.ToString())
         Dim Estado As Entidades.RecepcionEstado = New Reglas.RecepcionEstados().GetUno(IdEstado)
         nota.Estado = Estado
         Me.ImprimirNotaRecepcion(nota)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If

   End Sub

   Private Sub bscNroDoc_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Dim codigoCliente As Long = -1
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Dim idEstado As Integer = 0
         Dim fec1 As DateTime = Nothing
         Dim fec2 As DateTime = Nothing
         Dim IdCliente As Long = 0

         Dim prodRec As Eniac.Reglas.ProductosRecepcion = New Eniac.Reglas.ProductosRecepcion()

         idEstado = Int32.Parse(Me.cmbEstado.SelectedValue.ToString())

         If Me.dtpFechaEnvioDesde.Checked Then
            fec1 = Me.dtpFechaEnvioDesde.Value
         End If
         If Me.dtpFechaEnvioHasta.Checked Then
            fec2 = Me.dtpFechaEnvioHasta.Value
         End If

         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Me.ugDetalle.DataSource = prodRec.GetProductosEnReparacion(actual.Sucursal.Id, idEstado, fec1, fec2, IdCliente)

         Me.tslRegistros.Text = Me.ugDetalle.Rows.Count.ToString() + " Registros"

         Me.ugDetalle.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      Me.tsbEditarNota.Enabled = True
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = Me.CargarFiltrosImpresion
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

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

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
               Me.UltraGridExcelExporter1.Export(ugDetalle, myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If

         'Me.sfdExportar.FileName = Me.Name & ".xls"
         'Me.sfdExportar.Filter = "Archivos excel|*.xls"
         'If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '   If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
         '      Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
         '   End If
         'End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim r As New Report()
               Dim sec As ISection = r.AddSection()
               sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
               sec.AddText.AddContent(Me.Text + System.Environment.NewLine)
               sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If

         'Me.sfdExportar.FileName = Me.Name & ".pdf"
         'Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         'If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '   If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
         '      Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
         '   End If
         'End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs)
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub


#End Region

#Region "Metodos"

   Private Sub CargaComboEstados()
      Dim oEstado As Eniac.Reglas.RecepcionEstados = New Eniac.Reglas.RecepcionEstados()

      With Me.cmbEstado
         .DisplayMember = "NombreEstado"
         .ValueMember = "IdEstado"
         .DataSource = oEstado.GetTodos()
      End With
   End Sub

   Private Sub CargarValoresIniciales()

      Me.cmbEstado.SelectedValue = 10

      Me.dtpFechaEnvioDesde.Value = Date.Now
      Me.dtpFechaEnvioDesde.Checked = False

      Me.dtpFechaEnvioHasta.Value = Date.Now
      Me.dtpFechaEnvioHasta.Checked = False

      Me.chbCliente.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      Me.btnConsultar.Focus()
   End Sub

   Private Sub ImprimirNotaRecepcion(ByVal Nota As Eniac.Entidades.RecepcionNota)

      Me.Cursor = Cursors.WaitCursor

      Try
         Dim oImprimir As ImpresionNota = New ImpresionNota(Nota)
         oImprimir.ImprimirNotaRecepcion()

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

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpFechaEnvioDesde.Text, dtpFechaEnvioHasta.Text)

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

#End Region

End Class