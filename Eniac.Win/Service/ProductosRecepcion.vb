Option Explicit On
Option Strict On

Imports Eniac.Reglas
Imports Eniac.Service.Reglas
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section


Public Class ProductosRecepcion

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try

         Me._publicos = New Eniac.Win.Publicos()

         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

         Ayudante.Grilla.AgregarFiltroEnLinea(Me.ugDetalle, {"NombreProducto"})


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub ProductosRecepcionV_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.LimpiarCampos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbRecibir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRecibir.Click

      Try
         'If Me.ugDetalle.ActiveRow > 0 Then
         Dim nota As Eniac.Entidades.RecepcionNota = New Eniac.Entidades.RecepcionNota()
         Dim regE As Eniac.Reglas.RecepcionEstados = New Eniac.Reglas.RecepcionEstados()

         With nota
            'siempre obtengo el estado 10 (Devuelto), es el primer estado que va a tomar el producto
            .Estado = regE.GetUno(10)

            'cargo el producto
            .Producto = DirectCast(New Eniac.Reglas.Productos().GetUno(Me.ugDetalle.ActiveRow.Cells("IdProducto").Value.ToString()), Entidades.Producto)

            'cargo la venta
            .Venta = New Eniac.Reglas.Ventas().GetUna(actual.Sucursal.Id, Me.ugDetalle.ActiveRow.Cells("IdTipoComprobante").Value.ToString(), Me.ugDetalle.ActiveRow.Cells("Letra").Value.ToString(), Short.Parse(Me.ugDetalle.ActiveRow.Cells("CentroEmisor").Value.ToString()), Long.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroComprobante").Value.ToString()))

            'cargo la cantidad de productos que compro
            .CantidadProductos = Decimal.Parse(Me.ugDetalle.ActiveRow.Cells("Cantidad").Value.ToString())

            'cargo el cliente
            .Cliente = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
         End With

         Dim recNota As Eniac.Reglas.RecepcionNotas = New Eniac.Reglas.RecepcionNotas()

         If recNota.ExisteLaNota(nota.IdSucursal, nota.Venta.TipoComprobante.IdTipoComprobante, nota.Venta.CentroEmisor, nota.Venta.NumeroComprobante, nota.Venta.LetraComprobante, nota.Producto.IdProducto) Then
            If MessageBox.Show("Ya existe una nota para este articulo, desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               'abre el formulario de nota de recepcion enviandole la nota
               Dim frm As NotaRecepcion = New NotaRecepcion(nota)
               frm.ShowDialog()
            End If
         Else
            'abre el formulario de nota de recepcion enviandole la nota
            Dim frm As NotaRecepcion = New NotaRecepcion(nota)
            frm.ShowDialog()
         End If
         '   End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbRecibirSinComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRecibirSinComprobante.Click

      Try

         Dim nota As Eniac.Entidades.RecepcionNota = New Eniac.Entidades.RecepcionNota()
         Dim regE As Eniac.Reglas.RecepcionEstados = New Eniac.Reglas.RecepcionEstados()

         With nota
            'siempre obtengo el estado 10 (Devuelto), es el primer estado que va a tomar el producto
            .Estado = regE.GetUno(10)

            'NO cargo el producto
            '.Producto = 

            'NO cargo la venta
            '.Venta = 

            'cargo la cantidad de productos que compro
            .CantidadProductos = 1

            'cargo el cliente
            .Cliente = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
         End With

         'abre el formulario de nota de recepcion enviandole la nota
         Dim frm As NotaRecepcion = New NotaRecepcion(nota)
         frm.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If Me.Validar() Then
            Me.Cursor = Cursors.WaitCursor
            Me.tslRegistros.Text = "0 Registros"
            Me.tspBarra.Visible = True
            Me.Refresh()

            Dim oPro As Reglas.ProductosRecepcion = New Reglas.ProductosRecepcion()

            Me.ugDetalle.DataSource = oPro.GetProductosVendidos(actual.Sucursal.Id, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value)

            Me.tslRegistros.Text = Me.ugDetalle.Rows.Count.ToString() + " Registros"

            Me.ugDetalle.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.tspBarra.Visible = False
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Clientes = New Clientes
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
         Dim oClientes As Clientes = New Clientes
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

   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      Me.tsbRecibir.Enabled = True
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

   Private Sub LimpiarCampos()

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Enabled = True
      Me.bscCliente.Text = String.Empty
      Me.bscCliente.Enabled = True
      Me.txtDireccion.Text = String.Empty
      Me.txtLocalidad.Text = String.Empty
      Me.txtTelefono.Text = String.Empty
      Me.dtpFechaDesde.Value = Date.Now
      Me.dtpFechaHasta.Value = Date.Now

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.tsbRecibir.Enabled = False
      Me.tsbRecibirSinComprobante.Enabled = False

      Me.bscCodigoCliente.Focus()
   End Sub

   Private Function Validar() As Boolean
      If Not (Me.bscCliente.Selecciono Or Me.bscCodigoCliente.Selecciono) Then
         MessageBox.Show("Debe seleccionar un cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If
      Return True
   End Function

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.txtDireccion.Text = dr.Cells("Direccion").Value.ToString()

      Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtTelefono.Text = dr.Cells("Telefono").Value.ToString()
      Me.txtCategoria.Text = dr.Cells("NombreCategoria").Value.ToString()

      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      Me.tsbRecibirSinComprobante.Enabled = True

      Me.btnConsultar.Focus()
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpFechaDesde.Text, dtpFechaHasta.Text)

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function


#End Region


End Class