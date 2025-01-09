Option Strict On
Option Explicit On
Public Class BaseInforme

#Region "Overrides"
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Select Case keyData
         Case Keys.F5
            RefrescarDatosGrilla()
            Return True

         Case Else
            Return MyBase.ProcessCmdKey(msg, keyData)
      End Select

   End Function
#End Region

#Region "Eventos"

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         CargaGrillaDetalle()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarDatosGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try
         ImprimirGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimirPrediseñado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPrediseñado.Click
      Try
         ImprimirPredisenado()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         ExportarGrillaExcel()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         ExportarGrillaPdf()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region


   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      Try
         ExpandirTodo()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region



   Private Sub RefrescarDatosGrilla()

   End Sub

   Private Sub ImprimirGrilla()

   End Sub

   Private Sub ImprimirPredisenado()

   End Sub

   Private Sub ExportarGrillaExcel()
      ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
   End Sub

   Private Sub ExportarGrillaPdf()
      ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
   End Sub

   Private Sub CargaGrillaDetalle()

   End Sub

   Private Sub ExpandirTodo()
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Return String.Empty
   End Function

End Class