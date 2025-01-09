Imports ColumnasAgenda = Eniac.Entidades.SistemaE.MensajeMailAgenda.Columnas
Public Class MensajeMailAgenda
#Region "Campos/Propiedades/Constantes"
   Private Const tbpUsuariosKey As String = "tbpUsuarios"
   Private Const tbpClientesKey As String = "tbpClientes"
   Private Const tbpProveedoresKey As String = "tbpProveedores"
   Private Const SeparadorCorreosTrim As Char = ";"c
   Private Const SeparadorCorreos As String = "; "

   Private _publicos As Publicos
   Private _ultimoTxt As Controles.TextBox
   Private _cargando As Boolean
   Private _botonActivoFont As Font
   Private _botonInactivoFont As Font
   Private _dicBotonTextbox As Dictionary(Of Controles.TextBox, Controles.Button)

   Private _dtUsuarios As DataTable
   Private _dtClientes As DataTable
   Private _dtProveedores As DataTable

   Public ReadOnly Property Destinatarios As String
   Public ReadOnly Property DestinatariosCC As String
   Public ReadOnly Property DestinatariosCCO As String
#End Region

#Region "Overrides/Overloads"
   Public Overloads Function ShowDialog(owner As IWin32Window, destinatarios As String, destinatariosCC As String, destinatariosCCO As String) As DialogResult
      _Destinatarios = destinatarios
      _DestinatariosCC = destinatariosCC
      _DestinatariosCCO = destinatariosCCO

      txtDestinatarios.Text = destinatarios
      txtDestinatariosCC.Text = destinatariosCC
      txtDestinatariosCCO.Text = destinatariosCCO

      Return ShowDialog(owner)
   End Function
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _cargando = True
         _publicos = New Publicos()
         _publicos.CargaComboDesdeEnum(cmbConfiguracionMail, Entidades.Cliente.ConfiguracionMail.Principal)

         _botonInactivoFont = btnAgregarPara.Font
         _botonActivoFont = New Font(btnAgregarPara.Font, FontStyle.Bold)
         _dicBotonTextbox = New Dictionary(Of Controles.TextBox, Controles.Button) From
                                          {{txtDestinatarios, btnAgregarPara}, {txtDestinatariosCC, btnAgregarCC}, {txtDestinatariosCCO, btnAgregarCCO}}

         tbcAgenda.SelectTab(tbpClientesKey)
         tbcAgenda.SelectTab(tbpProveedoresKey)
         tbcAgenda.SelectTab(tbpUsuariosKey)

         Dim ds = New Reglas.Sistema.MensajeMailAgenda().GetAgendaCompleta()

         _dtUsuarios = ds.Tables(Reglas.Sistema.MensajeMailAgenda.UsuariosTableName)
         _dtClientes = ds.Tables(Reglas.Sistema.MensajeMailAgenda.ClientesTableName)
         _dtProveedores = ds.Tables(Reglas.Sistema.MensajeMailAgenda.ProveedoresTableName)

         SetUsuariosDataSource()
         SetClientesDataSource()
         SetProveedoresDataSource()

         If Not _dtUsuarios.Any() Then
            tbcAgenda.Tabs(tbpUsuariosKey).Visible = False
         End If
         If Not _dtClientes.Any() Then
            tbcAgenda.Tabs(tbpClientesKey).Visible = False
         End If
         If Not _dtProveedores.Any() Then
            tbcAgenda.Tabs(tbpProveedoresKey).Visible = False
         End If

         ugUsuarios.AgregarFiltroEnLinea({ColumnasAgenda.NombreUsuario.ToString(), ColumnasAgenda.MailDireccion.ToString()})
         ugClientes.AgregarFiltroEnLinea({ColumnasAgenda.NombreCliente.ToString(),
                                          ColumnasAgenda.CorreoPrincipal.ToString(), ColumnasAgenda.CorreoAdministrativo.ToString(),
                                          ColumnasAgenda.CorreoAdminyPrincipal.ToString(), ColumnasAgenda.CorreoAdminoPrincipal.ToString()})
         ugProveedores.AgregarFiltroEnLinea({ColumnasAgenda.NombreProveedor.ToString(),
                                             ColumnasAgenda.CorreoPrincipal.ToString(), ColumnasAgenda.CorreoAdministrativo.ToString(),
                                             ColumnasAgenda.CorreoAdminyPrincipal.ToString(), ColumnasAgenda.CorreoAdminoPrincipal.ToString()})

         SetUltimoTxt(txtDestinatarios)
         txtDestinatarios.Focus()
      End Sub,
      onFinallyAction:=Sub(owner) _cargando = False)
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(Sub() cmbConfiguracionMail.SelectedValue = Reglas.Publicos.ConfiguraciónMail.StringToEnum(Entidades.Cliente.ConfiguracionMail.Principal))
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.F9 Then
         tbcAgenda.SelectTab(tbpUsuariosKey)
      ElseIf keyData = Keys.F10 Then
         tbcAgenda.SelectTab(tbpClientesKey)
      ElseIf keyData = Keys.F11 Then
         tbcAgenda.SelectTab(tbpProveedoresKey)

      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      ElseIf keyData = (Keys.Add Or Keys.Control) Or (keyData = Keys.Enter And (ugUsuarios.Focused Or ugClientes.Focused Or ugProveedores.Focused)) Then
         AgregarDireccion(_ultimoTxt)
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub tbcAgenda_SelectedTabChanged(sender As Object, e As UltraWinTabControl.SelectedTabChangedEventArgs) Handles tbcAgenda.SelectedTabChanged
      TryCatched(
      Sub()
         cmbConfiguracionMail.Visible = e.Tab.Key <> tbpUsuariosKey
         e.Tab.TabPage.Controls(0).Focus()
      End Sub)
   End Sub
   Private Sub cmbConfiguracionMail_VisibleChanged(sender As Object, e As EventArgs) Handles cmbConfiguracionMail.VisibleChanged
      TryCatched(Sub() lblOrigenCorreos.Visible = cmbConfiguracionMail.Visible)
   End Sub
   Private Sub cmbConfiguracionMail_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbConfiguracionMail.SelectedValueChanged
      TryCatched(
      Sub()
         If _cargando Then Exit Sub
         Dim selec = cmbConfiguracionMail.ValorSeleccionado(Of Entidades.Cliente.ConfiguracionMail)
         ugClientes.DisplayLayout.Bands(0).Columns(ColumnasAgenda.CorreoPrincipal.ToString()).Hidden = Not selec = Entidades.Cliente.ConfiguracionMail.Principal
         ugClientes.DisplayLayout.Bands(0).Columns(ColumnasAgenda.CorreoAdministrativo.ToString()).Hidden = Not selec = Entidades.Cliente.ConfiguracionMail.Administrativo
         ugClientes.DisplayLayout.Bands(0).Columns(ColumnasAgenda.CorreoAdminyPrincipal.ToString()).Hidden = Not selec = Entidades.Cliente.ConfiguracionMail.AdminyPrincipal
         ugClientes.DisplayLayout.Bands(0).Columns(ColumnasAgenda.CorreoAdminoPrincipal.ToString()).Hidden = Not selec = Entidades.Cliente.ConfiguracionMail.AdminoPrincipal

         ugProveedores.DisplayLayout.Bands(0).Columns(ColumnasAgenda.CorreoPrincipal.ToString()).Hidden = Not selec = Entidades.Cliente.ConfiguracionMail.Principal
         ugProveedores.DisplayLayout.Bands(0).Columns(ColumnasAgenda.CorreoAdministrativo.ToString()).Hidden = Not selec = Entidades.Cliente.ConfiguracionMail.Administrativo
         ugProveedores.DisplayLayout.Bands(0).Columns(ColumnasAgenda.CorreoAdminyPrincipal.ToString()).Hidden = Not selec = Entidades.Cliente.ConfiguracionMail.AdminyPrincipal
         ugProveedores.DisplayLayout.Bands(0).Columns(ColumnasAgenda.CorreoAdminoPrincipal.ToString()).Hidden = Not selec = Entidades.Cliente.ConfiguracionMail.AdminoPrincipal

         SetClientesDataSource()
         SetProveedoresDataSource()
      End Sub)
   End Sub

   Private Sub txtDestinatarios_Enter(sender As Object, e As EventArgs) Handles txtDestinatarios.Enter, txtDestinatariosCC.Enter, txtDestinatariosCCO.Enter
      TryCatched(Sub() If TypeOf (sender) Is Controles.TextBox Then SetUltimoTxt(DirectCast(sender, Controles.TextBox)))
   End Sub
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub
   Private Sub ug_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugUsuarios.DoubleClickCell, ugClientes.DoubleClickCell, ugProveedores.DoubleClickCell
      TryCatched(Sub() AgregarDireccion(_ultimoTxt))
   End Sub
   Private Sub btnAgregarPara_Click(sender As Object, e As EventArgs) Handles btnAgregarPara.Click
      TryCatched(Sub() AgregarDireccion(txtDestinatarios))
   End Sub
   Private Sub btnAgregarCC_Click(sender As Object, e As EventArgs) Handles btnAgregarCC.Click
      TryCatched(Sub() AgregarDireccion(txtDestinatariosCC))
   End Sub
   Private Sub btnAgregarCCO_Click(sender As Object, e As EventArgs) Handles btnAgregarCCO.Click
      TryCatched(Sub() AgregarDireccion(txtDestinatariosCCO))
   End Sub
