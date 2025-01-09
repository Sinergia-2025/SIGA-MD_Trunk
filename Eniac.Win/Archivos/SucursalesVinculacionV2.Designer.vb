<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SucursalesVinculacionV2
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
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Desvincular")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SucursalOrigen")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDeposito")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DepositoOrigen")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UbicacionOrigen")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalAsociada")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SucursalAsociada")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDepositoAsociado")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DepositoAsociado")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacionAsociada")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UbicacionAsociada")
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
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Desvincular")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("SucursalOrigen")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdDeposito")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DepositoOrigen")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUbicacion")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UbicacionOrigen")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursalAsociada")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("SucursalAsociada")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdDepositoAsociado")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DepositoAsociado")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUbicacionAsociada")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UbicacionAsociada")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SucursalesVinculacionV2))
        Me.ugVinculacionSucDepUbi = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnVincular = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gpbxSucursalAsociada = New System.Windows.Forms.GroupBox()
        Me.txtEmpresaAsociada = New Eniac.Controles.Label()
        Me.lblEmpresaAsociada = New Eniac.Controles.Label()
        Me.lblUbicacionAsociada = New Eniac.Controles.Label()
        Me.cmbUbicacionAsociada = New Eniac.Controles.ComboBox()
        Me.lblDepositoAsociado = New Eniac.Controles.Label()
        Me.cmbDepositoAsociado = New Eniac.Controles.ComboBox()
        Me.lblSucursalAsociada = New Eniac.Controles.Label()
        Me.cmbSucursalAsociada = New Eniac.Controles.ComboBox()
        Me.gpbxSucursalOrigen = New System.Windows.Forms.GroupBox()
        Me.txtEmpresaOrigen = New Eniac.Controles.Label()
        Me.cmbSucursalOrigen = New Eniac.Controles.Label()
        Me.lblEmpresaOrigen = New Eniac.Controles.Label()
        Me.lblUbicacionOrigen = New Eniac.Controles.Label()
        Me.cmbUbicacionOrigen = New Eniac.Controles.ComboBox()
        Me.lblDepositoOrigen = New Eniac.Controles.Label()
        Me.cmbDepositoOrigen = New Eniac.Controles.ComboBox()
        Me.lblSucursalOrigen = New Eniac.Controles.Label()
        Me.btnDesvincular = New System.Windows.Forms.Button()
        CType(Me.ugVinculacionSucDepUbi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbxSucursalAsociada.SuspendLayout()
        Me.gpbxSucursalOrigen.SuspendLayout()
        Me.SuspendLayout()
        '
        'ugVinculacionSucDepUbi
        '
        Me.ugVinculacionSucDepUbi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugVinculacionSucDepUbi.DataSource = Me.UltraDataSource1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugVinculacionSucDepUbi.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn1.Width = 54
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.Caption = "Sucursal"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 130
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.Caption = "Deposito"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 130
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.Header.Caption = "Ubicacion"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 130
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.Header.Caption = "Suc.Asociada"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 130
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.Caption = "Dep.Asociado"
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Width = 130
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.Caption = "Ubic.Asociada"
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Width = 130
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13})
        Me.ugVinculacionSucDepUbi.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugVinculacionSucDepUbi.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugVinculacionSucDepUbi.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVinculacionSucDepUbi.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVinculacionSucDepUbi.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugVinculacionSucDepUbi.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVinculacionSucDepUbi.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.ugVinculacionSucDepUbi.DisplayLayout.MaxColScrollRegions = 1
        Me.ugVinculacionSucDepUbi.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.CellAppearance = Appearance9
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugVinculacionSucDepUbi.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugVinculacionSucDepUbi.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugVinculacionSucDepUbi.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugVinculacionSucDepUbi.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugVinculacionSucDepUbi.Location = New System.Drawing.Point(9, 165)
        Me.ugVinculacionSucDepUbi.Name = "ugVinculacionSucDepUbi"
        Me.ugVinculacionSucDepUbi.Size = New System.Drawing.Size(811, 329)
        Me.ugVinculacionSucDepUbi.TabIndex = 68
        Me.ugVinculacionSucDepUbi.Text = "UltraGrid1"
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13})
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'btnVincular
        '
        Me.btnVincular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVincular.Image = Global.Eniac.Win.My.Resources.Resources.add_24
        Me.btnVincular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVincular.Location = New System.Drawing.Point(493, 503)
        Me.btnVincular.Name = "btnVincular"
        Me.btnVincular.Size = New System.Drawing.Size(97, 30)
        Me.btnVincular.TabIndex = 74
        Me.btnVincular.Text = "Vincular"
        Me.btnVincular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVincular.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(738, 503)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 73
        Me.btnCancelar.Text = "&Salir"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gpbxSucursalAsociada
        '
        Me.gpbxSucursalAsociada.Controls.Add(Me.txtEmpresaAsociada)
        Me.gpbxSucursalAsociada.Controls.Add(Me.lblEmpresaAsociada)
        Me.gpbxSucursalAsociada.Controls.Add(Me.lblUbicacionAsociada)
        Me.gpbxSucursalAsociada.Controls.Add(Me.cmbUbicacionAsociada)
        Me.gpbxSucursalAsociada.Controls.Add(Me.lblDepositoAsociado)
        Me.gpbxSucursalAsociada.Controls.Add(Me.cmbDepositoAsociado)
        Me.gpbxSucursalAsociada.Controls.Add(Me.lblSucursalAsociada)
        Me.gpbxSucursalAsociada.Controls.Add(Me.cmbSucursalAsociada)
        Me.gpbxSucursalAsociada.Location = New System.Drawing.Point(418, 9)
        Me.gpbxSucursalAsociada.Name = "gpbxSucursalAsociada"
        Me.gpbxSucursalAsociada.Size = New System.Drawing.Size(400, 150)
        Me.gpbxSucursalAsociada.TabIndex = 75
        Me.gpbxSucursalAsociada.TabStop = False
        Me.gpbxSucursalAsociada.Text = "Datos Sucursal Asociada"
        '
        'txtEmpresaAsociada
        '
        Me.txtEmpresaAsociada.AutoSize = True
        Me.txtEmpresaAsociada.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEmpresaAsociada.LabelAsoc = Nothing
        Me.txtEmpresaAsociada.Location = New System.Drawing.Point(104, 58)
        Me.txtEmpresaAsociada.Name = "txtEmpresaAsociada"
        Me.txtEmpresaAsociada.Size = New System.Drawing.Size(10, 13)
        Me.txtEmpresaAsociada.TabIndex = 79
        Me.txtEmpresaAsociada.Text = "-"
        '
        'lblEmpresaAsociada
        '
        Me.lblEmpresaAsociada.AutoSize = True
        Me.lblEmpresaAsociada.LabelAsoc = Nothing
        Me.lblEmpresaAsociada.Location = New System.Drawing.Point(11, 58)
        Me.lblEmpresaAsociada.Name = "lblEmpresaAsociada"
        Me.lblEmpresaAsociada.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresaAsociada.TabIndex = 75
        Me.lblEmpresaAsociada.Text = "Empresa"
        '
        'lblUbicacionAsociada
        '
        Me.lblUbicacionAsociada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUbicacionAsociada.AutoSize = True
        Me.lblUbicacionAsociada.LabelAsoc = Nothing
        Me.lblUbicacionAsociada.Location = New System.Drawing.Point(11, 119)
        Me.lblUbicacionAsociada.Name = "lblUbicacionAsociada"
        Me.lblUbicacionAsociada.Size = New System.Drawing.Size(55, 13)
        Me.lblUbicacionAsociada.TabIndex = 71
        Me.lblUbicacionAsociada.Text = "Ubicacion"
        '
        'cmbUbicacionAsociada
        '
        Me.cmbUbicacionAsociada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUbicacionAsociada.BindearPropiedadControl = "SelectedValue"
        Me.cmbUbicacionAsociada.BindearPropiedadEntidad = "IdSucursalAsociada"
        Me.cmbUbicacionAsociada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacionAsociada.Enabled = False
        Me.cmbUbicacionAsociada.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacionAsociada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacionAsociada.FormattingEnabled = True
        Me.cmbUbicacionAsociada.IsPK = False
        Me.cmbUbicacionAsociada.IsRequired = False
        Me.cmbUbicacionAsociada.Key = Nothing
        Me.cmbUbicacionAsociada.LabelAsoc = Nothing
        Me.cmbUbicacionAsociada.Location = New System.Drawing.Point(107, 116)
        Me.cmbUbicacionAsociada.Name = "cmbUbicacionAsociada"
        Me.cmbUbicacionAsociada.Size = New System.Drawing.Size(279, 21)
        Me.cmbUbicacionAsociada.TabIndex = 72
        '
        'lblDepositoAsociado
        '
        Me.lblDepositoAsociado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDepositoAsociado.AutoSize = True
        Me.lblDepositoAsociado.LabelAsoc = Nothing
        Me.lblDepositoAsociado.Location = New System.Drawing.Point(11, 89)
        Me.lblDepositoAsociado.Name = "lblDepositoAsociado"
        Me.lblDepositoAsociado.Size = New System.Drawing.Size(49, 13)
        Me.lblDepositoAsociado.TabIndex = 69
        Me.lblDepositoAsociado.Text = "Deposito"
        '
        'cmbDepositoAsociado
        '
        Me.cmbDepositoAsociado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDepositoAsociado.BindearPropiedadControl = "SelectedValue"
        Me.cmbDepositoAsociado.BindearPropiedadEntidad = "IdSucursalAsociada"
        Me.cmbDepositoAsociado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositoAsociado.Enabled = False
        Me.cmbDepositoAsociado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositoAsociado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositoAsociado.FormattingEnabled = True
        Me.cmbDepositoAsociado.IsPK = False
        Me.cmbDepositoAsociado.IsRequired = False
        Me.cmbDepositoAsociado.Key = Nothing
        Me.cmbDepositoAsociado.LabelAsoc = Nothing
        Me.cmbDepositoAsociado.Location = New System.Drawing.Point(107, 86)
        Me.cmbDepositoAsociado.Name = "cmbDepositoAsociado"
        Me.cmbDepositoAsociado.Size = New System.Drawing.Size(279, 21)
        Me.cmbDepositoAsociado.TabIndex = 70
        '
        'lblSucursalAsociada
        '
        Me.lblSucursalAsociada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSucursalAsociada.AutoSize = True
        Me.lblSucursalAsociada.LabelAsoc = Nothing
        Me.lblSucursalAsociada.Location = New System.Drawing.Point(11, 26)
        Me.lblSucursalAsociada.Name = "lblSucursalAsociada"
        Me.lblSucursalAsociada.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursalAsociada.TabIndex = 67
        Me.lblSucursalAsociada.Text = "Sucursal"
        '
        'cmbSucursalAsociada
        '
        Me.cmbSucursalAsociada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursalAsociada.BindearPropiedadControl = "SelectedValue"
        Me.cmbSucursalAsociada.BindearPropiedadEntidad = "IdSucursalAsociada"
        Me.cmbSucursalAsociada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursalAsociada.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursalAsociada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursalAsociada.FormattingEnabled = True
        Me.cmbSucursalAsociada.IsPK = False
        Me.cmbSucursalAsociada.IsRequired = False
        Me.cmbSucursalAsociada.Key = Nothing
        Me.cmbSucursalAsociada.LabelAsoc = Nothing
        Me.cmbSucursalAsociada.Location = New System.Drawing.Point(107, 23)
        Me.cmbSucursalAsociada.Name = "cmbSucursalAsociada"
        Me.cmbSucursalAsociada.Size = New System.Drawing.Size(279, 21)
        Me.cmbSucursalAsociada.TabIndex = 68
        '
        'gpbxSucursalOrigen
        '
        Me.gpbxSucursalOrigen.Controls.Add(Me.txtEmpresaOrigen)
        Me.gpbxSucursalOrigen.Controls.Add(Me.cmbSucursalOrigen)
        Me.gpbxSucursalOrigen.Controls.Add(Me.lblEmpresaOrigen)
        Me.gpbxSucursalOrigen.Controls.Add(Me.lblUbicacionOrigen)
        Me.gpbxSucursalOrigen.Controls.Add(Me.cmbUbicacionOrigen)
        Me.gpbxSucursalOrigen.Controls.Add(Me.lblDepositoOrigen)
        Me.gpbxSucursalOrigen.Controls.Add(Me.cmbDepositoOrigen)
        Me.gpbxSucursalOrigen.Controls.Add(Me.lblSucursalOrigen)
        Me.gpbxSucursalOrigen.Location = New System.Drawing.Point(9, 9)
        Me.gpbxSucursalOrigen.Name = "gpbxSucursalOrigen"
        Me.gpbxSucursalOrigen.Size = New System.Drawing.Size(393, 150)
        Me.gpbxSucursalOrigen.TabIndex = 78
        Me.gpbxSucursalOrigen.TabStop = False
        Me.gpbxSucursalOrigen.Text = "Datos Sucursal Origen"
        '
        'txtEmpresaOrigen
        '
        Me.txtEmpresaOrigen.AutoSize = True
        Me.txtEmpresaOrigen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEmpresaOrigen.LabelAsoc = Nothing
        Me.txtEmpresaOrigen.Location = New System.Drawing.Point(94, 58)
        Me.txtEmpresaOrigen.Name = "txtEmpresaOrigen"
        Me.txtEmpresaOrigen.Size = New System.Drawing.Size(10, 13)
        Me.txtEmpresaOrigen.TabIndex = 78
        Me.txtEmpresaOrigen.Text = "-"
        '
        'cmbSucursalOrigen
        '
        Me.cmbSucursalOrigen.AutoSize = True
        Me.cmbSucursalOrigen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSucursalOrigen.LabelAsoc = Nothing
        Me.cmbSucursalOrigen.Location = New System.Drawing.Point(94, 26)
        Me.cmbSucursalOrigen.Name = "cmbSucursalOrigen"
        Me.cmbSucursalOrigen.Size = New System.Drawing.Size(10, 13)
        Me.cmbSucursalOrigen.TabIndex = 77
        Me.cmbSucursalOrigen.Text = "-"
        '
        'lblEmpresaOrigen
        '
        Me.lblEmpresaOrigen.AutoSize = True
        Me.lblEmpresaOrigen.LabelAsoc = Nothing
        Me.lblEmpresaOrigen.Location = New System.Drawing.Point(19, 58)
        Me.lblEmpresaOrigen.Name = "lblEmpresaOrigen"
        Me.lblEmpresaOrigen.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresaOrigen.TabIndex = 75
        Me.lblEmpresaOrigen.Text = "Empresa"
        '
        'lblUbicacionOrigen
        '
        Me.lblUbicacionOrigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUbicacionOrigen.AutoSize = True
        Me.lblUbicacionOrigen.LabelAsoc = Nothing
        Me.lblUbicacionOrigen.Location = New System.Drawing.Point(19, 119)
        Me.lblUbicacionOrigen.Name = "lblUbicacionOrigen"
        Me.lblUbicacionOrigen.Size = New System.Drawing.Size(55, 13)
        Me.lblUbicacionOrigen.TabIndex = 71
        Me.lblUbicacionOrigen.Text = "Ubicacion"
        '
        'cmbUbicacionOrigen
        '
        Me.cmbUbicacionOrigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbUbicacionOrigen.BindearPropiedadControl = "SelectedValue"
        Me.cmbUbicacionOrigen.BindearPropiedadEntidad = "IdSucursalAsociada"
        Me.cmbUbicacionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacionOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacionOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacionOrigen.FormattingEnabled = True
        Me.cmbUbicacionOrigen.IsPK = False
        Me.cmbUbicacionOrigen.IsRequired = False
        Me.cmbUbicacionOrigen.Key = Nothing
        Me.cmbUbicacionOrigen.LabelAsoc = Nothing
        Me.cmbUbicacionOrigen.Location = New System.Drawing.Point(97, 116)
        Me.cmbUbicacionOrigen.Name = "cmbUbicacionOrigen"
        Me.cmbUbicacionOrigen.Size = New System.Drawing.Size(283, 21)
        Me.cmbUbicacionOrigen.TabIndex = 72
        '
        'lblDepositoOrigen
        '
        Me.lblDepositoOrigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDepositoOrigen.AutoSize = True
        Me.lblDepositoOrigen.LabelAsoc = Nothing
        Me.lblDepositoOrigen.Location = New System.Drawing.Point(19, 89)
        Me.lblDepositoOrigen.Name = "lblDepositoOrigen"
        Me.lblDepositoOrigen.Size = New System.Drawing.Size(49, 13)
        Me.lblDepositoOrigen.TabIndex = 69
        Me.lblDepositoOrigen.Text = "Deposito"
        '
        'cmbDepositoOrigen
        '
        Me.cmbDepositoOrigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDepositoOrigen.BindearPropiedadControl = "SelectedValue"
        Me.cmbDepositoOrigen.BindearPropiedadEntidad = "IdSucursalAsociada"
        Me.cmbDepositoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositoOrigen.FormattingEnabled = True
        Me.cmbDepositoOrigen.IsPK = False
        Me.cmbDepositoOrigen.IsRequired = False
        Me.cmbDepositoOrigen.Key = Nothing
        Me.cmbDepositoOrigen.LabelAsoc = Nothing
        Me.cmbDepositoOrigen.Location = New System.Drawing.Point(97, 86)
        Me.cmbDepositoOrigen.Name = "cmbDepositoOrigen"
        Me.cmbDepositoOrigen.Size = New System.Drawing.Size(283, 21)
        Me.cmbDepositoOrigen.TabIndex = 70
        '
        'lblSucursalOrigen
        '
        Me.lblSucursalOrigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSucursalOrigen.AutoSize = True
        Me.lblSucursalOrigen.LabelAsoc = Nothing
        Me.lblSucursalOrigen.Location = New System.Drawing.Point(19, 26)
        Me.lblSucursalOrigen.Name = "lblSucursalOrigen"
        Me.lblSucursalOrigen.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursalOrigen.TabIndex = 67
        Me.lblSucursalOrigen.Text = "Sucursal"
        '
        'btnDesvincular
        '
        Me.btnDesvincular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDesvincular.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnDesvincular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesvincular.Location = New System.Drawing.Point(596, 503)
        Me.btnDesvincular.Name = "btnDesvincular"
        Me.btnDesvincular.Size = New System.Drawing.Size(97, 30)
        Me.btnDesvincular.TabIndex = 80
        Me.btnDesvincular.Text = "DesVincular"
        Me.btnDesvincular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDesvincular.UseVisualStyleBackColor = True
        '
        'SucursalesVinculacionV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 544)
        Me.Controls.Add(Me.btnDesvincular)
        Me.Controls.Add(Me.gpbxSucursalOrigen)
        Me.Controls.Add(Me.gpbxSucursalAsociada)
        Me.Controls.Add(Me.btnVincular)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.ugVinculacionSucDepUbi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SucursalesVinculacionV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vinculacion de Sucursales"
        CType(Me.ugVinculacionSucDepUbi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbxSucursalAsociada.ResumeLayout(False)
        Me.gpbxSucursalAsociada.PerformLayout()
        Me.gpbxSucursalOrigen.ResumeLayout(False)
        Me.gpbxSucursalOrigen.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugVinculacionSucDepUbi As UltraGrid
    Private WithEvents imageList1 As ImageList
    Protected WithEvents btnVincular As Button
   Protected WithEvents btnCancelar As Button
   Friend WithEvents gpbxSucursalAsociada As GroupBox
   Friend WithEvents lblUbicacionAsociada As Controles.Label
   Public WithEvents cmbUbicacionAsociada As Controles.ComboBox
   Friend WithEvents lblDepositoAsociado As Controles.Label
   Public WithEvents cmbDepositoAsociado As Controles.ComboBox
   Friend WithEvents lblSucursalAsociada As Controles.Label
   Public WithEvents cmbSucursalAsociada As Controles.ComboBox
    Friend WithEvents lblEmpresaAsociada As Controles.Label
    Friend WithEvents gpbxSucursalOrigen As GroupBox
    Friend WithEvents lblEmpresaOrigen As Controles.Label
    Friend WithEvents lblUbicacionOrigen As Controles.Label
    Public WithEvents cmbUbicacionOrigen As Controles.ComboBox
    Friend WithEvents lblDepositoOrigen As Controles.Label
    Public WithEvents cmbDepositoOrigen As Controles.ComboBox
    Friend WithEvents lblSucursalOrigen As Controles.Label
    Friend WithEvents txtEmpresaOrigen As Controles.Label
    Friend WithEvents cmbSucursalOrigen As Controles.Label
    Friend WithEvents txtEmpresaAsociada As Controles.Label
    Friend WithEvents UltraDataSource1 As UltraWinDataSource.UltraDataSource
    Protected WithEvents btnDesvincular As Button
End Class
