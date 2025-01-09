Public Class ImpresionMasivaDeCuotas

#Region "Campos"

   Private _publicos As Publicos
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Publicos()

            dtpDesde.Value = Date.Today
            dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

            _publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
            cmbTiposComprobantes.SelectedIndex = -1

            _publicos.CargaComboDesdeEnum(cmbExportado, GetType(Entidades.Publicos.SiNoTodos))

            cmbEstadoComprobante.Items.Insert(0, "NORMAL")
            cmbEstadoComprobante.Items.Insert(1, "ANULADO")
            cmbEstadoComprobante.SelectedIndex = -1

            cmbGrabanLibro.Items.Insert(0, "TODOS")
            cmbGrabanLibro.Items.Insert(1, "SI")
            cmbGrabanLibro.Items.Insert(2, "NO")
            cmbGrabanLibro.SelectedIndex = 0

            cmbAfectaCaja.Items.Insert(0, "TODOS")
            cmbAfectaCaja.Items.Insert(1, "SI")
            cmbAfectaCaja.Items.Insert(2, "NO")
            cmbAfectaCaja.SelectedIndex = 0

            _publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
            cmbFormaPago.SelectedIndex = -1

            _publicos.CargaComboUsuarios(Me.cmbUsuario)

            ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreCaja", "Observacion"}, {"Ver"})

            PreferenciasLeer(ugDetalle, tsbPreferencias)

            RefrescarDatos()

         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(0L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
         End Sub)
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCliente)
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text, True)
         End Sub)
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               If e.Cell.Column.Key = "Ver" Then

                  Dim ventas = New Reglas.Ventas()
                  Dim export = New ImpresionCuotasCuentasCorrientes()

                  Dim idSucursal = dr.Field(Of Integer)("IdSucursal")
                  Dim idTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
                  Dim letra = dr.Field(Of String)("Letra")
                  Dim centroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
                  Dim numeroComprobante = dr.Field(Of Long)("NumeroComprobante")

                  Dim venta = ventas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
                  export.Ver(venta)
               End If
            End If
         End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
               ShowMessage("No seleccionó un Cliente aunque activó ese Filtro")
               bscCodigoCliente.Focus()
               Exit Sub
            End If
            CargaGrillaDetalle()
         End Sub)
   End Sub

#End Region

