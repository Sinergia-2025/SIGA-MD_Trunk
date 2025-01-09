Public Class InformeSituacionCrediticiaClientes

#Region "Campos"
   Private _publicos As Publicos
   Private _idUsuario As String = actual.Nombre
   Private _fechaCobroDesdeDefault As DateTime
   Private pivotcolName As StringBuilder = New StringBuilder()
   Private sumPivot As StringBuilder = New StringBuilder()
   Private dtColumnas As DataTable = New DataTable
#End Region

#Region "Overrides/Overloads"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(_idUsuario).Rows.Count = 0 Then
            _idUsuario = ""
         End If

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario)
         If _idUsuario = "" Then
            cmbVendedor.SelectedIndex = -1
         Else
            chbVendedor.Checked = True
            chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         '   _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
         '     cmbZonaGeografica.SelectedIndex = -1

         _publicos.CargaComboCategorias(cmbCategoria)

         _publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))
         cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbActivos, Entidades.Publicos.SiNoTodos.TODOS)

         '     _publicos.CargaComboProvincias(cmbProvincia)

         '     _publicos.CargaComboGrupos(cmbGrupos)

         '  _publicos.CargaComboGrupoCategoria(cmbGrupoCategoria)

         '      cmbGrupos.SelectedIndex = -1

         '      _publicos.CargaComboEstadosClientes(cmbEstadosClientes)
         '       cmbEstadosClientes.SelectedIndex = -1

         _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)

         _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK)).SelectedValue = Entidades.OrigenFK.Actual
         _publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK)).SelectedValue = Entidades.OrigenFK.Actual
         _publicos.CargaComboDesdeEnum(cmbOrigenCobrador, GetType(Entidades.OrigenFK)).SelectedValue = Entidades.OrigenFK.Actual

         '_publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         'cmbFormaPago.SelectedIndex = -1

         ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)

         'If cmbZonaGeografica.Items.Count > 1 Then
         '   ugDetalle.DisplayLayout.Bands(0).Columns("NombreZonaGeografica").Hidden = False
         '   ugDetalle.DisplayLayout.Bands(0).Columns("Telefonos").Hidden = True
         'Else
         '   ugDetalle.DisplayLayout.Bands(0).Columns("NombreZonaGeografica").Hidden = True
         '   ugDetalle.DisplayLayout.Bands(0).Columns("Telefonos").Hidden = False
         'End If



         'Hay que colocarlo del CargarColumnasASumar porque sino da error.
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal
         cmbSucursal.SelectedIndex = 0

         ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled

         'tsbEmitirRecibo.Visible = New Reglas.Usuarios().TienePermisos("RecibosNuevos")
         'tssEmitirRecibo.Visible = tsbEmitirRecibo.Visible

         '-.PE-32019.-
         _publicos.CargaComboDesdeEnum(cmbTipoCliente, GetType(Entidades.Cliente.ClienteVinculado))
         cmbTipoCliente.SelectedIndex = 0

         _fechaCobroDesdeDefault = Date.Today.AddDays(Reglas.Publicos.CtaCte.SaldoLimiteDeCreditoDiasSumarFechaCobro).Date
         dtpFechaCobroCheques.Value = _fechaCobroDesdeDefault

         FiltersManager1.Refrescar()

      End Sub)
   End Sub

   'Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
   '   If keyData = Keys.F5 Then
   '      tsbRefrescar.PerformClick()
   '   ElseIf keyData = Keys.F3 Then
   '      btnConsultar.PerformClick()
   '   ElseIf keyData = Keys.F8 Then
   '      '     tsbEmitirRecibo.PerformClick()
   '   Else
   '      Return MyBase.ProcessCmdKey(msg, keyData)
   '   End If
   '   Return True
   'End Function

