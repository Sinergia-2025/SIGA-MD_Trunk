Public Class ucConfAppMovilesFTP

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      '# FTP
      txtFTPServidorMovil.Text = Reglas.Publicos.FTPServidorMovil
      txtFTPUsuarioMovil.Text = Reglas.Publicos.FTPUsuarioMovil
      txtFTPPasswordMovil.Text = Reglas.Publicos.FTPPasswordMovil
      chbFTPConexionPasivaMovil.Checked = Reglas.Publicos.FTPConexionPasivaMovil
      txtFTPCarpetaRemotaMovil.Text = Reglas.Publicos.FTPCarpetaRemotaMovil

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      '# FTP
      ActualizarParametro(Entidades.Parametro.Parametros.FTPSERVIDORMOVIL, txtFTPServidorMovil, Nothing, txtFTPServidorMovil.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FTPUSUARIOMOVIL, txtFTPUsuarioMovil, Nothing, txtFTPUsuarioMovil.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FTPPASSWORDMOVIL, txtFTPPasswordMovil, Nothing, txtFTPPasswordMovil.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FTPCONEXIONPASIVAMOVIL, chbFTPConexionPasivaMovil, Nothing, chbFTPConexionPasivaMovil.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.FTPCARPETAREMOTAMOVIL, txtFTPCarpetaRemotaMovil, Nothing, txtFTPCarpetaRemotaMovil.Text)

   End Sub

End Class