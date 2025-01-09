<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalidadListasControlItemsDetalle
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
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtIdListaControlItem = New Eniac.Controles.TextBox()
      Me.lblIdListaControlItem = New Eniac.Controles.Label()
      Me.txtNombreListaControlItem = New Eniac.Controles.TextBox()
      Me.lblGrupo = New Eniac.Controles.Label()
        Me.lblSubGrupo = New Eniac.Controles.Label()
        Me.btnLimpiarProducto = New Eniac.Controles.Button()
        Me.lblNivelInspeccion = New Eniac.Controles.Label()
        Me.txtlblControlesRealizar = New Eniac.Controles.TextBox()
        Me.lblControlesRealizar = New Eniac.Controles.Label()
        Me.lblInfoAQL = New Eniac.Controles.Label()
        Me.lblAQL = New Eniac.Controles.Label()
        Me.txtAQL = New Eniac.Controles.TextBox()
        Me.cmbNivelInspeccion = New Eniac.Controles.ComboBox()
        Me.cmbSubGrupo = New Eniac.Controles.ComboBox()
        Me.cmbGrupo = New Eniac.Controles.ComboBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(380, 316)
        Me.btnAceptar.TabIndex = 16
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(466, 316)
        Me.btnCancelar.TabIndex = 17
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(279, 316)
        Me.btnCopiar.TabIndex = 19
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(219, 316)
        Me.btnAplicar.TabIndex = 18
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(12, 42)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtIdListaControlItem
        '
        Me.txtIdListaControlItem.BindearPropiedadControl = "Text"
        Me.txtIdListaControlItem.BindearPropiedadEntidad = "IdListaControlItem"
        Me.txtIdListaControlItem.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdListaControlItem.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdListaControlItem.Formato = ""
        Me.txtIdListaControlItem.IsDecimal = False
        Me.txtIdListaControlItem.IsNumber = False
        Me.txtIdListaControlItem.IsPK = True
        Me.txtIdListaControlItem.IsRequired = True
        Me.txtIdListaControlItem.Key = ""
        Me.txtIdListaControlItem.LabelAsoc = Me.lblIdListaControlItem
        Me.txtIdListaControlItem.Location = New System.Drawing.Point(119, 12)
        Me.txtIdListaControlItem.MaxLength = 6
        Me.txtIdListaControlItem.Name = "txtIdListaControlItem"
        Me.txtIdListaControlItem.Size = New System.Drawing.Size(59, 20)
        Me.txtIdListaControlItem.TabIndex = 1
        Me.txtIdListaControlItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdListaControlItem
        '
        Me.lblIdListaControlItem.AutoSize = True
        Me.lblIdListaControlItem.LabelAsoc = Nothing
        Me.lblIdListaControlItem.Location = New System.Drawing.Point(12, 16)
        Me.lblIdListaControlItem.Name = "lblIdListaControlItem"
        Me.lblIdListaControlItem.Size = New System.Drawing.Size(40, 13)
        Me.lblIdListaControlItem.TabIndex = 0
        Me.lblIdListaControlItem.Text = "Código"
        '
        'txtNombreListaControlItem
        '
        Me.txtNombreListaControlItem.BindearPropiedadControl = "Text"
        Me.txtNombreListaControlItem.BindearPropiedadEntidad = "NombreListaControlItem"
        Me.txtNombreListaControlItem.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreListaControlItem.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreListaControlItem.Formato = ""
        Me.txtNombreListaControlItem.IsDecimal = False
        Me.txtNombreListaControlItem.IsNumber = False
        Me.txtNombreListaControlItem.IsPK = False
        Me.txtNombreListaControlItem.IsRequired = True
        Me.txtNombreListaControlItem.Key = ""
        Me.txtNombreListaControlItem.LabelAsoc = Me.lblNombre
        Me.txtNombreListaControlItem.Location = New System.Drawing.Point(119, 38)
        Me.txtNombreListaControlItem.MaxLength = 100
        Me.txtNombreListaControlItem.Name = "txtNombreListaControlItem"
        Me.txtNombreListaControlItem.Size = New System.Drawing.Size(417, 20)
        Me.txtNombreListaControlItem.TabIndex = 3
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.LabelAsoc = Nothing
        Me.lblGrupo.Location = New System.Drawing.Point(12, 68)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(36, 13)
        Me.lblGrupo.TabIndex = 4
        Me.lblGrupo.Text = "Grupo"
        '
        'lblSubGrupo
        '
        Me.lblSubGrupo.AutoSize = True
        Me.lblSubGrupo.LabelAsoc = Nothing
        Me.lblSubGrupo.Location = New System.Drawing.Point(12, 95)
        Me.lblSubGrupo.Name = "lblSubGrupo"
        Me.lblSubGrupo.Size = New System.Drawing.Size(55, 13)
        Me.lblSubGrupo.TabIndex = 6
        Me.lblSubGrupo.Text = "SubGrupo"
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.Image = Global.Eniac.Win.My.Resources.Resources.refresh_16
        Me.btnLimpiarProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(304, 89)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnLimpiarProducto.TabIndex = 8
        Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'lblNivelInspeccion
        '
        Me.lblNivelInspeccion.AutoSize = True
        Me.lblNivelInspeccion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelInspeccion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNivelInspeccion.LabelAsoc = Nothing
        Me.lblNivelInspeccion.Location = New System.Drawing.Point(12, 122)
        Me.lblNivelInspeccion.Name = "lblNivelInspeccion"
        Me.lblNivelInspeccion.Size = New System.Drawing.Size(101, 13)
        Me.lblNivelInspeccion.TabIndex = 9
        Me.lblNivelInspeccion.Text = "Nivel de Inspección"
        '
        'txtlblControlesRealizar
        '
        Me.txtlblControlesRealizar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtlblControlesRealizar.BindearPropiedadControl = "Text"
        Me.txtlblControlesRealizar.BindearPropiedadEntidad = "Observacion"
        Me.txtlblControlesRealizar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtlblControlesRealizar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtlblControlesRealizar.Formato = ""
        Me.txtlblControlesRealizar.IsDecimal = False
        Me.txtlblControlesRealizar.IsNumber = False
        Me.txtlblControlesRealizar.IsPK = False
        Me.txtlblControlesRealizar.IsRequired = False
        Me.txtlblControlesRealizar.Key = ""
        Me.txtlblControlesRealizar.LabelAsoc = Me.lblControlesRealizar
        Me.txtlblControlesRealizar.Location = New System.Drawing.Point(119, 145)
        Me.txtlblControlesRealizar.MaxLength = 60
        Me.txtlblControlesRealizar.Multiline = True
        Me.txtlblControlesRealizar.Name = "txtlblControlesRealizar"
        Me.txtlblControlesRealizar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtlblControlesRealizar.Size = New System.Drawing.Size(417, 161)
        Me.txtlblControlesRealizar.TabIndex = 15
        '
        'lblControlesRealizar
        '
        Me.lblControlesRealizar.AutoSize = True
        Me.lblControlesRealizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblControlesRealizar.LabelAsoc = Nothing
        Me.lblControlesRealizar.Location = New System.Drawing.Point(12, 148)
        Me.lblControlesRealizar.Name = "lblControlesRealizar"
        Me.lblControlesRealizar.Size = New System.Drawing.Size(78, 13)
        Me.lblControlesRealizar.TabIndex = 14
        Me.lblControlesRealizar.Text = "Observaciones"
        '
        'lblInfoAQL
        '
        Me.lblInfoAQL.AutoSize = True
        Me.lblInfoAQL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInfoAQL.LabelAsoc = Nothing
        Me.lblInfoAQL.Location = New System.Drawing.Point(304, 122)
        Me.lblInfoAQL.Name = "lblInfoAQL"
        Me.lblInfoAQL.Size = New System.Drawing.Size(15, 13)
        Me.lblInfoAQL.TabIndex = 13
        Me.lblInfoAQL.Text = "%"
        '
        'lblAQL
        '
        Me.lblAQL.AutoSize = True
        Me.lblAQL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAQL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAQL.LabelAsoc = Nothing
        Me.lblAQL.Location = New System.Drawing.Point(184, 122)
        Me.lblAQL.Name = "lblAQL"
        Me.lblAQL.Size = New System.Drawing.Size(37, 13)
        Me.lblAQL.TabIndex = 11
        Me.lblAQL.Text = "A.Q.L."
        '
        'txtAQL
        '
        Me.txtAQL.BindearPropiedadControl = "Text"
        Me.txtAQL.BindearPropiedadEntidad = "ValorAQL"
        Me.txtAQL.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAQL.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAQL.Formato = "N2"
        Me.txtAQL.IsDecimal = True
        Me.txtAQL.IsNumber = True
        Me.txtAQL.IsPK = False
        Me.txtAQL.IsRequired = False
        Me.txtAQL.Key = ""
        Me.txtAQL.LabelAsoc = Me.lblAQL
        Me.txtAQL.Location = New System.Drawing.Point(227, 118)
        Me.txtAQL.MaxLength = 7
        Me.txtAQL.Name = "txtAQL"
        Me.txtAQL.Size = New System.Drawing.Size(71, 20)
        Me.txtAQL.TabIndex = 12
        Me.txtAQL.Text = "0,00"
        Me.txtAQL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbNivelInspeccion
        '
        Me.cmbNivelInspeccion.BindearPropiedadControl = "SelectedValue"
        Me.cmbNivelInspeccion.BindearPropiedadEntidad = "NivelInspeccion"
        Me.cmbNivelInspeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivelInspeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbNivelInspeccion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbNivelInspeccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbNivelInspeccion.FormattingEnabled = True
        Me.cmbNivelInspeccion.IsPK = False
        Me.cmbNivelInspeccion.IsRequired = False
        Me.cmbNivelInspeccion.Key = Nothing
        Me.cmbNivelInspeccion.LabelAsoc = Nothing
        Me.cmbNivelInspeccion.Location = New System.Drawing.Point(119, 118)
        Me.cmbNivelInspeccion.Name = "cmbNivelInspeccion"
        Me.cmbNivelInspeccion.Size = New System.Drawing.Size(59, 21)
        Me.cmbNivelInspeccion.TabIndex = 10
        '
        'cmbSubGrupo
        '
        Me.cmbSubGrupo.BindearPropiedadControl = "SelectedValue"
        Me.cmbSubGrupo.BindearPropiedadEntidad = "SubGrupo.IdListaControlItemSubGrupo"
        Me.cmbSubGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubGrupo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubGrupo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubGrupo.FormattingEnabled = True
        Me.cmbSubGrupo.IsPK = False
        Me.cmbSubGrupo.IsRequired = False
        Me.cmbSubGrupo.Key = Nothing
        Me.cmbSubGrupo.LabelAsoc = Me.lblSubGrupo
        Me.cmbSubGrupo.Location = New System.Drawing.Point(119, 91)
        Me.cmbSubGrupo.Name = "cmbSubGrupo"
        Me.cmbSubGrupo.Size = New System.Drawing.Size(179, 21)
        Me.cmbSubGrupo.TabIndex = 7
        '
        'cmbGrupo
        '
        Me.cmbGrupo.BindearPropiedadControl = "SelectedValue"
        Me.cmbGrupo.BindearPropiedadEntidad = "Grupo.IdListaControlItemGrupo"
        Me.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrupo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.IsPK = False
        Me.cmbGrupo.IsRequired = True
        Me.cmbGrupo.Key = Nothing
        Me.cmbGrupo.LabelAsoc = Me.lblGrupo
        Me.cmbGrupo.Location = New System.Drawing.Point(119, 64)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(179, 21)
        Me.cmbGrupo.TabIndex = 5
        '
        'CalidadListasControlItemsDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 351)
        Me.Controls.Add(Me.cmbNivelInspeccion)
        Me.Controls.Add(Me.lblNivelInspeccion)
        Me.Controls.Add(Me.txtlblControlesRealizar)
        Me.Controls.Add(Me.lblControlesRealizar)
        Me.Controls.Add(Me.lblInfoAQL)
        Me.Controls.Add(Me.lblAQL)
        Me.Controls.Add(Me.txtAQL)
        Me.Controls.Add(Me.btnLimpiarProducto)
        Me.Controls.Add(Me.lblSubGrupo)
        Me.Controls.Add(Me.cmbSubGrupo)
        Me.Controls.Add(Me.lblGrupo)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.txtNombreListaControlItem)
        Me.Controls.Add(Me.txtIdListaControlItem)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblIdListaControlItem)
        Me.Name = "CalidadListasControlItemsDetalle"
        Me.Text = "Items Listas de Control"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.lblIdListaControlItem, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtIdListaControlItem, 0)
        Me.Controls.SetChildIndex(Me.txtNombreListaControlItem, 0)
        Me.Controls.SetChildIndex(Me.cmbGrupo, 0)
        Me.Controls.SetChildIndex(Me.lblGrupo, 0)
        Me.Controls.SetChildIndex(Me.cmbSubGrupo, 0)
        Me.Controls.SetChildIndex(Me.lblSubGrupo, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiarProducto, 0)
        Me.Controls.SetChildIndex(Me.txtAQL, 0)
        Me.Controls.SetChildIndex(Me.lblAQL, 0)
        Me.Controls.SetChildIndex(Me.lblInfoAQL, 0)
        Me.Controls.SetChildIndex(Me.lblControlesRealizar, 0)
        Me.Controls.SetChildIndex(Me.txtlblControlesRealizar, 0)
        Me.Controls.SetChildIndex(Me.lblNivelInspeccion, 0)
        Me.Controls.SetChildIndex(Me.cmbNivelInspeccion, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtIdListaControlItem As Eniac.Controles.TextBox
   Friend WithEvents lblIdListaControlItem As Eniac.Controles.Label
   Friend WithEvents txtNombreListaControlItem As Eniac.Controles.TextBox
   Friend WithEvents lblGrupo As Eniac.Controles.Label
   Friend WithEvents cmbGrupo As Eniac.Controles.ComboBox
   Friend WithEvents lblSubGrupo As Eniac.Controles.Label
   Friend WithEvents cmbSubGrupo As Eniac.Controles.ComboBox
   Friend WithEvents btnLimpiarProducto As Eniac.Controles.Button
    Friend WithEvents cmbNivelInspeccion As Controles.ComboBox
    Friend WithEvents lblNivelInspeccion As Controles.Label
    Friend WithEvents txtlblControlesRealizar As Controles.TextBox
    Friend WithEvents lblControlesRealizar As Controles.Label
    Friend WithEvents lblInfoAQL As Controles.Label
    Friend WithEvents lblAQL As Controles.Label
    Friend WithEvents txtAQL As Controles.TextBox
End Class
