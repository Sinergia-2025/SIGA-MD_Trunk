Public Class RequerimientosComprasABM
   Private _publicos As Publicos
   Private _tipoTipoComprobante As String = Entidades.TipoComprobante.Tipos.REQCOMPRAS.ToString()

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos)
      TryCatched(Sub() tsbBorrar.Visible = False)
      TryCatched(Sub() InicializaCombos())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New RequerimientosComprasDetalle(DirectCast(GetEntidad(), Entidades.RequerimientoCompra))
      Else
         Return New RequerimientosComprasDetalle(New Entidades.RequerimientoCompra())
      End If
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.RequerimientosCompras()
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return DirectCast(rg, Reglas.RequerimientosCompras).GetAll(PreparaFiltrosParaBusqueda())
   End Function
   Protected Overrides Function Buscar(rg As Reglas.Base, args As Entidades.Buscar) As DataTable
      Return DirectCast(rg, Reglas.RequerimientosCompras).Buscar(args, PreparaFiltrosParaBusqueda())
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      Dim rReq = New Reglas.RequerimientosCompras()
      Return rReq.GetUno(dr.Field(Of Long)(Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString()))
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I

         .Columns(Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString()).FormatearColumna("Id Req.", pos, 50, HAlign.Right, True)
         .Columns(Entidades.RequerimientoCompra.Columnas.IdSucursal.ToString()).FormatearColumna("S.", pos, 20, HAlign.Right, True)
         .Columns(Entidades.RequerimientoCompra.Columnas.IdTipoComprobante.ToString()).FormatearColumna("Id Tipo Comprobante", pos, 100, , True)
         .Columns("DescripcionTipoComprobante").FormatearColumna("Tipo Comprobante", pos, 120)
         .Columns(Entidades.RequerimientoCompra.Columnas.Letra.ToString()).FormatearColumna("L.", pos, 20)
         .Columns(Entidades.RequerimientoCompra.Columnas.CentroEmisor.ToString()).FormatearColumna("Emisor", pos, 45, HAlign.Right)
         .Columns(Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString()).FormatearColumna("Requerimiento", pos, 100, HAlign.Right)
         .Columns(Entidades.RequerimientoCompra.Columnas.Fecha.ToString()).FormatearColumna("Fecha/Hora", pos, 100, HAlign.Center, True, "dd/MM/yyyy HH:mm")
         .Columns("Fecha_Fecha").FormatearColumna("Fecha", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("Fecha_Hora").FormatearColumna("Hora", pos, 60, HAlign.Center, , "HH:mm:ss")
         .Columns(Entidades.RequerimientoCompra.Columnas.FechaAlta.ToString()).FormatearColumna("Fecha/Hora Alta", pos, 100, HAlign.Center, True, "dd/MM/yyyy HH:mm")
         .Columns("FechaAlta_Fecha").FormatearColumna("Fecha Alta", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("FechaAlta_Hora").FormatearColumna("Hora Alta", pos, 60, HAlign.Center, , "HH:mm:ss")
         .Columns(Entidades.RequerimientoCompra.Columnas.IdUsuarioAlta.ToString()).FormatearColumna("Usuario Alta", pos, 80)
         .Columns(Entidades.RequerimientoCompra.Columnas.Observacion.ToString()).FormatearColumna("Observación", pos, 300)

         dgvDatos.AgregarFiltroEnLinea({Entidades.RequerimientoCompra.Columnas.Observacion.ToString()})

      End With
   End Sub

   Protected Overrides Sub OnBeforeRefreshGrid(e As CancelableEventArgs)
      MyBase.OnBeforeRefreshGrid(e)
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
#End Region

#Region "Eventos"
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(Sub() RefreshGrid())
   End Sub

#Region "Eventos Filtros"
   Private Sub chbUsuarioAlta_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuarioAlta.CheckedChanged
      TryCatched(Sub() chbUsuarioAlta.FiltroCheckedChanged(cmbUsuarioAlta))
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub
   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(Sub() chbNumero.FiltroCheckedChanged(txtNumero, "0", String.Empty))
   End Sub
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpFechaDesde, dtpFechaHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChangedMesCompleto(dtpFechaDesde, dtpFechaHasta))
   End Sub

   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged
      TryCatched(Sub() chbFechaEntrega.FiltroCheckedChanged(chkMesCompletoEntrega, dtpFechaEntregaDesde, dtpFechaEntregaHasta))
   End Sub
   Private Sub chkMesCompletoEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoEntrega.CheckedChanged
      TryCatched(Sub() chkMesCompletoEntrega.FiltroCheckedChangedMesCompleto(dtpFechaEntregaDesde, dtpFechaEntregaHasta))
   End Sub
#End Region

#End Region

#Region "Metodos Privados"

   Private Sub InicializaCombos()
      _publicos.CargaComboUsuariosActivos(cmbUsuarioAlta)
      _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, MiraPC:=True, _tipoTipoComprobante, UsaFacturacion:=True)
   End Sub

   Private Sub RefrescarDatosGrilla()
      'Resetear filtros
      chbUsuarioAlta.Checked = False
      chbTipoComprobante.Checked = False
      chbNumero.Checked = False
      chkMesCompleto.Checked = False
      chbFecha.Checked = False
      chkMesCompletoEntrega.Checked = False
      chbFechaEntrega.Checked = False
   End Sub

   Private Function PreparaFiltrosParaBusqueda() As Entidades.Filtros.RequerimientosComprasABMFiltros
      Dim f = New Entidades.Filtros.RequerimientosComprasABMFiltros

      If chbUsuarioAlta.Checked Then
         f.IdUsuarioAlta = cmbUsuarioAlta.ValorSeleccionado(Of String)
      End If
      If chbTipoComprobante.Checked Then
         f.IdTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(Of String)
      End If
      If chbNumero.Checked Then
         f.NumeroRequerimiento = txtNumero.ValorNumericoPorDefecto(0L)
      End If
      If chbFecha.Checked Then
         f.FechaDesde = dtpFechaDesde.Value
         f.FechaHasta = dtpFechaHasta.Value
      End If
      If chbFechaEntrega.Checked Then
         f.FechaEntregaDesde = dtpFechaEntregaDesde.Value
         f.FechaEntregaHasta = dtpFechaEntregaHasta.Value
      End If

      Return f
   End Function

#End Region

End Class