Public Class CmdSincroOCImportarBejerman
   Implements Eniac.Win.IComandoMenu
   Implements IConParametros

   Private Const Tag As String = "CmdSincroOCImportarBejerman.Ejecutar"

#Region "Campos"

   Private _reImportar As Boolean = False

#End Region

   Private WithEvents rSincronizarOC As Reglas.SincronizarOrdenesCompra

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Instancia regla de SincronizarOrdenesCompra", Tag), TraceEventType.Verbose)
      rSincronizarOC = New Reglas.SincronizarOrdenesCompra(idFuncion)

      '# Registro de la parámetros que se van a utilizar para el envio de información
      My.Application.Log.WriteEntry(String.Format("{0} - Antes de ejecutar ImportarDesdeBejerman()", Tag), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - ReImportar: {1}", Tag, _reImportar.ToString()), TraceEventType.Verbose)

      '### Importación
      rSincronizarOC.ImportarDesdeBejerman(_reImportar)

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
            Case ParametrosPermitidos.ReImportar.ToString()
               _reImportar = If(keyValue.Length > 0, CBool(keyValue(1).Trim()), False)
         End Select
      Next

   End Sub

   '# Parámetros Permitidos
   Private Enum ParametrosPermitidos
      ReImportar
   End Enum

End Class
