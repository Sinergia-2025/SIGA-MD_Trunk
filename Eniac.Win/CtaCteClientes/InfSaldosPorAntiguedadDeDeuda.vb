Public Class InfSaldosPorAntiguedadDeDeuda

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
            If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
               IdUsuario = ""
            End If

            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
            If IdUsuario = "" Then
               cmbVendedor.SelectedIndex = -1
            Else
               chbVendedor.Checked = True
               chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
            End If

            _publicos.CargaComboDesdeEnum(cmbFechasCalculo, GetType(Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme))
            cmbFechasCalculo.SelectedValue = Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme.Fecha

            _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
            cmbZonaGeografica.SelectedIndex = -1

            _publicos.CargaComboAntiguedadSaldoConfigCliente(cmbRangoDias)
            _publicos.CargaComboCategorias(cmbCategoria)

            _publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))
            cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
            _publicos.CargaComboProvincias(cmbProvincia)

            _publicos.CargaComboGrupos(cmbGrupos)
            cmbGrupos.SelectedIndex = -1

            _publicos.CargaComboGrupoCategoria(cmbGrupoCategoria)

            _publicos.CargaComboEstadosClientes(cmbEstadosClientes)
            cmbEstadosClientes.SelectedIndex = -1

            _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)

            _publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
            _publicos.CargaComboDesdeEnum(cmbOrigenCobrador, GetType(Entidades.OrigenFK))
            cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual
            cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Actual

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            RefrescarDatos()
            CargaGrillaDetalle(sinRegistros:=True)

            'Me._estaCargando = False
            PreferenciasLeer(ugDetalle, tsbPreferencias)

            ugDetalle.AgregarFiltroEnLinea({"NombreVendedor", "NombreCliente"})

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

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCliente.Checked And bscCodigoCliente.Text.Length = 0 Then
               ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
               bscCodigoCliente.Focus()
               Exit Sub
            End If
            If chbCobrador.Checked And cmbCobrador.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó un Cobrador aunque activó ese Filtro.")
               cmbCobrador.Focus()
               Exit Sub
            End If
            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            CargaGrillaDetalle(sinRegistros:=False)

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   'Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click

   '   Try

   '      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

   '      Dim Filtros As String = Me.CargarFiltrosImpresion()

   '      Dim dt As DataTable

   '      Me.Cursor = Cursors.WaitCursor

   '      dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

   '      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

   '      Dim frmImprime As VisorReportes

   '      If Me.cmbVendedor.SelectedIndex >= 0 Then
   '         frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientes.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True, 1) '# 1 = Cantidad Copias
   '      Else
   '         frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientesPorVendedor.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True, 1) '# 1 = Cantidad Copias
   '      End If

   '      frmImprime.Text = Me.Text
   '      frmImprime.WindowState = FormWindowState.Maximized
   '      frmImprime.Show()

   '      Me.Cursor = Cursors.Default

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

   '   End Try

   'End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
#Region "Eventos Buscador Clientes"
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
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() If e.FilaDevuelta IsNot Nothing Then CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      TryCatched(Sub() chbGrupo.FiltroCheckedChanged(cmbGrupos))
   End Sub
   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged
      TryCatched(
         Sub()
            chbCobrador.FiltroCheckedChanged(cmbCobrador)
            cmbOrigenCobrador.Enabled = cmbCobrador.Enabled
         End Sub)
   End Sub
   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged
      TryCatched(Sub() chbProvincia.FiltroCheckedChanged(cmbProvincia))
   End Sub
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(
         Sub()
            chbCategoria.FiltroCheckedChanged(cmbCategoria)
            cmbOrigenCategoria.Enabled = cmbCategoria.Enabled
         End Sub)
   End Sub
   Private Sub chbGrupoCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupoCategoria.CheckedChanged
      TryCatched(Sub() chbGrupoCategoria.FiltroCheckedChanged(cmbGrupoCategoria))
   End Sub
   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoCliente.CheckedChanged
      TryCatched(Sub() chbEstadoCliente.FiltroCheckedChanged(cmbEstadosClientes))
   End Sub
