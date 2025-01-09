<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposChequesDetalle
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
        Me.txtIdTipoCheque = New Eniac.Controles.TextBox()
        Me.lblDescripcion = New Eniac.Controles.Label()
        Me.txtNombreTipoCheque = New Eniac.Controles.TextBox()
        Me.chbSolicitarNroOperacion = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(191, 165)
        Me.btnAceptar.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(277, 165)
        Me.btnCancelar.TabIndex = 6
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(90, 165)
        Me.btnCopiar.TabIndex = 7
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(33, 165)
        Me.btnAplicar.TabIndex = 8
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
        'txtIdTipoCheque
        '
        Me.txtIdTipoCheque.BindearPropiedadControl = "Text"
        Me.txtIdTipoCheque.BindearPropiedadEntidad = "IdTipoCheque"
        Me.txtIdTipoCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdTipoCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdTipoCheque.Formato = ""
        Me.txtIdTipoCheque.IsDecimal = False
        Me.txtIdTipoCheque.IsNumber = False
        Me.txtIdTipoCheque.IsPK = True
        Me.txtIdTipoCheque.IsRequired = True
        Me.txtIdTipoCheque.Key = ""
        Me.txtIdTipoCheque.LabelAsoc = Me.lblCodigo
        Me.txtIdTipoCheque.Location = New System.Drawing.Point(98, 12)
        Me.txtIdTipoCheque.MaxLength = 10
        Me.txtIdTipoCheque.Name = "txtIdTipoCheque"
        Me.txtIdTipoCheque.Size = New System.Drawing.Size(54, 20)
        Me.txtIdTipoCheque.TabIndex = 1
        Me.txtIdTipoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtNombreTipoCheque
        '
        Me.txtNombreTipoCheque.BindearPropiedadControl = "Text"
        Me.txtNombreTipoCheque.BindearPropiedadEntidad = "NombreTipoCheque"
        Me.txtNombreTipoCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreTipoCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreTipoCheque.Formato = ""
        Me.txtNombreTipoCheque.IsDecimal = False
        Me.txtNombreTipoCheque.IsNumber = False
        Me.txtNombreTipoCheque.IsPK = False
        Me.txtNombreTipoCheque.IsRequired = True
        Me.txtNombreTipoCheque.Key = ""
        Me.txtNombreTipoCheque.LabelAsoc = Me.lblDescripcion
        Me.txtNombreTipoCheque.Location = New System.Drawing.Point(98, 51)
        Me.txtNombreTipoCheque.MaxLength = 20
        Me.txtNombreTipoCheque.Name = "txtNombreTipoCheque"
        Me.txtNombreTipoCheque.Size = New System.Drawing.Size(262, 20)
        Me.txtNombreTipoCheque.TabIndex = 3

        '
        'chbSolicitarNroOperacion
        '
        Me.chbSolicitarNroOperacion.AutoSize = True
        Me.chbSolicitarNroOperacion.BindearPropiedadControl = "Checked"
        Me.chbSolicitarNroOperacion.BindearPropiedadEntidad = "SolicitaNroOperacion"
        Me.chbSolicitarNroOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitarNroOperacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitarNroOperacion.IsPK = False
        Me.chbSolicitarNroOperacion.IsRequired = False
        Me.chbSolicitarNroOperacion.Key = Nothing
        Me.chbSolicitarNroOperacion.LabelAsoc = Nothing
        Me.chbSolicitarNroOperacion.Location = New System.Drawing.Point(24, 92)
        Me.chbSolicitarNroOperacion.Name = "chbSolicitarNroOperacion"
        Me.chbSolicitarNroOperacion.Size = New System.Drawing.Size(135, 17)
        Me.chbSolicitarNroOperacion.TabIndex = 4
        Me.chbSolicitarNroOperacion.Text = "Solicitar Nro Operación"
        Me.chbSolicitarNroOperacion.UseVisualStyleBackColor = True


        '
        'TiposChequesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 207)
        Me.Controls.Add(Me.chbSolicitarNroOperacion)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtNombreTipoCheque)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.txtIdTipoCheque)
        Me.Name = "TiposChequesDetalle"
        Me.Text = "Nuevo BaseDetalle"
        Me.Controls.SetChildIndex(Me.txtIdTipoCheque, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.txtNombreTipoCheque, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.chbSolicitarNroOperacion, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub '
    'TiposChequesDetalle
    '


    Friend WithEvents lblCodigo As Controles.Label
    Friend WithEvents txtIdTipoCheque As Controles.TextBox
    Friend WithEvents lblDescripcion As Controles.Label
    Friend WithEvents txtNombreTipoCheque As Controles.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chbSolicitarNroOperacion As Eniac.Controles.CheckBox

End Class
