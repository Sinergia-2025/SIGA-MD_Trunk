<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposObservacionesDetalle
   Inherits BaseDetalle

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
        Me.chbActiva = New Eniac.Controles.CheckBox()
        Me.lblDescripcion = New Eniac.Controles.Label()
        Me.txtDescripcion = New Eniac.Controles.TextBox()
        Me.lblIdObservacion = New Eniac.Controles.Label()
        Me.txtIdObservaciones = New Eniac.Controles.TextBox()
        Me.chbPorDefecto = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(241, 107)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(327, 107)
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(140, 107)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(83, 107)
        '
        'chbActiva
        '
        Me.chbActiva.AutoSize = True
        Me.chbActiva.BindearPropiedadControl = "Checked"
        Me.chbActiva.BindearPropiedadEntidad = "Activa"
        Me.chbActiva.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActiva.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActiva.IsPK = False
        Me.chbActiva.IsRequired = False
        Me.chbActiva.Key = Nothing
        Me.chbActiva.Location = New System.Drawing.Point(110, 70)
        Me.chbActiva.Name = "chbActiva"
        Me.chbActiva.Size = New System.Drawing.Size(56, 17)
        Me.chbActiva.TabIndex = 11
        Me.chbActiva.Text = "Activa"
        Me.chbActiva.UseVisualStyleBackColor = True
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(12, 43)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 13
        Me.lblDescripcion.Text = "Descripcion"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = True
        Me.txtDescripcion.Key = ""
        Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
        Me.txtDescripcion.Location = New System.Drawing.Point(110, 36)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(263, 20)
        Me.txtDescripcion.TabIndex = 10
        '
        'lblIdObservacion
        '
        Me.lblIdObservacion.AutoSize = True
        Me.lblIdObservacion.LabelAsoc = Nothing
        Me.lblIdObservacion.Location = New System.Drawing.Point(12, 15)
        Me.lblIdObservacion.Name = "lblIdObservacion"
        Me.lblIdObservacion.Size = New System.Drawing.Size(40, 13)
        Me.lblIdObservacion.TabIndex = 12
        Me.lblIdObservacion.Text = "Codigo"
        '
        'txtIdObservaciones
        '
        Me.txtIdObservaciones.BindearPropiedadControl = "Text"
        Me.txtIdObservaciones.BindearPropiedadEntidad = "IdObservaciones"
        Me.txtIdObservaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdObservaciones.Formato = ""
        Me.txtIdObservaciones.IsDecimal = False
        Me.txtIdObservaciones.IsNumber = True
        Me.txtIdObservaciones.IsPK = True
        Me.txtIdObservaciones.IsRequired = True
        Me.txtIdObservaciones.Key = ""
        Me.txtIdObservaciones.LabelAsoc = Nothing
        Me.txtIdObservaciones.Location = New System.Drawing.Point(110, 8)
        Me.txtIdObservaciones.MaxLength = 6
        Me.txtIdObservaciones.Name = "txtIdObservaciones"
        Me.txtIdObservaciones.Size = New System.Drawing.Size(59, 20)
        Me.txtIdObservaciones.TabIndex = 15
        Me.txtIdObservaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbPorDefecto
        '
        Me.chbPorDefecto.AutoSize = True
        Me.chbPorDefecto.BindearPropiedadControl = "Checked"
        Me.chbPorDefecto.BindearPropiedadEntidad = "PorDefecto"
        Me.chbPorDefecto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPorDefecto.IsPK = False
        Me.chbPorDefecto.IsRequired = False
        Me.chbPorDefecto.Key = Nothing
        Me.chbPorDefecto.Location = New System.Drawing.Point(201, 70)
        Me.chbPorDefecto.Name = "chbPorDefecto"
        Me.chbPorDefecto.Size = New System.Drawing.Size(83, 17)
        Me.chbPorDefecto.TabIndex = 16
        Me.chbPorDefecto.Text = "Por Defecto"
        Me.chbPorDefecto.UseVisualStyleBackColor = True
        '
        'TiposObservacionesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 142)
        Me.Controls.Add(Me.chbPorDefecto)
        Me.Controls.Add(Me.txtIdObservaciones)
        Me.Controls.Add(Me.chbActiva)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblIdObservacion)
        Me.Name = "TiposObservacionesDetalle"
        Me.Text = "Tipo de Observacion"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblIdObservacion, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.chbActiva, 0)
        Me.Controls.SetChildIndex(Me.txtIdObservaciones, 0)
        Me.Controls.SetChildIndex(Me.chbPorDefecto, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chbActiva As Controles.CheckBox
    Friend WithEvents lblDescripcion As Controles.Label
    Friend WithEvents txtDescripcion As Controles.TextBox
    Friend WithEvents lblIdObservacion As Controles.Label
    Friend WithEvents txtIdObservaciones As Controles.TextBox
    Friend WithEvents chbPorDefecto As Controles.CheckBox
End Class
