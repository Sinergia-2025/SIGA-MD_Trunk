<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AreasComunesDetalle
   Inherits Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AreasComunesDetalle))
      Me.txtIdAreaComun = New Eniac.Controles.TextBox()
      Me.lblIdSector = New Eniac.Controles.Label()
      Me.lblNombreSector = New Eniac.Controles.Label()
      Me.txtNombreAreaComun = New Eniac.Controles.TextBox()
      Me.cmbNaves = New Eniac.Controles.ComboBox()
      Me.chbParticipaExpensas = New Eniac.Controles.CheckBox()
      Me.chbEsNave = New Eniac.Controles.CheckBox()
      Me.chbEsCliente = New Eniac.Controles.CheckBox()
      Me.bscNombreCliente = New Eniac.Controles.Buscador()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.txtMtsCuadrados = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtCoeficiente = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(412, 162)
      Me.btnAceptar.TabIndex = 9
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(502, 162)
      Me.btnCancelar.TabIndex = 10
      '
      'txtIdAreaComun
      '
      Me.txtIdAreaComun.BindearPropiedadControl = "Text"
      Me.txtIdAreaComun.BindearPropiedadEntidad = "IdAreaComun"
      Me.txtIdAreaComun.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdAreaComun.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdAreaComun.Formato = ""
      Me.txtIdAreaComun.IsDecimal = False
      Me.txtIdAreaComun.IsNumber = False
      Me.txtIdAreaComun.IsPK = True
      Me.txtIdAreaComun.IsRequired = True
      Me.txtIdAreaComun.Key = ""
      Me.txtIdAreaComun.LabelAsoc = Me.lblIdSector
      Me.txtIdAreaComun.Location = New System.Drawing.Point(126, 16)
      Me.txtIdAreaComun.MaxLength = 10
      Me.txtIdAreaComun.Name = "txtIdAreaComun"
      Me.txtIdAreaComun.Size = New System.Drawing.Size(105, 20)
      Me.txtIdAreaComun.TabIndex = 0
      '
      'lblIdSector
      '
      Me.lblIdSector.AutoSize = True
      Me.lblIdSector.Location = New System.Drawing.Point(58, 19)
      Me.lblIdSector.Name = "lblIdSector"
      Me.lblIdSector.Size = New System.Drawing.Size(65, 13)
      Me.lblIdSector.TabIndex = 11
      Me.lblIdSector.Text = "Area Comun"
      '
      'lblNombreSector
      '
      Me.lblNombreSector.AutoSize = True
      Me.lblNombreSector.Location = New System.Drawing.Point(60, 48)
      Me.lblNombreSector.Name = "lblNombreSector"
      Me.lblNombreSector.Size = New System.Drawing.Size(63, 13)
      Me.lblNombreSector.TabIndex = 12
      Me.lblNombreSector.Text = "Descripcion"
      '
      'txtNombreAreaComun
      '
      Me.txtNombreAreaComun.BindearPropiedadControl = "Text"
      Me.txtNombreAreaComun.BindearPropiedadEntidad = "NombreAreaComun"
      Me.txtNombreAreaComun.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreAreaComun.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreAreaComun.Formato = ""
      Me.txtNombreAreaComun.IsDecimal = False
      Me.txtNombreAreaComun.IsNumber = False
      Me.txtNombreAreaComun.IsPK = False
      Me.txtNombreAreaComun.IsRequired = True
      Me.txtNombreAreaComun.Key = ""
      Me.txtNombreAreaComun.LabelAsoc = Me.lblNombreSector
      Me.txtNombreAreaComun.Location = New System.Drawing.Point(126, 44)
      Me.txtNombreAreaComun.MaxLength = 50
      Me.txtNombreAreaComun.Name = "txtNombreAreaComun"
      Me.txtNombreAreaComun.Size = New System.Drawing.Size(453, 20)
      Me.txtNombreAreaComun.TabIndex = 1
      '
      'cmbNaves
      '
      Me.cmbNaves.BindearPropiedadControl = "SelectedValue"
      Me.cmbNaves.BindearPropiedadEntidad = "IdNave"
      Me.cmbNaves.DisplayMember = "IdNave"
      Me.cmbNaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNaves.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNaves.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNaves.FormattingEnabled = True
      Me.cmbNaves.IsPK = False
      Me.cmbNaves.IsRequired = False
      Me.cmbNaves.Key = Nothing
      Me.cmbNaves.LabelAsoc = Nothing
      Me.cmbNaves.Location = New System.Drawing.Point(146, 93)
      Me.cmbNaves.Name = "cmbNaves"
      Me.cmbNaves.Size = New System.Drawing.Size(211, 21)
      Me.cmbNaves.TabIndex = 5
      '
      'chbParticipaExpensas
      '
      Me.chbParticipaExpensas.AutoSize = True
      Me.chbParticipaExpensas.BindearPropiedadControl = "Checked"
      Me.chbParticipaExpensas.BindearPropiedadEntidad = "ParticipaExpensas"
      Me.chbParticipaExpensas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbParticipaExpensas.ForeColorFocus = System.Drawing.Color.Red
      Me.chbParticipaExpensas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbParticipaExpensas.IsPK = False
      Me.chbParticipaExpensas.IsRequired = False
      Me.chbParticipaExpensas.Key = Nothing
      Me.chbParticipaExpensas.LabelAsoc = Nothing
      Me.chbParticipaExpensas.Location = New System.Drawing.Point(10, 70)
      Me.chbParticipaExpensas.Name = "chbParticipaExpensas"
      Me.chbParticipaExpensas.Size = New System.Drawing.Size(130, 17)
      Me.chbParticipaExpensas.TabIndex = 2
      Me.chbParticipaExpensas.Text = "Participa en expensas"
      Me.chbParticipaExpensas.UseVisualStyleBackColor = True
      '
      'chbEsNave
      '
      Me.chbEsNave.AutoSize = True
      Me.chbEsNave.BindearPropiedadControl = ""
      Me.chbEsNave.BindearPropiedadEntidad = ""
      Me.chbEsNave.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbEsNave.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEsNave.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEsNave.IsPK = False
      Me.chbEsNave.IsRequired = False
      Me.chbEsNave.Key = Nothing
      Me.chbEsNave.LabelAsoc = Nothing
      Me.chbEsNave.Location = New System.Drawing.Point(75, 95)
      Me.chbEsNave.Name = "chbEsNave"
      Me.chbEsNave.Size = New System.Drawing.Size(65, 17)
      Me.chbEsNave.TabIndex = 4
      Me.chbEsNave.Text = "Es nave"
      Me.chbEsNave.UseVisualStyleBackColor = True
      '
      'chbEsCliente
      '
      Me.chbEsCliente.AutoSize = True
      Me.chbEsCliente.BindearPropiedadControl = ""
      Me.chbEsCliente.BindearPropiedadEntidad = ""
      Me.chbEsCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbEsCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEsCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEsCliente.IsPK = False
      Me.chbEsCliente.IsRequired = False
      Me.chbEsCliente.Key = Nothing
      Me.chbEsCliente.LabelAsoc = Nothing
      Me.chbEsCliente.Location = New System.Drawing.Point(68, 122)
      Me.chbEsCliente.Name = "chbEsCliente"
      Me.chbEsCliente.Size = New System.Drawing.Size(72, 17)
      Me.chbEsCliente.TabIndex = 6
      Me.chbEsCliente.Text = "Es cliente"
      Me.chbEsCliente.UseVisualStyleBackColor = True
      '
      'bscNombreCliente
      '
      Me.bscNombreCliente.AyudaAncho = 608
      Me.bscNombreCliente.BindearPropiedadControl = Nothing
      Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
      Me.bscNombreCliente.ColumnasAlineacion = Nothing
      Me.bscNombreCliente.ColumnasAncho = Nothing
      Me.bscNombreCliente.ColumnasFormato = Nothing
      Me.bscNombreCliente.ColumnasOcultas = Nothing
      Me.bscNombreCliente.ColumnasTitulos = Nothing
      Me.bscNombreCliente.Datos = Nothing
      Me.bscNombreCliente.FilaDevuelta = Nothing
      Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreCliente.IsDecimal = False
      Me.bscNombreCliente.IsNumber = False
      Me.bscNombreCliente.IsPK = False
      Me.bscNombreCliente.IsRequired = False
      Me.bscNombreCliente.Key = ""
      Me.bscNombreCliente.LabelAsoc = Nothing
      Me.bscNombreCliente.Location = New System.Drawing.Point(271, 119)
      Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.bscNombreCliente.MaxLengh = "32767"
      Me.bscNombreCliente.Name = "bscNombreCliente"
      Me.bscNombreCliente.Permitido = True
      Me.bscNombreCliente.Selecciono = False
      Me.bscNombreCliente.Size = New System.Drawing.Size(308, 23)
      Me.bscNombreCliente.TabIndex = 8
      Me.bscNombreCliente.Titulo = Nothing
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.AyudaAncho = 608
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ColumnasAlineacion = Nothing
      Me.bscCodigoCliente.ColumnasAncho = Nothing
      Me.bscCodigoCliente.ColumnasFormato = Nothing
      Me.bscCodigoCliente.ColumnasOcultas = Nothing
      Me.bscCodigoCliente.ColumnasTitulos = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Nothing
      Me.bscCodigoCliente.Location = New System.Drawing.Point(146, 119)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(120, 23)
      Me.bscCodigoCliente.TabIndex = 7
      Me.bscCodigoCliente.Titulo = Nothing
      '
      'txtMtsCuadrados
      '
      Me.txtMtsCuadrados.BindearPropiedadControl = "Text"
      Me.txtMtsCuadrados.BindearPropiedadEntidad = "Superficie"
      Me.txtMtsCuadrados.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMtsCuadrados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMtsCuadrados.Formato = ""
      Me.txtMtsCuadrados.IsDecimal = False
      Me.txtMtsCuadrados.IsNumber = True
      Me.txtMtsCuadrados.IsPK = False
      Me.txtMtsCuadrados.IsRequired = False
      Me.txtMtsCuadrados.Key = ""
      Me.txtMtsCuadrados.LabelAsoc = Nothing
      Me.txtMtsCuadrados.Location = New System.Drawing.Point(217, 68)
      Me.txtMtsCuadrados.MaxLength = 4
      Me.txtMtsCuadrados.Name = "txtMtsCuadrados"
      Me.txtMtsCuadrados.Size = New System.Drawing.Size(49, 20)
      Me.txtMtsCuadrados.TabIndex = 3
      Me.txtMtsCuadrados.Text = "0"
      Me.txtMtsCuadrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(181, 72)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(30, 13)
      Me.Label1.TabIndex = 13
      Me.Label1.Text = "Mts2"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(287, 72)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(60, 13)
      Me.Label2.TabIndex = 14
      Me.Label2.Text = "Coeficiente"
      '
      'txtCoeficiente
      '
      Me.txtCoeficiente.BindearPropiedadControl = ""
      Me.txtCoeficiente.BindearPropiedadEntidad = ""
      Me.txtCoeficiente.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCoeficiente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCoeficiente.Formato = ""
      Me.txtCoeficiente.IsDecimal = False
      Me.txtCoeficiente.IsNumber = False
      Me.txtCoeficiente.IsPK = False
      Me.txtCoeficiente.IsRequired = False
      Me.txtCoeficiente.Key = ""
      Me.txtCoeficiente.LabelAsoc = Nothing
      Me.txtCoeficiente.Location = New System.Drawing.Point(355, 68)
      Me.txtCoeficiente.MaxLength = 4
      Me.txtCoeficiente.Name = "txtCoeficiente"
      Me.txtCoeficiente.ReadOnly = True
      Me.txtCoeficiente.Size = New System.Drawing.Size(111, 20)
      Me.txtCoeficiente.TabIndex = 15
      Me.txtCoeficiente.Text = "0"
      Me.txtCoeficiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'AreasComunesDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(591, 197)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtCoeficiente)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtMtsCuadrados)
      Me.Controls.Add(Me.bscNombreCliente)
      Me.Controls.Add(Me.bscCodigoCliente)
      Me.Controls.Add(Me.chbEsCliente)
      Me.Controls.Add(Me.chbEsNave)
      Me.Controls.Add(Me.chbParticipaExpensas)
      Me.Controls.Add(Me.cmbNaves)
      Me.Controls.Add(Me.lblNombreSector)
      Me.Controls.Add(Me.txtNombreAreaComun)
      Me.Controls.Add(Me.lblIdSector)
      Me.Controls.Add(Me.txtIdAreaComun)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "AreasComunesDetalle"
      Me.Text = "Area Comun"
      Me.Controls.SetChildIndex(Me.txtIdAreaComun, 0)
      Me.Controls.SetChildIndex(Me.lblIdSector, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreAreaComun, 0)
      Me.Controls.SetChildIndex(Me.lblNombreSector, 0)
      Me.Controls.SetChildIndex(Me.cmbNaves, 0)
      Me.Controls.SetChildIndex(Me.chbParticipaExpensas, 0)
      Me.Controls.SetChildIndex(Me.chbEsNave, 0)
      Me.Controls.SetChildIndex(Me.chbEsCliente, 0)
      Me.Controls.SetChildIndex(Me.bscCodigoCliente, 0)
      Me.Controls.SetChildIndex(Me.bscNombreCliente, 0)
      Me.Controls.SetChildIndex(Me.txtMtsCuadrados, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtCoeficiente, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Friend WithEvents txtIdAreaComun As Eniac.Controles.TextBox
    Friend WithEvents lblIdSector As Eniac.Controles.Label
    Friend WithEvents lblNombreSector As Eniac.Controles.Label
    Friend WithEvents txtNombreAreaComun As Eniac.Controles.TextBox
    Friend WithEvents cmbNaves As Eniac.Controles.ComboBox
    Friend WithEvents chbParticipaExpensas As Eniac.Controles.CheckBox
    Friend WithEvents chbEsNave As Eniac.Controles.CheckBox
    Friend WithEvents chbEsCliente As Eniac.Controles.CheckBox
    Friend WithEvents bscNombreCliente As Eniac.Controles.Buscador
    Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
    Friend WithEvents txtMtsCuadrados As Eniac.Controles.TextBox
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents Label2 As Eniac.Controles.Label
    Friend WithEvents txtCoeficiente As Eniac.Controles.TextBox

End Class
