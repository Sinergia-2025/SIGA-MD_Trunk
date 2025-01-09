Public Class ucConfArchivosClientes
   Private IdUsuario As String = actual.Nombre

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbConfiguracionMail, GetType(Entidades.Cliente.ConfiguracionMail), , True)
      e.Publicos.CargaComboZonasGeograficas(cmbZonasGeograficas)
      If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
         IdUsuario = ""
      End If
      e.Publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
      cmbVendedor.SelectedIndex = -1
      e.Publicos.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR, IdUsuario)
      cmbCobrador.SelectedIndex = -1
      e.Publicos.CargaComboListaDePrecios(cmbListasDePrecios, activa:=True, insertarEnPosicionCero:=Nothing)
      ' cmbListasDePrecios.SelectedIndex = -1
      e.Publicos.CargaComboCategorias(cmbCategorias)
      e.Publicos.CargaComboTipoClientes(cmbTipos)
      e.Publicos.CargaComboCategoriasFiscales(cmbCF)

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Solapas
      chbClienteTieneTrabajo.Checked = Reglas.Publicos.ClienteTieneTrabajo
      chbClienteTieneGarante.Checked = Reglas.Publicos.ClienteTieneGarante
      chbClienteUtilizaGeolocalizacion.Checked = Reglas.Publicos.ClienteUtilizaGeolocalizacion
      chbClienteMultiplesDirecciones.Checked = Reglas.Publicos.ClienteTieneMultiplesDirecciones
      chbClienteOtros.Checked = Reglas.Publicos.ClienteUtilizaOtros
      chbClienteContactos.Checked = Reglas.Publicos.ClienteUtilizaContactos
      chbClienteAdjuntos.Checked = Reglas.Publicos.ClienteUtilizaAdjuntos
      chbClienteImpuestos.Checked = Reglas.Publicos.ClienteUtilizaImpuestos
      chbClienteHorarios.Checked = Reglas.Publicos.ClienteUtilizaHorarios
      txtClientesCantidadDeVisitas.Text = Reglas.Publicos.ClienteCantidadVisitasPorDefecto.ToString()


      chbClientePermiteModificarCodigo.Checked = Reglas.Publicos.ClientePermiteModificarCodigo
      chbClienteSucursalAsociada.Checked = Reglas.Publicos.ClienteTieneSucursalAsociada
      chbClienteBuscarPorCodigoYNroDocumento.Checked = Reglas.Publicos.ClienteBuscarPorCodigoYNroDocumento
      chbClienteProductosAsociados.Checked = Reglas.Publicos.ClienteMostrarProductosAsociados
      chbClienteMuestraCodigoLetras.Checked = Reglas.Publicos.ClienteMuestraCodigoClienteLetras
      '-- REQ-34505.- -------------------------------------------------------------
      chbAltaPublicarenWeb.Checked = Reglas.Publicos.AltaNuevoClientePublicarenWeb
      '----------------------------------------------------------------------------
      chbContactosAgendaPrivada.Checked = Reglas.Publicos.ContactosAgendaPrivada
      chbForzarListaDePreciosCliente.Checked = Reglas.Publicos.ForzarListaDePreciosCliente         ' Forzar al Cliente ingresar la Lista de Precios cuando se lo da de alta
      chbClienteUtilizaCalle.Checked = Reglas.Publicos.ClienteUtilizaCalle

      'Campos Requeridos
      chbClienteRequiereTelefono.Checked = Reglas.Publicos.ClienteRequiereTelefono
      chbClienteRequiereCelular.Checked = Reglas.Publicos.ClienteRequiereCelular
      chbClienteRequiereCorreoElectronico.Checked = Reglas.Publicos.ClienteRequiereCorreoElectronico
      chbClienteRequiereCorreoAdministrativo.Checked = Reglas.Publicos.ClienteRequiereCorreoAdministrativo


      cmbConfiguracionMail.SelectedValue = Reglas.Publicos.ConfiguraciónMail

      If Reglas.Publicos.ClienteZonaGeograficaPorDefecto.ToString() = "-1" Then
         chbZonaGeografica.Checked = False
         cmbZonasGeograficas.SelectedIndex = -1
      Else
         chbZonaGeografica.Checked = True
         cmbZonasGeograficas.SelectedValue = Reglas.Publicos.ClienteZonaGeograficaPorDefecto
      End If

      If Reglas.Publicos.ClienteVendedorPorDefecto = 0 Then
         chbVendedor.Checked = False
         cmbVendedor.SelectedIndex = -1
      Else
         chbVendedor.Checked = True
         cmbVendedor.SelectedValue = Reglas.Publicos.ClienteVendedorPorDefecto
      End If


      If Reglas.Publicos.ClienteCobradorPorDefecto = 0 Then
         chbCobrador.Checked = False
         cmbCobrador.SelectedIndex = -1
      Else
         chbCobrador.Checked = True
         cmbCobrador.SelectedValue = Reglas.Publicos.ClienteCobradorPorDefecto
      End If

      If Reglas.Publicos.ClienteListaDePreciosPorDefecto = 0 Then
         chbListaPrecios.Checked = False
         cmbListasDePrecios.SelectedIndex = -1
      Else
         chbListaPrecios.Checked = True
         cmbListasDePrecios.SelectedValue = Reglas.Publicos.ClienteListaDePreciosPorDefecto
      End If

      If Reglas.Publicos.ClienteCategoriaPorDefecto = 0 Then
         chbCategoria.Checked = False
         cmbCategorias.SelectedIndex = -1
      Else
         chbCategoria.Checked = True
         cmbCategorias.SelectedValue = Reglas.Publicos.ClienteCategoriaPorDefecto
      End If

      If Reglas.Publicos.ClienteTipoPorDefecto = 0 Then
         chbTipo.Checked = False
         cmbTipos.SelectedIndex = -1
      Else
         chbTipo.Checked = True
         cmbTipos.SelectedValue = Reglas.Publicos.ClienteTipoPorDefecto
      End If

      If Reglas.Publicos.ClienteCategoriaFiscalPorDefecto = 0 Then
         chbCategoriaFiscal.Checked = False
         cmbCF.SelectedIndex = -1
      Else
         chbCategoriaFiscal.Checked = True
         cmbCF.SelectedValue = Reglas.Publicos.ClienteCategoriaFiscalPorDefecto
      End If

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)


      'Solapas
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTETIENETRABAJO, chbClienteTieneTrabajo, Nothing, chbClienteTieneTrabajo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTETIENEGARANTE, chbClienteTieneGarante, Nothing, chbClienteTieneGarante.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEUTILIZAGEOLOCALIZACION, chbClienteUtilizaGeolocalizacion, Nothing, chbClienteUtilizaGeolocalizacion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEMULTIPLESDIRECCIONES, chbClienteMultiplesDirecciones, Nothing, chbClienteMultiplesDirecciones.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEUTILIZAOTROS, chbClienteOtros, Nothing, chbClienteOtros.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEUTILIZACONTACTOS, chbClienteContactos, Nothing, chbClienteContactos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEUTILIZAADJUNTOS, chbClienteAdjuntos, Nothing, chbClienteAdjuntos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEUTILIZAIMPUESTOS, chbClienteImpuestos, Nothing, chbClienteImpuestos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEUTILIZAHORARIOS, chbClienteHorarios, Nothing, chbClienteHorarios.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTESCANTIDADVISITASPORDEFECTO, txtClientesCantidadDeVisitas, Nothing, lblClientesCantidadVisitas.Text)


      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEPERMITEMODIFICARCODIGO, chbClientePermiteModificarCodigo, Nothing, chbClientePermiteModificarCodigo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTETIENESUCURSALASOC, chbClienteSucursalAsociada, Nothing, chbClienteSucursalAsociada.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEBUSCARPORCODIGOYNRODOCUMENTO, chbClienteBuscarPorCodigoYNroDocumento, Nothing, chbClienteBuscarPorCodigoYNroDocumento.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEMOSTRARPRODUCTOSASOCIADOS, chbClienteProductosAsociados, Nothing, chbClienteProductosAsociados.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEMUESTRACODIGOLETRAS, chbClienteMuestraCodigoLetras, Nothing, chbClienteMuestraCodigoLetras.Text)
      '-- REQ-34505.- -------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.ALTANUEVOCLIENTEPUBLICAWEB, chbAltaPublicarenWeb, Nothing, chbAltaPublicarenWeb.Text)
      '----------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.CONTACTOSAGENDAPRIVADA, chbContactosAgendaPrivada, Nothing, chbContactosAgendaPrivada.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FORZARLISTADEPRECIOSCLIENTE, chbForzarListaDePreciosCliente, Nothing, chbForzarListaDePreciosCliente.Text)     ' Forzar Lista de Precios al momento de dar de alta un cliente
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEUTILIZACALLE, chbClienteUtilizaCalle, Nothing, chbClienteUtilizaCalle.Text)


      'Campos Requeridos
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEREQUIERETELEFONO, chbClienteRequiereTelefono, Nothing, chbClienteRequiereTelefono.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEREQUIERECELULAR, chbClienteRequiereCelular, Nothing, chbClienteRequiereCelular.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEREQUIERECORREOELECTRONICO, chbClienteRequiereCorreoElectronico, Nothing, chbClienteRequiereCorreoElectronico.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEREQUIERECORREOADMINISTRATIVO, chbClienteRequiereCorreoAdministrativo, Nothing, chbClienteRequiereCorreoAdministrativo.Text)


      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.CONFIGURACIONMAIL, cmbConfiguracionMail, Nothing, cmbConfiguracionMail.SelectedText)

      ActualizarParametroClaveTexto(Entidades.Parametro.Parametros.CLIENTESZONAGEOGRAFICAPORDEFECTO.ToString(), If(chbZonaGeografica.Checked, cmbZonasGeograficas.SelectedValue.ToString(), "-1"), Nothing, chbZonaGeografica.Text)

      '      ActualizarParametroClaveTexto(Of String)(Entidades.Parametro.Parametros.CLIENTESZONAGEOGRAFICAPORDEFECTO, cmbZonasGeograficas, Nothing, chbZonaGeografica.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CLIENTESVENDEDORPORDEFECTO, cmbVendedor, Nothing, chbVendedor.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CLIENTESCOBRADORPORDEFECTO, cmbCobrador, Nothing, chbCobrador.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CLIENTESLISTADEPRECIOSPORDEFECTO, cmbListasDePrecios, Nothing, chbListaPrecios.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CLIENTESCATEGORIAPORDEFECTO, cmbCategorias, Nothing, chbCategoria.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CLIENTESTIPOPORDEFECTO, cmbTipos, Nothing, chbTipo.Text)
      ActualizarParametro(Of Short)(Entidades.Parametro.Parametros.CLIENTESCATEGORIAFISCALPORDEFECTO, cmbCF, Nothing, chbCategoriaFiscal.Text)

   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      Select Case chbZonaGeografica.Checked
         Case True
            cmbZonasGeograficas.Enabled = True
         Case False
            cmbZonasGeograficas.Enabled = False
            cmbZonasGeograficas.SelectedIndex = -1
      End Select
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      Select Case chbVendedor.Checked
         Case True
            cmbVendedor.Enabled = True
         Case False
            cmbVendedor.Enabled = False
            cmbVendedor.SelectedIndex = -1
      End Select
   End Sub

   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged
      Select Case chbCobrador.Checked
         Case True
            cmbCobrador.Enabled = True
         Case False
            cmbCobrador.Enabled = False
            cmbCobrador.SelectedIndex = -1
      End Select
   End Sub

   Private Sub chbListaPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaPrecios.CheckedChanged
      Select Case chbListaPrecios.Checked
         Case True
            cmbListasDePrecios.Enabled = True
         Case False
            cmbListasDePrecios.Enabled = False
            cmbListasDePrecios.SelectedIndex = -1
      End Select
   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      Select Case chbCategoria.Checked
         Case True
            cmbCategorias.Enabled = True
         Case False
            cmbCategorias.Enabled = False
            cmbCategorias.SelectedIndex = -1
      End Select
   End Sub

   Private Sub chbTipo_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipo.CheckedChanged
      Select Case chbTipo.Checked
         Case True
            cmbTipos.Enabled = True
         Case False
            cmbTipos.Enabled = False
            cmbTipos.SelectedIndex = -1
      End Select
   End Sub

   Private Sub chbCategoriaFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaFiscal.CheckedChanged
      Select Case chbCategoriaFiscal.Checked
         Case True
            cmbCF.Enabled = True
         Case False
            cmbCF.Enabled = False
            cmbCF.SelectedIndex = -1
      End Select
   End Sub
End Class