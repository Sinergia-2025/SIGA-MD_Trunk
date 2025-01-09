Public Class ConsultarTablasAFIP

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)
      If Not New Reglas.Impresoras().AlgunaUsaBonos() Then
         'If Not Publicos.UtilizaBonosFiscalesElectronicos Then
         Me.utsTablas.Tabs.Remove(Me.utsTablas.Tabs("UnidadesDeMedidas"))
      End If
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub utsTablas_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles utsTablas.SelectedTabChanged
      Try
         If Not Publicos.HayInternet() Then
            MessageBox.Show("No tiene internet para realizar esta acción.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
         End If

         Dim reg As Reglas.AFIPFE = New Reglas.AFIPFE()
         Select Case e.Tab.Key
            Case "TiposTributos"
               Me.ugdDatos.DataSource = reg.GetTiposTributosV1()
            Case "TiposOpcionales"
               Me.ugdDatos.DataSource = reg.GetTiposOpcionalesV1()
            Case "TiposMonedas"
               Me.ugdDatos.DataSource = reg.GetTiposMonedasV1()
            Case "TiposAlicuotas"
               Me.ugdDatos.DataSource = reg.GetTiposAlicuotasV1()
            Case "TiposDocumentos"
               Me.ugdDatos.DataSource = reg.GetTiposDocumentosV1()
            Case "TiposConceptos"
               Me.ugdDatos.DataSource = reg.GetTiposConceptosV1()
            Case "TiposComprobantes"
               Me.ugdDatos.DataSource = reg.GetTiposComprobantesV1()
            Case "PuntosVentas"
               Me.ugdDatos.DataSource = reg.GetPuntosDeVentaV1()
            Case "UnidadesDeMedidas"
               If New Reglas.Impresoras().AlgunaUsaBonos() Then
                  'If Publicos.UtilizaBonosFiscalesElectronicos Then
                  Dim reg1 As Reglas.AFIPBFE = New Reglas.AFIPBFE()
                  Me.ugdDatos.DataSource = reg1.GetUnidadesDeMedidas()
               End If
         End Select
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

End Class