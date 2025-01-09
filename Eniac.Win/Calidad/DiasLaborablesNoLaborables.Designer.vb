<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiasLaborablesNoLaborables
   Inherits System.Windows.Forms.Form

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim DayOfWeek15 As Infragistics.Win.UltraWinSchedule.DayOfWeek = New Infragistics.Win.UltraWinSchedule.DayOfWeek(System.DayOfWeek.Sunday)
      Dim DayOfWeek16 As Infragistics.Win.UltraWinSchedule.DayOfWeek = New Infragistics.Win.UltraWinSchedule.DayOfWeek(System.DayOfWeek.Monday)
      Dim DayOfWeek17 As Infragistics.Win.UltraWinSchedule.DayOfWeek = New Infragistics.Win.UltraWinSchedule.DayOfWeek(System.DayOfWeek.Tuesday)
      Dim DayOfWeek18 As Infragistics.Win.UltraWinSchedule.DayOfWeek = New Infragistics.Win.UltraWinSchedule.DayOfWeek(System.DayOfWeek.Wednesday)
      Dim DayOfWeek19 As Infragistics.Win.UltraWinSchedule.DayOfWeek = New Infragistics.Win.UltraWinSchedule.DayOfWeek(System.DayOfWeek.Thursday)
      Dim DayOfWeek20 As Infragistics.Win.UltraWinSchedule.DayOfWeek = New Infragistics.Win.UltraWinSchedule.DayOfWeek(System.DayOfWeek.Friday)
      Dim DayOfWeek21 As Infragistics.Win.UltraWinSchedule.DayOfWeek = New Infragistics.Win.UltraWinSchedule.DayOfWeek(System.DayOfWeek.Saturday)
      Dim MonthOfYear25 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.January)
      Dim MonthOfYear26 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.February)
      Dim MonthOfYear27 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.March)
      Dim MonthOfYear28 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.April)
      Dim MonthOfYear29 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.May)
      Dim MonthOfYear30 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.June)
      Dim MonthOfYear31 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.July)
      Dim MonthOfYear32 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.August)
      Dim MonthOfYear33 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.September)
      Dim MonthOfYear34 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.October)
      Dim MonthOfYear35 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.November)
      Dim MonthOfYear36 As Infragistics.Win.UltraWinSchedule.MonthOfYear = New Infragistics.Win.UltraWinSchedule.MonthOfYear(Infragistics.Win.UltraWinSchedule.YearMonthEnum.December)
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiasLaborablesNoLaborables))
      Me.rbtLaborable = New System.Windows.Forms.RadioButton()
      Me.rbtNoLaborable = New System.Windows.Forms.RadioButton()
      Me.Label9 = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.Label1 = New Eniac.Controles.Label()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.btnGenerar = New System.Windows.Forms.Button()
      Me.btnActualizar = New System.Windows.Forms.Button()
      Me.UltraCalendarLook1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarLook(Me.components)
      Me.UltraMonthViewMulti2 = New Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti()
      Me.calendarInfo = New Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(Me.components)
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.tspRutas = New System.Windows.Forms.ToolStrip()
      CType(Me.UltraMonthViewMulti2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tspRutas.SuspendLayout()
      Me.SuspendLayout()
      '
      'rbtLaborable
      '
      Me.rbtLaborable.AutoSize = True
      Me.rbtLaborable.Location = New System.Drawing.Point(455, 102)
      Me.rbtLaborable.Name = "rbtLaborable"
      Me.rbtLaborable.Size = New System.Drawing.Size(72, 17)
      Me.rbtLaborable.TabIndex = 5
      Me.rbtLaborable.TabStop = True
      Me.rbtLaborable.Text = "Laborable"
      Me.rbtLaborable.UseVisualStyleBackColor = True
      '
      'rbtNoLaborable
      '
      Me.rbtNoLaborable.AutoSize = True
      Me.rbtNoLaborable.Location = New System.Drawing.Point(455, 126)
      Me.rbtNoLaborable.Name = "rbtNoLaborable"
      Me.rbtNoLaborable.Size = New System.Drawing.Size(89, 17)
      Me.rbtNoLaborable.TabIndex = 6
      Me.rbtNoLaborable.TabStop = True
      Me.rbtNoLaborable.Text = "No Laborable"
      Me.rbtNoLaborable.UseVisualStyleBackColor = True
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.LabelAsoc = Nothing
      Me.Label9.Location = New System.Drawing.Point(10, 52)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(40, 13)
      Me.Label9.TabIndex = 26
      Me.Label9.Text = "Fecha "
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = "Value"
      Me.dtpDesde.BindearPropiedadEntidad = "FechaExcepcion"
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = True
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Nothing
      Me.dtpDesde.Location = New System.Drawing.Point(52, 49)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpDesde.TabIndex = 25
      Me.dtpDesde.Tag = "000"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(162, 52)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(35, 13)
      Me.Label1.TabIndex = 27
      Me.Label1.Text = "Hasta"
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = "Value"
      Me.dtpHasta.BindearPropiedadEntidad = "FechaExcepcion"
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = True
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Nothing
      Me.dtpHasta.Location = New System.Drawing.Point(203, 49)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpHasta.TabIndex = 28
      Me.dtpHasta.Tag = "000"
      '
      'btnGenerar
      '
      Me.btnGenerar.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
      Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGenerar.Location = New System.Drawing.Point(318, 34)
      Me.btnGenerar.Name = "btnGenerar"
      Me.btnGenerar.Size = New System.Drawing.Size(92, 47)
      Me.btnGenerar.TabIndex = 29
      Me.btnGenerar.Text = "Generar"
      Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGenerar.UseVisualStyleBackColor = True
      '
      'btnActualizar
      '
      Me.btnActualizar.Image = Global.Eniac.Win.My.Resources.Resources.play_save_321
      Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnActualizar.Location = New System.Drawing.Point(453, 151)
      Me.btnActualizar.Name = "btnActualizar"
      Me.btnActualizar.Size = New System.Drawing.Size(92, 47)
      Me.btnActualizar.TabIndex = 30
      Me.btnActualizar.Text = "Modificar"
      Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnActualizar.UseVisualStyleBackColor = True
      '
      'UltraCalendarLook1
      '
      Me.UltraCalendarLook1.ViewStyle = Infragistics.Win.UltraWinSchedule.ViewStyle.Office2007
      '
      'UltraMonthViewMulti2
      '
      Me.UltraMonthViewMulti2.BackColor = System.Drawing.SystemColors.Window
      Me.UltraMonthViewMulti2.CalendarInfo = Me.calendarInfo
      Me.UltraMonthViewMulti2.CalendarLook = Me.UltraCalendarLook1
      Me.UltraMonthViewMulti2.Location = New System.Drawing.Point(12, 96)
      Me.UltraMonthViewMulti2.MonthDimensions = New System.Drawing.Size(3, 1)
      Me.UltraMonthViewMulti2.Name = "UltraMonthViewMulti2"
      Me.UltraMonthViewMulti2.OverrideFontSettings = False
      Me.UltraMonthViewMulti2.Size = New System.Drawing.Size(426, 124)
      Me.UltraMonthViewMulti2.TabIndex = 32
      Me.UltraMonthViewMulti2.UseAppStyling = False
      Me.UltraMonthViewMulti2.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
      '
      'calendarInfo
      '
      Me.calendarInfo.AlternateSelectTypeDay = Infragistics.Win.UltraWinSchedule.SelectType.[Single]
      Me.calendarInfo.AppointmentActionsEnabled = False
      DayOfWeek15.IsWorkDay = True
      DayOfWeek15.LongDescription = "domingo"
      DayOfWeek15.ShortDescription = "dom"
      DayOfWeek16.LongDescription = "lunes"
      DayOfWeek16.ShortDescription = "lun"
      DayOfWeek17.LongDescription = "martes"
      DayOfWeek17.ShortDescription = "mar"
      DayOfWeek18.LongDescription = "miércoles"
      DayOfWeek18.ShortDescription = "mie"
      DayOfWeek19.LongDescription = "jueves"
      DayOfWeek19.ShortDescription = "jue"
      DayOfWeek20.LongDescription = "viernes"
      DayOfWeek20.ShortDescription = "vie"
      DayOfWeek21.IsWorkDay = True
      DayOfWeek21.LongDescription = "sábado"
      DayOfWeek21.ShortDescription = "sáb"
      Me.calendarInfo.DaysOfWeek.Add(DayOfWeek15)
      Me.calendarInfo.DaysOfWeek.Add(DayOfWeek16)
      Me.calendarInfo.DaysOfWeek.Add(DayOfWeek17)
      Me.calendarInfo.DaysOfWeek.Add(DayOfWeek18)
      Me.calendarInfo.DaysOfWeek.Add(DayOfWeek19)
      Me.calendarInfo.DaysOfWeek.Add(DayOfWeek20)
      Me.calendarInfo.DaysOfWeek.Add(DayOfWeek21)
      Me.calendarInfo.FirstDayOfWeek = Infragistics.Win.UltraWinSchedule.FirstDayOfWeek.Monday
      MonthOfYear25.LongDescription = "Enero"
      MonthOfYear25.ShortDescription = "Ene"
      MonthOfYear26.LongDescription = "Febrero"
      MonthOfYear26.ShortDescription = "Feb"
      MonthOfYear27.LongDescription = "Marzo"
      MonthOfYear27.ShortDescription = "Mar"
      MonthOfYear28.LongDescription = "Abril"
      MonthOfYear28.ShortDescription = "Abr"
      MonthOfYear29.LongDescription = "Mayo"
      MonthOfYear29.ShortDescription = "May"
      MonthOfYear30.LongDescription = "Junio"
      MonthOfYear30.ShortDescription = "Jun"
      MonthOfYear31.LongDescription = "Julio"
      MonthOfYear31.ShortDescription = "Jul"
      MonthOfYear32.LongDescription = "Agosto"
      MonthOfYear32.ShortDescription = "Ago"
      MonthOfYear33.LongDescription = "Septiembre"
      MonthOfYear33.ShortDescription = "Sep"
      MonthOfYear34.LongDescription = "Octubre"
      MonthOfYear34.ShortDescription = "Oct"
      MonthOfYear35.LongDescription = "Noviembre"
      MonthOfYear35.ShortDescription = "Nov"
      MonthOfYear36.LongDescription = "Diciembre"
      MonthOfYear36.ShortDescription = "Dic"
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear25)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear26)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear27)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear28)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear29)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear30)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear31)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear32)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear33)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear34)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear35)
      Me.calendarInfo.MonthsOfYear.Add(MonthOfYear36)
      Me.calendarInfo.SelectTypeActivity = Infragistics.Win.UltraWinSchedule.SelectType.[Single]
      Me.calendarInfo.SelectTypeDay = Infragistics.Win.UltraWinSchedule.SelectType.[Single]
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(101, 26)
      Me.tsbRefrescar.Text = "&Refrescar(F5)"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
      Me.tsbCerrar.Text = "&Cerrar"
      '
      'tspRutas
      '
      Me.tspRutas.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tspRutas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator3, Me.tsbCerrar})
      Me.tspRutas.Location = New System.Drawing.Point(0, 0)
      Me.tspRutas.Name = "tspRutas"
      Me.tspRutas.Size = New System.Drawing.Size(588, 29)
      Me.tspRutas.TabIndex = 4
      Me.tspRutas.Text = "ToolStrip1"
      '
      'DiasLaborablesNoLaborables
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(588, 238)
      Me.Controls.Add(Me.UltraMonthViewMulti2)
      Me.Controls.Add(Me.btnActualizar)
      Me.Controls.Add(Me.btnGenerar)
      Me.Controls.Add(Me.dtpHasta)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.dtpDesde)
      Me.Controls.Add(Me.rbtNoLaborable)
      Me.Controls.Add(Me.rbtLaborable)
      Me.Controls.Add(Me.tspRutas)
      Me.Name = "DiasLaborablesNoLaborables"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Dias Laborables/NoLaborables"
      CType(Me.UltraMonthViewMulti2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tspRutas.ResumeLayout(False)
      Me.tspRutas.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents rbtNoLaborable As RadioButton
   Friend WithEvents rbtLaborable As RadioButton
   Friend WithEvents btnGenerar As Button
   Friend WithEvents dtpHasta As Controles.DateTimePicker
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents Label9 As Controles.Label
   Friend WithEvents dtpDesde As Controles.DateTimePicker
   Friend WithEvents btnActualizar As Button
   Friend WithEvents UltraCalendarLook1 As UltraWinSchedule.UltraCalendarLook
   Friend WithEvents UltraMonthViewMulti2 As UltraWinSchedule.UltraMonthViewMulti
   Friend WithEvents tsbRefrescar As ToolStripButton
   Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
   Friend WithEvents tsbCerrar As ToolStripButton
   Friend WithEvents tspRutas As ToolStrip
   Friend WithEvents calendarInfo As UltraWinSchedule.UltraCalendarInfo
End Class
