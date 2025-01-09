<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfLogistica
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
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.tbpGenerarArchivos = New System.Windows.Forms.TabPage()
      Me.grpGenerarArchivos = New System.Windows.Forms.GroupBox()
      Me.txtDestinoArchivosParaMoviles = New Eniac.Controles.TextBox()
      Me.lblDestinoArchivosParaMoviles = New Eniac.Controles.Label()
      Me.cmdDestinoArchivosParaMovilesExaminar = New System.Windows.Forms.Button()
      Me.cmbFormatoExportacion1 = New Eniac.Controles.ComboBox()
      Me.lblFormatoExportacion = New Eniac.Controles.Label()
      Me.chbIncluirEsCambiableEsBonificable = New Eniac.Controles.CheckBox()
      Me.chbExportarPreciosConIVA1 = New Eniac.Controles.CheckBox()
      Me.tbpPreventa = New System.Windows.Forms.TabPage()
      Me.GroupBox15 = New System.Windows.Forms.GroupBox()
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido = New Eniac.Controles.CheckBox()
      Me.lblPreventaImprimirPedidos = New Eniac.Controles.Label()
      Me.grpPreventaV2ImportaDescuentos = New System.Windows.Forms.GroupBox()
      Me.chbPreventaV2ImportaDescuentosPedidosPDA = New Eniac.Controles.CheckBox()
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb = New Eniac.Controles.CheckBox()
      Me.cmbPreventaImprimirPedidos = New Eniac.Controles.ComboBox()
      Me.cmbPreVentaAccionSinListaPrecios = New Eniac.Controles.ComboBox()
      Me.lblPreVentaAccionSinListaPrecios = New Eniac.Controles.Label()
      Me.chbPreventaRespetaPrecioDelMovil = New Eniac.Controles.CheckBox()
      Me.chbPreventaV2RespetaListaPreciosCliente = New Eniac.Controles.CheckBox()
      Me.tbpOrganizarEntrega = New System.Windows.Forms.TabPage()
      Me.grpOrganizarEntrega = New System.Windows.Forms.GroupBox()
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio = New Eniac.Controles.CheckBox()
      Me.lblOrganizarEntregaFiltroFechaDesde2 = New Eniac.Controles.Label()
      Me.txtOrganizarEntregaFiltroFechaDesde = New Eniac.Controles.TextBox()
      Me.lblOrganizarEntregaFiltroFechaDesde = New Eniac.Controles.Label()
      Me.cmbOrganizarEntregaFiltroImpreso = New Eniac.Controles.ComboBox()
      Me.lblOrganizarEntregaFiltroImpreso = New Eniac.Controles.Label()
      Me.chbOrganizarEntregaFiltraFechaEnvio = New Eniac.Controles.CheckBox()
      Me.cboFormasPagoOrgEntregas = New Eniac.Controles.ComboBox()
      Me.lblFormasPagoOrgEntregas = New Eniac.Controles.Label()
      Me.tbpConsolidadoCarga = New System.Windows.Forms.TabPage()
      Me.ConsolidadoCarga = New System.Windows.Forms.GroupBox()
      Me.chbConsolidadoCargaOrdenIdProducto = New Eniac.Controles.CheckBox()
      Me.tbpRegistraciónPagosContraEntrega = New System.Windows.Forms.TabPage()
      Me.grpRegistracionPagos = New System.Windows.Forms.GroupBox()
      Me.cmbRegistracionPagosModoConsultarComprobantes = New Eniac.Controles.ComboBox()
      Me.lblRegistracionPagosModoConsultarComprobantes = New Eniac.Controles.Label()
      Me.cmbRegistracionPagosTipoMovimiento = New Eniac.Controles.ComboBox()
      Me.lblRegistracionPagosTipoMovimiento = New Eniac.Controles.Label()
      Me.TabControl1.SuspendLayout()
      Me.tbpGenerarArchivos.SuspendLayout()
      Me.grpGenerarArchivos.SuspendLayout()
      Me.tbpPreventa.SuspendLayout()
      Me.GroupBox15.SuspendLayout()
      Me.grpPreventaV2ImportaDescuentos.SuspendLayout()
      Me.tbpOrganizarEntrega.SuspendLayout()
      Me.grpOrganizarEntrega.SuspendLayout()
      Me.tbpConsolidadoCarga.SuspendLayout()
      Me.ConsolidadoCarga.SuspendLayout()
      Me.tbpRegistraciónPagosContraEntrega.SuspendLayout()
      Me.grpRegistracionPagos.SuspendLayout()
      Me.SuspendLayout()
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.tbpGenerarArchivos)
      Me.TabControl1.Controls.Add(Me.tbpPreventa)
      Me.TabControl1.Controls.Add(Me.tbpOrganizarEntrega)
      Me.TabControl1.Controls.Add(Me.tbpConsolidadoCarga)
      Me.TabControl1.Controls.Add(Me.tbpRegistraciónPagosContraEntrega)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 0)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(900, 400)
      Me.TabControl1.TabIndex = 59
      '
      'tbpGenerarArchivos
      '
      Me.tbpGenerarArchivos.BackColor = System.Drawing.SystemColors.Control
      Me.tbpGenerarArchivos.Controls.Add(Me.grpGenerarArchivos)
      Me.tbpGenerarArchivos.Location = New System.Drawing.Point(4, 22)
      Me.tbpGenerarArchivos.Name = "tbpGenerarArchivos"
      Me.tbpGenerarArchivos.Size = New System.Drawing.Size(892, 374)
      Me.tbpGenerarArchivos.TabIndex = 0
      Me.tbpGenerarArchivos.Text = "Generar Archivos"
      '
      'grpGenerarArchivos
      '
      Me.grpGenerarArchivos.Controls.Add(Me.txtDestinoArchivosParaMoviles)
      Me.grpGenerarArchivos.Controls.Add(Me.cmdDestinoArchivosParaMovilesExaminar)
      Me.grpGenerarArchivos.Controls.Add(Me.lblDestinoArchivosParaMoviles)
      Me.grpGenerarArchivos.Controls.Add(Me.cmbFormatoExportacion1)
      Me.grpGenerarArchivos.Controls.Add(Me.chbIncluirEsCambiableEsBonificable)
      Me.grpGenerarArchivos.Controls.Add(Me.chbExportarPreciosConIVA1)
      Me.grpGenerarArchivos.Controls.Add(Me.lblFormatoExportacion)
      Me.grpGenerarArchivos.Location = New System.Drawing.Point(44, 17)
      Me.grpGenerarArchivos.Name = "grpGenerarArchivos"
      Me.grpGenerarArchivos.Size = New System.Drawing.Size(788, 114)
      Me.grpGenerarArchivos.TabIndex = 1
      Me.grpGenerarArchivos.TabStop = False
      Me.grpGenerarArchivos.Text = "Generar Archivos"
      '
      'txtDestinoArchivosParaMoviles
      '
      Me.txtDestinoArchivosParaMoviles.BindearPropiedadControl = Nothing
      Me.txtDestinoArchivosParaMoviles.BindearPropiedadEntidad = Nothing
      Me.txtDestinoArchivosParaMoviles.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDestinoArchivosParaMoviles.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDestinoArchivosParaMoviles.Formato = ""
      Me.txtDestinoArchivosParaMoviles.IsDecimal = False
      Me.txtDestinoArchivosParaMoviles.IsNumber = False
      Me.txtDestinoArchivosParaMoviles.IsPK = False
      Me.txtDestinoArchivosParaMoviles.IsRequired = False
      Me.txtDestinoArchivosParaMoviles.Key = ""
      Me.txtDestinoArchivosParaMoviles.LabelAsoc = Me.lblDestinoArchivosParaMoviles
      Me.txtDestinoArchivosParaMoviles.Location = New System.Drawing.Point(218, 17)
      Me.txtDestinoArchivosParaMoviles.Name = "txtDestinoArchivosParaMoviles"
      Me.txtDestinoArchivosParaMoviles.Size = New System.Drawing.Size(308, 20)
      Me.txtDestinoArchivosParaMoviles.TabIndex = 1
      Me.txtDestinoArchivosParaMoviles.Tag = "RUTAARCHIVOSPALM"
      Me.txtDestinoArchivosParaMoviles.Text = "C:\"
      '
      'lblDestinoArchivosParaMoviles
      '
      Me.lblDestinoArchivosParaMoviles.AutoSize = True
      Me.lblDestinoArchivosParaMoviles.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDestinoArchivosParaMoviles.LabelAsoc = Nothing
      Me.lblDestinoArchivosParaMoviles.Location = New System.Drawing.Point(41, 20)
      Me.lblDestinoArchivosParaMoviles.Name = "lblDestinoArchivosParaMoviles"
      Me.lblDestinoArchivosParaMoviles.Size = New System.Drawing.Size(165, 13)
      Me.lblDestinoArchivosParaMoviles.TabIndex = 0
      Me.lblDestinoArchivosParaMoviles.Text = "Destino de Archivos para Moviles"
      '
      'cmdDestinoArchivosParaMovilesExaminar
      '
      Me.cmdDestinoArchivosParaMovilesExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.cmdDestinoArchivosParaMovilesExaminar.Location = New System.Drawing.Point(532, 15)
      Me.cmdDestinoArchivosParaMovilesExaminar.Name = "cmdDestinoArchivosParaMovilesExaminar"
      Me.cmdDestinoArchivosParaMovilesExaminar.Size = New System.Drawing.Size(29, 23)
      Me.cmdDestinoArchivosParaMovilesExaminar.TabIndex = 2
      Me.cmdDestinoArchivosParaMovilesExaminar.Text = "..."
      Me.cmdDestinoArchivosParaMovilesExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdDestinoArchivosParaMovilesExaminar.UseVisualStyleBackColor = True
      '
      'cmbFormatoExportacion1
      '
      Me.cmbFormatoExportacion1.BindearPropiedadControl = Nothing
      Me.cmbFormatoExportacion1.BindearPropiedadEntidad = Nothing
      Me.cmbFormatoExportacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormatoExportacion1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormatoExportacion1.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormatoExportacion1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormatoExportacion1.FormattingEnabled = True
      Me.cmbFormatoExportacion1.IsPK = False
      Me.cmbFormatoExportacion1.IsRequired = False
      Me.cmbFormatoExportacion1.Key = Nothing
      Me.cmbFormatoExportacion1.LabelAsoc = Me.lblFormatoExportacion
      Me.cmbFormatoExportacion1.Location = New System.Drawing.Point(218, 43)
      Me.cmbFormatoExportacion1.Name = "cmbFormatoExportacion1"
      Me.cmbFormatoExportacion1.Size = New System.Drawing.Size(122, 21)
      Me.cmbFormatoExportacion1.TabIndex = 4
      Me.cmbFormatoExportacion1.Tag = "ORGANIZARENTREGASFORMADEPAGO"
      '
      'lblFormatoExportacion
      '
      Me.lblFormatoExportacion.AutoSize = True
      Me.lblFormatoExportacion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFormatoExportacion.LabelAsoc = Nothing
      Me.lblFormatoExportacion.Location = New System.Drawing.Point(41, 46)
      Me.lblFormatoExportacion.Name = "lblFormatoExportacion"
      Me.lblFormatoExportacion.Size = New System.Drawing.Size(140, 13)
      Me.lblFormatoExportacion.TabIndex = 3
      Me.lblFormatoExportacion.Text = "Formato archivo por defecto"
      '
      'chbIncluirEsCambiableEsBonificable
      '
      Me.chbIncluirEsCambiableEsBonificable.AutoSize = True
      Me.chbIncluirEsCambiableEsBonificable.BindearPropiedadControl = Nothing
      Me.chbIncluirEsCambiableEsBonificable.BindearPropiedadEntidad = Nothing
      Me.chbIncluirEsCambiableEsBonificable.ForeColorFocus = System.Drawing.Color.Red
      Me.chbIncluirEsCambiableEsBonificable.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbIncluirEsCambiableEsBonificable.IsPK = False
      Me.chbIncluirEsCambiableEsBonificable.IsRequired = False
      Me.chbIncluirEsCambiableEsBonificable.Key = Nothing
      Me.chbIncluirEsCambiableEsBonificable.LabelAsoc = Nothing
      Me.chbIncluirEsCambiableEsBonificable.Location = New System.Drawing.Point(218, 93)
      Me.chbIncluirEsCambiableEsBonificable.Name = "chbIncluirEsCambiableEsBonificable"
      Me.chbIncluirEsCambiableEsBonificable.Size = New System.Drawing.Size(306, 17)
      Me.chbIncluirEsCambiableEsBonificable.TabIndex = 6
      Me.chbIncluirEsCambiableEsBonificable.Text = "Incluir EsCambiable y EsBonificable en archivo de producto"
      Me.chbIncluirEsCambiableEsBonificable.UseVisualStyleBackColor = True
      '
      'chbExportarPreciosConIVA1
      '
      Me.chbExportarPreciosConIVA1.AutoSize = True
      Me.chbExportarPreciosConIVA1.BindearPropiedadControl = Nothing
      Me.chbExportarPreciosConIVA1.BindearPropiedadEntidad = Nothing
      Me.chbExportarPreciosConIVA1.ForeColorFocus = System.Drawing.Color.Red
      Me.chbExportarPreciosConIVA1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbExportarPreciosConIVA1.IsPK = False
      Me.chbExportarPreciosConIVA1.IsRequired = False
      Me.chbExportarPreciosConIVA1.Key = Nothing
      Me.chbExportarPreciosConIVA1.LabelAsoc = Nothing
      Me.chbExportarPreciosConIVA1.Location = New System.Drawing.Point(218, 70)
      Me.chbExportarPreciosConIVA1.Name = "chbExportarPreciosConIVA1"
      Me.chbExportarPreciosConIVA1.Size = New System.Drawing.Size(298, 17)
      Me.chbExportarPreciosConIVA1.TabIndex = 5
      Me.chbExportarPreciosConIVA1.Text = "Generar Archivos: Exportar Precios de Productos con IVA"
      Me.chbExportarPreciosConIVA1.UseVisualStyleBackColor = True
      '
      'tbpPreventa
      '
      Me.tbpPreventa.BackColor = System.Drawing.SystemColors.Control
      Me.tbpPreventa.Controls.Add(Me.GroupBox15)
      Me.tbpPreventa.Location = New System.Drawing.Point(4, 22)
      Me.tbpPreventa.Name = "tbpPreventa"
      Me.tbpPreventa.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpPreventa.Size = New System.Drawing.Size(882, 298)
      Me.tbpPreventa.TabIndex = 1
      Me.tbpPreventa.Text = "Preventa"
      '
      'GroupBox15
      '
      Me.GroupBox15.Controls.Add(Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido)
      Me.GroupBox15.Controls.Add(Me.lblPreventaImprimirPedidos)
      Me.GroupBox15.Controls.Add(Me.grpPreventaV2ImportaDescuentos)
      Me.GroupBox15.Controls.Add(Me.cmbPreventaImprimirPedidos)
      Me.GroupBox15.Controls.Add(Me.cmbPreVentaAccionSinListaPrecios)
      Me.GroupBox15.Controls.Add(Me.lblPreVentaAccionSinListaPrecios)
      Me.GroupBox15.Controls.Add(Me.chbPreventaRespetaPrecioDelMovil)
      Me.GroupBox15.Controls.Add(Me.chbPreventaV2RespetaListaPreciosCliente)
      Me.GroupBox15.Location = New System.Drawing.Point(43, 17)
      Me.GroupBox15.Name = "GroupBox15"
      Me.GroupBox15.Size = New System.Drawing.Size(788, 106)
      Me.GroupBox15.TabIndex = 2
      Me.GroupBox15.TabStop = False
      Me.GroupBox15.Text = "Preventa"
      '
      'chbPreVentaAgrupaOrdenProductoEnCadaPedido
      '
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.AutoSize = True
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.BindearPropiedadControl = Nothing
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.BindearPropiedadEntidad = Nothing
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.IsPK = False
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.IsRequired = False
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.Key = Nothing
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.LabelAsoc = Nothing
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.Location = New System.Drawing.Point(376, 83)
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.Name = "chbPreVentaAgrupaOrdenProductoEnCadaPedido"
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.Size = New System.Drawing.Size(320, 17)
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.TabIndex = 7
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.Text = "Preventa Agrupa los productos por órden en diferentes Pedido"
      Me.chbPreVentaAgrupaOrdenProductoEnCadaPedido.UseVisualStyleBackColor = True
      '
      'lblPreventaImprimirPedidos
      '
      Me.lblPreventaImprimirPedidos.AutoSize = True
      Me.lblPreventaImprimirPedidos.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblPreventaImprimirPedidos.LabelAsoc = Nothing
      Me.lblPreventaImprimirPedidos.Location = New System.Drawing.Point(489, 34)
      Me.lblPreventaImprimirPedidos.Name = "lblPreventaImprimirPedidos"
      Me.lblPreventaImprimirPedidos.Size = New System.Drawing.Size(83, 13)
      Me.lblPreventaImprimirPedidos.TabIndex = 3
      Me.lblPreventaImprimirPedidos.Text = "Imprimir Pedidos"
      '
      'grpPreventaV2ImportaDescuentos
      '
      Me.grpPreventaV2ImportaDescuentos.Controls.Add(Me.chbPreventaV2ImportaDescuentosPedidosPDA)
      Me.grpPreventaV2ImportaDescuentos.Controls.Add(Me.chbPreventaV2ImportaDescuentosSiMovilWeb)
      Me.grpPreventaV2ImportaDescuentos.Location = New System.Drawing.Point(94, 11)
      Me.grpPreventaV2ImportaDescuentos.Name = "grpPreventaV2ImportaDescuentos"
      Me.grpPreventaV2ImportaDescuentos.Size = New System.Drawing.Size(246, 44)
      Me.grpPreventaV2ImportaDescuentos.TabIndex = 0
      Me.grpPreventaV2ImportaDescuentos.TabStop = False
      Me.grpPreventaV2ImportaDescuentos.Text = "Preventa importa descuentos de..."
      '
      'chbPreventaV2ImportaDescuentosPedidosPDA
      '
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.AutoSize = True
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.BindearPropiedadControl = Nothing
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.BindearPropiedadEntidad = Nothing
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.IsPK = False
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.IsRequired = False
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.Key = Nothing
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.LabelAsoc = Nothing
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.Location = New System.Drawing.Point(22, 19)
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.Name = "chbPreventaV2ImportaDescuentosPedidosPDA"
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.Size = New System.Drawing.Size(89, 17)
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.TabIndex = 0
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.Text = "Pedidos PDA"
      Me.chbPreventaV2ImportaDescuentosPedidosPDA.UseVisualStyleBackColor = True
      '
      'chbPreventaV2ImportaDescuentosSiMovilWeb
      '
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.AutoSize = True
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.BindearPropiedadControl = Nothing
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.BindearPropiedadEntidad = Nothing
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.IsPK = False
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.IsRequired = False
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.Key = Nothing
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.LabelAsoc = Nothing
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.Location = New System.Drawing.Point(117, 19)
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.Name = "chbPreventaV2ImportaDescuentosSiMovilWeb"
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.Size = New System.Drawing.Size(86, 17)
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.TabIndex = 1
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.Text = "SiMovil Web"
      Me.chbPreventaV2ImportaDescuentosSiMovilWeb.UseVisualStyleBackColor = True
      '
      'cmbPreventaImprimirPedidos
      '
      Me.cmbPreventaImprimirPedidos.BindearPropiedadControl = Nothing
      Me.cmbPreventaImprimirPedidos.BindearPropiedadEntidad = Nothing
      Me.cmbPreventaImprimirPedidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPreventaImprimirPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPreventaImprimirPedidos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPreventaImprimirPedidos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPreventaImprimirPedidos.FormattingEnabled = True
      Me.cmbPreventaImprimirPedidos.IsPK = False
      Me.cmbPreventaImprimirPedidos.IsRequired = False
      Me.cmbPreventaImprimirPedidos.Key = Nothing
      Me.cmbPreventaImprimirPedidos.LabelAsoc = Me.lblPreventaImprimirPedidos
      Me.cmbPreventaImprimirPedidos.Location = New System.Drawing.Point(578, 30)
      Me.cmbPreventaImprimirPedidos.Name = "cmbPreventaImprimirPedidos"
      Me.cmbPreventaImprimirPedidos.Size = New System.Drawing.Size(150, 21)
      Me.cmbPreventaImprimirPedidos.TabIndex = 4
      Me.cmbPreventaImprimirPedidos.Tag = ""
      '
      'cmbPreVentaAccionSinListaPrecios
      '
      Me.cmbPreVentaAccionSinListaPrecios.BindearPropiedadControl = Nothing
      Me.cmbPreVentaAccionSinListaPrecios.BindearPropiedadEntidad = Nothing
      Me.cmbPreVentaAccionSinListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPreVentaAccionSinListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPreVentaAccionSinListaPrecios.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPreVentaAccionSinListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPreVentaAccionSinListaPrecios.FormattingEnabled = True
      Me.cmbPreVentaAccionSinListaPrecios.IsPK = False
      Me.cmbPreVentaAccionSinListaPrecios.IsRequired = False
      Me.cmbPreVentaAccionSinListaPrecios.Key = Nothing
      Me.cmbPreVentaAccionSinListaPrecios.LabelAsoc = Me.lblPreVentaAccionSinListaPrecios
      Me.cmbPreVentaAccionSinListaPrecios.Location = New System.Drawing.Point(578, 57)
      Me.cmbPreVentaAccionSinListaPrecios.Name = "cmbPreVentaAccionSinListaPrecios"
      Me.cmbPreVentaAccionSinListaPrecios.Size = New System.Drawing.Size(150, 21)
      Me.cmbPreVentaAccionSinListaPrecios.TabIndex = 6
      Me.cmbPreVentaAccionSinListaPrecios.Tag = "ORGANIZARENTREGASFORMADEPAGO"
      '
      'lblPreVentaAccionSinListaPrecios
      '
      Me.lblPreVentaAccionSinListaPrecios.AutoSize = True
      Me.lblPreVentaAccionSinListaPrecios.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblPreVentaAccionSinListaPrecios.LabelAsoc = Nothing
      Me.lblPreVentaAccionSinListaPrecios.Location = New System.Drawing.Point(373, 60)
      Me.lblPreVentaAccionSinListaPrecios.Name = "lblPreVentaAccionSinListaPrecios"
      Me.lblPreVentaAccionSinListaPrecios.Size = New System.Drawing.Size(199, 13)
      Me.lblPreVentaAccionSinListaPrecios.TabIndex = 5
      Me.lblPreVentaAccionSinListaPrecios.Text = "Acción si pedido no tiene lista de precios"
      '
      'chbPreventaRespetaPrecioDelMovil
      '
      Me.chbPreventaRespetaPrecioDelMovil.AutoSize = True
      Me.chbPreventaRespetaPrecioDelMovil.BindearPropiedadControl = Nothing
      Me.chbPreventaRespetaPrecioDelMovil.BindearPropiedadEntidad = Nothing
      Me.chbPreventaRespetaPrecioDelMovil.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPreventaRespetaPrecioDelMovil.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPreventaRespetaPrecioDelMovil.IsPK = False
      Me.chbPreventaRespetaPrecioDelMovil.IsRequired = False
      Me.chbPreventaRespetaPrecioDelMovil.Key = Nothing
      Me.chbPreventaRespetaPrecioDelMovil.LabelAsoc = Nothing
      Me.chbPreventaRespetaPrecioDelMovil.Location = New System.Drawing.Point(116, 83)
      Me.chbPreventaRespetaPrecioDelMovil.Name = "chbPreventaRespetaPrecioDelMovil"
      Me.chbPreventaRespetaPrecioDelMovil.Size = New System.Drawing.Size(194, 17)
      Me.chbPreventaRespetaPrecioDelMovil.TabIndex = 2
      Me.chbPreventaRespetaPrecioDelMovil.Text = "Preventa respeta el precio del movil"
      Me.chbPreventaRespetaPrecioDelMovil.UseVisualStyleBackColor = True
      '
      'chbPreventaV2RespetaListaPreciosCliente
      '
      Me.chbPreventaV2RespetaListaPreciosCliente.AutoSize = True
      Me.chbPreventaV2RespetaListaPreciosCliente.BindearPropiedadControl = Nothing
      Me.chbPreventaV2RespetaListaPreciosCliente.BindearPropiedadEntidad = Nothing
      Me.chbPreventaV2RespetaListaPreciosCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPreventaV2RespetaListaPreciosCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPreventaV2RespetaListaPreciosCliente.IsPK = False
      Me.chbPreventaV2RespetaListaPreciosCliente.IsRequired = False
      Me.chbPreventaV2RespetaListaPreciosCliente.Key = Nothing
      Me.chbPreventaV2RespetaListaPreciosCliente.LabelAsoc = Nothing
      Me.chbPreventaV2RespetaListaPreciosCliente.Location = New System.Drawing.Point(116, 60)
      Me.chbPreventaV2RespetaListaPreciosCliente.Name = "chbPreventaV2RespetaListaPreciosCliente"
      Me.chbPreventaV2RespetaListaPreciosCliente.Size = New System.Drawing.Size(231, 17)
      Me.chbPreventaV2RespetaListaPreciosCliente.TabIndex = 1
      Me.chbPreventaV2RespetaListaPreciosCliente.Text = "Preventa respeta lista de precios del cliente"
      Me.chbPreventaV2RespetaListaPreciosCliente.UseVisualStyleBackColor = True
      '
      'tbpOrganizarEntrega
      '
      Me.tbpOrganizarEntrega.BackColor = System.Drawing.SystemColors.Control
      Me.tbpOrganizarEntrega.Controls.Add(Me.grpOrganizarEntrega)
      Me.tbpOrganizarEntrega.Location = New System.Drawing.Point(4, 22)
      Me.tbpOrganizarEntrega.Name = "tbpOrganizarEntrega"
      Me.tbpOrganizarEntrega.Size = New System.Drawing.Size(882, 298)
      Me.tbpOrganizarEntrega.TabIndex = 2
      Me.tbpOrganizarEntrega.Text = "Organizar Entrega"
      '
      'grpOrganizarEntrega
      '
      Me.grpOrganizarEntrega.Controls.Add(Me.chbGenerarRepartoPermiteDistintasFechasEnvio)
      Me.grpOrganizarEntrega.Controls.Add(Me.lblOrganizarEntregaFiltroFechaDesde2)
      Me.grpOrganizarEntrega.Controls.Add(Me.txtOrganizarEntregaFiltroFechaDesde)
      Me.grpOrganizarEntrega.Controls.Add(Me.lblOrganizarEntregaFiltroFechaDesde)
      Me.grpOrganizarEntrega.Controls.Add(Me.cmbOrganizarEntregaFiltroImpreso)
      Me.grpOrganizarEntrega.Controls.Add(Me.lblOrganizarEntregaFiltroImpreso)
      Me.grpOrganizarEntrega.Controls.Add(Me.chbOrganizarEntregaFiltraFechaEnvio)
      Me.grpOrganizarEntrega.Controls.Add(Me.cboFormasPagoOrgEntregas)
      Me.grpOrganizarEntrega.Controls.Add(Me.lblFormasPagoOrgEntregas)
      Me.grpOrganizarEntrega.Location = New System.Drawing.Point(41, 17)
      Me.grpOrganizarEntrega.Name = "grpOrganizarEntrega"
      Me.grpOrganizarEntrega.Size = New System.Drawing.Size(788, 93)
      Me.grpOrganizarEntrega.TabIndex = 3
      Me.grpOrganizarEntrega.TabStop = False
      Me.grpOrganizarEntrega.Text = "Organizar Entrega"
      '
      'chbGenerarRepartoPermiteDistintasFechasEnvio
      '
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.AutoSize = True
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.BindearPropiedadControl = Nothing
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.BindearPropiedadEntidad = Nothing
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.ForeColorFocus = System.Drawing.Color.Red
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.IsPK = False
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.IsRequired = False
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.Key = Nothing
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.LabelAsoc = Nothing
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.Location = New System.Drawing.Point(116, 70)
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.Name = "chbGenerarRepartoPermiteDistintasFechasEnvio"
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.Size = New System.Drawing.Size(403, 17)
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.TabIndex = 8
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.Text = "Organizar Entrega (v2) permite Generar Repartos con distintas Fechas de Envío"
      Me.chbGenerarRepartoPermiteDistintasFechasEnvio.UseVisualStyleBackColor = True
      '
      'lblOrganizarEntregaFiltroFechaDesde2
      '
      Me.lblOrganizarEntregaFiltroFechaDesde2.AutoSize = True
      Me.lblOrganizarEntregaFiltroFechaDesde2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblOrganizarEntregaFiltroFechaDesde2.LabelAsoc = Nothing
      Me.lblOrganizarEntregaFiltroFechaDesde2.Location = New System.Drawing.Point(675, 50)
      Me.lblOrganizarEntregaFiltroFechaDesde2.Name = "lblOrganizarEntregaFiltroFechaDesde2"
      Me.lblOrganizarEntregaFiltroFechaDesde2.Size = New System.Drawing.Size(28, 13)
      Me.lblOrganizarEntregaFiltroFechaDesde2.TabIndex = 7
      Me.lblOrganizarEntregaFiltroFechaDesde2.Text = "días"
      '
      'txtOrganizarEntregaFiltroFechaDesde
      '
      Me.txtOrganizarEntregaFiltroFechaDesde.BindearPropiedadControl = Nothing
      Me.txtOrganizarEntregaFiltroFechaDesde.BindearPropiedadEntidad = Nothing
      Me.txtOrganizarEntregaFiltroFechaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.txtOrganizarEntregaFiltroFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtOrganizarEntregaFiltroFechaDesde.Formato = ""
      Me.txtOrganizarEntregaFiltroFechaDesde.IsDecimal = True
      Me.txtOrganizarEntregaFiltroFechaDesde.IsNumber = True
      Me.txtOrganizarEntregaFiltroFechaDesde.IsPK = False
      Me.txtOrganizarEntregaFiltroFechaDesde.IsRequired = False
      Me.txtOrganizarEntregaFiltroFechaDesde.Key = ""
      Me.txtOrganizarEntregaFiltroFechaDesde.LabelAsoc = Me.lblOrganizarEntregaFiltroFechaDesde
      Me.txtOrganizarEntregaFiltroFechaDesde.Location = New System.Drawing.Point(634, 47)
      Me.txtOrganizarEntregaFiltroFechaDesde.MaxLength = 3
      Me.txtOrganizarEntregaFiltroFechaDesde.Name = "txtOrganizarEntregaFiltroFechaDesde"
      Me.txtOrganizarEntregaFiltroFechaDesde.Size = New System.Drawing.Size(35, 20)
      Me.txtOrganizarEntregaFiltroFechaDesde.TabIndex = 6
      Me.txtOrganizarEntregaFiltroFechaDesde.Tag = ""
      Me.txtOrganizarEntregaFiltroFechaDesde.Text = "0"
      Me.txtOrganizarEntregaFiltroFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblOrganizarEntregaFiltroFechaDesde
      '
      Me.lblOrganizarEntregaFiltroFechaDesde.AutoSize = True
      Me.lblOrganizarEntregaFiltroFechaDesde.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblOrganizarEntregaFiltroFechaDesde.LabelAsoc = Me.lblOrganizarEntregaFiltroFechaDesde2
      Me.lblOrganizarEntregaFiltroFechaDesde.Location = New System.Drawing.Point(432, 50)
      Me.lblOrganizarEntregaFiltroFechaDesde.Name = "lblOrganizarEntregaFiltroFechaDesde"
      Me.lblOrganizarEntregaFiltroFechaDesde.Size = New System.Drawing.Size(196, 13)
      Me.lblOrganizarEntregaFiltroFechaDesde.TabIndex = 5
      Me.lblOrganizarEntregaFiltroFechaDesde.Text = "Impresión Masiva: Fecha desde Hoy +/-"
      '
      'cmbOrganizarEntregaFiltroImpreso
      '
      Me.cmbOrganizarEntregaFiltroImpreso.BindearPropiedadControl = Nothing
      Me.cmbOrganizarEntregaFiltroImpreso.BindearPropiedadEntidad = Nothing
      Me.cmbOrganizarEntregaFiltroImpreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbOrganizarEntregaFiltroImpreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbOrganizarEntregaFiltroImpreso.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbOrganizarEntregaFiltroImpreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbOrganizarEntregaFiltroImpreso.FormattingEnabled = True
      Me.cmbOrganizarEntregaFiltroImpreso.IsPK = False
      Me.cmbOrganizarEntregaFiltroImpreso.IsRequired = False
      Me.cmbOrganizarEntregaFiltroImpreso.Key = Nothing
      Me.cmbOrganizarEntregaFiltroImpreso.LabelAsoc = Me.lblOrganizarEntregaFiltroImpreso
      Me.cmbOrganizarEntregaFiltroImpreso.Location = New System.Drawing.Point(634, 19)
      Me.cmbOrganizarEntregaFiltroImpreso.Name = "cmbOrganizarEntregaFiltroImpreso"
      Me.cmbOrganizarEntregaFiltroImpreso.Size = New System.Drawing.Size(122, 21)
      Me.cmbOrganizarEntregaFiltroImpreso.TabIndex = 4
      Me.cmbOrganizarEntregaFiltroImpreso.Tag = "ORGANIZARENTREGASFORMADEPAGO"
      '
      'lblOrganizarEntregaFiltroImpreso
      '
      Me.lblOrganizarEntregaFiltroImpreso.AutoSize = True
      Me.lblOrganizarEntregaFiltroImpreso.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblOrganizarEntregaFiltroImpreso.LabelAsoc = Nothing
      Me.lblOrganizarEntregaFiltroImpreso.Location = New System.Drawing.Point(432, 22)
      Me.lblOrganizarEntregaFiltroImpreso.Name = "lblOrganizarEntregaFiltroImpreso"
      Me.lblOrganizarEntregaFiltroImpreso.Size = New System.Drawing.Size(157, 13)
      Me.lblOrganizarEntregaFiltroImpreso.TabIndex = 3
      Me.lblOrganizarEntregaFiltroImpreso.Text = "Impresión Masiva: Filtro Impreso"
      '
      'chbOrganizarEntregaFiltraFechaEnvio
      '
      Me.chbOrganizarEntregaFiltraFechaEnvio.AutoSize = True
      Me.chbOrganizarEntregaFiltraFechaEnvio.BindearPropiedadControl = Nothing
      Me.chbOrganizarEntregaFiltraFechaEnvio.BindearPropiedadEntidad = Nothing
      Me.chbOrganizarEntregaFiltraFechaEnvio.ForeColorFocus = System.Drawing.Color.Red
      Me.chbOrganizarEntregaFiltraFechaEnvio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbOrganizarEntregaFiltraFechaEnvio.IsPK = False
      Me.chbOrganizarEntregaFiltraFechaEnvio.IsRequired = False
      Me.chbOrganizarEntregaFiltraFechaEnvio.Key = Nothing
      Me.chbOrganizarEntregaFiltraFechaEnvio.LabelAsoc = Nothing
      Me.chbOrganizarEntregaFiltraFechaEnvio.Location = New System.Drawing.Point(116, 46)
      Me.chbOrganizarEntregaFiltraFechaEnvio.Name = "chbOrganizarEntregaFiltraFechaEnvio"
      Me.chbOrganizarEntregaFiltraFechaEnvio.Size = New System.Drawing.Size(246, 17)
      Me.chbOrganizarEntregaFiltraFechaEnvio.TabIndex = 2
      Me.chbOrganizarEntregaFiltraFechaEnvio.Text = "Organizar Entrega (v2) filtra por fecha de envio"
      Me.chbOrganizarEntregaFiltraFechaEnvio.UseVisualStyleBackColor = True
      '
      'cboFormasPagoOrgEntregas
      '
      Me.cboFormasPagoOrgEntregas.BindearPropiedadControl = Nothing
      Me.cboFormasPagoOrgEntregas.BindearPropiedadEntidad = Nothing
      Me.cboFormasPagoOrgEntregas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboFormasPagoOrgEntregas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboFormasPagoOrgEntregas.ForeColorFocus = System.Drawing.Color.Red
      Me.cboFormasPagoOrgEntregas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboFormasPagoOrgEntregas.FormattingEnabled = True
      Me.cboFormasPagoOrgEntregas.IsPK = False
      Me.cboFormasPagoOrgEntregas.IsRequired = False
      Me.cboFormasPagoOrgEntregas.Key = Nothing
      Me.cboFormasPagoOrgEntregas.LabelAsoc = Me.lblFormasPagoOrgEntregas
      Me.cboFormasPagoOrgEntregas.Location = New System.Drawing.Point(240, 19)
      Me.cboFormasPagoOrgEntregas.Name = "cboFormasPagoOrgEntregas"
      Me.cboFormasPagoOrgEntregas.Size = New System.Drawing.Size(122, 21)
      Me.cboFormasPagoOrgEntregas.TabIndex = 1
      Me.cboFormasPagoOrgEntregas.Tag = "ORGANIZARENTREGASFORMADEPAGO"
      '
      'lblFormasPagoOrgEntregas
      '
      Me.lblFormasPagoOrgEntregas.AutoSize = True
      Me.lblFormasPagoOrgEntregas.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFormasPagoOrgEntregas.LabelAsoc = Nothing
      Me.lblFormasPagoOrgEntregas.Location = New System.Drawing.Point(63, 22)
      Me.lblFormasPagoOrgEntregas.Name = "lblFormasPagoOrgEntregas"
      Me.lblFormasPagoOrgEntregas.Size = New System.Drawing.Size(172, 13)
      Me.lblFormasPagoOrgEntregas.TabIndex = 0
      Me.lblFormasPagoOrgEntregas.Text = "Forma de Pago Organizar Entregas"
      '
      'tbpConsolidadoCarga
      '
      Me.tbpConsolidadoCarga.BackColor = System.Drawing.SystemColors.Control
      Me.tbpConsolidadoCarga.Controls.Add(Me.ConsolidadoCarga)
      Me.tbpConsolidadoCarga.Location = New System.Drawing.Point(4, 22)
      Me.tbpConsolidadoCarga.Name = "tbpConsolidadoCarga"
      Me.tbpConsolidadoCarga.Size = New System.Drawing.Size(882, 298)
      Me.tbpConsolidadoCarga.TabIndex = 3
      Me.tbpConsolidadoCarga.Text = "Consolidado de Carga"
      '
      'ConsolidadoCarga
      '
      Me.ConsolidadoCarga.Controls.Add(Me.chbConsolidadoCargaOrdenIdProducto)
      Me.ConsolidadoCarga.Location = New System.Drawing.Point(44, 20)
      Me.ConsolidadoCarga.Name = "ConsolidadoCarga"
      Me.ConsolidadoCarga.Size = New System.Drawing.Size(788, 43)
      Me.ConsolidadoCarga.TabIndex = 4
      Me.ConsolidadoCarga.TabStop = False
      Me.ConsolidadoCarga.Text = "Consolidado de Carga"
      '
      'chbConsolidadoCargaOrdenIdProducto
      '
      Me.chbConsolidadoCargaOrdenIdProducto.AutoSize = True
      Me.chbConsolidadoCargaOrdenIdProducto.BindearPropiedadControl = Nothing
      Me.chbConsolidadoCargaOrdenIdProducto.BindearPropiedadEntidad = Nothing
      Me.chbConsolidadoCargaOrdenIdProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbConsolidadoCargaOrdenIdProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbConsolidadoCargaOrdenIdProducto.IsPK = False
      Me.chbConsolidadoCargaOrdenIdProducto.IsRequired = False
      Me.chbConsolidadoCargaOrdenIdProducto.Key = Nothing
      Me.chbConsolidadoCargaOrdenIdProducto.LabelAsoc = Nothing
      Me.chbConsolidadoCargaOrdenIdProducto.Location = New System.Drawing.Point(218, 19)
      Me.chbConsolidadoCargaOrdenIdProducto.Name = "chbConsolidadoCargaOrdenIdProducto"
      Me.chbConsolidadoCargaOrdenIdProducto.Size = New System.Drawing.Size(341, 17)
      Me.chbConsolidadoCargaOrdenIdProducto.TabIndex = 0
      Me.chbConsolidadoCargaOrdenIdProducto.Tag = "MAILREQUIERESSL"
      Me.chbConsolidadoCargaOrdenIdProducto.Text = "Consolidado de Carga se Emite Ordenado con Codigo de Producto"
      Me.chbConsolidadoCargaOrdenIdProducto.UseVisualStyleBackColor = True
      '
      'tbpRegistraciónPagosContraEntrega
      '
      Me.tbpRegistraciónPagosContraEntrega.BackColor = System.Drawing.SystemColors.Control
      Me.tbpRegistraciónPagosContraEntrega.Controls.Add(Me.grpRegistracionPagos)
      Me.tbpRegistraciónPagosContraEntrega.Location = New System.Drawing.Point(4, 22)
      Me.tbpRegistraciónPagosContraEntrega.Name = "tbpRegistraciónPagosContraEntrega"
      Me.tbpRegistraciónPagosContraEntrega.Size = New System.Drawing.Size(882, 298)
      Me.tbpRegistraciónPagosContraEntrega.TabIndex = 4
      Me.tbpRegistraciónPagosContraEntrega.Text = "Registración de Pagos contra Entrega"
      '
      'grpRegistracionPagos
      '
      Me.grpRegistracionPagos.Controls.Add(Me.cmbRegistracionPagosModoConsultarComprobantes)
      Me.grpRegistracionPagos.Controls.Add(Me.lblRegistracionPagosModoConsultarComprobantes)
      Me.grpRegistracionPagos.Controls.Add(Me.cmbRegistracionPagosTipoMovimiento)
      Me.grpRegistracionPagos.Controls.Add(Me.lblRegistracionPagosTipoMovimiento)
      Me.grpRegistracionPagos.Location = New System.Drawing.Point(46, 19)
      Me.grpRegistracionPagos.Name = "grpRegistracionPagos"
      Me.grpRegistracionPagos.Size = New System.Drawing.Size(788, 43)
      Me.grpRegistracionPagos.TabIndex = 5
      Me.grpRegistracionPagos.TabStop = False
      Me.grpRegistracionPagos.Text = "Registración de Pagos contra Entrega"
      '
      'cmbRegistracionPagosModoConsultarComprobantes
      '
      Me.cmbRegistracionPagosModoConsultarComprobantes.BindearPropiedadControl = Nothing
      Me.cmbRegistracionPagosModoConsultarComprobantes.BindearPropiedadEntidad = Nothing
      Me.cmbRegistracionPagosModoConsultarComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRegistracionPagosModoConsultarComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbRegistracionPagosModoConsultarComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRegistracionPagosModoConsultarComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRegistracionPagosModoConsultarComprobantes.FormattingEnabled = True
      Me.cmbRegistracionPagosModoConsultarComprobantes.IsPK = False
      Me.cmbRegistracionPagosModoConsultarComprobantes.IsRequired = False
      Me.cmbRegistracionPagosModoConsultarComprobantes.Key = Nothing
      Me.cmbRegistracionPagosModoConsultarComprobantes.LabelAsoc = Me.lblRegistracionPagosModoConsultarComprobantes
      Me.cmbRegistracionPagosModoConsultarComprobantes.Location = New System.Drawing.Point(599, 17)
      Me.cmbRegistracionPagosModoConsultarComprobantes.Name = "cmbRegistracionPagosModoConsultarComprobantes"
      Me.cmbRegistracionPagosModoConsultarComprobantes.Size = New System.Drawing.Size(122, 21)
      Me.cmbRegistracionPagosModoConsultarComprobantes.TabIndex = 3
      Me.cmbRegistracionPagosModoConsultarComprobantes.Tag = ""
      '
      'lblRegistracionPagosModoConsultarComprobantes
      '
      Me.lblRegistracionPagosModoConsultarComprobantes.AutoSize = True
      Me.lblRegistracionPagosModoConsultarComprobantes.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRegistracionPagosModoConsultarComprobantes.LabelAsoc = Nothing
      Me.lblRegistracionPagosModoConsultarComprobantes.Location = New System.Drawing.Point(465, 20)
      Me.lblRegistracionPagosModoConsultarComprobantes.Name = "lblRegistracionPagosModoConsultarComprobantes"
      Me.lblRegistracionPagosModoConsultarComprobantes.Size = New System.Drawing.Size(128, 13)
      Me.lblRegistracionPagosModoConsultarComprobantes.TabIndex = 2
      Me.lblRegistracionPagosModoConsultarComprobantes.Text = "Comprobantes del reparto"
      '
      'cmbRegistracionPagosTipoMovimiento
      '
      Me.cmbRegistracionPagosTipoMovimiento.BindearPropiedadControl = Nothing
      Me.cmbRegistracionPagosTipoMovimiento.BindearPropiedadEntidad = Nothing
      Me.cmbRegistracionPagosTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRegistracionPagosTipoMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbRegistracionPagosTipoMovimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRegistracionPagosTipoMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRegistracionPagosTipoMovimiento.FormattingEnabled = True
      Me.cmbRegistracionPagosTipoMovimiento.IsPK = False
      Me.cmbRegistracionPagosTipoMovimiento.IsRequired = False
      Me.cmbRegistracionPagosTipoMovimiento.Key = Nothing
      Me.cmbRegistracionPagosTipoMovimiento.LabelAsoc = Me.lblRegistracionPagosTipoMovimiento
      Me.cmbRegistracionPagosTipoMovimiento.Location = New System.Drawing.Point(218, 17)
      Me.cmbRegistracionPagosTipoMovimiento.Name = "cmbRegistracionPagosTipoMovimiento"
      Me.cmbRegistracionPagosTipoMovimiento.Size = New System.Drawing.Size(122, 21)
      Me.cmbRegistracionPagosTipoMovimiento.TabIndex = 1
      Me.cmbRegistracionPagosTipoMovimiento.Tag = ""
      '
      'lblRegistracionPagosTipoMovimiento
      '
      Me.lblRegistracionPagosTipoMovimiento.AutoSize = True
      Me.lblRegistracionPagosTipoMovimiento.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRegistracionPagosTipoMovimiento.LabelAsoc = Nothing
      Me.lblRegistracionPagosTipoMovimiento.Location = New System.Drawing.Point(41, 20)
      Me.lblRegistracionPagosTipoMovimiento.Name = "lblRegistracionPagosTipoMovimiento"
      Me.lblRegistracionPagosTipoMovimiento.Size = New System.Drawing.Size(161, 13)
      Me.lblRegistracionPagosTipoMovimiento.TabIndex = 0
      Me.lblRegistracionPagosTipoMovimiento.Text = "Tipo de movimiento para Cambio"
      '
      'ucConfLogistica
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.TabControl1)
      Me.Name = "ucConfLogistica"
      Me.Controls.SetChildIndex(Me.TabControl1, 0)
      Me.TabControl1.ResumeLayout(False)
      Me.tbpGenerarArchivos.ResumeLayout(False)
      Me.grpGenerarArchivos.ResumeLayout(False)
      Me.grpGenerarArchivos.PerformLayout()
      Me.tbpPreventa.ResumeLayout(False)
      Me.GroupBox15.ResumeLayout(False)
      Me.GroupBox15.PerformLayout()
      Me.grpPreventaV2ImportaDescuentos.ResumeLayout(False)
      Me.grpPreventaV2ImportaDescuentos.PerformLayout()
      Me.tbpOrganizarEntrega.ResumeLayout(False)
      Me.grpOrganizarEntrega.ResumeLayout(False)
      Me.grpOrganizarEntrega.PerformLayout()
      Me.tbpConsolidadoCarga.ResumeLayout(False)
      Me.ConsolidadoCarga.ResumeLayout(False)
      Me.ConsolidadoCarga.PerformLayout()
      Me.tbpRegistraciónPagosContraEntrega.ResumeLayout(False)
      Me.grpRegistracionPagos.ResumeLayout(False)
      Me.grpRegistracionPagos.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents TabControl1 As TabControl
   Friend WithEvents tbpGenerarArchivos As TabPage
   Friend WithEvents tbpPreventa As TabPage
   Friend WithEvents tbpOrganizarEntrega As TabPage
   Friend WithEvents tbpConsolidadoCarga As TabPage
   Friend WithEvents tbpRegistraciónPagosContraEntrega As TabPage
   Friend WithEvents grpGenerarArchivos As GroupBox
   Friend WithEvents txtDestinoArchivosParaMoviles As Controles.TextBox
   Friend WithEvents lblDestinoArchivosParaMoviles As Controles.Label
   Friend WithEvents cmdDestinoArchivosParaMovilesExaminar As Button
   Friend WithEvents cmbFormatoExportacion1 As Controles.ComboBox
   Friend WithEvents lblFormatoExportacion As Controles.Label
   Friend WithEvents chbIncluirEsCambiableEsBonificable As Controles.CheckBox
   Friend WithEvents chbExportarPreciosConIVA1 As Controles.CheckBox
   Friend WithEvents GroupBox15 As GroupBox
   Friend WithEvents chbPreVentaAgrupaOrdenProductoEnCadaPedido As Controles.CheckBox
   Friend WithEvents lblPreventaImprimirPedidos As Controles.Label
   Friend WithEvents grpPreventaV2ImportaDescuentos As GroupBox
   Friend WithEvents chbPreventaV2ImportaDescuentosPedidosPDA As Controles.CheckBox
   Friend WithEvents chbPreventaV2ImportaDescuentosSiMovilWeb As Controles.CheckBox
   Friend WithEvents cmbPreventaImprimirPedidos As Controles.ComboBox
   Friend WithEvents cmbPreVentaAccionSinListaPrecios As Controles.ComboBox
   Friend WithEvents lblPreVentaAccionSinListaPrecios As Controles.Label
   Friend WithEvents chbPreventaRespetaPrecioDelMovil As Controles.CheckBox
   Friend WithEvents chbPreventaV2RespetaListaPreciosCliente As Controles.CheckBox
   Friend WithEvents grpOrganizarEntrega As GroupBox
   Friend WithEvents chbGenerarRepartoPermiteDistintasFechasEnvio As Controles.CheckBox
   Friend WithEvents lblOrganizarEntregaFiltroFechaDesde2 As Controles.Label
   Friend WithEvents txtOrganizarEntregaFiltroFechaDesde As Controles.TextBox
   Friend WithEvents lblOrganizarEntregaFiltroFechaDesde As Controles.Label
   Friend WithEvents cmbOrganizarEntregaFiltroImpreso As Controles.ComboBox
   Friend WithEvents lblOrganizarEntregaFiltroImpreso As Controles.Label
   Friend WithEvents chbOrganizarEntregaFiltraFechaEnvio As Controles.CheckBox
   Friend WithEvents cboFormasPagoOrgEntregas As Controles.ComboBox
   Friend WithEvents lblFormasPagoOrgEntregas As Controles.Label
   Friend WithEvents ConsolidadoCarga As GroupBox
   Friend WithEvents chbConsolidadoCargaOrdenIdProducto As Controles.CheckBox
   Friend WithEvents grpRegistracionPagos As GroupBox
   Friend WithEvents cmbRegistracionPagosModoConsultarComprobantes As Controles.ComboBox
   Friend WithEvents lblRegistracionPagosModoConsultarComprobantes As Controles.Label
   Friend WithEvents cmbRegistracionPagosTipoMovimiento As Controles.ComboBox
   Friend WithEvents lblRegistracionPagosTipoMovimiento As Controles.Label
End Class
