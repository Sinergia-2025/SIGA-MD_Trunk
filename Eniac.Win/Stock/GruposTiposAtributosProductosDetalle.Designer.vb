<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GruposTiposAtributosProductosDetalle
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
		Me.lblDescripcion = New Eniac.Controles.Label()
		Me.txtDescripcion = New Eniac.Controles.TextBox()
		Me.lblId = New Eniac.Controles.Label()
		Me.txtIdGrupo = New Eniac.Controles.TextBox()
		Me.bscDescripcionTipoAtributo = New Eniac.Controles.Buscador2()
		Me.lblCoidigoTipoAtributo = New Eniac.Controles.Label()
		Me.bscCodigoTipoAtributo = New Eniac.Controles.Buscador2()
		Me.SuspendLayout()
		'
		'btnAceptar
		'
		Me.btnAceptar.Location = New System.Drawing.Point(272, 125)
		Me.btnAceptar.TabIndex = 7
		'
		'btnCancelar
		'
		Me.btnCancelar.Location = New System.Drawing.Point(358, 125)
		Me.btnCancelar.TabIndex = 8
		'
		'btnCopiar
		'
		Me.btnCopiar.Location = New System.Drawing.Point(171, 125)
		'
		'btnAplicar
		'
		Me.btnAplicar.Location = New System.Drawing.Point(114, 125)
		'
		'lblDescripcion
		'
		Me.lblDescripcion.AutoSize = True
		Me.lblDescripcion.LabelAsoc = Nothing
		Me.lblDescripcion.Location = New System.Drawing.Point(13, 85)
		Me.lblDescripcion.Name = "lblDescripcion"
		Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
		Me.lblDescripcion.TabIndex = 5
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
		Me.txtDescripcion.Location = New System.Drawing.Point(91, 82)
		Me.txtDescripcion.MaxLength = 50
		Me.txtDescripcion.Name = "txtDescripcion"
		Me.txtDescripcion.Size = New System.Drawing.Size(340, 20)
		Me.txtDescripcion.TabIndex = 6
		'
		'lblId
		'
		Me.lblId.AutoSize = True
		Me.lblId.LabelAsoc = Nothing
		Me.lblId.Location = New System.Drawing.Point(13, 55)
		Me.lblId.Name = "lblId"
		Me.lblId.Size = New System.Drawing.Size(72, 13)
		Me.lblId.TabIndex = 3
		Me.lblId.Text = "Codigo Grupo"
		'
		'txtIdGrupo
		'
		Me.txtIdGrupo.BindearPropiedadControl = "Text"
		Me.txtIdGrupo.BindearPropiedadEntidad = "IdGrupoTipoAtributoProducto"
		Me.txtIdGrupo.ForeColorFocus = System.Drawing.Color.Red
		Me.txtIdGrupo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtIdGrupo.Formato = ""
		Me.txtIdGrupo.IsDecimal = False
		Me.txtIdGrupo.IsNumber = True
		Me.txtIdGrupo.IsPK = True
		Me.txtIdGrupo.IsRequired = True
		Me.txtIdGrupo.Key = ""
		Me.txtIdGrupo.LabelAsoc = Me.lblId
		Me.txtIdGrupo.Location = New System.Drawing.Point(91, 52)
		Me.txtIdGrupo.MaxLength = 10
		Me.txtIdGrupo.Name = "txtIdGrupo"
		Me.txtIdGrupo.Size = New System.Drawing.Size(105, 20)
		Me.txtIdGrupo.TabIndex = 4
		Me.txtIdGrupo.Text = "0"
		Me.txtIdGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
		Me.bscDescripcionTipoAtributo.LabelAsoc = Me.lblCoidigoTipoAtributo
		Me.bscDescripcionTipoAtributo.Location = New System.Drawing.Point(202, 18)
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
		'lblCoidigoTipoAtributo
		'
		Me.lblCoidigoTipoAtributo.AutoSize = True
		Me.lblCoidigoTipoAtributo.LabelAsoc = Nothing
		Me.lblCoidigoTipoAtributo.Location = New System.Drawing.Point(13, 22)
		Me.lblCoidigoTipoAtributo.Name = "lblCoidigoTipoAtributo"
		Me.lblCoidigoTipoAtributo.Size = New System.Drawing.Size(64, 13)
		Me.lblCoidigoTipoAtributo.TabIndex = 0
		Me.lblCoidigoTipoAtributo.Text = "Codigo Tipo"
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
		Me.bscCodigoTipoAtributo.LabelAsoc = Me.lblCoidigoTipoAtributo
		Me.bscCodigoTipoAtributo.Location = New System.Drawing.Point(91, 18)
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
		'GruposTiposAtributosProductosDetalle
		'
		Me.AcceptButton = Nothing
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(447, 160)
		Me.Controls.Add(Me.bscDescripcionTipoAtributo)
		Me.Controls.Add(Me.bscCodigoTipoAtributo)
		Me.Controls.Add(Me.lblCoidigoTipoAtributo)
		Me.Controls.Add(Me.lblDescripcion)
		Me.Controls.Add(Me.txtDescripcion)
		Me.Controls.Add(Me.lblId)
		Me.Controls.Add(Me.txtIdGrupo)
		Me.Name = "GruposTiposAtributosProductosDetalle"
		Me.Text = "Grupos de Tipos de Atributos de Productos"
		Me.Controls.SetChildIndex(Me.btnCancelar, 0)
		Me.Controls.SetChildIndex(Me.btnAceptar, 0)
		Me.Controls.SetChildIndex(Me.btnCopiar, 0)
		Me.Controls.SetChildIndex(Me.btnAplicar, 0)
		Me.Controls.SetChildIndex(Me.txtIdGrupo, 0)
		Me.Controls.SetChildIndex(Me.lblId, 0)
		Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
		Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
		Me.Controls.SetChildIndex(Me.lblCoidigoTipoAtributo, 0)
		Me.Controls.SetChildIndex(Me.bscCodigoTipoAtributo, 0)
		Me.Controls.SetChildIndex(Me.bscDescripcionTipoAtributo, 0)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents lblDescripcion As Controles.Label
	Friend WithEvents txtDescripcion As Controles.TextBox
	Friend WithEvents lblId As Controles.Label
	Friend WithEvents txtIdGrupo As Controles.TextBox
	Friend WithEvents bscDescripcionTipoAtributo As Controles.Buscador2
	Friend WithEvents bscCodigoTipoAtributo As Controles.Buscador2
	Friend WithEvents lblCoidigoTipoAtributo As Controles.Label
End Class
