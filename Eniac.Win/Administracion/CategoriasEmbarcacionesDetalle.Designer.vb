<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoriasEmbarcacionesDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CategoriasEmbarcacionesDetalle))
      Me.lblNombreCategoriaCama = New Eniac.Controles.Label()
      Me.txtNombreCategoriaEmbarcacion = New Eniac.Controles.TextBox()
      Me.lblIdCategoriaCama = New Eniac.Controles.Label()
      Me.txtIdCategoriaEmbarcacion = New Eniac.Controles.TextBox()
      Me.lblTiposEmbarcacion = New Eniac.Controles.Label()
      Me.cmbTiposEmbarcacion = New Eniac.Controles.ComboBox()
      Me.lblImporteExpensas = New Eniac.Controles.Label()
      Me.txtImporteExpensas = New Eniac.Controles.TextBox()
      Me.lblImporteAlquiler = New Eniac.Controles.Label()
      Me.txtImporteAlquiler = New Eniac.Controles.TextBox()
      Me.txtPorcDescAlquiler = New Eniac.Controles.TextBox()
      Me.lblPorcDescAlquiler = New Eniac.Controles.Label()
      Me.lblImporteGtosAdm = New Eniac.Controles.Label()
      Me.txtImporteGtosAdm = New Eniac.Controles.TextBox()
      Me.lblImporteGastosIntermAlq = New Eniac.Controles.Label()
      Me.txtImporteGastosIntermAlq = New Eniac.Controles.TextBox()
      Me.txtExpensasRelacionCategoria = New Eniac.Controles.TextBox()
      Me.lblExpensasRelacionCategoria = New Eniac.Controles.Label()
      Me.txtAlto = New Eniac.Controles.TextBox()
      Me.lblAlto = New Eniac.Controles.Label()
      Me.txtAncho = New Eniac.Controles.TextBox()
      Me.lblAncho = New Eniac.Controles.Label()
      Me.txtLargo = New Eniac.Controles.TextBox()
      Me.lblLargo = New Eniac.Controles.Label()
        Me.cmbIntereses = New Eniac.Controles.ComboBox()
        Me.chbIntereses = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(368, 240)
        Me.btnAceptar.TabIndex = 26
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(464, 240)
        Me.btnCancelar.TabIndex = 27
        '
        'lblNombreCategoriaCama
        '
        Me.lblNombreCategoriaCama.AutoSize = True
        Me.lblNombreCategoriaCama.LabelAsoc = Nothing
        Me.lblNombreCategoriaCama.Location = New System.Drawing.Point(19, 45)
        Me.lblNombreCategoriaCama.Name = "lblNombreCategoriaCama"
        Me.lblNombreCategoriaCama.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreCategoriaCama.TabIndex = 2
        Me.lblNombreCategoriaCama.Text = "Nombre"
        '
        'txtNombreCategoriaEmbarcacion
        '
        Me.txtNombreCategoriaEmbarcacion.BindearPropiedadControl = "Text"
        Me.txtNombreCategoriaEmbarcacion.BindearPropiedadEntidad = "NombreCategoriaEmbarcacion"
        Me.txtNombreCategoriaEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreCategoriaEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreCategoriaEmbarcacion.Formato = ""
        Me.txtNombreCategoriaEmbarcacion.IsDecimal = False
        Me.txtNombreCategoriaEmbarcacion.IsNumber = False
        Me.txtNombreCategoriaEmbarcacion.IsPK = False
        Me.txtNombreCategoriaEmbarcacion.IsRequired = True
        Me.txtNombreCategoriaEmbarcacion.Key = ""
        Me.txtNombreCategoriaEmbarcacion.LabelAsoc = Me.lblNombreCategoriaCama
        Me.txtNombreCategoriaEmbarcacion.Location = New System.Drawing.Point(139, 41)
        Me.txtNombreCategoriaEmbarcacion.MaxLength = 30
        Me.txtNombreCategoriaEmbarcacion.Name = "txtNombreCategoriaEmbarcacion"
        Me.txtNombreCategoriaEmbarcacion.Size = New System.Drawing.Size(331, 20)
        Me.txtNombreCategoriaEmbarcacion.TabIndex = 3
        '
        'lblIdCategoriaCama
        '
        Me.lblIdCategoriaCama.AutoSize = True
        Me.lblIdCategoriaCama.LabelAsoc = Nothing
        Me.lblIdCategoriaCama.Location = New System.Drawing.Point(19, 17)
        Me.lblIdCategoriaCama.Name = "lblIdCategoriaCama"
        Me.lblIdCategoriaCama.Size = New System.Drawing.Size(40, 13)
        Me.lblIdCategoriaCama.TabIndex = 0
        Me.lblIdCategoriaCama.Text = "Código"
        '
        'txtIdCategoriaEmbarcacion
        '
        Me.txtIdCategoriaEmbarcacion.BindearPropiedadControl = "Text"
        Me.txtIdCategoriaEmbarcacion.BindearPropiedadEntidad = "IdCategoriaEmbarcacion"
        Me.txtIdCategoriaEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdCategoriaEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdCategoriaEmbarcacion.Formato = ""
        Me.txtIdCategoriaEmbarcacion.IsDecimal = False
        Me.txtIdCategoriaEmbarcacion.IsNumber = True
        Me.txtIdCategoriaEmbarcacion.IsPK = True
        Me.txtIdCategoriaEmbarcacion.IsRequired = True
        Me.txtIdCategoriaEmbarcacion.Key = ""
        Me.txtIdCategoriaEmbarcacion.LabelAsoc = Me.lblIdCategoriaCama
        Me.txtIdCategoriaEmbarcacion.Location = New System.Drawing.Point(139, 13)
        Me.txtIdCategoriaEmbarcacion.MaxLength = 4
        Me.txtIdCategoriaEmbarcacion.Name = "txtIdCategoriaEmbarcacion"
        Me.txtIdCategoriaEmbarcacion.Size = New System.Drawing.Size(42, 20)
        Me.txtIdCategoriaEmbarcacion.TabIndex = 1
        Me.txtIdCategoriaEmbarcacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTiposEmbarcacion
        '
        Me.lblTiposEmbarcacion.AutoSize = True
        Me.lblTiposEmbarcacion.LabelAsoc = Nothing
        Me.lblTiposEmbarcacion.Location = New System.Drawing.Point(19, 72)
        Me.lblTiposEmbarcacion.Name = "lblTiposEmbarcacion"
        Me.lblTiposEmbarcacion.Size = New System.Drawing.Size(93, 13)
        Me.lblTiposEmbarcacion.TabIndex = 4
        Me.lblTiposEmbarcacion.Text = "Tipo Embarcacion"
        '
        'cmbTiposEmbarcacion
        '
        Me.cmbTiposEmbarcacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbTiposEmbarcacion.BindearPropiedadEntidad = "IdTipoEmbarcacion"
        Me.cmbTiposEmbarcacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposEmbarcacion.FormattingEnabled = True
        Me.cmbTiposEmbarcacion.IsPK = False
        Me.cmbTiposEmbarcacion.IsRequired = False
        Me.cmbTiposEmbarcacion.Key = Nothing
        Me.cmbTiposEmbarcacion.LabelAsoc = Me.lblTiposEmbarcacion
        Me.cmbTiposEmbarcacion.Location = New System.Drawing.Point(139, 69)
        Me.cmbTiposEmbarcacion.Name = "cmbTiposEmbarcacion"
        Me.cmbTiposEmbarcacion.Size = New System.Drawing.Size(139, 21)
        Me.cmbTiposEmbarcacion.TabIndex = 5
        '
        'lblImporteExpensas
        '
        Me.lblImporteExpensas.AutoSize = True
        Me.lblImporteExpensas.LabelAsoc = Nothing
        Me.lblImporteExpensas.Location = New System.Drawing.Point(19, 101)
        Me.lblImporteExpensas.Name = "lblImporteExpensas"
        Me.lblImporteExpensas.Size = New System.Drawing.Size(86, 13)
        Me.lblImporteExpensas.TabIndex = 6
        Me.lblImporteExpensas.Text = "Monto Expensas"
        '
        'txtImporteExpensas
        '
        Me.txtImporteExpensas.BindearPropiedadControl = "Text"
        Me.txtImporteExpensas.BindearPropiedadEntidad = "ImporteExpensas"
        Me.txtImporteExpensas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteExpensas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteExpensas.Formato = "N2"
        Me.txtImporteExpensas.IsDecimal = True
        Me.txtImporteExpensas.IsNumber = True
        Me.txtImporteExpensas.IsPK = False
        Me.txtImporteExpensas.IsRequired = True
        Me.txtImporteExpensas.Key = ""
        Me.txtImporteExpensas.LabelAsoc = Me.lblImporteExpensas
        Me.txtImporteExpensas.Location = New System.Drawing.Point(192, 97)
        Me.txtImporteExpensas.MaxLength = 30
        Me.txtImporteExpensas.Name = "txtImporteExpensas"
        Me.txtImporteExpensas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtImporteExpensas.Size = New System.Drawing.Size(70, 20)
        Me.txtImporteExpensas.TabIndex = 7
        '
        'lblImporteAlquiler
        '
        Me.lblImporteAlquiler.AutoSize = True
        Me.lblImporteAlquiler.LabelAsoc = Nothing
        Me.lblImporteAlquiler.Location = New System.Drawing.Point(19, 126)
        Me.lblImporteAlquiler.Name = "lblImporteAlquiler"
        Me.lblImporteAlquiler.Size = New System.Drawing.Size(74, 13)
        Me.lblImporteAlquiler.TabIndex = 10
        Me.lblImporteAlquiler.Text = "Monto Alquiler"
        '
        'txtImporteAlquiler
        '
        Me.txtImporteAlquiler.BindearPropiedadControl = "Text"
        Me.txtImporteAlquiler.BindearPropiedadEntidad = "ImporteAlquiler"
        Me.txtImporteAlquiler.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteAlquiler.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteAlquiler.Formato = "N2"
        Me.txtImporteAlquiler.IsDecimal = True
        Me.txtImporteAlquiler.IsNumber = True
        Me.txtImporteAlquiler.IsPK = False
        Me.txtImporteAlquiler.IsRequired = True
        Me.txtImporteAlquiler.Key = ""
        Me.txtImporteAlquiler.LabelAsoc = Me.lblImporteAlquiler
        Me.txtImporteAlquiler.Location = New System.Drawing.Point(192, 122)
        Me.txtImporteAlquiler.MaxLength = 30
        Me.txtImporteAlquiler.Name = "txtImporteAlquiler"
        Me.txtImporteAlquiler.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtImporteAlquiler.Size = New System.Drawing.Size(70, 20)
        Me.txtImporteAlquiler.TabIndex = 11
        '
        'txtPorcDescAlquiler
        '
        Me.txtPorcDescAlquiler.BindearPropiedadControl = "Text"
        Me.txtPorcDescAlquiler.BindearPropiedadEntidad = "PorcDescAlquiler"
        Me.txtPorcDescAlquiler.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcDescAlquiler.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcDescAlquiler.Formato = "##0.0000"
        Me.txtPorcDescAlquiler.IsDecimal = True
        Me.txtPorcDescAlquiler.IsNumber = True
        Me.txtPorcDescAlquiler.IsPK = False
        Me.txtPorcDescAlquiler.IsRequired = False
        Me.txtPorcDescAlquiler.Key = ""
        Me.txtPorcDescAlquiler.LabelAsoc = Me.lblPorcDescAlquiler
        Me.txtPorcDescAlquiler.Location = New System.Drawing.Point(487, 122)
        Me.txtPorcDescAlquiler.MaxLength = 8
        Me.txtPorcDescAlquiler.Name = "txtPorcDescAlquiler"
        Me.txtPorcDescAlquiler.Size = New System.Drawing.Size(70, 20)
        Me.txtPorcDescAlquiler.TabIndex = 13
        Me.txtPorcDescAlquiler.Text = "0.0000"
        Me.txtPorcDescAlquiler.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPorcDescAlquiler
        '
        Me.lblPorcDescAlquiler.AutoSize = True
        Me.lblPorcDescAlquiler.LabelAsoc = Nothing
        Me.lblPorcDescAlquiler.Location = New System.Drawing.Point(284, 125)
        Me.lblPorcDescAlquiler.Name = "lblPorcDescAlquiler"
        Me.lblPorcDescAlquiler.Size = New System.Drawing.Size(107, 13)
        Me.lblPorcDescAlquiler.TabIndex = 12
        Me.lblPorcDescAlquiler.Text = "% Descuento Alquiler"
        '
        'lblImporteGtosAdm
        '
        Me.lblImporteGtosAdm.AutoSize = True
        Me.lblImporteGtosAdm.LabelAsoc = Nothing
        Me.lblImporteGtosAdm.Location = New System.Drawing.Point(19, 152)
        Me.lblImporteGtosAdm.Name = "lblImporteGtosAdm"
        Me.lblImporteGtosAdm.Size = New System.Drawing.Size(162, 13)
        Me.lblImporteGtosAdm.TabIndex = 14
        Me.lblImporteGtosAdm.Text = "Monto por Gastos Administracion"
        '
        'txtImporteGtosAdm
        '
        Me.txtImporteGtosAdm.BindearPropiedadControl = "Text"
        Me.txtImporteGtosAdm.BindearPropiedadEntidad = "ImporteGastosAdmin"
        Me.txtImporteGtosAdm.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteGtosAdm.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteGtosAdm.Formato = "N2"
        Me.txtImporteGtosAdm.IsDecimal = True
        Me.txtImporteGtosAdm.IsNumber = True
        Me.txtImporteGtosAdm.IsPK = False
        Me.txtImporteGtosAdm.IsRequired = True
        Me.txtImporteGtosAdm.Key = ""
        Me.txtImporteGtosAdm.LabelAsoc = Me.lblImporteGtosAdm
        Me.txtImporteGtosAdm.Location = New System.Drawing.Point(192, 148)
        Me.txtImporteGtosAdm.MaxLength = 30
        Me.txtImporteGtosAdm.Name = "txtImporteGtosAdm"
        Me.txtImporteGtosAdm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtImporteGtosAdm.Size = New System.Drawing.Size(70, 20)
        Me.txtImporteGtosAdm.TabIndex = 15
        '
        'lblImporteGastosIntermAlq
        '
        Me.lblImporteGastosIntermAlq.AutoSize = True
        Me.lblImporteGastosIntermAlq.LabelAsoc = Nothing
        Me.lblImporteGastosIntermAlq.Location = New System.Drawing.Point(284, 152)
        Me.lblImporteGastosIntermAlq.Name = "lblImporteGastosIntermAlq"
        Me.lblImporteGastosIntermAlq.Size = New System.Drawing.Size(200, 13)
        Me.lblImporteGastosIntermAlq.TabIndex = 16
        Me.lblImporteGastosIntermAlq.Text = "Monto por Gastos Intermediacion Alquiler"
        '
        'txtImporteGastosIntermAlq
        '
        Me.txtImporteGastosIntermAlq.BindearPropiedadControl = "Text"
        Me.txtImporteGastosIntermAlq.BindearPropiedadEntidad = "ImporteGastosIntermAlq"
        Me.txtImporteGastosIntermAlq.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteGastosIntermAlq.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteGastosIntermAlq.Formato = "N2"
        Me.txtImporteGastosIntermAlq.IsDecimal = True
        Me.txtImporteGastosIntermAlq.IsNumber = True
        Me.txtImporteGastosIntermAlq.IsPK = False
        Me.txtImporteGastosIntermAlq.IsRequired = True
        Me.txtImporteGastosIntermAlq.Key = ""
        Me.txtImporteGastosIntermAlq.LabelAsoc = Me.lblImporteGastosIntermAlq
        Me.txtImporteGastosIntermAlq.Location = New System.Drawing.Point(487, 148)
        Me.txtImporteGastosIntermAlq.MaxLength = 30
        Me.txtImporteGastosIntermAlq.Name = "txtImporteGastosIntermAlq"
        Me.txtImporteGastosIntermAlq.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtImporteGastosIntermAlq.Size = New System.Drawing.Size(70, 20)
        Me.txtImporteGastosIntermAlq.TabIndex = 17
        '
        'txtExpensasRelacionCategoria
        '
        Me.txtExpensasRelacionCategoria.BindearPropiedadControl = "Text"
        Me.txtExpensasRelacionCategoria.BindearPropiedadEntidad = "ExpensasRelacionCategoria"
        Me.txtExpensasRelacionCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtExpensasRelacionCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtExpensasRelacionCategoria.Formato = "N4"
        Me.txtExpensasRelacionCategoria.IsDecimal = True
        Me.txtExpensasRelacionCategoria.IsNumber = True
        Me.txtExpensasRelacionCategoria.IsPK = False
        Me.txtExpensasRelacionCategoria.IsRequired = True
        Me.txtExpensasRelacionCategoria.Key = ""
        Me.txtExpensasRelacionCategoria.LabelAsoc = Me.lblExpensasRelacionCategoria
        Me.txtExpensasRelacionCategoria.Location = New System.Drawing.Point(487, 97)
        Me.txtExpensasRelacionCategoria.MaxLength = 30
        Me.txtExpensasRelacionCategoria.Name = "txtExpensasRelacionCategoria"
        Me.txtExpensasRelacionCategoria.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtExpensasRelacionCategoria.Size = New System.Drawing.Size(70, 20)
        Me.txtExpensasRelacionCategoria.TabIndex = 9
        Me.txtExpensasRelacionCategoria.Text = "0.0000"
        '
        'lblExpensasRelacionCategoria
        '
        Me.lblExpensasRelacionCategoria.AutoSize = True
        Me.lblExpensasRelacionCategoria.LabelAsoc = Nothing
        Me.lblExpensasRelacionCategoria.Location = New System.Drawing.Point(284, 101)
        Me.lblExpensasRelacionCategoria.Name = "lblExpensasRelacionCategoria"
        Me.lblExpensasRelacionCategoria.Size = New System.Drawing.Size(196, 13)
        Me.lblExpensasRelacionCategoria.TabIndex = 8
        Me.lblExpensasRelacionCategoria.Text = "Relación de la Categoria para Expensas"
        '
        'txtAlto
        '
        Me.txtAlto.BindearPropiedadControl = "Text"
        Me.txtAlto.BindearPropiedadEntidad = "Alto"
        Me.txtAlto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAlto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAlto.Formato = "N2"
        Me.txtAlto.IsDecimal = True
        Me.txtAlto.IsNumber = True
        Me.txtAlto.IsPK = False
        Me.txtAlto.IsRequired = True
        Me.txtAlto.Key = ""
        Me.txtAlto.LabelAsoc = Me.lblAlto
        Me.txtAlto.Location = New System.Drawing.Point(280, 205)
        Me.txtAlto.MaxLength = 30
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAlto.Size = New System.Drawing.Size(70, 20)
        Me.txtAlto.TabIndex = 23
        '
        'lblAlto
        '
        Me.lblAlto.AutoSize = True
        Me.lblAlto.LabelAsoc = Nothing
        Me.lblAlto.Location = New System.Drawing.Point(237, 208)
        Me.lblAlto.Name = "lblAlto"
        Me.lblAlto.Size = New System.Drawing.Size(25, 13)
        Me.lblAlto.TabIndex = 22
        Me.lblAlto.Text = "Alto"
        '
        'txtAncho
        '
        Me.txtAncho.BindearPropiedadControl = "Text"
        Me.txtAncho.BindearPropiedadEntidad = "Ancho"
        Me.txtAncho.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAncho.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAncho.Formato = "N2"
        Me.txtAncho.IsDecimal = True
        Me.txtAncho.IsNumber = True
        Me.txtAncho.IsPK = False
        Me.txtAncho.IsRequired = True
        Me.txtAncho.Key = ""
        Me.txtAncho.LabelAsoc = Me.lblAncho
        Me.txtAncho.Location = New System.Drawing.Point(416, 205)
        Me.txtAncho.MaxLength = 30
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAncho.Size = New System.Drawing.Size(70, 20)
        Me.txtAncho.TabIndex = 25
        '
        'lblAncho
        '
        Me.lblAncho.AutoSize = True
        Me.lblAncho.LabelAsoc = Nothing
        Me.lblAncho.Location = New System.Drawing.Point(372, 208)
        Me.lblAncho.Name = "lblAncho"
        Me.lblAncho.Size = New System.Drawing.Size(38, 13)
        Me.lblAncho.TabIndex = 24
        Me.lblAncho.Text = "Ancho"
        '
        'txtLargo
        '
        Me.txtLargo.BindearPropiedadControl = "Text"
        Me.txtLargo.BindearPropiedadEntidad = "Largo"
        Me.txtLargo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLargo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLargo.Formato = "N2"
        Me.txtLargo.IsDecimal = True
        Me.txtLargo.IsNumber = True
        Me.txtLargo.IsPK = False
        Me.txtLargo.IsRequired = True
        Me.txtLargo.Key = ""
        Me.txtLargo.LabelAsoc = Me.lblLargo
        Me.txtLargo.Location = New System.Drawing.Point(150, 205)
        Me.txtLargo.MaxLength = 30
        Me.txtLargo.Name = "txtLargo"
        Me.txtLargo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLargo.Size = New System.Drawing.Size(70, 20)
        Me.txtLargo.TabIndex = 21
        '
        'lblLargo
        '
        Me.lblLargo.AutoSize = True
        Me.lblLargo.LabelAsoc = Nothing
        Me.lblLargo.Location = New System.Drawing.Point(113, 208)
        Me.lblLargo.Name = "lblLargo"
        Me.lblLargo.Size = New System.Drawing.Size(34, 13)
        Me.lblLargo.TabIndex = 20
        Me.lblLargo.Text = "Largo"
        '
        'cmbIntereses
        '
        Me.cmbIntereses.BindearPropiedadControl = "SelectedValue"
        Me.cmbIntereses.BindearPropiedadEntidad = "Interes.IdInteres"
        Me.cmbIntereses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIntereses.Enabled = False
        Me.cmbIntereses.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIntereses.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIntereses.FormattingEnabled = True
        Me.cmbIntereses.IsPK = False
        Me.cmbIntereses.IsRequired = False
        Me.cmbIntereses.Key = Nothing
        Me.cmbIntereses.LabelAsoc = Nothing
        Me.cmbIntereses.Location = New System.Drawing.Point(97, 178)
        Me.cmbIntereses.Name = "cmbIntereses"
        Me.cmbIntereses.Size = New System.Drawing.Size(181, 21)
        Me.cmbIntereses.TabIndex = 19
        Me.cmbIntereses.Visible = False
        '
        'chbIntereses
        '
        Me.chbIntereses.AutoSize = True
        Me.chbIntereses.BindearPropiedadControl = Nothing
        Me.chbIntereses.BindearPropiedadEntidad = Nothing
        Me.chbIntereses.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIntereses.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIntereses.IsPK = False
        Me.chbIntereses.IsRequired = False
        Me.chbIntereses.Key = Nothing
        Me.chbIntereses.LabelAsoc = Nothing
        Me.chbIntereses.Location = New System.Drawing.Point(22, 180)
        Me.chbIntereses.Name = "chbIntereses"
        Me.chbIntereses.Size = New System.Drawing.Size(69, 17)
        Me.chbIntereses.TabIndex = 18
        Me.chbIntereses.Text = "Intereses"
        Me.chbIntereses.UseVisualStyleBackColor = True
        Me.chbIntereses.Visible = False
        '
        'CategoriasEmbarcacionesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(567, 287)
        Me.Controls.Add(Me.cmbIntereses)
        Me.Controls.Add(Me.chbIntereses)
        Me.Controls.Add(Me.lblExpensasRelacionCategoria)
        Me.Controls.Add(Me.lblImporteGastosIntermAlq)
        Me.Controls.Add(Me.txtExpensasRelacionCategoria)
        Me.Controls.Add(Me.txtImporteGastosIntermAlq)
        Me.Controls.Add(Me.lblImporteGtosAdm)
        Me.Controls.Add(Me.txtImporteGtosAdm)
        Me.Controls.Add(Me.txtPorcDescAlquiler)
        Me.Controls.Add(Me.lblPorcDescAlquiler)
        Me.Controls.Add(Me.lblLargo)
        Me.Controls.Add(Me.lblAncho)
        Me.Controls.Add(Me.lblAlto)
        Me.Controls.Add(Me.lblImporteExpensas)
        Me.Controls.Add(Me.txtLargo)
        Me.Controls.Add(Me.txtAncho)
        Me.Controls.Add(Me.txtAlto)
        Me.Controls.Add(Me.txtImporteExpensas)
        Me.Controls.Add(Me.lblImporteAlquiler)
        Me.Controls.Add(Me.txtImporteAlquiler)
        Me.Controls.Add(Me.cmbTiposEmbarcacion)
        Me.Controls.Add(Me.lblTiposEmbarcacion)
        Me.Controls.Add(Me.lblNombreCategoriaCama)
        Me.Controls.Add(Me.txtNombreCategoriaEmbarcacion)
        Me.Controls.Add(Me.lblIdCategoriaCama)
        Me.Controls.Add(Me.txtIdCategoriaEmbarcacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CategoriasEmbarcacionesDetalle"
        Me.Text = "Categoria de Embarcación"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtIdCategoriaEmbarcacion, 0)
        Me.Controls.SetChildIndex(Me.lblIdCategoriaCama, 0)
        Me.Controls.SetChildIndex(Me.txtNombreCategoriaEmbarcacion, 0)
        Me.Controls.SetChildIndex(Me.lblNombreCategoriaCama, 0)
        Me.Controls.SetChildIndex(Me.lblTiposEmbarcacion, 0)
        Me.Controls.SetChildIndex(Me.cmbTiposEmbarcacion, 0)
        Me.Controls.SetChildIndex(Me.txtImporteAlquiler, 0)
        Me.Controls.SetChildIndex(Me.lblImporteAlquiler, 0)
        Me.Controls.SetChildIndex(Me.txtImporteExpensas, 0)
        Me.Controls.SetChildIndex(Me.txtAlto, 0)
        Me.Controls.SetChildIndex(Me.txtAncho, 0)
        Me.Controls.SetChildIndex(Me.txtLargo, 0)
        Me.Controls.SetChildIndex(Me.lblImporteExpensas, 0)
        Me.Controls.SetChildIndex(Me.lblAlto, 0)
        Me.Controls.SetChildIndex(Me.lblAncho, 0)
        Me.Controls.SetChildIndex(Me.lblLargo, 0)
        Me.Controls.SetChildIndex(Me.lblPorcDescAlquiler, 0)
        Me.Controls.SetChildIndex(Me.txtPorcDescAlquiler, 0)
        Me.Controls.SetChildIndex(Me.txtImporteGtosAdm, 0)
        Me.Controls.SetChildIndex(Me.lblImporteGtosAdm, 0)
        Me.Controls.SetChildIndex(Me.txtImporteGastosIntermAlq, 0)
        Me.Controls.SetChildIndex(Me.txtExpensasRelacionCategoria, 0)
        Me.Controls.SetChildIndex(Me.lblImporteGastosIntermAlq, 0)
        Me.Controls.SetChildIndex(Me.lblExpensasRelacionCategoria, 0)
        Me.Controls.SetChildIndex(Me.chbIntereses, 0)
        Me.Controls.SetChildIndex(Me.cmbIntereses, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombreCategoriaCama As Eniac.Controles.Label
   Friend WithEvents txtNombreCategoriaEmbarcacion As Eniac.Controles.TextBox
   Friend WithEvents lblIdCategoriaCama As Eniac.Controles.Label
   Friend WithEvents txtIdCategoriaEmbarcacion As Eniac.Controles.TextBox
   Friend WithEvents lblTiposEmbarcacion As Eniac.Controles.Label
   Friend WithEvents cmbTiposEmbarcacion As Eniac.Controles.ComboBox
   Friend WithEvents lblImporteExpensas As Eniac.Controles.Label
   Friend WithEvents txtImporteExpensas As Eniac.Controles.TextBox
   Friend WithEvents lblImporteAlquiler As Eniac.Controles.Label
   Friend WithEvents txtImporteAlquiler As Eniac.Controles.TextBox
   Friend WithEvents txtPorcDescAlquiler As Eniac.Controles.TextBox
   Friend WithEvents lblPorcDescAlquiler As Eniac.Controles.Label
   Friend WithEvents lblImporteGtosAdm As Eniac.Controles.Label
   Friend WithEvents txtImporteGtosAdm As Eniac.Controles.TextBox
   Friend WithEvents lblImporteGastosIntermAlq As Eniac.Controles.Label
   Friend WithEvents txtImporteGastosIntermAlq As Eniac.Controles.TextBox
   Friend WithEvents txtExpensasRelacionCategoria As Eniac.Controles.TextBox
   Friend WithEvents lblExpensasRelacionCategoria As Eniac.Controles.Label
   Friend WithEvents txtAlto As Eniac.Controles.TextBox
   Friend WithEvents lblAlto As Eniac.Controles.Label
   Friend WithEvents txtAncho As Eniac.Controles.TextBox
   Friend WithEvents lblAncho As Eniac.Controles.Label
   Friend WithEvents txtLargo As Eniac.Controles.TextBox
   Friend WithEvents lblLargo As Eniac.Controles.Label
    Friend WithEvents cmbIntereses As Controles.ComboBox
    Friend WithEvents chbIntereses As Controles.CheckBox
End Class
