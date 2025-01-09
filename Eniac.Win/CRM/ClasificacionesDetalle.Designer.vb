<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClasificacionesDetalle
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
      Me.txtNombreCalificacion = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtIdCalificacion = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(196, 118)
        Me.btnAceptar.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(282, 118)
        Me.btnCancelar.TabIndex = 5
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(95, 118)
        Me.btnCopiar.TabIndex = 6
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(38, 118)
      Me.btnAplicar.TabIndex = 7

        '
        'txtNombreCalificacion
        '
        Me.txtNombreCalificacion.BindearPropiedadControl = "Text"
        Me.txtNombreCalificacion.BindearPropiedadEntidad = "NombreClasificacion"
        Me.txtNombreCalificacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreCalificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreCalificacion.Formato = ""
        Me.txtNombreCalificacion.IsDecimal = False
        Me.txtNombreCalificacion.IsNumber = False
        Me.txtNombreCalificacion.IsPK = False
        Me.txtNombreCalificacion.IsRequired = True
        Me.txtNombreCalificacion.Key = ""
        Me.txtNombreCalificacion.LabelAsoc = Me.lblNombre
        Me.txtNombreCalificacion.Location = New System.Drawing.Point(78, 41)
        Me.txtNombreCalificacion.MaxLength = 40
        Me.txtNombreCalificacion.Name = "txtNombreCalificacion"
        Me.txtNombreCalificacion.Size = New System.Drawing.Size(285, 20)
        Me.txtNombreCalificacion.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(21, 42)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtIdCalificacion
        '
        Me.txtIdCalificacion.BindearPropiedadControl = "Text"
        Me.txtIdCalificacion.BindearPropiedadEntidad = "IdClasificacion"
        Me.txtIdCalificacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdCalificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdCalificacion.Formato = ""
        Me.txtIdCalificacion.IsDecimal = False
        Me.txtIdCalificacion.IsNumber = True
        Me.txtIdCalificacion.IsPK = True
        Me.txtIdCalificacion.IsRequired = True
        Me.txtIdCalificacion.Key = ""
        Me.txtIdCalificacion.LabelAsoc = Me.lblCodigo
        Me.txtIdCalificacion.Location = New System.Drawing.Point(78, 15)
        Me.txtIdCalificacion.MaxLength = 10
        Me.txtIdCalificacion.Name = "txtIdCalificacion"
        Me.txtIdCalificacion.Size = New System.Drawing.Size(120, 20)
        Me.txtIdCalificacion.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(21, 19)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código"
        '
        'ClasificacionesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 153)
        Me.Controls.Add(Me.txtNombreCalificacion)
        Me.Controls.Add(Me.txtIdCalificacion)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblCodigo)
        Me.Name = "ClasificacionesDetalle"
        Me.Text = "Clasificaciones"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtIdCalificacion, 0)
        Me.Controls.SetChildIndex(Me.txtNombreCalificacion, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNombreCalificacion As Controles.TextBox
    Friend WithEvents lblNombre As Controles.Label
    Friend WithEvents txtIdCalificacion As Controles.TextBox
    Friend WithEvents lblCodigo As Controles.Label
End Class
