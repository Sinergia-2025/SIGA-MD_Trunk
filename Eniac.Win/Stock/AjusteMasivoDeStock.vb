Public Class AjusteMasivoDeStock

#Region "Campos"

   Private _publicos As Publicos
   'Private _stocks As List(Of Entidades.ProductoSucursal)
   'Private _ubicac As List(Of Entidades.ProductoSucursal)
   Private _listas As List(Of Entidades.ListaDePrecios)
   'Private _filtroMultiplesMarcas As MFMarcas
   'Private _filtroMultiplesRubros As MFRubros
   Private _idListaPrecios As Integer
   Private _colorColumnasEditables As Color = System.Drawing.Color.FromArgb(224, 224, 224)
   Private _decimalesEnPrecio As Integer = 2
   Private _formatoEnPrecio As String = "N" + _decimalesEnPrecio.ToString()
   Private _maskInputEnPrecio As String = Formatos.MaskInput.CustomMaskInput(9, _decimalesEnPrecio)
   Private _tit As Dictionary(Of String, String)

   Private _cargoBienLaPantalla As Boolean
   Private _mensajeDeErrorEnCarga As String = ""

   Private dtAjusteMasivo As DataTable

   Public _Cargando As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _Cargando = True
         _publicos.CargaComboSucursales(cmbSucursales)
         _publicos.CargaComboDepositos(cmbDepositos, Integer.Parse(cmbSucursales.SelectedValue.ToString()), True, True, Entidades.Publicos.SiNoTodos.TODOS)
         If cmbDepositos.Items.Count > 0 Then
            cmbDepositos.SelectedIndex = 0
            _cargoBienLaPantalla = True
         Else
            _mensajeDeErrorEnCarga = String.Format("El usuario no posee depositos autorizados para la sucursal ({0})", actual.Sucursal.Nombre)
            _cargoBienLaPantalla = False
            Exit Sub
         End If
         _Cargando = False

         _publicos.CargaComboSubRubros(Me.cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            chbSubRubro.Visible = False
            cmbSubRubro.Visible = False
         End If

         cmbMarca_M.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubro_M.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True)

         cboCompuestos.Items.Insert(0, "TODOS")
         cboCompuestos.Items.Insert(1, "SI")
         cboCompuestos.Items.Insert(2, "NO")
         cboCompuestos.SelectedIndex = 0

         If Not Reglas.Publicos.TieneModuloProduccion Then
            lblCompuestos.Visible = False
            cboCompuestos.Visible = False
         End If

         _idListaPrecios = Reglas.Publicos.ListaPreciosPredeterminada

         With ugDetalle.DisplayLayout.Bands(0)
            .Columns("PrecioVenta").Header.Caption = New Reglas.ListasDePrecios().GetUno(_idListaPrecios).NombreListaPrecios

            .Columns("Stock").FormatoMaskInput(_formatoEnPrecio, _maskInputEnPrecio)
            .Columns("NuevoStock").FormatoMaskInput(_formatoEnPrecio, _maskInputEnPrecio)
            .Columns("NuevoStock").CellAppearance.BackColor = _colorColumnasEditables

            .Columns("NuevoNombreUbicacion").CellAppearance.BackColor = _colorColumnasEditables
            .Columns("NuevoNombreUbicacion").MaxLength = New Reglas.Publicos().GetAnchoCampo("SucursalesUbicaciones", "NombreUbicacion")

            .Columns("EsCompuesto").Hidden = Not Reglas.Publicos.TieneModuloProduccion

            ugDetalle.AgregarFiltroEnLinea({"IdProducto", "NombreProducto", "Ubicacion"})
            ugDetalle.ColumnasFijas({"NombreSucursal", "IdProducto", "NombreProducto"})
         End With

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         tsbGrabar.Enabled = False
      End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Select Case keyData
         Case Keys.F4
            tsbGrabar.PerformClick()
         Case Keys.F5
            tsbRefrescar.PerformClick()
         Case Keys.F3
            btnBuscar.PerformClick()
         Case Else
            Return MyBase.ProcessCmdKey(msg, keyData)
      End Select
      Return True
   End Function

#End Region

