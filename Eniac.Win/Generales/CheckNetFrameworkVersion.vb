Public Class CheckNetFrameworkVersion

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.Escape Then
         Close()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
      TryCatched(Sub() AbrirLink(LinkLabel2, e))
   End Sub
   Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
      TryCatched(Sub() AbrirLink(LinkLabel3, e))
   End Sub
   Private Sub CopiarLinkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarLinkToolStripMenuItem.Click
      TryCatched(Sub() Clipboard.SetText(DirectCast(DirectCast(sender, ToolStripItem).Owner, ContextMenuStrip).SourceControl.Tag.ToString()))
   End Sub

   Private Sub AbrirLink(link As LinkLabel, e As LinkLabelLinkClickedEventArgs)
      If e.Button = MouseButtons.Left Then
         ' Specify that the link was visited.
         link.LinkVisited = True

         ' Navigate to a URL.
         Process.Start(link.Tag.ToString())
      End If
   End Sub

   Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
      Try
         lblTecnicoConfianza.ForeColor = If(Now.Second Mod 2 = 0, Color.Red, Color.Black)
      Catch ex As Exception

      End Try
   End Sub
End Class