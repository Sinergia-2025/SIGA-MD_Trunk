<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucConfRMA
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.lblRMACantidadMesesHistorico = New Eniac.Controles.Label()
      Me.txtCRMNovedadesObservacionFacturable = New Eniac.Controles.TextBox()
        Me.lblCRMNovedadesObservacionFacturable = New Eniac.Controles.Label()
        Me.txtRMACantidadMesesHistorico = New Eniac.Controles.TextBox()
        Me.chbImprime1copiaNR = New Eniac.Controles.CheckBox()
        Me.txtCRMNovedadesProductoFacturable = New Eniac.Controles.TextBox()
        Me.lblCRMNovedadesProductoFacturable = New Eniac.Controles.Label()
        Me.lblListaPrecioFacturar = New Eniac.Controles.Label()
        Me.cmbListaPrecioFacturar = New Eniac.Controles.ComboBox()
        Me.cmbMovimientoConsumo = New Eniac.Controles.ComboBox()
        Me.lblMovimientoConsumo = New Eniac.Controles.Label()
        Me.cmbMovimientoReversado = New Eniac.Controles.ComboBox()
        Me.lblMovimientoReversado = New Eniac.Controles.Label()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.lblFormaPago = New Eniac.Controles.Label()
        Me.chkCopiarSaldoComoEfectivoAlFacturar = New Eniac.Controles.CheckBox()
        Me.chbProductosRepNoFactura = New Eniac.Controles.CheckBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.lblDepositoOrigen = New Eniac.Controles.Label()
        Me.cmbDepositoOrigen = New Eniac.Controles.ComboBox()
        Me.lblUbicacionReserva = New Eniac.Controles.Label()
        Me.cmbUbicacionOrigen = New Eniac.Controles.ComboBox()
        Me.cmbMovimientoDevReserva = New Eniac.Controles.ComboBox()
        Me.lblMovimientoDevReserva = New Eniac.Controles.Label()
        Me.cmbMovimientoReserva = New Eniac.Controles.ComboBox()
        Me.lblMovimientoReserva = New Eniac.Controles.Label()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRMACantidadMesesHistorico
        '
        Me.lblRMACantidadMesesHistorico.AutoSize = True
        Me.lblRMACantidadMesesHistorico.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRMACantidadMesesHistorico.LabelAsoc = Nothing
        Me.lblRMACantidadMesesHistorico.Location = New System.Drawing.Point(9, 126)
        Me.lblRMACantidadMesesHistorico.Name = "lblRMACantidadMesesHistorico"
        Me.lblRMACantidadMesesHistorico.Size = New System.Drawing.Size(142, 13)
        Me.lblRMACantidadMesesHistorico.TabIndex = 5
        Me.lblRMACantidadMesesHistorico.Text = "Cantidad de Meses Histórico"
        '
        'txtCRMNovedadesObservacionFacturable
        '
        Me.txtCRMNovedadesObservacionFacturable.BindearPropiedadControl = Nothing
        Me.txtCRMNovedadesObservacionFacturable.BindearPropiedadEntidad = Nothing
        Me.txtCRMNovedadesObservacionFacturable.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCRMNovedadesObservacionFacturable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCRMNovedadesObservacionFacturable.Formato = ""
        Me.txtCRMNovedadesObservacionFacturable.IsDecimal = False
        Me.txtCRMNovedadesObservacionFacturable.IsNumber = False
        Me.txtCRMNovedadesObservacionFacturable.IsPK = False
        Me.txtCRMNovedadesObservacionFacturable.IsRequired = False
        Me.txtCRMNovedadesObservacionFacturable.Key = ""
        Me.txtCRMNovedadesObservacionFacturable.LabelAsoc = Me.lblCRMNovedadesObservacionFacturable
        Me.txtCRMNovedadesObservacionFacturable.Location = New System.Drawing.Point(165, 97)
        Me.txtCRMNovedadesObservacionFacturable.MaxLength = 100
        Me.txtCRMNovedadesObservacionFacturable.Name = "txtCRMNovedadesObservacionFacturable"
        Me.txtCRMNovedadesObservacionFacturable.Size = New System.Drawing.Size(334, 20)
        Me.txtCRMNovedadesObservacionFacturable.TabIndex = 4
        '
        'lblCRMNovedadesObservacionFacturable
        '
        Me.lblCRMNovedadesObservacionFacturable.AutoSize = True
        Me.lblCRMNovedadesObservacionFacturable.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCRMNovedadesObservacionFacturable.LabelAsoc = Nothing
        Me.lblCRMNovedadesObservacionFacturable.Location = New System.Drawing.Point(9, 100)
        Me.lblCRMNovedadesObservacionFacturable.Name = "lblCRMNovedadesObservacionFacturable"
        Me.lblCRMNovedadesObservacionFacturable.Size = New System.Drawing.Size(120, 13)
        Me.lblCRMNovedadesObservacionFacturable.TabIndex = 3
        Me.lblCRMNovedadesObservacionFacturable.Text = "Observación al Facturar"
        '
        'txtRMACantidadMesesHistorico
        '
        Me.txtRMACantidadMesesHistorico.BindearPropiedadControl = Nothing
        Me.txtRMACantidadMesesHistorico.BindearPropiedadEntidad = Nothing
        Me.txtRMACantidadMesesHistorico.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRMACantidadMesesHistorico.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRMACantidadMesesHistorico.Formato = ""
        Me.txtRMACantidadMesesHistorico.IsDecimal = False
        Me.txtRMACantidadMesesHistorico.IsNumber = True
        Me.txtRMACantidadMesesHistorico.IsPK = False
        Me.txtRMACantidadMesesHistorico.IsRequired = False
        Me.txtRMACantidadMesesHistorico.Key = ""
        Me.txtRMACantidadMesesHistorico.LabelAsoc = Me.lblRMACantidadMesesHistorico
        Me.txtRMACantidadMesesHistorico.Location = New System.Drawing.Point(165, 123)
        Me.txtRMACantidadMesesHistorico.MaxLength = 8
        Me.txtRMACantidadMesesHistorico.Name = "txtRMACantidadMesesHistorico"
        Me.txtRMACantidadMesesHistorico.Size = New System.Drawing.Size(26, 20)
        Me.txtRMACantidadMesesHistorico.TabIndex = 6
        Me.txtRMACantidadMesesHistorico.Text = "3"
        Me.txtRMACantidadMesesHistorico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbImprime1copiaNR
        '
        Me.chbImprime1copiaNR.BindearPropiedadControl = Nothing
        Me.chbImprime1copiaNR.BindearPropiedadEntidad = Nothing
        Me.chbImprime1copiaNR.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImprime1copiaNR.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImprime1copiaNR.IsPK = False
        Me.chbImprime1copiaNR.IsRequired = False
        Me.chbImprime1copiaNR.Key = Nothing
        Me.chbImprime1copiaNR.LabelAsoc = Nothing
        Me.chbImprime1copiaNR.Location = New System.Drawing.Point(12, 9)
        Me.chbImprime1copiaNR.Name = "chbImprime1copiaNR"
        Me.chbImprime1copiaNR.Size = New System.Drawing.Size(292, 26)
        Me.chbImprime1copiaNR.TabIndex = 0
        Me.chbImprime1copiaNR.Text = "Service: Imprime solo una copia de Nota de Recepción"
        Me.chbImprime1copiaNR.UseVisualStyleBackColor = True
        '
        'txtCRMNovedadesProductoFacturable
        '
        Me.txtCRMNovedadesProductoFacturable.BindearPropiedadControl = Nothing
        Me.txtCRMNovedadesProductoFacturable.BindearPropiedadEntidad = Nothing
        Me.txtCRMNovedadesProductoFacturable.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCRMNovedadesProductoFacturable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCRMNovedadesProductoFacturable.Formato = ""
        Me.txtCRMNovedadesProductoFacturable.IsDecimal = False
        Me.txtCRMNovedadesProductoFacturable.IsNumber = False
        Me.txtCRMNovedadesProductoFacturable.IsPK = False
        Me.txtCRMNovedadesProductoFacturable.IsRequired = False
        Me.txtCRMNovedadesProductoFacturable.Key = ""
        Me.txtCRMNovedadesProductoFacturable.LabelAsoc = Me.lblCRMNovedadesProductoFacturable
        Me.txtCRMNovedadesProductoFacturable.Location = New System.Drawing.Point(165, 40)
        Me.txtCRMNovedadesProductoFacturable.MaxLength = 8
        Me.txtCRMNovedadesProductoFacturable.Name = "txtCRMNovedadesProductoFacturable"
        Me.txtCRMNovedadesProductoFacturable.Size = New System.Drawing.Size(56, 20)
        Me.txtCRMNovedadesProductoFacturable.TabIndex = 2
        Me.txtCRMNovedadesProductoFacturable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCRMNovedadesProductoFacturable
        '
        Me.lblCRMNovedadesProductoFacturable.AutoSize = True
        Me.lblCRMNovedadesProductoFacturable.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCRMNovedadesProductoFacturable.LabelAsoc = Nothing
        Me.lblCRMNovedadesProductoFacturable.Location = New System.Drawing.Point(9, 43)
        Me.lblCRMNovedadesProductoFacturable.Name = "lblCRMNovedadesProductoFacturable"
        Me.lblCRMNovedadesProductoFacturable.Size = New System.Drawing.Size(128, 13)
        Me.lblCRMNovedadesProductoFacturable.TabIndex = 1
        Me.lblCRMNovedadesProductoFacturable.Text = "Cód. Producto Facturable"
        '
        'lblListaPrecioFacturar
        '
        Me.lblListaPrecioFacturar.AutoSize = True
        Me.lblListaPrecioFacturar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblListaPrecioFacturar.LabelAsoc = Nothing
        Me.lblListaPrecioFacturar.Location = New System.Drawing.Point(9, 153)
        Me.lblListaPrecioFacturar.Name = "lblListaPrecioFacturar"
        Me.lblListaPrecioFacturar.Size = New System.Drawing.Size(148, 13)
        Me.lblListaPrecioFacturar.TabIndex = 7
        Me.lblListaPrecioFacturar.Text = "Lista de Precios para Facturar"
        '
        'cmbListaPrecioFacturar
        '
        Me.cmbListaPrecioFacturar.BindearPropiedadControl = Nothing
        Me.cmbListaPrecioFacturar.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecioFacturar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecioFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecioFacturar.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecioFacturar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecioFacturar.FormattingEnabled = True
        Me.cmbListaPrecioFacturar.IsPK = False
        Me.cmbListaPrecioFacturar.IsRequired = False
        Me.cmbListaPrecioFacturar.Items.AddRange(New Object() {"ACTUAL", "ULTIMO"})
        Me.cmbListaPrecioFacturar.Key = Nothing
        Me.cmbListaPrecioFacturar.LabelAsoc = Me.lblListaPrecioFacturar
        Me.cmbListaPrecioFacturar.Location = New System.Drawing.Point(165, 149)
        Me.cmbListaPrecioFacturar.Name = "cmbListaPrecioFacturar"
        Me.cmbListaPrecioFacturar.Size = New System.Drawing.Size(188, 21)
        Me.cmbListaPrecioFacturar.TabIndex = 8
        Me.cmbListaPrecioFacturar.Tag = "VENTASPRECIOVENTA"
        '
        'cmbMovimientoConsumo
        '
        Me.cmbMovimientoConsumo.BindearPropiedadControl = Nothing
        Me.cmbMovimientoConsumo.BindearPropiedadEntidad = Nothing
        Me.cmbMovimientoConsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMovimientoConsumo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMovimientoConsumo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMovimientoConsumo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMovimientoConsumo.FormattingEnabled = True
        Me.cmbMovimientoConsumo.IsPK = False
        Me.cmbMovimientoConsumo.IsRequired = False
        Me.cmbMovimientoConsumo.Items.AddRange(New Object() {"ACTUAL", "ULTIMO"})
        Me.cmbMovimientoConsumo.Key = Nothing
        Me.cmbMovimientoConsumo.LabelAsoc = Me.lblMovimientoConsumo
        Me.cmbMovimientoConsumo.Location = New System.Drawing.Point(165, 178)
        Me.cmbMovimientoConsumo.Name = "cmbMovimientoConsumo"
        Me.cmbMovimientoConsumo.Size = New System.Drawing.Size(334, 21)
        Me.cmbMovimientoConsumo.TabIndex = 10
        Me.cmbMovimientoConsumo.Tag = "VENTASPRECIOVENTA"
        '
        'lblMovimientoConsumo
        '
        Me.lblMovimientoConsumo.AutoSize = True
        Me.lblMovimientoConsumo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMovimientoConsumo.LabelAsoc = Nothing
        Me.lblMovimientoConsumo.Location = New System.Drawing.Point(9, 182)
        Me.lblMovimientoConsumo.Name = "lblMovimientoConsumo"
        Me.lblMovimientoConsumo.Size = New System.Drawing.Size(132, 13)
        Me.lblMovimientoConsumo.TabIndex = 9
        Me.lblMovimientoConsumo.Text = "Movimiento para Consumo"
        '
        'cmbMovimientoReversado
        '
        Me.cmbMovimientoReversado.BindearPropiedadControl = Nothing
        Me.cmbMovimientoReversado.BindearPropiedadEntidad = Nothing
        Me.cmbMovimientoReversado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMovimientoReversado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMovimientoReversado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMovimientoReversado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMovimientoReversado.FormattingEnabled = True
        Me.cmbMovimientoReversado.IsPK = False
        Me.cmbMovimientoReversado.IsRequired = False
        Me.cmbMovimientoReversado.Items.AddRange(New Object() {"ACTUAL", "ULTIMO"})
        Me.cmbMovimientoReversado.Key = Nothing
        Me.cmbMovimientoReversado.LabelAsoc = Me.lblMovimientoReversado
        Me.cmbMovimientoReversado.Location = New System.Drawing.Point(165, 209)
        Me.cmbMovimientoReversado.Name = "cmbMovimientoReversado"
        Me.cmbMovimientoReversado.Size = New System.Drawing.Size(334, 21)
        Me.cmbMovimientoReversado.TabIndex = 12
        Me.cmbMovimientoReversado.Tag = "VENTASPRECIOVENTA"
        '
        'lblMovimientoReversado
        '
        Me.lblMovimientoReversado.AutoSize = True
        Me.lblMovimientoReversado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMovimientoReversado.LabelAsoc = Nothing
        Me.lblMovimientoReversado.Location = New System.Drawing.Point(9, 213)
        Me.lblMovimientoReversado.Name = "lblMovimientoReversado"
        Me.lblMovimientoReversado.Size = New System.Drawing.Size(140, 13)
        Me.lblMovimientoReversado.TabIndex = 11
        Me.lblMovimientoReversado.Text = "Movimiento para Reversado"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = Nothing
        Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Me.lblFormaPago
        Me.cmbFormaPago.Location = New System.Drawing.Point(165, 303)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(226, 21)
        Me.cmbFormaPago.TabIndex = 14
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFormaPago.LabelAsoc = Nothing
        Me.lblFormaPago.Location = New System.Drawing.Point(9, 306)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(118, 13)
        Me.lblFormaPago.TabIndex = 13
        Me.lblFormaPago.Text = "Forma de &Pago Factura"
        '
        'chkCopiarSaldoComoEfectivoAlFacturar
        '
        Me.chkCopiarSaldoComoEfectivoAlFacturar.AutoSize = True
        Me.chkCopiarSaldoComoEfectivoAlFacturar.BindearPropiedadControl = Nothing
        Me.chkCopiarSaldoComoEfectivoAlFacturar.BindearPropiedadEntidad = Nothing
        Me.chkCopiarSaldoComoEfectivoAlFacturar.ForeColorFocus = System.Drawing.Color.Red
        Me.chkCopiarSaldoComoEfectivoAlFacturar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkCopiarSaldoComoEfectivoAlFacturar.IsPK = False
        Me.chkCopiarSaldoComoEfectivoAlFacturar.IsRequired = False
        Me.chkCopiarSaldoComoEfectivoAlFacturar.Key = Nothing
        Me.chkCopiarSaldoComoEfectivoAlFacturar.LabelAsoc = Nothing
        Me.chkCopiarSaldoComoEfectivoAlFacturar.Location = New System.Drawing.Point(165, 330)
        Me.chkCopiarSaldoComoEfectivoAlFacturar.Name = "chkCopiarSaldoComoEfectivoAlFacturar"
        Me.chkCopiarSaldoComoEfectivoAlFacturar.Size = New System.Drawing.Size(207, 17)
        Me.chkCopiarSaldoComoEfectivoAlFacturar.TabIndex = 59
        Me.chkCopiarSaldoComoEfectivoAlFacturar.Text = "Copiar saldo como efectivo al Facturar"
        Me.chkCopiarSaldoComoEfectivoAlFacturar.UseVisualStyleBackColor = True
        '
        'chbProductosRepNoFactura
        '
        Me.chbProductosRepNoFactura.BindearPropiedadControl = Nothing
        Me.chbProductosRepNoFactura.BindearPropiedadEntidad = Nothing
        Me.chbProductosRepNoFactura.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProductosRepNoFactura.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProductosRepNoFactura.IsPK = False
        Me.chbProductosRepNoFactura.IsRequired = False
        Me.chbProductosRepNoFactura.Key = Nothing
        Me.chbProductosRepNoFactura.LabelAsoc = Nothing
        Me.chbProductosRepNoFactura.Location = New System.Drawing.Point(12, 65)
        Me.chbProductosRepNoFactura.Name = "chbProductosRepNoFactura"
        Me.chbProductosRepNoFactura.Size = New System.Drawing.Size(399, 26)
        Me.chbProductosRepNoFactura.TabIndex = 60
        Me.chbProductosRepNoFactura.Text = "Productos consumidos en Reparación no se muestran en Factura"
        Me.chbProductosRepNoFactura.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.lblDepositoOrigen)
        Me.GroupBox13.Controls.Add(Me.cmbDepositoOrigen)
        Me.GroupBox13.Controls.Add(Me.lblUbicacionReserva)
        Me.GroupBox13.Controls.Add(Me.cmbUbicacionOrigen)
        Me.GroupBox13.Location = New System.Drawing.Point(550, 43)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(257, 119)
        Me.GroupBox13.TabIndex = 61
        Me.GroupBox13.TabStop = False
        '
        'lblDepositoOrigen
        '
        Me.lblDepositoOrigen.AutoSize = True
        Me.lblDepositoOrigen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDepositoOrigen.LabelAsoc = Nothing
        Me.lblDepositoOrigen.Location = New System.Drawing.Point(14, 20)
        Me.lblDepositoOrigen.Name = "lblDepositoOrigen"
        Me.lblDepositoOrigen.Size = New System.Drawing.Size(178, 13)
        Me.lblDepositoOrigen.TabIndex = 41
        Me.lblDepositoOrigen.Text = "Depósito de Reserva de Mercaderia"
        '
        'cmbDepositoOrigen
        '
        Me.cmbDepositoOrigen.BindearPropiedadControl = ""
        Me.cmbDepositoOrigen.BindearPropiedadEntidad = ""
        Me.cmbDepositoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositoOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbDepositoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositoOrigen.FormattingEnabled = True
        Me.cmbDepositoOrigen.IsPK = False
        Me.cmbDepositoOrigen.IsRequired = False
        Me.cmbDepositoOrigen.Key = Nothing
        Me.cmbDepositoOrigen.LabelAsoc = Me.lblDepositoOrigen
        Me.cmbDepositoOrigen.Location = New System.Drawing.Point(17, 38)
        Me.cmbDepositoOrigen.Name = "cmbDepositoOrigen"
        Me.cmbDepositoOrigen.Size = New System.Drawing.Size(226, 21)
        Me.cmbDepositoOrigen.TabIndex = 40
        '
        'lblUbicacionReserva
        '
        Me.lblUbicacionReserva.AutoSize = True
        Me.lblUbicacionReserva.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUbicacionReserva.LabelAsoc = Nothing
        Me.lblUbicacionReserva.Location = New System.Drawing.Point(14, 65)
        Me.lblUbicacionReserva.Name = "lblUbicacionReserva"
        Me.lblUbicacionReserva.Size = New System.Drawing.Size(184, 13)
        Me.lblUbicacionReserva.TabIndex = 43
        Me.lblUbicacionReserva.Text = "Ubicación de Reserva de Mercaderia"
        '
        'cmbUbicacionOrigen
        '
        Me.cmbUbicacionOrigen.BindearPropiedadControl = ""
        Me.cmbUbicacionOrigen.BindearPropiedadEntidad = ""
        Me.cmbUbicacionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacionOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbUbicacionOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacionOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacionOrigen.FormattingEnabled = True
        Me.cmbUbicacionOrigen.IsPK = False
        Me.cmbUbicacionOrigen.IsRequired = False
        Me.cmbUbicacionOrigen.Key = Nothing
        Me.cmbUbicacionOrigen.LabelAsoc = Me.lblUbicacionReserva
        Me.cmbUbicacionOrigen.Location = New System.Drawing.Point(17, 83)
        Me.cmbUbicacionOrigen.Name = "cmbUbicacionOrigen"
        Me.cmbUbicacionOrigen.Size = New System.Drawing.Size(226, 21)
        Me.cmbUbicacionOrigen.TabIndex = 42
        '
        'cmbMovimientoDevReserva
        '
        Me.cmbMovimientoDevReserva.BindearPropiedadControl = Nothing
        Me.cmbMovimientoDevReserva.BindearPropiedadEntidad = Nothing
        Me.cmbMovimientoDevReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMovimientoDevReserva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMovimientoDevReserva.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMovimientoDevReserva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMovimientoDevReserva.FormattingEnabled = True
        Me.cmbMovimientoDevReserva.IsPK = False
        Me.cmbMovimientoDevReserva.IsRequired = False
        Me.cmbMovimientoDevReserva.Items.AddRange(New Object() {"ACTUAL", "ULTIMO"})
        Me.cmbMovimientoDevReserva.Key = Nothing
        Me.cmbMovimientoDevReserva.LabelAsoc = Me.lblMovimientoDevReserva
        Me.cmbMovimientoDevReserva.Location = New System.Drawing.Point(165, 273)
        Me.cmbMovimientoDevReserva.Name = "cmbMovimientoDevReserva"
        Me.cmbMovimientoDevReserva.Size = New System.Drawing.Size(334, 21)
        Me.cmbMovimientoDevReserva.TabIndex = 65
        Me.cmbMovimientoDevReserva.Tag = "VENTASPRECIOVENTA"
        '
        'lblMovimientoDevReserva
        '
        Me.lblMovimientoDevReserva.AutoSize = True
        Me.lblMovimientoDevReserva.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMovimientoDevReserva.LabelAsoc = Nothing
        Me.lblMovimientoDevReserva.Location = New System.Drawing.Point(9, 277)
        Me.lblMovimientoDevReserva.Name = "lblMovimientoDevReserva"
        Me.lblMovimientoDevReserva.Size = New System.Drawing.Size(151, 13)
        Me.lblMovimientoDevReserva.TabIndex = 64
        Me.lblMovimientoDevReserva.Text = "Movimiento para Dev Reserva"
        '
        'cmbMovimientoReserva
        '
        Me.cmbMovimientoReserva.BindearPropiedadControl = Nothing
        Me.cmbMovimientoReserva.BindearPropiedadEntidad = Nothing
        Me.cmbMovimientoReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMovimientoReserva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMovimientoReserva.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMovimientoReserva.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMovimientoReserva.FormattingEnabled = True
        Me.cmbMovimientoReserva.IsPK = False
        Me.cmbMovimientoReserva.IsRequired = False
        Me.cmbMovimientoReserva.Items.AddRange(New Object() {"ACTUAL", "ULTIMO"})
        Me.cmbMovimientoReserva.Key = Nothing
        Me.cmbMovimientoReserva.LabelAsoc = Me.lblMovimientoReserva
        Me.cmbMovimientoReserva.Location = New System.Drawing.Point(165, 242)
        Me.cmbMovimientoReserva.Name = "cmbMovimientoReserva"
        Me.cmbMovimientoReserva.Size = New System.Drawing.Size(334, 21)
        Me.cmbMovimientoReserva.TabIndex = 63
        Me.cmbMovimientoReserva.Tag = "VENTASPRECIOVENTA"
        '
        'lblMovimientoReserva
        '
        Me.lblMovimientoReserva.AutoSize = True
        Me.lblMovimientoReserva.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMovimientoReserva.LabelAsoc = Nothing
        Me.lblMovimientoReserva.Location = New System.Drawing.Point(9, 246)
        Me.lblMovimientoReserva.Name = "lblMovimientoReserva"
        Me.lblMovimientoReserva.Size = New System.Drawing.Size(128, 13)
        Me.lblMovimientoReserva.TabIndex = 62
        Me.lblMovimientoReserva.Text = "Movimiento para Reserva"
        '
        'ucConfRMA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbMovimientoDevReserva)
        Me.Controls.Add(Me.lblMovimientoDevReserva)
        Me.Controls.Add(Me.cmbMovimientoReserva)
        Me.Controls.Add(Me.lblMovimientoReserva)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.chbProductosRepNoFactura)
        Me.Controls.Add(Me.chkCopiarSaldoComoEfectivoAlFacturar)
        Me.Controls.Add(Me.cmbFormaPago)
        Me.Controls.Add(Me.lblFormaPago)
        Me.Controls.Add(Me.cmbMovimientoReversado)
        Me.Controls.Add(Me.lblMovimientoReversado)
        Me.Controls.Add(Me.cmbMovimientoConsumo)
        Me.Controls.Add(Me.lblMovimientoConsumo)
        Me.Controls.Add(Me.cmbListaPrecioFacturar)
        Me.Controls.Add(Me.lblListaPrecioFacturar)
        Me.Controls.Add(Me.lblRMACantidadMesesHistorico)
        Me.Controls.Add(Me.txtCRMNovedadesObservacionFacturable)
        Me.Controls.Add(Me.txtRMACantidadMesesHistorico)
        Me.Controls.Add(Me.chbImprime1copiaNR)
        Me.Controls.Add(Me.lblCRMNovedadesObservacionFacturable)
        Me.Controls.Add(Me.txtCRMNovedadesProductoFacturable)
        Me.Controls.Add(Me.lblCRMNovedadesProductoFacturable)
        Me.Name = "ucConfRMA"
        Me.Controls.SetChildIndex(Me.lblCRMNovedadesProductoFacturable, 0)
        Me.Controls.SetChildIndex(Me.txtCRMNovedadesProductoFacturable, 0)
        Me.Controls.SetChildIndex(Me.lblCRMNovedadesObservacionFacturable, 0)
        Me.Controls.SetChildIndex(Me.chbImprime1copiaNR, 0)
        Me.Controls.SetChildIndex(Me.txtRMACantidadMesesHistorico, 0)
        Me.Controls.SetChildIndex(Me.txtCRMNovedadesObservacionFacturable, 0)
        Me.Controls.SetChildIndex(Me.lblRMACantidadMesesHistorico, 0)
        Me.Controls.SetChildIndex(Me.lblListaPrecioFacturar, 0)
        Me.Controls.SetChildIndex(Me.cmbListaPrecioFacturar, 0)
        Me.Controls.SetChildIndex(Me.lblMovimientoConsumo, 0)
        Me.Controls.SetChildIndex(Me.cmbMovimientoConsumo, 0)
        Me.Controls.SetChildIndex(Me.lblMovimientoReversado, 0)
        Me.Controls.SetChildIndex(Me.cmbMovimientoReversado, 0)
        Me.Controls.SetChildIndex(Me.lblFormaPago, 0)
        Me.Controls.SetChildIndex(Me.cmbFormaPago, 0)
        Me.Controls.SetChildIndex(Me.chkCopiarSaldoComoEfectivoAlFacturar, 0)
        Me.Controls.SetChildIndex(Me.chbProductosRepNoFactura, 0)
        Me.Controls.SetChildIndex(Me.GroupBox13, 0)
        Me.Controls.SetChildIndex(Me.lblMovimientoReserva, 0)
        Me.Controls.SetChildIndex(Me.cmbMovimientoReserva, 0)
        Me.Controls.SetChildIndex(Me.lblMovimientoDevReserva, 0)
        Me.Controls.SetChildIndex(Me.cmbMovimientoDevReserva, 0)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRMACantidadMesesHistorico As Controles.Label
   Friend WithEvents txtCRMNovedadesObservacionFacturable As Controles.TextBox
   Friend WithEvents txtRMACantidadMesesHistorico As Controles.TextBox
   Friend WithEvents chbImprime1copiaNR As Controles.CheckBox
   Friend WithEvents lblCRMNovedadesObservacionFacturable As Controles.Label
   Friend WithEvents txtCRMNovedadesProductoFacturable As Controles.TextBox
   Friend WithEvents lblCRMNovedadesProductoFacturable As Controles.Label
   Friend WithEvents cmbListaPrecioFacturar As Controles.ComboBox
   Friend WithEvents lblListaPrecioFacturar As Controles.Label
    Friend WithEvents cmbMovimientoConsumo As Controles.ComboBox
    Friend WithEvents lblMovimientoConsumo As Controles.Label
    Friend WithEvents cmbMovimientoReversado As Controles.ComboBox
    Friend WithEvents lblMovimientoReversado As Controles.Label
    Friend WithEvents cmbFormaPago As Controles.ComboBox
    Friend WithEvents lblFormaPago As Controles.Label
    Friend WithEvents chkCopiarSaldoComoEfectivoAlFacturar As Controles.CheckBox
    Friend WithEvents chbProductosRepNoFactura As Controles.CheckBox
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents lblDepositoOrigen As Controles.Label
    Friend WithEvents cmbDepositoOrigen As Controles.ComboBox
    Friend WithEvents lblUbicacionReserva As Controles.Label
    Friend WithEvents cmbUbicacionOrigen As Controles.ComboBox
    Friend WithEvents cmbMovimientoDevReserva As Controles.ComboBox
    Friend WithEvents lblMovimientoDevReserva As Controles.Label
    Friend WithEvents cmbMovimientoReserva As Controles.ComboBox
    Friend WithEvents lblMovimientoReserva As Controles.Label
End Class
