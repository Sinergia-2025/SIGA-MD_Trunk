Option Strict On
Option Explicit On
Public Class VentaColaImpresion
   Private _publicos As Publicos

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         _publicos.CargaComboColaImpresion(cmbColaImpresion)
         RefrescarDatosGrilla()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         'Me.RefrescarDatosGrilla()
         Me.CargaColaImpresion()
         'Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Public Sub RefrescarDatosGrilla()
      If cmbColaImpresion.Items.Count > 0 Then
         cmbColaImpresion.SelectedIndex = 0
      End If
   End Sub

   Private Sub cmbColaImpresion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColaImpresion.SelectedIndexChanged
      Try
         CargaColaImpresion()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Public Sub CargaColaImpresion()
      If cmbColaImpresion.SelectedValue IsNot Nothing Then
         Dim idColaImpresion As Integer

         If Integer.TryParse(cmbColaImpresion.SelectedValue.ToString(), idColaImpresion) Then
            Dim dtColaImp As DataTable = New Reglas.VentasColasImpresionComprobantes().GetAll(idColaImpresion)
            ugDetalle.DataSource = dtColaImp
            Me.tssRegistros.Text = dtColaImp.Rows.Count.ToString() & " Registros"
         End If
      End If
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
      Try

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class
