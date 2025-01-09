<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebitosAutTarjetasRecepcion
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DebitosAutTarjetasRecepcion))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGenerarPagos = New System.Windows.Forms.ToolStripButton()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ugDatos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.grbCabecera = New System.Windows.Forms.GroupBox()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.bscCuentaBancariaTransfBanc = New Eniac.Controles.Buscador()
      Me.lblCuentaBancaria = New Eniac.Controles.Label()
      Me.cmbTipo = New Eniac.Controles.ComboBox()
      Me.lblTarjeta = New Eniac.Controles.Label()
      Me.txtFechaRespuesta = New Eniac.Controles.TextBox()
      Me.lblImporte = New Eniac.Controles.Label()
      Me.txtImporte = New Eniac.Controles.TextBox()
      Me.lblFechaRespuesta = New Eniac.Controles.Label()
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.chbTomaFoto = New Eniac.Controles.CheckBox()
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      CType(Me.ugDatos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbCabecera.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImportar, Me.ToolStripSeparator1, Me.tsbGenerarPagos, Me.tsbImprimir, Me.tsddExportar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(974, 29)
      Me.tstBarra.TabIndex = 1
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbImportar
      '
      Me.tsbImportar.Image = CType(resources.GetObject("tsbImportar.Image"), System.Drawing.Image)
      Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImportar.Name = "tsbImportar"
      Me.tsbImportar.Size = New System.Drawing.Size(99, 26)
      Me.tsbImportar.Text = "&Leer Archivo"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGenerarPagos
      '
      Me.tsbGenerarPagos.Enabled = False
      Me.tsbGenerarPagos.Image = Global.Eniac.Win.My.Resources.Resources.cashier
      Me.tsbGenerarPagos.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGenerarPagos.Name = "tsbGenerarPagos"
      Me.tsbGenerarPagos.Size = New System.Drawing.Size(109, 26)
      Me.tsbGenerarPagos.Text = "Generar Pagos"
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
      Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
      Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsddExportar.Name = "tsddExportar"
      Me.tsddExportar.Size = New System.Drawing.Size(63, 26)
      Me.tsddExportar.Text = "Exportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAPDF.Text = "a PDF"
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
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 529)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(974, 22)
      Me.StatusStrip1.TabIndex = 6
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(959, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ugDatos
      '
      Me.ugDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDatos.DisplayLayout.Appearance = Appearance1
      Me.ugDatos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDatos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDatos.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDatos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugDatos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aquí para agrupar."
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDatos.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugDatos.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDatos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDatos.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDatos.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugDatos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDatos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugDatos.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDatos.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
      Me.ugDatos.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDatos.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugDatos.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDatos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugDatos.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDatos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDatos.Location = New System.Drawing.Point(0, 112)
      Me.ugDatos.Name = "ugDatos"
      Me.ugDatos.Size = New System.Drawing.Size(974, 417)
      Me.ugDatos.TabIndex = 8
      Me.ugDatos.Text = "UltraGrid1"
      '
      'grbCabecera
      '
      Me.grbCabecera.Controls.Add(Me.chbTomaFoto)
      Me.grbCabecera.Controls.Add(Me.dtpFecha)
      Me.grbCabecera.Controls.Add(Me.lblFecha)
      Me.grbCabecera.Controls.Add(Me.cmbCajas)
      Me.grbCabecera.Controls.Add(Me.lblCaja)
      Me.grbCabecera.Controls.Add(Me.bscCuentaBancariaTransfBanc)
      Me.grbCabecera.Controls.Add(Me.lblCuentaBancaria)
      Me.grbCabecera.Controls.Add(Me.cmbTipo)
      Me.grbCabecera.Controls.Add(Me.lblTarjeta)
      Me.grbCabecera.Controls.Add(Me.txtFechaRespuesta)
      Me.grbCabecera.Controls.Add(Me.lblImporte)
      Me.grbCabecera.Controls.Add(Me.txtImporte)
      Me.grbCabecera.Controls.Add(Me.lblFechaRespuesta)
      Me.grbCabecera.Location = New System.Drawing.Point(12, 32)
      Me.grbCabecera.Name = "grbCabecera"
      Me.grbCabecera.Size = New System.Drawing.Size(950, 74)
      Me.grbCabecera.TabIndex = 9
      Me.grbCabecera.TabStop = False
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = Nothing
      Me.dtpFecha.BindearPropiedadEntidad = Nothing
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(731, 26)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
      Me.dtpFecha.TabIndex = 32
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.Location = New System.Drawing.Point(739, 11)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 31
      Me.lblFecha.Text = "&Fecha"
      '
      'cmbCajas
      '
      Me.cmbCajas.BindearPropiedadControl = ""
      Me.cmbCajas.BindearPropiedadEntidad = ""
      Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCajas.FormattingEnabled = True
      Me.cmbCajas.IsPK = False
      Me.cmbCajas.IsRequired = False
      Me.cmbCajas.Key = Nothing
      Me.cmbCajas.LabelAsoc = Me.lblCaja
      Me.cmbCajas.Location = New System.Drawing.Point(570, 26)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(155, 21)
      Me.cmbCajas.TabIndex = 30
      '
      'lblCaja
      '
      Me.lblCaja.AutoSize = True
      Me.lblCaja.Location = New System.Drawing.Point(567, 11)
      Me.lblCaja.Name = "lblCaja"
      Me.lblCaja.Size = New System.Drawing.Size(157, 13)
      Me.lblCaja.TabIndex = 29
      Me.lblCaja.Text = "Caja (si categoría no tiene caja)"
      '
      'bscCuentaBancariaTransfBanc
      '
      Me.bscCuentaBancariaTransfBanc.AyudaAncho = 608
      Me.bscCuentaBancariaTransfBanc.BindearPropiedadControl = Nothing
      Me.bscCuentaBancariaTransfBanc.BindearPropiedadEntidad = Nothing
      Me.bscCuentaBancariaTransfBanc.ColumnasAlineacion = Nothing
      Me.bscCuentaBancariaTransfBanc.ColumnasAncho = Nothing
      Me.bscCuentaBancariaTransfBanc.ColumnasFormato = Nothing
      Me.bscCuentaBancariaTransfBanc.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
      Me.bscCuentaBancariaTransfBanc.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
      Me.bscCuentaBancariaTransfBanc.Datos = Nothing
      Me.bscCuentaBancariaTransfBanc.FilaDevuelta = Nothing
      Me.bscCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCuentaBancariaTransfBanc.IsDecimal = False
      Me.bscCuentaBancariaTransfBanc.IsNumber = False
      Me.bscCuentaBancariaTransfBanc.IsPK = False
      Me.bscCuentaBancariaTransfBanc.IsRequired = False
      Me.bscCuentaBancariaTransfBanc.Key = ""
      Me.bscCuentaBancariaTransfBanc.LabelAsoc = Me.lblCuentaBancaria
      Me.bscCuentaBancariaTransfBanc.Location = New System.Drawing.Point(360, 27)
      Me.bscCuentaBancariaTransfBanc.MaxLengh = "32767"
      Me.bscCuentaBancariaTransfBanc.Name = "bscCuentaBancariaTransfBanc"
      Me.bscCuentaBancariaTransfBanc.Permitido = True
      Me.bscCuentaBancariaTransfBanc.Selecciono = False
      Me.bscCuentaBancariaTransfBanc.Size = New System.Drawing.Size(200, 20)
      Me.bscCuentaBancariaTransfBanc.TabIndex = 28
      Me.bscCuentaBancariaTransfBanc.Titulo = "Clientes"
      '
      'lblCuentaBancaria
      '
      Me.lblCuentaBancaria.AutoSize = True
      Me.lblCuentaBancaria.Location = New System.Drawing.Point(359, 11)
      Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
      Me.lblCuentaBancaria.Size = New System.Drawing.Size(86, 13)
      Me.lblCuentaBancaria.TabIndex = 27
      Me.lblCuentaBancaria.Text = "Cuenta Bancaria"
      '
      'cmbTipo
      '
      Me.cmbTipo.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipo.BindearPropiedadEntidad = "Cobrador.idCobrador"
      Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipo.FormattingEnabled = True
      Me.cmbTipo.IsPK = False
      Me.cmbTipo.IsRequired = False
      Me.cmbTipo.Items.AddRange(New Object() {"VISA", "MASTER"})
      Me.cmbTipo.Key = Nothing
      Me.cmbTipo.LabelAsoc = Me.lblTarjeta
      Me.cmbTipo.Location = New System.Drawing.Point(9, 25)
      Me.cmbTipo.Name = "cmbTipo"
      Me.cmbTipo.Size = New System.Drawing.Size(112, 21)
      Me.cmbTipo.TabIndex = 12
      '
      'lblTarjeta
      '
      Me.lblTarjeta.AutoSize = True
      Me.lblTarjeta.Location = New System.Drawing.Point(6, 12)
      Me.lblTarjeta.Name = "lblTarjeta"
      Me.lblTarjeta.Size = New System.Drawing.Size(40, 13)
      Me.lblTarjeta.TabIndex = 11
      Me.lblTarjeta.Text = "Tarjeta"
      '
      'txtFechaRespuesta
      '
      Me.txtFechaRespuesta.BindearPropiedadControl = Nothing
      Me.txtFechaRespuesta.BindearPropiedadEntidad = Nothing
      Me.txtFechaRespuesta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtFechaRespuesta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtFechaRespuesta.Formato = ""
      Me.txtFechaRespuesta.IsDecimal = False
      Me.txtFechaRespuesta.IsNumber = False
      Me.txtFechaRespuesta.IsPK = False
      Me.txtFechaRespuesta.IsRequired = False
      Me.txtFechaRespuesta.Key = ""
      Me.txtFechaRespuesta.LabelAsoc = Nothing
      Me.txtFechaRespuesta.Location = New System.Drawing.Point(130, 26)
      Me.txtFechaRespuesta.Name = "txtFechaRespuesta"
      Me.txtFechaRespuesta.ReadOnly = True
      Me.txtFechaRespuesta.Size = New System.Drawing.Size(96, 20)
      Me.txtFechaRespuesta.TabIndex = 2
      Me.txtFechaRespuesta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblImporte
      '
      Me.lblImporte.AutoSize = True
      Me.lblImporte.Location = New System.Drawing.Point(243, 12)
      Me.lblImporte.Name = "lblImporte"
      Me.lblImporte.Size = New System.Drawing.Size(42, 13)
      Me.lblImporte.TabIndex = 7
      Me.lblImporte.Text = "Importe"
      '
      'txtImporte
      '
      Me.txtImporte.BindearPropiedadControl = Nothing
      Me.txtImporte.BindearPropiedadEntidad = Nothing
      Me.txtImporte.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporte.Formato = ""
      Me.txtImporte.IsDecimal = False
      Me.txtImporte.IsNumber = False
      Me.txtImporte.IsPK = False
      Me.txtImporte.IsRequired = False
      Me.txtImporte.Key = ""
      Me.txtImporte.LabelAsoc = Nothing
      Me.txtImporte.Location = New System.Drawing.Point(243, 26)
      Me.txtImporte.Name = "txtImporte"
      Me.txtImporte.ReadOnly = True
      Me.txtImporte.Size = New System.Drawing.Size(61, 20)
      Me.txtImporte.TabIndex = 6
      Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblFechaRespuesta
      '
      Me.lblFechaRespuesta.AutoSize = True
      Me.lblFechaRespuesta.Location = New System.Drawing.Point(127, 12)
      Me.lblFechaRespuesta.Name = "lblFechaRespuesta"
      Me.lblFechaRespuesta.Size = New System.Drawing.Size(110, 13)
      Me.lblFechaRespuesta.TabIndex = 3
      Me.lblFechaRespuesta.Text = "Fecha de Generación"
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDatos
      Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance13
      Me.UltraGridPrintDocument1.Header.BorderSides = System.Windows.Forms.Border3DSide.Bottom
      Me.UltraGridPrintDocument1.Header.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
      Me.UltraGridPrintDocument1.Header.TextCenter = ""
      Me.UltraGridPrintDocument1.Page.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
      Me.UltraGridPrintDocument1.Page.Margins.Bottom = 2
      Me.UltraGridPrintDocument1.Page.Margins.Left = 2
      Me.UltraGridPrintDocument1.Page.Margins.Right = 2
      Me.UltraGridPrintDocument1.Page.Margins.Top = 2
      Me.UltraGridPrintDocument1.PageBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
      Me.UltraGridPrintDocument1.PageBody.Margins.Bottom = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Left = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Right = 2
      Me.UltraGridPrintDocument1.PageBody.Margins.Top = 2
      '
      'chbTomaFoto
      '
      Me.chbTomaFoto.AutoSize = True
      Me.chbTomaFoto.BindearPropiedadControl = Nothing
      Me.chbTomaFoto.BindearPropiedadEntidad = Nothing
      Me.chbTomaFoto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTomaFoto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTomaFoto.IsPK = False
      Me.chbTomaFoto.IsRequired = False
      Me.chbTomaFoto.Key = Nothing
      Me.chbTomaFoto.LabelAsoc = Nothing
      Me.chbTomaFoto.Location = New System.Drawing.Point(9, 52)
      Me.chbTomaFoto.Name = "chbTomaFoto"
      Me.chbTomaFoto.Size = New System.Drawing.Size(121, 17)
      Me.chbTomaFoto.TabIndex = 33
      Me.chbTomaFoto.Text = "Tomar datos de foto"
      Me.chbTomaFoto.UseVisualStyleBackColor = True
      '
      'DebitosAutTarjetasRecepcion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(974, 551)
      Me.Controls.Add(Me.grbCabecera)
      Me.Controls.Add(Me.ugDatos)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "DebitosAutTarjetasRecepcion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Leer Archivo de Respuesta Tarjetas de Credito"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      CType(Me.ugDatos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbCabecera.ResumeLayout(False)
      Me.grbCabecera.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ugDatos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents grbCabecera As System.Windows.Forms.GroupBox
   Friend WithEvents lblFechaRespuesta As Eniac.Controles.Label
   Friend WithEvents txtFechaRespuesta As Eniac.Controles.TextBox
   Friend WithEvents lblImporte As Eniac.Controles.Label
   Friend WithEvents txtImporte As Eniac.Controles.TextBox
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbGenerarPagos As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbTipo As Eniac.Controles.ComboBox
   Friend WithEvents lblTarjeta As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents bscCuentaBancariaTransfBanc As Eniac.Controles.Buscador
   Friend WithEvents lblCuentaBancaria As Eniac.Controles.Label
   Friend WithEvents chbTomaFoto As Eniac.Controles.CheckBox
End Class
