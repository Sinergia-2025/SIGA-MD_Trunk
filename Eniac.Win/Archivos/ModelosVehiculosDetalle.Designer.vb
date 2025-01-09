<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModelosVehiculosDetalle
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
        Me.lblIdMarcaVehiculo = New Eniac.Controles.Label()
        Me.lblidModeloVehiculo = New Eniac.Controles.Label()
        Me.lblNombreLocalidad = New Eniac.Controles.Label()
        Me.txtNombreModeloVehiculo = New Eniac.Controles.TextBox()
        Me.txtIdModelosVehiculos = New Eniac.Controles.TextBox()
        Me.cmbNombreMarca = New Eniac.Controles.ComboBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(231, 137)
        Me.btnAceptar.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(317, 137)
        Me.btnCancelar.TabIndex = 7
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(130, 137)
        Me.btnCopiar.TabIndex = 9
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(73, 137)
        Me.btnAplicar.TabIndex = 8
        '
        'lblIdMarcaVehiculo
        '
        Me.lblIdMarcaVehiculo.AutoSize = True
        Me.lblIdMarcaVehiculo.LabelAsoc = Nothing
        Me.lblIdMarcaVehiculo.Location = New System.Drawing.Point(20, 88)
        Me.lblIdMarcaVehiculo.Name = "lblIdMarcaVehiculo"
        Me.lblIdMarcaVehiculo.Size = New System.Drawing.Size(37, 13)
        Me.lblIdMarcaVehiculo.TabIndex = 4
        Me.lblIdMarcaVehiculo.Text = "Marca"
        '
        'lblidModeloVehiculo
        '
        Me.lblidModeloVehiculo.AutoSize = True
        Me.lblidModeloVehiculo.LabelAsoc = Nothing
        Me.lblidModeloVehiculo.Location = New System.Drawing.Point(20, 28)
        Me.lblidModeloVehiculo.Name = "lblidModeloVehiculo"
        Me.lblidModeloVehiculo.Size = New System.Drawing.Size(78, 13)
        Me.lblidModeloVehiculo.TabIndex = 0
        Me.lblidModeloVehiculo.Text = "Código Modelo"
        '
        'lblNombreLocalidad
        '
        Me.lblNombreLocalidad.AutoSize = True
        Me.lblNombreLocalidad.LabelAsoc = Nothing
        Me.lblNombreLocalidad.Location = New System.Drawing.Point(20, 56)
        Me.lblNombreLocalidad.Name = "lblNombreLocalidad"
        Me.lblNombreLocalidad.Size = New System.Drawing.Size(63, 13)
        Me.lblNombreLocalidad.TabIndex = 2
        Me.lblNombreLocalidad.Text = "Descripcion"
        '
        'txtNombreModeloVehiculo
        '
        Me.txtNombreModeloVehiculo.BindearPropiedadControl = "Text"
        Me.txtNombreModeloVehiculo.BindearPropiedadEntidad = "NombreModeloVehiculo"
        Me.txtNombreModeloVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreModeloVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreModeloVehiculo.Formato = ""
        Me.txtNombreModeloVehiculo.IsDecimal = False
        Me.txtNombreModeloVehiculo.IsNumber = False
        Me.txtNombreModeloVehiculo.IsPK = False
        Me.txtNombreModeloVehiculo.IsRequired = True
        Me.txtNombreModeloVehiculo.Key = ""
        Me.txtNombreModeloVehiculo.LabelAsoc = Me.lblNombreLocalidad
        Me.txtNombreModeloVehiculo.Location = New System.Drawing.Point(118, 53)
        Me.txtNombreModeloVehiculo.MaxLength = 50
        Me.txtNombreModeloVehiculo.Name = "txtNombreModeloVehiculo"
        Me.txtNombreModeloVehiculo.Size = New System.Drawing.Size(263, 20)
        Me.txtNombreModeloVehiculo.TabIndex = 3
        '
        'txtIdModelosVehiculos
        '
        Me.txtIdModelosVehiculos.BindearPropiedadControl = "Text"
        Me.txtIdModelosVehiculos.BindearPropiedadEntidad = "IdModeloVehiculo"
        Me.txtIdModelosVehiculos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdModelosVehiculos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdModelosVehiculos.Formato = ""
        Me.txtIdModelosVehiculos.IsDecimal = False
        Me.txtIdModelosVehiculos.IsNumber = False
        Me.txtIdModelosVehiculos.IsPK = True
        Me.txtIdModelosVehiculos.IsRequired = True
        Me.txtIdModelosVehiculos.Key = ""
        Me.txtIdModelosVehiculos.LabelAsoc = Me.lblidModeloVehiculo
        Me.txtIdModelosVehiculos.Location = New System.Drawing.Point(118, 25)
        Me.txtIdModelosVehiculos.MaxLength = 5
        Me.txtIdModelosVehiculos.Name = "txtIdModelosVehiculos"
        Me.txtIdModelosVehiculos.Size = New System.Drawing.Size(80, 20)
        Me.txtIdModelosVehiculos.TabIndex = 1
        '
        'cmbNombreMarca
        '
        Me.cmbNombreMarca.BindearPropiedadControl = "SelectedValue"
        Me.cmbNombreMarca.BindearPropiedadEntidad = "IdMarcaVehiculo"
        Me.cmbNombreMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNombreMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbNombreMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbNombreMarca.FormattingEnabled = True
        Me.cmbNombreMarca.IsPK = False
        Me.cmbNombreMarca.IsRequired = True
        Me.cmbNombreMarca.Key = Nothing
        Me.cmbNombreMarca.LabelAsoc = Nothing
        Me.cmbNombreMarca.Location = New System.Drawing.Point(118, 85)
        Me.cmbNombreMarca.Name = "cmbNombreMarca"
        Me.cmbNombreMarca.Size = New System.Drawing.Size(211, 21)
        Me.cmbNombreMarca.TabIndex = 5
        '
        'ModelosVehiculosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 172)
        Me.Controls.Add(Me.cmbNombreMarca)
        Me.Controls.Add(Me.lblIdMarcaVehiculo)
        Me.Controls.Add(Me.lblNombreLocalidad)
        Me.Controls.Add(Me.txtNombreModeloVehiculo)
        Me.Controls.Add(Me.lblidModeloVehiculo)
        Me.Controls.Add(Me.txtIdModelosVehiculos)
        Me.Name = "ModelosVehiculosDetalle"
        Me.Text = "Modelos Vehiculos"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtIdModelosVehiculos, 0)
        Me.Controls.SetChildIndex(Me.lblidModeloVehiculo, 0)
        Me.Controls.SetChildIndex(Me.txtNombreModeloVehiculo, 0)
        Me.Controls.SetChildIndex(Me.lblNombreLocalidad, 0)
        Me.Controls.SetChildIndex(Me.lblIdMarcaVehiculo, 0)
        Me.Controls.SetChildIndex(Me.cmbNombreMarca, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblIdMarcaVehiculo As Controles.Label
    Friend WithEvents lblidModeloVehiculo As Controles.Label
    Friend WithEvents lblNombreLocalidad As Controles.Label
    Friend WithEvents txtNombreModeloVehiculo As Controles.TextBox
    Friend WithEvents txtIdModelosVehiculos As Controles.TextBox
    Friend WithEvents cmbNombreMarca As Controles.ComboBox
End Class
