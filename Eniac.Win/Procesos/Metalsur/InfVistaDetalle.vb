Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Public Class InfVistaDetalle
    Implements IConParametros



    Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
        Throw New NotImplementedException()
    End Sub

#Region "Propiedades"
    Private Property Modo As Eniac.Entidades.Cliente.ModoClienteProspecto?

    Public Property FechaDesde() As Date?

    Public Property FechaHasta() As Date?




#End Region


#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        MyBase.OnLoad(e)

        Try

            'Me._publicos = New Publicos()

            If Me.FechaDesde.HasValue Then
                Me.dtpDesde.Value = Me.FechaDesde.Value
            Else
                Me.dtpDesde.Value = DateTime.Today
            End If

            If Me.FechaHasta.HasValue Then
                Me.dtpHasta.Value = Me.FechaHasta.Value
            Else
                Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            End If

            'Me.dtpDesde.Value = DateTime.Today
            'Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

            Me.CargaGrillaDetalle()


            '_cargando = False



        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "Eventos"

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

            Dim Filtros As String = String.Empty

            Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

            'If Me.chbCliente.Checked Then
            '   Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
            'End If



            Dim Titulo As String

            Titulo = Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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

    Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs)
        Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub



    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        Try



            Me.Cursor = Cursors.WaitCursor

            Me.CargaGrillaDetalle()

            ugDetalle.AgregarTotalesSuma({Entidades.CRMNovedad.Columnas.Cantidad.ToString()})

            LeerPreferencias()
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


#End Region

#Region "Metodos"

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

    Private Sub RefrescarDatosGrilla()


        If Me.FechaDesde.HasValue Then
            Me.dtpDesde.Value = Me.FechaDesde.Value
        Else
            Me.dtpDesde.Value = DateTime.Today
        End If

        If Me.FechaHasta.HasValue Then
            Me.dtpHasta.Value = Me.FechaHasta.Value
        Else
            Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
        End If



        If Not Me.ugDetalle.DataSource Is Nothing Then
            DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
        End If

        Me.dtpDesde.Focus()

    End Sub



    Private Sub ClearCombo(cmb As ComboBox)
        If TypeOf (cmb.DataSource) Is IList Then DirectCast(cmb.DataSource, IList).Clear()
    End Sub

    Private Sub CargaGrillaDetalle()

        Dim oc As Reglas.SincronizarOrdenesCompra = New Reglas.SincronizarOrdenesCompra(IdFuncion)


        Dim dtDetalle As DataTable

        'TODO: El parametro de proyectos se envia cero pero hay que poner el control en la pantalla y enviar el parametro 
        'correcto para que funcione la pantalla.

        'dtDetalle = oc.GetInfVistaDetalle("SBVACIA.dbo.", dtpDesde.Value, dtpHasta.Value, FIngresoDesde.Value, FIngresoHasta.Value)

        Me.ugDetalle.DataSource = dtDetalle

        Me.tssRegistros.Text = dtDetalle.Rows.Count.ToString() & " Registros"

    End Sub

#End Region

End Class