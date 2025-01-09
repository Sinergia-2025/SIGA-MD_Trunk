Public Class AnulacionRecibosAClientes

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre
   Private CantidadSeleccionada As Integer

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            dtpDesde.Value = Date.Today
            dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

            'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
            If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
               IdUsuario = ""
            End If

            Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
            If IdUsuario = "" Then
               cmbVendedor.SelectedIndex = -1
            Else
               chbVendedor.Checked = True
               chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
            End If

            _publicos.CargaComboCategorias(cmbCategoria)
            _publicos.CargaComboTiposComprobantesRecibo(cmbTiposComprobantesRec, True, "CTACTECLIE", esReciboClienteVinculado:=Nothing)
            _publicos.CargaComboUsuarios(cmbUsuario)

            _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, MiraUsuario:=True, MiraPC:=False, CajasModificables:=False)
            cmbCajas.SelectedIndex = -1

            With cmbLetra
               .DisplayMember = "LetraFiscal"
               .ValueMember = "LetraFiscal"
               .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
               .SelectedIndex = -1
            End With

            With cmbEmisor
               .DisplayMember = "CentroEmisor"
               .ValueMember = "CentroEmisor"
               .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
               .SelectedIndex = -1
            End With

            _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
            cmbZonaGeografica.SelectedIndex = -1

            ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreCaja", "Observacion"}, {"Ver"})
            ugDetalle.AgregarTotalesSuma({"ImportePesos", "ImporteDolares", "ImporteTickets", "ImporteCheques", "ImporteTarjetas", "ImporteTransfBancaria", "ImporteTransfBancariaDolares", "ImporteRetenciones", "ImporteTotal"})

            PreferenciasLeer(ugDetalle, tsbPreferencias)
         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            RefrescarDatosGrilla()
            tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"
         End Sub)
   End Sub

   Private Sub tsbAnulacion_Click(sender As Object, e As EventArgs) Handles tsbAnulacion.Click
      TryCatched(
         Sub()
            Dim entro = False

            ugDetalle.UpdateData()

            CantidadSeleccionada = 0

            For Each dr As UltraGridRow In Me.ugDetalle.Rows
               If dr.Cells("Selec").Value IsNot Nothing Then
                  If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then
                     CantidadSeleccionada += 1
                     'entro = True
                  End If
               End If
            Next

            If Me.CantidadSeleccionada = 0 Then
               MessageBox.Show("No seleccionó ningún movimiento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            Else
               If MessageBox.Show("¿Está seguro de querer eliminar " & Me.CantidadSeleccionada.ToString() & " Recibo(s)?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
                  Exit Sub
               End If
            End If

            Me.Cursor = Cursors.WaitCursor

            Dim ctactes As List(Of Entidades.CuentaCorriente) = New List(Of Entidades.CuentaCorriente)()

            Dim octacte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
            Dim ctacte As Entidades.CuentaCorriente
            For Each dr As UltraGridRow In Me.ugDetalle.Rows
               If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then

                  ctacte = New Entidades.CuentaCorriente()
                  ctacte = octacte.GetUna(Integer.Parse(dr.Cells("IdSucursal").Value.ToString()), dr.Cells("IdTipoComprobante").Value.ToString(), dr.Cells("Letra").Value.ToString(),
                                                Integer.Parse(dr.Cells("CentroEmisor").Value.ToString()), Long.Parse(dr.Cells("NumeroComprobante").Value.ToString()))

                  ctacte.Usuario = actual.Nombre

                  Dim TotalComprobantes As Decimal = 0
                  For i As Integer = 0 To ctacte.Pagos.Count - 1
                     TotalComprobantes += ctacte.Pagos(i).Paga
                  Next
                  Dim totalPago As Decimal = 0

                  '# Me traigo el valor del Dolar para ese comprobante y convierto el Importe de Dolares a Pesos
                  Dim dolarDeLaVenta As Decimal = Decimal.Parse(dr.Cells(Entidades.CuentaCorriente.Columnas.CotizacionDolar.ToString()).Value.ToString())
                  Dim dolarTrx = If(ctacte.CuentaBancariaTransfBanc.Moneda.IdMoneda = Entidades.Moneda.Dolar, dolarDeLaVenta, 1)
                  totalPago = ctacte.ImportePesos + ctacte.ImporteTarjetas + (ctacte.ImporteTransfBancaria * dolarTrx) + ctacte.ImporteCheques + ctacte.ImporteRetenciones + Decimal.Parse((ctacte.ImporteDolares * dolarDeLaVenta).ToString("N2"))

                  Dim diferencia As Decimal = TotalComprobantes - totalPago
                  If diferencia <> 0 Then
                     Dim Antic As Entidades.CuentaCorriente
                     Dim TipoAnticipo As String

                     TipoAnticipo = ctacte.TipoComprobante.IdTipoComprobanteSecundario

                     Antic = octacte.GetUna(actual.Sucursal.Id, TipoAnticipo, ctacte.Letra, ctacte.CentroEmisor, ctacte.NumeroComprobante)

                     'El Saldo viene con el saldo cambiado, pero por las dudas le saco el signo a ambos.
                     If Math.Abs(Antic.ImporteTotal) <> Math.Abs(Antic.Saldo) Then
                        Throw New Exception(String.Format("El recibo {0} {1} {2:0000}-{3:00000000} generó un ANTICIPO y tiene pago aplicado, debe anular primero el Recibo que lo afectó.",
                                                          ctacte.TipoComprobante.IdTipoComprobante, ctacte.Letra, ctacte.CentroEmisor, ctacte.NumeroComprobante))
                     End If
                  End If

                  octacte.AnularRecibo(ctacte)

                  dr.Cells("Selec").Value = False
               End If
            Next

            ShowMessage("La anulación se realizo con éxito!!")

            btnConsultar.PerformClick()
         End Sub)
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs)
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            Dim codigoCliente As Long = -1
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim oClientes = New Reglas.Clientes()
            If bscCodigoCliente.Text.Trim.Length > 0 Then
               codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
            End If
            bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
         End Sub)
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCliente)
            Dim oClientes = New Reglas.Clientes()
            bscCliente.Datos = oClientes.GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
         End Sub)
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub

   Private Sub chbRecibo_CheckedChanged(sender As Object, e As EventArgs) Handles chbRecibo.CheckedChanged
      TryCatched(Sub() chbRecibo.FiltroCheckedChanged(cmbTiposComprobantesRec))
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub

   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      TryCatched(Sub() chbCaja.FiltroCheckedChanged(cmbCajas))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
               ShowMessage("ATENCION: Activo el filtro de Cliente pero NO selecciono")
               bscCodigoCliente.Focus()
               Exit Sub
            End If

            If chbCaja.Checked And cmbCajas.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó una Caja aunque activó ese Filtro")
               cmbCajas.Focus()
               Exit Sub
            End If

            If chbNumero.Checked And txtNumero.ValorNumericoPorDefecto(0L) = 0 Then
               ShowMessage("ATENCION: NO seleccionó un Numero aunque activó ese Filtro")
               txtNumero.Focus()
               Exit Sub
            End If

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False
            chbTodos.Checked = False

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If chkExpandAll.Checked Then
         ugDetalle.Rows.ExpandAll(True)
      Else
         ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing AndAlso e.Cell.Column.Key = "Ver" Then
               Dim reg = New Reglas.CuentasCorrientes()
               Dim ctacte = reg.GetUna(dr.Field(Of Integer)("IdSucursal"),
                                       dr.Field(Of String)("IdTipoComprobante"),
                                       dr.Field(Of String)("Letra"),
                                       dr.Field(Of Integer)("CentroEmisor"),
                                       dr.Field(Of Long)("NumeroComprobante"))
               Dim imp = New RecibosImprimir()
               imp.ImprimirRecibo(ctacte, True)
            End If
         End Sub)
   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      TryCatched(Sub() chbLetra.FiltroCheckedChanged(cmbLetra))
   End Sub

   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      TryCatched(Sub() chbEmisor.FiltroCheckedChanged(cmbEmisor))
   End Sub

   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(
         Sub()
            txtNumero.Enabled = chbNumero.Checked
            If Not chbNumero.Checked Then
               txtNumero.Text = String.Empty
            Else
               txtNumero.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
         Sub()
            For Each dr As UltraGridRow In ugDetalle.Rows
               dr.Cells("Selec").Value = chbTodos.Checked
            Next
         End Sub)
   End Sub


