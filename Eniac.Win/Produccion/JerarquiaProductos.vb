Public Class JerarquiaProductos

#Region "Campos"

   Private _publicos As Publicos
   Private _Componentes As DataTable
   Private _divideTamano As Boolean = False

   Private _idProducto As String
   Private _idFormula As Integer
   Private _pedidosProductosFormulasActual As DataTable
   Private _filtroMultiplesRubros As MFRubros
   Private _filtroMultiplesMarcas As MFMarcas
#End Region

   Public ReadOnly Property Componentes As DataTable
      Get
         Return _Componentes
      End Get
   End Property

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      _publicos = New Publicos()

      _divideTamano = Reglas.Publicos.ProduccionDivideTamano

      cmbRubro.Inicializar(False, True, True)
      cmbMarca.Inicializar(False, True, True)
      CargaComboFormulaTurismo()

      Me.LeerPreferencias()

      If Not String.IsNullOrWhiteSpace(_idProducto) Then
         bscCodigoProducto2.Text = _idProducto
         bscCodigoProducto2.PresionarBoton()
         tstBarra.Visible = False
         btnAceptar.Visible = True
         'btnCancelar.Visible = True
         cmbFormulas.SelectedValue = _idFormula
         cmbFormulas.Enabled = False
      End If

   End Sub

   Public Overloads Function ShowDialog(idProducto As String, idFormula As Integer, pedidosProductosFormulasActual As DataTable) As DialogResult
      _idProducto = idProducto
      _idFormula = idFormula
      _pedidosProductosFormulasActual = pedidosProductosFormulasActual
      Return ShowDialog()
   End Function

#End Region

