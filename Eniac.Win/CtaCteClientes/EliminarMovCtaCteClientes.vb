Public Class EliminarMovCtaCteClientes

#Region "Campos"
   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = String.Empty
         End If

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
         If String.IsNullOrWhiteSpace(IdUsuario) Then
            cmbVendedor.SelectedIndex = -1
         Else
            chbVendedor.Checked = True
            chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
         cmbZonaGeografica.SelectedIndex = -1

         _publicos.CargaComboCategorias(cmbCategoria)

         _publicos.CargaComboTiposComprobantesCtaCteClientes(cmbTiposComprobantes)
         cmbTiposComprobantes.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbGrabanLibro, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbTodos, Reglas.Publicos.TodosEnum.MararTodos)

         ugDetalle.AgregarTotalesSuma({"ImporteTotal", "Saldo"})
         ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbEliminar.PerformClick()
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
   Private Sub tsbEliminar_Click(sender As Object, e As EventArgs) Handles tsbEliminar.Click
      TryCatched(
      Sub()
         ugDetalle.UpdateData()

         Dim dtDetalle = ugDetalle.DataSource(Of DataTable)
         If Not dtDetalle.Any(Function(dr) dr.Field(Of Boolean)("Selec")) Then
            ShowMessage("No seleccionó ningún movimiento")
         End If

         Dim ctactes = New List(Of Entidades.CuentaCorriente)()
         Dim rCtaCte = New Reglas.CuentasCorrientes()
         For Each dr In dtDetalle.Where(Function(x) x.Field(Of Boolean)("Selec"))
            Dim ctaCte = rCtaCte.GetUna(dr.Field(Of Integer)("IdSucursal"), dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                                        dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Long)("NumeroComprobante"))
            ctactes.Add(ctaCte)
         Next
         rCtaCte.EliminarCtaCteDirecta(ctactes)

         ShowMessage("La eliminacion de Cta Cte se realizo con éxito!!")

         RefrescarDatosGrilla()
      End Sub)

   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
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
   Private Sub chkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechas.CheckedChanged
      TryCatched(Sub() chbFechas.FiltroCheckedChanged(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub

#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         tsbEliminar.Enabled = True

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, "Selec"))
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()
      If String.IsNullOrWhiteSpace(IdUsuario) Then
         chbVendedor.Checked = False
      End If

      chbCliente.Checked = False
      chbFechas.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbZonaGeografica.Checked = False
      chbCategoria.Checked = False
      chbTipoComprobante.Checked = False
      cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      tsbEliminar.Enabled = False

      cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

      ugDetalle.ClearFilas()

      bscCodigoCliente.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idZonaGeografica = cmbZonaGeografica.ValorSeleccionado(chbZonaGeografica, String.Empty)
      Dim desde = dtpDesde.Valor(chbFechas).IfNull()
      Dim hasta = dtpHasta.Valor(chbFechas).IfNull()
      Dim tipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)
      Dim idCategoria As Integer = cmbCategoria.ValorSeleccionado(chbCategoria, 0I)

      Dim rCtaCte = New Reglas.CuentasCorrientes()
      Dim dtDetalle = rCtaCte.GetMovEliminar(actual.Sucursal.Id,
                                             desde, hasta,
                                             idVendedor, idCliente,
                                             tipoComprobante, idZonaGeografica,
                                             idCategoria, cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos))
      cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos
      ugDetalle.DataSource = dtDetalle
   End Sub

#End Region

End Class