<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActualizarPreciosCompras
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.dgvProductos = New Eniac.Controles.DataGridView()
      Me.Selec = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.NrosSerie = New System.Windows.Forms.DataGridViewButtonColumn()
      Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PrecioO = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PrecioCostoNuevo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PorcRecarg = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PrecioVenta1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PrecioVentaNuevo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescuentoRecargoPorc = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescuentoRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DescRecGeneral = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PorcentajeIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IVAProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TotalProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PrecioLista = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Iva = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.MovimientoCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ProductoSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colIdLote = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.VtoLote = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaActualizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCentroCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCentroCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tspMenu = New System.Windows.Forms.ToolStrip()
      Me.tsbActualizar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.chbPrecioVenta = New Eniac.Controles.CheckBox()
      Me.txtAjusteA = New Eniac.Controles.TextBox()
      Me.chbAjusteA = New Eniac.Controles.CheckBox()
      Me.txtRedondeoPrecioVenta = New Eniac.Controles.TextBox()
      Me.lblRedondeoPrecioVenta = New Eniac.Controles.Label()
      Me.chbActualizarPCosto = New Eniac.Controles.CheckBox()
      CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tspMenu.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'dgvProductos
      '
      Me.dgvProductos.AllowUserToAddRows = False
      Me.dgvProductos.AllowUserToDeleteRows = False
      Me.dgvProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selec, Me.NrosSerie, Me.IdProducto, Me.NombreProducto, Me.Cantidad, Me.PrecioO, Me.PrecioCostoNuevo, Me.PorcRecarg, Me.PrecioVenta1, Me.PrecioVentaNuevo, Me.DescuentoRecargoPorc, Me.DescuentoRecargo, Me.DescRecGeneral, Me.Stock, Me.Importe, Me.PorcentajeIVA, Me.IVAProducto, Me.TotalProducto, Me.PrecioLista, Me.Utilidad, Me.Password, Me.CentroEmisor, Me.Costo, Me.Usuario, Me.NroComprobante, Me.TipoDocumento, Me.NroDocumento, Me.IdSucursal, Me.TipoComprobante, Me.letra, Me.Iva, Me.MovimientoCompra, Me.ProductoSucursal, Me.colIdLote, Me.VtoLote, Me.Orden, Me.Precio, Me.IdConcepto, Me.NombreConcepto, Me.FechaActualizacion, Me.CentroCosto, Me.IdCentroCosto, Me.NombreCentroCosto})
      Me.dgvProductos.Location = New System.Drawing.Point(9, 91)
      Me.dgvProductos.Name = "dgvProductos"
      Me.dgvProductos.RowHeadersVisible = False
      Me.dgvProductos.RowHeadersWidth = 20
      Me.dgvProductos.Size = New System.Drawing.Size(925, 364)
      Me.dgvProductos.TabIndex = 7
      '
      'Selec
      '
      Me.Selec.HeaderText = ""
      Me.Selec.Name = "Selec"
      Me.Selec.Width = 30
      '
      'NrosSerie
      '
      Me.NrosSerie.HeaderText = "Nros Serie"
      Me.NrosSerie.Name = "NrosSerie"
      Me.NrosSerie.Visible = False
      Me.NrosSerie.Width = 40
      '
      'IdProducto
      '
      Me.IdProducto.DataPropertyName = "IdProducto"
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.IdProducto.DefaultCellStyle = DataGridViewCellStyle1
      Me.IdProducto.HeaderText = "Código"
      Me.IdProducto.Name = "IdProducto"
      Me.IdProducto.ReadOnly = True
      Me.IdProducto.ToolTipText = "Código del producto"
      '
      'NombreProducto
      '
      Me.NombreProducto.DataPropertyName = "NombreProducto"
      Me.NombreProducto.HeaderText = "Descripción"
      Me.NombreProducto.Name = "NombreProducto"
      Me.NombreProducto.ReadOnly = True
      Me.NombreProducto.Width = 200
      '
      'Cantidad
      '
      Me.Cantidad.DataPropertyName = "Cantidad"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle2.Format = "N2"
      DataGridViewCellStyle2.NullValue = Nothing
      Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle2
      Me.Cantidad.HeaderText = "Cantidad"
      Me.Cantidad.Name = "Cantidad"
      Me.Cantidad.ReadOnly = True
      Me.Cantidad.Width = 60
      '
      'PrecioO
      '
      Me.PrecioO.DataPropertyName = "PrecioCostoO"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle3.Format = "N2"
      DataGridViewCellStyle3.NullValue = Nothing
      Me.PrecioO.DefaultCellStyle = DataGridViewCellStyle3
      Me.PrecioO.HeaderText = "Costo Actual"
      Me.PrecioO.Name = "PrecioO"
      Me.PrecioO.ReadOnly = True
      Me.PrecioO.Width = 60
      '
      'PrecioCostoNuevo
      '
      Me.PrecioCostoNuevo.DataPropertyName = "PrecioCostoNuevo"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      DataGridViewCellStyle4.Format = "N2"
      DataGridViewCellStyle4.NullValue = Nothing
      Me.PrecioCostoNuevo.DefaultCellStyle = DataGridViewCellStyle4
      Me.PrecioCostoNuevo.HeaderText = "Nuevo Costo"
      Me.PrecioCostoNuevo.Name = "PrecioCostoNuevo"
      Me.PrecioCostoNuevo.Width = 60
      '
      'PorcRecarg
      '
      Me.PorcRecarg.DataPropertyName = "PorcentRecargo"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      DataGridViewCellStyle5.Format = "N2"
      DataGridViewCellStyle5.NullValue = Nothing
      Me.PorcRecarg.DefaultCellStyle = DataGridViewCellStyle5
      Me.PorcRecarg.HeaderText = "% Recargo"
      Me.PorcRecarg.Name = "PorcRecarg"
      Me.PorcRecarg.Width = 60
      '
      'PrecioVenta1
      '
      Me.PrecioVenta1.DataPropertyName = "PrecioVentaActual"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle6.Format = "N2"
      DataGridViewCellStyle6.NullValue = Nothing
      Me.PrecioVenta1.DefaultCellStyle = DataGridViewCellStyle6
      Me.PrecioVenta1.HeaderText = "Precio Venta"
      Me.PrecioVenta1.Name = "PrecioVenta1"
      Me.PrecioVenta1.ReadOnly = True
      Me.PrecioVenta1.Width = 60
      '
      'PrecioVentaNuevo
      '
      Me.PrecioVentaNuevo.DataPropertyName = "PrecioVentaNuevo"
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      DataGridViewCellStyle7.Format = "N2"
      DataGridViewCellStyle7.NullValue = Nothing
      Me.PrecioVentaNuevo.DefaultCellStyle = DataGridViewCellStyle7
      Me.PrecioVentaNuevo.HeaderText = "Precio Venta Nuevo"
      Me.PrecioVentaNuevo.Name = "PrecioVentaNuevo"
      Me.PrecioVentaNuevo.Width = 60
      '
      'DescuentoRecargoPorc
      '
      Me.DescuentoRecargoPorc.DataPropertyName = "DescuentoRecargoPorc"
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle8.Format = "N2"
      Me.DescuentoRecargoPorc.DefaultCellStyle = DataGridViewCellStyle8
      Me.DescuentoRecargoPorc.HeaderText = "% D./R."
      Me.DescuentoRecargoPorc.Name = "DescuentoRecargoPorc"
      Me.DescuentoRecargoPorc.Visible = False
      Me.DescuentoRecargoPorc.Width = 55
      '
      'DescuentoRecargo
      '
      Me.DescuentoRecargo.DataPropertyName = "DescuentoRecargo"
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle9.Format = "N2"
      DataGridViewCellStyle9.NullValue = Nothing
      Me.DescuentoRecargo.DefaultCellStyle = DataGridViewCellStyle9
      Me.DescuentoRecargo.HeaderText = "$ D./R."
      Me.DescuentoRecargo.Name = "DescuentoRecargo"
      Me.DescuentoRecargo.Visible = False
      Me.DescuentoRecargo.Width = 55
      '
      'DescRecGeneral
      '
      Me.DescRecGeneral.DataPropertyName = "DescRecGeneral"
      Me.DescRecGeneral.HeaderText = "DescRecGeneral"
      Me.DescRecGeneral.Name = "DescRecGeneral"
      Me.DescRecGeneral.Visible = False
      '
      'Stock
      '
      Me.Stock.DataPropertyName = "Stock"
      DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle10.Format = "N2"
      Me.Stock.DefaultCellStyle = DataGridViewCellStyle10
      Me.Stock.HeaderText = "Stock"
      Me.Stock.Name = "Stock"
      Me.Stock.ReadOnly = True
      Me.Stock.Width = 55
      '
      'Importe
      '
      Me.Importe.DataPropertyName = "ImporteTotal"
      DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle11.Format = "N2"
      DataGridViewCellStyle11.NullValue = Nothing
      Me.Importe.DefaultCellStyle = DataGridViewCellStyle11
      Me.Importe.HeaderText = "Importe"
      Me.Importe.Name = "Importe"
      Me.Importe.Visible = False
      Me.Importe.Width = 70
      '
      'PorcentajeIVA
      '
      Me.PorcentajeIVA.DataPropertyName = "PorcentajeIVA"
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle12.Format = "N1"
      DataGridViewCellStyle12.NullValue = Nothing
      Me.PorcentajeIVA.DefaultCellStyle = DataGridViewCellStyle12
      Me.PorcentajeIVA.HeaderText = "%IVA"
      Me.PorcentajeIVA.Name = "PorcentajeIVA"
      Me.PorcentajeIVA.ReadOnly = True
      Me.PorcentajeIVA.Width = 55
      '
      'IVAProducto
      '
      Me.IVAProducto.DataPropertyName = "IVA"
      DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle13.Format = "N2"
      DataGridViewCellStyle13.NullValue = Nothing
      Me.IVAProducto.DefaultCellStyle = DataGridViewCellStyle13
      Me.IVAProducto.HeaderText = "IVA"
      Me.IVAProducto.Name = "IVAProducto"
      Me.IVAProducto.Visible = False
      Me.IVAProducto.Width = 55
      '
      'TotalProducto
      '
      Me.TotalProducto.DataPropertyName = "TotalProducto"
      DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle14.Format = "N2"
      DataGridViewCellStyle14.NullValue = Nothing
      Me.TotalProducto.DefaultCellStyle = DataGridViewCellStyle14
      Me.TotalProducto.HeaderText = "Total"
      Me.TotalProducto.Name = "TotalProducto"
      Me.TotalProducto.Visible = False
      Me.TotalProducto.Width = 70
      '
      'PrecioLista
      '
      Me.PrecioLista.DataPropertyName = "PrecioLista"
      Me.PrecioLista.HeaderText = "PrecioLista"
      Me.PrecioLista.Name = "PrecioLista"
      Me.PrecioLista.Visible = False
      '
      'Utilidad
      '
      Me.Utilidad.DataPropertyName = "Utilidad"
      Me.Utilidad.HeaderText = "Utilidad"
      Me.Utilidad.Name = "Utilidad"
      Me.Utilidad.Visible = False
      '
      'Password
      '
      Me.Password.DataPropertyName = "Password"
      Me.Password.HeaderText = "Password"
      Me.Password.Name = "Password"
      Me.Password.Visible = False
      '
      'CentroEmisor
      '
      Me.CentroEmisor.DataPropertyName = "CentroEmisor"
      Me.CentroEmisor.HeaderText = "CentroEmisor"
      Me.CentroEmisor.Name = "CentroEmisor"
      Me.CentroEmisor.Visible = False
      '
      'Costo
      '
      Me.Costo.DataPropertyName = "Costo"
      Me.Costo.HeaderText = "Costo"
      Me.Costo.Name = "Costo"
      Me.Costo.Visible = False
      '
      'Usuario
      '
      Me.Usuario.DataPropertyName = "Usuario"
      Me.Usuario.HeaderText = "Usuario"
      Me.Usuario.Name = "Usuario"
      Me.Usuario.Visible = False
      '
      'NroComprobante
      '
      Me.NroComprobante.DataPropertyName = "NumeroComprobante"
      Me.NroComprobante.HeaderText = "NroComprobante"
      Me.NroComprobante.Name = "NroComprobante"
      Me.NroComprobante.Visible = False
      '
      'TipoDocumento
      '
      Me.TipoDocumento.DataPropertyName = "TipoDocumento"
      Me.TipoDocumento.HeaderText = "TipoDocumento"
      Me.TipoDocumento.Name = "TipoDocumento"
      Me.TipoDocumento.Visible = False
      '
      'NroDocumento
      '
      Me.NroDocumento.DataPropertyName = "NroDocumento"
      Me.NroDocumento.HeaderText = "NroDocumento"
      Me.NroDocumento.Name = "NroDocumento"
      Me.NroDocumento.Visible = False
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.Visible = False
      '
      'TipoComprobante
      '
      Me.TipoComprobante.DataPropertyName = "TipoComprobante"
      Me.TipoComprobante.HeaderText = "TipoComprobante"
      Me.TipoComprobante.Name = "TipoComprobante"
      Me.TipoComprobante.Visible = False
      '
      'letra
      '
      Me.letra.DataPropertyName = "Letra"
      Me.letra.HeaderText = "letra"
      Me.letra.Name = "letra"
      Me.letra.Visible = False
      '
      'Iva
      '
      Me.Iva.DataPropertyName = "Iva"
      Me.Iva.HeaderText = "Iva"
      Me.Iva.Name = "Iva"
      Me.Iva.Visible = False
      '
      'MovimientoCompra
      '
      Me.MovimientoCompra.DataPropertyName = "MovimientoCompra"
      Me.MovimientoCompra.HeaderText = "MovimientoCompra"
      Me.MovimientoCompra.Name = "MovimientoCompra"
      Me.MovimientoCompra.Visible = False
      '
      'ProductoSucursal
      '
      Me.ProductoSucursal.DataPropertyName = "ProductoSucursal"
      Me.ProductoSucursal.HeaderText = "ProductoSucursal"
      Me.ProductoSucursal.Name = "ProductoSucursal"
      Me.ProductoSucursal.Visible = False
      '
      'colIdLote
      '
      Me.colIdLote.DataPropertyName = "IdLote"
      Me.colIdLote.HeaderText = "Lote"
      Me.colIdLote.Name = "colIdLote"
      Me.colIdLote.Visible = False
      Me.colIdLote.Width = 80
      '
      'VtoLote
      '
      Me.VtoLote.DataPropertyName = "VtoLote"
      DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      DataGridViewCellStyle15.NullValue = Nothing
      Me.VtoLote.DefaultCellStyle = DataGridViewCellStyle15
      Me.VtoLote.HeaderText = "Vto. Lote"
      Me.VtoLote.Name = "VtoLote"
      Me.VtoLote.Visible = False
      Me.VtoLote.Width = 70
      '
      'Orden
      '
      Me.Orden.DataPropertyName = "Orden"
      Me.Orden.HeaderText = "Orden"
      Me.Orden.Name = "Orden"
      Me.Orden.Visible = False
      '
      'Precio
      '
      Me.Precio.DataPropertyName = "Precio"
      Me.Precio.HeaderText = "Precio"
      Me.Precio.Name = "Precio"
      Me.Precio.Visible = False
      '
      'IdConcepto
      '
      Me.IdConcepto.DataPropertyName = "IdConcepto"
      Me.IdConcepto.HeaderText = "IdConcepto"
      Me.IdConcepto.Name = "IdConcepto"
      Me.IdConcepto.Visible = False
      '
      'NombreConcepto
      '
      Me.NombreConcepto.DataPropertyName = "NombreConcepto"
      Me.NombreConcepto.HeaderText = "NombreConcepto"
      Me.NombreConcepto.Name = "NombreConcepto"
      Me.NombreConcepto.Visible = False
      '
      'FechaActualizacion
      '
      Me.FechaActualizacion.DataPropertyName = "FechaActualizacion"
      DataGridViewCellStyle16.Format = "dd/MM/yyyy"
      Me.FechaActualizacion.DefaultCellStyle = DataGridViewCellStyle16
      Me.FechaActualizacion.HeaderText = "Fecha Act."
      Me.FechaActualizacion.Name = "FechaActualizacion"
      '
      'CentroCosto
      '
      Me.CentroCosto.DataPropertyName = "CentroCosto"
      Me.CentroCosto.HeaderText = "CentroCosto"
      Me.CentroCosto.Name = "CentroCosto"
      Me.CentroCosto.Visible = False
      '
      'IdCentroCosto
      '
      Me.IdCentroCosto.DataPropertyName = "IdCentroCosto"
      Me.IdCentroCosto.HeaderText = "IdCentroCosto"
      Me.IdCentroCosto.Name = "IdCentroCosto"
      Me.IdCentroCosto.Visible = False
      '
      'NombreCentroCosto
      '
      Me.NombreCentroCosto.DataPropertyName = "NombreCentroCosto"
      Me.NombreCentroCosto.HeaderText = "NombreCentroCosto"
      Me.NombreCentroCosto.Name = "NombreCentroCosto"
      Me.NombreCentroCosto.Visible = False
      '
      'tspMenu
      '
      Me.tspMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbActualizar, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tspMenu.Location = New System.Drawing.Point(0, 0)
      Me.tspMenu.Name = "tspMenu"
      Me.tspMenu.Size = New System.Drawing.Size(940, 25)
      Me.tspMenu.TabIndex = 9
      Me.tspMenu.TabStop = True
      Me.tspMenu.Text = "Barra de Menu"
      '
      'tsbActualizar
      '
      Me.tsbActualizar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.tsbActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbActualizar.Name = "tsbActualizar"
      Me.tsbActualizar.Size = New System.Drawing.Size(120, 22)
      Me.tsbActualizar.Text = "&Actualizar Precios"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'chbTodos
      '
      Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(9, 61)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(124, 24)
      Me.chbTodos.TabIndex = 0
      Me.chbTodos.Text = "Chequear Todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 460)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(940, 22)
      Me.stsStado.TabIndex = 8
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(861, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'chbPrecioVenta
      '
      Me.chbPrecioVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chbPrecioVenta.BindearPropiedadControl = Nothing
      Me.chbPrecioVenta.BindearPropiedadEntidad = Nothing
      Me.chbPrecioVenta.Checked = True
      Me.chbPrecioVenta.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbPrecioVenta.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPrecioVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPrecioVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbPrecioVenta.ImageIndex = 1
      Me.chbPrecioVenta.IsPK = False
      Me.chbPrecioVenta.IsRequired = False
      Me.chbPrecioVenta.Key = Nothing
      Me.chbPrecioVenta.LabelAsoc = Nothing
      Me.chbPrecioVenta.Location = New System.Drawing.Point(530, 36)
      Me.chbPrecioVenta.Name = "chbPrecioVenta"
      Me.chbPrecioVenta.Size = New System.Drawing.Size(136, 24)
      Me.chbPrecioVenta.TabIndex = 2
      Me.chbPrecioVenta.Text = "Actualizar Precio Venta"
      Me.chbPrecioVenta.UseVisualStyleBackColor = True
      '
      'txtAjusteA
      '
      Me.txtAjusteA.BindearPropiedadControl = Nothing
      Me.txtAjusteA.BindearPropiedadEntidad = Nothing
      Me.txtAjusteA.ForeColorFocus = System.Drawing.Color.Red
      Me.txtAjusteA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtAjusteA.Formato = "0"
      Me.txtAjusteA.IsDecimal = False
      Me.txtAjusteA.IsNumber = True
      Me.txtAjusteA.IsPK = False
      Me.txtAjusteA.IsRequired = False
      Me.txtAjusteA.Key = ""
      Me.txtAjusteA.LabelAsoc = Nothing
      Me.txtAjusteA.Location = New System.Drawing.Point(887, 38)
      Me.txtAjusteA.MaxLength = 5
      Me.txtAjusteA.Name = "txtAjusteA"
      Me.txtAjusteA.Size = New System.Drawing.Size(31, 20)
      Me.txtAjusteA.TabIndex = 6
      Me.txtAjusteA.Text = "9"
      Me.txtAjusteA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'chbAjusteA
      '
      Me.chbAjusteA.AutoSize = True
      Me.chbAjusteA.BindearPropiedadControl = Nothing
      Me.chbAjusteA.BindearPropiedadEntidad = Nothing
      Me.chbAjusteA.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAjusteA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAjusteA.IsPK = False
      Me.chbAjusteA.IsRequired = False
      Me.chbAjusteA.Key = Nothing
      Me.chbAjusteA.LabelAsoc = Nothing
      Me.chbAjusteA.Location = New System.Drawing.Point(817, 41)
      Me.chbAjusteA.Name = "chbAjusteA"
      Me.chbAjusteA.Size = New System.Drawing.Size(64, 17)
      Me.chbAjusteA.TabIndex = 5
      Me.chbAjusteA.Text = "Ajuste a"
      Me.chbAjusteA.UseVisualStyleBackColor = True
      '
      'txtRedondeoPrecioVenta
      '
      Me.txtRedondeoPrecioVenta.BindearPropiedadControl = Nothing
      Me.txtRedondeoPrecioVenta.BindearPropiedadEntidad = Nothing
      Me.txtRedondeoPrecioVenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRedondeoPrecioVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRedondeoPrecioVenta.Formato = "##0"
      Me.txtRedondeoPrecioVenta.IsDecimal = False
      Me.txtRedondeoPrecioVenta.IsNumber = True
      Me.txtRedondeoPrecioVenta.IsPK = False
      Me.txtRedondeoPrecioVenta.IsRequired = False
      Me.txtRedondeoPrecioVenta.Key = ""
      Me.txtRedondeoPrecioVenta.LabelAsoc = Me.lblRedondeoPrecioVenta
      Me.txtRedondeoPrecioVenta.Location = New System.Drawing.Point(752, 38)
      Me.txtRedondeoPrecioVenta.MaxLength = 1
      Me.txtRedondeoPrecioVenta.Name = "txtRedondeoPrecioVenta"
      Me.txtRedondeoPrecioVenta.Size = New System.Drawing.Size(31, 20)
      Me.txtRedondeoPrecioVenta.TabIndex = 4
      Me.txtRedondeoPrecioVenta.Text = "2"
      Me.txtRedondeoPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblRedondeoPrecioVenta
      '
      Me.lblRedondeoPrecioVenta.AutoSize = True
      Me.lblRedondeoPrecioVenta.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblRedondeoPrecioVenta.Location = New System.Drawing.Point(692, 42)
      Me.lblRedondeoPrecioVenta.Name = "lblRedondeoPrecioVenta"
      Me.lblRedondeoPrecioVenta.Size = New System.Drawing.Size(57, 13)
      Me.lblRedondeoPrecioVenta.TabIndex = 3
      Me.lblRedondeoPrecioVenta.Text = "Redondeo"
      '
      'chbActualizarPCosto
      '
      Me.chbActualizarPCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chbActualizarPCosto.BindearPropiedadControl = Nothing
      Me.chbActualizarPCosto.BindearPropiedadEntidad = Nothing
      Me.chbActualizarPCosto.Checked = True
      Me.chbActualizarPCosto.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbActualizarPCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbActualizarPCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbActualizarPCosto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbActualizarPCosto.ImageIndex = 1
      Me.chbActualizarPCosto.IsPK = False
      Me.chbActualizarPCosto.IsRequired = False
      Me.chbActualizarPCosto.Key = Nothing
      Me.chbActualizarPCosto.LabelAsoc = Nothing
      Me.chbActualizarPCosto.Location = New System.Drawing.Point(371, 37)
      Me.chbActualizarPCosto.Name = "chbActualizarPCosto"
      Me.chbActualizarPCosto.Size = New System.Drawing.Size(136, 24)
      Me.chbActualizarPCosto.TabIndex = 1
      Me.chbActualizarPCosto.Text = "Actualizar Precio Costo"
      Me.chbActualizarPCosto.UseVisualStyleBackColor = True
      '
      'ActualizarPreciosCompras
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(940, 482)
      Me.Controls.Add(Me.chbActualizarPCosto)
      Me.Controls.Add(Me.txtAjusteA)
      Me.Controls.Add(Me.chbAjusteA)
      Me.Controls.Add(Me.txtRedondeoPrecioVenta)
      Me.Controls.Add(Me.lblRedondeoPrecioVenta)
      Me.Controls.Add(Me.chbPrecioVenta)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.chbTodos)
      Me.Controls.Add(Me.tspMenu)
      Me.Controls.Add(Me.dgvProductos)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ActualizarPreciosCompras"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Actualizar Precios de Costo"
      CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tspMenu.ResumeLayout(False)
      Me.tspMenu.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dgvProductos As Eniac.Controles.DataGridView
   Friend WithEvents tspMenu As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbActualizar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chbPrecioVenta As Eniac.Controles.CheckBox
    Friend WithEvents txtAjusteA As Eniac.Controles.TextBox
    Friend WithEvents chbAjusteA As Eniac.Controles.CheckBox
    Friend WithEvents txtRedondeoPrecioVenta As Eniac.Controles.TextBox
    Friend WithEvents lblRedondeoPrecioVenta As Eniac.Controles.Label
   Friend WithEvents chbActualizarPCosto As Eniac.Controles.CheckBox
   Friend WithEvents Selec As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents NrosSerie As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PrecioO As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PrecioCostoNuevo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PorcRecarg As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PrecioVenta1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PrecioVentaNuevo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargoPorc As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescRecGeneral As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PorcentajeIVA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IVAProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PrecioLista As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Utilidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Password As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Costo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Iva As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents MovimientoCompra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ProductoSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colIdLote As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents VtoLote As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaActualizacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCentroCosto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
End Class
