<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfGenerales
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucConfGenerales))
      Me.pnlGeneralesSubtotalesEnGrillas = New System.Windows.Forms.Panel()
      Me.picGeneralesSubtotalesEnGrillas = New System.Windows.Forms.PictureBox()
      Me.pnlGeneralesSubtotalesEnGrillasFlow = New System.Windows.Forms.FlowLayoutPanel()
      Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador = New System.Windows.Forms.RadioButton()
      Me.radGeneralesSubtotalesEnGrillas_FinalDelGrupo = New System.Windows.Forms.RadioButton()
      Me.pnlGeneralesSubtotalesEnGrillas.SuspendLayout()
      CType(Me.picGeneralesSubtotalesEnGrillas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlGeneralesSubtotalesEnGrillasFlow.SuspendLayout()
      Me.SuspendLayout()
      '
      'pnlGeneralesSubtotalesEnGrillas
      '
      Me.pnlGeneralesSubtotalesEnGrillas.Controls.Add(Me.picGeneralesSubtotalesEnGrillas)
      Me.pnlGeneralesSubtotalesEnGrillas.Controls.Add(Me.pnlGeneralesSubtotalesEnGrillasFlow)
      Me.pnlGeneralesSubtotalesEnGrillas.Location = New System.Drawing.Point(59, 46)
      Me.pnlGeneralesSubtotalesEnGrillas.Name = "pnlGeneralesSubtotalesEnGrillas"
      Me.pnlGeneralesSubtotalesEnGrillas.Size = New System.Drawing.Size(778, 191)
      Me.pnlGeneralesSubtotalesEnGrillas.TabIndex = 59
      '
      'picGeneralesSubtotalesEnGrillas
      '
      Me.picGeneralesSubtotalesEnGrillas.Dock = System.Windows.Forms.DockStyle.Fill
      Me.picGeneralesSubtotalesEnGrillas.Image = CType(resources.GetObject("picGeneralesSubtotalesEnGrillas.Image"), System.Drawing.Image)
      Me.picGeneralesSubtotalesEnGrillas.Location = New System.Drawing.Point(287, 0)
      Me.picGeneralesSubtotalesEnGrillas.Name = "picGeneralesSubtotalesEnGrillas"
      Me.picGeneralesSubtotalesEnGrillas.Size = New System.Drawing.Size(491, 191)
      Me.picGeneralesSubtotalesEnGrillas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
      Me.picGeneralesSubtotalesEnGrillas.TabIndex = 1
      Me.picGeneralesSubtotalesEnGrillas.TabStop = False
      '
      'pnlGeneralesSubtotalesEnGrillasFlow
      '
      Me.pnlGeneralesSubtotalesEnGrillasFlow.AutoSize = True
      Me.pnlGeneralesSubtotalesEnGrillasFlow.Controls.Add(Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador)
      Me.pnlGeneralesSubtotalesEnGrillasFlow.Controls.Add(Me.radGeneralesSubtotalesEnGrillas_FinalDelGrupo)
      Me.pnlGeneralesSubtotalesEnGrillasFlow.Dock = System.Windows.Forms.DockStyle.Left
      Me.pnlGeneralesSubtotalesEnGrillasFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
      Me.pnlGeneralesSubtotalesEnGrillasFlow.Location = New System.Drawing.Point(0, 0)
      Me.pnlGeneralesSubtotalesEnGrillasFlow.Name = "pnlGeneralesSubtotalesEnGrillasFlow"
      Me.pnlGeneralesSubtotalesEnGrillasFlow.Size = New System.Drawing.Size(287, 191)
      Me.pnlGeneralesSubtotalesEnGrillasFlow.TabIndex = 0
      '
      'radGeneralesSubtotalesEnGrillas_FilaAgrupador
      '
      Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador.AutoSize = True
      Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador.Checked = True
      Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador.Location = New System.Drawing.Point(3, 3)
      Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador.Name = "radGeneralesSubtotalesEnGrillas_FilaAgrupador"
      Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador.Size = New System.Drawing.Size(275, 17)
      Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador.TabIndex = 0
      Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador.TabStop = True
      Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador.Text = "Mostrar los totales de los grupos en la fila agrupadora"
      Me.radGeneralesSubtotalesEnGrillas_FilaAgrupador.UseVisualStyleBackColor = True
      '
      'radGeneralesSubtotalesEnGrillas_FinalDelGrupo
      '
      Me.radGeneralesSubtotalesEnGrillas_FinalDelGrupo.AutoSize = True
      Me.radGeneralesSubtotalesEnGrillas_FinalDelGrupo.Location = New System.Drawing.Point(3, 26)
      Me.radGeneralesSubtotalesEnGrillas_FinalDelGrupo.Name = "radGeneralesSubtotalesEnGrillas_FinalDelGrupo"
      Me.radGeneralesSubtotalesEnGrillas_FinalDelGrupo.Size = New System.Drawing.Size(281, 17)
      Me.radGeneralesSubtotalesEnGrillas_FinalDelGrupo.TabIndex = 1
      Me.radGeneralesSubtotalesEnGrillas_FinalDelGrupo.TabStop = True
      Me.radGeneralesSubtotalesEnGrillas_FinalDelGrupo.Text = "Mostrar los totales de los grupos al final de cada grupo"
      Me.radGeneralesSubtotalesEnGrillas_FinalDelGrupo.UseVisualStyleBackColor = True
      '
      'ucConfGenerales
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.pnlGeneralesSubtotalesEnGrillas)
      Me.Name = "ucConfGenerales"
      Me.Controls.SetChildIndex(Me.pnlGeneralesSubtotalesEnGrillas, 0)
      Me.pnlGeneralesSubtotalesEnGrillas.ResumeLayout(False)
      Me.pnlGeneralesSubtotalesEnGrillas.PerformLayout()
      CType(Me.picGeneralesSubtotalesEnGrillas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlGeneralesSubtotalesEnGrillasFlow.ResumeLayout(False)
      Me.pnlGeneralesSubtotalesEnGrillasFlow.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents pnlGeneralesSubtotalesEnGrillas As Panel
   Friend WithEvents picGeneralesSubtotalesEnGrillas As PictureBox
   Friend WithEvents pnlGeneralesSubtotalesEnGrillasFlow As FlowLayoutPanel
   Friend WithEvents radGeneralesSubtotalesEnGrillas_FilaAgrupador As RadioButton
   Friend WithEvents radGeneralesSubtotalesEnGrillas_FinalDelGrupo As RadioButton
End Class
