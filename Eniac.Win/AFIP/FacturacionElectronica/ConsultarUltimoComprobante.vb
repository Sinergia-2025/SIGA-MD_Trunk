Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ConsultarUltimoComprobante

   Private _publicos As Publicos
   Public ConsultarAutomaticamente As Boolean = False
   Private _Letra As String = ""
   Private _CentroEmisor As Short = 0

#Region "Constructores"


   Public Sub New()

      Me.InitializeComponent()

   End Sub


   Public Sub New(ByVal Letra As String, ByVal CentroEmisor As Short)

      Me.New()

      Me._Letra = Letra
      Me._CentroEmisor = CentroEmisor

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me._publicos.CargaComboTiposComprobantesElectronicos(Me.cmbTiposComprobantes, "NO")

      Dim aTipoFactura As ArrayList = New ArrayList()
      aTipoFactura.Insert(0, "A")
      aTipoFactura.Insert(1, "B")
      aTipoFactura.Insert(2, "C")
      aTipoFactura.Insert(3, "E")
      aTipoFactura.Insert(4, "M")

      Me.cmbLetra.DataSource = aTipoFactura

      If ConsultarAutomaticamente Then
         Me.cmbLetra.Text = Me._Letra.ToString()
         Me.txtEmisor.Text = Me._CentroEmisor.ToString()
         Me.btnObtener.PerformClick()
      End If

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnObtenerUltimoNroComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtener.Click
      Try
         If Not Publicos.HayInternet() Then
            MessageBox.Show("No tiene internet para realizar esta acción.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
         End If

         If Integer.Parse(Me.txtEmisor.Text) = 0 Then
            MessageBox.Show("Tiene que ingresar un Emisor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtEmisor.Focus()
            Exit Sub
         End If

         Cursor = Cursors.WaitCursor

         LimpiarCampos()

         Dim impresora = New Reglas.Impresoras().GetUna(actual.Sucursal.Id, txtEmisor.ValorNumericoPorDefecto(0I))
         If Not impresora.UtilizaBonosFiscalesElectronicos Then
            If cmbLetra.Text <> "E" Then
               Dim reg As Reglas.AFIPFE = New Reglas.AFIPFE()
               txtUltimoNroComprobante.Text = reg.GetUltimoComprobanteAutorizadoV1(cmbTiposComprobantes.SelectedValue.ToString(), cmbLetra.Text, Int32.Parse(txtEmisor.Text)).ToString()
            Else
               Dim eTipoCpte = New Reglas.AFIPTiposComprobantes().GetUno(cmbTiposComprobantes.SelectedValue.ToString(), cmbLetra.Text)
               '-- Recupera el Ultimo Comprobante Autorizado.- --
               Dim reg = New Reglas.AFIPFEX
               txtUltimoNroComprobante.Text = reg.GetRecuperaUltCompExp(Convert.ToInt16(eTipoCpte.IdAFIPTipoComprobante), Int32.Parse(txtEmisor.Text)).ToString()
            End If
         Else
            Dim reg As Reglas.AFIPBFE = New Reglas.AFIPBFE()
            txtUltimoNroComprobante.Text = reg.GetUltimoComprobanteAutorizado(cmbTiposComprobantes.SelectedValue.ToString(), cmbLetra.Text, Int32.Parse(txtEmisor.Text)).ToString()
         End If

         tsbAplicar.Enabled = True
         GetUltimoComprobante()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tsbAplicar.Enabled = False
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub cmbTiposComprobantes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged
      Try
         Me.LimpiarCampos()
         Me.CargarEmisor()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbLetra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLetra.SelectedIndexChanged
      Me.LimpiarCampos()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarEmisor()

      If Me.cmbTiposComprobantes.SelectedIndex >= 0 Then

         Dim oImpresoras As New Reglas.Impresoras
         Dim oVentasNumeros As New Reglas.VentasNumeros

         Me.txtEmisor.Text = oImpresoras.GetPorSucursalTipoComprobante(actual.Sucursal.Id, _
                                                                       Me.cmbTiposComprobantes.SelectedValue.ToString()).CentroEmisor.ToString()
      End If

      Me.tsbAplicar.Enabled = False

   End Sub

   Private Sub LimpiarCampos()
      'Me.txtEmisor.Text = "1"
      Me.txtUltimoNroComprobante.Text = String.Empty
      Me.txtFecha.Text = String.Empty
      Me.txtTipoDoc.Text = String.Empty
      Me.txtNroDoc.Text = String.Empty
      Me.txtCliente.Text = String.Empty
      Me.txtCAE.Text = String.Empty
      Me.txtVenCAE.Text = String.Empty
      Me.txtImporteTotal.Text = String.Empty
      Me.txtObservaciones.Text = String.Empty
      Me.txtNeto.Text = String.Empty
      Me.txtIVA.Text = String.Empty
   End Sub

   Private Sub AplicarUltimoNumero()

      Dim oVN As Entidades.VentaNumero = New Entidades.VentaNumero()
      Dim oVNRe As Reglas.VentasNumeros = New Reglas.VentasNumeros()

      With oVN
         .IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         .LetraFiscal = Me.cmbLetra.Text
         .CentroEmisor = Short.Parse(Me.txtEmisor.Text)
         .IdSucursal = actual.Sucursal.Id
         .Numero = Long.Parse(Me.txtUltimoNroComprobante.Text)
      End With

      oVNRe.Actualizar(oVN)

   End Sub

   Private Sub GetUltimoComprobante()

      If String.IsNullOrEmpty(Me.txtUltimoNroComprobante.Text) OrElse Long.Parse(Me.txtUltimoNroComprobante.Text) = 0 Then
         Exit Sub
      End If

      Dim idTipoComprobante As String = Me.cmbTiposComprobantes.SelectedValue.ToString()
      Dim letra As String = Me.cmbLetra.SelectedValue.ToString()
      Dim centroEmisor As Integer = Int32.Parse(Me.txtEmisor.Text)
      Dim numeroComprobante As Long = Long.Parse(Me.txtUltimoNroComprobante.Text)

      Dim regAFI As Reglas.AFIPTiposDocumentos = New Reglas.AFIPTiposDocumentos()
      Dim rCli As Reglas.Clientes = New Reglas.Clientes()

      Dim impresora = New Reglas.Impresoras().GetUna(actual.Sucursal.Id, centroEmisor)
      If Not impresora.UtilizaBonosFiscalesElectronicos Then

         If Me.cmbLetra.SelectedValue.ToString() <> "E" Then
            Dim reg = New Reglas.AFIPFE()
            Dim comp = reg.GetComprobanteEmitidoV1(idTipoComprobante, letra, numeroComprobante, centroEmisor)

            Me.txtFecha.Text = comp.CbteFch.Substring(6, 2) + "/" + comp.CbteFch.Substring(4, 2) + "/" + comp.CbteFch.Substring(0, 4)
            Me.txtTipoDoc.Text = regAFI.GetIdTipoDocumento(comp.DocTipo)
            Me.txtNroDoc.Text = comp.DocNro.ToString()

            Dim cli As Entidades.Cliente = rCli.GetUnoPorTipoYNroDocumento(Me.txtTipoDoc.Text, Long.Parse(Me.txtNroDoc.Text))
            If cli Is Nothing Then
               cli = rCli.GetUnoPorCUIT(comp.DocNro.ToString())
            End If
            If cli IsNot Nothing Then
               Me.txtCliente.Text = cli.NombreCliente
            End If
            Me.txtCAE.Text = comp.CodAutorizacion
            Me.txtVenCAE.Text = comp.FchVto.Substring(6, 2) + "/" + comp.FchVto.Substring(4, 2) + "/" + comp.FchVto.Substring(0, 4)
            Me.txtNeto.Text = comp.ImpNeto.ToString("0.00")
            Me.txtIVA.Text = comp.ImpIVA.ToString("0.00")
            Me.txtImporteTotal.Text = comp.ImpTotal.ToString("0.00")

            Me.txtObservaciones.Text = String.Empty
            If comp.Observaciones IsNot Nothing Then
               For Each ob As Eniac.Reglas.WSFEv1.Obs In comp.Observaciones
                  Me.txtObservaciones.Text += ob.Code.ToString() + " - " + ob.Msg + Convert.ToChar(Keys.Enter)
               Next
            End If
         Else

            Dim eTipoCpte = New Reglas.AFIPTiposComprobantes().GetUno(cmbTiposComprobantes.SelectedValue.ToString(), cmbLetra.Text)
            '-- Recupera los Datos del Ultimo Comprobante Autorizado.- --
            Dim reg = New Reglas.AFIPFEX
            Dim comp = reg.GetRecuperaComprobanteExp(Convert.ToInt16(eTipoCpte.IdAFIPTipoComprobante), numeroComprobante, centroEmisor)

            Me.txtFecha.Text = comp.Fecha_cbte.ToDateTimeFormatoPropio("yyyyMMdd").ToString()

            Me.txtTipoDoc.Text = regAFI.GetIdTipoDocumento(80)
            Me.txtNroDoc.Text = comp.Cuit_pais_cliente.ToString()

            Me.txtCliente.Text = comp.Cliente.ToString()

            Me.txtCAE.Text = comp.Cae
            Me.txtVenCAE.Text = comp.Fch_venc_Cae.ToDateTimeFormatoPropio("yyyyMMdd").ToString()

            Me.txtNeto.Text = "0.00"
            Me.txtIVA.Text = "0.00"
            Me.txtImporteTotal.Text = comp.Imp_total.ToString("0.00")

            Me.txtObservaciones.Text = "Id de TRansaccion: " + comp.Id.ToString()

         End If
      Else
         Dim reg As Reglas.AFIPBFE = New Reglas.AFIPBFE()
            Dim comp As Reglas.WSBFE.ClsBFEGetCMPR = reg.GetComprobanteEmitido(idTipoComprobante, letra, numeroComprobante, centroEmisor)
            Me.txtFecha.Text = comp.Fecha_cbte_orig.Substring(6, 2) + "/" + comp.Fecha_cbte_orig.Substring(4, 2) + "/" + comp.Fecha_cbte_orig.Substring(0, 4)
            Me.txtTipoDoc.Text = regAFI.GetIdTipoDocumento(comp.Tipo_doc)
            Me.txtNroDoc.Text = comp.Nro_doc.ToString()

            Dim cli As Entidades.Cliente = rCli.GetUnoPorTipoYNroDocumento(Me.txtTipoDoc.Text, Long.Parse(Me.txtNroDoc.Text))
            If cli Is Nothing Then
                cli = rCli.GetUnoPorCUIT(comp.Nro_doc.ToString())
            End If
            If cli IsNot Nothing Then
                Me.txtCliente.Text = cli.NombreCliente
            End If
            Me.txtCAE.Text = comp.Cae
            Me.txtVenCAE.Text = comp.Fch_venc_Cae.Substring(6, 2) + "/" + comp.Fch_venc_Cae.Substring(4, 2) + "/" + comp.Fch_venc_Cae.Substring(0, 4)
            Me.txtNeto.Text = comp.Imp_neto.ToString("0.00")
            Me.txtIVA.Text = comp.Impto_liq.ToString("0.00")
            Me.txtImporteTotal.Text = comp.Imp_total.ToString("0.00")

            Me.txtObservaciones.Text = String.Empty
            If comp.Obs IsNot Nothing Then
                Me.txtObservaciones.Text = comp.Obs
            End If

      End If

   End Sub

#End Region

   Private Sub tsbAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAplicar.Click
      Try
         If Me.cmbTiposComprobantes.SelectedIndex = -1 Then
            MessageBox.Show("Antes Debe Elegir un Tipo de Comprobante y Obtener.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If

         If Me.cmbLetra.SelectedIndex = -1 Then
            MessageBox.Show("Antes Debe Elegir un Emisor y Obtener.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbLetra.Focus()
            Exit Sub
         End If

         If MessageBox.Show("Esta seguro que quiere aplicar el número de comprobante a las tablas del sistema?", _
                            Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                            MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Me.AplicarUltimoNumero()

            MessageBox.Show("¡¡ Número actualizado CORRECTAMENTE !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

End Class