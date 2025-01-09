Public Class ClientesEstrellas

   Private _cacheSemaforo As List(Of Entidades.SemaforoVentaUtilidad)

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub()
                    _cacheSemaforo = New Reglas.SemaforoVentasUtilidades().GetTodos(Entidades.SemaforoVentaUtilidad.TiposSemaforos.ESTRELLAS)
                    RefrescarDatosGrilla()
                    Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)
                 End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         Me.tsbGrabar.PerformClick()
      ElseIf keyData = Keys.F5 Then
         Me.tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() Me.RefrescarDatosGrilla())
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(Sub() Grabar())
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub()
                    If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

                    Dim Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion()

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
                 End Sub)
   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      TryCatched(Sub() Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString())
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(Sub() ColorearCeldas(e))
   End Sub
   Private Sub ugDetalle_BeforeCellUpdate(sender As Object, e As UltraWinGrid.BeforeCellUpdateEventArgs) Handles ugDetalle.BeforeCellUpdate
      TryCatched(Sub() CalculosCellChanged(e))
   End Sub
   Private Sub ugDetalle_AfterCellUpdate(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.AfterCellUpdate
      TryCatched(Sub() ugDetalle.DisplayLayout.Bands(0).SortedColumns.RefreshSort(regroupBy:=False))
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()



      CargaGrillaDetalle()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim rCliente = New Reglas.Clientes()

      SetDataSource(rCliente.GetAll())


   End Sub
   Private Sub SetDataSource(dt As DataTable)
      Dim tit = GetColumnasVisiblesGrilla(ugDetalle)
      ugDetalle.DataSource = dt
      AjustarColumnasGrilla(ugDetalle, tit)

      ugDetalle.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString()})
      MostrarCount(dt.Rows.Count)

      Dim rows = ugDetalle.Rows.GetFilteredInNonGroupByRows()
      If rows.Length > 0 Then
         ugDetalle.ActiveRow = rows(0)
      End If
   End Sub
   Private Sub MostrarCount(cantidad As Integer)
      tssRegistros.Text = String.Format("{0} Registro{1}", cantidad, If(cantidad = 1, "", "s"))
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New System.Text.StringBuilder()
      Dim Primero = True
      With filtro
         'cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)
         '.AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)
         'cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Private Sub CalculosCellChanged(e As BeforeCellUpdateEventArgs)
      Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
      If dr IsNot Nothing Then
         Dim valorizacionFacturacionMensual = dr.Field(Of Decimal?)(Entidades.Cliente.Columnas.ValorizacionFacturacionMensual.ToString()).IfNull()
         Dim valorizacionCoeficienteFacturacion = dr.Field(Of Decimal?)(Entidades.Cliente.Columnas.ValorizacionCoeficienteFacturacion.ToString()).IfNull()
         Dim valorizacionFacturacion = dr.Field(Of Decimal?)(Entidades.Cliente.Columnas.ValorizacionFacturacion.ToString()).IfNull()

         Dim valorizacionImporteAdeudado = dr.Field(Of Decimal?)(Entidades.Cliente.Columnas.ValorizacionImporteAdeudado.ToString()).IfNull()
         Dim valorizacionCoeficienteDeuda = dr.Field(Of Decimal?)(Entidades.Cliente.Columnas.ValorizacionCoeficienteDeuda.ToString()).IfNull()
         Dim valorizacionDeuda = dr.Field(Of Decimal?)(Entidades.Cliente.Columnas.ValorizacionDeuda.ToString()).IfNull()

         Dim valorizacionProyecto = dr.Field(Of Decimal?)(Entidades.Cliente.Columnas.ValorizacionProyecto.ToString()).IfNull()

         Dim valorizacionCliente = dr.Field(Of Decimal?)(Entidades.Cliente.Columnas.ValorizacionCliente.ToString()).IfNull()
         Dim valorizacionEstrellas = dr.Field(Of Decimal?)(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString()).IfNull()

         Dim recalculaValorizacionFacturacion = False
         If e.Cell.Column.Key = Entidades.Cliente.Columnas.ValorizacionFacturacionMensual.ToString() Then
            valorizacionFacturacionMensual = e.NewValueAs(0D)
            recalculaValorizacionFacturacion = True
         End If
         If e.Cell.Column.Key = Entidades.Cliente.Columnas.ValorizacionCoeficienteFacturacion.ToString() Then
            valorizacionCoeficienteFacturacion = e.NewValueAs(0D)
            recalculaValorizacionFacturacion = True
         End If

         Dim recalculaValorizacionDeuda = False
         If e.Cell.Column.Key = Entidades.Cliente.Columnas.ValorizacionImporteAdeudado.ToString() Then
            valorizacionImporteAdeudado = e.NewValueAs(0D)
            recalculaValorizacionDeuda = True
         End If
         If e.Cell.Column.Key = Entidades.Cliente.Columnas.ValorizacionCoeficienteDeuda.ToString() Then
            valorizacionCoeficienteDeuda = e.NewValueAs(0D)
            recalculaValorizacionDeuda = True
         End If

         Dim recalculaValorizacionProyecto = False
         If e.Cell.Column.Key = Entidades.Cliente.Columnas.ValorizacionProyecto.ToString() Then
            valorizacionProyecto = e.NewValueAs(0D)
            recalculaValorizacionProyecto = True
         End If


         If recalculaValorizacionFacturacion Then
            valorizacionFacturacion = Math.Round(valorizacionFacturacionMensual * valorizacionCoeficienteFacturacion, 2)
         End If
         If recalculaValorizacionDeuda Then
            valorizacionDeuda = Math.Round(valorizacionImporteAdeudado * valorizacionCoeficienteDeuda, 2)
         End If
         If recalculaValorizacionFacturacion Or recalculaValorizacionDeuda Or recalculaValorizacionProyecto Then
            valorizacionCliente = valorizacionFacturacion + valorizacionDeuda + valorizacionProyecto
         End If

         dr(Entidades.Cliente.Columnas.ValorizacionFacturacionMensual.ToString()) = valorizacionFacturacionMensual
         dr(Entidades.Cliente.Columnas.ValorizacionCoeficienteFacturacion.ToString()) = valorizacionCoeficienteFacturacion
         dr(Entidades.Cliente.Columnas.ValorizacionFacturacion.ToString()) = valorizacionFacturacion
         dr(Entidades.Cliente.Columnas.ValorizacionImporteAdeudado.ToString()) = valorizacionImporteAdeudado
         dr(Entidades.Cliente.Columnas.ValorizacionCoeficienteDeuda.ToString()) = valorizacionCoeficienteDeuda
         dr(Entidades.Cliente.Columnas.ValorizacionDeuda.ToString()) = valorizacionDeuda
         dr(Entidades.Cliente.Columnas.ValorizacionProyecto.ToString()) = valorizacionProyecto
         dr(Entidades.Cliente.Columnas.ValorizacionCliente.ToString()) = valorizacionCliente


         Dim maxValorizacionClienteObj = dr.Table.Compute(String.Format("MAX({0})", Entidades.Cliente.Columnas.ValorizacionCliente.ToString()), String.Empty)
         Dim maxValorizacionCliente As Decimal
         If IsNumeric(maxValorizacionClienteObj) Then
            maxValorizacionCliente = Convert.ToDecimal(maxValorizacionClienteObj)
         End If

         Dim recalculaTodasLasEstrellas = valorizacionEstrellas >= 10 Or Math.Round(maxValorizacionCliente, 2) = Math.Round(valorizacionCliente, 2)

         valorizacionEstrellas = Math.Round(valorizacionCliente * 10 / maxValorizacionCliente, 2)

         dr(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString()) = valorizacionEstrellas

         If recalculaTodasLasEstrellas Then
            Dim selectWhere = String.Format("{0} <> {1}", Entidades.Cliente.Columnas.IdCliente.ToString(), dr.Field(Of Long)(Entidades.Cliente.Columnas.IdCliente.ToString()))
            dr.Table.Select(selectWhere).All(Function(dr1)
                                                Dim valorizacionCliente1 = dr1.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionCliente.ToString())
                                                dr1(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString()) = Math.Round(valorizacionCliente1 * 10 / maxValorizacionCliente, 2)
                                                Return True
                                             End Function)
         End If

      End If
   End Sub
   Private Sub ColorearCeldas(e As UltraWinGrid.InitializeRowEventArgs)
      Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Row)
      If dr IsNot Nothing Then
         Dim estrellas = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString())

         Dim semaforo = If(_cacheSemaforo Is Nothing, Nothing, _cacheSemaforo.Where(Function(s) s.PorcentajeHasta >= estrellas).OrderBy(Function(s) s.PorcentajeHasta).FirstOrDefault())
         If semaforo IsNot Nothing Then
            e.Row.Cells(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString()).Color(Color.FromArgb(semaforo.ColorLetra), Color.FromArgb(semaforo.ColorSemaforo))
         Else
            e.Row.Cells(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString()).Color(Nothing, Nothing)
         End If

         'If valorizacionEstrellas > 7.5 Then
         '   e.Row.Cells(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString()).Color(Color.White, Color.Green)
         'ElseIf valorizacionEstrellas > 5 Then
         '   e.Row.Cells(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString()).Color(Color.Black, Color.Yellow)
         'ElseIf valorizacionEstrellas > 2.5 Then
         '   e.Row.Cells(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString()).Color(Color.Black, Color.Orange)
         'Else
         '   e.Row.Cells(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString()).Color(Color.White, Color.Red)
         'End If
      End If
   End Sub

   Private Sub Grabar()
      ugDetalle.UpdateData()
      Dim dt = If(TypeOf (ugDetalle.DataSource) Is DataTable, DirectCast(ugDetalle.DataSource, DataTable), Nothing)
      If dt IsNot Nothing Then
         If ShowPregunta("¿Desea guardar las modificaciones de estrellas?") = Windows.Forms.DialogResult.Yes Then
            Dim rCliente = New Reglas.Clientes()

            Dim cantidadActualidos = rCliente.GrabarValoracionEstrellasMasiva(dt)

            ShowMessage(String.Format("¡Se actualizaron {0} clientes exitosamente!", cantidadActualidos))

            RefrescarDatosGrilla()
         End If
      End If
   End Sub

   '-.PE-31547.-
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class