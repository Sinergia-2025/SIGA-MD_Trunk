Public Class InfCtaCtePendientePorProducto

#Region "Campos"

   Private _publicos As Publicos
   Private _idUsuario As String = actual.Nombre
   Private _utilizaIntereses As Boolean
   Private _vieneDeOnLoad As Boolean = False
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _utilizaIntereses = New Reglas.Categorias().CategoriasConInteres().Count > 0

            'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
            If New Reglas.Empleados().GetPorUsuario(_idUsuario).Rows.Count = 0 Then
               _idUsuario = ""
            End If

            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario)
            If _idUsuario = "" Then
               cmbVendedor.SelectedIndex = -1
            Else
               chbVendedor.Checked = True
               chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
            End If

            _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
            cmbZonaGeografica.SelectedIndex = -1

            _publicos.CargaComboCategorias(cmbCategoria)



            _vieneDeOnLoad = True
            'Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS", , , , , True)
            cmbTiposComprobantes.Initializar(False, "VENTAS", "CTACTECLIE")
            cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
            _vieneDeOnLoad = False

            cmbGrupos.Inicializar()
            cmbGrupos.SelectedValue = Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()

            cmbGrabanLibro.Items.Insert(0, "TODOS")
            cmbGrabanLibro.Items.Insert(1, "SI")
            cmbGrabanLibro.Items.Insert(2, "NO")
            cmbGrabanLibro.SelectedIndex = 0
            _publicos.CargaComboProvincias(cmbProvincia)


            '  Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)
            'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreZonaGeografica").Hidden = (Me.cmbZonaGeografica.Items.Count = 1)

            ugDetalle.AgregarTotalesSuma({"ImporteTotalNeto", "Comision", "Saldo2"})

            ugDetalle.AgregarFiltroEnLinea({"NombreVendedor", "NombreCliente", "NombreProducto", "CUIT", "Telefonos", "Observacion", "NombreClienteCtaCte"}, {"Ver"})

            PreferenciasLeer(ugDetalle, tsbPreferencias)

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
            'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
            'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

            'If Not Reglas.Publicos.TieneModuloContabilidad Then
            '   ugDetalle.DisplayLayout.Bands(0).Columns("IdPlanCuenta").Hidden = True
            '   ugDetalle.DisplayLayout.Bands(0).Columns("IdAsiento").Hidden = True
            'End If

            '  Me.ugDetalle.DisplayLayout.Bands(0).Columns("Interes").Hidden = Not _utilizaIntereses
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

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            If e.Cell.Column.Key = "Ver" Then
               Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
               If dr IsNot Nothing Then
                  Dim tipoComprobante = New Reglas.TiposComprobantes().GetUno(ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString())

                  If tipoComprobante.EsRecibo = True Then
                     'imprime los recibos
                     Dim rCtaCte = New Reglas.CuentasCorrientes()
                     Dim ctacte = rCtaCte.GetUna(dr.Field(Of Integer)("IdSucursal"),
                                                 dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                                                 dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Long)("NumeroComprobante"))
                     Dim imp = New RecibosImprimir()
                     imp.ImprimirRecibo(ctacte, True)
                  Else
                     Dim rVentas = New Reglas.Ventas()
                     Dim venta = rVentas.GetUna(dr.Field(Of Integer)("IdSucursal"),
                                                dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                                                dr.Field(Of Integer)("CentroEmisor").ToShort(), dr.Field(Of Long)("NumeroComprobante"))
                     Dim imp = New Impresion(venta)
                     If Not tipoComprobante.EsFiscal Then
                        imp.ImprimirComprobanteNoFiscal(True)
                     Else
                        imp.ReImprimirComprobanteFiscal()
                     End If
                  End If
               End If
            End If
         End Sub)
   End Sub

#Region "Eventos Toolbar"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

#End Region

#Region "Eventos Filtros"
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged

      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If

         Me.cmbZonaGeografica.Focus()

      End If

   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

   End Sub
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If

   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            'Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
            '_listaTipoComprobante = New List(Of Entidades.TipoComprobante)()
         Else
            Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged

      Me.dtpDesde.Enabled = Me.chbFecha.Checked
      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If Me.chbFecha.Checked Then
         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Date.Now
      End If

      Me.dtpDesde.Focus()

   End Sub
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub
   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged

      Me.cmbProvincia.Enabled = Me.chbProvincia.Checked

      If Not Me.chbProvincia.Checked Then
         Me.cmbProvincia.SelectedIndex = -1
      Else
         If Me.cmbProvincia.Items.Count > 0 Then
            Me.cmbProvincia.SelectedIndex = 0
         End If
         Me.cmbProvincia.Focus()
      End If

   End Sub

#Region "Eventos Buscador Clientes"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
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
            End If
         End Sub)
   End Sub
#End Region

