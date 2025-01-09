<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoriasCamasDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CategoriasCamasDetalle))
      Me.lblNombreCategoriaCama = New Eniac.Controles.Label()
      Me.txtNombreCategoriaCama = New Eniac.Controles.TextBox()
      Me.lblIdCategoriaCama = New Eniac.Controles.Label()
      Me.txtIdCategoriaCama = New Eniac.Controles.TextBox()
      Me.lblCantidadAccionesRequeridas = New Eniac.Controles.Label()
      Me.txtCantidadAccionesRequeridas = New Eniac.Controles.TextBox()
      Me.lblAlto = New Eniac.Controles.Label()
      Me.lblLargo = New Eniac.Controles.Label()
      Me.lblAncho = New Eniac.Controles.Label()
      Me.txtAlto = New Eniac.Controles.TextBox()
      Me.txtLargo = New Eniac.Controles.TextBox()
      Me.txtAncho = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.TextBox1 = New Eniac.Controles.TextBox()
      Me.lblImporteGastosIntermAlq = New Eniac.Controles.Label()
      Me.txtImporteGastosIntermAlq = New Eniac.Controles.TextBox()
      Me.lblImporteGtosAdm = New Eniac.Controles.Label()
      Me.txtImporteGtosAdm = New Eniac.Controles.TextBox()
      Me.txtPorcDescAlquiler = New Eniac.Controles.TextBox()
      Me.lblPorcDescAlquiler = New Eniac.Controles.Label()
      Me.lblImporteExpensas = New Eniac.Controles.Label()
      Me.txtImporteExpensas = New Eniac.Controles.TextBox()
      Me.lblImporteAlquiler = New Eniac.Controles.Label()
      Me.txtImporteAlquiler = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(159, 301)
      Me.btnAceptar.TabIndex = 14
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(255, 301)
      Me.btnCancelar.TabIndex = 15
      '
      'lblNombreCategoriaCama
      '
      Me.lblNombreCategoriaCama.AutoSize = True
      Me.lblNombreCategoriaCama.Location = New System.Drawing.Point(19, 45)
      Me.lblNombreCategoriaCama.Name = "lblNombreCategoriaCama"
      Me.lblNombreCategoriaCama.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreCategoriaCama.TabIndex = 2
      Me.lblNombreCategoriaCama.Text = "Nombre"
      '
      'txtNombreCategoriaCama
      '
      Me.txtNombreCategoriaCama.BindearPropiedadControl = "Text"
      Me.txtNombreCategoriaCama.BindearPropiedadEntidad = "NombreCategoriaCama"
      Me.txtNombreCategoriaCama.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreCategoriaCama.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreCategoriaCama.Formato = ""
      Me.txtNombreCategoriaCama.IsDecimal = False
      Me.txtNombreCategoriaCama.IsNumber = False
      Me.txtNombreCategoriaCama.IsPK = False
      Me.txtNombreCategoriaCama.IsRequired = True
      Me.txtNombreCategoriaCama.Key = ""
      Me.txtNombreCategoriaCama.LabelAsoc = Me.lblNombreCategoriaCama
      Me.txtNombreCategoriaCama.Location = New System.Drawing.Point(104, 41)
      Me.txtNombreCategoriaCama.MaxLength = 30
      Me.txtNombreCategoriaCama.Name = "txtNombreCategoriaCama"
      Me.txtNombreCategoriaCama.Size = New System.Drawing.Size(231, 20)
      Me.txtNombreCategoriaCama.TabIndex = 3
      '
      'lblIdCategoriaCama
      '
      Me.lblIdCategoriaCama.AutoSize = True
      Me.lblIdCategoriaCama.Location = New System.Drawing.Point(19, 17)
      Me.lblIdCategoriaCama.Name = "lblIdCategoriaCama"
      Me.lblIdCategoriaCama.Size = New System.Drawing.Size(40, 13)
      Me.lblIdCategoriaCama.TabIndex = 0
      Me.lblIdCategoriaCama.Text = "Código"
      '
      'txtIdCategoriaCama
      '
      Me.txtIdCategoriaCama.BindearPropiedadControl = "Text"
      Me.txtIdCategoriaCama.BindearPropiedadEntidad = "IdCategoriaCama"
      Me.txtIdCategoriaCama.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdCategoriaCama.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdCategoriaCama.Formato = ""
      Me.txtIdCategoriaCama.IsDecimal = False
      Me.txtIdCategoriaCama.IsNumber = True
      Me.txtIdCategoriaCama.IsPK = True
      Me.txtIdCategoriaCama.IsRequired = True
      Me.txtIdCategoriaCama.Key = ""
      Me.txtIdCategoriaCama.LabelAsoc = Me.lblIdCategoriaCama
      Me.txtIdCategoriaCama.Location = New System.Drawing.Point(104, 13)
      Me.txtIdCategoriaCama.MaxLength = 4
      Me.txtIdCategoriaCama.Name = "txtIdCategoriaCama"
      Me.txtIdCategoriaCama.Size = New System.Drawing.Size(42, 20)
      Me.txtIdCategoriaCama.TabIndex = 1
      Me.txtIdCategoriaCama.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCantidadAccionesRequeridas
      '
      Me.lblCantidadAccionesRequeridas.AutoSize = True
      Me.lblCantidadAccionesRequeridas.Location = New System.Drawing.Point(170, 123)
      Me.lblCantidadAccionesRequeridas.Name = "lblCantidadAccionesRequeridas"
      Me.lblCantidadAccionesRequeridas.Size = New System.Drawing.Size(108, 13)
      Me.lblCantidadAccionesRequeridas.TabIndex = 12
      Me.lblCantidadAccionesRequeridas.Text = "Acciones Requeridas"
      '
      'txtCantidadAccionesRequeridas
      '
      Me.txtCantidadAccionesRequeridas.BindearPropiedadControl = "Text"
      Me.txtCantidadAccionesRequeridas.BindearPropiedadEntidad = "CantidadAccionesRequeridas"
      Me.txtCantidadAccionesRequeridas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadAccionesRequeridas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadAccionesRequeridas.Formato = ""
      Me.txtCantidadAccionesRequeridas.IsDecimal = False
      Me.txtCantidadAccionesRequeridas.IsNumber = True
      Me.txtCantidadAccionesRequeridas.IsPK = False
      Me.txtCantidadAccionesRequeridas.IsRequired = False
      Me.txtCantidadAccionesRequeridas.Key = ""
      Me.txtCantidadAccionesRequeridas.LabelAsoc = Me.lblCantidadAccionesRequeridas
      Me.txtCantidadAccionesRequeridas.Location = New System.Drawing.Point(283, 120)
      Me.txtCantidadAccionesRequeridas.MaxLength = 30
      Me.txtCantidadAccionesRequeridas.Name = "txtCantidadAccionesRequeridas"
      Me.txtCantidadAccionesRequeridas.Size = New System.Drawing.Size(52, 20)
      Me.txtCantidadAccionesRequeridas.TabIndex = 13
      Me.txtCantidadAccionesRequeridas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAlto
      '
      Me.lblAlto.AutoSize = True
      Me.lblAlto.Location = New System.Drawing.Point(19, 71)
      Me.lblAlto.Name = "lblAlto"
      Me.lblAlto.Size = New System.Drawing.Size(50, 13)
      Me.lblAlto.TabIndex = 4
      Me.lblAlto.Text = "Alto (mts)"
      '
      'lblLargo
      '
      Me.lblLargo.AutoSize = True
      Me.lblLargo.Location = New System.Drawing.Point(19, 97)
      Me.lblLargo.Name = "lblLargo"
      Me.lblLargo.Size = New System.Drawing.Size(59, 13)
      Me.lblLargo.TabIndex = 8
      Me.lblLargo.Text = "Largo (mts)"
      '
      'lblAncho
      '
      Me.lblAncho.AutoSize = True
      Me.lblAncho.Location = New System.Drawing.Point(212, 72)
      Me.lblAncho.Name = "lblAncho"
      Me.lblAncho.Size = New System.Drawing.Size(63, 13)
      Me.lblAncho.TabIndex = 6
      Me.lblAncho.Text = "Ancho (mts)"
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
      Me.txtAlto.IsRequired = False
      Me.txtAlto.Key = ""
      Me.txtAlto.LabelAsoc = Me.lblAlto
      Me.txtAlto.Location = New System.Drawing.Point(104, 67)
      Me.txtAlto.MaxLength = 30
      Me.txtAlto.Name = "txtAlto"
      Me.txtAlto.Size = New System.Drawing.Size(52, 20)
      Me.txtAlto.TabIndex = 5
      Me.txtAlto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.txtLargo.IsRequired = False
      Me.txtLargo.Key = ""
      Me.txtLargo.LabelAsoc = Me.lblLargo
      Me.txtLargo.Location = New System.Drawing.Point(104, 94)
      Me.txtLargo.MaxLength = 30
      Me.txtLargo.Name = "txtLargo"
      Me.txtLargo.Size = New System.Drawing.Size(52, 20)
      Me.txtLargo.TabIndex = 9
      Me.txtLargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.txtAncho.IsRequired = False
      Me.txtAncho.Key = ""
      Me.txtAncho.LabelAsoc = Me.lblAncho
      Me.txtAncho.Location = New System.Drawing.Point(283, 68)
      Me.txtAncho.MaxLength = 30
      Me.txtAncho.Name = "txtAncho"
      Me.txtAncho.Size = New System.Drawing.Size(52, 20)
      Me.txtAncho.TabIndex = 7
      Me.txtAncho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(19, 126)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(79, 13)
      Me.Label1.TabIndex = 10
      Me.Label1.Text = "Tasa Municipal"
      '
      'TextBox1
      '
      Me.TextBox1.BindearPropiedadControl = "Text"
      Me.TextBox1.BindearPropiedadEntidad = "TasaMunicipal"
      Me.TextBox1.ForeColorFocus = System.Drawing.Color.Red
      Me.TextBox1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.TextBox1.Formato = "N2"
      Me.TextBox1.IsDecimal = True
      Me.TextBox1.IsNumber = True
      Me.TextBox1.IsPK = False
      Me.TextBox1.IsRequired = False
      Me.TextBox1.Key = ""
      Me.TextBox1.LabelAsoc = Me.Label1
      Me.TextBox1.Location = New System.Drawing.Point(104, 122)
      Me.TextBox1.MaxLength = 30
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(52, 20)
      Me.TextBox1.TabIndex = 11
      Me.TextBox1.Text = "0.00"
      Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblImporteGastosIntermAlq
      '
      Me.lblImporteGastosIntermAlq.AutoSize = True
      Me.lblImporteGastosIntermAlq.Location = New System.Drawing.Point(19, 264)
      Me.lblImporteGastosIntermAlq.Name = "lblImporteGastosIntermAlq"
      Me.lblImporteGastosIntermAlq.Size = New System.Drawing.Size(200, 13)
      Me.lblImporteGastosIntermAlq.TabIndex = 25
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
      Me.txtImporteGastosIntermAlq.Location = New System.Drawing.Point(265, 261)
      Me.txtImporteGastosIntermAlq.MaxLength = 30
      Me.txtImporteGastosIntermAlq.Name = "txtImporteGastosIntermAlq"
      Me.txtImporteGastosIntermAlq.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.txtImporteGastosIntermAlq.Size = New System.Drawing.Size(70, 20)
      Me.txtImporteGastosIntermAlq.TabIndex = 24
      '
      'lblImporteGtosAdm
      '
      Me.lblImporteGtosAdm.AutoSize = True
      Me.lblImporteGtosAdm.Location = New System.Drawing.Point(19, 237)
      Me.lblImporteGtosAdm.Name = "lblImporteGtosAdm"
      Me.lblImporteGtosAdm.Size = New System.Drawing.Size(162, 13)
      Me.lblImporteGtosAdm.TabIndex = 23
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
      Me.txtImporteGtosAdm.Location = New System.Drawing.Point(265, 234)
      Me.txtImporteGtosAdm.MaxLength = 30
      Me.txtImporteGtosAdm.Name = "txtImporteGtosAdm"
      Me.txtImporteGtosAdm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.txtImporteGtosAdm.Size = New System.Drawing.Size(70, 20)
      Me.txtImporteGtosAdm.TabIndex = 22
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
      Me.txtPorcDescAlquiler.Location = New System.Drawing.Point(265, 208)
      Me.txtPorcDescAlquiler.MaxLength = 8
      Me.txtPorcDescAlquiler.Name = "txtPorcDescAlquiler"
      Me.txtPorcDescAlquiler.Size = New System.Drawing.Size(70, 20)
      Me.txtPorcDescAlquiler.TabIndex = 20
      Me.txtPorcDescAlquiler.Text = "0.0000"
      Me.txtPorcDescAlquiler.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPorcDescAlquiler
      '
      Me.lblPorcDescAlquiler.AutoSize = True
      Me.lblPorcDescAlquiler.Location = New System.Drawing.Point(19, 210)
      Me.lblPorcDescAlquiler.Name = "lblPorcDescAlquiler"
      Me.lblPorcDescAlquiler.Size = New System.Drawing.Size(107, 13)
      Me.lblPorcDescAlquiler.TabIndex = 21
      Me.lblPorcDescAlquiler.Text = "% Descuento Alquiler"
      '
      'lblImporteExpensas
      '
      Me.lblImporteExpensas.AutoSize = True
      Me.lblImporteExpensas.Location = New System.Drawing.Point(19, 160)
      Me.lblImporteExpensas.Name = "lblImporteExpensas"
      Me.lblImporteExpensas.Size = New System.Drawing.Size(86, 13)
      Me.lblImporteExpensas.TabIndex = 17
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
      Me.txtImporteExpensas.Location = New System.Drawing.Point(265, 157)
      Me.txtImporteExpensas.MaxLength = 30
      Me.txtImporteExpensas.Name = "txtImporteExpensas"
      Me.txtImporteExpensas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.txtImporteExpensas.Size = New System.Drawing.Size(70, 20)
      Me.txtImporteExpensas.TabIndex = 16
      '
      'lblImporteAlquiler
      '
      Me.lblImporteAlquiler.AutoSize = True
      Me.lblImporteAlquiler.Location = New System.Drawing.Point(19, 185)
      Me.lblImporteAlquiler.Name = "lblImporteAlquiler"
      Me.lblImporteAlquiler.Size = New System.Drawing.Size(74, 13)
      Me.lblImporteAlquiler.TabIndex = 19
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
      Me.txtImporteAlquiler.Location = New System.Drawing.Point(265, 182)
      Me.txtImporteAlquiler.MaxLength = 30
      Me.txtImporteAlquiler.Name = "txtImporteAlquiler"
      Me.txtImporteAlquiler.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.txtImporteAlquiler.Size = New System.Drawing.Size(70, 20)
      Me.txtImporteAlquiler.TabIndex = 18
      '
      'CategoriasCamasDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(360, 348)
      Me.Controls.Add(Me.lblImporteGastosIntermAlq)
      Me.Controls.Add(Me.txtImporteGastosIntermAlq)
      Me.Controls.Add(Me.lblImporteGtosAdm)
      Me.Controls.Add(Me.txtImporteGtosAdm)
      Me.Controls.Add(Me.txtPorcDescAlquiler)
      Me.Controls.Add(Me.lblPorcDescAlquiler)
      Me.Controls.Add(Me.lblImporteExpensas)
      Me.Controls.Add(Me.txtImporteExpensas)
      Me.Controls.Add(Me.lblImporteAlquiler)
      Me.Controls.Add(Me.txtImporteAlquiler)
      Me.Controls.Add(Me.TextBox1)
      Me.Controls.Add(Me.txtAncho)
      Me.Controls.Add(Me.txtLargo)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtAlto)
      Me.Controls.Add(Me.lblAncho)
      Me.Controls.Add(Me.lblLargo)
      Me.Controls.Add(Me.lblAlto)
      Me.Controls.Add(Me.lblCantidadAccionesRequeridas)
      Me.Controls.Add(Me.txtCantidadAccionesRequeridas)
      Me.Controls.Add(Me.lblNombreCategoriaCama)
      Me.Controls.Add(Me.txtNombreCategoriaCama)
      Me.Controls.Add(Me.lblIdCategoriaCama)
      Me.Controls.Add(Me.txtIdCategoriaCama)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "CategoriasCamasDetalle"
      Me.Text = "Categoria de Cama"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdCategoriaCama, 0)
      Me.Controls.SetChildIndex(Me.lblIdCategoriaCama, 0)
      Me.Controls.SetChildIndex(Me.txtNombreCategoriaCama, 0)
      Me.Controls.SetChildIndex(Me.lblNombreCategoriaCama, 0)
      Me.Controls.SetChildIndex(Me.txtCantidadAccionesRequeridas, 0)
      Me.Controls.SetChildIndex(Me.lblCantidadAccionesRequeridas, 0)
      Me.Controls.SetChildIndex(Me.lblAlto, 0)
      Me.Controls.SetChildIndex(Me.lblLargo, 0)
      Me.Controls.SetChildIndex(Me.lblAncho, 0)
      Me.Controls.SetChildIndex(Me.txtAlto, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtLargo, 0)
      Me.Controls.SetChildIndex(Me.txtAncho, 0)
      Me.Controls.SetChildIndex(Me.TextBox1, 0)
      Me.Controls.SetChildIndex(Me.txtImporteAlquiler, 0)
      Me.Controls.SetChildIndex(Me.lblImporteAlquiler, 0)
      Me.Controls.SetChildIndex(Me.txtImporteExpensas, 0)
      Me.Controls.SetChildIndex(Me.lblImporteExpensas, 0)
      Me.Controls.SetChildIndex(Me.lblPorcDescAlquiler, 0)
      Me.Controls.SetChildIndex(Me.txtPorcDescAlquiler, 0)
      Me.Controls.SetChildIndex(Me.txtImporteGtosAdm, 0)
      Me.Controls.SetChildIndex(Me.lblImporteGtosAdm, 0)
      Me.Controls.SetChildIndex(Me.txtImporteGastosIntermAlq, 0)
      Me.Controls.SetChildIndex(Me.lblImporteGastosIntermAlq, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Friend WithEvents lblNombreCategoriaCama As Eniac.Controles.Label
    Friend WithEvents txtNombreCategoriaCama As Eniac.Controles.TextBox
    Friend WithEvents lblIdCategoriaCama As Eniac.Controles.Label
    Friend WithEvents txtIdCategoriaCama As Eniac.Controles.TextBox
    Friend WithEvents lblCantidadAccionesRequeridas As Eniac.Controles.Label
    Friend WithEvents txtCantidadAccionesRequeridas As Eniac.Controles.TextBox
    Friend WithEvents lblAlto As Eniac.Controles.Label
    Friend WithEvents lblLargo As Eniac.Controles.Label
    Friend WithEvents lblAncho As Eniac.Controles.Label
    Friend WithEvents txtAlto As Eniac.Controles.TextBox
    Friend WithEvents txtLargo As Eniac.Controles.TextBox
    Friend WithEvents txtAncho As Eniac.Controles.TextBox
    Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents TextBox1 As Eniac.Controles.TextBox
   Friend WithEvents lblImporteGastosIntermAlq As Eniac.Controles.Label
   Friend WithEvents txtImporteGastosIntermAlq As Eniac.Controles.TextBox
   Friend WithEvents lblImporteGtosAdm As Eniac.Controles.Label
   Friend WithEvents txtImporteGtosAdm As Eniac.Controles.TextBox
   Friend WithEvents txtPorcDescAlquiler As Eniac.Controles.TextBox
   Friend WithEvents lblPorcDescAlquiler As Eniac.Controles.Label
   Friend WithEvents lblImporteExpensas As Eniac.Controles.Label
   Friend WithEvents txtImporteExpensas As Eniac.Controles.TextBox
   Friend WithEvents lblImporteAlquiler As Eniac.Controles.Label
   Friend WithEvents txtImporteAlquiler As Eniac.Controles.TextBox

End Class
