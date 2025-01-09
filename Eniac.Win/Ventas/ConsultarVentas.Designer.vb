<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarVentas
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
      Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarVentas))
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.colVer = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.colImprimir = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.colVerEstandar = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.TipoImpresora = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescripcionAbrev = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCategoriaFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FormaDePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colCantidadInvocados = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.colCantidadLotes = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Percepciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TotalImpuestos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colCAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colCAEVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colIdTipoMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colNumeroMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.MercDespachada = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.FechaActualizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImportePesos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTickets = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTarjetas = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteCheques = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteRetenciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ImporteTransfBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbLetra = New Eniac.Controles.CheckBox()
      Me.chbEmisor = New Eniac.Controles.CheckBox()
      Me.chbProvincia = New Eniac.Controles.CheckBox()
      Me.chbLocalidad = New Eniac.Controles.CheckBox()
      Me.cmbProvincia = New Eniac.Controles.ComboBox()
      Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
      Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
      Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
      Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
      Me.cmbEmisor = New Eniac.Controles.ComboBox()
      Me.cboLetra = New Eniac.Controles.ComboBox()
      Me.chbCategoria = New Eniac.Controles.CheckBox()
      Me.cmbCategoria = New Eniac.Controles.ComboBox()
      Me.cmbEsComercial = New Eniac.Controles.ComboBox()
      Me.lblEsComercial = New Eniac.Controles.Label()
      Me.cmbMercDespachada = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.chbFormaPago = New Eniac.Controles.CheckBox()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.cmbAfectaCaja = New Eniac.Controles.ComboBox()
      Me.lblAfectaCaja = New Eniac.Controles.Label()
      Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
      Me.lblGrabanLibro = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.txtTotal = New Eniac.Controles.TextBox()
      Me.lblTotales = New Eniac.Controles.Label()
      Me.txtImpuestos = New Eniac.Controles.TextBox()
      Me.txtSubtotal = New Eniac.Controles.TextBox()
      Me.txtPercepciones = New Eniac.Controles.TextBox()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbFiltros.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.AllowUserToResizeRows = False
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVer, Me.colImprimir, Me.colVerEstandar, Me.TipoImpresora, Me.IdTipoComprobante, Me.DescripcionAbrev, Me.Letra, Me.CentroEmisor, Me.NumeroComprobante, Me.Fecha, Me.TipoDocCliente, Me.NroDocCliente, Me.NombreCliente, Me.NombreCategoriaFiscal, Me.FormaDePago, Me.colCantidadInvocados, Me.colCantidadLotes, Me.SubTotal, Me.IVA, Me.Percepciones, Me.TotalImpuestos, Me.ImporteTotal, Me.colCAE, Me.colCAEVencimiento, Me.Usuario, Me.Observacion, Me.colIdTipoMovimiento, Me.colNumeroMovimiento, Me.colIdSucursal, Me.MercDespachada, Me.FechaActualizacion, Me.IdCliente, Me.NombreProveedor, Me.ImportePesos, Me.ImporteTickets, Me.ImporteTarjetas, Me.ImporteCheques, Me.ImporteRetenciones, Me.IdCuentaBancaria, Me.ImporteTransfBancaria, Me.NombreBanco})
      DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle18
      Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDetalle.Location = New System.Drawing.Point(7, 212)
      Me.dgvDetalle.MultiSelect = False
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
      Me.dgvDetalle.RowHeadersVisible = False
      Me.dgvDetalle.RowHeadersWidth = 4
      Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDetalle.Size = New System.Drawing.Size(1003, 298)
      Me.dgvDetalle.TabIndex = 1
      '
      'colVer
      '
      Me.colVer.DataPropertyName = "Ver"
      Me.colVer.HeaderText = "Ver"
      Me.colVer.Name = "colVer"
      Me.colVer.ReadOnly = True
      Me.colVer.Text = "..."
      Me.colVer.Width = 30
      '
      'colImprimir
      '
      Me.colImprimir.DataPropertyName = "Imprimir"
      Me.colImprimir.HeaderText = "Imp"
      Me.colImprimir.Name = "colImprimir"
      Me.colImprimir.ReadOnly = True
      Me.colImprimir.Text = "(I)"
      Me.colImprimir.Width = 30
      '
      'colVerEstandar
      '
      Me.colVerEstandar.DataPropertyName = "VerEstandar"
      Me.colVerEstandar.HeaderText = "V.E."
      Me.colVerEstandar.Name = "colVerEstandar"
      Me.colVerEstandar.ReadOnly = True
      Me.colVerEstandar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.colVerEstandar.Text = "Ver en Formato Estandar"
      Me.colVerEstandar.Width = 30
      '
      'TipoImpresora
      '
      Me.TipoImpresora.DataPropertyName = "TipoImpresora"
      Me.TipoImpresora.HeaderText = "TipoImpresora"
      Me.TipoImpresora.Name = "TipoImpresora"
      Me.TipoImpresora.ReadOnly = True
      Me.TipoImpresora.Visible = False
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
      'DescripcionAbrev
      '
      Me.DescripcionAbrev.DataPropertyName = "DescripcionAbrev"
      Me.DescripcionAbrev.HeaderText = "Comprobante"
      Me.DescripcionAbrev.Name = "DescripcionAbrev"
      Me.DescripcionAbrev.ReadOnly = True
      Me.DescripcionAbrev.Width = 75
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
      Me.NumeroComprobante.Width = 55
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
      Me.Fecha.Width = 80
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
      'NombreCliente
      '
      Me.NombreCliente.DataPropertyName = "NombreCliente"
      Me.NombreCliente.HeaderText = "Cliente"
      Me.NombreCliente.Name = "NombreCliente"
      Me.NombreCliente.ReadOnly = True
      Me.NombreCliente.Width = 160
      '
      'NombreCategoriaFiscal
      '
      Me.NombreCategoriaFiscal.DataPropertyName = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscal.HeaderText = "Categ. Fiscal"
      Me.NombreCategoriaFiscal.Name = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscal.ReadOnly = True
      Me.NombreCategoriaFiscal.Width = 60
      '
      'FormaDePago
      '
      Me.FormaDePago.DataPropertyName = "FormaDePago"
      Me.FormaDePago.HeaderText = "F. de Pago"
      Me.FormaDePago.Name = "FormaDePago"
      Me.FormaDePago.ReadOnly = True
      Me.FormaDePago.Width = 60
      '
      'colCantidadInvocados
      '
      Me.colCantidadInvocados.DataPropertyName = "CantidadInvocados"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.colCantidadInvocados.DefaultCellStyle = DataGridViewCellStyle6
      Me.colCantidadInvocados.HeaderText = "Invoc."
      Me.colCantidadInvocados.Name = "colCantidadInvocados"
      Me.colCantidadInvocados.ReadOnly = True
      Me.colCantidadInvocados.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.colCantidadInvocados.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.colCantidadInvocados.ToolTipText = "Comprobantes Invocados"
      Me.colCantidadInvocados.Width = 37
      '
      'colCantidadLotes
      '
      Me.colCantidadLotes.DataPropertyName = "CantidadLotes"
      Me.colCantidadLotes.HeaderText = "Lotes"
      Me.colCantidadLotes.Name = "colCantidadLotes"
      Me.colCantidadLotes.ReadOnly = True
      Me.colCantidadLotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.colCantidadLotes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.colCantidadLotes.Width = 35
      '
      'SubTotal
      '
      Me.SubTotal.DataPropertyName = "SubTotal"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.Format = "N2"
      DataGridViewCellStyle7.NullValue = Nothing
      Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle7
      Me.SubTotal.HeaderText = "Neto"
      Me.SubTotal.Name = "SubTotal"
      Me.SubTotal.ReadOnly = True
      Me.SubTotal.Width = 70
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
      'Percepciones
      '
      Me.Percepciones.DataPropertyName = "Percepciones"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle9.Format = "N2"
      Me.Percepciones.DefaultCellStyle = DataGridViewCellStyle9
      Me.Percepciones.HeaderText = "Percep."
      Me.Percepciones.Name = "Percepciones"
      Me.Percepciones.ReadOnly = True
      Me.Percepciones.Visible = False
      Me.Percepciones.Width = 65
      '
      'TotalImpuestos
      '
      Me.TotalImpuestos.DataPropertyName = "TotalImpuestos"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle10.Format = "N2"
      DataGridViewCellStyle10.NullValue = Nothing
      Me.TotalImpuestos.DefaultCellStyle = DataGridViewCellStyle10
      Me.TotalImpuestos.HeaderText = "Impuestos"
      Me.TotalImpuestos.Name = "TotalImpuestos"
      Me.TotalImpuestos.ReadOnly = True
      Me.TotalImpuestos.Visible = False
      Me.TotalImpuestos.Width = 70
      '
      'ImporteTotal
      '
      Me.ImporteTotal.DataPropertyName = "ImporteTotal"
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle11.Format = "N2"
      Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle11
      Me.ImporteTotal.HeaderText = "Total"
      Me.ImporteTotal.Name = "ImporteTotal"
      Me.ImporteTotal.ReadOnly = True
      Me.ImporteTotal.Width = 70
      '
      'colCAE
      '
      Me.colCAE.DataPropertyName = "CAE"
      Me.colCAE.HeaderText = "CAE"
      Me.colCAE.Name = "colCAE"
      Me.colCAE.ReadOnly = True
      Me.colCAE.Visible = False
      '
      'colCAEVencimiento
      '
      Me.colCAEVencimiento.DataPropertyName = "CAEVencimiento"
      Me.colCAEVencimiento.HeaderText = "Venc. CAE"
      Me.colCAEVencimiento.Name = "colCAEVencimiento"
      Me.colCAEVencimiento.ReadOnly = True
      Me.colCAEVencimiento.Visible = False
      Me.colCAEVencimiento.Width = 80
      '
      'Usuario
      '
      Me.Usuario.DataPropertyName = "Usuario"
      Me.Usuario.HeaderText = "Usuario"
      Me.Usuario.Name = "Usuario"
      Me.Usuario.ReadOnly = True
      Me.Usuario.Width = 60
      '
      'Observacion
      '
      Me.Observacion.DataPropertyName = "Observacion"
      Me.Observacion.HeaderText = "Observacion"
      Me.Observacion.Name = "Observacion"
      Me.Observacion.ReadOnly = True
      Me.Observacion.Width = 250
      '
      'colIdTipoMovimiento
      '
      Me.colIdTipoMovimiento.DataPropertyName = "IdTipoMovimiento"
      Me.colIdTipoMovimiento.HeaderText = "IdTipoMovimiento"
      Me.colIdTipoMovimiento.Name = "colIdTipoMovimiento"
      Me.colIdTipoMovimiento.ReadOnly = True
      Me.colIdTipoMovimiento.Visible = False
      '
      'colNumeroMovimiento
      '
      Me.colNumeroMovimiento.DataPropertyName = "NumeroMovimiento"
      Me.colNumeroMovimiento.HeaderText = "NumeroMovimiento"
      Me.colNumeroMovimiento.Name = "colNumeroMovimiento"
      Me.colNumeroMovimiento.ReadOnly = True
      Me.colNumeroMovimiento.Visible = False
      '
      'colIdSucursal
      '
      Me.colIdSucursal.DataPropertyName = "IdSucursal"
      Me.colIdSucursal.HeaderText = "Sucursal"
      Me.colIdSucursal.Name = "colIdSucursal"
      Me.colIdSucursal.ReadOnly = True
      Me.colIdSucursal.Visible = False
      '
      'MercDespachada
      '
      Me.MercDespachada.DataPropertyName = "MercDespachada"
      Me.MercDespachada.HeaderText = "Merc. Desp."
      Me.MercDespachada.Name = "MercDespachada"
      Me.MercDespachada.ReadOnly = True
      Me.MercDespachada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.MercDespachada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.MercDespachada.Width = 60
      '
      'FechaActualizacion
      '
      Me.FechaActualizacion.DataPropertyName = "FechaActualizacion"
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle12.Format = "dd/MM/yyyy HH:mm"
      Me.FechaActualizacion.DefaultCellStyle = DataGridViewCellStyle12
      Me.FechaActualizacion.HeaderText = "Fecha Actualización"
      Me.FechaActualizacion.Name = "FechaActualizacion"
      Me.FechaActualizacion.ReadOnly = True
      '
      'IdCliente
      '
      Me.IdCliente.DataPropertyName = "IdCliente"
      Me.IdCliente.HeaderText = "IdCliente"
      Me.IdCliente.Name = "IdCliente"
      Me.IdCliente.ReadOnly = True
      Me.IdCliente.Visible = False
      '
      'NombreProveedor
      '
      Me.NombreProveedor.DataPropertyName = "NombreProveedor"
      Me.NombreProveedor.HeaderText = "Proveedor CyO"
      Me.NombreProveedor.Name = "NombreProveedor"
      Me.NombreProveedor.ReadOnly = True
      Me.NombreProveedor.Width = 150
      '
      'ImportePesos
      '
      Me.ImportePesos.DataPropertyName = "ImportePesos"
      DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle13.Format = "N2"
      Me.ImportePesos.DefaultCellStyle = DataGridViewCellStyle13
      Me.ImportePesos.HeaderText = "Imp. Pesos"
      Me.ImportePesos.Name = "ImportePesos"
      Me.ImportePesos.ReadOnly = True
      Me.ImportePesos.Width = 70
      '
      'ImporteTickets
      '
      Me.ImporteTickets.DataPropertyName = "ImporteTickets"
      DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle14.Format = "N2"
      Me.ImporteTickets.DefaultCellStyle = DataGridViewCellStyle14
      Me.ImporteTickets.HeaderText = "Imp. Tickets"
      Me.ImporteTickets.Name = "ImporteTickets"
      Me.ImporteTickets.ReadOnly = True
      Me.ImporteTickets.Width = 70
      '
      'ImporteTarjetas
      '
      Me.ImporteTarjetas.DataPropertyName = "ImporteTarjetas"
      DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle15.Format = "N2"
      Me.ImporteTarjetas.DefaultCellStyle = DataGridViewCellStyle15
      Me.ImporteTarjetas.HeaderText = "Imp. Tarjetas"
      Me.ImporteTarjetas.Name = "ImporteTarjetas"
      Me.ImporteTarjetas.ReadOnly = True
      Me.ImporteTarjetas.Width = 70
      '
      'ImporteCheques
      '
      Me.ImporteCheques.DataPropertyName = "ImporteCheques"
      DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle16.Format = "N2"
      Me.ImporteCheques.DefaultCellStyle = DataGridViewCellStyle16
      Me.ImporteCheques.HeaderText = "Imp. Cheques"
      Me.ImporteCheques.Name = "ImporteCheques"
      Me.ImporteCheques.ReadOnly = True
      Me.ImporteCheques.Width = 70
      '
      'ImporteRetenciones
      '
      Me.ImporteRetenciones.DataPropertyName = "ImporteRetenciones"
      Me.ImporteRetenciones.HeaderText = "Importe Reten."
      Me.ImporteRetenciones.Name = "ImporteRetenciones"
      Me.ImporteRetenciones.ReadOnly = True
      Me.ImporteRetenciones.Visible = False
      Me.ImporteRetenciones.Width = 70
      '
      'IdCuentaBancaria
      '
      Me.IdCuentaBancaria.DataPropertyName = "IdCuentaBancaria"
      Me.IdCuentaBancaria.HeaderText = "IdCuentaBancaria"
      Me.IdCuentaBancaria.Name = "IdCuentaBancaria"
      Me.IdCuentaBancaria.ReadOnly = True
      Me.IdCuentaBancaria.Visible = False
      '
      'ImporteTransfBancaria
      '
      Me.ImporteTransfBancaria.DataPropertyName = "ImporteTransfBancaria"
      DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle17.Format = "N2"
      Me.ImporteTransfBancaria.DefaultCellStyle = DataGridViewCellStyle17
      Me.ImporteTransfBancaria.HeaderText = "Imp. Tr. Banc."
      Me.ImporteTransfBancaria.Name = "ImporteTransfBancaria"
      Me.ImporteTransfBancaria.ReadOnly = True
      Me.ImporteTransfBancaria.Width = 70
      '
      'NombreBanco
      '
      Me.NombreBanco.DataPropertyName = "NombreBanco"
      Me.NombreBanco.HeaderText = "Banco"
      Me.NombreBanco.Name = "NombreBanco"
      Me.NombreBanco.ReadOnly = True
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.chbLetra)
      Me.grbFiltros.Controls.Add(Me.chbEmisor)
      Me.grbFiltros.Controls.Add(Me.chbProvincia)
      Me.grbFiltros.Controls.Add(Me.chbLocalidad)
      Me.grbFiltros.Controls.Add(Me.cmbProvincia)
      Me.grbFiltros.Controls.Add(Me.bscCodigoLocalidad)
      Me.grbFiltros.Controls.Add(Me.bscNombreLocalidad)
      Me.grbFiltros.Controls.Add(Me.chbZonaGeografica)
      Me.grbFiltros.Controls.Add(Me.cmbZonaGeografica)
      Me.grbFiltros.Controls.Add(Me.cmbEmisor)
      Me.grbFiltros.Controls.Add(Me.cboLetra)
      Me.grbFiltros.Controls.Add(Me.chbCategoria)
      Me.grbFiltros.Controls.Add(Me.cmbCategoria)
      Me.grbFiltros.Controls.Add(Me.cmbEsComercial)
      Me.grbFiltros.Controls.Add(Me.lblEsComercial)
      Me.grbFiltros.Controls.Add(Me.cmbMercDespachada)
      Me.grbFiltros.Controls.Add(Me.Label1)
      Me.grbFiltros.Controls.Add(Me.txtNumero)
      Me.grbFiltros.Controls.Add(Me.chbUsuario)
      Me.grbFiltros.Controls.Add(Me.cmbUsuario)
      Me.grbFiltros.Controls.Add(Me.chbFormaPago)
      Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
      Me.grbFiltros.Controls.Add(Me.chbVendedor)
      Me.grbFiltros.Controls.Add(Me.cmbVendedor)
      Me.grbFiltros.Controls.Add(Me.cmbAfectaCaja)
      Me.grbFiltros.Controls.Add(Me.lblAfectaCaja)
      Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
      Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.lblNombre)
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Controls.Add(Me.chbNumero)
      Me.grbFiltros.Location = New System.Drawing.Point(7, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(1003, 168)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'chbLetra
      '
      Me.chbLetra.AutoSize = True
      Me.chbLetra.BindearPropiedadControl = Nothing
      Me.chbLetra.BindearPropiedadEntidad = Nothing
      Me.chbLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLetra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLetra.IsPK = False
      Me.chbLetra.IsRequired = False
      Me.chbLetra.Key = Nothing
      Me.chbLetra.LabelAsoc = Nothing
      Me.chbLetra.Location = New System.Drawing.Point(671, 23)
      Me.chbLetra.Name = "chbLetra"
      Me.chbLetra.Size = New System.Drawing.Size(50, 17)
      Me.chbLetra.TabIndex = 6
      Me.chbLetra.Text = "Letra"
      Me.chbLetra.UseVisualStyleBackColor = True
      '
      'chbEmisor
      '
      Me.chbEmisor.AutoSize = True
      Me.chbEmisor.BindearPropiedadControl = Nothing
      Me.chbEmisor.BindearPropiedadEntidad = Nothing
      Me.chbEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEmisor.IsPK = False
      Me.chbEmisor.IsRequired = False
      Me.chbEmisor.Key = Nothing
      Me.chbEmisor.LabelAsoc = Nothing
      Me.chbEmisor.Location = New System.Drawing.Point(772, 23)
      Me.chbEmisor.Name = "chbEmisor"
      Me.chbEmisor.Size = New System.Drawing.Size(57, 17)
      Me.chbEmisor.TabIndex = 8
      Me.chbEmisor.Text = "Emisor"
      Me.chbEmisor.UseVisualStyleBackColor = True
      '
      'chbProvincia
      '
      Me.chbProvincia.AutoSize = True
      Me.chbProvincia.BindearPropiedadControl = Nothing
      Me.chbProvincia.BindearPropiedadEntidad = Nothing
      Me.chbProvincia.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProvincia.IsPK = False
      Me.chbProvincia.IsRequired = False
      Me.chbProvincia.Key = Nothing
      Me.chbProvincia.LabelAsoc = Nothing
      Me.chbProvincia.Location = New System.Drawing.Point(703, 108)
      Me.chbProvincia.Name = "chbProvincia"
      Me.chbProvincia.Size = New System.Drawing.Size(70, 17)
      Me.chbProvincia.TabIndex = 32
      Me.chbProvincia.Text = "Provincia"
      Me.chbProvincia.UseVisualStyleBackColor = True
      '
      'chbLocalidad
      '
      Me.chbLocalidad.AutoSize = True
      Me.chbLocalidad.BindearPropiedadControl = Nothing
      Me.chbLocalidad.BindearPropiedadEntidad = Nothing
      Me.chbLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLocalidad.IsPK = False
      Me.chbLocalidad.IsRequired = False
      Me.chbLocalidad.Key = Nothing
      Me.chbLocalidad.LabelAsoc = Nothing
      Me.chbLocalidad.Location = New System.Drawing.Point(376, 107)
      Me.chbLocalidad.Name = "chbLocalidad"
      Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
      Me.chbLocalidad.TabIndex = 29
      Me.chbLocalidad.Text = "Localidad"
      Me.chbLocalidad.UseVisualStyleBackColor = True
      '
      'cmbProvincia
      '
      Me.cmbProvincia.BindearPropiedadControl = "SelectedValue"
      Me.cmbProvincia.BindearPropiedadEntidad = "IdProvincia"
      Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbProvincia.Enabled = False
      Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbProvincia.FormattingEnabled = True
      Me.cmbProvincia.IsPK = False
      Me.cmbProvincia.IsRequired = True
      Me.cmbProvincia.Key = Nothing
      Me.cmbProvincia.LabelAsoc = Nothing
      Me.cmbProvincia.Location = New System.Drawing.Point(777, 106)
      Me.cmbProvincia.Name = "cmbProvincia"
      Me.cmbProvincia.Size = New System.Drawing.Size(125, 21)
      Me.cmbProvincia.TabIndex = 33
      '
      'bscCodigoLocalidad
      '
      Me.bscCodigoLocalidad.AyudaAncho = 608
      Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
      Me.bscCodigoLocalidad.BindearPropiedadEntidad = "IdLocalidad"
      Me.bscCodigoLocalidad.ColumnasAlineacion = Nothing
      Me.bscCodigoLocalidad.ColumnasAncho = Nothing
      Me.bscCodigoLocalidad.ColumnasFormato = Nothing
      Me.bscCodigoLocalidad.ColumnasOcultas = Nothing
      Me.bscCodigoLocalidad.ColumnasTitulos = Nothing
      Me.bscCodigoLocalidad.Datos = Nothing
      Me.bscCodigoLocalidad.Enabled = False
      Me.bscCodigoLocalidad.FilaDevuelta = Nothing
      Me.bscCodigoLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoLocalidad.IsDecimal = False
      Me.bscCodigoLocalidad.IsNumber = False
      Me.bscCodigoLocalidad.IsPK = False
      Me.bscCodigoLocalidad.IsRequired = False
      Me.bscCodigoLocalidad.Key = ""
      Me.bscCodigoLocalidad.LabelAsoc = Nothing
      Me.bscCodigoLocalidad.Location = New System.Drawing.Point(451, 106)
      Me.bscCodigoLocalidad.MaxLengh = "32767"
      Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
      Me.bscCodigoLocalidad.Permitido = True
      Me.bscCodigoLocalidad.Selecciono = False
      Me.bscCodigoLocalidad.Size = New System.Drawing.Size(85, 20)
      Me.bscCodigoLocalidad.TabIndex = 30
      Me.bscCodigoLocalidad.Titulo = Nothing
      '
      'bscNombreLocalidad
      '
      Me.bscNombreLocalidad.AyudaAncho = 608
      Me.bscNombreLocalidad.BindearPropiedadControl = Nothing
      Me.bscNombreLocalidad.BindearPropiedadEntidad = Nothing
      Me.bscNombreLocalidad.ColumnasAlineacion = Nothing
      Me.bscNombreLocalidad.ColumnasAncho = Nothing
      Me.bscNombreLocalidad.ColumnasFormato = Nothing
      Me.bscNombreLocalidad.ColumnasOcultas = Nothing
      Me.bscNombreLocalidad.ColumnasTitulos = Nothing
      Me.bscNombreLocalidad.Datos = Nothing
      Me.bscNombreLocalidad.Enabled = False
      Me.bscNombreLocalidad.FilaDevuelta = Nothing
      Me.bscNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreLocalidad.IsDecimal = False
      Me.bscNombreLocalidad.IsNumber = False
      Me.bscNombreLocalidad.IsPK = False
      Me.bscNombreLocalidad.IsRequired = False
      Me.bscNombreLocalidad.Key = ""
      Me.bscNombreLocalidad.LabelAsoc = Nothing
      Me.bscNombreLocalidad.Location = New System.Drawing.Point(538, 106)
      Me.bscNombreLocalidad.MaxLengh = "32767"
      Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
      Me.bscNombreLocalidad.Permitido = True
      Me.bscNombreLocalidad.Selecciono = False
      Me.bscNombreLocalidad.Size = New System.Drawing.Size(159, 20)
      Me.bscNombreLocalidad.TabIndex = 31
      Me.bscNombreLocalidad.Titulo = Nothing
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
      Me.chbZonaGeografica.Location = New System.Drawing.Point(376, 137)
      Me.chbZonaGeografica.Name = "chbZonaGeografica"
      Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
      Me.chbZonaGeografica.TabIndex = 38
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
      Me.cmbZonaGeografica.Location = New System.Drawing.Point(488, 133)
      Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
      Me.cmbZonaGeografica.Size = New System.Drawing.Size(130, 21)
      Me.cmbZonaGeografica.TabIndex = 39
      '
      'cmbEmisor
      '
      Me.cmbEmisor.BindearPropiedadControl = Nothing
      Me.cmbEmisor.BindearPropiedadEntidad = Nothing
      Me.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEmisor.Enabled = False
      Me.cmbEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEmisor.FormattingEnabled = True
      Me.cmbEmisor.IsPK = False
      Me.cmbEmisor.IsRequired = False
      Me.cmbEmisor.Key = Nothing
      Me.cmbEmisor.LabelAsoc = Nothing
      Me.cmbEmisor.Location = New System.Drawing.Point(830, 21)
      Me.cmbEmisor.Name = "cmbEmisor"
      Me.cmbEmisor.Size = New System.Drawing.Size(40, 21)
      Me.cmbEmisor.TabIndex = 9
      '
      'cboLetra
      '
      Me.cboLetra.BindearPropiedadControl = Nothing
      Me.cboLetra.BindearPropiedadEntidad = Nothing
      Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLetra.Enabled = False
      Me.cboLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.cboLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboLetra.FormattingEnabled = True
      Me.cboLetra.IsPK = False
      Me.cboLetra.IsRequired = False
      Me.cboLetra.Key = Nothing
      Me.cboLetra.LabelAsoc = Nothing
      Me.cboLetra.Location = New System.Drawing.Point(728, 21)
      Me.cboLetra.Name = "cboLetra"
      Me.cboLetra.Size = New System.Drawing.Size(38, 21)
      Me.cboLetra.TabIndex = 7
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
      Me.chbCategoria.Location = New System.Drawing.Point(462, 78)
      Me.chbCategoria.Name = "chbCategoria"
      Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
      Me.chbCategoria.TabIndex = 21
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
      Me.cmbCategoria.Location = New System.Drawing.Point(536, 76)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(130, 21)
      Me.cmbCategoria.TabIndex = 22
      '
      'cmbEsComercial
      '
      Me.cmbEsComercial.BindearPropiedadControl = Nothing
      Me.cmbEsComercial.BindearPropiedadEntidad = Nothing
      Me.cmbEsComercial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEsComercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEsComercial.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEsComercial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEsComercial.FormattingEnabled = True
      Me.cmbEsComercial.IsPK = False
      Me.cmbEsComercial.IsRequired = False
      Me.cmbEsComercial.Key = Nothing
      Me.cmbEsComercial.LabelAsoc = Me.lblEsComercial
      Me.cmbEsComercial.Location = New System.Drawing.Point(87, 133)
      Me.cmbEsComercial.Name = "cmbEsComercial"
      Me.cmbEsComercial.Size = New System.Drawing.Size(83, 21)
      Me.cmbEsComercial.TabIndex = 35
      '
      'lblEsComercial
      '
      Me.lblEsComercial.AutoSize = True
      Me.lblEsComercial.Location = New System.Drawing.Point(15, 137)
      Me.lblEsComercial.Name = "lblEsComercial"
      Me.lblEsComercial.Size = New System.Drawing.Size(53, 13)
      Me.lblEsComercial.TabIndex = 34
      Me.lblEsComercial.Text = "Comercial"
      '
      'cmbMercDespachada
      '
      Me.cmbMercDespachada.BindearPropiedadControl = Nothing
      Me.cmbMercDespachada.BindearPropiedadEntidad = Nothing
      Me.cmbMercDespachada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMercDespachada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbMercDespachada.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMercDespachada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMercDespachada.FormattingEnabled = True
      Me.cmbMercDespachada.IsPK = False
      Me.cmbMercDespachada.IsRequired = False
      Me.cmbMercDespachada.Key = Nothing
      Me.cmbMercDespachada.LabelAsoc = Me.Label1
      Me.cmbMercDespachada.Location = New System.Drawing.Point(279, 133)
      Me.cmbMercDespachada.Name = "cmbMercDespachada"
      Me.cmbMercDespachada.Size = New System.Drawing.Size(83, 21)
      Me.cmbMercDespachada.TabIndex = 37
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(175, 137)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(98, 13)
      Me.Label1.TabIndex = 36
      Me.Label1.Text = "Merc. Despachada"
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
      Me.txtNumero.Location = New System.Drawing.Point(943, 21)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(56, 20)
      Me.txtNumero.TabIndex = 11
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
      Me.chbUsuario.Location = New System.Drawing.Point(671, 49)
      Me.chbUsuario.Name = "chbUsuario"
      Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
      Me.chbUsuario.TabIndex = 19
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
      Me.cmbUsuario.Location = New System.Drawing.Point(777, 47)
      Me.cmbUsuario.Name = "cmbUsuario"
      Me.cmbUsuario.Size = New System.Drawing.Size(125, 21)
      Me.cmbUsuario.TabIndex = 20
      '
      'chbFormaPago
      '
      Me.chbFormaPago.AutoSize = True
      Me.chbFormaPago.BindearPropiedadControl = Nothing
      Me.chbFormaPago.BindearPropiedadEntidad = Nothing
      Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFormaPago.IsPK = False
      Me.chbFormaPago.IsRequired = False
      Me.chbFormaPago.Key = Nothing
      Me.chbFormaPago.LabelAsoc = Nothing
      Me.chbFormaPago.Location = New System.Drawing.Point(671, 78)
      Me.chbFormaPago.Name = "chbFormaPago"
      Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
      Me.chbFormaPago.TabIndex = 23
      Me.chbFormaPago.Text = "Forma de Pago"
      Me.chbFormaPago.UseVisualStyleBackColor = True
      '
      'cmbFormaPago
      '
      Me.cmbFormaPago.BindearPropiedadControl = Nothing
      Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
      Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormaPago.Enabled = False
      Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormaPago.FormattingEnabled = True
      Me.cmbFormaPago.IsPK = False
      Me.cmbFormaPago.IsRequired = False
      Me.cmbFormaPago.Key = Nothing
      Me.cmbFormaPago.LabelAsoc = Nothing
      Me.cmbFormaPago.Location = New System.Drawing.Point(777, 76)
      Me.cmbFormaPago.Name = "cmbFormaPago"
      Me.cmbFormaPago.Size = New System.Drawing.Size(125, 21)
      Me.cmbFormaPago.TabIndex = 24
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
      Me.chbVendedor.Location = New System.Drawing.Point(462, 49)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 17
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
      Me.cmbVendedor.Location = New System.Drawing.Point(536, 47)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(130, 21)
      Me.cmbVendedor.TabIndex = 18
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
      Me.cmbAfectaCaja.Location = New System.Drawing.Point(279, 102)
      Me.cmbAfectaCaja.Name = "cmbAfectaCaja"
      Me.cmbAfectaCaja.Size = New System.Drawing.Size(83, 21)
      Me.cmbAfectaCaja.TabIndex = 28
      '
      'lblAfectaCaja
      '
      Me.lblAfectaCaja.AutoSize = True
      Me.lblAfectaCaja.Location = New System.Drawing.Point(214, 106)
      Me.lblAfectaCaja.Name = "lblAfectaCaja"
      Me.lblAfectaCaja.Size = New System.Drawing.Size(62, 13)
      Me.lblAfectaCaja.TabIndex = 27
      Me.lblAfectaCaja.Text = "Afecta Caja"
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
      Me.cmbGrabanLibro.Location = New System.Drawing.Point(87, 102)
      Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
      Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
      Me.cmbGrabanLibro.TabIndex = 26
      '
      'lblGrabanLibro
      '
      Me.lblGrabanLibro.AutoSize = True
      Me.lblGrabanLibro.Location = New System.Drawing.Point(11, 106)
      Me.lblGrabanLibro.Name = "lblGrabanLibro"
      Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
      Me.lblGrabanLibro.TabIndex = 25
      Me.lblGrabanLibro.Text = "Graban Libro"
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
      Me.bscCodigoCliente.Location = New System.Drawing.Point(87, 64)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 13
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(84, 48)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 14
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
      Me.bscCliente.Location = New System.Drawing.Point(181, 64)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(254, 23)
      Me.bscCliente.TabIndex = 15
      Me.bscCliente.Titulo = Nothing
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(181, 48)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 16
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
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(536, 21)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(130, 21)
      Me.cmbTiposComprobantes.TabIndex = 5
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(905, 105)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(94, 45)
      Me.btnConsultar.TabIndex = 40
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
      Me.chbCliente.Location = New System.Drawing.Point(14, 66)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 12
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
      Me.chbTipoComprobante.Location = New System.Drawing.Point(438, 23)
      Me.chbTipoComprobante.Name = "chbTipoComprobante"
      Me.chbTipoComprobante.Size = New System.Drawing.Size(95, 17)
      Me.chbTipoComprobante.TabIndex = 4
      Me.chbTipoComprobante.Text = "Tipo Comprob."
      Me.chbTipoComprobante.UseVisualStyleBackColor = True
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(14, 23)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 41
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
      Me.dtpHasta.Location = New System.Drawing.Point(307, 21)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 3
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(269, 25)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 2
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
      Me.dtpDesde.Location = New System.Drawing.Point(144, 21)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 1
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.Location = New System.Drawing.Point(105, 25)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 0
      Me.lblDesde.Text = "Desde"
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
      Me.chbNumero.Location = New System.Drawing.Point(877, 23)
      Me.chbNumero.Name = "chbNumero"
      Me.chbNumero.Size = New System.Drawing.Size(63, 17)
      Me.chbNumero.TabIndex = 10
      Me.chbNumero.Text = "Numero"
      Me.chbNumero.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator5, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1015, 29)
      Me.tstBarra.TabIndex = 7
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
      'tsbImprimir
      '
      Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
      Me.stsStado.Location = New System.Drawing.Point(0, 537)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(1015, 22)
      Me.stsStado.TabIndex = 6
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(936, 17)
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
      'txtTotal
      '
      Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotal.BindearPropiedadControl = Nothing
      Me.txtTotal.BindearPropiedadEntidad = Nothing
      Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotal.Formato = ""
      Me.txtTotal.IsDecimal = False
      Me.txtTotal.IsNumber = False
      Me.txtTotal.IsPK = False
      Me.txtTotal.IsRequired = False
      Me.txtTotal.Key = ""
      Me.txtTotal.LabelAsoc = Nothing
      Me.txtTotal.Location = New System.Drawing.Point(936, 511)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.txtTotal.Size = New System.Drawing.Size(70, 20)
      Me.txtTotal.TabIndex = 5
      Me.txtTotal.Text = "0.00"
      Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotales
      '
      Me.lblTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotales.AutoSize = True
      Me.lblTotales.Location = New System.Drawing.Point(677, 515)
      Me.lblTotales.Name = "lblTotales"
      Me.lblTotales.Size = New System.Drawing.Size(45, 13)
      Me.lblTotales.TabIndex = 2
      Me.lblTotales.Text = "Totales:"
      '
      'txtImpuestos
      '
      Me.txtImpuestos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtImpuestos.BindearPropiedadControl = Nothing
      Me.txtImpuestos.BindearPropiedadEntidad = Nothing
      Me.txtImpuestos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImpuestos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImpuestos.Formato = "##0.00"
      Me.txtImpuestos.IsDecimal = True
      Me.txtImpuestos.IsNumber = True
      Me.txtImpuestos.IsPK = False
      Me.txtImpuestos.IsRequired = False
      Me.txtImpuestos.Key = ""
      Me.txtImpuestos.LabelAsoc = Nothing
      Me.txtImpuestos.Location = New System.Drawing.Point(798, 511)
      Me.txtImpuestos.Name = "txtImpuestos"
      Me.txtImpuestos.ReadOnly = True
      Me.txtImpuestos.Size = New System.Drawing.Size(70, 20)
      Me.txtImpuestos.TabIndex = 4
      Me.txtImpuestos.Text = "0.00"
      Me.txtImpuestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtSubtotal
      '
      Me.txtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSubtotal.BindearPropiedadControl = Nothing
      Me.txtSubtotal.BindearPropiedadEntidad = Nothing
      Me.txtSubtotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSubtotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSubtotal.Formato = "##0.00"
      Me.txtSubtotal.IsDecimal = True
      Me.txtSubtotal.IsNumber = True
      Me.txtSubtotal.IsPK = False
      Me.txtSubtotal.IsRequired = False
      Me.txtSubtotal.Key = ""
      Me.txtSubtotal.LabelAsoc = Nothing
      Me.txtSubtotal.Location = New System.Drawing.Point(729, 511)
      Me.txtSubtotal.Name = "txtSubtotal"
      Me.txtSubtotal.ReadOnly = True
      Me.txtSubtotal.Size = New System.Drawing.Size(70, 20)
      Me.txtSubtotal.TabIndex = 3
      Me.txtSubtotal.Text = "0.00"
      Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtPercepciones
      '
      Me.txtPercepciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPercepciones.BindearPropiedadControl = Nothing
      Me.txtPercepciones.BindearPropiedadEntidad = Nothing
      Me.txtPercepciones.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPercepciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPercepciones.Formato = ""
      Me.txtPercepciones.IsDecimal = False
      Me.txtPercepciones.IsNumber = False
      Me.txtPercepciones.IsPK = False
      Me.txtPercepciones.IsRequired = False
      Me.txtPercepciones.Key = ""
      Me.txtPercepciones.LabelAsoc = Nothing
      Me.txtPercepciones.Location = New System.Drawing.Point(867, 511)
      Me.txtPercepciones.Name = "txtPercepciones"
      Me.txtPercepciones.ReadOnly = True
      Me.txtPercepciones.Size = New System.Drawing.Size(70, 20)
      Me.txtPercepciones.TabIndex = 8
      Me.txtPercepciones.Text = "0.00"
      Me.txtPercepciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtPercepciones.Visible = False
      '
      'ConsultarVentas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1015, 559)
      Me.Controls.Add(Me.txtPercepciones)
      Me.Controls.Add(Me.txtSubtotal)
      Me.Controls.Add(Me.txtTotal)
      Me.Controls.Add(Me.lblTotales)
      Me.Controls.Add(Me.txtImpuestos)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ConsultarVentas"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultar Ventas"
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
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
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents cmbAfectaCaja As Eniac.Controles.ComboBox
   Friend WithEvents lblAfectaCaja As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents lblTotales As Eniac.Controles.Label
   Friend WithEvents txtImpuestos As Eniac.Controles.TextBox
   Friend WithEvents txtSubtotal As Eniac.Controles.TextBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents cmbMercDespachada As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbEsComercial As Eniac.Controles.ComboBox
   Friend WithEvents lblEsComercial As Eniac.Controles.Label
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents cmbEmisor As Eniac.Controles.ComboBox
   Friend WithEvents cboLetra As Eniac.Controles.ComboBox
   Friend WithEvents chbProvincia As Eniac.Controles.CheckBox
   Friend WithEvents chbLocalidad As Eniac.Controles.CheckBox
   Public WithEvents cmbProvincia As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoLocalidad As Eniac.Controles.Buscador
   Friend WithEvents bscNombreLocalidad As Eniac.Controles.Buscador
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents chbLetra As Eniac.Controles.CheckBox
   Friend WithEvents chbEmisor As Eniac.Controles.CheckBox
   Friend WithEvents txtPercepciones As Eniac.Controles.TextBox
   Friend WithEvents colVer As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents colImprimir As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents colVerEstandar As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents TipoImpresora As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescripcionAbrev As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FormaDePago As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colCantidadInvocados As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents colCantidadLotes As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IVA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Percepciones As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalImpuestos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colCAE As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colCAEVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colIdTipoMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colNumeroMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents MercDespachada As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents FechaActualizacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImportePesos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTickets As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTarjetas As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteCheques As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteRetenciones As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCuentaBancaria As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTransfBancaria As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreBanco As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
