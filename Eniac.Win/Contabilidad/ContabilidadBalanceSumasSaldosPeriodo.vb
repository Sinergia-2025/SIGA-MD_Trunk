Public Class ContabilidadBalanceSumasSaldosPeriodo

#Region "Campos"

   Private _publicosContabilidad As ContabilidadPublicos
   Private _publicos As Publicos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicosContabilidad = New ContabilidadPublicos()
            _publicos = New Publicos()

            _publicosContabilidad.CargaComboPlanes(cmbPlan, True)
            _publicosContabilidad.CargarSucursalesACheckListBox(clbSucursales)

            RefrescarDatos()
            PreferenciasLeer(ugDetalle, tsbPreferencias)
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub
   Private Sub tsbImprimirPredisenado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPredisenado.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim parm = New ReportParameterCollection()

            parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion)
            parm.Add("NombreSucursal", clbSucursales.CheckedItems.OfType(Of Entidades.Sucursal)().ToList().ConvertAll(Function(s) s.Nombre.Trim()), " / ")
            parm.Add("Filtros", CargarFiltrosImpresion())

            Using dt = DirectCast(ugDetalle.DataSource, DataTable).Copy()

               Dim i = 0I
               For Each dc In dt.Columns.OfType(Of DataColumn)().Where(Function(c) c.ColumnName.Contains("/")).ToArray()
                  i += 1
                  Dim colName = dc.ColumnName
                  dt.Columns.Add(String.Format("Periodo{0:00}", i), dc.DataType, String.Format("[{0}]", dc.ColumnName))

                  parm.Add(String.Format("Header_Periodo{0:00}", i), dc.ColumnName)
               Next

               Using frmImprime = New VisorReportes("Eniac.Win.rptBalanceSumasSaldosPeriodo.rdlc",
                                                    "dtsBalanceSumasSaldosPeriodo_dtBalanceSumasSaldosPeriodoSumasSaldosPeriodo", dt, parm, True, 1)
                  frmImprime.Text = Text
                  frmImprime.rvReporte.DocumentMapCollapsed = True
                  frmImprime.Size = New Size(780, 600)
                  frmImprime.StartPosition = FormStartPosition.CenterScreen
                  frmImprime.WindowState = FormWindowState.Maximized
                  frmImprime.ShowDialog()
               End Using
            End Using
         End Sub)
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.FitWidthToPages = 1, .Landscape = True}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub ugDetalle_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugDetalle.AfterRowFilterChanged
      TryCatched(Sub() ActualizarInfoRegistros())
   End Sub

   Private Sub dtpBalanceHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpBalanceHasta.ValueChanged
      TryCatched(
         Sub()
            If Not dtpBalanceDesde.Checked Then
               'Si no está tildado el desde muestra el comienzo del ejercicio como desde.
               Dim rEjercicio = New Reglas.ContabilidadEjercicios()
               Dim codEjeVigente = rEjercicio.GetUna(dtpBalanceHasta.Value, False)
               dtpBalanceDesde.Value = codEjeVigente.FechaDesde
               dtpBalanceDesde.Checked = False
            End If
         End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(Sub() CargarGrillaDetalle())
   End Sub
#End Region

#Region "Metodos"

   Private Sub RefrescarDatos()
      'Siempre marco la actual
      For idx = 0 To clbSucursales.Items.Count - 1
         Dim s = DirectCast(clbSucursales.Items.Item(idx), Entidades.Sucursal)
         clbSucursales.SetItemChecked(idx, s.Id = actual.Sucursal.Id)
      Next

      Dim rEjercicio = New Reglas.ContabilidadEjercicios()
      Dim codEjeVigente = rEjercicio.GetUna(Date.Today, False)

      dtpBalanceHasta.Value = codEjeVigente.FechaHasta.UltimoSegundoDelDia()
      dtpBalanceDesde.Checked = False
      cmbPlan.SelectedIndex = 0

      ugDetalle.ClearFilas()

      ActualizarInfoRegistros()
   End Sub

   Private Sub CargarGrillaDetalle()
      Dim fechaDesde = dtpBalanceDesde.Valor()
      Dim fechaHasta = dtpBalanceHasta.Value
      Dim idPlan As Integer? = cmbPlan.ValorSeleccionado(Of Integer)()
      If idPlan < 1 Then idPlan = Nothing

      Dim idSucs = clbSucursales.CheckedItems.OfType(Of Entidades.Sucursal).ToList().ConvertAll(Function(s) s.Id)

      Dim regla = New Reglas.ContabilidadReportes()
      Dim dt = regla.BalanceSumaSaldoPorPeriodo(idSucs, fechaDesde, fechaHasta, idPlan, chbIncluirCuentasSinMovimientos.Checked)

      ugDetalle.DataSource = dt
      FormatearGrilla()

      ActualizarInfoRegistros()
      If Not dt.Any() Then
         ShowMessage("No se encontraron datos para los filtros seleccionados.")
         Exit Sub
      End If
   End Sub
   Private Sub FormatearGrilla()
      With ugDetalle.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.ActivateOnly
         Next

         Dim pos = 0I
         .Columns("IdCuenta").FormatearColumna("Nro. Cuenta", pos, 80, HAlign.Right)
         .Columns("NombreCuenta").FormatearColumna("Cuenta", pos, 300)

         Dim listaTotales = New List(Of String)()
         .Columns.OfType(Of UltraGridColumn).Where(Function(c) c.Key.Contains("/")).ToList().
            ForEach(
            Sub(c)
               c.FormatearColumna(c.Key, pos, 100, HAlign.Right,, "N2").Header.Appearance.TextHAlign = HAlign.Center
               listaTotales.Add(c.Key)
            End Sub)

         .Columns("SaldoTotal").FormatearColumna("Total", pos, 100, HAlign.Right,, "N2")

         listaTotales.Add("SaldoTotal")
         ugDetalle.AgregarTotalesSuma(listaTotales.ToArray())
         ugDetalle.AgregarFiltroEnLinea({"NombreCuenta"})
      End With
   End Sub
   Private Sub ActualizarInfoRegistros()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()

      With filtro
         .AppendFormat("Suc.: {0}", String.Join(" / ", clbSucursales.CheckedItems.OfType(Of Entidades.Sucursal)().ToList().ConvertAll(Function(s) s.Id)))
         .AppendFormat(" - Fecha ")
         If dtpBalanceDesde.Checked Then
            .AppendFormat("desde: {0:dd/MM/yyyy} - ", dtpBalanceHasta.Value)
         End If
         .AppendFormat("hasta: {0:dd/MM/yyyy}", dtpBalanceHasta.Value)
         If cmbPlan.SelectedIndex >= 0 Then
            .AppendFormat(" - Plan: {0}", cmbPlan.Text)
         End If
         If chbIncluirCuentasSinMovimientos.Checked Then
            .AppendFormat(" - {0}", chbIncluirCuentasSinMovimientos.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#End Region

End Class