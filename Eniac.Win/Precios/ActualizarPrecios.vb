Option Strict On
Option Explicit On

Imports actual = Eniac.Entidades.Usuario.Actual
<Obsolete("No se utiliza más. Se utiliza ActualizarPreciosV2", True)>
Public Class ActualizarPrecios

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(compuesto As Compuesto, buscaYCalculaAutomaticamente As Boolean)
      Me.New()
      Me._compuesto = compuesto
      Me.rdbCostoDesdeFormula.Checked = True
      Me._buscaYCalcula = buscaYCalculaAutomaticamente
   End Sub

#End Region

   Public Enum Compuesto
      TODOS
      SI
      NO
   End Enum


#Region "Campos"

   Private _publicos As Publicos
   Private _precios As List(Of Entidades.ProductoSucursal)
   Private _listas As List(Of Entidades.ListaDePrecios)
   Private _listasSelec As List(Of Entidades.ListaDePrecios)
   Private _filtroMultiplesMarcas As MFMarcas
   Private _filtroMultiplesRubros As MFRubros
   Private _DecimalesEnPrecio As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio
   Private _estacargando As Boolean = False
   Private _calcular As Boolean = False
   Private _compuesto As Compuesto = Compuesto.TODOS
   Private _buscaYCalcula As Boolean = False
   Private _actualizarPreciosMostrarCodigoProductoProveedor As Boolean

   Private _actualizarPreciosCalculo As String
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         _actualizarPreciosCalculo = Publicos.ActualizarPreciosCalculo
         If _comprasProductos IsNot Nothing Then
            _actualizarPreciosCalculo = Reglas.Publicos.ActualizarPreciosCalculoDesdeCompras
         End If

         Me.CargarSucursales()

         Me._filtroMultiplesMarcas = New MFMarcas()
         Me._filtroMultiplesRubros = New MFRubros()

         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)
         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))
         _publicos.CargaComboDesdeEnum(Me.cmbTodosListas, GetType(Reglas.Publicos.TodosEnumSI))

         _actualizarPreciosMostrarCodigoProductoProveedor = Reglas.Publicos.ActualizarPreciosMostrarCodigoProductoProveedor

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If


         Me.CargaSeleccionListasDePrecios()

         '   Me.CargaListasDePrecios()

         Me.cboCompuestos.Items.Insert(0, Compuesto.TODOS.ToString())
         Me.cboCompuestos.Items.Insert(1, Compuesto.SI.ToString())
         Me.cboCompuestos.Items.Insert(2, Compuesto.NO.ToString())
         'Me.cboCompuestos.SelectedIndex = 0

         Me.cboCompuestos.Text = Me._compuesto.ToString()

         Me.cmbEsOferta.SelectedIndex = 0

         If Not Publicos.TieneModuloProduccion Then
            Me.lblCompuestos.Visible = False
            Me.cboCompuestos.Visible = False
            Me.rdbCostoSiMismo.Visible = False
            Me.rdbCostoDesdeFormula.Visible = False
         End If

         tbcDetalle.SelectedTab = TbpCalcular
         tbcDetalle.SelectedTab = TbpFiltros

         Me.tsbGrabar.Enabled = False
         Me.tsbImportarExcel.Enabled = False

         If Publicos.UtilizaPrecioDeCompra Then
            Me.grbPrecioCompra.Show()
         Else
            Me.grbPrecioCompra.Hide()
            Me.rdbCostoFabrica.Visible = False
         End If

         If rdbCostoFabrica.Visible = False And rdbCostoDesdeFormula.Visible = False Then
            Me.rdbCostoSiMismo.Visible = True
         End If
         'Me.rdbCostoFabrica.Visible = Publicos.UtilizaPrecioDeCompra 'No queda prolijo el porcentaje de Si Mismo.

         Me.txtRedondeoPrecioVenta.Text = Publicos.PreciosDecimalesEnVenta.ToString()

         txtCodigoProductoProveedor.Visible = _actualizarPreciosMostrarCodigoProductoProveedor
         txtCodigoProductoProveedor.LabelAsoc.Visible = txtCodigoProductoProveedor.Visible

         lblDescuentoRecargoPorc1.Visible = Publicos.UtilizaPrecioDeCompra
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


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

#End Region

