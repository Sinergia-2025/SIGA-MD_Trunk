Option Strict On
Option Explicit On

Imports Infragistics.Win.UltraWinGrid
Imports Eniac.Entidades

Public Class DesvincularPedidos

#Region "Campos"
   Private _publicos As Publicos

   Private _dtPedidosClientes As DataTable

   Private _tipoEstadoPedidoCliente As String
   Private _tipoEstadoPedidoProveedor As String

   Private _titResumen As Dictionary(Of String, String)
#End Region

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()

         If String.IsNullOrWhiteSpace(_tipoEstadoPedidoCliente) Then _tipoEstadoPedidoCliente = "PEDIDOSCLIE"
         If String.IsNullOrWhiteSpace(_tipoEstadoPedidoProveedor) Then _tipoEstadoPedidoProveedor = "PEDIDOSPROV"

         _publicos.CargaComboEstadosPedidos(cmbNuevoEstadoPedidoCliente, False, False, False, False, False, _tipoEstadoPedidoCliente)
         _publicos.CargaComboEstadosPedidosProv(cmbNuevoEstadoPedidoProveedor, False, False, False, False, False, _tipoEstadoPedidoProveedor)
         cmbNuevoEstadoPedidoCliente.SelectedValue = Reglas.Publicos.EstadoPedidoPreVinculacion
         cmbNuevoEstadoPedidoProveedor.SelectedValue = Reglas.Publicos.EstadoPedidoProvPreVinculacion

         Ayudante.Grilla.AgregarFiltroEnLinea(ugResumen, {Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                                          Entidades.Producto.Columnas.NombreProducto.ToString(),
                                                          Entidades.Proveedor.Columnas.NombreProveedor.ToString()})

         _titResumen = GetColumnasVisiblesGrilla(ugResumen)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub AnularPedidos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         MostrarCantidadRegistros()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Cursor = Cursors.WaitCursor

         DesvincularPedidos()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If GetCantidadPedidos(_dtPedidosClientes) > 0 Then
            Me.btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: ¡NO hay Pedidos que cumplan con la selección!")
         End If
      Catch ex As Exception
         MostrarCantidadRegistros()
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
#End Region


#Region "Metodos"
   Public Sub RefrescarDatosGrilla()
      If TypeOf (ugResumen.DataSource) Is DataTable Then
         DirectCast(ugResumen.DataSource, DataTable).Clear()
      End If
   End Sub

   Private Sub DesvincularPedidos()
      Dim dr As DataRow = GetActiveRow(ugResumen)
      If ValidarDesvinculacion(dr) Then
         If ShowPregunta("¿Desea desvincular el pedido seleccionado?") = Windows.Forms.DialogResult.Yes Then
            Dim rPedidosEstados As Reglas.PedidosEstadosProveedores = New Reglas.PedidosEstadosProveedores()
            rPedidosEstados.DesVincularPedidos({dr}, cmbNuevoEstadoPedidoCliente.SelectedValue.ToString(), cmbNuevoEstadoPedidoProveedor.SelectedValue.ToString(), IdFuncion)
            CargaGrillaDetalle()
            ShowMessage("Desvinculación realizada exitosamente!")
         End If
      End If
   End Sub
   Private Function ValidarDesvinculacion(drPedido As DataRow) As Boolean
      If drPedido Is Nothing Then
         ShowMessage("No ha seleccionado ningún pedido a desvincular.")
         Return False
      End If

      If cmbNuevoEstadoPedidoCliente.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar el estado al que se cambiará el Pedido de Cliente.")
         Return False
      End If

      If cmbNuevoEstadoPedidoProveedor.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar el estado al que se cambiará el Pedido de Proveedor.")
         Return False
      End If

      Return True
   End Function
   Private Function GetActiveRow(grilla As UltraGrid) As DataRow
      If grilla.ActiveRow IsNot Nothing AndAlso
         grilla.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (grilla.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(grilla.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then
         Return DirectCast(grilla.ActiveRow.ListObject, DataRowView).Row
      Else
         Return Nothing
      End If
   End Function

   Private Function GetCantidadPedidos(dt As DataTable) As Integer
      If dt Is Nothing Then Return 0
      Return dt.Rows.Count
   End Function

   Private Sub MostrarCantidadRegistros()
      Me.tssRegistros.Text = String.Format("{0} Registros",
                                           GetCantidadPedidos(_dtPedidosClientes))
   End Sub

   Public Sub CargaGrillaDetalle()
      Dim rPedidos As Reglas.PedidosEstados = New Reglas.PedidosEstados()
      _dtPedidosClientes = rPedidos.GetPedidosVinculados()
      _dtPedidosClientes.AcceptChanges()

      ugResumen.DataSource = _dtPedidosClientes

      AjustarColumnasGrilla(ugResumen, _titResumen)
   End Sub

#End Region

End Class