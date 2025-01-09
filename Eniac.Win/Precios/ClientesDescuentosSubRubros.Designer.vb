<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClientesDescuentosSubRubros
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesDescuentosSubRubros))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubRubro")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargo")
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
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblSubRubro = New Eniac.Controles.Label()
      Me.bscSubRubro = New Eniac.Controles.Buscador2()
      Me.lblDescuento = New Eniac.Controles.Label()
      Me.txtDescuento = New Eniac.Controles.TextBox()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.txtNombreRubro = New Eniac.Controles.TextBox()
      Me.lblRubro = New Eniac.Controles.Label()
      Me.pnlSubRubros = New System.Windows.Forms.Panel()
      Me.ugDetalle = New Eniac.Win.UltraGridSiga()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tspFacturacion.SuspendLayout()
      Me.grbCliente.SuspendLayout()
      Me.pnlSubRubros.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ConfigBuscador = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = True
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(108, 15)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 1
      '
      'lblCliente
      '
      Me.lblCliente.AutoSize = True
      Me.lblCliente.LabelAsoc = Nothing
      Me.lblCliente.Location = New System.Drawing.Point(50, 20)
      Me.lblCliente.Name = "lblCliente"
      Me.lblCliente.Size = New System.Drawing.Size(39, 13)
      Me.lblCliente.TabIndex = 0
      Me.lblCliente.Text = "Cliente"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ConfigBuscador = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = False
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Me.lblCliente
      Me.bscCliente.Location = New System.Drawing.Point(205, 15)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(316, 23)
      Me.bscCliente.TabIndex = 2
      '
      'lblSubRubro
      '
      Me.lblSubRubro.AutoSize = True
      Me.lblSubRubro.LabelAsoc = Nothing
      Me.lblSubRubro.Location = New System.Drawing.Point(50, 33)
      Me.lblSubRubro.Name = "lblSubRubro"
      Me.lblSubRubro.Size = New System.Drawing.Size(55, 13)
      Me.lblSubRubro.TabIndex = 2
      Me.lblSubRubro.Text = "SubRubro"
      '
      'bscSubRubro
      '
      Me.bscSubRubro.ActivarFiltroEnGrilla = True
      Me.bscSubRubro.BindearPropiedadControl = Nothing
      Me.bscSubRubro.BindearPropiedadEntidad = Nothing
      Me.bscSubRubro.ConfigBuscador = Nothing
      Me.bscSubRubro.Datos = Nothing
      Me.bscSubRubro.FilaDevuelta = Nothing
      Me.bscSubRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.bscSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscSubRubro.IsDecimal = False
      Me.bscSubRubro.IsNumber = False
      Me.bscSubRubro.IsPK = False
      Me.bscSubRubro.IsRequired = False
      Me.bscSubRubro.Key = ""
      Me.bscSubRubro.LabelAsoc = Me.lblSubRubro
      Me.bscSubRubro.Location = New System.Drawing.Point(108, 29)
      Me.bscSubRubro.MaxLengh = "32767"
      Me.bscSubRubro.Name = "bscSubRubro"
      Me.bscSubRubro.Permitido = True
      Me.bscSubRubro.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscSubRubro.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscSubRubro.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscSubRubro.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscSubRubro.Selecciono = False
      Me.bscSubRubro.Size = New System.Drawing.Size(280, 20)
      Me.bscSubRubro.TabIndex = 3
      '
      'lblDescuento
      '
      Me.lblDescuento.AutoSize = True
      Me.lblDescuento.LabelAsoc = Nothing
      Me.lblDescuento.Location = New System.Drawing.Point(410, 33)
      Me.lblDescuento.Name = "lblDescuento"
      Me.lblDescuento.Size = New System.Drawing.Size(39, 13)
      Me.lblDescuento.TabIndex = 4
      Me.lblDescuento.Text = "% D/R"
      '
      'txtDescuento
      '
      Me.txtDescuento.BindearPropiedadControl = Nothing
      Me.txtDescuento.BindearPropiedadEntidad = Nothing
      Me.txtDescuento.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescuento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescuento.Formato = "N2"
      Me.txtDescuento.IsDecimal = True
      Me.txtDescuento.IsNumber = True
      Me.txtDescuento.IsPK = False
      Me.txtDescuento.IsRequired = False
      Me.txtDescuento.Key = ""
      Me.txtDescuento.LabelAsoc = Me.lblDescuento
      Me.txtDescuento.Location = New System.Drawing.Point(455, 29)
      Me.txtDescuento.Name = "txtDescuento"
      Me.txtDescuento.Size = New System.Drawing.Size(66, 20)
      Me.txtDescuento.TabIndex = 5
      Me.txtDescuento.Text = "0.00"
      Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnEliminar
      '
      Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
      Me.btnEliminar.Location = New System.Drawing.Point(585, 12)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 7
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnInsertar
      '
      Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
      Me.btnInsertar.Location = New System.Drawing.Point(542, 12)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 6
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'tspFacturacion
      '
      Me.tspFacturacion.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbGrabar, Me.ToolStripSeparator1, Me.tsbSalir, Me.ToolStripSeparator3})
      Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
      Me.tspFacturacion.Name = "tspFacturacion"
      Me.tspFacturacion.Size = New System.Drawing.Size(684, 29)
      Me.tspFacturacion.TabIndex = 4
      Me.tspFacturacion.Text = "ToolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Enabled = False
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(91, 26)
      Me.tsbGrabar.Text = "&Grabar (F4)"
      Me.tsbGrabar.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'grbCliente
      '
      Me.grbCliente.Controls.Add(Me.lblCliente)
      Me.grbCliente.Controls.Add(Me.bscCliente)
      Me.grbCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grbCliente.Dock = System.Windows.Forms.DockStyle.Top
      Me.grbCliente.Location = New System.Drawing.Point(0, 29)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(684, 41)
      Me.grbCliente.TabIndex = 0
      Me.grbCliente.TabStop = False
      '
      'txtNombreRubro
      '
      Me.txtNombreRubro.BindearPropiedadControl = Nothing
      Me.txtNombreRubro.BindearPropiedadEntidad = Nothing
      Me.txtNombreRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreRubro.Formato = "##0.00"
      Me.txtNombreRubro.IsDecimal = False
      Me.txtNombreRubro.IsNumber = False
      Me.txtNombreRubro.IsPK = False
      Me.txtNombreRubro.IsRequired = False
      Me.txtNombreRubro.Key = ""
      Me.txtNombreRubro.LabelAsoc = Me.lblRubro
      Me.txtNombreRubro.Location = New System.Drawing.Point(108, 3)
      Me.txtNombreRubro.Name = "txtNombreRubro"
      Me.txtNombreRubro.ReadOnly = True
      Me.txtNombreRubro.Size = New System.Drawing.Size(280, 20)
      Me.txtNombreRubro.TabIndex = 1
      Me.txtNombreRubro.TabStop = False
      '
      'lblRubro
      '
      Me.lblRubro.AutoSize = True
      Me.lblRubro.LabelAsoc = Nothing
      Me.lblRubro.Location = New System.Drawing.Point(50, 6)
      Me.lblRubro.Name = "lblRubro"
      Me.lblRubro.Size = New System.Drawing.Size(36, 13)
      Me.lblRubro.TabIndex = 0
      Me.lblRubro.Text = "Rubro"
      '
      'pnlSubRubros
      '
      Me.pnlSubRubros.Controls.Add(Me.txtNombreRubro)
      Me.pnlSubRubros.Controls.Add(Me.lblRubro)
      Me.pnlSubRubros.Controls.Add(Me.btnEliminar)
      Me.pnlSubRubros.Controls.Add(Me.btnInsertar)
      Me.pnlSubRubros.Controls.Add(Me.txtDescuento)
      Me.pnlSubRubros.Controls.Add(Me.lblDescuento)
      Me.pnlSubRubros.Controls.Add(Me.bscSubRubro)
      Me.pnlSubRubros.Controls.Add(Me.lblSubRubro)
      Me.pnlSubRubros.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlSubRubros.Location = New System.Drawing.Point(0, 70)
      Me.pnlSubRubros.Name = "pnlSubRubros"
      Me.pnlSubRubros.Size = New System.Drawing.Size(684, 54)
      Me.pnlSubRubros.TabIndex = 1
      '
      'ugDetalle
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Hidden = True
      UltraGridColumn3.Header.Caption = "Rubro"
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 250
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance2
      UltraGridColumn4.Header.Caption = "Código"
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 80
      UltraGridColumn5.Header.Caption = "SubRubro"
      UltraGridColumn5.Header.VisiblePosition = 4
      UltraGridColumn5.Width = 250
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance3
      UltraGridColumn6.Format = "N2"
      UltraGridColumn6.Header.Caption = "% D/R"
      UltraGridColumn6.Header.VisiblePosition = 5
      UltraGridColumn6.Width = 80
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance4.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance4
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance6.BackColor2 = System.Drawing.SystemColors.Control
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance7
      Appearance8.BackColor = System.Drawing.SystemColors.Highlight
      Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance9
      Appearance10.BorderColor = System.Drawing.Color.Silver
      Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance11.BackColor = System.Drawing.SystemColors.Control
      Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance11.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance11
      Appearance12.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Location = New System.Drawing.Point(0, 124)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(684, 415)
      Me.ugDetalle.TabIndex = 2
      Me.ugDetalle.Text = "UltraGrid1"
      Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(684, 22)
      Me.stsStado.TabIndex = 3
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(605, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'ClientesDescuentosSubRubros
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(684, 561)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.pnlSubRubros)
      Me.Controls.Add(Me.grbCliente)
      Me.Controls.Add(Me.tspFacturacion)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.Name = "ClientesDescuentosSubRubros"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Clientes - Asignación de Descuentos por SubRubros"
      Me.tspFacturacion.ResumeLayout(False)
      Me.tspFacturacion.PerformLayout()
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      Me.pnlSubRubros.ResumeLayout(False)
      Me.pnlSubRubros.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblSubRubro As Eniac.Controles.Label
   Friend WithEvents bscSubRubro As Eniac.Controles.Buscador2
   Friend WithEvents lblDescuento As Eniac.Controles.Label
   Friend WithEvents txtDescuento As Eniac.Controles.TextBox
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtNombreRubro As Eniac.Controles.TextBox
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents pnlSubRubros As Panel
   Friend WithEvents ugDetalle As UltraGridSiga
   Protected Friend WithEvents stsStado As StatusStrip
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As ToolStripProgressBar
   Protected WithEvents tssRegistros As ToolStripStatusLabel
   Friend WithEvents lblCliente As Controles.Label
End Class
