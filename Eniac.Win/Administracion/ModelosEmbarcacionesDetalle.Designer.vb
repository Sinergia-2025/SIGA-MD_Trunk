<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModelosEmbarcacionesDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModelosEmbarcacionesDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtModeloEmbarcacion = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtIdModeloEmbarcacion = New Eniac.Controles.TextBox()
      Me.cmbMarcasEmbarcaciones = New Eniac.Controles.ComboBox()
      Me.lblMarcaEmbarcacion = New Eniac.Controles.Label()
      Me.lnkMarcaEmbarcacion = New Eniac.Controles.LinkLabel()
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
      Me.lblNombre.Location = New System.Drawing.Point(28, 45)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 3
      Me.lblNombre.Text = "Nombre"
      '
      'txtModeloEmbarcacion
      '
      Me.txtModeloEmbarcacion.BindearPropiedadControl = "Text"
      Me.txtModeloEmbarcacion.BindearPropiedadEntidad = "NombreModeloEmbarcacion"
      Me.txtModeloEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtModeloEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtModeloEmbarcacion.Formato = ""
      Me.txtModeloEmbarcacion.IsDecimal = False
      Me.txtModeloEmbarcacion.IsNumber = False
      Me.txtModeloEmbarcacion.IsPK = False
      Me.txtModeloEmbarcacion.IsRequired = True
      Me.txtModeloEmbarcacion.Key = ""
      Me.txtModeloEmbarcacion.LabelAsoc = Me.lblNombre
      Me.txtModeloEmbarcacion.Location = New System.Drawing.Point(106, 41)
      Me.txtModeloEmbarcacion.MaxLength = 30
      Me.txtModeloEmbarcacion.Name = "txtModeloEmbarcacion"
      Me.txtModeloEmbarcacion.Size = New System.Drawing.Size(275, 20)
      Me.txtModeloEmbarcacion.TabIndex = 2
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.Location = New System.Drawing.Point(28, 17)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 1
      Me.lblId.Text = "Código"
      '
      'txtIdModeloEmbarcacion
      '
      Me.txtIdModeloEmbarcacion.BindearPropiedadControl = "Text"
      Me.txtIdModeloEmbarcacion.BindearPropiedadEntidad = "IdModeloEmbarcacion"
      Me.txtIdModeloEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdModeloEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdModeloEmbarcacion.Formato = ""
      Me.txtIdModeloEmbarcacion.IsDecimal = False
      Me.txtIdModeloEmbarcacion.IsNumber = True
      Me.txtIdModeloEmbarcacion.IsPK = True
      Me.txtIdModeloEmbarcacion.IsRequired = True
      Me.txtIdModeloEmbarcacion.Key = ""
      Me.txtIdModeloEmbarcacion.LabelAsoc = Me.lblId
      Me.txtIdModeloEmbarcacion.Location = New System.Drawing.Point(106, 13)
      Me.txtIdModeloEmbarcacion.MaxLength = 4
      Me.txtIdModeloEmbarcacion.Name = "txtIdModeloEmbarcacion"
      Me.txtIdModeloEmbarcacion.Size = New System.Drawing.Size(55, 20)
      Me.txtIdModeloEmbarcacion.TabIndex = 0
      Me.txtIdModeloEmbarcacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbMarcasEmbarcaciones
      '
      Me.cmbMarcasEmbarcaciones.BindearPropiedadControl = "SelectedValue"
      Me.cmbMarcasEmbarcaciones.BindearPropiedadEntidad = "MarcaEmbarcacion.IdMarcaEmbarcacion"
      Me.cmbMarcasEmbarcaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMarcasEmbarcaciones.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMarcasEmbarcaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMarcasEmbarcaciones.FormattingEnabled = True
      Me.cmbMarcasEmbarcaciones.IsPK = False
      Me.cmbMarcasEmbarcaciones.IsRequired = True
      Me.cmbMarcasEmbarcaciones.Key = Nothing
      Me.cmbMarcasEmbarcaciones.LabelAsoc = Me.lblMarcaEmbarcacion
      Me.cmbMarcasEmbarcaciones.Location = New System.Drawing.Point(106, 70)
      Me.cmbMarcasEmbarcaciones.Name = "cmbMarcasEmbarcaciones"
      Me.cmbMarcasEmbarcaciones.Size = New System.Drawing.Size(180, 21)
      Me.cmbMarcasEmbarcaciones.TabIndex = 4
      '
      'lblMarcaEmbarcacion
      '
      Me.lblMarcaEmbarcacion.AutoSize = True
      Me.lblMarcaEmbarcacion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMarcaEmbarcacion.Location = New System.Drawing.Point(292, 74)
      Me.lblMarcaEmbarcacion.Name = "lblMarcaEmbarcacion"
      Me.lblMarcaEmbarcacion.Size = New System.Drawing.Size(37, 13)
      Me.lblMarcaEmbarcacion.TabIndex = 8
      Me.lblMarcaEmbarcacion.Text = "Marca"
      Me.lblMarcaEmbarcacion.Visible = False
      '
      'lnkMarcaEmbarcacion
      '
      Me.lnkMarcaEmbarcacion.AutoSize = True
      Me.lnkMarcaEmbarcacion.Location = New System.Drawing.Point(28, 74)
      Me.lnkMarcaEmbarcacion.Name = "lnkMarcaEmbarcacion"
      Me.lnkMarcaEmbarcacion.Size = New System.Drawing.Size(37, 13)
      Me.lnkMarcaEmbarcacion.TabIndex = 5
      Me.lnkMarcaEmbarcacion.TabStop = True
      Me.lnkMarcaEmbarcacion.Text = "Marca"
      '
      'ModelosEmbarcacionesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(390, 164)
      Me.Controls.Add(Me.lnkMarcaEmbarcacion)
      Me.Controls.Add(Me.cmbMarcasEmbarcaciones)
      Me.Controls.Add(Me.lblMarcaEmbarcacion)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtModeloEmbarcacion)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtIdModeloEmbarcacion)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ModelosEmbarcacionesDetalle"
      Me.Text = "Modelo de Embarcacion"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdModeloEmbarcacion, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtModeloEmbarcacion, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.lblMarcaEmbarcacion, 0)
      Me.Controls.SetChildIndex(Me.cmbMarcasEmbarcaciones, 0)
      Me.Controls.SetChildIndex(Me.lnkMarcaEmbarcacion, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtModeloEmbarcacion As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtIdModeloEmbarcacion As Eniac.Controles.TextBox
   Friend WithEvents cmbMarcasEmbarcaciones As Eniac.Controles.ComboBox
   Friend WithEvents lblMarcaEmbarcacion As Eniac.Controles.Label
   Friend WithEvents lnkMarcaEmbarcacion As Eniac.Controles.LinkLabel

End Class
