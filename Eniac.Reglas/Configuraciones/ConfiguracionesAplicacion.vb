Option Strict On
Option Explicit On
Imports System.Text
Public Class ConfiguracionesAplicacion
   Private _nombreArchivo As String
   Public Const EjecutaAlerta As String = "ejecutaAlerta"
   Public Const EjecutaAsync As String = "ejecutaAsync"
   Public Const MinutosEjecucionAlertas As String = "minutosEjecucionAlertas"

   Public Sub New()
      _nombreArchivo = "eniac.config.txt"
   End Sub

   Public Function LeerArchivo() As Entidades.ConfiguracionesAplicacion
      Dim result As Entidades.ConfiguracionesAplicacion = New Entidades.ConfiguracionesAplicacion()

      Dim tiempoVal As Int32 = 60

      If IO.File.Exists(_nombreArchivo) Then
         Dim archivo As String() = IO.File.ReadAllLines(_nombreArchivo)
         For Each linea As String In archivo
            Dim valores As String() = linea.Split(":"c)
            If valores.Length > 1 Then
               If valores(0).Trim().ToLower() = EjecutaAlerta.ToLower() Then
                  result.EjecutaAlerta = valores(1).Trim().ToLower() = Boolean.TrueString.ToLower()
               ElseIf valores(0).Trim().ToLower() = EjecutaAsync.ToLower() Then
                  result.EjecutaAsync = valores(1).Trim().ToLower() = Boolean.TrueString.ToLower()
               ElseIf valores(0).Trim().ToLower() = MinutosEjecucionAlertas.ToLower() Then
                  Int32.TryParse(valores(1).Trim().ToLower(), tiempoVal)
                  result.MinutosEjecucionAlertas = tiempoVal
               End If
            End If
         Next
      End If

      Return result
   End Function

   Public Sub GrabaArchivo(config As Entidades.ConfiguracionesAplicacion)
      Dim stb As StringBuilder = New StringBuilder()
      stb.AppendLine(String.Format("{0}:{1}", EjecutaAlerta, config.EjecutaAlerta.ToString()))
      stb.AppendLine(String.Format("{0}:{1}", EjecutaAsync, config.EjecutaAsync.ToString()))
      stb.AppendLine(String.Format("{0}:{1}", MinutosEjecucionAlertas, config.MinutosEjecucionAlertas.ToString()))
      IO.File.WriteAllText(_nombreArchivo, stb.ToString())
   End Sub

End Class