<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadosOrdenesProduccionDetalle
   Inherits Eniac.Win.BaseDetalle


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
      Me.lblTipoEstado = New Eniac.Controles.Label()
      Me.cmbTiposEstados = New Eniac.Controles.ComboBox()
      Me.lblComprobante = New Eniac.Controles.Label()
      Me.cmbComprobantes = New Eniac.Controles.ComboBox()
      Me.lblIdTipoEstado = New Eniac.Controles.Label()
      Me.txtidTipoEstado = New Eniac.Controles.TextBox()
      Me.btnLimpiarTamaño = New Eniac.Controles.Button()
      Me.lblOrden = New Eniac.Controles.Label()
      Me.txtOrden = New Eniac.Controles.TextBox()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.lblColorSemadoro = New Eniac.Controles.Label()
      Me.btnColor = New System.Windows.Forms.Button()
      Me.cdColor = New System.Windows.Forms.ColorDialog()
      Me.chbReservaMateriaPrima = New Eniac.Controles.CheckBox()
      Me.chbGeneraProductoTerminado = New Eniac.Controles.CheckBox()
      Me.cmbIdEstadoPedido = New Eniac.Controles.ComboBox()
      Me.lblIdEstadoPedido = New Eniac.Controles.Label()
      Me.btnIdEstadoPedido = New Eniac.Controles.Button()
        Me.grpReservaMateriaPrima = New System.Windows.Forms.GroupBox()
        Me.lblDepositoOrigen = New Eniac.Controles.Label()
        Me.cmbDepositoOrigen = New Eniac.Controles.ComboBox()
        Me.lblUbicacionOrigen = New Eniac.Controles.Label()
        Me.cmbUbicacionOrigen = New Eniac.Controles.ComboBox()
        Me.grpReservaMateriaPrima.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(103, 321)
        Me.btnAceptar.TabIndex = 18
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(195, 321)
        Me.btnCancelar.TabIndex = 19
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(2, 321)
        Me.btnCopiar.TabIndex = 17
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(12, 321)
        '
        'lblTipoEstado
        '
        Me.lblTipoEstado.AutoSize = True
        Me.lblTipoEstado.LabelAsoc = Nothing
        Me.lblTipoEstado.Location = New System.Drawing.Point(19, 79)
        Me.lblTipoEstado.Name = "lblTipoEstado"
        Me.lblTipoEstado.Size = New System.Drawing.Size(64, 13)
        Me.lblTipoEstado.TabIndex = 5
        Me.lblTipoEstado.Text = "Tipo Estado"
        '
        'cmbTiposEstados
        '
        Me.cmbTiposEstados.BindearPropiedadControl = "SelectedValue"
        Me.cmbTiposEstados.BindearPropiedadEntidad = "IdTipoEstado"
        Me.cmbTiposEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiposEstados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposEstados.FormattingEnabled = True
        Me.cmbTiposEstados.IsPK = False
        Me.cmbTiposEstados.IsRequired = True
        Me.cmbTiposEstados.Key = Nothing
        Me.cmbTiposEstados.LabelAsoc = Me.lblTipoEstado
        Me.cmbTiposEstados.Location = New System.Drawing.Point(103, 76)
        Me.cmbTiposEstados.Name = "cmbTiposEstados"
        Me.cmbTiposEstados.Size = New System.Drawing.Size(139, 21)
        Me.cmbTiposEstados.TabIndex = 6
        '
        'lblComprobante
        '
        Me.lblComprobante.AutoSize = True
        Me.lblComprobante.LabelAsoc = Nothing
        Me.lblComprobante.Location = New System.Drawing.Point(19, 52)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(70, 13)
        Me.lblComprobante.TabIndex = 2
        Me.lblComprobante.Text = "Comprobante"
        '
        'cmbComprobantes
        '
        Me.cmbComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbComprobantes.BindearPropiedadEntidad = "IdTipoComprobante"
        Me.cmbComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbComprobantes.FormattingEnabled = True
        Me.cmbComprobantes.IsPK = False
        Me.cmbComprobantes.IsRequired = False
        Me.cmbComprobantes.Key = Nothing
        Me.cmbComprobantes.LabelAsoc = Me.lblComprobante
        Me.cmbComprobantes.Location = New System.Drawing.Point(103, 49)
        Me.cmbComprobantes.Name = "cmbComprobantes"
        Me.cmbComprobantes.Size = New System.Drawing.Size(139, 21)
        Me.cmbComprobantes.TabIndex = 3
        '
        'lblIdTipoEstado
        '
        Me.lblIdTipoEstado.AutoSize = True
        Me.lblIdTipoEstado.LabelAsoc = Nothing
        Me.lblIdTipoEstado.Location = New System.Drawing.Point(19, 26)
        Me.lblIdTipoEstado.Name = "lblIdTipoEstado"
        Me.lblIdTipoEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblIdTipoEstado.TabIndex = 0
        Me.lblIdTipoEstado.Text = "Estado"
        '
        'txtidTipoEstado
        '
        Me.txtidTipoEstado.BindearPropiedadControl = "Text"
        Me.txtidTipoEstado.BindearPropiedadEntidad = "IdEstado"
        Me.txtidTipoEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtidTipoEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtidTipoEstado.Formato = ""
        Me.txtidTipoEstado.IsDecimal = False
        Me.txtidTipoEstado.IsNumber = False
        Me.txtidTipoEstado.IsPK = True
        Me.txtidTipoEstado.IsRequired = True
        Me.txtidTipoEstado.Key = ""
        Me.txtidTipoEstado.LabelAsoc = Me.lblIdTipoEstado
        Me.txtidTipoEstado.Location = New System.Drawing.Point(103, 23)
        Me.txtidTipoEstado.MaxLength = 10
        Me.txtidTipoEstado.Name = "txtidTipoEstado"
        Me.txtidTipoEstado.Size = New System.Drawing.Size(139, 20)
        Me.txtidTipoEstado.TabIndex = 1
        '
        'btnLimpiarTamaño
        '
        Me.btnLimpiarTamaño.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiarTamaño.Location = New System.Drawing.Point(245, 44)
        Me.btnLimpiarTamaño.Name = "btnLimpiarTamaño"
        Me.btnLimpiarTamaño.Size = New System.Drawing.Size(30, 30)
        Me.btnLimpiarTamaño.TabIndex = 4
        Me.btnLimpiarTamaño.TabStop = False
        Me.btnLimpiarTamaño.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarTamaño.UseVisualStyleBackColor = True
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.LabelAsoc = Nothing
        Me.lblOrden.Location = New System.Drawing.Point(19, 107)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblOrden.TabIndex = 7
        Me.lblOrden.Text = "Orden"
        '
        'txtOrden
        '
        Me.txtOrden.BindearPropiedadControl = "Text"
        Me.txtOrden.BindearPropiedadEntidad = "Orden"
        Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrden.Formato = ""
        Me.txtOrden.IsDecimal = False
        Me.txtOrden.IsNumber = True
        Me.txtOrden.IsPK = False
        Me.txtOrden.IsRequired = True
        Me.txtOrden.Key = ""
        Me.txtOrden.LabelAsoc = Me.lblOrden
        Me.txtOrden.Location = New System.Drawing.Point(103, 103)
        Me.txtOrden.MaxLength = 2
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(29, 20)
        Me.txtOrden.TabIndex = 8
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtColor
        '
        Me.txtColor.BindearPropiedadControl = "Key"
        Me.txtColor.BindearPropiedadEntidad = "Color"
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = False
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Me.lblColorSemadoro
        Me.txtColor.Location = New System.Drawing.Point(103, 129)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(82, 20)
        Me.txtColor.TabIndex = 10
        '
        'lblColorSemadoro
        '
        Me.lblColorSemadoro.AutoSize = True
        Me.lblColorSemadoro.LabelAsoc = Nothing
        Me.lblColorSemadoro.Location = New System.Drawing.Point(19, 133)
        Me.lblColorSemadoro.Name = "lblColorSemadoro"
        Me.lblColorSemadoro.Size = New System.Drawing.Size(31, 13)
        Me.lblColorSemadoro.TabIndex = 9
        Me.lblColorSemadoro.Text = "Color"
        '
        'btnColor
        '
        Me.btnColor.Location = New System.Drawing.Point(191, 128)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(57, 23)
        Me.btnColor.TabIndex = 11
        Me.btnColor.Text = "Paleta"
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'chbReservaMateriaPrima
        '
        Me.chbReservaMateriaPrima.AutoSize = True
        Me.chbReservaMateriaPrima.BindearPropiedadControl = "Checked"
        Me.chbReservaMateriaPrima.BindearPropiedadEntidad = "ReservaMateriaPrima"
        Me.chbReservaMateriaPrima.ForeColorFocus = System.Drawing.Color.Red
        Me.chbReservaMateriaPrima.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbReservaMateriaPrima.IsPK = False
        Me.chbReservaMateriaPrima.IsRequired = False
        Me.chbReservaMateriaPrima.Key = Nothing
        Me.chbReservaMateriaPrima.LabelAsoc = Nothing
        Me.chbReservaMateriaPrima.Location = New System.Drawing.Point(6, 14)
        Me.chbReservaMateriaPrima.Name = "chbReservaMateriaPrima"
        Me.chbReservaMateriaPrima.Size = New System.Drawing.Size(133, 17)
        Me.chbReservaMateriaPrima.TabIndex = 12
        Me.chbReservaMateriaPrima.Tag = ""
        Me.chbReservaMateriaPrima.Text = "Reserva Materia Prima"
        Me.chbReservaMateriaPrima.UseVisualStyleBackColor = True
        '
        'chbGeneraProductoTerminado
        '
        Me.chbGeneraProductoTerminado.AutoSize = True
        Me.chbGeneraProductoTerminado.BindearPropiedadControl = "Checked"
        Me.chbGeneraProductoTerminado.BindearPropiedadEntidad = "GeneraProductoTerminado"
        Me.chbGeneraProductoTerminado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGeneraProductoTerminado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGeneraProductoTerminado.IsPK = False
        Me.chbGeneraProductoTerminado.IsRequired = False
        Me.chbGeneraProductoTerminado.Key = Nothing
        Me.chbGeneraProductoTerminado.LabelAsoc = Nothing
        Me.chbGeneraProductoTerminado.Location = New System.Drawing.Point(22, 263)
        Me.chbGeneraProductoTerminado.Name = "chbGeneraProductoTerminado"
        Me.chbGeneraProductoTerminado.Size = New System.Drawing.Size(160, 17)
        Me.chbGeneraProductoTerminado.TabIndex = 13
        Me.chbGeneraProductoTerminado.Tag = ""
        Me.chbGeneraProductoTerminado.Text = "Genera Producto Terminado"
        Me.chbGeneraProductoTerminado.UseVisualStyleBackColor = True
        '
        'cmbIdEstadoPedido
        '
        Me.cmbIdEstadoPedido.BindearPropiedadControl = "SelectedValue"
        Me.cmbIdEstadoPedido.BindearPropiedadEntidad = "IdEstadoPedido"
        Me.cmbIdEstadoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdEstadoPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdEstadoPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIdEstadoPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIdEstadoPedido.FormattingEnabled = True
        Me.cmbIdEstadoPedido.IsPK = False
        Me.cmbIdEstadoPedido.IsRequired = False
        Me.cmbIdEstadoPedido.Key = Nothing
        Me.cmbIdEstadoPedido.LabelAsoc = Me.lblIdEstadoPedido
        Me.cmbIdEstadoPedido.Location = New System.Drawing.Point(103, 289)
        Me.cmbIdEstadoPedido.Name = "cmbIdEstadoPedido"
        Me.cmbIdEstadoPedido.Size = New System.Drawing.Size(139, 21)
        Me.cmbIdEstadoPedido.TabIndex = 15
        '
        'lblIdEstadoPedido
        '
        Me.lblIdEstadoPedido.AutoSize = True
        Me.lblIdEstadoPedido.LabelAsoc = Nothing
        Me.lblIdEstadoPedido.Location = New System.Drawing.Point(19, 292)
        Me.lblIdEstadoPedido.Name = "lblIdEstadoPedido"
        Me.lblIdEstadoPedido.Size = New System.Drawing.Size(76, 13)
        Me.lblIdEstadoPedido.TabIndex = 14
        Me.lblIdEstadoPedido.Text = "Estado Pedido"
        '
        'btnIdEstadoPedido
        '
        Me.btnIdEstadoPedido.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnIdEstadoPedido.Location = New System.Drawing.Point(245, 283)
        Me.btnIdEstadoPedido.Name = "btnIdEstadoPedido"
        Me.btnIdEstadoPedido.Size = New System.Drawing.Size(30, 30)
        Me.btnIdEstadoPedido.TabIndex = 16
        Me.btnIdEstadoPedido.TabStop = False
        Me.btnIdEstadoPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIdEstadoPedido.UseVisualStyleBackColor = True
        '
        'grpReservaMateriaPrima
        '
        Me.grpReservaMateriaPrima.Controls.Add(Me.lblDepositoOrigen)
        Me.grpReservaMateriaPrima.Controls.Add(Me.cmbDepositoOrigen)
        Me.grpReservaMateriaPrima.Controls.Add(Me.chbReservaMateriaPrima)
        Me.grpReservaMateriaPrima.Controls.Add(Me.lblUbicacionOrigen)
        Me.grpReservaMateriaPrima.Controls.Add(Me.cmbUbicacionOrigen)
        Me.grpReservaMateriaPrima.Location = New System.Drawing.Point(17, 157)
        Me.grpReservaMateriaPrima.Name = "grpReservaMateriaPrima"
        Me.grpReservaMateriaPrima.Size = New System.Drawing.Size(258, 100)
        Me.grpReservaMateriaPrima.TabIndex = 20
        Me.grpReservaMateriaPrima.TabStop = False
        '
        'lblDepositoOrigen
        '
        Me.lblDepositoOrigen.AutoSize = True
        Me.lblDepositoOrigen.LabelAsoc = Nothing
        Me.lblDepositoOrigen.Location = New System.Drawing.Point(10, 40)
        Me.lblDepositoOrigen.Name = "lblDepositoOrigen"
        Me.lblDepositoOrigen.Size = New System.Drawing.Size(49, 13)
        Me.lblDepositoOrigen.TabIndex = 1
        Me.lblDepositoOrigen.Text = "Depósito"
        '
        'cmbDepositoOrigen
        '
        Me.cmbDepositoOrigen.BindearPropiedadControl = "SelectedValue"
        Me.cmbDepositoOrigen.BindearPropiedadEntidad = "IdDeposito"
        Me.cmbDepositoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositoOrigen.Enabled = False
        Me.cmbDepositoOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepositoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositoOrigen.FormattingEnabled = True
        Me.cmbDepositoOrigen.IsPK = False
        Me.cmbDepositoOrigen.IsRequired = False
        Me.cmbDepositoOrigen.Key = Nothing
        Me.cmbDepositoOrigen.LabelAsoc = Me.lblDepositoOrigen
        Me.cmbDepositoOrigen.Location = New System.Drawing.Point(70, 37)
        Me.cmbDepositoOrigen.Name = "cmbDepositoOrigen"
        Me.cmbDepositoOrigen.Size = New System.Drawing.Size(174, 21)
        Me.cmbDepositoOrigen.TabIndex = 2
        '
        'lblUbicacionOrigen
        '
        Me.lblUbicacionOrigen.AutoSize = True
        Me.lblUbicacionOrigen.LabelAsoc = Nothing
        Me.lblUbicacionOrigen.Location = New System.Drawing.Point(10, 67)
        Me.lblUbicacionOrigen.Name = "lblUbicacionOrigen"
        Me.lblUbicacionOrigen.Size = New System.Drawing.Size(55, 13)
        Me.lblUbicacionOrigen.TabIndex = 3
        Me.lblUbicacionOrigen.Text = "Ubicación"
        '
        'cmbUbicacionOrigen
        '
        Me.cmbUbicacionOrigen.BindearPropiedadControl = "SelectedValue"
        Me.cmbUbicacionOrigen.BindearPropiedadEntidad = "IdUbicacion"
        Me.cmbUbicacionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacionOrigen.Enabled = False
        Me.cmbUbicacionOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacionOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacionOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacionOrigen.FormattingEnabled = True
        Me.cmbUbicacionOrigen.IsPK = False
        Me.cmbUbicacionOrigen.IsRequired = False
        Me.cmbUbicacionOrigen.Key = Nothing
        Me.cmbUbicacionOrigen.LabelAsoc = Me.lblUbicacionOrigen
        Me.cmbUbicacionOrigen.Location = New System.Drawing.Point(70, 64)
        Me.cmbUbicacionOrigen.Name = "cmbUbicacionOrigen"
        Me.cmbUbicacionOrigen.Size = New System.Drawing.Size(174, 21)
        Me.cmbUbicacionOrigen.TabIndex = 4
        '
        'EstadosOrdenesProduccionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 363)
        Me.Controls.Add(Me.grpReservaMateriaPrima)
        Me.Controls.Add(Me.chbGeneraProductoTerminado)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.lblColorSemadoro)
        Me.Controls.Add(Me.btnColor)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.btnIdEstadoPedido)
        Me.Controls.Add(Me.btnLimpiarTamaño)
        Me.Controls.Add(Me.lblIdTipoEstado)
        Me.Controls.Add(Me.txtidTipoEstado)
        Me.Controls.Add(Me.lblComprobante)
        Me.Controls.Add(Me.cmbComprobantes)
        Me.Controls.Add(Me.lblIdEstadoPedido)
        Me.Controls.Add(Me.lblTipoEstado)
        Me.Controls.Add(Me.cmbIdEstadoPedido)
        Me.Controls.Add(Me.cmbTiposEstados)
        Me.Name = "EstadosOrdenesProduccionDetalle"
        Me.Text = "Estado de Orden de Porducción"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.cmbTiposEstados, 0)
        Me.Controls.SetChildIndex(Me.cmbIdEstadoPedido, 0)
        Me.Controls.SetChildIndex(Me.lblTipoEstado, 0)
        Me.Controls.SetChildIndex(Me.lblIdEstadoPedido, 0)
        Me.Controls.SetChildIndex(Me.cmbComprobantes, 0)
        Me.Controls.SetChildIndex(Me.lblComprobante, 0)
        Me.Controls.SetChildIndex(Me.txtidTipoEstado, 0)
        Me.Controls.SetChildIndex(Me.lblIdTipoEstado, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiarTamaño, 0)
        Me.Controls.SetChildIndex(Me.btnIdEstadoPedido, 0)
        Me.Controls.SetChildIndex(Me.txtOrden, 0)
        Me.Controls.SetChildIndex(Me.lblOrden, 0)
        Me.Controls.SetChildIndex(Me.btnColor, 0)
        Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
        Me.Controls.SetChildIndex(Me.txtColor, 0)
        Me.Controls.SetChildIndex(Me.chbGeneraProductoTerminado, 0)
        Me.Controls.SetChildIndex(Me.grpReservaMateriaPrima, 0)
        Me.grpReservaMateriaPrima.ResumeLayout(False)
        Me.grpReservaMateriaPrima.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTipoEstado As Eniac.Controles.Label
   Friend WithEvents cmbTiposEstados As Eniac.Controles.ComboBox
   Friend WithEvents lblComprobante As Eniac.Controles.Label
   Friend WithEvents cmbComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents lblIdTipoEstado As Eniac.Controles.Label
   Friend WithEvents txtidTipoEstado As Eniac.Controles.TextBox
   Friend WithEvents btnLimpiarTamaño As Eniac.Controles.Button
   Friend WithEvents lblOrden As Eniac.Controles.Label
   Friend WithEvents txtOrden As Eniac.Controles.TextBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Friend WithEvents chbReservaMateriaPrima As Eniac.Controles.CheckBox
   Friend WithEvents chbGeneraProductoTerminado As Eniac.Controles.CheckBox
   Friend WithEvents cmbIdEstadoPedido As Eniac.Controles.ComboBox
   Friend WithEvents lblIdEstadoPedido As Eniac.Controles.Label
   Friend WithEvents btnIdEstadoPedido As Eniac.Controles.Button
    Friend WithEvents grpReservaMateriaPrima As GroupBox
    Friend WithEvents lblDepositoOrigen As Controles.Label
    Friend WithEvents cmbDepositoOrigen As Controles.ComboBox
    Friend WithEvents lblUbicacionOrigen As Controles.Label
    Friend WithEvents cmbUbicacionOrigen As Controles.ComboBox
End Class
