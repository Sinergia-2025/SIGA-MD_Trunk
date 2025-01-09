<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ObservacionesDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ObservacionesDetalle))
      Me.lblDetalleObservacion = New Eniac.Controles.Label()
      Me.txtDetalleObservacion = New Eniac.Controles.TextBox()
      Me.lblIdObservacion = New Eniac.Controles.Label()
      Me.txtIdObservacion = New Eniac.Controles.TextBox()
      Me.cboTipo = New Eniac.Controles.ComboBox()
      Me.lblTipo = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(544, 117)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(630, 117)
      Me.btnCancelar.TabIndex = 7
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(443, 117)
      '
      'lblDetalleObservacion
      '
      Me.lblDetalleObservacion.AutoSize = True
      Me.lblDetalleObservacion.Location = New System.Drawing.Point(28, 45)
      Me.lblDetalleObservacion.Name = "lblDetalleObservacion"
      Me.lblDetalleObservacion.Size = New System.Drawing.Size(44, 13)
      Me.lblDetalleObservacion.TabIndex = 2
      Me.lblDetalleObservacion.Text = "Nombre"
      '
      'txtDetalleObservacion
      '
      Me.txtDetalleObservacion.BindearPropiedadControl = "Text"
      Me.txtDetalleObservacion.BindearPropiedadEntidad = "DetalleObservacion"
      Me.txtDetalleObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDetalleObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDetalleObservacion.Formato = ""
      Me.txtDetalleObservacion.IsDecimal = False
      Me.txtDetalleObservacion.IsNumber = False
      Me.txtDetalleObservacion.IsPK = False
      Me.txtDetalleObservacion.IsRequired = True
      Me.txtDetalleObservacion.Key = ""
      Me.txtDetalleObservacion.LabelAsoc = Me.lblDetalleObservacion
      Me.txtDetalleObservacion.Location = New System.Drawing.Point(87, 41)
      Me.txtDetalleObservacion.MaxLength = 100
      Me.txtDetalleObservacion.Name = "txtDetalleObservacion"
      Me.txtDetalleObservacion.Size = New System.Drawing.Size(620, 20)
      Me.txtDetalleObservacion.TabIndex = 3
      '
      'lblIdObservacion
      '
      Me.lblIdObservacion.AutoSize = True
      Me.lblIdObservacion.Location = New System.Drawing.Point(28, 17)
      Me.lblIdObservacion.Name = "lblIdObservacion"
      Me.lblIdObservacion.Size = New System.Drawing.Size(40, 13)
      Me.lblIdObservacion.TabIndex = 0
      Me.lblIdObservacion.Text = "Código"
      '
      'txtIdObservacion
      '
      Me.txtIdObservacion.BindearPropiedadControl = "Text"
      Me.txtIdObservacion.BindearPropiedadEntidad = "IdObservacion"
      Me.txtIdObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdObservacion.Formato = ""
      Me.txtIdObservacion.IsDecimal = False
      Me.txtIdObservacion.IsNumber = True
      Me.txtIdObservacion.IsPK = True
      Me.txtIdObservacion.IsRequired = True
      Me.txtIdObservacion.Key = ""
      Me.txtIdObservacion.LabelAsoc = Me.lblIdObservacion
      Me.txtIdObservacion.Location = New System.Drawing.Point(87, 13)
      Me.txtIdObservacion.MaxLength = 5
      Me.txtIdObservacion.Name = "txtIdObservacion"
      Me.txtIdObservacion.Size = New System.Drawing.Size(48, 20)
      Me.txtIdObservacion.TabIndex = 1
      Me.txtIdObservacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cboTipo
      '
      Me.cboTipo.BindearPropiedadControl = "SelectedValue"
      Me.cboTipo.BindearPropiedadEntidad = "Tipo"
      Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboTipo.ForeColorFocus = System.Drawing.Color.Red
      Me.cboTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboTipo.FormattingEnabled = True
      Me.cboTipo.IsPK = False
      Me.cboTipo.IsRequired = False
      Me.cboTipo.Key = Nothing
      Me.cboTipo.LabelAsoc = Nothing
      Me.cboTipo.Location = New System.Drawing.Point(87, 66)
      Me.cboTipo.Name = "cboTipo"
      Me.cboTipo.Size = New System.Drawing.Size(148, 21)
      Me.cboTipo.TabIndex = 5
      Me.cboTipo.TabStop = False
      '
      'lblTipo
      '
      Me.lblTipo.AutoSize = True
      Me.lblTipo.Location = New System.Drawing.Point(28, 69)
      Me.lblTipo.Name = "lblTipo"
      Me.lblTipo.Size = New System.Drawing.Size(28, 13)
      Me.lblTipo.TabIndex = 4
      Me.lblTipo.Text = "Tipo"
      '
      'ObservacionesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(719, 152)
      Me.Controls.Add(Me.cboTipo)
      Me.Controls.Add(Me.lblTipo)
      Me.Controls.Add(Me.lblDetalleObservacion)
      Me.Controls.Add(Me.txtDetalleObservacion)
      Me.Controls.Add(Me.lblIdObservacion)
      Me.Controls.Add(Me.txtIdObservacion)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ObservacionesDetalle"
      Me.Text = "Observacion"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdObservacion, 0)
      Me.Controls.SetChildIndex(Me.lblIdObservacion, 0)
      Me.Controls.SetChildIndex(Me.txtDetalleObservacion, 0)
      Me.Controls.SetChildIndex(Me.lblDetalleObservacion, 0)
      Me.Controls.SetChildIndex(Me.lblTipo, 0)
      Me.Controls.SetChildIndex(Me.cboTipo, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDetalleObservacion As Eniac.Controles.Label
   Friend WithEvents txtDetalleObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblIdObservacion As Eniac.Controles.Label
   Friend WithEvents txtIdObservacion As Eniac.Controles.TextBox
   Friend WithEvents cboTipo As Eniac.Controles.ComboBox
   Friend WithEvents lblTipo As Eniac.Controles.Label

End Class
