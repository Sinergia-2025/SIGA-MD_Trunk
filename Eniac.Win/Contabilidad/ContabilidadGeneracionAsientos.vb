#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
#End Region
Public Class ContabilidadGeneracionAsientos

   Private Paginas As List(Of TabPage) = New List(Of TabPage)()

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      TryCatched(
         Sub()
            dtpDesde.Value = Date.Now
            dtpHasta.Value = Date.Now.AddMonths(1)

            Text = String.Format("{0} - Empresa: {1}", Text, actual.Sucursal.NombreEmpresa)
         End Sub)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            tsbVincularAsientoManual.Visible = New Reglas.Usuarios().TienePermisos("Contabilidad-PermiteVincular")
            tssVincularAsientoManual.Visible = tsbVincularAsientoManual.Visible
         End Sub)
   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(
         Sub()
            If Reglas.ContabilidadPublicos.ContabilidadCuentaRedondeo = 0 Then
               ShowMessage("Debe setear la cuenta <Cuenta para Diferencias por Redondeo> desde Parametros del Sistema.")
               Close()
            End If
         End Sub)
   End Sub

#End Region

#Region "Eventos"

   Private Sub ugdCtaCteProveedores_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugdCtaCteProveedores.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugdCtaCteProveedores.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               Select Case e.Cell.Column.Key
                  Case Is = "Ver"
                     Dim rCtaCteProv = New Reglas.CuentasCorrientesProv()
                     Dim ctacte = rCtaCteProv.GetUna(
                                             dr.Field(Of Integer)("IdSucursal"),
                                             dr.Field(Of Long)("IdProveedor"),
                                             dr.Field(Of String)("IdTipoComprobante"),
                                             dr.Field(Of String)("Letra"),
                                             dr.Field(Of Integer)("CentroEmisor"),
                                             dr.Field(Of Long)("NumeroComprobante"))
                     Dim imp = New PagosImprimir()
                     imp.ImprimirPago(ctacte, True)
               End Select
            End If
         End Sub)
   End Sub

   Private Sub ugdCompras_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugdCompras.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugdCompras.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               Select Case e.Cell.Column.Key
                  Case Is = "Ver"
                     Dim rCompras = New Reglas.Compras()
                     Dim Compra = rCompras.GetUna(
                                             dr.Field(Of Integer)("IdSucursal"),
                                             dr.Field(Of String)("IdTipoComprobante"),
                                             dr.Field(Of String)("Letra"),
                                             dr.Field(Of Integer)("CentroEmisor"),
                                             dr.Field(Of Long)("NumeroComprobante"),
                                             dr.Field(Of Long)("IdProveedor"))
                     Dim oImpr = New ImpresionCompra(Compra)
                     oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)
               End Select
            End If
         End Sub)
   End Sub

   Private Sub ugdCtaCteClientes_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugdCtaCteClientes.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugdCtaCteClientes.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               Select Case e.Cell.Column.Key
                  Case Is = "Ver"
                     Dim rCtaCte = New Reglas.CuentasCorrientes()
                     Dim ctacte = rCtaCte.GetUna(
                                             dr.Field(Of Integer)("IdSucursal"),
                                             dr.Field(Of String)("IdTipoComprobante"),
                                             dr.Field(Of String)("Letra"),
                                             dr.Field(Of Integer)("CentroEmisor"),
                                             dr.Field(Of Long)("NumeroComprobante"))
                     Dim imp = New RecibosImprimir()
                     imp.ImprimirRecibo(ctacte, True)
               End Select
            End If
         End Sub)
   End Sub

   Private Sub ugdCaja_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugdCaja.ClickCellButton
      TryCatched(
         Sub()
            If e.Cell.Column.Key = "Ver" Then
               Dim dr = ugdCaja.FilaSeleccionada(Of DataRow)(e.Cell.Row)
               If dr IsNot Nothing Then
                  Using frmDetalle = New CajaDetalles()
                     frmDetalle.Operacion = Reglas.CajaDetalles.TipoOperacion.Consulta

                     frmDetalle.IdSucursalMovimiento = dr.Field(Of Integer)("IdSucursal")
                     frmDetalle.CajaNombre.IdCaja = dr.Field(Of Integer)("IdCaja")
                     frmDetalle.CajaNombre.NombreCaja = dr.Field(Of String)("NombreCaja")

                     frmDetalle.NumeroPlanilla = dr.Field(Of Integer)("NumeroPlanilla")
                     frmDetalle.NroDeMovimiento = dr.Field(Of Integer)("NumeroMovimiento")

                     frmDetalle.btnAceptar.Visible = False

                     frmDetalle.ShowDialog()
                  End Using
               End If
            End If
         End Sub)
   End Sub

   Private Sub ugdDepositosBancarios_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugdDepositosBancarios.ClickCellButton
      TryCatched(
         Sub()
            If e.Cell.Column.Key = "Ver" Then
               Dim dr = ugdDepositosBancarios.FilaSeleccionada(Of DataRow)(e.Cell.Row)
               If dr IsNot Nothing Then
                  Dim rDepositos = New Reglas.Depositos()
                  Dim Deposito = rDepositos.GetUna(
                                             dr.Field(Of Integer)("IdSucursal"),
                                             dr.Field(Of Long)("NumeroDeposito"),
                                             dr.Field(Of String)("IdTipoComprobante"))
                  Dim di = New DepositosImprimir()
                  di.ImprimirDeposito(Deposito)
               End If
            End If
         End Sub)
   End Sub

   Private Sub ugdVentas_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugdVentas.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugdCtaCteClientes.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               Select Case e.Cell.Column.Key
                  Case Is = "Ver"

                     Dim rVentas = New Reglas.Ventas()
                     Dim venta = rVentas.GetUna(
                                             dr.Field(Of Integer)("IdSucursal"),
                                             dr.Field(Of String)("IdTipoComprobante"),
                                             dr.Field(Of String)("Letra"),
                                             dr.Field(Of Integer)("CentroEmisor").ToShort(),
                                             dr.Field(Of Long)("NumeroComprobante"))
                     Dim oImpr = New Impresion(venta)
                     If venta.Impresora.TipoImpresora = "NORMAL" Then
                        oImpr.ImprimirComprobanteNoFiscal(Visualizar:=True, UtilizarComprobanteEstandar:=False)
                        'If venta.Percepciones IsNot Nothing Then
                        '   For Each perc In venta.Percepciones
                        '      If perc.ImporteTotal <> 0 Then
                        '         Dim ret = New PercepcionImprimir()
                        '         ret.ImprimirPercepcion(venta, perc)
                        '      End If
                        '   Next
                        'End If
                     Else
                        oImpr.ReImprimirComprobanteFiscal()
                     End If
               End Select
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos Privados"
   Private Function ValidarProceso() As Boolean
      If chkprocesos.CheckedItems.Count = 0 Then
         Return False
      End If
      Return True
   End Function

   Private Sub ConcatenarMensaje(mensaje As StringBuilder, resultado As Reglas.ContabilidadProcesos.ResultadoProcesoHistorico, proceso As String, grilla As UltraGrid)
      mensaje.AppendFormat("{1}: Se han procesado {0} registros.", resultado.Procesados, proceso)
      If resultado.Erroneos > 0 Then
         mensaje.AppendFormat(" Con error {0}.", resultado.Erroneos)
         With grilla.DisplayLayout.Bands(0)
            .Columns("MensajeError").Hidden = False
            .SortedColumns.Clear()
            .SortedColumns.Add(.Columns("MensajeError"), True)
         End With
         grilla.ActiveRow = grilla.Rows(0)
      End If
      mensaje.AppendLine()
   End Sub

   Private Sub InicializaProgreeBar(proceso As String, dt As DataTable)
      tslInfo.Text = "Procesando " + proceso
      Application.DoEvents()
      tspBarra.Minimum = 0
      tspBarra.Value = 0
      tspBarra.Maximum = dt.Rows.Count
   End Sub

   Private Sub Procesar()
      Dim rProcesoContable = New Reglas.ContabilidadProcesos(tspBarra, tstAvance)

      Dim mensaje = New StringBuilder()
      Dim resultado As Reglas.ContabilidadProcesos.ResultadoProcesoHistorico

      tslInfo.Text = String.Empty
      tspBarra.Visible = True

      ' para cada item chequeado, llamo al proceso correspondiente para incuirlo en contabilidad.
      For i As Integer = 0 To Me.chkprocesos.CheckedItems.Count - 1
         Dim proceso As String = Me.chkprocesos.CheckedItems(i).ToString()
         Select Case proceso
            Case "Ventas"
               If Me.ugdVentas.DataSource IsNot Nothing AndAlso TypeOf (Me.ugdVentas.DataSource) Is DataTable Then
                  InicializaProgreeBar(proceso, DirectCast(Me.ugdVentas.DataSource, DataTable))
                  resultado = rProcesoContable.CargarAsientosDeVentas(DirectCast(Me.ugdVentas.DataSource, DataTable))
                  ConcatenarMensaje(mensaje, resultado, proceso, ugdVentas)
               End If

            Case "CC. Clientes"
               If Me.ugdCtaCteClientes.DataSource IsNot Nothing AndAlso TypeOf (Me.ugdCtaCteClientes.DataSource) Is DataTable Then
                  InicializaProgreeBar(proceso, DirectCast(Me.ugdCtaCteClientes.DataSource, DataTable))
                  resultado = rProcesoContable.CargarAsientosDeCtaCteClte(DirectCast(Me.ugdCtaCteClientes.DataSource, DataTable))
                  ConcatenarMensaje(mensaje, resultado, proceso, ugdCtaCteClientes)
               End If

            Case "Compras"
               If Me.ugdCompras.DataSource IsNot Nothing AndAlso TypeOf (Me.ugdCompras.DataSource) Is DataTable Then
                  InicializaProgreeBar(proceso, DirectCast(Me.ugdCompras.DataSource, DataTable))
                  resultado = rProcesoContable.CargarAsientosDeCompras(DirectCast(Me.ugdCompras.DataSource, DataTable))
                  ConcatenarMensaje(mensaje, resultado, proceso, ugdCompras)
               End If

            Case "CC. Proveedores"
               If Me.ugdCtaCteProveedores.DataSource IsNot Nothing AndAlso TypeOf (Me.ugdCtaCteProveedores.DataSource) Is DataTable Then
                  InicializaProgreeBar(proceso, DirectCast(Me.ugdCtaCteProveedores.DataSource, DataTable))
                  resultado = rProcesoContable.CargarAsientosDeCtaCteProv(DirectCast(Me.ugdCtaCteProveedores.DataSource, DataTable))
                  ConcatenarMensaje(mensaje, resultado, proceso, ugdCtaCteProveedores)
               End If

            Case "Caja"
               If Me.ugdCaja.DataSource IsNot Nothing AndAlso TypeOf (Me.ugdCaja.DataSource) Is DataTable Then
                  InicializaProgreeBar(proceso, DirectCast(Me.ugdCaja.DataSource, DataTable))
                  resultado = rProcesoContable.CargarAsientosDeCaja(DirectCast(Me.ugdCaja.DataSource, DataTable))
                  ConcatenarMensaje(mensaje, resultado, proceso, ugdCaja)
               End If

            Case "Bancos"
               If Me.ugdBanco.DataSource IsNot Nothing AndAlso TypeOf (Me.ugdBanco.DataSource) Is DataTable Then
                  InicializaProgreeBar(proceso, DirectCast(Me.ugdBanco.DataSource, DataTable))
                  resultado = rProcesoContable.CargarAsientosDeBancos(DirectCast(Me.ugdBanco.DataSource, DataTable))
                  ConcatenarMensaje(mensaje, resultado, proceso, ugdBanco)
               End If

            Case "Dep./Extracc./Transf."
               If Me.ugdDepositosBancarios.DataSource IsNot Nothing AndAlso TypeOf (Me.ugdDepositosBancarios.DataSource) Is DataTable Then
                  InicializaProgreeBar(proceso, DirectCast(Me.ugdDepositosBancarios.DataSource, DataTable))
                  resultado = rProcesoContable.CargarAsientosDeDepositoBancario(DirectCast(Me.ugdDepositosBancarios.DataSource, DataTable))
                  ConcatenarMensaje(mensaje, resultado, proceso, ugdDepositosBancarios)
               End If
         End Select

      Next
      tspBarra.Value = 0
      tspBarra.Visible = False
      tslInfo.Text = String.Empty

      ShowMessage(mensaje.ToString())

   End Sub

