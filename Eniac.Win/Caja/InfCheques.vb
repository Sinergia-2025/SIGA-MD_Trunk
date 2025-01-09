Option Infer On
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinSchedule
Public Class InfCheques

   Private _cheques As DataTable

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      '	Set all of the UltraWinScheduleBase-derived controls to use
      '	the same UltraCalendarInfo component so that all date and
      '	activity information is automatically coordinated between the
      '	different controls
      Me.ultraDayView1.CalendarInfo = Me.ultraCalendarInfo1
      Me.ultraDayView1.CalendarLook = Me.ultraCalendarLook1

      Me.ultraMonthViewMulti1.CalendarInfo = Me.ultraCalendarInfo1
      Me.ultraWeekView1.CalendarInfo = Me.ultraCalendarInfo1
      Me.ultraMonthViewSingle1.CalendarInfo = Me.ultraCalendarInfo1

      '	Set the 'UseAlternateSelectedDateRanges' property to true
      '	for the UltraDayView and UltraMonthViewMulti controls, and
      '	false for the UltraWeekView and UltraMonthViewSingle controls.
      '
      '	When dates are selected in the UltraMonthViewMulti control,
      '	the changes will be reflected in the UltraDayView control, but
      '	not in the UltraWeekView and UltraMonthViewSingle controls, which
      '	respond only to changes in the SelectedDateRanges collection.
      '	We do this to simulate the MS Outlook date navigation model (see
      '	the handler for the AfterAlternateSelectedDateRangeChange event).
      '
      Me.ultraMonthViewMulti1.UseAlternateSelectedDateRanges = True
      Me.ultraDayView1.UseAlternateSelectedDateRanges = True

      Me.ultraWeekView1.UseAlternateSelectedDateRanges = True
      Me.ultraMonthViewSingle1.UseAlternateSelectedDateRanges = True

      '	Make the ActiveDay initially selected in both the SelectedDateRanges
      '	collection and the AlternateSelectedDateRanges collection.
      Me.ultraCalendarInfo1.ActiveDay.Selected = True
      Me.ultraCalendarInfo1.ActiveDay.SelectedInAlternateDateRanges = True

      '	Use the MaxAlternateSelectedDays property to restrict the number
      '	of days that can be selected in the AlternateSelectedDateRanges
      '	collection. MS Outlook allows up to 6 weeks, so we'll go with that.
      Me.ultraCalendarInfo1.MaxAlternateSelectedDays = 42

      '	The selection type can be set differently for the
      '	SelectedDateRanges and AlternateSelectedDateRanges
      '	collections we will set the AlternateSelectedDateRanges
      '	collection to use the 'Extended' selection type.
      Me.ultraCalendarInfo1.SelectTypeActivity = SelectType.Extended

      Me.CargaCheques()

      'Me.ultraCalendarLook1.DayWithActivityAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

   End Sub

   Private Sub CargaCheques()
      Dim regl As Reglas.Cheques = New Reglas.Cheques()
      Dim esPropio As Boolean? = Nothing
      If rdbChequesPropios.Checked Then
         esPropio = True
      ElseIf rdbChequesTerceros.Checked Then
         esPropio = False
      End If

      Me._cheques = regl.GetInfCheques(Eniac.Entidades.Usuario.Actual.Sucursal.Id, esPropio)

      'Dim fech As DateTime
      'For Each dr As DataRow In Me._cheques.Rows
      '   If fech.ToString("yyyyMMdd") = DateTime.Parse(dr("FechaCobro").ToString()).ToString("yyyyMMdd") Then
      '      Continue For
      '   End If
      '   Me.ultraCalendarInfo1.Notes.Add(DateTime.Parse(dr("FechaCobro").ToString()))
      '   fech = DateTime.Parse(dr("FechaCobro").ToString())
      'Next
      Me.CargarCitas()
   End Sub

   Private Sub CargarCitas()
      Me.ultraCalendarInfo1.Appointments.Clear()
      Dim fechaCobro As DateTime
      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim chq = From cheque In Me._cheques.AsEnumerable()
                  Order By cheque.Field(Of DateTime)("FechaCobro") Ascending
               Select cheque

      Dim totales As Dictionary(Of Date, Decimal) = New Dictionary(Of Date, Decimal)()

      'recorro todos los cheques entre las fechas seleccionadas
      For Each dr As DataRow In chq
         stb.Length = 0
         With stb
            .AppendLine(dr(Entidades.Cheque.Columnas.NumeroCheque.ToString()).ToString())
            .AppendLine(dr("Titular").ToString())
            .AppendLine(dr("NombreBanco").ToString())
            .AppendLine(dr("Localidad").ToString())
         End With
         fechaCobro = DateTime.Parse(dr(Entidades.Cheque.Columnas.FechaCobro.ToString()).ToString()).Date
         Dim stbSubject As StringBuilder = New StringBuilder()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cheque.Columnas.IdCliente.ToString()).ToString()) Then
            stbSubject.AppendFormat("C: {0} - {1} - ",
                                    dr(Entidades.Cliente.Columnas.CodigoCliente.ToString()),
                                    dr(Entidades.Cliente.Columnas.NombreCliente.ToString()))
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Cheque.Columnas.IdProveedor.ToString()).ToString()) Then
            stbSubject.AppendFormat("P: {0} - {1} - ",
                                    dr(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()),
                                    dr(Entidades.Proveedor.Columnas.NombreProveedor.ToString()))
         End If
         stbSubject.AppendFormat("{0:N2}", Decimal.Parse(dr(Entidades.Cheque.Columnas.Importe.ToString()).ToString()))
         Dim ap As Infragistics.Win.UltraWinSchedule.Appointment
         ap = AppoinmentColor(Me.GetAppointment(fechaCobro,
                                                 fechaCobro,
                                                 stbSubject.ToString(),
                                                 stb.ToString()),
                              Decimal.Parse(dr(Entidades.Cheque.Columnas.Importe.ToString()).ToString()))
         Me.ultraCalendarInfo1.Appointments.Add(ap)

         'acumulo el valor de cheques por día e ingreso 
         If Not totales.ContainsKey(fechaCobro.Date) Then
            totales.Add(fechaCobro.Date, 0)
         End If
         totales(fechaCobro.Date) = totales(fechaCobro.Date) + Decimal.Parse(dr(Entidades.Cheque.Columnas.Importe.ToString()).ToString())
      Next

      For Each total As KeyValuePair(Of Date, Decimal) In totales
         Me.ultraCalendarInfo1.Appointments.Add(AppoinmentColor(Me.GetAppointment(total.Key, total.Key, String.Format("TOTAL: {0:N2}", total.Value), String.Empty),
                                                                total.Value))
      Next

      CalculaTotal()
   End Sub

   Private Function AppoinmentColor(ap As Appointment, value As Decimal) As Appointment
      If rdbChequesPropios.Checked Then
         ap.Appearance.BackColor = Color.OrangeRed
      ElseIf rdbChequesTerceros.Checked Then
         ap.Appearance.BackColor = Color.LightGreen
      Else
         If value < 0 Then
            ap.Appearance.BackColor = Color.OrangeRed
         Else
            ap.Appearance.BackColor = Color.LightGreen
         End If
      End If
      Return ap
   End Function

   Private Sub CalculaTotal()
      Dim fechaDesde As DateTime
      Dim fechaHasta As DateTime

      fechaDesde = Me.ultraCalendarInfo1.ActiveDay.Date
      fechaHasta = Me.ultraCalendarInfo1.ActiveDay.Date.AddDays(1)

      If Me.ultraCalendarInfo1.AlternateSelectedDateRanges.Count > 0 Then
         fechaDesde = Me.ultraCalendarInfo1.AlternateSelectedDateRanges(0).FirstDay.Date
         fechaHasta = Me.ultraCalendarInfo1.AlternateSelectedDateRanges(0).LastDay.Date.AddDays(1)
      End If

      Dim totalCheques As Decimal = 0
      Dim chq = From cheque In Me._cheques.AsEnumerable()
               Where cheque.Field(Of DateTime)("FechaCobro") >= fechaDesde _
                  And cheque.Field(Of DateTime)("FechaCobro") <= fechaHasta
                  Order By cheque.Field(Of DateTime)("FechaCobro") Ascending
               Select cheque

      For Each dr As DataRow In chq
         'acumulo el valor de todos los cheques
         totalCheques += Decimal.Parse(dr(Entidades.Cheque.Columnas.Importe.ToString()).ToString())
      Next
      'cargo el total general de cheques seleccionados
      Me.txtTotalCheques.Text = totalCheques.ToString("N2")
   End Sub

   Private Function GetAppointment(fechaDesde As DateTime, fechaHasta As DateTime, subject As String, description As String) As Infragistics.Win.UltraWinSchedule.Appointment
      Dim ap As Infragistics.Win.UltraWinSchedule.Appointment
      ap = New Infragistics.Win.UltraWinSchedule.Appointment(fechaDesde, fechaHasta.AddMinutes(15))
      ap.Subject = subject
      ap.AllDayEvent = True
      ap.Visible = True
      ap.Locked = True
      ap.Description = description

      Return ap
   End Function

   Private Sub ultraCalendarInfo1_AfterAlternateSelectedDateRangeChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles ultraCalendarInfo1.AfterAlternateSelectedDateRangeChange
      Try
         Dim controlToDisplay As UltraScheduleControlBase = Nothing

         '	Get a reference to the AlternateSelectedDateRanges collection
         '	Note that the AlternateSelectedDateRanges collection is of the same
         '	type as the UltraCalendarInfo's SelectedDateRanges collection
         Dim selectedDateRanges As SelectedDateRanges = Me.ultraCalendarInfo1.AlternateSelectedDateRanges

         '	Get the total number of selected days in the 'alternate' selection
         Dim selectedDaysCount As Int32 = selectedDateRanges.SelectedDaysCount

         '	If there are one or less days selected, we will display the 
         '	UltraDayView control.
         If selectedDaysCount <= 1 Then
            controlToDisplay = Me.ultraDayView1
         Else

            '	Determine whether we are dealing with a contiguous selection.
            '	since the SelectedDateRanges class handles defragmenting its
            '	contents automatically, we know the selection is contiguous
            '	if the count of the collection is one. This is because members
            '	of the AlternateSelectedDateRanges collection (DateRange objects)
            '	can only handle ranges that do not contain any 'gaps', so if there
            '	is only one member, there are no gaps, and as such, the selection
            '	must be contiguous
            Dim isContiguous As Boolean = selectedDateRanges.Count = 1

            '	Determine whether the selection consists of an entire week or weeks
            If isContiguous AndAlso selectedDaysCount Mod 8 = 0 AndAlso _
                selectedDateRanges(0).StartDate.DayOfWeek = Me.ultraCalendarInfo1.FirstDayOfWeekResolved Then

               '	If there is exactly one week selected, we will display
               '	the UltraWeekView control. If there is anywhere from 2
               '	to 6 weeks selected, we will display the UltraMonthViewSingle control
               If selectedDaysCount = 8 Then
                  controlToDisplay = Me.ultraWeekView1
               Else
                  Me.ultraMonthViewSingle1.VisibleWeeks = Convert.ToInt32((selectedDaysCount / 8))
                  controlToDisplay = Me.ultraMonthViewSingle1
               End If
               '	If there are 14 or fewer days selected, we will display the UltraDayView control
            ElseIf selectedDaysCount <= 14 Then
               controlToDisplay = Me.ultraDayView1
            Else

               '	In all other cases, we display the UltraMonthViewSingle control
               controlToDisplay = Me.ultraMonthViewSingle1

               '	Get the first and last dates in the selection, and determine
               '	the total number of days the selection spans
               Dim startDate As DateTime = selectedDateRanges(0).StartDate
               Dim endDate As DateTime = selectedDateRanges(selectedDateRanges.Count - 1).EndDate
               Dim daysSpanned As Int32 = Convert.ToInt32(endDate.Subtract(startDate).TotalDays + 1)

               '	Set the UltraMonthViewSingle control's VisibleWeeks
               '	property to a value that is large enough to display
               '	the entire selection
               Me.ultraMonthViewSingle1.VisibleWeeks = Convert.ToInt32(daysSpanned / 8)

            End If

         End If

         '	Display the appropriate control
         If Not controlToDisplay Is Nothing Then

            Me.ultraDayView1.Visible = False
            Me.ultraWeekView1.Visible = False
            Me.ultraMonthViewSingle1.Visible = False

            controlToDisplay.Dock = DockStyle.Fill
            controlToDisplay.Visible = True
         End If

         '	Since the UltraWeekView and UltraMonthViewSingle controls are not
         '	'listening' to changes in the alternate date range selection, we must
         '	bring the selected days into view manually.
         If controlToDisplay Is Me.ultraWeekView1 Then
            Me.ultraWeekView1.ScrollDayIntoView(selectedDateRanges(0).StartDate)
         ElseIf controlToDisplay Is Me.ultraMonthViewSingle1 Then
            Me.ultraMonthViewSingle1.ScrollDayIntoView(selectedDateRanges(0).StartDate, True)
         End If

         CalculaTotal()
         'Me.CargarCitas()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub ultraCalendarInfo1_BeforeAlternateSelectedDateRangeChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeSelectedDateRangeChangeEventArgs) Handles ultraCalendarInfo1.BeforeAlternateSelectedDateRangeChange
      ' Cancel the slection change if the "Cancel Selection" checkbox is checked
      e.Cancel = False

      '	Allow the message box to be displayed (when MaxAlternateSelectedDays
      '	is exceeded) if the "Display Message" checkbox is Checked
      e.DisplayMaxSelectedDaysErrorMsg = True

      '	If MaxAlternateSelectedDays is exceeded, beep
      If e.WasMaxSelectedDaysExceeded Then Beep()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If Me.ultraCalendarInfo1.Appointments.Count > 0 Then
            Me.ultraCalendarInfo1.Appointments.Clear()
         End If
         If Me.ultraCalendarInfo1.Notes.Count > 0 Then
            Me.ultraCalendarInfo1.Notes.Clear()
         End If
         Me.txtTotalCheques.Text = "0.00"
         Me.CargaCheques()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub rdbChequesPropios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbChequesPropios.CheckedChanged, rdbChequesTerceros.CheckedChanged, rdbTodos.CheckedChanged
      Me.tsbRefrescar.PerformClick()
   End Sub

End Class