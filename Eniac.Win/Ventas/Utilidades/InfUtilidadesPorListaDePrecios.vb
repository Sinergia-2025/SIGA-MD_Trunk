Public Class InfUtilidadesPorListaDePrecios

#Region "Campos"

   Private _publicos As Publicos
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1
         _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
         _publicos.CargaComboListaDePrecios(cmbListaDePrecios)
         _publicos.CargaComboDesdeEnum(cmbProductoEsComercial, Entidades.Publicos.SiNoTodos.TODOS)

         _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

         ugUtilXListaDePrecios.AgregarTotalesSuma({"Costo", "Total", "Utilidad", "MargenGlobal", "CostoConImpuestos", "TotalConImpuestos", "UtilidadConImpuestos", "MargenGlobalConImpuestos"})
         ugUtilXListaDePrecios.AgregarTotalCustomColumna("Margen", New Ayudante.CustomSummaries.SummaryMargen("Utilidad", "Total", "Margen"))
         ugUtilXListaDePrecios.AgregarTotalCustomColumna("MargenConImpuestos", New Ayudante.CustomSummaries.SummaryMargen("UtilidadConImpuestos", "TotalConImpuestos", "MargenConImpuestos"))

         ugUtilXListaDePrecios.AgregarFiltroEnLinea({"NombreListaPrecios"})

         _tit = GetColumnasVisiblesGrilla(ugUtilXListaDePrecios)

         PreferenciasLeer(ugUtilXListaDePrecios, tsbPreferencias)

         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal
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
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugUtilXListaDePrecios.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugUtilXListaDePrecios.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugUtilXListaDePrecios.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugUtilXListaDePrecios, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos CheckBox Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub
   Private Sub chbListaDePrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaDePrecios.CheckedChanged
      TryCatched(Sub() chbListaDePrecios.FiltroCheckedChanged(cmbListaDePrecios))
   End Sub

#End Region

