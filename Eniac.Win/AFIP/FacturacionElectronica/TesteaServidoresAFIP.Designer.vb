<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TesteaServidoresAFIP
    Inherits BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TesteaServidoresAFIP))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbTestea = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
      Me.pcbAutorizacion = New System.Windows.Forms.PictureBox()
      Me.grbAutorizacion = New System.Windows.Forms.GroupBox()
      Me.grbAplicaciones = New System.Windows.Forms.GroupBox()
      Me.pcbAplicaciones = New System.Windows.Forms.PictureBox()
      Me.grbBaseDeDatos = New System.Windows.Forms.GroupBox()
      Me.pcbBaseDeDatos = New System.Windows.Forms.PictureBox()
      Me.tstBarra.SuspendLayout()
      CType(Me.pcbAutorizacion, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbAutorizacion.SuspendLayout()
      Me.grbAplicaciones.SuspendLayout()
      CType(Me.pcbAplicaciones, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbBaseDeDatos.SuspendLayout()
      CType(Me.pcbBaseDeDatos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbTestea, Me.ToolStripSeparator1, Me.tsbSalir, Me.ToolStripButton1})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(316, 29)
      Me.tstBarra.TabIndex = 7
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbTestea
      '
      Me.tsbTestea.Image = Global.Eniac.Win.My.Resources.Resources.play_ok_32
      Me.tsbTestea.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbTestea.Name = "tsbTestea"
      Me.tsbTestea.Size = New System.Drawing.Size(66, 26)
      Me.tsbTestea.Text = "Testea"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripButton1
      '
      Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
      Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton1.Name = "ToolStripButton1"
      Me.ToolStripButton1.Size = New System.Drawing.Size(26, 26)
      Me.ToolStripButton1.Text = "ToolStripButton1"
      Me.ToolStripButton1.Visible = False
      '
      'pcbAutorizacion
      '
      Me.pcbAutorizacion.ErrorImage = Nothing
      Me.pcbAutorizacion.InitialImage = Nothing
      Me.pcbAutorizacion.Location = New System.Drawing.Point(19, 31)
      Me.pcbAutorizacion.Name = "pcbAutorizacion"
      Me.pcbAutorizacion.Size = New System.Drawing.Size(48, 48)
      Me.pcbAutorizacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.pcbAutorizacion.TabIndex = 8
      Me.pcbAutorizacion.TabStop = False
      '
      'grbAutorizacion
      '
      Me.grbAutorizacion.Controls.Add(Me.pcbAutorizacion)
      Me.grbAutorizacion.Location = New System.Drawing.Point(12, 32)
      Me.grbAutorizacion.Name = "grbAutorizacion"
      Me.grbAutorizacion.Size = New System.Drawing.Size(93, 104)
      Me.grbAutorizacion.TabIndex = 9
      Me.grbAutorizacion.TabStop = False
      Me.grbAutorizacion.Text = "Autorización"
      '
      'grbAplicaciones
      '
      Me.grbAplicaciones.Controls.Add(Me.pcbAplicaciones)
      Me.grbAplicaciones.Location = New System.Drawing.Point(111, 32)
      Me.grbAplicaciones.Name = "grbAplicaciones"
      Me.grbAplicaciones.Size = New System.Drawing.Size(92, 104)
      Me.grbAplicaciones.TabIndex = 10
      Me.grbAplicaciones.TabStop = False
      Me.grbAplicaciones.Text = "Aplicaciones"
      '
      'pcbAplicaciones
      '
      Me.pcbAplicaciones.Location = New System.Drawing.Point(19, 31)
      Me.pcbAplicaciones.Name = "pcbAplicaciones"
      Me.pcbAplicaciones.Size = New System.Drawing.Size(53, 48)
      Me.pcbAplicaciones.TabIndex = 8
      Me.pcbAplicaciones.TabStop = False
      '
      'grbBaseDeDatos
      '
      Me.grbBaseDeDatos.Controls.Add(Me.pcbBaseDeDatos)
      Me.grbBaseDeDatos.Location = New System.Drawing.Point(209, 31)
      Me.grbBaseDeDatos.Name = "grbBaseDeDatos"
      Me.grbBaseDeDatos.Size = New System.Drawing.Size(94, 105)
      Me.grbBaseDeDatos.TabIndex = 11
      Me.grbBaseDeDatos.TabStop = False
      Me.grbBaseDeDatos.Text = "Base de Datos"
      '
      'pcbBaseDeDatos
      '
      Me.pcbBaseDeDatos.Location = New System.Drawing.Point(22, 32)
      Me.pcbBaseDeDatos.Name = "pcbBaseDeDatos"
      Me.pcbBaseDeDatos.Size = New System.Drawing.Size(54, 48)
      Me.pcbBaseDeDatos.TabIndex = 8
      Me.pcbBaseDeDatos.TabStop = False
      '
      'TesteaServidoresAFIP
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(316, 153)
      Me.Controls.Add(Me.grbBaseDeDatos)
      Me.Controls.Add(Me.grbAplicaciones)
      Me.Controls.Add(Me.grbAutorizacion)
      Me.Controls.Add(Me.tstBarra)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "TesteaServidoresAFIP"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Testea Servidores de AFIP"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.pcbAutorizacion, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbAutorizacion.ResumeLayout(False)
      Me.grbAutorizacion.PerformLayout()
      Me.grbAplicaciones.ResumeLayout(False)
      CType(Me.pcbAplicaciones, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbBaseDeDatos.ResumeLayout(False)
      CType(Me.pcbBaseDeDatos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbTestea As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents pcbAutorizacion As System.Windows.Forms.PictureBox
   Friend WithEvents grbAutorizacion As System.Windows.Forms.GroupBox
   Friend WithEvents grbAplicaciones As System.Windows.Forms.GroupBox
   Friend WithEvents pcbAplicaciones As System.Windows.Forms.PictureBox
   Friend WithEvents grbBaseDeDatos As System.Windows.Forms.GroupBox
   Friend WithEvents pcbBaseDeDatos As System.Windows.Forms.PictureBox
   Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
