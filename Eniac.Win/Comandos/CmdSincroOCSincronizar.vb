Public Class CmdSincroOCSincronizar
   Implements IComandoMenu
   Implements IConParametros

   Private Const Tag As String = "CmdSincroOCSincronizar.Ejecutar"

   Private _reImportar As Boolean = False
   Private _reEnviar As Boolean = False
   Private _descargarTodo As Boolean = False
   Private _enviarWebProveedores As Boolean = True
   Private _exportarProveedores As Boolean = True
   Private _enviarWebOC As Boolean = True
   Private _exportarOC As Boolean = True

   Private WithEvents rSincronizarOC As Reglas.SincronizarOrdenesCompra

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Instancia regla de SincronizarOrdenesCompra", Tag), TraceEventType.Verbose)
      rSincronizarOC = New Reglas.SincronizarOrdenesCompra(idFuncion)

      My.Application.Log.WriteEntry(String.Format("{0} - Antes de ejecutar Sincronizar()", Tag), TraceEventType.Verbose)

      '### Descarga
      rSincronizarOC.Sincronizar(_reImportar, _reEnviar, _enviarWebProveedores, _exportarProveedores, _enviarWebOC, _exportarOC, _descargarTodo)

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
      stb.AppendFormatLine("ReImportar - Indica si se van a reimportar las OC - False")
      stb.AppendFormatLine("ReEnviar - Indica si se van a reenviar las OC - False")
      stb.AppendFormatLine("DescargarTodo - Indica si descarga Todo nuevamente - False")

      stb.AppendFormatLine("EnviarWebProv - . - True")
      stb.AppendFormatLine("ExportarProv - . - True")

      stb.AppendFormatLine("EnviarWebOC - . - True")
      stb.AppendFormatLine("ExportarOC - . - True")
      Return stb.ToString()
   End Function

   Private Sub SetParametrosDeSincronizacion(parametros As String)

      For Each p As String In parametros.Split(";"c)
         Dim keyValue As String() = p.Split("="c)
         Select Case keyValue(0)
            Case ParametrosPermitidos.ReImportar.ToString()
               _reImportar = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
            Case ParametrosPermitidos.ReEnviar.ToString()
               _reEnviar = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
            Case ParametrosPermitidos.DescargarTodo.ToString()
               _descargarTodo = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
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
      ReImportar
      DescargarTodo
      EnviarWebProv
      ExportarProv
      EnviarWebOC
      ExportarOC
   End Enum

End Class
