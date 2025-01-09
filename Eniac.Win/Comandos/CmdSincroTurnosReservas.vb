Option Strict On
Option Explicit On

Public Class CmdSincroTurnosReservas
   Implements Eniac.Win.IComandoMenu

   Private Const Tag As String = "CmdSincroTurnosReservas.Ejecutar"
   '-- REQ-31464.- -- 
   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Aplicando Configuración Regional.", Tag), TraceEventType.Information)
      Reglas.Publicos.VerificaConfiguracionRegional()
      '-- Comenzando el Proceso de TurnosReservas.- --
      My.Application.Log.WriteEntry(String.Format("{0} - Comenzando Subida de Información desde Tarea Programada.", Tag), TraceEventType.Information)


      '-- Define variable de Calendarios y Obtiene Datos.- -- 
      Dim oPublicaWeb As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.SI
      Dim oCalendarios = New Reglas.Calendarios().GetTodos(True, oPublicaWeb)
      '-- Define variable de Calendarios.- -- 
      Dim oTurnosReservas = New Reglas.TurnosCalendarios
      '-- Define Variable de Fechas.- --
      Dim oFechaProc As Date = Date.Now()
      Try
         If oCalendarios.Count = 0 Then
            My.Application.Log.WriteEntry(String.Format("No se Localizaron Calendarios Activos.", Tag), TraceEventType.Information)
            Exit Try
         End If
         '-- Comienza el Proceso de Sincronizacion de Turnos-Reservas.- --
         For Each oCalen As Entidades.Calendario In oCalendarios
            oTurnosReservas.GetTodos(oCalen.IdCalendario,
                                oFechaProc.AddDays(oCalen.DiasDesde),
                                oFechaProc.AddDays(oCalen.DiasHasta))
         Next
      Catch ex As Exception
         Dim err As StringBuilder = New StringBuilder
         With err
            .AppendFormatLine("*** Se encontraron los siguientes ERRORES en el Proceso de Turnos-Reservas ***")
            .AppendFormatLine("<br>")
            .AppendFormatLine("{0}", ex.Message)
         End With
      End Try
      My.Application.Log.WriteEntry(String.Format("{0} - Fin", Tag), TraceEventType.Information)

   End Sub

End Class
