Public Class UsuariosRoles

#Region "Campos"
   Private _titUsuarios As Dictionary(Of String, String)
   Private _titUsuariosRoles As Dictionary(Of String, String)
   Private _publicos As Publicos
   Private _sucursalEstoyEn As Entidades.Sucursal

   Private _modificado As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(Sub() _sucursalEstoyEn = New Reglas.Sucursales().EstoyEn(incluirLogo:=False))
      TryCatched(Sub() InicializaTit())
      TryCatched(Sub() CargaPantalla())
      TryCatched(Sub() InicializaTotalesFiltrosGrillas())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Metodos"
   Private Sub InicializaTit()
      _titUsuarios = GetColumnasVisiblesGrilla(ugUsuarios)
      _titUsuariosRoles = GetColumnasVisiblesGrilla(ugUsuariosRoles)
   End Sub
   Private Sub InicializaTotalesFiltrosGrillas()
      ugUsuarios.AgregarFiltroEnLinea({"Id", "Nombre"})
      ugUsuariosRoles.AgregarFiltroEnLinea({"IdUsuario", "NombreUsuario"})

      ugUsuarios.AgregarTotalesContar({"Id"})
      ugUsuariosRoles.AgregarTotalesContar({"IdUsuario"})
   End Sub
   Private Sub CargaPantalla()
      _publicos.CargaComboSucursales(cmbSucursales, seleccionMultiple:=False, seleccionTodos:=False, IdFuncion)
      cmbSucursales.SelectedValue = _sucursalEstoyEn.Id

      _publicos.CargaComboRoles(cmbRoles)
      If cmbRoles.Items.Count > 0 Then
         cmbRoles.SelectedIndex = 0
      End If

      Dim rUsuario = New Reglas.Usuarios()
      ugUsuarios.DataSource = rUsuario.GetTodos(toLowerId:=True, activo:=True)
      AjustarColumnasGrilla(ugUsuarios, _titUsuarios)

      CargarUsuariosRoles()

      CambiarModificado(modificado:=False)
   End Sub

   Private Sub CargarUsuariosRoles()
      Dim rUsuariosRoles = New Reglas.UsuariosRoles()
      ugUsuariosRoles.DataSource = rUsuariosRoles.GetTodosPorRol(cmbRoles.ValorSeleccionado(Of String),
                                                                 cmbSucursales.ValorSeleccionado(Of Integer))
      AjustarColumnasGrilla(ugUsuariosRoles, _titUsuariosRoles)
   End Sub

   Private Sub CambiarModificado(modificado As Boolean)
      _modificado = modificado
      HabilitaControlesSegunModificado()
   End Sub
   Private Sub HabilitaControlesSegunModificado()
      cmbSucursales.Enabled = Not _modificado
      cmbRoles.Enabled = Not _modificado

      btnAceptar.Enabled = _modificado
   End Sub

   Private Sub Agregar()
      For Each u In ugUsuarios.SelectIfEmpty().FilasSeleccionadas(Of Entidades.Usuario)
         Dim usuariosRoles = ugUsuariosRoles.DataSource(Of List(Of Entidades.UsuarioRol))
         If Not usuariosRoles.Any(Function(ur) ur.IdUsuario = u.Id) Then
            usuariosRoles.Add(New Entidades.UsuarioRol With
                              {
                                 .IdUsuario = u.Id,
                                 .NombreUsuario = u.Nombre
                              })
         End If
      Next
      ugUsuariosRoles.Rows.Refresh(RefreshRow.FireInitializeRow)
      CambiarModificado(modificado:=True)
   End Sub
   Private Sub Quitar()
      For Each ur In ugUsuariosRoles.SelectIfEmpty().FilasSeleccionadas(Of Entidades.UsuarioRol)
         Dim usuariosRoles = ugUsuariosRoles.DataSource(Of List(Of Entidades.UsuarioRol))
         usuariosRoles.Remove(ur)
      Next
      ugUsuariosRoles.Rows.Refresh(RefreshRow.FireInitializeRow)
      CambiarModificado(modificado:=True)
   End Sub

   Private Sub Guardar()
      Dim oUsuRol = New Reglas.UsuariosRoles()
      oUsuRol.Actualizar(cmbSucursales.ValorSeleccionado(Of Integer), cmbRoles.ValorSeleccionado(Of String),
                         ugUsuariosRoles.DataSource(Of List(Of Entidades.UsuarioRol)))

      ShowMessage("Los roles han sido modificados con exito!!")
      CargarUsuariosRoles()
      CambiarModificado(modificado:=False)

   End Sub

   Private Function CheckModificable() As Boolean
      If _modificado Then
         If ShowPregunta("Hay cambios sin Guardar. Si continua se perderan los cambios sin guardar. ¿Desea continuar?") = DialogResult.No Then
            Return False
         End If
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      TryCatched(Sub() Agregar())
   End Sub
   Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
      TryCatched(Sub() Quitar())
   End Sub
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Guardar())
   End Sub
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() If CheckModificable() Then CargaPantalla())
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() If CheckModificable() Then Close())
   End Sub
   Private Sub cmbSucursales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursales.SelectedIndexChanged
      TryCatched(Sub() CargarUsuariosRoles())
   End Sub
   Private Sub cmbRoles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRoles.SelectedIndexChanged
      TryCatched(Sub() CargarUsuariosRoles())
   End Sub

#End Region

End Class