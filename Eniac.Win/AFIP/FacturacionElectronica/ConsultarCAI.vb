Public Class ConsultarCAI

   Private Property UrlCAE As String

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      UrlCAE = Reglas.Publicos.AFIPURLControlarComprobante '"https://serviciosweb.afip.gob.ar/genericos/comprobantes/cae.aspx"

      MyBase.OnLoad(e)

      ' wbwAFIP.Navigate(UrlCAE)
      wvAFIP.Source = New Uri(UrlCAE)

      Me.Cursor = Cursors.WaitCursor
   End Sub

   Protected Overrides Sub OnShown(ByVal e As System.EventArgs)
      MyBase.OnShown(e)
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

End Class