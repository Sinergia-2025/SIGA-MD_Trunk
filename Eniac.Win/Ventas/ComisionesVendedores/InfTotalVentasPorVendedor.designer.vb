<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InfTotalVentasPorVendedor
   Inherits BaseForm

   'Form overrides dispose to clean up the component list.
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

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfTotalVentasPorVendedor))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantComprobantes")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantItems")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalContado")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCtaCte")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comision")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteObjetivo")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcObjetivo")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
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
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.cmbGrupos = New Eniac.Win.ComboBoxGrupoTiposComprobantes
      Me.lblGrupoComprobante = New Eniac.Controles.Label()
      Me.cmbTipoVendedor = New Eniac.Controles.ComboBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
      Me.lblGrabanLibro = New Eniac.Controles.Label()
      Me.txtComisionVendedor = New Eniac.Controles.TextBox()
      Me.txtCalculoComisionVendedor = New Eniac.Controles.TextBox()
      Me.chbUnificar = New Eniac.Controles.CheckBox()
      Me.lblSucursal = New Eniac.Controles.Label()
      Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
      Me.chbConIVA = New Eniac.Controles.CheckBox()
      Me.cmbAfectaCaja = New Eniac.Controles.ComboBox()
      Me.lblAfectaCaja = New Eniac.Controles.Label()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
      Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.cmbConComision = New Eniac.Controles.ComboBox()
      Me.lblConComision = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.chbMesCompleto = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir2 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.dgvDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.grbConsultar.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbConsultar
      '
      Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbConsultar.Controls.Add(Me.cmbGrupos)
      Me.grbConsultar.Controls.Add(Me.cmbTipoVendedor)
      Me.grbConsultar.Controls.Add(Me.cmbVendedor)
      Me.grbConsultar.Controls.Add(Me.chbVendedor)
      Me.grbConsultar.Controls.Add(Me.lblGrupoComprobante)
      Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbConsultar.Controls.Add(Me.bscCodigoCliente)
      Me.grbConsultar.Controls.Add(Me.chbTipoComprobante)
      Me.grbConsultar.Controls.Add(Me.cmbGrabanLibro)
      Me.grbConsultar.Controls.Add(Me.lblGrabanLibro)
      Me.grbConsultar.Controls.Add(Me.txtComisionVendedor)
      Me.grbConsultar.Controls.Add(Me.txtCalculoComisionVendedor)
      Me.grbConsultar.Controls.Add(Me.chbUnificar)
      Me.grbConsultar.Controls.Add(Me.lblSucursal)
      Me.grbConsultar.Controls.Add(Me.cmbSucursal)
      Me.grbConsultar.Controls.Add(Me.chbConIVA)
      Me.grbConsultar.Controls.Add(Me.cmbAfectaCaja)
      Me.grbConsultar.Controls.Add(Me.lblAfectaCaja)
      Me.grbConsultar.Controls.Add(Me.dtpHasta)
      Me.grbConsultar.Controls.Add(Me.dtpDesde)
      Me.grbConsultar.Controls.Add(Me.lblHasta)
      Me.grbConsultar.Controls.Add(Me.lblDesde)
      Me.grbConsultar.Controls.Add(Me.chbZonaGeografica)
      Me.grbConsultar.Controls.Add(Me.cmbZonaGeografica)
      Me.grbConsultar.Controls.Add(Me.chbCliente)
      Me.grbConsultar.Controls.Add(Me.cmbConComision)
      Me.grbConsultar.Controls.Add(Me.lblConComision)
      Me.grbConsultar.Controls.Add(Me.bscCliente)
      Me.grbConsultar.Controls.Add(Me.lblCodigoCliente)
      Me.grbConsultar.Controls.Add(Me.lblNombre)
      Me.grbConsultar.Controls.Add(Me.chbMesCompleto)
      Me.grbConsultar.Controls.Add(Me.btnConsultar)
      Me.grbConsultar.Location = New System.Drawing.Point(6, 32)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(992, 153)
      Me.grbConsultar.TabIndex = 1
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Consultar"
      '
      'cmbGrupos
      '
      Me.cmbGrupos.BindearPropiedadControl = Nothing
      Me.cmbGrupos.BindearPropiedadEntidad = Nothing
      Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGrupos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbGrupos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbGrupos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbGrupos.FormattingEnabled = True
      Me.cmbGrupos.IsPK = False
      Me.cmbGrupos.IsRequired = False
      Me.cmbGrupos.ItemHeight = 13
      Me.cmbGrupos.Key = Nothing
      Me.cmbGrupos.LabelAsoc = Me.lblGrupoComprobante
      Me.cmbGrupos.Location = New System.Drawing.Point(463, 93)
      Me.cmbGrupos.Name = "cmbGrupos"
      Me.cmbGrupos.Size = New System.Drawing.Size(101, 21)
      Me.cmbGrupos.TabIndex = 30
      '
      'lblGrupoComprobante
      '
      Me.lblGrupoComprobante.AutoSize = True
      Me.lblGrupoComprobante.LabelAsoc = Nothing
      Me.lblGrupoComprobante.Location = New System.Drawing.Point(421, 98)
      Me.lblGrupoComprobante.Name = "lblGrupoComprobante"
      Me.lblGrupoComprobante.Size = New System.Drawing.Size(36, 13)
      Me.lblGrupoComprobante.TabIndex = 20
      Me.lblGrupoComprobante.Text = "Grupo"
      '
      'cmbTipoVendedor
      '
      Me.cmbTipoVendedor.BindearPropiedadControl = Nothing
      Me.cmbTipoVendedor.BindearPropiedadEntidad = Nothing
      Me.cmbTipoVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoVendedor.FormattingEnabled = True
      Me.cmbTipoVendedor.IsPK = False
      Me.cmbTipoVendedor.IsRequired = False
      Me.cmbTipoVendedor.Key = Nothing
      Me.cmbTipoVendedor.LabelAsoc = Nothing
      Me.cmbTipoVendedor.Location = New System.Drawing.Point(273, 123)
      Me.cmbTipoVendedor.Name = "cmbTipoVendedor"
      Me.cmbTipoVendedor.Size = New System.Drawing.Size(83, 21)
      Me.cmbTipoVendedor.TabIndex = 19
      '
      'cmbVendedor
      '
      Me.cmbVendedor.BindearPropiedadControl = Nothing
      Me.cmbVendedor.BindearPropiedadEntidad = Nothing
      Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVendedor.Enabled = False
      Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVendedor.FormattingEnabled = True
      Me.cmbVendedor.IsPK = False
      Me.cmbVendedor.IsRequired = False
      Me.cmbVendedor.Key = Nothing
      Me.cmbVendedor.LabelAsoc = Nothing
      Me.cmbVendedor.Location = New System.Drawing.Point(119, 123)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(148, 21)
      Me.cmbVendedor.TabIndex = 18
      '
      'chbVendedor
      '
      Me.chbVendedor.AutoSize = True
      Me.chbVendedor.BindearPropiedadControl = Nothing
      Me.chbVendedor.BindearPropiedadEntidad = Nothing
      Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVendedor.IsPK = False
      Me.chbVendedor.IsRequired = False
      Me.chbVendedor.Key = Nothing
      Me.chbVendedor.LabelAsoc = Nothing
      Me.chbVendedor.Location = New System.Drawing.Point(6, 127)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 17
      Me.chbVendedor.Text = "Vendedor"
      Me.chbVendedor.UseVisualStyleBackColor = True
      '
      'cmbTiposComprobantes
      '
      Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
      Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
      Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantes.Enabled = False
      Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantes.FormattingEnabled = True
      Me.cmbTiposComprobantes.IsPK = False
      Me.cmbTiposComprobantes.IsRequired = False
      Me.cmbTiposComprobantes.ItemHeight = 13
      Me.cmbTiposComprobantes.Key = Nothing
      Me.cmbTiposComprobantes.LabelAsoc = Me.chbTipoComprobante
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(119, 93)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(148, 21)
      Me.cmbTiposComprobantes.TabIndex = 16
      '
      'chbTipoComprobante
      '
      Me.chbTipoComprobante.AutoSize = True
      Me.chbTipoComprobante.BindearPropiedadControl = Nothing
      Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
      Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTipoComprobante.IsPK = False
      Me.chbTipoComprobante.IsRequired = False
      Me.chbTipoComprobante.Key = Nothing
      Me.chbTipoComprobante.LabelAsoc = Nothing
      Me.chbTipoComprobante.Location = New System.Drawing.Point(6, 97)
      Me.chbTipoComprobante.Name = "chbTipoComprobante"
      Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
      Me.chbTipoComprobante.TabIndex = 15
      Me.chbTipoComprobante.Text = "Tipo Comprobante"
      Me.chbTipoComprobante.UseVisualStyleBackColor = True
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.AyudaAncho = 608
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasAlineacion = Nothing
      Me.bscCodigoCliente.ColumnasAncho = Nothing
      Me.bscCodigoCliente.ColumnasFormato = Nothing
      Me.bscCodigoCliente.ColumnasOcultas = Nothing
      Me.bscCodigoCliente.ColumnasTitulos = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.Enabled = False
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(63, 60)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 10
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(66, 47)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 9
      Me.lblCodigoCliente.Text = "Código"
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
      Me.cmbGrabanLibro.Location = New System.Drawing.Point(463, 123)
      Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
      Me.cmbGrabanLibro.Size = New System.Drawing.Size(101, 21)
      Me.cmbGrabanLibro.TabIndex = 23
      '
      'lblGrabanLibro
      '
      Me.lblGrabanLibro.AutoSize = True
      Me.lblGrabanLibro.LabelAsoc = Nothing
      Me.lblGrabanLibro.Location = New System.Drawing.Point(389, 128)
      Me.lblGrabanLibro.Name = "lblGrabanLibro"
      Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
      Me.lblGrabanLibro.TabIndex = 22
      Me.lblGrabanLibro.Text = "Graban Libro"
      '
      'txtComisionVendedor
      '
      Me.txtComisionVendedor.BindearPropiedadControl = Nothing
      Me.txtComisionVendedor.BindearPropiedadEntidad = Nothing
      Me.txtComisionVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComisionVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComisionVendedor.Formato = ""
      Me.txtComisionVendedor.IsDecimal = False
      Me.txtComisionVendedor.IsNumber = False
      Me.txtComisionVendedor.IsPK = False
      Me.txtComisionVendedor.IsRequired = False
      Me.txtComisionVendedor.Key = ""
      Me.txtComisionVendedor.LabelAsoc = Nothing
      Me.txtComisionVendedor.Location = New System.Drawing.Point(817, 38)
      Me.txtComisionVendedor.Name = "txtComisionVendedor"
      Me.txtComisionVendedor.ReadOnly = True
      Me.txtComisionVendedor.Size = New System.Drawing.Size(170, 20)
      Me.txtComisionVendedor.TabIndex = 19
      Me.txtComisionVendedor.TabStop = False
      '
      'txtCalculoComisionVendedor
      '
      Me.txtCalculoComisionVendedor.BindearPropiedadControl = Nothing
      Me.txtCalculoComisionVendedor.BindearPropiedadEntidad = Nothing
      Me.txtCalculoComisionVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCalculoComisionVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCalculoComisionVendedor.Formato = ""
      Me.txtCalculoComisionVendedor.IsDecimal = False
      Me.txtCalculoComisionVendedor.IsNumber = False
      Me.txtCalculoComisionVendedor.IsPK = False
      Me.txtCalculoComisionVendedor.IsRequired = False
      Me.txtCalculoComisionVendedor.Key = ""
      Me.txtCalculoComisionVendedor.LabelAsoc = Nothing
      Me.txtCalculoComisionVendedor.Location = New System.Drawing.Point(817, 13)
      Me.txtCalculoComisionVendedor.Name = "txtCalculoComisionVendedor"
      Me.txtCalculoComisionVendedor.ReadOnly = True
      Me.txtCalculoComisionVendedor.Size = New System.Drawing.Size(170, 20)
      Me.txtCalculoComisionVendedor.TabIndex = 9
      Me.txtCalculoComisionVendedor.TabStop = False
      '
      'chbUnificar
      '
      Me.chbUnificar.AutoSize = True
      Me.chbUnificar.BindearPropiedadControl = Nothing
      Me.chbUnificar.BindearPropiedadEntidad = Nothing
      Me.chbUnificar.Checked = True
      Me.chbUnificar.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbUnificar.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUnificar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUnificar.IsPK = False
      Me.chbUnificar.IsRequired = False
      Me.chbUnificar.Key = Nothing
      Me.chbUnificar.LabelAsoc = Nothing
      Me.chbUnificar.Location = New System.Drawing.Point(192, 26)
      Me.chbUnificar.Name = "chbUnificar"
      Me.chbUnificar.Size = New System.Drawing.Size(62, 17)
      Me.chbUnificar.TabIndex = 2
      Me.chbUnificar.Text = "Unificar"
      Me.chbUnificar.UseVisualStyleBackColor = True
      '
      'lblSucursal
      '
      Me.lblSucursal.AutoSize = True
      Me.lblSucursal.LabelAsoc = Nothing
      Me.lblSucursal.Location = New System.Drawing.Point(2, 27)
      Me.lblSucursal.Name = "lblSucursal"
      Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
      Me.lblSucursal.TabIndex = 0
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
      Me.cmbSucursal.Location = New System.Drawing.Point(56, 23)
      Me.cmbSucursal.Name = "cmbSucursal"
      Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
      Me.cmbSucursal.TabIndex = 1
      '
      'chbConIVA
      '
      Me.chbConIVA.AutoSize = True
      Me.chbConIVA.BindearPropiedadControl = Nothing
      Me.chbConIVA.BindearPropiedadEntidad = Nothing
      Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
      Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbConIVA.IsPK = False
      Me.chbConIVA.IsRequired = False
      Me.chbConIVA.Key = Nothing
      Me.chbConIVA.LabelAsoc = Nothing
      Me.chbConIVA.Location = New System.Drawing.Point(781, 125)
      Me.chbConIVA.Name = "chbConIVA"
      Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
      Me.chbConIVA.TabIndex = 28
      Me.chbConIVA.Text = "Con IVA"
      Me.chbConIVA.UseVisualStyleBackColor = True
      '
      'cmbAfectaCaja
      '
      Me.cmbAfectaCaja.BindearPropiedadControl = Nothing
      Me.cmbAfectaCaja.BindearPropiedadEntidad = Nothing
      Me.cmbAfectaCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAfectaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbAfectaCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbAfectaCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbAfectaCaja.FormattingEnabled = True
      Me.cmbAfectaCaja.IsPK = False
      Me.cmbAfectaCaja.IsRequired = False
      Me.cmbAfectaCaja.Key = Nothing
      Me.cmbAfectaCaja.LabelAsoc = Me.lblAfectaCaja
      Me.cmbAfectaCaja.Location = New System.Drawing.Point(677, 123)
      Me.cmbAfectaCaja.Name = "cmbAfectaCaja"
      Me.cmbAfectaCaja.Size = New System.Drawing.Size(90, 21)
      Me.cmbAfectaCaja.TabIndex = 27
      '
      'lblAfectaCaja
      '
      Me.lblAfectaCaja.AutoSize = True
      Me.lblAfectaCaja.LabelAsoc = Nothing
      Me.lblAfectaCaja.Location = New System.Drawing.Point(609, 128)
      Me.lblAfectaCaja.Name = "lblAfectaCaja"
      Me.lblAfectaCaja.Size = New System.Drawing.Size(62, 13)
      Me.lblAfectaCaja.TabIndex = 26
      Me.lblAfectaCaja.Text = "Afecta Caja"
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
      Me.dtpHasta.Location = New System.Drawing.Point(596, 23)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 7
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(555, 27)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 6
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
      Me.dtpDesde.Location = New System.Drawing.Point(417, 23)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 5
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(361, 27)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 4
      Me.lblDesde.Text = "Desde"
      '
      'chbZonaGeografica
      '
      Me.chbZonaGeografica.AutoSize = True
      Me.chbZonaGeografica.BindearPropiedadControl = Nothing
      Me.chbZonaGeografica.BindearPropiedadEntidad = Nothing
      Me.chbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.chbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbZonaGeografica.IsPK = False
      Me.chbZonaGeografica.IsRequired = False
      Me.chbZonaGeografica.Key = Nothing
      Me.chbZonaGeografica.LabelAsoc = Nothing
      Me.chbZonaGeografica.Location = New System.Drawing.Point(417, 61)
      Me.chbZonaGeografica.Name = "chbZonaGeografica"
      Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
      Me.chbZonaGeografica.TabIndex = 13
      Me.chbZonaGeografica.Text = "Zona Geográfica"
      Me.chbZonaGeografica.UseVisualStyleBackColor = True
      '
      'cmbZonaGeografica
      '
      Me.cmbZonaGeografica.BindearPropiedadControl = Nothing
      Me.cmbZonaGeografica.BindearPropiedadEntidad = Nothing
      Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbZonaGeografica.Enabled = False
      Me.cmbZonaGeografica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbZonaGeografica.FormattingEnabled = True
      Me.cmbZonaGeografica.IsPK = False
      Me.cmbZonaGeografica.IsRequired = False
      Me.cmbZonaGeografica.Key = Nothing
      Me.cmbZonaGeografica.LabelAsoc = Nothing
      Me.cmbZonaGeografica.Location = New System.Drawing.Point(529, 59)
      Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
      Me.cmbZonaGeografica.Size = New System.Drawing.Size(135, 21)
      Me.cmbZonaGeografica.TabIndex = 14
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
      Me.chbCliente.Location = New System.Drawing.Point(6, 63)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 8
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'cmbConComision
      '
      Me.cmbConComision.BindearPropiedadControl = Nothing
      Me.cmbConComision.BindearPropiedadEntidad = Nothing
      Me.cmbConComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbConComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbConComision.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbConComision.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbConComision.FormattingEnabled = True
      Me.cmbConComision.IsPK = False
      Me.cmbConComision.IsRequired = False
      Me.cmbConComision.Key = Nothing
      Me.cmbConComision.LabelAsoc = Me.lblConComision
      Me.cmbConComision.Location = New System.Drawing.Point(677, 93)
      Me.cmbConComision.Name = "cmbConComision"
      Me.cmbConComision.Size = New System.Drawing.Size(90, 21)
      Me.cmbConComision.TabIndex = 25
      Me.cmbConComision.TabStop = False
      '
      'lblConComision
      '
      Me.lblConComision.AutoSize = True
      Me.lblConComision.LabelAsoc = Nothing
      Me.lblConComision.Location = New System.Drawing.Point(600, 98)
      Me.lblConComision.Name = "lblConComision"
      Me.lblConComision.Size = New System.Drawing.Size(71, 13)
      Me.lblConComision.TabIndex = 24
      Me.lblConComision.Text = "Con Comision"
      '
      'bscCliente
      '
      Me.bscCliente.AutoSize = True
      Me.bscCliente.AyudaAncho = 608
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasAlineacion = Nothing
      Me.bscCliente.ColumnasAncho = Nothing
      Me.bscCliente.ColumnasFormato = Nothing
      Me.bscCliente.ColumnasOcultas = Nothing
      Me.bscCliente.ColumnasTitulos = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.Enabled = False
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = False
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Me.lblNombre
      Me.bscCliente.Location = New System.Drawing.Point(159, 60)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(236, 23)
      Me.bscCliente.TabIndex = 12
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(162, 47)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 11
      Me.lblNombre.Text = "Nombre"
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
      Me.chbMesCompleto.Location = New System.Drawing.Point(271, 26)
      Me.chbMesCompleto.Name = "chbMesCompleto"
      Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chbMesCompleto.TabIndex = 3
      Me.chbMesCompleto.Text = "Mes Completo"
      Me.chbMesCompleto.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(883, 93)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 29
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsbImprimir2, Me.ToolStripSeparator5, Me.tsddExportar, Me.ToolStripSeparator4, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1004, 29)
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
      Me.tsbImprimir.Text = "Imprimir"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimir2
      '
      Me.tsbImprimir2.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir2.Name = "tsbImprimir2"
      Me.tsbImprimir2.Size = New System.Drawing.Size(125, 26)
      Me.tsbImprimir2.Text = "Imp. &Prediseñado"
      Me.tsbImprimir2.ToolTipText = "Imprimir Reporte Prediseñado"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
      Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
      Me.tsmiAPDF.Text = "a PDF"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
      'dgvDetalle
      '
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.dgvDetalle.DisplayLayout.Appearance = Appearance1
      Me.dgvDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn1.Header.Caption = "S."
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Width = 41
      UltraGridColumn4.Header.Caption = "Vendedor"
      UltraGridColumn4.Header.VisiblePosition = 2
      UltraGridColumn4.Width = 388
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance2
      UltraGridColumn5.Format = "N0"
      UltraGridColumn5.Header.Caption = "Cant. Comp."
      UltraGridColumn5.Header.VisiblePosition = 3
      UltraGridColumn5.Width = 67
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance3
      UltraGridColumn6.Format = "N0"
      UltraGridColumn6.Header.Caption = "Cant. Items"
      UltraGridColumn6.Header.VisiblePosition = 4
      UltraGridColumn6.Width = 59
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance4
      UltraGridColumn7.Format = "N2"
      UltraGridColumn7.Header.Caption = "Total Contado"
      UltraGridColumn7.Header.VisiblePosition = 5
      UltraGridColumn7.Width = 97
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance5
      UltraGridColumn8.Format = "N2"
      UltraGridColumn8.Header.Caption = "Total Cta.Cte."
      UltraGridColumn8.Header.VisiblePosition = 6
      UltraGridColumn8.Width = 95
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn9.CellAppearance = Appearance6
      UltraGridColumn9.Format = "N2"
      UltraGridColumn9.Header.Caption = "Total (Neto)"
      UltraGridColumn9.Header.VisiblePosition = 7
      UltraGridColumn9.Width = 94
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn10.CellAppearance = Appearance7
      UltraGridColumn10.Format = "N2"
      UltraGridColumn10.Header.Caption = "Comisión"
      UltraGridColumn10.Header.VisiblePosition = 8
      UltraGridColumn10.Width = 89
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn11.CellAppearance = Appearance8
      Appearance9.TextHAlignAsString = "Right"
      UltraGridColumn11.FilterCellAppearance = Appearance9
      UltraGridColumn11.Format = "N2"
      UltraGridColumn11.Header.Caption = "Objetivo"
      UltraGridColumn11.Header.VisiblePosition = 10
      UltraGridColumn11.Hidden = True
      UltraGridColumn11.Width = 88
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn12.CellAppearance = Appearance10
      UltraGridColumn12.Format = "N2"
      UltraGridColumn12.Header.Caption = "% Obj"
      UltraGridColumn12.Header.VisiblePosition = 9
      UltraGridColumn12.Hidden = True
      UltraGridColumn12.Width = 55
      Appearance11.TextHAlignAsString = "Right"
      UltraGridColumn13.CellAppearance = Appearance11
      UltraGridColumn13.Header.Caption = "Código"
      UltraGridColumn13.Header.VisiblePosition = 1
      UltraGridColumn13.Width = 60
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13})
      Me.dgvDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.dgvDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance12.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvDetalle.DisplayLayout.GroupByBox.Appearance = Appearance12
      Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance13
      Me.dgvDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance14.BackColor2 = System.Drawing.SystemColors.Control
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance14
      Me.dgvDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.dgvDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.ForeColor = System.Drawing.SystemColors.ControlText
      Me.dgvDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance15
      Appearance16.BackColor = System.Drawing.SystemColors.Highlight
      Appearance16.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dgvDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance16
      Me.dgvDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.dgvDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance17.BackColor = System.Drawing.SystemColors.Window
      Me.dgvDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance17
      Appearance18.BorderColor = System.Drawing.Color.Silver
      Appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.dgvDetalle.DisplayLayout.Override.CellAppearance = Appearance18
      Me.dgvDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.dgvDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance19.BackColor = System.Drawing.SystemColors.Control
      Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance19.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance19
      Appearance20.TextHAlignAsString = "Left"
      Me.dgvDetalle.DisplayLayout.Override.HeaderAppearance = Appearance20
      Me.dgvDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.dgvDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance21.BackColor = System.Drawing.SystemColors.Window
      Appearance21.BorderColor = System.Drawing.Color.Silver
      Me.dgvDetalle.DisplayLayout.Override.RowAppearance = Appearance21
      Me.dgvDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance22.BackColor = System.Drawing.SystemColors.ControlLight
      Me.dgvDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance22
      Me.dgvDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.dgvDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dgvDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dgvDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgvDetalle.Location = New System.Drawing.Point(6, 191)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.Size = New System.Drawing.Size(992, 325)
      Me.dgvDetalle.TabIndex = 2
      Me.dgvDetalle.Text = "UltraGrid1"
      '
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.FitWidthToPages = 1
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.dgvDetalle
      Appearance23.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance23
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
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'InfTotalVentasPorVendedor
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1004, 528)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbConsultar)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "InfTotalVentasPorVendedor"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Total de Ventas por Vendedor"
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbConComision As Eniac.Controles.ComboBox
   Friend WithEvents lblConComision As Eniac.Controles.Label
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents cmbAfectaCaja As Eniac.Controles.ComboBox
   Friend WithEvents lblAfectaCaja As Eniac.Controles.Label
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents chbUnificar As Eniac.Controles.CheckBox
   Friend WithEvents dgvDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents txtCalculoComisionVendedor As Eniac.Controles.TextBox
   Friend WithEvents txtComisionVendedor As Eniac.Controles.TextBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents tsbImprimir2 As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents lblGrupoComprobante As Eniac.Controles.Label
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbTipoVendedor As Eniac.Controles.ComboBox
   Friend WithEvents cmbGrupos As ComboBoxGrupoTiposComprobantes
End Class
