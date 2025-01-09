Public Class CategoriasImagenesDetalle

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.CategoriaImagen)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      Me._tituloNuevo = "Nueva"

      MyBase.OnLoad(e)
      Me._publicos = New Publicos()

      Me._publicos.CargaComboTipoNave(Me.cmbTipoNave)
      Me.cmbTipoNave.SelectedIndex = -1

      Me._publicos.CargaComboCategorias(Me.cmbCategorias)

      Me._liSources.Add("Categoria", DirectCast(Me._entidad, Entidades.CategoriaImagen).Categoria)

      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoCodigo()

      Else

         If DirectCast(Me._entidad, Entidades.CategoriaImagen).Foto IsNot Nothing Then
            Me.pcbFoto.Image = Entidades.Publicos.GetFotoFromBites(DirectCast(Me._entidad, Entidades.CategoriaImagen).Foto)
         End If

         If DirectCast(Me._entidad, Entidades.CategoriaImagen).FotoReverso IsNot Nothing Then
            Me.pcbFotoReverso.Image = Entidades.Publicos.GetFotoFromBites(DirectCast(Me._entidad, Entidades.CategoriaImagen).FotoReverso)
         End If

         If DirectCast(Me._entidad, Entidades.CategoriaImagen).ColorFuente IsNot Nothing Then
            Me.ucpTableroDePartidasForColorBotadas.ColorHtml = DirectCast(Me._entidad, Entidades.CategoriaImagen).ColorFuente
         End If

         If DirectCast(Me._entidad, Entidades.CategoriaImagen).ColorFuenteVto IsNot Nothing Then
            Me.ucpColorFuenteVtoTextoCredencial.ColorHtml = DirectCast(Me._entidad, Entidades.CategoriaImagen).ColorFuenteVto
         End If

      End If

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CategoriasImagenes()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If pcbFoto.Image Is Nothing Then
         Return "Debe seleccionar una Imagen."
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.cmbTipoNave.SelectedIndex = -1
      Me.txtIdCategoriaImagen.Focus()
   End Sub

   Private Sub pcbFoto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pcbFoto.DoubleClick
      If Me.pcbFoto.Image Is Nothing Then
         MessageBox.Show("No hay foto para mostrar", Me.Text, MessageBoxButtons.OK)
         Exit Sub
      End If
      Using frmVisorFotos As New VisorFotos
         frmVisorFotos.Foto = Me.pcbFoto.Image
         frmVisorFotos.ShowDialog(Me)
      End Using
   End Sub

   Private Sub btnLimpiarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarImagen.Click
      Try
         DirectCast(Me._entidad, Entidades.CategoriaImagen).Foto = Nothing
         Me.pcbFoto.Image = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarImagen.Click
      Try
         If Me.ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.ofdArchivos.FileName) Then
               If System.IO.File.ReadAllBytes(Me.ofdArchivos.FileName).Length > Publicos.MaximoTamanioFoto Then
                  MessageBox.Show("El tamaño de la imagen no puede ser mayor a " + (Publicos.MaximoTamanioFoto / 1024).ToString() + "KB", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Me.pcbFoto.Image = New System.Drawing.Bitmap(Me.ofdArchivos.FileName)
               DirectCast(Me._entidad, Entidades.CategoriaImagen).Foto = Eniac.Entidades.Publicos.GetFotoFromImage(Me.pcbFoto.Image, System.IO.Path.GetExtension(Me.ofdArchivos.FileName))
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
      Try
         Me.cmbTipoNave.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.CategoriaImagen).IdTipoNave = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ucpTableroDePartidasForColorBotadas_ColorChanged(sender As Object, e As EventArgs) Handles ucpTableroDePartidasForColorBotadas.ColorChanged
      Try
         DirectCast(Me._entidad, Entidades.CategoriaImagen).ColorFuente = Me.ucpTableroDePartidasForColorBotadas.ColorHtml
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()
      Dim oRegCategoriasImagenes As Reglas.CategoriasImagenes = New Reglas.CategoriasImagenes()
      Dim ProximaCategoria As Integer
      ProximaCategoria = oRegCategoriasImagenes.GetCodigoMaximo() + 1
      Me.txtIdCategoriaImagen.Text = ProximaCategoria.ToString()
   End Sub



#End Region

 
   Private Sub btnBuscarImagenReverso_Click(sender As Object, e As EventArgs) Handles btnBuscarImagenReverso.Click
      Try
         If Me.ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.ofdArchivos.FileName) Then
               If System.IO.File.ReadAllBytes(Me.ofdArchivos.FileName).Length > Publicos.MaximoTamanioFoto Then
                  MessageBox.Show("El tamaño de la imagen no puede ser mayor a " + (Publicos.MaximoTamanioFoto / 1024).ToString() + "KB", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Me.pcbFotoReverso.Image = New System.Drawing.Bitmap(Me.ofdArchivos.FileName)
               DirectCast(Me._entidad, Entidades.CategoriaImagen).FotoReverso = Entidades.Publicos.GetFotoFromImage(Me.pcbFotoReverso.Image, System.IO.Path.GetExtension(Me.ofdArchivos.FileName))
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiarImagenReverso_Click(sender As Object, e As EventArgs) Handles btnLimpiarImagenReverso.Click
      Try

         DirectCast(Me._entidad, Entidades.CategoriaImagen).FotoReverso = Nothing
         Me.pcbFotoReverso.Image = Nothing

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ucpColorFuenteVtoTextoCredencial_ColorChanged(sender As Object, e As EventArgs) Handles ucpColorFuenteVtoTextoCredencial.ColorChanged
      Try
         DirectCast(Me._entidad, Entidades.CategoriaImagen).ColorFuenteVto = Me.ucpColorFuenteVtoTextoCredencial.ColorHtml
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class
