<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDashGraficador
   Inherits ucDashBase

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
      Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.pnlPanelGraficador = New System.Windows.Forms.Panel()
        Me.ckbDashBoard = New System.Windows.Forms.CheckBox()
        Me.pbxDashGraficador = New System.Windows.Forms.PictureBox()
        Me.gfcPrincipal = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lblTituloPrincipal = New System.Windows.Forms.Label()
        Me.lblComentarioPrincipal = New System.Windows.Forms.Label()
        Me.tmrDashBoard = New System.Windows.Forms.Timer(Me.components)
        Me.cdgDashBoard = New System.Windows.Forms.ColorDialog()
        Me.pnlPanelGraficador.SuspendLayout()
        CType(Me.pbxDashGraficador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gfcPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPanelGraficador
        '
        Me.pnlPanelGraficador.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.pnlPanelGraficador.BackgroundImage = Global.Eniac.Win.My.Resources.Resources.FondoDashBoard
        Me.pnlPanelGraficador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlPanelGraficador.Controls.Add(Me.ckbDashBoard)
        Me.pnlPanelGraficador.Controls.Add(Me.pbxDashGraficador)
        Me.pnlPanelGraficador.Controls.Add(Me.gfcPrincipal)
        Me.pnlPanelGraficador.Controls.Add(Me.lblTituloPrincipal)
        Me.pnlPanelGraficador.Controls.Add(Me.lblComentarioPrincipal)
        Me.pnlPanelGraficador.Location = New System.Drawing.Point(3, 3)
        Me.pnlPanelGraficador.Name = "pnlPanelGraficador"
        Me.pnlPanelGraficador.Size = New System.Drawing.Size(560, 318)
        Me.pnlPanelGraficador.TabIndex = 4
        '
        'ckbDashBoard
        '
        Me.ckbDashBoard.AutoSize = True
        Me.ckbDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.ckbDashBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbDashBoard.ForeColor = System.Drawing.Color.White
        Me.ckbDashBoard.Location = New System.Drawing.Point(474, 291)
        Me.ckbDashBoard.Name = "ckbDashBoard"
        Me.ckbDashBoard.Size = New System.Drawing.Size(79, 19)
        Me.ckbDashBoard.TabIndex = 10
        Me.ckbDashBoard.Text = "Refrescar"
        Me.ckbDashBoard.UseVisualStyleBackColor = False
        '
        'pbxDashGraficador
        '
        Me.pbxDashGraficador.BackColor = System.Drawing.Color.Transparent
        Me.pbxDashGraficador.ErrorImage = Nothing
        Me.pbxDashGraficador.Image = Global.Eniac.Win.My.Resources.Resources.BotonDashBoard
        Me.pbxDashGraficador.InitialImage = Nothing
        Me.pbxDashGraficador.Location = New System.Drawing.Point(501, 8)
        Me.pbxDashGraficador.Name = "pbxDashGraficador"
        Me.pbxDashGraficador.Size = New System.Drawing.Size(50, 50)
        Me.pbxDashGraficador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxDashGraficador.TabIndex = 7
        Me.pbxDashGraficador.TabStop = False
        '
        'gfcPrincipal
        '
        Me.gfcPrincipal.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.LineColor = System.Drawing.Color.White
        ChartArea1.AxisX.MajorGrid.IntervalOffset = 0R
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver
        ChartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White
        ChartArea1.AxisX.Title = "Prueba X"
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX.TitleForeColor = System.Drawing.Color.White
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelAutoFitStyle = CType((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Silver
        ChartArea1.AxisY.LineColor = System.Drawing.Color.Transparent
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Yellow
        ChartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White
        ChartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Red
        ChartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisY.Title = "Prueba Y"
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.TitleForeColor = System.Drawing.Color.White
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea"
        Me.gfcPrincipal.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.ForeColor = System.Drawing.Color.White
        Legend1.Name = "Leyenda00"
        Me.gfcPrincipal.Legends.Add(Legend1)
        Me.gfcPrincipal.Location = New System.Drawing.Point(3, 64)
        Me.gfcPrincipal.Name = "gfcPrincipal"
        Me.gfcPrincipal.Size = New System.Drawing.Size(554, 251)
        Me.gfcPrincipal.TabIndex = 6
        Me.gfcPrincipal.Text = "Principal"
        '
        'lblTituloPrincipal
        '
        Me.lblTituloPrincipal.BackColor = System.Drawing.Color.Transparent
        Me.lblTituloPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloPrincipal.ForeColor = System.Drawing.Color.White
        Me.lblTituloPrincipal.Location = New System.Drawing.Point(21, 9)
        Me.lblTituloPrincipal.Name = "lblTituloPrincipal"
        Me.lblTituloPrincipal.Size = New System.Drawing.Size(473, 31)
        Me.lblTituloPrincipal.TabIndex = 4
        Me.lblTituloPrincipal.Text = "Datos"
        '
        'lblComentarioPrincipal
        '
        Me.lblComentarioPrincipal.BackColor = System.Drawing.Color.Transparent
        Me.lblComentarioPrincipal.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblComentarioPrincipal.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblComentarioPrincipal.Location = New System.Drawing.Point(23, 42)
        Me.lblComentarioPrincipal.Name = "lblComentarioPrincipal"
        Me.lblComentarioPrincipal.Size = New System.Drawing.Size(472, 16)
        Me.lblComentarioPrincipal.TabIndex = 3
        Me.lblComentarioPrincipal.Text = "Titulo"
        '
        'tmrDashBoard
        '
        Me.tmrDashBoard.Interval = 1000
        '
        'ucDashGraficador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlPanelGraficador)
        Me.Name = "ucDashGraficador"
        Me.Size = New System.Drawing.Size(560, 318)
        Me.pnlPanelGraficador.ResumeLayout(False)
        Me.pnlPanelGraficador.PerformLayout()
        CType(Me.pbxDashGraficador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gfcPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pnlPanelGraficador As Panel
   Private WithEvents pbxDashGraficador As PictureBox
   Private WithEvents gfcPrincipal As DataVisualization.Charting.Chart
   Private WithEvents lblTituloPrincipal As Label
   Private WithEvents lblComentarioPrincipal As Label
   Friend WithEvents ckbDashBoard As CheckBox
   Friend WithEvents tmrDashBoard As Timer
   Friend WithEvents cdgDashBoard As ColorDialog
End Class
