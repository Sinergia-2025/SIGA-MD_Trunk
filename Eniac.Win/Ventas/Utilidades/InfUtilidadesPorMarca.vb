Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Public Class InfUtilidadesPorMarca

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1

         Dim oRubro = New Reglas.Rubros()
         cmbRubro.ValueMember = "IdRubro"
         cmbRubro.DisplayMember = "NombreRubro"

         cmbRubro.DataSource = oRubro.GetAll()
         cmbRubro.SelectedIndex = -1

         _publicos.CargaComboSubRubros(cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            chbSubRubro.Visible = False
            cmbSubRubro.Visible = False
         End If

         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         chbUnificar.Enabled = cmbSucursal.Enabled

         chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

         cmbGrupos.Inicializar()
         cmbGrupos.SelectedValue = Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()

         _publicos.CargaComboDesdeEnum(cmbGrabanLibro, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbProductoEsComercial, Entidades.Publicos.SiNoTodos.TODOS)

         cmbTiposComprobantes.Initializar(False, "VENTAS")
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         LeerPreferencias()
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
         If ugvUtilXMarca.Rows.Count = 0 Then Exit Sub

         Dim filtros = CargarFiltrosImpresion()

         Dim dt = ugvUtilXMarca.DataSource(Of DataTable)

         Dim parm = New ReportParameterCollection()

         parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion)
         parm.Add("NombreSucursal", actual.Sucursal.Nombre)
         parm.Add("Filtros", filtros)

         Dim frmImprime = New VisorReportes("Eniac.Win.InfUtilidadesPorMarca.rdlc", "SistemaDataSet_UtilidadesPorMarca", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()
      End Sub)
   End Sub
   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      TryCatched(
      Sub()
         If tbcXTipo.SelectedTab Is tbpUtilXMarca Then
            ugvUtilXMarca.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1})
         Else
            ugvUtilXRubro.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1})
         End If
      End Sub)
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(
      Sub()
         Dim grilla As UltraGrid
         Dim sufijo As String
         If tbcXTipo.SelectedTab.Equals(tbpUtilXMarca) Then
            grilla = ugvUtilXMarca
            sufijo = "Marca"
         Else
            grilla = ugvUtilXRubro
            sufijo = "Rubro"
         End If

         If grilla.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook = New Workbook()
         Dim myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Reglas.Publicos.NombreEmpresaImpresion
         myWorksheet.Rows(1).Cells(0).Value = Text
         myWorksheet.Rows(2).Cells(0).Value = CargarFiltrosImpresion()

         sfdExportar.FileName = String.Format("{0}_{1}.xls", Name, sufijo)
         sfdExportar.Filter = "Archivos excel|*.xls"
         If sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(sfdExportar.FileName.Trim()) Then
               UltraGridExcelExporter1.Export(grilla, myWorksheet, 4, 0)
               myWorkbook.Save(sfdExportar.FileName)
            End If
         End If
      End Sub)
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(
      Sub()
         Dim grilla As UltraGrid
         Dim sufijo As String
         If tbcXTipo.SelectedTab.Equals(tbpUtilXMarca) Then
            grilla = ugvUtilXMarca
            sufijo = "Marca"
         Else
            grilla = ugvUtilXRubro
            sufijo = "Rubro"
         End If

         If grilla.Rows.Count = 0 Then Exit Sub

         Me.sfdExportar.FileName = String.Format("{0}_{1}.pdf", Name, sufijo)
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(sfdExportar.FileName.Trim()) Then
               Dim r = New Report()
               Dim sec = r.AddSection()
               sec.AddText.AddContent(Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine)
               sec.AddText.AddContent(Text + Environment.NewLine)
               sec.AddText.AddContent(CargarFiltrosImpresion() + Environment.NewLine + Environment.NewLine)
               UltraGridDocumentExporter1.Export(grilla, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If
      End Sub)
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(
      Sub()
         If tbcXTipo.SelectedTab.Equals(tbpUtilXMarca) Then
            Dim pre As Preferencias = New Preferencias(Me.ugvUtilXMarca, True)
            pre.SufijoXML = "Marca"
            pre.ShowDialog()
         Else
            Dim pre As Preferencias = New Preferencias(Me.ugvUtilXRubro, True)
            pre.SufijoXML = "Rubro"
            pre.ShowDialog()
         End If
      End Sub)
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
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(cmbRubro))
   End Sub
   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      TryCatched(Sub() chbSubRubro.FiltroCheckedChanged(cmbSubRubro))
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub
#End Region

