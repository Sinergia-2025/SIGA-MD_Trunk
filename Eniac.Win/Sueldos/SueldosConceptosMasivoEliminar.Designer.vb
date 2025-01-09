<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosConceptosMasivoEliminar
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
      Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Personal", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLegajo")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombrePersonal")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocPersonal")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocPersonal")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Domicilio")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Check", 0)
      Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
      Me.grpConceptos = New System.Windows.Forms.GroupBox
      Me.btnConsultar = New Eniac.Controles.Button
      Me.bscCodigoConcepto = New Eniac.Controles.Buscador
      Me.lblCodigoConcepto = New Eniac.Controles.Label
      Me.bscNombreConcepto = New Eniac.Controles.Buscador
      Me.lblNombreConcepto = New Eniac.Controles.Label
      Me.grpModalidad = New System.Windows.Forms.GroupBox
      Me.RadioModoAguinaldo = New System.Windows.Forms.RadioButton
      Me.RadioModoNormal = New System.Windows.Forms.RadioButton
      Me.PersonalBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
      Me.ugvPersonal = New Infragistics.Win.UltraWinGrid.UltraGrid
      Me.PersonalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DataSetSueldos = New Eniac.Win.DataSetSueldos
      Me.chbPersonalSeleccionarTodos = New Eniac.Controles.CheckBox
      Me.tstBarra = New System.Windows.Forms.ToolStrip
      Me.tsbEliminar = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton
      Me.btnLimpiar = New Eniac.Controles.Button
      Me.grpConceptos.SuspendLayout()
      Me.grpModalidad.SuspendLayout()
      CType(Me.PersonalBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugvPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PersonalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataSetSueldos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'grpConceptos
      '
      Me.grpConceptos.Controls.Add(Me.btnLimpiar)
      Me.grpConceptos.Controls.Add(Me.btnConsultar)
      Me.grpConceptos.Controls.Add(Me.bscCodigoConcepto)
      Me.grpConceptos.Controls.Add(Me.lblCodigoConcepto)
      Me.grpConceptos.Controls.Add(Me.bscNombreConcepto)
      Me.grpConceptos.Controls.Add(Me.lblNombreConcepto)
      Me.grpConceptos.Controls.Add(Me.grpModalidad)
      Me.grpConceptos.Location = New System.Drawing.Point(10, 27)
      Me.grpConceptos.Name = "grpConceptos"
      Me.grpConceptos.Size = New System.Drawing.Size(581, 70)
      Me.grpConceptos.TabIndex = 1
      Me.grpConceptos.TabStop = False
      Me.grpConceptos.Text = "Seleccion de conceptos"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Enabled = False
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(475, 20)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 12
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'bscCodigoConcepto
      '
      Me.bscCodigoConcepto.BindearPropiedadControl = Nothing
      Me.bscCodigoConcepto.BindearPropiedadEntidad = Nothing
      Me.bscCodigoConcepto.ColumnasAlineacion = Nothing
      Me.bscCodigoConcepto.ColumnasAncho = Nothing
      Me.bscCodigoConcepto.ColumnasFormato = Nothing
      Me.bscCodigoConcepto.ColumnasOcultas = Nothing
      Me.bscCodigoConcepto.ColumnasTitulos = Nothing
      Me.bscCodigoConcepto.Datos = Nothing
      Me.bscCodigoConcepto.FilaDevuelta = Nothing
      Me.bscCodigoConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoConcepto.IsDecimal = False
      Me.bscCodigoConcepto.IsNumber = True
      Me.bscCodigoConcepto.IsPK = False
      Me.bscCodigoConcepto.IsRequired = False
      Me.bscCodigoConcepto.Key = ""
      Me.bscCodigoConcepto.LabelAsoc = Me.lblCodigoConcepto
      Me.bscCodigoConcepto.Location = New System.Drawing.Point(133, 41)
      Me.bscCodigoConcepto.Name = "bscCodigoConcepto"
      Me.bscCodigoConcepto.Selecciono = False
      Me.bscCodigoConcepto.Size = New System.Drawing.Size(107, 23)
      Me.bscCodigoConcepto.TabIndex = 2
      Me.bscCodigoConcepto.Titulo = Nothing
      '
      'lblCodigoConcepto
      '
      Me.lblCodigoConcepto.AutoSize = True
      Me.lblCodigoConcepto.Location = New System.Drawing.Point(131, 26)
      Me.lblCodigoConcepto.Name = "lblCodigoConcepto"
      Me.lblCodigoConcepto.Size = New System.Drawing.Size(53, 13)
      Me.lblCodigoConcepto.TabIndex = 0
      Me.lblCodigoConcepto.Text = "Concepto"
      '
      'bscNombreConcepto
      '
      Me.bscNombreConcepto.AutoSize = True
      Me.bscNombreConcepto.BindearPropiedadControl = Nothing
      Me.bscNombreConcepto.BindearPropiedadEntidad = Nothing
      Me.bscNombreConcepto.ColumnasAlineacion = Nothing
      Me.bscNombreConcepto.ColumnasAncho = Nothing
      Me.bscNombreConcepto.ColumnasFormato = Nothing
      Me.bscNombreConcepto.ColumnasOcultas = Nothing
      Me.bscNombreConcepto.ColumnasTitulos = Nothing
      Me.bscNombreConcepto.Datos = Nothing
      Me.bscNombreConcepto.FilaDevuelta = Nothing
      Me.bscNombreConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreConcepto.IsDecimal = False
      Me.bscNombreConcepto.IsNumber = False
      Me.bscNombreConcepto.IsPK = False
      Me.bscNombreConcepto.IsRequired = False
      Me.bscNombreConcepto.Key = ""
      Me.bscNombreConcepto.LabelAsoc = Me.lblNombreConcepto
      Me.bscNombreConcepto.Location = New System.Drawing.Point(243, 41)
      Me.bscNombreConcepto.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreConcepto.Name = "bscNombreConcepto"
      Me.bscNombreConcepto.Selecciono = False
      Me.bscNombreConcepto.Size = New System.Drawing.Size(223, 23)
      Me.bscNombreConcepto.TabIndex = 3
      Me.bscNombreConcepto.Titulo = Nothing
      '
      'lblNombreConcepto
      '
      Me.lblNombreConcepto.AutoSize = True
      Me.lblNombreConcepto.Location = New System.Drawing.Point(240, 24)
      Me.lblNombreConcepto.Name = "lblNombreConcepto"
      Me.lblNombreConcepto.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreConcepto.TabIndex = 2
      Me.lblNombreConcepto.Text = "Nombre"
      '
      'grpModalidad
      '
      Me.grpModalidad.Controls.Add(Me.RadioModoAguinaldo)
      Me.grpModalidad.Controls.Add(Me.RadioModoNormal)
      Me.grpModalidad.Location = New System.Drawing.Point(6, 11)
      Me.grpModalidad.Name = "grpModalidad"
      Me.grpModalidad.Size = New System.Drawing.Size(80, 52)
      Me.grpModalidad.TabIndex = 13
      Me.grpModalidad.TabStop = False
      '
      'RadioModoAguinaldo
      '
      Me.RadioModoAguinaldo.AutoSize = True
      Me.RadioModoAguinaldo.Location = New System.Drawing.Point(6, 29)
      Me.RadioModoAguinaldo.Name = "RadioModoAguinaldo"
      Me.RadioModoAguinaldo.Size = New System.Drawing.Size(72, 17)
      Me.RadioModoAguinaldo.TabIndex = 1
      Me.RadioModoAguinaldo.Text = "Aguinaldo"
      Me.RadioModoAguinaldo.UseVisualStyleBackColor = True
      '
      'RadioModoNormal
      '
      Me.RadioModoNormal.AutoSize = True
      Me.RadioModoNormal.Checked = True
      Me.RadioModoNormal.Location = New System.Drawing.Point(7, 10)
      Me.RadioModoNormal.Name = "RadioModoNormal"
      Me.RadioModoNormal.Size = New System.Drawing.Size(58, 17)
      Me.RadioModoNormal.TabIndex = 0
      Me.RadioModoNormal.TabStop = True
      Me.RadioModoNormal.Text = "Normal"
      Me.RadioModoNormal.UseVisualStyleBackColor = True
      '
      'PersonalBindingSource1
      '
      Me.PersonalBindingSource1.DataMember = "Personal"
      '
      'ugvPersonal
      '
      Me.ugvPersonal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ugvPersonal.DataSource = Me.PersonalBindingSource
      Appearance37.BackColor = System.Drawing.SystemColors.Window
      Appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugvPersonal.DisplayLayout.Appearance = Appearance37
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(42, 0)
      UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(197, 0)
      UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(58, 0)
      UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn4.Header.VisiblePosition = 4
      UltraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(94, 0)
      UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn5.Header.VisiblePosition = 5
      UltraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(140, 0)
      UltraGridColumn6.DataType = GetType(Boolean)
      UltraGridColumn6.Header.VisiblePosition = 1
      UltraGridColumn6.RowLayoutColumnInfo.OriginX = 0
      UltraGridColumn6.RowLayoutColumnInfo.OriginY = 0
      UltraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(42, 0)
      UltraGridColumn6.RowLayoutColumnInfo.SpanX = 2
      UltraGridColumn6.RowLayoutColumnInfo.SpanY = 2
      UltraGridColumn6.Width = 43
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
      UltraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout
      UltraGridBand1.SummaryFooterCaption = "Suma"
      Me.ugvPersonal.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugvPersonal.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance38.BorderColor = System.Drawing.SystemColors.Window
      Me.ugvPersonal.DisplayLayout.GroupByBox.Appearance = Appearance38
      Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugvPersonal.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance39
      Me.ugvPersonal.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugvPersonal.DisplayLayout.GroupByBox.Hidden = True
      Me.ugvPersonal.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna aquí para agrupar."
      Appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance40.BackColor2 = System.Drawing.SystemColors.Control
      Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugvPersonal.DisplayLayout.GroupByBox.PromptAppearance = Appearance40
      Me.ugvPersonal.DisplayLayout.MaxColScrollRegions = 1
      Me.ugvPersonal.DisplayLayout.MaxRowScrollRegions = 1
      Appearance41.BackColor = System.Drawing.SystemColors.Window
      Appearance41.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugvPersonal.DisplayLayout.Override.ActiveCellAppearance = Appearance41
      Appearance42.BackColor = System.Drawing.SystemColors.Highlight
      Appearance42.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugvPersonal.DisplayLayout.Override.ActiveRowAppearance = Appearance42
      Me.ugvPersonal.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugvPersonal.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance43.BackColor = System.Drawing.SystemColors.Window
      Me.ugvPersonal.DisplayLayout.Override.CardAreaAppearance = Appearance43
      Appearance44.BorderColor = System.Drawing.Color.Silver
      Appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugvPersonal.DisplayLayout.Override.CellAppearance = Appearance44
      Me.ugvPersonal.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugvPersonal.DisplayLayout.Override.CellPadding = 0
      Appearance45.BackColor = System.Drawing.SystemColors.Control
      Appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance45.BorderColor = System.Drawing.SystemColors.Window
      Me.ugvPersonal.DisplayLayout.Override.GroupByRowAppearance = Appearance45
      Appearance46.TextHAlignAsString = "Left"
      Me.ugvPersonal.DisplayLayout.Override.HeaderAppearance = Appearance46
      Me.ugvPersonal.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugvPersonal.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance47.BackColor = System.Drawing.SystemColors.Window
      Appearance47.BorderColor = System.Drawing.Color.Silver
      Me.ugvPersonal.DisplayLayout.Override.RowAppearance = Appearance47
      Me.ugvPersonal.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance48.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugvPersonal.DisplayLayout.Override.TemplateAddRowAppearance = Appearance48
      Me.ugvPersonal.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugvPersonal.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugvPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugvPersonal.Location = New System.Drawing.Point(10, 115)
      Me.ugvPersonal.Name = "ugvPersonal"
      Me.ugvPersonal.Size = New System.Drawing.Size(581, 314)
      Me.ugvPersonal.TabIndex = 2
      Me.ugvPersonal.Text = "Personal"
      '
      'PersonalBindingSource
      '
      Me.PersonalBindingSource.DataMember = "Personal"
      Me.PersonalBindingSource.DataSource = Me.DataSetSueldos
      '
      'DataSetSueldos
      '
      Me.DataSetSueldos.DataSetName = "DataSetSueldos"
      Me.DataSetSueldos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'chbPersonalSeleccionarTodos
      '
      Me.chbPersonalSeleccionarTodos.AutoSize = True
      Me.chbPersonalSeleccionarTodos.BindearPropiedadControl = Nothing
      Me.chbPersonalSeleccionarTodos.BindearPropiedadEntidad = Nothing
      Me.chbPersonalSeleccionarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.chbPersonalSeleccionarTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPersonalSeleccionarTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPersonalSeleccionarTodos.IsPK = False
      Me.chbPersonalSeleccionarTodos.IsRequired = False
      Me.chbPersonalSeleccionarTodos.Key = Nothing
      Me.chbPersonalSeleccionarTodos.LabelAsoc = Nothing
      Me.chbPersonalSeleccionarTodos.Location = New System.Drawing.Point(11, 99)
      Me.chbPersonalSeleccionarTodos.Name = "chbPersonalSeleccionarTodos"
      Me.chbPersonalSeleccionarTodos.Size = New System.Drawing.Size(55, 17)
      Me.chbPersonalSeleccionarTodos.TabIndex = 10
      Me.chbPersonalSeleccionarTodos.Text = "Check"
      Me.chbPersonalSeleccionarTodos.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbEliminar, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(602, 29)
      Me.tstBarra.TabIndex = 11
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbEliminar
      '
      Me.tsbEliminar.Enabled = False
      Me.tsbEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbEliminar.Name = "tsbEliminar"
      Me.tsbEliminar.Size = New System.Drawing.Size(136, 26)
      Me.tsbEliminar.Text = "&Eliminar Conceptos"
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
      'btnLimpiar
      '
      Me.btnLimpiar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.btnLimpiar.Location = New System.Drawing.Point(91, 24)
      Me.btnLimpiar.Name = "btnLimpiar"
      Me.btnLimpiar.Size = New System.Drawing.Size(37, 37)
      Me.btnLimpiar.TabIndex = 20
      Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnLimpiar.UseVisualStyleBackColor = True
      '
      'SueldosConceptosMasivoEliminar
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(602, 432)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.ugvPersonal)
      Me.Controls.Add(Me.grpConceptos)
      Me.Controls.Add(Me.chbPersonalSeleccionarTodos)
      Me.Name = "SueldosConceptosMasivoEliminar"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Eliminar Conceptos Masivamente"
      Me.grpConceptos.ResumeLayout(False)
      Me.grpConceptos.PerformLayout()
      Me.grpModalidad.ResumeLayout(False)
      Me.grpModalidad.PerformLayout()
      CType(Me.PersonalBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugvPersonal, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PersonalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataSetSueldos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grpConceptos As System.Windows.Forms.GroupBox
   Friend WithEvents bscCodigoConcepto As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoConcepto As Eniac.Controles.Label
   Friend WithEvents bscNombreConcepto As Eniac.Controles.Buscador
   Friend WithEvents lblNombreConcepto As Eniac.Controles.Label
   Friend WithEvents PersonalBindingSource1 As System.Windows.Forms.BindingSource
   Friend WithEvents ugvPersonal As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents PersonalBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents DataSetSueldos As Eniac.Win.DataSetSueldos
   Friend WithEvents chbPersonalSeleccionarTodos As Eniac.Controles.CheckBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents grpModalidad As System.Windows.Forms.GroupBox
   Friend WithEvents RadioModoAguinaldo As System.Windows.Forms.RadioButton
   Friend WithEvents RadioModoNormal As System.Windows.Forms.RadioButton
   Friend WithEvents btnLimpiar As Eniac.Controles.Button
End Class
