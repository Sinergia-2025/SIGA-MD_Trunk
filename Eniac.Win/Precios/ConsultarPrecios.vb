Public Class ConsultarPrecios

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(esdeVentas As String, esDeCompras As String)
      Me.New()

      cmbEsDeCompras.Enabled = False
      cmbEsDeVentas.Enabled = False

      _esDeVentas = esdeVentas
      _esDeCompras = esDeCompras
   End Sub

#End Region

#Region "Campos"

   Private _publicos As Publicos
   Private _MostrarCosto As Boolean
   Private _estaCargando As Boolean = True

   Private _paraBusqueda As Boolean = False
   Private _decimalesEnDescRec As Integer

   Private _esDeCompras As String
   Private _esDeVentas As String
   Public ConsultarAutomaticamente As Boolean = False

   Private _tit As Dictionary(Of String, String)
   Private _titStockPorSucursal As Dictionary(Of String, String)

   '-- REQ-34669.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
   Private _DatosAtributoProducto As DataTable
   Private _PrecioLista As Boolean = False
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            lblDescRecCantidad.Text = String.Empty
            txtObservaciones.Text = String.Empty

            PreferenciasLeer(ugDetalle, tsbPreferencias)

            _publicos = New Publicos()
            _publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios)
            _decimalesEnDescRec = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec

            cmbSucursales.Initializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, IdFuncion)
            cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
            cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

            pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
            pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
            pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

            'Seguridad del campo Precio de Costo
            _MostrarCosto = New Reglas.Usuarios().TienePermisos("ConsultarPrecios-PrecioCosto")

            chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

            chbEmbalaje.Visible = Reglas.Publicos.ConsultarPreciosConEmbalaje
            chbEmbalaje.Checked = Me.chbEmbalaje.Visible

            cmbEsOferta.SelectedIndex = 0
            cmbEsDeVentas.SelectedIndex = 0
            cmbEsDeCompras.SelectedIndex = 0

            If ConsultarAutomaticamente Then
               cmbEsDeVentas.Text = _esDeVentas
               cmbEsDeCompras.Text = _esDeCompras
            End If


            chbVerStockReservado.Checked = Reglas.Publicos.VisualizaStockReservado
            chbVerStockDefectuoso.Checked = Reglas.Publicos.VisualizaStockDefectuoso
            chbVerStockFuturo.Checked = Reglas.Publicos.VisualizaStockFuturo
            chbVerStockFuturoReservado.Checked = Reglas.Publicos.VisualizaStockFuturoReservado

            chbVerStockReservado.Visible = Reglas.Publicos.UtilizaStockReservado
            chbVerStockDefectuoso.Visible = Reglas.Publicos.UtilizaStockDefectuoso
            chbVerStockFuturo.Visible = Reglas.Publicos.UtilizaStockFuturo
            chbVerStockFuturoReservado.Visible = Reglas.Publicos.UtilizaStockFuturoReservado
            pnlVerStock.Visible = chbVerStockReservado.Visible Or chbVerStockDefectuoso.Visible Or chbVerStockFuturo.Visible Or chbVerStockFuturoReservado.Visible

            _publicos.CargaComboDesdeEnum(cmbAfectaStock, GetType(Entidades.Publicos.SiNoTodos))
            cmbAfectaStock.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS


            If Reglas.Publicos.PreciosPriorizaCodigoYDescripcion Then
               radCodigoYDescripcion.Checked = True
            Else
               radCodigoODescripcion.Checked = True
            End If

            Me.SetearColumnas()

            Me.txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("#0.00")

            '------------
            _publicos.CargaComboMonedas(cmbMoneda)

            DirectCast(Me.cmbMoneda.DataSource, DataTable).Rows.InsertAt(DirectCast(Me.cmbMoneda.DataSource, DataTable).NewRow, 0)
            DirectCast(Me.cmbMoneda.DataSource, DataTable).Rows(0)("IdMoneda") = -1
            DirectCast(Me.cmbMoneda.DataSource, DataTable).Rows(0)("NombreMoneda") = "del producto"
            'Me.cmbMoneda.SelectedIndex = 0
            cmbMoneda.SelectedValue = Reglas.Publicos.MonedaParaConsultarPrecios
            '------------------------------

            ''Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
            'Me.ugdDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
            'Me.ugdDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

            'Me.pnlPrincipal.Focus()
            Me.txtCodigo.Select()

            Me._estaCargando = False

            _tit = GetColumnasVisiblesGrilla(ugDetalle)
            _titStockPorSucursal = GetColumnasVisiblesGrilla(ugStockPorSucusal)

            _PrecioLista = _tit.ContainsKey("PrecioListaConIVA") Or _tit.ContainsKey("PrecioListaSinIVA")

            If _paraBusqueda And (Not String.IsNullOrWhiteSpace(txtCodigo.Text) Or Not String.IsNullOrWhiteSpace(txtProducto.Text)) Then
               Me.CargaGrillaDetalle()
            End If

            '-- REQ-35218.- ---------------------------------
            VerificaValorAtributos()
            tbcInformeStock.TabPages.Remove(tbpAtributoProducto)
            '------------------------------------------------
         End Sub)

   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(
      Sub()
         If _paraBusqueda Then
            If (Not String.IsNullOrWhiteSpace(txtCodigo.Text) Or Not String.IsNullOrWhiteSpace(txtProducto.Text)) Then
               ugDetalle.Focus()
               If ugDetalle.Rows.Count > 0 Then
                  ugDetalle.ActiveRow = ugDetalle.Rows(0)
               End If
            Else
               txtProducto.Focus()
            End If
         End If
      End Sub)
      TryCatched(
      Sub()
         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         pnlPrincipalFiltros.AutoSize = True
         Dim tempSize = grbConsultar.Size
         pnlPrincipalFiltros.AutoSize = False
         pnlPrincipalFiltros.Size = tempSize
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnBuscar.PerformClick()
      ElseIf keyData = Keys.F12 Then
         tsbProductosProveedor.PerformClick()
      ElseIf keyData = Keys.Escape Then
         If _paraBusqueda Then
            DialogResult = Windows.Forms.DialogResult.Cancel
            Close()
         End If
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"
   Private Sub tbcInformeStock_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcInformeStock.SelectedIndexChanged
      TryCatched(
         Sub()
            If tbcInformeStock.SelectedTab.Name = tbpAtributoProducto.Name Then
               CargaDatosStockAtributos(ugStockPorSucusal.ActiveRow.Cells("idSucursal").Value.ToString().ToInt32.IfNull())
            Else
               ugStockAtributo.DataSource = Nothing
            End If
         End Sub)
   End Sub
   Private Sub ugDetalle_ClickCell(sender As Object, e As ClickCellEventArgs) Handles ugDetalle.ClickCell
      TryCatched(
         Sub()
            VisualizaStockAtributoProducto()
            CargaStockDeposito(ugDetalle.ActiveRow.Cells("IdProducto").Value.ToString().Trim())
         End Sub)
   End Sub

   Private Sub ugStockPorSucusal_ClickCell(sender As Object, e As ClickCellEventArgs) Handles ugStockPorSucusal.ClickCell
      TryCatched(
         Sub()
            '-- Por sucursal.- --------------------
            If tbcInformeStock.SelectedTab.Name = tbpAtributoProducto.Name Then
               CargaDatosStockAtributos(ugStockPorSucusal.ActiveRow.Cells("idSucursal").Value.ToString().ToInt32.IfNull())
            End If
            '--------------------------------------
         End Sub)
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            txtCodigo.Text = String.Empty
            txtProducto.Text = String.Empty

            With tbcInformeStock.TabPages
               If tbcInformeStock.TabCount = 2 Then
                  .Remove(tbpAtributoProducto)
               End If
            End With

            cmbListaDePrecios.SelectedIndex = 0

            cmbSucursales.Refrescar()
            cmbMarcas.Refrescar()
            cmbRubros.Refrescar()

            Dim Sucursales(10) As Integer
            Sucursales(0) = 0

            chbConPrecio.Checked = False
            chbConStock.Checked = False
            chbInactivos.Checked = False
            chbEmbalaje.Checked = False

            chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

            chbEmbalaje.Visible = Reglas.Publicos.ConsultarPreciosConEmbalaje
            chbEmbalaje.Checked = Me.chbEmbalaje.Visible
            cmbEsOferta.SelectedIndex = 0

            txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("#0.00")

            'Me.cmbMoneda.SelectedIndex = 0
            cmbMoneda.SelectedValue = Reglas.Publicos.MonedaParaConsultarPrecios

            cmbEsDeVentas.SelectedIndex = 0
            cmbEsDeCompras.SelectedIndex = 0

            Dim oProd = New Reglas.Productos()

            ugDetalle.ClearFilas()
            ugStockPorSucusal.ClearFilas()

            lblDetalleProducto.Text = String.Empty
            ugStockDepositos.ClearFilas()
            cmbAfectaStock.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

            tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"

            txtCodigo.Focus()

         End Sub)
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged, chbVerStockReservado.CheckedChanged, chbVerStockFuturoReservado.CheckedChanged, chbVerStockFuturo.CheckedChanged, chbVerStockDefectuoso.CheckedChanged
      TryCatched(Sub() If Not _estaCargando Then SetearColumnas())
   End Sub

   Private Sub chbEmbalaje_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmbalaje.CheckedChanged
      TryCatched(Sub() If Not _estaCargando Then SetearColumnas())
   End Sub

   Private Sub chbVerStockReservado_CheckedChanged(sender As Object, e As EventArgs) Handles chbVerStockReservado.CheckedChanged, chbVerStockReservado.CheckedChanged
      TryCatched(Sub() If Not _estaCargando Then SetearColumnas())
   End Sub

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
         Sub()
            With tbcInformeStock.TabPages
               If tbcInformeStock.TabCount = 2 Then
                  .Remove(tbpAtributoProducto)
               End If
            End With

            CargaGrillaDetalle()
            If txtCodigo.Text.Trim().Length > 0 Then
               txtCodigo.Focus()
               txtCodigo.SelectAll()
            Else
               txtProducto.Focus()
               txtProducto.SelectAll()
            End If
            If _paraBusqueda AndAlso ugDetalle.Rows.Count > 0 Then
               ugDetalle.Focus()
            End If
            ugDetalle.Refresh()

            If ugDetalle.Selected.Rows.Count = 0 AndAlso ugDetalle.ActiveRow IsNot Nothing Then
               ugDetalle.ActiveRow.Selected = True
            End If
            CargaStockDeposito(If(String.IsNullOrEmpty(txtCodigo.Text), ugDetalle.ActiveRow.Cells("IdProducto").Value.ToString().Trim(), txtCodigo.Text))
         End Sub)
   End Sub

   Private Sub tsbProductosProveedor_Click(sender As Object, e As EventArgs) Handles tsbProductosProveedor.Click
      TryCatched(
         Sub()
            'si no seleccionó una fila no le deja continuar
            If ugDetalle.ActiveRow Is Nothing Then
               Exit Sub
            End If
            '----------
            Using fr = New InfProductosProveedores(ugDetalle.ActiveRow.Cells("IdProducto").Value.ToString().Trim())
               fr.ConsultarAutomaticamente = True
               fr.ShowDialog(Me)
            End Using
         End Sub)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Public Property IdProductoDevuelta As String

   Private Sub ugDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles ugDetalle.KeyDown
      TryCatched(Sub() If e.KeyCode = Keys.Enter Then Aceptar())
   End Sub

   Private Sub ugDetalle_Enter(sender As Object, e As EventArgs) Handles ugDetalle.Enter
      TryCatched(Sub() If _paraBusqueda Then AcceptButton = Nothing)
   End Sub

   Private Sub ugDetalle_Leave(sender As Object, e As EventArgs) Handles ugDetalle.Leave
      TryCatched(Sub() AcceptButton = btnBuscar)
   End Sub

   Private Sub ugDetalle_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugDetalle.DoubleClickRow
      TryCatched(Sub() Aceptar())
   End Sub

   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      TryCatched(
         Sub()
            CargarGrillaStockPorSucursal()

            lblDescRecCantidad.Text = String.Empty
            If ugDetalle.ActiveRow IsNot Nothing AndAlso
               ugDetalle.ActiveRow.ListObject IsNot Nothing Then
               txtObservaciones.Text = ugDetalle.ActiveRow.Cells("Observacion").Value.ToString().Trim()


               Dim stb As StringBuilder = New StringBuilder()
               Dim UnidHasta1 = 0D
               Dim UnidHasta2 = 0D
               Dim UnidHasta3 = 0D
               Dim UnidHasta4 = 0D
               Dim UnidHasta5 = 0D
               If Not String.IsNullOrWhiteSpace(ugDetalle.ActiveRow.Cells("UnidHasta1").Value.ToString()) Then
                  UnidHasta1 = Decimal.Parse(ugDetalle.ActiveRow.Cells("UnidHasta1").Value.ToString())
               End If
               If Not String.IsNullOrWhiteSpace(ugDetalle.ActiveRow.Cells("UnidHasta2").Value.ToString()) Then
                  UnidHasta2 = Decimal.Parse(ugDetalle.ActiveRow.Cells("UnidHasta2").Value.ToString())
               End If
               If Not String.IsNullOrWhiteSpace(ugDetalle.ActiveRow.Cells("UnidHasta3").Value.ToString()) Then
                  UnidHasta3 = Decimal.Parse(ugDetalle.ActiveRow.Cells("UnidHasta3").Value.ToString())
               End If
               If Not String.IsNullOrWhiteSpace(ugDetalle.ActiveRow.Cells("UnidHasta4").Value.ToString()) Then
                  UnidHasta4 = Decimal.Parse(ugDetalle.ActiveRow.Cells("UnidHasta4").Value.ToString())
               End If
               If Not String.IsNullOrWhiteSpace(ugDetalle.ActiveRow.Cells("UnidHasta5").Value.ToString()) Then
                  UnidHasta5 = Decimal.Parse(ugDetalle.ActiveRow.Cells("UnidHasta5").Value.ToString())
               End If

               Dim UHPorc1 = 0D
               Dim UHPorc2 = 0D
               Dim UHPorc3 = 0D
               Dim UHPorc4 = 0D
               Dim UHPorc5 = 0D
               If Not String.IsNullOrWhiteSpace(ugDetalle.ActiveRow.Cells("UHPorc1").Value.ToString()) Then
                  UHPorc1 = Decimal.Parse(ugDetalle.ActiveRow.Cells("UHPorc1").Value.ToString())
               End If
               If Not String.IsNullOrWhiteSpace(ugDetalle.ActiveRow.Cells("UHPorc2").Value.ToString()) Then
                  UHPorc2 = Decimal.Parse(ugDetalle.ActiveRow.Cells("UHPorc2").Value.ToString())
               End If
               If Not String.IsNullOrWhiteSpace(ugDetalle.ActiveRow.Cells("UHPorc3").Value.ToString()) Then
                  UHPorc3 = Decimal.Parse(ugDetalle.ActiveRow.Cells("UHPorc3").Value.ToString())
               End If
               If Not String.IsNullOrWhiteSpace(ugDetalle.ActiveRow.Cells("UHPorc4").Value.ToString()) Then
                  UHPorc4 = Decimal.Parse(ugDetalle.ActiveRow.Cells("UHPorc4").Value.ToString())
               End If
               If Not String.IsNullOrWhiteSpace(ugDetalle.ActiveRow.Cells("UHPorc5").Value.ToString()) Then
                  UHPorc5 = Decimal.Parse(ugDetalle.ActiveRow.Cells("UHPorc5").Value.ToString())
               End If

               If UnidHasta1 <> 0 Then
                  stb.AppendFormat("Desde {0:N2} unidades ==> {1} %", UnidHasta1, UHPorc1.ToString("N" + _decimalesEnDescRec.ToString()))
               End If
               If UnidHasta2 <> 0 Then
                  stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", UnidHasta2, UHPorc2.ToString("N" + _decimalesEnDescRec.ToString()))
               End If
               If UnidHasta3 <> 0 Then
                  stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", UnidHasta3, UHPorc3.ToString("N" + _decimalesEnDescRec.ToString()))
               End If
               If UnidHasta4 <> 0 Then
                  stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", UnidHasta4, UHPorc4.ToString("N" + _decimalesEnDescRec.ToString()))
               End If
               If UnidHasta5 <> 0 Then
                  stb.AppendLine().AppendFormat("Desde {0:N2} unidades ==> {1} %", UnidHasta5, UHPorc5.ToString("N" + _decimalesEnDescRec.ToString()))
               End If
               lblDescRecCantidad.Text = stb.ToString()
            End If
         End Sub)
   End Sub

