Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class SueldosInformeControl

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         'Me._publicos.CargaComboCategoriasSocios(Me.cboCategoria)

         Me._publicos.CargaComboSueldosTiposRecibos(Me.cmbTipoRecibo)
         'Me.tsbImprimir.Visible = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub SueldosInformeControl_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         'Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         Filtros = "" '"Vencimiento Hasta" & dtpHasta.Text

         If Me.bscIdLegajo.Text.Length > 0 And Me.bscNombrePersonal.Text.Length > 0 Then
            Filtros = Filtros & " - Legajo: " & Me.bscIdLegajo.Text & " - " & Me.bscNombrePersonal.Text
         End If

         Dim Titulo As String

         Titulo = Eniac.Win.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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

         'Dim vri As VisorReportesInfra = New VisorReportesInfra()
         'vri.Documento = Me.UltraGridPrintDocument1
         'vri.Name = Me.Text
         'vri.Show()

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

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         'If Me.cmbPeridoLiquidacion.SelectedIndex = -1 Then
         '   MessageBox.Show("No seleccionó el Periodo de Liquidación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbPeridoLiquidacion.Focus()
         '   Exit Sub
         'End If

         'If Me.chbSocio.Checked And Not Me.bscNroDoc.Selecciono And Not Me.bscSocio.Selecciono Then
         '   MessageBox.Show("ATENCION: Activo el filtro de Socio, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.bscNroDoc.Focus()
         '   Exit Sub
         'End If

         'If Me.chbCobrador.Checked And Me.cmbCobrador.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: Activo el filtro de Cobrador, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbCobrador.Focus()
         '   Exit Sub
         'End If

         'If Me.chbCategoria.Checked And Me.cboCategoria.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: Activo el filtro de Categoria, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cboCategoria.Focus()
         '   Exit Sub
         'End If

         Me.Cursor = Cursors.WaitCursor

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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   'Private Sub chbSocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

   '    'Me.cmbTipoDoc.Enabled = Me.chbSocio.Checked
   '    'Me.bscNroDoc.Enabled = Me.chbSocio.Checked
   '    'Me.bscSocio.Enabled = Me.chbSocio.Checked

   '    If Not Me.chbSocio.Checked Then
   '        '       Me.cmbTipoDoc.Text = Publicos.TipoDocumentoSocio()
   '        Me.bscNroDoc.Text = ""
   '        Me.bscSocio.Text = ""
   '    Else
   '        Me.bscNroDoc.Focus()
   '    End If

   'End Sub

   Private Sub bscNroDoc_BuscadorClick() Handles bscIdLegajo.BuscadorClick


      Dim NroDoc As Integer = -1

      Try
         Me._publicos.PreparaGrillaPersonal(Me.bscIdLegajo)
         Dim oLegajos As Reglas.SueldosPersonal = New Reglas.SueldosPersonal
         If Me.bscIdLegajo.Text.Trim.Length > 0 Then
            NroDoc = Integer.Parse(Me.bscIdLegajo.Text.Trim())
         End If
         ' Me.bscNroDoc.Datos = oSocios.GetUno(NroDoc)
         Me.bscIdLegajo.Datos = oLegajos.GetFiltradoPorLegajo(NroDoc)

         ' Me.bscNroDoc.Datos = oSocios.GetUno(NroDoc)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscIdLegajo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPersonal(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscSocio_BuscadorClick() Handles bscNombrePersonal.BuscadorClick
      Try
         Me._publicos.PreparaGrillaPersonal(Me.bscNombrePersonal)
         Dim oLegajos As Reglas.SueldosPersonal = New Reglas.SueldosPersonal

         Me.bscNombrePersonal.Datos = oLegajos.GetFiltradoPorNombre(Me.bscNombrePersonal.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscSocio_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombrePersonal.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPersonal(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.ckbLegajo.Checked = False
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargarDatosPersonal(ByVal dr As DataGridViewRow)

      Me.bscNombrePersonal.Text = dr.Cells("NombrePersonal").Value.ToString()
      Me.bscIdLegajo.Text = dr.Cells("idLegajo").Value.ToString()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCtaCteDet As New Reglas.SueldosLiquidacion


      Dim TipoDocSocio As String = String.Empty
      Dim NroDocSocio As Long = 0

      Dim Desde As Date = Nothing
      Dim Hasta As Date = Nothing

      Dim SoloActivos As String = String.Empty

      Try

         Dim Cobrador As String = ""
         Dim Tot_Haberes, Tot_SalarioFamiliar, Tot_Retenciones, Tot_Neto As Decimal

         Dim tiporecibo As Integer

         Dim TablaLeida As DataTable, LegajoSeleccionado As String
         LegajoSeleccionado = Me.bscIdLegajo.Text

         tiporecibo = Integer.Parse(cmbTipoRecibo.SelectedValue.ToString())

         Dim esAguinaldo As String = ""
         If radNormal.Checked Then
            esAguinaldo = "N"
         ElseIf radAguinaldo.Checked Then
            esAguinaldo = "S"
         End If

         TablaLeida = oCtaCteDet.GetInformeControl(LegajoSeleccionado, tiporecibo, esAguinaldo)

         Dim dt As New DataSetSueldos.InformeControlDataTable
         Dim drCl As DataSetSueldos.InformeControlRow = Nothing

         Dim TipoConceptoGU As Integer = -1
         Dim LegajoGU As Long = -1
         Dim Saldo As Decimal = 0
         Dim Sueldo_a_Cobrar As Decimal = 0
         Dim SaldoGeneral As Decimal = 0

         Dim Indice As Integer

         For Each dr As DataRow In TablaLeida.Rows

            If LegajoGU <> Long.Parse(dr("IdLegajo").ToString()) Then

               If LegajoGU <> -1 Then

                  drCl.Saldo = Saldo
                  dt.Rows.Add(drCl)
                  Saldo = 0

                  drCl = dt.NewInformeControlRow
                  drCl.NombreConcepto = "NETO A COBRAR:"
                  drCl.Saldo = Sueldo_a_Cobrar
                  dt.Rows.Add(drCl)

                  Sueldo_a_Cobrar = 0

                  drCl = dt.NewInformeControlRow
                  dt.Rows.Add(drCl)

               End If

               TipoConceptoGU = Integer.Parse(dr("IdTipoConcepto").ToString())
               LegajoGU = Long.Parse(dr("IdLegajo").ToString())

               Saldo = 0
               'Contador = 0

               drCl = dt.NewInformeControlRow
               drCl.NombrePersonal = dr("NombrePersonal").ToString()
               drCl.Legajo = dr("IdLegajo").ToString()

            Else

               If TipoConceptoGU <> Integer.Parse(dr("IdTipoConcepto").ToString()) Then

                  'If TipoConceptoGU <> -1 Then
                  '   drCl.Saldo = Saldo.ToString
                  'End If

                  drCl.Saldo = Saldo

                  'Select Case TipoConceptoGU
                  '   Case 1
                  '      Tot_Haberes += Saldo
                  '   Case 2
                  '      Tot_Retenciones += Saldo
                  '   Case 6
                  '      Tot_SalarioFamiliar += Saldo
                  '   Case Else
                  'End Select

                  'If TipoConceptoGU = 1 Or TipoConceptoGU = 4 Or TipoConceptoGU = 6 Or TipoConceptoGU = 7 Then
                  '   Indice = 1
                  'Else
                  '   Indice = -1
                  'End If

                  'Tot_Neto += Saldo * Indice

                  Saldo = 0
                  TipoConceptoGU = Integer.Parse(dr("IdTipoConcepto").ToString())
                  dt.Rows.Add(drCl)
               Else

                  dt.Rows.Add(drCl)

               End If

               drCl = dt.NewInformeControlRow
            End If

            drCl.idConcepto = dr("idConcepto").ToString()
            drCl.CodigoConcepto = dr("CodigoConcepto").ToString()
            drCl.NombreConcepto = dr("NombreConcepto").ToString()
            drCl.Valor = Decimal.Parse(dr("Valor").ToString())
            drCl.Importe = Decimal.Parse(dr("Importe").ToString())
            Saldo = Saldo + Decimal.Parse(dr("Importe").ToString())

                If TipoConceptoGU = 1 Or TipoConceptoGU = 4 Or TipoConceptoGU = 6 Or TipoConceptoGU = 7 Or TipoConceptoGU = 8 Then
                    Indice = 1
                Else
                    Indice = -1
                End If

            Sueldo_a_Cobrar = Sueldo_a_Cobrar + Decimal.Parse(dr("Importe").ToString()) * Indice


            Select Case Integer.Parse(dr("IdTipoConcepto").ToString())
               Case 1
                  Tot_Haberes += Decimal.Parse(dr("Importe").ToString())
               Case 2
                  Tot_Retenciones += Decimal.Parse(dr("Importe").ToString())
               Case 6
                  Tot_SalarioFamiliar += Decimal.Parse(dr("Importe").ToString())
               Case Else
            End Select

            Tot_Neto += Decimal.Parse(dr("Importe").ToString()) * Indice

         Next


         If LegajoGU <> -1 Then

            '-------------------------------------------------------------------------
            'Select Case TipoConceptoGU
            '   Case 1
            '      Tot_Haberes += Saldo
            '   Case 2
            '      Tot_Retenciones += Saldo
            '   Case 6
            '      Tot_SalarioFamiliar += Saldo
            '   Case Else
            'End Select

            'If TipoConceptoGU = 1 Or TipoConceptoGU = 4 Or TipoConceptoGU = 6 Or TipoConceptoGU = 7 Then
            '   Indice = 1
            'Else
            '   Indice = -1
            'End If

            'Tot_Neto += Saldo * Indice
            '-------------------------------------------------------------------------


            drCl.Saldo = Saldo
            dt.Rows.Add(drCl)

            drCl = dt.NewInformeControlRow
            drCl.NombreConcepto = "NETO A COBRAR:"
            drCl.Saldo = Sueldo_a_Cobrar
            dt.Rows.Add(drCl)

            Sueldo_a_Cobrar = 0

            drCl = dt.NewInformeControlRow
            dt.Rows.Add(drCl)

         End If

         'linea en blanco
         drCl = dt.NewInformeControlRow()
         dt.Rows.Add(drCl)

         drCl = dt.NewInformeControlRow()
         drCl.NombreConcepto = "TOTAL HABERES:"
         drCl.Saldo = Tot_Haberes
         dt.Rows.Add(drCl)

         drCl = dt.NewInformeControlRow()
         drCl.NombreConcepto = "TOTAL RETENCIONES:"
         drCl.Saldo = Tot_Retenciones
         dt.Rows.Add(drCl)

         drCl = dt.NewInformeControlRow()
         drCl.NombreConcepto = "TOTAL SALARIO FAMILIAR:"
         drCl.Saldo = Tot_SalarioFamiliar
         dt.Rows.Add(drCl)

         'drCl = dt.NewInformeControlRow()
         'drCl.NombreConcepto = "TOTAL SUMA:"
         'drCl.Saldo = Tot_Haberes.ToString
         'dt.Rows.Add(drCl)

         drCl = dt.NewInformeControlRow()
         drCl.NombreConcepto = "TOTAL NETO:"
         drCl.Saldo = Tot_Neto
         dt.Rows.Add(drCl)

         'total(general)
         drCl = dt.NewInformeControlRow()
         ' drCl("NombreSocio") = "Total General"
         '  drCl("Saldo") = SaldoGeneral
         dt.Rows.Add(drCl)

         Me.ugDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString("#,##0") & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("TipoDocSocio", System.Type.GetType("System.String"))
         .Columns.Add("NroDocSocio", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreSocio", System.Type.GetType("System.String"))
         .Columns.Add("Periodo1", System.Type.GetType("System.Decimal"))
         .Columns.Add("Periodo2", System.Type.GetType("System.Decimal"))
         .Columns.Add("Periodo3", System.Type.GetType("System.Decimal"))
         .Columns.Add("Periodo4", System.Type.GetType("System.Decimal"))
         .Columns.Add("Periodo5", System.Type.GetType("System.Decimal"))
         .Columns.Add("Periodo6", System.Type.GetType("System.Decimal"))
         .Columns.Add("Periodo7", System.Type.GetType("System.Decimal"))
         .Columns.Add("Periodo8", System.Type.GetType("System.Decimal"))
         .Columns.Add("Periodo9", System.Type.GetType("System.Decimal"))
         .Columns.Add("Periodo10", System.Type.GetType("System.Decimal"))
         .Columns.Add("Saldo", System.Type.GetType("System.Decimal"))

      End With

      Return dtTemp

   End Function

#End Region

   Private Sub ckbLegajo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbLegajo.CheckedChanged
      Me.bscIdLegajo.Enabled = Me.ckbLegajo.Checked
      Me.bscNombrePersonal.Enabled = Me.ckbLegajo.Checked

      If Not Me.ckbLegajo.Checked Then
         Me.bscIdLegajo.Text = ""
         Me.bscNombrePersonal.Text = ""
      Else
         Me.bscIdLegajo.Focus()
      End If
   End Sub

   Private Sub tsbRefrescar_Click_1(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click

   End Sub
End Class