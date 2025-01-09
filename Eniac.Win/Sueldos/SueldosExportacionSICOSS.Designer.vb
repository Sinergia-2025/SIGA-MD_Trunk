<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosExportacionSICOSS
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SueldosExportacionSICOSS))
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.ProcesoDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.LineaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobanteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescripcionAbrevDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.LetraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroComprobanteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocClienteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocClienteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreClienteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCategoriaFiscalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CUITDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteBrutoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NetoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Percepciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImpuestoInterno = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdAFIPTipoComprobanteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdAFIPTipoDocumentoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.AlicuotaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CantidadDeAlicuotasDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.EstaAnuladaDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.colError = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CitiVentasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DsAFIP = New Eniac.Win.dsAFIP()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.dtpPeriodoFiscal = New Eniac.Controles.DateTimePicker()
      Me.lblPeriodoFiscal = New Eniac.Controles.Label()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.btnArchivo = New Eniac.Controles.Button()
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.txtArchivoDestino = New Eniac.Controles.TextBox()
      Me.lblArchivoDestino = New Eniac.Controles.Label()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbVerRegistrosConErrores = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TbpComprobantes = New System.Windows.Forms.TabPage()
      Me.CitiVentasAlicuotasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.CitiVentasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DsAFIP, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbFiltros.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TbpComprobantes.SuspendLayout()
      CType(Me.CitiVentasAlicuotasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.AllowUserToResizeColumns = False
      Me.dgvDetalle.AllowUserToResizeRows = False
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvDetalle.AutoGenerateColumns = False
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProcesoDataGridViewCheckBoxColumn, Me.LineaDataGridViewTextBoxColumn, Me.IdTipoComprobanteDataGridViewTextBoxColumn, Me.DescripcionAbrevDataGridViewTextBoxColumn, Me.LetraDataGridViewTextBoxColumn, Me.CentroEmisorDataGridViewTextBoxColumn, Me.NumeroComprobanteDataGridViewTextBoxColumn, Me.FechaDataGridViewTextBoxColumn, Me.TipoDocClienteDataGridViewTextBoxColumn, Me.NroDocClienteDataGridViewTextBoxColumn, Me.NombreClienteDataGridViewTextBoxColumn, Me.NombreCategoriaFiscalDataGridViewTextBoxColumn, Me.CUITDataGridViewTextBoxColumn, Me.ImporteBrutoDataGridViewTextBoxColumn, Me.NetoDataGridViewTextBoxColumn, Me.ImporteDataGridViewTextBoxColumn, Me.Percepciones, Me.ImpuestoInterno, Me.TotalDataGridViewTextBoxColumn, Me.IdAFIPTipoComprobanteDataGridViewTextBoxColumn, Me.IdAFIPTipoDocumentoDataGridViewTextBoxColumn, Me.AlicuotaDataGridViewTextBoxColumn, Me.CantidadDeAlicuotasDataGridViewTextBoxColumn, Me.EstaAnuladaDataGridViewCheckBoxColumn, Me.colError})
      Me.dgvDetalle.DataSource = Me.CitiVentasBindingSource
      DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle15
      Me.dgvDetalle.Location = New System.Drawing.Point(3, 6)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
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
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(852, 292)
      Me.dgvDetalle.TabIndex = 1
      '
      'ProcesoDataGridViewCheckBoxColumn
      '
      Me.ProcesoDataGridViewCheckBoxColumn.DataPropertyName = "Proceso"
      Me.ProcesoDataGridViewCheckBoxColumn.FalseValue = "False"
      Me.ProcesoDataGridViewCheckBoxColumn.HeaderText = "Procesar"
      Me.ProcesoDataGridViewCheckBoxColumn.Name = "ProcesoDataGridViewCheckBoxColumn"
      Me.ProcesoDataGridViewCheckBoxColumn.TrueValue = "True"
      Me.ProcesoDataGridViewCheckBoxColumn.Width = 55
      '
      'LineaDataGridViewTextBoxColumn
      '
      Me.LineaDataGridViewTextBoxColumn.DataPropertyName = "Linea"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.LineaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
      Me.LineaDataGridViewTextBoxColumn.HeaderText = "Linea"
      Me.LineaDataGridViewTextBoxColumn.Name = "LineaDataGridViewTextBoxColumn"
      Me.LineaDataGridViewTextBoxColumn.ReadOnly = True
      Me.LineaDataGridViewTextBoxColumn.Width = 45
      '
      'IdTipoComprobanteDataGridViewTextBoxColumn
      '
      Me.IdTipoComprobanteDataGridViewTextBoxColumn.DataPropertyName = "IdTipoComprobante"
      Me.IdTipoComprobanteDataGridViewTextBoxColumn.HeaderText = "IdTipoComprobante"
      Me.IdTipoComprobanteDataGridViewTextBoxColumn.Name = "IdTipoComprobanteDataGridViewTextBoxColumn"
      Me.IdTipoComprobanteDataGridViewTextBoxColumn.ReadOnly = True
      Me.IdTipoComprobanteDataGridViewTextBoxColumn.Visible = False
      '
      'DescripcionAbrevDataGridViewTextBoxColumn
      '
      Me.DescripcionAbrevDataGridViewTextBoxColumn.DataPropertyName = "DescripcionAbrev"
      Me.DescripcionAbrevDataGridViewTextBoxColumn.HeaderText = "Comprobante"
      Me.DescripcionAbrevDataGridViewTextBoxColumn.Name = "DescripcionAbrevDataGridViewTextBoxColumn"
      Me.DescripcionAbrevDataGridViewTextBoxColumn.ReadOnly = True
      Me.DescripcionAbrevDataGridViewTextBoxColumn.Width = 80
      '
      'LetraDataGridViewTextBoxColumn
      '
      Me.LetraDataGridViewTextBoxColumn.DataPropertyName = "Letra"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.LetraDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
      Me.LetraDataGridViewTextBoxColumn.FillWeight = 35.0!
      Me.LetraDataGridViewTextBoxColumn.HeaderText = "Letra"
      Me.LetraDataGridViewTextBoxColumn.Name = "LetraDataGridViewTextBoxColumn"
      Me.LetraDataGridViewTextBoxColumn.ReadOnly = True
      Me.LetraDataGridViewTextBoxColumn.Width = 40
      '
      'CentroEmisorDataGridViewTextBoxColumn
      '
      Me.CentroEmisorDataGridViewTextBoxColumn.DataPropertyName = "CentroEmisor"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CentroEmisorDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
      Me.CentroEmisorDataGridViewTextBoxColumn.FillWeight = 35.0!
      Me.CentroEmisorDataGridViewTextBoxColumn.HeaderText = "Emisor"
      Me.CentroEmisorDataGridViewTextBoxColumn.Name = "CentroEmisorDataGridViewTextBoxColumn"
      Me.CentroEmisorDataGridViewTextBoxColumn.ReadOnly = True
      Me.CentroEmisorDataGridViewTextBoxColumn.Width = 45
      '
      'NumeroComprobanteDataGridViewTextBoxColumn
      '
      Me.NumeroComprobanteDataGridViewTextBoxColumn.DataPropertyName = "NumeroComprobante"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.NumeroComprobanteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
      Me.NumeroComprobanteDataGridViewTextBoxColumn.HeaderText = "Nro. Comp."
      Me.NumeroComprobanteDataGridViewTextBoxColumn.Name = "NumeroComprobanteDataGridViewTextBoxColumn"
      Me.NumeroComprobanteDataGridViewTextBoxColumn.ReadOnly = True
      Me.NumeroComprobanteDataGridViewTextBoxColumn.Width = 90
      '
      'FechaDataGridViewTextBoxColumn
      '
      Me.FechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle6.Format = "d"
      DataGridViewCellStyle6.NullValue = Nothing
      Me.FechaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
      Me.FechaDataGridViewTextBoxColumn.HeaderText = "Fecha"
      Me.FechaDataGridViewTextBoxColumn.Name = "FechaDataGridViewTextBoxColumn"
      Me.FechaDataGridViewTextBoxColumn.ReadOnly = True
      Me.FechaDataGridViewTextBoxColumn.Width = 90
      '
      'TipoDocClienteDataGridViewTextBoxColumn
      '
      Me.TipoDocClienteDataGridViewTextBoxColumn.DataPropertyName = "TipoDocCliente"
      Me.TipoDocClienteDataGridViewTextBoxColumn.HeaderText = "Tipo Doc."
      Me.TipoDocClienteDataGridViewTextBoxColumn.Name = "TipoDocClienteDataGridViewTextBoxColumn"
      Me.TipoDocClienteDataGridViewTextBoxColumn.ReadOnly = True
      Me.TipoDocClienteDataGridViewTextBoxColumn.Width = 45
      '
      'NroDocClienteDataGridViewTextBoxColumn
      '
      Me.NroDocClienteDataGridViewTextBoxColumn.DataPropertyName = "NroDocCliente"
      Me.NroDocClienteDataGridViewTextBoxColumn.HeaderText = "Nro. Doc."
      Me.NroDocClienteDataGridViewTextBoxColumn.Name = "NroDocClienteDataGridViewTextBoxColumn"
      Me.NroDocClienteDataGridViewTextBoxColumn.ReadOnly = True
      Me.NroDocClienteDataGridViewTextBoxColumn.Width = 80
      '
      'NombreClienteDataGridViewTextBoxColumn
      '
      Me.NombreClienteDataGridViewTextBoxColumn.DataPropertyName = "NombreCliente"
      Me.NombreClienteDataGridViewTextBoxColumn.HeaderText = "Cliente"
      Me.NombreClienteDataGridViewTextBoxColumn.Name = "NombreClienteDataGridViewTextBoxColumn"
      Me.NombreClienteDataGridViewTextBoxColumn.ReadOnly = True
      Me.NombreClienteDataGridViewTextBoxColumn.Width = 180
      '
      'NombreCategoriaFiscalDataGridViewTextBoxColumn
      '
      Me.NombreCategoriaFiscalDataGridViewTextBoxColumn.DataPropertyName = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscalDataGridViewTextBoxColumn.HeaderText = "Categ. Fiscal"
      Me.NombreCategoriaFiscalDataGridViewTextBoxColumn.Name = "NombreCategoriaFiscalDataGridViewTextBoxColumn"
      Me.NombreCategoriaFiscalDataGridViewTextBoxColumn.ReadOnly = True
      '
      'CUITDataGridViewTextBoxColumn
      '
      Me.CUITDataGridViewTextBoxColumn.DataPropertyName = "CUIT"
      Me.CUITDataGridViewTextBoxColumn.HeaderText = "CUIT"
      Me.CUITDataGridViewTextBoxColumn.Name = "CUITDataGridViewTextBoxColumn"
      Me.CUITDataGridViewTextBoxColumn.ReadOnly = True
      Me.CUITDataGridViewTextBoxColumn.Width = 90
      '
      'ImporteBrutoDataGridViewTextBoxColumn
      '
      Me.ImporteBrutoDataGridViewTextBoxColumn.DataPropertyName = "ImporteBruto"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "N2"
      DataGridViewCellStyle7.NullValue = Nothing
      Me.ImporteBrutoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
      Me.ImporteBrutoDataGridViewTextBoxColumn.HeaderText = "Bruto"
      Me.ImporteBrutoDataGridViewTextBoxColumn.Name = "ImporteBrutoDataGridViewTextBoxColumn"
      Me.ImporteBrutoDataGridViewTextBoxColumn.ReadOnly = True
      Me.ImporteBrutoDataGridViewTextBoxColumn.Width = 80
      '
      'NetoDataGridViewTextBoxColumn
      '
      Me.NetoDataGridViewTextBoxColumn.DataPropertyName = "Neto"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "N2"
      Me.NetoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
      Me.NetoDataGridViewTextBoxColumn.HeaderText = "Neto"
      Me.NetoDataGridViewTextBoxColumn.Name = "NetoDataGridViewTextBoxColumn"
      Me.NetoDataGridViewTextBoxColumn.ReadOnly = True
      Me.NetoDataGridViewTextBoxColumn.Width = 80
      '
      'ImporteDataGridViewTextBoxColumn
      '
      Me.ImporteDataGridViewTextBoxColumn.DataPropertyName = "Importe"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle9.Format = "N2"
      Me.ImporteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
      Me.ImporteDataGridViewTextBoxColumn.HeaderText = "Importe"
      Me.ImporteDataGridViewTextBoxColumn.Name = "ImporteDataGridViewTextBoxColumn"
      Me.ImporteDataGridViewTextBoxColumn.ReadOnly = True
      Me.ImporteDataGridViewTextBoxColumn.Width = 80
      '
      'Percepciones
      '
      Me.Percepciones.DataPropertyName = "Percepciones"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle10.Format = "N2"
      DataGridViewCellStyle10.NullValue = Nothing
      Me.Percepciones.DefaultCellStyle = DataGridViewCellStyle10
      Me.Percepciones.HeaderText = "Percepciones"
      Me.Percepciones.Name = "Percepciones"
      Me.Percepciones.Width = 80
      '
      'ImpuestoInterno
      '
      Me.ImpuestoInterno.DataPropertyName = "ImpuestoInterno"
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle11.Format = "N2"
      Me.ImpuestoInterno.DefaultCellStyle = DataGridViewCellStyle11
      Me.ImpuestoInterno.HeaderText = "Imp. Interno"
      Me.ImpuestoInterno.Name = "ImpuestoInterno"
      Me.ImpuestoInterno.Width = 50
      '
      'TotalDataGridViewTextBoxColumn
      '
      Me.TotalDataGridViewTextBoxColumn.DataPropertyName = "Total"
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle12.Format = "N2"
      Me.TotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
      Me.TotalDataGridViewTextBoxColumn.HeaderText = "Total"
      Me.TotalDataGridViewTextBoxColumn.Name = "TotalDataGridViewTextBoxColumn"
      Me.TotalDataGridViewTextBoxColumn.ReadOnly = True
      Me.TotalDataGridViewTextBoxColumn.Width = 80
      '
      'IdAFIPTipoComprobanteDataGridViewTextBoxColumn
      '
      Me.IdAFIPTipoComprobanteDataGridViewTextBoxColumn.DataPropertyName = "IdAFIPTipoComprobante"
      Me.IdAFIPTipoComprobanteDataGridViewTextBoxColumn.HeaderText = "IdAFIPTipoComprobante"
      Me.IdAFIPTipoComprobanteDataGridViewTextBoxColumn.Name = "IdAFIPTipoComprobanteDataGridViewTextBoxColumn"
      Me.IdAFIPTipoComprobanteDataGridViewTextBoxColumn.Visible = False
      '
      'IdAFIPTipoDocumentoDataGridViewTextBoxColumn
      '
      Me.IdAFIPTipoDocumentoDataGridViewTextBoxColumn.DataPropertyName = "IdAFIPTipoDocumento"
      Me.IdAFIPTipoDocumentoDataGridViewTextBoxColumn.HeaderText = "IdAFIPTipoDocumento"
      Me.IdAFIPTipoDocumentoDataGridViewTextBoxColumn.Name = "IdAFIPTipoDocumentoDataGridViewTextBoxColumn"
      Me.IdAFIPTipoDocumentoDataGridViewTextBoxColumn.Visible = False
      '
      'AlicuotaDataGridViewTextBoxColumn
      '
      Me.AlicuotaDataGridViewTextBoxColumn.DataPropertyName = "Alicuota"
      DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.AlicuotaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle13
      Me.AlicuotaDataGridViewTextBoxColumn.HeaderText = "Alicuota"
      Me.AlicuotaDataGridViewTextBoxColumn.Name = "AlicuotaDataGridViewTextBoxColumn"
      Me.AlicuotaDataGridViewTextBoxColumn.ReadOnly = True
      Me.AlicuotaDataGridViewTextBoxColumn.Visible = False
      Me.AlicuotaDataGridViewTextBoxColumn.Width = 70
      '
      'CantidadDeAlicuotasDataGridViewTextBoxColumn
      '
      Me.CantidadDeAlicuotasDataGridViewTextBoxColumn.DataPropertyName = "CantidadDeAlicuotas"
      DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CantidadDeAlicuotasDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle14
      Me.CantidadDeAlicuotasDataGridViewTextBoxColumn.HeaderText = "Cant. Alicuotas"
      Me.CantidadDeAlicuotasDataGridViewTextBoxColumn.Name = "CantidadDeAlicuotasDataGridViewTextBoxColumn"
      Me.CantidadDeAlicuotasDataGridViewTextBoxColumn.ReadOnly = True
      Me.CantidadDeAlicuotasDataGridViewTextBoxColumn.Width = 50
      '
      'EstaAnuladaDataGridViewCheckBoxColumn
      '
      Me.EstaAnuladaDataGridViewCheckBoxColumn.DataPropertyName = "EstaAnulada"
      Me.EstaAnuladaDataGridViewCheckBoxColumn.HeaderText = "Anulada"
      Me.EstaAnuladaDataGridViewCheckBoxColumn.Name = "EstaAnuladaDataGridViewCheckBoxColumn"
      Me.EstaAnuladaDataGridViewCheckBoxColumn.ReadOnly = True
      Me.EstaAnuladaDataGridViewCheckBoxColumn.Width = 50
      '
      'colError
      '
      Me.colError.DataPropertyName = "TipoError"
      Me.colError.HeaderText = "Error"
      Me.colError.Name = "colError"
      Me.colError.Width = 350
      '
      'CitiVentasBindingSource
      '
      Me.CitiVentasBindingSource.DataMember = "CitiVentas"
      Me.CitiVentasBindingSource.DataSource = Me.DsAFIP
      '
      'DsAFIP
      '
      Me.DsAFIP.DataSetName = "dsAFIP"
      Me.DsAFIP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.dtpPeriodoFiscal)
      Me.grbFiltros.Controls.Add(Me.chbTodos)
      Me.grbFiltros.Controls.Add(Me.lblPeriodoFiscal)
      Me.grbFiltros.Controls.Add(Me.btnArchivo)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.txtArchivoDestino)
      Me.grbFiltros.Controls.Add(Me.lblArchivoDestino)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(865, 61)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'dtpPeriodoFiscal
      '
      Me.dtpPeriodoFiscal.BindearPropiedadControl = Nothing
      Me.dtpPeriodoFiscal.BindearPropiedadEntidad = Nothing
      Me.dtpPeriodoFiscal.CustomFormat = "MM/yyyy"
      Me.dtpPeriodoFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPeriodoFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPeriodoFiscal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodoFiscal.IsPK = False
      Me.dtpPeriodoFiscal.IsRequired = False
      Me.dtpPeriodoFiscal.Key = ""
      Me.dtpPeriodoFiscal.LabelAsoc = Me.lblPeriodoFiscal
      Me.dtpPeriodoFiscal.Location = New System.Drawing.Point(105, 23)
      Me.dtpPeriodoFiscal.Name = "dtpPeriodoFiscal"
      Me.dtpPeriodoFiscal.Size = New System.Drawing.Size(65, 20)
      Me.dtpPeriodoFiscal.TabIndex = 1
      '
      'lblPeriodoFiscal
      '
      Me.lblPeriodoFiscal.AutoSize = True
      Me.lblPeriodoFiscal.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblPeriodoFiscal.Location = New System.Drawing.Point(18, 16)
      Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
      Me.lblPeriodoFiscal.Size = New System.Drawing.Size(73, 13)
      Me.lblPeriodoFiscal.TabIndex = 0
      Me.lblPeriodoFiscal.Text = "Periodo Fiscal"
      '
      'chbTodos
      '
      Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chbTodos.AutoSize = True
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.Enabled = False
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(7, 44)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(56, 17)
      Me.chbTodos.TabIndex = 0
      Me.chbTodos.Text = "Todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'btnArchivo
      '
      Me.btnArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnArchivo.ImageKey = "folder.ico"
      Me.btnArchivo.ImageList = Me.imgGrabar
      Me.btnArchivo.Location = New System.Drawing.Point(765, 18)
      Me.btnArchivo.Name = "btnArchivo"
      Me.btnArchivo.Size = New System.Drawing.Size(94, 30)
      Me.btnArchivo.TabIndex = 3
      Me.btnArchivo.Text = "&Examinar..."
      Me.btnArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnArchivo.UseVisualStyleBackColor = True
      '
      'imgGrabar
      '
      Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
      Me.imgGrabar.Images.SetKeyName(0, "document_find.ico")
      Me.imgGrabar.Images.SetKeyName(1, "folder.ico")
      Me.imgGrabar.Images.SetKeyName(2, "row_add.ico")
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(97, 11)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 2
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Me.txtArchivoDestino.Location = New System.Drawing.Point(300, 26)
      Me.txtArchivoDestino.Name = "txtArchivoDestino"
      Me.txtArchivoDestino.Size = New System.Drawing.Size(446, 20)
      Me.txtArchivoDestino.TabIndex = 2
      '
      'lblArchivoDestino
      '
      Me.lblArchivoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblArchivoDestino.AutoSize = True
      Me.lblArchivoDestino.Location = New System.Drawing.Point(209, 30)
      Me.lblArchivoDestino.Name = "lblArchivoDestino"
      Me.lblArchivoDestino.Size = New System.Drawing.Size(85, 13)
      Me.lblArchivoDestino.TabIndex = 1
      Me.lblArchivoDestino.Text = "Archivo Destino:"
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbExportar, Me.ToolStripSeparator5, Me.tsbVerRegistrosConErrores, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(893, 29)
      Me.tstBarra.TabIndex = 2
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
      'tsbExportar
      '
      Me.tsbExportar.Enabled = False
      Me.tsbExportar.Image = CType(resources.GetObject("tsbExportar.Image"), System.Drawing.Image)
      Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbExportar.Name = "tsbExportar"
      Me.tsbExportar.Size = New System.Drawing.Size(76, 26)
      Me.tsbExportar.Text = "&Exportar"
      Me.tsbExportar.ToolTipText = "Imprimir"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
      '
      'tsbVerRegistrosConErrores
      '
      Me.tsbVerRegistrosConErrores.Enabled = False
      Me.tsbVerRegistrosConErrores.Image = CType(resources.GetObject("tsbVerRegistrosConErrores.Image"), System.Drawing.Image)
      Me.tsbVerRegistrosConErrores.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbVerRegistrosConErrores.Name = "tsbVerRegistrosConErrores"
      Me.tsbVerRegistrosConErrores.Size = New System.Drawing.Size(111, 26)
      Me.tsbVerRegistrosConErrores.Text = "Ver con errores"
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
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 450)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(893, 22)
      Me.stsStado.TabIndex = 6
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(814, 17)
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
      'TabControl1
      '
      Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TabControl1.Controls.Add(Me.TbpComprobantes)
      Me.TabControl1.Location = New System.Drawing.Point(12, 105)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(869, 330)
      Me.TabControl1.TabIndex = 1
      '
      'TbpComprobantes
      '
      Me.TbpComprobantes.BackColor = System.Drawing.SystemColors.Control
      Me.TbpComprobantes.Controls.Add(Me.dgvDetalle)
      Me.TbpComprobantes.Location = New System.Drawing.Point(4, 22)
      Me.TbpComprobantes.Name = "TbpComprobantes"
      Me.TbpComprobantes.Padding = New System.Windows.Forms.Padding(3)
      Me.TbpComprobantes.Size = New System.Drawing.Size(861, 304)
      Me.TbpComprobantes.TabIndex = 0
      Me.TbpComprobantes.Text = "Comprobantes"
      '
      'CitiVentasAlicuotasBindingSource
      '
      Me.CitiVentasAlicuotasBindingSource.DataMember = "CitiVentasAlicuotas"
      Me.CitiVentasAlicuotasBindingSource.DataSource = Me.DsAFIP
      '
      'SueldosExportacionSICOSS
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(893, 472)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "SueldosExportacionSICOSS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Exportacion para SI.C.O.S.S."
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.CitiVentasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DsAFIP, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TbpComprobantes.ResumeLayout(False)
      CType(Me.CitiVentasAlicuotasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(false)
      Me.PerformLayout

End Sub
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents txtArchivoDestino As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestino As Eniac.Controles.Label
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents btnArchivo As Eniac.Controles.Button
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents DsAFIP As Eniac.Win.dsAFIP
   Friend WithEvents CitiVentasBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents tsbVerRegistrosConErrores As System.Windows.Forms.ToolStripButton
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TbpComprobantes As System.Windows.Forms.TabPage
   Friend WithEvents CitiVentasAlicuotasBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents dtpPeriodoFiscal As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
   Friend WithEvents ProcesoDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents LineaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobanteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescripcionAbrevDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents LetraDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobanteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocClienteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocClienteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreClienteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaFiscalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CUITDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteBrutoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NetoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Percepciones As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImpuestoInterno As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdAFIPTipoComprobanteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdAFIPTipoDocumentoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents AlicuotaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CantidadDeAlicuotasDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents EstaAnuladaDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents colError As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
