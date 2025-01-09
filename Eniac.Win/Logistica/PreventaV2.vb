Imports System
Imports System.IO
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid

Public Class PreventaV2

#Region "Pedidos"
   Private _publicos As Publicos
   'Private _pedidosClientes As System.Collections.Generic.List(Of Entidades.Cliente)
   '' ''Private _ventasProductos As System.Collections.Generic.List(Of Eniac.Entidades.VentaProducto)
   '' ''Private _ventasObservaciones As List(Of Eniac.Entidades.VentaObservacion)
   Private _listaPreVenta As System.Collections.Generic.List(Of Entidades.PreVenta)
   Private _tipoImpuestoIVA As Eniac.Entidades.TipoImpuesto.Tipos = Eniac.Entidades.TipoImpuesto.Tipos.IVA
   Private _subTotales As System.Collections.Generic.List(Of Eniac.Entidades.VentaImpuesto)
   Private _categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal
   'Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   'Private _productoLoteTemporal As Eniac.Entidades.VentaProductoLote
   'Private _productosLotes As List(Of Eniac.Entidades.VentaProductoLote)
   Private _clienteE As Entidades.Cliente
   '' ''Private _pedidoSelect As Integer
   'Private _tipoComp As String = "PEDIDO"
   Private _letraComp As String = "X"
   Private CliInexistente As String = "CLIENTE INACTIVO o INEXISTENTE"
   Private estadoSindef As String = "ESTADO SIN DEFINIR"
   Private PedidoIngresado As String = "PEDIDO YA INGRESADO"
   Private SinArticulos As String = "PEDIDO SIN ARTICULOS"
   Private ArticulosConNovedades As String = "PEDIDO CON ARTICULOS CON NOVEDADES"
   Private cantsinProd As Integer = 0
   'Private _transportistaEnvio As Entidades.Transportista
   '' ''Private _argArticulos As List(Of Entidades.ArgPreVenta)
   '' ''Private _arPDA As Reglas.ArchivoPDA
   Private _NecesitaModificarParametros As Boolean
   Private _ParametrosAModificar As DataTable
