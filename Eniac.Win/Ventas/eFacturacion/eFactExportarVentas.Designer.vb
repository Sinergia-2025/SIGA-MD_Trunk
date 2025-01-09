<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class eFactExportarVentas
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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(eFactExportarVentas))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.grbPendientes = New System.Windows.Forms.GroupBox
      Me.btnBuscarDestino = New Eniac.Controles.Button
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.txtArchivoDestino = New Eniac.Controles.TextBox
      Me.lblArchivoDestino = New Eniac.Controles.Label
      Me.tstBarra = New System.Windows.Forms.ToolStrip
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbExportar = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel
      Me.prbExportando = New System.Windows.Forms.ProgressBar
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.chkMesCompleto = New Eniac.Controles.CheckBox
      Me.dtpHasta = New Eniac.Controles.DateTimePicker
      Me.lblHasta = New Eniac.Controles.Label
      Me.dtpDesde = New Eniac.Controles.DateTimePicker
      Me.lblDesde = New Eniac.Controles.Label
      Me.btnConsultar = New Eniac.Controles.Button
      Me.dgvDetalle = New Eniac.Controles.DataGridView
      Me.fbdBase = New System.Windows.Forms.FolderBrowserDialog
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.TipoDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.IdTipoDocumentoFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.NroDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ImporteExento = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ImporteNeto = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ImportePercepcion = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.grbPendientes.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbPendientes
      '
      Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPendientes.Controls.Add(Me.btnBuscarDestino)
      Me.grbPendientes.Controls.Add(Me.txtArchivoDestino)
      Me.grbPendientes.Controls.Add(Me.lblArchivoDestino)
      Me.grbPendientes.Location = New System.Drawing.Point(12, 434)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(895, 57)
      Me.grbPendientes.TabIndex = 4
      Me.grbPendientes.TabStop = False
      '
      'btnBuscarDestino
      '
      Me.btnBuscarDestino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnBuscarDestino.ImageKey = "folder.ico"
      Me.btnBuscarDestino.ImageList = Me.imgGrabar
      Me.btnBuscarDestino.Location = New System.Drawing.Point(530, 13)
      Me.btnBuscarDestino.Name = "btnBuscarDestino"
      Me.btnBuscarDestino.Size = New System.Drawing.Size(93, 40)
      Me.btnBuscarDestino.TabIndex = 2
      Me.btnBuscarDestino.Text = "&Examinar..."
      Me.btnBuscarDestino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnBuscarDestino.UseVisualStyleBackColor = True
      '
      'imgGrabar
      '
      Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
      Me.imgGrabar.Images.SetKeyName(0, "document_find.ico")
      Me.imgGrabar.Images.SetKeyName(1, "folder.ico")
      Me.imgGrabar.Images.SetKeyName(2, "row_add.ico")
      '
      'txtArchivoDestino
      '
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
      Me.txtArchivoDestino.Location = New System.Drawing.Point(108, 25)
      Me.txtArchivoDestino.Name = "txtArchivoDestino"
      Me.txtArchivoDestino.Size = New System.Drawing.Size(416, 20)
      Me.txtArchivoDestino.TabIndex = 1
      '
      'lblArchivoDestino
      '
      Me.lblArchivoDestino.AutoSize = True
      Me.lblArchivoDestino.Location = New System.Drawing.Point(21, 27)
      Me.lblArchivoDestino.Name = "lblArchivoDestino"
      Me.lblArchivoDestino.Size = New System.Drawing.Size(85, 13)
      Me.lblArchivoDestino.TabIndex = 0
      Me.lblArchivoDestino.Text = "Archivo Destino:"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbExportar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(918, 29)
      Me.tstBarra.TabIndex = 0
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(103, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbExportar
      '
      Me.tsbExportar.Image = CType(resources.GetObject("tsbExportar.Image"), System.Drawing.Image)
      Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbExportar.Name = "tsbExportar"
      Me.tsbExportar.Size = New System.Drawing.Size(75, 26)
      Me.tsbExportar.Text = "&Exportar"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(64, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 500)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(918, 22)
      Me.StatusStrip1.TabIndex = 5
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(903, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'prbExportando
      '
      Me.prbExportando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.prbExportando.Location = New System.Drawing.Point(12, 410)
      Me.prbExportando.Name = "prbExportando"
      Me.prbExportando.Size = New System.Drawing.Size(894, 23)
      Me.prbExportando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.prbExportando.TabIndex = 3
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.chkMesCompleto)
      Me.GroupBox1.Controls.Add(Me.dtpHasta)
      Me.GroupBox1.Controls.Add(Me.dtpDesde)
      Me.GroupBox1.Controls.Add(Me.lblHasta)
      Me.GroupBox1.Controls.Add(Me.lblDesde)
      Me.GroupBox1.Controls.Add(Me.btnConsultar)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 25)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(895, 66)
      Me.GroupBox1.TabIndex = 1
      Me.GroupBox1.TabStop = False
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(24, 29)
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
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(345, 27)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(116, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(308, 31)
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
      Me.dtpDesde.Location = New System.Drawing.Point(165, 27)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(116, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Location = New System.Drawing.Point(121, 31)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(761, 15)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(111, 45)
      Me.btnConsultar.TabIndex = 5
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTipoComprobante, Me.Descripcion, Me.Letra, Me.CentroEmisor, Me.NumeroComprobante, Me.Fecha, Me.TipoDocCliente, Me.IdTipoDocumentoFiscal, Me.NroDocCliente, Me.NombreCliente, Me.ImporteExento, Me.ImporteNeto, Me.IVA, Me.ImportePercepcion, Me.ImporteTotal})
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle11
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(13, 97)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 4
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(893, 307)
      Me.dgvDetalle.TabIndex = 2
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
      'Descripcion
      '
      Me.Descripcion.DataPropertyName = "Descripcion"
      Me.Descripcion.HeaderText = "Comprobante"
      Me.Descripcion.Name = "Descripcion"
      Me.Descripcion.ReadOnly = True
      Me.Descripcion.Width = 75
      '
      'Letra
      '
      Me.Letra.DataPropertyName = "Letra"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
      Me.Letra.HeaderText = "Let."
      Me.Letra.Name = "Letra"
      Me.Letra.ReadOnly = True
      Me.Letra.Width = 30
      '
      'CentroEmisor
      '
      Me.CentroEmisor.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CentroEmisor.DefaultCellStyle = DataGridViewCellStyle3
      Me.CentroEmisor.HeaderText = "Emisor"
      Me.CentroEmisor.Name = "CentroEmisor"
      Me.CentroEmisor.ReadOnly = True
      Me.CentroEmisor.Width = 40
      '
      'NumeroComprobante
      '
      Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroComprobante.DefaultCellStyle = DataGridViewCellStyle4
      Me.NumeroComprobante.HeaderText = "Numero"
      Me.NumeroComprobante.Name = "NumeroComprobante"
      Me.NumeroComprobante.ReadOnly = True
      Me.NumeroComprobante.Width = 60
      '
      'Fecha
      '
      Me.Fecha.DataPropertyName = "Fecha"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle5.Format = "dd/MM/yyyy HH:mm"
      DataGridViewCellStyle5.NullValue = Nothing
      Me.Fecha.DefaultCellStyle = DataGridViewCellStyle5
      Me.Fecha.HeaderText = "Fecha"
      Me.Fecha.Name = "Fecha"
      Me.Fecha.ReadOnly = True
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
      'IdTipoDocumentoFiscal
      '
      Me.IdTipoDocumentoFiscal.DataPropertyName = "IdTipoDocumentoFiscal"
      Me.IdTipoDocumentoFiscal.HeaderText = "IdTipoDocumentoFiscal"
      Me.IdTipoDocumentoFiscal.Name = "IdTipoDocumentoFiscal"
      Me.IdTipoDocumentoFiscal.ReadOnly = True
      Me.IdTipoDocumentoFiscal.Visible = False
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
      'NombreCliente
      '
      Me.NombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.NombreCliente.DataPropertyName = "NombreCliente"
      Me.NombreCliente.HeaderText = "Cliente"
      Me.NombreCliente.Name = "NombreCliente"
      Me.NombreCliente.ReadOnly = True
      '
      'ImporteExento
      '
      Me.ImporteExento.DataPropertyName = "ImporteExento"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle6.Format = "N2"
      Me.ImporteExento.DefaultCellStyle = DataGridViewCellStyle6
      Me.ImporteExento.HeaderText = "Exento"
      Me.ImporteExento.Name = "ImporteExento"
      Me.ImporteExento.ReadOnly = True
      Me.ImporteExento.Width = 70
      '
      'ImporteNeto
      '
      Me.ImporteNeto.DataPropertyName = "ImporteNeto"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "N2"
      DataGridViewCellStyle7.NullValue = Nothing
      Me.ImporteNeto.DefaultCellStyle = DataGridViewCellStyle7
      Me.ImporteNeto.HeaderText = "Neto"
      Me.ImporteNeto.Name = "ImporteNeto"
      Me.ImporteNeto.ReadOnly = True
      Me.ImporteNeto.Width = 70
      '
      'IVA
      '
      Me.IVA.DataPropertyName = "IVA"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "N2"
      Me.IVA.DefaultCellStyle = DataGridViewCellStyle8
      Me.IVA.HeaderText = "IVA"
      Me.IVA.Name = "IVA"
      Me.IVA.ReadOnly = True
      Me.IVA.Width = 70
      '
      'ImportePercepcion
      '
      Me.ImportePercepcion.DataPropertyName = "ImportePercepcion"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle9.Format = "N2"
      Me.ImportePercepcion.DefaultCellStyle = DataGridViewCellStyle9
      Me.ImportePercepcion.HeaderText = "Percepcion"
      Me.ImportePercepcion.Name = "ImportePercepcion"
      Me.ImportePercepcion.ReadOnly = True
      Me.ImportePercepcion.Width = 70
      '
      'ImporteTotal
      '
      Me.ImporteTotal.DataPropertyName = "ImporteTotal"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle10.Format = "N2"
      Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle10
      Me.ImporteTotal.HeaderText = "Total"
      Me.ImporteTotal.Name = "ImporteTotal"
      Me.ImporteTotal.ReadOnly = True
      Me.ImporteTotal.Width = 70
      '
      'eFactExportarVentas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(918, 522)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.prbExportando)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbPendientes)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "eFactExportarVentas"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "eFact - Exportar Comprobantes de Ventas"
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblArchivoDestino As Eniac.Controles.Label
   Friend WithEvents txtArchivoDestino As Eniac.Controles.TextBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents prbExportando As System.Windows.Forms.ProgressBar
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents btnBuscarDestino As Eniac.Controles.Button
   Friend WithEvents fbdBase As System.Windows.Forms.FolderBrowserDialog
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoDocumentoFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteExento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteNeto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IVA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImportePercepcion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
