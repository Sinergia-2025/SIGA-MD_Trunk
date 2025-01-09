<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChequesDetalleAyuda
   Inherits BaseForm


   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChequesDetalleAyuda))
      Me.txtImporteTotal = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.chbTipoCheque = New System.Windows.Forms.CheckBox()
      Me.cmbTiposCheques = New Eniac.Controles.ComboBox()
      Me.lblFechaCobroHasta = New Eniac.Controles.Label()
      Me.lblFechaCobroDesde = New Eniac.Controles.Label()
      Me.chbBanco = New Eniac.Controles.CheckBox()
      Me.chbTitular = New Eniac.Controles.CheckBox()
      Me.txtTitular = New Eniac.Controles.TextBox()
      Me.chbLocalidad = New Eniac.Controles.CheckBox()
      Me.cmbLocalidad = New Eniac.Controles.ComboBox()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.chbFechaEnCarteraAl = New Eniac.Controles.CheckBox()
      Me.dtpFechaEnCarteraAl = New Eniac.Controles.DateTimePicker()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.bscProveedor = New Eniac.Controles.Buscador2()
      Me.lblNombreProv = New Eniac.Controles.Label()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.cmbBancos = New Eniac.Controles.ComboBox()
      Me.dpFechaCobroHasta = New Eniac.Controles.DateTimePicker()
      Me.dpFechaCobroDesde = New Eniac.Controles.DateTimePicker()
      Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IdCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreTipoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdTipoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdBancoSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Localidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Titular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEstadoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroPlanillaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroMovimientoIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservacionIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroPlanillaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroMovimientoEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservacionEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEstadoChequeAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCajaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCajaIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCajaEgreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtImporteTotal
        '
        Me.txtImporteTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImporteTotal.BindearPropiedadControl = Nothing
        Me.txtImporteTotal.BindearPropiedadEntidad = Nothing
        Me.txtImporteTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteTotal.Formato = "##0.00"
        Me.txtImporteTotal.IsDecimal = True
        Me.txtImporteTotal.IsNumber = True
        Me.txtImporteTotal.IsPK = False
        Me.txtImporteTotal.IsRequired = False
        Me.txtImporteTotal.Key = ""
        Me.txtImporteTotal.LabelAsoc = Nothing
        Me.txtImporteTotal.Location = New System.Drawing.Point(568, 465)
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.ReadOnly = True
        Me.txtImporteTotal.Size = New System.Drawing.Size(75, 20)
        Me.txtImporteTotal.TabIndex = 52
        Me.txtImporteTotal.Text = "0.00"
        Me.txtImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(528, 469)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Total:"
        '
        'chbTodos
        '
        Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.ImageIndex = 0
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(12, 463)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(124, 24)
        Me.chbTodos.TabIndex = 15
        Me.chbTodos.Text = "Chequear Todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_a_16
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(798, 455)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(712, 455)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToOrderColumns = True
        Me.dgvDetalle.AllowUserToResizeRows = False
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check, Me.IdCheque, Me.NombreTipoCheque, Me.IdTipoCheque, Me.IdBanco, Me.NombreBanco, Me.IdBancoSucursal, Me.IdLocalidad, Me.Localidad, Me.NumeroCheque, Me.NroOperacion, Me.FechaEmision, Me.FechaCobro, Me.Titular, Me.Importe, Me.IdEstadoCheque, Me.NroPlanillaIngreso, Me.NroMovimientoIngreso, Me.ObservacionIngreso, Me.FechaIngreso, Me.NroPlanillaEgreso, Me.NroMovimientoEgreso, Me.ObservacionEgreso, Me.FechaEgreso, Me.IdEstadoChequeAnt, Me.IdCajaIngreso, Me.NombreCajaIngreso, Me.CodigoCliente, Me.IdCliente, Me.NombreCliente, Me.Cuit, Me.IdCajaEgreso, Me.IdProveedor, Me.CodigoProveedor, Me.NombreProveedor})
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 234)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(866, 215)
        Me.dgvDetalle.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chbTipoCheque)
        Me.GroupBox1.Controls.Add(Me.cmbTiposCheques)
        Me.GroupBox1.Controls.Add(Me.lblFechaCobroHasta)
        Me.GroupBox1.Controls.Add(Me.lblFechaCobroDesde)
        Me.GroupBox1.Controls.Add(Me.chbBanco)
        Me.GroupBox1.Controls.Add(Me.chbTitular)
        Me.GroupBox1.Controls.Add(Me.txtTitular)
        Me.GroupBox1.Controls.Add(Me.chbLocalidad)
        Me.GroupBox1.Controls.Add(Me.cmbLocalidad)
        Me.GroupBox1.Controls.Add(Me.chbNumero)
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.chbFechaEnCarteraAl)
        Me.GroupBox1.Controls.Add(Me.dtpFechaEnCarteraAl)
        Me.GroupBox1.Controls.Add(Me.bscCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.bscProveedor)
        Me.GroupBox1.Controls.Add(Me.lblCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.lblNombreProv)
        Me.GroupBox1.Controls.Add(Me.chbProveedor)
        Me.GroupBox1.Controls.Add(Me.bscCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.bscCliente)
        Me.GroupBox1.Controls.Add(Me.lblCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.Controls.Add(Me.chbCliente)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.cmbBancos)
        Me.GroupBox1.Controls.Add(Me.dpFechaCobroHasta)
        Me.GroupBox1.Controls.Add(Me.dpFechaCobroDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(866, 221)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'chbTipoCheque
        '
        Me.chbTipoCheque.AutoSize = True
        Me.chbTipoCheque.Location = New System.Drawing.Point(21, 196)
        Me.chbTipoCheque.Name = "chbTipoCheque"
        Me.chbTipoCheque.Size = New System.Drawing.Size(102, 17)
        Me.chbTipoCheque.TabIndex = 27
        Me.chbTipoCheque.Text = "Tipo de Cheque"
        Me.chbTipoCheque.UseVisualStyleBackColor = True
        '
        'cmbTiposCheques
        '
        Me.cmbTiposCheques.BindearPropiedadControl = ""
        Me.cmbTiposCheques.BindearPropiedadEntidad = ""
        Me.cmbTiposCheques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposCheques.Enabled = False
        Me.cmbTiposCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposCheques.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposCheques.FormattingEnabled = True
        Me.cmbTiposCheques.IsPK = False
        Me.cmbTiposCheques.IsRequired = True
        Me.cmbTiposCheques.Key = Nothing
        Me.cmbTiposCheques.LabelAsoc = Nothing
        Me.cmbTiposCheques.Location = New System.Drawing.Point(129, 194)
        Me.cmbTiposCheques.Name = "cmbTiposCheques"
        Me.cmbTiposCheques.Size = New System.Drawing.Size(114, 21)
        Me.cmbTiposCheques.TabIndex = 25
        '
        'lblFechaCobroHasta
        '
        Me.lblFechaCobroHasta.AutoSize = True
        Me.lblFechaCobroHasta.LabelAsoc = Nothing
        Me.lblFechaCobroHasta.Location = New System.Drawing.Point(247, 23)
        Me.lblFechaCobroHasta.Name = "lblFechaCobroHasta"
        Me.lblFechaCobroHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaCobroHasta.TabIndex = 2
        Me.lblFechaCobroHasta.Text = "Hasta"
        '
        'lblFechaCobroDesde
        '
        Me.lblFechaCobroDesde.AutoSize = True
        Me.lblFechaCobroDesde.LabelAsoc = Nothing
        Me.lblFechaCobroDesde.Location = New System.Drawing.Point(18, 23)
        Me.lblFechaCobroDesde.Name = "lblFechaCobroDesde"
        Me.lblFechaCobroDesde.Size = New System.Drawing.Size(123, 13)
        Me.lblFechaCobroDesde.TabIndex = 0
        Me.lblFechaCobroDesde.Text = "Fecha de Cobro:  Desde"
        '
        'chbBanco
        '
        Me.chbBanco.AutoSize = True
        Me.chbBanco.BindearPropiedadControl = Nothing
        Me.chbBanco.BindearPropiedadEntidad = Nothing
        Me.chbBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.chbBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbBanco.IsPK = False
        Me.chbBanco.IsRequired = False
        Me.chbBanco.Key = Nothing
        Me.chbBanco.LabelAsoc = Nothing
        Me.chbBanco.Location = New System.Drawing.Point(21, 51)
        Me.chbBanco.Name = "chbBanco"
        Me.chbBanco.Size = New System.Drawing.Size(57, 17)
        Me.chbBanco.TabIndex = 8
        Me.chbBanco.Text = "Banco"
        Me.chbBanco.UseVisualStyleBackColor = True
        '
        'chbTitular
        '
        Me.chbTitular.AutoSize = True
        Me.chbTitular.BindearPropiedadControl = Nothing
        Me.chbTitular.BindearPropiedadEntidad = Nothing
        Me.chbTitular.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTitular.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTitular.IsPK = False
        Me.chbTitular.IsRequired = False
        Me.chbTitular.Key = Nothing
        Me.chbTitular.LabelAsoc = Nothing
        Me.chbTitular.Location = New System.Drawing.Point(21, 164)
        Me.chbTitular.Name = "chbTitular"
        Me.chbTitular.Size = New System.Drawing.Size(55, 17)
        Me.chbTitular.TabIndex = 22
        Me.chbTitular.Text = "Titular"
        Me.chbTitular.UseVisualStyleBackColor = True
        '
        'txtTitular
        '
        Me.txtTitular.BindearPropiedadControl = "Text"
        Me.txtTitular.BindearPropiedadEntidad = "Titular"
        Me.txtTitular.Enabled = False
        Me.txtTitular.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTitular.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTitular.Formato = ""
        Me.txtTitular.IsDecimal = False
        Me.txtTitular.IsNumber = False
        Me.txtTitular.IsPK = False
        Me.txtTitular.IsRequired = True
        Me.txtTitular.Key = "Titular"
        Me.txtTitular.LabelAsoc = Nothing
        Me.txtTitular.Location = New System.Drawing.Point(101, 161)
        Me.txtTitular.MaxLength = 40
        Me.txtTitular.Name = "txtTitular"
        Me.txtTitular.Size = New System.Drawing.Size(343, 20)
        Me.txtTitular.TabIndex = 23
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
        Me.chbLocalidad.Location = New System.Drawing.Point(306, 53)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 10
        Me.chbLocalidad.Text = "Localidad"
        Me.chbLocalidad.UseVisualStyleBackColor = True
        '
        'cmbLocalidad
        '
        Me.cmbLocalidad.BindearPropiedadControl = ""
        Me.cmbLocalidad.BindearPropiedadEntidad = ""
        Me.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocalidad.Enabled = False
        Me.cmbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLocalidad.FormattingEnabled = True
        Me.cmbLocalidad.IsPK = False
        Me.cmbLocalidad.IsRequired = True
        Me.cmbLocalidad.Key = Nothing
        Me.cmbLocalidad.LabelAsoc = Nothing
        Me.cmbLocalidad.Location = New System.Drawing.Point(381, 51)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(160, 21)
        Me.cmbLocalidad.TabIndex = 11
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
        Me.chbNumero.Location = New System.Drawing.Point(626, 21)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 6
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
        Me.txtNumero.Location = New System.Drawing.Point(689, 19)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(73, 20)
        Me.txtNumero.TabIndex = 7
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbFechaEnCarteraAl
        '
        Me.chbFechaEnCarteraAl.AutoSize = True
        Me.chbFechaEnCarteraAl.BindearPropiedadControl = Nothing
        Me.chbFechaEnCarteraAl.BindearPropiedadEntidad = Nothing
        Me.chbFechaEnCarteraAl.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEnCarteraAl.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEnCarteraAl.IsPK = False
        Me.chbFechaEnCarteraAl.IsRequired = False
        Me.chbFechaEnCarteraAl.Key = Nothing
        Me.chbFechaEnCarteraAl.LabelAsoc = Nothing
        Me.chbFechaEnCarteraAl.Location = New System.Drawing.Point(406, 21)
        Me.chbFechaEnCarteraAl.Name = "chbFechaEnCarteraAl"
        Me.chbFechaEnCarteraAl.Size = New System.Drawing.Size(88, 17)
        Me.chbFechaEnCarteraAl.TabIndex = 4
        Me.chbFechaEnCarteraAl.Text = "En Cartera Al"
        Me.chbFechaEnCarteraAl.UseVisualStyleBackColor = True
        '
        'dtpFechaEnCarteraAl
        '
        Me.dtpFechaEnCarteraAl.BindearPropiedadControl = Nothing
        Me.dtpFechaEnCarteraAl.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEnCarteraAl.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaEnCarteraAl.Enabled = False
        Me.dtpFechaEnCarteraAl.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEnCarteraAl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEnCarteraAl.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEnCarteraAl.IsPK = False
        Me.dtpFechaEnCarteraAl.IsRequired = False
        Me.dtpFechaEnCarteraAl.Key = ""
        Me.dtpFechaEnCarteraAl.LabelAsoc = Nothing
        Me.dtpFechaEnCarteraAl.Location = New System.Drawing.Point(497, 19)
        Me.dtpFechaEnCarteraAl.Name = "dtpFechaEnCarteraAl"
        Me.dtpFechaEnCarteraAl.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEnCarteraAl.TabIndex = 5
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ConfigBuscador = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.Enabled = False
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = False
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(101, 131)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 19
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(98, 117)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProveedor.TabIndex = 18
        Me.lblCodigoProveedor.Text = "Código"
        '
        'bscProveedor
        '
        Me.bscProveedor.ActivarFiltroEnGrilla = True
        Me.bscProveedor.AutoSize = True
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ConfigBuscador = Nothing
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
        Me.bscProveedor.LabelAsoc = Me.lblNombreProv
        Me.bscProveedor.Location = New System.Drawing.Point(198, 131)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(300, 23)
        Me.bscProveedor.TabIndex = 21
        '
        'lblNombreProv
        '
        Me.lblNombreProv.AutoSize = True
        Me.lblNombreProv.LabelAsoc = Nothing
        Me.lblNombreProv.Location = New System.Drawing.Point(195, 117)
        Me.lblNombreProv.Name = "lblNombreProv"
        Me.lblNombreProv.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreProv.TabIndex = 20
        Me.lblNombreProv.Text = "Nombre"
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
        Me.chbProveedor.Location = New System.Drawing.Point(21, 134)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 17
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
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
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(101, 90)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 14
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(98, 76)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 13
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
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
        Me.bscCliente.Location = New System.Drawing.Point(198, 90)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(317, 23)
        Me.bscCliente.TabIndex = 16
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(195, 76)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "Nombre"
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
        Me.chbCliente.Location = New System.Drawing.Point(21, 96)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 12
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(736, 124)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 26
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'cmbBancos
        '
        Me.cmbBancos.BindearPropiedadControl = Nothing
        Me.cmbBancos.BindearPropiedadEntidad = Nothing
        Me.cmbBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBancos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBancos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbBancos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbBancos.FormattingEnabled = True
        Me.cmbBancos.IsPK = False
        Me.cmbBancos.IsRequired = False
        Me.cmbBancos.Key = Nothing
        Me.cmbBancos.LabelAsoc = Nothing
        Me.cmbBancos.Location = New System.Drawing.Point(81, 49)
        Me.cmbBancos.Name = "cmbBancos"
        Me.cmbBancos.Size = New System.Drawing.Size(159, 21)
        Me.cmbBancos.TabIndex = 9
        Me.cmbBancos.TabStop = False
        '
        'dpFechaCobroHasta
        '
        Me.dpFechaCobroHasta.BindearPropiedadControl = Nothing
        Me.dpFechaCobroHasta.BindearPropiedadEntidad = Nothing
        Me.dpFechaCobroHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dpFechaCobroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dpFechaCobroHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaCobroHasta.IsPK = False
        Me.dpFechaCobroHasta.IsRequired = False
        Me.dpFechaCobroHasta.Key = ""
        Me.dpFechaCobroHasta.LabelAsoc = Nothing
        Me.dpFechaCobroHasta.Location = New System.Drawing.Point(285, 19)
        Me.dpFechaCobroHasta.Name = "dpFechaCobroHasta"
        Me.dpFechaCobroHasta.Size = New System.Drawing.Size(95, 20)
        Me.dpFechaCobroHasta.TabIndex = 3
        '
        'dpFechaCobroDesde
        '
        Me.dpFechaCobroDesde.BindearPropiedadControl = Nothing
        Me.dpFechaCobroDesde.BindearPropiedadEntidad = Nothing
        Me.dpFechaCobroDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dpFechaCobroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dpFechaCobroDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaCobroDesde.IsPK = False
        Me.dpFechaCobroDesde.IsRequired = False
        Me.dpFechaCobroDesde.Key = ""
        Me.dpFechaCobroDesde.LabelAsoc = Nothing
        Me.dpFechaCobroDesde.Location = New System.Drawing.Point(146, 19)
        Me.dpFechaCobroDesde.Name = "dpFechaCobroDesde"
        Me.dpFechaCobroDesde.Size = New System.Drawing.Size(95, 20)
        Me.dpFechaCobroDesde.TabIndex = 1
        '
        'Check
        '
        Me.Check.DataPropertyName = "Check"
        Me.Check.HeaderText = ""
        Me.Check.Name = "Check"
        Me.Check.Width = 30
        '
        'IdCheque
        '
        Me.IdCheque.DataPropertyName = "IdCheque"
        Me.IdCheque.HeaderText = "IdCheque"
        Me.IdCheque.Name = "IdCheque"
        Me.IdCheque.Visible = False
        '
        'NombreTipoCheque
        '
        Me.NombreTipoCheque.DataPropertyName = "NombreTipoCheque"
        Me.NombreTipoCheque.HeaderText = "Tipo de Cheque"
        Me.NombreTipoCheque.Name = "NombreTipoCheque"
        '
        'IdTipoCheque
        '
        Me.IdTipoCheque.DataPropertyName = "IdTipoCheque"
        Me.IdTipoCheque.HeaderText = "IdTipoCheque"
        Me.IdTipoCheque.Name = "IdTipoCheque"
        Me.IdTipoCheque.Visible = False
        '
        'IdBanco
        '
        Me.IdBanco.DataPropertyName = "IdBanco"
        Me.IdBanco.HeaderText = "IdBanco"
        Me.IdBanco.Name = "IdBanco"
        Me.IdBanco.ReadOnly = True
        Me.IdBanco.Visible = False
        '
        'NombreBanco
        '
        Me.NombreBanco.DataPropertyName = "NombreBanco"
        Me.NombreBanco.HeaderText = "Banco"
        Me.NombreBanco.Name = "NombreBanco"
        Me.NombreBanco.ReadOnly = True
        Me.NombreBanco.Width = 120
        '
        'IdBancoSucursal
        '
        Me.IdBancoSucursal.DataPropertyName = "IdBancoSucursal"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdBancoSucursal.DefaultCellStyle = DataGridViewCellStyle1
        Me.IdBancoSucursal.HeaderText = "Suc."
        Me.IdBancoSucursal.Name = "IdBancoSucursal"
        Me.IdBancoSucursal.ReadOnly = True
        Me.IdBancoSucursal.Width = 50
        '
        'IdLocalidad
        '
        Me.IdLocalidad.DataPropertyName = "IdLocalidad"
        Me.IdLocalidad.HeaderText = "IdLocalidad"
        Me.IdLocalidad.Name = "IdLocalidad"
        Me.IdLocalidad.ReadOnly = True
        Me.IdLocalidad.Visible = False
        '
        'Localidad
        '
        Me.Localidad.DataPropertyName = "NombreLocalidad"
        Me.Localidad.HeaderText = "Localidad"
        Me.Localidad.Name = "Localidad"
        Me.Localidad.ReadOnly = True
        '
        'NumeroCheque
        '
        Me.NumeroCheque.DataPropertyName = "NumeroCheque"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumeroCheque.DefaultCellStyle = DataGridViewCellStyle2
        Me.NumeroCheque.HeaderText = "Numero"
        Me.NumeroCheque.Name = "NumeroCheque"
        Me.NumeroCheque.ReadOnly = True
        Me.NumeroCheque.Width = 80
        '
        'NroOperacion
        '
        Me.NroOperacion.DataPropertyName = "NroOperacion"
        Me.NroOperacion.HeaderText = "Nro. Operación"
        Me.NroOperacion.Name = "NroOperacion"
        '
        'FechaEmision
        '
        Me.FechaEmision.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        Me.FechaEmision.DefaultCellStyle = DataGridViewCellStyle3
        Me.FechaEmision.HeaderText = "Emisión"
        Me.FechaEmision.Name = "FechaEmision"
        Me.FechaEmision.ReadOnly = True
        Me.FechaEmision.Visible = False
        Me.FechaEmision.Width = 70
        '
        'FechaCobro
        '
        Me.FechaCobro.DataPropertyName = "FechaCobro"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "dd/MM/yyyy"
        Me.FechaCobro.DefaultCellStyle = DataGridViewCellStyle4
        Me.FechaCobro.HeaderText = "Cobro"
        Me.FechaCobro.Name = "FechaCobro"
        Me.FechaCobro.ReadOnly = True
        Me.FechaCobro.Width = 70
        '
        'Titular
        '
        Me.Titular.DataPropertyName = "Titular"
        Me.Titular.HeaderText = "Titular"
        Me.Titular.Name = "Titular"
        Me.Titular.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle5
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 80
        '
        'IdEstadoCheque
        '
        Me.IdEstadoCheque.DataPropertyName = "IdEstadoCheque"
        Me.IdEstadoCheque.HeaderText = "Estado"
        Me.IdEstadoCheque.Name = "IdEstadoCheque"
        Me.IdEstadoCheque.ReadOnly = True
        '
        'NroPlanillaIngreso
        '
        Me.NroPlanillaIngreso.DataPropertyName = "NroPlanillaIngreso"
        Me.NroPlanillaIngreso.HeaderText = "Nro Planilla Ingreso"
        Me.NroPlanillaIngreso.Name = "NroPlanillaIngreso"
        Me.NroPlanillaIngreso.ReadOnly = True
        Me.NroPlanillaIngreso.Visible = False
        Me.NroPlanillaIngreso.Width = 120
        '
        'NroMovimientoIngreso
        '
        Me.NroMovimientoIngreso.DataPropertyName = "NroMovimientoIngreso"
        Me.NroMovimientoIngreso.HeaderText = "Nro Movimiento Ingreso"
        Me.NroMovimientoIngreso.Name = "NroMovimientoIngreso"
        Me.NroMovimientoIngreso.ReadOnly = True
        Me.NroMovimientoIngreso.Visible = False
        '
        'ObservacionIngreso
        '
        Me.ObservacionIngreso.DataPropertyName = "ObservacionIngreso"
        Me.ObservacionIngreso.HeaderText = "ObservacionIngreso"
        Me.ObservacionIngreso.Name = "ObservacionIngreso"
        Me.ObservacionIngreso.ReadOnly = True
        Me.ObservacionIngreso.Visible = False
        '
        'FechaIngreso
        '
        Me.FechaIngreso.DataPropertyName = "FechaIngreso"
        Me.FechaIngreso.HeaderText = "FechaIngreso"
        Me.FechaIngreso.Name = "FechaIngreso"
        Me.FechaIngreso.Visible = False
        '
        'NroPlanillaEgreso
        '
        Me.NroPlanillaEgreso.DataPropertyName = "NroPlanillaEgreso"
        Me.NroPlanillaEgreso.HeaderText = "Nro Planilla Egreso"
        Me.NroPlanillaEgreso.Name = "NroPlanillaEgreso"
        Me.NroPlanillaEgreso.ReadOnly = True
        Me.NroPlanillaEgreso.Visible = False
        '
        'NroMovimientoEgreso
        '
        Me.NroMovimientoEgreso.DataPropertyName = "NroMovimientoEgreso"
        Me.NroMovimientoEgreso.HeaderText = "Nro Movimiento Egreso"
        Me.NroMovimientoEgreso.Name = "NroMovimientoEgreso"
        Me.NroMovimientoEgreso.ReadOnly = True
        Me.NroMovimientoEgreso.Visible = False
        '
        'ObservacionEgreso
        '
        Me.ObservacionEgreso.DataPropertyName = "ObservacionEgreso"
        Me.ObservacionEgreso.HeaderText = "ObservacionEgreso"
        Me.ObservacionEgreso.Name = "ObservacionEgreso"
        Me.ObservacionEgreso.ReadOnly = True
        Me.ObservacionEgreso.Visible = False
        '
        'FechaEgreso
        '
        Me.FechaEgreso.DataPropertyName = "FechaEgreso"
        Me.FechaEgreso.HeaderText = "FechaEgreso"
        Me.FechaEgreso.Name = "FechaEgreso"
        Me.FechaEgreso.ReadOnly = True
        Me.FechaEgreso.Visible = False
        '
        'IdEstadoChequeAnt
        '
        Me.IdEstadoChequeAnt.DataPropertyName = "IdEstadoChequeAnt"
        Me.IdEstadoChequeAnt.HeaderText = "IdEstadoChequeAnt"
        Me.IdEstadoChequeAnt.Name = "IdEstadoChequeAnt"
        Me.IdEstadoChequeAnt.ReadOnly = True
        Me.IdEstadoChequeAnt.Visible = False
        '
        'IdCajaIngreso
        '
        Me.IdCajaIngreso.DataPropertyName = "IdCajaIngreso"
        Me.IdCajaIngreso.HeaderText = "IdCajaIngreso"
        Me.IdCajaIngreso.Name = "IdCajaIngreso"
        Me.IdCajaIngreso.ReadOnly = True
        Me.IdCajaIngreso.Visible = False
        '
        'NombreCajaIngreso
        '
        Me.NombreCajaIngreso.DataPropertyName = "NombreCajaIngreso"
        Me.NombreCajaIngreso.HeaderText = "NombreCajaIngreso"
        Me.NombreCajaIngreso.Name = "NombreCajaIngreso"
        Me.NombreCajaIngreso.Visible = False
        '
        'CodigoCliente
        '
        Me.CodigoCliente.DataPropertyName = "CodigoCliente"
        Me.CodigoCliente.HeaderText = "CodigoCliente"
        Me.CodigoCliente.Name = "CodigoCliente"
        Me.CodigoCliente.Visible = False
        '
        'IdCliente
        '
        Me.IdCliente.DataPropertyName = "IdCliente"
        Me.IdCliente.HeaderText = "IdCliente"
        Me.IdCliente.Name = "IdCliente"
        Me.IdCliente.Visible = False
        '
        'NombreCliente
        '
        Me.NombreCliente.DataPropertyName = "NombreCliente"
        Me.NombreCliente.HeaderText = "Cliente"
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.Width = 150
        '
        'Cuit
        '
        Me.Cuit.DataPropertyName = "Cuit"
        Me.Cuit.HeaderText = "Cuit"
        Me.Cuit.Name = "Cuit"
        '
        'IdCajaEgreso
        '
        Me.IdCajaEgreso.DataPropertyName = "IdCajaEgreso"
        Me.IdCajaEgreso.HeaderText = "IdCajaEgreso"
        Me.IdCajaEgreso.Name = "IdCajaEgreso"
        Me.IdCajaEgreso.ReadOnly = True
        Me.IdCajaEgreso.Visible = False
        '
        'IdProveedor
        '
        Me.IdProveedor.DataPropertyName = "IdProveedor"
        Me.IdProveedor.HeaderText = "IdProveedor"
        Me.IdProveedor.Name = "IdProveedor"
        Me.IdProveedor.Visible = False
        '
        'CodigoProveedor
        '
        Me.CodigoProveedor.DataPropertyName = "CodigoProveedor"
        Me.CodigoProveedor.HeaderText = "CodigoProveedor"
        Me.CodigoProveedor.Name = "CodigoProveedor"
        Me.CodigoProveedor.Visible = False
        '
        'NombreProveedor
        '
        Me.NombreProveedor.DataPropertyName = "NombreProveedor"
        Me.NombreProveedor.HeaderText = "Proveedor"
        Me.NombreProveedor.Name = "NombreProveedor"
        Me.NombreProveedor.Width = 150
        '
        'ChequesDetalleAyuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 492)
        Me.Controls.Add(Me.txtImporteTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ChequesDetalleAyuda"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cheques"
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView

   Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents dpFechaCobroDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents dpFechaCobroHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents cmbBancos As Eniac.Controles.ComboBox
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents txtImporteTotal As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador2
   Friend WithEvents lblNombreProv As Eniac.Controles.Label
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents chbFechaEnCarteraAl As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaEnCarteraAl As Eniac.Controles.DateTimePicker
   Friend WithEvents chbLocalidad As Eniac.Controles.CheckBox
   Friend WithEvents cmbLocalidad As Eniac.Controles.ComboBox
   Friend WithEvents chbTitular As Eniac.Controles.CheckBox
   Friend WithEvents txtTitular As Eniac.Controles.TextBox
   Friend WithEvents chbBanco As Eniac.Controles.CheckBox
   Friend WithEvents lblFechaCobroDesde As Eniac.Controles.Label
   Friend WithEvents lblFechaCobroHasta As Eniac.Controles.Label
   Friend WithEvents cmbTiposCheques As Eniac.Controles.ComboBox
   Friend WithEvents chbTipoCheque As System.Windows.Forms.CheckBox
    Friend WithEvents Check As DataGridViewCheckBoxColumn
    Friend WithEvents IdCheque As DataGridViewTextBoxColumn
    Friend WithEvents NombreTipoCheque As DataGridViewTextBoxColumn
    Friend WithEvents IdTipoCheque As DataGridViewTextBoxColumn
    Friend WithEvents IdBanco As DataGridViewTextBoxColumn
    Friend WithEvents NombreBanco As DataGridViewTextBoxColumn
    Friend WithEvents IdBancoSucursal As DataGridViewTextBoxColumn
    Friend WithEvents IdLocalidad As DataGridViewTextBoxColumn
    Friend WithEvents Localidad As DataGridViewTextBoxColumn
    Friend WithEvents NumeroCheque As DataGridViewTextBoxColumn
    Friend WithEvents NroOperacion As DataGridViewTextBoxColumn
    Friend WithEvents FechaEmision As DataGridViewTextBoxColumn
    Friend WithEvents FechaCobro As DataGridViewTextBoxColumn
    Friend WithEvents Titular As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents IdEstadoCheque As DataGridViewTextBoxColumn
    Friend WithEvents NroPlanillaIngreso As DataGridViewTextBoxColumn
    Friend WithEvents NroMovimientoIngreso As DataGridViewTextBoxColumn
    Friend WithEvents ObservacionIngreso As DataGridViewTextBoxColumn
    Friend WithEvents FechaIngreso As DataGridViewTextBoxColumn
    Friend WithEvents NroPlanillaEgreso As DataGridViewTextBoxColumn
    Friend WithEvents NroMovimientoEgreso As DataGridViewTextBoxColumn
    Friend WithEvents ObservacionEgreso As DataGridViewTextBoxColumn
    Friend WithEvents FechaEgreso As DataGridViewTextBoxColumn
    Friend WithEvents IdEstadoChequeAnt As DataGridViewTextBoxColumn
    Friend WithEvents IdCajaIngreso As DataGridViewTextBoxColumn
    Friend WithEvents NombreCajaIngreso As DataGridViewTextBoxColumn
    Friend WithEvents CodigoCliente As DataGridViewTextBoxColumn
    Friend WithEvents IdCliente As DataGridViewTextBoxColumn
    Friend WithEvents NombreCliente As DataGridViewTextBoxColumn
    Friend WithEvents Cuit As DataGridViewTextBoxColumn
    Friend WithEvents IdCajaEgreso As DataGridViewTextBoxColumn
    Friend WithEvents IdProveedor As DataGridViewTextBoxColumn
    Friend WithEvents CodigoProveedor As DataGridViewTextBoxColumn
    Friend WithEvents NombreProveedor As DataGridViewTextBoxColumn
End Class
