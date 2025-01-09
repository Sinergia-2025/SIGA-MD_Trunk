<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosCategoriasDetalle
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
      Me.txtNombreCategoria = New Eniac.Controles.TextBox
      Me.lblNombre = New Eniac.Controles.Label
      Me.txtIdCategoria = New Eniac.Controles.TextBox
      Me.lblCodigo = New Eniac.Controles.Label
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(193, 97)
      Me.btnAceptar.TabIndex = 2
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(279, 97)
      Me.btnCancelar.TabIndex = 3
      '
      'txtNombreCategoria
      '
      Me.txtNombreCategoria.BindearPropiedadControl = "Text"
      Me.txtNombreCategoria.BindearPropiedadEntidad = "NombreCategoria"
      Me.txtNombreCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCategoria.Formato = ""
      Me.txtNombreCategoria.IsDecimal = False
      Me.txtNombreCategoria.IsNumber = False
      Me.txtNombreCategoria.IsPK = False
      Me.txtNombreCategoria.IsRequired = True
      Me.txtNombreCategoria.Key = ""
      Me.txtNombreCategoria.LabelAsoc = Me.lblNombre
      Me.txtNombreCategoria.Location = New System.Drawing.Point(74, 49)
      Me.txtNombreCategoria.MaxLength = 40
      Me.txtNombreCategoria.Name = "txtNombreCategoria"
      Me.txtNombreCategoria.Size = New System.Drawing.Size(285, 20)
      Me.txtNombreCategoria.TabIndex = 1
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(17, 53)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 5
      Me.lblNombre.Text = "Nombre"
      '
      'txtIdCategoria
      '
      Me.txtIdCategoria.BindearPropiedadControl = "Text"
      Me.txtIdCategoria.BindearPropiedadEntidad = "IdCategoria"
      Me.txtIdCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdCategoria.Formato = ""
      Me.txtIdCategoria.IsDecimal = False
      Me.txtIdCategoria.IsNumber = True
      Me.txtIdCategoria.IsPK = True
      Me.txtIdCategoria.IsRequired = True
      Me.txtIdCategoria.Key = ""
      Me.txtIdCategoria.LabelAsoc = Me.lblCodigo
      Me.txtIdCategoria.Location = New System.Drawing.Point(74, 23)
      Me.txtIdCategoria.MaxLength = 10
      Me.txtIdCategoria.Name = "txtIdCategoria"
      Me.txtIdCategoria.Size = New System.Drawing.Size(120, 20)
      Me.txtIdCategoria.TabIndex = 0
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(17, 27)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(54, 13)
      Me.lblCodigo.TabIndex = 4
      Me.lblCodigo.Text = "Categoría"
      '
      'SueldosCategoriasDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(371, 139)
      Me.Controls.Add(Me.txtNombreCategoria)
      Me.Controls.Add(Me.txtIdCategoria)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Name = "SueldosCategoriasDetalle"
      Me.Text = "Categoría de Personal"
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtIdCategoria, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreCategoria, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Friend WithEvents txtNombreCategoria As Eniac.Controles.TextBox
    Friend WithEvents lblNombre As Eniac.Controles.Label
    Friend WithEvents txtIdCategoria As Eniac.Controles.TextBox
    Friend WithEvents lblCodigo As Eniac.Controles.Label
End Class
