Public Class ucConfBanco
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)
      chbUnificaLibrosDeBanco.Checked = Reglas.Publicos.UnificaLibrosDeBanco
      txtDiasVisualizacionLibroBanco.Text = Reglas.Publicos.DiasVisualizacionLibroBanco.ToString()
      chbDepositoMuestraClienteXTitular.Checked = Reglas.Publicos.DepositoMuestraClienteEnLugarDeTitular
      txtCuentaBancoPagoProveedores.Text = Reglas.Publicos.CtaBancoPago.ToString()
      txtCuentaBancoTransfBancaria.Text = Reglas.Publicos.CtaBancoTransfBancaria.ToString()
      txtCuentaBancoDeposito.Text = Reglas.Publicos.CtaBancoDeposito.ToString()
      txtCuentaBancoAcredTarjeta.Text = Reglas.Publicos.CtaBancoAcredTarjeta.ToString()
      txtCuentaBancoExtraccion.Text = Reglas.Publicos.CtaBancoExtraccion.ToString()
      txtCuentaBancoLiquidacionesTarjetas.Text = Reglas.Publicos.CtaBancoLiquidacionesTarjetas.ToString()

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)
      ActualizarParametro(Entidades.Parametro.Parametros.UNIFICALIBROSDEBANCO, chbUnificaLibrosDeBanco, Nothing, chbUnificaLibrosDeBanco.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.DIASVISUALIZACIONLIBROBANCO, txtDiasVisualizacionLibroBanco, Nothing, lblDiasVisualizacionLibroBanco.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.DEPOSITOMUESTRACLIENTEXTITULAR, chbDepositoMuestraClienteXTitular, Nothing, chbDepositoMuestraClienteXTitular.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTABANCOPAGO, txtCuentaBancoPagoProveedores, Nothing, lblCuentaBancoPagoProveedores.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTABANCOTRANSFBANCARIA, txtCuentaBancoTransfBancaria, Nothing, lblCuentaBancoTransfBancaria.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTABANCODEPOSITO, txtCuentaBancoDeposito, Nothing, lblCuentaBancoDeposito.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTABANCOACREDTARJETA, txtCuentaBancoAcredTarjeta, Nothing, lblCuentaBancoAcredTarjeta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTABANCOEXTRACCION, txtCuentaBancoExtraccion, Nothing, lblCuentaBancoExtraccion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CTABANCOLIQUIDACIONTARJETA, txtCuentaBancoLiquidacionesTarjetas, Nothing, lblCuentaBancoLiquidacionesTarjetas.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.COLORCONCILIADO, txtColorConciliado.Key.ToString(), Nothing, grbLibroBanco.Text)
      ActualizarParametroTexto(Entidades.Parametro.Parametros.COLORNOCONCILIADO, txtColorDesconciliado.Key.ToString(), Nothing, grbLibroBanco.Text)

   End Sub

   Private Sub btnColorConciliado_Click(sender As Object, e As EventArgs) Handles btnColorConciliado.Click
      FindForm().TryCatched(Sub() SeleccionarColor(txtColorConciliado))
   End Sub

   Private Sub btnColorDesconciliado_Click(sender As Object, e As EventArgs) Handles btnColorDesconciliado.Click
      FindForm().TryCatched(Sub() SeleccionarColor(txtColorDesconciliado))
   End Sub

   Private Sub SeleccionarColor(txt As Controles.TextBox)
      cdColor.Color = txt.BackColor
      If cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
         txt.Key = cdColor.Color.ToArgb().ToString
         txt.BackColor = cdColor.Color
      End If
   End Sub

End Class
