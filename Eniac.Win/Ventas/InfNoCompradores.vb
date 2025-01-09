Public Class InfNoCompradores

#Region "Campos"

   Private _publicos As Publicos
   Private _IdActualCuentaBancaria As Integer = 0
   Public ConsultarAutomaticamente As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            chbCategoriaCliente.Checked = False
            chbVendedor.Checked = False
            chbZonaGeografica.Checked = False

            _publicos.CargaComboMarcas(cmbMarca)
            _publicos.CargaComboRubros(cmbRubro)
            _publicos.CargaComboCategorias(cmbCategoria)
            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
            cmbVendedor.SelectedIndex = -1
            _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
            cmbZonaGeografica.SelectedIndex = -1
            _publicos.CargaComboRutas(cmbRuta, activa:=True, seleccionMultiple:=False, seleccionTodos:=False, cargarListaPrecios:=False)
            _publicos.CargaComboDesdeEnum(cmbActivo, GetType(Entidades.Publicos.SiNoTodos))
            cmbActivo.SelectedValue = Entidades.Publicos.SiNoTodos.SI

            Dim oProv = New Reglas.Provincias()
            Dim dtProv = oProv.GetAll()

            cmbProvincia.DisplayMember = "NombreProvincia"
            cmbProvincia.ValueMember = "IdProvincia"
            cmbProvincia.DataSource = dtProv.Copy()
            cmbProvincia.SelectedIndex = -1

            ugDetalle.AgregarFiltroEnLinea({"Codigo", "NombreCliente"})

            PreferenciasLeer(ugDetalle, tsbPreferencias)

            cmbRuta.Visible = New Reglas.Funciones().ExisteFuncion("MovilRutasABM")
            chbRuta.Visible = cmbRuta.Visible

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
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#Region "Eventos Filtros"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      TryCatched(Sub() chbLocalidad.FiltroCheckedChanged(usaPermitido:=True, bscCodigoLocalidad, bscNombreLocalidad))
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
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region

#Region "Eventos Buscador Localidades"
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
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarLocalidad(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(Sub() chbMarca.FiltroCheckedChanged(cmbMarca))
   End Sub
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(cmbRubro))
   End Sub
   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged
      TryCatched(Sub() chbProvincia.FiltroCheckedChanged(cmbProvincia))
   End Sub
   Private Sub chbCategoriaCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaCliente.CheckedChanged
      TryCatched(Sub() chbCategoriaCliente.FiltroCheckedChanged(cmbCategoria))
   End Sub
   Private Sub chbRuta_CheckedChanged(sender As Object, e As EventArgs) Handles chbRuta.CheckedChanged
      TryCatched(Sub() chbRuta.FiltroCheckedChanged(cmbRuta))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
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

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()
      dtpDesde.Value = Date.Today

      chbVendedor.Checked = False
      chbCliente.Checked = False
      chbCategoriaCliente.Checked = False
      chbZonaGeografica.Checked = False
      chbMarca.Checked = False
      chbRubro.Checked = False
      chbLocalidad.Checked = False
      chbProvincia.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      cmbActivo.SelectedValue = Entidades.Publicos.SiNoTodos.SI

      ugDetalle.ClearFilas()

      dtpDesde.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idZonaGeografica = cmbZonaGeografica.ValorSeleccionado(chbZonaGeografica, String.Empty)
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoriaCliente, 0I)
      Dim idProvincia = cmbProvincia.ValorSeleccionado(chbProvincia, String.Empty)
      Dim idLocalidad = If(chbLocalidad.Checked, bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I), 0I)
      Dim idRuta = cmbRuta.ValorSeleccionado(chbRuta, 0I)

      Dim rVentas = New Reglas.Ventas()
      Dim dtDetalle = rVentas.GetNoCompradores(dtpDesde.Value, idCliente, idVendedor, idZonaGeografica, idCategoria, idMarca, idRubro, idLocalidad, idProvincia, idRuta,
                                               cmbActivo.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)())
      ugDetalle.DataSource = dtDetalle

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      bscCliente.Permitido = False
      bscCodigoCliente.Permitido = False

      btnConsultar.Focus()
   End Sub
   Private Sub CargarLocalidad(dr As DataGridViewRow)
      bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      bscCodigoLocalidad.Permitido = False
      bscNombreLocalidad.Permitido = False

      btnConsultar.Focus()
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fecha desde: {0}", dtpDesde.Text)
         If chbCliente.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbCategoriaCliente.Checked Then
            .AppendFormat(" - Categoria: {0}", cmbCategoria.Text)
         End If
         If chbVendedor.Checked Then
            .AppendFormat(" - Vendedor: {0}", cmbVendedor.Text)
         End If
         If chbZonaGeografica.Checked Then
            .AppendFormat(" - Zona Geografica: {0}", cmbZonaGeografica.Text)
         End If
         If chbProvincia.Checked Then
            .AppendFormat(" - Provincia: {0}", cmbProvincia.Text)
         End If
         If chbMarca.Checked Then
            .AppendFormat(" - Marca: {0}", cmbMarca.Text)
         End If
         If chbRubro.Checked Then
            .AppendFormat(" - Marca: {0}", cmbRubro.Text)
         End If
         If chbLocalidad.Checked Then
            .AppendFormat(" - Localidad: {0} - {1}", bscCodigoLocalidad.Text, bscNombreLocalidad.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#End Region

End Class