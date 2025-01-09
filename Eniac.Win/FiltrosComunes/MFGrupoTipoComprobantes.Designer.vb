<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MFGrupoTipoComprobantes
    Inherits BaseMultiplesFiltros2

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        CType(Me.ugbProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbProductos.SuspendLayout()
        Me.grbCuerpo.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCabeza.SuspendLayout()
        Me.grbPie.SuspendLayout()
        Me.SuspendLayout()
        '
        'ugbProductos
        '
        Me.ugbProductos.Size = New System.Drawing.Size(416, 526)
        Me.ugbProductos.TabIndex = 0
        '
        'grbCuerpo
        '
        Me.grbCuerpo.Size = New System.Drawing.Size(410, 379)
        '
        'dgvDatos
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvDatos.DisplayLayout.Appearance = Appearance1
        Me.dgvDatos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvDatos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDatos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Me.dgvDatos.DisplayLayout.MaxBandDepth = 1
        Me.dgvDatos.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvDatos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDatos.DisplayLayout.Override.ActiveCellAppearance = Appearance2
        Appearance3.BackColor = System.Drawing.SystemColors.Highlight
        Appearance3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDatos.DisplayLayout.Override.ActiveRowAppearance = Appearance3
        Me.dgvDatos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvDatos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDatos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDatos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgvDatos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Me.dgvDatos.DisplayLayout.Override.CardAreaAppearance = Appearance4
        Appearance5.BorderColor = System.Drawing.Color.Silver
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgvDatos.DisplayLayout.Override.CellAppearance = Appearance5
        Me.dgvDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgvDatos.DisplayLayout.Override.CellPadding = 0
        Appearance6.BackColor = System.Drawing.SystemColors.Control
        Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvDatos.DisplayLayout.Override.GroupByRowAppearance = Appearance6
        Appearance7.TextHAlignAsString = "Left"
        Me.dgvDatos.DisplayLayout.Override.HeaderAppearance = Appearance7
        Me.dgvDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgvDatos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Me.dgvDatos.DisplayLayout.Override.RowAppearance = Appearance8
        Me.dgvDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgvDatos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance9
        Me.dgvDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvDatos.Size = New System.Drawing.Size(404, 360)
        '
        'lnkAgregarTodos
        '
        Me.lnkAgregarTodos.TabIndex = 6
        '
        'bscNombre
        '
        Me.bscNombre.Location = New System.Drawing.Point(161, 15)
        Me.bscNombre.Size = New System.Drawing.Size(243, 20)
        Me.bscNombre.TabIndex = 2
        '
        'bscCodigo
        '
        Me.bscCodigo.MaxLengh = "30"
        Me.bscCodigo.Size = New System.Drawing.Size(147, 20)
        '
        'btnInsertar
        '
        Me.btnInsertar.TabIndex = 4
        '
        'btnEliminar
        '
        Me.btnEliminar.TabIndex = 5
        '
        'grbPie
        '
        Me.grbPie.Location = New System.Drawing.Point(3, 479)
        '
        'MFGrupoTipoComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 526)
        Me.Name = "MFGrupoTipoComprobantes"
        Me.Text = "Grupo de Tipos Comprobantes"
        CType(Me.ugbProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbProductos.ResumeLayout(False)
        Me.grbCuerpo.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCabeza.ResumeLayout(False)
        Me.grbCabeza.PerformLayout()
        Me.grbPie.ResumeLayout(False)
        Me.grbPie.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
End Class
