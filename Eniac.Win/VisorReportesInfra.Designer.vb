<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisorReportesInfra
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
      Me.components = New System.ComponentModel.Container()
      Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("Menu")
      Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Imprimir")
      Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Imprimir")
      Me.upcDocumento = New Infragistics.Win.Printing.UltraPrintPreviewControl()
      Me.uptImagenes = New Infragistics.Win.Printing.UltraPrintPreviewThumbnail()
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.VisorReportesInfra_Fill_Panel = New System.Windows.Forms.Panel()
      Me.UltraToolbarsManager1 = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
      Me._VisorReportesInfra_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
      Me._VisorReportesInfra_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
      Me._VisorReportesInfra_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
      Me._VisorReportesInfra_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
      CType(Me.upcDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.uptImagenes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.VisorReportesInfra_Fill_Panel.SuspendLayout()
      CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'upcDocumento
      '
      Me.upcDocumento.BackColorInternal = System.Drawing.SystemColors.ControlDark
      Me.upcDocumento.Dock = System.Windows.Forms.DockStyle.Fill
      Me.upcDocumento.ForeColor = System.Drawing.SystemColors.ControlLightLight
      Me.upcDocumento.Location = New System.Drawing.Point(0, 0)
      Me.upcDocumento.Name = "upcDocumento"
      Me.upcDocumento.Size = New System.Drawing.Size(506, 418)
      Me.upcDocumento.TabIndex = 0
      '
      'uptImagenes
      '
      Me.uptImagenes.BackColorInternal = System.Drawing.SystemColors.ControlDark
      Me.uptImagenes.Dock = System.Windows.Forms.DockStyle.Fill
      Me.uptImagenes.ForeColor = System.Drawing.SystemColors.ControlLightLight
      Me.uptImagenes.Location = New System.Drawing.Point(0, 0)
      Me.uptImagenes.Name = "uptImagenes"
      Me.uptImagenes.PreviewControl = Me.upcDocumento
      Me.uptImagenes.Size = New System.Drawing.Size(255, 418)
      Me.uptImagenes.TabIndex = 1
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Name = "SplitContainer1"
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.uptImagenes)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.upcDocumento)
      Me.SplitContainer1.Size = New System.Drawing.Size(765, 418)
      Me.SplitContainer1.SplitterDistance = 255
      Me.SplitContainer1.TabIndex = 2
      '
      'VisorReportesInfra_Fill_Panel
      '
      Me.VisorReportesInfra_Fill_Panel.Controls.Add(Me.SplitContainer1)
      Me.VisorReportesInfra_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
      Me.VisorReportesInfra_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.VisorReportesInfra_Fill_Panel.Location = New System.Drawing.Point(0, 25)
      Me.VisorReportesInfra_Fill_Panel.Name = "VisorReportesInfra_Fill_Panel"
      Me.VisorReportesInfra_Fill_Panel.Size = New System.Drawing.Size(765, 418)
      Me.VisorReportesInfra_Fill_Panel.TabIndex = 0
      '
      'UltraToolbarsManager1
      '
      Me.UltraToolbarsManager1.DesignerFlags = 1
      Me.UltraToolbarsManager1.DockWithinContainer = Me
      Me.UltraToolbarsManager1.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
      UltraToolbar1.DockedColumn = 0
      UltraToolbar1.DockedRow = 0
      UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool3})
      UltraToolbar1.Text = "Menu"
      Me.UltraToolbarsManager1.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
      ButtonTool4.SharedPropsInternal.Caption = "Imprimir"
      ButtonTool4.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
      Me.UltraToolbarsManager1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool4})
      '
      '_VisorReportesInfra_Toolbars_Dock_Area_Left
      '
      Me._VisorReportesInfra_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
      Me._VisorReportesInfra_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control
      Me._VisorReportesInfra_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
      Me._VisorReportesInfra_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
      Me._VisorReportesInfra_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 25)
      Me._VisorReportesInfra_Toolbars_Dock_Area_Left.Name = "_VisorReportesInfra_Toolbars_Dock_Area_Left"
      Me._VisorReportesInfra_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 418)
      Me._VisorReportesInfra_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager1
      '
      '_VisorReportesInfra_Toolbars_Dock_Area_Right
      '
      Me._VisorReportesInfra_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
      Me._VisorReportesInfra_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control
      Me._VisorReportesInfra_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
      Me._VisorReportesInfra_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
      Me._VisorReportesInfra_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(765, 25)
      Me._VisorReportesInfra_Toolbars_Dock_Area_Right.Name = "_VisorReportesInfra_Toolbars_Dock_Area_Right"
      Me._VisorReportesInfra_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 418)
      Me._VisorReportesInfra_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager1
      '
      '_VisorReportesInfra_Toolbars_Dock_Area_Top
      '
      Me._VisorReportesInfra_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
      Me._VisorReportesInfra_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control
      Me._VisorReportesInfra_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
      Me._VisorReportesInfra_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
      Me._VisorReportesInfra_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
      Me._VisorReportesInfra_Toolbars_Dock_Area_Top.Name = "_VisorReportesInfra_Toolbars_Dock_Area_Top"
      Me._VisorReportesInfra_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(765, 25)
      Me._VisorReportesInfra_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager1
      '
      '_VisorReportesInfra_Toolbars_Dock_Area_Bottom
      '
      Me._VisorReportesInfra_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
      Me._VisorReportesInfra_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
      Me._VisorReportesInfra_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
      Me._VisorReportesInfra_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
      Me._VisorReportesInfra_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 443)
      Me._VisorReportesInfra_Toolbars_Dock_Area_Bottom.Name = "_VisorReportesInfra_Toolbars_Dock_Area_Bottom"
      Me._VisorReportesInfra_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(765, 0)
      Me._VisorReportesInfra_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager1
      '
      'VisorReportesInfra
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(765, 443)
      Me.Controls.Add(Me.VisorReportesInfra_Fill_Panel)
      Me.Controls.Add(Me._VisorReportesInfra_Toolbars_Dock_Area_Left)
      Me.Controls.Add(Me._VisorReportesInfra_Toolbars_Dock_Area_Right)
      Me.Controls.Add(Me._VisorReportesInfra_Toolbars_Dock_Area_Top)
      Me.Controls.Add(Me._VisorReportesInfra_Toolbars_Dock_Area_Bottom)
      Me.Name = "VisorReportesInfra"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "VisorReportesInfra"
      CType(Me.upcDocumento, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.uptImagenes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      Me.VisorReportesInfra_Fill_Panel.ResumeLayout(False)
      CType(Me.UltraToolbarsManager1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Public WithEvents upcDocumento As Infragistics.Win.Printing.UltraPrintPreviewControl
   Friend WithEvents uptImagenes As Infragistics.Win.Printing.UltraPrintPreviewThumbnail
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents VisorReportesInfra_Fill_Panel As System.Windows.Forms.Panel
   Friend WithEvents UltraToolbarsManager1 As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
   Friend WithEvents _VisorReportesInfra_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
   Friend WithEvents _VisorReportesInfra_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
   Friend WithEvents _VisorReportesInfra_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
   Friend WithEvents _VisorReportesInfra_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
End Class