#End Region

#Region "Métodos"
   Private Sub Aceptar()
      _Destinatarios = txtDestinatarios.Text
      _DestinatariosCC = txtDestinatariosCC.Text
      _DestinatariosCCO = txtDestinatariosCCO.Text

      Close(DialogResult.OK)
   End Sub

   Private Sub AgregarDireccion(txt As Controles.TextBox)
      If txt Is Nothing Then Exit Sub
      Dim drs = If(tbcAgenda.SelectedTab.Key = tbpUsuariosKey, ugUsuarios.FilasSeleccionadas(Of DataRow),
                If(tbcAgenda.SelectedTab.Key = tbpClientesKey, ugClientes.FilasSeleccionadas(Of DataRow),
                If(tbcAgenda.SelectedTab.Key = tbpProveedoresKey, ugProveedores.FilasSeleccionadas(Of DataRow), {})))
      AgregarDireccion(drs, txt)
   End Sub
   Private Sub AgregarDireccion(drs As IEnumerable(Of DataRow), txt As Controles.TextBox)
      If txt Is Nothing Then Exit Sub
      For Each dr In drs
         AgregarDireccion(dr, txt)
      Next
   End Sub
   Private Sub AgregarDireccion(dr As DataRow, txt As Controles.TextBox)
      If txt Is Nothing Then Exit Sub
      If dr Is Nothing Then Exit Sub
      If Not String.IsNullOrWhiteSpace(txt.Text) Then
         txt.AppendText(SeparadorCorreos)
      End If
      If dr.Table.Columns.Contains(ColumnasAgenda.MailDireccion.ToString()) Then
         txt.AppendText(dr.Field(Of String)(ColumnasAgenda.MailDireccion.ToString()).IfNull().Trim().Trim(SeparadorCorreosTrim).Trim())
      Else
         Dim columnName As String = GetColumnName()
         If Not String.IsNullOrWhiteSpace(columnName) Then
            txt.AppendText(dr.Field(Of String)(columnName).IfNull().Trim().Trim(SeparadorCorreosTrim).Trim())
         End If
      End If

      SetUltimoTxt(txt)
   End Sub

   Private Sub SetUltimoTxt(txt As Controles.TextBox)
      btnAgregarPara.Font = _botonInactivoFont
      btnAgregarCC.Font = _botonInactivoFont
      btnAgregarCCO.Font = _botonInactivoFont

      btnAgregarPara.BackColor = SystemColors.ControlLight
      btnAgregarCC.BackColor = SystemColors.ControlLight
      btnAgregarCCO.BackColor = SystemColors.ControlLight
      btnAgregarPara.ForeColor = Nothing
      btnAgregarCC.ForeColor = Nothing
      btnAgregarCCO.ForeColor = Nothing

      _ultimoTxt = txt

      If _dicBotonTextbox.ContainsKey(txt) Then
         _dicBotonTextbox(txt).Font = _botonActivoFont
         _dicBotonTextbox(txt).BackColor = SystemColors.Highlight
         _dicBotonTextbox(txt).ForeColor = SystemColors.HighlightText
      End If
   End Sub

   Private Function GetColumnName() As String
      Dim config = cmbConfiguracionMail.ValorSeleccionado(Entidades.Cliente.ConfiguracionMail.Principal)
      Dim columnName = If(config = Entidades.Cliente.ConfiguracionMail.Principal, ColumnasAgenda.CorreoPrincipal.ToString(),
                       If(config = Entidades.Cliente.ConfiguracionMail.Administrativo, ColumnasAgenda.CorreoAdministrativo.ToString(),
                       If(config = Entidades.Cliente.ConfiguracionMail.AdminyPrincipal, ColumnasAgenda.CorreoAdminyPrincipal.ToString(),
                       If(config = Entidades.Cliente.ConfiguracionMail.AdminoPrincipal, ColumnasAgenda.CorreoAdminoPrincipal.ToString(), String.Empty))))
      Return columnName
   End Function

   Private Sub SetUsuariosDataSource()
      ugUsuarios.DataSource = _dtUsuarios
   End Sub
   Private Sub SetClientesDataSource()
      ugClientes.DataSource = FiltrarDataTable(_dtClientes)
   End Sub
   Private Sub SetProveedoresDataSource()
      ugProveedores.DataSource = FiltrarDataTable(_dtProveedores)
   End Sub
   Private Function FiltrarDataTable(dt As DataTable) As DataTable
      Dim columnName = GetColumnName()
      Dim drs = dt.Where(Function(dr) Not String.IsNullOrWhiteSpace(dr.Field(Of String)(columnName))).CopyToDataTable()
      Return drs
   End Function
#End Region

End Class