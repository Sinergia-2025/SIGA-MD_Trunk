Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class DespacharMercaderia

#Region "Campos"

   Private _publicos As Publicos
   'Private _puedeAnularComprobantes As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Me.cmbAfectaCaja.Items.Insert(0, "TODOS")
         Me.cmbAfectaCaja.Items.Insert(1, "SI")
         Me.cmbAfectaCaja.Items.Insert(2, "NO")
         Me.cmbAfectaCaja.SelectedIndex = 0

         Me.cmbMercDespachada.Items.Insert(0, "TODOS")
         Me.cmbMercDespachada.Items.Insert(1, "SI")
         Me.cmbMercDespachada.Items.Insert(2, "NO")
         Me.cmbMercDespachada.SelectedIndex = 0

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarVentas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbDespachar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDespachar.Click
      DespacharAnularDespacho(True)

      '' ''If Me.dgvDetalle.RowCount = 0 Then Exit Sub

      '' ''Me.dgvDetalle.EndEdit()

      '' ''Try
      '' ''   Me.Cursor = Cursors.WaitCursor
      '' ''   Dim colComprobantes As List(Of Entidades.Venta) = New List(Of Entidades.Venta)

      '' ''   Dim oVenta As Entidades.Venta
      '' ''   Dim oVentas As Reglas.Ventas = New Reglas.Ventas

      '' ''   tspBarra.Minimum = 0
      '' ''   tspBarra.Maximum = Me.dgvDetalle.Rows.Count
      '' ''   tspBarra.Value = 0
      '' ''   tspBarra.Step = 1
      '' ''   tspBarra.Visible = True
      '' ''   For Each dr1 As DataGridViewRow In Me.dgvDetalle.Rows()
      '' ''      tspBarra.PerformStep()
      '' ''      'If Boolean.Parse(dr1.Cells("MercDespachada").Value.ToString()) Then
      '' ''      oVenta = New Entidades.Venta

      '' ''      oVenta = oVentas.GetUna(actual.Sucursal.Id, dr1.Cells("IdTipoComprobante").Value.ToString(), _
      '' ''                             dr1.Cells("Letra").Value.ToString(), Short.Parse(dr1.Cells("CentroEmisor").Value.ToString()), _
      '' ''                              Long.Parse(dr1.Cells("NumeroComprobante").Value.ToString()))


      '' ''      oVenta.MercDespachada = Boolean.Parse(dr1.Cells("MercDespachada").Value.ToString())


      '' ''      oVenta.FechaEnvio = Nothing

      '' ''      oVenta.Transportista.idTransportista = 0

      '' ''      oVenta.NumeroReparto = 0

      '' ''      colComprobantes.Add(oVenta)
      '' ''      'End If

      '' ''   Next

      '' ''   tspBarra.Style = ProgressBarStyle.Marquee

      '' ''   oVentas.GrabarMercaderiaDespachada(colComprobantes)

      '' ''   tspBarra.Style = ProgressBarStyle.Continuous

      '' ''   MessageBox.Show("Los comprobantes se actualizaron correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      '' ''   Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())

      '' ''Catch ex As Exception
      '' ''   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '' ''Finally
      '' ''   Me.Cursor = Cursors.Default
      '' ''   tspBarra.Style = ProgressBarStyle.Continuous
      '' ''   tspBarra.Visible = False
      '' ''End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
         Else
            If Me.cmbTiposComprobantes.Items.Count > 0 Then
               Me.cmbTiposComprobantes.SelectedIndex = 0
            End If
         End If

         Me.cmbTiposComprobantes.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
   End Sub

   Private Sub chbNumeroReparto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumeroReparto.CheckedChanged
      Me.txtNumeroReparto.Enabled = Me.chbNumeroReparto.Checked
      If Not Me.chbNumeroReparto.Checked Then
         Me.txtNumeroReparto.Text = ""
      Else
         Me.txtNumeroReparto.Focus()
      End If
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Try
         Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
         Me.bscCliente.Enabled = Me.chbCliente.Checked


         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty

         Me.bscCodigoCliente.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
      Try
         Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

         If Not Me.chbVendedor.Checked Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            If Me.cmbVendedor.Items.Count > 0 Then
               Me.cmbVendedor.SelectedIndex = 0
            End If
         End If

         Me.cmbVendedor.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuario.Enabled = Me.chbUsuario.Checked

         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
         Else
            If Me.cmbUsuario.Items.Count > 0 Then
               Me.cmbUsuario.SelectedIndex = 0
            End If
         End If

         Me.cmbUsuario.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFormaPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFormaPago.CheckedChanged

      Try
         Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked

         If Not Me.chbFormaPago.Checked Then
            Me.cmbFormaPago.SelectedIndex = -1
         Else
            If Me.cmbFormaPago.Items.Count > 0 Then
               Me.cmbFormaPago.SelectedIndex = 0
            End If
         End If

         Me.cmbFormaPago.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbNumero.Checked And (Me.txtNumero.Text = "" OrElse Long.Parse(Me.txtNumero.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         If Me.chbNumeroReparto.Checked And (Me.txtNumeroReparto.Text = "" OrElse Long.Parse(Me.txtNumeroReparto.Text) = 0) Then
            ShowMessage("ATENCION: NO seleccionó un Número de Reparto aunque activó ese Filtro")
            Me.txtNumeroReparto.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbTodos.CheckedChanged
      Me.Cursor = Cursors.WaitCursor

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows()
         dr.Cells("Seleccionado").Value = Me.chbTodos.Checked
      Next

      Me.Cursor = Cursors.Default
   End Sub

   Private Sub dtgVentas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick

      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         If Me.dgvDetalle.SelectedRows.Count = 0 Then Exit Sub

         If e.RowIndex <> -1 Then

            Select Case Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name

               Case "MercDespachada"
                  Me.dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Display)


               Case "colVer"
                  Me.Cursor = Cursors.WaitCursor

                  Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

                  Dim Comprobante As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()))

                  Dim oImpr As Impresion = New Impresion(Comprobante)
                  If Comprobante.Impresora.TipoImpresora = "NORMAL" Then
                     oImpr.ImprimirComprobanteNoFiscal(True)
                  Else
                     oImpr.ReImprimirComprobanteFiscal()
                  End If

               Case Else
            End Select
         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   'Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
   '   If e.ColumnIndex = 27 And e.RowIndex <> -1 Then
   '      Me.dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Display)
   '   End If
   'End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbNumero.Checked = False
      chbNumeroReparto.Checked = False
      Me.chbCliente.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.cmbAfectaCaja.SelectedIndex = 0
      Me.cmbMercDespachada.SelectedIndex = 0
      Me.chbVendedor.Checked = False
      Me.chbUsuario.Checked = False
      Me.chbFormaPago.Checked = False

      'Limpio la Grilla.

      'Metodo 1 
      'Dim dt As DataTable = DirectCast(Me.dgvPorCliente.DataSource, DataTable)
      'dt.Rows.Clear()

      'Metodo 2
      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtSubtotal.Text = "0.00"
      Me.txtImpuestos.Text = "0.00"
      Me.txtTotal.Text = "0.00"

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

         Dim TotalNeto As Decimal = 0
         Dim TotalImpuestos As Decimal = 0
         Dim Total As Decimal = 0

         Dim IdCliente As Long = 0

         Dim IdTipoComprobante As String = String.Empty
         Dim NumeroComprobante As Long = 0

         Dim IdVendedor As Integer = 0

         Dim IdFormasPago As Integer = 0
         Dim IdUsuario As String = String.Empty

         Dim numeroReparto As Integer


         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.chbNumero.Checked Then
            NumeroComprobante = Long.Parse(Me.txtNumero.Text)
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbFormaPago.Enabled Then
            IdFormasPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
         End If

         If Me.cmbUsuario.Enabled Then
            'IdUsuario = DirectCast(Me.cmbUsuario.SelectedItem, Entidades.Usuario).Usuario
            IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
         End If

         If chbNumeroReparto.Checked Then
            numeroReparto = Integer.Parse(txtNumeroReparto.Text)
         End If


         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oVenta.GetPorRangoFechas({actual.Sucursal},
                                              Me.dtpDesde.Value, Me.dtpHasta.Value,
                                              IdVendedor, Entidades.OrigenFK.Movimiento,
                                              Me.cmbGrabanLibro.Text,
                                              IdCliente,
                                              Me.cmbAfectaCaja.Text,
                                              IdTipoComprobante,
                                              NumeroComprobante,
                                              IdFormasPago,
                                              IdUsuario, "NO ANULADO", , , Me.cmbMercDespachada.Text, , , numeroReparto)


         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("MercDespachada") = Boolean.Parse(dr("MercDespachada").ToString())

            '-- REQ-30770 --
            drCl("IdSucursal") = dr("IdSucursal").ToString()


            'If dr("TipoImpresora").ToString() = "NORMAL" Then
            drCl("Ver") = "..."
            'Else
            '   drCl("Ver") = "( F )"
            'End If

            'drCl("Imprimir") = "I"
            'drCl("VerEstandar") = ".E."

            drCl("TipoImpresora") = dr("TipoImpresora").ToString()
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("DescripcionAbrev") = dr("DescripcionAbrev").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("IdCliente") = dr("IdCliente").ToString()

            If dr("IdEstadoComprobante").ToString() <> "ANULADO" Then
               drCl("NombreCliente") = dr("NombreCliente").ToString()
            Else
               drCl("NombreCliente") = "** COMPROBANTE ANULADO **"
            End If

            drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
            drCl("FormaDePago") = dr("FormaDePago").ToString()

            'If Integer.Parse(dr("CantidadInvocados").ToString()) > 0 Then
            '   drCl("CantidadInvocados") = Integer.Parse(dr("CantidadInvocados").ToString())
            'End If

            'If Integer.Parse(dr("CantidadLotes").ToString()) > 0 Then
            '   drCl("CantidadLotes") = Integer.Parse(dr("CantidadLotes").ToString())
            'End If

            drCl("SubTotal") = Decimal.Parse(dr("SubTotal").ToString())
            drCl("TotalImpuestos") = Decimal.Parse(dr("TotalImpuestos").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

            If Not String.IsNullOrEmpty(dr("NumeroReparto").ToString()) Then
               drCl("NumeroReparto") = Integer.Parse(dr("NumeroReparto").ToString())
            End If

            If Not String.IsNullOrEmpty(dr("FechaEnvio").ToString()) Then
               drCl("FechaEnvio") = Date.Parse(dr("FechaEnvio").ToString())
            End If

            drCl("NombreTransportista") = dr("NombreTransportista").ToString()

            drCl("Usuario") = dr("Usuario").ToString()
            drCl("Observacion") = dr("Observacion").ToString()

            dt.Rows.Add(drCl)

            TotalNeto = TotalNeto + Decimal.Parse(drCl("SubTotal").ToString())
            TotalImpuestos = TotalImpuestos + Decimal.Parse(drCl("TotalImpuestos").ToString())
            Total = Total + Decimal.Parse(drCl("ImporteTotal").ToString())

         Next

         Me.txtSubtotal.Text = TotalNeto.ToString("#,##0.00")
         Me.txtImpuestos.Text = TotalImpuestos.ToString("#,##0.00")
         Me.txtTotal.Text = Total.ToString("#,##0.00")

         Me.dgvDetalle.DataSource = dt

         Me.tsbDespachar.Enabled = True
         Me.tsbAnularDespacho.Enabled = True
         chbTodos.Checked = False

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Seleccionado", System.Type.GetType("System.Boolean")).DefaultValue = False
         .Columns.Add("MercDespachada", System.Type.GetType("System.Boolean"))
         .Columns.Add("Ver")
         '.Columns.Add("Imprimir")
         '.Columns.Add("VerEstandar")
         .Columns.Add("TipoImpresora", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAbrev", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         '.Columns.Add("CantidadInvocados", System.Type.GetType("System.Int32"))
         '.Columns.Add("CantidadLotes", System.Type.GetType("System.Int32"))
         .Columns.Add("SubTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("NumeroReparto", System.Type.GetType("System.Int32"))
         .Columns.Add("FechaEnvio", System.Type.GetType("System.DateTime"))
         .Columns.Add("NombreTransportista", System.Type.GetType("System.String"))
         .Columns.Add("Usuario", System.Type.GetType("System.String"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))

      End With

      Return dtTemp

   End Function

   Private Sub DespacharAnularDespacho(despachar As Boolean)
      If Me.dgvDetalle.RowCount = 0 Then Exit Sub

      Me.dgvDetalle.UpdateCellValue(dgvDetalle.SelectedCells(0).ColumnIndex, dgvDetalle.SelectedCells(0).RowIndex)
      Me.dgvDetalle.EndEdit()

      If Not despachar Then
         If MessageBox.Show("¿Está seguro que desea Anuluar los Despachos seleccionados?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If
      End If

      Try

         Me.Cursor = Cursors.WaitCursor
         Dim colComprobantes As List(Of Entidades.Venta) = New List(Of Entidades.Venta)

         Dim oVenta As Entidades.Venta
         Dim oVentas As Reglas.Ventas = New Reglas.Ventas

         tspBarra.Minimum = 0
         tspBarra.Maximum = Me.dgvDetalle.Rows.Count
         tspBarra.Value = 0
         tspBarra.Step = 1
         tspBarra.Visible = True

         Dim dt As DataTable = DirectCast(dgvDetalle.DataSource, DataTable)

         For Each dr1 As DataGridViewRow In dgvDetalle.Rows
            tspBarra.PerformStep()
            If CBool(dr1.Cells("seleccionado").Value) Then
               'If Boolean.Parse(dr1.Cells("MercDespachada").Value.ToString()) Then
               oVenta = New Entidades.Venta

               oVenta = oVentas.GetUna(Short.Parse(dr1.Cells("IdSucursal").Value.ToString()), dr1.Cells("IdTipoComprobante").Value.ToString(),
                                       dr1.Cells("Letra").Value.ToString(), Short.Parse(dr1.Cells("CentroEmisor").Value.ToString()),
                                       Long.Parse(dr1.Cells("NumeroComprobante").Value.ToString()))

               If despachar <> oVenta.MercDespachada Then
                  oVenta.MercDespachada = despachar

                  If Not despachar Then
                     oVenta.FechaEnvio = Nothing
                     oVenta.Transportista.idTransportista = 0
                     oVenta.NumeroReparto = 0
                  End If

                  colComprobantes.Add(oVenta)
               End If

            End If
         Next

         tspBarra.Style = ProgressBarStyle.Marquee

         oVentas.GrabarMercaderiaDespachada(colComprobantes)

         tspBarra.Style = ProgressBarStyle.Continuous

         MessageBox.Show("Los comprobantes se actualizaron correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.btnConsultar_Click(Me.btnConsultar, Nothing)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         tspBarra.Style = ProgressBarStyle.Continuous
         tspBarra.Visible = False
      End Try

   End Sub

#End Region

   Private Sub tsbAnularDespacho_Click(sender As Object, e As EventArgs) Handles tsbAnularDespacho.Click
      DespacharAnularDespacho(False)
   End Sub
End Class