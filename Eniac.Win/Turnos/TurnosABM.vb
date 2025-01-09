#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinSchedule
Imports Infragistics.Win
Imports Eniac.Entidades
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class TurnosABM
   Private _publicos As Publicos
   Private _turnos As List(Of Entidades.TurnoCalendario)
   Private _turnosBorrados As List(Of Entidades.TurnoCalendario)
   Private _tit As Dictionary(Of String, String)
   Private _hayGrabacionPendiente As Boolean
   Private _estaCargando As Boolean = True
   Private _grabarAutomaticamente As Boolean = True
   Private _cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      _turnos = New List(Of Entidades.TurnoCalendario)()
   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         _publicos.CargaComboCalendariosActivos(Me.cmbCalendario, actual.Sucursal.IdSucursal, Usuario.Actual.Nombre)

         If Me.cmbCalendario.Items.Count <> 0 Then
            Me.cmbCalendario.SelectedIndex = -1 'Para forzar el control posterior si puede grabar.
         Else
            MessageBox.Show("No existen Calendarios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

         End If

         tsbFacturar.Visible = Reglas.Publicos.TurnosPermiteFacturarDesdeCalendario
         tssFacturar.Visible = Reglas.Publicos.TurnosPermiteFacturarDesdeCalendario

         _tit = GetColumnasVisiblesGrilla()

         Me._estaCargando = False

         Refrescar()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
#End Region

#Region "Overridable"
   Protected Overridable Function GetColumnasVisiblesGrilla() As Dictionary(Of String, String)
      Return MyBase.GetColumnasVisiblesGrilla(ugTurnos)
   End Function
   Protected Overridable Function GetRegla() As Reglas.TurnosCalendarios
      Return New Reglas.TurnosCalendarios()
   End Function
   Protected Overridable Function LocationParaAppointment(turno As Entidades.TurnoCalendario) As String
      Dim result As String = String.Empty

      If Not String.IsNullOrWhiteSpace(turno.IdProducto) Then
         Dim turnosPorZona As StringBuilder = New StringBuilder()
         If turno.TurnoProducto IsNot Nothing Then
            For Each zona As Entidades.TurnosCalendariosProductos In turno.TurnoProducto
               turnosPorZona.AppendFormat("{0} S:{1} / ", zona.NombreProducto, zona.NumeroSesion)
            Next
         End If

         Dim producto As DataRow = _cache.BuscaProductoPorId(turno.IdProducto)
         If producto IsNot Nothing Then
            '0: IdProducto                   1: NombreProducto             2: Precio Lista                 
            '3: Descuento Recargo General    4: Descuento Recargo 1        5: Descuento Recargo 2
            '6: Precio Neto                  7: Nro de Sesion              8: Zonas (finaliza en " / ")
            Dim formato As String = "{6,12:N2} / {8}{1,-40}"
            If GetCalendarioSeleccionado().UtilizaSesion And turno.TurnoProducto.Count = 0 Then
               formato = String.Concat("{7,5} / ", formato)
            End If
            result = String.Format(formato,
                                   turno.IdProducto,
                                   producto("NombreProducto"),
                                   turno.Precio,
                                   turno.DescuentoRecargoPorcGral,
                                   turno.DescuentoRecargoPorc1,
                                   turno.DescuentoRecargoPorc2,
                                   turno.PrecioNeto,
                                   turno.NumeroSesion,
                                   turnosPorZona.ToString())
            If Not String.IsNullOrWhiteSpace(turno.IdTipoComprobante) Then
               result = String.Concat(result, "  /  FACTURADO")
            End If
            If Not String.IsNullOrWhiteSpace(turno.Observaciones) Then
               result = String.Concat(result, "  /  ", turno.Observaciones)
            End If
         End If
      Else
         If GetCalendarioSeleccionado().UtilizaSesion Then
            result = String.Format("{0,5} / {1}", turno.NumeroSesion, turno.Observaciones)
         Else
            result = turno.Observaciones
         End If
      End If

      Return result
   End Function
   Protected Overridable Function SubjectParaAppointment(turno As Entidades.TurnoCalendario) As String
      Dim formato = "{0} ({1})"
      If Not String.IsNullOrWhiteSpace(turno.NombreEmbarcacion) Then
         formato = "{4}: {3} ({2}) - Cliente: {1} ({0})"
      End If

      Return String.Format(formato,
                           turno.CodigoCliente, turno.NombreCliente,
                           turno.CodigoEmbarcacion, turno.NombreEmbarcacion,
                           turno.NombreTipoTurno)
   End Function
   Protected Overridable Function NewDetalle(turno As Entidades.TurnoCalendario, turnos As List(Of Entidades.TurnoCalendario), stateForm As StateForm) As TurnosDetalle
      Return New TurnosDetalle(turno, turnos, stateForm)
   End Function
   Protected Overridable Function NewEntidad(calendario As Entidades.Calendario, fechaDesde As DateTime, fechaHasta As DateTime) As Entidades.TurnoCalendario
      Return New Entidades.TurnoCalendario(calendario, fechaDesde, fechaHasta)
   End Function


   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F5 Then
            Me.Cursor = Cursors.WaitCursor
            Me.tsbRefrescar.PerformClick()
            Return True
         ElseIf keyData = Keys.F3 Then
            cmbCalendario.DropDownStyle = ComboBoxStyle.DropDown
            cmbCalendario.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
            cmbCalendario.AutoCompleteSource = AutoCompleteSource.ListItems
            cmbCalendario.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Eventos"

   'Private Sub TurnosABM_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

   '   If e.KeyCode = Keys.F5 Then
   '      Try
   '         Me.Cursor = Cursors.WaitCursor

   '         Me.tsbRefrescar.PerformClick()

   '      Catch ex As Exception
   '         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Finally
   '         Me.Cursor = Cursors.Default
   '      End Try
   '   End If

   'End Sub

   Private Sub cmbCalendario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalendario.SelectedIndexChanged

      If Me._estaCargando Then Exit Sub

      Dim CA As Entidades.Calendario = DirectCast(Me.cmbCalendario.SelectedItem, Entidades.Calendario)
      Me.dtpFechaDesde.Value = Today.AddDays(CA.DiasDesde)
      Me.dtpFechaHasta.Value = Today.AddDays(CA.DiasHasta)

      Me.SeteaBotonesUsuario()
      btnConsultar_Click(btnConsultar, Nothing)
      'PerformClick se ejecuta solo si Visible = True y Enabled = True
      'Me.btnConsultar.PerformClick()

      If cmbCalendario.DropDownStyle = ComboBoxStyle.DropDown Then
         cmbCalendario.DropDownStyle = ComboBoxStyle.DropDownList
         cmbCalendario.AutoCompleteMode = Windows.Forms.AutoCompleteMode.None
         cmbCalendario.AutoCompleteSource = AutoCompleteSource.None
      End If

   End Sub

   Private Sub dtpFechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDesde.ValueChanged

      If Me._estaCargando Then Exit Sub

      btnConsultar_Click(btnConsultar, Nothing)
      'PerformClick se ejecuta solo si Visible = True y Enabled = True
      'Me.btnConsultar.PerformClick()

   End Sub

   Private Sub dtpFechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaHasta.ValueChanged

      If Me._estaCargando Then Exit Sub

      btnConsultar_Click(btnConsultar, Nothing)
      'PerformClick se ejecuta solo si Visible = True y Enabled = True
      'Me.btnConsultar.PerformClick()

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If calendarInfo.Appointments.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            'MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#Region "Eventos Toolbar Calendario"
   Private Sub tsbHoy_Click(sender As Object, e As EventArgs) Handles tsbHoy.Click
      calendarInfo.ActivateDay(Today)
   End Sub
   Private Sub tsbDiario_Click(sender As Object, e As EventArgs) Handles tsbDiario.Click
      MostrarCalendario(1)
   End Sub
   Private Sub tsbSemanal_Click(sender As Object, e As EventArgs) Handles tsbSemanal.Click
      MostrarCalendario(7)
   End Sub
   Private Sub tsbMensual_Click(sender As Object, e As EventArgs) Handles tsbMensual.Click
      MostrarCalendario(30)
   End Sub
   Private Sub tsbLista_Click(sender As Object, e As EventArgs) Handles tsbLista.Click
      MostrarCalendario(-1)
   End Sub
   Private Sub tsbAnterior_Click(sender As Object, e As EventArgs) Handles tsbAnterior.Click
      MoverDiaSeleccionado(-1)
   End Sub
   Private Sub tsbSiguiente_Click(sender As Object, e As EventArgs) Handles tsbSiguiente.Click
      MoverDiaSeleccionado(1)
   End Sub
#End Region

#Region "Eventos Toolbar Generico"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Refrescar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      Try
         Agregar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbModificar_Click(sender As Object, e As EventArgs) Handles tsbModificar.Click
      Try
         Modificar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbEliminar_Click(sender As Object, e As EventArgs) Handles tsbEliminar.Click
      TryCatched(Sub()
                    If calendarInfo.SelectedAppointments.Count > 0 Then
                       Dim app As Appointment = calendarInfo.SelectedAppointments(0)
                       If app.Tag IsNot Nothing AndAlso TypeOf (app.Tag) Is Entidades.TurnoCalendario Then
                          Dim turno As Entidades.TurnoCalendario = DirectCast(app.Tag, Entidades.TurnoCalendario)

                          If ShowPregunta(String.Format("¿Está seguro de borrar el turno de {1} ({0}) para el horario de {2:HH:mm} a {3:HH:mm}?",
                                                        turno.CodigoCliente, turno.NombreCliente, turno.FechaDesde, turno.FechaHasta)) = Windows.Forms.DialogResult.Yes Then
                             calendarInfo.Appointments.Remove(app)
                             _turnosBorrados.Add(turno)
                             ugTurnos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
                             tssRegistros.Text = String.Format("{0} Registros", _turnos.Count)
                             _hayGrabacionPendiente = True
                             If _grabarAutomaticamente Then
                                GuardarTurnos()
                                CargaGrillaDetalle()
                             End If
                          End If
                       End If
                    End If
                 End Sub)
   End Sub
   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(Sub()
                    Cursor = Cursors.WaitCursor
                    GuardarTurnos()
                    ShowMessage("Grabación realizada exitosamente!")
                    CargaGrillaDetalle()
                 End Sub)
   End Sub
   Private Sub tsbFacturar_Click(sender As Object, e As EventArgs) Handles tsbFacturar.Click
      TryCatched(Sub()
                    If calendarInfo.SelectedAppointments.Count > 0 Then
                       Dim app As Appointment = calendarInfo.SelectedAppointments(0)
                       If app.Tag IsNot Nothing AndAlso TypeOf (app.Tag) Is Entidades.TurnoCalendario Then
                          Dim turno As Entidades.TurnoCalendario = DirectCast(app.Tag, Entidades.TurnoCalendario)
                          If Not String.IsNullOrWhiteSpace(turno.IdProducto) Then
                             Dim venta As Entidades.Venta = GetRegla().ConvertirTurnoEnVenta(turno, _cache)

                             Using frm As New FacturacionV2()
                                frm.IdFuncion = Me.IdFuncion
                                frm.InvocarDesdeCajero(venta, idTipoComprobanteGenerar:=String.Empty, soloCopia:=True)
                                frm.ShowInTaskbar = False
                                If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                                   Refrescar()
                                End If
                             End Using
                          Else
                             ShowMessage("El turno seleccionado no tiene un producto seleccionado. No es posible facturar.")
                          End If
                       End If
                    Else
                       ShowMessage("Seleccione un turno a facturar.")
                    End If
                 End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub()
                    If _hayGrabacionPendiente Then
                       If ShowPregunta("Existen modificaciones sin guardar. Si sale ahora perderá los cambios realizados." + Environment.NewLine + Environment.NewLine +
                                       "¿Desea salir de todas manera?") = Windows.Forms.DialogResult.No Then
                          Exit Sub
                       End If
                    End If
                    Close()
                 End Sub)
   End Sub

#End Region

#Region "Eventos CalendarInfo"
   Private Sub calendarInfo_AfterActiveDayChanged(sender As Object, e As AfterActiveDayChangedEventArgs) Handles calendarInfo.AfterActiveDayChanged
      Try
         CargaDataSourceGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub calendarInfo_BeforeDisplayAppointmentDialog(sender As Object, e As DisplayAppointmentDialogEventArgs) Handles calendarInfo.BeforeDisplayAppointmentDialog
      If e.Appointment.Tag IsNot Nothing Then
         Try
            Modificar()
         Catch ex As Exception
            ShowError(ex)
         End Try
      Else
         Try
            Agregar()
         Catch ex As Exception
            ShowError(ex)
         End Try
      End If
      e.Cancel = True
   End Sub
#End Region

#End Region

#Region "Metodos Genericos"
   Private Sub Refrescar()
      If _hayGrabacionPendiente Then
         If ShowPregunta("Existen modificaciones sin guardar." + Environment.NewLine + Environment.NewLine +
                         "¿Desea refrescar de todos modos?") = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If
      End If

      _cache = New Reglas.BusquedasCacheadas()

      If Me.cmbCalendario.Items.Count <> 0 Then
         cmbCalendario.SelectedIndex = 0
      Else
         Throw New Exception("No existen Calendarios.")
      End If

      Dim CA As Entidades.Calendario = DirectCast(Me.cmbCalendario.SelectedItem, Entidades.Calendario)
      Me.dtpFechaDesde.Value = Today.AddDays(CA.DiasDesde)
      Me.dtpFechaHasta.Value = Today.AddDays(CA.DiasHasta)

      If _turnos IsNot Nothing Then _turnos.Clear()
      ugTurnos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
      If _turnosBorrados IsNot Nothing Then _turnosBorrados.Clear()


      calendarInfo.Appointments.Clear()
      calendarInfo.ActivateDay(Today)

      MostrarCalendario(1)

      CargaWorkingHours()

      tsbGrabar.Enabled = False

      _hayGrabacionPendiente = False

      btnConsultar_Click(btnConsultar, Nothing)

   End Sub

   Private Sub SeteaBotonesUsuario()

      Dim oCalendarios As Reglas.Calendarios = New Reglas.Calendarios()

      Dim dt As DataTable = New DataTable()

      dt = oCalendarios.GetCalendarioPorUsuario(Integer.Parse(Me.cmbCalendario.SelectedValue.ToString()), actual.Sucursal.IdSucursal, Usuario.Actual.Nombre)

      Dim blnVisible As Boolean

      blnVisible = Boolean.Parse(dt.Rows(0).Item("PermitirEscritura").ToString())

      Me.tss1.Visible = blnVisible
      Me.tsbGrabar.Visible = blnVisible And Not _grabarAutomaticamente
      Me.tssGrabar.Visible = blnVisible And Not _grabarAutomaticamente
      Me.tsbNuevo.Visible = blnVisible
      Me.tss3.Visible = blnVisible
      Me.tsbModificar.Visible = blnVisible
      Me.tss4.Visible = blnVisible
      Me.tsbEliminar.Visible = blnVisible

   End Sub

   Private Sub CargaGrillaDetalle()

      If cmbCalendario.SelectedIndex < 0 Then
         Throw New Exception("Debe seleccionar un Calendario.")
      End If

      If _hayGrabacionPendiente Then
         If ShowPregunta("Existen modificaciones sin guardar y las perderá si consulta." + Environment.NewLine + Environment.NewLine +
                         "¿Desea consultar de todas manera?") = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If
      End If

      CargaWorkingHours()

      _turnos = GetRegla().GetTodos(Integer.Parse(cmbCalendario.SelectedValue.ToString()),
                                    dtpFechaDesde.Value,
                                    dtpFechaHasta.Value)
      _turnosBorrados = New List(Of Entidades.TurnoCalendario)()

      tssRegistros.Text = String.Format("{0} Registros", _turnos.Count)

      calendarInfo.Appointments.Clear()
      For Each turno As Entidades.TurnoCalendario In _turnos
         CargaAppointmentDesdeTurno(turno)
      Next
      CargaDataSourceGrilla()

      tsbGrabar.Enabled = True

      UltraDayView1.EnsureTimeSlotVisible(DateTime.Now, True)
   End Sub
   Private Sub CargaDataSourceGrilla()
      Dim fechaSeleccionada As DateTime = calendarInfo.ActiveDay.Date
      Dim filtrados As List(Of Entidades.TurnoCalendario) = New List(Of Entidades.TurnoCalendario)()
      For Each turno As Entidades.TurnoCalendario In _turnos
         If turno.FechaDesde >= fechaSeleccionada And turno.FechaDesde <= fechaSeleccionada.AddDays(1).AddSeconds(-1) Then
            filtrados.Add(turno)
         End If
      Next
      ugTurnos.DataSource = filtrados
      AjustarColumnasGrilla(ugTurnos, _tit)
   End Sub
   Private Sub GuardarTurnos()
      Dim rTurnos As Reglas.TurnosCalendarios = GetRegla()

      rTurnos.Actualizar(_turnos, _turnosBorrados)

      _hayGrabacionPendiente = False
   End Sub
   Private Function GetTurnoDeGrilla() As Entidades.TurnoCalendario
      If ugTurnos.ActiveRow IsNot Nothing AndAlso
         ugTurnos.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugTurnos.ActiveRow.ListObject) Is Entidades.TurnoCalendario Then
         Return DirectCast(ugTurnos.ActiveRow.ListObject, Entidades.TurnoCalendario)
      End If
      Return Nothing
   End Function
   Private Sub CargaWorkingHours()

      ' Me.UltraDayView1.CalendarInfo.DaysOfWeek.Reset()
      If Me.cmbCalendario.SelectedIndex <> -1 Then

         Dim CA As Entidades.Calendario = New Reglas.Calendarios().GetUno(Integer.Parse(Me.cmbCalendario.SelectedValue.ToString()))

         Me.UltraDayView1.CalendarInfo.Owners.UnassignedOwner.Name = CA.NombreCalendario

         Dim day As Infragistics.Win.UltraWinSchedule.DayOfWeek = Nothing

         'Excepciones de Calendario
         Me.calendarInfo.DateSettings.Clear()

         Dim Excepciones As DataTable = New Reglas.CalendariosExcepciones()._GetTodos(Integer.Parse(cmbCalendario.SelectedValue.ToString()))

         For Each dr As DataRow In Excepciones.Rows
            calendarInfo.DateSettings.Add(Date.Parse(dr("FechaExcepcion").ToString())).IsWorkDay = DefaultableBoolean.False
         Next

         'Carga de Horarios
         For Each dayOfWeek As DayOfWeek In calendarInfo.DaysOfWeek
            dayOfWeek.WorkingHours.Clear()
            dayOfWeek.WorkDayStartTime = Today
            dayOfWeek.WorkDayEndTime = Today
            dayOfWeek.IsWorkDay = False
         Next

         For Each Horario As Entidades.CalendarioHorario In CA.Horarios

            day = Me.calendarInfo.DaysOfWeek(Horario.IdDiaSemana)

            Dim hora1 As Double = Decimal.Parse(Horario.HoraDesde.Substring(0, 2)) + Decimal.Parse(Horario.HoraDesde.Substring(3, 2)) / 60
            Dim hora2 As Double = Decimal.Parse(Horario.HoraHasta.Substring(0, 2)) + Decimal.Parse(Horario.HoraHasta.Substring(3, 2)) / 60

            ' day.WorkDayStartTime = DateTime.Today.AddHours(hora1)
            ' day.WorkDayEndTime = DateTime.Today.AddHours(hora2)
            Dim TR As TimeRange = New TimeRange(TimeSpan.FromHours(hora1), TimeSpan.FromHours(hora2))

            day.WorkingHours.Add(TR)
            day.WorkDayStartTime = Today
            day.WorkDayEndTime = Today
            day.IsWorkDay = True
         Next

         Dim fecha1EneroDesde As DateTime = dtpFechaDesde.Value.Date.PrimerDiaAnio
         'Dim fecha1EneroHasta As DateTime = dtpFechaHasta.Value.Date.PrimerDiaAnio
         For Each diaLook As DayLook In UltraCalendarLook1.DaysOfYearLook
            Dim fecha As DateTime = fecha1EneroDesde.AddDays(diaLook.DayNumber - 2)
            'Dim fecha2 As DateTime = fecha1EneroHasta.AddDays(diaLook.DayNumber - 2)
            If Not calendarInfo.IsWorkDay(fecha) Then
               diaLook.Appearance.ForeColor = Color.LightGray
            Else
               diaLook.Appearance.ForeColor = Nothing
            End If
         Next

         Me.UltraDayView1.WorkingHourTimeSlotAppearance.BackColor = Color.LightGreen

      End If

   End Sub
   Private Function HoraStringToTimeSpan(hora As String) As TimeSpan
      If hora.Split(":"c).Length < 2 Then hora = hora + ":"
      Return New TimeSpan(Integer.Parse(hora.Split(":"c)(0)), Integer.Parse(hora.Split(":"c)(1)), 0)
   End Function
   Protected Function GetCalendarioSeleccionado() As Entidades.Calendario
      If cmbCalendario.SelectedIndex < 0 Then
         Return Nothing
      Else
         Return DirectCast(cmbCalendario.SelectedItem, Entidades.Calendario)
      End If
   End Function
   Private Function ControlarHorarios(ByVal FechaDesde As DateTime, ByVal FechaHasta As DateTime) As Boolean
      Return calendarInfo.IsInWorkingHours(FechaDesde, FechaDesde.TimeOfDay, FechaHasta.TimeOfDay)
   End Function
