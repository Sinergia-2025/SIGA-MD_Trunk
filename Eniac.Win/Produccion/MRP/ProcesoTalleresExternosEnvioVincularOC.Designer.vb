<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcesoTalleresExternosEnvioVincularOC
   Inherits BaseForm

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
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("masivo")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionTipoComprobante")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotalConImpuestos")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantEntregada")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadNuevoEstado")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Forma de Pago")
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
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProcesoTalleresExternosEnvioVincularOC))
      Me.txtPedido = New Eniac.Controles.TextBox()
      Me.txtProducto = New Eniac.Controles.TextBox()
      Me.txtOrdenProduccion = New Eniac.Controles.TextBox()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.Label4 = New Eniac.Controles.Label()
      Me.ugOC = New Eniac.Win.UltraGridEditable()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.pnlInfoOP = New System.Windows.Forms.Panel()
      Me.pnlInfoOP2 = New System.Windows.Forms.TableLayoutPanel()
      Me.lblCantidad = New Eniac.Controles.Label()
      Me.txtCantidad = New Eniac.Controles.TextBox()
        CType(Me.ugOC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlInfoOP.SuspendLayout()
        Me.pnlInfoOP2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPedido
        '
        Me.txtPedido.BindearPropiedadControl = ""
        Me.txtPedido.BindearPropiedadEntidad = ""
        Me.txtPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPedido.Formato = ""
        Me.txtPedido.IsDecimal = False
        Me.txtPedido.IsNumber = True
        Me.txtPedido.IsPK = False
        Me.txtPedido.IsRequired = False
        Me.txtPedido.Key = ""
        Me.txtPedido.LabelAsoc = Nothing
        Me.txtPedido.Location = New System.Drawing.Point(657, 16)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.ReadOnly = True
        Me.txtPedido.Size = New System.Drawing.Size(236, 20)
        Me.txtPedido.TabIndex = 92
        '
        'txtProducto
        '
        Me.txtProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProducto.BindearPropiedadControl = ""
        Me.txtProducto.BindearPropiedadEntidad = ""
        Me.txtProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProducto.Formato = ""
        Me.txtProducto.IsDecimal = False
        Me.txtProducto.IsNumber = True
        Me.txtProducto.IsPK = False
        Me.txtProducto.IsRequired = False
        Me.txtProducto.Key = ""
        Me.txtProducto.LabelAsoc = Nothing
        Me.txtProducto.Location = New System.Drawing.Point(245, 16)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(300, 20)
        Me.txtProducto.TabIndex = 93
        '
        'txtOrdenProduccion
        '
        Me.txtOrdenProduccion.BindearPropiedadControl = ""
        Me.txtOrdenProduccion.BindearPropiedadEntidad = ""
        Me.txtOrdenProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdenProduccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdenProduccion.Formato = ""
        Me.txtOrdenProduccion.IsDecimal = False
        Me.txtOrdenProduccion.IsNumber = True
        Me.txtOrdenProduccion.IsPK = False
        Me.txtOrdenProduccion.IsRequired = False
        Me.txtOrdenProduccion.Key = ""
        Me.txtOrdenProduccion.LabelAsoc = Nothing
        Me.txtOrdenProduccion.Location = New System.Drawing.Point(3, 16)
        Me.txtOrdenProduccion.Name = "txtOrdenProduccion"
        Me.txtOrdenProduccion.ReadOnly = True
        Me.txtOrdenProduccion.Size = New System.Drawing.Size(236, 20)
        Me.txtOrdenProduccion.TabIndex = 95
        '
        'dtpFecha
        '
        Me.dtpFecha.BindearPropiedadControl = Nothing
        Me.dtpFecha.BindearPropiedadEntidad = Nothing
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.IsPK = False
        Me.dtpFecha.IsRequired = False
        Me.dtpFecha.Key = ""
        Me.dtpFecha.LabelAsoc = Me.lblFecha
        Me.dtpFecha.Location = New System.Drawing.Point(899, 16)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(82, 20)
        Me.dtpFecha.TabIndex = 88
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(899, 0)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 89
        Me.lblFecha.Text = "&Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(657, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Pedido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(245, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Producto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Órden"
        '
        'ugOC
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugOC.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = "Masivo"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 47
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance2
        UltraGridColumn2.Format = "dd/MM/yyyy"
        UltraGridColumn2.Header.Caption = "Fecha"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.VisiblePosition = 2
        UltraGridColumn12.Hidden = True
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "Tipo Comprobante"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance3
        UltraGridColumn4.Header.Caption = "L."
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 20
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance4
        UltraGridColumn5.Header.Caption = "Emisor"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 50
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance5
        UltraGridColumn6.Header.Caption = "Número"
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Width = 65
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance6
        UltraGridColumn7.Format = "N2"
        UltraGridColumn7.Header.Caption = "Total"
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Width = 100
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.Caption = "Observación"
        UltraGridColumn8.Header.VisiblePosition = 11
        UltraGridColumn8.Width = 255
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance7
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 100
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance8
        UltraGridColumn13.Format = "N2"
        UltraGridColumn13.Header.Caption = "Cantidad Pendiente"
        UltraGridColumn13.Header.VisiblePosition = 9
        UltraGridColumn13.Width = 100
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance9
        UltraGridColumn10.Format = "N2"
        UltraGridColumn10.Header.Caption = "Cantidad A Vincular"
        UltraGridColumn10.Header.VisiblePosition = 10
        UltraGridColumn10.Width = 100
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.VisiblePosition = 12
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn12, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn13, UltraGridColumn10, UltraGridColumn11})
        Me.ugOC.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugOC.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugOC.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugOC.DisplayLayout.GroupByBox.Appearance = Appearance10
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugOC.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance11
        Me.ugOC.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance12.BackColor2 = System.Drawing.SystemColors.Control
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugOC.DisplayLayout.GroupByBox.PromptAppearance = Appearance12
        Me.ugOC.DisplayLayout.MaxColScrollRegions = 1
        Me.ugOC.DisplayLayout.MaxRowScrollRegions = 1
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugOC.DisplayLayout.Override.ActiveCellAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.SystemColors.Highlight
        Appearance14.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugOC.DisplayLayout.Override.ActiveRowAppearance = Appearance14
        Me.ugOC.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugOC.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugOC.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugOC.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugOC.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Me.ugOC.DisplayLayout.Override.CardAreaAppearance = Appearance15
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugOC.DisplayLayout.Override.CellAppearance = Appearance16
        Me.ugOC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugOC.DisplayLayout.Override.CellPadding = 0
        Appearance17.BackColor = System.Drawing.SystemColors.Control
        Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.BorderColor = System.Drawing.SystemColors.Window
        Me.ugOC.DisplayLayout.Override.GroupByRowAppearance = Appearance17
        Appearance18.TextHAlignAsString = "Left"
        Me.ugOC.DisplayLayout.Override.HeaderAppearance = Appearance18
        Me.ugOC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugOC.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.BorderColor = System.Drawing.Color.Silver
        Me.ugOC.DisplayLayout.Override.RowAppearance = Appearance19
        Me.ugOC.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugOC.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
        Me.ugOC.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugOC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugOC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugOC.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugOC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugOC.EnterMueveACeldaDeAbajo = True
        Me.ugOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugOC.Location = New System.Drawing.Point(0, 39)
        Me.ugOC.Name = "ugOC"
        Me.ugOC.Size = New System.Drawing.Size(984, 467)
        Me.ugOC.TabIndex = 96
        Me.ugOC.Text = "UltraGrid1"
        Me.ugOC.ToolStripLabelRegistros = Nothing
        Me.ugOC.ToolStripMenuExpandir = Nothing
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.ToolStripProgressBar1, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 97
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
        Me.tssInfo.Spring = True
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ToolStripProgressBar1.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.btnAceptar)
        Me.Panel2.Controls.Add(Me.btnCancelar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 506)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 33)
        Me.Panel2.TabIndex = 98
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(775, 0)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 30)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar (F4)"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(881, 0)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 30)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'pnlInfoOP
        '
        Me.pnlInfoOP.Controls.Add(Me.pnlInfoOP2)
        Me.pnlInfoOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfoOP.Location = New System.Drawing.Point(0, 0)
        Me.pnlInfoOP.Name = "pnlInfoOP"
        Me.pnlInfoOP.Size = New System.Drawing.Size(984, 39)
        Me.pnlInfoOP.TabIndex = 99
        '
        'pnlInfoOP2
        '
        Me.pnlInfoOP2.ColumnCount = 5
        Me.pnlInfoOP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlInfoOP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlInfoOP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlInfoOP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlInfoOP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlInfoOP2.Controls.Add(Me.txtOrdenProduccion, 0, 1)
        Me.pnlInfoOP2.Controls.Add(Me.lblFecha, 4, 0)
        Me.pnlInfoOP2.Controls.Add(Me.dtpFecha, 4, 1)
        Me.pnlInfoOP2.Controls.Add(Me.lblCantidad, 2, 0)
        Me.pnlInfoOP2.Controls.Add(Me.txtCantidad, 2, 1)
        Me.pnlInfoOP2.Controls.Add(Me.Label4, 0, 0)
        Me.pnlInfoOP2.Controls.Add(Me.txtProducto, 1, 1)
        Me.pnlInfoOP2.Controls.Add(Me.txtPedido, 3, 1)
        Me.pnlInfoOP2.Controls.Add(Me.Label2, 1, 0)
        Me.pnlInfoOP2.Controls.Add(Me.Label3, 3, 0)
        Me.pnlInfoOP2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInfoOP2.Location = New System.Drawing.Point(0, 0)
        Me.pnlInfoOP2.Name = "pnlInfoOP2"
        Me.pnlInfoOP2.RowCount = 2
        Me.pnlInfoOP2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlInfoOP2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlInfoOP2.Size = New System.Drawing.Size(984, 39)
        Me.pnlInfoOP2.TabIndex = 98
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCantidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(551, 0)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 96
        Me.lblCantidad.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.BindearPropiedadControl = ""
        Me.txtCantidad.BindearPropiedadEntidad = ""
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "N2"
        Me.txtCantidad.IsDecimal = False
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Nothing
        Me.txtCantidad.Location = New System.Drawing.Point(551, 16)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidad.TabIndex = 97
        Me.txtCantidad.Text = "0.00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ProcesoTalleresExternosEnvioVincularOC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.ugOC)
        Me.Controls.Add(Me.pnlInfoOP)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.stsStado)
        Me.Name = "ProcesoTalleresExternosEnvioVincularOC"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vincular Orden de Compra"
        CType(Me.ugOC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlInfoOP.ResumeLayout(False)
        Me.pnlInfoOP2.ResumeLayout(False)
        Me.pnlInfoOP2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPedido As Controles.TextBox
    Friend WithEvents txtProducto As Controles.TextBox
    Friend WithEvents txtOrdenProduccion As Controles.TextBox
    Friend WithEvents dtpFecha As Controles.DateTimePicker
    Friend WithEvents lblFecha As Controles.Label
    Friend WithEvents Label3 As Controles.Label
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents Label4 As Controles.Label
   Friend WithEvents ugOC As UltraGridEditable
   Protected Friend WithEvents stsStado As StatusStrip
    Protected Friend WithEvents tssInfo As ToolStripStatusLabel
    Protected Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Protected WithEvents tssRegistros As ToolStripStatusLabel
    Private WithEvents imageList1 As ImageList
    Friend WithEvents Panel2 As Panel
    Protected WithEvents btnAceptar As Button
    Protected WithEvents btnCancelar As Button
    Friend WithEvents pnlInfoOP As Panel
   Friend WithEvents txtCantidad As Controles.TextBox
   Friend WithEvents lblCantidad As Controles.Label
    Friend WithEvents pnlInfoOP2 As TableLayoutPanel
End Class
