<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CalidadListasControlTiposDetalle
    Inherits BaseDetalle

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblNombreTipoCliente = New Eniac.Controles.Label()
        Me.txtNombreTipoListaControl = New Eniac.Controles.TextBox()
        Me.lblIdTipoCliente = New Eniac.Controles.Label()
        Me.txtIdTipoListaControl = New Eniac.Controles.TextBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(243, 104)
        Me.btnAceptar.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(329, 104)
        Me.btnCancelar.TabIndex = 5
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(142, 104)
        Me.btnCopiar.TabIndex = 7
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(85, 104)
        Me.btnAplicar.TabIndex = 6
        '
        'lblNombreTipoCliente
        '
        Me.lblNombreTipoCliente.AutoSize = True
        Me.lblNombreTipoCliente.LabelAsoc = Nothing
        Me.lblNombreTipoCliente.Location = New System.Drawing.Point(18, 47)
        Me.lblNombreTipoCliente.Name = "lblNombreTipoCliente"
        Me.lblNombreTipoCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreTipoCliente.TabIndex = 2
        Me.lblNombreTipoCliente.Text = "Nombre"
        '
        'txtNombreTipoListaControl
        '
        Me.txtNombreTipoListaControl.BindearPropiedadControl = "Text"
        Me.txtNombreTipoListaControl.BindearPropiedadEntidad = "NombreListaControlTipo"
        Me.txtNombreTipoListaControl.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreTipoListaControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreTipoListaControl.Formato = ""
        Me.txtNombreTipoListaControl.IsDecimal = False
        Me.txtNombreTipoListaControl.IsNumber = False
        Me.txtNombreTipoListaControl.IsPK = False
        Me.txtNombreTipoListaControl.IsRequired = True
        Me.txtNombreTipoListaControl.Key = ""
        Me.txtNombreTipoListaControl.LabelAsoc = Me.lblNombreTipoCliente
        Me.txtNombreTipoListaControl.Location = New System.Drawing.Point(97, 44)
        Me.txtNombreTipoListaControl.MaxLength = 30
        Me.txtNombreTipoListaControl.Name = "txtNombreTipoListaControl"
        Me.txtNombreTipoListaControl.Size = New System.Drawing.Size(309, 20)
        Me.txtNombreTipoListaControl.TabIndex = 3
        '
        'lblIdTipoCliente
        '
        Me.lblIdTipoCliente.AutoSize = True
        Me.lblIdTipoCliente.LabelAsoc = Nothing
        Me.lblIdTipoCliente.Location = New System.Drawing.Point(18, 19)
        Me.lblIdTipoCliente.Name = "lblIdTipoCliente"
        Me.lblIdTipoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblIdTipoCliente.TabIndex = 0
        Me.lblIdTipoCliente.Text = "Código"
        '
        'txtIdTipoListaControl
        '
        Me.txtIdTipoListaControl.BindearPropiedadControl = "Text"
        Me.txtIdTipoListaControl.BindearPropiedadEntidad = "IdListaControlTipo"
        Me.txtIdTipoListaControl.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdTipoListaControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdTipoListaControl.Formato = ""
        Me.txtIdTipoListaControl.IsDecimal = False
        Me.txtIdTipoListaControl.IsNumber = True
        Me.txtIdTipoListaControl.IsPK = True
        Me.txtIdTipoListaControl.IsRequired = True
        Me.txtIdTipoListaControl.Key = ""
        Me.txtIdTipoListaControl.LabelAsoc = Me.lblIdTipoCliente
        Me.txtIdTipoListaControl.Location = New System.Drawing.Point(97, 16)
        Me.txtIdTipoListaControl.MaxLength = 9
        Me.txtIdTipoListaControl.Name = "txtIdTipoListaControl"
        Me.txtIdTipoListaControl.Size = New System.Drawing.Size(51, 20)
        Me.txtIdTipoListaControl.TabIndex = 1
        Me.txtIdTipoListaControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CalidadListasControlTiposDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 139)
        Me.Controls.Add(Me.lblNombreTipoCliente)
        Me.Controls.Add(Me.txtNombreTipoListaControl)
        Me.Controls.Add(Me.lblIdTipoCliente)
        Me.Controls.Add(Me.txtIdTipoListaControl)
        Me.Name = "CalidadListasControlTiposDetalle"
        Me.Text = "Tipo de Listas de Control"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtIdTipoListaControl, 0)
        Me.Controls.SetChildIndex(Me.lblIdTipoCliente, 0)
        Me.Controls.SetChildIndex(Me.txtNombreTipoListaControl, 0)
        Me.Controls.SetChildIndex(Me.lblNombreTipoCliente, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombreTipoCliente As Eniac.Controles.Label
    Friend WithEvents txtNombreTipoListaControl As Eniac.Controles.TextBox
    Friend WithEvents lblIdTipoCliente As Eniac.Controles.Label
    Friend WithEvents txtIdTipoListaControl As Eniac.Controles.TextBox
End Class
