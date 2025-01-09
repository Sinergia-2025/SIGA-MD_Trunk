Public Class ModificarComprobantesDeVentas
   Implements IConParametros
#Region "Campos"

   Private _publicos As Publicos
   Private _modo As String
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Enumeraciones"

   Private Enum Estados
      Insercion
      Modificacion
   End Enum

#End Region
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(_modo) Then _modo = "VENTAS"

         tsbEditar.Visible = _modo = "VENTAS"
         tsbCancelar.Visible = _modo = "VENTAS"
         tsbModificarCuotas.Visible = _modo = "CTACTE"

         tsbEditar.Enabled = False
         tsbCancelar.Enabled = False
         _publicos = New Publicos()

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, True, "VENTAS")
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1

         If _modo = "VENTAS" Then
            _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         Else
            _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS", False)
         End If

         cmbFormaPago.SelectedIndex = -1

         'Hay que colocarlo del CargarColumnasASumar porque sino da error.
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         ugDetalle.AgregarTotalesSuma({"ImporteTotal", "TotalImpuestos", "Subtotal", "Kilos", "ComisionVendedor"})

         dtpDesde.Focus()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbPreferencias.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Metodos"

   Private Sub ModificarVenta()
      Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         Dim rVenta = New Reglas.Ventas

         '# Cargo el comprobante a Modificar
         Dim eVenta = rVenta.GetUna(dr.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                 dr.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                 dr.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                 Convert.ToInt16(dr.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString())),
                                 dr.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))

         '# Paso el comprobante a la pantalla de Modificación
         Using frm = New ModificarVentasDetalle(eVenta, IdFuncion)
            frm.ShowDialog()
         End Using
      End If
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False

         btnBuscar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      tsbEditar.Enabled = False
      tsbCancelar.Enabled = False

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today

      bscCodigoCliente.Permitido = True
      bscCodigoCliente.Text = String.Empty
      bscCodigoCliente.Tag = Nothing
      bscCliente.Permitido = True
      bscCliente.Text = ""
      tsbModificarCuotas.Enabled = False
      chbTipoComprobante.Checked = False
      chbCliente.Checked = False
      chbVendedor.Checked = False
      chbFormaPago.Checked = False
      If cmbTiposComprobantes.Items.Count > 0 Then
         'Me.cmbTiposComprobantes.SelectedIndex = 0
         cmbTiposComprobantes.SelectedValue = "REMITO"
      End If

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False
      ugDetalle.ClearFilas()
      '-- REQ-35894.- ----------------------------------------------
      txtNroComprobante.Text = String.Empty
      chbNroComprobante.Checked = False
      '-------------------------------------------------------------
      dtpDesde.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idCliente = If(chbCliente.Checked, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), 0L)
      Dim idTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idFormaDePago = cmbFormaPago.ValorSeleccionado(chbFormaPago, 0I)
      Dim modoCtaCte = _modo = "CTACTE"

      Dim nComprobanteDesde As Long? = Nothing
      If chbNroComprobante.Checked Then nComprobanteDesde = txtNroComprobante.ValorNumericoPorDefecto(0L)
      Dim nComprobanteHasta As Long? = Nothing
      If chbNroComprobante.Checked Then nComprobanteHasta = txtNroComprobante.ValorNumericoPorDefecto(0L)

      Dim fechaDesde = dtpDesde.Value.Date()
      Dim fechaHasta = dtpHasta.Value.UltimoSegundoDelDia()

      Dim rVenta = New Reglas.Ventas()
      Dim dtDetalle = rVenta.GetPorRangoFechas(agregarSelec:=False, agregarVer:=True,
                                               {actual.Sucursal}, fechaDesde, fechaHasta, idVendedor, Entidades.OrigenFK.Movimiento,
                                               Entidades.Publicos.SiNoTodos.TODOS, idCliente, Entidades.Publicos.SiNoTodos.TODOS,
                                               idTipoComprobante, numeroComprobante:=0, idFormaDePago, idUsuario:=String.Empty,
                                               idEstadoComprobante:="PENDIENTE", porcUtilidadDesde:=-1, porcUtilidadHasta:=-1,
                                               mercDespachada:="TODOS", comercial:="TODOS", idCategoria:=0, numeroReparto:=0,
                                               modoCtaCte, exclurirComprobanteFiscal:=False, exclurirComprobanteElectronico:=False,
                                               letra:=String.Empty, emisor:=Nothing, nComprobanteDesde, nComprobanteHasta)

      'Dim dt = CrearDT()

      'For Each dr As DataRow In dtDetalle.Rows

      '   Dim drCl = dt.NewRow()

      '   drCl("Ver") = "..."
      '   drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
      '   drCl("IdSucursal") = dr.Field(Of Integer)("IdSucursal")
      '   drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
      '   drCl("Letra") = dr("Letra").ToString()
      '   drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
      '   drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
      '   drCl("NombreVendedor") = dr("NombreVendedor").ToString()
      '   drCl("IdEstadoComprobante") = dr("IdEstadoComprobante").ToString()
      '   drCl("ImporteBruto") = Decimal.Parse(dr("ImporteBruto").ToString())
      '   drCl("DescuentoRecargoPorc") = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
      '   drCl("DescuentoRecargo") = Decimal.Parse(dr("DescuentoRecargo").ToString())
      '   drCl("SubTotal") = Decimal.Parse(dr("SubTotal").ToString())
      '   drCl("TotalImpuestos") = Decimal.Parse(dr("TotalImpuestos").ToString())
      '   drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
      '   drCl("Kilos") = Decimal.Parse(dr("Kilos").ToString())
      '   drCl("ComisionVendedor") = Decimal.Parse(dr("ComisionVendedor").ToString())
      '   drCl("FormaDePago") = dr("FormaDePago").ToString()
      '   drCl("NombreCliente") = dr("NombreCliente").ToString()
      '   drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
      '   drCl("Observacion") = dr("Observacion").ToString()
      '   drCl("DescripcionAbrev") = dr("DescripcionAbrev").ToString()
      '   drCl(Entidades.Venta.Columnas.IdCategoria.ToString()) = dr.Field(Of Integer)(Entidades.Venta.Columnas.IdCategoria.ToString())

      '   drCl("IdClienteCtaCte") = dr("IdClienteCtaCte")
      '   drCl("CodigoClienteCtaCte") = dr("CodigoClienteCtaCte")
      '   drCl("NombreClienteCtaCte") = dr("NombreClienteCtaCte")
      '   drCl("Saldo") = dr("Saldo")
      '   If Not String.IsNullOrEmpty(dr("IdCobrador").ToString()) Then
      '      drCl("IdCobrador") = dr("IdCobrador")
      '      drCl("NombreCobrador") = dr("NombreCobrador")
      '   End If
      '   drCl("IdClienteVinculado") = dr("IdClienteVinculado")
      '   drCl("CodigoClienteVinculado") = dr("CodigoClienteVinculado")
      '   drCl("NombreClienteVinculado") = dr("NombreClienteVinculado")
      '   drCl("IdVendedor") = dr("IdVendedor")
      '   'drCl("NroDocVendedor") = dr("NroDocVendedor")

      '   drCl("Referencia") = dr("Referencia")

      '   dt.Rows.Add(drCl)

      'Next

      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)

      ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreCobrador", "NombreVendedor"}, {})

      ugDetalle.DisplayLayout.Bands(0).Columns("Kilos").Hidden = _modo = "CTACTE"
      ugDetalle.DisplayLayout.Bands(0).Columns("ComisionVendedor").Hidden = _modo = "CTACTE"

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   'Private Function CrearDT() As DataTable

   '   Dim dtTemp As DataTable = New DataTable()

   '   With dtTemp
   '      .Columns.Add("Ver")
   '      .Columns.Add("IdSucursal", GetType(Integer))
   '      .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
   '      .Columns.Add("Letra", System.Type.GetType("System.String"))
   '      .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
   '      .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
   '      .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
   '      .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
   '      .Columns.Add("IdEstadoComprobante", System.Type.GetType("System.String"))
   '      .Columns.Add("ImporteBruto", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("DescuentoRecargoPorc", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("DescuentoRecargo", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("SubTotal", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("Kilos", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("ComisionVendedor", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("Observacion", System.Type.GetType("System.String"))
   '      .Columns.Add("DescripcionAbrev", System.Type.GetType("System.String"))
   '      .Columns.Add("IdCategoria", GetType(Integer))

   '      .Columns.Add("IdClienteCtaCte", GetType(Long))
   '      .Columns.Add("CodigoClienteCtaCte", GetType(Long))
   '      .Columns.Add("NombreClienteCtaCte", GetType(String))
   '      .Columns.Add("Saldo", GetType(Decimal))
   '      .Columns.Add("IdCobrador", GetType(Integer))
   '      .Columns.Add("NombreCobrador", GetType(String))
   '      .Columns.Add("IdClienteVinculado", GetType(Integer))
   '      .Columns.Add("CodigoClienteVinculado", GetType(Integer))
   '      .Columns.Add("NombreClienteVinculado", GetType(String))

   '      .Columns.Add("IdVendedor", System.Type.GetType("System.Int32"))
   '      '  .Columns.Add("NroDocVendedor", System.Type.GetType("System.String"))

   '      .Columns.Add("Referencia", GetType(String))

   '   End With

   '   Return dtTemp

   'End Function

