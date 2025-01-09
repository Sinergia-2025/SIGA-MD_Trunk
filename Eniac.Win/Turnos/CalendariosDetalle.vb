Public Class CalendariosDetalle
   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _titUsuarios As Dictionary(Of String, String)
   Dim _usuariosCalendarios As DataTable

   Public ReadOnly Property Calendario As Entidades.Calendario
      Get
         Return DirectCast(_entidad, Entidades.Calendario)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Eniac.Entidades.Calendario)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Campos"
   Private _blnCajasModificables As Boolean = True
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja
#End Region

#Region "Overrides"

   Public Sub CargaComboDesdeEnum(ByVal combo As Eniac.Controles.ComboBox, enumArray As Array)
      Dim list As List(Of KeyValuePair(Of Object, String)) = New List(Of KeyValuePair(Of Object, String))()
      For Each item As System.Enum In enumArray
         If Publicos.CheckBrowsable(item) Then
            list.Add(New KeyValuePair(Of Object, String)(item, DirectCast(item, DayOfWeek).NombreDiaSemana()))
         End If
      Next

      combo.DataSource = list
      combo.DisplayMember = "Value"
      combo.ValueMember = "Key"
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()
         _publicos.CargaComboSucursales(cmbIdSucursal)
         CargaComboDesdeEnum(cmbDiaSemana, System.Enum.GetValues(GetType(DayOfWeek)))
         _publicos.CargaComboUsuarios(Me.cmbUsuario)
         _publicos.CargaComboCajas(Me.cmbCajas, Entidades.Usuario.Actual.Sucursal.Id, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         _publicos.CargaComboTiposCalendarios(cmbTipoCalendario)
         _publicos.CargaComboNaves(cmbNave, MiraPC:=False)

         chbNave.Visible = cmbNave.Items.Count > 0
         cmbNave.Visible = chbNave.Visible

         Me.cmbCajas.SelectedIndex = -1

         Me.BindearControles(Me._entidad, Me._liSources)

         Dim oUsu As Reglas.Usuarios = New Reglas.Usuarios()
         _titUsuarios = GetColumnasVisiblesGrilla(dgvUsuarios)

         With Me.dgvUsuarios
            .DataSource = oUsu.GetAll("CadenaSegura")
         End With
         AjustarColumnasGrilla(dgvUsuarios, _titUsuarios)
         Me.dgvUsuarios.Refresh()

         Me.CargarUsuariosCalendarios()

         Me.dtpHoraDesde.Value = Date.Parse(DateTime.Now.ToString("HH:00"))

         Me.dtpHoraHasta.Value = Date.Parse(DateTime.Now.ToString("HH:00"))

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdCalendario.Text = (DirectCast(GetReglas(), Reglas.Calendarios).GetCodigoMaximo() + 1).ToString()
            Me.txtCupo.Text = "1"
         Else
            chbIdSucursal.Checked = Calendario.IdSucursal > 0
            chbUsuario.Checked = Calendario.IdUsuario <> ""
            If Not String.IsNullOrWhiteSpace(Calendario.IdProducto) Then
               chbProducto.Checked = True
               bscCodigoProducto2.Text = Calendario.IdProducto
               bscCodigoProducto2.PresionarBoton()
            End If

            ' IdCaja
            If Calendario.CalendarioSucursal.IdCaja <> 0 Then
               Me.chbCajas.Checked = True
               Me.cmbCajas.SelectedValue = Calendario.CalendarioSucursal.IdCaja
            End If

            If Calendario.IdNave.HasValue Then
               Dim val = Calendario.IdNave.Value
               Me.chbNave.Checked = True
               Me.cmbNave.SelectedValue = val

            End If

         End If

         chbProducto.Visible = Reglas.Publicos.TurnosPermiteFacturarDesdeCalendario
         bscCodigoProducto2.Visible = chbProducto.Visible
         bscProducto2.Visible = chbProducto.Visible

         If Reglas.Publicos.TurnosPermiteFacturarDesdeCalendario Then
            Me.chbCajas.Visible = True
            Me.cmbCajas.Visible = True
         Else
            Me.chbCajas.Visible = False
            Me.cmbCajas.Visible = False
         End If


         chbIdSucursal_CheckedChanged(cmbIdSucursal, Nothing)

         _tit = GetColumnasVisiblesGrilla(ugDiasSemana)

         ugDiasSemana.DataSource = Calendario.Horarios
         AjustarColumnasGrilla(ugDiasSemana, _tit)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Calendarios()
   End Function

   Protected Overrides Sub Aceptar()

      If Me._usuariosCalendarios IsNot Nothing Then
         Me._usuariosCalendarios.AcceptChanges()
      End If

      DirectCast(Me._entidad, Entidades.Calendario).Usuarios = Me._usuariosCalendarios

      If Not chbIdSucursal.Checked Then
         Calendario.IdSucursal = 0
      End If

      If chbProducto.Checked Then
         Calendario.IdProducto = bscCodigoProducto2.Text
      Else
         Calendario.IdProducto = String.Empty
      End If

      If cmbCajas.SelectedIndex > -1 Then
         Calendario.CalendarioSucursal.IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
      Else
         Calendario.CalendarioSucursal.IdCaja = 0
      End If

      MyBase.Aceptar()

      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      If Integer.Parse("0" & Me.txtIdCalendario.Text) = 0 Then
         Me.txtIdCalendario.Focus()
         Return "El Codigo de Calendario NO puede ser Cero."
      End If

      If chbIdSucursal.Checked And cmbIdSucursal.SelectedIndex = -1 Then
         cmbIdSucursal.Focus()
         Return "Debe indicar una Sucursal."
      End If

      If chbProducto.Checked Then
         If Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
            bscCodigoProducto2.Focus()
            Return "Debe seleccionar un Producto."
         End If
      End If

      If chbCajas.Checked And cmbCajas.SelectedIndex = -1 Then
         Me.cmbCajas.Focus()
         Return "Debe seleccionar una Caja."
      End If

      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Metodos"

   Private Function ValidarInsertarHorario() As Boolean

      If cmbDiaSemana.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar un día de semana")
         cmbDiaSemana.Focus()
         Return False
      End If

      Dim idDiaSemanaPantalla As DayOfWeek = DirectCast(cmbDiaSemana.SelectedValue, DayOfWeek)
      Dim horaDesdePantalla As DateTime = Today.AddHours(dtpHoraDesde.Value.Hour).AddMinutes(0)
      Dim horaHastaPantalla As DateTime = Today.AddHours(dtpHoraHasta.Value.Hour).AddMinutes(0)

      Dim horaDesdeRegistro As DateTime
      Dim horaHastaRegistro As DateTime
      Dim horaRegistro As Integer
      Dim minuRegistro As Integer

      For Each hora As Entidades.CalendarioHorario In Calendario.Horarios
         If idDiaSemanaPantalla.Equals(hora.IdDiaSemana) Then
            horaRegistro = Integer.Parse(hora.HoraDesde.Split(":"c)(0))
            minuRegistro = Integer.Parse(hora.HoraDesde.Split(":"c)(1))
            horaDesdeRegistro = Today.AddHours(horaRegistro).AddMinutes(minuRegistro)

            horaRegistro = Integer.Parse(hora.HoraHasta.Split(":"c)(0))
            minuRegistro = Integer.Parse(hora.HoraHasta.Split(":"c)(1))
            horaHastaRegistro = Today.AddHours(horaRegistro).AddMinutes(minuRegistro)

            If horaDesdeRegistro <= horaHastaPantalla And horaHastaRegistro >= horaDesdePantalla Then
               ShowMessage(String.Format("Existe un horario para el día {0} desde {1} hasta {2}",
                                         hora.NombreDiaSemana, hora.HoraDesde, hora.HoraHasta))
               dtpHoraDesde.Focus()
               Return False
            End If
         End If
      Next

      Return True
   End Function

   Private Sub InsertarHorario()
      Dim horario As Entidades.CalendarioHorario = New Entidades.CalendarioHorario()
      horario.IdDiaSemana = DirectCast(cmbDiaSemana.SelectedValue, DayOfWeek)
      horario.HoraDesde = dtpHoraDesde.Value.ToString("HH:mm")
      horario.HoraHasta = dtpHoraHasta.Value.ToString("HH:mm")

      Calendario.Horarios.Add(horario)
      ugDiasSemana.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
   End Sub

   Private Function GetDiaSemanaRow() As Entidades.CalendarioHorario
      If ugDiasSemana.ActiveRow IsNot Nothing AndAlso
         ugDiasSemana.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugDiasSemana.ActiveRow.ListObject) Is Entidades.CalendarioHorario Then
         Return DirectCast(ugDiasSemana.ActiveRow.ListObject, Entidades.CalendarioHorario)
      End If
      Return Nothing
   End Function

   Private Sub CargarUsuariosCalendarios()
      Dim oUsuCaj As Reglas.Calendarios = New Reglas.Calendarios()
      With Me.dgvUsuariosCalendarios
         If Me.cmbIdSucursal.SelectedIndex > -1 Then
            Me._usuariosCalendarios = oUsuCaj.GetUsuariosPorCalendario(Me.txtIdCalendario.Text, Integer.Parse(Me.cmbIdSucursal.SelectedValue.ToString()))
         Else
            Me._usuariosCalendarios = oUsuCaj.GetUsuariosPorCalendario(Me.txtIdCalendario.Text, 0)
         End If
         .DataSource = Me._usuariosCalendarios
      End With
      Me.FormatearGrillaUsuariosCalendarios()
   End Sub

   Private Sub FormatearGrillaUsuariosCalendarios()
      With Me.dgvUsuariosCalendarios
         .Columns("Nombre").HeaderText = "Usuario"
         .Columns("Nombre").Width = 140
         .Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
         .Columns("IdUsuario").HeaderText = "Id"
         .Columns("IdUsuario").Width = 60
         .Columns("IdSucursal").Visible = False
         .Columns("IdCalendario").Visible = False
         .Columns("PermitirEscritura").HeaderText = "Permitir Escritura"
         .Columns("PermitirEscritura").Width = 50
      End With
   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
   End Sub

