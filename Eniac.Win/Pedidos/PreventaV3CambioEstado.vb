#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class PreventaV3CambioEstado
#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Propiedades"

   Public Property Pedido As Entidades.DsPreventa.PedidoRow

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos = New Publicos()

         Me._publicos.CargaComboEstadoVisita(Me.cmbEstadoVisita, Nothing, Nothing)
         Me.cmbEstadoVisita.SelectedIndex = 0

         If Pedido.GetPedidoProductoRows.Count > 0 Then
            Me._publicos.CargaComboEstadoVisita(Me.cmbEstadoVisitaNuevo, Nothing, True)
         Else
            Me._publicos.CargaComboEstadoVisita(Me.cmbEstadoVisitaNuevo, True, Nothing)
         End If

         Me.cmbEstadoVisitaNuevo.SelectedIndex = -1

         Me.cmbEstadoVisita.SelectedValue = Pedido.IdEstadoVenta

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
#End Region

#Region "Eventos"

   Private Sub Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If Me.cmbEstadoVisitaNuevo.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione un nuevo Estado de Visita", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbEstadoVisitaNuevo.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
         End If

         Me.ModificarEstadoVisita()

         DialogResult = Windows.Forms.DialogResult.OK

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"
   Public Sub ModificarEstadoVisita()

      If Not Pedido.Estado.Equals(Entidades.PreVenta.PreventaEstadoPedido.Corregible) Then
         Throw New Exception("No se puede cambiar el estado de visita porque hay otros errores en el pedido.")
      End If

      Dim estadoVisita As Eniac.Entidades.EstadoVisita = DirectCast(cmbEstadoVisitaNuevo.SelectedItem, Eniac.Entidades.EstadoVisita)
      Dim valida As String = New Reglas.PreVenta().ValidaEstadoVisita(estadoVisita, Pedido)

      If Not String.IsNullOrWhiteSpace(valida) Then
         Throw New Exception(valida)
      End If

      Pedido.IdEstadoVenta = estadoVisita.IdEstadoVisita
      Pedido.NombreEstadoVenta = estadoVisita.NombreEstadoVisita
      Pedido.Estado = Entidades.PreVenta.PreventaEstadoPedido.Normal
      Pedido.Pasa = True
      Pedido.MensajeError = String.Empty
   End Sub
#End Region

End Class