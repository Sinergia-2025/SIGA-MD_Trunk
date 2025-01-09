<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacturacionUtilizaCanje
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FacturacionUtilizaCanje))
        Me.dgvDetalle = New Eniac.Controles.DataGridView()
        Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionAbrev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdaAtributoProducto01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionAtributo01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdaAtributoProducto02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionAtributo02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdaAtributoProducto03 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionAtributo03 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdaAtributoProducto04 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionAtributo04 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadCanje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockCanje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteCanje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbProductosCanje = New System.Windows.Forms.GroupBox()
        Me.btnInsertarProducto = New Eniac.Controles.Button()
        Me.btnBorrarProducto = New Eniac.Controles.Button()
        Me.txtCantidadProductoCanje = New Eniac.Controles.TextBox()
        Me.bscCodigoProductoCanje = New Eniac.Controles.Buscador2()
        Me.lblProductoCanje = New Eniac.Controles.Label()
        Me.lblCantidadCanje = New Eniac.Controles.Label()
        Me.btnLimpiarProductos = New Eniac.Controles.Button()
        Me.bscNombreProductoCanje = New Eniac.Controles.Buscador2()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTotalGeneral = New Eniac.Controles.TextBox()
        Me.lblTotalGeneral = New Eniac.Controles.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbTipoComprobante = New Eniac.Controles.ComboBox()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbProductosCanje.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTipoComprobante, Me.DescripcionAbrev, Me.IdaAtributoProducto01, Me.DescripcionAtributo01, Me.IdaAtributoProducto02, Me.DescripcionAtributo02, Me.IdaAtributoProducto03, Me.DescripcionAtributo03, Me.IdaAtributoProducto04, Me.DescripcionAtributo04, Me.CantidadCanje, Me.ImporteTotal, Me.StockCanje, Me.ImporteCanje})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 65)
        Me.dgvDetalle.MultiSelect = False
        Me.dgvDetalle.Name = "dgvDetalle"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.RowHeadersWidth = 4
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(689, 298)
        Me.dgvDetalle.TabIndex = 6
        '
        'IdTipoComprobante
        '
        Me.IdTipoComprobante.DataPropertyName = "IdProducto"
        Me.IdTipoComprobante.HeaderText = "Código"
        Me.IdTipoComprobante.Name = "IdTipoComprobante"
        Me.IdTipoComprobante.Width = 85
        '
        'DescripcionAbrev
        '
        Me.DescripcionAbrev.DataPropertyName = "DescripcionProducto"
        Me.DescripcionAbrev.HeaderText = "Descripcion"
        Me.DescripcionAbrev.Name = "DescripcionAbrev"
        Me.DescripcionAbrev.Width = 200
        '
        'IdaAtributoProducto01
        '
        Me.IdaAtributoProducto01.DataPropertyName = "IdaAtributoProducto01"
        Me.IdaAtributoProducto01.HeaderText = "CodigoAtributo01"
        Me.IdaAtributoProducto01.Name = "IdaAtributoProducto01"
        Me.IdaAtributoProducto01.Visible = False
        '
        'DescripcionAtributo01
        '
        Me.DescripcionAtributo01.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescripcionAtributo01.DataPropertyName = "DescripcionAtributo01"
        Me.DescripcionAtributo01.HeaderText = "Descripcion"
        Me.DescripcionAtributo01.Name = "DescripcionAtributo01"
        Me.DescripcionAtributo01.Visible = False
        '
        'IdaAtributoProducto02
        '
        Me.IdaAtributoProducto02.DataPropertyName = "IdaAtributoProducto02"
        Me.IdaAtributoProducto02.HeaderText = "CodigoAtributo02"
        Me.IdaAtributoProducto02.Name = "IdaAtributoProducto02"
        Me.IdaAtributoProducto02.Visible = False
        '
        'DescripcionAtributo02
        '
        Me.DescripcionAtributo02.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescripcionAtributo02.DataPropertyName = "DescripcionAtributo02"
        Me.DescripcionAtributo02.HeaderText = "Descripcion"
        Me.DescripcionAtributo02.Name = "DescripcionAtributo02"
        Me.DescripcionAtributo02.Visible = False
        '
        'IdaAtributoProducto03
        '
        Me.IdaAtributoProducto03.DataPropertyName = "IdaAtributoProducto03"
        Me.IdaAtributoProducto03.HeaderText = "CodigoAtributo03"
        Me.IdaAtributoProducto03.Name = "IdaAtributoProducto03"
        Me.IdaAtributoProducto03.Visible = False
        '
        'DescripcionAtributo03
        '
        Me.DescripcionAtributo03.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescripcionAtributo03.DataPropertyName = "DescripcionAtributo03"
        Me.DescripcionAtributo03.HeaderText = "Descripcion"
        Me.DescripcionAtributo03.Name = "DescripcionAtributo03"
        Me.DescripcionAtributo03.Visible = False
        '
        'IdaAtributoProducto04
        '
        Me.IdaAtributoProducto04.DataPropertyName = "IdaAtributoProducto04"
        Me.IdaAtributoProducto04.HeaderText = "CodigoAtributo04"
        Me.IdaAtributoProducto04.Name = "IdaAtributoProducto04"
        Me.IdaAtributoProducto04.Visible = False
        '
        'DescripcionAtributo04
        '
        Me.DescripcionAtributo04.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DescripcionAtributo04.DataPropertyName = "DescripcionAtributo04"
        Me.DescripcionAtributo04.HeaderText = "Descripcion"
        Me.DescripcionAtributo04.Name = "DescripcionAtributo04"
        Me.DescripcionAtributo04.Visible = False
        '
        'CantidadCanje
        '
        Me.CantidadCanje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CantidadCanje.DataPropertyName = "CantidadProducto"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.CantidadCanje.DefaultCellStyle = DataGridViewCellStyle2
        Me.CantidadCanje.HeaderText = "Cantidad"
        Me.CantidadCanje.Name = "CantidadCanje"
        Me.CantidadCanje.Width = 74
        '
        'ImporteTotal
        '
        Me.ImporteTotal.DataPropertyName = "PrecioProducto"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle3
        Me.ImporteTotal.HeaderText = "Precio"
        Me.ImporteTotal.Name = "ImporteTotal"
        Me.ImporteTotal.Width = 75
        '
        'StockCanje
        '
        Me.StockCanje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.StockCanje.DataPropertyName = "StockProducto"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.StockCanje.DefaultCellStyle = DataGridViewCellStyle4
        Me.StockCanje.HeaderText = "Stock"
        Me.StockCanje.Name = "StockCanje"
        Me.StockCanje.Width = 60
        '
        'ImporteCanje
        '
        Me.ImporteCanje.DataPropertyName = "ImporteProducto"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.ImporteCanje.DefaultCellStyle = DataGridViewCellStyle5
        Me.ImporteCanje.HeaderText = "Importe"
        Me.ImporteCanje.Name = "ImporteCanje"
        '
        'grbProductosCanje
        '
        Me.grbProductosCanje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbProductosCanje.Controls.Add(Me.btnInsertarProducto)
        Me.grbProductosCanje.Controls.Add(Me.btnBorrarProducto)
        Me.grbProductosCanje.Controls.Add(Me.txtCantidadProductoCanje)
        Me.grbProductosCanje.Controls.Add(Me.bscCodigoProductoCanje)
        Me.grbProductosCanje.Controls.Add(Me.lblProductoCanje)
        Me.grbProductosCanje.Controls.Add(Me.lblCantidadCanje)
        Me.grbProductosCanje.Controls.Add(Me.btnLimpiarProductos)
        Me.grbProductosCanje.Controls.Add(Me.bscNombreProductoCanje)
        Me.grbProductosCanje.Location = New System.Drawing.Point(12, 7)
        Me.grbProductosCanje.Name = "grbProductosCanje"
        Me.grbProductosCanje.Size = New System.Drawing.Size(689, 52)
        Me.grbProductosCanje.TabIndex = 7
        Me.grbProductosCanje.TabStop = False
        '
        'btnInsertarProducto
        '
        Me.btnInsertarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.btnInsertarProducto.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertarProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInsertarProducto.Location = New System.Drawing.Point(602, 9)
        Me.btnInsertarProducto.Name = "btnInsertarProducto"
        Me.btnInsertarProducto.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertarProducto.TabIndex = 110
        Me.btnInsertarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarProducto.UseVisualStyleBackColor = True
        '
        'btnBorrarProducto
        '
        Me.btnBorrarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.btnBorrarProducto.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnBorrarProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBorrarProducto.Location = New System.Drawing.Point(643, 9)
        Me.btnBorrarProducto.Name = "btnBorrarProducto"
        Me.btnBorrarProducto.Size = New System.Drawing.Size(37, 37)
        Me.btnBorrarProducto.TabIndex = 111
        Me.btnBorrarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBorrarProducto.UseVisualStyleBackColor = True
        '
        'txtCantidadProductoCanje
        '
        Me.txtCantidadProductoCanje.BindearPropiedadControl = "Text"
        Me.txtCantidadProductoCanje.BindearPropiedadEntidad = "CantidadProducto"
        Me.txtCantidadProductoCanje.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadProductoCanje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadProductoCanje.Formato = "N2"
        Me.txtCantidadProductoCanje.IsDecimal = True
        Me.txtCantidadProductoCanje.IsNumber = True
        Me.txtCantidadProductoCanje.IsPK = False
        Me.txtCantidadProductoCanje.IsRequired = False
        Me.txtCantidadProductoCanje.Key = ""
        Me.txtCantidadProductoCanje.LabelAsoc = Nothing
        Me.txtCantidadProductoCanje.Location = New System.Drawing.Point(511, 17)
        Me.txtCantidadProductoCanje.MaxLength = 6
        Me.txtCantidadProductoCanje.Name = "txtCantidadProductoCanje"
        Me.txtCantidadProductoCanje.Size = New System.Drawing.Size(69, 20)
        Me.txtCantidadProductoCanje.TabIndex = 109
        Me.txtCantidadProductoCanje.Text = "0,00"
        Me.txtCantidadProductoCanje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCodigoProductoCanje
        '
        Me.bscCodigoProductoCanje.ActivarFiltroEnGrilla = True
        Me.bscCodigoProductoCanje.BindearPropiedadControl = ""
        Me.bscCodigoProductoCanje.BindearPropiedadEntidad = ""
        Me.bscCodigoProductoCanje.ConfigBuscador = Nothing
        Me.bscCodigoProductoCanje.Datos = Nothing
        Me.bscCodigoProductoCanje.FilaDevuelta = Nothing
        Me.bscCodigoProductoCanje.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProductoCanje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProductoCanje.IsDecimal = False
        Me.bscCodigoProductoCanje.IsNumber = False
        Me.bscCodigoProductoCanje.IsPK = False
        Me.bscCodigoProductoCanje.IsRequired = False
        Me.bscCodigoProductoCanje.Key = ""
        Me.bscCodigoProductoCanje.LabelAsoc = Nothing
        Me.bscCodigoProductoCanje.Location = New System.Drawing.Point(90, 17)
        Me.bscCodigoProductoCanje.MaxLengh = "32767"
        Me.bscCodigoProductoCanje.Name = "bscCodigoProductoCanje"
        Me.bscCodigoProductoCanje.Permitido = True
        Me.bscCodigoProductoCanje.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProductoCanje.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProductoCanje.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProductoCanje.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProductoCanje.Selecciono = False
        Me.bscCodigoProductoCanje.Size = New System.Drawing.Size(81, 20)
        Me.bscCodigoProductoCanje.TabIndex = 107
        '
        'lblProductoCanje
        '
        Me.lblProductoCanje.AutoSize = True
        Me.lblProductoCanje.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProductoCanje.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProductoCanje.LabelAsoc = Nothing
        Me.lblProductoCanje.Location = New System.Drawing.Point(44, 20)
        Me.lblProductoCanje.Name = "lblProductoCanje"
        Me.lblProductoCanje.Size = New System.Drawing.Size(40, 13)
        Me.lblProductoCanje.TabIndex = 105
        Me.lblProductoCanje.Text = "Codigo"
        '
        'lblCantidadCanje
        '
        Me.lblCantidadCanje.AutoSize = True
        Me.lblCantidadCanje.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCantidadCanje.LabelAsoc = Nothing
        Me.lblCantidadCanje.Location = New System.Drawing.Point(456, 20)
        Me.lblCantidadCanje.Name = "lblCantidadCanje"
        Me.lblCantidadCanje.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidadCanje.TabIndex = 104
        Me.lblCantidadCanje.Text = "Cantidad"
        '
        'btnLimpiarProductos
        '
        Me.btnLimpiarProductos.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiarProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiarProductos.Location = New System.Drawing.Point(10, 12)
        Me.btnLimpiarProductos.Name = "btnLimpiarProductos"
        Me.btnLimpiarProductos.Size = New System.Drawing.Size(30, 30)
        Me.btnLimpiarProductos.TabIndex = 106
        Me.btnLimpiarProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarProductos.UseVisualStyleBackColor = True
        '
        'bscNombreProductoCanje
        '
        Me.bscNombreProductoCanje.ActivarFiltroEnGrilla = True
        Me.bscNombreProductoCanje.BindearPropiedadControl = Nothing
        Me.bscNombreProductoCanje.BindearPropiedadEntidad = Nothing
        Me.bscNombreProductoCanje.ConfigBuscador = Nothing
        Me.bscNombreProductoCanje.Datos = Nothing
        Me.bscNombreProductoCanje.FilaDevuelta = Nothing
        Me.bscNombreProductoCanje.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProductoCanje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProductoCanje.IsDecimal = False
        Me.bscNombreProductoCanje.IsNumber = False
        Me.bscNombreProductoCanje.IsPK = False
        Me.bscNombreProductoCanje.IsRequired = False
        Me.bscNombreProductoCanje.Key = ""
        Me.bscNombreProductoCanje.LabelAsoc = Nothing
        Me.bscNombreProductoCanje.Location = New System.Drawing.Point(177, 17)
        Me.bscNombreProductoCanje.MaxLengh = "32767"
        Me.bscNombreProductoCanje.Name = "bscNombreProductoCanje"
        Me.bscNombreProductoCanje.Permitido = True
        Me.bscNombreProductoCanje.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProductoCanje.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProductoCanje.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProductoCanje.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProductoCanje.Selecciono = False
        Me.bscNombreProductoCanje.Size = New System.Drawing.Size(273, 20)
        Me.bscNombreProductoCanje.TabIndex = 108
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 435)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(713, 22)
        Me.stsStado.TabIndex = 8
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(634, 17)
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtTotalGeneral)
        Me.GroupBox1.Controls.Add(Me.lblTotalGeneral)
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbTipoComprobante)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 369)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 57)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'txtTotalGeneral
        '
        Me.txtTotalGeneral.BindearPropiedadControl = Nothing
        Me.txtTotalGeneral.BindearPropiedadEntidad = Nothing
        Me.txtTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtTotalGeneral.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalGeneral.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalGeneral.Formato = "##,##0.00"
        Me.txtTotalGeneral.IsDecimal = True
        Me.txtTotalGeneral.IsNumber = True
        Me.txtTotalGeneral.IsPK = False
        Me.txtTotalGeneral.IsRequired = False
        Me.txtTotalGeneral.Key = ""
        Me.txtTotalGeneral.LabelAsoc = Nothing
        Me.txtTotalGeneral.Location = New System.Drawing.Point(360, 14)
        Me.txtTotalGeneral.Name = "txtTotalGeneral"
        Me.txtTotalGeneral.ReadOnly = True
        Me.txtTotalGeneral.Size = New System.Drawing.Size(123, 31)
        Me.txtTotalGeneral.TabIndex = 109
        Me.txtTotalGeneral.TabStop = False
        Me.txtTotalGeneral.Text = "0.00"
        Me.txtTotalGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalGeneral
        '
        Me.lblTotalGeneral.AutoSize = True
        Me.lblTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotalGeneral.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalGeneral.LabelAsoc = Nothing
        Me.lblTotalGeneral.Location = New System.Drawing.Point(289, 18)
        Me.lblTotalGeneral.Name = "lblTotalGeneral"
        Me.lblTotalGeneral.Size = New System.Drawing.Size(65, 25)
        Me.lblTotalGeneral.TabIndex = 108
        Me.lblTotalGeneral.Text = "Total"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(513, 15)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 107
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(599, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 106
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(10, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Tipo Comprobante"
        '
        'cmbTipoComprobante
        '
        Me.cmbTipoComprobante.BindearPropiedadControl = Nothing
        Me.cmbTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.cmbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobante.FormattingEnabled = True
        Me.cmbTipoComprobante.IsPK = False
        Me.cmbTipoComprobante.IsRequired = False
        Me.cmbTipoComprobante.ItemHeight = 13
        Me.cmbTipoComprobante.Key = Nothing
        Me.cmbTipoComprobante.LabelAsoc = Nothing
        Me.cmbTipoComprobante.Location = New System.Drawing.Point(110, 21)
        Me.cmbTipoComprobante.Name = "cmbTipoComprobante"
        Me.cmbTipoComprobante.Size = New System.Drawing.Size(163, 21)
        Me.cmbTipoComprobante.TabIndex = 5
        '
        'FacturacionUtilizaCanje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 457)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.grbProductosCanje)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FacturacionUtilizaCanje"
        Me.Text = "Canje de Productos"
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbProductosCanje.ResumeLayout(False)
        Me.grbProductosCanje.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDetalle As Controles.DataGridView
    Friend WithEvents grbProductosCanje As GroupBox
   Protected Friend WithEvents stsStado As StatusStrip
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As ToolStripProgressBar
   Protected WithEvents tssRegistros As ToolStripStatusLabel
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents cmbTipoComprobante As Controles.ComboBox
   Friend WithEvents txtCantidadProductoCanje As Controles.TextBox
   Friend WithEvents bscCodigoProductoCanje As Controles.Buscador2
   Friend WithEvents lblProductoCanje As Controles.Label
   Friend WithEvents lblCantidadCanje As Controles.Label
   Friend WithEvents btnLimpiarProductos As Controles.Button
   Friend WithEvents bscNombreProductoCanje As Controles.Buscador2
   Friend WithEvents btnInsertarProducto As Controles.Button
   Friend WithEvents btnBorrarProducto As Controles.Button
   Friend WithEvents Label1 As Controles.Label
   Protected WithEvents btnAceptar As Button
   Private WithEvents imageList1 As ImageList
   Protected WithEvents btnCancelar As Button
   Friend WithEvents txtTotalGeneral As Controles.TextBox
   Friend WithEvents lblTotalGeneral As Controles.Label
    Friend WithEvents IdTipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionAbrev As DataGridViewTextBoxColumn
    Friend WithEvents IdaAtributoProducto01 As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionAtributo01 As DataGridViewTextBoxColumn
    Friend WithEvents IdaAtributoProducto02 As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionAtributo02 As DataGridViewTextBoxColumn
    Friend WithEvents IdaAtributoProducto03 As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionAtributo03 As DataGridViewTextBoxColumn
    Friend WithEvents IdaAtributoProducto04 As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionAtributo04 As DataGridViewTextBoxColumn
    Friend WithEvents CantidadCanje As DataGridViewTextBoxColumn
    Friend WithEvents ImporteTotal As DataGridViewTextBoxColumn
    Friend WithEvents StockCanje As DataGridViewTextBoxColumn
    Friend WithEvents ImporteCanje As DataGridViewTextBoxColumn
End Class