#Region "Eventos"
   Private Sub ActualizarStocks_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
      TryCatched(
      Sub()
         If tsbGrabar.Enabled Then
            If ShowPregunta("¿ Sale sin Grabar los cambios ?", MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
               e.Cancel = True
               Exit Sub
            End If
         End If
      End Sub)
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub

   Private Sub tsbObtenerStock_Click(sender As Object, e As EventArgs) Handles tsbObtenerStock.Click
      TryCatched(
      Sub()
         Using fPre = New ImportarStockExcel()
            If fPre.ShowDialog(Me,
                               cmbSucursales.ValorSeleccionado(0I),
                               cmbDepositos.ValorSeleccionado(0I)) = DialogResult.Cancel Then
               Exit Sub
            End If

            ugDetalle.UpdateData()
            Enabled = False

            Dim contador = 0I
            For Each drImportado In fPre.dtDetalle.Select("Importa")

               Dim idProducto = drImportado.Field(Of String)("Codigo").Trim()
               Dim idUbicacion = drImportado.Field(Of Integer)("IdUbicacion")

               MostrarAvance(String.Format("Importando producto {0} / {2} - {3}", drImportado("Codigo"), drImportado("IdUbicacion"), drImportado("NombreUbicacion"), drImportado("Descripcion")))

               Dim cont As Integer = 0
               Dim dtDetalle = ugDetalle.DataSource(Of DataTable)
               If dtDetalle IsNot Nothing Then
                  For Each dr In dtDetalle.Where(Function(x) x.Field(Of String)("IdProductoParaComparar") = idProducto And x.Field(Of Integer)("IdUbicacion") = idUbicacion)
                     cont += 1
                     MostrarAvance(String.Format("Importando producto {0} - {1} ({2})", drImportado("Codigo"), drImportado("Descripcion"), cont))

                     Dim nuevoStock = drImportado.ValorNumericoPorDefecto("Stock", 0D)
                     dr("NuevoStock") = nuevoStock

                     'dr("NuevoNombreUbicacion") = drImportado.Field(Of String)("NombreUbicacion").IfNull()
                     contador += 1
                  Next
               End If
            Next

            tsbGrabar.Enabled = contador > 0

            ShowMessage(String.Format("Importación realizada exitosamente. Se actualizaron {0} productos", contador))
         End Using
      End Sub)
      Enabled = True
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
      Sub()
         If Not TypeOf (ugDetalle.DataSource) Is DataTable Then Return
         If ShowPregunta("¿Esta Seguro de Actualizar el Stock de los Productos?") = DialogResult.Yes Then

            Enabled = False
            ugDetalle.UpdateData()

            Dim rProductosSucursales As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
            Try
               AddHandler rProductosSucursales.AvanceAjusteMasivoStock, Sub(sender1, e1) MostrarAvance(e1.Mensaje)

               rProductosSucursales.AjusteMasivoStock(DirectCast(ugDetalle.DataSource, DataTable),
                                                      True, True, reprocesa:=False, idFuncion:=IdFuncion, atributo:=False)
            Catch ex As Reglas.ProductosSucursales.ValidacionAjusteMasivoStockException
               If ShowPregunta(ex.Message) = Windows.Forms.DialogResult.Yes Then
                  rProductosSucursales.AjusteMasivoStock(DirectCast(ugDetalle.DataSource, DataTable),
                                                         True, True, reprocesa:=True, idFuncion:=IdFuncion, atributo:=False)
               Else
                  Throw New Exception("Actualización cancelada por el usuario", ex)
               End If
            End Try

            MessageBox.Show("¡Actualización relizada exitosamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            CargaGrillaDetalle()

            tsbGrabar.Enabled = False
         End If
      End Sub)
      tssInfo.Text = String.Empty
      Enabled = True
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub cmbSucursales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursales.SelectedIndexChanged
      TryCatched(Sub() _publicos.CargaComboDepositos(cmbDepositos, Integer.Parse(cmbSucursales.SelectedValue.ToString()), True, True, Entidades.Publicos.SiNoTodos.TODOS))
   End Sub
#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2))
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Reglas.Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Reglas.Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub Producto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion, bscCodigoProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub cmbDepositos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDepositos.SelectedValueChanged
      TryCatched(
      Sub()
         Dim dr = cmbDepositos.ItemSeleccionado(Of DataRow)()
         If dr IsNot Nothing Then
            _publicos.CargaComboUbicaciones(cmbUbiDest, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
         End If
      End Sub)
   End Sub
#Region "Eventos Buscador Proveedores"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
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
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      TryCatched(Sub() chbSubRubro.FiltroCheckedChanged(cmbSubRubro))
   End Sub
#End Region

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
      Sub()
         CargaGrillaDetalle()
         tsbGrabar.Enabled = True
         tsbObtenerStock.Visible = True
      End Sub)
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)(e.Row)
         If dr.Field(Of Decimal)("Stock") <> dr.Field(Of Decimal)("NuevoStock") Then
            e.Row.Cells("NuevoStock").Color(Color.Black, Color.Cyan)
         Else
            e.Row.Cells("NuevoStock").Color(Nothing, Nothing)
         End If
         If dr.Field(Of Integer)("IdUbicacion") <> dr.Field(Of Integer)("NuevoIdUbicacion") Then
            e.Row.Cells("NuevoNombreUbicacion").Color(Color.Black, Color.Cyan)
         Else
            e.Row.Cells("NuevoNombreUbicacion").Color(Nothing, Nothing)
         End If

         'If dr.Field(Of Decimal)("StockMinimo") <> dr.Field(Of Decimal)("NuevoStockMinimo") Then
         '   e.Row.Cells("NuevoStockMinimo").Color(Color.Black, Color.Cyan)
         'Else
         '   e.Row.Cells("NuevoStockMinimo").Color(Nothing, Nothing)
         'End If
         'If dr.Field(Of Decimal)("PuntoDePedido") <> dr.Field(Of Decimal)("NuevoPuntoDePedido") Then
         '   e.Row.Cells("NuevoPuntoDePedido").Color(Color.Black, Color.Cyan)
         'Else
         '   e.Row.Cells("NuevoPuntoDePedido").Color(Nothing, Nothing)
         'End If
         'If dr.Field(Of Decimal)("StockMaximo") <> dr.Field(Of Decimal)("NuevoStockMaximo") Then
         '   e.Row.Cells("NuevoStockMaximo").Color(Color.Black, Color.Cyan)
         'Else
         '   e.Row.Cells("NuevoStockMaximo").Color(Nothing, Nothing)
         'End If
      End Sub)
   End Sub
