<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseMultiplesFiltros2
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseMultiplesFiltros2))
      Me.ugbProductos = New Infragistics.Win.Misc.UltraGroupBox()
      Me.grbCuerpo = New System.Windows.Forms.GroupBox()
      Me.dgvDatos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.grbCabeza = New System.Windows.Forms.GroupBox()
      Me.lnkAgregarTodos = New Eniac.Controles.Button()
      Me.bscNombre = New Eniac.Controles.Buscador2()
      Me.lnkLimpiarFiltros = New Eniac.Controles.Button()
      Me.bscCodigo = New Eniac.Controles.Buscador2()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.grbPie = New System.Windows.Forms.GroupBox()
      Me.btnCerrar = New Eniac.Controles.Button()
      Me.lnkGrabarFiltro = New Eniac.Controles.Button()
      Me.lnkRecuperarUltimo = New Eniac.Controles.Button()
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
        Me.ugbProductos.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.ugbProductos.Controls.Add(Me.grbCuerpo)
        Me.ugbProductos.Controls.Add(Me.grbCabeza)
        Me.ugbProductos.Controls.Add(Me.grbPie)
        Me.ugbProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbProductos.Location = New System.Drawing.Point(0, 0)
        Me.ugbProductos.Name = "ugbProductos"
        Me.ugbProductos.Size = New System.Drawing.Size(416, 453)
        Me.ugbProductos.TabIndex = 1
        Me.ugbProductos.Text = "Seleccione"
        '
        'grbCuerpo
        '
        Me.grbCuerpo.Controls.Add(Me.dgvDatos)
        Me.grbCuerpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbCuerpo.Location = New System.Drawing.Point(3, 100)
        Me.grbCuerpo.Name = "grbCuerpo"
        Me.grbCuerpo.Size = New System.Drawing.Size(410, 306)
        Me.grbCuerpo.TabIndex = 1
        Me.grbCuerpo.TabStop = False
        '
        'dgvDatos
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvDatos.DisplayLayout.Appearance = Appearance1
        Me.dgvDatos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvDatos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvDatos.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvDatos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.dgvDatos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvDatos.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.dgvDatos.DisplayLayout.MaxBandDepth = 1
        Me.dgvDatos.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvDatos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDatos.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDatos.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.dgvDatos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvDatos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDatos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDatos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgvDatos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.dgvDatos.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgvDatos.DisplayLayout.Override.CellAppearance = Appearance8
        Me.dgvDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgvDatos.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvDatos.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.dgvDatos.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.dgvDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgvDatos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.dgvDatos.DisplayLayout.Override.RowAppearance = Appearance11
        Me.dgvDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgvDatos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.dgvDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.Location = New System.Drawing.Point(3, 16)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Size = New System.Drawing.Size(404, 287)
        Me.dgvDatos.TabIndex = 0
        '
        'grbCabeza
        '
        Me.grbCabeza.Controls.Add(Me.lnkAgregarTodos)
        Me.grbCabeza.Controls.Add(Me.bscNombre)
        Me.grbCabeza.Controls.Add(Me.lnkLimpiarFiltros)
        Me.grbCabeza.Controls.Add(Me.bscCodigo)
        Me.grbCabeza.Controls.Add(Me.btnInsertar)
        Me.grbCabeza.Controls.Add(Me.btnEliminar)
        Me.grbCabeza.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbCabeza.Location = New System.Drawing.Point(3, 16)
        Me.grbCabeza.Name = "grbCabeza"
        Me.grbCabeza.Size = New System.Drawing.Size(410, 84)
        Me.grbCabeza.TabIndex = 0
        Me.grbCabeza.TabStop = False
        '
        'lnkAgregarTodos
        '
        Me.lnkAgregarTodos.AutoSize = True
        Me.lnkAgregarTodos.Location = New System.Drawing.Point(9, 48)
        Me.lnkAgregarTodos.Name = "lnkAgregarTodos"
        Me.lnkAgregarTodos.Size = New System.Drawing.Size(83, 23)
        Me.lnkAgregarTodos.TabIndex = 4
        Me.lnkAgregarTodos.Text = "Agregar todos"
        '
        'bscNombre
        '
        Me.bscNombre.ActivarFiltroEnGrilla = True
        Me.bscNombre.BindearPropiedadControl = Nothing
        Me.bscNombre.BindearPropiedadEntidad = Nothing
        Me.bscNombre.ConfigBuscador = Nothing
        Me.bscNombre.Datos = Nothing
        Me.bscNombre.FilaDevuelta = Nothing
        Me.bscNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombre.IsDecimal = False
        Me.bscNombre.IsNumber = False
        Me.bscNombre.IsPK = False
        Me.bscNombre.IsRequired = False
        Me.bscNombre.Key = ""
        Me.bscNombre.LabelAsoc = Nothing
        Me.bscNombre.Location = New System.Drawing.Point(122, 15)
        Me.bscNombre.MaxLengh = "32767"
        Me.bscNombre.Name = "bscNombre"
        Me.bscNombre.Permitido = True
        Me.bscNombre.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombre.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombre.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombre.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombre.Selecciono = False
        Me.bscNombre.Size = New System.Drawing.Size(279, 20)
        Me.bscNombre.TabIndex = 1
        '
        'lnkLimpiarFiltros
        '
        Me.lnkLimpiarFiltros.AutoSize = True
        Me.lnkLimpiarFiltros.Location = New System.Drawing.Point(98, 48)
        Me.lnkLimpiarFiltros.Name = "lnkLimpiarFiltros"
        Me.lnkLimpiarFiltros.Size = New System.Drawing.Size(77, 23)
        Me.lnkLimpiarFiltros.TabIndex = 2
        Me.lnkLimpiarFiltros.Text = "Quitar todos"
        '
        'bscCodigo
        '
        Me.bscCodigo.ActivarFiltroEnGrilla = True
        Me.bscCodigo.BindearPropiedadControl = Nothing
        Me.bscCodigo.BindearPropiedadEntidad = Nothing
        Me.bscCodigo.ConfigBuscador = Nothing
        Me.bscCodigo.Datos = Nothing
        Me.bscCodigo.FilaDevuelta = Nothing
        Me.bscCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigo.IsDecimal = False
        Me.bscCodigo.IsNumber = False
        Me.bscCodigo.IsPK = False
        Me.bscCodigo.IsRequired = False
        Me.bscCodigo.Key = ""
        Me.bscCodigo.LabelAsoc = Nothing
        Me.bscCodigo.Location = New System.Drawing.Point(8, 15)
        Me.bscCodigo.MaxLengh = "32767"
        Me.bscCodigo.Name = "bscCodigo"
        Me.bscCodigo.Permitido = True
        Me.bscCodigo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigo.Selecciono = False
        Me.bscCodigo.Size = New System.Drawing.Size(108, 20)
        Me.bscCodigo.TabIndex = 0
        '
        'btnInsertar
        '
        Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
        Me.btnInsertar.Location = New System.Drawing.Point(330, 41)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 2
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(367, 41)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'grbPie
        '
        Me.grbPie.Controls.Add(Me.btnCerrar)
        Me.grbPie.Controls.Add(Me.lnkGrabarFiltro)
        Me.grbPie.Controls.Add(Me.lnkRecuperarUltimo)
        Me.grbPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grbPie.Location = New System.Drawing.Point(3, 406)
        Me.grbPie.Name = "grbPie"
        Me.grbPie.Size = New System.Drawing.Size(410, 44)
        Me.grbPie.TabIndex = 2
        Me.grbPie.TabStop = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnCerrar.Location = New System.Drawing.Point(299, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(105, 32)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "&Aceptar (F4)"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lnkGrabarFiltro
        '
        Me.lnkGrabarFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkGrabarFiltro.AutoSize = True
        Me.lnkGrabarFiltro.Location = New System.Drawing.Point(99, 13)
        Me.lnkGrabarFiltro.Name = "lnkGrabarFiltro"
        Me.lnkGrabarFiltro.Size = New System.Drawing.Size(71, 23)
        Me.lnkGrabarFiltro.TabIndex = 1
        Me.lnkGrabarFiltro.Text = "Grabar filtro"
        '
        'lnkRecuperarUltimo
        '
        Me.lnkRecuperarUltimo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkRecuperarUltimo.AutoSize = True
        Me.lnkRecuperarUltimo.Location = New System.Drawing.Point(4, 13)
        Me.lnkRecuperarUltimo.Name = "lnkRecuperarUltimo"
        Me.lnkRecuperarUltimo.Size = New System.Drawing.Size(89, 23)
        Me.lnkRecuperarUltimo.TabIndex = 0
        Me.lnkRecuperarUltimo.Text = "Recuperar filtro"
        '
        'BaseMultiplesFiltros2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 453)
        Me.ControlBox = False
        Me.Controls.Add(Me.ugbProductos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Name = "BaseMultiplesFiltros2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BaseMultiplesFiltros"
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
    Public WithEvents ugbProductos As Infragistics.Win.Misc.UltraGroupBox
   Public WithEvents grbCuerpo As System.Windows.Forms.GroupBox
   Public WithEvents dgvDatos As Infragistics.Win.UltraWinGrid.UltraGrid
   Public WithEvents grbCabeza As System.Windows.Forms.GroupBox
   Public WithEvents lnkAgregarTodos As Eniac.Controles.Button
   Public WithEvents bscNombre As Eniac.Controles.Buscador2
   Public WithEvents bscCodigo As Eniac.Controles.Buscador2
   Public WithEvents btnInsertar As Eniac.Controles.Button
   Public WithEvents btnEliminar As Eniac.Controles.Button
   Public WithEvents grbPie As System.Windows.Forms.GroupBox
   Public WithEvents btnCerrar As Eniac.Controles.Button
   Public WithEvents lnkGrabarFiltro As Eniac.Controles.Button
   Public WithEvents lnkLimpiarFiltros As Eniac.Controles.Button
   Public WithEvents lnkRecuperarUltimo As Eniac.Controles.Button
End Class
