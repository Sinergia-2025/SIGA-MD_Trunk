Public Class ucConfBase

   Protected Property Inicializada As Boolean = False
   Protected Property UbicacionParametro As String

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      'If Not DesignMode Then
      '   Inicializar()
      'End If
   End Sub

#Region "Inicializar"
   Public Sub Inicializar()
      FindForm().TryCatched(
         Sub()
            Dim publicos = New Publicos()
            Dim e = New InicializarEventArgs(publicos)
            OnPreInicializar(e)
            If Not e.Cancel Then
               OnInicializando(e)
               If Not e.Cancel Then
                  OnPosInicializar(e)
               End If
            End If
         End Sub)
   End Sub

   Public Event PreInicializar As EventHandler(Of InicializarEventArgs)
   Protected Overridable Sub OnPreInicializar(e As InicializarEventArgs)
      RaiseEvent PreInicializar(Me, e)
   End Sub
   Public Event Inicializando As EventHandler(Of InicializarEventArgs)
   Protected Overridable Sub OnInicializando(e As InicializarEventArgs)
      RaiseEvent Inicializando(Me, e)
   End Sub
   Public Event PosInicializar As EventHandler(Of InicializarEventArgs)
   Protected Overridable Sub OnPosInicializar(e As InicializarEventArgs)
      RaiseEvent PosInicializar(Me, e)
      If Not e.Cancel Then
         Inicializada = True
         InicializaUbicacionParametro()
      End If
   End Sub

   Private Sub InicializaUbicacionParametro()
      Dim lst = New Stack(Of String)
      LocateControlOnTabs(Sub(tc, tp) lst.Push(tp.Text))
      UbicacionParametro = String.Format("{2} => {0} : {1}", String.Join(" -> ", lst), [GetType]().Name, FindForm().Text)
   End Sub

#End Region

#Region "CargarParametros"
   Public Sub CargarParametros()
      Dim frm = FindForm()
      If frm Is Nothing Then Exit Sub
      frm.TryCatched(
         Sub()
            Dim e = New CancelableEventArgs()
            OnPreCargar(e)
            If Not e.Cancel Then
               OnCargando(e)
               If Not e.Cancel Then
                  OnPosCargar(e)
               End If
            End If
         End Sub,
         Sub(o, ex)
            Enabled = False
            lblErrorEnCarga.Visible = True
            o.ShowError(ex)
         End Sub)
   End Sub

   Public Event PreCargar As EventHandler(Of CancelableEventArgs)
   Protected Sub OnPreCargar(e As CancelableEventArgs)
      RaiseEvent PreCargar(Me, e)
   End Sub
   Public Event Cargando As EventHandler(Of CancelableEventArgs)
   Protected Overridable Sub OnCargando(e As CancelableEventArgs)
      RaiseEvent Cargando(Me, e)
   End Sub
   Public Event PosCargar As EventHandler(Of CancelableEventArgs)
   Protected Sub OnPosCargar(e As CancelableEventArgs)
      RaiseEvent PosCargar(Me, e)
   End Sub
#End Region

#Region "ValidarParametros"
   Public Function ValidarParametros(stb As StringBuilder) As Boolean
      Dim frm = FindForm()
      If frm Is Nothing Then Return False
      Dim e = New ValidacionEventArgs(stb)
      frm.TryCatched(
         Sub()
            OnPreValidar(e)
            If Not e.Cancel Then
               OnValidando(e)
               If Not e.Cancel Then
                  OnPosValidar(e)
               End If
            End If

         End Sub)
      Return e.ConError
   End Function

   Public Event PreValidar As EventHandler(Of ValidacionEventArgs)
   Protected Overridable Sub OnPreValidar(e As ValidacionEventArgs)

   End Sub
   Public Event Validando As EventHandler(Of ValidacionEventArgs)
   Protected Overridable Sub OnValidando(e As ValidacionEventArgs)

   End Sub
   Public Event PosValidar As EventHandler(Of ValidacionEventArgs)
   Protected Overridable Sub OnPosValidar(e As ValidacionEventArgs)

   End Sub

#End Region

#Region "GrabarParametros"
   Public Function GrabarParametros() As Boolean
      Dim frm = FindForm()
      If frm Is Nothing Then Return True
      Dim e = New CancelableEventArgs()
      FindForm().TryCatched(
         Sub()
            OnPreGrabar(e)
            If Not e.Cancel Then
               OnGrabando(e)
               If Not e.Cancel Then
                  OnPosGrabar(e)
               End If
            End If
         End Sub)
      Return Not e.Cancel
   End Function

   Public Event PreGrabar As EventHandler(Of CancelableEventArgs)
   Protected Overridable Sub OnPreGrabar(e As CancelableEventArgs)
      If lblErrorEnCarga.Visible Then
         e.Cancel = True
      Else
         RaiseEvent PreGrabar(Me, e)
      End If

   End Sub
   Public Event Grabando As EventHandler(Of CancelableEventArgs)
   Protected Overridable Sub OnGrabando(e As CancelableEventArgs)
      RaiseEvent Grabando(Me, e)
   End Sub
   Public Event PosGrabar As EventHandler(Of CancelableEventArgs)
   Protected Overridable Sub OnPosGrabar(e As CancelableEventArgs)
      RaiseEvent PosGrabar(Me, e)
   End Sub