#Region "Metodos IConParametros"
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If parametros = "TIPO" Then
         _modo = "VENTAS"
      Else
         _modo = "CTACTE"
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Modalidad de la pantalla.")
      stb.AppendFormatLine("Valores posibles: TIPO o blanco")
      stb.AppendFormatLine("Si TIPO usa modo VENTAS. Si blanco usa modo CTACTE")
      stb.AppendFormatLine("Por defecto: blanco")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function
#End Region
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbEditar_Click(sender As Object, e As EventArgs) Handles tsbEditar.Click
      TryCatched(Sub() ModificarVenta())
   End Sub
   Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
      TryCatched(
      Sub()
         tsbEditar.Enabled = True
         tsbCancelar.Enabled = False
      End Sub)
   End Sub
   Private Sub tsbModificarCuotas_Click(sender As Object, e As EventArgs) Handles tsbModificarCuotas.Click
      TryCatched(
      Sub()
         If ugDetalle.ActiveRow Is Nothing Then Exit Sub
         Dim dr = Me.ugDetalle.FilaSeleccionada(Of DataRow)()
         Dim oFacturacion = New Reglas.Ventas()
         Dim comp = oFacturacion.GetUna(dr.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                        dr.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                        dr.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                        Convert.ToInt16(dr.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString())),
                                        dr.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))

         If comp.CuentaCorriente.CantidadCuotas <> 0 Then
            Using frmMCC = New CuentaCorrienteModificar(comp)
               If frmMCC.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  ShowMessage("Se modificaron la cuotas correctamente.")
               End If
            End Using
         Else
            ShowMessage("El comprobante no es de Cuenta Corriente.")
         End If
      End Sub)
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
   Private Sub chbNroComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroComprobante.CheckedChanged
      TryCatched(
      Sub()
         txtNroComprobante.Text = String.Empty
         txtNroComprobante.Focus()
         txtNroComprobante.Enabled = chbNroComprobante.Checked
      End Sub)
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
   End Sub

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
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


