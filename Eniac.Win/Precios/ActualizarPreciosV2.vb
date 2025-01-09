Public Class ActualizarPreciosV2

#Region "Campos"

   Private _publicos As Publicos
   Private _precios As List(Of Entidades.ProductoSucursal)
   Private _listas As List(Of Entidades.ListaDePrecios)
   Private _listasSelec As List(Of Entidades.ListaDePrecios)

   '-- REQ-32570.- ---------------------------------------------------------
   Private _decimalesEnPrecio As Integer
   Private _formatoEnPrecio As String
   Private _ceroFormateado As String
   '------------------------------------------------------------------------

   Private _ColorColumnasEditables As Color = System.Drawing.Color.FromArgb(224, 224, 224)
   Private _estacargando As Boolean = False
   Private _calcular As Boolean = False
   Private _compuesto As Compuesto = Compuesto.TODOS
   Private _buscaYCalcula As Boolean = False
   Private _actualizarPreciosMostrarCodigoProductoProveedor As Boolean

   Private _actualizarPreciosCalculo As String
   Private _cargandoAutomaticamentePorcentajes As Boolean = False
   Private _cambiando As Boolean = False

   Private _calcula As Boolean = False '-.PE-32502.-

   Private _dicListasPrecios As Dictionary(Of Integer, DataRow)

   Private _cache As Reglas.BusquedasCacheadas

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
      _decimalesEnPrecio = Reglas.Publicos.PreciosDecimalesEnVenta
      _formatoEnPrecio = String.Concat("N", _decimalesEnPrecio)
      _ceroFormateado = 0.ToString(_formatoEnPrecio)
   End Sub

   Public Sub New(compuesto As Compuesto, buscaYCalculaAutomaticamente As Boolean)
      Me.New()
      _compuesto = compuesto
      rdbCostoDesdeFormula.Checked = True
      _buscaYCalcula = buscaYCalculaAutomaticamente
   End Sub

