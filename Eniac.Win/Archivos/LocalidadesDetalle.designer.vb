<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocalidadesDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LocalidadesDetalle))
      Me.txtIdLocalidad = New Eniac.Controles.TextBox()
      Me.lblIdLocalidad = New Eniac.Controles.Label()
      Me.lblNombreLocalidad = New Eniac.Controles.Label()
      Me.txtNombreLocalidad = New Eniac.Controles.TextBox()
      Me.cmbProvincia = New Eniac.Controles.ComboBox()
      Me.lblProvincia = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(200, 108)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(286, 108)
      Me.btnCancelar.TabIndex = 4
      '
      'txtIdLocalidad
      '
      Me.txtIdLocalidad.BindearPropiedadControl = "Text"
      Me.txtIdLocalidad.BindearPropiedadEntidad = "IdLocalidad"
      Me.txtIdLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdLocalidad.Formato = ""
      Me.txtIdLocalidad.IsDecimal = False
      Me.txtIdLocalidad.IsNumber = True
      Me.txtIdLocalidad.IsPK = True
      Me.txtIdLocalidad.IsRequired = True
      Me.txtIdLocalidad.Key = ""
      Me.txtIdLocalidad.LabelAsoc = Me.lblIdLocalidad
      Me.txtIdLocalidad.Location = New System.Drawing.Point(90, 16)
      Me.txtIdLocalidad.MaxLength = 5
      Me.txtIdLocalidad.Name = "txtIdLocalidad"
      Me.txtIdLocalidad.Size = New System.Drawing.Size(59, 20)
      Me.txtIdLocalidad.TabIndex = 0
      Me.txtIdLocalidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIdLocalidad
      '
      Me.lblIdLocalidad.AutoSize = True
      Me.lblIdLocalidad.Location = New System.Drawing.Point(12, 20)
      Me.lblIdLocalidad.Name = "lblIdLocalidad"
      Me.lblIdLocalidad.Size = New System.Drawing.Size(72, 13)
      Me.lblIdLocalidad.TabIndex = 5
      Me.lblIdLocalidad.Text = "Código Postal"
      '
      'lblNombreLocalidad
      '
      Me.lblNombreLocalidad.AutoSize = True
      Me.lblNombreLocalidad.Location = New System.Drawing.Point(12, 48)
      Me.lblNombreLocalidad.Name = "lblNombreLocalidad"
      Me.lblNombreLocalidad.Size = New System.Drawing.Size(53, 13)
      Me.lblNombreLocalidad.TabIndex = 6
      Me.lblNombreLocalidad.Text = "Localidad"
      '
      'txtNombreLocalidad
      '
      Me.txtNombreLocalidad.BindearPropiedadControl = "Text"
      Me.txtNombreLocalidad.BindearPropiedadEntidad = "NombreLocalidad"
      Me.txtNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreLocalidad.Formato = ""
      Me.txtNombreLocalidad.IsDecimal = False
      Me.txtNombreLocalidad.IsNumber = False
      Me.txtNombreLocalidad.IsPK = False
      Me.txtNombreLocalidad.IsRequired = True
      Me.txtNombreLocalidad.Key = ""
      Me.txtNombreLocalidad.LabelAsoc = Me.lblNombreLocalidad
      Me.txtNombreLocalidad.Location = New System.Drawing.Point(90, 44)
      Me.txtNombreLocalidad.MaxLength = 50
      Me.txtNombreLocalidad.Name = "txtNombreLocalidad"
      Me.txtNombreLocalidad.Size = New System.Drawing.Size(275, 20)
      Me.txtNombreLocalidad.TabIndex = 1
      '
      'cmbProvincia
      '
      Me.cmbProvincia.BindearPropiedadControl = "SelectedValue"
      Me.cmbProvincia.BindearPropiedadEntidad = "IdProvincia"
      Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbProvincia.FormattingEnabled = True
      Me.cmbProvincia.IsPK = False
      Me.cmbProvincia.IsRequired = True
      Me.cmbProvincia.Key = Nothing
      Me.cmbProvincia.LabelAsoc = Me.lblProvincia
      Me.cmbProvincia.Location = New System.Drawing.Point(90, 74)
      Me.cmbProvincia.Name = "cmbProvincia"
      Me.cmbProvincia.Size = New System.Drawing.Size(190, 21)
      Me.cmbProvincia.TabIndex = 2
      '
      'lblProvincia
      '
      Me.lblProvincia.AutoSize = True
      Me.lblProvincia.Location = New System.Drawing.Point(12, 78)
      Me.lblProvincia.Name = "lblProvincia"
      Me.lblProvincia.Size = New System.Drawing.Size(51, 13)
      Me.lblProvincia.TabIndex = 7
      Me.lblProvincia.Text = "Provincia"
      '
      'LocalidadesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(375, 143)
      Me.Controls.Add(Me.lblProvincia)
      Me.Controls.Add(Me.cmbProvincia)
      Me.Controls.Add(Me.lblNombreLocalidad)
      Me.Controls.Add(Me.txtNombreLocalidad)
      Me.Controls.Add(Me.lblIdLocalidad)
      Me.Controls.Add(Me.txtIdLocalidad)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "LocalidadesDetalle"
      Me.Text = "Localidad"
      Me.Controls.SetChildIndex(Me.txtIdLocalidad, 0)
      Me.Controls.SetChildIndex(Me.lblIdLocalidad, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreLocalidad, 0)
      Me.Controls.SetChildIndex(Me.lblNombreLocalidad, 0)
      Me.Controls.SetChildIndex(Me.cmbProvincia, 0)
      Me.Controls.SetChildIndex(Me.lblProvincia, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblIdLocalidad As Eniac.Controles.Label
    Friend WithEvents lblNombreLocalidad As Eniac.Controles.Label
   Friend WithEvents lblProvincia As Eniac.Controles.Label
   Public WithEvents txtIdLocalidad As Eniac.Controles.TextBox
   Public WithEvents txtNombreLocalidad As Eniac.Controles.TextBox
   Public WithEvents cmbProvincia As Eniac.Controles.ComboBox

End Class