#Region "Eventos"

   Private Sub ActualizarPrecios_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      Select Case e.KeyCode
         Case Keys.F4
            If Me.tsbGrabar.Enabled Then
               Me.tsbGrabar.PerformClick()
            End If
         Case Keys.F5
            If Me.tsbRefrescar.Visible Then
               Me.tsbRefrescar.PerformClick()
            End If
         Case Keys.F8
            If Me.btnCalcular.Enabled Then
               Me.tbcDetalle.SelectedTab = Me.TbpCalcular
               Me.btnCalcular.PerformClick()
            End If
         Case Keys.F11
            Me.tbcDetalle.SelectedTab = Me.TbpFiltros
            Me.btnBuscar.Focus()
         Case Keys.F12
            Me.tbcDetalle.SelectedTab = Me.TbpCalcular
            Me.btnCalcular.Focus()
      End Select
   End Sub

   Private Sub ActualizarPrecios_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         If MessageBox.Show("Usted esta por actualizar los precios de los productos. Esta seguro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.BarraInicializa("Preparando grabación de datos...", 0, Me.dgvPrecios.Rows.Count)
            Me.Cursor = Cursors.WaitCursor
            Me.dgvPrecios.Update()
            Me.CargarYGrabarPrecios()
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

   Private Sub tsbImportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportarExcel.Click

      Try

         Dim fPre As New ImportarPreciosExcel
         fPre.ShowDialog()

         If Not fPre.Resultado Then
            Exit Sub
         End If

         Dim CodigoProducto As String
         Dim Contador As Integer
         Dim listaelegida As String

         'If Me.dgvListasPrecios.RowCount = 1 Or fPre.NumeroListaDePrecios = 0 Then
         '   listaelegida = "PrecioVenta1"
         'Else
         listaelegida = fPre.NombreListaDePrecios + "1"
         'End If

         Contador = 0

         Dim precioCosto As Decimal = 0
         Dim precioCostoNuevo As Decimal = 0
         Dim precioVenta As Decimal = 0

         With fPre.lvMapeo

            For Each Linea As ListViewItem In .Items

               CodigoProducto = Linea.Text

               For Each dr As DataGridViewRow In Me.dgvPrecios.Rows

                  If dr.Cells("IdProducto").Value.ToString.Trim() = CodigoProducto Then

                     dr.Cells("IdProducto").Style.BackColor = Color.Cyan
                     dr.Cells("NombreProducto").Style.BackColor = Color.Cyan

                     precioCosto = Decimal.Parse(dr.Cells("PrecioCosto1").Value.ToString())
                     If Linea.SubItems(3).Text <> "--" Then
                        dr.Cells("PrecioCosto1").Value = Decimal.Parse(Linea.SubItems(3).Text)
                        dr.Cells("PrecioCosto1").Style.BackColor = Color.Cyan
                     End If
                     precioCostoNuevo = Decimal.Parse(dr.Cells("PrecioCosto1").Value.ToString())

                     If Linea.SubItems(4).Text <> "--" Then
                        dr.Cells(listaelegida).Value = Decimal.Parse(Linea.SubItems(4).Text)
                        dr.Cells(listaelegida).Style.BackColor = Color.Cyan
                     Else
                        precioVenta = Decimal.Parse(dr.Cells(listaelegida).Value.ToString())
                        dr.Cells(listaelegida).Value = Me.GetPrecioVentaNuevo(CodigoProducto, precioCosto, precioCostoNuevo, precioVenta, 0)
                     End If

                     Contador += 1

                  End If

               Next

            Next

            MessageBox.Show("Proceso Finalizado, Cantidad de Precios Ajustados: " & Contador.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         End With
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub lnkFiltroMultiplesMarcas_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroMultiplesMarcas.LinkClicked
      Try
         Me._filtroMultiplesMarcas.ShowDialog()
         If Me._filtroMultiplesMarcas.Filtros.Count = 0 Then
            Me.lnkFiltroMultiplesMarcas.Text = "Todas las Marcas"
         ElseIf Me._filtroMultiplesMarcas.Filtros.Count = 1 Then
            Me.lnkFiltroMultiplesMarcas.Text = Me._filtroMultiplesMarcas.Filtros(0).NombreMarca
         Else
            Me.lnkFiltroMultiplesMarcas.Text = "Algunas Marcas"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkFiltroMultiplesRubros_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroMultiplesRubros.LinkClicked
      Try
         Me._filtroMultiplesRubros.ShowDialog()
         If Me._filtroMultiplesRubros.Filtros.Count = 0 Then
            Me.lnkFiltroMultiplesRubros.Text = "Todos los Rubros"
         ElseIf Me._filtroMultiplesRubros.Filtros.Count = 1 Then
            Me.lnkFiltroMultiplesRubros.Text = Me._filtroMultiplesRubros.Filtros(0).NombreRubro
         Else
            Me.lnkFiltroMultiplesRubros.Text = "Algunos Rubros"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

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

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
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

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

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

   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'Private Sub txtRedondeoPrecioVenta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
   '   Me.txtRedondeoPrecioVenta.SelectAll()
   'End Sub

   Private Sub txtRedondeoPrecioVenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRedondeoPrecioVenta.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub dgvListasPrecios_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListasPrecios.CellContentClick
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

   'Genera una Pila de llamados y da error
   'Private Sub dgvListasPrecios_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListasPrecios.CellValueChanged
   '   If e.RowIndex > -1 Then
   '      Dim Dbl As Double = 0
   '      If Double.TryParse(Me.dgvListasPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), Dbl) Then
   '         Me.dgvListasPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Dbl.ToString("N2")
   '      Else
   '         MessageBox.Show("El valor ingresado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '         Me.dgvListasPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
   '      End If
   '   End If
   'End Sub

   Private Sub dgvListasPrecios_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles dgvListasPrecios.CellValueNeeded
      If e.Value Is Nothing Then
         e.Value = "0.00"
      End If
   End Sub

   Private Sub dgvListasPrecios_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListasPrecios.CellEndEdit
      Try
         If e.RowIndex > -1 Then
            If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
               Dim Dbl As Double = 0
               If Double.TryParse(Me.dgvListasPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), Dbl) Then
                  Me.dgvListasPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Dbl   '.ToString("N" + Me._DecimalesEnPrecio.ToString())
               Else
                  MessageBox.Show("El valor ingresado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.dgvListasPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
               End If
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvListasPrecios_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvListasPrecios.DataError
      Try
         If e.Exception IsNot Nothing Then
            MessageBox.Show(e.Exception.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = False
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
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

   Private Sub dgvPrecios_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrecios.CellEndEdit

      Try

         If e.RowIndex > -1 Then
            Dim Dbl As Double = 0
            Dim precioCosto As Decimal, precioCostoNuevo As Decimal, precioVenta As Decimal

            If Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
               If Not Me.dgvPrecios.Columns(e.ColumnIndex).Name = "Sel" Then
                  Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
               End If

            End If

            If Me.dgvPrecios.Columns(e.ColumnIndex).HeaderText = "Nuevo D/R 1" Or Me.dgvPrecios.Columns(e.ColumnIndex).HeaderText = "Nuevo D/R 2" Or _
               Me.dgvPrecios.Columns(e.ColumnIndex).HeaderText = "Nuevo D/R 3" Or Me.dgvPrecios.Columns(e.ColumnIndex).HeaderText = "Nuevo D/R 4" Then

               If Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("IdProveedor").Value.ToString()) Then

                  If Double.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) > -100.0 And Double.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) < 100.0 Then

                     Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioFabrica1").Value

                     Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioFabrica1").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioFabrica1").Value), 2).ToString("N2")

                     If dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value IsNot Nothing AndAlso
                        Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value.ToString()) Then
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value) / 100)).ToString("N2")
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value), 2).ToString("N2")
                     End If
                     If dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value IsNot Nothing AndAlso
                        Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value.ToString()) Then
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value) / 100)).ToString("N2")
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value), 2).ToString("N2")
                     End If
                     If dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value IsNot Nothing AndAlso
                        Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value.ToString()) Then
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value) / 100)).ToString("N2")
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value), 2).ToString("N2")
                     End If
                     If dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value IsNot Nothing AndAlso
                        Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value.ToString()) Then
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value) / 100)).ToString("N2")
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value), 2).ToString("N2")
                     End If

                     Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value), 2).ToString("N2")

                     Dim IdProducto As String = Me.dgvPrecios.Rows(e.RowIndex).Cells("IdProducto").Value.ToString.Trim()

                     precioCosto = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto").Value.ToString())
                     precioCostoNuevo = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value.ToString())

                     For Each lis As Entidades.ListaDePrecios In Me._listas
                        'Obtener el nuevo precio de venta y setearlo a la grilla
                        precioVenta = 0

                        'If lis.IdListaPrecios = 0 Then
                        '   lis.NombreListaPrecios = "PrecioVenta"
                        'End If

                        If Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString() <> "" Then
                           precioVenta = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString())
                        End If
                        Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios + "1").Value = Me.GetPrecioVentaNuevo(IdProducto, precioCosto, precioCostoNuevo, precioVenta, lis.IdListaPrecios)
                     Next

                  Else
                     If Not _cargandoAutomaticamentePorcentajes Then
                        MessageBox.Show("El porcentaje no es correcto!. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     End If
                     Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                  End If
               Else
                  If Not _cargandoAutomaticamentePorcentajes Then
                     MessageBox.Show("El producto no tiene proveedor!. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  End If
                  Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
               End If
            ElseIf dgvPrecios.Columns(e.ColumnIndex).Name.Equals("PrecioCosto1") OrElse
                   dgvPrecios.Columns(e.ColumnIndex).Name.Equals("PrecioFabrica1") Then

               If Double.TryParse(Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), Dbl) AndAlso _
                  Double.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) >= 0 Then

                  Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Dbl.ToString("N" + Me._DecimalesEnPrecio.ToString())

                  'Si digito el Precio de Costo lo cambio en aquellas listas que correspondan.

                  If Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "PrecioCosto1" Then

                     Dim IdProducto As String = String.Empty

                     If Me.dgvPrecios.Rows(e.RowIndex).Cells("IdProducto").Value IsNot Nothing Then
                        IdProducto = Me.dgvPrecios.Rows(e.RowIndex).Cells("IdProducto").Value.ToString.Trim()
                     Else
                        Exit Sub
                     End If

                     precioCosto = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto").Value.ToString())
                     precioCostoNuevo = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value.ToString())

                     'dr.Cells("PrecioVenta1").Value = Me.GetPrecioVentaNuevo(precioCosto, precioCostoNuevo, precioVenta, 0)

                     For Each lis As Entidades.ListaDePrecios In Me._listas
                        'Obtener el nuevo precio de venta y setearlo a la grilla
                        precioVenta = 0

                        'If lis.IdListaPrecios = 0 Then
                        '   lis.NombreListaPrecios = "PrecioVenta"
                        'End If

                        If Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString() <> "" Then
                           precioVenta = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString())
                        End If
                        Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios + "1").Value = Me.GetPrecioVentaNuevo(IdProducto, precioCosto, precioCostoNuevo, precioVenta, lis.IdListaPrecios)
                     Next

                  Else
                     Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioFabrica1").Value

                     Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioFabrica1").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioFabrica1").Value), 2).ToString("N2")

                     If Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value.ToString()) Then
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value) / 100)).ToString("N2")
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value), 2).ToString("N2")
                     End If
                     If Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value.ToString()) Then
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value) / 100)).ToString("N2")
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value), 2).ToString("N2")
                     End If
                     If Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value.ToString()) Then
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value) / 100)).ToString("N2")
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value), 2).ToString("N2")
                     End If
                     If Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value.ToString()) Then
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value) / 100)).ToString("N2")
                        Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value), 2).ToString("N2")
                     End If

                     Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value), 2).ToString("N2")

                     Dim IdProducto As String = Me.dgvPrecios.Rows(e.RowIndex).Cells("IdProducto").Value.ToString.Trim()

                     precioCosto = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto").Value.ToString())
                     precioCostoNuevo = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value.ToString())

                     For Each lis As Entidades.ListaDePrecios In Me._listas
                        'Obtener el nuevo precio de venta y setearlo a la grilla
                        precioVenta = 0

                        'If lis.IdListaPrecios = 0 Then
                        '   lis.NombreListaPrecios = "PrecioVenta"
                        'End If

                        If Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString() <> "" Then
                           precioVenta = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString())
                        End If
                        Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios + "1").Value = Me.GetPrecioVentaNuevo(IdProducto, precioCosto, precioCostoNuevo, precioVenta, lis.IdListaPrecios)
                     Next

                  End If
               Else
                  If Not _cargandoAutomaticamentePorcentajes Then
                     MessageBox.Show("El valor ingresado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  End If
                  Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
               End If
            End If

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   'Genera una Pila de llamados y da error
   'Private Sub dgvPrecios_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrecios.CellValueChanged
   '   If e.RowIndex > -1 Then
   '      Dim Dbl As Double = 0
   '      If Double.TryParse(Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), Dbl) Then
   '         Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Dbl.ToString("N2")
   '      Else
   '         MessageBox.Show("El valor ingresado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '         Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
   '      End If
   '   End If
   'End Sub

   Private Sub dgvPrecios_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles dgvPrecios.CellValueNeeded
      If e.Value Is Nothing Then
         e.Value = "0.00"
      End If
   End Sub

   Private Sub txtPrecioCostoPorc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecioCostoPorc.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPrecioCostoMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecioCostoMonto.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub chbFechaActualizado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFechaActualizado.CheckedChanged
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

   Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click

      Try

         If Me.dgvPrecios.RowCount = 0 Then Exit Sub

         If Me.ValidarCalcular() Then
            Me.Cursor = Cursors.WaitCursor
            Me.BarraInicializa("Calculando precios...", 0, Me.dgvPrecios.Rows.Count)
            Me.PosibilitaOrdenarGrilla(False)
            Me._calcular = True
            Me.CalcularNuevosPrecios()

            Me.dgvPrecios.Focus()
            Me.dgvPrecios.CurrentCell = Me.dgvPrecios.CurrentRow.Cells("PrecioCosto1")

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

   Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeleccionListaPrecios.CellContentClick
      If e.ColumnIndex = 1 And e.RowIndex <> -1 Then
         Me.dgvSeleccionListaPrecios.CommitEdit(DataGridViewDataErrorContexts.Display)
      End If
   End Sub

   'Private Sub dgvDetalle_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeleccionListaPrecios.CellValueChanged
   '   If e.ColumnIndex = 1 And e.RowIndex <> -1 Then
   '      Me.CargaListasDePrecios()
   '   End If
   'End Sub

   Private Sub dgvSeleccionListaPrecios_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeleccionListaPrecios.CellLeave

      'If e.ColumnIndex = 1 And e.RowIndex <> -1 Then
      '   Me._listasSelec.Clear()

      '   For Each dr As DataGridViewRow In Me.dgvSeleccionListaPrecios.Rows
      '      If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then
      '         Me._listasSelec.Add(New Reglas.ListasDePrecios().GetUno(Integer.Parse(DirectCast(dr.DataBoundItem, DataRowView)("Id").ToString())))
      '      Else
      '         If Integer.Parse(dr.Cells("Id").Value.ToString()) = 0 Then
      '            Me._listasSelec.Add(New Reglas.ListasDePrecios().GetUno(Integer.Parse(DirectCast(dr.DataBoundItem, DataRowView)("Id").ToString())))
      '         End If
      '      End If
      '   Next
      '   Me.CargaListasDePrecios()
      'End If
   End Sub

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnumSI Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnumSI)
               Case Reglas.Publicos.TodosEnumSI.MarcarTodos

                  For Each dr As DataGridViewRow In dgvPrecios.Rows
                     dr.Cells("sel").Value = True
                  Next

                  Me.dgvPrecios.CommitEdit(DataGridViewDataErrorContexts.Display)

                  Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos

               Case Reglas.Publicos.TodosEnumSI.DesmarcarTodos

                  For Each dr As DataGridViewRow In dgvPrecios.Rows
                     dr.Cells("sel").Value = False
                  Next

                  Me.dgvPrecios.CommitEdit(DataGridViewDataErrorContexts.Display)

                  Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos

               Case Reglas.Publicos.TodosEnumSI.InvertirMarcasTodos
                  For Each dr As DataGridViewRow In dgvPrecios.Rows
                     dr.Cells("sel").Value = Not CBool(dr.Cells("sel").Value)
                  Next

                  Me.dgvPrecios.CommitEdit(DataGridViewDataErrorContexts.Display)

               Case Else

            End Select
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         Me.dgvPrecios.Update()
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
         dgvPrecios.Update()
      End Try
   End Sub

   Private Sub dgvPrecios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPrecios.CellContentClick
      If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
         If Me._calcular = True Then
            Me.dgvSeleccionListaPrecios.CommitEdit(DataGridViewDataErrorContexts.Display)
            Me.dgvListasPrecios.CommitEdit(DataGridViewDataErrorContexts.Display)
            If Me.tsbGrabar.Enabled = True Then
               MessageBox.Show("Debe Recalcular luego de modificar la seleccion.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.tsbGrabar.Enabled = False
         End If
      End If
   End Sub

#End Region

#Region "Metodos"

   'Private Sub PresionarTab(ByVal e As System.Windows.Forms.KeyEventArgs)
   '   If e.KeyCode = Keys.Enter Then
   '      Me.ProcessTabKey(True)
   '   End If
   'End Sub

   Private Sub BarraInicializa(ByVal texto As String, ByVal valorInicial As Integer, ByVal maximoValor As Integer)
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
            Case "VENTA"
               dr("PorcActual") = False
               dr("SobreVenta") = True
               dr("SobreCosto") = False
            Case Else
               dr("PorcActual") = False
               dr("SobreVenta") = False
               dr("SobreCosto") = True
         End Select

         dr("DesdeFormula") = False

         dr("DesdeFormula") = True

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
         .Columns("Porcentaje").DefaultCellStyle.Format = "#,##0.00"
         .Columns("Porcentaje").ValueType = System.Type.GetType("System.Double")

         .Columns("Monto").HeaderText = "$"
         .Columns("Monto").Width = 50
         .Columns("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns("Monto").DefaultCellStyle.Format = "#,##0.00"
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

         If Publicos.TieneModuloProduccion Then
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
               Case Else
                  chbPorcActual.Checked = False
                  chbSobreVenta.Checked = False
                  chbSobreCosto.Checked = True
                  chbDesdeFormula.Checked = False
            End Select
         Finally
            _cambiando = False
         End Try
      End With

   End Sub

   Private Sub RefrescarDatos()

      Me.tsbGrabar.Enabled = False
      Me.tsbImportarExcel.Enabled = False

      If Not Me._filtroMultiplesMarcas.dgvDatos.DataSource Is Nothing Then
         Me._filtroMultiplesMarcas.Filtros.Clear()
         Me._filtroMultiplesMarcas.dgvDatos.DataSource = Me._filtroMultiplesMarcas.Filtros.ToArray()
         Me.lnkFiltroMultiplesMarcas.Text = "Todas las Marcas"
      End If

      If Not Me._filtroMultiplesRubros.dgvDatos.DataSource Is Nothing Then
         Me._filtroMultiplesRubros.Filtros.Clear()
         Me._filtroMultiplesRubros.dgvDatos.DataSource = Me._filtroMultiplesRubros.Filtros.ToArray()
         Me.lnkFiltroMultiplesRubros.Text = "Todos los Rubros"
      End If

      Me.chbSubRubro.Checked = False
      Me.chbProducto.Checked = False
      Me.chbProveedor.Checked = False

      Me.chbSinCosto.Checked = False
      Me.chbSinVenta.Checked = False
      Me.cboCompuestos.SelectedIndex = 0

      Me.chbFechaActualizado.Checked = False

      Me.txtPrecioCostoPorc.Text = "0.00"
      Me.txtPrecioCostoMonto.Text = "0.00"
      Me.rdbCostoSiMismo.Checked = True

      Me.txtPorcenFabrica.Text = "0.00"

      Me.txtRedondeoPrecioVenta.Text = Publicos.PreciosDecimalesEnVenta.ToString()
      Me.txtAjusteA.Text = "9"
      Me.chbAjusteA.Checked = False

      Me.cmbEsOferta.SelectedIndex = 0

      'Me.CargaListasDePrecios()
      Me.CargaSeleccionListasDePrecios()

      If Not Me.dgvPrecios.DataSource Is Nothing Then
         DirectCast(Me.dgvPrecios.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.dgvListasPrecios.DataSource Is Nothing Then
         DirectCast(Me.dgvListasPrecios.DataSource, DataTable).Rows.Clear()
      End If


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

      Me.PosibilitaOrdenarGrilla(True)

      Me.tbcDetalle.SelectedTab = Me.TbpFiltros

   End Sub

   Private Sub CargarSucursales()

      'Si unifica Precios solo le muestro la sucursal actual. Luego se replica solo.
      'If Publicos.PreciosUnificar Then

      '   Me.clbSucursales.Items.Add(actual.Sucursal)
      '   Me.clbSucursales.SetItemChecked(0, True)

      'Else

      Dim lis As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(False)

      For Each suc As Entidades.Sucursal In lis
         Me.clbSucursales.Items.Add(suc)
         'Marco en forma predeterminada la Sucursal donde estoy parado. Ahorra trabajo, sobre todo si solo hay 1, tiene mas sentido.
         If suc.Id = actual.Sucursal.Id Then
            Me.clbSucursales.SetItemChecked(Me.clbSucursales.Items.Count - 1, True)
         End If
      Next

      'End If

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
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

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
      Me.chbProveedorHabitual.Enabled = True
   End Sub

   Private _productosAActualizar As DataTable

   Private Sub CargaGrillaDetalle()

      Dim Sucursales(10) As Integer
      Dim IdSubRubro As Integer = 0
      Dim IdProducto As String = ""
      Dim IdProveedor As Long = 0
      Dim FechaActDesde As Date = Nothing
      Dim FechaActHasta As Date = Nothing
      Dim EsOferta As String

      Dim con As Integer = 0
      For Each ite As Object In Me.clbSucursales.CheckedItems
         Sucursales(con) = DirectCast(ite, Entidades.Sucursal).Id
         con += 1
      Next

      If Me.chbSubRubro.Checked Then
         IdSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
      End If

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

      Me.dgvPrecios.Columns.Clear()

      Me._listasSelec.Clear()

      For Each dr As DataGridViewRow In Me.dgvSeleccionListaPrecios.Rows
         If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then
            Me._listasSelec.Add(New Reglas.ListasDePrecios().GetUno(Integer.Parse(DirectCast(dr.DataBoundItem, DataRowView)("Id").ToString())))
            'Else
            '   If Integer.Parse(dr.Cells("Id").Value.ToString()) = 0 Then
            '      Me._listasSelec.Add(New Reglas.ListasDePrecios().GetUno(Integer.Parse(DirectCast(dr.DataBoundItem, DataRowView)("Id").ToString())))
            '   End If
         End If
      Next

      Me.CargaListasDePrecios()

      'GAR: 10/05/2016 - NO debe recargar las listas al filtrar porque se pierden cuando graba
      'En caso de filtrar las listas, ahi debe mosotrar o no.
      'Me.CargaListasDePrecios()

      Dim arrProductos As Entidades.Producto() = {}
      If _comprasProductos IsNot Nothing Then
         arrProductos = _comprasProductos.ConvertAll(Function(x) x.ProductoSucursal.Producto).ToArray()
      End If

      Me._productosAActualizar = New Reglas.Productos().GetProductosParaActualizarPrecios(Sucursales, _
                                                                                 Me._listasSelec, _
                                                                                 Me._filtroMultiplesMarcas.Filtros.ToArray(), _
                                                                                 Me._filtroMultiplesRubros.Filtros.ToArray(), _
                                                                                 IdSubRubro, _
                                                                                 IdProducto, _
                                                                                 IdProveedor, _
                                                                                 Me.chbSinCosto.Checked, _
                                                                                 Me.chbSinVenta.Checked, _
                                                                                 Me.cboCompuestos.Text, _
                                                                                 FechaActDesde, FechaActHasta, txtCodigo.Text.Trim(), If(arrProductos.Length = 0, txtProducto.Text.Trim(), String.Empty),
                                                                                 Me.chbProveedorHabitual.Checked, EsOferta,
                                                                                 txtCodigoProductoProveedor.Text,
                                                                                 arrProductos)

      'Me._productosAActualizar.Columns.Add("Sel", System.Type.GetType("System.Boolean"))

      Me.dgvPrecios.DataSource = Me._productosAActualizar

      Me.tssRegistros.Text = Me.dgvPrecios.Rows.Count.ToString() & " Registros"
      Me.tsbGrabar.Enabled = False

      Me.AgregarSeleccion()

      Me.FormatearGrilla()

      Me.dgvPrecios.Columns("NombreProducto").Frozen = True

      Me.PosibilitaOrdenarGrilla(True)

   End Sub

   Private Sub AgregarSeleccion()
      'darle valor a la columna
      'Dim Sel As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
      'Me.dgvPrecios.Columns.Insert(0, Sel)
      '' Me.dgvPrecios.Columns.Add(Sel)
      'Sel.HeaderText = "Sel"
      'Sel.Name = "Sel"
      'Sel.DataPropertyName = "Sel"
      'Sel.Width = 30
      ''Me.dgvPrecios.Columns("Sel").DataPropertyName
      Me.dgvPrecios.Columns("Sel").Width = 30

      Dim blnSeleccionar As Boolean
      If Reglas.Publicos.ActualizarPreciosMostrarTodos Then
         blnSeleccionar = True
         Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos
      Else
         blnSeleccionar = False
         Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos
      End If

      '  If Me._estacargando Then

      For Each dr As DataGridViewRow In dgvPrecios.Rows
         dr.Cells("sel").Value = blnSeleccionar
      Next
      'End If

      'For Each dr As DataRow In Me._productosAActualizar.Rows
      '   dr("Sel") = blnSeleccionar
      'Next

   End Sub

   Private Sub FormatearGrilla()

      Me.dgvPrecios.Columns("IdSucursal").Visible = False
      Me.dgvPrecios.Columns("NombreCorto").Visible = False
      Me.dgvPrecios.Columns("Tamano").Visible = False
      Me.dgvPrecios.Columns("IdMarca").Visible = False
      Me.dgvPrecios.Columns("IdRubro").Visible = False
      Me.dgvPrecios.Columns("IdUnidadDeMedida").Visible = False
      Me.dgvPrecios.Columns("IdProveedor").Visible = False

      Dim SucElegidas As Integer = 0
      For Each ite As Object In Me.clbSucursales.CheckedItems
         SucElegidas += 1
      Next

      'If Me.clbSucursales.Items.Count > 1 Then
      If SucElegidas > 1 Then
         Me.dgvPrecios.Columns("NombreSucursal").HeaderText = "Sucursal"
         Me.dgvPrecios.Columns("NombreSucursal").Width = 70
         Me.dgvPrecios.Columns("NombreSucursal").ReadOnly = True
      Else
         Me.dgvPrecios.Columns("NombreSucursal").Visible = False
      End If

      Me.dgvPrecios.Columns("IdProducto").HeaderText = "Cod. Prod."
      Me.dgvPrecios.Columns("IdProducto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("IdProducto").Width = 100
      Me.dgvPrecios.Columns("IdProducto").ReadOnly = True
      'Me.dgvPrecios.Columns("IdProducto").Frozen = True
      Me.dgvPrecios.Columns("IdProductoSinEspacios").Visible = False

      Me.dgvPrecios.Columns("CodigoProductoProveedor").HeaderText = "Cod. Prod. Proveedor"
      Me.dgvPrecios.Columns("CodigoProductoProveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("CodigoProductoProveedor").Width = 100
      Me.dgvPrecios.Columns("CodigoProductoProveedor").ReadOnly = True

      Me.dgvPrecios.Columns("CodigoProductoProveedor").Visible = _actualizarPreciosMostrarCodigoProductoProveedor

      Me.dgvPrecios.Columns("NombreProducto").HeaderText = "Producto"
      'If Me.grbPrecioCompra.Visible Then
      '   Me.dgvPrecios.Columns("NombreProducto").Width = 180
      'Else
      Me.dgvPrecios.Columns("NombreProducto").Width = 200 '310
      'End If
      Me.dgvPrecios.Columns("NombreProducto").ReadOnly = True
      '      Me.dgvPrecios.Columns("NombreProducto").Frozen = True
      'If Me.dgvListasPrecios.RowCount = 1 Then
      '   Me.dgvPrecios.Columns("NombreProducto").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      'End If

      Me.dgvPrecios.Columns("NombreMarca").HeaderText = "Marca"
      Me.dgvPrecios.Columns("NombreMarca").ReadOnly = True

      Me.dgvPrecios.Columns("NombreRubro").HeaderText = "Rubro"
      Me.dgvPrecios.Columns("NombreRubro").ReadOnly = True

      Me.dgvPrecios.Columns("Alicuota").HeaderText = "IVA"
      Me.dgvPrecios.Columns("Alicuota").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("Alicuota").Width = 40
      Me.dgvPrecios.Columns("Alicuota").DefaultCellStyle.Format = "N2"
      Me.dgvPrecios.Columns("Alicuota").ReadOnly = True

      Me.dgvPrecios.Columns("Simbolo").HeaderText = "M."
      Me.dgvPrecios.Columns("Simbolo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      Me.dgvPrecios.Columns("Simbolo").Width = 40
      Me.dgvPrecios.Columns("Simbolo").ReadOnly = True

      Me.dgvPrecios.Columns("EsOferta").HeaderText = "Oferta"
      Me.dgvPrecios.Columns("EsOferta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      Me.dgvPrecios.Columns("EsOferta").Width = 40
      Me.dgvPrecios.Columns("EsOferta").ReadOnly = True

      Me.dgvPrecios.Columns("PrecioFabrica").HeaderText = "Precio Compra"
      Me.dgvPrecios.Columns("PrecioFabrica").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("PrecioFabrica").ReadOnly = True
      Me.dgvPrecios.Columns("PrecioFabrica").Width = 65
      Me.dgvPrecios.Columns("PrecioFabrica").DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      Me.dgvPrecios.Columns("PrecioFabrica").Visible = Publicos.UtilizaPrecioDeCompra


      Dim colPF As DataGridViewColumn = New DataGridViewColumn(Me.dgvPrecios.Columns("PrecioFabrica").CellTemplate)
      colPF.Name = "PrecioFabrica1"
      colPF.HeaderText = "Nuevo Precio Compra"
      colPF.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      colPF.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
      colPF.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      colPF.Width = 65
      Me.dgvPrecios.Columns.Insert(Me.dgvPrecios.Columns("PrecioFabrica").Index + 1, colPF)
      Me.dgvPrecios.Columns(colPF.Name).ReadOnly = True
      Me.dgvPrecios.Columns(colPF.Name).Visible = Publicos.UtilizaPrecioDeCompra

      Me.dgvPrecios.Columns("NombreProveedor").HeaderText = "Prov. Habitual"
      Me.dgvPrecios.Columns("NombreProveedor").ReadOnly = True
      Me.dgvPrecios.Columns("NombreProveedor").Width = 124
      Me.dgvPrecios.Columns("NombreProveedor").Visible = Publicos.UtilizaPrecioDeCompra

      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").HeaderText = "D/R 1"
      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").ReadOnly = True
      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").Width = 65
      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").Visible = Publicos.UtilizaPrecioDeCompra

      Dim colDR1 As DataGridViewColumn = New DataGridViewColumn(Me.dgvPrecios.Columns("DescuentoRecargoPorc1").CellTemplate)
      colDR1.Name = "DescuentoRecargoPorc11"
      colDR1.HeaderText = "Nuevo D/R 1"
      colDR1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      colDR1.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
      colDR1.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      colDR1.Width = 65
      Me.dgvPrecios.Columns.Insert(Me.dgvPrecios.Columns("DescuentoRecargoPorc1").Index + 1, colDR1)
      Me.dgvPrecios.Columns(colDR1.Name).ReadOnly = True
      Me.dgvPrecios.Columns(colDR1.Name).Visible = Publicos.UtilizaPrecioDeCompra


      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").HeaderText = "D/R 2"
      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").ReadOnly = True
      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").Width = 65
      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").Visible = Publicos.UtilizaPrecioDeCompra

      Dim colDR2 As DataGridViewColumn = New DataGridViewColumn(Me.dgvPrecios.Columns("DescuentoRecargoPorc2").CellTemplate)
      colDR2.Name = "DescuentoRecargoPorc21"
      colDR2.HeaderText = "Nuevo D/R 2"
      colDR2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      colDR2.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
      colDR2.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      colDR2.Width = 65
      Me.dgvPrecios.Columns.Insert(Me.dgvPrecios.Columns("DescuentoRecargoPorc2").Index + 1, colDR2)
      Me.dgvPrecios.Columns(colDR2.Name).ReadOnly = True
      Me.dgvPrecios.Columns(colDR2.Name).Visible = Publicos.UtilizaPrecioDeCompra

      Me.dgvPrecios.Columns("DescuentoRecargoPorc3").HeaderText = "D/R 3"
      Me.dgvPrecios.Columns("DescuentoRecargoPorc3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("DescuentoRecargoPorc3").ReadOnly = True
      Me.dgvPrecios.Columns("DescuentoRecargoPorc3").Width = 65
      Me.dgvPrecios.Columns("DescuentoRecargoPorc3").DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      Me.dgvPrecios.Columns("DescuentoRecargoPorc3").Visible = Publicos.UtilizaPrecioDeCompra

      Dim colDR3 As DataGridViewColumn = New DataGridViewColumn(Me.dgvPrecios.Columns("DescuentoRecargoPorc3").CellTemplate)
      colDR3.Name = "DescuentoRecargoPorc31"
      colDR3.HeaderText = "Nuevo D/R 3"
      colDR3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      colDR3.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
      colDR3.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      colDR3.Width = 65
      Me.dgvPrecios.Columns.Insert(Me.dgvPrecios.Columns("DescuentoRecargoPorc3").Index + 1, colDR3)
      Me.dgvPrecios.Columns(colDR3.Name).ReadOnly = True
      Me.dgvPrecios.Columns(colDR3.Name).Visible = Publicos.UtilizaPrecioDeCompra

      Me.dgvPrecios.Columns("DescuentoRecargoPorc4").HeaderText = "D/R 4"
      Me.dgvPrecios.Columns("DescuentoRecargoPorc4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("DescuentoRecargoPorc4").ReadOnly = True
      Me.dgvPrecios.Columns("DescuentoRecargoPorc4").Width = 65
      Me.dgvPrecios.Columns("DescuentoRecargoPorc4").DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      Me.dgvPrecios.Columns("DescuentoRecargoPorc4").Visible = Publicos.UtilizaPrecioDeCompra

      Dim colDR4 As DataGridViewColumn = New DataGridViewColumn(Me.dgvPrecios.Columns("DescuentoRecargoPorc4").CellTemplate)
      colDR4.Name = "DescuentoRecargoPorc41"
      colDR4.HeaderText = "Nuevo D/R 4"
      colDR4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      colDR4.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
      colDR4.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      colDR4.Width = 65
      Me.dgvPrecios.Columns.Insert(Me.dgvPrecios.Columns("DescuentoRecargoPorc4").Index + 1, colDR4)
      Me.dgvPrecios.Columns(colDR4.Name).ReadOnly = True
      Me.dgvPrecios.Columns(colDR4.Name).Visible = Publicos.UtilizaPrecioDeCompra

      Me.dgvPrecios.Columns("PrecioCosto").HeaderText = "Precio Costo"
      Me.dgvPrecios.Columns("PrecioCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("PrecioCosto").ReadOnly = True
      Me.dgvPrecios.Columns("PrecioCosto").Width = 65
      Me.dgvPrecios.Columns("PrecioCosto").DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()

      Dim colPC As DataGridViewColumn = New DataGridViewColumn(Me.dgvPrecios.Columns("PrecioCosto").CellTemplate)
      colPC.Name = "PrecioCosto1"
      colPC.HeaderText = "Nuevo Precio Costo"
      colPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      colPC.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
      colPC.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      colPC.Width = 65
      Me.dgvPrecios.Columns.Insert(Me.dgvPrecios.Columns("PrecioCosto").Index + 1, colPC)
      Me.dgvPrecios.Columns(colPC.Name).ReadOnly = True

      'Me.dgvPrecios.Columns("Porc").HeaderText = "  %"
      'Me.dgvPrecios.Columns("Porc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      'Me.dgvPrecios.Columns("Porc").ReadOnly = True
      'Me.dgvPrecios.Columns("Porc").Width = 50
      'Me.dgvPrecios.Columns("Porc").DefaultCellStyle.Format = "N2"


      'Me.dgvPrecios.Columns("PrecioVenta").HeaderText = "Lista de Venta 1"
      'Me.dgvPrecios.Columns("PrecioVenta").HeaderText = New Reglas.ListasDePrecios().GetUno(0).NombreListaPrecios
      'Me.dgvPrecios.Columns("PrecioVenta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      'Me.dgvPrecios.Columns("PrecioVenta").ReadOnly = True
      'Me.dgvPrecios.Columns("PrecioVenta").Width = 65
      'Me.dgvPrecios.Columns("PrecioVenta").DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()

      'Dim colPV As DataGridViewColumn = New DataGridViewColumn(Me.dgvPrecios.Columns("PrecioVenta").CellTemplate)
      'colPV.Name = "PrecioVenta1"
      ''colPV.HeaderText = "Nuevo Lista de Venta 1"
      'colPV.HeaderText = "Nuevo " & New Reglas.ListasDePrecios().GetUno(0).NombreListaPrecios
      'colPV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      'colPV.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
      'colPV.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      'colPV.Width = 65
      'Me.dgvPrecios.Columns.Insert(Me.dgvPrecios.Columns("PrecioVenta").Index + 1, colPV)
      'Me.dgvPrecios.Columns(colPV.Name).ReadOnly = True

      For Each lis As Entidades.ListaDePrecios In Me._listasSelec
         For Each col As DataGridViewColumn In Me.dgvPrecios.Columns

            If col.Name = "Porc" & lis.IdListaPrecios Then
               Me.dgvPrecios.Columns(col.Name).HeaderText = "  %"
               Me.dgvPrecios.Columns(col.Name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
               Me.dgvPrecios.Columns(col.Name).ReadOnly = True
               Me.dgvPrecios.Columns(col.Name).Width = 50
               Me.dgvPrecios.Columns(col.Name).DefaultCellStyle.Format = "N2"
            End If

            If col.Name = lis.NombreListaPrecios Then
               col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
               col.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
               col.Width = 65
               col.ReadOnly = True
               Dim col1 As DataGridViewColumn = New DataGridViewColumn(col.CellTemplate)
               col1.Name = lis.NombreListaPrecios + "1"
               col1.HeaderText = "Nuevo " + lis.NombreListaPrecios
               col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
               col1.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
               col1.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
               col1.Width = 65
               Me.dgvPrecios.Columns.Insert(col.Index + 1, col1)
               'Me.dgvPrecios.Columns(col1.Name).SortMode = DataGridViewColumnSortMode.NotSortable
               Me.dgvPrecios.Columns(col1.Name).ReadOnly = True
               Exit For
            End If
         Next
      Next

      Me.dgvPrecios.Columns("FechaActualizacion").HeaderText = "Actualizacion Costo"
      Me.dgvPrecios.Columns("FechaActualizacion").Width = 100
      Me.dgvPrecios.Columns("FechaActualizacion").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
      Me.dgvPrecios.Columns("FechaActualizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      Me.dgvPrecios.Columns("FechaActualizacion").ReadOnly = True

      Me.dgvPrecios.Columns("Stock").HeaderText = "Stock"
      Me.dgvPrecios.Columns("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("Stock").ReadOnly = True
      Me.dgvPrecios.Columns("Stock").Width = 60
      Me.dgvPrecios.Columns("Stock").DefaultCellStyle.Format = "N2"

      If Publicos.TieneModuloProduccion Then
         Me.dgvPrecios.Columns("EsCompuesto").HeaderText = "Formula"
         Me.dgvPrecios.Columns("EsCompuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         Me.dgvPrecios.Columns("EsCompuesto").ReadOnly = True
         Me.dgvPrecios.Columns("EsCompuesto").Width = 50
      Else
         Me.dgvPrecios.Columns("EsCompuesto").Visible = False
      End If

      Me.dgvPrecios.Columns("UltimoProv").HeaderText = "Prov. Ultima Compra"
      Me.dgvPrecios.Columns("UltimoProv").ReadOnly = True
      Me.dgvPrecios.Columns("UltimoProv").Width = 124

   End Sub

   Private _todosLosProductos As DataTable

   Private Sub CalcularNuevosPrecios()

      Dim IdProducto As String = ""
      Dim precioFabrica As Decimal = 0
      Dim precioCosto As Decimal = 0
      Dim precioVenta As Decimal = 0
      Dim precioFabricaNuevo As Decimal = 0
      Dim precioCostoNuevo As Decimal = 0
      Dim DR1Nuevo As Decimal = 0
      Dim DR2Nuevo As Decimal = 0
      Dim DR3Nuevo As Decimal = 0
      Dim DR4Nuevo As Decimal = 0

      Me._todosLosProductos = New Reglas.Productos().GetAll()

      For Each dr As DataGridViewRow In Me.dgvPrecios.Rows
         If Boolean.Parse(dr.Cells("Sel").Value.ToString()) Then


            IdProducto = dr.Cells("IdProducto").Value.ToString.Trim()

            precioFabrica = Decimal.Parse(dr.Cells("PrecioFabrica").Value.ToString())
            precioCosto = Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString())
            'precioVenta = Decimal.Parse(dr.Cells("PrecioVenta").Value.ToString())

            'Obtener el nuevo precio de fabrica y setearlo a la grilla
            precioFabricaNuevo = Me.GetPrecioFabricaNuevo(precioFabrica)
            dr.Cells("PrecioFabrica1").Value = precioFabricaNuevo

            dr.Cells("DescuentoRecargoPorc11").Value = dr.Cells("DescuentoRecargoPorc1").Value
            dr.Cells("DescuentoRecargoPorc21").Value = dr.Cells("DescuentoRecargoPorc2").Value
            dr.Cells("DescuentoRecargoPorc31").Value = dr.Cells("DescuentoRecargoPorc3").Value
            dr.Cells("DescuentoRecargoPorc41").Value = dr.Cells("DescuentoRecargoPorc4").Value

            If IsNumeric(dr.Cells("DescuentoRecargoPorc11").Value) Then
               DR1Nuevo = Decimal.Parse(dr.Cells("DescuentoRecargoPorc11").Value.ToString())
            Else
               DR1Nuevo = 0
            End If
            If IsNumeric(dr.Cells("DescuentoRecargoPorc21").Value) Then
               DR2Nuevo = Decimal.Parse(dr.Cells("DescuentoRecargoPorc21").Value.ToString())
            Else
               DR2Nuevo = 0
            End If
            If IsNumeric(dr.Cells("DescuentoRecargoPorc31").Value) Then
               DR3Nuevo = Decimal.Parse(dr.Cells("DescuentoRecargoPorc31").Value.ToString())
            Else
               DR3Nuevo = 0
            End If
            If IsNumeric(dr.Cells("DescuentoRecargoPorc41").Value) Then
               DR4Nuevo = Decimal.Parse(dr.Cells("DescuentoRecargoPorc41").Value.ToString())
            Else
               DR4Nuevo = 0
            End If

            precioCostoNuevo = Me.GetPrecioCostoNuevo(IdProducto, precioFabricaNuevo, precioCosto, DR1Nuevo, DR2Nuevo, DR3Nuevo, DR4Nuevo)
            'Obtener el nuevo precio de costo y setearlo a la grilla

            If _comprasProductos IsNot Nothing Then
               For Each cp In _comprasProductos.Where(Function(x) x.IdProducto.Trim() = dr.Cells("IdProducto").Value.ToString().Trim())
                  Dim p As Entidades.Producto = cp.ProductoSucursal.Producto
                  If Publicos.PreciosConIVA Then
                     Dim porcentajeIVA As Decimal = cp.PorcentajeIVA
                     'Si es Monotributista (el Proveedor o la Empresa) tomo el IVA del producto porque el comprobante está con IVA 0
                     'Si yo soy Monotributista mis productos deberían estar configurados con IVA 0, por lo que no es problema esto
                     If Not _categoriaFiscalProveedor.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
                        porcentajeIVA = p.Alicuota
                     End If
                     precioCostoNuevo = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(cp.Precio, porcentajeIVA,
                                                                                             p.PorcImpuestoInterno, p.ImporteImpuestoInterno, p.OrigenPorcImpInt)
                  Else
                     precioCostoNuevo = cp.Precio
                  End If
               Next
            End If

            dr.Cells("PrecioCosto1").Value = precioCostoNuevo

            If _comprasProductos IsNot Nothing Then
               Dim precioFabricaNuevoSegunCompra As Decimal = precioCostoNuevo
               precioFabricaNuevoSegunCompra = precioFabricaNuevoSegunCompra / (1 - (DR4Nuevo / 100))
               precioFabricaNuevoSegunCompra = precioFabricaNuevoSegunCompra / (1 - (DR3Nuevo / 100))
               precioFabricaNuevoSegunCompra = precioFabricaNuevoSegunCompra / (1 - (DR2Nuevo / 100))
               precioFabricaNuevoSegunCompra = precioFabricaNuevoSegunCompra / (1 - (DR1Nuevo / 100))

               dr.Cells("PrecioFabrica1").Value = precioFabricaNuevoSegunCompra
            End If

            'dr.Cells("PrecioVenta1").Value = Me.GetPrecioVentaNuevo(IdProducto, precioCosto, precioCostoNuevo, precioVenta, 0)

            For Each lis As Entidades.ListaDePrecios In Me._listasSelec
               'Obtener el nuevo precio de venta y setearlo a la grilla
               precioVenta = 0

               'If lis.IdListaPrecios = 0 Then
               '   lis.NombreListaPrecios = "PrecioVenta"
               'End If

               If dr.Cells(lis.NombreListaPrecios).Value.ToString() <> "" Then
                  precioVenta = Decimal.Parse(dr.Cells(lis.NombreListaPrecios).Value.ToString())
               End If
               dr.Cells(lis.NombreListaPrecios + "1").Value = Me.GetPrecioVentaNuevo(IdProducto, precioCosto, precioCostoNuevo, precioVenta, lis.IdListaPrecios)
            Next

            Me.tspBarra.Value += 1
         Else
            dr.Cells("PrecioFabrica1").Value = ""
            dr.Cells("DescuentoRecargoPorc11").Value = ""
            dr.Cells("DescuentoRecargoPorc21").Value = ""
            dr.Cells("DescuentoRecargoPorc31").Value = ""
            dr.Cells("DescuentoRecargoPorc41").Value = ""
            dr.Cells("PrecioCosto1").Value = ""
            'dr.Cells("PrecioVenta1").Value = ""

            'For Each lis As Entidades.ListaDePrecios In Me._listasSelec
            '   dr.Cells(lis.NombreListaPrecios + "1").Value = 0
            'Next

         End If
      Next

      'Me.dgvPrecios.Enabled = True

      Me.dgvPrecios.Columns("PrecioFabrica1").ReadOnly = False
      Me.dgvPrecios.Columns("PrecioCosto1").ReadOnly = False
      'Me.dgvPrecios.Columns("PrecioVenta1").ReadOnly = False

      Me.dgvPrecios.Columns("DescuentoRecargoPorc11").ReadOnly = False
      Me.dgvPrecios.Columns("DescuentoRecargoPorc21").ReadOnly = False
      Me.dgvPrecios.Columns("DescuentoRecargoPorc31").ReadOnly = False
      Me.dgvPrecios.Columns("DescuentoRecargoPorc41").ReadOnly = False

      For Each lis As Entidades.ListaDePrecios In Me._listasSelec
         For Each col As DataGridViewColumn In Me.dgvPrecios.Columns

            If col.Name = lis.NombreListaPrecios Then

               Dim col1 As DataGridViewColumn = New DataGridViewColumn(col.CellTemplate)
               col1.Name = lis.NombreListaPrecios + "1"
               Me.dgvPrecios.Columns(col1.Name).ReadOnly = False
               Exit For
            End If
         Next
      Next

      'For Each lis As DataGridViewRow In Me.dgvSeleccionListaPrecios.Rows
      '   If Integer.Parse(lis.Cells("Id").Value.ToString()) = 0 And Not Boolean.Parse(lis.Cells("Selec").Value.ToString()) Then
      '      For Each col As DataGridViewColumn In Me.dgvPrecios.Columns

      '         Me.dgvPrecios.Columns("Porc").Visible = False
      '         Me.dgvPrecios.Columns("PrecioVenta").Visible = False
      '         Me.dgvPrecios.Columns("PrecioVenta1").Visible = False

      '         Exit For

      '      Next
      '   End If
      'Next

   End Sub

   Private Sub PosibilitaOrdenarGrilla(ByVal Permite As Boolean)

      Dim Valor As Windows.Forms.DataGridViewColumnSortMode

      If Permite Then
         Valor = DataGridViewColumnSortMode.Automatic
      Else
         Valor = DataGridViewColumnSortMode.NotSortable
      End If

      For Each col As DataGridViewColumn In Me.dgvPrecios.Columns
         If col.Visible Then
            col.SortMode = Valor
         End If
      Next

   End Sub

   'Private Function GetPrecioFabricaNuevo(ByVal precioFabrica As Decimal) As Decimal
   '   Dim porcFabrica As Decimal = Decimal.Round(Decimal.Parse(Me.txtPorcenFabrica.Text) / 100, 4)
   '   Dim precioFabricaNuevo As Decimal = 0

   '   'Calcular el precio de fabrica nuevo
   '   If porcFabrica <> 0 Then
   '      precioFabricaNuevo = precioFabrica + Decimal.Round(precioFabrica * porcFabrica, 2)
   '   Else
   '      precioFabricaNuevo = precioFabrica
   '   End If
   '   'Retornar el nuevo precio de fabrica 
   '   Return precioFabricaNuevo
   'End Function

   Private Function GetPrecioCostoNuevo(ByVal IdProducto As String, ByVal precioFabricaNuevo As Decimal,
                                        ByVal precioCosto As Decimal, ByVal DR1 As Decimal, ByVal DR2 As Decimal,
                                        ByVal DR3 As Decimal, ByVal DR4 As Decimal) As Decimal

      Dim porcCosto1 As Decimal = Decimal.Round(Decimal.Parse(Me.txtPrecioCostoPorc.Text) / 100, 4)
      Dim precioCostoNuevo As Decimal = 0

      'Calcular el precio de costo nuevo
      If Me.rdbCostoFabrica.Checked Then
         'Calculo sobre el precio de fabrica
         If porcCosto1 <> 0 Then
            precioCostoNuevo = precioFabricaNuevo + Decimal.Round(precioFabricaNuevo * porcCosto1, 2)
         Else
            precioCostoNuevo = precioFabricaNuevo

            precioCostoNuevo = precioCostoNuevo + precioCostoNuevo * DR1 / 100
            precioCostoNuevo = precioCostoNuevo + precioCostoNuevo * DR2 / 100
            precioCostoNuevo = precioCostoNuevo + precioCostoNuevo * DR3 / 100
            precioCostoNuevo = precioCostoNuevo + precioCostoNuevo * DR4 / 100
         End If
      Else

         If Me.rdbCostoDesdeFormula.Checked Then
            Dim formu As DataRow() = (From form As DataRow In Me._todosLosProductos.AsEnumerable()
               Where form.Field(Of String)("IdProducto").Trim() = IdProducto
               Select form).ToArray()

            If formu.Length = 0 Then
               Throw New Exception(String.Format("No se encontró el producto '{0}' en la lista de formulas.", IdProducto))
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
               Throw New Exception(String.Format("El producto {0} - {1} no posee fórmula.", IdProducto, nombre))
            End If

            Dim oProdComp As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
            precioCosto = oProdComp.GetPrecioCosto(actual.Sucursal.IdSucursal, IdProducto, formula)
         End If

         'Calculo sobre el precio costo
         If porcCosto1 <> 0 Then
            precioCostoNuevo = precioCosto + Decimal.Round(precioCosto * porcCosto1, 4)
         Else
            precioCostoNuevo = precioCosto
         End If
      End If

      'precioCostoNuevo = precioCosto

      precioCostoNuevo += Decimal.Parse(Me.txtPrecioCostoMonto.Text)

      'Retornar el nuevo precio de costo 
      Return precioCostoNuevo

   End Function

   Private Function GetPrecioVentaNuevo(ByVal IdProducto As String, ByVal precioCosto As Decimal, ByVal precioCostoNuevo As Decimal, ByVal precioVenta As Decimal, ByVal idListaDePrecios As Integer) As Decimal

      Dim porcRecargo As Decimal = 0
      Dim Monto As Decimal = 0

      Dim ComoCalcular As String = ""

      For Each dr As DataGridViewRow In Me.dgvListasPrecios.Rows
         If Integer.Parse(dr.Cells("Id").Value.ToString()) = idListaDePrecios Then

            porcRecargo = Decimal.Round(Decimal.Parse(dr.Cells("Porcentaje").Value.ToString()) / 100, 4)
            Monto = Decimal.Parse(dr.Cells("Monto").Value.ToString())

            Select Case True
               Case Boolean.Parse(dr.Cells("PorcActual").Value.ToString())
                  ComoCalcular = "PorcActual"
                  porcRecargo = 0

               Case Boolean.Parse(dr.Cells("SobreVenta").Value.ToString())
                  ComoCalcular = "SobreVenta"

               Case Boolean.Parse(dr.Cells("SobreCosto").Value.ToString())
                  ComoCalcular = "SobreCosto"

               Case Boolean.Parse(dr.Cells("DesdeFormula").Value.ToString())
                  ComoCalcular = "DesdeFormula"

               Case Else

            End Select

            Exit For
         End If
      Next

      Dim precioVentaNuevo As Decimal = 0

      'Calcular el precio de venta nuevo
      Select Case ComoCalcular

         Case "PorcActual"
            If precioCosto <> 0 Then
               porcRecargo = Decimal.Parse(IIf(precioCosto > 0, (precioVenta / precioCosto - 1), 0).ToString())
               precioVentaNuevo = precioCostoNuevo + Decimal.Round(precioCostoNuevo * porcRecargo, 4)
            Else
               precioVentaNuevo = precioCostoNuevo
            End If

         Case "SobreVenta"
            'Calculo sobre el precio venta
            If porcRecargo <> 0 Then
               precioVentaNuevo = precioVenta + Decimal.Round(precioVenta * porcRecargo, 4)
            Else
               precioVentaNuevo = precioVenta
            End If

         Case "SobreCosto"
            'Calculo sobre el precio de costo
            If porcRecargo <> 0 Then
               precioVentaNuevo = precioCostoNuevo + Decimal.Round(precioCostoNuevo * porcRecargo, 4)
            Else
               precioVentaNuevo = precioCostoNuevo
            End If

         Case "DesdeFormula"
            Dim oProdComp As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()

            Dim formula As Integer
            formula = New Reglas.Productos().GetUno(IdProducto).IdFormula

            precioVenta = oProdComp.GetPrecioVenta(actual.Sucursal.IdSucursal, IdProducto, formula, idListaDePrecios)

            If porcRecargo <> 0 Then
               precioVentaNuevo = precioVenta + Decimal.Round(precioVenta * porcRecargo, 4)
            Else
               precioVentaNuevo = precioVenta
            End If

         Case Else

      End Select

      precioVentaNuevo += Monto

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

      'Retornar el nuevo precio de venta 
      Return precioVentaNuevo

   End Function

   Private Function GetPrecioFabricaNuevo(ByVal precioFabrica As Decimal) As Decimal
      Dim porcFabrica As Decimal = Decimal.Round(Decimal.Parse(Me.txtPorcenFabrica.Text) / 100, 4)
      Dim precioFabricaNuevo As Decimal = 0

      'Calcular el precio de fabrica nuevo
      If porcFabrica <> 0 Then
         precioFabricaNuevo = precioFabrica + Decimal.Round(precioFabrica * porcFabrica, 2)
      Else
         precioFabricaNuevo = precioFabrica
      End If
      'Retornar el nuevo precio de fabrica 
      Return precioFabricaNuevo
   End Function

   Private Sub CargarYGrabarPrecios()

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

      For Each dr As DataGridViewRow In Me.dgvPrecios.Rows

         If Boolean.Parse(dr.Cells("Sel").Value.ToString()) Then
            Me.tssInfo.Text = "Procesando..."
            Application.DoEvents()

            If Me.CambiaronLosPrecios(dr) Then
               oProdS = New Entidades.ProductoSucursal()
               'Cargo los valores de la grilla al objeto productosSucursales
               With oProdS
                  .Producto.IdProducto = dr.Cells("IdProducto").Value.ToString.Trim()
                  If Not String.IsNullOrEmpty(dr.Cells("IdProveedor").Value.ToString()) Then
                     .Producto.ProductoProveedorHabitual = New Reglas.ProductosProveedores().GetUno(Long.Parse(dr.Cells("IdProveedor").Value.ToString()), .Producto.IdProducto)
                     If .Producto.ProductoProveedorHabitual IsNot Nothing Then
                        .Producto.ProductoProveedorHabitual.UltimoPrecioFabrica = Decimal.Parse(dr.Cells("PrecioFabrica1").Value.ToString())
                        If Not String.IsNullOrEmpty(dr.Cells("DescuentoRecargoPorc11").Value.ToString()) Then
                           .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = Decimal.Parse(dr.Cells("DescuentoRecargoPorc11").Value.ToString())
                        Else
                           .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = 0
                        End If
                        If Not String.IsNullOrEmpty(dr.Cells("DescuentoRecargoPorc21").Value.ToString()) Then
                           .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = Decimal.Parse(dr.Cells("DescuentoRecargoPorc21").Value.ToString())
                        Else
                           .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = 0
                        End If
                        If Not String.IsNullOrEmpty(dr.Cells("DescuentoRecargoPorc31").Value.ToString()) Then
                           .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = Decimal.Parse(dr.Cells("DescuentoRecargoPorc31").Value.ToString())
                        Else
                           .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = 0
                        End If
                        If Not String.IsNullOrEmpty(dr.Cells("DescuentoRecargoPorc41").Value.ToString()) Then
                           .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = Decimal.Parse(dr.Cells("DescuentoRecargoPorc41").Value.ToString())
                        Else
                           .Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = 0
                        End If
                     End If
                  End If

                  .Sucursal.Id = Integer.Parse(dr.Cells("IdSucursal").Value.ToString())
                  .PrecioFabrica = Decimal.Parse(dr.Cells("PrecioFabrica1").Value.ToString())
                  .PrecioCosto = Decimal.Parse(dr.Cells("PrecioCosto1").Value.ToString())
                  .Stock = Decimal.Parse(dr.Cells("Stock").Value.ToString())
                  .Usuario = actual.Nombre

                  If .PrecioFabrica < 0 Then
                     MessageBox.Show("El producto '" & dr.Cells("IdProducto").Value.ToString.Trim() & " - " & dr.Cells("NombreProducto").Value.ToString.Trim() & _
                                          "' tiene el precio de Compra negativo, NO puede continuar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                     Return
                  End If

                  If .PrecioCosto < 0 Then
                     MessageBox.Show("El producto '" & dr.Cells("IdProducto").Value.ToString.Trim() & " - " & dr.Cells("NombreProducto").Value.ToString.Trim() & _
                                          "' tiene el precio de Costo negativo, NO puede continuar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                     Return
                  End If

                  'If .PrecioVenta < 0 Then
                  '   MessageBox.Show("El producto '" & dr.Cells("IdProducto").Value.ToString.Trim() & " - " & dr.Cells("NombreProducto").Value.ToString.Trim() & _
                  '                        "' tiene el precio de Venta negativo, NO puede continuar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  '   Return
                  'End If

                  If Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString()) > 0 And Decimal.Parse(dr.Cells("PrecioCosto1").Value.ToString()) = 0 And Not Pregunto3 Then
                     If MessageBox.Show("El producto '" & dr.Cells("IdProducto").Value.ToString.Trim() & " - " & dr.Cells("NombreProducto").Value.ToString.Trim() & _
                                          "' tiene el precio de Costo Nuevo es 0 (cero) pero el Actual NO, continua en este caso y en los demas ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Return
                     End If
                     Pregunto3 = True
                  End If

                  'If Decimal.Parse(dr.Cells("PrecioVenta").Value.ToString()) > 0 And Decimal.Parse(dr.Cells("PrecioVenta1").Value.ToString()) = 0 And Not Pregunto4 Then
                  '   If MessageBox.Show("El producto '" & dr.Cells("IdProducto").Value.ToString.Trim() & " - " & dr.Cells("NombreProducto").Value.ToString.Trim() & _
                  '                        "' tiene el precio de Venta Nuevo es 0 (cero) pero el Actual NO, continua en este caso y en los demas ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                  '      Return
                  '   End If
                  '   Pregunto4 = True
                  'End If

                  Me.tssInfo.Text = "Recorriendo listas..."
                  For Each lis As Entidades.ListaDePrecios In Me._listasSelec
                     oProdSP = New Entidades.ProductoSucursalPrecio()
                     oProdSP.ProductoSucursal = oProdS
                     oProdSP.IdSucursal = Integer.Parse(dr.Cells("IdSucursal").Value.ToString())
                     oProdSP.ListaDePrecios = lis

                     If Decimal.Parse("0" + dr.Cells(lis.NombreListaPrecios).Value.ToString()) > 0 And Decimal.Parse("0" + dr.Cells(lis.NombreListaPrecios + "1").Value.ToString()) = 0 And Not Pregunto4 Then
                        If MessageBox.Show("El producto '" & dr.Cells("IdProducto").Value.ToString.Trim() & _
                                             " - " & dr.Cells("NombreProducto").Value.ToString.Trim() & _
                                             " de la lista " & lis.NombreListaPrecios & _
                                             "' tiene el precio de Venta Nuevo es 0 (cero) pero el Actual NO, continua en este caso y en los demas ?", _
                                             Me.Text, _
                                             MessageBoxButtons.YesNo, _
                                             MessageBoxIcon.Question, _
                                             MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                           Return
                        End If
                        Pregunto4 = True
                     End If

                     oProdSP.PrecioVenta = Decimal.Parse(dr.Cells(lis.NombreListaPrecios + "1").Value.ToString())
                     oProdSP.Usuario = Entidades.Usuario.Actual.Nombre
                     .Precios.Add(oProdSP)
                  Next

                  'Pensado fundamentalmente cuando carga por primera vez, para no obligar a cargar manualmente todo y si pueda calcular.
                  If .PrecioFabrica > .PrecioCosto And Not Pregunto1 Then
                     If MessageBox.Show("El producto '" & dr.Cells("IdProducto").Value.ToString.Trim() & " - " & dr.Cells("NombreProducto").Value.ToString.Trim() & _
                                          "' tiene el precio de Compra mayor al precio de Costo, continua en este caso y en los demas ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Return
                     End If
                     Pregunto1 = True
                  End If

                  If Not Pregunto2 Then
                     For Each pre As Entidades.ProductoSucursalPrecio In .Precios
                        If .PrecioCosto > pre.PrecioVenta Then
                           If MessageBox.Show(String.Format("El producto '{0} - {1}' tiene el precio de Costo mayor al precio de Venta en la lista {2}, continua en este caso y en los demas ?",
                                                                                 dr.Cells("IdProducto").Value.ToString.Trim(),
                                                                                 dr.Cells("NombreProducto").Value.ToString.Trim(),
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

         End If

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

      'Dim tr As Threading.Thread = New Threading.Thread(AddressOf GrabarPrecios)
      'tr.Start()
      'Me.tspBarra.Value = 0

      'Do While tr.IsAlive
      '   Me.tspBarra.Value += 1
      '   If Me.tspBarra.Value = Me.tspBarra.Maximum Then
      '      Me.tspBarra.Value = 0
      '   End If
      '   Me.stsStado.Refresh()
      '   Me.Refresh()
      'Loop

      'Me.tspBarra.Value = Me.tspBarra.Maximum
      'Me.Refresh()
      MessageBox.Show("Precios grabados con exito!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.CargaGrillaDetalle()
   End Sub

   Private Function CambiaronLosPrecios(ByVal dr As DataGridViewRow) As Boolean

      If dr.Cells("PrecioFabrica1").Value Is Nothing Then
         dr.Cells("PrecioFabrica1").Value = "0.00"
      End If

      If Decimal.Parse(dr.Cells("PrecioFabrica").Value.ToString()) <> Decimal.Parse(dr.Cells("PrecioFabrica1").Value.ToString()) Then
         Return True
      End If

      If dr.Cells("PrecioCosto1").Value Is Nothing Then
         dr.Cells("PrecioCosto1").Value = "0.00"
      End If

      If Decimal.Parse(dr.Cells("PrecioCosto").Value.ToString()) <> Decimal.Parse(dr.Cells("PrecioCosto1").Value.ToString()) Then
         Return True
      End If

      'If dr.Cells("PrecioVenta1").Value Is Nothing Then
      '   dr.Cells("PrecioVenta1").Value = "0.00"
      'End If

      'If Decimal.Parse(dr.Cells("PrecioVenta").Value.ToString()) <> Decimal.Parse(dr.Cells("PrecioVenta1").Value.ToString()) Then
      '   Return True
      'End If

      Dim prec As Decimal
      For Each lp As Entidades.ListaDePrecios In Me._listas
         'Al ponerlo en negativo, fuerzo que la primera vez que hago precios para una lista nueva, inserte los registros aunque sea en cero.
         prec = -12345  '0
         If Not String.IsNullOrEmpty(dr.Cells(lp.NombreListaPrecios).Value.ToString()) Then
            prec = Decimal.Parse(dr.Cells(lp.NombreListaPrecios).Value.ToString())
         End If
         If prec <> Decimal.Parse(dr.Cells(lp.NombreListaPrecios + "1").Value.ToString()) Then
            Return True
         End If
      Next
      Return False
   End Function

   Private Function ValidarCalcular() As Boolean

      'If String.IsNullOrEmpty(Me.txtPorcenFabrica.Text.Trim()) Then
      '   MessageBox.Show("El Porcentaje de Compra es Inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '   Me.txtPorcPrecioCosto.Focus()
      '   Return False
      'End If

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
      For Each drl As DataGridViewRow In Me.dgvPrecios.Rows
         If Boolean.Parse(drl.Cells("Sel").Value.ToString()) Then
            cantSelec += 1
         End If
      Next
      'si son distintos estos valores es porque selecciono solo algunos de los registros
      If cantSelec <> Me.dgvPrecios.Rows.Count Then
         todos = False
      End If

      If Me._filtroMultiplesMarcas.Filtros.Count = 0 And Me._filtroMultiplesRubros.Filtros.Count = 0 And Not Me.chbSubRubro.Checked And _
         Not Me.chbProducto.Checked And Not Me.chbProveedor.Checked And Not Me.chbFechaActualizado.Checked And _
         Not Me.chbSinCosto.Checked And Not Me.chbSinVenta.Checked And Me.cboCompuestos.SelectedIndex = 0 And _
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
         'Envio a grabar los nuevos precios
         oProdSucu.ModificarPrecios(Me._precios, IdFuncion)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

   Private _cargandoAutomaticamentePorcentajes As Boolean = False
   Private Sub btnDescuentoRecargoPorc_Click(sender As Object, e As EventArgs) Handles btnDescuentoRecargoPorc1.Click, btnDescuentoRecargoPorc2.Click, btnDescuentoRecargoPorc3.Click, btnDescuentoRecargoPorc4.Click, btnDescuentoRecargoPorc5.Click, btnDescuentoRecargoPorc6.Click
      Try
         If TypeOf (sender) Is Control Then
            If DirectCast(sender, Control).Tag IsNot Nothing AndAlso
               Not String.IsNullOrWhiteSpace(DirectCast(sender, Control).Tag.ToString()) Then
               Dim campo As String
               campo = DirectCast(sender, Control).Tag.ToString()
               Dim descrec As Decimal

               If campo.StartsWith("DescuentoRecargoPorc1") AndAlso IsNumeric(txtDescuentoRecargoPorc1.Text) Then
                  descrec = Decimal.Parse(txtDescuentoRecargoPorc1.Text)
               ElseIf campo.StartsWith("DescuentoRecargoPorc2") AndAlso IsNumeric(txtDescuentoRecargoPorc2.Text) Then
                  descrec = Decimal.Parse(txtDescuentoRecargoPorc2.Text)
               ElseIf campo.StartsWith("DescuentoRecargoPorc3") AndAlso IsNumeric(txtDescuentoRecargoPorc3.Text) Then
                  descrec = Decimal.Parse(txtDescuentoRecargoPorc3.Text)
               ElseIf campo.StartsWith("DescuentoRecargoPorc4") AndAlso IsNumeric(txtDescuentoRecargoPorc4.Text) Then
                  descrec = Decimal.Parse(txtDescuentoRecargoPorc4.Text)
               ElseIf campo.StartsWith("DescuentoRecargoPorc5") AndAlso IsNumeric(txtDescuentoRecargoPorc5.Text) Then
                  descrec = Decimal.Parse(txtDescuentoRecargoPorc5.Text)
               ElseIf campo.StartsWith("DescuentoRecargoPorc6") AndAlso IsNumeric(txtDescuentoRecargoPorc6.Text) Then
                  descrec = Decimal.Parse(txtDescuentoRecargoPorc6.Text)
               Else
                  descrec = 0
               End If

               Try
                  _cargandoAutomaticamentePorcentajes = True
                  If dgvPrecios.Columns.Contains(campo) Then
                     If ShowPregunta(String.Format("¿Desea aplicar {0:N2} al {1} de todos los productos seleccionados?",
                                                   descrec, dgvPrecios.Columns(campo).HeaderText)) = Windows.Forms.DialogResult.Yes Then
                        For Each dr As DataGridViewRow In dgvPrecios.Rows
                           If Boolean.Parse(dr.Cells("Sel").Value.ToString()) Then
                              dr.Cells(campo).Value = descrec
                              dgvPrecios_CellEndEdit(dgvPrecios, New DataGridViewCellEventArgs(dgvPrecios.Columns(campo).Index, dr.Index))
                           End If
                        Next
                     End If
                  End If
               Finally
                  _cargandoAutomaticamentePorcentajes = False
               End Try
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtDescuentoRecargoPorc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuentoRecargoPorc6.KeyDown, txtDescuentoRecargoPorc5.KeyDown, txtDescuentoRecargoPorc4.KeyDown, txtDescuentoRecargoPorc3.KeyDown, txtDescuentoRecargoPorc2.KeyDown, txtDescuentoRecargoPorc1.KeyDown
      PresionarTab(e)
   End Sub

   Private _comprasProductos As List(Of Entidades.MovimientoStockProducto)
   Private _categoriaFiscalProveedor As Entidades.CategoriaFiscal
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Public Overloads Function ShowDialog(cp As List(Of Entidades.MovimientoStockProducto), categoriaFiscalProveedor As Entidades.CategoriaFiscal) As DialogResult
      If cp Is Nothing OrElse cp.Count = 0 Then Return Windows.Forms.DialogResult.OK
      _comprasProductos = cp
      _categoriaFiscalProveedor = categoriaFiscalProveedor
      _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
      'Como está viniendo de una pantalla que va a predefinir la búsqueda, no permite refrescar para no perder esa búsqueda predefinida.
      tsbRefrescar.Visible = False
      tsbImportarExcel.Visible = False
      ToolStripSeparator1.Visible = False
      ToolStripSeparator4.Visible = False
      Return ShowDialog()
   End Function

   Private _cambiando As Boolean = False
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
End Class