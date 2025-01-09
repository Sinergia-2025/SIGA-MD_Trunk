<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaldosCtaCteProveedores
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaldosCtaCteProveedores))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TelefonoProveedor")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoVencido")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubroCompra")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbRubroCompra = New Eniac.Controles.CheckBox()
      Me.cmbRubroCompra = New Eniac.Controles.ComboBox()
      Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
      Me.lblGrabanLibro = New Eniac.Controles.Label()
      Me.chbCategoria = New Eniac.Controles.CheckBox()
      Me.cmbCategoria = New Eniac.Controles.ComboBox()
      Me.chbSaldosPositivos = New Eniac.Controles.CheckBox()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.grbFiltros.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.chbRubroCompra)
      Me.grbFiltros.Controls.Add(Me.cmbRubroCompra)
      Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
      Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
      Me.grbFiltros.Controls.Add(Me.chbCategoria)
      Me.grbFiltros.Controls.Add(Me.cmbCategoria)
      Me.grbFiltros.Controls.Add(Me.chbSaldosPositivos)
      Me.grbFiltros.Controls.Add(Me.chbProveedor)
      Me.grbFiltros.Controls.Add(Me.bscCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.bscProveedor)
      Me.grbFiltros.Controls.Add(Me.lblCodigoProveedor)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbFecha)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 31)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(666, 141)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'chbRubroCompra
      '
      Me.chbRubroCompra.AutoSize = True
      Me.chbRubroCompra.BindearPropiedadControl = Nothing
      Me.chbRubroCompra.BindearPropiedadEntidad = Nothing
      Me.chbRubroCompra.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRubroCompra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRubroCompra.IsPK = False
      Me.chbRubroCompra.IsRequired = False
      Me.chbRubroCompra.Key = Nothing
      Me.chbRubroCompra.LabelAsoc = Nothing
      Me.chbRubroCompra.Location = New System.Drawing.Point(283, 89)
      Me.chbRubroCompra.Name = "chbRubroCompra"
      Me.chbRubroCompra.Size = New System.Drawing.Size(55, 17)
      Me.chbRubroCompra.TabIndex = 11
      Me.chbRubroCompra.Text = "Rubro"
      Me.chbRubroCompra.UseVisualStyleBackColor = True
      '
      'cmbRubroCompra
      '
      Me.cmbRubroCompra.BindearPropiedadControl = Nothing
      Me.cmbRubroCompra.BindearPropiedadEntidad = Nothing
      Me.cmbRubroCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRubroCompra.Enabled = False
      Me.cmbRubroCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbRubroCompra.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRubroCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRubroCompra.FormattingEnabled = True
      Me.cmbRubroCompra.IsPK = False
      Me.cmbRubroCompra.IsRequired = False
      Me.cmbRubroCompra.Key = Nothing
      Me.cmbRubroCompra.LabelAsoc = Nothing
      Me.cmbRubroCompra.Location = New System.Drawing.Point(354, 87)
      Me.cmbRubroCompra.Name = "cmbRubroCompra"
      Me.cmbRubroCompra.Size = New System.Drawing.Size(90, 21)
      Me.cmbRubroCompra.TabIndex = 12
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
      Me.cmbGrabanLibro.LabelAsoc = Me.lblGrabanLibro
      Me.cmbGrabanLibro.Location = New System.Drawing.Point(354, 114)
      Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
      Me.cmbGrabanLibro.Size = New System.Drawing.Size(90, 21)
      Me.cmbGrabanLibro.TabIndex = 14
      '
      'lblGrabanLibro
      '
      Me.lblGrabanLibro.AutoSize = True
      Me.lblGrabanLibro.LabelAsoc = Nothing
      Me.lblGrabanLibro.Location = New System.Drawing.Point(280, 116)
      Me.lblGrabanLibro.Name = "lblGrabanLibro"
      Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
      Me.lblGrabanLibro.TabIndex = 13
      Me.lblGrabanLibro.Text = "Graban Libro"
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
      Me.chbCategoria.Location = New System.Drawing.Point(17, 89)
      Me.chbCategoria.Name = "chbCategoria"
      Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
      Me.chbCategoria.TabIndex = 8
      Me.chbCategoria.Text = "Categoria"
      Me.chbCategoria.UseVisualStyleBackColor = True
      '
      'cmbCategoria
      '
      Me.cmbCategoria.BindearPropiedadControl = "SelectedValue"
      Me.cmbCategoria.BindearPropiedadEntidad = "Categoria.IdCategoria"
      Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoria.Enabled = False
      Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoria.FormattingEnabled = True
      Me.cmbCategoria.IsPK = False
      Me.cmbCategoria.IsRequired = True
      Me.cmbCategoria.Key = Nothing
      Me.cmbCategoria.LabelAsoc = Nothing
      Me.cmbCategoria.Location = New System.Drawing.Point(98, 87)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(165, 21)
      Me.cmbCategoria.TabIndex = 9
      '
      'chbSaldosPositivos
      '
      Me.chbSaldosPositivos.AutoSize = True
      Me.chbSaldosPositivos.BindearPropiedadControl = Nothing
      Me.chbSaldosPositivos.BindearPropiedadEntidad = Nothing
      Me.chbSaldosPositivos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbSaldosPositivos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbSaldosPositivos.IsPK = False
      Me.chbSaldosPositivos.IsRequired = False
      Me.chbSaldosPositivos.Key = Nothing
      Me.chbSaldosPositivos.LabelAsoc = Nothing
      Me.chbSaldosPositivos.Location = New System.Drawing.Point(283, 64)
      Me.chbSaldosPositivos.Name = "chbSaldosPositivos"
      Me.chbSaldosPositivos.Size = New System.Drawing.Size(127, 17)
      Me.chbSaldosPositivos.TabIndex = 10
      Me.chbSaldosPositivos.Text = "Solo Saldos Positivos"
      Me.chbSaldosPositivos.UseVisualStyleBackColor = True
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
      Me.chbProveedor.Location = New System.Drawing.Point(17, 33)
      Me.chbProveedor.Name = "chbProveedor"
      Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
      Me.chbProveedor.TabIndex = 0
      Me.chbProveedor.Text = "Proveedor"
      Me.chbProveedor.UseVisualStyleBackColor = True
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
      Me.bscCodigoProveedor.IsNumber = True
      Me.bscCodigoProveedor.IsPK = False
      Me.bscCodigoProveedor.IsRequired = False
      Me.bscCodigoProveedor.Key = ""
      Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
      Me.bscCodigoProveedor.Location = New System.Drawing.Point(101, 32)
      Me.bscCodigoProveedor.MaxLengh = "32767"
      Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
      Me.bscCodigoProveedor.Permitido = True
      Me.bscCodigoProveedor.Selecciono = False
      Me.bscCodigoProveedor.Size = New System.Drawing.Size(162, 23)
      Me.bscCodigoProveedor.TabIndex = 2
      Me.bscCodigoProveedor.Titulo = Nothing
      '
      'lblCodigoProveedor
      '
      Me.lblCodigoProveedor.AutoSize = True
      Me.lblCodigoProveedor.LabelAsoc = Nothing
      Me.lblCodigoProveedor.Location = New System.Drawing.Point(98, 16)
      Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
      Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoProveedor.TabIndex = 1
      Me.lblCodigoProveedor.Text = "Código"
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
      Me.bscProveedor.LabelAsoc = Me.lblNombre
      Me.bscProveedor.Location = New System.Drawing.Point(283, 32)
      Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProveedor.MaxLengh = "32767"
      Me.bscProveedor.Name = "bscProveedor"
      Me.bscProveedor.Permitido = True
      Me.bscProveedor.Selecciono = False
      Me.bscProveedor.Size = New System.Drawing.Size(300, 23)
      Me.bscProveedor.TabIndex = 4
      Me.bscProveedor.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(280, 16)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 3
      Me.lblNombre.Text = "Nombre"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(548, 84)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 15
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'chbFecha
      '
      Me.chbFecha.AutoSize = True
      Me.chbFecha.BindearPropiedadControl = Nothing
      Me.chbFecha.BindearPropiedadEntidad = Nothing
      Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFecha.IsPK = False
      Me.chbFecha.IsRequired = False
      Me.chbFecha.Key = Nothing
      Me.chbFecha.LabelAsoc = Nothing
      Me.chbFecha.Location = New System.Drawing.Point(17, 63)
      Me.chbFecha.Name = "chbFecha"
      Me.chbFecha.Size = New System.Drawing.Size(56, 17)
      Me.chbFecha.TabIndex = 5
      Me.chbFecha.Text = "Fecha"
      Me.chbFecha.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.Enabled = False
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(138, 61)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(86, 20)
      Me.dtpHasta.TabIndex = 7
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(98, 65)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 6
      Me.lblHasta.Text = "Hasta"
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "find.ico")
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar, Me.ToolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(881, 29)
      Me.tstBarra.TabIndex = 6
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
      Me.tsbImprimir.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
      Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
      Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsddExportar.Name = "tsddExportar"
      Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
      Me.tsddExportar.Text = "Exportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
      Me.tsmiAPDF.Text = "a PDF"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbPreferencias
      '
      Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
      Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbPreferencias.Name = "tsbPreferencias"
      Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
      Me.tsbPreferencias.Text = "&Preferencias"
      Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 518)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(881, 22)
      Me.stsStado.TabIndex = 5
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(802, 17)
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
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn14.Header.VisiblePosition = 0
      UltraGridColumn14.Hidden = True
      UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn15.CellAppearance = Appearance2
      UltraGridColumn15.Header.Caption = "Código"
      UltraGridColumn15.Header.VisiblePosition = 1
      UltraGridColumn15.Width = 58
      UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn16.Header.Caption = "Proveedor"
      UltraGridColumn16.Header.VisiblePosition = 2
      UltraGridColumn16.Width = 191
      UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn17.Header.Caption = "CUIT"
      UltraGridColumn17.Header.VisiblePosition = 4
      UltraGridColumn17.Width = 92
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn1.Header.Caption = "Teléfono"
      UltraGridColumn1.Header.VisiblePosition = 5
      UltraGridColumn1.Width = 113
      UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn11.CellAppearance = Appearance3
      UltraGridColumn11.Format = "N2"
      UltraGridColumn11.Header.VisiblePosition = 6
      UltraGridColumn11.Width = 89
      UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn18.CellAppearance = Appearance4
      UltraGridColumn18.Header.Caption = "Vencido"
      UltraGridColumn18.Header.VisiblePosition = 7
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance5
      UltraGridColumn2.Header.VisiblePosition = 8
      UltraGridColumn2.Hidden = True
      UltraGridColumn3.Header.Caption = "Rubro"
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.Width = 108
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance6
      UltraGridColumn4.Format = "N2"
      UltraGridColumn4.Header.VisiblePosition = 9
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn1, UltraGridColumn11, UltraGridColumn18, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
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
      Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 178)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(857, 303)
      Me.ugDetalle.TabIndex = 7
      '
      'SaldosCtaCteProveedores
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(881, 540)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "SaldosCtaCteProveedores"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Saldos de Cta. Cte. de Proveedores"
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbSaldosPositivos As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents cmbRubroCompra As Eniac.Controles.ComboBox
   Friend WithEvents chbRubroCompra As Eniac.Controles.CheckBox
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
End Class
