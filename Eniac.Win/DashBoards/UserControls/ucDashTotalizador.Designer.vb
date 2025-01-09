<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDashTotalizador
   Inherits ucDashBase

   'UserControl overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.pnlPanelTotalizador = New System.Windows.Forms.Panel()
      Me.ckbDashBoard = New System.Windows.Forms.CheckBox()
      Me.flpSeparadorTotalizador = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblTituloComentario = New System.Windows.Forms.Label()
      Me.pbxDashTotalizador = New System.Windows.Forms.PictureBox()
      Me.lblDatosPrincipales = New System.Windows.Forms.Label()
      Me.lblTituloPrincipal = New System.Windows.Forms.Label()
      Me.tmrDashBoard = New System.Windows.Forms.Timer(Me.components)
        Me.pnlPanelTotalizador.SuspendLayout()
        CType(Me.pbxDashTotalizador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPanelTotalizador
        '
        Me.pnlPanelTotalizador.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.FondoDashBoard
        Me.pnlPanelTotalizador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlPanelTotalizador.Controls.Add(Me.ckbDashBoard)
        Me.pnlPanelTotalizador.Controls.Add(Me.flpSeparadorTotalizador)
        Me.pnlPanelTotalizador.Controls.Add(Me.lblTituloComentario)
        Me.pnlPanelTotalizador.Controls.Add(Me.pbxDashTotalizador)
        Me.pnlPanelTotalizador.Controls.Add(Me.lblDatosPrincipales)
        Me.pnlPanelTotalizador.Controls.Add(Me.lblTituloPrincipal)
        Me.pnlPanelTotalizador.Location = New System.Drawing.Point(0, 0)
        Me.pnlPanelTotalizador.Name = "pnlPanelTotalizador"
        Me.pnlPanelTotalizador.Size = New System.Drawing.Size(372, 124)
        Me.pnlPanelTotalizador.TabIndex = 4
        '
        'ckbDashBoard
        '
        Me.ckbDashBoard.AutoSize = True
        Me.ckbDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.ckbDashBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbDashBoard.ForeColor = System.Drawing.Color.White
        Me.ckbDashBoard.Location = New System.Drawing.Point(283, 90)
        Me.ckbDashBoard.Name = "ckbDashBoard"
        Me.ckbDashBoard.Size = New System.Drawing.Size(79, 19)
        Me.ckbDashBoard.TabIndex = 9
        Me.ckbDashBoard.Text = "Refrescar"
        Me.ckbDashBoard.UseVisualStyleBackColor = False
        '
        'flpSeparadorTotalizador
        '
        Me.flpSeparadorTotalizador.BackColor = System.Drawing.Color.Silver
        Me.flpSeparadorTotalizador.Location = New System.Drawing.Point(17, 80)
        Me.flpSeparadorTotalizador.Name = "flpSeparadorTotalizador"
        Me.flpSeparadorTotalizador.Size = New System.Drawing.Size(341, 1)
        Me.flpSeparadorTotalizador.TabIndex = 5
        '
        'lblTituloComentario
        '
        Me.lblTituloComentario.BackColor = System.Drawing.Color.Transparent
        Me.lblTituloComentario.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloComentario.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblTituloComentario.Location = New System.Drawing.Point(13, 91)
        Me.lblTituloComentario.Name = "lblTituloComentario"
        Me.lblTituloComentario.Size = New System.Drawing.Size(264, 16)
        Me.lblTituloComentario.TabIndex = 4
        Me.lblTituloComentario.Text = "Comentario"
        '
        'pbxDashTotalizador
        '
        Me.pbxDashTotalizador.BackColor = System.Drawing.Color.Transparent
        Me.pbxDashTotalizador.ErrorImage = Nothing
        Me.pbxDashTotalizador.Image = Global.Eniac.Win.My.Resources.Resources.BotonDashBoard
        Me.pbxDashTotalizador.InitialImage = Nothing
        Me.pbxDashTotalizador.Location = New System.Drawing.Point(16, 14)
        Me.pbxDashTotalizador.Name = "pbxDashTotalizador"
        Me.pbxDashTotalizador.Size = New System.Drawing.Size(50, 50)
        Me.pbxDashTotalizador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxDashTotalizador.TabIndex = 1
        Me.pbxDashTotalizador.TabStop = False
        '
        'lblDatosPrincipales
        '
        Me.lblDatosPrincipales.BackColor = System.Drawing.Color.Transparent
        Me.lblDatosPrincipales.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosPrincipales.ForeColor = System.Drawing.Color.White
        Me.lblDatosPrincipales.Location = New System.Drawing.Point(83, 31)
        Me.lblDatosPrincipales.Name = "lblDatosPrincipales"
        Me.lblDatosPrincipales.Size = New System.Drawing.Size(275, 30)
        Me.lblDatosPrincipales.TabIndex = 2
        Me.lblDatosPrincipales.Text = "Datos"
        Me.lblDatosPrincipales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTituloPrincipal
        '
        Me.lblTituloPrincipal.BackColor = System.Drawing.Color.Transparent
        Me.lblTituloPrincipal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloPrincipal.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblTituloPrincipal.Location = New System.Drawing.Point(83, 14)
        Me.lblTituloPrincipal.Name = "lblTituloPrincipal"
        Me.lblTituloPrincipal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTituloPrincipal.Size = New System.Drawing.Size(274, 16)
        Me.lblTituloPrincipal.TabIndex = 1
        Me.lblTituloPrincipal.Text = "Titulo"
        Me.lblTituloPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrDashBoard
        '
        Me.tmrDashBoard.Interval = 1000
        '
        'ucDashTotalizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlPanelTotalizador)
        Me.Name = "ucDashTotalizador"
        Me.Size = New System.Drawing.Size(374, 127)
        Me.pnlPanelTotalizador.ResumeLayout(False)
        Me.pnlPanelTotalizador.PerformLayout()
        CType(Me.pbxDashTotalizador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    ''' <summary>
    ''' Elementos del UserControl.- ---
    ''' </summary>
    Private WithEvents pnlPanelTotalizador As Panel
   Friend WithEvents flpSeparadorTotalizador As FlowLayoutPanel
   Private WithEvents lblTituloComentario As Label
   Private WithEvents pbxDashTotalizador As PictureBox
   Private WithEvents lblDatosPrincipales As Label
   Private WithEvents lblTituloPrincipal As Label
    Friend WithEvents ckbDashBoard As CheckBox
    Friend WithEvents tmrDashBoard As Timer
End Class
