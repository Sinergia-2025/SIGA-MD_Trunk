Public Class ucConfCRMGenerales
   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'CRM
      chbPermiteAbrirMultiplesNovedadesNuevas.Checked = Reglas.Publicos.PermiteAbrirMultiplesNovedadesNuevas
      chbPermiteAbrirMultiplesNovedadesEditar.Checked = Reglas.Publicos.PermiteAbrirMultiplesNovedadesEditar
      txtDiasAVencerAlertas.Text = Reglas.Publicos.CRMNovedadesDiasAVencerAlarma.ToString()
      chbSoloMuestraUsuariosActivos.Checked = Reglas.Publicos.CRMSoloMuestraUsuariosActivos

      chbPermiteEnvioMailsDesdeNovedad.Checked = Reglas.Publicos.CRMPermiteEnvioMailsDesdeNovedad
      chbMuestraSolapaMasInfo.Checked = Reglas.Publicos.CRMMuestraSolapaMasInfo
      chbReportaCategoriaNovedades.Checked = Reglas.Publicos.CRMMuestraReportaCategoriasNovedades
      chbCRMImporteConIVA.Checked = Reglas.Publicos.CRMImporteConIVA

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.PERMITEABRIRMULTIPLESNOVEDADESNUEVAS, chbPermiteAbrirMultiplesNovedadesNuevas, Nothing, chbPermiteAbrirMultiplesNovedadesNuevas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PERMITEABRIRMULTIPLESNOVEDADESEDITAR, chbPermiteAbrirMultiplesNovedadesEditar, Nothing, chbPermiteAbrirMultiplesNovedadesEditar.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CRMNOVEDADESDIASAVENCERALARMA, txtDiasAVencerAlertas, Nothing, txtDiasAVencerAlertas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CRMSOLOMUESTRAUSUARIOSACTIVOS, chbSoloMuestraUsuariosActivos, Nothing, chbSoloMuestraUsuariosActivos.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CRMPERMITEENVIOMAILS, chbPermiteEnvioMailsDesdeNovedad, Nothing, chbPermiteEnvioMailsDesdeNovedad.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CRMMUESTRASOLAPAMASINFO, chbMuestraSolapaMasInfo, Nothing, chbMuestraSolapaMasInfo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CRMMUESTRAREPORTACATEGORIASNOVEDADES, chbReportaCategoriaNovedades, Nothing, chbReportaCategoriaNovedades.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CRMIMPORTECONIVA, chbCRMImporteConIVA, Nothing, chbCRMImporteConIVA.Text)

   End Sub

End Class