#End Region

#Region "ActualizarParametro"
   Protected Sub ActualizarParametro(Of T)(idParametro As Entidades.Parametro.Parametros, valorParametro As ComboBox, categoriaParametro As String, descripcionParametro As String)
      Dim valor = valorParametro.ValorSeleccionado(Of T)
      If valor IsNot Nothing Then
         ActualizarParametro(idParametro, valor.ToString(), categoriaParametro, descripcionParametro)
      Else
         Dim a = 1
      End If
   End Sub
   Protected Sub ActualizarParametro(idParametro As Entidades.Parametro.Parametros, valorParametro As CheckBox, categoriaParametro As String)
      ActualizarParametro(idParametro, valorParametro, categoriaParametro, valorParametro.Text)
   End Sub
   Protected Sub ActualizarParametro(idParametro As Entidades.Parametro.Parametros, valorParametro As CheckBox, categoriaParametro As String, descripcionParametro As String)
      ActualizarParametro(idParametro, valorParametro.Checked.ToString(), categoriaParametro, descripcionParametro)
   End Sub
   Protected Sub ActualizarParametro(idParametro As Entidades.Parametro.Parametros, valorParametro As DateTimePicker, categoriaParametro As String, descripcionParametro As String)
      ActualizarParametro(idParametro, valorParametro.Value.ToString("dd/MM/yyyy"), categoriaParametro, descripcionParametro)
   End Sub
   Protected Sub ActualizarParametro(idParametro As Entidades.Parametro.Parametros, valorParametro As Controles.Buscador, categoriaParametro As String, descripcionParametro As String)
      ActualizarParametro(idParametro, valorParametro.Text, categoriaParametro, descripcionParametro)
   End Sub
   Protected Sub ActualizarParametro(idParametro As Entidades.Parametro.Parametros, valorParametro As Controles.Buscador2, categoriaParametro As String, descripcionParametro As String)
      ActualizarParametro(idParametro, valorParametro.Text, categoriaParametro, descripcionParametro)
   End Sub
   Protected Sub ActualizarParametro(idParametro As Entidades.Parametro.Parametros, valorParametro As TextBox, categoriaParametro As String, descripcionParametro As String)
      ActualizarParametro(idParametro, valorParametro.Text, categoriaParametro, descripcionParametro)
   End Sub
   Public Sub ActualizarParametroTexto(idParametro As Entidades.Parametro.Parametros, valorParametro As String, categoriaParametro As String, descripcionParametro As String)
      ActualizarParametro(idParametro, valorParametro, categoriaParametro, descripcionParametro)
   End Sub
   Public Sub ActualizarParametroClaveTexto(idParametro As String, valorParametro As String, categoriaParametro As String, descripcionParametro As String)
      ActualizarParametro(idParametro, valorParametro, categoriaParametro, descripcionParametro)
   End Sub
   Private Sub ActualizarParametro(idParametro As Entidades.Parametro.Parametros, valorParametro As String, categoriaParametro As String, descripcionParametro As String)
      ActualizarParametro(idParametro.ToString(), valorParametro, categoriaParametro, descripcionParametro)
   End Sub
   Private Sub ActualizarParametro(idParametro As String, valorParametro As String, categoriaParametro As String, descripcionParametro As String)
      Try
         Reglas.ParametrosCache.Editor.Instancia().Actualizar(idParametro, valorParametro, categoriaParametro, descripcionParametro, UbicacionParametro)
      Catch ex As Exception
         Throw New Exception(String.Format("Error guardando parámetro {0}: {1}", idParametro.ToString(), ex.Message), ex)
      End Try
   End Sub
#End Region

End Class
Public Class CancelableEventArgs
   Inherits EventArgs
   Public Property Cancel As Boolean = False
End Class
Public Class InicializarEventArgs
   Inherits CancelableEventArgs
   Public Property Publicos As Publicos
   Public Sub New(publicos As Publicos)
      Me.Publicos = publicos
   End Sub
End Class
Public Class ValidacionEventArgs
   Inherits CancelableEventArgs
   Public Property ConError As Boolean
   Public Property MensajesError As StringBuilder
   Public Sub New()
      Me.New(New StringBuilder())
   End Sub
   Public Sub New(stb As StringBuilder)
      ConError = False
      MensajesError = stb
   End Sub
   Public Sub AgregarError(mensaje As String)
      MensajesError.AppendLine(mensaje)
      ConError = True
   End Sub
   Public Sub AgregarError(mensaje As String, ParamArray args As Object())
      AgregarError(String.Format(mensaje, args))
   End Sub
End Class