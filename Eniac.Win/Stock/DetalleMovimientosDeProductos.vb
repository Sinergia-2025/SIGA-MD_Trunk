Public Class DetalleMovimientosDeProductos

#Region "Campos"

   Private _publicos As Publicos
   Private _stockInicial As Decimal
   Private _MovCompProv As Reglas.MovimientosComprasProductosArchivo

   '-- REQ-35223.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _publicos = New Publicos()

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia

         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         _publicos.CargaComboEmpleados(cmbEmpleado, Entidades.Publicos.TiposEmpleados.TODOS)
         cmbEmpleado.SelectedIndex = -1

         Dim oTipoMov = New Reglas.TiposMovimientos()
         'cmbTipoMovimiento.DataSource = oTipoMov.GetParaCombos()
         cmbTipoMovimiento.DataSource = oTipoMov.GetTodos()
         cmbTipoMovimiento.DisplayMember = "Descripcion"
         cmbTipoMovimiento.ValueMember = "IdTipoMovimiento"
         cmbTipoMovimiento.SelectedIndex = -1

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         'ugDetalle.DisplayLayout.Bands(0).Columns("NombreModelo").Hidden = Not Reglas.Publicos.ProductoTieneModelo
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
         'ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubSubRubro

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "VENTAS", "COMPRAS")
         cmbTiposComprobantes.SelectedIndex = -1

         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         With ugDetalle.DisplayLayout.Bands(0)
            .Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled

            .Columns("IngresoDefectuoso").Hidden = Not Reglas.Publicos.UtilizaStockDefectuoso
            .Columns("EgresoDefectuoso").Hidden = .Columns("IngresoDefectuoso").Hidden
            .Columns("SaldoDefectuoso").Hidden = .Columns("IngresoDefectuoso").Hidden

            .Columns("IngresoReservado").Hidden = Not Reglas.Publicos.UtilizaStockReservado
            .Columns("EgresoReservado").Hidden = .Columns("IngresoReservado").Hidden
            .Columns("SaldoReservado").Hidden = .Columns("IngresoReservado").Hidden

            .Columns("IngresoFuturo").Hidden = Not Reglas.Publicos.UtilizaStockFuturo
            .Columns("EgresoFuturo").Hidden = .Columns("IngresoFuturo").Hidden
            .Columns("SaldoFuturo").Hidden = .Columns("IngresoFuturo").Hidden

            .Columns("IngresoFuturoReservado").Hidden = Not Reglas.Publicos.UtilizaStockFuturoReservado
            .Columns("EgresoFuturoReservado").Hidden = .Columns("IngresoFuturoReservado").Hidden
            .Columns("SaldoFuturoReservado").Hidden = .Columns("IngresoFuturoReservado").Hidden

            '#####################################################################################################################################
            '# Verificar si las columnas 'Ingreso Disponible' y 'Egreso Disponible' son las únicas columnas de tipo 'Ingreso'/'Egreso' visibles. #
            '# De ser así, el header caption debe mostrar 'Ingreso'/'Egrego' (sin la palabra 'Disponible').                                      #  
            '#####################################################################################################################################
            If Not Reglas.Publicos.UtilizaStockDefectuoso AndAlso
               Not Reglas.Publicos.UtilizaStockReservado AndAlso
               Not Reglas.Publicos.UtilizaStockFuturo AndAlso
               Not Reglas.Publicos.UtilizaStockFuturoReservado Then

               .Columns("Ingreso").Header.Caption = "Ingreso"
               .Columns("Egreso").Header.Caption = "Egreso"
               .Columns("Saldo").Header.Caption = "Saldo"
            End If

            '-- REQ-35221.- ------------------------------------------------------
            .Columns("DescripcionAtributo01").Header.Caption = If(TipoAtributo01 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion)
            .Columns("DescripcionAtributo01").Hidden = (TipoAtributo01 = 0)
            '-- Atributo 02.- ------------------------------------------------------
            .Columns("DescripcionAtributo02").Header.Caption = If(TipoAtributo02 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion)
            .Columns("DescripcionAtributo02").Hidden = (TipoAtributo02 = 0)
            '-- Atributo 03.- ------------------------------------------------------
            .Columns("DescripcionAtributo03").Header.Caption = If(TipoAtributo03 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo03).Descripcion)
            .Columns("DescripcionAtributo03").Hidden = (TipoAtributo03 = 0)
            '-- Atributo 04.- ------------------------------------------------------
            .Columns("DescripcionAtributo04").Header.Caption = If(TipoAtributo04 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo04).Descripcion)
            .Columns("DescripcionAtributo04").Hidden = (TipoAtributo04 = 0)
            '---------------------------------------------------------------------
         End With
         ugDetalle.AgregarFiltroEnLinea({"NombreClienteProveedor", "NombreProducto", "NombreEmpleado", "IdLote", "Observacion"})

         CargarColumnasASumar()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbPreferencias.PerformClick()
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
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbGenerarArchivo_Click(sender As Object, e As EventArgs) Handles tsbGenerarArchivo.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count > 0 Then
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing AndAlso dr.Field(Of Long?)("NumeroMovimiento").HasValue Then
               Dim idTipoMovimiento = dr.Field(Of String)("IdTipoMovimiento")
               Dim numeroMovimiento = dr.Field(Of Long)("NumeroMovimiento")
               Dim IdDeposito = dr.Field(Of Integer)("IdDeposito")

               Dim rMovArchivo = New Reglas.MovimientosComprasProductosArchivo()
               Dim cantidad = rMovArchivo.GenerarArchivo(actual.Sucursal.Id, IdDeposito, idTipoMovimiento, numeroMovimiento)

               If cantidad <> 0 Then
                  ShowMessage(String.Format("Se Exportaron {0} productos EXITOSAMENTE !!!", cantidad))
               Else
                  Exit Sub
               End If
            End If
         End If
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbTipoMovimiento_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoMovimiento.CheckedChanged
      TryCatched(Sub() chbTipoMovimiento.FiltroCheckedChanged(cmbTipoMovimiento))
   End Sub