#Region "Eventos Busqueda Cliente"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         Dim codigoCliente = If(chbCliente.Checked, bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L), -1L)
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

#Region "Eventos Busqueda Cliente"
   Private Sub chbProveedorHabitual_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedorHabitual.CheckedChanged
      TryCatched(Sub() chbProveedorHabitual.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedorHabitual, bscNombreProveedorHabitual))
   End Sub
   Private Sub bscCodigoProveedorHabitual_BuscadorClick() Handles bscCodigoProveedorHabitual.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedorHabitual)
         Dim codigoProveedor = bscCodigoProveedorHabitual.Text.ValorNumericoPorDefecto(-1)
         bscCodigoProveedorHabitual.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedorProv_BuscadorClick() Handles bscNombreProveedorHabitual.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscNombreProveedorHabitual)
         bscNombreProveedorHabitual.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscNombreProveedorHabitual.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedorHabitual.BuscadorSeleccion, bscNombreProveedorHabitual.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbCliente.Checked And Not (bscCodigoCliente.Selecciono Or bscCliente.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         If chbProveedorHabitual.Checked And Not (bscCodigoProveedorHabitual.Selecciono Or bscNombreProveedorHabitual.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
            bscCodigoProveedorHabitual.Focus()
            Exit Sub
         End If
         If chbRubro.Checked And cmbRubro.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro")
            cmbRubro.Focus()
            Exit Sub
         End If
         If chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO Informó un tipo de comprobante aunque activó ese Filtro.")
            cmbTiposComprobantes.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugvUtilXMarca.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs)
      TryCatched(
      Sub()
         MuestraColumnasGrilla(ugvUtilXRubro)
         MuestraColumnasGrilla(ugvUtilXMarca)
      End Sub)
   End Sub

   'Private Sub tbcXTipo_TabIndexChanged(sender As Object, e As EventArgs) Handles tbcXTipo.TabIndexChanged
   '   TryCatched(
   '   Sub()
   '      If tbcXTipo.SelectedTab Is tbpUtilXMarca Then
   '         ugvUtilXRubro.ToolStripLabelRegistros = Nothing
   '         ugvUtilXMarca.ToolStripLabelRegistros = tssRegistrosRubro
   '      Else
   '         ugvUtilXMarca.ToolStripLabelRegistros = Nothing
   '         ugvUtilXRubro.ToolStripLabelRegistros = tssRegistrosRubro
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

   Private Sub RefrescarDatosGrilla()

      chbMostrarProveedorHabitual.Checked = False
      chbProveedorHabitual.Checked = False
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now
      chbVendedor.Checked = False

      cmbGrupos.Refrescar()
      chbCliente.Checked = False

      cmbProductoEsComercial.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      ugvUtilXMarca.ClearFilas()
      ugvUtilXRubro.ClearFilas()

      chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

      cmbSucursal.Refrescar()
      chbUnificar.Checked = True

      chbTipoComprobante.Checked = False

      cmbGrabanLibro.SelectedIndex = 0

      dtpDesde.Focus()

      If Not chbMostrarProveedorHabitual.Checked Then
         If ugvUtilXMarca.DisplayLayout.Bands(0).Columns.Contains("NombreProveedorHabitual") Then
            With ugvUtilXMarca.DisplayLayout.Bands(0)
               .Columns("NombreProveedorHabitual").Hidden = True
            End With
            With ugvUtilXRubro.DisplayLayout.Bands(0)
               .Columns("NombreProveedorHabitual").Hidden = True
            End With
         End If

      End If
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), 0L)
      Dim idProveedorHabitual = If(chbProveedorHabitual.Checked, Long.Parse(bscCodigoProveedorHabitual.Tag.ToString()), 0L)

      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim idSubRubro = cmbSubRubro.ValorSeleccionado(chbRubro, 0I)

      Dim tiposComprobantes = cmbTiposComprobantes.GetTiposComprobantes().ToList()

      Dim rVentas = New Reglas.Ventas()
      Dim dtDetalleMarca = rVentas.GetUtilidadesPor(Entidades.Venta.TipoUtilidad.MARCA,
                                       cmbSucursal.GetSucursales(),
                                       dtpDesde.Value, dtpHasta.Value,
                                       idVendedor,
                                       chbUnificar.Checked, idRubro,
                                       idSubRubro,
                                       idCliente,
                                       idProducto:=String.Empty,
                                       idZonaGeografica:=String.Empty,
                                       idLocalidad:=0,
                                       idListaDePrecios:=-1,
                                       idMarca:=0,
                                       mostrarProveedorHabitual:=chbMostrarProveedorHabitual.Checked,
                                       idProveedorHabitual:=idProveedorHabitual,
                                       listaComprobantes:=tiposComprobantes,
                                       grabaLibro:=cmbGrabanLibro.Text,
                                       grupo:=cmbGrupos.GetGruposTiposComprobantes(),
                                       esComercial:=cmbProductoEsComercial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos))

      Dim dtDetalleRubro = rVentas.GetUtilidadesPor(Entidades.Venta.TipoUtilidad.RUBRO,
                                       cmbSucursal.GetSucursales(),
                                       dtpDesde.Value, dtpHasta.Value,
                                       idVendedor,
                                       chbUnificar.Checked, idRubro,
                                       idSubRubro,
                                       idCliente,
                                       idProducto:=String.Empty,
                                       idZonaGeografica:=String.Empty,
                                       idLocalidad:=0,
                                       idListaDePrecios:=-1,
                                       idMarca:=0,
                                       mostrarProveedorHabitual:=chbMostrarProveedorHabitual.Checked,
                                       idProveedorHabitual:=idProveedorHabitual,
                                       listaComprobantes:=tiposComprobantes,
                                       grabaLibro:=cmbGrabanLibro.Text,
                                       grupo:=cmbGrupos.GetGruposTiposComprobantes(),
                                       esComercial:=cmbProductoEsComercial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos))
      Dim dtMarca = CrearDTMarcaRubro()
      Dim dtRubro = CrearDTMarcaRubro()

      CopiaDTMarcaRubro(dtDetalleMarca, dtMarca)
      CopiaDTMarcaRubro(dtDetalleRubro, dtRubro)


      ugvUtilXMarca.DataSource = dtMarca
      SeteaGrillaMarca()

      ugvUtilXRubro.DataSource = dtRubro
      SeteaGrillaRubro()

      LeerPreferencias()
   End Sub

   Private Sub FormateaGrilla(grilla As UltraGrid, tipoVisible As String, tipoInvisible As String)
      grilla.AgregarTotalesSuma({"Costo", "Total", "Utilidad", "CostoConImpuestos", "TotalConImpuestos", "UtilidadConImpuestos"})
      grilla.AgregarTotalCustomColumna("Margen", New Ayudante.CustomSummaries.SummaryMargen("Utilidad", "Total", "Margen"))
      grilla.AgregarTotalCustomColumna("MargenConImpuestos", New CustomSummaries.SummaryMargen("UtilidadConImpuestos", "TotalConImpuestos", "MargenConImpuestos"))

      Dim col As Integer = 0
      With grilla.DisplayLayout.Bands(0)

         .Columns("IdSucursal").FormatearColumna("S.", col, 40, HAlign.Right, Me.chbUnificar.Checked)
         .Columns("Id" + tipoVisible).FormatearColumna("Id " + tipoVisible, col, 80, HAlign.Right, False)
         .Columns("Nombre" + tipoVisible).FormatearColumna("Nombre " + tipoVisible, col, 200, HAlign.Left, False)

         .Columns("Costo").FormatearColumna("Costo", col, 100, HAlign.Right, chbConIVA.Checked, "N2")
         .Columns("Total").FormatearColumna("Total", col, 100, HAlign.Right, chbConIVA.Checked, "N2")
         .Columns("Utilidad").FormatearColumna("Utilidad", col, 100, HAlign.Right, chbConIVA.Checked, "N2")

         .Columns("Margen").FormatearColumna("Margen", col, 100, HAlign.Right, chbConIVA.Checked, "N2")

         .Columns("CostoConImpuestos").FormatearColumna("Costo", col, 100, HAlign.Right, Not chbConIVA.Checked, "N2")
         .Columns("TotalConImpuestos").FormatearColumna("Total", col, 100, HAlign.Right, Not chbConIVA.Checked, "N2")
         .Columns("UtilidadConImpuestos").FormatearColumna("Utilidad", col, 100, HAlign.Right, Not chbConIVA.Checked, "N2")

         .Columns("MargenConImpuestos").FormatearColumna("Margen", col, 100, HAlign.Right, Not chbConIVA.Checked, "N2")

         .Columns("Id" + tipoInvisible).FormatearColumna("Id " + tipoInvisible, col, 80, HAlign.Right, True)
         .Columns("Nombre" + tipoInvisible).FormatearColumna("Nombre " + tipoInvisible, col, 150, HAlign.Left, True)

         If chbMostrarProveedorHabitual.Checked Then
            .Columns("NombreProveedorHabitual").FormatearColumna("Proveedor Habitual", col, 150, HAlign.Left, False)
         End If

      End With

      grilla.AgregarFiltroEnLinea({"Nombre" + tipoVisible})
   End Sub

   Private Sub MuestraColumnasGrilla(grilla As UltraGrid)
      With grilla.DisplayLayout.Bands(0)
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
   End Sub

   Private Sub SeteaGrillaMarca()
      FormateaGrilla(ugvUtilXMarca, "Marca", "Rubro")
   End Sub

   Private Sub SeteaGrillaRubro()
      FormateaGrilla(ugvUtilXRubro, "Rubro", "Marca")
   End Sub

   Private Function CrearDTMarcaRubro() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("IdMarca", GetType(String))
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("IdRubro", GetType(String))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("Costo", GetType(Decimal))
         .Columns.Add("Total", GetType(Decimal))
         .Columns.Add("Utilidad", GetType(Decimal))
         .Columns.Add("Margen", GetType(Decimal))

         .Columns.Add("CostoConImpuestos", GetType(Decimal))
         .Columns.Add("TotalConImpuestos", GetType(Decimal))
         .Columns.Add("UtilidadConImpuestos", GetType(Decimal))
         .Columns.Add("MargenConImpuestos", GetType(Decimal))

         If chbMostrarProveedorHabitual.Checked Then
            .Columns.Add("NombreProveedorHabitual", GetType(String))
         End If

         .Columns.Add("IdSucursal", GetType(Integer))

      End With

      Return dtTemp

   End Function

   Private Sub CopiaDTMarcaRubro(dtOrigen As DataTable, dtDestino As DataTable)
      Dim drCl As DataRow
      Dim decTotalMargen As Decimal
      For Each dr As DataRow In dtOrigen.Rows

         drCl = dtDestino.NewRow()

         If dtOrigen.Columns.Contains("IdMarca") Then
            drCl("IdMarca") = dr("IdMarca").ToString()
            drCl("NombreMarca") = dr("NombreMarca").ToString()
         ElseIf dtOrigen.Columns.Contains("IdRubro") Then
            drCl("IdRubro") = dr("IdRubro").ToString()
            drCl("NombreRubro") = dr("NombreRubro").ToString()
         End If

         drCl("Total") = Decimal.Round(Decimal.Parse(dr("Total").ToString()), 2)
         drCl("Costo") = Decimal.Round(Decimal.Parse(dr("Costo").ToString()), 2)
         drCl("Utilidad") = Decimal.Round(Decimal.Parse(dr("Utilidad").ToString()), 2)
         If Decimal.Parse(drCl("Total").ToString()) > 0 Then
            decTotalMargen = Decimal.Round(Decimal.Parse(drCl("Utilidad").ToString()) / Decimal.Parse(drCl("Total").ToString()) * 100, 2)
         Else
            decTotalMargen = 0
         End If
         drCl("Margen") = Decimal.Round(decTotalMargen, 2)

         drCl("TotalConImpuestos") = Decimal.Round(Decimal.Parse(dr("TotalConImpuestos").ToString()), 2)
         drCl("CostoConImpuestos") = Decimal.Round(Decimal.Parse(dr("CostoConImpuestos").ToString()), 2)
         drCl("UtilidadConImpuestos") = Decimal.Round(Decimal.Parse(dr("UtilidadConImpuestos").ToString()), 2)
         If Decimal.Parse(drCl("TotalConImpuestos").ToString()) > 0 Then
            decTotalMargen = Decimal.Round(Decimal.Parse(drCl("UtilidadConImpuestos").ToString()) / Decimal.Parse(drCl("TotalConImpuestos").ToString()) * 100, 2)
         Else
            decTotalMargen = 0
         End If
         drCl("MargenConImpuestos") = Decimal.Round(decTotalMargen, 2)

         If Me.chbMostrarProveedorHabitual.Checked Then
            'drCl("CodigoProveedorHabitual") = dr("CodigoProveedorHabitual").ToString()
            drCl("NombreProveedorHabitual") = dr("NombreProveedorHabitual").ToString()
         End If


         drCl("IdSucursal") = dr("IdSucursal")

         dtDestino.Rows.Add(drCl)

      Next

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro

         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         If Me.chbVendedor.Checked Then
            Dim idVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
            .AppendFormat("Vendedor: {0} - {1} - ", idVendedor, Me.cmbVendedor.Text)
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            .AppendFormat("Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text.Trim(), Me.bscCliente.Text.Trim())
         End If

         If Me.chbRubro.Checked Then
            .AppendFormat("Rubro: {0}", cmbRubro.Text)
         End If

         If Me.chbSubRubro.Checked Then
            .AppendFormat("SubRubro: {0}", cmbSubRubro.Text)
         End If

         .AppendFormat("Precios Con IVA: {0}", IIf(Me.chbConIVA.Checked, "SI", "NO"))

         If Me.cmbGrabanLibro.SelectedIndex >= 0 Then
            .AppendFormat("  Graban Libro: {0} - ", Me.cmbGrabanLibro.Text)
         End If

         Me.cmbGrupos.CargarFiltrosImpresionTiposComprobantes(filtro, False, True)
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Protected Overridable Sub LeerPreferencias()
      Try

         Dim nameMarca As String = Me.ugvUtilXMarca.FindForm().Name + "MarcaGrid.xml"
         Dim nameComp As String = Me.ugvUtilXRubro.FindForm().Name + "RubroGrid.xml"

         If System.IO.File.Exists(nameMarca) Then
            Me.ugvUtilXMarca.DisplayLayout.LoadFromXml(nameMarca)
         End If

         If System.IO.File.Exists(nameComp) Then
            Me.ugvUtilXRubro.DisplayLayout.LoadFromXml(nameComp)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProveedorHabitual.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedorHabitual.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedorHabitual.Tag = dr.Cells("IdProveedor").Value.ToString()

         bscNombreProveedorHabitual.Enabled = False
         bscCodigoProveedorHabitual.Enabled = False
         btnConsultar.Focus()
      End If
   End Sub

End Class