<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalidadListasControlDetalle
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
        Me.lblIdInteres = New Eniac.Controles.Label()
        Me.txtIdEdicion = New Eniac.Controles.TextBox()
        Me.lblNombreInteres = New Eniac.Controles.Label()
        Me.txtNombreEdicion = New Eniac.Controles.TextBox()
        Me.txtOrden = New Eniac.Controles.TextBox()
        Me.lblOrden = New Eniac.Controles.Label()
        Me.lblTipoListaControl = New Eniac.Controles.Label()
        Me.cmbTipoListaControl = New Eniac.Controles.ComboBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(196, 132)
        Me.btnAceptar.Size = New System.Drawing.Size(90, 30)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "&Aceptar (F4)"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(292, 132)
        Me.btnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.btnCancelar.TabIndex = 9
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(95, 132)
        Me.btnCopiar.TabIndex = 11
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(35, 132)
        Me.btnAplicar.TabIndex = 10
        '
        'lblIdInteres
        '
        Me.lblIdInteres.AutoSize = True
        Me.lblIdInteres.LabelAsoc = Nothing
        Me.lblIdInteres.Location = New System.Drawing.Point(22, 28)
        Me.lblIdInteres.Name = "lblIdInteres"
        Me.lblIdInteres.Size = New System.Drawing.Size(40, 13)
        Me.lblIdInteres.TabIndex = 0
        Me.lblIdInteres.Text = "Código"
        '
        'txtIdEdicion
        '
        Me.txtIdEdicion.BindearPropiedadControl = "Text"
        Me.txtIdEdicion.BindearPropiedadEntidad = "IdListaControl"
        Me.txtIdEdicion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdEdicion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdEdicion.Formato = ""
        Me.txtIdEdicion.IsDecimal = False
        Me.txtIdEdicion.IsNumber = True
        Me.txtIdEdicion.IsPK = True
        Me.txtIdEdicion.IsRequired = True
        Me.txtIdEdicion.Key = ""
        Me.txtIdEdicion.LabelAsoc = Me.lblIdInteres
        Me.txtIdEdicion.Location = New System.Drawing.Point(92, 24)
        Me.txtIdEdicion.MaxLength = 15
        Me.txtIdEdicion.Name = "txtIdEdicion"
        Me.txtIdEdicion.Size = New System.Drawing.Size(129, 20)
        Me.txtIdEdicion.TabIndex = 1
        Me.txtIdEdicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombreInteres
        '
        Me.lblNombreInteres.AutoSize = True
        Me.lblNombreInteres.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNombreInteres.LabelAsoc = Nothing
        Me.lblNombreInteres.Location = New System.Drawing.Point(22, 53)
        Me.lblNombreInteres.Name = "lblNombreInteres"
        Me.lblNombreInteres.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreInteres.TabIndex = 2
        Me.lblNombreInteres.Text = "Nombre"
        '
        'txtNombreEdicion
        '
        Me.txtNombreEdicion.BindearPropiedadControl = "Text"
        Me.txtNombreEdicion.BindearPropiedadEntidad = "NombreListaControl"
        Me.txtNombreEdicion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreEdicion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreEdicion.Formato = ""
        Me.txtNombreEdicion.IsDecimal = False
        Me.txtNombreEdicion.IsNumber = False
        Me.txtNombreEdicion.IsPK = False
        Me.txtNombreEdicion.IsRequired = True
        Me.txtNombreEdicion.Key = ""
        Me.txtNombreEdicion.LabelAsoc = Me.lblNombreInteres
        Me.txtNombreEdicion.Location = New System.Drawing.Point(92, 50)
        Me.txtNombreEdicion.MaxLength = 30
        Me.txtNombreEdicion.Name = "txtNombreEdicion"
        Me.txtNombreEdicion.Size = New System.Drawing.Size(250, 20)
        Me.txtNombreEdicion.TabIndex = 3
        '
        'txtOrden
        '
        Me.txtOrden.BindearPropiedadControl = "Text"
        Me.txtOrden.BindearPropiedadEntidad = "Orden"
        Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrden.Formato = "N0"
        Me.txtOrden.IsDecimal = False
        Me.txtOrden.IsNumber = True
        Me.txtOrden.IsPK = False
        Me.txtOrden.IsRequired = True
        Me.txtOrden.Key = ""
        Me.txtOrden.LabelAsoc = Me.lblOrden
        Me.txtOrden.Location = New System.Drawing.Point(304, 77)
        Me.txtOrden.MaxLength = 15
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(55, 20)
        Me.txtOrden.TabIndex = 7
        Me.txtOrden.Text = "0"
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.LabelAsoc = Nothing
        Me.lblOrden.Location = New System.Drawing.Point(260, 80)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblOrden.TabIndex = 6
        Me.lblOrden.Text = "Orden"
        '
        'lblTipoListaControl
        '
        Me.lblTipoListaControl.AutoSize = True
        Me.lblTipoListaControl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTipoListaControl.LabelAsoc = Nothing
        Me.lblTipoListaControl.Location = New System.Drawing.Point(38, 80)
        Me.lblTipoListaControl.Name = "lblTipoListaControl"
        Me.lblTipoListaControl.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoListaControl.TabIndex = 4
        Me.lblTipoListaControl.Text = "Tipo"
        '
        'cmbTipoListaControl
        '
        Me.cmbTipoListaControl.BindearPropiedadControl = "SelectedItem"
        Me.cmbTipoListaControl.BindearPropiedadEntidad = "Tipo"
        Me.cmbTipoListaControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoListaControl.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoListaControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoListaControl.FormattingEnabled = True
        Me.cmbTipoListaControl.IsPK = False
        Me.cmbTipoListaControl.IsRequired = True
        Me.cmbTipoListaControl.Key = Nothing
        Me.cmbTipoListaControl.LabelAsoc = Me.lblTipoListaControl
        Me.cmbTipoListaControl.Location = New System.Drawing.Point(92, 76)
        Me.cmbTipoListaControl.Name = "cmbTipoListaControl"
        Me.cmbTipoListaControl.Size = New System.Drawing.Size(162, 21)
        Me.cmbTipoListaControl.TabIndex = 5
        '
        'CalidadListasControlDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(391, 167)
        Me.Controls.Add(Me.lblTipoListaControl)
        Me.Controls.Add(Me.cmbTipoListaControl)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.txtNombreEdicion)
        Me.Controls.Add(Me.txtIdEdicion)
        Me.Controls.Add(Me.lblNombreInteres)
        Me.Controls.Add(Me.lblIdInteres)
        Me.MaximizeBox = True
        Me.Name = "CalidadListasControlDetalle"
        Me.Text = "Lista de Control"
        Me.Controls.SetChildIndex(Me.lblIdInteres, 0)
        Me.Controls.SetChildIndex(Me.lblNombreInteres, 0)
        Me.Controls.SetChildIndex(Me.txtIdEdicion, 0)
        Me.Controls.SetChildIndex(Me.txtNombreEdicion, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.lblOrden, 0)
        Me.Controls.SetChildIndex(Me.txtOrden, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoListaControl, 0)
        Me.Controls.SetChildIndex(Me.lblTipoListaControl, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIdInteres As Eniac.Controles.Label
   Friend WithEvents txtIdEdicion As Eniac.Controles.TextBox
   Friend WithEvents lblNombreInteres As Eniac.Controles.Label
   Friend WithEvents txtNombreEdicion As Eniac.Controles.TextBox
    Friend WithEvents txtOrden As Eniac.Controles.TextBox
    Friend WithEvents lblOrden As Eniac.Controles.Label
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbTipoListaControl As Eniac.Controles.ComboBox
    Friend WithEvents lblTipoListaControl As Eniac.Controles.Label
End Class
