<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaDePreciosDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaDePreciosDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblIdLista = New Eniac.Controles.Label()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.dtpVigencia = New Eniac.Controles.DateTimePicker()
      Me.lblVigencia = New Eniac.Controles.Label()
      Me.cmbListaPrecios = New Eniac.Controles.ComboBox()
      Me.lblListaPrecios = New Eniac.Controles.Label()
      Me.txtDescuentoRecargoPorc = New Eniac.Controles.TextBox()
      Me.lblDescuentoRecargoPorc = New Eniac.Controles.Label()
      Me.txtOrden = New Eniac.Controles.TextBox()
      Me.lblOrden = New Eniac.Controles.Label()
      Me.chbActiva = New Eniac.Controles.CheckBox()
      Me.txtNombreCortoListaPrecios = New Eniac.Controles.TextBox()
      Me.lblNombreCortoListaPrecios = New Eniac.Controles.Label()
      Me.lblFormaDePago = New Eniac.Controles.Label()
      Me.cmbFormaDePago = New Eniac.Controles.ComboBox()
      Me.chbFormaDePago = New Eniac.Controles.CheckBox()
      Me.chbPublicarenWeb = New Eniac.Controles.CheckBox()
      Me.chbPermiteUtilidadEnCero = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(224, 257)
        Me.btnAceptar.TabIndex = 22
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(310, 257)
        Me.btnCancelar.TabIndex = 23
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(123, 257)
        Me.btnCopiar.TabIndex = 21
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(53, 257)
        Me.btnAplicar.TabIndex = 20
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(12, 46)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreListaPrecios"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(109, 43)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(275, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblIdLista
        '
        Me.lblIdLista.AutoSize = True
        Me.lblIdLista.LabelAsoc = Nothing
        Me.lblIdLista.Location = New System.Drawing.Point(12, 20)
        Me.lblIdLista.Name = "lblIdLista"
        Me.lblIdLista.Size = New System.Drawing.Size(44, 13)
        Me.lblIdLista.TabIndex = 0
        Me.lblIdLista.Text = "Número"
        '
        'txtNumero
        '
        Me.txtNumero.BindearPropiedadControl = "Text"
        Me.txtNumero.BindearPropiedadEntidad = "IdListaPrecios"
        Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumero.Formato = ""
        Me.txtNumero.IsDecimal = False
        Me.txtNumero.IsNumber = True
        Me.txtNumero.IsPK = True
        Me.txtNumero.IsRequired = True
        Me.txtNumero.Key = ""
        Me.txtNumero.LabelAsoc = Me.lblIdLista
        Me.txtNumero.Location = New System.Drawing.Point(109, 17)
        Me.txtNumero.MaxLength = 9
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(77, 20)
        Me.txtNumero.TabIndex = 1
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpVigencia
        '
        Me.dtpVigencia.BindearPropiedadControl = "Value"
        Me.dtpVigencia.BindearPropiedadEntidad = "FechaVigencia"
        Me.dtpVigencia.CustomFormat = "dd/MM/yyyy"
        Me.dtpVigencia.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpVigencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVigencia.IsPK = False
        Me.dtpVigencia.IsRequired = True
        Me.dtpVigencia.Key = ""
        Me.dtpVigencia.LabelAsoc = Me.lblVigencia
        Me.dtpVigencia.Location = New System.Drawing.Point(109, 95)
        Me.dtpVigencia.Name = "dtpVigencia"
        Me.dtpVigencia.Size = New System.Drawing.Size(85, 20)
        Me.dtpVigencia.TabIndex = 7
        '
        'lblVigencia
        '
        Me.lblVigencia.AutoSize = True
        Me.lblVigencia.LabelAsoc = Nothing
        Me.lblVigencia.Location = New System.Drawing.Point(12, 99)
        Me.lblVigencia.Name = "lblVigencia"
        Me.lblVigencia.Size = New System.Drawing.Size(48, 13)
        Me.lblVigencia.TabIndex = 6
        Me.lblVigencia.Text = "Vigencia"
        '
        'cmbListaPrecios
        '
        Me.cmbListaPrecios.BindearPropiedadControl = Nothing
        Me.cmbListaPrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecios.FormattingEnabled = True
        Me.cmbListaPrecios.IsPK = False
        Me.cmbListaPrecios.IsRequired = False
        Me.cmbListaPrecios.Key = Nothing
        Me.cmbListaPrecios.LabelAsoc = Me.lblListaPrecios
        Me.cmbListaPrecios.Location = New System.Drawing.Point(109, 121)
        Me.cmbListaPrecios.Name = "cmbListaPrecios"
        Me.cmbListaPrecios.Size = New System.Drawing.Size(180, 21)
        Me.cmbListaPrecios.TabIndex = 9
        '
        'lblListaPrecios
        '
        Me.lblListaPrecios.AutoSize = True
        Me.lblListaPrecios.LabelAsoc = Nothing
        Me.lblListaPrecios.Location = New System.Drawing.Point(12, 124)
        Me.lblListaPrecios.Name = "lblListaPrecios"
        Me.lblListaPrecios.Size = New System.Drawing.Size(90, 13)
        Me.lblListaPrecios.TabIndex = 8
        Me.lblListaPrecios.Text = "Copiar Precios de"
        '
        'txtDescuentoRecargoPorc
        '
        Me.txtDescuentoRecargoPorc.BindearPropiedadControl = "Text"
        Me.txtDescuentoRecargoPorc.BindearPropiedadEntidad = "DescuentoRecargoPorc"
        Me.txtDescuentoRecargoPorc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc.IsDecimal = True
        Me.txtDescuentoRecargoPorc.IsNumber = True
        Me.txtDescuentoRecargoPorc.IsPK = False
        Me.txtDescuentoRecargoPorc.IsRequired = False
        Me.txtDescuentoRecargoPorc.Key = ""
        Me.txtDescuentoRecargoPorc.LabelAsoc = Me.lblDescuentoRecargoPorc
        Me.txtDescuentoRecargoPorc.Location = New System.Drawing.Point(109, 148)
        Me.txtDescuentoRecargoPorc.MaxLength = 6
        Me.txtDescuentoRecargoPorc.Name = "txtDescuentoRecargoPorc"
        Me.txtDescuentoRecargoPorc.Size = New System.Drawing.Size(56, 20)
        Me.txtDescuentoRecargoPorc.TabIndex = 11
        Me.txtDescuentoRecargoPorc.Text = "0.00"
        Me.txtDescuentoRecargoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoRecargoPorc
        '
        Me.lblDescuentoRecargoPorc.AutoSize = True
        Me.lblDescuentoRecargoPorc.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc.Location = New System.Drawing.Point(12, 152)
        Me.lblDescuentoRecargoPorc.Name = "lblDescuentoRecargoPorc"
        Me.lblDescuentoRecargoPorc.Size = New System.Drawing.Size(87, 13)
        Me.lblDescuentoRecargoPorc.TabIndex = 10
        Me.lblDescuentoRecargoPorc.Text = "Desc. / Recargo"
        '
        'txtOrden
        '
        Me.txtOrden.BindearPropiedadControl = "Text"
        Me.txtOrden.BindearPropiedadEntidad = "Orden"
        Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrden.Formato = "##0.00"
        Me.txtOrden.IsDecimal = True
        Me.txtOrden.IsNumber = True
        Me.txtOrden.IsPK = False
        Me.txtOrden.IsRequired = False
        Me.txtOrden.Key = ""
        Me.txtOrden.LabelAsoc = Me.lblOrden
        Me.txtOrden.Location = New System.Drawing.Point(233, 149)
        Me.txtOrden.MaxLength = 6
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(56, 20)
        Me.txtOrden.TabIndex = 13
        Me.txtOrden.Text = "0"
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.LabelAsoc = Nothing
        Me.lblOrden.Location = New System.Drawing.Point(191, 152)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblOrden.TabIndex = 12
        Me.lblOrden.Text = "Orden"
        '
        'chbActiva
        '
        Me.chbActiva.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbActiva.AutoSize = True
        Me.chbActiva.BindearPropiedadControl = "Checked"
        Me.chbActiva.BindearPropiedadEntidad = "Activa"
        Me.chbActiva.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActiva.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActiva.IsPK = False
        Me.chbActiva.IsRequired = False
        Me.chbActiva.Key = Nothing
        Me.chbActiva.LabelAsoc = Nothing
        Me.chbActiva.Location = New System.Drawing.Point(334, 20)
        Me.chbActiva.Name = "chbActiva"
        Me.chbActiva.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbActiva.Size = New System.Drawing.Size(56, 17)
        Me.chbActiva.TabIndex = 19
        Me.chbActiva.Text = "Activa"
        Me.chbActiva.UseVisualStyleBackColor = True
        '
        'txtNombreCortoListaPrecios
        '
        Me.txtNombreCortoListaPrecios.BindearPropiedadControl = "Text"
        Me.txtNombreCortoListaPrecios.BindearPropiedadEntidad = "NombreCortoListaPrecios"
        Me.txtNombreCortoListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreCortoListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreCortoListaPrecios.Formato = ""
        Me.txtNombreCortoListaPrecios.IsDecimal = False
        Me.txtNombreCortoListaPrecios.IsNumber = False
        Me.txtNombreCortoListaPrecios.IsPK = False
        Me.txtNombreCortoListaPrecios.IsRequired = False
        Me.txtNombreCortoListaPrecios.Key = ""
        Me.txtNombreCortoListaPrecios.LabelAsoc = Me.lblNombreCortoListaPrecios
        Me.txtNombreCortoListaPrecios.Location = New System.Drawing.Point(109, 69)
        Me.txtNombreCortoListaPrecios.MaxLength = 10
        Me.txtNombreCortoListaPrecios.Name = "txtNombreCortoListaPrecios"
        Me.txtNombreCortoListaPrecios.Size = New System.Drawing.Size(118, 20)
        Me.txtNombreCortoListaPrecios.TabIndex = 5
        '
        'lblNombreCortoListaPrecios
        '
        Me.lblNombreCortoListaPrecios.AutoSize = True
        Me.lblNombreCortoListaPrecios.LabelAsoc = Nothing
        Me.lblNombreCortoListaPrecios.Location = New System.Drawing.Point(12, 72)
        Me.lblNombreCortoListaPrecios.Name = "lblNombreCortoListaPrecios"
        Me.lblNombreCortoListaPrecios.Size = New System.Drawing.Size(72, 13)
        Me.lblNombreCortoListaPrecios.TabIndex = 4
        Me.lblNombreCortoListaPrecios.Text = "Nombre Corto"
        '
        'lblFormaDePago
        '
        Me.lblFormaDePago.AutoSize = True
        Me.lblFormaDePago.LabelAsoc = Nothing
        Me.lblFormaDePago.Location = New System.Drawing.Point(28, 178)
        Me.lblFormaDePago.Name = "lblFormaDePago"
        Me.lblFormaDePago.Size = New System.Drawing.Size(79, 13)
        Me.lblFormaDePago.TabIndex = 15
        Me.lblFormaDePago.Text = "Forma de Pago"
        '
        'cmbFormaDePago
        '
        Me.cmbFormaDePago.BindearPropiedadControl = ""
        Me.cmbFormaDePago.BindearPropiedadEntidad = ""
        Me.cmbFormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaDePago.Enabled = False
        Me.cmbFormaDePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaDePago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaDePago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaDePago.FormattingEnabled = True
        Me.cmbFormaDePago.IsPK = False
        Me.cmbFormaDePago.IsRequired = False
        Me.cmbFormaDePago.Key = Nothing
        Me.cmbFormaDePago.LabelAsoc = Me.lblFormaDePago
        Me.cmbFormaDePago.Location = New System.Drawing.Point(109, 175)
        Me.cmbFormaDePago.Name = "cmbFormaDePago"
        Me.cmbFormaDePago.Size = New System.Drawing.Size(180, 21)
        Me.cmbFormaDePago.TabIndex = 16
        '
        'chbFormaDePago
        '
        Me.chbFormaDePago.AutoSize = True
        Me.chbFormaDePago.BindearPropiedadControl = ""
        Me.chbFormaDePago.BindearPropiedadEntidad = ""
        Me.chbFormaDePago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFormaDePago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFormaDePago.IsPK = False
        Me.chbFormaDePago.IsRequired = False
        Me.chbFormaDePago.Key = Nothing
        Me.chbFormaDePago.LabelAsoc = Nothing
        Me.chbFormaDePago.Location = New System.Drawing.Point(15, 178)
        Me.chbFormaDePago.Name = "chbFormaDePago"
        Me.chbFormaDePago.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbFormaDePago.Size = New System.Drawing.Size(15, 14)
        Me.chbFormaDePago.TabIndex = 14
        Me.chbFormaDePago.UseVisualStyleBackColor = True
        '
        'chbPublicarenWeb
        '
        Me.chbPublicarenWeb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbPublicarenWeb.AutoSize = True
        Me.chbPublicarenWeb.BindearPropiedadControl = "Checked"
        Me.chbPublicarenWeb.BindearPropiedadEntidad = "PublicarenWeb"
        Me.chbPublicarenWeb.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPublicarenWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPublicarenWeb.IsPK = False
        Me.chbPublicarenWeb.IsRequired = False
        Me.chbPublicarenWeb.Key = Nothing
        Me.chbPublicarenWeb.LabelAsoc = Nothing
        Me.chbPublicarenWeb.Location = New System.Drawing.Point(109, 202)
        Me.chbPublicarenWeb.Name = "chbPublicarenWeb"
        Me.chbPublicarenWeb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbPublicarenWeb.Size = New System.Drawing.Size(105, 17)
        Me.chbPublicarenWeb.TabIndex = 17
        Me.chbPublicarenWeb.Text = "Publicar en Web"
        Me.chbPublicarenWeb.UseVisualStyleBackColor = True
        '
        'chbPermiteUtilidadEnCero
        '
        Me.chbPermiteUtilidadEnCero.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbPermiteUtilidadEnCero.AutoSize = True
        Me.chbPermiteUtilidadEnCero.BindearPropiedadControl = "Checked"
        Me.chbPermiteUtilidadEnCero.BindearPropiedadEntidad = "PermiteUtilidadEnCero"
        Me.chbPermiteUtilidadEnCero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteUtilidadEnCero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteUtilidadEnCero.IsPK = False
        Me.chbPermiteUtilidadEnCero.IsRequired = False
        Me.chbPermiteUtilidadEnCero.Key = Nothing
        Me.chbPermiteUtilidadEnCero.LabelAsoc = Nothing
        Me.chbPermiteUtilidadEnCero.Location = New System.Drawing.Point(15, 225)
        Me.chbPermiteUtilidadEnCero.Name = "chbPermiteUtilidadEnCero"
        Me.chbPermiteUtilidadEnCero.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbPermiteUtilidadEnCero.Size = New System.Drawing.Size(264, 17)
        Me.chbPermiteUtilidadEnCero.TabIndex = 18
        Me.chbPermiteUtilidadEnCero.Text = "Permite precios con utilidad en cero (Venta=Costo)"
        Me.chbPermiteUtilidadEnCero.UseVisualStyleBackColor = True
        '
        'ListaDePreciosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(399, 292)
        Me.Controls.Add(Me.chbPermiteUtilidadEnCero)
        Me.Controls.Add(Me.chbPublicarenWeb)
        Me.Controls.Add(Me.chbFormaDePago)
        Me.Controls.Add(Me.chbActiva)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.txtDescuentoRecargoPorc)
        Me.Controls.Add(Me.lblDescuentoRecargoPorc)
        Me.Controls.Add(Me.cmbFormaDePago)
        Me.Controls.Add(Me.lblFormaDePago)
        Me.Controls.Add(Me.cmbListaPrecios)
        Me.Controls.Add(Me.lblListaPrecios)
        Me.Controls.Add(Me.dtpVigencia)
        Me.Controls.Add(Me.lblVigencia)
        Me.Controls.Add(Me.lblNombreCortoListaPrecios)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombreCortoListaPrecios)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblIdLista)
        Me.Controls.Add(Me.txtNumero)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ListaDePreciosDetalle"
        Me.Text = "Lista de Precios"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtNumero, 0)
        Me.Controls.SetChildIndex(Me.lblIdLista, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.txtNombreCortoListaPrecios, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.lblNombreCortoListaPrecios, 0)
        Me.Controls.SetChildIndex(Me.lblVigencia, 0)
        Me.Controls.SetChildIndex(Me.dtpVigencia, 0)
        Me.Controls.SetChildIndex(Me.lblListaPrecios, 0)
        Me.Controls.SetChildIndex(Me.cmbListaPrecios, 0)
        Me.Controls.SetChildIndex(Me.lblFormaDePago, 0)
        Me.Controls.SetChildIndex(Me.cmbFormaDePago, 0)
        Me.Controls.SetChildIndex(Me.lblDescuentoRecargoPorc, 0)
        Me.Controls.SetChildIndex(Me.txtDescuentoRecargoPorc, 0)
        Me.Controls.SetChildIndex(Me.lblOrden, 0)
        Me.Controls.SetChildIndex(Me.txtOrden, 0)
        Me.Controls.SetChildIndex(Me.chbActiva, 0)
        Me.Controls.SetChildIndex(Me.chbFormaDePago, 0)
        Me.Controls.SetChildIndex(Me.chbPublicarenWeb, 0)
        Me.Controls.SetChildIndex(Me.chbPermiteUtilidadEnCero, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblIdLista As Eniac.Controles.Label
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents dtpVigencia As Eniac.Controles.DateTimePicker
   Friend WithEvents lblVigencia As Eniac.Controles.Label
   Friend WithEvents cmbListaPrecios As Eniac.Controles.ComboBox
   Friend WithEvents lblListaPrecios As Eniac.Controles.Label
   Friend WithEvents txtDescuentoRecargoPorc As Eniac.Controles.TextBox
   Friend WithEvents lblDescuentoRecargoPorc As Eniac.Controles.Label
   Friend WithEvents txtOrden As Eniac.Controles.TextBox
   Friend WithEvents lblOrden As Eniac.Controles.Label
   Friend WithEvents chbActiva As Eniac.Controles.CheckBox
   Friend WithEvents txtNombreCortoListaPrecios As Eniac.Controles.TextBox
   Friend WithEvents lblNombreCortoListaPrecios As Eniac.Controles.Label
   Friend WithEvents lblFormaDePago As Eniac.Controles.Label
   Friend WithEvents cmbFormaDePago As Eniac.Controles.ComboBox
   Friend WithEvents chbFormaDePago As Eniac.Controles.CheckBox
   Friend WithEvents chbPublicarenWeb As Eniac.Controles.CheckBox
   Friend WithEvents chbPermiteUtilidadEnCero As Eniac.Controles.CheckBox

End Class
