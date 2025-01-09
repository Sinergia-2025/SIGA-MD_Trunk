Public Class CmdSincroOCEnviarWeb
   Implements IConParametros
   Implements IComandoMenu

   Private Const Tag As String = "CmdSincroOCEnviarWeb.Ejecutar"

#Region "Campos"

   Private _reenviar As Boolean = False
   Private _enviarWebProveedores As Boolean
   Private _exportarProveedores As Boolean
   Private _enviarWebOC As Boolean
   Private _exportarOC As Boolean

#End Region

   Private WithEvents rSincronizarOC As Reglas.SincronizarOrdenesCompra

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Instancia regla de SincronizarOrdenesCompra", Tag), TraceEventType.Verbose)
      rSincronizarOC = New Reglas.SincronizarOrdenesCompra(idFuncion)

      '# Registro de la parámetros que se van a utilizar para el envio de información
      My.Application.Log.WriteEntry(String.Format("{0} - Antes de ejecutar EnviarWeb()", Tag), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - Reenviar: {1}", Tag, _reenviar.ToString()), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - Enviar Web Proveedores: {1}", Tag, _enviarWebProveedores.ToString()), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - Exportar Proveedores: {1}", Tag, _exportarProveedores.ToString()), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - Enviar Web OC: {1}", Tag, _enviarWebOC.ToString()), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - Exportar OC: {1}", Tag, _exportarOC.ToString()), TraceEventType.Verbose)

      '### Subida
      rSincronizarOC.EnviarWeb(_reenviar, _enviarWebProveedores, _exportarProveedores, _enviarWebOC, _exportarOC)

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
      Return "Pendiente documentar"
   End Function

   Private Sub SetParametrosDeSincronizacion(parametros As String)

      For Each p As String In parametros.Split(";"c)
         Dim keyValue As String() = p.Split("="c)
         Select Case keyValue(0)
            Case ParametrosPermitidos.ReEnviar.ToString()
               _reenviar = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
            Case ParametrosPermitidos.EnviarWebProv.ToString()
               _enviarWebProveedores = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
            Case ParametrosPermitidos.ExportarProv.ToString()
               _exportarProveedores = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
            Case ParametrosPermitidos.EnviarWebOC.ToString()
               _enviarWebOC = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
            Case ParametrosPermitidos.ExportarOC.ToString()
               _exportarOC = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
         End Select
      Next

   End Sub

   '# Parámetros permitidos
   Private Enum ParametrosPermitidos
      ReEnviar
      EnviarWebProv
      ExportarProv
      EnviarWebOC
      ExportarOC
   End Enum

End Class
