Public Class CuentaCorrienteProveedor

   Private _dt As DataTable
   Private _fechaFactura As DateTime
   Private _diasCC As Integer

   Public ReadOnly Property Pagos() As DataTable
      Get
         Return Me._dt
      End Get
   End Property

   Public Sub New(ByVal fechaFactura As DateTime, ByVal montoACancelar As Decimal, ByVal Dias As Integer)
      MyBase.New()
      Me.InitializeComponent()

      Try
         Me._dt = New DataTable()
         Me._dt.Columns.Add("MontoAPagar", System.Type.GetType("System.Decimal"))
         Me._dt.Columns.Add("Dias", System.Type.GetType("System.Int32"))
         Me._dt.Columns.Add("FechaAPagar", System.Type.GetType("System.DateTime"))

         Me.txtSaldo.Text = montoACancelar.ToString("#,##0.00")
         Me.txtMonto.Text = montoACancelar.ToString("#,##0.00")
         Me.txtDias.Text = Dias.ToString()
         Me.dtpFechaAPagar.Value = fechaFactura.AddDays(Dias)

         Me._diasCC = Dias
         Me._fechaFactura = fechaFactura

         Me.CalcularResto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me.dgvFormaDePago.DataSource = Me._dt

         'Me.dtpFechaAPagar.Value = Me._fechaFactura.AddDays(30)

         'Me.txtDias.Text = "0"   'Antes 30. La mayoria no va a usar cuotas, por lo tanto el vencimiento es el mismo dia.

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Decimal.Parse(Me.txtRestan.Text) <> 0 Then
         MessageBox.Show("El Resto debe ser Cero para Aceptar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvFormaDePago.SelectedCells.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar el item seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLinea()
               Me.CalcularResto()
               Me.LimpiarCampos()
               Me.txtMonto.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub EliminarLinea()
      Me._dt.Rows.RemoveAt(Me.dgvFormaDePago.SelectedCells(0).RowIndex)

      Me.dgvFormaDePago.DataSource = Me._dt

   End Sub

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
      Try
         If Decimal.Parse(Me.txtMonto.Text) > 0 Then
            Me.InsertarComprobanteGrilla()
         Else
            MessageBox.Show("El monto debe ser mayor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMonto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub InsertarComprobanteGrilla()
      If Decimal.Parse(Me.txtMonto.Text) > Decimal.Parse(Me.txtRestan.Text) Then
         MessageBox.Show("El monto a pagar no puede ser mayor que el resto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtMonto.Focus()
      Else
         Dim dr As DataRow = Me._dt.NewRow()

         dr("MontoAPagar") = Me.txtMonto.Text
         dr("Dias") = Me.txtDias.Text
         dr("FechaAPagar") = Me.dtpFechaAPagar.Value

         Me._dt.Rows.Add(dr)


         Me.dgvFormaDePago.DataSource = Me._dt
         Me.dgvFormaDePago.FirstDisplayedScrollingRowIndex = Me.dgvFormaDePago.Rows.Count - 1

         Me.CalcularResto()
         Me.LimpiarCampos()
         Me.txtMonto.Focus()
      End If
   End Sub

   Private Sub LimpiarCampos()
      'Me.txtDias.Text = Me._diasCC
      Me.txtMonto.Text = Me.txtRestan.Text
      'Me.dtpFechaAPagar.Value = Me._fechaFactura.AddDays(Int32.Parse(Me.txtDias.Text))
   End Sub

   Private Sub CalcularResto()
      Dim resto As Decimal = 0
      resto = Decimal.Parse(Me.txtSaldo.Text)

      For Each dr As DataRow In Me._dt.Rows
         resto -= Decimal.Parse(dr("MontoAPagar").ToString())
      Next

      Me.txtRestan.Text = resto.ToString("#,##0.00")

   End Sub

   Private Sub txtDias_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDias.Leave
      If Me.txtDias.Text.Trim().Length = 0 Then Me.txtDias.Text = "0"
      Me.dtpFechaAPagar.Value = Me._fechaFactura.AddDays(Int32.Parse(Me.txtDias.Text))
   End Sub

   Private Sub dtpFechaAPagar_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaAPagar.Leave
      Me.txtDias.Text = (Me.dtpFechaAPagar.Value - Me._fechaFactura).Days.ToString()
   End Sub

   Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.txtDias.Focus()
      End If
   End Sub

   Private Sub txtDias_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDias.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.dtpFechaAPagar.Focus()
      End If
   End Sub

   Private Sub dtpFechaAPagar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaAPagar.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnInsertar.Focus()
      End If
   End Sub

End Class