#End Region

#Region "Metodos Appointments"
   Private Sub CargaAppointmentDesdeTurno(turno As Entidades.TurnoCalendario)
      Dim app As Appointment = New Appointment(turno.FechaDesde, turno.FechaHasta)
      app.Locked = True

      ActualizaAppointmentDesdeTurno(app, turno)

      calendarInfo.Appointments.Add(app)
   End Sub
   Private Sub ActualizaAppointmentDesdeTurno(app As Appointment, turno As Entidades.TurnoCalendario)
      app.StartDateTime = turno.FechaDesde
      app.EndDateTime = turno.FechaHasta
      app.Subject = SubjectParaAppointment(turno)
      app.Location = LocationParaAppointment(turno)
      app.Description = turno.Observaciones
      'If turno.EsEfectivo Then

      ' app.Appearance.BackColor = Color.DimGray.ToArgb
      'End If
      app.Tag = turno

      If Not String.IsNullOrEmpty(Reglas.Ayudante.Cache.Turnos.CacheTurnosEstados.Instancia.Buscar(turno.IdEstadoTurno).Color.ToString()) Then
         app.Appearance.BackColor = Color.FromArgb(Integer.Parse(Reglas.Ayudante.Cache.Turnos.CacheTurnosEstados.Instancia.Buscar(turno.IdEstadoTurno).Color.ToString()))
      End If
   End Sub
   Private Sub MostrarCalendario(dias As Integer)
      UltraDayView1.Visible = dias = 1
      UltraWeekView1.Visible = dias = 7
      UltraMonthViewSingle1.Visible = dias = 30
      ugTurnos.Visible = dias = -1

   End Sub
   Private Sub MoverDiaSeleccionado(coeficiente As Integer)
      If UltraDayView1.Visible Then
         SeleccionarDia(calendarInfo.ActiveDay.Date.AddDays(coeficiente))
      ElseIf UltraWeekView1.Visible Then
         SeleccionarDia(calendarInfo.ActiveDay.Date.AddDays(coeficiente * 7))
      ElseIf UltraMonthViewMulti1.Visible Then
         SeleccionarDia(calendarInfo.ActiveDay.Date.AddMonths(coeficiente))
      ElseIf ugTurnos.Visible Then
         SeleccionarDia(calendarInfo.ActiveDay.Date.AddDays(coeficiente))
         'If coeficiente > 0 Then
         '   ugTurnos.PerformAction(UltraWinGrid.UltraGridAction.BelowRow)
         'Else
         '   ugTurnos.PerformAction(UltraWinGrid.UltraGridAction.AboveCell)
         'End If
      End If
   End Sub
   Private Sub SeleccionarDia(dia As DateTime)
      calendarInfo.ActiveDay.Selected = False
      calendarInfo.ActivateDay(dia)
      calendarInfo.ActiveDay.Selected = True
   End Sub
