<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnularRequerimientosComprasConfirmar
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnularRequerimientosComprasConfirmar))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selec")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRequerimientoCompra")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAnulacion")
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuarioAnulacion")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadAsignaciones")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Asignaciones")
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
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
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.tbcDetalle = New System.Windows.Forms.TabControl()
      Me.tbpProductos = New System.Windows.Forms.TabPage()
      Me.ugProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.grbProveedor = New System.Windows.Forms.GroupBox()
      Me.lblEmisor = New Eniac.Controles.Label()
      Me.txtEmisor = New Eniac.Controles.TextBox()
      Me.lblNumeroPosible = New Eniac.Controles.Label()
      Me.txtNumeroPosible = New Eniac.Controles.TextBox()
      Me.lblLetra = New Eniac.Controles.Label()
      Me.txtLetra = New Eniac.Controles.TextBox()
      Me.txtTiposComprobantes = New Eniac.Controles.TextBox()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.TextBox()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.btnTodos = New System.Windows.Forms.Button()
      Me.cmbTodos = New Eniac.Controles.ComboBox()
      Me.tbcDetalle.SuspendLayout()
      Me.tbpProductos.SuspendLayout()
      CType(Me.ugProductos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbProveedor.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(719, 3)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(92, 30)
      Me.btnAceptar.TabIndex = 5
      Me.btnAceptar.Text = "&Anular (F4)"
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
      Me.btnCancelar.Location = New System.Drawing.Point(817, 3)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 4
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'tbcDetalle
      '
      Me.tbcDetalle.Controls.Add(Me.tbpProductos)
      Me.tbcDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tbcDetalle.Location = New System.Drawing.Point(0, 84)
      Me.tbcDetalle.Name = "tbcDetalle"
      Me.tbcDetalle.SelectedIndex = 0
      Me.tbcDetalle.Size = New System.Drawing.Size(904, 441)
      Me.tbcDetalle.TabIndex = 7
      Me.tbcDetalle.TabStop = False
      '
      'tbpProductos
      '
      Me.tbpProductos.BackColor = System.Drawing.SystemColors.Control
      Me.tbpProductos.Controls.Add(Me.btnTodos)
      Me.tbpProductos.Controls.Add(Me.cmbTodos)
      Me.tbpProductos.Controls.Add(Me.ugProductos)
      Me.tbpProductos.ImageKey = "product2.ico"
      Me.tbpProductos.Location = New System.Drawing.Point(4, 22)
      Me.tbpProductos.Name = "tbpProductos"
      Me.tbpProductos.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpProductos.Size = New System.Drawing.Size(896, 415)
      Me.tbpProductos.TabIndex = 0
      Me.tbpProductos.Text = "Productos (F9)"
      '
      'ugProductos
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugProductos.DisplayLayout.Appearance = Appearance1
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Header.Caption = ""
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn1.Width = 30
      UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn27.CellAppearance = Appearance3
      UltraGridColumn27.Header.Caption = "# Req."
      UltraGridColumn27.Header.VisiblePosition = 1
      UltraGridColumn27.Hidden = True
      UltraGridColumn27.Width = 70
      UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn28.Header.Caption = "Código"
      UltraGridColumn28.Header.VisiblePosition = 3
      UltraGridColumn28.Width = 100
      UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn29.Header.Caption = "Descripción"
      UltraGridColumn29.Header.VisiblePosition = 4
      UltraGridColumn29.Width = 195
      UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn30.CellAppearance = Appearance4
      UltraGridColumn30.Header.Caption = "Ord."
      UltraGridColumn30.Header.VisiblePosition = 2
      UltraGridColumn30.Hidden = True
      UltraGridColumn30.Width = 50
      UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn31.CellAppearance = Appearance5
      UltraGridColumn31.Format = "N2"
      UltraGridColumn31.Header.VisiblePosition = 5
      UltraGridColumn31.Width = 70
      UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance6.TextHAlignAsString = "Center"
      UltraGridColumn32.CellAppearance = Appearance6
      UltraGridColumn32.Format = "dd/MM/yyyy"
      UltraGridColumn32.Header.Caption = "Fecha Entrega"
      UltraGridColumn32.Header.VisiblePosition = 8
      UltraGridColumn32.Width = 90
      UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn33.Header.VisiblePosition = 7
      UltraGridColumn33.Width = 257
      UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn34.Header.VisiblePosition = 9
      UltraGridColumn34.Hidden = True
      UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn35.Header.VisiblePosition = 10
      UltraGridColumn35.Hidden = True
      UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn36.CellAppearance = Appearance7
      UltraGridColumn36.Format = "N2"
      UltraGridColumn36.Header.VisiblePosition = 6
      UltraGridColumn36.Width = 70
      UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance8
      UltraGridColumn2.Header.Caption = "Cant. Asig."
      UltraGridColumn2.Header.VisiblePosition = 11
      UltraGridColumn2.Width = 37
      UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn37.Header.VisiblePosition = 13
      UltraGridColumn37.Hidden = True
      UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn38.Header.VisiblePosition = 12
      UltraGridColumn38.Hidden = True
      UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn39.Header.VisiblePosition = 14
      UltraGridColumn39.Hidden = True
      UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn40.Header.VisiblePosition = 15
      UltraGridColumn40.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn2, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40})
      Me.ugProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugProductos.DisplayLayout.GroupByBox.Appearance = Appearance9
      Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
      Me.ugProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance11.BackColor2 = System.Drawing.SystemColors.Control
      Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
      Me.ugProductos.DisplayLayout.MaxBandDepth = 1
      Me.ugProductos.DisplayLayout.MaxColScrollRegions = 1
      Me.ugProductos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance12
      Appearance13.BackColor = System.Drawing.SystemColors.Highlight
      Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance13
      Me.ugProductos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugProductos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance14.BackColor = System.Drawing.SystemColors.Window
      Me.ugProductos.DisplayLayout.Override.CardAreaAppearance = Appearance14
      Appearance15.BorderColor = System.Drawing.Color.Silver
      Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugProductos.DisplayLayout.Override.CellAppearance = Appearance15
      Me.ugProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugProductos.DisplayLayout.Override.CellPadding = 0
      Appearance16.BackColor = System.Drawing.SystemColors.Control
      Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance16.BorderColor = System.Drawing.SystemColors.Window
      Me.ugProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance16
      Appearance17.TextHAlignAsString = "Left"
      Me.ugProductos.DisplayLayout.Override.HeaderAppearance = Appearance17
      Me.ugProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance18.BackColor = System.Drawing.SystemColors.Window
      Appearance18.BorderColor = System.Drawing.Color.Silver
      Me.ugProductos.DisplayLayout.Override.RowAppearance = Appearance18
      Me.ugProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
      Me.ugProductos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugProductos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugProductos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugProductos.Location = New System.Drawing.Point(3, 3)
      Me.ugProductos.Name = "ugProductos"
      Me.ugProductos.Size = New System.Drawing.Size(890, 409)
      Me.ugProductos.TabIndex = 3
      Me.ugProductos.Text = "UltraGrid1"
      '
      'grbProveedor
      '
      Me.grbProveedor.Controls.Add(Me.lblEmisor)
      Me.grbProveedor.Controls.Add(Me.txtEmisor)
      Me.grbProveedor.Controls.Add(Me.lblNumeroPosible)
      Me.grbProveedor.Controls.Add(Me.txtNumeroPosible)
      Me.grbProveedor.Controls.Add(Me.lblLetra)
      Me.grbProveedor.Controls.Add(Me.txtLetra)
      Me.grbProveedor.Controls.Add(Me.txtTiposComprobantes)
      Me.grbProveedor.Controls.Add(Me.lblTipoComprobante)
      Me.grbProveedor.Controls.Add(Me.txtObservacion)
      Me.grbProveedor.Controls.Add(Me.lblObservacion)
      Me.grbProveedor.Controls.Add(Me.dtpFecha)
      Me.grbProveedor.Controls.Add(Me.lblFecha)
      Me.grbProveedor.Dock = System.Windows.Forms.DockStyle.Top
      Me.grbProveedor.Location = New System.Drawing.Point(0, 0)
      Me.grbProveedor.Name = "grbProveedor"
      Me.grbProveedor.Size = New System.Drawing.Size(904, 84)
      Me.grbProveedor.TabIndex = 6
      Me.grbProveedor.TabStop = False
      Me.grbProveedor.Text = "Detalle"
      '
      'lblEmisor
      '
      Me.lblEmisor.AutoSize = True
      Me.lblEmisor.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblEmisor.LabelAsoc = Nothing
      Me.lblEmisor.Location = New System.Drawing.Point(235, 16)
      Me.lblEmisor.Name = "lblEmisor"
      Me.lblEmisor.Size = New System.Drawing.Size(44, 13)
      Me.lblEmisor.TabIndex = 14
      Me.lblEmisor.Text = "Numero"
      '
      'txtEmisor
      '
      Me.txtEmisor.BindearPropiedadControl = "Text"
      Me.txtEmisor.BindearPropiedadEntidad = "NumeroRequerimiento"
      Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmisor.Formato = "0"
      Me.txtEmisor.IsDecimal = False
      Me.txtEmisor.IsNumber = True
      Me.txtEmisor.IsPK = False
      Me.txtEmisor.IsRequired = False
      Me.txtEmisor.Key = ""
      Me.txtEmisor.LabelAsoc = Me.lblEmisor
      Me.txtEmisor.Location = New System.Drawing.Point(238, 32)
      Me.txtEmisor.MaxLength = 8
      Me.txtEmisor.Name = "txtEmisor"
      Me.txtEmisor.ReadOnly = True
      Me.txtEmisor.Size = New System.Drawing.Size(47, 20)
      Me.txtEmisor.TabIndex = 15
      Me.txtEmisor.Text = "0"
      Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblNumeroPosible
      '
      Me.lblNumeroPosible.AutoSize = True
      Me.lblNumeroPosible.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNumeroPosible.LabelAsoc = Nothing
      Me.lblNumeroPosible.Location = New System.Drawing.Point(288, 16)
      Me.lblNumeroPosible.Name = "lblNumeroPosible"
      Me.lblNumeroPosible.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroPosible.TabIndex = 6
      Me.lblNumeroPosible.Text = "Numero"
      '
      'txtNumeroPosible
      '
      Me.txtNumeroPosible.BindearPropiedadControl = "Text"
      Me.txtNumeroPosible.BindearPropiedadEntidad = "NumeroRequerimiento"
      Me.txtNumeroPosible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
      Me.txtNumeroPosible.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroPosible.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroPosible.Formato = "0"
      Me.txtNumeroPosible.IsDecimal = False
      Me.txtNumeroPosible.IsNumber = True
      Me.txtNumeroPosible.IsPK = False
      Me.txtNumeroPosible.IsRequired = False
      Me.txtNumeroPosible.Key = ""
      Me.txtNumeroPosible.LabelAsoc = Me.lblNumeroPosible
      Me.txtNumeroPosible.Location = New System.Drawing.Point(291, 32)
      Me.txtNumeroPosible.MaxLength = 8
      Me.txtNumeroPosible.Name = "txtNumeroPosible"
      Me.txtNumeroPosible.ReadOnly = True
      Me.txtNumeroPosible.Size = New System.Drawing.Size(81, 20)
      Me.txtNumeroPosible.TabIndex = 7
      Me.txtNumeroPosible.Text = "0"
      Me.txtNumeroPosible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblLetra
      '
      Me.lblLetra.AutoSize = True
      Me.lblLetra.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblLetra.LabelAsoc = Nothing
      Me.lblLetra.Location = New System.Drawing.Point(204, 16)
      Me.lblLetra.Name = "lblLetra"
      Me.lblLetra.Size = New System.Drawing.Size(28, 13)
      Me.lblLetra.TabIndex = 2
      Me.lblLetra.Text = "Tipo"
      '
      'txtLetra
      '
      Me.txtLetra.BindearPropiedadControl = "Text"
      Me.txtLetra.BindearPropiedadEntidad = "Letra"
      Me.txtLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
      Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLetra.Formato = ""
      Me.txtLetra.IsDecimal = False
      Me.txtLetra.IsNumber = False
      Me.txtLetra.IsPK = False
      Me.txtLetra.IsRequired = False
      Me.txtLetra.Key = ""
      Me.txtLetra.LabelAsoc = Me.lblLetra
      Me.txtLetra.Location = New System.Drawing.Point(207, 32)
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.ReadOnly = True
      Me.txtLetra.Size = New System.Drawing.Size(25, 20)
      Me.txtLetra.TabIndex = 3
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtTiposComprobantes
      '
      Me.txtTiposComprobantes.BindearPropiedadControl = "SelectedValue"
      Me.txtTiposComprobantes.BindearPropiedadEntidad = "idTipoComprobante"
      Me.txtTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
      Me.txtTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTiposComprobantes.Formato = ""
      Me.txtTiposComprobantes.IsDecimal = False
      Me.txtTiposComprobantes.IsNumber = False
      Me.txtTiposComprobantes.IsPK = False
      Me.txtTiposComprobantes.IsRequired = False
      Me.txtTiposComprobantes.Key = Nothing
      Me.txtTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
      Me.txtTiposComprobantes.Location = New System.Drawing.Point(15, 30)
      Me.txtTiposComprobantes.Name = "txtTiposComprobantes"
      Me.txtTiposComprobantes.ReadOnly = True
      Me.txtTiposComprobantes.Size = New System.Drawing.Size(189, 22)
      Me.txtTiposComprobantes.TabIndex = 1
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblTipoComprobante.LabelAsoc = Nothing
      Me.lblTipoComprobante.Location = New System.Drawing.Point(14, 16)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
      Me.lblTipoComprobante.TabIndex = 0
      Me.lblTipoComprobante.Text = "&Tipo Comprobante"
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
      Me.txtObservacion.Location = New System.Drawing.Point(83, 60)
      Me.txtObservacion.MaxLength = 100
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.ReadOnly = True
      Me.txtObservacion.Size = New System.Drawing.Size(603, 20)
      Me.txtObservacion.TabIndex = 11
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblObservacion.LabelAsoc = Nothing
      Me.lblObservacion.Location = New System.Drawing.Point(15, 64)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
      Me.lblObservacion.TabIndex = 10
      Me.lblObservacion.Text = "Observación"
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = "Value"
      Me.dtpFecha.BindearPropiedadEntidad = "Fecha"
      Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Formato = "dd/MM/yyyy"
      Me.dtpFecha.IsDecimal = False
      Me.dtpFecha.IsNumber = False
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(793, 32)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.ReadOnly = True
      Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
      Me.dtpFecha.TabIndex = 9
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblFecha.LabelAsoc = Nothing
      Me.lblFecha.Location = New System.Drawing.Point(750, 36)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 8
      Me.lblFecha.Text = "&Fecha"
      '
      'Panel1
      '
      Me.Panel1.AutoSize = True
      Me.Panel1.Controls.Add(Me.btnAceptar)
      Me.Panel1.Controls.Add(Me.btnCancelar)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel1.Location = New System.Drawing.Point(0, 525)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(904, 36)
      Me.Panel1.TabIndex = 8
      '
      'btnTodos
      '
      Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnTodos.Location = New System.Drawing.Point(813, 10)
      Me.btnTodos.Name = "btnTodos"
      Me.btnTodos.Size = New System.Drawing.Size(75, 23)
      Me.btnTodos.TabIndex = 9
      Me.btnTodos.Text = "Aplicar"
      Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnTodos.UseVisualStyleBackColor = True
      '
      'cmbTodos
      '
      Me.cmbTodos.BindearPropiedadControl = Nothing
      Me.cmbTodos.BindearPropiedadEntidad = Nothing
      Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTodos.FormattingEnabled = True
      Me.cmbTodos.IsPK = False
      Me.cmbTodos.IsRequired = False
      Me.cmbTodos.Key = Nothing
      Me.cmbTodos.LabelAsoc = Nothing
      Me.cmbTodos.Location = New System.Drawing.Point(697, 11)
      Me.cmbTodos.Name = "cmbTodos"
      Me.cmbTodos.Size = New System.Drawing.Size(110, 21)
      Me.cmbTodos.TabIndex = 8
      '
      'AnularRequerimientosComprasConfirmar
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(904, 561)
      Me.Controls.Add(Me.tbcDetalle)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.grbProveedor)
      Me.Name = "AnularRequerimientosComprasConfirmar"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Anular Requerimiento de Compra"
      Me.tbcDetalle.ResumeLayout(False)
      Me.tbpProductos.ResumeLayout(False)
      CType(Me.ugProductos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbProveedor.ResumeLayout(False)
      Me.grbProveedor.PerformLayout()
      Me.Panel1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Private WithEvents imageList1 As ImageList
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
   Friend WithEvents tbcDetalle As TabControl
   Friend WithEvents tbpProductos As TabPage
   Friend WithEvents grbProveedor As GroupBox
   Friend WithEvents lblNumeroPosible As Controles.Label
   Friend WithEvents txtNumeroPosible As Controles.TextBox
   Friend WithEvents lblLetra As Controles.Label
   Friend WithEvents txtLetra As Controles.TextBox
   Friend WithEvents txtTiposComprobantes As Controles.TextBox
   Friend WithEvents lblTipoComprobante As Controles.Label
   Friend WithEvents txtObservacion As Controles.TextBox
   Friend WithEvents lblObservacion As Controles.Label
   Friend WithEvents dtpFecha As Controles.TextBox
   Friend WithEvents lblFecha As Controles.Label
   Friend WithEvents Panel1 As Panel
   Friend WithEvents ugProductos As UltraGrid
   Friend WithEvents lblEmisor As Controles.Label
   Friend WithEvents txtEmisor As Controles.TextBox
   Friend WithEvents btnTodos As Button
   Friend WithEvents cmbTodos As Controles.ComboBox
End Class
