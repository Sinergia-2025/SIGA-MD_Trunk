Public Class InformeOrdenesDeCalidad

#Region "Campos"
   Private _publicos As Publicos
   Private _titGrillaControl As Dictionary(Of String, String)
   Private _vieneDeOnLoad As Boolean = False
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         '-- Carga los Tipos de Estados.- ------------------------------------------------------------------------------
         cmbEstadosOrdenes.Initializar()
         '-- Cargar los tipos de Comprobantes.- ------------------------------------------------------------------------
         _vieneDeOnLoad = True
         cmbTiposComprobantes.Initializar(True, True, True, False, Entidades.TipoComprobante.Tipos.CALIDAD.ToString(),,,,,,, Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString())
         _vieneDeOnLoad = False
         '-- Carga Usuarios.- ------------------------------------------------------------------------------------------
         _publicos.CargaComboUsuarios(cmbUsuario)

         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         '-- Recupera Columnas Visibles.- ------------------------------------------------------------------------------
         _titGrillaControl = GetColumnasVisiblesGrilla(ugDetalle)
         '-- Inicializa Campos de Busqueda.- ---------------------------------------------------------------------------
         RefrescarDatos()
         '-- Setea Valores de Filtro y Totales en la Grilla.- ----------------------------------------------------------
         SeteaFiltrosCabeceras()

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

#Region "Métodos"
   Private Sub RefrescarDatos()
      '-- Fecha de Consulta.- ------------------------------------------------------------------------------------------
      chbFecha.Checked = False
      chkMesCompleto.Enabled = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      '-- 
      chbProveedor.Checked = False
      chbProducto.Checked = False
      chbUsuario.Checked = False
      '--
      chbNumeroComprobante.Checked = False
      '-- 
      cmbTiposComprobantes.Refrescar()
      cmbEstadosOrdenes.Refrescar()
      cmbSucursal.Refrescar()
      '-- Limpio la Grilla.-
      ugDetalle.ClearFilas()
   End Sub
   Private Sub SeteaFiltrosCabeceras()
      ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "NombreProveedor"})
      ugDetalle.AgregarTotalesSuma({"CantidadComprobante"})
   End Sub
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscNombreProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
      End If
   End Sub
   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProducto.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscNombreProducto.Permitido = False
         bscCodigoProducto.Permitido = False
      End If
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim rOrdenesCC = New Reglas.CalidadOrdenDeControl()
      Dim dtDetalle = rOrdenesCC.GetOrdenesDeCalidadXEstados(cmbSucursal.GetSucursales(),
                                                             cmbEstadosOrdenes.GetEstadosOrdenesCalidad(),
                                                             dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                             cmbTiposComprobantes.GetTiposComprobantes(),
                                                             txtNumeroComprobante.ValorSeleccionado(chbNumeroComprobante, 0L),
                                                             If(chbProducto.Checked, bscCodigoProducto.Text.Trim(), String.Empty),
                                                             If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L),
                                                             cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty))
      ugDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla(ugDetalle, _titGrillaControl)

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=True, muestraNombre:=False)

         .AppendFormat(" - Estado: {0} ", cmbEstadosOrdenes.Text)


         If chbFecha.Checked Then
            .AppendFormat(" - Fechas: {0} Hasta {1} ", dtpDesde.Value, dtpHasta.Value)
         End If
         If chbProveedor.Checked Then
            .AppendFormat(" - Proveedor: {0} - {1} ", bscCodigoProveedor.Text, bscNombreProveedor.Text)
         End If
         If chbUsuario.Checked Then
            .AppendFormat(" - Usuario: {0} ", cmbUsuario.Text)
         End If
         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1} ", bscCodigoProducto.Text, bscNombreProducto.Text)
         End If
         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, muestraId:=True, muestraNombre:=False)
         If chbNumeroComprobante.Checked Then
            .AppendFormat(" - Número : {0} ", txtNumeroComprobante.Text)
         End If
      End With
      Return filtro.ToString()
   End Function
#End Region

#Region "Eventos"
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
   Private Sub bscProveedor_BuscadorClick() Handles bscNombreProveedor.BuscadorClick
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

#Region "Eventos Buscador Producto"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto, bscNombreProducto))
   End Sub
   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscNombreProducto_BuscadorClick() Handles bscNombreProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombreProducto)
         bscNombreProducto.Datos = New Reglas.Productos().GetPorNombre(bscNombreProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscNombreProducto.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
   Private Sub chbNumeroComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroComprobante.CheckedChanged
      TryCatched(Sub() chbNumeroComprobante.FiltroCheckedChanged(txtNumeroComprobante))
   End Sub
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscNombreProducto.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto.Focus()
            Exit Sub
         End If
         If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscNombreProveedor.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If
         If chbNumeroComprobante.Checked AndAlso txtNumeroComprobante.ValorNumericoPorDefecto(0I) = 0 Then
            ShowMessage("ATENCION: NO Ingresó un Número aunque activó ese Filtro.")
            txtNumeroComprobante.Focus()
            Exit Sub
         End If
         If chbUsuario.Checked AndAlso cmbUsuario.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Ha seleccionado el filtro por Usuario pero no ha seleccionado uno. Por favor reintente.")
            txtNumeroComprobante.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("¡¡¡ NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
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
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
       Sub()
          Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
          If dr Is Nothing Then
             Throw New Exception("Debe seleccionar una Orden para poder continuar")
          End If
          ImprimirOrdenDeCalidad(Integer.Parse(dr("IdSucursal").ToString()),
                                dr("IdTipoComprobante").ToString(),
                                dr("Letra").ToString(),
                                Short.Parse(dr("CentroEmisor").ToString()),
                                Long.Parse(dr("NumeroComprobante").ToString()),
                                True)

       End Sub)
   End Sub

   Private Sub ImprimirOrdenDeCalidad(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                        visualiza As Boolean)

      Dim impresion = New ImpresionOrdenesCalidad()
      Dim eOrdCalidad = RecuperaUnaOperacion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion)
      impresion.ImprimirOrdenDeCalidad(eOrdCalidad, Visualizar:=visualiza)
   End Sub
   Private Function RecuperaUnaOperacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long) As Entidades.CalidadOrdenDeControl

      Dim rOrdControl = New Reglas.CalidadOrdenDeControl()

      Return rOrdControl.GetUno(IdSucursal:=idSucursal,
                               IdTipoComprobante:=idTipoComprobante,
                               Letra:=letra,
                               CentroEmisor:=centroEmisor,
                               NumeroComprobante:=numeroOrdenProduccion)
   End Function
#End Region
#End Region

End Class