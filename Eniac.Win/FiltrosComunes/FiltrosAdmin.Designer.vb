<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltrosAdmin
   Inherits System.Windows.Forms.Form

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
      Me.lsvFiltros = New System.Windows.Forms.ListView()
      Me.txtNombreArchivo = New System.Windows.Forms.TextBox()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'lsvFiltros
      '
      Me.lsvFiltros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lsvFiltros.Location = New System.Drawing.Point(0, 0)
      Me.lsvFiltros.Name = "lsvFiltros"
      Me.lsvFiltros.Size = New System.Drawing.Size(309, 251)
      Me.lsvFiltros.TabIndex = 2
      Me.lsvFiltros.UseCompatibleStateImageBehavior = False
      Me.lsvFiltros.View = System.Windows.Forms.View.Details
      '
      'txtNombreArchivo
      '
      Me.txtNombreArchivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNombreArchivo.Location = New System.Drawing.Point(2, 259)
      Me.txtNombreArchivo.MaxLength = 50
      Me.txtNombreArchivo.Name = "txtNombreArchivo"
      Me.txtNombreArchivo.Size = New System.Drawing.Size(211, 20)
      Me.txtNombreArchivo.TabIndex = 0
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.Location = New System.Drawing.Point(215, 258)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(90, 23)
      Me.btnOk.TabIndex = 1
      Me.btnOk.Text = "&Ok"
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'FiltrosAdmin
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(309, 284)
      Me.ControlBox = False
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.txtNombreArchivo)
      Me.Controls.Add(Me.lsvFiltros)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
      Me.KeyPreview = True
      Me.Name = "FiltrosAdmin"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Recuperar Filtros"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lsvFiltros As System.Windows.Forms.ListView
   Friend WithEvents txtNombreArchivo As System.Windows.Forms.TextBox
   Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
