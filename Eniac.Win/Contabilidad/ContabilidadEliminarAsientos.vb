#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
#End Region
Public Class ContabilidadEliminarAsientos

   Private Paginas As List(Of TabPage) = New List(Of TabPage)()
   Private _publicos As Publicos

#Region "Eventos"

   Private Sub ugdPagosAProveedores_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugdCtaCteProveedores.ClickCellButton

      If e.Cell.Row.Index <> -1 Then
         Try
            Me.Cursor = Cursors.WaitCursor
            Dim reg As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()

            Select Case Me.ugdCtaCteClientes.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Key
               Case Is = "Ver"

                  Dim ctacte As Entidades.CuentaCorrienteProv = reg.GetUna(Integer.Parse(Me.ugdCtaCteProveedores.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()), _
                          Long.Parse(Me.ugdCtaCteProveedores.Rows(e.Cell.Row.Index).Cells("IdProveedor").Value.ToString()), _
                          Me.ugdCtaCteProveedores.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                          Me.ugdCtaCteProveedores.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                          Int32.Parse(Me.ugdCtaCteProveedores.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                          Long.Parse(Me.ugdCtaCteProveedores.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))

                  Dim imp As PagosImprimir = New PagosImprimir()
                  imp.ImprimirPago(ctacte, True)

            End Select
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub

   Private Sub ugdFacturasComprasStock_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugdCompras.ClickCellButton

      If e.Cell.Row.Index <> -1 Then
         Try
            Me.Cursor = Cursors.WaitCursor
            Dim oCompras As Reglas.Compras = New Reglas.Compras()

            Select Case Me.ugdCompras.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Key

               Case Is = "Ver"

                  Dim Compra As Entidades.Compra = oCompras.GetUna(Integer.Parse(e.Cell.Row.Cells("IdSucursal").Value.ToString()), _
                        e.Cell.Row.Cells("IdTipoComprobante").Value.ToString(), _
                        e.Cell.Row.Cells("Letra").Value.ToString(), _
                        Short.Parse(e.Cell.Row.Cells("CentroEmisor").Value.ToString()), _
                        Long.Parse(e.Cell.Row.Cells("NumeroComprobante").Value.ToString()), _
                        Long.Parse(e.Cell.Row.Cells("IdProveedor").Value.ToString()))

                  Dim oImpr As ImpresionCompra = New ImpresionCompra(Compra)

                  oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)

            End Select

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If
   End Sub

   Private Sub ugdCuentaCorriente_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugdCtaCteClientes.ClickCellButton
      If e.Cell.Row.Index <> -1 Then
         Try
            Me.Cursor = Cursors.WaitCursor
            Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

            Select Case Me.ugdCtaCteClientes.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Key
               Case Is = "Ver"

                  Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(Integer.Parse(Me.ugdCtaCteClientes.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()), _
                          Me.ugdCtaCteClientes.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                          Me.ugdCtaCteClientes.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                          Int32.Parse(Me.ugdCtaCteClientes.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                          Long.Parse(Me.ugdCtaCteClientes.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))
                  Dim imp As RecibosImprimir = New RecibosImprimir()
                  imp.ImprimirRecibo(ctacte, True)

            End Select
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If
   End Sub

   Private Sub ugdVentas_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugdVentas.ClickCellButton

      If e.Cell.Row.Index <> -1 Then

         Try
            Me.Cursor = Cursors.WaitCursor
            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

            Select Case Me.ugdVentas.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Key

               Case Is = "Ver"

                  Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(Me.ugdVentas.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()), _
                              Me.ugdVentas.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.ugdVentas.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.ugdVentas.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.ugdVentas.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))


                  Dim oImpr As Impresion = New Impresion(venta)
                  If venta.Impresora.TipoImpresora = "NORMAL" Then
                     Dim ReporteEstandar As Boolean = False
                     oImpr.ImprimirComprobanteNoFiscal(True, ReporteEstandar)

                     'If venta.Percepciones IsNot Nothing Then
                     '   For Each perc As Entidades.PercepcionVenta In venta.Percepciones
                     '      If perc.ImporteTotal <> 0 Then
                     '         Dim ret As PercepcionImprimir = New PercepcionImprimir()
                     '         ret.ImprimirPercepcion(venta, perc)
                     '      End If
                     '   Next
                     'End If

                  Else
                     oImpr.ReImprimirComprobanteFiscal()
                  End If
                  'If Me.ugdFacturasVentas.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Header.Caption <> "Imp" Then


                  'Else
                  '   If venta.Impresora.TipoImpresora = "NORMAL" Then

                  '      oImpr.ImprimirComprobanteNoFiscal(False)

                  '   ElseIf Not venta.TipoComprobante.GrabaLibro Then

                  '      Dim fc As FacturacionComunes = New FacturacionComunes()
                  '      fc.ImprimirComprobante(venta, venta.TipoComprobante.EsFiscal)

                  '   Else
                  '      MessageBox.Show("No es posible Reimprimir en la Impresora Fiscal un Comprobante FISCAL.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  '   End If

                  'End If

            End Select

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub

