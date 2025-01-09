<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmpleadosABM
    Inherits BaseABM2

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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmpleadosABM))
        Me.UltraTextEditor1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDatos
        '
        UltraGridBand1.Header.FixOnRight = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDatos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre un titulo de columna aquí para agrupar."
        Me.dgvDatos.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvDatos.DisplayLayout.MaxRowScrollRegions = 1
        Me.dgvDatos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Appearance1.BorderColor = System.Drawing.Color.Silver
        Me.dgvDatos.DisplayLayout.Override.CellAppearance = Appearance1
        Me.dgvDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Appearance2.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.FixedHeaderAppearance = Appearance2
        Appearance3.ForeColor = System.Drawing.Color.ForestGreen
        Me.dgvDatos.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.dgvDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.HotTrackHeaderAppearance = Appearance4
        Appearance5.BorderColor = System.Drawing.Color.Silver
        Me.dgvDatos.DisplayLayout.Override.RowAppearance = Appearance5
        Appearance6.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance6
        Me.dgvDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.dgvDatos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
        Me.dgvDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvDatos.Size = New System.Drawing.Size(934, 411)
        '
        'UltraTextEditor1
        '
        Me.UltraTextEditor1.Location = New System.Drawing.Point(695, 224)
        Me.UltraTextEditor1.Name = "UltraTextEditor1"
        Me.UltraTextEditor1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.UltraTextEditor1.Size = New System.Drawing.Size(100, 21)
        Me.UltraTextEditor1.TabIndex = 7
        Me.UltraTextEditor1.Visible = False
        '
        'EmpleadosABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(934, 462)
        Me.Controls.Add(Me.UltraTextEditor1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EmpleadosABM"
        Me.Text = "Empleados"
        Me.Controls.SetChildIndex(Me.dgvDatos, 0)
        Me.Controls.SetChildIndex(Me.UltraTextEditor1, 0)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraTextEditor1 As Infragistics.Win.UltraWinEditors.UltraTextEditor

End Class
