Public Class CRMTiposNovedadesObjetivosDetalle

   Private _publicos As Publicos
   Private _usuarioTodos As List(Of Entidades.Usuario)
   Private _usuario As List(Of Entidades.Usuario)
   Private _titUsuario As Dictionary(Of String, String)
   Private _titAsignado As Dictionary(Of String, String)

   Public ReadOnly Property Objetivo As Entidades.CRMTipoNovedadObjetivo
      Get
         Return DirectCast(_entidad, Entidades.CRMTipoNovedadObjetivo)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.CRMTipoNovedadObjetivo)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()
         _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad)

         _usuarioTodos = New Reglas.Usuarios().GetTodos(toLowerId:=True)

         _usuario = _usuarioTodos.Where(Function(u) Not Objetivo.Usuarios.Any(Function(ou) ou.IdUsuario = u.Id)).ToList()

         _titUsuario = GetColumnasVisiblesGrilla(ugUsuarios)
         _titAsignado = GetColumnasVisiblesGrilla(ugUsuariosAsignados)

         ugUsuarios.DataSource = _usuario
         ugUsuariosAsignados.DataSource = Objetivo.Usuarios

         AjustarColumnasGrilla(ugUsuarios, _titUsuario)
         AjustarColumnasGrilla(ugUsuariosAsignados, _titAsignado)

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            dtpPeriodo.Value = Today

         Else

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CRMTiposNovedadesObjetivos()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      'If chbDiasProximoContacto.Checked And String.IsNullOrWhiteSpace(txtDiasProximoContacto.Text) Then
      '   txtDiasProximoContacto.Focus()
      '   Return "Debe indicar una cantidad de días de próximo contacto."
      'End If

      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Eventos"
   Private Sub dtpPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodo.ValueChanged
      TryCatched(Sub()
                    dtpPeriodo.Value = dtpPeriodo.Value.PrimerDiaMes()
                    Dim habiles = New Reglas.Feriados().GetDiasHabiles(dtpPeriodo.Value.ToPeriodo())
                    txtDiasHabiles.Text = habiles.Habiles.ToString()
                    Objetivo.Usuarios.All(Function(u)
                                             u.DiasHabiles = habiles.Habiles
                                             Return True
                                          End Function)
                 End Sub)
   End Sub

   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      TryCatched(Sub() AgregarUsuario())
   End Sub

   Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
      TryCatched(Sub() QuitarUsuario())
   End Sub

   Private Sub ugUsuarios_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugUsuarios.DoubleClickCell
      TryCatched(Sub() AgregarUsuario())
   End Sub

   Private Sub ugUsuariosAsignados_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugUsuariosAsignados.DoubleClickCell
      TryCatched(Sub() QuitarUsuario())
   End Sub
#End Region

#Region "Metodos"
   Private Sub AgregarUsuario()
      Dim usr = ugUsuarios.FilaSeleccionada(Of Entidades.Usuario)()
      If usr IsNot Nothing Then
         Dim objUsr = New Entidades.CRMTipoNovedadObjetivoUsuario()
         With objUsr
            .IdUsuario = usr.Id
            .NombreUsuario = usr.Nombre
            .Objetivo = 0
            .ObjetivoMinimo = 0
            .DiasHabiles = txtDiasHabiles.ValorNumericoPorDefecto(0I)
         End With
         Objetivo.Usuarios.Add(objUsr)
         _usuario.Remove(usr)
         ugUsuariosAsignados.Rows.Refresh(RefreshRow.ReloadData)
         ugUsuarios.Rows.Refresh(RefreshRow.ReloadData)
      End If
   End Sub

   Private Sub QuitarUsuario()
      Dim objUsr = ugUsuariosAsignados.FilaSeleccionada(Of Entidades.CRMTipoNovedadObjetivoUsuario)()
      If objUsr IsNot Nothing Then
         Dim usr = New Entidades.Usuario()
         With usr
            .Id = objUsr.IdUsuario
            .Nombre = objUsr.NombreUsuario
         End With
         _usuario.Add(usr)
         Objetivo.Usuarios.Remove(objUsr)
         ugUsuariosAsignados.Rows.Refresh(RefreshRow.ReloadData)
         ugUsuarios.Rows.Refresh(RefreshRow.ReloadData)
      End If
   End Sub
#End Region

End Class