#End Region

#Region "Metodos Privados"
   Private Function ValidarProceso() As Boolean
      If Me.chkprocesos.CheckedItems.Count = 0 Then
         Return False
      End If
      Return True
   End Function

   Private Sub ConcatenarMensaje(mensaje As StringBuilder, resultado As Reglas.ContabilidadProcesos.ResultadoProcesoHistorico, proceso As String, grilla As Infragistics.Win.UltraWinGrid.UltraGrid)
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
      Me.tslInfo.Text = "Procesando " + proceso
      Application.DoEvents()
      Me.tspBarra.Minimum = 0
      Me.tspBarra.Value = 0
      Me.tspBarra.Maximum = dt.Rows.Count
   End Sub

   Private Function GetDataRow(grilla As UltraGrid) As DataRow()
      If TypeOf (grilla.DataSource) Is DataTable Then
         Return DirectCast(grilla.DataSource, DataTable).Select(String.Format("{0}", SelecColumnName))
      End If
      Return {}
   End Function

   Private Sub UpdateDataGrillas()
      ugdVentas.UpdateData()
      ugdCtaCteClientes.UpdateData()
      ugdCompras.UpdateData()
      ugdCtaCteProveedores.UpdateData()
      ugdCaja.UpdateData()
      ugdBanco.UpdateData()
      ugdDepositosBancarios.UpdateData()
   End Sub

   Private Sub Procesar()

      UpdateDataGrillas()

      Dim modulo As String = String.Empty
      Dim drCol As DataRow() = {}

      If tbcResultados.SelectedTab.Equals(tbpFacturasVentas) Then
         modulo = "Ventas"
         drCol = GetDataRow(ugdVentas)
      ElseIf tbcResultados.SelectedTab.Equals(tbpCuentaCorriente) Then
         modulo = "CuentasCorrientes"
         drCol = GetDataRow(ugdCtaCteClientes)
      ElseIf tbcResultados.SelectedTab.Equals(tbpFacturasComprasStock) Then
         modulo = "Compras"
         drCol = GetDataRow(ugdCompras)
      ElseIf tbcResultados.SelectedTab.Equals(tbpPagosAProveedores) Then
         modulo = "CuentasCorrientesProv"
         drCol = GetDataRow(ugdCtaCteProveedores)
      ElseIf tbcResultados.SelectedTab.Equals(tbpCaja) Then
         modulo = "CajasDetalle"
         drCol = GetDataRow(ugdCaja)
      ElseIf tbcResultados.SelectedTab.Equals(tbpBanco) Then
         modulo = "LibrosBancos"
         drCol = GetDataRow(ugdBanco)
      ElseIf tbcResultados.SelectedTab.Equals(tbpDepositosBancarios) Then
         modulo = "Depositos"
         drCol = GetDataRow(ugdDepositosBancarios)
      Else

      End If

      If Not String.IsNullOrWhiteSpace(modulo) AndAlso drCol IsNot Nothing Then
         If ShowPregunta(String.Format("¿Desea eliminar los {1} asientos seleccionados de {0} seleccionado?", modulo, drCol.Length)) = Windows.Forms.DialogResult.Yes Then
            Dim oProcesoContable As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos(tspBarra, tstAvance)
            oProcesoContable.EliminaAsiento(modulo, drCol)
            ShowMessage("Asientos eliminado exitosamente.")
            btnConsultar.PerformClick()
         End If
      End If
   End Sub

