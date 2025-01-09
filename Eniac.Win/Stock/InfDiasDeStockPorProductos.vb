Imports Eniac.Entidades.Publicos.Reportes
Public Class InfDiasDeStockPorProductos

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _tit As Dictionary(Of String, String)

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
         _publicos.CargaComboDesdeEnum(cmbAgruparPor, GetType(NivelAgrupamientoStock))

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            chbSubRubro.Visible = False
            cmbSubRubro.Visible = False
         End If

         '-- REQ-38504.- --------------------------------------------------------------------------------------------
         cmbSucursal.Initializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, IdFuncion)
         cmbDepositos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, {})
         '-----------------------------------------------------------------------------------------------------------

         ugDetalle.AgregarFiltroEnLinea({"NombreProducto"})

         _estaCargando = False

         RefrescarDatosGrilla()

         _tit = GetColumnasVisiblesGrilla(ugDetalle)
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
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged, chbIncluirSabados.CheckedChanged, chbIncluirDomingos.CheckedChanged
      TryCatched(Sub() txtDias.SetValor(Dias(dtpDesde.Value, dtpHasta.Value)))
   End Sub

   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim habilitaDeposito As Boolean = False
         If cmbSucursal.SelectedIndex > 0 Then
            Dim sucursal = cmbSucursal.GetSucursales()
            If sucursal.Length > 0 Then
               cmbDepositos.Inicializar(True, True, True, sucursal)
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
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
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
            'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
            'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
            chbProducto.Checked = False
         End If
      End Sub)
   End Sub
   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      TryCatched(
      Sub()
         chbSubRubro.FiltroCheckedChanged(cmbSubRubro)
         If chbSubRubro.Checked Then
            'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
            'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
            chbProducto.Checked = False
         End If
      End Sub)
   End Sub

#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And bscCodigoProducto2.Text.Length = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
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

      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbMesCompleto.Checked = False

      chbMarca.Checked = False
      chbRubro.Checked = False
      chbSubRubro.Checked = False
      chbProducto.Checked = False

      cmbSucursal.Refrescar()
      cmbDepositos.Refrescar()
      chbUbicacion.Checked = False

      cmbAgruparPor.SelectedValue = NivelAgrupamientoStock.Ubicacion

      chbIncluirSabados.Checked = False
      chbIncluirDomingos.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      dtpDesde.Focus()

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()

      With filtro
         .AppendFormat("Fecha: Desde {0:dd/MM/yyyy HH:mm} hasta {1:dd/MM/yyyy HH:mm}", dtpDesde.Value, dtpHasta.Value)
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)
         If cmbDepositos.ItemSeleccionado(Of Integer) <> Entidades.Sucursal.ValoresFijosIdSucursal.Todos Then
            filtro.Append(" - ")
            cmbDepositos.CargarFiltrosImpresionDepositos(filtro, False, True)
         End If
         If chbUbicacion.Checked Then
            .AppendFormat(" - Ubicación: {0}", cmbUbicacion.Text)
         End If

         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If

         If chbIncluirSabados.Checked Then
            .AppendFormat(" - {0}", chbIncluirSabados.Text)
         End If
         If chbIncluirDomingos.Checked Then
            .AppendFormat(" - {0}", chbIncluirDomingos.Text)
         End If

         If chbMarca.Checked Then
            .AppendFormat(" - Marca: {0}", cmbMarca.Text)
         End If

         If chbRubro.Checked Then
            .AppendFormat(" - Rubro: {0}", cmbRubro.Text)
         End If

         If chbSubRubro.Checked Then
            .AppendFormat(" - SubRubro: {0}", cmbSubRubro.Text)
         End If

         .AppendFormat(" - {0}: {1}", lblAgruparPor.Text, cmbAgruparPor.Text)

      End With
      Return filtro.ToString()
   End Function

   Private Sub CargaGrillaDetalle()
      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim idSubRubro = cmbSubRubro.ValorSeleccionado(chbSubRubro, 0I)
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)
      Dim nivelAgrupamiento = cmbAgruparPor.ValorSeleccionado(NivelAgrupamientoStock.Ubicacion)

      Dim rVenta = New Reglas.Ventas()
      Dim dt = rVenta.GetSumaPorProductos(cmbSucursal.GetSucursales(),
                                          cmbDepositos.GetDepositos(),
                                          cmbUbicacion.ItemSeleccionado(Of Entidades.SucursalUbicacion)(chbUbicacion),
                                          dtpDesde.Value, dtpHasta.Value,
                                          idVendedor:=0L, idCliente:=0L,
                                          idMarca, idRubro, idSubRubro,
                                          idProducto, idProveedor:=0,
                                          alertaDeCaja:=False,
                                          idCategoria:=0,
                                          unificarSumaProductos:=False,
                                          idCaja:=0, idSucursalCaja:=0,
                                          idListaPrecios:=-1,
                                          idTransportista:=0,
                                          mostrarProductodeVenta:=False, mostrarProveedorHabitual:=False,
                                          esComercial:=Entidades.Publicos.SiNoTodos.TODOS,
                                          cantidadDias:=txtDias.ValorNumericoPorDefecto(0I),
                                          nivelAgrupamiento:=nivelAgrupamiento)

      ugDetalle.DataSource = dt
      AjustarColumnasGrilla(ugDetalle, _tit)

      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("NombreDeposito").Hidden = Not (nivelAgrupamiento = NivelAgrupamientoStock.Deposito Or nivelAgrupamiento = NivelAgrupamientoStock.Ubicacion)
         .Columns("NombreUbicacion").Hidden = Not (nivelAgrupamiento = NivelAgrupamientoStock.Ubicacion)
      End With

   End Sub

   Private Function Dias(fechaDesde As Date, fechaHasta As Date) As Integer
      Dim cantDias = 1I
      Dim diaActual = fechaDesde.Date

      Do While diaActual < fechaHasta.Date
         If diaActual.DayOfWeek <> DayOfWeek.Saturday And diaActual.DayOfWeek <> DayOfWeek.Sunday Then
            cantDias += 1

         ElseIf diaActual.DayOfWeek <> DayOfWeek.Saturday And chbIncluirSabados.Checked Then
            cantDias += 1

         ElseIf diaActual.DayOfWeek <> DayOfWeek.Sunday And chbIncluirDomingos.Checked Then
            cantDias += 1
         End If

         diaActual = diaActual.AddDays(1)
      Loop
      Return cantDias
   End Function


#End Region

End Class