#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
      bscCliente.Enabled = False
      bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbCategoria.Checked = False
      chbCliente.Checked = False
      If IdUsuario = "" Then
         chbVendedor.Checked = False
      End If
      chbRecibo.Checked = False
      chbCaja.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      chbLetra.Checked = False
      chbEmisor.Checked = False
      chbNumero.Checked = False
      chbZonaGeografica.Checked = False

      ugDetalle.ClearFilas()

      btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idCliente = If(chbCliente.Checked And (bscCodigoCliente.Selecciono Or bscCliente.Selecciono), Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoria, 0I)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idTipoComprobante = If(chbRecibo.Checked, cmbTiposComprobantesRec.ValorSeleccionado(Of String), String.Empty)
      Dim idUsuario = If(chbUsuario.Checked, cmbUsuario.ItemSeleccionado(Of Entidades.Usuario).Usuario, String.Empty)
      Dim idCaja = cmbCajas.ValorSeleccionado(chbCaja, 0I)
      Dim letra = If(chbLetra.Checked, cmbLetra.ValorSeleccionado(Of String), String.Empty)
      Dim emisor = cmbEmisor.ValorSeleccionado(chbEmisor, 0I)
      Dim numeroComprobante As Long = If(chbNumero.Checked, txtNumero.ValorNumericoPorDefecto(0L), 0L)
      Dim idZonaGeografica As String = If(chbZonaGeografica.Checked, cmbZonaGeografica.ItemSeleccionado(Of Entidades.ZonaGeografica).IdZonaGeografica, String.Empty)

      Dim oCtaCte = New Reglas.CuentasCorrientes()
      Dim dtDetalle = oCtaCte.GetRecibosAnulacion(actual.Sucursal.Id,
                                                  dtpDesde.Value, dtpHasta.Value,
                                                  idCliente,
                                                  idCategoria,
                                                  idVendedor,
                                                  idTipoComprobante,
                                                  idUsuario,
                                                  idCaja, letra, emisor, numeroComprobante,
                                                  idZonaGeografica)

      Dim dt = CrearDT()

      For Each dr As DataRow In dtDetalle.Rows
         Dim drCl = dt.NewRow()

         drCl("Ver") = "..."
         drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
         drCl("Fecha") = Date.Parse(dr("Fecha").ToString()).Date
         drCl("Hora") = Date.Parse(dr("Fecha").ToString()).ToString("HH:mm")
         drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
         drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
         drCl("NombreCliente") = dr("NombreCliente").ToString()
         drCl("NombreCaja") = dr("NombreCaja").ToString()
         drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
         drCl("Letra") = dr("Letra").ToString()
         drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
         drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
         drCl("ImportePesos") = Decimal.Parse(dr("ImportePesos").ToString())
         drCl("ImporteDolares") = Decimal.Parse(dr("ImporteDolares").ToString())
         drCl("ImporteTickets") = Decimal.Parse(dr("ImporteTickets").ToString()) 'Oculto
         drCl("ImporteCheques") = Decimal.Parse(dr("ImporteCheques").ToString())
         drCl("ImporteTarjetas") = Decimal.Parse(dr("ImporteTarjetas").ToString())
         If String.IsNullOrEmpty(dr("ImporteTransfBancaria").ToString()) Then
            drCl("ImporteTransfBancaria") = 0
            drCl("NombreCuentaBancaria") = ""
         Else
            If dr.Field(Of Integer?)("IdMonedaCuentaBancaria").IfNull() = Entidades.Moneda.Dolar Then
               drCl("ImporteTransfBancaria") = 0
               drCl("ImporteTransfBancariaDolares") = Decimal.Parse(dr("ImporteTransfBancaria").ToString())
            Else
               drCl("ImporteTransfBancaria") = Decimal.Parse(dr("ImporteTransfBancaria").ToString())
               drCl("ImporteTransfBancariaDolares") = 0
            End If
            drCl("NombreCuentaBancaria") = dr("NombreCuentaBancaria").ToString()
            'TotalTransfBanc = TotalTransfBanc + Decimal.Parse(dr("ImporteTransfBancaria").ToString())
         End If
         drCl("ImporteRetenciones") = Decimal.Parse(dr("ImporteRetenciones").ToString())
         drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
         drCl("ImporteTarjetas") = Decimal.Parse(dr("ImporteTarjetas").ToString())
         drCl("IdEstadoComprobante") = dr("IdEstadoComprobante").ToString()
         drCl("Observacion") = dr("Observacion").ToString()
         drCl("IdUsuario") = dr("IdUsuario").ToString()
         drCl("FechaActualizacion") = Date.Parse(dr("FechaActualizacion").ToString())
         drCl("CotizacionDolar") = dr("CotizacionDolar").ToString()

         'TotalPesos = TotalPesos + Decimal.Parse(dr("ImportePesos").ToString())
         'TotalCheques = TotalCheques + Decimal.Parse(dr("ImporteCheques").ToString())
         'TotalTarjetas = TotalTarjetas + Decimal.Parse(dr("ImporteTarjetas").ToString())
         'TotalRetenciones = TotalRetenciones + Decimal.Parse(dr("ImporteRetenciones").ToString())
         'Total = Total + Decimal.Parse(dr("ImporteTotal").ToString())

         dt.Rows.Add(drCl)

      Next

      'Me.txtTotalPesos.Text = TotalPesos.ToString("##,##0.00")
      'Me.txtTotalCheques.Text = TotalCheques.ToString("##,##0.00")
      'Me.txtTotalTarjetas.Text = TotalTarjetas.ToString("##,##0.00")
      'Me.txtTotalTransfBanc.Text = TotalTransfBanc.ToString("##,##0.00")
      'Me.txtTotalRetenciones.Text = TotalRetenciones.ToString("##,##0.00")
      'Me.txtTotal.Text = Total.ToString("##,##0.00")

      ugDetalle.DataSource = dt

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver", GetType(String))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("Fecha", GetType(Date))
         .Columns.Add("Hora", GetType(String))
         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("NombreCaja", GetType(String))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("ImportePesos", GetType(Decimal))
         .Columns.Add("ImporteDolares", GetType(Decimal))
         .Columns.Add("ImporteTickets", GetType(Decimal))
         .Columns.Add("ImporteCheques", GetType(Decimal))
         .Columns.Add("ImporteTarjetas", GetType(Decimal))
         .Columns.Add("ImporteTransfBancaria", GetType(Decimal))
         .Columns.Add("ImporteTransfBancariaDolares", GetType(Decimal))
         .Columns.Add("NombreCuentaBancaria", GetType(String))
         .Columns.Add("ImporteRetenciones", GetType(Decimal))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("IdEstadoComprobante", GetType(String))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("IdUsuario", GetType(String))
         .Columns.Add("FechaActualizacion", GetType(Date))
         .Columns.Add("NombreZonaGeografica", GetType(String))
         .Columns.Add("CotizacionDolar", GetType(Decimal))
      End With

      Return dtTemp

   End Function

