Public Class DocumentosDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Documento)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

   Private _publicos As Publicos

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Win.StateForm.Insertar Then
         Me.btnAbrir.Visible = False
         Me.btnExportar.Visible = False
      End If

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Documentos()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If Decimal.Parse(Me.txtVersion.Text) = 0 Then
         Return "No Indico la Versión"
      End If
      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub txtCodigoDocumento_LostFocus(sender As Object, e As EventArgs) Handles txtIdDocumento.LostFocus
      Me.txtIdDocumento.Text = Me.txtIdDocumento.Text.ToUpper()
   End Sub

   Private Sub txtLado_LostFocus(sender As Object, e As EventArgs) Handles txtGrupo.LostFocus
      Me.txtGrupo.Text = Me.txtGrupo.Text.ToUpper()
   End Sub

   Private Sub txtFila_LostFocus(sender As Object, e As EventArgs) Handles txtVersion.LostFocus
      Me.txtVersion.Text = Me.txtVersion.Text.ToUpper()
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtNombre.Focus()
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      Dim ArchivoStream As IO.Stream = Nothing
      Dim DialogoAbrirArchivo As New OpenFileDialog()

      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoAbrirArchivo.Filter = "Todos los Archivos (*.*)|*.*"
      DialogoAbrirArchivo.FilterIndex = 1
      DialogoAbrirArchivo.RestoreDirectory = True

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            ArchivoStream = DialogoAbrirArchivo.OpenFile()
            If (ArchivoStream IsNot Nothing) Then
               'Si bien aca lo pude abrir, solo es para obtener el path.
               Me.txtNombre.Text = DialogoAbrirArchivo.FileName
               Me.txtNombre.Focus()
            End If
         Catch Ex As Exception
            MessageBox.Show("ATENCION: No se puede leer el Archivo. Error: " & Ex.Message)
         Finally
            If (ArchivoStream IsNot Nothing) Then
               ArchivoStream.Close()
            End If
         End Try
      End If
   End Sub

   Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
      Try
         Dim nombreWS As String = Me.Text
         Using sfdExportar = New SaveFileDialog()
            sfdExportar.FileName = CType(Me._entidad, Eniac.Entidades.Documento).Nombre
            sfdExportar.Filter = "All Files (*.*)|*.*"
            If sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
               If Not String.IsNullOrEmpty(sfdExportar.FileName.Trim()) Then
                  Dim doc As Reglas.Documentos = New Reglas.Documentos
                  doc.ExportarDocumento(CType(Me._entidad, Eniac.Entidades.Documento).idDocumento, sfdExportar.FileName.Trim())
                  btnCancelar.PerformClick()
               End If
            End If
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
      Try
         Dim nombreWS As String = Me.Text
         Using sfdExportar = New SaveFileDialog()
            sfdExportar.FileName = CType(Me._entidad, Eniac.Entidades.Documento).Nombre
            sfdExportar.Filter = "All Files (*.*)|*.*"
            If sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
               If Not String.IsNullOrEmpty(sfdExportar.FileName.Trim()) Then
                  Dim doc As Reglas.Documentos = New Reglas.Documentos
                  doc.ExportarDocumento(CType(Me._entidad, Entidades.Documento).idDocumento, sfdExportar.FileName.Trim())
                  System.Diagnostics.Process.Start(sfdExportar.FileName.Trim())
                  btnCancelar.PerformClick()
               End If
            End If
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"


#End Region
End Class