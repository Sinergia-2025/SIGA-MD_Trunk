<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CasillerosDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CasillerosDetalle))
      Me.lblSector = New Eniac.Controles.Label()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtCodigoCasillero = New Eniac.Controles.TextBox()
      Me.chkCliente = New Eniac.Controles.CheckBox()
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.txtFila = New Eniac.Controles.TextBox()
      Me.lblFila = New Eniac.Controles.Label()
      Me.txtColumna = New Eniac.Controles.TextBox()
      Me.lblColumna = New Eniac.Controles.Label()
      Me.bscNombreCliente = New Eniac.Controles.Buscador()
      Me.lblNombreCliente = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.cmbSector = New Eniac.Controles.ComboBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(330, 203)
        Me.btnAceptar.TabIndex = 8
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(421, 203)
        Me.btnCancelar.TabIndex = 9
        '
        'lblSector
        '
        Me.lblSector.AutoSize = True
        Me.lblSector.LabelAsoc = Nothing
        Me.lblSector.Location = New System.Drawing.Point(27, 45)
        Me.lblSector.Name = "lblSector"
        Me.lblSector.Size = New System.Drawing.Size(38, 13)
        Me.lblSector.TabIndex = 11
        Me.lblSector.Text = "Sector"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(27, 19)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 10
        Me.lblId.Text = "Código"
        '
        'txtCodigoCasillero
        '
        Me.txtCodigoCasillero.BindearPropiedadControl = "Text"
        Me.txtCodigoCasillero.BindearPropiedadEntidad = "CodigoCasillero"
        Me.txtCodigoCasillero.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoCasillero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoCasillero.Formato = ""
        Me.txtCodigoCasillero.IsDecimal = False
        Me.txtCodigoCasillero.IsNumber = True
        Me.txtCodigoCasillero.IsPK = True
        Me.txtCodigoCasillero.IsRequired = True
        Me.txtCodigoCasillero.Key = ""
        Me.txtCodigoCasillero.LabelAsoc = Me.lblId
        Me.txtCodigoCasillero.Location = New System.Drawing.Point(85, 16)
        Me.txtCodigoCasillero.MaxLength = 5
        Me.txtCodigoCasillero.Name = "txtCodigoCasillero"
        Me.txtCodigoCasillero.Size = New System.Drawing.Size(88, 20)
        Me.txtCodigoCasillero.TabIndex = 0
        '
        'chkCliente
        '
        Me.chkCliente.AutoSize = True
        Me.chkCliente.BindearPropiedadControl = ""
        Me.chkCliente.BindearPropiedadEntidad = ""
        Me.chkCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chkCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkCliente.IsPK = False
        Me.chkCliente.IsRequired = False
        Me.chkCliente.Key = Nothing
        Me.chkCliente.LabelAsoc = Nothing
        Me.chkCliente.Location = New System.Drawing.Point(85, 71)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(118, 17)
        Me.chkCliente.TabIndex = 5
        Me.chkCliente.Text = "Asignado al cliente:"
        Me.chkCliente.UseVisualStyleBackColor = True
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
        Me.chbActivo.Location = New System.Drawing.Point(411, 15)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 1
        Me.chbActivo.Text = "Activo"
        Me.chbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'txtFila
        '
        Me.txtFila.BindearPropiedadControl = "Text"
        Me.txtFila.BindearPropiedadEntidad = "FilaCasillero"
        Me.txtFila.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFila.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFila.Formato = ""
        Me.txtFila.IsDecimal = False
        Me.txtFila.IsNumber = True
        Me.txtFila.IsPK = False
        Me.txtFila.IsRequired = True
        Me.txtFila.Key = ""
        Me.txtFila.LabelAsoc = Me.lblFila
        Me.txtFila.Location = New System.Drawing.Point(323, 42)
        Me.txtFila.MaxLength = 5
        Me.txtFila.Name = "txtFila"
        Me.txtFila.Size = New System.Drawing.Size(41, 20)
        Me.txtFila.TabIndex = 3
        Me.txtFila.Text = "0"
        Me.txtFila.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFila
        '
        Me.lblFila.AutoSize = True
        Me.lblFila.LabelAsoc = Nothing
        Me.lblFila.Location = New System.Drawing.Point(294, 45)
        Me.lblFila.Name = "lblFila"
        Me.lblFila.Size = New System.Drawing.Size(23, 13)
        Me.lblFila.TabIndex = 12
        Me.lblFila.Text = "Fila"
        '
        'txtColumna
        '
        Me.txtColumna.BindearPropiedadControl = "Text"
        Me.txtColumna.BindearPropiedadEntidad = "ColumnaCasillero"
        Me.txtColumna.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColumna.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColumna.Formato = ""
        Me.txtColumna.IsDecimal = False
        Me.txtColumna.IsNumber = True
        Me.txtColumna.IsPK = False
        Me.txtColumna.IsRequired = True
        Me.txtColumna.Key = ""
        Me.txtColumna.LabelAsoc = Me.lblColumna
        Me.txtColumna.Location = New System.Drawing.Point(426, 43)
        Me.txtColumna.MaxLength = 5
        Me.txtColumna.Name = "txtColumna"
        Me.txtColumna.Size = New System.Drawing.Size(41, 20)
        Me.txtColumna.TabIndex = 4
        Me.txtColumna.Text = "0"
        Me.txtColumna.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblColumna
        '
        Me.lblColumna.AutoSize = True
        Me.lblColumna.LabelAsoc = Nothing
        Me.lblColumna.Location = New System.Drawing.Point(372, 45)
        Me.lblColumna.Name = "lblColumna"
        Me.lblColumna.Size = New System.Drawing.Size(48, 13)
        Me.lblColumna.TabIndex = 13
        Me.lblColumna.Text = "Columna"
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
        Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCliente.IsDecimal = False
        Me.bscNombreCliente.IsNumber = False
        Me.bscNombreCliente.IsPK = False
        Me.bscNombreCliente.IsRequired = False
        Me.bscNombreCliente.Key = ""
        Me.bscNombreCliente.LabelAsoc = Me.lblNombreCliente
        Me.bscNombreCliente.Location = New System.Drawing.Point(224, 107)
        Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = False
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(272, 23)
        Me.bscNombreCliente.TabIndex = 7
        Me.bscNombreCliente.Titulo = Nothing
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.LabelAsoc = Nothing
        Me.lblNombreCliente.Location = New System.Drawing.Point(221, 91)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreCliente.TabIndex = 15
        Me.lblNombreCliente.Text = "Nombre"
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
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(85, 107)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = False
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(133, 23)
        Me.bscCodigoCliente.TabIndex = 6
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(82, 91)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 14
        Me.lblCodigoCliente.Text = "Código"
        '
        'cmbSector
        '
        Me.cmbSector.BindearPropiedadControl = "SelectedValue"
        Me.cmbSector.BindearPropiedadEntidad = "Sector.IdSector"
        Me.cmbSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSector.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSector.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSector.FormattingEnabled = True
        Me.cmbSector.IsPK = False
        Me.cmbSector.IsRequired = False
        Me.cmbSector.Key = Nothing
        Me.cmbSector.LabelAsoc = Me.lblSector
        Me.cmbSector.Location = New System.Drawing.Point(85, 42)
        Me.cmbSector.Name = "cmbSector"
        Me.cmbSector.Size = New System.Drawing.Size(203, 21)
        Me.cmbSector.TabIndex = 2
        '
        'CasillerosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 238)
        Me.Controls.Add(Me.bscNombreCliente)
        Me.Controls.Add(Me.bscCodigoCliente)
        Me.Controls.Add(Me.lblNombreCliente)
        Me.Controls.Add(Me.lblCodigoCliente)
        Me.Controls.Add(Me.cmbSector)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.chkCliente)
        Me.Controls.Add(Me.lblColumna)
        Me.Controls.Add(Me.lblFila)
        Me.Controls.Add(Me.lblSector)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtColumna)
        Me.Controls.Add(Me.txtFila)
        Me.Controls.Add(Me.txtCodigoCasillero)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CasillerosDetalle"
        Me.Text = "Casillero"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoCasillero, 0)
        Me.Controls.SetChildIndex(Me.txtFila, 0)
        Me.Controls.SetChildIndex(Me.txtColumna, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.lblSector, 0)
        Me.Controls.SetChildIndex(Me.lblFila, 0)
        Me.Controls.SetChildIndex(Me.lblColumna, 0)
        Me.Controls.SetChildIndex(Me.chkCliente, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.Controls.SetChildIndex(Me.cmbSector, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoCliente, 0)
        Me.Controls.SetChildIndex(Me.lblNombreCliente, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoCliente, 0)
        Me.Controls.SetChildIndex(Me.bscNombreCliente, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSector As Eniac.Controles.Label
    Friend WithEvents lblId As Eniac.Controles.Label
    Friend WithEvents txtCodigoCasillero As Eniac.Controles.TextBox
    Friend WithEvents chkCliente As Eniac.Controles.CheckBox
    Friend WithEvents chbActivo As Eniac.Controles.CheckBox
    Friend WithEvents cmbSector As Eniac.Controles.ComboBox
    Friend WithEvents txtFila As Eniac.Controles.TextBox
    Friend WithEvents lblFila As Eniac.Controles.Label
    Friend WithEvents txtColumna As Eniac.Controles.TextBox
    Friend WithEvents lblColumna As Eniac.Controles.Label
    Friend WithEvents bscNombreCliente As Eniac.Controles.Buscador
    Friend WithEvents lblNombreCliente As Eniac.Controles.Label
    Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
    Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
End Class
