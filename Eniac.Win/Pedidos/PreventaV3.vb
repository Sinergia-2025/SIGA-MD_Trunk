#Region "Imports"
Imports System
Imports System.IO
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
#End Region
Public Class PreventaV3

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Try
         Me._publicos = New Publicos()

         If Reglas.Publicos.PedidosWebFormato = Entidades.PreVenta.FormatoWebPeridos.SiMovilPedidos.ToString() Then
            With ugPedidos.DisplayLayout.Bands(0)
               .Columns(DsPreventa.Pedido.NumeroPedidoColumn.ColumnName.ToString()).Hidden = True
               .Columns(DsPreventa.Pedido.FechaRecepcionWebColumn.ColumnName.ToString()).Hidden = False
            End With
         End If

         ugPedidos.AgregarFiltroEnLinea({DsPreventa.Pedido.NombreClienteColumn.ColumnName,
                                         DsPreventa.Pedido.DireccionColumn.ColumnName,
                                         DsPreventa.Pedido.ObservacionesColumn.ColumnName,
                                         DsPreventa.Pedido.MensajeErrorColumn.ColumnName})

         ugPedidosProductos.AgregarFiltroEnLinea({DsPreventa.PedidoProducto.NombreProductoColumn.ColumnName,
                                                  DsPreventa.PedidoProducto.NotaBonifColumn.ColumnName,
                                                  DsPreventa.PedidoProducto.NotaCambioColumn.ColumnName,
                                                  DsPreventa.PedidoProducto.MensajeErrorColumn.ColumnName})

         chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F4 Then
            If utcPreventa.SelectedTab.Index = 0 Then
               utcPreventa.SelectedTab = utcPreventa.Tabs(1)
            ElseIf utcPreventa.SelectedTab.Index = 1 Then
               If tsbGenerarPedidos.Enabled And tsbGenerarPedidos.Visible Then
                  tsbGenerarPedidos.PerformClick()
               End If
            End If
            Return True
         ElseIf keyData = Keys.F5 Then
            tsbRefrescar.PerformClick()
            Return True
         ElseIf keyData = Keys.F3 Then
            tsbCambiarProducto.PerformClick()
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar Principal"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Me.LimpiarTodo()
   End Sub

   Private Sub tsbGenerarPedidos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbGenerarPedidos.Click
      Try
         Cursor = Cursors.WaitCursor
         tsbGenerarPedidos.Enabled = False
         Me.GrabarPedidos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         tsbGenerarPedidos.Enabled = True
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos Toolbar Secundaria"
   Private Sub tsbCambiarEstado_Click(sender As Object, e As EventArgs) Handles tsbCambiarEstado.Click
      Try
         If ugPedidos.ActiveRow IsNot Nothing AndAlso ugPedidos.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugPedidos.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row IsNot Nothing AndAlso
            TypeOf (DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row) Is Entidades.DsPreventa.PedidoRow Then

            Dim dr As Entidades.DsPreventa.PedidoRow = DirectCast(DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row, Entidades.DsPreventa.PedidoRow)
            Using frm As New PreventaV3CambioEstado()
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

   Private Sub tsbCambiarProducto_Click(sender As Object, e As EventArgs) Handles tsbCambiarProducto.Click
      Try
         Dim dr As DsPreventa.PedidoProductoRow = ugPedidosProductos.FilaSeleccionada(Of DsPreventa.PedidoProductoRow)()
         If dr IsNot Nothing AndAlso dr.ConError_ProductoInexistente Then
            ugPedidosProductos.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
            Using frm As PreventaV3CambioProducto = New PreventaV3CambioProducto()
               If frm.ShowDialog(Me, ugPedidos.FilaSeleccionada(Of DsPreventa.PedidoRow)(), dr) = Windows.Forms.DialogResult.OK Then
                  Dim regla As Reglas.ServiciosRest.Pedidos.BasePedidosWeb = New Reglas.PreVenta().NewBasePedidosWeb()
                  regla.AgregarMensajeErrorSegunBanderas(DsPreventa)
                  MuestraCantidadRegistros()
               End If
            End Using
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbEliminaWeb_Click(sender As Object, e As EventArgs) Handles tsbEliminaWeb.Click
      Try
         MarcarPedidoComoProcesado()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Eventos Grillas"
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
               e.Row.Appearance.BackColor = Nothing
               e.Row.Cells(DsPreventa.Pedido.PasaColumn.ColumnName).Appearance.BackColor = Color.LightGreen
               e.Row.Cells(DsPreventa.Pedido.PasaColumn.ColumnName).ActiveAppearance.BackColor = Color.LightGreen
            End If

            If dr.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.CONERROR.ToString() Then
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).Appearance.BackColor = Color.OrangeRed
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).ActiveAppearance.BackColor = Color.OrangeRed

            ElseIf dr.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.GRABADO.ToString() Then
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).Appearance.BackColor = Color.LightGreen
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).ActiveAppearance.BackColor = Color.LightGreen

            ElseIf dr.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.MARCADO.ToString() Then
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).Appearance.BackColor = Color.Yellow
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).ActiveAppearance.BackColor = Color.Yellow

            ElseIf dr.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.PROCESANDO.ToString() Then
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).Appearance.BackColor = Color.LightBlue
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).ActiveAppearance.BackColor = Color.LightBlue

            ElseIf dr.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.EXISTE.ToString() Then
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).Appearance.BackColor = Color.LightCoral
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).ActiveAppearance.BackColor = Color.LightCoral

            Else
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).Appearance.BackColor = Nothing
               e.Row.Cells(DsPreventa.Pedido.EstadoGrabacionColumn.ColumnName).ActiveAppearance.BackColor = Nothing

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

            tsbEliminaWeb.Enabled = dr.ArchivoRow.FormatoArchivo.Equals(Entidades.PreVenta.PreventaFormatoArchivo.Web)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugPedidosProductos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugPedidosProductos.InitializeRow
      Try
         Dim dr As Entidades.DsPreventa.PedidoProductoRow = ugPedidosProductos.FilaSeleccionada(Of Entidades.DsPreventa.PedidoProductoRow)(e.Row)

         If dr IsNot Nothing Then
            'Dim dr As Entidades.DsPreventa.PedidoRow = DirectCast(DirectCast(e.Row.ListObject, DataRowView).Row, Entidades.DsPreventa.PedidoRow)
            If dr.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.ConError) Or dr.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.Corregible) Then
               e.Row.Appearance.BackColor = Color.OrangeRed
               e.Row.Cells(DsPreventa.PedidoProducto.IdProductoColumn.ColumnName).Appearance.BackColor = Color.OrangeRed
               e.Row.Cells(DsPreventa.PedidoProducto.IdProductoColumn.ColumnName).ActiveAppearance.BackColor = Color.OrangeRed
            ElseIf dr.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.Advertencia) Then
               e.Row.Appearance.BackColor = Color.Yellow
               e.Row.Cells(DsPreventa.PedidoProducto.IdProductoColumn.ColumnName).Appearance.BackColor = Color.Yellow
               e.Row.Cells(DsPreventa.PedidoProducto.IdProductoColumn.ColumnName).ActiveAppearance.BackColor = Color.Yellow
            Else
               e.Row.Appearance.BackColor = Nothing
               e.Row.Cells(DsPreventa.PedidoProducto.IdProductoColumn.ColumnName).Appearance.BackColor = Color.LightGreen
               e.Row.Cells(DsPreventa.PedidoProducto.IdProductoColumn.ColumnName).ActiveAppearance.BackColor = Color.LightGreen
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub ugPedidosProductos_AfterRowActivate(sender As Object, e As EventArgs) Handles ugPedidosProductos.AfterRowActivate
      Try
         Dim dr As DsPreventa.PedidoProductoRow = ugPedidosProductos.FilaSeleccionada(Of DsPreventa.PedidoProductoRow)()
         tsbCambiarProducto.Enabled = False
         If dr IsNot Nothing Then
            tsbCambiarProducto.Enabled = dr.ConError_ProductoInexistente
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

   Private Sub btnAgregarPedidosWeb_Click(sender As Object, e As EventArgs) Handles btnAgregarPedidosWeb.Click
      Try
         Dim rPreVenta As Reglas.PreVenta = New Reglas.PreVenta()
         If rPreVenta.PermiteSeleccionarRutasPedidosPendientes() Then
            Using frm As New PreventaV3SeleccionarRutasPedidosPendientes()
               If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                  Me.Cursor = Cursors.WaitCursor
                  DsPreventa.TipoComprobantes = frm.tiposComprobantes
                  rPreVenta.AgregarPedidoWeb(DsPreventa, frm.RutasSeleccionadas)
               End If
            End Using
         Else
            rPreVenta.AgregarPedidoWeb(DsPreventa, Nothing)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         MuestraCantidadRegistros()
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
         Me.Cursor = Cursors.Default
      End Try
   End Sub

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
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub btnAgregarDirectorio_Click(sender As Object, e As EventArgs) Handles btnAgregarDirectorio.Click
      Me.Cursor = Cursors.WaitCursor
      Try
         Dim rPreVenta As Reglas.PreVenta = New Reglas.PreVenta()

         If fbdDirectorio.ShowDialog() = DialogResult.OK Then
            For Each fileName As String In Directory.GetFiles(fbdDirectorio.SelectedPath, "*.txt", SearchOption.TopDirectoryOnly)
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
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub utcPreventa_SelectedTabChanged(sender As Object, e As UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcPreventa.SelectedTabChanged
      MuestraControlesToolbar(utcPreventa.SelectedTab.Key = "tbpPedidos")
   End Sub

#End Region

#Region "Métodos"
   Private Sub GrabarNombreArchivoTXT(ByVal Id As Integer, _
                              ByVal FileNamePed As String, _
                              ByVal IdEmpleado As Integer, _
                              ByVal Fecha As Date)

      Dim oLineaDetalle As Entidades.PreVenta = New Entidades.PreVenta()
      Dim oLineaDetalles As Reglas.PreVenta = New Reglas.PreVenta()

      oLineaDetalle.IdPreVenta = oLineaDetalles.GetProximoId
      oLineaDetalle.IdSucursal = actual.Sucursal.Id
      oLineaDetalle.FileNamePed = FileNamePed
      oLineaDetalle.Usuario = actual.Nombre
      oLineaDetalle.Vendedor = New Eniac.Reglas.Empleados().GetUno(IdEmpleado)
      oLineaDetalle.Fecha = Fecha
      oLineaDetalles.Insertar(oLineaDetalle)
   End Sub

   Private Sub GrabarPedidos()

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

      If ShowPregunta(String.Format("¿Desea generar los {0} pedidos?",
                                    DsPreventa.Pedido.Where(Function(x) x.Pasa And x.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.PENDIENTE.ToString()).Count)) _
                     = Windows.Forms.DialogResult.Yes Then
         If Not String.IsNullOrWhiteSpace(Reglas.Publicos.PedidosURLWebPUT) OrElse
            ShowPregunta("No está configurada la URL para marcar los pedidos como procesados. ¿Desea continuar?") = Windows.Forms.DialogResult.Yes Then
            Dim rPreVenta As Reglas.PreVenta = New Reglas.PreVenta()

            Dim pedidosGenerados As List(Of Entidades.Pedido)

            pedidosGenerados = rPreVenta.GrabarPedidos(DsPreventa, dtpFechaEnvio.Value)

            Dim imprimirPedidos As Boolean
            Dim preventaImprimirPedidos As String = Reglas.Publicos.PreventaImprimirPedidos
            If preventaImprimirPedidos = Reglas.Publicos.SiempreNuncaPreguntar.PREGUNTAR.ToString() Then
               imprimirPedidos = ShowPregunta("¿Desea imprimir los pedidos generados?") = Windows.Forms.DialogResult.Yes
            Else
               imprimirPedidos = preventaImprimirPedidos = Reglas.Publicos.SiempreNuncaPreguntar.SIEMPRE.ToString()
            End If

            If imprimirPedidos Then
               Dim filtros As ImpresionMasivaPedido.FiltrosPredeterminados
               filtros = New ImpresionMasivaPedido.FiltrosPredeterminados() With {.ConsultaAutomatica = True}
               For Each pedido As Entidades.Pedido In pedidosGenerados
                  If Not filtros.NumeroDesde.HasValue OrElse filtros.NumeroDesde.Value > pedido.NumeroPedido Then filtros.NumeroDesde = pedido.NumeroPedido
                  If Not filtros.NumeroHasta.HasValue OrElse filtros.NumeroHasta.Value < pedido.NumeroPedido Then filtros.NumeroHasta = pedido.NumeroPedido

                  If Not filtros.FechaDesde.HasValue OrElse filtros.FechaDesde.Value > pedido.Fecha Then filtros.FechaDesde = pedido.Fecha
                  If Not filtros.FechaHasta.HasValue OrElse filtros.FechaHasta.Value < pedido.Fecha Then filtros.FechaHasta = pedido.Fecha
               Next
               Using frm As New ImpresionMasivaPedido()
                  frm.ShowDialog(filtros)
               End Using
            End If

         End If

         LimpiarTodo()

         MessageBox.Show("Pedidos generados exitosamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub LimpiarTodo()
      tsbGenerarPedidos.Enabled = False
      tslCantidadPedidos.Enabled = False
      tsbEliminaWeb.Enabled = False
      utcPreventa.SelectedTab = utcPreventa.Tabs(0)

      DsPreventa.Clear()
      MuestraCantidadRegistros()
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

         lblCantidadOK.Text = String.Format(lblCantidadOK.Tag.ToString(), cantidadOK)
         lblCantidadCorregir.Text = String.Format(lblCantidadCorregir.Tag.ToString(), cantidadParaCorregir)
         lblCantidadAdvertencia.Text = String.Format(lblCantidadAdvertencia.Tag.ToString(), cantidadWarning)
         lblCantidadError.Text = String.Format(lblCantidadError.Tag.ToString(), cantidadError)

         lblCantidadCorregir.Visible = cantidadParaCorregir > 0
         lblCantidadAdvertencia.Visible = cantidadWarning > 0
         lblCantidadError.Visible = cantidadError > 0
         lblCantidadOK.Visible = cantidadOK > 0 Or cantidadParaCorregir > 0 Or cantidadWarning > 0 Or cantidadError > 0

         tslCantidadPedidos.Text = String.Format(tslCantidadPedidos.Tag.ToString(), DsPreventa.Pedido.Count, cantidad)
         tsbGenerarPedidos.Enabled = cantidad > 0
      Catch ex As Exception
         tslCantidadPedidos.Text = String.Format(tslCantidadPedidos.Tag.ToString(), 0, 0)
      End Try
   End Sub

   Private Sub MarcarPedidoComoProcesado()
      Try
         If ugPedidos.ActiveRow IsNot Nothing AndAlso
            ugPedidos.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugPedidos.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row IsNot Nothing AndAlso
            TypeOf (DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row) Is Entidades.DsPreventa.PedidoRow Then
            Dim drPedido As Entidades.DsPreventa.PedidoRow = DirectCast(DirectCast(ugPedidos.ActiveRow.ListObject, DataRowView).Row, Entidades.DsPreventa.PedidoRow)
            If drPedido.ArchivoRow IsNot Nothing AndAlso
               drPedido.ArchivoRow.FormatoArchivo.Equals(Entidades.PreVenta.PreventaFormatoArchivo.Web) Then
               Dim stbMensaje As StringBuilder = New StringBuilder()
               If Reglas.Publicos.PedidosWebFormato = Entidades.PreVenta.FormatoWebPeridos.SiMovilPedidos.ToString() Then
                  stbMensaje.AppendFormat("El Pedido seleccionado ", drPedido.IdTipoComprobante, drPedido.Letra, drPedido.CentroEmisor, drPedido.NumeroPedido)
               Else
                  stbMensaje.AppendFormat("El {0} {1} {2:0000}-{3:0000} ", drPedido.IdTipoComprobante, drPedido.Letra, drPedido.CentroEmisor, drPedido.NumeroPedido)
               End If
               If drPedido.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.ConError) Or drPedido.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.Corregible) Then
                  stbMensaje.AppendFormat("posee errores.")
               Else
                  stbMensaje.AppendFormat("no se ha importado.")
               End If
               stbMensaje.AppendLine().AppendLine()
               stbMensaje.AppendFormat("¿Desea marcar el mismo como procesado?")
               If ShowPregunta(stbMensaje.ToString()) = Windows.Forms.DialogResult.Yes Then
                  stbMensaje = New StringBuilder()
                  stbMensaje.AppendLine("Al marcar el pedido como procesado no podrá volver a recuperar el mismo.")
                  stbMensaje.AppendLine().AppendLine("¿Está seguro de marcar el mismo como procesado?")
                  If ShowPregunta(stbMensaje.ToString()) = Windows.Forms.DialogResult.Yes Then
                     Cursor = Cursors.WaitCursor
                     Dim rPreVenta As Reglas.PreVenta = New Reglas.PreVenta()
                     rPreVenta.MarcarPedidoComoProcesado(drPedido)
                     drPedido.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.MARCADO.ToString()
                     ShowMessage("El pedido fue marcado exitosamente.")
                  End If
               End If
            End If
         End If
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub MuestraControlesToolbar(visible As Boolean)
      tssPedidos1.Visible = visible
      tssPedidos2.Visible = visible
      tssPedidos3.Visible = visible
      tsbGenerarPedidos.Visible = visible
      tsbCambiarEstado.Visible = visible
      tsbCambiarProducto.Visible = visible
      tsbEliminaWeb.Visible = visible

   End Sub
