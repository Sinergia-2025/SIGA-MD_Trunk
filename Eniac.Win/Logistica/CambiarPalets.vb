Option Explicit On
Option Strict On

Public Class CambiarPalets

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

   Private _cantidadActual As Integer
   Public Property CantidadActual() As Integer
      Get
         Return _cantidadActual
      End Get
      Set(ByVal value As Integer)
         _cantidadActual = value
      End Set
   End Property

   Private _nuevaCantidad As Integer
   Public Property NuevaCantidad() As Integer
      Get
         Return _nuevaCantidad
      End Get
      Set(ByVal value As Integer)
         _nuevaCantidad = value
      End Set
   End Property
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos = New Publicos()


         _publicos.CargaComboDesdeEnum(cmbCambioMasivo, GetType(OrganizarEntregasV2.ModoCambioMasivo))

         Me.txtCantidaActual.Text = CantidadActual.ToString()
         Me.txtIdTipoComprobante.Text = IdTipoComprobante.ToString()
         Me.txtLetra.Text = Letra.ToString()
         Me.txtNumeroComprobante.Text = NumeroPedido.ToString()
         Me.txtNuevaCantidad.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      ''If Venta IsNot Nothing Then Me._NomTransp = Venta.Transportista.NombreTransportista
      DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try

         Me.Cursor = Cursors.WaitCursor
         Me.ModificarRespDistrib()

         DialogResult = Windows.Forms.DialogResult.OK

         Me.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Public Sub ModificarRespDistrib()
      Me.NuevaCantidad = Integer.Parse(txtNuevaCantidad.Text)
      Me.CambioMasivo = DirectCast(cmbCambioMasivo.SelectedValue, OrganizarEntregasV2.ModoCambioMasivo)
   End Sub

#End Region

End Class