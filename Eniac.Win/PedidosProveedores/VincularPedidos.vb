Option Strict On
Option Explicit On

Imports Infragistics.Win.UltraWinGrid
Imports Eniac.Entidades

Public Class VincularPedidos

#Region "Campos"
   Private _publicos As Publicos

   Private _dtPedidosClientes As DataTable
   Private _dtPedidosProveedores As DataTable

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

         _publicos.CargaComboEstadosPedidos(cmbEstadosPedidosClientes, False, False, False, False, False, _tipoEstadoPedidoCliente)
         _publicos.CargaComboEstadosPedidosProv(cmbEstadosPedidosProveedores, False, False, False, False, False, _tipoEstadoPedidoProveedor)
         cmbEstadosPedidosClientes.SelectedValue = Reglas.Publicos.EstadoPedidoPreVinculacion
         cmbEstadosPedidosProveedores.SelectedValue = Reglas.Publicos.EstadoPedidoProvPreVinculacion

         Ayudante.Grilla.AgregarFiltroEnLinea(ugPedidosClientes, {Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                                                  Entidades.Producto.Columnas.NombreProducto.ToString(),
                                                                  Entidades.PedidoEstado.Columnas.Observacion.ToString(),
                                                                  "NombreVendedor"})

         Ayudante.Grilla.AgregarFiltroEnLinea(ugPedidosProveedores, {Entidades.Proveedor.Columnas.NombreProveedor.ToString(),
                                                                     Entidades.Producto.Columnas.NombreProducto.ToString(),
                                                                     Entidades.PedidoEstadoProveedor.Columnas.Observacion.ToString(),
                                                                     "NombreComprador"})

         Ayudante.Grilla.AgregarFiltroEnLinea(ugResumen, {Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                                          Entidades.Producto.Columnas.NombreProducto.ToString(),
                                                          Entidades.Proveedor.Columnas.NombreProveedor.ToString()})

         tbcVinculaciones.SelectedTab = tbpResumen
         _titResumen = GetColumnasVisiblesGrilla(ugResumen)
         tbcVinculaciones.SelectedTab = tbpVincular

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

         GuardarVinculosDePedidos()

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

