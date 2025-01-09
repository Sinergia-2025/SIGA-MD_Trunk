Public Class CmdSincroOCDescargarResp
   Implements IComandoMenu
   Implements IConParametros

   Private Const Tag As String = "CmdSincroOCDescargarResp.Ejecutar"
   Private _descargarTodo As Boolean

   Private WithEvents rSincronizarOC As Reglas.SincronizarOrdenesCompra

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Instancia regla de SincronizarOrdenesCompra", Tag), TraceEventType.Verbose)
      rSincronizarOC = New Reglas.SincronizarOrdenesCompra(idFuncion)

      My.Application.Log.WriteEntry(String.Format("{0} - Antes de ejecutar DescargarRespuestas()", Tag), TraceEventType.Verbose)

      '### Descarga (Aún no está terminada por eso queda comentada)
      'rSincronizarOC.DescargarRespuestas(_descargarTodo)

      My.Application.Log.WriteEntry(String.Format("{0} - Finaliza", Tag), TraceEventType.Information)

   End Sub

   Public Sub rSincronizarOC_Avance(sender As Object, e As Reglas.AvanceSincronizarOrdenesCompraEventArgs) Handles rSincronizarOC.Avance
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
      Dim stb = New StringBuilder("Lista separada por ';' de pares clave valor separados por '='").AppendLine().AppendLine()
      stb.AppendFormatLine("DescargarTodo - Indica si desea descargar todo o solo novedades - False (no funciona)")
      Return stb.ToString()
   End Function

   Private Sub SetParametrosDeSincronizacion(parametros As String)

      For Each p As String In parametros.Split(";"c)
         Dim keyValue As String() = p.Split("="c)
         Select Case keyValue(0)
            Case ParametrosPermitidos.DescargarTodo.ToString()
               _descargarTodo = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
         End Select
      Next

   End Sub

   '# Parámetros permitidos
   Private Enum ParametrosPermitidos
      DescargarTodo
   End Enum

End Class
