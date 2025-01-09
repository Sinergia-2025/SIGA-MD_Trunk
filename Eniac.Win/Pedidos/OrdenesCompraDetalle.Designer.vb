<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrdenesCompraDetalle
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
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.lblProveedor = New Eniac.Controles.Label()
      Me.lblNumeroOrdenCompra = New Eniac.Controles.Label()
      Me.txtNumeroOrdenCompra = New Eniac.Controles.TextBox()
      Me.lblFormaPago = New Eniac.Controles.Label()
      Me.txtUsuario = New Eniac.Controles.TextBox()
      Me.lblUsuario = New Eniac.Controles.Label()
      Me.dtpFechaPedidos = New Eniac.Controles.DateTimePicker()
      Me.lblFechaPedidos = New Eniac.Controles.Label()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
      Me.bscProveedor = New Eniac.Controles.Buscador()
        Me.chbDescuentoRecargo = New Eniac.Controles.CheckBox()
        Me.chbAnticipado = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(303, 168)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(389, 168)
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(202, 168)
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "RespetaPreciosOrdenCompra"
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(115, 118)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(216, 17)
        Me.chbActivo.TabIndex = 24
        Me.chbActivo.Text = "Respeta Precios de la Orden de Compra"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.LabelAsoc = Nothing
        Me.lblProveedor.Location = New System.Drawing.Point(33, 42)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
        Me.lblProveedor.TabIndex = 22
        Me.lblProveedor.Text = "Proveedor"
        '
        'lblNumeroOrdenCompra
        '
        Me.lblNumeroOrdenCompra.AutoSize = True
        Me.lblNumeroOrdenCompra.LabelAsoc = Nothing
        Me.lblNumeroOrdenCompra.Location = New System.Drawing.Point(33, 16)
        Me.lblNumeroOrdenCompra.Name = "lblNumeroOrdenCompra"
        Me.lblNumeroOrdenCompra.Size = New System.Drawing.Size(44, 13)
        Me.lblNumeroOrdenCompra.TabIndex = 20
        Me.lblNumeroOrdenCompra.Text = "Número"
        '
        'txtNumeroOrdenCompra
        '
        Me.txtNumeroOrdenCompra.BindearPropiedadControl = "Text"
        Me.txtNumeroOrdenCompra.BindearPropiedadEntidad = "NumeroOrdenCompra"
        Me.txtNumeroOrdenCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroOrdenCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroOrdenCompra.Formato = ""
        Me.txtNumeroOrdenCompra.IsDecimal = False
        Me.txtNumeroOrdenCompra.IsNumber = True
        Me.txtNumeroOrdenCompra.IsPK = True
        Me.txtNumeroOrdenCompra.IsRequired = True
        Me.txtNumeroOrdenCompra.Key = ""
        Me.txtNumeroOrdenCompra.LabelAsoc = Me.lblNumeroOrdenCompra
        Me.txtNumeroOrdenCompra.Location = New System.Drawing.Point(115, 12)
        Me.txtNumeroOrdenCompra.MaxLength = 10
        Me.txtNumeroOrdenCompra.Name = "txtNumeroOrdenCompra"
        Me.txtNumeroOrdenCompra.Size = New System.Drawing.Size(54, 20)
        Me.txtNumeroOrdenCompra.TabIndex = 21
        Me.txtNumeroOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.LabelAsoc = Nothing
        Me.lblFormaPago.Location = New System.Drawing.Point(33, 68)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(79, 13)
        Me.lblFormaPago.TabIndex = 22
        Me.lblFormaPago.Text = "Forma de Pago"
        '
        'txtUsuario
        '
        Me.txtUsuario.BindearPropiedadControl = "Text"
        Me.txtUsuario.BindearPropiedadEntidad = "IdUsuario"
        Me.txtUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUsuario.Formato = ""
        Me.txtUsuario.IsDecimal = False
        Me.txtUsuario.IsNumber = False
        Me.txtUsuario.IsPK = False
        Me.txtUsuario.IsRequired = True
        Me.txtUsuario.Key = ""
        Me.txtUsuario.LabelAsoc = Me.lblUsuario
        Me.txtUsuario.Location = New System.Drawing.Point(115, 141)
        Me.txtUsuario.MaxLength = 20
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(128, 20)
        Me.txtUsuario.TabIndex = 23
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.LabelAsoc = Nothing
        Me.lblUsuario.Location = New System.Drawing.Point(33, 145)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
        Me.lblUsuario.TabIndex = 22
        Me.lblUsuario.Text = "Usuario"
        '
        'dtpFechaPedidos
        '
        Me.dtpFechaPedidos.BindearPropiedadControl = "Value"
        Me.dtpFechaPedidos.BindearPropiedadEntidad = "FechaPedidos"
        Me.dtpFechaPedidos.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaPedidos.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaPedidos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaPedidos.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaPedidos.IsPK = False
        Me.dtpFechaPedidos.IsRequired = True
        Me.dtpFechaPedidos.Key = ""
        Me.dtpFechaPedidos.LabelAsoc = Me.lblFechaPedidos
        Me.dtpFechaPedidos.Location = New System.Drawing.Point(115, 91)
        Me.dtpFechaPedidos.Name = "dtpFechaPedidos"
        Me.dtpFechaPedidos.Size = New System.Drawing.Size(102, 20)
        Me.dtpFechaPedidos.TabIndex = 26
        '
        'lblFechaPedidos
        '
        Me.lblFechaPedidos.AutoSize = True
        Me.lblFechaPedidos.LabelAsoc = Nothing
        Me.lblFechaPedidos.Location = New System.Drawing.Point(33, 95)
        Me.lblFechaPedidos.Name = "lblFechaPedidos"
        Me.lblFechaPedidos.Size = New System.Drawing.Size(78, 13)
        Me.lblFechaPedidos.TabIndex = 25
        Me.lblFechaPedidos.Text = "Fecha Pedidos"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = "SelectedValue"
        Me.cmbFormaPago.BindearPropiedadEntidad = "IdFormasPago"
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = True
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Me.lblFormaPago
        Me.cmbFormaPago.Location = New System.Drawing.Point(115, 64)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(130, 21)
        Me.cmbFormaPago.TabIndex = 35
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.AyudaAncho = 140
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
        Me.bscCodigoProveedor.ColumnasAncho = Nothing
        Me.bscCodigoProveedor.ColumnasFormato = Nothing
        Me.bscCodigoProveedor.ColumnasOcultas = Nothing
        Me.bscCodigoProveedor.ColumnasTitulos = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = False
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = True
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Me.lblProveedor
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(115, 38)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoProveedor.TabIndex = 36
        Me.bscCodigoProveedor.Titulo = Nothing
        '
        'bscProveedor
        '
        Me.bscProveedor.AutoSize = True
        Me.bscProveedor.AyudaAncho = 140
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ColumnasAlineacion = Nothing
        Me.bscProveedor.ColumnasAncho = Nothing
        Me.bscProveedor.ColumnasFormato = Nothing
        Me.bscProveedor.ColumnasOcultas = Nothing
        Me.bscProveedor.ColumnasTitulos = Nothing
        Me.bscProveedor.Datos = Nothing
        Me.bscProveedor.FilaDevuelta = Nothing
        Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProveedor.IsDecimal = False
        Me.bscProveedor.IsNumber = False
        Me.bscProveedor.IsPK = False
        Me.bscProveedor.IsRequired = True
        Me.bscProveedor.Key = ""
        Me.bscProveedor.LabelAsoc = Me.lblProveedor
        Me.bscProveedor.Location = New System.Drawing.Point(212, 37)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(257, 23)
        Me.bscProveedor.TabIndex = 37
        Me.bscProveedor.Titulo = Nothing
        '
        'chbDescuentoRecargo
        '
        Me.chbDescuentoRecargo.AutoSize = True
        Me.chbDescuentoRecargo.BindearPropiedadControl = "Checked"
        Me.chbDescuentoRecargo.BindearPropiedadEntidad = "AplicaDescuentoRecargo"
        Me.chbDescuentoRecargo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDescuentoRecargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDescuentoRecargo.IsPK = False
        Me.chbDescuentoRecargo.IsRequired = False
        Me.chbDescuentoRecargo.Key = Nothing
        Me.chbDescuentoRecargo.LabelAsoc = Nothing
        Me.chbDescuentoRecargo.Location = New System.Drawing.Point(272, 68)
        Me.chbDescuentoRecargo.Name = "chbDescuentoRecargo"
        Me.chbDescuentoRecargo.Size = New System.Drawing.Size(122, 17)
        Me.chbDescuentoRecargo.TabIndex = 38
        Me.chbDescuentoRecargo.Text = "Impuesto Ley 25413"
        Me.chbDescuentoRecargo.UseVisualStyleBackColor = True
        '
        'chbAnticipado
        '
        Me.chbAnticipado.AutoSize = True
        Me.chbAnticipado.BindearPropiedadControl = "Checked"
        Me.chbAnticipado.BindearPropiedadEntidad = "Anticipado"
        Me.chbAnticipado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAnticipado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAnticipado.IsPK = False
        Me.chbAnticipado.IsRequired = False
        Me.chbAnticipado.Key = Nothing
        Me.chbAnticipado.LabelAsoc = Nothing
        Me.chbAnticipado.Location = New System.Drawing.Point(272, 94)
        Me.chbAnticipado.Name = "chbAnticipado"
        Me.chbAnticipado.Size = New System.Drawing.Size(76, 17)
        Me.chbAnticipado.TabIndex = 39
        Me.chbAnticipado.Text = "Anticipado"
        Me.chbAnticipado.UseVisualStyleBackColor = True
        '
        'chbDescuentoRecargo
        '
        Me.chbDescuentoRecargo.AutoSize = True
        Me.chbDescuentoRecargo.BindearPropiedadControl = "Checked"
        Me.chbDescuentoRecargo.BindearPropiedadEntidad = "AplicaDescuentoRecargo"
        Me.chbDescuentoRecargo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDescuentoRecargo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDescuentoRecargo.IsPK = False
        Me.chbDescuentoRecargo.IsRequired = False
        Me.chbDescuentoRecargo.Key = Nothing
        Me.chbDescuentoRecargo.LabelAsoc = Nothing
        Me.chbDescuentoRecargo.Location = New System.Drawing.Point(272, 69)
        Me.chbDescuentoRecargo.Name = "chbDescuentoRecargo"
        Me.chbDescuentoRecargo.Size = New System.Drawing.Size(122, 17)
        Me.chbDescuentoRecargo.TabIndex = 38
        Me.chbDescuentoRecargo.Text = "Impuesto Ley 25413"
        Me.chbDescuentoRecargo.UseVisualStyleBackColor = True
        '
        'chbAnticipado
        '
        Me.chbAnticipado.AutoSize = True
        Me.chbAnticipado.BindearPropiedadControl = "Checked"
        Me.chbAnticipado.BindearPropiedadEntidad = "Anticipado"
        Me.chbAnticipado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAnticipado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAnticipado.IsPK = False
        Me.chbAnticipado.IsRequired = False
        Me.chbAnticipado.Key = Nothing
        Me.chbAnticipado.LabelAsoc = Nothing
        Me.chbAnticipado.Location = New System.Drawing.Point(271, 95)
        Me.chbAnticipado.Name = "chbAnticipado"
        Me.chbAnticipado.Size = New System.Drawing.Size(76, 17)
        Me.chbAnticipado.TabIndex = 39
        Me.chbAnticipado.Text = "Anticipado"
        Me.chbAnticipado.UseVisualStyleBackColor = True
        '
        'OrdenesCompraDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 203)
        Me.Controls.Add(Me.chbAnticipado)
        Me.Controls.Add(Me.chbDescuentoRecargo)
        Me.Controls.Add(Me.bscCodigoProveedor)
        Me.Controls.Add(Me.bscProveedor)
        Me.Controls.Add(Me.cmbFormaPago)
        Me.Controls.Add(Me.dtpFechaPedidos)
        Me.Controls.Add(Me.lblFechaPedidos)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.lblFormaPago)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.lblProveedor)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.lblNumeroOrdenCompra)
        Me.Controls.Add(Me.txtNumeroOrdenCompra)
        Me.Name = "OrdenesCompraDetalle"
        Me.Text = "Orden Compra"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.txtNumeroOrdenCompra, 0)
        Me.Controls.SetChildIndex(Me.lblNumeroOrdenCompra, 0)
        Me.Controls.SetChildIndex(Me.txtUsuario, 0)
        Me.Controls.SetChildIndex(Me.lblProveedor, 0)
        Me.Controls.SetChildIndex(Me.lblUsuario, 0)
        Me.Controls.SetChildIndex(Me.lblFormaPago, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.Controls.SetChildIndex(Me.lblFechaPedidos, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaPedidos, 0)
        Me.Controls.SetChildIndex(Me.cmbFormaPago, 0)
        Me.Controls.SetChildIndex(Me.bscProveedor, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoProveedor, 0)
        Me.Controls.SetChildIndex(Me.chbDescuentoRecargo, 0)
        Me.Controls.SetChildIndex(Me.chbAnticipado, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents lblProveedor As Eniac.Controles.Label
   Friend WithEvents lblNumeroOrdenCompra As Eniac.Controles.Label
   Friend WithEvents txtNumeroOrdenCompra As Eniac.Controles.TextBox
   Friend WithEvents lblFormaPago As Eniac.Controles.Label
   Friend WithEvents txtUsuario As Eniac.Controles.TextBox
   Friend WithEvents lblUsuario As Eniac.Controles.Label
   Protected WithEvents dtpFechaPedidos As Eniac.Controles.DateTimePicker
   Protected WithEvents lblFechaPedidos As Eniac.Controles.Label
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
    Friend WithEvents chbDescuentoRecargo As Controles.CheckBox
    Friend WithEvents chbAnticipado As Controles.CheckBox
End Class