#Region "Eventos Busquedas Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
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
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Busquedas Localidades"
   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      TryCatched(Sub() chbLocalidad.FiltroCheckedChanged(usaPermitido:=True, bscCodigoLocalidad, bscNombreLocalidad))
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLocalidades(bscCodigoLocalidad)
         bscCodigoLocalidad.Datos = New Reglas.Localidades().GetPorCodigo(bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLocalidades(bscNombreLocalidad)
         bscNombreLocalidad.Datos = New Reglas.Localidades().GetPorNombre(bscNombreLocalidad.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion, bscNombreLocalidad.BuscadorSeleccion
      TryCatched(Sub() CargarLocalidad(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbListaDePrecios.Checked And cmbListaDePrecios.SelectedIndex < 0 Then
            ShowMessage("ATENCION: Debe seleccionar una LISTA DE PRECIOS.")
            cmbListaDePrecios.Focus()
            Exit Sub
         End If
         If chbCliente.Checked And Not (bscCodigoCliente.Selecciono Or bscCliente.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         If chbVendedor.Checked And cmbVendedor.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar un VENDEDOR.")
            cmbVendedor.Focus()
            Exit Sub
         End If
         If chbLocalidad.Checked And Not bscCodigoLocalidad.Selecciono And Not bscNombreLocalidad.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó una LOCALIDAD aunque activó ese Filtro.")
            bscCodigoLocalidad.Focus()
            Exit Sub
         End If
         If chbZonaGeografica.Checked And cmbZonaGeografica.SelectedIndex < 0 Then
            ShowMessage("ATENCION: Debe seleccionar una ZONA GEOGRÁFICA.")
            cmbZonaGeografica.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugUtilXListaDePrecios.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      TryCatched(
      Sub()
         With ugUtilXListaDePrecios.DisplayLayout.Bands(0)
            If .Columns.Exists("Costo") Then
               .Columns("Costo").Hidden = chbConIVA.Checked
               .Columns("Total").Hidden = chbConIVA.Checked
               .Columns("Utilidad").Hidden = chbConIVA.Checked
               .Columns("Margen").Hidden = chbConIVA.Checked
               .Columns("MargenGlobal").Hidden = chbConIVA.Checked

               .Columns("CostoConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("TotalConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("UtilidadConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("MargenConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("MargenGlobalConImpuestos").Hidden = Not chbConIVA.Checked
            End If
            AjustarOrdenamientoPorDefecto()
         End With
      End Sub)
   End Sub

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

   Private Sub CargarLocalidad(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
         bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
         bscCodigoLocalidad.Permitido = False
         bscNombreLocalidad.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()
      cmbSucursal.Refrescar()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today

      chbCliente.Checked = False
      chbVendedor.Checked = False

      chbZonaGeografica.Checked = False
      chbLocalidad.Checked = False
      chbListaDePrecios.Checked = False

      chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

      cmbProductoEsComercial.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      'Limpio la Grilla.
      ugUtilXListaDePrecios.ClearFilas()

      dtpDesde.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idZonaGeografica = cmbZonaGeografica.ValorSeleccionado(chbZonaGeografica, String.Empty)
      Dim idLocalidad = If(chbLocalidad.Checked, bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I), 0)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idListaDePrecios = cmbListaDePrecios.ValorSeleccionado(chbListaDePrecios, -1)

      Dim rVentas = New Reglas.Ventas()
      Dim dtDetalle = rVentas.GetUtilidadesPor(Entidades.Venta.TipoUtilidad.LISTAPRECIOS,
                                               cmbSucursal.GetSucursales(),
                                               dtpDesde.Value, dtpHasta.Value,
                                               idVendedor,
                                               agruparSucursales:=True,
                                               idCliente:=idCliente,
                                               idZonaGeografica:=idZonaGeografica,
                                               idLocalidad:=idLocalidad,
                                               idListaDePrecios:=idListaDePrecios,
                                               idRubro:=0, idSubrubro:=0, idProducto:=String.Empty, idMarca:=0, mostrarProveedorHabitual:=False,
                                               idProveedorHabitual:=0, esComercial:=cmbProductoEsComercial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                               listaComprobantes:=Nothing, grabaLibro:="TODOS", grupo:=Nothing)
      ugUtilXListaDePrecios.DataSource = dtDetalle
      AjustarOrdenamientoPorDefecto()
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)
         .AppendFormat(" - Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)
         If cmbListaDePrecios.SelectedIndex > -1 Then
            .AppendFormat(" - Lista de Precios: {0}", cmbListaDePrecios.Text)
         End If
         If chbCliente.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text.Trim(), bscCliente.Text.Trim())
         End If
         If chbVendedor.Checked Then
            Dim idVendedor = cmbVendedor.ValorSeleccionado(Of Integer)
            .AppendFormat(" - Vendedor: {0} - {1}", idVendedor, cmbVendedor.Text)
         End If
         If chbLocalidad.Checked Then
            .AppendFormat(" - Localidad: {0} - {1}", bscCodigoLocalidad.Text.Trim(), bscNombreLocalidad.Text.Trim())
         End If
         If cmbZonaGeografica.SelectedIndex >= 0 Then
            .AppendFormat(" - Zona Geográfica: {0}", cmbZonaGeografica.Text)
         End If
         .AppendFormat(" - Precios Con IVA: {0}", If(chbConIVA.Checked, "SI", "NO"))
      End With
      Return filtro.ToString()
   End Function

   Private Sub AjustarOrdenamientoPorDefecto()
      With ugUtilXListaDePrecios.DisplayLayout.Bands(0)
         If .SortedColumns.Count = 0 Or (.SortedColumns.Count = 1 And .SortedColumns(0).Key.Contains("MargenGlobal")) Then
            .SortedColumns.Clear()
            .SortedColumns.Add(If(chbConIVA.Checked, "MargenGlobalConImpuestos", "MargenGlobal"), True)
         End If
      End With
   End Sub

#End Region
End Class