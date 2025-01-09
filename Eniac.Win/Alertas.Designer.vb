<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Alertas
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
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Key")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MensajeDeAlerta")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Grupo")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Color")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MostrarEnLista")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MostrarPopUp")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenPrioridad")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tag")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlertaSistema")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlertaSistemaCondicion")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Prioridad", 0)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TituloConsultaGenerica", 1)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugAlertas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraDesktopAlert1 = New Infragistics.Win.Misc.UltraDesktopAlert(Me.components)
        Me._timer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlDolar = New System.Windows.Forms.Panel()
        Me.btnAplicar = New Eniac.Controles.Button()
        Me.lblAAplicar = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.lblDolarDelSistema = New Eniac.Controles.Label()
        Me.txtDolarAAplicar = New Eniac.Controles.TextBox()
        Me.txtDolarSistema = New Eniac.Controles.TextBox()
        Me.pnlConfiguracionBackup = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDestinatarios = New Eniac.Controles.TextBox()
        Me.lblDestinatarios = New Eniac.Controles.Label()
        Me.lblDomingo = New Eniac.Controles.Label()
        Me.chbLunes = New Eniac.Controles.CheckBox()
        Me.lblSabado = New Eniac.Controles.Label()
        Me.lblProHoraHasta = New Eniac.Controles.Label()
        Me.chbDomingo = New Eniac.Controles.CheckBox()
        Me.lblProHoraDesde = New Eniac.Controles.Label()
        Me.chbSabado = New Eniac.Controles.CheckBox()
        Me.lblProFrecuencia = New Eniac.Controles.Label()
        Me.lblViernes = New Eniac.Controles.Label()
        Me.txtProFrecuencia = New Eniac.Controles.TextBox()
        Me.lblJueves = New Eniac.Controles.Label()
        Me.mtbProHoraDesde = New System.Windows.Forms.MaskedTextBox()
        Me.lblMiercoles = New Eniac.Controles.Label()
        Me.mtbProHoraHasta = New System.Windows.Forms.MaskedTextBox()
        Me.chbViernes = New Eniac.Controles.CheckBox()
        Me.lblMinutos = New Eniac.Controles.Label()
        Me.chbJueves = New Eniac.Controles.CheckBox()
        Me.lblLunes = New Eniac.Controles.Label()
        Me.chbMiercoles = New Eniac.Controles.CheckBox()
        Me.chbMartes = New Eniac.Controles.CheckBox()
        Me.lblMartes = New Eniac.Controles.Label()
        Me.btnRefrescar = New Eniac.Controles.Button()
        CType(Me.ugAlertas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDesktopAlert1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDolar.SuspendLayout()
        Me.pnlConfiguracionBackup.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ugAlertas
        '
        Appearance1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ugAlertas.DisplayLayout.Appearance = Appearance1
        Me.ugAlertas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 252
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 74
        UltraGridColumn1.Header.VisiblePosition = 4
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 76
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 47
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 47
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.Width = 47
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 47
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 47
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 73
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 73
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 52
        UltraGridColumn15.Header.VisiblePosition = 13
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 73
        UltraGridColumn5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn5.Header.VisiblePosition = 1
        UltraGridColumn5.MaxWidth = 30
        UltraGridColumn5.MinWidth = 30
        UltraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn5.Width = 30
        UltraGridColumn14.Header.VisiblePosition = 14
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 79
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn1, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn15, UltraGridColumn5, UltraGridColumn14})
        Me.ugAlertas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugAlertas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Inset
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAlertas.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAlertas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugAlertas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugAlertas.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAlertas.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugAlertas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugAlertas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ugAlertas.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.ControlDark
        Appearance6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ugAlertas.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugAlertas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugAlertas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAlertas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAlertas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None
        Me.ugAlertas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
        Me.ugAlertas.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.ButtonSoft
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugAlertas.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Appearance8.TextVAlignAsString = "Middle"
        Me.ugAlertas.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugAlertas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugAlertas.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugAlertas.DisplayLayout.Override.CellPadding = 1
        Me.ugAlertas.DisplayLayout.Override.CellSpacing = 2
        Me.ugAlertas.DisplayLayout.Override.DefaultRowHeight = 30
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAlertas.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Center"
        Me.ugAlertas.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugAlertas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugAlertas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Me.ugAlertas.DisplayLayout.Override.MaxSelectedRows = 1
        Appearance11.BackColor = System.Drawing.SystemColors.ControlDark
        Appearance11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ugAlertas.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugAlertas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAlertas.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree
        Me.ugAlertas.DisplayLayout.Override.RowSizingAutoMaxLines = 3
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugAlertas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugAlertas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugAlertas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugAlertas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugAlertas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugAlertas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugAlertas.Location = New System.Drawing.Point(0, 0)
        Me.ugAlertas.Name = "ugAlertas"
        Me.ugAlertas.Size = New System.Drawing.Size(286, 305)
        Me.ugAlertas.TabIndex = 1
        Me.ugAlertas.Text = "Alertas"
        '
        'UltraDesktopAlert1
        '
        Me.UltraDesktopAlert1.AutoClose = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraDesktopAlert1.MultipleWindowDisplayStyle = Infragistics.Win.Misc.MultipleWindowDisplayStyle.Tiled
        Me.UltraDesktopAlert1.UseFlatMode = Infragistics.Win.DefaultableBoolean.[False]
        '
        '_timer
        '
        Me._timer.Interval = 1200000
        '
        'pnlDolar
        '
        Me.pnlDolar.Controls.Add(Me.btnAplicar)
        Me.pnlDolar.Controls.Add(Me.lblAAplicar)
        Me.pnlDolar.Controls.Add(Me.Label1)
        Me.pnlDolar.Controls.Add(Me.lblDolarDelSistema)
        Me.pnlDolar.Controls.Add(Me.txtDolarAAplicar)
        Me.pnlDolar.Controls.Add(Me.txtDolarSistema)
        Me.pnlDolar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDolar.Location = New System.Drawing.Point(0, 430)
        Me.pnlDolar.Name = "pnlDolar"
        Me.pnlDolar.Size = New System.Drawing.Size(286, 32)
        Me.pnlDolar.TabIndex = 2
        '
        'btnAplicar
        '
        Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnAplicar.Location = New System.Drawing.Point(252, 0)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(32, 29)
        Me.btnAplicar.TabIndex = 21
        Me.btnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'lblAAplicar
        '
        Me.lblAAplicar.AutoSize = True
        Me.lblAAplicar.LabelAsoc = Nothing
        Me.lblAAplicar.Location = New System.Drawing.Point(158, 10)
        Me.lblAAplicar.Name = "lblAAplicar"
        Me.lblAAplicar.Size = New System.Drawing.Size(29, 13)
        Me.lblAAplicar.TabIndex = 14
        Me.lblAAplicar.Text = "U$D"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(2, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "U$D"
        '
        'lblDolarDelSistema
        '
        Me.lblDolarDelSistema.AutoSize = True
        Me.lblDolarDelSistema.LabelAsoc = Nothing
        Me.lblDolarDelSistema.Location = New System.Drawing.Point(96, 10)
        Me.lblDolarDelSistema.Name = "lblDolarDelSistema"
        Me.lblDolarDelSistema.Size = New System.Drawing.Size(59, 13)
        Me.lblDolarDelSistema.TabIndex = 12
        Me.lblDolarDelSistema.Text = "del sistema"
        '
        'txtDolarAAplicar
        '
        Me.txtDolarAAplicar.BackColor = System.Drawing.SystemColors.Window
        Me.txtDolarAAplicar.BindearPropiedadControl = Nothing
        Me.txtDolarAAplicar.BindearPropiedadEntidad = Nothing
        Me.txtDolarAAplicar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDolarAAplicar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDolarAAplicar.Formato = "#0.00"
        Me.txtDolarAAplicar.IsDecimal = True
        Me.txtDolarAAplicar.IsNumber = True
        Me.txtDolarAAplicar.IsPK = False
        Me.txtDolarAAplicar.IsRequired = False
        Me.txtDolarAAplicar.Key = ""
        Me.txtDolarAAplicar.LabelAsoc = Nothing
        Me.txtDolarAAplicar.Location = New System.Drawing.Point(190, 6)
        Me.txtDolarAAplicar.MaxLength = 8
        Me.txtDolarAAplicar.Name = "txtDolarAAplicar"
        Me.txtDolarAAplicar.Size = New System.Drawing.Size(59, 20)
        Me.txtDolarAAplicar.TabIndex = 11
        Me.txtDolarAAplicar.Text = "0.00"
        Me.txtDolarAAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDolarSistema
        '
        Me.txtDolarSistema.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtDolarSistema.BindearPropiedadControl = Nothing
        Me.txtDolarSistema.BindearPropiedadEntidad = Nothing
        Me.txtDolarSistema.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDolarSistema.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDolarSistema.Formato = "#0.00"
        Me.txtDolarSistema.IsDecimal = False
        Me.txtDolarSistema.IsNumber = True
        Me.txtDolarSistema.IsPK = False
        Me.txtDolarSistema.IsRequired = False
        Me.txtDolarSistema.Key = ""
        Me.txtDolarSistema.LabelAsoc = Nothing
        Me.txtDolarSistema.Location = New System.Drawing.Point(35, 6)
        Me.txtDolarSistema.MaxLength = 8
        Me.txtDolarSistema.Name = "txtDolarSistema"
        Me.txtDolarSistema.ReadOnly = True
        Me.txtDolarSistema.Size = New System.Drawing.Size(59, 20)
        Me.txtDolarSistema.TabIndex = 10
        Me.txtDolarSistema.Text = "0.00"
        Me.txtDolarSistema.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlConfiguracionBackup
        '
        Me.pnlConfiguracionBackup.Controls.Add(Me.GroupBox1)
        Me.pnlConfiguracionBackup.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlConfiguracionBackup.Location = New System.Drawing.Point(0, 305)
        Me.pnlConfiguracionBackup.Name = "pnlConfiguracionBackup"
        Me.pnlConfiguracionBackup.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlConfiguracionBackup.Size = New System.Drawing.Size(286, 125)
        Me.pnlConfiguracionBackup.TabIndex = 3
        Me.pnlConfiguracionBackup.Text = "Configuración de Backup"
        Me.pnlConfiguracionBackup.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDestinatarios)
        Me.GroupBox1.Controls.Add(Me.lblDestinatarios)
        Me.GroupBox1.Controls.Add(Me.lblDomingo)
        Me.GroupBox1.Controls.Add(Me.chbLunes)
        Me.GroupBox1.Controls.Add(Me.lblSabado)
        Me.GroupBox1.Controls.Add(Me.lblProHoraHasta)
        Me.GroupBox1.Controls.Add(Me.chbDomingo)
        Me.GroupBox1.Controls.Add(Me.lblProHoraDesde)
        Me.GroupBox1.Controls.Add(Me.chbSabado)
        Me.GroupBox1.Controls.Add(Me.lblProFrecuencia)
        Me.GroupBox1.Controls.Add(Me.lblViernes)
        Me.GroupBox1.Controls.Add(Me.txtProFrecuencia)
        Me.GroupBox1.Controls.Add(Me.lblJueves)
        Me.GroupBox1.Controls.Add(Me.mtbProHoraDesde)
        Me.GroupBox1.Controls.Add(Me.lblMiercoles)
        Me.GroupBox1.Controls.Add(Me.mtbProHoraHasta)
        Me.GroupBox1.Controls.Add(Me.chbViernes)
        Me.GroupBox1.Controls.Add(Me.lblMinutos)
        Me.GroupBox1.Controls.Add(Me.chbJueves)
        Me.GroupBox1.Controls.Add(Me.lblLunes)
        Me.GroupBox1.Controls.Add(Me.chbMiercoles)
        Me.GroupBox1.Controls.Add(Me.chbMartes)
        Me.GroupBox1.Controls.Add(Me.lblMartes)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 119)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuración de Backup"
        '
        'txtDestinatarios
        '
        Me.txtDestinatarios.BackColor = System.Drawing.SystemColors.Window
        Me.txtDestinatarios.BindearPropiedadControl = Nothing
        Me.txtDestinatarios.BindearPropiedadEntidad = Nothing
        Me.txtDestinatarios.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDestinatarios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDestinatarios.Formato = "#0.00"
        Me.txtDestinatarios.IsDecimal = False
        Me.txtDestinatarios.IsNumber = False
        Me.txtDestinatarios.IsPK = False
        Me.txtDestinatarios.IsRequired = False
        Me.txtDestinatarios.Key = ""
        Me.txtDestinatarios.LabelAsoc = Me.lblDestinatarios
        Me.txtDestinatarios.Location = New System.Drawing.Point(76, 93)
        Me.txtDestinatarios.MaxLength = 5
        Me.txtDestinatarios.Name = "txtDestinatarios"
        Me.txtDestinatarios.ReadOnly = True
        Me.txtDestinatarios.Size = New System.Drawing.Size(198, 20)
        Me.txtDestinatarios.TabIndex = 41
        '
        'lblDestinatarios
        '
        Me.lblDestinatarios.AutoSize = True
        Me.lblDestinatarios.LabelAsoc = Nothing
        Me.lblDestinatarios.Location = New System.Drawing.Point(4, 96)
        Me.lblDestinatarios.Name = "lblDestinatarios"
        Me.lblDestinatarios.Size = New System.Drawing.Size(71, 13)
        Me.lblDestinatarios.TabIndex = 40
        Me.lblDestinatarios.Text = "Destinatarios:"
        '
        'lblDomingo
        '
        Me.lblDomingo.AutoSize = True
        Me.lblDomingo.LabelAsoc = Nothing
        Me.lblDomingo.Location = New System.Drawing.Point(156, 43)
        Me.lblDomingo.Name = "lblDomingo"
        Me.lblDomingo.Size = New System.Drawing.Size(49, 13)
        Me.lblDomingo.TabIndex = 39
        Me.lblDomingo.Text = "Domingo"
        '
        'chbLunes
        '
        Me.chbLunes.AutoCheck = False
        Me.chbLunes.AutoSize = True
        Me.chbLunes.BindearPropiedadControl = Nothing
        Me.chbLunes.BindearPropiedadEntidad = Nothing
        Me.chbLunes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLunes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLunes.IsPK = False
        Me.chbLunes.IsRequired = False
        Me.chbLunes.Key = Nothing
        Me.chbLunes.LabelAsoc = Nothing
        Me.chbLunes.Location = New System.Drawing.Point(6, 23)
        Me.chbLunes.Name = "chbLunes"
        Me.chbLunes.Size = New System.Drawing.Size(15, 14)
        Me.chbLunes.TabIndex = 15
        Me.chbLunes.UseVisualStyleBackColor = True
        '
        'lblSabado
        '
        Me.lblSabado.AutoSize = True
        Me.lblSabado.LabelAsoc = Nothing
        Me.lblSabado.Location = New System.Drawing.Point(90, 43)
        Me.lblSabado.Name = "lblSabado"
        Me.lblSabado.Size = New System.Drawing.Size(44, 13)
        Me.lblSabado.TabIndex = 38
        Me.lblSabado.Text = "Sábado"
        '
        'lblProHoraHasta
        '
        Me.lblProHoraHasta.AutoSize = True
        Me.lblProHoraHasta.LabelAsoc = Nothing
        Me.lblProHoraHasta.Location = New System.Drawing.Point(90, 71)
        Me.lblProHoraHasta.Name = "lblProHoraHasta"
        Me.lblProHoraHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblProHoraHasta.TabIndex = 29
        Me.lblProHoraHasta.Text = "Hasta"
        '
        'chbDomingo
        '
        Me.chbDomingo.AutoCheck = False
        Me.chbDomingo.AutoSize = True
        Me.chbDomingo.BindearPropiedadControl = Nothing
        Me.chbDomingo.BindearPropiedadEntidad = Nothing
        Me.chbDomingo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDomingo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDomingo.IsPK = False
        Me.chbDomingo.IsRequired = False
        Me.chbDomingo.Key = Nothing
        Me.chbDomingo.LabelAsoc = Nothing
        Me.chbDomingo.Location = New System.Drawing.Point(135, 42)
        Me.chbDomingo.Name = "chbDomingo"
        Me.chbDomingo.Size = New System.Drawing.Size(15, 14)
        Me.chbDomingo.TabIndex = 21
        Me.chbDomingo.UseVisualStyleBackColor = True
        '
        'lblProHoraDesde
        '
        Me.lblProHoraDesde.AutoSize = True
        Me.lblProHoraDesde.LabelAsoc = Nothing
        Me.lblProHoraDesde.Location = New System.Drawing.Point(4, 71)
        Me.lblProHoraDesde.Name = "lblProHoraDesde"
        Me.lblProHoraDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblProHoraDesde.TabIndex = 30
        Me.lblProHoraDesde.Text = "Desde"
        '
        'chbSabado
        '
        Me.chbSabado.AutoCheck = False
        Me.chbSabado.AutoSize = True
        Me.chbSabado.BindearPropiedadControl = Nothing
        Me.chbSabado.BindearPropiedadEntidad = Nothing
        Me.chbSabado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSabado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSabado.IsPK = False
        Me.chbSabado.IsRequired = False
        Me.chbSabado.Key = Nothing
        Me.chbSabado.LabelAsoc = Nothing
        Me.chbSabado.Location = New System.Drawing.Point(69, 42)
        Me.chbSabado.Name = "chbSabado"
        Me.chbSabado.Size = New System.Drawing.Size(15, 14)
        Me.chbSabado.TabIndex = 20
        Me.chbSabado.UseVisualStyleBackColor = True
        '
        'lblProFrecuencia
        '
        Me.lblProFrecuencia.AutoSize = True
        Me.lblProFrecuencia.LabelAsoc = Nothing
        Me.lblProFrecuencia.Location = New System.Drawing.Point(173, 71)
        Me.lblProFrecuencia.Name = "lblProFrecuencia"
        Me.lblProFrecuencia.Size = New System.Drawing.Size(32, 13)
        Me.lblProFrecuencia.TabIndex = 31
        Me.lblProFrecuencia.Text = "Cada"
        '
        'lblViernes
        '
        Me.lblViernes.AutoSize = True
        Me.lblViernes.LabelAsoc = Nothing
        Me.lblViernes.Location = New System.Drawing.Point(27, 43)
        Me.lblViernes.Name = "lblViernes"
        Me.lblViernes.Size = New System.Drawing.Size(42, 13)
        Me.lblViernes.TabIndex = 37
        Me.lblViernes.Text = "Viernes"
        '
        'txtProFrecuencia
        '
        Me.txtProFrecuencia.BindearPropiedadControl = Nothing
        Me.txtProFrecuencia.BindearPropiedadEntidad = Nothing
        Me.txtProFrecuencia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProFrecuencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProFrecuencia.Formato = ""
        Me.txtProFrecuencia.IsDecimal = False
        Me.txtProFrecuencia.IsNumber = False
        Me.txtProFrecuencia.IsPK = False
        Me.txtProFrecuencia.IsRequired = False
        Me.txtProFrecuencia.Key = ""
        Me.txtProFrecuencia.LabelAsoc = Me.lblProFrecuencia
        Me.txtProFrecuencia.Location = New System.Drawing.Point(208, 68)
        Me.txtProFrecuencia.Name = "txtProFrecuencia"
        Me.txtProFrecuencia.ReadOnly = True
        Me.txtProFrecuencia.Size = New System.Drawing.Size(42, 20)
        Me.txtProFrecuencia.TabIndex = 28
        '
        'lblJueves
        '
        Me.lblJueves.AutoSize = True
        Me.lblJueves.LabelAsoc = Nothing
        Me.lblJueves.Location = New System.Drawing.Point(235, 24)
        Me.lblJueves.Name = "lblJueves"
        Me.lblJueves.Size = New System.Drawing.Size(41, 13)
        Me.lblJueves.TabIndex = 36
        Me.lblJueves.Text = "Jueves"
        '
        'mtbProHoraDesde
        '
        Me.mtbProHoraDesde.Location = New System.Drawing.Point(45, 68)
        Me.mtbProHoraDesde.Mask = "00:00"
        Me.mtbProHoraDesde.Name = "mtbProHoraDesde"
        Me.mtbProHoraDesde.ReadOnly = True
        Me.mtbProHoraDesde.Size = New System.Drawing.Size(42, 20)
        Me.mtbProHoraDesde.TabIndex = 26
        Me.mtbProHoraDesde.ValidatingType = GetType(Date)
        '
        'lblMiercoles
        '
        Me.lblMiercoles.AutoSize = True
        Me.lblMiercoles.LabelAsoc = Nothing
        Me.lblMiercoles.Location = New System.Drawing.Point(156, 24)
        Me.lblMiercoles.Name = "lblMiercoles"
        Me.lblMiercoles.Size = New System.Drawing.Size(52, 13)
        Me.lblMiercoles.TabIndex = 35
        Me.lblMiercoles.Text = "Miércoles"
        '
        'mtbProHoraHasta
        '
        Me.mtbProHoraHasta.Location = New System.Drawing.Point(128, 68)
        Me.mtbProHoraHasta.Mask = "00:00"
        Me.mtbProHoraHasta.Name = "mtbProHoraHasta"
        Me.mtbProHoraHasta.ReadOnly = True
        Me.mtbProHoraHasta.Size = New System.Drawing.Size(42, 20)
        Me.mtbProHoraHasta.TabIndex = 27
        Me.mtbProHoraHasta.ValidatingType = GetType(Date)
        '
        'chbViernes
        '
        Me.chbViernes.AutoCheck = False
        Me.chbViernes.AutoSize = True
        Me.chbViernes.BindearPropiedadControl = Nothing
        Me.chbViernes.BindearPropiedadEntidad = Nothing
        Me.chbViernes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbViernes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbViernes.IsPK = False
        Me.chbViernes.IsRequired = False
        Me.chbViernes.Key = Nothing
        Me.chbViernes.LabelAsoc = Nothing
        Me.chbViernes.Location = New System.Drawing.Point(6, 42)
        Me.chbViernes.Name = "chbViernes"
        Me.chbViernes.Size = New System.Drawing.Size(15, 14)
        Me.chbViernes.TabIndex = 19
        Me.chbViernes.UseVisualStyleBackColor = True
        '
        'lblMinutos
        '
        Me.lblMinutos.AutoSize = True
        Me.lblMinutos.LabelAsoc = Nothing
        Me.lblMinutos.Location = New System.Drawing.Point(253, 71)
        Me.lblMinutos.Name = "lblMinutos"
        Me.lblMinutos.Size = New System.Drawing.Size(26, 13)
        Me.lblMinutos.TabIndex = 32
        Me.lblMinutos.Text = "min."
        '
        'chbJueves
        '
        Me.chbJueves.AutoCheck = False
        Me.chbJueves.AutoSize = True
        Me.chbJueves.BindearPropiedadControl = Nothing
        Me.chbJueves.BindearPropiedadEntidad = Nothing
        Me.chbJueves.ForeColorFocus = System.Drawing.Color.Red
        Me.chbJueves.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbJueves.IsPK = False
        Me.chbJueves.IsRequired = False
        Me.chbJueves.Key = Nothing
        Me.chbJueves.LabelAsoc = Nothing
        Me.chbJueves.Location = New System.Drawing.Point(214, 23)
        Me.chbJueves.Name = "chbJueves"
        Me.chbJueves.Size = New System.Drawing.Size(15, 14)
        Me.chbJueves.TabIndex = 18
        Me.chbJueves.UseVisualStyleBackColor = True
        '
        'lblLunes
        '
        Me.lblLunes.AutoSize = True
        Me.lblLunes.LabelAsoc = Nothing
        Me.lblLunes.Location = New System.Drawing.Point(27, 24)
        Me.lblLunes.Name = "lblLunes"
        Me.lblLunes.Size = New System.Drawing.Size(36, 13)
        Me.lblLunes.TabIndex = 33
        Me.lblLunes.Text = "Lunes"
        '
        'chbMiercoles
        '
        Me.chbMiercoles.AutoCheck = False
        Me.chbMiercoles.AutoSize = True
        Me.chbMiercoles.BindearPropiedadControl = Nothing
        Me.chbMiercoles.BindearPropiedadEntidad = Nothing
        Me.chbMiercoles.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMiercoles.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMiercoles.IsPK = False
        Me.chbMiercoles.IsRequired = False
        Me.chbMiercoles.Key = Nothing
        Me.chbMiercoles.LabelAsoc = Nothing
        Me.chbMiercoles.Location = New System.Drawing.Point(135, 23)
        Me.chbMiercoles.Name = "chbMiercoles"
        Me.chbMiercoles.Size = New System.Drawing.Size(15, 14)
        Me.chbMiercoles.TabIndex = 17
        Me.chbMiercoles.UseVisualStyleBackColor = True
        '
        'chbMartes
        '
        Me.chbMartes.AutoCheck = False
        Me.chbMartes.AutoSize = True
        Me.chbMartes.BindearPropiedadControl = Nothing
        Me.chbMartes.BindearPropiedadEntidad = Nothing
        Me.chbMartes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMartes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMartes.IsPK = False
        Me.chbMartes.IsRequired = False
        Me.chbMartes.Key = Nothing
        Me.chbMartes.LabelAsoc = Nothing
        Me.chbMartes.Location = New System.Drawing.Point(69, 23)
        Me.chbMartes.Name = "chbMartes"
        Me.chbMartes.Size = New System.Drawing.Size(15, 14)
        Me.chbMartes.TabIndex = 16
        Me.chbMartes.UseVisualStyleBackColor = True
        '
        'lblMartes
        '
        Me.lblMartes.AutoSize = True
        Me.lblMartes.LabelAsoc = Nothing
        Me.lblMartes.Location = New System.Drawing.Point(90, 24)
        Me.lblMartes.Name = "lblMartes"
        Me.lblMartes.Size = New System.Drawing.Size(39, 13)
        Me.lblMartes.TabIndex = 34
        Me.lblMartes.Text = "Martes"
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnRefrescar.Location = New System.Drawing.Point(247, 270)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(32, 29)
        Me.btnRefrescar.TabIndex = 22
        Me.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefrescar.UseVisualStyleBackColor = True
        Me.btnRefrescar.Visible = False
        '
        'Alertas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(286, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.ugAlertas)
        Me.Controls.Add(Me.pnlConfiguracionBackup)
        Me.Controls.Add(Me.pnlDolar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Alertas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Alertas"
        CType(Me.ugAlertas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDesktopAlert1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDolar.ResumeLayout(False)
        Me.pnlDolar.PerformLayout()
        Me.pnlConfiguracionBackup.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugAlertas As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraDesktopAlert1 As Infragistics.Win.Misc.UltraDesktopAlert
   Friend WithEvents _timer As System.Windows.Forms.Timer
   Friend WithEvents pnlDolar As System.Windows.Forms.Panel
   Friend WithEvents txtDolarAAplicar As Eniac.Controles.TextBox
   Friend WithEvents txtDolarSistema As Eniac.Controles.TextBox
   Friend WithEvents lblDolarDelSistema As Eniac.Controles.Label
   Friend WithEvents lblAAplicar As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents btnAplicar As Eniac.Controles.Button
   Friend WithEvents pnlConfiguracionBackup As System.Windows.Forms.Panel
   Friend WithEvents chbLunes As Eniac.Controles.CheckBox
   Friend WithEvents chbMartes As Eniac.Controles.CheckBox
   Friend WithEvents chbMiercoles As Eniac.Controles.CheckBox
   Friend WithEvents chbJueves As Eniac.Controles.CheckBox
   Friend WithEvents chbViernes As Eniac.Controles.CheckBox
   Friend WithEvents chbSabado As Eniac.Controles.CheckBox
   Friend WithEvents chbDomingo As Eniac.Controles.CheckBox
   Friend WithEvents lblMinutos As Eniac.Controles.Label
   Friend WithEvents mtbProHoraHasta As System.Windows.Forms.MaskedTextBox
   Friend WithEvents mtbProHoraDesde As System.Windows.Forms.MaskedTextBox
   Friend WithEvents txtProFrecuencia As Eniac.Controles.TextBox
   Friend WithEvents lblProFrecuencia As Eniac.Controles.Label
   Friend WithEvents lblProHoraDesde As Eniac.Controles.Label
   Friend WithEvents lblProHoraHasta As Eniac.Controles.Label
   Friend WithEvents lblViernes As Eniac.Controles.Label
   Friend WithEvents lblJueves As Eniac.Controles.Label
   Friend WithEvents lblMiercoles As Eniac.Controles.Label
   Friend WithEvents lblMartes As Eniac.Controles.Label
   Friend WithEvents lblLunes As Eniac.Controles.Label
   Friend WithEvents lblDomingo As Eniac.Controles.Label
   Friend WithEvents lblSabado As Eniac.Controles.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents txtDestinatarios As Eniac.Controles.TextBox
   Friend WithEvents lblDestinatarios As Eniac.Controles.Label
    Friend WithEvents btnRefrescar As Controles.Button
End Class