#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs)
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs)
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim dt = ugDetalle.DataSource(Of DataTable)
         Dim parm = New ReportParameterCollection(CargarFiltrosImpresion())

         Dim frmImprime As VisorReportes
         If Not chbFecha.Checked Then
            Dim reporte As Entidades.InformePersonalizadoResuelto
            If cmbVendedor.SelectedIndex >= 0 Then
               reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.SaldosCtaCteClientes, "Eniac.Win.SaldosCtaCteClientes.rdlc")
               frmImprime = New VisorReportes(reporte.NombreArchivo, "SistemaDataSet_SaldosCtaCteClientes", dt, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad de Copias
            Else
               reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.SaldosCtaCteClientesPorVendedor, "Eniac.Win.SaldosCtaCteClientesPorVendedor.rdlc")
               frmImprime = New VisorReportes(reporte.NombreArchivo, "SistemaDataSet_SaldosCtaCteClientes", dt, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad de Copias
            End If
         Else
            If cmbVendedor.SelectedIndex >= 0 Then
               frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientesT.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True, 1) '# 1 = Cantidad de Copias
            Else
               frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientesPorVendedorT.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True, 1) '# 1 = Cantidad de Copias
            End If
         End If

         frmImprime.Text = Text
         frmImprime.WindowState = FormWindowState.Maximized

         If chbCliente.Checked Then
            If bscCodigoCliente.Selecciono Then
               If Not String.IsNullOrWhiteSpace(bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                  frmImprime.Destinatarios = bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
               End If
            ElseIf bscCliente.Selecciono Then
               If Not String.IsNullOrWhiteSpace(bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                  frmImprime.Destinatarios = bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
               End If
            End If
         End If

         frmImprime.Show()
      End Sub)
   End Sub
   Private Sub tsbImprimirAgrupadoPorZona_Click(sender As Object, e As EventArgs)
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim dt = ugDetalle.DataSource(Of DataTable)

         Dim parm = New ReportParameterCollection(CargarFiltrosImpresion())

         Dim frmImprime = New VisorReportes("Eniac.Win.EstadosDeCuentasCorrientes.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True, 1) With {
            .Text = Text,
            .WindowState = FormWindowState.Maximized
         } '# 1 = Cantidad de Copias
         frmImprime.Show()
      End Sub)
   End Sub

   Private Sub tsbEmitirRecibo_Click(sender As Object, e As EventArgs)
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Using frm As New Recibos(dr.ValorNumericoPorDefecto("IdCliente", 0L), dr.ValorNumericoPorDefecto("Saldo", 0D), cerraLuegoDeGrabar:=True)
               frm.IdFuncion = IdFuncion
               frm.ShowInTaskbar = False
               If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                  CargaGrillaDetalle()
               End If
            End Using
         End If
      End Sub)
   End Sub
   Private Sub tsbFiltros_Click(sender As Object, e As EventArgs) Handles tsbFiltros.Click
      TryCatched(Sub() FiltersManager1.SeleccionarFiltro())
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCliente.Permitido = Me.chbCliente.Checked
      Me.bscCodigoCliente.Permitido = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
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
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(
      Sub()
         chbFecha.FiltroCheckedChanged(dtpHasta, dtpHasta)
         '   chbIncluyeChTerceros.Enabled = Not chbFecha.Checked
      End Sub)
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbOrigenVendedor))
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   'Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs)
   '   TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   'End Sub
   'Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs)
   '   TryCatched(Sub() chbProvincia.FiltroCheckedChanged(cmbProvincia))
   'End Sub
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbOrigenCategoria))
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub
   'Private Sub chbGrupoCategoria_CheckedChanged(sender As Object, e As EventArgs)
   '   TryCatched(Sub() chbGrupoCategoria.FiltroCheckedChanged(cmbGrupoCategoria))
   'End Sub
   'Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs)
   '   TryCatched(Sub() chbEstadoCliente.FiltroCheckedChanged(cmbEstadosClientes))
   'End Sub
   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged
      TryCatched(Sub() chbCobrador.FiltroCheckedChanged(cmbOrigenCobrador))
      TryCatched(Sub() chbCobrador.FiltroCheckedChanged(cmbCobrador))
   End Sub
   'Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs)
   '   TryCatched(Sub() chbGrupo.FiltroCheckedChanged(cmbGrupos))
   'End Sub
   'Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs)
   '   TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
   'End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbCliente.Checked And bscCodigoCliente.Text.Length = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub
   'Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
   '   TryCatched(
   '   Sub()
   '      Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
   '      If dr IsNot Nothing Then
   '         tsbEmitirRecibo.Enabled = dr.ValorNumericoPorDefecto("Saldo", 0D) > 0
   '      End If
   '   End Sub)
   'End Sub
