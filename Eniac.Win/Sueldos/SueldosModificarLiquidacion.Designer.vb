<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosModificarLiquidacion
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SueldosModificarLiquidacion))
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtLugarPago = New System.Windows.Forms.TextBox()
      Me.lblSueldosFechaPago = New Eniac.Controles.Label()
      Me.dtpSueldosFechaPago = New Eniac.Controles.DateTimePicker()
      Me.cmbNroLiquidacion = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbTipoRecibo = New Eniac.Controles.ComboBox()
      Me.lblTipoRecibo = New Eniac.Controles.Label()
      Me.cmbPeriodoLiquidacion = New Eniac.Controles.ComboBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbModificarLugaryFechaPago = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbSocio = New Eniac.Controles.CheckBox()
      Me.bscNroLegajo = New Eniac.Controles.Buscador()
      Me.lblNroDocumento = New Eniac.Controles.Label()
      Me.bscNombrePersonal = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lbPeriodo = New Eniac.Controles.Label()
      Me.DataSetSueldos = New Eniac.Win.DataSetSueldos()
      Me.RecibosImpresosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      CType(Me.DataSetSueldos, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RecibosImpresosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "find.ico")
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(19, 36)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(77, 13)
      Me.Label2.TabIndex = 66
      Me.Label2.Text = "Lugar de Pago"
      '
      'txtLugarPago
      '
      Me.txtLugarPago.Location = New System.Drawing.Point(119, 33)
      Me.txtLugarPago.MaxLength = 50
      Me.txtLugarPago.Name = "txtLugarPago"
      Me.txtLugarPago.Size = New System.Drawing.Size(209, 20)
      Me.txtLugarPago.TabIndex = 65
      '
      'lblSueldosFechaPago
      '
      Me.lblSueldosFechaPago.AutoSize = True
      Me.lblSueldosFechaPago.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSueldosFechaPago.Location = New System.Drawing.Point(364, 37)
      Me.lblSueldosFechaPago.Name = "lblSueldosFechaPago"
      Me.lblSueldosFechaPago.Size = New System.Drawing.Size(80, 13)
      Me.lblSueldosFechaPago.TabIndex = 64
      Me.lblSueldosFechaPago.Text = "Fecha de Pago"
      '
      'dtpSueldosFechaPago
      '
      Me.dtpSueldosFechaPago.BindearPropiedadControl = "Value"
      Me.dtpSueldosFechaPago.BindearPropiedadEntidad = "FechaNacimiento"
      Me.dtpSueldosFechaPago.CustomFormat = "dd/MM/yyyy"
      Me.dtpSueldosFechaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpSueldosFechaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpSueldosFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpSueldosFechaPago.IsPK = False
      Me.dtpSueldosFechaPago.IsRequired = False
      Me.dtpSueldosFechaPago.Key = ""
      Me.dtpSueldosFechaPago.LabelAsoc = Nothing
      Me.dtpSueldosFechaPago.Location = New System.Drawing.Point(450, 33)
      Me.dtpSueldosFechaPago.Name = "dtpSueldosFechaPago"
      Me.dtpSueldosFechaPago.Size = New System.Drawing.Size(85, 20)
      Me.dtpSueldosFechaPago.TabIndex = 63
      Me.dtpSueldosFechaPago.Tag = "SUELDOS_FECHA_DE_PAGO"
      '
      'cmbNroLiquidacion
      '
      Me.cmbNroLiquidacion.BindearPropiedadControl = "SelectedValue"
      Me.cmbNroLiquidacion.BindearPropiedadEntidad = "IdTipoConcepto"
      Me.cmbNroLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNroLiquidacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNroLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNroLiquidacion.FormattingEnabled = True
      Me.cmbNroLiquidacion.IsPK = False
      Me.cmbNroLiquidacion.IsRequired = True
      Me.cmbNroLiquidacion.Key = Nothing
      Me.cmbNroLiquidacion.LabelAsoc = Nothing
      Me.cmbNroLiquidacion.Location = New System.Drawing.Point(526, 25)
      Me.cmbNroLiquidacion.Name = "cmbNroLiquidacion"
      Me.cmbNroLiquidacion.Size = New System.Drawing.Size(43, 21)
      Me.cmbNroLiquidacion.TabIndex = 62
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(442, 30)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(81, 13)
      Me.Label1.TabIndex = 61
      Me.Label1.Text = "Nro Liquidación"
      '
      'cmbTipoRecibo
      '
      Me.cmbTipoRecibo.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoRecibo.BindearPropiedadEntidad = "IdTipoConcepto"
      Me.cmbTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoRecibo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoRecibo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoRecibo.FormattingEnabled = True
      Me.cmbTipoRecibo.IsPK = False
      Me.cmbTipoRecibo.IsRequired = True
      Me.cmbTipoRecibo.Key = Nothing
      Me.cmbTipoRecibo.LabelAsoc = Me.lblTipoRecibo
      Me.cmbTipoRecibo.Location = New System.Drawing.Point(296, 25)
      Me.cmbTipoRecibo.Name = "cmbTipoRecibo"
      Me.cmbTipoRecibo.Size = New System.Drawing.Size(126, 21)
      Me.cmbTipoRecibo.TabIndex = 59
      '
      'lblTipoRecibo
      '
      Me.lblTipoRecibo.AutoSize = True
      Me.lblTipoRecibo.Location = New System.Drawing.Point(213, 30)
      Me.lblTipoRecibo.Name = "lblTipoRecibo"
      Me.lblTipoRecibo.Size = New System.Drawing.Size(80, 13)
      Me.lblTipoRecibo.TabIndex = 60
      Me.lblTipoRecibo.Text = "Tipo de Recibo"
      '
      'cmbPeriodoLiquidacion
      '
      Me.cmbPeriodoLiquidacion.BindearPropiedadControl = "SelectedValue"
      Me.cmbPeriodoLiquidacion.BindearPropiedadEntidad = "IdTipoConcepto"
      Me.cmbPeriodoLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPeriodoLiquidacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPeriodoLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPeriodoLiquidacion.FormattingEnabled = True
      Me.cmbPeriodoLiquidacion.IsPK = False
      Me.cmbPeriodoLiquidacion.IsRequired = True
      Me.cmbPeriodoLiquidacion.Key = Nothing
      Me.cmbPeriodoLiquidacion.LabelAsoc = Nothing
      Me.cmbPeriodoLiquidacion.Location = New System.Drawing.Point(116, 25)
      Me.cmbPeriodoLiquidacion.Name = "cmbPeriodoLiquidacion"
      Me.cmbPeriodoLiquidacion.Size = New System.Drawing.Size(90, 21)
      Me.cmbPeriodoLiquidacion.TabIndex = 58
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra})
      Me.stsStado.Location = New System.Drawing.Point(0, 243)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(618, 22)
      Me.stsStado.TabIndex = 13
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(603, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbModificarLugaryFechaPago, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(618, 29)
      Me.tstBarra.TabIndex = 12
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
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
      'tsbModificarLugaryFechaPago
      '
      Me.tsbModificarLugaryFechaPago.Image = Global.Eniac.Win.My.Resources.Resources.date_time
      Me.tsbModificarLugaryFechaPago.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbModificarLugaryFechaPago.Name = "tsbModificarLugaryFechaPago"
      Me.tsbModificarLugaryFechaPago.Size = New System.Drawing.Size(117, 26)
      Me.tsbModificarLugaryFechaPago.Text = "Modificar Datos"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.chbSocio)
      Me.grbFiltros.Controls.Add(Me.bscNroLegajo)
      Me.grbFiltros.Controls.Add(Me.cmbNroLiquidacion)
      Me.grbFiltros.Controls.Add(Me.bscNombrePersonal)
      Me.grbFiltros.Controls.Add(Me.Label1)
      Me.grbFiltros.Controls.Add(Me.lblNroDocumento)
      Me.grbFiltros.Controls.Add(Me.cmbTipoRecibo)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.lblTipoRecibo)
      Me.grbFiltros.Controls.Add(Me.cmbPeriodoLiquidacion)
      Me.grbFiltros.Controls.Add(Me.lbPeriodo)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(594, 115)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'chbSocio
      '
      Me.chbSocio.AutoSize = True
      Me.chbSocio.BindearPropiedadControl = Nothing
      Me.chbSocio.BindearPropiedadEntidad = Nothing
      Me.chbSocio.ForeColorFocus = System.Drawing.Color.Red
      Me.chbSocio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbSocio.IsPK = False
      Me.chbSocio.IsRequired = False
      Me.chbSocio.Key = Nothing
      Me.chbSocio.LabelAsoc = Nothing
      Me.chbSocio.Location = New System.Drawing.Point(15, 76)
      Me.chbSocio.Name = "chbSocio"
      Me.chbSocio.Size = New System.Drawing.Size(97, 17)
      Me.chbSocio.TabIndex = 50
      Me.chbSocio.Text = "Un solo Legajo"
      Me.chbSocio.UseVisualStyleBackColor = True
      '
      'bscNroLegajo
      '
      Me.bscNroLegajo.AyudaAncho = 608
      Me.bscNroLegajo.BindearPropiedadControl = Nothing
      Me.bscNroLegajo.BindearPropiedadEntidad = Nothing
      Me.bscNroLegajo.ColumnasAlineacion = Nothing
      Me.bscNroLegajo.ColumnasAncho = Nothing
      Me.bscNroLegajo.ColumnasFormato = Nothing
      Me.bscNroLegajo.ColumnasOcultas = Nothing
      Me.bscNroLegajo.ColumnasTitulos = Nothing
      Me.bscNroLegajo.Datos = Nothing
      Me.bscNroLegajo.Enabled = False
      Me.bscNroLegajo.FilaDevuelta = Nothing
      Me.bscNroLegajo.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNroLegajo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNroLegajo.IsDecimal = False
      Me.bscNroLegajo.IsNumber = True
      Me.bscNroLegajo.IsPK = False
      Me.bscNroLegajo.IsRequired = False
      Me.bscNroLegajo.Key = ""
      Me.bscNroLegajo.LabelAsoc = Me.lblNroDocumento
      Me.bscNroLegajo.Location = New System.Drawing.Point(122, 76)
      Me.bscNroLegajo.MaxLengh = "32767"
      Me.bscNroLegajo.Name = "bscNroLegajo"
      Me.bscNroLegajo.Permitido = True
      Me.bscNroLegajo.Selecciono = False
      Me.bscNroLegajo.Size = New System.Drawing.Size(131, 23)
      Me.bscNroLegajo.TabIndex = 54
      Me.bscNroLegajo.Titulo = Nothing
      '
      'lblNroDocumento
      '
      Me.lblNroDocumento.AutoSize = True
      Me.lblNroDocumento.Location = New System.Drawing.Point(119, 60)
      Me.lblNroDocumento.Name = "lblNroDocumento"
      Me.lblNroDocumento.Size = New System.Drawing.Size(62, 13)
      Me.lblNroDocumento.TabIndex = 53
      Me.lblNroDocumento.Text = "Nro. Legajo"
      '
      'bscNombrePersonal
      '
      Me.bscNombrePersonal.AutoSize = True
      Me.bscNombrePersonal.AyudaAncho = 608
      Me.bscNombrePersonal.BindearPropiedadControl = Nothing
      Me.bscNombrePersonal.BindearPropiedadEntidad = Nothing
      Me.bscNombrePersonal.ColumnasAlineacion = Nothing
      Me.bscNombrePersonal.ColumnasAncho = Nothing
      Me.bscNombrePersonal.ColumnasFormato = Nothing
      Me.bscNombrePersonal.ColumnasOcultas = Nothing
      Me.bscNombrePersonal.ColumnasTitulos = Nothing
      Me.bscNombrePersonal.Datos = Nothing
      Me.bscNombrePersonal.Enabled = False
      Me.bscNombrePersonal.FilaDevuelta = Nothing
      Me.bscNombrePersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombrePersonal.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombrePersonal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombrePersonal.IsDecimal = False
      Me.bscNombrePersonal.IsNumber = False
      Me.bscNombrePersonal.IsPK = False
      Me.bscNombrePersonal.IsRequired = False
      Me.bscNombrePersonal.Key = ""
      Me.bscNombrePersonal.LabelAsoc = Me.lblNombre
      Me.bscNombrePersonal.Location = New System.Drawing.Point(262, 76)
      Me.bscNombrePersonal.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombrePersonal.MaxLengh = "32767"
      Me.bscNombrePersonal.Name = "bscNombrePersonal"
      Me.bscNombrePersonal.Permitido = True
      Me.bscNombrePersonal.Selecciono = False
      Me.bscNombrePersonal.Size = New System.Drawing.Size(307, 23)
      Me.bscNombrePersonal.TabIndex = 56
      Me.bscNombrePersonal.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(262, 60)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 55
      Me.lblNombre.Text = "Nombre"
      '
      'lbPeriodo
      '
      Me.lbPeriodo.AutoSize = True
      Me.lbPeriodo.Location = New System.Drawing.Point(13, 30)
      Me.lbPeriodo.Name = "lbPeriodo"
      Me.lbPeriodo.Size = New System.Drawing.Size(100, 13)
      Me.lbPeriodo.TabIndex = 48
      Me.lbPeriodo.Text = "Periodo Liquidación"
      '
      'DataSetSueldos
      '
      Me.DataSetSueldos.DataSetName = "DataSetSueldos"
      Me.DataSetSueldos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'RecibosImpresosBindingSource
      '
      Me.RecibosImpresosBindingSource.DataMember = "RecibosImpresos"
      Me.RecibosImpresosBindingSource.DataSource = Me.DataSetSueldos
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.txtLugarPago)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.dtpSueldosFechaPago)
      Me.GroupBox1.Controls.Add(Me.lblSueldosFechaPago)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 156)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(594, 78)
      Me.GroupBox1.TabIndex = 67
      Me.GroupBox1.TabStop = False
      '
      'SueldosModificarLiquidacion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(618, 265)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SueldosModificarLiquidacion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Modificar Datos de Liquidación"
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      CType(Me.DataSetSueldos, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RecibosImpresosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents lbPeriodo As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents RecibosImpresosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents DataSetSueldos As Eniac.Win.DataSetSueldos
   Friend WithEvents chbSocio As Eniac.Controles.CheckBox
   Friend WithEvents bscNroLegajo As Eniac.Controles.Buscador
   Friend WithEvents lblNroDocumento As Eniac.Controles.Label
   Friend WithEvents bscNombrePersonal As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents PeriodoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DireccionCobroDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreLocalidadDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCobradorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteCuotaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaExtraDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Periodo2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocSocio2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreSocio2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DireccionCobro2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreLocalidad2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaSocio2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCobrador2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteCuota2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaExtra2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cmbPeriodoLiquidacion As Eniac.Controles.ComboBox
   Friend WithEvents cmbTipoRecibo As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoRecibo As Eniac.Controles.Label
   Friend WithEvents cmbNroLiquidacion As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents tsbModificarLugaryFechaPago As System.Windows.Forms.ToolStripButton
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtLugarPago As System.Windows.Forms.TextBox
   Friend WithEvents lblSueldosFechaPago As Eniac.Controles.Label
   Friend WithEvents dtpSueldosFechaPago As Eniac.Controles.DateTimePicker
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
