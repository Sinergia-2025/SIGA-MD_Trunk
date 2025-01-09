Public Class CmdSincroPanelesSincronizar
   Implements Eniac.Win.IComandoMenu
   Implements IConParametros

   Private Const Tag As String = "CmdSincroPanelesSincronizar.Ejecutar"

   Private _reEnviar As Boolean = False
   Private _enviarWebPanelControl As Boolean = True
   Private _exportarPanelControl As Boolean = True
   Private _enviarWebFechasSalida As Boolean = True
   Private _exportarFechasSalida As Boolean = True

   Private WithEvents rSincronizarOC As Reglas.SincronizarPanelDeControl

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Instancia regla de SincronizarPanelDeControl", Tag), TraceEventType.Verbose)
      rSincronizarOC = New Reglas.SincronizarPanelDeControl(idFuncion)

      My.Application.Log.WriteEntry(String.Format("{0} - Antes de ejecutar Sincronizar()", Tag), TraceEventType.Verbose)

      '### Descarga
      rSincronizarOC.Sincronizar(_reEnviar, _enviarWebPanelControl, _exportarPanelControl, _enviarWebFechasSalida, _exportarFechasSalida)

      My.Application.Log.WriteEntry(String.Format("{0} - Finaliza", Tag), TraceEventType.Information)

   End Sub

   Public Sub rSincronizarOC_Avance(sender As Object, e As Reglas.AvanceSincronizarPanelDeControlEventArgs) Handles rSincronizarOC.Avance
      If e IsNot Nothing Then
         My.Application.Log.WriteEntry(String.Format("{0} - {1}", Tag, e.Texto), TraceEventType.Verbose)
      End If
   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      '# Si el comando tiene parámetros, realizo un split para obtener los valores y setearlos a las variables para luego utilizarlas en la sincronización.
      If Not String.IsNullOrEmpty(parametros) Then
         Me.SetParametrosDeSincronizacion(parametros)
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

   Private Sub SetParametrosDeSincronizacion(parametros As String)

      For Each p As String In parametros.Split(";"c)
         Dim keyValue As String() = p.Split("="c)
         Select Case keyValue(0)
            Case ParametrosPermitidos.ReEnviar.ToString()
               _reEnviar = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
            Case ParametrosPermitidos.EnviarWebPC.ToString()
               _enviarWebPanelControl = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
            Case ParametrosPermitidos.ExportarPC.ToString()
               _exportarPanelControl = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
            Case ParametrosPermitidos.EnviarWebFS.ToString()
               _enviarWebFechasSalida = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
            Case ParametrosPermitidos.ExportarFS.ToString()
               _exportarFechasSalida = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
         End Select
      Next

   End Sub

   '# Parámetros permitidos
   Private Enum ParametrosPermitidos
      ReEnviar
      EnviarWebPC
      ExportarPC
      EnviarWebFS
      ExportarFS
   End Enum

End Class
