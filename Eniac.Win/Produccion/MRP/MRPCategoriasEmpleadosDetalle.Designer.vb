<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MRPCategoriasEmpleadosDetalle
   Inherits BaseDetalle

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
        Me.chbActivo = New Eniac.Controles.CheckBox()
        Me.txtValorHora = New Eniac.Controles.TextBox()
        Me.lblValorhora = New Eniac.Controles.Label()
        Me.txtCodigoCategoria = New Eniac.Controles.TextBox()
        Me.lblCodigoCategoria = New Eniac.Controles.Label()
        Me.lblDescripcion = New Eniac.Controles.Label()
        Me.txtDescripcion = New Eniac.Controles.TextBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(313, 78)
        Me.btnAceptar.TabIndex = 7
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(399, 78)
        Me.btnCancelar.TabIndex = 8
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(212, 143)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(155, 143)
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(425, 17)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 4
        Me.chbActivo.Text = "Activa"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'txtValorHora
        '
        Me.txtValorHora.BindearPropiedadControl = "Text"
        Me.txtValorHora.BindearPropiedadEntidad = "ValorhoraProduccion"
        Me.txtValorHora.ForeColorFocus = System.Drawing.Color.Red
        Me.txtValorHora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtValorHora.Formato = ""
        Me.txtValorHora.IsDecimal = True
        Me.txtValorHora.IsNumber = True
        Me.txtValorHora.IsPK = False
        Me.txtValorHora.IsRequired = True
        Me.txtValorHora.Key = ""
        Me.txtValorHora.LabelAsoc = Me.lblValorhora
        Me.txtValorHora.Location = New System.Drawing.Point(299, 15)
        Me.txtValorHora.MaxLength = 12
        Me.txtValorHora.Name = "txtValorHora"
        Me.txtValorHora.Size = New System.Drawing.Size(115, 20)
        Me.txtValorHora.TabIndex = 3
        Me.txtValorHora.Text = "0.00"
        Me.txtValorHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblValorhora
        '
        Me.lblValorhora.AutoSize = True
        Me.lblValorhora.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblValorhora.LabelAsoc = Nothing
        Me.lblValorhora.Location = New System.Drawing.Point(179, 19)
        Me.lblValorhora.Name = "lblValorhora"
        Me.lblValorhora.Size = New System.Drawing.Size(114, 13)
        Me.lblValorhora.TabIndex = 2
        Me.lblValorhora.Text = "Valor Hora Producción"
        '
        'txtCodigoCategoria
        '
        Me.txtCodigoCategoria.BindearPropiedadControl = "Text"
        Me.txtCodigoCategoria.BindearPropiedadEntidad = "CodigoCategoriaEmpleado"
        Me.txtCodigoCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoCategoria.Formato = ""
        Me.txtCodigoCategoria.IsDecimal = False
        Me.txtCodigoCategoria.IsNumber = False
        Me.txtCodigoCategoria.IsPK = True
        Me.txtCodigoCategoria.IsRequired = True
        Me.txtCodigoCategoria.Key = ""
        Me.txtCodigoCategoria.LabelAsoc = Me.lblCodigoCategoria
        Me.txtCodigoCategoria.Location = New System.Drawing.Point(83, 16)
        Me.txtCodigoCategoria.MaxLength = 12
        Me.txtCodigoCategoria.Name = "txtCodigoCategoria"
        Me.txtCodigoCategoria.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigoCategoria.TabIndex = 1
        '
        'lblCodigoCategoria
        '
        Me.lblCodigoCategoria.AutoSize = True
        Me.lblCodigoCategoria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoCategoria.LabelAsoc = Nothing
        Me.lblCodigoCategoria.Location = New System.Drawing.Point(14, 19)
        Me.lblCodigoCategoria.Name = "lblCodigoCategoria"
        Me.lblCodigoCategoria.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCategoria.TabIndex = 0
        Me.lblCodigoCategoria.Text = "Código"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(14, 45)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 5
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = True
        Me.txtDescripcion.Key = "NombreEmpleado"
        Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
        Me.txtDescripcion.Location = New System.Drawing.Point(83, 42)
        Me.txtDescripcion.MaxLength = 100
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(393, 20)
        Me.txtDescripcion.TabIndex = 6
        '
        'MRPCategoriasEmpleadosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 113)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.txtValorHora)
        Me.Controls.Add(Me.lblValorhora)
        Me.Controls.Add(Me.txtCodigoCategoria)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblCodigoCategoria)
        Me.Name = "MRPCategoriasEmpleadosDetalle"
        Me.Text = "Categorias de Empleados"
        Me.Controls.SetChildIndex(Me.lblCodigoCategoria, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoCategoria, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.lblValorhora, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtValorHora, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCodigoCategoria As Controles.Label
    Friend WithEvents lblDescripcion As Controles.Label
    Friend WithEvents txtDescripcion As Controles.TextBox
    Friend WithEvents chbActivo As Controles.CheckBox
    Friend WithEvents lblValorhora As Controles.Label
    Friend WithEvents txtValorHora As Controles.TextBox
    Friend WithEvents txtCodigoCategoria As Controles.TextBox
End Class
