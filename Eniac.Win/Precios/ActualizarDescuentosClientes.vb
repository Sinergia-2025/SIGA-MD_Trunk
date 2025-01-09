Option Strict On
Option Explicit On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ActualizarDescuentosClientes

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(compuesto As Compuesto, buscaYCalculaAutomaticamente As Boolean)
      Me.New()
      Me._compuesto = compuesto
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
   Private _filtroMultiplesMarcas As MFMarcas
   Private _filtroMultiplesRubros As MFRubros
   Private _DecimalesEnPrecio As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio
   Private _estacargando As Boolean = False
   Private _calcular As Boolean = False
   Private _compuesto As Compuesto = Compuesto.TODOS
   Private _buscaYCalcula As Boolean = False
   Private _actualizarPreciosMostrarCodigoProductoProveedor As Boolean

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._filtroMultiplesMarcas = New MFMarcas()
         Me._filtroMultiplesRubros = New MFRubros()

         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)
         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))

         _actualizarPreciosMostrarCodigoProductoProveedor = Reglas.Publicos.ActualizarPreciosMostrarCodigoProductoProveedor

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         '   Me.CargaListasDePrecios()

         Me.cboCompuestos.Items.Insert(0, Compuesto.TODOS.ToString())
         Me.cboCompuestos.Items.Insert(1, Compuesto.SI.ToString())
         Me.cboCompuestos.Items.Insert(2, Compuesto.NO.ToString())
         'Me.cboCompuestos.SelectedIndex = 0

         Me.cboCompuestos.Text = Me._compuesto.ToString()

         Me.cmbEsOferta.SelectedIndex = 0

         If Not Reglas.Publicos.TieneModuloProduccion Then
            Me.lblCompuestos.Visible = False
            Me.cboCompuestos.Visible = False
         End If

         Me.tsbGrabar.Enabled = False

         txtCodigoProductoProveedor.Visible = _actualizarPreciosMostrarCodigoProductoProveedor
         txtCodigoProductoProveedor.LabelAsoc.Visible = txtCodigoProductoProveedor.Visible

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      If Me._buscaYCalcula Then
         Me.tsbRefrescar.Visible = False
         Me.ToolStripSeparator1.Visible = False
         Me.btnBuscar.PerformClick()
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
         Case Keys.F11
            Me.tbcDetalle.SelectedTab = Me.TbpFiltros
            Me.btnBuscar.Focus()
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
         If MessageBox.Show("Usted esta por actualizar los descuentos del Cliente. Esta seguro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.BarraInicializa("Preparando grabación de datos...", 0, Me.dgvPrecios.Rows.Count)
            Me.Cursor = Cursors.WaitCursor
            Me.dgvPrecios.Update()
            Me.dgvPrecios.CommitEdit(DataGridViewDataErrorContexts.Display)
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

   Private Sub txtRedondeoPrecioVenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Me.PresionarTab(e)
   End Sub

   Private Sub dgvListasPrecios_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs)
      If e.Value Is Nothing Then
         e.Value = "0.00"
      End If
   End Sub


   Private Sub dgvListasPrecios_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
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

         Me._estacargando = True

         Me.Cursor = Cursors.WaitCursor

         Me.tssInfo.Text = "Buscando registros..."
         Application.DoEvents()

         Me.CargaGrillaDetalle()

         Me.tssInfo.Text = ""
         Application.DoEvents()

         Me._estacargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tssRegistros.Text = "0 Registros"
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvPrecios_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrecios.CellEndEdit

      Try
         If Me.dgvPrecios.Columns(e.ColumnIndex).HeaderText = "Nuevo D/R 1" Or Me.dgvPrecios.Columns(e.ColumnIndex).HeaderText = "Nuevo D/R 2" Then
            Me.tsbGrabar.Enabled = True
            Dim dec As Decimal = 0
            If Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
               If Not Me.dgvPrecios.Columns(e.ColumnIndex).Name = "Sel" Then
                  Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
               End If
            End If
            If Decimal.TryParse(Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), dec) Then
               Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dec.ToString("0.00")
            Else
               Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
            End If
         End If


         'If e.RowIndex > -1 Then
         '   Dim Dbl As Double = 0
         '   Dim precioCosto As Decimal, precioCostoNuevo As Decimal, precioVenta As Decimal

         '   If Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
         '      If Not Me.dgvPrecios.Columns(e.ColumnIndex).Name = "Sel" Then
         '         Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
         '      End If

         '   End If

         '   If Me.dgvPrecios.Columns(e.ColumnIndex).HeaderText = "Nuevo D/R 1" Or Me.dgvPrecios.Columns(e.ColumnIndex).HeaderText = "Nuevo D/R 2" Then

         '      If Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("IdProveedor").Value.ToString()) Then

         '         If Double.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) > -100.0 And Double.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) < 100.0 Then

         '            If dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value IsNot Nothing AndAlso
         '               Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value.ToString()) Then
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value) / 100)).ToString("N2")
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value), 2).ToString("N2")
         '            End If
         '            If dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value IsNot Nothing AndAlso
         '               Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value.ToString()) Then
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value) / 100)).ToString("N2")
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value), 2).ToString("N2")
         '            End If
         '            If dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value IsNot Nothing AndAlso
         '               Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value.ToString()) Then
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value) / 100)).ToString("N2")
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value), 2).ToString("N2")
         '            End If
         '            If dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value IsNot Nothing AndAlso
         '               Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value.ToString()) Then
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value) / 100)).ToString("N2")
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value), 2).ToString("N2")
         '            End If

         '            Dim IdProducto As String = Me.dgvPrecios.Rows(e.RowIndex).Cells("IdProducto").Value.ToString.Trim()

         '            precioCosto = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto").Value.ToString())
         '            precioCostoNuevo = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value.ToString())

         '            For Each lis As Entidades.ListaDePrecios In Me._listas
         '               'Obtener el nuevo precio de venta y setearlo a la grilla
         '               precioVenta = 0

         '               'If lis.IdListaPrecios = 0 Then
         '               '   lis.NombreListaPrecios = "PrecioVenta"
         '               'End If

         '               If Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString() <> "" Then
         '                  precioVenta = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString())
         '               End If
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios + "1").Value = Me.GetPrecioVentaNuevo(IdProducto, precioCosto, precioCostoNuevo, precioVenta, lis.IdListaPrecios)
         '            Next

         '         Else
         '            If Not _cargandoAutomaticamentePorcentajes Then
         '               MessageBox.Show("El porcentaje no es correcto!. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '            End If
         '            Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
         '         End If
         '      Else
         '         If Not _cargandoAutomaticamentePorcentajes Then
         '            MessageBox.Show("El producto no tiene proveedor!. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '         End If
         '         Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
         '      End If
         '   ElseIf dgvPrecios.Columns(e.ColumnIndex).Name.Equals("PrecioCosto1") OrElse
         '          dgvPrecios.Columns(e.ColumnIndex).Name.Equals("PrecioFabrica1") Then

         '      If Double.TryParse(Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), Dbl) AndAlso _
         '         Double.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) >= 0 Then

         '         Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Dbl.ToString("N" + Me._DecimalesEnPrecio.ToString())

         '         'Si digito el Precio de Costo lo cambio en aquellas listas que correspondan.

         '         If Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "PrecioCosto1" Then

         '            Dim IdProducto As String = String.Empty

         '            If Me.dgvPrecios.Rows(e.RowIndex).Cells("IdProducto").Value IsNot Nothing Then
         '               IdProducto = Me.dgvPrecios.Rows(e.RowIndex).Cells("IdProducto").Value.ToString.Trim()
         '            Else
         '               Exit Sub
         '            End If

         '            precioCosto = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto").Value.ToString())
         '            precioCostoNuevo = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value.ToString())

         '            'dr.Cells("PrecioVenta1").Value = Me.GetPrecioVentaNuevo(precioCosto, precioCostoNuevo, precioVenta, 0)

         '            For Each lis As Entidades.ListaDePrecios In Me._listas
         '               'Obtener el nuevo precio de venta y setearlo a la grilla
         '               precioVenta = 0

         '               'If lis.IdListaPrecios = 0 Then
         '               '   lis.NombreListaPrecios = "PrecioVenta"
         '               'End If

         '               If Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString() <> "" Then
         '                  precioVenta = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString())
         '               End If
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios + "1").Value = Me.GetPrecioVentaNuevo(IdProducto, precioCosto, precioCostoNuevo, precioVenta, lis.IdListaPrecios)
         '            Next

         '         Else
         '            Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioFabrica1").Value

         '            Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioFabrica1").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioFabrica1").Value), 2).ToString("N2")

         '            If Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value.ToString()) Then
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value) / 100)).ToString("N2")
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc11").Value), 2).ToString("N2")
         '            End If
         '            If Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value.ToString()) Then
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value) / 100)).ToString("N2")
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc21").Value), 2).ToString("N2")
         '            End If
         '            If Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value.ToString()) Then
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value) / 100)).ToString("N2")
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc31").Value), 2).ToString("N2")
         '            End If
         '            If Not String.IsNullOrEmpty(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value.ToString()) Then
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) + (CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value) * CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value) / 100)).ToString("N2")
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("DescuentoRecargoPorc41").Value), 2).ToString("N2")
         '            End If

         '            Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value = Math.Round(CDec(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value), 2).ToString("N2")

         '            Dim IdProducto As String = Me.dgvPrecios.Rows(e.RowIndex).Cells("IdProducto").Value.ToString.Trim()

         '            precioCosto = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto").Value.ToString())
         '            precioCostoNuevo = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells("PrecioCosto1").Value.ToString())

         '            For Each lis As Entidades.ListaDePrecios In Me._listas
         '               'Obtener el nuevo precio de venta y setearlo a la grilla
         '               precioVenta = 0

         '               'If lis.IdListaPrecios = 0 Then
         '               '   lis.NombreListaPrecios = "PrecioVenta"
         '               'End If

         '               If Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString() <> "" Then
         '                  precioVenta = Decimal.Parse(Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios).Value.ToString())
         '               End If
         '               Me.dgvPrecios.Rows(e.RowIndex).Cells(lis.NombreListaPrecios + "1").Value = Me.GetPrecioVentaNuevo(IdProducto, precioCosto, precioCostoNuevo, precioVenta, lis.IdListaPrecios)
         '            Next

         '         End If
         '      Else
         '         If Not _cargandoAutomaticamentePorcentajes Then
         '            MessageBox.Show("El valor ingresado es inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '         End If
         '         Me.dgvPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0.00"
         '      End If
         '   End If

         'End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub


   Private Sub dgvPrecios_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles dgvPrecios.CellValueNeeded
      If e.Value Is Nothing Then
         e.Value = "0.00"
      End If
   End Sub

   Private Sub txtPrecioCostoPorc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Me.PresionarTab(e)
   End Sub

   Private Sub txtPrecioCostoMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      Me.PresionarTab(e)
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

