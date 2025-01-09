Public Class PedidosEstados
   Inherits Base

   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _cache As BusquedasCacheadas

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "PedidosEstados"
      da = accesoDatos
      _categoriaFiscalEmpresa = New CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
      _cache = New BusquedasCacheadas()
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      Dim ent As Entidades.PedidoEstado = DirectCast(entidad, Entidades.PedidoEstado)
      EjecutaConTransaccion(Sub() Inserta(ent))
   End Sub
#End Region

   Public Sub Inserta(prod As Entidades.PedidoEstado)
      EjecutaSP(prod, TipoSP._I)
   End Sub

   Public Sub Inserta(prod As Entidades.PedidoProducto)
      Inserta(prod, prod.Cantidad, "Alta Pedido")
   End Sub
   Public Sub Inserta(prod As Entidades.PedidoProducto, cantidad As Decimal, observacion As String)
      Dim estado = New Entidades.PedidoEstado()

      estado.IdSucursal = prod.IdSucursal
      estado.IdTipoComprobante = prod.IdTipoComprobante
      estado.Letra = prod.Letra
      estado.CentroEmisor = prod.CentroEmisor
      estado.NumeroPedido = prod.NumeroPedido
      estado.IdProducto = prod.IdProducto
      estado.Orden = prod.Orden
      estado.FechaEstado = Date.Now
      estado.IdEstado = Entidades.EstadoPedido.ESTADO_ALTA ' "PENDIENTE"
      estado.TipoEstadoPedido = prod.TipoComprobante.Tipo
      estado.IdUsuario = actual.Nombre
      estado.Observacion = observacion
      estado.CantEstado = cantidad
      estado.IdSucursalFact = 0
      estado.IdTipoComprobanteFact = ""
      estado.LetraFact = ""
      estado.CentroEmisorFact = 0
      estado.NumeroComprobanteFact = 0
      estado.IdCriticidad = prod.IdCriticidad
      estado.FechaEntrega = prod.FechaEntrega
      estado.IdSucursalAnterior = prod.IdSucursal
      estado.IdDepositoAnterior = prod.Producto.IdDeposito
      estado.IdUbicacionAnterior = prod.Producto.IdUbicacion

      Inserta(estado)
   End Sub

   Public Sub EjecutaSP(prod As Entidades.PedidoEstado, tipo As TipoSP)

      Dim sql = New SqlServer.PedidosEstados(da)

      Select Case tipo
         Case TipoSP._I
            sql.PedidosEstados_I(prod.IdSucursal,
                                 prod.IdTipoComprobante,
                                 prod.Letra,
                                 prod.CentroEmisor,
                                 prod.NumeroPedido,
                                 prod.IdProducto,
                                 prod.FechaEstado,
                                 prod.IdEstado,
                                 prod.IdUsuario,
                                 prod.Observacion,
                                 prod.CantEstado,
                                 prod.IdSucursalFact,
                                 prod.IdTipoComprobanteFact,
                                 prod.LetraFact,
                                 prod.CentroEmisorFact,
                                 prod.NumeroComprobanteFact,
                                 prod.Orden,
                                 prod.IdCriticidad,
                                 prod.FechaEntrega,
                                 prod.TipoEstadoPedido,
                                 0,
                                 prod.IdSucursalGenerado,
                                 prod.IdTipoComprobanteGenerado,
                                 prod.LetraGenerado,
                                 prod.CentroEmisorGenerado,
                                 prod.NumeroPedidoGenerado,
                                 prod.IdSucursalRemito,
                                 prod.IdTipoComprobanteRemito,
                                 prod.LetraRemito,
                                 prod.CentroEmisorRemito,
                                 prod.NumeroComprobanteRemito,
                                 prod.IdSucursalProduccion,
                                 prod.IdTipoComprobanteProduccion,
                                 prod.LetraProduccion,
                                 prod.CentroEmisorProduccion,
                                 prod.NumeroOrdenProduccion,
                                 prod.IdSucursalVinculado,
                                 prod.IdTipoComprobanteVinculado,
                                 prod.LetraVinculado,
                                 prod.CentroEmisorVinculado,
                                 prod.NumeroPedidoVinculado,
                                 prod.IdProductoVinculado,
                                 prod.OrdenVinculado,
                                 prod.FechaEstadoVinculado,
                                 prod.AnulacionPorModificacion,
                                 prod.IdSucursalAnterior,
                                 prod.IdDepositoAnterior,
                                 prod.IdUbicacionAnterior)

         Case TipoSP._U

         Case TipoSP._D
            Dim sqlPE As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)
            sqlPE.PedidosEstados_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroPedido, prod.Orden, prod.IdProducto, Nothing)
      End Select

   End Sub



   Private Sub CargarUno(o As Entidades.PedidoEstado, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString())
         .Orden = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.Orden.ToString()).ToString())
         .FechaEstado = DateTime.Parse(dr(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString())
         .IdProducto = dr(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString()


         .IdEstado = dr(Entidades.PedidoEstado.Columnas.IdEstado.ToString()).ToString()
         .IdUsuario = dr(Entidades.PedidoEstado.Columnas.IdUsuario.ToString()).ToString()
         .CantEstado = Decimal.Parse(dr(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString())
         .Observacion = dr(Entidades.PedidoEstado.Columnas.Observacion.ToString()).ToString()
         If IsNumeric(dr(Entidades.PedidoEstado.Columnas.IdSucursalFact.ToString())) Then
            .IdSucursalFact = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.IdSucursalFact.ToString()).ToString())
         End If
         .IdTipoComprobanteFact = dr(Entidades.PedidoEstado.Columnas.IdTipoComprobanteFact.ToString()).ToString()
         .LetraFact = dr(Entidades.PedidoEstado.Columnas.LetraFact.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.CentroEmisorFact.ToString()).ToString()) Then
            .CentroEmisorFact = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.CentroEmisorFact.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.NumeroComprobanteFact.ToString()).ToString()) Then
            .NumeroComprobanteFact = Long.Parse(dr(Entidades.PedidoEstado.Columnas.NumeroComprobanteFact.ToString()).ToString())
         End If


         .IdCriticidad = dr(Entidades.PedidoEstado.Columnas.IdCriticidad.ToString()).ToString()
         .FechaEntrega = DateTime.Parse(dr(Entidades.PedidoEstado.Columnas.FechaEntrega.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.NumeroReparto.ToString()).ToString()) Then
            .NumeroReparto = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.NumeroReparto.ToString()).ToString())
         End If

         .TipoEstadoPedido = dr(Entidades.PedidoEstado.Columnas.TipoEstadoPedido.ToString()).ToString()

         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.IdSucursalGenerado.ToString()).ToString()) Then
            .IdSucursalGenerado = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.IdSucursalGenerado.ToString()).ToString())
         End If
         .IdTipoComprobanteGenerado = dr(Entidades.PedidoEstado.Columnas.IdTipoComprobanteGenerado.ToString()).ToString()
         .LetraGenerado = dr(Entidades.PedidoEstado.Columnas.LetraGenerado.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.CentroEmisorGenerado.ToString()).ToString()) Then
            .CentroEmisorGenerado = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.CentroEmisorGenerado.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.NumeroPedidoGenerado.ToString()).ToString()) Then
            .NumeroPedidoGenerado = Long.Parse(dr(Entidades.PedidoEstado.Columnas.NumeroPedidoGenerado.ToString()).ToString())
         End If


         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.IdSucursalRemito.ToString()).ToString()) Then
            .IdSucursalRemito = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.IdSucursalRemito.ToString()).ToString())
         End If
         .IdTipoComprobanteRemito = dr(Entidades.PedidoEstado.Columnas.IdTipoComprobanteRemito.ToString()).ToString()
         .LetraRemito = dr(Entidades.PedidoEstado.Columnas.LetraRemito.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.CentroEmisorRemito.ToString()).ToString()) Then
            .CentroEmisorRemito = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.CentroEmisorRemito.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.NumeroComprobanteRemito.ToString()).ToString()) Then
            .NumeroComprobanteRemito = Long.Parse(dr(Entidades.PedidoEstado.Columnas.NumeroComprobanteRemito.ToString()).ToString())
         End If


         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.IdSucursalProduccion.ToString()).ToString()) Then
            .IdSucursalProduccion = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.IdSucursalProduccion.ToString()).ToString())
         End If
         .IdTipoComprobanteProduccion = dr(Entidades.PedidoEstado.Columnas.IdTipoComprobanteProduccion.ToString()).ToString()
         .LetraProduccion = dr(Entidades.PedidoEstado.Columnas.LetraProduccion.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.CentroEmisorProduccion.ToString()).ToString()) Then
            .CentroEmisorProduccion = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.CentroEmisorProduccion.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.NumeroOrdenProduccion.ToString()).ToString()) Then
            .NumeroOrdenProduccion = Long.Parse(dr(Entidades.PedidoEstado.Columnas.NumeroOrdenProduccion.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.IdSucursalAnterior.ToString()).ToString()) Then
            .IdSucursalAnterior = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.IdSucursalAnterior.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.IdDepositoAnterior.ToString()).ToString()) Then
            .IdDepositoAnterior = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.IdDepositoAnterior.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstado.Columnas.IdUbicacionAnterior.ToString()).ToString()) Then
            .IdUbicacionAnterior = Integer.Parse(dr(Entidades.PedidoEstado.Columnas.IdUbicacionAnterior.ToString()).ToString())
         End If

      End With
   End Sub

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          orden As Integer, idProducto As String) As Entidades.PedidoEstado
      Dim dt As DataTable = New SqlServer.PedidosProductos(da).PedidosProductos_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto)
      Dim o As Entidades.PedidoEstado = New Entidades.PedidoEstado()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(idSucursal As Integer,
                            idTipoComprobante As String, letra As String,
                            centroEmisor As Integer, numeroPedido As Long) As List(Of Entidades.PedidoEstado)
      Return GetTodos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden:=Nothing, idProducto:=String.Empty)
      'Dim dt As DataTable = New SqlServer.PedidosEstados(da).PedidosEstados_GA(idSucursal,
      '                                                                            idTipoComprobante, letra,
      '                                                                            centroEmisor, numeroPedido)
      'Return CargaLista(dt, Sub(o, dr) CargarUno(DirectCast(o, Entidades.PedidoEstado), dr), Function() New Entidades.PedidoEstado())
   End Function
   Public Function GetTodos(idSucursal As Integer,
                            idTipoComprobante As String, letra As String,
                            centroEmisor As Integer, numeroPedido As Long,
                            orden As Integer?, idProducto As String) As List(Of Entidades.PedidoEstado)
      Dim dt As DataTable = New SqlServer.PedidosEstados(da).PedidosEstados_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto)
      Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoEstado())
   End Function

   Public Function GetTodosPorPedidoGenerado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long) As List(Of Entidades.PedidoEstado)
      Dim dt As DataTable = New SqlServer.PedidosEstados(da).PedidosEstados_G_PorComprobanteGenerado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
      Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoEstado())
   End Function

   Public Function GetTodosPorProduccionProducto(idSucursalProduccion As Integer,
                                                 idTipoComprobanteProduccion As String, letraProduccion As String,
                                                 centroEmisorProduccion As Integer, numeroOrdenProduccion As Long,
                                                 idProducto As String, orden As Integer) As List(Of Entidades.PedidoEstado)
      Dim dt As DataTable = New SqlServer.PedidosEstados(da).PedidosEstados_G_PorComprobanteProduccion(idSucursalProduccion,
                                                                                                       idTipoComprobanteProduccion, letraProduccion,
                                                                                                       centroEmisorProduccion, numeroOrdenProduccion,
                                                                                                       idProducto, orden)
      Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoEstado())
   End Function

   Public Sub ActualizarEstadoPedidoMasivo(idEstadoNuevo As String,
                                           tipoEstadoPedido As String,
                                           idUsuario As String,
                                           observ As String,
                                           idCriticidad As String,
                                           fechaEntrega As Date?,
                                           cantidadCambioIndividual As Decimal?,
                                           IdResponsable As Integer,
                                           fechaNuevoEstado As Date?,
                                           tablagrabar As DataTable,
                                           metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                           idFuncion As String)
      EjecutaConTransaccion(
         Sub()
            _ActualizarEstadoPedidoMasivo(idEstadoNuevo,
                                          tipoEstadoPedido,
                                          idUsuario,
                                          observ,
                                          idCriticidad,
                                          fechaEntrega,
                                          cantidadCambioIndividual,
                                          IdResponsable,
                                          fechaNuevoEstado,
                                          tablagrabar,
                                          metodoGrabacion,
                                          idFuncion)
         End Sub)
   End Sub

   Friend Sub _ActualizarEstadoPedidoMasivo(idEstadoNuevoParam As String,
                                            tipoEstadoPedido As String,
                                            idUsuario As String,
                                            observ As String,
                                            idCriticidad As String,
                                            fechaEntrega As Date?,
                                            cantidadCambioIndividual As Decimal?,
                                            idResponsable As Integer,
                                            fechaNuevoEstado As Date?,
                                            tablagrabar As DataTable,
                                            metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                            idFuncion As String)
      Dim idEstadoNuevo As String = idEstadoNuevoParam

      Dim idTipoComprobante As String
      Dim letra As String
      Dim centroEmisor As Integer
      Dim numeroPedido As Long
      Dim idSucursal As Integer

      Dim depOrigen As Integer
      Dim ubiOrigen As Integer

      Dim idProd As String
      Dim fechaEstado As Date
      Dim orden As Integer
      Dim idTipoEstadoAnterior As String
      Dim cantEstado As Decimal
      Dim idEstadoAnterior As String

      If Not fechaNuevoEstado.HasValue Then
         fechaNuevoEstado = Now
      End If
      Dim FechaNuevoEstadoInicial As Date = fechaNuevoEstado.Value

      Dim dicVentaAGenerar As Dictionary(Of String, List(Of DataRow)) = New Dictionary(Of String, List(Of DataRow))()
      Dim dicPedidosAGenerar As Dictionary(Of String, List(Of DataRow)) = New Dictionary(Of String, List(Of DataRow))()
      Dim dicProduccionAGenerar As Dictionary(Of String, List(Of DataRow)) = New Dictionary(Of String, List(Of DataRow))()


      Dim sqlPE As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)
      Dim fechaEntregaNull As Boolean = Not fechaEntrega.HasValue
      Dim idCriticidadNull As Boolean = String.IsNullOrWhiteSpace(idCriticidad)
      Dim idTipoEstado As String

      If Not tablagrabar.Columns.Contains("IdCriticidadGrabar") Then
         tablagrabar.Columns.Add("IdCriticidadGrabar", GetType(String))
      End If
      If Not tablagrabar.Columns.Contains("FechaEntregaGrabar") Then
         tablagrabar.Columns.Add("FechaEntregaGrabar", GetType(Date))
      End If
      For Each filaGrabar As DataRow In tablagrabar.Rows

         If Not filaGrabar.Table.Columns.Contains("ObservacionCambioEstado") Then
            filaGrabar.Table.Columns.Add("ObservacionCambioEstado", GetType(String))
         End If

         filaGrabar("ObservacionCambioEstado") = observ

         idSucursal = Integer.Parse(filaGrabar("IdSucursal").ToString())

         depOrigen = Integer.Parse(filaGrabar("IdDepositoDefecto").ToString())
         ubiOrigen = Integer.Parse(filaGrabar("IdUbicacionDefecto").ToString())

         If String.IsNullOrWhiteSpace(idEstadoNuevoParam) Then
            idEstadoNuevo = filaGrabar("IdEstadoNuevo").ToString()
         End If
         'Viene el Estado pero tambien utilizo el Tipo de Estado
         Dim estadoNuevo = _cache.BuscaEstadosPedido(idEstadoNuevo, tipoEstadoPedido)
         idTipoEstado = estadoNuevo.IdTipoEstado

         idTipoComprobante = filaGrabar(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString()
         letra = filaGrabar(Entidades.Pedido.Columnas.Letra.ToString()).ToString()
         centroEmisor = Integer.Parse(filaGrabar(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString())
         numeroPedido = Long.Parse(filaGrabar(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString())

         idProd = filaGrabar("idProducto").ToString
         fechaEstado = Date.Parse(filaGrabar("fechaEstado").ToString)

         If idCriticidadNull Then   'Si el parámetro viene en blanco esta bandera está en null.
            idCriticidad = filaGrabar("IdCriticidad").ToString
         End If

         If fechaEntregaNull Then
            fechaEntrega = Date.Parse(filaGrabar("FechaEntrega").ToString)
         End If

         filaGrabar("IdCriticidadGrabar") = idCriticidad
         filaGrabar("FechaEntregaGrabar") = fechaEntrega

         idEstadoAnterior = filaGrabar("IdEstado").ToString()

         orden = Integer.Parse(filaGrabar("Orden").ToString)

         idTipoEstadoAnterior = New Reglas.EstadosPedidos().GetUno(filaGrabar("IdEstado").ToString(), tipoEstadoPedido).IdTipoEstado

         If cantidadCambioIndividual.HasValue Then
            filaGrabar("CantEntregada") = cantidadCambioIndividual.Value
         End If
         cantEstado = Decimal.Parse(filaGrabar("CantEntregada").ToString)


         Dim rPP As Reglas.PedidosProductos = New PedidosProductos(da)
         Dim sqlEP As SqlServer.EstadosPedidos = New SqlServer.EstadosPedidos(da)
         Dim sqlPP As SqlServer.PedidosProductos = New SqlServer.PedidosProductos(da)
         Dim dtPedido As DataTable = New PedidosEstados(da).GetPedidosEstadosUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProd, fechaEstado, orden)

         Dim idFact As PedidosEstados.IdComprobanteRelacionado = GetIdComprobanteRelacionadoFromDataRow(filaGrabar, PedidosEstados.IdComprobanteRelacionado.Grupo.Fact)
         Dim idRemito As PedidosEstados.IdComprobanteRelacionado = GetIdComprobanteRelacionadoFromDataRow(filaGrabar, PedidosEstados.IdComprobanteRelacionado.Grupo.Remito)
         Dim idGenerado As PedidosEstados.IdComprobanteRelacionado = GetIdComprobanteRelacionadoFromDataRow(filaGrabar, PedidosEstados.IdComprobanteRelacionado.Grupo.Generado)
         Dim idProduccion As PedidosEstados.IdComprobanteRelacionado = GetIdComprobanteRelacionadoFromDataRow(filaGrabar, PedidosEstados.IdComprobanteRelacionado.Grupo.Produccion)
         Dim idVinculado As PedidosEstados.IdComprobanteRelacionado = GetIdComprobanteRelacionadoFromDataRow(filaGrabar, PedidosEstados.IdComprobanteRelacionado.Grupo.Vinculado)

         If Decimal.Parse(dtPedido.Rows(0)("CantEstado").ToString()) = cantEstado Then
            sqlPE.PedidosEstados_U_Estado(idSucursal,
                                          idTipoComprobante, letra, centroEmisor, numeroPedido,
                                          idProd,
                                          fechaEstado,
                                          idEstadoNuevo,
                                          tipoEstadoPedido,
                                          cantEstado,
                                          fechaNuevoEstado.Value,
                                          observ,
                                          orden,
                                          idCriticidad,
                                          fechaEntrega,
                                          numeroReparto:=0,
                                          anulacionPorModificacion:=False)
         Else
            sqlPE.PedidosEstados_I(idSucursal,
                                    idTipoComprobante,
                                    letra,
                                    centroEmisor,
                                    numeroPedido,
                                    idProd,
                                    fechaNuevoEstado.Value,
                                    idEstadoNuevo,
                                    idUsuario,
                                    observ,
                                    cantEstado,
                                    idFact.IdSucursal,
                                    idFact.IdTipoComprobante,
                                    idFact.Letra,
                                    idFact.CentroEmisor,
                                    idFact.Numero,
                                    orden,
                                    idCriticidad,
                                    fechaEntrega,
                                    tipoEstadoPedido,
                                    0,
                                    idGenerado.IdSucursal,
                                    idGenerado.IdTipoComprobante,
                                    idGenerado.Letra,
                                    idGenerado.CentroEmisor,
                                    idGenerado.Numero,
                                    idRemito.IdSucursal,
                                    idRemito.IdTipoComprobante,
                                    idRemito.Letra,
                                    idRemito.CentroEmisor,
                                    idRemito.Numero,
                                    idProduccion.IdSucursal,
                                    idProduccion.IdTipoComprobante,
                                    idProduccion.Letra,
                                    idProduccion.CentroEmisor,
                                    idProduccion.Numero,
                                    idVinculado.IdSucursal,
                                    idVinculado.IdTipoComprobante,
                                    idVinculado.Letra,
                                    idVinculado.CentroEmisor,
                                    idVinculado.Numero,
                                    idVinculado.IdProducto,
                                    idVinculado.Orden,
                                    idVinculado.FechaEstado,
                                    anulacionPorModificacion:=False, idSucursal, depOrigen, ubiOrigen)
            sqlPE.PedidosEstados_U_Cantidad(idSucursal,
                                   idTipoComprobante,
                                   letra,
                                   centroEmisor,
                                   numeroPedido,
                                   idProd,
                                   orden,
                                   fechaEstado,
                                   cantEstado * -1)
         End If

         If Not filaGrabar.Table.Columns.Contains("FechaNuevoEstado") Then
            filaGrabar.Table.Columns.Add("FechaNuevoEstado", GetType(Date))
         End If
         filaGrabar.SetField("FechaNuevoEstado", fechaNuevoEstado.Value)

         rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProd, orden,
                                                         idTipoEstadoAnterior, idTipoEstado, cantEstado)

         ReservaProducto(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProd, orden,
                             idEstadoAnterior, idEstadoNuevo, tipoEstadoPedido, cantEstado,
                             Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, depOrigen, ubiOrigen, depOrigen, ubiOrigen)

         Dim idTipoComprobanteFact As String = sqlEP.getComprobanteXEstado(idEstadoNuevo, tipoEstadoPedido)

         If Not String.IsNullOrEmpty(idTipoComprobanteFact) Then
            Dim tipoComprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(idTipoComprobanteFact)

            If tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.VENTAS.ToString() Then
               Dim idSucursalComprobante As Integer = idSucursal
               If IsNumeric(filaGrabar("IdSucursalTipoComprobanteDestino")) AndAlso Integer.Parse(filaGrabar("IdSucursalTipoComprobanteDestino").ToString()) > 0 Then
                  idSucursalComprobante = Integer.Parse(filaGrabar("IdSucursalTipoComprobanteDestino").ToString())
               End If

               Dim clavePedido As String = String.Format("{0}\{1}\{2}\{3:0000}\{4:00000000}\{5}\{6}", idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, tipoComprobante.IdTipoComprobante,
                                                         idSucursalComprobante)
               If Not dicVentaAGenerar.ContainsKey(clavePedido) Then
                  dicVentaAGenerar.Add(clavePedido, New List(Of DataRow))
               End If
               dicVentaAGenerar(clavePedido).Add(filaGrabar)
            ElseIf tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString() Then
               Dim clavePedido As String = String.Format("{0}\{1}\{2}\{3:0000}\{4:00000000}\{5}", idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, tipoComprobante.IdTipoComprobante)
               If Not dicPedidosAGenerar.ContainsKey(clavePedido) Then
                  dicPedidosAGenerar.Add(clavePedido, New List(Of DataRow))
               End If
               dicPedidosAGenerar(clavePedido).Add(filaGrabar)
            ElseIf tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PRODUCCION.ToString() Then
               Dim clavePedido As String
               If Reglas.Publicos.PedidoGeneraOrdenProduccionPorProducto Then
                  clavePedido = String.Format("{0}\{1}\{2}\{3:0000}\{4:00000000}\{5}\{6}", idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, tipoComprobante.IdTipoComprobante, orden)
               Else
                  clavePedido = String.Format("{0}\{1}\{2}\{3:0000}\{4:00000000}\{5}", idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, tipoComprobante.IdTipoComprobante)
               End If

               If Not dicProduccionAGenerar.ContainsKey(clavePedido) Then
                  dicProduccionAGenerar.Add(clavePedido, New List(Of DataRow))
               End If
               dicProduccionAGenerar(clavePedido).Add(filaGrabar)
            End If      'If tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.VENTAS.ToString() Then
            'Y DE        ElseIf tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString() Then
            'Y DE        ElseIf tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PRODUCCION.ToString() Then

         End If         'If Not String.IsNullOrEmpty(IdTipoComprobanteFact) Then

         'da.CommitTransaction()

         fechaNuevoEstado = fechaNuevoEstado.Value.AddSeconds(1)
      Next           'For Each filaGrabar As DataRow In tablagrabar.Rows

      CreaVentaDesdePedido(dicVentaAGenerar, FechaNuevoEstadoInicial, fechaNuevoEstado.Value, idResponsable, idFuncion, sqlPE)

      For Each valores As KeyValuePair(Of String, List(Of DataRow)) In dicPedidosAGenerar
         Dim valoresCol As String() = valores.Key.Split("\"c)

         Dim tipoComprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(valoresCol(5))

         Dim idSucursalPresup As Integer = Integer.Parse(valoresCol(0))
         Dim IdTipoComprobantePresup As String = valoresCol(1)
         Dim LetraPresup As String = valoresCol(2)
         Dim CentroEmisorPresup As Integer = Integer.Parse(valoresCol(3))
         Dim NumeroPedidoPresup As Long = Long.Parse(valoresCol(4))

         Dim presup As Entidades.Pedido = New Pedidos(da).GetUno(idSucursalPresup, IdTipoComprobantePresup, LetraPresup, CentroEmisorPresup, NumeroPedidoPresup, estadoPedido:=Nothing)

         Dim pedido As Entidades.Pedido
         Dim rPedidos As Pedidos = New Pedidos(da)
         pedido = rPedidos.CrearPedido(tipoComprobante,
                                       presup.Cliente,
                                       String.Empty, Nothing,
                                       Nothing,
                                       Today,
                                       presup.Cliente.Vendedor,
                                       caja:=Nothing,
                                       presup.Transportista,
                                       presup.FormaPago,
                                       presup.TipoComprobanteFact,
                                       presup.Observacion,
                                       presup.EstadoVisita,
                                       presup.NumeroOrdenCompra,
                                       presup.DescuentoRecargoPorc,
                                       presup.ClienteVinculado,
                                       presup.IdMoneda, cotizacionDolar:=presup.CotizacionDolar, presup.IdPlazoEntrega, presup.ValidezPresupuesto)
         '                             String.Empty,

         With pedido
            If pedido.Cliente.EsClienteGenerico Then
               .NombreClienteGenerico = presup.NombreClienteGenerico
               .Cuit = presup.Cuit
               .TipoDocCliente = presup.TipoDocCliente
               .NroDocCliente = presup.NroDocCliente.IfNull()
            End If
            .Direccion = presup.Direccion
            .IdLocalidad = presup.IdLocalidad.IfNull()
         End With

         For Each drFilaGrabar As DataRow In valores.Value
            idProd = drFilaGrabar("idProducto").ToString()
            Dim oProducto As Entidades.Producto = New Entidades.Producto
            oProducto = New Reglas.Productos(da).GetUno(idProd)
            Dim ordenPresup As Integer = Integer.Parse(drFilaGrabar("Orden").ToString)
            Dim CantEstadoPresup As Decimal = Decimal.Parse(drFilaGrabar("CantEntregada").ToString)

            For Each x In valores.Value.Where(Function(dr)
                                                 Return dr.Field(Of String)("IdProducto") = drFilaGrabar.Field(Of String)("IdProducto") AndAlso
                                                        dr.Field(Of String)("NombreProducto") = drFilaGrabar.Field(Of String)("NombreProducto") AndAlso
                                                        dr.Field(Of Integer)("Orden") = drFilaGrabar.Field(Of Integer)("Orden") AndAlso
                                                        dr.Field(Of String)("IdCriticidad") = drFilaGrabar.Field(Of String)("IdCriticidad") AndAlso
                                                        Not dr.Equals(drFilaGrabar)
                                              End Function)
               CantEstadoPresup += x.Field(Of Decimal)("CantEntregada")
               x("CantEntregada") = 0
            Next

            drFilaGrabar("CantEntregada") = 0

            If CantEstadoPresup = 0 Then Continue For

            Dim presupProd As Entidades.PedidoProducto = New PedidosProductos(da).GetUno(idSucursalPresup, IdTipoComprobantePresup, LetraPresup, CentroEmisorPresup, NumeroPedidoPresup,
                                                                                         ordenPresup, idProd)

            Dim precio As Decimal = presupProd.Precio
            Dim usaPrecioSinIVA As Boolean = (pedido.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
                                             Not pedido.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Or
                                             Not pedido.TipoComprobante.UtilizaImpuestos
            If Not usaPrecioSinIVA Then

               precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(presupProd.Precio, oProducto.Alicuota, oProducto.PorcImpuestoInterno,
                                                                             oProducto.ImporteImpuestoInterno, oProducto.OrigenPorcImpInt)
            End If

            Dim pedidoProducto As Entidades.PedidoProducto

            pedidoProducto = rPedidos.CrearPedidoProducto(producto:=oProducto,
                                                          productoDescripcion:=presupProd.NombreProducto,
                                                          descuentoRecargoPorc1:=presupProd.DescuentoRecargoPorc,
                                                          descuentoRecargoPorc2:=presupProd.DescuentoRecargoPorc2,
                                                          precio:=precio,
                                                          cantidad:=CantEstadoPresup,
                                                          tipoImpuesto:=presupProd.TipoImpuesto,
                                                          porcentajeIva:=Nothing,
                                                          idListaDePrecios:=presupProd.IdListaPrecios,
                                                          idCriticidad:=presupProd.IdCriticidad,
                                                          fechaEntrega:=Today,
                                                          pedido:=pedido,
                                                          redondeoEnCalculo:=2,
                                                          kilosModif:=presupProd.Kilos,
                                                          precioVentaPorTamano:=presupProd.PrecioVentaPorTamano,
                                                          tamano:=presupProd.Tamano,
                                                          idUnidadDeMedida:=presupProd.IdUnidadDeMedida,
                                                          moneda:=presupProd.Moneda,
                                                          espmm:=presupProd.Espmm,
                                                          espPulgadas:=presupProd.EspPulgadas,
                                                          codigoSAE:=presupProd.CodigoSAE,
                                                          produccionProceso:=presupProd.ProduccionProceso,
                                                          produccionForma:=presupProd.ProduccionForma,
                                                          largoExtAlto:=presupProd.LargoExtAlto,
                                                          anchoIntBase:=presupProd.AnchoIntBase,
                                                          architrave:=presupProd.Architrave,
                                                          modelo:=presupProd.ProduccionModeloForma,
                                                          urlPlano:=presupProd.UrlPlano,
                                                          idFormula:=presupProd.IdFormula,
                                                          tipoOperacion:=presupProd.TipoOperacion,
                                                          nota:=presupProd.Nota,
                                                          costo:=presupProd.Costo)
            pedidoProducto.IdProcesoProductivo = presupProd.IdProcesoProductivo
            rPedidos.AgregarLinea(pedido, pedidoProducto)

            pedidoProducto.PedidosProductosFormulas = presupProd.PedidosProductosFormulas

         Next        'For Each drFilaGrabar As DataRow In valores.Value

         For Each pedCont In presup.PedidosContactos
            rPedidos.AgregarContacto(pedido, pedCont.Contacto)
         Next

         For Each pedObs In presup.PedidosObservaciones
            rPedidos.AgregarObservacion(pedido, pedObs)
         Next

         Dim pedidoGenerado As Entidades.Pedido = rPedidos.Inserta(pedido)

         For Each drFilaGrabar As DataRow In valores.Value
            Dim idProdPres As String = drFilaGrabar("idProducto").ToString()
            Dim ordenPresup As Integer = Integer.Parse(drFilaGrabar("Orden").ToString)

            sqlPE.PedidosEstados_U_Ped(presup.IdSucursal, presup.IdTipoComprobante, presup.LetraComprobante, presup.CentroEmisor,
                                       presup.NumeroPedido, idProdPres, FechaNuevoEstadoInicial, fechaNuevoEstado, ordenPresup,
                                       pedidoGenerado.IdSucursal, pedidoGenerado.IdTipoComprobante, pedidoGenerado.LetraComprobante,
                                       pedidoGenerado.CentroEmisor, pedidoGenerado.NumeroPedido)
         Next


      Next           'For Each valores As KeyValuePair(Of String, List(Of DataRow)) In dicPedidosAGenerar


      CreaProduccionDesdePedido(dicProduccionAGenerar, FechaNuevoEstadoInicial, fechaNuevoEstado.Value, idResponsable, sqlPE)

   End Sub

   Public Sub ConsumirPedido(fecha As Date, numeroReparto As Integer, tipoTipoComprobante As String,
                             idEstadoAnterior As String, idEstadoNuevo As String, observaciones As String,
                             idProducto As String, cantidadProducto As Decimal, idCliente As Long, pedidos() As Entidades.IPKComprobante, idSucursalParaBuscarPedido As Integer,
                             alInvocarPedidoAfectaFactura As Boolean, alInvocarPedidoAfectaRemito As Boolean, invocarPedidosConEstadoEspecifico As Boolean,
                             idSucursalInvocador As Integer, idTipoComprobanteInvocador As String, letraInvocador As String, centroEmisorInvocador As Short, numeroComprobanteInvocador As Long,
                             anulacionPorModificacion As Boolean,
                             idFuncion As String, ByRef cont As Integer, Cache As BusquedasCacheadas)
      Dim sql = New SqlServer.Pedidos(da)
      Dim sqlPP = New SqlServer.PedidosProductos(da)
      Dim rPP = New PedidosProductos(da)
      Dim sqlPE = New SqlServer.PedidosEstados(da)
      Dim rPE = Me

      Dim idTipoEstadoAnterior = _cache.BuscaEstadosPedido(idEstadoAnterior, tipoTipoComprobante).IdTipoEstado
      Dim idTipoEstadoNuevo = _cache.BuscaEstadosPedido(idEstadoNuevo, tipoTipoComprobante).IdTipoEstado

      Using tablaPedidos = sql.GetPedidosXClienteProducto(idSucursalParaBuscarPedido,
                                                          If(invocarPedidosConEstadoEspecifico, idEstadoAnterior, String.Empty),
                                                          idProducto,
                                                          idCliente,
                                                          pedidos,
                                                          tipoTipoComprobante,
                                                          alInvocarPedidoAfectaFactura,
                                                          alInvocarPedidoAfectaRemito)

         ' para cada pedido me fijo que puedo facturar...
         For Each drPedido As DataRow In tablaPedidos.Rows
            Select Case cantidadProducto ' la cantidad del producto puede ser mayor 0 Igual, menor

               Case Is >= drPedido.Field(Of Decimal)("cantEntregada") ' en este caso "sobra cantidad" facturo y finalizo
                  Dim fechaEntrega = Date.Parse(drPedido(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString())
                  If invocarPedidosConEstadoEspecifico Then
                     sqlPE.PedidosEstados_U_Estado(
                                          Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                          drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                          drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                          Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                          Integer.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                          idProducto,
                                          Date.Parse(drPedido("FechaEstado").ToString()),
                                          idEstadoNuevo,
                                          tipoTipoComprobante,
                                          Decimal.Parse(drPedido("cantEntregada").ToString()),
                                          fecha.AddSeconds(cont),
                                          "Facturación Automática",
                                          Integer.Parse(drPedido("Orden").ToString()),
                                          drPedido("IdCriticidad").ToString(),
                                          Date.Parse(drPedido("FechaEntrega").ToString()),
                                          numeroReparto,
                                          anulacionPorModificacion)

                     rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(
                                          Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                          drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                          drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                          Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                          Integer.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                          idProducto,
                                          Integer.Parse(drPedido("Orden").ToString()),
                                          idTipoEstadoAnterior,
                                          idTipoEstadoNuevo,
                                          Decimal.Parse(drPedido("cantEntregada").ToString()))

                     rPE.ReservaProducto(Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                          drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                          drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                          Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                          Integer.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                          idProducto,
                                          Integer.Parse(drPedido("Orden").ToString()),
                                          idEstadoAnterior, idEstadoNuevo, "PEDIDOSCLIE", Decimal.Parse(drPedido("cantEntregada").ToString()),
                                          Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, 0, 0,
                                          Integer.Parse(drPedido("IdDepositoDefecto").ToString()),
                                          Integer.Parse(drPedido("IdUbicacionDefecto").ToString()))

                     fechaEntrega = fecha.AddSeconds(cont)
                  End If         'If InvocarPedidosConEstadoEspecifico Then

                  If alInvocarPedidoAfectaFactura Then
                     sqlPE.PedidosEstados_U_Fact(Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                  drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                  drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                  Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                  Integer.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                  idProducto, fechaEntrega,
                                                  idSucursalInvocador,
                                                  idTipoComprobanteInvocador, letraInvocador,
                                                  centroEmisorInvocador, numeroComprobanteInvocador,
                                                  Integer.Parse(drPedido("Orden").ToString()))
                  End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaFactura Then
                  If alInvocarPedidoAfectaRemito Then
                     sqlPE.PedidosEstados_U_Remito(Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                Integer.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                idProducto, fechaEntrega,
                                                idSucursalInvocador, idTipoComprobanteInvocador, letraInvocador,
                                                centroEmisorInvocador, numeroComprobanteInvocador,
                                                Integer.Parse(drPedido("Orden").ToString()))
                  End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaRemito Then

                  cont += 1
               Case Is < Decimal.Parse(drPedido("cantEntregada").ToString()) ' facturo y el resto pasa a pendiente


                  'Si al facturar repite el codigo da error de PK, tomo la fecha en cada momento esperando que los Segundos eviten el error por PK.
                  'FechaNuevoEstado = Date.Parse(Date.Now.ToString("yyyy-MM-dd HH:mm:ss")).AddSeconds(Cont)
                  Dim FechaNuevoEstado = fecha.AddSeconds(cont) '' Date.Parse(Fecha.ToString("yyyy-MM-dd HH:mm")).AddSeconds(Cont)

                  Dim idFact = rPE.GetIdComprobanteRelacionadoFromDataRow(drPedido, IdComprobanteRelacionado.Grupo.Fact)
                  Dim idRemito = rPE.GetIdComprobanteRelacionadoFromDataRow(drPedido, IdComprobanteRelacionado.Grupo.Remito)
                  Dim idGenerado = rPE.GetIdComprobanteRelacionadoFromDataRow(drPedido, IdComprobanteRelacionado.Grupo.Generado)
                  Dim idProduccion = rPE.GetIdComprobanteRelacionadoFromDataRow(drPedido, IdComprobanteRelacionado.Grupo.Produccion)
                  Dim idVinculado = rPE.GetIdComprobanteRelacionadoFromDataRow(drPedido, IdComprobanteRelacionado.Grupo.Vinculado)

                  If alInvocarPedidoAfectaFactura Then
                     idFact.IdSucursal = idSucursalInvocador
                     idFact.IdTipoComprobante = idTipoComprobanteInvocador
                     idFact.Letra = letraInvocador
                     idFact.CentroEmisor = centroEmisorInvocador
                     idFact.Numero = numeroComprobanteInvocador
                  End If
                  If alInvocarPedidoAfectaRemito Then
                     idRemito.IdSucursal = idSucursalInvocador
                     idRemito.IdTipoComprobante = idTipoComprobanteInvocador
                     idRemito.Letra = letraInvocador
                     idRemito.CentroEmisor = centroEmisorInvocador
                     idRemito.Numero = numeroComprobanteInvocador
                  End If

                  If Not invocarPedidosConEstadoEspecifico Then
                     idEstadoNuevo = drPedido(Entidades.PedidoEstado.Columnas.IdEstado.ToString()).ToString()
                     idTipoEstadoNuevo = Cache.BuscaEstadosPedido(idEstadoNuevo, tipoTipoComprobante).IdTipoEstado
                  End If

                  sqlPE.PedidosEstados_I(Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                       drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                       drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                       Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                       Integer.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                       idProducto,
                                       FechaNuevoEstado,
                                       idEstadoNuevo,
                                       actual.Nombre,
                                       observaciones,
                                       cantidadProducto,
                                       If(idFact.Numero > 0, idFact.IdSucursal, 0),
                                       idFact.IdTipoComprobante,
                                       idFact.Letra,
                                       idFact.CentroEmisor,
                                       idFact.Numero,
                                       Integer.Parse(drPedido("Orden").ToString()),
                                       drPedido("IdCriticidad").ToString(),
                                       Date.Parse(drPedido("FechaEntrega").ToString()),
                                       tipoTipoComprobante,
                                       numeroReparto,
                                       idGenerado.IdSucursal,
                                       idGenerado.IdTipoComprobante,
                                       idGenerado.Letra,
                                       idGenerado.CentroEmisor,
                                       idGenerado.Numero,
                                       idRemito.IdSucursal,
                                       idRemito.IdTipoComprobante,
                                       idRemito.Letra,
                                       idRemito.CentroEmisor,
                                       idRemito.Numero,
                                       idProduccion.IdSucursal,
                                       idProduccion.IdTipoComprobante,
                                       idProduccion.Letra,
                                       idProduccion.CentroEmisor,
                                       idProduccion.Numero,
                                       idVinculado.IdSucursal,
                                       idVinculado.IdTipoComprobante,
                                       idVinculado.Letra,
                                       idVinculado.CentroEmisor,
                                       idVinculado.Numero,
                                       idVinculado.IdProducto,
                                       idVinculado.Orden,
                                       idVinculado.FechaEstado,
                                       anulacionPorModificacion,
                                       Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                       Integer.Parse(drPedido("IdDepositoDefecto").ToString()),
                                       Integer.Parse(drPedido("IdUbicacionDefecto").ToString()))

                  sqlPE.PedidosEstados_U_Cantidad(Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                               drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                               drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                               Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                               Long.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                               drPedido(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                                               Integer.Parse(drPedido(Entidades.PedidoEstado.Columnas.Orden.ToString()).ToString()),
                                               DateTime.Parse(drPedido(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString()),
                                               cantidadProducto * -1)

                  If invocarPedidosConEstadoEspecifico Then
                     rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                                  drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                                  drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                                  Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                                  Integer.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                                  idProducto,
                                                                  Integer.Parse(drPedido("Orden").ToString()),
                                                                  idTipoEstadoAnterior,
                                                                  idTipoEstadoNuevo,
                                                                  cantidadProducto)

                     rPE.ReservaProducto(Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                          drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                          drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                          Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                          Integer.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                          idProducto,
                                          Integer.Parse(drPedido("Orden").ToString()),
                                          idEstadoAnterior, idEstadoNuevo, "PEDIDOSCLIE", Decimal.Parse(drPedido("cantEntregada").ToString()),
                                          Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, 0, 0,
                                          Integer.Parse(drPedido("IdDepositoDefecto").ToString()),
                                          Integer.Parse(drPedido("IdUbicacionDefecto").ToString()))
                  End If         'If InvocarPedidosConEstadoEspecifico Then

                  If alInvocarPedidoAfectaFactura Then
                     sqlPE.PedidosEstados_U_Fact(Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                              drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                              drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                              Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                              Integer.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                              idProducto, FechaNuevoEstado,
                                              idSucursalInvocador, idTipoComprobanteInvocador, letraInvocador, centroEmisorInvocador, numeroComprobanteInvocador,
                                              Integer.Parse(drPedido("Orden").ToString()))
                  End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaFactura Then
                  If alInvocarPedidoAfectaRemito Then
                     sqlPE.PedidosEstados_U_Remito(Integer.Parse(drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                Integer.Parse(drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                Integer.Parse(drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                idProducto, FechaNuevoEstado,
                                                idSucursalInvocador, idTipoComprobanteInvocador, letraInvocador, centroEmisorInvocador, numeroComprobanteInvocador,
                                                Integer.Parse(drPedido("Orden").ToString()))
                  End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaRemito Then
                  cont += 1
            End Select

            cantidadProducto = cantidadProducto - Decimal.Parse(drPedido("cantEntregada").ToString())

            If cantidadProducto <= 0 Then
               Exit For ' salgo xq no tengo mas cantidad facturada
            End If

         Next
      End Using
   End Sub


   Private Sub CreaVentaDesdePedido(dicVentaAGenerar As Dictionary(Of String, List(Of DataRow)),
                                    fechaNuevoEstadoInicial As Date,
                                    fechaNuevoEstado As Date,
                                    IdResponsable As Integer,
                                    idFuncion As String,
                                    sqlPE As SqlServer.PedidosEstados)

      Dim valoresCol As String()
      Dim tipoComprobanteFact As Entidades.TipoComprobante
      Dim idSucursalPedido As Integer
      Dim idTipoComprobantePedido As String
      Dim letraPedido As String
      Dim centroEmisorPedido As Integer
      Dim numeroPedidoPedido As Long
      Dim idSucursalComprobante As Integer
      Dim pedido As Entidades.Pedido

      Dim formaDePagoCtaCte As Entidades.VentaFormaPago = New Reglas.VentasFormasPago().GetUna("VENTAS", False)

      For Each valores As KeyValuePair(Of String, List(Of DataRow)) In dicVentaAGenerar
         valoresCol = valores.Key.Split("\"c)
         tipoComprobanteFact = _cache.BuscaTipoComprobante(valoresCol(5))

         idSucursalPedido = Integer.Parse(valoresCol(0))
         idTipoComprobantePedido = valoresCol(1)
         letraPedido = valoresCol(2)
         centroEmisorPedido = Integer.Parse(valoresCol(3))
         numeroPedidoPedido = Long.Parse(valoresCol(4))

         If valoresCol.Length > 6 Then
            idSucursalComprobante = Integer.Parse(valoresCol(6))
         Else
            idSucursalComprobante = idSucursalPedido
         End If

         pedido = New Pedidos(da).GetUno(idSucursalPedido, idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedidoPedido, estadoPedido:=Nothing)

         Dim rVentas As Reglas.Ventas = New Reglas.Ventas(da)

         Dim nuevaVenta As Entidades.Venta
         'Dim Importe As Decimal = CantEstado * Decimal.Parse(dtPedido.Rows(0)("Precio").ToString())

         Dim Observacion As String
         Observacion = String.Format("Generado por Cambio de Estado de: {0} {1} {2:0000}-{3:00000000}. Fecha: {4:dd/MM/yyyy}",
                                     idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedidoPedido, fechaNuevoEstado).Truncar(100)

         Dim descuentoRecargoPorc As Decimal? = Nothing
         If Not pedido.TipoComprobante.CargaDescRecGralActual Then
            descuentoRecargoPorc = pedido.DescuentoRecargoPorc
         End If
         nuevaVenta = rVentas.CreaVenta(idSucursalComprobante,
                                        tipoComprobanteFact, String.Empty, 0, Nothing,
                                        pedido.Cliente, Nothing,
                                        fechaNuevoEstado, pedido.Cliente.Vendedor,
                                        Nothing, formaDePagoCtaCte,
                                        descuentoRecargoPorc, idCaja:=0, cotizacionDolar:=pedido.CotizacionDolar, mercDespachada:=False,
                                        numeroReparto:=Nothing, fechaEnvio:=Nothing, proveedor:=Nothing,
                                        observaciones:=Observacion, cobrador:=Nothing, clienteVinculado:=Nothing, nroOrdenCompra:=0)
         nuevaVenta.NumeroComprobante = 0

         For Each filaGrabar As DataRow In valores.Value
            Dim CantEstado As Decimal = Decimal.Parse(filaGrabar("CantEntregada").ToString())
            Dim producto As Entidades.Producto = _cache.BuscaProductoEntidadPorId(filaGrabar("IdProducto").ToString(), da)

            Dim pedProd = New PedidosProductos(da).GetUno(pedido.IdSucursal, pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido,
                                                          filaGrabar.Field(Of Integer)("Orden"), producto.IdProducto)

            Dim idListaPrecios = Publicos.ListaPreciosPredeterminada
            If filaGrabar.Table.Columns.Contains("IdListaPrecios") Then
               idListaPrecios = filaGrabar.Field(Of Integer?)("IdListaPrecios").IfNull(idListaPrecios)
            End If

            Dim descuentoRecargoPorc1 As Decimal = 0
            Dim descuentoRecargoPorc2 As Decimal = 0
            Dim precio As Decimal? = Nothing

            If Not pedido.TipoComprobante.CargaDescRecActual Then
               descuentoRecargoPorc1 = pedProd.DescuentoRecargoPorc
               descuentoRecargoPorc2 = pedProd.DescuentoRecargoPorc2
            End If
            If Not pedido.TipoComprobante.CargaPrecioActual Then
               precio = pedProd.Precio
            End If

            rVentas.AgregarVentaProducto(nuevaVenta, rVentas.CreaVentaProducto(producto,
                                                                               pedProd.NombreProducto,
                                                                               descuentoRecargoPorc1,
                                                                               descuentoRecargoPorc2,
                                                                               precio,
                                                                               CantEstado,
                                                                               _cache.BuscaTiposImpuestos(producto.IdTipoImpuesto),
                                                                               producto.Alicuota,
                                                                               _cache.BuscaListaDePrecios(idListaPrecios),
                                                                               Nothing,
                                                                               Entidades.Producto.TiposOperaciones.NORMAL,
                                                                               "", Nothing,
                                                                               nuevaVenta, 2), 2)

            If pedido.Contactos IsNot Nothing Then
               For Each Contacto As Entidades.PedidoClienteContacto In pedido.Contactos
                  rVentas.AgregarVentaContactos(nuevaVenta, Contacto.Contacto)
               Next
            End If

            ''''Dim orden As Integer = Integer.Parse(filaGrabar("Orden").ToString)

            ''''If nuevaVenta.TipoComprobante.AlInvocarPedidoAfectaFactura Then
            ''''   sqlPE.PedidosEstados_U_Fact(idSucursalPedido,
            ''''                               idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedidoPedido,
            ''''                               producto.IdProducto,
            ''''                               fechaNuevoEstado,
            ''''                               nuevaVenta.IdSucursal,
            ''''                               nuevaVenta.IdTipoComprobante,
            ''''                               nuevaVenta.LetraComprobante,
            ''''                               nuevaVenta.CentroEmisor,
            ''''                               nuevaVenta.NumeroComprobante,
            ''''                               orden)
            ''''End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaFactura Then
            ''''If nuevaVenta.TipoComprobante.AlInvocarPedidoAfectaRemito Then
            ''''   sqlPE.PedidosEstados_U_Remito(idSucursalPedido,
            ''''                                 idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedidoPedido,
            ''''                                 producto.IdProducto,
            ''''                                 fechaNuevoEstado,
            ''''                                 nuevaVenta.IdSucursal,
            ''''                                 nuevaVenta.IdTipoComprobante,
            ''''                                 nuevaVenta.LetraComprobante,
            ''''                                 nuevaVenta.CentroEmisor,
            ''''                                 nuevaVenta.NumeroComprobante,
            ''''                                 orden)
            ''''End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaRemito Then
         Next

         rVentas.Inserta(nuevaVenta, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

         For Each filaGrabar As DataRow In valores.Value
            Dim orden As Integer = Integer.Parse(filaGrabar("Orden").ToString)
            Dim producto As Entidades.Producto = _cache.BuscaProductoEntidadPorId(filaGrabar("IdProducto").ToString(), da)

            Dim fechaNuevoEstado1 = filaGrabar.Field(Of Date?)("FechaNuevoEstado").IfNull(fechaNuevoEstado)

            If nuevaVenta.TipoComprobante.AlInvocarPedidoAfectaFactura Then
               sqlPE.PedidosEstados_U_Fact(idSucursalPedido,
                                           idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedidoPedido,
                                           producto.IdProducto,
                                           fechaNuevoEstado1,
                                           nuevaVenta.IdSucursal,
                                           nuevaVenta.IdTipoComprobante,
                                           nuevaVenta.LetraComprobante,
                                           nuevaVenta.CentroEmisor,
                                           nuevaVenta.NumeroComprobante,
                                           orden)
            End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaFactura Then
            If nuevaVenta.TipoComprobante.AlInvocarPedidoAfectaRemito Then
               sqlPE.PedidosEstados_U_Remito(idSucursalPedido,
                                             idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedidoPedido,
                                             producto.IdProducto,
                                             fechaNuevoEstado1,
                                             nuevaVenta.IdSucursal,
                                             nuevaVenta.IdTipoComprobante,
                                             nuevaVenta.LetraComprobante,
                                             nuevaVenta.CentroEmisor,
                                             nuevaVenta.NumeroComprobante,
                                             orden)
            End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaRemito Then
         Next

      Next

   End Sub


   Private Sub CreaProduccionDesdePedido(dicProduccionAGenerar As Dictionary(Of String, List(Of DataRow)),
                                         fechaNuevoEstadoInicial As Date,
                                         fechaNuevoEstado As Date,
                                         idResponsable As Integer,
                                         sqlPE As SqlServer.PedidosEstados)

      Dim estadoOPNuevo = New Reglas.EstadosOrdenesProduccion().GetUno(Entidades.EstadoOrdenProduccion.ESTADO_ALTA)
      If estadoOPNuevo.ReservaMateriaPrima AndAlso estadoOPNuevo.IdDeposito = 0 Then
         Throw New Exception(String.Format("El estado {0} está configurado para reservar Materia Prima, pero no está configurado el deposito destino.", estadoOPNuevo.IdEstado))
      End If

      Dim valoresCol As String()
      Dim tipoComprobante = New Entidades.TipoComprobante()
      Dim idSucursalPedido As Integer
      Dim IdTipoComprobantePedido As String
      Dim LetraPedido As String
      Dim CentroEmisorPedido As Integer
      Dim NumeroPedidoPedido As Long
      Dim pedido As Entidades.Pedido
      Dim pedidoProd As Entidades.PedidoProducto
      Dim ordProd As Entidades.OrdenProduccion
      Dim oProducto As Entidades.Producto
      Dim rOrdProd As OrdenesProduccion
      Dim idProd As String
      Dim ordenPedido As Integer
      Dim cantEstadoPedido As Decimal
      For Each valores As KeyValuePair(Of String, List(Of DataRow)) In dicProduccionAGenerar
         valoresCol = valores.Key.Split("\"c)

         If tipoComprobante.IdTipoComprobante <> valoresCol(5) Then
            tipoComprobante = New Reglas.TiposComprobantes(da).GetUno(valoresCol(5))
         End If

         idSucursalPedido = Integer.Parse(valoresCol(0))
         IdTipoComprobantePedido = valoresCol(1)
         LetraPedido = valoresCol(2)
         CentroEmisorPedido = Integer.Parse(valoresCol(3))
         NumeroPedidoPedido = Long.Parse(valoresCol(4))

         pedido = New Pedidos(da).GetUno(idSucursalPedido, IdTipoComprobantePedido, LetraPedido, CentroEmisorPedido, NumeroPedidoPedido, estadoPedido:=Nothing)



         If idSucursalPedido <> actual.Sucursal.Id Then
            Throw New Exception(String.Format("El {0} {1} {2:0000}-{3:00000000} pertene a la sucursal {4} ; No se puede generar una orden de produccion desde otra sucursal",
                                              pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido, pedido.IdSucursal))
         End If
         rOrdProd = New OrdenesProduccion(da)
         Dim observ = If(valores.Value.AnySecure(), valores.Value(0).Field(Of String)("ObservacionCambioEstado"), String.Empty)
         ordProd = rOrdProd.CrearOrdenProduccion(tipoComprobante,
                                                 pedido.Cliente,
                                                 String.Empty, Nothing,
                                                 Nothing,
                                                 Today,
                                                 pedido.Cliente.Vendedor,
                                                 pedido.Transportista,
                                                 pedido.FormaPago,
                                                 pedido.TipoComprobanteFact,
                                                 observ,
                                                 pedido.EstadoVisita,
                                                 0)

         Dim converter = New Entidades.FormulaConverter()
         For Each drFilaGrabar As DataRow In valores.Value
            If Not drFilaGrabar.Table.Columns.Contains("OP") Then
               drFilaGrabar.Table.Columns.Add("OP", GetType(Object))
            End If


            idProd = drFilaGrabar("idProducto").ToString()
            oProducto = New Reglas.Productos(da).GetUno(idProd)
            ordenPedido = Integer.Parse(drFilaGrabar("Orden").ToString)
            cantEstadoPedido = Decimal.Parse(drFilaGrabar("CantEntregada").ToString)

            Dim idCriticidadGrabar = drFilaGrabar.Field(Of String)("IdCriticidadGrabar")
            Dim fechaEntregaGrabar = drFilaGrabar.Field(Of Date)("FechaEntregaGrabar")


            pedidoProd = New PedidosProductos(da).GetUno(idSucursalPedido, IdTipoComprobantePedido, LetraPedido, CentroEmisorPedido, NumeroPedidoPedido,
                                                         ordenPedido, idProd)

            Dim precio As Decimal = pedidoProd.Precio
            Dim usaPrecioSinIVA As Boolean = (ordProd.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
                                             Not ordProd.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos
            If Not usaPrecioSinIVA Then
               precio = pedidoProd.PrecioConImpuestos
            End If

            Dim ordProdProd As Entidades.OrdenProduccionProducto
            '-- REQ-41642.- -------------------------------------------------
            ordProdProd = rOrdProd.CrearOrdenProduccionProducto(oProducto,
                                                                pedidoProd.NombreProducto,
                                                                pedidoProd.DescuentoRecargoPorc,
                                                                pedidoProd.DescuentoRecargoPorc2,
                                                                precio,
                                                                cantEstadoPedido,
                                                                pedidoProd.TipoImpuesto,
                                                                oProducto.Alicuota,
                                                                pedidoProd.IdListaPrecios,
                                                                idCriticidadGrabar,
                                                                fechaEntregaGrabar,
                                                                ordProd,
                                                                2,
                                                                pedidoProd.Espmm,
                                                                pedidoProd.EspPulgadas,
                                                                pedidoProd.CodigoSAE,
                                                                pedidoProd.ProduccionProceso,
                                                                pedidoProd.ProduccionForma,
                                                                pedidoProd.LargoExtAlto,
                                                                pedidoProd.AnchoIntBase,
                                                                pedidoProd.Architrave,
                                                                pedidoProd.ProduccionModeloForma,
                                                                pedidoProd.UrlPlano,
                                                                pedidoProd.IdFormula,
                                                                idResponsable,
                                                                pedidoProd.IdProcesoProductivo,
                                                                idSucursalPedido,
                                                                IdTipoComprobantePedido,
                                                                LetraPedido,
                                                                CentroEmisorPedido,
                                                                Integer.Parse(NumeroPedidoPedido.ToString()),
                                                                idProd,
                                                                ordenPedido)
            '-----------------------------------------------------------------
            rOrdProd.AgregarLinea(ordProd, ordProdProd)
            If oProducto.IdProcesoProductivoDefecto.IfNull() = 0 Then
               rOrdProd.AgregarFormula(ordProdProd, converter.ConvertirFormulaPedidoEnOP(pedidoProd.PedidosProductosFormulas))
               ordProdProd.PrecioLista = pedidoProd.PrecioLista
            End If

            drFilaGrabar("OP") = ordProdProd

         Next

         If tipoComprobante.GeneraObservConInvocados Then
            Dim formato As String = "Invoco: {0} ´{1}´ {2:0000}-{3:00000000}. Emision: {4:dd/MM/yyyy}"
            If pedido.NumeroOrdenCompra <> 0 Then
               formato = String.Concat(formato, " - O. de Compra: {5}")
            End If
            Dim oOrdenProduccionObservacion = New Entidades.OrdenProduccionObservacion() With
            {
               .IdSucursal = ordProd.IdSucursal,
               .IdTipoComprobante = ordProd.IdTipoComprobante,
               .Letra = ordProd.LetraComprobante,
               .CentroEmisor = ordProd.CentroEmisor,
               .NumeroOrdenProduccion = ordProd.NumeroOrdenProduccion,
               .Linea = ordProd.OrdenesProduccionObservaciones.Count + 1,
               .Observacion = String.Format(formato,
                                            pedido.TipoComprobante.Descripcion,
                                            pedido.LetraComprobante,
                                            pedido.CentroEmisor,
                                            pedido.NumeroPedido,
                                            pedido.Fecha,
                                            pedido.NumeroOrdenCompra).Truncar(100)
            }
            ordProd.OrdenesProduccionObservaciones.Add(oOrdenProduccionObservacion)
         End If
         'Importo Observaciones segun parametro tipo comprobante
         If tipoComprobante.ImportaObservDeInvocados Then
            For Each dr In pedido.PedidosObservaciones
               Dim oOrdenProduccionObservacion = New Entidades.OrdenProduccionObservacion() With
               {
                  .IdSucursal = ordProd.IdSucursal,
                  .IdTipoComprobante = ordProd.IdTipoComprobante,
                  .Letra = ordProd.LetraComprobante,
                  .CentroEmisor = ordProd.CentroEmisor,
                  .NumeroOrdenProduccion = ordProd.NumeroOrdenProduccion,
                  .Linea = ordProd.OrdenesProduccionObservaciones.Count + 1,
                  .Observacion = dr.Observacion
               }
               ordProd.OrdenesProduccionObservaciones.Add(oOrdenProduccionObservacion)
            Next
         End If

         Dim ordProdGenerado = rOrdProd.Inserta(ordProd)

         For Each drFilaGrabar As DataRow In valores.Value
            Dim idProdPres As String = drFilaGrabar("idProducto").ToString()
            ordenPedido = Integer.Parse(drFilaGrabar("Orden").ToString)

            Dim ordProdProd = DirectCast(drFilaGrabar("OP"), Entidades.OrdenProduccionProducto)

            sqlPE.PedidosEstados_U_OP(pedido.IdSucursal, pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor,
                                      pedido.NumeroPedido, idProdPres, fechaNuevoEstadoInicial, fechaNuevoEstado, ordenPedido,
                                      ordProdGenerado.IdSucursal, ordProdGenerado.IdTipoComprobante, ordProdGenerado.LetraComprobante,
                                      ordProdGenerado.CentroEmisor, ordProdGenerado.NumeroOrdenProduccion,
                                      ordProdProd.IdProducto, ordProdProd.Orden)
         Next
      Next
   End Sub

   Public Sub ReservaProducto(idSucursal As Integer,
                              idTipoComprobante As String,
                              letra As String,
                              centroEmisor As Integer,
                              numeroPedido As Long,
                              idProducto As String,
                              orden As Integer,
                              idEstadoAnterior As String,
                              idEstadoNuevo As String,
                              TipoEstadoPedido As String,
                              cantidad As Decimal,
                              MetodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                              IdFuncion As String,
                              idDepOrigen As Integer,
                              IdUbiOrigen As Integer,
                              idDepPedEst As Integer,
                              IdUbiPedEst As Integer)

      Dim estadoAnterior As Entidades.EstadoPedido = _cache.BuscaEstadosPedido(idEstadoAnterior, TipoEstadoPedido, AccionesSiNoExisteRegistro.Vacio)
      Dim estadoNuevo As Entidades.EstadoPedido = _cache.BuscaEstadosPedido(idEstadoNuevo, TipoEstadoPedido)

      Dim idDepDestino As Integer
      Dim idUbiDestino As Integer

      'Solo debo realizar movimientos de Stock->Reservado y de Reservado->Stock si difieren en la propiedad ReservaMateriaPrima.
      'Si es igual esta propiedad significa que no cambian de un lado a otro las cantidades.
      If estadoAnterior.ReservaStock <> estadoNuevo.ReservaStock Then
         Dim coeficienteStock As Integer

         If Not estadoAnterior.ReservaStock And estadoNuevo.ReservaStock Then
            'Si el estado actual no reserva MP (PENDIENTE) y el nuevo si lo hace (EN PROCESO) el coeficiente es NEGATIVO, porque se descuenta MP de Stock.
            coeficienteStock = -1
            '-- Verifico si trae valores de Deposito y Ubicacion.-
            If idDepOrigen = 0 Then
               Dim eProd = New Reglas.ProductosSucursales()._GetUno(idSucursal, idProducto)
               '-- Recupera Datos del Producto.-
               idDepOrigen = eProd.IdDepositoDefecto
               IdUbiOrigen = eProd.IdUbicacionDefecto
            End If
            idDepDestino = estadoNuevo.IdDeposito
            idUbiDestino = estadoNuevo.IdUbicacion
         Else
            'Si el estado actual reserva MP (EN PROCESO) y el nuevo no lo hace (FINALIZADO) el coeficiente es POSITIVO, porque se incrementa MP de Stock.
            coeficienteStock = 1
            '-- Carga los Depositos y las Ubicaciones Origenes.-
            idDepOrigen = idDepPedEst
            IdUbiOrigen = IdUbiPedEst
            '-----------------------------------------
            idDepDestino = estadoAnterior.IdDeposito
            idUbiDestino = estadoAnterior.IdUbicacion
            '-----------------------------------------
         End If
         'El movimiento de reserva tomará este coeficiente y lo multiplicará por -1 para así saber si tiene que sumar o restar en StockReservado.

         'Busco el Tipo de Movimiento que tiene el tilde en Reserva Mercaderia
         Dim tipoMovimiento As Entidades.TipoMovimiento = _cache.BuscaTipoMovimientoReservaMercaderia()
         If tipoMovimiento Is Nothing Then
            Throw New Exception("No está definido ningún Tipo de Movimiento con el tilde en Reserva de Mercadería. Verifique y reintente.")
         End If


         'Instancio el Movimiento de Compra poniendo en la Observacion el motivo de la reserva.
         Dim movi = New Entidades.MovimientoStock()
         movi.IdSucursal = idSucursal
         movi.Sucursal = _cache.BuscaSucursal(idSucursal) '# Se carga la sucursal correspondiente al Pedido
         movi.TipoMovimiento = tipoMovimiento
         movi.FechaMovimiento = Now
         movi.Usuario = actual.Nombre
         movi.Observacion = String.Format("Reserva de mercadería por: {0} {1} {2:0000}-{3:00000000} Ln: {4}",
                                          idTipoComprobante, letra, centroEmisor, numeroPedido, orden)

         'Instancio un Movimiento de Compra Producto poniendo el producto a reservar y la cantidad del stock a descontar.
         Dim moviProd = New Entidades.MovimientoStockProducto()
         moviProd.IdSucursal = idSucursal '# Se carga la sucursal correspondiente al Pedido
         moviProd.IdProducto = idProducto
         moviProd.IdDeposito = idDepOrigen
         moviProd.IdUbicacion = IdUbiOrigen

         'Multiplico por el coeficiente antes definido. (asumo que el tipo está definido positivo)
         moviProd.Cantidad = cantidad * coeficienteStock
         moviProd.Orden = 1
         movi.Productos.Add(moviProd)

         'Instancio un Movimiento de Compra Producto poniendo el producto a reservar y la cantidad del stock reservado a incrementar.
         moviProd = New Entidades.MovimientoStockProducto()
         moviProd.IdSucursal = idSucursal '# Se carga la sucursal correspondiente al Pedido
         moviProd.IdProducto = idProducto
         moviProd.IdDeposito = idDepDestino
         moviProd.IdUbicacion = idUbiDestino

         'Multiplico por el coeficiente antes definido. (asumo que el tipo está definido positivo)
         moviProd.Cantidad = cantidad * coeficienteStock * -1
         moviProd.Orden = 2
         movi.Productos.Add(moviProd)

         'Grabo el movimiento esperando que el mismo, al estar marcado como Reserva de Mercadería, impacte en StockReservado.
         Dim rMovimientoCompra = New MovimientosStock(da)
         rMovimientoCompra.CargarMovimientoStock(movi, MetodoGrabacion, IdFuncion)

      End If         'If estadoAnterior.ReservaMateriaPrima <> estadoNuevo.ReservaMateriaPrima Then
   End Sub

   'Public Function GetCantidadPedidosEstado(idSucursal As Integer,
   '                                         idTipoComprobante As String,
   '                                         letra As String,
   '                                         centroEmisor As Short,
   '                                         numeroPedido As Long,
   '                                         idEstado As String,
   '                                         idProducto As String, orden As Integer) As Decimal
   '   Dim sql As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(Me.da)

   '   Return sql.GetCantidadPedidosEstado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idEstado, idProducto, orden)
   'End Function

   Public Function GetPedidosEstadosUno(IdSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long,
                                     idProducto As String,
                                     fechaEstado As Date,
                                     orden As Integer) As DataTable

      Dim sql As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)

      Return sql.GetPedidosEstadosUno(IdSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProducto, fechaEstado, orden)
   End Function

   Public Function GetPedidoParaVincular(idEstado As String) As DataTable
      Dim sql As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)
      Return sql.GetPedidoParaVincular(idEstado)
   End Function

   Public Function GetPedidosVinculados() As DataTable
      Dim sql As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)

      Return sql.GetPedidosVinculados(Publicos.EstadoPedidoPostVinculacion, Publicos.EstadoPedidoProvPostVinculacion)
   End Function

   Public Function GetIdComprobanteRelacionadoFromDataRow(Pedido As DataRow, grupo As IdComprobanteRelacionado.Grupo) As IdComprobanteRelacionado
      Dim result As IdComprobanteRelacionado = New IdComprobanteRelacionado()

      If Pedido.Table.Columns.Contains("IdSucursal" + grupo.ToString()) Then
         If IsNumeric(Pedido("IdSucursal" + grupo.ToString()).ToString()) Then
            result.IdSucursal = Integer.Parse(Pedido("IdSucursal" + grupo.ToString()).ToString())
         End If
      Else
         result.IdSucursal = Integer.Parse(Pedido("IdSucursal").ToString())
      End If

      result.IdTipoComprobante = Pedido("IdTipoComprobante" + grupo.ToString()).ToString()
      result.Letra = Pedido("Letra" + grupo.ToString()).ToString()
      If IsNumeric(Pedido("CentroEmisor" + grupo.ToString()).ToString()) Then
         result.CentroEmisor = Short.Parse(Pedido("CentroEmisor" + grupo.ToString()).ToString())
      End If

      Dim prefijoNumero As String = "NumeroComprobante"

      If grupo = IdComprobanteRelacionado.Grupo.Generado Or
         grupo = IdComprobanteRelacionado.Grupo.Vinculado Then prefijoNumero = "NumeroPedido"
      If grupo = IdComprobanteRelacionado.Grupo.Produccion Then prefijoNumero = "NumeroOrden"

      If IsNumeric(Pedido(prefijoNumero + grupo.ToString()).ToString()) Then
         result.Numero = Long.Parse(Pedido(prefijoNumero + grupo.ToString()).ToString())
      End If

      If Pedido.Table.Columns.Contains("IdProducto" + grupo.ToString()) Then
         result.IdProducto = Pedido("IdProducto" + grupo.ToString()).ToString()
      End If

      If Pedido.Table.Columns.Contains("Orden" + grupo.ToString()) AndAlso IsNumeric(Pedido("Orden" + grupo.ToString())) Then
         result.Orden = Integer.Parse(Pedido("Orden" + grupo.ToString()).ToString())
      End If

      If Pedido.Table.Columns.Contains("FechaEstado" + grupo.ToString()) AndAlso IsDate(Pedido("FechaEstado" + grupo.ToString())) Then
         result.FechaEstado = DateTime.Parse(Pedido("FechaEstado" + grupo.ToString()).ToString())
      End If

      Return result
   End Function

   Public Sub CambiarInvocadorFact(origen As Entidades.IPKComprobante, destino As Entidades.IPKComprobante)
      Dim sql = New SqlServer.PedidosEstados(da)
      sql.PedidosEstados_U_CambiarInvocador("Fact",
                                            origen.IdSucursal, origen.IdTipoComprobante, origen.Letra, origen.CentroEmisor, origen.NumeroComprobante,
                                            destino.IdSucursal, destino.IdTipoComprobante, destino.Letra, destino.CentroEmisor, destino.NumeroComprobante)
   End Sub
   Public Sub CambiarInvocadorRemito(origen As Entidades.IPKComprobante, destino As Entidades.IPKComprobante)
      Dim sql = New SqlServer.PedidosEstados(da)
      sql.PedidosEstados_U_CambiarInvocador("Remito",
                                            origen.IdSucursal, origen.IdTipoComprobante, origen.Letra, origen.CentroEmisor, origen.NumeroComprobante,
                                            destino.IdSucursal, destino.IdTipoComprobante, destino.Letra, destino.CentroEmisor, destino.NumeroComprobante)
   End Sub

   Public Function ValidaPedidosEstadosDepositos(idSucursal As Integer, IdDeposito As Integer) As Boolean
      Dim dt = New SqlServer.PedidosEstados(da).GetPedidosEstadosCantidadSucursalesDepositos(idSucursal, IdDeposito)
      Return dt.Rows(0).Field(Of Integer)("Cantidad") > 0
   End Function


   Public Class IdComprobanteRelacionado
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Short
      Public Property Numero As Long
      Public Property IdProducto As String
      Public Property Orden As Integer
      Public Property FechaEstado As Date?

      Public Enum Grupo
         Fact
         Remito
         Generado
         Produccion
         Vinculado
      End Enum

   End Class

End Class
