Public Class SolicitarSoporte

   Private _sincroGestion As Reglas.ServiciosRest.Gestion.SincronizarGestion
   Private _cuentaCaracteresFormato As String
   Private _idCatDefault As Integer

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
      TryCatched(
      Sub()
         _sincroGestion = New Reglas.ServiciosRest.Gestion.SincronizarGestion()

         _cuentaCaracteresFormato = lblCuentaCaracteres.Text
      End Sub)
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() ugAdjuntos.DataSource = New List(Of ArchivoSeleccionado)())
      TryCatched(Sub() CargaComboCatagoriasDesdeGestion())
      TryCatched(Sub() LimpiaPantalla())
      TryCatched(Sub() lblCuentaCaracteres.Text = String.Format(_cuentaCaracteresFormato, txtComentarios.Text.Length))
   End Sub
#End Region

#Region "Eventos"
   Private Sub txtComentarios_TextChanged(sender As Object, e As EventArgs) Handles txtComentarios.TextChanged
      TryCatched(Sub() lblCuentaCaracteres.Text = String.Format(_cuentaCaracteresFormato, txtComentarios.Text.Length))
   End Sub
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

#Region "Eventos Adjuntos"
   Private Sub btnAgregarAdjunto_Click(sender As Object, e As EventArgs) Handles btnAgregarAdjunto.Click
      TryCatched(
      Sub()
         If OpenFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            AgregarAdjuntos(OpenFileDialog1.FileNames)
         End If
      End Sub)
   End Sub
   Private Sub btnQuitarAdjunto_Click(sender As Object, e As EventArgs) Handles btnQuitarAdjunto.Click
      TryCatched(
      Sub()
         Dim selec = ugAdjuntos.FilasSeleccionadas(Of ArchivoSeleccionado)
         If selec.CountSecure > 0 Then
            If ShowPregunta(String.Format("¿Desea eliminar los {0} archivos seleccionados?", selec.CountSecure)) = DialogResult.Yes Then
               EliminarAdjuntos(selec)
            End If
         End If
      End Sub)
   End Sub
#Region "Eventos DragDrop"
   Private Sub ugScripts_DragDrop(sender As Object, e As DragEventArgs) Handles ugAdjuntos.DragDrop
      TryCatched(
         Sub()
            Dim archivos = DirectCast(e.Data.GetData(DataFormats.FileDrop), IEnumerable(Of String))
            AgregarAdjuntos(archivos)
         End Sub)
   End Sub
   Private Sub ugScripts_DragOver(sender As Object, e As DragEventArgs) Handles ugAdjuntos.DragOver
      If e.Data.GetDataPresent(DataFormats.FileDrop) Then
         e.Effect = DragDropEffects.Copy
      Else
         e.Effect = DragDropEffects.None
      End If
   End Sub
#End Region
#End Region

#End Region

#Region "Metodos Privados"
   Private Sub Aceptar()
      Dim tk = _sincroGestion.EnviarNuevoTicket(txtInterlocutor.Text, txtDescripcion.Text, cmbCategoriaNovedad.ValorSeleccionado(0I), txtComentarios.Text)

      Dim errorAdjuntos = String.Empty
      If tk IsNot Nothing Then
         Try
            Dim adjuntos = ugAdjuntos.DataSource(Of List(Of ArchivoSeleccionado))
            If adjuntos.AnySecure() Then
               _sincroGestion.SubirAdjuntoTicket(tk, ugAdjuntos.DataSource(Of List(Of ArchivoSeleccionado)).ConvertAll(Function(f) f.FullFileName))
            End If
         Catch ex As Exception
            Dim stb = New StringBuilder()
            ArmaErrorRecursivo(ex, stb)
            errorAdjuntos = stb.ToString()
         End Try
      End If

      Dim stbMensaje = New StringBuilder()
      stbMensaje.AppendFormatLine("El nuevo ticket {0}-{1} se registro exitosamente!", tk.Letra, tk.IdNovedad)
      If Not String.IsNullOrWhiteSpace(errorAdjuntos) Then
         stbMensaje.AppendLine().AppendLine().AppendFormatLine("Error subiendo los archivos adjuntos:").Append(errorAdjuntos)
      End If
      ShowMessage(stbMensaje.ToString())

      LimpiaPantalla()
      'Close(DialogResult.OK)
   End Sub

   Private Sub CargaComboCatagoriasDesdeGestion()
      Dim cat = _sincroGestion.GetCategorias().OrderBy(Function(x) x.NombreCategoriaNovedad).ToList()
      Dim catDefault = cat.FirstOrDefault(Function(x) x.PorDefecto)
      If catDefault IsNot Nothing Then
         _idCatDefault = catDefault.IdCategoriaNovedad
      Else
         _idCatDefault = 0
      End If

      cmbCategoriaNovedad.DisplayMember = Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()
      cmbCategoriaNovedad.ValueMember = Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString()
      cmbCategoriaNovedad.DataSource = cat
   End Sub

   Private Sub LimpiaPantalla()
      txtDescripcion.Clear()
      If _idCatDefault = 0 Then
         cmbCategoriaNovedad.SetSelectedIndexSecure(0)
      Else
         cmbCategoriaNovedad.SelectedValue = _idCatDefault
      End If
      txtComentarios.Clear()

      ugAdjuntos.ClearFilas()
      RefreshGrid()

      txtDescripcion.Focus()
   End Sub

   Private Sub AgregarAdjuntos(files As IEnumerable(Of String))
      AgregarAdjuntos(files.ToList().ConvertAll(Function(f) New ArchivoSeleccionado(f)))
   End Sub
   Private Sub AgregarAdjuntos(files As IEnumerable(Of ArchivoSeleccionado))
      ugAdjuntos.DataSource(Of List(Of ArchivoSeleccionado)).AddRange(files)
      RefreshGrid()
   End Sub

   Private Sub EliminarAdjuntos(files As IEnumerable(Of String))
      EliminarAdjuntos(files.ToList().ConvertAll(Function(f) New ArchivoSeleccionado(f)))
   End Sub
   Private Sub EliminarAdjuntos(files As IEnumerable(Of ArchivoSeleccionado))
      ugAdjuntos.DataSource(Of List(Of ArchivoSeleccionado)).RemoveAll(Function(f) files.Contains(f))
      RefreshGrid()
   End Sub
   Private Sub RefreshGrid()
      ugAdjuntos.Rows.Refresh(RefreshRow.ReloadData)
      ugAdjuntos.DisplayLayout.Bands(0).Columns("FileName").PerformAutoResize(PerformAutoSizeType.AllRowsInBand)
   End Sub

#End Region

   Private Structure ArchivoSeleccionado
      Public ReadOnly Property FileName As String
         Get
            If FileInfo Is Nothing Then Return String.Empty Else Return FileInfo.Name
         End Get
      End Property
      Public ReadOnly Property FullFileName As String
         Get
            If FileInfo Is Nothing Then Return String.Empty Else Return FileInfo.FullName
         End Get
      End Property
      Public ReadOnly Property FileInfo As IO.FileInfo

      Public Sub New(fileInfo As IO.FileInfo)
         Me.New()
         Me.FileInfo = fileInfo
      End Sub
      Public Sub New(fullFileName As String)
         Me.New(New IO.FileInfo(fullFileName))
      End Sub
   End Structure

End Class