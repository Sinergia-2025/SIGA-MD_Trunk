<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoriasProveedoresDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CategoriasProveedoresDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombreCategoria = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtCategoria = New Eniac.Controles.TextBox()
      Me.grpContabilidad = New System.Windows.Forms.GroupBox()
      Me.UcCuentas1 = New Eniac.Win.ucCuentas()
      Me.grpContabilidad.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(308, 127)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(394, 127)
      Me.btnCancelar.TabIndex = 4
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(28, 45)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 6
      Me.lblNombre.Text = "Nombre"
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
      Me.txtNombreCategoria.Location = New System.Drawing.Point(87, 41)
      Me.txtNombreCategoria.MaxLength = 30
      Me.txtNombreCategoria.Name = "txtNombreCategoria"
      Me.txtNombreCategoria.Size = New System.Drawing.Size(275, 20)
      Me.txtNombreCategoria.TabIndex = 1
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.LabelAsoc = Nothing
      Me.lblId.Location = New System.Drawing.Point(28, 17)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 5
      Me.lblId.Text = "Código"
      '
      'txtCategoria
      '
      Me.txtCategoria.BindearPropiedadControl = "Text"
      Me.txtCategoria.BindearPropiedadEntidad = "IdCategoria"
      Me.txtCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCategoria.Formato = ""
      Me.txtCategoria.IsDecimal = False
      Me.txtCategoria.IsNumber = True
      Me.txtCategoria.IsPK = True
      Me.txtCategoria.IsRequired = True
      Me.txtCategoria.Key = ""
      Me.txtCategoria.LabelAsoc = Me.lblId
      Me.txtCategoria.Location = New System.Drawing.Point(87, 13)
      Me.txtCategoria.MaxLength = 3
      Me.txtCategoria.Name = "txtCategoria"
      Me.txtCategoria.Size = New System.Drawing.Size(48, 20)
      Me.txtCategoria.TabIndex = 0
      Me.txtCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'grpContabilidad
      '
      Me.grpContabilidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpContabilidad.Controls.Add(Me.UcCuentas1)
      Me.grpContabilidad.Location = New System.Drawing.Point(12, 67)
      Me.grpContabilidad.Name = "grpContabilidad"
      Me.grpContabilidad.Size = New System.Drawing.Size(462, 50)
      Me.grpContabilidad.TabIndex = 2
      Me.grpContabilidad.TabStop = False
      Me.grpContabilidad.Text = "Contabilidad"
      '
      'UcCuentas1
      '
      Me.UcCuentas1.Cuenta = Nothing
      Me.UcCuentas1.Location = New System.Drawing.Point(6, 19)
      Me.UcCuentas1.Name = "UcCuentas1"
      Me.UcCuentas1.Size = New System.Drawing.Size(444, 20)
      Me.UcCuentas1.TabIndex = 0
      '
      'CategoriasProveedoresDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(483, 162)
      Me.Controls.Add(Me.grpContabilidad)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombreCategoria)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtCategoria)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CategoriasProveedoresDetalle"
      Me.Text = "Categoria Proveedor"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtCategoria, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtNombreCategoria, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.grpContabilidad, 0)
      Me.grpContabilidad.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombreCategoria As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtCategoria As Eniac.Controles.TextBox
   Friend WithEvents grpContabilidad As System.Windows.Forms.GroupBox
   Friend WithEvents UcCuentas1 As Eniac.Win.ucCuentas

End Class
