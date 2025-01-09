Public Class TransportistasConsultas

    Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
        Try
            Me.txtNombre.Text = String.Empty
            Me.txtDireccion.Text = String.Empty

            If Me.dgvTransportistas.Rows.Count > 0 Then
                DirectCast(Me.dgvTransportistas.DataSource, DataTable).Rows.Clear()
            End If

            Me.txtNombre.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.RefrescarDatosGrilla()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tssRegistros.Text = "0 Registros"
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub RefrescarDatosGrilla()

        Dim oPro As Reglas.Transportistas = New Reglas.Transportistas()

        If Me.txtNombre.Text.Trim().Length > 0 Then
            Me.dgvTransportistas.DataSource = oPro.GetFiltradoPorNombre(Me.txtNombre.Text.Trim())
        Else
            Me.dgvTransportistas.DataSource = oPro.GetFiltradoPorDireccion(Me.txtDireccion.Text.Trim())
        End If

        Me.tssRegistros.Text = Me.dgvTransportistas.RowCount.ToString() & " Registros"

        If Me.dgvTransportistas.Rows.Count > 0 Then
            Me.dgvTransportistas.Focus()
        Else
            Me.txtNombre.Focus()
        End If

    End Sub

    Private Sub TransportistasConsultas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F5 Then
            Me.tsbRefrescar.PerformClick()
        End If
    End Sub
End Class