#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatos()

      If _idUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If

      cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual
      cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Actual
      cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual

      cmbActivos.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      '  chbZonaGeografica.Checked = False
      chbCliente.Checked = False
      chbFecha.Checked = False
      chbExcluirSaldosNegativos.Checked = False
      chbCategoria.Checked = False
      chbCobrador.Checked = False
      cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      'Me.cmbGrabanLibro.SelectedIndex = 0
      '   chbGrupo.Checked = False
      '   chbGrupoCategoria.Checked = False
      chbExcluirAnticipos.Checked = False
      chbExcluirPreComprobantes.Checked = False
      '   chbProvincia.Checked = False
      chbAgruparSaldosCHFecha.Checked = False
      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False
      chbAgregarClientesSinSaldo.Checked = False
      '    chbFormaPago.Checked = False
      '   chbEstadoCliente.Checked = False
      '  chbFormaPago.Checked = False

      ugDetalle.ClearFilas()

      '   chbAgruparIdClienteCtaCte.Checked = False

      btnConsultar.Focus()

      cmbSucursal.Refrescar()
      cmbSucursal.SelectedIndex = 0
      '-.PE-32019.-
      cmbTipoCliente.SelectedIndex = 0

      chbAgregarClientesSinSaldo.Checked = True
      chbExcluirAnticipos.Checked = True
      FiltersManager1.Refrescar()

   End Sub

   Private Sub CargaGrillaDetalle()

      '  ugDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = Not chbFecha.Checked
      'Deberian Calcularse, el valor que muestra es con el saldo a lo actual y no a la fecha filtrada
      ugDetalle.DisplayLayout.Bands(0).Columns("Saldo").Hidden = chbFecha.Checked
      '  ugDetalle.DisplayLayout.Bands(0).Columns("IMPORTE2").Hidden = chbFecha.Checked

      '---------------------------------------------------------------------------------------------
      Dim idCliente As Long = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim fechaHasta = dtpHasta.Valor(chbFecha).IfNull()
      Dim tipoCliente = cmbTipoCliente.ValorSeleccionado(Of Entidades.Cliente.ClienteVinculado)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim origenVendedor = cmbOrigenVendedor.ValorSeleccionado(Of Entidades.OrigenFK).ToString()
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoria, 0I)
      Dim origenCategoria = cmbOrigenCategoria.ValorSeleccionado(Of Entidades.OrigenFK).ToString()
      Dim origenCobrador = cmbOrigenCobrador.ValorSeleccionado(Of Entidades.OrigenFK)
      Dim idCobrador = cmbCobrador.ValorSeleccionado(chbCobrador, 0I)
      Dim agregarSinSaldo = chbAgregarClientesSinSaldo.ToStringEspañol()
      Dim incluirChequesTerceros = chbIncluyeChTerceros.ToStringEspañol()
      Dim excluirAnticipos = chbExcluirAnticipos.ToStringEspañol()
      Dim excluirSaldosNegativos = chbExcluirSaldosNegativos.ToStringEspañol()
      Dim excluirPreComprobantes = chbExcluirPreComprobantes.ToStringEspañol()


      'If tipoCliente = Entidades.Cliente.ClienteVinculado.Vinculado Then
      '   ugDetalle.DisplayLayout.Bands(0).Columns("CodVin").Hidden = False
      '   ugDetalle.DisplayLayout.Bands(0).Columns("NombreVin").Hidden = False
      'Else
      '   ugDetalle.DisplayLayout.Bands(0).Columns("CodVin").Hidden = True
      '   ugDetalle.DisplayLayout.Bands(0).Columns("NombreVin").Hidden = True
      'End If
      Dim FechaCobro As DateTime = dtpFechaCobroCheques.Value

      Dim rCtaCteDet = New Reglas.CuentasCorrientesPagos()
      Dim dt As DataTable = New DataTable

      Dim pivotResult As Reglas.CuentasCorrientesPagos.GetInformeSituacionCrediticiaPivotInfo


      ugDetalle.ClearFilas()

      If chbAgregarClientesSinSaldo.Checked Then
         If chbAgruparSaldosCHFecha.Checked Then

            ColumnasMesesCheques()

            pivotResult = rCtaCteDet.GetInformeSituacionCrediticiaSinSaldosPIVOT(cmbSucursal.GetSucursales(), fechaHasta,
                                                          idVendedor, idCliente, excluirSaldosNegativos, idCategoria, cmbGrabanLibro.Text,
                                                          excluirAnticipos, excluirPreComprobantes,
                                                          origenCategoria, agregarSinSaldo,
                                                          origenVendedor, idCobrador, origenCobrador,
                                                          tipoCliente, cmbActivos.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                          FechaCobro, pivotcolName.ToString(), sumPivot.ToString(),
                                                          dtColumnas)

            ugDetalle.DataSource = pivotResult.dtResult

            For Each dr As UltraGridRow In ugDetalle.Rows
               dr.Cells("SitCrediticia").Value = Decimal.Parse(dr.Cells("Saldo").Value.ToString())
               For Each drColumna As DataRow In dtColumnas.Rows
                  Dim MES As Decimal = 0
                  If Not String.IsNullOrEmpty(dr.Cells(drColumna("Mes").ToString()).Value.ToString()) Then
                     MES = Decimal.Parse(dr.Cells(drColumna("Mes").ToString()).Value.ToString())
                  End If
                  dr.Cells("SitCrediticia").Value = Decimal.Parse(dr.Cells("SitCrediticia").Value.ToString()) + MES
               Next
            Next
            For Each drColumna As DataRow In dtColumnas.Rows
               ugDetalle.DisplayLayout.Bands(0).Columns(drColumna("Mes").ToString()).FormatearColumna(drColumna("Mes").ToString(), 150, 140, HAlign.Right,, "N2")
            Next



         Else
            PreferenciasLeer(ugDetalle, tsbPreferencias)

            dt = rCtaCteDet.GetInformeSituacionCrediticiaSinSaldos(cmbSucursal.GetSucursales(), fechaHasta,
                                        idVendedor, idCliente, excluirSaldosNegativos, idCategoria, cmbGrabanLibro.Text,
                                        excluirAnticipos, excluirPreComprobantes,
                                        origenCategoria, agregarSinSaldo, origenVendedor, idCobrador, origenCobrador,
                                        tipoCliente, cmbActivos.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos), FechaCobro)

            ugDetalle.DataSource = dt
            For Each dr As UltraGridRow In ugDetalle.Rows
               dr.Cells("SitCrediticia").Value = Decimal.Parse(dr.Cells("Saldo").Value.ToString())
               If Not String.IsNullOrEmpty(dr.Cells("Importe2").Value.ToString()) Then
                  dr.Cells("SitCrediticia").Value = Decimal.Parse(dr.Cells("SitCrediticia").Value.ToString()) + Decimal.Parse(dr.Cells("Importe2").Value.ToString())
               End If
            Next
            ugDetalle.DisplayLayout.Bands(0).Columns("Importe2").FormatearColumna("Cheques", 8, 110, HAlign.Right,, "N2")
         End If

      Else
         If chbAgruparSaldosCHFecha.Checked Then

            ColumnasMesesCheques()

            pivotResult = rCtaCteDet.GetInformeSituacionCrediticiaPIVOT(cmbSucursal.GetSucursales(), fechaHasta,
                                                        idVendedor, idCliente,
                                                        excluirSaldosNegativos, idCategoria, cmbGrabanLibro.Text,
                                                        excluirAnticipos, excluirPreComprobantes,
                                                        origenCategoria, origenVendedor, idCobrador, origenCobrador,
                                                        tipoCliente, cmbActivos.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                        FechaCobro, pivotcolName.ToString(), sumPivot.ToString(),
                                                         dtColumnas)

            ugDetalle.DataSource = pivotResult.dtResult

            For Each dr As UltraGridRow In ugDetalle.Rows
               dr.Cells("SitCrediticia").Value = Decimal.Parse(dr.Cells("Saldo").Value.ToString())
               For Each drColumna As DataRow In dtColumnas.Rows
                  Dim MES As Decimal = 0
                  If Not String.IsNullOrEmpty(dr.Cells(drColumna("Mes").ToString()).Value.ToString()) Then
                     MES = Decimal.Parse(dr.Cells(drColumna("Mes").ToString()).Value.ToString())
                  End If
                  dr.Cells("SitCrediticia").Value = Decimal.Parse(dr.Cells("SitCrediticia").Value.ToString()) + MES
               Next
            Next
            For Each drColumna As DataRow In dtColumnas.Rows
               ugDetalle.DisplayLayout.Bands(0).Columns(drColumna("Mes").ToString()).FormatearColumna(drColumna("Mes").ToString(), 150, 150, HAlign.Right,, "N2")
            Next

         Else
            dt = rCtaCteDet.GetInformeSituacionCrediticia(cmbSucursal.GetSucursales(), fechaHasta,
                                                 idVendedor, idCliente, excluirSaldosNegativos, idCategoria, cmbGrabanLibro.Text,
                                                 excluirAnticipos, excluirPreComprobantes,
                                                 origenCategoria, origenVendedor, idCobrador, origenCobrador,
                                                 tipoCliente, cmbActivos.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos), FechaCobro)

            ugDetalle.DataSource = dt
            For Each dr As UltraGridRow In ugDetalle.Rows
               dr.Cells("SitCrediticia").Value = Decimal.Parse(dr.Cells("Saldo").Value.ToString())
               If Not String.IsNullOrEmpty(dr.Cells("Importe2").Value.ToString()) Then
                  dr.Cells("SitCrediticia").Value = Decimal.Parse(dr.Cells("SitCrediticia").Value.ToString()) + Decimal.Parse(dr.Cells("Importe2").Value.ToString())
               End If
            Next
            ugDetalle.DisplayLayout.Bands(0).Columns("Importe2").FormatearColumna("Cheques", 8, 110, HAlign.Right,, "N2")
         End If


      End If


      Dim columna As UltraGridColumn = ugDetalle.DisplayLayout.Bands(0).Columns("SitCrediticia")
      columna.SortIndicator = SortIndicator.Descending
      ugDetalle.DisplayLayout.Bands(0).SortedColumns.Add(columna, True, False)


      ConfiguraTotalesGrilla(dtColumnas)

      With ugDetalle.DisplayLayout.Bands(0)
         If .Columns.Exists("IdEmpleado") Then
            .Columns("IdEmpleado").FormatearColumna("IdEmpleado", 100, 50, HAlign.Right, True)
         End If
         If .Columns.Exists("IdCobrador") Then
            .Columns("IdCobrador").FormatearColumna("IdCobrador", 100, 50, HAlign.Right, True)
         End If
         If .Columns.Exists("NombreDeFantasia") Then
            .Columns("NombreDeFantasia").FormatearColumna("Cliente (N. de Fantasía)", 4, 130, HAlign.Left, True)
         End If
      End With

      If chbIncluyeChTerceros.Checked Then
         For Each dr As UltraGridRow In ugDetalle.Rows
            If Not String.IsNullOrEmpty(dr.Cells("IMPORTE2").Value.ToString()) Then
               dr.Cells("Saldo").Value = Decimal.Parse(dr.Cells("Saldo").Value.ToString()) + Decimal.Parse(dr.Cells("IMPORTE2").Value.ToString())
            End If
         Next
      End If

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, False, True)
         If chbCliente.Checked Then
            .AppendFormat(" - {0}: {1} - {2} ({3})", lblCliente.Text, bscCodigoCliente.Text, bscCliente.Text, cmbTipoCliente.Text)
         End If
         If chbFecha.Checked Then
            .AppendFormat(" - {0}: {1}", chbFecha.Checked, dtpHasta.Text)
         End If
         If cmbActivos.ValorSeleccionado(Entidades.Publicos.SiNoTodos.TODOS) = Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat(" - {0}: {1}", lblActivos.Text, cmbActivos.Text)
         End If
         If chbVendedor.Checked Then
            .AppendFormat(" - {0}: {1}", chbVendedor.Text, cmbVendedor.Text)
         End If
         'If chbZonaGeografica.Checked Then
         '   .AppendFormat(" - {0}: {1}", chbZonaGeografica.Text, cmbZonaGeografica.Text)
         'End If
         'If chbProvincia.Checked Then
         '   .AppendFormat(" - {0}: {1}", chbProvincia.Text, cmbProvincia.Text)
         'End If
         If chbCategoria.Checked Then
            .AppendFormat(" - {0}: {1} {2}", chbCategoria.Text, cmbCategoria.Text, cmbOrigenCategoria.Text)
         End If
         'If chbGrupoCategoria.Checked Then
         '   .AppendFormat(" - {0}: {1}", chbGrupoCategoria.Text, cmbGrupoCategoria.Text)
         'End If
         'If chbEstadoCliente.Checked Then
         '   .AppendFormat(" - {0}: {1}", chbEstadoCliente.Text, cmbEstadosClientes.Text)
         'End If
         If chbCobrador.Checked Then
            .AppendFormat(" - {0}: {1} {2}", chbCobrador.Text, cmbCobrador.Text, cmbOrigenCobrador.Text)
         End If
         If cmbGrabanLibro.ValorSeleccionado(Entidades.Publicos.SiNoTodos.TODOS) = Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat(" - {0}: {1}", lblGrabanLibro.Text, cmbGrabanLibro.Text)
         End If
         'If chbGrupo.Checked Then
         '   .AppendFormat(" - {0}: {1}", chbGrupo.Text, cmbGrupos.Text)
         'End If
         'If chbFormaPago.Checked Then
         '   .AppendFormat(" - {0}: {1}", chbFormaPago.Text, cmbFormaPago.Text)
         'End If
         If chbAgregarClientesSinSaldo.Checked Then
            .AppendFormat(" - {0}", chbAgregarClientesSinSaldo.Text)
         End If
         'If chbAgruparIdClienteCtaCte.Checked Then
         '   .AppendFormat(" - {0}", chbAgruparIdClienteCtaCte.Text)
         'End If
         If chbIncluyeChTerceros.Checked Then
            .AppendFormat(" - {0}", chbIncluyeChTerceros.Text)
         End If
         If chbExcluirAnticipos.Checked Then
            .AppendFormat(" - {0}", chbExcluirAnticipos.Text)
         End If
         If chbExcluirSaldosNegativos.Checked Then
            .AppendFormat(" - {0}", chbExcluirSaldosNegativos.Text)
         End If
         If chbExcluirPreComprobantes.Checked Then
            .AppendFormat(" - {0}", chbExcluirPreComprobantes.Text)
         End If
      End With
      Return filtro.ToString()
   End Function
   Private Sub ConfiguraTotalesGrilla(dtColumas As DataTable)

      ugDetalle.AgregarFiltroEnLinea({"NombreVendedor", "NombreCliente", "CUIT", "Telefonos", "NombreDeFantasia"})
      ugDetalle.AgregarTotalesSuma({"SitCrediticia", "Saldo", "SaldoVencido", "IMPORTE2"})

      If dtColumas.Rows.Count <> 0 Then
         For Each drColumna As DataRow In dtColumas.Rows
            ugDetalle.AgregarTotalesSuma({drColumna("Mes").ToString()})
         Next
      End If

   End Sub

   Private Sub ColumnasMesesCheques()


      Dim fechaActual As DateTime = dtpFechaCobroCheques.Value
      Dim fechaFutura As DateTime = dtpFechaCobroCheques.Value.AddMonths(6)
      Dim tablaMeses As New DataTable()
      tablaMeses.Columns.Add("Mes", GetType(String))

      Dim fechaIterativa As DateTime = fechaActual

      While fechaIterativa.Date <= fechaFutura.Date

         Dim nombreMes As String = fechaIterativa.GetMonthEnEspanol
         Dim year As String = fechaIterativa.Year.ToString()
         Dim fila As DataRow = tablaMeses.NewRow()
         fila("Mes") = "CHQ__" & nombreMes & "_" & year
         tablaMeses.Rows.Add(fila)

         fechaIterativa = fechaIterativa.AddMonths(1)
      End While

      dtColumnas = New DataTable

      dtColumnas = tablaMeses

      Dim primero As Boolean = True
      pivotcolName = New StringBuilder()
      sumPivot = New StringBuilder()

      For Each drColumna As DataRow In dtColumnas.Rows
         If Not primero Then
            pivotcolName.Append(",")
            sumPivot.Append(",")
         End If
         pivotcolName.AppendFormat("[{0}]", drColumna("Mes"))
         sumPivot.AppendFormat("SUM([{0}]) as [{0}]", drColumna("Mes"))
         primero = False
      Next
   End Sub


#End Region

End Class