Option Explicit On
Option Strict Off

Public Class CambiarTipoComprobante

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Propiedades"

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
   'Private _Pedido As Eniac.Entidades.Venta
   'Public Property Pedido() As Eniac.Entidades.Venta
   '   Get
   '      Return _Pedido
   '   End Get
   '   Set(ByVal value As Eniac.Entidades.Venta)
   '      _Pedido = value
   '   End Set
   'End Property

   Private _comprobante As String
   Public Property comprobante() As String
      Get
         Return _comprobante
      End Get
      Set(ByVal value As String)
         _comprobante = value
      End Set
   End Property

   Public Property CambioMasivo() As OrganizarEntregasV2.ModoCambioMasivo


#End Region

#Region "Overrides"



   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos = New Publicos()

         Me.lblcompActual.Text = Me._comprobante

         'Me._publicos.CargaComboTiposComprobantes(Me.cmbtComprNuevo, False, "VENTAS")
         Me._publicos.CargaComboTiposComprobantes(Me.cmbtComprNuevo, True, "VENTAS", , , , True, coeficienteValor:=1) '# Traigo solo los comprobantes que no son negativos
         Me.cmbtComprNuevo.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbCambioMasivo, GetType(OrganizarEntregasV2.ModoCambioMasivo))

         Me.txtIdTipoComprobante.Text = IdTipoComprobante
         Me.txtLetra.Text = Letra
         Me.txtNumeroComprobante.Text = NumeroPedido
         ' Me.cmbTcomprobante.Text = _Pedido.Transportista.NombreTransportista.ToString()

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

         Me.ModificarTComp()
         DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"

   Public Sub ModificarTComp()


      Me.comprobante = Me.cmbtComprNuevo.SelectedValue.ToString()
      Me.CambioMasivo = DirectCast(cmbCambioMasivo.SelectedValue, OrganizarEntregasV2.ModoCambioMasivo)


      'Dim oPedido As Reglas.Pedidos = New Reglas.Pedidos()

      'oPedido.ModificarTComp(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal,
      '                       IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, comprobante)

      ' ''Dim oVenta As Reglas.Ventas = New Reglas.Ventas()
      ' ''Pedido.TipoComprobanteFact = tipoCompFact.GetUno(Me.cmbtComprNuevo.SelectedValue.ToString())
      ' ''oVenta.ModificarTComp(Pedido)

      'MessageBox.Show("¡¡¡ Tipo de Comprobante modificado Exitosamente !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

   End Sub

#End Region


End Class