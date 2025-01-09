<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GenerarOrdenesDeCalidad
   Inherits Eniac.Win.BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selec")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLote")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDeposito")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeposito")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUbicacion")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalCompra")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteCompra")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraCompra")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorCompra")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteCompra")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGenerar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.bscNombreProducto = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
      Me.bscNombreProveedor = New Eniac.Controles.Buscador2()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.btnTodos = New System.Windows.Forms.Button()
      Me.cmbTodos = New Eniac.Controles.ComboBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.pnlGrilla = New System.Windows.Forms.Panel()
      Me.ugDetalle = New Eniac.Win.UltraGridEditable()
      Me.pnlFiltrosDatos = New System.Windows.Forms.Panel()
      Me.grpDatos = New System.Windows.Forms.GroupBox()
      Me.dtpFechaOrdenCalidad = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.cmbEstadosOrdenes = New Eniac.Controles.ComboBox()
      Me.lblEstadoOrden = New Eniac.Controles.Label()
      Me.cmbTiposComprobantesGenerar = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
        Me.txtObservaciones = New Eniac.Controles.TextBox()
        Me.lblObservaciones = New Eniac.Controles.Label()
        Me.tstBarra.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.pnlGrilla.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltrosDatos.SuspendLayout()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbGenerar, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 3
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbGenerar
        '
        Me.tsbGenerar.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
        Me.tsbGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGenerar.Name = "tsbGenerar"
        Me.tsbGenerar.Size = New System.Drawing.Size(97, 26)
        Me.tsbGenerar.Text = "Generar (F4)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbTiposComprobantes)
        Me.GroupBox1.Controls.Add(Me.lblTipoComprobante)
        Me.GroupBox1.Controls.Add(Me.bscNombreProducto)
        Me.GroupBox1.Controls.Add(Me.bscCodigoProducto)
        Me.GroupBox1.Controls.Add(Me.bscCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.bscNombreProveedor)
        Me.GroupBox1.Controls.Add(Me.chbProducto)
        Me.GroupBox1.Controls.Add(Me.chbProveedor)
        Me.GroupBox1.Controls.Add(Me.chbFecha)
        Me.GroupBox1.Controls.Add(Me.chkMesCompleto)
        Me.GroupBox1.Controls.Add(Me.dtpHasta)
        Me.GroupBox1.Controls.Add(Me.dtpDesde)
        Me.GroupBox1.Controls.Add(Me.lblHasta)
        Me.GroupBox1.Controls.Add(Me.lblDesde)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(118, 45)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(201, 21)
        Me.cmbTiposComprobantes.TabIndex = 7
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(18, 49)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoComprobante.TabIndex = 6
        Me.lblTipoComprobante.Text = "Tipo Comprobante"
        '
        'bscNombreProducto
        '
        Me.bscNombreProducto.ActivarFiltroEnGrilla = True
        Me.bscNombreProducto.BindearPropiedadControl = Nothing
        Me.bscNombreProducto.BindearPropiedadEntidad = Nothing
        Me.bscNombreProducto.ConfigBuscador = Nothing
        Me.bscNombreProducto.Datos = Nothing
        Me.bscNombreProducto.FilaDevuelta = Nothing
        Me.bscNombreProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProducto.IsDecimal = False
        Me.bscNombreProducto.IsNumber = False
        Me.bscNombreProducto.IsPK = False
        Me.bscNombreProducto.IsRequired = False
        Me.bscNombreProducto.Key = ""
        Me.bscNombreProducto.LabelAsoc = Nothing
        Me.bscNombreProducto.Location = New System.Drawing.Point(261, 93)
        Me.bscNombreProducto.MaxLengh = "32767"
        Me.bscNombreProducto.Name = "bscNombreProducto"
        Me.bscNombreProducto.Permitido = False
        Me.bscNombreProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProducto.Selecciono = False
        Me.bscNombreProducto.Size = New System.Drawing.Size(274, 20)
        Me.bscNombreProducto.TabIndex = 13
        '
        'bscCodigoProducto
        '
        Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto.ConfigBuscador = Nothing
        Me.bscCodigoProducto.Datos = Nothing
        Me.bscCodigoProducto.FilaDevuelta = Nothing
        Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto.IsDecimal = False
        Me.bscCodigoProducto.IsNumber = False
        Me.bscCodigoProducto.IsPK = False
        Me.bscCodigoProducto.IsRequired = False
        Me.bscCodigoProducto.Key = ""
        Me.bscCodigoProducto.LabelAsoc = Nothing
        Me.bscCodigoProducto.Location = New System.Drawing.Point(118, 93)
        Me.bscCodigoProducto.MaxLengh = "32767"
        Me.bscCodigoProducto.Name = "bscCodigoProducto"
        Me.bscCodigoProducto.Permitido = False
        Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.Selecciono = False
        Me.bscCodigoProducto.Size = New System.Drawing.Size(137, 20)
        Me.bscCodigoProducto.TabIndex = 12
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ConfigBuscador = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = False
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Nothing
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(118, 70)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = False
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 9
        '
        'bscNombreProveedor
        '
        Me.bscNombreProveedor.ActivarFiltroEnGrilla = True
        Me.bscNombreProveedor.AutoSize = True
        Me.bscNombreProveedor.BindearPropiedadControl = Nothing
        Me.bscNombreProveedor.BindearPropiedadEntidad = Nothing
        Me.bscNombreProveedor.ConfigBuscador = Nothing
        Me.bscNombreProveedor.Datos = Nothing
        Me.bscNombreProveedor.FilaDevuelta = Nothing
        Me.bscNombreProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProveedor.IsDecimal = False
        Me.bscNombreProveedor.IsNumber = False
        Me.bscNombreProveedor.IsPK = False
        Me.bscNombreProveedor.IsRequired = False
        Me.bscNombreProveedor.Key = ""
        Me.bscNombreProveedor.LabelAsoc = Nothing
        Me.bscNombreProveedor.Location = New System.Drawing.Point(215, 70)
        Me.bscNombreProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreProveedor.MaxLengh = "32767"
        Me.bscNombreProveedor.Name = "bscNombreProveedor"
        Me.bscNombreProveedor.Permitido = False
        Me.bscNombreProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.Selecciono = False
        Me.bscNombreProveedor.Size = New System.Drawing.Size(320, 23)
        Me.bscNombreProveedor.TabIndex = 10
        '
        'chbProducto
        '
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(21, 95)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 11
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
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
        Me.chbProveedor.Location = New System.Drawing.Point(21, 73)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 8
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'chbFecha
        '
        Me.chbFecha.AutoSize = True
        Me.chbFecha.BindearPropiedadControl = Nothing
        Me.chbFecha.BindearPropiedadEntidad = Nothing
        Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFecha.IsPK = False
        Me.chbFecha.IsRequired = False
        Me.chbFecha.Key = Nothing
        Me.chbFecha.LabelAsoc = Nothing
        Me.chbFecha.Location = New System.Drawing.Point(21, 21)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 0
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.Enabled = False
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(118, 21)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 1
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(439, 19)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 5
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(398, 23)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 4
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
        Me.dtpDesde.Location = New System.Drawing.Point(261, 19)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 3
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(217, 23)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 2
        Me.lblDesde.Text = "Desde"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnConsultar.Location = New System.Drawing.Point(868, 3)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 32)
        Me.btnConsultar.TabIndex = 0
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnTodos
        '
        Me.btnTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(787, 8)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 2
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'cmbTodos
        '
        Me.cmbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTodos.BindearPropiedadControl = Nothing
        Me.cmbTodos.BindearPropiedadEntidad = Nothing
        Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodos.FormattingEnabled = True
        Me.cmbTodos.IsPK = False
        Me.cmbTodos.IsRequired = False
        Me.cmbTodos.Key = Nothing
        Me.cmbTodos.LabelAsoc = Nothing
        Me.cmbTodos.Location = New System.Drawing.Point(660, 9)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 1
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
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
        'pnlGrilla
        '
        Me.pnlGrilla.Controls.Add(Me.btnConsultar)
        Me.pnlGrilla.Controls.Add(Me.cmbTodos)
        Me.pnlGrilla.Controls.Add(Me.btnTodos)
        Me.pnlGrilla.Controls.Add(Me.ugDetalle)
        Me.pnlGrilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrilla.Location = New System.Drawing.Point(0, 149)
        Me.pnlGrilla.Name = "pnlGrilla"
        Me.pnlGrilla.Size = New System.Drawing.Size(984, 390)
        Me.pnlGrilla.TabIndex = 1
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn1.CellButtonAppearance = Appearance2
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 40
        UltraGridColumn14.Header.VisiblePosition = 1
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.Header.Caption = "Proveedor"
        UltraGridColumn15.Header.VisiblePosition = 2
        UltraGridColumn15.Width = 162
        UltraGridColumn16.Header.VisiblePosition = 3
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.Header.Caption = "Producto"
        UltraGridColumn17.Header.VisiblePosition = 4
        UltraGridColumn17.Width = 173
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        UltraGridColumn18.CellAppearance = Appearance3
        UltraGridColumn18.Header.Caption = "Lote"
        UltraGridColumn18.Header.VisiblePosition = 5
        UltraGridColumn18.Width = 91
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        UltraGridColumn9.CellAppearance = Appearance4
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.VisiblePosition = 7
        UltraGridColumn9.Width = 100
        UltraGridColumn19.Header.VisiblePosition = 6
        UltraGridColumn19.Hidden = True
        Appearance5.TextVAlignAsString = "Middle"
        UltraGridColumn20.CellAppearance = Appearance5
        UltraGridColumn20.Header.Caption = "Deposito"
        UltraGridColumn20.Header.VisiblePosition = 8
        UltraGridColumn21.Header.VisiblePosition = 9
        UltraGridColumn21.Hidden = True
        Appearance6.TextVAlignAsString = "Middle"
        UltraGridColumn22.CellAppearance = Appearance6
        UltraGridColumn22.Header.Caption = "Ubicacion"
        UltraGridColumn22.Header.VisiblePosition = 10
        Appearance7.TextHAlignAsString = "Center"
        Appearance7.TextVAlignAsString = "Middle"
        UltraGridColumn23.CellAppearance = Appearance7
        UltraGridColumn23.Header.Caption = "Suc"
        UltraGridColumn23.Header.VisiblePosition = 11
        UltraGridColumn23.Width = 41
        UltraGridColumn24.Header.Caption = "Comprobante"
        UltraGridColumn24.Header.VisiblePosition = 12
        UltraGridColumn24.Width = 153
        Appearance8.TextHAlignAsString = "Center"
        Appearance8.TextVAlignAsString = "Middle"
        UltraGridColumn25.CellAppearance = Appearance8
        UltraGridColumn25.Header.Caption = "Letra"
        UltraGridColumn25.Header.VisiblePosition = 13
        UltraGridColumn25.Width = 38
        Appearance9.TextHAlignAsString = "Center"
        Appearance9.TextVAlignAsString = "Middle"
        UltraGridColumn26.CellAppearance = Appearance9
        UltraGridColumn26.Header.Caption = "Emisor"
        UltraGridColumn26.Header.VisiblePosition = 14
        UltraGridColumn26.Width = 46
        Appearance10.TextHAlignAsString = "Right"
        Appearance10.TextVAlignAsString = "Middle"
        UltraGridColumn27.CellAppearance = Appearance10
        UltraGridColumn27.Header.Caption = "Numero"
        UltraGridColumn27.Header.VisiblePosition = 15
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn9, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance11.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance11
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance13.BackColor2 = System.Drawing.SystemColors.Control
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.SystemColors.Highlight
        Appearance15.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance15
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance16
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Appearance17.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance17
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance18.BackColor = System.Drawing.SystemColors.Control
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance18
        Appearance19.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance21.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance21
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.EnterMueveACeldaDeAbajo = True
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 390)
        Me.ugDetalle.TabIndex = 3
        Me.ugDetalle.Text = "UltraGrid1"
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'pnlFiltrosDatos
        '
        Me.pnlFiltrosDatos.Controls.Add(Me.GroupBox1)
        Me.pnlFiltrosDatos.Controls.Add(Me.grpDatos)
        Me.pnlFiltrosDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltrosDatos.Location = New System.Drawing.Point(0, 29)
        Me.pnlFiltrosDatos.Name = "pnlFiltrosDatos"
        Me.pnlFiltrosDatos.Size = New System.Drawing.Size(984, 120)
        Me.pnlFiltrosDatos.TabIndex = 0
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.txtObservaciones)
        Me.grpDatos.Controls.Add(Me.lblObservaciones)
        Me.grpDatos.Controls.Add(Me.dtpFechaOrdenCalidad)
        Me.grpDatos.Controls.Add(Me.lblFecha)
        Me.grpDatos.Controls.Add(Me.cmbEstadosOrdenes)
        Me.grpDatos.Controls.Add(Me.lblEstadoOrden)
        Me.grpDatos.Controls.Add(Me.cmbTiposComprobantesGenerar)
        Me.grpDatos.Controls.Add(Me.Label1)
        Me.grpDatos.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpDatos.Location = New System.Drawing.Point(573, 0)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(411, 120)
        Me.grpDatos.TabIndex = 1
        Me.grpDatos.TabStop = False
        '
        'dtpFechaOrdenCalidad
        '
        Me.dtpFechaOrdenCalidad.BindearPropiedadControl = "Value"
        Me.dtpFechaOrdenCalidad.BindearPropiedadEntidad = "Fecha"
        Me.dtpFechaOrdenCalidad.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaOrdenCalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaOrdenCalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaOrdenCalidad.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaOrdenCalidad.IsPK = False
        Me.dtpFechaOrdenCalidad.IsRequired = False
        Me.dtpFechaOrdenCalidad.Key = ""
        Me.dtpFechaOrdenCalidad.LabelAsoc = Me.lblFecha
        Me.dtpFechaOrdenCalidad.Location = New System.Drawing.Point(52, 45)
        Me.dtpFechaOrdenCalidad.Name = "dtpFechaOrdenCalidad"
        Me.dtpFechaOrdenCalidad.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaOrdenCalidad.TabIndex = 5
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(2, 49)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 4
        Me.lblFecha.Text = "Fecha"
        '
        'cmbEstadosOrdenes
        '
        Me.cmbEstadosOrdenes.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadosOrdenes.BindearPropiedadEntidad = "IdEstadoCalidad"
        Me.cmbEstadosOrdenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadosOrdenes.Enabled = False
        Me.cmbEstadosOrdenes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadosOrdenes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadosOrdenes.FormattingEnabled = True
        Me.cmbEstadosOrdenes.IsPK = False
        Me.cmbEstadosOrdenes.IsRequired = False
        Me.cmbEstadosOrdenes.Key = Nothing
        Me.cmbEstadosOrdenes.LabelAsoc = Me.lblEstadoOrden
        Me.cmbEstadosOrdenes.Location = New System.Drawing.Point(254, 19)
        Me.cmbEstadosOrdenes.Name = "cmbEstadosOrdenes"
        Me.cmbEstadosOrdenes.Size = New System.Drawing.Size(150, 21)
        Me.cmbEstadosOrdenes.TabIndex = 3
        '
        'lblEstadoOrden
        '
        Me.lblEstadoOrden.AutoSize = True
        Me.lblEstadoOrden.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEstadoOrden.LabelAsoc = Nothing
        Me.lblEstadoOrden.Location = New System.Drawing.Point(208, 23)
        Me.lblEstadoOrden.Name = "lblEstadoOrden"
        Me.lblEstadoOrden.Size = New System.Drawing.Size(40, 13)
        Me.lblEstadoOrden.TabIndex = 2
        Me.lblEstadoOrden.Text = "Estado"
        '
        'cmbTiposComprobantesGenerar
        '
        Me.cmbTiposComprobantesGenerar.BindearPropiedadControl = "SelectedValue"
        Me.cmbTiposComprobantesGenerar.BindearPropiedadEntidad = "IdTipoComprobante"
        Me.cmbTiposComprobantesGenerar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantesGenerar.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantesGenerar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantesGenerar.FormattingEnabled = True
        Me.cmbTiposComprobantesGenerar.IsPK = False
        Me.cmbTiposComprobantesGenerar.IsRequired = False
        Me.cmbTiposComprobantesGenerar.Key = Nothing
        Me.cmbTiposComprobantesGenerar.LabelAsoc = Me.Label1
        Me.cmbTiposComprobantesGenerar.Location = New System.Drawing.Point(52, 19)
        Me.cmbTiposComprobantesGenerar.Name = "cmbTiposComprobantesGenerar"
        Me.cmbTiposComprobantesGenerar.Size = New System.Drawing.Size(150, 21)
        Me.cmbTiposComprobantesGenerar.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(2, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BindearPropiedadControl = "Text"
        Me.txtObservaciones.BindearPropiedadEntidad = "Observaciones"
        Me.txtObservaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservaciones.Formato = ""
        Me.txtObservaciones.IsDecimal = False
        Me.txtObservaciones.IsNumber = False
        Me.txtObservaciones.IsPK = False
        Me.txtObservaciones.IsRequired = False
        Me.txtObservaciones.Key = ""
        Me.txtObservaciones.LabelAsoc = Nothing
        Me.txtObservaciones.Location = New System.Drawing.Point(52, 71)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(352, 20)
        Me.txtObservaciones.TabIndex = 7
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObservaciones.LabelAsoc = Nothing
        Me.lblObservaciones.Location = New System.Drawing.Point(2, 75)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(44, 13)
        Me.lblObservaciones.TabIndex = 6
        Me.lblObservaciones.Text = "Observ."
        '
        'GenerarOrdenesDeCalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.pnlGrilla)
        Me.Controls.Add(Me.pnlFiltrosDatos)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "GenerarOrdenesDeCalidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generación Masiva de Ordenes de Calidad"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.pnlGrilla.ResumeLayout(False)
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltrosDatos.ResumeLayout(False)
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents tstBarra As ToolStrip
   Public WithEvents tsbRefrescar As ToolStripButton
   Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
   Friend WithEvents tsbGenerar As ToolStripButton
   Private WithEvents ToolStripSeparator1 As ToolStripSeparator
   Public WithEvents tsbSalir As ToolStripButton
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents chbFecha As Controles.CheckBox
   Friend WithEvents chkMesCompleto As Controles.CheckBox
   Friend WithEvents dtpHasta As Controles.DateTimePicker
   Friend WithEvents lblHasta As Controles.Label
   Friend WithEvents dtpDesde As Controles.DateTimePicker
   Friend WithEvents lblDesde As Controles.Label
   Friend WithEvents btnTodos As Button
   Friend WithEvents cmbTodos As Controles.ComboBox
   Protected Friend WithEvents stsStado As StatusStrip
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As ToolStripProgressBar
   Protected WithEvents tssRegistros As ToolStripStatusLabel
   Friend WithEvents btnConsultar As Controles.Button
   Friend WithEvents bscNombreProducto As Controles.Buscador2
   Friend WithEvents bscCodigoProducto As Controles.Buscador2
   Friend WithEvents bscCodigoProveedor As Controles.Buscador2
   Friend WithEvents bscNombreProveedor As Controles.Buscador2
   Friend WithEvents chbProducto As Controles.CheckBox
   Friend WithEvents chbProveedor As Controles.CheckBox
   Friend WithEvents cmbTiposComprobantes As ComboBoxTiposComprobantes
   Friend WithEvents lblTipoComprobante As Controles.Label
   Friend WithEvents pnlGrilla As Panel
   Friend WithEvents ugDetalle As UltraGridEditable
   Friend WithEvents pnlFiltrosDatos As Panel
   Friend WithEvents grpDatos As GroupBox
   Friend WithEvents cmbTiposComprobantesGenerar As Controles.ComboBox
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents cmbEstadosOrdenes As Controles.ComboBox
   Friend WithEvents lblEstadoOrden As Controles.Label
   Friend WithEvents dtpFechaOrdenCalidad As Controles.DateTimePicker
   Friend WithEvents lblFecha As Controles.Label
    Friend WithEvents txtObservaciones As Controles.TextBox
    Friend WithEvents lblObservaciones As Controles.Label
End Class
