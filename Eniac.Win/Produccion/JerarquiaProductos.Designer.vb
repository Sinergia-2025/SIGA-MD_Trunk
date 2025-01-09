<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JerarquiaProductos
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
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabarFormula = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbAgregarFormula = New System.Windows.Forms.ToolStripButton()
      Me.tsbModificarFormula = New System.Windows.Forms.ToolStripButton()
      Me.tsbEliminarFormula = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grpConceptos = New System.Windows.Forms.GroupBox()
      Me.bscCopiarNombreProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCopiarCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.chbCopiar = New Eniac.Controles.CheckBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.btnEliminarComponente = New Eniac.Controles.Button()
      Me.btnAgregarComponente = New Eniac.Controles.Button()
      Me.cmbFormulas = New Eniac.Controles.ComboBox()
      Me.lblFormula = New Eniac.Controles.Label()
      Me.dgvProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.btnPreferenciasProductos = New Eniac.Controles.Button()
      Me.btnPreferenciasComponentes = New Eniac.Controles.Button()
      Me.dgvComponentes = New Eniac.Win.UltraGridEditable()
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.lblMarca = New Eniac.Controles.Label()
      Me.cmbMarca = New Eniac.Win.ComboBoxMarcas()
      Me.lblRubro = New Eniac.Controles.Label()
      Me.cmbRubro = New Eniac.Win.ComboBoxRubro()
      Me.btnBuscar = New Eniac.Controles.Button()
      Me.tstBarra.SuspendLayout()
      Me.grpConceptos.SuspendLayout()
      CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbGrabarFormula, Me.ToolStripSeparator3, Me.tsbAgregarFormula, Me.tsbModificarFormula, Me.tsbEliminarFormula, Me.ToolStripSeparator1, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 11
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGrabarFormula
      '
      Me.tsbGrabarFormula.Enabled = False
      Me.tsbGrabarFormula.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabarFormula.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabarFormula.Name = "tsbGrabarFormula"
      Me.tsbGrabarFormula.Size = New System.Drawing.Size(115, 26)
      Me.tsbGrabarFormula.Text = "&Grabar Fórmula"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      Me.ToolStripSeparator3.Visible = False
      '
      'tsbAgregarFormula
      '
      Me.tsbAgregarFormula.Enabled = False
      Me.tsbAgregarFormula.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.tsbAgregarFormula.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbAgregarFormula.Name = "tsbAgregarFormula"
      Me.tsbAgregarFormula.Size = New System.Drawing.Size(122, 26)
      Me.tsbAgregarFormula.Text = "&Agregar Fórmula"
      Me.tsbAgregarFormula.Visible = False
      '
      'tsbModificarFormula
      '
      Me.tsbModificarFormula.Enabled = False
      Me.tsbModificarFormula.Image = Global.Eniac.Win.My.Resources.Resources.copy_save_32
      Me.tsbModificarFormula.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbModificarFormula.Name = "tsbModificarFormula"
      Me.tsbModificarFormula.Size = New System.Drawing.Size(131, 26)
      Me.tsbModificarFormula.Text = "&Modificar Fórmula"
      Me.tsbModificarFormula.Visible = False
      '
      'tsbEliminarFormula
      '
      Me.tsbEliminarFormula.Enabled = False
      Me.tsbEliminarFormula.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.tsbEliminarFormula.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbEliminarFormula.Name = "tsbEliminarFormula"
      Me.tsbEliminarFormula.Size = New System.Drawing.Size(123, 26)
      Me.tsbEliminarFormula.Text = "&Eliminar Fórmula"
      Me.tsbEliminarFormula.Visible = False
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
      'grpConceptos
      '
      Me.grpConceptos.Controls.Add(Me.bscCopiarNombreProducto2)
      Me.grpConceptos.Controls.Add(Me.bscCopiarCodigoProducto2)
      Me.grpConceptos.Controls.Add(Me.bscProducto2)
      Me.grpConceptos.Controls.Add(Me.bscCodigoProducto2)
      Me.grpConceptos.Controls.Add(Me.chbCopiar)
      Me.grpConceptos.Controls.Add(Me.Label1)
      Me.grpConceptos.Location = New System.Drawing.Point(6, 32)
      Me.grpConceptos.Name = "grpConceptos"
      Me.grpConceptos.Size = New System.Drawing.Size(479, 105)
      Me.grpConceptos.TabIndex = 0
      Me.grpConceptos.TabStop = False
      Me.grpConceptos.Text = "Selección de Producto"
      '
      'bscCopiarNombreProducto2
      '
      Me.bscCopiarNombreProducto2.ActivarFiltroEnGrilla = True
      Me.bscCopiarNombreProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscCopiarNombreProducto2.BindearPropiedadControl = Nothing
      Me.bscCopiarNombreProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCopiarNombreProducto2.ConfigBuscador = Nothing
      Me.bscCopiarNombreProducto2.Datos = Nothing
      Me.bscCopiarNombreProducto2.FilaDevuelta = Nothing
      Me.bscCopiarNombreProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCopiarNombreProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCopiarNombreProducto2.IsDecimal = False
      Me.bscCopiarNombreProducto2.IsNumber = False
      Me.bscCopiarNombreProducto2.IsPK = False
      Me.bscCopiarNombreProducto2.IsRequired = False
      Me.bscCopiarNombreProducto2.Key = ""
      Me.bscCopiarNombreProducto2.LabelAsoc = Nothing
      Me.bscCopiarNombreProducto2.Location = New System.Drawing.Point(183, 70)
      Me.bscCopiarNombreProducto2.MaxLengh = "32767"
      Me.bscCopiarNombreProducto2.Name = "bscCopiarNombreProducto2"
      Me.bscCopiarNombreProducto2.Permitido = False
      Me.bscCopiarNombreProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCopiarNombreProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCopiarNombreProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCopiarNombreProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCopiarNombreProducto2.Selecciono = False
      Me.bscCopiarNombreProducto2.Size = New System.Drawing.Size(290, 20)
      Me.bscCopiarNombreProducto2.TabIndex = 52
      '
      'bscCopiarCodigoProducto2
      '
      Me.bscCopiarCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCopiarCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscCopiarCodigoProducto2.BindearPropiedadControl = Nothing
      Me.bscCopiarCodigoProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCopiarCodigoProducto2.ConfigBuscador = Nothing
      Me.bscCopiarCodigoProducto2.Datos = Nothing
      Me.bscCopiarCodigoProducto2.FilaDevuelta = Nothing
      Me.bscCopiarCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCopiarCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCopiarCodigoProducto2.IsDecimal = False
      Me.bscCopiarCodigoProducto2.IsNumber = False
      Me.bscCopiarCodigoProducto2.IsPK = False
      Me.bscCopiarCodigoProducto2.IsRequired = False
      Me.bscCopiarCodigoProducto2.Key = ""
      Me.bscCopiarCodigoProducto2.LabelAsoc = Nothing
      Me.bscCopiarCodigoProducto2.Location = New System.Drawing.Point(59, 69)
      Me.bscCopiarCodigoProducto2.MaxLengh = "32767"
      Me.bscCopiarCodigoProducto2.Name = "bscCopiarCodigoProducto2"
      Me.bscCopiarCodigoProducto2.Permitido = False
      Me.bscCopiarCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCopiarCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCopiarCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCopiarCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCopiarCodigoProducto2.Selecciono = False
      Me.bscCopiarCodigoProducto2.Size = New System.Drawing.Size(118, 20)
      Me.bscCopiarCodigoProducto2.TabIndex = 51
      '
      'bscProducto2
      '
      Me.bscProducto2.ActivarFiltroEnGrilla = True
      Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProducto2.BindearPropiedadControl = Nothing
      Me.bscProducto2.BindearPropiedadEntidad = Nothing
      Me.bscProducto2.ConfigBuscador = Nothing
      Me.bscProducto2.Datos = Nothing
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto2.IsDecimal = False
      Me.bscProducto2.IsNumber = False
      Me.bscProducto2.IsPK = False
      Me.bscProducto2.IsRequired = False
      Me.bscProducto2.Key = ""
      Me.bscProducto2.LabelAsoc = Nothing
      Me.bscProducto2.Location = New System.Drawing.Point(183, 40)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(290, 20)
      Me.bscProducto2.TabIndex = 50
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto2.ConfigBuscador = Nothing
      Me.bscCodigoProducto2.Datos = Nothing
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto2.IsDecimal = False
      Me.bscCodigoProducto2.IsNumber = False
      Me.bscCodigoProducto2.IsPK = False
      Me.bscCodigoProducto2.IsRequired = False
      Me.bscCodigoProducto2.Key = ""
      Me.bscCodigoProducto2.LabelAsoc = Nothing
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(59, 39)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(118, 20)
      Me.bscCodigoProducto2.TabIndex = 49
      '
      'chbCopiar
      '
      Me.chbCopiar.AutoSize = True
      Me.chbCopiar.BindearPropiedadControl = Nothing
      Me.chbCopiar.BindearPropiedadEntidad = Nothing
      Me.chbCopiar.Enabled = False
      Me.chbCopiar.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCopiar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCopiar.IsPK = False
      Me.chbCopiar.IsRequired = False
      Me.chbCopiar.Key = Nothing
      Me.chbCopiar.LabelAsoc = Nothing
      Me.chbCopiar.Location = New System.Drawing.Point(5, 70)
      Me.chbCopiar.Name = "chbCopiar"
      Me.chbCopiar.Size = New System.Drawing.Size(56, 17)
      Me.chbCopiar.TabIndex = 3
      Me.chbCopiar.Text = "Copiar"
      Me.chbCopiar.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(5, 40)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(50, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Producto"
      '
      'btnEliminarComponente
      '
      Me.btnEliminarComponente.Enabled = False
      Me.btnEliminarComponente.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.btnEliminarComponente.Location = New System.Drawing.Point(476, 269)
      Me.btnEliminarComponente.Name = "btnEliminarComponente"
      Me.btnEliminarComponente.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminarComponente.TabIndex = 5
      Me.btnEliminarComponente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnEliminarComponente.UseVisualStyleBackColor = True
      '
      'btnAgregarComponente
      '
      Me.btnAgregarComponente.Enabled = False
      Me.btnAgregarComponente.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.btnAgregarComponente.Location = New System.Drawing.Point(476, 226)
      Me.btnAgregarComponente.Name = "btnAgregarComponente"
      Me.btnAgregarComponente.Size = New System.Drawing.Size(37, 37)
      Me.btnAgregarComponente.TabIndex = 4
      Me.btnAgregarComponente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAgregarComponente.UseVisualStyleBackColor = True
      '
      'cmbFormulas
      '
      Me.cmbFormulas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbFormulas.BindearPropiedadControl = Nothing
      Me.cmbFormulas.BindearPropiedadEntidad = Nothing
      Me.cmbFormulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormulas.Enabled = False
      Me.cmbFormulas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormulas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormulas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormulas.FormattingEnabled = True
      Me.cmbFormulas.IsPK = False
      Me.cmbFormulas.IsRequired = False
      Me.cmbFormulas.Key = Nothing
      Me.cmbFormulas.LabelAsoc = Me.lblFormula
      Me.cmbFormulas.Location = New System.Drawing.Point(561, 113)
      Me.cmbFormulas.Name = "cmbFormulas"
      Me.cmbFormulas.Size = New System.Drawing.Size(233, 21)
      Me.cmbFormulas.TabIndex = 12
      Me.cmbFormulas.TabStop = False
      '
      'lblFormula
      '
      Me.lblFormula.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblFormula.AutoSize = True
      Me.lblFormula.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFormula.LabelAsoc = Nothing
      Me.lblFormula.Location = New System.Drawing.Point(517, 118)
      Me.lblFormula.Name = "lblFormula"
      Me.lblFormula.Size = New System.Drawing.Size(44, 13)
      Me.lblFormula.TabIndex = 13
      Me.lblFormula.Text = "Fórmula"
      '
      'dgvProductos
      '
      Me.dgvProductos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.dgvProductos.DisplayLayout.Appearance = Appearance1
      Me.dgvProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvProductos.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.dgvProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvProductos.DisplayLayout.GroupByBox.Hidden = True
      Me.dgvProductos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.dgvProductos.DisplayLayout.MaxColScrollRegions = 1
      Me.dgvProductos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.dgvProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dgvProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.dgvProductos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.dgvProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvProductos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.dgvProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.dgvProductos.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.dgvProductos.DisplayLayout.Override.CellAppearance = Appearance8
      Me.dgvProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
      Me.dgvProductos.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.dgvProductos.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.dgvProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.dgvProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.dgvProductos.DisplayLayout.Override.RowAppearance = Appearance11
      Me.dgvProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvProductos.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.dgvProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.dgvProductos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.dgvProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dgvProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dgvProductos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.dgvProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgvProductos.Location = New System.Drawing.Point(6, 143)
      Me.dgvProductos.Name = "dgvProductos"
      Me.dgvProductos.Size = New System.Drawing.Size(468, 389)
      Me.dgvProductos.TabIndex = 14
      '
      'btnPreferenciasProductos
      '
      Me.btnPreferenciasProductos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnPreferenciasProductos.Image = Global.Eniac.Win.My.Resources.Resources.copy_ok_24
      Me.btnPreferenciasProductos.Location = New System.Drawing.Point(435, 533)
      Me.btnPreferenciasProductos.Name = "btnPreferenciasProductos"
      Me.btnPreferenciasProductos.Size = New System.Drawing.Size(37, 27)
      Me.btnPreferenciasProductos.TabIndex = 16
      Me.btnPreferenciasProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnPreferenciasProductos.UseVisualStyleBackColor = True
      '
      'btnPreferenciasComponentes
      '
      Me.btnPreferenciasComponentes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnPreferenciasComponentes.Image = Global.Eniac.Win.My.Resources.Resources.copy_ok_24
      Me.btnPreferenciasComponentes.Location = New System.Drawing.Point(516, 533)
      Me.btnPreferenciasComponentes.Name = "btnPreferenciasComponentes"
      Me.btnPreferenciasComponentes.Size = New System.Drawing.Size(37, 27)
      Me.btnPreferenciasComponentes.TabIndex = 17
      Me.btnPreferenciasComponentes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnPreferenciasComponentes.UseVisualStyleBackColor = True
      '
      'dgvComponentes
      '
      Me.dgvComponentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.dgvComponentes.DisplayLayout.Appearance = Appearance13
      Me.dgvComponentes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance14.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvComponentes.DisplayLayout.GroupByBox.Appearance = Appearance14
      Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvComponentes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
      Me.dgvComponentes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvComponentes.DisplayLayout.GroupByBox.Hidden = True
      Me.dgvComponentes.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance16.BackColor2 = System.Drawing.SystemColors.Control
      Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvComponentes.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
      Me.dgvComponentes.DisplayLayout.MaxColScrollRegions = 1
      Me.dgvComponentes.DisplayLayout.MaxRowScrollRegions = 1
      Appearance17.BackColor = System.Drawing.SystemColors.Window
      Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
      Me.dgvComponentes.DisplayLayout.Override.ActiveCellAppearance = Appearance17
      Appearance18.BackColor = System.Drawing.SystemColors.Highlight
      Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dgvComponentes.DisplayLayout.Override.ActiveRowAppearance = Appearance18
      Me.dgvComponentes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.dgvComponentes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvComponentes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.dgvComponentes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance19.BackColor = System.Drawing.SystemColors.Window
      Me.dgvComponentes.DisplayLayout.Override.CardAreaAppearance = Appearance19
      Appearance20.BorderColor = System.Drawing.Color.Silver
      Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.dgvComponentes.DisplayLayout.Override.CellAppearance = Appearance20
      Me.dgvComponentes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.dgvComponentes.DisplayLayout.Override.CellPadding = 0
      Appearance21.BackColor = System.Drawing.SystemColors.Control
      Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance21.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvComponentes.DisplayLayout.Override.GroupByRowAppearance = Appearance21
      Appearance22.TextHAlignAsString = "Left"
      Me.dgvComponentes.DisplayLayout.Override.HeaderAppearance = Appearance22
      Me.dgvComponentes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.dgvComponentes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance23.BackColor = System.Drawing.SystemColors.Window
      Appearance23.BorderColor = System.Drawing.Color.Silver
      Me.dgvComponentes.DisplayLayout.Override.RowAppearance = Appearance23
      Me.dgvComponentes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.dgvComponentes.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
      Me.dgvComponentes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
      Me.dgvComponentes.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.dgvComponentes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dgvComponentes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dgvComponentes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.dgvComponentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgvComponentes.Location = New System.Drawing.Point(516, 143)
      Me.dgvComponentes.Name = "dgvComponentes"
      Me.dgvComponentes.Size = New System.Drawing.Size(466, 388)
      Me.dgvComponentes.TabIndex = 15
      Me.dgvComponentes.Text = "Componentes del Producto"
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.Location = New System.Drawing.Point(809, 531)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(90, 30)
      Me.btnAceptar.TabIndex = 18
      Me.btnAceptar.Text = "Aceptar (F4)"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      Me.btnAceptar.Visible = False
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_a_16
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.Location = New System.Drawing.Point(902, 531)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 19
      Me.btnCancelar.Text = "Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      Me.btnCancelar.Visible = False
      '
      'lblMarca
      '
      Me.lblMarca.AutoSize = True
      Me.lblMarca.LabelAsoc = Nothing
      Me.lblMarca.Location = New System.Drawing.Point(509, 44)
      Me.lblMarca.Name = "lblMarca"
      Me.lblMarca.Size = New System.Drawing.Size(37, 13)
      Me.lblMarca.TabIndex = 22
      Me.lblMarca.Text = "Marca"
      '
      'cmbMarca
      '
      Me.cmbMarca.BindearPropiedadControl = Nothing
      Me.cmbMarca.BindearPropiedadEntidad = Nothing
      Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMarca.FormattingEnabled = True
      Me.cmbMarca.IsPK = False
      Me.cmbMarca.IsRequired = False
      Me.cmbMarca.Key = Nothing
      Me.cmbMarca.LabelAsoc = Me.lblMarca
      Me.cmbMarca.Location = New System.Drawing.Point(552, 41)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(233, 21)
      Me.cmbMarca.TabIndex = 23
      '
      'lblRubro
      '
      Me.lblRubro.AutoSize = True
      Me.lblRubro.LabelAsoc = Nothing
      Me.lblRubro.Location = New System.Drawing.Point(508, 71)
      Me.lblRubro.Name = "lblRubro"
      Me.lblRubro.Size = New System.Drawing.Size(36, 13)
      Me.lblRubro.TabIndex = 24
      Me.lblRubro.Text = "Rubro"
      '
      'cmbRubro
      '
      Me.cmbRubro.BindearPropiedadControl = Nothing
      Me.cmbRubro.BindearPropiedadEntidad = Nothing
      Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRubro.FormattingEnabled = True
      Me.cmbRubro.IsPK = False
      Me.cmbRubro.IsRequired = False
      Me.cmbRubro.Key = Nothing
      Me.cmbRubro.LabelAsoc = Me.lblRubro
      Me.cmbRubro.Location = New System.Drawing.Point(552, 68)
      Me.cmbRubro.Name = "cmbRubro"
      Me.cmbRubro.Size = New System.Drawing.Size(233, 21)
      Me.cmbRubro.TabIndex = 25
      '
      'btnBuscar
      '
      Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnBuscar.Location = New System.Drawing.Point(846, 58)
      Me.btnBuscar.Name = "btnBuscar"
      Me.btnBuscar.Size = New System.Drawing.Size(89, 40)
      Me.btnBuscar.TabIndex = 39
      Me.btnBuscar.Text = "&Buscar"
      Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnBuscar.UseVisualStyleBackColor = True
      '
      'JerarquiaProductos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 561)
      Me.Controls.Add(Me.btnBuscar)
      Me.Controls.Add(Me.lblMarca)
      Me.Controls.Add(Me.cmbMarca)
      Me.Controls.Add(Me.lblRubro)
      Me.Controls.Add(Me.cmbRubro)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.cmbFormulas)
      Me.Controls.Add(Me.btnPreferenciasComponentes)
      Me.Controls.Add(Me.btnPreferenciasProductos)
      Me.Controls.Add(Me.dgvComponentes)
      Me.Controls.Add(Me.dgvProductos)
      Me.Controls.Add(Me.lblFormula)
      Me.Controls.Add(Me.btnEliminarComponente)
      Me.Controls.Add(Me.btnAgregarComponente)
      Me.Controls.Add(Me.grpConceptos)
      Me.Controls.Add(Me.tstBarra)
      Me.KeyPreview = True
      Me.Name = "JerarquiaProductos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Jerarquía de Productos"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grpConceptos.ResumeLayout(False)
      Me.grpConceptos.PerformLayout()
      CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvComponentes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbEliminarFormula As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grpConceptos As System.Windows.Forms.GroupBox
   Friend WithEvents btnEliminarComponente As Eniac.Controles.Button
   Friend WithEvents btnAgregarComponente As Eniac.Controles.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents chbCopiar As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormulas As Eniac.Controles.ComboBox
   Friend WithEvents tsbAgregarFormula As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbGrabarFormula As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents lblFormula As Eniac.Controles.Label
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCopiarNombreProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCopiarCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents tsbModificarFormula As System.Windows.Forms.ToolStripButton
   Friend WithEvents dgvProductos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents dgvComponentes As UltraGridEditable
   Friend WithEvents btnPreferenciasProductos As Eniac.Controles.Button
   Friend WithEvents btnPreferenciasComponentes As Eniac.Controles.Button
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents cmbMarca As Eniac.Win.ComboBoxMarcas
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents cmbRubro As Eniac.Win.ComboBoxRubro
   Friend WithEvents btnBuscar As Eniac.Controles.Button
End Class
