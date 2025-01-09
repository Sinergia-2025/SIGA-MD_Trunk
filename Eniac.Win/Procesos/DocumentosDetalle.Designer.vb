<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentosDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblGrupo = New Eniac.Controles.Label()
      Me.txtGrupo = New Eniac.Controles.TextBox()
      Me.lblVersion = New Eniac.Controles.Label()
      Me.txtVersion = New Eniac.Controles.TextBox()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.btnExportar = New Eniac.Controles.Button()
      Me.btnAbrir = New Eniac.Controles.Button()
      Me.txtIdDocumento = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(369, 107)
      Me.btnAceptar.TabIndex = 10
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(462, 107)
      Me.btnCancelar.TabIndex = 11
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(22, 28)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 0
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "Nombre"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = True
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(77, 24)
      Me.txtNombre.MaxLength = 1
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.ReadOnly = True
      Me.txtNombre.Size = New System.Drawing.Size(369, 20)
      Me.txtNombre.TabIndex = 1
      '
      'lblGrupo
      '
      Me.lblGrupo.AutoSize = True
      Me.lblGrupo.LabelAsoc = Nothing
      Me.lblGrupo.Location = New System.Drawing.Point(144, 62)
      Me.lblGrupo.Name = "lblGrupo"
      Me.lblGrupo.Size = New System.Drawing.Size(36, 13)
      Me.lblGrupo.TabIndex = 5
      Me.lblGrupo.Text = "Grupo"
      '
      'txtGrupo
      '
      Me.txtGrupo.BindearPropiedadControl = "Text"
      Me.txtGrupo.BindearPropiedadEntidad = "Grupo"
      Me.txtGrupo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtGrupo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtGrupo.Formato = ""
      Me.txtGrupo.IsDecimal = False
      Me.txtGrupo.IsNumber = False
      Me.txtGrupo.IsPK = False
      Me.txtGrupo.IsRequired = True
      Me.txtGrupo.Key = ""
      Me.txtGrupo.LabelAsoc = Me.lblGrupo
      Me.txtGrupo.Location = New System.Drawing.Point(199, 58)
      Me.txtGrupo.MaxLength = 15
      Me.txtGrupo.Name = "txtGrupo"
      Me.txtGrupo.Size = New System.Drawing.Size(113, 20)
      Me.txtGrupo.TabIndex = 6
      '
      'lblVersion
      '
      Me.lblVersion.AutoSize = True
      Me.lblVersion.LabelAsoc = Nothing
      Me.lblVersion.Location = New System.Drawing.Point(22, 65)
      Me.lblVersion.Name = "lblVersion"
      Me.lblVersion.Size = New System.Drawing.Size(42, 13)
      Me.lblVersion.TabIndex = 3
      Me.lblVersion.Text = "Version"
      '
      'txtVersion
      '
      Me.txtVersion.BindearPropiedadControl = "Text"
      Me.txtVersion.BindearPropiedadEntidad = "Version"
      Me.txtVersion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtVersion.Formato = ""
      Me.txtVersion.IsDecimal = False
      Me.txtVersion.IsNumber = False
      Me.txtVersion.IsPK = False
      Me.txtVersion.IsRequired = True
      Me.txtVersion.Key = ""
      Me.txtVersion.LabelAsoc = Me.lblVersion
      Me.txtVersion.Location = New System.Drawing.Point(77, 61)
      Me.txtVersion.MaxLength = 5
      Me.txtVersion.Name = "txtVersion"
      Me.txtVersion.Size = New System.Drawing.Size(40, 20)
      Me.txtVersion.TabIndex = 4
      Me.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnExaminar
      '
      Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_16
      Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar.Location = New System.Drawing.Point(452, 23)
      Me.btnExaminar.Name = "btnExaminar"
      Me.btnExaminar.Size = New System.Drawing.Size(70, 20)
      Me.btnExaminar.TabIndex = 2
      Me.btnExaminar.Text = "Exam..."
      Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar.UseVisualStyleBackColor = True
      '
      'btnExportar
      '
      Me.btnExportar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExportar.Location = New System.Drawing.Point(111, 101)
      Me.btnExportar.Name = "btnExportar"
      Me.btnExportar.Size = New System.Drawing.Size(93, 40)
      Me.btnExportar.TabIndex = 9
      Me.btnExportar.Text = "Exportar"
      Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnExportar.UseVisualStyleBackColor = True
      '
      'btnAbrir
      '
      Me.btnAbrir.Image = Global.Eniac.Win.My.Resources.Resources.note_info_32
      Me.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAbrir.Location = New System.Drawing.Point(12, 101)
      Me.btnAbrir.Name = "btnAbrir"
      Me.btnAbrir.Size = New System.Drawing.Size(93, 40)
      Me.btnAbrir.TabIndex = 8
      Me.btnAbrir.Text = "Abrir"
      Me.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnAbrir.UseVisualStyleBackColor = True
      '
      'txtIdDocumento
      '
      Me.txtIdDocumento.BindearPropiedadControl = "Text"
      Me.txtIdDocumento.BindearPropiedadEntidad = "IdDocumento"
      Me.txtIdDocumento.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdDocumento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdDocumento.Formato = ""
      Me.txtIdDocumento.IsDecimal = False
      Me.txtIdDocumento.IsNumber = False
      Me.txtIdDocumento.IsPK = False
      Me.txtIdDocumento.IsRequired = True
      Me.txtIdDocumento.Key = ""
      Me.txtIdDocumento.LabelAsoc = Nothing
      Me.txtIdDocumento.Location = New System.Drawing.Point(415, 59)
      Me.txtIdDocumento.MaxLength = 10
      Me.txtIdDocumento.Name = "txtIdDocumento"
      Me.txtIdDocumento.Size = New System.Drawing.Size(0, 20)
      Me.txtIdDocumento.TabIndex = 7
      Me.txtIdDocumento.TabStop = False
      Me.txtIdDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'DocumentosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(554, 149)
      Me.Controls.Add(Me.btnAbrir)
      Me.Controls.Add(Me.btnExportar)
      Me.Controls.Add(Me.lblVersion)
      Me.Controls.Add(Me.txtVersion)
      Me.Controls.Add(Me.lblGrupo)
      Me.Controls.Add(Me.txtGrupo)
      Me.Controls.Add(Me.btnExaminar)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.txtIdDocumento)
      Me.Name = "DocumentosDetalle"
      Me.Text = "Documento"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdDocumento, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.btnExaminar, 0)
      Me.Controls.SetChildIndex(Me.txtGrupo, 0)
      Me.Controls.SetChildIndex(Me.lblGrupo, 0)
      Me.Controls.SetChildIndex(Me.txtVersion, 0)
      Me.Controls.SetChildIndex(Me.lblVersion, 0)
      Me.Controls.SetChildIndex(Me.btnExportar, 0)
      Me.Controls.SetChildIndex(Me.btnAbrir, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblGrupo As Eniac.Controles.Label
   Friend WithEvents txtGrupo As Eniac.Controles.TextBox
   Friend WithEvents lblVersion As Eniac.Controles.Label
   Friend WithEvents txtVersion As Eniac.Controles.TextBox
   Friend WithEvents btnExaminar As Eniac.Controles.Button
   Friend WithEvents btnExportar As Eniac.Controles.Button
   Friend WithEvents btnAbrir As Eniac.Controles.Button
   Friend WithEvents txtIdDocumento As Eniac.Controles.TextBox
End Class
