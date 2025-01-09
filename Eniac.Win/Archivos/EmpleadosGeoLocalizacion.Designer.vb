<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmpleadosGeoLocalizacion
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
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbObtenerEmpleados = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.gmcMapa = New GMap.NET.WindowsForms.GMapControl()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.tcbZoom = New System.Windows.Forms.TrackBar()
        Me.cmbTipoMapa = New System.Windows.Forms.ComboBox()
        Me.lblMaximo = New System.Windows.Forms.Label()
        Me.nudMaximoAMostrar = New System.Windows.Forms.NumericUpDown()
        Me.trvEmpleados = New System.Windows.Forms.TreeView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tstBarra.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.tcbZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaximoAMostrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbObtenerEmpleados, Me.ToolStripSeparator1, Me.tsbSalir, Me.ToolStripSeparator4})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(917, 29)
        Me.tstBarra.TabIndex = 1
        '
        'tsbObtenerEmpleados
        '
        Me.tsbObtenerEmpleados.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbObtenerEmpleados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbObtenerEmpleados.Name = "tsbObtenerEmpleados"
        Me.tsbObtenerEmpleados.Size = New System.Drawing.Size(137, 26)
        Me.tsbObtenerEmpleados.Text = "&Obtener Empleados"
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'gmcMapa
        '
        Me.gmcMapa.AutoScroll = True
        Me.gmcMapa.Bearing = 0.0!
        Me.gmcMapa.CanDragMap = True
        Me.gmcMapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gmcMapa.EmptyTileColor = System.Drawing.Color.Navy
        Me.gmcMapa.GrayScaleMode = False
        Me.gmcMapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.gmcMapa.LevelsKeepInMemmory = 5
        Me.gmcMapa.Location = New System.Drawing.Point(0, 0)
        Me.gmcMapa.MarkersEnabled = True
        Me.gmcMapa.MaxZoom = 18
        Me.gmcMapa.MinZoom = 2
        Me.gmcMapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.gmcMapa.Name = "gmcMapa"
        Me.gmcMapa.NegativeMode = False
        Me.gmcMapa.PolygonsEnabled = True
        Me.gmcMapa.RetryLoadTile = 0
        Me.gmcMapa.RoutesEnabled = True
        Me.gmcMapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.gmcMapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.gmcMapa.ShowTileGridLines = False
        Me.gmcMapa.Size = New System.Drawing.Size(724, 455)
        Me.gmcMapa.TabIndex = 2
        Me.gmcMapa.Zoom = 0.0R
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 29)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gmcMapa)
        Me.SplitContainer1.Size = New System.Drawing.Size(917, 455)
        Me.SplitContainer1.SplitterDistance = 189
        Me.SplitContainer1.TabIndex = 3
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tcbZoom)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbTipoMapa)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblMaximo)
        Me.SplitContainer2.Panel1.Controls.Add(Me.nudMaximoAMostrar)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.trvEmpleados)
        Me.SplitContainer2.Size = New System.Drawing.Size(189, 455)
        Me.SplitContainer2.SplitterDistance = 112
        Me.SplitContainer2.TabIndex = 1
        '
        'tcbZoom
        '
        Me.tcbZoom.AccessibleDescription = ""
        Me.tcbZoom.LargeChange = 18
        Me.tcbZoom.Location = New System.Drawing.Point(3, 61)
        Me.tcbZoom.Name = "tcbZoom"
        Me.tcbZoom.Size = New System.Drawing.Size(155, 45)
        Me.tcbZoom.TabIndex = 3
        Me.tcbZoom.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'cmbTipoMapa
        '
        Me.cmbTipoMapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMapa.FormattingEnabled = True
        Me.cmbTipoMapa.Items.AddRange(New Object() {"Google Maps", "Google Satelite Maps"})
        Me.cmbTipoMapa.Location = New System.Drawing.Point(12, 34)
        Me.cmbTipoMapa.Name = "cmbTipoMapa"
        Me.cmbTipoMapa.Size = New System.Drawing.Size(137, 21)
        Me.cmbTipoMapa.TabIndex = 2
        '
        'lblMaximo
        '
        Me.lblMaximo.AutoSize = True
        Me.lblMaximo.Location = New System.Drawing.Point(55, 15)
        Me.lblMaximo.Name = "lblMaximo"
        Me.lblMaximo.Size = New System.Drawing.Size(51, 13)
        Me.lblMaximo.TabIndex = 1
        Me.lblMaximo.Text = "Registros"
        '
        'nudMaximoAMostrar
        '
        Me.nudMaximoAMostrar.Location = New System.Drawing.Point(12, 8)
        Me.nudMaximoAMostrar.Name = "nudMaximoAMostrar"
        Me.nudMaximoAMostrar.Size = New System.Drawing.Size(42, 20)
        Me.nudMaximoAMostrar.TabIndex = 0
        Me.nudMaximoAMostrar.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'trvEmpleados
        '
        Me.trvEmpleados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvEmpleados.Location = New System.Drawing.Point(0, 0)
        Me.trvEmpleados.Name = "trvEmpleados"
        Me.trvEmpleados.Size = New System.Drawing.Size(189, 339)
        Me.trvEmpleados.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslInfo, Me.tspBarra})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 462)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(917, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslInfo
        '
        Me.tslInfo.Name = "tslInfo"
        Me.tslInfo.Size = New System.Drawing.Size(902, 17)
        Me.tslInfo.Spring = True
        Me.tslInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Visible = False
        '
        'EmpleadosGeoLocalizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 484)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "EmpleadosGeoLocalizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empleados - Localización Geográfica (Mapa)"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.tcbZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaximoAMostrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Public WithEvents tsbObtenerEmpleados As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gmcMapa As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents trvEmpleados As System.Windows.Forms.TreeView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tslInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents nudMaximoAMostrar As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMaximo As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMapa As System.Windows.Forms.ComboBox
    Friend WithEvents tcbZoom As System.Windows.Forms.TrackBar
End Class
