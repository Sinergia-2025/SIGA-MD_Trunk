<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucConfVentasExportacion
	Inherits ucConfBase

	'UserControl overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.grpExportacionVenta = New System.Windows.Forms.GroupBox()
		Me.cmbExportarVentasFormato = New Eniac.Controles.ComboBox()
		Me.lblFormatoExportacionVenta = New Eniac.Controles.Label()
		Me.txtUbicacionArchivosPDA = New Eniac.Controles.TextBox()
		Me.lblUbicacionArchivosPDA = New Eniac.Controles.Label()
		Me.txtFormatoArchivoExportacion = New Eniac.Controles.TextBox()
		Me.btnFormatoNombreArchivo = New System.Windows.Forms.Button()
		Me.lblFormatoArchivoExportacion = New Eniac.Controles.Label()
		Me.grpExportacionVenta.SuspendLayout()
		Me.SuspendLayout()
		'
		'grpExportacionVenta
		'
		Me.grpExportacionVenta.Controls.Add(Me.cmbExportarVentasFormato)
		Me.grpExportacionVenta.Controls.Add(Me.txtUbicacionArchivosPDA)
		Me.grpExportacionVenta.Controls.Add(Me.lblFormatoExportacionVenta)
		Me.grpExportacionVenta.Controls.Add(Me.lblUbicacionArchivosPDA)
		Me.grpExportacionVenta.Location = New System.Drawing.Point(45, 27)
		Me.grpExportacionVenta.Name = "grpExportacionVenta"
		Me.grpExportacionVenta.Size = New System.Drawing.Size(474, 119)
		Me.grpExportacionVenta.TabIndex = 59
		Me.grpExportacionVenta.TabStop = False
		Me.grpExportacionVenta.Text = "Exportación de Ventas"
		'
		'cmbExportarVentasFormato
		'
		Me.cmbExportarVentasFormato.BindearPropiedadControl = Nothing
		Me.cmbExportarVentasFormato.BindearPropiedadEntidad = Nothing
		Me.cmbExportarVentasFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbExportarVentasFormato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbExportarVentasFormato.ForeColorFocus = System.Drawing.Color.Red
		Me.cmbExportarVentasFormato.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.cmbExportarVentasFormato.FormattingEnabled = True
		Me.cmbExportarVentasFormato.IsPK = False
		Me.cmbExportarVentasFormato.IsRequired = False
		Me.cmbExportarVentasFormato.Key = Nothing
		Me.cmbExportarVentasFormato.LabelAsoc = Me.lblFormatoExportacionVenta
		Me.cmbExportarVentasFormato.Location = New System.Drawing.Point(73, 23)
		Me.cmbExportarVentasFormato.Name = "cmbExportarVentasFormato"
		Me.cmbExportarVentasFormato.Size = New System.Drawing.Size(153, 21)
		Me.cmbExportarVentasFormato.TabIndex = 23
		Me.cmbExportarVentasFormato.TabStop = False
		'
		'lblFormatoExportacionVenta
		'
		Me.lblFormatoExportacionVenta.AutoSize = True
		Me.lblFormatoExportacionVenta.LabelAsoc = Nothing
		Me.lblFormatoExportacionVenta.Location = New System.Drawing.Point(22, 26)
		Me.lblFormatoExportacionVenta.Name = "lblFormatoExportacionVenta"
		Me.lblFormatoExportacionVenta.Size = New System.Drawing.Size(45, 13)
		Me.lblFormatoExportacionVenta.TabIndex = 22
		Me.lblFormatoExportacionVenta.Text = "Formato"
		'
		'txtUbicacionArchivosPDA
		'
		Me.txtUbicacionArchivosPDA.BindearPropiedadControl = Nothing
		Me.txtUbicacionArchivosPDA.BindearPropiedadEntidad = Nothing
		Me.txtUbicacionArchivosPDA.ForeColorFocus = System.Drawing.Color.Red
		Me.txtUbicacionArchivosPDA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtUbicacionArchivosPDA.Formato = ""
		Me.txtUbicacionArchivosPDA.IsDecimal = False
		Me.txtUbicacionArchivosPDA.IsNumber = False
		Me.txtUbicacionArchivosPDA.IsPK = False
		Me.txtUbicacionArchivosPDA.IsRequired = False
		Me.txtUbicacionArchivosPDA.Key = ""
		Me.txtUbicacionArchivosPDA.LabelAsoc = Me.lblUbicacionArchivosPDA
		Me.txtUbicacionArchivosPDA.Location = New System.Drawing.Point(25, 75)
		Me.txtUbicacionArchivosPDA.Name = "txtUbicacionArchivosPDA"
		Me.txtUbicacionArchivosPDA.Size = New System.Drawing.Size(308, 20)
		Me.txtUbicacionArchivosPDA.TabIndex = 7
		Me.txtUbicacionArchivosPDA.Tag = "UBICACIONARCHIVOSPDA"
		'
		'lblUbicacionArchivosPDA
		'
		Me.lblUbicacionArchivosPDA.AutoSize = True
		Me.lblUbicacionArchivosPDA.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblUbicacionArchivosPDA.LabelAsoc = Nothing
		Me.lblUbicacionArchivosPDA.Location = New System.Drawing.Point(22, 59)
		Me.lblUbicacionArchivosPDA.Name = "lblUbicacionArchivosPDA"
		Me.lblUbicacionArchivosPDA.Size = New System.Drawing.Size(124, 13)
		Me.lblUbicacionArchivosPDA.TabIndex = 6
		Me.lblUbicacionArchivosPDA.Text = "Ubicación Archivos PDA"
		'
		'txtFormatoArchivoExportacion
		'
		Me.txtFormatoArchivoExportacion.BindearPropiedadControl = Nothing
		Me.txtFormatoArchivoExportacion.BindearPropiedadEntidad = Nothing
		Me.txtFormatoArchivoExportacion.ForeColorFocus = System.Drawing.Color.Red
		Me.txtFormatoArchivoExportacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtFormatoArchivoExportacion.Formato = ""
		Me.txtFormatoArchivoExportacion.IsDecimal = False
		Me.txtFormatoArchivoExportacion.IsNumber = False
		Me.txtFormatoArchivoExportacion.IsPK = False
		Me.txtFormatoArchivoExportacion.IsRequired = False
		Me.txtFormatoArchivoExportacion.Key = ""
		Me.txtFormatoArchivoExportacion.LabelAsoc = Me.lblFormatoArchivoExportacion
		Me.txtFormatoArchivoExportacion.Location = New System.Drawing.Point(45, 179)
		Me.txtFormatoArchivoExportacion.Name = "txtFormatoArchivoExportacion"
		Me.txtFormatoArchivoExportacion.ReadOnly = True
		Me.txtFormatoArchivoExportacion.Size = New System.Drawing.Size(428, 20)
		Me.txtFormatoArchivoExportacion.TabIndex = 61
		Me.txtFormatoArchivoExportacion.Tag = "UBICACIONARCHIVOSPDA"
		'
		'btnFormatoNombreArchivo
		'
		Me.btnFormatoNombreArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnFormatoNombreArchivo.BackColor = System.Drawing.SystemColors.Control
		Me.btnFormatoNombreArchivo.Cursor = System.Windows.Forms.Cursors.Hand
		Me.btnFormatoNombreArchivo.Image = Global.Eniac.Win.My.Resources.Resources.info_32
		Me.btnFormatoNombreArchivo.Location = New System.Drawing.Point(479, 171)
		Me.btnFormatoNombreArchivo.Name = "btnFormatoNombreArchivo"
		Me.btnFormatoNombreArchivo.Size = New System.Drawing.Size(39, 35)
		Me.btnFormatoNombreArchivo.TabIndex = 62
		Me.btnFormatoNombreArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnFormatoNombreArchivo.UseVisualStyleBackColor = False
		'
		'lblFormatoArchivoExportacion
		'
		Me.lblFormatoArchivoExportacion.AutoSize = True
		Me.lblFormatoArchivoExportacion.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblFormatoArchivoExportacion.LabelAsoc = Nothing
		Me.lblFormatoArchivoExportacion.Location = New System.Drawing.Point(42, 161)
		Me.lblFormatoArchivoExportacion.Name = "lblFormatoArchivoExportacion"
		Me.lblFormatoArchivoExportacion.Size = New System.Drawing.Size(237, 13)
		Me.lblFormatoArchivoExportacion.TabIndex = 60
		Me.lblFormatoArchivoExportacion.Text = "Formato para Nombre de Archivo de Exportacion"
		'
		'ucConfVentasExportacion
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.btnFormatoNombreArchivo)
		Me.Controls.Add(Me.txtFormatoArchivoExportacion)
		Me.Controls.Add(Me.lblFormatoArchivoExportacion)
		Me.Controls.Add(Me.grpExportacionVenta)
		Me.Name = "ucConfVentasExportacion"
		Me.Controls.SetChildIndex(Me.grpExportacionVenta, 0)
		Me.Controls.SetChildIndex(Me.lblFormatoArchivoExportacion, 0)
		Me.Controls.SetChildIndex(Me.txtFormatoArchivoExportacion, 0)
		Me.Controls.SetChildIndex(Me.btnFormatoNombreArchivo, 0)
		Me.grpExportacionVenta.ResumeLayout(False)
		Me.grpExportacionVenta.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents grpExportacionVenta As GroupBox
	Friend WithEvents cmbExportarVentasFormato As Controles.ComboBox
	Friend WithEvents lblFormatoExportacionVenta As Controles.Label
	Friend WithEvents txtUbicacionArchivosPDA As Controles.TextBox
	Friend WithEvents lblUbicacionArchivosPDA As Controles.Label
	Friend WithEvents txtFormatoArchivoExportacion As Controles.TextBox
	Friend WithEvents lblFormatoArchivoExportacion As Controles.Label
	Friend WithEvents btnFormatoNombreArchivo As Button
End Class
