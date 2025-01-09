Public Class InfPuntoDePedidoDeProductos

#Region "Campos"

   Private _publicos As Publicos
   Public ConsultarAutomaticamente As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)

         _publicos.CargaComboSubRubros(cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            chbSubRubro.Visible = False
            cmbSubRubro.Visible = False
         End If

         '-- REQ-38504.- --------------------------------------------------------------------------------------------
         cmbSucursal.Initializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, IdFuncion)
         cmbDepositos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, {})
         '-----------------------------------------------------------------------------------------------------------

         If ConsultarAutomaticamente Then
            btnConsultar.PerformClick()
         End If

         dgvDetalle.AgregarFiltroEnLinea({"NombreProducto"})

         tssRegistros.Text = dgvDetalle.CantidadRegistrosParaStatusbar
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
      TryCatched(Sub() dgvDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() dgvDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() dgvDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim habilitaDeposito As Boolean = False
         If cmbSucursal.SelectedIndex > 0 Then
            Dim sucursales = cmbSucursal.GetSucursales()
            If sucursales.Length > 0 Then
               cmbDepositos.Inicializar(True, True, True, sucursales)
               habilitaDeposito = cmbDepositos.GetDepositos().Count > 1
            End If
         End If
         cmbDepositos.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      End Sub)
   End Sub
   Private Sub cmbDepositos_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositos.AfterSelectedIndexChanged
      TryCatched(Sub() _publicos.CargaComboUbicaciones(cmbUbicacion, cmbSucursal.GetSucursales(), cmbDepositos.GetDepositos()))
   End Sub
   Private Sub chbUbicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbUbicacion.CheckedChanged
      TryCatched(Sub() chbUbicacion.FiltroCheckedChanged(cmbUbicacion))
   End Sub

#Region "Eventos Buscador Productos"
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

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(
      Sub()
         chbMarca.FiltroCheckedChanged(cmbMarca)
         If chbMarca.Checked Then
            'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
            'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
            chbProducto.Checked = False
         End If
      End Sub)
   End Sub
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(
      Sub()
         chbRubro.FiltroCheckedChanged(cmbRubro)
         If chbRubro.Checked Then
            'Si elijo una marca, limpio el producto seleccionado (hipotericamente)
            'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
            chbProducto.Checked = False
         End If
      End Sub)
   End Sub
   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      TryCatched(Sub() chbSubRubro.FiltroCheckedChanged(cmbSubRubro))
   End Sub


#End Region

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() dgvDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

   Public Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And bscCodigoProducto2.Text.Length = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If chbMarca.Checked And cmbMarca.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Marca aunque activó ese Filtro")
            cmbMarca.Focus()
            Exit Sub
         End If

         If chbRubro.Checked And cmbRubro.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro")
            cmbRubro.Focus()
            Exit Sub
         End If

         If chbProducto.Checked Then
            'Actualiza el stock actual queda la pantalla levantada un tiempo y vuelve a "consultar"
            bscCodigoProducto2.PresionarBoton()
         End If

         CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Permitido = False
         bscCodigoProducto2.Permitido = False

         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      optSdSConPedido.Checked = True

      chbProducto.Checked = False

      chbMarca.Checked = False
      chbRubro.Checked = False
      chbSubRubro.Checked = False

      cmbSucursal.Refrescar()
      cmbDepositos.Refrescar()
      chbUbicacion.Checked = False

      dgvDetalle.ClearFilas()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim tipoPedido = If(optSdSConPedido.Checked, "ConPedido", "TODOS")
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)
      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim idSubRubro = cmbSubRubro.ValorSeleccionado(chbSubRubro, 0I)

      Dim rProdSuc = New Reglas.ProductosSucursales()
      Dim dtDetalle = rProdSuc.GetPuntoDePedidoDeProductos(cmbSucursal.GetSucursales(),
                                                           cmbDepositos.GetDepositos(),
                                                           cmbUbicacion.ItemSeleccionado(Of Entidades.SucursalUbicacion)(chbUbicacion),
                                                           tipoPedido,
                                                           idProducto,
                                                           idMarca, idRubro, idSubRubro)
      dgvDetalle.DataSource = dtDetalle
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()

      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)
         If cmbDepositos.ValorSeleccionado(Of Integer) = Entidades.Sucursal.ValoresFijosIdSucursal.Todos Then
            .AppendFormat(" - ")
            cmbDepositos.CargarFiltrosImpresionDepositos(filtro, False, True)
         End If
         If chbUbicacion.Checked Then
            .AppendFormat(" - Ubicacion: {0}", cmbUbicacion.Text)
         End If
         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If

         .AppendFormat(" - Situación de Stock: {0}", If(optSdSConPedido.Checked, "Con Pedido", "Todos"))

         If chbMarca.Checked Then
            .AppendFormat(" - Marca: {0}", cmbMarca.Text)
         End If
         If chbRubro.Checked Then
            .AppendFormat(" - Rubro: {0}", cmbRubro.Text)
         End If
         If chbSubRubro.Checked Then
            .AppendFormat(" - Subrubro: {0}", cmbSubRubro.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#End Region

End Class