#Region "Eventos"

   Private Sub FormulasABM_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      ElseIf e.KeyCode = Keys.F4 Then
         btnAceptar.PerformClick()
         e.Handled = True
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbModificarFormulaGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabarFormula.Click

      Try
         If GrabarFormula() Then
            MessageBox.Show("Se actualizaron los datos correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Refrescar()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
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

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
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
            Me.CargarDatosProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCopiar_CheckedChanged(sender As Object, e As EventArgs) Handles chbCopiar.CheckedChanged

      Me.bscCopiarCodigoProducto2.Permitido = Me.chbCopiar.Checked
      Me.bscCopiarNombreProducto2.Permitido = Me.chbCopiar.Checked

      'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
      If Not Me.chbCopiar.Checked Then

         Me.bscCopiarCodigoProducto2.Text = String.Empty
         Me.bscCopiarNombreProducto2.Text = String.Empty
      Else
         Me.tsbGrabarFormula.Enabled = False
         Me.tsbAgregarFormula.Enabled = True
         '' ''Me.tsbAgregarFormula.Enabled = False
      End If

      Me.bscCopiarCodigoProducto2.Focus()

   End Sub

   Private Sub bscCopiarCodigoProducto2_BuscadorClick() Handles bscCopiarCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCopiarCodigoProducto2)
         Me.bscCopiarCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCopiarCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCopiarCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCopiarCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then

            If e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim() = Me.bscCodigoProducto2.Text.Trim() Then
               MessageBox.Show("El Producto a Copiar NO puede coincidir con el Actual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.bscCopiarCodigoProducto2.Text = ""
               Me.bscCopiarCodigoProducto2.Focus()
               Exit Sub
            End If

            Me.CargarProductoCopiado(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCopiarNombreProducto2_BuscadorClick() Handles bscCopiarNombreProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCopiarNombreProducto2)
         Me.bscCopiarNombreProducto2.Datos = oProductos.GetPorNombre(Me.bscCopiarNombreProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCopiarNombreProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCopiarNombreProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then

            If e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim() = Me.bscCodigoProducto2.Text.Trim() Then
               MessageBox.Show("El Producto a Copiar NO puede coincidir con el Actual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.bscCopiarNombreProducto2.Text = ""
               Me.bscCopiarNombreProducto2.Focus()
               Exit Sub
            End If

            Me.CargarProductoCopiado(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnCopiar_Click(sender As Object, e As EventArgs)
      Try

         Me.CargarProductos()

         Me.CargarComponentes(Me.bscCodigoProducto2.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnAgregarComponente_Click(sender As Object, e As EventArgs) Handles btnAgregarComponente.Click
      Try
         'Me.tsbGrabar.Enabled = True

         Me.AgregarComponente()
         Me._Componentes.AcceptChanges()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminarComponente_Click(sender As Object, e As EventArgs) Handles btnEliminarComponente.Click
      Try
         If Me.dgvComponentes.Selected.Rows.Count = 0 Then
            MessageBox.Show("No ha seleccionado ninguna fila, por favor, seleccione la fila completa.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If Me.dgvComponentes.ActiveCell IsNot Nothing Then
            Me.dgvComponentes.ActiveRow = Me.dgvComponentes.ActiveCell.Row
         End If
         If Me.dgvComponentes.ActiveCell IsNot Nothing Or Me.dgvComponentes.ActiveRow IsNot Nothing Then
            Me.dgvComponentes.DeleteSelectedRows(True)

            Me._Componentes = DirectCast(Me.dgvComponentes.DataSource, DataTable)

            Me._Componentes.AcceptChanges()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbAgregarFormula_Click(sender As Object, e As EventArgs) Handles tsbAgregarFormula.Click
      Try

         If MessageBox.Show(String.Format("Antes de agregar una nueva formula, se deben guardar los cambios que haya realizado a la formula {0}. ¿Desea guardar la formula actual y agregar una nueva formula?", cmbFormulas.Text),
                            Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Exit Sub
         Else
            If Not GrabarFormula() Then
               Return
            End If
         End If

         Dim agregar As AgregarFormula = New AgregarFormula(Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         agregar.ShowDialog()

         Me.CargarComponentes(Me.bscCodigoProducto2.Text)

         Me.btnAgregarComponente.Enabled = True
         Me.tsbGrabarFormula.Enabled = True
         Me.tsbAgregarFormula.Enabled = True
         Me.tsbModificarFormula.Enabled = True
         Me.tsbEliminarFormula.Enabled = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbEliminarFormula_Click(sender As Object, e As EventArgs) Handles tsbEliminarFormula.Click
      Try
         If MessageBox.Show("¿Desea eliminar la fórmula seleccionada?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
            Dim prodform As Reglas.ProductosFormulas = New Reglas.ProductosFormulas()
            prodform.EliminarFormula(Me.bscCodigoProducto2.Text, Integer.Parse(Me.cmbFormulas.SelectedIndex.ToString()) + 1)
            MessageBox.Show("Se eliminó la formula seleccionada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.cmbFormulas.DataSource = New Reglas.ProductosComponentes().GetFormulas(actual.Sucursal.IdSucursal, Me.bscCodigoProducto2.Text)
            'Me.cmbFormulas.Update()
            'Me._publicos.CargaComboFormulasDeProductos(Me.cmbFormulas, Me.bscCodigoProducto2.Text)
            'CargaComboFormulaTurismo()
            If Me.cmbFormulas.Items.Count > 0 Then
               Me.cmbFormulas.SelectedIndex = 0
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub cmbFormulas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormulas.SelectedIndexChanged
      Try
         Dim IdFormula As Integer = -1
         Dim oComponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
         Dim idListaDePrecios As Integer = 0
         'If Me._Componentes IsNot Nothing Then
         '   If Me._Componentes.Rows.Count <> 0 Then
         '      Me._Componentes = ocomponentes.GetComponentes(actual.Sucursal.IdSucursal, Me.bscCodigoProducto2.Text, Integer.Parse(Me.cmbFormulas.SelectedValue.ToString()), idListaDePrecios)
         '      Me.dgvComponentes.DataSource = Me._Componentes
         '   End If
         'End If

         If cmbFormulas.SelectedIndex = 0 Then
            IdFormula = Eniac.Reglas.Publicos.TurismoFormulaVisitasID
         Else
            IdFormula = Eniac.Reglas.Publicos.TurismoFormulaGastronomiaID
         End If

         If Me.chbCopiar.Checked Then
            Me._Componentes = oComponentes.GetComponentes(actual.Sucursal.IdSucursal, Me.bscCopiarCodigoProducto2.Text, IdFormula, idListaDePrecios)
         Else
            Me._Componentes = oComponentes.GetComponentes(actual.Sucursal.IdSucursal, Me.bscCodigoProducto2.Text, IdFormula, idListaDePrecios)
         End If
         If _pedidosProductosFormulasActual IsNot Nothing Then
            TomaValoresComponenteDesdeActual()
         End If

         Me.dgvComponentes.DataSource = Me._Componentes

         Me.FormatearGrillaComponentes()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbCopiarFormula_Click(sender As Object, e As EventArgs)
      Try
         Dim agregar As AgregarFormula = New AgregarFormula(Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         agregar.ShowDialog()

         Me.CargarComponentes(Me.bscCodigoProducto2.Text)

         Me.btnAgregarComponente.Enabled = True
         Me.tsbGrabarFormula.Enabled = True
         Me.tsbAgregarFormula.Enabled = True
         Me.tsbModificarFormula.Enabled = True
         Me.tsbEliminarFormula.Enabled = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbModificarFormula_Click(sender As Object, e As EventArgs) Handles tsbModificarFormula.Click
      Try
         Dim modificar As ModificarFormula = New ModificarFormula(Me.bscCodigoProducto2.Text, Me.bscProducto2.Text,
                                                                  Integer.Parse(Me.cmbFormulas.SelectedValue.ToString()),
                                                                  Me.cmbFormulas.Text.ToString())
         modificar.ShowDialog()

         Me.CargarComponentes(Me.bscCodigoProducto2.Text)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"

   Protected Overridable Sub LeerPreferencias()
      Try

         Ayudante.Grilla.AgregarFiltroEnLinea(Me.dgvProductos, {"IdProducto", "NombreProducto"})

         Dim nameProd As String = Me.dgvProductos.FindForm().Name + "ProductosGrid.xml"
         Dim nameComp As String = Me.dgvComponentes.FindForm().Name + "ComponentesGrid.xml"

         If System.IO.File.Exists(nameProd) Then
            Me.dgvProductos.DisplayLayout.LoadFromXml(nameProd)
         End If

         If System.IO.File.Exists(nameComp) Then
            Me.dgvComponentes.DisplayLayout.LoadFromXml(nameComp)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub Refrescar()

      Me.bscCodigoProducto2.Text = ""
      Me.bscProducto2.Text = ""
      Me.bscCodigoProducto2.Enabled = True
      Me.bscProducto2.Enabled = True
      Me.tsbEliminarFormula.Enabled = False
      Me.tsbModificarFormula.Enabled = False
      Me.tsbGrabarFormula.Enabled = False
      Me.tsbAgregarFormula.Enabled = False
      Me.chbCopiar.Enabled = False
      Me.chbCopiar.Checked = False

      Me.btnAgregarComponente.Enabled = False
      Me.btnEliminarComponente.Enabled = False

      Me.dgvProductos.Enabled = False

      If Not Me.dgvProductos.DataSource Is Nothing Then
         DirectCast(Me.dgvProductos.DataSource, DataTable).Rows.Clear()
      End If

      Me.dgvComponentes.Enabled = False

      If Not Me.dgvComponentes.DataSource Is Nothing Then
         DirectCast(Me.dgvComponentes.DataSource, DataTable).Rows.Clear()
      End If
      Me.cmbFormulas.Enabled = False
      Me.cmbFormulas.DataSource = Nothing

      Me.bscCodigoProducto2.Focus()

      cmbRubro.Refrescar()
      cmbMarca.Refrescar()

   End Sub

   Private Sub CargarDatosProducto(dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

      Me.chbCopiar.Enabled = True

      Me.tsbModificarFormula.Enabled = True
      Me.tsbEliminarFormula.Enabled = True

      'Me.CargarProductos()

      'Me.CargarComponentes(Me.bscCodigoProducto2.Text)

   End Sub

   Private Sub CargarProductoCopiado(dr As DataGridViewRow)

      Me.bscCopiarNombreProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCopiarCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      Me.bscCopiarNombreProducto2.Permitido = False
      Me.bscCopiarCodigoProducto2.Permitido = False

      Dim agregar As CopiarFormula = New CopiarFormula(Me.bscCopiarCodigoProducto2.Text, Me.bscCopiarNombreProducto2.Text, Me.bscCodigoProducto2.Text)
      agregar.ShowDialog()

      Me.CargarComponentes(Me.bscCodigoProducto2.Text)

      Me.btnAgregarComponente.Enabled = True
      Me.tsbGrabarFormula.Enabled = True
      Me.tsbAgregarFormula.Enabled = True
      Me.tsbModificarFormula.Enabled = True
      Me.tsbEliminarFormula.Enabled = True
      Me.chbCopiar.Checked = False

      Me.dgvComponentes.Focus()

   End Sub

   Private Sub CargarProductos()

      Try
         Me.dgvProductos.Enabled = True

         Me.btnAgregarComponente.Enabled = True
         Me.btnEliminarComponente.Enabled = True

         Me.dgvComponentes.Enabled = True

         Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros(True)
         Dim marcas As Entidades.Marca() = cmbMarca.GetMarcas(True)

         'Carga grilla Productos
         Dim oproductos As Reglas.Productos = New Reglas.Productos()
         Dim dt As DataTable

         dt = oproductos.GetProductosGrillaFiltroMultipleMarcaRubroSubrubro(actual.Sucursal.IdSucursal, "", cmbMarca.GetMarcas(True),
                                  cmbRubro.GetRubros(True), 0, idProducto:=String.Empty)

         Me.dgvProductos.DataSource = dt
         Me.FormatearGrillaProductos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try


   End Sub

   Private Sub TomaValoresComponenteDesdeActual()
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
   End Sub

   Private Sub CargarComponentes(IdProducto As String)

      'Carga grilla de Componentes Productos

      Try

         Dim oComponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()
         Dim IdFormula As Integer
         Dim idListaDePrecios As Integer = 0    'Lista Base
         Me.cmbFormulas.Enabled = True

         ' Me._publicos.CargaComboFormulasDeProductos(Me.cmbFormulas, IdProducto)
         Dim Formulas As DataTable = New Reglas.ProductosFormulas().GetFormulas(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal, IdProducto)
         ' Me.CargaComboFormulaTurismo()

         'If Me.cmbFormulas.Items.Count > 0 Then
         '   Dim oProducto As Entidades.Producto = New Reglas.Productos().GetUno(IdProducto)
         '   Me.cmbFormulas.SelectedIndex = oProducto.IdFormula 'Si esta NULL viene en cero y al no encontrar elemento queda en -1
         '   If Me.cmbFormulas.SelectedIndex = -1 Then
         Me.cmbFormulas.SelectedIndex = 0
         '   End If
         'End If

         If Formulas.Rows.Count > 0 Then

            If cmbFormulas.SelectedIndex = 0 Then
               IdFormula = Eniac.Reglas.Publicos.TurismoFormulaVisitasID
            Else
               IdFormula = Eniac.Reglas.Publicos.TurismoFormulaGastronomiaID
            End If

            Me._Componentes = oComponentes.GetComponentes(actual.Sucursal.IdSucursal, IdProducto, IdFormula, idListaDePrecios)
            If _pedidosProductosFormulasActual IsNot Nothing Then
               TomaValoresComponenteDesdeActual()
            End If

            Me.tsbGrabarFormula.Enabled = True
            Me.tsbAgregarFormula.Enabled = True

            Me.dgvComponentes.DataSource = Me._Componentes

            Me.FormatearGrillaComponentes()

         Else
            Dim prodform As Reglas.ProductosFormulas = New Reglas.ProductosFormulas()
            prodform.GrabarFormula(IdProducto, Eniac.Reglas.Publicos.TurismoFormulaVisitasID, Eniac.Reglas.Publicos.TurismoFormulaVisitas, PorcentajeGanancia:=0)
            prodform.GrabarFormula(IdProducto, Eniac.Reglas.Publicos.TurismoFormulaGastronomiaID, Eniac.Reglas.Publicos.TurismoFormulaGastronomia, PorcentajeGanancia:=0)

            '  Me._publicos.CargaComboFormulasDeProductos(Me.cmbFormulas, IdProducto)
            ' Me.CargaComboFormulaTurismo()
            Me.cmbFormulas.SelectedIndex = 0
            Me.tsbGrabarFormula.Enabled = True
            Me.tsbAgregarFormula.Enabled = True
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub CargaComboFormulaTurismo()
      Me.cmbFormulas.Items.Insert(0, Eniac.Reglas.Publicos.TurismoFormulaVisitas)
      Me.cmbFormulas.Items.Insert(1, Eniac.Reglas.Publicos.TurismoFormulaGastronomia)
      Me.cmbFormulas.SelectedIndex = 0
   End Sub
   Private Sub AgregarComponente()
      If Me.dgvProductos.ActiveCell IsNot Nothing Then
         Me.dgvProductos.ActiveRow = Me.dgvProductos.ActiveCell.Row
      End If
      If Me.dgvProductos.ActiveCell IsNot Nothing Or Me.dgvProductos.ActiveRow IsNot Nothing Then
         For Each dg As UltraGridRow In Me.dgvProductos.Selected.Rows
            If Me._Componentes.Select("IdProductoComponente = '" & dg.Cells("IdProducto").Value.ToString() + "'").Length = 0 Then
               If Me.CompIgualProducto(dg.Cells("IdProducto").Value.ToString()) Then
                  MessageBox.Show("El producto no puede ser componente de si mismo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Dim dr As DataRow = Me._Componentes.NewRow()
               dr("IdProductoComponente") = dg.Cells("IdProducto").Value
               dr("NombreProducto") = dg.Cells("NombreProducto").Value
               dr("IdUnidadDeMedida") = dg.Cells("IdUnidadDeMedida").Value
               dr("PrecioCosto") = dg.Cells("PrecioCosto").Value
               dr("PrecioCostoSinIVA") = dg.Cells("PrecioCostoSinIVA").Value
               dr("PrecioCostoConIVA") = dg.Cells("PrecioCostoConIVA").Value
               dr("NombreMoneda") = dg.Cells("NombreMoneda").Value
               dr("FactorConversion") = dg.Cells("FactorConversion").Value
               dr("Simbolo") = dg.Cells("Simbolo").Value
               dr("Tamano") = dg.Cells("Tamano").Value
               dr("SegunCalculoForma") = False
               dr("Cantidad") = 1
               'dr("DescuentaAlFacturar") = "False"

               dr("PrecioVenta") = dg.Cells("PrecioVenta").Value
               dr("PrecioVentaSinIVA") = dg.Cells("PrecioVentaSinIVA").Value
               dr("PrecioVentaConIVA") = dg.Cells("PrecioVentaConIVA").Value
               dr("ComponenteAgregado") = True

               Me._Componentes.Rows.Add(dr)

            Else
               MessageBox.Show("El componente ya esta existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

         Next

         Me.dgvComponentes.DataSource = Me._Componentes

         Me.FormatearGrillaComponentes()
      End If

      Me.FormatearGrillaProductos()


   End Sub

   Private Function CompIgualProducto(idProducto As String) As Boolean

      If Me._Componentes.GetChanges(DataRowState.Unchanged) IsNot Nothing Then
         For Each dr As DataRow In Me._Componentes.GetChanges(DataRowState.Unchanged).Rows
            If Me.bscCodigoProducto2.Text = idProducto Then
               Return True
            End If
         Next
      End If

      If Me._Componentes.GetChanges(DataRowState.Added) IsNot Nothing Then
         For Each dr As DataRow In Me._Componentes.GetChanges(DataRowState.Added).Rows
            If Me.bscCodigoProducto2.Text = idProducto Then
               Return True
            End If
         Next
      End If

      Return False

   End Function

   Private Function GrabarFormula() As Boolean
      If Me.cmbFormulas.Items.Count = 0 Then
         MessageBox.Show("Debe ingresar al menos una Fórmula", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbFormulas.Focus()
         Return False
      End If

      Dim IdProducto As String
      IdProducto = Me.bscCodigoProducto2.Text
      Dim reg As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()

      Dim idFormula As Integer
      If cmbFormulas.SelectedIndex = 0 Then
         idFormula = Eniac.Reglas.Publicos.TurismoFormulaVisitasID
      Else
         idFormula = Eniac.Reglas.Publicos.TurismoFormulaGastronomiaID
      End If
      'For Each dr As UltraGridRow In Me.dgvComponentes.Rows
      '   If String.IsNullOrEmpty(dr.Cells("Cantidad").Value.ToString()) OrElse Decimal.Parse(dr.Cells("Cantidad").Value.ToString()) = 0 Then
      '      MessageBox.Show("Debe Ingresar la cantidad en el Producto: " + dr.Cells("NombreProducto").Value.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '      Return False
      '   End If
      'Next

      Me._Componentes.AcceptChanges()

      reg.GrabarComponentesProductos(IdProducto, idFormula, Me._Componentes, False)

      Dim prodsuc As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()

      Dim oprod As Reglas.Productos = New Reglas.Productos()
      Dim oformulas As Reglas.ProductosFormulas = New Reglas.ProductosFormulas()
      Dim formulas As DataTable = oformulas.GetFormulas(actual.Sucursal.IdSucursal, IdProducto)
      If formulas.Rows.Count = 1 Then
         For Each dr As DataRow In formulas.Rows
            oprod.ProductoFormulaDefecto(IdProducto, Integer.Parse(dr("IdFormula").ToString()))
         Next
      End If
      Return True
   End Function

   Private Sub FormatearGrillaProductos()
      With Me.dgvProductos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         Ayudante.Grilla.FormatearColumna(.Columns("IdProducto"), "Código", col, 100)
         Ayudante.Grilla.FormatearColumna(.Columns("NombreProducto"), "Producto", col, 200)
         Ayudante.Grilla.FormatearColumna(.Columns("Tamano"), "Tamaño", col, 50, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("IdUnidadDeMedida"), "Unidad Med.", col, 45, , True)
         Ayudante.Grilla.FormatearColumna(.Columns("PrecioCosto"), "PrecioCosto", col, 100, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("NombreRubro"), "Rubro", col, 150)
         Ayudante.Grilla.FormatearColumna(.Columns("NombreSubRubro"), "SubRubro", col, 150)
         Ayudante.Grilla.FormatearColumna(.Columns("NombreMarca"), "Marca", col, 200)
         Ayudante.Grilla.FormatearColumna(.Columns("NombreMoneda"), "Moneda", col, 50, , True)
         Ayudante.Grilla.FormatearColumna(.Columns("FactorConversion"), "Factor Conversion", col, 100, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("Simbolo"), "M.", col, 30, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("PrecioVenta"), "Precio Venta", col, 100, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("PrecioVentaConIVA"), "Precio Venta", col, 100, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("PrecioVentaSinIVA"), "Precio Venta", col, 100, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("PrecioCostoConIVA"), "PrecioCosto", col, 100, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("PrecioCostoSinIVA"), "PrecioCosto", col, 100, HAlign.Center, True)
      End With
      Me.LeerPreferencias()

   End Sub

   Private Sub FormatearGrillaComponentes()
      With Me.dgvComponentes.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next

         Dim col As Integer = 0
         Ayudante.Grilla.FormatearColumna(.Columns("IdProductoComponente"), "Cod. Componente", col, 80, , False)
         Ayudante.Grilla.FormatearColumna(.Columns("NombreProducto"), "Componente", col, 300, , False)
         Ayudante.Grilla.FormatearColumna(.Columns("IdUnidadDeMedida"), "U. Med.", col, 40, , True)
         Ayudante.Grilla.FormatearColumna(.Columns("PrecioCosto"), "Precio Costo", col, 80, HAlign.Right, True)
         Ayudante.Grilla.FormatearColumna(.Columns("NombreMoneda"), "Moneda", col, 50, HAlign.Left, True)
         Ayudante.Grilla.FormatearColumna(.Columns("Simbolo"), "M.", col, 30, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("Cantidad"), "Cantidad", col, 72, HAlign.Right, True, , , Activation.AllowEdit)
         Ayudante.Grilla.FormatearColumna(.Columns("IdMoneda"), "Moneda", col, 100, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("PrecioVenta"), "Precio Venta", col, 100, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("IdProducto"), "Producto", col, 100, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("FactorConversion"), "Factor Conversion", col, 100, HAlign.Center, True)
         Ayudante.Grilla.FormatearColumna(.Columns("Tamano"), "Tamaño", col, 60, HAlign.Right, True)
         Ayudante.Grilla.FormatearColumna(.Columns("CostoLinea"), "Costo", col, 60, HAlign.Right, True)
         Ayudante.Grilla.FormatearColumna(.Columns("SegunCalculoForma"), "Según Cálculo", col, 60, HAlign.Center, True, , , Activation.AllowEdit)
      End With
      Me.LeerPreferencias()

   End Sub


#End Region

   Private Sub dgvComponentes_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles dgvComponentes.AfterCellUpdate
      Try
         If e.Cell.Column.Key = "Cantidad" And e.Cell.Row.ListObject IsNot Nothing Then

            If e.Cell.Value Is Nothing Or e.Cell.Value Is System.DBNull.Value Then
               e.Cell.Value = "0.0000"
            End If

         Else

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnPreferenciasProductos_Click(sender As Object, e As EventArgs) Handles btnPreferenciasProductos.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.dgvProductos, True)
         pre.SufijoXML = "Productos"
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnPreferenciasComponentes_Click(sender As Object, e As EventArgs) Handles btnPreferenciasComponentes.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.dgvComponentes, True)
         pre.SufijoXML = "Componentes"
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvComponentes_CellChange(sender As Object, e As CellEventArgs) Handles dgvComponentes.CellChange
      Try
         dgvComponentes.UpdateData()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Try
         DialogResult = Windows.Forms.DialogResult.Cancel
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try

         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         If cmbRubro.SelectedIndex > -1 Then
            Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   'Private Sub cmbMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
   '   Try
   '      CargarProductos()
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   'Private Sub cmbRubro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.SelectedIndexChanged
   '   Try
   '      CargarProductos()
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      Try
         Me.CargarProductos()
         Me.CargarComponentes(Me.bscCodigoProducto2.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class