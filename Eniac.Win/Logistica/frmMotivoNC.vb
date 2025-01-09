Option Explicit On
Option Strict On
Public Class frmMotivoNC

#Region "Campos"

   Private _publicos As Publicos

#End Region

   Private Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.

   End Sub
   Public Sub New(drPedido As dtsRegistracionPagos.PedidosRow)
      Me.New(drPedido.IdTipoComprobante, drPedido.Letra, drPedido.CentroEmisor, drPedido.NumeroComprobante)
   End Sub
   Public Sub New(idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      Me.New()
      Me.IdTipoComprobante = idTipoComprobante
      Me.Letra = letra
      Me.CentroEmisor = centroEmisor
      Me.NumeroComprobante = numeroComprobante
   End Sub

#Region "Propiedades"

   Private Property IdTipoComprobante As String
   Private Property Letra As String
   Private Property CentroEmisor As Integer
   Private Property NumeroComprobante As Long

   Private _idMotivo As Integer
   Public Property IdMotivo() As Integer
      Get
         Return _idMotivo
      End Get
      Set(ByVal value As Integer)
         _idMotivo = value
      End Set
   End Property

   Private _motivo As String
   Public Property Motivo() As String
      Get
         Return _motivo
      End Get
      Private Set(ByVal value As String)
         _motivo = value
      End Set
   End Property


#End Region

   Property Pedido As Eniac.Entidades.Venta



   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos = New Publicos()

         Me._publicos.CargaComboEstadosVenta(Me.cmbMotivo)
         Me.cmbMotivo.SelectedIndex = 0


         Me.txtIdTipoComprobante.Text = IdTipoComprobante
         Me.txtLetra.Text = Letra
         ''Me.txtCentroEmisor.Text = DrPedido.CentroEmisor.ToString()
         Me.txtNumeroComprobante.Text = NumeroComprobante.ToString()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub



#Region "Eventos"

   Private Sub Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.IdMotivo = CInt(Me.cmbMotivo.SelectedValue)
         Me.Motivo = Me.cmbMotivo.Text

         DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region
End Class
