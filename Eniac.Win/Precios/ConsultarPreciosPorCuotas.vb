Public Class ConsultarPreciosPorCuotas
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos

   Private _modoDefault As String

   Private _titListasDePrecios As Dictionary(Of String, String)
   Private _titFormasPago As Dictionary(Of String, String)
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         If String.IsNullOrWhiteSpace(_modoDefault) Then _modoDefault = "FP"

         Me._publicos = New Publicos()
         Me._publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios)
         Me._publicos.CargaComboCategorias(Me.cmbCategoria, False, False)
         If cmbCategoria.Items.Count > 0 Then
            cmbCategoria.SelectedIndex = 0
         End If
         tbcPrecios.SelectedTab = tbpListaPrecios
         _titListasDePrecios = GetColumnasVisiblesGrilla(ugListasDePrecios)
         tbcPrecios.SelectedTab = tbpFormasPago
         _titFormasPago = GetColumnasVisiblesGrilla(ugFormaPago)
         chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

         If _modoDefault = "LP" Then
            tbcPrecios.SelectedTab = tbpListaPrecios
         ElseIf _modoDefault = "FP" Then
            tbcPrecios.SelectedTab = tbpFormasPago
         Else
            'Por si está algo mal configurado.
            tbcPrecios.SelectedTab = tbpListaPrecios
         End If

         bscCodigoProducto2.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarPreciosPorProducto_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.RefrescarDatosGrilla()
         Me.bscCodigoProducto2.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub cmbListaDePrecios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaDePrecios.SelectedIndexChanged, cmbCategoria.SelectedIndexChanged
      Try
         CargaPreciosPorFormaPago()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      bscCodigoProducto2.Text = String.Empty
      bscProducto2.Text = String.Empty
      txtCodigoDeBarras.Text = String.Empty
      txtMoneda.Text = String.Empty
      txtAlicuota.Text = "0.00"
      txtStock.Text = "0.00"

      If TypeOf (Me.ugListasDePrecios.DataSource) Is DataTable Then
         DirectCast(Me.ugListasDePrecios.DataSource, DataTable).Clear()
      End If
      If TypeOf (Me.ugFormaPago.DataSource) Is DataTable Then
         DirectCast(Me.ugFormaPago.DataSource, DataTable).Clear()
      End If

      MuestraCantidadRegistros()
   End Sub

   Private Sub MuestraCantidadRegistros()
      Dim cantidadRegistros As Long = 0
      If tbcPrecios.SelectedTab IsNot Nothing Then
         If tbcPrecios.SelectedTab.Equals(tbpListaPrecios) Then
            If TypeOf (ugListasDePrecios.DataSource) Is DataTable Then
               cantidadRegistros = DirectCast(Me.ugListasDePrecios.DataSource, DataTable).Rows.Count
            End If
         Else
            If TypeOf (ugFormaPago.DataSource) Is DataTable Then
               cantidadRegistros = DirectCast(Me.ugFormaPago.DataSource, DataTable).Rows.Count
            End If
         End If
      End If
      Me.tssRegistros.Text = String.Format("{0} Registros", cantidadRegistros)
   End Sub

