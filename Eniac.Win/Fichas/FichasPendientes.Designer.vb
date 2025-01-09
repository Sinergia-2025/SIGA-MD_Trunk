<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichasPendientes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FichasPendientes))
      Me.dgvOperacionesPendientes = New Eniac.Controles.DataGridView
      Me.btnOk = New Eniac.Controles.Button
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New Eniac.Controles.Button
      CType(Me.dgvOperacionesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'dgvOperacionesPendientes
      '
      Me.dgvOperacionesPendientes.AllowUserToAddRows = False
      Me.dgvOperacionesPendientes.AllowUserToDeleteRows = False
      Me.dgvOperacionesPendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvOperacionesPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvOperacionesPendientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvOperacionesPendientes.Location = New System.Drawing.Point(0, 0)
      Me.dgvOperacionesPendientes.MultiSelect = False
      Me.dgvOperacionesPendientes.Name = "dgvOperacionesPendientes"
      Me.dgvOperacionesPendientes.RowHeadersVisible = False
      Me.dgvOperacionesPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvOperacionesPendientes.Size = New System.Drawing.Size(394, 292)
      Me.dgvOperacionesPendientes.TabIndex = 0
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnOk.ImageKey = "check2.ico"
      Me.btnOk.ImageList = Me.imgIconos
      Me.btnOk.Location = New System.Drawing.Point(206, 298)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(85, 30)
      Me.btnOk.TabIndex = 2
      Me.btnOk.Text = "&Seleccionar"
      Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "check2.ico")
      Me.imgIconos.Images.SetKeyName(1, "delete2.ico")
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageKey = "delete2.ico"
      Me.btnCancelar.ImageList = Me.imgIconos
      Me.btnCancelar.Location = New System.Drawing.Point(297, 298)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 1
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'FichasPendientes
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(394, 338)
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.dgvOperacionesPendientes)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FichasPendientes"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Operaciones"
      CType(Me.dgvOperacionesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
    Friend WithEvents dgvOperacionesPendientes As Eniac.Controles.DataGridView
    Friend WithEvents btnOk As Eniac.Controles.Button
    Friend WithEvents btnCancelar As Eniac.Controles.Button
    Friend WithEvents imgIconos As System.Windows.Forms.ImageList
End Class
