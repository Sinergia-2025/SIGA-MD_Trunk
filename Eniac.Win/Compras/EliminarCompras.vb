Public Class EliminarCompras

#Region "Campos"
   Private _publicos As Publicos
   Private _Sucursal As Integer = 0
   Private _idCaja As Integer = 0
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Reglas.Publicos.ComprasIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = False
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, "COMPRAS")
         cmbTiposComprobantes.SelectedIndex = -1

         _Sucursal = actual.Sucursal.Id

         'carga las cajas.
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _publicos.CargaComboCajas(cmbCajas, _Sucursal, miraUsuario:=True, miraPC:=Not Reglas.Publicos.ComprasIgnorarPCdeCaja, cajasModificables:=False)
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

   Private Sub tsbEliminar_Click(sender As Object, e As EventArgs) Handles tsbEliminar.Click
      TryCatched(Sub() EliminarCompra())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
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
#End Region


   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProveedor.Checked And bscCodigoProveedor.Text.Length = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If e.Cell.Column.Key = "Ver" Then
               Dim rCompras = New Reglas.Compras()
               Dim compra = rCompras.GetUna(actual.Sucursal.Id,
                                            dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                                            dr.Field(Of Integer)("CentroEmisor").ToShort(), dr.Field(Of Long)("NumeroComprobante"),
                                            dr.Field(Of Long)("IdProveedor"))
               Dim oImpr = New ImpresionCompra(compra)
               oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)
            Else
               If e.Cell.Column.Key = "CantidadInvocados" Then
                  If dr.Field(Of Integer?)("CantidadInvocados").IfNull() > 0 Then
                     Using oComprobantesInvocados = New FacturablesInvocadosCom(dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                                                                                dr.Field(Of Integer)("CentroEmisor").ToShort(), dr.Field(Of Long)("NumeroComprobante"),
                                                                                dr.Field(Of Long)("IdProveedor"))

                        oComprobantesInvocados.ShowDialog()
                     End Using
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

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now
      chbProveedor.Checked = False
      chbTipoComprobante.Checked = False

      ugDetalle.ClearFilas()

      _publicos.CargaComboCajas(cmbCajas, _Sucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), -0L)
      Dim tipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)

      Dim rCompra As Reglas.Compras = New Reglas.Compras()
      Dim dtDetalle = rCompra.GetPorRangoFechas({actual.Sucursal},
                                                actual.Sucursal.IdEmpresa, 0,
                                                dtpDesde.Value, dtpHasta.Value,
                                                idProveedor,
                                                IdComprador:=0,
                                                grabaLibro:="TODOS", afectaCaja:="TODOS", esComercial:="TODOS",
                                                tipoComprobante:=tipoComprobante,
                                                numeroComprobante:=0, idFormasPago:=0, idRubro:=0, estado:="", idCategoria:=0, idUsuario:="", idCentroCosto:=0,
                                                idMoneda:=Entidades.Moneda.Peso, tipoConversion:=Entidades.Moneda_TipoConversion.Comprobante, cotizDolar:=0)

      Dim dt = ConsultarCompras.CrearDT()

      ugDetalle.DataSource = ConsultarCompras.CopiarDt(dtDetalle, dt)
      ConsultarCompras.FormatearGrilla(ugDetalle)
   End Sub

   Private Sub EliminarCompra()

      Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
      If dr Is Nothing Then Exit Sub

      If cmbCajas.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar una caja!!! Por favor reintente.")
         Exit Sub
      End If

      '# Datos del comprobante
      Dim idTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
      Dim letra = dr.Field(Of String)("Letra")
      Dim centroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
      Dim numeroComprobante = dr.Field(Of Long)("NumeroComprobante")
      Dim idProveedor = dr.Field(Of Long)("IdProveedor")

      Dim rCompras = GetReglaCompras()
      Dim compra = rCompras.GetUna(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)

      '# Valido que el comprobante no esté FACTURADO
      Dim comprobante = String.Format("{0} {1} {2:0000}-{3:00000000} Proveedor: {4},",
                                      idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)

      If compra.IdEstadoComprobante = "FACTURADO" Then
         '# Datos del comprobante facturador
         Dim comprobanteFact = String.Format("{0} {1} {2:0000} {3:00000000} Proveedor: {4}",
                                             compra.IdTipoComprobanteFact, compra.LetraFact, compra.CentroEmisorFact, compra.NumeroComprobanteFact, compra.IdProveedorFact)
         ShowMessage(String.Format("ATENCION: El comprobante {0} se encuentra FACTURADO por el comprobante {1} y no puede anularse.",
                                   comprobante, comprobanteFact))
         Exit Sub
      End If

      'If Compra.IdCaja <> Integer.Parse(Me.cmbCajas.SelectedValue.ToString()) And (Compra.ImportePesos <> Compra.ImporteTotal) Then
      '   MessageBox.Show("ATENCION: La compra tiene Moneda distinta de Pesos y eligio una Caja distinta!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '   Exit Sub
      'Else
      compra.IdCaja = cmbCajas.ValorSeleccionado(0I)

      If ShowPregunta("¿ Está Seguro de Eliminar la Compra seleccionada ? ") <> DialogResult.Yes Then
         Exit Sub
      End If

      rCompras.EliminarCompra(compra)

      ShowMessage("¡¡¡ Comprobante Eliminado Exitosamente !!!")
      'End If
      btnConsultar.PerformClick()
   End Sub

   Protected Overridable Function GetReglaCompras() As Reglas.Compras
      Return New Reglas.Compras()
   End Function
   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro
         filtro.AppendFormat("Fechas: {0:dd/MM/yyyy} Hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         If chbTipoComprobante.Checked Then
            filtro.AppendFormat(" - Tipo de Comprobante: {0}", cmbTiposComprobantes.Text)
         End If
         If chbProveedor.Checked Then
            filtro.AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text, bscProveedor.Text)
         End If
         If cmbCajas.SelectedIndex > -1 Then
            filtro.AppendFormat(" - Cajas: {0}", cmbCajas.Text)
         End If
      End With
      Return filtro.ToString()
   End Function
#End Region

End Class