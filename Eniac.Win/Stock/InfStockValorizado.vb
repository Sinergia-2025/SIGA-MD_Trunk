Public Class InfStockValorizado

#Region "Campos"

   Private _precios As List(Of Entidades.ProductoSucursal)
   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()
            _publicos.CargaComboListaDePrecios(cmbListaDePrecios)

            _publicos.CargaComboMarcas(cmbMarca)
            _publicos.CargaComboRubros(cmbRubro)

            ' # Cargo combo de Activos
            _publicos.CargaComboDesdeEnum(cmbActivos, GetType(Entidades.Publicos.SiNoTodos))
            cmbActivos.SelectedIndex = 0

            '-- REQ-38504.- --------------------------------------------------------------------------------------------
            cmbSucursal.Initializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, IdFuncion)
            cmbDepositos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, {})
            ugdDetalle.DisplayLayout.Bands(0).Columns("NombreSucursal").Hidden = True
            '-----------------------------------------------------------------------------------------------------------

            txtCotizacionDolar.SetValor(New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion)

            _publicos.CargaComboSubRubros(cmbSubRubro)

            If Not Reglas.Publicos.ProductoTieneSubRubro Then
               chbSubRubro.Visible = False
               cmbSubRubro.Visible = False
            End If

            chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

            ugdDetalle.AgregarFiltroEnLinea({"IdProducto", "NombreSucursal", "NombreProducto"})

            PreferenciasLeer(ugdDetalle, tsbPreferencias)

            ugdDetalle.AgregarTotalesSuma({"StockDeposito", "StockUbicacion", "Kilos", "KilosDeposito", "KilosUbicacion", "ValorizadoCostoConImpuestos", "ValorizadoVentaConImpuestos", "ValorizadoCostoSinImpuestos", "ValorizadoVentaSinImpuestos"})
            tssRegistros.Text = ugdDetalle.CantidadRegistrosParaStatusbar
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
   Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
      TryCatched(
         Sub()

            If chbProveedor.Checked And Not (bscCodigoProveedor.Selecciono Or bscNombreProveedor.Selecciono) Then
               ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
               bscCodigoProveedor.Focus()
               Exit Sub
            End If

            If chbProducto.Checked And Not (bscCodigoProducto2.Selecciono Or bscProducto2.Selecciono) Then
               ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro")
               bscCodigoProducto2.Focus()
               Exit Sub
            End If

            BarraInicializa("Calculando Capital Invertido...", 0, ugdDetalle.Rows.Count)

            CargarGrillaDetalle()
            GrillaConSinIva()
         End Sub)
      TryCatched(Sub() BarraFinaliza())
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            cmbListaDePrecios.SelectedIndex = 0
            cmbActivos.SelectedIndex = 0

            cmbSucursal.Refrescar()
            cmbDepositos.Refrescar()
            chbUbicacion.Checked = False

            chbProveedor.Checked = False
            chbProveedorHabitual.Checked = False
            chbProducto.Checked = False
            bscProducto2.Text = String.Empty
            chbMarca.Checked = False
            chbRubro.Checked = False
            chbSubRubro.Checked = False
            dtpFecha.Value = Date.Today
            chbHastaFecha.Checked = False

            txtCotizacionDolar.SetValor(New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion)

            ugdDetalle.ClearFilas()

            'tssRegistros.Text = ugdDetalle.CantidadRegistrosParaStatusbar

            chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

            'tssRegistros.Text = ""

            btnCalcular.Focus()
         End Sub)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            If ugdDetalle.Rows.Count = 0 Then Exit Sub

            Dim Titulo = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

            Dim UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(components)
            UltraPrintPreviewD.AutoSizeMode = AutoSizeMode.GrowAndShrink
            UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

            UltraPrintPreviewD.Document = UltraGridPrintDocument1
            UltraPrintPreviewD.Name = Text

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
            UltraPrintPreviewD.Focus()
         End Sub)
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugdDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugdDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugdDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Checkbox Filtros"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      End If
   End Sub

   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      Me.cmbRubro.Enabled = Me.chbRubro.Checked
      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         If Me.cmbRubro.Items.Count > 0 Then
            Me.cmbRubro.SelectedIndex = 0
         End If
      End If
   End Sub

   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      Try
         Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

         If Not Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubRubro.Items.Count > 0 Then
               Me.cmbSubRubro.SelectedIndex = 0
            End If
         End If

         Me.cmbSubRubro.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      cmbMarca.Enabled = chbMarca.Checked
      If Not chbMarca.Checked Then
         cmbMarca.SelectedIndex = -1
      Else
         cmbMarca.SelectedIndex = 0
      End If
   End Sub

   Private Sub chbProveedorHabitual_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      bscCodigoProveedor.Enabled = chbProveedor.Checked
      bscNombreProveedor.Enabled = chbProveedor.Checked

      chbProveedorHabitual.Enabled = False
      chbProveedorHabitual.Checked = False

      bscCodigoProveedor.Text = String.Empty
      bscCodigoProveedor.Tag = Nothing
      bscNombreProveedor.Text = String.Empty

      If chbProveedor.Checked Then
         bscCodigoProveedor.Focus()
      End If
   End Sub

   Private Sub chbHastaFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbHastaFecha.CheckedChanged
      Me.dtpFecha.Enabled = Me.chbHastaFecha.Checked
   End Sub
