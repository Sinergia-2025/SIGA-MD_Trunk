<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SucursalesDepositosDetalle
   Inherits BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Id")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre")
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
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Id")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Nombre")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.ChbPermitirEscritura = New System.Windows.Forms.CheckBox()
        Me.gpbDepositos = New System.Windows.Forms.GroupBox()
        Me.cmbTipoDeposito = New Eniac.Controles.ComboBox()
        Me.lblTipoDeposito = New Eniac.Controles.Label()
        Me.chbActivo = New Eniac.Controles.CheckBox()
        Me.cmbSucursales = New Eniac.Controles.ComboBox()
        Me.lblSucursalDeposito = New Eniac.Controles.Label()
        Me.chbDisponibleVenta = New Eniac.Controles.CheckBox()
        Me.lblCodigoDeposito = New Eniac.Controles.Label()
        Me.txtCodigoDeposito = New Eniac.Controles.TextBox()
        Me.txtNombreDeposito = New Eniac.Controles.TextBox()
        Me.lblNombreDeposito = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.lblUsuarios = New Eniac.Controles.Label()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.ChbPorDefecto = New System.Windows.Forms.CheckBox()
        Me.ChbResponsable = New System.Windows.Forms.CheckBox()
        Me.ugUsuarios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.ugUsuariosDepositos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gpbDepositos.SuspendLayout()
        CType(Me.ugUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugUsuariosDepositos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(485, 393)
        Me.btnAceptar.TabIndex = 10
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(571, 393)
        Me.btnCancelar.TabIndex = 11
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(384, 393)
        Me.btnCopiar.TabIndex = 13
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(327, 393)
        Me.btnAplicar.TabIndex = 12
        '
        'ChbPermitirEscritura
        '
        Me.ChbPermitirEscritura.AutoSize = True
        Me.ChbPermitirEscritura.Checked = True
        Me.ChbPermitirEscritura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbPermitirEscritura.Location = New System.Drawing.Point(257, 182)
        Me.ChbPermitirEscritura.Name = "ChbPermitirEscritura"
        Me.ChbPermitirEscritura.Size = New System.Drawing.Size(104, 17)
        Me.ChbPermitirEscritura.TabIndex = 5
        Me.ChbPermitirEscritura.Text = "Permitir Escritura"
        Me.ChbPermitirEscritura.UseVisualStyleBackColor = True
        '
        'gpbDepositos
        '
        Me.gpbDepositos.Controls.Add(Me.cmbTipoDeposito)
        Me.gpbDepositos.Controls.Add(Me.lblTipoDeposito)
        Me.gpbDepositos.Controls.Add(Me.chbActivo)
        Me.gpbDepositos.Controls.Add(Me.cmbSucursales)
        Me.gpbDepositos.Controls.Add(Me.lblSucursalDeposito)
        Me.gpbDepositos.Controls.Add(Me.chbDisponibleVenta)
        Me.gpbDepositos.Controls.Add(Me.lblCodigoDeposito)
        Me.gpbDepositos.Controls.Add(Me.txtCodigoDeposito)
        Me.gpbDepositos.Controls.Add(Me.txtNombreDeposito)
        Me.gpbDepositos.Controls.Add(Me.lblNombreDeposito)
        Me.gpbDepositos.Location = New System.Drawing.Point(13, 10)
        Me.gpbDepositos.Name = "gpbDepositos"
        Me.gpbDepositos.Size = New System.Drawing.Size(635, 84)
        Me.gpbDepositos.TabIndex = 0
        Me.gpbDepositos.TabStop = False
        Me.gpbDepositos.Text = "Depositos"
        '
        'cmbTipoDeposito
        '
        Me.cmbTipoDeposito.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoDeposito.BindearPropiedadEntidad = "TipoDeposito"
        Me.cmbTipoDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDeposito.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDeposito.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDeposito.FormattingEnabled = True
        Me.cmbTipoDeposito.IsPK = False
        Me.cmbTipoDeposito.IsRequired = False
        Me.cmbTipoDeposito.Key = Nothing
        Me.cmbTipoDeposito.LabelAsoc = Me.lblTipoDeposito
        Me.cmbTipoDeposito.Location = New System.Drawing.Point(327, 48)
        Me.cmbTipoDeposito.Name = "cmbTipoDeposito"
        Me.cmbTipoDeposito.Size = New System.Drawing.Size(148, 21)
        Me.cmbTipoDeposito.TabIndex = 8
        '
        'lblTipoDeposito
        '
        Me.lblTipoDeposito.AutoSize = True
        Me.lblTipoDeposito.LabelAsoc = Nothing
        Me.lblTipoDeposito.Location = New System.Drawing.Point(271, 51)
        Me.lblTipoDeposito.Name = "lblTipoDeposito"
        Me.lblTipoDeposito.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoDeposito.TabIndex = 7
        Me.lblTipoDeposito.Text = "Tipo"
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(481, 23)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 4
        Me.chbActivo.Text = "Activo"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'cmbSucursales
        '
        Me.cmbSucursales.BindearPropiedadControl = "SelectedValue"
        Me.cmbSucursales.BindearPropiedadEntidad = "IdSucursal"
        Me.cmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.IsPK = True
        Me.cmbSucursales.IsRequired = False
        Me.cmbSucursales.Key = Nothing
        Me.cmbSucursales.LabelAsoc = Me.lblSucursalDeposito
        Me.cmbSucursales.Location = New System.Drawing.Point(66, 19)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.Size = New System.Drawing.Size(199, 21)
        Me.cmbSucursales.TabIndex = 1
        '
        'lblSucursalDeposito
        '
        Me.lblSucursalDeposito.AutoSize = True
        Me.lblSucursalDeposito.LabelAsoc = Nothing
        Me.lblSucursalDeposito.Location = New System.Drawing.Point(12, 23)
        Me.lblSucursalDeposito.Name = "lblSucursalDeposito"
        Me.lblSucursalDeposito.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursalDeposito.TabIndex = 0
        Me.lblSucursalDeposito.Text = "Sucursal"
        '
        'chbDisponibleVenta
        '
        Me.chbDisponibleVenta.AutoSize = True
        Me.chbDisponibleVenta.BindearPropiedadControl = "Checked"
        Me.chbDisponibleVenta.BindearPropiedadEntidad = "DisponibleVenta"
        Me.chbDisponibleVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDisponibleVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDisponibleVenta.IsPK = False
        Me.chbDisponibleVenta.IsRequired = False
        Me.chbDisponibleVenta.Key = Nothing
        Me.chbDisponibleVenta.LabelAsoc = Nothing
        Me.chbDisponibleVenta.Location = New System.Drawing.Point(481, 51)
        Me.chbDisponibleVenta.Name = "chbDisponibleVenta"
        Me.chbDisponibleVenta.Size = New System.Drawing.Size(141, 17)
        Me.chbDisponibleVenta.TabIndex = 9
        Me.chbDisponibleVenta.Text = "Disponible para la Venta"
        Me.chbDisponibleVenta.UseVisualStyleBackColor = True
        '
        'lblCodigoDeposito
        '
        Me.lblCodigoDeposito.AutoSize = True
        Me.lblCodigoDeposito.LabelAsoc = Nothing
        Me.lblCodigoDeposito.Location = New System.Drawing.Point(271, 23)
        Me.lblCodigoDeposito.Name = "lblCodigoDeposito"
        Me.lblCodigoDeposito.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoDeposito.TabIndex = 2
        Me.lblCodigoDeposito.Text = "Codigo"
        '
        'txtCodigoDeposito
        '
        Me.txtCodigoDeposito.BindearPropiedadControl = "Text"
        Me.txtCodigoDeposito.BindearPropiedadEntidad = "CodigoDeposito"
        Me.txtCodigoDeposito.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoDeposito.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoDeposito.Formato = ""
        Me.txtCodigoDeposito.IsDecimal = False
        Me.txtCodigoDeposito.IsNumber = False
        Me.txtCodigoDeposito.IsPK = False
        Me.txtCodigoDeposito.IsRequired = False
        Me.txtCodigoDeposito.Key = ""
        Me.txtCodigoDeposito.LabelAsoc = Me.lblCodigoDeposito
        Me.txtCodigoDeposito.Location = New System.Drawing.Point(327, 19)
        Me.txtCodigoDeposito.MaxLength = 30
        Me.txtCodigoDeposito.Name = "txtCodigoDeposito"
        Me.txtCodigoDeposito.Size = New System.Drawing.Size(148, 20)
        Me.txtCodigoDeposito.TabIndex = 3
        '
        'txtNombreDeposito
        '
        Me.txtNombreDeposito.BindearPropiedadControl = "Text"
        Me.txtNombreDeposito.BindearPropiedadEntidad = "NombreDeposito"
        Me.txtNombreDeposito.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreDeposito.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreDeposito.Formato = ""
        Me.txtNombreDeposito.IsDecimal = False
        Me.txtNombreDeposito.IsNumber = False
        Me.txtNombreDeposito.IsPK = False
        Me.txtNombreDeposito.IsRequired = False
        Me.txtNombreDeposito.Key = ""
        Me.txtNombreDeposito.LabelAsoc = Me.lblNombreDeposito
        Me.txtNombreDeposito.Location = New System.Drawing.Point(66, 48)
        Me.txtNombreDeposito.MaxLength = 50
        Me.txtNombreDeposito.Name = "txtNombreDeposito"
        Me.txtNombreDeposito.Size = New System.Drawing.Size(199, 20)
        Me.txtNombreDeposito.TabIndex = 6
        '
        'lblNombreDeposito
        '
        Me.lblNombreDeposito.AutoSize = True
        Me.lblNombreDeposito.LabelAsoc = Nothing
        Me.lblNombreDeposito.Location = New System.Drawing.Point(12, 52)
        Me.lblNombreDeposito.Name = "lblNombreDeposito"
        Me.lblNombreDeposito.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreDeposito.TabIndex = 5
        Me.lblNombreDeposito.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(356, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Usuarios del Deposito"
        '
        'lblUsuarios
        '
        Me.lblUsuarios.AutoSize = True
        Me.lblUsuarios.LabelAsoc = Nothing
        Me.lblUsuarios.Location = New System.Drawing.Point(10, 106)
        Me.lblUsuarios.Name = "lblUsuarios"
        Me.lblUsuarios.Size = New System.Drawing.Size(48, 13)
        Me.lblUsuarios.TabIndex = 1
        Me.lblUsuarios.Text = "Usuarios"
        '
        'btnQuitar
        '
        Me.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuitar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitar.Location = New System.Drawing.Point(257, 301)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(98, 41)
        Me.btnQuitar.TabIndex = 7
        Me.btnQuitar.Text = "< Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAgregar.Image = Global.Eniac.Win.My.Resources.Resources.add_24
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.Location = New System.Drawing.Point(257, 255)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(98, 41)
        Me.btnAgregar.TabIndex = 6
        Me.btnAgregar.Text = "Agregar >"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'ChbPorDefecto
        '
        Me.ChbPorDefecto.AutoSize = True
        Me.ChbPorDefecto.Checked = True
        Me.ChbPorDefecto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbPorDefecto.Location = New System.Drawing.Point(257, 159)
        Me.ChbPorDefecto.Name = "ChbPorDefecto"
        Me.ChbPorDefecto.Size = New System.Drawing.Size(83, 17)
        Me.ChbPorDefecto.TabIndex = 4
        Me.ChbPorDefecto.Text = "Por Defecto"
        Me.ChbPorDefecto.UseVisualStyleBackColor = True
        '
        'ChbResponsable
        '
        Me.ChbResponsable.AutoSize = True
        Me.ChbResponsable.Checked = True
        Me.ChbResponsable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbResponsable.Location = New System.Drawing.Point(257, 136)
        Me.ChbResponsable.Name = "ChbResponsable"
        Me.ChbResponsable.Size = New System.Drawing.Size(88, 17)
        Me.ChbResponsable.TabIndex = 3
        Me.ChbResponsable.Text = "Responsable"
        Me.ChbResponsable.UseVisualStyleBackColor = True
        '
        'ugUsuarios
        '
        Me.ugUsuarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugUsuarios.DataSource = Me.UltraDataSource2
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugUsuarios.DisplayLayout.Appearance = Appearance1
        UltraGridColumn3.Header.VisiblePosition = 0
        UltraGridColumn3.Width = 68
        UltraGridColumn4.Header.VisiblePosition = 1
        UltraGridColumn4.Width = 149
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn3, UltraGridColumn4})
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
        Me.ugUsuarios.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugUsuarios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugUsuarios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugUsuarios.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugUsuarios.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugUsuarios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugUsuarios.DisplayLayout.Override.CellPadding = 0
        Me.ugUsuarios.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugUsuarios.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Appearance9.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ugUsuarios.DisplayLayout.Override.FilterRowAppearance = Appearance9
        Me.ugUsuarios.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugUsuarios.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugUsuarios.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugUsuarios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugUsuarios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugUsuarios.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugUsuarios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugUsuarios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugUsuarios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugUsuarios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugUsuarios.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugUsuarios.Location = New System.Drawing.Point(13, 122)
        Me.ugUsuarios.Name = "ugUsuarios"
        Me.ugUsuarios.Size = New System.Drawing.Size(238, 267)
        Me.ugUsuarios.TabIndex = 2
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2})
        '
        'ugUsuariosDepositos
        '
        Me.ugUsuariosDepositos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugUsuariosDepositos.DisplayLayout.Appearance = Appearance14
        Me.ugUsuariosDepositos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugUsuariosDepositos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.ugUsuariosDepositos.DisplayLayout.GroupByBox.Appearance = Appearance15
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugUsuariosDepositos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
        Me.ugUsuariosDepositos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance17.BackColor2 = System.Drawing.SystemColors.Control
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugUsuariosDepositos.DisplayLayout.GroupByBox.PromptAppearance = Appearance17
        Me.ugUsuariosDepositos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugUsuariosDepositos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugUsuariosDepositos.DisplayLayout.Override.ActiveCellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.SystemColors.Highlight
        Appearance19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugUsuariosDepositos.DisplayLayout.Override.ActiveRowAppearance = Appearance19
        Me.ugUsuariosDepositos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugUsuariosDepositos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugUsuariosDepositos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Me.ugUsuariosDepositos.DisplayLayout.Override.CardAreaAppearance = Appearance20
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugUsuariosDepositos.DisplayLayout.Override.CellAppearance = Appearance21
        Me.ugUsuariosDepositos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugUsuariosDepositos.DisplayLayout.Override.CellPadding = 0
        Me.ugUsuariosDepositos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugUsuariosDepositos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Appearance22.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ugUsuariosDepositos.DisplayLayout.Override.FilterRowAppearance = Appearance22
        Me.ugUsuariosDepositos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance23.BackColor = System.Drawing.SystemColors.Control
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugUsuariosDepositos.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Appearance24.TextHAlignAsString = "Left"
        Me.ugUsuariosDepositos.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.ugUsuariosDepositos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugUsuariosDepositos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.ugUsuariosDepositos.DisplayLayout.Override.RowAppearance = Appearance25
        Me.ugUsuariosDepositos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugUsuariosDepositos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance26
        Me.ugUsuariosDepositos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugUsuariosDepositos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugUsuariosDepositos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugUsuariosDepositos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugUsuariosDepositos.Location = New System.Drawing.Point(361, 122)
        Me.ugUsuariosDepositos.Name = "ugUsuariosDepositos"
        Me.ugUsuariosDepositos.Size = New System.Drawing.Size(287, 267)
        Me.ugUsuariosDepositos.TabIndex = 9
        Me.ugUsuariosDepositos.Text = "UltraGrid2"
        '
        'SucursalesDepositosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 428)
        Me.Controls.Add(Me.ugUsuariosDepositos)
        Me.Controls.Add(Me.ugUsuarios)
        Me.Controls.Add(Me.ChbResponsable)
        Me.Controls.Add(Me.ChbPorDefecto)
        Me.Controls.Add(Me.ChbPermitirEscritura)
        Me.Controls.Add(Me.gpbDepositos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblUsuarios)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Name = "SucursalesDepositosDetalle"
        Me.Text = "Sucursales Depositos Detalles"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnAgregar, 0)
        Me.Controls.SetChildIndex(Me.btnQuitar, 0)
        Me.Controls.SetChildIndex(Me.lblUsuarios, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.gpbDepositos, 0)
        Me.Controls.SetChildIndex(Me.ChbPermitirEscritura, 0)
        Me.Controls.SetChildIndex(Me.ChbPorDefecto, 0)
        Me.Controls.SetChildIndex(Me.ChbResponsable, 0)
        Me.Controls.SetChildIndex(Me.ugUsuarios, 0)
        Me.Controls.SetChildIndex(Me.ugUsuariosDepositos, 0)
        Me.gpbDepositos.ResumeLayout(False)
        Me.gpbDepositos.PerformLayout()
        CType(Me.ugUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugUsuariosDepositos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChbPermitirEscritura As CheckBox
    Friend WithEvents gpbDepositos As GroupBox
    Friend WithEvents cmbSucursales As Controles.ComboBox
    Friend WithEvents lblSucursalDeposito As Controles.Label
    Friend WithEvents chbDisponibleVenta As Controles.CheckBox
    Friend WithEvents lblCodigoDeposito As Controles.Label
    Friend WithEvents txtCodigoDeposito As Controles.TextBox
    Friend WithEvents txtNombreDeposito As Controles.TextBox
    Friend WithEvents lblNombreDeposito As Controles.Label
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents lblUsuarios As Controles.Label
    Protected WithEvents btnQuitar As Button
    Protected WithEvents btnAgregar As Button
    Friend WithEvents chbActivo As Controles.CheckBox
    Friend WithEvents ChbPorDefecto As CheckBox
    Friend WithEvents ChbResponsable As CheckBox
    Friend WithEvents ugUsuarios As UltraGrid
    Friend WithEvents UltraDataSource2 As UltraWinDataSource.UltraDataSource
    Friend WithEvents ugUsuariosDepositos As UltraGrid
    Friend WithEvents cmbTipoDeposito As Controles.ComboBox
    Friend WithEvents lblTipoDeposito As Controles.Label
End Class
