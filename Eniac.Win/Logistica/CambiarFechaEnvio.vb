Option Explicit On
Option Strict On

Public Class CambiarFechaEnvio

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

   ''Private _Pedido As Eniac.Entidades.Venta
   ''Public Property Pedido() As Eniac.Entidades.Venta
   ''   Get
   ''      Return _Pedido
   ''   End Get
   ''   Set(ByVal value As Eniac.Entidades.Venta)
   ''      _Pedido = value
   ''   End Set
   ''End Property

   Private _fecEnvio As Date
   Public Property fecEnvio() As Date
      Get
         Return _fecEnvio
      End Get
      Set(ByVal value As Date)
         _fecEnvio = value
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

         Me.txtIdTipoComprobante.Text = IdTipoComprobante.ToString()
         Me.txtLetra.Text = Letra.ToString()
         Me.txtNumeroComprobante.Text = NumeroPedido.ToString()
         If fecEnvio = New Date Then
            Me.dtpFechaEnvio.Value = Today
         Else
            Me.dtpFechaEnvio.Value = fecEnvio
         End If
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

         Me.CambiarFechaEnvio()

         DialogResult = Windows.Forms.DialogResult.OK

         Me.Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Public Sub CambiarFechaEnvio()
      Me.fecEnvio = dtpFechaEnvioNueva.Value
      Me.CambioMasivo = DirectCast(cmbCambioMasivo.SelectedValue, OrganizarEntregasV2.ModoCambioMasivo)
   End Sub

#End Region

End Class