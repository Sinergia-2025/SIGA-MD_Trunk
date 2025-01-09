Imports Infragistics.Win.UltraWinSchedule
Public Class DiasLaborablesNoLaborables

   Private _Dias As DateTime()
   Private _ActiveDay As String = String.Empty

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         'ultracalendarcombo1.value = ultraviewsingle.DayThatUserClickedOn
         Me.UltraCalendarLook1.ActiveDayAppearance.BackColor = Color.Yellow
         Me.dtpDesde.Value = Date.Today.AddMonths(-1)


         Me.ColorLaborableNoLaborable()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"
   Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
      Try

         Me.Cursor = Cursors.WaitCursor

         Dim starting As DateTime = New DateTime()
         starting = Date.Parse(dtpDesde.Value.ToString("dd/MM/yyyy"))
         Dim ending As DateTime = New DateTime()
         ending = Date.Parse(dtpHasta.Value.ToString("dd/MM/yyyy"))

         _Dias = GetDatesBetween(starting, ending).ToArray()

         Dim oDias As Reglas.DiasLaborablesNoLaborables = New Reglas.DiasLaborablesNoLaborables()
         oDias.GrabarDias(_Dias)

         MessageBox.Show("Generación exitosa!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Me.Refrescar()

         ' UltraCalendarInfo1.Appointments.Add(Date.Today, "Laborable")

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbCerrar_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub calendarInfo_AfterActiveDayChanged(sender As Object, e As AfterActiveDayChangedEventArgs) Handles calendarInfo.AfterActiveDayChanged
      Try
         _ActiveDay = Me.calendarInfo.ActiveDay.Date.ToString("dd/MM/yyyy")

         Dim DiaLNL As Entidades.DiaLaborableNoLaborable = New Reglas.DiasLaborablesNoLaborables().GetUno(Date.Parse(_ActiveDay.ToString()))
         If DiaLNL.Laborable Then
            Me.rbtLaborable.Checked = True
         Else
            Me.rbtNoLaborable.Checked = True
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
      Try

         Dim odiasLNL As Reglas.DiasLaborablesNoLaborables = New Reglas.DiasLaborablesNoLaborables
         Dim DiaLNL As Entidades.DiaLaborableNoLaborable = New Reglas.DiasLaborablesNoLaborables().GetUno(Date.Parse(_ActiveDay.ToString()))
         If Me.rbtLaborable.Checked Then
            DiaLNL.Laborable = True
         Else
            DiaLNL.Laborable = False
         End If
         odiasLNL._Actualiza(DiaLNL)

         Me.Refrescar()

         MessageBox.Show("Modificación exitosa!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Métodos"
   Private Function GetDatesBetween(FechaDesde As Date, fechaHasta As Date) As Date()

      Dim allDates As List(Of DateTime) = New List(Of DateTime)()
      Dim fecha As DateTime = FechaDesde
      While fecha <= fechaHasta
         allDates.Add(fecha)
         fecha = fecha.AddDays(1)
      End While

      Return allDates.ToArray()

   End Function

   Private Sub ColorLaborableNoLaborable()
      Dim odiasLNL As Reglas.DiasLaborablesNoLaborables = New Reglas.DiasLaborablesNoLaborables
      Dim DiasLNL As DataTable = odiasLNL.GetDiasLNL(Me.dtpDesde.Value, Me.dtpHasta.Value)

      For Each dr As DataRow In DiasLNL.Rows

         If Boolean.Parse(dr("Laborable").ToString()) Then
            UltraCalendarLook1.DaysOfYearLook.Item(Date.Parse(dr("dia").ToString())).Appearance.BackColor = Color.Green
         Else
            UltraCalendarLook1.DaysOfYearLook.Item(Date.Parse(dr("dia").ToString())).Appearance.BackColor = Color.Red
         End If

      Next
   End Sub

   Private Sub Refrescar()
      calendarInfo.ActiveDay = calendarInfo.GetDay(Date.Today(), True)
      calendarInfo.ActiveDay.Activated = True

      Me.dtpDesde.Value = Date.Today.AddMonths(-1)

      Me.ColorLaborableNoLaborable()
   End Sub

#End Region

End Class