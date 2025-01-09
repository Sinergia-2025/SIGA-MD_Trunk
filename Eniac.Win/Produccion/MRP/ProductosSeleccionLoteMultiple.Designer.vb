<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductosSeleccionLoteMultiple
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductosSeleccionLoteMultiple))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Lote")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.pnlAcciones = New System.Windows.Forms.Panel()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.bscLote = New Eniac.Controles.Buscador2()
      Me.lblCantidad = New Eniac.Controles.Label()
      Me.txtCantidad = New Eniac.Controles.TextBox()
      Me.lblLote = New Eniac.Controles.Label()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.pnlLote = New System.Windows.Forms.Panel()
        Me.chbLoteExistente = New Eniac.Controles.CheckBox()
        Me.txtLoteExistente = New Eniac.Controles.TextBox()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLote.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'pnlAcciones
        '
        Me.pnlAcciones.AutoSize = True
        Me.pnlAcciones.Controls.Add(Me.btnAceptar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 227)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(490, 37)
        Me.pnlAcciones.TabIndex = 88
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(316, 4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(402, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertar.Location = New System.Drawing.Point(237, 27)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 93
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminar.Location = New System.Drawing.Point(237, 68)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 94
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'bscLote
        '
        Me.bscLote.ActivarFiltroEnGrilla = True
        Me.bscLote.BindearPropiedadControl = Nothing
        Me.bscLote.BindearPropiedadEntidad = Nothing
        Me.bscLote.ConfigBuscador = Nothing
        Me.bscLote.Datos = Nothing
        Me.bscLote.FilaDevuelta = Nothing
        Me.bscLote.ForeColorFocus = System.Drawing.Color.Red
        Me.bscLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscLote.IsDecimal = False
        Me.bscLote.IsNumber = False
        Me.bscLote.IsPK = False
        Me.bscLote.IsRequired = False
        Me.bscLote.Key = ""
        Me.bscLote.LabelAsoc = Nothing
        Me.bscLote.Location = New System.Drawing.Point(60, 37)
        Me.bscLote.Margin = New System.Windows.Forms.Padding(4)
        Me.bscLote.MaxLengh = "32767"
        Me.bscLote.Name = "bscLote"
        Me.bscLote.Permitido = True
        Me.bscLote.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscLote.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscLote.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscLote.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscLote.Selecciono = False
        Me.bscLote.Size = New System.Drawing.Size(174, 20)
        Me.bscLote.TabIndex = 90
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(5, 67)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 91
        Me.lblCantidad.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.BindearPropiedadControl = Nothing
        Me.txtCantidad.BindearPropiedadEntidad = Nothing
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "#0.00"
        Me.txtCantidad.IsDecimal = True
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Me.lblCantidad
        Me.txtCantidad.Location = New System.Drawing.Point(60, 64)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(54, 20)
        Me.txtCantidad.TabIndex = 92
        Me.txtCantidad.Text = "0,00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLote
        '
        Me.lblLote.AutoSize = True
        Me.lblLote.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLote.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLote.LabelAsoc = Nothing
        Me.lblLote.Location = New System.Drawing.Point(6, 40)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(28, 13)
        Me.lblLote.TabIndex = 89
        Me.lblLote.Text = "Lote"
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance2
        UltraGridColumn3.Format = "N2"
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn3.Width = 74
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn3})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance9
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(276, 0)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(214, 227)
        Me.ugDetalle.TabIndex = 95
        '
        'pnlLote
        '
        Me.pnlLote.Controls.Add(Me.chbLoteExistente)
        Me.pnlLote.Controls.Add(Me.btnInsertar)
        Me.pnlLote.Controls.Add(Me.btnEliminar)
        Me.pnlLote.Controls.Add(Me.bscLote)
        Me.pnlLote.Controls.Add(Me.lblCantidad)
        Me.pnlLote.Controls.Add(Me.txtCantidad)
        Me.pnlLote.Controls.Add(Me.lblLote)
        Me.pnlLote.Controls.Add(Me.txtLoteExistente)
        Me.pnlLote.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLote.Location = New System.Drawing.Point(0, 0)
        Me.pnlLote.Name = "pnlLote"
        Me.pnlLote.Size = New System.Drawing.Size(276, 227)
        Me.pnlLote.TabIndex = 96
        '
        'chbLoteExistente
        '
        Me.chbLoteExistente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbLoteExistente.AutoSize = True
        Me.chbLoteExistente.BindearPropiedadControl = Nothing
        Me.chbLoteExistente.BindearPropiedadEntidad = Nothing
        Me.chbLoteExistente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLoteExistente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLoteExistente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbLoteExistente.IsPK = False
        Me.chbLoteExistente.IsRequired = False
        Me.chbLoteExistente.Key = Nothing
        Me.chbLoteExistente.LabelAsoc = Nothing
        Me.chbLoteExistente.Location = New System.Drawing.Point(6, 11)
        Me.chbLoteExistente.Name = "chbLoteExistente"
        Me.chbLoteExistente.Size = New System.Drawing.Size(93, 17)
        Me.chbLoteExistente.TabIndex = 95
        Me.chbLoteExistente.Text = "Lote Existente"
        Me.chbLoteExistente.UseVisualStyleBackColor = True
        '
        'txtLoteExistente
        '
        Me.txtLoteExistente.BindearPropiedadControl = ""
        Me.txtLoteExistente.BindearPropiedadEntidad = ""
        Me.txtLoteExistente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLoteExistente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLoteExistente.Formato = ""
        Me.txtLoteExistente.IsDecimal = False
        Me.txtLoteExistente.IsNumber = False
        Me.txtLoteExistente.IsPK = False
        Me.txtLoteExistente.IsRequired = False
        Me.txtLoteExistente.Key = ""
        Me.txtLoteExistente.LabelAsoc = Nothing
        Me.txtLoteExistente.Location = New System.Drawing.Point(60, 37)
        Me.txtLoteExistente.MaxLength = 8
        Me.txtLoteExistente.Name = "txtLoteExistente"
        Me.txtLoteExistente.Size = New System.Drawing.Size(174, 20)
        Me.txtLoteExistente.TabIndex = 96
        '
        'ProductosSeleccionLoteMultiple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 264)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.pnlLote)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Name = "ProductosSeleccionLoteMultiple"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione Lotes"
        Me.pnlAcciones.ResumeLayout(False)
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLote.ResumeLayout(False)
        Me.pnlLote.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents imageList1 As ImageList
   Friend WithEvents pnlAcciones As Panel
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
   Friend WithEvents btnInsertar As Controles.Button
   Friend WithEvents btnEliminar As Controles.Button
   Friend WithEvents bscLote As Controles.Buscador2
   Friend WithEvents lblCantidad As Controles.Label
   Friend WithEvents txtCantidad As Controles.TextBox
   Friend WithEvents lblLote As Controles.Label
   Friend WithEvents ugDetalle As UltraGrid
   Friend WithEvents pnlLote As Panel
    Friend WithEvents chbLoteExistente As Controles.CheckBox
    Friend WithEvents txtLoteExistente As Controles.TextBox
End Class
