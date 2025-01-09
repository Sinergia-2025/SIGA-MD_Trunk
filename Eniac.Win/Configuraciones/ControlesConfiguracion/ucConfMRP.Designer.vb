<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucConfMRP
    Inherits ucConfBase

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
      Me.cmbTipoComprobanteOP = New Eniac.Controles.ComboBox()
      Me.lblTipoComprobanteOP = New Eniac.Controles.Label()
      Me.cmbEstadoPlanificacion = New Eniac.Controles.ComboBox()
      Me.lblEstadosPlanificacionNecesidad = New Eniac.Controles.Label()
      Me.cmbTipoComprobanteRQ = New Eniac.Controles.ComboBox()
      Me.lblTipoComprobanteRQ = New Eniac.Controles.Label()
      Me.cmbEstadosPlanificacionRequerimiento = New Eniac.Controles.ComboBox()
      Me.lblEstadosPlanificacionRequerimiento = New Eniac.Controles.Label()
      Me.cmbEstadosFinalOrdenProduccion = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.gbTalleresExternos = New System.Windows.Forms.GroupBox()
      Me.cmbOperarioProductosNecesariosTE = New Eniac.Controles.ComboBox()
      Me.lblOperarioProductosNecesriosTE = New Eniac.Controles.Label()
      Me.cmbEstadoOPVincularFuncionalidadTE = New Eniac.Controles.ComboBox()
      Me.lblEstadoOPVincularFuncionalidadTE = New Eniac.Controles.Label()
      Me.cmbEstadoOPaVincularFuncionalidadTE = New Eniac.Controles.ComboBox()
      Me.lblEstadoOPaVincularFuncionalidadTE = New Eniac.Controles.Label()
        Me.gbTalleresExternos.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbTipoComprobanteOP
        '
        Me.cmbTipoComprobanteOP.BindearPropiedadControl = Nothing
        Me.cmbTipoComprobanteOP.BindearPropiedadEntidad = Nothing
        Me.cmbTipoComprobanteOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobanteOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobanteOP.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobanteOP.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobanteOP.FormattingEnabled = True
        Me.cmbTipoComprobanteOP.IsPK = False
        Me.cmbTipoComprobanteOP.IsRequired = False
        Me.cmbTipoComprobanteOP.Key = Nothing
        Me.cmbTipoComprobanteOP.LabelAsoc = Me.lblTipoComprobanteOP
        Me.cmbTipoComprobanteOP.Location = New System.Drawing.Point(314, 16)
        Me.cmbTipoComprobanteOP.Name = "cmbTipoComprobanteOP"
        Me.cmbTipoComprobanteOP.Size = New System.Drawing.Size(177, 21)
        Me.cmbTipoComprobanteOP.TabIndex = 1
        Me.cmbTipoComprobanteOP.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblTipoComprobanteOP
        '
        Me.lblTipoComprobanteOP.AutoSize = True
        Me.lblTipoComprobanteOP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTipoComprobanteOP.LabelAsoc = Nothing
        Me.lblTipoComprobanteOP.Location = New System.Drawing.Point(15, 19)
        Me.lblTipoComprobanteOP.Name = "lblTipoComprobanteOP"
        Me.lblTipoComprobanteOP.Size = New System.Drawing.Size(213, 13)
        Me.lblTipoComprobanteOP.TabIndex = 0
        Me.lblTipoComprobanteOP.Text = "Tipo de Comprobante Orden de Produccion"
        '
        'cmbEstadoPlanificacion
        '
        Me.cmbEstadoPlanificacion.BindearPropiedadControl = Nothing
        Me.cmbEstadoPlanificacion.BindearPropiedadEntidad = Nothing
        Me.cmbEstadoPlanificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoPlanificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoPlanificacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoPlanificacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoPlanificacion.FormattingEnabled = True
        Me.cmbEstadoPlanificacion.IsPK = False
        Me.cmbEstadoPlanificacion.IsRequired = False
        Me.cmbEstadoPlanificacion.Key = Nothing
        Me.cmbEstadoPlanificacion.LabelAsoc = Me.lblEstadosPlanificacionNecesidad
        Me.cmbEstadoPlanificacion.Location = New System.Drawing.Point(314, 45)
        Me.cmbEstadoPlanificacion.Name = "cmbEstadoPlanificacion"
        Me.cmbEstadoPlanificacion.Size = New System.Drawing.Size(177, 21)
        Me.cmbEstadoPlanificacion.TabIndex = 3
        Me.cmbEstadoPlanificacion.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblEstadosPlanificacionNecesidad
        '
        Me.lblEstadosPlanificacionNecesidad.AutoSize = True
        Me.lblEstadosPlanificacionNecesidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstadosPlanificacionNecesidad.LabelAsoc = Nothing
        Me.lblEstadosPlanificacionNecesidad.Location = New System.Drawing.Point(15, 48)
        Me.lblEstadosPlanificacionNecesidad.Name = "lblEstadosPlanificacionNecesidad"
        Me.lblEstadosPlanificacionNecesidad.Size = New System.Drawing.Size(234, 13)
        Me.lblEstadosPlanificacionNecesidad.TabIndex = 2
        Me.lblEstadosPlanificacionNecesidad.Text = "Estado Final en la Planificacion de Necesidades"
        '
        'cmbTipoComprobanteRQ
        '
        Me.cmbTipoComprobanteRQ.BindearPropiedadControl = Nothing
        Me.cmbTipoComprobanteRQ.BindearPropiedadEntidad = Nothing
        Me.cmbTipoComprobanteRQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobanteRQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobanteRQ.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobanteRQ.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobanteRQ.FormattingEnabled = True
        Me.cmbTipoComprobanteRQ.IsPK = False
        Me.cmbTipoComprobanteRQ.IsRequired = False
        Me.cmbTipoComprobanteRQ.Key = Nothing
        Me.cmbTipoComprobanteRQ.LabelAsoc = Me.lblTipoComprobanteRQ
        Me.cmbTipoComprobanteRQ.Location = New System.Drawing.Point(314, 76)
        Me.cmbTipoComprobanteRQ.Name = "cmbTipoComprobanteRQ"
        Me.cmbTipoComprobanteRQ.Size = New System.Drawing.Size(177, 21)
        Me.cmbTipoComprobanteRQ.TabIndex = 5
        Me.cmbTipoComprobanteRQ.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblTipoComprobanteRQ
        '
        Me.lblTipoComprobanteRQ.AutoSize = True
        Me.lblTipoComprobanteRQ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTipoComprobanteRQ.LabelAsoc = Nothing
        Me.lblTipoComprobanteRQ.Location = New System.Drawing.Point(15, 79)
        Me.lblTipoComprobanteRQ.Name = "lblTipoComprobanteRQ"
        Me.lblTipoComprobanteRQ.Size = New System.Drawing.Size(248, 13)
        Me.lblTipoComprobanteRQ.TabIndex = 4
        Me.lblTipoComprobanteRQ.Text = "Tipo de Comprobante Planificacion Requerimientos"
        '
        'cmbEstadosPlanificacionRequerimiento
        '
        Me.cmbEstadosPlanificacionRequerimiento.BindearPropiedadControl = Nothing
        Me.cmbEstadosPlanificacionRequerimiento.BindearPropiedadEntidad = Nothing
        Me.cmbEstadosPlanificacionRequerimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadosPlanificacionRequerimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadosPlanificacionRequerimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadosPlanificacionRequerimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadosPlanificacionRequerimiento.FormattingEnabled = True
        Me.cmbEstadosPlanificacionRequerimiento.IsPK = False
        Me.cmbEstadosPlanificacionRequerimiento.IsRequired = False
        Me.cmbEstadosPlanificacionRequerimiento.Key = Nothing
        Me.cmbEstadosPlanificacionRequerimiento.LabelAsoc = Me.lblEstadosPlanificacionRequerimiento
        Me.cmbEstadosPlanificacionRequerimiento.Location = New System.Drawing.Point(314, 110)
        Me.cmbEstadosPlanificacionRequerimiento.Name = "cmbEstadosPlanificacionRequerimiento"
        Me.cmbEstadosPlanificacionRequerimiento.Size = New System.Drawing.Size(177, 21)
        Me.cmbEstadosPlanificacionRequerimiento.TabIndex = 7
        Me.cmbEstadosPlanificacionRequerimiento.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblEstadosPlanificacionRequerimiento
        '
        Me.lblEstadosPlanificacionRequerimiento.AutoSize = True
        Me.lblEstadosPlanificacionRequerimiento.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstadosPlanificacionRequerimiento.LabelAsoc = Nothing
        Me.lblEstadosPlanificacionRequerimiento.Location = New System.Drawing.Point(15, 113)
        Me.lblEstadosPlanificacionRequerimiento.Name = "lblEstadosPlanificacionRequerimiento"
        Me.lblEstadosPlanificacionRequerimiento.Size = New System.Drawing.Size(245, 13)
        Me.lblEstadosPlanificacionRequerimiento.TabIndex = 6
        Me.lblEstadosPlanificacionRequerimiento.Text = "Estado Final en la Planificacion de Requerimientos"
        '
        'cmbEstadosFinalOrdenProduccion
        '
        Me.cmbEstadosFinalOrdenProduccion.BindearPropiedadControl = Nothing
        Me.cmbEstadosFinalOrdenProduccion.BindearPropiedadEntidad = Nothing
        Me.cmbEstadosFinalOrdenProduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadosFinalOrdenProduccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadosFinalOrdenProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadosFinalOrdenProduccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadosFinalOrdenProduccion.FormattingEnabled = True
        Me.cmbEstadosFinalOrdenProduccion.IsPK = False
        Me.cmbEstadosFinalOrdenProduccion.IsRequired = False
        Me.cmbEstadosFinalOrdenProduccion.Key = Nothing
        Me.cmbEstadosFinalOrdenProduccion.LabelAsoc = Me.Label1
        Me.cmbEstadosFinalOrdenProduccion.Location = New System.Drawing.Point(314, 146)
        Me.cmbEstadosFinalOrdenProduccion.Name = "cmbEstadosFinalOrdenProduccion"
        Me.cmbEstadosFinalOrdenProduccion.Size = New System.Drawing.Size(177, 21)
        Me.cmbEstadosFinalOrdenProduccion.TabIndex = 9
        Me.cmbEstadosFinalOrdenProduccion.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(15, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(291, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Estado que toma la orden de producción al finalizar la misma"
        '
        'gbTalleresExternos
        '
        Me.gbTalleresExternos.Controls.Add(Me.cmbOperarioProductosNecesariosTE)
        Me.gbTalleresExternos.Controls.Add(Me.lblOperarioProductosNecesriosTE)
        Me.gbTalleresExternos.Controls.Add(Me.cmbEstadoOPVincularFuncionalidadTE)
        Me.gbTalleresExternos.Controls.Add(Me.lblEstadoOPVincularFuncionalidadTE)
        Me.gbTalleresExternos.Controls.Add(Me.cmbEstadoOPaVincularFuncionalidadTE)
        Me.gbTalleresExternos.Controls.Add(Me.lblEstadoOPaVincularFuncionalidadTE)
        Me.gbTalleresExternos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTalleresExternos.Location = New System.Drawing.Point(18, 180)
        Me.gbTalleresExternos.Name = "gbTalleresExternos"
        Me.gbTalleresExternos.Size = New System.Drawing.Size(614, 101)
        Me.gbTalleresExternos.TabIndex = 10
        Me.gbTalleresExternos.TabStop = False
        Me.gbTalleresExternos.Text = "Talleres Externos"
        '
        'cmbOperarioProductosNecesariosTE
        '
        Me.cmbOperarioProductosNecesariosTE.BindearPropiedadControl = Nothing
        Me.cmbOperarioProductosNecesariosTE.BindearPropiedadEntidad = Nothing
        Me.cmbOperarioProductosNecesariosTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperarioProductosNecesariosTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperarioProductosNecesariosTE.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOperarioProductosNecesariosTE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOperarioProductosNecesariosTE.FormattingEnabled = True
        Me.cmbOperarioProductosNecesariosTE.IsPK = False
        Me.cmbOperarioProductosNecesariosTE.IsRequired = False
        Me.cmbOperarioProductosNecesariosTE.Key = Nothing
        Me.cmbOperarioProductosNecesariosTE.LabelAsoc = Me.lblOperarioProductosNecesriosTE
        Me.cmbOperarioProductosNecesariosTE.Location = New System.Drawing.Point(408, 73)
        Me.cmbOperarioProductosNecesariosTE.Name = "cmbOperarioProductosNecesariosTE"
        Me.cmbOperarioProductosNecesariosTE.Size = New System.Drawing.Size(177, 21)
        Me.cmbOperarioProductosNecesariosTE.TabIndex = 5
        Me.cmbOperarioProductosNecesariosTE.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblOperarioProductosNecesriosTE
        '
        Me.lblOperarioProductosNecesriosTE.AutoSize = True
        Me.lblOperarioProductosNecesriosTE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOperarioProductosNecesriosTE.LabelAsoc = Nothing
        Me.lblOperarioProductosNecesriosTE.Location = New System.Drawing.Point(15, 76)
        Me.lblOperarioProductosNecesriosTE.Name = "lblOperarioProductosNecesriosTE"
        Me.lblOperarioProductosNecesriosTE.Size = New System.Drawing.Size(376, 13)
        Me.lblOperarioProductosNecesriosTE.TabIndex = 4
        Me.lblOperarioProductosNecesriosTE.Text = "Operario que informa productos necesarios  en funcionalidad Talleres externos"
        '
        'cmbEstadoOPVincularFuncionalidadTE
        '
        Me.cmbEstadoOPVincularFuncionalidadTE.BindearPropiedadControl = Nothing
        Me.cmbEstadoOPVincularFuncionalidadTE.BindearPropiedadEntidad = Nothing
        Me.cmbEstadoOPVincularFuncionalidadTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoOPVincularFuncionalidadTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoOPVincularFuncionalidadTE.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoOPVincularFuncionalidadTE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoOPVincularFuncionalidadTE.FormattingEnabled = True
        Me.cmbEstadoOPVincularFuncionalidadTE.IsPK = False
        Me.cmbEstadoOPVincularFuncionalidadTE.IsRequired = False
        Me.cmbEstadoOPVincularFuncionalidadTE.Key = Nothing
        Me.cmbEstadoOPVincularFuncionalidadTE.LabelAsoc = Me.lblEstadoOPVincularFuncionalidadTE
        Me.cmbEstadoOPVincularFuncionalidadTE.Location = New System.Drawing.Point(408, 46)
        Me.cmbEstadoOPVincularFuncionalidadTE.Name = "cmbEstadoOPVincularFuncionalidadTE"
        Me.cmbEstadoOPVincularFuncionalidadTE.Size = New System.Drawing.Size(177, 21)
        Me.cmbEstadoOPVincularFuncionalidadTE.TabIndex = 3
        Me.cmbEstadoOPVincularFuncionalidadTE.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblEstadoOPVincularFuncionalidadTE
        '
        Me.lblEstadoOPVincularFuncionalidadTE.AutoSize = True
        Me.lblEstadoOPVincularFuncionalidadTE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstadoOPVincularFuncionalidadTE.LabelAsoc = Nothing
        Me.lblEstadoOPVincularFuncionalidadTE.Location = New System.Drawing.Point(15, 49)
        Me.lblEstadoOPVincularFuncionalidadTE.Name = "lblEstadoOPVincularFuncionalidadTE"
        Me.lblEstadoOPVincularFuncionalidadTE.Size = New System.Drawing.Size(351, 13)
        Me.lblEstadoOPVincularFuncionalidadTE.TabIndex = 2
        Me.lblEstadoOPVincularFuncionalidadTE.Text = "Estado de orden de compra vinculada en funcionalidad Talleres externos"
        '
        'cmbEstadoOPaVincularFuncionalidadTE
        '
        Me.cmbEstadoOPaVincularFuncionalidadTE.BindearPropiedadControl = Nothing
        Me.cmbEstadoOPaVincularFuncionalidadTE.BindearPropiedadEntidad = Nothing
        Me.cmbEstadoOPaVincularFuncionalidadTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoOPaVincularFuncionalidadTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoOPaVincularFuncionalidadTE.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoOPaVincularFuncionalidadTE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoOPaVincularFuncionalidadTE.FormattingEnabled = True
        Me.cmbEstadoOPaVincularFuncionalidadTE.IsPK = False
        Me.cmbEstadoOPaVincularFuncionalidadTE.IsRequired = False
        Me.cmbEstadoOPaVincularFuncionalidadTE.Key = Nothing
        Me.cmbEstadoOPaVincularFuncionalidadTE.LabelAsoc = Me.lblEstadoOPaVincularFuncionalidadTE
        Me.cmbEstadoOPaVincularFuncionalidadTE.Location = New System.Drawing.Point(408, 19)
        Me.cmbEstadoOPaVincularFuncionalidadTE.Name = "cmbEstadoOPaVincularFuncionalidadTE"
        Me.cmbEstadoOPaVincularFuncionalidadTE.Size = New System.Drawing.Size(177, 21)
        Me.cmbEstadoOPaVincularFuncionalidadTE.TabIndex = 1
        Me.cmbEstadoOPaVincularFuncionalidadTE.Tag = "PEDIDOSESTADOAREMITIR"
        '
        'lblEstadoOPaVincularFuncionalidadTE
        '
        Me.lblEstadoOPaVincularFuncionalidadTE.AutoSize = True
        Me.lblEstadoOPaVincularFuncionalidadTE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstadoOPaVincularFuncionalidadTE.LabelAsoc = Nothing
        Me.lblEstadoOPaVincularFuncionalidadTE.Location = New System.Drawing.Point(15, 22)
        Me.lblEstadoOPaVincularFuncionalidadTE.Name = "lblEstadoOPaVincularFuncionalidadTE"
        Me.lblEstadoOPaVincularFuncionalidadTE.Size = New System.Drawing.Size(353, 13)
        Me.lblEstadoOPaVincularFuncionalidadTE.TabIndex = 0
        Me.lblEstadoOPaVincularFuncionalidadTE.Text = "Estado de orden de compra A Vincular en funcionalidad Talleres externos"
        '
        'ucConfMRP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbTalleresExternos)
        Me.Controls.Add(Me.cmbEstadosFinalOrdenProduccion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEstadosPlanificacionRequerimiento)
        Me.Controls.Add(Me.lblEstadosPlanificacionRequerimiento)
        Me.Controls.Add(Me.cmbTipoComprobanteRQ)
        Me.Controls.Add(Me.lblTipoComprobanteRQ)
        Me.Controls.Add(Me.cmbEstadoPlanificacion)
        Me.Controls.Add(Me.lblEstadosPlanificacionNecesidad)
        Me.Controls.Add(Me.cmbTipoComprobanteOP)
        Me.Controls.Add(Me.lblTipoComprobanteOP)
        Me.Name = "ucConfMRP"
        Me.Size = New System.Drawing.Size(872, 497)
        Me.Controls.SetChildIndex(Me.lblTipoComprobanteOP, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoComprobanteOP, 0)
        Me.Controls.SetChildIndex(Me.lblEstadosPlanificacionNecesidad, 0)
        Me.Controls.SetChildIndex(Me.cmbEstadoPlanificacion, 0)
        Me.Controls.SetChildIndex(Me.lblTipoComprobanteRQ, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoComprobanteRQ, 0)
        Me.Controls.SetChildIndex(Me.lblEstadosPlanificacionRequerimiento, 0)
        Me.Controls.SetChildIndex(Me.cmbEstadosPlanificacionRequerimiento, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cmbEstadosFinalOrdenProduccion, 0)
        Me.Controls.SetChildIndex(Me.gbTalleresExternos, 0)
        Me.gbTalleresExternos.ResumeLayout(False)
        Me.gbTalleresExternos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbTipoComprobanteOP As Controles.ComboBox
    Friend WithEvents lblTipoComprobanteOP As Controles.Label
    Friend WithEvents cmbEstadoPlanificacion As Controles.ComboBox
    Friend WithEvents lblEstadosPlanificacionNecesidad As Controles.Label
    Friend WithEvents cmbTipoComprobanteRQ As Controles.ComboBox
    Friend WithEvents lblTipoComprobanteRQ As Controles.Label
    Friend WithEvents cmbEstadosPlanificacionRequerimiento As Controles.ComboBox
    Friend WithEvents lblEstadosPlanificacionRequerimiento As Controles.Label
    Friend WithEvents cmbEstadosFinalOrdenProduccion As Controles.ComboBox
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents gbTalleresExternos As GroupBox
    Friend WithEvents cmbEstadoOPaVincularFuncionalidadTE As Controles.ComboBox
    Friend WithEvents lblEstadoOPaVincularFuncionalidadTE As Controles.Label
    Friend WithEvents cmbOperarioProductosNecesariosTE As Controles.ComboBox
    Friend WithEvents lblOperarioProductosNecesriosTE As Controles.Label
    Friend WithEvents cmbEstadoOPVincularFuncionalidadTE As Controles.ComboBox
    Friend WithEvents lblEstadoOPVincularFuncionalidadTE As Controles.Label
End Class
