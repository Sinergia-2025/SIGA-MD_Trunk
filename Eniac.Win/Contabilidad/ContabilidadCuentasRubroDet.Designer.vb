<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadCuentasRubroDet
    Inherits Eniac.Win.BaseDetalle

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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuenta")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuenta")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.bscCodigoRubro = New Eniac.Controles.Buscador()
        Me.bscRubro = New Eniac.Controles.Buscador()
        Me.Label1 = New Eniac.Controles.Label()
        Me.lblAlicuotaIVA = New Eniac.Controles.Label()
        Me.UcCuentas1 = New Eniac.Win.ucCuentas()
        Me.ugCentrosEmisores = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.cmbTipo = New Eniac.Controles.ComboBox()
        Me.grpCentroEmisor = New System.Windows.Forms.GroupBox()
        Me.btnLimpiar = New Eniac.Controles.Button()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.lblCentroEmisor = New Eniac.Controles.Label()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.txtCentroEmisor = New Eniac.Controles.TextBox()
        Me.UcCuentas2 = New Eniac.Win.ucCuentas()
        CType(Me.ugCentrosEmisores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCentroEmisor.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(443, 457)
        Me.btnAceptar.TabIndex = 7
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(529, 457)
        Me.btnCancelar.TabIndex = 8
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(342, 457)
        Me.btnCopiar.TabIndex = 10
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(285, 457)
        Me.btnAplicar.TabIndex = 9
        '
        'bscCodigoRubro
        '
        Me.bscCodigoRubro.AyudaAncho = 608
        Me.bscCodigoRubro.BindearPropiedadControl = ""
        Me.bscCodigoRubro.BindearPropiedadEntidad = ""
        Me.bscCodigoRubro.ColumnasAlineacion = Nothing
        Me.bscCodigoRubro.ColumnasAncho = Nothing
        Me.bscCodigoRubro.ColumnasFormato = Nothing
        Me.bscCodigoRubro.ColumnasOcultas = Nothing
        Me.bscCodigoRubro.ColumnasTitulos = Nothing
        Me.bscCodigoRubro.Datos = Nothing
        Me.bscCodigoRubro.FilaDevuelta = Nothing
        Me.bscCodigoRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoRubro.IsDecimal = False
        Me.bscCodigoRubro.IsNumber = False
        Me.bscCodigoRubro.IsPK = False
        Me.bscCodigoRubro.IsRequired = False
        Me.bscCodigoRubro.Key = ""
        Me.bscCodigoRubro.LabelAsoc = Nothing
        Me.bscCodigoRubro.Location = New System.Drawing.Point(111, 12)
        Me.bscCodigoRubro.MaxLengh = "32767"
        Me.bscCodigoRubro.Name = "bscCodigoRubro"
        Me.bscCodigoRubro.Permitido = True
        Me.bscCodigoRubro.Selecciono = False
        Me.bscCodigoRubro.Size = New System.Drawing.Size(80, 20)
        Me.bscCodigoRubro.TabIndex = 1
        Me.bscCodigoRubro.Titulo = Nothing
        '
        'bscRubro
        '
        Me.bscRubro.AyudaAncho = 608
        Me.bscRubro.BindearPropiedadControl = Nothing
        Me.bscRubro.BindearPropiedadEntidad = Nothing
        Me.bscRubro.ColumnasAlineacion = Nothing
        Me.bscRubro.ColumnasAncho = Nothing
        Me.bscRubro.ColumnasFormato = Nothing
        Me.bscRubro.ColumnasOcultas = Nothing
        Me.bscRubro.ColumnasTitulos = Nothing
        Me.bscRubro.Datos = Nothing
        Me.bscRubro.FilaDevuelta = Nothing
        Me.bscRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscRubro.IsDecimal = False
        Me.bscRubro.IsNumber = False
        Me.bscRubro.IsPK = False
        Me.bscRubro.IsRequired = False
        Me.bscRubro.Key = ""
        Me.bscRubro.LabelAsoc = Nothing
        Me.bscRubro.Location = New System.Drawing.Point(196, 12)
        Me.bscRubro.MaxLengh = "32767"
        Me.bscRubro.Name = "bscRubro"
        Me.bscRubro.Permitido = True
        Me.bscRubro.Selecciono = False
        Me.bscRubro.Size = New System.Drawing.Size(300, 20)
        Me.bscRubro.TabIndex = 2
        Me.bscRubro.Titulo = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(65, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rubro"
        '
        'lblAlicuotaIVA
        '
        Me.lblAlicuotaIVA.AutoSize = True
        Me.lblAlicuotaIVA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAlicuotaIVA.LabelAsoc = Nothing
        Me.lblAlicuotaIVA.Location = New System.Drawing.Point(65, 41)
        Me.lblAlicuotaIVA.Name = "lblAlicuotaIVA"
        Me.lblAlicuotaIVA.Size = New System.Drawing.Size(28, 13)
        Me.lblAlicuotaIVA.TabIndex = 3
        Me.lblAlicuotaIVA.Text = "Tipo"
        '
        'UcCuentas1
        '
        Me.UcCuentas1.Cuenta = Nothing
        Me.UcCuentas1.Location = New System.Drawing.Point(68, 65)
        Me.UcCuentas1.Name = "UcCuentas1"
        Me.UcCuentas1.Size = New System.Drawing.Size(444, 20)
        Me.UcCuentas1.TabIndex = 5
        '
        'ugCentrosEmisores
        '
        Me.ugCentrosEmisores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugCentrosEmisores.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "Centro Emisor"
        UltraGridColumn1.Header.VisiblePosition = 0
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Header.Caption = "Código Cuenta"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.Caption = "Nombre Cuenta"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 355
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
        Me.ugCentrosEmisores.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugCentrosEmisores.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugCentrosEmisores.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCentrosEmisores.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCentrosEmisores.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.ugCentrosEmisores.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCentrosEmisores.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.ugCentrosEmisores.DisplayLayout.MaxColScrollRegions = 1
        Me.ugCentrosEmisores.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugCentrosEmisores.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugCentrosEmisores.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.ugCentrosEmisores.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugCentrosEmisores.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.ugCentrosEmisores.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugCentrosEmisores.DisplayLayout.Override.CellAppearance = Appearance10
        Me.ugCentrosEmisores.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugCentrosEmisores.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCentrosEmisores.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.TextHAlignAsString = "Left"
        Me.ugCentrosEmisores.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.ugCentrosEmisores.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugCentrosEmisores.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.ugCentrosEmisores.DisplayLayout.Override.RowAppearance = Appearance13
        Me.ugCentrosEmisores.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugCentrosEmisores.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.ugCentrosEmisores.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugCentrosEmisores.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugCentrosEmisores.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugCentrosEmisores.Location = New System.Drawing.Point(6, 71)
        Me.ugCentrosEmisores.Name = "ugCentrosEmisores"
        Me.ugCentrosEmisores.Size = New System.Drawing.Size(582, 283)
        Me.ugCentrosEmisores.TabIndex = 6
        Me.ugCentrosEmisores.Text = "UltraGrid1"
        '
        'cmbTipo
        '
        Me.cmbTipo.BindearPropiedadControl = ""
        Me.cmbTipo.BindearPropiedadEntidad = ""
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.IsPK = False
        Me.cmbTipo.IsRequired = False
        Me.cmbTipo.Key = Nothing
        Me.cmbTipo.LabelAsoc = Nothing
        Me.cmbTipo.Location = New System.Drawing.Point(111, 38)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(132, 21)
        Me.cmbTipo.TabIndex = 4
        '
        'grpCentroEmisor
        '
        Me.grpCentroEmisor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCentroEmisor.Controls.Add(Me.btnLimpiar)
        Me.grpCentroEmisor.Controls.Add(Me.btnInsertar)
        Me.grpCentroEmisor.Controls.Add(Me.lblCentroEmisor)
        Me.grpCentroEmisor.Controls.Add(Me.btnEliminar)
        Me.grpCentroEmisor.Controls.Add(Me.txtCentroEmisor)
        Me.grpCentroEmisor.Controls.Add(Me.UcCuentas2)
        Me.grpCentroEmisor.Controls.Add(Me.ugCentrosEmisores)
        Me.grpCentroEmisor.Location = New System.Drawing.Point(12, 91)
        Me.grpCentroEmisor.Name = "grpCentroEmisor"
        Me.grpCentroEmisor.Size = New System.Drawing.Size(594, 360)
        Me.grpCentroEmisor.TabIndex = 6
        Me.grpCentroEmisor.TabStop = False
        Me.grpCentroEmisor.Text = "Emisores"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(14, 30)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(29, 32)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.TabStop = False
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInsertar.Location = New System.Drawing.Point(508, 28)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 4
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'lblCentroEmisor
        '
        Me.lblCentroEmisor.AutoSize = True
        Me.lblCentroEmisor.LabelAsoc = Nothing
        Me.lblCentroEmisor.Location = New System.Drawing.Point(53, 26)
        Me.lblCentroEmisor.Name = "lblCentroEmisor"
        Me.lblCentroEmisor.Size = New System.Drawing.Size(38, 13)
        Me.lblCentroEmisor.TabIndex = 1
        Me.lblCentroEmisor.Text = "Emisor"
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminar.Location = New System.Drawing.Point(551, 28)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'txtCentroEmisor
        '
        Me.txtCentroEmisor.BindearPropiedadControl = "Text"
        Me.txtCentroEmisor.BindearPropiedadEntidad = "PatenteVehiculo"
        Me.txtCentroEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCentroEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCentroEmisor.Formato = ""
        Me.txtCentroEmisor.IsDecimal = False
        Me.txtCentroEmisor.IsNumber = True
        Me.txtCentroEmisor.IsPK = False
        Me.txtCentroEmisor.IsRequired = False
        Me.txtCentroEmisor.Key = ""
        Me.txtCentroEmisor.LabelAsoc = Me.lblCentroEmisor
        Me.txtCentroEmisor.Location = New System.Drawing.Point(99, 19)
        Me.txtCentroEmisor.MaxLength = 8
        Me.txtCentroEmisor.Name = "txtCentroEmisor"
        Me.txtCentroEmisor.Size = New System.Drawing.Size(60, 20)
        Me.txtCentroEmisor.TabIndex = 2
        Me.txtCentroEmisor.Text = "0"
        Me.txtCentroEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UcCuentas2
        '
        Me.UcCuentas2.Cuenta = Nothing
        Me.UcCuentas2.Location = New System.Drawing.Point(56, 45)
        Me.UcCuentas2.Name = "UcCuentas2"
        Me.UcCuentas2.Size = New System.Drawing.Size(444, 20)
        Me.UcCuentas2.TabIndex = 3
        '
        'ContabilidadCuentasRubroDet
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CierraAutomaticamente = True
        Me.ClientSize = New System.Drawing.Size(618, 492)
        Me.Controls.Add(Me.grpCentroEmisor)
        Me.Controls.Add(Me.UcCuentas1)
        Me.Controls.Add(Me.lblAlicuotaIVA)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bscCodigoRubro)
        Me.Controls.Add(Me.bscRubro)
        Me.Name = "ContabilidadCuentasRubroDet"
        Me.Text = "Cuenta por Rubros de Producto Detalle"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.bscRubro, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoRubro, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cmbTipo, 0)
        Me.Controls.SetChildIndex(Me.lblAlicuotaIVA, 0)
        Me.Controls.SetChildIndex(Me.UcCuentas1, 0)
        Me.Controls.SetChildIndex(Me.grpCentroEmisor, 0)
        CType(Me.ugCentrosEmisores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCentroEmisor.ResumeLayout(False)
        Me.grpCentroEmisor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bscCodigoRubro As Eniac.Controles.Buscador
   Friend WithEvents bscRubro As Eniac.Controles.Buscador
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents lblAlicuotaIVA As Eniac.Controles.Label
   Friend WithEvents cmbTipo As Eniac.Controles.ComboBox
   Friend WithEvents UcCuentas1 As Eniac.Win.ucCuentas
    Friend WithEvents ugCentrosEmisores As UltraGrid
    Friend WithEvents grpCentroEmisor As GroupBox
    Friend WithEvents UcCuentas2 As ucCuentas
    Friend WithEvents lblCentroEmisor As Controles.Label
    Friend WithEvents txtCentroEmisor As Controles.TextBox
    Friend WithEvents btnLimpiar As Controles.Button
    Friend WithEvents btnInsertar As Controles.Button
    Friend WithEvents btnEliminar As Controles.Button
End Class