#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
               ShowMessage("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.")
               bscCodigoCliente.Focus()
               Exit Sub
            End If

            If chbVendedor.Checked And cmbVendedor.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO Informó un Vendedor aunque activó ese Filtro.")
               cmbVendedor.Focus()
               Exit Sub
            End If

            If chbZonaGeografica.Checked And cmbZonaGeografica.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO Informó una Zona Geográfica aunque activó ese Filtro.")
               cmbZonaGeografica.Focus()
               Exit Sub
            End If

            If chbCategoria.Checked And Me.cmbCategoria.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO Informó una Categoría aunque activó ese Filtro.")
               cmbCategoria.Focus()
               Exit Sub
            End If

            If chbProvincia.Checked And cmbProvincia.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO Informó una Provincia aunque activó ese Filtro.")
               cmbProvincia.Focus()
               Exit Sub
            End If

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      bscCliente.Enabled = False
      bscCodigoCliente.Enabled = False

      btnConsultar.Focus()
   End Sub

   Private Sub RefrescarDatosGrilla()
      If _idUsuario = "" Then
         chbVendedor.Checked = False
      End If
      rbtVenActual.Checked = True

      chbCliente.Checked = False
      chbFecha.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now
      chbZonaGeografica.Checked = False
      chbCategoria.Checked = False
      chbTipoComprobante.Checked = False
      cmbGrabanLibro.SelectedIndex = 0
      optConSaldo.Checked = True
      chbExcluirSaldosNegativos.Checked = False
      chbExcluirAnticipos.Checked = False
      chbExcluirPreComprobantes.Checked = False
      chbProvincia.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False
      cmbGrupos.Refrescar()
      rbtCatActual.Checked = True

      chbExcluirMinutas.Checked = True
      rbtImpresionNormal.Checked = True

      ugDetalle.ClearFilas()

      chbAgruparIdClienteCtaCte.Checked = False

      cmbSucursal.Refrescar()

      btnConsultar.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()

      ugDetalle.Update()

      '---------------------------------------------------------------------------------------------

      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idZonaGeografica = cmbZonaGeografica.ValorSeleccionado(chbZonaGeografica, String.Empty)

      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)

      Dim desde As Date = dtpDesde.Valor(chbFecha.Checked).IfNull()
      Dim hasta As Date = dtpHasta.Valor(chbFecha.Checked).IfNull()

      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoria, 0I)
      Dim excluirSaldosNegativos = chbExcluirSaldosNegativos.ToStringEspañol()
      Dim excluirAnticipos = chbExcluirAnticipos.ToStringEspañol()
      Dim excluirPreComprobantes = chbExcluirPreComprobantes.ToStringEspañol()
      Dim idProvincia = cmbProvincia.ValorSeleccionado(chbProvincia, String.Empty)
      Dim tipoSaldo = If(Me.optTodos.Checked, "TODOS", "SOLOSALDO")
      Dim tipoCategoria = If(rbtCatMovimiento.Checked, "MOVIMIENTO", "ACTUAL")
      Dim tipoVendedor = If(rbtVenMovimiento.Checked, "MOVIMIENTO", "ACTUAL")
      Dim excluirMinutas = chbExcluirMinutas.ToStringEspañol()


      Dim tiposComprobantes = New List(Of Entidades.TipoComprobante)()

      If chbTipoComprobante.Checked Then
         tiposComprobantes.AddRange(cmbTiposComprobantes.GetTiposComprobantes())
      Else
         tiposComprobantes = Nothing
      End If

      Dim rCtaCte = New Reglas.CuentasCorrientes()
      Dim dtDetalle = rCtaCte.GetCtaCtePendientesPorProducto(
                                 actual.Sucursal.Id,
                                 desde, hasta,
                                 idVendedor, idCliente,
                                 tiposComprobantes, tipoSaldo,
                                 idZonaGeografica, idCategoria,
                                 cmbGrabanLibro.Text, cmbGrupos.GetGruposTiposComprobantes(),
                                 excluirSaldosNegativos, excluirAnticipos, excluirPreComprobantes,
                                 idProvincia, tipoCategoria, tipoVendedor, excluirMinutas,
                                 cmbSucursal.GetSucursales())


      ugDetalle.DataSource = dtDetalle
      ugDetalle.Rows.OfType(Of UltraGridRow).ToList().ForEach(Sub(dr) dr.Cells("Ver").Value = "...")

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      Dim Primero = True

      With filtro

         If cmbSucursal.Enabled Then
            cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If

         If chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} ({1}) - ", Me.cmbVendedor.Text, IIf(rbtVenActual.Checked, "Actual", "Movimiento").ToString() & ")")
         End If

         If chbFecha.Checked Then
            .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)
         End If

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         If chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If chbZonaGeografica.Checked Then
            .AppendFormat(" Zona Geografica: {0} - ", Me.cmbZonaGeografica.Text)
         End If


         cmbGrupos.CargarFiltrosImpresionTiposComprobantes(filtro, False, True)


         If cmbGrabanLibro.Text <> "TODOS" Then
            .AppendFormat(" Graban Libro: {0} - ", Me.cmbGrabanLibro.Text)
         End If

         If chbExcluirAnticipos.Checked Then
            .AppendFormat("Excluir Anticipos - ")
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            .AppendFormat("Excluir Saldos Negativos - ")
         End If

         If Me.chbExcluirPreComprobantes.Checked Then
            .AppendFormat("Excluir Pre-Comprobantes - ")
         End If

         If Me.chbAgruparIdClienteCtaCte.Checked Then
            .AppendFormat("Agrupados por Cliente de Cta. Cte. - ")
         End If

         'Minuta nunca tendria saldo solo.
         If Me.chbExcluirMinutas.Checked And Me.optTodos.Checked Then
            .AppendFormat("Excluir Minutas - ")
         End If

         If Me.chbCategoria.Checked Then
            .AppendFormat(" Categoría: {0} ({1}) - ", Me.cmbCategoria.Text, IIf(rbtCatActual.Checked, "Actual", "Movimiento"))
         End If

         If Me.chbProvincia.Checked Then
            .AppendFormat(" Provincia: {0} - ", Me.cmbProvincia.Text)
         End If

         If Me.optTodos.Checked Then
            .AppendFormat("Saldo: Todos - ")
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function

#End Region

End Class