#End Region

#Region "Eventos"

#Region "Eventos Botones"
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If ValidarInsertarHorario() Then
            InsertarHorario()
            cmbDiaSemana.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         Dim horario As Entidades.CalendarioHorario = GetDiaSemanaRow()
         If horario IsNot Nothing Then
            Calendario.Horarios.Remove(horario)
            ugDiasSemana.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      If Me.dgvUsuarios.SelectedRows.Count > 0 Then
         For Each dg As DataGridViewRow In Me.dgvUsuarios.SelectedRows
            If Me._usuariosCalendarios.Select("IdUsuario = '" & dg.Cells("Id").Value.ToString() & "'").Length = 0 Then
               Dim dr As DataRow = Me._usuariosCalendarios.NewRow()
               dr(0) = actual.Sucursal.Id
               dr(1) = Me.txtIdCalendario.Text
               dr(2) = dg.Cells("Id").Value
               dr(3) = dg.Cells("Nombre").Value
               dr(4) = Me.ChbPermitirEscritura.Checked
               Me._usuariosCalendarios.Rows.Add(dr)
            End If
         Next
      End If
   End Sub

   Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
      If Me.dgvUsuariosCalendarios.SelectedCells.Count > 0 Then
         Me.dgvUsuariosCalendarios.Rows.Remove(Me.dgvUsuariosCalendarios.SelectedRows(0))
      End If
   End Sub