#Region "Eventos Vincular/Desvincular"
   Private Sub btnVincular_Click(sender As Object, e As EventArgs) Handles btnVincular.Click
      Try
         ugPedidosClientes.EndUpdate()
         ugPedidosProveedores.EndUpdate()
         VincularPedidos(GetActiveRow(ugPedidosClientes), GetActiveRow(ugPedidosProveedores))
         ugPedidosClientes.DisplayLayout.Bands(0).SortedColumns.RefreshSort(False)
         ugPedidosProveedores.DisplayLayout.Bands(0).SortedColumns.RefreshSort(False)
         _dtPedidosClientes.AcceptChanges()
         _dtPedidosProveedores.AcceptChanges()
         CargaGrillaResumen()
      Catch ex As Exception
         _dtPedidosClientes.RejectChanges()
         _dtPedidosProveedores.RejectChanges()
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnDesvincular_Click(sender As Object, e As EventArgs) Handles btnDesvincular.Click
      Try
         ugPedidosClientes.EndUpdate()
         ugPedidosProveedores.EndUpdate()
         DesvincularPedidos(GetActiveRow(ugPedidosClientes), GetActiveRow(ugPedidosProveedores))
         ugPedidosClientes.DisplayLayout.Bands(0).SortedColumns.RefreshSort(False)
         ugPedidosProveedores.DisplayLayout.Bands(0).SortedColumns.RefreshSort(False)
         _dtPedidosClientes.AcceptChanges()
         _dtPedidosProveedores.AcceptChanges()
         CargaGrillaResumen()
      Catch ex As Exception
         _dtPedidosClientes.RejectChanges()
         _dtPedidosProveedores.RejectChanges()
         ShowError(ex)
      End Try
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If GetCantidadPedidos(_dtPedidosClientes) > 0 And GetCantidadPedidos(_dtPedidosProveedores) > 0 Then
            Me.btnConsultar.Focus()
         Else
            If GetCantidadPedidos(_dtPedidosClientes) = 0 And GetCantidadPedidos(_dtPedidosProveedores) = 0 Then
               ShowMessage("ATENCION: ¡NO hay Pedidos que cumplan con la selección!")
            ElseIf GetCantidadPedidos(_dtPedidosClientes) = 0 Then
               ShowMessage("ATENCION: ¡NO hay Pedidos de Clientes que cumplan con la selección!")
            ElseIf GetCantidadPedidos(_dtPedidosProveedores) = 0 Then
               ShowMessage("ATENCION: ¡NO hay Pedidos de Proveedores que cumplan con la selección!")
            End If
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

   End Sub

   Private Sub GuardarVinculosDePedidos()
      If ValidaVinculosDePedidos() Then
         If ShowPregunta("¿Desea vincular los pedidos seleccionados?") = Windows.Forms.DialogResult.Yes Then
            Dim rPEP As Reglas.PedidosEstadosProveedores = New Reglas.PedidosEstadosProveedores()
            rPEP.VincularPedidos(_dtPedidosClientes, IdFuncion, _tipoEstadoPedidoCliente, _tipoEstadoPedidoProveedor)
            CargaGrillaDetalle()
            ShowMessage("Vinculación realizada exitosamente!")
         End If            'If ShowPregunta("¿Desea vincular los pedidos seleccionados?") = Windows.Forms.DialogResult.Yes Then
      End If
   End Sub

   Private Function ValidaVinculosDePedidos() As Boolean

      If _dtPedidosClientes Is Nothing OrElse _dtPedidosClientes.Select("Vinculado <> ''").Length = 0 Then
         ShowMessage("No ha vinculado ningún pedido. Por favor reintente.")
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
      Me.tssRegistros.Text = String.Format("{0} Pedidos Clientes / {0} Pedidos Proveedores",
                                           GetCantidadPedidos(_dtPedidosClientes), GetCantidadPedidos(_dtPedidosProveedores))
   End Sub

   Public Sub CargaGrillaDetalle()
      CargaGrillaDetallePedidosClientes()
      CargaGrillaDetallePedidosProveedores()
   End Sub

   Public Sub CargaGrillaDetallePedidosClientes()
      Dim rPedidos As Reglas.PedidosEstados = New Reglas.PedidosEstados()
      _dtPedidosClientes = rPedidos.GetPedidoParaVincular(cmbEstadosPedidosClientes.SelectedValue.ToString())
      _dtPedidosClientes.AcceptChanges()

      ugPedidosClientes.DataSource = _dtPedidosClientes

      CargaGrillaResumen()
   End Sub

   Public Sub CargaGrillaResumen()
      Dim dt As DataTable = _dtPedidosClientes.Clone()
      dt.ImportRowRange(_dtPedidosClientes.Select("Vinculado <> ''"))
      ugResumen.DataSource = dt

      AjustarColumnasGrilla(ugResumen, _titResumen)

   End Sub

   Public Sub CargaGrillaDetallePedidosProveedores()
      Dim rPedidos As Reglas.PedidosEstadosProveedores = New Reglas.PedidosEstadosProveedores()
      _dtPedidosProveedores = rPedidos.GetPedidoParaVincular(cmbEstadosPedidosProveedores.SelectedValue.ToString())
      _dtPedidosProveedores.AcceptChanges()

      ugPedidosProveedores.DataSource = _dtPedidosProveedores



   End Sub

   Private Function ValidaSiPedidoYaEstaVinculado(drPedido As DataRow) As Boolean
      If Not String.IsNullOrWhiteSpace(drPedido("Vinculado").ToString()) Then
         ShowMessage(String.Format("El {0} {1} {2:0000}-{3:00000000} línea {4} ya se encuentra vinculado con el {5} {6} {7:0000}-{8:00000000} línea {9}",
                                   drPedido("DescripcionAbrev"),
                                   drPedido("Letra"),
                                   drPedido("CentroEmisor"),
                                   drPedido("NumeroPedido"),
                                   drPedido("Orden"),
                                   drPedido("DescripcionAbrevVinculado"),
                                   drPedido("LetraVinculado"),
                                   drPedido("CentroEmisorVinculado"),
                                   drPedido("NumeroPedidoVinculado"),
                                   drPedido("OrdenVinculado")))
         Return False
      End If
      Return True
   End Function

   Private Function ValidarVinculacion(drPedidoCliente As DataRow, drPedidoProveedor As DataRow) As Boolean
      If Not ValidaSiPedidoYaEstaVinculado(drPedidoCliente) Then
         Return False
      End If
      If Not ValidaSiPedidoYaEstaVinculado(drPedidoProveedor) Then
         Return False
      End If

      If Not drPedidoCliente(Entidades.PedidoEstado.Columnas.IdProducto.ToString).Equals(drPedidoProveedor(Entidades.PedidoEstadoProveedor.Columnas.IdProducto.ToString)) Then
         ShowMessage(String.Format("Los productos de los pedidos deben coincidir" + Environment.NewLine + Environment.NewLine +
                                   "Producto de {0} {1} {2:0000} {3:00000000} línea {4}: {5} - {6}" + Environment.NewLine + Environment.NewLine +
                                   "Producto de {7} {8} {9:0000} {10:00000000} línea {11}: {12} - {13}",
                                   drPedidoCliente("DescripcionAbrev"),
                                   drPedidoCliente("Letra"),
                                   drPedidoCliente("CentroEmisor"),
                                   drPedidoCliente("NumeroPedido"),
                                   drPedidoCliente("Orden"),
                                   drPedidoCliente("IdProducto"),
                                   drPedidoCliente("NombreProducto"),
                                   drPedidoProveedor("DescripcionAbrev"),
                                   drPedidoProveedor("Letra"),
                                   drPedidoProveedor("CentroEmisor"),
                                   drPedidoProveedor("NumeroPedido"),
                                   drPedidoProveedor("Orden"),
                                   drPedidoProveedor("IdProducto"),
                                   drPedidoProveedor("NombreProducto")))
         Return False
      End If

      Return True
   End Function
   Private Sub VincularPedidos(drPedidoCliente As DataRow, drPedidoProveedor As DataRow)
      If drPedidoCliente Is Nothing Or drPedidoProveedor Is Nothing Then Exit Sub

      If ValidarVinculacion(drPedidoCliente, drPedidoProveedor) Then
         Dim cantidadPedidoCliente As Decimal = 0
         Dim cantidadPedidoProveedor As Decimal = 0

         If IsNumeric(drPedidoCliente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()) Then
            cantidadPedidoCliente = Decimal.Parse(drPedidoCliente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString())
         End If
         If IsNumeric(drPedidoProveedor(Entidades.PedidoEstadoProveedor.Columnas.CantEstado.ToString()).ToString()) Then
            cantidadPedidoProveedor = Decimal.Parse(drPedidoProveedor(Entidades.PedidoEstadoProveedor.Columnas.CantEstado.ToString()).ToString())
         End If

         If cantidadPedidoCliente = cantidadPedidoProveedor Then
            AsignarVinculo(drPedidoCliente, drPedidoProveedor)
            AsignarVinculo(drPedidoProveedor, drPedidoCliente)
         Else
            Dim cantidadVincular As Decimal = Math.Min(cantidadPedidoCliente, cantidadPedidoProveedor)
            Dim drPedidoClienteVincular As DataRow
            Dim drPedidoProveedorVincular As DataRow

            If cantidadPedidoCliente > cantidadPedidoProveedor Then
               drPedidoClienteVincular = drPedidoCliente.Table.NewRow()
               drPedidoClienteVincular.ItemArray = drPedidoCliente.ItemArray
               drPedidoClienteVincular(Entidades.PedidoEstado.Columnas.CantEstado.ToString()) = cantidadVincular
               drPedidoCliente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()) = Decimal.Parse(drPedidoCliente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()) - cantidadVincular
               drPedidoCliente.Table.Rows.InsertAt(drPedidoClienteVincular, drPedidoCliente.Table.Rows.IndexOf(drPedidoCliente))
            Else
               drPedidoClienteVincular = drPedidoCliente
            End If

            If cantidadPedidoProveedor > cantidadPedidoCliente Then
               drPedidoProveedorVincular = drPedidoProveedor.Table.NewRow()
               drPedidoProveedorVincular.ItemArray = drPedidoProveedor.ItemArray
               drPedidoProveedorVincular(Entidades.PedidoEstadoProveedor.Columnas.CantEstado.ToString()) = cantidadVincular
               drPedidoProveedor(Entidades.PedidoEstadoProveedor.Columnas.CantEstado.ToString()) = Decimal.Parse(drPedidoProveedor(Entidades.PedidoEstadoProveedor.Columnas.CantEstado.ToString()).ToString()) - cantidadVincular
               drPedidoProveedor.Table.Rows.InsertAt(drPedidoProveedorVincular, drPedidoProveedor.Table.Rows.IndexOf(drPedidoProveedor))
               'drPedidoProveedor.Table.Rows.Add(drPedidoProveedorVincular)
            Else
               drPedidoProveedorVincular = drPedidoProveedor
            End If
            AsignarVinculo(drPedidoClienteVincular, drPedidoProveedorVincular)
            AsignarVinculo(drPedidoProveedorVincular, drPedidoClienteVincular)
         End If
      End If            'If ValidarVinculacion(drPedidoCliente, drPedidoProveedor) Then
   End Sub

   Private Sub AsignarVinculo(drPedido As DataRow, drPedidoVinculado As DataRow)
      Dim campoVinculado As String = IIf(drPedido.Table.Columns.Contains("NombreProveedorVinculado"), "NombreProveedorVinculado", "NombreClienteVinculado").ToString()
      If drPedidoVinculado IsNot Nothing Then
         Dim campoOrigen As String = IIf(drPedidoVinculado.Table.Columns.Contains("NombreProveedor"), "NombreProveedor", "NombreCliente").ToString()
         drPedido("IdSucursalVinculado") = drPedidoVinculado("IdSucursal")
         drPedido("IdTipoComprobanteVinculado") = drPedidoVinculado("IdTipoComprobante")
         drPedido("DescripcionAbrevVinculado") = drPedidoVinculado("DescripcionAbrev")
         drPedido("LetraVinculado") = drPedidoVinculado("Letra")
         drPedido("CentroEmisorVinculado") = drPedidoVinculado("CentroEmisor")
         drPedido("NumeroPedidoVinculado") = drPedidoVinculado("NumeroPedido")
         drPedido("OrdenVinculado") = drPedidoVinculado("Orden")
         drPedido("FechaEstadoVinculado") = drPedidoVinculado("FechaEstado")
         drPedido("IdProductoVinculado") = drPedidoVinculado("IdProducto")
         drPedido("IdProductoVinculado") = drPedidoVinculado("IdProducto")
         drPedido(campoVinculado) = drPedidoVinculado(campoOrigen)
         drPedido("Vinculado") = "VINCULADO"
      Else
         drPedido("IdSucursalVinculado") = DBNull.Value
         drPedido("IdTipoComprobanteVinculado") = ""
         drPedido("DescripcionAbrevVinculado") = ""
         drPedido("LetraVinculado") = ""
         drPedido("CentroEmisorVinculado") = DBNull.Value
         drPedido("NumeroPedidoVinculado") = DBNull.Value
         drPedido("OrdenVinculado") = DBNull.Value
         drPedido("FechaEstadoVinculado") = DBNull.Value
         drPedido("IdProductoVinculado") = ""
         drPedido(campoVinculado) = ""
         drPedido("Vinculado") = ""
      End If
   End Sub

   Private Sub DesvincularPedidos(drPedidoCliente As DataRow, drPedidoProveedor As DataRow)
      If drPedidoCliente Is Nothing And drPedidoProveedor Is Nothing Then Exit Sub

      Dim drPedidoClienteADesvincular As DataRow
      Dim drPedidoProveedorADesvincular As DataRow

      Dim mensajeConfirmacion As String

      If drPedidoCliente IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(drPedidoCliente("Vinculado").ToString()) Then
         drPedidoClienteADesvincular = drPedidoCliente
         drPedidoProveedorADesvincular = BuscarPedidoVinculado(drPedidoCliente, _dtPedidosProveedores)

         mensajeConfirmacion = String.Format("¿Desea Desvincular el {0} {1} {2:0000}-{3:00000000}?",
                                             drPedidoCliente("DescripcionAbrev"),
                                             drPedidoCliente("Letra"),
                                             drPedidoCliente("CentroEmisor"),
                                             drPedidoCliente("NumeroPedido"))
      ElseIf drPedidoProveedor IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(drPedidoProveedor("Vinculado").ToString()) Then
         drPedidoClienteADesvincular = BuscarPedidoVinculado(drPedidoProveedor, _dtPedidosClientes)
         drPedidoProveedorADesvincular = drPedidoProveedor

         mensajeConfirmacion = String.Format("¿Desea Desvincular el {0} {1} {2:0000}-{3:00000000}?",
                                             drPedidoProveedor("DescripcionAbrev"),
                                             drPedidoProveedor("Letra"),
                                             drPedidoProveedor("CentroEmisor"),
                                             drPedidoProveedor("NumeroPedido"))
      End If

      If drPedidoClienteADesvincular IsNot Nothing AndAlso drPedidoProveedorADesvincular IsNot Nothing Then
         If ShowPregunta(mensajeConfirmacion) = Windows.Forms.DialogResult.Yes Then

            Dim drPedidoClienteOriginal As DataRow = BuscarPedidoOriginal(drPedidoClienteADesvincular, _dtPedidosClientes)
            Dim drPedidoProveedorOriginal As DataRow = BuscarPedidoOriginal(drPedidoProveedorADesvincular, _dtPedidosProveedores)

            AsignarVinculo(drPedidoClienteADesvincular, Nothing)
            AsignarVinculo(drPedidoProveedorADesvincular, Nothing)

            If drPedidoClienteOriginal IsNot Nothing Then
               drPedidoClienteOriginal(Entidades.PedidoEstado.Columnas.CantEstado.ToString()) = Decimal.Parse(drPedidoClienteOriginal(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()) +
                                                                                                Decimal.Parse(drPedidoClienteADesvincular(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString())
               _dtPedidosClientes.Rows.Remove(drPedidoClienteADesvincular)
            End If

            If drPedidoProveedorOriginal IsNot Nothing Then
               drPedidoProveedorOriginal(Entidades.PedidoEstadoProveedor.Columnas.CantEstado.ToString()) = Decimal.Parse(drPedidoProveedorOriginal(Entidades.PedidoEstadoProveedor.Columnas.CantEstado.ToString()).ToString()) +
                                                                                                           Decimal.Parse(drPedidoProveedorADesvincular(Entidades.PedidoEstadoProveedor.Columnas.CantEstado.ToString()).ToString())
               _dtPedidosProveedores.Rows.Remove(drPedidoProveedorADesvincular)
            End If
         End If
      End If

   End Sub

   Private Function BuscarPedidoOriginal(drPedido As DataRow, dtPedidos As DataTable) As DataRow
      Dim drCol As DataRow()
      drCol = dtPedidos.Select(String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroPedido = {4} AND Orden = {5} AND IdProducto = '{6}' AND FechaEstado = #{7:MM/dd/yyyy HH:mm:ss}# AND Vinculado = ''",
                                             drPedido("IdSucursal"),
                                             drPedido("IdTipoComprobante"),
                                             drPedido("Letra"),
                                             drPedido("CentroEmisor"),
                                             drPedido("NumeroPedido"),
                                             drPedido("Orden"),
                                             drPedido("IdProducto"),
                                             drPedido("FechaEstado")))
      If drCol.Length = 0 Then
         Return Nothing
      Else
         Return drCol(0)
      End If
   End Function

   Private Function BuscarPedidoVinculado(drConVinculadoABuscar As DataRow, dtDondeBuscarElVinculado As DataTable) As DataRow
      Dim drCol As DataRow()
      drCol = dtDondeBuscarElVinculado.Select(String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroPedido = {4} AND Orden = {5} AND IdProducto = '{6}' AND FechaEstado = #{7:MM/dd/yyyy HH:mm:ss}# AND " +
                                                            "IdSucursalVinculado = {8} AND IdTipoComprobanteVinculado = '{9}' AND LetraVinculado = '{10}' AND CentroEmisorVinculado = {11} AND NumeroPedidoVinculado = {12} AND OrdenVinculado = {13} AND IdProductoVinculado = '{14}' AND FechaEstadoVinculado = #{15:MM/dd/yyyy HH:mm:ss}#",
                                                            drConVinculadoABuscar("IdSucursalVinculado"),
                                                            drConVinculadoABuscar("IdTipoComprobanteVinculado"),
                                                            drConVinculadoABuscar("LetraVinculado"),
                                                            drConVinculadoABuscar("CentroEmisorVinculado"),
                                                            drConVinculadoABuscar("NumeroPedidoVinculado"),
                                                            drConVinculadoABuscar("OrdenVinculado"),
                                                            drConVinculadoABuscar("IdProductoVinculado"),
                                                            drConVinculadoABuscar("FechaEstadoVinculado"),
                                                            drConVinculadoABuscar("IdSucursal"),
                                                            drConVinculadoABuscar("IdTipoComprobante"),
                                                            drConVinculadoABuscar("Letra"),
                                                            drConVinculadoABuscar("CentroEmisor"),
                                                            drConVinculadoABuscar("NumeroPedido"),
                                                            drConVinculadoABuscar("Orden"),
                                                            drConVinculadoABuscar("IdProducto"),
                                                            drConVinculadoABuscar("FechaEstado")))
      If drCol.Length = 0 Then
         Return Nothing
      Else
         Return drCol(0)
      End If
   End Function

#End Region
End Class