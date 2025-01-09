Public Class InfComisionesCobranzasRealizadas

#Region "Campos"

   Private _publicos As Publicos
   Private TotalContadoNeto As Decimal = 0
   Private TotalContadoFinal As Decimal = 0
   Private TotalCtaCteNeto As Decimal = 0
   Private TotalCtaCteFinal As Decimal = 0
   Private _idUsuario As String = actual.Nombre
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            If New Reglas.Empleados().GetPorUsuario(_idUsuario).Rows.Count = 0 Then
               _idUsuario = String.Empty
            End If

            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario)
            If String.IsNullOrWhiteSpace(_idUsuario) Then
               cmbVendedor.SelectedIndex = -1
            Else
               chbVendedor.Checked = True
               chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
            End If

            _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
            cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual

            _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR, _idUsuario)
            If String.IsNullOrWhiteSpace(_idUsuario) Then
               cmbCobrador.SelectedIndex = -1
            Else
               chbCobrador.Checked = True
               chbCobrador.Enabled = False  'Para que no pueda modificarlo manualmente
            End If

            _publicos.CargaComboDesdeEnum(cmbOrigenCobrador, GetType(Entidades.OrigenFK))
            cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Actual


            _publicos.CargaComboDesdeEnum(cmbComisionPor, GetType(Entidades.Empleado.Tipo))
            cmbComisionPor.SelectedValue = Entidades.Empleado.Tipo.Vendedor

            cmbTiposComprobantesAplicador.Initializar(False, "VENTAS", "CTACTECLIE")
            cmbTiposComprobantesAplicador.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

            cmbTiposComprobantesAplicados.Initializar(False, "VENTAS")
            cmbTiposComprobantesAplicados.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

            _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
            cmbFormaPago.SelectedIndex = -1

            cmbComercial.Items.Insert(0, "TODOS")
            cmbComercial.Items.Insert(1, "SI")
            cmbComercial.Items.Insert(2, "NO")
            cmbComercial.SelectedIndex = 0

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            ugDetalle.AgregarTotalesSuma({"ImporteNeto", "ImporteTotal", "Comision"})

            'Hay que colocarlo del CargarColumnasASumar porque sino da error.

            _publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))

            cmbGrupos.Inicializar()
            cmbGrupos.SelectedValue = Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()

            ugDetalle.AgregarFiltroEnLinea({"Codigo", "NombreVendedor", "NombreCliente"})

            Dim OrdenarCobranzaPor = Reglas.Publicos.OrdenarCobranzaPor

            Select Case OrdenarCobranzaPor
               Case "Fecha"
                  Me.rbtOrdenarCobranzaPorFecha.Checked = True
               Case Else
                  Me.rbtOrdenarCobranzaPorVendedor.Checked = True
            End Select

            PreferenciasLeer(ugDetalle, tsbPreferencias)

            'Seteo que permita filtrarse en los campos
            'Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]

            ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not cmbSucursal.Enabled

            'Se agrego el Boton Preferencias
            ''Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
            'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
            'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
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
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim filtros = CargarFiltrosImpresion()
            Dim dtCC = DirectCast(ugDetalle.DataSource, DataTable)

            Dim parm = New ReportParameterCollection()
            parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion)
            parm.Add("NombreSucursal", actual.Sucursal.Nombre)
            parm.Add("Filtros", filtros)
            parm.Add("TotalContadoNeto", TotalContadoNeto)
            parm.Add("TotalContadoFinal", TotalContadoFinal)
            parm.Add("TotalCtaCteNeto", TotalCtaCteNeto)
            parm.Add("TotalCtaCteFinal", TotalCtaCteFinal)

            Dim frmImprime = New VisorReportes("Eniac.Win.InfCobranzasRealizadas.rdlc", "DSReportes_InfCobranzasRealizadasCC", dtCC, parm, True, 1) '# 1 = Cantidad Copias
            frmImprime.Text = Text
            frmImprime.WindowState = FormWindowState.Maximized
            frmImprime.Show()
         End Sub)
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
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbFomaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFomaPago.CheckedChanged
      TryCatched(Sub() chbFomaPago.FiltroCheckedChanged(cmbFormaPago))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
               ShowMessage("ATENCION: Es obligatorio seleccionar un Cliente")
               bscCodigoCliente.Focus()
               Exit Sub
            End If

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            CargaGrillasDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#Region "Eventos Buscador Cliente"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes(bscCliente)
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text, False)
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

#End Region

