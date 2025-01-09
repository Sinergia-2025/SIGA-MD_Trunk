#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports System.Runtime.CompilerServices
#End Region
Namespace Extensiones
   Public Module FormExtensions
      <Extension, DebuggerStepThrough>
      Public Function ShowError(owner As Form, ex As Exception) As DialogResult
         If TypeOf (ex) Is Reglas.ServiciosRest.ErrorResponseException Then
            Return owner.ShowError(DirectCast(ex, Reglas.ServiciosRest.ErrorResponseException))
         ElseIf TypeOf (ex) Is Reflection.TargetInvocationException Then
            Return owner.ShowError(ex, recursivo:=True)
         ElseIf TypeOf (ex) Is Microsoft.Reporting.WinForms.LocalProcessingException Then
            Return owner.ShowError(ex, recursivo:=True)
         ElseIf TypeOf (ex) Is LibreriaFiscalV2.ExcepcionFiscal Then
            Return owner.ShowError(ex, recursivo:=True)
         End If
         Return owner.ShowError(ex, recursivo:=False)
      End Function
      <Extension, DebuggerStepThrough>
      Public Function ShowError(owner As Form, ex As Reglas.ServiciosRest.ErrorResponseException) As DialogResult
         If ex.ErrorResponse IsNot Nothing AndAlso ex.ErrorResponse.MensajeTecnico IsNot Nothing AndAlso ex.ErrorResponse.MensajeTecnico.Count <> 0 Then
            Dim stb As StringBuilder = New StringBuilder()
            stb.AppendFormatLine(ex.Message)
            stb.AppendLine().AppendLine("MENSAJE TECNICO").AppendLine("---------------")
            For Each msg As String In ex.ErrorResponse.MensajeTecnico
               stb.AppendLine(msg)
            Next
            Return owner.ShowMessage(stb.ToString())
         Else
            Return owner.ShowError(DirectCast(ex, Exception), recursivo:=False)
         End If
      End Function
      <Extension, DebuggerStepThrough>
      Public Function ShowError(owner As Form, ex As Exception, recursivo As Boolean) As DialogResult
         Dim st As System.Text.StringBuilder = New System.Text.StringBuilder()
         If recursivo Then
            owner.ArmaErrorRecursivo(ex, st)
         Else
            st.AppendLine(ex.Message)
         End If
         Return owner.ShowMessage(st.ToString())
      End Function

      <Extension, DebuggerStepThrough>
      Public Function ShowMessage(owner As Form, mensaje As String) As DialogResult

         If owner Is Nothing OrElse owner.IsDisposed Then
            Return MessageBox.Show(mensaje, owner.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            Return MessageBox.Show(owner, mensaje, owner.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Function
      '' ''<Extension, DebuggerStepThrough>
      '' ''Public Function ShowMessage(owner As Form, mensaje As String, frm As Form) As DialogResult
      '' ''   Return MessageBox.Show(owner, mensaje, frm.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '' ''End Function
      <Extension, DebuggerStepThrough>
      Public Function ShowPregunta(owner As Form, mensaje As String, ParamArray args As Object()) As DialogResult
         Return ShowPregunta(owner, String.Format(mensaje, args))
      End Function
      '' ''<Extension, DebuggerStepThrough>
      '' ''Public Function ShowMessage(owner As Form, mensaje As String, frm As Form) As DialogResult
      '' ''   Return MessageBox.Show(owner, mensaje, frm.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '' ''End Function
      <Extension, DebuggerStepThrough>
      Public Function ShowPregunta(owner As Form, mensaje As String, defaultButton As MessageBoxDefaultButton, ParamArray args As Object()) As DialogResult
         Return ShowPregunta(owner, String.Format(mensaje, args), defaultButton)
      End Function
      '' ''<Extension, DebuggerStepThrough>
      '' ''Public Function ShowMessage(owner As Form, mensaje As String, frm As Form) As DialogResult
      '' ''   Return MessageBox.Show(owner, mensaje, frm.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '' ''End Function
      <Extension, DebuggerStepThrough>
      Public Function ShowPregunta(owner As Form, mensaje As String) As DialogResult
         Return System.Windows.Forms.MessageBox.Show(owner, mensaje, owner.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
      End Function
      <Extension, DebuggerStepThrough>
      Public Function ShowPregunta(owner As Form, mensaje As String, defaultButton As MessageBoxDefaultButton) As DialogResult
         Return System.Windows.Forms.MessageBox.Show(owner, mensaje.Truncar(1000), owner.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, defaultButton)
      End Function

      <Extension, DebuggerStepThrough>
      Public Sub ArmaErrorRecursivo(owner As Form, ex As Exception, stb As System.Text.StringBuilder)
         If ex IsNot Nothing Then
            stb.AppendLine(ex.Message)
            If ex.InnerException IsNot Nothing Then
               stb.AppendLine()
               owner.ArmaErrorRecursivo(ex.InnerException, stb)
            End If
         End If
      End Sub

      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As Form, controles As Control, accion As Action)
         owner.TryCatched({controles}, {}, accion)
      End Sub
      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As Form, controles As ToolStripItem, accion As Action)
         owner.TryCatched({}, {controles}, accion)
      End Sub
      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As Form, controles As IEnumerable(Of Control), accion As Action)
         owner.TryCatched(controles, {}, accion)
      End Sub
      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As Form, controles As IEnumerable(Of ToolStripItem), accion As Action)
         owner.TryCatched({}, controles, accion)
      End Sub
      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As Form, controles As IEnumerable(Of Control), toolStrips As IEnumerable(Of ToolStripItem), accion As Action)

         Dim prevCursor = owner.Cursor
         Dim prevControlEnabled = New Dictionary(Of Control, Boolean)()
         For Each c In controles.Where(Function(x) x IsNot Nothing)
            prevControlEnabled.Add(c, c.Enabled)
            c.Enabled = False
         Next

         Dim prevToolStripEnabled = New Dictionary(Of ToolStripItem, Boolean)()
         For Each c In toolStrips.Where(Function(x) x IsNot Nothing)
            prevToolStripEnabled.Add(c, c.Enabled)
            c.Enabled = False
         Next

         Try
            owner.Cursor = Cursors.WaitCursor
            owner.TryCatched(accion)
         Finally
            For Each c In controles.Where(Function(x) x IsNot Nothing)
               c.Enabled = prevControlEnabled(c)
            Next
            For Each c In toolStrips.Where(Function(x) x IsNot Nothing)
               c.Enabled = prevToolStripEnabled(c)
            Next
            owner.Cursor = prevCursor
         End Try
      End Sub
      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As UserControl, accion As Action)
         owner.FindForm().TryCatched(accion)
      End Sub
      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As UserControl, accion As Action, onErrorAction As Action(Of Form, Exception))
         owner.FindForm().TryCatched(accion, onErrorAction, onFinallyAction:=Nothing)
      End Sub
      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As UserControl, accion As Action, onFinallyAction As Action(Of Form))
         owner.FindForm().TryCatched(accion, Sub(o, ex) o.ShowError(ex), onFinallyAction)
      End Sub

      <Extension, DebuggerStepThrough>
      Public Sub PresionarTab(owner As UserControl, e As KeyEventArgs)
         Dim frm = owner.FindForm()
         If TypeOf (frm) Is BaseForm Then
            DirectCast(frm, BaseForm).PresionarTab(e)
         End If
      End Sub

      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As Form, accion As Action)
         TryCatched(owner, accion, accionAdicionalError:=Nothing)
      End Sub

      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As Form, accion As Action, accionAdicionalError As Action)
         TryCatched(owner, accion,
                    Sub(o, ex)
                       o.ShowError(ex)
                       If accionAdicionalError IsNot Nothing Then accionAdicionalError()
                    End Sub)
      End Sub
      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As Form, accion As Action, onErrorAction As Action(Of Form, Exception))
         TryCatched(owner, accion, onErrorAction, onFinallyAction:=Nothing)
      End Sub
      <Extension, DebuggerStepThrough>
      Public Sub TryCatched(owner As Form, accion As Action, onFinallyAction As Action(Of Form))
         TryCatched(owner, accion, Sub(o, ex) o.ShowError(ex), onFinallyAction)
      End Sub
      <Extension> ', DebuggerStepThrough>
      Public Sub TryCatched(owner As Form, accion As Action, onErrorAction As Action(Of Form, Exception), onFinallyAction As Action(Of Form))
         Dim prevCursor = If(owner IsNot Nothing, owner.Cursor, Cursors.Default)
         Try
            If owner IsNot Nothing Then owner.Cursor = Cursors.WaitCursor
            accion()
         Catch ex As Exception
            onErrorAction(owner, ex)
         Finally
            If onFinallyAction IsNot Nothing Then onFinallyAction(owner)
            If owner IsNot Nothing Then owner.Cursor = prevCursor
         End Try
      End Sub

      <Extension, DebuggerStepThrough>
      Public Sub Close(form As Form, result As DialogResult)
         form.DialogResult = result
         form.Close()
      End Sub


      <Extension> ', DebuggerStepThrough>
      Public Sub FormEnabled(value As Boolean, listaControles As IEnumerable(Of Control), tsp As ToolStrip, tsbIgnorar As IEnumerable(Of ToolStripButton))
         'listaControles.ToList().ForEach(Function(c) c.Enabled = value)
         For Each c In listaControles
            c.Enabled = value
         Next
         tsp.Items.OfType(Of ToolStripButton).ToList().ForEach(
         Sub(tsb)
            If Not tsbIgnorar.Contains(tsb) Then
               If value Then
                  tsb.Enabled = tsb.TagAs(Of Boolean)()
                  tsb.Tag = Nothing
               Else
                  tsb.Tag = tsb.Enabled
                  tsb.Enabled = value
               End If
            End If
         End Sub)
      End Sub

      <Extension>
      Public Function ValidaConErrorBuilder(owner As Form, validador As Action(Of Entidades.ErrorBuilder)) As Boolean
         Return ValidaConErrorBuilder(owner, validador,
                                      onErrorAction:=
                                      Function(frm, err)
                                         frm.ShowMessage(err.ErrorToString())
                                         err.PerformFocusOnError()
                                         Return False
                                      End Function,
                                      onWarningAction:=
                                      Function(frm, err)
                                         If frm.ShowPregunta(err.WarningToString()) = DialogResult.No Then
                                            Return False
                                         End If
                                         Return True
                                      End Function)
      End Function

      <Extension>
      Public Function ValidaConErrorBuilder(owner As Form, validador As Action(Of Entidades.ErrorBuilder),
                                            onErrorAction As Func(Of Form, Entidades.ErrorBuilder, Boolean),
                                            onWarningAction As Func(Of Form, Entidades.ErrorBuilder, Boolean)) As Boolean
         Using err = New Entidades.ErrorBuilder()
            validador(err)
            If err.AnyError AndAlso onErrorAction IsNot Nothing Then
               Return onErrorAction(owner, err)
            End If
            If err.AnyWarning AndAlso onWarningAction IsNot Nothing Then
               Return onWarningAction(owner, err)
            End If
            Return True
         End Using
      End Function

   End Module
End Namespace