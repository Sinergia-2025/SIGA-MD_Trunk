<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfCheques
    Inherits BaseForm

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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.ultraWeekView1 = New Infragistics.Win.UltraWinSchedule.UltraWeekView()
      Me.ultraCalendarLook1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarLook(Me.components)
      Me.panel2 = New System.Windows.Forms.Panel()
      Me.txtTotalCheques = New System.Windows.Forms.TextBox()
      Me.lblTotalCheques = New System.Windows.Forms.Label()
      Me.rdbChequesTerceros = New System.Windows.Forms.RadioButton()
      Me.rdbTodos = New System.Windows.Forms.RadioButton()
      Me.rdbChequesPropios = New System.Windows.Forms.RadioButton()
      Me.pnlRight = New System.Windows.Forms.Panel()
      Me.ultraMonthViewSingle1 = New Infragistics.Win.UltraWinSchedule.UltraMonthViewSingle()
      Me.ultraDayView1 = New Infragistics.Win.UltraWinSchedule.UltraDayView()
      Me.ultraDayView2 = New Infragistics.Win.UltraWinSchedule.UltraDayView()
      Me.ultraWeekView2 = New Infragistics.Win.UltraWinSchedule.UltraWeekView()
      Me.ultraMonthViewMulti1 = New Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti()
      Me.ultraCalendarInfo1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(Me.components)
      Me.panel1 = New System.Windows.Forms.Panel()
      Me.splitter1 = New System.Windows.Forms.Splitter()
      Me.pnlLeft = New System.Windows.Forms.Panel()
      Me.splitter2 = New System.Windows.Forms.Splitter()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      CType(Me.ultraWeekView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panel2.SuspendLayout()
      Me.pnlRight.SuspendLayout()
      CType(Me.ultraMonthViewSingle1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ultraDayView1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ultraDayView2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ultraWeekView2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ultraMonthViewMulti1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panel1.SuspendLayout()
      Me.pnlLeft.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'ultraWeekView1
      '
      Me.ultraWeekView1.CalendarLook = Me.ultraCalendarLook1
      Me.ultraWeekView1.Location = New System.Drawing.Point(168, 24)
      Me.ultraWeekView1.Name = "ultraWeekView1"
      Me.ultraWeekView1.Size = New System.Drawing.Size(128, 384)
      Me.ultraWeekView1.TabIndex = 3
      Me.ultraWeekView1.Visible = False
      '
      'ultraCalendarLook1
      '
      Appearance1.BackColor = System.Drawing.Color.Silver
      Appearance1.FontData.BoldAsString = "True"
      Me.ultraCalendarLook1.DayWithActivityAppearance = Appearance1
      Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
      Appearance2.FontData.BoldAsString = "True"
      Me.ultraCalendarLook1.NoteAppearance = Appearance2
      Appearance3.FontData.BoldAsString = "True"
      Me.ultraCalendarLook1.SelectedAppointmentAppearance = Appearance3
      Appearance4.BackColor = System.Drawing.Color.Tomato
      Me.ultraCalendarLook1.TodayAppearance = Appearance4
      Me.ultraCalendarLook1.ViewStyle = Infragistics.Win.UltraWinSchedule.ViewStyle.VisualStudio2005
      '
      'panel2
      '
      Me.panel2.Controls.Add(Me.txtTotalCheques)
      Me.panel2.Controls.Add(Me.lblTotalCheques)
      Me.panel2.Controls.Add(Me.rdbChequesTerceros)
      Me.panel2.Controls.Add(Me.rdbTodos)
      Me.panel2.Controls.Add(Me.rdbChequesPropios)
      Me.panel2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.panel2.Location = New System.Drawing.Point(0, 297)
      Me.panel2.Name = "panel2"
      Me.panel2.Size = New System.Drawing.Size(197, 123)
      Me.panel2.TabIndex = 2
      '
      'txtTotalCheques
      '
      Me.txtTotalCheques.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold)
      Me.txtTotalCheques.Location = New System.Drawing.Point(74, 81)
      Me.txtTotalCheques.Name = "txtTotalCheques"
      Me.txtTotalCheques.ReadOnly = True
      Me.txtTotalCheques.Size = New System.Drawing.Size(104, 23)
      Me.txtTotalCheques.TabIndex = 3
      Me.txtTotalCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalCheques
      '
      Me.lblTotalCheques.AutoSize = True
      Me.lblTotalCheques.Location = New System.Drawing.Point(18, 91)
      Me.lblTotalCheques.Name = "lblTotalCheques"
      Me.lblTotalCheques.Size = New System.Drawing.Size(31, 13)
      Me.lblTotalCheques.TabIndex = 2
      Me.lblTotalCheques.Text = "Total"
      '
      'rdbChequesTerceros
      '
      Me.rdbChequesTerceros.AutoSize = True
      Me.rdbChequesTerceros.Checked = True
      Me.rdbChequesTerceros.Location = New System.Drawing.Point(21, 56)
      Me.rdbChequesTerceros.Name = "rdbChequesTerceros"
      Me.rdbChequesTerceros.Size = New System.Drawing.Size(112, 17)
      Me.rdbChequesTerceros.TabIndex = 1
      Me.rdbChequesTerceros.TabStop = True
      Me.rdbChequesTerceros.Text = "Cheques Terceros"
      Me.rdbChequesTerceros.UseVisualStyleBackColor = True
      '
      'rdbTodos
      '
      Me.rdbTodos.AutoSize = True
      Me.rdbTodos.Location = New System.Drawing.Point(21, 9)
      Me.rdbTodos.Name = "rdbTodos"
      Me.rdbTodos.Size = New System.Drawing.Size(55, 17)
      Me.rdbTodos.TabIndex = 0
      Me.rdbTodos.Text = "Todos"
      Me.rdbTodos.UseVisualStyleBackColor = True
      '
      'rdbChequesPropios
      '
      Me.rdbChequesPropios.AutoSize = True
      Me.rdbChequesPropios.Location = New System.Drawing.Point(21, 32)
      Me.rdbChequesPropios.Name = "rdbChequesPropios"
      Me.rdbChequesPropios.Size = New System.Drawing.Size(105, 17)
      Me.rdbChequesPropios.TabIndex = 0
      Me.rdbChequesPropios.Text = "Cheques Propios"
      Me.rdbChequesPropios.UseVisualStyleBackColor = True
      '
      'pnlRight
      '
      Me.pnlRight.Controls.Add(Me.ultraWeekView1)
      Me.pnlRight.Controls.Add(Me.ultraMonthViewSingle1)
      Me.pnlRight.Controls.Add(Me.ultraDayView1)
      Me.pnlRight.Controls.Add(Me.ultraDayView2)
      Me.pnlRight.Controls.Add(Me.ultraWeekView2)
      Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlRight.Location = New System.Drawing.Point(201, 29)
      Me.pnlRight.Name = "pnlRight"
      Me.pnlRight.Size = New System.Drawing.Size(612, 420)
      Me.pnlRight.TabIndex = 12
      '
      'ultraMonthViewSingle1
      '
      Me.ultraMonthViewSingle1.CalendarLook = Me.ultraCalendarLook1
      Me.ultraMonthViewSingle1.Location = New System.Drawing.Point(304, 24)
      Me.ultraMonthViewSingle1.Name = "ultraMonthViewSingle1"
      Me.ultraMonthViewSingle1.Size = New System.Drawing.Size(120, 384)
      Me.ultraMonthViewSingle1.TabIndex = 2
      Me.ultraMonthViewSingle1.Visible = False
      '
      'ultraDayView1
      '
      Me.ultraDayView1.CalendarLook = Me.ultraCalendarLook1
      Me.ultraDayView1.HideTimeSlotDescriptorArea = True
      Me.ultraDayView1.Location = New System.Drawing.Point(16, 24)
      Me.ultraDayView1.Name = "ultraDayView1"
      Me.ultraDayView1.Size = New System.Drawing.Size(136, 384)
      Me.ultraDayView1.TabIndex = 1
      Me.ultraDayView1.TimeSlotInterval = Infragistics.Win.UltraWinSchedule.TimeSlotInterval.SixtyMinutes
      Me.ultraDayView1.Visible = False
      '
      'ultraDayView2
      '
      Me.ultraDayView2.CalendarLook = Me.ultraCalendarLook1
      Me.ultraDayView2.Location = New System.Drawing.Point(24, 24)
      Me.ultraDayView2.Name = "ultraDayView2"
      Me.ultraDayView2.Size = New System.Drawing.Size(136, 104)
      Me.ultraDayView2.TabIndex = 1
      Me.ultraDayView2.Text = "ultraDayView2"
      Me.ultraDayView2.Visible = False
      '
      'ultraWeekView2
      '
      Me.ultraWeekView2.CalendarLook = Me.ultraCalendarLook1
      Me.ultraWeekView2.Location = New System.Drawing.Point(176, 24)
      Me.ultraWeekView2.Name = "ultraWeekView2"
      Me.ultraWeekView2.Size = New System.Drawing.Size(128, 104)
      Me.ultraWeekView2.TabIndex = 3
      Me.ultraWeekView2.Visible = False
      '
      'ultraMonthViewMulti1
      '
      Me.ultraMonthViewMulti1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ultraMonthViewMulti1.BackColor = System.Drawing.SystemColors.Window
      Me.ultraMonthViewMulti1.CalendarInfo = Me.ultraCalendarInfo1
      Me.ultraMonthViewMulti1.CalendarLook = Me.ultraCalendarLook1
      Me.ultraMonthViewMulti1.DayOfWeekCaptionStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekCaptionStyle.FirstTwoLetters
      Me.ultraMonthViewMulti1.Location = New System.Drawing.Point(12, 8)
      Me.ultraMonthViewMulti1.MonthDimensions = New System.Drawing.Size(1, 2)
      Me.ultraMonthViewMulti1.MonthPadding = New System.Drawing.Size(3, 3)
      Me.ultraMonthViewMulti1.Name = "ultraMonthViewMulti1"
      Me.ultraMonthViewMulti1.Size = New System.Drawing.Size(176, 248)
      Me.ultraMonthViewMulti1.TabIndex = 0
      Me.ultraMonthViewMulti1.UseAlternateSelectedDateRanges = True
      '
      'ultraCalendarInfo1
      '
      '
      'panel1
      '
      Me.panel1.BackColor = System.Drawing.Color.White
      Me.panel1.Controls.Add(Me.ultraMonthViewMulti1)
      Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.panel1.Location = New System.Drawing.Point(0, 0)
      Me.panel1.Name = "panel1"
      Me.panel1.Size = New System.Drawing.Size(197, 293)
      Me.panel1.TabIndex = 0
      '
      'splitter1
      '
      Me.splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(254, Byte), Integer))
      Me.splitter1.Location = New System.Drawing.Point(197, 29)
      Me.splitter1.Name = "splitter1"
      Me.splitter1.Size = New System.Drawing.Size(4, 420)
      Me.splitter1.TabIndex = 11
      Me.splitter1.TabStop = False
      '
      'pnlLeft
      '
      Me.pnlLeft.Controls.Add(Me.panel2)
      Me.pnlLeft.Controls.Add(Me.splitter2)
      Me.pnlLeft.Controls.Add(Me.panel1)
      Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
      Me.pnlLeft.Location = New System.Drawing.Point(0, 29)
      Me.pnlLeft.Name = "pnlLeft"
      Me.pnlLeft.Size = New System.Drawing.Size(197, 420)
      Me.pnlLeft.TabIndex = 10
      '
      'splitter2
      '
      Me.splitter2.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(254, Byte), Integer))
      Me.splitter2.Dock = System.Windows.Forms.DockStyle.Top
      Me.splitter2.Enabled = False
      Me.splitter2.Location = New System.Drawing.Point(0, 293)
      Me.splitter2.Name = "splitter2"
      Me.splitter2.Size = New System.Drawing.Size(197, 4)
      Me.splitter2.TabIndex = 1
      Me.splitter2.TabStop = False
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(813, 29)
      Me.tstBarra.TabIndex = 14
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'InfCheques
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(813, 449)
      Me.Controls.Add(Me.pnlRight)
      Me.Controls.Add(Me.splitter1)
      Me.Controls.Add(Me.pnlLeft)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "InfCheques"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informes de Cheques"
      CType(Me.ultraWeekView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panel2.ResumeLayout(False)
      Me.panel2.PerformLayout()
      Me.pnlRight.ResumeLayout(False)
      CType(Me.ultraMonthViewSingle1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ultraDayView1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ultraDayView2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ultraWeekView2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ultraMonthViewMulti1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panel1.ResumeLayout(False)
      Me.pnlLeft.ResumeLayout(False)
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ultraWeekView1 As Infragistics.Win.UltraWinSchedule.UltraWeekView
   Friend WithEvents ultraCalendarLook1 As Infragistics.Win.UltraWinSchedule.UltraCalendarLook
   Friend WithEvents panel2 As System.Windows.Forms.Panel
   Friend WithEvents pnlRight As System.Windows.Forms.Panel
   Friend WithEvents ultraMonthViewSingle1 As Infragistics.Win.UltraWinSchedule.UltraMonthViewSingle
   Friend WithEvents ultraDayView1 As Infragistics.Win.UltraWinSchedule.UltraDayView
   Friend WithEvents ultraDayView2 As Infragistics.Win.UltraWinSchedule.UltraDayView
   Friend WithEvents ultraWeekView2 As Infragistics.Win.UltraWinSchedule.UltraWeekView
   Friend WithEvents ultraMonthViewMulti1 As Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti
   Friend WithEvents panel1 As System.Windows.Forms.Panel
   Friend WithEvents splitter1 As System.Windows.Forms.Splitter
   Friend WithEvents ultraCalendarInfo1 As Infragistics.Win.UltraWinSchedule.UltraCalendarInfo
   Friend WithEvents pnlLeft As System.Windows.Forms.Panel
   Friend WithEvents splitter2 As System.Windows.Forms.Splitter
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents rdbChequesTerceros As System.Windows.Forms.RadioButton
   Friend WithEvents rdbChequesPropios As System.Windows.Forms.RadioButton
   Friend WithEvents txtTotalCheques As System.Windows.Forms.TextBox
   Friend WithEvents lblTotalCheques As System.Windows.Forms.Label
   Friend WithEvents rdbTodos As System.Windows.Forms.RadioButton
End Class
