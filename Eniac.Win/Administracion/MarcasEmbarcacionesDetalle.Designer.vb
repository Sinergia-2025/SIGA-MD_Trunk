<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MarcasEmbarcacionesDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MarcasEmbarcacionesDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtMarcaEmbarcacion = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtIdMarcaEmbarcacion = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(195, 84)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(291, 84)
      Me.btnCancelar.TabIndex = 6
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(28, 45)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 3
      Me.lblNombre.Text = "Nombre"
      '
      'txtMarcaEmbarcacion
      '
      Me.txtMarcaEmbarcacion.BindearPropiedadControl = "Text"
      Me.txtMarcaEmbarcacion.BindearPropiedadEntidad = "NombreMarcaEmbarcacion"
      Me.txtMarcaEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMarcaEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMarcaEmbarcacion.Formato = ""
      Me.txtMarcaEmbarcacion.IsDecimal = False
      Me.txtMarcaEmbarcacion.IsNumber = False
      Me.txtMarcaEmbarcacion.IsPK = False
      Me.txtMarcaEmbarcacion.IsRequired = True
      Me.txtMarcaEmbarcacion.Key = ""
      Me.txtMarcaEmbarcacion.LabelAsoc = Me.lblNombre
      Me.txtMarcaEmbarcacion.Location = New System.Drawing.Point(106, 41)
      Me.txtMarcaEmbarcacion.MaxLength = 30
      Me.txtMarcaEmbarcacion.Name = "txtMarcaEmbarcacion"
      Me.txtMarcaEmbarcacion.Size = New System.Drawing.Size(275, 20)
      Me.txtMarcaEmbarcacion.TabIndex = 2
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.Location = New System.Drawing.Point(28, 17)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 1
      Me.lblId.Text = "Código"
      '
      'txtIdMarcaEmbarcacion
      '
      Me.txtIdMarcaEmbarcacion.BindearPropiedadControl = "Text"
      Me.txtIdMarcaEmbarcacion.BindearPropiedadEntidad = "IdMarcaEmbarcacion"
      Me.txtIdMarcaEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdMarcaEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdMarcaEmbarcacion.Formato = ""
      Me.txtIdMarcaEmbarcacion.IsDecimal = False
      Me.txtIdMarcaEmbarcacion.IsNumber = True
      Me.txtIdMarcaEmbarcacion.IsPK = True
      Me.txtIdMarcaEmbarcacion.IsRequired = True
      Me.txtIdMarcaEmbarcacion.Key = ""
      Me.txtIdMarcaEmbarcacion.LabelAsoc = Me.lblId
      Me.txtIdMarcaEmbarcacion.Location = New System.Drawing.Point(106, 13)
      Me.txtIdMarcaEmbarcacion.MaxLength = 4
      Me.txtIdMarcaEmbarcacion.Name = "txtIdMarcaEmbarcacion"
      Me.txtIdMarcaEmbarcacion.Size = New System.Drawing.Size(55, 20)
      Me.txtIdMarcaEmbarcacion.TabIndex = 0
      Me.txtIdMarcaEmbarcacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'MarcasEmbarcacionesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(390, 131)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtMarcaEmbarcacion)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtIdMarcaEmbarcacion)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "MarcasEmbarcacionesDetalle"
      Me.Text = "Marca de Embarcacion"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdMarcaEmbarcacion, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtMarcaEmbarcacion, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtMarcaEmbarcacion As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtIdMarcaEmbarcacion As Eniac.Controles.TextBox

End Class
