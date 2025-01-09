<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AtributosProductosDetalle
	Inherits BaseDetalle

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
		Me.bscDescripcionGrupoTipoAtributo = New Eniac.Controles.Buscador2()
		Me.lblGrupo = New Eniac.Controles.Label()
		Me.bscCodigoGrupoTipoAtributo = New Eniac.Controles.Buscador2()
		Me.bscDescripcionTipoAtributo = New Eniac.Controles.Buscador2()
		Me.lblTipo = New Eniac.Controles.Label()
		Me.bscCodigoTipoAtributo = New Eniac.Controles.Buscador2()
		Me.lblDescripcion = New Eniac.Controles.Label()
		Me.txtDescripcion = New Eniac.Controles.TextBox()
		Me.lblAtributo = New Eniac.Controles.Label()
		Me.txtIdAtributo = New Eniac.Controles.TextBox()
		Me.lblOrden = New Eniac.Controles.Label()
		Me.txtOrden = New Eniac.Controles.TextBox()
		Me.SuspendLayout()
		'
		'btnAceptar
		'
		Me.btnAceptar.Location = New System.Drawing.Point(286, 174)
		Me.btnAceptar.TabIndex = 14
		'
		'btnCancelar
		'
		Me.btnCancelar.Location = New System.Drawing.Point(372, 174)
		Me.btnCancelar.TabIndex = 15
		'
		'btnCopiar
		'
		Me.btnCopiar.Location = New System.Drawing.Point(185, 174)
		Me.btnCopiar.TabIndex = 13
		'
		'btnAplicar
		'
		Me.btnAplicar.Location = New System.Drawing.Point(128, 174)
		Me.btnAplicar.TabIndex = 12
		'
		'bscDescripcionGrupoTipoAtributo
		'
		Me.bscDescripcionGrupoTipoAtributo.ActivarFiltroEnGrilla = True
		Me.bscDescripcionGrupoTipoAtributo.BindearPropiedadControl = Nothing
		Me.bscDescripcionGrupoTipoAtributo.BindearPropiedadEntidad = Nothing
		Me.bscDescripcionGrupoTipoAtributo.ConfigBuscador = Nothing
		Me.bscDescripcionGrupoTipoAtributo.Datos = Nothing
		Me.bscDescripcionGrupoTipoAtributo.FilaDevuelta = Nothing
		Me.bscDescripcionGrupoTipoAtributo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.bscDescripcionGrupoTipoAtributo.ForeColorFocus = System.Drawing.Color.Red
		Me.bscDescripcionGrupoTipoAtributo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.bscDescripcionGrupoTipoAtributo.IsDecimal = False
		Me.bscDescripcionGrupoTipoAtributo.IsNumber = False
		Me.bscDescripcionGrupoTipoAtributo.IsPK = False
		Me.bscDescripcionGrupoTipoAtributo.IsRequired = False
		Me.bscDescripcionGrupoTipoAtributo.Key = ""
		Me.bscDescripcionGrupoTipoAtributo.LabelAsoc = Me.lblGrupo
		Me.bscDescripcionGrupoTipoAtributo.Location = New System.Drawing.Point(222, 44)
		Me.bscDescripcionGrupoTipoAtributo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
		Me.bscDescripcionGrupoTipoAtributo.MaxLengh = "32767"
		Me.bscDescripcionGrupoTipoAtributo.Name = "bscDescripcionGrupoTipoAtributo"
		Me.bscDescripcionGrupoTipoAtributo.Permitido = True
		Me.bscDescripcionGrupoTipoAtributo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
		Me.bscDescripcionGrupoTipoAtributo.PermitidoNoForeColor = System.Drawing.Color.Black
		Me.bscDescripcionGrupoTipoAtributo.PermitidoSiBackColor = System.Drawing.Color.White
		Me.bscDescripcionGrupoTipoAtributo.PermitidoSiForeColor = System.Drawing.Color.Black
		Me.bscDescripcionGrupoTipoAtributo.Selecciono = False
		Me.bscDescripcionGrupoTipoAtributo.Size = New System.Drawing.Size(229, 23)
		Me.bscDescripcionGrupoTipoAtributo.TabIndex = 5
		'
		'lblGrupo
		'
		Me.lblGrupo.AutoSize = True
		Me.lblGrupo.LabelAsoc = Nothing
		Me.lblGrupo.Location = New System.Drawing.Point(19, 48)
		Me.lblGrupo.Name = "lblGrupo"
		Me.lblGrupo.Size = New System.Drawing.Size(72, 13)
		Me.lblGrupo.TabIndex = 3
		Me.lblGrupo.Text = "Codigo Grupo"
		'
		'bscCodigoGrupoTipoAtributo
		'
		Me.bscCodigoGrupoTipoAtributo.ActivarFiltroEnGrilla = True
		Me.bscCodigoGrupoTipoAtributo.BindearPropiedadControl = ""
		Me.bscCodigoGrupoTipoAtributo.BindearPropiedadEntidad = ""
		Me.bscCodigoGrupoTipoAtributo.ConfigBuscador = Nothing
		Me.bscCodigoGrupoTipoAtributo.Datos = Nothing
		Me.bscCodigoGrupoTipoAtributo.FilaDevuelta = Nothing
		Me.bscCodigoGrupoTipoAtributo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.bscCodigoGrupoTipoAtributo.ForeColorFocus = System.Drawing.Color.Red
		Me.bscCodigoGrupoTipoAtributo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.bscCodigoGrupoTipoAtributo.IsDecimal = False
		Me.bscCodigoGrupoTipoAtributo.IsNumber = False
		Me.bscCodigoGrupoTipoAtributo.IsPK = False
		Me.bscCodigoGrupoTipoAtributo.IsRequired = False
		Me.bscCodigoGrupoTipoAtributo.Key = ""
		Me.bscCodigoGrupoTipoAtributo.LabelAsoc = Me.lblGrupo
		Me.bscCodigoGrupoTipoAtributo.Location = New System.Drawing.Point(111, 44)
		Me.bscCodigoGrupoTipoAtributo.MaxLengh = "32767"
		Me.bscCodigoGrupoTipoAtributo.Name = "bscCodigoGrupoTipoAtributo"
		Me.bscCodigoGrupoTipoAtributo.Permitido = True
		Me.bscCodigoGrupoTipoAtributo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
		Me.bscCodigoGrupoTipoAtributo.PermitidoNoForeColor = System.Drawing.Color.Black
		Me.bscCodigoGrupoTipoAtributo.PermitidoSiBackColor = System.Drawing.Color.White
		Me.bscCodigoGrupoTipoAtributo.PermitidoSiForeColor = System.Drawing.Color.Black
		Me.bscCodigoGrupoTipoAtributo.Selecciono = False
		Me.bscCodigoGrupoTipoAtributo.Size = New System.Drawing.Size(105, 23)
		Me.bscCodigoGrupoTipoAtributo.TabIndex = 4
		'
		'bscDescripcionTipoAtributo
		'
		Me.bscDescripcionTipoAtributo.ActivarFiltroEnGrilla = True
		Me.bscDescripcionTipoAtributo.BindearPropiedadControl = Nothing
		Me.bscDescripcionTipoAtributo.BindearPropiedadEntidad = Nothing
		Me.bscDescripcionTipoAtributo.ConfigBuscador = Nothing
		Me.bscDescripcionTipoAtributo.Datos = Nothing
		Me.bscDescripcionTipoAtributo.FilaDevuelta = Nothing
		Me.bscDescripcionTipoAtributo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.bscDescripcionTipoAtributo.ForeColorFocus = System.Drawing.Color.Red
		Me.bscDescripcionTipoAtributo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.bscDescripcionTipoAtributo.IsDecimal = False
		Me.bscDescripcionTipoAtributo.IsNumber = False
		Me.bscDescripcionTipoAtributo.IsPK = False
		Me.bscDescripcionTipoAtributo.IsRequired = False
		Me.bscDescripcionTipoAtributo.Key = ""
		Me.bscDescripcionTipoAtributo.LabelAsoc = Me.lblTipo
		Me.bscDescripcionTipoAtributo.Location = New System.Drawing.Point(222, 13)
		Me.bscDescripcionTipoAtributo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
		Me.bscDescripcionTipoAtributo.MaxLengh = "32767"
		Me.bscDescripcionTipoAtributo.Name = "bscDescripcionTipoAtributo"
		Me.bscDescripcionTipoAtributo.Permitido = True
		Me.bscDescripcionTipoAtributo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
		Me.bscDescripcionTipoAtributo.PermitidoNoForeColor = System.Drawing.Color.Black
		Me.bscDescripcionTipoAtributo.PermitidoSiBackColor = System.Drawing.Color.White
		Me.bscDescripcionTipoAtributo.PermitidoSiForeColor = System.Drawing.Color.Black
		Me.bscDescripcionTipoAtributo.Selecciono = False
		Me.bscDescripcionTipoAtributo.Size = New System.Drawing.Size(229, 23)
		Me.bscDescripcionTipoAtributo.TabIndex = 2
		'
		'lblTipo
		'
		Me.lblTipo.AutoSize = True
		Me.lblTipo.LabelAsoc = Nothing
		Me.lblTipo.Location = New System.Drawing.Point(19, 17)
		Me.lblTipo.Name = "lblTipo"
		Me.lblTipo.Size = New System.Drawing.Size(64, 13)
		Me.lblTipo.TabIndex = 0
		Me.lblTipo.Text = "Codigo Tipo"
		'
		'bscCodigoTipoAtributo
		'
		Me.bscCodigoTipoAtributo.ActivarFiltroEnGrilla = True
		Me.bscCodigoTipoAtributo.BindearPropiedadControl = ""
		Me.bscCodigoTipoAtributo.BindearPropiedadEntidad = ""
		Me.bscCodigoTipoAtributo.ConfigBuscador = Nothing
		Me.bscCodigoTipoAtributo.Datos = Nothing
		Me.bscCodigoTipoAtributo.FilaDevuelta = Nothing
		Me.bscCodigoTipoAtributo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.bscCodigoTipoAtributo.ForeColorFocus = System.Drawing.Color.Red
		Me.bscCodigoTipoAtributo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.bscCodigoTipoAtributo.IsDecimal = False
		Me.bscCodigoTipoAtributo.IsNumber = False
		Me.bscCodigoTipoAtributo.IsPK = False
		Me.bscCodigoTipoAtributo.IsRequired = False
		Me.bscCodigoTipoAtributo.Key = ""
		Me.bscCodigoTipoAtributo.LabelAsoc = Me.lblTipo
		Me.bscCodigoTipoAtributo.Location = New System.Drawing.Point(111, 13)
		Me.bscCodigoTipoAtributo.MaxLengh = "32767"
		Me.bscCodigoTipoAtributo.Name = "bscCodigoTipoAtributo"
		Me.bscCodigoTipoAtributo.Permitido = True
		Me.bscCodigoTipoAtributo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
		Me.bscCodigoTipoAtributo.PermitidoNoForeColor = System.Drawing.Color.Black
		Me.bscCodigoTipoAtributo.PermitidoSiBackColor = System.Drawing.Color.White
		Me.bscCodigoTipoAtributo.PermitidoSiForeColor = System.Drawing.Color.Black
		Me.bscCodigoTipoAtributo.Selecciono = False
		Me.bscCodigoTipoAtributo.Size = New System.Drawing.Size(105, 23)
		Me.bscCodigoTipoAtributo.TabIndex = 1
		'
		'lblDescripcion
		'
		Me.lblDescripcion.AutoSize = True
		Me.lblDescripcion.LabelAsoc = Nothing
		Me.lblDescripcion.Location = New System.Drawing.Point(19, 107)
		Me.lblDescripcion.Name = "lblDescripcion"
		Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
		Me.lblDescripcion.TabIndex = 8
		Me.lblDescripcion.Text = "Descripcion"
		'
		'txtDescripcion
		'
		Me.txtDescripcion.BindearPropiedadControl = ""
		Me.txtDescripcion.BindearPropiedadEntidad = ""
		Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
		Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtDescripcion.Formato = ""
		Me.txtDescripcion.IsDecimal = False
		Me.txtDescripcion.IsNumber = False
		Me.txtDescripcion.IsPK = False
		Me.txtDescripcion.IsRequired = False
		Me.txtDescripcion.Key = ""
		Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
		Me.txtDescripcion.Location = New System.Drawing.Point(111, 104)
		Me.txtDescripcion.MaxLength = 50
		Me.txtDescripcion.Name = "txtDescripcion"
		Me.txtDescripcion.Size = New System.Drawing.Size(340, 20)
		Me.txtDescripcion.TabIndex = 9
		'
		'lblAtributo
		'
		Me.lblAtributo.AutoSize = True
		Me.lblAtributo.LabelAsoc = Nothing
		Me.lblAtributo.Location = New System.Drawing.Point(19, 77)
		Me.lblAtributo.Name = "lblAtributo"
		Me.lblAtributo.Size = New System.Drawing.Size(79, 13)
		Me.lblAtributo.TabIndex = 6
		Me.lblAtributo.Text = "Codigo Atributo"
		'
		'txtIdAtributo
		'
		Me.txtIdAtributo.BindearPropiedadControl = "Text"
		Me.txtIdAtributo.BindearPropiedadEntidad = "IdGrupoTipoAtributoProducto"
		Me.txtIdAtributo.ForeColorFocus = System.Drawing.Color.Red
		Me.txtIdAtributo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtIdAtributo.Formato = ""
		Me.txtIdAtributo.IsDecimal = False
		Me.txtIdAtributo.IsNumber = True
		Me.txtIdAtributo.IsPK = True
		Me.txtIdAtributo.IsRequired = False
		Me.txtIdAtributo.Key = ""
		Me.txtIdAtributo.LabelAsoc = Me.lblAtributo
		Me.txtIdAtributo.Location = New System.Drawing.Point(111, 74)
		Me.txtIdAtributo.MaxLength = 10
		Me.txtIdAtributo.Name = "txtIdAtributo"
		Me.txtIdAtributo.Size = New System.Drawing.Size(105, 20)
		Me.txtIdAtributo.TabIndex = 7
		Me.txtIdAtributo.Text = "0"
		Me.txtIdAtributo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblOrden
		'
		Me.lblOrden.AutoSize = True
		Me.lblOrden.LabelAsoc = Nothing
		Me.lblOrden.Location = New System.Drawing.Point(19, 141)
		Me.lblOrden.Name = "lblOrden"
		Me.lblOrden.Size = New System.Drawing.Size(36, 13)
		Me.lblOrden.TabIndex = 10
		Me.lblOrden.Text = "Orden"
		'
		'txtOrden
		'
		Me.txtOrden.BindearPropiedadControl = ""
		Me.txtOrden.BindearPropiedadEntidad = ""
		Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
		Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtOrden.Formato = ""
		Me.txtOrden.IsDecimal = False
		Me.txtOrden.IsNumber = False
		Me.txtOrden.IsPK = False
		Me.txtOrden.IsRequired = False
		Me.txtOrden.Key = ""
		Me.txtOrden.LabelAsoc = Me.lblOrden
		Me.txtOrden.Location = New System.Drawing.Point(111, 138)
		Me.txtOrden.MaxLength = 50
		Me.txtOrden.Name = "txtOrden"
		Me.txtOrden.Size = New System.Drawing.Size(105, 20)
		Me.txtOrden.TabIndex = 11
		Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'AtributosProductosDetalle
		'
		Me.AcceptButton = Nothing
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(461, 209)
		Me.Controls.Add(Me.txtOrden)
		Me.Controls.Add(Me.lblOrden)
		Me.Controls.Add(Me.lblDescripcion)
		Me.Controls.Add(Me.txtDescripcion)
		Me.Controls.Add(Me.lblAtributo)
		Me.Controls.Add(Me.txtIdAtributo)
		Me.Controls.Add(Me.bscDescripcionTipoAtributo)
		Me.Controls.Add(Me.bscCodigoTipoAtributo)
		Me.Controls.Add(Me.lblTipo)
		Me.Controls.Add(Me.bscDescripcionGrupoTipoAtributo)
		Me.Controls.Add(Me.bscCodigoGrupoTipoAtributo)
		Me.Controls.Add(Me.lblGrupo)
		Me.Name = "AtributosProductosDetalle"
		Me.Text = "Atributos de Productos "
		Me.Controls.SetChildIndex(Me.btnCancelar, 0)
		Me.Controls.SetChildIndex(Me.btnAceptar, 0)
		Me.Controls.SetChildIndex(Me.btnCopiar, 0)
		Me.Controls.SetChildIndex(Me.btnAplicar, 0)
		Me.Controls.SetChildIndex(Me.lblGrupo, 0)
		Me.Controls.SetChildIndex(Me.bscCodigoGrupoTipoAtributo, 0)
		Me.Controls.SetChildIndex(Me.bscDescripcionGrupoTipoAtributo, 0)
		Me.Controls.SetChildIndex(Me.lblTipo, 0)
		Me.Controls.SetChildIndex(Me.bscCodigoTipoAtributo, 0)
		Me.Controls.SetChildIndex(Me.bscDescripcionTipoAtributo, 0)
		Me.Controls.SetChildIndex(Me.txtIdAtributo, 0)
		Me.Controls.SetChildIndex(Me.lblAtributo, 0)
		Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
		Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
		Me.Controls.SetChildIndex(Me.lblOrden, 0)
		Me.Controls.SetChildIndex(Me.txtOrden, 0)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents bscDescripcionGrupoTipoAtributo As Controles.Buscador2
	Friend WithEvents lblGrupo As Controles.Label
	Friend WithEvents bscCodigoGrupoTipoAtributo As Controles.Buscador2
	Friend WithEvents bscDescripcionTipoAtributo As Controles.Buscador2
	Friend WithEvents lblTipo As Controles.Label
	Friend WithEvents bscCodigoTipoAtributo As Controles.Buscador2
	Friend WithEvents lblDescripcion As Controles.Label
	Friend WithEvents txtDescripcion As Controles.TextBox
	Friend WithEvents lblAtributo As Controles.Label
	Friend WithEvents txtIdAtributo As Controles.TextBox
	Friend WithEvents lblOrden As Controles.Label
	Friend WithEvents txtOrden As Controles.TextBox
End Class
