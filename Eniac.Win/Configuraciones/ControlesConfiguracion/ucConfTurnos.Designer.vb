<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfTurnos
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Me.cmbEstadoTurnoBase = New Eniac.Controles.ComboBox()
      Me.Label13 = New Eniac.Controles.Label()
      Me.lblRubro = New Eniac.Controles.Label()
      Me.bscCodigoRubro = New Eniac.Controles.Buscador()
      Me.bscRubro = New Eniac.Controles.Buscador()
      Me.chbTurnosPermiteFacturarDesdeCalendario = New Eniac.Controles.CheckBox()
      Me.Label9 = New Eniac.Controles.Label()
      Me.Label10 = New Eniac.Controles.Label()
      Me.cmbTipoTurnoBase = New Eniac.Controles.ComboBox()
      Me.cmbTipoTurnoCambio = New Eniac.Controles.ComboBox()
      Me.SuspendLayout()
      '
      'cmbEstadoTurnoBase
      '
      Me.cmbEstadoTurnoBase.BindearPropiedadControl = Nothing
      Me.cmbEstadoTurnoBase.BindearPropiedadEntidad = Nothing
      Me.cmbEstadoTurnoBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoTurnoBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEstadoTurnoBase.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoTurnoBase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoTurnoBase.FormattingEnabled = True
      Me.cmbEstadoTurnoBase.IsPK = False
      Me.cmbEstadoTurnoBase.IsRequired = False
      Me.cmbEstadoTurnoBase.Key = Nothing
      Me.cmbEstadoTurnoBase.LabelAsoc = Me.Label13
      Me.cmbEstadoTurnoBase.Location = New System.Drawing.Point(580, 22)
      Me.cmbEstadoTurnoBase.Name = "cmbEstadoTurnoBase"
      Me.cmbEstadoTurnoBase.Size = New System.Drawing.Size(122, 21)
      Me.cmbEstadoTurnoBase.TabIndex = 68
      Me.cmbEstadoTurnoBase.Tag = "TURNOSESTADOBASE"
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label13.LabelAsoc = Nothing
      Me.Label13.Location = New System.Drawing.Point(443, 25)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(133, 13)
      Me.Label13.TabIndex = 67
      Me.Label13.Text = "Estado de Turno Asignado"
      '
      'lblRubro
      '
      Me.lblRubro.AutoSize = True
      Me.lblRubro.LabelAsoc = Nothing
      Me.lblRubro.Location = New System.Drawing.Point(110, 104)
      Me.lblRubro.Name = "lblRubro"
      Me.lblRubro.Size = New System.Drawing.Size(99, 13)
      Me.lblRubro.TabIndex = 64
      Me.lblRubro.Text = "Turnos Utiliza Zona"
      '
      'bscCodigoRubro
      '
      Me.bscCodigoRubro.AyudaAncho = 608
      Me.bscCodigoRubro.BindearPropiedadControl = "Text"
      Me.bscCodigoRubro.BindearPropiedadEntidad = "IdRubro"
      Me.bscCodigoRubro.ColumnasAlineacion = Nothing
      Me.bscCodigoRubro.ColumnasAncho = Nothing
      Me.bscCodigoRubro.ColumnasFormato = Nothing
      Me.bscCodigoRubro.ColumnasOcultas = Nothing
      Me.bscCodigoRubro.ColumnasTitulos = Nothing
      Me.bscCodigoRubro.Datos = Nothing
      Me.bscCodigoRubro.FilaDevuelta = Nothing
      Me.bscCodigoRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoRubro.IsDecimal = False
      Me.bscCodigoRubro.IsNumber = True
      Me.bscCodigoRubro.IsPK = True
      Me.bscCodigoRubro.IsRequired = True
      Me.bscCodigoRubro.Key = ""
      Me.bscCodigoRubro.LabelAsoc = Me.lblRubro
      Me.bscCodigoRubro.Location = New System.Drawing.Point(113, 120)
      Me.bscCodigoRubro.MaxLengh = "32767"
      Me.bscCodigoRubro.Name = "bscCodigoRubro"
      Me.bscCodigoRubro.Permitido = True
      Me.bscCodigoRubro.Selecciono = False
      Me.bscCodigoRubro.Size = New System.Drawing.Size(91, 20)
      Me.bscCodigoRubro.TabIndex = 65
      Me.bscCodigoRubro.Titulo = Nothing
      '
      'bscRubro
      '
      Me.bscRubro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscRubro.AyudaAncho = 608
      Me.bscRubro.BindearPropiedadControl = Nothing
      Me.bscRubro.BindearPropiedadEntidad = Nothing
      Me.bscRubro.ColumnasAlineacion = Nothing
      Me.bscRubro.ColumnasAncho = Nothing
      Me.bscRubro.ColumnasFormato = Nothing
      Me.bscRubro.ColumnasOcultas = Nothing
      Me.bscRubro.ColumnasTitulos = Nothing
      Me.bscRubro.Datos = Nothing
      Me.bscRubro.FilaDevuelta = Nothing
      Me.bscRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.bscRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscRubro.IsDecimal = False
      Me.bscRubro.IsNumber = False
      Me.bscRubro.IsPK = True
      Me.bscRubro.IsRequired = True
      Me.bscRubro.Key = ""
      Me.bscRubro.LabelAsoc = Me.lblRubro
      Me.bscRubro.Location = New System.Drawing.Point(210, 120)
      Me.bscRubro.MaxLengh = "32767"
      Me.bscRubro.Name = "bscRubro"
      Me.bscRubro.Permitido = True
      Me.bscRubro.Selecciono = False
      Me.bscRubro.Size = New System.Drawing.Size(292, 20)
      Me.bscRubro.TabIndex = 66
      Me.bscRubro.Titulo = Nothing
      '
      'chbTurnosPermiteFacturarDesdeCalendario
      '
      Me.chbTurnosPermiteFacturarDesdeCalendario.BindearPropiedadControl = Nothing
      Me.chbTurnosPermiteFacturarDesdeCalendario.BindearPropiedadEntidad = Nothing
      Me.chbTurnosPermiteFacturarDesdeCalendario.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTurnosPermiteFacturarDesdeCalendario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTurnosPermiteFacturarDesdeCalendario.IsPK = False
      Me.chbTurnosPermiteFacturarDesdeCalendario.IsRequired = False
      Me.chbTurnosPermiteFacturarDesdeCalendario.Key = Nothing
      Me.chbTurnosPermiteFacturarDesdeCalendario.LabelAsoc = Nothing
      Me.chbTurnosPermiteFacturarDesdeCalendario.Location = New System.Drawing.Point(112, 76)
      Me.chbTurnosPermiteFacturarDesdeCalendario.Name = "chbTurnosPermiteFacturarDesdeCalendario"
      Me.chbTurnosPermiteFacturarDesdeCalendario.Size = New System.Drawing.Size(230, 27)
      Me.chbTurnosPermiteFacturarDesdeCalendario.TabIndex = 63
      Me.chbTurnosPermiteFacturarDesdeCalendario.Tag = ""
      Me.chbTurnosPermiteFacturarDesdeCalendario.Text = "Turnos Permite Facturar Desde Calendario"
      Me.chbTurnosPermiteFacturarDesdeCalendario.UseVisualStyleBackColor = True
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label9.LabelAsoc = Nothing
      Me.Label9.Location = New System.Drawing.Point(109, 25)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(121, 13)
      Me.Label9.TabIndex = 59
      Me.Label9.Text = "Tipo de Turno Asignado"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label10.LabelAsoc = Nothing
      Me.Label10.Location = New System.Drawing.Point(409, 52)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(170, 13)
      Me.Label10.TabIndex = 61
      Me.Label10.Text = "Estado de Turno luego del Ingreso"
      '
      'cmbTipoTurnoBase
      '
      Me.cmbTipoTurnoBase.BindearPropiedadControl = Nothing
      Me.cmbTipoTurnoBase.BindearPropiedadEntidad = Nothing
      Me.cmbTipoTurnoBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoTurnoBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoTurnoBase.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoTurnoBase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoTurnoBase.FormattingEnabled = True
      Me.cmbTipoTurnoBase.IsPK = False
      Me.cmbTipoTurnoBase.IsRequired = False
      Me.cmbTipoTurnoBase.Key = Nothing
      Me.cmbTipoTurnoBase.LabelAsoc = Me.Label9
      Me.cmbTipoTurnoBase.Location = New System.Drawing.Point(280, 22)
      Me.cmbTipoTurnoBase.Name = "cmbTipoTurnoBase"
      Me.cmbTipoTurnoBase.Size = New System.Drawing.Size(122, 21)
      Me.cmbTipoTurnoBase.TabIndex = 60
      Me.cmbTipoTurnoBase.Tag = "TURNOSTIPOBASE"
      '
      'cmbTipoTurnoCambio
      '
      Me.cmbTipoTurnoCambio.BindearPropiedadControl = Nothing
      Me.cmbTipoTurnoCambio.BindearPropiedadEntidad = Nothing
      Me.cmbTipoTurnoCambio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoTurnoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoTurnoCambio.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoTurnoCambio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoTurnoCambio.FormattingEnabled = True
      Me.cmbTipoTurnoCambio.IsPK = False
      Me.cmbTipoTurnoCambio.IsRequired = False
      Me.cmbTipoTurnoCambio.Key = Nothing
      Me.cmbTipoTurnoCambio.LabelAsoc = Me.Label10
      Me.cmbTipoTurnoCambio.Location = New System.Drawing.Point(580, 49)
      Me.cmbTipoTurnoCambio.Name = "cmbTipoTurnoCambio"
      Me.cmbTipoTurnoCambio.Size = New System.Drawing.Size(122, 21)
      Me.cmbTipoTurnoCambio.TabIndex = 62
      Me.cmbTipoTurnoCambio.Tag = "TURNOSTIPOCAMBIO"
      '
      'ucConfTurnos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.cmbEstadoTurnoBase)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.lblRubro)
      Me.Controls.Add(Me.bscCodigoRubro)
      Me.Controls.Add(Me.bscRubro)
      Me.Controls.Add(Me.chbTurnosPermiteFacturarDesdeCalendario)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.cmbTipoTurnoBase)
      Me.Controls.Add(Me.cmbTipoTurnoCambio)
      Me.Name = "ucConfTurnos"
      Me.Controls.SetChildIndex(Me.cmbTipoTurnoCambio, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoTurnoBase, 0)
      Me.Controls.SetChildIndex(Me.Label10, 0)
      Me.Controls.SetChildIndex(Me.Label9, 0)
      Me.Controls.SetChildIndex(Me.chbTurnosPermiteFacturarDesdeCalendario, 0)
      Me.Controls.SetChildIndex(Me.bscRubro, 0)
      Me.Controls.SetChildIndex(Me.bscCodigoRubro, 0)
      Me.Controls.SetChildIndex(Me.lblRubro, 0)
      Me.Controls.SetChildIndex(Me.Label13, 0)
      Me.Controls.SetChildIndex(Me.cmbEstadoTurnoBase, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents cmbEstadoTurnoBase As Controles.ComboBox
   Friend WithEvents Label13 As Controles.Label
   Friend WithEvents lblRubro As Controles.Label
   Friend WithEvents bscCodigoRubro As Controles.Buscador
   Friend WithEvents bscRubro As Controles.Buscador
   Friend WithEvents chbTurnosPermiteFacturarDesdeCalendario As Controles.CheckBox
   Friend WithEvents Label9 As Controles.Label
   Friend WithEvents Label10 As Controles.Label
   Friend WithEvents cmbTipoTurnoBase As Controles.ComboBox
   Friend WithEvents cmbTipoTurnoCambio As Controles.ComboBox
End Class
