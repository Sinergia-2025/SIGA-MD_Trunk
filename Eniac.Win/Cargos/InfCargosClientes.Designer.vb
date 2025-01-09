<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfCargosClientes
   'Inherits BaseForm
   Inherits Eniac.Win.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfCargosClientes))
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.chbCobrador = New Eniac.Controles.CheckBox()
      Me.cmbCobrador = New Eniac.Controles.ComboBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.cmbTiposLiquidacion = New Eniac.Controles.ComboBox()
      Me.bscCodigoCargo = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.chbZonaGeografica = New System.Windows.Forms.CheckBox()
      Me.bscNombreCargo = New Eniac.Controles.Buscador2()
      Me.chbCategoria = New Eniac.Controles.CheckBox()
      Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
      Me.cmbCategorias = New Eniac.Controles.ComboBox()
      Me.bscNombreCliente = New Eniac.Controles.Buscador2()
      Me.lblNombreCliente = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.chbCargo = New Eniac.Controles.CheckBox()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.lblTotal = New Eniac.Controles.Label()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.grbConsultar.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbConsultar
      '
      Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbConsultar.Controls.Add(Me.chbCobrador)
      Me.grbConsultar.Controls.Add(Me.cmbCobrador)
      Me.grbConsultar.Controls.Add(Me.Label2)
      Me.grbConsultar.Controls.Add(Me.cmbTiposLiquidacion)
      Me.grbConsultar.Controls.Add(Me.bscCodigoCargo)
      Me.grbConsultar.Controls.Add(Me.chbZonaGeografica)
      Me.grbConsultar.Controls.Add(Me.bscNombreCargo)
      Me.grbConsultar.Controls.Add(Me.chbCategoria)
      Me.grbConsultar.Controls.Add(Me.cmbZonaGeografica)
      Me.grbConsultar.Controls.Add(Me.cmbCategorias)
      Me.grbConsultar.Controls.Add(Me.bscNombreCliente)
      Me.grbConsultar.Controls.Add(Me.bscCodigoCliente)
      Me.grbConsultar.Controls.Add(Me.chbCargo)
      Me.grbConsultar.Controls.Add(Me.chbCliente)
      Me.grbConsultar.Controls.Add(Me.lblCodigoCliente)
      Me.grbConsultar.Controls.Add(Me.lblNombreCliente)
      Me.grbConsultar.Controls.Add(Me.chkExpandAll)
      Me.grbConsultar.Controls.Add(Me.btnConsultar)
      Me.grbConsultar.Location = New System.Drawing.Point(4, 32)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(974, 127)
      Me.grbConsultar.TabIndex = 1
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Filtros"
      '
      'chbCobrador
      '
      Me.chbCobrador.AutoSize = True
      Me.chbCobrador.BindearPropiedadControl = Nothing
      Me.chbCobrador.BindearPropiedadEntidad = Nothing
      Me.chbCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCobrador.IsPK = False
      Me.chbCobrador.IsRequired = False
      Me.chbCobrador.Key = Nothing
      Me.chbCobrador.LabelAsoc = Nothing
      Me.chbCobrador.Location = New System.Drawing.Point(526, 66)
      Me.chbCobrador.Name = "chbCobrador"
      Me.chbCobrador.Size = New System.Drawing.Size(69, 17)
      Me.chbCobrador.TabIndex = 56
      Me.chbCobrador.Text = "Cobrador"
      Me.chbCobrador.UseVisualStyleBackColor = True
      '
      'cmbCobrador
      '
      Me.cmbCobrador.BindearPropiedadControl = Nothing
      Me.cmbCobrador.BindearPropiedadEntidad = Nothing
      Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCobrador.Enabled = False
      Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCobrador.FormattingEnabled = True
      Me.cmbCobrador.IsPK = False
      Me.cmbCobrador.IsRequired = False
      Me.cmbCobrador.Key = Nothing
      Me.cmbCobrador.LabelAsoc = Nothing
      Me.cmbCobrador.Location = New System.Drawing.Point(638, 64)
      Me.cmbCobrador.Name = "cmbCobrador"
      Me.cmbCobrador.Size = New System.Drawing.Size(180, 21)
      Me.cmbCobrador.TabIndex = 57
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(5, 23)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(85, 13)
      Me.Label2.TabIndex = 55
      Me.Label2.Text = "Tipo Liquidacion"
      '
      'cmbTiposLiquidacion
      '
      Me.cmbTiposLiquidacion.BindearPropiedadControl = ""
      Me.cmbTiposLiquidacion.BindearPropiedadEntidad = ""
      Me.cmbTiposLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposLiquidacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposLiquidacion.FormattingEnabled = True
      Me.cmbTiposLiquidacion.IsPK = False
      Me.cmbTiposLiquidacion.IsRequired = True
      Me.cmbTiposLiquidacion.Key = Nothing
      Me.cmbTiposLiquidacion.LabelAsoc = Nothing
      Me.cmbTiposLiquidacion.Location = New System.Drawing.Point(96, 19)
      Me.cmbTiposLiquidacion.Name = "cmbTiposLiquidacion"
      Me.cmbTiposLiquidacion.Size = New System.Drawing.Size(120, 21)
      Me.cmbTiposLiquidacion.TabIndex = 54
      '
      'bscCodigoCargo
      '
      Me.bscCodigoCargo.ActivarFiltroEnGrilla = True
      Me.bscCodigoCargo.BindearPropiedadControl = Nothing
      Me.bscCodigoCargo.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCargo.ConfigBuscador = Nothing
      Me.bscCodigoCargo.Datos = Nothing
      Me.bscCodigoCargo.Enabled = False
      Me.bscCodigoCargo.FilaDevuelta = Nothing
      Me.bscCodigoCargo.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCargo.IsDecimal = False
      Me.bscCodigoCargo.IsNumber = False
      Me.bscCodigoCargo.IsPK = False
      Me.bscCodigoCargo.IsRequired = False
      Me.bscCodigoCargo.Key = ""
      Me.bscCodigoCargo.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCargo.Location = New System.Drawing.Point(95, 90)
      Me.bscCodigoCargo.MaxLengh = "32767"
      Me.bscCodigoCargo.Name = "bscCodigoCargo"
      Me.bscCodigoCargo.Permitido = True
      Me.bscCodigoCargo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCargo.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCargo.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCargo.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCargo.Selecciono = False
      Me.bscCodigoCargo.Size = New System.Drawing.Size(133, 20)
      Me.bscCodigoCargo.TabIndex = 14
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(95, 46)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 13
      Me.lblCodigoCliente.Text = "Codigo"
      '
      'chbZonaGeografica
      '
      Me.chbZonaGeografica.AutoSize = True
      Me.chbZonaGeografica.Location = New System.Drawing.Point(526, 21)
      Me.chbZonaGeografica.Name = "chbZonaGeografica"
      Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
      Me.chbZonaGeografica.TabIndex = 15
      Me.chbZonaGeografica.Text = "Zona Geográfica"
      Me.chbZonaGeografica.UseVisualStyleBackColor = True
      '
      'bscNombreCargo
      '
      Me.bscNombreCargo.ActivarFiltroEnGrilla = True
      Me.bscNombreCargo.AutoSize = True
      Me.bscNombreCargo.BindearPropiedadControl = Nothing
      Me.bscNombreCargo.BindearPropiedadEntidad = Nothing
      Me.bscNombreCargo.ConfigBuscador = Nothing
      Me.bscNombreCargo.Datos = Nothing
      Me.bscNombreCargo.Enabled = False
      Me.bscNombreCargo.FilaDevuelta = Nothing
      Me.bscNombreCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreCargo.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreCargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreCargo.IsDecimal = False
      Me.bscNombreCargo.IsNumber = False
      Me.bscNombreCargo.IsPK = False
      Me.bscNombreCargo.IsRequired = False
      Me.bscNombreCargo.Key = ""
      Me.bscNombreCargo.LabelAsoc = Nothing
      Me.bscNombreCargo.Location = New System.Drawing.Point(233, 90)
      Me.bscNombreCargo.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreCargo.MaxLengh = "32767"
      Me.bscNombreCargo.Name = "bscNombreCargo"
      Me.bscNombreCargo.Permitido = True
      Me.bscNombreCargo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNombreCargo.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNombreCargo.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNombreCargo.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNombreCargo.Selecciono = False
      Me.bscNombreCargo.Size = New System.Drawing.Size(273, 23)
      Me.bscNombreCargo.TabIndex = 15
      '
      'chbCategoria
      '
      Me.chbCategoria.AutoSize = True
      Me.chbCategoria.BindearPropiedadControl = Nothing
      Me.chbCategoria.BindearPropiedadEntidad = Nothing
      Me.chbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCategoria.IsPK = False
      Me.chbCategoria.IsRequired = False
      Me.chbCategoria.Key = Nothing
      Me.chbCategoria.LabelAsoc = Nothing
      Me.chbCategoria.Location = New System.Drawing.Point(234, 21)
      Me.chbCategoria.Name = "chbCategoria"
      Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
      Me.chbCategoria.TabIndex = 8
      Me.chbCategoria.Text = "Categoria"
      Me.chbCategoria.UseVisualStyleBackColor = True
      '
      'cmbZonaGeografica
      '
      Me.cmbZonaGeografica.BindearPropiedadControl = ""
      Me.cmbZonaGeografica.BindearPropiedadEntidad = ""
      Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbZonaGeografica.Enabled = False
      Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbZonaGeografica.FormattingEnabled = True
      Me.cmbZonaGeografica.IsPK = False
      Me.cmbZonaGeografica.IsRequired = True
      Me.cmbZonaGeografica.Key = Nothing
      Me.cmbZonaGeografica.LabelAsoc = Nothing
      Me.cmbZonaGeografica.Location = New System.Drawing.Point(638, 19)
      Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
      Me.cmbZonaGeografica.Size = New System.Drawing.Size(180, 21)
      Me.cmbZonaGeografica.TabIndex = 9
      '
      'cmbCategorias
      '
      Me.cmbCategorias.BindearPropiedadControl = ""
      Me.cmbCategorias.BindearPropiedadEntidad = ""
      Me.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategorias.Enabled = False
      Me.cmbCategorias.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategorias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategorias.FormattingEnabled = True
      Me.cmbCategorias.IsPK = False
      Me.cmbCategorias.IsRequired = True
      Me.cmbCategorias.Key = Nothing
      Me.cmbCategorias.LabelAsoc = Nothing
      Me.cmbCategorias.Location = New System.Drawing.Point(311, 19)
      Me.cmbCategorias.Name = "cmbCategorias"
      Me.cmbCategorias.Size = New System.Drawing.Size(180, 21)
      Me.cmbCategorias.TabIndex = 9
      '
      'bscNombreCliente
      '
      Me.bscNombreCliente.ActivarFiltroEnGrilla = True
      Me.bscNombreCliente.BindearPropiedadControl = Nothing
      Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
      Me.bscNombreCliente.ConfigBuscador = Nothing
      Me.bscNombreCliente.Datos = Nothing
      Me.bscNombreCliente.Enabled = False
      Me.bscNombreCliente.FilaDevuelta = Nothing
      Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreCliente.IsDecimal = False
      Me.bscNombreCliente.IsNumber = False
      Me.bscNombreCliente.IsPK = False
      Me.bscNombreCliente.IsRequired = False
      Me.bscNombreCliente.Key = ""
      Me.bscNombreCliente.LabelAsoc = Me.lblNombreCliente
      Me.bscNombreCliente.Location = New System.Drawing.Point(234, 63)
      Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.bscNombreCliente.MaxLengh = "32767"
      Me.bscNombreCliente.Name = "bscNombreCliente"
      Me.bscNombreCliente.Permitido = True
      Me.bscNombreCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNombreCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNombreCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNombreCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNombreCliente.Selecciono = False
      Me.bscNombreCliente.Size = New System.Drawing.Size(272, 23)
      Me.bscNombreCliente.TabIndex = 2
      '
      'lblNombreCliente
      '
      Me.lblNombreCliente.AutoSize = True
      Me.lblNombreCliente.LabelAsoc = Nothing
      Me.lblNombreCliente.Location = New System.Drawing.Point(234, 46)
      Me.lblNombreCliente.Name = "lblNombreCliente"
      Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreCliente.TabIndex = 14
      Me.lblNombreCliente.Text = "Nombre"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ConfigBuscador = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.Enabled = False
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(95, 63)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(133, 23)
      Me.bscCodigoCliente.TabIndex = 1
      '
      'chbCargo
      '
      Me.chbCargo.AutoSize = True
      Me.chbCargo.BindearPropiedadControl = Nothing
      Me.chbCargo.BindearPropiedadEntidad = Nothing
      Me.chbCargo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCargo.IsPK = False
      Me.chbCargo.IsRequired = False
      Me.chbCargo.Key = Nothing
      Me.chbCargo.LabelAsoc = Nothing
      Me.chbCargo.Location = New System.Drawing.Point(20, 93)
      Me.chbCargo.Name = "chbCargo"
      Me.chbCargo.Size = New System.Drawing.Size(54, 17)
      Me.chbCargo.TabIndex = 5
      Me.chbCargo.Text = "Cargo"
      Me.chbCargo.UseVisualStyleBackColor = True
      '
      'chbCliente
      '
      Me.chbCliente.AutoSize = True
      Me.chbCliente.BindearPropiedadControl = Nothing
      Me.chbCliente.BindearPropiedadEntidad = Nothing
      Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCliente.IsPK = False
      Me.chbCliente.IsRequired = False
      Me.chbCliente.Key = Nothing
      Me.chbCliente.LabelAsoc = Nothing
      Me.chbCliente.Location = New System.Drawing.Point(20, 66)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 0
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(848, 95)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 19)
      Me.chkExpandAll.TabIndex = 12
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(848, 46)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 11
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 0
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
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbPreferencias
      '
      Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
      Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbPreferencias.Name = "tsbPreferencias"
      Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
      Me.tsbPreferencias.Text = "&Preferencias"
      Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
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
      'lblTotal
      '
      Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotal.AutoSize = True
      Me.lblTotal.LabelAsoc = Nothing
      Me.lblTotal.Location = New System.Drawing.Point(849, 496)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(34, 13)
      Me.lblTotal.TabIndex = 4
      Me.lblTotal.Text = "Total:"
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance7.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance7
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
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un titulo de columna aquí para agrupar."
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
      Appearance1.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance1
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Appearance2.ForeColor = System.Drawing.Color.Gray
      Me.ugDetalle.DisplayLayout.Override.FixedHeaderAppearance = Appearance2
      Appearance3.ForeColor = System.Drawing.Color.ForestGreen
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance3
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Appearance4.ForeColor = System.Drawing.Color.Gray
      Me.ugDetalle.DisplayLayout.Override.HotTrackHeaderAppearance = Appearance4
      Appearance5.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance5
      Appearance6.ForeColor = System.Drawing.Color.Gray
      Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance6
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(4, 179)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(974, 316)
      Me.ugDetalle.TabIndex = 2
      Me.ugDetalle.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 498)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(984, 22)
      Me.stsStado.TabIndex = 3
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
      'InfCargosClientes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 520)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.lblTotal)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbConsultar)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "InfCargosClientes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Cargos de Clientes"
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents lblTotal As Eniac.Controles.Label
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents bscNombreCliente As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategorias As Eniac.Controles.ComboBox
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbCargo As Eniac.Controles.CheckBox
   Friend WithEvents chbZonaGeografica As System.Windows.Forms.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoCargo As Eniac.Controles.Buscador2
   Friend WithEvents bscNombreCargo As Eniac.Controles.Buscador2
   Friend WithEvents cmbTiposLiquidacion As Eniac.Controles.ComboBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents chbCobrador As Eniac.Controles.CheckBox
   Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
End Class
