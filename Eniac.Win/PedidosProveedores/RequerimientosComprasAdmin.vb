Public Class RequerimientosComprasAdmin
#Region "Campos"

   Private _publicos As Publicos
   Private _tipoTipoComprobante As Entidades.TipoComprobante.Tipos = Entidades.TipoComprobante.Tipos.REQCOMPRAS

   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbTodos, Reglas.Publicos.TodosEnum.MararTodos)

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante.ToString())
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         _publicos.CargaComboDesdeEnum(cmbAsignados, Entidades.Publicos.SiNoTodos.NO)

         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         ugDetalle.DisplayLayout.Bands(0).Columns("NombreModelo").Hidden = Not Reglas.Publicos.ProductoTieneModelo
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubSubRubro

         RefrescarDatosGrilla()

         ugDetalle.AgregarFiltroEnLinea({"Observacion", "IdProducto", "NombreProducto", "ObservacionRQProducto", "NombreProveedorHabitual", "NombreProveedorAsignado"})
         ugDetalle.AgregarTotalesSuma({"Cantidad", "CantidadAsignada"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

      End Sub)
   End Sub
   'Protected Overrides Sub OnShown(e As EventArgs)
   '   MyBase.OnShown(e)
   '   CargaGrillaDetalle(onLoad:=True)
   'End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbAsignar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub chbRequerimiento_CheckedChanged(sender As Object, e As EventArgs) Handles chbRequerimiento.CheckedChanged
      TryCatched(Sub() chbRequerimiento.FiltroCheckedChanged(txtRequerimiento, "0"))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
   Sub()
      If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscProducto.Selecciono Then
         ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
         bscCodigoProducto.Focus()
         Exit Sub
      End If

      If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscNombreProveedor.Selecciono Then
         ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
         bscCodigoProveedor.Focus()
         Exit Sub
      End If

      CargaGrillaDetalle(onLoad:=False)

      If ugDetalle.Rows.Count > 0 Then
         btnConsultar.Focus()

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False
      Else
         ShowMessage("NO hay registros que cumplan con la seleccion !!!")
      End If
   End Sub)

   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

   Private Sub ugDetalle_CantidadFilasChanged(sender As Object, e As UltraGridSiga.CantidadFilasChangedEventArgs) Handles ugDetalle.CantidadFilasChanged
      TryCatched(
   Sub()
      tsbAsignar.Enabled = e.CantidadFilas > 0
   End Sub)
   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, "Selec", Function(dr) True))
   End Sub
#End Region

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbAsignar_Click(sender As Object, e As EventArgs) Handles tsbAsignar.Click
      TryCatched(Sub() AsignarProveedores())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(
      Sub()
         PreferenciasCargar(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

#Region "Eventos Buscador Producto"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto, bscProducto))
   End Sub

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto)
         bscProducto.Datos = New Reglas.Productos().GetPorNombre(bscProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub

   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscProducto.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region
#Region "Eventos Buscador Proveedor"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscNombreProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor, True)
      End Sub)
   End Sub
   Private Sub bscNombreProveedor_BuscadorClick() Handles bscNombreProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscNombreProveedor)
         bscNombreProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscNombreProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscNombreProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub cmbMarcas_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim marcas = cmbMarcas.GetMarcas(todosVacio:=True)
                    cmbModelos.ConcatenarNombreMarca = marcas.CountSecure() <> 1
                    cmbModelos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                           marcas:=marcas)
                 End Sub)
   End Sub
   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
                    cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
                    cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                             rubros:=rubros)
                 End Sub)
   End Sub
   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
                    cmbSubSubRubros.ConcatenarNombreSubRubro = subRubros.CountSecure() <> 1
                    cmbSubSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                                subRubro:=subRubros)
                 End Sub)

   End Sub

#End Region

#End Region