#End Region

#Region "Metodos"

   Private Sub RefrescarDatos()
      cmbMarca_M.Refrescar()
      cmbRubro_M.Refrescar()

      cmbDepositos.Enabled = True
      cmbSucursales.Enabled = True

      chbSubRubro.Checked = False
      chbProducto.Checked = False
      chbProveedor.Checked = False

      cboCompuestos.SelectedIndex = 0

      tsbObtenerStock.Visible = False

      ugDetalle.ClearFilas()

      tsbGrabar.Enabled = False

   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         If Integer.Parse(dr.Cells("Atributos").Value.ToString()) = 0 Then
            bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
            bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
            bscProducto2.Permitido = False
            bscCodigoProducto2.Permitido = False
            btnBuscar.PerformClick()
         Else
            ShowMessage(String.Format("No es posible cargar el producto ({0}), el mismo utiliza SubRubro con Atributo", dr.Cells("NombreProducto").Value.ToString()))
            bscCodigoProducto2.Selecciono = False
            bscProducto2.Selecciono = False
            bscCodigoProducto2.Focus()
         End If
      End If
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

         bscProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         btnBuscar.Focus()
      End If
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idSubRubro = cmbSubRubro.ValorSeleccionado(chbSubRubro.Checked, 0I)

      Dim idProducto As String = ""
      If Me.bscCodigoProducto2.Selecciono Or Me.bscProducto2.Selecciono Then
         idProducto = Me.bscCodigoProducto2.Text
      End If

      Dim idProveedor As Long = 0
      If Me.bscCodigoProveedor.Text.Length > 0 Then
         idProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      _idListaPrecios = Reglas.Publicos.ListaPreciosPredeterminada

      dtAjusteMasivo = New Reglas.Productos().GetStockParaActualizar(Integer.Parse(cmbSucursales.SelectedValue.ToString()),
                                                                     Integer.Parse(cmbDepositos.SelectedValue.ToString()),
                                                                     Me._listas,
                                                                     cmbMarca_M.GetMarcas(True),
                                                                     cmbRubro_M.GetRubros(True),
                                                                     idSubRubro,
                                                                     idProducto,
                                                                     idProveedor,
                                                                     False,
                                                                     False,
                                                                     Me.cboCompuestos.Text,
                                                                     Nothing, Nothing, String.Empty, String.Empty,
                                                                     _idListaPrecios,
                                                                     atributo:=False)

      dtAjusteMasivo.AcceptChanges()

      ugDetalle.DataSource = dtAjusteMasivo

      If dtAjusteMasivo.Rows.Count > 0 Then
         cmbDepositos.Enabled = False
         cmbSucursales.Enabled = False
      End If

      FormatearGrilla()
   End Sub

   Private Sub FormatearGrilla()
      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub

   Private Function ValidarCalcular() As Boolean
      If cmbMarca_M.Items.Count = 0 And cmbRubro_M.Items.Count = 0 And Not Me.chbSubRubro.Checked And
         Not Me.chbProducto.Checked And Not Me.chbProveedor.Checked And Me.cboCompuestos.SelectedIndex = 0 Then
         If MessageBox.Show("No Activo Ningun Filtro, ¿Está Seguro de Calcular sobre TODOS los Productos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
            Return False
         End If
      End If

      Return True

   End Function

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      Dim Primero As Boolean = True

      With filtro


         filtro.AppendFormat(" - Sucursales: {0}", cmbSucursales.SelectedText.ToString())
         filtro.AppendFormat(" - Deposito: {0}", cmbDepositos.SelectedText.ToString())

         cmbMarca_M.CargarFiltrosImpresionMarcas(filtro, False, True)
         .AppendFormat(" - ")
         cmbRubro_M.CargarFiltrosImpresionRubros(filtro, False, True)

         'If Me.clbSucursales.CheckedItems.Count > 1 Then
         '   For Each Sucursal As Entidades.Sucursal In Me.clbSucursales.CheckedItems
         '      filtro.AppendFormat("Filtros: Sucursales: : {0}", Sucursal.Nombre)
         '   Next
         '   filtro = filtro.Remove(filtro.Length - 2, 2)
         'Else
         '   filtro.AppendFormat(" - Sucursales: {0}", CType(Me.clbSucursales.CheckedItems(0), Entidades.Sucursal).Nombre)
         'End If

         If Me.chbSubRubro.Checked Then
            filtro.AppendFormat(" - Rubro: {0}", Me.cmbSubRubro.Text)
         End If

         If Me.chbProducto.Checked Then
            filtro.AppendFormat(" - Producto: {0} - {1}", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If
         If Me.chbProveedor.Checked Then
            filtro.AppendFormat(" - Proveedor: {0} - {1}", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If
         'If Me.cmbConStock.SelectedIndex > -1 Then
         '   filtro.AppendFormat(" - Con Stock: {0}", Me.cmbConStock.Text)
         'End If
         If Me.cboCompuestos.Visible Then
            filtro.AppendFormat(" - Compuesto: {0}", Me.cboCompuestos.Text)
         End If

         'If Me.chbAjustaUbicacion.Checked Then
         '   filtro.AppendFormat(" - Ajusta Ubicación")
         'End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Private Sub MostrarAvance(mensaje As String)
      tssInfo.Text = mensaje
      Application.DoEvents()
   End Sub

#End Region

   Private Sub CambiaStockMinimoMaximo(valor As Decimal, columna As String)
      If TypeOf (ugDetalle.DataSource) Is DataTable Then
         Dim dt = DirectCast(ugDetalle.DataSource, DataTable)
         dt.Select().ToList().ForEach(Sub(dr) dr(columna) = valor)
      End If
      ugDetalle.Rows.Refresh(RefreshRow.ReloadData)
   End Sub

   Private Sub ugDetalle_AfterRowUpdate(sender As Object, e As RowEventArgs) Handles ugDetalle.AfterRowUpdate
      TryCatched(Sub() tsbGrabar.Enabled = True)
   End Sub

   Private Sub btnAgregarUbicacion_Click(sender As Object, e As EventArgs) Handles btnAgregarUbicacion.Click, tsbAgregarUbicacion.Click
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            dr.CopyAdd(Sub(NewRow)
                          NewRow("Stock") = 0
                          NewRow("NuevoStock") = 0
                          NewRow("IdUbicacion") = 0
                          NewRow("NombreUbicacion") = String.Empty
                       End Sub)
            dtAjusteMasivo.AcceptChanges()
         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      TryCatched(
      Sub()
         Dim _RegProductos = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
         If _RegProductos.Field(Of Integer)("IdUbicacion") = 0 Then
            '-- Posiciona el cursor.- --
            dtAjusteMasivo.Rows.Remove(_RegProductos)
         End If
      End Sub)
   End Sub


   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      TryCatched(Sub() ugDetalle.UpdateData())
   End Sub

   Private Sub AjusteMasivoDeStock_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      TryCatched(
      Sub()
         If Not _cargoBienLaPantalla Then
            ShowMessage(_mensajeDeErrorEnCarga)
            tsbGrabar.Enabled = False
            Close()
         End If
      End Sub)
   End Sub
End Class