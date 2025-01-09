Public Class ContabilidadListadoAsientos

#Region "Campos"

   Private _publicosContabilidad As ContabilidadPublicos
   Private _publicos As Publicos

   Private _utilizaCentroCostos As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicosContabilidad = New ContabilidadPublicos()
         _publicos = New Publicos()

         _publicosContabilidad.CargaComboPlanes(cmbPlan, False)
         _publicosContabilidad.CargarSucursalesACheckListBox(clbSucursales)
         _publicos.CargaComboDesdeEnum(cmbExportados, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbTipoRegistro, Entidades.ContabilidadReporte.TipoRegistro.DEFINITIVO)

         _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos

         If _utilizaCentroCostos Then
            _publicos.CargaComboCentroCostos(cmbCentroCosto)
            cmbCentroCosto.Visible = True
            chbCentroCosto.Visible = True
         Else
            cmbCentroCosto.Visible = False
            chbCentroCosto.Visible = False
         End If
         RefrescarDatos()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
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

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir("", CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim parm = New ReportParameterCollection(CargarFiltrosImpresion())

         Dim dt = ugDetalle.DataSource(Of DataTable)
         Dim frmImprime = New VisorReportes("Eniac.Win.rptAsientos.rdlc", "dtsAsientos_dtAsientos", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Text
         frmImprime.rvReporte.DocumentMapCollapsed = True
         frmImprime.Size = New Size(780, 600)
         frmImprime.StartPosition = FormStartPosition.CenterScreen
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbCentroCosto_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroCosto.CheckedChanged
      TryCatched(Sub() chbCentroCosto.FiltroCheckedChanged(cmbCentroCosto))
   End Sub
   Private Sub chbAsiento_CheckedChanged(sender As Object, e As EventArgs) Handles chbAsiento.CheckedChanged
      TryCatched(Sub() chbAsiento.FiltroCheckedChanged(usaPermitido:=True, bscNumeroAsiento, bscConcepto))
   End Sub

   Private Sub bscNumeroAsiento_BuscadorClick() Handles bscNumeroAsiento.BuscadorClick
      TryCatched(
      Sub()
         _publicosContabilidad.PreparaGrillaAsientosContables(bscNumeroAsiento)
         If cmbTipoRegistro.SelectedValue IsNot Nothing Then
            If cmbTipoRegistro.ValorSeleccionado(Of Entidades.ContabilidadReporte.TipoRegistro) = Entidades.ContabilidadReporte.TipoRegistro.DEFINITIVO Then
               Dim oAsientos = New Reglas.ContabilidadAsientos()
               bscNumeroAsiento.Datos = oAsientos.GetPorIdASiento(cmbPlan.ValorSeleccionado(0I), bscNumeroAsiento.Text.ValorNumericoPorDefecto(0I))
            Else
               Dim oAsientos = New Reglas.ContabilidadAsientosTmp()
               bscNumeroAsiento.Datos = oAsientos.GetPorIdASiento_Tmp(cmbPlan.ValorSeleccionado(0I), bscNumeroAsiento.Text.ValorNumericoPorDefecto(0I))
            End If
         End If
      End Sub)
   End Sub
   Private Sub bscConcepto_BuscadorClick() Handles bscConcepto.BuscadorClick
      TryCatched(
      Sub()
         _publicosContabilidad.PreparaGrillaAsientosContables(bscConcepto)
         If cmbTipoRegistro.SelectedValue IsNot Nothing Then
            If cmbTipoRegistro.ValorSeleccionado(Of Entidades.ContabilidadReporte.TipoRegistro) = Entidades.ContabilidadReporte.TipoRegistro.DEFINITIVO Then
               Dim oAsientos = New Reglas.ContabilidadAsientos()
               bscConcepto.Datos = oAsientos.GetPorNombre(bscConcepto.Text.Trim())
            Else
               Dim oAsientos = New Reglas.ContabilidadAsientosTmp()
               bscConcepto.Datos = oAsientos.GetPorNombre_Tmp(bscConcepto.Text.Trim())
            End If
         End If
      End Sub)
   End Sub
   Private Sub bscNumeroAsiento_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNumeroAsiento.BuscadorSeleccion, bscConcepto.BuscadorSeleccion
      TryCatched(
      Sub()
         If e.FilaDevuelta IsNot Nothing Then
            bscConcepto.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadAsiento.Columnas.NombreAsiento.ToString()).Value.ToString()
            bscNumeroAsiento.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadAsiento.Columnas.IdAsiento.ToString()).Value.ToString()
            lblFecha.Text = Date.Parse(e.FilaDevuelta.Cells(Entidades.ContabilidadAsiento.Columnas.FechaAsiento.ToString()).Value.ToString()).ToString("dd/MM/yyyy")
            bscConcepto.Permitido = False
            bscNumeroAsiento.Permitido = False
            btnConsultar.Focus()
         End If
      End Sub)
   End Sub

