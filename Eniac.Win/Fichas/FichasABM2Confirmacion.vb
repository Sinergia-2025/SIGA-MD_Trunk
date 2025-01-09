Option Strict On
Option Explicit On
Public Class FichasABM2Confirmacion
   Private _venta As Entidades.Venta
   Public ReadOnly Property ImprimirFichaAnticipo As Boolean
      Get
         Return radFichaAnticipo_SI.Checked
      End Get
   End Property
   Public ReadOnly Property ImprimirFichaCliente As Boolean
      Get
         Return radFichaCliente_SI.Checked
      End Get
   End Property
   Public ReadOnly Property ReemplazaFicha As Boolean
      Get
         Return radReemplazaFicha_SI.Checked
      End Get
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         radFichaAnticipo_SI.Checked = True
         radFichaCliente_SI.Checked = True
         pnlReemplazaFicha.Visible = Reglas.Publicos.FichasPreguntaReemplazarComprobante
         If pnlReemplazaFicha.Visible Then
            radReemplazaFicha_SI.Checked = True
         Else
            radReemplazaFicha_NO.Checked = True
         End If

         lblComprobante.Text = String.Empty
         lblCliente.Text = String.Empty
         lblImporteTotal.Text = String.Empty
         If _venta IsNot Nothing Then
            lblComprobante.Text = String.Format("{0} {1} {2:0000}-{3:00000000}",
                                                 _venta.TipoComprobante.Descripcion,
                                                 _venta.LetraComprobante,
                                                 _venta.CentroEmisor,
                                                 _venta.NumeroComprobante)
            lblCliente.Text = String.Format("Cliente: {0} - {1}", _venta.Cliente.CodigoCliente, _venta.Cliente.NombreCliente)
            lblImporteTotal.Text = String.Format("Importe Total: {0:N2}", _venta.ImporteTotal)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Try
         DialogResult = Windows.Forms.DialogResult.Cancel
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
      Try
         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Public Overloads Function ShowDialog(owner As System.Windows.Forms.IWin32Window,
                                        venta As Entidades.Venta) As DialogResult
      _venta = venta
      Return ShowDialog(owner)
   End Function

End Class