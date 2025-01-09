<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RequerimientosComprasDetalle
   Inherits BaseDetalle

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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRequerimientoCompra")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadUMCompra")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUnidadDeMedida")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUnidadDeMedidaCompra")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FactorConversionCompra")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAnulacion")
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuarioAnulacion")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Asignaciones")
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.grbProveedor = New System.Windows.Forms.GroupBox()
      Me.lblFechaEntrega = New Eniac.Controles.Label()
      Me.dtpFechaEntrega = New Eniac.Controles.DateTimePicker()
      Me.lblNumeroAutomatico = New Eniac.Controles.Label()
      Me.chbNumeroAutomatico = New Eniac.Controles.CheckBox()
      Me.lblNumeroPosible = New Eniac.Controles.Label()
      Me.txtNumeroPosible = New Eniac.Controles.TextBox()
      Me.lblLetra = New Eniac.Controles.Label()
      Me.txtLetra = New Eniac.Controles.TextBox()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.tbcDetalle = New System.Windows.Forms.TabControl()
      Me.tbpProductos = New System.Windows.Forms.TabPage()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.pnlDetallePedido = New System.Windows.Forms.Panel()
      Me.pnlCantidadUMC = New System.Windows.Forms.Panel()
      Me.lblCantidadUMC = New Eniac.Controles.Label()
      Me.txtCantidadUMC = New Eniac.Controles.TextBox()
      Me.txtObservacionProducto = New Eniac.Controles.TextBox()
      Me.lblObservacionProducto = New Eniac.Controles.Label()
      Me.lblCantidad = New Eniac.Controles.Label()
      Me.txtCantidad = New Eniac.Controles.TextBox()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.lblStock = New Eniac.Controles.Label()
      Me.txtStock = New Eniac.Controles.TextBox()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.lblFechaEntregaProd = New Eniac.Controles.Label()
      Me.lblCodProducto = New Eniac.Controles.Label()
      Me.dtpFechaEntregaProd = New Eniac.Controles.DateTimePicker()
      Me.btnLimpiarProducto = New Eniac.Controles.Button()
      Me.txtProductoObservacion = New Eniac.Controles.TextBox()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.pnlAccionesDetalle = New System.Windows.Forms.Panel()
      Me.lblItems = New Eniac.Controles.Label()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.ugProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbProveedor.SuspendLayout()
        Me.tbcDetalle.SuspendLayout()
        Me.tbpProductos.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlDetallePedido.SuspendLayout()
        Me.pnlCantidadUMC.SuspendLayout()
        Me.pnlAccionesDetalle.SuspendLayout()
        CType(Me.ugProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(716, 522)
        Me.btnAceptar.Size = New System.Drawing.Size(92, 30)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar (F4)"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(811, 522)
        Me.btnCancelar.TabIndex = 3
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(615, 522)
        Me.btnCopiar.TabIndex = 4
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(558, 522)
        Me.btnAplicar.TabIndex = 5
        '
        'grbProveedor
        '
        Me.grbProveedor.Controls.Add(Me.lblFechaEntrega)
        Me.grbProveedor.Controls.Add(Me.dtpFechaEntrega)
        Me.grbProveedor.Controls.Add(Me.lblNumeroAutomatico)
        Me.grbProveedor.Controls.Add(Me.chbNumeroAutomatico)
        Me.grbProveedor.Controls.Add(Me.lblNumeroPosible)
        Me.grbProveedor.Controls.Add(Me.txtNumeroPosible)
        Me.grbProveedor.Controls.Add(Me.lblLetra)
        Me.grbProveedor.Controls.Add(Me.txtLetra)
        Me.grbProveedor.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbProveedor.Controls.Add(Me.lblTipoComprobante)
        Me.grbProveedor.Controls.Add(Me.txtObservacion)
        Me.grbProveedor.Controls.Add(Me.lblObservacion)
        Me.grbProveedor.Controls.Add(Me.dtpFecha)
        Me.grbProveedor.Controls.Add(Me.lblFecha)
        Me.grbProveedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbProveedor.Location = New System.Drawing.Point(0, 0)
        Me.grbProveedor.Name = "grbProveedor"
        Me.grbProveedor.Size = New System.Drawing.Size(900, 84)
        Me.grbProveedor.TabIndex = 0
        Me.grbProveedor.TabStop = False
        Me.grbProveedor.Text = "Detalle"
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFechaEntrega.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFechaEntrega.LabelAsoc = Nothing
        Me.lblFechaEntrega.Location = New System.Drawing.Point(692, 64)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(95, 13)
        Me.lblFechaEntrega.TabIndex = 12
        Me.lblFechaEntrega.Text = "Fecha de Entrega:"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.BindearPropiedadControl = Nothing
        Me.dtpFechaEntrega.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntrega.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntrega.IsPK = False
        Me.dtpFechaEntrega.IsRequired = False
        Me.dtpFechaEntrega.Key = ""
        Me.dtpFechaEntrega.LabelAsoc = Me.lblFechaEntrega
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(793, 60)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEntrega.TabIndex = 13
        '
        'lblNumeroAutomatico
        '
        Me.lblNumeroAutomatico.AutoSize = True
        Me.lblNumeroAutomatico.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNumeroAutomatico.LabelAsoc = Nothing
        Me.lblNumeroAutomatico.Location = New System.Drawing.Point(235, 16)
        Me.lblNumeroAutomatico.Name = "lblNumeroAutomatico"
        Me.lblNumeroAutomatico.Size = New System.Drawing.Size(14, 13)
        Me.lblNumeroAutomatico.TabIndex = 4
        Me.lblNumeroAutomatico.Text = "A"
        '
        'chbNumeroAutomatico
        '
        Me.chbNumeroAutomatico.AutoSize = True
        Me.chbNumeroAutomatico.BindearPropiedadControl = Nothing
        Me.chbNumeroAutomatico.BindearPropiedadEntidad = Nothing
        Me.chbNumeroAutomatico.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroAutomatico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroAutomatico.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbNumeroAutomatico.IsPK = False
        Me.chbNumeroAutomatico.IsRequired = False
        Me.chbNumeroAutomatico.Key = Nothing
        Me.chbNumeroAutomatico.LabelAsoc = Nothing
        Me.chbNumeroAutomatico.Location = New System.Drawing.Point(236, 35)
        Me.chbNumeroAutomatico.Name = "chbNumeroAutomatico"
        Me.chbNumeroAutomatico.Size = New System.Drawing.Size(15, 14)
        Me.chbNumeroAutomatico.TabIndex = 5
        Me.chbNumeroAutomatico.UseVisualStyleBackColor = True
        '
        'lblNumeroPosible
        '
        Me.lblNumeroPosible.AutoSize = True
        Me.lblNumeroPosible.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNumeroPosible.LabelAsoc = Nothing
        Me.lblNumeroPosible.Location = New System.Drawing.Point(250, 16)
        Me.lblNumeroPosible.Name = "lblNumeroPosible"
        Me.lblNumeroPosible.Size = New System.Drawing.Size(87, 13)
        Me.lblNumeroPosible.TabIndex = 6
        Me.lblNumeroPosible.Text = "Numero (Posible)"
        '
        'txtNumeroPosible
        '
        Me.txtNumeroPosible.BindearPropiedadControl = "Text"
        Me.txtNumeroPosible.BindearPropiedadEntidad = "NumeroRequerimiento"
        Me.txtNumeroPosible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtNumeroPosible.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroPosible.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroPosible.Formato = "0"
        Me.txtNumeroPosible.IsDecimal = False
        Me.txtNumeroPosible.IsNumber = True
        Me.txtNumeroPosible.IsPK = False
        Me.txtNumeroPosible.IsRequired = False
        Me.txtNumeroPosible.Key = ""
        Me.txtNumeroPosible.LabelAsoc = Me.lblNumeroPosible
        Me.txtNumeroPosible.Location = New System.Drawing.Point(253, 32)
        Me.txtNumeroPosible.MaxLength = 8
        Me.txtNumeroPosible.Name = "txtNumeroPosible"
        Me.txtNumeroPosible.ReadOnly = True
        Me.txtNumeroPosible.Size = New System.Drawing.Size(81, 20)
        Me.txtNumeroPosible.TabIndex = 7
        Me.txtNumeroPosible.Text = "0"
        Me.txtNumeroPosible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLetra.LabelAsoc = Nothing
        Me.lblLetra.Location = New System.Drawing.Point(204, 16)
        Me.lblLetra.Name = "lblLetra"
        Me.lblLetra.Size = New System.Drawing.Size(31, 13)
        Me.lblLetra.TabIndex = 2
        Me.lblLetra.Text = "Letra"
        '
        'txtLetra
        '
        Me.txtLetra.BindearPropiedadControl = "Text"
        Me.txtLetra.BindearPropiedadEntidad = "Letra"
        Me.txtLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLetra.Formato = ""
        Me.txtLetra.IsDecimal = False
        Me.txtLetra.IsNumber = False
        Me.txtLetra.IsPK = False
        Me.txtLetra.IsRequired = False
        Me.txtLetra.Key = ""
        Me.txtLetra.LabelAsoc = Me.lblLetra
        Me.txtLetra.Location = New System.Drawing.Point(207, 32)
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.ReadOnly = True
        Me.txtLetra.Size = New System.Drawing.Size(25, 20)
        Me.txtLetra.TabIndex = 3
        Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = "idTipoComprobante"
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(15, 30)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(189, 24)
        Me.cmbTiposComprobantes.TabIndex = 1
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(14, 16)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoComprobante.TabIndex = 0
        Me.lblTipoComprobante.Text = "&Tipo Comprobante"
        '
        'txtObservacion
        '
        Me.txtObservacion.BindearPropiedadControl = "Text"
        Me.txtObservacion.BindearPropiedadEntidad = "Observacion"
        Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacion.Formato = ""
        Me.txtObservacion.IsDecimal = False
        Me.txtObservacion.IsNumber = False
        Me.txtObservacion.IsPK = False
        Me.txtObservacion.IsRequired = False
        Me.txtObservacion.Key = ""
        Me.txtObservacion.LabelAsoc = Me.lblObservacion
        Me.txtObservacion.Location = New System.Drawing.Point(83, 60)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(603, 20)
        Me.txtObservacion.TabIndex = 11
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(15, 64)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
        Me.lblObservacion.TabIndex = 10
        Me.lblObservacion.Text = "Observación"
        '
        'dtpFecha
        '
        Me.dtpFecha.BindearPropiedadControl = "Value"
        Me.dtpFecha.BindearPropiedadEntidad = "Fecha"
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.IsPK = False
        Me.dtpFecha.IsRequired = False
        Me.dtpFecha.Key = ""
        Me.dtpFecha.LabelAsoc = Me.lblFecha
        Me.dtpFecha.Location = New System.Drawing.Point(793, 32)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtpFecha.TabIndex = 9
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(750, 36)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 8
        Me.lblFecha.Text = "&Fecha"
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDetalle.Controls.Add(Me.tbpProductos)
        Me.tbcDetalle.Location = New System.Drawing.Point(0, 86)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(900, 432)
        Me.tbcDetalle.TabIndex = 1
        Me.tbcDetalle.TabStop = False
        '
        'tbpProductos
        '
        Me.tbpProductos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpProductos.Controls.Add(Me.TableLayoutPanel1)
        Me.tbpProductos.ImageKey = "product2.ico"
        Me.tbpProductos.Location = New System.Drawing.Point(4, 22)
        Me.tbpProductos.Name = "tbpProductos"
        Me.tbpProductos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpProductos.Size = New System.Drawing.Size(892, 406)
        Me.tbpProductos.TabIndex = 0
        Me.tbpProductos.Text = "Productos (F9)"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.pnlDetallePedido, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlAccionesDetalle, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ugProductos, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(886, 400)
        Me.TableLayoutPanel1.TabIndex = 37
        '
        'pnlDetallePedido
        '
        Me.pnlDetallePedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetallePedido.Controls.Add(Me.pnlCantidadUMC)
        Me.pnlDetallePedido.Controls.Add(Me.txtObservacionProducto)
        Me.pnlDetallePedido.Controls.Add(Me.lblObservacionProducto)
        Me.pnlDetallePedido.Controls.Add(Me.lblCantidad)
        Me.pnlDetallePedido.Controls.Add(Me.txtCantidad)
        Me.pnlDetallePedido.Controls.Add(Me.lblProducto)
        Me.pnlDetallePedido.Controls.Add(Me.lblStock)
        Me.pnlDetallePedido.Controls.Add(Me.txtStock)
        Me.pnlDetallePedido.Controls.Add(Me.bscCodigoProducto2)
        Me.pnlDetallePedido.Controls.Add(Me.lblFechaEntregaProd)
        Me.pnlDetallePedido.Controls.Add(Me.lblCodProducto)
        Me.pnlDetallePedido.Controls.Add(Me.dtpFechaEntregaProd)
        Me.pnlDetallePedido.Controls.Add(Me.btnLimpiarProducto)
        Me.pnlDetallePedido.Controls.Add(Me.txtProductoObservacion)
        Me.pnlDetallePedido.Controls.Add(Me.bscProducto2)
        Me.pnlDetallePedido.Location = New System.Drawing.Point(0, 0)
        Me.pnlDetallePedido.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlDetallePedido.Name = "pnlDetallePedido"
        Me.pnlDetallePedido.Size = New System.Drawing.Size(807, 74)
        Me.pnlDetallePedido.TabIndex = 0
        '
        'pnlCantidadUMC
        '
        Me.pnlCantidadUMC.AutoSize = True
        Me.pnlCantidadUMC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlCantidadUMC.Controls.Add(Me.lblCantidadUMC)
        Me.pnlCantidadUMC.Controls.Add(Me.txtCantidadUMC)
        Me.pnlCantidadUMC.Location = New System.Drawing.Point(298, 3)
        Me.pnlCantidadUMC.Name = "pnlCantidadUMC"
        Me.pnlCantidadUMC.Size = New System.Drawing.Size(143, 20)
        Me.pnlCantidadUMC.TabIndex = 15
        Me.pnlCantidadUMC.Visible = False
        '
        'lblCantidadUMC
        '
        Me.lblCantidadUMC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCantidadUMC.LabelAsoc = Nothing
        Me.lblCantidadUMC.Location = New System.Drawing.Point(0, 4)
        Me.lblCantidadUMC.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCantidadUMC.Name = "lblCantidadUMC"
        Me.lblCantidadUMC.Size = New System.Drawing.Size(83, 13)
        Me.lblCantidadUMC.TabIndex = 5
        Me.lblCantidadUMC.Text = "Cantidad UMC"
        Me.lblCantidadUMC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCantidadUMC
        '
        Me.txtCantidadUMC.BindearPropiedadControl = Nothing
        Me.txtCantidadUMC.BindearPropiedadEntidad = Nothing
        Me.txtCantidadUMC.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadUMC.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadUMC.Formato = "N2"
        Me.txtCantidadUMC.IsDecimal = True
        Me.txtCantidadUMC.IsNumber = True
        Me.txtCantidadUMC.IsPK = False
        Me.txtCantidadUMC.IsRequired = False
        Me.txtCantidadUMC.Key = ""
        Me.txtCantidadUMC.LabelAsoc = Me.lblCantidadUMC
        Me.txtCantidadUMC.Location = New System.Drawing.Point(83, 0)
        Me.txtCantidadUMC.Margin = New System.Windows.Forms.Padding(0)
        Me.txtCantidadUMC.MaxLength = 8
        Me.txtCantidadUMC.Name = "txtCantidadUMC"
        Me.txtCantidadUMC.ReadOnly = True
        Me.txtCantidadUMC.Size = New System.Drawing.Size(60, 20)
        Me.txtCantidadUMC.TabIndex = 6
        Me.txtCantidadUMC.TabStop = False
        Me.txtCantidadUMC.Text = "0.00"
        Me.txtCantidadUMC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtObservacionProducto
        '
        Me.txtObservacionProducto.BindearPropiedadControl = "Text"
        Me.txtObservacionProducto.BindearPropiedadEntidad = "Observacion"
        Me.txtObservacionProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacionProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacionProducto.Formato = ""
        Me.txtObservacionProducto.IsDecimal = False
        Me.txtObservacionProducto.IsNumber = False
        Me.txtObservacionProducto.IsPK = False
        Me.txtObservacionProducto.IsRequired = False
        Me.txtObservacionProducto.Key = ""
        Me.txtObservacionProducto.LabelAsoc = Me.lblObservacionProducto
        Me.txtObservacionProducto.Location = New System.Drawing.Point(76, 50)
        Me.txtObservacionProducto.MaxLength = 100
        Me.txtObservacionProducto.Name = "txtObservacionProducto"
        Me.txtObservacionProducto.Size = New System.Drawing.Size(603, 20)
        Me.txtObservacionProducto.TabIndex = 14
        '
        'lblObservacionProducto
        '
        Me.lblObservacionProducto.AutoSize = True
        Me.lblObservacionProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObservacionProducto.LabelAsoc = Nothing
        Me.lblObservacionProducto.Location = New System.Drawing.Point(8, 54)
        Me.lblObservacionProducto.Name = "lblObservacionProducto"
        Me.lblObservacionProducto.Size = New System.Drawing.Size(67, 13)
        Me.lblObservacionProducto.TabIndex = 13
        Me.lblObservacionProducto.Text = "Observación"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(444, 8)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 9
        Me.lblCantidad.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.BindearPropiedadControl = Nothing
        Me.txtCantidad.BindearPropiedadEntidad = Nothing
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "N2"
        Me.txtCantidad.IsDecimal = True
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Me.lblCantidad
        Me.txtCantidad.Location = New System.Drawing.Point(447, 24)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(54, 20)
        Me.txtCantidad.TabIndex = 10
        Me.txtCantidad.Text = "0,00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(164, 8)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 3
        Me.lblProducto.Text = "Producto"
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStock.LabelAsoc = Nothing
        Me.lblStock.Location = New System.Drawing.Point(746, 10)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(35, 13)
        Me.lblStock.TabIndex = 7
        Me.lblStock.Text = "Stock"
        '
        'txtStock
        '
        Me.txtStock.BindearPropiedadControl = Nothing
        Me.txtStock.BindearPropiedadEntidad = Nothing
        Me.txtStock.ForeColorFocus = System.Drawing.Color.Red
        Me.txtStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtStock.Formato = ""
        Me.txtStock.IsDecimal = False
        Me.txtStock.IsNumber = True
        Me.txtStock.IsPK = False
        Me.txtStock.IsRequired = False
        Me.txtStock.Key = ""
        Me.txtStock.LabelAsoc = Nothing
        Me.txtStock.Location = New System.Drawing.Point(749, 24)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(56, 20)
        Me.txtStock.TabIndex = 8
        Me.txtStock.TabStop = False
        Me.txtStock.Text = "0"
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(34, 24)
        Me.bscCodigoProducto2.MaxLengh = "15"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(127, 20)
        Me.bscCodigoProducto2.TabIndex = 2
        '
        'lblFechaEntregaProd
        '
        Me.lblFechaEntregaProd.AutoSize = True
        Me.lblFechaEntregaProd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFechaEntregaProd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFechaEntregaProd.LabelAsoc = Nothing
        Me.lblFechaEntregaProd.Location = New System.Drawing.Point(504, 8)
        Me.lblFechaEntregaProd.Name = "lblFechaEntregaProd"
        Me.lblFechaEntregaProd.Size = New System.Drawing.Size(92, 13)
        Me.lblFechaEntregaProd.TabIndex = 11
        Me.lblFechaEntregaProd.Text = "Fecha de Entrega"
        '
        'lblCodProducto
        '
        Me.lblCodProducto.AutoSize = True
        Me.lblCodProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCodProducto.LabelAsoc = Nothing
        Me.lblCodProducto.Location = New System.Drawing.Point(31, 8)
        Me.lblCodProducto.Name = "lblCodProducto"
        Me.lblCodProducto.Size = New System.Drawing.Size(40, 13)
        Me.lblCodProducto.TabIndex = 1
        Me.lblCodProducto.Text = "Código"
        '
        'dtpFechaEntregaProd
        '
        Me.dtpFechaEntregaProd.BindearPropiedadControl = Nothing
        Me.dtpFechaEntregaProd.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntregaProd.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaEntregaProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFechaEntregaProd.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntregaProd.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntregaProd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntregaProd.IsPK = False
        Me.dtpFechaEntregaProd.IsRequired = False
        Me.dtpFechaEntregaProd.Key = ""
        Me.dtpFechaEntregaProd.LabelAsoc = Me.lblFechaEntregaProd
        Me.dtpFechaEntregaProd.Location = New System.Drawing.Point(507, 24)
        Me.dtpFechaEntregaProd.Name = "dtpFechaEntregaProd"
        Me.dtpFechaEntregaProd.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEntregaProd.TabIndex = 12
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiarProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(0, 13)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(29, 32)
        Me.btnLimpiarProducto.TabIndex = 0
        Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'txtProductoObservacion
        '
        Me.txtProductoObservacion.BindearPropiedadControl = Nothing
        Me.txtProductoObservacion.BindearPropiedadEntidad = Nothing
        Me.txtProductoObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProductoObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProductoObservacion.Formato = ""
        Me.txtProductoObservacion.IsDecimal = False
        Me.txtProductoObservacion.IsNumber = False
        Me.txtProductoObservacion.IsPK = False
        Me.txtProductoObservacion.IsRequired = False
        Me.txtProductoObservacion.Key = ""
        Me.txtProductoObservacion.LabelAsoc = Nothing
        Me.txtProductoObservacion.Location = New System.Drawing.Point(167, 24)
        Me.txtProductoObservacion.MaxLength = 60
        Me.txtProductoObservacion.Name = "txtProductoObservacion"
        Me.txtProductoObservacion.Size = New System.Drawing.Size(274, 20)
        Me.txtProductoObservacion.TabIndex = 4
        Me.txtProductoObservacion.Visible = False
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(167, 24)
        Me.bscProducto2.MaxLengh = "60"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(277, 20)
        Me.bscProducto2.TabIndex = 4
        '
        'pnlAccionesDetalle
        '
        Me.pnlAccionesDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAccionesDetalle.Controls.Add(Me.lblItems)
        Me.pnlAccionesDetalle.Controls.Add(Me.btnInsertar)
        Me.pnlAccionesDetalle.Controls.Add(Me.btnEliminar)
        Me.pnlAccionesDetalle.Location = New System.Drawing.Point(807, 0)
        Me.pnlAccionesDetalle.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAccionesDetalle.Name = "pnlAccionesDetalle"
        Me.pnlAccionesDetalle.Size = New System.Drawing.Size(79, 74)
        Me.pnlAccionesDetalle.TabIndex = 1
        '
        'lblItems
        '
        Me.lblItems.AutoSize = True
        Me.lblItems.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblItems.LabelAsoc = Nothing
        Me.lblItems.Location = New System.Drawing.Point(3, 8)
        Me.lblItems.Name = "lblItems"
        Me.lblItems.Size = New System.Drawing.Size(32, 13)
        Me.lblItems.TabIndex = 0
        Me.lblItems.Text = "Items"
        '
        'btnInsertar
        '
        Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInsertar.Location = New System.Drawing.Point(4, 22)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 39)
        Me.btnInsertar.TabIndex = 1
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminar.Location = New System.Drawing.Point(41, 22)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 40)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'ugProductos
        '
        Me.ugProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.ugProductos, 2)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugProductos.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance2
        UltraGridColumn27.Header.Caption = "# Req."
        UltraGridColumn27.Header.VisiblePosition = 0
        UltraGridColumn27.Hidden = True
        UltraGridColumn27.Width = 70
        UltraGridColumn28.Header.Caption = "Código"
        UltraGridColumn28.Header.VisiblePosition = 2
        UltraGridColumn28.Width = 100
        UltraGridColumn29.Header.Caption = "Descripción"
        UltraGridColumn29.Header.VisiblePosition = 3
        UltraGridColumn29.Width = 200
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance3
        UltraGridColumn30.Header.Caption = "Ord."
        UltraGridColumn30.Header.VisiblePosition = 1
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 50
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance4
        UltraGridColumn31.Format = "N2"
        UltraGridColumn31.Header.VisiblePosition = 4
        UltraGridColumn31.Width = 90
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance5
        UltraGridColumn1.Format = "N2"
        UltraGridColumn1.Header.Caption = "Cantidad UMC"
        UltraGridColumn1.Header.VisiblePosition = 5
        UltraGridColumn1.Width = 90
        UltraGridColumn3.Header.Caption = "U.M. Stock"
        UltraGridColumn3.Header.VisiblePosition = 10
        UltraGridColumn3.Width = 80
        UltraGridColumn4.Header.Caption = "U.M. Compra"
        UltraGridColumn4.Header.VisiblePosition = 11
        UltraGridColumn4.Width = 80
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance6
        UltraGridColumn2.Format = "N2"
        UltraGridColumn2.Header.Caption = "Kilos Producto"
        UltraGridColumn2.Header.VisiblePosition = 8
        UltraGridColumn2.Hidden = True
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn32.CellAppearance = Appearance7
        UltraGridColumn32.Format = "dd/MM/yyyy"
        UltraGridColumn32.Header.Caption = "Fecha Entrega"
        UltraGridColumn32.Header.VisiblePosition = 6
        UltraGridColumn32.Width = 90
        UltraGridColumn33.Header.VisiblePosition = 7
        UltraGridColumn33.Width = 300
        UltraGridColumn34.Header.VisiblePosition = 12
        UltraGridColumn34.Hidden = True
        UltraGridColumn35.Header.VisiblePosition = 13
        UltraGridColumn35.Hidden = True
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance8
        UltraGridColumn36.Format = "N2"
        UltraGridColumn36.Header.VisiblePosition = 9
        UltraGridColumn36.Width = 70
        UltraGridColumn37.Header.VisiblePosition = 15
        UltraGridColumn37.Hidden = True
        UltraGridColumn38.Header.VisiblePosition = 14
        UltraGridColumn38.Hidden = True
        UltraGridColumn39.Header.VisiblePosition = 16
        UltraGridColumn39.Hidden = True
        UltraGridColumn40.Header.VisiblePosition = 17
        UltraGridColumn40.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn1, UltraGridColumn3, UltraGridColumn4, UltraGridColumn2, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40})
        Me.ugProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.ugProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductos.DisplayLayout.GroupByBox.Hidden = True
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.ugProductos.DisplayLayout.MaxBandDepth = 1
        Me.ugProductos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugProductos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.ugProductos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugProductos.DisplayLayout.Override.CellAppearance = Appearance15
        Me.ugProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugProductos.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.ugProductos.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.ugProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.ugProductos.DisplayLayout.Override.RowAppearance = Appearance18
        Me.ugProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.ugProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugProductos.Location = New System.Drawing.Point(3, 77)
        Me.ugProductos.Name = "ugProductos"
        Me.ugProductos.Size = New System.Drawing.Size(880, 320)
        Me.ugProductos.TabIndex = 2
        Me.ugProductos.Text = "UltraGrid1"
        '
        'RequerimientosComprasDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 557)
        Me.Controls.Add(Me.tbcDetalle)
        Me.Controls.Add(Me.grbProveedor)
        Me.Name = "RequerimientosComprasDetalle"
        Me.Text = "Requerimiento de Compra"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.grbProveedor, 0)
        Me.Controls.SetChildIndex(Me.tbcDetalle, 0)
        Me.grbProveedor.ResumeLayout(False)
        Me.grbProveedor.PerformLayout()
        Me.tbcDetalle.ResumeLayout(False)
        Me.tbpProductos.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlDetallePedido.ResumeLayout(False)
        Me.pnlDetallePedido.PerformLayout()
        Me.pnlCantidadUMC.ResumeLayout(False)
        Me.pnlCantidadUMC.PerformLayout()
        Me.pnlAccionesDetalle.ResumeLayout(False)
        Me.pnlAccionesDetalle.PerformLayout()
        CType(Me.ugProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbProveedor As GroupBox
   Friend WithEvents lblNumeroAutomatico As Controles.Label
   Friend WithEvents chbNumeroAutomatico As Controles.CheckBox
   Friend WithEvents lblNumeroPosible As Controles.Label
   Friend WithEvents txtNumeroPosible As Controles.TextBox
   Friend WithEvents lblLetra As Controles.Label
   Friend WithEvents txtLetra As Controles.TextBox
   Friend WithEvents cmbTiposComprobantes As Controles.ComboBox
   Friend WithEvents lblTipoComprobante As Controles.Label
   Friend WithEvents txtObservacion As Controles.TextBox
   Friend WithEvents lblObservacion As Controles.Label
   Friend WithEvents dtpFecha As Controles.DateTimePicker
   Friend WithEvents lblFecha As Controles.Label
   Friend WithEvents tbcDetalle As TabControl
   Friend WithEvents tbpProductos As TabPage
   Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
   Friend WithEvents pnlDetallePedido As Panel
   Friend WithEvents lblProducto As Controles.Label
   Friend WithEvents lblStock As Controles.Label
   Friend WithEvents txtStock As Controles.TextBox
   Friend WithEvents bscCodigoProducto2 As Controles.Buscador2
   Friend WithEvents lblFechaEntregaProd As Controles.Label
   Friend WithEvents lblCodProducto As Controles.Label
   Friend WithEvents dtpFechaEntregaProd As Controles.DateTimePicker
   Friend WithEvents btnLimpiarProducto As Controles.Button
   Friend WithEvents txtProductoObservacion As Controles.TextBox
   Friend WithEvents bscProducto2 As Controles.Buscador2
   Friend WithEvents pnlAccionesDetalle As Panel
   Friend WithEvents lblItems As Controles.Label
   Friend WithEvents btnInsertar As Controles.Button
   Friend WithEvents btnEliminar As Controles.Button
    Friend WithEvents ugProductos As UltraGrid
    Friend WithEvents lblCantidad As Controles.Label
   Friend WithEvents txtCantidad As Controles.TextBox
   Friend WithEvents lblFechaEntrega As Controles.Label
   Friend WithEvents dtpFechaEntrega As Controles.DateTimePicker
   Friend WithEvents txtObservacionProducto As Controles.TextBox
   Friend WithEvents lblObservacionProducto As Controles.Label
    Friend WithEvents lblCantidadUMC As Controles.Label
    Friend WithEvents txtCantidadUMC As Controles.TextBox
    Friend WithEvents pnlCantidadUMC As Panel
End Class
