<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChequerasDetalle
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
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNombreTipoCheque = New Eniac.Controles.TextBox()
      Me.label1 = New Eniac.Controles.Label()
      Me.txtNumeroDesde = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtNumeroHasta = New Eniac.Controles.TextBox()
      Me.bscCuentaBancariaDestino = New Eniac.Controles.Buscador()
      Me.lblCuentaBancariaDestino = New Eniac.Controles.Label()
      Me.txtNombreChequera = New Eniac.Controles.TextBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.Label4 = New Eniac.Controles.Label()
      Me.txtNumeroActual = New Eniac.Controles.TextBox()
      Me.bscCodigoCuentaBancariaDestino = New Eniac.Controles.Buscador()
        Me.Label5 = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(275, 166)
        Me.btnAceptar.TabIndex = 14
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(361, 166)
        Me.btnCancelar.TabIndex = 15
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(174, 166)
        Me.btnCopiar.TabIndex = 16
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(117, 166)
        Me.btnAplicar.TabIndex = 17
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.Checked = True
        Me.chbActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(392, 27)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 13
        Me.chbActivo.Text = "Activo"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(29, 132)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 11
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtNombreTipoCheque
        '
        Me.txtNombreTipoCheque.BindearPropiedadControl = "Text"
        Me.txtNombreTipoCheque.BindearPropiedadEntidad = "Descripcion"
        Me.txtNombreTipoCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreTipoCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreTipoCheque.Formato = ""
        Me.txtNombreTipoCheque.IsDecimal = False
        Me.txtNombreTipoCheque.IsNumber = False
        Me.txtNombreTipoCheque.IsPK = False
        Me.txtNombreTipoCheque.IsRequired = False
        Me.txtNombreTipoCheque.Key = ""
        Me.txtNombreTipoCheque.LabelAsoc = Me.lblDescripcion
        Me.txtNombreTipoCheque.Location = New System.Drawing.Point(98, 129)
        Me.txtNombreTipoCheque.MaxLength = 20
        Me.txtNombreTipoCheque.Name = "txtNombreTipoCheque"
        Me.txtNombreTipoCheque.Size = New System.Drawing.Size(262, 20)
        Me.txtNombreTipoCheque.TabIndex = 12
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.LabelAsoc = Nothing
        Me.label1.Location = New System.Drawing.Point(14, 55)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(78, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Número Desde"
        '
        'txtNumeroDesde
        '
        Me.txtNumeroDesde.BindearPropiedadControl = "Text"
        Me.txtNumeroDesde.BindearPropiedadEntidad = "NumeroDesde"
        Me.txtNumeroDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroDesde.Formato = ""
        Me.txtNumeroDesde.IsDecimal = False
        Me.txtNumeroDesde.IsNumber = True
        Me.txtNumeroDesde.IsPK = True
        Me.txtNumeroDesde.IsRequired = True
        Me.txtNumeroDesde.Key = ""
        Me.txtNumeroDesde.LabelAsoc = Me.label1
        Me.txtNumeroDesde.Location = New System.Drawing.Point(98, 51)
        Me.txtNumeroDesde.MaxLength = 10
        Me.txtNumeroDesde.Name = "txtNumeroDesde"
        Me.txtNumeroDesde.Size = New System.Drawing.Size(85, 20)
        Me.txtNumeroDesde.TabIndex = 4
        Me.txtNumeroDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(189, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "hasta"
        '
        'txtNumeroHasta
        '
        Me.txtNumeroHasta.BindearPropiedadControl = "Text"
        Me.txtNumeroHasta.BindearPropiedadEntidad = "NumeroHasta"
        Me.txtNumeroHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroHasta.Formato = ""
        Me.txtNumeroHasta.IsDecimal = False
        Me.txtNumeroHasta.IsNumber = True
        Me.txtNumeroHasta.IsPK = False
        Me.txtNumeroHasta.IsRequired = True
        Me.txtNumeroHasta.Key = ""
        Me.txtNumeroHasta.LabelAsoc = Me.Label2
        Me.txtNumeroHasta.Location = New System.Drawing.Point(228, 51)
        Me.txtNumeroHasta.MaxLength = 10
        Me.txtNumeroHasta.Name = "txtNumeroHasta"
        Me.txtNumeroHasta.Size = New System.Drawing.Size(85, 20)
        Me.txtNumeroHasta.TabIndex = 6
        Me.txtNumeroHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCuentaBancariaDestino
        '
        Me.bscCuentaBancariaDestino.AyudaAncho = 608
        Me.bscCuentaBancariaDestino.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaDestino.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaDestino.ColumnasAlineacion = Nothing
        Me.bscCuentaBancariaDestino.ColumnasAncho = Nothing
        Me.bscCuentaBancariaDestino.ColumnasFormato = Nothing
        Me.bscCuentaBancariaDestino.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCuentaBancariaDestino.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCuentaBancariaDestino.Datos = Nothing
        Me.bscCuentaBancariaDestino.FilaDevuelta = Nothing
        Me.bscCuentaBancariaDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaDestino.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaDestino.IsDecimal = False
        Me.bscCuentaBancariaDestino.IsNumber = False
        Me.bscCuentaBancariaDestino.IsPK = False
        Me.bscCuentaBancariaDestino.IsRequired = True
        Me.bscCuentaBancariaDestino.Key = ""
        Me.bscCuentaBancariaDestino.LabelAsoc = Me.lblCuentaBancariaDestino
        Me.bscCuentaBancariaDestino.Location = New System.Drawing.Point(98, 25)
        Me.bscCuentaBancariaDestino.MaxLengh = "32767"
        Me.bscCuentaBancariaDestino.Name = "bscCuentaBancariaDestino"
        Me.bscCuentaBancariaDestino.Permitido = True
        Me.bscCuentaBancariaDestino.Selecciono = False
        Me.bscCuentaBancariaDestino.Size = New System.Drawing.Size(262, 20)
        Me.bscCuentaBancariaDestino.TabIndex = 1
        Me.bscCuentaBancariaDestino.Titulo = "Clientes"
        '
        'lblCuentaBancariaDestino
        '
        Me.lblCuentaBancariaDestino.AutoSize = True
        Me.lblCuentaBancariaDestino.LabelAsoc = Nothing
        Me.lblCuentaBancariaDestino.Location = New System.Drawing.Point(12, 28)
        Me.lblCuentaBancariaDestino.Name = "lblCuentaBancariaDestino"
        Me.lblCuentaBancariaDestino.Size = New System.Drawing.Size(80, 13)
        Me.lblCuentaBancariaDestino.TabIndex = 0
        Me.lblCuentaBancariaDestino.Text = "Cuenta Destino"
        '
        'txtNombreChequera
        '
        Me.txtNombreChequera.BindearPropiedadControl = "Text"
        Me.txtNombreChequera.BindearPropiedadEntidad = "NombreChequera"
        Me.txtNombreChequera.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreChequera.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreChequera.Formato = ""
        Me.txtNombreChequera.IsDecimal = False
        Me.txtNombreChequera.IsNumber = False
        Me.txtNombreChequera.IsPK = True
        Me.txtNombreChequera.IsRequired = True
        Me.txtNombreChequera.Key = ""
        Me.txtNombreChequera.LabelAsoc = Me.Label3
        Me.txtNombreChequera.Location = New System.Drawing.Point(98, 77)
        Me.txtNombreChequera.MaxLength = 50
        Me.txtNombreChequera.Name = "txtNombreChequera"
        Me.txtNombreChequera.Size = New System.Drawing.Size(225, 20)
        Me.txtNombreChequera.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(48, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(15, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Número Actual"
        '
        'txtNumeroActual
        '
        Me.txtNumeroActual.BindearPropiedadControl = "Text"
        Me.txtNumeroActual.BindearPropiedadEntidad = "NumeroActual"
        Me.txtNumeroActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroActual.Formato = ""
        Me.txtNumeroActual.IsDecimal = False
        Me.txtNumeroActual.IsNumber = True
        Me.txtNumeroActual.IsPK = False
        Me.txtNumeroActual.IsRequired = True
        Me.txtNumeroActual.Key = ""
        Me.txtNumeroActual.LabelAsoc = Me.Label4
        Me.txtNumeroActual.Location = New System.Drawing.Point(98, 103)
        Me.txtNumeroActual.MaxLength = 50
        Me.txtNumeroActual.Name = "txtNumeroActual"
        Me.txtNumeroActual.Size = New System.Drawing.Size(73, 20)
        Me.txtNumeroActual.TabIndex = 10
        Me.txtNumeroActual.Text = "0"
        Me.txtNumeroActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCodigoCuentaBancariaDestino
        '
        Me.bscCodigoCuentaBancariaDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoCuentaBancariaDestino.AyudaAncho = 608
        Me.bscCodigoCuentaBancariaDestino.BindearPropiedadControl = Nothing
        Me.bscCodigoCuentaBancariaDestino.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCuentaBancariaDestino.ColumnasAlineacion = Nothing
        Me.bscCodigoCuentaBancariaDestino.ColumnasAncho = Nothing
        Me.bscCodigoCuentaBancariaDestino.ColumnasFormato = Nothing
        Me.bscCodigoCuentaBancariaDestino.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCodigoCuentaBancariaDestino.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCodigoCuentaBancariaDestino.Datos = Nothing
        Me.bscCodigoCuentaBancariaDestino.FilaDevuelta = Nothing
        Me.bscCodigoCuentaBancariaDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCuentaBancariaDestino.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCuentaBancariaDestino.IsDecimal = False
        Me.bscCodigoCuentaBancariaDestino.IsNumber = False
        Me.bscCodigoCuentaBancariaDestino.IsPK = False
        Me.bscCodigoCuentaBancariaDestino.IsRequired = False
        Me.bscCodigoCuentaBancariaDestino.Key = ""
        Me.bscCodigoCuentaBancariaDestino.LabelAsoc = Me.lblCuentaBancariaDestino
        Me.bscCodigoCuentaBancariaDestino.Location = New System.Drawing.Point(98, 31)
        Me.bscCodigoCuentaBancariaDestino.MaxLengh = "32767"
        Me.bscCodigoCuentaBancariaDestino.Name = "bscCodigoCuentaBancariaDestino"
        Me.bscCodigoCuentaBancariaDestino.Permitido = True
        Me.bscCodigoCuentaBancariaDestino.Selecciono = False
        Me.bscCodigoCuentaBancariaDestino.Size = New System.Drawing.Size(49, 13)
        Me.bscCodigoCuentaBancariaDestino.TabIndex = 3
        Me.bscCodigoCuentaBancariaDestino.TabStop = False
        Me.bscCodigoCuentaBancariaDestino.Titulo = "Clientes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(171, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "(último cheque registrado)"
        '
        'ChequerasDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 201)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNumeroActual)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNombreChequera)
        Me.Controls.Add(Me.bscCuentaBancariaDestino)
        Me.Controls.Add(Me.lblCuentaBancariaDestino)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumeroHasta)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtNombreTipoCheque)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtNumeroDesde)
        Me.Controls.Add(Me.bscCodigoCuentaBancariaDestino)
        Me.Name = "ChequerasDetalle"
        Me.Text = "Chequeras"
        Me.Controls.SetChildIndex(Me.bscCodigoCuentaBancariaDestino, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtNumeroDesde, 0)
        Me.Controls.SetChildIndex(Me.label1, 0)
        Me.Controls.SetChildIndex(Me.txtNombreTipoCheque, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.Controls.SetChildIndex(Me.txtNumeroHasta, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblCuentaBancariaDestino, 0)
        Me.Controls.SetChildIndex(Me.bscCuentaBancariaDestino, 0)
        Me.Controls.SetChildIndex(Me.txtNombreChequera, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtNumeroActual, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbActivo As Controles.CheckBox
   Friend WithEvents lblDescripcion As Controles.Label
   Friend WithEvents txtNombreTipoCheque As Controles.TextBox
   Friend WithEvents label1 As Controles.Label
   Friend WithEvents txtNumeroDesde As Controles.TextBox
   Friend WithEvents Label2 As Controles.Label
   Friend WithEvents txtNumeroHasta As Controles.TextBox
   Friend WithEvents bscCuentaBancariaDestino As Controles.Buscador
   Friend WithEvents lblCuentaBancariaDestino As Controles.Label
   Friend WithEvents txtNombreChequera As Controles.TextBox
   Friend WithEvents Label3 As Controles.Label
   Friend WithEvents Label4 As Controles.Label
   Friend WithEvents txtNumeroActual As Controles.TextBox
   Friend WithEvents bscCodigoCuentaBancariaDestino As Controles.Buscador
    Friend WithEvents Label5 As Controles.Label
End Class