#Region "Métodos"

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         filtro.AppendFormat("Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)

         If chbCliente.Checked Then filtro.AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         If cmbGrabanLibro.SelectedIndex > 0 Then filtro.AppendFormat(" - Graban Libro: {0}", cmbGrabanLibro.Text)
         If cmbAfectaCaja.SelectedIndex > 0 Then filtro.AppendFormat(" - Afecta Caja: {0}", cmbAfectaCaja.Text)
         If chbEstadoComprobante.Checked Then filtro.AppendFormat(" - Estado: {0}", cmbEstadoComprobante.Text)
         If chbLetra.Checked Then filtro.AppendFormat(" - Letra: {0}", cmbLetras.Text)
         If Not String.IsNullOrWhiteSpace(txtEmisor.Text) Then filtro.AppendFormat(" - Emisor: {0}", txtEmisor.Text)
         If Not String.IsNullOrWhiteSpace(txtNroDesde.Text) Then filtro.AppendFormat(" - Nro Desde: {0}", txtNroDesde.Text)
         If Not String.IsNullOrWhiteSpace(txtNroHasta.Text) Then filtro.AppendFormat(" - Nro Hasta: {0}", txtNroHasta.Text)
         If chbTipoComprobante.Checked Then filtro.AppendFormat(" - Tipo de Comprobante: {0}", cmbTiposComprobantes.Text)
         If chbFormaPago.Checked Then filtro.AppendFormat(" - Formas de Pago: {0}", cmbFormaPago.Text)
         If cmbUsuario.Enabled Then filtro.AppendFormat(" - Usuario: {0}", cmbUsuario.SelectedValue.ToString())

      End With
      Return filtro.ToString()
   End Function

   Private Sub Exportar()
      ugDetalle.UpdateData()

      Dim dt = DirectCast(ugDetalle.DataSource, DataTable)
      Dim drColImprime = dt.Select("Imprime")
      Dim totalImprimir = drColImprime.Count

      If totalImprimir = 0 Then
         ShowMessage("No se seleccionaron comprobantes para Exportar.")
         Exit Sub
      End If

      If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
         tspBarra.Maximum = totalImprimir
         tspBarra.Value = 0

         Dim ventas = New Reglas.Ventas()
         Dim export = New ImpresionCuotasCuentasCorrientes()

         For Each dr In drColImprime
            tspBarra.PerformStep()
            tssInfo.Text = String.Format("Exportando... {0} de {1}", tspBarra.Value, totalImprimir)
            Application.DoEvents()

            Dim idSucursal = dr.Field(Of Integer)("IdSucursal")
            Dim idTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
            Dim letra = dr.Field(Of String)("Letra")
            Dim centroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
            Dim numeroComprobante = dr.Field(Of Long)("NumeroComprobante")

            Dim venta = ventas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
            export.Exportar(venta, FolderBrowserDialog1.SelectedPath)
         Next

         ShowMessage(String.Format("Se imprimieron {0} comprobante.", totalImprimir))
      End If
   End Sub

   Private Sub Imprimir()
      ugDetalle.UpdateData()

      Dim dt = DirectCast(ugDetalle.DataSource, DataTable)
      Dim drColImprime = dt.Select("Imprime")
      Dim totalImprimir = drColImprime.Count

      If totalImprimir = 0 Then
         ShowMessage("No se seleccionaron comprobantes para Exportar.")
         Exit Sub
      End If

      tspBarra.Maximum = totalImprimir
      tspBarra.Value = 0

      Dim ventas = New Reglas.Ventas()
      Dim export = New ImpresionCuotasCuentasCorrientes()

      For Each dr In drColImprime
         tspBarra.PerformStep()
         tssInfo.Text = String.Format("Imprimiendo... {0} de {1}", tspBarra.Value, totalImprimir)

         Application.DoEvents()

         Dim idSucursal = dr.Field(Of Integer)("IdSucursal")
         Dim idTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
         Dim letra = dr.Field(Of String)("Letra")
         Dim centroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
         Dim numeroComprobante = dr.Field(Of Long)("NumeroComprobante")


         Dim venta = ventas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
         export.Imprimir(venta)
      Next

      ShowMessage(String.Format("Se imprimieron {0} comprobante.", totalImprimir))
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
         Sub()
            For Each dr As UltraGridRow In ugDetalle.Rows
               dr.Cells("Imprime").Value = chbTodos.Checked
            Next
         End Sub)
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      bscCliente.Enabled = False
      bscCodigoCliente.Enabled = False
   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("Imprime", GetType(Boolean))
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
         .Columns.Add("ImporteTickets", GetType(Decimal))
         .Columns.Add("ImporteCheques", GetType(Decimal))
         .Columns.Add("ImporteTarjetas", GetType(Decimal))
         .Columns.Add("ImporteTransfBancaria", GetType(Decimal))
         .Columns.Add("NombreCuentaBancaria", GetType(String))
         .Columns.Add("ImporteRetenciones", GetType(Decimal))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("IdEstadoComprobante", GetType(String))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("IdUsuario", GetType(String))
         .Columns.Add("FechaActualizacion", GetType(Date))
      End With
      Return dtTemp
   End Function

   Private Sub RefrescarDatos()
      chkMesCompleto.Checked = False

      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbCliente.Checked = False
      chbEstadoComprobante.Checked = False

      chbTipoComprobante.Checked = False
      chbLetra.Checked = False

      cmbLetras.SelectedIndex = -1
      txtEmisor.Text = String.Empty
      txtNroDesde.Text = String.Empty
      txtNroHasta.Text = String.Empty

      cmbGrabanLibro.SelectedIndex = 0
      cmbAfectaCaja.SelectedIndex = 0
      cmbExportado.SelectedIndex = 0


      chbUsuario.Checked = False
      chbFormaPago.Checked = False

      ugDetalle.ClearFilas()

      chbTodos.Checked = False
      chbOrdenInverso.Checked = Reglas.Publicos.Facturacion.Impresion.ImpresionMasivaOrdenInverso

      dtpDesde.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idCliente = If(chbCliente.Checked, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoCliente.Tag, 0L), 0L)
      Dim idTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)
      Dim emisor = txtEmisor.ValorNumericoPorDefecto(0S)
      Dim idUsuario = cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty)
      Dim idEstadoComprobante = cmbEstadoComprobante.ValorSeleccionado(chbEstadoComprobante, String.Empty)
      Dim idFormasPago = cmbFormaPago.ValorSeleccionado(chbFormaPago, 0I)

      '      Dim dtDetalle As DataTable

      Dim rCtaCte = New Reglas.CuentasCorrientes()
      Using dtDetalle = rCtaCte.GetImpresionCuotasMasiva(actual.Sucursal.IdSucursal,
                                                         dtpDesde.Value, dtpHasta.Value,
                                                         orden:=If(chbOrdenInverso.Checked, "DESC", "ASC"),
                                                         idCliente,
                                                         idTipoComprobante, cmbLetras.Text, emisor,
                                                         txtNroDesde.ValorNumericoPorDefecto(0L),
                                                         txtNroHasta.ValorNumericoPorDefecto(0L),
                                                         idEstadoComprobante,
                                                         cmbGrabanLibro.Text, cmbAfectaCaja.Text,
                                                         idFormasPago,
                                                         idUsuario,
                                                         cmbExportado.Text)
         Dim dt = CrearDT()

         For Each dr As DataRow In dtDetalle.Rows
            Dim drCl = dt.NewRow()

            drCl("Imprime") = False

            drCl("Ver") = "..."
            drCl("IdSucursal") = dr.Field(Of Integer)("IdSucursal")
            drCl("Fecha") = dr.Field(Of Date)("Fecha").Date
            drCl("Hora") = dr.Field(Of Date)("Fecha").ToString("HH:mm")
            drCl("IdCliente") = dr.Field(Of Long)("IdCliente")
            drCl("CodigoCliente") = dr.Field(Of Long)("CodigoCliente")
            drCl("NombreCliente") = dr.Field(Of String)("NombreCliente")
            drCl("IdTipoComprobante") = dr.Field(Of String)("IdTipoComprobante")
            drCl("Letra") = dr.Field(Of String)("Letra")
            drCl("CentroEmisor") = dr.Field(Of Integer)("CentroEmisor")
            drCl("NumeroComprobante") = dr.Field(Of Long)("NumeroComprobante")
            drCl("ImportePesos") = dr.Field(Of Decimal)("ImportePesos")
            drCl("ImporteTickets") = dr.Field(Of Decimal)("ImporteTickets")
            drCl("ImporteCheques") = dr.Field(Of Decimal)("ImporteCheques")
            drCl("ImporteTarjetas") = dr.Field(Of Decimal)("ImporteTarjetas")
            If String.IsNullOrEmpty(dr.Field(Of Decimal)("ImporteTransfBancaria").ToString()) Then
               drCl("ImporteTransfBancaria") = 0
               drCl("NombreCuentaBancaria") = String.Empty
            Else
               drCl("ImporteTransfBancaria") = dr.Field(Of Decimal)("ImporteTransfBancaria")
               drCl("NombreCuentaBancaria") = dr.Field(Of String)("NombreCuentaBancaria")
            End If
            drCl("ImporteRetenciones") = dr.Field(Of Decimal)("ImporteRetenciones")
            drCl("ImporteTotal") = dr.Field(Of Decimal)("ImporteTotal")

            drCl("IdEstadoComprobante") = dr.Field(Of String)("IdEstadoComprobante")
            drCl("Observacion") = dr.Field(Of String)("Observacion")
            drCl("IdUsuario") = dr.Field(Of String)("IdUsuario")
            drCl("FechaActualizacion") = dr.Field(Of DateTime)("FechaActualizacion")

            dt.Rows.Add(drCl)
         Next

         ugDetalle.DataSource = dt
      End Using

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      If ugDetalle.Rows.Count > 0 Then
         btnConsultar.Focus()
      Else
         MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(
         Sub()
            bscCodigoCliente.Enabled = chbCliente.Checked
            bscCliente.Enabled = chbCliente.Checked

            bscCodigoCliente.Text = String.Empty
            bscCodigoCliente.Tag = Nothing
            bscCliente.Text = String.Empty

            bscCodigoCliente.Focus()
         End Sub)
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged

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

         ShowError(ex)

      End Try
   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked
         'Me.cmbLetras.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
            'Me.cmbLetras.SelectedIndex = -1
         Else
            If Me.cmbTiposComprobantes.Items.Count > 0 Then
               Me.cmbTiposComprobantes.SelectedIndex = 0
            End If
         End If

         Me.cmbTiposComprobantes.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged

      Try
         Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked

         If Not Me.chbFormaPago.Checked Then
            Me.cmbFormaPago.SelectedIndex = -1
         Else
            If Me.cmbFormaPago.Items.Count > 0 Then
               Me.cmbFormaPago.SelectedIndex = 0
            End If
         End If

         Me.cmbFormaPago.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      Try
         Me.cmbLetras.Enabled = Me.chbLetra.Checked

         If Not Me.chbLetra.Checked Then
            Me.cmbLetras.SelectedIndex = -1
         Else
            If Me.cmbLetras.Items.Count > 0 Then
               Me.cmbLetras.SelectedIndex = 0
            End If
         End If

         Me.chbLetra.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuario.Enabled = Me.chbUsuario.Checked

         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
         Else
            If Me.cmbUsuario.Items.Count > 0 Then
               Me.cmbUsuario.SelectedIndex = 0
            End If
         End If

         Me.cmbUsuario.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbEstadoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoComprobante.CheckedChanged

      Try
         Me.cmbEstadoComprobante.Enabled = Me.chbEstadoComprobante.Checked

         If Not Me.chbEstadoComprobante.Checked Then
            Me.cmbEstadoComprobante.SelectedIndex = -1
         Else
            If Me.cmbEstadoComprobante.Items.Count > 0 Then
               Me.cmbEstadoComprobante.SelectedIndex = 0
            End If
         End If

         Me.cmbEstadoComprobante.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try
         Me.ugDetalle.UpdateData()

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         If Integer.Parse("0" & Me.txtNroHasta.Text) > 0 And Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 <> Me.ugDetalle.Rows.Count Then

            Dim intDiferencia As Integer = Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 - Me.ugDetalle.Rows.Count

            If MessageBox.Show("ATENCION: Existe una diferencia de " & intDiferencia.ToString() & " entre el rango seleccionado y el Rango en pantalla, ¿ Esta Seguro de Continuar ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               Me.txtNroDesde.Focus()
               Exit Sub
            End If

         End If

         Me.tssInfo.Text = "Imprimiendo..."
         Me.tspBarra.Visible = True
         Me.tspBarra.Value = 0
         Me.Imprimir()
         Me.tspBarra.Value = 0
         Me.btnConsultar.PerformClick()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.tspBarra.Visible = False
         Me.tssInfo.Text = String.Empty
      End Try
   End Sub

   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         If Integer.Parse("0" & Me.txtNroHasta.Text) > 0 And Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 <> Me.ugDetalle.Rows.Count Then
            Dim intDiferencia As Integer = Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 - Me.ugDetalle.Rows.Count
            If MessageBox.Show("ATENCION: Existe una diferencia de " & intDiferencia.ToString() & " entre el rango seleccionado y el Rango en pantalla, ¿ Esta Seguro de Continuar ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               Me.txtNroDesde.Focus()
               Exit Sub
            End If
         End If

         Me.tssInfo.Text = "Exportando..."
         Me.tspBarra.Visible = True
         Me.tspBarra.Value = 0
         Me.Exportar()
         Me.tspBarra.Value = 0
         Me.btnConsultar.PerformClick()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.tspBarra.Visible = False
         Me.tssInfo.Text = String.Empty
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub

#End Region

End Class