#End Region

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion()))
   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro

         filtro.AppendFormat("Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)

         If Me.chbCategoria.Checked Then
            filtro.AppendFormat(" - Categoria: {0}", Me.cmbCategoria.Text)
         End If

         If Me.chbRecibo.Checked Then
            filtro.AppendFormat(" - Tipo de Comprobante: {0}", Me.cmbTiposComprobantesRec.Text)
         End If

         If Me.chbCliente.Checked Then
            filtro.AppendFormat("Cliente: {0} - {1}", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbLetra.Checked Then
            filtro.AppendFormat(" - Letra: {0}", Me.cmbLetra.Text)
         End If

         If Me.chbEmisor.Checked Then
            filtro.AppendFormat(" - Emisor: {0}", Me.cmbEmisor.Text)
         End If

         If Me.chbNumero.Checked Then
            filtro.AppendFormat(" - Número: {0}", Me.txtNumero.Text)
         End If

         If Me.chbVendedor.Checked Then
            filtro.AppendFormat(" - Vendedor: {0}", Me.cmbVendedor.Text)
         End If

         If Me.chbUsuario.Checked Then
            filtro.AppendFormat(" - Usuario: {0}", Me.cmbUsuario.Text)
         End If

         If Me.chbCaja.Checked Then
            filtro.AppendFormat(" - Caja: {0}", Me.cmbCajas.Text)
         End If

         If Me.chbZonaGeografica.Checked Then
            filtro.AppendFormat(" - Zona Geografica: {0}", Me.cmbZonaGeografica.Text)
         End If

      End With

      Return filtro.ToString()
   End Function

   Private Sub tsbPreferencias_Click_1(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(
         Sub()
            Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
            pre.ShowDialog()
         End Sub)
   End Sub
End Class