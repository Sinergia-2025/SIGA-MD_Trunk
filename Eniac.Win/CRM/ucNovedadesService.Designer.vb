<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucNovedadesService
   Inherits Eniac.Win.ucNovedades

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblFecha = New Eniac.Controles.Label()
        Me.btnHistoricoVentas = New System.Windows.Forms.Button()
        Me.Label1 = New Eniac.Controles.Label()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.bscComprobante = New Eniac.Controles.Buscador2()
        Me.lblLetra = New Eniac.Controles.Label()
        Me.lblEmisor = New Eniac.Controles.Label()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.txtLetraComprobante = New Eniac.Controles.TextBox()
        Me.txtEmisor = New Eniac.Controles.TextBox()
        Me.btnLimpiarComprobante = New Eniac.Controles.Button()
        Me.txtNroSerie = New Eniac.Controles.TextBox()
        Me.lblNroDeSerie = New Eniac.Controles.Label()
        Me.txtMarca = New Eniac.Controles.TextBox()
        Me.txtModelo = New Eniac.Controles.TextBox()
        Me.pnlModelo = New System.Windows.Forms.Panel()
        Me.lnkModelo = New Eniac.Controles.LinkLabel()
        Me.bscModelo = New Eniac.Controles.Buscador()
        Me.txtNombreProducto = New Eniac.Controles.TextBox()
        Me.txtFechaVenta = New Eniac.Controles.TextBox()
        Me.lnkMarca = New Eniac.Controles.LinkLabel()
        Me.bscMarca = New Eniac.Controles.Buscador()
        Me.pnlVentaPropia = New System.Windows.Forms.Panel()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.pnlServiceLugarCompra = New System.Windows.Forms.Panel()
        Me.txtServiceLugarCompra = New Eniac.Controles.TextBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.dtpServiceLugarCompraFecha = New Eniac.Controles.DateTimePicker()
        Me.txtServiceLugarCompraNumeroComprobante = New Eniac.Controles.TextBox()
        Me.txtServiceLugarCompraTipoComprobante = New Eniac.Controles.TextBox()
        Me.Label4 = New Eniac.Controles.Label()
        Me.Label5 = New Eniac.Controles.Label()
        Me.GroupBox1.SuspendLayout()
        Me.pnlModelo.SuspendLayout()
        Me.pnlVentaPropia.SuspendLayout()
        Me.pnlServiceLugarCompra.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lnkMarca)
        Me.GroupBox1.Controls.Add(Me.pnlModelo)
        Me.GroupBox1.Controls.Add(Me.txtNroSerie)
        Me.GroupBox1.Controls.Add(Me.lblNroDeSerie)
        Me.GroupBox1.Controls.Add(Me.bscCodigoProducto2)
        Me.GroupBox1.Controls.Add(Me.bscProducto2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtNombreProducto)
        Me.GroupBox1.Controls.Add(Me.txtMarca)
        Me.GroupBox1.Controls.Add(Me.bscMarca)
        Me.GroupBox1.Controls.Add(Me.pnlServiceLugarCompra)
        Me.GroupBox1.Controls.Add(Me.pnlVentaPropia)
        Me.GroupBox1.MaximumSize = New System.Drawing.Size(0, 250)
        Me.GroupBox1.Size = New System.Drawing.Size(385, 164)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.Text = "Service"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFecha.LabelAsoc = Nothing
        Me.lblFecha.Location = New System.Drawing.Point(5, 51)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(83, 13)
        Me.lblFecha.TabIndex = 9
        Me.lblFecha.Text = "Fecha de Venta"
        '
        'btnHistoricoVentas
        '
        Me.btnHistoricoVentas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnHistoricoVentas.Location = New System.Drawing.Point(178, 45)
        Me.btnHistoricoVentas.Name = "btnHistoricoVentas"
        Me.btnHistoricoVentas.Size = New System.Drawing.Size(125, 25)
        Me.btnHistoricoVentas.TabIndex = 11
        Me.btnHistoricoVentas.Text = "Histórico de Ventas "
        Me.btnHistoricoVentas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(5, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Producto"
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
        Me.bscProducto2.Location = New System.Drawing.Point(153, 85)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(226, 20)
        Me.bscProducto2.TabIndex = 4
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.BindearPropiedadControl = ""
        Me.bscCodigoProducto2.BindearPropiedadEntidad = ""
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
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(65, 85)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(82, 20)
        Me.bscCodigoProducto2.TabIndex = 3
        '
        'bscComprobante
        '
        Me.bscComprobante.ActivarFiltroEnGrilla = True
        Me.bscComprobante.BindearPropiedadControl = Nothing
        Me.bscComprobante.BindearPropiedadEntidad = Nothing
        Me.bscComprobante.ConfigBuscador = Nothing
        Me.bscComprobante.Datos = Nothing
        Me.bscComprobante.FilaDevuelta = Nothing
        Me.bscComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.bscComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscComprobante.IsDecimal = False
        Me.bscComprobante.IsNumber = False
        Me.bscComprobante.IsPK = False
        Me.bscComprobante.IsRequired = False
        Me.bscComprobante.Key = ""
        Me.bscComprobante.LabelAsoc = Nothing
        Me.bscComprobante.Location = New System.Drawing.Point(226, 19)
        Me.bscComprobante.MaxLengh = "32767"
        Me.bscComprobante.Name = "bscComprobante"
        Me.bscComprobante.Permitido = True
        Me.bscComprobante.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscComprobante.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscComprobante.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscComprobante.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscComprobante.Selecciono = False
        Me.bscComprobante.Size = New System.Drawing.Size(153, 20)
        Me.bscComprobante.TabIndex = 8
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLetra.LabelAsoc = Nothing
        Me.lblLetra.Location = New System.Drawing.Point(150, 3)
        Me.lblLetra.Name = "lblLetra"
        Me.lblLetra.Size = New System.Drawing.Size(31, 13)
        Me.lblLetra.TabIndex = 3
        Me.lblLetra.Text = "Letra"
        '
        'lblEmisor
        '
        Me.lblEmisor.AutoSize = True
        Me.lblEmisor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmisor.LabelAsoc = Nothing
        Me.lblEmisor.Location = New System.Drawing.Point(185, 3)
        Me.lblEmisor.Name = "lblEmisor"
        Me.lblEmisor.Size = New System.Drawing.Size(38, 13)
        Me.lblEmisor.TabIndex = 5
        Me.lblEmisor.Text = "Emisor"
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(39, 2)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoComprobante.TabIndex = 1
        Me.lblTipoComprobante.Text = "Tipo"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(221, 3)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(70, 13)
        Me.lblProducto.TabIndex = 7
        Me.lblProducto.Text = "Comprobante"
        '
        'txtLetraComprobante
        '
        Me.txtLetraComprobante.BindearPropiedadControl = "Text"
        Me.txtLetraComprobante.BindearPropiedadEntidad = "LetraService"
        Me.txtLetraComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtLetraComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLetraComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLetraComprobante.Formato = ""
        Me.txtLetraComprobante.IsDecimal = False
        Me.txtLetraComprobante.IsNumber = False
        Me.txtLetraComprobante.IsPK = False
        Me.txtLetraComprobante.IsRequired = False
        Me.txtLetraComprobante.Key = ""
        Me.txtLetraComprobante.LabelAsoc = Nothing
        Me.txtLetraComprobante.Location = New System.Drawing.Point(153, 19)
        Me.txtLetraComprobante.Name = "txtLetraComprobante"
        Me.txtLetraComprobante.ReadOnly = True
        Me.txtLetraComprobante.Size = New System.Drawing.Size(26, 20)
        Me.txtLetraComprobante.TabIndex = 4
        Me.txtLetraComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEmisor
        '
        Me.txtEmisor.BindearPropiedadControl = "Text"
        Me.txtEmisor.BindearPropiedadEntidad = "CentroEmisorService"
        Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEmisor.Formato = "#0"
        Me.txtEmisor.IsDecimal = True
        Me.txtEmisor.IsNumber = True
        Me.txtEmisor.IsPK = False
        Me.txtEmisor.IsRequired = False
        Me.txtEmisor.Key = ""
        Me.txtEmisor.LabelAsoc = Nothing
        Me.txtEmisor.Location = New System.Drawing.Point(183, 19)
        Me.txtEmisor.MaxLength = 8
        Me.txtEmisor.Name = "txtEmisor"
        Me.txtEmisor.ReadOnly = True
        Me.txtEmisor.Size = New System.Drawing.Size(40, 20)
        Me.txtEmisor.TabIndex = 6
        Me.txtEmisor.Text = "0"
        Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnLimpiarComprobante
        '
        Me.btnLimpiarComprobante.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiarComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiarComprobante.Location = New System.Drawing.Point(3, 10)
        Me.btnLimpiarComprobante.Name = "btnLimpiarComprobante"
        Me.btnLimpiarComprobante.Size = New System.Drawing.Size(30, 30)
        Me.btnLimpiarComprobante.TabIndex = 0
        Me.btnLimpiarComprobante.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarComprobante.UseVisualStyleBackColor = True
        '
        'txtNroSerie
        '
        Me.txtNroSerie.BindearPropiedadControl = "Text"
        Me.txtNroSerie.BindearPropiedadEntidad = "NroDeSerie"
        Me.txtNroSerie.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroSerie.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroSerie.Formato = ""
        Me.txtNroSerie.IsDecimal = False
        Me.txtNroSerie.IsNumber = False
        Me.txtNroSerie.IsPK = False
        Me.txtNroSerie.IsRequired = False
        Me.txtNroSerie.Key = ""
        Me.txtNroSerie.LabelAsoc = Nothing
        Me.txtNroSerie.Location = New System.Drawing.Point(65, 111)
        Me.txtNroSerie.MaxLength = 50
        Me.txtNroSerie.Name = "txtNroSerie"
        Me.txtNroSerie.Size = New System.Drawing.Size(82, 20)
        Me.txtNroSerie.TabIndex = 6
        '
        'lblNroDeSerie
        '
        Me.lblNroDeSerie.AutoSize = True
        Me.lblNroDeSerie.LabelAsoc = Nothing
        Me.lblNroDeSerie.Location = New System.Drawing.Point(5, 114)
        Me.lblNroDeSerie.Name = "lblNroDeSerie"
        Me.lblNroDeSerie.Size = New System.Drawing.Size(54, 13)
        Me.lblNroDeSerie.TabIndex = 5
        Me.lblNroDeSerie.Text = "Nro. Serie"
        '
        'txtMarca
        '
        Me.txtMarca.BindearPropiedadControl = "Text"
        Me.txtMarca.BindearPropiedadEntidad = "NroDeSerie"
        Me.txtMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMarca.Formato = ""
        Me.txtMarca.IsDecimal = False
        Me.txtMarca.IsNumber = False
        Me.txtMarca.IsPK = False
        Me.txtMarca.IsRequired = False
        Me.txtMarca.Key = ""
        Me.txtMarca.LabelAsoc = Nothing
        Me.txtMarca.Location = New System.Drawing.Point(202, 110)
        Me.txtMarca.MaxLength = 100
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(177, 21)
        Me.txtMarca.TabIndex = 8
        '
        'txtModelo
        '
        Me.txtModelo.BindearPropiedadControl = "Text"
        Me.txtModelo.BindearPropiedadEntidad = "NroDeSerie"
        Me.txtModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtModelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtModelo.Formato = ""
        Me.txtModelo.IsDecimal = False
        Me.txtModelo.IsNumber = False
        Me.txtModelo.IsPK = False
        Me.txtModelo.IsRequired = False
        Me.txtModelo.Key = ""
        Me.txtModelo.LabelAsoc = Nothing
        Me.txtModelo.Location = New System.Drawing.Point(52, 5)
        Me.txtModelo.MaxLength = 100
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(177, 21)
        Me.txtModelo.TabIndex = 1
        '
        'pnlModelo
        '
        Me.pnlModelo.Controls.Add(Me.lnkModelo)
        Me.pnlModelo.Controls.Add(Me.txtModelo)
        Me.pnlModelo.Controls.Add(Me.bscModelo)
        Me.pnlModelo.Location = New System.Drawing.Point(150, 133)
        Me.pnlModelo.Name = "pnlModelo"
        Me.pnlModelo.Size = New System.Drawing.Size(240, 29)
        Me.pnlModelo.TabIndex = 9
        '
        'lnkModelo
        '
        Me.lnkModelo.AutoSize = True
        Me.lnkModelo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lnkModelo.LabelAsoc = Nothing
        Me.lnkModelo.Location = New System.Drawing.Point(3, 9)
        Me.lnkModelo.Name = "lnkModelo"
        Me.lnkModelo.Size = New System.Drawing.Size(42, 13)
        Me.lnkModelo.TabIndex = 0
        Me.lnkModelo.TabStop = True
        Me.lnkModelo.Text = "Modelo"
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
        Me.bscModelo.Location = New System.Drawing.Point(52, 5)
        Me.bscModelo.MaxLengh = "32767"
        Me.bscModelo.Name = "bscModelo"
        Me.bscModelo.Permitido = True
        Me.bscModelo.Selecciono = False
        Me.bscModelo.Size = New System.Drawing.Size(177, 21)
        Me.bscModelo.TabIndex = 1
        Me.bscModelo.Titulo = Nothing
        '
        'txtNombreProducto
        '
        Me.txtNombreProducto.BindearPropiedadControl = "Text"
        Me.txtNombreProducto.BindearPropiedadEntidad = "NombreProducto"
        Me.txtNombreProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreProducto.Formato = ""
        Me.txtNombreProducto.IsDecimal = False
        Me.txtNombreProducto.IsNumber = False
        Me.txtNombreProducto.IsPK = False
        Me.txtNombreProducto.IsRequired = False
        Me.txtNombreProducto.Key = ""
        Me.txtNombreProducto.LabelAsoc = Nothing
        Me.txtNombreProducto.Location = New System.Drawing.Point(153, 85)
        Me.txtNombreProducto.MaxLength = 50
        Me.txtNombreProducto.Name = "txtNombreProducto"
        Me.txtNombreProducto.Size = New System.Drawing.Size(226, 20)
        Me.txtNombreProducto.TabIndex = 4
        '
        'txtFechaVenta
        '
        Me.txtFechaVenta.BindearPropiedadControl = "Text"
        Me.txtFechaVenta.BindearPropiedadEntidad = "Fecha"
        Me.txtFechaVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFechaVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFechaVenta.Formato = ""
        Me.txtFechaVenta.IsDecimal = False
        Me.txtFechaVenta.IsNumber = False
        Me.txtFechaVenta.IsPK = False
        Me.txtFechaVenta.IsRequired = False
        Me.txtFechaVenta.Key = ""
        Me.txtFechaVenta.LabelAsoc = Nothing
        Me.txtFechaVenta.Location = New System.Drawing.Point(90, 48)
        Me.txtFechaVenta.MaxLength = 50
        Me.txtFechaVenta.Name = "txtFechaVenta"
        Me.txtFechaVenta.ReadOnly = True
        Me.txtFechaVenta.Size = New System.Drawing.Size(82, 20)
        Me.txtFechaVenta.TabIndex = 10
        '
        'lnkMarca
        '
        Me.lnkMarca.AutoSize = True
        Me.lnkMarca.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lnkMarca.LabelAsoc = Nothing
        Me.lnkMarca.Location = New System.Drawing.Point(153, 114)
        Me.lnkMarca.Name = "lnkMarca"
        Me.lnkMarca.Size = New System.Drawing.Size(37, 13)
        Me.lnkMarca.TabIndex = 7
        Me.lnkMarca.TabStop = True
        Me.lnkMarca.Text = "Marca"
        '
        'bscMarca
        '
        Me.bscMarca.AyudaAncho = 608
        Me.bscMarca.BindearPropiedadControl = Nothing
        Me.bscMarca.BindearPropiedadEntidad = Nothing
        Me.bscMarca.ColumnasAlineacion = Nothing
        Me.bscMarca.ColumnasAncho = Nothing
        Me.bscMarca.ColumnasFormato = Nothing
        Me.bscMarca.ColumnasOcultas = Nothing
        Me.bscMarca.ColumnasTitulos = Nothing
        Me.bscMarca.Datos = Nothing
        Me.bscMarca.FilaDevuelta = Nothing
        Me.bscMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.bscMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscMarca.IsDecimal = False
        Me.bscMarca.IsNumber = False
        Me.bscMarca.IsPK = False
        Me.bscMarca.IsRequired = False
        Me.bscMarca.Key = ""
        Me.bscMarca.LabelAsoc = Nothing
        Me.bscMarca.Location = New System.Drawing.Point(202, 110)
        Me.bscMarca.MaxLengh = "32767"
        Me.bscMarca.Name = "bscMarca"
        Me.bscMarca.Permitido = True
        Me.bscMarca.Selecciono = False
        Me.bscMarca.Size = New System.Drawing.Size(177, 21)
        Me.bscMarca.TabIndex = 8
        Me.bscMarca.Titulo = Nothing
        '
        'pnlVentaPropia
        '
        Me.pnlVentaPropia.Controls.Add(Me.btnLimpiarComprobante)
        Me.pnlVentaPropia.Controls.Add(Me.bscComprobante)
        Me.pnlVentaPropia.Controls.Add(Me.txtFechaVenta)
        Me.pnlVentaPropia.Controls.Add(Me.btnHistoricoVentas)
        Me.pnlVentaPropia.Controls.Add(Me.lblLetra)
        Me.pnlVentaPropia.Controls.Add(Me.lblFecha)
        Me.pnlVentaPropia.Controls.Add(Me.lblEmisor)
        Me.pnlVentaPropia.Controls.Add(Me.lblTipoComprobante)
        Me.pnlVentaPropia.Controls.Add(Me.lblProducto)
        Me.pnlVentaPropia.Controls.Add(Me.cmbTiposComprobantes)
        Me.pnlVentaPropia.Controls.Add(Me.txtLetraComprobante)
        Me.pnlVentaPropia.Controls.Add(Me.txtEmisor)
        Me.pnlVentaPropia.Location = New System.Drawing.Point(1, 13)
        Me.pnlVentaPropia.Name = "pnlVentaPropia"
        Me.pnlVentaPropia.Size = New System.Drawing.Size(382, 69)
        Me.pnlVentaPropia.TabIndex = 0
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = "IdTipoComprobanteService"
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Nothing
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(41, 18)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(106, 21)
        Me.cmbTiposComprobantes.TabIndex = 2
        '
        'pnlServiceLugarCompra
        '
        Me.pnlServiceLugarCompra.Controls.Add(Me.txtServiceLugarCompra)
        Me.pnlServiceLugarCompra.Controls.Add(Me.Label3)
        Me.pnlServiceLugarCompra.Controls.Add(Me.Label2)
        Me.pnlServiceLugarCompra.Controls.Add(Me.dtpServiceLugarCompraFecha)
        Me.pnlServiceLugarCompra.Controls.Add(Me.txtServiceLugarCompraNumeroComprobante)
        Me.pnlServiceLugarCompra.Controls.Add(Me.txtServiceLugarCompraTipoComprobante)
        Me.pnlServiceLugarCompra.Controls.Add(Me.Label4)
        Me.pnlServiceLugarCompra.Controls.Add(Me.Label5)
        Me.pnlServiceLugarCompra.Location = New System.Drawing.Point(1, 13)
        Me.pnlServiceLugarCompra.Name = "pnlServiceLugarCompra"
        Me.pnlServiceLugarCompra.Size = New System.Drawing.Size(382, 69)
        Me.pnlServiceLugarCompra.TabIndex = 1
        '
        'txtServiceLugarCompra
        '
        Me.txtServiceLugarCompra.BindearPropiedadControl = "Text"
        Me.txtServiceLugarCompra.BindearPropiedadEntidad = "ServiceLugarCompra"
        Me.txtServiceLugarCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtServiceLugarCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtServiceLugarCompra.Formato = ""
        Me.txtServiceLugarCompra.IsDecimal = False
        Me.txtServiceLugarCompra.IsNumber = False
        Me.txtServiceLugarCompra.IsPK = False
        Me.txtServiceLugarCompra.IsRequired = False
        Me.txtServiceLugarCompra.Key = ""
        Me.txtServiceLugarCompra.LabelAsoc = Nothing
        Me.txtServiceLugarCompra.Location = New System.Drawing.Point(108, 45)
        Me.txtServiceLugarCompra.MaxLength = 50
        Me.txtServiceLugarCompra.Name = "txtServiceLugarCompra"
        Me.txtServiceLugarCompra.Size = New System.Drawing.Size(270, 20)
        Me.txtServiceLugarCompra.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(3, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Lugar de compra"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(262, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha"
        '
        'dtpServiceLugarCompraFecha
        '
        Me.dtpServiceLugarCompraFecha.BindearPropiedadControl = "Value"
        Me.dtpServiceLugarCompraFecha.BindearPropiedadEntidad = "FechaNovedad"
        Me.dtpServiceLugarCompraFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpServiceLugarCompraFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpServiceLugarCompraFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpServiceLugarCompraFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpServiceLugarCompraFecha.IsPK = False
        Me.dtpServiceLugarCompraFecha.IsRequired = False
        Me.dtpServiceLugarCompraFecha.Key = ""
        Me.dtpServiceLugarCompraFecha.LabelAsoc = Nothing
        Me.dtpServiceLugarCompraFecha.Location = New System.Drawing.Point(265, 19)
        Me.dtpServiceLugarCompraFecha.Name = "dtpServiceLugarCompraFecha"
        Me.dtpServiceLugarCompraFecha.ShowCheckBox = True
        Me.dtpServiceLugarCompraFecha.Size = New System.Drawing.Size(113, 20)
        Me.dtpServiceLugarCompraFecha.TabIndex = 5
        '
        'txtServiceLugarCompraNumeroComprobante
        '
        Me.txtServiceLugarCompraNumeroComprobante.BindearPropiedadControl = "Text"
        Me.txtServiceLugarCompraNumeroComprobante.BindearPropiedadEntidad = "ServiceLugarCompraNumeroComprobante"
        Me.txtServiceLugarCompraNumeroComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.txtServiceLugarCompraNumeroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtServiceLugarCompraNumeroComprobante.Formato = ""
        Me.txtServiceLugarCompraNumeroComprobante.IsDecimal = False
        Me.txtServiceLugarCompraNumeroComprobante.IsNumber = False
        Me.txtServiceLugarCompraNumeroComprobante.IsPK = False
        Me.txtServiceLugarCompraNumeroComprobante.IsRequired = False
        Me.txtServiceLugarCompraNumeroComprobante.Key = ""
        Me.txtServiceLugarCompraNumeroComprobante.LabelAsoc = Nothing
        Me.txtServiceLugarCompraNumeroComprobante.Location = New System.Drawing.Point(109, 19)
        Me.txtServiceLugarCompraNumeroComprobante.MaxLength = 50
        Me.txtServiceLugarCompraNumeroComprobante.Name = "txtServiceLugarCompraNumeroComprobante"
        Me.txtServiceLugarCompraNumeroComprobante.Size = New System.Drawing.Size(150, 20)
        Me.txtServiceLugarCompraNumeroComprobante.TabIndex = 3
        '
        'txtServiceLugarCompraTipoComprobante
        '
        Me.txtServiceLugarCompraTipoComprobante.BindearPropiedadControl = "Text"
        Me.txtServiceLugarCompraTipoComprobante.BindearPropiedadEntidad = "ServiceLugarCompraTipoComprobante"
        Me.txtServiceLugarCompraTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.txtServiceLugarCompraTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtServiceLugarCompraTipoComprobante.Formato = ""
        Me.txtServiceLugarCompraTipoComprobante.IsDecimal = False
        Me.txtServiceLugarCompraTipoComprobante.IsNumber = False
        Me.txtServiceLugarCompraTipoComprobante.IsPK = False
        Me.txtServiceLugarCompraTipoComprobante.IsRequired = False
        Me.txtServiceLugarCompraTipoComprobante.Key = ""
        Me.txtServiceLugarCompraTipoComprobante.LabelAsoc = Nothing
        Me.txtServiceLugarCompraTipoComprobante.Location = New System.Drawing.Point(3, 19)
        Me.txtServiceLugarCompraTipoComprobante.MaxLength = 50
        Me.txtServiceLugarCompraTipoComprobante.Name = "txtServiceLugarCompraTipoComprobante"
        Me.txtServiceLugarCompraTipoComprobante.Size = New System.Drawing.Size(100, 20)
        Me.txtServiceLugarCompraTipoComprobante.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(105, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Comprobante"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(0, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Tipo"
        '
        'ucNovedadesService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.MaximumSize = New System.Drawing.Size(390, 260)
        Me.Name = "ucNovedadesService"
        Me.Size = New System.Drawing.Size(385, 164)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlModelo.ResumeLayout(False)
        Me.pnlModelo.PerformLayout()
        Me.pnlVentaPropia.ResumeLayout(False)
        Me.pnlVentaPropia.PerformLayout()
        Me.pnlServiceLugarCompra.ResumeLayout(False)
        Me.pnlServiceLugarCompra.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblFecha As Eniac.Controles.Label
    Friend WithEvents btnHistoricoVentas As System.Windows.Forms.Button
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscComprobante As Eniac.Controles.Buscador2
   Friend WithEvents lblLetra As Eniac.Controles.Label
   Friend WithEvents lblEmisor As Eniac.Controles.Label
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents txtLetraComprobante As Eniac.Controles.TextBox
   Friend WithEvents txtEmisor As Eniac.Controles.TextBox
   Friend WithEvents btnLimpiarComprobante As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
    Friend WithEvents txtMarca As Eniac.Controles.TextBox
    Friend WithEvents txtNroSerie As Eniac.Controles.TextBox
    Friend WithEvents lblNroDeSerie As Eniac.Controles.Label
    Friend WithEvents txtModelo As Eniac.Controles.TextBox
    Friend WithEvents pnlModelo As System.Windows.Forms.Panel
    Friend WithEvents txtNombreProducto As Eniac.Controles.TextBox
    Friend WithEvents txtFechaVenta As Controles.TextBox
    Friend WithEvents lnkMarca As Controles.LinkLabel
    Friend WithEvents lnkModelo As Controles.LinkLabel
    Friend WithEvents bscMarca As Controles.Buscador
    Friend WithEvents bscModelo As Controles.Buscador
    Friend WithEvents pnlVentaPropia As Panel
    Friend WithEvents pnlServiceLugarCompra As Panel
    Friend WithEvents txtServiceLugarCompraNumeroComprobante As Controles.TextBox
    Friend WithEvents txtServiceLugarCompraTipoComprobante As Controles.TextBox
    Friend WithEvents Label4 As Controles.Label
    Friend WithEvents Label5 As Controles.Label
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents dtpServiceLugarCompraFecha As Controles.DateTimePicker
    Friend WithEvents txtServiceLugarCompra As Controles.TextBox
    Friend WithEvents Label3 As Controles.Label
End Class
