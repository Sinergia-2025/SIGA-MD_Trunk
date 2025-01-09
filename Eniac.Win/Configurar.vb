Public Class Configurar

    Public Overridable Sub SetearControl(ByVal control As System.Windows.Forms.Control, ByVal estado As StateForm)
        If TypeOf control Is Eniac.Controles.ISeteoControl Then
            Dim cnt As Eniac.Controles.ISeteoControl = DirectCast(control, Eniac.Controles.ISeteoControl)
            If Not cnt.Key Is Nothing Then
                Select Case cnt.Key.Trim()
                    Case "NombreCliente"
                        ''control.MaxLength = 30
                End Select
            End If
            If cnt.IsPK And estado = StateForm.Actualizar Then
                control.Enabled = False
            End If
            If cnt.IsRequired Then
                control.BackColor = Color.LightBlue
            End If
        End If
    End Sub

    Public Overridable Function ValidarControl(ByVal control As System.Windows.Forms.Control) As String
      If TypeOf control Is Eniac.Controles.TextBox And control.Visible <> False Then
         Dim text As Eniac.Controles.TextBox = DirectCast(control, Eniac.Controles.TextBox)
         If text.IsRequired Then
            If text.Text.Trim() = "" Then
               If Not text.LabelAsoc Is Nothing Then
                  Return "El campo " & text.LabelAsoc.Text & " es requerido." + Convert.ToChar(Keys.Enter)
               Else
                  Return "El campo " & text.Text & " es requerido." & Convert.ToChar(Keys.Enter)
               End If
            End If
         End If
      End If
        If TypeOf control Is Eniac.Controles.ComboBox Then
            Dim com As Eniac.Controles.ComboBox = DirectCast(control, Eniac.Controles.ComboBox)
            If com.IsRequired Then
                If com.Text.Trim() = "" Then
                    If Not com.LabelAsoc Is Nothing Then
                  Return "El campo " & com.LabelAsoc.Text & " es requerido." & Convert.ToChar(Keys.Enter)
                    Else
                  Return "El campo " & com.Text & " es requerido." & Convert.ToChar(Keys.Enter)
                    End If
                End If
            End If
        End If
        Return ""
    End Function

End Class