#Region "Eventos Codigo y/o Descripcion"
   Private Sub radCodigoDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles radCodigoYDescripcion.CheckedChanged, radCodigoODescripcion.CheckedChanged
      Try
         If radCodigoODescripcion.Checked Then
            If Not String.IsNullOrEmpty(txtCodigo.Text) Then
               _textChangedInternal = True
               txtProducto.Text = String.Empty
               _textChangedInternal = False
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private _textChangedInternal As Boolean = False
   Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
      If Not _textChangedInternal Then
         If radCodigoODescripcion.Checked Then
            _textChangedInternal = True
            txtProducto.Text = String.Empty
            _textChangedInternal = False
         End If
      End If
      CargaStockDeposito(txtCodigo.Text)
   End Sub

   Private Sub txtProducto_TextChanged(sender As Object, e As EventArgs) Handles txtProducto.TextChanged
      If Not _textChangedInternal Then
         If radCodigoODescripcion.Checked Then
            _textChangedInternal = True
            txtCodigo.Text = String.Empty
            _textChangedInternal = False
         End If
      End If
      CargaStockDeposito(txtCodigo.Text)
   End Sub
#End Region

   Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
      Try
         If cmbMoneda.SelectedIndex = 0 Then
            txtCotizacionDolar.Enabled = False
            txtCotizacionDolar.Text = "1.00"
         Else
            txtCotizacionDolar.Enabled = True
            txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
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