#End Region

#Region "Metodos"


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

   Private Sub RefrescarDatos()

      Me.tsbGrabar.Enabled = False

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

      Me.cboCompuestos.SelectedIndex = 0

      Me.cmbEsOferta.SelectedIndex = 0

      If Not Me.dgvPrecios.DataSource Is Nothing Then
         DirectCast(Me.dgvPrecios.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtCodigo.Text = ""
      Me.txtProducto.Text = ""

      Me.bscCliente.Text = ""
      Me.bscCliente.Tag = Nothing
      bscCodigoCliente.Tag = Nothing
      Me.bscCodigoCliente.Text = ""
      Me.bscCliente.Permitido = True
      Me.bscCodigoCliente.Permitido = True

      Me.tssRegistros.Text = " 0 Registros"

      Me.txtDescuentoRecargoPorc1.Text = "0.00"
      Me.txtDescuentoRecargoPorc2.Text = "0.00"

      Me.PosibilitaOrdenarGrilla(True)

      Me.tbcDetalle.SelectedTab = Me.TbpFiltros

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False
      Me.btnBuscar_Click(Me.btnBuscar, New EventArgs())
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

      Dim IdSubRubro As Integer = 0
      Dim IdProducto As String = ""
      Dim IdProveedor As Long = 0
      Dim EsOferta As String
      Dim idCliente As Long = 0

      If Me.chbSubRubro.Checked Then
         IdSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
      End If

      If Me.chbProducto.Checked Then
         IdProducto = Me.bscCodigoProducto2.Text
         If String.IsNullOrEmpty(IdProducto) Then
            MessageBox.Show("Activo el filtro por producto pero no selecciono ninguno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If
      End If

      If Me.chbProveedor.Checked Then
         If Me.bscCodigoProveedor.Text.Length > 0 Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If
         If IdProveedor = 0 Then
            MessageBox.Show("Activo el filtro por proveedor pero no selecciono ninguno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If
      End If

      EsOferta = Me.cmbEsOferta.Text

      Me.dgvPrecios.Columns.Clear()

      If Me.bscCodigoCliente.Tag IsNot Nothing Then
         Long.TryParse(Me.bscCodigoCliente.Tag.ToString(), idCliente)
      End If

      If idCliente = 0 Then
         MessageBox.Show("Debe seleccionar un cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Exit Sub
      End If

      Me._productosAActualizar = New Reglas.Productos().GetProductoParaAplicarDescuentosClientes(idCliente,
                                                                                                 Me._filtroMultiplesMarcas.Filtros, _
                                                                                 Me._filtroMultiplesRubros.Filtros, _
                                                                                 IdSubRubro, _
                                                                                 IdProducto, _
                                                                                 IdProveedor, _
                                                                                 Me.cboCompuestos.Text, _
                                                                                txtCodigo.Text.Trim(), txtProducto.Text.Trim(),
                                                                                 Me.chbProveedorHabitual.Checked, EsOferta,
                                                                                 txtCodigoProductoProveedor.Text)

      Me.dgvPrecios.DataSource = Me._productosAActualizar

      Me.tssRegistros.Text = Me.dgvPrecios.Rows.Count.ToString() & " Registros"
      Me.tsbGrabar.Enabled = False

      Me.AgregarSeleccion()

      Me.FormatearGrilla()

      Me.dgvPrecios.Columns("NombreProducto").Frozen = True

      Me.PosibilitaOrdenarGrilla(True)

   End Sub

   Private Sub AgregarSeleccion()
     
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
      

   End Sub

   Private Sub FormatearGrilla()

      Me.dgvPrecios.Columns("IdProducto").HeaderText = "Cod. Prod."
      Me.dgvPrecios.Columns("IdProducto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("IdProducto").Width = 100
      Me.dgvPrecios.Columns("IdProducto").ReadOnly = True

      Me.dgvPrecios.Columns("CodigoProductoProveedor").HeaderText = "Cod. Prod. Proveedor"
      Me.dgvPrecios.Columns("CodigoProductoProveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("CodigoProductoProveedor").Width = 100
      Me.dgvPrecios.Columns("CodigoProductoProveedor").ReadOnly = True

      Me.dgvPrecios.Columns("CodigoProductoProveedor").Visible = _actualizarPreciosMostrarCodigoProductoProveedor

      Me.dgvPrecios.Columns("NombreProducto").HeaderText = "Producto"
      Me.dgvPrecios.Columns("NombreProducto").Width = 200 '310
      Me.dgvPrecios.Columns("NombreProducto").ReadOnly = True

      Me.dgvPrecios.Columns("NombreMarca").HeaderText = "Marca"
      Me.dgvPrecios.Columns("NombreMarca").Width = 120
      Me.dgvPrecios.Columns("NombreMarca").ReadOnly = True

      Me.dgvPrecios.Columns("NombreRubro").HeaderText = "Rubro"
      Me.dgvPrecios.Columns("NombreRubro").Width = 120
      Me.dgvPrecios.Columns("NombreRubro").ReadOnly = True

      Me.dgvPrecios.Columns("EsOferta").HeaderText = "Oferta"
      Me.dgvPrecios.Columns("EsOferta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      Me.dgvPrecios.Columns("EsOferta").Width = 40
      Me.dgvPrecios.Columns("EsOferta").ReadOnly = True

      'Me.dgvPrecios.Columns("NombreProveedor").HeaderText = "Prov. Habitual"
      'Me.dgvPrecios.Columns("NombreProveedor").ReadOnly = True
      'Me.dgvPrecios.Columns("NombreProveedor").Width = 124
      'Me.dgvPrecios.Columns("NombreProveedor").Visible = Publicos.UtilizaPrecioDeCompra

      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").HeaderText = "D/R 1"
      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").ReadOnly = True
      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").Width = 65
      Me.dgvPrecios.Columns("DescuentoRecargoPorc1").DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()

      Dim colDR1 As DataGridViewColumn = New DataGridViewColumn(Me.dgvPrecios.Columns("DescuentoRecargoPorc1").CellTemplate)
      colDR1.Name = "DescuentoRecargoPorc11"
      colDR1.HeaderText = "Nuevo D/R 1"
      colDR1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      colDR1.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
      colDR1.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      colDR1.Width = 65
      Me.dgvPrecios.Columns.Insert(Me.dgvPrecios.Columns("DescuentoRecargoPorc1").Index + 1, colDR1)
      Me.dgvPrecios.Columns(colDR1.Name).ReadOnly = False


      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").HeaderText = "D/R 2"
      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").ReadOnly = True
      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").Width = 65
      Me.dgvPrecios.Columns("DescuentoRecargoPorc2").DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()

      Dim colDR2 As DataGridViewColumn = New DataGridViewColumn(Me.dgvPrecios.Columns("DescuentoRecargoPorc2").CellTemplate)
      colDR2.Name = "DescuentoRecargoPorc21"
      colDR2.HeaderText = "Nuevo D/R 2"
      colDR2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      colDR2.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(224, 224, 224)
      colDR2.DefaultCellStyle.Format = "N" + Me._DecimalesEnPrecio.ToString()
      colDR2.Width = 65
      Me.dgvPrecios.Columns.Insert(Me.dgvPrecios.Columns("DescuentoRecargoPorc2").Index + 1, colDR2)
      Me.dgvPrecios.Columns(colDR2.Name).ReadOnly = False

      Me.dgvPrecios.Columns("UltimoProv").Visible = False


   End Sub

   Private _todosLosProductos As DataTable


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

   Private Sub CargarYGrabarPrecios()

      Dim idCliente As Long = 0
      Dim descuentos As List(Of Entidades.ClienteDescuentoProducto)
      Dim desc As Entidades.ClienteDescuentoProducto
      Dim cant As Integer = 0

      Long.TryParse(Me.bscCodigoCliente.Tag.ToString(), idCliente)


      Me.tssInfo.Text = "Cargando datos..."

      descuentos = New List(Of Entidades.ClienteDescuentoProducto)()

      Me.tssInfo.Text = "Procesando..."
      For Each dr As DataGridViewRow In Me.dgvPrecios.Rows

         'If Boolean.Parse(dr.Cells("Sel").Value.ToString()) Then
         If dr.Cells("DescuentoRecargoPorc11").Value IsNot Nothing Or dr.Cells("DescuentoRecargoPorc21").Value IsNot Nothing Then
            cant += 1
            desc = New Entidades.ClienteDescuentoProducto()

            desc.IdCliente = idCliente
            desc.IdProducto = dr.Cells("IdProducto").Value.ToString()
            If dr.Cells("DescuentoRecargoPorc11").Value IsNot Nothing Then
               Decimal.TryParse(dr.Cells("DescuentoRecargoPorc11").Value.ToString(), desc.DescuentoRecargoPorc1)
            End If
            If dr.Cells("DescuentoRecargoPorc21").Value IsNot Nothing Then
               Decimal.TryParse(dr.Cells("DescuentoRecargoPorc21").Value.ToString(), desc.DescuentoRecargoPorc2)
            End If

            Me.tssInfo.Text = "Terminando el calculo..."
            Application.DoEvents()

            descuentos.Add(desc)

            Me.tspBarra.Value += 1
            Application.DoEvents()

         End If

      Next

      Me.Cursor = Cursors.WaitCursor

      Me.tssInfo.Text = "Aguarde, se estan grabando los nuevos descuentos..."
      Application.DoEvents()

      Dim reg As Reglas.ClientesDescuentosProductos = New Reglas.ClientesDescuentosProductos()

      reg.GrabarClientesDescuentosProductos2(idCliente, descuentos)

      Me.tssInfo.Text = ""

      If cant > 0 Then
         MessageBox.Show("Descuentos grabados con exito!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.CargaGrillaDetalle()
      Else
         MessageBox.Show("No se selecciono ningun descuento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

   End Sub

#End Region

   Private _cargandoAutomaticamentePorcentajes As Boolean = False
   Private Sub btnDescuentoRecargoPorc_Click(sender As Object, e As EventArgs) Handles btnDescuentoRecargoPorc1.Click, btnDescuentoRecargoPorc2.Click
      Try
         Me.tsbGrabar.Enabled = True
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

   Private Sub txtDescuentoRecargoPorc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuentoRecargoPorc2.KeyDown, txtDescuentoRecargoPorc1.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Permitido = False
      Me.bscCodigoCliente.Permitido = False

      Me.btnBuscar.Focus()

   End Sub

End Class