#End Region

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Try
         Me._publicos = New Publicos()
         '' ''Me._ventasProductos = New System.Collections.Generic.List(Of Eniac.Entidades.VentaProducto)
         '' ''Me._ventasObservaciones = New List(Of Eniac.Entidades.VentaObservacion)

         _categoriaFiscalEmpresa = New Eniac.Reglas.CategoriasFiscales()._GetUno(Publicos.CategoriaFiscalEmpresa)

         _subTotales = New List(Of Eniac.Entidades.VentaImpuesto)

         '' ''_argArticulos = New List(Of Entidades.ArgPreVenta)()
         Dim oParametros As Eniac.Reglas.Parametros = New Eniac.Reglas.Parametros()
         _ParametrosAModificar = oParametros.GetParametrosDeOrganizarEntregasv2()
         If (_ParametrosAModificar.Rows.Count) <> 0 Then
            _NecesitaModificarParametros = True
         End If

         'TODO: quitar cuando se pueda corregir el problema del evento
         If Me._NecesitaModificarParametros Then
            Dim mensaje As StringBuilder = New StringBuilder("")

            With mensaje
               .AppendLine("Los parámetros no están configurados correctamente. ")
               .AppendLine("Debe modificar los siguientes parámetros: ")
               For index As Integer = 0 To (Me._ParametrosAModificar.Rows.Count - 1)
                  .AppendFormat("   - ""{0}"" (Solapa {1}).", Me._ParametrosAModificar.Rows(index)("Parámetro").ToString(),
                                                               Me._ParametrosAModificar.Rows(index)("Solapa").ToString())
                  .AppendLine()
               Next
            End With
            Me.utcPreventa.Enabled = False
            'Me.utpGenerarPedidos.Enabled = False
            'Me.utpImportar.Enabled = False
            'MessageBox.Show("Los parámetros no están configurados correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show(mensaje.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
         'hasta acá

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub





   ' '' Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
   ' ''     Me.Close()
   ' '' End Sub

   ' ''Private Sub tsbNuevoPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevoPedido.Click
   ' ''   '
   ' ''End Sub

   Private Sub tsbGenerarPedidos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbGenerarPedidos.Click
      Try
         If DsPreventa.Archivo.Count = 0 Then
            MessageBox.Show("No se han agregado archivos!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If DsPreventa.Pedido.Count = 0 Then
            MessageBox.Show("No hay Pedidos para Generar!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If DsPreventa.Pedido.Select(String.Format("{0} = {1}", DsPreventa.Pedido.PasaColumn.ColumnName, Boolean.TrueString)).Length = 0 Then
            MessageBox.Show("No hay Pedidos en condiciones de ingresar!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Cursor = Cursors.WaitCursor
         Me.GrabarPedidos()

         LimpiarTodo()

         MessageBox.Show("Pedidos generados exitosamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub


   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Me.LimpiarTodo()
   End Sub

   Private Sub GrabarNombreArchivoTXT(ByVal Id As Integer, _
                              ByVal FileNamePed As String, _
                              ByVal IdEmpleado As Integer, _
                              ByVal NroDocEmpleado As String, _
                              ByVal Fecha As Date)

      Dim oLineaDetalle As Entidades.PreVenta = New Entidades.PreVenta()
      Dim oLineaDetalles As Reglas.PreVenta = New Reglas.PreVenta()

      oLineaDetalle.IdPreVenta = oLineaDetalles.GetProximoId
      oLineaDetalle.IdSucursal = actual.Sucursal.Id
      oLineaDetalle.FileNamePed = FileNamePed
      oLineaDetalle.Usuario = actual.Nombre
      oLineaDetalle.Vendedor = New Eniac.Reglas.Empleados().GetUno(idEmpleado)
      oLineaDetalle.Fecha = Fecha
      oLineaDetalles.Insertar(oLineaDetalle)
   End Sub

   Private Sub GrabarPedidos()

      Dim rPreVenta As Reglas.PreVenta = New Reglas.PreVenta()
      rPreVenta.GrabarPedidos(DsPreventa, dtpFechaEnvio.Value)

   End Sub

   Private Sub LimpiarTodo()
      tsbGenerarPedidos.Enabled = False
      utcPreventa.SelectedTab = utcPreventa.Tabs(0)

      DsPreventa.Clear()
      MuestraCantidadRegistros()
      MuestraCantidadCambioYBonificacion()
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private _productosFiltrados As List(Of Eniac.Entidades.VentaProducto)

   Private Sub MuestraCantidadCambioYBonificacion()
      With ugPedidosProductos.DisplayLayout.Bands(0)
         .Columns("CantidadCambio").Hidden = DsPreventa.PedidoProducto.Select("CantidadCambio <> 0").Length = 0
         .Columns("CantidadBonif").Hidden = DsPreventa.PedidoProducto.Select("CantidadBonif <> 0").Length = 0
         .Columns("NotaCambio").Hidden = .Columns("CantidadCambio").Hidden
         .Columns("NotaBonif").Hidden = .Columns("CantidadBonif").Hidden
      End With
   End Sub
   Private Sub MuestraCantidadRegistros()
      Try
         Dim cantidad As Integer = DsPreventa.Pedido.Select(String.Format("{0} = {1}", DsPreventa.Pedido.PasaColumn.ColumnName, Boolean.TrueString)).Length
         Dim cantidadError As Integer = 0
         Dim cantidadWarning As Integer = 0
         Dim cantidadParaCorregir As Integer = 0
         Dim cantidadOK As Integer = 0

         For Each drPedido As DsPreventa.PedidoRow In DsPreventa.Pedido
            If drPedido.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.ConError) Then
               cantidadError += 1
            ElseIf drPedido.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.Advertencia) Then
               cantidadWarning += 1
            ElseIf drPedido.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.Corregible) Then
               cantidadParaCorregir += 1
            Else
               cantidadOK += 1
            End If
         Next

         tslCantidadOK.Text = String.Format(tslCantidadOK.Tag.ToString(), cantidadOK)
         tslCantidadCorregir.Text = String.Format(tslCantidadCorregir.Tag.ToString(), cantidadParaCorregir)
         tslCantidadAdvertencia.Text = String.Format(tslCantidadAdvertencia.Tag.ToString(), cantidadWarning)
         tslCantidadError.Text = String.Format(tslCantidadError.Tag.ToString(), cantidadError)

         tslCantidadCorregir.Visible = cantidadParaCorregir > 0
         tslCantidadAdvertencia.Visible = cantidadWarning > 0
         tslCantidadError.Visible = cantidadError > 0
         tslCantidadOK.Visible = cantidadParaCorregir > 0 Or cantidadWarning > 0 Or cantidadError > 0

         tslCantidadPedidos.Text = String.Format(tslCantidadPedidos.Tag.ToString(), DsPreventa.Pedido.Count, cantidad)
         tsbGenerarPedidos.Enabled = cantidad > 0
      Catch ex As Exception
         tslCantidadPedidos.Text = String.Format(tslCantidadPedidos.Tag.ToString(), 0, 0)
      End Try
   End Sub

   'Private Function CrearDT() As DataTable

   '   Dim dtTemp As DataTable = New DataTable()

   '   With dtTemp

   '      .Columns.Add("Pasa", System.Type.GetType("System.String"))
   '      .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
   '      .Columns.Add("Codigo", System.Type.GetType("System.String"))
   '      .Columns.Add("Comercio", System.Type.GetType("System.String"))
   '      .Columns.Add("Domicilio", System.Type.GetType("System.String"))

   '      .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
   '      .Columns.Add("TipoDocVendedor", System.Type.GetType("System.String"))
   '      .Columns.Add("NroDocVendedor", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
   '      .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
   '      .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
   '      .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreCliente2", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreZonaGeografica", System.Type.GetType("System.String"))
   '      .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
   '      .Columns.Add("DescripcionTipoComprobante", System.Type.GetType("System.String"))

   '      .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
   '      .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))

   '      .Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"))
   '      .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("Saldo", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("Total", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("IdFormasPago", System.Type.GetType("System.Int32"))
   '      .Columns.Add("DescripcionFormasPago", System.Type.GetType("System.String"))
   '      .Columns.Add("Observacion", System.Type.GetType("System.String"))
   '   End With

   '   Return dtTemp

   'End Function

   Private Sub btnAgregarArchivo_Click(sender As Object, e As EventArgs) Handles btnAgregarArchivo.Click
      Me.Cursor = Cursors.WaitCursor
      Try
         Dim rPreVenta As Reglas.PreVenta = New Reglas.PreVenta()

         If ofdArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            For Each fileName As String In ofdArchivo.FileNames
               Dim fiArchivo As FileInfo = New FileInfo(fileName)
               If fiArchivo.Exists Then
                  rPreVenta.AgregarArchivo(fiArchivo, DsPreventa)
               End If
            Next
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         MuestraCantidadRegistros()
         MuestraCantidadCambioYBonificacion()
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ugPedidos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugPedidos.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing AndAlso
            TypeOf (DirectCast(e.Row.ListObject, DataRowView).Row) Is Entidades.DsPreventa.PedidoRow Then
            Dim dr As Entidades.DsPreventa.PedidoRow = DirectCast(DirectCast(e.Row.ListObject, DataRowView).Row, Entidades.DsPreventa.PedidoRow)
            If dr.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.ConError) Or dr.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.Corregible) Then
               e.Row.Appearance.BackColor = Color.OrangeRed
               e.Row.Cells(DsPreventa.Pedido.PasaColumn.ColumnName).Appearance.BackColor = Color.OrangeRed
               e.Row.Cells(DsPreventa.Pedido.PasaColumn.ColumnName).ActiveAppearance.BackColor = Color.OrangeRed
            ElseIf dr.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.Advertencia) Then
               e.Row.Appearance.BackColor = Color.Yellow
               e.Row.Cells(DsPreventa.Pedido.PasaColumn.ColumnName).Appearance.BackColor = Color.Yellow
               e.Row.Cells(DsPreventa.Pedido.PasaColumn.ColumnName).ActiveAppearance.BackColor = Color.Yellow
            Else
               e.Row.Cells(DsPreventa.Pedido.PasaColumn.ColumnName).Appearance.BackColor = Color.LightGreen
               e.Row.Cells(DsPreventa.Pedido.PasaColumn.ColumnName).ActiveAppearance.BackColor = Color.LightGreen
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugPedidos_AfterRowActivate(sender As Object, e As EventArgs) Handles ugPedidos.AfterRowActivate
      Try
         If ugPedidos.ActiveRow IsNot Nothing AndAlso ugPedidos.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugPedidos.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row IsNot Nothing AndAlso
            TypeOf (DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row) Is Entidades.DsPreventa.PedidoRow Then

            Dim dr As Entidades.DsPreventa.PedidoRow = DirectCast(DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row, Entidades.DsPreventa.PedidoRow)

            PedidoProductoBindingSource.Filter = String.Format("{0} = '{1}' AND {2} = {3} AND {4} = {5}",
                                                               DsPreventa.PedidoProducto.NombreArchivoColumn.ColumnName,
                                                               dr.NombreArchivo,
                                                               DsPreventa.PedidoProducto.CentroEmisorColumn.ColumnName,
                                                               dr.CentroEmisor,
                                                               DsPreventa.PedidoProducto.NumeroPedidoColumn.ColumnName,
                                                               dr.NumeroPedido)

            Dim rPreventa As Reglas.PreVenta = New Reglas.PreVenta()
            tsbCambiarEstado.Enabled = dr.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.Corregible) And Not String.IsNullOrWhiteSpace(rPreventa.ValidaEstadoVisita(dr))

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAgregarDirectorio_Click(sender As Object, e As EventArgs) Handles btnAgregarDirectorio.Click
      Me.Cursor = Cursors.WaitCursor
      Try
         Dim rPreVenta As Reglas.PreVenta = New Reglas.PreVenta()

         If fbdDirectorio.ShowDialog() = DialogResult.OK Then
            For Each fileName As String In Directory.GetFiles(fbdDirectorio.SelectedPath,
                                                              "*.txt", SearchOption.TopDirectoryOnly)
               Dim fiArchivo As FileInfo = New FileInfo(fileName)
               If fiArchivo.Exists Then
                  rPreVenta.AgregarArchivo(fiArchivo, DsPreventa)
               End If
            Next
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         MuestraCantidadRegistros()
         MuestraCantidadCambioYBonificacion()
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnQuitarArchivo_Click(sender As Object, e As EventArgs) Handles btnQuitarArchivo.Click
      Try
         If ugArchivosImportados.ActiveRow IsNot Nothing AndAlso
            ugArchivosImportados.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugArchivosImportados.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugArchivosImportados.ActiveRow.ListObject, DataRowView).Row IsNot Nothing AndAlso
            TypeOf (DirectCast(ugArchivosImportados.ActiveRow.ListObject, DataRowView).Row) Is Entidades.DsPreventa.ArchivoRow Then
            Dim dr As Entidades.DsPreventa.ArchivoRow = DirectCast(DirectCast(ugArchivosImportados.ActiveRow.ListObject, DataRowView).Row, Entidades.DsPreventa.ArchivoRow)

            If MessageBox.Show(String.Format("¿Desea eliminar el archivo seleccionado ({0})?", dr.NombreArchivo),
                               Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim rPreVenta As Reglas.PreVenta = New Reglas.PreVenta()
               rPreVenta.BorrarArchivo(dr)
            End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         MuestraCantidadRegistros()
         MuestraCantidadCambioYBonificacion()
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbCambiarEstado_Click(sender As Object, e As EventArgs) Handles tsbCambiarEstado.Click
      Try
         If ugPedidos.ActiveRow IsNot Nothing AndAlso ugPedidos.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugPedidos.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row IsNot Nothing AndAlso
            TypeOf (DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row) Is Entidades.DsPreventa.PedidoRow Then

            Dim dr As Entidades.DsPreventa.PedidoRow = DirectCast(DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row, Entidades.DsPreventa.PedidoRow)
            Using frm As New PreventaV2CambioEstado()
               frm.Pedido = dr
               If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  tsbCambiarEstado.Enabled = dr.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.Corregible) And Not String.IsNullOrWhiteSpace(New Reglas.PreVenta().ValidaEstadoVisita(dr))
               End If
            End Using

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAgregarPedidosWeb_Click(sender As Object, e As EventArgs) Handles btnAgregarPedidosWeb.Click
      Me.Cursor = Cursors.WaitCursor
      Try
         Dim rPreVenta As Reglas.PreVenta = New Reglas.PreVenta()

         rPreVenta.AgregarPedidoWeb(DsPreventa, New List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         MuestraCantidadRegistros()
         MuestraCantidadCambioYBonificacion()
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   'TODO: encontrar la razón por qué esto no funciona
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
   End Sub
   Private Sub PreventaV2_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      Try
         If Me._NecesitaModificarParametros Then
            Dim mensaje As StringBuilder = New StringBuilder("")

            With mensaje
               .AppendLine("Los parámetros no están configurados correctamente. ")
               .AppendLine("Debe modificar los siguientes parámetros: ")
               For index As Integer = 0 To (Me._ParametrosAModificar.Rows.Count - 1)
                  .AppendFormat("   - ""{0}"" (Solapa {1}).", Me._ParametrosAModificar.Rows(index)("Parámetro").ToString(),
                                                               Me._ParametrosAModificar.Rows(index)("Solapa").ToString())
                  .AppendLine()
               Next
            End With
            'MessageBox.Show("Los parámetros no están configurados correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show(mensaje.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub ugPedidosProductos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugPedidosProductos.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing AndAlso
            TypeOf (DirectCast(e.Row.ListObject, DataRowView).Row) Is Entidades.DsPreventa.PedidoProductoRow Then
            Dim dr As Entidades.DsPreventa.PedidoProductoRow = DirectCast(DirectCast(e.Row.ListObject, DataRowView).Row, Entidades.DsPreventa.PedidoProductoRow)

            If dr.CantidadCambio <> 0 Then
               With e.Row.Cells(DirectCast(dr.Table, Entidades.DsPreventa.PedidoProductoDataTable).CantidadCambioColumn.ColumnName)
                  .Appearance.BackColor = Color.Yellow
                  .ActiveAppearance.BackColor = Color.Yellow
                  .Appearance.ForeColor = Color.Black
                  .ActiveAppearance.ForeColor = Color.Black
               End With
            End If

            If dr.CantidadBonif <> 0 Then
               With e.Row.Cells(DirectCast(dr.Table, Entidades.DsPreventa.PedidoProductoDataTable).CantidadBonifColumn.ColumnName)
                  .Appearance.BackColor = Color.Yellow
                  .ActiveAppearance.BackColor = Color.Yellow
                  .Appearance.ForeColor = Color.Black
                  .ActiveAppearance.ForeColor = Color.Black
               End With
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class