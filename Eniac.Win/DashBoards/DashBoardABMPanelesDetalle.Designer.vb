<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashBoardABMPanelesDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
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

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashBoardABMPanelesDetalle))
      Me.txtIdDashBoard = New Eniac.Controles.TextBox()
      Me.lblIdDashBoard = New Eniac.Controles.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.tpgSeteaDatos = New System.Windows.Forms.TabPage()
        Me.chbShowLeyendLabel = New Eniac.Controles.CheckBox()
        Me.lblMinimoDashBoard = New Eniac.Controles.Label()
        Me.txtMinimoDashBoard = New Eniac.Controles.TextBox()
        Me.lblObjetivoDashBoard = New Eniac.Controles.Label()
        Me.txtObjetivoDashBoard = New Eniac.Controles.TextBox()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.lblImagenDashBoard = New Eniac.Controles.Label()
        Me.lblTiempoDashBoard = New Eniac.Controles.Label()
        Me.txtTiempoDashBoard = New Eniac.Controles.TextBox()
        Me.chbRefrescaDatos = New Eniac.Controles.CheckBox()
        Me.chbEstadoDash = New Eniac.Controles.CheckBox()
        Me.lblOrdenDashBoard = New Eniac.Controles.Label()
        Me.txtOrdenDashBoard = New Eniac.Controles.TextBox()
        Me.lblComentarioDashBoard = New Eniac.Controles.Label()
        Me.lblTituloDashBoard = New Eniac.Controles.Label()
        Me.gpbDashBoardGrafico = New System.Windows.Forms.GroupBox()
        Me.lblModeloDashBoard = New Eniac.Controles.Label()
        Me.chbTituloYDash = New Eniac.Controles.CheckBox()
        Me.chbTituloXDash = New Eniac.Controles.CheckBox()
        Me.chbShowValueLabel = New Eniac.Controles.CheckBox()
        Me.chbEstiloArea3D = New Eniac.Controles.CheckBox()
        Me.txtTituloYDash = New Eniac.Controles.TextBox()
        Me.txtTituloXDash = New Eniac.Controles.TextBox()
        Me.txtComentarioDashBoard = New Eniac.Controles.TextBox()
        Me.txtTituloDashBoard = New Eniac.Controles.TextBox()
        Me.tpgSentenciaSQL = New System.Windows.Forms.TabPage()
        Me.txtSentenciaSQLDashB = New System.Windows.Forms.TextBox()
        Me.lblSentenciaSQL = New Eniac.Controles.Label()
        Me.txtNombreDashBoard = New Eniac.Controles.TextBox()
        Me.lblNombreDashBoard = New Eniac.Controles.Label()
        Me.lblTipoDashBoard = New Eniac.Controles.Label()
        Me.pnlVisualizadorDashBoard = New System.Windows.Forms.Panel()
        Me.DialogoAbrirArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.cmbTipoDashBoard = New Eniac.Controles.ComboBox()
        Me.cmbTipoRefreshDashBoard = New Eniac.Controles.ComboBox()
        Me.cmbModeloDashBoard = New Eniac.Controles.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.tpgSeteaDatos.SuspendLayout()
        Me.gpbDashBoardGrafico.SuspendLayout()
        Me.tpgSentenciaSQL.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(442, 355)
        Me.btnAceptar.Size = New System.Drawing.Size(93, 35)
        Me.btnAceptar.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(542, 355)
        Me.btnCancelar.Size = New System.Drawing.Size(93, 35)
        Me.btnCancelar.TabIndex = 5
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(324, 355)
        Me.btnCopiar.Size = New System.Drawing.Size(111, 35)
        Me.btnCopiar.TabIndex = 23
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(258, 355)
        Me.btnAplicar.Size = New System.Drawing.Size(63, 35)
        Me.btnAplicar.TabIndex = 22
        '
        'txtIdDashBoard
        '
        Me.txtIdDashBoard.BindearPropiedadControl = ""
        Me.txtIdDashBoard.BindearPropiedadEntidad = ""
        Me.txtIdDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdDashBoard.Formato = ""
        Me.txtIdDashBoard.IsDecimal = False
        Me.txtIdDashBoard.IsNumber = True
        Me.txtIdDashBoard.IsPK = True
        Me.txtIdDashBoard.IsRequired = True
        Me.txtIdDashBoard.Key = ""
        Me.txtIdDashBoard.LabelAsoc = Me.lblIdDashBoard
        Me.txtIdDashBoard.Location = New System.Drawing.Point(66, 12)
        Me.txtIdDashBoard.MaxLength = 15
        Me.txtIdDashBoard.Name = "txtIdDashBoard"
        Me.txtIdDashBoard.ReadOnly = True
        Me.txtIdDashBoard.Size = New System.Drawing.Size(66, 21)
        Me.txtIdDashBoard.TabIndex = 0
        '
        'lblIdDashBoard
        '
        Me.lblIdDashBoard.AutoSize = True
        Me.lblIdDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblIdDashBoard.LabelAsoc = Nothing
        Me.lblIdDashBoard.Location = New System.Drawing.Point(12, 15)
        Me.lblIdDashBoard.Name = "lblIdDashBoard"
        Me.lblIdDashBoard.Size = New System.Drawing.Size(46, 15)
        Me.lblIdDashBoard.TabIndex = 64
        Me.lblIdDashBoard.Text = "Código"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpgSeteaDatos)
        Me.TabControl1.Controls.Add(Me.tpgSentenciaSQL)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(11, 46)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(629, 300)
        Me.TabControl1.TabIndex = 3
        '
        'tpgSeteaDatos
        '
        Me.tpgSeteaDatos.BackColor = System.Drawing.SystemColors.Control
        Me.tpgSeteaDatos.Controls.Add(Me.cmbTipoRefreshDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.lblMinimoDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.txtMinimoDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.lblObjetivoDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.txtObjetivoDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.btnInsertar)
        Me.tpgSeteaDatos.Controls.Add(Me.btnEliminar)
        Me.tpgSeteaDatos.Controls.Add(Me.lblImagenDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.lblTiempoDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.txtTiempoDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.chbRefrescaDatos)
        Me.tpgSeteaDatos.Controls.Add(Me.chbEstadoDash)
        Me.tpgSeteaDatos.Controls.Add(Me.lblOrdenDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.txtOrdenDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.lblComentarioDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.lblTituloDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.gpbDashBoardGrafico)
        Me.tpgSeteaDatos.Controls.Add(Me.txtComentarioDashBoard)
        Me.tpgSeteaDatos.Controls.Add(Me.txtTituloDashBoard)
        Me.tpgSeteaDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpgSeteaDatos.Location = New System.Drawing.Point(4, 24)
        Me.tpgSeteaDatos.Name = "tpgSeteaDatos"
        Me.tpgSeteaDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgSeteaDatos.Size = New System.Drawing.Size(621, 272)
        Me.tpgSeteaDatos.TabIndex = 0
        Me.tpgSeteaDatos.Text = "Seteo Datos"
        '
        'chbShowLeyendLabel
        '
        Me.chbShowLeyendLabel.AutoSize = True
        Me.chbShowLeyendLabel.BindearPropiedadControl = ""
        Me.chbShowLeyendLabel.BindearPropiedadEntidad = ""
        Me.chbShowLeyendLabel.ForeColorFocus = System.Drawing.Color.Red
        Me.chbShowLeyendLabel.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbShowLeyendLabel.IsPK = False
        Me.chbShowLeyendLabel.IsRequired = False
        Me.chbShowLeyendLabel.Key = Nothing
        Me.chbShowLeyendLabel.LabelAsoc = Nothing
        Me.chbShowLeyendLabel.Location = New System.Drawing.Point(14, 98)
        Me.chbShowLeyendLabel.Name = "chbShowLeyendLabel"
        Me.chbShowLeyendLabel.Size = New System.Drawing.Size(180, 19)
        Me.chbShowLeyendLabel.TabIndex = 5
        Me.chbShowLeyendLabel.Text = "Visualiza Leyenda de Datos."
        Me.chbShowLeyendLabel.UseVisualStyleBackColor = True
        '
        'lblMinimoDashBoard
        '
        Me.lblMinimoDashBoard.AutoSize = True
        Me.lblMinimoDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblMinimoDashBoard.LabelAsoc = Nothing
        Me.lblMinimoDashBoard.Location = New System.Drawing.Point(228, 95)
        Me.lblMinimoDashBoard.Name = "lblMinimoDashBoard"
        Me.lblMinimoDashBoard.Size = New System.Drawing.Size(49, 15)
        Me.lblMinimoDashBoard.TabIndex = 84
        Me.lblMinimoDashBoard.Text = "Mínimo"
        '
        'txtMinimoDashBoard
        '
        Me.txtMinimoDashBoard.BindearPropiedadControl = ""
        Me.txtMinimoDashBoard.BindearPropiedadEntidad = ""
        Me.txtMinimoDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMinimoDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMinimoDashBoard.Formato = ""
        Me.txtMinimoDashBoard.IsDecimal = True
        Me.txtMinimoDashBoard.IsNumber = True
        Me.txtMinimoDashBoard.IsPK = False
        Me.txtMinimoDashBoard.IsRequired = True
        Me.txtMinimoDashBoard.Key = ""
        Me.txtMinimoDashBoard.LabelAsoc = Me.lblMinimoDashBoard
        Me.txtMinimoDashBoard.Location = New System.Drawing.Point(283, 92)
        Me.txtMinimoDashBoard.MaxLength = 15
        Me.txtMinimoDashBoard.Name = "txtMinimoDashBoard"
        Me.txtMinimoDashBoard.Size = New System.Drawing.Size(112, 21)
        Me.txtMinimoDashBoard.TabIndex = 8
        Me.txtMinimoDashBoard.Text = "0.00"
        Me.txtMinimoDashBoard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblObjetivoDashBoard
        '
        Me.lblObjetivoDashBoard.AutoSize = True
        Me.lblObjetivoDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblObjetivoDashBoard.LabelAsoc = Nothing
        Me.lblObjetivoDashBoard.Location = New System.Drawing.Point(16, 95)
        Me.lblObjetivoDashBoard.Name = "lblObjetivoDashBoard"
        Me.lblObjetivoDashBoard.Size = New System.Drawing.Size(51, 15)
        Me.lblObjetivoDashBoard.TabIndex = 82
        Me.lblObjetivoDashBoard.Text = "Objetivo"
        '
        'txtObjetivoDashBoard
        '
        Me.txtObjetivoDashBoard.BindearPropiedadControl = ""
        Me.txtObjetivoDashBoard.BindearPropiedadEntidad = ""
        Me.txtObjetivoDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObjetivoDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObjetivoDashBoard.Formato = ""
        Me.txtObjetivoDashBoard.IsDecimal = True
        Me.txtObjetivoDashBoard.IsNumber = True
        Me.txtObjetivoDashBoard.IsPK = False
        Me.txtObjetivoDashBoard.IsRequired = True
        Me.txtObjetivoDashBoard.Key = ""
        Me.txtObjetivoDashBoard.LabelAsoc = Me.lblObjetivoDashBoard
        Me.txtObjetivoDashBoard.Location = New System.Drawing.Point(91, 92)
        Me.txtObjetivoDashBoard.MaxLength = 15
        Me.txtObjetivoDashBoard.Name = "txtObjetivoDashBoard"
        Me.txtObjetivoDashBoard.Size = New System.Drawing.Size(123, 21)
        Me.txtObjetivoDashBoard.TabIndex = 7
        Me.txtObjetivoDashBoard.Text = "0.00"
        Me.txtObjetivoDashBoard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnInsertar
        '
        Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
        Me.btnInsertar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInsertar.Location = New System.Drawing.Point(527, 84)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 9
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminar.Location = New System.Drawing.Point(564, 84)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 10
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblImagenDashBoard
        '
        Me.lblImagenDashBoard.AutoSize = True
        Me.lblImagenDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblImagenDashBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImagenDashBoard.LabelAsoc = Nothing
        Me.lblImagenDashBoard.Location = New System.Drawing.Point(406, 97)
        Me.lblImagenDashBoard.Name = "lblImagenDashBoard"
        Me.lblImagenDashBoard.Size = New System.Drawing.Size(114, 13)
        Me.lblImagenDashBoard.TabIndex = 78
        Me.lblImagenDashBoard.Text = "Imagen DashBoard"
        '
        'lblTiempoDashBoard
        '
        Me.lblTiempoDashBoard.AutoSize = True
        Me.lblTiempoDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblTiempoDashBoard.LabelAsoc = Nothing
        Me.lblTiempoDashBoard.Location = New System.Drawing.Point(412, 57)
        Me.lblTiempoDashBoard.Name = "lblTiempoDashBoard"
        Me.lblTiempoDashBoard.Size = New System.Drawing.Size(53, 15)
        Me.lblTiempoDashBoard.TabIndex = 76
        Me.lblTiempoDashBoard.Text = "Intervalo"
        '
        'txtTiempoDashBoard
        '
        Me.txtTiempoDashBoard.BindearPropiedadControl = ""
        Me.txtTiempoDashBoard.BindearPropiedadEntidad = ""
        Me.txtTiempoDashBoard.Enabled = False
        Me.txtTiempoDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTiempoDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTiempoDashBoard.Formato = ""
        Me.txtTiempoDashBoard.IsDecimal = False
        Me.txtTiempoDashBoard.IsNumber = True
        Me.txtTiempoDashBoard.IsPK = False
        Me.txtTiempoDashBoard.IsRequired = True
        Me.txtTiempoDashBoard.Key = ""
        Me.txtTiempoDashBoard.LabelAsoc = Me.lblTiempoDashBoard
        Me.txtTiempoDashBoard.Location = New System.Drawing.Point(471, 54)
        Me.txtTiempoDashBoard.MaxLength = 15
        Me.txtTiempoDashBoard.Name = "txtTiempoDashBoard"
        Me.txtTiempoDashBoard.Size = New System.Drawing.Size(38, 21)
        Me.txtTiempoDashBoard.TabIndex = 5
        Me.txtTiempoDashBoard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbRefrescaDatos
        '
        Me.chbRefrescaDatos.AutoSize = True
        Me.chbRefrescaDatos.BindearPropiedadControl = ""
        Me.chbRefrescaDatos.BindearPropiedadEntidad = ""
        Me.chbRefrescaDatos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRefrescaDatos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRefrescaDatos.IsPK = False
        Me.chbRefrescaDatos.IsRequired = False
        Me.chbRefrescaDatos.Key = Nothing
        Me.chbRefrescaDatos.LabelAsoc = Nothing
        Me.chbRefrescaDatos.Location = New System.Drawing.Point(332, 56)
        Me.chbRefrescaDatos.Name = "chbRefrescaDatos"
        Me.chbRefrescaDatos.Size = New System.Drawing.Size(79, 19)
        Me.chbRefrescaDatos.TabIndex = 4
        Me.chbRefrescaDatos.Text = "Refrescar"
        Me.chbRefrescaDatos.UseVisualStyleBackColor = True
        '
        'chbEstadoDash
        '
        Me.chbEstadoDash.AutoSize = True
        Me.chbEstadoDash.BindearPropiedadControl = ""
        Me.chbEstadoDash.BindearPropiedadEntidad = ""
        Me.chbEstadoDash.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstadoDash.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstadoDash.IsPK = False
        Me.chbEstadoDash.IsRequired = False
        Me.chbEstadoDash.Key = Nothing
        Me.chbEstadoDash.LabelAsoc = Nothing
        Me.chbEstadoDash.Location = New System.Drawing.Point(543, 23)
        Me.chbEstadoDash.Name = "chbEstadoDash"
        Me.chbEstadoDash.Size = New System.Drawing.Size(57, 19)
        Me.chbEstadoDash.TabIndex = 2
        Me.chbEstadoDash.Text = "Activo"
        Me.chbEstadoDash.UseVisualStyleBackColor = True
        '
        'lblOrdenDashBoard
        '
        Me.lblOrdenDashBoard.AutoSize = True
        Me.lblOrdenDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblOrdenDashBoard.LabelAsoc = Nothing
        Me.lblOrdenDashBoard.Location = New System.Drawing.Point(441, 24)
        Me.lblOrdenDashBoard.Name = "lblOrdenDashBoard"
        Me.lblOrdenDashBoard.Size = New System.Drawing.Size(41, 15)
        Me.lblOrdenDashBoard.TabIndex = 72
        Me.lblOrdenDashBoard.Text = "Orden"
        '
        'txtOrdenDashBoard
        '
        Me.txtOrdenDashBoard.BindearPropiedadControl = ""
        Me.txtOrdenDashBoard.BindearPropiedadEntidad = ""
        Me.txtOrdenDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdenDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdenDashBoard.Formato = ""
        Me.txtOrdenDashBoard.IsDecimal = False
        Me.txtOrdenDashBoard.IsNumber = False
        Me.txtOrdenDashBoard.IsPK = False
        Me.txtOrdenDashBoard.IsRequired = True
        Me.txtOrdenDashBoard.Key = ""
        Me.txtOrdenDashBoard.LabelAsoc = Me.lblOrdenDashBoard
        Me.txtOrdenDashBoard.Location = New System.Drawing.Point(489, 21)
        Me.txtOrdenDashBoard.MaxLength = 15
        Me.txtOrdenDashBoard.Name = "txtOrdenDashBoard"
        Me.txtOrdenDashBoard.Size = New System.Drawing.Size(38, 21)
        Me.txtOrdenDashBoard.TabIndex = 1
        Me.txtOrdenDashBoard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblComentarioDashBoard
        '
        Me.lblComentarioDashBoard.AutoSize = True
        Me.lblComentarioDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblComentarioDashBoard.LabelAsoc = Nothing
        Me.lblComentarioDashBoard.Location = New System.Drawing.Point(14, 57)
        Me.lblComentarioDashBoard.Name = "lblComentarioDashBoard"
        Me.lblComentarioDashBoard.Size = New System.Drawing.Size(71, 15)
        Me.lblComentarioDashBoard.TabIndex = 65
        Me.lblComentarioDashBoard.Text = "Comentario"
        '
        'lblTituloDashBoard
        '
        Me.lblTituloDashBoard.AutoSize = True
        Me.lblTituloDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblTituloDashBoard.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTituloDashBoard.LabelAsoc = Nothing
        Me.lblTituloDashBoard.Location = New System.Drawing.Point(16, 24)
        Me.lblTituloDashBoard.Name = "lblTituloDashBoard"
        Me.lblTituloDashBoard.Size = New System.Drawing.Size(37, 15)
        Me.lblTituloDashBoard.TabIndex = 64
        Me.lblTituloDashBoard.Text = "Titulo"
        '
        'gpbDashBoardGrafico
        '
        Me.gpbDashBoardGrafico.BackColor = System.Drawing.SystemColors.Control
        Me.gpbDashBoardGrafico.Controls.Add(Me.chbShowLeyendLabel)
        Me.gpbDashBoardGrafico.Controls.Add(Me.lblModeloDashBoard)
        Me.gpbDashBoardGrafico.Controls.Add(Me.chbTituloYDash)
        Me.gpbDashBoardGrafico.Controls.Add(Me.chbTituloXDash)
        Me.gpbDashBoardGrafico.Controls.Add(Me.chbShowValueLabel)
        Me.gpbDashBoardGrafico.Controls.Add(Me.chbEstiloArea3D)
        Me.gpbDashBoardGrafico.Controls.Add(Me.cmbModeloDashBoard)
        Me.gpbDashBoardGrafico.Controls.Add(Me.txtTituloYDash)
        Me.gpbDashBoardGrafico.Controls.Add(Me.txtTituloXDash)
        Me.gpbDashBoardGrafico.Location = New System.Drawing.Point(16, 127)
        Me.gpbDashBoardGrafico.Name = "gpbDashBoardGrafico"
        Me.gpbDashBoardGrafico.Size = New System.Drawing.Size(587, 130)
        Me.gpbDashBoardGrafico.TabIndex = 39
        Me.gpbDashBoardGrafico.TabStop = False
        Me.gpbDashBoardGrafico.Text = "Grafico: "
        '
        'lblModeloDashBoard
        '
        Me.lblModeloDashBoard.AutoSize = True
        Me.lblModeloDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblModeloDashBoard.LabelAsoc = Nothing
        Me.lblModeloDashBoard.Location = New System.Drawing.Point(11, 29)
        Me.lblModeloDashBoard.Name = "lblModeloDashBoard"
        Me.lblModeloDashBoard.Size = New System.Drawing.Size(49, 15)
        Me.lblModeloDashBoard.TabIndex = 79
        Me.lblModeloDashBoard.Text = "Modelo"
        '
        'chbTituloYDash
        '
        Me.chbTituloYDash.AutoSize = True
        Me.chbTituloYDash.BindearPropiedadControl = ""
        Me.chbTituloYDash.BindearPropiedadEntidad = ""
        Me.chbTituloYDash.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTituloYDash.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTituloYDash.IsPK = False
        Me.chbTituloYDash.IsRequired = False
        Me.chbTituloYDash.Key = Nothing
        Me.chbTituloYDash.LabelAsoc = Nothing
        Me.chbTituloYDash.Location = New System.Drawing.Point(301, 64)
        Me.chbTituloYDash.Name = "chbTituloYDash"
        Me.chbTituloYDash.Size = New System.Drawing.Size(66, 19)
        Me.chbTituloYDash.TabIndex = 19
        Me.chbTituloYDash.Text = "Titulo Y"
        Me.chbTituloYDash.UseVisualStyleBackColor = True
        '
        'chbTituloXDash
        '
        Me.chbTituloXDash.AutoSize = True
        Me.chbTituloXDash.BindearPropiedadControl = ""
        Me.chbTituloXDash.BindearPropiedadEntidad = ""
        Me.chbTituloXDash.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTituloXDash.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTituloXDash.IsPK = False
        Me.chbTituloXDash.IsRequired = False
        Me.chbTituloXDash.Key = Nothing
        Me.chbTituloXDash.LabelAsoc = Nothing
        Me.chbTituloXDash.Location = New System.Drawing.Point(14, 64)
        Me.chbTituloXDash.Name = "chbTituloXDash"
        Me.chbTituloXDash.Size = New System.Drawing.Size(67, 19)
        Me.chbTituloXDash.TabIndex = 17
        Me.chbTituloXDash.Text = "Titulo X"
        Me.chbTituloXDash.UseVisualStyleBackColor = True
        '
        'chbShowValueLabel
        '
        Me.chbShowValueLabel.AutoSize = True
        Me.chbShowValueLabel.BindearPropiedadControl = ""
        Me.chbShowValueLabel.BindearPropiedadEntidad = ""
        Me.chbShowValueLabel.ForeColorFocus = System.Drawing.Color.Red
        Me.chbShowValueLabel.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbShowValueLabel.IsPK = False
        Me.chbShowValueLabel.IsRequired = False
        Me.chbShowValueLabel.Key = Nothing
        Me.chbShowValueLabel.LabelAsoc = Nothing
        Me.chbShowValueLabel.Location = New System.Drawing.Point(407, 28)
        Me.chbShowValueLabel.Name = "chbShowValueLabel"
        Me.chbShowValueLabel.Size = New System.Drawing.Size(171, 19)
        Me.chbShowValueLabel.TabIndex = 2
        Me.chbShowValueLabel.Text = "Visualiza Puntos de Datos."
        Me.chbShowValueLabel.UseVisualStyleBackColor = True
        '
        'chbEstiloArea3D
        '
        Me.chbEstiloArea3D.AutoSize = True
        Me.chbEstiloArea3D.BindearPropiedadControl = ""
        Me.chbEstiloArea3D.BindearPropiedadEntidad = ""
        Me.chbEstiloArea3D.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstiloArea3D.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstiloArea3D.IsPK = False
        Me.chbEstiloArea3D.IsRequired = False
        Me.chbEstiloArea3D.Key = Nothing
        Me.chbEstiloArea3D.LabelAsoc = Nothing
        Me.chbEstiloArea3D.Location = New System.Drawing.Point(301, 28)
        Me.chbEstiloArea3D.Name = "chbEstiloArea3D"
        Me.chbEstiloArea3D.Size = New System.Drawing.Size(103, 19)
        Me.chbEstiloArea3D.TabIndex = 1
        Me.chbEstiloArea3D.Text = "Estilo Area 3D"
        Me.chbEstiloArea3D.UseVisualStyleBackColor = True
        '
        'txtTituloYDash
        '
        Me.txtTituloYDash.BindearPropiedadControl = ""
        Me.txtTituloYDash.BindearPropiedadEntidad = ""
        Me.txtTituloYDash.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTituloYDash.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTituloYDash.Formato = ""
        Me.txtTituloYDash.IsDecimal = False
        Me.txtTituloYDash.IsNumber = False
        Me.txtTituloYDash.IsPK = False
        Me.txtTituloYDash.IsRequired = False
        Me.txtTituloYDash.Key = ""
        Me.txtTituloYDash.LabelAsoc = Me.chbTituloYDash
        Me.txtTituloYDash.Location = New System.Drawing.Point(378, 62)
        Me.txtTituloYDash.MaxLength = 30
        Me.txtTituloYDash.Name = "txtTituloYDash"
        Me.txtTituloYDash.Size = New System.Drawing.Size(199, 21)
        Me.txtTituloYDash.TabIndex = 4
        '
        'txtTituloXDash
        '
        Me.txtTituloXDash.BindearPropiedadControl = ""
        Me.txtTituloXDash.BindearPropiedadEntidad = ""
        Me.txtTituloXDash.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTituloXDash.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTituloXDash.Formato = ""
        Me.txtTituloXDash.IsDecimal = False
        Me.txtTituloXDash.IsNumber = False
        Me.txtTituloXDash.IsPK = False
        Me.txtTituloXDash.IsRequired = False
        Me.txtTituloXDash.Key = ""
        Me.txtTituloXDash.LabelAsoc = Me.chbTituloXDash
        Me.txtTituloXDash.Location = New System.Drawing.Point(87, 62)
        Me.txtTituloXDash.MaxLength = 30
        Me.txtTituloXDash.Name = "txtTituloXDash"
        Me.txtTituloXDash.Size = New System.Drawing.Size(207, 21)
        Me.txtTituloXDash.TabIndex = 3
        '
        'txtComentarioDashBoard
        '
        Me.txtComentarioDashBoard.BindearPropiedadControl = ""
        Me.txtComentarioDashBoard.BindearPropiedadEntidad = ""
        Me.txtComentarioDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComentarioDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComentarioDashBoard.Formato = ""
        Me.txtComentarioDashBoard.IsDecimal = False
        Me.txtComentarioDashBoard.IsNumber = False
        Me.txtComentarioDashBoard.IsPK = False
        Me.txtComentarioDashBoard.IsRequired = False
        Me.txtComentarioDashBoard.Key = ""
        Me.txtComentarioDashBoard.LabelAsoc = Me.lblComentarioDashBoard
        Me.txtComentarioDashBoard.Location = New System.Drawing.Point(91, 54)
        Me.txtComentarioDashBoard.MaxLength = 50
        Me.txtComentarioDashBoard.Name = "txtComentarioDashBoard"
        Me.txtComentarioDashBoard.Size = New System.Drawing.Size(235, 21)
        Me.txtComentarioDashBoard.TabIndex = 3
        '
        'txtTituloDashBoard
        '
        Me.txtTituloDashBoard.BindearPropiedadControl = ""
        Me.txtTituloDashBoard.BindearPropiedadEntidad = ""
        Me.txtTituloDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTituloDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTituloDashBoard.Formato = ""
        Me.txtTituloDashBoard.IsDecimal = False
        Me.txtTituloDashBoard.IsNumber = False
        Me.txtTituloDashBoard.IsPK = False
        Me.txtTituloDashBoard.IsRequired = True
        Me.txtTituloDashBoard.Key = ""
        Me.txtTituloDashBoard.LabelAsoc = Me.lblTituloDashBoard
        Me.txtTituloDashBoard.Location = New System.Drawing.Point(91, 21)
        Me.txtTituloDashBoard.MaxLength = 50
        Me.txtTituloDashBoard.Name = "txtTituloDashBoard"
        Me.txtTituloDashBoard.Size = New System.Drawing.Size(344, 21)
        Me.txtTituloDashBoard.TabIndex = 0
        '
        'tpgSentenciaSQL
        '
        Me.tpgSentenciaSQL.BackColor = System.Drawing.SystemColors.Control
        Me.tpgSentenciaSQL.Controls.Add(Me.txtSentenciaSQLDashB)
        Me.tpgSentenciaSQL.Controls.Add(Me.lblSentenciaSQL)
        Me.tpgSentenciaSQL.Location = New System.Drawing.Point(4, 24)
        Me.tpgSentenciaSQL.Name = "tpgSentenciaSQL"
        Me.tpgSentenciaSQL.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgSentenciaSQL.Size = New System.Drawing.Size(621, 272)
        Me.tpgSentenciaSQL.TabIndex = 1
        Me.tpgSentenciaSQL.Text = "Sentencia SQL"
        '
        'txtSentenciaSQLDashB
        '
        Me.txtSentenciaSQLDashB.Location = New System.Drawing.Point(8, 8)
        Me.txtSentenciaSQLDashB.Multiline = True
        Me.txtSentenciaSQLDashB.Name = "txtSentenciaSQLDashB"
        Me.txtSentenciaSQLDashB.Size = New System.Drawing.Size(602, 255)
        Me.txtSentenciaSQLDashB.TabIndex = 66
        '
        'lblSentenciaSQL
        '
        Me.lblSentenciaSQL.AutoSize = True
        Me.lblSentenciaSQL.BackColor = System.Drawing.Color.Transparent
        Me.lblSentenciaSQL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSentenciaSQL.LabelAsoc = Nothing
        Me.lblSentenciaSQL.Location = New System.Drawing.Point(292, 129)
        Me.lblSentenciaSQL.Name = "lblSentenciaSQL"
        Me.lblSentenciaSQL.Size = New System.Drawing.Size(89, 15)
        Me.lblSentenciaSQL.TabIndex = 65
        Me.lblSentenciaSQL.Text = "Sentencia SQL"
        '
        'txtNombreDashBoard
        '
        Me.txtNombreDashBoard.BindearPropiedadControl = ""
        Me.txtNombreDashBoard.BindearPropiedadEntidad = ""
        Me.txtNombreDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreDashBoard.Formato = ""
        Me.txtNombreDashBoard.IsDecimal = False
        Me.txtNombreDashBoard.IsNumber = False
        Me.txtNombreDashBoard.IsPK = False
        Me.txtNombreDashBoard.IsRequired = True
        Me.txtNombreDashBoard.Key = ""
        Me.txtNombreDashBoard.LabelAsoc = Me.lblNombreDashBoard
        Me.txtNombreDashBoard.Location = New System.Drawing.Point(379, 12)
        Me.txtNombreDashBoard.MaxLength = 30
        Me.txtNombreDashBoard.Name = "txtNombreDashBoard"
        Me.txtNombreDashBoard.Size = New System.Drawing.Size(265, 21)
        Me.txtNombreDashBoard.TabIndex = 2
        Me.txtNombreDashBoard.TabStop = False
        '
        'lblNombreDashBoard
        '
        Me.lblNombreDashBoard.AutoSize = True
        Me.lblNombreDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreDashBoard.LabelAsoc = Nothing
        Me.lblNombreDashBoard.Location = New System.Drawing.Point(324, 15)
        Me.lblNombreDashBoard.Name = "lblNombreDashBoard"
        Me.lblNombreDashBoard.Size = New System.Drawing.Size(52, 15)
        Me.lblNombreDashBoard.TabIndex = 65
        Me.lblNombreDashBoard.Text = "Nombre"
        '
        'lblTipoDashBoard
        '
        Me.lblTipoDashBoard.AutoSize = True
        Me.lblTipoDashBoard.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoDashBoard.LabelAsoc = Nothing
        Me.lblTipoDashBoard.Location = New System.Drawing.Point(138, 15)
        Me.lblTipoDashBoard.Name = "lblTipoDashBoard"
        Me.lblTipoDashBoard.Size = New System.Drawing.Size(31, 15)
        Me.lblTipoDashBoard.TabIndex = 66
        Me.lblTipoDashBoard.Text = "Tipo"
        '
        'pnlVisualizadorDashBoard
        '
        Me.pnlVisualizadorDashBoard.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.pnlVisualizadorDashBoard.Location = New System.Drawing.Point(654, -3)
        Me.pnlVisualizadorDashBoard.Name = "pnlVisualizadorDashBoard"
        Me.pnlVisualizadorDashBoard.Size = New System.Drawing.Size(676, 412)
        Me.pnlVisualizadorDashBoard.TabIndex = 67
        '
        'DialogoAbrirArchivo
        '
        Me.DialogoAbrirArchivo.Filter = "Todos los Archivos (*.*)|*.*"
        Me.DialogoAbrirArchivo.RestoreDirectory = True
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(15, 355)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(104, 35)
        Me.btnVisualizar.TabIndex = 3
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'cmbTipoDashBoard
        '
        Me.cmbTipoDashBoard.BindearPropiedadControl = ""
        Me.cmbTipoDashBoard.BindearPropiedadEntidad = ""
        Me.cmbTipoDashBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDashBoard.FormattingEnabled = True
        Me.cmbTipoDashBoard.IsPK = False
        Me.cmbTipoDashBoard.IsRequired = False
        Me.cmbTipoDashBoard.Key = Nothing
        Me.cmbTipoDashBoard.LabelAsoc = Me.lblTipoDashBoard
        Me.cmbTipoDashBoard.Location = New System.Drawing.Point(175, 12)
        Me.cmbTipoDashBoard.Name = "cmbTipoDashBoard"
        Me.cmbTipoDashBoard.Size = New System.Drawing.Size(143, 23)
        Me.cmbTipoDashBoard.TabIndex = 1
        '
        'cmbTipoRefreshDashBoard
        '
        Me.cmbTipoRefreshDashBoard.BindearPropiedadControl = ""
        Me.cmbTipoRefreshDashBoard.BindearPropiedadEntidad = ""
        Me.cmbTipoRefreshDashBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoRefreshDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoRefreshDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoRefreshDashBoard.FormattingEnabled = True
        Me.cmbTipoRefreshDashBoard.IsPK = False
        Me.cmbTipoRefreshDashBoard.IsRequired = False
        Me.cmbTipoRefreshDashBoard.Key = Nothing
        Me.cmbTipoRefreshDashBoard.LabelAsoc = Nothing
        Me.cmbTipoRefreshDashBoard.Location = New System.Drawing.Point(520, 54)
        Me.cmbTipoRefreshDashBoard.Name = "cmbTipoRefreshDashBoard"
        Me.cmbTipoRefreshDashBoard.Size = New System.Drawing.Size(74, 23)
        Me.cmbTipoRefreshDashBoard.TabIndex = 6
        '
        'cmbModeloDashBoard
        '
        Me.cmbModeloDashBoard.BindearPropiedadControl = ""
        Me.cmbModeloDashBoard.BindearPropiedadEntidad = ""
        Me.cmbModeloDashBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModeloDashBoard.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbModeloDashBoard.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbModeloDashBoard.FormattingEnabled = True
        Me.cmbModeloDashBoard.IsPK = False
        Me.cmbModeloDashBoard.IsRequired = False
        Me.cmbModeloDashBoard.Key = Nothing
        Me.cmbModeloDashBoard.LabelAsoc = Me.lblModeloDashBoard
        Me.cmbModeloDashBoard.Location = New System.Drawing.Point(87, 25)
        Me.cmbModeloDashBoard.Name = "cmbModeloDashBoard"
        Me.cmbModeloDashBoard.Size = New System.Drawing.Size(205, 23)
        Me.cmbModeloDashBoard.TabIndex = 0
        '
        'DashBoardABMPanelesDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1319, 398)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.pnlVisualizadorDashBoard)
        Me.Controls.Add(Me.lblTipoDashBoard)
        Me.Controls.Add(Me.lblNombreDashBoard)
        Me.Controls.Add(Me.lblIdDashBoard)
        Me.Controls.Add(Me.cmbTipoDashBoard)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtNombreDashBoard)
        Me.Controls.Add(Me.txtIdDashBoard)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DashBoardABMPanelesDetalle"
        Me.Text = "Detalle DashBoard"
        Me.Controls.SetChildIndex(Me.txtIdDashBoard, 0)
        Me.Controls.SetChildIndex(Me.txtNombreDashBoard, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoDashBoard, 0)
        Me.Controls.SetChildIndex(Me.lblIdDashBoard, 0)
        Me.Controls.SetChildIndex(Me.lblNombreDashBoard, 0)
        Me.Controls.SetChildIndex(Me.lblTipoDashBoard, 0)
        Me.Controls.SetChildIndex(Me.pnlVisualizadorDashBoard, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.tpgSeteaDatos.ResumeLayout(False)
        Me.tpgSeteaDatos.PerformLayout()
        Me.gpbDashBoardGrafico.ResumeLayout(False)
        Me.gpbDashBoardGrafico.PerformLayout()
        Me.tpgSentenciaSQL.ResumeLayout(False)
        Me.tpgSentenciaSQL.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIdDashBoard As Controles.TextBox
   Friend WithEvents cmbTipoDashBoard As Controles.ComboBox
   Friend WithEvents TabControl1 As TabControl
   Friend WithEvents tpgSeteaDatos As TabPage
   Friend WithEvents lblMinimoDashBoard As Controles.Label
   Friend WithEvents txtMinimoDashBoard As Controles.TextBox
   Friend WithEvents lblObjetivoDashBoard As Controles.Label
   Friend WithEvents txtObjetivoDashBoard As Controles.TextBox
   Friend WithEvents btnInsertar As Controles.Button
   Friend WithEvents btnEliminar As Controles.Button
   Friend WithEvents lblImagenDashBoard As Controles.Label
   Friend WithEvents lblTiempoDashBoard As Controles.Label
   Friend WithEvents txtTiempoDashBoard As Controles.TextBox
   Friend WithEvents chbRefrescaDatos As Controles.CheckBox
   Friend WithEvents chbEstadoDash As Controles.CheckBox
   Friend WithEvents lblOrdenDashBoard As Controles.Label
   Friend WithEvents txtOrdenDashBoard As Controles.TextBox
   Friend WithEvents lblComentarioDashBoard As Controles.Label
   Friend WithEvents lblTituloDashBoard As Controles.Label
   Friend WithEvents gpbDashBoardGrafico As GroupBox
   Friend WithEvents lblModeloDashBoard As Controles.Label
   Friend WithEvents chbTituloYDash As Controles.CheckBox
   Friend WithEvents chbTituloXDash As Controles.CheckBox
   Friend WithEvents chbShowValueLabel As Controles.CheckBox
   Friend WithEvents chbEstiloArea3D As Controles.CheckBox
   Friend WithEvents cmbModeloDashBoard As Controles.ComboBox
   Friend WithEvents txtTituloYDash As Controles.TextBox
   Friend WithEvents txtTituloXDash As Controles.TextBox
   Friend WithEvents txtComentarioDashBoard As Controles.TextBox
   Friend WithEvents txtTituloDashBoard As Controles.TextBox
   Friend WithEvents tpgSentenciaSQL As TabPage
    Friend WithEvents txtNombreDashBoard As Controles.TextBox
    Friend WithEvents lblTipoDashBoard As Controles.Label
    Friend WithEvents lblNombreDashBoard As Controles.Label
    Friend WithEvents lblIdDashBoard As Controles.Label
    Friend WithEvents pnlVisualizadorDashBoard As Panel
    Friend WithEvents cmbTipoRefreshDashBoard As Controles.ComboBox
    Friend WithEvents DialogoAbrirArchivo As OpenFileDialog
    Friend WithEvents lblSentenciaSQL As Controles.Label
    Friend WithEvents txtSentenciaSQLDashB As TextBox
   Friend WithEvents btnVisualizar As Button
    Friend WithEvents chbShowLeyendLabel As Controles.CheckBox
End Class
