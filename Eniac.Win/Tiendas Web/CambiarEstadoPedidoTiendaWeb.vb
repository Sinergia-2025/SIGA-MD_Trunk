Public Class CambiarEstadoPedidoTiendaWeb
   Private Property _pedido As Entidades.PedidoTiendaWeb
   Private Property _publicos As Publicos
   Public Property NuevoEstado As String

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(pedido As Entidades.PedidoTiendaWeb)
      Me.New()

      _pedido = pedido
      _publicos = New Publicos

      '# Carga Combos
      Me.cmbEstadoAnterior.Items.Add(_pedido.IdEstadoPedidoTiendaWeb)
      Me.cmbEstadoAnterior.SelectedIndex = 0
      Me._publicos.CargaComboDesdeEnum(Me.cmbNuevoEstado, GetType(Estados))

      '# Datos del pedido
      Me.txtTienda.Text = _pedido.SistemaDestino
      Me.txtPedido.Text = _pedido.Numero.ToString()

   End Sub

   Public Enum Estados
      INGRESADO
      CANCELADO
   End Enum

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Try
         Me.Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         '# Seteo el nuevo estado
         Me.NuevoEstado = Me.cmbNuevoEstado.SelectedValue.ToString()

         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class