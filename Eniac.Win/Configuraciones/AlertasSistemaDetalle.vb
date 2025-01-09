Public Class AlertasSistemaDetalle
   Private _publicos As Publicos
   Private _usuarios As List(Of Entidades.Usuario)
   Private _roles As List(Of Entidades.Rol)

   Private ReadOnly Property AlertaSistema As Entidades.SistemaE.AlertaSistema
      Get
         Return DirectCast(_entidad, Entidades.SistemaE.AlertaSistema)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.SistemaE.AlertaSistema)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _usuarios = New Reglas.Usuarios().GetActivos(toLowerId:=True, usuarioActual:=String.Empty)
            _roles = New Reglas.Roles().GetTodos()

            _publicos.CargaComboDesdeEnum(cmbCondicionCount, GetType(Entidades.SistemaE.CondicionesCountAlerta))
            _publicos.CargaComboDesdeEnum(cmbPermisosCondicion, GetType(Entidades.SistemaE.CondicionesPermisoAlerta))

            tbcDetalle.TabPages.OfType(Of TabPage).ToList().ForEach(Sub(tbp) tbcDetalle.SelectedTab = tbp)
            tbcDetalle.SelectedTab = tbpConsultaAlerta

            BindearControles(_entidad) ', _liSources)

            If StateForm = Eniac.Win.StateForm.Insertar Then
               txtIdAlertaSistema.SetValor(GetProximoNumero())
            Else
               If Not String.IsNullOrWhiteSpace(bscCodigoFuncion.Text) Then
                  bscCodigoFuncion.PresionarBoton()
               End If
            End If

            txtConsultaAlerta.Text = AlertaSistema.ConsultaAlerta

            bdsAlertasCondiciones.DataSource = AlertaSistema.Condiciones
            bdsAlertasRoles.DataSource = AlertaSistema.Roles
            bdsAlertasUsuarios.DataSource = AlertaSistema.Usuarios
            bdsAlertasPermisos.DataSource = AlertaSistema.Permisos

            MostrarRoles()
            MostrarUsuarios()
            MostrarVariablesMensajeCount()
            MostrarVariablesConsulta()

            ugUsuarios.AgregarFiltroEnLinea({"Nombre"})
            ugAlertaUsuarios.AgregarFiltroEnLinea({"NombreUsuario"})
            ugRoles.AgregarFiltroEnLinea({"Nombre"})
            ugAlertaRoles.AgregarFiltroEnLinea({"NombreRol"})

            RefrescarCondicion()
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         If tbcDetalle.SelectedTab.Equals(tbpConsultaAlerta) Then
            btnEjecutar.PerformClick()
         End If
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Sistema.AlertasSistema()
   End Function
   Private Function Regla() As Reglas.Sistema.AlertasSistema
      Return DirectCast(GetReglas(), Reglas.Sistema.AlertasSistema)
   End Function
   Protected Overrides Sub Aceptar()
      AlertaSistema.IdFuncionClick = bscCodigoFuncion.Text
      AlertaSistema.ConsultaAlerta = txtConsultaAlerta.Text

      If chbUtilizaConsultaGenerica.Checked Then
         AlertaSistema.IdFuncionClick = String.Empty
         AlertaSistema.ParametrosPantalla = String.Empty
      End If

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"
#Region "Función"
   Private Sub bscCodigoFuncion_BuscadorClick() Handles bscCodigoFuncion.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaFunciones2(bscCodigoFuncion)
            bscCodigoFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(bscCodigoFuncion.Text, String.Empty)
         End Sub)
   End Sub
   Private Sub bscNombreFuncion_BuscadorClick() Handles bscNombreFuncion.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaFunciones2(bscNombreFuncion)
            bscNombreFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, bscNombreFuncion.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoFuncion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoFuncion.BuscadorSeleccion, bscNombreFuncion.BuscadorSeleccion
      TryCatched(Sub() CargarDatosFuncion(e.FilaDevuelta))
   End Sub

   Private Sub CargarDatosFuncion(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreFuncion.Text = dr.Cells("Nombre").Value.ToString()
         bscCodigoFuncion.Text = dr.Cells("Id").Value.ToString().Trim()
      End If
   End Sub
#End Region

   Private Sub chbUtilizaConsultaGenerica_CheckedChanged(sender As Object, e As EventArgs) Handles chbUtilizaConsultaGenerica.CheckedChanged
      TryCatched(
      Sub()
         bscCodigoFuncion.Permitido = Not chbUtilizaConsultaGenerica.Checked
         bscNombreFuncion.Permitido = Not chbUtilizaConsultaGenerica.Checked
         txtParametrosPantalla.Enabled = Not chbUtilizaConsultaGenerica.Checked
         'If chbUtilizaConsultaGenerica.Checked Then
         '   bscCodigoFuncion.Text = String.Empty
         '   bscNombreFuncion.Text = String.Empty
         '   txtParametrosPantalla.Text = String.Empty
         'End If
      End Sub)
   End Sub

   Private Sub btnAyudaParametros_Click(sender As Object, e As EventArgs) Handles btnAyudaParametros.Click
      Dim mensajeTooltip As String = String.Empty
      TryCatched(
         Sub()
            Dim fnc = New Reglas.Funciones().GetUna(bscCodigoFuncion.Text, cargaDocumentos:=False, cargaVinculadas:=False)
            Dim nombreClase = fnc.Archivo + "." + fnc.Pantalla
            Dim nombreAssembly = GetNombreAssembly(fnc.Archivo)

            Dim obj = Activator.CreateInstanceFrom(nombreAssembly, nombreClase)
            Dim frm = obj.Unwrap()
            If TypeOf (frm) Is IConParametros Then
               mensajeTooltip = DirectCast(frm, IConParametros).GetParametrosDisponibles()
            Else
               mensajeTooltip = String.Format("La pantalla {0} no recibe Parámetros", fnc.Pantalla)
            End If
         End Sub,
         onErrorAction:=
         Sub(owner, ex)
            mensajeTooltip = String.Format("Error cargando formulario: {0}", ex.Message)
         End Sub,
         onFinallyAction:=
         Sub(owner)
            If Not String.IsNullOrWhiteSpace(mensajeTooltip) Then
               Using frm = New VisorTexto()
                  frm.ShowDialog(Me, String.Format("Parametros para la función {0}", bscNombreFuncion.Text), mensajeTooltip)
               End Using
            End If
         End Sub)
   End Sub
   Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
      TryCatched(Sub() EjecutarConsulta())
   End Sub

   Private Sub ugVariablesConsulta_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugVariablesConsulta.DoubleClickCell
      TryCatched(Sub() AgregaVariableConsulta(e))
   End Sub

#End Region

#Region "Métodos"
   Private Function GetProximoNumero() As Integer
      Return New Reglas.Sistema.AlertasSistema().GetCodigoMaximo() + 1
   End Function
   Private Function GetNombreAssembly(clase As String) As String
      Dim nom = Application.StartupPath + "\" + clase
      Dim archExe = String.Format("{0}.exe", nom)
      Return If(IO.File.Exists(archExe), archExe, String.Format("{0}.dll", nom))
   End Function
   Private Sub EjecutarConsulta()
      Dim variables As Reglas.Sistema.AlertasSistema.VariablesAlerta = Nothing
      If txtConsultaAlerta.Text.Contains("@@") Then
         Using frm = New AlertasSistemaDetalleConfirmarEjecucion()
            If frm.ShowDialog(Me) = DialogResult.Cancel Then
               Exit Sub
            Else
               variables = frm.Variables
            End If
         End Using
      End If
      Dim r = New Reglas.Sistema.AlertasSistema()
      Using dt = r.EjecutaConsulta(txtConsultaAlerta.Text, variables)
         Using frm = New ConsultaGenerica(dt)
            frm.ShowDialog()
         End Using
      End Using
   End Sub
   Private Sub AgregaVariableConsulta(e As DoubleClickCellEventArgs)
      Dim dr = e.Cell.Row.FilaSeleccionada(Of Reglas.Sistema.AlertasSistema.VariableAlerta)
      If dr IsNot Nothing Then
         txtConsultaAlerta.Paste(dr.Variable)
      End If
   End Sub
   Private Sub MostrarVariablesMensajeCount()
      ugVariablesMensajeCount.DataSource = New Reglas.Sistema.AlertasSistema.VariablesAlerta().Inicializar(Reglas.Sistema.AlertasSistema.DestinoListaVariables.Mensaje)
      ugVariablesMensajeCount.DisplayLayout.PerformAutoResizeColumns(sizeHiddenColumns:=False, PerformAutoSizeType.AllRowsInBand)
   End Sub
   Private Sub MostrarVariablesConsulta()
      ugVariablesConsulta.DataSource = New Reglas.Sistema.AlertasSistema.VariablesAlerta().Inicializar(Reglas.Sistema.AlertasSistema.DestinoListaVariables.Consulta)
      ugVariablesConsulta.DisplayLayout.PerformAutoResizeColumns(sizeHiddenColumns:=False, PerformAutoSizeType.AllRowsInBand)
   End Sub
#End Region

#Region "Solapa Condiciones"
   Private Sub btnRefrescarCondicion_Click(sender As Object, e As EventArgs) Handles btnRefrescarCondicion.Click
      TryCatched(Sub() RefrescarCondicion())
   End Sub
   Private Sub btnInsertarCondicion_Click(sender As Object, e As EventArgs) Handles btnInsertarCondicion.Click
      TryCatched(Sub() If ValidaCondicion() Then InsertaCondicion())
   End Sub
   Private Sub btnEliminarCondicion_Click(sender As Object, e As EventArgs) Handles btnEliminarCondicion.Click
      TryCatched(Sub() EliminarCondicion())
   End Sub
   Private Sub ugAlertaCondicion_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugAlertaCondicion.DoubleClickCell
      TryCatched(Sub() EditarCondicion())
   End Sub
   Private Sub ugVariablesMensajeCount_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugVariablesMensajeCount.DoubleClickCell
      TryCatched(Sub() AgregaVariableMensajeCount(e))
   End Sub
   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColorCondicionCount.Click
      TryCatched(Sub() CambiaColor())
   End Sub


   Private Function ValidaCondicion() As Boolean
      If txtValorCondicionCount.ValorNumericoPorDefecto(0I) < 0 Then
         Throw New Exception("El valor debe ser positivo o cero")
      End If
      Return True
   End Function
   Private Sub RefrescarCondicion()
      cmbCondicionCount.SelectedValue = Entidades.SistemaE.CondicionesCountAlerta.Diferente
      txtValorCondicionCount.SetValor(0I)
      txtMensajeCount.Clear()
      txtColorCondicionCount.BackColor = Nothing
      txtOrdenPrioridad.SetValor(200I)
      chbMostrarPopUp.Checked = False
      txtParametrosAdicionalesPantalla.Clear()
      cmbCondicionCount.Focus()
   End Sub
   Private Sub InsertaCondicion()
      Dim dr = New Entidades.SistemaE.AlertaSistemaCondicion With
         {
            .CondicionCount = cmbCondicionCount.ValorSeleccionado(Of Entidades.SistemaE.CondicionesCountAlerta)(),
            .ValorCondicionCount = txtValorCondicionCount.ValorNumericoPorDefecto(0I),
            .MensajeCount = txtMensajeCount.Text,
            .ColorCondicionCount = txtColorCondicionCount.BackColor,
            .OrdenPrioridad = txtOrdenPrioridad.ValorNumericoPorDefecto(0I),
            .MostrarPopUp = chbMostrarPopUp.Checked,
            .ParametrosAdicionalesPantalla = txtParametrosAdicionalesPantalla.Text
         }
      AlertaSistema.Condiciones.Add(dr)
      ugAlertaCondicion.Rows.Refresh(RefreshRow.ReloadData)
      RefrescarCondicion()
   End Sub
   Private Sub EditarCondicion()
      Dim dr = ugAlertaCondicion.FilaSeleccionada(Of Entidades.SistemaE.AlertaSistemaCondicion)()
      If dr IsNot Nothing Then

         cmbCondicionCount.SelectedValue = dr.CondicionCount
         txtValorCondicionCount.SetValor(dr.ValorCondicionCount)
         txtMensajeCount.Text = dr.MensajeCount
         txtColorCondicionCount.BackColor = dr.ColorCondicionCount
         txtOrdenPrioridad.SetValor(dr.OrdenPrioridad)
         chbMostrarPopUp.Checked = dr.MostrarPopUp
         txtParametrosAdicionalesPantalla.Text = dr.ParametrosAdicionalesPantalla

         AlertaSistema.Condiciones.Remove(dr)
         ugAlertaCondicion.Rows.Refresh(RefreshRow.ReloadData)
         cmbCondicionCount.Focus()
      End If
   End Sub
   Private Sub EliminarCondicion()
      Dim dr = ugAlertaCondicion.FilaSeleccionada(Of Entidades.SistemaE.AlertaSistemaCondicion)()
      If dr IsNot Nothing Then
         If ShowPregunta(String.Format("¿Desea eliminar la condición de {0} {1}?", cmbCondicionCount.Text, txtValorCondicionCount.Text)) = DialogResult.Yes Then
            AlertaSistema.Condiciones.Remove(dr)
            ugAlertaCondicion.Rows.Refresh(RefreshRow.ReloadData)
            cmbCondicionCount.Focus()
         End If
      End If
   End Sub
   Private Sub CambiaColor()
      cdColor.Color = txtColorCondicionCount.BackColor
      If cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
         txtColorCondicionCount.BackColor = cdColor.Color
      End If
   End Sub
   Private Sub AgregaVariableMensajeCount(e As DoubleClickCellEventArgs)
      Dim dr = e.Cell.Row.FilaSeleccionada(Of Reglas.Sistema.AlertasSistema.VariableAlerta)
      If dr IsNot Nothing Then
         txtMensajeCount.Paste(dr.Variable)
      End If
   End Sub

#End Region

#Region "Solapa Permisos"
   Private Sub bscCodigoFuncionPermiso_BuscadorClick() Handles bscCodigoFuncionPermiso.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaFunciones2(bscCodigoFuncionPermiso)
            bscCodigoFuncionPermiso.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(bscCodigoFuncionPermiso.Text, String.Empty)
         End Sub)
   End Sub
   Private Sub bscNombreFuncionPermiso_BuscadorClick() Handles bscNombreFuncionPermiso.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaFunciones2(bscNombreFuncionPermiso)
            bscNombreFuncionPermiso.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, bscNombreFuncionPermiso.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoFuncionPermiso_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoFuncionPermiso.BuscadorSeleccion, bscNombreFuncionPermiso.BuscadorSeleccion
      TryCatched(Sub() CargarDatosFuncionPermiso(e.FilaDevuelta))
   End Sub
   Private Sub btnEliminarFuncionPermiso_Click(sender As Object, e As EventArgs) Handles btnEliminarFuncionPermiso.Click
      TryCatched(Sub() QuitarFuncionPermisos())
   End Sub

   Private Sub CargarDatosFuncionPermiso(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreFuncionPermiso.Text = dr.Cells("Nombre").Value.ToString()
         bscCodigoFuncionPermiso.Text = dr.Cells("Id").Value.ToString().Trim()

         Dim aPermiso = New Entidades.SistemaE.AlertaSistemaPermiso() With
            {
               .IdFuncion = dr.Cells("Id").Value.ToString(),
               .NombreFuncion = dr.Cells("Nombre").Value.ToString(),
               .IdFuncionPadre = dr.Cells("IdPadre").Value.ToString(),
               .NombreFuncionPadre = dr.Cells("NombrePadre").Value.ToString(),
               .Posicion = dr.Cells("Posicion").Value.ToString().ToInt32().IfNull(),
               .Pantalla = dr.Cells("Pantalla").Value.ToString(),
               .Archivo = dr.Cells("Archivo").Value.ToString()
            }
         AlertaSistema.Permisos.Add(aPermiso)
         bdsAlertasPermisos.ResetBindings(metadataChanged:=False)

         bscNombreFuncionPermiso.Text = String.Empty
         bscCodigoFuncionPermiso.Text = String.Empty
      End If
   End Sub
   Private Sub QuitarFuncionPermisos()
      Dim dr = ugAlertaPermisos.FilaSeleccionada(Of Entidades.SistemaE.AlertaSistemaPermiso)
      If dr IsNot Nothing Then
         AlertaSistema.Permisos.Remove(dr)
         bdsAlertasPermisos.ResetBindings(metadataChanged:=False)
      End If
   End Sub

#End Region

#Region "Solapa Usuarios/Roles"
   Private Sub btnAgregarUsuario_Click(sender As Object, e As EventArgs) Handles btnAgregarUsuario.Click
      TryCatched(Sub() AgregarUsuariosSeleccionados())
   End Sub
   Private Sub btnQuitarUsusario_Click(sender As Object, e As EventArgs) Handles btnQuitarUsusario.Click
      TryCatched(Sub() QuitarUsuariosSeleccionados())
   End Sub
   Private Sub btnAgregarRol_Click(sender As Object, e As EventArgs) Handles btnAgregarRol.Click
      TryCatched(Sub() AgregarRolesSeleccionados())
   End Sub
   Private Sub btnQuitarRol_Click(sender As Object, e As EventArgs) Handles btnQuitarRol.Click
      TryCatched(Sub() QuitarRolesSeleccionados())
   End Sub
   Private Sub ugUsuarios_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugUsuarios.DoubleClickCell
      TryCatched(Sub() AgregarUsuariosSeleccionados())
   End Sub
   Private Sub ugAlertaUsuarios_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugAlertaUsuarios.DoubleClickCell
      TryCatched(Sub() QuitarUsuariosSeleccionados())
   End Sub
   Private Sub ugRoles_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugRoles.DoubleClickCell
      TryCatched(Sub() AgregarRolesSeleccionados())
   End Sub
   Private Sub ugAlertaRoles_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugAlertaRoles.DoubleClickCell
      TryCatched(Sub() QuitarRolesSeleccionados())
   End Sub

   Private Sub AgregarUsuariosSeleccionados()
      Dim rows = If(ugUsuarios.Selected.Rows.Count = 0, If(ugUsuarios.ActiveRow IsNot Nothing, {ugUsuarios.ActiveRow}, Nothing), ugUsuarios.Selected.Rows.OfType(Of UltraGridRow))
      If rows IsNot Nothing Then
         rows.ToList().ForEach(
            Sub(ur)
               Dim dr = ur.FilaSeleccionada(Of Entidades.Usuario)
               Dim aUsr = New Entidades.SistemaE.AlertaSistemaUsuario() With
                           {
                              .IdUsuario = dr.Id,
                              .NombreUsuario = dr.Nombre
                           }
               AlertaSistema.Usuarios.Add(aUsr)
            End Sub)
         ActualizarGrillasUsuarioRoles()
      End If
   End Sub
   Public Sub QuitarUsuariosSeleccionados()
      Dim rows = If(ugAlertaUsuarios.Selected.Rows.Count = 0, If(ugAlertaUsuarios.ActiveRow IsNot Nothing, {ugAlertaUsuarios.ActiveRow}, Nothing), ugAlertaUsuarios.Selected.Rows.OfType(Of UltraGridRow))
      If rows IsNot Nothing Then
         rows.ToList().ForEach(
            Sub(ur)
               Dim dr = ur.FilaSeleccionada(Of Entidades.SistemaE.AlertaSistemaUsuario)
               AlertaSistema.Usuarios.Remove(dr)
            End Sub)
         ActualizarGrillasUsuarioRoles()
      End If
   End Sub
   Private Sub AgregarRolesSeleccionados()
      Dim rows = If(ugRoles.Selected.Rows.Count = 0, If(ugRoles.ActiveRow IsNot Nothing, {ugRoles.ActiveRow}, Nothing), ugRoles.Selected.Rows.OfType(Of UltraGridRow))
      If rows IsNot Nothing Then
         rows.ToList().ForEach(
            Sub(ur)
               Dim dr = ur.FilaSeleccionada(Of Entidades.Rol)
               Dim aRol = New Entidades.SistemaE.AlertaSistemaRol() With
                           {
                              .IdRol = dr.Id,
                              .NombreRol = dr.Nombre
                           }
               AlertaSistema.Roles.Add(aRol)
            End Sub)
         ActualizarGrillasUsuarioRoles()
      End If
   End Sub
   Public Sub QuitarRolesSeleccionados()
      Dim rows = If(ugAlertaRoles.Selected.Rows.Count = 0, If(ugAlertaRoles.ActiveRow IsNot Nothing, {ugAlertaRoles.ActiveRow}, Nothing), ugAlertaRoles.Selected.Rows.OfType(Of UltraGridRow))
      If rows IsNot Nothing Then
         rows.ToList().ForEach(
            Sub(ur)
               Dim dr = ur.FilaSeleccionada(Of Entidades.SistemaE.AlertaSistemaRol)
               AlertaSistema.Roles.Remove(dr)
            End Sub)
         ActualizarGrillasUsuarioRoles()
      End If
   End Sub

   Private Sub ActualizarGrillasUsuarioRoles()
      bdsAlertasRoles.ResetBindings(False)
      bdsAlertasUsuarios.ResetBindings(False)
      ugAlertaUsuarios.Rows.Refresh(RefreshRow.FireInitializeRow)
      ugAlertaRoles.Rows.Refresh(RefreshRow.FireInitializeRow)
      MostrarRoles()
      MostrarUsuarios()
   End Sub

   Private Sub MostrarRoles()
      bdsRoles.DataSource = _roles.Where(Function(r) Not AlertaSistema.Roles.ConvertAll(Function(ar) ar.IdRol).Contains(r.Id))
   End Sub
   Private Sub MostrarUsuarios()
      bdsUsuarios.DataSource = _usuarios.Where(Function(u) Not AlertaSistema.Usuarios.ConvertAll(Function(au) au.IdUsuario).Contains(u.Id))
   End Sub

#End Region

End Class