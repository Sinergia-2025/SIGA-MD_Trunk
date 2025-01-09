<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MarcasDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MarcasDetalle))
      Me.lblNombreMarca = New Eniac.Controles.Label()
      Me.txtNombreMarca = New Eniac.Controles.TextBox()
      Me.lblIdMarca = New Eniac.Controles.Label()
      Me.txtIdMarca = New Eniac.Controles.TextBox()
      Me.txtComisionPorVenta = New Eniac.Controles.TextBox()
      Me.lblComisionPorVenta = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtDescuentoRecargo1 = New Eniac.Controles.TextBox()
      Me.lblDescuentoRecargo = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.txtDescuentoRecargo2 = New Eniac.Controles.TextBox()
      Me.lblDescuentoRecargo2 = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(194, 163)
      Me.btnAceptar.TabIndex = 13
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(280, 163)
      Me.btnCancelar.TabIndex = 14
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(110, 245)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(53, 245)
      '
      'lblNombreMarca
      '
      Me.lblNombreMarca.AutoSize = True
      Me.lblNombreMarca.LabelAsoc = Nothing
      Me.lblNombreMarca.Location = New System.Drawing.Point(7, 50)
      Me.lblNombreMarca.Name = "lblNombreMarca"
      Me.lblNombreMarca.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreMarca.TabIndex = 2
      Me.lblNombreMarca.Text = "Nombre"
      '
      'txtNombreMarca
      '
      Me.txtNombreMarca.BindearPropiedadControl = "Text"
      Me.txtNombreMarca.BindearPropiedadEntidad = "NombreMarca"
      Me.txtNombreMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreMarca.Formato = ""
      Me.txtNombreMarca.IsDecimal = False
      Me.txtNombreMarca.IsNumber = False
      Me.txtNombreMarca.IsPK = False
      Me.txtNombreMarca.IsRequired = True
      Me.txtNombreMarca.Key = ""
      Me.txtNombreMarca.LabelAsoc = Me.lblNombreMarca
      Me.txtNombreMarca.Location = New System.Drawing.Point(119, 46)
      Me.txtNombreMarca.MaxLength = 50
      Me.txtNombreMarca.Name = "txtNombreMarca"
      Me.txtNombreMarca.Size = New System.Drawing.Size(236, 20)
      Me.txtNombreMarca.TabIndex = 3
      '
      'lblIdMarca
      '
      Me.lblIdMarca.AutoSize = True
      Me.lblIdMarca.LabelAsoc = Nothing
      Me.lblIdMarca.Location = New System.Drawing.Point(7, 22)
      Me.lblIdMarca.Name = "lblIdMarca"
      Me.lblIdMarca.Size = New System.Drawing.Size(40, 13)
      Me.lblIdMarca.TabIndex = 0
      Me.lblIdMarca.Text = "Código"
      '
      'txtIdMarca
      '
      Me.txtIdMarca.BindearPropiedadControl = "Text"
      Me.txtIdMarca.BindearPropiedadEntidad = "IdMarca"
      Me.txtIdMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdMarca.Formato = ""
      Me.txtIdMarca.IsDecimal = False
      Me.txtIdMarca.IsNumber = True
      Me.txtIdMarca.IsPK = True
      Me.txtIdMarca.IsRequired = True
      Me.txtIdMarca.Key = ""
      Me.txtIdMarca.LabelAsoc = Me.lblIdMarca
      Me.txtIdMarca.Location = New System.Drawing.Point(119, 18)
      Me.txtIdMarca.MaxLength = 4
      Me.txtIdMarca.Name = "txtIdMarca"
      Me.txtIdMarca.Size = New System.Drawing.Size(54, 20)
      Me.txtIdMarca.TabIndex = 1
      Me.txtIdMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtComisionPorVenta
      '
      Me.txtComisionPorVenta.BindearPropiedadControl = "Text"
      Me.txtComisionPorVenta.BindearPropiedadEntidad = "ComisionPorVenta"
      Me.txtComisionPorVenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComisionPorVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComisionPorVenta.Formato = "##0.00"
      Me.txtComisionPorVenta.IsDecimal = True
      Me.txtComisionPorVenta.IsNumber = True
      Me.txtComisionPorVenta.IsPK = False
      Me.txtComisionPorVenta.IsRequired = False
      Me.txtComisionPorVenta.Key = ""
      Me.txtComisionPorVenta.LabelAsoc = Me.lblComisionPorVenta
      Me.txtComisionPorVenta.Location = New System.Drawing.Point(119, 72)
      Me.txtComisionPorVenta.MaxLength = 5
      Me.txtComisionPorVenta.Name = "txtComisionPorVenta"
      Me.txtComisionPorVenta.Size = New System.Drawing.Size(54, 20)
      Me.txtComisionPorVenta.TabIndex = 5
      Me.txtComisionPorVenta.Text = "0.00"
      Me.txtComisionPorVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblComisionPorVenta
      '
      Me.lblComisionPorVenta.AutoSize = True
      Me.lblComisionPorVenta.LabelAsoc = Nothing
      Me.lblComisionPorVenta.Location = New System.Drawing.Point(7, 75)
      Me.lblComisionPorVenta.Name = "lblComisionPorVenta"
      Me.lblComisionPorVenta.Size = New System.Drawing.Size(71, 13)
      Me.lblComisionPorVenta.TabIndex = 4
      Me.lblComisionPorVenta.Text = "Comisión Vta."
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(179, 75)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(15, 13)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "%"
      '
      'txtDescuentoRecargo1
      '
      Me.txtDescuentoRecargo1.BindearPropiedadControl = "Text"
      Me.txtDescuentoRecargo1.BindearPropiedadEntidad = "DescuentoRecargoPorc1"
      Me.txtDescuentoRecargo1.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescuentoRecargo1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescuentoRecargo1.Formato = "##0.00"
      Me.txtDescuentoRecargo1.IsDecimal = True
      Me.txtDescuentoRecargo1.IsNumber = True
      Me.txtDescuentoRecargo1.IsPK = False
      Me.txtDescuentoRecargo1.IsRequired = False
      Me.txtDescuentoRecargo1.Key = ""
      Me.txtDescuentoRecargo1.LabelAsoc = Me.lblDescuentoRecargo
      Me.txtDescuentoRecargo1.Location = New System.Drawing.Point(119, 98)
      Me.txtDescuentoRecargo1.MaxLength = 5
      Me.txtDescuentoRecargo1.Name = "txtDescuentoRecargo1"
      Me.txtDescuentoRecargo1.Size = New System.Drawing.Size(54, 20)
      Me.txtDescuentoRecargo1.TabIndex = 8
      Me.txtDescuentoRecargo1.Text = "0,00"
      Me.txtDescuentoRecargo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDescuentoRecargo
      '
      Me.lblDescuentoRecargo.AutoSize = True
      Me.lblDescuentoRecargo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDescuentoRecargo.LabelAsoc = Nothing
      Me.lblDescuentoRecargo.Location = New System.Drawing.Point(7, 101)
      Me.lblDescuentoRecargo.Name = "lblDescuentoRecargo"
      Me.lblDescuentoRecargo.Size = New System.Drawing.Size(105, 13)
      Me.lblDescuentoRecargo.TabIndex = 7
      Me.lblDescuentoRecargo.Text = "Descto. / Recargo 1"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(179, 101)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(15, 13)
      Me.Label2.TabIndex = 9
      Me.Label2.Text = "%"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(179, 127)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(15, 13)
      Me.Label3.TabIndex = 12
      Me.Label3.Text = "%"
      '
      'txtDescuentoRecargo2
      '
      Me.txtDescuentoRecargo2.BindearPropiedadControl = "Text"
      Me.txtDescuentoRecargo2.BindearPropiedadEntidad = "DescuentoRecargoPorc2"
      Me.txtDescuentoRecargo2.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescuentoRecargo2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescuentoRecargo2.Formato = "##0.00"
      Me.txtDescuentoRecargo2.IsDecimal = True
      Me.txtDescuentoRecargo2.IsNumber = True
      Me.txtDescuentoRecargo2.IsPK = False
      Me.txtDescuentoRecargo2.IsRequired = False
      Me.txtDescuentoRecargo2.Key = ""
      Me.txtDescuentoRecargo2.LabelAsoc = Me.lblDescuentoRecargo2
      Me.txtDescuentoRecargo2.Location = New System.Drawing.Point(119, 124)
      Me.txtDescuentoRecargo2.MaxLength = 5
      Me.txtDescuentoRecargo2.Name = "txtDescuentoRecargo2"
      Me.txtDescuentoRecargo2.Size = New System.Drawing.Size(54, 20)
      Me.txtDescuentoRecargo2.TabIndex = 11
      Me.txtDescuentoRecargo2.Text = "0,00"
      Me.txtDescuentoRecargo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDescuentoRecargo2
      '
      Me.lblDescuentoRecargo2.AutoSize = True
      Me.lblDescuentoRecargo2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDescuentoRecargo2.LabelAsoc = Nothing
      Me.lblDescuentoRecargo2.Location = New System.Drawing.Point(7, 127)
      Me.lblDescuentoRecargo2.Name = "lblDescuentoRecargo2"
      Me.lblDescuentoRecargo2.Size = New System.Drawing.Size(105, 13)
      Me.lblDescuentoRecargo2.TabIndex = 10
      Me.lblDescuentoRecargo2.Text = "Descto. / Recargo 2"
      '
      'MarcasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(372, 205)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtDescuentoRecargo2)
      Me.Controls.Add(Me.lblDescuentoRecargo2)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtDescuentoRecargo1)
      Me.Controls.Add(Me.lblDescuentoRecargo)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtComisionPorVenta)
      Me.Controls.Add(Me.lblComisionPorVenta)
      Me.Controls.Add(Me.lblNombreMarca)
      Me.Controls.Add(Me.txtNombreMarca)
      Me.Controls.Add(Me.lblIdMarca)
      Me.Controls.Add(Me.txtIdMarca)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "MarcasDetalle"
      Me.Text = "Marca"
      Me.Controls.SetChildIndex(Me.txtIdMarca, 0)
      Me.Controls.SetChildIndex(Me.lblIdMarca, 0)
      Me.Controls.SetChildIndex(Me.txtNombreMarca, 0)
      Me.Controls.SetChildIndex(Me.lblNombreMarca, 0)
      Me.Controls.SetChildIndex(Me.lblComisionPorVenta, 0)
      Me.Controls.SetChildIndex(Me.txtComisionPorVenta, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.lblDescuentoRecargo, 0)
      Me.Controls.SetChildIndex(Me.txtDescuentoRecargo1, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblDescuentoRecargo2, 0)
      Me.Controls.SetChildIndex(Me.txtDescuentoRecargo2, 0)
      Me.Controls.SetChildIndex(Me.Label3, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreMarca As Eniac.Controles.Label
   Friend WithEvents txtNombreMarca As Eniac.Controles.TextBox
   Friend WithEvents lblIdMarca As Eniac.Controles.Label
   Friend WithEvents txtIdMarca As Eniac.Controles.TextBox
   Friend WithEvents txtComisionPorVenta As Eniac.Controles.TextBox
   Friend WithEvents lblComisionPorVenta As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtDescuentoRecargo1 As Eniac.Controles.TextBox
   Friend WithEvents lblDescuentoRecargo As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents txtDescuentoRecargo2 As Eniac.Controles.TextBox
   Friend WithEvents lblDescuentoRecargo2 As Eniac.Controles.Label

End Class
