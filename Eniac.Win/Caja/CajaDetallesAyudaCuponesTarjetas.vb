Public Class CajaDetallesAyudaCuponesTarjetas

#Region "Campos"
   Private _publicos As Publicos
   'Private _caja As Entidades.CajaNombre
   'Private _tipoMovimiento As String
   Private _estados As Entidades.TarjetaCupon.Estados()
   Public cajaCupones As Integer
#End Region

   Public Property CuponesSeleccionados As DataTable

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub

#Region "Overrides/Overloads"
   Public Overloads Function ShowDialog(owner As IWin32Window, estados As Entidades.TarjetaCupon.Estados()) As DialogResult
      _estados = estados
      Return ShowDialog(owner)
   End Function
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()
            InicializaCombos()
            RefrecarDatosGrilla()
            CargarGrillaDetalle()
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Filtros"
   Private Sub chbFechaEmision_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEmision.CheckedChanged
      TryCatched(Sub() chbFechaEmision.FiltroCheckedChanged(chbMesCompleto, dtpFechaEmisionDesde, dtpFechaEmisionHasta))
   End Sub
   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpFechaEmisionDesde, dtpFechaEmisionHasta))
   End Sub
   Private Sub chbTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles chbTarjeta.CheckedChanged
      TryCatched(Sub() chbTarjeta.FiltroCheckedChanged(cmbTarjeta))
   End Sub
   Private Sub chbLotes_CheckedChanged(sender As Object, e As EventArgs) Handles chbLotes.CheckedChanged
      TryCatched(Sub() chbLotes.FiltroCheckedChanged(txtLote))
   End Sub
   Private Sub chbNumeroCupon_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroCupon.CheckedChanged
      TryCatched(Sub() chbNumeroCupon.FiltroCheckedChanged(txtNumeroCupon))
   End Sub
   Private Sub chbBanco_CheckedChanged(sender As Object, e As EventArgs) Handles chbBanco.CheckedChanged
      TryCatched(Sub() chbBanco.FiltroCheckedChanged(cmbBancos))
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

#Region "Eventos Buscador Proveedor"
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

#End Region

#Region "Eventos Acciones"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub
#End Region

#Region "Eventos Grilla"
   Private Sub ugCuponesTarjetas_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugCuponesTarjetas.DoubleClickCell
      TryCatched(
      Sub()
         Dim dr = ugCuponesTarjetas.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim dt = ugCuponesTarjetas.DataSource(Of DataTable)
            If Not dt.Any(Function(dr1) dr1.Field(Of Boolean)("Selec")) Then
               dr("Selec") = True
               ugCuponesTarjetas.RowsRefresh(RefreshRow.ReloadData)
               btnAceptar.PerformClick()
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugCuponesTarjetas_CellChange(sender As Object, e As CellEventArgs) Handles ugCuponesTarjetas.CellChange
      TryCatched(
      Sub()
         If e.Cell.Column.Key = "Selec" Then
            ugCuponesTarjetas.UpdateData()
         End If
      End Sub)
   End Sub
   Private Sub ugCuponesTarjetas_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugCuponesTarjetas.AfterCellUpdate
      TryCatched(Sub() CalcularTotal())
   End Sub
#End Region

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugCuponesTarjetas.MarcarDesmarcar(cmbTodos, "Selec"))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(Sub() If ValidaConsultar() Then CargarGrillaDetalle())
   End Sub

#End Region

