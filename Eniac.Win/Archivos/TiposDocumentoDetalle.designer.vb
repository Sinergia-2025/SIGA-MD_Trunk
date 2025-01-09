<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposDocumentoDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TiposDocumentoDetalle))
      Me.txtTipoDocumento = New Eniac.Controles.TextBox
      Me.lblIdLocalidad = New Eniac.Controles.Label
      Me.lblNombreLocalidad = New Eniac.Controles.Label
      Me.txtDescripcion = New Eniac.Controles.TextBox
      Me.chbAutoincremental = New Eniac.Controles.CheckBox
      Me.lblAutoincremental = New Eniac.Controles.Label
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(241, 107)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(327, 107)
      Me.btnCancelar.TabIndex = 4
      '
      'txtTipoDocumento
      '
      Me.txtTipoDocumento.BindearPropiedadControl = "Text"
      Me.txtTipoDocumento.BindearPropiedadEntidad = "TipoDocumento"
      Me.txtTipoDocumento.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTipoDocumento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTipoDocumento.Formato = ""
      Me.txtTipoDocumento.IsDecimal = False
      Me.txtTipoDocumento.IsNumber = False
      Me.txtTipoDocumento.IsPK = True
      Me.txtTipoDocumento.IsRequired = True
      Me.txtTipoDocumento.Key = ""
      Me.txtTipoDocumento.LabelAsoc = Me.lblIdLocalidad
      Me.txtTipoDocumento.Location = New System.Drawing.Point(110, 16)
      Me.txtTipoDocumento.MaxLength = 5
      Me.txtTipoDocumento.Name = "txtTipoDocumento"
      Me.txtTipoDocumento.Size = New System.Drawing.Size(59, 20)
      Me.txtTipoDocumento.TabIndex = 0
      '
      'lblIdLocalidad
      '
      Me.lblIdLocalidad.AutoSize = True
      Me.lblIdLocalidad.Location = New System.Drawing.Point(12, 23)
      Me.lblIdLocalidad.Name = "lblIdLocalidad"
      Me.lblIdLocalidad.Size = New System.Drawing.Size(84, 13)
      Me.lblIdLocalidad.TabIndex = 5
      Me.lblIdLocalidad.Text = "Tipo documento"
      '
      'lblNombreLocalidad
      '
      Me.lblNombreLocalidad.AutoSize = True
      Me.lblNombreLocalidad.Location = New System.Drawing.Point(12, 51)
      Me.lblNombreLocalidad.Name = "lblNombreLocalidad"
      Me.lblNombreLocalidad.Size = New System.Drawing.Size(63, 13)
      Me.lblNombreLocalidad.TabIndex = 6
      Me.lblNombreLocalidad.Text = "Descripcion"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "NombreTipoDocumento"
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = True
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.lblNombreLocalidad
      Me.txtDescripcion.Location = New System.Drawing.Point(110, 44)
      Me.txtDescripcion.MaxLength = 50
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(263, 20)
      Me.txtDescripcion.TabIndex = 1
      '
      'chbAutoincremental
      '
      Me.chbAutoincremental.AutoSize = True
      Me.chbAutoincremental.BindearPropiedadControl = "Checked"
      Me.chbAutoincremental.BindearPropiedadEntidad = "EsAutoincremental"
      Me.chbAutoincremental.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAutoincremental.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAutoincremental.IsPK = False
      Me.chbAutoincremental.IsRequired = True
      Me.chbAutoincremental.Key = Nothing
      Me.chbAutoincremental.LabelAsoc = Me.lblAutoincremental
      Me.chbAutoincremental.Location = New System.Drawing.Point(110, 78)
      Me.chbAutoincremental.Name = "chbAutoincremental"
      Me.chbAutoincremental.Size = New System.Drawing.Size(15, 14)
      Me.chbAutoincremental.TabIndex = 2
      Me.chbAutoincremental.UseVisualStyleBackColor = True
      '
      'lblAutoincremental
      '
      Me.lblAutoincremental.AutoSize = True
      Me.lblAutoincremental.Location = New System.Drawing.Point(12, 79)
      Me.lblAutoincremental.Name = "lblAutoincremental"
      Me.lblAutoincremental.Size = New System.Drawing.Size(82, 13)
      Me.lblAutoincremental.TabIndex = 8
      Me.lblAutoincremental.Text = "Incremento Aut."
      '
      'TiposDocumentoDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(416, 142)
      Me.Controls.Add(Me.lblAutoincremental)
      Me.Controls.Add(Me.chbAutoincremental)
      Me.Controls.Add(Me.lblNombreLocalidad)
      Me.Controls.Add(Me.txtDescripcion)
      Me.Controls.Add(Me.lblIdLocalidad)
      Me.Controls.Add(Me.txtTipoDocumento)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "TiposDocumentoDetalle"
      Me.Text = "Tipo de Documento"
      Me.Controls.SetChildIndex(Me.txtTipoDocumento, 0)
      Me.Controls.SetChildIndex(Me.lblIdLocalidad, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
      Me.Controls.SetChildIndex(Me.lblNombreLocalidad, 0)
      Me.Controls.SetChildIndex(Me.chbAutoincremental, 0)
      Me.Controls.SetChildIndex(Me.lblAutoincremental, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Friend WithEvents txtTipoDocumento As Eniac.Controles.TextBox
    Friend WithEvents lblIdLocalidad As Eniac.Controles.Label
    Friend WithEvents lblNombreLocalidad As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents chbAutoincremental As Eniac.Controles.CheckBox
   Friend WithEvents lblAutoincremental As Eniac.Controles.Label

End Class
