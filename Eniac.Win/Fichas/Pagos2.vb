#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Entidades
Imports Eniac.Reglas
#End Region
Public Class Pagos2

#Region "Enumeraciones"

   Public Enum TipoPago
      Pago
      Devolucion
   End Enum

#End Region

#Region "Campos"

   Private _idCaja As Integer = 0

   Private _idSucursal As Integer
   Private _idTipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Short
   Private _nroOperacion As Long
   Private _idCliente As Long
   Private _cliente As Entidades.Cliente
   Private _categoria As Entidades.Categoria
   Private _tipoRecibo As TipoComprobante

   Private _vendedor As Entidades.Empleado
   Private _cobrador As Entidades.Empleado
   Private _cuota As Integer
   Private _tipo As TipoPago
   Private _ficha As Entidades.Venta

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Dim pub As Eniac.Win.Publicos = New Eniac.Win.Publicos()
      pub.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)

      If _cobrador IsNot Nothing Then
         cmbCobrador.SelectedValue = _cobrador.IdEmpleado
      Else
         cmbCobrador.SelectedIndex = -1
      End If

      Me.txtCaja.Text = New Eniac.Reglas.CajasNombres().GetUna(Me._idSucursal, Me._idCaja).NombreCaja

      Dim tit As Dictionary(Of String, String) = GetColumnasVisiblesGrilla(ugInteresesCuotas)
      ugInteresesCuotas.DataSource = _ficha.CuentaCorriente.Pagos
      AjustarColumnasGrilla(ugInteresesCuotas, tit)

      ugInteresesCuotas.AgregarTotalesSuma({Entidades.CuentaCorrientePago.Columnas.SaldoCuota.ToString(),
                                            Entidades.CuentaCorrientePago.Columnas.DescuentoRecargo.ToString()})

      dtpFecha.Focus()
   End Sub

#End Region

