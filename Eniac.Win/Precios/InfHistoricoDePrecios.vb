Public Class InfHistoricoDePrecios

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      '-.PE-31486.-
      TryCatched(Sub() PreferenciasLeer(ugDetalle, tsbPreferencias))

      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboMarcas(cmbMarca)
            _publicos.CargaComboRubros(cmbRubro)
            _publicos.CargaComboUsuarios(cmbUsuario)

            '# Combo de selección multiple para Lista de Precios
            cmbListaDePrecios.Initializar(False, True, True)
            cmbListaDePrecios.SelectedIndex = 0

            Dim formato = String.Format("N{0}", Reglas.Publicos.PreciosDecimalesEnVenta)
            Dim maskInput = Formatos.MaskInput.CustomMaskInput(9, Reglas.Publicos.PreciosDecimalesEnVenta)

            With ugDetalle.DisplayLayout.Bands(0)
               .Columns("PrecioCosto").FormatoMaskInput(formato, maskInput)
               .Columns("PrecioVenta").FormatoMaskInput(formato, maskInput)
               .Columns("PrecioCostoAnterior").FormatoMaskInput(formato, maskInput)
               .Columns("PrecioVentaAnterior").FormatoMaskInput(formato, maskInput)
               .Columns("IndicePrecioCosto").FormatoMaskInput(formato, maskInput)
               .Columns("IndicePrecioVenta").FormatoMaskInput(formato, maskInput)
            End With

            '# Filtros en Linea
            ugDetalle.AgregarFiltroEnLinea({"IdProducto", "NombreProducto"})

            Refrescar()
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
      TryCatched(Sub() Refrescar())
   End Sub

   '-.PE-31486.-
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion, New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, filtro:=""))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridDocumentExporter1, filtro:=""))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta, ultimoSegundo:=True))
   End Sub

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(
         Sub()
            chbMarca.FiltroCheckedChanged(cmbMarca)
            'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
            'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
            If chbMarca.Checked Then
               chbProducto.Checked = False
            End If
         End Sub)
   End Sub

   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(
         Sub()
            chbRubro.FiltroCheckedChanged(cmbRubro)
            'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
            'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
            If chbRubro.Checked Then
               chbProducto.Checked = False
            End If
         End Sub)
   End Sub

#Region "Eventos Buscador Producto"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(
         Sub()
         chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2)
            If chbProducto.Checked Then
               'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
               chbMarca.Checked = False
               chbRubro.Checked = False
            End If
         End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
            bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
         End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscProducto2)
            bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
         End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub

   Private Sub chbListaDePrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaDePrecios.CheckedChanged
      TryCatched(Sub() chbListaDePrecios.FiltroCheckedChanged(cmbListaDePrecios))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbMarca.Checked And cmbMarca.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó una Marca aunque activó ese Filtro.")
               cmbMarca.Focus()
               Exit Sub
            End If

            If chbRubro.Checked And cmbRubro.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro.")
               cmbRubro.Focus()
               Exit Sub
            End If

            If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
               bscCodigoProducto2.Focus()
               Exit Sub
            End If

            If Not chbListaDeCostos.Checked AndAlso Not chbListaDePrecios.Checked Then
               ShowMessage("Debe seleccionar si desea consultar la Lista de Costos o al menos una Lista de Precios.")
               cmbListaDePrecios.Focus()
               Exit Sub
            End If

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("NO hay registros que cumplan con la seleccion !!!")
               Exit Sub
            End If
         End Sub)

   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#End Region

#Region "Metodos"

   Private Sub Refrescar()
      _publicos.CargarSucursalesACheckListBox(clbSucursales)

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbProducto.Checked = False
      chbMarca.Checked = False
      chbRubro.Checked = False
      chbProducto.Checked = False

      chbUsuario.Checked = False

      chbListaDePrecios.Checked = True
      cmbListaDePrecios.SelectedIndex = 0
      chbListaDeCostos.Checked = True

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()
      ugDetalle.DisplayLayout.Bands(0).Columns("NombreListaPrecios").Hidden = False

      dtpDesde.Focus()
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
      bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      bscProducto2.Permitido = False
      bscCodigoProducto2.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim reg = New Reglas.HistorialPrecios()

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text.Trim(), String.Empty)
      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim idUsuario = If(chbUsuario.Checked, cmbUsuario.ValorSeleccionado(Of String), String.Empty)
      Dim listaDePrecios = If(chbListaDePrecios.Checked, cmbListaDePrecios.GetListaDePrecios(), Nothing)    '# Lista de Precios Multiples
      Dim suc = clbSucursales.CheckedItems.OfType(Of Entidades.Sucursal).ToList().ConvertAll(Function(s) s.Id).ToArray()

      Dim dtDetalle = reg.GetHistorialPrecios(suc, dtpDesde.Value, dtpHasta.Value,
                                              idProducto, idMarca, idRubro,
                                              idUsuario, listaDePrecios, chbListaDeCostos.Checked)
      ugDetalle.DataSource = dtDetalle
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         filtro.AppendFormat("Fechas: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)

         If chbMarca.Checked Then filtro.AppendFormat(" - Marca: {0}", cmbMarca.Text)
         If chbRubro.Checked Then filtro.AppendFormat(" - Rubro: {0}", cmbRubro.Text)
         If chbProducto.Checked Then filtro.AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         If chbUsuario.Checked Then filtro.AppendFormat(" - Usuario: {0}", cmbUsuario.Text)
         If chbListaDePrecios.Checked Then filtro.AppendFormat(" - Lista de Precios: {0}", cmbListaDePrecios.Text)
         If chbListaDeCostos.Checked Then filtro.AppendFormat(" - {0}", chbListaDeCostos.Text)

      End With
      Return filtro.ToString()
   End Function

#End Region

End Class