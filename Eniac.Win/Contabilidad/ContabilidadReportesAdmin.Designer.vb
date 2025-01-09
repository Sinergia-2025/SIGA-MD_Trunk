<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadReportesAdmin
   Inherits Eniac.Win.BaseForm
   'Inherits System.Windows.Forms.Form

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
      Me.tbListados = New System.Windows.Forms.TabControl
      Me.tbBalance = New System.Windows.Forms.TabPage
      Me.dtpBalance = New Eniac.Controles.DateTimePicker
      Me.lblFechaBalance = New Eniac.Controles.Label
      Me.tbAsientos = New System.Windows.Forms.TabPage
      Me.bscConcepto = New Eniac.Controles.Buscador
      Me.lblConcepto = New Eniac.Controles.Label
      Me.dtFechaAsiento = New Eniac.Controles.DateTimePicker
      Me.lblFechaAsiento = New Eniac.Controles.Label
      Me.lblNumeroAsiento = New Eniac.Controles.Label
      Me.txtNumeroAsiento = New Eniac.Controles.TextBox
      Me.tbLibro = New System.Windows.Forms.TabPage
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.cmdPlan = New System.Windows.Forms.Button
      Me.lblDesc = New Eniac.Controles.Label
      Me.bscDescripcion = New Eniac.Controles.Buscador
      Me.bscCodCuenta = New Eniac.Controles.Buscador
      Me.lblCta = New Eniac.Controles.Label
      Me.dtpHasta = New Eniac.Controles.DateTimePicker
      Me.lblHasta = New Eniac.Controles.Label
      Me.dtpDesde = New Eniac.Controles.DateTimePicker
      Me.lbldesde = New Eniac.Controles.Label
      Me.tbPlan = New System.Windows.Forms.TabPage
      Me.btnVerPlan = New System.Windows.Forms.Button
      Me.clbSucursales = New Eniac.Controles.CheckedListBox
      Me.lblPlan = New Eniac.Controles.Label
      Me.cmbPlan = New Eniac.Controles.ComboBox
      Me.cmdReporte = New System.Windows.Forms.Button
      Me.Label3 = New Eniac.Controles.Label
      Me.tbListados.SuspendLayout()
      Me.tbBalance.SuspendLayout()
      Me.tbAsientos.SuspendLayout()
      Me.tbLibro.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.tbPlan.SuspendLayout()
      Me.SuspendLayout()
      '
      'tbListados
      '
      Me.tbListados.Controls.Add(Me.tbBalance)
      Me.tbListados.Controls.Add(Me.tbAsientos)
      Me.tbListados.Controls.Add(Me.tbLibro)
      Me.tbListados.Controls.Add(Me.tbPlan)
      Me.tbListados.Location = New System.Drawing.Point(12, 99)
      Me.tbListados.Name = "tbListados"
      Me.tbListados.SelectedIndex = 0
      Me.tbListados.Size = New System.Drawing.Size(507, 190)
      Me.tbListados.TabIndex = 0
      '
      'tbBalance
      '
      Me.tbBalance.Controls.Add(Me.dtpBalance)
      Me.tbBalance.Controls.Add(Me.lblFechaBalance)
      Me.tbBalance.Location = New System.Drawing.Point(4, 22)
      Me.tbBalance.Name = "tbBalance"
      Me.tbBalance.Padding = New System.Windows.Forms.Padding(3)
      Me.tbBalance.Size = New System.Drawing.Size(499, 164)
      Me.tbBalance.TabIndex = 0
      Me.tbBalance.Text = "Balance de Sumas y Saldos"
      Me.tbBalance.UseVisualStyleBackColor = True
      '
      'dtpBalance
      '
      Me.dtpBalance.BindearPropiedadControl = ""
      Me.dtpBalance.BindearPropiedadEntidad = ""
      Me.dtpBalance.CustomFormat = "dd/MM/yyyy"
      Me.dtpBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpBalance.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpBalance.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpBalance.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpBalance.IsPK = False
      Me.dtpBalance.IsRequired = False
      Me.dtpBalance.Key = ""
      Me.dtpBalance.LabelAsoc = Me.lblFechaBalance
      Me.dtpBalance.Location = New System.Drawing.Point(76, 21)
      Me.dtpBalance.Name = "dtpBalance"
      Me.dtpBalance.Size = New System.Drawing.Size(82, 20)
      Me.dtpBalance.TabIndex = 25
      '
      'lblFechaBalance
      '
      Me.lblFechaBalance.AutoSize = True
      Me.lblFechaBalance.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFechaBalance.Location = New System.Drawing.Point(17, 25)
      Me.lblFechaBalance.Name = "lblFechaBalance"
      Me.lblFechaBalance.Size = New System.Drawing.Size(55, 13)
      Me.lblFechaBalance.TabIndex = 26
      Me.lblFechaBalance.Text = "A la fecha"
      '
      'tbAsientos
      '
      Me.tbAsientos.Controls.Add(Me.bscConcepto)
      Me.tbAsientos.Controls.Add(Me.dtFechaAsiento)
      Me.tbAsientos.Controls.Add(Me.lblConcepto)
      Me.tbAsientos.Controls.Add(Me.lblFechaAsiento)
      Me.tbAsientos.Controls.Add(Me.lblNumeroAsiento)
      Me.tbAsientos.Controls.Add(Me.txtNumeroAsiento)
      Me.tbAsientos.Location = New System.Drawing.Point(4, 22)
      Me.tbAsientos.Name = "tbAsientos"
      Me.tbAsientos.Padding = New System.Windows.Forms.Padding(3)
      Me.tbAsientos.Size = New System.Drawing.Size(499, 164)
      Me.tbAsientos.TabIndex = 1
      Me.tbAsientos.Text = "Asientos"
      Me.tbAsientos.UseVisualStyleBackColor = True
      '
      'bscConcepto
      '
      Me.bscConcepto.AyudaAncho = 608
      Me.bscConcepto.BindearPropiedadControl = Nothing
      Me.bscConcepto.BindearPropiedadEntidad = Nothing
      Me.bscConcepto.ColumnasAlineacion = Nothing
      Me.bscConcepto.ColumnasAncho = Nothing
      Me.bscConcepto.ColumnasFormato = Nothing
      Me.bscConcepto.ColumnasOcultas = Nothing
      Me.bscConcepto.ColumnasTitulos = Nothing
      Me.bscConcepto.Datos = Nothing
      Me.bscConcepto.FilaDevuelta = Nothing
      Me.bscConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscConcepto.IsDecimal = False
      Me.bscConcepto.IsNumber = False
      Me.bscConcepto.IsPK = False
      Me.bscConcepto.IsRequired = False
      Me.bscConcepto.Key = ""
      Me.bscConcepto.LabelAsoc = Me.lblConcepto
      Me.bscConcepto.Location = New System.Drawing.Point(69, 48)
      Me.bscConcepto.MaxLengh = "32767"
      Me.bscConcepto.Name = "bscConcepto"
      Me.bscConcepto.Permitido = True
      Me.bscConcepto.Selecciono = False
      Me.bscConcepto.Size = New System.Drawing.Size(288, 20)
      Me.bscConcepto.TabIndex = 33
      Me.bscConcepto.Titulo = Nothing
      '
      'lblConcepto
      '
      Me.lblConcepto.AutoSize = True
      Me.lblConcepto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblConcepto.Location = New System.Drawing.Point(13, 52)
      Me.lblConcepto.Name = "lblConcepto"
      Me.lblConcepto.Size = New System.Drawing.Size(53, 13)
      Me.lblConcepto.TabIndex = 32
      Me.lblConcepto.Text = "Concepto"
      '
      'dtFechaAsiento
      '
      Me.dtFechaAsiento.BindearPropiedadControl = "value"
      Me.dtFechaAsiento.BindearPropiedadEntidad = "fechaAsiento"
      Me.dtFechaAsiento.Checked = False
      Me.dtFechaAsiento.CustomFormat = "dd/MM/yyyy"
      Me.dtFechaAsiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtFechaAsiento.ForeColorFocus = System.Drawing.Color.Red
      Me.dtFechaAsiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtFechaAsiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtFechaAsiento.IsPK = False
      Me.dtFechaAsiento.IsRequired = False
      Me.dtFechaAsiento.Key = ""
      Me.dtFechaAsiento.LabelAsoc = Me.lblFechaAsiento
      Me.dtFechaAsiento.Location = New System.Drawing.Point(245, 17)
      Me.dtFechaAsiento.Name = "dtFechaAsiento"
      Me.dtFechaAsiento.ShowCheckBox = True
      Me.dtFechaAsiento.Size = New System.Drawing.Size(112, 20)
      Me.dtFechaAsiento.TabIndex = 29
      '
      'lblFechaAsiento
      '
      Me.lblFechaAsiento.AutoSize = True
      Me.lblFechaAsiento.Location = New System.Drawing.Point(202, 21)
      Me.lblFechaAsiento.Name = "lblFechaAsiento"
      Me.lblFechaAsiento.Size = New System.Drawing.Size(37, 13)
      Me.lblFechaAsiento.TabIndex = 31
      Me.lblFechaAsiento.Text = "Fecha"
      '
      'lblNumeroAsiento
      '
      Me.lblNumeroAsiento.AutoSize = True
      Me.lblNumeroAsiento.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblNumeroAsiento.Location = New System.Drawing.Point(13, 21)
      Me.lblNumeroAsiento.Name = "lblNumeroAsiento"
      Me.lblNumeroAsiento.Size = New System.Drawing.Size(44, 13)
      Me.lblNumeroAsiento.TabIndex = 30
      Me.lblNumeroAsiento.Text = "Número"
      '
      'txtNumeroAsiento
      '
      Me.txtNumeroAsiento.BindearPropiedadControl = ""
      Me.txtNumeroAsiento.BindearPropiedadEntidad = ""
      Me.txtNumeroAsiento.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroAsiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroAsiento.Formato = ""
      Me.txtNumeroAsiento.IsDecimal = False
      Me.txtNumeroAsiento.IsNumber = True
      Me.txtNumeroAsiento.IsPK = False
      Me.txtNumeroAsiento.IsRequired = False
      Me.txtNumeroAsiento.Key = ""
      Me.txtNumeroAsiento.LabelAsoc = Me.lblNumeroAsiento
      Me.txtNumeroAsiento.Location = New System.Drawing.Point(69, 17)
      Me.txtNumeroAsiento.MaxLength = 8
      Me.txtNumeroAsiento.Name = "txtNumeroAsiento"
      Me.txtNumeroAsiento.Size = New System.Drawing.Size(79, 20)
      Me.txtNumeroAsiento.TabIndex = 28
      Me.txtNumeroAsiento.Text = "0"
      Me.txtNumeroAsiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tbLibro
      '
      Me.tbLibro.Controls.Add(Me.GroupBox1)
      Me.tbLibro.Controls.Add(Me.dtpHasta)
      Me.tbLibro.Controls.Add(Me.dtpDesde)
      Me.tbLibro.Controls.Add(Me.lbldesde)
      Me.tbLibro.Controls.Add(Me.lblHasta)
      Me.tbLibro.Location = New System.Drawing.Point(4, 22)
      Me.tbLibro.Name = "tbLibro"
      Me.tbLibro.Padding = New System.Windows.Forms.Padding(3)
      Me.tbLibro.Size = New System.Drawing.Size(499, 164)
      Me.tbLibro.TabIndex = 2
      Me.tbLibro.Text = "Libro Mayor"
      Me.tbLibro.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.cmdPlan)
      Me.GroupBox1.Controls.Add(Me.lblDesc)
      Me.GroupBox1.Controls.Add(Me.bscDescripcion)
      Me.GroupBox1.Controls.Add(Me.bscCodCuenta)
      Me.GroupBox1.Controls.Add(Me.lblCta)
      Me.GroupBox1.Location = New System.Drawing.Point(9, 57)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(372, 98)
      Me.GroupBox1.TabIndex = 57
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Cuenta"
      '
      'cmdPlan
      '
      Me.cmdPlan.Location = New System.Drawing.Point(10, 16)
      Me.cmdPlan.Name = "cmdPlan"
      Me.cmdPlan.Size = New System.Drawing.Size(103, 23)
      Me.cmdPlan.TabIndex = 2
      Me.cmdPlan.Text = "Ver Plan..."
      Me.cmdPlan.UseVisualStyleBackColor = True
      '
      'lblDesc
      '
      Me.lblDesc.AutoSize = True
      Me.lblDesc.Location = New System.Drawing.Point(107, 47)
      Me.lblDesc.Name = "lblDesc"
      Me.lblDesc.Size = New System.Drawing.Size(63, 13)
      Me.lblDesc.TabIndex = 38
      Me.lblDesc.Text = "Descripción"
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
      Me.bscDescripcion.Location = New System.Drawing.Point(110, 63)
      Me.bscDescripcion.MaxLengh = "32767"
      Me.bscDescripcion.Name = "bscDescripcion"
      Me.bscDescripcion.Permitido = True
      Me.bscDescripcion.Selecciono = False
      Me.bscDescripcion.Size = New System.Drawing.Size(242, 20)
      Me.bscDescripcion.TabIndex = 1
      Me.bscDescripcion.Titulo = Nothing
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
      Me.bscCodCuenta.Location = New System.Drawing.Point(10, 63)
      Me.bscCodCuenta.MaxLengh = "32767"
      Me.bscCodCuenta.Name = "bscCodCuenta"
      Me.bscCodCuenta.Permitido = True
      Me.bscCodCuenta.Selecciono = False
      Me.bscCodCuenta.Size = New System.Drawing.Size(95, 20)
      Me.bscCodCuenta.TabIndex = 0
      Me.bscCodCuenta.Titulo = Nothing
      '
      'lblCta
      '
      Me.lblCta.AutoSize = True
      Me.lblCta.Location = New System.Drawing.Point(7, 42)
      Me.lblCta.Name = "lblCta"
      Me.lblCta.Size = New System.Drawing.Size(40, 13)
      Me.lblCta.TabIndex = 33
      Me.lblCta.Text = "Código"
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = ""
      Me.dtpHasta.BindearPropiedadEntidad = ""
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(290, 18)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(89, 20)
      Me.dtpHasta.TabIndex = 56
      Me.dtpHasta.Value = New Date(2012, 7, 2, 23, 27, 0, 0)
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.Location = New System.Drawing.Point(218, 22)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(68, 13)
      Me.lblHasta.TabIndex = 53
      Me.lblHasta.Text = "Fecha Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = ""
      Me.dtpDesde.BindearPropiedadEntidad = ""
      Me.dtpDesde.Checked = False
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lbldesde
      Me.dtpDesde.Location = New System.Drawing.Point(82, 18)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.ShowCheckBox = True
      Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
      Me.dtpDesde.TabIndex = 55
      Me.dtpDesde.Value = New Date(2011, 10, 6, 0, 0, 0, 0)
      '
      'lbldesde
      '
      Me.lbldesde.AutoSize = True
      Me.lbldesde.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lbldesde.Location = New System.Drawing.Point(7, 22)
      Me.lbldesde.Name = "lbldesde"
      Me.lbldesde.Size = New System.Drawing.Size(71, 13)
      Me.lbldesde.TabIndex = 54
      Me.lbldesde.Text = "Fecha Desde"
      '
      'tbPlan
      '
      Me.tbPlan.Controls.Add(Me.btnVerPlan)
      Me.tbPlan.Location = New System.Drawing.Point(4, 22)
      Me.tbPlan.Name = "tbPlan"
      Me.tbPlan.Padding = New System.Windows.Forms.Padding(3)
      Me.tbPlan.Size = New System.Drawing.Size(499, 164)
      Me.tbPlan.TabIndex = 3
      Me.tbPlan.Text = "Plan de Cuentas"
      Me.tbPlan.UseVisualStyleBackColor = True
      '
      'btnVerPlan
      '
      Me.btnVerPlan.Location = New System.Drawing.Point(6, 26)
      Me.btnVerPlan.Name = "btnVerPlan"
      Me.btnVerPlan.Size = New System.Drawing.Size(103, 23)
      Me.btnVerPlan.TabIndex = 3
      Me.btnVerPlan.Text = "Ver Plan..."
      Me.btnVerPlan.UseVisualStyleBackColor = True
      '
      'clbSucursales
      '
      Me.clbSucursales.CheckOnClick = True
      Me.clbSucursales.FormattingEnabled = True
      Me.clbSucursales.Location = New System.Drawing.Point(385, 12)
      Me.clbSucursales.Name = "clbSucursales"
      Me.clbSucursales.Size = New System.Drawing.Size(134, 64)
      Me.clbSucursales.TabIndex = 51
      '
      'lblPlan
      '
      Me.lblPlan.AutoSize = True
      Me.lblPlan.Location = New System.Drawing.Point(18, 18)
      Me.lblPlan.Name = "lblPlan"
      Me.lblPlan.Size = New System.Drawing.Size(80, 13)
      Me.lblPlan.TabIndex = 50
      Me.lblPlan.Text = "Plan de Cuenta"
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
      Me.cmbPlan.IsPK = False
      Me.cmbPlan.IsRequired = True
      Me.cmbPlan.Key = Nothing
      Me.cmbPlan.LabelAsoc = Me.lblPlan
      Me.cmbPlan.Location = New System.Drawing.Point(110, 12)
      Me.cmbPlan.Name = "cmbPlan"
      Me.cmbPlan.Size = New System.Drawing.Size(196, 21)
      Me.cmbPlan.TabIndex = 49
      '
      'cmdReporte
      '
      Me.cmdReporte.Location = New System.Drawing.Point(394, 305)
      Me.cmdReporte.Name = "cmdReporte"
      Me.cmdReporte.Size = New System.Drawing.Size(125, 23)
      Me.cmdReporte.TabIndex = 1
      Me.cmdReporte.Text = "Ver Reporte"
      Me.cmdReporte.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(320, 18)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(59, 13)
      Me.Label3.TabIndex = 52
      Me.Label3.Text = "Sucursales"
      '
      'ContabilidadReportesAdmin
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(531, 340)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.clbSucursales)
      Me.Controls.Add(Me.cmdReporte)
      Me.Controls.Add(Me.lblPlan)
      Me.Controls.Add(Me.tbListados)
      Me.Controls.Add(Me.cmbPlan)
      Me.Name = "ContabilidadReportesAdmin"
      Me.Text = "Reportes Admin"
      Me.tbListados.ResumeLayout(False)
      Me.tbBalance.ResumeLayout(False)
      Me.tbBalance.PerformLayout()
      Me.tbAsientos.ResumeLayout(False)
      Me.tbAsientos.PerformLayout()
      Me.tbLibro.ResumeLayout(False)
      Me.tbLibro.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.tbPlan.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tbListados As System.Windows.Forms.TabControl
   Friend WithEvents tbBalance As System.Windows.Forms.TabPage
   Friend WithEvents tbAsientos As System.Windows.Forms.TabPage
   Friend WithEvents tbLibro As System.Windows.Forms.TabPage
   Friend WithEvents tbPlan As System.Windows.Forms.TabPage
   Friend WithEvents dtpBalance As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaBalance As Eniac.Controles.Label
   Friend WithEvents dtFechaAsiento As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaAsiento As Eniac.Controles.Label
   Friend WithEvents lblConcepto As Eniac.Controles.Label
   Friend WithEvents lblNumeroAsiento As Eniac.Controles.Label
   Friend WithEvents txtNumeroAsiento As Eniac.Controles.TextBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lbldesde As Eniac.Controles.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents cmdPlan As System.Windows.Forms.Button
   Friend WithEvents lblDesc As Eniac.Controles.Label
   Friend WithEvents bscDescripcion As Eniac.Controles.Buscador
   Friend WithEvents bscCodCuenta As Eniac.Controles.Buscador
   Friend WithEvents lblCta As Eniac.Controles.Label
   Friend WithEvents btnVerPlan As System.Windows.Forms.Button
   Friend WithEvents bscConcepto As Eniac.Controles.Buscador
   Friend WithEvents cmdReporte As System.Windows.Forms.Button
   Friend WithEvents lblPlan As Eniac.Controles.Label
   Friend WithEvents cmbPlan As Eniac.Controles.ComboBox
   Friend WithEvents clbSucursales As Eniac.Controles.CheckedListBox
   Friend WithEvents Label3 As Eniac.Controles.Label
End Class
