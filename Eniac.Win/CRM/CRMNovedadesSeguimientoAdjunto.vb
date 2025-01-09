Imports System.IO
Public Class CRMNovedadesSeguimientoAdjunto
   Inherits BaseDetalle
#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.CRMNovedadSeguimientoAdjunto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
   Private _publicos As Publicos

#End Region


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Dim tempText As String = Me.Text

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.BindearControles(Me._entidad)

      Dim adjunto As Entidades.CRMNovedadSeguimientoAdjunto = CType(Me._entidad, Eniac.Entidades.CRMNovedadSeguimientoAdjunto)
      Dim archivoAdjunto As Entidades.CRMNovedadSeguimientoAdjunto = New Reglas.CRMNovedadesSeguimientoAdjuntos().GetUno(adjunto.IdTipoNovedad,
                                                                                                                         adjunto.Letra,
                                                                                                                         adjunto.CentroEmisor,
                                                                                                                         adjunto.IdNovedad,
                                                                                                                         adjunto.IdSeguimiento,
                                                                                                                         adjunto.IdUnico,
                                                                                                                         True)


      Dim Tamaño As Entidades.Extensiones.TamañoArchivo = Nothing
      If Not (IsNothing(archivoAdjunto.Adjunto)) Then
         Tamaño = archivoAdjunto.Adjunto.Tamaño() ' Convert.ToDecimal(archivoAdjunto.Adjunto.Length / 1024)
      Else
         Dim fileinfo As FileInfo = New FileInfo(adjunto.NombreAdjunto)
         If fileinfo.Exists Then
            Tamaño = fileinfo.Tamaño() ' fileinfo.Length
         End If
      End If

      If Tamaño Is Nothing OrElse Tamaño.Bytes = 0 Then
         ShowError(New Exception("El archivo no existe."))
         Me.btnAbrir.Enabled = False
         Me.btnGuardar.Enabled = False

      Else
         txtTamaño.Text = Tamaño.ToString()
      End If

      ''modificar segun el tamaño a kb o mb
      'If (Tamaño > 1024) Then
      '   Tamaño = Tamaño / 1024
      '   Me.txtTamaño.Text = Tamaño.ToString("N2") + " MB"
      'Else
      '   Me.txtTamaño.Text = Tamaño.ToString("N2") + " KB"
      'End If



      Me.Text = tempText

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtNombre.Focus()
   End Sub

   Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
      Try
         Dim nombreWS As String = Me.Text
         Dim sfdExportar As System.Windows.Forms.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
         Dim seguimiento As Entidades.CRMNovedadSeguimientoAdjunto = CType(Me._entidad, Eniac.Entidades.CRMNovedadSeguimientoAdjunto)
         'Dim _Seguimiento As Entidades.CRMNovedadSeguimiento = CType(Me._entidad, Eniac.Entidades.CRMNovedadSeguimiento)
         sfdExportar.FileName = seguimiento.NombreAdjunto
         sfdExportar.AddExtension = True
         sfdExportar.Filter = "All Files (*.*)|*.*"
         If sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(sfdExportar.FileName.Trim()) Then
               Dim adjunto As Entidades.CRMNovedadSeguimientoAdjunto
               adjunto = New Reglas.CRMNovedadesSeguimientoAdjuntos().GetUno(seguimiento.IdTipoNovedad,
                                                                             seguimiento.Letra,
                                                                             seguimiento.CentroEmisor,
                                                                             seguimiento.IdNovedad,
                                                                             seguimiento.IdSeguimiento,
                                                                             seguimiento.IdUnico,
                                                                             True)
               IO.File.WriteAllBytes(sfdExportar.FileName.Trim(), adjunto.Adjunto)
               btnCancelar.PerformClick()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
      Try
         Dim nombreWS As String = Me.Text
         Dim sfdExportar As System.Windows.Forms.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
         Dim seguimiento As Entidades.CRMNovedadSeguimientoAdjunto = CType(Me._entidad, Eniac.Entidades.CRMNovedadSeguimientoAdjunto)

         Dim adjunto As Entidades.CRMNovedadSeguimientoAdjunto
         adjunto = New Reglas.CRMNovedadesSeguimientoAdjuntos().GetUno(seguimiento.IdTipoNovedad,
                                                                       seguimiento.Letra,
                                                                       seguimiento.CentroEmisor,
                                                                       seguimiento.IdNovedad,
                                                                       seguimiento.IdSeguimiento,
                                                                       seguimiento.IdUnico,
                                                                       True)
         Dim tempPath As String = Path.Combine(IO.Path.GetTempPath, adjunto.NombreAdjunto)
         IO.File.WriteAllBytes(tempPath, adjunto.Adjunto)
         System.Diagnostics.Process.Start(tempPath)
         btnCancelar.PerformClick()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub


#End Region

#Region "Metodos"


#End Region


End Class