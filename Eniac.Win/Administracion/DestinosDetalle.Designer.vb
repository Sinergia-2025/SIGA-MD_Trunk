<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DestinosDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Me.lblIdDestino = New Eniac.Controles.Label()
      Me.txtIdDestino = New Eniac.Controles.TextBox()
      Me.lblNombreDestino = New Eniac.Controles.Label()
      Me.txtNombreDestino = New Eniac.Controles.TextBox()
      Me.chbEsLibre = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(131, 147)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(224, 147)
      Me.btnCancelar.TabIndex = 6
      '
      'lblIdDestino
      '
      Me.lblIdDestino.AutoSize = True
      Me.lblIdDestino.Location = New System.Drawing.Point(22, 28)
      Me.lblIdDestino.Name = "lblIdDestino"
      Me.lblIdDestino.Size = New System.Drawing.Size(40, 13)
      Me.lblIdDestino.TabIndex = 0
      Me.lblIdDestino.Text = "Codigo"
      '
      'txtIdDestino
      '
      Me.txtIdDestino.BindearPropiedadControl = "Text"
      Me.txtIdDestino.BindearPropiedadEntidad = "IdDestino"
      Me.txtIdDestino.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdDestino.Formato = ""
      Me.txtIdDestino.IsDecimal = False
      Me.txtIdDestino.IsNumber = True
      Me.txtIdDestino.IsPK = True
      Me.txtIdDestino.IsRequired = True
      Me.txtIdDestino.Key = ""
      Me.txtIdDestino.LabelAsoc = Me.lblIdDestino
      Me.txtIdDestino.Location = New System.Drawing.Point(75, 24)
      Me.txtIdDestino.MaxLength = 1
      Me.txtIdDestino.Name = "txtIdDestino"
      Me.txtIdDestino.Size = New System.Drawing.Size(25, 20)
      Me.txtIdDestino.TabIndex = 1
      Me.txtIdDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNombreDestino
      '
      Me.lblNombreDestino.AutoSize = True
      Me.lblNombreDestino.Location = New System.Drawing.Point(22, 55)
      Me.lblNombreDestino.Name = "lblNombreDestino"
      Me.lblNombreDestino.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreDestino.TabIndex = 2
      Me.lblNombreDestino.Text = "Nombre"
      '
      'txtNombreDestino
      '
      Me.txtNombreDestino.BindearPropiedadControl = "Text"
      Me.txtNombreDestino.BindearPropiedadEntidad = "NombreDestino"
      Me.txtNombreDestino.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreDestino.Formato = ""
      Me.txtNombreDestino.IsDecimal = False
      Me.txtNombreDestino.IsNumber = False
      Me.txtNombreDestino.IsPK = False
      Me.txtNombreDestino.IsRequired = True
      Me.txtNombreDestino.Key = ""
      Me.txtNombreDestino.LabelAsoc = Me.lblNombreDestino
      Me.txtNombreDestino.Location = New System.Drawing.Point(75, 51)
      Me.txtNombreDestino.MaxLength = 30
      Me.txtNombreDestino.Name = "txtNombreDestino"
      Me.txtNombreDestino.Size = New System.Drawing.Size(239, 20)
      Me.txtNombreDestino.TabIndex = 3
      '
      'chbEsLibre
      '
      Me.chbEsLibre.AutoSize = True
      Me.chbEsLibre.BindearPropiedadControl = "Checked"
      Me.chbEsLibre.BindearPropiedadEntidad = "EsLibre"
      Me.chbEsLibre.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEsLibre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEsLibre.IsPK = False
      Me.chbEsLibre.IsRequired = False
      Me.chbEsLibre.Key = Nothing
      Me.chbEsLibre.LabelAsoc = Nothing
      Me.chbEsLibre.Location = New System.Drawing.Point(25, 83)
      Me.chbEsLibre.Name = "chbEsLibre"
      Me.chbEsLibre.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbEsLibre.Size = New System.Drawing.Size(64, 17)
      Me.chbEsLibre.TabIndex = 4
      Me.chbEsLibre.Text = "Es Libre"
      Me.chbEsLibre.UseVisualStyleBackColor = True
      '
      'DestinosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(326, 195)
      Me.Controls.Add(Me.chbEsLibre)
      Me.Controls.Add(Me.txtNombreDestino)
      Me.Controls.Add(Me.lblNombreDestino)
      Me.Controls.Add(Me.lblIdDestino)
      Me.Controls.Add(Me.txtIdDestino)
      Me.Name = "DestinosDetalle"
      Me.Text = "Destino"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdDestino, 0)
      Me.Controls.SetChildIndex(Me.lblIdDestino, 0)
      Me.Controls.SetChildIndex(Me.lblNombreDestino, 0)
      Me.Controls.SetChildIndex(Me.txtNombreDestino, 0)
      Me.Controls.SetChildIndex(Me.chbEsLibre, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblIdDestino As Eniac.Controles.Label
   Friend WithEvents txtIdDestino As Eniac.Controles.TextBox
   Friend WithEvents lblNombreDestino As Eniac.Controles.Label
   Friend WithEvents txtNombreDestino As Eniac.Controles.TextBox
   Friend WithEvents chbEsLibre As Eniac.Controles.CheckBox
End Class
