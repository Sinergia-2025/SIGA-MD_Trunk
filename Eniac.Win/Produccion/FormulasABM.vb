Public Class FormulasABM

#Region "Campos"

   Private _publicos As Publicos
   Private _Componentes As DataTable
   Private _divideTamano As Boolean = False

   Private _idProducto As String
   Private _idFormula As Integer
   Private _pedidosProductosFormulasActual As DataTable
   Private _productosEstructura As IList(Of Entidades.ProductoArbol)
   Private _variables As Entidades.ProduccionFormasVariablesList
   Private _cotizacionDolar As Decimal


   Private _titProductos As Dictionary(Of String, String)
   Private _titComponentes As Dictionary(Of String, String)

#End Region

   Private _soloBuscaPorIdProducto As Boolean = False

   Public ReadOnly Property Componentes As DataTable
      Get
         Return _Componentes
      End Get
   End Property

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _divideTamano = Reglas.Publicos.ProduccionDivideTamano

            LeerPreferencias()

            _titProductos = GetColumnasVisiblesGrilla(dgvProductos)
            _titComponentes = GetColumnasVisiblesGrilla(dgvComponentes)

            If Not String.IsNullOrWhiteSpace(_idProducto) Then
               _soloBuscaPorIdProducto = True
               bscCodigoProducto2.Text = _idProducto
               bscCodigoProducto2.PresionarBoton()
               tstBarra.Visible = False
               btnAceptar.Visible = True
               'btnCancelar.Visible = True
               grpPrecios.Visible = False
               cmbFormulas.SelectedValue = _idFormula
               cmbFormulas.Enabled = False
            End If
         End Sub)
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      If Not String.IsNullOrWhiteSpace(bscCodigoProducto2.Text) Then
         bscCodigoProducto2.PresionarBoton()
      End If
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

   Public Overloads Function ShowDialog(idProducto As String, idFormula As Integer, productosEstructura As IList(Of Entidades.ProductoArbol),
                                        variables As Entidades.ProduccionFormasVariablesList, cotizacionDolar As Decimal) As DialogResult
      _productosEstructura = productosEstructura
      _variables = variables
      _cotizacionDolar = cotizacionDolar
      txtFactorConversion.SetValor(cotizacionDolar)
      Return ShowDialog(idProducto, idFormula)
   End Function

   Public Overloads Function ShowDialog(idProducto As String, idFormula As Integer, pedidosProductosFormulasActual As DataTable) As DialogResult
      _pedidosProductosFormulasActual = pedidosProductosFormulasActual
      Return ShowDialog(idProducto, idFormula)
   End Function

   Public Overloads Function ShowDialog(idProducto As String, idFormula As Integer) As DialogResult
      _idProducto = idProducto
      _idFormula = idFormula
      Return ShowDialog()
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() Refrescar())
   End Sub

   Private Sub tsbModificarFormulaGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabarFormula.Click
      TryCatched(
         Sub()
            If GrabarFormula() Then
               ShowMessage("Se actualizaron los datos correctamente.")
               Refrescar()
            End If
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
            bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", _soloBuscaPorIdProducto)
         End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscProducto2)
            bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
         End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub

   Private Sub chbCopiar_CheckedChanged(sender As Object, e As EventArgs) Handles chbCopiar.CheckedChanged
      TryCatched(
         Sub()
            bscCopiarCodigoProducto2.Permitido = chbCopiar.Checked
            bscCopiarNombreProducto2.Permitido = chbCopiar.Checked

            'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
            If Not chbCopiar.Checked Then

               bscCopiarCodigoProducto2.Text = String.Empty
               bscCopiarNombreProducto2.Text = String.Empty
            Else
               tsbGrabarFormula.Enabled = False
               tsbAgregarFormula.Enabled = True
            End If

            bscCopiarCodigoProducto2.Focus()
         End Sub)
   End Sub
   Private Sub bscCopiarCodigoProducto2_BuscadorClick() Handles bscCopiarCodigoProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCopiarCodigoProducto2)
            bscCopiarCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCopiarCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", True)
         End Sub)
   End Sub
   Private Sub bscCopiarNombreProducto2_BuscadorClick() Handles bscCopiarNombreProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCopiarNombreProducto2)
            bscCopiarNombreProducto2.Datos = New Reglas.Productos().GetPorNombre(bscCopiarNombreProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", True)
         End Sub)
   End Sub

   Private Sub bscCopiarCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCopiarCodigoProducto2.BuscadorSeleccion, bscCopiarNombreProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProductoCopiado(e.FilaDevuelta))
   End Sub

   Private Sub btnCopiar_Click(sender As Object, e As EventArgs)
      TryCatched(
         Sub()
            CargarProductos()
            CargarComponentes(bscCodigoProducto2.Text.Trim())
         End Sub)
   End Sub

   Private Sub btnAgregarComponente_Click(sender As Object, e As EventArgs) Handles btnAgregarComponente.Click
      TryCatched(Sub() AgregarComponente())
   End Sub

   Private Sub btnEliminarComponente_Click(sender As Object, e As EventArgs) Handles btnEliminarComponente.Click
      TryCatched(
         Sub()
            Dim rows = dgvComponentes.FilasSeleccionadasOActiva(Of DataRow)()
            If Not rows.AnySecure() Then
               ShowMessage("No ha seleccionado ninguna fila, por favor seleccione al menos una fila.")
               Exit Sub
            End If


            'If dgvComponentes.Selected.Rows.Count = 0 Then
            '   If dgvComponentes.ActiveRow Is Nothing Then
            '      ShowMessage("No ha seleccionado ninguna fila, por favor, seleccione la fila completa.")
            '      Exit Sub
            '   End If
            '   dgvComponentes.ActiveRow.Selected = True
            'End If

            If ShowPregunta(String.Format("Ha seleccionado {0} componentes para eliminar. ¿Desea eliminar los {0} componentes seleccionados?", rows.Count)) = DialogResult.Yes Then
               rows.ForEachSecure(Sub(dr) dr.Delete())
            End If
            _Componentes.AcceptChanges()
            dgvComponentes.RowsRefresh(RefreshRow.ReloadData)

            'dgvComponentes.DeleteSelectedRows(True)

            '_Componentes = DirectCast(dgvComponentes.DataSource, DataTable)
            '_Componentes.AcceptChanges()

            CalculoCosto()

            txtPrecioVenta.Text = txtPrecioCosto.Text
            RecaulcularPorcCostoProduccion()
         End Sub)
   End Sub

   Private Sub btnAplicaPrecioCosto_Click(sender As Object, e As EventArgs) Handles btnAplicaPrecioCosto.Click
      TryCatched(Sub() txtPrecioCostoAplicar.Enabled = False)
      If Decimal.Parse(txtPrecioVenta.Text.ToString()) <> 0 Then
         txtPorcentaje.Text = CalcularPorcentajeGanancia(Decimal.Parse(txtPrecioCostoAplicar.Text), Decimal.Parse(txtPrecioVenta.Text)).ToString()
      End If
   End Sub

   Private Sub btnAplicaPrecioVenta_Click(sender As Object, e As EventArgs) Handles btnAplicaPrecioVenta.Click
      TryCatched(Sub() txtPrecioVenta.Enabled = False)
      If Decimal.Parse(txtPrecioCosto.Text.ToString()) <> 0 Then
         txtPorcentaje.Text = CalcularPorcentajeGanancia(Decimal.Parse(txtPrecioCostoAplicar.Text), Decimal.Parse(txtPrecioVenta.Text)).ToString()
      End If
   End Sub

   Private Sub txtPorcentaje_Leave(sender As Object, e As EventArgs) Handles txtPorcentaje.Leave
      TryCatched(
         Sub()
            Dim precioventa = txtPrecioCostoAplicar.Text.ValorNumericoPorDefecto(0D) + (txtPrecioCostoAplicar.Text.ValorNumericoPorDefecto(0D) * txtPorcentaje.Text.ValorNumericoPorDefecto(0D) / 100)
            txtPrecioVenta.Text = precioventa.ToString("N2")
         End Sub)
   End Sub

   Private Sub tsbAgregarFormula_Click(sender As Object, e As EventArgs) Handles tsbAgregarFormula.Click
      TryCatched(
         Sub()
            If ShowPregunta(String.Format("Antes de agregar una nueva formula, se deben guardar los cambios que haya realizado a la formula {0}. ¿Desea guardar la formula actual y agregar una nueva formula?", cmbFormulas.Text)) = Windows.Forms.DialogResult.No Then
               Exit Sub
            Else
               If Not GrabarFormula() Then
                  Return
               End If
            End If

            Using agregar = New AgregarFormula(bscCodigoProducto2.Text, bscProducto2.Text)
               agregar.ShowDialog()
            End Using

            CargarComponentes(bscCodigoProducto2.Text)

            btnAgregarComponente.Enabled = True
            tsbGrabarFormula.Enabled = True
            tsbAgregarFormula.Enabled = True
            tsbModificarFormula.Enabled = True
            tsbEliminarFormula.Enabled = True
         End Sub)
   End Sub

   Private Sub tsbEliminarFormula_Click(sender As Object, e As EventArgs) Handles tsbEliminarFormula.Click
      TryCatched(
         Sub()
            If ShowPregunta("¿Desea eliminar la fórmula seleccionada?") = Windows.Forms.DialogResult.Yes Then
               Dim prodform = New Reglas.ProductosFormulas()
               prodform.EliminarFormula(bscCodigoProducto2.Text, cmbFormulas.ValorSeleccionado(Of Integer)())
               ShowMessage("Se eliminó la formula seleccionada.")

               _publicos.CargaComboFormulasDeProductos(cmbFormulas, bscCodigoProducto2.Text)
               If cmbFormulas.Items.Count > 0 Then
                  cmbFormulas.SelectedIndex = 0
               Else
                  tsbRefrescar.PerformClick()
               End If
            End If
         End Sub)
   End Sub

   Private Sub cmbFormulas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormulas.SelectedIndexChanged
      TryCatched(
         Sub()
            Dim idListaDePrecios = Reglas.Publicos.ListaPreciosPredeterminada
            Dim idFormula = cmbFormulas.ValorSeleccionado(cmbFormulas.SelectedIndex >= 0, -1I)
            Dim idProducto = If(chbCopiar.Checked, bscCopiarCodigoProducto2.Text, bscCodigoProducto2.Text)

            Dim rComponentes = New Reglas.ProductosComponentes()

            _Componentes = rComponentes.GetComponentes(actual.Sucursal.IdSucursal, idProducto, idFormula, idListaDePrecios)

            TomaValoresComponenteDesdeActual()

            CargaGrillaComponentes(_Componentes)

            If cmbFormulas.SelectedValue IsNot Nothing Then
               Dim formula As Entidades.ProductoFormula = New Reglas.ProductosFormulas().GetUna(idProducto,
                                                                                                       Integer.Parse(cmbFormulas.SelectedValue.ToString()))
               txtPorcentaje.Text = formula.PorcentajeGanancia.ToString("N2")
            End If

            'dgvComponentes.DataSource = _Componentes
            'HabilitaPrecios()
            'FormatearGrillaComponentes()
         End Sub)
   End Sub

   Private Sub tsbCopiarFormula_Click(sender As Object, e As EventArgs)
      TryCatched(
         Sub()
            Using agregar = New AgregarFormula(bscCodigoProducto2.Text, bscProducto2.Text)
               agregar.ShowDialog()
            End Using

            CargarComponentes(bscCodigoProducto2.Text)

            btnAgregarComponente.Enabled = True
            tsbGrabarFormula.Enabled = True
            tsbAgregarFormula.Enabled = True
            tsbModificarFormula.Enabled = True
            tsbEliminarFormula.Enabled = True
         End Sub)
   End Sub

   Private Sub tsbModificarFormula_Click(sender As Object, e As EventArgs) Handles tsbModificarFormula.Click
      TryCatched(
         Sub()
            Using modificar = New ModificarFormula(bscCodigoProducto2.Text, bscProducto2.Text, cmbFormulas.ValorSeleccionado(Of Integer), cmbFormulas.Text)
               modificar.ShowDialog()
            End Using

            CargarComponentes(bscCodigoProducto2.Text)
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Protected Overridable Sub LeerPreferencias()
      TryCatched(
         Sub()
            AgregarFiltroEnLinea(dgvProductos, {"IdProducto", "NombreProducto"})

            Dim nameProd As String = dgvProductos.FindForm().Name + "ProductosGrid.xml"
            Dim nameComp As String = dgvComponentes.FindForm().Name + "ComponentesGrid.xml"

            If IO.File.Exists(nameProd) Then
               dgvProductos.DisplayLayout.LoadFromXml(nameProd)
            End If

            If IO.File.Exists(nameComp) Then
               dgvComponentes.DisplayLayout.LoadFromXml(nameComp)
            End If
         End Sub)
   End Sub

   Private Sub Refrescar()

      bscCodigoProducto2.Text = ""
      bscProducto2.Text = ""
      bscCodigoProducto2.Permitido = True
      bscProducto2.Permitido = True
      tsbEliminarFormula.Enabled = False
      tsbModificarFormula.Enabled = False
      tsbGrabarFormula.Enabled = False
      tsbAgregarFormula.Enabled = False
      chbCopiar.Enabled = False
      chbCopiar.Checked = False

      btnAgregarComponente.Enabled = False
      btnEliminarComponente.Enabled = False

      txtPrecioCosto.Text = ""
      txtPrecioCostoAplicar.Text = ""
      txtPrecioVenta.Text = ""
      txtPrecioCostoAplicar.Enabled = True
      txtPrecioVenta.Enabled = True
      dgvProductos.Enabled = False
      txtPrecioCostoBase.Text = ""
      txtPrecioVentaBase.Text = ""
      txtPorcentaje.Text = "0.00"

      dgvProductos.ClearFilas()

      dgvComponentes.Enabled = False

      dgvComponentes.ClearFilas()
      HabilitaPrecios()

      cmbFormulas.Enabled = False
      cmbFormulas.DataSource = Nothing

      bscCodigoProducto2.Focus()

   End Sub

   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         If Not String.IsNullOrEmpty(dr.Cells("IdProcesoProductivoDefecto").Value.ToString()) Then
            ShowMessage("El producto Seleccionado posee Proceso Productivo asignado. No admite formula.")
            Exit Sub
         End If

         If dr IsNot Nothing Then
            bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
            bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
            chbDescontarStockComp.Checked = Boolean.Parse(dr.Cells("DescontarStockComponentes").Value.ToString())

            txtPrecioCostoBase.Text = dr.Cells("PrecioCosto").Value.ToString()
            txtPrecioVentaBase.Text = dr.Cells("PrecioVenta").Value.ToString()

            txtMoneda.Text = dr.Cells("NombreMoneda").Value.ToString()
            txtFactorConversion.Text = Decimal.Parse(dr.Cells("FactorConversion").Value.ToString()).ToString("#0.00")

            bscProducto2.Permitido = False
            bscCodigoProducto2.Permitido = False

            chbCopiar.Enabled = True

            tsbModificarFormula.Enabled = True
            tsbEliminarFormula.Enabled = True

            CargarProductos()

            CargarComponentes(bscCodigoProducto2.Text)

            'La primera vez va a encargar el campo desmarcado.
            If dgvComponentes.Rows.Count = 0 And Publicos.ProduccionDescStockComponentesFormulasFacturacion Then
               chbDescontarStockComp.Checked = True
            End If

         End If
      End If

   End Sub

   Private Sub CargarProductoCopiado(dr As DataGridViewRow)
      If dr IsNot Nothing Then

         If dr.Cells("IdProducto").Value.ToString.Trim() = bscCodigoProducto2.Text.Trim() Then
            ShowMessage("El Producto a Copiar NO puede coincidir con el Actual.")
            bscCopiarCodigoProducto2.Text = ""
            bscCopiarCodigoProducto2.Focus()
            Exit Sub
         End If

         bscCopiarNombreProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCopiarCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

         bscCopiarNombreProducto2.Permitido = False
         bscCopiarCodigoProducto2.Permitido = False

         Using frmCopiar = New CopiarFormula(bscCopiarCodigoProducto2.Text, bscCopiarNombreProducto2.Text, bscCodigoProducto2.Text)
            If frmCopiar.ShowDialog() = DialogResult.Cancel Then
               Exit Sub
            End If
         End Using

         CargarComponentes(bscCodigoProducto2.Text)

         btnAgregarComponente.Enabled = True
         tsbGrabarFormula.Enabled = True
         tsbAgregarFormula.Enabled = True
         tsbModificarFormula.Enabled = True
         tsbEliminarFormula.Enabled = True
         chbCopiar.Checked = False

         dgvComponentes.Focus()
      End If

   End Sub
   Private Function CalcularPorcentajeGanancia(PrecioCosto As Decimal, precioVenta As Decimal) As Decimal
      Dim Porcentaje As Decimal
      Porcentaje = Decimal.Round(((precioVenta - PrecioCosto) / PrecioCosto) * 100, 2)
      Return Porcentaje
   End Function
   Private Sub CargarProductos()
      dgvProductos.Enabled = True

      btnAgregarComponente.Enabled = True
      btnEliminarComponente.Enabled = True

      dgvComponentes.Enabled = True

      'Carga grilla Productos
      Dim oproductos = New Reglas.Productos()
      Dim dt = oproductos.GetProductosGrillaFiltroMarcaRubroSubrubro(actual.Sucursal.IdSucursal, "", 0, 0, 0, idProducto:=String.Empty)
      CargaGrillaProductos(dt)

   End Sub

   Private Sub CargaGrillaProductos(dt As DataTable)
      dgvProductos.DataSource = dt
      AjustarColumnasGrilla(dgvProductos, _titProductos)

   End Sub
   Private Sub CargaGrillaComponentes(dt As DataTable)
      dgvComponentes.DataSource = dt
      HabilitaPrecios()
      AjustarColumnasGrilla(dgvComponentes, _titComponentes)

   End Sub

   Private Sub TomaValoresComponenteDesdeActual()
      If _pedidosProductosFormulasActual IsNot Nothing Then
         For Each drActual As DataRow In _pedidosProductosFormulasActual.Rows
            Dim existe As Boolean = False
            For Each drComponente As DataRow In _Componentes.Select(String.Format("IdProductoComponente = '{0}'", drActual("IdProductoComponente")))
               For Each dc As DataColumn In _pedidosProductosFormulasActual.Columns
                  drComponente(dc.ColumnName) = drActual(dc.ColumnName)
               Next
               existe = True
            Next
            If Not existe And Boolean.Parse(drActual("ComponenteAgregado").ToString()) Then
               _Componentes.ImportRow(drActual)
            End If
         Next
      ElseIf _productosEstructura IsNot Nothing Then
         _Componentes.Clear()
         For Each drEstr In _productosEstructura

            Dim drComp = _Componentes.NewRow()
            drComp("IdProductoComponente") = drEstr.IdProducto
            drComp("NombreProducto") = drEstr.NombreProducto
            drComp("IdUnidadDeMedida") = drEstr.UnidadMedida
            drComp("PrecioCosto") = drEstr.ImporteCostoConImpuestos
            drComp("PrecioCostoSinIVA") = drEstr.PrecioSinImpuestos
            drComp("PrecioCostoConIVA") = drEstr.PrecioConImpuestos
            drComp("IdMoneda") = drEstr.IdMoneda
            drComp("NombreMoneda") = drEstr.Moneda
            drComp("FactorConversion") = 0
            drComp("Simbolo") = "$"
            drComp("Tamano") = 0D '"Tamano"
            drComp("SegunCalculoForma") = drEstr.CalculoForma
            drComp("FormulaCalculoKilaje") = drEstr.FormulaCalculoKilaje

            'dr("DescuentaAlFacturar") = "False"

            drComp("PrecioVenta") = drEstr.ImportePrecioConImpuestos
            drComp("PrecioVentaSinIVA") = drEstr.PrecioSinImpuestos
            drComp("PrecioVentaConIVA") = drEstr.PrecioConImpuestos
            drComp("ComponenteAgregado") = True
            drComp("PorcCostoProduccion") = 0D

            drComp("IdFormulaComponente") = drEstr.IdFormula
            drComp("NombreFormulaComponente") = drEstr.NombreFormula
            drComp("ComponenteEsCompuesto") = drEstr.IdFormula <> 0


            drComp("Cantidad") = drEstr.CantidadEnFormula

            _Componentes.Rows.Add(drComp)
            'Dim existe As Boolean = False


            'For Each drComponente In _Componentes.Where(Function(dr) dr.Field(Of String)("IdProductoComponente") = drEstr.IdProducto)





            '   For Each dc As DataColumn In _pedidosProductosFormulasActual.Columns
            '      drComponente(dc.ColumnName) = drEstr(dc.ColumnName)
            '   Next
            '   existe = True
            'Next
            'If Not existe And Boolean.Parse(drEstr("ComponenteAgregado").ToString()) Then
            '   _Componentes.ImportRow(drEstr)
            'End If
         Next

      End If
   End Sub

   Private Sub CargarComponentes(IdProducto As String)

      'Carga grilla de Componentes Productos

      Try

         Dim oComponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()

         Dim idListaDePrecios As Integer = Reglas.Publicos.ListaPreciosPredeterminada  ' 0    'Lista Base
         Me.cmbFormulas.Enabled = True

         Me._publicos.CargaComboFormulasDeProductos(Me.cmbFormulas, IdProducto)
         If Me.cmbFormulas.Items.Count > 0 Then
            Dim oProducto As Entidades.Producto = New Reglas.Productos().GetUno(IdProducto)
            Me.cmbFormulas.SelectedValue = oProducto.IdFormula 'Si esta NULL viene en cero y al no encontrar elemento queda en -1
            If Me.cmbFormulas.SelectedIndex = -1 Then
               Me.cmbFormulas.SelectedIndex = 0
            End If
         End If

         If Me.cmbFormulas.SelectedValue IsNot Nothing OrElse Me.cmbFormulas.Items.Count > 0 Then

            Me._Componentes = oComponentes.GetComponentes(actual.Sucursal.IdSucursal, IdProducto, Integer.Parse(Me.cmbFormulas.SelectedValue.ToString()), idListaDePrecios)
            TomaValoresComponenteDesdeActual()

            Me.CalculoCosto()

            Me.tsbGrabarFormula.Enabled = True
            Me.tsbAgregarFormula.Enabled = True
            Dim precioventa As Decimal = 0
            precioventa = Decimal.Parse(Me.txtPrecioCostoAplicar.Text) + (Decimal.Parse(Me.txtPrecioCostoAplicar.Text) * Decimal.Parse(Me.txtPorcentaje.Text) / 100)
            Me.txtPrecioVenta.Text = precioventa.ToString("#,###,##0.0000")

            CargaGrillaComponentes(_Componentes)

            RecaulcularPorcCostoProduccion()

            'Me.dgvComponentes.DataSource = Me._Componentes
            'HabilitaPrecios()
            'Me.FormatearGrillaComponentes()
         Else
            If Not Reglas.Publicos.ProduccionRecetaUnica Then
               MessageBox.Show("Debe Agregar una Formula.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.btnAgregarComponente.Enabled = False
               Me.tsbGrabarFormula.Enabled = False
               Me.tsbAgregarFormula.Enabled = True
               '' ''Me.tsbAgregarFormula.Enabled = True
               Me.tsbModificarFormula.Enabled = False
               Me.tsbEliminarFormula.Enabled = False
            Else
               Dim prodform As Reglas.ProductosFormulas = New Reglas.ProductosFormulas()
               prodform.GrabarFormula(IdProducto, 1, "Unica", Decimal.Parse(Me.txtPorcentaje.Text.ToString()))
               Me._publicos.CargaComboFormulasDeProductos(Me.cmbFormulas, IdProducto)
               Me.cmbFormulas.SelectedIndex = 0
               Me.tsbGrabarFormula.Enabled = True
               Me.tsbAgregarFormula.Enabled = True
            End If


         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub AgregarComponente()
      If dgvProductos.Selected.Rows.Count > 0 Then
         For Each dg In dgvProductos.Selected.Rows
            Dim drProductos = dg.FilaSeleccionada(Of DataRow)()
            If Not _Componentes.AsEnumerable().Any(Function(drComp) drComp.Field(Of String)("IdProductoComponente") = drProductos.Field(Of String)("IdProducto")) Then
               If CompIgualProducto(drProductos.Field(Of String)("IdProducto")) Then
                  ShowMessage("El producto no puede ser componente de si mismo")
                  Exit Sub
               End If

               Dim drComp = _Componentes.NewRow()
               drComp("IdProductoComponente") = drProductos("IdProducto")
               drComp("NombreProducto") = drProductos("NombreProducto")
               drComp("IdUnidadDeMedida") = drProductos("IdUnidadDeMedida")
               drComp("PrecioCosto") = drProductos("PrecioCosto")
               drComp("PrecioCostoSinIVA") = drProductos("PrecioCostoSinIVA")
               drComp("PrecioCostoConIVA") = drProductos("PrecioCostoConIVA")
               drComp("NombreMoneda") = drProductos("NombreMoneda")
               drComp("FactorConversion") = drProductos("FactorConversion")
               drComp("Simbolo") = drProductos("Simbolo")
               drComp("Tamano") = drProductos("Tamano")
               drComp("SegunCalculoForma") = False
               'dr("DescuentaAlFacturar") = "False"

               drComp("PrecioVenta") = drProductos("PrecioVenta")
               drComp("PrecioVentaSinIVA") = drProductos("PrecioVentaSinIVA")
               drComp("PrecioVentaConIVA") = drProductos("PrecioVentaConIVA")
               drComp("ComponenteAgregado") = True
               drComp("PorcCostoProduccion") = 0D

               drComp("IdFormulaComponente") = drProductos("IdFormula")
               drComp("NombreFormulaComponente") = drProductos("NombreFormula")
               drComp("ComponenteEsCompuesto") = drProductos("EsCompuesto")

               drComp("IdUnidadDeMedidaProduccion") = drProductos("IdUnidadDeMedidaProduccion")
               drComp("FactorConversionProduccion") = drProductos("FactorConversionProduccion")

               _Componentes.Rows.Add(drComp)

            Else
               ShowMessage("El componente ya esta existe")
               Exit Sub
            End If
         Next

         CargaGrillaComponentes(_Componentes)
         'dgvComponentes.DataSource = _Componentes
         'HabilitaPrecios()
         'FormatearGrillaComponentes()
      End If

      'FormatearGrillaProductos()
      _Componentes.AcceptChanges()
      RecaulcularPorcCostoProduccion()

   End Sub

   Private Sub RecaulcularPorcCostoProduccion()
      Dim total = _Componentes.AsEnumerable().Sum(Function(dr) dr.Field(Of Decimal?)("CostoLinea").IfNull())
      _Componentes.AsEnumerable().ToList().
            ForEach(Sub(dr) dr.SetField("PorcCostoProduccion", If(total = 0, 0, Math.Round(dr.Field(Of Decimal?)("CostoLinea").IfNull() / total * 100, 4))))
      _Componentes.AcceptChanges()
   End Sub

   Private Function CompIgualProducto(idProducto As String) As Boolean
      Return bscCodigoProducto2.Text = idProducto

      'If Me._Componentes.GetChanges(DataRowState.Unchanged) IsNot Nothing Then
      '   For Each dr As DataRow In Me._Componentes.GetChanges(DataRowState.Unchanged).Rows
      '      If Me.bscCodigoProducto2.Text = idProducto Then
      '         Return True
      '      End If
      '   Next
      'End If

      'If Me._Componentes.GetChanges(DataRowState.Added) IsNot Nothing Then
      '   For Each dr As DataRow In Me._Componentes.GetChanges(DataRowState.Added).Rows
      '      If Me.bscCodigoProducto2.Text = idProducto Then
      '         Return True
      '      End If
      '   Next
      'End If

      'Return False

   End Function

   Private Function GrabarFormulaEstructuraProducto() As Boolean
      If _productosEstructura IsNot Nothing Then

         For Each peBorrar In _productosEstructura.Where(Function(pe) Not _Componentes.AsEnumerable().Any(Function(drComp) drComp.Field(Of String)("IdProductoComponente") = pe.IdProducto)).ToList()
            _productosEstructura.Remove(peBorrar)
         Next

         For Each reg In _Componentes.AsEnumerable()
            Dim nodoHijo = _productosEstructura.FirstOrDefault(Function(pe) pe.IdProducto = reg.Field(Of String)("IdProductoComponente"))
            If nodoHijo Is Nothing Then

               If reg.Field(Of Integer?)("IdFormulaComponente").HasValue Then
                  Dim rEstructura = New Reglas.EstructuraProductos()

                  Dim a = rEstructura.CreaEstructura(reg.Field(Of String)("IdProductoComponente"), reg.Field(Of Integer?)("IdFormulaComponente").IfNull(),
                                                     Reglas.Publicos.ListaPreciosPredeterminada,
                                                     1, True, _variables, moneda:=Entidades.Moneda.Peso, _cotizacionDolar)
                  nodoHijo = a(0)
               Else

                  nodoHijo = New Entidades.ProductoArbol()
                  With nodoHijo
                     .IdProducto = reg.Field(Of String)("IdProductoComponente")
                     .NombreProducto = reg.Field(Of String)("NombreProducto")
                     .UnidadMedida = reg.Field(Of String)("IdUnidadDeMedida")
                     .IdMoneda = reg.Field(Of Integer)("IdMoneda")
                     .Moneda = reg.Field(Of String)("NombreMoneda")

                     .CalculoForma = reg.Field(Of Boolean)("SegunCalculoForma")

                     .CostoConImpuestos = reg.Field(Of Decimal?)("PrecioCostoConIVA").IfNull()
                     .CostoSinImpuestos = reg.Field(Of Decimal?)("PrecioCostoSinIVA").IfNull()
                     .PrecioConImpuestos = reg.Field(Of Decimal?)("PrecioVentaConIVA").IfNull()
                     .PrecioSinImpuestos = reg.Field(Of Decimal?)("PrecioVentaSinIVA").IfNull()

                     .FormulaCalculoKilaje = reg.Field(Of String)("FormulaCalculoKilaje").IfNull()
                  End With
               End If
               _productosEstructura.Add(nodoHijo)
            End If

            nodoHijo.CantidadEnFormula = reg.Field(Of Decimal)("Cantidad")
            nodoHijo.IdFormula = reg.Field(Of Integer?)("IdFormulaComponente").IfNull()
            nodoHijo.NombreFormula = reg.Field(Of String)("NombreFormulaComponente").IfNull()
            '.Cantidad = .CantidadEnFormula * cantidad

         Next

         'For Each peDelete In _Componentes.AsEnumerable().Where(Function(drComp) drComp.Field(Of String)("IdProducto") = "")

         'Next
      End If
      Return True
   End Function

   Private Function GrabarFormula() As Boolean
      If Me.cmbFormulas.Items.Count = 0 Then
         MessageBox.Show("Debe ingresar al menos una Fórmula", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbFormulas.Focus()
         Return False
      End If

      ' Dim Porcentaje As Decimal = Decimal.Parse(Me.txtPorcentaje.Text)

      Dim IdProducto As String
      IdProducto = Me.bscCodigoProducto2.Text
      Dim reg As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
      Dim oformulas As Reglas.ProductosFormulas = New Reglas.ProductosFormulas()
      For Each dr As UltraGridRow In Me.dgvComponentes.Rows
         If dr.Cells("Cantidad").ValorAs(0D) = 0 Then
            ShowMessage(String.Format("Debe Ingresar la cantidad en el Producto: {0}", dr.Cells("NombreProducto").Value.ToString()))
            Return False
         End If
      Next

      If txtPrecioCostoAplicar.Visible And Me.txtPrecioCostoAplicar.Enabled Then
         If MessageBox.Show("Desea aplicar Precio de Costo? (debe presionar el botón).", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Return False
         End If
      End If

      If txtPrecioVenta.Visible And Me.txtPrecioVenta.Enabled Then
         If MessageBox.Show("Desea aplicar Precio de Venta? (debe presionar el botón).", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Return False
         End If
      End If

      Me._Componentes.AcceptChanges()

      reg.GrabarComponentesProductos(IdProducto, Integer.Parse(Me.cmbFormulas.SelectedValue.ToString()), Me._Componentes, Me.chbDescontarStockComp.Checked)

      Dim prodsuc As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()

      If txtPrecioCostoAplicar.Visible Then
         If Me.txtPrecioCostoAplicar.Enabled Then
            If Not Me.txtPrecioVenta.Enabled Then
               prodsuc.ActualizarPrecioCostoVenta(bscCodigoProducto2.Text,
                                                  actual.Sucursal.IdSucursal,
                                                  0,
                                                  Decimal.Parse(Me.txtPrecioVenta.Text))
            End If


         Else
            If Me.txtPrecioVenta.Enabled Then
               prodsuc.ActualizarPrecioCostoVenta(bscCodigoProducto2.Text,
                                                  actual.Sucursal.IdSucursal,
                                                  Decimal.Parse(Me.txtPrecioCostoAplicar.Text),
                                                  0)
            Else
               prodsuc.ActualizarPrecioCostoVenta(bscCodigoProducto2.Text, actual.Sucursal.IdSucursal,
                                                       Decimal.Parse(Me.txtPrecioCostoAplicar.Text),
                                                        Decimal.Parse(Me.txtPrecioVenta.Text))
            End If
         End If
      End If         'If txtPrecioCostoAplicar.Visible Then


      Dim oprod As Reglas.Productos = New Reglas.Productos()
      Dim formulas As DataTable = oformulas.GetFormulas(actual.Sucursal.IdSucursal, IdProducto)
      If formulas.Rows.Count = 1 Then
         For Each dr As DataRow In formulas.Rows
            oprod.ActualizarFormulaDefecto(IdProducto, Integer.Parse(dr("IdFormula").ToString()))
         Next
      End If

      'Actualizar porcentaje de Ganancia
      Dim costo As Decimal = Decimal.Parse(IIf(Me.txtPrecioCostoAplicar.Enabled, Me.txtPrecioCosto.Text, Me.txtPrecioCostoAplicar.Text).ToString())
      Dim venta As Decimal = Decimal.Parse(IIf(Me.txtPrecioVenta.Enabled, Me.txtPrecioVentaBase.Text, Me.txtPrecioVenta.Text).ToString())
      Dim Porcentaje As Decimal = CalcularPorcentajeGanancia(costo, venta)

      oformulas.ModificarFormula(IdProducto, Integer.Parse(Me.cmbFormulas.SelectedValue.ToString()), Me.cmbFormulas.Text, Porcentaje)

      Return True
   End Function

   'Private Sub FormatearGrillaProductos()
   '   With dgvProductos.DisplayLayout.Bands(0)
   '      Dim pos = 0I
   '      .Columns("IdProducto").FormatearColumna("Código", pos, 100)
   '      .Columns("NombreProducto").FormatearColumna("Producto", pos, 250)
   '      .Columns("Tamano").FormatearColumna("Tamaño", pos, 50, HAlign.Center, True)
   '      .Columns("IdUnidadDeMedida").FormatearColumna("Unidad Med.", pos, 45)
   '      .Columns("PrecioCosto").FormatearColumna("PrecioCosto", pos, 100, HAlign.Center, True)
   '      .Columns("NombreMarca").FormatearColumna("Marca", pos, 200)
   '      .Columns("NombreRubro").FormatearColumna("Rubro", pos, 200)
   '      .Columns("NombreMoneda").FormatearColumna("Moneda", pos, 50)
   '      .Columns("FactorConversion").FormatearColumna("Factor Conversion", pos, 100, HAlign.Center, True)
   '   End With
   '   LeerPreferencias()
   'End Sub

   'Private Sub FormatearGrillaComponentes()
   '   With dgvComponentes.DisplayLayout.Bands(0)
   '      For Each columna In .Columns
   '         columna.Hidden = True
   '      Next
   '      Dim pos = 0I
   '      .Columns("IdProductoComponente").FormatearColumna("Cod. Componente", pos, 80, , False)
   '      .Columns("NombreProducto").FormatearColumna("Componente", pos, 140, , False)
   '      .Columns("IdUnidadDeMedida").FormatearColumna("U. Med.", pos, 40, , False)
   '      .Columns("PrecioCosto").FormatearColumna("Precio Costo", pos, 80, HAlign.Right, False)
   '      .Columns("NombreMoneda").FormatearColumna("Moneda", pos, 50, HAlign.Left, True)
   '      .Columns("Simbolo").FormatearColumna("M.", pos, 30, HAlign.Center, False)
   '      .Columns("Cantidad").FormatearColumna("Cantidad", pos, 72, HAlign.Right, False, , , Activation.AllowEdit)
   '      .Columns("IdMoneda").FormatearColumna("Moneda", pos, 100, HAlign.Center, True)
   '      .Columns("PrecioVenta").FormatearColumna("Precio Venta", pos, 100, HAlign.Center, True)
   '      .Columns("IdProducto").FormatearColumna("Producto", pos, 100, HAlign.Center, True)
   '      .Columns("FactorConversion").FormatearColumna("Factor Conversion", pos, 100, HAlign.Center, True)
   '      .Columns("Tamano").FormatearColumna("Tamaño", pos, 60, HAlign.Right, True)
   '      .Columns("CostoLinea").FormatearColumna("Costo", pos, 60, HAlign.Right, False)
   '      .Columns("PorcCostoProduccion").FormatearColumna("% Costo Prod.", pos, 80, HAlign.Right, False)
   '      .Columns("SegunCalculoForma").FormatearColumna("Según Cálculo", pos, 60, HAlign.Center, False, , , Activation.AllowEdit)
   '   End With
   '   LeerPreferencias()
   'End Sub


#End Region

   Private Sub CalculoCosto()
      Dim regCal = New Reglas.PreciosCalculos()
      txtPrecioCosto.SetValor(regCal.GetPrecioCosto(_Componentes, _divideTamano, txtFactorConversion.ValorNumericoPorDefecto(0D)))
      txtPrecioCostoAplicar.Text = txtPrecioCosto.Text
   End Sub


   Private Sub dgvComponentes_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles dgvComponentes.AfterCellUpdate
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing AndAlso e.Cell.Column.Key = "CantidadUMProduccion" Then         'If e.Cell.Column.Key = "Cantidad" And e.Cell.Row.ListObject IsNot Nothing Then

            If e.Cell.Value Is Nothing Or e.Cell.Value Is System.DBNull.Value Then
               e.Cell.Value = "0.0000"
            End If

            dr("Cantidad") = dr.Field(Of Decimal)("CantidadUMProduccion") * dr.Field(Of Decimal)("FactorConversionProduccion")

            CalculoCosto()

            If txtPorcentaje.ValorNumericoPorDefecto(0D) <> 0 Then
               Dim precioventa = txtPrecioCostoAplicar.ValorNumericoPorDefecto(0D) * (1 + (txtPorcentaje.ValorNumericoPorDefecto(0D) / 100))
               txtPrecioVenta.SetValor(precioventa)
            Else
               txtPrecioVenta.Text = txtPrecioCosto.Text
            End If

            RecaulcularPorcCostoProduccion()

         Else

         End If
      End Sub)
   End Sub

   Private Sub btnPreferenciasProductos_Click(sender As Object, e As EventArgs) Handles btnPreferenciasProductos.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.dgvProductos, True)
         pre.SufijoXML = "Productos"
         pre.ShowDialog()
         _titProductos = GetColumnasVisiblesGrilla(dgvProductos)
         _titComponentes = GetColumnasVisiblesGrilla(dgvComponentes)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnPreferenciasComponentes_Click(sender As Object, e As EventArgs) Handles btnPreferenciasComponentes.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.dgvComponentes, True)
         pre.SufijoXML = "Componentes"
         pre.ShowDialog()
         _titProductos = GetColumnasVisiblesGrilla(dgvProductos)
         _titComponentes = GetColumnasVisiblesGrilla(dgvComponentes)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvComponentes_CellChange(sender As Object, e As CellEventArgs) Handles dgvComponentes.CellChange
      Try
         dgvComponentes.UpdateData()
         HabilitaPrecios()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub HabilitaPrecios()
      txtPrecioCostoAplicar.Visible = _Componentes IsNot Nothing AndAlso _Componentes.Select("SegunCalculoForma").Length = 0
      lblPrecioCostoAplicar.Visible = txtPrecioCostoAplicar.Visible
      txtPrecioVenta.Visible = txtPrecioCostoAplicar.Visible
      lblPrecioVenta.Visible = txtPrecioCostoAplicar.Visible
      lblPrecioVentaPorc.Visible = txtPrecioCostoAplicar.Visible
      txtPorcentaje.Visible = txtPrecioCostoAplicar.Visible
      btnAplicaPrecioCosto.Visible = txtPrecioCostoAplicar.Visible
      btnAplicaPrecioVenta.Visible = txtPrecioCostoAplicar.Visible
      Label10.Visible = txtPrecioCostoAplicar.Visible

      lblPrecioCalculadoEnVenta1.Visible = Not txtPrecioCostoAplicar.Visible
      lblPrecioCalculadoEnVenta2.Visible = Not txtPrecioCostoAplicar.Visible
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         If _pedidosProductosFormulasActual Is Nothing AndAlso _productosEstructura Is Nothing Then
            If GrabarFormula() Then
               Close(DialogResult.OK)
            End If
         Else
            If GrabarFormulaEstructuraProducto() Then
               Close(DialogResult.OK)
            End If
         End If
      End Sub)
   End Sub

   Private Sub dgvComponentes_ClickCellButton(sender As Object, e As CellEventArgs) Handles dgvComponentes.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Using frm = New FormulasDetalleComponente()
               frm.ShowDialog(Me, dr)
            End Using
            'ShowMessage(dr.Field(Of String)("NombreFormulaComponente"))
         End If
      End Sub)
   End Sub

   Private Sub dgvComponentes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvComponentes.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim cel = e.Row.Cells("NombreFormulaComponente")
            Dim esCompuesto = dr.Field(Of Boolean?)("ComponenteEsCompuesto").IfNull()
            cel.Activation = If(esCompuesto, Activation.ActivateOnly, Activation.Disabled)
            If Not esCompuesto Then
               cel.Color(Color.Black, Color.LightGray)
            End If
         End If
      End Sub)
   End Sub
End Class