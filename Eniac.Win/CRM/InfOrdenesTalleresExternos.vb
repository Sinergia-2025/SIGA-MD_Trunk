Public Class InfOrdenesTalleresExternos

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

            Dim Titulo As String

            If radEnviadas.Checked Then
               Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + "ORDENES ENVIADAS AL TALLER" + Environment.NewLine + Filtros
            Else
               Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + "ORDENES PENDIENTES EN TALLER" + Environment.NewLine + Filtros
            End If

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
            UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
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

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.Trim.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCliente)
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
               btnConsultar.Select()
            End If
         End Sub)
   End Sub

   Private Sub chbProveedorHabitual_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedorHabitual.CheckedChanged
      TryCatched(Sub() chbProveedorHabitual.FiltroCheckedChanged(bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores(bscCodigoProveedor)
            Dim codigoProveedor = bscCodigoProveedor.Text.Trim().ValorNumericoPorDefecto(-1L)
            bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
         End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores(bscProveedor)
            bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosProveedor(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbProducto.Checked And Not (bscCodigoProducto2.Selecciono Or bscProducto2.Selecciono) Then
               ShowMessage("ATENCION: No seleccionó un Producto aunque activó ese Filtro.")
               Exit Sub
            End If
            If chbCliente.Checked And Not (bscCodigoCliente.Selecciono Or bscCliente.Selecciono) Then
               ShowMessage("ATENCION: No seleccionó un Cliente aunque activó ese Filtro.")
               Exit Sub
            End If
            If chbProveedorHabitual.Checked And Not (bscCodigoProveedor.Selecciono Or bscProveedor.Selecciono) Then
               ShowMessage("ATENCION: No seleccionó un Proveedor aunque activó ese Filtro.")
               Exit Sub
            End If

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Select()
            Else
               ShowMessage("¡¡¡NO hay registros que cumplan con la seleccion !!!")
            End If
         End Sub)
   End Sub
#End Region

#Region "Métodos"
   Private Sub RefrescarGrillaDetalle()
      chbMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbCliente.Checked = False
      chbProducto.Checked = False
      chbProveedorHabitual.Checked = False
      radPendientes.Checked = True

      ugDetalle.ClearFilas()
      dtpDesde.Select()
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      bscCliente.Selecciono = True
      bscCodigoCliente.Selecciono = True
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      bscProducto2.Selecciono = True
      bscCodigoProducto2.Selecciono = True
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      bscCodigoProveedor.Selecciono = True
      bscProveedor.Selecciono = True
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)
      Dim idProveedor = If(chbProveedorHabitual.Checked, bscCodigoProveedor.Tag.ToString().ValorNumericoPorDefecto(0L), 0L)
      Dim idCliente = If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ValorNumericoPorDefecto(0L), 0L)

      Dim desdeFechaNovedad As Date?, hastaFechaNovedad As Date?, nullFechaNovedad As Boolean
      Dim desdeFechaHoraEnvioGarantia As Date?, hastaFechaHoraEnvioGarantia As Date?, nullFechaHoraEnvioGarantia As Boolean
      Dim desdeFechaHoraRetiroGarantia As Date?, hastaFechaHoraRetiroGarantia As Date?, nullFechaHoraRetiroGarantia As Boolean
      Dim desdeFechaHoraRetiro As Date?, hastaFechaHoraRetiro As Date?, nullFechaHoraRetiro As Boolean
      Dim desdeFechaHoraEntrega As Date?, hastaFechaHoraEntrega As Date?, nullFechaHoraEntrega As Boolean

      If radEnviadas.Checked Then
         desdeFechaHoraEnvioGarantia = dtpDesde.Value
         hastaFechaHoraEnvioGarantia = dtpHasta.Value
      ElseIf radRetiradas.Checked Then
         desdeFechaHoraRetiroGarantia = dtpDesde.Value
         hastaFechaHoraRetiroGarantia = dtpHasta.Value
      ElseIf radPendientes.Checked Then
         desdeFechaHoraEnvioGarantia = dtpDesde.Value
         hastaFechaHoraEnvioGarantia = dtpHasta.Value
         nullFechaHoraRetiroGarantia = True
      End If

      Dim dtDetalle = New Reglas.CRMNovedades().GetInfCRMService(0,
                                                                 desdeFechaNovedad, hastaFechaNovedad, nullFechaNovedad,
                                                                 desdeFechaHoraEnvioGarantia, hastaFechaHoraEnvioGarantia, nullFechaHoraEnvioGarantia,
                                                                 desdeFechaHoraRetiroGarantia, hastaFechaHoraRetiroGarantia, nullFechaHoraRetiroGarantia,
                                                                 desdeFechaHoraRetiro, hastaFechaHoraRetiro, nullFechaHoraRetiro,
                                                                 desdeFechaHoraEntrega, hastaFechaHoraEntrega, nullFechaHoraEntrega,
                                                                 idProducto, 0, idProveedor, idCliente)

      ugDetalle.DataSource = dtDetalle

   End Sub

   Private Sub tsbImprimirPred_Click(sender As Object, e As EventArgs) Handles tsbImprimirPred.Click
      TryCatched(
       Sub()
          '  If Not bscCuentaBancaria.FilaDevuelta Is Nothing Then
          '  Dim dtMov As DataTable = DirectCast(ugDetalle.DataSource, DataTable)

          Dim dtCO As CRMDataSet.CRMNovedadesTalleresExternosDataTable = New CRMDataSet.CRMNovedadesTalleresExternosDataTable()
          Dim drCO As CRMDataSet.CRMNovedadesTalleresExternosRow

          For Each vo As UltraGridRow In ugDetalle.Rows

             drCO = dtCO.NewCRMNovedadesTalleresExternosRow()

             drCO.IdNovedad = Long.Parse(vo.Cells("IdNovedad").Value.ToString())
             drCO.Comentario = vo.Cells("Comentario").Value.ToString()
             drCO.Estado = vo.Cells("Estado").Value.ToString()
             If Not String.IsNullOrEmpty(vo.Cells("FechaRetiroGarantia_Fecha").Value.ToString()) Then
                drCO.FechaEntrega = Date.Parse(vo.Cells("FechaRetiroGarantia_Fecha").Value.ToString())
             End If
             If Not String.IsNullOrEmpty(vo.Cells("FechaEntregadoGarantia_Fecha").Value.ToString()) Then
                drCO.FechaEnvio = Date.Parse(vo.Cells("FechaEntregadoGarantia_Fecha").Value.ToString())
             End If
             drCO.Garantia = vo.Cells("Garantia").Value.ToString()
             drCO.NombreProducto = vo.Cells("NombreProducto").Value.ToString()
             If Not String.IsNullOrEmpty(vo.Cells("CostoReparacion").Value.ToString()) Then
                drCO.CostoReparacion = Decimal.Parse(vo.Cells("CostoReparacion").Value.ToString())
             End If

             dtCO.AddCRMNovedadesTalleresExternosRow(drCO)
          Next


          Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

             parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
             parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
             parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Titulo", Me.Text))
             parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", CargarFiltrosImpresion()))

          Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfOrdenesTalleresExternos.rdlc", "CRMDataSet_CRMNovedadesTalleresExternos", dtCO, parm, True, 1) '# 1 = Cantidad Copias

          frmImprime.Text = Text
             frmImprime.WindowState = FormWindowState.Maximized
             frmImprime.Show()

          'Else
          '   MessageBox.Show("Por favor seleccione una cuenta bancaria", Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
          'End If
       End Sub)
   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Desde el  " & dtpDesde.Value.ToString("dd/MM/yyyy") & "  Hasta el " & dtpHasta.Value.ToString("dd/MM/yyyy"))
         .AppendFormat(" - Producto: {0}", bscProducto2.Text)
         .AppendFormat(" - Cliente: {0}", bscCliente.Text)
         .AppendFormat(" - Proveedor: {0}", bscProveedor.Text)
         .AppendFormat(" - Ordenes: {0}", IIf(radEnviadas.Checked, radEnviadas.Text, IIf(radPendientes.Checked, radPendientes.Text, radRetiradas.Text)))
      End With
      Return filtro.ToString().Trim()
   End Function
#End Region

End Class