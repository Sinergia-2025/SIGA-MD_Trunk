Public Class TesteaServidoresAFIP
   Private Sub tsbTestea_Click(sender As Object, e As EventArgs) Handles tsbTestea.Click
      TryCatched(
      Sub()
         If Not Publicos.HayInternet() Then
            ShowMessage("No tiene internet para realizar esta acción.")
            Exit Sub
         End If

         Dim reg = New Reglas.AFIPFE()
         Dim estados = New List(Of String)(reg.TestearServidoresV1().Split("/"c))
         Dim estadosB = New List(Of String)
         If New Reglas.Impresoras().AlgunaUsaBonos() Then
            'If Reglas.Publicos.UtilizaBonosFiscalesElectronicos Then
            Dim reg1 = New Reglas.AFIPBFE()
            estadosB.AddRange(reg1.TestearServidoresV1().Split("/"c))
         Else
            estadosB.AddRange({"OK", "OK", "OK"})
         End If

         'Servidor Autorización
         If estados(0) = "OK" And estadosB(0) = "OK" Then
            pcbAutorizacion.Image = My.Resources.server_ok_48
         Else
            pcbAutorizacion.Image = My.Resources.server_cancel_48
         End If
         'Servidor Aplicación
         If estados(1) = "OK" And estadosB(1) = "OK" Then
            pcbAplicaciones.Image = My.Resources.server_ok_48
         Else
            pcbAplicaciones.Image = My.Resources.server_cancel_48
         End If
         'Servidor Base de Datos
         If estados(2) = "OK" And estadosB(2) = "OK" Then
            pcbBaseDeDatos.Image = My.Resources.server_ok_48
         Else
            pcbBaseDeDatos.Image = My.Resources.server_cancel_48
         End If
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
   Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
      TryCatched(
      Sub()
         If Not Publicos.HayInternet() Then
            ShowMessage("No tiene internet para realizar esta acción.")
            Exit Sub
         End If

         Dim reg = New Reglas.AFIPPN3()
         Dim resp = reg.GetDatosContribuyento("33711345499")

         ShowMessage(resp)
      End Sub)
   End Sub
End Class