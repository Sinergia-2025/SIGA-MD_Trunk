<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMTiposNovedadesObjetivosDetalle
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
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Id")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre")
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
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUsuario")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Objetivo")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ObjetivoMinimo")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasHabiles")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ObjetivoDiario")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.lblTipoNovedad = New Eniac.Controles.Label()
      Me.lblPeriodo = New Eniac.Controles.Label()
      Me.dtpPeriodo = New Eniac.Controles.DateTimePicker()
      Me.ugUsuarios = New Eniac.Win.UltraGridEditable()
      Me.ugUsuariosAsignados = New Eniac.Win.UltraGridEditable()
      Me.btnQuitar = New System.Windows.Forms.Button()
      Me.btnAgregar = New System.Windows.Forms.Button()
      Me.txtDiasHabiles = New Eniac.Controles.TextBox()
      Me.lblDiasHabiles = New Eniac.Controles.Label()
      Me.cmbTipoNovedad = New Eniac.Controles.ComboBox()
      CType(Me.ugUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugUsuariosAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(805, 522)
      Me.btnAceptar.TabIndex = 10
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(891, 522)
      Me.btnCancelar.TabIndex = 11
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(704, 522)
      Me.btnCopiar.TabIndex = 13
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(647, 522)
      Me.btnAplicar.TabIndex = 12
      '
      'lblTipoNovedad
      '
      Me.lblTipoNovedad.AutoSize = True
      Me.lblTipoNovedad.LabelAsoc = Nothing
      Me.lblTipoNovedad.Location = New System.Drawing.Point(54, 35)
      Me.lblTipoNovedad.Name = "lblTipoNovedad"
      Me.lblTipoNovedad.Size = New System.Drawing.Size(75, 13)
      Me.lblTipoNovedad.TabIndex = 0
      Me.lblTipoNovedad.Text = "Tipo Novedad"
      '
      'lblPeriodo
      '
      Me.lblPeriodo.AutoSize = True
      Me.lblPeriodo.LabelAsoc = Nothing
      Me.lblPeriodo.Location = New System.Drawing.Point(54, 62)
      Me.lblPeriodo.Name = "lblPeriodo"
      Me.lblPeriodo.Size = New System.Drawing.Size(43, 13)
      Me.lblPeriodo.TabIndex = 2
      Me.lblPeriodo.Text = "Periodo"
      '
      'dtpPeriodo
      '
      Me.dtpPeriodo.BindearPropiedadControl = "Value"
      Me.dtpPeriodo.BindearPropiedadEntidad = "PeriodoObjetivo"
      Me.dtpPeriodo.CustomFormat = "MM/yyyy"
      Me.dtpPeriodo.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPeriodo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodo.IsPK = True
      Me.dtpPeriodo.IsRequired = True
      Me.dtpPeriodo.Key = ""
      Me.dtpPeriodo.LabelAsoc = Me.lblPeriodo
      Me.dtpPeriodo.Location = New System.Drawing.Point(135, 58)
      Me.dtpPeriodo.Name = "dtpPeriodo"
      Me.dtpPeriodo.Size = New System.Drawing.Size(87, 20)
      Me.dtpPeriodo.TabIndex = 3
      '
      'ugUsuarios
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugUsuarios.DisplayLayout.Appearance = Appearance1
      UltraGridColumn7.Header.Caption = "Código"
      UltraGridColumn7.Header.VisiblePosition = 0
      UltraGridColumn8.Header.VisiblePosition = 1
      UltraGridColumn8.Width = 163
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn7, UltraGridColumn8})
      Me.ugUsuarios.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugUsuarios.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugUsuarios.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugUsuarios.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugUsuarios.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugUsuarios.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugUsuarios.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugUsuarios.DisplayLayout.MaxColScrollRegions = 1
      Me.ugUsuarios.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugUsuarios.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugUsuarios.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugUsuarios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugUsuarios.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugUsuarios.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugUsuarios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugUsuarios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugUsuarios.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugUsuarios.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugUsuarios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugUsuarios.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugUsuarios.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugUsuarios.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugUsuarios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugUsuarios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugUsuarios.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugUsuarios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugUsuarios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugUsuarios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugUsuarios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugUsuarios.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugUsuarios.Location = New System.Drawing.Point(12, 84)
      Me.ugUsuarios.Name = "ugUsuarios"
      Me.ugUsuarios.Size = New System.Drawing.Size(290, 432)
      Me.ugUsuarios.TabIndex = 6
      Me.ugUsuarios.Text = "UltraGrid1"
      '
      'ugUsuariosAsignados
      '
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugUsuariosAsignados.DisplayLayout.Appearance = Appearance13
      UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn3.Header.Caption = "Código"
      UltraGridColumn3.Header.VisiblePosition = 0
      UltraGridColumn3.Width = 100
      UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn4.Header.Caption = "Nombre"
      UltraGridColumn4.Header.VisiblePosition = 1
      UltraGridColumn4.Width = 160
      Appearance14.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance14
      UltraGridColumn5.Format = "N0"
      UltraGridColumn5.Header.VisiblePosition = 2
      UltraGridColumn5.MaskInput = "nnnnnnnnn"
      UltraGridColumn5.Width = 80
      Appearance15.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance15
      UltraGridColumn6.Format = "N0"
      UltraGridColumn6.Header.Caption = "Objetivo Mínimo"
      UltraGridColumn6.Header.VisiblePosition = 3
      UltraGridColumn6.MaskInput = "nnnnnnnnn"
      UltraGridColumn6.Width = 80
      UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance16.TextHAlignAsString = "Right"
      UltraGridColumn13.CellAppearance = Appearance16
      UltraGridColumn13.Format = "N0"
      UltraGridColumn13.Header.Caption = "Dias Hábiles"
      UltraGridColumn13.Header.VisiblePosition = 4
      UltraGridColumn13.Width = 80
      UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance17.TextHAlignAsString = "Right"
      UltraGridColumn14.CellAppearance = Appearance17
      UltraGridColumn14.Format = "N2"
      UltraGridColumn14.Header.Caption = "Objetivo Diario"
      UltraGridColumn14.Header.VisiblePosition = 5
      UltraGridColumn14.MaskInput = "{double:-9.2}"
      UltraGridColumn14.Width = 80
      UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn13, UltraGridColumn14})
      Me.ugUsuariosAsignados.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
      Me.ugUsuariosAsignados.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugUsuariosAsignados.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance18.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance18.BorderColor = System.Drawing.SystemColors.Window
      Me.ugUsuariosAsignados.DisplayLayout.GroupByBox.Appearance = Appearance18
      Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugUsuariosAsignados.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance19
      Me.ugUsuariosAsignados.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance20.BackColor2 = System.Drawing.SystemColors.Control
      Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugUsuariosAsignados.DisplayLayout.GroupByBox.PromptAppearance = Appearance20
      Me.ugUsuariosAsignados.DisplayLayout.MaxColScrollRegions = 1
      Me.ugUsuariosAsignados.DisplayLayout.MaxRowScrollRegions = 1
      Appearance21.BackColor = System.Drawing.SystemColors.Window
      Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugUsuariosAsignados.DisplayLayout.Override.ActiveCellAppearance = Appearance21
      Appearance22.BackColor = System.Drawing.SystemColors.Highlight
      Appearance22.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugUsuariosAsignados.DisplayLayout.Override.ActiveRowAppearance = Appearance22
      Me.ugUsuariosAsignados.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugUsuariosAsignados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugUsuariosAsignados.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugUsuariosAsignados.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugUsuariosAsignados.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance23.BackColor = System.Drawing.SystemColors.Window
      Me.ugUsuariosAsignados.DisplayLayout.Override.CardAreaAppearance = Appearance23
      Appearance24.BorderColor = System.Drawing.Color.Silver
      Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugUsuariosAsignados.DisplayLayout.Override.CellAppearance = Appearance24
      Me.ugUsuariosAsignados.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugUsuariosAsignados.DisplayLayout.Override.CellPadding = 0
      Appearance25.BackColor = System.Drawing.SystemColors.Control
      Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance25.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance25.BorderColor = System.Drawing.SystemColors.Window
      Me.ugUsuariosAsignados.DisplayLayout.Override.GroupByRowAppearance = Appearance25
      Appearance26.TextHAlignAsString = "Left"
      Me.ugUsuariosAsignados.DisplayLayout.Override.HeaderAppearance = Appearance26
      Me.ugUsuariosAsignados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugUsuariosAsignados.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance27.BackColor = System.Drawing.SystemColors.Window
      Appearance27.BorderColor = System.Drawing.Color.Silver
      Me.ugUsuariosAsignados.DisplayLayout.Override.RowAppearance = Appearance27
      Me.ugUsuariosAsignados.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugUsuariosAsignados.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
      Me.ugUsuariosAsignados.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugUsuariosAsignados.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugUsuariosAsignados.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugUsuariosAsignados.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugUsuariosAsignados.Location = New System.Drawing.Point(354, 84)
      Me.ugUsuariosAsignados.Name = "ugUsuariosAsignados"
      Me.ugUsuariosAsignados.Size = New System.Drawing.Size(614, 432)
      Me.ugUsuariosAsignados.TabIndex = 9
      Me.ugUsuariosAsignados.Text = "UltraGrid2"
      '
      'btnQuitar
      '
      Me.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.btnQuitar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.btnQuitar.Location = New System.Drawing.Point(308, 200)
      Me.btnQuitar.Name = "btnQuitar"
      Me.btnQuitar.Size = New System.Drawing.Size(40, 40)
      Me.btnQuitar.TabIndex = 8
      Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnQuitar.UseVisualStyleBackColor = True
      '
      'btnAgregar
      '
      Me.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.btnAgregar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.btnAgregar.Location = New System.Drawing.Point(308, 154)
      Me.btnAgregar.Name = "btnAgregar"
      Me.btnAgregar.Size = New System.Drawing.Size(40, 40)
      Me.btnAgregar.TabIndex = 7
      Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAgregar.UseVisualStyleBackColor = True
      '
      'txtDiasHabiles
      '
      Me.txtDiasHabiles.BindearPropiedadControl = ""
      Me.txtDiasHabiles.BindearPropiedadEntidad = ""
      Me.txtDiasHabiles.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDiasHabiles.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDiasHabiles.Formato = ""
      Me.txtDiasHabiles.IsDecimal = False
      Me.txtDiasHabiles.IsNumber = True
      Me.txtDiasHabiles.IsPK = False
      Me.txtDiasHabiles.IsRequired = False
      Me.txtDiasHabiles.Key = ""
      Me.txtDiasHabiles.LabelAsoc = Me.lblDiasHabiles
      Me.txtDiasHabiles.Location = New System.Drawing.Point(230, 58)
      Me.txtDiasHabiles.MaxLength = 8
      Me.txtDiasHabiles.Name = "txtDiasHabiles"
      Me.txtDiasHabiles.ReadOnly = True
      Me.txtDiasHabiles.Size = New System.Drawing.Size(72, 20)
      Me.txtDiasHabiles.TabIndex = 4
      Me.txtDiasHabiles.TabStop = False
      Me.txtDiasHabiles.Text = "0"
      Me.txtDiasHabiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiasHabiles
      '
      Me.lblDiasHabiles.AutoSize = True
      Me.lblDiasHabiles.LabelAsoc = Nothing
      Me.lblDiasHabiles.Location = New System.Drawing.Point(305, 62)
      Me.lblDiasHabiles.Name = "lblDiasHabiles"
      Me.lblDiasHabiles.Size = New System.Drawing.Size(64, 13)
      Me.lblDiasHabiles.TabIndex = 5
      Me.lblDiasHabiles.Text = "días hábiles"
      '
      'cmbTipoNovedad
      '
      Me.cmbTipoNovedad.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoNovedad.BindearPropiedadEntidad = "IdTipoNovedad"
      Me.cmbTipoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoNovedad.FormattingEnabled = True
      Me.cmbTipoNovedad.IsPK = True
      Me.cmbTipoNovedad.IsRequired = True
      Me.cmbTipoNovedad.Key = Nothing
      Me.cmbTipoNovedad.LabelAsoc = Me.lblTipoNovedad
      Me.cmbTipoNovedad.Location = New System.Drawing.Point(135, 31)
      Me.cmbTipoNovedad.Name = "cmbTipoNovedad"
      Me.cmbTipoNovedad.Size = New System.Drawing.Size(167, 21)
      Me.cmbTipoNovedad.TabIndex = 1
      Me.cmbTipoNovedad.TabStop = False
      '
      'CRMTiposNovedadesObjetivosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(980, 557)
      Me.Controls.Add(Me.txtDiasHabiles)
      Me.Controls.Add(Me.lblDiasHabiles)
      Me.Controls.Add(Me.btnQuitar)
      Me.Controls.Add(Me.btnAgregar)
      Me.Controls.Add(Me.ugUsuariosAsignados)
      Me.Controls.Add(Me.ugUsuarios)
      Me.Controls.Add(Me.lblPeriodo)
      Me.Controls.Add(Me.dtpPeriodo)
      Me.Controls.Add(Me.cmbTipoNovedad)
      Me.Controls.Add(Me.lblTipoNovedad)
      Me.Name = "CRMTiposNovedadesObjetivosDetalle"
      Me.Text = "Objetivo por Usuario"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.lblTipoNovedad, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoNovedad, 0)
      Me.Controls.SetChildIndex(Me.dtpPeriodo, 0)
      Me.Controls.SetChildIndex(Me.lblPeriodo, 0)
      Me.Controls.SetChildIndex(Me.ugUsuarios, 0)
      Me.Controls.SetChildIndex(Me.ugUsuariosAsignados, 0)
      Me.Controls.SetChildIndex(Me.btnAgregar, 0)
      Me.Controls.SetChildIndex(Me.btnQuitar, 0)
      Me.Controls.SetChildIndex(Me.lblDiasHabiles, 0)
      Me.Controls.SetChildIndex(Me.txtDiasHabiles, 0)
      CType(Me.ugUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugUsuariosAsignados, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmbTipoNovedad As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoNovedad As Eniac.Controles.Label
   Friend WithEvents lblPeriodo As Eniac.Controles.Label
   Friend WithEvents dtpPeriodo As Eniac.Controles.DateTimePicker
   Friend WithEvents ugUsuarios As UltraGridEditable
   Friend WithEvents ugUsuariosAsignados As UltraGridEditable
   Protected WithEvents btnQuitar As System.Windows.Forms.Button
   Protected WithEvents btnAgregar As System.Windows.Forms.Button
   Friend WithEvents txtDiasHabiles As Eniac.Controles.TextBox
   Friend WithEvents lblDiasHabiles As Eniac.Controles.Label
End Class
