Imports Eniac.Controles

Public Class FacturacionUtilizaCanje

#Region "Constantes"
   '-- REQ-36082.- --------------------------------------------------------------------
   Public Property MovAtributo01 As Entidades.AtributoProducto
   Public Property MovAtributo02 As Entidades.AtributoProducto
   Public Property MovAtributo03 As Entidades.AtributoProducto
   Public Property MovAtributo04 As Entidades.AtributoProducto

   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04

   Private flackCargaProductos As Boolean = True
   '-----------------------------------------------------------------------------------
#End Region

#Region "Campos"
   Private _decimalesEnCantidad As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnCantidad
   Private _mensajeDeErrorEnCarga As String = ""
   Private _cargoBienLaPantalla As Boolean = False
   '-----------------------------------------
   Public idCliente As Long = 0
   Public idListaPrecios As Integer = 0
   Public tipoOperacion As Entidades.Producto.TiposOperaciones = Entidades.Producto.TiposOperaciones.NORMAL
   '-----------------------------------------
   Private _publicos As Publicos
   '-----------------------------------------
   Public _cotizacionDolar As Decimal
   Public _clienteE As Entidades.Cliente
   Public fechaCompro As Date
   Public _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _modalidad As Eniac.Entidades.Producto.Modalidades = Eniac.Entidades.Producto.Modalidades.NORMAL
   Public _valorRedondeo As Integer = 2
   Public _formatoDecimalesAMostrar As String = String.Format("N{0}", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio)
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         _publicos = New Publicos()

         '-- Seta Valores Decimales.-
         txtCantidadProductoCanje.Formato = "N" + _decimalesEnCantidad.ToString()
         '-- REQ-34986.- --------------------------------------------------------------------------------------------------------------------------------
         With dgvDetalle.Columns("DescripcionAtributo01")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion
            .Visible = True
         End With
         With dgvDetalle.Columns("DescripcionAtributo02")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion
            .Visible = True
         End With
         With dgvDetalle.Columns("DescripcionAtributo03")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo03).Descripcion
         End With
         With dgvDetalle.Columns("DescripcionAtributo04")
            .HeaderText = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo04).Descripcion
         End With
         '-----------------------------------------------------------------------------------------------------------------------------------------------
         _cargoBienLaPantalla = True
      Catch ex As Exception
         _mensajeDeErrorEnCarga = ex.Message
         _cargoBienLaPantalla = False
      End Try
   End Sub
#End Region

