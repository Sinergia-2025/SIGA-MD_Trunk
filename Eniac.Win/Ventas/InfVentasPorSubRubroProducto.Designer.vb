<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfVentasPorSubRubroProducto
   Inherits Eniac.Win.BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubRubro")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteNeto")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
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
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSubRubro")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubRubro")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteNeto")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Kilos")
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfVentasPorSubRubroProducto))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.pnlSubSubRubros = New System.Windows.Forms.Panel()
      Me.cmbSubSubRubros = New Eniac.Win.ComboBoxSubSubRubro()
      Me.lblSubSubRubros = New Eniac.Controles.Label()
      Me.pnlSubRubros = New System.Windows.Forms.Panel()
      Me.cmbSubRubros = New Eniac.Win.ComboBoxSubRubro()
      Me.lblSubRubros = New Eniac.Controles.Label()
      Me.pnlRubros = New System.Windows.Forms.Panel()
      Me.cmbRubros = New Eniac.Win.ComboBoxRubro()
      Me.lblRubros = New Eniac.Controles.Label()
      Me.pnlModelos = New System.Windows.Forms.Panel()
      Me.cmbModelos = New Eniac.Win.ComboBoxModelos()
      Me.lblModelos = New Eniac.Controles.Label()
      Me.pnlMarcas = New System.Windows.Forms.Panel()
      Me.lblMarcas = New Eniac.Controles.Label()
      Me.cmbMarcas = New Eniac.Win.ComboBoxMarcas()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.ugDetalle = New Eniac.Win.UltraGridSiga()
      Me.UltraDataSource3 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.pnlSubSubRubros.SuspendLayout()
      Me.pnlSubRubros.SuspendLayout()
      Me.pnlRubros.SuspendLayout()
      Me.pnlModelos.SuspendLayout()
      Me.pnlMarcas.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(834, 31)
      Me.tstBarra.TabIndex = 4
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(106, 28)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(81, 28)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 31)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(67, 28)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.TableLayoutPanel1)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
      Me.grbFiltros.Location = New System.Drawing.Point(0, 31)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(834, 89)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TableLayoutPanel1.ColumnCount = 3
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.Controls.Add(Me.pnlSubSubRubros, 2, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.pnlSubRubros, 1, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.pnlRubros, 0, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.pnlModelos, 1, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.pnlMarcas, 0, 0)
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 39)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 2
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(822, 48)
      Me.TableLayoutPanel1.TabIndex = 5
      '
      'pnlSubSubRubros
      '
      Me.pnlSubSubRubros.AutoSize = True
      Me.pnlSubSubRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlSubSubRubros.Controls.Add(Me.cmbSubSubRubros)
      Me.pnlSubSubRubros.Controls.Add(Me.lblSubSubRubros)
      Me.pnlSubSubRubros.Location = New System.Drawing.Point(528, 24)
      Me.pnlSubSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
      Me.pnlSubSubRubros.Name = "pnlSubSubRubros"
      Me.pnlSubSubRubros.Size = New System.Drawing.Size(281, 21)
      Me.pnlSubSubRubros.TabIndex = 4
      '
      'cmbSubSubRubros
      '
      Me.cmbSubSubRubros.BindearPropiedadControl = Nothing
      Me.cmbSubSubRubros.BindearPropiedadEntidad = Nothing
      Me.cmbSubSubRubros.ConcatenarNombreSubRubro = False
      Me.cmbSubSubRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSubSubRubros.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSubSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSubSubRubros.FormattingEnabled = True
      Me.cmbSubSubRubros.IsPK = False
      Me.cmbSubSubRubros.IsRequired = False
      Me.cmbSubSubRubros.Key = Nothing
      Me.cmbSubSubRubros.LabelAsoc = Me.lblSubSubRubros
      Me.cmbSubSubRubros.Location = New System.Drawing.Point(81, 0)
      Me.cmbSubSubRubros.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbSubSubRubros.Name = "cmbSubSubRubros"
      Me.cmbSubSubRubros.Size = New System.Drawing.Size(200, 21)
      Me.cmbSubSubRubros.TabIndex = 1
      '
      'lblSubSubRubros
      '
      Me.lblSubSubRubros.AutoSize = True
      Me.lblSubSubRubros.LabelAsoc = Nothing
      Me.lblSubSubRubros.Location = New System.Drawing.Point(3, 3)
      Me.lblSubSubRubros.Name = "lblSubSubRubros"
      Me.lblSubSubRubros.Size = New System.Drawing.Size(79, 13)
      Me.lblSubSubRubros.TabIndex = 0
      Me.lblSubSubRubros.Text = "SubSubRubros"
      '
      'pnlSubRubros
      '
      Me.pnlSubRubros.AutoSize = True
      Me.pnlSubRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlSubRubros.Controls.Add(Me.cmbSubRubros)
      Me.pnlSubRubros.Controls.Add(Me.lblSubRubros)
      Me.pnlSubRubros.Location = New System.Drawing.Point(257, 24)
      Me.pnlSubRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
      Me.pnlSubRubros.Name = "pnlSubRubros"
      Me.pnlSubRubros.Size = New System.Drawing.Size(265, 21)
      Me.pnlSubRubros.TabIndex = 3
      '
      'cmbSubRubros
      '
      Me.cmbSubRubros.BindearPropiedadControl = Nothing
      Me.cmbSubRubros.BindearPropiedadEntidad = Nothing
      Me.cmbSubRubros.ConcatenarNombreRubro = False
      Me.cmbSubRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSubRubros.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSubRubros.FormattingEnabled = True
      Me.cmbSubRubros.IsPK = False
      Me.cmbSubRubros.IsRequired = False
      Me.cmbSubRubros.Key = Nothing
      Me.cmbSubRubros.LabelAsoc = Me.lblSubRubros
      Me.cmbSubRubros.Location = New System.Drawing.Point(65, 0)
      Me.cmbSubRubros.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbSubRubros.Name = "cmbSubRubros"
      Me.cmbSubRubros.Size = New System.Drawing.Size(200, 21)
      Me.cmbSubRubros.TabIndex = 1
      '
      'lblSubRubros
      '
      Me.lblSubRubros.AutoSize = True
      Me.lblSubRubros.LabelAsoc = Nothing
      Me.lblSubRubros.Location = New System.Drawing.Point(3, 4)
      Me.lblSubRubros.Name = "lblSubRubros"
      Me.lblSubRubros.Size = New System.Drawing.Size(60, 13)
      Me.lblSubRubros.TabIndex = 0
      Me.lblSubRubros.Text = "SubRubros"
      '
      'pnlRubros
      '
      Me.pnlRubros.AutoSize = True
      Me.pnlRubros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlRubros.Controls.Add(Me.cmbRubros)
      Me.pnlRubros.Controls.Add(Me.lblRubros)
      Me.pnlRubros.Location = New System.Drawing.Point(3, 24)
      Me.pnlRubros.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
      Me.pnlRubros.Name = "pnlRubros"
      Me.pnlRubros.Size = New System.Drawing.Size(247, 21)
      Me.pnlRubros.TabIndex = 2
      '
      'cmbRubros
      '
      Me.cmbRubros.BindearPropiedadControl = Nothing
      Me.cmbRubros.BindearPropiedadEntidad = Nothing
      Me.cmbRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRubros.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRubros.FormattingEnabled = True
      Me.cmbRubros.IsPK = False
      Me.cmbRubros.IsRequired = False
      Me.cmbRubros.Key = Nothing
      Me.cmbRubros.LabelAsoc = Me.lblRubros
      Me.cmbRubros.Location = New System.Drawing.Point(47, 0)
      Me.cmbRubros.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbRubros.Name = "cmbRubros"
      Me.cmbRubros.Size = New System.Drawing.Size(200, 21)
      Me.cmbRubros.TabIndex = 1
      '
      'lblRubros
      '
      Me.lblRubros.AutoSize = True
      Me.lblRubros.LabelAsoc = Nothing
      Me.lblRubros.Location = New System.Drawing.Point(3, 4)
      Me.lblRubros.Name = "lblRubros"
      Me.lblRubros.Size = New System.Drawing.Size(41, 13)
      Me.lblRubros.TabIndex = 0
      Me.lblRubros.Text = "Rubros"
      '
      'pnlModelos
      '
      Me.pnlModelos.AutoSize = True
      Me.pnlModelos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlModelos.Controls.Add(Me.cmbModelos)
      Me.pnlModelos.Controls.Add(Me.lblModelos)
      Me.pnlModelos.Location = New System.Drawing.Point(257, 0)
      Me.pnlModelos.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
      Me.pnlModelos.Name = "pnlModelos"
      Me.pnlModelos.Size = New System.Drawing.Size(265, 21)
      Me.pnlModelos.TabIndex = 1
      '
      'cmbModelos
      '
      Me.cmbModelos.BindearPropiedadControl = Nothing
      Me.cmbModelos.BindearPropiedadEntidad = Nothing
      Me.cmbModelos.ConcatenarNombreMarca = False
      Me.cmbModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbModelos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbModelos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbModelos.FormattingEnabled = True
      Me.cmbModelos.IsPK = False
      Me.cmbModelos.IsRequired = False
      Me.cmbModelos.Key = Nothing
      Me.cmbModelos.LabelAsoc = Me.lblModelos
      Me.cmbModelos.Location = New System.Drawing.Point(65, 0)
      Me.cmbModelos.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbModelos.Name = "cmbModelos"
      Me.cmbModelos.Size = New System.Drawing.Size(200, 21)
      Me.cmbModelos.TabIndex = 1
      '
      'lblModelos
      '
      Me.lblModelos.AutoSize = True
      Me.lblModelos.LabelAsoc = Nothing
      Me.lblModelos.Location = New System.Drawing.Point(3, 4)
      Me.lblModelos.Name = "lblModelos"
      Me.lblModelos.Size = New System.Drawing.Size(47, 13)
      Me.lblModelos.TabIndex = 0
      Me.lblModelos.Text = "Modelos"
      '
      'pnlMarcas
      '
      Me.pnlMarcas.AutoSize = True
      Me.pnlMarcas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlMarcas.Controls.Add(Me.lblMarcas)
      Me.pnlMarcas.Controls.Add(Me.cmbMarcas)
      Me.pnlMarcas.Location = New System.Drawing.Point(3, 0)
      Me.pnlMarcas.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
      Me.pnlMarcas.Name = "pnlMarcas"
      Me.pnlMarcas.Size = New System.Drawing.Size(248, 21)
      Me.pnlMarcas.TabIndex = 0
      '
      'lblMarcas
      '
      Me.lblMarcas.AutoSize = True
      Me.lblMarcas.LabelAsoc = Nothing
      Me.lblMarcas.Location = New System.Drawing.Point(3, 4)
      Me.lblMarcas.Name = "lblMarcas"
      Me.lblMarcas.Size = New System.Drawing.Size(42, 13)
      Me.lblMarcas.TabIndex = 0
      Me.lblMarcas.Text = "Marcas"
      '
      'cmbMarcas
      '
      Me.cmbMarcas.BindearPropiedadControl = Nothing
      Me.cmbMarcas.BindearPropiedadEntidad = Nothing
      Me.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMarcas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMarcas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMarcas.FormattingEnabled = True
      Me.cmbMarcas.IsPK = False
      Me.cmbMarcas.IsRequired = False
      Me.cmbMarcas.Key = Nothing
      Me.cmbMarcas.LabelAsoc = Me.lblMarcas
      Me.cmbMarcas.Location = New System.Drawing.Point(48, 0)
      Me.cmbMarcas.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbMarcas.Name = "cmbMarcas"
      Me.cmbMarcas.Size = New System.Drawing.Size(200, 21)
      Me.cmbMarcas.TabIndex = 1
      '
      'chkMesCompleto
      '
      Me.chkMesCompleto.AutoSize = True
      Me.chkMesCompleto.BindearPropiedadControl = Nothing
      Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
      Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
      Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkMesCompleto.IsPK = False
      Me.chkMesCompleto.IsRequired = False
      Me.chkMesCompleto.Key = Nothing
      Me.chkMesCompleto.LabelAsoc = Nothing
      Me.chkMesCompleto.Location = New System.Drawing.Point(14, 15)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 0
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(287, 13)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(86, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(250, 17)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(155, 13)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(86, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(111, 17)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkExpandAll.Enabled = False
      Me.chkExpandAll.Location = New System.Drawing.Point(593, 11)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(122, 16)
      Me.chkExpandAll.TabIndex = 1
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(721, 2)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(110, 32)
      Me.btnConsultar.TabIndex = 0
      Me.btnConsultar.Text = "&Consultar (F3)"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'ugDetalle
      '
      Me.ugDetalle.DataSource = Me.UltraDataSource3
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      Me.ugDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn1.Width = 84
      UltraGridColumn2.Header.Caption = "SubRubro"
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn2.Width = 114
      UltraGridColumn3.Header.Caption = "Codigo"
      UltraGridColumn3.Header.VisiblePosition = 1
      UltraGridColumn3.Width = 150
      UltraGridColumn4.Header.Caption = "Producto"
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 318
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance2
      UltraGridColumn5.Header.Caption = "Importe Neto"
      UltraGridColumn5.Header.VisiblePosition = 4
      UltraGridColumn5.Width = 112
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance3
      UltraGridColumn6.Header.VisiblePosition = 5
      UltraGridColumn6.Width = 122
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance4
      UltraGridColumn7.Header.VisiblePosition = 6
      UltraGridColumn7.Width = 115
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance5.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance5
      Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
      Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance7.BackColor2 = System.Drawing.SystemColors.Control
      Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance8.BackColor = System.Drawing.SystemColors.Window
      Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance8
      Appearance9.BackColor = System.Drawing.SystemColors.Highlight
      Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance9
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
      Me.ugDetalle.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance10.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance10
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance12.BackColor = System.Drawing.Color.Tomato
      Appearance12.BackColor2 = System.Drawing.SystemColors.ButtonFace
      Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance12.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
      Appearance13.TextHAlignAsString = "Right"
      Me.ugDetalle.DisplayLayout.Override.GroupBySummaryValueAppearance = Appearance13
      Appearance14.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.InGroupByRows) _
            Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter) _
            Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.HideDataRowFooters), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      Appearance16.TextHAlignAsString = "Right"
      Me.ugDetalle.DisplayLayout.Override.SummaryFooterAppearance = Appearance16
      Appearance17.BackColor = System.Drawing.Color.LimeGreen
      Appearance17.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance17.TextHAlignAsString = "Right"
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance17
      Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
      Me.ugDetalle.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(0, 157)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(834, 382)
      Me.ugDetalle.TabIndex = 2
      Me.ugDetalle.Text = "UltraGrid1"
      Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
      Me.ugDetalle.ToolStripMenuExpandir = Nothing
      '
      'UltraDataSource3
      '
      Me.UltraDataSource3.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7})
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'Panel1
      '
      Me.Panel1.AutoSize = True
      Me.Panel1.Controls.Add(Me.btnConsultar)
      Me.Panel1.Controls.Add(Me.chkExpandAll)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 120)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(834, 37)
      Me.Panel1.TabIndex = 1
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(834, 22)
      Me.stsStado.TabIndex = 3
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(755, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'InfVentasPorSubRubroProducto
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(834, 561)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "InfVentasPorSubRubroProducto"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Ventas por SubRubro/Producto"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.TableLayoutPanel1.PerformLayout()
      Me.pnlSubSubRubros.ResumeLayout(False)
      Me.pnlSubSubRubros.PerformLayout()
      Me.pnlSubRubros.ResumeLayout(False)
      Me.pnlSubRubros.PerformLayout()
      Me.pnlRubros.ResumeLayout(False)
      Me.pnlRubros.PerformLayout()
      Me.pnlModelos.ResumeLayout(False)
      Me.pnlModelos.PerformLayout()
      Me.pnlMarcas.ResumeLayout(False)
      Me.pnlMarcas.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As UltraGridSiga
   Friend WithEvents UltraDataSource3 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents Panel1 As Panel
    Protected Friend WithEvents stsStado As StatusStrip
    Protected Friend WithEvents tssInfo As ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As ToolStripProgressBar
    Protected WithEvents tssRegistros As ToolStripStatusLabel
    Friend WithEvents pnlMarcas As Panel
    Friend WithEvents lblMarcas As Controles.Label
    Friend WithEvents cmbMarcas As ComboBoxMarcas
    Friend WithEvents pnlModelos As Panel
    Friend WithEvents cmbModelos As ComboBoxModelos
    Friend WithEvents lblModelos As Controles.Label
    Friend WithEvents pnlRubros As Panel
    Friend WithEvents cmbRubros As ComboBoxRubro
    Friend WithEvents lblRubros As Controles.Label
    Friend WithEvents pnlSubRubros As Panel
    Friend WithEvents cmbSubRubros As ComboBoxSubRubro
    Friend WithEvents lblSubRubros As Controles.Label
    Friend WithEvents pnlSubSubRubros As Panel
    Friend WithEvents cmbSubSubRubros As ComboBoxSubSubRubro
    Friend WithEvents lblSubSubRubros As Controles.Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
