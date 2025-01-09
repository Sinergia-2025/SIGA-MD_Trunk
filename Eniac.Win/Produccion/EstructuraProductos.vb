Imports System.Collections.ObjectModel

Public Class EstructuraProductos

#Region "Campos"

   Private _stateForm As StateForm = StateForm.Insertar

   Private _publicos As Publicos
   'Private _listaProductos As List(Of Entidades.ProduccionProducto)

   Private _MostrarCosto As Boolean

   Private _decimalesMostrarEnPrecio As Integer = 4
   Private _decimalesMostrarEnCantidad As Integer = 4

   Private _formatoMostrarEnPrecio As String = String.Format("N{0}", _decimalesMostrarEnPrecio)
   Private _formatoMostrarEnCantidad As String = String.Format("N{0}", _decimalesMostrarEnCantidad)

   Private _valoresFormulas As Entidades.ProduccionFormasVariablesList
   Private _cotizacionDolar As Decimal?

#End Region

   Private _valoresFormulasEdicion As Entidades.ProduccionFormasVariablesList
   Private _modeloFormaEdicion As Entidades.ProduccionModeloForma
   Private _listaEdicion As ObservableCollection(Of Entidades.ProductoArbol)
   Public ReadOnly Property GetRaizEditada() As Entidades.ProductoArbol
      Get
         Return _listaEdicion.FirstOrDefaultSecure()
      End Get
   End Property

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(Sub() _publicos.CargaComboProduccionModeloForma(cmbModeloForma))
      'Seguridad del campo Precio de Costo
      TryCatched(Sub() _MostrarCosto = New Reglas.Usuarios().TienePermisos("ConsultarPrecios-PrecioCosto"))
      ''-- Inicializa Valores.-
      TryCatched(Sub() If Not _cotizacionDolar.HasValue Then _cotizacionDolar = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion)
      TryCatched(Sub() _publicos.CargaComboMonedas1(cmbMonedaVenta))
      cmbMonedaVenta.SelectedValue = Reglas.Publicos.Facturacion.FacturacionMonedaPorDefecto

      Me.PreferenciasLeer(ugDetalle, tsbPreferencias)

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnConsultar.PerformClick()
         btnRecalcular.PerformClick()
      ElseIf keyData = Keys.F6 Then
         cmbFormulas.Focus()
      ElseIf keyData = Keys.F7 Then
         txtCantidad.Focus()
      ElseIf keyData = Keys.F8 Then
         ugVariables.Focus()
         ugVariables.IrPrimerCeldaEditable()
      ElseIf keyData = Keys.Escape Then
         If _listaEdicion IsNot Nothing Then
            btnCancelar.PerformClick()
            Close()
         End If
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      '-- Inicializa Valores.-
      TryCatched(Sub() Nuevo())
   End Sub

   Public Overloads Function ShowDialog(owner As IWin32Window, padre As Entidades.ProductoArbol,
                                        valoresFormulas As Entidades.ProduccionFormasVariablesList,
                                        modelo As Entidades.ProduccionModeloForma,
                                        cotizacionDolar As Decimal,
                                        stateForm As StateForm) As DialogResult
      Return ShowDialog(owner, New ObservableCollection(Of Entidades.ProductoArbol)({padre}), valoresFormulas, modelo, cotizacionDolar, stateForm)
   End Function
   Public Overloads Function ShowDialog(owner As IWin32Window, lst As ObservableCollection(Of Entidades.ProductoArbol),
                                        valoresFormulas As Entidades.ProduccionFormasVariablesList,
                                        modelo As Entidades.ProduccionModeloForma,
                                        cotizacionDolar As Decimal,
                                        stateForm As StateForm) As DialogResult
      Dim result = DialogResult.OK
      TryCatched(
      Sub()
         _stateForm = stateForm
         _listaEdicion = lst
         _valoresFormulasEdicion = valoresFormulas
         _modeloFormaEdicion = modelo
         _valoresFormulas = _valoresFormulasEdicion.ClonarColeccion()
         _cotizacionDolar = cotizacionDolar
         grpConsultar.Enabled = _stateForm = StateForm.Insertar
         grpConsultar.Visible = _stateForm = StateForm.Insertar

         'btnRecalcular.Visible = True
         pnlAceptarCancelar.Visible = _stateForm = StateForm.Actualizar
         ToolStrip1.Visible = _stateForm <> StateForm.Consultar
         ugVariables.DisplayLayout.Override.AllowUpdate = If(_stateForm = StateForm.Insertar, DefaultableBoolean.True, DefaultableBoolean.False)



      End Sub,
      accionAdicionalError:=Sub() result = DialogResult.Cancel)
      If result = DialogResult.OK Then
         Return ShowDialog(owner)
      Else
         Return DialogResult.Cancel
      End If
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() Nuevo())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

