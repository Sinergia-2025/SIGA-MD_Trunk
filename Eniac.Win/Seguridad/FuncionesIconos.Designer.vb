<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FuncionesIconos
   Inherits BaseForm

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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FuncionesIconos))
      Me.ofdIcono = New System.Windows.Forms.OpenFileDialog
      Me.txtIcono = New System.Windows.Forms.TextBox
      Me.btnIcono = New System.Windows.Forms.Button
      Me.btnGrabar = New System.Windows.Forms.Button
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.cmbFunciones = New Eniac.Controles.ComboBox
      Me.tstBarra = New System.Windows.Forms.ToolStrip
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'txtIcono
      '
      Me.txtIcono.Location = New System.Drawing.Point(159, 39)
      Me.txtIcono.Name = "txtIcono"
      Me.txtIcono.Size = New System.Drawing.Size(373, 20)
      Me.txtIcono.TabIndex = 0
      '
      'btnIcono
      '
      Me.btnIcono.Location = New System.Drawing.Point(531, 36)
      Me.btnIcono.Name = "btnIcono"
      Me.btnIcono.Size = New System.Drawing.Size(75, 23)
      Me.btnIcono.TabIndex = 1
      Me.btnIcono.Text = "&Buscar"
      Me.btnIcono.UseVisualStyleBackColor = True
      '
      'btnGrabar
      '
      Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGrabar.ImageIndex = 0
      Me.btnGrabar.ImageList = Me.imageList1
      Me.btnGrabar.Location = New System.Drawing.Point(526, 72)
      Me.btnGrabar.Name = "btnGrabar"
      Me.btnGrabar.Size = New System.Drawing.Size(80, 30)
      Me.btnGrabar.TabIndex = 2
      Me.btnGrabar.Text = "Grabar"
      Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGrabar.UseVisualStyleBackColor = True
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'cmbFunciones
      '
      Me.cmbFunciones.BindearPropiedadControl = Nothing
      Me.cmbFunciones.BindearPropiedadEntidad = Nothing
      Me.cmbFunciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFunciones.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFunciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFunciones.FormattingEnabled = True
      Me.cmbFunciones.IsPK = False
      Me.cmbFunciones.IsRequired = False
      Me.cmbFunciones.Key = Nothing
      Me.cmbFunciones.LabelAsoc = Nothing
      Me.cmbFunciones.Location = New System.Drawing.Point(16, 39)
      Me.cmbFunciones.Name = "cmbFunciones"
      Me.cmbFunciones.Size = New System.Drawing.Size(137, 21)
      Me.cmbFunciones.TabIndex = 3
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(630, 29)
      Me.tstBarra.TabIndex = 12
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'FuncionesIconos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(630, 114)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.cmbFunciones)
      Me.Controls.Add(Me.btnGrabar)
      Me.Controls.Add(Me.btnIcono)
      Me.Controls.Add(Me.txtIcono)
      Me.Name = "FuncionesIconos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Agregar iconos a las funciones"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ofdIcono As System.Windows.Forms.OpenFileDialog
   Friend WithEvents txtIcono As System.Windows.Forms.TextBox
   Friend WithEvents btnIcono As System.Windows.Forms.Button
   Friend WithEvents btnGrabar As System.Windows.Forms.Button
   Friend WithEvents cmbFunciones As Eniac.Controles.ComboBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
End Class
