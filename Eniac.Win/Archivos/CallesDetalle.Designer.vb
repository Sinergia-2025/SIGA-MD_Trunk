<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CallesDetalle
   Inherits Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CallesDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombreCategoria = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.cmbLocalidades = New Eniac.Controles.ComboBox()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(151, 100)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(247, 100)
      Me.btnCancelar.TabIndex = 4
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(6, 47)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 6
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombreCategoria
      '
      Me.txtNombreCategoria.BindearPropiedadControl = "Text"
      Me.txtNombreCategoria.BindearPropiedadEntidad = "NombreCalle"
      Me.txtNombreCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCategoria.Formato = ""
      Me.txtNombreCategoria.IsDecimal = False
      Me.txtNombreCategoria.IsNumber = False
      Me.txtNombreCategoria.IsPK = False
      Me.txtNombreCategoria.IsRequired = True
      Me.txtNombreCategoria.Key = ""
      Me.txtNombreCategoria.LabelAsoc = Me.lblNombre
      Me.txtNombreCategoria.Location = New System.Drawing.Point(62, 40)
      Me.txtNombreCategoria.MaxLength = 50
      Me.txtNombreCategoria.Name = "txtNombreCategoria"
      Me.txtNombreCategoria.Size = New System.Drawing.Size(275, 20)
      Me.txtNombreCategoria.TabIndex = 1
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.Location = New System.Drawing.Point(6, 21)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 5
      Me.lblId.Text = "Código"
      '
      'txtId
      '
      Me.txtId.BindearPropiedadControl = "Text"
      Me.txtId.BindearPropiedadEntidad = "IdCalle"
      Me.txtId.ForeColorFocus = System.Drawing.Color.Red
      Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtId.Formato = ""
      Me.txtId.IsDecimal = False
      Me.txtId.IsNumber = True
      Me.txtId.IsPK = True
      Me.txtId.IsRequired = True
      Me.txtId.Key = ""
      Me.txtId.LabelAsoc = Me.lblId
      Me.txtId.Location = New System.Drawing.Point(62, 14)
      Me.txtId.MaxLength = 9
      Me.txtId.Name = "txtId"
      Me.txtId.Size = New System.Drawing.Size(77, 20)
      Me.txtId.TabIndex = 0
      Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbLocalidades
      '
      Me.cmbLocalidades.BindearPropiedadControl = "SelectedValue"
      Me.cmbLocalidades.BindearPropiedadEntidad = "Localidad.IdLocalidad"
      Me.cmbLocalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLocalidades.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbLocalidades.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbLocalidades.FormattingEnabled = True
      Me.cmbLocalidades.IsPK = False
      Me.cmbLocalidades.IsRequired = True
      Me.cmbLocalidades.Key = Nothing
      Me.cmbLocalidades.LabelAsoc = Me.lblLocalidad
      Me.cmbLocalidades.Location = New System.Drawing.Point(62, 66)
      Me.cmbLocalidades.Name = "cmbLocalidades"
      Me.cmbLocalidades.Size = New System.Drawing.Size(275, 21)
      Me.cmbLocalidades.TabIndex = 2
      '
      'lblLocalidad
      '
      Me.lblLocalidad.AutoSize = True
      Me.lblLocalidad.Location = New System.Drawing.Point(6, 74)
      Me.lblLocalidad.Name = "lblLocalidad"
      Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
      Me.lblLocalidad.TabIndex = 7
      Me.lblLocalidad.Text = "Localidad"
      '
      'CallesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(348, 147)
      Me.Controls.Add(Me.cmbLocalidades)
      Me.Controls.Add(Me.lblLocalidad)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombreCategoria)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtId)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CallesDetalle"
      Me.Text = "Calle"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtId, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtNombreCategoria, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.lblLocalidad, 0)
      Me.Controls.SetChildIndex(Me.cmbLocalidades, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombreCategoria As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtId As Eniac.Controles.TextBox
   Friend WithEvents cmbLocalidades As Eniac.Controles.ComboBox
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
End Class
