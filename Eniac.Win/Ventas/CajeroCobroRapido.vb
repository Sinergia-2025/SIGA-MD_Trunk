Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Public Class CajeroCobroRapido

   Private _publicos As Publicos
   Private _ConfiguracionImpresoras As Boolean
   Private _blnCajasModificables As Boolean = True
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja

   Public Property VentaCajero() As Entidades.VentaCajero

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         If VentaCajero IsNot Nothing Then
            Me._publicos = New Publicos()

            Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, "VENTAS", , , , True)

            If Me.cmbTiposComprobantes.Items.Count = 0 Then
               Me._ConfiguracionImpresoras = True
            End If

            cmbTiposComprobantes.SelectedValue = Reglas.Publicos.TipoComprobanteGeneradoCajero
            If cmbTiposComprobantes.SelectedValue Is Nothing Then
               cmbTiposComprobantes.SelectedIndex = 0
            End If

            Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
            Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
            Me._publicos.CargaComboCajas(Me.cmbCajas, Entidades.Usuario.Actual.Sucursal.Id, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
            Me._publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)
            Me._publicos.CargaComboCategorias(Me.cmbCategoria)


            bscCodigoCliente.Text = VentaCajero.CodigoCliente.ToString()
            bscCliente.Text = VentaCajero.NombreCliente
            cmbVendedor.SelectedText = VentaCajero.NombreVendedor
            cmbFormaPago.SelectedValue = VentaCajero.IdFormasPago
            cmbCategoria.SelectedValue = VentaCajero.IdCategoria
            cmbCategoriaFiscal.SelectedValue = VentaCajero.IdCategoriaFiscal
            txtTotalGeneral.Text = VentaCajero.ImporteTotal.ToString("N2")

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CajeroCobroRapido_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      Try
         If e.KeyCode = Keys.F4 Then
            Aceptar()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CajeroCobroRapido_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Try
         If _ConfiguracionImpresoras Then
            MessageBox.Show("No Existe la PC en Configuraciones/Impresoras", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub


   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Try
         DialogResult = Windows.Forms.DialogResult.Cancel
         Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         Aceptar()
         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbTiposComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged
      Try
         'cada vez que selecciono un comprobante, pongo la fecha de hoy en el comprobante y si es fiscal no lo permito modificar
         If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
            Exit Sub
         End If
         If Me.cmbTiposComprobantes.Items.Count > 0 Then
            If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
               Me.dtpFecha.Enabled = Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal
               If Not Me.dtpFecha.Enabled Then
                  Me.dtpFecha.Value = New Reglas.Generales().GetServerDBFechaHora   ' Date.Now
               End If
            End If
         End If

         'solo habilito el boton de Facturables segun corresponde (si Eligio Factura en blanco o negro, tickets, etc)
         If Me.cmbTiposComprobantes.SelectedValue IsNot Nothing Then
            'Si es X es remito, siempre debe tener esa letra, sino dejo la que esta.
            If DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas.Length = 1 Then
               Me.txtLetra.Text = DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).LetrasHabilitadas
            Else
               If Me.cmbCategoriaFiscal.SelectedIndex >= 0 Then
                  Me.txtLetra.Text = DirectCast(Me.cmbCategoriaFiscal.SelectedItem, Entidades.CategoriaFiscal).LetraFiscal
               Else
                  Me.txtLetra.Text = ""
               End If
            End If

            Me.chbNumeroAutomatico.Checked = True
            Me.chbNumeroAutomatico.Enabled = Reglas.Publicos.Facturacion.FacturacionModificaNumeroComprobante And Not DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsFiscal
         End If

         Me.CargarProximoNumero()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub chbNumeroAutomatico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      Me.txtNumeroPosible.ReadOnly = chbNumeroAutomatico.Checked
   End Sub

   Private Sub CargarProximoNumero()
      If Me.txtLetra.Text <> "" Then
         Dim oImpresora As Entidades.Impresora
         Dim oVentasNumeros As New Reglas.VentasNumeros
         Dim CentroEmisor As Short

         oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, Me.cmbTiposComprobantes.SelectedValue.ToString())
         CentroEmisor = oImpresora.CentroEmisor

         Me.txtNumeroPosible.Text = oVentasNumeros.GetProximoNumero(actual.Sucursal, _
                                                                    DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).IdTipoComprobante, _
                                                                    Me.txtLetra.Text, _
                                                                    CentroEmisor).ToString()
         Me.txtNumeroPosible.Tag = oImpresora.Marca
      Else
         Me.txtNumeroPosible.Text = ""
         Me.txtNumeroPosible.Tag = ""
      End If
   End Sub

   Private Sub Aceptar()
      Dim rVentaCajero As Reglas.VentasCajeros = New Reglas.VentasCajeros()
      rVentaCajero.CobroRapido(VentaCajero, dtpFecha.Value, DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante), Integer.Parse(cmbCajas.SelectedValue.ToString()), Entidades.Entidad.MetodoGrabacion.Automatico, Me.IdFuncion)
   End Sub

End Class