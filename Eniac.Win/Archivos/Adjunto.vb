Option Strict On
Option Explicit On
Imports System.IO
Public Class Adjunto
   Inherits BaseDetalle
#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.IAdjunto, regla As Reglas.IReglaAdjuntos)
      Me.InitializeComponent()
      AdjuntoOriginal = entidad
      _entidad = DirectCast(entidad, Entidades.Entidad)
      _regla = regla
   End Sub
   Private _publicos As Publicos
   Private _regla As Reglas.IReglaAdjuntos

#End Region

   Private Property AdjuntoOriginal As Entidades.IAdjunto

   Private ReadOnly Property Adjunto As Entidades.IAdjunto
      Get
         Return DirectCast(Me._entidad, Eniac.Entidades.IAdjunto)
      End Get
   End Property

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Dim tempText As String = Me.Text

      MyBase.OnLoad(e)

      btnBuscarAdjunto.Visible = StateForm = Win.StateForm.Insertar

      Me._publicos = New Publicos()

      _entidad = DirectCast(_regla.GetOClonar(Adjunto), Entidades.Entidad)

      _publicos.CargaComboTiposAdjuntos(cmbTipoAdjunto)
      If cmbTipoAdjunto.Items.Count > 0 Then
         cmbTipoAdjunto.SelectedIndex = 0
      End If

      Me.BindearControles(Me._entidad)

      Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

      If StateForm = Win.StateForm.Insertar Then
         Me.txtNivelAutorizacion.Text = actual.NivelAutorizacion.ToString()
      ElseIf StateForm = Win.StateForm.Actualizar Then
         btnAbrir.Visible = False
         btnGuardar.Visible = False
      ElseIf StateForm = Win.StateForm.Consultar Then
         txtObservaciones.ReadOnly = True
         cmbTipoAdjunto.Enabled = False
         btnAceptar.Visible = False
      End If

      Dim tamano As Decimal = 0
      If Not (IsNothing(Adjunto.Adjunto)) Then
         tamano = Adjunto.Adjunto.Length
      Else
         If Not String.IsNullOrWhiteSpace(Adjunto.NombreAdjuntoCompleto) Then
            Dim fileinfo As FileInfo = New FileInfo(Adjunto.NombreAdjuntoCompleto)
            If fileinfo.Exists Then
               tamano = fileinfo.Length
            End If
         End If
      End If

      If tamano = 0 Then
         If StateForm = Win.StateForm.Actualizar Then
            ShowError(New Exception("El archivo no existe."))
         End If
         Me.btnAbrir.Enabled = False
         Me.btnGuardar.Enabled = False
      End If

      MostrarTamano(tamano, 0)

      Me.Text = tempText

   End Sub

#End Region

   Private _unidadTamano As String() = {"B", "KB", "MB", "GB"}
   Private Function MostrarTamano(tamano As Decimal, unidadIndex As Integer) As Decimal
      If tamano < 1024 Then
         txtTamano.Text = String.Format("{0:N2} {1}", tamano, _unidadTamano(unidadIndex))
      Else
         unidadIndex += 1
         tamano = tamano / 1024
         MostrarTamano(tamano, unidadIndex)
      End If
   End Function

#Region "Eventos"

   Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
      Try
         Dim nombreWS As String = Me.Text
         Dim sfdExportar As System.Windows.Forms.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
         sfdExportar.FileName = Adjunto.NombreAdjuntoCompleto
         sfdExportar.AddExtension = True
         sfdExportar.Filter = "All Files (*.*)|*.*"
         If sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(sfdExportar.FileName.Trim()) Then
               If Not IsNothing(Adjunto.Adjunto) Then
                  IO.File.WriteAllBytes(sfdExportar.FileName.Trim(), Adjunto.Adjunto)
               Else
                  IO.File.Copy(Adjunto.NombreAdjuntoCompleto, sfdExportar.FileName.Trim())
               End If

               ShowMessage("Archivo grabado exitosamente.")
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
      Try
         Dim nombreWS As String = Me.Text
         Dim sfdExportar As System.Windows.Forms.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()

         Dim nombreAdjunto As String = Adjunto.NombreAdjuntoCompleto
         If nombreAdjunto Is Nothing Then
            nombreAdjunto = Adjunto.NombreAdjunto
         End If
         Dim fi As FileInfo = New FileInfo(nombreAdjunto)
         If fi.Directory.Exists Then
            nombreAdjunto = fi.Name
         End If

         Dim tempPath As String = Path.Combine(IO.Path.GetTempPath, nombreAdjunto)

         If Not IsNothing(Adjunto.Adjunto) Then
            IO.File.WriteAllBytes(tempPath, Adjunto.Adjunto)
         Else
            IO.File.Copy(Adjunto.NombreAdjuntoCompleto, tempPath, True)
         End If

         System.Diagnostics.Process.Start(tempPath)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub


