Imports actual = Eniac.Entidades.Usuario.Actual

Public Class Consolidado

#Region "Campos"

   Private _estaCargando As Boolean = True

#End Region


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.dtpVencimientoDesde.Value = Date.Now
         Me.dtpVencimientoHasta.Value = Date.Now

         Me.dtpDesde.Value = Date.Now
         Me.dtpHasta.Value = Me.dtpDesde.MaxDate

         txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")
         chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

         Me.CargarSucursales()
         Me.CargarBancos()

         Me._estaCargando = False

         Me.CargarDatosGenerales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try


   End Sub

#End Region

#Region "Eventos"

   Private Sub Consolidado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargarSucursales()
         Me.RefrescarPantalla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpVencimientoDesde.Value.Year, Me.dtpVencimientoDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpVencimientoHasta.Value = FechaTemp

         End If

         Me.dtpVencimientoDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpVencimientoHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         Me.chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub btnConsultar_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Dim suc As List(Of Integer) = New List(Of Integer)
         'For Each ite As Object In Me.clbSucursales.CheckedItems
         '   suc.Add(DirectCast(ite, Entidades.Sucursal).Id)
         'Next
         For Each ite As Object In Me.clbSucursales.CheckedItems
            If Not suc.Contains(DirectCast(ite, Entidades.CajaNombre).IdSucursal) Then
               suc.Add(DirectCast(ite, Entidades.CajaNombre).IdSucursal)
            End If
         Next

         Me.TotalVentas(suc)
         Me.TotalCompras(suc)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub clbSucursales_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbSucursales.SelectedValueChanged
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarPantalla()

         Me.CargarDatosGenerales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.dgvTotalVentas.RowCount = 0 Then

         End If
         Me.Cursor = Cursors.WaitCursor

         Dim Filtros As String

         Filtros = "Filtros: Rango de Fechas: desde el " & dtpVencimientoDesde.Text & " hasta el " & dtpVencimientoHasta.Text

         If chkMesCompleto.Checked Then
            Filtros = "Periodo: " & Strings.Format(dtpVencimientoDesde.Value, "MMMMM") & " " & Strings.Format(dtpVencimientoHasta.Value, "yyyy")
         End If

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TituloReporte", Me.Text))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim dt1 As DataTable
         Dim dt2 As DataTable
         Dim dt3 As DataTable
         Dim dt4 As DataTable
         Dim dt5 As DataTable
         Dim dt6 As DataTable
         Dim dt7 As DataTable
         Dim dt8 As DataTable

         dt1 = DirectCast(Me.dgvCajas.DataSource, DataTable).Copy()
         dt1.TableName = "DSReportes_Cajas"
         dt2 = DirectCast(Me.dgvCtasBcos.DataSource, DataTable).Copy()
         dt2.TableName = "DSReportes_Bancos"
         dt3 = DirectCast(Me.dgvStockValorizado.DataSource, DataTable).Copy()
         dt3.TableName = "DSReportes_Stock"
         dt4 = DirectCast(Me.dgvCtasCtesClientes.DataSource, DataTable).Copy()
         dt4.TableName = "DSReportes_CCClientes"
         dt5 = DirectCast(Me.dgvSaldosProv.DataSource, DataTable).Copy()
         dt5.TableName = "DSReportes_CCProv"
         dt6 = DirectCast(Me.dgvTotalVentas.DataSource, DataTable).Copy()
         dt6.TableName = "DSReportes_Ventas"
         dt7 = DirectCast(Me.dgvTotalCompras.DataSource, DataTable).Copy()
         dt7.TableName = "DSReportes_Compras"
         dt8 = DirectCast(Me.dgvChequesPropios.DataSource, DataTable).Copy()
         dt8.TableName = "DSReportes_Cheques"

         Dim ds As DataSet = New DataSet()

         ds.Tables.Add(dt1)
         ds.Tables.Add(dt2)
         ds.Tables.Add(dt3)
         ds.Tables.Add(dt4)
         ds.Tables.Add(dt5)
         ds.Tables.Add(dt6)
         ds.Tables.Add(dt7)
         ds.Tables.Add(dt8)

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Consolidado.rdlc", ds, parm, True, 1) '# 1 = Cantidad de Copias

         frmImprime.Text = Me.Text
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show("Debe ingresar filtro de fechas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.dtpVencimientoDesde.Focus()
         'MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnConsultarCheques_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultarCheques.Click
      Try
         Dim suc As List(Of Integer) = New List(Of Integer)
         For Each ite As Object In Me.clbSucursales.CheckedItems
            If Not suc.Contains(DirectCast(ite, Entidades.CajaNombre).IdSucursal) Then
               suc.Add(DirectCast(ite, Entidades.CajaNombre).IdSucursal)
            End If
         Next

         Me.CargarChequesPropios(suc)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private suc As List(Of Integer)

   Private Sub CargarDatosGenerales()

      If Me._estaCargando Then Exit Sub

      suc = New List(Of Integer)
      For Each ite As Object In Me.clbSucursales.CheckedItems
         If Not suc.Contains(DirectCast(ite, Entidades.CajaNombre).IdSucursal) Then
            suc.Add(DirectCast(ite, Entidades.CajaNombre).IdSucursal)
         End If
      Next
      Dim caj As List(Of Entidades.CajaNombre) = New List(Of Entidades.CajaNombre)
      For Each ite As Object In Me.clbSucursales.CheckedItems
         caj.Add(DirectCast(ite, Entidades.CajaNombre))
      Next
      Me.CargarStockValorizado(suc)
      Me.TraerSaldosClientes(suc)
      Me.TraerSaldosProveedores(suc)
      Me.CargarCajas(caj)
      Me.CargarBancos()
      Me.btnConsultarCheques.PerformClick()
      Me.chkMesCompleto.Checked = True
      Me.btnConsultar.PerformClick()

   End Sub

   Private Sub RefrescarPantalla()

      Me.CargarDatosGenerales()

      Me.chkMesCompleto.Checked = False
      Me.dtpVencimientoDesde.Value = Date.Now
      Me.dtpVencimientoHasta.Value = Date.Now

      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Me.dtpDesde.MaxDate

      Me.RefrescarDatosGrillas()
      Me.txtTotalVentas.Text = ""
      Me.txtTotalCompras.Text = ""

      'Me.txtTotalPagar.Text = ""
      'Me.txtTotalCobrar.Text = ""
      'Me.txtEfectivo.Text = ""
      'Me.txtDolares.Text = ""
      'Me.txtTarjetas.Text = ""
      'Me.txtTickets.Text = ""
      'Me.txtCheques.Text = ""
      'Me.txtTotalBancos.Text = ""
      'Me.txtTotalStock.Text = ""

   End Sub

   Private Sub CargarSucursales()

      Dim lis As List(Of Entidades.CajaNombre)

      If actual.Sucursal.SoyLaCentral Then
         'Traigo la informacion de todas las Sucursales
         lis = New Reglas.CajasNombres().GetTodas(0)
      Else
         lis = New Reglas.CajasNombres().GetTodas(actual.Sucursal.Id)
      End If

      Me.clbSucursales.DataSource = lis
      'Me.clbSucursales.DisplayMember = "NombreSucursal"
      Dim Cont As Integer = 0

      For Each suc As Entidades.CajaNombre In lis
         'Marco en forma predeterminada la Sucursal donde estoy parado. Ahorra trabajo, sobre todo si solo hay 1, tiene mas sentido.
         Me.clbSucursales.SetItemChecked(Cont, suc.IdSucursal = actual.Sucursal.Id)
         Cont += 1
      Next

   End Sub

   Public Sub CargarBancos()
      Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
      Dim dt As DataTable = oLibroBancos.GetSaldosCuentasBancarias(actual.Sucursal.Id, -1, dtpVencimientoHasta.Value, activas:=Entidades.Publicos.SiNoTodos.SI, conSaldo:=Entidades.Publicos.SiNoTodos.TODOS, 0)

      dt.Columns.Add("SaldoMostrar", GetType(Decimal), "Saldo + SaldoDolares")

      dgvCtasBcos.DataSource = dt

      Dim sumabancos As Decimal = 0
      For Each dr As DataRow In dt.Rows
         If Not String.IsNullOrEmpty(dr("SaldoMostrar").ToString()) Then
            sumabancos += Decimal.Parse(dr("SaldoMostrar").ToString())
         End If
      Next

      Me.txtTotalBancos.Text = sumabancos.ToString("$ #,##0.00")
   End Sub

   Public Sub CargarCajas(ByVal suc As List(Of Entidades.CajaNombre))

      Dim reg As Reglas.Cajas = New Reglas.Cajas()

      Dim dtSuc As DataTable = New DataTable()

      Dim sumaPesos As Decimal = 0
      Dim sumaCheques As Decimal = 0
      Dim sumaTarjetas As Decimal = 0
      Dim sumaTickets As Decimal = 0
      Dim sumaDolares As Decimal = 0

      dtSuc.Columns.Add("NombreSuc", System.Type.GetType("System.String"))
      dtSuc.Columns.Add("NombreCaja", System.Type.GetType("System.String"))
      dtSuc.Columns.Add("Efectivo", System.Type.GetType("System.Decimal"))
      dtSuc.Columns.Add("Cheques", System.Type.GetType("System.Decimal"))
      dtSuc.Columns.Add("Tarjetas", System.Type.GetType("System.Decimal"))
      dtSuc.Columns.Add("Tickets", System.Type.GetType("System.Decimal"))
      dtSuc.Columns.Add("Dolares", System.Type.GetType("System.Decimal"))

      Dim plaAct As Entidades.Caja
      Dim oCajaDetalles As Reglas.CajaDetalles
      Dim dt As DataTable

      oCajaDetalles = New Reglas.CajaDetalles()

      'obtengo las cajas
      Dim cajas As List(Of Entidades.CajaNombre) = New Reglas.CajasNombres().GetTodas(actual.Sucursal.Id)

      Dim drsu As DataRow

      For Each caj As Entidades.CajaNombre In suc

         plaAct = reg.GetPlanillaActual(caj.IdSucursal, caj.IdCaja)

         dt = oCajaDetalles.GetTodas(caj.IdSucursal, caj.IdCaja, plaAct.NumeroPlanilla, "FECHA")

         sumaPesos = 0
         sumaCheques = 0
         sumaTarjetas = 0
         sumaTickets = 0
         sumaDolares = 0

         For Each dr As DataRow In dt.Rows
            sumaPesos += Decimal.Parse(dr("ImportePesos").ToString())
            sumaCheques += Decimal.Parse(dr("ImporteCheques").ToString())
            sumaTarjetas += Decimal.Parse(dr("ImporteTarjetas").ToString())
            sumaTickets += Decimal.Parse(dr("ImporteTickets").ToString())
            sumaDolares += Decimal.Parse(dr("ImporteDolares").ToString())
         Next

         drsu = dtSuc.NewRow()

         drsu("NombreSuc") = caj.NombreSucursal
         drsu("NombreCaja") = caj.NombreCaja
         drsu("Efectivo") = (sumaPesos + plaAct.PesosSaldoInicial)
         drsu("Cheques") = (sumaCheques + plaAct.ChequesSaldoInicial)
         drsu("Tarjetas") = (sumaTarjetas + plaAct.TarjetasSaldoInicial)
         drsu("Tickets") = (sumaTickets + plaAct.TicketsSaldoInicial)
         drsu("Dolares") = (sumaDolares + plaAct.DolaresSaldoInicial)

         dtSuc.Rows.Add(drsu)
      Next

      Me.dgvCajas.DataSource = dtSuc

      Dim TotalPesos As Decimal = 0
      Dim TotalCheques As Decimal = 0
      Dim TotalTarjetas As Decimal = 0
      Dim TotalTickets As Decimal = 0
      Dim TotalDolares As Decimal = 0

      For Each dr As DataRow In dtSuc.Rows
         TotalPesos += Decimal.Parse(dr("Efectivo").ToString())
         TotalCheques += Decimal.Parse(dr("Cheques").ToString())
         TotalTarjetas += Decimal.Parse(dr("Tarjetas").ToString())
         TotalTickets += Decimal.Parse(dr("Tickets").ToString())
         TotalDolares += Decimal.Parse(dr("Dolares").ToString())
      Next

      Me.txtEfectivo.Text = TotalPesos.ToString("$ #,##0.00")
      Me.txtCheques.Text = TotalCheques.ToString("$ #,##0.00")
      Me.txtTickets.Text = TotalTickets.ToString("$ #,##0.00")
      Me.txtTarjetas.Text = TotalTarjetas.ToString("$ #,##0.00")
      Me.txtDolares.Text = TotalDolares.ToString("U$S #,##0.00")

   End Sub

   Public Sub CargarStockValorizado(ByVal suc As List(Of Integer))

      Dim oProductosSucursales As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()

      Dim cotizacionDolar As Decimal = 1
      If IsNumeric(txtCotizacionDolar.Text) Then cotizacionDolar = Decimal.Parse(txtCotizacionDolar.Text)

      Dim dt As DataTable = oProductosSucursales.GetStockValorizado(suc, cotizacionDolar)

      Me.dgvStockValorizado.DataSource = dt

      MuestraStockValorizadoSegunIVA()

      'Dim sumastock As Decimal = 0
      'For Each dr As DataRow In dt.Rows
      '   sumastock += Decimal.Parse(dr("Valor").ToString())
      'Next

      'Me.txtTotalStock.Text = sumastock.ToString("$ #,##0.00")

   End Sub

   Public Sub CargarChequesPropios(ByVal suc As List(Of Integer))

      Dim cheq As Reglas.Cheques = New Reglas.Cheques()

      Dim dt As DataTable = cheq.GetSaldoCheqPropio(Me.dtpDesde.Value, Me.dtpHasta.Value, suc, True)

      Me.dgvChequesPropios.DataSource = dt

      Dim sumacheqprop As Decimal = 0
      For Each dr As DataRow In dt.Rows
         sumacheqprop += Decimal.Parse(dr("Saldo").ToString())
      Next

      Me.txtChequesPropios.Text = sumacheqprop.ToString("$ #,##0.00")

   End Sub

   Private Sub TraerSaldosClientes(ByVal suc As List(Of Integer))

      Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

      Dim decSaldo As Decimal = 0

      Dim dt As DataTable = oCtaCte.GetSaldoClientes(suc)

      Me.dgvCtasCtesClientes.DataSource = dt

      For Each dr As DataRow In dt.Rows
         decSaldo += Decimal.Parse(dr("Saldo").ToString())
      Next

      Me.txtTotalCobrar.Text = decSaldo.ToString("$ #,##0.00")

   End Sub

   Private Sub TraerSaldosProveedores(ByVal suc As List(Of Integer))

      Dim oCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()

      Dim decSaldo As Decimal = 0

      Dim dt As DataTable = oCtaCte.GetSaldoProveedores(suc)

      Me.dgvSaldosProv.DataSource = dt

      For Each dr As DataRow In dt.Rows
         decSaldo += Decimal.Parse(dr("Saldo").ToString())
      Next

      Me.txtTotalPagar.Text = decSaldo.ToString("$ #,##0.00")
   End Sub

   Private Sub TotalVentas(ByVal suc As List(Of Integer))

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
      Dim sumaVentas As Decimal = 0

      Dim dt As DataTable = oVentas.GetTotalVentasSucursales(suc, Me.dtpVencimientoDesde.Value, Me.dtpVencimientoHasta.Value)

      Me.dgvTotalVentas.DataSource = dt

      For Each dr As DataRow In dt.Rows
         sumaVentas += Decimal.Parse(dr("Total").ToString())
      Next

      Me.txtTotalVentas.Text = sumaVentas.ToString("$ #,##0.00")

   End Sub

   Private Sub TotalCompras(ByVal suc As List(Of Integer))

      Dim oCompras As Reglas.Compras = New Reglas.Compras()
      Dim SumaCompras As Decimal = 0

      Dim dt As DataTable = oCompras.GetTotalComprasSucursales(suc, Me.dtpVencimientoDesde.Value, Me.dtpVencimientoHasta.Value)

      Me.dgvTotalCompras.DataSource = dt

      For Each dr As DataRow In dt.Rows

         SumaCompras += Decimal.Parse(dr("Total").ToString())

      Next

      Me.txtTotalCompras.Text = SumaCompras.ToString("$ #,##0.00")

   End Sub

   Private Sub RefrescarDatosGrillas()

      'If Not Me.dgvStockValorizado.DataSource Is Nothing Then
      '   DirectCast(Me.dgvStockValorizado.DataSource, DataTable).Rows.Clear()
      'End If
      'If Not Me.dgvCtasBcos.DataSource Is Nothing Then
      '   DirectCast(Me.dgvCtasBcos.DataSource, DataTable).Rows.Clear()
      'End If
      'If Not Me.dgvCajas.DataSource Is Nothing Then
      '   DirectCast(Me.dgvCajas.DataSource, DataTable).Rows.Clear()
      'End If
      'If Not Me.dgvSaldosProv.DataSource Is Nothing Then
      '   DirectCast(Me.dgvSaldosProv.DataSource, DataTable).Rows.Clear()
      'End If
      'If Not Me.dgvCtasCtesClientes.DataSource Is Nothing Then
      '   DirectCast(Me.dgvCtasCtesClientes.DataSource, DataTable).Rows.Clear()
      'End If

      If Not Me.dgvTotalVentas.DataSource Is Nothing Then
         DirectCast(Me.dgvTotalVentas.DataSource, DataTable).Rows.Clear()
      End If
      If Not Me.dgvTotalCompras.DataSource Is Nothing Then
         DirectCast(Me.dgvTotalCompras.DataSource, DataTable).Rows.Clear()
      End If

      txtCotizacionDolar.Text = New Reglas.Monedas().GetUna(2).FactorConversion.ToString("N2")
      chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

   End Sub

#End Region


   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      MuestraStockValorizadoSegunIVA()
   End Sub

   Private Sub MuestraStockValorizadoSegunIVA()
      dgvStockValorizado.Columns(StockValorizado.Name).Visible = Not chbConIVA.Checked
      dgvStockValorizado.Columns(ValorConIVA.Name).Visible = chbConIVA.Checked

      Dim sumastock As Decimal = 0
      If TypeOf (dgvStockValorizado.DataSource) Is DataTable Then
         For Each dr As DataRow In DirectCast(dgvStockValorizado.DataSource, DataTable).Rows
            If chbConIVA.Checked Then
               sumastock += Decimal.Parse(dr("ValorConIVA").ToString())
            Else
               sumastock += Decimal.Parse(dr("ValorSinIVA").ToString())
            End If
         Next
      End If
      Me.txtTotalStock.Text = sumastock.ToString("C2")   '$ #,##0.00
   End Sub

   Dim prev_txtCotizacionDolar As String = ""

   Private Sub txtCotizacionDolar_Leave(sender As Object, e As EventArgs) Handles txtCotizacionDolar.Leave
      Try
         If Not prev_txtCotizacionDolar.Equals(txtCotizacionDolar.Text) Then
            Me.CargarStockValorizado(suc)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtCotizacionDolar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCotizacionDolar.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtCotizacionDolar_Enter(sender As Object, e As EventArgs) Handles txtCotizacionDolar.Enter
      prev_txtCotizacionDolar = txtCotizacionDolar.Text
   End Sub
End Class