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


Public Class ProductosEnReparacion

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

   Private Sub ProductosEnReparacionV_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

   Private Sub tsbCambiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCambiarEstado.Click
      Try

         Dim nota As Eniac.Entidades.RecepcionNotaEstado = New Eniac.Entidades.RecepcionNotaEstado()
         Dim regE As Eniac.Reglas.RecepcionEstados = New Eniac.Reglas.RecepcionEstados()

         With nota
            .FechaEstado = Now
            .Estado = regE.GetUno(Int32.Parse(Me.ugDetalle.ActiveRow.Cells("IdEstado").Value.ToString()))
            .Nota = New Eniac.Reglas.RecepcionNotas().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NroNota").Value.ToString()))
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
         End With

         Using frm As CambiarEstadoProductos = New CambiarEstadoProductos(nota)
            frm.ShowDialog()
         End Using

         Me.btnConsultar.PerformClick()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbEnviarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEnviarProducto.Click
      Try

         If Me.ugDetalle.ActiveRow Is Nothing Then
            Exit Sub
         End If

         Dim nota As Eniac.Entidades.RecepcionNotaProveedor = New Eniac.Entidades.RecepcionNotaProveedor()
         Dim prov As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores()

         With nota
            .IdSucursal = actual.Sucursal.Id
            .Nota = New Eniac.Reglas.RecepcionNotas().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NroNota").Value.ToString()))
            .FechaEntrega = Now
            .Usuario = actual.Nombre
         End With

         Dim frm As EnviarProducto = New EnviarProducto(nota)
         frm.ShowDialog()

         Me.btnConsultar.PerformClick()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPrestarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrestarProducto.Click
      Try

         If Me.ugDetalle.ActiveRow.Cells("IdProductoPrestado").Value.ToString() <> "" Then
            If MessageBox.Show("Usted ya presto un producto para esta nota, desea cambiarlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
               Exit Sub
            End If
         End If

         Dim nota As Eniac.Entidades.RecepcionNota = New Eniac.Entidades.RecepcionNota()
         Dim regE As Eniac.Reglas.RecepcionEstados = New Eniac.Reglas.RecepcionEstados()

         nota = New Eniac.Reglas.RecepcionNotas().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NroNota").Value.ToString()))
         nota.Modo = Entidades.Modos.PrestarProducto
         nota.Usuario = actual.Nombre

         Dim frm As PrestarProducto = New PrestarProducto(nota)
         frm.ShowDialog()

         Me.btnConsultar.PerformClick()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbDevolucionProductoPrestado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDevolucionProductoPrestado.Click
      Try

         Dim nota As Eniac.Entidades.RecepcionNota = New Eniac.Entidades.RecepcionNota()
         Dim regE As Eniac.Reglas.RecepcionEstados = New Eniac.Reglas.RecepcionEstados()

         nota = New Eniac.Reglas.RecepcionNotas().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NroNota").Value.ToString()))
         nota.Modo = Entidades.Modos.DevolverProducto
         nota.Usuario = actual.Nombre

         Dim frm As PrestarProducto = New PrestarProducto(nota)
         frm.Text = "Devolución de producto prestado"
         frm.ShowDialog()

         Me.btnConsultar.PerformClick()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimirHistorialNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirHistorialNota.Click



      Try
         Dim nota As Eniac.Entidades.RecepcionNota = New Eniac.Entidades.RecepcionNota()

         nota = New Eniac.Reglas.RecepcionNotas().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NroNota").Value.ToString()))

         Dim dt As DataTable

         dt = New Eniac.Reglas.RecepcionNotasEstados().GetUna(nota.IdSucursal, nota.NroNota)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", nota.Cliente.NombreCliente))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", nota.Cliente.CodigoCliente.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", nota.Cliente.Direccion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", nota.Cliente.IdLocalidad.ToString())) 'Poner Nombre
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", nota.Cliente.Telefono & " " & nota.Cliente.Celular))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Email", nota.Cliente.CorreoElectronico))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroNota", nota.NroNota.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", nota.FechaNota.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CodigoProducto", nota.Producto.IdProducto))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreProducto", nota.Producto.NombreProducto))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cantidad", nota.CantidadProductos.ToString()))
         If nota.Venta.TipoComprobante IsNot Nothing Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprobante", nota.Venta.Fecha.ToString("dd/MM/yyyy") & " - " & nota.Venta.TipoComprobanteDescripcion & " '" & nota.Venta.LetraComprobante & "' " & nota.Venta.CentroEmisor.ToString("0000") & "-" & nota.Venta.NumeroComprobante.ToString("00000000")))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprobante", "SIN FACTURA RELACIONADA"))
         End If
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Costo", nota.CostoReparacion.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Defecto", nota.DefectoProducto))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Observacion", nota.Observacion))

         Dim frmImprime As VisorReportes
         frmImprime = New VisorReportes("Eniac.Win.NotaRecepcionHistorial.rdlc", "SistemaDataSet_RecepcionNotasHistorial", dt, parm, 1) '# 1 = Cantidad de Copias
         frmImprime.Text = "Historial Nota Recepción"
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub cmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado.SelectedIndexChanged
      Try
         If Me.ugDetalle.DataSource IsNot Nothing Then
            DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
         End If
         Me.tsbEnviarProducto.Enabled = Me.HabilitaEnviarProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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

         Dim Estado As Entidades.RecepcionEstado
         'For Each dr As UltraGridRow In Me.ugDetalle.Rows
         '   Estado = New Reglas.RecepcionEstados().GetUno(Integer.Parse(dr.Cells("IdEstado").Value.ToString()))
         '   If Estado.NombreEstado = "Entregado" Then
         '      dr.Cells("Remito").Style = ColumnStyle.Button
         '   End If
         'Next

         Me.tslRegistros.Text = Me.ugDetalle.Rows.Count.ToString() + " Registros"

         Me.ugDetalle.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvDetalle_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try

         'habilita o deshabilita el prestar y devolver si tiene o no un producto prestado

         'Al preguntar por el Estado no necesito borrar el producto que se presto. Reveer esta funcionalidad en base a comentarios.
         'If Me.dgvDetalle.SelectedRows(0).Cells("IdProductoPrestado").Value.ToString() <> "" Then
         If Me.ugDetalle.ActiveRow.Cells("EstaPrestado").Value.ToString() <> "" AndAlso Boolean.Parse(Me.ugDetalle.ActiveRow.Cells("EstaPrestado").Value.ToString()) Then
            Me.tsbPrestarProducto.Enabled = False
            Me.tsbDevolucionProductoPrestado.Enabled = True
         Else
            Me.tsbPrestarProducto.Enabled = True
            Me.tsbDevolucionProductoPrestado.Enabled = False
         End If
         'solo habilita el enviar producto si el estado es "Devuelto"
         If Me.ugDetalle.ActiveRow.Cells("IdEstado").Value.ToString() <> "10" Then
            Me.tsbEnviarProducto.Enabled = False
         Else
            Me.tsbEnviarProducto.Enabled = True
         End If
         Me.tsbImprimirHistorialNota.Enabled = True
         Me.tsbCambiarEstado.Enabled = True
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      Try

         'habilita o deshabilita el prestar y devolver si tiene o no un producto prestado

         'Al preguntar por el Estado no necesito borrar el producto que se presto. Reveer esta funcionalidad en base a comentarios.
         'If Me.dgvDetalle.SelectedRows(0).Cells("IdProductoPrestado").Value.ToString() <> "" Then
         If Me.ugDetalle.ActiveRow.Cells("EstaPrestado").Value.ToString() <> "" AndAlso Boolean.Parse(Me.ugDetalle.ActiveRow.Cells("EstaPrestado").Value.ToString()) Then
            Me.tsbPrestarProducto.Enabled = False
            Me.tsbDevolucionProductoPrestado.Enabled = True
         Else
            Me.tsbPrestarProducto.Enabled = True
            Me.tsbDevolucionProductoPrestado.Enabled = False
         End If
         'solo habilita el enviar producto si el estado es "Devuelto"
         If Me.ugDetalle.ActiveRow.Cells("IdEstado").Value.ToString() <> "10" Then
            Me.tsbEnviarProducto.Enabled = False
         Else
            Me.tsbEnviarProducto.Enabled = True
         End If
         Me.tsbImprimirHistorialNota.Enabled = True
         Me.tsbCambiarEstado.Enabled = True
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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
      Me.tsbImprimirHistorialNota.Enabled = False
      Me.tsbDevolucionProductoPrestado.Enabled = False
      Me.tsbPrestarProducto.Enabled = False
      Me.tsbCambiarEstado.Enabled = False

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

   Private Function HabilitaEnviarProducto() As Boolean
      'valida que en el combo de estado diga Devuelto, para habilitar el boton
      If Int32.Parse(Me.cmbEstado.SelectedValue.ToString()) <> 10 Then
         Return False
      End If
      Return True
   End Function

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

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         If Me.ugDetalle.ActiveRow Is Nothing Then
            Exit Sub
         End If
         '----------
         Me.Cursor = Cursors.WaitCursor
         Dim fr As FacturacionV2 = New FacturacionV2(Long.Parse(Me.ugDetalle.ActiveRow.Cells("IdCliente").Value.ToString()), "REMITO", Me.ugDetalle.ActiveRow.Cells("IdProducto").Value.ToString().Trim())
         fr.ConsultarAutomaticamente = True
         fr.MdiParent = Me.MdiParent
         fr.Show()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

End Class