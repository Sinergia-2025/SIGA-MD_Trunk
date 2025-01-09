Option Explicit On
Option Strict On

Public Class CambiarFormaPago

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Propiedades"


   Private _CambioMasivo As OrganizarEntregasV2.ModoCambioMasivo

   Public Property CambioMasivo() As OrganizarEntregasV2.ModoCambioMasivo
      Get
         Return _CambioMasivo
      End Get
      Set(ByVal value As OrganizarEntregasV2.ModoCambioMasivo)
         _CambioMasivo = value
      End Set
   End Property

   Private _idFormaPago As Integer
   Public Property IdFormaPago() As Integer
      Get
         Return _idFormaPago
      End Get
      Set(ByVal value As Integer)
         _idFormaPago = value
      End Set
   End Property


   Private _idTipoComprobante As String
   Public Property IdTipoComprobante() As String
      Get
         Return _idTipoComprobante
      End Get
      Set(ByVal value As String)
         _idTipoComprobante = value
      End Set
   End Property
   Private _letra As String
   Public Property Letra() As String
      Get
         Return _letra
      End Get
      Set(ByVal value As String)
         _letra = value
      End Set
   End Property
   Private _centroEmisor As Short
   Public Property CentroEmisor() As Short
      Get
         Return _centroEmisor
      End Get
      Set(ByVal value As Short)
         _centroEmisor = value
      End Set
   End Property
   Private _numeroPedido As Long
   Public Property NumeroPedido() As Long
      Get
         Return _numeroPedido
      End Get
      Set(ByVal value As Long)
         _numeroPedido = value
      End Set
   End Property

   Private _formaPago As String
   Public Property formaPago() As String
      Get
         Return _formaPago
      End Get
      Set(ByVal value As String)
         _formaPago = value
      End Set
   End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos = New Publicos()

         Me._publicos.CargaComboFormasDePago(Me.cmbfPago, "VENTAS")
         Me.cmbfPago.SelectedIndex = 0

         Me._publicos.CargaComboFormasDePago(Me.cmbfpagoNuevo, "VENTAS", False)
         Me.cmbfpagoNuevo.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbCambioMasivo, GetType(OrganizarEntregasV2.ModoCambioMasivo))

         Me.txtIdTipoComprobante.Text = IdTipoComprobante.ToString()
         Me.txtLetra.Text = Letra.ToString()
         Me.txtNumeroComprobante.Text = NumeroPedido.ToString()
         Me.cmbfPago.SelectedValue = IdFormaPago

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

         If Me.cmbfpagoNuevo.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione una nueva Forma de Pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbfpagoNuevo.Focus()
            Me.Cursor = Cursors.Arrow
            Exit Sub
         End If

         Me.ModificarformaPago()

         DialogResult = Windows.Forms.DialogResult.OK

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"

   Public Sub ModificarformaPago()

      '# Valido que la nueva forma de pago tenga el mismo porcentaje de desc/rec que la anterior.
      '# Caso contrario le informo al usuario que debe realizar la modificación desde la pantalla de Modificar Pedidos
      If DirectCast(Me.cmbfPago.SelectedItem, Entidades.VentaFormaPago).Porcentaje <>
         DirectCast(Me.cmbfpagoNuevo.SelectedItem, Entidades.VentaFormaPago).Porcentaje Then
         Throw New Exception(String.Format("ATENCIÓN: El porcentaje de la nueva Forma de Pago seleccionada es distinto al de la anterior. Debe modificarla desde >> MODIFICAR"))
      End If

      Me.IdFormaPago = CInt(Me.cmbfpagoNuevo.SelectedValue)
      Me.formaPago = Me.cmbfpagoNuevo.Text
      Me.CambioMasivo = DirectCast(cmbCambioMasivo.SelectedValue, OrganizarEntregasV2.ModoCambioMasivo)
   End Sub

#End Region
End Class