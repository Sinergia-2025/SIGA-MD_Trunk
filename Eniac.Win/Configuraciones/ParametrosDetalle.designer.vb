<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParametrosDetalle
   Inherits Eniac.Win.BaseDetalle

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.lblNombreParametro = New Eniac.Controles.Label()
      Me.txtNombreParametro = New Eniac.Controles.TextBox()
      Me.lblIdParametro = New Eniac.Controles.Label()
      Me.txtParametro = New Eniac.Controles.TextBox()
      Me.lblValorParametro = New Eniac.Controles.Label()
      Me.txtValorParametro = New Eniac.Controles.TextBox()
      Me.lblCategoria = New Eniac.Controles.Label()
      Me.txtCategoria = New Eniac.Controles.TextBox()
        Me.lblUbicacionParametro = New Eniac.Controles.Label()
        Me.txtUbicacionParametro = New Eniac.Controles.TextBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(505, 150)
        Me.btnAceptar.TabIndex = 10
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(591, 150)
        Me.btnCancelar.TabIndex = 11
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(404, 150)
        Me.btnCopiar.TabIndex = 9
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(347, 150)
        Me.btnAplicar.TabIndex = 8
        '
        'lblNombreParametro
        '
        Me.lblNombreParametro.AutoSize = True
        Me.lblNombreParametro.LabelAsoc = Nothing
        Me.lblNombreParametro.Location = New System.Drawing.Point(21, 93)
        Me.lblNombreParametro.Name = "lblNombreParametro"
        Me.lblNombreParametro.Size = New System.Drawing.Size(63, 13)
        Me.lblNombreParametro.TabIndex = 6
        Me.lblNombreParametro.Text = "Descripción"
        '
        'txtNombreParametro
        '
        Me.txtNombreParametro.BindearPropiedadControl = "Text"
        Me.txtNombreParametro.BindearPropiedadEntidad = "DescripcionParametro"
        Me.txtNombreParametro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreParametro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreParametro.Formato = ""
        Me.txtNombreParametro.IsDecimal = False
        Me.txtNombreParametro.IsNumber = False
        Me.txtNombreParametro.IsPK = False
        Me.txtNombreParametro.IsRequired = False
        Me.txtNombreParametro.Key = ""
        Me.txtNombreParametro.LabelAsoc = Me.lblNombreParametro
        Me.txtNombreParametro.Location = New System.Drawing.Point(99, 90)
        Me.txtNombreParametro.MaxLength = 200
        Me.txtNombreParametro.Name = "txtNombreParametro"
        Me.txtNombreParametro.Size = New System.Drawing.Size(570, 20)
        Me.txtNombreParametro.TabIndex = 7
        '
        'lblIdParametro
        '
        Me.lblIdParametro.AutoSize = True
        Me.lblIdParametro.LabelAsoc = Nothing
        Me.lblIdParametro.Location = New System.Drawing.Point(21, 15)
        Me.lblIdParametro.Name = "lblIdParametro"
        Me.lblIdParametro.Size = New System.Drawing.Size(40, 13)
        Me.lblIdParametro.TabIndex = 0
        Me.lblIdParametro.Text = "Código"
        '
        'txtParametro
        '
        Me.txtParametro.BindearPropiedadControl = "Text"
        Me.txtParametro.BindearPropiedadEntidad = "IdParametro"
        Me.txtParametro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtParametro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtParametro.Formato = ""
        Me.txtParametro.IsDecimal = False
        Me.txtParametro.IsNumber = False
        Me.txtParametro.IsPK = True
        Me.txtParametro.IsRequired = True
        Me.txtParametro.Key = ""
        Me.txtParametro.LabelAsoc = Me.lblIdParametro
        Me.txtParametro.Location = New System.Drawing.Point(99, 12)
        Me.txtParametro.MaxLength = 50
        Me.txtParametro.Name = "txtParametro"
        Me.txtParametro.Size = New System.Drawing.Size(211, 20)
        Me.txtParametro.TabIndex = 1
        '
        'lblValorParametro
        '
        Me.lblValorParametro.AutoSize = True
        Me.lblValorParametro.LabelAsoc = Nothing
        Me.lblValorParametro.Location = New System.Drawing.Point(21, 41)
        Me.lblValorParametro.Name = "lblValorParametro"
        Me.lblValorParametro.Size = New System.Drawing.Size(31, 13)
        Me.lblValorParametro.TabIndex = 2
        Me.lblValorParametro.Text = "Valor"
        '
        'txtValorParametro
        '
        Me.txtValorParametro.BindearPropiedadControl = "Text"
        Me.txtValorParametro.BindearPropiedadEntidad = "ValorParametro"
        Me.txtValorParametro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtValorParametro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtValorParametro.Formato = ""
        Me.txtValorParametro.IsDecimal = False
        Me.txtValorParametro.IsNumber = False
        Me.txtValorParametro.IsPK = False
        Me.txtValorParametro.IsRequired = True
        Me.txtValorParametro.Key = ""
        Me.txtValorParametro.LabelAsoc = Me.lblValorParametro
        Me.txtValorParametro.Location = New System.Drawing.Point(99, 38)
        Me.txtValorParametro.MaxLength = 200
        Me.txtValorParametro.Name = "txtValorParametro"
        Me.txtValorParametro.Size = New System.Drawing.Size(570, 20)
        Me.txtValorParametro.TabIndex = 3
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.LabelAsoc = Nothing
        Me.lblCategoria.Location = New System.Drawing.Point(21, 67)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(54, 13)
        Me.lblCategoria.TabIndex = 4
        Me.lblCategoria.Text = "Categoría"
        '
        'txtCategoria
        '
        Me.txtCategoria.BindearPropiedadControl = "Text"
        Me.txtCategoria.BindearPropiedadEntidad = "CategoriaParametro"
        Me.txtCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCategoria.Formato = ""
        Me.txtCategoria.IsDecimal = False
        Me.txtCategoria.IsNumber = False
        Me.txtCategoria.IsPK = False
        Me.txtCategoria.IsRequired = False
        Me.txtCategoria.Key = ""
        Me.txtCategoria.LabelAsoc = Me.lblCategoria
        Me.txtCategoria.Location = New System.Drawing.Point(99, 64)
        Me.txtCategoria.MaxLength = 20
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(211, 20)
        Me.txtCategoria.TabIndex = 5
        '
        'lblUbicacionParametro
        '
        Me.lblUbicacionParametro.AutoSize = True
        Me.lblUbicacionParametro.LabelAsoc = Nothing
        Me.lblUbicacionParametro.Location = New System.Drawing.Point(21, 119)
        Me.lblUbicacionParametro.Name = "lblUbicacionParametro"
        Me.lblUbicacionParametro.Size = New System.Drawing.Size(55, 13)
        Me.lblUbicacionParametro.TabIndex = 12
        Me.lblUbicacionParametro.Text = "Ubicación"
        '
        'txtUbicacionParametro
        '
        Me.txtUbicacionParametro.BindearPropiedadControl = "Text"
        Me.txtUbicacionParametro.BindearPropiedadEntidad = "UbicacionParametro"
        Me.txtUbicacionParametro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUbicacionParametro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUbicacionParametro.Formato = ""
        Me.txtUbicacionParametro.IsDecimal = False
        Me.txtUbicacionParametro.IsNumber = False
        Me.txtUbicacionParametro.IsPK = False
        Me.txtUbicacionParametro.IsRequired = False
        Me.txtUbicacionParametro.Key = ""
        Me.txtUbicacionParametro.LabelAsoc = Me.lblUbicacionParametro
        Me.txtUbicacionParametro.Location = New System.Drawing.Point(99, 116)
        Me.txtUbicacionParametro.MaxLength = 200
        Me.txtUbicacionParametro.Name = "txtUbicacionParametro"
        Me.txtUbicacionParametro.ReadOnly = True
        Me.txtUbicacionParametro.Size = New System.Drawing.Size(570, 20)
        Me.txtUbicacionParametro.TabIndex = 13
        '
        'ParametrosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(680, 185)
        Me.Controls.Add(Me.lblUbicacionParametro)
        Me.Controls.Add(Me.txtUbicacionParametro)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.lblValorParametro)
        Me.Controls.Add(Me.txtValorParametro)
        Me.Controls.Add(Me.lblNombreParametro)
        Me.Controls.Add(Me.txtNombreParametro)
        Me.Controls.Add(Me.lblIdParametro)
        Me.Controls.Add(Me.txtParametro)
        Me.Name = "ParametrosDetalle"
        Me.Text = "Parámetro"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtParametro, 0)
        Me.Controls.SetChildIndex(Me.lblIdParametro, 0)
        Me.Controls.SetChildIndex(Me.txtNombreParametro, 0)
        Me.Controls.SetChildIndex(Me.lblNombreParametro, 0)
        Me.Controls.SetChildIndex(Me.txtValorParametro, 0)
        Me.Controls.SetChildIndex(Me.lblValorParametro, 0)
        Me.Controls.SetChildIndex(Me.txtCategoria, 0)
        Me.Controls.SetChildIndex(Me.lblCategoria, 0)
        Me.Controls.SetChildIndex(Me.txtUbicacionParametro, 0)
        Me.Controls.SetChildIndex(Me.lblUbicacionParametro, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombreParametro As Eniac.Controles.Label
    Friend WithEvents txtNombreParametro As Eniac.Controles.TextBox
    Friend WithEvents lblIdParametro As Eniac.Controles.Label
    Friend WithEvents txtParametro As Eniac.Controles.TextBox
   Friend WithEvents lblValorParametro As Eniac.Controles.Label
    Friend WithEvents txtValorParametro As Eniac.Controles.TextBox
    Friend WithEvents lblCategoria As Eniac.Controles.Label
    Friend WithEvents txtCategoria As Eniac.Controles.TextBox
    Friend WithEvents lblUbicacionParametro As Controles.Label
    Friend WithEvents txtUbicacionParametro As Controles.TextBox
End Class
