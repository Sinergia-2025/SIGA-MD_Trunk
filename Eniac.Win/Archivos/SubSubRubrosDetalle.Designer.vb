<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubSubRubrosDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SubSubRubrosDetalle))
      Me.tcSubSubRubro = New System.Windows.Forms.TabControl()
      Me.tpTiendaWeb = New System.Windows.Forms.TabPage()
        Me.txtIdSubSubRubroML = New Eniac.Controles.TextBox()
        Me.lblIdSubSubRubroML = New Eniac.Controles.Label()
        Me.txtIdSubSubRubroTiendaNube = New Eniac.Controles.TextBox()
        Me.lblIdSubSubRubroTiendaNube = New Eniac.Controles.Label()
        Me.lblRubro = New Eniac.Controles.Label()
        Me.bscCodigoRubro = New Eniac.Controles.Buscador()
        Me.bscNombreRubro = New Eniac.Controles.Buscador()
        Me.lblSubRubro = New Eniac.Controles.Label()
        Me.bscCodigoSubRubro = New Eniac.Controles.Buscador()
        Me.bscSubRubro = New Eniac.Controles.Buscador()
        Me.lblNombreSubSubRubro = New Eniac.Controles.Label()
        Me.txtNombreSubSubRubro = New Eniac.Controles.TextBox()
        Me.lblIdSubRubro = New Eniac.Controles.Label()
        Me.txtIdSubSubRubro = New Eniac.Controles.TextBox()
        Me.txtIdSubSubRubroArborea = New Eniac.Controles.TextBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.tcSubSubRubro.SuspendLayout()
        Me.tpTiendaWeb.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(408, 238)
        Me.btnAceptar.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(494, 238)
        Me.btnCancelar.TabIndex = 5
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(143, 293)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(86, 319)
        '
        'tcSubSubRubro
        '
        Me.tcSubSubRubro.Controls.Add(Me.tpTiendaWeb)
        Me.tcSubSubRubro.Location = New System.Drawing.Point(12, 116)
        Me.tcSubSubRubro.Name = "tcSubSubRubro"
        Me.tcSubSubRubro.SelectedIndex = 0
        Me.tcSubSubRubro.Size = New System.Drawing.Size(562, 116)
        Me.tcSubSubRubro.TabIndex = 12
        '
        'tpTiendaWeb
        '
        Me.tpTiendaWeb.BackColor = System.Drawing.SystemColors.Control
        Me.tpTiendaWeb.Controls.Add(Me.txtIdSubSubRubroArborea)
        Me.tpTiendaWeb.Controls.Add(Me.Label1)
        Me.tpTiendaWeb.Controls.Add(Me.txtIdSubSubRubroML)
        Me.tpTiendaWeb.Controls.Add(Me.lblIdSubSubRubroML)
        Me.tpTiendaWeb.Controls.Add(Me.txtIdSubSubRubroTiendaNube)
        Me.tpTiendaWeb.Controls.Add(Me.lblIdSubSubRubroTiendaNube)
        Me.tpTiendaWeb.Location = New System.Drawing.Point(4, 22)
        Me.tpTiendaWeb.Name = "tpTiendaWeb"
        Me.tpTiendaWeb.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTiendaWeb.Size = New System.Drawing.Size(554, 90)
        Me.tpTiendaWeb.TabIndex = 0
        Me.tpTiendaWeb.Text = "Tienda Web"
        '
        'txtIdSubSubRubroML
        '
        Me.txtIdSubSubRubroML.BindearPropiedadControl = "Text"
        Me.txtIdSubSubRubroML.BindearPropiedadEntidad = "IdSubSubRubroMercadoLibre"
        Me.txtIdSubSubRubroML.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSubSubRubroML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSubSubRubroML.Formato = "N2"
        Me.txtIdSubSubRubroML.IsDecimal = False
        Me.txtIdSubSubRubroML.IsNumber = False
        Me.txtIdSubSubRubroML.IsPK = False
        Me.txtIdSubSubRubroML.IsRequired = False
        Me.txtIdSubSubRubroML.Key = ""
        Me.txtIdSubSubRubroML.LabelAsoc = Me.lblIdSubSubRubroML
        Me.txtIdSubSubRubroML.Location = New System.Drawing.Point(176, 32)
        Me.txtIdSubSubRubroML.MaxLength = 30
        Me.txtIdSubSubRubroML.Name = "txtIdSubSubRubroML"
        Me.txtIdSubSubRubroML.Size = New System.Drawing.Size(98, 20)
        Me.txtIdSubSubRubroML.TabIndex = 13
        Me.txtIdSubSubRubroML.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdSubSubRubroML
        '
        Me.lblIdSubSubRubroML.AutoSize = True
        Me.lblIdSubSubRubroML.LabelAsoc = Nothing
        Me.lblIdSubSubRubroML.Location = New System.Drawing.Point(6, 35)
        Me.lblIdSubSubRubroML.Name = "lblIdSubSubRubroML"
        Me.lblIdSubSubRubroML.Size = New System.Drawing.Size(117, 13)
        Me.lblIdSubSubRubroML.TabIndex = 12
        Me.lblIdSubSubRubroML.Text = "Cód. SubSubRubro ML"
        '
        'txtIdSubSubRubroTiendaNube
        '
        Me.txtIdSubSubRubroTiendaNube.BindearPropiedadControl = "Text"
        Me.txtIdSubSubRubroTiendaNube.BindearPropiedadEntidad = "IdSubSubRubroTiendaNube"
        Me.txtIdSubSubRubroTiendaNube.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSubSubRubroTiendaNube.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSubSubRubroTiendaNube.Formato = ""
        Me.txtIdSubSubRubroTiendaNube.IsDecimal = False
        Me.txtIdSubSubRubroTiendaNube.IsNumber = False
        Me.txtIdSubSubRubroTiendaNube.IsPK = False
        Me.txtIdSubSubRubroTiendaNube.IsRequired = False
        Me.txtIdSubSubRubroTiendaNube.Key = ""
        Me.txtIdSubSubRubroTiendaNube.LabelAsoc = Me.lblIdSubSubRubroTiendaNube
        Me.txtIdSubSubRubroTiendaNube.Location = New System.Drawing.Point(176, 6)
        Me.txtIdSubSubRubroTiendaNube.MaxLength = 30
        Me.txtIdSubSubRubroTiendaNube.Name = "txtIdSubSubRubroTiendaNube"
        Me.txtIdSubSubRubroTiendaNube.Size = New System.Drawing.Size(98, 20)
        Me.txtIdSubSubRubroTiendaNube.TabIndex = 11
        Me.txtIdSubSubRubroTiendaNube.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdSubSubRubroTiendaNube
        '
        Me.lblIdSubSubRubroTiendaNube.AutoSize = True
        Me.lblIdSubSubRubroTiendaNube.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdSubSubRubroTiendaNube.LabelAsoc = Nothing
        Me.lblIdSubSubRubroTiendaNube.Location = New System.Drawing.Point(6, 9)
        Me.lblIdSubSubRubroTiendaNube.Name = "lblIdSubSubRubroTiendaNube"
        Me.lblIdSubSubRubroTiendaNube.Size = New System.Drawing.Size(164, 13)
        Me.lblIdSubSubRubroTiendaNube.TabIndex = 10
        Me.lblIdSubSubRubroTiendaNube.Text = "Cód. SubSubRubro Tienda Nube"
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.LabelAsoc = Nothing
        Me.lblRubro.Location = New System.Drawing.Point(25, 19)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(36, 13)
        Me.lblRubro.TabIndex = 26
        Me.lblRubro.Text = "Rubro"
        '
        'bscCodigoRubro
        '
        Me.bscCodigoRubro.AyudaAncho = 608
        Me.bscCodigoRubro.BindearPropiedadControl = "Text"
        Me.bscCodigoRubro.BindearPropiedadEntidad = "IdRubro"
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
        Me.bscCodigoRubro.IsNumber = True
        Me.bscCodigoRubro.IsPK = True
        Me.bscCodigoRubro.IsRequired = True
        Me.bscCodigoRubro.Key = ""
        Me.bscCodigoRubro.LabelAsoc = Nothing
        Me.bscCodigoRubro.Location = New System.Drawing.Point(103, 12)
        Me.bscCodigoRubro.MaxLengh = "32767"
        Me.bscCodigoRubro.Name = "bscCodigoRubro"
        Me.bscCodigoRubro.Permitido = True
        Me.bscCodigoRubro.Selecciono = False
        Me.bscCodigoRubro.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoRubro.TabIndex = 27
        Me.bscCodigoRubro.Titulo = Nothing
        '
        'bscNombreRubro
        '
        Me.bscNombreRubro.AyudaAncho = 608
        Me.bscNombreRubro.BindearPropiedadControl = Nothing
        Me.bscNombreRubro.BindearPropiedadEntidad = Nothing
        Me.bscNombreRubro.ColumnasAlineacion = Nothing
        Me.bscNombreRubro.ColumnasAncho = Nothing
        Me.bscNombreRubro.ColumnasFormato = Nothing
        Me.bscNombreRubro.ColumnasOcultas = Nothing
        Me.bscNombreRubro.ColumnasTitulos = Nothing
        Me.bscNombreRubro.Datos = Nothing
        Me.bscNombreRubro.FilaDevuelta = Nothing
        Me.bscNombreRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreRubro.IsDecimal = False
        Me.bscNombreRubro.IsNumber = False
        Me.bscNombreRubro.IsPK = True
        Me.bscNombreRubro.IsRequired = True
        Me.bscNombreRubro.Key = ""
        Me.bscNombreRubro.LabelAsoc = Nothing
        Me.bscNombreRubro.Location = New System.Drawing.Point(198, 12)
        Me.bscNombreRubro.MaxLengh = "32767"
        Me.bscNombreRubro.Name = "bscNombreRubro"
        Me.bscNombreRubro.Permitido = True
        Me.bscNombreRubro.Selecciono = False
        Me.bscNombreRubro.Size = New System.Drawing.Size(340, 20)
        Me.bscNombreRubro.TabIndex = 28
        Me.bscNombreRubro.Titulo = Nothing
        '
        'lblSubRubro
        '
        Me.lblSubRubro.AutoSize = True
        Me.lblSubRubro.LabelAsoc = Nothing
        Me.lblSubRubro.Location = New System.Drawing.Point(25, 45)
        Me.lblSubRubro.Name = "lblSubRubro"
        Me.lblSubRubro.Size = New System.Drawing.Size(55, 13)
        Me.lblSubRubro.TabIndex = 29
        Me.lblSubRubro.Text = "SubRubro"
        '
        'bscCodigoSubRubro
        '
        Me.bscCodigoSubRubro.AyudaAncho = 608
        Me.bscCodigoSubRubro.BindearPropiedadControl = "Text"
        Me.bscCodigoSubRubro.BindearPropiedadEntidad = "IdSubRubro"
        Me.bscCodigoSubRubro.ColumnasAlineacion = Nothing
        Me.bscCodigoSubRubro.ColumnasAncho = Nothing
        Me.bscCodigoSubRubro.ColumnasFormato = Nothing
        Me.bscCodigoSubRubro.ColumnasOcultas = Nothing
        Me.bscCodigoSubRubro.ColumnasTitulos = Nothing
        Me.bscCodigoSubRubro.Datos = Nothing
        Me.bscCodigoSubRubro.FilaDevuelta = Nothing
        Me.bscCodigoSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoSubRubro.IsDecimal = False
        Me.bscCodigoSubRubro.IsNumber = True
        Me.bscCodigoSubRubro.IsPK = True
        Me.bscCodigoSubRubro.IsRequired = True
        Me.bscCodigoSubRubro.Key = ""
        Me.bscCodigoSubRubro.LabelAsoc = Me.lblSubRubro
        Me.bscCodigoSubRubro.Location = New System.Drawing.Point(103, 38)
        Me.bscCodigoSubRubro.MaxLengh = "32767"
        Me.bscCodigoSubRubro.Name = "bscCodigoSubRubro"
        Me.bscCodigoSubRubro.Permitido = True
        Me.bscCodigoSubRubro.Selecciono = False
        Me.bscCodigoSubRubro.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoSubRubro.TabIndex = 30
        Me.bscCodigoSubRubro.Titulo = Nothing
        '
        'bscSubRubro
        '
        Me.bscSubRubro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscSubRubro.AyudaAncho = 608
        Me.bscSubRubro.BindearPropiedadControl = Nothing
        Me.bscSubRubro.BindearPropiedadEntidad = Nothing
        Me.bscSubRubro.ColumnasAlineacion = Nothing
        Me.bscSubRubro.ColumnasAncho = Nothing
        Me.bscSubRubro.ColumnasFormato = Nothing
        Me.bscSubRubro.ColumnasOcultas = Nothing
        Me.bscSubRubro.ColumnasTitulos = Nothing
        Me.bscSubRubro.Datos = Nothing
        Me.bscSubRubro.FilaDevuelta = Nothing
        Me.bscSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscSubRubro.IsDecimal = False
        Me.bscSubRubro.IsNumber = False
        Me.bscSubRubro.IsPK = True
        Me.bscSubRubro.IsRequired = True
        Me.bscSubRubro.Key = ""
        Me.bscSubRubro.LabelAsoc = Me.lblSubRubro
        Me.bscSubRubro.Location = New System.Drawing.Point(198, 38)
        Me.bscSubRubro.MaxLengh = "32767"
        Me.bscSubRubro.Name = "bscSubRubro"
        Me.bscSubRubro.Permitido = True
        Me.bscSubRubro.Selecciono = False
        Me.bscSubRubro.Size = New System.Drawing.Size(340, 20)
        Me.bscSubRubro.TabIndex = 31
        Me.bscSubRubro.Titulo = Nothing
        '
        'lblNombreSubSubRubro
        '
        Me.lblNombreSubSubRubro.AutoSize = True
        Me.lblNombreSubSubRubro.LabelAsoc = Nothing
        Me.lblNombreSubSubRubro.Location = New System.Drawing.Point(25, 97)
        Me.lblNombreSubSubRubro.Name = "lblNombreSubSubRubro"
        Me.lblNombreSubSubRubro.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreSubSubRubro.TabIndex = 24
        Me.lblNombreSubSubRubro.Text = "Nombre"
        '
        'txtNombreSubSubRubro
        '
        Me.txtNombreSubSubRubro.BindearPropiedadControl = "Text"
        Me.txtNombreSubSubRubro.BindearPropiedadEntidad = "NombreSubSubRubro"
        Me.txtNombreSubSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreSubSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreSubSubRubro.Formato = ""
        Me.txtNombreSubSubRubro.IsDecimal = False
        Me.txtNombreSubSubRubro.IsNumber = False
        Me.txtNombreSubSubRubro.IsPK = False
        Me.txtNombreSubSubRubro.IsRequired = True
        Me.txtNombreSubSubRubro.Key = ""
        Me.txtNombreSubSubRubro.LabelAsoc = Me.lblNombreSubSubRubro
        Me.txtNombreSubSubRubro.Location = New System.Drawing.Point(103, 90)
        Me.txtNombreSubSubRubro.MaxLength = 50
        Me.txtNombreSubSubRubro.Name = "txtNombreSubSubRubro"
        Me.txtNombreSubSubRubro.Size = New System.Drawing.Size(323, 20)
        Me.txtNombreSubSubRubro.TabIndex = 25
        '
        'lblIdSubRubro
        '
        Me.lblIdSubRubro.AutoSize = True
        Me.lblIdSubRubro.LabelAsoc = Nothing
        Me.lblIdSubRubro.Location = New System.Drawing.Point(25, 71)
        Me.lblIdSubRubro.Name = "lblIdSubRubro"
        Me.lblIdSubRubro.Size = New System.Drawing.Size(40, 13)
        Me.lblIdSubRubro.TabIndex = 22
        Me.lblIdSubRubro.Text = "Código"
        '
        'txtIdSubSubRubro
        '
        Me.txtIdSubSubRubro.BindearPropiedadControl = "Text"
        Me.txtIdSubSubRubro.BindearPropiedadEntidad = "IdSubSubRubro"
        Me.txtIdSubSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSubSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSubSubRubro.Formato = ""
        Me.txtIdSubSubRubro.IsDecimal = False
        Me.txtIdSubSubRubro.IsNumber = True
        Me.txtIdSubSubRubro.IsPK = True
        Me.txtIdSubSubRubro.IsRequired = True
        Me.txtIdSubSubRubro.Key = ""
        Me.txtIdSubSubRubro.LabelAsoc = Me.lblIdSubRubro
        Me.txtIdSubSubRubro.Location = New System.Drawing.Point(103, 64)
        Me.txtIdSubSubRubro.MaxLength = 9
        Me.txtIdSubSubRubro.Name = "txtIdSubSubRubro"
        Me.txtIdSubSubRubro.Size = New System.Drawing.Size(77, 20)
        Me.txtIdSubSubRubro.TabIndex = 23
        Me.txtIdSubSubRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIdSubSubRubroArborea
        '
        Me.txtIdSubSubRubroArborea.BindearPropiedadControl = "Text"
        Me.txtIdSubSubRubroArborea.BindearPropiedadEntidad = "IdSubSubRubroArborea"
        Me.txtIdSubSubRubroArborea.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSubSubRubroArborea.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSubSubRubroArborea.Formato = "N2"
        Me.txtIdSubSubRubroArborea.IsDecimal = False
        Me.txtIdSubSubRubroArborea.IsNumber = False
        Me.txtIdSubSubRubroArborea.IsPK = False
        Me.txtIdSubSubRubroArborea.IsRequired = False
        Me.txtIdSubSubRubroArborea.Key = ""
        Me.txtIdSubSubRubroArborea.LabelAsoc = Me.Label1
        Me.txtIdSubSubRubroArborea.Location = New System.Drawing.Point(176, 58)
        Me.txtIdSubSubRubroArborea.MaxLength = 30
        Me.txtIdSubSubRubroArborea.Name = "txtIdSubSubRubroArborea"
        Me.txtIdSubSubRubroArborea.Size = New System.Drawing.Size(98, 20)
        Me.txtIdSubSubRubroArborea.TabIndex = 15
        Me.txtIdSubSubRubroArborea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(6, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Cód. SubSubRubro Arborea"
        '
        'SubSubRubrosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(583, 273)
        Me.Controls.Add(Me.lblRubro)
        Me.Controls.Add(Me.bscCodigoRubro)
        Me.Controls.Add(Me.bscNombreRubro)
        Me.Controls.Add(Me.lblSubRubro)
        Me.Controls.Add(Me.bscCodigoSubRubro)
        Me.Controls.Add(Me.bscSubRubro)
        Me.Controls.Add(Me.lblNombreSubSubRubro)
        Me.Controls.Add(Me.txtNombreSubSubRubro)
        Me.Controls.Add(Me.lblIdSubRubro)
        Me.Controls.Add(Me.txtIdSubSubRubro)
        Me.Controls.Add(Me.tcSubSubRubro)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SubSubRubrosDetalle"
        Me.Text = "SubSubRubro"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.tcSubSubRubro, 0)
        Me.Controls.SetChildIndex(Me.txtIdSubSubRubro, 0)
        Me.Controls.SetChildIndex(Me.lblIdSubRubro, 0)
        Me.Controls.SetChildIndex(Me.txtNombreSubSubRubro, 0)
        Me.Controls.SetChildIndex(Me.lblNombreSubSubRubro, 0)
        Me.Controls.SetChildIndex(Me.bscSubRubro, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoSubRubro, 0)
        Me.Controls.SetChildIndex(Me.lblSubRubro, 0)
        Me.Controls.SetChildIndex(Me.bscNombreRubro, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoRubro, 0)
        Me.Controls.SetChildIndex(Me.lblRubro, 0)
        Me.tcSubSubRubro.ResumeLayout(False)
        Me.tpTiendaWeb.ResumeLayout(False)
        Me.tpTiendaWeb.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tcSubSubRubro As System.Windows.Forms.TabControl
   Friend WithEvents tpTiendaWeb As System.Windows.Forms.TabPage
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents bscCodigoRubro As Eniac.Controles.Buscador
   Friend WithEvents bscNombreRubro As Eniac.Controles.Buscador
   Friend WithEvents lblSubRubro As Eniac.Controles.Label
   Friend WithEvents bscCodigoSubRubro As Eniac.Controles.Buscador
   Friend WithEvents bscSubRubro As Eniac.Controles.Buscador
   Friend WithEvents lblNombreSubSubRubro As Eniac.Controles.Label
   Friend WithEvents txtNombreSubSubRubro As Eniac.Controles.TextBox
   Friend WithEvents lblIdSubRubro As Eniac.Controles.Label
   Friend WithEvents txtIdSubSubRubro As Eniac.Controles.TextBox
   Friend WithEvents txtIdSubSubRubroML As Eniac.Controles.TextBox
   Friend WithEvents lblIdSubSubRubroML As Eniac.Controles.Label
   Friend WithEvents txtIdSubSubRubroTiendaNube As Eniac.Controles.TextBox
   Friend WithEvents lblIdSubSubRubroTiendaNube As Eniac.Controles.Label
    Friend WithEvents txtIdSubSubRubroArborea As Controles.TextBox
    Friend WithEvents Label1 As Controles.Label
End Class
