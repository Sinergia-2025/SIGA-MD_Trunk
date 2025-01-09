<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResumenAnualPorMoneda
   Inherits Eniac.Win.BaseForm

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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.btnImprimir1 = New System.Windows.Forms.Button()
      Me.cmbMonedas = New Eniac.Controles.ComboBox()
      Me.lblMoneda = New Eniac.Controles.Label()
      Me.txtAnio = New Eniac.Controles.TextBox()
      Me.lblAnio = New Eniac.Controles.Label()
      Me.tstBarra.SuspendLayout()
      Me.grbConsultar.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(289, 29)
      Me.tstBarra.TabIndex = 0
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
      'grbConsultar
      '
      Me.grbConsultar.Controls.Add(Me.btnImprimir1)
      Me.grbConsultar.Controls.Add(Me.cmbMonedas)
      Me.grbConsultar.Controls.Add(Me.lblMoneda)
      Me.grbConsultar.Controls.Add(Me.txtAnio)
      Me.grbConsultar.Controls.Add(Me.lblAnio)
      Me.grbConsultar.Location = New System.Drawing.Point(12, 34)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(259, 158)
      Me.grbConsultar.TabIndex = 1
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Consultar"
      '
      'btnImprimir1
      '
      Me.btnImprimir1.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
      Me.btnImprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnImprimir1.Location = New System.Drawing.Point(143, 97)
      Me.btnImprimir1.Name = "btnImprimir1"
      Me.btnImprimir1.Size = New System.Drawing.Size(100, 43)
      Me.btnImprimir1.TabIndex = 93
      Me.btnImprimir1.Text = "&Imprimir"
      Me.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnImprimir1.UseVisualStyleBackColor = True
      '
      'cmbMonedas
      '
      Me.cmbMonedas.BindearPropiedadControl = "SelectedValue"
      Me.cmbMonedas.BindearPropiedadEntidad = "Moneda.IdMoneda"
      Me.cmbMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMonedas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMonedas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMonedas.FormattingEnabled = True
      Me.cmbMonedas.IsPK = False
      Me.cmbMonedas.IsRequired = True
      Me.cmbMonedas.Key = Nothing
      Me.cmbMonedas.LabelAsoc = Me.lblMoneda
      Me.cmbMonedas.Location = New System.Drawing.Point(69, 30)
      Me.cmbMonedas.Name = "cmbMonedas"
      Me.cmbMonedas.Size = New System.Drawing.Size(130, 21)
      Me.cmbMonedas.TabIndex = 0
      '
      'lblMoneda
      '
      Me.lblMoneda.AutoSize = True
      Me.lblMoneda.Location = New System.Drawing.Point(16, 33)
      Me.lblMoneda.Name = "lblMoneda"
      Me.lblMoneda.Size = New System.Drawing.Size(46, 13)
      Me.lblMoneda.TabIndex = 92
      Me.lblMoneda.Text = "Moneda"
      '
      'txtAnio
      '
      Me.txtAnio.BindearPropiedadControl = Nothing
      Me.txtAnio.BindearPropiedadEntidad = Nothing
      Me.txtAnio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtAnio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtAnio.Formato = ""
      Me.txtAnio.IsDecimal = False
      Me.txtAnio.IsNumber = True
      Me.txtAnio.IsPK = False
      Me.txtAnio.IsRequired = True
      Me.txtAnio.Key = ""
      Me.txtAnio.LabelAsoc = Me.lblAnio
      Me.txtAnio.Location = New System.Drawing.Point(69, 60)
      Me.txtAnio.Name = "txtAnio"
      Me.txtAnio.Size = New System.Drawing.Size(61, 20)
      Me.txtAnio.TabIndex = 1
      '
      'lblAnio
      '
      Me.lblAnio.AutoSize = True
      Me.lblAnio.Location = New System.Drawing.Point(16, 63)
      Me.lblAnio.Name = "lblAnio"
      Me.lblAnio.Size = New System.Drawing.Size(26, 13)
      Me.lblAnio.TabIndex = 89
      Me.lblAnio.Text = "Año"
      '
      'ResumenAnualPorMoneda
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(289, 202)
      Me.Controls.Add(Me.grbConsultar)
      Me.Controls.Add(Me.tstBarra)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ResumenAnualPorMoneda"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Resumen Anual por Moneda"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents cmbMonedas As Eniac.Controles.ComboBox
   Friend WithEvents lblMoneda As Eniac.Controles.Label
   Friend WithEvents txtAnio As Eniac.Controles.TextBox
   Friend WithEvents lblAnio As Eniac.Controles.Label
   Friend WithEvents btnImprimir1 As System.Windows.Forms.Button
End Class
