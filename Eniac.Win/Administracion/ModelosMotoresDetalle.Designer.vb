<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModelosMotoresDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModelosMotoresDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtModeloMotor = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtIdModeloMotor = New Eniac.Controles.TextBox()
      Me.cmbMarcasMotor = New Eniac.Controles.ComboBox()
      Me.lblMarcaEmbarcacion = New Eniac.Controles.Label()
      Me.lnkMarcaMotor = New Eniac.Controles.LinkLabel()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(195, 117)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(291, 117)
      Me.btnCancelar.TabIndex = 7
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(28, 45)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 3
      Me.lblNombre.Text = "Nombre"
      '
      'txtModeloMotor
      '
      Me.txtModeloMotor.BindearPropiedadControl = "Text"
      Me.txtModeloMotor.BindearPropiedadEntidad = "NombreModeloMotor"
      Me.txtModeloMotor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtModeloMotor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtModeloMotor.Formato = ""
      Me.txtModeloMotor.IsDecimal = False
      Me.txtModeloMotor.IsNumber = False
      Me.txtModeloMotor.IsPK = False
      Me.txtModeloMotor.IsRequired = True
      Me.txtModeloMotor.Key = ""
      Me.txtModeloMotor.LabelAsoc = Me.lblNombre
      Me.txtModeloMotor.Location = New System.Drawing.Point(106, 41)
      Me.txtModeloMotor.MaxLength = 30
      Me.txtModeloMotor.Name = "txtModeloMotor"
      Me.txtModeloMotor.Size = New System.Drawing.Size(275, 20)
      Me.txtModeloMotor.TabIndex = 2
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.LabelAsoc = Nothing
      Me.lblId.Location = New System.Drawing.Point(28, 17)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 1
      Me.lblId.Text = "Código"
      '
      'txtIdModeloMotor
      '
      Me.txtIdModeloMotor.BindearPropiedadControl = "Text"
      Me.txtIdModeloMotor.BindearPropiedadEntidad = "IdModeloMotor"
      Me.txtIdModeloMotor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdModeloMotor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdModeloMotor.Formato = ""
      Me.txtIdModeloMotor.IsDecimal = False
      Me.txtIdModeloMotor.IsNumber = True
      Me.txtIdModeloMotor.IsPK = True
      Me.txtIdModeloMotor.IsRequired = True
      Me.txtIdModeloMotor.Key = ""
      Me.txtIdModeloMotor.LabelAsoc = Me.lblId
      Me.txtIdModeloMotor.Location = New System.Drawing.Point(106, 13)
      Me.txtIdModeloMotor.MaxLength = 4
      Me.txtIdModeloMotor.Name = "txtIdModeloMotor"
      Me.txtIdModeloMotor.Size = New System.Drawing.Size(55, 20)
      Me.txtIdModeloMotor.TabIndex = 0
      Me.txtIdModeloMotor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbMarcasMotor
      '
      Me.cmbMarcasMotor.BindearPropiedadControl = "SelectedValue"
      Me.cmbMarcasMotor.BindearPropiedadEntidad = "IdMarcaMotor"
      Me.cmbMarcasMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMarcasMotor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMarcasMotor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMarcasMotor.FormattingEnabled = True
      Me.cmbMarcasMotor.IsPK = False
      Me.cmbMarcasMotor.IsRequired = True
      Me.cmbMarcasMotor.Key = Nothing
      Me.cmbMarcasMotor.LabelAsoc = Me.lblMarcaEmbarcacion
      Me.cmbMarcasMotor.Location = New System.Drawing.Point(106, 70)
      Me.cmbMarcasMotor.Name = "cmbMarcasMotor"
      Me.cmbMarcasMotor.Size = New System.Drawing.Size(180, 21)
      Me.cmbMarcasMotor.TabIndex = 4
      '
      'lblMarcaEmbarcacion
      '
      Me.lblMarcaEmbarcacion.AutoSize = True
      Me.lblMarcaEmbarcacion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMarcaEmbarcacion.LabelAsoc = Nothing
      Me.lblMarcaEmbarcacion.Location = New System.Drawing.Point(292, 74)
      Me.lblMarcaEmbarcacion.Name = "lblMarcaEmbarcacion"
      Me.lblMarcaEmbarcacion.Size = New System.Drawing.Size(37, 13)
      Me.lblMarcaEmbarcacion.TabIndex = 8
      Me.lblMarcaEmbarcacion.Text = "Marca"
      Me.lblMarcaEmbarcacion.Visible = False
      '
      'lnkMarcaMotor
      '
      Me.lnkMarcaMotor.AutoSize = True
      Me.lnkMarcaMotor.Location = New System.Drawing.Point(28, 74)
      Me.lnkMarcaMotor.Name = "lnkMarcaMotor"
      Me.lnkMarcaMotor.Size = New System.Drawing.Size(37, 13)
      Me.lnkMarcaMotor.TabIndex = 5
      Me.lnkMarcaMotor.TabStop = True
      Me.lnkMarcaMotor.Text = "Marca"
      '
      'ModelosMotoresDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(390, 164)
      Me.Controls.Add(Me.lnkMarcaMotor)
      Me.Controls.Add(Me.cmbMarcasMotor)
      Me.Controls.Add(Me.lblMarcaEmbarcacion)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtModeloMotor)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtIdModeloMotor)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ModelosMotoresDetalle"
      Me.Text = "Modelo de Motor"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdModeloMotor, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtModeloMotor, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.lblMarcaEmbarcacion, 0)
      Me.Controls.SetChildIndex(Me.cmbMarcasMotor, 0)
      Me.Controls.SetChildIndex(Me.lnkMarcaMotor, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtModeloMotor As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtIdModeloMotor As Eniac.Controles.TextBox
   Friend WithEvents cmbMarcasMotor As Eniac.Controles.ComboBox
   Friend WithEvents lblMarcaEmbarcacion As Eniac.Controles.Label
   Friend WithEvents lnkMarcaMotor As Eniac.Controles.LinkLabel

End Class
