<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosLugaresActividadDetalle
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
      Me.txtNombreLugarActividad = New Eniac.Controles.TextBox
      Me.lblNombre = New Eniac.Controles.Label
      Me.txtIdLugarActvidad = New Eniac.Controles.TextBox
      Me.lblCodigo = New Eniac.Controles.Label
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(191, 73)
      Me.btnAceptar.TabIndex = 2
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(277, 73)
      Me.btnCancelar.TabIndex = 3
      '
      'txtNombreLugarActividad
      '
      Me.txtNombreLugarActividad.BindearPropiedadControl = "Text"
      Me.txtNombreLugarActividad.BindearPropiedadEntidad = "NombreLugarActividad"
      Me.txtNombreLugarActividad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreLugarActividad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreLugarActividad.Formato = ""
      Me.txtNombreLugarActividad.IsDecimal = False
      Me.txtNombreLugarActividad.IsNumber = False
      Me.txtNombreLugarActividad.IsPK = False
      Me.txtNombreLugarActividad.IsRequired = True
      Me.txtNombreLugarActividad.Key = ""
      Me.txtNombreLugarActividad.LabelAsoc = Me.lblNombre
      Me.txtNombreLugarActividad.Location = New System.Drawing.Point(72, 38)
      Me.txtNombreLugarActividad.MaxLength = 50
      Me.txtNombreLugarActividad.Name = "txtNombreLugarActividad"
      Me.txtNombreLugarActividad.Size = New System.Drawing.Size(285, 20)
      Me.txtNombreLugarActividad.TabIndex = 1
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(15, 45)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 5
      Me.lblNombre.Text = "Nombre"
      '
      'txtIdLugarActvidad
      '
      Me.txtIdLugarActvidad.BindearPropiedadControl = "Text"
      Me.txtIdLugarActvidad.BindearPropiedadEntidad = "IdLugarActividad"
      Me.txtIdLugarActvidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdLugarActvidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdLugarActvidad.Formato = ""
      Me.txtIdLugarActvidad.IsDecimal = False
      Me.txtIdLugarActvidad.IsNumber = True
      Me.txtIdLugarActvidad.IsPK = True
      Me.txtIdLugarActvidad.IsRequired = True
      Me.txtIdLugarActvidad.Key = ""
      Me.txtIdLugarActvidad.LabelAsoc = Me.lblCodigo
      Me.txtIdLugarActvidad.Location = New System.Drawing.Point(72, 12)
      Me.txtIdLugarActvidad.MaxLength = 9
      Me.txtIdLugarActvidad.Name = "txtIdLugarActvidad"
      Me.txtIdLugarActvidad.Size = New System.Drawing.Size(101, 20)
      Me.txtIdLugarActvidad.TabIndex = 0
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(15, 19)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 4
      Me.lblCodigo.Text = "Código"
      '
      'SueldosLugaresActividadDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(366, 108)
      Me.Controls.Add(Me.txtNombreLugarActividad)
      Me.Controls.Add(Me.txtIdLugarActvidad)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Name = "SueldosLugaresActividadDetalle"
      Me.Text = "Lugar de Actividad"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtIdLugarActvidad, 0)
      Me.Controls.SetChildIndex(Me.txtNombreLugarActividad, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtNombreLugarActividad As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtIdLugarActvidad As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
End Class
