<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormatosEtiquetasDetalle
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
      Me.lblNombreFormatoEtiqueta = New Eniac.Controles.Label()
      Me.txtNombreFormatoEtiqueta = New Eniac.Controles.TextBox()
      Me.lblIdFormatoEtiqueta = New Eniac.Controles.Label()
      Me.txtIdFormatoEtiqueta = New Eniac.Controles.TextBox()
      Me.lblArchivoAImprimir = New Eniac.Controles.Label()
      Me.txtArchivoAImprimir = New Eniac.Controles.TextBox()
      Me.lblTipo = New Eniac.Controles.Label()
      Me.cmbTipo = New Eniac.Controles.ComboBox()
      Me.cmbNombreImpresora = New Eniac.Controles.ComboBox()
      Me.lblNombreImpresora = New Eniac.Controles.Label()
      Me.chbArchivoEmbebido = New Eniac.Controles.CheckBox()
      Me.chbImprimeLote = New Eniac.Controles.CheckBox()
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.lblMaximoColumnas = New Eniac.Controles.Label()
      Me.txtMaximoColumnas = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(345, 177)
      Me.btnAceptar.TabIndex = 14
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(431, 177)
      Me.btnCancelar.TabIndex = 15
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(244, 177)
      Me.btnCopiar.TabIndex = 17
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(187, 177)
      Me.btnAplicar.TabIndex = 16
      '
      'lblNombreFormatoEtiqueta
      '
      Me.lblNombreFormatoEtiqueta.AutoSize = True
      Me.lblNombreFormatoEtiqueta.LabelAsoc = Nothing
      Me.lblNombreFormatoEtiqueta.Location = New System.Drawing.Point(19, 42)
      Me.lblNombreFormatoEtiqueta.Name = "lblNombreFormatoEtiqueta"
      Me.lblNombreFormatoEtiqueta.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreFormatoEtiqueta.TabIndex = 2
      Me.lblNombreFormatoEtiqueta.Text = "Nombre"
      '
      'txtNombreFormatoEtiqueta
      '
      Me.txtNombreFormatoEtiqueta.BindearPropiedadControl = "Text"
      Me.txtNombreFormatoEtiqueta.BindearPropiedadEntidad = "NombreFormatoEtiqueta"
      Me.txtNombreFormatoEtiqueta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreFormatoEtiqueta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreFormatoEtiqueta.Formato = ""
      Me.txtNombreFormatoEtiqueta.IsDecimal = False
      Me.txtNombreFormatoEtiqueta.IsNumber = False
      Me.txtNombreFormatoEtiqueta.IsPK = False
      Me.txtNombreFormatoEtiqueta.IsRequired = False
      Me.txtNombreFormatoEtiqueta.Key = ""
      Me.txtNombreFormatoEtiqueta.LabelAsoc = Me.lblNombreFormatoEtiqueta
      Me.txtNombreFormatoEtiqueta.Location = New System.Drawing.Point(116, 38)
      Me.txtNombreFormatoEtiqueta.MaxLength = 30
      Me.txtNombreFormatoEtiqueta.Name = "txtNombreFormatoEtiqueta"
      Me.txtNombreFormatoEtiqueta.Size = New System.Drawing.Size(372, 20)
      Me.txtNombreFormatoEtiqueta.TabIndex = 3
      '
      'lblIdFormatoEtiqueta
      '
      Me.lblIdFormatoEtiqueta.AutoSize = True
      Me.lblIdFormatoEtiqueta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblIdFormatoEtiqueta.LabelAsoc = Nothing
      Me.lblIdFormatoEtiqueta.Location = New System.Drawing.Point(19, 15)
      Me.lblIdFormatoEtiqueta.Name = "lblIdFormatoEtiqueta"
      Me.lblIdFormatoEtiqueta.Size = New System.Drawing.Size(40, 13)
      Me.lblIdFormatoEtiqueta.TabIndex = 0
      Me.lblIdFormatoEtiqueta.Text = "Código"
      '
      'txtIdFormatoEtiqueta
      '
      Me.txtIdFormatoEtiqueta.BindearPropiedadControl = "Text"
      Me.txtIdFormatoEtiqueta.BindearPropiedadEntidad = "IdFormatoEtiqueta"
      Me.txtIdFormatoEtiqueta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdFormatoEtiqueta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdFormatoEtiqueta.Formato = ""
      Me.txtIdFormatoEtiqueta.IsDecimal = False
      Me.txtIdFormatoEtiqueta.IsNumber = True
      Me.txtIdFormatoEtiqueta.IsPK = True
      Me.txtIdFormatoEtiqueta.IsRequired = True
      Me.txtIdFormatoEtiqueta.Key = ""
      Me.txtIdFormatoEtiqueta.LabelAsoc = Me.lblIdFormatoEtiqueta
      Me.txtIdFormatoEtiqueta.Location = New System.Drawing.Point(116, 12)
      Me.txtIdFormatoEtiqueta.MaxLength = 10
      Me.txtIdFormatoEtiqueta.Name = "txtIdFormatoEtiqueta"
      Me.txtIdFormatoEtiqueta.Size = New System.Drawing.Size(54, 20)
      Me.txtIdFormatoEtiqueta.TabIndex = 1
      Me.txtIdFormatoEtiqueta.Text = "0"
      Me.txtIdFormatoEtiqueta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblArchivoAImprimir
      '
      Me.lblArchivoAImprimir.AutoSize = True
      Me.lblArchivoAImprimir.LabelAsoc = Nothing
      Me.lblArchivoAImprimir.Location = New System.Drawing.Point(19, 95)
      Me.lblArchivoAImprimir.Name = "lblArchivoAImprimir"
      Me.lblArchivoAImprimir.Size = New System.Drawing.Size(91, 13)
      Me.lblArchivoAImprimir.TabIndex = 8
      Me.lblArchivoAImprimir.Text = "Archivo A Imprimir"
      '
      'txtArchivoAImprimir
      '
      Me.txtArchivoAImprimir.BindearPropiedadControl = "Text"
      Me.txtArchivoAImprimir.BindearPropiedadEntidad = "ArchivoAImprimir"
      Me.txtArchivoAImprimir.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoAImprimir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoAImprimir.Formato = ""
      Me.txtArchivoAImprimir.IsDecimal = False
      Me.txtArchivoAImprimir.IsNumber = False
      Me.txtArchivoAImprimir.IsPK = False
      Me.txtArchivoAImprimir.IsRequired = False
      Me.txtArchivoAImprimir.Key = ""
      Me.txtArchivoAImprimir.LabelAsoc = Me.lblArchivoAImprimir
      Me.txtArchivoAImprimir.Location = New System.Drawing.Point(116, 91)
      Me.txtArchivoAImprimir.MaxLength = 100
      Me.txtArchivoAImprimir.Name = "txtArchivoAImprimir"
      Me.txtArchivoAImprimir.Size = New System.Drawing.Size(293, 20)
      Me.txtArchivoAImprimir.TabIndex = 9
      '
      'lblTipo
      '
      Me.lblTipo.AutoSize = True
      Me.lblTipo.LabelAsoc = Nothing
      Me.lblTipo.Location = New System.Drawing.Point(19, 67)
      Me.lblTipo.Name = "lblTipo"
      Me.lblTipo.Size = New System.Drawing.Size(28, 13)
      Me.lblTipo.TabIndex = 4
      Me.lblTipo.Text = "Tipo"
      '
      'cmbTipo
      '
      Me.cmbTipo.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipo.BindearPropiedadEntidad = "Tipo"
      Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipo.FormattingEnabled = True
      Me.cmbTipo.IsPK = False
      Me.cmbTipo.IsRequired = False
      Me.cmbTipo.Key = Nothing
      Me.cmbTipo.LabelAsoc = Me.lblTipo
      Me.cmbTipo.Location = New System.Drawing.Point(116, 64)
      Me.cmbTipo.Name = "cmbTipo"
      Me.cmbTipo.Size = New System.Drawing.Size(155, 21)
      Me.cmbTipo.TabIndex = 5
      '
      'cmbNombreImpresora
      '
      Me.cmbNombreImpresora.BindearPropiedadControl = "SelectedItem"
      Me.cmbNombreImpresora.BindearPropiedadEntidad = "NombreImpresora"
      Me.cmbNombreImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNombreImpresora.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNombreImpresora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNombreImpresora.FormattingEnabled = True
      Me.cmbNombreImpresora.IsPK = False
      Me.cmbNombreImpresora.IsRequired = False
      Me.cmbNombreImpresora.Key = Nothing
      Me.cmbNombreImpresora.LabelAsoc = Me.lblNombreImpresora
      Me.cmbNombreImpresora.Location = New System.Drawing.Point(116, 117)
      Me.cmbNombreImpresora.Name = "cmbNombreImpresora"
      Me.cmbNombreImpresora.Size = New System.Drawing.Size(293, 21)
      Me.cmbNombreImpresora.TabIndex = 12
      '
      'lblNombreImpresora
      '
      Me.lblNombreImpresora.AutoSize = True
      Me.lblNombreImpresora.LabelAsoc = Nothing
      Me.lblNombreImpresora.Location = New System.Drawing.Point(19, 120)
      Me.lblNombreImpresora.Name = "lblNombreImpresora"
      Me.lblNombreImpresora.Size = New System.Drawing.Size(53, 13)
      Me.lblNombreImpresora.TabIndex = 11
      Me.lblNombreImpresora.Text = "Impresora"
      '
      'chbArchivoEmbebido
      '
      Me.chbArchivoEmbebido.AutoSize = True
      Me.chbArchivoEmbebido.BindearPropiedadControl = "Checked"
      Me.chbArchivoEmbebido.BindearPropiedadEntidad = "ArchivoAImprimirEmbebido"
      Me.chbArchivoEmbebido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbArchivoEmbebido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbArchivoEmbebido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbArchivoEmbebido.IsPK = False
      Me.chbArchivoEmbebido.IsRequired = False
      Me.chbArchivoEmbebido.Key = Nothing
      Me.chbArchivoEmbebido.LabelAsoc = Nothing
      Me.chbArchivoEmbebido.Location = New System.Drawing.Point(415, 93)
      Me.chbArchivoEmbebido.Name = "chbArchivoEmbebido"
      Me.chbArchivoEmbebido.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbArchivoEmbebido.Size = New System.Drawing.Size(73, 17)
      Me.chbArchivoEmbebido.TabIndex = 10
      Me.chbArchivoEmbebido.Text = "Embebido"
      Me.chbArchivoEmbebido.UseVisualStyleBackColor = True
      '
      'chbImprimeLote
      '
      Me.chbImprimeLote.AutoSize = True
      Me.chbImprimeLote.BindearPropiedadControl = "Checked"
      Me.chbImprimeLote.BindearPropiedadEntidad = "ImprimeLote"
      Me.chbImprimeLote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbImprimeLote.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImprimeLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImprimeLote.IsPK = False
      Me.chbImprimeLote.IsRequired = False
      Me.chbImprimeLote.Key = Nothing
      Me.chbImprimeLote.LabelAsoc = Nothing
      Me.chbImprimeLote.Location = New System.Drawing.Point(116, 144)
      Me.chbImprimeLote.Name = "chbImprimeLote"
      Me.chbImprimeLote.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbImprimeLote.Size = New System.Drawing.Size(73, 17)
      Me.chbImprimeLote.TabIndex = 13
      Me.chbImprimeLote.Text = "Embebido"
      Me.chbImprimeLote.UseVisualStyleBackColor = True
      '
      'chbActivo
      '
      Me.chbActivo.AutoSize = True
      Me.chbActivo.BindearPropiedadControl = "Checked"
      Me.chbActivo.BindearPropiedadEntidad = "Activo"
      Me.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbActivo.IsPK = False
      Me.chbActivo.IsRequired = False
      Me.chbActivo.Key = Nothing
      Me.chbActivo.LabelAsoc = Nothing
      Me.chbActivo.Location = New System.Drawing.Point(415, 15)
      Me.chbActivo.Name = "chbActivo"
      Me.chbActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbActivo.Size = New System.Drawing.Size(56, 17)
      Me.chbActivo.TabIndex = 18
      Me.chbActivo.Text = "Activo"
      Me.chbActivo.UseVisualStyleBackColor = True
      '
      'lblMaximoColumnas
      '
      Me.lblMaximoColumnas.AutoSize = True
      Me.lblMaximoColumnas.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMaximoColumnas.LabelAsoc = Nothing
      Me.lblMaximoColumnas.Location = New System.Drawing.Point(274, 68)
      Me.lblMaximoColumnas.Name = "lblMaximoColumnas"
      Me.lblMaximoColumnas.Size = New System.Drawing.Size(79, 13)
      Me.lblMaximoColumnas.TabIndex = 6
      Me.lblMaximoColumnas.Text = "Max. Columnas"
      '
      'txtMaximoColumnas
      '
      Me.txtMaximoColumnas.BindearPropiedadControl = "Text"
      Me.txtMaximoColumnas.BindearPropiedadEntidad = "MaximoColumnas"
      Me.txtMaximoColumnas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMaximoColumnas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMaximoColumnas.Formato = ""
      Me.txtMaximoColumnas.IsDecimal = False
      Me.txtMaximoColumnas.IsNumber = True
      Me.txtMaximoColumnas.IsPK = False
      Me.txtMaximoColumnas.IsRequired = True
      Me.txtMaximoColumnas.Key = ""
      Me.txtMaximoColumnas.LabelAsoc = Me.lblMaximoColumnas
      Me.txtMaximoColumnas.Location = New System.Drawing.Point(355, 65)
      Me.txtMaximoColumnas.MaxLength = 10
      Me.txtMaximoColumnas.Name = "txtMaximoColumnas"
      Me.txtMaximoColumnas.Size = New System.Drawing.Size(54, 20)
      Me.txtMaximoColumnas.TabIndex = 7
      Me.txtMaximoColumnas.Text = "0"
      Me.txtMaximoColumnas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'FormatosEtiquetasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(520, 212)
      Me.Controls.Add(Me.lblMaximoColumnas)
      Me.Controls.Add(Me.txtMaximoColumnas)
      Me.Controls.Add(Me.chbActivo)
      Me.Controls.Add(Me.chbImprimeLote)
      Me.Controls.Add(Me.chbArchivoEmbebido)
      Me.Controls.Add(Me.cmbNombreImpresora)
      Me.Controls.Add(Me.lblNombreImpresora)
      Me.Controls.Add(Me.lblTipo)
      Me.Controls.Add(Me.cmbTipo)
      Me.Controls.Add(Me.lblArchivoAImprimir)
      Me.Controls.Add(Me.txtArchivoAImprimir)
      Me.Controls.Add(Me.lblNombreFormatoEtiqueta)
      Me.Controls.Add(Me.txtNombreFormatoEtiqueta)
      Me.Controls.Add(Me.lblIdFormatoEtiqueta)
      Me.Controls.Add(Me.txtIdFormatoEtiqueta)
      Me.Name = "FormatosEtiquetasDetalle"
      Me.Text = "Formato de Etiqueta"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdFormatoEtiqueta, 0)
      Me.Controls.SetChildIndex(Me.lblIdFormatoEtiqueta, 0)
      Me.Controls.SetChildIndex(Me.txtNombreFormatoEtiqueta, 0)
      Me.Controls.SetChildIndex(Me.lblNombreFormatoEtiqueta, 0)
      Me.Controls.SetChildIndex(Me.txtArchivoAImprimir, 0)
      Me.Controls.SetChildIndex(Me.lblArchivoAImprimir, 0)
      Me.Controls.SetChildIndex(Me.cmbTipo, 0)
      Me.Controls.SetChildIndex(Me.lblTipo, 0)
      Me.Controls.SetChildIndex(Me.lblNombreImpresora, 0)
      Me.Controls.SetChildIndex(Me.cmbNombreImpresora, 0)
      Me.Controls.SetChildIndex(Me.chbArchivoEmbebido, 0)
      Me.Controls.SetChildIndex(Me.chbImprimeLote, 0)
      Me.Controls.SetChildIndex(Me.chbActivo, 0)
      Me.Controls.SetChildIndex(Me.txtMaximoColumnas, 0)
      Me.Controls.SetChildIndex(Me.lblMaximoColumnas, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreFormatoEtiqueta As Eniac.Controles.Label
   Friend WithEvents txtNombreFormatoEtiqueta As Eniac.Controles.TextBox
   Friend WithEvents lblIdFormatoEtiqueta As Eniac.Controles.Label
   Friend WithEvents txtIdFormatoEtiqueta As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoAImprimir As Eniac.Controles.Label
   Friend WithEvents txtArchivoAImprimir As Eniac.Controles.TextBox
   Friend WithEvents lblTipo As Eniac.Controles.Label
   Friend WithEvents cmbTipo As Eniac.Controles.ComboBox
   Friend WithEvents cmbNombreImpresora As Eniac.Controles.ComboBox
   Friend WithEvents lblNombreImpresora As Eniac.Controles.Label
   Friend WithEvents chbArchivoEmbebido As Eniac.Controles.CheckBox
   Friend WithEvents chbImprimeLote As Eniac.Controles.CheckBox
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents lblMaximoColumnas As Eniac.Controles.Label
   Friend WithEvents txtMaximoColumnas As Eniac.Controles.TextBox
End Class
