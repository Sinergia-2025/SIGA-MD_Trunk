Public Class IngresoDeLote
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.lblFechaVencimiento.Visible = Publicos.LoteSolicitaFechaVencimiento
         Me.dtpFechaVencimiento.Visible = Publicos.LoteSolicitaFechaVencimiento
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Try
         If Me.txtIdLote.Text.Trim() = "" Then
            MessageBox.Show("El Lote no puede estar vacio.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtIdLote.SelectAll()
            Me.txtIdLote.Focus()
            Exit Sub
         End If
         '------------------------------------------------------------------------------------------------------------
         CargaFechaLote()
         '------------------------------------------------------------------------------------------------------------
         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtIdLote_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdLote.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Me.dtpFechaVencimiento.Visible Then
            '------------------------------------------------------------------------------------------------------------
            CargaFechaLote()
            '------------------------------------------------------------------------------------------------------------
            Me.dtpFechaVencimiento.Focus()
         Else
            Me.btnAceptar.Focus()
         End If
      End If
   End Sub

   Private Sub dtpFechaVencimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaVencimiento.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnAceptar.Focus()
      End If
   End Sub

   Private Sub txtIdLote_Leave(sender As Object, e As EventArgs) Handles txtIdLote.Leave
      '------------------------------------------------------------------------------------------------------------
      CargaFechaLote()
      '------------------------------------------------------------------------------------------------------------
   End Sub

   Private Sub CargaFechaLote()
      '------------------------------------------------------------------------------------------------------------
      Dim _dt = New Reglas.ProductosLotes().GetFiltradoPorId(txtIdLote.Text, Entidades.Usuario.Actual.Sucursal.Id)
      If _dt.Rows.Count > 0 Then
         Me.dtpFechaVencimiento.Value = _dt.Rows(0).Field(Of Date)("FechaVencimiento")
      End If
      '------------------------------------------------------------------------------------------------------------
   End Sub
End Class