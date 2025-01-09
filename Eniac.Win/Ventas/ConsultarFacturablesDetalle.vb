Public Class ConsultarFacturablesDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _rVenta As Reglas.Ventas
   Private _rVentaProd As Reglas.VentasProductos

   Private _titClientes As Dictionary(Of String, String)
   Private _titComprobantes As Dictionary(Of String, String)
   Private _titDetalles As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Publicos()

            _rVenta = New Reglas.Ventas()
            _rVentaProd = New Reglas.VentasProductos()

            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
            _publicos.CargaComboCategorias(cmbCategorias)

            _titClientes = GetColumnasVisiblesGrilla(ugCliente)
            _titComprobantes = GetColumnasVisiblesGrilla(ugComprobantes)
            _titDetalles = GetColumnasVisiblesGrilla(ugDetalle)

            ugCliente.AgregarFiltroEnLinea({"NombreCliente"})
            ugComprobantes.AgregarFiltroEnLinea({})
            ugDetalle.AgregarFiltroEnLinea({"NombreProducto"})

            RefrescarDatos()
         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      ElseIf keyData = Keys.F4 Then
         btnConsultar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Toolbar"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            CargaGrillaDetalle()

            If ugCliente.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("No hay registros que cumplan con la selección !!!")
            End If

         End Sub)
   End Sub

   Private Sub ugCliente_AfterRowActivate(sender As Object, e As EventArgs) Handles ugCliente.AfterRowActivate
      TryCatched(
         Sub()
            Dim drCliente = ugCliente.FilaSeleccionada(Of DataRow)()
            If drCliente IsNot Nothing Then
               Dim idCliente = drCliente.Field(Of Long)(Entidades.Cliente.Columnas.IdCliente.ToString())

               Dim dt = _rVenta.GetInfFacturables(actual.Sucursal.Id, dtpDesde.Value, dtpHasta.Value, idCliente, "PENDIENTE", "", 0, "", 0, 0)

               ugComprobantes.DataSource = dt
               ugComprobantes.Selected.Rows.AddRange(ugComprobantes.Rows.All.
                                                      Where(Function(ur) TypeOf (ur) Is UltraGridRow).ToList().
                                                      ConvertAll(Function(ug) DirectCast(ug, UltraGridRow)).ToArray())
               AjustarColumnasGrilla(ugComprobantes, _titComprobantes)

            End If
         End Sub)
   End Sub

   Private Sub ugComprobantes_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles ugComprobantes.AfterSelectChange
      TryCatched(
         Sub()

            Dim drComps = ugComprobantes.Selected.Rows.All.ToList().
                              ConvertAll(Function(ur) ugComprobantes.FilaSeleccionada(Of DataRow)(DirectCast(ur, UltraGridRow)))

            ugDetalle.DataSource = _rVentaProd.GetDetallePorComprobante(drComps)
            AjustarColumnasGrilla(ugDetalle, _titDetalles)

         End Sub)
   End Sub

   Private Sub chbCategoriaCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaCliente.CheckedChanged
      TryCatched(Sub() chbCategoriaCliente.FiltroCheckedChanged(cmbCategorias))
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatos()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbVendedor.Checked = False
      txtProducto.Text = String.Empty
      chbCategoriaCliente.Checked = False

      LimpiarGrillas()

      btnConsultar.Focus()

   End Sub

   Private Sub LimpiarGrillas()
      ugCliente.ClearFilas()
      ugComprobantes.ClearFilas()
      ugDetalle.ClearFilas()
   End Sub

   Private Sub CargaGrillaDetalle()
      LimpiarGrillas()

      Dim idVendedor = If(chbVendedor.Checked, cmbVendedor.ValorSeleccionado(Of Integer), 0I)
      Dim idCategoria = If(chbCategoriaCliente.Checked, cmbCategorias.ValorSeleccionado(Of Integer), 0I)
      Dim dtDetalle = _rVenta.GetClientesConFacturables(actual.Sucursal.Id,
                                                        dtpDesde.Value, dtpHasta.Value, txtProducto.Text,
                                                        idVendedor, idCategoria)

      ''dgvClientes.DataSource = dtDetalle
      ugCliente.DataSource = dtDetalle
      AjustarColumnasGrilla(ugCliente, _titClientes)

      tssRegistros.Text = ugCliente.CantidadRegistrosParaStatusbar
   End Sub

#End Region

End Class