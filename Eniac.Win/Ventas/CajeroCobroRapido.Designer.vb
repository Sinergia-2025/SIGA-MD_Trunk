<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CajeroCobroRapido
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CajeroCobroRapido))
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.txtTotalGeneral = New Eniac.Controles.TextBox()
      Me.lblNumeroAutomatico = New Eniac.Controles.Label()
      Me.chbNumeroAutomatico = New Eniac.Controles.CheckBox()
      Me.lblNumeroPosible = New Eniac.Controles.Label()
      Me.txtNumeroPosible = New Eniac.Controles.TextBox()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.lblFormaPago = New Eniac.Controles.Label()
      Me.lblLetra = New Eniac.Controles.Label()
      Me.txtLetra = New Eniac.Controles.TextBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.lblVendedor = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lblTotalGeneral = New Eniac.Controles.Label()
      Me.lblCategoriaFiscal = New Eniac.Controles.Label()
      Me.cmbCategoriaFiscal = New Eniac.Controles.ComboBox()
      Me.cmbCategoria = New Eniac.Controles.ComboBox()
      Me.lblCategoria = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(272, 223)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 78
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
      Me.btnCancelar.Location = New System.Drawing.Point(358, 223)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 77
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'cmbCajas
      '
      Me.cmbCajas.BindearPropiedadControl = ""
      Me.cmbCajas.BindearPropiedadEntidad = ""
      Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCajas.FormattingEnabled = True
      Me.cmbCajas.IsPK = False
      Me.cmbCajas.IsRequired = False
      Me.cmbCajas.Key = Nothing
      Me.cmbCajas.LabelAsoc = Me.lblCaja
      Me.cmbCajas.Location = New System.Drawing.Point(13, 66)
      Me.cmbCajas.Name = "cmbCajas"
      Me.cmbCajas.Size = New System.Drawing.Size(103, 21)
      Me.cmbCajas.TabIndex = 98
      '
      'lblCaja
      '
      Me.lblCaja.AutoSize = True
      Me.lblCaja.Location = New System.Drawing.Point(13, 51)
      Me.lblCaja.Name = "lblCaja"
      Me.lblCaja.Size = New System.Drawing.Size(28, 13)
      Me.lblCaja.TabIndex = 97
      Me.lblCaja.Text = "Ca&ja"
      '
      'txtTotalGeneral
      '
      Me.txtTotalGeneral.BindearPropiedadControl = Nothing
      Me.txtTotalGeneral.BindearPropiedadEntidad = Nothing
      Me.txtTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotalGeneral.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalGeneral.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalGeneral.Formato = "##,##0.00"
      Me.txtTotalGeneral.IsDecimal = True
      Me.txtTotalGeneral.IsNumber = True
      Me.txtTotalGeneral.IsPK = False
      Me.txtTotalGeneral.IsRequired = False
      Me.txtTotalGeneral.Key = ""
      Me.txtTotalGeneral.LabelAsoc = Nothing
      Me.txtTotalGeneral.Location = New System.Drawing.Point(307, 178)
      Me.txtTotalGeneral.Name = "txtTotalGeneral"
      Me.txtTotalGeneral.ReadOnly = True
      Me.txtTotalGeneral.Size = New System.Drawing.Size(123, 31)
      Me.txtTotalGeneral.TabIndex = 100
      Me.txtTotalGeneral.TabStop = False
      Me.txtTotalGeneral.Text = "0.00"
      Me.txtTotalGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNumeroAutomatico
      '
      Me.lblNumeroAutomatico.AutoSize = True
      Me.lblNumeroAutomatico.Location = New System.Drawing.Point(237, 12)
      Me.lblNumeroAutomatico.Name = "lblNumeroAutomatico"
      Me.lblNumeroAutomatico.Size = New System.Drawing.Size(14, 13)
      Me.lblNumeroAutomatico.TabIndex = 91
      Me.lblNumeroAutomatico.Text = "A"
      '
      'chbNumeroAutomatico
      '
      Me.chbNumeroAutomatico.AutoSize = True
      Me.chbNumeroAutomatico.BindearPropiedadControl = Nothing
      Me.chbNumeroAutomatico.BindearPropiedadEntidad = Nothing
      Me.chbNumeroAutomatico.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumeroAutomatico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumeroAutomatico.IsPK = False
      Me.chbNumeroAutomatico.IsRequired = False
      Me.chbNumeroAutomatico.Key = Nothing
      Me.chbNumeroAutomatico.LabelAsoc = Nothing
      Me.chbNumeroAutomatico.Location = New System.Drawing.Point(238, 31)
      Me.chbNumeroAutomatico.Name = "chbNumeroAutomatico"
      Me.chbNumeroAutomatico.Size = New System.Drawing.Size(15, 14)
      Me.chbNumeroAutomatico.TabIndex = 92
      Me.chbNumeroAutomatico.UseVisualStyleBackColor = True
      '
      'lblNumeroPosible
      '
      Me.lblNumeroPosible.AutoSize = True
      Me.lblNumeroPosible.Location = New System.Drawing.Point(252, 11)
      Me.lblNumeroPosible.Name = "lblNumeroPosible"
      Me.lblNumeroPosible.Size = New System.Drawing.Size(87, 13)
      Me.lblNumeroPosible.TabIndex = 93
      Me.lblNumeroPosible.Text = "Numero (Posible)"
      '
      'txtNumeroPosible
      '
      Me.txtNumeroPosible.BindearPropiedadControl = Nothing
      Me.txtNumeroPosible.BindearPropiedadEntidad = Nothing
      Me.txtNumeroPosible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumeroPosible.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroPosible.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroPosible.Formato = ""
      Me.txtNumeroPosible.IsDecimal = False
      Me.txtNumeroPosible.IsNumber = True
      Me.txtNumeroPosible.IsPK = False
      Me.txtNumeroPosible.IsRequired = False
      Me.txtNumeroPosible.Key = ""
      Me.txtNumeroPosible.LabelAsoc = Me.lblNumeroPosible
      Me.txtNumeroPosible.Location = New System.Drawing.Point(255, 28)
      Me.txtNumeroPosible.MaxLength = 8
      Me.txtNumeroPosible.Name = "txtNumeroPosible"
      Me.txtNumeroPosible.ReadOnly = True
      Me.txtNumeroPosible.Size = New System.Drawing.Size(81, 20)
      Me.txtNumeroPosible.TabIndex = 94
      Me.txtNumeroPosible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
      Me.cmbFormaPago.LabelAsoc = Me.lblFormaPago
      Me.cmbFormaPago.Location = New System.Drawing.Point(300, 65)
      Me.cmbFormaPago.Name = "cmbFormaPago"
      Me.cmbFormaPago.Size = New System.Drawing.Size(130, 21)
      Me.cmbFormaPago.TabIndex = 96
      '
      'lblFormaPago
      '
      Me.lblFormaPago.AutoSize = True
      Me.lblFormaPago.Location = New System.Drawing.Point(297, 51)
      Me.lblFormaPago.Name = "lblFormaPago"
      Me.lblFormaPago.Size = New System.Drawing.Size(79, 13)
      Me.lblFormaPago.TabIndex = 95
      Me.lblFormaPago.Text = "Forma de &Pago"
      '
      'lblLetra
      '
      Me.lblLetra.AutoSize = True
      Me.lblLetra.Location = New System.Drawing.Point(206, 12)
      Me.lblLetra.Name = "lblLetra"
      Me.lblLetra.Size = New System.Drawing.Size(28, 13)
      Me.lblLetra.TabIndex = 89
      Me.lblLetra.Text = "Tipo"
      '
      'txtLetra
      '
      Me.txtLetra.BindearPropiedadControl = Nothing
      Me.txtLetra.BindearPropiedadEntidad = Nothing
      Me.txtLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLetra.Formato = ""
      Me.txtLetra.IsDecimal = False
      Me.txtLetra.IsNumber = False
      Me.txtLetra.IsPK = False
      Me.txtLetra.IsRequired = False
      Me.txtLetra.Key = ""
      Me.txtLetra.LabelAsoc = Me.lblLetra
      Me.txtLetra.Location = New System.Drawing.Point(209, 28)
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.ReadOnly = True
      Me.txtLetra.Size = New System.Drawing.Size(25, 20)
      Me.txtLetra.TabIndex = 90
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
      Me.cmbVendedor.LabelAsoc = Me.lblVendedor
      Me.cmbVendedor.Location = New System.Drawing.Point(143, 65)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(129, 21)
      Me.cmbVendedor.TabIndex = 84
      '
      'lblVendedor
      '
      Me.lblVendedor.AutoSize = True
      Me.lblVendedor.Location = New System.Drawing.Point(143, 51)
      Me.lblVendedor.Name = "lblVendedor"
      Me.lblVendedor.Size = New System.Drawing.Size(53, 13)
      Me.lblVendedor.TabIndex = 83
      Me.lblVendedor.Text = "&Vendedor"
      '
      'cmbTiposComprobantes
      '
      Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
      Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
      Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantes.FormattingEnabled = True
      Me.cmbTiposComprobantes.IsPK = False
      Me.cmbTiposComprobantes.IsRequired = False
      Me.cmbTiposComprobantes.Key = Nothing
      Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(13, 24)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(189, 24)
      Me.cmbTiposComprobantes.TabIndex = 88
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.Location = New System.Drawing.Point(13, 9)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
      Me.lblTipoComprobante.TabIndex = 87
      Me.lblTipoComprobante.Text = "&Tipo Comprobante"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasCondiciones = CType(resources.GetObject("bscCodigoCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCodigoCliente.ColumnasVisibles = CType(resources.GetObject("bscCodigoCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(13, 108)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = False
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoCliente.TabIndex = 80
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(13, 94)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 79
      Me.lblCodigoCliente.Text = "Código"
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = Nothing
      Me.dtpFecha.BindearPropiedadEntidad = Nothing
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.Enabled = False
      Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(348, 26)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(82, 20)
      Me.dtpFecha.TabIndex = 86
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.Location = New System.Drawing.Point(345, 12)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 85
      Me.lblFecha.Text = "&Fecha"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ColumnasCondiciones = CType(resources.GetObject("bscCliente.ColumnasCondiciones"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaCondicion))
      Me.bscCliente.ColumnasVisibles = CType(resources.GetObject("bscCliente.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
      Me.bscCliente.Datos = Nothing
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
      Me.bscCliente.Location = New System.Drawing.Point(107, 107)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = False
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(323, 23)
      Me.bscCliente.TabIndex = 82
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(104, 94)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 81
      Me.lblNombre.Text = "&Nombre"
      '
      'lblTotalGeneral
      '
      Me.lblTotalGeneral.AutoSize = True
      Me.lblTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotalGeneral.Location = New System.Drawing.Point(245, 182)
      Me.lblTotalGeneral.Name = "lblTotalGeneral"
      Me.lblTotalGeneral.Size = New System.Drawing.Size(65, 25)
      Me.lblTotalGeneral.TabIndex = 99
      Me.lblTotalGeneral.Text = "Total"
      '
      'lblCategoriaFiscal
      '
      Me.lblCategoriaFiscal.AutoSize = True
      Me.lblCategoriaFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.lblCategoriaFiscal.Location = New System.Drawing.Point(172, 134)
      Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
      Me.lblCategoriaFiscal.Size = New System.Drawing.Size(82, 13)
      Me.lblCategoriaFiscal.TabIndex = 102
      Me.lblCategoriaFiscal.Text = "Categoria Fiscal"
      '
      'cmbCategoriaFiscal
      '
      Me.cmbCategoriaFiscal.BindearPropiedadControl = Nothing
      Me.cmbCategoriaFiscal.BindearPropiedadEntidad = Nothing
      Me.cmbCategoriaFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoriaFiscal.Enabled = False
      Me.cmbCategoriaFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoriaFiscal.FormattingEnabled = True
      Me.cmbCategoriaFiscal.IsPK = False
      Me.cmbCategoriaFiscal.IsRequired = False
      Me.cmbCategoriaFiscal.Key = Nothing
      Me.cmbCategoriaFiscal.LabelAsoc = Me.lblCategoriaFiscal
      Me.cmbCategoriaFiscal.Location = New System.Drawing.Point(172, 148)
      Me.cmbCategoriaFiscal.Name = "cmbCategoriaFiscal"
      Me.cmbCategoriaFiscal.Size = New System.Drawing.Size(131, 21)
      Me.cmbCategoriaFiscal.TabIndex = 101
      '
      'cmbCategoria
      '
      Me.cmbCategoria.BindearPropiedadControl = Nothing
      Me.cmbCategoria.BindearPropiedadEntidad = Nothing
      Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoria.Enabled = False
      Me.cmbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoria.FormattingEnabled = True
      Me.cmbCategoria.IsPK = False
      Me.cmbCategoria.IsRequired = False
      Me.cmbCategoria.Key = Nothing
      Me.cmbCategoria.LabelAsoc = Me.lblCategoria
      Me.cmbCategoria.Location = New System.Drawing.Point(13, 148)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(131, 21)
      Me.cmbCategoria.TabIndex = 101
      '
      'lblCategoria
      '
      Me.lblCategoria.AutoSize = True
      Me.lblCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.lblCategoria.Location = New System.Drawing.Point(13, 134)
      Me.lblCategoria.Name = "lblCategoria"
      Me.lblCategoria.Size = New System.Drawing.Size(52, 13)
      Me.lblCategoria.TabIndex = 102
      Me.lblCategoria.Text = "Categoria"
      '
      'CajeroCobroRapido
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(450, 265)
      Me.Controls.Add(Me.lblCategoria)
      Me.Controls.Add(Me.cmbCategoria)
      Me.Controls.Add(Me.lblCategoriaFiscal)
      Me.Controls.Add(Me.cmbCategoriaFiscal)
      Me.Controls.Add(Me.cmbCajas)
      Me.Controls.Add(Me.lblCaja)
      Me.Controls.Add(Me.txtTotalGeneral)
      Me.Controls.Add(Me.lblNumeroAutomatico)
      Me.Controls.Add(Me.chbNumeroAutomatico)
      Me.Controls.Add(Me.lblNumeroPosible)
      Me.Controls.Add(Me.txtNumeroPosible)
      Me.Controls.Add(Me.cmbFormaPago)
      Me.Controls.Add(Me.lblFormaPago)
      Me.Controls.Add(Me.lblLetra)
      Me.Controls.Add(Me.txtLetra)
      Me.Controls.Add(Me.cmbVendedor)
      Me.Controls.Add(Me.lblVendedor)
      Me.Controls.Add(Me.cmbTiposComprobantes)
      Me.Controls.Add(Me.lblTipoComprobante)
      Me.Controls.Add(Me.bscCodigoCliente)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.bscCliente)
      Me.Controls.Add(Me.lblFecha)
      Me.Controls.Add(Me.lblCodigoCliente)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblTotalGeneral)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.KeyPreview = True
      Me.Name = "CajeroCobroRapido"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cajero Cobro en Efectivo"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents txtTotalGeneral As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroAutomatico As Eniac.Controles.Label
   Friend WithEvents chbNumeroAutomatico As Eniac.Controles.CheckBox
   Friend WithEvents lblNumeroPosible As Eniac.Controles.Label
   Friend WithEvents txtNumeroPosible As Eniac.Controles.TextBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents lblFormaPago As Eniac.Controles.Label
   Friend WithEvents lblLetra As Eniac.Controles.Label
   Friend WithEvents txtLetra As Eniac.Controles.TextBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents lblVendedor As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblTotalGeneral As Eniac.Controles.Label
   Friend WithEvents lblCategoriaFiscal As Eniac.Controles.Label
   Friend WithEvents cmbCategoriaFiscal As Eniac.Controles.ComboBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents lblCategoria As Eniac.Controles.Label
End Class
