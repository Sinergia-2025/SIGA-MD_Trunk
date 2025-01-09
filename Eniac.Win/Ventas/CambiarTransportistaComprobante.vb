#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports System.ComponentModel
#End Region

Public Class CambiarTransportistaComprobante
#Region "Campos"
	Private _publicos As Publicos
   Public Enum ModoCambioMasivo As Integer
      <Description("Solo Actual")>
      SoloActual = 0
      Seleccionados = 1
      Todos = 2
   End Enum
   Public Property CambiosMasivos() As ModoCambioMasivo
#End Region

#Region "Propiedades"
   '-- Propiedades de traspaso.- ------------
   Public Property IdRespDist As Integer
   Public Property IdRespDistAct As Integer
   Public Property NomTransport As String
   Public Property Comprobante As String
   Public Property ComprobanteAct As String
   '----------------------------------------
   Public Property IdTipoComprobante() As String
   Public Property Letra() As String
   Public Property CentroEmisor() As Short
   Public Property NumeroPedido() As Long
   '---------------------------------------
   Public Property PedidosSeleccionados() As Integer
   Public Property TotaldePedidos() As Integer

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Cursor = Cursors.WaitCursor
         _publicos = New Publicos()
         '-- Carga Combo de Cambios Masivos.- --
         _publicos.CargaComboDesdeEnum(cmbCambioMasivo, GetType(OrganizarEntregasV2.ModoCambioMasivo))
         '-- Carga Combo de Tipos de Comprobantes.- -------------------------------
         _publicos.CargaComboTiposComprobantes(cmbTipoComprobanteNuevo, True, "VENTAS", , , , True, coeficienteValor:=1)
         '-------------------------------------------------------------------------
         '-- Carga Valores de Pedidos Seleccionados y Total de Pedidos.- ----------
         txtPedidosSeleccionados.Text = PedidosSeleccionados.ToString()
         txtTotalPedidos.Text = TotaldePedidos.ToString()
         '-- Carga Valores de Comprobante Actual.- --------------------------------
         txtIdTipoComprobante.Text = IdTipoComprobante
         txtLetra.Text = Letra
         txtNumeroComprobante.Text = NumeroPedido.ToString()
         '-------------------------------------------------------------------------
         Text = "Modificación Transportista-Comprobante"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Eventos"
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      gpbTipoComprobante.Enabled = chbTipoComprobante.Checked
      cmbCambioMasivo.Select()
   End Sub
   Private Sub chbResponsableDistribucion_CheckedChanged(sender As Object, e As EventArgs) Handles chbResponsableDistribucion.CheckedChanged
      gpbResponsableDistribucion.Enabled = chbResponsableDistribucion.Checked
      bscCodigoRDNuevo.Select()
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub
   ''' <summary>
   ''' Buscador de Transportista Nuevo.-
   ''' </summary>
   Private Sub bscCodigoRDNuevo_BuscadorClick() Handles bscCodigoRDNuevo.BuscadorClick
      Try
         Dim vIdTrans As Long = 0
         Dim oTransportistas = New Reglas.Transportistas
         Me._publicos.PreparaGrillaTransportistas(bscCodigoRDNuevo)
         If Not String.IsNullOrEmpty(bscCodigoRDNuevo.Text) Then
            vIdTrans = Long.Parse(bscCodigoRDNuevo.Text)
         End If
         bscCodigoRDNuevo.Datos = oTransportistas.GetFiltradoPorCodigo(vIdTrans, False)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub bscCodigoRDNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRDNuevo.BuscadorSeleccion
      Try
         If e.FilaDevuelta IsNot Nothing Then
            CargarDatosTransportista2(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscNombreRDNuevo_BuscadorClick() Handles bscNombreRDNuevo.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(bscNombreRDNuevo)
         Dim oTransportistas As Reglas.Transportistas = New Reglas.Transportistas
         bscNombreRDNuevo.Datos = oTransportistas.GetFiltradoPorNombre(bscNombreRDNuevo.Text.Trim(), True)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscNombreRDNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreRDNuevo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista2(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos"
   ''' <summary>
   ''' Carga deatos de Buscador Transportista.-
   ''' </summary>
   ''' <param name="dr"></param>
   Private Sub CargarDatosTransportista2(dr As DataGridViewRow)
      bscCodigoRDNuevo.Text = dr.Cells("IdTransportista").Value.ToString()
      bscNombreRDNuevo.Text = dr.Cells("NombreTransportista").Value.ToString()
   End Sub

   Protected Overrides Sub Aceptar()
      Try
         If Not ValidarDatos() Then Exit Sub
         Me.Cursor = Cursors.WaitCursor

         CambiosMasivos = DirectCast(cmbCambioMasivo.SelectedValue, ModoCambioMasivo)

         If chbResponsableDistribucion.Checked Then
            IdRespDist = Integer.Parse(bscCodigoRDNuevo.Text)
            NomTransport = bscNombreRDNuevo.Text
         End If
         If chbTipoComprobante.Checked Then
            Comprobante = cmbTipoComprobanteNuevo.SelectedValue.ToString()
         End If
         DialogResult = Windows.Forms.DialogResult.OK
         Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function ValidarDatos() As Boolean
      If chbResponsableDistribucion.Checked And Not bscCodigoRDNuevo.Selecciono And Not bscNombreRDNuevo.Selecciono Then
         ShowMessage("ATENCIÓN: Debe seleccionar un Responsable de Distribucion nuevo.")
         bscCodigoRDNuevo.Focus()
         Return False
      End If
      If chbTipoComprobante.Checked And cmbTipoComprobanteNuevo.SelectedIndex = -1 Then
         ShowMessage("ATENCIÓN: Debe seleccionar un Tipo de Comprobante nuevo.")
         cmbTipoComprobanteNuevo.Focus()
         Return False
      End If
      Return True
   End Function
#End Region
End Class