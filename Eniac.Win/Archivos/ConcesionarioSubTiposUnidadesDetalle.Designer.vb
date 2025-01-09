<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConcesionarioSubTiposUnidadesDetalle
    Inherits Win.BaseDetalle

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
        Me.lblUnidad = New Eniac.Controles.Label()
        Me.bscUnidad = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtNombreSubUnidad = New Eniac.Controles.TextBox()
        Me.lblIdSubUnidad = New Eniac.Controles.Label()
        Me.lblDescripcion = New Eniac.Controles.Label()
        Me.txtDescripcionSubUnidad = New Eniac.Controles.TextBox()
        Me.radBtnSolCantPuertasLat = New Eniac.Controles.RadioButton()
        Me.radBtnSolCantPisos = New Eniac.Controles.RadioButton()
        Me.radBtnSolVolumen = New Eniac.Controles.RadioButton()
        Me.radBtnNoSolicita = New Eniac.Controles.RadioButton()
        Me.bscCodigoUnidad = New Eniac.Controles.Buscador2()
        Me.txtIdSubUnidad = New Eniac.Controles.TextBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(325, 225)
        Me.btnAceptar.TabIndex = 13
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(411, 225)
        Me.btnCancelar.TabIndex = 14
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(224, 225)
        Me.btnCopiar.TabIndex = 16
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(167, 225)
        Me.btnAplicar.TabIndex = 15
        '
        'lblUnidad
        '
        Me.lblUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblUnidad.AutoSize = True
        Me.lblUnidad.LabelAsoc = Nothing
        Me.lblUnidad.Location = New System.Drawing.Point(11, 16)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(41, 13)
        Me.lblUnidad.TabIndex = 0
        Me.lblUnidad.Text = "Unidad"
        '
        'bscUnidad
        '
        Me.bscUnidad.ActivarFiltroEnGrilla = True
        Me.bscUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscUnidad.BindearPropiedadControl = ""
        Me.bscUnidad.BindearPropiedadEntidad = ""
        Me.bscUnidad.ConfigBuscador = Nothing
        Me.bscUnidad.Datos = Nothing
        Me.bscUnidad.FilaDevuelta = Nothing
        Me.bscUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscUnidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscUnidad.IsDecimal = False
        Me.bscUnidad.IsNumber = False
        Me.bscUnidad.IsPK = False
        Me.bscUnidad.IsRequired = True
        Me.bscUnidad.Key = ""
        Me.bscUnidad.LabelAsoc = Me.lblUnidad
        Me.bscUnidad.Location = New System.Drawing.Point(177, 16)
        Me.bscUnidad.MaxLengh = "32767"
        Me.bscUnidad.Name = "bscUnidad"
        Me.bscUnidad.Permitido = True
        Me.bscUnidad.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscUnidad.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscUnidad.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscUnidad.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscUnidad.Selecciono = False
        Me.bscUnidad.Size = New System.Drawing.Size(312, 20)
        Me.bscUnidad.TabIndex = 2
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(11, 76)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombreSubUnidad
        '
        Me.txtNombreSubUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNombreSubUnidad.BindearPropiedadControl = "Text"
        Me.txtNombreSubUnidad.BindearPropiedadEntidad = "NombreSubTipoUnidad"
        Me.txtNombreSubUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreSubUnidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreSubUnidad.Formato = ""
        Me.txtNombreSubUnidad.IsDecimal = False
        Me.txtNombreSubUnidad.IsNumber = False
        Me.txtNombreSubUnidad.IsPK = False
        Me.txtNombreSubUnidad.IsRequired = True
        Me.txtNombreSubUnidad.Key = ""
        Me.txtNombreSubUnidad.LabelAsoc = Me.lblNombre
        Me.txtNombreSubUnidad.Location = New System.Drawing.Point(80, 73)
        Me.txtNombreSubUnidad.MaxLength = 50
        Me.txtNombreSubUnidad.Name = "txtNombreSubUnidad"
        Me.txtNombreSubUnidad.Size = New System.Drawing.Size(409, 20)
        Me.txtNombreSubUnidad.TabIndex = 6
        '
        'lblIdSubUnidad
        '
        Me.lblIdSubUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdSubUnidad.AutoSize = True
        Me.lblIdSubUnidad.LabelAsoc = Nothing
        Me.lblIdSubUnidad.Location = New System.Drawing.Point(11, 48)
        Me.lblIdSubUnidad.Name = "lblIdSubUnidad"
        Me.lblIdSubUnidad.Size = New System.Drawing.Size(40, 13)
        Me.lblIdSubUnidad.TabIndex = 3
        Me.lblIdSubUnidad.Text = "Código"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(11, 102)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 7
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcionSubUnidad
        '
        Me.txtDescripcionSubUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtDescripcionSubUnidad.BindearPropiedadControl = "Text"
        Me.txtDescripcionSubUnidad.BindearPropiedadEntidad = "DescripcionSubTipoUnidad"
        Me.txtDescripcionSubUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcionSubUnidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcionSubUnidad.Formato = ""
        Me.txtDescripcionSubUnidad.IsDecimal = False
        Me.txtDescripcionSubUnidad.IsNumber = False
        Me.txtDescripcionSubUnidad.IsPK = False
        Me.txtDescripcionSubUnidad.IsRequired = False
        Me.txtDescripcionSubUnidad.Key = ""
        Me.txtDescripcionSubUnidad.LabelAsoc = Me.lblDescripcion
        Me.txtDescripcionSubUnidad.Location = New System.Drawing.Point(80, 99)
        Me.txtDescripcionSubUnidad.MaxLength = 50
        Me.txtDescripcionSubUnidad.Name = "txtDescripcionSubUnidad"
        Me.txtDescripcionSubUnidad.Size = New System.Drawing.Size(409, 20)
        Me.txtDescripcionSubUnidad.TabIndex = 8
        '
        'radBtnSolCantPuertasLat
        '
        Me.radBtnSolCantPuertasLat.AutoSize = True
        Me.radBtnSolCantPuertasLat.BindearPropiedadControl = ""
        Me.radBtnSolCantPuertasLat.BindearPropiedadEntidad = ""
        Me.radBtnSolCantPuertasLat.ForeColorFocus = System.Drawing.Color.Red
        Me.radBtnSolCantPuertasLat.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.radBtnSolCantPuertasLat.IsPK = False
        Me.radBtnSolCantPuertasLat.IsRequired = False
        Me.radBtnSolCantPuertasLat.Key = Nothing
        Me.radBtnSolCantPuertasLat.LabelAsoc = Nothing
        Me.radBtnSolCantPuertasLat.Location = New System.Drawing.Point(80, 153)
        Me.radBtnSolCantPuertasLat.Name = "radBtnSolCantPuertasLat"
        Me.radBtnSolCantPuertasLat.Size = New System.Drawing.Size(204, 17)
        Me.radBtnSolCantPuertasLat.TabIndex = 10
        Me.radBtnSolCantPuertasLat.Text = "Solicita Cantidad de Puertas Laterales"
        Me.radBtnSolCantPuertasLat.UseVisualStyleBackColor = True
        '
        'radBtnSolCantPisos
        '
        Me.radBtnSolCantPisos.AutoSize = True
        Me.radBtnSolCantPisos.BindearPropiedadControl = ""
        Me.radBtnSolCantPisos.BindearPropiedadEntidad = ""
        Me.radBtnSolCantPisos.ForeColorFocus = System.Drawing.Color.Red
        Me.radBtnSolCantPisos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.radBtnSolCantPisos.IsPK = False
        Me.radBtnSolCantPisos.IsRequired = False
        Me.radBtnSolCantPisos.Key = Nothing
        Me.radBtnSolCantPisos.LabelAsoc = Nothing
        Me.radBtnSolCantPisos.Location = New System.Drawing.Point(80, 177)
        Me.radBtnSolCantPisos.Name = "radBtnSolCantPisos"
        Me.radBtnSolCantPisos.Size = New System.Drawing.Size(147, 17)
        Me.radBtnSolCantPisos.TabIndex = 11
        Me.radBtnSolCantPisos.Text = "Solicita Cantidad de Pisos"
        Me.radBtnSolCantPisos.UseVisualStyleBackColor = True
        '
        'radBtnSolVolumen
        '
        Me.radBtnSolVolumen.AutoSize = True
        Me.radBtnSolVolumen.BindearPropiedadControl = ""
        Me.radBtnSolVolumen.BindearPropiedadEntidad = ""
        Me.radBtnSolVolumen.ForeColorFocus = System.Drawing.Color.Red
        Me.radBtnSolVolumen.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.radBtnSolVolumen.IsPK = False
        Me.radBtnSolVolumen.IsRequired = False
        Me.radBtnSolVolumen.Key = Nothing
        Me.radBtnSolVolumen.LabelAsoc = Nothing
        Me.radBtnSolVolumen.Location = New System.Drawing.Point(80, 200)
        Me.radBtnSolVolumen.Name = "radBtnSolVolumen"
        Me.radBtnSolVolumen.Size = New System.Drawing.Size(103, 17)
        Me.radBtnSolVolumen.TabIndex = 12
        Me.radBtnSolVolumen.Text = "Solicita Volumen"
        Me.radBtnSolVolumen.UseVisualStyleBackColor = True
        '
        'radBtnNoSolicita
        '
        Me.radBtnNoSolicita.AutoSize = True
        Me.radBtnNoSolicita.BindearPropiedadControl = ""
        Me.radBtnNoSolicita.BindearPropiedadEntidad = ""
        Me.radBtnNoSolicita.Checked = True
        Me.radBtnNoSolicita.ForeColorFocus = System.Drawing.Color.Red
        Me.radBtnNoSolicita.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.radBtnNoSolicita.IsPK = False
        Me.radBtnNoSolicita.IsRequired = False
        Me.radBtnNoSolicita.Key = Nothing
        Me.radBtnNoSolicita.LabelAsoc = Nothing
        Me.radBtnNoSolicita.Location = New System.Drawing.Point(80, 130)
        Me.radBtnNoSolicita.Name = "radBtnNoSolicita"
        Me.radBtnNoSolicita.Size = New System.Drawing.Size(76, 17)
        Me.radBtnNoSolicita.TabIndex = 9
        Me.radBtnNoSolicita.TabStop = True
        Me.radBtnNoSolicita.Text = "No Solicita"
        Me.radBtnNoSolicita.UseVisualStyleBackColor = True
        '
        'bscCodigoUnidad
        '
        Me.bscCodigoUnidad.ActivarFiltroEnGrilla = True
        Me.bscCodigoUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscCodigoUnidad.BindearPropiedadControl = "Text"
        Me.bscCodigoUnidad.BindearPropiedadEntidad = "IdTipoUnidad"
        Me.bscCodigoUnidad.ConfigBuscador = Nothing
        Me.bscCodigoUnidad.Datos = Nothing
        Me.bscCodigoUnidad.FilaDevuelta = Nothing
        Me.bscCodigoUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoUnidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoUnidad.IsDecimal = False
        Me.bscCodigoUnidad.IsNumber = True
        Me.bscCodigoUnidad.IsPK = False
        Me.bscCodigoUnidad.IsRequired = True
        Me.bscCodigoUnidad.Key = ""
        Me.bscCodigoUnidad.LabelAsoc = Me.lblUnidad
        Me.bscCodigoUnidad.Location = New System.Drawing.Point(80, 16)
        Me.bscCodigoUnidad.MaxLengh = "32767"
        Me.bscCodigoUnidad.Name = "bscCodigoUnidad"
        Me.bscCodigoUnidad.Permitido = True
        Me.bscCodigoUnidad.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoUnidad.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoUnidad.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoUnidad.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoUnidad.Selecciono = False
        Me.bscCodigoUnidad.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoUnidad.TabIndex = 1
        '
        'txtIdSubUnidad
        '
        Me.txtIdSubUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtIdSubUnidad.BindearPropiedadControl = "Text"
        Me.txtIdSubUnidad.BindearPropiedadEntidad = "IdSubTipoUnidad"
        Me.txtIdSubUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSubUnidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSubUnidad.Formato = ""
        Me.txtIdSubUnidad.IsDecimal = False
        Me.txtIdSubUnidad.IsNumber = True
        Me.txtIdSubUnidad.IsPK = True
        Me.txtIdSubUnidad.IsRequired = True
        Me.txtIdSubUnidad.Key = ""
        Me.txtIdSubUnidad.LabelAsoc = Me.lblIdSubUnidad
        Me.txtIdSubUnidad.Location = New System.Drawing.Point(80, 45)
        Me.txtIdSubUnidad.MaxLength = 4
        Me.txtIdSubUnidad.Name = "txtIdSubUnidad"
        Me.txtIdSubUnidad.Size = New System.Drawing.Size(77, 20)
        Me.txtIdSubUnidad.TabIndex = 4
        Me.txtIdSubUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ConcesionarioSubTiposUnidadesDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 267)
        Me.Controls.Add(Me.txtIdSubUnidad)
        Me.Controls.Add(Me.bscCodigoUnidad)
        Me.Controls.Add(Me.radBtnNoSolicita)
        Me.Controls.Add(Me.radBtnSolCantPuertasLat)
        Me.Controls.Add(Me.radBtnSolVolumen)
        Me.Controls.Add(Me.radBtnSolCantPisos)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtDescripcionSubUnidad)
        Me.Controls.Add(Me.lblUnidad)
        Me.Controls.Add(Me.bscUnidad)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombreSubUnidad)
        Me.Controls.Add(Me.lblIdSubUnidad)
        Me.Name = "ConcesionarioSubTiposUnidadesDetalle"
        Me.Text = "SubUnidad"
        Me.Controls.SetChildIndex(Me.lblIdSubUnidad, 0)
        Me.Controls.SetChildIndex(Me.txtNombreSubUnidad, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.bscUnidad, 0)
        Me.Controls.SetChildIndex(Me.lblUnidad, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcionSubUnidad, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.radBtnSolCantPisos, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.radBtnSolVolumen, 0)
        Me.Controls.SetChildIndex(Me.radBtnSolCantPuertasLat, 0)
        Me.Controls.SetChildIndex(Me.radBtnNoSolicita, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoUnidad, 0)
        Me.Controls.SetChildIndex(Me.txtIdSubUnidad, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblUnidad As Controles.Label
    Friend WithEvents bscUnidad As Controles.Buscador2
    Friend WithEvents lblNombre As Controles.Label
    Friend WithEvents txtNombreSubUnidad As Controles.TextBox
    Friend WithEvents lblIdSubUnidad As Controles.Label
    Friend WithEvents lblDescripcion As Controles.Label
    Friend WithEvents txtDescripcionSubUnidad As Controles.TextBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents radBtnSolCantPuertasLat As Controles.RadioButton
    Friend WithEvents radBtnSolCantPisos As Controles.RadioButton
    Friend WithEvents radBtnSolVolumen As Controles.RadioButton
    Friend WithEvents radBtnNoSolicita As Controles.RadioButton
    Friend WithEvents bscCodigoUnidad As Controles.Buscador2
    Friend WithEvents txtIdSubUnidad As Controles.TextBox
End Class