#End Region


   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub tsbGenerarAsientos_Click(sender As Object, e As EventArgs) Handles tsbGenerarAsientos.Click
      TryCatched(
         Sub()
            tsbGenerarAsientos.Enabled = False
            If ValidarProceso() Then
               Procesar()
            End If
         End Sub,
         onErrorAction:=
         Sub(owner, ex)
            ShowError(ex, recursivo:=True)
         End Sub,
         onFinallyAction:=Sub(owner) tsbGenerarAsientos.Enabled = True)
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            dtpDesde.Value = Date.Now
            dtpHasta.Value = Date.Now.AddMonths(1)

            chbTodos.Checked = False
            'Hago esto porque podria estar false con algunos chequeados.
            For i = 0 To chkprocesos.Items.Count - 1
               chkprocesos.SetItemChecked(i, False)
            Next
            'Oculto todas las solapas.
            For Each pagina As TabPage In tbcResultados.TabPages
               MostrarPagina(pagina, False)
            Next

            tslInfo.Text = String.Empty
         End Sub)
   End Sub

   Private Function AgregarProcesadoMensaje(dt As DataTable) As DataTable
      Dim dc As DataColumn
      If Not dt.Columns.Contains("Procesado") Then
         dc = New DataColumn("Procesado", GetType(Boolean))
         dc.DefaultValue = False
         dt.Columns.Add(dc)
      End If

      If Not dt.Columns.Contains("MensajeError") Then
         dc = New DataColumn("MensajeError", GetType(String))
         dc.DefaultValue = String.Empty
         dt.Columns.Add(dc)
      End If
      'dc = New DataColumn("Ver")
      'dt.Columns.Add(dc)

      Return dt
   End Function

   Private Sub LimpiarGrilla(grilla As UltraWinGrid.UltraGrid)
      If grilla.DataSource IsNot Nothing AndAlso TypeOf (grilla.DataSource) Is DataTable Then
         DirectCast(grilla.DataSource, DataTable).Clear()
      End If
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            Dim rProceso = New Reglas.ContabilidadProcesos()

            LimpiarGrilla(ugdVentas)
            LimpiarGrilla(ugdCtaCteClientes)
            LimpiarGrilla(ugdCompras)
            LimpiarGrilla(ugdCtaCteProveedores)
            LimpiarGrilla(ugdCaja)
            LimpiarGrilla(ugdBanco)
            LimpiarGrilla(ugdDepositosBancarios)

            tbcResultados.TabPages.OfType(Of TabPage).ToList().
                  ForEach(Sub(pagina) MostrarPagina(pagina, False))

            For i = 0 To chkprocesos.CheckedItems.Count - 1
               Select Case chkprocesos.CheckedItems(i).ToString
                  Case "Ventas"
                     MostrarPagina(tbpFacturasVentas, True)
                     ugdVentas.DataSource = AgregarProcesadoMensaje(rProceso.ObtenerDatosVentas(dtpDesde.Value, dtpHasta.Value))
                     ConfigurarGrillaVentas(ugdVentas)

                  Case "CC. Clientes"
                     MostrarPagina(tbpCuentaCorriente, True)
                     ugdCtaCteClientes.DataSource = AgregarProcesadoMensaje(rProceso.ObtenerDatosCtaCteClte(dtpDesde.Value, dtpHasta.Value))
                     ConfigurarGrillaCuentaCorriente(ugdCtaCteClientes)

                  Case "Compras"
                     MostrarPagina(tbpFacturasComprasStock, True)
                     ugdCompras.DataSource = AgregarProcesadoMensaje(rProceso.ObtenerDatosCompras(dtpDesde.Value, dtpHasta.Value))
                     ConfigurarGrillaCuentaFacturasCompras(ugdCompras)

                  Case "CC. Proveedores"
                     MostrarPagina(tbpPagosAProveedores, True)
                     ugdCtaCteProveedores.DataSource = AgregarProcesadoMensaje(rProceso.ObtenerDatosCtaCteProv(dtpDesde.Value, dtpHasta.Value))
                     ConfigurarGrillaPagoProveedores(ugdCtaCteProveedores)

                  Case "Caja"
                     'busco los movimientos de caja que no tienen fecha de Periodo Contable
                     MostrarPagina(tbpCaja, True)
                     ugdCaja.DataSource = AgregarProcesadoMensaje(rProceso.ObtenerDatosCaja(dtpDesde.Value, dtpHasta.Value))
                     ConfigurarGrillaCaja(ugdCaja)

                  Case "Bancos"
                     MostrarPagina(tbpBanco, True)
                     ugdBanco.DataSource = AgregarProcesadoMensaje(rProceso.ObtenerDatosLibroBanco(dtpDesde.Value, dtpHasta.Value))
                     ConfigurarGrillaBanco(ugdBanco)

                  Case "Dep./Extracc./Transf."
                     MostrarPagina(tbpDepositosBancarios, True)
                     ugdDepositosBancarios.DataSource = AgregarProcesadoMensaje(rProceso.ObtenerDatosDepositosBancarios(dtpDesde.Value, dtpHasta.Value))
                     ConfigurarGrillaDepositoBancario(ugdDepositosBancarios)

               End Select
            Next
            OrdenarPaginas(tbcResultados)
            ContarRegistros()
         End Sub)
   End Sub
   Private Sub MostrarPagina(pagina As TabPage, mostrar As Boolean)
      If (mostrar) Then
         If Not Me.tbcResultados.Contains(pagina) Then
            tbcResultados.TabPages.Add(pagina)
            Paginas.Remove(pagina)
         End If
      Else
         If Me.tbcResultados.Contains(pagina) Then
            tbcResultados.TabPages.Remove(pagina)
            Paginas.Add(pagina)
         End If
      End If
   End Sub

   Public Sub OrdenarPaginas(ByRef ContenedorPaginas As TabControl)
      Dim listaDePaginas = ContenedorPaginas.TabPages.Cast(Of TabPage).ToList()
      listaDePaginas.Sort(New ComparadorDePaginas())
      ContenedorPaginas.TabPages.Clear()
      ContenedorPaginas.TabPages.AddRange(listaDePaginas.ToArray())
   End Sub

   Public Class ComparadorDePaginas
      Implements IComparer(Of TabPage)
      Public Function Compare(x As TabPage, y As TabPage) As Integer Implements IComparer(Of TabPage).Compare
         Return String.Compare(x.Tag.ToString(), y.Tag.ToString())
      End Function
   End Class


   Private Sub ConfigurarGrillaVentas(ugdVentas As UltraGrid) 'VENTAS

      If ugdVentas.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In ugdVentas.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With ugdVentas.DisplayLayout.Bands(0)

         If Not .Columns.Exists("Ver") Then
            .Columns.Insert(0, "Ver")
         End If

         .Columns("Ver").Hidden = False
         .Columns("Ver").Header.Caption = "Ver"
         .Columns("Ver").Width = 30
         .Columns("Ver").Style = UltraWinGrid.ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = ButtonDisplayStyle.Always

         .Columns("IdSucursal").Hidden = False
         .Columns("IdSucursal").Header.Caption = "Suc."
         .Columns("IdSucursal").Width = 30
         .Columns("IdSucursal").CellAppearance.TextHAlign = HAlign.Right

         .Columns("IdTipoComprobante").Hidden = False
         .Columns("IdTipoComprobante").Header.Caption = "Tipo"
         .Columns("IdTipoComprobante").Width = 80

         .Columns("Letra").Hidden = False
         .Columns("Letra").Header.Caption = "L"
         .Columns("Letra").Width = 20

         .Columns("CentroEmisor").Hidden = False
         .Columns("CentroEmisor").Header.Caption = "Emisor"
         .Columns("CentroEmisor").Width = 50
         .Columns("CentroEmisor").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NumeroComprobante").Hidden = False
         .Columns("NumeroComprobante").Header.Caption = "Número"
         .Columns("NumeroComprobante").Width = 70
         .Columns("NumeroComprobante").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Fecha").Hidden = False
         .Columns("Fecha").Header.Caption = "Fecha"
         .Columns("Fecha").Width = 70
         .Columns("Fecha").CellAppearance.TextHAlign = HAlign.Center
         .Columns("Fecha").Format = Formatos.Format.FechaSinHora
         .Columns("Fecha").MaskInput = Formatos.MaskInput.FechaSinHora

         .Columns("ImporteTotal").Hidden = False
         .Columns("ImporteTotal").Header.Caption = "Total"
         .Columns("ImporteTotal").Width = 100
         .Columns("ImporteTotal").CellAppearance.TextHAlign = HAlign.Right
         .Columns("ImporteTotal").Format = "N2"

         .Columns("CodigoCliente").Hidden = False
         .Columns("CodigoCliente").Header.Caption = "Código"
         .Columns("CodigoCliente").Width = 60
         .Columns("CodigoCliente").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NombreCliente").Hidden = False
         .Columns("NombreCliente").Header.Caption = "Cliente"
         .Columns("NombreCliente").Width = 150

         .Columns("MensajeError").Header.Caption = "Mensaje de error"
         .Columns("MensajeError").Width = 400
      End With

      ugdVentas.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaCuentaCorriente(ugdCtaCteClientes As UltraGrid) 'CC CLIENTE

      If ugdCtaCteClientes.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In ugdCtaCteClientes.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With ugdCtaCteClientes.DisplayLayout.Bands(0)

         If Not .Columns.Exists("Ver") Then
            .Columns.Insert(0, "Ver")
         End If

         .Columns("Ver").Hidden = False
         .Columns("Ver").Header.Caption = "Ver"
         .Columns("Ver").Width = 30
         .Columns("Ver").Style = UltraWinGrid.ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = ButtonDisplayStyle.Always

         .Columns("IdSucursal").Hidden = False
         .Columns("IdSucursal").Header.Caption = "Suc."
         .Columns("IdSucursal").Width = 30
         .Columns("IdSucursal").CellAppearance.TextHAlign = HAlign.Right

         .Columns("IdTipoComprobante").Hidden = False
         .Columns("IdTipoComprobante").Header.Caption = "Tipo"
         .Columns("IdTipoComprobante").Width = 80

         .Columns("Letra").Hidden = False
         .Columns("Letra").Header.Caption = "L"
         .Columns("Letra").Width = 20

         .Columns("CentroEmisor").Hidden = False
         .Columns("CentroEmisor").Header.Caption = "Emisor"
         .Columns("CentroEmisor").Width = 50
         .Columns("CentroEmisor").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NumeroComprobante").Hidden = False
         .Columns("NumeroComprobante").Header.Caption = "Número"
         .Columns("NumeroComprobante").Width = 70
         .Columns("NumeroComprobante").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Fecha").Hidden = False
         .Columns("Fecha").Header.Caption = "Fecha"
         .Columns("Fecha").Width = 70
         .Columns("Fecha").CellAppearance.TextHAlign = HAlign.Center
         .Columns("Fecha").Format = Formatos.Format.FechaSinHora
         .Columns("Fecha").MaskInput = Formatos.MaskInput.FechaSinHora

         .Columns("ImporteTotal").Hidden = False
         .Columns("ImporteTotal").Header.Caption = "Total"
         .Columns("ImporteTotal").Width = 100
         .Columns("ImporteTotal").CellAppearance.TextHAlign = HAlign.Right
         .Columns("ImporteTotal").Format = "N2"

         .Columns("CodigoCliente").Hidden = False
         .Columns("CodigoCliente").Header.Caption = "Código"
         .Columns("CodigoCliente").Width = 60
         .Columns("CodigoCliente").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NombreCliente").Hidden = False
         .Columns("NombreCliente").Header.Caption = "Cliente"
         .Columns("NombreCliente").Width = 150

         .Columns("MensajeError").Header.Caption = "Mensaje de error"
         .Columns("MensajeError").Width = 400
      End With

      ugdCtaCteClientes.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaCuentaFacturasCompras(ugdCompras As UltraGrid) 'COMPRAS

      If ugdCompras.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In ugdCompras.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With ugdCompras.DisplayLayout.Bands(0)

         If Not .Columns.Exists("Ver") Then
            .Columns.Insert(0, "Ver")
         End If

         .Columns("Ver").Hidden = False
         .Columns("Ver").Header.Caption = "Ver"
         .Columns("Ver").Width = 30
         .Columns("Ver").Style = UltraWinGrid.ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = ButtonDisplayStyle.Always

         .Columns("IdSucursal").Hidden = False
         .Columns("IdSucursal").Header.Caption = "Suc."
         .Columns("IdSucursal").Width = 30
         .Columns("IdSucursal").CellAppearance.TextHAlign = HAlign.Right

         .Columns("IdTipoComprobante").Hidden = False
         .Columns("IdTipoComprobante").Header.Caption = "Tipo"
         .Columns("IdTipoComprobante").Width = 80

         .Columns("Letra").Hidden = False
         .Columns("Letra").Header.Caption = "L"
         .Columns("Letra").Width = 20

         .Columns("CentroEmisor").Hidden = False
         .Columns("CentroEmisor").Header.Caption = "Emisor"
         .Columns("CentroEmisor").Width = 50
         .Columns("CentroEmisor").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NumeroComprobante").Hidden = False
         .Columns("NumeroComprobante").Header.Caption = "Número"
         .Columns("NumeroComprobante").Width = 70
         .Columns("NumeroComprobante").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Fecha").Hidden = False
         .Columns("Fecha").Header.Caption = "Fecha"
         .Columns("Fecha").Width = 70
         .Columns("Fecha").CellAppearance.TextHAlign = HAlign.Center
         .Columns("Fecha").Format = Formatos.Format.FechaSinHora
         .Columns("Fecha").MaskInput = Formatos.MaskInput.FechaSinHora

         .Columns("ImporteTotal").Hidden = False
         .Columns("ImporteTotal").Header.Caption = "Total"
         .Columns("ImporteTotal").Width = 100
         .Columns("ImporteTotal").CellAppearance.TextHAlign = HAlign.Right
         .Columns("ImporteTotal").Format = "N2"

         .Columns("CodigoProveedor").Hidden = False
         .Columns("CodigoProveedor").Header.Caption = "Código"
         .Columns("CodigoProveedor").Width = 60
         .Columns("CodigoProveedor").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NombreProveedor").Hidden = False
         .Columns("NombreProveedor").Header.Caption = "Proveedor"
         .Columns("NombreProveedor").Width = 150

         .Columns("MensajeError").Header.Caption = "Mensaje de error"
         .Columns("MensajeError").Width = 400
      End With

      ugdCompras.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaPagoProveedores(ugdCtaCteProveedores As UltraGrid) 'CC PROVEEDORES

      If ugdCtaCteProveedores.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In ugdCtaCteProveedores.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With ugdCtaCteProveedores.DisplayLayout.Bands(0)

         If Not .Columns.Exists("Ver") Then
            .Columns.Insert(0, "Ver")
         End If

         .Columns("Ver").Hidden = False
         .Columns("Ver").Header.Caption = "Ver"
         .Columns("Ver").Width = 30
         .Columns("Ver").Style = UltraWinGrid.ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = ButtonDisplayStyle.Always

         .Columns("IdSucursal").Hidden = False
         .Columns("IdSucursal").Header.Caption = "Suc."
         .Columns("IdSucursal").Width = 30
         .Columns("IdSucursal").CellAppearance.TextHAlign = HAlign.Right

         .Columns("IdTipoComprobante").Hidden = False
         .Columns("IdTipoComprobante").Header.Caption = "Tipo"
         .Columns("IdTipoComprobante").Width = 80

         .Columns("Letra").Hidden = False
         .Columns("Letra").Header.Caption = "L"
         .Columns("Letra").Width = 20

         .Columns("CentroEmisor").Hidden = False
         .Columns("CentroEmisor").Header.Caption = "Emisor"
         .Columns("CentroEmisor").Width = 50
         .Columns("CentroEmisor").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NumeroComprobante").Hidden = False
         .Columns("NumeroComprobante").Header.Caption = "Número"
         .Columns("NumeroComprobante").Width = 70
         .Columns("NumeroComprobante").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Fecha").Hidden = False
         .Columns("Fecha").Header.Caption = "Fecha"
         .Columns("Fecha").Width = 70
         .Columns("Fecha").CellAppearance.TextHAlign = HAlign.Center
         .Columns("Fecha").Format = Formatos.Format.FechaSinHora
         .Columns("Fecha").MaskInput = Formatos.MaskInput.FechaSinHora

         .Columns("ImporteTotal").Hidden = False
         .Columns("ImporteTotal").Header.Caption = "Total"
         .Columns("ImporteTotal").Width = 100
         .Columns("ImporteTotal").CellAppearance.TextHAlign = HAlign.Right
         .Columns("ImporteTotal").Format = "N2"

         .Columns("CodigoProveedor").Hidden = False
         .Columns("CodigoProveedor").Header.Caption = "Código"
         .Columns("CodigoProveedor").Width = 60
         .Columns("CodigoProveedor").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NombreProveedor").Hidden = False
         .Columns("NombreProveedor").Header.Caption = "Proveedor"
         .Columns("NombreProveedor").Width = 150

         .Columns("MensajeError").Header.Caption = "Mensaje de error"
         .Columns("MensajeError").Width = 400
      End With

      ugdCtaCteProveedores.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaCaja(ugdCaja As UltraGrid)

      If ugdCaja.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In ugdCaja.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With ugdCaja.DisplayLayout.Bands(0)
         If Not .Columns.Exists("Ver") Then
            .Columns.Insert(0, "Ver")
         End If

         .Columns("Ver").Hidden = False
         .Columns("Ver").Header.Caption = "Ver"
         .Columns("Ver").Width = 30
         .Columns("Ver").Style = UltraWinGrid.ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = ButtonDisplayStyle.Always

         .Columns("IdSucursal").Hidden = False
         .Columns("IdSucursal").Header.Caption = "Suc."
         .Columns("IdSucursal").Width = 30
         .Columns("IdSucursal").CellAppearance.TextHAlign = HAlign.Right

         .Columns("IdCaja").Hidden = False
         .Columns("IdCaja").Header.Caption = "Caja"
         .Columns("IdCaja").Width = 40
         .Columns("IdCaja").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NombreCaja").Hidden = False
         .Columns("NombreCaja").Header.Caption = "Nombre de Caja"
         .Columns("NombreCaja").Width = 100

         .Columns("NumeroPlanilla").Hidden = False
         .Columns("NumeroPlanilla").Header.Caption = "Planilla"
         .Columns("NumeroPlanilla").Width = 55
         .Columns("NumeroPlanilla").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NumeroMovimiento").Hidden = False
         .Columns("NumeroMovimiento").Header.Caption = "Número"
         .Columns("NumeroMovimiento").Width = 70
         .Columns("NumeroMovimiento").CellAppearance.TextHAlign = HAlign.Right

         .Columns("FechaMovimiento").Hidden = False
         .Columns("FechaMovimiento").Header.Caption = "Fecha"
         .Columns("FechaMovimiento").Width = 70
         .Columns("FechaMovimiento").CellAppearance.TextHAlign = HAlign.Center
         .Columns("FechaMovimiento").Format = Formatos.Format.FechaSinHora
         .Columns("FechaMovimiento").MaskInput = Formatos.MaskInput.FechaSinHora

         .Columns("IdTipoMovimiento").Hidden = False
         .Columns("IdTipoMovimiento").Header.Caption = "T"
         .Columns("IdTipoMovimiento").Width = 20

         .Columns("NombreCuentaCaja").Hidden = False
         .Columns("NombreCuentaCaja").Header.Caption = "Cuenta Caja"
         .Columns("NombreCuentaCaja").Width = 150

         .Columns("ImportePesos").Hidden = False
         .Columns("ImportePesos").Header.Caption = "Pesos"
         .Columns("ImportePesos").Width = 100
         .Columns("ImportePesos").CellAppearance.TextHAlign = HAlign.Right
         .Columns("ImportePesos").Format = "N2"

         '.Columns("ImporteDolares").Hidden = False
         '.Columns("ImporteDolares").Header.Caption = "Dolares"
         '.Columns("ImporteDolares").Width = 100
         '.Columns("ImporteDolares").CellAppearance.TextHAlign = HAlign.Right
         '.Columns("ImporteDolares").Format = "N2"

         '.Columns("ImporteEuros").Hidden = False
         '.Columns("ImporteEuros").Header.Caption = "Euros"
         '.Columns("ImporteEuros").Width = 100
         '.Columns("ImporteEuros").CellAppearance.TextHAlign = HAlign.Right
         '.Columns("ImporteEuros").Format = "N2"

         .Columns("ImporteCheques").Hidden = False
         .Columns("ImporteCheques").Header.Caption = "Cheques"
         .Columns("ImporteCheques").Width = 100
         .Columns("ImporteCheques").MaxWidth = 100
         .Columns("ImporteCheques").CellAppearance.TextHAlign = HAlign.Right
         .Columns("ImporteCheques").Format = "N2"

         '.Columns("ImporteTarjetas").Hidden = False
         '.Columns("ImporteTarjetas").Header.Caption = "Tarjetas"
         '.Columns("ImporteTarjetas").Width = 100
         '.Columns("ImporteTarjetas").CellAppearance.TextHAlign = HAlign.Right
         '.Columns("ImporteTarjetas").Format = "N2"

         '.Columns("ImporteTickets").Hidden = False
         '.Columns("ImporteTickets").Header.Caption = "Tickets"
         '.Columns("ImporteTickets").Width = 100
         '.Columns("ImporteTickets").CellAppearance.TextHAlign = HAlign.Right
         '.Columns("ImporteTickets").Format = "N2"

         .Columns("MensajeError").Header.Caption = "Mensaje de error"
         .Columns("MensajeError").Width = 400
      End With

      ugdCaja.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaBanco(ugdBanco As UltraGrid)

      If ugdBanco.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In ugdBanco.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With ugdBanco.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns("IdSucursal").FormatearColumna("Suc.", pos, 30, HAlign.Right)
         .Columns("NombreCuenta").FormatearColumna("Cuenta Bancaria", pos, 100)
         .Columns("NumeroMovimiento").FormatearColumna("Número", pos, 70, HAlign.Right)
         .Columns("FechaMovimiento").FormatearColumna("Fecha", pos, 70, HAlign.Center, , Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("FechaAplicado").FormatearColumna("F. Aplicado", pos, 70, HAlign.Center, , Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("IdTipoMovimiento").FormatearColumna("T", pos, 20, HAlign.Center)
         .Columns("Importe").FormatearColumna("Importe", pos, 100, HAlign.Right, , Formatos.Format.Decimales2)
         .Columns("Observacion").FormatearColumna("Observación", pos, 200)
         .Columns("MensajeError").FormatearColumna("Mensaje de error", pos, 400, , True)
      End With

      ugdBanco.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaDepositoBancario(ugdDepositosBancarios As UltraGrid)

      If ugdDepositosBancarios.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In ugdDepositosBancarios.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With ugdDepositosBancarios.DisplayLayout.Bands(0)
         If Not .Columns.Exists("Ver") Then
            .Columns.Insert(0, "Ver")
         End If
         Dim pos As Integer = 0

         .Columns("Ver").FormatearColumna("Ver", pos, 30).Style = ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = ButtonDisplayStyle.Always

         .Columns("IdSucursal").FormatearColumna("Suc.", pos, 30, HAlign.Right)
         .Columns("IdCaja").FormatearColumna("Caja", pos, 40, HAlign.Right)
         .Columns("NombreCuenta").FormatearColumna("Cuenta Bancaria", pos, 100)
         .Columns("IdTipoComprobante").FormatearColumna("Tipo", pos, 90)
         .Columns("NumeroDeposito").FormatearColumna("Número", pos, 70, HAlign.Right)
         .Columns("Fecha").FormatearColumna("Fecha", pos, 70, HAlign.Center, , Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("ImporteTotal").FormatearColumna("Importe Total", pos, 100, HAlign.Right, , Formatos.Format.Decimales2)
         .Columns("ImportePesos").FormatearColumna("Pesos", pos, 100, HAlign.Right, , Formatos.Format.Decimales2)
         .Columns("ImporteCheques").FormatearColumna("Cheques", pos, 100, HAlign.Right, , Formatos.Format.Decimales2)
         .Columns("Observacion").FormatearColumna("Observacion", pos, 200)

         '.Columns("MensajeError").Header.Caption = "Mensaje de error"
         '.Columns("MensajeError").Width = 400
      End With

      ugdDepositosBancarios.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub


   Private Sub chbTodos_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor

         For i As Integer = 0 To chkprocesos.Items.Count - 1
            chkprocesos.SetItemChecked(i, chbTodos.Checked)
         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tbcResultados_Selected(sender As Object, e As TabControlEventArgs) Handles tbcResultados.Selected
      Me.ContarRegistros()
   End Sub

   Private Sub ContarRegistros()
      If (Me.tbcResultados.TabPages.Count > 0) Then
         Select Case Me.tbcResultados.SelectedTab.Name
            Case "tbpFacturasVentas"
               Me.tssRegistros.Text = ugdVentas.Rows.Count.ToString() & " Registros"
            Case "tbpCuentaCorriente"
               Me.tssRegistros.Text = ugdCtaCteClientes.Rows.Count.ToString() & " Registros"
            Case "tbpFacturasComprasStock"
               Me.tssRegistros.Text = ugdCompras.Rows.Count.ToString() & " Registros"
            Case "tbpPagosAProveedores"
               Me.tssRegistros.Text = ugdCtaCteProveedores.Rows.Count.ToString() & " Registros"
            Case "tbpCaja"
               Me.tssRegistros.Text = ugdCaja.Rows.Count.ToString() & " Registros"
            Case "tbpBanco"
               Me.tssRegistros.Text = ugdBanco.Rows.Count.ToString() & " Registros"
            Case "tbpDepositosBancarios"
               Me.tssRegistros.Text = ugdDepositosBancarios.Rows.Count.ToString() & " Registros"
         End Select
      Else
         Me.tssRegistros.Text = "0 Registros"
      End If
   End Sub

   Private Sub ugdVentas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugdVentas.InitializeRow
      Try
         e.Row.Cells("Ver").Value = "..."
         e.Row.Cells("Ver").ButtonAppearance.TextHAlign = HAlign.Center
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugdCtaCteClientes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugdCtaCteClientes.InitializeRow
      Try
         e.Row.Cells("Ver").Value = "..."
         e.Row.Cells("Ver").ButtonAppearance.TextHAlign = HAlign.Center
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugdCompras_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugdCompras.InitializeRow
      Try
         e.Row.Cells("Ver").Value = "..."
         e.Row.Cells("Ver").ButtonAppearance.TextHAlign = HAlign.Center
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugdCtaCteProveedores_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugdCtaCteProveedores.InitializeRow
      Try
         e.Row.Cells("Ver").Value = "..."
         e.Row.Cells("Ver").ButtonAppearance.TextHAlign = HAlign.Center
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub tsbVincularAsientoManual_Click(sender As Object, e As EventArgs) Handles tsbVincularAsientoManual.Click
      Try
         Dim datos As GenerarAsientoHistorialVincular.DatosParaVincular = MovimientoSeleccionado()
         If datos.dr Is Nothing Then
            Throw New Exception("No ha seleccionado un movimiento a vincular. Por favor seleccione uno y reintente.")
         End If

         Using frm As GenerarAsientoHistorialVincular = New GenerarAsientoHistorialVincular()
            If frm.ShowDialog(Me, datos) = Windows.Forms.DialogResult.OK Then

               Dim rContabilidad As Reglas.ContabilidadAsientosTmp = New Reglas.ContabilidadAsientosTmp()
               rContabilidad.VincularMovimientoAsientoManual(ModuloSeleccionado(), datos.dr, frm.IdEjercicio, frm.IdPlanCuenta, frm.IdAsiento)

               btnConsultar.PerformClick()
            End If
         End Using

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function ModuloSeleccionado() As Entidades.ContabilidadProceso.Procesos
      If tbcResultados.SelectedTab.Equals(tbpFacturasVentas) Then
         Return Entidades.ContabilidadProceso.Procesos.VENTAS
      ElseIf tbcResultados.SelectedTab.Equals(tbpCuentaCorriente) Then
         Return Entidades.ContabilidadProceso.Procesos.CuentaCte
      ElseIf tbcResultados.SelectedTab.Equals(tbpFacturasComprasStock) Then
         Return Entidades.ContabilidadProceso.Procesos.COMPRAS
      ElseIf tbcResultados.SelectedTab.Equals(tbpPagosAProveedores) Then
         Return Entidades.ContabilidadProceso.Procesos.PagoProv


      ElseIf tbcResultados.SelectedTab.Equals(tbpCaja) Then
         Return Entidades.ContabilidadProceso.Procesos.MOVCAJA
      ElseIf tbcResultados.SelectedTab.Equals(tbpBanco) Then
         Return Entidades.ContabilidadProceso.Procesos.MOVBANCO
      ElseIf tbcResultados.SelectedTab.Equals(tbpDepositosBancarios) Then
         Return Entidades.ContabilidadProceso.Procesos.MANUALES
      End If
      Return Nothing
   End Function

   Private Function MovimientoSeleccionado() As GenerarAsientoHistorialVincular.DatosParaVincular

      If tbcResultados.SelectedTab.Equals(tbpFacturasVentas) Then
         Return New GenerarAsientoHistorialVincular.DatosParaVincular(ugdVentas.FilaSeleccionada(Of DataRow)(), Sub(x) ConfigurarGrillaVentas(x))
      ElseIf tbcResultados.SelectedTab.Equals(tbpCuentaCorriente) Then
         Return New GenerarAsientoHistorialVincular.DatosParaVincular(ugdCtaCteClientes.FilaSeleccionada(Of DataRow)(), Sub(x) ConfigurarGrillaCuentaCorriente(x))
      ElseIf tbcResultados.SelectedTab.Equals(tbpFacturasComprasStock) Then
         Return New GenerarAsientoHistorialVincular.DatosParaVincular(ugdCompras.FilaSeleccionada(Of DataRow)(), Sub(x) ConfigurarGrillaCuentaFacturasCompras(x))
      ElseIf tbcResultados.SelectedTab.Equals(tbpPagosAProveedores) Then
         Return New GenerarAsientoHistorialVincular.DatosParaVincular(ugdCtaCteProveedores.FilaSeleccionada(Of DataRow)(), Sub(x) ConfigurarGrillaPagoProveedores(x))


      ElseIf tbcResultados.SelectedTab.Equals(tbpCaja) Then
         Return New GenerarAsientoHistorialVincular.DatosParaVincular(ugdCaja.FilaSeleccionada(Of DataRow)(), Sub(x) ConfigurarGrillaCaja(x))
      ElseIf tbcResultados.SelectedTab.Equals(tbpBanco) Then
         Return New GenerarAsientoHistorialVincular.DatosParaVincular(ugdBanco.FilaSeleccionada(Of DataRow)(), Sub(x) ConfigurarGrillaBanco(x))
      ElseIf tbcResultados.SelectedTab.Equals(tbpDepositosBancarios) Then
         Return New GenerarAsientoHistorialVincular.DatosParaVincular(ugdDepositosBancarios.FilaSeleccionada(Of DataRow)(), Sub(x) ConfigurarGrillaDepositoBancario(x))

      Else
         Return Nothing
      End If
   End Function

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(
         Sub()
            If Me.chkprocesos.CheckedItems.Count = 0 Then Exit Sub
            Dim excelExport = New UltraGridExportarExcel(UltraGridExcelExporter1, Reglas.Publicos.NombreEmpresa)
            excelExport.Exportar(String.Format("{0}.xls", Me.Name), GetGrillasExportar(), CargarFiltrosImpresion())
         End Sub)
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(
         Sub()
            If Me.chkprocesos.CheckedItems.Count = 0 Then Exit Sub

            Dim excelExport = New UltraGridExportarPDF(UltraGridDocumentExporter1, Reglas.Publicos.NombreEmpresa)
            excelExport.Exportar(String.Format("{0}.pdf", Me.Name), GetGrillasExportar(), CargarFiltrosImpresion())
         End Sub)
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro
         .AppendFormat(" Fecha Desde: {0} - ", Me.dtpDesde.Text)
         .AppendFormat(" Fecha Hasta: {0} - ", Me.dtpHasta.Text)
      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function
   Private Function GetGrillasExportar() As UltraGridExportTituloGrilla()
      Dim result As List(Of UltraGridExportTituloGrilla) = New List(Of UltraGridExportTituloGrilla)()
      For Each item As Object In chkprocesos.CheckedItems
         Select Case item.ToString()
            Case "Ventas"
               result.Add(New UltraGridExportTituloGrilla() With {.Grilla = ugdVentas, .Titulo = String.Format("{0} - {1}", Me.Text, tbpFacturasVentas.Text), .NombreHoja = tbpFacturasVentas.Text})
            Case "CC. Clientes"
               result.Add(New UltraGridExportTituloGrilla() With {.Grilla = ugdCtaCteClientes, .Titulo = String.Format("{0} - {1}", Me.Text, tbpCuentaCorriente.Text), .NombreHoja = tbpCuentaCorriente.Text})
            Case "Compras"
               result.Add(New UltraGridExportTituloGrilla() With {.Grilla = ugdCompras, .Titulo = String.Format("{0} - {1}", Me.Text, tbpFacturasComprasStock.Text), .NombreHoja = tbpFacturasComprasStock.Text})
            Case "CC. Proveedores"
               result.Add(New UltraGridExportTituloGrilla() With {.Grilla = ugdCtaCteProveedores, .Titulo = String.Format("{0} - {1}", Me.Text, tbpPagosAProveedores.Text), .NombreHoja = tbpPagosAProveedores.Text})
            Case "Caja"
               result.Add(New UltraGridExportTituloGrilla() With {.Grilla = ugdCaja, .Titulo = String.Format("{0} - {1}", Me.Text, tbpCaja.Text), .NombreHoja = tbpCaja.Text})
            Case "Bancos"
               result.Add(New UltraGridExportTituloGrilla() With {.Grilla = ugdBanco, .Titulo = String.Format("{0} - {1}", Me.Text, tbpBanco.Text), .NombreHoja = tbpBanco.Text})
            Case "Dep./Extracc./Transf."
               result.Add(New UltraGridExportTituloGrilla() With {.Grilla = ugdDepositosBancarios, .Titulo = String.Format("{0} - {1}", Me.Text, tbpDepositosBancarios.Text), .NombreHoja = Replace(tbpDepositosBancarios.Text, "/", "")})
         End Select
      Next
      Return result.ToArray()
   End Function

   Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
      TryCatched(
         Sub()
            If Me.chkprocesos.CheckedItems.Count = 0 Then Exit Sub

            Dim ugdetalle As UltraGrid
            If tbcResultados.SelectedTab.Equals(tbpFacturasVentas) Then
               ugdetalle = ugdVentas
            ElseIf tbcResultados.SelectedTab.Equals(tbpCuentaCorriente) Then
               ugdetalle = ugdCtaCteClientes
            ElseIf tbcResultados.SelectedTab.Equals(tbpFacturasComprasStock) Then
               ugdetalle = ugdCompras
            ElseIf tbcResultados.SelectedTab.Equals(tbpPagosAProveedores) Then
               ugdetalle = ugdCtaCteProveedores
            ElseIf tbcResultados.SelectedTab.Equals(tbpCaja) Then
               ugdetalle = ugdCaja
            ElseIf tbcResultados.SelectedTab.Equals(tbpBanco) Then
               ugdetalle = ugdBanco
            ElseIf tbcResultados.SelectedTab.Equals(tbpDepositosBancarios) Then
               ugdetalle = ugdDepositosBancarios
            Else
               Exit Sub
            End If

            ugdetalle.Exportar(String.Format("{0}_{1}.xls", Me.Name, Replace(tbcResultados.SelectedTab.Text, "/", "")), String.Format("{0} - {1}", Me.Text, tbcResultados.SelectedTab.Text),
                               UltraGridExcelExporter1, CargarFiltrosImpresion())
         End Sub)
   End Sub

   Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
      TryCatched(
         Sub()
            If Me.chkprocesos.CheckedItems.Count = 0 Then Exit Sub

            Dim ugdetalle As UltraGrid
            If tbcResultados.SelectedTab.Equals(tbpFacturasVentas) Then
               ugdetalle = ugdVentas
            ElseIf tbcResultados.SelectedTab.Equals(tbpCuentaCorriente) Then
               ugdetalle = ugdCtaCteClientes
            ElseIf tbcResultados.SelectedTab.Equals(tbpFacturasComprasStock) Then
               ugdetalle = ugdCompras
            ElseIf tbcResultados.SelectedTab.Equals(tbpPagosAProveedores) Then
               ugdetalle = ugdCtaCteProveedores
            ElseIf tbcResultados.SelectedTab.Equals(tbpCaja) Then
               ugdetalle = ugdCaja
            ElseIf tbcResultados.SelectedTab.Equals(tbpBanco) Then
               ugdetalle = ugdBanco
            ElseIf tbcResultados.SelectedTab.Equals(tbpDepositosBancarios) Then
               ugdetalle = ugdDepositosBancarios
            Else
               Exit Sub
            End If

            ugdetalle.Exportar(String.Format("{0}_{1}.pdf", Me.Name, Replace(tbcResultados.SelectedTab.Text, "/", "")), String.Format("{0} - {1}", Me.Text, tbcResultados.SelectedTab.Text),
                               UltraGridDocumentExporter1, CargarFiltrosImpresion())
         End Sub)
   End Sub
End Class