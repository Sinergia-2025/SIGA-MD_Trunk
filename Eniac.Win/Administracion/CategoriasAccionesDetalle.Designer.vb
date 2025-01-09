<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoriasAccionesDetalle
   Inherits BaseDetalle

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.txtCoeficienteDistribucionExpensas = New Eniac.Controles.TextBox()
      Me.lblCoeficienteDistribucionExpensas = New Eniac.Controles.Label()
      Me.lblPies = New Eniac.Controles.Label()
      Me.txtPies = New Eniac.Controles.TextBox()
      Me.lblNombreCategoriaAccion = New Eniac.Controles.Label()
      Me.txtNombreCategoriaAccion = New Eniac.Controles.TextBox()
      Me.lblIdCategoriaAccion = New Eniac.Controles.Label()
      Me.txtIdCategoriaAccion = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(290, 122)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(383, 122)
      Me.btnCancelar.TabIndex = 9
      '
      'txtCoeficienteDistribucionExpensas
      '
      Me.txtCoeficienteDistribucionExpensas.BindearPropiedadControl = "Text"
      Me.txtCoeficienteDistribucionExpensas.BindearPropiedadEntidad = "CoeficienteDistribucionExpensas"
      Me.txtCoeficienteDistribucionExpensas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCoeficienteDistribucionExpensas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCoeficienteDistribucionExpensas.Formato = "N5"
      Me.txtCoeficienteDistribucionExpensas.IsDecimal = True
      Me.txtCoeficienteDistribucionExpensas.IsNumber = True
      Me.txtCoeficienteDistribucionExpensas.IsPK = False
      Me.txtCoeficienteDistribucionExpensas.IsRequired = True
      Me.txtCoeficienteDistribucionExpensas.Key = ""
      Me.txtCoeficienteDistribucionExpensas.LabelAsoc = Me.lblCoeficienteDistribucionExpensas
      Me.txtCoeficienteDistribucionExpensas.Location = New System.Drawing.Point(161, 91)
      Me.txtCoeficienteDistribucionExpensas.MaxLength = 8
      Me.txtCoeficienteDistribucionExpensas.Name = "txtCoeficienteDistribucionExpensas"
      Me.txtCoeficienteDistribucionExpensas.Size = New System.Drawing.Size(70, 20)
      Me.txtCoeficienteDistribucionExpensas.TabIndex = 7
      Me.txtCoeficienteDistribucionExpensas.Text = "1.00000"
      Me.txtCoeficienteDistribucionExpensas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCoeficienteDistribucionExpensas
      '
      Me.lblCoeficienteDistribucionExpensas.AutoSize = True
      Me.lblCoeficienteDistribucionExpensas.Location = New System.Drawing.Point(19, 94)
      Me.lblCoeficienteDistribucionExpensas.Name = "lblCoeficienteDistribucionExpensas"
      Me.lblCoeficienteDistribucionExpensas.Size = New System.Drawing.Size(136, 13)
      Me.lblCoeficienteDistribucionExpensas.TabIndex = 6
      Me.lblCoeficienteDistribucionExpensas.Text = "Coeficiente Distr. Expensas"
      '
      'lblPies
      '
      Me.lblPies.AutoSize = True
      Me.lblPies.Location = New System.Drawing.Point(19, 68)
      Me.lblPies.Name = "lblPies"
      Me.lblPies.Size = New System.Drawing.Size(27, 13)
      Me.lblPies.TabIndex = 4
      Me.lblPies.Text = "Pies"
      '
      'txtPies
      '
      Me.txtPies.BindearPropiedadControl = "Text"
      Me.txtPies.BindearPropiedadEntidad = "Pies"
      Me.txtPies.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPies.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPies.Formato = "N"
      Me.txtPies.IsDecimal = False
      Me.txtPies.IsNumber = True
      Me.txtPies.IsPK = False
      Me.txtPies.IsRequired = True
      Me.txtPies.Key = ""
      Me.txtPies.LabelAsoc = Me.lblPies
      Me.txtPies.Location = New System.Drawing.Point(161, 65)
      Me.txtPies.MaxLength = 30
      Me.txtPies.Name = "txtPies"
      Me.txtPies.Size = New System.Drawing.Size(42, 20)
      Me.txtPies.TabIndex = 5
      Me.txtPies.Text = "0"
      Me.txtPies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNombreCategoriaAccion
      '
      Me.lblNombreCategoriaAccion.AutoSize = True
      Me.lblNombreCategoriaAccion.Location = New System.Drawing.Point(19, 42)
      Me.lblNombreCategoriaAccion.Name = "lblNombreCategoriaAccion"
      Me.lblNombreCategoriaAccion.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreCategoriaAccion.TabIndex = 2
      Me.lblNombreCategoriaAccion.Text = "Nombre"
      '
      'txtNombreCategoriaAccion
      '
      Me.txtNombreCategoriaAccion.BindearPropiedadControl = "Text"
      Me.txtNombreCategoriaAccion.BindearPropiedadEntidad = "NombreCategoriaAccion"
      Me.txtNombreCategoriaAccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCategoriaAccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCategoriaAccion.Formato = ""
      Me.txtNombreCategoriaAccion.IsDecimal = False
      Me.txtNombreCategoriaAccion.IsNumber = False
      Me.txtNombreCategoriaAccion.IsPK = False
      Me.txtNombreCategoriaAccion.IsRequired = True
      Me.txtNombreCategoriaAccion.Key = ""
      Me.txtNombreCategoriaAccion.LabelAsoc = Me.lblNombreCategoriaAccion
      Me.txtNombreCategoriaAccion.Location = New System.Drawing.Point(161, 39)
      Me.txtNombreCategoriaAccion.MaxLength = 30
      Me.txtNombreCategoriaAccion.Name = "txtNombreCategoriaAccion"
      Me.txtNombreCategoriaAccion.Size = New System.Drawing.Size(312, 20)
      Me.txtNombreCategoriaAccion.TabIndex = 3
      '
      'lblIdCategoriaAccion
      '
      Me.lblIdCategoriaAccion.AutoSize = True
      Me.lblIdCategoriaAccion.Location = New System.Drawing.Point(19, 16)
      Me.lblIdCategoriaAccion.Name = "lblIdCategoriaAccion"
      Me.lblIdCategoriaAccion.Size = New System.Drawing.Size(40, 13)
      Me.lblIdCategoriaAccion.TabIndex = 0
      Me.lblIdCategoriaAccion.Text = "Código"
      '
      'txtIdCategoriaAccion
      '
      Me.txtIdCategoriaAccion.BindearPropiedadControl = "Text"
      Me.txtIdCategoriaAccion.BindearPropiedadEntidad = "IdCategoriaAccion"
      Me.txtIdCategoriaAccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdCategoriaAccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdCategoriaAccion.Formato = ""
      Me.txtIdCategoriaAccion.IsDecimal = False
      Me.txtIdCategoriaAccion.IsNumber = True
      Me.txtIdCategoriaAccion.IsPK = True
      Me.txtIdCategoriaAccion.IsRequired = True
      Me.txtIdCategoriaAccion.Key = ""
      Me.txtIdCategoriaAccion.LabelAsoc = Me.lblIdCategoriaAccion
      Me.txtIdCategoriaAccion.Location = New System.Drawing.Point(161, 13)
      Me.txtIdCategoriaAccion.MaxLength = 4
      Me.txtIdCategoriaAccion.Name = "txtIdCategoriaAccion"
      Me.txtIdCategoriaAccion.Size = New System.Drawing.Size(42, 20)
      Me.txtIdCategoriaAccion.TabIndex = 1
      Me.txtIdCategoriaAccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'CategoriasAccionesDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(475, 158)
      Me.Controls.Add(Me.txtCoeficienteDistribucionExpensas)
      Me.Controls.Add(Me.lblCoeficienteDistribucionExpensas)
      Me.Controls.Add(Me.lblPies)
      Me.Controls.Add(Me.txtPies)
      Me.Controls.Add(Me.lblNombreCategoriaAccion)
      Me.Controls.Add(Me.txtNombreCategoriaAccion)
      Me.Controls.Add(Me.lblIdCategoriaAccion)
      Me.Controls.Add(Me.txtIdCategoriaAccion)
      Me.Name = "CategoriasAccionesDetalle"
      Me.Text = "Categoria de Acciones"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdCategoriaAccion, 0)
      Me.Controls.SetChildIndex(Me.lblIdCategoriaAccion, 0)
      Me.Controls.SetChildIndex(Me.txtNombreCategoriaAccion, 0)
      Me.Controls.SetChildIndex(Me.lblNombreCategoriaAccion, 0)
      Me.Controls.SetChildIndex(Me.txtPies, 0)
      Me.Controls.SetChildIndex(Me.lblPies, 0)
      Me.Controls.SetChildIndex(Me.lblCoeficienteDistribucionExpensas, 0)
      Me.Controls.SetChildIndex(Me.txtCoeficienteDistribucionExpensas, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtCoeficienteDistribucionExpensas As Eniac.Controles.TextBox
   Friend WithEvents lblCoeficienteDistribucionExpensas As Eniac.Controles.Label
   Friend WithEvents lblPies As Eniac.Controles.Label
   Friend WithEvents txtPies As Eniac.Controles.TextBox
   Friend WithEvents lblNombreCategoriaAccion As Eniac.Controles.Label
   Friend WithEvents txtNombreCategoriaAccion As Eniac.Controles.TextBox
   Friend WithEvents lblIdCategoriaAccion As Eniac.Controles.Label
   Friend WithEvents txtIdCategoriaAccion As Eniac.Controles.TextBox
End Class