#End Region

   Public Enum Compuesto
      TODOS
      SI
      NO
   End Enum

   Private Enum ComoCalcular
      PorcActual
      SobreVenta
      SobreCosto
      DesdeFormula
   End Enum

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         _publicos = New Publicos()

         _cache = New Reglas.BusquedasCacheadas()
         _cacheNombresColumnas = New Dictionary(Of Integer, NombresColumnas)()

         _actualizarPreciosCalculo = Publicos.ActualizarPreciosCalculo
         If _comprasProductos IsNot Nothing Then
            _actualizarPreciosCalculo = Reglas.Publicos.ActualizarPreciosCalculoDesdeCompras
            ShowInTaskbar = False
         End If

         Me.CargarSucursales()

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))
         _publicos.CargaComboDesdeEnum(Me.cmbTodosListas, GetType(Reglas.Publicos.TodosEnumSI))

         '-- REQ-36403.- ----
         _publicos.CargaComboDesdeEnum(cmbConStock, GetType(Entidades.Publicos.SiNoTodos))
         '-------------------
         _actualizarPreciosMostrarCodigoProductoProveedor = Reglas.Publicos.ActualizarPreciosMostrarCodigoProductoProveedor

         CargaSeleccionListasDePrecios()

         cboCompuestos.Items.Insert(0, Compuesto.TODOS.ToString())
         cboCompuestos.Items.Insert(1, Compuesto.SI.ToString())
         cboCompuestos.Items.Insert(2, Compuesto.NO.ToString())

         cmbRubro.Inicializar(False, True, True)
         cmbMarca.Inicializar(False, True, True)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         Me.chbSubSubRubro.Visible = Reglas.Publicos.ProductoTieneSubSubRubro
         Me.cmbSubSubRubro.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         Me.cboCompuestos.Text = Me._compuesto.ToString()

         Me.cmbEsOferta.SelectedIndex = 0

         If Not Reglas.Publicos.TieneModuloProduccion Then
            Me.lblCompuestos.Visible = False
            Me.cboCompuestos.Visible = False
            Me.rdbCostoSiMismo.Visible = False
            Me.rdbCostoDesdeFormula.Visible = False
         End If

         tbcDetalle.SelectedTab = TbpCalcular
         tbcDetalle.SelectedTab = TbpFiltros

         Me.tsbGrabar.Enabled = False
         Me.tsbImportarExcel.Enabled = False

         If Reglas.Publicos.UtilizaPrecioDeCompra Then
            Me.grbPrecioCompra.Show()
         Else
            Me.grbPrecioCompra.Hide()
            Me.rdbCostoFabrica.Visible = False
         End If

         If rdbCostoFabrica.Visible = False And rdbCostoDesdeFormula.Visible = False Then
            Me.rdbCostoSiMismo.Visible = True
         End If

         '-- REQ-32570.- ------------------------------------------------------------
         txtPrecioCostoPorc.Formato = _ceroFormateado
         txtPrecioCostoPorc.Text = _ceroFormateado
         txtPrecioCostoMonto.Formato = _ceroFormateado
         txtPrecioCostoMonto.Text = _ceroFormateado
         txtPorcenFabrica.Formato = _ceroFormateado
         txtPorcenFabrica.Text = _ceroFormateado

         txtRedondeoPrecioVenta.Text = _decimalesEnPrecio.ToString()
         '---------------------------------------------------------------------------

         txtCodigoProductoProveedor.Visible = _actualizarPreciosMostrarCodigoProductoProveedor
         txtCodigoProductoProveedor.LabelAsoc.Visible = txtCodigoProductoProveedor.Visible

         lblDescuentoRecargoPorc1.Visible = Reglas.Publicos.UtilizaPrecioDeCompra
         txtDescuentoRecargoPorc1.Visible = lblDescuentoRecargoPorc1.Visible
         btnDescuentoRecargoPorc1.Visible = lblDescuentoRecargoPorc1.Visible

         lblDescuentoRecargoPorc2.Visible = lblDescuentoRecargoPorc1.Visible
         txtDescuentoRecargoPorc2.Visible = lblDescuentoRecargoPorc1.Visible
         btnDescuentoRecargoPorc2.Visible = lblDescuentoRecargoPorc1.Visible

         lblDescuentoRecargoPorc3.Visible = lblDescuentoRecargoPorc1.Visible
         txtDescuentoRecargoPorc3.Visible = lblDescuentoRecargoPorc1.Visible
         btnDescuentoRecargoPorc3.Visible = lblDescuentoRecargoPorc1.Visible

         lblDescuentoRecargoPorc4.Visible = lblDescuentoRecargoPorc1.Visible
         txtDescuentoRecargoPorc4.Visible = lblDescuentoRecargoPorc1.Visible
         btnDescuentoRecargoPorc4.Visible = lblDescuentoRecargoPorc1.Visible

         lblDescuentoRecargoPorc5.Visible = False ' lblDescuentoRecargoPorc1.Visible - No tenemos implementado aún el descuento 5
         txtDescuentoRecargoPorc5.Visible = False ' lblDescuentoRecargoPorc1.Visible - No tenemos implementado aún el descuento 5
         btnDescuentoRecargoPorc5.Visible = False ' lblDescuentoRecargoPorc1.Visible - No tenemos implementado aún el descuento 5

         lblDescuentoRecargoPorc6.Visible = False ' lblDescuentoRecargoPorc1.Visible - No tenemos implementado aún el descuento 6
         txtDescuentoRecargoPorc6.Visible = False ' lblDescuentoRecargoPorc1.Visible - No tenemos implementado aún el descuento 6
         btnDescuentoRecargoPorc6.Visible = False ' lblDescuentoRecargoPorc1.Visible - No tenemos implementado aún el descuento 6

         If _comprasProductos IsNot Nothing Then
            txtCodigo.Enabled = False
            txtProducto.Enabled = False
            txtProducto.Text = "Varios Productos"
            CargaGrillaDetalle()
            tbcDetalle.SelectedTab = TbpCalcular
            btnCalcular.PerformClick()
         End If

         Me._publicos.CargaComboMonedas(Me.cmbMoneda)
         Me.chbMoneda.Checked = False
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      If Me._buscaYCalcula Then
         Me.tsbImportarExcel.Visible = False
         Me.tsbRefrescar.Visible = False
         Me.ToolStripSeparator1.Visible = False
         Me.ToolStripSeparator4.Visible = False
         Me.btnBuscar.PerformClick()
         Me.tbcDetalle.SelectedTab = Me.TbpCalcular
         Me.btnCalcular.PerformClick()
      End If
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         tsbGrabar.PerformClick()
      ElseIf keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F8 Then
         If btnCalcular.Enabled Then
            tbcDetalle.SelectedTab = TbpCalcular
            btnCalcular.PerformClick()
         End If
      ElseIf keyData = Keys.F11 Then
         tbcDetalle.SelectedTab = TbpFiltros
         btnBuscar.Focus()
      ElseIf keyData = Keys.F12 Then
         tbcDetalle.SelectedTab = TbpCalcular
         btnCalcular.Focus()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   'Private Sub ActualizarPrecios_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
   '   Select Case e.KeyCode
   '      Case Keys.F4
   '         If Me.tsbGrabar.Enabled Then
   '            Me.tsbGrabar.PerformClick()
   '         End If
   '      Case Keys.F5
   '         If Me.tsbRefrescar.Visible Then
   '            Me.tsbRefrescar.PerformClick()
   '         End If
   '      Case Keys.F8
   '         If Me.btnCalcular.Enabled Then
   '            Me.tbcDetalle.SelectedTab = Me.TbpCalcular
   '            Me.btnCalcular.PerformClick()
   '         End If
   '      Case Keys.F11
   '         Me.tbcDetalle.SelectedTab = Me.TbpFiltros
   '         Me.btnBuscar.Focus()
   '      Case Keys.F12
   '         Me.tbcDetalle.SelectedTab = Me.TbpCalcular
   '         Me.btnCalcular.Focus()
   '   End Select
   'End Sub

   Private Sub ActualizarPrecios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
      Try
         If Me.tsbGrabar.Enabled Then
            If MessageBox.Show("¿ Sale sin Grabar los cambios ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               e.Cancel = True
               Exit Sub
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.RefrescarDatos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tssRegistros.Text = "0 Registros"
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         If MessageBox.Show("Usted esta por actualizar los precios de los productos. ¿Esta seguro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.BarraInicializa("Preparando grabación de datos...", 0, Me.ugPrecios.Rows.Count)

            Me.Cursor = Cursors.WaitCursor

            Me.ugPrecios.UpdateData()

            Me.CargarYGrabarPrecios2()
         End If
         If Me._buscaYCalcula Then
            Me.Close()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.BarraFinaliza()
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ugPrecios_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugPrecios.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim cols = dr.Field(Of List(Of String))("___ColumnasActualizadasPorImportacion")
            If cols IsNot Nothing Then
               For Each col In cols
                  If ugPrecios.DisplayLayout.Bands(0).Columns.Exists(col) Then
                     e.Row.Cells(col).Color(foreColor:=Color.Black, backColor:=Color.Cyan)
                  End If
               Next
            End If
         End If
      End Sub)
   End Sub

   Private Sub AddColumnToColumnasActualizadasPorImportacion(cols As List(Of String), key As String)
      If Not cols.Contains(key) Then
         cols.Add(key)
      End If
   End Sub
   Private Function GetColumnToColumnasActualizadasPorImportacion(drPrecio As DataRow) As List(Of String)
      If drPrecio("___ColumnasActualizadasPorImportacion") Is DBNull.Value Then
         drPrecio("___ColumnasActualizadasPorImportacion") = New List(Of String)()
      End If
      Return drPrecio.Field(Of List(Of String))("___ColumnasActualizadasPorImportacion")
   End Function
   Private Sub tsbImportarExcel_Click(sender As Object, e As EventArgs) Handles tsbImportarExcel.Click
      TryCatched(
      Sub()
         Using fPre = New ImportarPreciosExcel(_listas)
            If fPre.ShowDialog() = DialogResult.Cancel Then
               Exit Sub
            End If

            Dim nc = GetNombresColumnas(fPre.IdListaDePrecios)

            Dim dtPrecios = ugPrecios.DataSource(Of DataTable)

            Dim grp = dtPrecios.AsEnumerable().GroupBy(Function(dr1) dr1.Field(Of String)("IdProductoSinEspacios").ToUpper())

            Dim dic = grp.ToDictionary(Function(grp1) grp1.Key)

            Dim contador = 0I
            Dim currentImportado = 0I
            Dim totalImportado = fPre.Precios.Count()
            For Each drImportado In fPre.Precios.AsEnumerable()
               currentImportado += 1
               Dim idProducto = drImportado.Field(Of String)(Reglas.ImportarPreciosExcel.IdProductoColumnName).ToUpper()
               Dim nombreProducto = drImportado.Field(Of String)(Reglas.ImportarPreciosExcel.NombreProductoColumnName)

               If dic.Keys.Contains(idProducto) Then
                  Dim drPrecioCol = dic(idProducto)
                  For Each drPrecio In drPrecioCol
                     Dim ___ColumnasActualizadasPorImportacion = GetColumnToColumnasActualizadasPorImportacion(drPrecio)
                     AddColumnToColumnasActualizadasPorImportacion(___ColumnasActualizadasPorImportacion, "IdProducto")
                     AddColumnToColumnasActualizadasPorImportacion(___ColumnasActualizadasPorImportacion, "NombreProducto")

                     Dim precioCosto = drPrecio.Field(Of Decimal?)("PrecioCostoNuevo").IfNull()
                     Dim precioCostoCalculado = drImportado.Field(Of Decimal?)(Reglas.ImportarPreciosExcel.PrecioCostoCalculadoColumnName)
                     If precioCostoCalculado.HasValue Then
                        drPrecio("PrecioCostoNuevo") = precioCostoCalculado.Value
                        AddColumnToColumnasActualizadasPorImportacion(___ColumnasActualizadasPorImportacion, "PrecioCostoNuevo")
                     End If
                     Dim precioCostoNuevo = drPrecio.Field(Of Decimal?)("PrecioCostoNuevo").IfNull()

                     Dim precioVentaCalculado = drImportado.Field(Of Decimal?)(Reglas.ImportarPreciosExcel.PrecioVentaCalculadoColumnName)
                     If precioVentaCalculado.HasValue Then
                        drPrecio(nc.ColumnaPrecioNuevo) = precioVentaCalculado.Value
                        AddColumnToColumnasActualizadasPorImportacion(___ColumnasActualizadasPorImportacion, nc.ColumnaPrecioNuevo)
                     Else
                        Dim precioVenta = drPrecio.Field(Of Decimal?)(nc.ColumnaPrecioNuevo).IfNull()
                        Dim porcRecargo = drPrecio.Field(Of Decimal?)(nc.ColumnaPorcNuevo).IfNull()

                        drPrecio(nc.ColumnaPrecioNuevo) = GetPrecioVentaNuevo(idProducto,
                                                            precioCosto, precioCostoNuevo,
                                                            precioVenta, fPre.IdListaDePrecios,
                                                            GetComoCalcular(drPrecio), porcRecargo, 0)
                     End If

                     contador += 1
                  Next           'For Each drPrecio In drPrecioCol
               End If
               tssProcesoImportacion.Text = String.Format("Procesando {0}/{1} ({2} - {3})",
                                                       currentImportado, totalImportado, idProducto, nombreProducto)
               Application.DoEvents()
            Next                 'For Each drImportado In fPre.Precios.AsEnumerable()
            ShowMessage(String.Format("Proceso Finalizado, Cantidad de Precios Ajustados: {0}", contador))
            tssProcesoImportacion.Text = String.Empty
         End Using
      End Sub)
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugPrecios, tsbPreferencias))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      Try
         Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

         '# Cargo los SubRubros según los rubros seleccionados
         Me.cmbSubRubro.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, cmbRubro.GetRubros(True))
         Me.chbSubSubRubro.Enabled = Me.chbSubRubro.Checked

         If Not Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubRubro.Items.Count > 0 Then
               Me.cmbSubRubro.SelectedIndex = 0
            End If
            Me.cmbSubRubro.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbSubSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubSubRubro.CheckedChanged
      Try
         Me.cmbSubSubRubro.Enabled = Me.chbSubSubRubro.Checked

         '# Cargo los SubSubRubros según los SubRubros seleccionados
         Me.cmbSubSubRubro.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, cmbSubRubro.GetSubRubros(True))

         If Not Me.chbSubSubRubro.Checked Then
            Me.cmbSubSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubSubRubro.Items.Count > 0 Then
               Me.cmbSubSubRubro.SelectedIndex = 0
            End If
            Me.cmbSubSubRubro.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked
      Me.chbProveedorHabitual.Enabled = False
      Me.chbProveedorHabitual.Checked = False
      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      If Me.chbProveedor.Checked Then
         Me.bscCodigoProveedor.Focus()
      End If

   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      Try
         Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
         Me.bscProducto2.Enabled = Me.chbProducto.Checked
         If Me.chbProducto.Checked Then
            bscCodigoProducto2.Focus()
         End If
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaActualizado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaActualizado.CheckedChanged
      Try
         Me.dtpDesde.Enabled = Me.chbFechaActualizado.Checked
         Me.dtpHasta.Enabled = Me.chbFechaActualizado.Checked
         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
         If Me.chbFechaActualizado.Checked Then
            Me.dtpDesde.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbPorcActual_CheckedChanged(sender As Object, e As EventArgs) Handles chbSobreVenta.CheckedChanged, chbSobreCosto.CheckedChanged, chbPorcActual.CheckedChanged, chbDesdeFormula.CheckedChanged
      Try
         If Not _cambiando Then
            Try
               _cambiando = True

               If Not sender.Equals(chbPorcActual) Then chbPorcActual.Checked = False
               If Not sender.Equals(chbSobreCosto) Then chbSobreCosto.Checked = False
               If Not sender.Equals(chbSobreVenta) Then chbSobreVenta.Checked = False
               If Not sender.Equals(chbDesdeFormula) Then chbDesdeFormula.Checked = False

               For Each dr As DataGridViewRow In dgvListasPrecios.Rows
                  dr.Cells("PorcActual").Value = chbPorcActual.Checked
                  dr.Cells("SobreCosto").Value = chbSobreCosto.Checked
                  dr.Cells("SobreVenta").Value = chbSobreVenta.Checked
                  dr.Cells("DesdeFormula").Value = chbDesdeFormula.Checked
               Next

            Finally
               _cambiando = False
            End Try
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Eventos Busquedas Foraneas"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
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
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
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
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Eventos Grilla dgvListasPrecios"
   Private Sub dgvListasPrecios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListasPrecios.CellContentClick
      Try
         If e.RowIndex > -1 Then
            If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
               Me.dgvListasPrecios.EndEdit()

               'Me.dgvListasPrecios.Rows(e.RowIndex).Cells(3).Value = (e.ColumnIndex = 3)
               Me.dgvListasPrecios.Rows(e.RowIndex).Cells(4).Value = (e.ColumnIndex = 4)
               Me.dgvListasPrecios.Rows(e.RowIndex).Cells(5).Value = (e.ColumnIndex = 5)
               Me.dgvListasPrecios.Rows(e.RowIndex).Cells(6).Value = (e.ColumnIndex = 6)
               Me.dgvListasPrecios.Rows(e.RowIndex).Cells(7).Value = (e.ColumnIndex = 7)

               'Si marca 'Porcentaje Actual' borro el valor de Porcentaje y Monto
               If e.ColumnIndex = 4 Then
                  Me.dgvListasPrecios.Rows(e.RowIndex).Cells(2).Value = 0
                  Me.dgvListasPrecios.Rows(e.RowIndex).Cells(3).Value = 0
               End If

               Dim lp As Entidades.ListaDePrecios = New Reglas.ListasDePrecios().GetUno(Integer.Parse(Me.dgvListasPrecios.Rows(e.RowIndex).Cells(0).Value.ToString()))

               'Marco Costo
               If e.ColumnIndex = 6 Then
                  If Decimal.Parse(Me.dgvListasPrecios.Rows(e.RowIndex).Cells(2).Value.ToString()) = 0 Then
                     Me.dgvListasPrecios.Rows(e.RowIndex).Cells(2).Value = lp.DescuentoRecargoPorc
                  End If
                  'Else
                  '   Me.dgvListasPrecios.Rows(e.RowIndex).Cells(2).Value = 0
               End If
               'ElseIf e.ColumnIndex = 8 Then
               '   Me.dgvListasPrecios.EndEdit()
               '   Me.CargaGrillaDetalle2()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvListasPrecios_CellValueNeeded(sender As Object, e As DataGridViewCellValueEventArgs) Handles dgvListasPrecios.CellValueNeeded
      If e.Value Is Nothing Then
         e.Value = _ceroFormateado
      End If
   End Sub

   Private Sub dgvListasPrecios_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListasPrecios.CellEndEdit
      Try
         If e.RowIndex > -1 Then
            If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
               Dim Dbl As Double = 0
               If Double.TryParse(Me.dgvListasPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), Dbl) Then
                  Me.dgvListasPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Dbl    '.ToString("N" + Me._DecimalesEnPrecio.ToString())
               Else
                  MessageBox.Show("El valor ingresado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.dgvListasPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = _ceroFormateado
               End If
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvListasPrecios_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvListasPrecios.DataError
      Try
         If e.Exception IsNot Nothing Then
            MessageBox.Show(e.Exception.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = False
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Eventos Grilla dgvSeleccionListaPrecios"
   Private Sub dgvDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSeleccionListaPrecios.CellContentClick
      If e.ColumnIndex = 1 And e.RowIndex <> -1 Then
         Me.dgvSeleccionListaPrecios.CommitEdit(DataGridViewDataErrorContexts.Display)
      End If
   End Sub
#End Region

#Region "Eventos Grilla ugPrecios"
   Private Sub ugPrecios_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugPrecios.AfterCellUpdate
      Try
         If e.Cell IsNot Nothing AndAlso e.Cell.Row IsNot Nothing Then
            Dim row As DataRow = ugPrecios.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If row IsNot Nothing Then
               If e.Cell.Column.Key = "Sel" Then
                  Exit Sub
               End If

               If Not IsNumeric(e.Cell.Value) Then
                  e.Cell.Value = 0
               End If

               Dim precioCostoNuevo As Decimal
               If e.Cell.Column.Key = "PrecioFabricaNuevo" Or e.Cell.Column.Key.StartsWith("DescuentoRecargoPorcNuevo") Or
                  e.Cell.Column.Key = "PrecioCostoNuevo" Or e.Cell.Column.Key.StartsWith("PorcNuevo_") Then
                  If e.Cell.Column.Key = "PrecioFabricaNuevo" Or e.Cell.Column.Key.StartsWith("DescuentoRecargoPorcNuevo") Then
                     If Not String.IsNullOrEmpty(row("IdProveedor").ToString()) Then
                        Dim valor As Decimal = Decimal.Parse(e.Cell.Value.ToString())
                        If e.Cell.Column.Key.StartsWith("DescuentoRecargoPorcNuevo") AndAlso (valor < -100 Or valor > 100) Then
                           If Not _cargandoAutomaticamentePorcentajes Then
                              MessageBox.Show("El porcentaje no es correcto!. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                           End If
                           e.Cell.Value = 0
                        End If

                        Dim descRec1 As Decimal = If(IsNumeric(row("DescuentoRecargoPorcNuevo1")), Decimal.Parse(row("DescuentoRecargoPorcNuevo1").ToString()), 0)
                        Dim descRec2 As Decimal = If(IsNumeric(row("DescuentoRecargoPorcNuevo2")), Decimal.Parse(row("DescuentoRecargoPorcNuevo2").ToString()), 0)
                        Dim descRec3 As Decimal = If(IsNumeric(row("DescuentoRecargoPorcNuevo3")), Decimal.Parse(row("DescuentoRecargoPorcNuevo3").ToString()), 0)
                        Dim descRec4 As Decimal = If(IsNumeric(row("DescuentoRecargoPorcNuevo4")), Decimal.Parse(row("DescuentoRecargoPorcNuevo4").ToString()), 0)
                        precioCostoNuevo = If(IsNumeric(row("PrecioFabricaNuevo")), Decimal.Parse(row("PrecioFabricaNuevo").ToString()), 0)

                        precioCostoNuevo = Math.Round(precioCostoNuevo * (1 + (descRec1 / 100)), _decimalesEnPrecio)
                        precioCostoNuevo = Math.Round(precioCostoNuevo * (1 + (descRec2 / 100)), _decimalesEnPrecio)
                        precioCostoNuevo = Math.Round(precioCostoNuevo * (1 + (descRec3 / 100)), _decimalesEnPrecio)
                        precioCostoNuevo = Math.Round(precioCostoNuevo * (1 + (descRec4 / 100)), _decimalesEnPrecio)

                        row("PrecioCostoNuevo") = precioCostoNuevo

                     Else
                        If Not _cargandoAutomaticamentePorcentajes Then
                           ' MessageBox.Show("El producto no tiene proveedor!. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        'e.Cell.Value = DBNull.Value
                     End If               'ELSE - If Not String.IsNullOrEmpty(row("IdProveedor").ToString()) Then
                  End If                  'If e.Cell.Column.Key = "PrecioFabricaNuevo" Or e.Cell.Column.Key.StartsWith("DescuentoRecargoPorcNuevo") Then

                  Dim idProducto As String = row("IdProductoSinEspacios").ToString()
                  Dim precioCosto As Decimal = If(IsNumeric(row("PrecioCosto")), Decimal.Parse(row("PrecioCosto").ToString()), 0)
                  precioCostoNuevo = If(IsNumeric(row("PrecioCostoNuevo")), Decimal.Parse(row("PrecioCostoNuevo").ToString()), 0)

                  For Each lis As Entidades.ListaDePrecios In Me._listas
                     Dim nc As NombresColumnas = GetNombresColumnas(lis.IdListaPrecios)
                     'Obtener el nuevo precio de venta y setearlo a la grilla
                     Dim precioVenta As Decimal = If(IsNumeric(row(nc.ColumnaPrecio)), Decimal.Parse(row(nc.ColumnaPrecio).ToString()), 0)
                     Dim porcRecargo As Decimal = If(IsNumeric(row(nc.ColumnaPorcNuevo)), Decimal.Parse(row(nc.ColumnaPorcNuevo).ToString()), 0)

                     row(nc.ColumnaPrecioNuevo) = Me.GetPrecioVentaNuevo(idProducto,
                                                                         precioCosto,
                                                                         precioCostoNuevo,
                                                                         precioVenta,
                                                                         lis.IdListaPrecios,
                                                                         GetComoCalcular(_dicListasPrecios(lis.IdListaPrecios)),
                                                                         porcRecargo, 0)
                  Next
               End If
            End If            'If row IsNot Nothing Then
         End If               'If e.Cell IsNot Nothing AndAlso e.Cell.Row IsNot Nothing Then

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugPrecios_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugPrecios.DoubleClickCell
      Try
         If e.Cell.Column.Key = "IdProducto" Or e.Cell.Column.Key = "IdProductoSinEspacios" Or e.Cell.Column.Key = "NombreProducto" Then
            Cursor = Cursors.WaitCursor
            Dim drSeleccionado As DataRow = ugPrecios.FilaSeleccionada(Of DataRow)()
            If drSeleccionado IsNot Nothing Then
               tssInfo.Text = String.Format("Abriendo ABM de productos para producto {0} - {1}",
                                            drSeleccionado("IdProductoSinEspacios").ToString(),
                                            drSeleccionado("NombreProducto").ToString().Trim())
               Application.DoEvents()
               Dim rProducto As Reglas.Productos = New Reglas.Productos()
               Dim producto As Entidades.Producto = rProducto.GetUno(drSeleccionado("IdProductoSinEspacios").ToString(), True, True)
               Using frmProducto As ProductosDetalle = New ProductosDetalle(producto)
                  frmProducto.IdFuncion = IdFuncion
                  frmProducto.StateForm = StateForm.Actualizar
                  If frmProducto.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                     Dim dtNuevo As DataTable = GetDataTableParaCargaGrillaDetalle(producto.IdProducto)
                     If dtNuevo.Rows.Count > 0 Then
                        Dim drNuevo As DataRow = dtNuevo.Rows(0)
                        For Each dcSeleccionado As DataColumn In drSeleccionado.Table.Columns
                           If drNuevo.Table.Columns.Contains(dcSeleccionado.ColumnName) Then
                              drSeleccionado(dcSeleccionado.ColumnName) = drNuevo(dcSeleccionado.ColumnName)
                           End If
                        Next
                     End If   'If dtNuevo.Rows.Count > 0 Then
                  End If      'If frmProducto.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
               End Using      'Using frmProducto As ProductosDetalle = New ProductosDetalle(producto)
            End If            'If drSeleccionado IsNot Nothing Then
         End If               'If e.Cell.Column.Key = "IdProducto" Or e.Cell.Column.Key = "IdProductoSinEspacios" Or e.Cell.Column.Key = "NombreProducto" Then
      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
         tssInfo.Text = String.Empty
      End Try
   End Sub
#End Region

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      Try

         Dim SucElegidas As Integer = 0
         For Each ite As Object In Me.clbSucursales.CheckedItems
            SucElegidas += 1
         Next
         If SucElegidas = 0 Then
            MessageBox.Show("Debe Seleccionar al menos una Sucursal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.clbSucursales.Focus()
            Exit Sub
         End If

         Me._estacargando = True

         Me.Cursor = Cursors.WaitCursor

         Me.tssInfo.Text = "Buscando registros..."
         Application.DoEvents()

         Me.CargaGrillaDetalle()

         Me.tssInfo.Text = ""
         Application.DoEvents()

         Me._estacargando = False

         Me.tsbImportarExcel.Enabled = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tssRegistros.Text = "0 Registros"
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

      Try

         If Me.ugPrecios.Rows.Count = 0 Then Exit Sub

         If Me.ValidarCalcular() Then
            Me.Cursor = Cursors.WaitCursor

            Me.BarraInicializa("Calculando precios...", 0, Me.ugPrecios.Rows.Count)

            Me.PosibilitaOrdenarGrilla2(False)
            Me._calcular = True
            '-- REQ-41756.- -----------------------------------------------
            _decimalesEnPrecio = Integer.Parse(txtRedondeoPrecioVenta.Text)
            '--------------------------------------------------------------
            Me.CalcularNuevosPrecios2()

            Me.ugPrecios.Focus()
            Dim aUGRow As UltraGridRow = Me.ugPrecios.GetRow(ChildRow.First)
            Me.ugPrecios.ActiveRow = aUGRow
            Me.ugPrecios.ActiveCell = aUGRow.Cells("PrecioCostoNuevo")
            Me.ugPrecios.PerformAction(UltraGridAction.EnterEditMode, False, False)

            Me.tsbGrabar.Enabled = True
            Me.tsbImportarExcel.Enabled = True
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.BarraFinaliza()
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnumSI Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnumSI)
               Case Reglas.Publicos.TodosEnumSI.MarcarTodos


                  For Each dr1 As UltraGridRow In ugPrecios.Rows
                     dr1.Cells("sel").Value = True
                  Next

                  Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos

               Case Reglas.Publicos.TodosEnumSI.DesmarcarTodos

                  For Each dr1 As UltraGridRow In ugPrecios.Rows
                     dr1.Cells("sel").Value = False
                  Next

                  Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos

               Case Reglas.Publicos.TodosEnumSI.InvertirMarcasTodos

                  For Each dr1 As UltraGridRow In ugPrecios.Rows
                     dr1.Cells("sel").Value = Not CBool(dr1.Cells("sel").Value)
                  Next

               Case Else

            End Select
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         Me.ugPrecios.UpdateData()
      End Try
   End Sub

   Private Sub btnTodosListas_Click(sender As Object, e As EventArgs) Handles btnTodosListas.Click
      Try
         If cmbTodosListas.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodosListas.SelectedValue) Is Reglas.Publicos.TodosEnumSI Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodosListas.SelectedValue, Reglas.Publicos.TodosEnumSI)
               Case Reglas.Publicos.TodosEnumSI.MarcarTodos

                  For Each dr As DataGridViewRow In dgvSeleccionListaPrecios.Rows
                     dr.Cells("selec").Value = True
                  Next

                  cmbTodosListas.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos

               Case Reglas.Publicos.TodosEnumSI.DesmarcarTodos

                  For Each dr As DataGridViewRow In dgvSeleccionListaPrecios.Rows
                     dr.Cells("selec").Value = False
                  Next

                  cmbTodosListas.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos

               Case Reglas.Publicos.TodosEnumSI.InvertirMarcasTodos
                  For Each dr As DataGridViewRow In dgvSeleccionListaPrecios.Rows
                     dr.Cells("selec").Value = Not CBool(dr.Cells("selec").Value)
                  Next

               Case Else

            End Select

            Me.dgvSeleccionListaPrecios.Update()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         ugPrecios.UpdateData()
      End Try
   End Sub

   Private Sub btnDescuentoRecargoPorc_Click(sender As Object, e As EventArgs) Handles btnDescuentoRecargoPorc1.Click, btnDescuentoRecargoPorc2.Click, btnDescuentoRecargoPorc3.Click, btnDescuentoRecargoPorc4.Click, btnDescuentoRecargoPorc5.Click, btnDescuentoRecargoPorc6.Click
      Try
         If _calcular = True Then
            If TypeOf (sender) Is Control Then
               If DirectCast(sender, Control).Tag IsNot Nothing AndAlso
               Not String.IsNullOrWhiteSpace(DirectCast(sender, Control).Tag.ToString()) Then
                  Dim campo As String
                  campo = DirectCast(sender, Control).Tag.ToString()
                  Dim descrec As Decimal

                  If campo.StartsWith("DescuentoRecargoPorcNuevo1") AndAlso IsNumeric(txtDescuentoRecargoPorc1.Text) Then
                     descrec = Decimal.Parse(txtDescuentoRecargoPorc1.Text)
                  ElseIf campo.StartsWith("DescuentoRecargoPorcNuevo2") AndAlso IsNumeric(txtDescuentoRecargoPorc2.Text) Then
                     descrec = Decimal.Parse(txtDescuentoRecargoPorc2.Text)
                  ElseIf campo.StartsWith("DescuentoRecargoPorcNuevo3") AndAlso IsNumeric(txtDescuentoRecargoPorc3.Text) Then
                     descrec = Decimal.Parse(txtDescuentoRecargoPorc3.Text)
                  ElseIf campo.StartsWith("DescuentoRecargoPorcNuevo4") AndAlso IsNumeric(txtDescuentoRecargoPorc4.Text) Then
                     descrec = Decimal.Parse(txtDescuentoRecargoPorc4.Text)
                  ElseIf campo.StartsWith("DescuentoRecargoPorcNuevo5") AndAlso IsNumeric(txtDescuentoRecargoPorc5.Text) Then
                     descrec = Decimal.Parse(txtDescuentoRecargoPorc5.Text)
                  ElseIf campo.StartsWith("DescuentoRecargoPorcNuevo6") AndAlso IsNumeric(txtDescuentoRecargoPorc6.Text) Then
                     descrec = Decimal.Parse(txtDescuentoRecargoPorc6.Text)
                  Else
                     descrec = 0
                  End If

                  Try
                     _cargandoAutomaticamentePorcentajes = True
                     If ugPrecios.DisplayLayout.Bands(0).Columns.Exists(campo) Then
                        If ShowPregunta(String.Format("¿Desea aplicar {0:N2} al {1} de todos los productos seleccionados?",
                        descrec, ugPrecios.DisplayLayout.Bands(0).Columns(campo).Header.Caption)) = Windows.Forms.DialogResult.Yes Then
                           For Each dr As UltraGridRow In ugPrecios.Rows
                              If Boolean.Parse(dr.Cells("Sel").Value.ToString()) Then
                                 dr.Cells(campo).Value = descrec

                              End If
                           Next
                           Me.ugPrecios.UpdateData()
                        End If
                     End If
                  Finally
                     _cargandoAutomaticamentePorcentajes = False
                  End Try
               End If
            End If
         Else
            MessageBox.Show("Antes de Calcular los Descuentos/Recargos deberá realizar los calculos de las Listas de Precios", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbcDetalle.SelectedTab = TbpCalcular
            btnCalcular.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#Region "Eventos para PresionarTab"
   Private Sub txtRedondeoPrecioVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRedondeoPrecioVenta.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPrecioCostoPorc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioCostoPorc.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPrecioCostoMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioCostoMonto.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtDescuentoRecargoPorc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuentoRecargoPorc6.KeyDown, txtDescuentoRecargoPorc5.KeyDown, txtDescuentoRecargoPorc4.KeyDown, txtDescuentoRecargoPorc3.KeyDown, txtDescuentoRecargoPorc2.KeyDown, txtDescuentoRecargoPorc1.KeyDown
      PresionarTab(e)
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub BarraInicializa(texto As String, valorInicial As Integer, maximoValor As Integer)
      Me.tspBarra.Visible = True
      Me.tspBarra.Maximum = maximoValor
      Me.tspBarra.Value = valorInicial
      Me.tssInfo.Text = texto
   End Sub

   Private Sub BarraFinaliza()
      Me.tssInfo.Text = String.Empty
      Me.tspBarra.Value = Me.tspBarra.Maximum
      Me.tspBarra.Visible = False
      Me.tspBarra.Value = 0
   End Sub

   Private Sub CargaSeleccionListasDePrecios()

      Dim oLista As Reglas.ListasDePrecios = New Reglas.ListasDePrecios()

      Dim blnSeleccionarListas As Boolean
      If Reglas.Publicos.ActualizarPreciosMostrarTodos Then
         blnSeleccionarListas = True
         cmbTodosListas.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos
      Else
         blnSeleccionarListas = False
         cmbTodosListas.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos
      End If

      Me._listasSelec = oLista.GetTodos(True)

      Dim dt As DataTable = New DataTable()
      dt.Columns.Add("Id", System.Type.GetType("System.Int32"))
      dt.Columns.Add("Selec", System.Type.GetType("System.Boolean"))
      dt.Columns.Add("Lista", System.Type.GetType("System.String"))

      Dim dr As DataRow

      For Each lp As Entidades.ListaDePrecios In Me._listasSelec
         dr = dt.NewRow()
         dr("Id") = lp.IdListaPrecios
         dr("Selec") = blnSeleccionarListas
         dr("Lista") = lp.NombreListaPrecios

         dt.Rows.Add(dr)
      Next

      Me.dgvSeleccionListaPrecios.DataSource = dt

      'seteo la grilla
      With Me.dgvSeleccionListaPrecios
         .RowHeadersVisible = False
         .Columns("Id").Visible = False
         .Columns("Lista").HeaderText = "Nombre"
         .Columns("Lista").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
         .Columns("Lista").ReadOnly = True
         .Columns("Selec").HeaderText = "Sel"
         .Columns("Selec").Visible = True
         .Columns("Selec").Width = 30
      End With

   End Sub

   Private Sub CargaListasDePrecios()

      Dim oLista As Reglas.ListasDePrecios = New Reglas.ListasDePrecios()

      Me._listas = Me._listasSelec

      Dim dt As DataTable = New DataTable()
      dt.Columns.Add("Id", System.Type.GetType("System.Int32"))
      dt.Columns.Add("Lista", System.Type.GetType("System.String"))
      dt.Columns.Add("Porcentaje", System.Type.GetType("System.Decimal"))
      dt.Columns.Add("Monto", System.Type.GetType("System.Decimal"))
      dt.Columns.Add("PorcActual", System.Type.GetType("System.Boolean"))
      dt.Columns.Add("SobreVenta", System.Type.GetType("System.Boolean"))
      dt.Columns.Add("SobreCosto", System.Type.GetType("System.Boolean"))
      dt.Columns.Add("DesdeFormula", System.Type.GetType("System.Boolean"))

      ' dt.Columns.Add("DesdeFormula", System.Type.GetType("System.Boolean"))



      Dim dr As DataRow

      For Each lp As Entidades.ListaDePrecios In Me._listas

         dr = dt.NewRow()
         dr("Id") = lp.IdListaPrecios
         dr("Lista") = lp.NombreListaPrecios

         If _actualizarPreciosCalculo = "COSTO" Then
            dr("Porcentaje") = lp.DescuentoRecargoPorc
         Else
            dr("Porcentaje") = 0
         End If

         dr("Monto") = 0

         Select Case _actualizarPreciosCalculo
            Case "ACTUAL"
               dr("PorcActual") = True
               dr("SobreVenta") = False
               dr("SobreCosto") = False
               dr("DesdeFormula") = False
            Case "VENTA"
               dr("PorcActual") = False
               dr("SobreVenta") = True
               dr("SobreCosto") = False
               dr("DesdeFormula") = False
            Case "COSTO"
               dr("PorcActual") = False
               dr("SobreVenta") = False
               dr("SobreCosto") = True
               dr("DesdeFormula") = False
            Case "FORMULA"
               dr("PorcActual") = False
               dr("SobreVenta") = False
               dr("SobreCosto") = False
               dr("DesdeFormula") = True

         End Select

         dt.Rows.Add(dr)
      Next

      Me.dgvListasPrecios.DataSource = dt

      'seteo la grilla
      With Me.dgvListasPrecios
         .RowHeadersVisible = False

         .Columns("Id").Visible = False

         .Columns("Lista").HeaderText = "Nombre"
         .Columns("Lista").Width = 170
         .Columns("Lista").ReadOnly = True
         .Columns("Lista").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

         .Columns("Porcentaje").HeaderText = "%"
         .Columns("Porcentaje").Width = 50
         .Columns("Porcentaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns("Porcentaje").DefaultCellStyle.Format = _formatoEnPrecio
         .Columns("Porcentaje").ValueType = System.Type.GetType("System.Double")

         .Columns("Monto").HeaderText = "$"
         .Columns("Monto").Width = 50
         .Columns("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns("Monto").DefaultCellStyle.Format = _formatoEnPrecio
         .Columns("Monto").ValueType = System.Type.GetType("System.Double")

         .Columns("PorcActual").HeaderText = "Porc. Actual"
         .Columns("PorcActual").Width = 50
         .Columns("PorcActual").ValueType = System.Type.GetType("System.Boolean")

         .Columns("SobreVenta").HeaderText = "Sobre Venta"
         .Columns("SobreVenta").Width = 50
         .Columns("SobreVenta").ValueType = System.Type.GetType("System.Boolean")

         .Columns("SobreCosto").HeaderText = "Sobre Costo"
         .Columns("SobreCosto").Width = 50
         .Columns("SobreCosto").ValueType = System.Type.GetType("System.Boolean")

         If Reglas.Publicos.TieneModuloProduccion Then
            .Columns("DesdeFormula").HeaderText = "Desde Formula"
            .Columns("DesdeFormula").Width = 50
            .Columns("DesdeFormula").ValueType = System.Type.GetType("System.Boolean")
         Else
            .Columns("DesdeFormula").Visible = False
         End If

         chbPorcActual.Visible = .Columns("PorcActual").Visible
         chbSobreVenta.Visible = .Columns("SobreVenta").Visible
         chbSobreCosto.Visible = .Columns("SobreCosto").Visible
         chbDesdeFormula.Visible = .Columns("DesdeFormula").Visible

         _cambiando = True
         Try
            Select Case _actualizarPreciosCalculo
               Case "ACTUAL"
                  chbPorcActual.Checked = True
                  chbSobreVenta.Checked = False
                  chbSobreCosto.Checked = False
                  chbDesdeFormula.Checked = False
               Case "VENTA"
                  chbPorcActual.Checked = False
                  chbSobreVenta.Checked = True
                  chbSobreCosto.Checked = False
                  chbDesdeFormula.Checked = False
               Case "COSTO"
                  chbPorcActual.Checked = False
                  chbSobreVenta.Checked = False
                  chbSobreCosto.Checked = True
                  chbDesdeFormula.Checked = False
               Case "FORMULA"
                  chbPorcActual.Checked = False
                  chbSobreVenta.Checked = False
                  chbSobreCosto.Checked = False
                  chbDesdeFormula.Checked = True
            End Select
         Finally
            _cambiando = False
         End Try
      End With

   End Sub

   Private Sub RefrescarDatos()

      _cache = New Reglas.BusquedasCacheadas()
      _cacheNombresColumnas = New Dictionary(Of Integer, NombresColumnas)()

      tsbGrabar.Enabled = False
      tsbImportarExcel.Enabled = False

      chbSubRubro.Checked = False
      chbProducto.Checked = False
      chbProveedor.Checked = False

      cmbRubro.SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      cmbMarca.SelectedValue = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)

      chbSinCosto.Checked = False
      chbSinVenta.Checked = False
      cboCompuestos.SelectedIndex = 0

      chbFechaActualizado.Checked = False

      txtPrecioCostoPorc.Text = _ceroFormateado
      txtPrecioCostoMonto.Text = _ceroFormateado
      txtPorcenFabrica.Text = _ceroFormateado

      txtRedondeoPrecioVenta.Text = _decimalesEnPrecio.ToString()
      txtAjusteA.Text = "9"

      rdbCostoSiMismo.Checked = True

      chbAjusteA.Checked = False
      _calcular = False

      cmbEsOferta.SelectedIndex = 0

      CargaSeleccionListasDePrecios()

      '-- REQ-36403.- ----------------------------------------------
      cmbConStock.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      '-------------------------------------------------------------

      If Not Me.ugPrecios.DataSource Is Nothing Then
         DirectCast(Me.ugPrecios.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.dgvListasPrecios.DataSource Is Nothing Then
         DirectCast(Me.dgvListasPrecios.DataSource, DataTable).Rows.Clear()
      End If

      Me.chbMoneda.Checked = False

      Me.tssRegistros.Text = " 0 Registros"

      Dim Cont As Integer

      For Cont = 0 To clbSucursales.Items.Count - 1

         'Siempre marco la actual, si quiere hacer precios a los demas debera marcalo
         'If DirectCast(Me.clbSucursales.Items.Item(Cont), Entidades.Sucursal).Id = actual.Sucursal.Id And clbSucursales.Items.Count = 1 Then

         If DirectCast(Me.clbSucursales.Items.Item(Cont), Entidades.Sucursal).Id = actual.Sucursal.Id Then
            Me.clbSucursales.SetItemChecked(Cont, True)
         Else
            Me.clbSucursales.SetItemChecked(Cont, False)
         End If

      Next

      Me.PosibilitaOrdenarGrilla2(True)

      Me.tbcDetalle.SelectedTab = Me.TbpFiltros

   End Sub

   Private Sub CargarSucursales()

      Dim lis As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(False)

      For Each suc As Entidades.Sucursal In lis
         Me.clbSucursales.Items.Add(suc)
         'Marco en forma predeterminada la Sucursal donde estoy parado. Ahorra trabajo, sobre todo si solo hay 1, tiene mas sentido.
         If suc.Id = actual.Sucursal.Id Then
            Me.clbSucursales.SetItemChecked(Me.clbSucursales.Items.Count - 1, True)
         End If
      Next
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False
      Me.btnBuscar_Click(Me.btnBuscar, New EventArgs())
      If Me.btnCalcular.Enabled Then
         Me.tbcDetalle.SelectedTab = Me.TbpCalcular
         Me.btnCalcular.PerformClick()
      End If
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
      Me.chbProveedorHabitual.Enabled = True
   End Sub

   Private _productosAActualizar As DataTable

   Private Sub CargaGrillaDetalle()
      Me._listasSelec.Clear()

      For Each dr As DataGridViewRow In Me.dgvSeleccionListaPrecios.Rows
         If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then
            Me._listasSelec.Add(_cache.BuscaListaDePrecios(Integer.Parse(dr.Cells("Id").Value.ToString())))
         End If
      Next

      Me.ugPrecios.DataSource = Nothing

      Me.CargaListasDePrecios()

      Me._productosAActualizar = GetDataTableParaCargaGrillaDetalle(idProductoEspecifico:=String.Empty)

      Me.ugPrecios.DataSource = Me._productosAActualizar

      Me.tssRegistros.Text = Me.ugPrecios.Rows.Count.ToString() & " Registros"

      Me.tsbGrabar.Enabled = False

      Me.AgregarSeleccion()

      Me.FormatearGrilla2()

      ugPrecios.Rows.Refresh(RefreshRow.ReloadData)

      Me.ugPrecios.DisplayLayout.UseFixedHeaders = True

      Me.ugPrecios.DisplayLayout.Override.FixedCellSeparatorColor = Color.Red
      Me.ugPrecios.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Me.ugPrecios.DisplayLayout.Bands(0).Columns("NombreProducto").Header.Fixed = True
      Me.ugPrecios.DisplayLayout.Bands(0).Columns("Sel").Header.Fixed = True
      Me.ugPrecios.DisplayLayout.Bands(0).Columns("IdProducto").Header.Fixed = True

      Me.PosibilitaOrdenarGrilla2(True)

   End Sub

   Private Function GetDataTableParaCargaGrillaDetalle(idProductoEspecifico As String) As DataTable
      Dim Sucursales(10) As Integer
      Dim IdProducto As String = ""
      Dim IdProveedor As Long = 0
      Dim FechaActDesde As Date = Nothing
      Dim FechaActHasta As Date = Nothing
      Dim EsOferta As String
      Dim idMoneda As Integer = 0
      Dim con As Integer = 0
      For Each ite As Object In Me.clbSucursales.CheckedItems
         Sucursales(con) = DirectCast(ite, Entidades.Sucursal).Id
         con += 1
      Next

      If Me.bscCodigoProducto2.Selecciono Or Me.bscProducto2.Selecciono Then
         IdProducto = Me.bscCodigoProducto2.Text
      End If

      If Me.bscCodigoProveedor.Text.Length > 0 Then
         IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      If Me.chbFechaActualizado.Checked Then
         FechaActDesde = Me.dtpDesde.Value
         FechaActHasta = Me.dtpHasta.Value
      End If

      EsOferta = Me.cmbEsOferta.Text

      'GAR: 10/05/2016 - NO debe recargar las listas al filtrar porque se pierden cuando graba
      'En caso de filtrar las listas, ahi debe mosotrar o no.
      'Me.CargaListasDePrecios()

      Dim arrProductos As Entidades.Producto() = {}
      If _comprasProductos IsNot Nothing Then
         arrProductos = _comprasProductos.ConvertAll(Function(x) x.ProductoSucursal.Producto).ToArray()
      End If

      Dim marcas As Entidades.Marca() = cmbMarca.GetMarcas(True)
      Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros(True)
      Dim subRubros As Entidades.SubRubro() = cmbSubRubro.GetSubRubros(True)
      Dim subSubRubros As Entidades.SubSubRubro() = cmbSubSubRubro.GetSubSubRubros(True)

      If String.IsNullOrWhiteSpace(idProductoEspecifico) Then
         idProductoEspecifico = txtCodigo.Text.Trim()
      End If

      If chbMoneda.Checked Then
         If IsNumeric(cmbMoneda.SelectedValue) Then
            idMoneda = Integer.Parse(cmbMoneda.SelectedValue.ToString())
         End If
      End If

      Return New Reglas.Productos().GetProductosParaActualizarPrecios2(Sucursales,
                                                                      Me._listasSelec,
                                                                      marcas,
                                                                      rubros,
                                                                      subRubros,
                                                                      subSubRubros,
                                                                      IdProducto,
                                                                      IdProveedor,
                                                                      Me.chbSinCosto.Checked,
                                                                      Me.chbSinVenta.Checked,
                                                                      Me.cboCompuestos.Text,
                                                                      FechaActDesde, FechaActHasta, idProductoEspecifico, If(arrProductos.Length = 0, txtProducto.Text.Trim(), String.Empty),
                                                                      Me.chbProveedorHabitual.Checked, EsOferta,
                                                                      txtCodigoProductoProveedor.Text,
                                                                      arrProductos, idMoneda, cmbConStock.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos))
   End Function


   Private Sub AgregarSeleccion()

      Me.ugPrecios.DisplayLayout.Bands(0).Columns("Sel").Width = 30

      Dim blnSeleccionar As Boolean
      If Reglas.Publicos.ActualizarPreciosMostrarTodos Then
         blnSeleccionar = True
         Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos
      Else
         blnSeleccionar = False
         Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos
      End If

      For Each dr As DataRow In _productosAActualizar.Rows
         dr("sel") = blnSeleccionar
      Next

   End Sub

   Private Sub FormatearGrilla2()

      With ugPrecios.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         Dim pos As Integer = 0

         .Columns("Sel").FormatearColumna("", pos, 30, HAlign.Center, , , , Activation.AllowEdit).Style = UltraWinGrid.ColumnStyle.CheckBox

         .Columns("NombreSucursal").FormatearColumna("Sucursal", pos, 70, , clbSucursales.CheckedItems.Count = 0)

         .Columns("IdProducto").FormatearColumna("Cod. Prod.", pos, 100, HAlign.Right)

         .Columns("CodigoProductoProveedor").FormatearColumna("Cod. Prod. Proveedor", pos, 100, , Not _actualizarPreciosMostrarCodigoProductoProveedor)

         .Columns("NombreProducto").FormatearColumna("Producto", pos, 200)
         .Columns("NombreMarca").FormatearColumna("Marca", pos, 100)
         .Columns("NombreRubro").FormatearColumna("Rubro", pos, 100)
         .Columns("NombreSubRubro").FormatearColumna("SubRubro", pos, 100, , Not Reglas.Publicos.ProductoTieneSubRubro)
         .Columns("NombreSubSubRubro").FormatearColumna("SubSubRubro", pos, 100, , Not Reglas.Publicos.ProductoTieneSubSubRubro)

         .Columns("Alicuota").FormatearColumna("IVA", pos, 40, HAlign.Right, , "N2")
         .Columns("Simbolo").FormatearColumna("M.", pos, 40, HAlign.Center)
         .Columns("EsOferta").FormatearColumna("Oferta", pos, 44, HAlign.Center)

         .Columns("PrecioFabrica").FormatearColumna("Precio Compra", pos, 65, HAlign.Right, Not Reglas.Publicos.UtilizaPrecioDeCompra, _formatoEnPrecio)
         .Columns("PrecioFabricaNuevo").FormatearColumna("Nuevo Precio Compra", pos, 65, HAlign.Right, True, _formatoEnPrecio)
         .Columns("PrecioFabricaNuevo").CellAppearance.BackColor = _ColorColumnasEditables

         .Columns("NombreProveedor").FormatearColumna("Prov. Habitual", pos, 124, , Not Reglas.Publicos.UtilizaPrecioDeCompra)

         .Columns("DescuentoRecargoPorc1").FormatearColumna("D/R 1", pos, 65, HAlign.Right, Not Reglas.Publicos.UtilizaPrecioDeCompra, _formatoEnPrecio)
         .Columns("DescuentoRecargoPorcNuevo1").FormatearColumna("Nuevo D/R 1", pos, 65, HAlign.Right, True, _formatoEnPrecio)
         .Columns("DescuentoRecargoPorcNuevo1").CellAppearance.BackColor = _ColorColumnasEditables

         .Columns("DescuentoRecargoPorc2").FormatearColumna("D/R 2", pos, 65, HAlign.Right, Not Reglas.Publicos.UtilizaPrecioDeCompra, _formatoEnPrecio)
         .Columns("DescuentoRecargoPorcNuevo2").FormatearColumna("Nuevo D/R 2", pos, 65, HAlign.Right, True, _formatoEnPrecio)
         .Columns("DescuentoRecargoPorcNuevo2").CellAppearance.BackColor = _ColorColumnasEditables

         .Columns("DescuentoRecargoPorc3").FormatearColumna("D/R 3", pos, 65, HAlign.Right, Not Reglas.Publicos.UtilizaPrecioDeCompra, _formatoEnPrecio)
         .Columns("DescuentoRecargoPorcNuevo3").FormatearColumna("Nuevo D/R 3", pos, 65, HAlign.Right, True, _formatoEnPrecio)
         .Columns("DescuentoRecargoPorcNuevo3").CellAppearance.BackColor = _ColorColumnasEditables

         .Columns("DescuentoRecargoPorc4").FormatearColumna("D/R 4", pos, 65, HAlign.Right, Not Reglas.Publicos.UtilizaPrecioDeCompra, _formatoEnPrecio)
         .Columns("DescuentoRecargoPorcNuevo4").FormatearColumna("Nuevo D/R 4", pos, 65, HAlign.Right, True, _formatoEnPrecio)
         .Columns("DescuentoRecargoPorcNuevo4").CellAppearance.BackColor = _ColorColumnasEditables


         .Columns("FechaActualizacion").FormatearColumna("Actualización Costo", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
         .Columns("PrecioCosto").FormatearColumna("Precio Costo", pos, 65, HAlign.Right, , _formatoEnPrecio)
         .Columns("PrecioCostoNuevo").FormatearColumna("Nuevo Precio Costo", pos, 65, HAlign.Right, True, _formatoEnPrecio, Formatos.MaskInput.CustomMaskInput(14, _decimalesEnPrecio))
         .Columns("PrecioCostoNuevo").CellAppearance.BackColor = _ColorColumnasEditables

         For Each lis As Entidades.ListaDePrecios In Me._listasSelec
            Dim nc As NombresColumnas = GetNombresColumnas(lis.IdListaPrecios)

            .Columns(nc.ColumnaPorc).FormatearColumna("%", pos, 50, HAlign.Right, , _formatoEnPrecio, Formatos.MaskInput.Decimales5_2)
            .Columns(nc.FechaActualizacionPrecio).FormatearColumna(String.Format("Actualización Precio {0}", lis.NombreListaPrecios), pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
            .Columns(nc.ColumnaPrecio).FormatearColumna(lis.NombreListaPrecios, pos, 65, HAlign.Right, , _formatoEnPrecio)

            .Columns(nc.ColumnaPorcNuevo).FormatearColumna("Nuevo %", pos, 50, HAlign.Right, True, _formatoEnPrecio, Formatos.MaskInput.Decimales5_2)
            .Columns(nc.ColumnaPorcNuevo).CellAppearance.BackColor = _ColorColumnasEditables
            .Columns(nc.ColumnaPrecioNuevo).FormatearColumna(String.Format("Nuevo {0}", lis.NombreListaPrecios), pos, 65, HAlign.Right, True, _formatoEnPrecio, Formatos.MaskInput.CustomMaskInput(14, _decimalesEnPrecio))
            .Columns(nc.ColumnaPrecioNuevo).CellAppearance.BackColor = _ColorColumnasEditables
         Next

         .Columns("Stock").FormatearColumna("Stock", pos, 60, HAlign.Right, , _formatoEnPrecio)

         .Columns("EsCompuesto").FormatearColumna("Fórmula", pos, 50, HAlign.Center, Not Reglas.Publicos.TieneModuloProduccion)
         .Columns("UltimoProv").FormatearColumna("Prov. Ultima Compra", pos, 124)

      End With

      PreferenciasLeer(ugPrecios, Me.tsbPreferencias)
   End Sub
   Private _todosLosProductos As DataTable

   Private Sub CalcularNuevosPrecios2()

      Dim idProducto As String = ""
      Dim precioFabrica As Decimal = 0
      Dim precioCosto As Decimal = 0
      Dim precioVenta As Decimal = 0
      Dim precioFabricaNuevo As Decimal = 0
      Dim precioCostoNuevo As Decimal = 0
      Dim dR1Nuevo As Decimal = 0
      Dim dR2Nuevo As Decimal = 0
      Dim dR3Nuevo As Decimal = 0
      Dim dR4Nuevo As Decimal = 0

      Me._todosLosProductos = New Reglas.Productos().GetAll()

      _dicListasPrecios = New Dictionary(Of Integer, DataRow)()
      For Each dr As DataRow In DirectCast(dgvListasPrecios.DataSource, DataTable).Rows
         _dicListasPrecios.Add(Integer.Parse(dr("Id").ToString()), dr)
      Next

      'For Each dr As UltraGridRow In Me.ugPrecios.Rows
      For Each dr As DataRow In _productosAActualizar.Select("Sel")
         'If Boolean.Parse(dr.Cells("Sel").Value.ToString()) Then

         idProducto = dr("IdProductoSinEspacios").ToString()

         precioFabrica = If(IsNumeric(dr("PrecioFabrica")), Decimal.Parse(dr("PrecioFabrica").ToString()), 0)
         precioCosto = If(IsNumeric(dr("PrecioCosto")), Decimal.Parse(dr("PrecioCosto").ToString()), 0)
         'precioVenta = Decimal.Parse(dr.Cells("PrecioVenta").Value.ToString())

         'Obtener el nuevo precio de fabrica y setearlo a la grilla
         precioFabricaNuevo = Me.GetPrecioFabricaNuevo(precioFabrica)
         dr("PrecioFabricaNuevo") = Math.Round(precioFabricaNuevo, _decimalesEnPrecio)

         dR1Nuevo = If(IsNumeric(dr("DescuentoRecargoPorc1")), Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()), 0)
         dR2Nuevo = If(IsNumeric(dr("DescuentoRecargoPorc2")), Decimal.Parse(dr("DescuentoRecargoPorc2").ToString()), 0)
         dR3Nuevo = If(IsNumeric(dr("DescuentoRecargoPorc3")), Decimal.Parse(dr("DescuentoRecargoPorc3").ToString()), 0)
         dR4Nuevo = If(IsNumeric(dr("DescuentoRecargoPorc4")), Decimal.Parse(dr("DescuentoRecargoPorc4").ToString()), 0)

         dr("DescuentoRecargoPorcNuevo1") = dR1Nuevo
         dr("DescuentoRecargoPorcNuevo2") = dR2Nuevo
         dr("DescuentoRecargoPorcNuevo3") = dR3Nuevo
         dr("DescuentoRecargoPorcNuevo4") = dR4Nuevo

         Dim cantidadCostoNuevo = 0D
         precioCostoNuevo = GetPrecioCostoNuevo(idProducto, precioFabricaNuevo, precioCosto, dR1Nuevo, dR2Nuevo, dR3Nuevo, dR4Nuevo)
         Dim precioCostoNuevoBD = precioCostoNuevo
         'Obtener el nuevo precio de costo y setearlo a la grilla

         If _comprasProductos IsNot Nothing Then
            For Each cp In _comprasProductos.Where(Function(x) x.IdProducto.Trim() = dr("IdProductoSinEspacios").ToString() And x.Precio <> 0)
               Dim p As Entidades.Producto = cp.ProductoSucursal.Producto
               Dim precio As Decimal = cp.Precio + (cp.DescuentoRecargo / cp.Cantidad) + (cp.DescRecGeneral / cp.Cantidad)
               If p.Moneda.IdMoneda = 2 Then
                  precio = precio / _cotizacionDolar
               End If
               If Reglas.Publicos.PreciosConIVA Then
                  Dim porcentajeIVA As Decimal = cp.PorcentajeIVA
                  'Si es Monotributista (el Proveedor o la Empresa) tomo el IVA del producto porque el comprobante está con IVA 0
                  'Si yo soy Monotributista mis productos deberían estar configurados con IVA 0, por lo que no es problema esto
                  'ActualizarPreciosDesdeComprasPriorizaIVAProducto:
                  '        Agregado por solicitud de Bazar Celta. Ellos reciben los comprobantes sin IVA pero quieren hacer precios de compra como si lo tuviera.
                  '        Por lo que la venir el precio de compra sin IVA y la alicuota del comprobante en 0%, tomo el 21% del producto
                  If (_tipoComprobanteCompra.UtilizaImpuestos AndAlso (Not _categoriaFiscalProveedor.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado)) Or
                     (Not _tipoComprobanteCompra.UtilizaImpuestos AndAlso Reglas.Publicos.ActualizarPreciosDesdeComprasPriorizaIVAProducto) Then
                     porcentajeIVA = p.Alicuota
                  End If
                  precioCostoNuevo = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(precio, porcentajeIVA,
                                                                                          p.PorcImpuestoInterno, p.ImporteImpuestoInterno, p.OrigenPorcImpInt)
               Else
                  precioCostoNuevo = precio
               End If
               cantidadCostoNuevo = cp.Cantidad
            Next
         End If

         If Reglas.Publicos.Compras.ComprasPrecioCosto = Entidades.Publicos.ComprasPrecioCosto.PROMPOND Then
            Dim ps = New Reglas.ProductosSucursales().GetUno(dr.Field(Of Integer)("IdSucursal"), idProducto)
            If ps.Stock <> 0 Then
               precioCostoNuevo = (((ps.Stock - cantidadCostoNuevo) * precioCostoNuevoBD) + (cantidadCostoNuevo * precioCostoNuevo)) / (ps.Stock)
            End If
         End If

         dr("PrecioCostoNuevo") = Decimal.Round(precioCostoNuevo, _decimalesEnPrecio)

         If _comprasProductos IsNot Nothing Then
            Dim precioFabricaNuevoSegunCompra As Decimal = precioCostoNuevo
            precioFabricaNuevoSegunCompra = precioFabricaNuevoSegunCompra / (1 + (dR4Nuevo / 100))
            precioFabricaNuevoSegunCompra = precioFabricaNuevoSegunCompra / (1 + (dR3Nuevo / 100))
            precioFabricaNuevoSegunCompra = precioFabricaNuevoSegunCompra / (1 + (dR2Nuevo / 100))
            precioFabricaNuevoSegunCompra = precioFabricaNuevoSegunCompra / (1 + (dR1Nuevo / 100))

            dr("PrecioFabricaNuevo") = Decimal.Round(precioFabricaNuevoSegunCompra, _decimalesEnPrecio)
         End If

         For Each lis As Entidades.ListaDePrecios In Me._listasSelec
            'Obtener el nuevo precio de venta y setearlo a la grilla
            precioVenta = 0
            Dim nc As NombresColumnas = GetNombresColumnas(lis.IdListaPrecios)

            Dim comoCalculo As ComoCalcular = GetComoCalcular(_dicListasPrecios(lis.IdListaPrecios))

            If comoCalculo = ComoCalcular.PorcActual Then
               dr(nc.ColumnaPorcNuevo) = dr(nc.ColumnaPorc)
            Else
               dr(nc.ColumnaPorcNuevo) = _dicListasPrecios(lis.IdListaPrecios)("Porcentaje")
            End If

            Dim porcRecargo As Decimal = If(IsNumeric(dr(nc.ColumnaPorcNuevo)), Decimal.Parse(dr(nc.ColumnaPorcNuevo).ToString()), 0)

            Dim monto As Decimal = Decimal.Parse(_dicListasPrecios(lis.IdListaPrecios)("Monto").ToString())

            If comoCalculo = ComoCalcular.SobreCosto And porcRecargo = 0 And Not lis.PermiteUtilidadEnCero Then
               MessageBox.Show(String.Format("Atención: En la lista {0} no esta permitido utilidad en cero",
                                              lis.NombreListaPrecios),
                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Return
            End If

            precioVenta = If(IsNumeric(dr(nc.ColumnaPrecio)), Decimal.Parse(dr(nc.ColumnaPrecio).ToString()), 0)

            dr(nc.ColumnaPrecioNuevo) = Me.GetPrecioVentaNuevo(idProducto,
                                                               precioCosto,
                                                               precioCostoNuevo,
                                                               precioVenta,
                                                               lis.IdListaPrecios,
                                                               comoCalculo,
                                                               porcRecargo,
                                                               monto)
         Next

         Me.tspBarra.Value += 1
      Next

      'Me.dgvPrecios.Enabled = True

      With Me.ugPrecios.DisplayLayout.Bands(0)
         .Columns("PrecioFabricaNuevo").CellActivation = Activation.AllowEdit
         .Columns("PrecioCostoNuevo").CellActivation = Activation.AllowEdit

         .Columns("DescuentoRecargoPorcNuevo1").CellActivation = Activation.AllowEdit
         .Columns("DescuentoRecargoPorcNuevo2").CellActivation = Activation.AllowEdit
         .Columns("DescuentoRecargoPorcNuevo3").CellActivation = Activation.AllowEdit
         .Columns("DescuentoRecargoPorcNuevo4").CellActivation = Activation.AllowEdit

         .Columns("PrecioFabricaNuevo").Hidden = Not Reglas.Publicos.UtilizaPrecioDeCompra
         .Columns("PrecioCostoNuevo").Hidden = False

         .Columns("DescuentoRecargoPorcNuevo1").Hidden = Not Reglas.Publicos.UtilizaPrecioDeCompra
         .Columns("DescuentoRecargoPorcNuevo2").Hidden = Not Reglas.Publicos.UtilizaPrecioDeCompra
         .Columns("DescuentoRecargoPorcNuevo3").Hidden = Not Reglas.Publicos.UtilizaPrecioDeCompra
         .Columns("DescuentoRecargoPorcNuevo4").Hidden = Not Reglas.Publicos.UtilizaPrecioDeCompra


         For Each lis As Entidades.ListaDePrecios In Me._listasSelec
            Dim nc As NombresColumnas = GetNombresColumnas(lis.IdListaPrecios)
            .Columns(nc.ColumnaPorcNuevo).CellActivation = Activation.AllowEdit
            .Columns(nc.ColumnaPrecioNuevo).CellActivation = Activation.AllowEdit

            .Columns(nc.ColumnaPorcNuevo).Hidden = False
            .Columns(nc.ColumnaPrecioNuevo).Hidden = False
         Next
      End With
   End Sub

   Private Function GetComoCalcular(dr As DataRow) As ComoCalcular
      If Boolean.Parse(dr("PorcActual").ToString()) Then
         Return ComoCalcular.PorcActual
      End If
      If Boolean.Parse(dr("SobreVenta").ToString()) Then
         Return ComoCalcular.SobreVenta
      End If
      If Boolean.Parse(dr("SobreCosto").ToString()) Then
         Return ComoCalcular.SobreCosto
      End If
      If Boolean.Parse(dr("DesdeFormula").ToString()) Then
         Return ComoCalcular.DesdeFormula
      End If
      Throw New Exception(String.Format("No se ha seleccionado ninguna forma de calculo para la lista de precios {0}", dr("Lista")))
   End Function

   Private Sub PosibilitaOrdenarGrilla2(Permite As Boolean)

      'If Permite Then
      Me.ugPrecios.DisplayLayout.Bands(0).Override.HeaderClickAction = HeaderClickAction.Default
      'Else
      'Me.ugPrecios.DisplayLayout.Bands(0).Override.HeaderClickAction = HeaderClickAction.Select
      'End If

   End Sub

   Private Function GetPrecioCostoNuevo(idProducto As String, precioFabricaNuevo As Decimal, precioCosto As Decimal,
                                        dR1 As Decimal, dR2 As Decimal, dR3 As Decimal, dR4 As Decimal) As Decimal

      Dim porcCosto1 As Decimal = Decimal.Round(Decimal.Parse(Me.txtPrecioCostoPorc.Text) / 100, 4)
      Dim precioCostoNuevo As Decimal = 0

      'Calcular el precio de costo nuevo
      If Me.rdbCostoFabrica.Checked Then
         'Calculo sobre el precio de fabrica
         If porcCosto1 <> 0 Then
            precioCostoNuevo = precioFabricaNuevo + Decimal.Round(precioFabricaNuevo * porcCosto1, _decimalesEnPrecio)
         Else
            precioCostoNuevo = precioFabricaNuevo

            precioCostoNuevo = precioCostoNuevo + precioCostoNuevo * dR1 / 100
            precioCostoNuevo = precioCostoNuevo + precioCostoNuevo * dR2 / 100
            precioCostoNuevo = precioCostoNuevo + precioCostoNuevo * dR3 / 100
            precioCostoNuevo = precioCostoNuevo + precioCostoNuevo * dR4 / 100
         End If
      Else

         If Me.rdbCostoDesdeFormula.Checked Then
            Dim formu As DataRow() = (From form As DataRow In Me._todosLosProductos.AsEnumerable()
                                      Where form.Field(Of String)("IdProducto").Trim() = idProducto
                                      Select form).ToArray()

            If formu.Length = 0 Then
               Throw New Exception(String.Format("No se encontró el producto '{0}' en la lista de formulas.", idProducto))
            End If

            Dim formula As Integer = 0
            Dim nombre As String = String.Empty
            For Each fr As DataRow In formu
               If IsNumeric(fr("IdFormula")) Then
                  formula = Int32.Parse(fr("IdFormula").ToString())
               End If
               nombre = fr("NombreProducto").ToString()
            Next

            If formula = 0 Then
               Throw New Exception(String.Format("El producto {0} - {1} no posee fórmula.", idProducto, nombre))
            End If

            Dim oProdComp As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
            precioCosto = oProdComp.GetPrecioCosto(actual.Sucursal.IdSucursal, idProducto, formula)
         End If

         'Calculo sobre el precio costo
         If porcCosto1 <> 0 Then
            precioCostoNuevo = precioCosto + Decimal.Round(precioCosto * porcCosto1, _decimalesEnPrecio)
         Else
            precioCostoNuevo = precioCosto
         End If
      End If

      'precioCostoNuevo = precioCosto

      precioCostoNuevo += Decimal.Parse(Me.txtPrecioCostoMonto.Text)

      'Retornar el nuevo precio de costo 
      Return precioCostoNuevo

   End Function

   Private Function GetPrecioVentaNuevo(idProducto As String,
                                        precioCosto As Decimal,
                                        precioCostoNuevo As Decimal,
                                        precioVenta As Decimal,
                                        idListaDePrecios As Integer,
                                        comoCalcular As ComoCalcular,
                                        porcRecargo As Decimal,
                                        monto As Decimal) As Decimal

      Dim precioVentaNuevo As Decimal = 0

      porcRecargo = porcRecargo / 100

      'Calcular el precio de venta nuevo
      Select Case comoCalcular
         Case ActualizarPreciosV2.ComoCalcular.PorcActual
            If precioCosto <> 0 Then
               precioVentaNuevo = precioCostoNuevo + Decimal.Round(precioCostoNuevo * porcRecargo, _decimalesEnPrecio)
            Else
               precioVentaNuevo = precioCostoNuevo
            End If
         Case ActualizarPreciosV2.ComoCalcular.SobreVenta
            'Calculo sobre el precio venta
            If porcRecargo <> 0 Then
               precioVentaNuevo = precioVenta + Decimal.Round(precioVenta * porcRecargo, _decimalesEnPrecio)
            Else
               precioVentaNuevo = precioVenta
            End If

         Case ActualizarPreciosV2.ComoCalcular.SobreCosto
            'Calculo sobre el precio de costo
            If porcRecargo <> 0 Then
               precioVentaNuevo = precioCostoNuevo + Decimal.Round(precioCostoNuevo * porcRecargo, _decimalesEnPrecio)
            Else
               precioVentaNuevo = precioCostoNuevo
            End If

         Case ActualizarPreciosV2.ComoCalcular.DesdeFormula
            Dim oProdComp As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()

            Dim formula As Integer
            formula = New Reglas.Productos().GetUno(idProducto).IdFormula

            precioVenta = oProdComp.GetPrecioVenta(actual.Sucursal.IdSucursal, idProducto, formula, idListaDePrecios)

            If porcRecargo <> 0 Then
               precioVentaNuevo = precioVenta + Decimal.Round(precioVenta * porcRecargo, _decimalesEnPrecio)
            Else
               precioVentaNuevo = precioVenta
            End If
         Case Else

      End Select

      precioVentaNuevo += monto

      If radRedondeoPrecioVenta.Checked Then
         Dim Redondeo As Integer = Integer.Parse(Me.txtRedondeoPrecioVenta.Text)

         'Momentaneamente se anula, hay que analizar porque se puso y como se puede reemplazar.
         'If Redondeo >= 2 And Not Me.chbAjusteA.Checked Then
         '   Redondeo = 4   'Al usuario le muestro 2 pero internamente calculo a 4.
         'End If

         precioVentaNuevo = Decimal.Round(precioVentaNuevo, Redondeo)

         If Me.chbAjusteA.Checked And precioVentaNuevo > 0 Then
            'Si ajustamos a 0
            If Me.chbAjusteA.Checked And Integer.Parse(txtAjusteA.Text) = 0 Then
               Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
               precioVentaNuevo = Decimal.Parse(Split(PrecioTemporal, ".")(0).Substring(0, Split(PrecioTemporal, ".")(0).Length() - 1) + txtAjusteA.Text)
            Else
               Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, Redondeo))
               precioVentaNuevo = Decimal.Parse(Strings.Mid(PrecioTemporal, 1, PrecioTemporal.Length() - 1) + txtAjusteA.Text)
            End If
         End If
      ElseIf radEnteroPrecioVenta.Checked Then

         precioVentaNuevo = precioVentaNuevo.MidRound(txtEnteroPrecioVenta.ValorNumericoPorDefecto(0UI), 0,
                                                      txtEnteroPrecioVentaBaseRedondeo.ValorNumericoPorDefecto(0US))

      End If

      'Retornar el nuevo precio de venta 
      Return precioVentaNuevo

   End Function

   Private Function GetPrecioFabricaNuevo(precioFabrica As Decimal) As Decimal
      Dim porcFabrica As Decimal = Decimal.Round(Decimal.Parse(Me.txtPorcenFabrica.Text) / 100, _decimalesEnPrecio)

      Dim precioFabricaNuevo As Decimal = 0

      'Calcular el precio de fabrica nuevo
      If porcFabrica <> 0 Then
         precioFabricaNuevo = precioFabrica + Decimal.Round(precioFabrica * porcFabrica, _decimalesEnPrecio)
      Else
         precioFabricaNuevo = precioFabrica
      End If
      'Retornar el nuevo precio de fabrica 
      Return precioFabricaNuevo
   End Function

   Private Sub CargarYGrabarPrecios2()

      Dim oProdS As Entidades.ProductoSucursal
      Dim oProdSP As Entidades.ProductoSucursalPrecio
      Dim precios As List(Of Entidades.ProductoSucursal) = New List(Of Entidades.ProductoSucursal)
      Dim Pregunto1 As Boolean = False
      Dim Pregunto2 As Boolean = False
      Dim Pregunto3 As Boolean = False
      Dim Pregunto4 As Boolean = False

      Me.tssInfo.Text = "Cargando datos..."
      Me.dgvListasPrecios.DataSource.ToString()

      Me.tssInfo.Text = "Recorriendo lista de productos..."

      Dim modulo As Integer = 10
      Dim i As Integer = 0
      Dim drCol As DataRow() = _productosAActualizar.Select("Sel")

      For Each dr As DataRow In drCol
         i += 1
         Me.tssInfo.Text = String.Format("Procesando...     {2}/{3} ({0} - {1})", dr("IdProducto").ToString().Trim(), dr("NombreProducto"), i, drCol.Length)
         If i Mod modulo = 0 Then
            Application.DoEvents()
         End If

         If Me.CambiaronLosPrecios2(dr) Then
            oProdS = New Entidades.ProductoSucursal()
            'Cargo los valores de la grilla al objeto productosSucursales
            With oProdS
               .Producto.IdProducto = dr("IdProducto").ToString.Trim()
               .Producto.NombreProducto = dr("NombreProducto").ToString.Trim()
               .Producto.ActualizaPreciosSucursalesAsociadas = Boolean.Parse(dr("ActualizaPreciosSucursalesAsociadas").ToString())
               If Not String.IsNullOrEmpty(dr("IdProveedor").ToString()) Then
                  .Producto.ProductoProveedorHabitual = New Reglas.ProductosProveedores().GetUno(Long.Parse(dr("IdProveedor").ToString()), .Producto.IdProducto)
                  If .Producto.ProductoProveedorHabitual IsNot Nothing Then

                     .Producto.ProductoProveedorHabitual.UltimoPrecioFabrica = Decimal.Parse(dr("PrecioFabricaNuevo").ToString())

                     .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = If(IsNumeric(dr("DescuentoRecargoPorcNuevo1")), Decimal.Parse(dr("DescuentoRecargoPorcNuevo1").ToString()), 0)
                     .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = If(IsNumeric(dr("DescuentoRecargoPorcNuevo2")), Decimal.Parse(dr("DescuentoRecargoPorcNuevo2").ToString()), 0)
                     .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = If(IsNumeric(dr("DescuentoRecargoPorcNuevo3")), Decimal.Parse(dr("DescuentoRecargoPorcNuevo3").ToString()), 0)
                     .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = If(IsNumeric(dr("DescuentoRecargoPorcNuevo4")), Decimal.Parse(dr("DescuentoRecargoPorcNuevo4").ToString()), 0)
                  End If
               End If

               .Sucursal.Id = Integer.Parse(dr("IdSucursal").ToString())
               .PrecioFabrica = If(IsNumeric(dr("PrecioFabricaNuevo")), Decimal.Parse(dr("PrecioFabricaNuevo").ToString()), 0)
               .PrecioCosto = If(IsNumeric(dr("PrecioCostoNuevo")), Decimal.Parse(dr("PrecioCostoNuevo").ToString()), 0)
               .Stock = Decimal.Parse(dr("Stock").ToString())
               .Usuario = actual.Nombre

               If Reglas.Publicos.UtilizaPrecioDeCompra AndAlso .PrecioFabrica < 0 Then
                  MessageBox.Show(String.Format("El producto '{0} - {1}' tiene el precio de Compra negativo, NO puede continuar.",
                                                dr("IdProductoSinEspacios"),
                                                dr("NombreProducto").ToString.Trim()),
                                  Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Return
               End If

               If .PrecioCosto < 0 Then
                  MessageBox.Show(String.Format("El producto '{0} - {1}' tiene el precio de Costo negativo, NO puede continuar.",
                                                dr("IdProductoSinEspacios").ToString(),
                                                dr("NombreProducto").ToString.Trim()),
                                  Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Return
               End If

               If Decimal.Parse(dr("PrecioCosto").ToString()) > 0 And Decimal.Parse(dr("PrecioCostoNuevo").ToString()) = 0 And Not Pregunto3 Then
                  If MessageBox.Show(String.Format("El producto '{0} - {1}'tiene el precio de Costo Nuevo es 0 (cero) pero el Actual NO, ¿continua en este caso y en los demas?",
                                                   dr("IdProductoSinEspacios").ToString(),
                                                   dr("NombreProducto").ToString()),
                                     Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                     Return
                  End If
                  Pregunto3 = True
               End If

               Me.tssInfo.Text = "Recorriendo listas..."
               For Each lis As Entidades.ListaDePrecios In Me._listasSelec
                  oProdSP = New Entidades.ProductoSucursalPrecio()
                  oProdSP.ProductoSucursal = oProdS
                  oProdSP.IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
                  oProdSP.ListaDePrecios = lis

                  Dim nc As NombresColumnas = GetNombresColumnas(lis.IdListaPrecios)

                  If Not IsNumeric(dr(nc.ColumnaPrecio)) Then dr(nc.ColumnaPrecio) = 0
                  If Not IsNumeric(dr(nc.ColumnaPrecioNuevo)) Then dr(nc.ColumnaPrecioNuevo) = 0

                  If Decimal.Parse(dr("PrecioCostoNuevo").ToString()) = Decimal.Parse(dr(nc.ColumnaPrecioNuevo).ToString()) And Not lis.PermiteUtilidadEnCero Then
                     MessageBox.Show(String.Format("Atención: En la lista {2} no esta permitido utilidad en cero,  El producto '{0} - {1}' el Precio de Venta Nuevo es igual al Precio Nuevo de Costo",
                                                    dr("IdProductoSinEspacios").ToString(),
                                                    dr("NombreProducto").ToString.Trim(),
                                                    lis.NombreListaPrecios),
                                      Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                     Return
                  End If

                  If Decimal.Parse(dr(nc.ColumnaPrecio).ToString()) > 0 And Decimal.Parse(dr(nc.ColumnaPrecioNuevo).ToString()) = 0 And Not Pregunto4 Then
                     If MessageBox.Show(String.Format("El producto '{0} - {1}' en la lista {2} tiene el precio de Venta Nuevo es 0 (cero) pero el Actual NO, ¿continua en este caso y en los demas?",
                                                      dr("IdProductoSinEspacios").ToString(),
                                                      dr("NombreProducto").ToString.Trim(),
                                                      lis.NombreListaPrecios),
                                        Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Return
                     End If
                     Pregunto4 = True
                  End If

                  oProdSP.PrecioVenta = Decimal.Parse(dr(nc.ColumnaPrecioNuevo).ToString())
                  oProdSP.Usuario = Entidades.Usuario.Actual.Nombre
                  .Precios.Add(oProdSP)
               Next

               'Pensado fundamentalmente cuando carga por primera vez, para no obligar a cargar manualmente todo y si pueda calcular.
               If Reglas.Publicos.UtilizaPrecioDeCompra AndAlso .PrecioCosto > .PrecioFabrica And Not Pregunto1 Then
                  If MessageBox.Show(String.Format("El producto '{0} - {1}' tiene el precio de costo mayor al precio de compra, ¿continua en este caso y en los demas?",
                                                   dr("IdProductoSinEspacios").ToString(),
                                                   dr("NombreProducto").ToString.Trim()),
                                     Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                     Return
                  End If
                  Pregunto1 = True
               End If

               If Not Pregunto2 Then
                  For Each pre As Entidades.ProductoSucursalPrecio In .Precios
                     If .PrecioCosto > pre.PrecioVenta Then
                        If MessageBox.Show(String.Format("El producto '{0} - {1}' tiene el precio de Costo mayor al precio de Venta en la lista {2}, continua en este caso y en los demas ?",
                                                         dr("IdProducto").ToString.Trim(),
                                                         dr("NombreProducto").ToString.Trim(),
                                                         pre.ListaDePrecios.NombreListaPrecios),
                                           Me.Text,
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question,
                                           MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                           Return
                        End If
                     End If
                  Next
                  Pregunto2 = True
               End If

            End With
            'Agrego un precio a la lista
            precios.Add(oProdS)
         End If
         Me.tssInfo.Text = "Terminando el calculo..."

         Me.tspBarra.Value += 1

         'End If

      Next

      If precios.Count = 0 Then
         MessageBox.Show("ATENCION: NO Ajustó Ningun Precio.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Exit Sub
      End If

      Me._precios = precios

      Me.Cursor = Cursors.WaitCursor

      Me.tssInfo.Text = "Aguarde, se estan grabando los nuevos precios..."
      Application.DoEvents()

      Me.GrabarPrecios()

      Me.tssInfo.Text = ""

      MessageBox.Show("Precios grabados con exito!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.CargaGrillaDetalle()
   End Sub

   Private Function CambiaronLosPrecios2(dr As DataRow) As Boolean

      If Not IsNumeric(dr("PrecioFabricaNuevo")) Then dr("PrecioFabricaNuevo") = 0

      If Decimal.Parse(dr("PrecioFabrica").ToString()) <> Decimal.Parse(dr("PrecioFabricaNuevo").ToString()) Then
         Return True
      End If

      If Not IsNumeric(dr("PrecioCostoNuevo")) Then dr("PrecioCostoNuevo") = 0

      If Decimal.Parse(dr("PrecioCosto").ToString()) <> Decimal.Parse(dr("PrecioCostoNuevo").ToString()) Then
         Return True
      End If

      Dim prec As Decimal
      For Each lis As Entidades.ListaDePrecios In Me._listas
         Dim nc As NombresColumnas = GetNombresColumnas(lis.IdListaPrecios)

         'Al ponerlo en negativo, fuerzo que la primera vez que hago precios para una lista nueva, inserte los registros aunque sea en cero.
         prec = Decimal.MinValue   '0
         If IsNumeric(dr(nc.ColumnaPrecio)) Then
            prec = Decimal.Parse(dr(nc.ColumnaPrecio).ToString())
         End If
         If prec <> Decimal.Parse(dr(nc.ColumnaPrecioNuevo).ToString()) Then
            Return True
         End If
      Next
      Return False
   End Function

   Private Function ValidarCalcular() As Boolean

      If String.IsNullOrEmpty(Me.txtPrecioCostoPorc.Text.Trim()) Then
         MessageBox.Show("El Porcentaje de Costo es Inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtPrecioCostoPorc.Focus()
         Return False
      End If

      If String.IsNullOrEmpty(Me.txtPrecioCostoMonto.Text.Trim()) Then
         MessageBox.Show("El Monto de Costo es Inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtPrecioCostoMonto.Focus()
         Return False
      End If

      For Each dr As DataGridViewRow In Me.dgvListasPrecios.Rows
         If String.IsNullOrEmpty(dr.Cells("Porcentaje").Value.ToString.Trim()) Then
            MessageBox.Show("Existe al menos un Porcentaje de Venta Inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dgvListasPrecios.Focus()
            Return False
         End If
         If String.IsNullOrEmpty(dr.Cells("Monto").Value.ToString.Trim()) Then
            MessageBox.Show("Existe al menos un Monto de Venta Inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.dgvListasPrecios.Focus()
            Return False
         End If
      Next

      'saco la cuenta de los productos marcados
      Dim cantSelec As Integer = 0
      Dim todos As Boolean = True

      For Each drl As UltraGridRow In Me.ugPrecios.Rows
         If Boolean.Parse(drl.Cells("Sel").Value.ToString()) Then
            cantSelec += 1
         End If
      Next
      'si son distintos estos valores es porque selecciono solo algunos de los registros
      If cantSelec <> Me.ugPrecios.Rows.Count Then
         todos = False
      End If


      If DirectCast(cmbMarca.SelectedValue, Entidades.Sucursal.ValoresFijosIdSucursal) = Entidades.Sucursal.ValoresFijosIdSucursal.Todos And
         DirectCast(cmbRubro.SelectedValue, Entidades.Sucursal.ValoresFijosIdSucursal) = Entidades.Sucursal.ValoresFijosIdSucursal.Todos And
         Not Me.chbSubRubro.Checked And
         Not Me.chbProducto.Checked And Not Me.chbProveedor.Checked And Not Me.chbFechaActualizado.Checked And
         Not Me.chbSinCosto.Checked And Not Me.chbSinVenta.Checked And Me.cboCompuestos.SelectedIndex = 0 And
         String.IsNullOrEmpty(Me.txtCodigo.Text) And String.IsNullOrEmpty(Me.txtProducto.Text) And todos Then
         If MessageBox.Show("No Activo Ningun Filtro, ¿Está Seguro de Calcular sobre TODOS los Productos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
            Return False
         End If
      End If

      'Si se indica que se ajusta, y no indica a cuanto se debe ajustar, salgo.
      If Me.chbAjusteA.Checked And String.IsNullOrEmpty(Me.txtAjusteA.Text) Then
         MessageBox.Show("Indico un ajuste de redondeo pero no lo cargo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtAjusteA.Focus()
         Return False
      End If

      If cantSelec = 0 Then
         MessageBox.Show("No seleccionó ningún producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTodos.Focus()
         Return False
      End If

      Return True

   End Function

   Private Sub GrabarPrecios()
      Try
         Dim oProdSucu As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
         Try
            AddHandler oProdSucu.AvanceModificarPrecios, AddressOf oProdSucu_AvanceModificarPrecios
            'Envio a grabar los nuevos precios
            oProdSucu.ModificarPrecios(Me._precios, IdFuncion)
         Finally
            RemoveHandler oProdSucu.AvanceModificarPrecios, AddressOf oProdSucu_AvanceModificarPrecios
         End Try
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub oProdSucu_AvanceModificarPrecios(sender As Object, e As Reglas.ProductosSucursales.AvanceModificarPreciosEventArgs)
      Try
         Me.tssInfo.Text = String.Format("Grabando...     {2}/{3} ({0} - {1})", e.IdProducto.Trim(), e.NombreProducto, e.Indice, e.Total)
         If e.Indice Mod 10 = 0 Then
            Application.DoEvents()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#Region "Metodos NombreColumnas"
   Private _cacheNombresColumnas As Dictionary(Of Integer, NombresColumnas)
   Private Function GetNombresColumnas(idListaPrecios As Integer) As NombresColumnas
      If _cacheNombresColumnas Is Nothing Then _cacheNombresColumnas = New Dictionary(Of Integer, NombresColumnas)()
      If Not _cacheNombresColumnas.ContainsKey(idListaPrecios) Then
         _cacheNombresColumnas.Add(idListaPrecios,
                                   New NombresColumnas() With {.ColumnaPrecio = String.Format("IdLista_{0}", idListaPrecios),
                                                               .ColumnaPrecioNuevo = String.Format("IdListaNuevo_{0}", idListaPrecios),
                                                               .ColumnaPorc = String.Format("Porc_{0}", idListaPrecios),
                                                               .ColumnaPorcNuevo = String.Format("PorcNuevo_{0}", idListaPrecios),
                                                               .FechaActualizacionPrecio = String.Format("fecha_actualizacion_precio_{0}", idListaPrecios)})
      End If
      Return _cacheNombresColumnas(idListaPrecios)
   End Function

   Private Class NombresColumnas
      Public Property ColumnaPrecio As String
      Public Property ColumnaPrecioNuevo As String
      Public Property ColumnaPorc As String
      Public Property ColumnaPorcNuevo As String
      Public Property Monto As String
      Public Property FechaActualizacionPrecio As String
   End Class
#End Region

   Private _comprasProductos As List(Of Entidades.MovimientoStockProducto)
   Private _tipoComprobanteCompra As Entidades.TipoComprobante
   Private _categoriaFiscalProveedor As Entidades.CategoriaFiscal
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _cotizacionDolar As Decimal
   Public Overloads Function ShowDialog(owner As Form, movCompra As Entidades.MovimientoStock) As DialogResult
      'cp As List(Of Entidades.MovimientoCompraProducto), categoriaFiscalProveedor As Entidades.CategoriaFiscal) As DialogResult
      Dim cp = movCompra.Productos
      If cp Is Nothing OrElse cp.Count = 0 Then Return Windows.Forms.DialogResult.OK
      _comprasProductos = cp
      _tipoComprobanteCompra = movCompra.Compra.TipoComprobante
      _categoriaFiscalProveedor = movCompra.Compra.Proveedor.CategoriaFiscal
      _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)
      _cotizacionDolar = movCompra.Compra.CotizacionDolar
      'Como está viniendo de una pantalla que va a predefinir la búsqueda, no permite refrescar para no perder esa búsqueda predefinida.
      tsbRefrescar.Visible = False
      tsbImportarExcel.Visible = False
      ToolStripSeparator1.Visible = False
      ToolStripSeparator4.Visible = False
      Return ShowDialog(owner)
   End Function

#End Region

   Private Sub chbMoneda_CheckedChanged(sender As Object, e As EventArgs) Handles chbMoneda.CheckedChanged
      Try
         If chbMoneda.Checked Then
            cmbMoneda.SelectedIndex = 0
            cmbMoneda.Enabled = True
            cmbMoneda.Focus()
         Else
            cmbMoneda.SelectedIndex = -1
            cmbMoneda.Enabled = False
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub pnlFiltros_DoubleClick(sender As Object, e As EventArgs) Handles pnlFiltros.DoubleClick
      Try
         Me.FilterManager1.SeleccionarFiltro()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         '# Actualizo los SubRubros segun el Rubro seleccionado
         If Me.cmbRubro.DataSource IsNot Nothing AndAlso Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.Inicializar(False, True, True, Me.cmbRubro.GetRubros())
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbSubRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubro.AfterSelectedIndexChanged
      Try
         '# Actualizo los SubRubros segun el Rubro seleccionado
         If Me.cmbSubRubro.DataSource IsNot Nothing AndAlso Me.chbSubSubRubro.Checked Then
            Me.cmbSubSubRubro.Inicializar(False, True, True, Me.cmbSubRubro.GetSubRubros())
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbConStock_CheckedChanged(sender As Object, e As EventArgs) Handles chbConStock.CheckedChanged
      cmbConStock.Enabled = chbConStock.Checked
      If Not chbConStock.Checked Then
         cmbConStock.SelectedIndex = -1
      End If
   End Sub

   Private Sub radRedondeo_CheckedChanged(sender As Object, e As EventArgs) Handles radRedondeoPrecioVenta.CheckedChanged, radEnteroPrecioVenta.CheckedChanged
      TryCatched(
      Sub()
         txtEnteroPrecioVenta.Enabled = radEnteroPrecioVenta.Checked
         txtEnteroPrecioVentaBaseRedondeo.Enabled = radEnteroPrecioVenta.Checked
         txtRedondeoPrecioVenta.Enabled = radRedondeoPrecioVenta.Checked
         chbAjusteA.Enabled = radRedondeoPrecioVenta.Checked
         txtAjusteA.Enabled = radRedondeoPrecioVenta.Checked
      End Sub)
   End Sub
End Class