#End Region

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      Try
         With ugPedidosProductos.DisplayLayout.Bands(0)
            .Columns(DsPreventa.PedidoProducto.PrecioListaColumn.ColumnName).Hidden = chbConIVA.Checked
            .Columns(DsPreventa.PedidoProducto.PrecioColumn.ColumnName).Hidden = chbConIVA.Checked
            .Columns(DsPreventa.PedidoProducto.PrecioNetoColumn.ColumnName).Hidden = chbConIVA.Checked
            .Columns(DsPreventa.PedidoProducto.PrecioMovilColumn.ColumnName).Hidden = chbConIVA.Checked

            .Columns(DsPreventa.PedidoProducto.PrecioListaConIVAColumn.ColumnName).Hidden = Not chbConIVA.Checked
            .Columns(DsPreventa.PedidoProducto.PrecioConIVAColumn.ColumnName).Hidden = Not chbConIVA.Checked
            .Columns(DsPreventa.PedidoProducto.PrecioNetoConIVAColumn.ColumnName).Hidden = Not chbConIVA.Checked
            .Columns(DsPreventa.PedidoProducto.PrecioMovilConIVAColumn.ColumnName).Hidden = Not chbConIVA.Checked
         End With
      Catch ex As Exception

      End Try
   End Sub
End Class