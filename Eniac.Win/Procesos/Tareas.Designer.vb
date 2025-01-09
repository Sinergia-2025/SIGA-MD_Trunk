<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tareas
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tareas))
      Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
      Me.statusStrip1 = New System.Windows.Forms.StatusStrip
      Me.sslTareas = New System.Windows.Forms.ToolStripStatusLabel
      Me.gbxTareas = New System.Windows.Forms.GroupBox
      Me.txtTareas = New System.Windows.Forms.TextBox
      Me.btnEliminar = New System.Windows.Forms.Button
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAgregar = New System.Windows.Forms.Button
      Me.clbTareas = New System.Windows.Forms.CheckedListBox
      Me.mclFecha = New System.Windows.Forms.MonthCalendar
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.statusStrip1.SuspendLayout()
      Me.gbxTareas.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'toolStripStatusLabel1
      '
      Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
      Me.toolStripStatusLabel1.Size = New System.Drawing.Size(495, 17)
      Me.toolStripStatusLabel1.Spring = True
      '
      'statusStrip1
      '
      Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel1, Me.sslTareas})
      Me.statusStrip1.Location = New System.Drawing.Point(0, 409)
      Me.statusStrip1.Name = "statusStrip1"
      Me.statusStrip1.Size = New System.Drawing.Size(559, 22)
      Me.statusStrip1.TabIndex = 4
      Me.statusStrip1.Text = "statusStrip1"
      '
      'sslTareas
      '
      Me.sslTareas.Name = "sslTareas"
      Me.sslTareas.Size = New System.Drawing.Size(49, 17)
      Me.sslTareas.Text = "0 Tareas"
      '
      'gbxTareas
      '
      Me.gbxTareas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.gbxTareas.Controls.Add(Me.txtTareas)
      Me.gbxTareas.Controls.Add(Me.btnEliminar)
      Me.gbxTareas.Controls.Add(Me.btnAgregar)
      Me.gbxTareas.Location = New System.Drawing.Point(230, 29)
      Me.gbxTareas.Name = "gbxTareas"
      Me.gbxTareas.Size = New System.Drawing.Size(322, 155)
      Me.gbxTareas.TabIndex = 0
      Me.gbxTareas.TabStop = False
      Me.gbxTareas.Text = "Carga de tareas"
      '
      'txtTareas
      '
      Me.txtTareas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTareas.Location = New System.Drawing.Point(9, 19)
      Me.txtTareas.Multiline = True
      Me.txtTareas.Name = "txtTareas"
      Me.txtTareas.Size = New System.Drawing.Size(307, 92)
      Me.txtTareas.TabIndex = 0
      Me.ToolTip1.SetToolTip(Me.txtTareas, "Ingrese una tarea y presione ""Agregar""")
      '
      'btnEliminar
      '
      Me.btnEliminar.Enabled = False
      Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnEliminar.ImageIndex = 0
      Me.btnEliminar.ImageList = Me.imgIconos
      Me.btnEliminar.Location = New System.Drawing.Point(93, 117)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(80, 30)
      Me.btnEliminar.TabIndex = 2
      Me.btnEliminar.Text = "Eliminar"
      Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "note_delete.ico")
      Me.imgIconos.Images.SetKeyName(1, "note_add.ico")
      '
      'btnAgregar
      '
      Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAgregar.ImageIndex = 1
      Me.btnAgregar.ImageList = Me.imgIconos
      Me.btnAgregar.Location = New System.Drawing.Point(7, 117)
      Me.btnAgregar.Name = "btnAgregar"
      Me.btnAgregar.Size = New System.Drawing.Size(80, 30)
      Me.btnAgregar.TabIndex = 1
      Me.btnAgregar.Text = "Agregar"
      Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'clbTareas
      '
      Me.clbTareas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.clbTareas.BackColor = System.Drawing.SystemColors.Info
      Me.clbTareas.CheckOnClick = True
      Me.clbTareas.FormattingEnabled = True
      Me.clbTareas.Location = New System.Drawing.Point(-1, 189)
      Me.clbTareas.Name = "clbTareas"
      Me.clbTareas.Size = New System.Drawing.Size(553, 214)
      Me.clbTareas.TabIndex = 2
      '
      'mclFecha
      '
      Me.mclFecha.Location = New System.Drawing.Point(0, 29)
      Me.mclFecha.MaxSelectionCount = 1
      Me.mclFecha.Name = "mclFecha"
      Me.mclFecha.TabIndex = 1
      Me.mclFecha.TitleBackColor = System.Drawing.Color.Navy
      Me.mclFecha.TitleForeColor = System.Drawing.SystemColors.ButtonFace
      '
      'tstBarra
      '
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(559, 29)
      Me.tstBarra.TabIndex = 3
      Me.tstBarra.Text = "ToolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(80, 26)
      Me.tsbRefrescar.Text = "&Refrescar"
      Me.tsbRefrescar.ToolTipText = "Refrescar el formulario"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(71, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir las tareas seleccionadas"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(64, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'Tareas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(559, 431)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.statusStrip1)
      Me.Controls.Add(Me.gbxTareas)
      Me.Controls.Add(Me.clbTareas)
      Me.Controls.Add(Me.mclFecha)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "Tareas"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Tareas"
      Me.statusStrip1.ResumeLayout(False)
      Me.statusStrip1.PerformLayout()
      Me.gbxTareas.ResumeLayout(False)
      Me.gbxTareas.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents sslTareas As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents gbxTareas As System.Windows.Forms.GroupBox
    Private WithEvents txtTareas As System.Windows.Forms.TextBox
    Private WithEvents btnEliminar As System.Windows.Forms.Button
    Private WithEvents btnAgregar As System.Windows.Forms.Button
    Private WithEvents mclFecha As System.Windows.Forms.MonthCalendar
    Friend WithEvents imgIconos As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Private WithEvents clbTareas As System.Windows.Forms.CheckedListBox
End Class
