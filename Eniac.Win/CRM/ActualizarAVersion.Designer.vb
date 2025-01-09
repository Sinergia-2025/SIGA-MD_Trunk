<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActualizarAVersion
   Inherits BaseForm

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
      Me.cmbVersion = New Eniac.Controles.ComboBox()
      Me.lblVersion = New Eniac.Controles.Label()
      Me.lblTexto = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbActualizarVersion = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tslPie = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspProgresito = New System.Windows.Forms.ToolStripProgressBar()
      Me.lblBaseDeDatos = New Eniac.Controles.Label()
      Me.txtBaseDeDatos = New Eniac.Controles.TextBox()
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'cmbVersion
      '
      Me.cmbVersion.BindearPropiedadControl = "SelectedValue"
      Me.cmbVersion.BindearPropiedadEntidad = "IdAplicacion"
      Me.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVersion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVersion.FormattingEnabled = True
      Me.cmbVersion.IsPK = True
      Me.cmbVersion.IsRequired = True
      Me.cmbVersion.Key = Nothing
      Me.cmbVersion.LabelAsoc = Nothing
      Me.cmbVersion.Location = New System.Drawing.Point(117, 48)
      Me.cmbVersion.Name = "cmbVersion"
      Me.cmbVersion.Size = New System.Drawing.Size(114, 21)
      Me.cmbVersion.TabIndex = 6
      '
      'lblVersion
      '
      Me.lblVersion.AutoSize = True
      Me.lblVersion.LabelAsoc = Nothing
      Me.lblVersion.Location = New System.Drawing.Point(12, 56)
      Me.lblVersion.Name = "lblVersion"
      Me.lblVersion.Size = New System.Drawing.Size(99, 13)
      Me.lblVersion.TabIndex = 5
      Me.lblVersion.Text = "Versión a actualizar"
      '
      'lblTexto
      '
      Me.lblTexto.AutoSize = True
      Me.lblTexto.LabelAsoc = Nothing
      Me.lblTexto.Location = New System.Drawing.Point(12, 29)
      Me.lblTexto.Name = "lblTexto"
      Me.lblTexto.Size = New System.Drawing.Size(42, 13)
      Me.lblTexto.TabIndex = 7
      Me.lblTexto.Text = "Versión"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbActualizarVersion, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(286, 29)
      Me.tstBarra.TabIndex = 8
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbActualizarVersion
      '
      Me.tsbActualizarVersion.Image = Global.Eniac.Win.My.Resources.Resources.world_up_32
      Me.tsbActualizarVersion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbActualizarVersion.Name = "tsbActualizarVersion"
      Me.tsbActualizarVersion.Size = New System.Drawing.Size(85, 26)
      Me.tsbActualizarVersion.Text = "Actualizar"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslPie, Me.tspProgresito})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 138)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(286, 22)
      Me.StatusStrip1.TabIndex = 9
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tslPie
      '
      Me.tslPie.ForeColor = System.Drawing.SystemColors.ControlDarkDark
      Me.tslPie.Name = "tslPie"
      Me.tslPie.Size = New System.Drawing.Size(271, 17)
      Me.tslPie.Spring = True
      Me.tslPie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'tspProgresito
      '
      Me.tspProgresito.Name = "tspProgresito"
      Me.tspProgresito.Size = New System.Drawing.Size(100, 16)
      Me.tspProgresito.Visible = False
      '
      'lblBaseDeDatos
      '
      Me.lblBaseDeDatos.AutoSize = True
      Me.lblBaseDeDatos.LabelAsoc = Nothing
      Me.lblBaseDeDatos.Location = New System.Drawing.Point(12, 89)
      Me.lblBaseDeDatos.Name = "lblBaseDeDatos"
      Me.lblBaseDeDatos.Size = New System.Drawing.Size(75, 13)
      Me.lblBaseDeDatos.TabIndex = 10
      Me.lblBaseDeDatos.Text = "Base de datos"
      '
      'txtBaseDeDatos
      '
      Me.txtBaseDeDatos.BindearPropiedadControl = ""
      Me.txtBaseDeDatos.BindearPropiedadEntidad = ""
      Me.txtBaseDeDatos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtBaseDeDatos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtBaseDeDatos.Formato = "N2"
      Me.txtBaseDeDatos.IsDecimal = False
      Me.txtBaseDeDatos.IsNumber = False
      Me.txtBaseDeDatos.IsPK = False
      Me.txtBaseDeDatos.IsRequired = False
      Me.txtBaseDeDatos.Key = ""
      Me.txtBaseDeDatos.LabelAsoc = Nothing
      Me.txtBaseDeDatos.Location = New System.Drawing.Point(117, 82)
      Me.txtBaseDeDatos.MaxLength = 60
      Me.txtBaseDeDatos.Name = "txtBaseDeDatos"
      Me.txtBaseDeDatos.Size = New System.Drawing.Size(140, 20)
      Me.txtBaseDeDatos.TabIndex = 20
      '
      'ActualizarAVersion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(286, 160)
      Me.Controls.Add(Me.txtBaseDeDatos)
      Me.Controls.Add(Me.lblBaseDeDatos)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.lblTexto)
      Me.Controls.Add(Me.cmbVersion)
      Me.Controls.Add(Me.lblVersion)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ActualizarAVersion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Actualizar a version...."
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmbVersion As Eniac.Controles.ComboBox
   Friend WithEvents lblVersion As Eniac.Controles.Label
   Friend WithEvents lblTexto As Eniac.Controles.Label
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbActualizarVersion As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tslPie As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspProgresito As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents lblBaseDeDatos As Eniac.Controles.Label
   Friend WithEvents txtBaseDeDatos As Eniac.Controles.TextBox
End Class
