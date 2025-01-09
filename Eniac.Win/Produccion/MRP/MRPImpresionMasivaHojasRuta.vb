Imports System.Windows.Forms.MonthCalendar
Imports Eniac.Entidades
Imports Eniac.Win.SincronizacionSubidaV2
Imports Infragistics.Documents.Reports.Report.Section

Public Class MRPImpresionMasivaHojasRuta

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()
         '-- Carga de todos lo combos de Filtrado.- -------------------------------------------
         CargaCombosFiltrado()
         '-- Inicializa los campos del Formulario.- -------------------------------------------
         InicializaCamposFiltrado()
         '-------------------------------------------------------------------------------------
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Select Case keyData
         Case Keys.F3
            btnConsultar.PerformClick()
         Case Keys.F4
            tsbImprimir.PerformClick()
         Case Keys.F5
            tsbRefrescar.PerformClick()
         Case Else
            Return MyBase.ProcessCmdKey(msg, keyData)
      End Select
      Return True
   End Function
#End Region

#Region "Metodos"
   ''' <summary>
   ''' Carga Valores de Combos de Inicio de Filtrado.-
   ''' </summary>
   Private Sub CargaCombosFiltrado()
      '-- Carga de todos lo combos de Filtrado.- -------------------------------------------
      With _publicos
         '-- Tipo de Impresion.- -----------------------------------------------------------
         .CargaComboDesdeEnum(Me.cmbTiposImpresiones, GetType(Reglas.Publicos.TipoImpresionMRP))
         '-- Estado Ordenes de Produccion.- ------------------------------------------------
         .CargaComboEstadosOrdenesProduccion(cmbEstados, True, True, True, False, String.Empty)
         '-- Filtrado de Marca de Grilla.- ------------------------------------------------
         .CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))
         '-- Secciones.- -------------------------------------------------------------------
         .CargaComboSecciones(cmbSecciones)
         '-- Responsables.- ----------------------------------------------------------------
         .CargaComboEmpleados(cmbResponsables, Entidades.Publicos.TiposEmpleados.RESPPROD)
         '-- Tipos comprobantes Orden de Produccion.- --------------------------------------
         .CargaComboTiposComprobantes(cmbTipoComprobanteOP, True, "PRODUCCION", , , , True)
         '-- Tipos comprobantes Pedidos.- --------------------------------------
         .CargaComboTiposComprobantes(cmbTipoComprobantePedido, True, "PEDIDOSCLIE", , , , True)
      End With
   End Sub
   ''' <summary>
   ''' Inicializa los campos de Filtrado.-
   ''' </summary>
   Private Sub InicializaCamposFiltrado()
      '-- Inicializa los Controles.- --------------------------------------------------------
      cmbTiposImpresiones.SelectedIndex = 0
      chbImprimeArchivo.Checked = False
      cmbEstados.SelectedIndex = 1 'SOLO PENDIENTES
      cmbResponsables.SelectedIndex = 0
      cmbSecciones.SelectedIndex = -1
      '-- Inicializa los DatePicker.- ------------------------------------------------------
      dtpDesde.Value = DateTime.Today
      dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      dtpDesdeEstado.Value = DateTime.Today
      dtpHastaEstado.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      dtpDesdePlanMaestro.Value = DateTime.Today
      dtpHastaPlanMaestro.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      '-- Inicializa los Check.- -----------------------------------------------------------
      chbImprimeArchivo.Checked = False
      chbFecha.Checked = False
      chbFechaEstado.Checked = False

      chbCliente.Checked = False
      chbPedidoVta.Checked = False

      chbProducto.Checked = False
      chbOrdenProduccion.Checked = False

      chbSeccion.Checked = False
      chbTarea.Checked = False
      chbPlanMaestro.Checked = False
      chbFechaPlanMaestro.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      chbCentroProductor.Checked = False
      '-------------------------------------------------------------------------------------
   End Sub
   ''' <summary>
   ''' Carga los datos de un cliente en el buscador de Clientes.- 
   ''' </summary>
   ''' <param name="dr">DataGridViewRows de Clientes</param>
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombresClientes.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      End If
   End Sub
   ''' <summary>
   ''' Carga los Datos de Producto en el buscador de Productos.-
   ''' </summary>
   ''' <param name="dr">DataGridViewrows de Productos</param>
   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombresProductos.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      End If
   End Sub
   ''' <summary>
   ''' Carga los Datos de Producto en el buscador de Tareas.-
   ''' </summary>
   ''' <param name="dr">DataGridViewrows de Tareas</param>
   Private Sub CargarDatosTareas(dr As DataGridViewRow)
      bscNombreTareas.Text = dr.Cells("Descripcion").Value.ToString()
      bscNombreTareas.Tag = Integer.Parse(dr.Cells("IdTarea").Value.ToString())
   End Sub
   ''' <summary>
   ''' Carga los Datos de Producto en el buscador de Centros Productores.-
   ''' </summary>
   ''' <param name="dr">DataGridViewrows de Centros Productores</param>
   Private Sub CargarDatosCentroProductor(dr As DataGridViewRow)
      bscCodigosCentrosProductores.Text = dr.Cells("CodigoCentroProductor").Value.ToString()
      bscCodigosCentrosProductores.Tag = dr.Cells("IdCentroProductor").Value.ToString()
      bscNombresCentrosProductores.Text = dr.Cells("Descripcion").Value.ToString()
   End Sub
   ''' <summary>
   ''' Recupera los datos a mostrar en Grilla.- 
   ''' </summary>
   Private Sub CargaGrillaDetalle()
      '-- Asigna Valores a las variables de filtro.- ------------------------------------------------------------------------
      Dim idSucursal = actual.Sucursal.IdSucursal

      Dim idEstado = cmbEstados.Text
      Dim idResponsable = cmbResponsables.ValorSeleccionado(Of Integer)

      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto.Text, String.Empty)

      Dim idSeccion = If(chbSeccion.Checked, Integer.Parse(cmbSecciones.SelectedValue.ToString()), 0I)
      Dim idTarea = If(chbTarea.Checked, Integer.Parse(bscNombreTareas.Tag.ToString()), 0I)
      Dim idCentroProductor = If(chbCentroProductor.Checked, Integer.Parse(bscCodigosCentrosProductores.Tag.ToString()), 0I)

      Dim fechaDesde = dtpDesde.Valor(chbFecha).IfNull()
      Dim fechaHasta = dtpHasta.Valor(chbFecha).IfNull()

      Dim fechaDesdeEstado = dtpDesdeEstado.Valor(chbFechaEstado).IfNull()
      Dim fechaHastaEstado = dtpHastaEstado.Valor(chbFechaEstado).IfNull()

      Dim idNroPedido = If(chbPedidoVta.Checked, txtNroPedidoVta.ValorNumericoPorDefecto(0I), 0I)
      Dim lineaNroPedido = If(chbPedidoVta.Checked, txtLineaPedidoVta.ValorNumericoPorDefecto(0I), 0I)
      Dim idTipoComprobantePedido = If(chbPedidoVta.Checked, cmbTipoComprobantePedido.SelectedValue.ToString(), String.Empty)

      Dim idOrdenProduccion = If(chbOrdenProduccion.Checked, txtIdOrdenProduccion.ValorNumericoPorDefecto(0I), 0I)
      Dim idTipoComprobanteOP = If(chbOrdenProduccion.Checked, cmbTipoComprobanteOP.SelectedValue.ToString(), String.Empty)

      Dim nroPlanMaestro = If(chbPlanMaestro.Checked, txtPlanMaestro.ValorNumericoPorDefecto(0I), 0I)
      Dim fechaDesdePlan = dtpDesdePlanMaestro.Valor(chbFechaPlanMaestro).IfNull()
      Dim fechaHastaPlan = dtpHastaPlanMaestro.Valor(chbFechaPlanMaestro).IfNull()

      Dim tipoImpresion = DirectCast(cmbTiposImpresiones.SelectedValue, Reglas.Publicos.TipoImpresionMRP)

      '-- Obtiene Valores para la Grilla.- ----------------------------------------------------------------------------------
      Dim rOPM = New Reglas.OrdenesProduccionMRP()
      Dim dtDetalle = rOPM.GetOrdenesProduccionImpresionMasiva(idSucursal,
                                                               idEstado,
                                                               idResponsable,
                                                               idCliente,
                                                               idProducto,
                                                               idSeccion,
                                                               idTarea,
                                                               idCentroProductor,
                                                               fechaDesde,
                                                               fechaHasta,
                                                               fechaDesdeEstado,
                                                               fechaHastaEstado,
                                                               idNroPedido,
                                                               lineaNroPedido,
                                                               idTipoComprobantePedido,
                                                               idOrdenProduccion,
                                                               idTipoComprobanteOP,
                                                               nroPlanMaestro,
                                                               fechaDesdePlan,
                                                               fechaHastaPlan,
                                                               tipoImpresion)
      '-- Asigna Valores a la Grilla.- --------------------------------------------------------------------------------------
      ugDetalle.DataSource = dtDetalle
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
      '----------------------------------------------------------------------------------------------------------------------
   End Sub
   ''' <summary>
   ''' Formate la Grilla en base al tipo de Impresion.-
   ''' </summary>
   Private Sub FormateaGrillaDetalle()
      '-- Define Variable de Posicion.- ------------------------------------------------------------------------------------
      Dim pos = 0I
      '-- Setea Formato de Grilla.- ----------------------------------------------------------------------------------------
      With ugDetalle.DisplayLayout.Bands(0)
         '-- Oculta las Columnas.- -----------------------------------------------------------------------------------------
         .OcultaTodasLasColumnas()
         '-- Setea las Columnas.- ------------------------------------------------------------------------------------------
         .Columns("Imprimir").Hidden = False
         .Columns("Imprimir").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
         .Columns("Imprimir").Header.Caption = "I"
         .Columns("Imprimir").Header.VisiblePosition = pos
         .Columns("Imprimir").Width = 30
         pos += 1
         .Columns("Visualizar").FormatearColumna("V", pos, 30, HAlign.Center)
         '-- Datos Comprobante Orden de Produccion.- -----------------------------------------------------------------------
         .Columns("IdTipoComprobante").FormatearColumna("Comprobante", pos, 150, HAlign.Left)
         .Columns("NumeroOrdenProduccion").FormatearColumna("Numero", pos, 60, HAlign.Right)
         .Columns("Letra").FormatearColumna("Let.", pos, 40, HAlign.Center)
         .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 50, HAlign.Right)
         .Columns("FechaOrdenProduccion").FormatearColumna("Fecha Orden", pos, 90, HAlign.Center)
         '-- Cliente Orden de Produccion.- ---------------------------------------------------------------------------------
         .Columns("NombreCliente").FormatearColumna("Cliente", pos, 150)
         '-- Numero - Fecha Plan Maestro Orden de Produccion.- ---------------------------------------------------------------------------------
         .Columns("PlanMaestroNumero").FormatearColumna("Plan Maestro", pos, 50, HAlign.Right)
         .Columns("PlanMaestroFecha").FormatearColumna("Fecha Plan", pos, 90, HAlign.Center)
         '-- Datos de Pedido asociado a Orden de Produccion.- --------------------------------------------------------------
         .Columns("NumeroPedido").FormatearColumna("Pedido Vta", pos, 70, HAlign.Right)
         .Columns("OrdenPedido").FormatearColumna("Linea Vta", pos, 70, HAlign.Right)
         '------------------------------------------------------------------------------------------------------------------
         If cmbTiposImpresiones.SelectedIndex > 0 Then
            '-- Estado Orden de Produccion.- -------------------------------------------------------------------------------
            .Columns("IdEstado").FormatearColumna("Estado Orden", pos, 110, HAlign.Left)
            .Columns("FechaEstado").FormatearColumna("Fecha Estado", pos, 80, HAlign.Center)
            '-- Producto Asociado a Orden de Produccion.- ------------------------------------------------------------------
            .Columns("IdProducto").FormatearColumna("Codigo", pos, 80, HAlign.Right)
            .Columns("NombreProducto").FormatearColumna("Producto", pos, 170)
            .Columns("CantEstado").FormatearColumna("Cantidad", pos, 60, HAlign.Right)
            .Columns("FechaEntrega").FormatearColumna("Fecha Entrega", pos, 90, HAlign.Center)
            '-- Proceso Productivo asociado a Producto de Orden de Produccion.- --------------------------------------------
            .Columns("CodigoProcesoProductivo").FormatearColumna("Codigo Proceso", pos, 80, HAlign.Right)
            .Columns("DescripcionProceso").FormatearColumna("Descripción Proceso", pos, 170)
            '-- Operaciones Asociadas a Orden de Produccion.- --------------------------------------------------------------
            If cmbTiposImpresiones.SelectedIndex > 1 Then
               .Columns("CodigoProcProdOperacion").FormatearColumna("Codigo Operación", pos, 110, HAlign.Right)
               .Columns("DescripcionOperacion").FormatearColumna("Decripcion Operación", pos, 170)
               .Columns("CodigoCentroProductor").FormatearColumna("Codigo Centro", pos, 110, HAlign.Right)
               .Columns("DescripcionCentro").FormatearColumna("Decripcion Centro", pos, 170)
               .Columns("CodigoSeccion").FormatearColumna("Codigo Seccion", pos, 80, HAlign.Right)
               .Columns("DescripcionSeccion").FormatearColumna("Descripción Seccion", pos, 170)
            End If
         End If
         .Columns("Observacion").FormatearColumna("Observacion", pos, 150, HAlign.Left)

      End With
      '---------------------------------------------------------------------------------------------------------------------
   End Sub

   Private Sub ManipulaFiltroConsulta(tipoConsulta As String)
      '-- Check Productos.- ----------------------------------------------------------
      chbProducto.Enabled = False
      chbProducto.Checked = False
      '-- Check Sessiones.- ----------------------------------------------------------
      chbSeccion.Enabled = False
      chbSeccion.Checked = False
      '-- Check Tareas.- -------------------------------------------------------------
      chbTarea.Enabled = False
      chbTarea.Checked = False
      '-- Check Centros Productores.- ------------------------------------------------
      chbCentroProductor.Enabled = False
      chbCentroProductor.Checked = False
      chbImprimeArchivo.Enabled = True
      '-------------------------------------------------------------------------------
      Select Case tipoConsulta
         Case Reglas.Publicos.TipoImpresionMRP.PorOrdenProduccionProducto.ToString()
            chbProducto.Enabled = True
         Case Reglas.Publicos.TipoImpresionMRP.PorOrdenProduccionOperacion.ToString()
            chbImprimeArchivo.Checked = False
            chbImprimeArchivo.Enabled = False

            chbProducto.Enabled = True
            chbSeccion.Enabled = True
            chbTarea.Enabled = True
            chbCentroProductor.Enabled = True
      End Select
      '-------------------------------------------------------------------------------
   End Sub
   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         If marcar.HasValue Then
            dr.Cells("Imprimir").Value = marcar.Value
         Else
            dr.Cells("Imprimir").Value = Not CBool(dr.Cells("Imprimir").Value)
         End If
      Next
   End Sub

   ''' <summary>
   ''' Procedimeinto de Impresion de Hoja de Ruta.-
   ''' </summary>
   Private Sub ImpresionHojasRutaOrdenes(visualiza As Boolean)
      '-- Valida Datos en la Grilla.- ---------------------------------------------------
      If Not TypeOf (ugDetalle.DataSource) Is DataTable Then Exit Sub
      '-- Define Variable de Totales de Registros e Inicializa.- ------------------------
      Dim total = DirectCast(ugDetalle.DataSource, DataTable).Select("Imprimir = 'True'").Length
      '-- Valida Ordenes de Produccion Seleccionadas.- ----------------------------------
      If total = 0 Then
         ShowMessage("No se indicaron Ordenes de Produccion para Imprimir.")
         Exit Sub
      End If
      '-- Establece Maximo para tspBarra.- ----------------------------------------------
      tspBarra.Maximum = total
      For Each dr As DataRow In DirectCast(ugDetalle.DataSource, DataTable).Select("Imprimir = 'True'")
         Dim tipoImpresion = DirectCast(cmbTiposImpresiones.SelectedValue, Reglas.Publicos.TipoImpresionMRP)
         '--------------------------------------------------------------------------------
         Dim idSucursal = Integer.Parse(dr("IdSucursal").ToString())
         Dim idTipoComprobante = dr("IdTipoComprobante").ToString()
         Dim letra = dr("Letra").ToString()
         Dim centroEmisor = Short.Parse(dr("CentroEmisor").ToString())
         Dim numeroOrdenProd = Long.Parse(dr("NumeroOrdenProduccion").ToString())
         Dim NroPedido = If(String.IsNullOrEmpty(dr("NumeroPedido").ToString()), 0, Integer.Parse(dr("NumeroPedido").ToString()))
         Dim LineaPedido = If(String.IsNullOrEmpty(dr("OrdenPedido").ToString()), 0, Integer.Parse(dr("OrdenPedido").ToString()))
         '--------------------------------------------------------------------------------
         Try
            '-----------------------------------------------------------------------------
            Select Case tipoImpresion
               Case Reglas.Publicos.TipoImpresionMRP.PorOrdenProduccion          '-- Por Orden Produccion.- 
                  For Each dr2 As DataRow In RecuperaDetalleOperaciones(Integer.Parse(dr("IdSucursal").ToString()), Integer.Parse(dr("NumeroOrdenProduccion").ToString()), dr("IdTipoComprobante").ToString()).Rows
                     '--
                     Dim Orden = Integer.Parse(dr2("Orden").ToString())
                     Dim idProducto = dr2("IdProducto").ToString()
                     Dim idProcesoProductivo = Integer.Parse(dr2("IdProcesoProductivo").ToString())
                     Dim cantidadEstado = Decimal.Parse(dr2("CantEstado").ToString())
                     Dim fechaEntrega = DateTime.Parse(dr2("FechaEntrega").ToString())
                     '-- Procedimiento de Impresion de Hoja de Ruta.- -----------------------
                     ImprimirHojaRutaProducto(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProd, Orden, idProducto,
                                              idProcesoProductivo, visualiza, cantidadEstado, fechaEntrega, NroPedido, LineaPedido)
                     '-- Imprimir Archivo Adjunto.- -----------------------------------------
                     If chbImprimeArchivo.Checked Then
                        ImprimirArchivoAdjunto(idProducto, Integer.Parse(dr2("IdArchivoAdjunto").ToString()))
                     End If
                     '-----------------------------------------------------------------------
                  Next
               Case Reglas.Publicos.TipoImpresionMRP.PorOrdenProduccionProducto  '-- Por Producto.-
                  '--
                  Dim Orden = Integer.Parse(dr("Orden").ToString())
                  Dim idProducto = dr("IdProducto").ToString()
                  Dim idProcesoProductivo = Integer.Parse(dr("IdProcesoProductivo").ToString())
                  Dim cantidadEstado = Decimal.Parse(dr("CantEstado").ToString())
                  Dim fechaEntrega = DateTime.Parse(dr("FechaEntrega").ToString())
                  '-- Procedimiento de Impresion de Hoja de Ruta.- -----------------------
                  ImprimirHojaRutaProducto(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProd, Orden, idProducto,
                                           idProcesoProductivo, visualiza, cantidadEstado, fechaEntrega, NroPedido, LineaPedido)
                  '-- Imprimir Archivo Adjunto.- -----------------------------------------
                  If chbImprimeArchivo.Checked Then
                     ImprimirArchivoAdjunto(idProducto, Integer.Parse(dr("IdArchivoAdjunto").ToString()))
                  End If
                  '-----------------------------------------------------------------------
               Case Reglas.Publicos.TipoImpresionMRP.PorOrdenProduccionOperacion '-- Por Operacion.-
                  '--
                  Dim Orden = Integer.Parse(dr("Orden").ToString())
                  Dim idProducto = dr("IdProducto").ToString()
                  Dim idProcesoProductivo = Integer.Parse(dr("IdProcesoProductivo").ToString())
                  Dim cantidadEstado = Decimal.Parse(dr("CantEstado").ToString())
                  Dim fechaEntrega = DateTime.Parse(dr("FechaEntrega").ToString())
                  Dim IdOperacion = Integer.Parse(dr("IdOperacion").ToString())
                  '-- Procedimiento de Impresion de Hoja de Ruta.- -----------------------
                  ImprimirHojaRutaOperacion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProd, Orden, idProducto,
                                            idProcesoProductivo, IdOperacion, visualiza, cantidadEstado, fechaEntrega, NroPedido, LineaPedido)
                  '-----------------------------------------------------------------------
            End Select
         Catch ex As Exception
            Throw New ApplicationException(String.Format("Error imprimiendo {1} {2} {3:0000}-{4:00000000}: {5}",
                                                         idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProd,
                                                         ex.Message), ex)
         End Try
         '-- Actualiza Barra de Operaciones.-
         tspBarra.PerformStep()
         tssInfo.Text = String.Format("Imprimiendo... {0} de {1}", tspBarra.Value, total)
         Application.DoEvents()
      Next
      ShowMessage(String.Format("Se imprimieron {0} Ordenes de Produccion.", total))
   End Sub

   Private Sub ImprimirArchivoAdjunto(producto As String, link As Integer)
      Dim adjunto = New Reglas.ProductosLinks().GetUno(producto, link)
      If Not String.IsNullOrWhiteSpace(adjunto.Link) AndAlso System.IO.File.Exists(adjunto.Link) Then
         Dim Proceso As New System.Diagnostics.Process
         Proceso.StartInfo.FileName = adjunto.Link
         Proceso.Start()
      Else
         ShowMessage(String.Format("Problemas para poder visualizar el archivo Adjunto. {0}El mismo pudo haber sido movido. Comprobar.{0}Documento: {1} ", Environment.NewLine, adjunto.Link))
      End If
   End Sub

   Private Sub ImprimirHojaRutaProducto(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                        orden As Integer, idProducto As String, idProcesoProductivo As Long, visualiza As Boolean,
                                         cantidadEstado As Decimal, fechaEntrega As DateTime, nroPedido As Integer, lineaPedido As Integer)

      Dim dtOperaciones = New Reglas.OrdenesProduccionMRPOperaciones()._GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, orden, idProducto, idProcesoProductivo)

      For Each dr As DataRow In dtOperaciones.Rows
         Dim impresion = New ImpresionOrdenesProduccionMRP()
         Dim eOrdProdOper = RecuperaUnaOperacion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                 orden, idProducto, idProcesoProductivo, Integer.Parse(dr("IdOperacion").ToString()))
         With eOrdProdOper
            .CantidadOP = cantidadEstado
            .FechaEntrega = fechaEntrega
            .NumeroPedido = nroPedido
            .LineaPedido = lineaPedido
         End With
         impresion.ImprimirHojaRutaOperacion(eOrdProdOper, Visualizar:=visualiza)
      Next
   End Sub
   Private Sub ImprimirHojaRutaOperacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                         orden As Integer, idProducto As String, idProcesoProductivo As Long, idOperacion As Integer, visualiza As Boolean,
                                         cantidadEstado As Decimal, fechaEntrega As DateTime, nroPedido As Integer, lineaPedido As Integer)

      Dim impresion = New ImpresionOrdenesProduccionMRP()
      Dim eOrdProdOper = RecuperaUnaOperacion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                              orden, idProducto, idProcesoProductivo, idOperacion)
      With eOrdProdOper
         .CantidadOP = cantidadEstado
         .FechaEntrega = fechaEntrega
         .NumeroPedido = nroPedido
         .LineaPedido = lineaPedido
      End With
      impresion.ImprimirHojaRutaOperacion(eOrdProdOper, Visualizar:=visualiza)
   End Sub

   Private Function RecuperaUnaOperacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                         orden As Integer, idProducto As String, idProcesoProductivo As Long, idOperacion As Integer) As Entidades.OrdenProduccionMRPOperacion

      Dim rOrdProdOper = New Reglas.OrdenesProduccionMRPOperaciones()
      Return rOrdProdOper.GetUna(idSucursal:=idSucursal,
                                 idTipoComprobante:=idTipoComprobante,
                                 letra:=letra,
                                 centroEmisor:=centroEmisor,
                                 numeroOrdenProduccion:=numeroOrdenProduccion,
                                 orden:=orden,
                                 idProducto:=idProducto,
                                 idProcesoProductivo:=idProcesoProductivo,
                                 idOperacion:=idOperacion)
   End Function
   Private Function RecuperaDetalleOperaciones(idSucursal As Integer, idOrdenProduccion As Integer, idTipoComprobanteOP As String) As DataTable
      Dim dtDetalle As DataTable = Nothing
      Dim idEstado = cmbEstados.Text
      Dim idResponsable = cmbResponsables.ValorSeleccionado(Of Integer)

      '-- Obtiene Valores.- --------------------------------------------------------------------------------------------------------
      Dim rOPM = New Reglas.OrdenesProduccionMRP()
      dtDetalle = rOPM.GetOrdenesProduccionImpresionMasiva(idSucursal,
                                                               idEstado,
                                                               idResponsable,
                                                               0,
                                                               String.Empty,
                                                               0,
                                                               0,
                                                               0,
                                                               Nothing,
                                                               Nothing,
                                                               Nothing,
                                                               Nothing,
                                                               0,
                                                               0,
                                                               String.Empty,
                                                               idOrdenProduccion,
                                                               idTipoComprobanteOP,
                                                               0,
                                                               Nothing,
                                                               Nothing,
                                                               Reglas.Publicos.TipoImpresionMRP.PorOrdenProduccionProducto)
      '-----------------------------------------------------------------------------------------------------------------------------
      Return dtDetalle
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Buscador Clientes"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscNombresClientes_BuscadorClick() Handles bscNombresClientes.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscNombresClientes)
         bscNombresClientes.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscNombresClientes.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscNombresClientes.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Productos"
   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , , )
      End Sub)
   End Sub
   Private Sub bscNombresProductos_BuscadorClick() Handles bscNombresProductos.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombresProductos)
         bscNombresProductos.Datos = New Reglas.Productos().GetPorNombre(bscNombresProductos.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , )
      End Sub)
   End Sub
   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscNombresProductos.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Tareas"
   Private Sub bscNombreTareas_BuscadorClick() Handles bscNombreTareas.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMRPTareas(bscNombreTareas)
            bscNombreTareas.Datos = New Reglas.MRPTareas().GetFiltradoPorNombre(bscNombreTareas.Text.Trim(), Entidades.Publicos.SiNoTodos.SI)
         End Sub)
   End Sub
   Private Sub bscNombreTareas_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreTareas.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosTareas(e.FilaDevuelta)
               bscNombreTareas.Select()
            End If
         End Sub)
   End Sub
#End Region

#Region "Eventos Buscador Centros Productores."
   Private Sub bscCodigosCentrosProductores_BuscadorClick() Handles bscCodigosCentrosProductores.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMRPCentrosProductores(bscCodigosCentrosProductores)
            bscCodigosCentrosProductores.Datos = New Reglas.MRPCentrosProductores().GetFiltradoPorCodigo(bscCodigosCentrosProductores.Text.Trim(), Entidades.Publicos.SiNoTodos.TODOS, True)
         End Sub)
   End Sub
   Private Sub bscNombreCentrosProductores_BuscadorClick() Handles bscNombresCentrosProductores.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMRPCentrosProductores(bscNombresCentrosProductores)
            bscNombresCentrosProductores.Datos = New Reglas.MRPCentrosProductores().GetFiltradoPorNombre(bscNombresCentrosProductores.Text.Trim(), Entidades.Publicos.SiNoTodos.SI, Entidades.Publicos.SiNoTodos.TODOS)
         End Sub)
   End Sub
   Private Sub bscCodigoCentroProductor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigosCentrosProductores.BuscadorSeleccion, bscNombresCentrosProductores.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCentroProductor(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region

   Private Sub cmbTiposImpresiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposImpresiones.SelectedIndexChanged
      '-- Valida el Select Index del Combo de tipo de Impresion.- ------------------------------------------------------------------------
      ManipulaFiltroConsulta(cmbTiposImpresiones.SelectedValue.ToString())
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      '-----------------------------------------------------------------------------------------------------------------------------------
   End Sub
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      '-------------------------------------------------------------------------------------
      chkMesCompleto.Enabled = chbFecha.Checked
      dtpDesde.Enabled = chbFecha.Checked
      dtpHasta.Enabled = chbFecha.Checked
      '-------------------------------------------------------------------------------------
      If Not chbFecha.Checked Then
         '-- Inicializa los DatetimePicker.- -----------------------------------------------
         chkMesCompleto.Checked = False
         dtpDesde.Value = DateTime.Today
         dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         dtpDesde.Select()
      End If
      '-------------------------------------------------------------------------------------
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      Dim FechaTemp As Date
      Try
         If chkMesCompleto.Checked Then
            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp
         End If
         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked
      Catch ex As Exception
         chkMesCompleto.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbFechaEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEstado.CheckedChanged
      '-------------------------------------------------------------------------------------
      chkMesCompletoEstado.Enabled = chbFechaEstado.Checked
      dtpDesdeEstado.Enabled = chbFechaEstado.Checked
      dtpHastaEstado.Enabled = chbFechaEstado.Checked
      '-------------------------------------------------------------------------------------
      If Not chbFechaEstado.Checked Then
         '-- Inicializa los DatetimePicker.- -----------------------------------------------
         chkMesCompletoEstado.Checked = False
         dtpDesdeEstado.Value = Date.Today
         dtpHastaEstado.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         dtpDesdeEstado.Select()
      End If
      '-------------------------------------------------------------------------------------
   End Sub
   Private Sub chkMesCompletoEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoEstado.CheckedChanged
      Dim FechaTemp As Date
      Try
         If chkMesCompletoEstado.Checked Then
            FechaTemp = New Date(Me.dtpDesdeEstado.Value.Year, Me.dtpDesdeEstado.Value.Month, 1)
            Me.dtpDesdeEstado.Value = FechaTemp
            FechaTemp = Me.dtpDesdeEstado.Value.AddMonths(1).AddSeconds(-1)
            dtpHastaEstado.Value = FechaTemp
         End If
         Me.dtpDesdeEstado.Enabled = Not Me.chkMesCompletoEstado.Checked
         Me.dtpHastaEstado.Enabled = Not Me.chkMesCompletoEstado.Checked
      Catch ex As Exception
         chkMesCompletoEstado.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbPedidoVta_CheckedChanged(sender As Object, e As EventArgs) Handles chbPedidoVta.CheckedChanged
      '-- Inicializa los campos de Filtro.- ------------------------------------------------
      txtNroPedidoVta.Enabled = chbPedidoVta.Checked
      txtNroPedidoVta.Text = "0"
      txtNroPedidoVta.Select()

      txtLineaPedidoVta.Enabled = chbPedidoVta.Checked
      txtLineaPedidoVta.Text = String.Empty

      cmbTipoComprobantePedido.Enabled = chbPedidoVta.Checked
      cmbTipoComprobantePedido.SelectedIndex = -1
      '-------------------------------------------------------------------------------------
   End Sub
   Private Sub chbOrdenProduccion_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenProduccion.CheckedChanged
      '-- Inicializa los campos de Filtro.- ------------------------------------------------
      txtIdOrdenProduccion.Enabled = chbOrdenProduccion.Checked
      cmbTipoComprobanteOP.Enabled = chbOrdenProduccion.Checked

      txtIdOrdenProduccion.Text = "0"
      cmbTipoComprobanteOP.SelectedIndex = -1

      txtIdOrdenProduccion.Select()
      '-------------------------------------------------------------------------------------
   End Sub
   Private Sub chbPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chbPlanMaestro.CheckedChanged
      '-- Inicializa los campos de Filtro.- ------------------------------------------------
      txtPlanMaestro.Enabled = chbPlanMaestro.Checked
      chbFechaPlanMaestro.Enabled = chbPlanMaestro.Checked

      txtPlanMaestro.Text = "0"
      txtPlanMaestro.Select()

      chbFechaPlanMaestro.Checked = False
      dtpDesdePlanMaestro.Value = Date.Today
      dtpHastaPlanMaestro.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      '-------------------------------------------------------------------------------------
   End Sub
   Private Sub chbFechaPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaPlanMaestro.CheckedChanged
      dtpDesdePlanMaestro.Enabled = chbPlanMaestro.Checked
      dtpHastaPlanMaestro.Enabled = chbPlanMaestro.Checked

      dtpDesdePlanMaestro.Value = Date.Today
      dtpHastaPlanMaestro.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscNombresClientes))
   End Sub
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(bscCodigoProducto, bscNombresProductos))
   End Sub
   Private Sub chbSeccion_CheckedChanged(sender As Object, e As EventArgs) Handles chbSeccion.CheckedChanged
      '-- Inicializa los campos de Filtro.- ------------------------------------------------
      cmbSecciones.Enabled = chbSeccion.Checked
      cmbSecciones.SelectedIndex = -1
      cmbSecciones.Focus()
      '-------------------------------------------------------------------------------------
   End Sub
   Private Sub chbTarea_CheckedChanged(sender As Object, e As EventArgs) Handles chbTarea.CheckedChanged
      TryCatched(Sub() chbTarea.FiltroCheckedChanged(bscNombreTareas))
   End Sub
   Private Sub chbCentroProductor_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroProductor.CheckedChanged
      TryCatched(Sub() chbCentroProductor.FiltroCheckedChanged(bscCodigosCentrosProductores, bscNombresCentrosProductores))
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      '-- Inicializa los campos del Formulario.- -------------------------------------------
      InicializaCamposFiltrado()
      '-------------------------------------------------------------------------------------
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(Sub()
                    '-- Valido Responsable.- --------------------------------------------------------------------------------------------------------------------
                    If cmbResponsables.SelectedIndex = -1 Then
                       MessageBox.Show("ATENCION: NO seleccionó un Responsable.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       cmbResponsables.Focus()
                       Exit Sub
                    End If
                    '-- Valido Cliente.- ------------------------------------------------------------------------------------------------------------------------
                    If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscNombresClientes.Selecciono Then
                       MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       bscCodigoCliente.Focus()
                       Exit Sub
                    End If
                    '-- Valido Producto.- -----------------------------------------------------------------------------------------------------------------------
                    If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscNombresProductos.Selecciono Then
                       MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       bscCodigoProducto.Focus()
                       Exit Sub
                    End If
                    '-- Valido Seccion.- ------------------------------------------------------------------------------------------------------------------------
                    If chbSeccion.Checked AndAlso cmbSecciones.SelectedIndex = -1 Then
                       MessageBox.Show("ATENCION: NO seleccionó una Sección aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       cmbSecciones.Focus()
                       Exit Sub
                    End If
                    '-- Valido Tareas.- -------------------------------------------------------------------------------------------------------------------------
                    If chbTarea.Checked And Not bscNombreTareas.Selecciono Then
                       MessageBox.Show("ATENCION: NO seleccionó una Tarea aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       cmbSecciones.Focus()
                       Exit Sub
                    End If
                    '-- Valido Centro Productor.- ---------------------------------------------------------------------------------------------------------------
                    If chbCentroProductor.Checked And Not bscCodigosCentrosProductores.Selecciono And Not bscNombresCentrosProductores.Selecciono Then
                       MessageBox.Show("ATENCION: NO seleccionó un Centro Productor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       bscCodigosCentrosProductores.Focus()
                       Exit Sub
                    End If
                    '-- Pedido de Venta.- -----------------------------------------------------------------------------------------------------------------------
                    If chbPedidoVta.Checked AndAlso Integer.Parse("0" & txtNroPedidoVta.Text) = 0 Then
                       MessageBox.Show("ATENCION: NO Ingresó un Número de Pedido de Venta aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       txtNroPedidoVta.Focus()
                       Exit Sub
                    End If
                    If chbPedidoVta.Checked AndAlso cmbTipoComprobantePedido.SelectedIndex = -1 Then
                       MessageBox.Show("ATENCION: NO Ingresó un Tipo de Comprobante de Pedido de Venta aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       cmbTipoComprobantePedido.Focus()
                       Exit Sub
                    End If
                    '-- Orden de Produccion.- -------------------------------------------------------------------------------------------------------------------
                    If chbOrdenProduccion.Checked AndAlso Integer.Parse("0" & txtIdOrdenProduccion.Text) = 0 Then
                       MessageBox.Show("ATENCION: NO Ingresó un Número de Orden de Produccion aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       txtIdOrdenProduccion.Focus()
                       Exit Sub
                    End If
                    If chbOrdenProduccion.Checked AndAlso cmbTipoComprobanteOP.SelectedIndex = -1 Then
                       MessageBox.Show("ATENCION: NO Ingresó un Tipo de Comprobante de Orden de Produccion aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       cmbTipoComprobanteOP.Focus()
                       Exit Sub
                    End If
                    '-- Plan Maestro de Produccion.- ------------------------------------------------------------------------------------------------------------
                    If chbPlanMaestro.Checked AndAlso Integer.Parse("0" & txtPlanMaestro.Text) = 0 Then
                       MessageBox.Show("ATENCION: NO Ingresó un Número de Plan Maestro aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                       txtPlanMaestro.Focus()
                       Exit Sub
                    End If
                    '-- Carga Datos en la Grilla.- --------------------------------------------------------------------------------------------------------------
                    CargaGrillaDetalle()
                    '-- Formatea Datos en la Grilla.- -----------------------------------------------------------------------------------------------------------
                    FormateaGrillaDetalle()
                    '-- Valida Cantidad de Registros en la Grilla.- ---------------------------------------------------------------------------------------------
                    If ugDetalle.Rows.Count = 0 Then
                       ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
                    End If
                    '--------------------------------------------------------------------------------------------------------------------------------------------
                 End Sub)
   End Sub
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnumSI Then
            Me.Cursor = Cursors.WaitCursor
            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnumSI)
               Case Reglas.Publicos.TodosEnumSI.MarcarTodos
                  MarcarDesmarcar(True, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos
               Case Reglas.Publicos.TodosEnumSI.DesmarcarTodos
                  MarcarDesmarcar(False, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos
               Case Reglas.Publicos.TodosEnumSI.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.ToArray())
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
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub
            ugDetalle.UpdateData()
            If DirectCast(ugDetalle.DataSource, DataTable).Select("Imprimir").Count > 0 Then
               '-- Valida Parametros de Procesamiento.- --
               tssInfo.Text = "Imprimiendo..."
               tspBarra.Value = 0
               tspBarra.Visible = True
               '-- Procedimiento de Impresion.- ----------
               ImpresionHojasRutaOrdenes(False)
               '------------------------------------------
               tspBarra.Value = 0
               btnConsultar.PerformClick()
            End If
         End Sub,
         onFinallyAction:=
         Sub(owner)
            tspBarra.Visible = False
            tssInfo.Text = String.Empty
         End Sub)
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
            If dr Is Nothing Then
               Throw New Exception("Debe seleccionar una Orden para poder continuar")
            End If
            Dim NroPedido = If(String.IsNullOrEmpty(dr("NumeroPedido").ToString()), 0, Integer.Parse(dr("NumeroPedido").ToString()))
            Dim LineaPedido = If(String.IsNullOrEmpty(dr("OrdenPedido").ToString()), 0, Integer.Parse(dr("OrdenPedido").ToString()))
            Select Case cmbTiposImpresiones.SelectedIndex
               Case 0
                  For Each dr2 As DataRow In RecuperaDetalleOperaciones(Integer.Parse(dr("IdSucursal").ToString()), Integer.Parse(dr("NumeroOrdenProduccion").ToString()), dr("IdTipoComprobante").ToString()).Rows
                     '--
                     Dim Orden = Integer.Parse(dr2("Orden").ToString())
                     Dim idProducto = dr2("IdProducto").ToString()
                     Dim idProcesoProductivo = Integer.Parse(dr2("IdProcesoProductivo").ToString())
                     Dim cantidadEstado = Decimal.Parse(dr2("CantEstado").ToString())
                     Dim fechaEntrega = DateTime.Parse(dr2("FechaEntrega").ToString())
                     '-- Procedimiento de Impresion de Hoja de Ruta.- -----------------------
                     ImprimirHojaRutaProducto(Integer.Parse(dr("IdSucursal").ToString()),
                                           dr("IdTipoComprobante").ToString(),
                                           dr("Letra").ToString(),
                                           Short.Parse(dr("CentroEmisor").ToString()),
                                           Long.Parse(dr("NumeroOrdenProduccion").ToString()),
                                           Integer.Parse(dr("Orden").ToString()),
                                           idProducto,
                                           idProcesoProductivo, True, cantidadEstado, fechaEntrega,
                                           If(String.IsNullOrEmpty(dr("NumeroPedido").ToString()), 0, Integer.Parse(dr("NumeroPedido").ToString())),
                                           If(String.IsNullOrEmpty(dr("OrdenPedido").ToString()), 0, Integer.Parse(dr("OrdenPedido").ToString())))
                     '-- Imprimir Archivo Adjunto.- -----------------------------------------
                     If chbImprimeArchivo.Checked Then
                        ImprimirArchivoAdjunto(dr2("IdProducto").ToString(), Integer.Parse(dr2("IdArchivoAdjunto").ToString()))
                     End If
                     '-----------------------------------------------------------------------
                  Next
               Case 1
                  '--
                  Dim Orden = Integer.Parse(dr("Orden").ToString())
                  Dim idProducto = dr("IdProducto").ToString()
                  Dim idProcesoProductivo = Integer.Parse(dr("IdProcesoProductivo").ToString())
                  Dim cantidadEstado = Decimal.Parse(dr("CantEstado").ToString())
                  Dim fechaEntrega = DateTime.Parse(dr("FechaEntrega").ToString())
                  '-- Procedimiento de Impresion de Hoja de Ruta.- -----------------------
                  ImprimirHojaRutaProducto(Integer.Parse(dr("IdSucursal").ToString()),
                                           dr("IdTipoComprobante").ToString(),
                                           dr("Letra").ToString(),
                                           Short.Parse(dr("CentroEmisor").ToString()),
                                           Long.Parse(dr("NumeroOrdenProduccion").ToString()),
                                           Integer.Parse(dr("Orden").ToString()),
                                           dr("IdProducto").ToString(),
                                           Integer.Parse(dr("IdProcesoProductivo").ToString()), True, cantidadEstado, fechaEntrega,
                                           If(String.IsNullOrEmpty(dr("NumeroPedido").ToString()), 0, Integer.Parse(dr("NumeroPedido").ToString())),
                                           If(String.IsNullOrEmpty(dr("OrdenPedido").ToString()), 0, Integer.Parse(dr("OrdenPedido").ToString())))
                  '-- Imprimir Archivo Adjunto.- -----------------------------------------
                  If chbImprimeArchivo.Checked Then
                     ImprimirArchivoAdjunto(dr("IdProducto").ToString(), Integer.Parse(dr("IdArchivoAdjunto").ToString()))
                  End If
                  '-----------------------------------------------------------------------
               Case 2
                  '-- Procedimiento de Impresion de Hoja de Ruta.- -----------------------
                  ImprimirHojaRutaOperacion(Integer.Parse(dr("IdSucursal").ToString()),
                                      dr("IdTipoComprobante").ToString(),
                                      dr("Letra").ToString(),
                                      Short.Parse(dr("CentroEmisor").ToString()),
                                      Long.Parse(dr("NumeroOrdenProduccion").ToString()),
                                      Integer.Parse(dr("Orden").ToString()),
                                      dr("IdProducto").ToString(),
                                      Integer.Parse(dr("IdProcesoProductivo").ToString()),
                                      Integer.Parse(dr("IdOperacion").ToString()),
                                      True,
                                      Decimal.Parse(dr("CantEstado").ToString()),
                                      DateTime.Parse(dr("FechaEntrega").ToString()),
                                      If(String.IsNullOrEmpty(dr("NumeroPedido").ToString()), 0, Integer.Parse(dr("NumeroPedido").ToString())),
                                      If(String.IsNullOrEmpty(dr("OrdenPedido").ToString()), 0, Integer.Parse(dr("OrdenPedido").ToString())))
                  '-- Imprimir Archivo Adjunto.- -----------------------------------------
                  If chbImprimeArchivo.Checked Then
                     ImprimirArchivoAdjunto(dr("IdProducto").ToString(), Integer.Parse(dr("IdArchivoAdjunto").ToString()))
                  End If
                  '-----------------------------------------------------------------------
            End Select
            '-----------------------------------------------------------------------
         End Sub)
   End Sub



#End Region
End Class

