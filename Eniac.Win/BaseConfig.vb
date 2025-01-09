Option Strict On
Option Explicit On
Public Class BaseConfig
   Private _config As Entidades.ConfiguracionesAplicacion

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _config = New Reglas.ConfiguracionesAplicacion().LeerArchivo()

         chbEjecutaAlerta.Checked = _config.EjecutaAlerta
         chbEjecutaAsync.Checked = _config.EjecutaAsync
         txtMinutosAlertas.Text = _config.MinutosEjecucionAlertas.ToString()

         If IO.File.Exists("Servidor.txt") Then
            txtServidor.Text = IO.File.ReadAllText("Servidor.txt")
         End If

         If IO.File.Exists("BaseDefecto.txt") Then
            txtBaseDefecto.Text = IO.File.ReadAllText("BaseDefecto.txt")
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         _config.EjecutaAlerta = chbEjecutaAlerta.Checked
         _config.EjecutaAsync = chbEjecutaAsync.Checked

         _config.MinutosEjecucionAlertas = Integer.Parse(txtMinutosAlertas.Text)

         Dim rConfig As Reglas.ConfiguracionesAplicacion = New Reglas.ConfiguracionesAplicacion()
         rConfig.GrabaArchivo(_config)

         IO.File.WriteAllText("Servidor.txt", txtServidor.Text)
         IO.File.WriteAllText("BaseDefecto.txt", txtBaseDefecto.Text)

         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class