#Region "Metodos"
   Private Function ValidaConsultar() As Boolean
      Using errBuilder = New Entidades.ErrorBuilder()
         If chbTarjeta.Checked And cmbTarjeta.SelectedIndex = -1 Then
            errBuilder.AddError("ATENCIÓN: Activó filtro de Tarjeta pero no seleccionó un valor.", cmbTarjeta)
         End If
         If chbLotes.Checked AndAlso txtLote.ValorNumericoPorDefecto(0D) <= 0 Then
            errBuilder.AddError("ATENCIÓN: Activó filtro de Lote pero no seleccionó un valor.", txtLote)
         End If
         If chbNumeroCupon.Checked AndAlso txtNumeroCupon.ValorNumericoPorDefecto(0D) <= 0 Then
            errBuilder.AddError("ATENCIÓN: Activó filtro de Número Cupón pero no seleccionó un valor.", txtNumeroCupon)
         End If
         If chbBanco.Checked And cmbBancos.SelectedIndex = -1 Then
            errBuilder.AddError("ATENCIÓN: Activó filtro de Banco pero no seleccionó un valor.", cmbBancos)
         End If
         If chbCliente.Checked And bscCodigoCliente.Selecciono Then
            errBuilder.AddError("ATENCIÓN: Activó filtro de Cliente pero no seleccionó un valor.", bscCodigoCliente)
         End If
         If chbProveedor.Checked And bscCodigoProveedor.Selecciono Then
            errBuilder.AddError("ATENCIÓN: Activó filtro de Proveedor pero no seleccionó un valor.", bscCodigoProveedor)
         End If
         If errBuilder.AnyError Then
            ShowMessage(errBuilder.ErrorToString())
            Return False
         End If
         If errBuilder.AnyWarning Then
            Dim stb = New StringBuilder(errBuilder.WarningToString())
            stb.AppendLine()
            stb.AppendFormat("¿Desea continuar?")
            Return ShowPregunta(stb.ToString()) = DialogResult.Yes
         End If
      End Using
      Return True
   End Function
   Private Sub RefrecarDatosGrilla()
      chbFechaEmision.Checked = False
      chbTarjeta.Checked = False
      chbBanco.Checked = False
      chbLotes.Checked = False
      chbNumeroCupon.Checked = False
      chbCliente.Checked = False
      chbProveedor.Checked = False
      cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos
   End Sub
   Private Sub CargarGrillaDetalle()
      Dim rCupones = New Reglas.TarjetasCupones()
      Dim dtDetalle = rCupones.GetCajaDetallesAyudaCuponesTarjetas(_estados, dtpFechaEmisionDesde.Valor(chbFechaEmision), dtpFechaEmisionHasta.Valor(chbFechaEmision),
                                                                   cmbTarjeta.ValorSeleccionado(chbTarjeta, 0I), cmbBancos.ValorSeleccionado(chbBanco, 0I),
                                                                   txtLote.ValorSeleccionado(chbLotes, 0I), txtNumeroCupon.ValorSeleccionado(chbNumeroCupon, 0I),
                                                                   If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L),
                                                                   If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L), cajaCupones)

      Dim tit = GetColumnasVisiblesGrilla(ugCuponesTarjetas)
      ugCuponesTarjetas.DataSource = dtDetalle
      AjustarColumnasGrilla(ugCuponesTarjetas, tit)

      ugCuponesTarjetas.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString()})
      ugCuponesTarjetas.AgregarTotalesSuma({Entidades.TarjetaCupon.Columnas.Monto.ToString()})
   End Sub

   Private Sub Aceptar()
      ugCuponesTarjetas.UpdateData()

      Dim colCuponesSeleccionados = ugCuponesTarjetas.DataSource(Of DataTable).Where(Function(dr) dr.Field(Of Boolean)("Selec"))
      If ValidaAceptar(colCuponesSeleccionados) Then
         CuponesSeleccionados = colCuponesSeleccionados.CopyToDataTable()

         Close(DialogResult.OK)
      End If
   End Sub

   Private Function ValidaAceptar(colCuponesSeleccionados As IEnumerable(Of DataRow)) As Boolean
      Using errBuilder = New Entidades.ErrorBuilder()
         If Not colCuponesSeleccionados.AnySecure() Then
            errBuilder.AddError("Debe seleccionar al menos un cupón de tarjeta")
         End If

         If colCuponesSeleccionados.SumSecure(Function(dr) dr.Field(Of Decimal)(Entidades.TarjetaCupon.Columnas.Monto.ToString())).IfNull() = 0 Then
            errBuilder.AddWarning("El importe total de cupones es cero.")
         End If

         If errBuilder.AnyError Then
            ShowMessage(errBuilder.ErrorToString())
            Return False
         End If
         If errBuilder.AnyWarning Then
            If ShowPregunta(errBuilder.WarningToString("¿Desea continuar?")) = DialogResult.No Then
               Return False
            End If
         End If
         Return True
      End Using
   End Function

   Public Sub InicializaCombos()
      _publicos.CargaComboTarjetasE(cmbTarjeta, activas:=True)
      _publicos.CargaComboBancosE(cmbBancos)
      _publicos.CargaComboDesdeEnum(cmbTodos, Reglas.Publicos.TodosEnum.MararTodos)
   End Sub

   Private Sub CalcularTotal()
      Dim importeTotal = ugCuponesTarjetas.DataSource(Of DataTable).AsEnumerable().
                                           Where(Function(dr) dr.Field(Of Boolean)("Selec")).
                                           SumSecure(Function(dr) dr.Field(Of Decimal)(Entidades.TarjetaCupon.Columnas.Monto.ToString())).IfNull()
      txtImporteTotalSeleccionado.SetValor(importeTotal)
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         bscProveedor.Selecciono = True
         bscCodigoProveedor.Selecciono = True

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
         bscCliente.Selecciono = True
         bscCodigoCliente.Selecciono = True

         btnConsultar.Focus()
      End If
   End Sub

#End Region

End Class