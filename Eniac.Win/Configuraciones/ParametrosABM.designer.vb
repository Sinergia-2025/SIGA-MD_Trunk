<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParametrosABM
   Inherits Eniac.Win.BaseABM2

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Dise�ador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Dise�ador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Dise�ador de Windows Forms.  
    'No lo modifique con el editor de c�digo.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'dgvDatos
      '
      Me.dgvDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre un titulo de columna aqu� para agrupar."
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
      Me.dgvDatos.Size = New System.Drawing.Size(984, 510)
      '
      'ParametrosABM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(984, 561)
      Me.Cursor = System.Windows.Forms.Cursors.Default
      Me.Name = "ParametrosABM"
      Me.Text = "Par�metros"
      CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

End Class