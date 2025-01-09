<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadosProyectosDetalle
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.txtIdEstado = New Eniac.Controles.TextBox()
        Me.lblDescripcion = New Eniac.Controles.Label()
        Me.txtNombreEstado = New Eniac.Controles.TextBox()
        Me.txtColor = New Eniac.Controles.TextBox()
        Me.lblColorSemadoro = New Eniac.Controles.Label()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.chbFinalizado = New Eniac.Controles.CheckBox()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.lblPosicion = New Eniac.Controles.Label()
        Me.txtPosicion = New Eniac.Controles.TextBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(239, 173)
        Me.btnAceptar.TabIndex = 12
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(325, 173)
        Me.btnCancelar.TabIndex = 13
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(138, 173)
        Me.btnCopiar.TabIndex = 11
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(81, 173)
        Me.btnAplicar.TabIndex = 10
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(21, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código"
        '
        'txtIdEstado
        '
        Me.txtIdEstado.BindearPropiedadControl = "Text"
        Me.txtIdEstado.BindearPropiedadEntidad = "IdEstado"
        Me.txtIdEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdEstado.Formato = ""
        Me.txtIdEstado.IsDecimal = False
        Me.txtIdEstado.IsNumber = True
        Me.txtIdEstado.IsPK = True
        Me.txtIdEstado.IsRequired = True
        Me.txtIdEstado.Key = ""
        Me.txtIdEstado.LabelAsoc = Me.lblCodigo
        Me.txtIdEstado.Location = New System.Drawing.Point(98, 12)
        Me.txtIdEstado.MaxLength = 10
        Me.txtIdEstado.Name = "txtIdEstado"
        Me.txtIdEstado.Size = New System.Drawing.Size(54, 20)
        Me.txtIdEstado.TabIndex = 1
        Me.txtIdEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(21, 55)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 2
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtNombreEstado
        '
        Me.txtNombreEstado.BindearPropiedadControl = "Text"
        Me.txtNombreEstado.BindearPropiedadEntidad = "NombreEstado"
        Me.txtNombreEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreEstado.Formato = ""
        Me.txtNombreEstado.IsDecimal = False
        Me.txtNombreEstado.IsNumber = False
        Me.txtNombreEstado.IsPK = False
        Me.txtNombreEstado.IsRequired = True
        Me.txtNombreEstado.Key = ""
        Me.txtNombreEstado.LabelAsoc = Me.lblDescripcion
        Me.txtNombreEstado.Location = New System.Drawing.Point(98, 51)
        Me.txtNombreEstado.MaxLength = 20
        Me.txtNombreEstado.Name = "txtNombreEstado"
        Me.txtNombreEstado.Size = New System.Drawing.Size(262, 20)
        Me.txtNombreEstado.TabIndex = 3
        '
        'txtColor
        '
        Me.txtColor.BindearPropiedadControl = "Key"
        Me.txtColor.BindearPropiedadEntidad = "Color"
        Me.txtColor.Enabled = False
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = False
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Me.lblColorSemadoro
        Me.txtColor.Location = New System.Drawing.Point(98, 128)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(82, 20)
        Me.txtColor.TabIndex = 8
        Me.txtColor.TabStop = False
        '
        'lblColorSemadoro
        '
        Me.lblColorSemadoro.AutoSize = True
        Me.lblColorSemadoro.LabelAsoc = Nothing
        Me.lblColorSemadoro.Location = New System.Drawing.Point(61, 132)
        Me.lblColorSemadoro.Name = "lblColorSemadoro"
        Me.lblColorSemadoro.Size = New System.Drawing.Size(31, 13)
        Me.lblColorSemadoro.TabIndex = 7
        Me.lblColorSemadoro.Text = "Color"
        '
        'btnColor
        '
        Me.btnColor.Location = New System.Drawing.Point(186, 127)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(57, 23)
        Me.btnColor.TabIndex = 9
        Me.btnColor.Text = "Paleta"
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'chbFinalizado
        '
        Me.chbFinalizado.AutoSize = True
        Me.chbFinalizado.BindearPropiedadControl = "Checked"
        Me.chbFinalizado.BindearPropiedadEntidad = "Finalizado"
        Me.chbFinalizado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbFinalizado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFinalizado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFinalizado.IsPK = False
        Me.chbFinalizado.IsRequired = False
        Me.chbFinalizado.Key = Nothing
        Me.chbFinalizado.LabelAsoc = Nothing
        Me.chbFinalizado.Location = New System.Drawing.Point(24, 90)
        Me.chbFinalizado.Name = "chbFinalizado"
        Me.chbFinalizado.Size = New System.Drawing.Size(73, 17)
        Me.chbFinalizado.TabIndex = 4
        Me.chbFinalizado.Text = "Finalizado"
        Me.chbFinalizado.UseVisualStyleBackColor = True
        '
        'lblPosicion
        '
        Me.lblPosicion.AutoSize = True
        Me.lblPosicion.LabelAsoc = Nothing
        Me.lblPosicion.Location = New System.Drawing.Point(105, 91)
        Me.lblPosicion.Name = "lblPosicion"
        Me.lblPosicion.Size = New System.Drawing.Size(47, 13)
        Me.lblPosicion.TabIndex = 5
        Me.lblPosicion.Text = "Posición"
        '
        'txtPosicion
        '
        Me.txtPosicion.BindearPropiedadControl = "Text"
        Me.txtPosicion.BindearPropiedadEntidad = "Posicion"
        Me.txtPosicion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPosicion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPosicion.Formato = ""
        Me.txtPosicion.IsDecimal = False
        Me.txtPosicion.IsNumber = True
        Me.txtPosicion.IsPK = False
        Me.txtPosicion.IsRequired = True
        Me.txtPosicion.Key = ""
        Me.txtPosicion.LabelAsoc = Me.lblPosicion
        Me.txtPosicion.Location = New System.Drawing.Point(157, 88)
        Me.txtPosicion.MaxLength = 4
        Me.txtPosicion.Name = "txtPosicion"
        Me.txtPosicion.Size = New System.Drawing.Size(54, 20)
        Me.txtPosicion.TabIndex = 6
        Me.txtPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EstadosProyectosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 215)
        Me.Controls.Add(Me.lblPosicion)
        Me.Controls.Add(Me.txtPosicion)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.lblColorSemadoro)
        Me.Controls.Add(Me.btnColor)
        Me.Controls.Add(Me.chbFinalizado)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtNombreEstado)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.txtIdEstado)
        Me.Name = "EstadosProyectosDetalle"
        Me.Text = "Estado de Proyecto"
        Me.Controls.SetChildIndex(Me.txtIdEstado, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.txtNombreEstado, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.chbFinalizado, 0)
        Me.Controls.SetChildIndex(Me.btnColor, 0)
        Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
        Me.Controls.SetChildIndex(Me.txtColor, 0)
        Me.Controls.SetChildIndex(Me.txtPosicion, 0)
        Me.Controls.SetChildIndex(Me.lblPosicion, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCodigo As Controles.Label
    Friend WithEvents txtIdEstado As Controles.TextBox
    Friend WithEvents lblDescripcion As Controles.Label
    Friend WithEvents txtNombreEstado As Controles.TextBox
    Friend WithEvents txtColor As Eniac.Controles.TextBox
    Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
    Friend WithEvents btnColor As System.Windows.Forms.Button
    Friend WithEvents chbFinalizado As Eniac.Controles.CheckBox
    Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
    Friend WithEvents lblPosicion As Controles.Label
    Friend WithEvents txtPosicion As Controles.TextBox
End Class