#Region "Constructores"
   Private _cancelarFicha As Boolean
   Public Sub New(idCaja As Integer, tipo As TipoPago,
                  idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, nroOperacion As Long,
                  idCliente As Long, vendedor As Entidades.Empleado, cobrador As Entidades.Empleado, importeCuota As Decimal, cuotanumero As Integer,
                  cancelarFicha As Boolean)

      Me.InitializeComponent()

      Me._idCaja = idCaja
      _idSucursal = idSucursal
      _idTipoComprobante = idTipoComprobante
      _letra = letra
      _centroEmisor = centroEmisor
      Me._nroOperacion = nroOperacion
      Me._idCliente = idCliente
      Me._cliente = New Clientes().GetUno(idCliente)
      Me._categoria = New Categorias().GetUno(_cliente.IdCategoria)

      _cancelarFicha = cancelarFicha
      ' Si la pantalla fué abierta para Cancelar una Ficha
      If cancelarFicha Then
         Me.txtImporte.ReadOnly = True
         Me.txtInteres.ReadOnly = True
         _tipoRecibo = New Reglas.TiposComprobantes().GetUno("MINUTA")
      Else
         _tipoRecibo = New Reglas.TiposComprobantes().GetUno("RECIBOPROV")
      End If

      _ficha = New Ventas().GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, nroOperacion)

      _vendedor = vendedor
      _cobrador = cobrador

      Me._tipo = tipo
      If tipo = TipoPago.Pago Then
         Me.Text = "Pagos"
         Me.txtImporte.Text = importeCuota.ToString("##0.00")
         CalcularTotal()
      Else
         Me.Text = "Devolución de Pagos"
         Me.txtConcepto.Enabled = False
         Me.txtInteres.Enabled = False
      End If

      ' Si la pantalla es para Cancelar una Ficha
      If cancelarFicha Then Me.Text = "Cancelar Ficha"

      Me._cuota = cuotanumero
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
      Try
         If Double.Parse(Me.txtImporte.Text) > 0 Then
            If Double.Parse(Me.txtInteres.Text) > 0 Then
               If String.IsNullOrWhiteSpace(Me.txtConcepto.Text) Then
                  MessageBox.Show("Debe contener un concepto si el interes no es cero", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  txtConcepto.Focus()
                  Exit Sub
               End If
            End If
            If cmbCobrador.SelectedIndex = -1 Then
               ShowMessage("Debe seleccionar un Cobrador.")
               cmbCobrador.Focus()
               Exit Sub
            End If

            Me.GrabarPago(_cancelarFicha)
         Else
            MessageBox.Show("El importe debe ser distinto de cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub

   Private Sub txtImporte_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImporte.Enter
      Me.txtImporte.SelectAll()
   End Sub
   Private Sub txtImporte_Leave(sender As Object, e As EventArgs) Handles txtImporte.Leave
      Try
         If Not IsNumeric(txtImporte.Text) Then txtImporte.Text = "0.00"
         CalcularIntereses()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtInteres_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInteres.Leave, txtTotal.Leave
      Try
         Me.txtConcepto.ReadOnly = (Decimal.Parse(Me.txtInteres.Text) <= 0)
         CalcularTotal()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpFecha_Leave(sender As Object, e As EventArgs) Handles dtpFecha.Leave
      Try
         CalcularIntereses()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub controls_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInteres.KeyDown,
                                                                             txtImporte.KeyDown,
                                                                             txtConcepto.KeyDown,
                                                                             dtpFecha.KeyDown,
                                                                             cmbCobrador.KeyDown,
                                                                             txtTotal.KeyDown
      PresionarTab(e)
   End Sub

#End Region

#Region "Metodos"

   Private Sub GrabarPago(cancelarFicha As Boolean)

      Dim oReglasCuentaCorriente As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
      Dim oCtaCte As Entidades.CuentaCorriente
      Dim eCobrador As Entidades.Empleado = DirectCast(cmbCobrador.SelectedItem, Entidades.Empleado)

      Dim importe As Decimal = Decimal.Parse(Me.txtImporte.Text)
      Dim interes As Decimal = Decimal.Parse(Me.txtInteres.Text)

      oCtaCte = oReglasCuentaCorriente.GrabarPagoDeFichas(_idSucursal, _idTipoComprobante, _letra, _centroEmisor,
                                                          Long.Parse(Me._nroOperacion.ToString()),
                                                          dtpFecha.Value,
                                                          importe,
                                                          interes,
                                                          _vendedor,
                                                          Integer.Parse(Me._idCaja.ToString()),
                                                          txtConcepto.Text,
                                                          eCobrador,
                                                          Entidad.MetodoGrabacion.Manual,
                                                          IdFuncion,
                                                          cancelarFicha)
      '-------------
      Me.ImprimirRecibo(oCtaCte)

      If _cancelarFicha Then
         MessageBox.Show("La ficha se canceló con exito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
         MessageBox.Show("El pago se realizó con exito!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

      Me.LimpiarCampos()
      Me.Close()
   End Sub

   Private Sub ImprimirRecibo(ByVal pag As Eniac.Entidades.CuentaCorriente)
      Me.Cursor = Cursors.WaitCursor

      Try
         Dim impresionFichas As ImpresionFichas = New ImpresionFichas()
         impresionFichas.ImprimirRecibo(pag)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
      End Try
      ' '' ''obtengo los detalles de pagos para imprimir en el recibo
      ' '' ''Dim pagos As List(Of Entidades.CuentaCorrientePago) = pag.Pagos

      ' '' ''Dim oFP As Eniac.Reglas.FichasPagosDetalle = New Eniac.Reglas.FichasPagosDetalle()
      ' '' ''Dim pagos As List(Of Eniac.Entidades.FichaPagoDetalle) = oFP.GetFichasAImprimir(pag.IdSucursal, pag.IdCliente, pag.NroOperacion, pag.FechaPago)

      ' '' ''recupero si existen ajuste
      '' ''Dim oFA As Eniac.Reglas.FichasPagosAjustes = New Eniac.Reglas.FichasPagosAjustes()

      ' '' ''recupero los datos del cliente
      ' '' ''Dim oCl As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes()
      '' ''Dim cliente As Eniac.Entidades.Cliente = pag.Cliente

      '' ''Dim pagos As List(Of Eniac.Entidades.FichaPagoDetalle) = New List(Of FichaPagoDetalle)()

      '' ''Dim ficha As Entidades.Venta = Nothing
      ' '' ''calculo monto
      '' ''Dim intereses As Double = 0
      '' ''Dim concepto As String = pag.Observacion
      '' ''Dim monto As Decimal = 0
      '' ''For Each pago As Entidades.CuentaCorrientePago In pag.Pagos
      '' ''   If pago.IdTipoComprobante = "FICHAS" Then
      '' ''      If ficha Is Nothing Then ficha = New Reglas.Ventas().GetUna(pago.IdSucursal, pago.IdTipoComprobante, pago.Letra, Convert.ToInt16(pago.CentroEmisor), pago.NumeroComprobante)
      '' ''      monto += pago.Paga
      '' ''      pagos.Add(New FichaPagoDetalle(Convert.ToInt32(pago.NumeroComprobante), pago.Cuota, pago.Paga))
      '' ''   Else
      '' ''      intereses += pago.Paga
      '' ''   End If
      '' ''Next


      ' '' ''obtengo el nombre del o los productos
      ' '' ''Dim oFPro As Eniac.Reglas.FichasProductos = New Eniac.Reglas.FichasProductos()
      '' ''Dim produc As List(Of Eniac.Entidades.VentaProducto) = ficha.VentasProductos

      '' ''Dim productos As String = "  "
      '' ''For Each pr As Eniac.Entidades.VentaProducto In produc
      '' ''   productos += pr.NombreProducto + " / "
      '' ''Next
      '' ''productos = productos.Substring(0, productos.Length - 2)

      ' '' ''creo la coleccion de parametros
      '' ''Dim parm As List(Of Microsoft.Reporting.WinForms.ReportParameter) = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresa))
      '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", pag.Fecha.ToString()))
      '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDoc", cliente.CodigoCliente.ToString()))
      '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", cliente.NombreCliente))
      '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Monto", monto.ToString()))
      '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Productos", productos))
      '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Intereses", intereses.ToString()))
      '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Concepto", concepto))

      '' ''Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ReciboPago.rdlc", "SistemaDataSet_FichasPagosDetalle", pagos, parm)
      '' ''frmImprime.Text = "Recibo pago"
      '' ''Me.Cursor = Cursors.Default
      '' ''frmImprime.ShowDialog()

   End Sub

   Private Sub LimpiarCampos()
      Me.dtpFecha.Value = DateTime.Now
      Me.txtImporte.Text = "0.00"
      CalcularTotal()
      Me.cmbCobrador.SelectedIndex = -1
   End Sub

   Private Sub CalcularTotal()
      Dim importe As Decimal = If(IsNumeric(txtImporte.Text), Decimal.Parse(txtImporte.Text), 0D)
      Dim interes As Decimal = If(IsNumeric(txtInteres.Text), Decimal.Parse(txtInteres.Text), 0D)

      txtTotal.Text = (importe + interes).ToString("N2")

   End Sub

   Private Sub CalcularIntereses()
      If _cancelarFicha Then Exit Sub
      Dim totalAPagar As Decimal = Decimal.Parse(txtImporte.Text)
      Dim paga As Decimal
      Dim totalInteres As Decimal = 0
      For Each ccPago As Entidades.CuentaCorrientePago In _ficha.CuentaCorriente.Pagos
         If totalAPagar <= 0 Then Exit For
         If ccPago.SaldoCuota = 0 Then Continue For
         paga = Math.Min(ccPago.SaldoCuota, totalAPagar)

         Dim porcInteres As Decimal = New Ventas().ReciboPorcentajeDescuentoRecargo(_tipoRecibo,
                                                                                    _cliente.IdCategoria,
                                                                                    _ficha.Fecha,
                                                                                    ccPago.FechaVencimiento,
                                                                                    dtpFecha.Value,
                                                                                    paga,
                                                                                    ccPago.SaldoCuota)

         ccPago.Paga = paga
         porcInteres = Math.Max(0, porcInteres)
         ccPago.DescuentoRecargo = paga * porcInteres / 100
         If ccPago.DescuentoRecargo > 0 And Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido > ccPago.DescuentoRecargo Then
            ccPago.DescuentoRecargo = 0
         End If

         totalAPagar -= paga
         totalInteres += ccPago.DescuentoRecargo
      Next

      txtInteres.Text = totalInteres.ToString("N2")

      ugInteresesCuotas.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

      CalcularTotal()
   End Sub

#End Region

End Class