#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(Sub() CargaGrillaDetalle())
   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaGrillaDetalle()
      If ValidarAsiento() Then
         Dim sucs = _publicosContabilidad.GetIdSucursalesACheckListBox(clbSucursales)
         Dim idPlan = cmbPlan.ValorSeleccionado(0I)
         Dim idAsiento = If(chbAsiento.Checked, bscNumeroAsiento.Text.ValorNumericoPorDefecto(-1I), -1I)

         Dim idCentroCosto As Integer? = Nothing
         If chbCentroCosto.Checked Then
            idCentroCosto = cmbCentroCosto.ValorSeleccionado(0I)
         End If

         Dim rReportes = New Reglas.ContabilidadReportes()
         Dim reporte = rReportes.Asiento_GetDetalle(sucs, idPlan, idAsiento, idCentroCosto,
                                                    dtpDesde.Value, dtpHasta.Value,
                                                    cmbTipoRegistro.ValorSeleccionado(Of Entidades.ContabilidadReporte.TipoRegistro),
                                                    cmbExportados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos))
         ugDetalle.DataSource = reporte.detallesAsiento

         If reporte.detallesAsiento Is Nothing OrElse Not reporte.detallesAsiento.Any() Then
            ShowMessage("No se encontraron datos para los filtros seleccionados")
            Exit Sub
         End If

         FormatearGrilla()

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False
         chkExpandAll.Checked = True
      End If
   End Sub

   Private Function ValidarAsiento() As Boolean

      If cmbTipoRegistro.SelectedValue Is Nothing Then
         ShowMessage("Indique si el tipo de registro en DEFINITIVO o TEMPORAL.")
         cmbTipoRegistro.Focus()
         Return False
      End If

      If chbAsiento.Checked And Not bscNumeroAsiento.Selecciono And Not bscConcepto.Selecciono Then
         ShowMessage("Ingrese un número de asiento para generar el informe.")
         bscNumeroAsiento.Focus()
         Return False
      End If

      If chbCentroCosto.Checked And cmbCentroCosto.SelectedIndex = -1 Then
         ShowMessage("Ha seleccionado el filtro por Centro de Costos pero no ha seleccionado uno. Por favor reintente.")
         cmbCentroCosto.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub RefrescarDatos()

      _publicosContabilidad.RefrescaSucursalesACheckListBox(clbSucursales)

      cmbPlan.SelectedIndex = 0

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      cmbExportados.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbTipoRegistro.SelectedValue = Entidades.ContabilidadReporte.TipoRegistro.DEFINITIVO

      chbAsiento.Checked = False
      'Lo hago a propósito.
      lblFecha.Text = ""

      ugDetalle.ClearFilas()

   End Sub

   Private Sub FormatearGrilla()

      ugDetalle.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
      ugDetalle.DisplayLayout.Bands(0).SortedColumns.Add("nombreAsiento", False, True)
      ugDetalle.DisplayLayout.Bands(0).Columns("idAsiento").Band.SortedColumns.RefreshSort(False)
      ugDetalle.Rows.ExpandAll(False)

      With ugDetalle.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns("idAsiento").FormatearColumna("Nro. Asiento", pos, 70, HAlign.Right)
         .Columns("fechaAsiento").FormatearColumna("Fecha", pos, 80, HAlign.Center,, Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("nombreAsiento").FormatearColumna("Asiento", pos, 200)
         .Columns("idCuenta").FormatearColumna("Nro. Cuenta", pos, 70, HAlign.Right)
         .Columns("Cuenta").FormatearColumna("Cuenta", pos, 200)
         .Columns("Debe").FormatearColumna("Debe", pos, 70, HAlign.Right, , Formatos.Format.Decimales2)
         .Columns("Haber").FormatearColumna("Haber", pos, 70, HAlign.Right, , Formatos.Format.Decimales2)
         .Columns("CodigoReferencia").FormatearColumna("Referencia", pos, 70, HAlign.Right)
         .Columns("NombreReferencia").FormatearColumna("Nombre Referencia", pos, 170)

         .Columns("idRenglon").OcultoPosicion(hidden:=True, pos)
         .Columns("IdTipoReferencia").OcultoPosicion(hidden:=True, pos)
         .Columns("Referencia").OcultoPosicion(hidden:=True, pos)

         .Columns("IdCentroCosto").FormatearColumna("CC.", pos, 50, HAlign.Right)
         .Columns("NombreCentroCosto").FormatearColumna("Centro de Costos", pos, 150)

         .Columns("IdCentroCosto").OcultoPosicion(hidden:=Not _utilizaCentroCostos, pos)
         .Columns("NombreCentroCosto").OcultoPosicion(hidden:=Not _utilizaCentroCostos, pos)

         .Summaries.Clear()

         ugDetalle.AgregarTotalesSuma({"Debe", "Haber"})
         ugDetalle.AgregarFiltroEnLinea({"nombreAsiento", "Cuenta", "NombreReferencia"})

      End With
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fecha desde: {0:dd/MM/yyyy} - hasta: {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         If clbSucursales.CheckedItems.Count > 0 Then
            Dim sucs = String.Join(", ", _publicosContabilidad.GetNombreSucursalesACheckListBox(clbSucursales))
            .AppendFormat(" - Suc.: {0}", sucs)
         End If
         If cmbPlan.SelectedIndex >= 0 Then
            .AppendFormat(" - Plan: {0}", cmbPlan.Text)
         End If
         If cmbTipoRegistro.SelectedIndex >= 0 Then
            .AppendFormat(" - Tipo: {0}", cmbTipoRegistro.Text)
         End If
         If chbAsiento.Checked Then
            .AppendFormat(" - Código Asiento: {0} - Concepto: {1} - Fecha: {2}", bscNumeroAsiento.Text, bscConcepto.Text, lblFecha.Text)
         End If

      End With
      Return filtro.ToString()
   End Function
#End Region

End Class