#Region "Eventos Buscador Producto"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2))
      TryCatched(
      Sub()
         lblStockActual.Visible = chbProducto.Checked
         txtStockActual.Visible = chbProducto.Checked
         txtStockActual.SetValor(0)

         lblStockInicial.Visible = chbProducto.Checked
         txtStockInicial.Visible = chbProducto.Checked
         txtStockInicial.SetValor(0)

         lblStockFinal.Visible = chbProducto.Checked
         txtStockFinal.Visible = chbProducto.Checked
         txtStockFinal.SetValor(0)

         'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
         If chbProducto.Checked Then
            'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
            cmbMarcas.Refrescar()
            cmbModelos.Refrescar()
            cmbRubros.Refrescar()
            cmbSubRubros.Refrescar()
            cmbSubSubRubros.Refrescar()
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
#Region "Eventos Buscador Lotes"
   Private Sub chbLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbLote.CheckedChanged
      TryCatched(Sub() chbLote.FiltroCheckedChanged(usaPermitido:=True, bscLote))
   End Sub
   Private Sub bscLote_BuscadorClick() Handles bscLote.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLotes(bscLote)
         bscLote.Datos = New Reglas.ProductosLotes().GetFiltradoPorId(bscLote.Text, actual.Sucursal.Id)
      End Sub)
   End Sub

   Private Sub bscLote_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscLote.BuscadorSeleccion
      TryCatched(
      Sub()
         If e.FilaDevuelta IsNot Nothing Then
            bscLote.Text = e.FilaDevuelta.Cells("IdLote").Value.ToString()
            btnConsultar.Focus()
         End If
      End Sub)
   End Sub
