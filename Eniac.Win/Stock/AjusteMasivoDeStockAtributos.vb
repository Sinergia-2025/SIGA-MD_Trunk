Public Class AjusteMasivoDeStockAtributos
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
   '-- REQ-35488.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
   Private dtAjusteMasivo As DataTable

   Public _Cargando As Boolean = False

   Private _cargoBienLaPantalla As Boolean
   Private _mensajeDeErrorEnCarga As String = ""

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()


         'Me._filtroMultiplesMarcas = New MFMarcas()
         'Me._filtroMultiplesRubros = New MFRubros()

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

         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If


         cmbMarca_M.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubro_M.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True)

         'Me.CargaListasDePrecios()

         Me.cboCompuestos.Items.Insert(0, "TODOS")
         Me.cboCompuestos.Items.Insert(1, "SI")
         Me.cboCompuestos.Items.Insert(2, "NO")
         Me.cboCompuestos.SelectedIndex = 0

         If Not Reglas.Publicos.TieneModuloProduccion Then
            Me.lblCompuestos.Visible = False
            Me.cboCompuestos.Visible = False
         End If

         _idListaPrecios = Reglas.Publicos.ListaPreciosPredeterminada

         With ugDetalle.DisplayLayout.Bands(0)
            .Columns("PrecioVenta").Header.Caption = New Reglas.ListasDePrecios().GetUno(_idListaPrecios).NombreListaPrecios

            .Columns("Stock").FormatoMaskInput(_formatoEnPrecio, _maskInputEnPrecio)
            .Columns("NuevoStock").FormatoMaskInput(_formatoEnPrecio, _maskInputEnPrecio)
            .Columns("NuevoStock").CellAppearance.BackColor = _colorColumnasEditables

            '.Columns("NuevoStockMinimo").FormatoMaskInput(_formatoEnPrecio, _maskInputEnPrecio)
            '.Columns("NuevoPuntoDePedido").FormatoMaskInput(_formatoEnPrecio, _maskInputEnPrecio)
            '.Columns("NuevoStockMaximo").FormatoMaskInput(_formatoEnPrecio, _maskInputEnPrecio)

            '.Columns("NuevoStockMinimo").CellAppearance.BackColor = _colorColumnasEditables
            '.Columns("NuevoPuntoDePedido").CellAppearance.BackColor = _colorColumnasEditables
            '.Columns("NuevoStockMaximo").CellAppearance.BackColor = _colorColumnasEditables

            .Columns("NuevoNombreUbicacion").CellAppearance.BackColor = _colorColumnasEditables
            .Columns("NuevoNombreUbicacion").MaxLength = New Reglas.Publicos().GetAnchoCampo("SucursalesUbicaciones", "NombreUbicacion")

            .Columns("EsCompuesto").Hidden = Not Reglas.Publicos.TieneModuloProduccion

            '-- REQ-34986.- --------------------------------------------------------------------------------------------------------------------------------
            .Columns("DescripcionAtributo01").Header.Caption = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion
            .Columns("DescripcionAtributo02").Header.Caption = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion
            '-----------------------------------------------------------------------------------------------------------------------------------------------

            ugDetalle.AgregarFiltroEnLinea({"IdProducto", "NombreProducto", "Ubicacion"})
            ugDetalle.ColumnasFijas({"NombreSucursal", "IdProducto", "NombreProducto"})
         End With

         txtStockMinimo.Formato = _formatoEnPrecio
         txtPuntoDePedido.Formato = _formatoEnPrecio
         txtStockMaximo.Formato = _formatoEnPrecio

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         Me.tsbGrabar.Enabled = False

         'Me.rdbCostoFabrica.Visible = Publicos.UtilizaPrecioDeCompra 'No queda prolijo el porcentaje de Si Mismo.

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Select Case keyData
         Case Keys.F4
            If Me.tsbGrabar.Enabled Then
               Me.tsbGrabar.PerformClick()
               Return True
            End If
         Case Keys.F5
            Me.tsbRefrescar.PerformClick()
            Return True
      End Select
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"
   Private Sub ActualizarStocks_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
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

   Private Sub tsbObtenerStock_Click(sender As Object, e As EventArgs) Handles tsbObtenerStock.Click

      Try

         Using fPre As New ImportarStockExcel()
            If fPre.ShowDialog(Me,
                               cmbSucursales.ValorSeleccionado(0I),
                               cmbDepositos.ValorSeleccionado(0I)) = DialogResult.Cancel Then
               Exit Sub
            End If

            ugDetalle.UpdateData()

            Dim idProducto As String
            Dim contador As Integer

            contador = 0

            Dim nuevoStock As Decimal = 0
            Dim nuevaUbicacion As String = String.Empty

            Me.Enabled = False

            For Each drImportado As DataRow In fPre.dtDetalle.Select("Importa")

               idProducto = drImportado("Codigo").ToString()

               MostrarAvance(String.Format("Importando producto {0} - {1}", drImportado("Codigo"), drImportado("Descripcion")))

               Dim cont As Integer = 0
               For Each dr As DataRow In DirectCast(ugDetalle.DataSource, DataTable).Select(String.Format("IdProductoParaComparar = '{0}'", idProducto.Trim()))
                  cont += 1

                  MostrarAvance(String.Format("Importando producto {0} - {1} ({2})", drImportado("Codigo"), drImportado("Descripcion"), cont))

                  nuevoStock = drImportado.ValorNumericoPorDefecto("Stock", 0D)
                  dr("NuevoStock") = nuevoStock

                  nuevaUbicacion = drImportado("Ubicacion").ToString()
                  dr("NuevaUbicacion") = nuevaUbicacion
                  contador += 1
               Next
            Next

            ShowMessage(String.Format("Importación realizada exitosamente. Se actualizaron {0} productos", contador))

         End Using
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Enabled = True
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         If Not TypeOf (ugDetalle.DataSource) Is DataTable Then Return
         If MessageBox.Show("¿Esta Seguro de Actualizar el Stock de los Productos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ugDetalle.UpdateData()

            Me.Enabled = False
            Dim rProductosSucursales = New Reglas.ProductosSucursales()
            Try
               AddHandler rProductosSucursales.AvanceAjusteMasivoStock, Sub(sender1, e1) MostrarAvance(e1.Mensaje)

               rProductosSucursales.AjusteMasivoStock(DirectCast(ugDetalle.DataSource, DataTable),
                                                      True, True, reprocesa:=False, idFuncion:=IdFuncion, atributo:=True)
            Catch ex As Reglas.ProductosSucursales.ValidacionAjusteMasivoStockException
               If ShowPregunta(ex.Message) = Windows.Forms.DialogResult.Yes Then
                  rProductosSucursales.AjusteMasivoStock(DirectCast(ugDetalle.DataSource, DataTable),
                                                         True, True, reprocesa:=True, idFuncion:=IdFuncion, atributo:=True)
               Else
                  Throw New Exception("Actualización cancelada por el usuario", ex)
               End If
            End Try

            MessageBox.Show("¡Actualización relizada exitosamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            CargaGrillaDetalle()

            Me.tsbGrabar.Enabled = False

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         tssInfo.Text = String.Empty
         Me.Enabled = True
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = Me.CargarFiltrosImpresion

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos Filtros"
   'Private Sub lnkFiltroMultiplesMarcas_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroMultiplesMarcas.LinkClicked
   '   Try
   '      Me._filtroMultiplesMarcas.ShowDialog()
   '      If Me._filtroMultiplesMarcas.Filtros.Count = 0 Then
   '         Me.lnkFiltroMultiplesMarcas.Text = "Todas las Marcas"
   '      ElseIf Me._filtroMultiplesMarcas.Filtros.Count = 1 Then
   '         Me.lnkFiltroMultiplesMarcas.Text = Me._filtroMultiplesMarcas.Filtros(0).NombreMarca
   '      Else
   '         Me.lnkFiltroMultiplesMarcas.Text = "Algunas Marcas"
   '      End If
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   'Private Sub lnkFiltroMultiplesRubros_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroMultiplesRubros.LinkClicked
   '   Try
   '      Me._filtroMultiplesRubros.ShowDialog()
   '      If Me._filtroMultiplesRubros.Filtros.Count = 0 Then
   '         Me.lnkFiltroMultiplesRubros.Text = "Todos los Rubros"
   '      ElseIf Me._filtroMultiplesRubros.Filtros.Count = 1 Then
   '         Me.lnkFiltroMultiplesRubros.Text = Me._filtroMultiplesRubros.Filtros(0).NombreRubro
   '      Else
   '         Me.lnkFiltroMultiplesRubros.Text = "Algunos Rubros"
   '      End If
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSubRubro.CheckedChanged
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

   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged
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

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

   End Sub

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

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub Producto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion, bscCodigoProducto2.BuscadorSeleccion
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

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
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

#End Region

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
      Try

         Dim SucElegidas As Integer = 0
         'For Each ite As Object In Me.clbSucursales.CheckedItems
         '   SucElegidas += 1
         'Next
         'If SucElegidas = 0 Then
         '   MessageBox.Show("Debe Seleccionar al menos una Sucursal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.clbSucursales.Focus()
         '   Exit Sub
         'End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.tsbGrabar.Enabled = False
         Me.tsbObtenerStock.Visible = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tssRegistros.Text = "0 Registros"
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
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
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


#End Region

#Region "Metodos"

   Private Sub ReseteaNuevosStocks()
      Me.txtStockMinimo.Text = (0).ToString(Me.txtStockMinimo.Formato)
      Me.txtPuntoDePedido.Text = (0).ToString(Me.txtPuntoDePedido.Formato)
      Me.txtStockMaximo.Text = (0).ToString(Me.txtStockMaximo.Formato)
   End Sub

   Private Sub RefrescarDatos()

      'If Not Me._filtroMultiplesMarcas.dgvDatos.DataSource Is Nothing Then
      '   Me._filtroMultiplesMarcas.Filtros.Clear()
      '   Me._filtroMultiplesMarcas.dgvDatos.DataSource = Me._filtroMultiplesMarcas.Filtros.ToArray()
      '   Me.lnkFiltroMultiplesMarcas.Text = "Todas las Marcas"
      'End If

      'If Not Me._filtroMultiplesRubros.dgvDatos.DataSource Is Nothing Then
      '   Me._filtroMultiplesRubros.Filtros.Clear()
      '   Me._filtroMultiplesRubros.dgvDatos.DataSource = Me._filtroMultiplesRubros.Filtros.ToArray()
      '   Me.lnkFiltroMultiplesRubros.Text = "Todos los Rubros"
      'End If

      cmbMarca_M.Refrescar()
      cmbRubro_M.Refrescar()

      Me.chbSubRubro.Checked = False
      Me.chbProducto.Checked = False
      Me.chbProveedor.Checked = False
      'Me.chbAjustaUbicacion.Checked = False
      'Me.chbStockMinimoMaximo.Checked = False
      Me.ReseteaNuevosStocks()

      Me.cboCompuestos.SelectedIndex = 0

      Me.tsbObtenerStock.Visible = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      Me.tssRegistros.Text = " 0 Registros"

      Dim Cont As Integer

      'For Cont = 0 To clbSucursales.Items.Count - 1

      '   'Siempre marco la actual, si quiere hacer precios a los demas debera marcalo
      '   'If DirectCast(Me.clbSucursales.Items.Item(Cont), Entidades.Sucursal).Id = actual.Sucursal.Id And clbSucursales.Items.Count = 1 Then

      '   If DirectCast(Me.clbSucursales.Items.Item(Cont), Entidades.Sucursal).Id = actual.Sucursal.Id Then
      '      Me.clbSucursales.SetItemChecked(Cont, True)
      '   Else
      '      Me.clbSucursales.SetItemChecked(Cont, False)
      '   End If
      'Next

      Me.tsbGrabar.Enabled = False

   End Sub

   'Private Sub CargarSucursales()

   '   Dim lis As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(False)

   '   For Each suc As Entidades.Sucursal In lis
   '      Me.clbSucursales.Items.Add(suc)
   '      'Marco en forma predeterminada la Sucursal donde estoy parado. Ahorra trabajo, sobre todo si solo hay 1, tiene mas sentido.
   '      If suc.Id = actual.Sucursal.Id Then
   '         Me.clbSucursales.SetItemChecked(Me.clbSucursales.Items.Count - 1, True)
   '      End If
   '   Next

   '   'End If

   'End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      If Integer.Parse(dr.Cells("Atributos").Value.ToString()) = 0 Then
         MessageBox.Show(String.Format("No es posible cargar el producto ({0}), el mismo utiliza SubRubro Sin Atributo", dr.Cells("NombreProducto").Value.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         bscCodigoProducto2.Selecciono = False
         bscProducto2.Selecciono = False
         bscCodigoProducto2.Focus()
      Else
         Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         Me.bscProducto2.Enabled = False
         Me.bscCodigoProducto2.Enabled = False
         Me.btnBuscar_Click(Me.btnBuscar, New EventArgs())
      End If
   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub CargaGrillaDetalle()

      'Dim sucursales As New List(Of Integer)
      Dim fechaActDesde As Date = Nothing
      Dim fechaActHasta As Date = Nothing

      'For Each ite As Object In Me.clbSucursales.CheckedItems
      '   sucursales.Add(DirectCast(ite, Entidades.Sucursal).Id)
      'Next

      Dim idSubRubro As Integer = If(Me.chbSubRubro.Checked, Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString()), 0)

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
                                                                          atributo:=True)


      dtAjusteMasivo.AcceptChanges()

      Me.ugDetalle.DataSource = dtAjusteMasivo

      Me.tssRegistros.Text = Me.ugDetalle.CantidadRegistrosParaStatusbar() '' .Rows.Count.ToString() & " Registros"

      FormatearGrilla()

      Me.ReseteaNuevosStocks()

   End Sub

   Private Sub FormatearGrilla()
      AjustarColumnasGrilla(ugDetalle, _tit)
      'With ugDetalle.DisplayLayout.Bands(0)
      '   .Columns("NombreSucursal").Hidden = clbSucursales.CheckedItems.Count = 1
      '   .Columns("NuevaUbicacion").Hidden = Not Me.chbAjustaUbicacion.Checked

      '   StockMinimoMaximoVisible()
      'End With
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

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         filtro.AppendFormat(" - Sucursales: {0}", cmbSucursales.SelectedText.ToString())
         filtro.AppendFormat(" - Deposito: {0}", cmbDepositos.SelectedText.ToString())

         'If Me.clbSucursales.CheckedItems.Count > 1 Then
         '   For Each Sucursal As Entidades.Sucursal In Me.clbSucursales.CheckedItems
         '      filtro.AppendFormat("Filtros: Sucursales: : {0}", Sucursal.Nombre)
         '   Next
         '   filtro = filtro.Remove(filtro.Length - 2, 2)
         'Else
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

   Private Sub cmbSucursales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursales.SelectedIndexChanged
      _publicos.CargaComboDepositos(cmbDepositos, Integer.Parse(cmbSucursales.SelectedValue.ToString()), True, True, Entidades.Publicos.SiNoTodos.TODOS)
   End Sub

   Private Sub cmbDepositos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDepositos.SelectedValueChanged
      TryCatched(
         Sub()
            Dim dr = cmbDepositos.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing Then
               _publicos.CargaComboUbicaciones(cmbUbiDest, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
            End If
         End Sub)
   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      ugDetalle.UpdateData()
   End Sub

   Private Sub ugDetalle_AfterRowUpdate(sender As Object, e As RowEventArgs) Handles ugDetalle.AfterRowUpdate
      Me.tsbGrabar.Enabled = True
   End Sub

   Private Sub btnAgregarUbicacion_Click(sender As Object, e As EventArgs) Handles btnAgregarUbicacion.Click
      Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
      If dr IsNot Nothing Then
         dr.CopyAdd(Sub(NewRow)
                       NewRow("Stock") = 0
                       NewRow("NuevoStock") = 0
                       NewRow("IdUbicacion") = 0
                       NewRow("NombreUbicacion") = String.Empty
                    End Sub)
      End If
      dtAjusteMasivo.AcceptChanges()
   End Sub

   Private Sub cmbDepositos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositos.SelectedIndexChanged
      TryCatched(
         Sub()
            Dim dr = cmbDepositos.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing Then
               _publicos.CargaComboUbicaciones(cmbUbiDest, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
            End If
         End Sub)
   End Sub

   Private Sub AjusteMasivoDeStockAtributos_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      Try
         If Not _cargoBienLaPantalla Then
            MessageBox.Show(_mensajeDeErrorEnCarga, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.tsbGrabar.Enabled = False
            Me.Close()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

#End Region

End Class