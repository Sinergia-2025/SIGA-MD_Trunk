Public Class ucConfArchivosSync
   Private _titSync As Dictionary(Of String, String)

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      _titSync = DirectCast(FindForm(), BaseForm).GetColumnasVisiblesGrilla(ugArchivosSync)

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Archivos - Sync
      txtWebArchivosSyncBaseURL.Text = Reglas.Publicos.WebArchivos.SyncBaseURL
      txtWebArchivosSyncExportPath.Text = Reglas.Publicos.WebArchivos.SyncExportPath

      chbHabilitarTLS1_1.Checked = Reglas.Publicos.WebArchivos.HabilitarTLS1_1
      chbHabilitarTLS1_2.Checked = Reglas.Publicos.WebArchivos.HabilitarTLS1_2

      ugArchivosSync.DataSource = Reglas.Publicos.WebArchivos.SyncCollection
      DirectCast(FindForm(), BaseForm).AjustarColumnasGrilla(ugArchivosSync, _titSync)
      ugArchivosSync.AgregarFiltroEnLinea({"EndPointName"})

   End Sub


   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Archivos - Sync
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSYNCBASEURL, txtWebArchivosSyncBaseURL, "WEB-ARCHIVOS-SYNC", lblWebArchivosSyncBaseURL.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSSYNCEXPORTPATH, txtWebArchivosSyncExportPath, "WEB-ARCHIVOS-SYNC", lblWebArchivosSyncExportPath.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSHABILITARTLS1_1, chbHabilitarTLS1_1, "WEB-ARCHIVOS", chbHabilitarTLS1_1.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.WEBARCHIVOSHABILITARTLS1_2, chbHabilitarTLS1_2, "WEB-ARCHIVOS", chbHabilitarTLS1_2.Text)

      ugArchivosSync.UpdateData()
      If TypeOf (ugArchivosSync.DataSource) Is IEnumerable(Of Entidades.JSonEntidades.Sincronizacion.SyncConfig) Then
         For Each config In DirectCast(ugArchivosSync.DataSource, IEnumerable(Of Entidades.JSonEntidades.Sincronizacion.SyncConfig))

            ActualizarParametroClaveTexto(config.IncluidoSubidaKey.ToString(), config.IncluidoSubida.ToString(), "WEB-ARCHIVOS-SYNC", String.Format("{0} - Incluido en Subida", config.EndPointName))
            ActualizarParametroClaveTexto(config.TamanioPaginaSubidaKey.ToString(), config.TamanioPaginaSubida.ToString(), "WEB-ARCHIVOS-SYNC", String.Format("{0} - Tamaño Página de Subida", config.EndPointName))
            ActualizarParametroClaveTexto(config.IncluidoDescargaKey.ToString(), config.IncluidoDescarga.ToString(), "WEB-ARCHIVOS-SYNC", String.Format("{0} - Incluido en Descarga", config.EndPointName))
            ActualizarParametroClaveTexto(config.TamanioPaginaDescargaKey.ToString(), config.TamanioPaginaDescarga.ToString(), "WEB-ARCHIVOS-SYNC", String.Format("{0} - Tamaño Página de Descarga", config.EndPointName))

         Next
      End If

   End Sub

End Class