#End Region

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
      Sub()
         If chbTipoComprobante.Checked AndAlso cmbTiposComprobantes.SelectedIndex < 0 Then
            ShowMessage("ATENCION: Debe seleccionar un Tipo de Comprobante")
            cmbTiposComprobantes.Focus()
            Exit Sub
         End If
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: Debe seleccionar un Cliente")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnBuscar.Focus()

            tsbEditar.Enabled = True
            tsbCancelar.Enabled = False
            tsbModificarCuotas.Enabled = True
         Else
            tsbEditar.Enabled = False
            tsbCancelar.Enabled = False
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub


   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      TryCatched(Sub() tsbEditar.Enabled = ugDetalle.Count <> 0)
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            If e.Cell.Column.Key = "Ver" Then
               Dim rVentas = New Reglas.Ventas()
               Dim venta = rVentas.GetUna(actual.Sucursal.Id,
                                          dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                                          dr.Field(Of Integer)("CentroEmisor").ToShort(), dr.Field(Of Long)("NumeroComprobante"))

               Dim oImpr = New Impresion(venta)
               Dim oTipoComprobante = New Reglas.TiposComprobantes().GetUno(dr.Field(Of String)("IdTipoComprobante"))
               If Not oTipoComprobante.EsFiscal Then
                  oImpr.ImprimirComprobanteNoFiscal(True)
               Else
                  oImpr.ReImprimirComprobanteFiscal()
               End If
            End If
         End If
      End Sub)
   End Sub
#End Region

End Class
