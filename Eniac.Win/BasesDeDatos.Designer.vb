<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BasesDeDatos
    Inherits BaseForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BasesDeDatos))
      Me.cmbDataBase = New Eniac.Controles.ComboBox()
      Me.btnCambiar = New System.Windows.Forms.Button()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.SuspendLayout()
      '
      'cmbDataBase
      '
      Me.cmbDataBase.BindearPropiedadControl = Nothing
      Me.cmbDataBase.BindearPropiedadEntidad = Nothing
      Me.cmbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDataBase.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbDataBase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbDataBase.FormattingEnabled = True
      Me.cmbDataBase.IsPK = False
      Me.cmbDataBase.IsRequired = False
      Me.cmbDataBase.Key = Nothing
      Me.cmbDataBase.LabelAsoc = Nothing
      Me.cmbDataBase.Location = New System.Drawing.Point(12, 24)
      Me.cmbDataBase.Name = "cmbDataBase"
      Me.cmbDataBase.Size = New System.Drawing.Size(214, 21)
      Me.cmbDataBase.TabIndex = 0
      '
      'btnCambiar
      '
      Me.btnCambiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCambiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCambiar.ImageIndex = 0
      Me.btnCambiar.ImageList = Me.imgIconos
      Me.btnCambiar.Location = New System.Drawing.Point(70, 65)
      Me.btnCambiar.Name = "btnCambiar"
      Me.btnCambiar.Size = New System.Drawing.Size(98, 42)
      Me.btnCambiar.TabIndex = 1
      Me.btnCambiar.Text = "&Cambiar"
      Me.btnCambiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "database_reload_24.png")
      '
      'BasesDeDatos
      '
      Me.AcceptButton = Me.btnCambiar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(238, 119)
      Me.ControlBox = False
      Me.Controls.Add(Me.btnCambiar)
      Me.Controls.Add(Me.cmbDataBase)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "BasesDeDatos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Bases de Datos"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents cmbDataBase As Eniac.Controles.ComboBox
   Private WithEvents btnCambiar As System.Windows.Forms.Button
   Private WithEvents imgIconos As System.Windows.Forms.ImageList
End Class