#Region "Metodos"

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

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now
      chbCliente.Checked = False
      chbVendedor.Checked = False
      cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual
      chbCobrador.Checked = False
      cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Actual
      cmbComercial.SelectedIndex = 0

      cmbTiposComprobantesAplicador.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      cmbTiposComprobantesAplicados.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      chbFomaPago.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      cmbGrupos.Refrescar()
      cmbGrabanLibro.SelectedIndex = 0
      cmbSucursal.Refrescar()

      cmbComisionPor.SelectedValue = Entidades.Empleado.Tipo.Vendedor

      Dim OrdenarCobranzaPor = Reglas.Publicos.OrdenarCobranzaPor

      Select Case OrdenarCobranzaPor
         Case "Fecha"
            rbtOrdenarCobranzaPorFecha.Checked = True
         Case Else
            rbtOrdenarCobranzaPorVendedor.Checked = True
      End Select

      dtpDesde.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillasDetalle()
      Dim idCliente = If(IsNumeric(bscCodigoCliente.Tag), Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idcobrador = cmbCobrador.ValorSeleccionado(chbCobrador, 0I)
      Dim idFormaPago = cmbFormaPago.ValorSeleccionado(chbFomaPago, 0I)

      Dim ordenarPor = If(rbtOrdenarCobranzaPorFecha.Checked,
                          Entidades.FiltrosReportes.InfCobranzasRealizadas.OrdenadoPor.Fecha,
                          Entidades.FiltrosReportes.InfCobranzasRealizadas.OrdenadoPor.Vendedor)

      Dim rCaja = New Reglas.Cajas()
      Dim dtDetalleCC = rCaja.GetComisionesCobranzasDetalladas(cmbSucursal.GetSucursales(),
                                                     dtpDesde.Value, dtpHasta.Value,
                                                     idCliente, idVendedor, cmbOrigenVendedor.ValorSeleccionado(Of Entidades.OrigenFK),
                                                     cmbTiposComprobantesAplicador.GetTiposComprobantes(),
                                                     cmbTiposComprobantesAplicados.GetTiposComprobantes(),
                                                     idFormaPago, cmbComercial.Text,
                                                     cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                     cmbGrupos.GetGruposTiposComprobantes(),
                                                     ordenarPor, cmbComisionPor.ValorSeleccionado(Of Entidades.Empleado.Tipo),
                                                     idcobrador, cmbOrigenCobrador.ValorSeleccionado(Of Entidades.OrigenFK))


      Dim TotalContadoNeto As Decimal = 0
      Dim TotalContadoFinal As Decimal = 0
      Dim TotalCtaCteNeto As Decimal = 0
      Dim TotalCtaCteFinal As Decimal = 0
      Dim ImporteNeto As Decimal = 0
      Dim CoeficienteIVA As Decimal = Publicos.ProductoIVA

      Dim dtCC As DataTable = Me.CrearDT()
      Dim drClCC As DataRow
      For Each dr As DataRow In dtDetalleCC.Rows
         drClCC = dtCC.NewRow()

         drClCC("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
         If cmbOrigenVendedor.ValorSeleccionado(Of Entidades.OrigenFK) = Entidades.OrigenFK.Movimiento Then
            drClCC("IdVendedor") = dr("IdVendedor").ToString()
            drClCC("NombreVendedor") = dr("NombreVendedor").ToString()
         Else
            drClCC("IdVendedor") = dr("IdVendedorClie").ToString()
            drClCC("NombreVendedor") = dr("NombreVendedorClie").ToString()
         End If

         If cmbOrigenCobrador.ValorSeleccionado(Of Entidades.OrigenFK) = Entidades.OrigenFK.Movimiento Then
            drClCC("IdCobrador") = dr("IdCobrador").ToString()
            drClCC("NombreCobrador") = dr("NombreCobrador").ToString()
         Else
            drClCC("IdCobrador") = dr("IdCobradorClie").ToString()
            drClCC("NombreCobrador") = dr("NombreCobradorClie").ToString()
         End If

         drClCC("Fecha") = Date.Parse(dr("Fecha").ToString())
         drClCC("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
         drClCC("Letra") = dr("Letra").ToString()
         drClCC("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
         drClCC("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
         drClCC("IdCliente") = Long.Parse(dr("IdCliente").ToString())
         drClCC("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
         drClCC("NombreCliente") = dr("NombreCliente").ToString()

         If Not String.IsNullOrEmpty(dr("ImporteNeto").ToString()) Then
            ImporteNeto = Decimal.Parse(dr("ImporteNeto").ToString())
         Else
            ImporteNeto = Decimal.Round(Decimal.Parse(dr("ImporteTotal").ToString()) / (1 + CoeficienteIVA / 100), 2)   'Normalmente el 21
         End If

         drClCC("ImporteNeto") = ImporteNeto

         If dr("TipoCobro").ToString() = "VENTA" Then
            TotalContadoNeto = TotalContadoNeto + ImporteNeto
         Else
            TotalCtaCteNeto = TotalCtaCteNeto + ImporteNeto
         End If

         drClCC("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

         drClCC("ComisionPorVenta") = Decimal.Parse(dr("ComisionPorVenta").ToString())
         If Not String.IsNullOrEmpty(dr("Comision").ToString()) Then
            drClCC("Comision") = Decimal.Parse(dr("Comision").ToString())
         Else
            drClCC("Comision") = ImporteNeto * Decimal.Parse(dr("ComisionPorVenta").ToString()) / 100
         End If

         If dr("TipoCobro").ToString() = "VENTA" Then

            TotalContadoFinal = TotalContadoFinal + Decimal.Parse(dr("ImporteTotal").ToString())

         Else

            drClCC("IdTipoComprobante2") = dr("IdTipoComprobante2").ToString()
            drClCC("Letra2") = dr("Letra2").ToString()
            drClCC("CentroEmisor2") = Integer.Parse(dr("CentroEmisor2").ToString())
            drClCC("NumeroComprobante2") = Long.Parse(dr("NumeroComprobante2").ToString())
            drClCC("CuotaNumero2") = Integer.Parse(dr("CuotaNumero2").ToString())

            If Not String.IsNullOrEmpty(dr("Fecha2").ToString()) Then
               drClCC("Fecha2") = Date.Parse(dr("Fecha2").ToString())
            End If

            If Not String.IsNullOrEmpty(dr("DiasCobranza").ToString()) Then
               drClCC("DiasCobranza") = Integer.Parse(dr("DiasCobranza").ToString())
            End If

            TotalCtaCteFinal = TotalCtaCteFinal + Decimal.Parse(drClCC("ImporteTotal").ToString())

         End If

         drClCC("FormaPago") = dr("DescripcionFormasPago").ToString()

         dtCC.Rows.Add(drClCC)

      Next

      Me.TotalContadoFinal = TotalContadoFinal
      Me.TotalContadoNeto = TotalContadoNeto
      Me.TotalCtaCteFinal = TotalCtaCteFinal
      Me.TotalCtaCteNeto = TotalCtaCteNeto

      ugDetalle.DataSource = dtCC

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdVendedor", GetType(Integer))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("NombreCobrador", GetType(String))
         .Columns.Add("Fecha", GetType(Date))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("ImporteNeto", GetType(Decimal))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("ComisionPorVenta", GetType(Decimal))
         .Columns.Add("Comision", GetType(Decimal))
         .Columns.Add("IdTipoComprobante2", GetType(String))
         .Columns.Add("Letra2", GetType(String))
         .Columns.Add("CentroEmisor2", GetType(Integer))
         .Columns.Add("NumeroComprobante2", GetType(Long))
         .Columns.Add("CuotaNumero2", GetType(Integer))
         .Columns.Add("Fecha2", GetType(Date))
         .Columns.Add("DiasCobranza", GetType(Integer))
         .Columns.Add("FormaPago", GetType(String))
         .Columns.Add("IdCobrador", GetType(Integer))

      End With
      Return dtTemp
   End Function

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=True, muestraNombre:=False)
         .AppendFormat(" - Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)
         If chbCliente.Checked Then .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         If chbVendedor.Checked Then .AppendFormat(" - Vendedor: {0} ({1})", cmbVendedor.Text, cmbOrigenVendedor.Text)
         If chbFomaPago.Checked Then .AppendFormat(" - Forma de Pago: {0}", cmbFormaPago.Text)

         cmbTiposComprobantesAplicador.CargarFiltrosImpresionTiposComprobantes(filtro, muestraId:=False, muestraNombre:=True)
         cmbTiposComprobantesAplicados.CargarFiltrosImpresionTiposComprobantes(filtro, muestraId:=False, muestraNombre:=True)

         .AppendFormat(" - Comercial: {0}", cmbComercial.Text)
         .AppendFormat(" - Graban Libro: {0}", cmbGrabanLibro.Text)
         .AppendFormat(" - Grupo: {0}", cmbGrupos.Text)
      End With

      Return filtro.ToString()
   End Function

   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged
      TryCatched(Sub() chbCobrador.FiltroCheckedChanged(cmbCobrador))
   End Sub

#End Region

End Class