#End Region
#Region "Eventos Buscador Clientes"
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
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub
#Region "Eventos Buscador Proveedores"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmpleado.CheckedChanged
      TryCatched(Sub() chbEmpleado.FiltroCheckedChanged(cmbEmpleado))
   End Sub
   Private Sub cmbMarcas_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim marcas = cmbMarcas.GetMarcas(todosVacio:=True)
         cmbModelos.ConcatenarNombreMarca = marcas.CountSecure() <> 1
         cmbModelos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                marcas:=marcas)
      End Sub)
   End Sub
   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
         cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
         cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                  rubros:=rubros)
      End Sub)
   End Sub
   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
         cmbSubSubRubros.ConcatenarNombreSubRubro = subRubros.CountSecure() <> 1
         cmbSubSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                     subRubro:=subRubros)
      End Sub)
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If chbLote.Checked And Not bscLote.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Lote aunque activó ese Filtro.")
            bscLote.Focus()
            Exit Sub
         End If

         If chbEmpleado.Checked And cmbEmpleado.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Empleado aunque activó ese Filtro.")
            cmbEmpleado.Focus()
            Exit Sub
         End If

         If chbProducto.Checked Then
            'Actualiza el stock actual queda la pantalla levantada un tiempo y vuelve a "consultar"
            bscCodigoProducto2.PresionarBoton()
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs)
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If e.Cell.Column.Key = "Ver" Then
               Dim muestraCombo = dr.Field(Of Boolean)("MuestraCombo")

               If Not String.IsNullOrWhiteSpace(dr.Field(Of String)("NumeroComprobante")) Then
                  ShowMessage(String.Format("El movimiento está asociado al comprobante {0} {1} {2}. Dirijase al módulo correspondiente para imprimirlo.",
                                            dr.Field(Of String)("TipoComprobante"),
                                            dr.Field(Of String)("Letra"),
                                            dr.Field(Of String)("NumeroComprobante")))
               ElseIf Not String.IsNullOrWhiteSpace(dr.Field(Of String)("IdProduccion")) Then
                  ShowMessage("El movimiento pertenece al módulo de producción. Dirijase al mismo para imprimirlo.")
               Else
                  Dim idTipoMovimiento As String = dr.Field(Of String)("IdTipoMovimiento")
                  Dim numeroMovimiento As Long = dr.Field(Of Long)("NumeroMovimiento")
                  Dim IdSucursal As Integer = dr.Field(Of Integer)("IdSucursal")
                  Dim IdDeposito As Integer = dr.Field(Of Integer)("IdDeposito")

                  Dim oMov = New Reglas.MovimientosStock().GetUno(IdSucursal, idTipoMovimiento, numeroMovimiento)
                  If oMov IsNot Nothing Then
                     Dim impresion = New ImprimirMovimientoStock()
                     impresion.Imprimir(oMov)
                  End If
               End If
            End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub
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
   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

         If Boolean.Parse(dr.Cells("AfectaStock").Value.ToString()) Then
            'Me daba error la otra forma, desde que le puse el formato en la grilla
            txtStockActual.SetValor(Decimal.Parse(dr.Cells("Stock").Value.ToString()))     'dr.Cells("Stock").Value.ToString("##,##0.00")
            _stockInicial = Decimal.Parse(dr.Cells("StockInicial").Value.ToString())
            txtStockInicial.SetValor(0)
         Else
            lblStockActual.Visible = False
            txtStockActual.Visible = False
            lblStockInicial.Visible = False
            txtStockInicial.Visible = False
            lblStockFinal.Visible = False
            txtStockFinal.Visible = False
         End If

         bscProducto2.Permitido = False
         bscCodigoProducto2.Permitido = False

         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbTipoMovimiento.Checked = False

      cmbMarcas.Refrescar()
      cmbModelos.Refrescar()
      cmbRubros.Refrescar()
      cmbSubRubros.Refrescar()
      cmbSubSubRubros.Refrescar()

      chbProducto.Checked = False

      chbCliente.Checked = False
      chbProveedor.Checked = False

      chbEmpleado.Checked = False
      cmbEmpleado.SelectedIndex = -1

      bscLote.Text = String.Empty
      bscLote.Selecciono = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      cmbSucursal.Refrescar()

      ugDetalle.ClearFilas()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim decStockFinal As Decimal
      Dim decStockFinalDefectuoso As Decimal
      Dim decStockFinalReservado As Decimal
      Dim decStockFinalFuturo As Decimal
      Dim decStockFinalFuturoReservado As Decimal


      Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

      txtStockInicial.SetValor(0)
      txtStockFinal.SetValor(0)

      Dim saldosIniciales As Reglas.Stock.GetSaldoDetallePorProductoResult = Nothing

      Dim rStock = New Reglas.Stock()

      If chbProducto.Checked Then
         saldosIniciales = rStock.GetSaldoDetallePorProducto(actual.Sucursal.Id, Date.Parse("01/01/1900"), Me.dtpDesde.Value.AddDays(-1), bscCodigoProducto2.Text)
         txtStockInicial.SetValor(_stockInicial + saldosIniciales.SaldoInicial)
      End If

      'Si filtra un producto, muestra el saldo
      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("Saldo").Hidden = Not (chbProducto.Checked And Me.txtStockFinal.Visible)
         .Columns("SaldoDefectuoso").Hidden = .Columns("Saldo").Hidden Or .Columns("IngresoDefectuoso").Hidden
         .Columns("SaldoReservado").Hidden = .Columns("Saldo").Hidden Or .Columns("IngresoReservado").Hidden
         .Columns("SaldoFuturo").Hidden = .Columns("Saldo").Hidden Or .Columns("IngresoFuturo").Hidden
         .Columns("SaldoFuturoReservado").Hidden = .Columns("Saldo").Hidden Or .Columns("IngresoFuturoReservado").Hidden
      End With

      'Si filtra NO un producto, muestra otro detalle
      ugDetalle.DisplayLayout.Bands(0).Columns("IdProducto").Hidden = Me.chbProducto.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("NombreProducto").Hidden = Me.chbProducto.Checked

      ugDetalle.DisplayLayout.Bands(0).Columns("NombreMarca").Hidden = chbProducto.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("NombreRubro").Hidden = chbProducto.Checked

      decStockFinal = txtStockInicial.ValorNumericoPorDefecto(0D)

      If saldosIniciales IsNot Nothing Then
         decStockFinalDefectuoso = saldosIniciales.SaldoInicialDefectuoso
         decStockFinalReservado = saldosIniciales.SaldoInicialReservado
         decStockFinalFuturo = saldosIniciales.SaldoInicialFuturo
         decStockFinalFuturoReservado = saldosIniciales.SaldoInicialFuturoReservado
      End If

      Dim idTipoMovimiento = cmbTipoMovimiento.ValorSeleccionado(chbTipoMovimiento, String.Empty)
      Dim idTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), 0L)
      Dim lote = If(chbLote.Checked, bscLote.Text, String.Empty)
      Dim idEmpleado = cmbEmpleado.ValorSeleccionado(chbEmpleado, 0I)

      dtDetalle = rStock.GetInformeDetallePorProducto(cmbSucursal.GetSucursales(), dtpDesde.Value, dtpHasta.Value,
                                                      idTipoMovimiento, idTipoComprobante,
                                                      bscCodigoProducto2.Text, lote,
                                                      cmbMarcas.GetMarcas(todosVacio:=True), cmbModelos.GetModelos(todosVacio:=True),
                                                      cmbRubros.GetRubros(todosVacio:=True), cmbSubRubros.GetSubRubros(todosVacio:=True), cmbSubSubRubros.GetSubSubRubros(todosVacio:=True),
                                                      idCliente, idProveedor, idEmpleado)

      dt = CrearDT()

      For Each dr In dtDetalle.AsEnumerable()
         drCl = dt.NewRow()
         drCl("FechaMovimiento") = Date.Parse(dr("FechaMovimiento").ToString)
         drCl("IdTipoMovimiento") = dr("IdTipoMovimiento")
         drCl("TipoMovimiento") = dr("TipoMovimiento").ToString.Trim()
         drCl("MuestraCombo") = dr("MuestraCombo")
         drCl("NumeroMovimiento") = dr("NumeroMovimiento").ToString
         drCl("TipoComprobante") = dr("TipoComprobante").ToString.Trim()
         drCl("Letra") = dr("Letra").ToString

         If Not String.IsNullOrEmpty(dr("CentroEmisor").ToString) Then
            drCl("NumeroComprobante") = Strings.Format(dr("CentroEmisor"), "0000") & "-" & Strings.Format(dr("NumeroComprobante"), "00000000")
         Else
            drCl("NumeroComprobante") = ""
         End If

         drCl("IdProduccion") = dr("IdProduccion")

         If Not String.IsNullOrEmpty(dr("CodigoClienteProveedor").ToString) Then
            drCl("CodigoClienteProveedor") = dr("CodigoClienteProveedor").ToString()
         End If

         drCl("NombreClienteProveedor") = dr("NombreClienteProveedor").ToString
         drCl("SucursalDeA") = dr("NombreSucursalDeA").ToString
         drCl("IdProducto") = dr("IdProducto").ToString

         drCl("Precio") = dr("Precio").ToString

         SetIngresoEgresoSaldo(dr, drCl, "Ingreso", "Egreso", "Saldo", decStockFinal)

         drCl("NombreProducto") = dr("NombreProducto").ToString
         '---------------------------------------------------------------------------
         drCl("IdDeposito") = dr("IdDeposito")
         drCl("IdUbicacion") = dr("IdUbicacion")
         drCl("Deposito") = dr("NombreDeposito")
         drCl("Ubicacion") = dr("NombreUbicacion")
         '---------------------------------------------------------------------------
         drCl("NombreMarca") = dr("NombreMarca").ToString()
         drCl("NombreRubro") = dr("NombreRubro").ToString()
         drCl("NombreSubRubro") = dr("NombreSubRubro").ToString()

         drCl("IdEmpleado") = dr("IdEmpleado")
         drCl("NombreEmpleado") = dr("NombreEmpleado")

         drCl("Usuario") = dr("Usuario").ToString

         drCl("IdLote") = dr("IdLote").ToString

         drCl("Observacion") = dr("Observacion").ToString
         drCl("IdSucursal") = dr("IdSucursal")

         '-- REQ-35223.- ------------------------------------------------------------
         drCl("IdaAtributoProducto01") = dr("IdaAtributoProducto01")
         drCl("DescripcionAtributo01") = dr("DescripcionAtributo01")
         drCl("IdaAtributoProducto02") = dr("IdaAtributoProducto02")
         drCl("DescripcionAtributo02") = dr("DescripcionAtributo02")
         drCl("IdaAtributoProducto03") = dr("IdaAtributoProducto03")
         drCl("DescripcionAtributo03") = dr("DescripcionAtributo03")
         drCl("IdaAtributoProducto04") = dr("IdaAtributoProducto04")
         drCl("DescripcionAtributo04") = dr("DescripcionAtributo04")
         '---------------------------------------------------------------------------
         dt.Rows.Add(drCl)

      Next

      txtStockFinal.SetValor(decStockFinal)

      ugDetalle.DataSource = dt

      ugDetalle.AgregarFiltroEnLinea({"FechaMovimiento", "IdTipoComprobante"})
   End Sub

   Private Sub SetIngresoEgresoSaldo(drOrigen As DataRow, drDestino As DataRow, campoIngreso As String, campoEgreso As String, campoSaldo As String, ByRef decStockFinal As Decimal)
      Dim ingreso As Decimal = 0
      If IsNumeric(drOrigen(campoIngreso)) Then
         ingreso = Decimal.Parse(drOrigen(campoIngreso).ToString())
      End If
      Dim egreso As Decimal = 0
      If IsNumeric(drOrigen(campoEgreso)) Then
         egreso = Decimal.Parse(drOrigen(campoEgreso).ToString())
      End If

      decStockFinal += ingreso + egreso

      If ingreso = 0 Then
         drDestino(campoIngreso) = DBNull.Value
      Else
         drDestino(campoIngreso) = ingreso
      End If

      If egreso = 0 Then
         drDestino(campoEgreso) = DBNull.Value
      Else
         drDestino(campoEgreso) = egreso * -1
      End If

      drDestino(campoSaldo) = decStockFinal

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp = New DataTable()

      With dtTemp
         .Columns.Add("FechaMovimiento", GetType(Date))
         .Columns.Add("IdTipoMovimiento", GetType(String))
         .Columns.Add("TipoMovimiento", GetType(String))
         .Columns.Add("MuestraCombo", GetType(Boolean))
         .Columns.Add("NumeroMovimiento", GetType(Long))
         .Columns.Add("TipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("NumeroComprobante", GetType(String))
         .Columns.Add("CodigoClienteProveedor", GetType(Long))
         .Columns.Add("NombreClienteProveedor", GetType(String))
         .Columns.Add("IdProduccion", GetType(Integer))
         .Columns.Add("SucursalDeA", GetType(String))
         .Columns.Add("Precio", GetType(Decimal))
         .Columns.Add("Ingreso", GetType(Decimal))
         .Columns.Add("Egreso", GetType(Decimal))
         .Columns.Add("Saldo", GetType(Decimal))

         .Columns.Add("IngresoDefectuoso", GetType(Decimal))
         .Columns.Add("EgresoDefectuoso", GetType(Decimal))
         .Columns.Add("SaldoDefectuoso", GetType(Decimal))

         .Columns.Add("IngresoReservado", GetType(Decimal))
         .Columns.Add("EgresoReservado", GetType(Decimal))
         .Columns.Add("SaldoReservado", GetType(Decimal))

         .Columns.Add("IngresoFuturo", GetType(Decimal))
         .Columns.Add("EgresoFuturo", GetType(Decimal))
         .Columns.Add("SaldoFuturo", GetType(Decimal))

         .Columns.Add("IngresoFuturoReservado", GetType(Decimal))
         .Columns.Add("EgresoFuturoReservado", GetType(Decimal))
         .Columns.Add("SaldoFuturoReservado", GetType(Decimal))

         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("NombreSubRubro", GetType(String))
         .Columns.Add("IdEmpleado", GetType(Integer))
         .Columns.Add("NombreEmpleado", GetType(String))
         .Columns.Add("Usuario", GetType(String))
         .Columns.Add("IdLote", GetType(String))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("IdSucursal", GetType(Integer))

         .Columns.Add("IdaAtributoProducto01", GetType(String))
         .Columns.Add("DescripcionAtributo01", GetType(String))
         .Columns.Add("IdaAtributoProducto02", GetType(String))
         .Columns.Add("DescripcionAtributo02", GetType(String))
         .Columns.Add("IdaAtributoProducto03", GetType(String))
         .Columns.Add("DescripcionAtributo03", GetType(String))
         .Columns.Add("IdaAtributoProducto04", GetType(String))
         .Columns.Add("DescripcionAtributo04", GetType(String))
         .Columns.Add("IdDeposito", GetType(Integer))
         .Columns.Add("IdUbicacion", GetType(Integer))
         .Columns.Add("Deposito", GetType(String))
         .Columns.Add("Ubicacion", GetType(String))

      End With
      Return dtTemp
   End Function

   Private Sub CargarColumnasASumar()
      ugDetalle.AgregarTotalesSuma({"Ingreso;{0:N4}", "Egreso;{0:N4}",
                                    "IngresoDefectuoso;{0:N4}", "EgresoDefectuoso;{0:N4}",
                                    "IngresoReservado;{0:N4}", "EgresoReservado;{0:N4}",
                                    "IngresoFuturo;{0:N4}", "EgresoFuturo;{0:N4}",
                                    "IngresoFuturoReservado;{0:N4}", "EgresoFuturoReservado;{0:N4}"})
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=True, muestraNombre:=False)

         .AppendFormat(" - Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)
         If chbTipoMovimiento.Checked Then
            .AppendFormat(" - Tipo Movimiento: {0}", cmbTipoMovimiento.Text)
         End If

         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If
         If chbLote.Checked Then
            .AppendFormat(" - Lote: {0}", bscLote.Text)
         End If
         If chbCliente.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbTipoComprobante.Checked Then
            .AppendFormat(" - Tipo Comprobante: {0}", cmbTiposComprobantes.Text)
         End If
         If chbProveedor.Checked Then
            .AppendFormat(" - Proveedores: {0} - {1}", bscCodigoProveedor.Text, bscProveedor.Text)
         End If
         If chbEmpleado.Checked Then
            .AppendFormat(" - Empleado: {0}", cmbEmpleado.Text)
         End If

         If cmbMarcas.Visible Then cmbMarcas.CargarFiltrosImpresionMarcas(filtro, muestraId:=True, muestraNombre:=False)
         If cmbModelos.Visible Then cmbModelos.CargarFiltrosImpresionModelos(filtro, muestraId:=True, muestraNombre:=False)
         If cmbRubros.Visible Then cmbRubros.CargarFiltrosImpresionRubros(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubRubros.Visible Then cmbSubRubros.CargarFiltrosImpresionSubRubros(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubSubRubros.Visible Then cmbSubSubRubros.CargarFiltrosImpresionSubSubRubros(filtro, muestraId:=True, muestraNombre:=False)
      End With
      Return filtro.ToString()
   End Function

#End Region

End Class