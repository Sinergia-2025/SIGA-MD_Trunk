<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportacionDeCompras
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selec")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoComprobante")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocProveedor")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuitProveedor")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DireccionProveedor")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidadProveedor")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPProvincia")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BaseImponible")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImpuestosInternos")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalPercepciones")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAFIPTipoDocumento")
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tbcExportacion = New System.Windows.Forms.TabControl()
      Me.tbpComprobantes = New System.Windows.Forms.TabPage()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.txtArchivoDestino = New Eniac.Controles.TextBox()
      Me.lblArchivoDestino = New Eniac.Controles.Label()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
      Me.lblTiposComprobantes = New Eniac.Controles.Label()
      Me.lblSucursal = New Eniac.Controles.Label()
      Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.cmbTiposExportacion = New Eniac.Controles.ComboBox()
      Me.lblFormato = New Eniac.Controles.Label()
      Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
      Me.Label4 = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbExportarCompras = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tbcExportacion.SuspendLayout()
      Me.tbpComprobantes.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbFiltros.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'tbcExportacion
      '
      Me.tbcExportacion.Controls.Add(Me.tbpComprobantes)
      Me.tbcExportacion.Location = New System.Drawing.Point(12, 174)
      Me.tbcExportacion.Name = "tbcExportacion"
      Me.tbcExportacion.SelectedIndex = 0
      Me.tbcExportacion.Size = New System.Drawing.Size(960, 362)
      Me.tbcExportacion.TabIndex = 10
      '
      'tbpComprobantes
      '
      Me.tbpComprobantes.BackColor = System.Drawing.SystemColors.Control
      Me.tbpComprobantes.Controls.Add(Me.ugDetalle)
      Me.tbpComprobantes.Controls.Add(Me.btnExaminar)
      Me.tbpComprobantes.Controls.Add(Me.txtArchivoDestino)
      Me.tbpComprobantes.Controls.Add(Me.lblArchivoDestino)
      Me.tbpComprobantes.Location = New System.Drawing.Point(4, 22)
      Me.tbpComprobantes.Name = "tbpComprobantes"
      Me.tbpComprobantes.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpComprobantes.Size = New System.Drawing.Size(952, 336)
      Me.tbpComprobantes.TabIndex = 0
      Me.tbpComprobantes.Text = "Comprobantes"
      '
      'ugDetalle
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Header.Caption = "S."
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Width = 25
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance3
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Hidden = True
      Appearance4.TextHAlignAsString = "Center"
      UltraGridColumn3.CellAppearance = Appearance4
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 81
      UltraGridColumn26.Header.VisiblePosition = 3
      UltraGridColumn26.Hidden = True
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance5
      UltraGridColumn4.Header.VisiblePosition = 4
      UltraGridColumn4.Hidden = True
      UltraGridColumn5.Header.Caption = "Comprobante"
      UltraGridColumn5.Header.VisiblePosition = 5
      UltraGridColumn5.Width = 119
      Appearance6.TextHAlignAsString = "Center"
      UltraGridColumn6.CellAppearance = Appearance6
      UltraGridColumn6.Header.VisiblePosition = 6
      UltraGridColumn6.Width = 41
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance7
      UltraGridColumn7.Header.Caption = "Emisor"
      UltraGridColumn7.Header.VisiblePosition = 7
      UltraGridColumn7.Width = 55
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance8
      UltraGridColumn8.Header.Caption = "Nro. Comprobante"
      UltraGridColumn8.Header.VisiblePosition = 8
      UltraGridColumn8.Width = 85
      Appearance9.TextHAlignAsString = "Right"
      UltraGridColumn9.CellAppearance = Appearance9
      UltraGridColumn9.Header.VisiblePosition = 9
      UltraGridColumn9.Hidden = True
      UltraGridColumn10.Header.Caption = "Proveedor"
      UltraGridColumn10.Header.VisiblePosition = 10
      UltraGridColumn10.Width = 166
      UltraGridColumn11.Header.Caption = "Tipo Doc."
      UltraGridColumn11.Header.VisiblePosition = 11
      UltraGridColumn11.Hidden = True
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn12.CellAppearance = Appearance10
      UltraGridColumn12.Header.Caption = "CUIT"
      UltraGridColumn12.Header.VisiblePosition = 12
      UltraGridColumn12.Width = 97
      UltraGridColumn13.Header.Caption = "Dirección"
      UltraGridColumn13.Header.VisiblePosition = 13
      UltraGridColumn13.Width = 164
      Appearance11.TextHAlignAsString = "Right"
      UltraGridColumn14.CellAppearance = Appearance11
      UltraGridColumn14.Header.VisiblePosition = 14
      UltraGridColumn14.Hidden = True
      UltraGridColumn15.Header.Caption = "Localidad"
      UltraGridColumn15.Header.VisiblePosition = 15
      UltraGridColumn15.Width = 105
      Appearance12.TextHAlignAsString = "Right"
      UltraGridColumn16.CellAppearance = Appearance12
      UltraGridColumn16.Header.VisiblePosition = 16
      UltraGridColumn16.Hidden = True
      Appearance13.TextHAlignAsString = "Right"
      UltraGridColumn17.CellAppearance = Appearance13
      UltraGridColumn17.Header.VisiblePosition = 17
      UltraGridColumn17.Hidden = True
      UltraGridColumn18.Header.Caption = "Categoría Fiscal"
      UltraGridColumn18.Header.VisiblePosition = 18
      UltraGridColumn18.Width = 145
      Appearance14.TextHAlignAsString = "Right"
      UltraGridColumn28.CellAppearance = Appearance14
      UltraGridColumn28.Format = "N2"
      UltraGridColumn28.Header.Caption = "Neto"
      UltraGridColumn28.Header.VisiblePosition = 19
      Appearance15.TextHAlignAsString = "Right"
      UltraGridColumn22.CellAppearance = Appearance15
      UltraGridColumn22.Format = "N2"
      UltraGridColumn22.Header.VisiblePosition = 23
      UltraGridColumn22.Hidden = True
      UltraGridColumn22.Width = 65
      Appearance16.TextHAlignAsString = "Right"
      UltraGridColumn21.CellAppearance = Appearance16
      UltraGridColumn21.Format = "N2"
      UltraGridColumn21.Header.Caption = "Alícuota"
      UltraGridColumn21.Header.VisiblePosition = 20
      UltraGridColumn21.Width = 67
      Appearance17.TextHAlignAsString = "Right"
      UltraGridColumn23.CellAppearance = Appearance17
      UltraGridColumn23.Format = "N2"
      UltraGridColumn23.Header.Caption = "Imp. Internos"
      UltraGridColumn23.Header.VisiblePosition = 21
      UltraGridColumn23.Width = 74
      Appearance18.TextHAlignAsString = "Right"
      UltraGridColumn24.CellAppearance = Appearance18
      UltraGridColumn24.Format = "N2"
      UltraGridColumn24.Header.Caption = "Total Percepciones"
      UltraGridColumn24.Header.VisiblePosition = 22
      UltraGridColumn24.Width = 81
      Appearance19.TextHAlignAsString = "Right"
      UltraGridColumn25.CellAppearance = Appearance19
      UltraGridColumn25.Format = "N2"
      UltraGridColumn25.Header.VisiblePosition = 24
      UltraGridColumn27.Header.VisiblePosition = 25
      UltraGridColumn27.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn26, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn28, UltraGridColumn22, UltraGridColumn21, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn27})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance20.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance20.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance20
      Appearance21.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance21
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre las columnas aquí para agrupar."
      Appearance22.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance22.BackColor2 = System.Drawing.SystemColors.Control
      Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance22.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance22
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance23.BackColor = System.Drawing.SystemColors.Window
      Appearance23.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance23
      Appearance24.BackColor = System.Drawing.SystemColors.Highlight
      Appearance24.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance24
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance25.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance25
      Appearance26.BorderColor = System.Drawing.Color.Silver
      Appearance26.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance26
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance27.BackColor = System.Drawing.SystemColors.Control
      Appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance27.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance27.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance27
      Appearance28.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance28
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance29.BackColor = System.Drawing.SystemColors.Window
      Appearance29.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance29
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance30.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance30
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Top
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(3, 3)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(946, 283)
      Me.ugDetalle.TabIndex = 2
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'btnExaminar
      '
      Me.btnExaminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar.Location = New System.Drawing.Point(736, 292)
      Me.btnExaminar.Name = "btnExaminar"
      Me.btnExaminar.Size = New System.Drawing.Size(98, 40)
      Me.btnExaminar.TabIndex = 8
      Me.btnExaminar.Text = "&Examinar..."
      Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar.UseVisualStyleBackColor = True
      '
      'txtArchivoDestino
      '
      Me.txtArchivoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtArchivoDestino.BindearPropiedadControl = ""
      Me.txtArchivoDestino.BindearPropiedadEntidad = ""
      Me.txtArchivoDestino.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoDestino.Formato = ""
      Me.txtArchivoDestino.IsDecimal = False
      Me.txtArchivoDestino.IsNumber = False
      Me.txtArchivoDestino.IsPK = False
      Me.txtArchivoDestino.IsRequired = False
      Me.txtArchivoDestino.Key = ""
      Me.txtArchivoDestino.LabelAsoc = Me.lblArchivoDestino
      Me.txtArchivoDestino.Location = New System.Drawing.Point(96, 303)
      Me.txtArchivoDestino.Name = "txtArchivoDestino"
      Me.txtArchivoDestino.Size = New System.Drawing.Size(621, 20)
      Me.txtArchivoDestino.TabIndex = 7
      '
      'lblArchivoDestino
      '
      Me.lblArchivoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblArchivoDestino.AutoSize = True
      Me.lblArchivoDestino.LabelAsoc = Nothing
      Me.lblArchivoDestino.Location = New System.Drawing.Point(5, 306)
      Me.lblArchivoDestino.Name = "lblArchivoDestino"
      Me.lblArchivoDestino.Size = New System.Drawing.Size(85, 13)
      Me.lblArchivoDestino.TabIndex = 6
      Me.lblArchivoDestino.Text = "Archivo Destino:"
      '
      'chbTodos
      '
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.Checked = True
      Me.chbTodos.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(16, 150)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(124, 22)
      Me.chbTodos.TabIndex = 1
      Me.chbTodos.Text = "Chequear todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.lblTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.lblSucursal)
      Me.grbFiltros.Controls.Add(Me.cmbSucursal)
      Me.grbFiltros.Controls.Add(Me.bscProveedor)
      Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.chbProveedor)
      Me.grbFiltros.Controls.Add(Me.cmbTiposExportacion)
      Me.grbFiltros.Controls.Add(Me.lblFormato)
      Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
      Me.grbFiltros.Controls.Add(Me.Label4)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 32)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(960, 112)
      Me.grbFiltros.TabIndex = 7
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'cmbTiposComprobantes
      '
      Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
      Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
      Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantes.FormattingEnabled = True
      Me.cmbTiposComprobantes.IsPK = False
      Me.cmbTiposComprobantes.IsRequired = False
      Me.cmbTiposComprobantes.ItemHeight = 13
      Me.cmbTiposComprobantes.Key = Nothing
      Me.cmbTiposComprobantes.LabelAsoc = Me.lblTiposComprobantes
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(647, 20)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(156, 21)
      Me.cmbTiposComprobantes.TabIndex = 53
      '
      'lblTiposComprobantes
      '
      Me.lblTiposComprobantes.AutoSize = True
      Me.lblTiposComprobantes.LabelAsoc = Nothing
      Me.lblTiposComprobantes.Location = New System.Drawing.Point(546, 22)
      Me.lblTiposComprobantes.Name = "lblTiposComprobantes"
      Me.lblTiposComprobantes.Size = New System.Drawing.Size(94, 13)
      Me.lblTiposComprobantes.TabIndex = 52
      Me.lblTiposComprobantes.Text = "Tipo Comprobante"
      '
      'lblSucursal
      '
      Me.lblSucursal.AutoSize = True
      Me.lblSucursal.LabelAsoc = Nothing
      Me.lblSucursal.Location = New System.Drawing.Point(310, 23)
      Me.lblSucursal.Name = "lblSucursal"
      Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
      Me.lblSucursal.TabIndex = 50
      Me.lblSucursal.Text = "Sucursal"
      '
      'cmbSucursal
      '
      Me.cmbSucursal.BindearPropiedadControl = Nothing
      Me.cmbSucursal.BindearPropiedadEntidad = Nothing
      Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSucursal.FormattingEnabled = True
      Me.cmbSucursal.IsPK = False
      Me.cmbSucursal.IsRequired = False
      Me.cmbSucursal.ItemHeight = 13
      Me.cmbSucursal.Key = Nothing
      Me.cmbSucursal.LabelAsoc = Me.lblSucursal
      Me.cmbSucursal.Location = New System.Drawing.Point(364, 17)
      Me.cmbSucursal.Name = "cmbSucursal"
      Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
      Me.cmbSucursal.TabIndex = 51
      '
      'bscProveedor
      '
      Me.bscProveedor.AutoSize = True
      Me.bscProveedor.AyudaAncho = 608
      Me.bscProveedor.BindearPropiedadControl = Nothing
      Me.bscProveedor.BindearPropiedadEntidad = Nothing
      Me.bscProveedor.ColumnasAlineacion = Nothing
      Me.bscProveedor.ColumnasAncho = Nothing
      Me.bscProveedor.ColumnasFormato = Nothing
      Me.bscProveedor.ColumnasOcultas = Nothing
      Me.bscProveedor.ColumnasTitulos = Nothing
      Me.bscProveedor.Datos = Nothing
      Me.bscProveedor.Enabled = False
      Me.bscProveedor.FilaDevuelta = Nothing
      Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProveedor.IsDecimal = False
      Me.bscProveedor.IsNumber = False
      Me.bscProveedor.IsPK = False
      Me.bscProveedor.IsRequired = False
      Me.bscProveedor.Key = ""
      Me.bscProveedor.LabelAsoc = Nothing
      Me.bscProveedor.Location = New System.Drawing.Point(185, 76)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(328, 23)
      Me.bscProveedor.TabIndex = 20
      Me.bscProveedor.Titulo = Nothing
      '
      'bscCodigoProveedor
      '
      Me.bscCodigoProveedor.AyudaAncho = 608
      Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
      Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
      Me.bscCodigoProveedor.ColumnasAncho = Nothing
      Me.bscCodigoProveedor.ColumnasFormato = Nothing
      Me.bscCodigoProveedor.ColumnasOcultas = Nothing
      Me.bscCodigoProveedor.ColumnasTitulos = Nothing
      Me.bscCodigoProveedor.Datos = Nothing
      Me.bscCodigoProveedor.Enabled = False
      Me.bscCodigoProveedor.FilaDevuelta = Nothing
      Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProveedor.IsDecimal = False
      Me.bscCodigoProveedor.IsNumber = False
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Nothing
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(88, 76)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProveedor.TabIndex = 19
      Me.bscCodigoProveedor.Titulo = Nothing
      '
      'chbProveedor
      '
      Me.chbProveedor.AutoSize = True
      Me.chbProveedor.BindearPropiedadControl = Nothing
      Me.chbProveedor.BindearPropiedadEntidad = Nothing
      Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProveedor.IsPK = False
      Me.chbProveedor.IsRequired = False
      Me.chbProveedor.Key = Nothing
      Me.chbProveedor.LabelAsoc = Nothing
      Me.chbProveedor.Location = New System.Drawing.Point(17, 79)
      Me.chbProveedor.Name = "chbProveedor"
      Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
      Me.chbProveedor.TabIndex = 18
      Me.chbProveedor.Text = "Pro&veedor"
      Me.chbProveedor.UseVisualStyleBackColor = True
      '
      'cmbTiposExportacion
      '
      Me.cmbTiposExportacion.BindearPropiedadControl = Nothing
      Me.cmbTiposExportacion.BindearPropiedadEntidad = Nothing
      Me.cmbTiposExportacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposExportacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTiposExportacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposExportacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposExportacion.FormattingEnabled = True
      Me.cmbTiposExportacion.IsPK = False
      Me.cmbTiposExportacion.IsRequired = False
      Me.cmbTiposExportacion.Key = Nothing
      Me.cmbTiposExportacion.LabelAsoc = Nothing
      Me.cmbTiposExportacion.Location = New System.Drawing.Point(139, 17)
      Me.cmbTiposExportacion.Name = "cmbTiposExportacion"
      Me.cmbTiposExportacion.Size = New System.Drawing.Size(153, 21)
      Me.cmbTiposExportacion.TabIndex = 21
      Me.cmbTiposExportacion.TabStop = False
      '
      'lblFormato
      '
      Me.lblFormato.AutoSize = True
      Me.lblFormato.LabelAsoc = Nothing
      Me.lblFormato.Location = New System.Drawing.Point(14, 20)
      Me.lblFormato.Name = "lblFormato"
      Me.lblFormato.Size = New System.Drawing.Size(119, 13)
      Me.lblFormato.TabIndex = 18
      Me.lblFormato.Text = "Formato de Exportación"
      '
      'cmbGrabanLibro
      '
      Me.cmbGrabanLibro.BindearPropiedadControl = Nothing
      Me.cmbGrabanLibro.BindearPropiedadEntidad = Nothing
      Me.cmbGrabanLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGrabanLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbGrabanLibro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbGrabanLibro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbGrabanLibro.FormattingEnabled = True
      Me.cmbGrabanLibro.IsPK = False
      Me.cmbGrabanLibro.IsRequired = False
      Me.cmbGrabanLibro.Key = Nothing
      Me.cmbGrabanLibro.LabelAsoc = Nothing
      Me.cmbGrabanLibro.Location = New System.Drawing.Point(647, 74)
      Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
      Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
      Me.cmbGrabanLibro.TabIndex = 15
      Me.cmbGrabanLibro.TabStop = False
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.LabelAsoc = Nothing
      Me.Label4.Location = New System.Drawing.Point(578, 80)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(68, 13)
      Me.Label4.TabIndex = 14
      Me.Label4.Text = "Graban Libro"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(840, 58)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 20
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'chbMesCompleto
      '
      Me.chbMesCompleto.AutoSize = True
      Me.chbMesCompleto.BindearPropiedadControl = Nothing
      Me.chbMesCompleto.BindearPropiedadEntidad = Nothing
      Me.chbMesCompleto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMesCompleto.IsPK = False
      Me.chbMesCompleto.IsRequired = False
      Me.chbMesCompleto.Key = Nothing
      Me.chbMesCompleto.LabelAsoc = Nothing
      Me.chbMesCompleto.Location = New System.Drawing.Point(17, 50)
      Me.chbMesCompleto.Name = "chbMesCompleto"
      Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chbMesCompleto.TabIndex = 0
      Me.chbMesCompleto.Text = "Mes Completo"
      Me.chbMesCompleto.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(339, 48)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(298, 51)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(156, 48)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(116, 51)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(984, 22)
      Me.stsStado.TabIndex = 6
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(905, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbExportarCompras, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 5
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
      'tsbExportarCompras
      '
      Me.tsbExportarCompras.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
      Me.tsbExportarCompras.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbExportarCompras.Name = "tsbExportarCompras"
      Me.tsbExportarCompras.Size = New System.Drawing.Size(77, 26)
      Me.tsbExportarCompras.Text = "&Exportar"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
      'ExportacionDeCompras
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 561)
      Me.Controls.Add(Me.tbcExportacion)
      Me.Controls.Add(Me.chbTodos)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "ExportacionDeCompras"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Exportacion de Compras"
      Me.tbcExportacion.ResumeLayout(False)
      Me.tbpComprobantes.ResumeLayout(False)
      Me.tbpComprobantes.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbExportarCompras As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents lblTiposComprobantes As Eniac.Controles.Label
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbTiposExportacion As Eniac.Controles.ComboBox
   Friend WithEvents lblFormato As Eniac.Controles.Label
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents tbcExportacion As System.Windows.Forms.TabControl
   Friend WithEvents tbpComprobantes As System.Windows.Forms.TabPage
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnExaminar As Eniac.Controles.Button
   Friend WithEvents txtArchivoDestino As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestino As Eniac.Controles.Label
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
End Class
