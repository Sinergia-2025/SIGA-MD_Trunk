Public Class ImpresionMasivaRecibos

   Private _publicos As Publicos
   Private _silentMode As Boolean

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
   End Sub

   Public Sub New(silentMode As Boolean)
      Me.New()
      _silentMode = silentMode
   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "CTACTECLIE")

         _publicos.CargaComboDesdeEnum(cmbExportado, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(cmbAfectaCaja, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         cmbEstadoComprobante.Items.Insert(0, "NORMAL")
         cmbEstadoComprobante.Items.Insert(1, "ANULADO")

         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         _publicos.CargaComboUsuarios(cmbUsuario)

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreCaja", "Observacion"}, {"Ver"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         RefrescarDatos()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ExportarImprimir_Click("Imprimiendo...", AddressOf Imprimir))
   End Sub
   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      TryCatched(Sub() ExportarImprimir_Click("Exportando...", AddressOf Exportar))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

#Region "Eventos Buscador Cliente"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoComprobante.CheckedChanged
      TryCatched(Sub() chbEstadoComprobante.FiltroCheckedChanged(cmbEstadoComprobante))
   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      TryCatched(Sub() chbLetra.FiltroCheckedChanged(cmbLetras))
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub

   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
   End Sub
#End Region

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
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() MarcarTodos())
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim tipoComprobante = New Reglas.TiposComprobantes().GetUno(dr.Field(Of String)("IdTipoComprobante"))
            If tipoComprobante.EsRecibo Or tipoComprobante.EsAnticipo Then
               Dim idTipoComprobante = If(tipoComprobante.EsRecibo, tipoComprobante.IdTipoComprobante, tipoComprobante.IdTipoComprobanteSecundario)
               Dim rCtaCte = New Reglas.CuentasCorrientes()
               Dim ctacte = rCtaCte.GetUna(actual.Sucursal.Id,
                                           idTipoComprobante, dr.Field(Of String)("Letra"),
                                           dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Long)("NumeroComprobante"))
               Dim imp = New RecibosImprimir()
               imp.ImprimirRecibo(ctacte, True)
            End If
         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      TryCatched(Sub() ugDetalle.PerformAction(UltraGridAction.ExitEditMode))
   End Sub

#End Region

