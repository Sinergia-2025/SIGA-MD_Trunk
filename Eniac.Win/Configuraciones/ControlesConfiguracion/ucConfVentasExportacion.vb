Public Class ucConfVentasExportacion

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbExportarVentasFormato, GetType(Reglas.Publicos.ExportacionVentasEnum))

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Ventas - Exportacion
      cmbExportarVentasFormato.SelectedValue = Reglas.Publicos.Facturacion.Exportacion.ExportarVentasConFormato
      txtUbicacionArchivosPDA.Text = Reglas.Publicos.Facturacion.Exportacion.UbicacionArchivoPDA
      '-- REQ-34676.- --------------------------------------------------------------
      txtFormatoArchivoExportacion.Text = Reglas.Publicos.Facturacion.Exportacion.FormatoArchivoExportacion
      '-----------------------------------------------------------------------------
   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Ventas - Exportacion
      ActualizarParametro(Of Reglas.Publicos.ExportacionVentasEnum)(Entidades.Parametro.Parametros.EXPORTARVENTASCONFORMATO, cmbExportarVentasFormato, Nothing, grpExportacionVenta.Text)

      If Not String.IsNullOrWhiteSpace(txtUbicacionArchivosPDA.Text) AndAlso Not IO.Directory.Exists(txtUbicacionArchivosPDA.Text) Then
         IO.Directory.CreateDirectory(txtUbicacionArchivosPDA.Text)
      End If
      ActualizarParametro(Entidades.Parametro.Parametros.UBICACIONARCHIVOSPDA, txtUbicacionArchivosPDA, Nothing, lblUbicacionArchivosPDA.Text)
      '-- REQ-34676.- --------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.FORMATONOMBREARCHIVOEXPORTACION, txtFormatoArchivoExportacion, Nothing, lblFormatoArchivoExportacion.Text)
      '-----------------------------------------------------------------------------
   End Sub

   Private Sub btnFormatoNombreArchivo_Click(sender As Object, e As EventArgs) Handles btnFormatoNombreArchivo.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Using frm = New FormatoNombreArchivoExportacion()
            frm.FormatoNombreArchivo = txtFormatoArchivoExportacion.Text
            If frm.ShowDialog() = DialogResult.Cancel Then Return
            txtFormatoArchivoExportacion.Text = frm.FormatoNombreArchivo
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
End Class