#Region "Metodos"
   Private Sub CargaStockDeposito(idProducto As String)
      lblDetalleProducto.Text = String.Empty
      If ugDetalle.ActiveRow IsNot Nothing AndAlso
               ugDetalle.ActiveRow.ListObject IsNot Nothing AndAlso
               TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView AndAlso
               DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then
         lblDetalleProducto.Text = String.Format("{0} - {1}", ugDetalle.ActiveRow.Cells("IdProducto").Value.ToString().Trim(), ugDetalle.ActiveRow.Cells("NombreProducto").Value.ToString().Trim())
         '-- Carga Stock y Distribucion de Producto en Suc-Dep-Ubi.-
         ugStockDepositos.DataSource = New Reglas.Productos().GetProductosDepositos(idProducto, actual.Sucursal.IdSucursal, String.Empty)
         ugStockDepositos.AgregarTotalesSuma({"Stock"})
         ugStockDepositos.AgregarFiltroEnLinea({"TipoDeposito"})
         '----------------------------------------------------------
      End If

   End Sub
   Private Sub SeteaAtributoProductoSource()
      ugStockAtributo.DataSource = Nothing
      ugStockAtributo.DataSource = _DatosAtributoProducto
   End Sub
   Private Sub FormateaGrilla()
      With ugStockAtributo.DisplayLayout.Bands(0)
         '-- Configura solo las visibles.- --
         .Columns("IdAtributo").Hidden = True
         If (ugDetalle.ActiveRow.Cells("GrupoAtributo02").Value.ToString().ToInt32.IfNull() + ugDetalle.ActiveRow.Cells("TipoAtributo02").Value.ToString().ToInt32.IfNull()) > 0 Then
            .Columns("DescripcionAtributo").Header.Caption = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion
         Else
            .Columns("DescripcionAtributo").Hidden = True
         End If

         '-- Recorre Columnas y establece el Header.- ------------
         For Each col In .Columns.OfType(Of UltraGridColumn).Where(Function(c) c.Key.StartsWith("Atrib1_"))
            col.Header.Caption = col.Header.Caption.Split("_"c)(2)
            col.Header.Appearance.TextHAlign = HAlign.Center
            col.CellAppearance.TextHAlign = HAlign.Right
            col.CellActivation = Activation.NoEdit
            '-- REQ-35481.- Establece Formato de los Valores.- --- 
            col.Format = "N0"
         Next
         '--------------------------------------------------------
      End With
   End Sub
   Private Sub CargaDatosStockAtributos(idSucursal As Integer)
      '-- Recupera Datos Generales.- -----
      _DatosAtributoProducto = New Reglas.AtributosProductos().GetStockAtributoProductos(ugDetalle.ActiveRow.Cells("idProducto").Value.ToString().Trim(),
                                                                                         idSucursal,
                                                                                         ugDetalle.ActiveRow.Cells("GrupoAtributo01").Value.ToString().ToInt32.IfNull(),
                                                                                         ugDetalle.ActiveRow.Cells("TipoAtributo01").Value.ToString().ToInt32.IfNull(),
                                                                                         ugDetalle.ActiveRow.Cells("GrupoAtributo02").Value.ToString().ToInt32.IfNull(),
                                                                                         ugDetalle.ActiveRow.Cells("TipoAtributo02").Value.ToString().ToInt32.IfNull())
      '-- Carga los datos a la grilla.- --
      SeteaAtributoProductoSource()
      '-- Formatea Grilla.- --------------
      FormateaGrilla()
      '-----------------------------------------------------------------------------------------------------
   End Sub
   Private Sub VisualizaStockAtributoProducto()
      Try
         If ugDetalle.ActiveRow Is Nothing Then Exit Sub

         With tbcInformeStock.TabPages
            If ugDetalle.ActiveRow.Cells("Atributos").Value.ToString().ToInt32() > 0 Then
               If tbcInformeStock.TabCount = 1 Then
                  .Insert(1, tbpAtributoProducto)
               End If
            Else
               .Remove(tbpAtributoProducto)
            End If
         End With
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   ''' <summary>
   ''' Obtienen los Nombres de los Tipos de Atributos de Parametros.- ----------------
   ''' </summary>
   Private Sub VerificaValorAtributos()
      tbpAtributoProducto.Text = ""
      '-- Atributo 001.- -------------------------------------------------------------
      If TipoAtributo01 > 0 And TipoAtributo02 > 0 Then
         '-- Carga Valores Check.- ---------------------------------------------------
         tbpAtributoProducto.Text = String.Format("{0}-{1}",
                                                  New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion,
                                                  New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion)
      End If
   End Sub
   Private Sub CargarGrillaStockPorSucursal()
      Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         If Not String.IsNullOrWhiteSpace(dr.Field(Of String)("IdProducto")) Then

            Dim dtDetalle = New Reglas.Productos().GetStockPorProducto(dr.Field(Of String)("IdProducto").Trim())

            ugStockPorSucusal.DataSource = dtDetalle
            AjustarColumnasGrilla(ugStockPorSucusal, _titStockPorSucursal)

            ugStockPorSucusal.Rows.OfType(Of UltraGridRow).
                  Where(Function(udr)
                           Dim dr1 = ugStockPorSucusal.FilaSeleccionada(Of DataRow)(udr)
                           If dr1 IsNot Nothing Then
                              Dim result = dr1.Field(Of Integer)("IdSucursal") = actual.Sucursal.Id
                              Return result
                           End If
                           Return False
                        End Function).ToList().
                        ForEach(Sub(udr1) udr1.Activate())


            If ugDetalle.Rows.Count >= 1 Then
               VisualizaStockAtributoProducto()
            End If

         End If
      End If
   End Sub
   Private Sub CargaGrillaDetalle()

      Dim sucs = cmbSucursales.GetSucursales().ToList()
      Dim oProd As Reglas.Productos = New Reglas.Productos()
      Dim dtDetalle = oProd.GetPrecios(sucs, cmbListaDePrecios.ValorSeleccionado(Of Integer),
                                       cmbMarcas.GetMarcas(todosVacio:=True).ToList(),
                                       cmbModelos.GetModelos(todosVacio:=True).ToList(),
                                       cmbRubros.GetRubros(todosVacio:=True).ToList(),
                                       cmbSubRubros.GetSubRubros(todosVacio:=True).ToList(),
                                       cmbSubSubRubros.GetSubSubRubros(todosVacio:=True).ToList(),
                                       txtCodigo.Text.Trim(),
                                       txtProducto.Text.Trim(),
                                       chbConPrecio.Checked, chbConStock.Checked, chbInactivos.Checked, chbEmbalaje.Checked,
                                       cmbEsOferta.Text, cmbEsDeVentas.Text, cmbEsDeCompras.Text,
                                       Integer.Parse(cmbMoneda.SelectedValue.ToString()),
                                       Decimal.Parse(txtCotizacionDolar.Text), cmbAfectaStock.Text)

      ugDetalle.DisplayLayout.Bands(0).Columns("NombreSucursal").Hidden = Not (sucs.Count > 1)
      ugDetalle.DisplayLayout.Bands(0).Columns("Activo").Hidden = Not chbInactivos.Checked

      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)

      SetearColumnas()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro

         cmbSucursales.CargarFiltrosImpresionSucursales(filtro, True, False)
         If Not String.IsNullOrWhiteSpace(txtCodigo.Text) Then
            .AppendFormat(" - Producto con código: {0}", txtCodigo.Text)
         End If
         If Not String.IsNullOrWhiteSpace(txtProducto.Text) Then
            .AppendFormat(" - Producto con nombre: {0}", txtProducto.Text)
         End If
         .AppendFormat(" - Producto: {0} - {1}", txtCodigo.Text, txtProducto.Text)

         .AppendFormat(" - Lista de Precios: {0}", cmbListaDePrecios.Text)
         cmbMarcas.CargarFiltrosImpresionMarcas(filtro, False, True, " - ", String.Empty)
         cmbModelos.CargarFiltrosImpresionModelos(filtro, False, True, " - ", String.Empty)
         cmbRubros.CargarFiltrosImpresionRubros(filtro, False, True, " - ", String.Empty)
         cmbSubRubros.CargarFiltrosImpresionSubRubros(filtro, False, True, " - ", String.Empty)
         cmbSubSubRubros.CargarFiltrosImpresionSubSubRubros(filtro, False, True, " - ", String.Empty)

         If chbConPrecio.Checked Then
            .AppendFormat(" - {0}", chbConPrecio.Text)
         End If
         If chbConStock.Checked Then
            .AppendFormat(" - {0}", chbConStock.Text)
         End If
         If chbInactivos.Checked Then
            .AppendFormat(" - {0}", chbInactivos.Text)
         End If
         .AppendFormat(" - {0}: {1}", lblEsDeVentas.Text, cmbEsDeVentas.Text)
         .AppendFormat(" - {0}: {1}", lblEsDeCompras.Text, cmbEsDeCompras.Text)
         .AppendFormat(" - {0}: {1}", lblEsOferta.Text, cmbEsOferta.Text)

         .AppendFormat(" - {0}: {1} - Cotizacion: {2}", lblMoneda.Text, cmbMoneda.Text, txtCotizacionDolar.Text)

         Dim ver = {If(chbVerStockReservado.Checked, chbVerStockReservado.Text, String.Empty),
                    If(chbVerStockDefectuoso.Checked, chbVerStockDefectuoso.Text, String.Empty),
                    If(chbVerStockFuturo.Checked, chbVerStockFuturo.Text, String.Empty),
                    If(chbVerStockFuturoReservado.Checked, chbVerStockFuturoReservado.Text, String.Empty)}.
                  Where(Function(s) Not String.IsNullOrWhiteSpace(s))

         If ver.Any() Then
            .AppendFormat(" - Ver stock: {0}", String.Join(",", ver))
         End If

         If chbEmbalaje.Checked Then
            .AppendFormat(" - Con Precios por Embalaje")
         End If
         If chbConIVA.Checked Then
            .AppendFormat(" - Con Impuestos")
         End If

      End With

      Return filtro.ToString()

   End Function

   Private Sub SetearColumnas()

      If _estaCargando And Not _MostrarCosto Then
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoSinIVA").Hidden = True
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoConIVA").Hidden = True
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioListaSinIVA").Hidden = True
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioListaConIVA").Hidden = True
         ugDetalle.DisplayLayout.Bands(0).Columns("CostoEmbalajeSinIVA").Hidden = True
         ugDetalle.DisplayLayout.Bands(0).Columns("CostoEmbalajeConIVA").Hidden = True
         ugDetalle.DisplayLayout.Bands(0).Columns("PorcRecargoCostoVSVenta").Hidden = True
      End If

      With ugDetalle.DisplayLayout.Bands(0)

         Dim formato = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString()
         Dim maskInput = Formatos.MaskInput.CustomMaskInput(14, Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio)

         .Columns("PrecioCostoSinIVA").FormatoMaskInput(formato, maskInput)
         .Columns("PrecioCostoConIVA").FormatoMaskInput(formato, maskInput)
         .Columns("CostoEmbalajeSinIVA").FormatoMaskInput(formato, maskInput)
         .Columns("CostoEmbalajeConIVA").FormatoMaskInput(formato, maskInput)

         .Columns("PrecioVentaSinIVA").FormatoMaskInput(formato, maskInput)
         .Columns("PrecioVentaConIVA").FormatoMaskInput(formato, maskInput)
         .Columns("PrecioListaSinIVA").FormatoMaskInput(formato, maskInput)
         .Columns("PrecioListaConIVA").FormatoMaskInput(formato, maskInput)
         .Columns("VentaEmbalajeSinIVA").FormatoMaskInput(formato, maskInput)
         .Columns("VentaEmbalajeConIVA").FormatoMaskInput(formato, maskInput)

         If Not chbVerStockReservado.Checked And Not chbVerStockDefectuoso.Checked And
            Not chbVerStockFuturo.Checked And Not chbVerStockFuturoReservado.Checked Then
            .Columns("Stock").Header.Caption = "Stock"
            .Columns("StockTotal").Hidden = True
         Else
            .Columns("Stock").Header.Caption = "Stock Disponible"
            .Columns("StockTotal").Hidden = False
         End If

         '.Columns("StockReservado").Hidden = Not chbVerStockReservado.Checked
         '.Columns("StockDefectuoso").Hidden = Not chbVerStockDefectuoso.Checked
         '.Columns("StockFuturo").Hidden = Not chbVerStockFuturo.Checked
         '.Columns("StockFuturoReservado").Hidden = Not chbVerStockFuturoReservado.Checked

      End With

      If _MostrarCosto Then
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoSinIVA").Hidden = chbConIVA.Checked
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioCostoConIVA").Hidden = Not chbConIVA.Checked
         ugDetalle.DisplayLayout.Bands(0).Columns("FechaActualizacionCosto_Fecha").Hidden = False
         ugDetalle.DisplayLayout.Bands(0).Columns("FechaActualizacionCosto_Hora").Hidden = False
      End If

      ugDetalle.DisplayLayout.Bands(0).Columns("PrecioVentaSinIVA").Hidden = chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("PrecioVentaConIVA").Hidden = Not chbConIVA.Checked

      If _PrecioLista Then
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioListaSinIVA").Hidden = chbConIVA.Checked
         ugDetalle.DisplayLayout.Bands(0).Columns("PrecioListaConIVA").Hidden = Not chbConIVA.Checked
      End If


      If chbEmbalaje.Checked Then
         If _MostrarCosto Then
            ugDetalle.DisplayLayout.Bands(0).Columns("CostoEmbalajeSinIVA").Hidden = chbConIVA.Checked
            ugDetalle.DisplayLayout.Bands(0).Columns("CostoEmbalajeConIVA").Hidden = Not chbConIVA.Checked
         End If
         ugDetalle.DisplayLayout.Bands(0).Columns("VentaEmbalajeSinIVA").Hidden = chbConIVA.Checked
         ugDetalle.DisplayLayout.Bands(0).Columns("VentaEmbalajeConIVA").Hidden = Not chbConIVA.Checked
      Else
         If _MostrarCosto Then
            ugDetalle.DisplayLayout.Bands(0).Columns("CostoEmbalajeSinIVA").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns("CostoEmbalajeConIVA").Hidden = True
         End If
         ugDetalle.DisplayLayout.Bands(0).Columns("VentaEmbalajeSinIVA").Hidden = True
         ugDetalle.DisplayLayout.Bands(0).Columns("VentaEmbalajeConIVA").Hidden = True
      End If

      ugDetalle.DisplayLayout.Bands(0).Columns("NombreModelo").Hidden = Not Reglas.Publicos.ProductoTieneModelo
      ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
      ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubSubRubro

      ugDetalle.AgregarFiltroEnLinea({"IdProducto", "NombreProducto", "NombreCorto", "NombreProveedor", "NombreMarca", "NombreModelo", "NombreRubro", "NombreSubRubro", "NombreSubSubRubro"})

   End Sub

   Public Function ShowDialogParaBusqueda(codigo As String, nombre As String, idListaPrecios As Integer) As DialogResult

      txtCodigo.Text = codigo
      txtProducto.Text = nombre
      cmbListaDePrecios.SelectedValue = idListaPrecios

      cmbListaDePrecios.Enabled = False

      _paraBusqueda = True

      Return ShowDialog()
   End Function

   Private Sub Aceptar()
      If _paraBusqueda AndAlso
         ugDetalle.ActiveRow IsNot Nothing AndAlso
         ugDetalle.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then

         Dim drDetalle As DataRow = DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row
         If Not String.IsNullOrWhiteSpace(drDetalle("IdProducto").ToString().Trim()) Then
            IdProductoDevuelta = drDetalle("IdProducto").ToString().Trim()
            DialogResult = DialogResult.OK
            Close()
         End If
      End If
      CargaStockDeposito(ugDetalle.ActiveRow.Cells("IdProducto").Value.ToString().Trim())
   End Sub

#End Region

End Class