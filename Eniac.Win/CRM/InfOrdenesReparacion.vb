Public Class InfOrdenesReparacion

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            PreferenciasLeer(ugDetalle, tsbPreferencias)
            _publicos = New Publicos()

            _publicos.CargaComboSucursales(cmbSucursal)
            _publicos.CargaComboCRMEstadosNovedades(cmbEstadoNovedad, "SERVICE")

            _publicos.CargaComboCRMTiposComentariosNovedades(cmbTipoComentarios)

            _publicos.CargaComboDesdeEnum(cmbVisibleCliente, GetType(Entidades.Publicos.SiNoTodos))
            _publicos.CargaComboDesdeEnum(cmbVisibleRepresentante, GetType(Entidades.Publicos.SiNoTodos))

            dtpDesde.Value = dtpDesde.MaxDate
            CargaGrillaDetalle()

            RefrescarGrillaDetalle()

         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
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
      TryCatched(Sub() RefrescarGrillaDetalle(),
                 onFinallyAction:=Sub(owner) tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar)
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim Filtros = "Desde el  " & dtpDesde.Value.ToString("dd/MM/yyyy") & "  Hasta el " & dtpHasta.Value.ToString("dd/MM/yyyy")
            Dim Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + "ORDENES DE REPARACIÓN" + Environment.NewLine + Environment.NewLine + Filtros

            Dim UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(components)
            UltraPrintPreviewD.AutoSizeMode = AutoSizeMode.GrowAndShrink
            UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

            UltraPrintPreviewD.Document = UltraGridPrintDocument1
            UltraPrintPreviewD.Name = Text

            UltraPrintPreviewDialog1.Name = Text
            UltraGridPrintDocument1.Header.TextCenter = Titulo
            UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
            UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
            UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
            UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
            UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

            UltraPrintPreviewD.MdiParent = MdiParent
            UltraPrintPreviewD.Show()
            UltraPrintPreviewD.Select()
         End Sub)
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, ""))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, ""))
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbSucursal_CheckedChanged(sender As Object, e As EventArgs) Handles chbSucursal.CheckedChanged
      TryCatched(Sub() chbSucursal.FiltroCheckedChanged(cmbSucursal))
   End Sub
   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(bscCodigoProducto2, bscProducto2))
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
            bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
         End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscProducto2)
            bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
         End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarProducto(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      TryCatched(Sub() chbEstado.FiltroCheckedChanged(cmbEstadoNovedad))
   End Sub
   Private Sub chbTipoComentarios_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComentarios.CheckedChanged
      TryCatched(Sub() chbTipoComentarios.FiltroCheckedChanged(cmbTipoComentarios))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()

            If chbEstado.Checked AndAlso cmbEstadoNovedad.SelectedIndex = -1 Then
               ShowMessage("ATENCION: No seleccionó un Estado aunque activó ese Filtro.")
               Exit Sub
            End If

            If chbTipoComentarios.Checked AndAlso cmbTipoComentarios.SelectedIndex = -1 Then
               ShowMessage("ATENCION: No seleccionó un Tipo de Comentario aunque activó ese Filtro.")
               Exit Sub
            End If

            If chbProducto.Checked And Not (bscCodigoProducto2.Selecciono Or bscProducto2.Selecciono) Then
               ShowMessage("ATENCION: No seleccionó un Producto aunque activó ese Filtro.")
               Exit Sub
            End If

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Select()
               chkExpandAll.Enabled = True
               chkExpandAll.Checked = False
            Else
               ShowMessage("¡¡¡NO hay registros que cumplan con la seleccion !!!")
            End If
         End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#End Region

#Region "Métodos Privados"

   Private Sub RefrescarGrillaDetalle()

      chbMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbEstado.Checked = False
      chbSucursal.Checked = False
      cmbSucursal.SelectedIndex = -1
      chbProducto.Checked = False
      chbTipoComentarios.Checked = False

      cmbVisibleCliente.SelectedIndex = 1
      cmbVisibleRepresentante.SelectedIndex = 0

      chkExpandAll.Enabled = False
      chkExpandAll.Checked = False

      ugDetalle.ClearFilas()
      cmbSucursal.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      'Dim tipoFechaFiltro = Entidades.CRMNovedad.TipoFechaFiltro.FechaNovedad
      Dim idSucursal = cmbSucursal.ValorSeleccionado(chbSucursal, 0I)
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text.Trim(), String.Empty)
      Dim idEstadoNovedad = cmbEstadoNovedad.ValorSeleccionado(chbEstado, 0I)
      Dim idTipoComentario = cmbTipoComentarios.ValorSeleccionado(chbTipoComentarios, 0I)
      'Dim fechaDesde = dtpDesde.Value
      'Dim fechaHasta = dtpHasta.Value

      Dim rCRM = New Reglas.CRMNovedades()
      Dim ds = rCRM.GetInfOrdenesReparacion(idSucursal,
                                            dtpDesde.Value, dtpHasta.Value, nullFechaNovedad:=Nothing,
                                            desdeFechaHoraEnvioGarantia:=Nothing, hastaFechaHoraEnvioGarantia:=Nothing, nullFechaHoraEnvioGarantia:=False,
                                            desdeFechaHoraRetiroGarantia:=Nothing, hastaFechaHoraRetiroGarantia:=Nothing, nullFechaHoraRetiroGarantia:=False,
                                            desdeFechaHoraRetiro:=Nothing, hastaFechaHoraRetiro:=Nothing, nullFechaHoraRetiro:=False,
                                            desdeFechaHoraEntrega:=Nothing, hastaFechaHoraEntrega:=Nothing, nullFechaHoraEntrega:=False, 'fechaDesde As Date?, fechaHasta As Date?, tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                            idProducto,
                                            idEstadoNovedad, idProveedorService:=0, idTipoComentario,
                                            DirectCast(cmbVisibleCliente.SelectedValue, Entidades.Publicos.SiNoTodos),
                                            DirectCast(cmbVisibleRepresentante.SelectedValue, Entidades.Publicos.SiNoTodos),
                                            cantidadLineasVacias:=3)

      ugDetalle.SetDataBinding(ds, "Cabecera")

      ugDetalle.DataSource = ds

      ugDetalle.DisplayLayout.Bands("Detalle").Override.RowSizing = RowSizing.AutoFree

      With ugDetalle.DisplayLayout.Bands("Detalle")
         For Each col In .Columns
            col.Hidden = True
         Next
         .Columns("Comentario").FormatearColumna("Cometario", 0, 750)
      End With

      tssRegistros.Text = ds.Tables(0).Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      bscProducto2.Selecciono = True
      bscCodigoProducto2.Selecciono = True
   End Sub

#End Region

End Class