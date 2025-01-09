Public Class ucConfCalidad
   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      'e.Publicos.CargaComboEstadosCalidad(cmbEstadoListaPendiente)
      'e.Publicos.CargaComboEstadosCalidad(cmbEstadoListaProceso)
      'e.Publicos.CargaComboEstadosCalidad(cmbEstadoListaTerminada)

   End Sub
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      If cmbEstadoListaPendiente.Items.Count > 0 Then
         cmbEstadoListaPendiente.SelectedValue = Reglas.Publicos.EstadoListaControlPendiente
      End If
      If cmbEstadoListaProceso.Items.Count > 0 Then
         cmbEstadoListaProceso.SelectedValue = Reglas.Publicos.EstadoListaControlEnProceso
      End If
      If cmbEstadoListaTerminada.Items.Count > 0 Then
         cmbEstadoListaTerminada.SelectedValue = Reglas.Publicos.EstadoListaControlTerminado
      End If

      txtBaseExternaClientes.Text = Reglas.Publicos.CalidadBaseExternaClientes
      txtCalidadPanelControlTiempoRefresco.Text = Reglas.Publicos.CalidadPanelDeControlTiempoRefresco.ToString()
      chbCalidadUtilizaModelo.Checked = Reglas.Publicos.CalidadUtilizaModeloAsignacionListas
      chbCalidadUtilizaPagAutomaticoPanelPlanta.Checked = Reglas.Publicos.CalidadUtilizaPagAutomaticoPanelControlPlanta
      txtCalidadPanelControlPlantaPag.Text = Reglas.Publicos.CalidadPanelDeControlPlantaTiempoPaginado.ToString()
      txtURLHeaderPC.Text = Reglas.Publicos.CalidadURLHeaderPC.ToString()
      txtURLHeaderURBPC.Text = Reglas.Publicos.CalidadURLHeaderURBPC.ToString()
      txtURLHeaderMyLPC.Text = Reglas.Publicos.CalidadURLHeaderMyLPC.ToString()

      txtItemsPC.Text = Reglas.Publicos.CalidadURLItemsPC.ToString()
      txtSincroPC.Text = Reglas.Publicos.CalidadURLSincroPC.ToString()

      txtURLHeaderFS.Text = Reglas.Publicos.CalidadURLHeaderFS.ToString()
      txtItemsFS.Text = Reglas.Publicos.CalidadURLItemsFS.ToString()
      txtItemsFSMyL.Text = Reglas.Publicos.CalidadURLItemsFSMyL.ToString()
      txtItemsFSURB.Text = Reglas.Publicos.CalidadURLItemsFSURB.ToString()
      txtSincroFS.Text = Reglas.Publicos.CalidadURLSincroFS.ToString()
      txtPeriodosFS.Text = Reglas.Publicos.CalidadURLPeriodosFS.ToString()
      txtPeriodosFSRT.Text = Reglas.Publicos.CalidadURLPeriodosFSRT.ToString()

      txtCopiaOculta.Text = Reglas.Publicos.CalidadCopiaOcultaEnvioOC

      txtURLAuditorialogin.Text = Reglas.Publicos.CalidadURLAuditoriasLoginWeb.ToString()
      txtURLActualizaAuditoria.Text = Reglas.Publicos.CalidadURLActualizaAuditoriasLoginWeb.ToString()

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.LISTASCONTROLESTADOPENDIENTE, cmbEstadoListaPendiente, Nothing, cmbEstadoListaPendiente.LabelAsoc.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.LISTASCONTROLESTADOENPROCESO, cmbEstadoListaProceso, Nothing, cmbEstadoListaProceso.LabelAsoc.Text)
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.LISTASCONTROLESTADOTERMINADO, cmbEstadoListaTerminada, Nothing, cmbEstadoListaTerminada.LabelAsoc.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADBASEEXTERNACLIENTES, txtBaseExternaClientes, Nothing, lblBaseClientes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADPANELDECONTROLTIEMPOREFRESCO, txtCalidadPanelControlTiempoRefresco, Nothing, "Tiempo Refresco Panel Control")
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADUTILIZAMODELOASIGLISTAS, chbCalidadUtilizaModelo, Nothing, chbCalidadUtilizaModelo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADUTILIZAPAGAUTOMATICOPANELCONTROLPLANTA, chbCalidadUtilizaPagAutomaticoPanelPlanta, Nothing, chbCalidadUtilizaPagAutomaticoPanelPlanta.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADPANELDECONTROLPLANTATIEMPOPAGINADO, txtCalidadPanelControlPlantaPag, Nothing, "Tiempo Paginado Panel Control Planta")

      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLHEADERPC, txtURLHeaderPC, Nothing, lblURLheaderPC.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLHEADERURBPC, txtURLHeaderURBPC, Nothing, lblURLheaderURBPC.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLHEADERMyLPC, txtURLHeaderMyLPC, Nothing, lblURLheaderMyLPC.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLITEMSPC, txtItemsPC, Nothing, lblBaseClientes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLSINCROPC, txtSincroPC, Nothing, lblBaseClientes.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLHEADERFS, txtURLHeaderFS, Nothing, lblURLheaderFS.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLITEMSFS, txtItemsFS, Nothing, lblItemsFS.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLITEMSFSMYL, txtItemsFSMyL, Nothing, lblItemsFSMyL.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLITEMSFSURB, txtItemsFSURB, Nothing, lblItemsFSURB.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLSINCROFS, txtSincroFS, Nothing, lblSincoFS.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLPERIODOSFS, txtPeriodosFS, Nothing, lblPeriodosFS.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLPERIODOSFSRT, txtPeriodosFSRT, Nothing, lblPeriodosFSRT.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADCOPIAOCULTAOC, txtCopiaOculta, Nothing, lblCopiaOculta.Text)
      ' ActualizarParametro(Entidades.Parametro.Parametros.CALIDADCUERPOMAILENVIOOC, rtbCuerpoMail, Nothing, lblCuerpo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLAUDITORIALOGINWEB, txtURLAuditorialogin, Nothing, lblURLAuditoriaLogin.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CALIDADURLACTUALIZAAUDITORIALOGINWEB, txtURLActualizaAuditoria, Nothing, lblURLActualizaAuditoria.Text)

   End Sub

End Class