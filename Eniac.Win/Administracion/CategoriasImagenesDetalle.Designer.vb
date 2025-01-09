<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoriasImagenesDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CategoriasImagenesDetalle))
      Me.lblIdCategoriaCama = New Eniac.Controles.Label()
      Me.txtIdCategoriaImagen = New Eniac.Controles.TextBox()
      Me.cmbCategorias = New Eniac.Controles.ComboBox()
      Me.lblCategoria = New Eniac.Controles.Label()
      Me.cmbTipoNave = New Eniac.Controles.ComboBox()
      Me.lblTipoNave = New Eniac.Controles.Label()
      Me.pcbFoto = New System.Windows.Forms.PictureBox()
      Me.btnLimpiarImagen = New Eniac.Controles.Button()
      Me.btnBuscarImagen = New Eniac.Controles.Button()
      Me.ofdArchivos = New System.Windows.Forms.OpenFileDialog()
      Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
      Me.lblTableroDePartidasColorBotadas = New Eniac.Controles.Label()
      Me.ucpTableroDePartidasForColorBotadas = New Infragistics.Win.UltraWinEditors.UltraColorPicker()
      Me.Label1 = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.pcbFotoReverso = New System.Windows.Forms.PictureBox()
      Me.btnLimpiarImagenReverso = New Eniac.Controles.Button()
      Me.btnBuscarImagenReverso = New Eniac.Controles.Button()
        Me.Label3 = New Eniac.Controles.Label()
        Me.ucpColorFuenteVtoTextoCredencial = New Infragistics.Win.UltraWinEditors.UltraColorPicker()
        CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucpTableroDePartidasForColorBotadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbFotoReverso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucpColorFuenteVtoTextoCredencial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(577, 345)
        Me.btnAceptar.TabIndex = 14
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(673, 345)
        Me.btnCancelar.TabIndex = 15
        '
        'lblIdCategoriaCama
        '
        Me.lblIdCategoriaCama.AutoSize = True
        Me.lblIdCategoriaCama.LabelAsoc = Nothing
        Me.lblIdCategoriaCama.Location = New System.Drawing.Point(12, 33)
        Me.lblIdCategoriaCama.Name = "lblIdCategoriaCama"
        Me.lblIdCategoriaCama.Size = New System.Drawing.Size(128, 13)
        Me.lblIdCategoriaCama.TabIndex = 0
        Me.lblIdCategoriaCama.Text = "Código Categoría Imagen"
        '
        'txtIdCategoriaImagen
        '
        Me.txtIdCategoriaImagen.BindearPropiedadControl = "Text"
        Me.txtIdCategoriaImagen.BindearPropiedadEntidad = "IdCategoriaImagen"
        Me.txtIdCategoriaImagen.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdCategoriaImagen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdCategoriaImagen.Formato = ""
        Me.txtIdCategoriaImagen.IsDecimal = False
        Me.txtIdCategoriaImagen.IsNumber = True
        Me.txtIdCategoriaImagen.IsPK = True
        Me.txtIdCategoriaImagen.IsRequired = True
        Me.txtIdCategoriaImagen.Key = ""
        Me.txtIdCategoriaImagen.LabelAsoc = Me.lblIdCategoriaCama
        Me.txtIdCategoriaImagen.Location = New System.Drawing.Point(146, 30)
        Me.txtIdCategoriaImagen.MaxLength = 4
        Me.txtIdCategoriaImagen.Name = "txtIdCategoriaImagen"
        Me.txtIdCategoriaImagen.Size = New System.Drawing.Size(42, 20)
        Me.txtIdCategoriaImagen.TabIndex = 1
        Me.txtIdCategoriaImagen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCategorias
        '
        Me.cmbCategorias.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategorias.BindearPropiedadEntidad = "Categoria.IdCategoria"
        Me.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategorias.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategorias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategorias.FormattingEnabled = True
        Me.cmbCategorias.IsPK = False
        Me.cmbCategorias.IsRequired = True
        Me.cmbCategorias.Key = Nothing
        Me.cmbCategorias.LabelAsoc = Me.lblCategoria
        Me.cmbCategorias.Location = New System.Drawing.Point(146, 62)
        Me.cmbCategorias.Name = "cmbCategorias"
        Me.cmbCategorias.Size = New System.Drawing.Size(137, 21)
        Me.cmbCategorias.TabIndex = 17
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCategoria.LabelAsoc = Nothing
        Me.lblCategoria.Location = New System.Drawing.Point(12, 64)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(52, 13)
        Me.lblCategoria.TabIndex = 16
        Me.lblCategoria.Text = "Categoria"
        '
        'cmbTipoNave
        '
        Me.cmbTipoNave.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoNave.BindearPropiedadEntidad = "IdTipoNave"
        Me.cmbTipoNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoNave.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoNave.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoNave.FormattingEnabled = True
        Me.cmbTipoNave.IsPK = False
        Me.cmbTipoNave.IsRequired = False
        Me.cmbTipoNave.Key = Nothing
        Me.cmbTipoNave.LabelAsoc = Me.lblTipoNave
        Me.cmbTipoNave.Location = New System.Drawing.Point(146, 95)
        Me.cmbTipoNave.Name = "cmbTipoNave"
        Me.cmbTipoNave.Size = New System.Drawing.Size(137, 21)
        Me.cmbTipoNave.TabIndex = 19
        '
        'lblTipoNave
        '
        Me.lblTipoNave.AutoSize = True
        Me.lblTipoNave.LabelAsoc = Nothing
        Me.lblTipoNave.Location = New System.Drawing.Point(12, 98)
        Me.lblTipoNave.Name = "lblTipoNave"
        Me.lblTipoNave.Size = New System.Drawing.Size(70, 13)
        Me.lblTipoNave.TabIndex = 18
        Me.lblTipoNave.Text = "Tipo de nave"
        '
        'pcbFoto
        '
        Me.pcbFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pcbFoto.Location = New System.Drawing.Point(146, 141)
        Me.pcbFoto.Name = "pcbFoto"
        Me.pcbFoto.Size = New System.Drawing.Size(237, 175)
        Me.pcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbFoto.TabIndex = 22
        Me.pcbFoto.TabStop = False
        '
        'btnLimpiarImagen
        '
        Me.btnLimpiarImagen.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiarImagen.Location = New System.Drawing.Point(29, 275)
        Me.btnLimpiarImagen.Name = "btnLimpiarImagen"
        Me.btnLimpiarImagen.Size = New System.Drawing.Size(111, 40)
        Me.btnLimpiarImagen.TabIndex = 21
        Me.btnLimpiarImagen.Text = "&Limpiar imagen Frente"
        Me.btnLimpiarImagen.UseVisualStyleBackColor = False
        '
        'btnBuscarImagen
        '
        Me.btnBuscarImagen.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarImagen.Location = New System.Drawing.Point(29, 217)
        Me.btnBuscarImagen.Name = "btnBuscarImagen"
        Me.btnBuscarImagen.Size = New System.Drawing.Size(111, 40)
        Me.btnBuscarImagen.TabIndex = 20
        Me.btnBuscarImagen.Text = "&Buscar imagen Frente"
        Me.btnBuscarImagen.UseVisualStyleBackColor = False
        '
        'ofdArchivos
        '
        Me.ofdArchivos.Filter = "Archivos jpg|*.jpg|Archivos png|*.png"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(293, 103)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(93, 13)
        Me.LinkLabel1.TabIndex = 23
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Limpiar Tipo Nave"
        '
        'lblTableroDePartidasColorBotadas
        '
        Me.lblTableroDePartidasColorBotadas.AutoSize = True
        Me.lblTableroDePartidasColorBotadas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTableroDePartidasColorBotadas.LabelAsoc = Nothing
        Me.lblTableroDePartidasColorBotadas.Location = New System.Drawing.Point(26, 349)
        Me.lblTableroDePartidasColorBotadas.Name = "lblTableroDePartidasColorBotadas"
        Me.lblTableroDePartidasColorBotadas.Size = New System.Drawing.Size(82, 13)
        Me.lblTableroDePartidasColorBotadas.TabIndex = 24
        Me.lblTableroDePartidasColorBotadas.Text = "Color de Fuente"
        '
        'ucpTableroDePartidasForColorBotadas
        '
        Me.ucpTableroDePartidasForColorBotadas.Location = New System.Drawing.Point(114, 345)
        Me.ucpTableroDePartidasForColorBotadas.Name = "ucpTableroDePartidasForColorBotadas"
        Me.ucpTableroDePartidasForColorBotadas.Size = New System.Drawing.Size(125, 21)
        Me.ucpTableroDePartidasForColorBotadas.TabIndex = 25
        Me.ucpTableroDePartidasForColorBotadas.Tag = "TABLERODEPARTIDASFCOLORBOTADAS"
        Me.ucpTableroDePartidasForColorBotadas.Text = "Control"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(143, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Frente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(525, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Reverso"
        '
        'pcbFotoReverso
        '
        Me.pcbFotoReverso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pcbFotoReverso.Location = New System.Drawing.Point(528, 141)
        Me.pcbFotoReverso.Name = "pcbFotoReverso"
        Me.pcbFotoReverso.Size = New System.Drawing.Size(237, 175)
        Me.pcbFotoReverso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbFotoReverso.TabIndex = 29
        Me.pcbFotoReverso.TabStop = False
        '
        'btnLimpiarImagenReverso
        '
        Me.btnLimpiarImagenReverso.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiarImagenReverso.Location = New System.Drawing.Point(411, 275)
        Me.btnLimpiarImagenReverso.Name = "btnLimpiarImagenReverso"
        Me.btnLimpiarImagenReverso.Size = New System.Drawing.Size(111, 40)
        Me.btnLimpiarImagenReverso.TabIndex = 28
        Me.btnLimpiarImagenReverso.Text = "&Limpiar imagen Reverso"
        Me.btnLimpiarImagenReverso.UseVisualStyleBackColor = False
        '
        'btnBuscarImagenReverso
        '
        Me.btnBuscarImagenReverso.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarImagenReverso.Location = New System.Drawing.Point(411, 217)
        Me.btnBuscarImagenReverso.Name = "btnBuscarImagenReverso"
        Me.btnBuscarImagenReverso.Size = New System.Drawing.Size(111, 40)
        Me.btnBuscarImagenReverso.TabIndex = 27
        Me.btnBuscarImagenReverso.Text = "&Buscar imagen Reverso"
        Me.btnBuscarImagenReverso.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(260, 349)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Color Fuente Vto Credencial"
        '
        'ucpColorFuenteVtoTextoCredencial
        '
        Me.ucpColorFuenteVtoTextoCredencial.Location = New System.Drawing.Point(405, 345)
        Me.ucpColorFuenteVtoTextoCredencial.Name = "ucpColorFuenteVtoTextoCredencial"
        Me.ucpColorFuenteVtoTextoCredencial.Size = New System.Drawing.Size(125, 21)
        Me.ucpColorFuenteVtoTextoCredencial.TabIndex = 32
        Me.ucpColorFuenteVtoTextoCredencial.Tag = "TABLERODEPARTIDASFCOLORBOTADAS"
        Me.ucpColorFuenteVtoTextoCredencial.Text = "Control"
        '
        'CategoriasImagenesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 392)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ucpColorFuenteVtoTextoCredencial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pcbFotoReverso)
        Me.Controls.Add(Me.btnLimpiarImagenReverso)
        Me.Controls.Add(Me.btnBuscarImagenReverso)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTableroDePartidasColorBotadas)
        Me.Controls.Add(Me.ucpTableroDePartidasForColorBotadas)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.pcbFoto)
        Me.Controls.Add(Me.btnLimpiarImagen)
        Me.Controls.Add(Me.btnBuscarImagen)
        Me.Controls.Add(Me.cmbTipoNave)
        Me.Controls.Add(Me.lblTipoNave)
        Me.Controls.Add(Me.cmbCategorias)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.lblIdCategoriaCama)
        Me.Controls.Add(Me.txtIdCategoriaImagen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CategoriasImagenesDetalle"
        Me.Text = "Categoria Imágenes"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtIdCategoriaImagen, 0)
        Me.Controls.SetChildIndex(Me.lblIdCategoriaCama, 0)
        Me.Controls.SetChildIndex(Me.lblCategoria, 0)
        Me.Controls.SetChildIndex(Me.cmbCategorias, 0)
        Me.Controls.SetChildIndex(Me.lblTipoNave, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoNave, 0)
        Me.Controls.SetChildIndex(Me.btnBuscarImagen, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiarImagen, 0)
        Me.Controls.SetChildIndex(Me.pcbFoto, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.ucpTableroDePartidasForColorBotadas, 0)
        Me.Controls.SetChildIndex(Me.lblTableroDePartidasColorBotadas, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnBuscarImagenReverso, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiarImagenReverso, 0)
        Me.Controls.SetChildIndex(Me.pcbFotoReverso, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.ucpColorFuenteVtoTextoCredencial, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucpTableroDePartidasForColorBotadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbFotoReverso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucpColorFuenteVtoTextoCredencial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
   Friend WithEvents lblIdCategoriaCama As Eniac.Controles.Label
   Friend WithEvents txtIdCategoriaImagen As Eniac.Controles.TextBox
   Friend WithEvents cmbCategorias As Eniac.Controles.ComboBox
   Friend WithEvents lblCategoria As Eniac.Controles.Label
   Friend WithEvents cmbTipoNave As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoNave As Eniac.Controles.Label
   Friend WithEvents pcbFoto As System.Windows.Forms.PictureBox
   Friend WithEvents btnLimpiarImagen As Eniac.Controles.Button
   Friend WithEvents btnBuscarImagen As Eniac.Controles.Button
   Friend WithEvents ofdArchivos As System.Windows.Forms.OpenFileDialog
   Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
   Friend WithEvents lblTableroDePartidasColorBotadas As Eniac.Controles.Label
   Friend WithEvents ucpTableroDePartidasForColorBotadas As Infragistics.Win.UltraWinEditors.UltraColorPicker
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents pcbFotoReverso As System.Windows.Forms.PictureBox
   Friend WithEvents btnLimpiarImagenReverso As Eniac.Controles.Button
   Friend WithEvents btnBuscarImagenReverso As Eniac.Controles.Button
    Friend WithEvents Label3 As Controles.Label
    Friend WithEvents ucpColorFuenteVtoTextoCredencial As UltraWinEditors.UltraColorPicker
End Class
