Option Strict On
Option Explicit On

Imports System.IO

Public Class EditorHtml

    Private workingDirectory As String = String.Empty
    Public Property BodyHTML() As String

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(bodyHtml As String)
        Me.New()
        Me.BodyHTML = bodyHtml
    End Sub
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        txtEditorHtml.BodyHtml = BodyHTML
    End Sub

    Private Sub bBackground_Click(sender As Object, e As EventArgs) Handles bBackground.Click
        Try
            Using dialog As ColorDialog = New ColorDialog()
                If dialog.ShowDialog() = DialogResult.OK Then
                    txtEditorHtml.BodyBackColor = dialog.Color
                End If
            End Using
            txtEditorHtml.Focus()
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Private Sub bForeground_Click(sender As Object, e As EventArgs) Handles bForeground.Click
        Try
            Using dialog As ColorDialog = New ColorDialog()
                If dialog.ShowDialog() = DialogResult.OK Then
                    txtEditorHtml.BodyForeColor = dialog.Color
                End If
            End Using
            txtEditorHtml.Focus()
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Private Sub bImage_Click(sender As Object, e As EventArgs) Handles bImage.Click
        Try
            '' set initial value states
            Dim fileName As String = String.Empty
            Dim filePath As String = String.Empty

            '' define the file dialog
            Using dialog As OpenFileDialog = New OpenFileDialog()
                dialog.Title = "Seleccione una imagen"
                dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF,*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"
                dialog.FilterIndex = 1
                dialog.RestoreDirectory = True
                dialog.CheckFileExists = True
                If Not String.IsNullOrWhiteSpace(workingDirectory) Then dialog.InitialDirectory = workingDirectory
                If dialog.ShowDialog() = DialogResult.OK Then
                    fileName = Path.GetFileName(dialog.FileName)
                    filePath = Path.GetFullPath(dialog.FileName)
                    workingDirectory = Path.GetDirectoryName(dialog.FileName)
                    If Not String.IsNullOrWhiteSpace(fileName) Then
                        '' have a path for a image I can insert

                        txtEditorHtml.InsertImage(filePath)


                    End If
                End If
            End Using

            txtEditorHtml.Focus()
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Private Sub bLoadFile_Click(sender As Object, e As EventArgs) Handles bLoadFile.Click
        Try
            txtEditorHtml.OpenFilePrompt()
            txtEditorHtml.Focus()
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            BodyHTML = txtEditorHtml.BodyHtml

            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Private Sub bSaveHtml_Click(sender As Object, e As EventArgs) Handles bSaveHtml.Click
        Try
            txtEditorHtml.SaveFilePrompt()
            txtEditorHtml.Focus()
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub
End Class