<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LibrodeIvaVentas
    Inherits BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LibrodeIvaVentas))
      Me.chkConVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedores = New Eniac.Controles.ComboBox()
      Me.grbImpresionFinal = New System.Windows.Forms.GroupBox()
      Me.lblNumeroInicialHoja = New Eniac.Controles.Label()
      Me.txtNumeroInicialHoja = New Eniac.Controles.TextBox()
      Me.chkVersionFinal = New Eniac.Controles.CheckBox()
      Me.optPorProvincia = New System.Windows.Forms.RadioButton()
      Me.lblOrden = New System.Windows.Forms.Label()
      Me.optPorFecha = New System.Windows.Forms.RadioButton()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.dtpPeriodoFiscal = New Eniac.Controles.DateTimePicker()
      Me.lblPeriodoFiscal = New Eniac.Controles.Label()
      Me.chbFormatoHorizontal = New Eniac.Controles.CheckBox()
      Me.optPorProvinciaImpuesto = New System.Windows.Forms.RadioButton()
      Me.grbImpresionFinal.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'chkConVendedor
      '
      resources.ApplyResources(Me.chkConVendedor, "chkConVendedor")
      Me.chkConVendedor.BindearPropiedadControl = Nothing
      Me.chkConVendedor.BindearPropiedadEntidad = Nothing
      Me.chkConVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chkConVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkConVendedor.IsPK = False
      Me.chkConVendedor.IsRequired = False
      Me.chkConVendedor.Key = Nothing
      Me.chkConVendedor.LabelAsoc = Nothing
      Me.chkConVendedor.Name = "chkConVendedor"
      Me.chkConVendedor.UseVisualStyleBackColor = True
      '
      'cmbVendedores
      '
      Me.cmbVendedores.BindearPropiedadControl = Nothing
      Me.cmbVendedores.BindearPropiedadEntidad = Nothing
      Me.cmbVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      resources.ApplyResources(Me.cmbVendedores, "cmbVendedores")
      Me.cmbVendedores.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVendedores.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVendedores.FormattingEnabled = True
      Me.cmbVendedores.IsPK = False
      Me.cmbVendedores.IsRequired = False
      Me.cmbVendedores.Key = Nothing
      Me.cmbVendedores.LabelAsoc = Nothing
      Me.cmbVendedores.Name = "cmbVendedores"
      '
      'grbImpresionFinal
      '
      Me.grbImpresionFinal.Controls.Add(Me.lblNumeroInicialHoja)
      Me.grbImpresionFinal.Controls.Add(Me.txtNumeroInicialHoja)
      Me.grbImpresionFinal.Controls.Add(Me.chkVersionFinal)
      resources.ApplyResources(Me.grbImpresionFinal, "grbImpresionFinal")
      Me.grbImpresionFinal.Name = "grbImpresionFinal"
      Me.grbImpresionFinal.TabStop = False
      '
      'lblNumeroInicialHoja
      '
      resources.ApplyResources(Me.lblNumeroInicialHoja, "lblNumeroInicialHoja")
      Me.lblNumeroInicialHoja.Name = "lblNumeroInicialHoja"
      '
      'txtNumeroInicialHoja
      '
      Me.txtNumeroInicialHoja.BindearPropiedadControl = Nothing
      Me.txtNumeroInicialHoja.BindearPropiedadEntidad = Nothing
      resources.ApplyResources(Me.txtNumeroInicialHoja, "txtNumeroInicialHoja")
      Me.txtNumeroInicialHoja.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroInicialHoja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroInicialHoja.Formato = ""
      Me.txtNumeroInicialHoja.IsDecimal = False
      Me.txtNumeroInicialHoja.IsNumber = True
      Me.txtNumeroInicialHoja.IsPK = False
      Me.txtNumeroInicialHoja.IsRequired = False
      Me.txtNumeroInicialHoja.Key = ""
      Me.txtNumeroInicialHoja.LabelAsoc = Me.lblNumeroInicialHoja
      Me.txtNumeroInicialHoja.Name = "txtNumeroInicialHoja"
      '
      'chkVersionFinal
      '
      resources.ApplyResources(Me.chkVersionFinal, "chkVersionFinal")
      Me.chkVersionFinal.BindearPropiedadControl = Nothing
      Me.chkVersionFinal.BindearPropiedadEntidad = Nothing
      Me.chkVersionFinal.ForeColorFocus = System.Drawing.Color.Red
      Me.chkVersionFinal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkVersionFinal.IsPK = False
      Me.chkVersionFinal.IsRequired = False
      Me.chkVersionFinal.Key = Nothing
      Me.chkVersionFinal.LabelAsoc = Nothing
      Me.chkVersionFinal.Name = "chkVersionFinal"
      Me.chkVersionFinal.UseVisualStyleBackColor = True
      '
      'optPorProvincia
      '
      resources.ApplyResources(Me.optPorProvincia, "optPorProvincia")
      Me.optPorProvincia.Name = "optPorProvincia"
      Me.optPorProvincia.TabStop = True
      Me.optPorProvincia.UseVisualStyleBackColor = True
      '
      'lblOrden
      '
      resources.ApplyResources(Me.lblOrden, "lblOrden")
      Me.lblOrden.Name = "lblOrden"
      '
      'optPorFecha
      '
      resources.ApplyResources(Me.optPorFecha, "optPorFecha")
      Me.optPorFecha.Checked = True
      Me.optPorFecha.Name = "optPorFecha"
      Me.optPorFecha.TabStop = True
      Me.optPorFecha.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsbSalir})
      resources.ApplyResources(Me.tstBarra, "tstBarra")
      Me.tstBarra.Name = "tstBarra"
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      resources.ApplyResources(Me.tsbImprimir, "tsbImprimir")
      Me.tsbImprimir.Name = "tsbImprimir"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      resources.ApplyResources(Me.tsbSalir, "tsbSalir")
      Me.tsbSalir.Name = "tsbSalir"
      '
      'dtpPeriodoFiscal
      '
      Me.dtpPeriodoFiscal.BindearPropiedadControl = Nothing
      Me.dtpPeriodoFiscal.BindearPropiedadEntidad = Nothing
      resources.ApplyResources(Me.dtpPeriodoFiscal, "dtpPeriodoFiscal")
      Me.dtpPeriodoFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPeriodoFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPeriodoFiscal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodoFiscal.IsPK = False
      Me.dtpPeriodoFiscal.IsRequired = False
      Me.dtpPeriodoFiscal.Key = ""
      Me.dtpPeriodoFiscal.LabelAsoc = Me.lblPeriodoFiscal
      Me.dtpPeriodoFiscal.Name = "dtpPeriodoFiscal"
      '
      'lblPeriodoFiscal
      '
      resources.ApplyResources(Me.lblPeriodoFiscal, "lblPeriodoFiscal")
      Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
      '
      'chbFormatoHorizontal
      '
      resources.ApplyResources(Me.chbFormatoHorizontal, "chbFormatoHorizontal")
      Me.chbFormatoHorizontal.BindearPropiedadControl = Nothing
      Me.chbFormatoHorizontal.BindearPropiedadEntidad = Nothing
      Me.chbFormatoHorizontal.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFormatoHorizontal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFormatoHorizontal.IsPK = False
      Me.chbFormatoHorizontal.IsRequired = False
      Me.chbFormatoHorizontal.Key = Nothing
      Me.chbFormatoHorizontal.LabelAsoc = Nothing
      Me.chbFormatoHorizontal.Name = "chbFormatoHorizontal"
      Me.chbFormatoHorizontal.UseVisualStyleBackColor = True
      '
      'optPorProvinciaImpuesto
      '
      resources.ApplyResources(Me.optPorProvinciaImpuesto, "optPorProvinciaImpuesto")
      Me.optPorProvinciaImpuesto.Name = "optPorProvinciaImpuesto"
      Me.optPorProvinciaImpuesto.TabStop = True
      Me.optPorProvinciaImpuesto.UseVisualStyleBackColor = True
      '
      'LibrodeIvaVentas
      '
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.chbFormatoHorizontal)
      Me.Controls.Add(Me.dtpPeriodoFiscal)
      Me.Controls.Add(Me.lblPeriodoFiscal)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.optPorProvinciaImpuesto)
      Me.Controls.Add(Me.optPorProvincia)
      Me.Controls.Add(Me.lblOrden)
      Me.Controls.Add(Me.optPorFecha)
      Me.Controls.Add(Me.grbImpresionFinal)
      Me.Controls.Add(Me.chkConVendedor)
      Me.Controls.Add(Me.cmbVendedores)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.Name = "LibrodeIvaVentas"
      Me.grbImpresionFinal.ResumeLayout(False)
      Me.grbImpresionFinal.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents chkConVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedores As Eniac.Controles.ComboBox
   Friend WithEvents grbImpresionFinal As System.Windows.Forms.GroupBox
   Friend WithEvents lblNumeroInicialHoja As Eniac.Controles.Label
   Friend WithEvents txtNumeroInicialHoja As Eniac.Controles.TextBox
   Friend WithEvents chkVersionFinal As Eniac.Controles.CheckBox
   Friend WithEvents optPorProvincia As System.Windows.Forms.RadioButton
   Friend WithEvents lblOrden As System.Windows.Forms.Label
   Friend WithEvents optPorFecha As System.Windows.Forms.RadioButton
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpPeriodoFiscal As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
   Friend WithEvents chbFormatoHorizontal As Eniac.Controles.CheckBox
   Friend WithEvents optPorProvinciaImpuesto As System.Windows.Forms.RadioButton
End Class