#End Region

#Region "Eventos Buscadores Filtros"
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

   Private Sub bscCodigoProveedorHabitual_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
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
            Me.btnCalcular.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorClick() Handles bscNombreProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscNombreProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscNombreProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscNombreProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreProveedorHabitual_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnCalcular.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      Try
         GrillaConSinIva()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub GrillaConSinIva()
      With ugdDetalle.DisplayLayout.Bands(0)
         .Columns("ValorizadoCostoConImpuestos").Hidden = Not chbConIVA.Checked
         .Columns("ValorizadoVentaConImpuestos").Hidden = Not chbConIVA.Checked
         .Columns("ValorizadoCostoSinImpuestos").Hidden = chbConIVA.Checked
         .Columns("ValorizadoVentaSinImpuestos").Hidden = chbConIVA.Checked

         .Columns("PrecioCostoConImpuestos").Hidden = Not chbConIVA.Checked
         .Columns("PrecioVentaConImpuestos").Hidden = Not chbConIVA.Checked
         .Columns("PrecioCostoSinImpuestos").Hidden = chbConIVA.Checked
         .Columns("PrecioVentaSinImpuestos").Hidden = chbConIVA.Checked
      End With
   End Sub

#End Region

#Region "Metodos"

   'Private Sub CargarSucursales()

   '   Dim lis As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(False)

   '   Me.clbSucursales.Items.Clear()

   '   For Each suc As Entidades.Sucursal In lis

   '      Me.clbSucursales.Items.Add(suc)

   '      'Marco en forma predeterminada la Sucursal donde estoy parado. Ahorra trabajo, sobre todo si solo hay 1.
   '      If suc.Id = actual.Sucursal.Id Then
   '         Me.clbSucursales.SetItemChecked(Me.clbSucursales.Items.Count - 1, True)
   '      End If

   '   Next

   '   Me.ugdDetalle.DisplayLayout.Bands(0).Columns("NombreSucursal").Hidden = True

   'End Sub

   Private Sub CargarGrillaDetalle()

      Dim idProveedor As Long = If(Me.bscCodigoProveedor.Tag IsNot Nothing, Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), 0)
      Dim idProducto As String = If(Me.bscCodigoProducto2.Selecciono Or Me.bscProducto2.Selecciono, Me.bscCodigoProducto2.Text, String.Empty)
      Dim idMarca As Integer = If(Me.chbMarca.Checked, Integer.Parse(Me.cmbMarca.SelectedValue.ToString()), 0)
      Dim idRubro As Integer = If(Me.chbRubro.Checked, Integer.Parse(Me.cmbRubro.SelectedValue.ToString()), 0)
      Dim idSubRubro As Integer = If(Me.chbSubRubro.Checked, Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString()), 0)
      Dim activos As Entidades.Publicos.SiNoTodos = DirectCast(Me.cmbActivos.SelectedValue, Entidades.Publicos.SiNoTodos)

      Dim fechaHasta As DateTime? = Nothing
      If Me.chbHastaFecha.Checked Then
         fechaHasta = Me.dtpFecha.Value
      End If

      Dim ubicacion = cmbUbicacion.ItemSeleccionado(Of Entidades.SucursalUbicacion)(chbUbicacion)

      ugdDetalle.DisplayLayout.Bands(0).Columns("NombreSucursal").Hidden = cmbSucursal.GetSucursales().Count = 1

      Dim dtDetalle As DataTable
      dtDetalle = New Reglas.Productos().GetStockValorizado(cmbSucursal.GetSucursales(),
                                                            cmbDepositos.GetDepositos(),
                                                            ubicacion,
                                                            idProducto,
                                                            idMarca,
                                                            idRubro, idSubRubro,
                                                            fechaHasta,
                                                            idProveedor,
                                                            DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios,
                                                            chbProveedorHabitual.Checked,
                                                            txtCotizacionDolar.ValorNumericoPorDefecto(1D),
                                                            decimalesRedondeo:=2,
                                                            activos:=activos)

      _tit = GetColumnasVisiblesGrilla(ugdDetalle)

      ugdDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla(ugdDetalle, _tit)

      If dtDetalle.Rows.Count > 0 Then
         btnCalcular.Focus()
      Else
         MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

      'tssRegistros.Text = ugdDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)

      bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      bscProducto2.Enabled = False
      bscCodigoProducto2.Enabled = False

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

      With filtro
         Dim Filtros As String = String.Empty

         If cmbSucursal.GetSucursales().Count > 1 Then
            .AppendFormat("Sucursal/es: {0} - ")
            cmbSucursal.CargarFiltrosImpresionSucursales(filtro, False, True)
         End If


         If Me.chbProducto.Checked Then
            .AppendFormat(" Producto: {0} - ", Me.bscProducto2.Text)
         End If

         If Me.chbMarca.Checked Then
            .AppendFormat(" Marca: {0} - ", Me.cmbMarca.Text)
         End If

         If Me.chbRubro.Checked Then
            .AppendFormat(" Rubro: {0} - ", Me.cmbRubro.Text)
         End If

         If Me.chbSubRubro.Checked Then
            .AppendFormat(" SubRubro: {0} - ", Me.cmbSubRubro.Text)
         End If

         If Me.chbProveedor.Checked Then
            .AppendFormat(" Proveedor Habitual: {0} - ", Me.bscNombreProveedor.Text)
         End If

         If DirectCast(Me.cmbActivos.SelectedValue, Entidades.Publicos.SiNoTodos) <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat(" Activos: {0} - ", Me.cmbActivos.Text)
         End If

         .AppendFormat(" Lista de Precio: {0} - ", Me.cmbListaDePrecios.Text)
      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      bscNombreProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      bscNombreProveedor.Enabled = False
      bscCodigoProveedor.Enabled = False

      chbProveedorHabitual.Enabled = True
   End Sub

   Private Sub BarraInicializa(texto As String, valorInicial As Integer, maximoValor As Integer)
      tspBarra.Visible = True
      tspBarra.Maximum = maximoValor
      tspBarra.Value = valorInicial
      tssInfo.Text = texto
   End Sub

   Private Sub BarraFinaliza()
      tssInfo.Text = String.Empty
      tspBarra.Value = tspBarra.Maximum
      tspBarra.Visible = False
      tspBarra.Value = 0
   End Sub

   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      Try
         Dim habilitaDeposito As Boolean = False
         If cmbSucursal.SelectedIndex > 0 Then
            Dim sucursal = cmbSucursal.GetSucursales()
            If sucursal.Length > 0 Then
               cmbDepositos.Inicializar(True, True, True, sucursal)
               habilitaDeposito = cmbDepositos.GetDepositos().Count > 1
            End If
         End If
         cmbDepositos.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbDepositos_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositos.AfterSelectedIndexChanged
      TryCatched(
            Sub()
               _publicos.CargaComboUbicaciones(cmbUbicacion, cmbSucursal.GetSucursales(), cmbDepositos.GetDepositos())
               'cmbUbicacion.SelectedIndex = 0
            End Sub)
   End Sub

   Private Sub chbUbicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbUbicacion.CheckedChanged
      '-- Activo-Desactivo Combo.- --
      cmbUbicacion.Enabled = chbUbicacion.Checked
      cmbUbicacion.Focus()
   End Sub

#End Region

End Class