#End Region

#Region "Eventos Toolbar Secundaria"
   Private Sub tsbAgregarFormula_Click(sender As Object, e As EventArgs) Handles tsbAgregarFormula.Click
      TryCatched(Sub() AgregarNuevaFormula())
   End Sub
   Private Sub tsbModificarFormula_Click(sender As Object, e As EventArgs) Handles tsbModificarFormula.Click
      TryCatched(
         Sub()
            Dim idFormula = cmbFormulas.ValorSeleccionado(Of Integer)
            Using modificar = New ModificarFormula(bscCodigoProducto2.Text, bscProducto2.Text, idFormula, cmbFormulas.Text)
               If modificar.ShowDialog() = DialogResult.OK Then
                  _publicos.CargaComboFormulasDeProductos(cmbFormulas, bscCodigoProducto2.Text)
                  cmbFormulas.SelectedValue = idFormula
                  btnConsultar.PerformClick()
               End If
            End Using
         End Sub)
   End Sub
   Private Sub tsbModificarRegistroGrillaDetalle_Click(sender As Object, e As EventArgs) Handles tsbModificarRegistroGrillaDetalle.Click
      TryCatched(Sub() EditarFormula())
   End Sub
   Private Sub tsbEliminarFormula_Click(sender As Object, e As EventArgs) Handles tsbEliminarFormula.Click
      TryCatched(Sub() EliminarFormulaConPregunta())
   End Sub

#End Region

