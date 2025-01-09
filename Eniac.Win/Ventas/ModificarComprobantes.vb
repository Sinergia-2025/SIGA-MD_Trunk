Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports System.Text

Public Class ModificarComprobantes

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos
   Private _subTotales As System.Collections.Generic.List(Of Entidades.VentaImpuesto)
   Private _comprobantes As List(Of Entidades.Venta)
   Private _ventasProductos As System.Collections.Generic.List(Of Entidades.VentaProducto)
   Private _clienteE As Entidades.Cliente
   Private _tipoComprobante As String
   Private _letraComprobante As String
   Private _emisor As Short
   Private _numeroComprobante As Long
   Private _facturable As Entidades.Venta
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal

#End Region

#Region "Enumeraciones"

   Private Enum Estados
      Insercion
      Modificacion
   End Enum

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Eniac.Win.Publicos()
         Me._comprobantes = New List(Of Entidades.Venta)

         Me._publicos.CargaComboTiposComprobantesFacturablesReales(Me.cmbTiposComprobantes, False, "VENTAS")

         Me.RefrescarDatosGrilla()

         Me._categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      Dim oCliente As Reglas.Clientes = New Reglas.Clientes()
      Me._clienteE = oCliente.GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now.Date
      Me.dtpHasta.Value = Date.Now.Date

      Me.bscCodigoCliente.Enabled = True
      Me.bscCodigoCliente.Text = ""
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Enabled = True
      Me.bscCliente.Text = ""

      If Me.cmbTiposComprobantes.Items.Count > 0 Then
         'Me.cmbTiposComprobantes.SelectedIndex = 0
         Me.cmbTiposComprobantes.SelectedValue = "REMITO"
      End If

      If Not Me.dgvFacturables.DataSource Is Nothing Then
         DirectCast(Me.dgvFacturables.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtBruto.Text = "0.00"
      Me.txtDescRecGral.Text = "0.00"
      Me.txtDescRecGralPorc.Text = "0.00"
      Me.txtSubtotal.Text = "0.00"
      Me.txtTotalImpuestos.Text = "0.00"
      Me.txtTotal.Text = "0.00"

      If Not Me.dgvProductos.DataSource Is Nothing Then
         Me._ventasProductos.Clear()
         Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

      Dim IdCliente As Long = 0
      Dim TipoComprobante As String = String.Empty

      Try

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            TipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If
         'TipoComprobante = "REMITO"

         Dim Fec1 As Date, Fec2 As Date
         Fec1 = Me.dtpDesde.Value.Date()
         Fec2 = Me.dtpHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oVenta.GetPorRangoFechas({actual.Sucursal}, Fec1, Fec2, , Entidades.OrigenFK.Movimiento, "TODOS", IdCliente, "TODOS", TipoComprobante, 0, , , "PENDIENTE")

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("IdEstadoComprobante") = dr("IdEstadoComprobante").ToString()
            drCl("ImporteBruto") = Decimal.Parse(dr("ImporteBruto").ToString())
            drCl("DescuentoRecargoPorc") = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
            drCl("DescuentoRecargo") = Decimal.Parse(dr("DescuentoRecargo").ToString())
            drCl("SubTotal") = Decimal.Parse(dr("SubTotal").ToString())
            drCl("TotalImpuestos") = Decimal.Parse(dr("TotalImpuestos").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            drCl("Kilos") = Decimal.Parse(dr("Kilos").ToString())

            dt.Rows.Add(drCl)

         Next

         Me.dgvFacturables.DataSource = dt

         Me.tssRegistros.Text = Me.dgvFacturables.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdEstadoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("ImporteBruto", System.Type.GetType("System.Decimal"))
         .Columns.Add("DescuentoRecargoPorc", System.Type.GetType("System.Decimal"))
         .Columns.Add("DescuentoRecargo", System.Type.GetType("System.Decimal"))
         .Columns.Add("SubTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Kilos", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

   Private Sub CargarFacturable()

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Me._facturable = oVentas.GetUna(actual.Sucursal.Id, Me._tipoComprobante, Me._letraComprobante, Me._emisor, Me._numeroComprobante)

      With Me._facturable

         Me.txtBruto.Text = .ImporteBruto.ToString()
         Me.txtDescRecGral.Text = .DescuentoRecargo.ToString()
         Me.txtDescRecGralPorc.Text = .DescuentoRecargoPorc.ToString()
         Me.txtSubtotal.Text = .Subtotal.ToString()
         Me.txtTotalImpuestos.Text = .TotalImpuestos.ToString()
         Me.txtTotal.Text = .ImporteTotal.ToString()

         .ImportePesos = .ImporteTotal
         '.ImporteTarjetas = 0
         .ImporteTickets = 0

         Me.txtKilos.Text = .Kilos.ToString()

      End With

      Me.CargarProductosFacturables(Me._facturable)

      Me.dgvProductos.Columns("pCantidadNueva").ReadOnly = True

   End Sub

   Private Sub CargarProductosFacturables(ByVal Comprobante As Entidades.Venta)

      'limpio todos los productos de la grilla
      Me._ventasProductos = Nothing
      Me._ventasProductos = New List(Of Entidades.VentaProducto)

      Dim DescRec1 As Decimal, DescRec2 As Decimal
      Dim PrecioNeto As Decimal

      For Each vp As Entidades.VentaProducto In Comprobante.VentasProductos

         'Los precios en la BASE siempre se guardan SIN IVA

         'Le agrego el IVA porque al momento de la grabacion se lo saca si cumple con esto. Se devuelve SIN IVA
         If Publicos.PreciosConIVA Then
            vp.PrecioLista = Decimal.Round((vp.PrecioLista * (1 + vp.AlicuotaImpuesto / 100)), 2)
            vp.Costo = Decimal.Round((vp.Costo * (1 + vp.AlicuotaImpuesto / 100)), 2)
            'vp.DescuentoRecargo = Decimal.Round((vp.DescuentoRecargo * (1 + Me._clienteE.CategoriaFiscal.IvaInscripto / 100)), 2)
         End If

         If Not Me._clienteE.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            vp.Precio = Decimal.Round((vp.Precio * (1 + vp.AlicuotaImpuesto / 100)), 2)
            vp.ImporteTotal = Decimal.Round((vp.ImporteTotal * (1 + vp.AlicuotaImpuesto / 100)), 2)
         End If

         'Calculo el Nuevo Descuento Recargo.
         DescRec1 = Decimal.Round((vp.Precio * vp.DescuentoRecargoPorc1 / 100), 2)
         DescRec2 = Decimal.Round(((vp.Precio + DescRec1) * vp.DescuentoRecargoPorc2 / 100), 2)

         vp.DescuentoRecargo = (DescRec1 + DescRec2) * vp.Cantidad

         'Calculo el Nuevo Precio Neto.
         PrecioNeto = vp.Precio + DescRec1 + DescRec2
         PrecioNeto = Decimal.Round(PrecioNeto * (1 + (Decimal.Parse(Me.txtDescRecGralPorc.Text) / 100)), 2)

         vp.PrecioNeto = PrecioNeto

         Me._ventasProductos.Add(vp)

      Next

      'Indico el Orden que quiero verlo en pantalla, no respeta el diseño.
      With Me.dgvProductos
         .Columns("pIdProducto").DisplayIndex = 1
         .Columns("pProductoDesc").DisplayIndex = 2
         .Columns("pCantidad").DisplayIndex = 3
         .Columns("pPrecio").DisplayIndex = 4
         .Columns("pDescuentoRecargoPorc1").DisplayIndex = 5
         .Columns("pDescuentoRecargoPorc2").DisplayIndex = 6
         .Columns("pPrecioNeto").DisplayIndex = 7
         .Columns("pAlicuotaImpuesto").DisplayIndex = 8
         .Columns("pImporteTotal").DisplayIndex = 9
         .Columns("pCantidadNueva").DisplayIndex = 10
         .Columns("pKilos").DisplayIndex = 11
         ' .Columns("pKilosNuevo").DisplayIndex = 12
      End With

      Me.dgvProductos.DataSource = Me._ventasProductos

   End Sub

   Private Function ValidarComprobante() As Boolean

      If Decimal.Parse(Me.txtTotal.Text) = 0 Then
         MessageBox.Show("El total del nuevo comprobante no puede ser 0 (Cero)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      If Decimal.Parse(Me.txtTotal.Text) = Me._facturable.ImporteTotal Then
         MessageBox.Show("El Comprobante No tiene cambios a grabar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      For Each dr As DataGridViewRow In Me.dgvProductos.Rows

         If Not IsNumeric(dr.Cells("pCantidadNueva").Value) Then
            MessageBox.Show("Es incorrecta la Cantidad Nueva del producto '" & dr.Cells("pProductoDesc").Value.ToString() & "'", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If

         If Decimal.Parse(dr.Cells("pCantidadNueva").Value.ToString()) > Decimal.Parse(dr.Cells("pCantidad").Value.ToString()) Then
            MessageBox.Show("La Cantidad Nueva del producto '" & dr.Cells("pProductoDesc").Value.ToString() & "' NO puede ser mayor a la actual", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If

         If Decimal.Parse(dr.Cells("pCantidadNueva").Value.ToString()) < 0 Then
            MessageBox.Show("La Cantidad Nueva del producto '" & dr.Cells("pProductoDesc").Value.ToString() & "' debe ser Mayor o Igual a Cero", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If

      Next

      'For Each Linea As Entidades.VentaProducto In Me._ventasProductos
      '   If Linea.ImporteTotal = 0 Then
      '      MessageBox.Show("No puede haber productos con precio cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '      Return False
      '   End If
      'Next

      Return True

   End Function

   Private Sub GrabarCambios()

      Me.ActualizarCantidades()

      Dim oFaturacion As Reglas.Ventas = New Reglas.Ventas

      With Me._facturable

         .Usuario = actual.Nombre

         .ImporteBruto = Decimal.Parse(Me.txtBruto.Text)
         .DescuentoRecargo = Decimal.Parse(Me.txtDescRecGral.Text)
         .DescuentoRecargoPorc = Decimal.Parse(Me.txtDescRecGralPorc.Text)
         .Subtotal = Decimal.Parse(Me.txtSubtotal.Text)
         .TotalImpuestos = Decimal.Parse(Me.txtTotalImpuestos.Text)
         .ImporteTotal = Decimal.Parse(Me.txtTotal.Text)
         .Kilos = Decimal.Parse(Me.txtKilos.Text)

         .VentasProductos = Me._ventasProductos

         .VentasImpuestos = Me._subTotales

         .ImportePesos = .ImporteTotal
         '.ImporteTarjetas = 0
         .ImporteTickets = 0

      End With

      oFaturacion.ActualizarFacturable(Me._facturable)

   End Sub

   Private Sub CalcularTotalProducto()

      Dim DesctoProd As Decimal
      Dim TotalProd As Decimal

      Dim DescRec1 As Decimal, DescRec2 As Decimal
      Dim DesctoGralProd As Decimal

      Dim Prod As Reglas.Productos = New Reglas.Productos
      Dim oProd As Entidades.Producto
      Dim Kilos As Decimal = 0
      Dim Conversion As Decimal
      Dim oUM As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas

      For Each dr As DataGridViewRow In Me.dgvProductos.Rows

         DescRec1 = Decimal.Round((Decimal.Parse(dr.Cells("pPrecio").Value.ToString()) * Decimal.Parse(dr.Cells("pDescuentoRecargoPorc1").Value.ToString()) / 100), 2)
         DescRec2 = Decimal.Round(((Decimal.Parse(dr.Cells("pPrecio").Value.ToString()) + DescRec1) * Decimal.Parse(dr.Cells("pDescuentoRecargoPorc2").Value.ToString()) / 100), 2)

         DesctoProd = (DescRec1 + DescRec2) * Decimal.Parse(dr.Cells("pCantidadNueva").Value.ToString())

         TotalProd = Decimal.Parse(dr.Cells("pPrecio").Value.ToString()) * Decimal.Parse(dr.Cells("pCantidadNueva").Value.ToString()) + DesctoProd

         dr.Cells("pImporteTotal").Value = TotalProd

         DesctoGralProd = Decimal.Round((TotalProd * Me._facturable.DescuentoRecargoPorc / 100), 2)

         dr.Cells("pDescRecGeneral").Value = DesctoGralProd

         dr.Cells("pImporteTotalNeto").Value = TotalProd + DesctoGralProd

         oProd = Prod.GetUno(dr.Cells("pIdProducto").Value.ToString())

         Kilos = 0
         If oProd.Tamano > 0 Then
            Conversion = oUM.GetUno(oProd.UnidadDeMedida.IdUnidadDeMedida).ConversionAKilos
            Kilos = Decimal.Round(Decimal.Parse(dr.Cells("pCantidadNueva").Value.ToString()) * oProd.Tamano * Conversion, 3)
         End If

         dr.Cells("pKilos").Value = Kilos

      Next

   End Sub

   Private Sub CalcularTotales()

      'Dim oCF As Entidades.CategoriaFiscal = Nothing

      Dim bruto As Decimal = 0
      Dim descuento As Decimal = 0
      Dim subTotal As Decimal = 0
      Dim total As Decimal = 0
      Dim Kilos As Decimal = 0
      Dim iva As Decimal = 0

      'oCF = Me._clienteE.CategoriaFiscal
      'ivaDiscri = oCF.IvaDiscriminado

      Me._subTotales = New System.Collections.Generic.List(Of Entidades.VentaImpuesto)

      Dim oLineaImpuestos As Entidades.VentaImpuesto

      For Each vp As Entidades.VentaProducto In Me._ventasProductos
         Kilos += vp.Kilos

         bruto += (vp.Precio * vp.Cantidad)
         subTotal += vp.ImporteTotalNeto
         iva += vp.ImporteImpuesto
         total += vp.ImporteTotal

         Dim entro As Boolean = False
         For Each vi As Entidades.VentaImpuesto In Me._subTotales
            If vi.Alicuota = vp.AlicuotaImpuesto Then
               vi.TipoImpuesto.IdTipoImpuesto = vp.TipoImpuesto.IdTipoImpuesto
               vi.Bruto += (vp.Precio * vp.Cantidad)
               vi.Neto += vp.ImporteTotalNeto
               vi.Importe += vp.ImporteImpuesto
               vi.Total += vp.ImporteTotal
               entro = True
            End If
         Next

         If Not entro Then
            oLineaImpuestos = New Entidades.VentaImpuesto
            With oLineaImpuestos
               .TipoImpuesto = vp.TipoImpuesto
               .Alicuota = vp.AlicuotaImpuesto
               .Bruto = (vp.Precio * vp.Cantidad)
               .Neto = vp.ImporteTotalNeto
               .Importe = vp.ImporteImpuesto
               .Total = vp.ImporteTotal
            End With
            Me._subTotales.Add(oLineaImpuestos)
         End If

      Next

      bruto = Math.Round(bruto, 2)

      descuento = Decimal.Round((bruto * Me._facturable.DescuentoRecargoPorc / 100), 2)

      Me.txtBruto.Text = bruto.ToString("#,##0.00")
      Me.txtDescRecGral.Text = descuento.ToString()
      'NO hace falta porque no cambia.
      'Me.txtDescRecPorc.Text = Me._facturable.DescuentoRecargoPorc.ToString()
      Me.txtSubtotal.Text = subTotal.ToString("#,##0.00")
      Me.txtTotalImpuestos.Text = iva.ToString("#,##0.00")
      Me.txtTotal.Text = total.ToString("#,##0.00")
      Me.txtKilos.Text = Kilos.ToString("#,##0.00")

      'Marco las diferencias
      With Me._facturable

         'NO ANDA EL CORLOR !!! PORQUE??
         'If .ImporteNoGravado <> noGravado Then
         '   Me.txtNoGravado.ForeColor = System.Drawing.Color.Red
         'Else
         '   Me.txtNoGravado.ForeColor = System.Drawing.Color.Black
         'End If
         'If .Subtotal <> subTotal Then
         '   Me.txtSubtotal.ForeColor = System.Drawing.Color.Red
         'Else
         '   Me.txtSubtotal.ForeColor = System.Drawing.Color.Black
         'End If
         'If .Iva <> ivaInsc Then
         '   Me.txtIvaInscripto.ForeColor = System.Drawing.Color.Red
         'Else
         '   Me.txtIvaInscripto.ForeColor = System.Drawing.Color.Black
         'End If
         'If .ImporteTotal <> total Then
         '   Me.txtTotal.ForeColor = System.Drawing.Color.Red
         'Else
         '   Me.txtTotal.ForeColor = System.Drawing.Color.Black
         'End If

         .ImportePesos = .ImporteTotal
         '.ImporteTarjetas = 0
         .ImporteTickets = 0

         .Kilos = Kilos
      End With

   End Sub

   Private Sub ActualizarCantidades()

      'Cualquiera de las 2 formas hace lo mismo

      'For Each dr As DataGridViewRow In Me.dgvProductos.Rows
      '   If dr.Cells("pCantidad").Value.ToString() <> dr.Cells("pCantidadNueva").Value.ToString() Then
      '      For Each Linea As Entidades.VentaProducto In Me._ventasProductos
      '         If Linea.Orden = Long.Parse(dr.Cells("pOrden").Value.ToString()) Then
      '            Linea.Cantidad = Decimal.Parse(dr.Cells("pCantidadNueva").Value.ToString())
      '            Exit For
      '         End If
      '      Next
      '   End If
      'Next

      For Each dr As DataGridViewRow In Me.dgvProductos.Rows
         dr.Cells("pUsuario").Value = actual.Nombre
         dr.Cells("pCantidad").Value = dr.Cells("pCantidadNueva").Value
      Next

      Me._ventasProductos = DirectCast(Me.dgvProductos.DataSource, System.Collections.Generic.List(Of Entidades.VentaProducto))

   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub EliminarComprobantes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.dgvFacturables.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
      Try

         If Me.cmbTiposComprobantes.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: Debe seleccionar un Tipo de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If

         If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Debe seleccionar un Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.Cursor = Cursors.Default

         If dgvFacturables.Rows.Count > 0 Then
            Me.btnBuscar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvFacturables_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFacturables.CellClick

      If e.RowIndex >= 0 Then
         Me._tipoComprobante = Me.dgvFacturables.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString()
         Me._letraComprobante = Me.dgvFacturables.Rows(e.RowIndex).Cells("Letra").Value.ToString()
         Me._emisor = Short.Parse(Me.dgvFacturables.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString())
         Me._numeroComprobante = Long.Parse(Me.dgvFacturables.Rows(e.RowIndex).Cells("NroComprobante").Value.ToString())

         Me.CargarFacturable()
      End If

   End Sub

   Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click

      If Me.dgvFacturables.SelectedRows.Count = 0 Then Exit Sub

      If Not String.IsNullOrEmpty(Me.dgvFacturables.SelectedRows.Item(0).Cells("IdEstadoComprobante").Value.ToString()) Then
         MessageBox.Show("ATENCION: No puede modificar este comprobante por su estado actual", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Exit Sub
      End If

      Me.dgvProductos.Columns("pCantidadNueva").ReadOnly = False

      For Each dr As DataGridViewRow In Me.dgvProductos.Rows
         dr.Cells("pCantidadNueva").Value = dr.Cells("pCantidad").Value
      Next

      Me.dgvProductos.Focus()

   End Sub

   Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

      Try
         If Me.ValidarComprobante() Then
            Me.GrabarCambios()
            Me.dgvProductos.Columns("pCantidadNueva").ReadOnly = True
            MessageBox.Show("Cambios grabados EXITOSAMENTE !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me._ventasProductos.Clear()
            Me.dgvProductos.DataSource = Me._ventasProductos.ToArray()
            Me.btnBuscar_Click(Me.btnBuscar, New EventArgs())
            Me.dgvFacturables.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.CargarFacturable()
         Me.btnEditar_Click(Me.btnEditar, New EventArgs())
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub dgvProductos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductos.CellEndEdit
      'Podrian estar juntos, pero por ahora los dejo asi.
      Me.CalcularTotalProducto()
      Me.CalcularTotales()
   End Sub

#End Region

End Class
