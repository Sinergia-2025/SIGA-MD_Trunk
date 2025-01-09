Public Class InfUtilidadesPorCliente

#Region "Campos"
   Private _publicos As Publicos
   Private _cliente As Entidades.Cliente
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
         _publicos.CargaComboDesdeEnum(cmbProductoEsComercial, Entidades.Publicos.SiNoTodos.TODOS)

         _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

         ugUtilXCliente.AgregarTotalesSuma({"Costo", "Total", "Utilidad", "CostoConImpuestos", "TotalConImpuestos", "UtilidadConImpuestos"})
         ugUtilXCliente.AgregarTotalCustomColumna("Margen", New Ayudante.CustomSummaries.SummaryMargen("Utilidad", "Total", "Margen"))
         ugUtilXCliente.AgregarTotalCustomColumna("MargenConImpuestos", New Ayudante.CustomSummaries.SummaryMargen("UtilidadConImpuestos", "TotalConImpuestos", "MargenConImpuestos"))

         ugUtilXCliente.AgregarFiltroEnLinea({"NombreCliente"})

         _tit = GetColumnasVisiblesGrilla(ugUtilXCliente)

         PreferenciasLeer(ugUtilXCliente, tsbPreferencias)

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
      TryCatched(
      Sub()
         If ugUtilXCliente.Rows.Count = 0 Then Exit Sub

         Dim parm = New ReportParameterCollection(CargarFiltrosImpresion())

         Dim dt = ugUtilXCliente.DataSource(Of DataTable)()
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfUtilidadesPorCliente.rdlc", "SistemaDataSet_UtilidadesPorCliente", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()
      End Sub)
   End Sub
   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      TryCatched(Sub() ugUtilXCliente.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugUtilXCliente.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugUtilXCliente.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugUtilXCliente, tsbPreferencias))
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
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChanged(cmbVendedor))
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub
#End Region

#Region "Eventos Busqueda Cliente"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
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

#Region "Eventos Busqueda Localidad"
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
         If chbVendedor.Checked And cmbVendedor.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar un VENDEDOR.")
            cmbVendedor.Focus()
            Exit Sub
         End If
         If chbCliente.Checked And Not (bscCodigoCliente.Selecciono Or bscCliente.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         If chbLocalidad.Checked And Not bscCodigoLocalidad.Selecciono And Not bscNombreLocalidad.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó una LOCALIDAD aunque activó ese Filtro.")
            bscCodigoLocalidad.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugUtilXCliente.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs)
      TryCatched(
      Sub()
         With ugUtilXCliente.DisplayLayout.Bands(0)
            If .Columns.Exists("Costo") Then
               .Columns("Costo").Hidden = chbConIVA.Checked
               .Columns("Total").Hidden = chbConIVA.Checked
               .Columns("Utilidad").Hidden = chbConIVA.Checked

               .Columns("Margen").Hidden = chbConIVA.Checked

               .Columns("CostoConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("TotalConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("UtilidadConImpuestos").Hidden = Not chbConIVA.Checked

               .Columns("MargenConImpuestos").Hidden = Not chbConIVA.Checked
            End If
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
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today

      chbCliente.Checked = False
      chbVendedor.Checked = False

      chbZonaGeografica.Checked = False
      chbLocalidad.Checked = False

      chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

      'Limpio la Grilla.
      ugUtilXCliente.ClearFilas()

      dtpDesde.Focus()

      cmbSucursal.Refrescar()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idZonaGeografica = cmbZonaGeografica.ValorSeleccionado(chbZonaGeografica, String.Empty)
      Dim idLocalidad = If(chbLocalidad.Checked, bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I), 0I)

      Dim rVentas = New Reglas.Ventas()
      Dim dtDetalle = rVentas.GetUtilidadesPorCliente(cmbSucursal.GetSucursales(),
                                                      dtpDesde.Value, dtpHasta.Value,
                                                      idCliente, idVendedor,
                                                      idZonaGeografica, idLocalidad,
                                                      cmbProductoEsComercial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos))
      Dim dt = CrearDT()

      Dim decTotalMargen As Decimal
      For Each dr As DataRow In dtDetalle.Rows
         Dim drCl = dt.NewRow()

         drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
         drCl("NombreCliente") = dr("NombreCliente").ToString()

         drCl("Total") = Decimal.Parse(dr("Total").ToString())
         drCl("Costo") = dr("Costo")
         drCl("Utilidad") = Decimal.Parse(dr("Utilidad").ToString())
         If Decimal.Parse(drCl("Utilidad").ToString()) > 0 Then
            Dim total As Decimal = Decimal.Parse(drCl("Total").ToString())
            decTotalMargen = Decimal.Round(Decimal.Parse(drCl("Utilidad").ToString()) / If(total = 0, 1, total) * 100, 2)
         Else
            decTotalMargen = 0
         End If
         drCl("Margen") = decTotalMargen

         drCl("TotalConImpuestos") = dr("TotalConImpuestos")
         drCl("CostoConImpuestos") = dr("CostoConImpuestos")
         drCl("UtilidadConImpuestos") = dr("UtilidadConImpuestos")
         If Decimal.Parse(drCl("TotalConImpuestos").ToString()) > 0 Then
            Dim total As Decimal = Decimal.Parse(drCl("TotalConImpuestos").ToString())
            decTotalMargen = Decimal.Round(Decimal.Parse(drCl("UtilidadConImpuestos").ToString()) / If(total = 0, 1, total) * 100, 2)
         Else
            decTotalMargen = 0
         End If
         drCl("MargenConImpuestos") = decTotalMargen

         dt.Rows.Add(drCl)
      Next

      ugUtilXCliente.DataSource = dt
      ugUtilXCliente.DataSource = dt
   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))

         .Columns.Add("Costo", GetType(Decimal))
         .Columns.Add("Total", GetType(Decimal))
         .Columns.Add("Utilidad", GetType(Decimal))
         .Columns.Add("Margen", GetType(Decimal))

         .Columns.Add("CostoConImpuestos", GetType(Decimal))
         .Columns.Add("TotalConImpuestos", GetType(Decimal))
         .Columns.Add("UtilidadConImpuestos", GetType(Decimal))
         .Columns.Add("MargenConImpuestos", GetType(Decimal))
      End With
      Return dtTemp
   End Function

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)
         .AppendFormat(" - Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)
         If chbCliente.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text.Trim(), bscCliente.Text.Trim())
         End If
         If chbVendedor.Checked Then
            Dim idVendedor = cmbVendedor.ValorSeleccionado(0I)
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

   Private Sub chbConIVA_CheckedChanged_1(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      Try
         With ugUtilXCliente.DisplayLayout.Bands(0)
            If .Columns.Exists("Costo") Then

               .Columns("Costo").Hidden = chbConIVA.Checked
               .Columns("Total").Hidden = chbConIVA.Checked
               .Columns("Utilidad").Hidden = chbConIVA.Checked
               .Columns("Margen").Hidden = chbConIVA.Checked

               .Columns("CostoConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("TotalConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("UtilidadConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("MargenConImpuestos").Hidden = Not chbConIVA.Checked
            End If
         End With
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

End Class