Imports System.ComponentModel
Public Class ImportarProductosPlantillaExcel
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private ConexionExcel As OleDb.OleDbConnection
   'Private RangoExcel As String
   Private ColumnaIdProducto As Integer = 99
   Private ColumnaNombreProducto As Integer = 99
   Private ColumnaNombreProducto2 As Integer = 99  'Predeterminado 1 Columna
   Private ColumnaNombreMarca As Integer = 99
   Private ColumnaNombreRubro As Integer = 99
   Private ColumnaNombreSubRubro As Integer = 99
   Private ColumnaNombreSubSubRubro As Integer = 99
   Private ColumnaIVA As Integer = 99
   Private ColumnaPrecioCompra As Integer = 99
   Private ColumnaPrecioCosto As Integer = 99
   Private ColumnaPrecioVenta As Integer = 99
   Private ColumnaMoneda As Integer = 99
   Private ColumnaCodigoDeBarras As Integer = 99
   Private ColumnaPrecioCostoAnterior As Integer = 99
   Private ColumnaPorVarCosto As Integer = 99
   Private ColumnaCodigoLargoProducto As Integer = 99
   Private ColumnaObservacion As Integer = 99
   Private ColumnaDR1 As Integer = 99
   Private ColumnaDR2 As Integer = 99
   Private ColumnaDR3 As Integer = 99
   Private ColumnaDR4 As Integer = 99
   Private ColumnaIdProductoNumerico As Integer = 99

   Private ProductosConError As Integer
   Private _estaCargando As Boolean = True
   Private _plantilla As Entidades.Plantilla
   Private dtListaPrecios As DataTable
   Private _actualizarprecioExcel As String

   Private _funcion As String
   Private Const nombreFuncionImportar As String = "IMPORTARPROD"
   Private Const nombreFuncionComparar As String = "COMPARARPROD"

   Private _decimalesAMostrarEnTotalXProducto As Integer
   Private _decimalesAMostrarEnPrecio As Integer
   Private _formatoAMostrarEnPrecio As String
   Private _decimalesRedondeoEnPrecio As Integer
   Private _decimalesEnCantidad As Integer
   Private _decimalesMostrarEnCantidad As Integer
   Private _decimalesEnTotales As Integer
   Private _permiteModificarSubtotal As Boolean = False

   '-- REQ-32572.- ---------------------------------------------------------
   Private _decimalesEnPrecio As Integer
   Private _formatoEnPrecio As String
   '------------------------------------------------------------------------

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _actualizarprecioExcel = Reglas.Publicos.ActualizarPreciosExcel

         '_publicos.CargaComboMarcas(Me.cmbMarca)

         cboDescripcion.Items.Insert(0, "Una Columna")
         cboDescripcion.Items.Insert(1, "Dos Columnas")

         cboAccion.Items.Insert(0, "Todas")
         cboAccion.Items.Insert(1, "Altas")
         cboAccion.Items.Insert(2, "Existentes")
         cboAccion.Items.Insert(3, "Modificar")
         cboAccion.Items.Insert(4, "Sin Cambios")

         cboEstado.Items.Insert(0, "Todos")
         cboEstado.Items.Insert(1, "Validos")
         cboEstado.Items.Insert(2, "Invalidos")

         cmbDescripcionCorte.Items.Insert(0, "No Cortar")
         cmbDescripcionCorte.Items.Insert(1, "Cortar")
         cmbDescripcionCorte.Items.Insert(2, "Avisar y Cortar")

         _publicos.CargaComboListaDePrecios(cmbListaPrecios)
         _publicos.CargaComboMonedas(cmbMoneda)
         _publicos.CargaComboImpuestos(cmbTipoImpuesto)
         _publicos.CargaComboDesdeEnum(cmbPrecioPorEmbalaje, GetType(PrecioPorEmbalaje))
         _publicos.CargaComboDesdeEnum(cmbActivos, Entidades.Publicos.SiNoTodos.TODOS)

         CargarDecimales()

         '# En caso de que la función sea la de comparación
         If _funcion = nombreFuncionComparar Then
            PrepararPantallaParaComparacion()
         Else
            _funcion = nombreFuncionImportar
         End If

         RefrescarGrilla()

         _estaCargando = False
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

   Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
      TryCatched(
      Sub()
         If Not bscCodigoProveedor.Selecciono() And Not bscProveedor.Selecciono() Then
            ShowMessage("ATENCION: Debe cargar un Proveedor.")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If
         If String.IsNullOrEmpty(txtArchivoOrigen.Text) Then
            ShowMessage("ATENCION: Debe seleccionar el archivo")
            txtArchivoOrigen.Focus()
            Exit Sub
         End If
         If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
            ShowMessage("ATENCION: El archivo a Importar NO Existe")
            txtArchivoOrigen.Focus()
            Exit Sub
         End If

         If String.IsNullOrWhiteSpace(txtRangoCeldas2.Text) Then
            ShowMessage("ATENCION: Debe indicar la ultima FILA del archivo")
            txtRangoCeldas2.Focus()
            Exit Sub
         End If

         Dim rangoExcel = String.Format("[{0}{1}{2}]",
                                        txtRangoCeldas1.Text.Trim.Replace(" ", ""), txtRangoCeldas11.Text.Trim.Replace(" ", ""), txtRangoCeldas2.Text.Trim.Replace(" ", ""))

         If rangoExcel = "" Or rangoExcel = "[An:In]" Then
            ShowMessage("Debe indicar el rango de celdas a leer del archivo Excel")
            txtRangoCeldas1.Focus()
            Exit Sub
         End If

         If cboAccion.Text = "Altas" Then
            chbAltaProductos.Checked = True
         Else
            chbAltaProductos.Checked = False
         End If

         'btnMostrar.Enabled = False

         CargarGrillaDetalle(rangoExcel, cmbActivos.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos))

         grbPendientes.Enabled = False
         btnDesbloquearFiltros.Enabled = True
         tsbImportar.Enabled = True
         tsbImportarParaComparar.Enabled = _funcion = nombreFuncionComparar

      End Sub)
   End Sub
   Private Sub btnDesbloquearFiltros_Click(sender As Object, e As EventArgs) Handles btnDesbloquearFiltros.Click
      TryCatched(
      Sub()
         grbPendientes.Enabled = True
         btnDesbloquearFiltros.Enabled = False
      End Sub)
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarGrilla())
   End Sub
   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      TryCatched(
      Sub()
         If dgvDetalle.RowCount = 0 Then Exit Sub

         dgvDetalle.Update()
         dgvListasPrecios.UpdateData()
         dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit)

         Dim actualizaProductoSinCambios = chbActualizaProductosSinCambios.Checked '# Actualiza la fecha de actualizción de los productos sin cambios

         If cboAccion.Text = "Todas" Or cboAccion.Text = "Sin Cambios" Then
            ShowMessage("ATENCION: No puede seleccionar Todas o Sin Cambios en Accion, seleccione Altas o Modificación en forma separada.")
            Exit Sub
         Else
            If cboAccion.Text = "Altas" And ColumnaPrecioVenta = 99 Then
               For Each drPrecios As UltraGridRow In dgvListasPrecios.Rows
                  If CBool(drPrecios.Cells(ListaPreciosColumns.PorcActual.ToString()).Value.ToString()) Then
                     ShowMessage("ATENCION: No puede seleccionar Porcentaje Actual en calculo de precio de Venta si es Alta de producto")
                     Exit Sub
                  End If
               Next
            End If
         End If

         Dim ProductosAImportar As Integer = 0
         DirectCast(dgvDetalle.DataSource, DataTable).AcceptChanges()
         ProductosAImportar = DirectCast(dgvDetalle.DataSource, DataTable).Select("Importa = True").Length

         ProductosConError = DirectCast(dgvDetalle.DataSource, DataTable).Select("Importa = False").Length
         If ProductosConError > 0 AndAlso ShowPregunta(String.Format("ATENCION: Existen {0} Productos que NO se Importarán. ¿ Confirma el proceso ?", ProductosConError)) <> DialogResult.Yes Then
            Exit Sub
         End If

         ImportarDatos()

         ShowMessage(String.Format("Se importaron {0} Productos EXITOSAMENTE !!!", ProductosAImportar))

         tsbImportar.Enabled = False
         tsbImportarParaComparar.Enabled = If(_funcion = nombreFuncionComparar, False, True)

         prbImportando.Value = 0
      End Sub)
   End Sub
   Private Sub tsbImportarParaComparar_Click(sender As Object, e As EventArgs) Handles tsbImportarParaComparar.Click
      TryCatched(Sub() ImportarDatosParaComparar())
   End Sub
   Private Sub tsbCambiaParametros_Click(sender As Object, e As EventArgs) Handles tsbCambiaParametros.Click
      TryCatched(
      Sub()
         Using frm = New MovimientosDeComprasParametros(_decimalesAMostrarEnTotalXProducto,
                                                        _decimalesAMostrarEnPrecio,
                                                        _decimalesRedondeoEnPrecio,
                                                        _decimalesEnCantidad,
                                                        _decimalesMostrarEnCantidad,
                                                        _decimalesEnTotales,
                                                        _permiteModificarSubtotal)

            '# No permito modificar los demás campos no sean de Mostrar en Precio
            frm.txtComprasDecimalesEnTotal.Enabled = False
            frm.txtComprasDecimalesEnTotalXProducto.Enabled = False
            frm.txtComprasDecimalesMostrarEnCantidad.Enabled = False
            frm.txtComprasDecimalesRedondeoEnCantidad.Enabled = False
            frm.txtComprasDecimalesRedondeoEnPrecio.Enabled = False

            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

               _decimalesAMostrarEnTotalXProducto = frm.DecimalesAMostrarEnTotalXProducto
               _decimalesAMostrarEnPrecio = frm.DecimalesAMostrarEnPrecio
               _formatoAMostrarEnPrecio = String.Format("N{0}", _decimalesAMostrarEnPrecio)
               _decimalesRedondeoEnPrecio = frm.DecimalesRedondeoEnPrecio
               _decimalesEnCantidad = frm.DecimalesEnCantidad
               _decimalesMostrarEnCantidad = frm.DecimalesMostrarEnCantidad
               _decimalesEnTotales = frm.DecimalesEnTotales
               _permiteModificarSubtotal = frm.PermiteModificarSubtotal

               SeteaFormatosACampos()
            End If
         End Using
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
#Region "Eventos Buscador Plantillas"
   Private Sub bscCodigoPlantilla_BuscadorClick() Handles bscCodigoPlantilla.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaPlantillas(bscCodigoPlantilla)
         Dim codigoPlantilla = bscCodigoPlantilla.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoPlantilla.Datos = New Reglas.Plantillas().GetFiltradoPorCodigo(codigoPlantilla)
      End Sub)
   End Sub
   Private Sub bscPlantilla_BuscadorClick() Handles bscPlantilla.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaPlantillas(bscPlantilla)
         bscPlantilla.Datos = New Reglas.Plantillas().GetFiltradoPorNombre(bscPlantilla.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoPlantilla_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoPlantilla.BuscadorSeleccion, bscPlantilla.BuscadorSeleccion
      TryCatched(Sub() CargarDatosPlantilla(e.FilaDevuelta))
   End Sub
#End Region
#Region "Eventos Buscador Proveedor"
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      TryCatched(
      Sub()
         Dim DialogoAbrirArchivo = New OpenFileDialog With {
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop,
            .Filter = "Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|Todos los Archivos (*.*)|*.*",
            .FilterIndex = 1,
            .RestoreDirectory = True
         }
         If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtArchivoOrigen.Text = DialogoAbrirArchivo.FileName
         End If
      End Sub)
   End Sub

#Region "Eventos Alta Producto"
   Private Sub chbAltaProductos_CheckedChanged(sender As Object, e As EventArgs) Handles chbAltaProductos.CheckedChanged
      TryCatched(
      Sub()
         grpAltaProductos.Enabled = chbAltaProductos.Checked
         If Not chbAltaProductos.Checked Then
            chbMoneda.Checked = False
            chbAlicuota.Checked = False
            chbMarca.Checked = False
            chbRubro.Checked = False
            chbMoneda.Enabled = True
            chbAlicuota.Enabled = True
            chbMarca.Enabled = True
            chbRubro.Enabled = True
         Else
            If ColumnaMoneda = 99 Then
               chbMoneda.ForeColor = Color.LimeGreen
            Else
               chbMoneda.ForeColor = SystemColors.ControlText
            End If
            If ColumnaIVA = 99 Then
               chbAlicuota.ForeColor = Color.LimeGreen
            Else
               chbAlicuota.ForeColor = SystemColors.ControlText
            End If
            If ColumnaNombreMarca = 99 Then
               chbMarca.ForeColor = Color.LimeGreen
            Else
               chbMarca.ForeColor = SystemColors.ControlText
            End If
            If ColumnaNombreRubro = 99 Then
               chbRubro.ForeColor = Color.LimeGreen
            Else
               chbRubro.ForeColor = SystemColors.ControlText
            End If
         End If
      End Sub)
   End Sub

   Private Sub chbMoneda_CheckedChanged(sender As Object, e As EventArgs) Handles chbMoneda.CheckedChanged
      TryCatched(Sub() chbMoneda.FiltroCheckedChanged(cmbMoneda))
   End Sub
   Private Sub chbAlicuota_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlicuota.CheckedChanged
      TryCatched(Sub() chbAlicuota.FiltroCheckedChanged(cmbTipoImpuesto))
   End Sub

#Region "Eventos Alta Producto / Buscador Marca"
   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(Sub() chbMarca.FiltroCheckedChanged(bscCodigoMarca, bscMarca))
   End Sub
   Private Sub bscCodigoMarca_BuscadorClick() Handles bscCodigoMarca.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMarcas(bscCodigoMarca)
         bscCodigoMarca.Datos = New Reglas.Marcas().GetPorCodigo(bscCodigoMarca.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscMarca_BuscadorClick() Handles bscMarca.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMarcas(bscMarca)
         bscMarca.Datos = New Reglas.Marcas().GetPorNombre(bscMarca.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoMarca_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoMarca.BuscadorSeleccion, bscMarca.BuscadorSeleccion
      TryCatched(Sub() CargarMarca(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Alta Producto / Buscador Rubro"
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(bscCodigoRubro, bscRubro))
   End Sub
   Private Sub bscCodigoRubro_BuscadorClick() Handles bscCodigoRubro.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros(bscCodigoRubro)
         bscCodigoRubro.Datos = New Reglas.Rubros().GetPorCodigo(bscCodigoRubro.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscRubro_BuscadorClick() Handles bscRubro.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaRubros(bscRubro)
         bscRubro.Datos = New Reglas.Rubros().GetPorNombre(bscRubro.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro.BuscadorSeleccion, bscRubro.BuscadorSeleccion
      TryCatched(Sub() CargarRubro(e.FilaDevuelta))
   End Sub
#End Region

#End Region

   Private Sub chbDR1_CheckedChanged(sender As Object, e As EventArgs) Handles chbDR1.CheckedChanged
      TryCatched(Sub() chbDR1.FiltroCheckedChanged(txtDescuento1, "", "0.00"))
   End Sub
   Private Sub chbDR2_CheckedChanged(sender As Object, e As EventArgs) Handles chbDR2.CheckedChanged
      TryCatched(Sub() chbDR2.FiltroCheckedChanged(txtDescuento2, "", "0.00"))
   End Sub
   Private Sub chbDR3_CheckedChanged(sender As Object, e As EventArgs) Handles chbDR3.CheckedChanged
      TryCatched(Sub() chbDR3.FiltroCheckedChanged(txtDescuento3, "", "0.00"))
   End Sub
   Private Sub chbDR4_CheckedChanged(sender As Object, e As EventArgs) Handles chbDR4.CheckedChanged
      TryCatched(Sub() chbDR4.FiltroCheckedChanged(txtDescuento4, "", "0.00"))
   End Sub

   Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
      TryCatched(
      Sub()
         If Not _estaCargando Then
            tsbImportar.Enabled = (cboEstado.Text <> "Invalidos")
         End If
      End Sub)
   End Sub
   Private Sub cboDescripcion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDescripcion.SelectedIndexChanged
      TryCatched(Sub() ColumnasGrilla())
   End Sub
   Private Sub cboAccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAccion.SelectedIndexChanged
      TryCatched(
      Sub()
         chbAltaProductos.Enabled = cboAccion.Text = "Altas"
         chbAltaProductos.Checked = cboAccion.Text = "Altas"
      End Sub)
   End Sub

#End Region

#Region "Eventos Grilla"
   Private Sub dgvListasPrecios_CellChange(sender As Object, e As CellEventArgs) Handles dgvListasPrecios.CellChange
      Try
         If e.Cell.Column.DataType.Equals(GetType(Boolean)) AndAlso
            e.Cell.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Cell.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then

            Dim dr As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row

            If e.Cell.Column.Key <> ListaPreciosColumns.PorcActual.ToString() Then
               dr(ListaPreciosColumns.PorcActual.ToString()) = False
            End If

            If e.Cell.Column.Key <> ListaPreciosColumns.SobreVenta.ToString() Then
               dr(ListaPreciosColumns.SobreVenta.ToString()) = False
            End If

            If e.Cell.Column.Key <> ListaPreciosColumns.SobreCosto.ToString() Then
               dr(ListaPreciosColumns.SobreCosto.ToString()) = False
            End If

            If e.Cell.Column.Key <> ListaPreciosColumns.DesdeFormula.ToString() Then
               dr(ListaPreciosColumns.DesdeFormula.ToString()) = False
            End If

            'If e.Cell.Column.Key = ListaPreciosColumns.PorcActual.ToString() Then
            '   dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = dr(ListaPreciosColumns.PorcentajeCosto.ToString())
            'Else
            '   dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = dr(ListaPreciosColumns.PorcentajeBase.ToString())
            'End If


            dgvListasPrecios.PerformAction(UltraGridAction.ExitEditMode)
            dgvListasPrecios.UpdateData()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub dgvListasPrecios_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvListasPrecios.InitializeRow
      If Boolean.Parse(e.Row.Cells(ListaPreciosColumns.PorcActual.ToString()).Value.ToString()) Then
         e.Row.Cells(ListaPreciosColumns.PorcActual.ToString()).Activation = Activation.NoEdit
         e.Row.Cells(ListaPreciosColumns.PorcentajeCalculado.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.PorcActual.ToString()).Activation = Activation.AllowEdit
         e.Row.Cells(ListaPreciosColumns.PorcentajeCalculado.ToString()).Activation = Activation.AllowEdit
      End If
      If Boolean.Parse(e.Row.Cells(ListaPreciosColumns.SobreVenta.ToString()).Value.ToString()) Then
         e.Row.Cells(ListaPreciosColumns.SobreVenta.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.SobreVenta.ToString()).Activation = Activation.AllowEdit
      End If
      If Boolean.Parse(e.Row.Cells(ListaPreciosColumns.SobreCosto.ToString()).Value.ToString()) Then
         e.Row.Cells(ListaPreciosColumns.SobreCosto.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.SobreCosto.ToString()).Activation = Activation.AllowEdit
      End If
      If Boolean.Parse(e.Row.Cells(ListaPreciosColumns.DesdeFormula.ToString()).Value.ToString()) Then
         e.Row.Cells(ListaPreciosColumns.DesdeFormula.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.DesdeFormula.ToString()).Activation = Activation.AllowEdit
      End If
   End Sub

   Private Sub dgvDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
      Try
         Me.FormatearGrilla()
         If e.RowIndex <> -1 Then
            If Me.dgvDetalle.RowCount <> 0 Then
               If Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "DescuentoRecargoPorc1" Or
                       Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "DescuentoRecargoPorc2" Or
                       Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "DescuentoRecargoPorc3" Or
                       Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "DescuentoRecargoPorc4" Then
                  Me.dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Display)
               End If
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub dgvDetalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
      Try
         Me.FormatearGrilla()

         If e.RowIndex <> -1 AndAlso Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "DescuentoRecargoPorc1" Or
               Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "DescuentoRecargoPorc2" Or
               Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "DescuentoRecargoPorc3" Or
               Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "DescuentoRecargoPorc4" Then

            Dim dgrDetalle As DataGridViewRow = Me.dgvDetalle.Rows(e.RowIndex)

            Me.dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Display)

            If Boolean.Parse(dgrDetalle.Cells("Importa").Value.ToString()) = False Then
               MessageBox.Show("Solo puede modificar si la fila Importa datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               dgrDetalle.Cells(e.ColumnIndex).Value = 0
               Exit Sub
            End If

            Try
               If Me._plantilla.Proveedor.IdProveedor = Nothing Then
                  MessageBox.Show("No se puede modificar el descuento si la plantilla no tiene Proveedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  dgrDetalle.Cells(e.ColumnIndex).Value = 0
               Else
                  If Decimal.Parse(dgrDetalle.Cells(e.ColumnIndex).Value.ToString()) > -100.0 And Decimal.Parse(dgrDetalle.Cells(e.ColumnIndex).Value.ToString()) < 100.0 Then
                     dgrDetalle.Cells("PrecioCosto").Value = dgrDetalle.Cells("PrecioCompra").Value
                     If Not String.IsNullOrEmpty(dgrDetalle.Cells("DescuentoRecargoPorc1").Value.ToString()) Then
                        dgrDetalle.Cells("PrecioCosto").Value = (Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()) + (Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()) * Decimal.Parse(dgrDetalle.Cells("DescuentoRecargoPorc1").Value.ToString()) / 100)).ToString()
                     End If
                     If Not String.IsNullOrEmpty(dgrDetalle.Cells("DescuentoRecargoPorc2").Value.ToString()) Then
                        dgrDetalle.Cells("PrecioCosto").Value = (Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()) + (Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()) * Decimal.Parse(dgrDetalle.Cells("DescuentoRecargoPorc2").Value.ToString()) / 100)).ToString()
                     End If
                     If Not String.IsNullOrEmpty(dgrDetalle.Cells("DescuentoRecargoPorc3").Value.ToString()) Then
                        dgrDetalle.Cells("PrecioCosto").Value = (Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()) + (Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()) * Decimal.Parse(dgrDetalle.Cells("DescuentoRecargoPorc3").Value.ToString()) / 100)).ToString()
                     End If
                     If Not String.IsNullOrEmpty(dgrDetalle.Cells("DescuentoRecargoPorc4").Value.ToString()) Then
                        dgrDetalle.Cells("PrecioCosto").Value = (Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()) + (Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()) * Decimal.Parse(dgrDetalle.Cells("DescuentoRecargoPorc4").Value.ToString()) / 100)).ToString()
                     End If

                     dgrDetalle.Cells("PrecioCosto").Value = Math.Round(Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()), _decimalesEnPrecio)

                     If Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()) = Decimal.Parse(dgrDetalle.Cells("PrecioCostoAnterior").Value.ToString()) Then
                        dgrDetalle.Cells("Accion").Value = "Sin Cambios"
                        dgrDetalle.Cells("Importa").Value = False
                        dgrDetalle.Cells("Importa").Style.BackColor = Color.LightCoral
                     Else
                        If Decimal.Parse(dgrDetalle.Cells("PrecioCostoAnterior").Value.ToString()) = 0 Then
                           dgrDetalle.Cells("Importa").Style.BackColor = Color.LimeGreen
                        Else
                           dgrDetalle.Cells("Accion").Value = "Modifica"
                           dgrDetalle.Cells("Importa").Style.BackColor = Color.LimeGreen
                           Dim var As Decimal = 0
                           var = Decimal.Parse(dgrDetalle.Cells("PrecioCostoAnterior").Value.ToString()) - Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString())
                           dgrDetalle.Cells("PorcVarCosto").Value = (var / Decimal.Parse(dgrDetalle.Cells("PrecioCosto").Value.ToString()) * 100) * -1
                        End If
                     End If

                     Dim varCompra As Decimal = 0
                     varCompra = Decimal.Parse(dgrDetalle.Cells("PrecioCompraAnterior").Value.ToString()) - Decimal.Parse(dgrDetalle.Cells("PrecioCompra").Value.ToString())
                     dgrDetalle.Cells("PorcVarCompra").Value = (varCompra / Decimal.Parse(dgrDetalle.Cells("PrecioCompra").Value.ToString()) * 100) * -1

                  Else
                     MessageBox.Show("El porcentaje no es correcto!. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     dgrDetalle.Cells(e.ColumnIndex).Value = 0
                  End If
               End If

            Catch ex As Exception
               MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
               Me.Cursor = Cursors.Default
            End Try

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try


   End Sub
   Private Sub dgvDetalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetalle.DataError
      Try
         If e.Exception IsNot Nothing Then
            MessageBox.Show("El formato no es el correcto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = False
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub FitColumns()

      With dgvDetalle
         .Columns("PrecioCompraAnterior").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("PorcVarCompra").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("PrecioCompra").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("DescuentoRecargoPorc1").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("DescuentoRecargoPorc2").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("DescuentoRecargoPorc3").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("DescuentoRecargoPorc4").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("DescuentoRecargoPorc5").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("DescuentoRecargoPorc6").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("PrecioCostoAnterior").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("PorcVarCosto").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("PrecioCosto").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
         .Columns("PrecioVenta").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
      End With

   End Sub

   Private Sub CargarDecimales()

      '-- REQ-32572.- ---------------------------------------------------------
      _decimalesEnPrecio = Reglas.Publicos.PreciosDecimalesEnVenta
      _formatoEnPrecio = String.Concat("N", _decimalesEnPrecio)
      '------------------------------------------------------------------------

      _decimalesEnTotales = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral
      _decimalesRedondeoEnPrecio = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnPrecio
      _decimalesAMostrarEnPrecio = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnPrecio
      _formatoAMostrarEnPrecio = String.Format("N{0}", _decimalesAMostrarEnPrecio)
      _decimalesAMostrarEnTotalXProducto = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalXProducto

      If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
         _decimalesEnCantidad = 0
         _decimalesMostrarEnCantidad = 0
         'Me.txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
      Else
         _decimalesEnCantidad = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad
         _decimalesMostrarEnCantidad = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad
      End If
   End Sub

   Private Sub SeteaFormatosACampos()

      '# Descuentos
      txtDescuento1.Formato = _formatoAMostrarEnPrecio
      txtDescuento2.Formato = _formatoAMostrarEnPrecio
      txtDescuento3.Formato = _formatoAMostrarEnPrecio
      txtDescuento4.Formato = _formatoAMostrarEnPrecio

      '# Importes en Grillas
      With dgvDetalle
         .Columns("PrecioCompraAnterior").DefaultCellStyle.Format = _formatoEnPrecio
         .Columns("PrecioCompra").DefaultCellStyle.Format = _formatoEnPrecio
         .Columns("PrecioCostoAnterior").DefaultCellStyle.Format = _formatoEnPrecio
         .Columns("PrecioCosto").DefaultCellStyle.Format = _formatoEnPrecio
         .Columns("PrecioVenta").DefaultCellStyle.Format = _formatoEnPrecio

         .Columns("PorcVarCompra").DefaultCellStyle.Format = _formatoAMostrarEnPrecio
         .Columns("DescuentoRecargoPorc1").DefaultCellStyle.Format = _formatoAMostrarEnPrecio
         .Columns("DescuentoRecargoPorc2").DefaultCellStyle.Format = _formatoAMostrarEnPrecio
         .Columns("DescuentoRecargoPorc3").DefaultCellStyle.Format = _formatoAMostrarEnPrecio
         .Columns("DescuentoRecargoPorc4").DefaultCellStyle.Format = _formatoAMostrarEnPrecio
         .Columns("DescuentoRecargoPorc5").DefaultCellStyle.Format = _formatoAMostrarEnPrecio
         .Columns("DescuentoRecargoPorc6").DefaultCellStyle.Format = _formatoAMostrarEnPrecio
         .Columns("PorcVarCosto").DefaultCellStyle.Format = _formatoAMostrarEnPrecio

         '# Fit Columns
         FitColumns()
      End With
   End Sub

   Private Sub PrepararPantallaParaComparacion()

      '# Combo de Acción bloqueado para que solo muestre los productos que se encuentran en el sistema
      cboAccion.Enabled = False

      '# Alta de Productos bloqueada
      chbAltaProductos.Visible = False
      grpAltaProductos.Visible = chbAltaProductos.Visible

      '# Quito la solapa de Precios (ya que no se van a importar los precios, no es necesario setear el %)
      tbcDatos.TabPages.Remove(tbpPrecios)

      '# Oculto el botón de Importar y muestro el botón de Grabar para Comparar
      tsbImportar.Visible = False
      tsbImportarParaComparar.Visible = True

      '# Título de la pantalla
      Text = "Importar Productos desde Plantillas Excel para Comparar"

   End Sub

   Private Sub RefrescarGrilla()

      txtArchivoOrigen.Text = ""

      txtRangoCeldas1.Text = "An"

      cboDescripcion.SelectedIndex = 0

      cboAccion.SelectedIndex = 2
      cboEstado.SelectedIndex = 0
      cmbDescripcionCorte.SelectedIndex = 0

      cmbPrecioPorEmbalaje.SelectedValue = PrecioPorEmbalaje.No
      cmbActivos.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      chbHabitual.Checked = True

      txtPrefijo.Text = ""
      bscCodigoPlantilla.Text = ""
      bscPlantilla.Text = ""

      bscCodigoProveedor.Text = ""
      bscProveedor.Text = ""

      If TypeOf (dgvDetalle.DataSource) Is DataTable Then
         DirectCast(dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      'If Not Me._dt Is Nothing Then
      '   Me._dt.Rows.Clear()
      'End If
      txtRangoCeldas2.Text = ""
      prbImportando.Value = 0

      ColumnaIdProducto = 99
      ColumnaNombreProducto = 99
      ColumnaNombreProducto2 = 99
      ColumnaNombreMarca = 99
      ColumnaNombreRubro = 99
      ColumnaNombreSubRubro = 99
      ColumnaNombreSubSubRubro = 99
      ColumnaIVA = 99
      ColumnaPrecioCompra = 99
      ColumnaPrecioCosto = 99
      ColumnaPrecioVenta = 99
      ColumnaMoneda = 99
      ColumnaCodigoDeBarras = 99
      ColumnaPrecioCostoAnterior = 99
      ColumnaPorVarCosto = 99
      ColumnaCodigoLargoProducto = 99
      ColumnaObservacion = 99
      ColumnaIdProductoNumerico = 99
      '# La función COMPARAR no tiene visible esta solapa/grilla
      If _funcion = nombreFuncionImportar Then
         CreaDTPrecios()
         CargaDTPrecios()
         dgvListasPrecios.DataSource = dtListaPrecios
         FormateaGrillaPrecios()
      End If

      chbAltaProductos.Checked = False
      tsbImportar.Enabled = False
      bscPlantilla.Focus()
      chbDR1.Checked = False
      chbDR2.Checked = False
      chbDR3.Checked = False
      chbDR4.Checked = False

      grbPendientes.Enabled = True
      btnDesbloquearFiltros.Enabled = False

      tssRegistros.Text = dgvDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", GetType(Boolean))
         '.Columns.Add("LineaExcel", GetType(Long)))
         .Columns.Add("Accion", GetType(String))
         .Columns.Add("CodigoProducto", GetType(String))
         .Columns.Add("CodigoProveedor", GetType(String))
         .Columns.Add("IdProductoNumerico", GetType(Long))
         .Columns.Add("CodigoLargoProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("NombreProducto2", GetType(String))
         .Columns.Add("IVA", GetType(Decimal))
         .Columns.Add("PrecioCompraAnterior", GetType(Decimal))
         .Columns.Add("PorcVarCompra", GetType(Decimal))
         .Columns.Add("PrecioCompra", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorc1", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorc2", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorc3", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorc4", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorc5", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorc6", GetType(Decimal))
         .Columns.Add("PrecioCostoAnterior", GetType(Decimal))
         .Columns.Add("PorcVarCosto", GetType(Decimal))
         .Columns.Add("PrecioCosto", GetType(Decimal))
         .Columns.Add("PrecioVenta", GetType(Decimal))
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("Moneda", GetType(String))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("CodigoDeBarras", GetType(String))
         .Columns.Add("Mensaje", GetType(String))
         .Columns.Add("EsOferta", GetType(Boolean)).DefaultValue = False
         .Columns.Add("Stock", GetType(Decimal))
      End With

      Return dtTemp

   End Function

   Sub AbrirExcel(ArchivoXLS As String)

      Dim m_sConn1 As String

      If ArchivoXLS.ToUpper.EndsWith(".XLSX") Then
         'm_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
         m_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 12.0;HDR=NO;IMEX=1"";"
      Else
         m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
      End If


      ConexionExcel = New OleDb.OleDbConnection(m_sConn1)
      ConexionExcel.Open()

   End Sub

   Private Sub ColumnasGrilla()

      If _estaCargando Then Exit Sub

      If cboDescripcion.SelectedIndex = 1 Then  'Dos columnas

         dgvDetalle.Columns("NombreProducto").Width = 200
         dgvDetalle.Columns("NombreProducto2").Visible = True

         ColumnaIdProducto = 0
         ColumnaIdProductoNumerico = 1
         ColumnaNombreProducto = 2
         ColumnaNombreProducto2 = 3
         ColumnaNombreMarca = 4
         ColumnaNombreRubro = 5
         ColumnaNombreSubRubro = 6
         ColumnaNombreSubSubRubro = 7
         ColumnaIVA = 8
         ColumnaPrecioCosto = 9
         ColumnaPrecioVenta = 10
         ColumnaMoneda = 11
         ColumnaCodigoDeBarras = 12
         'ColumnaCodigoLargoProducto = 13
         ' ColumnaObservacion = 14

      Else

         dgvDetalle.Columns("NombreProducto").Width = 300
         dgvDetalle.Columns("NombreProducto2").Visible = False

         ColumnaIdProducto = 0
         ColumnaIdProductoNumerico = 1
         ColumnaNombreProducto = 2
         ColumnaNombreMarca = 3
         ColumnaNombreRubro = 4
         ColumnaNombreSubRubro = 5
         ColumnaNombreSubSubRubro = 6
         ColumnaIVA = 7
         ColumnaPrecioCosto = 8
         ColumnaPrecioVenta = 9
         ColumnaMoneda = 10
         ColumnaCodigoDeBarras = 11
         ' ColumnaCodigoLargoProducto = 13
         'ColumnaObservacion = 14
      End If

   End Sub

   Private AnchoIdProducto As Integer
   Private AnchoCodProductoProveedor As Integer
   Private AnchoNombreProducto As Integer
   Private AnchoCodigoLargoProducto As Integer
   Private AnchoObservacion As Integer
   Private AnchoNombreMarca As Integer
   Private AnchoNombreRubro As Integer
   Private AnchoCodigoDeBarras As Integer


   Private Sub CargarGrillaDetalle(rangoExcel As String, activos As Entidades.Publicos.SiNoTodos)

      Try

         Me.Cursor = Cursors.WaitCursor

         'Dim dt As DataTable
         'Dim drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos

         AnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto") ' # no se usa

         AnchoCodProductoProveedor = oPublicos.GetAnchoCampo(Entidades.ProductoProveedor.NombreTabla, Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString())

         AnchoNombreProducto = oPublicos.GetAnchoCampo("Productos", "NombreProducto")

         AnchoCodigoLargoProducto = oPublicos.GetAnchoCampo("Productos", "CodigoLargoProducto")

         AnchoObservacion = oPublicos.GetAnchoCampo("Productos", "Observacion")

         AnchoNombreMarca = oPublicos.GetAnchoCampo("Marcas", "NombreMarca")

         AnchoNombreRubro = oPublicos.GetAnchoCampo("Rubros", "NombreRubro")

         AnchoCodigoDeBarras = oPublicos.GetAnchoCampo("Productos", "CodigoDeBarras")


         'Dim condicionBusquedaProductoProveedor As String
         'If chbHabitual.Checked Then
         '   condicionBusquedaProductoProveedor = "CodigoProductoProveedor = '{0}' AND idProveedor = {1} AND Habitual"
         'Else
         '   condicionBusquedaProductoProveedor = "CodigoProductoProveedor = '{0}' AND idProveedor = {1}"
         'End If


         Me.tsbImportar.Enabled = False
         Me.tsbSalir.Enabled = False

         ProductosConError = 0

         'Leo el archivo y lo subo a la grilla. 

         Dim dt = CrearDT()

         Dim ds As DataSet = New DataSet()
         Dim DA As New System.Data.OleDb.OleDbDataAdapter

         Me.AbrirExcel(txtArchivoOrigen.Text)

         DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & rangoExcel, Me.ConexionExcel)
         DA.Fill(ds)

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String
         Dim i As Integer = 0
         Dim registros As Integer = 0
         Dim cache As Reglas.BusquedasCacheadas



         Me.tssRegistros.Text = ds.Tables(0).Rows.Count.ToString() + " registros obtenidos del excel."
         System.Windows.Forms.Application.DoEvents()

         registros = ds.Tables(0).Rows.Count


         Dim dicProductosProveedores As Dictionary(Of String, Dictionary(Of Long, DataRow)) = New Dictionary(Of String, Dictionary(Of Long, DataRow))()
         My.Application.Log.WriteEntry(String.Format("{0}{1:dd/MM/yyyy HH:mm:ss.fff} Antes de buscar los ProductosProveedores a BD", Name, Now, TraceEventType.Verbose))
         Using dtProductosProveedores As DataTable = oProductos.GetProductosProveedores()

            My.Application.Log.WriteEntry(String.Format("{0}{1:dd/MM/yyyy HH:mm:ss.fff} Despues de buscar los ProductosProveedores a BD", Name, Now, TraceEventType.Verbose))

            My.Application.Log.WriteEntry(String.Format("{0}{1:dd/MM/yyyy HH:mm:ss.fff} Antes de Convertir los ProductosProveedores en Dictionary", Name, Now, TraceEventType.Verbose))

            For Each drProductosProveedores As DataRow In dtProductosProveedores.Select(If(chbHabitual.Checked, "Habitual", ""))
               Dim codigoProducto As String = drProductosProveedores.Field(Of String)("CodigoProductoProveedor")
               codigoProducto = If(codigoProducto Is Nothing, String.Empty, codigoProducto)
               Dim idProveedorDt As Long = drProductosProveedores.Field(Of Long)("IdProveedor")

               If Not dicProductosProveedores.ContainsKey(codigoProducto) Then
                  dicProductosProveedores.Add(codigoProducto, New Dictionary(Of Long, DataRow)())
               End If
               Dim dicProveedor As Dictionary(Of Long, DataRow) = dicProductosProveedores(codigoProducto)
               If Not dicProveedor.ContainsKey(idProveedorDt) Then
                  dicProveedor.Add(idProveedorDt, drProductosProveedores)
               End If
            Next
            My.Application.Log.WriteEntry(String.Format("{0}{1:dd/MM/yyyy HH:mm:ss.fff} Despues de Convertir los ProductosProveedores en Dictionary", Name, Now, TraceEventType.Verbose))
         End Using

         Dim dicProductosCant As Dictionary(Of String, DataRow) = New Dictionary(Of String, DataRow)()
         My.Application.Log.WriteEntry(String.Format("{0}{1:dd/MM/yyyy HH:mm:ss.fff} Antes de buscar los ProductosCant a BD", Name, Now, TraceEventType.Verbose))
         Using dtProductosCant As DataTable = oProductos.GetProductosCant(actual.Sucursal.IdSucursal, Integer.Parse(cmbListaPrecios.SelectedValue.ToString()))
            My.Application.Log.WriteEntry(String.Format("{0}{1:dd/MM/yyyy HH:mm:ss.fff} Antes de buscar los ProductosCant a BD", Name, Now, TraceEventType.Verbose))

            My.Application.Log.WriteEntry(String.Format("{0}{1:dd/MM/yyyy HH:mm:ss.fff} Antes de Convertir los ProductosCant en Dictionary", Name, Now, TraceEventType.Verbose))
            For Each drProductosCant As DataRow In dtProductosCant.Rows
               Dim idProducto As String = drProductosCant.Field(Of String)("IdProducto")
               If Not dicProductosCant.ContainsKey(idProducto) Then
                  dicProductosCant.Add(idProducto, drProductosCant)
               End If
            Next
            My.Application.Log.WriteEntry(String.Format("{0}{1:dd/MM/yyyy HH:mm:ss.fff} Despues de Convertir los ProductosCant en Dictionary", Name, Now, TraceEventType.Verbose))
         End Using

         cache = New Reglas.BusquedasCacheadas()

         Dim codigoProveedor As String
         Dim idProveedor As Long = If(IsNumeric(bscCodigoProveedor.Tag), Long.Parse(bscCodigoProveedor.Tag.ToString()), 0)


         For Each dr In ds.Tables(0).Rows

            My.Application.Log.WriteEntry(String.Format("{0}{1:dd/MM/yyyy HH:mm:ss.fff} Inicia Producto {2}", Name, Now, dr(ColumnaIdProducto).ToString.Trim(), TraceEventType.Verbose))

            Accion = "Alta"
            i += 1

            If i Mod 10 = 0 Then
               Me.tssRegistros.Text = String.Format("Cargando registro {0}/{1}.", i, registros)
               System.Windows.Forms.Application.DoEvents()
            End If


            Importar = True
            Mensaje = ""

            'If dr(ColumnaIdProducto).ToString.Trim() = "" Or dr(ColumnaNombreMarca).ToString.Trim() = "" Or dr(ColumnaNombreRubro).ToString.Trim() = "" Then
            '   Importar = False
            '   Mensaje = "Hay Campo(s) sin completar"
            'End If


            If dr(ColumnaIdProducto).ToString.Trim() = "" Then
               Importar = False
               '  Mensaje = "Hay Campo(s) sin completar"
            End If


            'drCl("LineaExcel") = ""
            codigoProveedor = dr(ColumnaIdProducto).ToString.Trim.Replace("'", "´").Trim()


            'If drCl("CodigoProducto").ToString.Trim.Length > AnchoIdProducto Then
            '   Importar = False
            '   If Mensaje.Length > 0 Then Mensaje += " - "
            '   Mensaje += "Digitos del Codigo del Producto es Mayor a " & AnchoIdProducto.ToString()
            'Else
            '   Accion = IIf(oProductos.Existe(drCl("CodigoProducto")), "M", "A")
            'End Iff

            If codigoProveedor.Length > AnchoCodProductoProveedor Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Codigo del Producto Proveedor es Mayor a " & AnchoCodProductoProveedor.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     codigoProveedor = codigoProveedor.ToString.Remove(AnchoCodProductoProveedor)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Codigo del Producto Proveedor es Mayor a " & AnchoCodProductoProveedor.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     'drCl("CodigoProducto") = dr(ColumnaIdProducto).ToString.Trim.Replace("'", "´").Remove(AnchoIdProducto)
                     codigoProveedor = codigoProveedor.ToString.Remove(AnchoCodProductoProveedor)
                  End If
               End If
            End If

            If Me.chbCodigosProveedor.Checked And Me.bscCodigoProveedor.Text <> "" Then
               'Accion = IIf(dtProductosProveedores.Select(String.Format(condicionBusquedaProductoProveedor, codigoProveedor, Me.bscCodigoProveedor.Tag)).Count > 0, "Modifica", "Alta").ToString()
               Accion = If(dicProductosProveedores.ContainsKey(codigoProveedor) AndAlso dicProductosProveedores(codigoProveedor).ContainsKey(idProveedor), "Modifica", "Alta")
            Else
               'Accion = IIf(dtProductosCant.Select(String.Format("idProducto = '{0}'", codigoProveedor)).Count > 0, "Modifica", "Alta").ToString()
               Accion = If(dicProductosCant.ContainsKey(codigoProveedor), "Modifica", "Alta")
            End If


            Dim ProductoM As Entidades.ProductoLivianoParaImportarProducto

            If Accion = "Alta" Then
               If Not Me.chbAltaProductos.Checked Then
                  Importar = False
                  Mensaje = "No existe el Producto"
               End If
               Dim codigoProducto As String = Me.txtPrefijo.Text.Trim() & codigoProveedor.ToString()

               '# Valido que la cantidad de caracteres en el IdProducto sea <= a la permitida
               If codigoProducto.Length > AnchoIdProducto Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Codigo del Producto es Mayor a " & AnchoIdProducto.ToString()
               End If

               ProductoM = Nothing
               CargarGrillaDetalleContinuacion(dt, dr, dicProductosCant, codigoProducto, codigoProveedor, ProductoM, activos, cache, Accion, Mensaje, Importar)
            Else
               If String.IsNullOrWhiteSpace(codigoProveedor) Then
                  'ProductoM = Nothing
                  'CargarGrillaDetalleContinuacion(dt, dr, dicProductosCant, codigoProveedor, codigoProveedor, ProductoM, cache, Accion, Mensaje, Importar)
               Else
                  If chbCodigosProveedor.Checked Then
                     'Dim IdProducto As String = oProductos.IdProductoXProductoProveedor(codigoProveedor, Me.bscCodigoProveedor.Tag)
                     'Dim IdProducto As String = dtProductosProveedores.Select(String.Format("CodigoProductoProveedor = '{0}' AND idProveedor = {1}", codigoProveedor, Me.bscCodigoProveedor.Tag))(0)("idProducto").ToString()
                     'ProductoM = oProductos.GetUnoParaM(IdProducto)
                     'codigoProducto = Me.txtPrefijo.Text.Trim() & ProductoM.IdProducto

                     'For Each drProductosProveedores As DataRow In dtProductosProveedores.Select(String.Format(condicionBusquedaProductoProveedor, codigoProveedor, Me.bscCodigoProveedor.Tag))
                     If dicProductosProveedores.ContainsKey(codigoProveedor) AndAlso
                        dicProductosProveedores(codigoProveedor).ContainsKey(idProveedor) Then
                        'Dim idProducto As String = drProductosProveedores("idProducto").ToString()
                        Dim idProducto As String = dicProductosProveedores(codigoProveedor)(idProveedor).Field(Of String)("IdProducto")
                        ProductoM = oProductos.GetUnoParaM(idProducto)
                        Dim codigoProducto As String = Me.txtPrefijo.Text.Trim() & ProductoM.IdProducto

                        CargarGrillaDetalleContinuacion(dt, dr, dicProductosCant, codigoProducto, codigoProveedor, ProductoM, activos, cache, Accion, Mensaje, Importar)
                     End If
                     'Next

                  Else
                     ProductoM = oProductos.GetUnoParaM(codigoProveedor)
                     Dim codigoProducto As String = Me.txtPrefijo.Text.Trim() & ProductoM.IdProducto
                     CargarGrillaDetalleContinuacion(dt, dr, dicProductosCant, codigoProducto, codigoProveedor, ProductoM, activos, cache, Accion, Mensaje, Importar)
                  End If
               End If
            End If


            'Mostrar2(dt, drCl, dr, dtProductosCant, codigoProducto, codigoProducto, ProductoM, cache, Accion, Mensaje, Importar)

         Next

         If chbMostrarProductosFaltantes.Checked Then
            Dim rProd = New Reglas.Productos()
            Using dtProductos = rProd.GetAll_Ids(idProveedor)
               For Each drProd In dtProductos.AsEnumerable()
                  If Not dt.Any(Function(drXls) drXls.Field(Of String)("CodigoProducto") = drProd.Field(Of String)("IdProducto")) Then
                     Dim prod = rProd.GetUnoParaM(drProd.Field(Of String)("IdProducto"))

                     Dim drCl = dt.NewRow()
                     drCl("CodigoProducto") = prod.IdProducto
                     drCl("NombreProducto") = prod.NombreProducto
                     drCl("Importa") = False
                     drCl("Accion") = "No Importado"
                     drCl("Mensaje") = "El producto no se encuentra en planilla leída, verifique Rango de lectura o comuníquese con su proveedor"

                     dt.Rows.Add(drCl)
                  End If
               Next
            End Using
         End If

         Me.dgvDetalle.DataSource = dt

         If dt.Rows.Count <> 0 Then
            Me.dgvDetalle.Rows(0).Selected = False
         Else
            MessageBox.Show("No hay registros para esta selección.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

         Me.FormatearGrilla()

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         'If Me.cboEstado.Text = "Validos" Then
         'ProductosConError = 0
         'End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldas1.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         If ConexionExcel IsNot Nothing Then
            ConexionExcel.Close()
            ConexionExcel.Dispose()
         End If
         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try
   End Sub

   Private Sub CargarGrillaDetalleContinuacion(dt As DataTable, dr As DataRow, dicProductosCant As Dictionary(Of String, DataRow),
                                               codigoProducto As String, codigoProveedor As String, ProductoM As Entidades.ProductoLivianoParaImportarProducto,
                                               activos As Entidades.Publicos.SiNoTodos,
                                               cache As Reglas.BusquedasCacheadas, ByRef Accion As String, ByRef Mensaje As String, ByRef Importar As Boolean)
      Dim drCl As DataRow
      drCl = dt.NewRow()

      Dim precioPorEmbalajeProducto As Boolean = False
      Dim embalajeProducto As Integer = 1
      'Dim comprasRedondeoEnPrecio As Integer = Publicos.ComprasDecimalesRedondeoEnPrecio

      If ProductoM IsNot Nothing Then
         precioPorEmbalajeProducto = ProductoM.PrecioPorEmbalaje
         embalajeProducto = ProductoM.Embalaje
      End If

      drCl("CodigoProducto") = codigoProducto
      drCl("CodigoProveedor") = codigoProveedor

      If ProductoM IsNot Nothing Then
         drCl("EsOferta") = ProductoM.EsOferta.Equals("SI")
         'drCl("Stock") = Decimal.Parse(dtProductosCant.Select(String.Format("IdProducto = '{0}'", ProductoM.IdProducto))(0)("Stock").ToString())
         drCl("Stock") = dicProductosCant(ProductoM.IdProducto).Field(Of Decimal)("Stock")
      End If

      If ColumnaNombreProducto <> 99 Then
         If Me.chbModificaDescripcion.Checked Then
            If Me.cboDescripcion.SelectedIndex = 1 Then  'Dos Columnas
               drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´")
               drCl("NombreProducto2") = dr(ColumnaNombreProducto2).ToString.Trim.Replace("'", "´")

               If dr(ColumnaNombreProducto).ToString.Trim.Length + 1 + dr(ColumnaNombreProducto2).ToString.Trim.Length > AnchoNombreProducto Then
                  If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & AnchoNombreProducto.ToString()
                  Else
                     If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                        If Mensaje.Length > 0 Then Mensaje += " - "
                        Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & AnchoNombreProducto.ToString()
                     End If
                  End If

               End If

            Else
               drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´")
               drCl("NombreProducto2") = ""

               If dr(ColumnaNombreProducto).ToString.Trim.Length > AnchoNombreProducto Then
                  If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & AnchoNombreProducto.ToString()
                  Else
                     If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                        drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´").Remove(AnchoNombreProducto)
                        drCl("NombreProducto2") = ""
                        If Mensaje.Length > 0 Then Mensaje += " - "
                        Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & AnchoNombreProducto.ToString()
                     End If
                     If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                        drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´").Remove(AnchoNombreProducto)
                        drCl("NombreProducto2") = ""
                     End If
                  End If
               End If
            End If
         Else
            If Accion = "Modifica" Then
               drCl("NombreProducto") = If(ProductoM Is Nothing, String.Empty, ProductoM.NombreProducto)
            Else
               If dr(ColumnaNombreProducto).ToString.Trim.Length > AnchoNombreProducto Then
                  If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & AnchoNombreProducto.ToString()
                  Else
                     If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                        drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´").Remove(AnchoNombreProducto)
                        drCl("NombreProducto2") = ""
                        If Mensaje.Length > 0 Then Mensaje += " - "
                        Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & AnchoNombreProducto.ToString()
                     End If
                     If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                        drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´").Remove(AnchoNombreProducto)
                        drCl("NombreProducto2") = ""
                     End If
                  End If
               Else
                  drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString()
               End If
            End If
         End If

      Else
         If Accion = "Modifica" Then
            drCl("NombreProducto") = If(ProductoM Is Nothing, String.Empty, ProductoM.NombreProducto)
         Else
            Importar = False
            If Mensaje.Length > 0 Then Mensaje += " - "
            Mensaje += "El producto no tiene descripcion " & AnchoNombreProducto.ToString()
         End If
      End If


      If ColumnaCodigoLargoProducto <> 99 Then

         drCl("CodigoLargoProducto") = dr(ColumnaCodigoLargoProducto).ToString.Trim.Replace("'", "´")
         If drCl("CodigoLargoProducto").ToString.Trim.Length > AnchoCodigoLargoProducto Then
            If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Digitos del Nombre de Codigo Largo de Producto es Mayor a " & AnchoCodigoLargoProducto.ToString()
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("CodigoLargoProducto") = dr(ColumnaCodigoLargoProducto).ToString.Trim.Replace("'", "´").Remove(AnchoCodigoLargoProducto)
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Nombre de Codigo Lardo de Producto es Mayor a " & AnchoCodigoLargoProducto.ToString()
               End If
               If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                  drCl("CodigoLargoProducto") = dr(ColumnaCodigoLargoProducto).ToString.Trim.Replace("'", "´").Remove(AnchoCodigoLargoProducto)
               End If
            End If

         End If
      End If

      If ColumnaIdProductoNumerico <> 99 Then
         If Ayudante.ImportarExcel.IsNumeric(dr, ColumnaIdProductoNumerico) Then
            drCl("IdProductoNumerico") = Ayudante.ImportarExcel.GetValorLong(dr, ColumnaIdProductoNumerico)
         End If
      End If

      If ColumnaObservacion <> 99 Then

         drCl("Observacion") = dr(ColumnaObservacion).ToString.Trim.Replace("'", "´")
         If drCl("Observacion").ToString.Trim.Length > AnchoObservacion Then
            If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Digitos del Observacion es Mayor a " & AnchoObservacion.ToString()
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("Observacion") = dr(ColumnaObservacion).ToString.Trim.Replace("'", "´").Remove(AnchoObservacion)
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Nombre de Observacion es Mayor a " & AnchoObservacion.ToString()
               End If
               If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                  drCl("Observacion") = dr(ColumnaObservacion).ToString.Trim.Replace("'", "´").Remove(AnchoObservacion)
               End If
            End If

         End If
      End If


      If ColumnaNombreMarca <> 99 Then

         drCl("NombreMarca") = dr(ColumnaNombreMarca).ToString.Trim.Replace("'", "´")
         If drCl("NombreMarca").ToString.Trim.Length > AnchoNombreMarca Then
            If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Digitos del Nombre de Marca es Mayor a " & AnchoNombreMarca.ToString()
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("NombreMarca") = dr(ColumnaNombreMarca).ToString.Trim.Replace("'", "´").Remove(AnchoNombreMarca)
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Nombre de Marca es Mayor a " & AnchoNombreMarca.ToString()
               End If
               If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                  drCl("NombreMarca") = dr(ColumnaNombreMarca).ToString.Trim.Replace("'", "´").Remove(AnchoNombreMarca)
               End If
            End If

         End If
         If Me.chbAltaProductos.Checked And Accion = "Alta" Then
            If Me.chbMarca.Checked And (bscMarca.Selecciono Or bscCodigoMarca.Selecciono) Then
               drCl("NombreMarca") = Me.bscMarca.Text
            End If
         End If
      Else
         If Me.chbAltaProductos.Checked And Accion = "Alta" Then
            If Me.chbMarca.Checked And (bscMarca.Selecciono Or bscCodigoMarca.Selecciono) Then
               drCl("NombreMarca") = Me.bscMarca.Text
            Else
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Seleccionar el Nombre de Marca "
            End If
         Else
            If Accion = "Modifica" Then
               drCl("NombreMarca") = cache.BuscaMarca(ProductoM.IdMarca).NombreMarca
            End If
         End If
      End If


      If ColumnaNombreRubro <> 99 Then
         drCl("NombreRubro") = dr(ColumnaNombreRubro).ToString.Trim.Replace("'", "´")
         If dr(ColumnaNombreRubro).ToString.Trim.Length > AnchoNombreRubro Then
            If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Digitos del Nombre de Rubro es Mayor a " & AnchoNombreRubro.ToString()
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("NombreRubro") = dr(ColumnaNombreRubro).ToString.Trim.Replace("'", "´").Remove(AnchoNombreRubro)
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Nombre de Rubro es Mayor a " & AnchoNombreRubro.ToString()
               End If
               If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                  drCl("NombreRubro") = dr(ColumnaNombreRubro).ToString.Trim.Replace("'", "´").Remove(AnchoNombreRubro)
               End If
            End If

         End If
         If Me.chbAltaProductos.Checked And Accion = "Alta" Then
            If Me.chbRubro.Checked And (bscRubro.Selecciono Or bscCodigoRubro.Selecciono) Then
               drCl("NombreRubro") = Me.bscRubro.Text
            End If
         End If

      Else
         If Me.chbAltaProductos.Checked And Accion = "Alta" Then
            If Me.chbRubro.Checked And (bscRubro.Selecciono Or bscCodigoRubro.Selecciono) Then
               drCl("NombreRubro") = Me.bscRubro.Text
            Else
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Seleccionar el Nombre de Rubro "
            End If
         Else
            If Accion = "Modifica" Then
               drCl("NombreRubro") = cache.BuscaRubro(ProductoM.IdRubro).NombreRubro
            End If
         End If
      End If


      If ColumnaIVA <> 99 Then
         If Ayudante.ImportarExcel.IsNumeric(dr, ColumnaIVA) Then 'If IsNumeric(dr(ColumnaIVA).ToString()) Then
            drCl("IVA") = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnaIVA) ''  Decimal.Round(Decimal.Parse(dr(ColumnaIVA).ToString()), 2)
         End If

         If Me.chbAltaProductos.Checked And Accion = "Alta" Then
            If Me.chbAlicuota.Checked Then
               drCl("IVA") = Me.cmbTipoImpuesto.Text
            End If
         End If
      Else
         If Me.chbAltaProductos.Checked And Accion = "Alta" Then
            If Me.chbAlicuota.Checked Then
               drCl("IVA") = Me.cmbTipoImpuesto.Text
            Else
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Seleccionar el IVA "
               Importar = False
            End If
         Else
            If Accion = "Modifica" Then
               drCl("IVA") = ProductoM.Alicuota
            End If
            ' drCl("IVA") = Publicos.ProductoIVA
         End If
      End If



      If ColumnaPrecioCompra <> 99 Then
         If Me.bscCodigoProveedor.Text <> "" Then
            If Ayudante.ImportarExcel.IsNumeric(dr, ColumnaPrecioCompra) Then 'If IsNumeric(dr(ColumnaPrecioCompra).ToString()) Then

               Dim precioCompra As Decimal
               precioCompra = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnaPrecioCompra) '' Decimal.Round(Decimal.Parse(dr(ColumnaPrecioCompra).ToString()), 2)
               precioCompra = AplicaPrecioPorEmbalaje(precioCompra, embalajeProducto, precioPorEmbalajeProducto)

               drCl("PrecioCompra") = precioCompra

               If Accion = "Modifica" Then

                  'Dim PrecioCostoAnt As DataTable = New Reglas.Productos().GetPorCodigo(ProductoM.IdProducto, actual.Sucursal.IdSucursal,
                  '                                                                                        Integer.Parse(cmbListaPrecios.SelectedValue.ToString()),
                  '                                                                                         "COMPRAS")

                  'drCl("PrecioCostoAnterior") = Math.Round(CDec(PrecioCostoAnt.Rows(0)("PrecioCosto").ToString()), 2).ToString("N2")
                  'drCl("PrecioCostoAnterior") = Math.Round(Decimal.Parse(dtProductosCant.Select(String.Format("IdProducto = '{0}'", ProductoM.IdProducto))(0)("PrecioCosto").ToString()), 2).ToString("N2")
                  drCl("PrecioCostoAnterior") = Math.Round(dicProductosCant(ProductoM.IdProducto).Field(Of Decimal)("PrecioCosto"), _decimalesEnPrecio)

                  If Reglas.Publicos.UtilizaPrecioDeCompra Then


                     'Dim PF As Decimal = New Reglas.ProductosSucursales().GetUno(actual.Sucursal.IdSucursal, ProductoM.IdProducto).PrecioFabrica
                     'Dim PF As Decimal = Decimal.Parse(dtProductosCant.Select(String.Format("IdProducto = '{0}'", ProductoM.IdProducto, Me.bscCodigoProveedor.Tag))(0)("PrecioFabrica").ToString())
                     Dim PF As Decimal = dicProductosCant(ProductoM.IdProducto).Field(Of Decimal)("PrecioFabrica")
                     drCl("PrecioCompraAnterior") = Decimal.Round(PF, _decimalesEnPrecio)

                     drCl("PrecioCosto") = drCl("PrecioCompra")
                     'If ProductoM.ProductoProveedorHabitual IsNot Nothing Then
                     If ProductoM.IdProveedorHabitual.HasValue Then

                        If Me.chbDR1.Checked Then
                           drCl("DescuentoRecargoPorc1") = Decimal.Parse(Me.txtDescuento1.Text.ToString())
                        ElseIf ColumnaDR1 <> 99 Then
                           If Ayudante.ImportarExcel.IsNumeric(dr, ColumnaDR1) Then
                              drCl("DescuentoRecargoPorc1") = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnaDR1)
                           Else
                              drCl("DescuentoRecargoPorc1") = 0
                           End If
                        Else
                           drCl("DescuentoRecargoPorc1") = If(ProductoM.DescuentoRecargoPorc1.HasValue, ProductoM.DescuentoRecargoPorc1, 0)
                        End If

                        If Me.chbDR2.Checked Then
                           drCl("DescuentoRecargoPorc2") = Decimal.Parse(Me.txtDescuento2.Text.ToString())
                        ElseIf ColumnaDR2 <> 99 Then
                           If Ayudante.ImportarExcel.IsNumeric(dr, ColumnaDR2) Then
                              drCl("DescuentoRecargoPorc2") = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnaDR2)
                           Else
                              drCl("DescuentoRecargoPorc2") = 0
                           End If
                        Else
                           drCl("DescuentoRecargoPorc2") = If(ProductoM.DescuentoRecargoPorc2.HasValue, ProductoM.DescuentoRecargoPorc2, 0)
                        End If

                        If Me.chbDR3.Checked Then
                           drCl("DescuentoRecargoPorc3") = Decimal.Parse(Me.txtDescuento3.Text.ToString())
                        ElseIf ColumnaDR3 <> 99 Then
                           If Ayudante.ImportarExcel.IsNumeric(dr, ColumnaDR3) Then
                              drCl("DescuentoRecargoPorc3") = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnaDR3)
                           Else
                              drCl("DescuentoRecargoPorc3") = 0
                           End If
                        Else
                           drCl("DescuentoRecargoPorc3") = If(ProductoM.DescuentoRecargoPorc3.HasValue, ProductoM.DescuentoRecargoPorc3, 0)
                        End If

                        If Me.chbDR4.Checked Then
                           drCl("DescuentoRecargoPorc4") = Decimal.Parse(Me.txtDescuento4.Text.ToString())
                        ElseIf ColumnaDR4 <> 99 Then
                           If Ayudante.ImportarExcel.IsNumeric(dr, ColumnaDR4) Then
                              drCl("DescuentoRecargoPorc4") = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnaDR4)
                           Else
                              drCl("DescuentoRecargoPorc4") = 0
                           End If
                        Else
                           drCl("DescuentoRecargoPorc4") = If(ProductoM.DescuentoRecargoPorc4.HasValue, ProductoM.DescuentoRecargoPorc4, 0)
                        End If

                        Dim formato As String = _formatoEnPrecio
                        If Decimal.Parse(drCl("PrecioCosto").ToString()) <> 0 Then
                           drCl("PrecioCosto") = (CDec(drCl("PrecioCosto")) + (CDec(drCl("PrecioCosto")) * CDec(drCl("DescuentoRecargoPorc1")) / 100)).ToString()
                           drCl("PrecioCosto") = (CDec(drCl("PrecioCosto")) + (CDec(drCl("PrecioCosto")) * CDec(drCl("DescuentoRecargoPorc2")) / 100)).ToString()
                           drCl("PrecioCosto") = (CDec(drCl("PrecioCosto")) + (CDec(drCl("PrecioCosto")) * CDec(drCl("DescuentoRecargoPorc3")) / 100)).ToString()
                           drCl("PrecioCosto") = (CDec(drCl("PrecioCosto")) + (CDec(drCl("PrecioCosto")) * CDec(drCl("DescuentoRecargoPorc4")) / 100)).ToString()
                           drCl("PrecioCosto") = Math.Round(CDec(drCl("PrecioCosto")), _decimalesEnPrecio).ToString(formato)
                        End If

                     End If
                  End If

                  Dim PC As Decimal = Decimal.Parse(drCl("PrecioCosto").ToString())
                  Dim PCA As Decimal = Decimal.Parse(drCl("PrecioCostoAnterior").ToString())

                  If PC = PCA Then
                     If Me.chbActualizaProductosSinCambios.Checked Then
                        Accion = "Modifica"
                     Else
                        Importar = False
                        Accion = "Sin Cambios"
                     End If
                  Else
                     Dim var As Decimal = 0
                     var = Decimal.Parse(drCl("PrecioCostoAnterior").ToString()) - Decimal.Parse(drCl("PrecioCosto").ToString())
                     If Decimal.Parse(drCl("PrecioCosto").ToString()) <> 0 Then
                        drCl("PorcVarCosto") = (var / Decimal.Parse(drCl("PrecioCosto").ToString()) * 100) * -1
                     Else
                        drCl("PorcVarCosto") = 0
                     End If

                  End If

                  Dim varCompra As Decimal = 0
                  varCompra = Decimal.Parse(drCl("PrecioCompraAnterior").ToString()) - Decimal.Parse(drCl("PrecioCompra").ToString())
                  If Decimal.Parse(drCl("PrecioCompra").ToString()) = 0 Then
                     drCl("PorcVarCompra") = 0
                  Else
                     drCl("PorcVarCompra") = (varCompra / Decimal.Parse(drCl("PrecioCompra").ToString()) * 100) * -1
                  End If

               Else
                  drCl("PrecioCosto") = drCl("PrecioCompra")
                  drCl("PrecioCostoAnterior") = 0
                  drCl("PorcVarCosto") = 0
                  drCl("PrecioCompraAnterior") = 0
                  drCl("DescuentoRecargoPorc1") = 0
                  drCl("DescuentoRecargoPorc2") = 0
                  drCl("DescuentoRecargoPorc3") = 0
                  drCl("DescuentoRecargoPorc4") = 0
               End If
            End If
         Else
            drCl("PrecioCompra") = 0
            If Me._plantilla.Sistema = True Then
               drCl("PrecioCosto") = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnaPrecioCosto) '' Decimal.Round(Decimal.Parse(dr(ColumnaPrecioCosto).ToString()), 2)
            Else
               drCl("PrecioCosto") = 0
            End If

            drCl("PrecioCostoAnterior") = 0
            drCl("PorcVarCosto") = 0
         End If

      Else
         If ColumnaPrecioCosto <> 99 Then

            Dim precioCosto As Decimal
            precioCosto = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnaPrecioCosto) '' Decimal.Round(Decimal.Parse(dr(ColumnaPrecioCosto).ToString()), 2)
            precioCosto = AplicaPrecioPorEmbalaje(precioCosto, embalajeProducto, precioPorEmbalajeProducto)

            drCl("PrecioCosto") = precioCosto

            If Accion = "Modifica" Then
               'Dim PrecioCostoAnt As DataTable = New Reglas.Productos().GetPorCodigo(ProductoM.IdProducto, actual.Sucursal.IdSucursal,
               '                                                                                                           Integer.Parse(cmbListaPrecios.SelectedValue.ToString()),
               '                                                                                                            "COMPRAS")

               'drCl("PrecioCostoAnterior") = Math.Round(CDec(PrecioCostoAnt.Rows(0)("PrecioCosto").ToString()), 2).ToString("N2")
               'drCl("PrecioCostoAnterior") = Math.Round(Decimal.Parse(dtProductosCant.Select(String.Format("IdProducto = '{0}'", ProductoM.IdProducto))(0)("PrecioCosto").ToString()), 2).ToString("N2")
               drCl("PrecioCostoAnterior") = Math.Round(dicProductosCant(ProductoM.IdProducto).Field(Of Decimal)("PrecioCosto"), _decimalesEnPrecio)

               If Decimal.Parse(drCl("PrecioCosto").ToString()) = Decimal.Parse(drCl("PrecioCostoAnterior").ToString()) Then
                  If Me.chbActualizaProductosSinCambios.Checked Then
                     Accion = "Modifica"
                  Else
                     Importar = False
                     Accion = "Sin Cambios"
                  End If
               Else
                  Dim var As Decimal = 0
                  var = Decimal.Parse(drCl("PrecioCostoAnterior").ToString()) - Decimal.Parse(drCl("PrecioCosto").ToString())

                  Dim precioNuevo As Decimal = Decimal.Parse(drCl("PrecioCosto").ToString())

                  If var = 0 And precioNuevo = 0 Then
                     drCl("PorcVarCosto") = 0
                  ElseIf var <> 0 And precioNuevo = 0 Then
                     drCl("PorcVarCosto") = -100
                  ElseIf var = 0 And precioNuevo <> 0 Then
                     drCl("PorcVarCosto") = 100
                  Else
                     Try
                        drCl("PorcVarCosto") = (var / Decimal.Parse(drCl("PrecioCosto").ToString()) * 100) * -1
                     Catch ex As Exception
                        Throw ex
                     End Try
                  End If
               End If
            End If

         Else
            drCl("PrecioCompra") = 0
            drCl("PrecioCosto") = 0
            drCl("PrecioCostoAnterior") = 0
            drCl("PorcVarCosto") = 0
         End If
      End If



      If ColumnaPrecioVenta <> 99 Then
         ' If IsNumeric(dr(ColumnaPrecioVenta).ToString()) Then
         If Ayudante.ImportarExcel.IsNumeric(dr, ColumnaPrecioVenta) Then
            Dim precioVenta As Decimal
            precioVenta = Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnaPrecioVenta) '' Decimal.Round(Decimal.Parse(dr(ColumnaPrecioVenta).ToString()), 2)
            precioVenta = AplicaPrecioPorEmbalaje(precioVenta, embalajeProducto, precioPorEmbalajeProducto)

            drCl("PrecioVenta") = precioVenta
            'Else
            '   drCl("PrecioVenta") = 0
            ' End If
         Else
            Importar = False
         End If
      Else
         '  Me.cmbListaPrecios.Enabled = False
         If Accion = "Modifica" Or Accion = "Sin Cambios" Then

            'Dim PrecioVenta As DataTable = New Reglas.Productos().GetPorCodigo(ProductoM.IdProducto, actual.Sucursal.IdSucursal,
            '                                                 Integer.Parse(cmbListaPrecios.SelectedValue.ToString()), "VENTAS")

            'drCl("PrecioVenta") = PrecioVenta.Rows(0)("PrecioVenta").ToString()
            'drCl("PrecioVenta") = dtProductosCant.Select(String.Format("IdProducto = '{0}'", ProductoM.IdProducto))(0)("PrecioVenta").ToString()
            drCl("PrecioVenta") = dicProductosCant(ProductoM.IdProducto).Field(Of Decimal)("PrecioVenta")
         End If
      End If


      If ColumnaMoneda <> 99 Then

         drCl("Moneda") = IIf(dr(ColumnaMoneda).ToString.Trim() = "D", "Dolar", "Pesos").ToString()

      Else
         If Me.chbAltaProductos.Checked And Accion = "Alta" Then
            If Me.chbMoneda.Checked Then
               drCl("Moneda") = Me.cmbMoneda.Text
            Else
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Seleccionar la Moneda "
            End If
         Else
            If Accion = "Modifica" Or Accion = "Sin Cambios" Then
               drCl("Moneda") = ProductoM.NombreMoneda
            End If
         End If
      End If

      If ColumnaCodigoDeBarras <> 99 Then
         drCl("CodigoDeBarras") = dr(ColumnaCodigoDeBarras).ToString.Trim.Replace("'", "´")
         If dr(ColumnaCodigoDeBarras).ToString.Trim.Length > AnchoCodigoDeBarras Then
            Importar = False
            If Mensaje.Length > 0 Then Mensaje += " - "
            Mensaje += "Digitos del Codigo de Barras es Mayor a " & AnchoCodigoDeBarras.ToString()
         End If
         If dr(ColumnaCodigoDeBarras).ToString.Trim.Length > AnchoCodigoDeBarras Then
            If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Digitos del Codigo de Barras es Mayor a " & AnchoCodigoDeBarras.ToString()
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("CodigoDeBarras") = dr(ColumnaCodigoDeBarras).ToString.Trim.Replace("'", "´").Remove(AnchoCodigoDeBarras)
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Codigo de Barras es Mayor a " & AnchoCodigoDeBarras.ToString()
               End If
               If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                  drCl("CodigoDeBarras") = dr(ColumnaCodigoDeBarras).ToString.Trim.Replace("'", "´").Remove(AnchoCodigoDeBarras)
               End If
            End If
         End If
      End If

      '# Si la pantalla es de comparación, SIEMPRE va tildado
      If _funcion = nombreFuncionComparar Then
         drCl("Importa") = True
      Else
         drCl("Importa") = Importar
      End If

      If Not Importar Then
         'ProductosConError += 1
         drCl("Mensaje") = Mensaje
         If Not drCl("Mensaje").ToString() = "" Then
            'Accion = "Error"
            ' Accion = "Alta"
         End If
      Else
         If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
            drCl("Mensaje") = Mensaje
         Else
            drCl("Mensaje") = ""
         End If

      End If

      drCl("Accion") = Accion

      If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Accion = "Alta")) And
         (Me.cboAccion.Text = "Todas" Or
          (Me.cboAccion.Text = "Altas" And Accion = "Alta") Or
          (Me.cboAccion.Text = "Existentes" And (Accion = "Modifica" Or Accion = "Sin Cambios")) Or
          (Me.cboAccion.Text = "Sin Cambios" And (Accion = "Sin Cambios")) Or
          (Me.cboAccion.Text = "Modificar" And Accion = "Modifica")) And
         (drCl("CodigoProveedor").ToString() <> "" Or drCl("NombreProducto").ToString() <> "") Then
         If Not Importar Then
            If Accion <> "Sin Cambios" Then
               drCl("Accion") = "Error"
            End If
         End If
         dt.Rows.Add(drCl)
         If Not Importar Then
            ProductosConError += 1
         End If
      End If

      If activos <> Entidades.Publicos.SiNoTodos.TODOS Then
         If ProductoM IsNot Nothing Then
            If activos = Entidades.Publicos.SiNoTodos.SI AndAlso Not ProductoM.Activo Or
               activos = Entidades.Publicos.SiNoTodos.NO AndAlso ProductoM.Activo Then
               drCl("Accion") = If(ProductoM.Activo, "Activo", "Inacivo")
               drCl("Importa") = False
               drCl("Mensaje") = String.Format("El producto está {0} y filtro solo los {1}",
                                               If(ProductoM.Activo, "Activo", "Inactivo"),
                                               If(activos = Entidades.Publicos.SiNoTodos.SI, "Activos", "Inactivos"))
            End If
         End If
      End If

   End Sub

   Private Sub FormatearGrilla()

      If ColumnaPrecioVenta = 99 Then
         dgvDetalle.Columns("PrecioVenta").Visible = False
      Else
         dgvDetalle.Columns("PrecioVenta").Visible = True
      End If
      If ColumnaPrecioCompra = 99 Then
         dgvDetalle.Columns("PrecioCompra").Visible = False
         dgvDetalle.Columns("PorcVarCompra").Visible = False
         dgvDetalle.Columns("PrecioCompraAnterior").Visible = False
         dgvDetalle.Columns("DescuentoRecargoPorc1").Visible = False
         dgvDetalle.Columns("DescuentoRecargoPorc2").Visible = False
         dgvDetalle.Columns("DescuentoRecargoPorc3").Visible = False
         dgvDetalle.Columns("DescuentoRecargoPorc4").Visible = False
      Else
         dgvDetalle.Columns("PrecioCompra").Visible = True
         dgvDetalle.Columns("PorcVarCompra").Visible = True
         dgvDetalle.Columns("PrecioCompraAnterior").Visible = True
         dgvDetalle.Columns("DescuentoRecargoPorc1").Visible = True
         dgvDetalle.Columns("DescuentoRecargoPorc2").Visible = True
         dgvDetalle.Columns("DescuentoRecargoPorc3").Visible = True
         dgvDetalle.Columns("DescuentoRecargoPorc4").Visible = True
      End If
      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

         If dr.Cells("EsOferta").Value.ToString() = Boolean.TrueString Then
            dr.DefaultCellStyle.BackColor = Color.Yellow
         End If

         If dr.Cells("Accion").Value.ToString() = "Modifica" Then
            dr.Cells("Importa").Style.BackColor = Color.LimeGreen
            If IsNumeric(dr.Cells("PorcVarCosto").Value) AndAlso Decimal.Parse(dr.Cells("PorcVarCosto").Value.ToString()) < 0 Then
               dr.Cells("PorcVarCosto").Style.BackColor = Color.Coral
            Else
               dr.Cells("PorcVarCosto").Style.BackColor = Color.LightSkyBlue
            End If

            If IsNumeric(dr.Cells("PorcVarCompra").Value) AndAlso Decimal.Parse(dr.Cells("PorcVarCompra").Value.ToString()) < 0 Then
               dr.Cells("PorcVarCompra").Style.BackColor = Color.Coral
            Else
               dr.Cells("PorcVarCompra").Style.BackColor = Color.LightSkyBlue
            End If

         ElseIf dr.Cells("Accion").Value.ToString() = "Sin Cambios" Then
            dr.Cells("Importa").Style.BackColor = Color.LightCoral
         ElseIf dr.Cells("Accion").Value.ToString() = "Alta" And Boolean.Parse(dr.Cells("Importa").Value.ToString()) = True Then
            dr.Cells("Importa").Style.BackColor = Color.LimeGreen
         End If

         If dr.Cells("Accion").Value.ToString() = "Error" Then
            dr.Cells("Importa").ReadOnly = True
            dr.Cells("Importa").Style.BackColor = Color.Gray
         End If

      Next
   End Sub

   Private Sub ImportarDatosParaComparar()
      If dgvDetalle.RowCount = 0 Then Exit Sub

      Dim rProveedoresComparar As Reglas.ProveedoresComparar = New Reglas.ProveedoresComparar
      Dim eProveedorComparar As Entidades.ProveedorComparar = rProveedoresComparar.GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))
      Me.dgvDetalle.Update()
      Me.dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit)
      Dim dt As DataTable = DirectCast(Me.dgvDetalle.DataSource, DataTable)

      '# En caso de que el proveedor ya tenga una plantilla cargada para comparar, doy el mensaje al cliente
      Dim mensaje As StringBuilder = New StringBuilder
      If eProveedorComparar IsNot Nothing Then
         With mensaje
            .AppendFormat("El Proveedor {0} {1} ya tiene una Plantilla para Comparar cargada el día {2}. ¿Desea sobreescribirla?",
                          eProveedorComparar.IdProveedor.ToString(),
                          eProveedorComparar.NombreProveedor,
                          eProveedorComparar.FechaActualizacion.ToString())
         End With
      End If
      Dim importar As Boolean = True
      If Not String.IsNullOrEmpty(mensaje.ToString()) AndAlso Not MessageBox.Show(mensaje.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
         importar = False
      End If

      If importar Then
         eProveedorComparar = New Entidades.ProveedorComparar
         eProveedorComparar.IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         eProveedorComparar.IdPlantilla = Integer.Parse(Me.bscCodigoPlantilla.Text)
         eProveedorComparar.FechaActualizacion = Date.Now

         rProveedoresComparar.ImportarParaComparar(eProveedorComparar, dt)

         ShowMessage("Se importaron los Productos para Comparar correctamente!!!")

         Me.tsbImportarParaComparar.Enabled = False
      End If

   End Sub

   Private Sub ImportarDatos()

      Dim dtDatos As DataTable

      dtDatos = DirectCast(Me.dgvDetalle.DataSource, DataTable)

      Dim reg As Eniac.Reglas.Productos = New Eniac.Reglas.Productos()

      Dim idProveedor As Long = 0

      Long.TryParse(Me.bscCodigoProveedor.Tag.ToString(), idProveedor)

      If idProveedor = 0 Then
         idProveedor = Me._plantilla.Proveedor.IdProveedor
      End If

      If ColumnaPrecioVenta <> 99 Then
         reg.ImportarProductosPlantillas(actual.Sucursal.Id, dtDatos, actual.Nombre, cmbListaPrecios.ValorSeleccionado(Of Integer), prbImportando, idProveedor, IdFuncion,
                                         chbActualizaProductosSinCambios.Checked)
      Else
         If ColumnaPrecioCompra <> 99 Then
            reg.ImportarProductos(actual.Sucursal.Id, dtDatos, actual.Nombre, dtListaPrecios,
                                  txtRedondeoPrecioVenta.ValorNumericoPorDefecto(0I), chbAjusteA.Checked, txtAjusteA.ValorNumericoPorDefecto(0I), prbImportando, tslTiempoActual, tslRegistroActual, idProveedor, IdFuncion,
                                  chbActualizaProductosSinCambios.Checked)

         Else
            reg.ImportarProductos(actual.Sucursal.Id, dtDatos, actual.Nombre, dtListaPrecios,
                                  txtRedondeoPrecioVenta.ValorNumericoPorDefecto(0I), chbAjusteA.Checked, txtAjusteA.ValorNumericoPorDefecto(0I), prbImportando, tslTiempoActual, tslRegistroActual, idProveedor, IdFuncion,
                                  chbActualizaProductosSinCambios.Checked)

         End If

      End If

   End Sub

   Private Sub CargarDatosPlantilla(dr As DataGridViewRow)
      If dr Is Nothing Then Exit Sub
      Me.bscPlantilla.Text = dr.Cells("NombrePlantilla").Value.ToString()
      Me.bscCodigoPlantilla.Text = dr.Cells("IdPlantilla").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()

      If Not String.IsNullOrEmpty(dr.Cells("CodigoProveedor").Value.ToString()) Then
         Me.bscCodigoProveedor.PresionarBoton()
      End If

      Me._plantilla = New Reglas.Plantillas().GetUno(Integer.Parse(dr.Cells("IdPlantilla").Value.ToString()))

      Dim columnaFinal As Integer = 0
      Dim ColumnaFinalLetra As String = ""
      For Each dr1 As DataRow In Me._plantilla.Campos.Rows
         If Not String.IsNullOrEmpty(dr1("OrdenColumna").ToString()) Then
            If Integer.Parse(dr1("OrdenColumna").ToString()) > columnaFinal Then
               columnaFinal = Integer.Parse(dr1("OrdenColumna").ToString())
            End If

            Select Case Integer.Parse(dr1("Orden").ToString())
               Case 1
                  ColumnaIdProducto = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 2
                  ColumnaNombreProducto = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 3
                  ColumnaNombreProducto2 = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 4
                  ColumnaNombreMarca = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 5
                  ColumnaNombreRubro = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 6
                  ColumnaIVA = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 7
                  ColumnaPrecioCompra = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 8
                  ColumnaPrecioCosto = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 9
                  ColumnaPrecioVenta = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 10
                  ColumnaMoneda = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 11
                  ColumnaCodigoDeBarras = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 12
                  ColumnaCodigoLargoProducto = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 13
                  ColumnaObservacion = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 14
                  ColumnaDR1 = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 15
                  ColumnaDR2 = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 16
                  ColumnaDR3 = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 17
                  ColumnaDR4 = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case 18
                  ColumnaIdProductoNumerico = Integer.Parse(dr1("OrdenColumna").ToString()) - 1
               Case Else
            End Select

         End If
      Next
      Dim codig As Integer = columnaFinal + 64
      ColumnaFinalLetra = Chr(codig)
      Me.txtRangoCeldas1.Text = "A" + dr.Cells("FilaInicial").Value.ToString()
      Me.txtRangoCeldas11.Text = ":" + ColumnaFinalLetra.ToString()

      If ColumnaNombreProducto2 <> 99 Then
         Me.cboDescripcion.SelectedIndex = 1
      End If

   End Sub

   Private Sub CargarMarca(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoMarca.Text = dr.Cells("IdMarca").Value.ToString()
         bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()
         bscCodigoRubro.Focus()
      End If
   End Sub

   Private Sub CargarRubro(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
         bscRubro.Text = dr.Cells("NombreRubro").Value.ToString()
      End If
   End Sub

   Private Sub CreaDTPrecios()
      dtListaPrecios = New DataTable()

      dtListaPrecios.Columns.Add(ListaPreciosColumns.IdListaPrecios.ToString(), GetType(Integer))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.NombreListaPrecios.ToString(), GetType(String))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PrecioVenta.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PrecioVentaBase.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcentajeBase.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PrecioCosto.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcentajeCosto.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcentajeCalculado.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcActual.ToString(), GetType(Boolean))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.SobreVenta.ToString(), GetType(Boolean))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.SobreCosto.ToString(), GetType(Boolean))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.DesdeFormula.ToString(), GetType(Boolean))
   End Sub

   Private Sub CargaDTPrecios()

      For Each drPrecios As DataRow In New Reglas.ListasDePrecios().GetAll().Rows
         If dtListaPrecios.Select(String.Format("{0} = {1}", ListaPreciosColumns.IdListaPrecios.ToString(), drPrecios("IdListaPrecios"))).Length = 0 Then
            Dim dr As DataRow
            dr = dtListaPrecios.NewRow()
            dr(ListaPreciosColumns.IdListaPrecios.ToString()) = drPrecios("IdListaPrecios")
            dr(ListaPreciosColumns.NombreListaPrecios.ToString()) = drPrecios("NombreListaPrecios")
            'dr(ListaPreciosColumns.PrecioVenta.ToString()) = 0
            'dr(ListaPreciosColumns.PrecioVentaBase.ToString()) = 0
            'dr(ListaPreciosColumns.PorcentajeBase.ToString()) = 0
            'dr(ListaPreciosColumns.PrecioCosto.ToString()) = 0
            'dr(ListaPreciosColumns.PorcentajeCosto.ToString()) = 0
            dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = 0
            dr(ListaPreciosColumns.PorcActual.ToString()) = True
            dr(ListaPreciosColumns.SobreVenta.ToString()) = False
            dr(ListaPreciosColumns.SobreCosto.ToString()) = False
            dr(ListaPreciosColumns.DesdeFormula.ToString()) = False
            dtListaPrecios.Rows.Add(dr)
         End If
      Next

   End Sub

   Private Enum ListaPreciosColumns
      IdListaPrecios
      NombreListaPrecios
      PrecioVenta
      PrecioVentaBase
      PorcentajeBase
      PrecioCosto
      PorcentajeCosto
      PorcActual
      SobreVenta
      SobreCosto
      DesdeFormula
      PorcentajeCalculado
   End Enum

   Private Sub FormateaGrillaPrecios()
      With dgvListasPrecios.DisplayLayout.Bands(0)
         .Override.WrapHeaderText = DefaultableBoolean.True
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         .Columns(ListaPreciosColumns.NombreListaPrecios.ToString()).Header.Caption = "Nombre"
         .Columns(ListaPreciosColumns.NombreListaPrecios.ToString()).Width = 170
         .Columns(ListaPreciosColumns.NombreListaPrecios.ToString()).Hidden = False

         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Header.Caption = "%"
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Width = 50
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Format = "N2"
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).MaskInput = "{double:-4.2}"
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Hidden = False
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(ListaPreciosColumns.PorcActual.ToString()).Header.Caption = "Porc. Actual"
         .Columns(ListaPreciosColumns.PorcActual.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.PorcActual.ToString()).Width = 50
         .Columns(ListaPreciosColumns.PorcActual.ToString()).Hidden = False

         .Columns(ListaPreciosColumns.SobreVenta.ToString()).Header.Caption = "Sobre Venta"
         .Columns(ListaPreciosColumns.SobreVenta.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.SobreVenta.ToString()).Width = 50
         .Columns(ListaPreciosColumns.SobreVenta.ToString()).Hidden = False

         .Columns(ListaPreciosColumns.SobreCosto.ToString()).Header.Caption = "Sobre Costo"
         .Columns(ListaPreciosColumns.SobreCosto.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.SobreCosto.ToString()).Width = 50
         .Columns(ListaPreciosColumns.SobreCosto.ToString()).Hidden = False

         If Reglas.Publicos.TieneModuloProduccion Then
            .Columns(ListaPreciosColumns.DesdeFormula.ToString()).Header.Caption = "Desde Formula"
            .Columns(ListaPreciosColumns.DesdeFormula.ToString()).CellActivation = Activation.AllowEdit
            .Columns(ListaPreciosColumns.DesdeFormula.ToString()).Width = 50
            .Columns(ListaPreciosColumns.DesdeFormula.ToString()).Hidden = False
         End If

         dgvListasPrecios.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
         dgvListasPrecios.DisplayLayout.GroupByBox.Hidden = True
         dgvListasPrecios.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

         Me.SetearCheckEnGrillaPrecios()
         Me.tbcDatos.SelectedTab = Me.tbpPrecios
         Me.tbcDatos.SelectedTab = Me.TabPage1

         Me.dgvListasPrecios.UpdateData()
         Me.dgvListasPrecios.Focus()
      End With
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

         If Me.bscCodigoPlantilla.Text = "" Then
            Dim Plantilla As DataTable = New Reglas.Plantillas().GetFiltradoPorProveedor(Long.Parse(dr.Cells("IdProveedor").Value.ToString()))

            If Plantilla.Rows.Count <> 0 Then
               Me.bscCodigoPlantilla.Text = Plantilla.Rows(0).Item("IdPlantilla").ToString()
               Me.bscCodigoPlantilla.PresionarBoton()
            Else
               MessageBox.Show("No hay plantillas para este Proveedor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


         End If
      End If

   End Sub

   Private Function AplicaPrecioPorEmbalaje(precio As Decimal, embalajeProducto As Integer, precioPorEmbalajeProducto As Boolean) As Decimal
      Select Case GetPrecioPorEmbalajeSeleccionado()
         Case PrecioPorEmbalaje.No
            Return precio
         Case PrecioPorEmbalaje.Si
            Return precio / embalajeProducto
         Case PrecioPorEmbalaje.SegunProducto
            If precioPorEmbalajeProducto Then
               Return precio
            Else
               Return precio / embalajeProducto
            End If
         Case Else
            Throw New Exception(String.Format("Precios por embalaje '{0}' no implementado", GetPrecioPorEmbalajeSeleccionado().ToString()))
      End Select

   End Function

   Private Function GetPrecioPorEmbalajeSeleccionado() As PrecioPorEmbalaje
      If cmbPrecioPorEmbalaje.SelectedIndex = -1 Then
         cmbPrecioPorEmbalaje.SelectedValue = PrecioPorEmbalaje.No
      End If
      Return DirectCast(cmbPrecioPorEmbalaje.SelectedValue, PrecioPorEmbalaje)
   End Function

   Private Sub SetearCheckEnGrillaPrecios()
      Dim col = ListaPreciosColumns.PorcActual.ToString()
      Select Case _actualizarprecioExcel
         Case "ACTUAL"
            col = ListaPreciosColumns.PorcActual.ToString()
         Case "VENTA"
            col = ListaPreciosColumns.SobreVenta.ToString()
         Case Else
            col = ListaPreciosColumns.SobreCosto.ToString()
      End Select
      For Each r As UltraGridRow In Me.dgvListasPrecios.Rows
         r.Cells(ListaPreciosColumns.PorcActual.ToString()).Value = False
         r.Cells(ListaPreciosColumns.SobreVenta.ToString()).Value = False
         r.Cells(ListaPreciosColumns.SobreCosto.ToString()).Value = False
         r.Cells(col).Value = True
      Next
   End Sub

#End Region

#Region "Metodos IConParametros"

   '# Implemento la I para setear el tipo de función a ejecutar en la pantalla
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _funcion = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Modalidad de la pantalla.")
      stb.AppendFormatLine("Valores posibles: IMPORTARPROD o COMPARARPROD")
      stb.AppendFormatLine("Por defecto: IMPORTARPROD")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

#End Region

   Private Enum PrecioPorEmbalaje
      <Description("No Contemplar")> No
      <Description("Contemplar")> Si
      <Description("Segun Producto")> SegunProducto
   End Enum

End Class