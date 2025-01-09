Public Class ucConfVentasFacturacionRapida
   Private _publicos As Publicos

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      _publicos = e.Publicos

      e.Publicos.CargaComboTarjetas(cmbFacturacionContadoTarjeta)
      cmbFacturacionContadoTarjeta.SelectedIndex = -1


   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      chbFactRapidaAbrirCajaCompNoFiscal.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaAbrirCajaComprobanteNoFiscal
      chbFacturacionRapidaReempComp.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaReemplazarComprobantes
      chbFacturacionRapidaSolicitaCantidad.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaSolicitaCantidad
      chbFacturacionRapidaModifDescRecGralPorc.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaModificaDescRecGralPorc
      chbFacturacionImpresionFiscalSincronica.Checked = Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionFiscalSincronica
      chbFacturacionRapidaAgrupaProductos.Checked = Reglas.Publicos.Facturacion.Rapida.FacturacionRapidaAgrupaProductos
      chbPermiteModificarCliente.Checked = Reglas.Publicos.Facturacion.Rapida.PermiteModificarClienteFacturacionRapida

      chbFacturacionContadoEsEnTarjeta.Checked = Reglas.Publicos.Facturacion.FacturacionPermiteCobroTarjetaAutomatico
      If Reglas.Publicos.Facturacion.FacturacionPermiteCobroTarjetaAutomatico Then
         cmbFacturacionContadoTarjeta.SelectedValue = Reglas.Publicos.Facturacion.FacturacionTarjetaAutomatico
         bscFacturacionCodigoBancoTarjeta.Text = Reglas.Publicos.Facturacion.FacturacionBancoTarjetaAutomatico.ToString()
         If IsNumeric(bscFacturacionCodigoBancoTarjeta.Text) AndAlso Integer.Parse(bscFacturacionCodigoBancoTarjeta.Text) > 0 Then
            bscFacturacionCodigoBancoTarjeta.PresionarBoton()
         End If
      End If

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONABRIRCAJACOMPNOFISCAL, chbFactRapidaAbrirCajaCompNoFiscal, Nothing, chbFactRapidaAbrirCajaCompNoFiscal.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDAREEMPLAZARCOMP, chbFacturacionRapidaReempComp, Nothing, chbFacturacionRapidaReempComp.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDASOLICITACANTIDAD, chbFacturacionRapidaSolicitaCantidad, Nothing, chbFacturacionRapidaSolicitaCantidad.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMODIFICADESCRECGRALPORC, chbFacturacionRapidaModifDescRecGralPorc, Nothing, chbFacturacionRapidaModifDescRecGralPorc.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONIMPRESIONFISCALSINCRONICA, chbFacturacionImpresionFiscalSincronica, Nothing, chbFacturacionImpresionFiscalSincronica.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDAAGRUPAPRODUCTOS, chbFacturacionRapidaAgrupaProductos, Nothing, chbFacturacionRapidaAgrupaProductos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONRAPIDAPERMITEMODIFICARCLIENTE, chbPermiteModificarCliente, Nothing, chbPermiteModificarCliente.Text)


      ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONPERMITECOBROTARJETAAUTOMATICO, chbFacturacionContadoEsEnTarjeta, Nothing, chbFacturacionContadoEsEnTarjeta.Text)
      If chbFacturacionContadoEsEnTarjeta.Checked Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.FACTURACIONTARJETAAUTOMATICO, cmbFacturacionContadoTarjeta, Nothing, chbFacturacionContadoEsEnTarjeta.Text + " - " + lblTarTarjeta.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.FACTURACIONBANCOTARJETAAUTOMATICO, bscFacturacionCodigoBancoTarjeta, Nothing, chbFacturacionContadoEsEnTarjeta.Text + " - " + lblTarBanco.Text)
      Else
         ActualizarParametroTexto(Entidades.Parametro.Parametros.FACTURACIONTARJETAAUTOMATICO, "0", Nothing, chbFacturacionContadoEsEnTarjeta.Text + " - " + lblTarTarjeta.Text)
         ActualizarParametroTexto(Entidades.Parametro.Parametros.FACTURACIONBANCOTARJETAAUTOMATICO, "0", Nothing, chbFacturacionContadoEsEnTarjeta.Text + " - " + lblTarBanco.Text)
      End If

   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      If chbFacturacionContadoEsEnTarjeta.Checked Then
         If cmbFacturacionContadoTarjeta.SelectedIndex = -1 Then
            e.AgregarError("Debe seleccionar una Tarjeta por defecto para el Pago con Tarjeta.")
            cmbFacturacionContadoTarjeta.Focus()
         End If
         If Not bscFacturacionBancoTarjeta.Selecciono And Not bscFacturacionCodigoBancoTarjeta.Selecciono Then
            e.AgregarError("Debe seleccionar un Banco para el Pago con Tarjeta.")
            bscFacturacionCodigoBancoTarjeta.Focus()
         End If
      End If
   End Sub



   Private Sub bscFacturacionCodigoBancoTarjeta_BuscadorClick() Handles bscFacturacionCodigoBancoTarjeta.BuscadorClick
      FindForm().TryCatched(
         Sub()
            _publicos.PreparaGrillaBancos(bscFacturacionCodigoBancoTarjeta)
            Dim rBanco = New Reglas.Bancos()
            bscFacturacionCodigoBancoTarjeta.Datos = rBanco.GetFiltradoPorCodigo(bscFacturacionCodigoBancoTarjeta.Text.Trim(), True)
         End Sub)
   End Sub

   Private Sub bscTarBanco_BuscadorClick() Handles bscFacturacionBancoTarjeta.BuscadorClick
      FindForm().TryCatched(
         Sub()
            _publicos.PreparaGrillaBancos(bscFacturacionBancoTarjeta)
            Dim rBanco = New Reglas.Bancos()
            bscFacturacionBancoTarjeta.Datos = rBanco.GetFiltradoPorNombre(bscFacturacionBancoTarjeta.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscTarBanco_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscFacturacionBancoTarjeta.BuscadorSeleccion, bscFacturacionCodigoBancoTarjeta.BuscadorSeleccion
      FindForm().TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosTarjetasBancos(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
   Private Sub CargarDatosTarjetasBancos(dr As DataGridViewRow)
      bscFacturacionCodigoBancoTarjeta.Text = dr.Cells("IdBanco").Value.ToString()
      bscFacturacionBancoTarjeta.Text = dr.Cells("NombreBanco").Value.ToString()
   End Sub
   Private Sub chbFacturacionContadoEsEnTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles chbFacturacionContadoEsEnTarjeta.CheckedChanged
      FindForm().TryCatched(
         Sub()
            cmbFacturacionContadoTarjeta.Enabled = chbFacturacionContadoEsEnTarjeta.Checked
            bscFacturacionBancoTarjeta.Enabled = chbFacturacionContadoEsEnTarjeta.Checked
            bscFacturacionCodigoBancoTarjeta.Enabled = chbFacturacionContadoEsEnTarjeta.Checked

            If Not chbFacturacionContadoEsEnTarjeta.Checked Then
               bscFacturacionBancoTarjeta.Text = String.Empty
               bscFacturacionCodigoBancoTarjeta.Text = String.Empty
               cmbFacturacionContadoTarjeta.SelectedIndex = -1
            Else
               If cmbFacturacionContadoTarjeta.Items.Count > 0 Then
                  cmbFacturacionContadoTarjeta.SelectedIndex = 0
               End If
            End If

            cmbFacturacionContadoTarjeta.Focus()
         End Sub)
   End Sub


End Class