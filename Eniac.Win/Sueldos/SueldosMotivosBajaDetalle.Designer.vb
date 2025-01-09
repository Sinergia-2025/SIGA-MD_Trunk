<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosMotivosBajaDetalle
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
      Me.txtNombreMotivoBaja = New Eniac.Controles.TextBox
      Me.lblNombre = New Eniac.Controles.Label
      Me.txtIdMotivoBaja = New Eniac.Controles.TextBox
      Me.lblCodigo = New Eniac.Controles.Label
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(197, 94)
      Me.btnAceptar.TabIndex = 2
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(283, 94)
      Me.btnCancelar.TabIndex = 3
      '
      'txtNombreMotivoBaja
      '
      Me.txtNombreMotivoBaja.BindearPropiedadControl = "Text"
      Me.txtNombreMotivoBaja.BindearPropiedadEntidad = "NombreMotivoBaja"
      Me.txtNombreMotivoBaja.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreMotivoBaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreMotivoBaja.Formato = ""
      Me.txtNombreMotivoBaja.IsDecimal = False
      Me.txtNombreMotivoBaja.IsNumber = False
      Me.txtNombreMotivoBaja.IsPK = False
      Me.txtNombreMotivoBaja.IsRequired = True
      Me.txtNombreMotivoBaja.Key = ""
      Me.txtNombreMotivoBaja.LabelAsoc = Me.lblNombre
      Me.txtNombreMotivoBaja.Location = New System.Drawing.Point(66, 45)
      Me.txtNombreMotivoBaja.MaxLength = 50
      Me.txtNombreMotivoBaja.Name = "txtNombreMotivoBaja"
      Me.txtNombreMotivoBaja.Size = New System.Drawing.Size(285, 20)
      Me.txtNombreMotivoBaja.TabIndex = 1
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(9, 52)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 5
      Me.lblNombre.Text = "Nombre"
      '
      'txtIdMotivoBaja
      '
      Me.txtIdMotivoBaja.BindearPropiedadControl = "Text"
      Me.txtIdMotivoBaja.BindearPropiedadEntidad = "IdMotivoBaja"
      Me.txtIdMotivoBaja.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdMotivoBaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdMotivoBaja.Formato = ""
      Me.txtIdMotivoBaja.IsDecimal = False
      Me.txtIdMotivoBaja.IsNumber = True
      Me.txtIdMotivoBaja.IsPK = True
      Me.txtIdMotivoBaja.IsRequired = True
      Me.txtIdMotivoBaja.Key = ""
      Me.txtIdMotivoBaja.LabelAsoc = Me.lblCodigo
      Me.txtIdMotivoBaja.Location = New System.Drawing.Point(66, 19)
      Me.txtIdMotivoBaja.MaxLength = 9
      Me.txtIdMotivoBaja.Name = "txtIdMotivoBaja"
      Me.txtIdMotivoBaja.Size = New System.Drawing.Size(101, 20)
      Me.txtIdMotivoBaja.TabIndex = 0
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(9, 26)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 4
      Me.lblCodigo.Text = "Código"
      '
      'SueldosMotivosBajaDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(372, 129)
      Me.Controls.Add(Me.txtNombreMotivoBaja)
      Me.Controls.Add(Me.txtIdMotivoBaja)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Name = "SueldosMotivosBajaDetalle"
      Me.Text = "Motivo de Baja"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtIdMotivoBaja, 0)
      Me.Controls.SetChildIndex(Me.txtNombreMotivoBaja, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtNombreMotivoBaja As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtIdMotivoBaja As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
End Class
