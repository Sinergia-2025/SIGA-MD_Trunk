﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarStockLotesExcel
   'Inherits BaseForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarStockLotesExcel))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importa")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EstadoImporta")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Accion")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLote")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVencimiento")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDeposito")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeposito")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUbicacion")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Mensaje")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.btnLeerExel = New Eniac.Controles.Button()
      Me.txtArchivoOrigen = New Eniac.Controles.TextBox()
      Me.lblArchivo = New Eniac.Controles.Label()
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.ugDetalle = New Eniac.Win.UltraGridSiga()
      Me.grpFiltros = New System.Windows.Forms.GroupBox()
      Me.txtRangoCeldasFilaDesde = New Eniac.Controles.TextBox()
      Me.txtRangoCeldasColumnaHasta = New Eniac.Controles.TextBox()
      Me.txtRangoCeldasFilaHasta = New Eniac.Controles.TextBox()
      Me.txtRangoCeldasColumnaDesde = New Eniac.Controles.TextBox()
      Me.lblEjemplos = New Eniac.Controles.Label()
      Me.Label6 = New Eniac.Controles.Label()
        Me.tstBarra.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLeerExel
        '
        Me.btnLeerExel.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnLeerExel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLeerExel.Location = New System.Drawing.Point(868, 12)
        Me.btnLeerExel.Name = "btnLeerExel"
        Me.btnLeerExel.Size = New System.Drawing.Size(110, 35)
        Me.btnLeerExel.TabIndex = 9
        Me.btnLeerExel.Text = "Leer Excel (F3)"
        Me.btnLeerExel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLeerExel.UseVisualStyleBackColor = True
        '
        'txtArchivoOrigen
        '
        Me.txtArchivoOrigen.BindearPropiedadControl = "Text"
        Me.txtArchivoOrigen.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoOrigen.Formato = ""
        Me.txtArchivoOrigen.IsDecimal = False
        Me.txtArchivoOrigen.IsNumber = False
        Me.txtArchivoOrigen.IsPK = False
        Me.txtArchivoOrigen.IsRequired = False
        Me.txtArchivoOrigen.Key = ""
        Me.txtArchivoOrigen.LabelAsoc = Nothing
        Me.txtArchivoOrigen.Location = New System.Drawing.Point(58, 19)
        Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
        Me.txtArchivoOrigen.Size = New System.Drawing.Size(465, 20)
        Me.txtArchivoOrigen.TabIndex = 1
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.LabelAsoc = Nothing
        Me.lblArchivo.Location = New System.Drawing.Point(6, 23)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(46, 13)
        Me.lblArchivo.TabIndex = 0
        Me.lblArchivo.Text = "Archivo:"
        '
        'imgGrabar
        '
        Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
        Me.imgGrabar.Images.SetKeyName(0, "document_find.ico")
        Me.imgGrabar.Images.SetKeyName(1, "folder.ico")
        Me.imgGrabar.Images.SetKeyName(2, "row_add.ico")
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 3
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImportar
        '
        Me.tsbImportar.Enabled = False
        Me.tsbImportar.Image = CType(resources.GetObject("tsbImportar.Image"), System.Drawing.Image)
        Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImportar.Name = "tsbImportar"
        Me.tsbImportar.Size = New System.Drawing.Size(102, 26)
        Me.tsbImportar.Text = "&Importar (F4)"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tssRegistros})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(984, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.Location = New System.Drawing.Point(529, 12)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(98, 35)
        Me.btnExaminar.TabIndex = 2
        Me.btnExaminar.Text = "&Examinar"
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance2
        UltraGridColumn4.Header.VisiblePosition = 0
        UltraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn4.Width = 53
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Header.Caption = "Importó"
        UltraGridColumn2.Header.VisiblePosition = 10
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 60
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance4
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn3.Width = 51
        UltraGridColumn49.Header.VisiblePosition = 2
        UltraGridColumn15.Header.Caption = "Descripción"
        UltraGridColumn15.Header.VisiblePosition = 3
        UltraGridColumn15.Width = 291
        UltraGridColumn5.Header.Caption = "Lote/Despacho/Manifiesto"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 160
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn6.CellAppearance = Appearance5
        UltraGridColumn6.Header.Caption = "Fecha Vto"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 94
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.Header.Caption = "Depósito"
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Width = 120
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.Header.Caption = "Ubicación"
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn10.Width = 120
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn50.CellAppearance = Appearance6
        UltraGridColumn50.Header.Caption = "Cantidad"
        UltraGridColumn50.Header.VisiblePosition = 7
        UltraGridColumn50.Width = 65
        UltraGridColumn1.Header.VisiblePosition = 12
        UltraGridColumn1.Width = 150
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn4, UltraGridColumn2, UltraGridColumn3, UltraGridColumn49, UltraGridColumn15, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn50, UltraGridColumn1})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance7
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance9.BackColor2 = System.Drawing.SystemColors.Control
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.SystemColors.Highlight
        Appearance11.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance11
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance14.BackColor = System.Drawing.SystemColors.Control
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance14
        Appearance15.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance16
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.InGroupByRows), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 84)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 455)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        '
        'grpFiltros
        '
        Me.grpFiltros.Controls.Add(Me.txtRangoCeldasFilaDesde)
        Me.grpFiltros.Controls.Add(Me.txtRangoCeldasColumnaHasta)
        Me.grpFiltros.Controls.Add(Me.txtRangoCeldasFilaHasta)
        Me.grpFiltros.Controls.Add(Me.txtRangoCeldasColumnaDesde)
        Me.grpFiltros.Controls.Add(Me.lblEjemplos)
        Me.grpFiltros.Controls.Add(Me.Label6)
        Me.grpFiltros.Controls.Add(Me.btnExaminar)
        Me.grpFiltros.Controls.Add(Me.txtArchivoOrigen)
        Me.grpFiltros.Controls.Add(Me.lblArchivo)
        Me.grpFiltros.Controls.Add(Me.btnLeerExel)
        Me.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFiltros.Location = New System.Drawing.Point(0, 29)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(984, 55)
        Me.grpFiltros.TabIndex = 0
        Me.grpFiltros.TabStop = False
        '
        'txtRangoCeldasFilaDesde
        '
        Me.txtRangoCeldasFilaDesde.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasFilaDesde.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasFilaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasFilaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasFilaDesde.Formato = ""
        Me.txtRangoCeldasFilaDesde.IsDecimal = False
        Me.txtRangoCeldasFilaDesde.IsNumber = False
        Me.txtRangoCeldasFilaDesde.IsPK = False
        Me.txtRangoCeldasFilaDesde.IsRequired = False
        Me.txtRangoCeldasFilaDesde.Key = ""
        Me.txtRangoCeldasFilaDesde.LabelAsoc = Nothing
        Me.txtRangoCeldasFilaDesde.Location = New System.Drawing.Point(704, 19)
        Me.txtRangoCeldasFilaDesde.Name = "txtRangoCeldasFilaDesde"
        Me.txtRangoCeldasFilaDesde.Size = New System.Drawing.Size(21, 20)
        Me.txtRangoCeldasFilaDesde.TabIndex = 5
        Me.txtRangoCeldasFilaDesde.TabStop = False
        Me.txtRangoCeldasFilaDesde.Text = "4"
        Me.txtRangoCeldasFilaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRangoCeldasColumnaHasta
        '
        Me.txtRangoCeldasColumnaHasta.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasColumnaHasta.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasColumnaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasColumnaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasColumnaHasta.Formato = ""
        Me.txtRangoCeldasColumnaHasta.IsDecimal = False
        Me.txtRangoCeldasColumnaHasta.IsNumber = False
        Me.txtRangoCeldasColumnaHasta.IsPK = False
        Me.txtRangoCeldasColumnaHasta.IsRequired = False
        Me.txtRangoCeldasColumnaHasta.Key = ""
        Me.txtRangoCeldasColumnaHasta.LabelAsoc = Nothing
        Me.txtRangoCeldasColumnaHasta.Location = New System.Drawing.Point(726, 19)
        Me.txtRangoCeldasColumnaHasta.Name = "txtRangoCeldasColumnaHasta"
        Me.txtRangoCeldasColumnaHasta.ReadOnly = True
        Me.txtRangoCeldasColumnaHasta.Size = New System.Drawing.Size(17, 20)
        Me.txtRangoCeldasColumnaHasta.TabIndex = 6
        Me.txtRangoCeldasColumnaHasta.TabStop = False
        Me.txtRangoCeldasColumnaHasta.Text = ":G"
        Me.txtRangoCeldasColumnaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRangoCeldasFilaHasta
        '
        Me.txtRangoCeldasFilaHasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRangoCeldasFilaHasta.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasFilaHasta.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasFilaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasFilaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasFilaHasta.Formato = ""
        Me.txtRangoCeldasFilaHasta.IsDecimal = False
        Me.txtRangoCeldasFilaHasta.IsNumber = False
        Me.txtRangoCeldasFilaHasta.IsPK = False
        Me.txtRangoCeldasFilaHasta.IsRequired = False
        Me.txtRangoCeldasFilaHasta.Key = ""
        Me.txtRangoCeldasFilaHasta.LabelAsoc = Nothing
        Me.txtRangoCeldasFilaHasta.Location = New System.Drawing.Point(745, 19)
        Me.txtRangoCeldasFilaHasta.Name = "txtRangoCeldasFilaHasta"
        Me.txtRangoCeldasFilaHasta.Size = New System.Drawing.Size(46, 20)
        Me.txtRangoCeldasFilaHasta.TabIndex = 7
        '
        'txtRangoCeldasColumnaDesde
        '
        Me.txtRangoCeldasColumnaDesde.BindearPropiedadControl = Nothing
        Me.txtRangoCeldasColumnaDesde.BindearPropiedadEntidad = Nothing
        Me.txtRangoCeldasColumnaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRangoCeldasColumnaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRangoCeldasColumnaDesde.Formato = ""
        Me.txtRangoCeldasColumnaDesde.IsDecimal = False
        Me.txtRangoCeldasColumnaDesde.IsNumber = False
        Me.txtRangoCeldasColumnaDesde.IsPK = False
        Me.txtRangoCeldasColumnaDesde.IsRequired = False
        Me.txtRangoCeldasColumnaDesde.Key = ""
        Me.txtRangoCeldasColumnaDesde.LabelAsoc = Nothing
        Me.txtRangoCeldasColumnaDesde.Location = New System.Drawing.Point(681, 19)
        Me.txtRangoCeldasColumnaDesde.Name = "txtRangoCeldasColumnaDesde"
        Me.txtRangoCeldasColumnaDesde.Size = New System.Drawing.Size(21, 20)
        Me.txtRangoCeldasColumnaDesde.TabIndex = 4
        Me.txtRangoCeldasColumnaDesde.TabStop = False
        Me.txtRangoCeldasColumnaDesde.Text = "A"
        Me.txtRangoCeldasColumnaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEjemplos
        '
        Me.lblEjemplos.AutoSize = True
        Me.lblEjemplos.LabelAsoc = Nothing
        Me.lblEjemplos.Location = New System.Drawing.Point(795, 23)
        Me.lblEjemplos.Name = "lblEjemplos"
        Me.lblEjemplos.Size = New System.Drawing.Size(67, 13)
        Me.lblEjemplos.TabIndex = 8
        Me.lblEjemplos.Text = "Ej:  A1:Q200"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(633, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Rango:"
        '
        'ImportarStockLotesExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.grpFiltros)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "ImportarStockLotesExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importación de Stock de Lotes desde Excel"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLeerExel As Eniac.Controles.Button
    Friend WithEvents txtArchivoOrigen As Eniac.Controles.TextBox
    Friend WithEvents lblArchivo As Eniac.Controles.Label
    Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnExaminar As Eniac.Controles.Button
   Private WithEvents ugDetalle As UltraGridSiga
   Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grpFiltros As GroupBox
    Friend WithEvents txtRangoCeldasFilaDesde As Controles.TextBox
    Friend WithEvents txtRangoCeldasColumnaHasta As Controles.TextBox
    Friend WithEvents txtRangoCeldasFilaHasta As Controles.TextBox
    Friend WithEvents txtRangoCeldasColumnaDesde As Controles.TextBox
    Friend WithEvents lblEjemplos As Controles.Label
    Friend WithEvents Label6 As Controles.Label
End Class