#End Region

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatos()

      cmbSucursal.Refrescar()
      chbCliente.Checked = False
      cmbFechasCalculo.SelectedValue = Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme.Fecha
      cmbRangoDias.SelectedItem = cmbRangoDias.Items.OfType(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig).FirstOrDefault(Function(c) c.PorDefecto)
      If String.IsNullOrWhiteSpace(IdUsuario) Then chbVendedor.Checked = False
      cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      chbGrupo.Checked = False
      chbCobrador.Checked = False
      cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Actual
      chbProvincia.Checked = False
      chbZonaGeografica.Checked = False
      chbCategoria.Checked = False
      cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual
      chbGrupoCategoria.Checked = False
      chbEstadoCliente.Checked = False

      chbAgruparIdClienteCtaCte.Checked = False
      chbExcluirPreComprobantes.Checked = False
      chbExcluirSaldosNegativos.Checked = False
      chbExcluirAnticipos.Checked = False

      ugDetalle.ClearFilas()

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      btnConsultar.Focus()
   End Sub

   Private Sub CargaGrillaDetalle(sinRegistros As Boolean)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), 0L)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoria, 0I)
      Dim origenCategoria = cmbOrigenCategoria.ValorSeleccionado(Of Entidades.OrigenFK)
      Dim grupoCategoria = cmbGrupoCategoria.ValorSeleccionado(chbGrupoCategoria, String.Empty)
      Dim idCobrador = cmbCobrador.ValorSeleccionado(chbCobrador, 0I)
      Dim origenCobrador = cmbOrigenCobrador.ValorSeleccionado(Of Entidades.OrigenFK)
      Dim idZonaGeografica = cmbZonaGeografica.ValorSeleccionado(chbZonaGeografica, String.Empty)
      Dim grupo = cmbGrupos.ValorSeleccionado(chbGrupo, String.Empty)
      Dim idProvincia = cmbProvincia.ValorSeleccionado(chbProvincia, String.Empty)
      Dim idEstadoCliente = cmbEstadosClientes.ValorSeleccionado(chbEstadoCliente, 0I)
      Dim excluirAnticipos = If(chbExcluirSaldosNegativos.Checked, Entidades.Publicos.SiNo.SI, Entidades.Publicos.SiNo.NO)
      Dim excluirPreComprobantes = If(chbExcluirPreComprobantes.Checked, Entidades.Publicos.SiNo.SI, Entidades.Publicos.SiNo.NO)
      Dim excluirSaldosNegativos = If(chbExcluirSaldosNegativos.Checked, Entidades.Publicos.SiNo.SI, Entidades.Publicos.SiNo.NO)
      Dim rangosDias = cmbRangoDias.ItemSeleccionado(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig)

      Dim oCtaCteDet = New Reglas.CuentasCorrientesPagos()
      Me.ugDetalle.DataSource = oCtaCteDet.GetSaldosPorVencimientos(cmbSucursal.GetSucursales(), cmbFechasCalculo.ValorSeleccionado(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme)(),
                                                                    idCliente, chbAgruparIdClienteCtaCte.Checked, idVendedor,
                                                                    idCategoria, origenCategoria, grupoCategoria,
                                                                    idCobrador, origenCobrador,
                                                                    idZonaGeografica, cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos), grupo,
                                                                    idProvincia, idEstadoCliente, rangosDias, sinRegistros,
                                                                    excluirAnticipos, excluirPreComprobantes, excluirSaldosNegativos)

      ugDetalle.AgregarTotalesSuma({"Total", "Saldo"})


      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("NombreVendedor").Hidden = (cmbVendedor.Items.Count = 1)
         .Columns("IdSucursal").Hidden = Not cmbSucursal.GetSucursales().Count > 1

         Dim grpVencido = .Groups.Item("Vencido")
         Dim grpPorVencer = .Groups.Item("PorVencer")
         Dim grpCero = .Groups.Item("Cero")

         Dim pos = .Columns("Saldo").Header.VisiblePosition + 1
         For Each r In rangosDias.Rangos.OrderBy(Function(o) o.Orden)
            Dim col = .Columns(r.EtiquetaColumna).FormatearColumna(String.Format("{1}", Environment.NewLine, r.EtiquetaColumna, r.DiasDesde, r.DiasHasta), pos, .Columns("Saldo").Width, HAlign.Right, , "N2")
            col.Header.Appearance.TextHAlign = HAlign.Center
            If r.DiasDesde > 0 Then
               col.Group = grpVencido
            ElseIf r.DiasDesde < 0 Then
               col.Group = grpPorVencer
            Else
               col.Group = grpCero
            End If
            ugDetalle.AgregarTotalSumaColumna(col)
         Next

         grpPorVencer.Hidden = cmbFechasCalculo.ValorSeleccionado(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme)() = Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme.Fecha

      End With

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, False, True)

         If chbCliente.Checked Then .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)

         .AppendFormat(" - Por: {0} - Rangos: {1}", cmbFechasCalculo.Text, cmbRangoDias.Text)

         If chbVendedor.Checked Then .AppendFormat(" - Vendedor: {0}", cmbVendedor.Text)
         If cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos) <> Entidades.Publicos.SiNoTodos.TODOS Then .AppendFormat(" - Graban Libro {0}", cmbGrabanLibro.Text)
         If chbGrupo.Checked Then .AppendFormat(" - Grupo: {0}", cmbGrupos.Text)
         If chbCobrador.Checked Then .AppendFormat(" - Cobrador: {0} ({1})", cmbCobrador.Text, cmbOrigenCobrador.Text)
         If chbProvincia.Checked Then .AppendFormat(" - Provincia {0}", cmbProvincia.Text)
         If chbZonaGeografica.Checked Then .AppendFormat(" - Zona G.: {0}", cmbZonaGeografica.Text)
         If chbCategoria.Checked Then .AppendFormat(" - Categoría {0} ({1})", cmbCategoria.Text, cmbOrigenCobrador.Text)
         If chbGrupoCategoria.Checked Then .AppendFormat(" - Grupo Categoría {0}", cmbGrupoCategoria.Text)
         If chbEstadoCliente.Checked Then .AppendFormat(" - Estado Cliente: {0}", cmbEstadosClientes.Text)

         If chbAgruparIdClienteCtaCte.Checked Then .AppendFormat(" - {0}", chbAgruparIdClienteCtaCte.Text)
         If chbExcluirPreComprobantes.Checked Then .AppendFormat(" - {0}", chbExcluirPreComprobantes.Text)
         If chbExcluirSaldosNegativos.Checked Then .AppendFormat(" - {0}", chbExcluirSaldosNegativos.Text)
         If chbExcluirAnticipos.Checked Then .AppendFormat(" - {0}", chbExcluirAnticipos.Text)

      End With
      Return filtro.ToString()
   End Function

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      bscCliente.Permitido = False
      bscCodigoCliente.Permitido = False

      btnConsultar.Focus()
   End Sub

#End Region

End Class