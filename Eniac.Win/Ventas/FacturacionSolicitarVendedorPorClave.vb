Public Class FacturacionSolicitarVendedorPorClave
   Public Property Vendedor As Entidades.Empleado

   Private Sub txtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClave.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnAceptar.PerformClick()
      End If
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         If Valida() Then
            Dim vendedor As Entidades.Empleado = BuscaVendedor()
            If vendedor Is Nothing Then
               ShowMessage("Clave inválida: no existe vendedor con esta clave")
            Else
               Me.Vendedor = vendedor
               DialogResult = Windows.Forms.DialogResult.OK
               Close()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function Valida() As Boolean
      If String.IsNullOrWhiteSpace(txtClave.Text) Then
         ShowMessage("Clave inválida")
         Return False
      End If
      Return True
   End Function

   Private Function BuscaVendedor() As Entidades.Empleado
      Dim regla As Reglas.Empleados = New Reglas.Empleados()
      Return regla.GetPorClave(txtClave.Text, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
   End Function

End Class