#Region "Eventos"
   ''' <summary>
   ''' Evento click de boton Limpiar
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub btnLimpiarProductos_Click(sender As Object, e As EventArgs) Handles btnLimpiarProductos.Click
      '-- Seteo Inicial Cantidades.- --
      txtCantidadProductoCanje.Text = "0." + New String("0"c, Me._decimalesEnCantidad)
      '-- Seteo inicial Buscadores Producto.- --
      bscCodigoProductoCanje.Text = String.Empty
      bscCodigoProductoCanje.Enabled = True
      bscNombreProductoCanje.Text = String.Empty
      bscNombreProductoCanje.Enabled = True
      bscCodigoProductoCanje.Focus()
   End Sub

   Private Sub bscCodigoProductoCanje_BuscadorClick() Handles bscCodigoProductoCanje.BuscadorClick
      Try
         Dim oProductos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos2(bscCodigoProductoCanje)
         bscCodigoProductoCanje.Datos = oProductos.GetPorCodigo(bscCodigoProductoCanje.Text.Trim(), actual.Sucursal.Id, idListaPrecios, "VENTAS", , , , tipoOperacion, , , , , idCliente, soloBuscaPorIdProducto:=False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscNombreProductoCanje_BuscadorClick() Handles bscNombreProductoCanje.BuscadorClick
      Try
         Dim oProductos = New Reglas.Productos
         _publicos.PreparaGrillaProductos2(bscNombreProductoCanje)
         bscNombreProductoCanje.Datos = oProductos.GetPorNombre(bscNombreProductoCanje.Text.Trim(), actual.Sucursal.Id, idListaPrecios, "VENTAS", , , tipoOperacion, , , , , idCliente)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ProductoCanje_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscCodigoProductoCanje.BuscadorSeleccion, bscNombreProductoCanje.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub txtCantidadProductoCanje_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadProductoCanje.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Int(txtCantidadProductoCanje.Text).ToString.Length > 3 Then
            MessageBox.Show("La cantidad NO puede tener mas de 3 digitos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCantidadProductoCanje.Focus()
            Exit Sub
         End If
         If String.IsNullOrWhiteSpace(bscCodigoProductoCanje.Text) Then
            bscCodigoProductoCanje.Focus()
         Else
            btnInsertarProducto.Focus()
            btnInsertarProducto.PerformClick()
         End If
      End If
   End Sub
   Private Sub dgvDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
      Try
         '-- Limpia Campos de carga de Producto.- --
         LimpiarCamposProductos()
         '-- Carga Producto.- ----------------------
         flackCargaProductos = False
         CargarProductoCompleto(dgvDetalle.Rows(e.RowIndex))
         flackCargaProductos = True
         '-- Elimina Producto Grilla.- -------------
         EliminarLineaProducto()
         '-- Habilita Eliminar.- --
         btnBorrarProducto.Enabled = False
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnInsertarProducto_Click(sender As Object, e As EventArgs) Handles btnInsertarProducto.Click
      Try
         Dim CantResultante As Decimal = Decimal.Parse(Me.txtCantidadProductoCanje.Text)
         If CantResultante <> 0 Then
            InsertarProducto()
            '-- Habilita Eliminar.- ---------
            btnBorrarProducto.Enabled = True
            '--------------------------------
            bscCodigoProductoCanje.Focus()
            '--------------------------------
         Else
            MessageBox.Show("No puede ingresar Cantidades en Cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCantidadProductoCanje.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub
#End Region

#Region "Metodos"
   ''' <summary>
   ''' Carga del Producto.- --
   ''' </summary>
   ''' <param name="dr"></param>
   Private Sub CargarProducto(dr As DataGridViewRow)
      Me.bscCodigoProductoCanje.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscCodigoProductoCanje.Enabled = False

      Me.bscNombreProductoCanje.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscNombreProductoCanje.Enabled = False

      '-- REQ-35220.- -------------------------------------------------------------------------------
      MovAtributo01 = New Entidades.AtributoProducto
      MovAtributo02 = New Entidades.AtributoProducto
      MovAtributo03 = New Entidades.AtributoProducto
      MovAtributo04 = New Entidades.AtributoProducto
      If Integer.Parse(dr.Cells("Atributos").Value.ToString()) > 0 Then
         If flackCargaProductos Then
            '-- Carga los Valores de Atributo.- --
            With MovAtributo01
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo01").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo01").Value.ToString())
            End With
            With MovAtributo02
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo02").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo02").Value.ToString())
            End With
            With MovAtributo03
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo03").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo03").Value.ToString())
            End With
            With MovAtributo04
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo04").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo04").Value.ToString())
            End With

            '-- Convoca Formulario de Carga de Atributos.-
            Using sap = New SeleccionaAtributosProductos()
               With sap
                  .Atributo01 = MovAtributo01
                  .Atributo02 = MovAtributo02
                  .Atributo03 = MovAtributo03
                  .Atributo04 = MovAtributo04
                  '-- Adiciona Producto y Sucursal.- ---------------
                  .idSucursal = actual.Sucursal.IdSucursal
                  .idProducto = dr.Cells("IdProducto").Value.ToString.Trim()
               End With
               '-- Invoca Formulario.- -----------------------------
               If sap.ShowDialog(Me) = DialogResult.Cancel Then
                  btnLimpiarProductos.PerformClick()
                  bscCodigoProductoCanje.Focus()
                  Exit Sub
               End If
               '-- Aloja los datos recuperados.- --
               With sap
                  MovAtributo01 = .Atributo01
                  MovAtributo02 = .Atributo02
                  MovAtributo03 = .Atributo03
                  MovAtributo04 = .Atributo04
               End With
            End Using
         End If
         '----------------------------------------------------------------------------------------------------------------------------------------------------------------
         bscCodigoProductoCanje.Tag = New Reglas.ProductosSucursalesAtributos().GetStockProductoAtributo(dr.Cells("IdProducto").Value.ToString.Trim(),
                                                                                                         actual.Sucursal.IdSucursal,
                                                                                                         MovAtributo01.IdaAtributoProducto,
                                                                                                         MovAtributo02.IdaAtributoProducto,
                                                                                                         MovAtributo03.IdaAtributoProducto,
                                                                                                         MovAtributo04.IdaAtributoProducto).ToString()
         '----------------------------------------------------------------------------------------------------------------------------------------------------------------
      Else
         bscCodigoProductoCanje.Tag = dr.Cells("Stock").Value.ToString()
      End If
      '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
      Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())
      Dim p = FacturacionAyudantes.GetPrecio(Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString()), Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString()),
                                                Producto, _clienteE, fechaCompro, 0, _categoriaFiscalEmpresa, "",
                                                _cotizacionDolar, _modalidad, _valorRedondeo, FormaDePago:=Nothing)
      bscNombreProductoCanje.Tag = p.ToString(_formatoDecimalesAMostrar)

      '-------------------------------------------------------------------------------------------------------------------------------------------------------------------
   End Sub

   Private Sub InsertarProducto()
      Try
         Dim dt As DataTable
         If dgvDetalle.Rows.Count > 0 Then
            dt = DirectCast(dgvDetalle.DataSource, DataTable)
         Else
            dt = CrearDT()
         End If
         Dim drCl = dt.NewRow()

         drCl("IdProducto") = bscCodigoProductoCanje.Text
         drCl("DescripcionProducto") = bscNombreProductoCanje.Text

         drCl("IdaAtributoProducto01") = MovAtributo01.IdaAtributoProducto
         drCl("DescripcionAtributo01") = MovAtributo01.Descripcion
         drCl("IdaAtributoProducto02") = MovAtributo02.IdaAtributoProducto
         drCl("DescripcionAtributo02") = MovAtributo02.Descripcion
         drCl("IdaAtributoProducto03") = MovAtributo03.IdaAtributoProducto
         drCl("DescripcionAtributo03") = MovAtributo03.Descripcion
         drCl("IdaAtributoProducto04") = MovAtributo04.IdaAtributoProducto
         drCl("DescripcionAtributo04") = MovAtributo04.Descripcion

         drCl("CantidadProducto") = Decimal.Parse(txtCantidadProductoCanje.Text)
         drCl("StockProducto") = Decimal.Parse(bscCodigoProductoCanje.Tag.ToString())

         drCl("PrecioProducto") = Decimal.Parse(bscNombreProductoCanje.Tag.ToString())

         Dim Importe = Decimal.Parse(bscNombreProductoCanje.Tag.ToString()) * Decimal.Parse(txtCantidadProductoCanje.Text)

         drCl("ImporteProducto") = Importe

         txtTotalGeneral.Text = (Decimal.Parse(txtTotalGeneral.Text) + Importe).ToString()

         dt.Rows.Add(drCl)

         dgvDetalle.DataSource = dt
         '-- Inicializa los controles.- --
         btnLimpiarProductos.PerformClick()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         tssRegistros.Text = dgvDetalle.RowCount.ToString() & " Registros"
      End Try

   End Sub
   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("DescripcionProducto", GetType(String))
         .Columns.Add("IdaAtributoProducto01", GetType(Integer))
         .Columns.Add("DescripcionAtributo01", GetType(String))
         .Columns.Add("IdaAtributoProducto02", GetType(Integer))
         .Columns.Add("DescripcionAtributo02", GetType(String))
         .Columns.Add("IdaAtributoProducto03", GetType(Integer))
         .Columns.Add("DescripcionAtributo03", GetType(String))
         .Columns.Add("IdaAtributoProducto04", GetType(Integer))
         .Columns.Add("DescripcionAtributo04", GetType(String))
         .Columns.Add("CantidadProducto", GetType(Decimal))
         .Columns.Add("StockProducto", GetType(Decimal))
         .Columns.Add("PrecioProducto", GetType(Decimal))
         .Columns.Add("ImporteProducto", GetType(Decimal))
      End With
      Return dtTemp
   End Function
   Private Sub LimpiarCamposProductos()
      bscCodigoProductoCanje.Text = String.Empty
      bscNombreProductoCanje.Text = String.Empty

      txtCantidadProductoCanje.Text = String.Empty
      cmbTipoComprobante.SelectedIndex = -1
   End Sub
   Private Sub CargarProductoCompleto(dr As DataGridViewRow)

      bscCodigoProductoCanje.Text = dr.Cells(0).Value.ToString.Trim()
      bscCodigoProductoCanje.PresionarBoton()

      txtCantidadProductoCanje.Text = dr.Cells(10).Value.ToString()
      '-- REQ-34669.- -- Aloja los datos recuperados.- --
      With MovAtributo01
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto01").Value.ToString())
         If dr.Cells("DescripcionAtributo01").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo01").Value.ToString()
         End If
      End With
      With MovAtributo02
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto02").Value.ToString())
         If dr.Cells("DescripcionAtributo02").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo02").Value.ToString()
         End If
      End With
      With MovAtributo03
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto03").Value.ToString())
         If dr.Cells("DescripcionAtributo03").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo03").Value.ToString()
         End If
      End With
      With MovAtributo04
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto04").Value.ToString())
         If dr.Cells("DescripcionAtributo04").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo04").Value.ToString()
         End If
      End With

      Dim Importe = (Decimal.Parse(dr.Cells(12).Value.ToString.Trim()) * Decimal.Parse(dr.Cells(10).Value.ToString()))
      txtTotalGeneral.Text = (Decimal.Parse(txtTotalGeneral.Text) - Importe).ToString()
   End Sub
   Private Sub EliminarLineaProducto()
      Dim i As Integer
      i = dgvDetalle.CurrentRow.Index
      dgvDetalle.Rows.RemoveAt(i)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

      If Not dgvDetalle.DataSource Is Nothing And dgvDetalle.Rows.Count > 1 Then
         If cmbTipoComprobante.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un Tipo de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbTipoComprobante.Focus()
            Exit Sub
         End If
         DialogResult = DialogResult.OK
      Else
         MessageBox.Show("Debe ingresar al Menos dos Articulos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         cmbTipoComprobante.Focus()
         Exit Sub
      End If
   End Sub

   Private Sub txtTotalGeneral_TextChanged(sender As Object, e As EventArgs) Handles txtTotalGeneral.TextChanged

      Dim coeficiente As Integer? = Nothing
      Select Case Decimal.Parse(txtTotalGeneral.Text)
         Case >= 0
            coeficiente = 1
         Case < 0
            coeficiente = -1
      End Select
      Dim importeComprobante As Decimal? = txtTotalGeneral.ValorNumericoPorDefecto(0D) * coeficiente

      If _cargoBienLaPantalla Then
         _publicos.CargaComboTiposComprobantes(cmbTipoComprobante, True, "VENTAS", , , "SI", True,,,,,,,, coeficiente, importeComprobante)
      End If

   End Sub

   Private Sub btnBorrarProducto_Click(sender As Object, e As EventArgs) Handles btnBorrarProducto.Click
      Dim dr = dgvDetalle.CurrentRow
      '-- Recalcula Totales.- ----------------------------------------------------------------------------------------
      Dim Importe = (Decimal.Parse(dr.Cells(12).Value.ToString.Trim()) * Decimal.Parse(dr.Cells(10).Value.ToString()))
      txtTotalGeneral.Text = (Decimal.Parse(txtTotalGeneral.Text) - Importe).ToString()
      '---------------------------------------------------------------------------------------------------------------
      EliminarLineaProducto()
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      DialogResult = DialogResult.Cancel
   End Sub
#End Region
End Class