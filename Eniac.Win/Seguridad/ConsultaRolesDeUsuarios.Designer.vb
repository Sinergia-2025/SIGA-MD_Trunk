<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaRolesDeUsuarios
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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaRolesDeUsuarios))
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.lblUsuarios = New Eniac.Controles.Label
      Me.dgvUsuarios = New Eniac.Controles.DataGridView
      Me.Label1 = New Eniac.Controles.Label
      Me.dgvRoles = New Eniac.Controles.DataGridView
      Me.tstBarra.SuspendLayout()
      CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvRoles, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(592, 29)
      Me.tstBarra.TabIndex = 12
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(81, 26)
      Me.tsbRefrescar.Text = "&Refrescar"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      'lblUsuarios
      '
      Me.lblUsuarios.AutoSize = True
      Me.lblUsuarios.Location = New System.Drawing.Point(9, 37)
      Me.lblUsuarios.Name = "lblUsuarios"
      Me.lblUsuarios.Size = New System.Drawing.Size(48, 13)
      Me.lblUsuarios.TabIndex = 14
      Me.lblUsuarios.Text = "Usuarios"
      '
      'dgvUsuarios
      '
      Me.dgvUsuarios.AllowUserToAddRows = False
      Me.dgvUsuarios.AllowUserToDeleteRows = False
      Me.dgvUsuarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvUsuarios.Location = New System.Drawing.Point(12, 56)
      Me.dgvUsuarios.Name = "dgvUsuarios"
      Me.dgvUsuarios.RowHeadersWidth = 20
      Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvUsuarios.Size = New System.Drawing.Size(253, 333)
      Me.dgvUsuarios.TabIndex = 13
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(268, 37)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(34, 13)
      Me.Label1.TabIndex = 16
      Me.Label1.Text = "Roles"
      '
      'dgvRoles
      '
      Me.dgvRoles.AllowUserToAddRows = False
      Me.dgvRoles.AllowUserToDeleteRows = False
      Me.dgvRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvRoles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvRoles.Location = New System.Drawing.Point(271, 56)
      Me.dgvRoles.Name = "dgvRoles"
      Me.dgvRoles.RowHeadersWidth = 20
      Me.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvRoles.Size = New System.Drawing.Size(303, 333)
      Me.dgvRoles.TabIndex = 15
      '
      'ConsultaRolesDeUsuarios
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(592, 401)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dgvRoles)
      Me.Controls.Add(Me.lblUsuarios)
      Me.Controls.Add(Me.dgvUsuarios)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ConsultaRolesDeUsuarios"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consulta Roles de los Usuarios"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvRoles, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblUsuarios As Eniac.Controles.Label
   Friend WithEvents dgvUsuarios As Eniac.Controles.DataGridView
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents dgvRoles As Eniac.Controles.DataGridView
End Class