#Region "Eventos Buscadores Productos"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
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
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of Entidades.ProductoArbol)()
         If dr IsNot Nothing Then
            tsbModificarFormula.Enabled = dr.IdFormula > 0
            tsbModificarRegistroGrillaDetalle.Enabled = dr.IdFormula > 0
            tsbEliminarFormula.Enabled = dr.IdFormula > 0
         End If
      End Sub)
   End Sub


   Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
      If e.KeyChar = Convert.ToChar(Keys.Enter) Then
         btnConsultar.PerformClick()
      End If
   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      TryCatched(Sub() Nuevo())
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If ValidaConsulta() Then
            '-- Carga Niveles de Visualizacion de Grilla.-
            ugDetalle.DisplayLayout.MaxBandDepth = Integer.Parse(dudNivelesGrillas.Text.ToString)
            '-- Arma Estrucutura de Grilla.-
            Dim dtEstructura = CreateEstructura()
            '-- Formatea Grilla.-
            If dtEstructura.Count <> 0 Then
               SetDataSource(dtEstructura)
               Me.PreferenciasLeer(ugDetalle, tsbPreferencias)
            Else
               MessageBox.Show("El Producto no posee diseño de Estructura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Exit Sub
            End If
         End If
      End Sub)
   End Sub

   Private Sub btnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
      TryCatched(Sub() SetDataSource(New Reglas.EstructuraProductos().RecalculaCantidades(ugDetalle.DataSource(Of ObservableCollection(Of Entidades.ProductoArbol)), _valoresFormulas.ToList())))
   End Sub
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         _listaEdicion = ugDetalle.DataSource(Of ObservableCollection(Of Entidades.ProductoArbol))
         Close(DialogResult.OK)
      End Sub)
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(
      Sub()
         Close(DialogResult.Cancel)
      End Sub)
   End Sub

   Private Sub dudNivelesGrillas_GotFocus(sender As Object, e As EventArgs) Handles dudNivelesGrillas.GotFocus
      TryCatched(Sub() dudNivelesGrillas.Select(0, dudNivelesGrillas.Text.Length))
   End Sub

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      TryCatched(
      Sub()
         With ugDetalle.DisplayLayout.Bands(0)
            .Columns("PrecioConImpuestos").Hidden = Not _MostrarCosto OrElse Not chbConIVA.Checked
            .Columns("CostoConImpuestos").Hidden = Not _MostrarCosto OrElse Not chbConIVA.Checked

            .Columns("PrecioSinImpuestos").Hidden = Not _MostrarCosto OrElse chbConIVA.Checked
            .Columns("CostoSinImpuestos").Hidden = Not _MostrarCosto OrElse chbConIVA.Checked

            .Columns("ImportePrecioConImpuestos").Hidden = Not _MostrarCosto OrElse Not chbConIVA.Checked
            .Columns("ImporteCostoConImpuestos").Hidden = Not _MostrarCosto OrElse Not chbConIVA.Checked

            .Columns("ImportePrecioSinImpuestos").Hidden = Not _MostrarCosto OrElse chbConIVA.Checked
            .Columns("ImporteCostoSinImpuestos").Hidden = Not _MostrarCosto OrElse chbConIVA.Checked
         End With
         '--REQ-41767.- -------------
         btnConsultar.PerformClick()
         '---------------------------
      End Sub)
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Enabled = False
         bscCodigoProducto2.Enabled = False

         Dim idProducto = bscCodigoProducto2.Text.Trim()

         cmbFormulas.Enabled = True
         _publicos.CargaComboFormulasDeProductos(cmbFormulas, bscCodigoProducto2.Text)
         If cmbFormulas.Any() Then
            cmbFormulas.SelectedValue = New Reglas.Productos().GetUno(idProducto).IdFormula
            If cmbFormulas.SelectedIndex = -1 Then
               cmbFormulas.SelectedIndex = 0
            End If
            btnConsultar.Enabled = True
            btnConsultar.PerformClick()
         Else
            If ShowPregunta("Producto sin Fórmula. ¿Desea crear una?") = DialogResult.Yes Then
               If Not Reglas.Publicos.ProduccionRecetaUnica Then
                  Dim idFormula = AgregarNuevaFormula(idProducto, bscProducto2.Text)
                  _publicos.CargaComboFormulasDeProductos(cmbFormulas, idProducto)
                  cmbFormulas.SelectedValue = idFormula
                  btnConsultar.PerformClick()
               Else
                  Dim rProdform = New Reglas.ProductosFormulas()
                  rProdform.GrabarFormula(idProducto, 1, "Unica", PorcentajeGanancia:=0)
                  _publicos.CargaComboFormulasDeProductos(cmbFormulas, idProducto)
                  cmbFormulas.SelectedIndex = 0
                  CargarProducto(dr)
               End If
            Else
               btnConsultar.Enabled = False
               Nuevo()
            End If
         End If
      End If
   End Sub

   Private Sub LimpiarCamposProductos()
      bscCodigoProducto2.Enabled = True
      bscCodigoProducto2.Text = ""
      bscProducto2.Enabled = True
      bscProducto2.Text = ""
   End Sub
   Private Sub Nuevo()
      LimpiarCamposProductos()
      CargaGrillaVariables()

      If _listaEdicion Is Nothing Then
         Try
            Cursor = Cursors.WaitCursor
            ugDetalle.ClearFilas()
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Cursor = Cursors.Default
         End Try

      Else
         SetDataSource(_listaEdicion.ClonarColeccion)
      End If

      If _modeloFormaEdicion IsNot Nothing Then
         cmbModeloForma.SelectedValue = _modeloFormaEdicion.IdProduccionModeloForma
         cmbModeloForma.Enabled = False
      Else
         If cmbModeloForma.Items.Count > 0 Then
            cmbModeloForma.SelectedIndex = 0
         End If
      End If

      'If Me.ugDetalle.DataSource IsNot Nothing Then
      '   ugDetalle.Refresh()
      'End If

      dudNivelesGrillas.SelectedIndex = 9

      cmbFormulas.Enabled = False
      cmbFormulas.DataSource = Nothing
      '-- Desactiva Consultar.-
      btnConsultar.Enabled = False

      '-- Fromatea e Inicializa
      txtCantidad.Formato = _formatoMostrarEnCantidad
      txtCantidad.SetValor(1)

      Dim dolarFormato As String = String.Format("N{0}", Reglas.Publicos.Facturacion.FacturacionCantidadDecimalesEnCotizacionDolar.ToString())
      Dim cantEnteros As Integer = Integer.Parse(Reglas.Publicos.Facturacion.FacturacionCantidadEnterosEnCotizacionDolar.ToString())
      Dim cantDecimales As Integer = Integer.Parse(Reglas.Publicos.Facturacion.FacturacionCantidadDecimalesEnCotizacionDolar.ToString())
      txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString(dolarFormato)
      txtCotizacionDolar.Formato = dolarFormato
      txtCotizacionDolar.MaxLength = cantEnteros + cantDecimales + 1 'Cantidad de Enteros + Cantidad de Decimales + 1 (El lugar que ocupa el .)

      bscCodigoProducto2.Focus()
   End Sub
   Private Sub CargaGrillaVariables()
      If _valoresFormulas Is Nothing Then
         _valoresFormulas = Reglas.ProduccionFormas.GetValoresForma(0, 0, 0, 0, Nothing)
      End If

      If ugVariables.DataSource Is Nothing Then
         ugVariables.DataSource = _valoresFormulas
         ugVariables.DisplayLayout.Bands(0).Columns("Value").FormatoMaskInput(_formatoMostrarEnCantidad, Formatos.MaskInput.CustomMaskInput(9, _decimalesMostrarEnCantidad))
      End If

      _valoresFormulas.ForEach(
         Sub(dr)
            If _valoresFormulasEdicion Is Nothing Then
               dr.Value = 0
            Else
               dr.Value = _valoresFormulasEdicion.GetValor(dr)
            End If
         End Sub)

      'If _valoresFormulasEdicion Is Nothing Then
      '   _valoresFormulas.ForEach(Sub(dr) dr.Value = 0)
      'Else
      '   _valoresFormulas = _valoresFormulasEdicion.ClonarColeccion()
      'End If

      ugVariables.Rows.Refresh(RefreshRow.FireInitializeRow)

   End Sub
   Private Function ValidaConsulta() As Boolean
      If txtCantidad.ValorNumericoPorDefecto(0D) < 1 Then
         ShowMessage("Producto con Cantidad inválida.")
         txtCantidad.Focus()
         Return False
      End If

      If dudNivelesGrillas.Text.ValorNumericoPorDefecto(0I) < 1 Or dudNivelesGrillas.Text.ValorNumericoPorDefecto(0I) > 50 Then
         ShowMessage("Nivel Ingresado fuera de rango.")
         dudNivelesGrillas.Focus()
         Return False
      End If
      Return True
   End Function
   Private Sub FormateaGrilla()
      Dim cBands = ugDetalle.DisplayLayout.Bands.Count

      For ind = 0 To cBands - 1
         For Each col In ugDetalle.DisplayLayout.Bands(ind).Columns
            col.Hidden = True
         Next
         Dim pos = 0I
         With ugDetalle.DisplayLayout.Bands(ind)
            'If Not .Columns.Exists("EditProduct") Then
            '   .Columns.Add("EditProduct")
            'End If
            'Dim editColumn = .Columns("EditProduct").FormatearColumna("Modificar", pos, 1, HAlign.Center)
            'editColumn.Style = UltraWinGrid.ColumnStyle.Button
            'editColumn.NullText = "Modificar"
            'editColumn.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            'editColumn.MaxWidth = 50

            .Columns("IdProducto").FormatearColumna("Código", pos, 50, HAlign.Right)
            .Columns("NombreProducto").FormatearColumna("Componente", pos, 250, HAlign.Left)

            .Columns("UnidadMedida").Header.Appearance.TextHAlign = HAlign.Center
            .Columns("UnidadMedida").FormatearColumna("UM", pos, 50, HAlign.Center)

            .Columns("Moneda").Header.Appearance.TextHAlign = HAlign.Center
            .Columns("Moneda").FormatearColumna("M", pos, 50, HAlign.Center)

            .Columns("NombreFormula").FormatearColumna("Fórmula", pos, 120)

            .Columns("PrecioConImpuestos").FormatearColumna("Precio Venta", pos, 90, HAlign.Right, Not _MostrarCosto OrElse Not chbConIVA.Checked, _formatoMostrarEnPrecio)
            .Columns("CostoConImpuestos").FormatearColumna("Precio Costo", pos, 90, HAlign.Right, Not _MostrarCosto OrElse Not chbConIVA.Checked, _formatoMostrarEnPrecio)

            .Columns("PrecioSinImpuestos").FormatearColumna("Precio Venta", pos, 90, HAlign.Right, Not _MostrarCosto OrElse chbConIVA.Checked, _formatoMostrarEnPrecio)
            .Columns("CostoSinImpuestos").FormatearColumna("Precio Costo", pos, 90, HAlign.Right, Not _MostrarCosto OrElse chbConIVA.Checked, _formatoMostrarEnPrecio)

            .Columns("Cantidad").FormatearColumna("Cantidad", pos, 80, HAlign.Right,, _formatoMostrarEnCantidad)
            .Columns("CantidadEnFormula").FormatearColumna("Cantidad En Formula", pos, 80, HAlign.Right,, _formatoMostrarEnCantidad)

            .Columns("ImportePrecioConImpuestos").FormatearColumna("Importe Venta", pos, 90, HAlign.Right, Not _MostrarCosto OrElse Not chbConIVA.Checked, _formatoMostrarEnPrecio)
            .Columns("ImporteCostoConImpuestos").FormatearColumna("Importe Costo", pos, 90, HAlign.Right, Not _MostrarCosto OrElse Not chbConIVA.Checked, _formatoMostrarEnPrecio)

            .Columns("ImportePrecioSinImpuestos").FormatearColumna("Importe Venta", pos, 90, HAlign.Right, Not _MostrarCosto OrElse chbConIVA.Checked, _formatoMostrarEnPrecio)
            .Columns("ImporteCostoSinImpuestos").FormatearColumna("Importe Costo", pos, 90, HAlign.Right, Not _MostrarCosto OrElse chbConIVA.Checked, _formatoMostrarEnPrecio)

            .Columns("IdUnidadDeMedidaProduccion").FormatearColumna("UM Producción", pos, 90, HAlign.Right, True)
            .Columns("CantidadUMProduccion").FormatearColumna("Cant.UM Produccion", pos, 90, HAlign.Right, True, _formatoMostrarEnCantidad)
            .Columns("FactorConversionProduccion").FormatearColumna("Factor Conv. Producción ", pos, 90, HAlign.Right, True, _formatoMostrarEnCantidad)


            ' .Columns("Costo").FormatearColumna("Costo", pos, 90, HAlign.Right,, "N" + _decimalesMostrarEnPrecio.ToString())

            'If Not _MostrarCosto Then
            '   ugDetalle.DisplayLayout.Bands(ind).Columns("Precio").Hidden = True
            '   ugDetalle.DisplayLayout.Bands(ind).Columns("Costo").Hidden = True
            'End If


            .Columns("CalculoForma").Header.Appearance.TextHAlign = HAlign.Center
            .Columns("CalculoForma").FormatearColumna("Segun Calculo", pos, 60, HAlign.Center)

            .Columns("FormulaCalculoKilaje").FormatearColumna("Fórmula Cálculo", pos, 240)

         End With
      Next

      ' Next
      ugDetalle.Rows(0).Expanded = True
   End Sub
   Private Function CreateEstructura() As ObservableCollection(Of Entidades.ProductoArbol)
      Dim lista = Reglas.ProduccionFormas.AgregarValoresModeloForma(_valoresFormulas.ToList(),
                                                                    cmbModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma))
      Return New Reglas.EstructuraProductos().CreaEstructura(bscCodigoProducto2.Text,
                                                             cmbFormulas.ValorSeleccionado(Of Integer),
                                                             Reglas.Publicos.ListaPreciosPredeterminada,
                                                             txtCantidad.ValorNumericoPorDefecto(0D),
                                                             _MostrarCosto,
                                                             lista,
                                                             Integer.Parse(cmbMonedaVenta.SelectedValue.ToString()),
                                                             _cotizacionDolar.Value)
   End Function
   ''' <summary>
   ''' Arma Cabecera de Filtrado.-
   ''' </summary>
   ''' <returns></returns>
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Producto: {0} - {1}", bscProducto2.Text, bscProducto2.Text)
         .AppendFormat(" - Formula: {0} ", cmbFormulas.SelectedText.ToString())
         .AppendFormat(" - Cantidad: {0}", txtCantidad.Text)
         .AppendFormat(" - Límite niveles: {0}", dudNivelesGrillas.Text)
      End With
      Return filtro.ToString()
   End Function

   Private Sub SetDataSource(dtEstructura As List(Of Entidades.ProductoArbol))
      SetDataSource(New ObservableCollection(Of Entidades.ProductoArbol)(dtEstructura))
   End Sub
   Private Sub SetDataSource(dtEstructura As ObservableCollection(Of Entidades.ProductoArbol))
      ugDetalle.DataSource = dtEstructura
      FormateaGrilla()
      ugDetalle.ColapsarExpandir(chkExpandAll)
   End Sub

   Private Sub AgregarNuevaFormula()
      Dim dr = ugDetalle.FilaSeleccionada(Of Entidades.ProductoArbol)()
      If dr IsNot Nothing Then
         AgregarNuevaFormula(dr.IdProducto, dr.NombreProducto)

         btnConsultar.PerformClick()
      End If
   End Sub
   Private Function AgregarNuevaFormula(idProducto As String, nombreProducto As String) As Integer
      Using agregar = New AgregarFormula(idProducto, nombreProducto)
         If agregar.ShowDialog() = DialogResult.OK Then
            Return agregar.IdFormula
            'Dim idFormula = agregar.IdFormula
            '_publicos.CargaComboFormulasDeProductos(cmbFormulas, idProducto)
            'Return idFormula
            'cmbFormulas.SelectedValue = idFormula
            'btnConsultar.PerformClick()
         Else
            'btnConsultar.Enabled = False
            'Nuevo()
         End If
      End Using
      Return 0
   End Function
   Private Sub EditarFormula()
      Dim dr = ugDetalle.FilaSeleccionada(Of Entidades.ProductoArbol)()

      If dr IsNot Nothing Then
         If dr.IdFormula = 0 Then
            Throw New Exception(String.Format("El producto {0} - {1} no tiene formulas. No se puede modificar.", dr.IdProducto, dr.NombreProducto))
         End If
         Using frm = New FormulasABM()
            If _stateForm = StateForm.Insertar Then
               If frm.ShowDialog(dr.IdProducto, dr.IdFormula) = DialogResult.OK Then
                  btnConsultar.PerformClick()
               End If
            Else
               Dim lista = Reglas.ProduccionFormas.AgregarValoresModeloForma(_valoresFormulas.ToList(), cmbModeloForma.ItemSeleccionado(Of Entidades.ProduccionModeloForma))
               If frm.ShowDialog(dr.IdProducto, dr.IdFormula, dr.Hijo, lista, _cotizacionDolar.Value) = DialogResult.OK Then
                  Dim rEstructura = New Reglas.EstructuraProductos()

                  rEstructura.RecalculaCantidades(dr, lista)
                  rEstructura.RecalculaPrecios(dr)

                  ugDetalle.Rows.Refresh(RefreshRow.FireInitializeRow, True)
                  'btnConsultar.PerformClick()
               End If
            End If
         End Using
      End If

   End Sub
   Private Sub EliminarFormulaConPregunta()
      Dim dr = ugDetalle.FilaSeleccionada(Of Entidades.ProductoArbol)()

      If dr IsNot Nothing Then
         If ShowPregunta("¿Desea eliminar la fórmula {1} del producto {2} - {3}?",
                         dr.IdFormula, dr.NombreFormula, dr.IdProducto, dr.NombreProducto) = DialogResult.Yes Then
            Dim rProdform = New Reglas.ProductosFormulas()
            rProdform.EliminarFormula(dr.IdProducto, dr.IdFormula)
            ShowMessage("Se eliminó la formula seleccionada.")

            If dr.IdProducto = bscCodigoProducto2.Text Then
               _publicos.CargaComboFormulasDeProductos(cmbFormulas, dr.IdProducto)
               If cmbFormulas.Any() Then
                  cmbFormulas.SelectedIndex = 0
                  btnConsultar.PerformClick()
               Else
                  tsbRefrescar.PerformClick()
               End If
            Else
               btnConsultar.PerformClick()
            End If
         End If
      End If
   End Sub

   Private Sub txtCotizacionDolar_Leave(sender As Object, e As EventArgs) Handles txtCotizacionDolar.Leave
      TryCatched(
        Sub()
           If txtCotizacionDolar.ValorNumericoPorDefecto(0D) < 1 Then
              MessageBox.Show("La cotización dólar no puede ser inferior a uno (1)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
              txtCotizacionDolar.Focus()
              Exit Sub
           End If
           _cotizacionDolar = txtCotizacionDolar.ValorNumericoPorDefecto(0D)
           ''SOLO REPROCESO SI CAMBIA EL TIPO DE CAMBIO. SI NO CAMBIÓ NO HAGO NADA
           'If cotizacionDolar <> _cotizacionDolar_Prev And cmbMonedaVenta.ValorSeleccionado(Of Integer) = Entidades.Moneda.Dolar Then
           '   RecalcularCotizacionDolar(_cotizacionDolar_Prev, cotizacionDolar)
           'End If
        End Sub)
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

   '---------------------------------------------------------------------------------------------------------------------------------------------

End Class