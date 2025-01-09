Option Explicit On
Option Strict On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class Textos

   Public asunto As String
   Public cuerpo As String
   Public modalidad As String
   Private _funcion As String
   Private _Modalidad As String

   Private _publicos As Publicos

   Public Sub New(ByVal funcion As String, ByVal Modalidad As String)

      InitializeComponent()
      Me._funcion = funcion
      Me._Modalidad = Modalidad

   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()
         Me.txtModalidad.Enabled = False ' No permitir manipular la modalidad.

         Me.Cursor = Cursors.WaitCursor

         Dim dt As DataTable


         dt = New Reglas.Textos().GetTextos(_funcion, _Modalidad)

         If dt.Rows.Count = 0 Then
            Dim texto As Reglas.Textos = New Reglas.Textos()
            Dim IdTexto As Integer = New Reglas.Textos().GetIdMaximo()

            texto.InsertaTextos(IdTexto + 1, _funcion, "", "", _Modalidad)

            dt = New Reglas.Textos().GetTextos(_funcion, _Modalidad)
         End If

         For Each dr As DataRow In dt.Rows
            asunto = dr("Asunto").ToString()
            Me.txtAsunto.Text = asunto
            cuerpo = dr("Cuerpo").ToString()
            Me.rtbCuerpoMail.BodyHtml = cuerpo
            modalidad = dr("Modalidad").ToString()
            Me.txtModalidad.Text = modalidad
         Next

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub Textos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F4
            Me.tsbGrabar.PerformClick()
         Case Keys.F5
            Me.tsbRefrescar.PerformClick()
      End Select
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.txtAsunto.Text = ""
         Me.rtbCuerpoMail.BodyHtml = ""
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         Dim oTextos As Reglas.Textos = New Reglas.Textos()
         oTextos.GrabarTextos(Me._funcion, Me.txtAsunto.Text, Me.rtbCuerpoMail.BodyHtml, _Modalidad)

         asunto = Me.txtAsunto.Text
         cuerpo = Me.rtbCuerpoMail.BodyHtml

         MessageBox.Show("Se modifico el texto correspondiente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Try
         Me.Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub


#End Region

   Private Sub btnExpandirHtml_Click(sender As Object, e As EventArgs) Handles btnExpandirHtml.Click
      Using frm As EditorHtml = New EditorHtml(rtbCuerpoMail.BodyHtml)
         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            rtbCuerpoMail.BodyHtml = frm.BodyHTML
         End If
      End Using
   End Sub
End Class