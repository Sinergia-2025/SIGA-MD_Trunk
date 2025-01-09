Option Explicit On
Option Strict On

Public Class CambiarFechaEnvioyRespDist

#Region "Campos"

   Private _publicos As Publicos
   Private _publicosEniac As Eniac.Win.Publicos

#End Region

   Private Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(drPedido As dtsRegistracionPagos.PedidosRow)
      Me.New()
      Me.DrPedido = drPedido
   End Sub

#Region "Propiedades"

   Private _drPedido As dtsRegistracionPagos.PedidosRow
   Public Property DrPedido() As dtsRegistracionPagos.PedidosRow
      Get
         Return _drPedido
      End Get
      Private Set(ByVal value As dtsRegistracionPagos.PedidosRow)
         _drPedido = value
      End Set
   End Property

   Private _nuevoTransportista As Eniac.Entidades.Transportista
   Public Property NuevoTransportista() As Eniac.Entidades.Transportista
      Get
         Return _nuevoTransportista
      End Get
      Private Set(ByVal value As Eniac.Entidades.Transportista)
         _nuevoTransportista = value
      End Set
   End Property
   Private _nuevaFecha As DateTime
   Public Property NuevaFecha() As DateTime
      Get
         Return _nuevaFecha
      End Get
      Private Set(ByVal value As DateTime)
         _nuevaFecha = value
      End Set
   End Property
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me.Cursor = Cursors.WaitCursor

         Me._publicos = New Publicos()
         Me._publicosEniac = New Eniac.Win.Publicos()

         Me._publicosEniac.CargaComboTransportistas(Me.cmbRespDistribucion, True)
         Me.cmbRespDistribucion.SelectedIndex = -1

         Me._publicosEniac.CargaComboTransportistas(Me.cmbRespDistribucionNuevo, True)
         Me.cmbRespDistribucionNuevo.SelectedIndex = -1

         Me.txtIdTipoComprobante.Text = DrPedido.IdTipoComprobante
         Me.txtLetra.Text = DrPedido.Letra
         ''Me.txtCentroEmisor.Text = DrPedido.CentroEmisor.ToString()
         Me.txtNumeroComprobante.Text = DrPedido.NumeroComprobante.ToString()

         Me.dtpFechaEnvio.Value = DrPedido.FechaEnvio
         Me.cmbRespDistribucion.Text = DrPedido.NombreTransportista
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

         If Me.cmbRespDistribucionNuevo.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione un Responsable de Distribución", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         NuevaFecha = dtpFechaEnvioNueva.Value
         NuevoTransportista = DirectCast(cmbRespDistribucionNuevo.SelectedItem, Eniac.Entidades.Transportista)

         DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region
End Class