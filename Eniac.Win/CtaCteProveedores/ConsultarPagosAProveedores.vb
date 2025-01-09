Public Class ConsultarPagosAProveedores
   Implements IConParametros

#Region "Campos"
   Private _publicos As Publicos
   Private _modalidadPantalla As Entidades.ModalidadPantalla = Entidades.ModalidadPantalla.Consultar
   Private _tit As Dictionary(Of String, String)
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

         _publicos.CargaComboCategoriasProveedores(cmbCategoria)
         _publicos.CargaComboUsuarios(cmbUsuario)
         _publicos.CargaComboTiposComprobantesCtaCteProveedoresPag(cmbTiposComprobantes)

         _publicos.CargaComboCajas(cmbCaja, actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=False, cajasModificables:=False)
            cmbCaja.SelectedIndex = -1


            cmbEstado.Items.Insert(0, "NORMAL")
            cmbEstado.Items.Insert(1, "ANULADO")
            cmbEstado.SelectedIndex = -1

            With cboLetra
               .DisplayMember = "LetraFiscal"
               .ValueMember = "LetraFiscal"
               .DataSource = New Reglas.ComprasNumeros().GetLetrasFiscales()
               .SelectedIndex = -1
            End With

            With cmbEmisor
               .DisplayMember = "CentroEmisor"
               .ValueMember = "CentroEmisor"
               .DataSource = New Reglas.ComprasNumeros().GetCentrosEmisores()
               .SelectedIndex = -1
            End With

         ugDetalle.AgregarFiltroEnLinea({"NombreProveedor", "Observacion"}, {"Ver", "VerEstandar", "Imprimir"})
            ugDetalle.AgregarTotalesSuma({"ImportePesos", "ImporteDolares", "ImporteTickets", "ImporteCheques", "ImporteTarjetas", "ImporteTransfBancaria", "ImporteRetenciones", "ImporteTotal"})
            '  Me.CargarColumnasASumar()

            If Not Reglas.Publicos.TieneModuloContabilidad Then
               ugDetalle.DisplayLayout.Bands(0).Columns("IdPlanCuenta").Hidden = True
               ugDetalle.DisplayLayout.Bands(0).Columns("IdAsiento").Hidden = True
            End If

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            If _modalidadPantalla = Entidades.ModalidadPantalla.Modificar Then
               tsbModificar.Visible = True
               Text = "Modificar Recibo de Pagos a Proveedores"
            End If

            PreferenciasLeer(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
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
   Private Sub tsbImprimirPreDiseñado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPreDiseñado.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count() = 0 Then Exit Sub
         Dim dt = ugDetalle.DataSource(Of DataTable)
         Dim parm = New ReportParameterCollection(CargarFiltrosImpresion())

         Dim frmImprime = New VisorReportes("Eniac.Win.ConsultarPagosAProveedores.rdlc", "SistemaDataSet_DetallePagosAProveedores", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         If chbProveedor.Checked Then
            If bscCodigoProveedor.Selecciono Then
               If Not String.IsNullOrWhiteSpace(bscCodigoProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                  frmImprime.Destinatarios = bscCodigoProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
               End If
            ElseIf bscProveedor.Selecciono Then
               If Not String.IsNullOrWhiteSpace(bscProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                  frmImprime.Destinatarios = bscProveedor.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
               End If
            End If
         End If
         frmImprime.Show()
      End Sub)
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
   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      TryCatched(Sub() chbLetra.FiltroCheckedChanged(cboLetra))
   End Sub
   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      TryCatched(Sub() chbEmisor.FiltroCheckedChanged(cmbEmisor))
   End Sub
   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(Sub() chbNumero.FiltroCheckedChanged(txtNumero))
   End Sub
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      TryCatched(Sub() chbEstado.FiltroCheckedChanged(cmbEstado))
   End Sub
   Private Sub chbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbCaja.CheckedChanged
      TryCatched(Sub() chbCaja.FiltroCheckedChanged(cmbCaja))
   End Sub
#Region "Eventos Buscador Proveedor"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region


   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
            ShowMessage("ATENCION: Activo el filtro de Proveedor pero NO selecciono")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If
         If chbNumero.Checked And (txtNumero.Text = "" OrElse Long.Parse(txtNumero.Text) = 0) Then
            ShowMessage("ATENCION: NO seleccionó un Numero aunque activó ese Filtro")
            txtNumero.Focus()
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
   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim clickedBtn = e.Cell.Column.Key
            If clickedBtn = "Ver" Or clickedBtn = "Imprimir" Or clickedBtn = "VerEstandar" Then
               'imprime los recibos
               Dim ctacte = GetReciboSeleccionado(dr)
               Dim imp = New PagosImprimir()
               imp.ImprimirPago(ctacte, visualizar:=clickedBtn <> "Imprimir", verEstandar:=clickedBtn = "VerEstandar")

               'Imprime Retencion
               If ctacte.Retenciones.AnySecure() Then
                     Dim ret = New RetencionImprimir()
                     ret.ImprimirRetencion(ctacte)
                  End If
               End If

            End If
         End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs)
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

   '-.PE-32808.-
   Private Sub tsbModificar_Click(sender As Object, e As EventArgs) Handles tsbModificar.Click
      TryCatched(
      Sub()
         If _modalidadPantalla <> Entidades.ModalidadPantalla.Modificar Then Exit Sub
         Dim recibo = GetReciboSeleccionado()
         If recibo IsNot Nothing Then
            Using frmModifPagosProv As New ModificarPagosProveedores()
               If frmModifPagosProv.ShowDialog(Me, recibo, _modalidadPantalla) = Windows.Forms.DialogResult.OK Then
                  btnConsultar.PerformClick()
               End If         'If frmAnular.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            End Using         'Using frmAnular As New AnularRecibos()
         End If               'If recibo IsNot Nothing Then
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbCategoria.Checked = False
      chbProveedor.Checked = False
      chbEstado.Checked = False
      chbUsuario.Checked = False
      chbCaja.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      chbTipoComprobante.Checked = False
      chbLetra.Checked = False
      chbEmisor.Checked = False
      chbNumero.Checked = False
      cmbSucursal.Refrescar()
      dtpDesde.Focus()

   End Sub

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
   Private Sub CargaGrillaDetalle()
      Dim idTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)
      Dim letra = cboLetra.ValorSeleccionado(chbLetra, String.Empty)
      Dim emisor = cmbEmisor.ValorSeleccionado(chbEmisor, 0I)
      Dim numeroComprobante = If(chbNumero.Checked, txtNumero.ValorNumericoPorDefecto(0L), 0L)
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoria, 0I)
      Dim idUsuario = cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty)
      Dim estado = cmbEstado.ValorSeleccionado(chbEstado, String.Empty)
      Dim idCaja = cmbCaja.ValorSeleccionado(chbCaja, 0I)

      Dim rCtaCteProv = New Reglas.CuentasCorrientesProv()
      Dim dtDetalle = rCtaCteProv.GetPagosPorRangoFechas(cmbSucursal.GetSucursales(),
                                                        dtpDesde.Value, dtpHasta.Value,
                                                        idProveedor,
                                                        idCategoria, idUsuario, estado, idTipoComprobante,
                                                        letra, emisor, numeroComprobante, idCaja)
      dtDetalle.Columns.Add("Ver", GetType(String))
      dtDetalle.Columns.Add("Imprimir", GetType(String))
      dtDetalle.Columns.Add("VerEstandar", GetType(String))

      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub

   Private Function GetReciboSeleccionado() As Entidades.CuentaCorrienteProv
      Return GetReciboSeleccionado(ugDetalle.FilaSeleccionada(Of DataRow)())
   End Function
   Private Function GetReciboSeleccionado(dr As DataRow) As Entidades.CuentaCorrienteProv
      If dr IsNot Nothing Then
         Dim reg = New Reglas.CuentasCorrientesProv()
         Return reg.GetUna(dr.Field(Of Integer)("IdSucursal"),
                           dr.Field(Of Long)("IdProveedor"),
                           dr.Field(Of String)("IdTipoComprobante"),
                           dr.Field(Of String)("Letra"),
                           dr.Field(Of Integer)("CentroEmisor"),
                           dr.Field(Of Long)("NumeroComprobante"))
      End If
      Return Nothing
   End Function

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         If cmbSucursal.SelectedIndex > -1 Then
            filtro.AppendFormat(" - Sucursal: {0}", cmbSucursal.Text)
         End If
         If Me.chbProveedor.Checked Then
            filtro.AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text, bscProveedor.Text)
         End If
         If Me.chkMesCompleto.Checked Then
            filtro.AppendFormat(" - Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         End If
         If Me.chbTipoComprobante.Checked Then
            filtro.AppendFormat(" - Tipo de Comprobante: {0}", cmbTiposComprobantes.Text)
         End If
         If Me.chbLetra.Checked Then
            filtro.AppendFormat(" - Letra: {0}", cboLetra.Text)
         End If
         If Me.chbEmisor.Checked Then
            filtro.AppendFormat(" - Emisor: {0}", cmbEmisor.Text)
         End If
         If Me.chbNumero.Checked Then
            filtro.AppendFormat(" - Número: {0}", txtNumero.Text)
         End If
         If Me.chbCategoria.Checked Then
            filtro.AppendFormat(" - Categoria: {0}", cmbCategoria.Text)
         End If
         If Me.chbUsuario.Checked Then
            filtro.AppendFormat(" - Usuario: {0}", cmbUsuario.Text)
         End If
         If Me.chbCaja.Checked Then
            filtro.AppendFormat(" - Caja: {0}", cmbCaja.Text)
         End If
         If Me.chbEstado.Checked Then
            filtro.AppendFormat(" - Estado: {0}", cmbEstado.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#End Region

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If parametros = "Modificar" Then
         _modalidadPantalla = Entidades.ModalidadPantalla.Modificar
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Modalidad de la pantalla.")
      stb.AppendFormatLine("Valores posibles: Consultar/Modificar")
      stb.AppendFormatLine("Por defecto: Consultar")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

#End Region

End Class