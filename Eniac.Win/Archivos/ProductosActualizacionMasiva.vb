Public Class ProductosActualizacionMasiva

#Region "Campos"

   Private _publicos As Publicos
   Private _Productos As List(Of Entidades.Producto)
   Private _filtroMultiplesMarcas As MFMarcas
   Private _filtroMultiplesRubros As MFRubros
   Private _filtroMultiplesSubRubros As MFSubRubros
   Private _filtroMultiplesSubSubRubros As MFSubSubRubros
   Private _EmbalajeNormal As Boolean = Not Publicos.ProductoEmbalajeHaciaArriba
   Private _utilizaCentroCostos As Boolean = False
   Private Const selecColumnName As String = "Check"

   Private _tit As Dictionary(Of String, String)

   Private _SubRubroAtributo As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()
         Me._Productos = New List(Of Entidades.Producto)

         Me._filtroMultiplesSubSubRubros = New MFSubSubRubros()

         If Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbNuevoSubRubro.Visible = True
            Me.bscNuevoSubRubro.Visible = True
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = False
         End If

         If Reglas.Publicos.ProductoTieneSubSubRubro Then
            Me.lnkFiltroMultiplesSubSubRubros.Visible = True
            Me.chbNuevoSubSubRubro.Visible = True
            Me.bscNuevoSubSubRubro.Visible = True
            'Me.chbLimpiaSubSubRubro.Visible = True
            'Me.chbLimpiaSubSubRubro.Enabled = True
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubSubRubro").Hidden = False
         End If

         If Not Reglas.Publicos.TieneModuloProduccion Then
            Me.lblEsCompuesto.Visible = False
            Me.cmbEsCompuesto.Visible = False
            Me.pnlEsCompuestoNuevo.Visible = False
         End If

         If Reglas.Publicos.ProductoUtilizaProductoWeb Then
            Me.grpProductoWeb.Visible = True

            ' Me.gpNuevoProductoWeb.Visible = True
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("ValorCaracteristica1").Hidden = False
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("ValorCaracteristica2").Hidden = False
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("ValorCaracteristica3").Hidden = False

            Me.ugDetalle.DisplayLayout.Bands(0).Columns("Caracteristica1").Hidden = False
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("Caracteristica2").Hidden = False
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("Caracteristica3").Hidden = False
         Else
            Me.tbcCabecera.TabPages.Remove(Me.tbpCambiosWeb)
         End If

         Me.cmbAfectaStock.Items.Insert(0, "TODOS")
         Me.cmbAfectaStock.Items.Insert(1, "SI")
         Me.cmbAfectaStock.Items.Insert(2, "NO")
         Me.cmbAfectaStock.SelectedIndex = 0

         Me.cmbActivo.Items.Insert(0, "TODOS")
         Me.cmbActivo.Items.Insert(1, "SI")
         Me.cmbActivo.Items.Insert(2, "NO")
         Me.cmbActivo.SelectedIndex = 0

         Me.cmbEsDeCompras.Items.Insert(0, "TODOS")
         Me.cmbEsDeCompras.Items.Insert(1, "SI")
         Me.cmbEsDeCompras.Items.Insert(2, "NO")
         Me.cmbEsDeCompras.SelectedIndex = 0

         Me.cmbEsDeVentas.Items.Insert(0, "TODOS")
         Me.cmbEsDeVentas.Items.Insert(1, "SI")
         Me.cmbEsDeVentas.Items.Insert(2, "NO")
         Me.cmbEsDeVentas.SelectedIndex = 0

         Me.cmbEsDeCambio.Items.Insert(0, "TODOS")
         Me.cmbEsDeCambio.Items.Insert(1, "SI")
         Me.cmbEsDeCambio.Items.Insert(2, "NO")
         Me.cmbEsDeCambio.SelectedIndex = 0

         Me.cmbEsDeBonificacion.Items.Insert(0, "TODOS")
         Me.cmbEsDeBonificacion.Items.Insert(1, "SI")
         Me.cmbEsDeBonificacion.Items.Insert(2, "NO")
         Me.cmbEsDeBonificacion.SelectedIndex = 0

         Me.cmbEsOferta.Items.Insert(0, "TODOS")
         Me.cmbEsOferta.Items.Insert(1, "SI")
         Me.cmbEsOferta.Items.Insert(2, "NO")
         Me.cmbEsOferta.SelectedIndex = 0

         Me.cmbEsServicio.Items.Insert(0, "TODOS")
         Me.cmbEsServicio.Items.Insert(1, "SI")
         Me.cmbEsServicio.Items.Insert(2, "NO")
         Me.cmbEsServicio.SelectedIndex = 0

         Me.cmbPagaIngBrutos.Items.Insert(0, "TODOS")
         Me.cmbPagaIngBrutos.Items.Insert(1, "SI")
         Me.cmbPagaIngBrutos.Items.Insert(2, "NO")
         Me.cmbPagaIngBrutos.SelectedIndex = 0

         _publicos.CargaComboDesdeEnum(cmbEsPerceptibleIVARes53292023, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbEsPerceptibleIVARes53292023Nuevo, GetType(Entidades.Publicos.SiNo))

         Me.cmbPermiteModDesc.Items.Insert(0, "TODOS")
         Me.cmbPermiteModDesc.Items.Insert(1, "SI")
         Me.cmbPermiteModDesc.Items.Insert(2, "NO")
         Me.cmbPermiteModDesc.SelectedIndex = 0

         _publicos.CargaComboDesdeEnum(cmbPublicarEnWeb, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbPublicarEnWeb.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbPublicarEnTiendaNube, GetType(Entidades.Publicos.SiNoTodos))
         cmbPublicarEnTiendaNube.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         _publicos.CargaComboDesdeEnum(cmbPublicarEnMercadoLibre, GetType(Entidades.Publicos.SiNoTodos))
         cmbPublicarEnMercadoLibre.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         _publicos.CargaComboDesdeEnum(cmbPublicarEnArborea, GetType(Entidades.Publicos.SiNoTodos))
         cmbPublicarEnArborea.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbPublicarEnGestion, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbPublicarEnGestion.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbPublicarEnEmpresarial, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbPublicarEnEmpresarial.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbPublicarEnBalanza, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbPublicarEnBalanza.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbPublicarEnSincronizacionSucursal, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbPublicarEnSincronizacionSucursal.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbPublicarEnListaDePreciosParaClientes, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbPublicarEnListaDePreciosParaClientes.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(Me.cmbEsCompuesto, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(Me.cmbDescontarStockComponentesNuevo, GetType(Entidades.Publicos.SiNo))
         Me.cmbEsCompuesto.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         Me.cmbDescontarStockComponentesNuevo.SelectedIndex = -1

         'Me.cmbPublicarEnListaDePreciosParaClientes.Items.Insert(0, "TODOS")
         'Me.cmbPublicarEnListaDePreciosParaClientes.Items.Insert(1, "SI")
         'Me.cmbPublicarEnListaDePreciosParaClientes.Items.Insert(2, "NO")
         'Me.cmbPublicarEnListaDePreciosParaClientes.SelectedIndex = 0

         'Me.cmbPublicarEnWeb.Items.Insert(0, "TODOS")
         'Me.cmbPublicarEnWeb.Items.Insert(1, "SI")
         'Me.cmbPublicarEnWeb.Items.Insert(2, "NO")
         'Me.cmbPublicarEnWeb.SelectedIndex = 0

         Me.cmbUtilizaLote.Items.Insert(0, "TODOS")
         Me.cmbUtilizaLote.Items.Insert(1, "SI")
         Me.cmbUtilizaLote.Items.Insert(2, "NO")
         Me.cmbUtilizaLote.SelectedIndex = 0

         Me.cmbUtilizaNroSerie.Items.Insert(0, "TODOS")
         Me.cmbUtilizaNroSerie.Items.Insert(1, "SI")
         Me.cmbUtilizaNroSerie.Items.Insert(2, "NO")
         Me.cmbUtilizaNroSerie.SelectedIndex = 0

         Me.cmbActivoNuevo.Items.Insert(0, "SI")
         Me.cmbActivoNuevo.Items.Insert(1, "NO")
         Me.cmbActivoNuevo.SelectedIndex = -1

         Me.cmbAfectaStockNuevo.Items.Insert(0, "SI")
         Me.cmbAfectaStockNuevo.Items.Insert(1, "NO")
         Me.cmbAfectaStockNuevo.SelectedIndex = -1

         Me.cmbEsDeComprasNuevo.Items.Insert(0, "SI")
         Me.cmbEsDeComprasNuevo.Items.Insert(1, "NO")
         Me.cmbEsDeComprasNuevo.SelectedIndex = -1

         Me.cmbEsDeVentasNuevo.Items.Insert(0, "SI")
         Me.cmbEsDeVentasNuevo.Items.Insert(1, "NO")
         Me.cmbEsDeVentasNuevo.SelectedIndex = -1

         Me.cmbEsServicioNuevo.Items.Insert(0, "SI")
         Me.cmbEsServicioNuevo.Items.Insert(1, "NO")
         Me.cmbEsServicioNuevo.SelectedIndex = -1

         Me.cmbEsOfertaNuevo.Items.Insert(0, "SI")
         Me.cmbEsOfertaNuevo.Items.Insert(1, "NO")
         Me.cmbEsOfertaNuevo.SelectedIndex = -1

         Me.cmbEsDeCambioNuevo.Items.Insert(0, "SI")
         Me.cmbEsDeCambioNuevo.Items.Insert(1, "NO")
         Me.cmbEsDeCambioNuevo.SelectedIndex = -1

         Me.cmbEsDeBonificacionNuevo.Items.Insert(0, "SI")
         Me.cmbEsDeBonificacionNuevo.Items.Insert(1, "NO")
         Me.cmbEsDeBonificacionNuevo.SelectedIndex = -1

         Me.cmbModalidadCodigoDeBarras.Items.Add("TODOS")
         Me.cmbModalidadCodigoDeBarras.Items.Add("NO")
         Me.cmbModalidadCodigoDeBarras.Items.Add("PESO")
         Me.cmbModalidadCodigoDeBarras.Items.Add("PRECIO")
         Me.cmbModalidadCodigoDeBarras.SelectedIndex = 0

         Me.cmbModalidadCodigoDeBarrasNuevo.Items.Add("NO")
         Me.cmbModalidadCodigoDeBarrasNuevo.Items.Add("PESO")
         Me.cmbModalidadCodigoDeBarrasNuevo.Items.Add("PRECIO")
         Me.cmbModalidadCodigoDeBarrasNuevo.SelectedIndex = -1

         Me.cmbPagaIngBrutosNuevo.Items.Insert(0, "SI")
         Me.cmbPagaIngBrutosNuevo.Items.Insert(1, "NO")
         Me.cmbPagaIngBrutosNuevo.SelectedIndex = -1

         Me.cmbPermiteModDescNuevo.Items.Insert(0, "SI")
         Me.cmbPermiteModDescNuevo.Items.Insert(1, "NO")
         Me.cmbPermiteModDescNuevo.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbPublicarEnWebNuevo, GetType(Entidades.Publicos.SiNo))
         Me.cmbPublicarEnWebNuevo.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbPublicarEnTiendaNubeNuevo, GetType(Entidades.Publicos.SiNo))
         cmbPublicarEnTiendaNubeNuevo.SelectedIndex = -1
         _publicos.CargaComboDesdeEnum(cmbPublicarEnMercadoLibreNuevo, GetType(Entidades.Publicos.SiNo))
         cmbPublicarEnMercadoLibreNuevo.SelectedIndex = -1
         _publicos.CargaComboDesdeEnum(cmbPublicarEnArboreaNuevo, GetType(Entidades.Publicos.SiNo))
         cmbPublicarEnArboreaNuevo.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbPublicarEnGestionNuevo, GetType(Entidades.Publicos.SiNo))
         Me.cmbPublicarEnGestionNuevo.SelectedValue = -1

         _publicos.CargaComboDesdeEnum(cmbPublicarEnEmpresarialNuevo, GetType(Entidades.Publicos.SiNo))
         Me.cmbPublicarEnEmpresarialNuevo.SelectedValue = -1

         _publicos.CargaComboDesdeEnum(cmbPublicarEnBalanzaNuevo, GetType(Entidades.Publicos.SiNo))
         Me.cmbPublicarEnBalanzaNuevo.SelectedValue = -1

         _publicos.CargaComboDesdeEnum(cmbPublicarEnSincronizacionSucursalNuevo, GetType(Entidades.Publicos.SiNo))
         Me.cmbPublicarEnSincronizacionSucursalNuevo.SelectedValue = -1

         _publicos.CargaComboDesdeEnum(cmbPublicarEnListaDePreciosParaClientesNuevo, GetType(Entidades.Publicos.SiNo))
         Me.cmbPublicarEnListaDePreciosParaClientesNuevo.SelectedValue = -1

         'Me.cmbPublicarEnListaDePreciosParaClientesNuevo.Items.Insert(0, "SI")
         'Me.cmbPublicarEnListaDePreciosParaClientesNuevo.Items.Insert(1, "NO")
         'Me.cmbPublicarEnListaDePreciosParaClientesNuevo.SelectedIndex = -1

         'Me.cmbPublicarEnWebNuevo.Items.Insert(0, "SI")
         'Me.cmbPublicarEnWebNuevo.Items.Insert(1, "NO")
         'Me.cmbPublicarEnWebNuevo.SelectedIndex = -1

         Me.cmbUtilizaLoteNuevo.Items.Insert(0, "SI")
         Me.cmbUtilizaLoteNuevo.Items.Insert(1, "NO")
         Me.cmbUtilizaLoteNuevo.SelectedIndex = -1

         Me.cmbUtilizaNroSerieNuevo.Items.Insert(0, "SI")
         Me.cmbUtilizaNroSerieNuevo.Items.Insert(1, "NO")
         Me.cmbUtilizaNroSerieNuevo.SelectedIndex = -1

         Me._publicos.CargaComboMonedas(Me.cmbMoneda)
         Me._publicos.CargaComboMonedas(Me.cmbMonedaNueva)

         Me._publicos.CargaComboUnidadesDeMedidas(Me.cmbUnidadDeMedida)
         Me._publicos.CargaComboUnidadesDeMedidas(Me.cmbUnidadDeMedidaNuevo)

         Me._publicos.CargaComboCentroCostos(Me.cmbCentroDeCostos)
         Me._publicos.CargaComboCentroCostos(Me.cmbCentroCostosFiltro)

         Me._publicos.CargaComboImpuestos(Me.cmbAlicuotaIVANuevo)
         Me._publicos.CargaComboImpuestos(Me.cmbAlicuotaIVA2Nuevo)
         Me.cmbAlicuotaIVA2Nuevo.SelectedIndex = -1

         Me.chbAlicuotaIVA2Nuevo.Visible = Reglas.Publicos.ProductoUtilizaAlicuota2
         Me.cmbAlicuotaIVA2Nuevo.Visible = Reglas.Publicos.ProductoUtilizaAlicuota2

         Me._publicos.CargaComboImpuestos(Me.cmbAlicuotaIVA)
         Me._publicos.CargaComboImpuestos(Me.cmbAlicuotaIVA2)
         Me.cmbAlicuotaIVA2.SelectedIndex = -1

         Me.chbAlicuotaIva2.Visible = Reglas.Publicos.ProductoUtilizaAlicuota2
         Me.cmbAlicuotaIVA2.Visible = Reglas.Publicos.ProductoUtilizaAlicuota2
         Me.btnAlicuota2.Visible = Reglas.Publicos.ProductoUtilizaAlicuota2

         _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos

         cmbCentroDeCostos.Visible = _utilizaCentroCostos
         chbCentroDeCostos.Visible = _utilizaCentroCostos
         cmbCentroCostosFiltro.Visible = _utilizaCentroCostos
         chbCentroCostosFiltro.Visible = _utilizaCentroCostos


         cmbSubRubro.ConcatenarNombreRubro = True
         cmbMarca.Inicializar(False, True, True)
         cmbRubro.Inicializar(False, True, True)

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         ugDetalle.AgregarFiltroEnLinea({"NombreProducto"})

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ProductosActualizacionMasiva_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F4
            Me.tsbGuardar.PerformClick()
         Case Keys.F5
            Me.tsbRefrescar.PerformClick()
      End Select
   End Sub

   Private Sub tsbRefrescar_Click(sender As System.Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGuardar_Click(sender As System.Object, e As EventArgs) Handles tsbGuardar.Click
      ugDetalle.UpdateData()
      Try

         If Me.chbMarca.Checked And Not Me.bscMarca.Selecciono Then
            MessageBox.Show("ATENCION: Activo la Marca Nueva pero No seleccionó una.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscMarca.Focus()
            Exit Sub
         End If

         If Me.chbProveedorHabitual.Checked And Not Me.bscCodigoProveedor.Selecciono Then
            MessageBox.Show("ATENCION: Activo el Proveedor Habitual Nuevo pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If Me.chbRubro.Checked And Not Me.bscRubro.Selecciono Then
            MessageBox.Show("ATENCION: Activo el Rubro Nuevo pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscRubro.Focus()
            Exit Sub
         End If

         If Reglas.Publicos.ProductoTieneSubRubro Then
            'controlo solo si tiene habilitado el SubRubro
            If (Me.chbRubro.Checked And Me.bscRubro.Selecciono) Then
               If Not (Me.chbLimpiaSubRubro.Checked Or Me.bscNuevoSubRubro.Selecciono) Then
                  MessageBox.Show("Si va a cambiar el Rubro tiene que cambiar el SubRubro o limpiarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.bscNuevoSubRubro.Focus()
                  Exit Sub
               End If
            End If

            If Reglas.Publicos.ProductoTieneSubSubRubro Then
               'controlo solo si tiene habilitado el SubSubRubro
               If (Me.chbRubro.Checked And Me.bscRubro.Selecciono) Then
                  If Not (Me.chbLimpiaSubSubRubro.Checked Or Me.bscNuevoSubSubRubro.Selecciono) Then
                     MessageBox.Show("Si va a cambiar el Rubro tiene que cambiar el SubSubRubro o limpiarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Me.bscNuevoSubSubRubro.Focus()
                     Exit Sub
                  End If
               End If

               If (Me.chbNuevoSubRubro.Checked And Me.bscNuevoSubRubro.Selecciono) Then
                  If Not (Me.chbLimpiaSubSubRubro.Checked Or Me.bscNuevoSubSubRubro.Selecciono) Then
                     MessageBox.Show("Si va a cambiar el SubRubro tiene que cambiar el SubSubRubro o limpiarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Me.bscNuevoSubSubRubro.Focus()
                     Exit Sub
                  End If
               End If
            End If

         End If



         If Me.chbNuevoSubRubro.Checked And Not Me.bscNuevoSubRubro.Selecciono Then
            MessageBox.Show("ATENCION: Activo el SubRubro Nuevo pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscNuevoSubRubro.Focus()
            Exit Sub
         End If

         If Me.chbNuevoSubSubRubro.Checked And Not Me.bscNuevoSubSubRubro.Selecciono Then
            MessageBox.Show("ATENCION: Activo el SubSubRubro Nuevo pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscNuevoSubSubRubro.Focus()
            Exit Sub
         End If

         If Me.chbAfectaStock.Checked And Me.cmbAfectaStockNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Afecta Stock pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbAfectaStockNuevo.Focus()
            Exit Sub
         End If

         If Me.chbActivo.Checked And Me.cmbActivoNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Estado pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbActivoNuevo.Focus()
            Exit Sub
         End If

         If Me.chbEmbalaje.Checked And Integer.Parse("0" & Me.txtEmbalajeNuevo.Text) = 0 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Embalaje pero No cargó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtEmbalajeNuevo.Focus()
            Exit Sub
         End If

         If Me.chbEsDeCompras.Checked And Me.cmbEsDeComprasNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Es de Compras pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbEsDeComprasNuevo.Focus()
            Exit Sub
         End If

         If Me.chbEsDeVentas.Checked And Me.cmbEsDeVentasNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Es de Ventas pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbEsDeVentasNuevo.Focus()
            Exit Sub
         End If

         If Me.chbEsDeBonificacion.Checked And Me.cmbEsDeBonificacionNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Es de Bonificación pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbEsDeBonificacionNuevo.Focus()
            Exit Sub
         End If

         If Me.chbCodigoDeBarrasConPrecio.Checked And Me.cmbModalidadCodigoDeBarras.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Es de Código de Barras pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbModalidadCodigoDeBarras.Focus()
            Exit Sub
         End If

         If Me.chbEsDeCambio.Checked And Me.cmbEsDeCambioNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Es de Cambio pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbEsDeCambioNuevo.Focus()
            Exit Sub
         End If

         If Me.chbEsOferta.Checked And Me.cmbEsOfertaNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Es Oferta pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbEsOfertaNuevo.Focus()
            Exit Sub
         End If

         If Me.chbDescRecProductoNuevo.Checked And Me.txtDescRecProductoNuevo.Text = "" Then
            MessageBox.Show("ATENCION: Activo el Nuevo Desc/Recargo Producto pero No ingresó nada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescRecProductoNuevo.Focus()
            Exit Sub
         End If

         If Me.chbEsServicio.Checked And Me.cmbEsServicioNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Es Servicio pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbEsServicioNuevo.Focus()
            Exit Sub
         End If

         If Me.chbPagaIngBrutos.Checked And Me.cmbPagaIngBrutosNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Paga Ingresos Brutos pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbPagaIngBrutosNuevo.Focus()
            Exit Sub
         End If

         If Me.chbPermiteModificarDescripcion.Checked And Me.cmbPermiteModDescNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Permite Modificar Descripcion pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbPermiteModDescNuevo.Focus()
            Exit Sub
         End If

         If Me.chbTamano.Checked And Decimal.Parse("0" & Me.txtTamanioNuevo.Text.Trim()) > 0 And Me.cmbUnidadDeMedidaNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Tamaño. Debe elegir la Unidad de Medida si cargo el Tamaño.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbPermiteModDescNuevo.Focus()
            Exit Sub
         End If

         If Me.chbOrden.Checked And Integer.Parse("0" & Me.txtOrdenNuevo.Text) = 0 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Orden pero No cargó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtOrden.Focus()
            Exit Sub
         End If

         If Me.chbMoneda.Checked And Me.cmbMonedaNueva.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo la Nueva Moneda pero No cargó una.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMonedaNueva.Focus()
            Exit Sub
         End If

         If Me.chbPublicarEnWeb.Checked And Me.cmbPublicarEnWebNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Publicar en Web pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbPublicarEnWebNuevo.Focus()
            Exit Sub
         End If

         If Me.chbPublicarEnGestion.Checked And Me.cmbPublicarEnGestionNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Publicar en Gestión pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbPublicarEnGestionNuevo.Focus()
            Exit Sub
         End If

         If Me.chbPublicarEnEmpresarial.Checked And Me.cmbPublicarEnEmpresarialNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Publicar en Empresarial pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbPublicarEnEmpresarialNuevo.Focus()
            Exit Sub
         End If

         If Me.chbPublicarEnBalanza.Checked And Me.cmbPublicarEnBalanzaNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Publicar en Balanza pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbPublicarEnBalanzaNuevo.Focus()
            Exit Sub
         End If

         If Me.chbPublicarEnSincronizacionSucursal.Checked And Me.cmbPublicarEnSincronizacionSucursalNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Publicar en Sincronización entre Sucursales pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbPublicarEnSincronizacionSucursalNuevo.Focus()
            Exit Sub
         End If

         If Me.chbPublicarEnListaDePreciosParaClientes.Checked And Me.cmbPublicarEnListaDePreciosParaClientesNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo el Nuevo Publicar en Listas de Precios para Clientes pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbPublicarEnListaDePreciosParaClientesNuevo.Focus()
            Exit Sub
         End If

         If Me.chbCentroDeCostos.Checked And Me.cmbCentroDeCostos.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Activo Centro de Costos pero No seleccionó uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbCentroDeCostos.Focus()
            Exit Sub
         End If

         If Me.chbDescontarStockComponentes.Checked And Me.cmbDescontarStockComponentesNuevo.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Activo Desncontar Stock de Componentes pero no seleccionó uno.")
            Me.cmbDescontarStockComponentesNuevo.Focus()
            Exit Sub
         End If

         If Not Me.bscMarca.Selecciono And Not Me.bscRubro.Selecciono And Me.cmbAfectaStockNuevo.SelectedIndex = -1 And Me.cmbActivoNuevo.SelectedIndex = -1 And Integer.Parse("0" & Me.txtEmbalajeNuevo.Text) = 0 And
            Me.cmbEsServicioNuevo.SelectedIndex = -1 And Me.cmbEsDeComprasNuevo.SelectedIndex = -1 And Me.cmbEsDeVentasNuevo.SelectedIndex = -1 And
            Me.cmbPagaIngBrutosNuevo.SelectedIndex = -1 And Me.cmbPermiteModDescNuevo.SelectedIndex = -1 And Me.cmbUnidadDeMedidaNuevo.SelectedIndex = -1 And
            Not Me.chbOrden.Checked And Me.cmbMonedaNueva.SelectedIndex = -1 And cmbCentroDeCostos.SelectedIndex = -1 And cmbEsOfertaNuevo.SelectedIndex = -1 And
            cmbPublicarEnWebNuevo.SelectedIndex = -1 And cmbPublicarEnGestionNuevo.SelectedIndex = -1 And
            cmbPublicarEnEmpresarialNuevo.SelectedIndex = -1 And cmbPublicarEnBalanzaNuevo.SelectedIndex = -1 And
            cmbPublicarEnSincronizacionSucursalNuevo.SelectedIndex = -1 And cmbPublicarEnListaDePreciosParaClientesNuevo.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: No seleccionó Ninguna Caraterística a Ajustar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.bscMarca.Focus()
            Exit Sub
         End If

         If Me.chbLimpiaSubRubro.Checked And Me.chbLimpiaSubSubRubro.Checked Then
            If ShowPregunta("Esta por Limpiar el SubRubro y el SubSubRubro de los productos seleccionados, realmente desea continuar?") = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         ElseIf chbLimpiaSubRubro.Checked Then
            If ShowPregunta("Esta por Limpiar el SubRubro de los productos seleccionados, realmente desea continuar?") = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         ElseIf chbLimpiaSubSubRubro.Checked Then
            If ShowPregunta("Esta por Limpiar el SubSubRubro de los productos seleccionados, realmente desea continuar?") = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         End If
         If Me.chbAlicuotaIVA2Nuevo.Checked And Me.cmbAlicuotaIVA2Nuevo.SelectedIndex = -1 Then
            If MessageBox.Show("ATENCION: Selecciono la Alicuota IVA 2, pero no definio ninguna, de continuar quita el valor." + vbNewLine + vbNewLine + "¿ Esta seguro de continuar ? ", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
               Me.cmbCentroDeCostos.Focus()
               Exit Sub
            End If
         End If

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.Cursor = Cursors.WaitCursor

         Me.GuardarCambios()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbNuevoSubRubro_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbNuevoSubRubro.CheckedChanged
      Me.bscNuevoSubRubro.Enabled = Me.chbNuevoSubRubro.Checked

      If Reglas.Publicos.ProductoTieneSubSubRubro Then
         Me.chbNuevoSubSubRubro.Enabled = Me.chbNuevoSubRubro.Checked
         Me.chbNuevoSubSubRubro.Checked = False
         Me.chbLimpiaSubSubRubro.Checked = Not chbNuevoSubSubRubro.Checked
         'Me.chbNuevoSubRubro.Checked = Me.chbRubro.Checked
      End If

      If Not Me.chbNuevoSubRubro.Checked Then
         Me.bscNuevoSubRubro.Text = ""
         Me.chbLimpiaSubRubro.Checked = True
         'Me.chbLimpiaSubRubro.Enabled = True
      Else
         Me.bscNuevoSubRubro.Focus()
         Me.chbLimpiaSubRubro.Checked = False
         'Me.chbLimpiaSubRubro.Enabled = False
      End If
   End Sub

   Private Sub bscNuevoSubRubro_BuscadorClick() Handles bscNuevoSubRubro.BuscadorClick
      Try
         Dim oSubRubros As Reglas.SubRubros = New Reglas.SubRubros
         Me.chbNuevoSubSubRubro.Checked = False
         Me._publicos.PreparaGrillaSubRubros(Me.bscNuevoSubRubro)
         Me.bscNuevoSubRubro.Datos = oSubRubros.GetPorNombre(Integer.Parse("0" & Me.bscCodigoRubro.Text), Me.bscNuevoSubRubro.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNuevoSubRubro_BuscadorSeleccion(sender As System.Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscNuevoSubRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarSubRubro(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbNuevoSubSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevoSubSubRubro.CheckedChanged
      Me.bscNuevoSubSubRubro.Enabled = Me.chbNuevoSubSubRubro.Checked

      If Not Me.chbNuevoSubSubRubro.Checked Then
         Me.bscNuevoSubSubRubro.Text = ""
         Me.chbLimpiaSubSubRubro.Checked = True
         'Me.chbLimpiaSubSubRubro.Enabled = True
      Else
         Me.bscNuevoSubSubRubro.Focus()
         Me.chbLimpiaSubSubRubro.Checked = False
         'Me.chbLimpiaSubSubRubro.Enabled = False
      End If
   End Sub

   Private Sub bscNuevoSubSubRubro_BuscadorClick() Handles bscNuevoSubSubRubro.BuscadorClick
      Try
         If Not Me.bscNuevoSubRubro.Selecciono Then
            MessageBox.Show("Debe seleccionar un SubRubro previamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
         Dim oSubSubRubros As Reglas.SubSubRubros = New Reglas.SubSubRubros
         Me._publicos.PreparaGrillaSubSubRubros(Me.bscNuevoSubSubRubro)
         Dim idRubro As Integer = 0
         If IsNumeric(bscCodigoRubro.Text) Then idRubro = Integer.Parse(Me.bscCodigoRubro.Text)
         Dim idSubRubro As Integer = 0
         If IsNumeric(bscCodigoSubRubro.Text) Then idSubRubro = Integer.Parse(Me.bscCodigoSubRubro.Text)
         Me.bscNuevoSubSubRubro.Datos = oSubSubRubros.GetPorNombre(idRubro, idSubRubro, Me.bscNuevoSubSubRubro.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNuevoSubSubRubro_BuscadorSeleccion(sender As System.Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscNuevoSubSubRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarSubSubRubro(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbSubRubro_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      Try
         Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

         If Not Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubRubro.Items.Count > 0 Then
               Me.cmbSubRubro.SelectedIndex = 0
            End If
            Me.cmbSubRubro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, selecColumnName))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As System.Object, e As EventArgs) Handles btnConsultar.Click

      Try

         'If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
         '   MessageBox.Show("ATENCION: No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.bscCodigoCliente.Focus()
         '   Exit Sub
         'End If
         If Not String.IsNullOrWhiteSpace(bscProveedorFiltro.Text) And chbSinProveedorHabitual.Checked = True Then
            MessageBox.Show("ATENCION: Seleccionó un proveedor, y se encuentra activó el Filtro Sin Proveedor Habitual", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
         End If

         Me.Cursor = Cursors.WaitCursor

         CargaGrillaDetalle()

         Me.cmbTodos.SelectedIndex = 0

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbMarca_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbMarca.CheckedChanged

      Me.bscMarca.Enabled = Me.chbMarca.Checked

      If Not Me.chbMarca.Checked Then
         Me.bscMarca.Text = ""
      Else
         Me.bscMarca.Focus()
      End If

   End Sub

   Private Sub chbDescRecProducto_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbDescRecProducto.CheckedChanged

      Me.txtDescRecProducto.Enabled = Me.chbDescRecProducto.Checked

      If Not Me.chbDescRecProducto.Checked Then
         Me.txtDescRecProducto.Text = "0.00"
      Else
         Me.txtDescRecProducto.Focus()
      End If

   End Sub

   Private Sub chbDescRecProductoNuevo_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbDescRecProductoNuevo.CheckedChanged

      Me.txtDescRecProductoNuevo.Enabled = Me.chbDescRecProductoNuevo.Checked

      If Not Me.chbDescRecProductoNuevo.Checked Then
         Me.txtDescRecProductoNuevo.Text = "0.00"
      Else
         Me.txtDescRecProductoNuevo.Focus()
      End If

   End Sub

   Private Sub bscCodigoMarca_BuscadorClick() Handles bscCodigoMarca.BuscadorClick
      Try
         Dim oMarcas As Reglas.Marcas = New Reglas.Marcas
         Me._publicos.PreparaGrillaMarcas(Me.bscCodigoMarca)
         Me.bscCodigoMarca.Datos = oMarcas.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoMarca.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoMarca_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoMarca.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarMarca(e.FilaDevuelta)
            Me.chbRubro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscMarca_BuscadorClick() Handles bscMarca.BuscadorClick
      Try
         Dim oMarcas As Reglas.Marcas = New Reglas.Marcas
         Me._publicos.PreparaGrillaMarcas(Me.bscMarca)
         Me.bscMarca.Datos = oMarcas.GetPorNombre(Me.bscMarca.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscMarca_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscMarca.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarMarca(e.FilaDevuelta)
            Me.chbRubro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbRubro_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbRubro.CheckedChanged

      Me.bscRubro.Enabled = Me.chbRubro.Checked

      If Reglas.Publicos.ProductoTieneSubRubro Then
         Me.chbNuevoSubRubro.Enabled = Me.chbRubro.Checked
         Me.chbNuevoSubRubro.Checked = False
         'Me.chbNuevoSubRubro.Checked = Me.chbRubro.Checked
         chbLimpiaSubRubro.Checked = chbRubro.Checked
         chbLimpiaSubSubRubro.Checked = chbRubro.Checked
      End If

      If Not Me.chbRubro.Checked Then
         Me.bscRubro.Text = ""
         Me.bscNuevoSubRubro.Text = String.Empty
      Else
         Me.bscRubro.Focus()
      End If

   End Sub

   Private Sub bscCodigoRubro_BuscadorClick() Handles bscCodigoRubro.BuscadorClick
      Try
         Dim oRubros As Reglas.Rubros = New Reglas.Rubros
         Me._publicos.PreparaGrillaRubros(Me.bscCodigoRubro)
         Me.bscCodigoRubro.Datos = oRubros.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoRubro.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarRubro(e.FilaDevuelta)
            Me.chbMarca.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscRubro_BuscadorClick() Handles bscRubro.BuscadorClick
      Try
         Dim oRubros As Reglas.Rubros = New Reglas.Rubros
         Me.chbNuevoSubRubro.Checked = False
         Me.chbNuevoSubSubRubro.Checked = False
         Me._publicos.PreparaGrillaRubros(Me.bscRubro)
         Me.bscRubro.Datos = oRubros.GetPorNombre(Me.bscRubro.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarRubro(e.FilaDevuelta)
            Me.bscNuevoSubRubro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbAfectaStock_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbAfectaStock.CheckedChanged

      Me.cmbAfectaStockNuevo.Enabled = Me.chbAfectaStock.Checked

      If Not Me.chbAfectaStock.Checked Then
         Me.cmbAfectaStockNuevo.SelectedIndex = -1
      Else
         Me.cmbAfectaStockNuevo.Focus()
      End If

   End Sub

   Private Sub chbActivo_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbActivo.CheckedChanged

      Me.cmbActivoNuevo.Enabled = Me.chbActivo.Checked

      If Not Me.chbActivo.Checked Then
         Me.cmbActivoNuevo.SelectedIndex = -1
      Else
         Me.cmbActivoNuevo.Focus()
      End If

   End Sub

   Private Sub chbEmbalaje_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbEmbalaje.CheckedChanged

      Me.txtEmbalajeNuevo.Enabled = Me.chbEmbalaje.Checked

      If Not Me.chbEmbalaje.Checked Then
         Me.txtEmbalajeNuevo.Text = ""
      Else
         Me.txtEmbalajeNuevo.Focus()
      End If

   End Sub

   Private Sub chbEsDeCompras_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbEsDeCompras.CheckedChanged

      Me.cmbEsDeComprasNuevo.Enabled = Me.chbEsDeCompras.Checked

      If Not Me.chbEsDeCompras.Checked Then
         Me.cmbEsDeComprasNuevo.SelectedIndex = -1
      Else
         Me.cmbEsDeComprasNuevo.Focus()
      End If

   End Sub

   Private Sub chbEsDeVentas_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbEsDeVentas.CheckedChanged

      Me.cmbEsDeVentasNuevo.Enabled = Me.chbEsDeVentas.Checked

      If Not Me.chbEsDeVentas.Checked Then
         Me.cmbEsDeVentasNuevo.SelectedIndex = -1
      Else
         Me.cmbEsDeVentasNuevo.Focus()
      End If

   End Sub

   Private Sub chbEsOferta_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbEsOferta.CheckedChanged

      Me.cmbEsOfertaNuevo.Enabled = Me.chbEsOferta.Checked

      If Not Me.chbEsOferta.Checked Then
         Me.cmbEsOfertaNuevo.SelectedIndex = -1
      Else
         Me.cmbEsOfertaNuevo.Focus()
      End If

   End Sub

   Private Sub chbEsDeCambio_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbEsDeCambio.CheckedChanged

      Me.cmbEsDeCambioNuevo.Enabled = Me.chbEsDeCambio.Checked

      If Not Me.chbEsDeCambio.Checked Then
         Me.cmbEsDeCambioNuevo.SelectedIndex = -1
      Else
         Me.cmbEsDeCambioNuevo.Focus()
      End If

   End Sub

   Private Sub chbEsDeBonificacion_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbEsDeBonificacion.CheckedChanged

      Me.cmbEsDeBonificacionNuevo.Enabled = Me.chbEsDeBonificacion.Checked

      If Not Me.chbEsDeBonificacion.Checked Then
         Me.cmbEsDeBonificacionNuevo.SelectedIndex = -1
      Else
         Me.cmbEsDeBonificacionNuevo.Focus()
      End If

   End Sub

   Private Sub chbCodigoDeBarrasConPrecio_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbCodigoDeBarrasConPrecio.CheckedChanged

      Me.cmbModalidadCodigoDeBarrasNuevo.Enabled = Me.chbCodigoDeBarrasConPrecio.Checked

      If Not Me.chbCodigoDeBarrasConPrecio.Checked Then
         Me.cmbModalidadCodigoDeBarrasNuevo.SelectedIndex = -1
      Else
         Me.cmbModalidadCodigoDeBarrasNuevo.Focus()
      End If

   End Sub

   Private Sub chbEsServicio_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbEsServicio.CheckedChanged

      Me.cmbEsServicioNuevo.Enabled = Me.chbEsServicio.Checked

      If Not Me.chbEsServicio.Checked Then
         Me.cmbEsServicioNuevo.SelectedIndex = -1
      Else
         Me.cmbEsServicioNuevo.Focus()
      End If

   End Sub

   Private Sub chbPagaIngBrutos_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbPagaIngBrutos.CheckedChanged

      Me.cmbPagaIngBrutosNuevo.Enabled = Me.chbPagaIngBrutos.Checked

      If Not Me.chbPagaIngBrutos.Checked Then
         Me.cmbPagaIngBrutosNuevo.SelectedIndex = -1
      Else
         Me.cmbPagaIngBrutosNuevo.Focus()
      End If

   End Sub

   Private Sub chbPermiteModificarDescripcion_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbPermiteModificarDescripcion.CheckedChanged

      Me.cmbPermiteModDescNuevo.Enabled = Me.chbPermiteModificarDescripcion.Checked

      If Not Me.chbPermiteModificarDescripcion.Checked Then
         Me.cmbPermiteModDescNuevo.SelectedIndex = -1
      Else
         Me.cmbPermiteModDescNuevo.Focus()
      End If

   End Sub

   Private Sub chbTamano_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbTamano.CheckedChanged

      Me.txtTamanioNuevo.Enabled = Me.chbTamano.Checked
      Me.cmbUnidadDeMedidaNuevo.Enabled = Me.chbTamano.Checked

      If Not Me.chbTamano.Checked Then
         Me.txtTamanioNuevo.Text = "0"
      Else
         Me.txtTamanioNuevo.Focus()
      End If

   End Sub

   Private Sub chbOrden_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrden.CheckedChanged
      Me.txtOrdenNuevo.Enabled = Me.chbOrden.Checked

      If Not Me.chbOrden.Checked Then
         Me.txtOrdenNuevo.Text = ""
      Else
         Me.txtOrdenNuevo.Focus()
      End If
   End Sub

   Private Sub chbMonedaNueva_CheckedChanged(sender As Object, e As EventArgs) Handles chbMonedaNueva.CheckedChanged

      Me.cmbMonedaNueva.Enabled = Me.chbMonedaNueva.Checked

      If Not Me.chbMonedaNueva.Checked Then
         Me.cmbMonedaNueva.SelectedIndex = -1
      Else
         Me.cmbMonedaNueva.SelectedIndex = 1
         Me.cmbMonedaNueva.Focus()
      End If

   End Sub

   Private Sub chbMoneda_CheckedChanged(sender As Object, e As EventArgs) Handles chbMoneda.CheckedChanged
      Try
         Me.cmbMoneda.Enabled = Me.chbMoneda.Checked

         If Not Me.chbMoneda.Checked Then
            Me.cmbMoneda.SelectedIndex = -1
         Else
            If Me.cmbMoneda.Items.Count > 0 Then
               Me.cmbMoneda.SelectedIndex = 1
            End If
            Me.cmbMoneda.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbUnidadDeMedida_CheckedChanged(sender As Object, e As EventArgs) Handles chbUnidadDeMedida.CheckedChanged
      Try
         Me.cmbUnidadDeMedida.Enabled = Me.chbUnidadDeMedida.Checked

         If Not Me.chbUnidadDeMedida.Checked Then
            Me.cmbUnidadDeMedida.SelectedIndex = -1
         Else
            If Me.cmbUnidadDeMedida.Items.Count > 0 Then
               Me.cmbUnidadDeMedida.SelectedIndex = 1
            End If
            Me.cmbUnidadDeMedida.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProveedorHabitual_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbProveedorHabitual.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedorHabitual.Checked
      Me.bscProveedor.Enabled = Me.chbProveedorHabitual.Checked

      If Not Me.chbProveedorHabitual.Checked Then
         Me.bscCodigoProveedor.Text = ""
         Me.bscProveedor.Text = ""
         Me.bscCodigoProveedor.Tag = Nothing
         Me.bscCodigoProveedor.Tag = Nothing
         Me.bscCodigoProveedor.Selecciono = False
         Me.bscCodigoProveedor.Selecciono = False
      Else
         Me.bscCodigoProveedor.Focus()
      End If

   End Sub

   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbPublicarEnWeb_CheckedChanged(sender As Object, e As EventArgs) Handles chbPublicarEnWeb.CheckedChanged
      Try
         chbPublicarEnWeb.FiltroCheckedChanged(cmbPublicarEnWebNuevo, Entidades.Publicos.SiNoTodos.TODOS)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbPublicarEnTiendaNube_CheckedChanged(sender As Object, e As EventArgs) Handles chbPublicarEnTiendaNube.CheckedChanged
      Try
         chbPublicarEnTiendaNube.FiltroCheckedChanged(cmbPublicarEnTiendaNubeNuevo, Entidades.Publicos.SiNoTodos.TODOS)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbPublicarEnMercadoLibre_CheckedChanged(sender As Object, e As EventArgs) Handles chbPublicarEnMercadoLibre.CheckedChanged
      Try
         chbPublicarEnMercadoLibre.FiltroCheckedChanged(cmbPublicarEnMercadoLibreNuevo, Entidades.Publicos.SiNoTodos.TODOS)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPublicarEnArborea_CheckedChanged(sender As Object, e As EventArgs) Handles chbPublicarEnArborea.CheckedChanged
      Try
         chbPublicarEnArborea.FiltroCheckedChanged(cmbPublicarEnArboreaNuevo, Entidades.Publicos.SiNoTodos.TODOS)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPublicarEnGestion_CheckedChanged(sender As Object, e As EventArgs) Handles chbPublicarEnGestion.CheckedChanged
      Try
         chbPublicarEnGestion.FiltroCheckedChanged(cmbPublicarEnGestionNuevo, Entidades.Publicos.SiNoTodos.TODOS)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPublicarEnEmpresarial_CheckedChanged(sender As Object, e As EventArgs) Handles chbPublicarEnEmpresarial.CheckedChanged
      Try
         chbPublicarEnEmpresarial.FiltroCheckedChanged(cmbPublicarEnEmpresarialNuevo, Entidades.Publicos.SiNoTodos.TODOS)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPublicarEnBalanza_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbPublicarEnBalanza.CheckedChanged
      Try
         chbPublicarEnBalanza.FiltroCheckedChanged(cmbPublicarEnBalanzaNuevo, Entidades.Publicos.SiNoTodos.TODOS)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPublicarEnSincronizacionSucursal_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbPublicarEnSincronizacionSucursal.CheckedChanged
      Try
         chbPublicarEnSincronizacionSucursal.FiltroCheckedChanged(cmbPublicarEnSincronizacionSucursalNuevo, Entidades.Publicos.SiNoTodos.TODOS)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPublicarEnListaDePreciosParaClientesNuevo_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbPublicarEnListaDePreciosParaClientes.CheckedChanged
      Try
         chbPublicarEnListaDePreciosParaClientes.FiltroCheckedChanged(cmbPublicarEnListaDePreciosParaClientesNuevo, Entidades.Publicos.SiNoTodos.TODOS)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbCentroDeCostos_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroDeCostos.CheckedChanged
      Try
         cmbCentroDeCostos.Enabled = chbCentroDeCostos.Checked
         If Not chbCentroDeCostos.Checked Then
            cmbCentroDeCostos.SelectedIndex = -1
         Else
            cmbCentroDeCostos.SelectedIndex = 0
            cmbCentroDeCostos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbCentroCostosFiltro_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroCostosFiltro.CheckedChanged
      Try
         cmbCentroCostosFiltro.Enabled = chbCentroCostosFiltro.Checked
         If Not chbCentroCostosFiltro.Checked Then
            cmbCentroCostosFiltro.SelectedIndex = -1
         Else
            cmbCentroCostosFiltro.SelectedIndex = 0
            cmbCentroCostosFiltro.Focus()
         End If
      Catch ex As Exception

      End Try
   End Sub

   Private Sub chbLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbLote.CheckedChanged

      Me.cmbUtilizaLoteNuevo.Enabled = Me.chbLote.Checked

      If Not Me.chbLote.Checked Then
         Me.cmbUtilizaLoteNuevo.SelectedIndex = -1
      Else
         Me.cmbUtilizaLoteNuevo.Focus()
      End If

   End Sub

   Private Sub chbNroSerie_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroSerie.CheckedChanged
      Me.cmbUtilizaNroSerieNuevo.Enabled = Me.chbNroSerie.Checked

      If Not Me.chbLote.Checked Then
         Me.cmbUtilizaNroSerieNuevo.SelectedIndex = -1
      Else
         Me.cmbUtilizaNroSerieNuevo.Focus()
      End If

   End Sub
   Private Sub lnkFiltroMultiplesSubSubRubros_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFiltroMultiplesSubSubRubros.LinkClicked
      Try
         Me._filtroMultiplesSubSubRubros.ShowDialog()
         If Me._filtroMultiplesSubSubRubros.Filtros.Count = 0 Then
            Me.lnkFiltroMultiplesSubSubRubros.Text = "Todos los SubSubRubros"
         ElseIf Me._filtroMultiplesSubSubRubros.Filtros.Count = 1 Then
            Me.lnkFiltroMultiplesSubSubRubros.Text = Me._filtroMultiplesSubSubRubros.Filtros(0).NombreSubSubRubro
         Else
            Me.lnkFiltroMultiplesSubSubRubros.Text = "Algunos SubSubRubros"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCaracteristica1_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaracteristica1.CheckedChanged
      Me.txtCambioCaracteristica1.Enabled = Me.chbCaracteristica1.Checked

      If Not Me.chbCaracteristica1.Checked Then
         Me.txtCambioCaracteristica1.Text = ""
      Else
         Me.txtCambioCaracteristica1.Focus()
      End If
   End Sub

   Private Sub chbValorCaracteristica1_CheckedChanged(sender As Object, e As EventArgs) Handles chbValorCaracteristica1.CheckedChanged
      Me.txtCambioValorCaracteristica1.Enabled = Me.chbValorCaracteristica1.Checked

      If Not Me.chbValorCaracteristica1.Checked Then
         Me.txtCambioValorCaracteristica1.Text = ""
      Else
         Me.txtCambioValorCaracteristica1.Focus()
      End If
   End Sub

   Private Sub chbCaracteristica2_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaracteristica2.CheckedChanged
      Me.txtCambioCaracteristica2.Enabled = Me.chbCaracteristica2.Checked

      If Not Me.chbCaracteristica2.Checked Then
         Me.txtCambioCaracteristica2.Text = ""
      Else
         Me.txtCambioCaracteristica2.Focus()
      End If
   End Sub

   Private Sub chbValorCaracteristica2_CheckedChanged(sender As Object, e As EventArgs) Handles chbValorCaracteristica2.CheckedChanged
      Me.txtCambioValorCaracteristica2.Enabled = Me.chbValorCaracteristica2.Checked

      If Not Me.chbValorCaracteristica2.Checked Then
         Me.txtCambioValorCaracteristica2.Text = ""
      Else
         Me.txtCambioValorCaracteristica2.Focus()
      End If
   End Sub

   Private Sub chbCaracteristica3_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaracteristica3.CheckedChanged
      Me.txtCambioCaracteristica3.Enabled = Me.chbCaracteristica3.Checked

      If Not Me.chbCaracteristica3.Checked Then
         Me.txtCambioCaracteristica3.Text = ""
      Else
         Me.txtCambioCaracteristica3.Focus()
      End If
   End Sub

   Private Sub chbValorCaracteristica3_CheckedChanged(sender As Object, e As EventArgs) Handles chbValorCaracteristica3.CheckedChanged
      Me.txtCambioValorCaracteristica3.Enabled = Me.chbValorCaracteristica3.Checked

      If Not Me.chbValorCaracteristica3.Checked Then
         Me.txtCambioValorCaracteristica3.Text = ""
      Else
         Me.txtCambioValorCaracteristica3.Focus()
      End If
   End Sub

   Private Sub bscProveedorFiltro_BuscadorClick() Handles bscProveedorFiltro.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedorFiltro)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedorFiltro.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedorFiltro.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorFiltro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedorFiltro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedorFiltro(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarMarca(dr As DataGridViewRow)
      Me.bscCodigoMarca.Text = dr.Cells("IdMarca").Value.ToString()
      Me.bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()
   End Sub

   Private Sub CargarRubro(dr As DataGridViewRow)
      Me.bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
      Me.bscRubro.Text = dr.Cells("NombreRubro").Value.ToString()
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.txtCodigo.Text = String.Empty
      Me.txtProducto.Text = String.Empty

      Me.cmbMarca.Refrescar()
      Me.cmbRubro.Refrescar()
      Me.cmbSubRubro.Refrescar()

      If Not Me._filtroMultiplesSubSubRubros.dgvDatos.DataSource Is Nothing Then
         Me._filtroMultiplesSubSubRubros.Filtros.Clear()
         Me._filtroMultiplesSubSubRubros.dgvDatos.DataSource = Me._filtroMultiplesSubSubRubros.Filtros.ToArray()
         Me.lnkFiltroMultiplesSubSubRubros.Text = "Todos los SubSubRubros"
      End If

      Me.cmbAfectaStock.SelectedIndex = 0
      Me.cmbActivo.SelectedIndex = 0
      Me.txtEmbalaje.Text = "0"

      Me.cmbEsDeCompras.SelectedIndex = 0
      Me.cmbEsDeVentas.SelectedIndex = 0
      Me.cmbEsOferta.SelectedIndex = 0
      Me.cmbEsServicio.SelectedIndex = 0
      Me.cmbPagaIngBrutos.SelectedIndex = 0
      Me.cmbPermiteModDesc.SelectedIndex = 0

      Me.cmbUtilizaLote.SelectedIndex = 0
      Me.cmbUtilizaNroSerie.SelectedIndex = 0

      Me.cmbPublicarEnWeb.SelectedIndex = 0
      Me.cmbPublicarEnGestion.SelectedIndex = 0
      Me.cmbPublicarEnEmpresarial.SelectedIndex = 0
      Me.cmbPublicarEnBalanza.SelectedIndex = 0
      Me.cmbPublicarEnSincronizacionSucursal.SelectedIndex = 0
      Me.cmbPublicarEnListaDePreciosParaClientes.SelectedIndex = 0

      Me.chbPublicarEnWeb.Checked = False
      Me.chbPublicarEnGestion.Checked = False
      Me.chbPublicarEnEmpresarial.Checked = False
      Me.chbPublicarEnBalanza.Checked = False
      Me.chbPublicarEnSincronizacionSucursal.Checked = False
      Me.chbPublicarEnListaDePreciosParaClientes.Checked = False

      Me.chbLimpiaSubRubro.Checked = False
      Me.chbLimpiaSubSubRubro.Checked = False
      'Me.chbLimpiaSubRubro.Enabled = True
      'Me.chbLimpiaSubSubRubro.Enabled = True

      Me.txtOrden.Text = "0"

      Me.chbSubRubro.Checked = False
      Me.chbMoneda.Checked = False
      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbAfectaStock.Checked = False
      Me.chbActivo.Checked = False
      Me.chbEmbalaje.Checked = False
      Me.chbEsDeCompras.Checked = False
      Me.chbEsDeVentas.Checked = False
      Me.chbEsOferta.Checked = False
      Me.chbPuntoDePedido.Checked = False
      Me.chbStockMinimo.Checked = False
      Me.chbEsServicio.Checked = False
      Me.chbPagaIngBrutos.Checked = False
      Me.chbPermiteModificarDescripcion.Checked = False
      Me.chbTamano.Checked = False

      Me.chbNuevoSubRubro.Checked = False
      Me.bscNuevoSubRubro.Text = String.Empty
      Me.chbNuevoSubRubro.Enabled = False
      Me.chbNuevoSubSubRubro.Checked = False
      Me.bscNuevoSubSubRubro.Text = String.Empty
      Me.chbNuevoSubSubRubro.Enabled = False
      Me.chbOrden.Checked = False
      Me.chbMonedaNueva.Checked = False
      Me.chbCentroDeCostos.Checked = False
      Me.chbCentroCostosFiltro.Checked = False
      Me.chbLote.Checked = False
      Me.chbNroSerie.Checked = False
      Me.txtCaracteristica1.Text = String.Empty
      Me.txtCaracteristica2.Text = String.Empty
      Me.txtCaracteristica3.Text = String.Empty

      Me.txtCambioCaracteristica1.Text = String.Empty
      Me.txtCambioCaracteristica2.Text = String.Empty
      Me.txtCambioCaracteristica3.Text = String.Empty
      Me.txtCambioValorCaracteristica1.Text = String.Empty
      Me.txtCambioValorCaracteristica2.Text = String.Empty
      Me.txtCambioValorCaracteristica3.Text = String.Empty

      Me.chbCaracteristica1.Checked = False
      Me.chbCaracteristica2.Checked = False
      Me.chbCaracteristica3.Checked = False
      Me.chbValorCaracteristica1.Checked = False
      Me.chbValorCaracteristica2.Checked = False
      Me.chbValorCaracteristica3.Checked = False
      Me.chbSeteaCamposWeb.Checked = False
      Me.chbKilos.Checked = False
      Me.chbAlto.Checked = False
      Me.chbAncho.Checked = False
      Me.chbLargo.Checked = False

      Me.chbAlicuotaIVANuevo.Checked = False
      Me.chbAlicuotaIVA2Nuevo.Checked = False
      Me.chbAlicuotaIVA.Checked = False
      Me.chbAlicuotaIva2.Checked = False

      Me.pcbFoto2.Image = Nothing
      Me.pcbFoto3.Image = Nothing
      Me.chbLimpiaImagen2.Checked = False
      Me.chbLimpiaImagen3.Checked = False

      Me.bscProveedorFiltro.Text = String.Empty
      Me.chbProveedorHabitual.Checked = False
      Me.chbSinProveedorHabitual.Checked = False

      Me.chbDescontarStockComponentes.Checked = False
      Me.cmbEsCompuesto.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      cmbEsPerceptibleIVARes53292023.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      ugDetalle.ClearFilas()

      Me.cmbTodos.SelectedIndex = 0

      Me.tbcCabecera.SelectedTab = Me.tbpFiltros

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim Moneda As Integer = 0
      Dim CentroCosto As Integer = 0
      Dim IdProveedor As Long = 0
      Dim UM As String = String.Empty

      Dim alicuotaIva As Decimal = -1
      Dim activoFiltroAlicIva2 As Boolean
      Dim alicuotaIva2 As Decimal? = Nothing
      Dim descRecargoProducto As Decimal? = Nothing

      If Me.chbMoneda.Checked Then
         Moneda = Integer.Parse(Me.cmbMoneda.SelectedValue.ToString())
      End If

      If Me.chbCentroCostosFiltro.Checked Then
         CentroCosto = Integer.Parse(Me.cmbCentroCostosFiltro.SelectedValue.ToString())
      End If

      If Me.bscProveedorFiltro.Text.ToString() <> "" Then
         IdProveedor = Long.Parse(Me.bscProveedorFiltro.Tag.ToString())
      End If

      If Me.chbAlicuotaIVA.Checked Then
         If Me.cmbAlicuotaIVA.SelectedIndex > -1 Then
            alicuotaIva = Decimal.Parse(Me.cmbAlicuotaIVA.SelectedValue.ToString())
         End If
      End If

      If Me.chbAlicuotaIva2.Checked Then
         activoFiltroAlicIva2 = Me.chbAlicuotaIva2.Checked

         If (Me.cmbAlicuotaIVA2.SelectedIndex > -1) Then
            alicuotaIva2 = Decimal.Parse(Me.cmbAlicuotaIVA2.SelectedValue.ToString())
         End If
      End If

      If Me.chbDescRecProducto.Checked Then
         descRecargoProducto = Decimal.Parse(Me.txtDescRecProducto.Text.ToString())
      End If

      If Me.chbUnidadDeMedida.Checked Then
         UM = Me.cmbUnidadDeMedida.SelectedValue.ToString()
      End If

      Dim publicarEn As New Entidades.Filtros.ProductosPublicarEnFiltros()
      publicarEn.Web = cmbPublicarEnWeb.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.TiendaNube = cmbPublicarEnTiendaNube.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.MercadoLibre = cmbPublicarEnMercadoLibre.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.Arborea = cmbPublicarEnArborea.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.Gestion = cmbPublicarEnGestion.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.Empresarial = cmbPublicarEnEmpresarial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.Balanza = cmbPublicarEnBalanza.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.SincronizacionSucursal = cmbPublicarEnSincronizacionSucursal.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.ListaPrecioCliente = cmbPublicarEnListaDePreciosParaClientes.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()

      Dim esCompuesto As Entidades.Publicos.SiNoTodos = Me.cmbEsCompuesto.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()

      Dim rRegProductos = New Reglas.Productos()
      Dim dtDetalle = rRegProductos.GetPorFiltrosVarios(
                                       txtCodigo.Text,
                                       txtProducto.Text,
                                       cmbMarca.GetMarcas(True),
                                       cmbRubro.GetRubros(True),
                                       cmbSubRubro.GetSubRubros(True),
                                       txtEmbalaje.ValorNumericoPorDefecto(0I),
                                       descRecargoProducto,
                                       cmbAfectaStock.Text,
                                       cmbActivo.Text, cmbEsServicio.Text, cmbEsDeCompras.Text,
                                       cmbEsDeVentas.Text, cmbEsDeCambio.Text, cmbEsDeBonificacion.Text,
                                       cmbModalidadCodigoDeBarras.Text,
                                       cmbPagaIngBrutos.Text, cmbPermiteModDesc.Text,
                                       txtOrden.ValorNumericoPorDefecto(0I),
                                       Moneda,
                                       publicarEn, CentroCosto,
                                       cmbUtilizaLote.Text, cmbUtilizaNroSerie.Text,
                                       _filtroMultiplesSubSubRubros.Filtros,
                                       txtCaracteristica1.Text,
                                       txtCaracteristica2.Text,
                                       txtCaracteristica3.Text,
                                       IdProveedor,
                                       cmbEsOferta.Text,
                                       chbSinCosto.Checked,
                                       chbSinVenta.Checked,
                                       chbSinProveedorHabitual.Checked,
                                       alicuotaIva,
                                       activoFiltroAlicIva2,
                                       alicuotaIva2,
                                       esCompuesto,
                                       UM,
                                       cmbEsPerceptibleIVARes53292023.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos))

      dtDetalle.Columns.Add("Check", GetType(Boolean))
      dtDetalle.Select().All(Function(x)
                                x("Check") = False
                                Return True
                             End Function)

      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Sub GuardarCambios()

      _Productos.Clear()

      Dim IdMarca As Integer = -1
      Dim IdRubro As Integer = -1
      Dim IdSubRubro As Integer = -1
      Dim IdSubSubRubro As Integer = -1

      Dim blnAfectaStock As Boolean = Nothing
      Dim blnActivo As Boolean = Nothing
      Dim intEmbalaje As Integer = -1     '0 es Valor.
      Dim blnEsServicio As Boolean = Nothing
      Dim blnEsDeCompras As Boolean = Nothing
      Dim blnEsDeVentas As Boolean = Nothing
      Dim blnEsOferta As String = "NO"
      Dim blnEsDeCambio As Boolean = Nothing
      Dim blnEsDeBonificacion As Boolean = Nothing
      Dim descRecargoProducto As Decimal = -1
      Dim strModalidadCodigoDeBarras As String = String.Empty
      Dim blnPagaIB As Boolean = Nothing
      Dim blnPermiteModDesc As Boolean = Nothing
      Dim decTamano As Decimal = -1
      Dim intOrden As Integer = 0
      Dim intMoneda As Integer = 0
      Dim idProveedorHabitual As Long = -1

      Dim um As String = ""
      Dim unid As Entidades.UnidadDeMedida
      Dim ounid As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas
      Dim blnUtilizaLote As Boolean = Nothing
      Dim blnUtilizaNroSerie As Boolean = Nothing

      Dim CentroDeCostos As Entidades.ContabilidadCentroCosto = Nothing

      If Me.chbMarca.Checked Then
         IdMarca = Integer.Parse(Me.bscCodigoMarca.Text)
      End If

      If Me.chbProveedorHabitual.Checked Then
         idProveedorHabitual = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      If Me.chbRubro.Checked Then
         IdRubro = Integer.Parse(Me.bscCodigoRubro.Text)
      End If

      If Me.chbNuevoSubRubro.Checked Then
         IdSubRubro = Integer.Parse(Me.bscCodigoSubRubro.Text)
      End If

      If Me.chbNuevoSubSubRubro.Checked Then
         IdSubSubRubro = Integer.Parse(Me.bscCodigoSubSubRubro.Text)
      End If

      'If Me.chbNuevoSubRubro.Checked Then
      '   IdSubRubro = Integer.Parse(Me.bscNuevoSubRubro.FilaDevuelta.Cells.Item("IdSubRubro").Value.ToString())
      'End If

      If Me.chbAfectaStock.Checked Then
         blnAfectaStock = Boolean.Parse(IIf(Me.cmbAfectaStockNuevo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbActivo.Checked Then
         blnActivo = Boolean.Parse(IIf(Me.cmbActivoNuevo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbEsServicio.Checked Then
         blnEsServicio = Boolean.Parse(IIf(Me.cmbEsServicioNuevo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbEsDeCompras.Checked Then
         blnEsDeCompras = Boolean.Parse(IIf(Me.cmbEsDeComprasNuevo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbEsDeVentas.Checked Then
         blnEsDeVentas = Boolean.Parse(IIf(Me.cmbEsDeVentasNuevo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbEsOferta.Checked Then
         blnEsOferta = Me.cmbEsOfertaNuevo.Text
      End If

      If Me.chbEsDeBonificacion.Checked Then
         blnEsDeBonificacion = Boolean.Parse(IIf(Me.cmbEsDeBonificacionNuevo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbDescRecProductoNuevo.Checked Then
         descRecargoProducto = Decimal.Parse(Me.txtDescRecProductoNuevo.Text.ToString())
      End If

      If Me.chbCodigoDeBarrasConPrecio.Checked Then
         strModalidadCodigoDeBarras = Me.cmbModalidadCodigoDeBarrasNuevo.Text
      End If

      If Me.chbEsDeCambio.Checked Then
         blnEsDeCambio = Boolean.Parse(IIf(Me.cmbEsDeCambioNuevo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbPagaIngBrutos.Checked Then
         blnPagaIB = Boolean.Parse(IIf(Me.cmbPagaIngBrutosNuevo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbPermiteModificarDescripcion.Checked Then
         blnPermiteModDesc = Boolean.Parse(IIf(Me.cmbPermiteModDescNuevo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbLote.Checked Then
         blnUtilizaLote = Boolean.Parse(IIf(Me.cmbUtilizaLoteNuevo.Text = "SI", "True", "False").ToString())
      End If

      If Me.chbNroSerie.Checked Then
         blnUtilizaNroSerie = Boolean.Parse(IIf(Me.cmbUtilizaNroSerieNuevo.Text = "SI", "True", "False").ToString())
      End If

      'Dim esCompuesto As Entidades.Publicos.SiNoTodos
      If Reglas.Publicos.TieneModuloProduccion Then
         '# Si el cambio de Descontar stock de los componentes está activo, valido que todos los productos seleccionados sean Compuestos
         Dim rProductos As Reglas.Productos = New Reglas.Productos
         For Each row As DataRow In DirectCast(ugDetalle.DataSource, DataTable).Select("Check")
            If Not CBool(row("EsCompuesto")) AndAlso
               Me.chbDescontarStockComponentes.Checked Then
               Throw New Exception(String.Format("ATENCIÓN: El Producto {0} no es compuesto, por lo tanto no puede modificar el valor de 'Descontar Stock de Componentes'",
                                                 row.Field(Of String)(Entidades.Producto.Columnas.NombreProducto.ToString())))
            End If
         Next
      End If

      'If Me.chbTamano.Checked Then
      '   decTamano = Decimal.Parse(Me.txtTamanioNuevo.Text.ToString())
      '   um = Me.cmbUnidadDeMedidaNuevo.SelectedValue.ToString()
      'End If

      'If Me.chbEmbalaje.Checked Then
      '   intEmbalaje = Integer.Parse(Me.txtEmbalajeNuevo.Text)
      'End If

      Me.txtCodigo.Focus()


      DirectCast(Me.ugDetalle.DataSource, DataTable).AcceptChanges()

      Dim cantProd As Integer = 0
      Dim filas As DataRow() = DirectCast(Me.ugDetalle.DataSource, DataTable).Select("Check")
      If Me.ugDetalle.Rows.Count > 0 Then
         cantProd = filas.Count
      End If

      If cantProd = 0 Then
         Exit Sub
      End If

      If MessageBox.Show("¿ Está Seguro de cambiar datos a " & cantProd & " Producto(s) ? ", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
         Exit Sub
      End If

      Dim oProducto As Entidades.Producto

      For Each dr As UltraGridRow In ugDetalle.Rows

         If dr.Cells("Check").Value IsNot Nothing Then

            If Boolean.Parse(dr.Cells(selecColumnName).Text) Then

               oProducto = New Entidades.Producto()

               With oProducto
                  .IdProducto = dr.Cells("IdProducto").Value.ToString()
                  .IdMarca = IdMarca
                  .IdRubro = IdRubro
                  If Me.chbLimpiaSubRubro.Checked Then
                     .IdSubRubro = 0
                  Else
                     .IdSubRubro = IdSubRubro
                  End If

                  If Me.chbLimpiaSubSubRubro.Checked Then
                     .IdSubSubRubro = 0
                  Else
                     .IdSubSubRubro = IdSubSubRubro
                  End If

                  If Me.chbAfectaStock.Checked Then
                     .AfectaStock = blnAfectaStock
                  Else
                     .AfectaStock = Boolean.Parse(dr.Cells("AfectaStock").Value.ToString())
                  End If
                  If Me.chbActivo.Checked Then
                     .Activo = blnActivo
                  Else
                     .Activo = Boolean.Parse(dr.Cells("Activo").Value.ToString())
                  End If

                  If Me.chbEsServicio.Checked Then
                     .EsServicio = blnEsServicio
                  Else
                     .EsServicio = Boolean.Parse(dr.Cells("EsServicio").Value.ToString())
                  End If

                  If Me.chbEsDeCompras.Checked Then
                     .EsDeCompras = blnEsDeCompras
                  Else
                     .EsDeCompras = Boolean.Parse(dr.Cells("EsDeCompras").Value.ToString())
                  End If

                  If Me.chbEsDeVentas.Checked Then
                     .EsDeVentas = blnEsDeVentas
                  Else
                     .EsDeVentas = Boolean.Parse(dr.Cells("EsDeVentas").Value.ToString())
                  End If

                  If Me.chbEsDeCambio.Checked Then
                     .EsCambiable = blnEsDeCambio
                  Else
                     .EsCambiable = Boolean.Parse(dr.Cells("EsCambiable").Value.ToString())
                  End If

                  If Me.chbEsDeBonificacion.Checked Then
                     .EsBonificable = blnEsDeBonificacion
                  Else
                     .EsBonificable = Boolean.Parse(dr.Cells("EsBonificable").Value.ToString())
                  End If

                  If Me.chbDescRecProductoNuevo.Checked Then
                     .DescRecProducto = descRecargoProducto
                  Else
                     .DescRecProducto = Decimal.Parse(dr.Cells("DescRecProducto").Value.ToString())
                  End If

                  If Me.chbCodigoDeBarrasConPrecio.Checked Then
                     If strModalidadCodigoDeBarras = "NO" Then
                        .CodigoDeBarrasConPrecio = False
                        .ModalidadCodigoDeBarras = dr.Cells("ModalidadCodigoDeBarras").Value.ToString()
                     Else
                        .CodigoDeBarrasConPrecio = True
                        .ModalidadCodigoDeBarras = strModalidadCodigoDeBarras
                     End If
                  Else
                     .CodigoDeBarrasConPrecio = Boolean.Parse(dr.Cells("CodigoDeBarrasConPrecio").Value.ToString())
                     .ModalidadCodigoDeBarras = dr.Cells("ModalidadCodigoDeBarras").Value.ToString()
                  End If

                  If chbAlicuotaIVANuevo.Checked Then
                     .Alicuota = Decimal.Parse(cmbAlicuotaIVANuevo.SelectedValue.ToString())
                  Else
                     .Alicuota = Decimal.Parse(dr.Cells("Alicuota").Value.ToString())
                  End If

                  If chbAlicuotaIVA2Nuevo.Checked Then
                     If Me.cmbAlicuotaIVA2Nuevo.SelectedIndex = -1 Then
                        .Alicuota2 = Nothing
                     Else
                        .Alicuota2 = Decimal.Parse(cmbAlicuotaIVA2Nuevo.SelectedValue.ToString())
                     End If

                  Else
                     If Not String.IsNullOrWhiteSpace(dr.Cells("Alicuota2").Value.ToString()) Then
                        .Alicuota2 = Decimal.Parse(dr.Cells("Alicuota2").Value.ToString())
                     Else
                        .Alicuota2 = Nothing
                     End If
                  End If

                  If Me.chbEsOferta.Checked Then
                     .EsOferta = blnEsOferta
                  Else
                     .EsOferta = dr.Cells("EsOferta").Value.ToString()
                  End If

                  If chbPuntoDePedido.Checked Then
                     .PuntoDePedido = Decimal.Parse(txtPuntoDePedido.Text)
                  Else
                     .PuntoDePedido = If(IsNumeric(dr.Cells("PuntoDePedido").Value), Decimal.Parse(dr.Cells("PuntoDePedido").Value.ToString()), 0D)
                  End If

                  If chbStockMinimo.Checked Then
                     .StockMinimo = Decimal.Parse(txtStockMinimo.Text)
                  Else
                     .StockMinimo = If(IsNumeric(dr.Cells("StockMinimo").Value), Decimal.Parse(dr.Cells("StockMinimo").Value.ToString()), 0D)
                  End If

                  If Me.chbPagaIngBrutos.Checked Then
                     .PagaIngresosBrutos = blnPagaIB
                  Else
                     .PagaIngresosBrutos = Boolean.Parse(dr.Cells("PagaIngresosBrutos").Value.ToString())
                  End If

                  If chbEsPerceptibleIVARes53292023Nuevo.Checked Then
                     .EsPerceptibleIVARes53292023 = cmbEsPerceptibleIVARes53292023Nuevo.ValorSeleccionado(Of Entidades.Publicos.SiNo) = Entidades.Publicos.SiNo.SI
                  Else
                     .EsPerceptibleIVARes53292023 = Boolean.Parse(dr.Cells("EsPerceptibleIVARes53292023").Value.ToString())
                  End If

                  If Me.chbPermiteModificarDescripcion.Checked Then
                     .PermiteModificarDescripcion = blnPermiteModDesc
                  Else
                     .PermiteModificarDescripcion = Boolean.Parse(dr.Cells("PermiteModificarDescripcion").Value.ToString())
                  End If

                  .PublicarEnWeb = GetPublicarEnResuelto(chbPublicarEnWeb, cmbPublicarEnWebNuevo, dr, Entidades.Producto.Columnas.PublicarEnWeb)
                  .PublicarEnTiendaNube = GetPublicarEnResuelto(chbPublicarEnTiendaNube, cmbPublicarEnTiendaNubeNuevo, dr, Entidades.Producto.Columnas.PublicarEnTiendaNube)
                  .PublicarEnMercadoLibre = GetPublicarEnResuelto(chbPublicarEnMercadoLibre, cmbPublicarEnMercadoLibreNuevo, dr, Entidades.Producto.Columnas.PublicarEnMercadoLibre)
                  .PublicarEnArborea = GetPublicarEnResuelto(chbPublicarEnArborea, cmbPublicarEnArboreaNuevo, dr, Entidades.Producto.Columnas.PublicarEnArborea)
                  .PublicarEnGestion = GetPublicarEnResuelto(chbPublicarEnGestion, cmbPublicarEnGestionNuevo, dr, Entidades.Producto.Columnas.PublicarEnGestion)
                  .PublicarEnEmpresarial = GetPublicarEnResuelto(chbPublicarEnEmpresarial, cmbPublicarEnEmpresarialNuevo, dr, Entidades.Producto.Columnas.PublicarEnEmpresarial)
                  .PublicarEnBalanza = GetPublicarEnResuelto(chbPublicarEnBalanza, cmbPublicarEnBalanzaNuevo, dr, Entidades.Producto.Columnas.PublicarEnBalanza)
                  .PublicarEnSincronizacionSucursal = GetPublicarEnResuelto(chbPublicarEnSincronizacionSucursal, cmbPublicarEnSincronizacionSucursalNuevo, dr, Entidades.Producto.Columnas.PublicarEnSincronizacionSucursal)
                  .PublicarListaDePreciosClientes = GetPublicarEnResuelto(chbPublicarEnListaDePreciosParaClientes, cmbPublicarEnListaDePreciosParaClientesNuevo, dr, Entidades.Producto.Columnas.PublicarListaDePreciosClientes)

                  If Me.chbTamano.Checked Then
                     decTamano = Decimal.Parse(Me.txtTamanioNuevo.Text.ToString())
                     um = Me.cmbUnidadDeMedidaNuevo.SelectedValue.ToString()
                  Else
                     decTamano = -1
                     um = ""
                  End If

                  If Me.chbEmbalaje.Checked Then
                     intEmbalaje = Integer.Parse(Me.txtEmbalajeNuevo.Text)
                  Else
                     intEmbalaje = -1
                  End If

                  'Si configuro uno de los dos, veo de hacer el calculo de Kilos (si correpsonde).
                  If decTamano > 0 Or intEmbalaje > 0 Then
                     'Si no lo tiene asignado tomo el actual.
                     If decTamano = -1 And Decimal.Parse(dr.Cells("Tamano").Value.ToString()) > 0 Then
                        decTamano = Decimal.Parse(dr.Cells("Tamano").Value.ToString())
                        um = dr.Cells("IdUnidadDeMedida").Value.ToString()
                     End If
                     'Si no lo tiene asignado tomo el actual.
                     If intEmbalaje = -1 And Integer.Parse(dr.Cells("Embalaje").Value.ToString()) > 0 Then
                        intEmbalaje = Integer.Parse(dr.Cells("Embalaje").Value.ToString())
                     End If
                  End If

                  .Tamano = decTamano
                  .UnidadDeMedida.IdUnidadDeMedida = um
                  .Embalaje = intEmbalaje


                  'Solo Recalculo KILOS si tiene los 2 datos
                  If decTamano > 0 And intEmbalaje > 0 Then

                     unid = ounid.GetUno(um)

                     'Si esta en cero pudo digitarlo y se perderia
                     If unid.ConversionAKilos > 0 Then

                        If Me._EmbalajeNormal Then
                           .Kilos = decTamano * unid.ConversionAKilos * intEmbalaje
                        Else
                           .Kilos = decTamano * unid.ConversionAKilos
                        End If
                     Else
                        .Kilos = 0
                     End If
                  End If

                  'si tilda los kilos y los quiere cambiar se va a poner el valor manual y no se va a tomar en cuenta los calculos
                  If Me.chbKilos.Checked Then
                     Decimal.TryParse(Me.txtKilos.Text, .Kilos)
                  End If

                  If Me.chbAlto.Checked Then
                     Decimal.TryParse(Me.txtAlto.Text, .Alto)
                  End If

                  If Me.chbAncho.Checked Then
                     Decimal.TryParse(Me.txtAncho.Text, .Ancho)
                  End If

                  If Me.chbLargo.Checked Then
                     Decimal.TryParse(Me.txtLargo.Text, .Largo)
                  End If

                  If Me.chbOrden.Checked Then
                     intOrden = Integer.Parse(Me.txtOrdenNuevo.Text)
                     .Orden = intOrden
                  End If

                  If Me.chbMonedaNueva.Checked Then
                     intMoneda = Integer.Parse(Me.cmbMonedaNueva.SelectedValue.ToString())
                     .Moneda.IdMoneda = intMoneda
                  End If

                  If .Proveedor Is Nothing Then
                     .Proveedor = New Entidades.Proveedor()
                  End If
                  .Proveedor.IdProveedor = idProveedorHabitual

                  .ProductoProveedorHabitual = New Entidades.ProductoProveedor()
                  .ProductoProveedorHabitual.IdProveedor = idProveedorHabitual

                  If Me.chbCentroDeCostos.Checked Then
                     .CentroCosto = DirectCast(Me.cmbCentroDeCostos.SelectedItem, Entidades.ContabilidadCentroCosto)
                  End If

                  Dim Producto As Entidades.ProductoSucursal = New Reglas.ProductosSucursales().GetUno(actual.Sucursal.Id, .IdProducto)

                  '-- REQ-35653.- ----------------------------------------------------------------------------------------------------------
                  If chbNuevoSubRubro.Checked Then
                     Dim dtTieneAtributos = New Reglas.SubRubros().TieneAtributoSubRubro(IdSubRubro)
                     If dtTieneAtributos IsNot Nothing AndAlso dtTieneAtributos.Rows.Count > 0 AndAlso dtTieneAtributos.Rows(0).Field(Of Integer)("AtributoSubRubro") > 0 Then
                        If Decimal.Parse(dr.Cells("StockActual").Value.ToString()) > 0 Then
                           MessageBox.Show(String.Format("Producto ({0}) No puede tener {1}SubRubro ({2}) con Atributos",
                                                         dr.Cells("IdProducto").Value.ToString(),
                                                         Environment.NewLine, cmbSubRubro.SelectedText),
                                           Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                           Exit Sub
                        End If
                     End If
                     dtTieneAtributos = New Reglas.SubRubros().TieneAtributoSubRubro(dr.Cells("IdSubRubro").ValorAs(Of Integer))
                     If dtTieneAtributos IsNot Nothing AndAlso dtTieneAtributos.Rows.Count > 0 AndAlso dtTieneAtributos.Rows(0).Field(Of Integer)("AtributoSubRubro") > 0 Then
                        If Decimal.Parse(dr.Cells("StockActual").Value.ToString()) > 0 Then
                           MessageBox.Show(String.Format("Producto ({0}) No puede ser cambiado el SubRubro con Atributos",
                                                         dr.Cells("NombreProducto").Value.ToString().Trim()),
                                           Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                           Exit Sub
                        End If
                     End If
                  End If

                  If chbRubro.Checked And IdRubro <> dr.Cells("IdRubro").ValorAs(Of Integer) Then
                     Dim dtTieneAtributos = New Reglas.SubRubros().TieneAtributoSubRubro(dr.Cells("IdSubRubro").ValorAs(Of Integer))
                     If dtTieneAtributos IsNot Nothing AndAlso dtTieneAtributos.Rows.Count > 0 AndAlso dtTieneAtributos.Rows(0).Field(Of Integer)("AtributoSubRubro") > 0 Then
                        If Decimal.Parse(dr.Cells("StockActual").Value.ToString()) > 0 Then
                           MessageBox.Show(String.Format("Producto ({0}) No puede ser cambiado el SubRubro con Atributos",
                                                         dr.Cells("NombreProducto").Value.ToString().Trim()),
                                           Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                           Exit Sub
                        End If
                     End If
                  End If
                  '------------------------------------------------------------------------------------------------------------------------

                  If chbLote.Checked Then

                     If Producto.Stock <> 0 And (Boolean.Parse(dr.Cells("Lote").Value.ToString()) <> blnUtilizaLote) Then
                        MessageBox.Show("El producto: " & Producto.Producto.NombreProducto & " no tiene stock 0, NO se puede modicar Utiliza Lote ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                     Else
                        .Lote = blnUtilizaLote
                     End If

                  Else
                     .Lote = Boolean.Parse(dr.Cells("Lote").Value.ToString())
                  End If

                  If Me.chbNroSerie.Checked Then

                     If Producto.Stock <> 0 And (Boolean.Parse(dr.Cells("NroSerie").Value.ToString()) <> blnUtilizaNroSerie) Then
                        MessageBox.Show("El producto: " & .NombreProducto & " no tiene stock 0, no se puede modicar Utiliza Nro Serie ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                     Else
                        .NroSerie = blnUtilizaNroSerie
                     End If

                  Else
                     .NroSerie = Boolean.Parse(dr.Cells("NroSerie").Value.ToString())
                  End If

                  If Me.chbDescontarStockComponentes.Checked Then
                     .DescontarStockComponentes = If(Me.cmbDescontarStockComponentesNuevo.SelectedValue.ToString = Entidades.Publicos.SiNo.NO.ToString(), False, True)
                  End If

                  If Reglas.Publicos.ProductoUtilizaProductoWeb Then

                     .ProductosWeb = New Entidades.ProductoWeb()

                     Dim prodweb As Entidades.ProductoWeb = New Reglas.ProductosWeb().GetUno(.IdProducto, False)
                     If prodweb Is Nothing Then

                        If chbCaracteristica1.Checked Then
                           .ProductosWeb.Caracteristica1 = Me.txtCambioCaracteristica1.Text
                        End If
                        If chbCaracteristica2.Checked Then
                           .ProductosWeb.Caracteristica2 = Me.txtCambioCaracteristica2.Text
                        End If
                        If chbCaracteristica3.Checked Then
                           .ProductosWeb.Caracteristica3 = Me.txtCambioCaracteristica3.Text
                        End If
                        If chbValorCaracteristica1.Checked Then
                           .ProductosWeb.ValorCaracteristica1 = Me.txtCambioValorCaracteristica1.Text
                        End If
                        If chbValorCaracteristica2.Checked Then
                           .ProductosWeb.ValorCaracteristica2 = Me.txtCambioValorCaracteristica2.Text
                        End If
                        If chbValorCaracteristica3.Checked Then
                           .ProductosWeb.ValorCaracteristica3 = Me.txtCambioValorCaracteristica3.Text
                        End If
                     Else

                        If chbCaracteristica1.Checked Then
                           .ProductosWeb.Caracteristica1 = Me.txtCambioCaracteristica1.Text
                        Else
                           .ProductosWeb.Caracteristica1 = prodweb.Caracteristica1
                        End If

                        If chbCaracteristica2.Checked Then
                           .ProductosWeb.Caracteristica2 = Me.txtCambioCaracteristica2.Text
                        Else
                           .ProductosWeb.Caracteristica2 = prodweb.Caracteristica2
                        End If

                        If chbCaracteristica3.Checked Then
                           .ProductosWeb.Caracteristica3 = Me.txtCambioCaracteristica3.Text
                        Else
                           .ProductosWeb.Caracteristica3 = prodweb.Caracteristica3
                        End If

                        If chbValorCaracteristica1.Checked Then
                           .ProductosWeb.ValorCaracteristica1 = Me.txtCambioValorCaracteristica1.Text
                        Else
                           .ProductosWeb.ValorCaracteristica1 = prodweb.ValorCaracteristica1
                        End If

                        If chbValorCaracteristica2.Checked Then
                           .ProductosWeb.ValorCaracteristica2 = Me.txtCambioValorCaracteristica2.Text
                        Else
                           .ProductosWeb.ValorCaracteristica2 = prodweb.ValorCaracteristica2
                        End If

                        If chbValorCaracteristica3.Checked Then
                           .ProductosWeb.ValorCaracteristica3 = Me.txtCambioValorCaracteristica3.Text
                        Else
                           .ProductosWeb.ValorCaracteristica3 = prodweb.ValorCaracteristica3
                        End If

                     End If

                     If Me.chbSeteaCamposWeb.Checked Then
                        .ProductosWeb.EsParaConstructora = Me.chbEsParaConstructora.Checked
                        .ProductosWeb.EsParaCooperativaElectrica = Me.chbEsParaCooperativa.Checked
                        .ProductosWeb.EsParaIndustria = Me.chbEsParaIndustria.Checked
                        .ProductosWeb.EsParaMayorista = Me.chbEsParaMayorista.Checked
                        .ProductosWeb.EsParaMinorista = Me.chbEsParaMinorista.Checked
                     End If

                     If Me.pcbFoto2.Image IsNot Nothing Then
                        .ProductosWeb.Foto2 = Me.pcbFoto2.Image
                     End If

                     If Me.pcbFoto3.Image IsNot Nothing Then
                        .ProductosWeb.Foto3 = Me.pcbFoto3.Image
                     End If

                  End If

               End With

               Me._Productos.Add(oProducto)

            End If
         End If
      Next

      If Me._Productos.Count > 0 Then

         Dim regProductos As Reglas.Productos = New Reglas.Productos()
         Dim actualizaFoto2 As Boolean = False
         Dim actualizaFoto3 As Boolean = False

         actualizaFoto2 = Me.pcbFoto2.Image IsNot Nothing Or Me.chbLimpiaImagen2.Checked
         actualizaFoto3 = Me.pcbFoto3.Image IsNot Nothing Or Me.chbLimpiaImagen3.Checked

         regProductos.ActualizacionMasiva(Me._Productos, Me.chbAlto.Checked, Me.chbAncho.Checked, Me.chbLargo.Checked, Me.chbSeteaCamposWeb.Checked, actualizaFoto2, actualizaFoto3, Me.chbKilos.Checked)

         MessageBox.Show("Se Cambió Exitosamente " & Me._Productos.Count.ToString() & " Producto(s) !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Me.tbcCabecera.SelectedTab = Me.tbpFiltros
         Me.btnConsultar.PerformClick()

      Else
         MessageBox.Show("ATENCION: No Marcó Ningún Producto !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If

   End Sub

   Private Function GetPublicarEnResuelto(chb As CheckBox, cmb As ComboBox, dr As UltraGridRow, columna As Entidades.Producto.Columnas) As Boolean
      If chb.Checked Then
         Return cmb.ValorSeleccionado(Of Entidades.Publicos.SiNo)() = Entidades.Publicos.SiNo.SI
      Else
         Return Boolean.Parse(dr.Cells(columna.ToString()).Value.ToString())
      End If

   End Function

   Private Sub CargarSubRubro(dr As DataGridViewRow)
      Me.bscCodigoSubRubro.Text = dr.Cells("IdSubRubro").Value.ToString()
      Me.bscNuevoSubRubro.Text = dr.Cells("NombreSubRubro").Value.ToString()

      _SubRubroAtributo = If(Integer.Parse(dr.Cells("Atributos").Value.ToString()) > 0, True, False)

   End Sub

   Private Sub CargarSubSubRubro(dr As DataGridViewRow)
      Me.bscCodigoSubSubRubro.Text = dr.Cells("IdSubSubRubro").Value.ToString()
      Me.bscNuevoSubSubRubro.Text = dr.Cells("NombreSubSubRubro").Value.ToString()
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      Me.bscCodigoProveedor.Selecciono = True
      Me.bscProveedor.Selecciono = True
   End Sub
   Private Sub CargarDatosProveedorFiltro(dr As DataGridViewRow)
      Me.bscProveedorFiltro.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscProveedorFiltro.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedorFiltro.Selecciono = True
   End Sub
#End Region

   Private Sub chbKilos_CheckedChanged(sender As Object, e As EventArgs) Handles chbKilos.CheckedChanged
      Try
         Me.txtKilos.Enabled = Me.chbKilos.Checked

         If Not Me.chbKilos.Checked Then
            Me.txtKilos.Text = "0.000"
         Else
            Me.txtKilos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAlto_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlto.CheckedChanged
      Try
         Me.txtAlto.Enabled = Me.chbAlto.Checked

         If Not Me.chbAlto.Checked Then
            Me.txtAlto.Text = "0.000"
         Else
            Me.txtAlto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbStockMinimo_CheckedChanged(sender As Object, e As EventArgs) Handles chbStockMinimo.CheckedChanged
      Try
         Me.txtStockMinimo.Enabled = Me.chbStockMinimo.Checked

         If Not Me.chbStockMinimo.Checked Then
            Me.txtStockMinimo.Text = "0.000"
         Else
            Me.txtStockMinimo.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbPuntoDePedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbPuntoDePedido.CheckedChanged
      Try
         Me.txtPuntoDePedido.Enabled = Me.chbPuntoDePedido.Checked

         If Not Me.chbPuntoDePedido.Checked Then
            Me.txtPuntoDePedido.Text = "0.000"
         Else
            Me.txtPuntoDePedido.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAncho_CheckedChanged(sender As Object, e As EventArgs) Handles chbAncho.CheckedChanged
      Try
         Me.txtAncho.Enabled = Me.chbAncho.Checked

         If Not Me.chbAncho.Checked Then
            Me.txtAncho.Text = "0.000"
         Else
            Me.txtAncho.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbLargo_CheckedChanged(sender As Object, e As EventArgs) Handles chbLargo.CheckedChanged
      Try
         Me.txtLargo.Enabled = Me.chbLargo.Checked

         If Not Me.chbLargo.Checked Then
            Me.txtLargo.Text = "0.000"
         Else
            Me.txtLargo.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub


   Private Sub chbSeteaCamposWeb_CheckedChanged(sender As Object, e As EventArgs) Handles chbSeteaCamposWeb.CheckedChanged
      Try
         Me.grbCamposWebPara.Enabled = Me.chbSeteaCamposWeb.Checked

         Me.chbEsParaConstructora.Checked = False
         Me.chbEsParaCooperativa.Checked = False
         Me.chbEsParaIndustria.Checked = False
         Me.chbEsParaMayorista.Checked = False
         Me.chbEsParaMinorista.Checked = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnBuscarImagen2_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen2.Click
      Try
         If Me.ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.ofdArchivos.FileName) Then
               If System.IO.File.ReadAllBytes(Me.ofdArchivos.FileName).Length > Reglas.Publicos.TamañoMaximoImagenes Then
                  MessageBox.Show("El tamaño de la imagen no puede ser mayor a " + (Reglas.Publicos.TamañoMaximoImagenes / 1000).ToString() + "KB", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Me.pcbFoto2.Image = New System.Drawing.Bitmap(Me.ofdArchivos.FileName)
               ' DirectCast(Me._entidad, Entidades.Producto).ProductosWeb.Foto2 = Me.pcbFoto2.Image
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiarImagen2_Click(sender As Object, e As EventArgs) Handles btnLimpiarImagen2.Click
      Try
         Me.pcbFoto2.Image = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscarImagen3_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen3.Click
      Try
         If Me.ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.ofdArchivos.FileName) Then
               If System.IO.File.ReadAllBytes(Me.ofdArchivos.FileName).Length > Reglas.Publicos.TamañoMaximoImagenes Then
                  MessageBox.Show("El tamaño de la imagen no puede ser mayor a " + (Reglas.Publicos.TamañoMaximoImagenes / 1000).ToString() + "KB", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Me.pcbFoto3.Image = New System.Drawing.Bitmap(Me.ofdArchivos.FileName)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiarImagen3_Click(sender As Object, e As EventArgs) Handles btnLimpiarImagen3.Click
      Try
         Me.pcbFoto3.Image = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbLimpiaImagen2_CheckedChanged(sender As Object, e As EventArgs) Handles chbLimpiaImagen2.CheckedChanged
      Try
         Me.pcbFoto2.Image = Nothing
         Me.btnBuscarImagen2.Enabled = Not Me.chbLimpiaImagen2.Checked
         Me.btnLimpiarImagen2.Enabled = Not Me.chbLimpiaImagen2.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbLimpiaImagen3_CheckedChanged(sender As Object, e As EventArgs) Handles chbLimpiaImagen3.CheckedChanged
      Try
         Me.pcbFoto3.Image = Nothing
         Me.btnBuscarImagen3.Enabled = Not Me.chbLimpiaImagen3.Checked
         Me.btnLimpiarImagen3.Enabled = Not Me.chbLimpiaImagen3.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAlicuotaIVANuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlicuotaIVANuevo.CheckedChanged

      Me.cmbAlicuotaIVANuevo.Enabled = Me.chbAlicuotaIVANuevo.Checked

      If Not Me.chbAlicuotaIVANuevo.Checked Then
         Me.cmbAlicuotaIVANuevo.SelectedIndex = -1
      Else
         cmbAlicuotaIVANuevo.SelectedValue = Reglas.Publicos.ProductoIVA
         Me.cmbAlicuotaIVANuevo.Focus()
      End If
   End Sub
   Private Sub chbAlicuotaIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlicuotaIVA.CheckedChanged

      Me.cmbAlicuotaIVA.Enabled = Me.chbAlicuotaIVA.Checked

      If Not Me.chbAlicuotaIVA.Checked Then
         Me.cmbAlicuotaIVA.SelectedIndex = -1
      Else
         cmbAlicuotaIVA.SelectedValue = Reglas.Publicos.ProductoIVA
         Me.cmbAlicuotaIVA.Focus()
      End If
   End Sub
   Private Sub chbAlicuotaIVA2Nuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlicuotaIVA2Nuevo.CheckedChanged

      Me.cmbAlicuotaIVA2Nuevo.Enabled = Me.chbAlicuotaIVA2Nuevo.Checked

      If Not Me.chbAlicuotaIVA2Nuevo.Checked Then
         Me.cmbAlicuotaIVA2Nuevo.SelectedIndex = -1
         Me.btnRefrescarAlicuota2.Enabled = False
      Else
         Me.cmbAlicuotaIVA2Nuevo.SelectedIndex = -1
         Me.btnRefrescarAlicuota2.Enabled = True
         Me.cmbAlicuotaIVA2Nuevo.Focus()
      End If
   End Sub
   Private Sub chbAlicuotaIVA2_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlicuotaIva2.CheckedChanged

      Me.cmbAlicuotaIVA2.Enabled = Me.chbAlicuotaIva2.Checked

      If Not Me.chbAlicuotaIva2.Checked Then
         Me.cmbAlicuotaIVA2.SelectedIndex = -1
         Me.btnAlicuota2.Enabled = False
      Else
         Me.cmbAlicuotaIVA2.SelectedIndex = -1
         Me.btnAlicuota2.Enabled = True
         Me.cmbAlicuotaIVA2.Focus()
      End If
   End Sub
   Private Sub btnRefrescarObj_Click(sender As Object, e As EventArgs) Handles btnRefrescarAlicuota2.Click
      Me.cmbAlicuotaIVA2Nuevo.SelectedIndex = -1
   End Sub

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         If cmbRubro.SelectedIndex > -1 Then
            Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros()
            cmbSubRubro.Inicializar(True, True, True, rubros)
         End If
         cmbSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnAlicuota2_Click(sender As Object, e As EventArgs) Handles btnAlicuota2.Click
      Me.cmbAlicuotaIVA2.SelectedIndex = -1
   End Sub

   Private Sub chbDescontarStockComponentes_CheckedChanged(sender As Object, e As EventArgs) Handles chbDescontarStockComponentes.CheckedChanged
      Try
         Me.cmbDescontarStockComponentesNuevo.Enabled = Me.chbDescontarStockComponentes.Checked
         If Not Me.chbDescontarStockComponentes.Checked Then
            Me.cmbDescontarStockComponentesNuevo.SelectedIndex = -1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbEsPerceptibleIVARes53292023Nuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsPerceptibleIVARes53292023Nuevo.CheckedChanged
      TryCatched(Sub() chbEsPerceptibleIVARes53292023Nuevo.FiltroCheckedChanged(cmbEsPerceptibleIVARes53292023Nuevo))
   End Sub
End Class