#Region "Métodos"
   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto.Permitido = False
         bscCodigoProducto.Permitido = False
         bscProducto.Selecciono = True
         bscCodigoProducto.Selecciono = True
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscNombreProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         btnConsultar.Focus()
      End If

   End Sub

   Private Sub RefrescarDatosGrilla()

      chbFecha.Checked = False
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
      cmbAsignados.SelectedValue = Entidades.Publicos.SiNoTodos.NO

      chbProducto.Checked = False
      chbProveedor.Checked = False

      cmbMarcas.Refrescar()
      cmbModelos.Refrescar()
      cmbRubros.Refrescar()
      cmbSubRubros.Refrescar()
      cmbSubSubRubros.Refrescar()

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      chbRequerimiento.Checked = False

      cmbTodos.SelectedIndex = 0

      ugDetalle.ClearFilas()

      cmbAsignados.Focus()

   End Sub

   Private Sub CargaGrillaDetalle(onLoad As Boolean)
      Dim desde = If(onLoad, Date.Today.AddDays(3), dtpDesde.Valor(chbFecha))
      Dim hasta = If(onLoad, Date.Today.AddDays(2), dtpHasta.Valor(chbFecha))

      Dim rPedidos = New Reglas.RequerimientosCompras()
      Dim dtDetalle = rPedidos.GetInfReqDetProducto(desde.Date(), hasta.UltimoSegundoDelDia(), fechaEntregaDesde:=Nothing, fechaEntregaHasta:=Nothing,
                                                    cmbTiposComprobantes.GetTiposComprobantes(), If(chbRequerimiento.Checked, Long.Parse(txtRequerimiento.Text), 0L),
                                                    asignados:=Entidades.Publicos.SiNoTodos.TODOS, cmbAsignados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos), idUsuario:=String.Empty,
                                                    If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L), If(chbProducto.Checked, bscCodigoProducto.Text, String.Empty),
                                                    cmbMarcas.GetMarcas(todosVacio:=True), cmbModelos.GetModelos(todosVacio:=True),
                                                    cmbRubros.GetRubros(todosVacio:=True), cmbSubRubros.GetSubRubros(todosVacio:=True), cmbSubSubRubros.GetSubSubRubros(todosVacio:=True),
                                                    anulados:=Entidades.Publicos.SiNoTodos.NO,
                                                    agregarSelec:=True, incluyeDetalleAsignados:=False, PlanMaestroNumero:=0,
                                                    PlanMaestroFechaDesde:=Nothing, PlanMaestroFechaHasta:=Nothing)
      ugDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, muestraId:=True, muestraNombre:=False)

         If chbFecha.Checked Then
            .AppendFormat(" - Fechas: Desde {0} Hasta {1}", dtpDesde.Value, dtpHasta.Value)
         End If

         .AppendFormat("Asignados: {0}", cmbAsignados.Text)

         If chbProveedor.Checked Then
            .AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text, bscNombreProveedor.Text)
         End If

         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto.Text, bscProducto.Text)
         End If

         If cmbMarcas.Visible Then cmbMarcas.CargaFiltroImpresion(filtro, muestraId:=True, muestraNombre:=False)
         If cmbModelos.Visible Then cmbModelos.CargaFiltroImpresion(filtro, muestraId:=True, muestraNombre:=False)
         If cmbRubros.Visible Then cmbRubros.CargaFiltroImpresion(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubRubros.Visible Then cmbSubRubros.CargaFiltroImpresion(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubSubRubros.Visible Then cmbSubSubRubros.CargaFiltroImpresion(filtro, muestraId:=True, muestraNombre:=False)

      End With

      Return filtro.ToString()
   End Function

   Public Sub AsignarProveedores()
      Using frm = New RequerimientosComprasAdminAsignarProveedores()
         ugDetalle.UpdateData()
         Dim drColSelec = ugDetalle.DataSource(Of DataTable).Where(Function(dr) dr.Field(Of Boolean)("Selec"))
         If drColSelec.CountSecure > 0 Then
            Dim dtProductos = drColSelec.CopyToDataTable()
            If frm.ShowDialog(Me, Entidades.TipoComprobante.Tipos.PRESUPPROV, Entidades.TipoComprobante.Tipos.PRESUPPROV, dtProductos) = DialogResult.OK Then
               btnConsultar.PerformClick()
            End If
         End If
      End Using
   End Sub


#End Region

End Class