#End Region


#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)
      Try
         Me.dtpHasta.Value = Date.Now.AddMonths(1)
         Me.dtpDesde.Value = Date.Now

         Me._publicos = New Publicos()
         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      If Eniac.Reglas.ContabilidadPublicos.ContabilidadCuentaRedondeo = 0 Then
         MessageBox.Show("Debe setear la cuenta <Cuenta para Diferencias por Redondeo> desde Parametros del Sistema.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Close()
      End If
   End Sub

#End Region

#Region "Eventos"
#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Dim ugDetalle As UltraGrid

      If tbcResultados.SelectedTab.Equals(tbpFacturasVentas) Then
         ugDetalle = ugdVentas
      ElseIf tbcResultados.SelectedTab.Equals(tbpCuentaCorriente) Then
         ugDetalle = ugdCtaCteClientes
      ElseIf tbcResultados.SelectedTab.Equals(tbpFacturasComprasStock) Then
         ugDetalle = ugdCompras
      ElseIf tbcResultados.SelectedTab.Equals(tbpPagosAProveedores) Then
         ugDetalle = ugdCtaCteProveedores
      ElseIf tbcResultados.SelectedTab.Equals(tbpCaja) Then
         ugDetalle = ugdCaja
      ElseIf tbcResultados.SelectedTab.Equals(tbpBanco) Then
         ugDetalle = ugdBanco
      ElseIf tbcResultados.SelectedTab.Equals(tbpDepositosBancarios) Then
         ugDetalle = ugdDepositosBancarios
      Else
         Exit Sub
      End If

      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnum Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnum)
               Case Reglas.Publicos.TodosEnum.MararTodos
                  MarcarDesmarcar(True, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos

               Case Reglas.Publicos.TodosEnum.DesmarcarTodos
                  MarcarDesmarcar(False, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

               Case Reglas.Publicos.TodosEnum.MarcarFiltrados
                  MarcarDesmarcar(True, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarFiltrados

               Case Reglas.Publicos.TodosEnum.DesmarcarFiltrados
                  MarcarDesmarcar(False, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MarcarFiltrados

               Case Reglas.Publicos.TodosEnum.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.ToArray())

               Case Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.GetFilteredInNonGroupByRows())

               Case Else

            End Select
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         ugDetalle.UpdateData()
      End Try
   End Sub
   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         If marcar.HasValue Then
            dr.Cells(SelecColumnName).Value = marcar.Value
         Else
            dr.Cells(SelecColumnName).Value = Not CBool(dr.Cells(SelecColumnName).Value)
         End If
      Next
   End Sub
#End Region
#End Region

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbGenerarAsientos_Click(sender As Object, e As EventArgs) Handles tsbEliminarAsientos.Click
      Try
         tsbEliminarAsientos.Enabled = False

         If Me.ValidarProceso() Then
            Me.Procesar()
         End If
      Catch ex As Exception
         ShowError(ex, True)
         'Dim men As String = ex.Message
         'If ex.InnerException IsNot Nothing Then
         '   men += Chr(Keys.Enter) + ex.InnerException.Message
         'End If
         'MessageBox.Show(men, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         tsbEliminarAsientos.Enabled = True
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try

         Me.dtpHasta.Value = Date.Now.AddMonths(1)
         Me.dtpDesde.Value = Date.Now

         Me.cmbTodos.SelectedIndex = 0

         Me.chbTodos.Checked = False
         'Hago esto porque podria estar false con algunos chequeados.
         For i As Integer = 0 To chkprocesos.Items.Count - 1
            Me.chkprocesos.SetItemChecked(i, False)
         Next
         'Oculto todas las solapas.
         For Each Pagina As TabPage In tbcResultados.TabPages
            MostrarPagina(Pagina, False)
         Next

         Me.tslInfo.Text = ""

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Const SelecColumnName As String = "selec"

   Private Function AgregarProcesadoMensaje(dt As DataTable) As DataTable
      Dim dc As DataColumn

      If Not dt.Columns.Contains(SelecColumnName) Then
         dc = New DataColumn(SelecColumnName, GetType(Boolean))
         dc.DefaultValue = False
         dt.Columns.Add(dc)
      End If

      If Not dt.Columns.Contains("Procesado") Then
         dc = New DataColumn("Procesado", GetType(Boolean))
         dc.DefaultValue = False
         dt.Columns.Add(dc)
      End If

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
      Try
         Dim reg As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos()

         LimpiarGrilla(Me.ugdVentas)
         LimpiarGrilla(Me.ugdCtaCteClientes)
         LimpiarGrilla(Me.ugdCompras)
         LimpiarGrilla(Me.ugdCtaCteProveedores)
         LimpiarGrilla(Me.ugdCaja)
         LimpiarGrilla(Me.ugdBanco)
         LimpiarGrilla(Me.ugdDepositosBancarios)

         For Each Pagina As TabPage In tbcResultados.TabPages
            MostrarPagina(Pagina, False)
         Next

         Dim blnConAsiento As Boolean = True

         Dim intNumeroAsiento As Integer = 0
         If Me.chbNumeroAsiento.Checked Then
            intNumeroAsiento = Integer.Parse("0" + Me.txtNumeroAsiento.Text)
         End If

         For i As Integer = 0 To Me.chkprocesos.CheckedItems.Count - 1
            Select Case Me.chkprocesos.CheckedItems(i).ToString
               Case "Ventas"
                  MostrarPagina(tbpFacturasVentas, True)
                  Me.ugdVentas.DataSource = AgregarProcesadoMensaje(reg.ObtenerDatosVentas(Me.dtpDesde.Value, Me.dtpHasta.Value, blnConAsiento, intNumeroAsiento))
                  Me.ConfigurarGrillaVentas()

               Case "CC. Clientes"
                  MostrarPagina(tbpCuentaCorriente, True)
                  Me.ugdCtaCteClientes.DataSource = AgregarProcesadoMensaje(reg.ObtenerDatosCtaCteClte(Me.dtpDesde.Value, Me.dtpHasta.Value, blnConAsiento, intNumeroAsiento))
                  Me.ConfigurarGrillaCuentaCorriente()

               Case "Compras"
                  MostrarPagina(tbpFacturasComprasStock, True)
                  Me.ugdCompras.DataSource = AgregarProcesadoMensaje(reg.ObtenerDatosCompras(Me.dtpDesde.Value, Me.dtpHasta.Value, blnConAsiento, intNumeroAsiento))
                  Me.ConfigurarGrillaCuentaFacturasCompras()

               Case "CC. Proveedores"
                  MostrarPagina(tbpPagosAProveedores, True)
                  Me.ugdCtaCteProveedores.DataSource = AgregarProcesadoMensaje(reg.ObtenerDatosCtaCteProv(Me.dtpDesde.Value, Me.dtpHasta.Value, blnConAsiento, intNumeroAsiento))
                  Me.ConfigurarGrillaPagoProveedores()

               Case "Caja"
                  'busco los movimientos de caja que no tienen fecha de Periodo Contable
                  MostrarPagina(tbpCaja, True)
                  Me.ugdCaja.DataSource = AgregarProcesadoMensaje(reg.ObtenerDatosCaja(Me.dtpDesde.Value, Me.dtpHasta.Value, blnConAsiento, intNumeroAsiento))
                  Me.ConfigurarGrillaCaja()

               Case "Bancos"
                  MostrarPagina(tbpBanco, True)
                  Me.ugdBanco.DataSource = AgregarProcesadoMensaje(reg.ObtenerDatosLibroBanco(Me.dtpDesde.Value, Me.dtpHasta.Value, blnConAsiento, intNumeroAsiento))
                  Me.ConfigurarGrillaBanco()

               Case "Dep./Extracc./Transf."
                  MostrarPagina(tbpDepositosBancarios, True)
                  Me.ugdDepositosBancarios.DataSource = AgregarProcesadoMensaje(reg.ObtenerDatosDepositosBancarios(Me.dtpDesde.Value, Me.dtpHasta.Value, blnConAsiento, intNumeroAsiento))
                  Me.ConfigurarGrillaDepositoBancario()

            End Select
         Next
         OrdenarPaginas(Me.tbcResultados)
         ContarRegistros()

         Me.cmbTodos.SelectedIndex = 0

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub MostrarPagina(ByVal pagina As TabPage, ByVal mostrar As Boolean)
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
      Dim ListaDePaginas As List(Of TabPage) = ContenedorPaginas.TabPages.Cast(Of TabPage).ToList()
      ListaDePaginas.Sort(New ComparadorDePaginas())
      ContenedorPaginas.TabPages.Clear()
      ContenedorPaginas.TabPages.AddRange(ListaDePaginas.ToArray())
   End Sub

   Public Class ComparadorDePaginas
      Implements IComparer(Of TabPage)
      Public Function Compare(x As TabPage, y As TabPage) As Integer Implements IComparer(Of TabPage).Compare
         Return String.Compare(x.Tag.ToString(), y.Tag.ToString())
      End Function
   End Class

   Private Sub ConfigurarGrillaVentas() 'VENTAS

      If Me.ugdVentas.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugdVentas.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With Me.ugdVentas.DisplayLayout.Bands(0)

         If Not .Columns.Exists("Ver") Then
            .Columns.Insert(0, "Ver")
         End If

         Dim col As Integer = 0

         .Columns(SelecColumnName).FormatearColumna("Sel", col, 30, HAlign.Center, , , , Activation.AllowEdit).Style = ColumnStyle.CheckBox

         .Columns("Ver").FormatearColumna("Ver", col, 30, HAlign.Center).Style = ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = ButtonDisplayStyle.Always

         .Columns("IdSucursal").FormatearColumna("Suc.", col, 30, HAlign.Right)
         .Columns("IdTipoComprobante").FormatearColumna("Tipo", col, 80)
         .Columns("Letra").FormatearColumna("L", col, 20)
         .Columns("CentroEmisor").FormatearColumna("Emisor", col, 50, HAlign.Right)
         .Columns("NumeroComprobante").FormatearColumna("Número", col, 70, HAlign.Right)
         .Columns("Fecha").FormatearColumna("Fecha", col, 70, HAlign.Center, False, Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("ImporteTotal").FormatearColumna("Total", col, 100, HAlign.Right, , "N2")
         .Columns("CodigoCliente").FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns("NombreCliente").FormatearColumna("Cliente", col, 150)
         .Columns("IdPlanCuenta").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsiento").FormatearColumna("Asiento", col, 70, HAlign.Right)

         .Columns("IdPlanCuentaDefinitivo").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsientoDefinitivo").FormatearColumna("Asiento Definitivo", col, 70, HAlign.Right)

         .Columns("MensajeError").FormatearColumna("Mensaje de error", col, 400, , True)

         ugdVentas.AgregarFiltroEnLinea({"NombreCliente", "MensajeError"})
      End With

      Me.ugdVentas.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaCuentaCorriente() 'CC CLIENTE

      If Me.ugdCtaCteClientes.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugdCtaCteClientes.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With Me.ugdCtaCteClientes.DisplayLayout.Bands(0)

         If Not .Columns.Exists("Ver") Then
            .Columns.Insert(0, "Ver")
         End If

         Dim col As Integer = 0

         .Columns(SelecColumnName).FormatearColumna("Sel", col, 30, HAlign.Center, , , , Activation.AllowEdit).Style = ColumnStyle.CheckBox

         .Columns("Ver").FormatearColumna("Ver", col, 30, HAlign.Center).Style = ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = ButtonDisplayStyle.Always

         .Columns("IdSucursal").FormatearColumna("Suc.", col, 30, HAlign.Right)
         .Columns("IdTipoComprobante").FormatearColumna("Tipo", col, 80)
         .Columns("Letra").FormatearColumna("L", col, 20)
         .Columns("CentroEmisor").FormatearColumna("Emisor", col, 50, HAlign.Right)
         .Columns("NumeroComprobante").FormatearColumna("Número", col, 70, HAlign.Right)
         .Columns("Fecha").FormatearColumna("Fecha", col, 70, HAlign.Center, False, Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("ImporteTotal").FormatearColumna("Total", col, 100, HAlign.Right, , "N2")
         .Columns("CodigoCliente").FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns("NombreCliente").FormatearColumna("Cliente", col, 150)
         .Columns("IdPlanCuenta").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsiento").FormatearColumna("Asiento", col, 70, HAlign.Right)

         .Columns("IdPlanCuentaDefinitivo").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsientoDefinitivo").FormatearColumna("Asiento Definitivo", col, 70, HAlign.Right)

         .Columns("MensajeError").FormatearColumna("Mensaje de error", col, 400, , True)

         ugdVentas.AgregarFiltroEnLinea({"NombreCliente", "MensajeError"})
      End With

      Me.ugdCtaCteClientes.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaCuentaFacturasCompras() 'COMPRAS

      If Me.ugdCompras.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugdCompras.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With Me.ugdCompras.DisplayLayout.Bands(0)

         If Not .Columns.Exists("Ver") Then
            .Columns.Insert(0, "Ver")
         End If

         Dim col As Integer = 0

         .Columns(SelecColumnName).FormatearColumna("Sel", col, 30, HAlign.Center, , , , Activation.AllowEdit).Style = ColumnStyle.CheckBox

         .Columns("Ver").FormatearColumna("Ver", col, 30, HAlign.Center).Style = ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = ButtonDisplayStyle.Always

         .Columns("IdSucursal").FormatearColumna("Suc.", col, 30, HAlign.Right)
         .Columns("IdTipoComprobante").FormatearColumna("Tipo", col, 80)
         .Columns("Letra").FormatearColumna("L", col, 20)
         .Columns("CentroEmisor").FormatearColumna("Emisor", col, 50, HAlign.Right)
         .Columns("NumeroComprobante").FormatearColumna("Número", col, 70, HAlign.Right)
         .Columns("Fecha").FormatearColumna("Fecha", col, 70, HAlign.Center, False, Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("ImporteTotal").FormatearColumna("Total", col, 100, HAlign.Right, , "N2")
         .Columns("CodigoProveedor").FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns("NombreProveedor").FormatearColumna("Proveedor", col, 150)
         .Columns("IdPlanCuenta").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsiento").FormatearColumna("Asiento", col, 70, HAlign.Right)

         .Columns("IdPlanCuentaDefinitivo").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsientoDefinitivo").FormatearColumna("Asiento Definitivo", col, 70, HAlign.Right)

         .Columns("MensajeError").FormatearColumna("Mensaje de error", col, 400, , True)

         ugdVentas.AgregarFiltroEnLinea({"NombreProveedor", "MensajeError"})
      End With

      Me.ugdCompras.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaPagoProveedores() 'CC PROVEEDORES

      If Me.ugdCtaCteProveedores.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugdCtaCteProveedores.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With Me.ugdCtaCteProveedores.DisplayLayout.Bands(0)

         If Not .Columns.Exists("Ver") Then
            .Columns.Insert(0, "Ver")
         End If

         Dim col As Integer = 0

         .Columns(SelecColumnName).FormatearColumna("Sel", col, 30, HAlign.Center, , , , Activation.AllowEdit).Style = ColumnStyle.CheckBox

         .Columns("Ver").FormatearColumna("Ver", col, 30, HAlign.Center).Style = ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = ButtonDisplayStyle.Always

         .Columns("IdSucursal").FormatearColumna("Suc.", col, 30, HAlign.Right)
         .Columns("IdTipoComprobante").FormatearColumna("Tipo", col, 80)
         .Columns("Letra").FormatearColumna("L", col, 20)
         .Columns("CentroEmisor").FormatearColumna("Emisor", col, 50, HAlign.Right)
         .Columns("NumeroComprobante").FormatearColumna("Número", col, 70, HAlign.Right)
         .Columns("Fecha").FormatearColumna("Fecha", col, 70, HAlign.Center, False, Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("ImporteTotal").FormatearColumna("Total", col, 100, HAlign.Right, , "N2")
         .Columns("CodigoProveedor").FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns("NombreProveedor").FormatearColumna("Proveedor", col, 150)
         .Columns("IdPlanCuenta").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsiento").FormatearColumna("Asiento", col, 70, HAlign.Right)

         .Columns("IdPlanCuentaDefinitivo").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsientoDefinitivo").FormatearColumna("Asiento Definitivo", col, 70, HAlign.Right)

         .Columns("MensajeError").FormatearColumna("Mensaje de error", col, 400, , True)

         ugdVentas.AgregarFiltroEnLinea({"NombreProveedor", "MensajeError"})
      End With

      Me.ugdCtaCteProveedores.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaCaja()

      If Me.ugdCaja.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugdCaja.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With Me.ugdCaja.DisplayLayout.Bands(0)

         Dim col As Integer = 0

         .Columns(SelecColumnName).FormatearColumna("Sel", col, 30, HAlign.Center, , , , Activation.AllowEdit).Style = ColumnStyle.CheckBox

         .Columns("IdSucursal").FormatearColumna("Suc.", col, 30, HAlign.Right)

         .Columns("IdCaja").FormatearColumna("Caja", col, 40, HAlign.Right)
         .Columns("NumeroPlanilla").FormatearColumna("Planilla", col, 55, HAlign.Right)
         .Columns("NumeroMovimiento").FormatearColumna("Número", col, 70, HAlign.Right)
         .Columns("FechaMovimiento").FormatearColumna("Fecha", col, 70, HAlign.Center, False, Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("IdTipoMovimiento").FormatearColumna("T", col, 20)
         .Columns("NombreCuentaCaja").FormatearColumna("Cuenta Caja", col, 150)
         .Columns("ImportePesos").FormatearColumna("Pesos", col, 100, HAlign.Right, , "N2").MaxWidth = 100
         .Columns("ImporteCheques").FormatearColumna("Cheques", col, 100, HAlign.Right, , "N2").MaxWidth = 100
         .Columns("IdPlanCuenta").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsiento").FormatearColumna("Asiento", col, 70, HAlign.Right)

         .Columns("IdPlanCuentaDefinitivo").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsientoDefinitivo").FormatearColumna("Asiento Definitivo", col, 70, HAlign.Right)

         .Columns("MensajeError").FormatearColumna("Mensaje de error", col, 400, , True)

         ugdVentas.AgregarFiltroEnLinea({"NombreCuentaCaja", "MensajeError"})
      End With

      Me.ugdCaja.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaBanco()

      If Me.ugdBanco.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugdBanco.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With Me.ugdBanco.DisplayLayout.Bands(0)

         Dim col As Integer = 0

         .Columns(SelecColumnName).FormatearColumna("Sel", col, 30, HAlign.Center, , , , Activation.AllowEdit).Style = ColumnStyle.CheckBox

         .Columns("IdSucursal").FormatearColumna("Suc.", col, 30, HAlign.Right)

         .Columns("NombreCuenta").FormatearColumna("Cuenta Bancaria", col, 100)
         .Columns("NumeroMovimiento").FormatearColumna("Número", col, 70, HAlign.Right)
         .Columns("FechaMovimiento").FormatearColumna("Fecha", col, 70, HAlign.Center, False, Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("FechaAplicado").FormatearColumna("F. Aplicado", col, 70, HAlign.Center, False, Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("IdTipoMovimiento").FormatearColumna("T", col, 20)
         .Columns("Importe").FormatearColumna("Importe", col, 100, HAlign.Right, , "N2").MaxWidth = 100
         .Columns("Observacion").FormatearColumna("Observacion", col, 200)
         .Columns("IdPlanCuenta").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsiento").FormatearColumna("Asiento", col, 70, HAlign.Right)

         .Columns("IdPlanCuentaDefinitivo").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsientoDefinitivo").FormatearColumna("Asiento Definitivo", col, 70, HAlign.Right)

         .Columns("MensajeError").FormatearColumna("Mensaje de error", col, 400, , True)

         ugdVentas.AgregarFiltroEnLinea({"NombreCuenta", "MensajeError", "Observacion"})
      End With

      Me.ugdBanco.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub

   Private Sub ConfigurarGrillaDepositoBancario()

      If Me.ugdDepositosBancarios.DataSource Is Nothing Then
         Exit Sub
      End If

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugdDepositosBancarios.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.NoEdit
         col.Hidden = True
      Next

      'mostrar columnas a mostrar
      With Me.ugdDepositosBancarios.DisplayLayout.Bands(0)

         Dim col As Integer = 0

         .Columns(SelecColumnName).FormatearColumna("Sel", col, 30, HAlign.Center, , , , Activation.AllowEdit).Style = ColumnStyle.CheckBox

         .Columns("IdSucursal").FormatearColumna("Suc.", col, 30, HAlign.Right)

         .Columns("IdCaja").FormatearColumna("Caja", col, 40, HAlign.Right)
         .Columns("NombreCuenta").FormatearColumna("Cuenta Bancaria", col, 100)
         .Columns("IdTipoComprobante").FormatearColumna("Tipo", col, 90)
         .Columns("NumeroDeposito").FormatearColumna("Número", col, 70, HAlign.Right)
         .Columns("Fecha").FormatearColumna("Fecha", col, 70, HAlign.Center, False, Formatos.Format.FechaSinHora, Formatos.MaskInput.FechaSinHora)
         .Columns("ImporteTotal").FormatearColumna("Importe Total", col, 100, HAlign.Right, , "N2")
         .Columns("ImportePesos").FormatearColumna("Pesos", col, 100, HAlign.Right, , "N2")
         .Columns("ImporteCheques").FormatearColumna("Cheques", col, 100, HAlign.Right, , "N2")
         .Columns("Observacion").FormatearColumna("Observacion", col, 200)
         .Columns("IdPlanCuenta").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsiento").FormatearColumna("Asiento", col, 70, HAlign.Right)

         .Columns("IdPlanCuentaDefinitivo").FormatearColumna("Plan", col, 40, HAlign.Right)
         .Columns("IdAsientoDefinitivo").FormatearColumna("Asiento Definitivo", col, 70, HAlign.Right)

         '.Columns("MensajeError").FormatearColumna("Mensaje de error", col, 400, , True)

         ugdVentas.AgregarFiltroEnLinea({"NombreCuenta", "MensajeError", "Observacion"})
      End With

      Me.ugdDepositosBancarios.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn

   End Sub


   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
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


   Private Sub chbNumeroAsiento_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAsiento.CheckedChanged

      Me.txtNumeroAsiento.Enabled = Me.chbNumeroAsiento.Checked

      If Me.chbNumeroAsiento.Checked Then

         Me.txtNumeroAsiento.Focus()

      Else

         Me.txtNumeroAsiento.Text = String.Empty

      End If

   End Sub


End Class