#End Region

#Region "Eventos KeyDown/KeyPress"
   Private Sub txtIdCalendario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreCalendario.KeyDown, txtIdCalendario.KeyDown, cmbIdSucursal.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtDiasDesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasDesde.KeyPress
      If Not IsNumeric(e.KeyChar) AndAlso System.Convert.ToByte(e.KeyChar) <> 8 AndAlso Convert.ToByte(e.KeyChar) <> 45 Then
         e.Handled = True
      End If
   End Sub
#End Region

#Region "Eventos Checkbox"
   Private Sub chbIdSucursal_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdSucursal.CheckedChanged
      Try
         cmbIdSucursal.Enabled = chbIdSucursal.Checked
         If Not chbIdSucursal.Checked Then
            cmbIdSucursal.SelectedIndex = -1
            chbIdSucursal.Focus()
         Else
            cmbIdSucursal.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub lblIdSucursal_Click(sender As Object, e As EventArgs) Handles lblIdSucursal.Click
      chbIdSucursal.Checked = Not chbIdSucursal.Checked
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      If Not Me.chbUsuario.Checked Then
         Me.cmbUsuario.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.Calendario).IdUsuario = String.Empty
      End If
      Me.cmbUsuario.Enabled = Me.chbUsuario.Checked
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      Try
         bscCodigoProducto2.Enabled = chbProducto.Checked
         bscProducto2.Enabled = chbProducto.Checked
         If chbProducto.Checked Then
            bscCodigoProducto2.Focus()
         Else
            bscCodigoProducto2.Text = String.Empty
            bscProducto2.Text = String.Empty
            bscCodigoProducto2.Selecciono = False
            bscProducto2.Selecciono = False
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbCajas_CheckedChanged(sender As Object, e As EventArgs) Handles chbCajas.CheckedChanged
      Me.cmbCajas.Enabled = Me.chbCajas.Checked
      If Not Me.chbCajas.Checked Then
         Me.cmbCajas.SelectedIndex = -1
      End If
   End Sub
#End Region

#Region "Eventos Buscadores"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#End Region

   Private Sub chbNave_CheckedChanged(sender As Object, e As EventArgs) Handles chbNave.CheckedChanged
      TryCatched(Sub() chbNave.FiltroCheckedChanged(cmbNave))
   End Sub
End Class