#End Region

#Region "Metodos"
   Protected Overrides Sub Aceptar()
      'MyBase.Aceptar()

      If IsNothing(Adjunto.Adjunto) Then
         If String.IsNullOrWhiteSpace(Adjunto.NombreAdjunto) Then
            ShowMessage("Debe seleccionar un archivo a adjuntar.")
            btnBuscarAdjunto.Focus()
            Exit Sub
         End If
         If String.IsNullOrWhiteSpace(Adjunto.NombreAdjuntoCompleto) Then
            Adjunto.NombreAdjuntoCompleto = Adjunto.NombreAdjunto
         End If
         Dim fi As FileInfo = New FileInfo(Adjunto.NombreAdjuntoCompleto)
         If Not fi.Exists Then
            ShowMessage("El archivo seleccionado no existe.")
            btnBuscarAdjunto.Focus()
            Exit Sub
         Else

         End If
      End If

      If cmbTipoAdjunto.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar un tipo de adjunto.")
         cmbTipoAdjunto.Focus()
         Exit Sub
      End If


      If Not IsNumeric(txtNivelAutorizacion.Text) Then txtNivelAutorizacion.Text = "1"
      If Short.Parse(txtNivelAutorizacion.Text) > actual.NivelAutorizacion Then
         Me.txtNivelAutorizacion.Focus()
         ShowMessage("ATENCION: El nivel de autorización ingresado es superior al suyo.")
         Exit Sub
      End If

      Adjunto.NombreTipoAdjunto = cmbTipoAdjunto.Text

      Dim fi2 As FileInfo = New FileInfo(Adjunto.NombreAdjunto)

      'AdjuntoOriginal.IdCliente = Adjunto.IdCliente
      'AdjuntoOriginal.IdClienteAdjunto = Adjunto.IdClienteAdjunto
      AdjuntoOriginal.IdTipoAdjunto = Adjunto.IdTipoAdjunto
      AdjuntoOriginal.NombreAdjunto = fi2.Name ' Adjunto.NombreAdjunto
      AdjuntoOriginal.NombreAdjuntoCompleto = Adjunto.NombreAdjuntoCompleto
      AdjuntoOriginal.NombreTipoAdjunto = Adjunto.NombreTipoAdjunto
      AdjuntoOriginal.Adjunto = Adjunto.Adjunto
      AdjuntoOriginal.Observaciones = Adjunto.Observaciones
      AdjuntoOriginal.NivelAutorizacion = Adjunto.NivelAutorizacion
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()

   End Sub

#End Region


   Private Sub btnBuscarAdjunto_Click(sender As Object, e As EventArgs) Handles btnBuscarAdjunto.Click
      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            Dim fileInfo As FileInfo = New FileInfo(DialogoAbrirArchivo.FileName)
            If fileInfo.Exists Then
               'Si bien aca lo pude abrir, solo es para obtener el path.
               txtNombreAdjunto.Text = DialogoAbrirArchivo.FileName
               txtNombreAdjunto.Focus()
               MostrarTamano(fileInfo.Length, 0)
            Else
               ShowMessage(String.Format("No se puede acceder al archivo '{0}'.", DialogoAbrirArchivo.FileName))
            End If
         Catch Ex As Exception
            ShowMessage(String.Format("ATENCION: No se puede leer el Archivo. Error: {0}", Ex.Message))
         End Try
      End If
   End Sub

End Class