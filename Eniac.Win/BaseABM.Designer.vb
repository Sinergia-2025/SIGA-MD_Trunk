<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseABM
   Inherits Eniac.Win.BaseForm

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
      Me.stsStado = New System.Windows.Forms.StatusStrip
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel
      Me.toolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel
      Me.tstBarra = New System.Windows.Forms.ToolStrip
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
      Me.tsbEditar = New System.Windows.Forms.ToolStripButton
      Me.tsbBorrar = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.tstBuscar = New System.Windows.Forms.ToolStripTextBox
      Me.tsbBuscar = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.dgvDatos = New Eniac.Controles.DataGridView
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.toolStripProgressBar1, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 376)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(680, 22)
      Me.stsStado.TabIndex = 4
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(601, 17)
      Me.tssInfo.Spring = True
      '
      'toolStripProgressBar1
      '
      Me.toolStripProgressBar1.Name = "toolStripProgressBar1"
      Me.toolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
      Me.toolStripProgressBar1.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbNuevo, Me.tsbEditar, Me.tsbBorrar, Me.toolStripSeparator2, Me.tsbImprimir, Me.toolStripSeparator1, Me.tstBuscar, Me.tsbBuscar, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(680, 29)
      Me.tstBarra.TabIndex = 3
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
      'tsbNuevo
      '
      Me.tsbNuevo.Image = Global.Eniac.Win.My.Resources.Resources.document_add
      Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbNuevo.Name = "tsbNuevo"
      Me.tsbNuevo.Size = New System.Drawing.Size(68, 26)
      Me.tsbNuevo.Text = "&Nuevo"
      '
      'tsbEditar
      '
      Me.tsbEditar.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
      Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbEditar.Name = "tsbEditar"
      Me.tsbEditar.Size = New System.Drawing.Size(63, 26)
      Me.tsbEditar.Text = "&Editar"
      '
      'tsbBorrar
      '
      Me.tsbBorrar.Image = Global.Eniac.Win.My.Resources.Resources.document_delete
      Me.tsbBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbBorrar.Name = "tsbBorrar"
      Me.tsbBorrar.Size = New System.Drawing.Size(76, 26)
      Me.tsbBorrar.Text = "E&liminar"
      '
      'toolStripSeparator2
      '
      Me.toolStripSeparator2.Name = "toolStripSeparator2"
      Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      '
      'toolStripSeparator1
      '
      Me.toolStripSeparator1.Name = "toolStripSeparator1"
      Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tstBuscar
      '
      Me.tstBuscar.Name = "tstBuscar"
      Me.tstBuscar.Size = New System.Drawing.Size(100, 29)
      Me.tstBuscar.ToolTipText = "Ingrese un texto a buscar"
      '
      'tsbBuscar
      '
      Me.tsbBuscar.Image = Global.Eniac.Win.My.Resources.Resources.document_find
      Me.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbBuscar.Name = "tsbBuscar"
      Me.tsbBuscar.Size = New System.Drawing.Size(68, 26)
      Me.tsbBuscar.Text = "&Buscar"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
      'dgvDatos
      '
      Me.dgvDatos.AllowUserToAddRows = False
      Me.dgvDatos.AllowUserToDeleteRows = False
      Me.dgvDatos.AllowUserToOrderColumns = True
      Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dgvDatos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDatos.Location = New System.Drawing.Point(0, 29)
      Me.dgvDatos.Name = "dgvDatos"
      Me.dgvDatos.RowHeadersWidth = 30
      Me.dgvDatos.Size = New System.Drawing.Size(680, 347)
      Me.dgvDatos.TabIndex = 5
      '
      'BaseABM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(680, 398)
      Me.Controls.Add(Me.dgvDatos)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.KeyPreview = True
      Me.Name = "BaseABM"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents toolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Protected Friend WithEvents dgvDatos As Eniac.Controles.DataGridView
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
   Public WithEvents tstBuscar As System.Windows.Forms.ToolStripTextBox
   Public WithEvents tsbBuscar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbBorrar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
End Class
