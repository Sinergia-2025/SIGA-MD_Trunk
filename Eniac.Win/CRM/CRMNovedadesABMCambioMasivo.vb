Public Class CRMNovedadesABMCambioMasivo
   Private _cuentaCaracteres As String

   Private _cambioMasivo As Entidades.CRMNovedad.CambioMasivo
   Private _publicos As Publicos
   Private _idTipoNovedad As String
   Private _dt As DataTable

#Region "Overrides/Overloads"
   Protected Overrides Sub OnLoad(e As EventArgs)
      TryCatched(Sub() _cuentaCaracteres = lblCuentaCaracteres.Text)
      MyBase.OnLoad(e)
      TryCatched(Sub() InicializaControles())
      TryCatched(Sub() MuestraDatos())
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(
      Sub()
         'Estado
         btnCancelar.Focus()
         If _cambioMasivo.EstadoNovedad IsNot Nothing Then
            chbComentario.Checked = _cambioMasivo.EstadoNovedad.RequiereComentarios
            chbComentario.Enabled = Not _cambioMasivo.EstadoNovedad.RequiereComentarios
            If _cambioMasivo.EstadoNovedad.RequiereComentarios Then
               txtComentarios.Focus()
            End If
         Else
            chbComentario.Checked = False
            txtEstado.SetVisible(False)
         End If
      End Sub)
   End Sub

   Public Overloads Function ShowDialog(owner As IWin32Window, dt As DataTable, cambioMasivo As Entidades.CRMNovedad.CambioMasivo, idTipoNovedad As String) As DialogResult
      _dt = dt
      _cambioMasivo = cambioMasivo
      _idTipoNovedad = idTipoNovedad

      Return ShowDialog(owner)
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Comentarios"
   Private Sub chbComentario_CheckedChanged(sender As Object, e As EventArgs) Handles chbComentario.CheckedChanged
      TryCatched(
      Sub()
         pnlComentarios.Enabled = chbComentario.Checked
         pnlComentarios.Visible = chbComentario.Checked
         Dim delta = pnlComentarios.Width - chbComentario.Width
         delta *= If(chbComentario.Checked, 1, -1)
         Width += delta
         Left = Math.Max(0, Left + (delta / -2).ToInteger())
      End Sub)
   End Sub
   Private Sub txtComentarios_TextChanged(sender As Object, e As EventArgs) Handles txtComentarios.TextChanged
      TryCatched(Sub() lblCuentaCaracteres.Text = String.Format(_cuentaCaracteres, txtComentarios.Text.Length))
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            Dim fileInfo = New IO.FileInfo(DialogoAbrirArchivo.FileName)
            If fileInfo.Exists Then
               'Si bien aca lo pude abrir, solo es para obtener el path.
               txtNombreAdjunto.Text = DialogoAbrirArchivo.FileName
               txtNombreAdjunto.Focus()
            Else
               ShowMessage(String.Format("No se puede acceder al archivo '{0}'.", DialogoAbrirArchivo.FileName))
            End If
         Catch Ex As Exception
            ShowMessage(String.Format("ATENCION: No se puede leer el Archivo. Error: {0}", Ex.Message))
         End Try
      End If
   End Sub
#End Region
#Region "Eventos Acciones"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub
#End Region
#End Region

