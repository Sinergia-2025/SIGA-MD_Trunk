Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class EliminarVentas

#Region "Campos"

   Private _publicos As Publicos
   Private _comprobantes As List(Of Entidades.Venta)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()
         Me._comprobantes = New List(Of Entidades.Venta)

         Me.dtpHasta.Value = DateTime.Today.Date.AddDays(-1)

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Me.cmbAfectaCaja.Items.Insert(0, "TODOS")
         Me.cmbAfectaCaja.Items.Insert(1, "SI")
         Me.cmbAfectaCaja.Items.Insert(2, "NO")
         Me.cmbAfectaCaja.SelectedIndex = 0

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub EliminarVentas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

   Private Sub tsbEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEliminar.Click

      If Me.dgvDetalle.RowCount = 0 Then Exit Sub

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.EliminarVentas()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

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
            Me.dtpHasta.Value = FechaTemp

         End If

         dtpDesde.Enabled = Not chkMesCompleto.Checked
         dtpHasta.Enabled = Not chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub dtgVentas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick

      If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
         Try
            Me.Cursor = Cursors.WaitCursor
            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
            Dim venta As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
                        Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                        Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                        Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                        Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NumeroComprobante").Value.ToString()))

            Dim oImpr As Impresion = New Impresion(venta)

            If Me.dgvDetalle.Rows(e.RowIndex).Cells("TipoImpresora").Value.ToString() = "NORMAL" Then
               oImpr.ImprimirComprobanteNoFiscal(True)
            Else
               oImpr.ReImprimirComprobanteFiscal()
            End If

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now

      'Me.dtpHasta.Value = DateTime.Today.AddDays(-1)

      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.cmbAfectaCaja.SelectedIndex = 0

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargaGrillaDetalle()

      Me._comprobantes.Clear()

      Dim oComprobante As Entidades.Venta

      'Dim rTipoComprob As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      'Dim rFormasPago As Reglas.VentasFormasPago = New Reglas.VentasFormasPago()

      Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

      Dim IdCliente As Long = 0

      Dim TipoComprobante As String = String.Empty

      Dim IdVendedor As Integer = 0

      Try

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oVenta.GetPorRangoFechas({actual.Sucursal},
                                              Me.dtpDesde.Value, Me.dtpHasta.Value.AddHours(23).AddMinutes(59).AddSeconds(59),
                                              IdVendedor, Entidades.OrigenFK.Movimiento,
                                              Me.cmbGrabanLibro.Text,
                                              IdCliente,
                                              Me.cmbAfectaCaja.Text,
                                              TipoComprobante)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            'drCl("Ver") = "..."
            drCl("TipoImpresora") = dr("TipoImpresora").ToString()
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("DescripcionAbrev") = dr("DescripcionAbrev").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
            drCl("FormaDePago") = dr("FormaDePago").ToString()
            drCl("SubTotal") = Decimal.Parse(dr("SubTotal").ToString())
            drCl("TotalImpuestos") = Decimal.Parse(dr("TotalImpuestos").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            drCl("Kilos") = Decimal.Parse(dr("Kilos").ToString())

            dt.Rows.Add(drCl)


            'oComprobante = New Entidades.Venta()

            'With oComprobante
            '   .IdSucursal = actual.Sucursal.Id
            '   .TipoComprobante = rTipoComprob.GetUno(dr("IdTipoComprobante").ToString())
            '   .LetraComprobante = dr("Letra").ToString()
            '   .CentroEmisor = Integer.Parse(dr("CentroEmisor").ToString())
            '   .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
            '   .FormaPago = rFormasPago.GetUna(Integer.Parse(dr("IdFormasPago").ToString()))
            'End With

            oComprobante = oVenta.GetUna(actual.Sucursal.Id, _
                                         dr("IdTipoComprobante").ToString(), _
                                         dr("Letra").ToString(), _
                                         Short.Parse(dr("CentroEmisor").ToString()), _
                                         Long.Parse(dr("NumeroComprobante").ToString()))

            Me._comprobantes.Add(oComprobante)

         Next

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registro/s"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         '.Columns.Add("Ver")
         .Columns.Add("TipoImpresora", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAbrev", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         .Columns.Add("SubTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Kilos", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

   Private Sub EliminarVentas()

      Dim reg As Reglas.Ventas = New Reglas.Ventas()

      reg.EliminarVentas(Me._comprobantes)

      MessageBox.Show("Se eliminó Exitosamente " & Me._comprobantes.Count.ToString() & " Comprobante(s) !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())

   End Sub

#End Region

End Class