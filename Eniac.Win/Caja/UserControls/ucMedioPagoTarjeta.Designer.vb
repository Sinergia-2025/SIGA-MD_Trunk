<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMedioPagoTarjeta
   Inherits System.Windows.Forms.UserControl

   'UserControl overrides dispose to clean up the component list.
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
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTarjeta")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Monto")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuotas")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroLote")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCupon")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Banco")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tarjeta")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcentajeDelInteres")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MontoDelInteres")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTarjetaCupon")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbTarjetas = New System.Windows.Forms.GroupBox()
        Me.lblNroLote = New Eniac.Controles.Label()
        Me.txtTarNumeroLote = New Eniac.Controles.TextBox()
        Me.btnInsertarTarjeta = New Eniac.Controles.Button()
        Me.btnEliminarTarjeta = New Eniac.Controles.Button()
        Me.lblTarTarjeta = New Eniac.Controles.Label()
      Me.bscTarBanco = New Eniac.Controles.Buscador2()
      Me.lblTarBanco = New Eniac.Controles.Label()
        Me.txtTarNumeroCupon = New Eniac.Controles.TextBox()
        Me.lblTarNumeroCupon = New Eniac.Controles.Label()
        Me.lblTarCuotas = New Eniac.Controles.Label()
        Me.lblTarMonto = New Eniac.Controles.Label()
        Me.txtTarCuotas = New Eniac.Controles.TextBox()
        Me.txtTarMonto = New Eniac.Controles.TextBox()
        Me.ugTarjetas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.cmbTarTarjeta = New Eniac.Controles.ComboBox()
        Me.grbTarjetas.SuspendLayout()
        CType(Me.ugTarjetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbTarjetas
        '
        Me.grbTarjetas.Controls.Add(Me.ugTarjetas)
        Me.grbTarjetas.Controls.Add(Me.lblNroLote)
        Me.grbTarjetas.Controls.Add(Me.txtTarNumeroLote)
        Me.grbTarjetas.Controls.Add(Me.btnInsertarTarjeta)
        Me.grbTarjetas.Controls.Add(Me.btnEliminarTarjeta)
        Me.grbTarjetas.Controls.Add(Me.cmbTarTarjeta)
        Me.grbTarjetas.Controls.Add(Me.lblTarTarjeta)
        Me.grbTarjetas.Controls.Add(Me.bscTarBanco)
        Me.grbTarjetas.Controls.Add(Me.lblTarBanco)
        Me.grbTarjetas.Controls.Add(Me.txtTarNumeroCupon)
        Me.grbTarjetas.Controls.Add(Me.lblTarCuotas)
        Me.grbTarjetas.Controls.Add(Me.lblTarNumeroCupon)
        Me.grbTarjetas.Controls.Add(Me.lblTarMonto)
        Me.grbTarjetas.Controls.Add(Me.txtTarCuotas)
        Me.grbTarjetas.Controls.Add(Me.txtTarMonto)
        Me.grbTarjetas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbTarjetas.Location = New System.Drawing.Point(0, 0)
        Me.grbTarjetas.Name = "grbTarjetas"
        Me.grbTarjetas.Size = New System.Drawing.Size(871, 190)
        Me.grbTarjetas.TabIndex = 0
        Me.grbTarjetas.TabStop = False
        '
        'lblNroLote
        '
        Me.lblNroLote.AutoSize = True
        Me.lblNroLote.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNroLote.LabelAsoc = Nothing
        Me.lblNroLote.Location = New System.Drawing.Point(481, 14)
        Me.lblNroLote.Name = "lblNroLote"
        Me.lblNroLote.Size = New System.Drawing.Size(48, 13)
        Me.lblNroLote.TabIndex = 8
        Me.lblNroLote.Text = "Nro Lote"
        '
        'txtTarNumeroLote
        '
        Me.txtTarNumeroLote.BindearPropiedadControl = Nothing
        Me.txtTarNumeroLote.BindearPropiedadEntidad = Nothing
        Me.txtTarNumeroLote.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTarNumeroLote.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTarNumeroLote.Formato = ""
        Me.txtTarNumeroLote.IsDecimal = False
        Me.txtTarNumeroLote.IsNumber = True
        Me.txtTarNumeroLote.IsPK = False
        Me.txtTarNumeroLote.IsRequired = False
        Me.txtTarNumeroLote.Key = ""
        Me.txtTarNumeroLote.LabelAsoc = Me.lblNroLote
        Me.txtTarNumeroLote.Location = New System.Drawing.Point(484, 28)
        Me.txtTarNumeroLote.MaxLength = 9
        Me.txtTarNumeroLote.Name = "txtTarNumeroLote"
        Me.txtTarNumeroLote.Size = New System.Drawing.Size(45, 20)
        Me.txtTarNumeroLote.TabIndex = 9
        Me.txtTarNumeroLote.Text = "0"
        Me.txtTarNumeroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnInsertarTarjeta
        '
        Me.btnInsertarTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.btnInsertarTarjeta.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertarTarjeta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInsertarTarjeta.Location = New System.Drawing.Point(786, 14)
        Me.btnInsertarTarjeta.Name = "btnInsertarTarjeta"
        Me.btnInsertarTarjeta.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertarTarjeta.TabIndex = 12
        Me.btnInsertarTarjeta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarTarjeta.UseVisualStyleBackColor = True
        '
        'btnEliminarTarjeta
        '
        Me.btnEliminarTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.btnEliminarTarjeta.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminarTarjeta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminarTarjeta.Location = New System.Drawing.Point(824, 14)
        Me.btnEliminarTarjeta.Name = "btnEliminarTarjeta"
        Me.btnEliminarTarjeta.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminarTarjeta.TabIndex = 13
        Me.btnEliminarTarjeta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarTarjeta.UseVisualStyleBackColor = True
        '
        'lblTarTarjeta
        '
        Me.lblTarTarjeta.AutoSize = True
        Me.lblTarTarjeta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTarTarjeta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTarTarjeta.LabelAsoc = Nothing
        Me.lblTarTarjeta.Location = New System.Drawing.Point(3, 14)
        Me.lblTarTarjeta.Name = "lblTarTarjeta"
        Me.lblTarTarjeta.Size = New System.Drawing.Size(40, 13)
        Me.lblTarTarjeta.TabIndex = 0
        Me.lblTarTarjeta.Text = "Tarjeta"
      '
      'bscTarBanco
      '
      Me.bscTarBanco.BindearPropiedadControl = Nothing
      Me.bscTarBanco.BindearPropiedadEntidad = Nothing
      Me.bscTarBanco.Datos = Nothing
      Me.bscTarBanco.FilaDevuelta = Nothing
        Me.bscTarBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.bscTarBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscTarBanco.IsDecimal = False
        Me.bscTarBanco.IsNumber = False
        Me.bscTarBanco.IsPK = False
        Me.bscTarBanco.IsRequired = False
        Me.bscTarBanco.Key = ""
        Me.bscTarBanco.LabelAsoc = Me.lblTarBanco
        Me.bscTarBanco.Location = New System.Drawing.Point(159, 29)
        Me.bscTarBanco.MaxLengh = "32767"
        Me.bscTarBanco.Name = "bscTarBanco"
        Me.bscTarBanco.Permitido = True
        Me.bscTarBanco.Selecciono = False
        Me.bscTarBanco.Size = New System.Drawing.Size(193, 20)
        Me.bscTarBanco.TabIndex = 3
      '
      'lblTarBanco
      '
      Me.lblTarBanco.AutoSize = True
        Me.lblTarBanco.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTarBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTarBanco.LabelAsoc = Nothing
        Me.lblTarBanco.Location = New System.Drawing.Point(156, 15)
        Me.lblTarBanco.Name = "lblTarBanco"
        Me.lblTarBanco.Size = New System.Drawing.Size(38, 13)
        Me.lblTarBanco.TabIndex = 2
        Me.lblTarBanco.Text = "Banco"
        '
        'txtTarNumeroCupon
        '
        Me.txtTarNumeroCupon.BindearPropiedadControl = Nothing
        Me.txtTarNumeroCupon.BindearPropiedadEntidad = Nothing
        Me.txtTarNumeroCupon.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTarNumeroCupon.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTarNumeroCupon.Formato = ""
        Me.txtTarNumeroCupon.IsDecimal = False
        Me.txtTarNumeroCupon.IsNumber = True
        Me.txtTarNumeroCupon.IsPK = False
        Me.txtTarNumeroCupon.IsRequired = False
        Me.txtTarNumeroCupon.Key = ""
        Me.txtTarNumeroCupon.LabelAsoc = Me.lblTarNumeroCupon
        Me.txtTarNumeroCupon.Location = New System.Drawing.Point(536, 28)
        Me.txtTarNumeroCupon.MaxLength = 9
        Me.txtTarNumeroCupon.Name = "txtTarNumeroCupon"
        Me.txtTarNumeroCupon.Size = New System.Drawing.Size(90, 20)
        Me.txtTarNumeroCupon.TabIndex = 11
        Me.txtTarNumeroCupon.Text = "0"
        Me.txtTarNumeroCupon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTarNumeroCupon
        '
        Me.lblTarNumeroCupon.AutoSize = True
        Me.lblTarNumeroCupon.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTarNumeroCupon.LabelAsoc = Nothing
        Me.lblTarNumeroCupon.Location = New System.Drawing.Point(533, 13)
        Me.lblTarNumeroCupon.Name = "lblTarNumeroCupon"
        Me.lblTarNumeroCupon.Size = New System.Drawing.Size(61, 13)
        Me.lblTarNumeroCupon.TabIndex = 10
        Me.lblTarNumeroCupon.Text = "Nro. Cupon"
        '
        'lblTarCuotas
        '
        Me.lblTarCuotas.AutoSize = True
        Me.lblTarCuotas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTarCuotas.LabelAsoc = Nothing
        Me.lblTarCuotas.Location = New System.Drawing.Point(417, 13)
        Me.lblTarCuotas.Name = "lblTarCuotas"
        Me.lblTarCuotas.Size = New System.Drawing.Size(40, 13)
        Me.lblTarCuotas.TabIndex = 6
        Me.lblTarCuotas.Text = "Cuotas"
        '
        'lblTarMonto
        '
        Me.lblTarMonto.AutoSize = True
        Me.lblTarMonto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTarMonto.LabelAsoc = Nothing
        Me.lblTarMonto.Location = New System.Drawing.Point(350, 13)
        Me.lblTarMonto.Name = "lblTarMonto"
        Me.lblTarMonto.Size = New System.Drawing.Size(37, 13)
        Me.lblTarMonto.TabIndex = 4
        Me.lblTarMonto.Text = "Monto"
        '
        'txtTarCuotas
        '
        Me.txtTarCuotas.BindearPropiedadControl = Nothing
        Me.txtTarCuotas.BindearPropiedadEntidad = Nothing
        Me.txtTarCuotas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTarCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTarCuotas.Formato = "0"
        Me.txtTarCuotas.IsDecimal = False
        Me.txtTarCuotas.IsNumber = True
        Me.txtTarCuotas.IsPK = False
        Me.txtTarCuotas.IsRequired = False
        Me.txtTarCuotas.Key = ""
        Me.txtTarCuotas.LabelAsoc = Me.lblTarCuotas
        Me.txtTarCuotas.Location = New System.Drawing.Point(419, 28)
        Me.txtTarCuotas.MaxLength = 8
        Me.txtTarCuotas.Name = "txtTarCuotas"
        Me.txtTarCuotas.Size = New System.Drawing.Size(57, 20)
        Me.txtTarCuotas.TabIndex = 7
        Me.txtTarCuotas.Text = "1"
        Me.txtTarCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTarMonto
        '
        Me.txtTarMonto.BindearPropiedadControl = Nothing
        Me.txtTarMonto.BindearPropiedadEntidad = Nothing
        Me.txtTarMonto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTarMonto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTarMonto.Formato = "##0.00"
        Me.txtTarMonto.IsDecimal = True
        Me.txtTarMonto.IsNumber = True
        Me.txtTarMonto.IsPK = False
        Me.txtTarMonto.IsRequired = False
        Me.txtTarMonto.Key = ""
        Me.txtTarMonto.LabelAsoc = Me.lblTarMonto
        Me.txtTarMonto.Location = New System.Drawing.Point(353, 28)
        Me.txtTarMonto.MaxLength = 10
        Me.txtTarMonto.Name = "txtTarMonto"
        Me.txtTarMonto.Size = New System.Drawing.Size(60, 20)
        Me.txtTarMonto.TabIndex = 5
        Me.txtTarMonto.Text = "0.00"
        Me.txtTarMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ugTarjetas
        '
        Me.ugTarjetas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugTarjetas.DisplayLayout.Appearance = Appearance1
        UltraGridColumn16.Header.Caption = "Tarjeta"
        UltraGridColumn16.Header.VisiblePosition = 0
        UltraGridColumn16.Width = 180
        UltraGridColumn17.Header.VisiblePosition = 1
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.Header.Caption = "Banco"
        UltraGridColumn18.Header.VisiblePosition = 2
        UltraGridColumn18.Width = 180
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance2
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.VisiblePosition = 3
        UltraGridColumn19.Width = 100
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance3
        UltraGridColumn20.Header.VisiblePosition = 4
        UltraGridColumn20.Width = 70
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance4
        UltraGridColumn21.Header.Caption = "Nro. Lote"
        UltraGridColumn21.Header.VisiblePosition = 5
        UltraGridColumn21.Width = 70
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance5
        UltraGridColumn22.Header.Caption = "Nro. Cupon"
        UltraGridColumn22.Header.VisiblePosition = 6
        UltraGridColumn22.Width = 70
        UltraGridColumn23.Header.VisiblePosition = 7
        UltraGridColumn23.Hidden = True
        UltraGridColumn24.Header.VisiblePosition = 8
        UltraGridColumn24.Hidden = True
        UltraGridColumn25.Header.VisiblePosition = 9
        UltraGridColumn25.Hidden = True
        UltraGridColumn26.Header.VisiblePosition = 10
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.Header.VisiblePosition = 11
        UltraGridColumn27.Hidden = True
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance6
        UltraGridColumn28.Header.VisiblePosition = 12
        UltraGridColumn28.Hidden = True
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance7
        UltraGridColumn29.Header.VisiblePosition = 13
        UltraGridColumn29.Hidden = True
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance8
        UltraGridColumn30.Header.VisiblePosition = 14
        UltraGridColumn30.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30})
        Me.ugTarjetas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugTarjetas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugTarjetas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugTarjetas.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugTarjetas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.ugTarjetas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugTarjetas.DisplayLayout.GroupByBox.Hidden = True
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugTarjetas.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.ugTarjetas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugTarjetas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugTarjetas.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugTarjetas.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.ugTarjetas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugTarjetas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.ugTarjetas.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugTarjetas.DisplayLayout.Override.CellAppearance = Appearance15
        Me.ugTarjetas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugTarjetas.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugTarjetas.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.ugTarjetas.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.ugTarjetas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugTarjetas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.ugTarjetas.DisplayLayout.Override.RowAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugTarjetas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.ugTarjetas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugTarjetas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugTarjetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugTarjetas.Location = New System.Drawing.Point(6, 54)
        Me.ugTarjetas.Name = "ugTarjetas"
        Me.ugTarjetas.Size = New System.Drawing.Size(859, 130)
        Me.ugTarjetas.TabIndex = 14
        Me.ugTarjetas.Text = "UltraGrid1"
        '
        'cmbTarTarjeta
        '
        Me.cmbTarTarjeta.BindearPropiedadControl = ""
        Me.cmbTarTarjeta.BindearPropiedadEntidad = ""
        Me.cmbTarTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTarTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTarTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTarTarjeta.FormattingEnabled = True
        Me.cmbTarTarjeta.IsPK = False
        Me.cmbTarTarjeta.IsRequired = False
        Me.cmbTarTarjeta.Key = Nothing
        Me.cmbTarTarjeta.LabelAsoc = Me.lblTarTarjeta
        Me.cmbTarTarjeta.Location = New System.Drawing.Point(6, 28)
        Me.cmbTarTarjeta.Name = "cmbTarTarjeta"
        Me.cmbTarTarjeta.Size = New System.Drawing.Size(147, 21)
        Me.cmbTarTarjeta.TabIndex = 1
        '
        'ucMedioPagoTarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grbTarjetas)
        Me.Name = "ucMedioPagoTarjeta"
        Me.Size = New System.Drawing.Size(871, 190)
        Me.grbTarjetas.ResumeLayout(False)
        Me.grbTarjetas.PerformLayout()
        CType(Me.ugTarjetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbTarjetas As GroupBox
    Friend WithEvents lblNroLote As Controles.Label
    Friend WithEvents txtTarNumeroLote As Controles.TextBox
    Friend WithEvents btnInsertarTarjeta As Controles.Button
    Friend WithEvents btnEliminarTarjeta As Controles.Button
    Friend WithEvents cmbTarTarjeta As Controles.ComboBox
    Friend WithEvents lblTarTarjeta As Controles.Label
   Friend WithEvents bscTarBanco As Controles.Buscador2
   Friend WithEvents lblTarBanco As Controles.Label
    Friend WithEvents txtTarNumeroCupon As Controles.TextBox
    Friend WithEvents lblTarNumeroCupon As Controles.Label
    Friend WithEvents lblTarCuotas As Controles.Label
    Friend WithEvents lblTarMonto As Controles.Label
    Friend WithEvents txtTarCuotas As Controles.TextBox
    Friend WithEvents txtTarMonto As Controles.TextBox
    Friend WithEvents ugTarjetas As UltraGrid
End Class
