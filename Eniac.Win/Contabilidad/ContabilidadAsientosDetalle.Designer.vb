<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadAsientosDetalle
   Inherits Eniac.Win.BaseDetalle

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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContabilidadAsientosDetalle))
        Me.lblNro = New Eniac.Controles.Label()
        Me.txtNumeroAsiento = New Eniac.Controles.TextBox()
        Me.lblFecha = New Eniac.Controles.Label()
        Me.lbloncept = New Eniac.Controles.Label()
        Me.txtConcepto = New Eniac.Controles.TextBox()
        Me.grdAsientosDetalle = New Eniac.Controles.DataGridView()
        Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCentroCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.debe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.haber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdTipoReferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCentroCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTotales = New Eniac.Controles.Label()
        Me.txtTotalDebe = New Eniac.Controles.TextBox()
        Me.txtTotalHaber = New Eniac.Controles.TextBox()
        Me.lblCta = New Eniac.Controles.Label()
        Me.bscCodCuenta = New Eniac.Controles.Buscador()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCentroCosto = New Eniac.Controles.ComboBox()
        Me.lblCentroCosto = New Eniac.Controles.Label()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.cmdPlan = New System.Windows.Forms.Button()
        Me.lblHaber = New Eniac.Controles.Label()
        Me.lbldebe = New Eniac.Controles.Label()
        Me.lblDesc = New Eniac.Controles.Label()
        Me.txtHaber = New Eniac.Controles.TextBox()
        Me.txtDebe = New Eniac.Controles.TextBox()
        Me.bscDescripcion = New Eniac.Controles.Buscador()
        Me.dtpFecha = New Eniac.Controles.DateTimePicker()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbPlan = New Eniac.Controles.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bscModelo = New Eniac.Controles.Buscador()
        Me.txtDiferencia = New Eniac.Controles.TextBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.lblManual = New System.Windows.Forms.Label()
        Me.lblFechaExportacion = New Eniac.Controles.Label()
        Me.cmbSubsistema = New Eniac.Controles.ComboBox()
        Me.lblEstadoAsiento = New Eniac.Controles.Label()
        Me.cmbEstadoAsiento = New Eniac.Controles.ComboBox()
        Me.lblTipo = New Eniac.Controles.Label()
        Me.cmbTipo = New Eniac.Controles.ComboBox()
        Me.lblSubsistema = New Eniac.Controles.Label()
        CType(Me.grdAsientosDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(513, 522)
        Me.btnAceptar.TabIndex = 19
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(599, 522)
        Me.btnCancelar.TabIndex = 20
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(412, 522)
        Me.btnCopiar.TabIndex = 21
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(352, 522)
        Me.btnAplicar.TabIndex = 22
        '
        'lblNro
        '
        Me.lblNro.AutoSize = True
        Me.lblNro.LabelAsoc = Nothing
        Me.lblNro.Location = New System.Drawing.Point(20, 18)
        Me.lblNro.Name = "lblNro"
        Me.lblNro.Size = New System.Drawing.Size(86, 13)
        Me.lblNro.TabIndex = 0
        Me.lblNro.Text = "Número (posible)"
        '
        'txtNumeroAsiento
        '
        Me.txtNumeroAsiento.BindearPropiedadControl = "Text"
        Me.txtNumeroAsiento.BindearPropiedadEntidad = "IdAsiento"
        Me.txtNumeroAsiento.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroAsiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroAsiento.Formato = ""
        Me.txtNumeroAsiento.IsDecimal = False
        Me.txtNumeroAsiento.IsNumber = False
        Me.txtNumeroAsiento.IsPK = True
        Me.txtNumeroAsiento.IsRequired = True
        Me.txtNumeroAsiento.Key = ""
        Me.txtNumeroAsiento.LabelAsoc = Me.lblNro
        Me.txtNumeroAsiento.Location = New System.Drawing.Point(112, 14)
        Me.txtNumeroAsiento.MaxLength = 8
        Me.txtNumeroAsiento.Name = "txtNumeroAsiento"
        Me.txtNumeroAsiento.ReadOnly = True
        Me.txtNumeroAsiento.Size = New System.Drawing.Size(79, 20)
        Me.txtNumeroAsiento.TabIndex = 10000
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(465, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 4
        Me.lblFecha.Text = "Fecha"
        '
        'lbloncept
        '
        Me.lbloncept.AutoSize = True
        Me.lbloncept.LabelAsoc = Nothing
        Me.lbloncept.Location = New System.Drawing.Point(20, 46)
        Me.lbloncept.Name = "lbloncept"
        Me.lbloncept.Size = New System.Drawing.Size(53, 13)
        Me.lbloncept.TabIndex = 7
        Me.lbloncept.Text = "Concepto"
        '
        'txtConcepto
        '
        Me.txtConcepto.BindearPropiedadControl = "Text"
        Me.txtConcepto.BindearPropiedadEntidad = "NombreAsiento"
        Me.txtConcepto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtConcepto.Formato = ""
        Me.txtConcepto.IsDecimal = False
        Me.txtConcepto.IsNumber = False
        Me.txtConcepto.IsPK = False
        Me.txtConcepto.IsRequired = True
        Me.txtConcepto.Key = ""
        Me.txtConcepto.LabelAsoc = Me.lbloncept
        Me.txtConcepto.Location = New System.Drawing.Point(112, 46)
        Me.txtConcepto.MaxLength = 100
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(341, 20)
        Me.txtConcepto.TabIndex = 8
        '
        'grdAsientosDetalle
        '
        Me.grdAsientosDetalle.AllowUserToAddRows = False
        Me.grdAsientosDetalle.AllowUserToDeleteRows = False
        Me.grdAsientosDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdAsientosDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.grdAsientosDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAsientosDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ver, Me.cuenta, Me.NombreCentroCosto, Me.debe, Me.haber, Me.IdTipoReferencia, Me.Referencia, Me.IdCentroCosto})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdAsientosDetalle.DefaultCellStyle = DataGridViewCellStyle17
        Me.grdAsientosDetalle.Location = New System.Drawing.Point(21, 226)
        Me.grdAsientosDetalle.MultiSelect = False
        Me.grdAsientosDetalle.Name = "grdAsientosDetalle"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdAsientosDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.grdAsientosDetalle.RowHeadersVisible = False
        Me.grdAsientosDetalle.RowHeadersWidth = 4
        Me.grdAsientosDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdAsientosDetalle.Size = New System.Drawing.Size(557, 264)
        Me.grdAsientosDetalle.TabIndex = 12
        '
        'Ver
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ver.DefaultCellStyle = DataGridViewCellStyle14
        Me.Ver.HeaderText = "Ver"
        Me.Ver.Name = "Ver"
        Me.Ver.Text = "..."
        Me.Ver.Visible = False
        Me.Ver.Width = 30
        '
        'cuenta
        '
        Me.cuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cuenta.DataPropertyName = "Cuenta"
        Me.cuenta.HeaderText = "Cuenta [cod - desc]"
        Me.cuenta.Name = "cuenta"
        Me.cuenta.ReadOnly = True
        '
        'NombreCentroCosto
        '
        Me.NombreCentroCosto.DataPropertyName = "NombreCentroCosto"
        Me.NombreCentroCosto.HeaderText = "Centro Costo"
        Me.NombreCentroCosto.Name = "NombreCentroCosto"
        '
        'debe
        '
        Me.debe.DataPropertyName = "Debe"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        Me.debe.DefaultCellStyle = DataGridViewCellStyle15
        Me.debe.HeaderText = "Debe [$]"
        Me.debe.Name = "debe"
        '
        'haber
        '
        Me.haber.DataPropertyName = "Haber"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        Me.haber.DefaultCellStyle = DataGridViewCellStyle16
        Me.haber.HeaderText = "Haber [$]"
        Me.haber.Name = "haber"
        '
        'IdTipoReferencia
        '
        Me.IdTipoReferencia.DataPropertyName = "IdTipoReferencia"
        Me.IdTipoReferencia.HeaderText = "IdTipoReferencia"
        Me.IdTipoReferencia.Name = "IdTipoReferencia"
        Me.IdTipoReferencia.Visible = False
        '
        'Referencia
        '
        Me.Referencia.DataPropertyName = "Referencia"
        Me.Referencia.HeaderText = "Referencia"
        Me.Referencia.Name = "Referencia"
        Me.Referencia.Visible = False
        '
        'IdCentroCosto
        '
        Me.IdCentroCosto.DataPropertyName = "IdCentroCosto"
        Me.IdCentroCosto.HeaderText = "C.C."
        Me.IdCentroCosto.Name = "IdCentroCosto"
        Me.IdCentroCosto.Visible = False
        '
        'lblTotales
        '
        Me.lblTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotales.AutoSize = True
        Me.lblTotales.LabelAsoc = Nothing
        Me.lblTotales.Location = New System.Drawing.Point(319, 503)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(42, 13)
        Me.lblTotales.TabIndex = 14
        Me.lblTotales.Text = "Totales"
        '
        'txtTotalDebe
        '
        Me.txtTotalDebe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDebe.BindearPropiedadControl = ""
        Me.txtTotalDebe.BindearPropiedadEntidad = ""
        Me.txtTotalDebe.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalDebe.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalDebe.Formato = ""
        Me.txtTotalDebe.IsDecimal = True
        Me.txtTotalDebe.IsNumber = True
        Me.txtTotalDebe.IsPK = False
        Me.txtTotalDebe.IsRequired = False
        Me.txtTotalDebe.Key = ""
        Me.txtTotalDebe.LabelAsoc = Nothing
        Me.txtTotalDebe.Location = New System.Drawing.Point(378, 496)
        Me.txtTotalDebe.MaxLength = 8
        Me.txtTotalDebe.Name = "txtTotalDebe"
        Me.txtTotalDebe.ReadOnly = True
        Me.txtTotalDebe.Size = New System.Drawing.Size(94, 20)
        Me.txtTotalDebe.TabIndex = 15
        Me.txtTotalDebe.TabStop = False
        Me.txtTotalDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalHaber
        '
        Me.txtTotalHaber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalHaber.BindearPropiedadControl = ""
        Me.txtTotalHaber.BindearPropiedadEntidad = ""
        Me.txtTotalHaber.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalHaber.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalHaber.Formato = ""
        Me.txtTotalHaber.IsDecimal = True
        Me.txtTotalHaber.IsNumber = True
        Me.txtTotalHaber.IsPK = False
        Me.txtTotalHaber.IsRequired = False
        Me.txtTotalHaber.Key = ""
        Me.txtTotalHaber.LabelAsoc = Nothing
        Me.txtTotalHaber.Location = New System.Drawing.Point(472, 496)
        Me.txtTotalHaber.MaxLength = 8
        Me.txtTotalHaber.Name = "txtTotalHaber"
        Me.txtTotalHaber.ReadOnly = True
        Me.txtTotalHaber.Size = New System.Drawing.Size(106, 20)
        Me.txtTotalHaber.TabIndex = 16
        Me.txtTotalHaber.TabStop = False
        Me.txtTotalHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCta
        '
        Me.lblCta.AutoSize = True
        Me.lblCta.LabelAsoc = Nothing
        Me.lblCta.Location = New System.Drawing.Point(7, 16)
        Me.lblCta.Name = "lblCta"
        Me.lblCta.Size = New System.Drawing.Size(40, 13)
        Me.lblCta.TabIndex = 0
        Me.lblCta.Text = "Código"
        '
        'bscCodCuenta
        '
        Me.bscCodCuenta.AyudaAncho = 608
        Me.bscCodCuenta.BindearPropiedadControl = Nothing
        Me.bscCodCuenta.BindearPropiedadEntidad = Nothing
        Me.bscCodCuenta.ColumnasAlineacion = Nothing
        Me.bscCodCuenta.ColumnasAncho = Nothing
        Me.bscCodCuenta.ColumnasFormato = Nothing
        Me.bscCodCuenta.ColumnasOcultas = Nothing
        Me.bscCodCuenta.ColumnasTitulos = Nothing
        Me.bscCodCuenta.Datos = Nothing
        Me.bscCodCuenta.FilaDevuelta = Nothing
        Me.bscCodCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodCuenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodCuenta.IsDecimal = False
        Me.bscCodCuenta.IsNumber = True
        Me.bscCodCuenta.IsPK = False
        Me.bscCodCuenta.IsRequired = False
        Me.bscCodCuenta.Key = ""
        Me.bscCodCuenta.LabelAsoc = Me.lblCta
        Me.bscCodCuenta.Location = New System.Drawing.Point(10, 32)
        Me.bscCodCuenta.MaxLengh = "32767"
        Me.bscCodCuenta.Name = "bscCodCuenta"
        Me.bscCodCuenta.Permitido = True
        Me.bscCodCuenta.Selecciono = False
        Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
        Me.bscCodCuenta.TabIndex = 1
        Me.bscCodCuenta.Titulo = Nothing
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbCentroCosto)
        Me.GroupBox1.Controls.Add(Me.lblCentroCosto)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnInsertar)
        Me.GroupBox1.Controls.Add(Me.cmdPlan)
        Me.GroupBox1.Controls.Add(Me.lblHaber)
        Me.GroupBox1.Controls.Add(Me.lbldebe)
        Me.GroupBox1.Controls.Add(Me.lblDesc)
        Me.GroupBox1.Controls.Add(Me.txtHaber)
        Me.GroupBox1.Controls.Add(Me.txtDebe)
        Me.GroupBox1.Controls.Add(Me.bscDescripcion)
        Me.GroupBox1.Controls.Add(Me.bscCodCuenta)
        Me.GroupBox1.Controls.Add(Me.lblCta)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(655, 102)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cuenta"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.BindearPropiedadControl = Nothing
        Me.cmbCentroCosto.BindearPropiedadEntidad = Nothing
        Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCentroCosto.FormattingEnabled = True
        Me.cmbCentroCosto.IsPK = False
        Me.cmbCentroCosto.IsRequired = False
        Me.cmbCentroCosto.Key = Nothing
        Me.cmbCentroCosto.LabelAsoc = Me.lblCentroCosto
        Me.cmbCentroCosto.Location = New System.Drawing.Point(110, 74)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.Size = New System.Drawing.Size(143, 21)
        Me.cmbCentroCosto.TabIndex = 6
        Me.cmbCentroCosto.Visible = False
        '
        'lblCentroCosto
        '
        Me.lblCentroCosto.AutoSize = True
        Me.lblCentroCosto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCentroCosto.LabelAsoc = Nothing
        Me.lblCentroCosto.Location = New System.Drawing.Point(107, 59)
        Me.lblCentroCosto.Name = "lblCentroCosto"
        Me.lblCentroCosto.Size = New System.Drawing.Size(88, 13)
        Me.lblCentroCosto.TabIndex = 5
        Me.lblCentroCosto.Text = "Centro de Costos"
        Me.lblCentroCosto.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(612, 59)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 12
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
        Me.btnInsertar.Location = New System.Drawing.Point(575, 59)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 11
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'cmdPlan
        '
        Me.cmdPlan.Location = New System.Drawing.Point(391, 31)
        Me.cmdPlan.Name = "cmdPlan"
        Me.cmdPlan.Size = New System.Drawing.Size(103, 23)
        Me.cmdPlan.TabIndex = 4
        Me.cmdPlan.TabStop = False
        Me.cmdPlan.Text = "Ver Plan..."
        Me.cmdPlan.UseVisualStyleBackColor = True
        '
        'lblHaber
        '
        Me.lblHaber.AutoSize = True
        Me.lblHaber.LabelAsoc = Nothing
        Me.lblHaber.Location = New System.Drawing.Point(499, 59)
        Me.lblHaber.Name = "lblHaber"
        Me.lblHaber.Size = New System.Drawing.Size(36, 13)
        Me.lblHaber.TabIndex = 9
        Me.lblHaber.Text = "Haber"
        '
        'lbldebe
        '
        Me.lbldebe.AutoSize = True
        Me.lbldebe.LabelAsoc = Nothing
        Me.lbldebe.Location = New System.Drawing.Point(415, 59)
        Me.lbldebe.Name = "lbldebe"
        Me.lbldebe.Size = New System.Drawing.Size(33, 13)
        Me.lbldebe.TabIndex = 7
        Me.lbldebe.Text = "Debe"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.LabelAsoc = Nothing
        Me.lblDesc.Location = New System.Drawing.Point(107, 16)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(63, 13)
        Me.lblDesc.TabIndex = 2
        Me.lblDesc.Text = "Descripción"
        '
        'txtHaber
        '
        Me.txtHaber.BindearPropiedadControl = ""
        Me.txtHaber.BindearPropiedadEntidad = ""
        Me.txtHaber.ForeColorFocus = System.Drawing.Color.Red
        Me.txtHaber.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtHaber.Formato = "N2"
        Me.txtHaber.IsDecimal = True
        Me.txtHaber.IsNumber = True
        Me.txtHaber.IsPK = False
        Me.txtHaber.IsRequired = False
        Me.txtHaber.Key = ""
        Me.txtHaber.LabelAsoc = Me.lblHaber
        Me.txtHaber.Location = New System.Drawing.Point(477, 75)
        Me.txtHaber.MaxLength = 15
        Me.txtHaber.Name = "txtHaber"
        Me.txtHaber.Size = New System.Drawing.Size(80, 20)
        Me.txtHaber.TabIndex = 10
        Me.txtHaber.Text = "0.00"
        Me.txtHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebe
        '
        Me.txtDebe.BindearPropiedadControl = ""
        Me.txtDebe.BindearPropiedadEntidad = ""
        Me.txtDebe.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDebe.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDebe.Formato = "N2"
        Me.txtDebe.IsDecimal = True
        Me.txtDebe.IsNumber = True
        Me.txtDebe.IsPK = False
        Me.txtDebe.IsRequired = False
        Me.txtDebe.Key = ""
        Me.txtDebe.LabelAsoc = Me.lbldebe
        Me.txtDebe.Location = New System.Drawing.Point(391, 75)
        Me.txtDebe.MaxLength = 15
        Me.txtDebe.Name = "txtDebe"
        Me.txtDebe.Size = New System.Drawing.Size(80, 20)
        Me.txtDebe.TabIndex = 8
        Me.txtDebe.Text = "0.00"
        Me.txtDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscDescripcion
        '
        Me.bscDescripcion.AyudaAncho = 608
        Me.bscDescripcion.BindearPropiedadControl = Nothing
        Me.bscDescripcion.BindearPropiedadEntidad = Nothing
        Me.bscDescripcion.ColumnasAlineacion = Nothing
        Me.bscDescripcion.ColumnasAncho = Nothing
        Me.bscDescripcion.ColumnasFormato = Nothing
        Me.bscDescripcion.ColumnasOcultas = Nothing
        Me.bscDescripcion.ColumnasTitulos = Nothing
        Me.bscDescripcion.Datos = Nothing
        Me.bscDescripcion.FilaDevuelta = Nothing
        Me.bscDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscDescripcion.IsDecimal = False
        Me.bscDescripcion.IsNumber = False
        Me.bscDescripcion.IsPK = False
        Me.bscDescripcion.IsRequired = False
        Me.bscDescripcion.Key = ""
        Me.bscDescripcion.LabelAsoc = Me.lblDesc
        Me.bscDescripcion.Location = New System.Drawing.Point(110, 32)
        Me.bscDescripcion.MaxLengh = "32767"
        Me.bscDescripcion.Name = "bscDescripcion"
        Me.bscDescripcion.Permitido = True
        Me.bscDescripcion.Selecciono = False
        Me.bscDescripcion.Size = New System.Drawing.Size(275, 20)
        Me.bscDescripcion.TabIndex = 3
        Me.bscDescripcion.Titulo = Nothing
        '
        'dtpFecha
        '
        Me.dtpFecha.BindearPropiedadControl = "Value"
        Me.dtpFecha.BindearPropiedadEntidad = "FechaAsiento"
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.IsPK = False
        Me.dtpFecha.IsRequired = False
        Me.dtpFecha.Key = ""
        Me.dtpFecha.LabelAsoc = Me.lblFecha
        Me.dtpFecha.Location = New System.Drawing.Point(510, 14)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(203, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Plan de Cuenta"
        '
        'cmbPlan
        '
        Me.cmbPlan.BindearPropiedadControl = "SelectedValue"
        Me.cmbPlan.BindearPropiedadEntidad = "IdPlanCuenta"
        Me.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlan.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPlan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPlan.FormattingEnabled = True
        Me.cmbPlan.IsPK = True
        Me.cmbPlan.IsRequired = True
        Me.cmbPlan.Key = Nothing
        Me.cmbPlan.LabelAsoc = Me.Label1
        Me.cmbPlan.Location = New System.Drawing.Point(287, 14)
        Me.cmbPlan.Name = "cmbPlan"
        Me.cmbPlan.Size = New System.Drawing.Size(166, 21)
        Me.cmbPlan.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bscModelo)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(432, 40)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cargar Asiento Modelo"
        '
        'bscModelo
        '
        Me.bscModelo.AyudaAncho = 608
        Me.bscModelo.BindearPropiedadControl = Nothing
        Me.bscModelo.BindearPropiedadEntidad = Nothing
        Me.bscModelo.ColumnasAlineacion = Nothing
        Me.bscModelo.ColumnasAncho = Nothing
        Me.bscModelo.ColumnasFormato = Nothing
        Me.bscModelo.ColumnasOcultas = Nothing
        Me.bscModelo.ColumnasTitulos = Nothing
        Me.bscModelo.Datos = Nothing
        Me.bscModelo.FilaDevuelta = Nothing
        Me.bscModelo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscModelo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscModelo.IsDecimal = False
        Me.bscModelo.IsNumber = False
        Me.bscModelo.IsPK = False
        Me.bscModelo.IsRequired = False
        Me.bscModelo.Key = ""
        Me.bscModelo.LabelAsoc = Nothing
        Me.bscModelo.Location = New System.Drawing.Point(10, 14)
        Me.bscModelo.MaxLengh = "32767"
        Me.bscModelo.Name = "bscModelo"
        Me.bscModelo.Permitido = True
        Me.bscModelo.Selecciono = False
        Me.bscModelo.Size = New System.Drawing.Size(375, 20)
        Me.bscModelo.TabIndex = 0
        Me.bscModelo.TabStop = False
        Me.bscModelo.Titulo = Nothing
        '
        'txtDiferencia
        '
        Me.txtDiferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDiferencia.BindearPropiedadControl = ""
        Me.txtDiferencia.BindearPropiedadEntidad = ""
        Me.txtDiferencia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiferencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiferencia.Formato = ""
        Me.txtDiferencia.IsDecimal = True
        Me.txtDiferencia.IsNumber = True
        Me.txtDiferencia.IsPK = False
        Me.txtDiferencia.IsRequired = False
        Me.txtDiferencia.Key = ""
        Me.txtDiferencia.LabelAsoc = Nothing
        Me.txtDiferencia.Location = New System.Drawing.Point(578, 496)
        Me.txtDiferencia.MaxLength = 8
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.ReadOnly = True
        Me.txtDiferencia.Size = New System.Drawing.Size(106, 20)
        Me.txtDiferencia.TabIndex = 18
        Me.txtDiferencia.TabStop = False
        Me.txtDiferencia.Text = "0.00"
        Me.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(584, 480)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Diferencia"
        '
        'lblManual
        '
        Me.lblManual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblManual.AutoSize = True
        Me.lblManual.Location = New System.Drawing.Point(629, 17)
        Me.lblManual.Name = "lblManual"
        Me.lblManual.Size = New System.Drawing.Size(42, 13)
        Me.lblManual.TabIndex = 6
        Me.lblManual.Text = "Manual"
        '
        'lblFechaExportacion
        '
        Me.lblFechaExportacion.AutoSize = True
        Me.lblFechaExportacion.LabelAsoc = Nothing
        Me.lblFechaExportacion.Location = New System.Drawing.Point(28, 503)
        Me.lblFechaExportacion.Name = "lblFechaExportacion"
        Me.lblFechaExportacion.Size = New System.Drawing.Size(200, 13)
        Me.lblFechaExportacion.TabIndex = 13
        Me.lblFechaExportacion.Text = "Exportado el: {0:dd/MM/yyyy HH:mm:ss}"
        Me.lblFechaExportacion.Visible = False
        '
        'cmbSubsistema
        '
        Me.cmbSubsistema.BindearPropiedadControl = "SelectedValue"
        Me.cmbSubsistema.BindearPropiedadEntidad = "SubsiAsiento"
        Me.cmbSubsistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubsistema.Enabled = False
        Me.cmbSubsistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubsistema.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubsistema.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubsistema.FormattingEnabled = True
        Me.cmbSubsistema.IsPK = True
        Me.cmbSubsistema.IsRequired = True
        Me.cmbSubsistema.Key = Nothing
        Me.cmbSubsistema.LabelAsoc = Nothing
        Me.cmbSubsistema.Location = New System.Drawing.Point(510, 72)
        Me.cmbSubsistema.Name = "cmbSubsistema"
        Me.cmbSubsistema.Size = New System.Drawing.Size(161, 21)
        Me.cmbSubsistema.TabIndex = 10
        '
        'lblEstadoAsiento
        '
        Me.lblEstadoAsiento.AutoSize = True
        Me.lblEstadoAsiento.LabelAsoc = Nothing
        Me.lblEstadoAsiento.Location = New System.Drawing.Point(463, 53)
        Me.lblEstadoAsiento.Name = "lblEstadoAsiento"
        Me.lblEstadoAsiento.Size = New System.Drawing.Size(40, 13)
        Me.lblEstadoAsiento.TabIndex = 10001
        Me.lblEstadoAsiento.Text = "Estado"
        '
        'cmbEstadoAsiento
        '
        Me.cmbEstadoAsiento.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoAsiento.BindearPropiedadEntidad = "IdEstadoAsiento"
        Me.cmbEstadoAsiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoAsiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoAsiento.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoAsiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoAsiento.FormattingEnabled = True
        Me.cmbEstadoAsiento.IsPK = False
        Me.cmbEstadoAsiento.IsRequired = True
        Me.cmbEstadoAsiento.Key = Nothing
        Me.cmbEstadoAsiento.LabelAsoc = Me.lblEstadoAsiento
        Me.cmbEstadoAsiento.Location = New System.Drawing.Point(510, 46)
        Me.cmbEstadoAsiento.Name = "cmbEstadoAsiento"
        Me.cmbEstadoAsiento.Size = New System.Drawing.Size(160, 21)
        Me.cmbEstadoAsiento.TabIndex = 10002
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.LabelAsoc = Nothing
        Me.lblTipo.Location = New System.Drawing.Point(464, 104)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 10003
        Me.lblTipo.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipo.BindearPropiedadEntidad = "TipoAsiento"
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.IsPK = False
        Me.cmbTipo.IsRequired = True
        Me.cmbTipo.Key = Nothing
        Me.cmbTipo.LabelAsoc = Me.lblTipo
        Me.cmbTipo.Location = New System.Drawing.Point(510, 97)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(160, 21)
        Me.cmbTipo.TabIndex = 10004
        '
        'lblSubsistema
        '
        Me.lblSubsistema.AutoSize = True
        Me.lblSubsistema.LabelAsoc = Nothing
        Me.lblSubsistema.Location = New System.Drawing.Point(464, 79)
        Me.lblSubsistema.Name = "lblSubsistema"
        Me.lblSubsistema.Size = New System.Drawing.Size(26, 13)
        Me.lblSubsistema.TabIndex = 10005
        Me.lblSubsistema.Text = "Sub"
        '
        'ContabilidadAsientosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 557)
        Me.Controls.Add(Me.lblSubsistema)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.lblEstadoAsiento)
        Me.Controls.Add(Me.cmbEstadoAsiento)
        Me.Controls.Add(Me.lblManual)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbSubsistema)
        Me.Controls.Add(Me.cmbPlan)
        Me.Controls.Add(Me.lblFechaExportacion)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtDiferencia)
        Me.Controls.Add(Me.txtTotalHaber)
        Me.Controls.Add(Me.txtTotalDebe)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTotales)
        Me.Controls.Add(Me.grdAsientosDetalle)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.lbloncept)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblNro)
        Me.Controls.Add(Me.txtNumeroAsiento)
        Me.Name = "ContabilidadAsientosDetalle"
        Me.Text = "Asiento"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.txtNumeroAsiento, 0)
        Me.Controls.SetChildIndex(Me.lblNro, 0)
        Me.Controls.SetChildIndex(Me.lblFecha, 0)
        Me.Controls.SetChildIndex(Me.lbloncept, 0)
        Me.Controls.SetChildIndex(Me.txtConcepto, 0)
        Me.Controls.SetChildIndex(Me.grdAsientosDetalle, 0)
        Me.Controls.SetChildIndex(Me.lblTotales, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtTotalDebe, 0)
        Me.Controls.SetChildIndex(Me.txtTotalHaber, 0)
        Me.Controls.SetChildIndex(Me.txtDiferencia, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.dtpFecha, 0)
        Me.Controls.SetChildIndex(Me.lblFechaExportacion, 0)
        Me.Controls.SetChildIndex(Me.cmbPlan, 0)
        Me.Controls.SetChildIndex(Me.cmbSubsistema, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.lblManual, 0)
        Me.Controls.SetChildIndex(Me.cmbEstadoAsiento, 0)
        Me.Controls.SetChildIndex(Me.lblEstadoAsiento, 0)
        Me.Controls.SetChildIndex(Me.cmbTipo, 0)
        Me.Controls.SetChildIndex(Me.lblTipo, 0)
        Me.Controls.SetChildIndex(Me.lblSubsistema, 0)
        CType(Me.grdAsientosDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNro As Eniac.Controles.Label
   Friend WithEvents txtNumeroAsiento As Eniac.Controles.TextBox
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents lbloncept As Eniac.Controles.Label
   Friend WithEvents txtConcepto As Eniac.Controles.TextBox
   Friend WithEvents grdAsientosDetalle As Eniac.Controles.DataGridView
   Friend WithEvents lblTotales As Eniac.Controles.Label
   Friend WithEvents txtTotalDebe As Eniac.Controles.TextBox
   Friend WithEvents txtTotalHaber As Eniac.Controles.TextBox
   Friend WithEvents lblCta As Eniac.Controles.Label
   Friend WithEvents bscCodCuenta As Eniac.Controles.Buscador
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents lblHaber As Eniac.Controles.Label
   Friend WithEvents lbldebe As Eniac.Controles.Label
   Friend WithEvents lblDesc As Eniac.Controles.Label
   Friend WithEvents txtHaber As Eniac.Controles.TextBox
   Friend WithEvents txtDebe As Eniac.Controles.TextBox
   Friend WithEvents bscDescripcion As Eniac.Controles.Buscador
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents cmdPlan As System.Windows.Forms.Button
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbPlan As Eniac.Controles.ComboBox
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents bscModelo As Eniac.Controles.Buscador
   Friend WithEvents txtDiferencia As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents lblManual As System.Windows.Forms.Label
   Friend WithEvents lblFechaExportacion As Eniac.Controles.Label
   Friend WithEvents cmbSubsistema As Eniac.Controles.ComboBox
   Friend WithEvents cmbCentroCosto As Eniac.Controles.ComboBox
   Friend WithEvents lblCentroCosto As Eniac.Controles.Label
   Friend WithEvents Ver As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents debe As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents haber As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoReferencia As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Referencia As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblEstadoAsiento As Controles.Label
    Friend WithEvents cmbEstadoAsiento As Controles.ComboBox
    Friend WithEvents lblTipo As Controles.Label
    Friend WithEvents cmbTipo As Controles.ComboBox
    Friend WithEvents lblSubsistema As Controles.Label
End Class
