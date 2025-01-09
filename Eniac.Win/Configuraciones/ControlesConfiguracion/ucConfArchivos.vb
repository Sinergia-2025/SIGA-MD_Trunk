Public Class ucConfArchivos

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbAbrirArchivoExportado, GetType(Reglas.Publicos.AbrirArchivoExportadoModo))

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      txtTamañoMaximoImagenes.Text = Reglas.Publicos.TamañoMaximoImagenes.ToString()
      chbEmpleadoUtilizaGeolocalizacion.Checked = Reglas.Publicos.EmpleadoUtilizaGeolocalizacion
      chbPoliticasSeguridadClaves.Checked = Reglas.Publicos.PoliticasSeguridadClaves


      cmbAbrirArchivoExportado.SelectedValue = Reglas.Publicos.AbrirArchivoExportado

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      ActualizarParametro(Entidades.Parametro.Parametros.TAMAÑOMAXIMOIMAGENES, txtTamañoMaximoImagenes, Nothing, lblTamañoMaximoImagenes.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.EMPLEADOUTILIZAGEOLOCALIZACION, chbEmpleadoUtilizaGeolocalizacion, Nothing, chbEmpleadoUtilizaGeolocalizacion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.POLITICASSEGURIDADCLAVES, chbPoliticasSeguridadClaves, Nothing, chbPoliticasSeguridadClaves.Text)


      ActualizarParametro(Of Reglas.Publicos.AbrirArchivoExportadoModo)(Entidades.Parametro.Parametros.ABRIRARCHIVOEXPORTADO, cmbAbrirArchivoExportado, Nothing, lblAbrirArchivoExportado.Text)


   End Sub

End Class
