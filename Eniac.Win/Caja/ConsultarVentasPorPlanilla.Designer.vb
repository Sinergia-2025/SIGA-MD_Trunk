<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarVentasPorPlanilla
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarVentasPorPlanilla))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.txtImporteBancos = New Eniac.Controles.TextBox()
      Me.txtImportePesos = New Eniac.Controles.TextBox()
      Me.txtTotal = New Eniac.Controles.TextBox()
      Me.txtImporteCheques = New Eniac.Controles.TextBox()
      Me.lblTotales = New Eniac.Controles.Label()
      Me.txtImporteTickets = New Eniac.Controles.TextBox()
      Me.txtImporteTarjetas = New Eniac.Controles.TextBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.txtNroPlanillaHasta = New Eniac.Controles.TextBox()
      Me.lblNroPlanillaHasta = New Eniac.Controles.Label()
      Me.txtNroPlanillaDesde = New Eniac.Controles.TextBox()
      Me.lblNroPlanillaDesde = New Eniac.Controles.Label()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
      Me.Label4 = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.chkPorFecha = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescripcionAbrev = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCategoriaFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoImpresora = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdImpresora = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImportePesos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteCheques = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTarjetas = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTickets = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdEstadoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteBancos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "find.ico")
      '
      'txtImporteBancos
      '
      Me.txtImporteBancos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtImporteBancos.BindearPropiedadControl = Nothing
      Me.txtImporteBancos.BindearPropiedadEntidad = Nothing
      Me.txtImporteBancos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporteBancos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporteBancos.Formato = "##0.00"
      Me.txtImporteBancos.IsDecimal = True
      Me.txtImporteBancos.IsNumber = True
      Me.txtImporteBancos.IsPK = False
      Me.txtImporteBancos.IsRequired = False
      Me.txtImporteBancos.Key = ""
      Me.txtImporteBancos.LabelAsoc = Nothing
      Me.txtImporteBancos.Location = New System.Drawing.Point(978, 510)
      Me.txtImporteBancos.Name = "txtImporteBancos"
      Me.txtImporteBancos.ReadOnly = True
      Me.txtImporteBancos.Size = New System.Drawing.Size(70, 20)
      Me.txtImporteBancos.TabIndex = 10
      Me.txtImporteBancos.Text = "0.00"
      Me.txtImporteBancos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtImportePesos
      '
      Me.txtImportePesos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtImportePesos.BindearPropiedadControl = Nothing
      Me.txtImportePesos.BindearPropiedadEntidad = Nothing
      Me.txtImportePesos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImportePesos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImportePesos.Formato = "##0.00"
      Me.txtImportePesos.IsDecimal = True
      Me.txtImportePesos.IsNumber = True
      Me.txtImportePesos.IsPK = False
      Me.txtImportePesos.IsRequired = False
      Me.txtImportePesos.Key = ""
      Me.txtImportePesos.LabelAsoc = Nothing
      Me.txtImportePesos.Location = New System.Drawing.Point(699, 510)
      Me.txtImportePesos.Name = "txtImportePesos"
      Me.txtImportePesos.ReadOnly = True
      Me.txtImportePesos.Size = New System.Drawing.Size(70, 20)
      Me.txtImportePesos.TabIndex = 4
      Me.txtImportePesos.Text = "0.00"
      Me.txtImportePesos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotal
      '
      Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotal.BindearPropiedadControl = Nothing
      Me.txtTotal.BindearPropiedadEntidad = Nothing
      Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotal.Formato = "##0.00"
      Me.txtTotal.IsDecimal = True
      Me.txtTotal.IsNumber = True
      Me.txtTotal.IsPK = False
      Me.txtTotal.IsRequired = False
      Me.txtTotal.Key = ""
      Me.txtTotal.LabelAsoc = Nothing
      Me.txtTotal.Location = New System.Drawing.Point(629, 510)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.txtTotal.Size = New System.Drawing.Size(70, 20)
      Me.txtTotal.TabIndex = 3
      Me.txtTotal.Text = "0.00"
      Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtImporteCheques
      '
      Me.txtImporteCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtImporteCheques.BindearPropiedadControl = Nothing
      Me.txtImporteCheques.BindearPropiedadEntidad = Nothing
      Me.txtImporteCheques.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporteCheques.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporteCheques.Formato = ""
      Me.txtImporteCheques.IsDecimal = False
      Me.txtImporteCheques.IsNumber = False
      Me.txtImporteCheques.IsPK = False
      Me.txtImporteCheques.IsRequired = False
      Me.txtImporteCheques.Key = ""
      Me.txtImporteCheques.LabelAsoc = Nothing
      Me.txtImporteCheques.Location = New System.Drawing.Point(769, 510)
      Me.txtImporteCheques.Name = "txtImporteCheques"
      Me.txtImporteCheques.ReadOnly = True
      Me.txtImporteCheques.Size = New System.Drawing.Size(70, 20)
      Me.txtImporteCheques.TabIndex = 7
      Me.txtImporteCheques.Text = "0.00"
      Me.txtImporteCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotales
      '
      Me.lblTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotales.AutoSize = True
      Me.lblTotales.LabelAsoc = Nothing
      Me.lblTotales.Location = New System.Drawing.Point(579, 513)
      Me.lblTotales.Name = "lblTotales"
      Me.lblTotales.Size = New System.Drawing.Size(45, 13)
      Me.lblTotales.TabIndex = 2
      Me.lblTotales.Text = "Totales:"
      '
      'txtImporteTickets
      '
      Me.txtImporteTickets.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtImporteTickets.BindearPropiedadControl = Nothing
      Me.txtImporteTickets.BindearPropiedadEntidad = Nothing
      Me.txtImporteTickets.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporteTickets.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporteTickets.Formato = "##0.00"
      Me.txtImporteTickets.IsDecimal = True
      Me.txtImporteTickets.IsNumber = True
      Me.txtImporteTickets.IsPK = False
      Me.txtImporteTickets.IsRequired = False
      Me.txtImporteTickets.Key = ""
      Me.txtImporteTickets.LabelAsoc = Nothing
      Me.txtImporteTickets.Location = New System.Drawing.Point(909, 510)
      Me.txtImporteTickets.Name = "txtImporteTickets"
      Me.txtImporteTickets.ReadOnly = True
      Me.txtImporteTickets.Size = New System.Drawing.Size(70, 20)
      Me.txtImporteTickets.TabIndex = 5
      Me.txtImporteTickets.Text = "0.00"
      Me.txtImporteTickets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtImporteTarjetas
      '
      Me.txtImporteTarjetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtImporteTarjetas.BindearPropiedadControl = Nothing
      Me.txtImporteTarjetas.BindearPropiedadEntidad = Nothing
      Me.txtImporteTarjetas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporteTarjetas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporteTarjetas.Formato = "##0.00"
      Me.txtImporteTarjetas.IsDecimal = True
      Me.txtImporteTarjetas.IsNumber = True
      Me.txtImporteTarjetas.IsPK = False
      Me.txtImporteTarjetas.IsRequired = False
      Me.txtImporteTarjetas.Key = ""
      Me.txtImporteTarjetas.LabelAsoc = Nothing
      Me.txtImporteTarjetas.Location = New System.Drawing.Point(839, 510)
      Me.txtImporteTarjetas.Name = "txtImporteTarjetas"
      Me.txtImporteTarjetas.ReadOnly = True
      Me.txtImporteTarjetas.Size = New System.Drawing.Size(70, 20)
      Me.txtImporteTarjetas.TabIndex = 6
      Me.txtImporteTarjetas.Text = "0.00"
      Me.txtImporteTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 537)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(1077, 22)
      Me.stsStado.TabIndex = 8
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(998, 17)
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator3, Me.tsbRefrescar, Me.tsbImprimir, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1077, 29)
      Me.tstBarra.TabIndex = 9
      Me.tstBarra.Text = "toolStrip1"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir y Grabar (F4)"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.txtNroPlanillaHasta)
      Me.grbFiltros.Controls.Add(Me.txtNroPlanillaDesde)
      Me.grbFiltros.Controls.Add(Me.chbNumero)
      Me.grbFiltros.Controls.Add(Me.txtNumero)
      Me.grbFiltros.Controls.Add(Me.chbUsuario)
      Me.grbFiltros.Controls.Add(Me.cmbUsuario)
      Me.grbFiltros.Controls.Add(Me.lblCaja)
      Me.grbFiltros.Controls.Add(Me.cmbCajas)
      Me.grbFiltros.Controls.Add(Me.chbVendedor)
      Me.grbFiltros.Controls.Add(Me.cmbVendedor)
      Me.grbFiltros.Controls.Add(Me.lblNroPlanillaHasta)
      Me.grbFiltros.Controls.Add(Me.lblNroPlanillaDesde)
      Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
      Me.grbFiltros.Controls.Add(Me.Label4)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
      Me.grbFiltros.Controls.Add(Me.chkPorFecha)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(1053, 122)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'txtNroPlanillaHasta
      '
      Me.txtNroPlanillaHasta.BindearPropiedadControl = Nothing
      Me.txtNroPlanillaHasta.BindearPropiedadEntidad = Nothing
      Me.txtNroPlanillaHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroPlanillaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroPlanillaHasta.Formato = "##0"
      Me.txtNroPlanillaHasta.IsDecimal = False
      Me.txtNroPlanillaHasta.IsNumber = True
      Me.txtNroPlanillaHasta.IsPK = False
      Me.txtNroPlanillaHasta.IsRequired = False
      Me.txtNroPlanillaHasta.Key = ""
      Me.txtNroPlanillaHasta.LabelAsoc = Me.lblNroPlanillaHasta
      Me.txtNroPlanillaHasta.Location = New System.Drawing.Point(435, 19)
      Me.txtNroPlanillaHasta.MaxLength = 8
      Me.txtNroPlanillaHasta.Name = "txtNroPlanillaHasta"
      Me.txtNroPlanillaHasta.Size = New System.Drawing.Size(73, 20)
      Me.txtNroPlanillaHasta.TabIndex = 4
      Me.txtNroPlanillaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNroPlanillaHasta
      '
      Me.lblNroPlanillaHasta.AutoSize = True
      Me.lblNroPlanillaHasta.LabelAsoc = Nothing
      Me.lblNroPlanillaHasta.Location = New System.Drawing.Point(387, 23)
      Me.lblNroPlanillaHasta.Name = "lblNroPlanillaHasta"
      Me.lblNroPlanillaHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblNroPlanillaHasta.TabIndex = 5
      Me.lblNroPlanillaHasta.Text = "Hasta"
      '
      'txtNroPlanillaDesde
      '
      Me.txtNroPlanillaDesde.BindearPropiedadControl = Nothing
      Me.txtNroPlanillaDesde.BindearPropiedadEntidad = Nothing
      Me.txtNroPlanillaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroPlanillaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroPlanillaDesde.Formato = "##0"
      Me.txtNroPlanillaDesde.IsDecimal = False
      Me.txtNroPlanillaDesde.IsNumber = True
      Me.txtNroPlanillaDesde.IsPK = False
      Me.txtNroPlanillaDesde.IsRequired = False
      Me.txtNroPlanillaDesde.Key = ""
      Me.txtNroPlanillaDesde.LabelAsoc = Me.lblNroPlanillaDesde
      Me.txtNroPlanillaDesde.Location = New System.Drawing.Point(297, 19)
      Me.txtNroPlanillaDesde.MaxLength = 8
      Me.txtNroPlanillaDesde.Name = "txtNroPlanillaDesde"
      Me.txtNroPlanillaDesde.Size = New System.Drawing.Size(73, 20)
      Me.txtNroPlanillaDesde.TabIndex = 2
      Me.txtNroPlanillaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNroPlanillaDesde
      '
      Me.lblNroPlanillaDesde.AutoSize = True
      Me.lblNroPlanillaDesde.LabelAsoc = Nothing
      Me.lblNroPlanillaDesde.Location = New System.Drawing.Point(188, 23)
      Me.lblNroPlanillaDesde.Name = "lblNroPlanillaDesde"
      Me.lblNroPlanillaDesde.Size = New System.Drawing.Size(103, 13)
      Me.lblNroPlanillaDesde.TabIndex = 3
      Me.lblNroPlanillaDesde.Text = "Nro. Planilla   Desde"
      '
      'chbNumero
      '
      Me.chbNumero.AutoSize = True
      Me.chbNumero.BindearPropiedadControl = Nothing
      Me.chbNumero.BindearPropiedadEntidad = Nothing
      Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumero.IsPK = False
      Me.chbNumero.IsRequired = False
      Me.chbNumero.Key = Nothing
      Me.chbNumero.LabelAsoc = Nothing
      Me.chbNumero.Location = New System.Drawing.Point(746, 65)
      Me.chbNumero.Name = "chbNumero"
      Me.chbNumero.Size = New System.Drawing.Size(63, 17)
      Me.chbNumero.TabIndex = 18
      Me.chbNumero.Text = "Numero"
      Me.chbNumero.UseVisualStyleBackColor = True
      '
      'txtNumero
      '
      Me.txtNumero.BindearPropiedadControl = Nothing
      Me.txtNumero.BindearPropiedadEntidad = Nothing
      Me.txtNumero.Enabled = False
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = "##0"
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = False
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Nothing
      Me.txtNumero.Location = New System.Drawing.Point(813, 63)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(73, 20)
      Me.txtNumero.TabIndex = 19
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbUsuario
      '
      Me.chbUsuario.AutoSize = True
      Me.chbUsuario.BindearPropiedadControl = Nothing
      Me.chbUsuario.BindearPropiedadEntidad = Nothing
      Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUsuario.IsPK = False
      Me.chbUsuario.IsRequired = False
      Me.chbUsuario.Key = Nothing
      Me.chbUsuario.LabelAsoc = Nothing
      Me.chbUsuario.Location = New System.Drawing.Point(813, 96)
      Me.chbUsuario.Name = "chbUsuario"
      Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
      Me.chbUsuario.TabIndex = 26
      Me.chbUsuario.Text = "Usuario"
      Me.chbUsuario.UseVisualStyleBackColor = True
      '
      'cmbUsuario
      '
      Me.cmbUsuario.BindearPropiedadControl = Nothing
      Me.cmbUsuario.BindearPropiedadEntidad = Nothing
      Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuario.Enabled = False
      Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuario.FormattingEnabled = True
      Me.cmbUsuario.IsPK = False
      Me.cmbUsuario.IsRequired = False
      Me.cmbUsuario.Key = Nothing
      Me.cmbUsuario.LabelAsoc = Nothing
      Me.cmbUsuario.Location = New System.Drawing.Point(886, 94)
      Me.cmbUsuario.Name = "cmbUsuario"
      Me.cmbUsuario.Size = New System.Drawing.Size(148, 21)
      Me.cmbUsuario.TabIndex = 27
      '
      'lblCaja
      '
      Me.lblCaja.AutoSize = True
      Me.lblCaja.LabelAsoc = Nothing
      Me.lblCaja.Location = New System.Drawing.Point(13, 23)
      Me.lblCaja.Name = "lblCaja"
      Me.lblCaja.Size = New System.Drawing.Size(28, 13)
      Me.lblCaja.TabIndex = 1
      Me.lblCaja.Text = "Caja"
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
      Me.cmbCajas.Location = New System.Drawing.Point(45, 19)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
      Me.cmbCajas.TabIndex = 0
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
      Me.chbVendedor.Location = New System.Drawing.Point(540, 96)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 24
      Me.chbVendedor.Text = "Vendedor"
      Me.chbVendedor.UseVisualStyleBackColor = True
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
      Me.cmbVendedor.Location = New System.Drawing.Point(618, 94)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(162, 21)
      Me.cmbVendedor.TabIndex = 25
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
      Me.cmbGrabanLibro.Location = New System.Drawing.Point(425, 94)
      Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
      Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
      Me.cmbGrabanLibro.TabIndex = 23
      Me.cmbGrabanLibro.TabStop = False
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.LabelAsoc = Nothing
      Me.Label4.Location = New System.Drawing.Point(351, 98)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(68, 13)
      Me.Label4.TabIndex = 22
      Me.Label4.Text = "Graban Libro"
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
      Me.bscCodigoCliente.Location = New System.Drawing.Point(77, 60)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 14
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(74, 45)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 15
      Me.lblCodigoCliente.Text = "Código"
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
      Me.bscCliente.Location = New System.Drawing.Point(174, 60)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(300, 23)
      Me.bscCliente.TabIndex = 16
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(171, 45)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 17
      Me.lblNombre.Text = "Nombre"
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
      Me.cmbTiposComprobantes.LabelAsoc = Nothing
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(130, 94)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(196, 21)
      Me.cmbTiposComprobantes.TabIndex = 21
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(934, 41)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 28
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Me.chbCliente.Location = New System.Drawing.Point(13, 65)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 11
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
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
      Me.chbTipoComprobante.Location = New System.Drawing.Point(13, 96)
      Me.chbTipoComprobante.Name = "chbTipoComprobante"
      Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
      Me.chbTipoComprobante.TabIndex = 20
      Me.chbTipoComprobante.Text = "Tipo Comprobante"
      Me.chbTipoComprobante.UseVisualStyleBackColor = True
      '
      'chkPorFecha
      '
      Me.chkPorFecha.AutoSize = True
      Me.chkPorFecha.BindearPropiedadControl = Nothing
      Me.chkPorFecha.BindearPropiedadEntidad = Nothing
      Me.chkPorFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.chkPorFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkPorFecha.IsPK = False
      Me.chkPorFecha.IsRequired = False
      Me.chkPorFecha.Key = Nothing
      Me.chkPorFecha.LabelAsoc = Nothing
      Me.chkPorFecha.Location = New System.Drawing.Point(526, 21)
      Me.chkPorFecha.Name = "chkPorFecha"
      Me.chkPorFecha.Size = New System.Drawing.Size(54, 17)
      Me.chkPorFecha.TabIndex = 6
      Me.chkPorFecha.Text = "Venta"
      Me.chkPorFecha.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHasta.Enabled = False
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(799, 19)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 10
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(760, 23)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 9
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.Enabled = False
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(627, 19)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 8
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(585, 23)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 7
      Me.lblDesde.Text = "Desde"
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ver, Me.IdCliente, Me.CodigoCliente, Me.DescripcionAbrev, Me.NombreCategoriaFiscal, Me.TipoImpresora, Me.IdImpresora, Me.IdSucursal, Me.IdVendedor, Me.IdTipoComprobante, Me.Letra, Me.CentroEmisor, Me.NroComprobante, Me.Fecha, Me.NombreCliente, Me.TipoDocCliente, Me.NroDocCliente, Me.NumeroPlanilla, Me.NumeroMovimiento, Me.Usuario, Me.ImporteTotal, Me.ImportePesos, Me.ImporteCheques, Me.ImporteTarjetas, Me.ImporteTickets, Me.IdEstadoComprobante, Me.ImporteBancos})
      DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle15
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 166)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 4
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(1052, 344)
      Me.dgvDetalle.TabIndex = 1
      '
      'Ver
      '
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.Ver.DefaultCellStyle = DataGridViewCellStyle2
      Me.Ver.HeaderText = "Ver"
      Me.Ver.Name = "Ver"
      Me.Ver.ReadOnly = True
      Me.Ver.Text = "Ver"
      Me.Ver.Width = 30
      '
      'IdCliente
      '
      Me.IdCliente.DataPropertyName = "IdCliente"
      Me.IdCliente.HeaderText = "IdCliente"
      Me.IdCliente.Name = "IdCliente"
      Me.IdCliente.ReadOnly = True
      Me.IdCliente.Visible = False
      '
      'CodigoCliente
      '
      Me.CodigoCliente.DataPropertyName = "CodigoCliente"
      Me.CodigoCliente.HeaderText = "CodigoCliente"
      Me.CodigoCliente.Name = "CodigoCliente"
      Me.CodigoCliente.ReadOnly = True
      Me.CodigoCliente.Visible = False
      '
      'DescripcionAbrev
      '
      Me.DescripcionAbrev.DataPropertyName = "DescripcionAbrev"
      Me.DescripcionAbrev.HeaderText = "Comprobante"
      Me.DescripcionAbrev.Name = "DescripcionAbrev"
      Me.DescripcionAbrev.ReadOnly = True
      Me.DescripcionAbrev.Width = 90
      '
      'NombreCategoriaFiscal
      '
      Me.NombreCategoriaFiscal.DataPropertyName = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscal.HeaderText = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscal.Name = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscal.ReadOnly = True
      Me.NombreCategoriaFiscal.Visible = False
      '
      'TipoImpresora
      '
      Me.TipoImpresora.DataPropertyName = "TipoImpresora"
      Me.TipoImpresora.HeaderText = "TipoImpresora"
      Me.TipoImpresora.Name = "TipoImpresora"
      Me.TipoImpresora.ReadOnly = True
      Me.TipoImpresora.Visible = False
      '
      'IdImpresora
      '
      Me.IdImpresora.DataPropertyName = "IdImpresora"
      Me.IdImpresora.HeaderText = "IdImpresora"
      Me.IdImpresora.Name = "IdImpresora"
      Me.IdImpresora.ReadOnly = True
      Me.IdImpresora.Visible = False
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.ReadOnly = True
      Me.IdSucursal.Visible = False
      '
      'IdVendedor
      '
      Me.IdVendedor.DataPropertyName = "IdVendedor"
      Me.IdVendedor.HeaderText = "IdVendedor"
      Me.IdVendedor.Name = "IdVendedor"
      Me.IdVendedor.ReadOnly = True
      Me.IdVendedor.Visible = False
      '
      'IdTipoComprobante
      '
      Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
      Me.IdTipoComprobante.HeaderText = "Comprobante"
      Me.IdTipoComprobante.Name = "IdTipoComprobante"
      Me.IdTipoComprobante.ReadOnly = True
      Me.IdTipoComprobante.Visible = False
      Me.IdTipoComprobante.Width = 80
      '
      'Letra
      '
      Me.Letra.DataPropertyName = "Letra"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Letra.DefaultCellStyle = DataGridViewCellStyle3
      Me.Letra.HeaderText = "Letra"
      Me.Letra.Name = "Letra"
      Me.Letra.ReadOnly = True
      Me.Letra.Width = 35
      '
      'CentroEmisor
      '
      Me.CentroEmisor.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle4
      Me.CentroEmisor.HeaderText = "Emisor"
      Me.CentroEmisor.Name = "CentroEmisor"
      Me.CentroEmisor.ReadOnly = True
      Me.CentroEmisor.Width = 40
      '
      'NroComprobante
      '
      Me.NroComprobante.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NroComprobante.DefaultCellStyle = DataGridViewCellStyle5
      Me.NroComprobante.HeaderText = "Numero"
      Me.NroComprobante.Name = "NroComprobante"
      Me.NroComprobante.ReadOnly = True
      Me.NroComprobante.Width = 70
      '
      'Fecha
      '
      Me.Fecha.DataPropertyName = "Fecha"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle6.Format = "dd/MM/yyyy HH:mm"
      DataGridViewCellStyle6.NullValue = Nothing
      Me.Fecha.DefaultCellStyle = DataGridViewCellStyle6
      Me.Fecha.HeaderText = "Fecha"
      Me.Fecha.Name = "Fecha"
      Me.Fecha.ReadOnly = True
      '
      'NombreCliente
      '
      Me.NombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.NombreCliente.DataPropertyName = "NombreCliente"
      Me.NombreCliente.HeaderText = "Cliente"
      Me.NombreCliente.Name = "NombreCliente"
      Me.NombreCliente.ReadOnly = True
      '
      'TipoDocCliente
      '
      Me.TipoDocCliente.DataPropertyName = "TipoDocCliente"
      Me.TipoDocCliente.HeaderText = "Tipo Doc."
      Me.TipoDocCliente.Name = "TipoDocCliente"
      Me.TipoDocCliente.ReadOnly = True
      Me.TipoDocCliente.Visible = False
      Me.TipoDocCliente.Width = 55
      '
      'NroDocCliente
      '
      Me.NroDocCliente.DataPropertyName = "NroDocCliente"
      Me.NroDocCliente.HeaderText = "Nro. Doc."
      Me.NroDocCliente.Name = "NroDocCliente"
      Me.NroDocCliente.ReadOnly = True
      Me.NroDocCliente.Visible = False
      Me.NroDocCliente.Width = 80
      '
      'NumeroPlanilla
      '
      Me.NumeroPlanilla.DataPropertyName = "NumeroPlanilla"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroPlanilla.DefaultCellStyle = DataGridViewCellStyle7
      Me.NumeroPlanilla.HeaderText = "Planilla"
      Me.NumeroPlanilla.Name = "NumeroPlanilla"
      Me.NumeroPlanilla.ReadOnly = True
      Me.NumeroPlanilla.Width = 50
      '
      'NumeroMovimiento
      '
      Me.NumeroMovimiento.DataPropertyName = "NumeroMovimiento"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroMovimiento.DefaultCellStyle = DataGridViewCellStyle8
      Me.NumeroMovimiento.HeaderText = "Movim."
      Me.NumeroMovimiento.Name = "NumeroMovimiento"
      Me.NumeroMovimiento.ReadOnly = True
      Me.NumeroMovimiento.Width = 40
      '
      'Usuario
      '
      Me.Usuario.DataPropertyName = "Usuario"
      Me.Usuario.HeaderText = "Usuario"
      Me.Usuario.Name = "Usuario"
      Me.Usuario.ReadOnly = True
      Me.Usuario.Width = 60
      '
      'ImporteTotal
      '
      Me.ImporteTotal.DataPropertyName = "ImporteTotal"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle9.Format = "N2"
      Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle9
      Me.ImporteTotal.HeaderText = "Total"
      Me.ImporteTotal.Name = "ImporteTotal"
      Me.ImporteTotal.ReadOnly = True
      Me.ImporteTotal.Width = 70
      '
      'ImportePesos
      '
      Me.ImportePesos.DataPropertyName = "ImportePesos"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle10.Format = "N2"
      Me.ImportePesos.DefaultCellStyle = DataGridViewCellStyle10
      Me.ImportePesos.HeaderText = "Importe Pesos"
      Me.ImportePesos.Name = "ImportePesos"
      Me.ImportePesos.ReadOnly = True
      Me.ImportePesos.Width = 70
      '
      'ImporteCheques
      '
      Me.ImporteCheques.DataPropertyName = "ImporteCheques"
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle11.Format = "N2"
      Me.ImporteCheques.DefaultCellStyle = DataGridViewCellStyle11
      Me.ImporteCheques.HeaderText = "Importe Cheques"
      Me.ImporteCheques.Name = "ImporteCheques"
      Me.ImporteCheques.ReadOnly = True
      Me.ImporteCheques.Width = 70
      '
      'ImporteTarjetas
      '
      Me.ImporteTarjetas.DataPropertyName = "ImporteTarjetas"
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle12.Format = "N2"
      Me.ImporteTarjetas.DefaultCellStyle = DataGridViewCellStyle12
      Me.ImporteTarjetas.HeaderText = "Importe Tarjetas"
      Me.ImporteTarjetas.Name = "ImporteTarjetas"
      Me.ImporteTarjetas.ReadOnly = True
      Me.ImporteTarjetas.Width = 70
      '
      'ImporteTickets
      '
      Me.ImporteTickets.DataPropertyName = "ImporteTickets"
      DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle13.Format = "N2"
      Me.ImporteTickets.DefaultCellStyle = DataGridViewCellStyle13
      Me.ImporteTickets.HeaderText = "Importe Tickets"
      Me.ImporteTickets.Name = "ImporteTickets"
      Me.ImporteTickets.ReadOnly = True
      Me.ImporteTickets.Width = 70
      '
      'IdEstadoComprobante
      '
      Me.IdEstadoComprobante.DataPropertyName = "IdEstadoComprobante"
      Me.IdEstadoComprobante.HeaderText = "IdEstadoComprobante"
      Me.IdEstadoComprobante.Name = "IdEstadoComprobante"
      Me.IdEstadoComprobante.ReadOnly = True
      Me.IdEstadoComprobante.Visible = False
      '
      'ImporteBancos
      '
      Me.ImporteBancos.DataPropertyName = "ImporteTransfBancaria"
      DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle14.Format = "N2"
      Me.ImporteBancos.DefaultCellStyle = DataGridViewCellStyle14
      Me.ImporteBancos.HeaderText = "Importe Bancos"
      Me.ImporteBancos.Name = "ImporteBancos"
      Me.ImporteBancos.ReadOnly = True
      Me.ImporteBancos.Width = 70
      '
      'ConsultarVentasPorPlanilla
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1077, 559)
      Me.Controls.Add(Me.txtImporteBancos)
      Me.Controls.Add(Me.txtImportePesos)
      Me.Controls.Add(Me.txtTotal)
      Me.Controls.Add(Me.txtImporteCheques)
      Me.Controls.Add(Me.lblTotales)
      Me.Controls.Add(Me.txtImporteTickets)
      Me.Controls.Add(Me.txtImporteTarjetas)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ConsultarVentasPorPlanilla"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultar Ventas por Planillas"
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents chkPorFecha As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents txtImporteCheques As Eniac.Controles.TextBox
   Friend WithEvents lblTotales As Eniac.Controles.Label
   Friend WithEvents txtImporteTickets As Eniac.Controles.TextBox
   Friend WithEvents txtImporteTarjetas As Eniac.Controles.TextBox
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents txtImportePesos As Eniac.Controles.TextBox
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents lblNroPlanillaDesde As Eniac.Controles.Label
   Friend WithEvents lblNroPlanillaHasta As Eniac.Controles.Label
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents txtNroPlanillaHasta As Eniac.Controles.TextBox
   Friend WithEvents txtNroPlanillaDesde As Eniac.Controles.TextBox
   Friend WithEvents txtImporteBancos As Eniac.Controles.TextBox
   Friend WithEvents Ver As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodigoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescripcionAbrev As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoImpresora As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdImpresora As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdVendedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImportePesos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteCheques As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTarjetas As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTickets As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdEstadoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteBancos As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
