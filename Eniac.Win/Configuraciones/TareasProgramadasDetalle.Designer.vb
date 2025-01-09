<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TareasProgramadasDetalle
   Inherits BaseDetalle

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTareaProgramada")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiaSemana", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HoraProgramada")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDiaSemana")
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
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TareasProgramadasDetalle))
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.ugDiasSemana = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.lblHoraProgramada = New Eniac.Controles.Label()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.lblDiaSemana = New Eniac.Controles.Label()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.dtpHoraProgramada = New Eniac.Controles.DateTimePicker()
      Me.cmbDiaSemana = New Eniac.Controles.ComboBox()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblIdTareaProgramada = New Eniac.Controles.Label()
      Me.txtIdTareaProgramada = New Eniac.Controles.TextBox()
      Me.lblUsuario = New Eniac.Controles.Label()
      Me.txtUsuario = New Eniac.Controles.TextBox()
      Me.bscCodigoFuncion = New Eniac.Controles.Buscador2()
      Me.lblIdFuncion = New Eniac.Controles.Label()
      Me.lblFuncion = New Eniac.Controles.Label()
      Me.bscNombreFuncion = New Eniac.Controles.Buscador2()
      Me.lblNombreFuncion = New Eniac.Controles.Label()
      Me.lblUltimaFechaEjecucion = New Eniac.Controles.Label()
      Me.txtUltimaFechaEjecucion = New Eniac.Controles.TextBox()
      Me.GroupBox2.SuspendLayout()
      CType(Me.ugDiasSemana, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(317, 451)
      Me.btnAceptar.TabIndex = 14
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(403, 451)
      Me.btnCancelar.TabIndex = 15
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(216, 451)
      Me.btnCopiar.TabIndex = 17
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(159, 451)
      Me.btnAplicar.TabIndex = 16
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.ugDiasSemana)
      Me.GroupBox2.Controls.Add(Me.lblHoraProgramada)
      Me.GroupBox2.Controls.Add(Me.btnInsertar)
      Me.GroupBox2.Controls.Add(Me.lblDiaSemana)
      Me.GroupBox2.Controls.Add(Me.btnEliminar)
      Me.GroupBox2.Controls.Add(Me.dtpHoraProgramada)
      Me.GroupBox2.Controls.Add(Me.cmbDiaSemana)
      Me.GroupBox2.Location = New System.Drawing.Point(34, 167)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(421, 265)
      Me.GroupBox2.TabIndex = 13
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Horarios"
      '
      'ugDiasSemana
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDiasSemana.DisplayLayout.Appearance = Appearance1
      Me.ugDiasSemana.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.Caption = "Orden día"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 80
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance2
      UltraGridColumn4.Header.Caption = "Hora"
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 82
      UltraGridColumn6.Header.Caption = "Día"
      UltraGridColumn6.Header.VisiblePosition = 2
      UltraGridColumn6.Width = 187
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn4, UltraGridColumn6})
      Me.ugDiasSemana.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDiasSemana.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDiasSemana.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance3.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDiasSemana.DisplayLayout.GroupByBox.Appearance = Appearance3
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDiasSemana.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
      Me.ugDiasSemana.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance5.BackColor2 = System.Drawing.SystemColors.Control
      Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDiasSemana.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
      Me.ugDiasSemana.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDiasSemana.DisplayLayout.MaxRowScrollRegions = 1
      Appearance6.BackColor = System.Drawing.SystemColors.Window
      Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDiasSemana.DisplayLayout.Override.ActiveCellAppearance = Appearance6
      Appearance7.BackColor = System.Drawing.SystemColors.Highlight
      Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDiasSemana.DisplayLayout.Override.ActiveRowAppearance = Appearance7
      Me.ugDiasSemana.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDiasSemana.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDiasSemana.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance8.BackColor = System.Drawing.SystemColors.Window
      Me.ugDiasSemana.DisplayLayout.Override.CardAreaAppearance = Appearance8
      Appearance9.BorderColor = System.Drawing.Color.Silver
      Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDiasSemana.DisplayLayout.Override.CellAppearance = Appearance9
      Me.ugDiasSemana.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDiasSemana.DisplayLayout.Override.CellPadding = 0
      Appearance10.BackColor = System.Drawing.SystemColors.Control
      Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance10.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDiasSemana.DisplayLayout.Override.GroupByRowAppearance = Appearance10
      Appearance11.TextHAlignAsString = "Left"
      Me.ugDiasSemana.DisplayLayout.Override.HeaderAppearance = Appearance11
      Me.ugDiasSemana.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDiasSemana.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Me.ugDiasSemana.DisplayLayout.Override.RowAppearance = Appearance12
      Me.ugDiasSemana.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDiasSemana.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
      Me.ugDiasSemana.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDiasSemana.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDiasSemana.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDiasSemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDiasSemana.Location = New System.Drawing.Point(15, 45)
      Me.ugDiasSemana.Name = "ugDiasSemana"
      Me.ugDiasSemana.Size = New System.Drawing.Size(351, 210)
      Me.ugDiasSemana.TabIndex = 6
      Me.ugDiasSemana.Text = "UltraGrid1"
      '
      'lblHoraProgramada
      '
      Me.lblHoraProgramada.AutoSize = True
      Me.lblHoraProgramada.LabelAsoc = Nothing
      Me.lblHoraProgramada.Location = New System.Drawing.Point(158, 24)
      Me.lblHoraProgramada.Name = "lblHoraProgramada"
      Me.lblHoraProgramada.Size = New System.Drawing.Size(90, 13)
      Me.lblHoraProgramada.TabIndex = 2
      Me.lblHoraProgramada.Text = "Hora Programada"
      '
      'btnInsertar
      '
      Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.btnInsertar.Location = New System.Drawing.Point(372, 19)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 4
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'lblDiaSemana
      '
      Me.lblDiaSemana.AutoSize = True
      Me.lblDiaSemana.LabelAsoc = Nothing
      Me.lblDiaSemana.Location = New System.Drawing.Point(12, 23)
      Me.lblDiaSemana.Name = "lblDiaSemana"
      Me.lblDiaSemana.Size = New System.Drawing.Size(25, 13)
      Me.lblDiaSemana.TabIndex = 0
      Me.lblDiaSemana.Text = "Día"
      '
      'btnEliminar
      '
      Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
      Me.btnEliminar.Location = New System.Drawing.Point(372, 62)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 5
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'dtpHoraProgramada
      '
      Me.dtpHoraProgramada.BindearPropiedadControl = ""
      Me.dtpHoraProgramada.BindearPropiedadEntidad = ""
      Me.dtpHoraProgramada.CustomFormat = "HH:mm"
      Me.dtpHoraProgramada.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHoraProgramada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHoraProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHoraProgramada.IsPK = False
      Me.dtpHoraProgramada.IsRequired = False
      Me.dtpHoraProgramada.Key = ""
      Me.dtpHoraProgramada.LabelAsoc = Me.lblHoraProgramada
      Me.dtpHoraProgramada.Location = New System.Drawing.Point(254, 20)
      Me.dtpHoraProgramada.Name = "dtpHoraProgramada"
      Me.dtpHoraProgramada.ShowUpDown = True
      Me.dtpHoraProgramada.Size = New System.Drawing.Size(52, 20)
      Me.dtpHoraProgramada.TabIndex = 3
      '
      'cmbDiaSemana
      '
      Me.cmbDiaSemana.BindearPropiedadControl = ""
      Me.cmbDiaSemana.BindearPropiedadEntidad = ""
      Me.cmbDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDiaSemana.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbDiaSemana.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbDiaSemana.FormattingEnabled = True
      Me.cmbDiaSemana.IsPK = False
      Me.cmbDiaSemana.IsRequired = False
      Me.cmbDiaSemana.Key = Nothing
      Me.cmbDiaSemana.LabelAsoc = Me.lblDiaSemana
      Me.cmbDiaSemana.Location = New System.Drawing.Point(43, 19)
      Me.cmbDiaSemana.Name = "cmbDiaSemana"
      Me.cmbDiaSemana.Size = New System.Drawing.Size(101, 21)
      Me.cmbDiaSemana.TabIndex = 1
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.LabelAsoc = Nothing
      Me.lblObservacion.Location = New System.Drawing.Point(16, 89)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
      Me.lblObservacion.TabIndex = 7
      Me.lblObservacion.Text = "Observación"
      '
      'txtObservacion
      '
      Me.txtObservacion.BindearPropiedadControl = "Text"
      Me.txtObservacion.BindearPropiedadEntidad = "Observacion"
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Me.lblObservacion
      Me.txtObservacion.Location = New System.Drawing.Point(107, 85)
      Me.txtObservacion.MaxLength = 100
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(372, 20)
      Me.txtObservacion.TabIndex = 8
      '
      'lblIdTareaProgramada
      '
      Me.lblIdTareaProgramada.AutoSize = True
      Me.lblIdTareaProgramada.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblIdTareaProgramada.LabelAsoc = Nothing
      Me.lblIdTareaProgramada.Location = New System.Drawing.Point(16, 25)
      Me.lblIdTareaProgramada.Name = "lblIdTareaProgramada"
      Me.lblIdTareaProgramada.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTareaProgramada.TabIndex = 0
      Me.lblIdTareaProgramada.Text = "Código"
      '
      'txtIdTareaProgramada
      '
      Me.txtIdTareaProgramada.BindearPropiedadControl = "Text"
      Me.txtIdTareaProgramada.BindearPropiedadEntidad = "IdTareaProgramada"
      Me.txtIdTareaProgramada.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTareaProgramada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTareaProgramada.Formato = ""
      Me.txtIdTareaProgramada.IsDecimal = False
      Me.txtIdTareaProgramada.IsNumber = True
      Me.txtIdTareaProgramada.IsPK = True
      Me.txtIdTareaProgramada.IsRequired = True
      Me.txtIdTareaProgramada.Key = ""
      Me.txtIdTareaProgramada.LabelAsoc = Me.lblIdTareaProgramada
      Me.txtIdTareaProgramada.Location = New System.Drawing.Point(107, 22)
      Me.txtIdTareaProgramada.MaxLength = 10
      Me.txtIdTareaProgramada.Name = "txtIdTareaProgramada"
      Me.txtIdTareaProgramada.Size = New System.Drawing.Size(54, 20)
      Me.txtIdTareaProgramada.TabIndex = 1
      Me.txtIdTareaProgramada.Text = "0"
      Me.txtIdTareaProgramada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblUsuario
      '
      Me.lblUsuario.AutoSize = True
      Me.lblUsuario.LabelAsoc = Nothing
      Me.lblUsuario.Location = New System.Drawing.Point(15, 115)
      Me.lblUsuario.Name = "lblUsuario"
      Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
      Me.lblUsuario.TabIndex = 9
      Me.lblUsuario.Text = "Usuario"
      '
      'txtUsuario
      '
      Me.txtUsuario.BindearPropiedadControl = "Text"
      Me.txtUsuario.BindearPropiedadEntidad = "Usuario"
      Me.txtUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtUsuario.Formato = ""
      Me.txtUsuario.IsDecimal = False
      Me.txtUsuario.IsNumber = False
      Me.txtUsuario.IsPK = False
      Me.txtUsuario.IsRequired = False
      Me.txtUsuario.Key = ""
      Me.txtUsuario.LabelAsoc = Me.lblUsuario
      Me.txtUsuario.Location = New System.Drawing.Point(107, 111)
      Me.txtUsuario.MaxLength = 50
      Me.txtUsuario.Name = "txtUsuario"
      Me.txtUsuario.ReadOnly = True
      Me.txtUsuario.Size = New System.Drawing.Size(177, 20)
      Me.txtUsuario.TabIndex = 10
      '
      'bscCodigoFuncion
      '
      Me.bscCodigoFuncion.ActivarFiltroEnGrilla = True
      Me.bscCodigoFuncion.BindearPropiedadControl = Nothing
      Me.bscCodigoFuncion.BindearPropiedadEntidad = Nothing
      Me.bscCodigoFuncion.ConfigBuscador = Nothing
      Me.bscCodigoFuncion.Datos = Nothing
      Me.bscCodigoFuncion.FilaDevuelta = Nothing
      Me.bscCodigoFuncion.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoFuncion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoFuncion.IsDecimal = False
      Me.bscCodigoFuncion.IsNumber = False
      Me.bscCodigoFuncion.IsPK = False
      Me.bscCodigoFuncion.IsRequired = True
      Me.bscCodigoFuncion.Key = ""
      Me.bscCodigoFuncion.LabelAsoc = Me.lblIdFuncion
      Me.bscCodigoFuncion.Location = New System.Drawing.Point(107, 59)
      Me.bscCodigoFuncion.MaxLengh = "30"
      Me.bscCodigoFuncion.Name = "bscCodigoFuncion"
      Me.bscCodigoFuncion.Permitido = True
      Me.bscCodigoFuncion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoFuncion.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoFuncion.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoFuncion.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoFuncion.Selecciono = False
      Me.bscCodigoFuncion.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoFuncion.TabIndex = 4
      '
      'lblIdFuncion
      '
      Me.lblIdFuncion.AutoSize = True
      Me.lblIdFuncion.LabelAsoc = Me.lblFuncion
      Me.lblIdFuncion.Location = New System.Drawing.Point(107, 45)
      Me.lblIdFuncion.Name = "lblIdFuncion"
      Me.lblIdFuncion.Size = New System.Drawing.Size(40, 13)
      Me.lblIdFuncion.TabIndex = 3
      Me.lblIdFuncion.Text = "Código"
      '
      'lblFuncion
      '
      Me.lblFuncion.AutoSize = True
      Me.lblFuncion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFuncion.LabelAsoc = Nothing
      Me.lblFuncion.Location = New System.Drawing.Point(16, 62)
      Me.lblFuncion.Name = "lblFuncion"
      Me.lblFuncion.Size = New System.Drawing.Size(45, 13)
      Me.lblFuncion.TabIndex = 2
      Me.lblFuncion.Text = "Función"
      '
      'bscNombreFuncion
      '
      Me.bscNombreFuncion.ActivarFiltroEnGrilla = True
      Me.bscNombreFuncion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscNombreFuncion.BindearPropiedadControl = Nothing
      Me.bscNombreFuncion.BindearPropiedadEntidad = Nothing
      Me.bscNombreFuncion.ConfigBuscador = Nothing
      Me.bscNombreFuncion.Datos = Nothing
      Me.bscNombreFuncion.FilaDevuelta = Nothing
      Me.bscNombreFuncion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreFuncion.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreFuncion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreFuncion.IsDecimal = False
      Me.bscNombreFuncion.IsNumber = False
      Me.bscNombreFuncion.IsPK = False
      Me.bscNombreFuncion.IsRequired = True
      Me.bscNombreFuncion.Key = ""
      Me.bscNombreFuncion.LabelAsoc = Me.lblNombreFuncion
      Me.bscNombreFuncion.Location = New System.Drawing.Point(200, 59)
      Me.bscNombreFuncion.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreFuncion.MaxLengh = "32767"
      Me.bscNombreFuncion.Name = "bscNombreFuncion"
      Me.bscNombreFuncion.Permitido = True
      Me.bscNombreFuncion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNombreFuncion.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNombreFuncion.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNombreFuncion.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNombreFuncion.Selecciono = False
      Me.bscNombreFuncion.Size = New System.Drawing.Size(279, 23)
      Me.bscNombreFuncion.TabIndex = 6
      '
      'lblNombreFuncion
      '
      Me.lblNombreFuncion.AutoSize = True
      Me.lblNombreFuncion.LabelAsoc = Me.lblFuncion
      Me.lblNombreFuncion.Location = New System.Drawing.Point(197, 45)
      Me.lblNombreFuncion.Name = "lblNombreFuncion"
      Me.lblNombreFuncion.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreFuncion.TabIndex = 5
      Me.lblNombreFuncion.Text = "&Nombre"
      '
      'lblUltimaFechaEjecucion
      '
      Me.lblUltimaFechaEjecucion.AutoSize = True
      Me.lblUltimaFechaEjecucion.LabelAsoc = Nothing
      Me.lblUltimaFechaEjecucion.Location = New System.Drawing.Point(15, 141)
      Me.lblUltimaFechaEjecucion.Name = "lblUltimaFechaEjecucion"
      Me.lblUltimaFechaEjecucion.Size = New System.Drawing.Size(86, 13)
      Me.lblUltimaFechaEjecucion.TabIndex = 11
      Me.lblUltimaFechaEjecucion.Text = "Última Ejecución"
      '
      'txtUltimaFechaEjecucion
      '
      Me.txtUltimaFechaEjecucion.BindearPropiedadControl = "Text"
      Me.txtUltimaFechaEjecucion.BindearPropiedadEntidad = "UltimaFechaEjecucion"
      Me.txtUltimaFechaEjecucion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtUltimaFechaEjecucion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtUltimaFechaEjecucion.Formato = ""
      Me.txtUltimaFechaEjecucion.IsDecimal = False
      Me.txtUltimaFechaEjecucion.IsNumber = False
      Me.txtUltimaFechaEjecucion.IsPK = False
      Me.txtUltimaFechaEjecucion.IsRequired = False
      Me.txtUltimaFechaEjecucion.Key = ""
      Me.txtUltimaFechaEjecucion.LabelAsoc = Me.lblUltimaFechaEjecucion
      Me.txtUltimaFechaEjecucion.Location = New System.Drawing.Point(107, 137)
      Me.txtUltimaFechaEjecucion.MaxLength = 50
      Me.txtUltimaFechaEjecucion.Name = "txtUltimaFechaEjecucion"
      Me.txtUltimaFechaEjecucion.ReadOnly = True
      Me.txtUltimaFechaEjecucion.Size = New System.Drawing.Size(177, 20)
      Me.txtUltimaFechaEjecucion.TabIndex = 12
      '
      'TareasProgramadasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(492, 486)
      Me.Controls.Add(Me.lblUltimaFechaEjecucion)
      Me.Controls.Add(Me.txtUltimaFechaEjecucion)
      Me.Controls.Add(Me.lblFuncion)
      Me.Controls.Add(Me.bscCodigoFuncion)
      Me.Controls.Add(Me.bscNombreFuncion)
      Me.Controls.Add(Me.lblIdFuncion)
      Me.Controls.Add(Me.lblNombreFuncion)
      Me.Controls.Add(Me.lblUsuario)
      Me.Controls.Add(Me.txtUsuario)
      Me.Controls.Add(Me.lblObservacion)
      Me.Controls.Add(Me.txtObservacion)
      Me.Controls.Add(Me.lblIdTareaProgramada)
      Me.Controls.Add(Me.txtIdTareaProgramada)
      Me.Controls.Add(Me.GroupBox2)
      Me.Name = "TareasProgramadasDetalle"
      Me.Text = "Tarea Programada"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.GroupBox2, 0)
      Me.Controls.SetChildIndex(Me.txtIdTareaProgramada, 0)
      Me.Controls.SetChildIndex(Me.lblIdTareaProgramada, 0)
      Me.Controls.SetChildIndex(Me.txtObservacion, 0)
      Me.Controls.SetChildIndex(Me.lblObservacion, 0)
      Me.Controls.SetChildIndex(Me.txtUsuario, 0)
      Me.Controls.SetChildIndex(Me.lblUsuario, 0)
      Me.Controls.SetChildIndex(Me.lblNombreFuncion, 0)
      Me.Controls.SetChildIndex(Me.lblIdFuncion, 0)
      Me.Controls.SetChildIndex(Me.bscNombreFuncion, 0)
      Me.Controls.SetChildIndex(Me.bscCodigoFuncion, 0)
      Me.Controls.SetChildIndex(Me.lblFuncion, 0)
      Me.Controls.SetChildIndex(Me.txtUltimaFechaEjecucion, 0)
      Me.Controls.SetChildIndex(Me.lblUltimaFechaEjecucion, 0)
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      CType(Me.ugDiasSemana, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents ugDiasSemana As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents lblHoraProgramada As Eniac.Controles.Label
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents lblDiaSemana As Eniac.Controles.Label
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents dtpHoraProgramada As Eniac.Controles.DateTimePicker
   Friend WithEvents cmbDiaSemana As Eniac.Controles.ComboBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblIdTareaProgramada As Eniac.Controles.Label
   Friend WithEvents txtIdTareaProgramada As Eniac.Controles.TextBox
   Friend WithEvents lblUsuario As Eniac.Controles.Label
   Friend WithEvents txtUsuario As Eniac.Controles.TextBox
   Friend WithEvents bscCodigoFuncion As Eniac.Controles.Buscador2
   Friend WithEvents lblIdFuncion As Eniac.Controles.Label
   Friend WithEvents lblFuncion As Eniac.Controles.Label
   Friend WithEvents bscNombreFuncion As Eniac.Controles.Buscador2
   Friend WithEvents lblNombreFuncion As Eniac.Controles.Label
   Friend WithEvents lblUltimaFechaEjecucion As Eniac.Controles.Label
   Friend WithEvents txtUltimaFechaEjecucion As Eniac.Controles.TextBox
End Class
