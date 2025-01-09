Public Class EliminarComprobantes

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "VENTAS")
            _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))

            ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})

            RefrescarDatosGrilla()
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
   Private Sub tsbEliminarComprobantes_Click(sender As Object, e As EventArgs) Handles tsbEliminarComprobantes.Click
      TryCatched(Sub() EliminarComprobantes())
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub
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

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, "Selec"))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex < 0 Then
               ShowMessage("ATENCION: NO seleccionó un Tipo de Comprobante aunque activó ese Filtro.")
               cmbTiposComprobantes.Focus()
               Exit Sub
            End If
            If chbCliente.Checked And Not IsNumeric(bscCodigoCliente.Tag) Then
               ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
               bscCodigoCliente.Focus()
               Exit Sub
            End If

            CargaGrillaDetalle()

            cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

            If ugDetalle.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("No hay registros que cumplan con la selección !!!")
            End If
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
         bscCliente.Selecciono = True
         bscCodigoCliente.Selecciono = True

         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbTipoComprobante.Checked = False
      chbCliente.Checked = False
      chbOrdenInverso.Checked = True

      ugDetalle.ClearFilas()

      cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

      dtpDesde.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim tipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)

      Dim rVenta = New Reglas.Ventas()
      Dim dtDetalle = rVenta.GetParaEliminar(actual.Sucursal.Id, dtpDesde.Value.Date, dtpHasta.Value.UltimoSegundoDelDia(),
                                             idCliente, tipoComprobante, If(chbOrdenInverso.Checked, "DESC", "ASC"))
      ugDetalle.DataSource = dtDetalle

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub EliminarComprobantes()

      ugDetalle.UpdateData()

      'grabo todas los comprobantes marcados
      Dim _cache = New Reglas.BusquedasCacheadas()
      Dim _comprobantes = New List(Of Entidades.Venta)()
      Dim dtComprobantes = DirectCast(ugDetalle.DataSource, DataTable)

      For Each dr In dtComprobantes.AsEnumerable().Where(Function(dr1) dr1.Field(Of Boolean)("Selec"))
         Dim oComprobante = New Entidades.Venta()

         With oComprobante
            .IdSucursal = actual.Sucursal.Id
            .TipoComprobante = _cache.BuscaTipoComprobante(dr.Field(Of String)("IdTipoComprobante"))
            .LetraComprobante = dr.Field(Of String)("Letra")
            .CentroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
            .NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")
            .Fecha = dr.Field(Of Date)("Fecha")
         End With

         _comprobantes.Add(oComprobante)
      Next

      If _comprobantes.Count > 0 Then
         If ShowPregunta(String.Format("¿ Está Seguro de Eliminar {0} Comprobante(s) Seleccionado(s) ? ", _comprobantes.Count),
                         MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim regla = New Reglas.Ventas()
            regla.EliminarComprobantes(_comprobantes)

            ShowMessage(String.Format("Se Eliminó Exitosamente {0} Comprobante(s) !!", _comprobantes.Count))

            btnConsultar.PerformClick()
         End If
      Else
         ShowMessage("No ha seleccionado Comprobantes a eliminar")
      End If
   End Sub

#End Region

End Class