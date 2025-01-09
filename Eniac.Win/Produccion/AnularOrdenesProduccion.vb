Public Class AnularOrdenesProduccion

#Region "Campos"

   Private _publicos As Publicos

   Dim dtsMaster_detalle As DataSet
   'Dim primeraCarga As Boolean = True
   Dim dtDetalle As DataTable
   Dim dtOrdenProduccionDetalle As DataTable

   Private _tit As Dictionary(Of String, String)
   Private _tit1 As Dictionary(Of String, String)

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _tit = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"))
         _tit1 = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Detalle"))

         _publicos = New Publicos()

         cmbEstados.Items.Insert(0, "PENDIENTE")

         RefrescarDatosGrilla()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbAnular.PerformClick()
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
   Private Sub tsbAnular_Click(sender As Object, e As EventArgs) Handles tsbAnular.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.UpdateData()

         Dim tablaAnular = ugDetalle.DataSource(Of DataSet).Tables("Cabecera").Clone()
         For Each fila In ugDetalle.DataSource(Of DataSet).Tables("Cabecera").AsEnumerable()
            If Boolean.Parse(fila("anula").ToString) Then
               tablaAnular.ImportRow(fila)
            End If
         Next

         If tablaAnular.Rows.Count = 0 Then
            ShowMessage("ATENCION: NO Seleccionó Ningún Orden de Producción para Anular!!")
            Exit Sub
         End If

         Dim rOrdenProduccion = New Reglas.OrdenesProduccion()
         rOrdenProduccion.AnularOrdenesProduccion(tablaAnular)

         ShowMessage("¡¡¡ Orden/es de Producción Anulado/s Exitosamente !!!")

         btnConsultar_Click(btnConsultar, New EventArgs())
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(bscCodigoProducto2, bscProducto2))
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , , )
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , )
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region
#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
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
   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdPedido.CheckedChanged
      TryCatched(Sub() chbIdPedido.FiltroCheckedChanged(txtIdPedido))
   End Sub
   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      TryCatched(Sub() chbOrdenCompra.FiltroCheckedChanged(txtOrdenCompra))
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
         If chbIdPedido.Checked AndAlso txtIdPedido.ValorNumericoPorDefecto(0I) = 0 Then
            ShowMessage("ATENCION: NO Ingresó un Número de Orden Producción aunque activó ese Filtro.")
            txtIdPedido.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub
         Dim reg = New Reglas.OrdenesProduccion()
         If e.Cell.Column.Header.Caption = "Ver" Then
            Dim idTipoComprobante = e.Cell.Row.Cells(Entidades.OrdenProduccion.Columnas.IdTipoComprobante.ToString()).Value.ToString()
            Dim letra = e.Cell.Row.Cells(Entidades.OrdenProduccion.Columnas.Letra.ToString()).Value.ToString()
            Dim centroEmisor = Short.Parse(e.Cell.Row.Cells(Entidades.OrdenProduccion.Columnas.CentroEmisor.ToString()).Value.ToString())
            Dim numeroOrdenProduccion = Long.Parse(e.Cell.Row.Cells(Entidades.OrdenProduccion.Columnas.NumeroOrdenProduccion.ToString()).Value.ToString())

            Dim oOrdenProduccion = New Reglas.OrdenesProduccion().GetUno(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion)
            Dim impresion = New ImpresionOrdenesProduccion()

            If e.Cell.Column.Header.Caption = "Ver" Then
               impresion.ImprimirOrdenProduccion(oOrdenProduccion, True)
            Else
               impresion.ImprimirOrdenProduccionDetallado(oOrdenProduccion, True)
            End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

         bscCliente.Enabled = False
         bscCodigoCliente.Enabled = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Enabled = False
         bscCodigoProducto2.Enabled = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      cmbEstados.SelectedIndex = 0

      chbFecha.Checked = False
      chbProducto.Checked = False
      chbCliente.Checked = False
      chbIdPedido.Checked = False
      chbOrdenCompra.Checked = False

      If dtsMaster_detalle IsNot Nothing Then
         dtsMaster_detalle.Clear()
      End If

      '-- REG-41940.- --------------------------------------------------------------------------
      dtpDesdePlanMaestro.Value = DateTime.Today
      dtpHastaPlanMaestro.Value = DateTime.Today.UltimoSegundoDelDia()
      '-----------------------------------------------------------------------------------------
      ugDetalle.ClearFilas()

      cmbEstados.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()
      ''''Dim IdMarca As Integer = 0
      ''''Dim IdRubro As Integer = 0
      ''''Dim idSubRubro As Integer = 0
      ''''Dim lote As String = String.Empty

      ''''Dim Tamanio As Decimal = 0


      ''''Dim TipoComprobante As String = String.Empty

      ''''Dim IdVendedor As Integer = 0

      ''''Dim IdFormaDePago As Integer = 0
      ''''Dim IdUsuario As String = String.Empty
      ''''Dim Cantidad As String = String.Empty

      ''''Dim idPed_str As String = String.Empty
      '''''Dim colIdPedidos As New Collection


      Dim fechaDesde = dtpDesde.Valor(chbFecha).IfNull()
      Dim fechaHasta = dtpHasta.Valor(chbFecha).IfNull()
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim numeroOrdenProduccion = txtIdPedido.ValorSeleccionado(chbIdPedido, -1I)
      Dim ordenCompra = txtOrdenCompra.ValorSeleccionado(chbOrdenCompra, 0L)
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)

      Dim nroPlanMaestro = If(chbPlanMaestro.Checked, txtPlanMaestro.ValorNumericoPorDefecto(0I), 0I)
      Dim fechaDesdePlan = dtpDesdePlanMaestro.Valor(chbFechaPlanMaestro)
      Dim fechaHastaPlan = dtpHastaPlanMaestro.Valor(chbFechaPlanMaestro)

      dtsMaster_detalle = New DataSet()

      Dim rOrdenesProduccion = New Reglas.OrdenesProduccion()
      dtDetalle = rOrdenesProduccion.OrdenesProduccionCabecera(actual.Sucursal.Id,
                                                               cmbEstados.Text, fechaDesde, fechaHasta, numeroOrdenProduccion, idProducto,
                                                               IdMarca:=0, IdRubro:=0, lote:=String.Empty,
                                                               idCliente,
                                                               IdUsuario:=String.Empty, Tamanio:=0, IdVendedor:=0,
                                                               ordenCompra,
                                                               nroPlanMaestro,
                                                               fechaDesdePlan,
                                                               fechaHastaPlan)

      dtDetalle.TableName = "Cabecera"
      dtsMaster_detalle.Tables.Add(dtDetalle)

      dtOrdenProduccionDetalle = rOrdenesProduccion.GetOrdenesProduccionDetalladoXEstadosTodos(actual.Sucursal.Id,
                                                                                               cmbEstados.Text, fechaDesde, fechaHasta, numeroOrdenProduccion, idProducto,
                                                                                               IdMarca:=0, IdRubro:=0, lote:=String.Empty,
                                                                                               idCliente,
                                                                                               IdUsuario:=String.Empty, Tamanio:=0, IdVendedor:=0,
                                                                                               ordenCompra,
                                                                                               nroPlanMaestro,
                                                                                               fechaDesdePlan,
                                                                                               fechaHastaPlan)

      dtOrdenProduccionDetalle.TableName = "detalle"
      dtsMaster_detalle.Tables.Add(dtOrdenProduccionDetalle)

      Dim ColumnasPadre(4) As DataColumn
      Dim ColumnasHijo(4) As DataColumn
      ColumnasPadre(0) = dtsMaster_detalle.Tables("Cabecera").Columns("IdSucursal")
      ColumnasPadre(1) = dtsMaster_detalle.Tables("Cabecera").Columns("IdTipoComprobante")
      ColumnasPadre(2) = dtsMaster_detalle.Tables("Cabecera").Columns("CentroEmisor")
      ColumnasPadre(3) = dtsMaster_detalle.Tables("Cabecera").Columns("Letra")
      ColumnasPadre(4) = dtsMaster_detalle.Tables("Cabecera").Columns("NumeroOrdenProduccion")
      ColumnasHijo(0) = dtsMaster_detalle.Tables("detalle").Columns("IdSucursal")
      ColumnasHijo(1) = dtsMaster_detalle.Tables("detalle").Columns("IdTipoComprobante")
      ColumnasHijo(2) = dtsMaster_detalle.Tables("detalle").Columns("CentroEmisor")
      ColumnasHijo(3) = dtsMaster_detalle.Tables("detalle").Columns("Letra")
      ColumnasHijo(4) = dtsMaster_detalle.Tables("detalle").Columns("NumeroOrdenProduccion")

      Dim relConstEnum As DataRelation = New DataRelation("Detalle", ColumnasPadre, ColumnasHijo, True)
      dtsMaster_detalle.Relations.Add(relConstEnum)

      '############################3
      ugDetalle.SetDataBinding(dtsMaster_detalle, "Cabecera")
      'Me.ugDetalle.SetDataBinding(dtsMaster_detalle, "Detalle")

      ugDetalle.DataSource = dtsMaster_detalle

      If Not ugDetalle.DisplayLayout.Bands(0).Columns.Exists("ImprimirCab") Then
         ugDetalle.DisplayLayout.Bands(0).Columns.Add("ImprimirCab", "Ver").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         ugDetalle.DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D
         ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").Header.VisiblePosition = 0
         ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").Width = 30

         _tit.Add("ImprimirCab", "")

         ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
         ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Header.VisiblePosition = 1
         ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Width = 40
      End If

      AjustarColumnasGrilla()
   End Sub

   Private Sub FormatearGrilla()
      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("ImprimirCab").Width = 30
         Dim pos = 1I
         .Columns("anula").FormatearColumna("Anula", pos, 40).Style = UltraWinGrid.ColumnStyle.CheckBox
         .Columns("IdOrdenProduccion").FormatearColumna("Número", pos, 60, HAlign.Right)
         .Columns("fechaOrdenProduccion").FormatearColumna("Fecha/Hora", pos, 100, HAlign.Center)
         .Columns("NombreCliente").FormatearColumna("Cliente", pos, 200)
         .Columns("IdUsuario").FormatearColumna("Usuario", pos, 80)
         .Columns("Observacion").FormatearColumna("Observación", pos, 300)
      End With
   End Sub

   Private Sub FormatearGrilla2()
      With ugDetalle.DisplayLayout.Bands(1)
         Dim pos = 0I
         .Columns("IdSucursal").OcultoPosicion(hidden:=True, pos)
         .Columns("idProducto").FormatearColumna("Nro.Prod.", pos, 100, HAlign.Right)
         .Columns("IdOrdenProduccion").OcultoPosicion(hidden:=True, pos)
         .Columns("fechaOrdenProduccion").OcultoPosicion(hidden:=True, pos)
         .Columns("IdCliente").OcultoPosicion(hidden:=True, pos)
         .Columns("NombreCliente").OcultoPosicion(hidden:=True, pos)
         .Columns("nombreProducto").FormatearColumna("Producto", pos, 250)
         .Columns("tamano").FormatearColumna("Tamaño", pos, 60, HAlign.Right)
         .Columns("Orden").OcultoPosicion(hidden:=True, pos)
         .Columns("Cantidad").FormatearColumna("Cant. Pedida", pos, 80, HAlign.Right, , "N2")
         .Columns("fechaestado").FormatearColumna("Fecha Estado", pos, 100, HAlign.Center,, "dd/MM/yyyy HH:mm")
         .Columns("IdEstado").FormatearColumna("Estado", pos, 80)
         .Columns("CantEstado").FormatearColumna("Cant. Estado", pos, 80, HAlign.Right, , "N2")
         .Columns("cantPendiente").FormatearColumna("Cant. Pendiente", pos, 80, HAlign.Right, , "N2")
         .Columns("idTipoComprobante").FormatearColumna("Comprobante", pos, 90)
         .Columns("Letra").FormatearColumna("Let.", pos, 40, HAlign.Center)
         .Columns("CentroEmisor").FormatearColumna("P.V.", pos, 40, HAlign.Right)
         .Columns("NumeroComprobante").FormatearColumna("Nro.Comp.", pos, 70, HAlign.Right)
         .Columns("IdUsuario").FormatearColumna("Usuario", pos, 80)
         .Columns("Observacion").FormatearColumna("Observación", pos, 200)
      End With
   End Sub

   Private Overloads Sub AjustarColumnasGrilla()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"), _tit)
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Detalle"), _tit1)
   End Sub

   '-- REG-41940.- --------------------------------------------------------------------------------------------------------------
   Private Sub chbPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chbPlanMaestro.CheckedChanged
      '-- Inicializa los campos de Filtro.- ------------------------------------------------
      txtPlanMaestro.Enabled = chbPlanMaestro.Checked
      txtPlanMaestro.Text = "0"
      txtPlanMaestro.Select()
      '-------------------------------------------------------------------------------------
   End Sub

   Private Sub chbFechaPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaPlanMaestro.CheckedChanged
      dtpDesdePlanMaestro.Enabled = chbFechaPlanMaestro.Checked
      dtpHastaPlanMaestro.Enabled = chbFechaPlanMaestro.Checked

      dtpDesdePlanMaestro.Value = Date.Today
      dtpHastaPlanMaestro.Value = Date.Today.UltimoSegundoDelDia()
   End Sub
   '--------------------------------------------------------------------------------------------------------------------------
#End Region
End Class