#End Region

#Region "Metodos Formulario Detalle"
   Private Function GetFechaDesdeDePantalla() As DateTime
      If UltraDayView1.Visible Then
         Return UltraDayView1.SelectedTimeSlotRange.StartDateTime
      ElseIf UltraWeekView1.Visible Or UltraMonthViewSingle1.Visible Then
         If calendarInfo.SelectedDateRanges.Count > 0 Then
            Return calendarInfo.SelectedDateRanges(0).StartDate.Add(Now.TimeOfDay).RedondearFecha(GetCalendarioSeleccionado().LapsoPorDefecto)
         Else
            Return GetNowRedondeada()
         End If
      ElseIf ugTurnos.Visible Then
         If ugTurnos.ActiveRow IsNot Nothing AndAlso
            ugTurnos.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugTurnos.ActiveRow.ListObject) Is Entidades.TurnoCalendario Then
            Return DirectCast(ugTurnos.ActiveRow.ListObject, Entidades.TurnoCalendario).FechaHasta
         Else
            Return GetNowRedondeada()
         End If
      Else
         Return GetNowRedondeada()
      End If
   End Function

   Private Function GetNowRedondeada() As DateTime
      Return Now.RedondearFecha(DirectCast(cmbCalendario.SelectedItem, Entidades.Calendario).LapsoPorDefecto)
   End Function

   Private Sub Agregar()

      Dim cal = cmbCalendario.ItemSeleccionado(Of Entidades.Calendario)()
      Dim turno As Entidades.TurnoCalendario = NewEntidad(cal,
                                                          GetFechaDesdeDePantalla(),
                                                          GetFechaDesdeDePantalla().AddMinutes(cal.LapsoPorDefecto))

      If calendarInfo.SelectedAppointments.Count > 0 Then
         turno.FechaDesde = calendarInfo.SelectedAppointments.Item(0).StartDateTime
         turno.FechaHasta = calendarInfo.SelectedAppointments.Item(0).EndDateTime
      End If

      If Me.ControlarHorarios(GetFechaDesdeDePantalla(), GetFechaDesdeDePantalla().AddMinutes(DirectCast(cmbCalendario.SelectedItem, Entidades.Calendario).LapsoPorDefecto)) Then
         AbrirDetalle(turno, Nothing, StateForm.Insertar)
      Else
         MessageBox.Show("El turno no corresponde al horario definido para el Calendario", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If

   End Sub
   Private Sub Modificar()
      If Not ugTurnos.Visible Then
         If calendarInfo.SelectedAppointments.Count > 0 Then
            Dim app As Appointment = calendarInfo.SelectedAppointments(0)
            If app.Tag IsNot Nothing AndAlso TypeOf (app.Tag) Is Entidades.TurnoCalendario Then
               Dim turno As Entidades.TurnoCalendario = DirectCast(app.Tag, Entidades.TurnoCalendario)
               AbrirDetalle(turno, app, StateForm.Actualizar)
            End If
         End If
      Else
         Dim turno As Entidades.TurnoCalendario = GetTurnoDeGrilla()
         If turno IsNot Nothing Then
            For Each app As Appointment In calendarInfo.Appointments
               If app.Tag.Equals(turno) Then
                  AbrirDetalle(turno, app, StateForm.Actualizar)
               End If
            Next
         End If
      End If
   End Sub
   Private Sub AbrirDetalle(turno As Entidades.TurnoCalendario, app As Appointment, stateForm As StateForm)

      If stateForm = Win.StateForm.Insertar AndAlso Not TurnosDetalle.ControlaCupoDisponible(_turnos, turno, turno.FechaDesde, turno.FechaHasta, turno.Calendario.Cupo) Then
         If ShowPregunta("El cupo está completo para este rando de hora. ¿Desea ingresar un sobreturno?") = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If
      End If

      Dim turnoOriginal As Entidades.TurnoCalendario = Nothing
      If stateForm = Win.StateForm.Actualizar Then
         turnoOriginal = turno
         turno = GetRegla().GetUno(turno.IdTurnoUnico, turno.IdCalendario)
      End If

      Using frmDetalle As TurnosDetalle = NewDetalle(turno, _turnos, stateForm)
         If frmDetalle.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If stateForm = Win.StateForm.Insertar Then
               _turnos.Add(turno)
               CargaAppointmentDesdeTurno(turno)
               CargaDataSourceGrilla()
            Else
               If turnoOriginal IsNot Nothing Then
                  _turnos.Remove(turnoOriginal)
                  _turnos.Add(turno)
               End If
               ActualizaAppointmentDesdeTurno(app, turno)
            End If
            ugTurnos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
            tssRegistros.Text = String.Format("{0} Registros", _turnos.Count)
            _hayGrabacionPendiente = True
            If _grabarAutomaticamente Then
               GuardarTurnos()
               CargaGrillaDetalle()
            End If
         End If
      End Using
   End Sub
#End Region

End Class