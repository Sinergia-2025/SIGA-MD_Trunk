<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRPAQLADetalle
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
      Me.txtTamanoLoteDesde = New Eniac.Controles.TextBox()
      Me.lblTamanoLoteDesde = New Eniac.Controles.Label()
      Me.lblNivelGeneral1 = New Eniac.Controles.Label()
      Me.txtNivelGeneral1 = New Eniac.Controles.TextBox()
      Me.txtTamanoLoteHasta = New Eniac.Controles.TextBox()
      Me.lblTamanoLoteHasta = New Eniac.Controles.Label()
      Me.grpNivelGeneral = New System.Windows.Forms.GroupBox()
      Me.txtNivelGeneral3 = New Eniac.Controles.TextBox()
      Me.lblNivelGeneral3 = New Eniac.Controles.Label()
        Me.lblNivelGeneral2 = New Eniac.Controles.Label()
        Me.txtNivelGeneral2 = New Eniac.Controles.TextBox()
        Me.grpNivelEspecial = New System.Windows.Forms.GroupBox()
        Me.txtNivelEspecialS3 = New Eniac.Controles.TextBox()
        Me.lblNivelEspecialS3 = New Eniac.Controles.Label()
        Me.txtNivelEspecialS4 = New Eniac.Controles.TextBox()
        Me.lblNivelEspecialS4 = New Eniac.Controles.Label()
        Me.txtNivelEspecialS2 = New Eniac.Controles.TextBox()
        Me.lblNivelEspecialS2 = New Eniac.Controles.Label()
        Me.lblNivelEspecialS1 = New Eniac.Controles.Label()
        Me.txtNivelEspecialS1 = New Eniac.Controles.TextBox()
        Me.grpNivelGeneral.SuspendLayout()
        Me.grpNivelEspecial.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(158, 104)
        Me.btnAceptar.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(244, 104)
        Me.btnCancelar.TabIndex = 7
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(57, 104)
        Me.btnCopiar.TabIndex = 9
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(0, 104)
        Me.btnAplicar.TabIndex = 8
        '
        'txtTamanoLoteDesde
        '
        Me.txtTamanoLoteDesde.BindearPropiedadControl = "Text"
        Me.txtTamanoLoteDesde.BindearPropiedadEntidad = "TamanoLoteDesde"
        Me.txtTamanoLoteDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTamanoLoteDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTamanoLoteDesde.Formato = ""
        Me.txtTamanoLoteDesde.IsDecimal = False
        Me.txtTamanoLoteDesde.IsNumber = True
        Me.txtTamanoLoteDesde.IsPK = False
        Me.txtTamanoLoteDesde.IsRequired = True
        Me.txtTamanoLoteDesde.Key = ""
        Me.txtTamanoLoteDesde.LabelAsoc = Me.lblTamanoLoteDesde
        Me.txtTamanoLoteDesde.Location = New System.Drawing.Point(131, 12)
        Me.txtTamanoLoteDesde.MaxLength = 12
        Me.txtTamanoLoteDesde.Name = "txtTamanoLoteDesde"
        Me.txtTamanoLoteDesde.Size = New System.Drawing.Size(65, 20)
        Me.txtTamanoLoteDesde.TabIndex = 1
        Me.txtTamanoLoteDesde.Text = "0"
        Me.txtTamanoLoteDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTamanoLoteDesde
        '
        Me.lblTamanoLoteDesde.AutoSize = True
        Me.lblTamanoLoteDesde.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTamanoLoteDesde.LabelAsoc = Nothing
        Me.lblTamanoLoteDesde.Location = New System.Drawing.Point(21, 15)
        Me.lblTamanoLoteDesde.Name = "lblTamanoLoteDesde"
        Me.lblTamanoLoteDesde.Size = New System.Drawing.Size(104, 13)
        Me.lblTamanoLoteDesde.TabIndex = 0
        Me.lblTamanoLoteDesde.Text = "Tamaño Lote Desde"
        '
        'lblNivelGeneral1
        '
        Me.lblNivelGeneral1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNivelGeneral1.AutoSize = True
        Me.lblNivelGeneral1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelGeneral1.LabelAsoc = Nothing
        Me.lblNivelGeneral1.Location = New System.Drawing.Point(21, 17)
        Me.lblNivelGeneral1.Name = "lblNivelGeneral1"
        Me.lblNivelGeneral1.Size = New System.Drawing.Size(10, 13)
        Me.lblNivelGeneral1.TabIndex = 0
        Me.lblNivelGeneral1.Text = "I"
        '
        'txtNivelGeneral1
        '
        Me.txtNivelGeneral1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNivelGeneral1.BindearPropiedadControl = "Text"
        Me.txtNivelGeneral1.BindearPropiedadEntidad = "NivelGeneral1"
        Me.txtNivelGeneral1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNivelGeneral1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNivelGeneral1.Formato = ""
        Me.txtNivelGeneral1.IsDecimal = False
        Me.txtNivelGeneral1.IsNumber = False
        Me.txtNivelGeneral1.IsPK = False
        Me.txtNivelGeneral1.IsRequired = True
        Me.txtNivelGeneral1.Key = ""
        Me.txtNivelGeneral1.LabelAsoc = Me.lblNivelGeneral1
        Me.txtNivelGeneral1.Location = New System.Drawing.Point(11, 33)
        Me.txtNivelGeneral1.MaxLength = 1
        Me.txtNivelGeneral1.Name = "txtNivelGeneral1"
        Me.txtNivelGeneral1.Size = New System.Drawing.Size(30, 20)
        Me.txtNivelGeneral1.TabIndex = 1
        '
        'txtTamanoLoteHasta
        '
        Me.txtTamanoLoteHasta.BindearPropiedadControl = "Text"
        Me.txtTamanoLoteHasta.BindearPropiedadEntidad = "TamanoLoteHasta"
        Me.txtTamanoLoteHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTamanoLoteHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTamanoLoteHasta.Formato = ""
        Me.txtTamanoLoteHasta.IsDecimal = False
        Me.txtTamanoLoteHasta.IsNumber = True
        Me.txtTamanoLoteHasta.IsPK = False
        Me.txtTamanoLoteHasta.IsRequired = True
        Me.txtTamanoLoteHasta.Key = ""
        Me.txtTamanoLoteHasta.LabelAsoc = Me.lblTamanoLoteHasta
        Me.txtTamanoLoteHasta.Location = New System.Drawing.Point(243, 12)
        Me.txtTamanoLoteHasta.MaxLength = 12
        Me.txtTamanoLoteHasta.Name = "txtTamanoLoteHasta"
        Me.txtTamanoLoteHasta.Size = New System.Drawing.Size(65, 20)
        Me.txtTamanoLoteHasta.TabIndex = 3
        Me.txtTamanoLoteHasta.Text = "0"
        Me.txtTamanoLoteHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTamanoLoteHasta
        '
        Me.lblTamanoLoteHasta.AutoSize = True
        Me.lblTamanoLoteHasta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTamanoLoteHasta.LabelAsoc = Nothing
        Me.lblTamanoLoteHasta.Location = New System.Drawing.Point(202, 15)
        Me.lblTamanoLoteHasta.Name = "lblTamanoLoteHasta"
        Me.lblTamanoLoteHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblTamanoLoteHasta.TabIndex = 2
        Me.lblTamanoLoteHasta.Text = "Hasta"
        '
        'grpNivelGeneral
        '
        Me.grpNivelGeneral.Controls.Add(Me.txtNivelGeneral3)
        Me.grpNivelGeneral.Controls.Add(Me.lblNivelGeneral2)
        Me.grpNivelGeneral.Controls.Add(Me.lblNivelGeneral1)
        Me.grpNivelGeneral.Controls.Add(Me.txtNivelGeneral1)
        Me.grpNivelGeneral.Controls.Add(Me.lblNivelGeneral3)
        Me.grpNivelGeneral.Controls.Add(Me.txtNivelGeneral2)
        Me.grpNivelGeneral.Location = New System.Drawing.Point(20, 38)
        Me.grpNivelGeneral.Name = "grpNivelGeneral"
        Me.grpNivelGeneral.Size = New System.Drawing.Size(128, 60)
        Me.grpNivelGeneral.TabIndex = 4
        Me.grpNivelGeneral.TabStop = False
        Me.grpNivelGeneral.Text = "Nivel General"
        '
        'txtNivelGeneral3
        '
        Me.txtNivelGeneral3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNivelGeneral3.BindearPropiedadControl = "Text"
        Me.txtNivelGeneral3.BindearPropiedadEntidad = "NivelGeneral3"
        Me.txtNivelGeneral3.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNivelGeneral3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNivelGeneral3.Formato = ""
        Me.txtNivelGeneral3.IsDecimal = False
        Me.txtNivelGeneral3.IsNumber = False
        Me.txtNivelGeneral3.IsPK = False
        Me.txtNivelGeneral3.IsRequired = True
        Me.txtNivelGeneral3.Key = ""
        Me.txtNivelGeneral3.LabelAsoc = Me.lblNivelGeneral3
        Me.txtNivelGeneral3.Location = New System.Drawing.Point(83, 33)
        Me.txtNivelGeneral3.MaxLength = 1
        Me.txtNivelGeneral3.Name = "txtNivelGeneral3"
        Me.txtNivelGeneral3.Size = New System.Drawing.Size(30, 20)
        Me.txtNivelGeneral3.TabIndex = 5
        '
        'lblNivelGeneral3
        '
        Me.lblNivelGeneral3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNivelGeneral3.AutoSize = True
        Me.lblNivelGeneral3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelGeneral3.LabelAsoc = Nothing
        Me.lblNivelGeneral3.Location = New System.Drawing.Point(90, 17)
        Me.lblNivelGeneral3.Name = "lblNivelGeneral3"
        Me.lblNivelGeneral3.Size = New System.Drawing.Size(16, 13)
        Me.lblNivelGeneral3.TabIndex = 4
        Me.lblNivelGeneral3.Text = "III"
        '
        'lblNivelGeneral2
        '
        Me.lblNivelGeneral2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNivelGeneral2.AutoSize = True
        Me.lblNivelGeneral2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelGeneral2.LabelAsoc = Nothing
        Me.lblNivelGeneral2.Location = New System.Drawing.Point(55, 17)
        Me.lblNivelGeneral2.Name = "lblNivelGeneral2"
        Me.lblNivelGeneral2.Size = New System.Drawing.Size(13, 13)
        Me.lblNivelGeneral2.TabIndex = 2
        Me.lblNivelGeneral2.Text = "II"
        '
        'txtNivelGeneral2
        '
        Me.txtNivelGeneral2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNivelGeneral2.BindearPropiedadControl = "Text"
        Me.txtNivelGeneral2.BindearPropiedadEntidad = "NivelGeneral2"
        Me.txtNivelGeneral2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNivelGeneral2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNivelGeneral2.Formato = ""
        Me.txtNivelGeneral2.IsDecimal = False
        Me.txtNivelGeneral2.IsNumber = False
        Me.txtNivelGeneral2.IsPK = False
        Me.txtNivelGeneral2.IsRequired = True
        Me.txtNivelGeneral2.Key = ""
        Me.txtNivelGeneral2.LabelAsoc = Me.lblNivelGeneral2
        Me.txtNivelGeneral2.Location = New System.Drawing.Point(47, 33)
        Me.txtNivelGeneral2.MaxLength = 1
        Me.txtNivelGeneral2.Name = "txtNivelGeneral2"
        Me.txtNivelGeneral2.Size = New System.Drawing.Size(30, 20)
        Me.txtNivelGeneral2.TabIndex = 3
        '
        'grpNivelEspecial
        '
        Me.grpNivelEspecial.Controls.Add(Me.txtNivelEspecialS3)
        Me.grpNivelEspecial.Controls.Add(Me.txtNivelEspecialS4)
        Me.grpNivelEspecial.Controls.Add(Me.txtNivelEspecialS2)
        Me.grpNivelEspecial.Controls.Add(Me.lblNivelEspecialS4)
        Me.grpNivelEspecial.Controls.Add(Me.lblNivelEspecialS2)
        Me.grpNivelEspecial.Controls.Add(Me.lblNivelEspecialS3)
        Me.grpNivelEspecial.Controls.Add(Me.lblNivelEspecialS1)
        Me.grpNivelEspecial.Controls.Add(Me.txtNivelEspecialS1)
        Me.grpNivelEspecial.Location = New System.Drawing.Point(154, 38)
        Me.grpNivelEspecial.Name = "grpNivelEspecial"
        Me.grpNivelEspecial.Size = New System.Drawing.Size(160, 60)
        Me.grpNivelEspecial.TabIndex = 5
        Me.grpNivelEspecial.TabStop = False
        Me.grpNivelEspecial.Text = "Nivel Especial"
        '
        'txtNivelEspecialS3
        '
        Me.txtNivelEspecialS3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNivelEspecialS3.BindearPropiedadControl = "Text"
        Me.txtNivelEspecialS3.BindearPropiedadEntidad = "NivelEspecialS3"
        Me.txtNivelEspecialS3.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNivelEspecialS3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNivelEspecialS3.Formato = ""
        Me.txtNivelEspecialS3.IsDecimal = False
        Me.txtNivelEspecialS3.IsNumber = False
        Me.txtNivelEspecialS3.IsPK = False
        Me.txtNivelEspecialS3.IsRequired = True
        Me.txtNivelEspecialS3.Key = ""
        Me.txtNivelEspecialS3.LabelAsoc = Me.lblNivelEspecialS3
        Me.txtNivelEspecialS3.Location = New System.Drawing.Point(83, 33)
        Me.txtNivelEspecialS3.MaxLength = 1
        Me.txtNivelEspecialS3.Name = "txtNivelEspecialS3"
        Me.txtNivelEspecialS3.Size = New System.Drawing.Size(30, 20)
        Me.txtNivelEspecialS3.TabIndex = 5
        '
        'lblNivelEspecialS3
        '
        Me.lblNivelEspecialS3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNivelEspecialS3.AutoSize = True
        Me.lblNivelEspecialS3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelEspecialS3.LabelAsoc = Nothing
        Me.lblNivelEspecialS3.Location = New System.Drawing.Point(88, 17)
        Me.lblNivelEspecialS3.Name = "lblNivelEspecialS3"
        Me.lblNivelEspecialS3.Size = New System.Drawing.Size(20, 13)
        Me.lblNivelEspecialS3.TabIndex = 4
        Me.lblNivelEspecialS3.Text = "S3"
        '
        'txtNivelEspecialS4
        '
        Me.txtNivelEspecialS4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNivelEspecialS4.BindearPropiedadControl = "Text"
        Me.txtNivelEspecialS4.BindearPropiedadEntidad = "NivelEspecialS4"
        Me.txtNivelEspecialS4.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNivelEspecialS4.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNivelEspecialS4.Formato = ""
        Me.txtNivelEspecialS4.IsDecimal = False
        Me.txtNivelEspecialS4.IsNumber = False
        Me.txtNivelEspecialS4.IsPK = False
        Me.txtNivelEspecialS4.IsRequired = True
        Me.txtNivelEspecialS4.Key = ""
        Me.txtNivelEspecialS4.LabelAsoc = Me.lblNivelEspecialS4
        Me.txtNivelEspecialS4.Location = New System.Drawing.Point(119, 33)
        Me.txtNivelEspecialS4.MaxLength = 1
        Me.txtNivelEspecialS4.Name = "txtNivelEspecialS4"
        Me.txtNivelEspecialS4.Size = New System.Drawing.Size(30, 20)
        Me.txtNivelEspecialS4.TabIndex = 7
        '
        'lblNivelEspecialS4
        '
        Me.lblNivelEspecialS4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNivelEspecialS4.AutoSize = True
        Me.lblNivelEspecialS4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelEspecialS4.LabelAsoc = Nothing
        Me.lblNivelEspecialS4.Location = New System.Drawing.Point(124, 17)
        Me.lblNivelEspecialS4.Name = "lblNivelEspecialS4"
        Me.lblNivelEspecialS4.Size = New System.Drawing.Size(20, 13)
        Me.lblNivelEspecialS4.TabIndex = 6
        Me.lblNivelEspecialS4.Text = "S4"
        '
        'txtNivelEspecialS2
        '
        Me.txtNivelEspecialS2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNivelEspecialS2.BindearPropiedadControl = "Text"
        Me.txtNivelEspecialS2.BindearPropiedadEntidad = "NivelEspecialS2"
        Me.txtNivelEspecialS2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNivelEspecialS2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNivelEspecialS2.Formato = ""
        Me.txtNivelEspecialS2.IsDecimal = False
        Me.txtNivelEspecialS2.IsNumber = False
        Me.txtNivelEspecialS2.IsPK = False
        Me.txtNivelEspecialS2.IsRequired = True
        Me.txtNivelEspecialS2.Key = ""
        Me.txtNivelEspecialS2.LabelAsoc = Me.lblNivelEspecialS2
        Me.txtNivelEspecialS2.Location = New System.Drawing.Point(47, 33)
        Me.txtNivelEspecialS2.MaxLength = 1
        Me.txtNivelEspecialS2.Name = "txtNivelEspecialS2"
        Me.txtNivelEspecialS2.Size = New System.Drawing.Size(30, 20)
        Me.txtNivelEspecialS2.TabIndex = 3
        '
        'lblNivelEspecialS2
        '
        Me.lblNivelEspecialS2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNivelEspecialS2.AutoSize = True
        Me.lblNivelEspecialS2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelEspecialS2.LabelAsoc = Nothing
        Me.lblNivelEspecialS2.Location = New System.Drawing.Point(52, 17)
        Me.lblNivelEspecialS2.Name = "lblNivelEspecialS2"
        Me.lblNivelEspecialS2.Size = New System.Drawing.Size(20, 13)
        Me.lblNivelEspecialS2.TabIndex = 2
        Me.lblNivelEspecialS2.Text = "S2"
        '
        'lblNivelEspecialS1
        '
        Me.lblNivelEspecialS1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNivelEspecialS1.AutoSize = True
        Me.lblNivelEspecialS1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelEspecialS1.LabelAsoc = Nothing
        Me.lblNivelEspecialS1.Location = New System.Drawing.Point(16, 17)
        Me.lblNivelEspecialS1.Name = "lblNivelEspecialS1"
        Me.lblNivelEspecialS1.Size = New System.Drawing.Size(20, 13)
        Me.lblNivelEspecialS1.TabIndex = 0
        Me.lblNivelEspecialS1.Text = "S1"
        '
        'txtNivelEspecialS1
        '
        Me.txtNivelEspecialS1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNivelEspecialS1.BindearPropiedadControl = "Text"
        Me.txtNivelEspecialS1.BindearPropiedadEntidad = "NivelEspecialS1"
        Me.txtNivelEspecialS1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNivelEspecialS1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNivelEspecialS1.Formato = ""
        Me.txtNivelEspecialS1.IsDecimal = False
        Me.txtNivelEspecialS1.IsNumber = False
        Me.txtNivelEspecialS1.IsPK = False
        Me.txtNivelEspecialS1.IsRequired = True
        Me.txtNivelEspecialS1.Key = ""
        Me.txtNivelEspecialS1.LabelAsoc = Me.lblNivelEspecialS1
        Me.txtNivelEspecialS1.Location = New System.Drawing.Point(11, 33)
        Me.txtNivelEspecialS1.MaxLength = 1
        Me.txtNivelEspecialS1.Name = "txtNivelEspecialS1"
        Me.txtNivelEspecialS1.Size = New System.Drawing.Size(30, 20)
        Me.txtNivelEspecialS1.TabIndex = 1
        '
        'MRPAQLADetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 139)
        Me.Controls.Add(Me.grpNivelEspecial)
        Me.Controls.Add(Me.grpNivelGeneral)
        Me.Controls.Add(Me.txtTamanoLoteHasta)
        Me.Controls.Add(Me.lblTamanoLoteHasta)
        Me.Controls.Add(Me.txtTamanoLoteDesde)
        Me.Controls.Add(Me.lblTamanoLoteDesde)
        Me.Name = "MRPAQLADetalle"
        Me.Text = "MRP AQL A"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblTamanoLoteDesde, 0)
        Me.Controls.SetChildIndex(Me.txtTamanoLoteDesde, 0)
        Me.Controls.SetChildIndex(Me.lblTamanoLoteHasta, 0)
        Me.Controls.SetChildIndex(Me.txtTamanoLoteHasta, 0)
        Me.Controls.SetChildIndex(Me.grpNivelGeneral, 0)
        Me.Controls.SetChildIndex(Me.grpNivelEspecial, 0)
        Me.grpNivelGeneral.ResumeLayout(False)
        Me.grpNivelGeneral.PerformLayout()
        Me.grpNivelEspecial.ResumeLayout(False)
        Me.grpNivelEspecial.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTamanoLoteDesde As Controles.TextBox
   Friend WithEvents lblTamanoLoteDesde As Controles.Label
   Friend WithEvents lblNivelGeneral1 As Controles.Label
   Friend WithEvents txtNivelGeneral1 As Controles.TextBox
   Friend WithEvents txtTamanoLoteHasta As Controles.TextBox
   Friend WithEvents lblTamanoLoteHasta As Controles.Label
   Friend WithEvents grpNivelGeneral As GroupBox
   Friend WithEvents txtNivelGeneral2 As Controles.TextBox
   Friend WithEvents lblNivelGeneral2 As Controles.Label
   Friend WithEvents txtNivelGeneral3 As Controles.TextBox
   Friend WithEvents lblNivelGeneral3 As Controles.Label
   Friend WithEvents grpNivelEspecial As GroupBox
   Friend WithEvents txtNivelEspecialS3 As Controles.TextBox
   Friend WithEvents lblNivelEspecialS3 As Controles.Label
   Friend WithEvents txtNivelEspecialS2 As Controles.TextBox
   Friend WithEvents lblNivelEspecialS2 As Controles.Label
   Friend WithEvents txtNivelEspecialS1 As Controles.TextBox
   Friend WithEvents lblNivelEspecialS1 As Controles.Label
   Friend WithEvents lblNivelEspecialS4 As Controles.Label
   Friend WithEvents txtNivelEspecialS4 As Controles.TextBox
End Class
