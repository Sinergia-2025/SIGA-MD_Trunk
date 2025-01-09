<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZonasGeograficasDetalle
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
        Me.txtNombreZonaGeografica = New Eniac.Controles.TextBox()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtIdZonaGeografica = New Eniac.Controles.TextBox()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(193, 97)
        Me.btnAceptar.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(279, 97)
        Me.btnCancelar.TabIndex = 5
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(95, 97)
        Me.btnCopiar.TabIndex = 7
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(38, 97)
        Me.btnAplicar.TabIndex = 6
        '
        'txtNombreZonaGeografica
        '
        Me.txtNombreZonaGeografica.BindearPropiedadControl = "Text"
        Me.txtNombreZonaGeografica.BindearPropiedadEntidad = "NombreZonaGeografica"
        Me.txtNombreZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreZonaGeografica.Formato = ""
        Me.txtNombreZonaGeografica.IsDecimal = False
        Me.txtNombreZonaGeografica.IsNumber = False
        Me.txtNombreZonaGeografica.IsPK = False
        Me.txtNombreZonaGeografica.IsRequired = True
        Me.txtNombreZonaGeografica.Key = ""
        Me.txtNombreZonaGeografica.LabelAsoc = Me.lblNombre
        Me.txtNombreZonaGeografica.Location = New System.Drawing.Point(74, 49)
        Me.txtNombreZonaGeografica.MaxLength = 40
        Me.txtNombreZonaGeografica.Name = "txtNombreZonaGeografica"
        Me.txtNombreZonaGeografica.Size = New System.Drawing.Size(285, 20)
        Me.txtNombreZonaGeografica.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(17, 53)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtIdZonaGeografica
        '
        Me.txtIdZonaGeografica.BindearPropiedadControl = "Text"
        Me.txtIdZonaGeografica.BindearPropiedadEntidad = "IdZonaGeografica"
        Me.txtIdZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdZonaGeografica.Formato = ""
        Me.txtIdZonaGeografica.IsDecimal = False
        Me.txtIdZonaGeografica.IsNumber = False
        Me.txtIdZonaGeografica.IsPK = True
        Me.txtIdZonaGeografica.IsRequired = True
        Me.txtIdZonaGeografica.Key = ""
        Me.txtIdZonaGeografica.LabelAsoc = Me.lblCodigo
        Me.txtIdZonaGeografica.Location = New System.Drawing.Point(74, 23)
        Me.txtIdZonaGeografica.MaxLength = 10
        Me.txtIdZonaGeografica.Name = "txtIdZonaGeografica"
        Me.txtIdZonaGeografica.Size = New System.Drawing.Size(120, 20)
        Me.txtIdZonaGeografica.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(17, 27)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código"
        '
        'ZonasGeograficasDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 139)
        Me.Controls.Add(Me.txtNombreZonaGeografica)
        Me.Controls.Add(Me.txtIdZonaGeografica)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblCodigo)
        Me.Name = "ZonasGeograficasDetalle"
        Me.Text = "Zona Geográfica"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtIdZonaGeografica, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.txtNombreZonaGeografica, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreZonaGeografica As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtIdZonaGeografica As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
End Class
