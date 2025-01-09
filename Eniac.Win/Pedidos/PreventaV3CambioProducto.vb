#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class PreventaV3CambioProducto
#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Propiedades"
   Private Property Pedido As Entidades.DsPreventa.PedidoRow
   Private Property PedidoProducto As Entidades.DsPreventa.PedidoProductoRow
#End Region

#Region "Overrides/Overloads"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos = New Publicos()

         _publicos.CargaComboListaDePrecios(cmbListaPreciosNueva)

         txtIdProductoAnterior.Text = PedidoProducto.IdProducto

         If PedidoProducto.IdListaPrecios < 0 Then
            txtIdListaPreciosAnterior.Text = PedidoProducto.IdListaPrecios.ToString()
         Else
            txtIdListaPreciosAnterior.Text = PedidoProducto.NombreListaPrecios
         End If

         cmbListaPreciosNueva.SelectedValue = PedidoProducto.IdListaPrecios

         Dim rProducto As Reglas.Productos = New Reglas.Productos()
         If rProducto.Existe(PedidoProducto.IdProducto) Then
            bscCodigoProducto2.Text = PedidoProducto.IdProducto
            bscCodigoProducto2.PresionarBoton()
         Else
            bscCodigoProducto2.Text = String.Empty
            bscProducto2.Text = String.Empty
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         tsbGrabar.PerformClick()
         Return True
      ElseIf keyData = Keys.Escape Then
         tsbCerrar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
   Public Overloads Function ShowDialog(owner As Form, pedido As Entidades.DsPreventa.PedidoRow, pedidoProducto As Entidades.DsPreventa.PedidoProductoRow) As DialogResult
      _Pedido = pedido
      _PedidoProducto = pedidoProducto
      Return ShowDialog(owner)
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If (Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono) Or String.IsNullOrWhiteSpace(bscCodigoProducto2.Text) Then
            ShowMessage("Debe seleccionar un producto")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         Me.ModificarEstadoVisita()

         DialogResult = Windows.Forms.DialogResult.OK
         Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
#End Region

#Region "Eventos Busqueda Foranea - Producto"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Reglas.Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = New Reglas.Productos().GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Reglas.Publicos.ListaPreciosPredeterminada, "VENTAS")

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region
#End Region

#Region "Metodos"
   Private Sub ModificarEstadoVisita()

      PedidoProducto.IdProducto = bscCodigoProducto2.Text
      PedidoProducto.NombreProducto = bscProducto2.Text

      PedidoProducto.IdListaPrecios = Integer.Parse(cmbListaPreciosNueva.SelectedValue.ToString())
      PedidoProducto.NombreListaPrecios = cmbListaPreciosNueva.Text


      'TODO: Llevar esto a una regla para unificar con la bajada y que sea unificado con los otros formatos de bajada
      Dim rProdSuc As Eniac.Reglas.ProductosSucursales = New Eniac.Reglas.ProductosSucursales()

      Dim producto As Eniac.Entidades.ProductoSucursal
      producto = rProdSuc.GetUno(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal, PedidoProducto.IdProducto, PedidoProducto.IdListaPrecios)

      PedidoProducto.PrecioLista = producto.PrecioVentaLista
      PedidoProducto.Stock = producto.Stock
      PedidoProducto.IVA = producto.Producto.Alicuota

      Dim ruta As Entidades.MovilRuta = New Reglas.MovilRutas().GetUno(Pedido.IdRuta)
      'RUTA: PuedeModificarPrecio
      If ruta.PuedeModificarPrecio Or Reglas.Publicos.PreventaRespetaPrecioDelMovil Then
         Dim precioMovil As Decimal = PedidoProducto.PrecioMovil
         If (Publicos.PreciosConIVA And ruta.PrecioConImpuestos) Or (Not Publicos.PreciosConIVA And Not ruta.PrecioConImpuestos) Then
            PedidoProducto.Precio = precioMovil
         Else
            If Publicos.PreciosConIVA And Not ruta.PrecioConImpuestos Then
               PedidoProducto.Precio = (precioMovil * (1 + (PedidoProducto.IVA / 100))) + producto.Producto.ImporteImpuestoInterno
            ElseIf Not Publicos.PreciosConIVA And ruta.PrecioConImpuestos Then
               PedidoProducto.Precio = (precioMovil - producto.Producto.ImporteImpuestoInterno) / (1 + (PedidoProducto.IVA / 100))
            End If
         End If
      Else
         PedidoProducto.Precio = producto.PrecioVentaLista
      End If

      If Not Reglas.Publicos.PreventaV2ImportaDescuentosSimovilWeb Then
         Dim descRec As Eniac.Reglas.DescuentoRecargoProducto = New Reglas.CalculosDescuentosRecargos().DescuentoRecargo(Pedido.IdCliente, producto.Producto.IdProducto, PedidoProducto.Cantidad, 2)

         PedidoProducto.PorcDesc1 = descRec.DescuentoRecargo1
         PedidoProducto.PorcDesc2 = descRec.DescuentoRecargo2
      End If


      PedidoProducto.ConError_ProductoInexistente = False

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
   End Sub
#End Region
End Class