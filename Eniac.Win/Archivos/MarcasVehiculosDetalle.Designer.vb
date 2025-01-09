<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MarcasVehiculosDetalle
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
        Me.lblNombreMarcaVehiculo = New Eniac.Controles.Label()
        Me.txtNombreMarcaVehiculo = New Eniac.Controles.TextBox()
        Me.lblIdMarcaVehiculo = New Eniac.Controles.Label()
        Me.txtIdMarcaVehiculo = New Eniac.Controles.TextBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(244, 94)
        Me.btnAceptar.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(330, 94)
        Me.btnCancelar.TabIndex = 5
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(143, 94)
        Me.btnCopiar.TabIndex = 7
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(86, 94)
        Me.btnAplicar.TabIndex = 6
        '
        'lblNombreMarcaVehiculo
        '
        Me.lblNombreMarcaVehiculo.AutoSize = True
        Me.lblNombreMarcaVehiculo.LabelAsoc = Nothing
        Me.lblNombreMarcaVehiculo.Location = New System.Drawing.Point(12, 47)
        Me.lblNombreMarcaVehiculo.Name = "lblNombreMarcaVehiculo"
        Me.lblNombreMarcaVehiculo.Size = New System.Drawing.Size(63, 13)
        Me.lblNombreMarcaVehiculo.TabIndex = 2
        Me.lblNombreMarcaVehiculo.Text = "Descripcion"
        '
        'txtNombreMarcaVehiculo
        '
        Me.txtNombreMarcaVehiculo.BindearPropiedadControl = "Text"
        Me.txtNombreMarcaVehiculo.BindearPropiedadEntidad = "NombreMarcaVehiculo"
        Me.txtNombreMarcaVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreMarcaVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreMarcaVehiculo.Formato = ""
        Me.txtNombreMarcaVehiculo.IsDecimal = False
        Me.txtNombreMarcaVehiculo.IsNumber = False
        Me.txtNombreMarcaVehiculo.IsPK = False
        Me.txtNombreMarcaVehiculo.IsRequired = True
        Me.txtNombreMarcaVehiculo.Key = ""
        Me.txtNombreMarcaVehiculo.LabelAsoc = Me.lblNombreMarcaVehiculo
        Me.txtNombreMarcaVehiculo.Location = New System.Drawing.Point(110, 44)
        Me.txtNombreMarcaVehiculo.MaxLength = 50
        Me.txtNombreMarcaVehiculo.Name = "txtNombreMarcaVehiculo"
        Me.txtNombreMarcaVehiculo.Size = New System.Drawing.Size(263, 20)
        Me.txtNombreMarcaVehiculo.TabIndex = 3
        '
        'lblIdMarcaVehiculo
        '
        Me.lblIdMarcaVehiculo.AutoSize = True
        Me.lblIdMarcaVehiculo.LabelAsoc = Nothing
        Me.lblIdMarcaVehiculo.Location = New System.Drawing.Point(12, 19)
        Me.lblIdMarcaVehiculo.Name = "lblIdMarcaVehiculo"
        Me.lblIdMarcaVehiculo.Size = New System.Drawing.Size(73, 13)
        Me.lblIdMarcaVehiculo.TabIndex = 0
        Me.lblIdMarcaVehiculo.Text = "Código Marca"
        '
        'txtIdMarcaVehiculo
        '
        Me.txtIdMarcaVehiculo.BindearPropiedadControl = "Text"
        Me.txtIdMarcaVehiculo.BindearPropiedadEntidad = "IdMarcaVehiculo"
        Me.txtIdMarcaVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdMarcaVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdMarcaVehiculo.Formato = ""
        Me.txtIdMarcaVehiculo.IsDecimal = False
        Me.txtIdMarcaVehiculo.IsNumber = False
        Me.txtIdMarcaVehiculo.IsPK = True
        Me.txtIdMarcaVehiculo.IsRequired = True
        Me.txtIdMarcaVehiculo.Key = ""
        Me.txtIdMarcaVehiculo.LabelAsoc = Me.lblIdMarcaVehiculo
        Me.txtIdMarcaVehiculo.Location = New System.Drawing.Point(110, 16)
        Me.txtIdMarcaVehiculo.MaxLength = 5
        Me.txtIdMarcaVehiculo.Name = "txtIdMarcaVehiculo"
        Me.txtIdMarcaVehiculo.Size = New System.Drawing.Size(59, 20)
        Me.txtIdMarcaVehiculo.TabIndex = 1
        '
        'MarcasVehiculosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 129)
        Me.Controls.Add(Me.lblNombreMarcaVehiculo)
        Me.Controls.Add(Me.txtNombreMarcaVehiculo)
        Me.Controls.Add(Me.lblIdMarcaVehiculo)
        Me.Controls.Add(Me.txtIdMarcaVehiculo)
        Me.Name = "MarcasVehiculosDetalle"
        Me.Text = "Marcas Vehiculos"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtIdMarcaVehiculo, 0)
        Me.Controls.SetChildIndex(Me.lblIdMarcaVehiculo, 0)
        Me.Controls.SetChildIndex(Me.txtNombreMarcaVehiculo, 0)
        Me.Controls.SetChildIndex(Me.lblNombreMarcaVehiculo, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreMarcaVehiculo As Controles.Label
    Friend WithEvents txtNombreMarcaVehiculo As Controles.TextBox
    Friend WithEvents lblIdMarcaVehiculo As Controles.Label
    Friend WithEvents txtIdMarcaVehiculo As Controles.TextBox
End Class
