<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentasBancariasClaseDetalle
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
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtIdCuentaBancariaClase = New Eniac.Controles.TextBox()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNombreCuentaBancariaClase = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(225, 97)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(311, 97)
      Me.btnCancelar.TabIndex = 5
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(124, 97)
      Me.btnCopiar.TabIndex = 6
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(67, 97)
      Me.btnAplicar.TabIndex = 7
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
      'txtIdCuentaBancariaClase
      '
      Me.txtIdCuentaBancariaClase.BindearPropiedadControl = "Text"
      Me.txtIdCuentaBancariaClase.BindearPropiedadEntidad = "IdCuentaBancariaClase"
      Me.txtIdCuentaBancariaClase.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdCuentaBancariaClase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdCuentaBancariaClase.Formato = ""
      Me.txtIdCuentaBancariaClase.IsDecimal = False
      Me.txtIdCuentaBancariaClase.IsNumber = True
      Me.txtIdCuentaBancariaClase.IsPK = True
      Me.txtIdCuentaBancariaClase.IsRequired = True
      Me.txtIdCuentaBancariaClase.Key = ""
      Me.txtIdCuentaBancariaClase.LabelAsoc = Me.lblCodigo
      Me.txtIdCuentaBancariaClase.Location = New System.Drawing.Point(98, 12)
      Me.txtIdCuentaBancariaClase.MaxLength = 10
      Me.txtIdCuentaBancariaClase.Name = "txtIdCuentaBancariaClase"
      Me.txtIdCuentaBancariaClase.Size = New System.Drawing.Size(54, 20)
      Me.txtIdCuentaBancariaClase.TabIndex = 1
      Me.txtIdCuentaBancariaClase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      'txtNombreCuentaBancariaClase
      '
      Me.txtNombreCuentaBancariaClase.BindearPropiedadControl = "Text"
      Me.txtNombreCuentaBancariaClase.BindearPropiedadEntidad = "NombreCuentaBancariaClase"
      Me.txtNombreCuentaBancariaClase.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCuentaBancariaClase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCuentaBancariaClase.Formato = ""
      Me.txtNombreCuentaBancariaClase.IsDecimal = False
      Me.txtNombreCuentaBancariaClase.IsNumber = False
      Me.txtNombreCuentaBancariaClase.IsPK = False
      Me.txtNombreCuentaBancariaClase.IsRequired = True
      Me.txtNombreCuentaBancariaClase.Key = ""
      Me.txtNombreCuentaBancariaClase.LabelAsoc = Me.lblDescripcion
      Me.txtNombreCuentaBancariaClase.Location = New System.Drawing.Point(98, 51)
      Me.txtNombreCuentaBancariaClase.MaxLength = 20
      Me.txtNombreCuentaBancariaClase.Name = "txtNombreCuentaBancariaClase"
      Me.txtNombreCuentaBancariaClase.Size = New System.Drawing.Size(262, 20)
      Me.txtNombreCuentaBancariaClase.TabIndex = 3
      '
      'CuentasBancariasClaseDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(438, 139)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombreCuentaBancariaClase)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtIdCuentaBancariaClase)
      Me.Name = "CuentasBancariasClaseDetalle"
      Me.Text = "Clase de Cuentas Bancarias "
      Me.Controls.SetChildIndex(Me.txtIdCuentaBancariaClase, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtNombreCuentaBancariaClase, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

    Friend WithEvents lblCodigo As Controles.Label
    Friend WithEvents txtIdCuentaBancariaClase As Controles.TextBox
    Friend WithEvents lblDescripcion As Controles.Label
    Friend WithEvents txtNombreCuentaBancariaClase As Controles.TextBox

End Class