#End Region

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)

         Dim codProd As String = String.Empty
         codProd = Me.bscCodigoProducto2.Text.Trim()

         Dim idListaPrecios As Integer = DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios

         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Dim dt As DataTable = oProductos.GetPorCodigo(codProd, actual.Sucursal.Id, idListaPrecios, "VENTAS")

         Me.bscCodigoProducto2.Datos = dt
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim idListaPrecios As Integer = DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, idListaPrecios, "VENTAS")
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

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      bscCodigoProducto2.Text = dr.Cells(Entidades.Producto.Columnas.IdProducto.ToString()).Value.ToString()
      bscProducto2.Text = dr.Cells(Entidades.Producto.Columnas.NombreProducto.ToString()).Value.ToString()
      txtStock.Text = dr.Cells("Stock").Value.ToString()
      txtCodigoDeBarras.Text = dr.Cells("CodigoDeBarras").Value.ToString()
      txtMoneda.Text = dr.Cells("NombreMoneda").Value.ToString()
      txtAlicuota.Text = Decimal.Parse(dr.Cells("Alicuota").Value.ToString()).ToString("N2")

      CargaPreciosPorListaDePrecios()
      CargaPreciosPorFormaPago()
      'Me.txtCantidad.Focus()
   End Sub

   Private Sub CargaPreciosPorFormaPago()
      If String.IsNullOrWhiteSpace(bscCodigoProducto2.Text) Then Return
      Dim idListaPrecios As Integer = Publicos.ListaPreciosPredeterminada
      If cmbListaDePrecios.SelectedIndex > -1 Then
         idListaPrecios = Integer.Parse(cmbListaDePrecios.SelectedValue.ToString())
      End If
      Dim categoria As Entidades.Categoria = Nothing
      If cmbCategoria.SelectedIndex > -1 Then
         categoria = DirectCast(cmbCategoria.SelectedItem, Entidades.Categoria)
      Else
         If tbcPrecios.SelectedTab.Equals(tbpFormasPago) Then
            ShowMessage("Debe seleccionar una categoría de cliente.")
         End If
         Exit Sub
      End If

      Dim oProd As Reglas.Productos = New Reglas.Productos()
      Dim dtDetalle As DataTable
      dtDetalle = oProd.GetPreciosParaConsultaPorCuotaPorFormaPago(actual.Sucursal.IdSucursal, Me.bscCodigoProducto2.Text.Trim(), idListaPrecios, categoria)

      Me.ugFormaPago.DataSource = dtDetalle

      AjustarColumnasGrilla(ugFormaPago, _titFormasPago)

      MuestraCantidadRegistros()

   End Sub
   Private Sub CargaPreciosPorListaDePrecios()
      If String.IsNullOrWhiteSpace(bscCodigoProducto2.Text) Then Return
      Dim oProd As Reglas.Productos = New Reglas.Productos()

      Dim dtDetalle As DataTable
      dtDetalle = oProd.GetPreciosParaConsultaPorCuotaPorListaPrecios(actual.Sucursal.IdSucursal, Me.bscCodigoProducto2.Text.Trim())

      Me.ugListasDePrecios.DataSource = dtDetalle

      AjustarColumnasGrilla(ugListasDePrecios, _titListasDePrecios)

      MuestraCantidadRegistros()
   End Sub

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      Try
         Me.ugListasDePrecios.DisplayLayout.Bands(0).Columns("PrecioVentaSinIVA").Hidden = chbConIVA.Checked
         Me.ugListasDePrecios.DisplayLayout.Bands(0).Columns("PrecioVentaConIVA").Hidden = Not chbConIVA.Checked

         Me.ugListasDePrecios.DisplayLayout.Bands(0).Columns("PrecioCuotaSinIVA").Hidden = chbConIVA.Checked
         Me.ugListasDePrecios.DisplayLayout.Bands(0).Columns("PrecioCuotaConIVA").Hidden = Not chbConIVA.Checked

         _titListasDePrecios = GetColumnasVisiblesGrilla(ugListasDePrecios)

         Me.ugFormaPago.DisplayLayout.Bands(0).Columns("PrecioVentaSinIVA").Hidden = chbConIVA.Checked
         Me.ugFormaPago.DisplayLayout.Bands(0).Columns("PrecioVentaConIVA").Hidden = Not chbConIVA.Checked

         Me.ugFormaPago.DisplayLayout.Bands(0).Columns("PrecioCuotaSinIVA").Hidden = chbConIVA.Checked
         Me.ugFormaPago.DisplayLayout.Bands(0).Columns("PrecioCuotaConIVA").Hidden = Not chbConIVA.Checked

         Me.ugFormaPago.DisplayLayout.Bands(0).Columns("PrecioFinalSinIVA").Hidden = chbConIVA.Checked
         Me.ugFormaPago.DisplayLayout.Bands(0).Columns("PrecioFinalConIVA").Hidden = Not chbConIVA.Checked

         _titFormasPago = GetColumnasVisiblesGrilla(ugFormaPago)


      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tbcPrecios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcPrecios.SelectedIndexChanged
      Try
         MuestraCantidadRegistros()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _modoDefault = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function
End Class