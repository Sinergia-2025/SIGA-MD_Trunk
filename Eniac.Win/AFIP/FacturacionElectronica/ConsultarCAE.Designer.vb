<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarCAE
    Inherits BaseForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarCAE))
      Me.tstBarra = New System.Windows.Forms.ToolStrip
      Me.tsbVerificarCAEs = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.dgvComprobantes = New System.Windows.Forms.DataGridView
      Me.colCuitEmisor = New Infragistics.Win.UltraDataGridView.UltraNumericEditorColumn(Me.components)
      Me.colTipoComprobante = New System.Windows.Forms.DataGridViewComboBoxColumn
      Me.colLetra = New System.Windows.Forms.DataGridViewComboBoxColumn
      Me.colPuntoVenta = New Infragistics.Win.UltraDataGridView.UltraNumericEditorColumn(Me.components)
      Me.colNroComprobante = New Infragistics.Win.UltraDataGridView.UltraNumericEditorColumn(Me.components)
      Me.colImporteTotal = New Infragistics.Win.UltraDataGridView.UltraCurrencyEditorColumn(Me.components)
      Me.colCAE = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.colFechaComprobante = New Infragistics.Win.UltraDataGridView.UltraDateTimeEditorColumn(Me.components)
      Me.colVerificar = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.tstBarra.SuspendLayout()
      CType(Me.dgvComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbVerificarCAEs, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(879, 29)
      Me.tstBarra.TabIndex = 3
      '
      'tsbVerificarCAEs
      '
      Me.tsbVerificarCAEs.Image = Global.Eniac.Win.My.Resources.Resources.numeric_field_ok_32
      Me.tsbVerificarCAEs.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbVerificarCAEs.Name = "tsbVerificarCAEs"
      Me.tsbVerificarCAEs.Size = New System.Drawing.Size(106, 26)
      Me.tsbVerificarCAEs.Text = "Verificar CAEs"
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
      'dgvComprobantes
      '
      Me.dgvComprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvComprobantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCuitEmisor, Me.colTipoComprobante, Me.colLetra, Me.colPuntoVenta, Me.colNroComprobante, Me.colImporteTotal, Me.colCAE, Me.colFechaComprobante, Me.colVerificar})
      Me.dgvComprobantes.Location = New System.Drawing.Point(12, 32)
      Me.dgvComprobantes.Name = "dgvComprobantes"
      Me.dgvComprobantes.RowHeadersVisible = False
      Me.dgvComprobantes.Size = New System.Drawing.Size(855, 239)
      Me.dgvComprobantes.TabIndex = 4
      '
      'colCuitEmisor
      '
      Me.colCuitEmisor.DefaultNewRowValue = CType(resources.GetObject("colCuitEmisor.DefaultNewRowValue"), Object)
      Me.colCuitEmisor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
      Me.colCuitEmisor.HeaderText = "CUIT Emisor"
      Me.colCuitEmisor.MaskInput = Nothing
      Me.colCuitEmisor.Name = "colCuitEmisor"
      Me.colCuitEmisor.PadChar = Global.Microsoft.VisualBasic.ChrW(0)
      Me.colCuitEmisor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.colCuitEmisor.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None
      '
      'colTipoComprobante
      '
      Me.colTipoComprobante.HeaderText = "Tipo Comprobante"
      Me.colTipoComprobante.Name = "colTipoComprobante"
      Me.colTipoComprobante.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.colTipoComprobante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      '
      'colLetra
      '
      Me.colLetra.HeaderText = "Letra"
      Me.colLetra.Items.AddRange(New Object() {"A", "B", "C"})
      Me.colLetra.Name = "colLetra"
      Me.colLetra.Width = 50
      '
      'colPuntoVenta
      '
      Me.colPuntoVenta.DefaultNewRowValue = CType(resources.GetObject("colPuntoVenta.DefaultNewRowValue"), Object)
      Me.colPuntoVenta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
      Me.colPuntoVenta.HeaderText = "Punto de venta"
      Me.colPuntoVenta.MaskInput = Nothing
      Me.colPuntoVenta.Name = "colPuntoVenta"
      Me.colPuntoVenta.PadChar = Global.Microsoft.VisualBasic.ChrW(0)
      Me.colPuntoVenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.colPuntoVenta.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None
      Me.colPuntoVenta.Width = 40
      '
      'colNroComprobante
      '
      Me.colNroComprobante.DefaultNewRowValue = CType(resources.GetObject("colNroComprobante.DefaultNewRowValue"), Object)
      Me.colNroComprobante.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
      Me.colNroComprobante.HeaderText = "Nro. Comprobante"
      Me.colNroComprobante.MaskInput = Nothing
      Me.colNroComprobante.Name = "colNroComprobante"
      Me.colNroComprobante.PadChar = Global.Microsoft.VisualBasic.ChrW(0)
      Me.colNroComprobante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.colNroComprobante.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None
      '
      'colImporteTotal
      '
      Me.colImporteTotal.DefaultNewRowValue = CType(resources.GetObject("colImporteTotal.DefaultNewRowValue"), Object)
      Me.colImporteTotal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
      Me.colImporteTotal.HeaderText = "Importe Total"
      Me.colImporteTotal.MaskInput = Nothing
      Me.colImporteTotal.Name = "colImporteTotal"
      Me.colImporteTotal.PadChar = Global.Microsoft.VisualBasic.ChrW(0)
      Me.colImporteTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.colImporteTotal.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None
      '
      'colCAE
      '
      Me.colCAE.HeaderText = "CAE"
      Me.colCAE.Name = "colCAE"
      '
      'colFechaComprobante
      '
      Me.colFechaComprobante.DefaultNewRowValue = CType(resources.GetObject("colFechaComprobante.DefaultNewRowValue"), Object)
      Me.colFechaComprobante.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
      Me.colFechaComprobante.DropDownCalendarAlignment = Infragistics.Win.DropDownListAlignment.Right
      Me.colFechaComprobante.FillWeight = 95.0!
      Me.colFechaComprobante.HeaderText = "Fecha Comprobante"
      Me.colFechaComprobante.MaskInput = Nothing
      Me.colFechaComprobante.Name = "colFechaComprobante"
      Me.colFechaComprobante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.colFechaComprobante.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None
      '
      'colVerificar
      '
      Me.colVerificar.HeaderText = "Verificar"
      Me.colVerificar.Name = "colVerificar"
      Me.colVerificar.ReadOnly = True
      Me.colVerificar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.colVerificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.colVerificar.Width = 70
      '
      'ConsultarCAE
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(879, 283)
      Me.Controls.Add(Me.dgvComprobantes)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "ConsultarCAE"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultar CAEs"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.dgvComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dgvComprobantes As System.Windows.Forms.DataGridView
   Friend WithEvents tsbVerificarCAEs As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents colCuitEmisor As Infragistics.Win.UltraDataGridView.UltraNumericEditorColumn
   Friend WithEvents colTipoComprobante As System.Windows.Forms.DataGridViewComboBoxColumn
   Friend WithEvents colLetra As System.Windows.Forms.DataGridViewComboBoxColumn
   Friend WithEvents colPuntoVenta As Infragistics.Win.UltraDataGridView.UltraNumericEditorColumn
   Friend WithEvents colNroComprobante As Infragistics.Win.UltraDataGridView.UltraNumericEditorColumn
   Friend WithEvents colImporteTotal As Infragistics.Win.UltraDataGridView.UltraCurrencyEditorColumn
   Friend WithEvents colCAE As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colFechaComprobante As Infragistics.Win.UltraDataGridView.UltraDateTimeEditorColumn
   Friend WithEvents colVerificar As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