#Region "Metodos"
   Private Sub ExportarImprimir_Click(texto As String, accion As Action)
      If ugDetalle.Rows.Count = 0 Then Exit Sub
      Dim cantidadRango = txtNroHasta.ValorNumericoPorDefecto(0I) - txtNroDesde.ValorNumericoPorDefecto(0I)
      Dim cantidadGrilla = ugDetalle.Rows.Count
      If txtNroHasta.ValorNumericoPorDefecto(0I) > 0 And cantidadRango + 1 <> cantidadGrilla Then
         Dim intDiferencia = cantidadRango + 1 - cantidadGrilla
         If ShowPregunta(String.Format("ATENCION: Existe una diferencia de {0} entre el rango seleccionado y el Rango en pantalla, ¿ Esta Seguro de Continuar ?",
                                          intDiferencia), MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
            txtNroDesde.Focus()
            Exit Sub
         End If
      End If

      tssInfo.Text = texto
      tspBarra.Visible = True
      tspBarra.Value = 0
      accion()
      tspBarra.Value = 0
      RefrescarDatos()
   End Sub

   Friend Sub MarcarTodos()
      ugDetalle.MarcarDesmarcar(cmbTodos, "Imprime")
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Enabled = False
         bscCodigoCliente.Enabled = False
         btnConsultar.Focus()
      End If
   End Sub

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

      chbUsuario.Checked = False
      chbFormaPago.Checked = False

      ugDetalle.ClearFilas()

      cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos
      chbOrdenInverso.Checked = Reglas.Publicos.Facturacion.Impresion.ImpresionMasivaOrdenInverso

      dtpDesde.Focus()

   End Sub

   Friend Sub CargaGrillaDetalle()
      Dim fechaDesde = dtpDesde.Value
      Dim fechaHasta = dtpHasta.Value

      Dim orden = If(chbOrdenInverso.Checked, "DESC", "ASC")

      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idEstadoComprobante = If(chbEstadoComprobante.Checked, cmbEstadoComprobante.Text, String.Empty)
      Dim idTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)

      Dim nroDesde = txtNroDesde.ValorNumericoPorDefecto(0L)
      Dim nroHasta = txtNroHasta.ValorNumericoPorDefecto(0L)
      Dim emisor = txtEmisor.ValorNumericoPorDefecto(0S)
      Dim idFormasPago = cmbFormaPago.ValorSeleccionado(chbFormaPago, 0I)

      Dim idUsuario = cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty)

      Dim rCtaCte = New Reglas.CuentasCorrientes()
      Dim dtDetalle = rCtaCte.GetParaImpresionMasiva(actual.Sucursal.IdSucursal,
                                                     fechaDesde, fechaHasta,
                                                     orden,
                                                     idCliente,
                                                     idTipoComprobante, cmbLetras.Text, emisor, nroDesde, nroHasta,
                                                     idEstadoComprobante,
                                                     cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos), cmbAfectaCaja.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                     idFormasPago, idUsuario, cmbExportado.Text)
      ugDetalle.DataSource = dtDetalle

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      If ugDetalle.Rows.Count > 0 Then
         btnConsultar.Focus()
      Else
         If Not _silentMode Then '# Si el método se ejecuta a través de una tarea programada no se muestra nada.
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End If
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         filtro.AppendFormat("Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         filtro.AppendFormat(" - Graban Libro: {0}", cmbGrabanLibro.Text)
         filtro.AppendFormat(" - Afecta Caja: {0}", cmbAfectaCaja.Text)

         If chbCliente.Checked Then
            filtro.AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbEstadoComprobante.Checked Then
            filtro.AppendFormat(" - Estado: {0}", cmbEstadoComprobante.Text)
         End If
         If chbTipoComprobante.Checked Then
            filtro.AppendFormat(" - Tipo de Comprobante: {0}", cmbTiposComprobantes.Text)
         End If
         If chbLetra.Checked Then
            filtro.AppendFormat(" - Letra: {0}", cmbLetras.Text)
         End If
         If Not String.IsNullOrEmpty(txtEmisor.Text.Trim()) Then
            filtro.AppendFormat(" - Emisor: {0}", txtEmisor.Text)
         End If
         If txtNroDesde.ValorNumericoPorDefecto(0I) > 0 Then
            filtro.AppendFormat(" - Nro Desde: {0}", txtNroDesde.Text)
         End If
         If txtNroHasta.ValorNumericoPorDefecto(0I) > 0 Then
            filtro.AppendFormat(" - Nro Hasta: {0}", txtNroHasta.Text)
         End If
         If chbFormaPago.Checked Then
            filtro.AppendFormat(" - Formas de Pago: {0}", cmbFormaPago.Text)
         End If
         If chbUsuario.Enabled Then
            filtro.AppendFormat(" - Usuario: {0}", cmbUsuario.Text)
         End If
         filtro.AppendFormat(" - Exportado: {0}", cmbExportado.Text)
         If chbOrdenInverso.Checked Then
            filtro.AppendFormat(" - Orden Inverso")
         End If
      End With

      Return filtro.ToString()

   End Function

   Private Sub Imprimir()

      ugDetalle.UpdateData()

      Dim dtDetalle = ugDetalle.DataSource(Of DataTable)()
      Dim drImprime = dtDetalle.Where(Function(dr) dr.Field(Of Boolean)("Imprime"))
      Dim total = drImprime.Count

      If total = 0 Then
         ShowMessage("No se indicaron comprobantes para Imprimir.")
         Exit Sub
      End If

      tspBarra.Maximum = total
      tspBarra.Value = 0

      Dim rCtaCte = New Reglas.CuentasCorrientes()
      For Each dr In drImprime
         tspBarra.PerformStep()

         tssInfo.Text = String.Format("Imprimiendo... {0} de {1}", tspBarra.Value, total)
         Application.DoEvents()

         Dim idSucursal = actual.Sucursal.IdSucursal
         Dim idTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
         Dim letra = dr.Field(Of String)("Letra")
         Dim centroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
         Dim numeroComprobante = dr.Field(Of Long)("NumeroComprobante")

         Dim recibo = rCtaCte.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

         Dim imp = New RecibosImprimir()
         imp.ImprimirRecibo(recibo, False)
      Next

      ShowMessage(String.Format("Se imprimieron {0} comprobante.", total))
   End Sub
   Friend Sub Exportar()
      Exportar(raizDestino:=Nothing, silentMode:=False)
   End Sub
   Friend Sub Exportar(raizDestino As String, silentMode As Boolean)

      ugDetalle.UpdateData()

      Dim dtDetalle = ugDetalle.DataSource(Of DataTable)()
      Dim drImprime = dtDetalle.Where(Function(dr) dr.Field(Of Boolean)("Imprime"))
      Dim total = drImprime.Count

      If total = 0 Then
         MessageBox.Show("No se indicaron comprobantes para Exportar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      '# En caso que el parámetro esté vacio, se abre el browser para seleccionar la ubicación.
      If String.IsNullOrEmpty(raizDestino) Then
         If Not FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
         raizDestino = FolderBrowserDialog1.SelectedPath
      End If

      tspBarra.Maximum = total
      tspBarra.Value = 0

      Dim ePDF As ExportarPDF = New ExportarPDF()
      Dim cuitEmpresa As String = Reglas.Publicos.CuitEmpresa
      Dim rCtaCte = New Reglas.CuentasCorrientes()
      For Each dr In drImprime

         tspBarra.PerformStep()

         tssInfo.Text = String.Format("Exportando... {0} de {1}", tspBarra.Value, total)
         Application.DoEvents()

         Dim idSucursal = actual.Sucursal.IdSucursal
         Dim idTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
         Dim letra = dr.Field(Of String)("Letra")
         Dim centroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
         Dim numeroComprobante = dr.Field(Of Long)("NumeroComprobante")

         Dim recibo = rCtaCte.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

         Try
            Dim archivoDestino As String = IO.Path.Combine(raizDestino,
                                                           String.Format("{0}_{1}_{2}_{3:0000}_{4:00000000}.pdf",
                                                                         cuitEmpresa,
                                                                         recibo.TipoComprobante.DescripcionAbrev,
                                                                         recibo.Letra,
                                                                         recibo.CentroEmisor,
                                                                         recibo.NumeroComprobante))

            ePDF.ExportarRecibo(recibo, archivoDestino)

            rCtaCte.ActualizaFechaExportacion(recibo, Now)
         Catch ex As Exception
            Throw New Exception(String.Format("Error Exportando {0} {1} {2:0000}-{3:00000000}", recibo.TipoComprobante.Descripcion, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante))
         End Try
      Next
      If Not _silentMode Then
         MessageBox.Show(String.Format("Se imprimieron {0} comprobante.", total))
      End If

   End Sub

#End Region

End Class