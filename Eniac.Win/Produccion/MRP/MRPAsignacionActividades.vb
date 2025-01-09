Imports Eniac.Entidades
Imports Eniac.Reglas
Imports Eniac.Win.SincronizacionSubidaV2
Imports Infragistics.Win.Printing
Imports Infragistics.Win.UltraWinGrid.DocumentExport
Imports Infragistics.Win.UltraWinGrid.ExcelExport

Public Class MRPAsignacionActividades

   Private Const seleccionMasivoColumnName As String = "masivo"

#Region "Campos"
   Private _publicos As Publicos
   Private _idEstado As String = String.Empty
   Private _idTipoEstado As String = String.Empty
   Private _fechaComienzo As Date? = Nothing
   Private _cargaComboDestino As Boolean = True

   Private _tit As Dictionary(Of String, String)

   Private eOperMRP As OrdenProduccionMRPOperacion
   Private respetaOrden As Boolean = False
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboEstadosOrdenesProduccion(cmbEstados, True, True, True, False, String.Empty)
         cmbEstados.SelectedIndex = 1  'SOLO PENDIENTES

         _publicos.CargaComboTiposComprobantes(cmbTipoComprobanteOP, True, "PRODUCCION", , , , True)
         Me._publicos.CargaComboTiposComprobantes(cmbTipoComprobantePedido, True, "PEDIDOSCLIE", , , , True)

         _publicos.CargaComboSecciones(cmbSecciones)
         cmbSecciones.SelectedIndex = -1


         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)
         _publicos.CargaComboEmpleados(cmbResponsable, Entidades.Publicos.TiposEmpleados.RESPPROD)
         _publicos.CargaComboEmpleados(cmbEmpleado, Entidades.Publicos.TiposEmpleados.RESPPROD)

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         dtpFechaComienzo.Value = Date.Today

         _cargaComboDestino = True
         _publicos.CargaComboDesdeEnum(cmbEstadoCambiar, GetType(Reglas.Publicos.EstadoAsignaTarea))

         cmbEstadoCambiar.SelectedIndex = 0

         HabilitaDetalle(False)
         FormateaGrilla()

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
   Private Sub bscNombreTareas_BuscadorClick() Handles bscNombreTareas.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMRPTareas(bscNombreTareas)
            bscNombreTareas.Datos = New Reglas.MRPTareas().GetFiltradoPorNombre(bscNombreTareas.Text.Trim(), Entidades.Publicos.SiNoTodos.SI)
         End Sub)
   End Sub
   Private Sub bscNombreTareas_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreTareas.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosTareas(e.FilaDevuelta)
               bscNombreTareas.Select()
            End If
         End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Dim oProveedores = New Reglas.Proveedores
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscNombreProveedor.BuscadorClick
      Try
         Dim oProveedores = New Reglas.Proveedores
         Me._publicos.PreparaGrillaProveedores2(Me.bscNombreProveedor)
         Me.bscNombreProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscNombreProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscNombreProveedor.BuscadorSeleccion
      Try
         If e.FilaDevuelta IsNot Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoCentroProductor_BuscadorClick() Handles bscCodigoCentroProductor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMRPCentrosProductores(bscCodigoCentroProductor)
            bscCodigoCentroProductor.Datos = New Reglas.MRPCentrosProductores().GetFiltradoPorCodigo(bscCodigoCentroProductor.Text.Trim(), Entidades.Publicos.SiNoTodos.TODOS, True)
         End Sub)
   End Sub
   Private Sub bscNombreCentrosProductores_BuscadorClick() Handles bscNombreCentrosProductores.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMRPCentrosProductores(bscNombreCentrosProductores)
            bscNombreCentrosProductores.Datos = New Reglas.MRPCentrosProductores().GetFiltradoPorNombre(bscNombreCentrosProductores.Text.Trim(), Entidades.Publicos.SiNoTodos.SI, Entidades.Publicos.SiNoTodos.TODOS)
         End Sub)
   End Sub
   Private Sub bscCodigoCentroProductor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCentroProductor.BuscadorSeleccion, bscNombreCentrosProductores.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCentroProductor(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

   Private Sub chbSeccion_CheckedChanged(sender As Object, e As EventArgs) Handles chbSeccion.CheckedChanged
      TryCatched(Sub() chbSeccion.FiltroCheckedChanged(cmbSecciones))
   End Sub
   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(Sub() chbMarca.FiltroCheckedChanged(cmbMarca))
   End Sub

   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(cmbRubro))
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
      Sub()
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Estado: " & Me.cmbEstados.Text

         If Me.chbFecha.Checked Then
            Filtros = Filtros & " / Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text
         End If

         If Me.chbProducto.Checked Then
            Filtros = Filtros & " / Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text
         End If

         If Me.chbCliente.Checked Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If


         If Me.chbRubro.Checked Then
            If Filtros.Length > 0 Then Filtros += " / "
            Filtros += "Rubro: " & Me.cmbRubro.Text
         End If

         If Me.chbMarca.Checked Then
            If Filtros.Length > 0 Then Filtros += " / "
            Filtros += "Marca: " & Me.cmbMarca.Text
         End If

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewDialog1.Name = Me.Text
         UltraGridPrintDocument1.Header.TextCenter = Titulo
         UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewDialog1.ShowDialog()
      End Sub)
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, String.Empty))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, String.Empty))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(bscCodigoProducto2, bscProducto2))
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , , )
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , )
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion, bscCodigoProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbOrdenProduccion_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenProduccion.CheckedChanged
      TryCatched(
      Sub()
         txtIdOrdenProduccion.Enabled = chbOrdenProduccion.Checked
         cmbTipoComprobanteOP.Enabled = chbOrdenProduccion.Checked

         If Not chbOrdenProduccion.Checked Then
            txtIdOrdenProduccion.Text = String.Empty
            cmbTipoComprobanteOP.SelectedIndex = -1
         Else
            txtIdOrdenProduccion.Focus()
            cmbTipoComprobanteOP.SelectedIndex = 0
         End If
      End Sub)
   End Sub

   Private Sub chbTamanio_CheckedChanged(sender As Object, e As EventArgs) Handles chbTamanio.CheckedChanged
      TryCatched(
      Sub()
         txtTamanio.Enabled = chbTamanio.Checked
         If Not chbTamanio.Checked Then
            txtTamanio.Text = "0.000"
         Else
            txtTamanio.Focus()
         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_AfterCellActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterCellActivate
      TryCatched(
      Sub()

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         If Me.ugDetalle.ActiveCell Is Nothing Then Exit Sub

         HabilitaDetalle(True)
         LimpiaCamposOperacion()
         Try
            _fechaComienzo = DirectCast(Me.ugDetalle.ActiveCell.Row.Cells("FechaComienzo").Value, Date?)
         Catch ex As Exception
            _fechaComienzo = Nothing
         End Try

         Me.cmbEstadoCambiar.SelectedIndex = GetEstado(ugDetalle.ActiveCell.Row.Cells("IdEstadoTarea").Value.ToString())

         '-- Establece Centro Productor.- 
         bscCodigoCentroProductor.Text = ugDetalle.ActiveCell.Row.Cells("CodigoCentroProductor").Value.ToString()
         bscCodigoCentroProductor.PresionarBoton()

         If bscCodigoProveedor.Enabled Then
            bscCodigoProveedor.Text = ugDetalle.ActiveCell.Row.Cells("CodigoProveedor").Value.ToString()
            bscCodigoProveedor.PresionarBoton()
         End If

         '-- Establece la fecha de comienzo
         If _fechaComienzo IsNot Nothing Then
            dtpFechaComienzo.Value = _fechaComienzo.Value
         Else
            dtpFechaComienzo.Value = Today.Date
         End If

         CargaOrdenProducMRPOper(ugDetalle.ActiveCell.Row)
         respetaOrden = DirectCast(ugDetalle.ActiveCell.Row.Cells("RespetaOrden").Value, Boolean)
      End Sub)

   End Sub

   Private Sub CargaOrdenProducMRPOper(dr As UltraGridRow)
      eOperMRP = New OrdenProduccionMRPOperacion

      With eOperMRP
         .IdSucursal = DirectCast(dr.Cells("IdSucursal").Value, Integer)
         .NumeroOrdenProduccion = DirectCast(dr.Cells("NumeroOrdenProduccion").Value, Integer)
         .IdTipoComprobante = DirectCast(dr.Cells("IdTipoComprobante").Value, String)
         .LetraComprobante = DirectCast(dr.Cells("Letra").Value, String)
         .CentroEmisor = DirectCast(dr.Cells("CentroEmisor").Value, Integer)
         .Orden = DirectCast(dr.Cells("Orden").Value, Integer)

         .IdProducto = DirectCast(dr.Cells("idProducto").Value, String)
         .IdProcesoProductivo = DirectCast(dr.Cells("IdProcesoProductivo").Value, Long)
         .IdOperacion = DirectCast(dr.Cells("IdOperacion").Value, Integer)
         .CodigoProcProdOperacion = DirectCast(dr.Cells("CodigoProcProdOperacion").Value, String)

         .CentroProductorOperacion = DirectCast(dr.Cells("CentroProductorOperacion").Value, Integer)
         .Proveedor = 0
         If Not String.IsNullOrEmpty(dr.Cells("IdProveedor").Value.ToString()) Then
            .Proveedor = DirectCast(dr.Cells("IdProveedor").Value, Long)
         End If

         .IdEstadoTarea = DirectCast(dr.Cells("IdEstadoTarea").Value, String)
         .FechaComienzo = DirectCast(dr.Cells("FechaComienzo").Value, Date)
         .IdEmpleado = 0
         If Not String.IsNullOrEmpty(dr.Cells("IdEmpleado").Value.ToString()) Then
            .IdEmpleado = DirectCast(dr.Cells("IdEmpleado").Value, Integer)
         End If

      End With
   End Sub

   Private Sub cmdMasivo_Click(sender As Object, e As EventArgs) Handles cmdMasivo.Click
      TryCatched(
      Sub()


         Dim respuesta As DialogResult

         respuesta = ShowPregunta(String.Format(Traducciones.TraducirTexto("¿Desea cambiar el Estado actual de la Operacion Seleccionada al Estado: {0}?", Me, "__CambioEstadoMasivo"),
                                                Me.cmbEstadoCambiar.Text))

         If respuesta = Windows.Forms.DialogResult.Yes Then

            If ValidaReglasEstados() Then
               Dim regla = New Reglas.OrdenesProduccionMRPOperaciones()

               regla.ActualizarAsigna(eOperMRP)

               MessageBox.Show("Estado/s actualizado/s Exitosamente !!.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

               CargaGrillaDetalle()
               FormateaGrilla()
               HabilitaDetalle(False)
               LimpiaCamposOperacion()
            End If
         End If
      End Sub)
   End Sub
   Private Function ValidaReglasEstados() As Boolean
      If chbEmpleado.Checked Then
         eOperMRP.IdEmpleado = Integer.Parse(cmbEmpleado.SelectedValue.ToString())
      End If
      If chbFechaComienzo.Checked Then
         eOperMRP.FechaComienzo = dtpFechaComienzo.Value
      End If
      If eOperMRP.CentroProductorOperacion <> Integer.Parse(bscCodigoCentroProductor.Tag.ToString()) Then
         eOperMRP.CentroProductorOperacion = Integer.Parse(bscCodigoCentroProductor.Tag.ToString())
      End If
      If bscNombreProveedor.Selecciono Or bscCodigoProveedor.Selecciono Then
         eOperMRP.Proveedor = Integer.Parse(bscCodigoProveedor.Tag.ToString())
      End If
      If respetaOrden Then
         Dim rOPMRPO = New Reglas.OrdenesProduccionMRPOperaciones()
         Dim oLis = New List(Of OrdenProduccionMRPOperacion)
         oLis = rOPMRPO.GetAsignaActividad(eOperMRP.IdSucursal, eOperMRP.IdTipoComprobante, eOperMRP.LetraComprobante, eOperMRP.CentroEmisor,
                                           eOperMRP.NumeroOrdenProduccion, eOperMRP.Orden, eOperMRP.IdProducto, eOperMRP.IdProcesoProductivo,
                                           eOperMRP.CodigoProcProdOperacion)
         If oLis.Count > 0 Then
            Dim eLis = oLis.ElementAt(0)
            Select Case eLis.IdEstadoTarea
               Case Reglas.Publicos.EstadoAsignaTarea.PENDIENTE.ToString()
                  If cmbEstadoCambiar.Text <> "PENDIENTE" AndAlso cmbEstadoCambiar.Text <> "PAUSADA" Then
                     MessageBox.Show(String.Format("Respeta Orden {0}Estado de Actividad invalido ({2}).{0}Estado Operacion Anterior {1}!!.", Environment.NewLine, eLis.IdEstadoTarea, cmbEstadoCambiar.Text), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Exit Function
                  End If
               Case Reglas.Publicos.EstadoAsignaTarea.LIBERADA.ToString()
                  If cmbEstadoCambiar.Text <> "PENDIENTE" AndAlso cmbEstadoCambiar.Text <> "PAUSADA" Then
                     If cmbEstadoCambiar.Text = "LIBERADA" AndAlso eLis.FechaComienzo <= eOperMRP.FechaComienzo Then
                        eOperMRP.IdEstadoTarea = cmbEstadoCambiar.Text
                     Else
                        MessageBox.Show(String.Format("Respeta Orden {0}Estado de Actividad invalido ({2}).{0}Estado Operacion Anterior {1}!!.", Environment.NewLine, eLis.IdEstadoTarea, cmbEstadoCambiar.Text), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Function
                     End If
                  End If
               Case Reglas.Publicos.EstadoAsignaTarea.PAUSADA.ToString()
                  If cmbEstadoCambiar.Text <> "PENDIENTE" Or cmbEstadoCambiar.Text <> "PAUSADA" Or cmbEstadoCambiar.Text <> "LIBERADA" Then
                     MessageBox.Show(String.Format("Respeta Orden {0}Estado de Actividad invalido ({2}).{0}Estado Operacion Anterior {1}!!.", Environment.NewLine, eLis.IdEstadoTarea, cmbEstadoCambiar.Text), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Exit Function
                  End If
            End Select
            eOperMRP.IdEstadoTarea = cmbEstadoCambiar.Text
         Else
            eOperMRP.IdEstadoTarea = cmbEstadoCambiar.Text
         End If
      Else
         eOperMRP.IdEstadoTarea = cmbEstadoCambiar.Text
      End If

      Return True
   End Function

   Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaComienzo.KeyDown, cmbEstadoCambiar.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
      cmbEstadoCambiar.SelectedIndex = 0
   End Sub
   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      TryCatched(
      Sub()
         Me.txtOrdenCompra.Enabled = Me.chbOrdenCompra.Checked

         If Not Me.chbOrdenCompra.Checked Then
            Me.txtOrdenCompra.Text = String.Empty
         Else
            Me.txtOrdenCompra.Focus()
         End If
      End Sub)
   End Sub
   Private Sub cmbEstadoCambiar_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEstadoCambiar.SelectedValueChanged
      TryCatched(
      Sub()
         If Not _cargaComboDestino Then
            Dim cache = New Reglas.BusquedasCacheadas()
            Dim estadoSeleccionado = cache.BuscaEstadosOrdenesProduccion(cmbEstadoCambiar.Text)
         End If
      End Sub)
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If Me.chbProducto.Checked And Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbOrdenProduccion.Checked AndAlso Integer.Parse("0" & Me.txtIdOrdenProduccion.Text) = 0 Then
            MessageBox.Show("ATENCION: NO Ingresó un Número de Orden de Produccion aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtIdOrdenProduccion.Focus()
            Exit Sub
         End If

         If chbTamanio.Checked AndAlso Decimal.Parse("0" & Me.txtTamanio.Text) = 0 Then
            MessageBox.Show("ATENCION: NO Ingresó un Tamaño aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTamanio.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()
         FormateaGrilla()

         If ugDetalle.Rows.Count = 0 Then
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
         End If
         HabilitaDetalle(False)
         LimpiaCamposOperacion()
      End Sub)

   End Sub


   Private Sub chbTarea_CheckedChanged(sender As Object, e As EventArgs) Handles chbTarea.CheckedChanged
      bscNombreTareas.Enabled = chbTarea.Checked
      bscNombreTareas.Text = String.Empty
      bscNombreTareas.Focus()
   End Sub
   Private Sub chbPedidoVta_CheckedChanged(sender As Object, e As EventArgs) Handles chbPedidoVta.CheckedChanged
      txtNroPedido.Enabled = chbPedidoVta.Checked
      txtLineaPedido.Enabled = chbPedidoVta.Checked
      cmbTipoComprobantePedido.Enabled = chbPedidoVta.Checked
      If chbPedidoVta.Checked Then
         cmbTipoComprobantePedido.SelectedIndex = 0
      Else
         cmbTipoComprobantePedido.SelectedIndex = -1
         txtNroPedido.Text = String.Empty
         txtLineaPedido.Text = String.Empty
      End If
      txtNroPedido.Focus()
   End Sub
   Private Sub chbFechaComienzo_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaComienzo.CheckedChanged
      dtpFechaComienzo.Enabled = chbFechaComienzo.Checked
   End Sub

   Private Sub chbEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmpleado.CheckedChanged
      cmbEmpleado.Enabled = chbEmpleado.Checked
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarDatosTareas(dr As DataGridViewRow)
      bscNombreTareas.Text = dr.Cells("Descripcion").Value.ToString()
      bscNombreTareas.Tag = Integer.Parse(dr.Cells("IdTarea").Value.ToString())
   End Sub
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      bscNombreProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
   End Sub
   Private Sub CargarDatosCentroProductor(dr As DataGridViewRow)
      bscCodigoCentroProductor.Text = dr.Cells("CodigoCentroProductor").Value.ToString()
      bscCodigoCentroProductor.Tag = dr.Cells("IdCentroProductor").Value.ToString()
      bscNombreCentrosProductores.Text = dr.Cells("Descripcion").Value.ToString()

      If dr.Cells("ClaseCentroProductor").Value.ToString() = "EXT" AndAlso Not String.IsNullOrEmpty(dr.Cells("IdProveedor").Value.ToString()) Then
         Dim codigo = New Reglas.Proveedores().GetUno(Integer.Parse(dr.Cells("IdProveedor").Value.ToString())).IdProveedor
         bscCodigoProveedor.Text = codigo.ToString()
         bscCodigoProveedor.PresionarBoton()
      Else
         bscCodigoProveedor.Text = String.Empty
         bscNombreProveedor.Text = String.Empty
      End If
      bscCodigoProveedor.Enabled = dr.Cells("ClaseCentroProductor").Value.ToString() <> "INT"
      bscNombreProveedor.Enabled = dr.Cells("ClaseCentroProductor").Value.ToString() <> "INT"
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

         bscCliente.Enabled = False
         bscCodigoCliente.Enabled = False
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Enabled = False
         bscCodigoProducto2.Enabled = False
      End If
   End Sub
   Private Function GetEstado(estado As String) As Integer
      Select Case estado
         Case Reglas.Publicos.EstadoAsignaTarea.PENDIENTE.ToString()
            Return 0
         Case Reglas.Publicos.EstadoAsignaTarea.LIBERADA.ToString()
            Return 1
         Case Reglas.Publicos.EstadoAsignaTarea.PAUSADA.ToString()
            Return 2
         Case Reglas.Publicos.EstadoAsignaTarea.FINALIZADA.ToString()
            Return 3
      End Select
   End Function

   Private Sub CargaGrillaDetalle()
      'If cmbResponsable.SelectedIndex = -1 Then
      '   Throw New Exception("Debe seleccionar un responsable de Producción, por Favor Verificar!!!")
      'End If

      ' Dim responsable = cmbResponsable.ValorSeleccionado(Of Integer)
      Dim idResponsable = cmbResponsable.ValorSeleccionado(chbOperario, 0I)
      Dim fechaDesde = dtpDesde.Valor(chbFecha).IfNull()
      Dim fechaHasta = dtpHasta.Valor(chbFecha).IfNull()
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)
      Dim idOrdenProduccion = If(chbOrdenProduccion.Checked, txtIdOrdenProduccion.ValorNumericoPorDefecto(0I), -0I)
      Dim idTipocomprobanteOP = If(chbOrdenProduccion.Checked, cmbTipoComprobanteOP.SelectedValue.ToString(), String.Empty)
      Dim tamanio = If(chbTamanio.Checked, txtTamanio.ValorNumericoPorDefecto(0D), 0D)

      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)

      Dim seccion = If(chbSeccion.Checked, Integer.Parse(cmbSecciones.SelectedValue.ToString()), 0I)
      Dim tarea = If(chbTarea.Checked, Integer.Parse(bscNombreTareas.Tag.ToString()), 0I)

      Dim ordenCompra = If(chbOrdenCompra.Checked, txtOrdenCompra.ValorNumericoPorDefecto(0L), 0L)

      Dim idPedido = If(chbPedidoVta.Checked, txtNroPedido.ValorNumericoPorDefecto(0I), 0I)
      Dim linea = If(chbPedidoVta.Checked, txtLineaPedido.ValorNumericoPorDefecto(0I), 0I)

      Dim rOP = New Reglas.OrdenesProduccion()
      Dim dtDetalle = rOP.GetOrdenesProduccionTareas(actual.Sucursal.IdSucursal,
                                                     cmbEstados.Text,
                                                     fechaDesde, fechaHasta, idOrdenProduccion,
                                                     idProducto, idCliente, tamanio,
                                                     idMarca, idRubro, ordenCompra, idResponsable,
                                                     idTipocomprobanteOP, seccion, tarea, idPedido, linea)

      ugDetalle.DataSource = dtDetalle
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      cmbEstadoCambiar.SelectedIndex = 0
   End Sub

   Private Sub LimpiaCamposOperacion()
      cmbEstadoCambiar.SelectedIndex = 0

      chbFechaComienzo.Checked = False
      dtpFechaComienzo.Value = Date.Today
      chbEmpleado.Checked = False
      cmbEmpleado.SelectedIndex = 0

      bscCodigoCentroProductor.Text = String.Empty
      bscNombreCentrosProductores.Text = String.Empty

      bscCodigoProveedor.Text = String.Empty
      bscNombreProveedor.Text = String.Empty
   End Sub
   Private Sub RefrescarDatosGrilla()

      cmbEstados.SelectedIndex = 1

      LimpiaCamposOperacion()

      chbFecha.Checked = False
      chbProducto.Checked = False
      chbCliente.Checked = False
      chbOrdenProduccion.Checked = False
      chbTamanio.Checked = False
      chbOrdenCompra.Checked = False

      cmbEstadoCambiar.SelectedIndex = 0
      cmbResponsable.SelectedIndexIfAny(0)
      chbOperario.Checked = False
      'Limpio la Grilla.
      ugDetalle.ClearFilas()

      _idEstado = String.Empty
      _idTipoEstado = String.Empty

      chbPedidoVta.Checked = False
      chbSeccion.Checked = False
      chbTarea.Checked = False


      cmbEstados.Focus()

      HabilitaDetalle(False)

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub
   Private Sub HabilitaDetalle(estadoCambio As Boolean)

      cmbEstadoCambiar.Enabled = estadoCambio
      dtpFechaComienzo.Enabled = estadoCambio

      dtpFechaComienzo.Enabled = False
      chbFechaComienzo.Enabled = estadoCambio

      cmbEmpleado.Enabled = False
      chbEmpleado.Enabled = estadoCambio
      cmdMasivo.Enabled = estadoCambio

      gprCentroProductor.Enabled = estadoCambio
   End Sub

   Public Sub FormateaGrilla()
      Dim pos = 0I

      With ugDetalle.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         .Columns("IdTipoComprobante").FormatearColumna("Comprobante", pos, 150, HAlign.Left)
         .Columns("NumeroOrdenProduccion").FormatearColumna("Numero", pos, 60, HAlign.Right)
         .Columns("FechaOrdenProduccion").FormatearColumna("Fecha", pos, 80, HAlign.Center)

         .Columns("NombreCliente").FormatearColumna("Cliente", pos, 150)

         .Columns("IdProducto").FormatearColumna("Codigo Producto", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 170)

         .Columns("FechaEntrega").FormatearColumna("Fecha Entrega", pos, 90, HAlign.Center)
         .Columns("NumeroPedido").FormatearColumna("Pedido Vta", pos, 70, HAlign.Right)
         .Columns("OrdenPedido").FormatearColumna("Linea Vta", pos, 70, HAlign.Right)

         .Columns("CodigoProcProdOperacion").FormatearColumna("Codigo Operación", pos, 110, HAlign.Right)
         .Columns("DescripcionOperacion").FormatearColumna("Descripcion Operación", pos, 150)
         .Columns("IdEstadoTarea").FormatearColumna("Estado Operación", pos, 110, HAlign.Left)
         .Columns("FechaComienzo").FormatearColumna("Fecha Comienzo", pos, 100, HAlign.Center)

         .Columns("DescripcionCP").FormatearColumna("Centro Productor", pos, 150, HAlign.Left)
         .Columns("ClaseCentroProductor").FormatearColumna("Clase", pos, 80, HAlign.Left)

         .Columns("NombreProveedor").FormatearColumna("Proveedor", pos, 150, HAlign.Left)
         .Columns("NombreEmpleado").FormatearColumna("Empleado", pos, 150, HAlign.Left)

         .Columns("DescripcionSeccion").FormatearColumna("Seccion", pos, 150, HAlign.Left)

         .Columns("Observacion").FormatearColumna("Observacion", pos, 150, HAlign.Left)

      End With
   End Sub

   Private Sub cmbSecciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSecciones.SelectedIndexChanged

   End Sub

   Private Sub chbOperario_CheckedChanged(sender As Object, e As EventArgs) Handles chbOperario.CheckedChanged
      TryCatched(Sub() chbOperario.FiltroCheckedChanged(cmbResponsable))
   End Sub

#End Region
End Class