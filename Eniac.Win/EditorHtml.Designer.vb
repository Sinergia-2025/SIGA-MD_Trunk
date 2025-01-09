<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorHtml
   Inherits Eniac.Win.BaseForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditorHtml))
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtEditorHtml = New MSDN.Html.Editor.HtmlEditorControl()
        Me.bLoadFile = New System.Windows.Forms.Button()
        Me.bImage = New System.Windows.Forms.Button()
        Me.bForeground = New System.Windows.Forms.Button()
        Me.bBackground = New System.Windows.Forms.Button()
        Me.bSaveHtml = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        Me.imageList1.Images.SetKeyName(2, "diskette_32.png")
        Me.imageList1.Images.SetKeyName(3, "folder_32.ico")
        Me.imageList1.Images.SetKeyName(4, "id_card2.ico")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(796, 509)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(882, 509)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtEditorHtml
        '
        Me.txtEditorHtml.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEditorHtml.InnerText = Nothing
        Me.txtEditorHtml.Location = New System.Drawing.Point(12, 10)
        Me.txtEditorHtml.Name = "txtEditorHtml"
        Me.txtEditorHtml.Size = New System.Drawing.Size(950, 491)
        Me.txtEditorHtml.TabIndex = 6
        '
        'bLoadFile
        '
        Me.bLoadFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bLoadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bLoadFile.ImageIndex = 3
        Me.bLoadFile.ImageList = Me.imageList1
        Me.bLoadFile.Location = New System.Drawing.Point(340, 509)
        Me.bLoadFile.Name = "bLoadFile"
        Me.bLoadFile.Size = New System.Drawing.Size(100, 30)
        Me.bLoadFile.TabIndex = 31
        Me.bLoadFile.Text = "Abrir plantilla"
        Me.bLoadFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bImage
        '
        Me.bImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bImage.ImageIndex = 4
        Me.bImage.ImageList = Me.imageList1
        Me.bImage.Location = New System.Drawing.Point(224, 509)
        Me.bImage.Name = "bImage"
        Me.bImage.Size = New System.Drawing.Size(110, 30)
        Me.bImage.TabIndex = 30
        Me.bImage.Text = "Agregar imagen"
        Me.bImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bForeground
        '
        Me.bForeground.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bForeground.Location = New System.Drawing.Point(118, 509)
        Me.bForeground.Name = "bForeground"
        Me.bForeground.Size = New System.Drawing.Size(100, 30)
        Me.bForeground.TabIndex = 29
        Me.bForeground.Text = "Color texto"
        '
        'bBackground
        '
        Me.bBackground.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bBackground.Location = New System.Drawing.Point(12, 509)
        Me.bBackground.Name = "bBackground"
        Me.bBackground.Size = New System.Drawing.Size(100, 30)
        Me.bBackground.TabIndex = 28
        Me.bBackground.Text = "Color fondo"
        '
        'bSaveHtml
        '
        Me.bSaveHtml.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bSaveHtml.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bSaveHtml.ImageIndex = 2
        Me.bSaveHtml.ImageList = Me.imageList1
        Me.bSaveHtml.Location = New System.Drawing.Point(446, 509)
        Me.bSaveHtml.Name = "bSaveHtml"
        Me.bSaveHtml.Size = New System.Drawing.Size(110, 30)
        Me.bSaveHtml.TabIndex = 31
        Me.bSaveHtml.Text = "Guardar plantilla"
        Me.bSaveHtml.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EditorHtml
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 551)
        Me.Controls.Add(Me.bSaveHtml)
        Me.Controls.Add(Me.bLoadFile)
        Me.Controls.Add(Me.bImage)
        Me.Controls.Add(Me.bForeground)
        Me.Controls.Add(Me.bBackground)
        Me.Controls.Add(Me.txtEditorHtml)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Name = "EditorHtml"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditorHtml"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents txtEditorHtml As MSDN.Html.Editor.HtmlEditorControl
   Private WithEvents bLoadFile As System.Windows.Forms.Button
   Private WithEvents bImage As System.Windows.Forms.Button
   Private WithEvents bForeground As System.Windows.Forms.Button
   Private WithEvents bBackground As System.Windows.Forms.Button
   Private WithEvents bSaveHtml As System.Windows.Forms.Button
End Class
