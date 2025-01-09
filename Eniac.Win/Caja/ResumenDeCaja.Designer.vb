<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResumenDeCaja
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResumenDeCaja))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.chbAgrupado = New Eniac.Controles.CheckBox()
        Me.rdbFechaMovimiento = New Eniac.Controles.RadioButton()
        Me.rdbFechaPlanilla = New Eniac.Controles.RadioButton()
        Me.lblFechaDe = New Eniac.Controles.Label()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.btnImprimir = New Eniac.Controles.Button()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.cmbCajas = New Eniac.Win.ComboBoxCajas()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(524, 29)
        Me.tstBarra.TabIndex = 1
        Me.tstBarra.Text = "toolStrip1"
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
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.lblCaja)
        Me.grbFiltros.Controls.Add(Me.cmbCajas)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.chbAgrupado)
        Me.grbFiltros.Controls.Add(Me.rdbFechaMovimiento)
        Me.grbFiltros.Controls.Add(Me.rdbFechaPlanilla)
        Me.grbFiltros.Controls.Add(Me.lblFechaDe)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.btnImprimir)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 35)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(442, 178)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.ItemHeight = 13
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(95, 27)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(33, 30)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'chbAgrupado
        '
        Me.chbAgrupado.AutoSize = True
        Me.chbAgrupado.BindearPropiedadControl = Nothing
        Me.chbAgrupado.BindearPropiedadEntidad = Nothing
        Me.chbAgrupado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAgrupado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAgrupado.IsPK = False
        Me.chbAgrupado.IsRequired = False
        Me.chbAgrupado.Key = Nothing
        Me.chbAgrupado.LabelAsoc = Nothing
        Me.chbAgrupado.Location = New System.Drawing.Point(243, 132)
        Me.chbAgrupado.Name = "chbAgrupado"
        Me.chbAgrupado.Size = New System.Drawing.Size(72, 17)
        Me.chbAgrupado.TabIndex = 12
        Me.chbAgrupado.Text = "Agrupado"
        Me.chbAgrupado.UseVisualStyleBackColor = True
        '
        'rdbFechaMovimiento
        '
        Me.rdbFechaMovimiento.AutoSize = True
        Me.rdbFechaMovimiento.BindearPropiedadControl = Nothing
        Me.rdbFechaMovimiento.BindearPropiedadEntidad = Nothing
        Me.rdbFechaMovimiento.Checked = True
        Me.rdbFechaMovimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbFechaMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbFechaMovimiento.IsPK = False
        Me.rdbFechaMovimiento.IsRequired = False
        Me.rdbFechaMovimiento.Key = Nothing
        Me.rdbFechaMovimiento.LabelAsoc = Nothing
        Me.rdbFechaMovimiento.Location = New System.Drawing.Point(95, 92)
        Me.rdbFechaMovimiento.Name = "rdbFechaMovimiento"
        Me.rdbFechaMovimiento.Size = New System.Drawing.Size(79, 17)
        Me.rdbFechaMovimiento.TabIndex = 10
        Me.rdbFechaMovimiento.TabStop = True
        Me.rdbFechaMovimiento.Text = "Movimiento"
        Me.rdbFechaMovimiento.UseVisualStyleBackColor = True
        '
        'rdbFechaPlanilla
        '
        Me.rdbFechaPlanilla.AutoSize = True
        Me.rdbFechaPlanilla.BindearPropiedadControl = Nothing
        Me.rdbFechaPlanilla.BindearPropiedadEntidad = Nothing
        Me.rdbFechaPlanilla.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbFechaPlanilla.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbFechaPlanilla.IsPK = False
        Me.rdbFechaPlanilla.IsRequired = False
        Me.rdbFechaPlanilla.Key = Nothing
        Me.rdbFechaPlanilla.LabelAsoc = Nothing
        Me.rdbFechaPlanilla.Location = New System.Drawing.Point(179, 92)
        Me.rdbFechaPlanilla.Name = "rdbFechaPlanilla"
        Me.rdbFechaPlanilla.Size = New System.Drawing.Size(58, 17)
        Me.rdbFechaPlanilla.TabIndex = 11
        Me.rdbFechaPlanilla.Text = "Planilla"
        Me.rdbFechaPlanilla.UseVisualStyleBackColor = True
        '
        'lblFechaDe
        '
        Me.lblFechaDe.AutoSize = True
        Me.lblFechaDe.LabelAsoc = Nothing
        Me.lblFechaDe.Location = New System.Drawing.Point(33, 94)
        Me.lblFechaDe.Name = "lblFechaDe"
        Me.lblFechaDe.Size = New System.Drawing.Size(52, 13)
        Me.lblFechaDe.TabIndex = 9
        Me.lblFechaDe.Text = "Fecha de"
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(33, 66)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 4
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(320, 64)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpHasta.TabIndex = 8
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(279, 68)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 7
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(178, 64)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpDesde.TabIndex = 6
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(134, 68)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 5
        Me.lblDesde.Text = "Desde"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(321, 119)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(90, 43)
        Me.btnImprimir.TabIndex = 13
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(240, 31)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(33, 13)
        Me.lblCaja.TabIndex = 2
        Me.lblCaja.Text = "Cajas"
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = Nothing
        Me.cmbCajas.BindearPropiedadEntidad = Nothing
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Me.lblCaja
        Me.cmbCajas.Location = New System.Drawing.Point(279, 27)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(141, 21)
        Me.cmbCajas.SucursalesSeleccionadas = Nothing
        Me.cmbCajas.TabIndex = 3
        '
        'ResumenDeCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 287)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ResumenDeCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resumen de Caja"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnImprimir As Eniac.Controles.Button
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents rdbFechaMovimiento As Eniac.Controles.RadioButton
   Friend WithEvents rdbFechaPlanilla As Eniac.Controles.RadioButton
   Friend WithEvents lblFechaDe As Eniac.Controles.Label
    Friend WithEvents chbAgrupado As Eniac.Controles.CheckBox
    Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents lblSucursal As Eniac.Controles.Label
    Friend WithEvents lblCaja As Controles.Label
    Friend WithEvents cmbCajas As ComboBoxCajas
End Class
