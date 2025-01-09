Option Explicit On
Option Strict On

Imports Eniac.Entidades
Imports System.Text

Public Class ContabilidadProcesos

   Private _dtGrilla As DataTable

#Region "Eventos"
   Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
      Try
         If Me.ValidarProceso() Then
            Me.Procesar()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos Privados"
   Private Function ValidarProceso() As Boolean
      Return True
   End Function

   Private Sub FormatearGrilla()

      With Me.grdResultados.DisplayLayout.Bands(0)
         Dim pos As Integer = 0


         .Columns("TipoProceso").FormatearColumna("Tipo", pos, 70, , , , , UltraWinGrid.Activation.NoEdit).AnchoMinimoMaximo(minWidth:=Nothing, maxWidth:=70)
         .Columns("TipoProceso").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
         .Columns("TipoProceso").MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
         .Columns("TipoProceso").MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
         .Columns("TipoProceso").MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
         .Columns("TipoProceso").MergedCellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

         ''
         .Columns("IdPlanCuenta").OcultoPosicion(True, pos)

         ''
         .Columns("idAsiento").FormatearColumna("Asiento", pos, 70, , , , , UltraWinGrid.Activation.NoEdit).AnchoMinimoMaximo(minWidth:=Nothing, maxWidth:=70)
         .Columns("idAsiento").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
         .Columns("idAsiento").MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
         .Columns("idAsiento").MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
         .Columns("idAsiento").MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
         .Columns("idAsiento").MergedCellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

         ''
         .Columns("dscAsiento").FormatearColumna("Descripción", pos, 180)
         .Columns("dscAsiento").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
         .Columns("dscAsiento").MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
         .Columns("dscAsiento").MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
         .Columns("dscAsiento").MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
         .Columns("dscAsiento").MergedCellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

         ''
         .Columns("FechaAsiento").FormatearColumna("Fecha", pos, 80, HAlign.Center, , "dd/MM/yyyy").AnchoMinimoMaximo(minWidth:=Nothing, maxWidth:=80)
         ''
         .Columns("Cuenta").FormatearColumna("Cuentas", pos, 180)
         ''
         .Columns("debe").FormatearColumna("Debe", pos, 80, HAlign.Right, , "N2").AnchoMinimoMaximo(minWidth:=Nothing, maxWidth:=80)

         ''
         .Columns("haber").FormatearColumna("Haber", pos, 80, HAlign.Right, , "N2").AnchoMinimoMaximo(minWidth:=Nothing, maxWidth:=80)

         .Columns("Observaciones").FormatearColumna("Mensaje", pos, 200, , True)

         'Me.grdResultados.DisplayLayout.Bands(0).Columns("Documento").Header.Caption = "Documento"
         'Me.grdResultados.DisplayLayout.Bands(0).Columns("Documento").Width = 120

      End With

      grdResultados.AgregarFiltroEnLinea({"dscAsiento", "Cuenta"})

      Me.grdResultados.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ResizeAllColumns

   End Sub

   Private Function ArmarGrillaResultados() As DataTable
      Return New Reglas.ContabilidadProcesos().CrearTablaResultados()
      'Dim datosResultado As New DataTable
      'datosResultado.Columns.Add("TipoProceso", GetType(String))
      'datosResultado.Columns.Add("idAsiento", GetType(Integer))
      'datosResultado.Columns.Add("dscAsiento", GetType(String))
      'datosResultado.Columns.Add("Cuenta", GetType(String)) 'Cuentas.CodCuenta + desc
      'datosResultado.Columns.Add("Documento", GetType(String))
      'datosResultado.Columns.Add("Debe", GetType(Decimal))
      'datosResultado.Columns.Add("Haber", GetType(Decimal))

      'Return datosResultado
   End Function
   Private Sub Procesar()
      Dim oProcesoContable As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos()

      _dtGrilla.Clear()
      Me.grdResultados.DisplayLayout.Bands(0).Columns("Observaciones").Hidden = True
      'Facturas-Ventas
      'Caja
      'Facturas-Compras
      'Stock
      'Cuenta Corriente
      'Pagos a Proveedores
      'Bancos
      'Anulaciones

      ' para cada item chequeado, llamo al proceso correspondiente para incuirlo en contabilidad.
      For i As Integer = 0 To Me.chkprocesos.CheckedItems.Count - 1
         Select Case Me.chkprocesos.CheckedItems(i).ToString
            Case "Ventas"
               _dtGrilla.ImportRowRange(oProcesoContable.ProcesarVentas(Me.dtpDesde.Value, Me.dtpHasta.Value).Select())
            Case "CC. Clientes"
               _dtGrilla.ImportRowRange(oProcesoContable.ProcesarCtaCteClte(Me.dtpDesde.Value, Me.dtpHasta.Value).Select())

            Case "Stock"
               _dtGrilla.ImportRowRange(oProcesoContable.ProcesarStock(Me.dtpDesde.Value, Me.dtpHasta.Value).Select())
               _dtGrilla.ImportRowRange(oProcesoContable.ProcesarStockVentas(Me.dtpDesde.Value, Me.dtpHasta.Value).Select())

            Case "Compras"
               _dtGrilla.ImportRowRange(oProcesoContable.ProcesarCompras(Me.dtpDesde.Value, Me.dtpHasta.Value).Select())

            Case "CC. Proveedores"
               _dtGrilla.ImportRowRange(oProcesoContable.ProcesarCtaCteProv(Me.dtpDesde.Value, Me.dtpHasta.Value).Select())

            Case "Caja"
               _dtGrilla.ImportRowRange(oProcesoContable.ProcesarCaja(Me.dtpDesde.Value, Me.dtpHasta.Value).Select())

            Case "Bancos"
               _dtGrilla.ImportRowRange(oProcesoContable.ProcesarBancos(Me.dtpDesde.Value, Me.dtpHasta.Value).Select())
         End Select
         Application.DoEvents()
      Next

      Dim errorCount As Integer = _dtGrilla.Select("Observaciones IS NOT NULL").Length
      Dim msg As StringBuilder = New StringBuilder()
      msg.AppendFormat("Se procesaron {0} registros.", _dtGrilla.Rows.Count)
      If errorCount > 0 Then
         Me.grdResultados.DisplayLayout.Bands(0).Columns("Observaciones").Hidden = False
         msg.AppendLine().AppendLine()
         msg.AppendFormat("Se produjeron {0} errores.", errorCount)
      End If
      MessageBox.Show(msg.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   End Sub

#End Region


#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      _dtGrilla = Me.ArmarGrillaResultados()
      Me.grdResultados.DataSource = _dtGrilla

      FormatearGrilla()

      Refrescar()

      MyBase.OnLoad(e)

   End Sub

#End Region

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Refrescar()
   End Sub

   Private Sub Refrescar()
      _dtGrilla.Clear()
      Me.dtpHasta.Value = Today
      Me.dtpDesde.Value = New Date(Today.Year, Today.Month, 1)
      Me.grdResultados.DisplayLayout.Bands(0).Columns("Observaciones").Hidden = True
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor

         For i As Integer = 0 To chkprocesos.Items.Count - 1
            chkprocesos.SetItemChecked(i, chbTodos.Checked)
         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

End Class