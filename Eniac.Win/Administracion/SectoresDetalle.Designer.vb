<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SectoresDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SectoresDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.chkAreaComun = New Eniac.Controles.CheckBox()
      Me.cmbAreaComun = New Eniac.Controles.ComboBox()
      Me.lblAreaComun = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(330, 203)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(421, 203)
      Me.btnCancelar.TabIndex = 7
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(12, 45)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 9
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreSector"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(85, 42)
      Me.txtNombre.MaxLength = 60
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(422, 20)
      Me.txtNombre.TabIndex = 1
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.Location = New System.Drawing.Point(12, 19)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 8
      Me.lblId.Text = "Código"
      '
      'txtId
      '
      Me.txtId.BindearPropiedadControl = "Text"
      Me.txtId.BindearPropiedadEntidad = "IdSector"
      Me.txtId.ForeColorFocus = System.Drawing.Color.Red
      Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtId.Formato = ""
      Me.txtId.IsDecimal = False
      Me.txtId.IsNumber = True
      Me.txtId.IsPK = True
      Me.txtId.IsRequired = True
      Me.txtId.Key = ""
      Me.txtId.LabelAsoc = Me.lblId
      Me.txtId.Location = New System.Drawing.Point(85, 16)
      Me.txtId.MaxLength = 5
      Me.txtId.Name = "txtId"
      Me.txtId.Size = New System.Drawing.Size(88, 20)
      Me.txtId.TabIndex = 0
      '
      'chkAreaComun
      '
      Me.chkAreaComun.AutoSize = True
      Me.chkAreaComun.BindearPropiedadControl = ""
      Me.chkAreaComun.BindearPropiedadEntidad = ""
      Me.chkAreaComun.ForeColorFocus = System.Drawing.Color.Red
      Me.chkAreaComun.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkAreaComun.IsPK = False
      Me.chkAreaComun.IsRequired = False
      Me.chkAreaComun.Key = Nothing
      Me.chkAreaComun.LabelAsoc = Nothing
      Me.chkAreaComun.Location = New System.Drawing.Point(85, 70)
      Me.chkAreaComun.Name = "chkAreaComun"
      Me.chkAreaComun.Size = New System.Drawing.Size(148, 17)
      Me.chkAreaComun.TabIndex = 2
      Me.chkAreaComun.Text = "Pertenece al área común:"
      Me.chkAreaComun.UseVisualStyleBackColor = True
      '
      'cmbAreaComun
      '
      Me.cmbAreaComun.BindearPropiedadControl = ""
      Me.cmbAreaComun.BindearPropiedadEntidad = ""
      Me.cmbAreaComun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAreaComun.Enabled = False
      Me.cmbAreaComun.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbAreaComun.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbAreaComun.FormattingEnabled = True
      Me.cmbAreaComun.IsPK = False
      Me.cmbAreaComun.IsRequired = False
      Me.cmbAreaComun.Key = Nothing
      Me.cmbAreaComun.LabelAsoc = Me.lblAreaComun
      Me.cmbAreaComun.Location = New System.Drawing.Point(239, 68)
      Me.cmbAreaComun.Name = "cmbAreaComun"
      Me.cmbAreaComun.Size = New System.Drawing.Size(180, 21)
      Me.cmbAreaComun.TabIndex = 3
      '
      'lblAreaComun
      '
      Me.lblAreaComun.AutoSize = True
      Me.lblAreaComun.Location = New System.Drawing.Point(425, 71)
      Me.lblAreaComun.Name = "lblAreaComun"
      Me.lblAreaComun.Size = New System.Drawing.Size(65, 13)
      Me.lblAreaComun.TabIndex = 4
      Me.lblAreaComun.Text = "Área Común"
      Me.lblAreaComun.Visible = False
      '
      'txtObservacion
      '
      Me.txtObservacion.BindearPropiedadControl = "Text"
      Me.txtObservacion.BindearPropiedadEntidad = "Observaciones"
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Me.lblObservacion
      Me.txtObservacion.Location = New System.Drawing.Point(85, 95)
      Me.txtObservacion.MaxLength = 200
      Me.txtObservacion.Multiline = True
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(407, 102)
      Me.txtObservacion.TabIndex = 5
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.Location = New System.Drawing.Point(12, 98)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
      Me.lblObservacion.TabIndex = 10
      Me.lblObservacion.Text = "Observación"
      '
      'SectoresDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(510, 238)
      Me.Controls.Add(Me.lblAreaComun)
      Me.Controls.Add(Me.txtObservacion)
      Me.Controls.Add(Me.lblObservacion)
      Me.Controls.Add(Me.cmbAreaComun)
      Me.Controls.Add(Me.chkAreaComun)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtId)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "SectoresDetalle"
      Me.Text = "Sector"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtId, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.chkAreaComun, 0)
      Me.Controls.SetChildIndex(Me.cmbAreaComun, 0)
      Me.Controls.SetChildIndex(Me.lblObservacion, 0)
      Me.Controls.SetChildIndex(Me.txtObservacion, 0)
      Me.Controls.SetChildIndex(Me.lblAreaComun, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
    Friend WithEvents txtNombre As Eniac.Controles.TextBox
    Friend WithEvents lblId As Eniac.Controles.Label
    Friend WithEvents txtId As Eniac.Controles.TextBox
    Friend WithEvents chkAreaComun As Eniac.Controles.CheckBox
    Friend WithEvents cmbAreaComun As Eniac.Controles.ComboBox
    Friend WithEvents txtObservacion As Eniac.Controles.TextBox
    Friend WithEvents lblObservacion As Eniac.Controles.Label
    Friend WithEvents lblAreaComun As Eniac.Controles.Label
End Class
