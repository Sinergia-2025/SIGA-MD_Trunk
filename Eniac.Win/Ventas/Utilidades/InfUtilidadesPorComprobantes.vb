Public Class InfUtilidadesPorComprobantes

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "VENTAS")
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)

         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         _publicos.CargaComboUsuarios(cmbUsuario)

         _publicos.CargaComboDesdeEnum(cmbGrabanLibro, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbAfectaCaja, Entidades.Publicos.SiNoTodos.SI)

         _publicos.CargaComboSemaforoVentasUtilidades(cmbPorcUtilidadDesde)
         _publicos.CargaComboSemaforoVentasUtilidades(cmbPorcUtilidadHasta)

         _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))

         '-.PE-31609.-
         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         RefrescarDatosGrilla()
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
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(
      Sub()
         PreferenciasCargar(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
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
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub
   Private Sub chbUtilidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbUtilidad.CheckedChanged
      TryCatched(Sub() chbUtilidad.FiltroCheckedChanged(cmbPorcUtilidadHasta))
      TryCatched(Sub() chbUtilidad.FiltroCheckedChanged(cmbPorcUtilidadDesde))
   End Sub
   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
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
         Dim codigoCliente = If(chbCliente.Checked, bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L), -1L)
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

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
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

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub
   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      Try
         With ugDetalle.DisplayLayout.Bands(0)
            If .Columns.Exists("Costo") Then
               .Columns("Costo").Hidden = chbConIVA.Checked
               .Columns("SubTotal").Hidden = chbConIVA.Checked
               .Columns("Utilidad").Hidden = chbConIVA.Checked
               .Columns("PorcUtilidad").Hidden = chbConIVA.Checked

               .Columns("CostoConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("TotalConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("UtilidadConImpuestos").Hidden = Not chbConIVA.Checked
               .Columns("PorcUtilidadCI").Hidden = Not chbConIVA.Checked
            End If
         End With
      Catch ex As Exception
         ShowError(ex)
      End Try
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
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbTipoComprobante.Checked = False

      chbCliente.Checked = False
      chbVendedor.Checked = False
      cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual


      cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbAfectaCaja.SelectedValue = Entidades.Publicos.SiNoTodos.SI

      chbFormaPago.Checked = False
      chbUsuario.Checked = False

      chbUtilidad.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      cmbSucursal.Refrescar()

      dtpDesde.Focus()

      chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)

      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim origenVendedor = cmbOrigenVendedor.ValorSeleccionado(Of Entidades.OrigenFK)

      Dim idFormaDePago = cmbFormaPago.ValorSeleccionado(chbFormaPago, 0I)

      Dim idUsuario = cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty)

      Dim porcUtilidadDesde = If(chbUtilidad.Checked, cmbPorcUtilidadDesde.Text.ValorNumericoPorDefecto(0D), -1D)
      Dim porcUtilidadHasta = If(chbUtilidad.Checked, cmbPorcUtilidadHasta.Text.ValorNumericoPorDefecto(0D), -1D)

      Dim rVenta = New Reglas.Ventas()
      Dim dtDetalle = rVenta.GetPorRangoFechas(agregarSelec:=False, agregarVer:=False,
                                               cmbSucursal.GetSucursales(),
                                               dtpDesde.Value, dtpHasta.Value,
                                               idVendedor, origenVendedor,
                                               cmbGrabanLibro.ValorSeleccionado(Entidades.Publicos.SiNoTodos.TODOS),
                                               idCliente,
                                               cmbAfectaCaja.ValorSeleccionado(Entidades.Publicos.SiNoTodos.TODOS),
                                               idTipoComprobante, numeroComprobante:=0,
                                               idFormaDePago, idUsuario,
                                               idEstadoComprobante:="NO ANULADO",
                                               porcUtilidadDesde, porcUtilidadHasta,
                                               mercDespachada:="TODOS", comercial:="SI",
                                               idCategoria:=0, numeroReparto:=0, ctaCte:=False,
                                               exclurirComprobanteFiscal:=False, exclurirComprobanteElectronico:=False,
                                               letra:=String.Empty, emisor:=Nothing, ncomprobantedesde:=Nothing, ncomprobantehasta:=Nothing)
      'Dim dt = CrearDT()
      'For Each dr As DataRow In dtDetalle.Rows
      '   Dim drCl = dt.NewRow()
      '   drCl("IdSucursal") = dr("IdSucursal") '-.PE-31609.-
      '   drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
      '   drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
      '   drCl("TipoComprobante") = dr("DescripcionAbrev").ToString()
      '   drCl("Letra") = dr("Letra").ToString()
      '   drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
      '   drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
      '   'drCl("TipoDocVendedor") = dr("TipoDocVendedor").ToString()
      '   'drCl("NroDocVendedor") = Long.Parse(dr("NroDocVendedor").ToString())
      '   drCl("NombreVendedor") = dr("NombreVendedor").ToString()
      '   drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
      '   drCl("NombreCliente") = dr("NombreCliente").ToString()
      '   drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
      '   drCl("FormaDePago") = dr("FormaDePago").ToString()
      '   drCl("Costo") = Decimal.Parse(dr("Costo").ToString())
      '   drCl("Subtotal") = Decimal.Parse(dr("Subtotal").ToString())
      '   drCl("Utilidad") = Decimal.Parse(dr("Utilidad").ToString())
      '   drCl("PorcUtilidad") = Decimal.Round(Decimal.Parse(dr("Utilidad").ToString()) / Decimal.Parse(dr("Subtotal").ToString()) * 100, 2)

      '   drCl("CostoConImpuestos") = Decimal.Parse(dr("CostoConImpuestos").ToString())
      '   drCl("TotalConImpuestos") = Decimal.Parse(dr("TotalConImpuestos").ToString())
      '   drCl("UtilidadConImpuestos") = Decimal.Parse(dr("UtilidadConImpuestos").ToString())
      '   If Decimal.Parse(dr("TotalConImpuestos").ToString()) <> 0 Then
      '      drCl("PorcUtilidadCI") = Decimal.Round(Decimal.Parse(dr("UtilidadConImpuestos").ToString()) / Decimal.Parse(dr("TotalConImpuestos").ToString()) * 100, 2)
      '   End If

      '   drCl("Usuario") = dr("Usuario").ToString()

      '   dt.Rows.Add(drCl)
      'Next

      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)

      ugDetalle.AgregarTotalesSuma({"Costo", "Subtotal", "Utilidad", "CostoConImpuestos", "TotalConImpuestos", "UtilidadConImpuestos"})
      ugDetalle.AgregarTotalCustomColumna("PorcUtilidad", New Ayudante.CustomSummaries.SummaryMargen("Utilidad", "SubTotal", "PorcUtilidad"))
      ugDetalle.AgregarTotalCustomColumna("PorcUtilidadCI", New Ayudante.CustomSummaries.SummaryMargen("UtilidadConImpuestos", "TotalConImpuestos", "PorcUtilidadCI"))

   End Sub

   'Private Function CrearDT() As DataTable
   '   Dim dtTemp = New DataTable()
   '   With dtTemp
   '      .Columns.Add("IdSucursal", GetType(Integer)) '-.PE-31609.-
   '      .Columns.Add("Fecha", GetType(Date))
   '      .Columns.Add("IdTipoComprobante", GetType(String))
   '      .Columns.Add("TipoComprobante", GetType(String))
   '      .Columns.Add("Letra", GetType(String))
   '      .Columns.Add("CentroEmisor", GetType(Integer))
   '      .Columns.Add("NumeroComprobante", GetType(Long))
   '      .Columns.Add("NombreVendedor", GetType(String))
   '      .Columns.Add("IdCliente", GetType(Long))
   '      .Columns.Add("NombreCliente", GetType(String))
   '      .Columns.Add("NombreCategoriaFiscal", GetType(String))
   '      .Columns.Add("FormaDePago", GetType(String))
   '      .Columns.Add("Costo", GetType(Decimal))
   '      .Columns.Add("Subtotal", GetType(Decimal))
   '      .Columns.Add("Utilidad", GetType(Decimal))
   '      .Columns.Add("PorcUtilidad", GetType(Decimal))
   '      .Columns.Add("TotalConImpuestos", GetType(Decimal))
   '      .Columns.Add("UtilidadConImpuestos", GetType(Decimal))
   '      .Columns.Add("PorcUtilidadCI", GetType(Decimal))
   '      .Columns.Add("CostoConImpuestos", GetType(Decimal))
   '      .Columns.Add("Usuario", GetType(String))
   '   End With
   '   Return dtTemp
   'End Function
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)
         .AppendFormat(" - Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)
         If chbTipoComprobante.Checked Then
            .AppendFormat(" - Tipo Comprobante: {0}", cmbTiposComprobantes.Text)
         End If
         If chbTipoComprobante.Checked Then
            .AppendFormat(" - Tipo Comprobante: {0}", cmbTiposComprobantes.Text)
         End If
         If chbUtilidad.Checked Then
            .AppendFormat(" - Utilidad: desde {0} hasta {1}", cmbPorcUtilidadDesde.Text, cmbPorcUtilidadHasta.Text)
         End If
         If chbCliente.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text.Trim(), bscCliente.Text.Trim())
         End If
         If chbFormaPago.Checked Then
            .AppendFormat(" - Forma de Pago: {0}", cmbFormaPago.Text)
         End If
         If cmbGrabanLibro.ValorSeleccionado(Entidades.Publicos.SiNoTodos.TODOS) <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat(" - Graba Libro: {0}", cmbGrabanLibro.Text)
         End If
         If cmbAfectaCaja.ValorSeleccionado(Entidades.Publicos.SiNoTodos.TODOS) <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat(" - Afecta Caja: {0}", cmbAfectaCaja.Text)
         End If
         If chbVendedor.Checked Then
            Dim idVendedor = cmbVendedor.ValorSeleccionado(Of Integer)
            .AppendFormat(" - Vendedor: {0} - {1} / {2}", idVendedor, cmbVendedor.Text, cmbOrigenVendedor.Text)
         End If
         If chbUsuario.Checked Then
            .AppendFormat(" - Usuario: {0}", cmbUsuario.Text)
         End If
         .AppendFormat(" - Precios Con IVA: {0}", If(chbConIVA.Checked, "SI", "NO"))
      End With
      Return filtro.ToString()
   End Function

#End Region

End Class