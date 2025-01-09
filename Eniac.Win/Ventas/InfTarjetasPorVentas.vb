Public Class InfTarjetasPorVentas

#Region "Campos"

   Private _publicos As Publicos
   Private _idActualCuentaBancaria As Integer = 0

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=False, cajasModificables:=True)
         cmbCajas.SelectedIndex = -1

         _publicos.CargaComboBancos(cmbBanco)

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "VENTAS")
         cmbTiposComprobantes.SelectedIndex = -1
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbGrabanLibro, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboUsuarios(cmbUsuario)

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreBanco"})
         ugDetalle.AgregarTotalesSuma({"Monto"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)
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
      TryCatched(Sub() ugDetalle.Imprimir("", CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
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
   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      TryCatched(Sub() chbCaja.FiltroCheckedChanged(cmbCajas))
   End Sub
   Private Sub chbBanco_CheckedChanged(sender As Object, e As EventArgs) Handles chbBanco.CheckedChanged
      TryCatched(Sub() chbBanco.FiltroCheckedChanged(cmbBanco))
   End Sub
#Region "Eventos Buscador Cliente"
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
   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(Sub() chbNumero.FiltroCheckedChanged(txtNumero))
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
#Region "Eventos Buscador Cuenta Bancaria"
   Private Sub chbCuentaBancaria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCuentaBancaria.CheckedChanged
      TryCatched(Sub() chbCuentaBancaria.FiltroCheckedChanged(usaPermitido:=True, bscCuentaBancaria))
   End Sub
   Private Sub bscCuentaBancaria_BuscadorClick() Handles bscCuentaBancaria.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCuentasBancarias(bscCuentaBancaria)
         bscCuentaBancaria.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancaria.Text.Trim())
      End Sub)
   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancaria.BuscadorSeleccion
      TryCatched(
      Sub()
         If bscCuentaBancaria.FilaDevuelta IsNot Nothing Then
            bscCuentaBancaria.Text = bscCuentaBancaria.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            _IdActualCuentaBancaria = Integer.Parse(bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString())

            bscCuentaBancaria.Permitido = False
         End If
      End Sub)
   End Sub
#End Region
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbCaja.Checked And cmbCajas.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Caja aunque activó ese Filtro")
            cmbCajas.Focus()
            Exit Sub
         End If

         If chbBanco.Checked And cmbBanco.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Banco aunque activó ese Filtro")
            cmbBanco.Focus()
            Exit Sub
         End If

         'PE-39843
         'If chbNumero.Checked And txtNumero.ValorNumericoPorDefecto(0L) = 0 Then
         '   ShowMessage("ATENCION: NO seleccionó un Numero aunque activó ese Filtro")
         '   txtNumero.Focus()
         '   Exit Sub
         'End If

         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
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
      chbMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbCaja.Checked = False
      chbTipoComprobante.Checked = False
      cmbGrabanLibro.SelectedIndex = 0
      chbUsuario.Checked = False
      chbNumero.Checked = False
      chbVendedor.Checked = False
      chbBanco.Checked = False

      chbCliente.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      btnConsultar.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idCaja = cmbCajas.ValorSeleccionado(chbCaja, 0I)
      Dim idBanco = cmbBanco.ValorSeleccionado(chbBanco, 0I)
      Dim idTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbCliente, String.Empty)
      Dim numeroCupon = txtNumero.ValorSeleccionado(chbNumero, 0L)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idCuentaBancaria = _IdActualCuentaBancaria
      Dim idUsuario = cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)

      Dim rTarjetas = New Reglas.Ventas()
      Dim dtDetalle = rTarjetas.GetTarjetasVentas(actual.Sucursal.Id, dtpDesde.Value, dtpHasta.Value,
                                                  numeroCupon,
                                                  idCaja, idBanco, idCuentaBancaria,
                                                  idCliente, idVendedor,
                                                  idTipoComprobante, cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                  idUsuario)
      ugDetalle.DataSource = dtDetalle
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)

         If cmbCajas.SelectedIndex >= 0 Then
            .AppendFormat(" - Caja: {0}", cmbCajas.Text)
         End If
         If cmbBanco.SelectedIndex >= 0 Then
            .AppendFormat(" - Banco: {0}", cmbBanco.Text)
         End If
         If bscCodigoCliente.Text.Length > 0 And bscCliente.Text.Length > 0 Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbNumero.Checked Then
            .AppendFormat(" - Cupón: {0}", txtNumero.Text)
         End If
         If cmbTiposComprobantes.SelectedIndex >= 0 Then
            .AppendFormat(" - Tipo Comprobante: {0}", cmbTiposComprobantes.Text)
         End If
         If cmbGrabanLibro.SelectedIndex >= 0 Then
            .AppendFormat(" - Graban Libro: {0}", cmbGrabanLibro.Text)
         End If
         If cmbVendedor.SelectedIndex >= 0 Then
            .AppendFormat(" - Vendedor: {0}", cmbVendedor.Text)
         End If

         If bscCuentaBancaria.Text.Length > 0 Then
            .AppendFormat(" - Cta. Banco: {0}", bscCuentaBancaria.Text)
         End If
         If cmbUsuario.SelectedIndex >= 0 Then
            .AppendFormat(" - Usuario: {0}", cmbUsuario.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#End Region
End Class