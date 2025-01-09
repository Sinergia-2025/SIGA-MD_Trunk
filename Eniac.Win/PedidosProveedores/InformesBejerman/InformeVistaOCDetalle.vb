#Region "Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
#End Region

Public Class InformeVistaOCDetalle

#Region "Campos"
   Private _publicos As Publicos
#End Region

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         '# Valores inciales para las fechas Desde/Hasta
         Me.SetearFechas()

         '# Lectura de preferencias
         PreferenciasLeer(Me.ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#Region "Métodos"

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As StringBuilder = New StringBuilder()
      Dim Primero As Boolean = True
      With filtro
         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)
      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub Imprimir()
      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Dim Titulo As String

      Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion()

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

   End Sub

   Private Sub RefrescarDatos()

      Me.ugDetalle.ClearFilas()
      Me.SetearFechas()

      Me.tssRegistros.Text = String.Format("{0} Registros", Me.ugDetalle.Rows.Count.ToString())

   End Sub

   Private Sub SetearFechas()
      Me.dtpDesde.Value = UltimoSegundoDelDia(Date.Today.AddDays(-1)).AddSeconds(1)
      Me.dtpHasta.Value = UltimoSegundoDelDia(Me.dtpDesde.Value)
   End Sub

   Private Sub CargarGrillaDetalle()

      Dim fechaDesde As Date = Me.dtpDesde.Value
      Dim fechaHasta As Date = Me.dtpHasta.Value

      Dim rSincronizarOC As Reglas.SincronizarOrdenesCompra = New Reglas.SincronizarOrdenesCompra(IdFuncion)

      '# El informe muestra la información en plano - Sin formateos.
      Me.ugDetalle.DataSource = rSincronizarOC.GetDetallesBejerman(fechaDesde, fechaHasta)

      '# Preferencias
      Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)

      If Not Me.ugDetalle.Rows.Count > 0 Then
         ShowMessage("NO hay registros que cumplan con la seleccion !!!")
      End If

   End Sub

#End Region

#Region "Eventos"
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.CargarGrillaDetalle()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.tssRegistros.Text = String.Format("{0} Registros", Me.ugDetalle.Rows.Count.ToString())
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.RefrescarDatos()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try
         Cursor = Cursors.WaitCursor
         Me.Imprimir()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Try
         Me.Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Me.PreferenciasCargar(Me.ugDetalle, tsbPreferencias)
         Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

End Class