#Region "Métodos Privados"
   Private Sub InicializaControles()
      _publicos = New Publicos()
      _publicos.CargaComboCRMTiposComentariosNovedades(cmbNuevoIdTipoComentarioNovedad, _idTipoNovedad)
      CargaNuevoTipoComentarioDefault()

      _publicos.CargaComboDesdeEnum(cmbComentarioPrincipal, Entidades.CRMNovedad.ComentarioPrincipalOptiones.Ultimo)


      Dim tienePermisoParaUsarAdjuntos = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, _idTipoNovedad + "-PuedeAdjuntar")


      If Not tienePermisoParaUsarAdjuntos Then
         btnExaminar.Enabled = False
         lblNombreAdjunto.Enabled = False
         txtNombreAdjunto.Enabled = False

         btnExaminar.Visible = False
         lblNombreAdjunto.Visible = False
         txtNombreAdjunto.Visible = False
      End If


   End Sub
   Private Sub MuestraDatos()
      Dim cantidad = _dt.Count()
      txtCantidadRegistros.SetValor(cantidad)
      If cantidad > 15 Then
         txtCantidadRegistros.BackColor = Color.Red
         txtCantidadRegistros.ForeColor = Color.White
      ElseIf cantidad > 10 Then
         txtCantidadRegistros.BackColor = Color.LightCoral
      ElseIf cantidad > 5 Then
         txtCantidadRegistros.BackColor = Color.Yellow
      ElseIf cantidad > 1 Then
         txtCantidadRegistros.BackColor = Color.LightYellow
      Else
         txtCantidadRegistros.BackColor = Color.White
      End If

      'Prioridad
      If _cambioMasivo.Prioridad IsNot Nothing Then
         txtPrioridad.Text = _cambioMasivo.Prioridad.NombrePrioridadNovedad
      ElseIf _cambioMasivo.PrioridadDelta <> 0 Then
         txtPrioridad.Text = String.Format("{0}{1}", If(_cambioMasivo.PrioridadDelta < 0, "-", "+"), _cambioMasivo.PrioridadDelta)
      Else
         txtPrioridad.SetVisible(False)
      End If

      'Etiqueta
      If Not String.IsNullOrWhiteSpace(_cambioMasivo.EtiquetaNovedad) Then
         txtEtiquetas.Text = String.Format("{0}: {1}", _cambioMasivo.AccionEtiquetaNovedad.ToString(), _cambioMasivo.EtiquetaNovedad)
      Else
         txtEtiquetas.SetVisible(False)
      End If

      'Requiere Test
      If _cambioMasivo.RequiereTesteo.HasValue Then
         txtRequiereTest.Text = If(_cambioMasivo.RequiereTesteo.Value, "SI", "NO")
      Else
         txtRequiereTest.SetVisible(False)
      End If

      'Usuario Asignado
      If _cambioMasivo.UsuarioAsignado IsNot Nothing Then
         txtUsuarioAsignado.Text = _cambioMasivo.UsuarioAsignado.Nombre
      Else
         txtUsuarioAsignado.SetVisible(False)
      End If

      'Medio
      If _cambioMasivo.MedioNovedad IsNot Nothing Then
         txtMedio.Text = _cambioMasivo.MedioNovedad.NombreMedioComunicacionNovedad
         txtMedio.BackColor = _cambioMasivo.MedioNovedad.Color.ToArgbColor()
      Else
         txtMedio.SetVisible(False)
      End If

      'Estado
      If _cambioMasivo.EstadoNovedad IsNot Nothing Then
         txtEstado.Text = _cambioMasivo.EstadoNovedad.NombreEstadoNovedad
         txtEstado.BackColor = _cambioMasivo.EstadoNovedad.Color.ToArgbColor()
         'If _cambioMasivo.EstadoNovedad.RequiereComentarios Then
         '   chbComentario.Checked = True
         '   chbComentario.Enabled = False
         'End If
      Else
         txtEstado.SetVisible(False)
      End If

      'Color
      If _cambioMasivo.BanderaColor.HasValue Then
         txtColor.BackColor = _cambioMasivo.BanderaColor.Value
      Else
         txtColor.SetVisible(False)
      End If

      'Priorizado
      If _cambioMasivo.Priorizado.HasValue Then
         txtPriorizado.Text = If(_cambioMasivo.Priorizado.Value, "SI", "NO")
      Else
         txtPriorizado.SetVisible(False)
      End If

   End Sub
   Private Sub Aceptar()
      If ValidaAceptar() Then
         If chbComentario.Checked Then
            _cambioMasivo.NuevoComentario = txtComentarios.Text
            _cambioMasivo.NuevoIdTipoComentarioNovedad = cmbNuevoIdTipoComentarioNovedad.ValorSeleccionado(0I)
            _cambioMasivo.NuevoAdjunto = txtNombreAdjunto.Text
            _cambioMasivo.ComentarioPrincipal = cmbComentarioPrincipal.ValorSeleccionado(Of Entidades.CRMNovedad.ComentarioPrincipalOptiones)
         End If
         Close(DialogResult.OK)
      End If
   End Sub
   Private Function ValidaAceptar() As Boolean
      If chbComentario.Checked AndAlso String.IsNullOrWhiteSpace(txtComentarios.Text) Then
         ShowMessage("Debe escribir un comentario")
         Return False
      End If

      If Not String.IsNullOrWhiteSpace(txtNombreAdjunto.Text) Then
         If Not IO.File.Exists(txtNombreAdjunto.Text) Then
            txtNombreAdjunto.Focus()
            ShowMessage(String.Format("El archivo '{0}' no existe.", txtNombreAdjunto.Text))
            Return False
         End If
         If String.IsNullOrWhiteSpace(txtComentarios.Text) Then
            txtComentarios.Focus()
            ShowMessage("Para adjuntar un archivo, debe ingresar un comentario.")
            Return False
         End If
      End If

      If cmbComentarioPrincipal.SelectedIndex < 0 Then
         cmbComentarioPrincipal.Focus()
         ShowMessage("Debe seleccionar valor para Comentario Principal.")
         Return False
      End If
      If cmbNuevoIdTipoComentarioNovedad.SelectedIndex < 0 Then
         cmbNuevoIdTipoComentarioNovedad.Focus()
         ShowMessage("Debe seleccionar un Tipo de Comentario.")
         Return False
      End If

      Return True
   End Function

   Private Sub CargaNuevoTipoComentarioDefault()
      If cmbNuevoIdTipoComentarioNovedad.Items.Count = 1 Then
         cmbNuevoIdTipoComentarioNovedad.SelectedIndex = 0
      Else
         cmbNuevoIdTipoComentarioNovedad.SelectedIndex = -1
         Dim tipoDef = DirectCast(cmbNuevoIdTipoComentarioNovedad.DataSource, List(Of Entidades.CRMTipoComentarioNovedad)).FirstOrDefault(Function(x) x.PorDefecto)
         If tipoDef IsNot Nothing Then
            cmbNuevoIdTipoComentarioNovedad.SelectedValue = tipoDef.IdTipoComentarioNovedad
         End If
      End If
   End Sub
#End Region

End Class