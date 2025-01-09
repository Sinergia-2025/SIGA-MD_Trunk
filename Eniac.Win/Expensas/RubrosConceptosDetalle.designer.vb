<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RubrosConceptosDetalle
   Inherits Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RubrosConceptosDetalle))
      Me.lblNombreRubro = New Eniac.Controles.Label
      Me.txtNombreRubro = New Eniac.Controles.TextBox
      Me.lblIdRubro = New Eniac.Controles.Label
      Me.txtRubro = New Eniac.Controles.TextBox
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(162, 80)
      Me.btnAceptar.TabIndex = 2
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(248, 80)
      Me.btnCancelar.TabIndex = 3
      '
      'lblNombreRubro
      '
      Me.lblNombreRubro.AutoSize = True
      Me.lblNombreRubro.Location = New System.Drawing.Point(7, 48)
      Me.lblNombreRubro.Name = "lblNombreRubro"
      Me.lblNombreRubro.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreRubro.TabIndex = 5
      Me.lblNombreRubro.Text = "Nombre"
      '
      'txtNombreRubro
      '
      Me.txtNombreRubro.BindearPropiedadControl = "Text"
      Me.txtNombreRubro.BindearPropiedadEntidad = "NombreRubroConcepto"
      Me.txtNombreRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreRubro.Formato = ""
      Me.txtNombreRubro.IsDecimal = False
      Me.txtNombreRubro.IsNumber = False
      Me.txtNombreRubro.IsPK = False
      Me.txtNombreRubro.IsRequired = True
      Me.txtNombreRubro.Key = ""
      Me.txtNombreRubro.LabelAsoc = Me.lblNombreRubro
      Me.txtNombreRubro.Location = New System.Drawing.Point(53, 44)
      Me.txtNombreRubro.MaxLength = 50
      Me.txtNombreRubro.Name = "txtNombreRubro"
      Me.txtNombreRubro.Size = New System.Drawing.Size(275, 20)
      Me.txtNombreRubro.TabIndex = 1
      '
      'lblIdRubro
      '
      Me.lblIdRubro.AutoSize = True
      Me.lblIdRubro.Location = New System.Drawing.Point(7, 20)
      Me.lblIdRubro.Name = "lblIdRubro"
      Me.lblIdRubro.Size = New System.Drawing.Size(40, 13)
      Me.lblIdRubro.TabIndex = 4
      Me.lblIdRubro.Text = "Código"
      '
      'txtRubro
      '
      Me.txtRubro.BindearPropiedadControl = "Text"
      Me.txtRubro.BindearPropiedadEntidad = "IdRubroConcepto"
      Me.txtRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRubro.Formato = ""
      Me.txtRubro.IsDecimal = False
      Me.txtRubro.IsNumber = True
      Me.txtRubro.IsPK = True
      Me.txtRubro.IsRequired = True
      Me.txtRubro.Key = ""
      Me.txtRubro.LabelAsoc = Me.lblIdRubro
      Me.txtRubro.Location = New System.Drawing.Point(53, 16)
      Me.txtRubro.MaxLength = 9
      Me.txtRubro.Name = "txtRubro"
      Me.txtRubro.Size = New System.Drawing.Size(77, 20)
      Me.txtRubro.TabIndex = 0
      Me.txtRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'RubrosConceptosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(337, 115)
      Me.Controls.Add(Me.lblNombreRubro)
      Me.Controls.Add(Me.txtNombreRubro)
      Me.Controls.Add(Me.lblIdRubro)
      Me.Controls.Add(Me.txtRubro)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "RubrosConceptosDetalle"
      Me.Text = "Rubro Concepto"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtRubro, 0)
      Me.Controls.SetChildIndex(Me.lblIdRubro, 0)
      Me.Controls.SetChildIndex(Me.txtNombreRubro, 0)
      Me.Controls.SetChildIndex(Me.lblNombreRubro, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreRubro As Eniac.Controles.Label
   Friend WithEvents txtNombreRubro As Eniac.Controles.TextBox
   Friend WithEvents lblIdRubro As Eniac.Controles.Label
   Friend WithEvents txtRubro As Eniac.Controles.TextBox

End Class
