Public Class OrdenesProduccionEstados
   Inherits Base

   Private _cache As BusquedasCacheadas

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(cache As BusquedasCacheadas)
      Me.New(New Datos.DataAccess(), cache)
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.New(accesoDatos, New BusquedasCacheadas())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess, cache As BusquedasCacheadas)
      MyBase.New("OrdenesProduccionEstados", accesoDatos)
      _cache = cache
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.OrdenProduccionEstado)))
   End Sub
#End Region

   Public Sub Inserta(prod As Entidades.OrdenProduccionEstado)
      EjecutaSP(prod, TipoSP._I)
   End Sub

   Public Sub Inserta(prod As Entidades.OrdenProduccionProducto)
      Dim estado = New Entidades.OrdenProduccionEstado()

      estado.IdSucursal = prod.IdSucursal
      estado.IdTipoComprobante = prod.IdTipoComprobante
      estado.Letra = prod.Letra
      estado.CentroEmisor = prod.CentroEmisor
      estado.NumeroOrdenProduccion = prod.NumeroOrdenProduccion
      estado.IdProducto = prod.IdProducto
      estado.Orden = prod.Orden
      estado.FechaEstado = Date.Now
      estado.IdEstado = Entidades.EstadoOrdenProduccion.ESTADO_ALTA ' "PENDIENTE"
      estado.IdUsuario = actual.Nombre
      estado.Observacion = "Alta OrdenProduccion"
      estado.CantEstado = prod.Cantidad
      estado.IdTipoComprobanteFact = ""
      estado.LetraFact = ""
      estado.CentroEmisorFact = 0
      estado.NumeroComprobanteFact = 0
      estado.IdCriticidad = prod.IdCriticidad
      estado.FechaEntrega = prod.FechaEntrega
      estado.IdFormula = prod.IdFormula


      estado.IdResponsable = prod.IdResponsable

      Inserta(estado)

      ReservaMateriaPrima(estado.IdSucursal, estado.IdTipoComprobante, estado.Letra, estado.CentroEmisor, estado.NumeroOrdenProduccion, estado.IdProducto, estado.Orden,
                          String.Empty, estado.IdEstado, estado.CantEstado, prod.Espmm, prod.LargoExtAlto, prod.AnchoIntBase,
                          Entidades.Entidad.MetodoGrabacion.Automatico, "OrdenesDeProduccion")

   End Sub

   Public Sub EjecutaSP(prod As Entidades.OrdenProduccionEstado, tipo As TipoSP)
      Dim sql = New SqlServer.OrdenesProduccionEstados(da)
      Select Case tipo
         Case TipoSP._I
            sql.OrdenesProduccionEstados_I(prod.IdSucursal,
                                           prod.IdTipoComprobante,
                                           prod.Letra,
                                           prod.CentroEmisor,
                                           prod.NumeroOrdenProduccion,
                                           prod.IdProducto,
                                           prod.FechaEstado,
                                           prod.IdEstado,
                                           prod.IdUsuario,
                                           prod.Observacion,
                                           prod.CantEstado,
                                           prod.IdTipoComprobanteFact,
                                           prod.LetraFact,
                                           prod.CentroEmisorFact,
                                           prod.NumeroComprobanteFact,
                                           prod.Orden,
                                           prod.IdCriticidad,
                                           prod.FechaEntrega,
                                           0,
                                           prod.IdFormula,
                                           prod.IdResponsable,
                                           prod.PlanMaestroNumero,
                                           prod.PlanMaestroFecha)

         Case TipoSP._U

         Case TipoSP._D
            sql.OrdenesProduccionEstados_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroOrdenProduccion, prod.Orden, prod.IdProducto, Nothing)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.OrdenProduccionEstado, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.OrdenProduccionEstado.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.OrdenProduccionEstado.Columnas.CentroEmisor.ToString())
         .NumeroOrdenProduccion = dr.Field(Of Integer)(Entidades.OrdenProduccionEstado.Columnas.NumeroOrdenProduccion.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.OrdenProduccionEstado.Columnas.Orden.ToString())
         .FechaEstado = dr.Field(Of Date)(Entidades.OrdenProduccionEstado.Columnas.FechaEstado.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.IdProducto.ToString())


         .IdEstado = dr.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.IdEstado.ToString())
         .IdUsuario = dr.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.IdUsuario.ToString())
         .CantEstado = dr.Field(Of Decimal)(Entidades.OrdenProduccionEstado.Columnas.CantEstado.ToString())
         .Observacion = dr.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.Observacion.ToString())
         .IdTipoComprobanteFact = dr.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.IdTipoComprobanteFact.ToString()).IfNull()
         .LetraFact = dr.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.LetraFact.ToString()).IfNull()
         .CentroEmisorFact = dr.Field(Of Integer?)(Entidades.OrdenProduccionEstado.Columnas.CentroEmisorFact.ToString()).IfNull()
         .NumeroComprobanteFact = dr.Field(Of Long?)(Entidades.OrdenProduccionEstado.Columnas.NumeroComprobanteFact.ToString()).IfNull()

         .NumeroReparto = dr.Field(Of Integer?)(Entidades.OrdenProduccionEstado.Columnas.NumeroReparto.ToString()).IfNull()

         .IdCriticidad = dr.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.IdCriticidad.ToString())
         .FechaEntrega = dr.Field(Of Date)(Entidades.OrdenProduccionEstado.Columnas.FechaEntrega.ToString())

         .IdFormula = dr.Field(Of Integer?)(Entidades.OrdenProduccionProducto.Columnas.IdFormula.ToString()).IfNull()
         .IdResponsable = dr.Field(Of Integer?)(Entidades.OrdenProduccionProducto.Columnas.IdResponsable.ToString()).IfNull()

         .PlanMaestroNumero = dr.Field(Of Integer?)(Entidades.OrdenProduccionEstado.Columnas.PlanMaestroNumero.ToString())
         .PlanMaestroFecha = dr.Field(Of Date?)(Entidades.OrdenProduccionEstado.Columnas.PlanMaestroFecha.ToString())
      End With
   End Sub

   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                          orden As Integer, idProducto As String) As Entidades.OrdenProduccionEstado
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, orden, idProducto)
   End Function
   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                          orden As Integer, idProducto As String, fechaEstado As Date?) As Entidades.OrdenProduccionEstado
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                    orden, idProducto, fechaEstado, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function Get1(idSucursal As Integer,
                        idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                        orden As Integer, idProducto As String, fechaEstado As Date?) As DataTable
      Return New SqlServer.OrdenesProduccionEstados(da).
                  OrdenesProduccionEstados_G1(idSucursal,
                                              idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                              orden, idProducto, fechaEstado)
   End Function
   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                          orden As Integer, idProducto As String, fechaEstado As Date?, accion As AccionesSiNoExisteRegistro) As Entidades.OrdenProduccionEstado
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, orden, idProducto, fechaEstado),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.OrdenProduccionEstado(),
                          accion, String.Format("No existe estado de O.P. para {0} {1} {2} {3:0000}-{4:00000000} / {5} / {6} / {7}",
                                                idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, orden, idProducto, fechaEstado))
   End Function

   Public Function GetTodos(IdSucursal As Integer,
                            IdTipoComprobante As String, Letra As String,
                            CentroEmisor As Integer, NumeroOrdenProduccion As Long) As List(Of Entidades.OrdenProduccionEstado)
      Dim dt As DataTable = New SqlServer.OrdenesProduccionEstados(da).OrdenesProduccionEstados_GA(IdSucursal,
                                                                                  IdTipoComprobante, Letra,
                                                                                  CentroEmisor, NumeroOrdenProduccion)
      Dim o As Entidades.OrdenProduccionEstado
      Dim oLis As List(Of Entidades.OrdenProduccionEstado) = New List(Of Entidades.OrdenProduccionEstado)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.OrdenProduccionEstado()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   <Obsolete("Usar nuevo método")>
   Public Sub ActualizarEstadoOrdenProduccionMasivo(idSucursal As Integer,
                                                    idEstado As String,
                                                    idUsuario As String,
                                                    observ As String,
                                                    idCriticidad As String,
                                                    fechaEntrega As Date?,
                                                    cantidadCambioIndividual As Decimal?,
                                                    tablagrabar As DataTable,
                                                    metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                                    idFuncion As String)
      EjecutaConTransaccion(
         Sub()
            _ActualizarEstadoOrdenProduccionMasivo(idSucursal,
                                                    idEstado,
                                                    idUsuario,
                                                    observ,
                                                    idCriticidad,
                                                    fechaEntrega,
                                                    cantidadCambioIndividual,
                                                    tablagrabar,
                                                    metodoGrabacion,
                                                    idFuncion, 0)
         End Sub)
   End Sub
   <Obsolete("Usar nuevo método")>
   Public Sub _ActualizarEstadoOrdenProduccionMasivo(idSucursal As Integer,
                                                    idEstado As String,
                                                    idUsuario As String,
                                                    observ As String,
                                                    idCriticidad As String,
                                                    fechaEntrega As Date?,
                                                    cantidadCambioIndividual As Decimal?,
                                                    tablagrabar As DataTable,
                                                    metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                                    idFuncion As String, nPlanMaestro As Integer)

      'Viene el Estado pero tambien utilizo el Tipo de Estado
      Dim estadoOPNuevo = New Reglas.EstadosOrdenesProduccion().GetUno(idEstado)
      If estadoOPNuevo.ReservaMateriaPrima AndAlso estadoOPNuevo.IdDeposito = 0 Then
         Throw New Exception(String.Format("El estado {0} está configurado para reservar Materia Prima, pero no está configurado el deposito destino.", estadoOPNuevo.IdEstado))
      End If
      Dim IdTipoEstado As String
      IdTipoEstado = estadoOPNuevo.IdTipoEstado
      '------------------------------------------------------------------------

      Dim IdTipoComprobante As String
      Dim Letra As String
      Dim CentroEmisor As Integer
      Dim NumeroOrdenProduccion As Long

      Dim IdDeposito As Integer
      Dim IdUbicacion As Integer

      Dim idProd As String
      Dim FechaEstado As Date
      Dim orden As Integer
      'Dim idEstadoAnterior As String
      Dim IdTipoEstadoAnterior As String
      Dim CantEstado As Decimal
      'Dim IdCriticidad As String
      'Dim fechaEntrega As Date
      Dim idFormula As Integer
      Dim espmm As Decimal
      Dim largoExtAlto As Decimal
      Dim anchoIntBase As Decimal

      Dim IdResponsable As Integer

      Dim FechaNuevoEstado As Date = Date.Now
      Dim fechaEntregaNull As Boolean = Not fechaEntrega.HasValue

      For Each filaGrabar As DataRow In tablagrabar.Rows

         Dim sqlEstado As SqlServer.EstadosOrdenesProduccion = New SqlServer.EstadosOrdenesProduccion(da)

         IdTipoComprobante = filaGrabar(Entidades.OrdenProduccion.Columnas.IdTipoComprobante.ToString()).ToString()
         Letra = filaGrabar(Entidades.OrdenProduccion.Columnas.Letra.ToString()).ToString()
         CentroEmisor = Integer.Parse(filaGrabar(Entidades.OrdenProduccion.Columnas.CentroEmisor.ToString()).ToString())
         NumeroOrdenProduccion = Long.Parse(filaGrabar(Entidades.OrdenProduccion.Columnas.NumeroOrdenProduccion.ToString()).ToString())

         idProd = filaGrabar("idProducto").ToString
         FechaEstado = Date.Parse(filaGrabar("fechaEstado").ToString)
         'IdCriticidad = filaGrabar("IdCriticidad").ToString
         'fechaEntrega = Date.Parse(filaGrabar("FechaEntrega").ToString)
         If fechaEntregaNull Then
            fechaEntrega = Date.Parse(filaGrabar("FechaEntrega").ToString)
         End If

         If Not String.IsNullOrWhiteSpace(filaGrabar("IdFormula").ToString()) Then
            idFormula = Integer.Parse(filaGrabar("IdFormula").ToString())
         End If

         espmm = Decimal.Parse(filaGrabar("Espmm").ToString())
         largoExtAlto = Decimal.Parse(filaGrabar("LargoExtAlto").ToString())
         anchoIntBase = Decimal.Parse(filaGrabar("AnchoIntBase").ToString())

         IdDeposito = Integer.Parse(filaGrabar("IdDepositoDefecto").ToString())
         IdUbicacion = Integer.Parse(filaGrabar("IdUbicacionDefecto").ToString())

         IdResponsable = Integer.Parse(filaGrabar("IdResponsable").ToString())

         orden = Integer.Parse(filaGrabar("Orden").ToString)

         'idEstadoAnterior = filaGrabar("IdEstado").ToString
         Dim estadoOPAnterior = New Reglas.EstadosOrdenesProduccion().GetUno(filaGrabar("IdEstado").ToString)
         IdTipoEstadoAnterior = estadoOPAnterior.IdTipoEstado

         If cantidadCambioIndividual.HasValue Then
            CantEstado = cantidadCambioIndividual.Value
         Else
            CantEstado = Decimal.Parse(filaGrabar("CantEntregada").ToString)
         End If

         Dim rPP As Reglas.OrdenesProduccionProductos = New OrdenesProduccionProductos(da)
         Dim sqlEP As SqlServer.EstadosOrdenesProduccion = New SqlServer.EstadosOrdenesProduccion(da)
         Dim sqlPP As SqlServer.OrdenesProduccionProductos = New SqlServer.OrdenesProduccionProductos(da)
         Dim sqlPE As SqlServer.OrdenesProduccionEstados = New SqlServer.OrdenesProduccionEstados(da)
         Dim dtOrdenProduccion As DataTable = New OrdenesProduccionEstados(da).GetOrdenesProduccionEstadosUno(idSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion, idProd, FechaEstado, orden)

         If Decimal.Parse(dtOrdenProduccion.Rows(0)("CantEstado").ToString()) = CantEstado Then
            sqlPE.OrdenesProduccionEstados_U_Estado(idSucursal,
                                                       IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion,
                                                       idProd,
                                                       FechaEstado,
                                                       idEstado,
                                                       CantEstado,
                                                       FechaNuevoEstado,
                                                       observ,
                                                       orden,
                                                       idCriticidad,
                                                       fechaEntrega.Value,
                                                       0,
                                                       IdResponsable, nPlanMaestro, Now)
         Else
            sqlPE.OrdenesProduccionEstados_I(idSucursal,
                                             IdTipoComprobante,
                                             Letra,
                                             CentroEmisor,
                                             NumeroOrdenProduccion,
                                             idProd,
                                             FechaNuevoEstado,
                                             idEstado,
                                             idUsuario,
                                             observ,
                                             CantEstado,
                                             "",
                                             "",
                                             0,
                                             0,
                                             orden,
                                             idCriticidad,
                                             fechaEntrega,
                                             0,
                                             idFormula,
                                             IdResponsable, nPlanMaestro, planMaestroFecha:=Now)
            sqlPE.OrdenesProduccionEstados_U_Cantidad(idSucursal,
                                                         IdTipoComprobante,
                                                         Letra,
                                                         CentroEmisor,
                                                         NumeroOrdenProduccion,
                                                         idProd,
                                                         orden,
                                                         FechaEstado,
                                                         CantEstado * -1)
         End If

         rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(idSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion, idProd, orden,
                                                            IdTipoEstadoAnterior, IdTipoEstado, CantEstado)

         'If Not estadoOPNuevo.GeneraProductoTerminado Then
         ReservaMateriaPrima(idSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion, idProd, orden,
                             estadoOPAnterior.IdEstado, estadoOPNuevo.IdEstado, CantEstado, espmm, largoExtAlto,
                             anchoIntBase, metodoGrabacion, idFuncion)
         'End If

         GeneraProductoTerminado(idSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion, idProd, orden,
                                estadoOPAnterior, estadoOPNuevo, CantEstado, idFormula, espmm, largoExtAlto, anchoIntBase,
                                IdResponsable, metodoGrabacion, idFuncion, IdDeposito, IdUbicacion)

         ActualizaPedidoOrigen(idSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion, idProd, orden,
                                  IdTipoEstadoAnterior, IdTipoEstado, CantEstado, IdResponsable, idFuncion)

         Dim IdTipoComprobanteFact As String = sqlEP.GetComprobanteXEstado(idEstado)

         If Not String.IsNullOrEmpty(IdTipoComprobanteFact) Then

            Dim oProducto As Entidades.Producto = New Entidades.Producto
            oProducto = New Reglas.Productos().GetUno(idProd)

            Dim _ventasObservaciones As List(Of Entidades.VentaObservacion) = New List(Of Entidades.VentaObservacion)()

            If Not String.IsNullOrEmpty(observ) Then
               Dim oLineaObservacion As Entidades.VentaObservacion

               oLineaObservacion = New Entidades.VentaObservacion()
               With oLineaObservacion
                  .IdSucursal = idSucursal
                  .Usuario = idUsuario
                  .Linea = 1
                  .Observacion = observ
               End With
               _ventasObservaciones.Add(oLineaObservacion)
            End If

            '----------------------------------------------------------------------------------------------------

            Dim regClientes As Reglas.Clientes = New Reglas.Clientes(da)
            Dim oCliente As Entidades.Cliente

            oCliente = regClientes._GetUno(Long.Parse(dtOrdenProduccion.Rows(0)("IdCliente").ToString()), False)

            'Corregir para que no habra conexion.
            Dim oReglaVentas As Reglas.Ventas = New Reglas.Ventas(da)

            Dim oComprobante As Entidades.Venta
            Dim IdCLiente As Long = oCliente.IdCliente
            Dim fecha As Date = FechaNuevoEstado
            Dim Ven = oCliente.Vendedor

            Dim Observacion As String
            Dim idProducto As String = oProducto.IdProducto ' idprod
            Dim Importe As Decimal = CantEstado * Decimal.Parse(dtOrdenProduccion.Rows(0)("Precio").ToString())

            Dim idFormaDePagoCtaCte As Integer = New Reglas.VentasFormasPago().GetUna("VENTAS", False).IdFormasPago

            Observacion = String.Format("Generado por Cambio de Estado de: {0} {1} {2:0000}-{3:00000000}. Fecha: {4:dd/MM/yyyy}",
                                           IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion, FechaEstado).Truncar(100)

            oComprobante = oReglaVentas.GrabarComprobante(idSucursal,
                                                             IdTipoComprobanteFact,
                                                             IdCLiente,
                                                             0,
                                                             fecha,
                                                             Ven,
                                                             idFormaDePagoCtaCte,
                                                             Observacion,
                                                             Importe,
                                                             idProducto,
                                                             CantEstado,
                                                             _ventasObservaciones,
                                                             Nothing,
                                                             contactos:=Nothing,
                                                             nombreProducto:=String.Empty,
                                                             cobrador:=Nothing,
                                                             comprobantesAsociados:={},
                                                             idEmbarcacion:=0,
                                                             metodoGrabacion:=metodoGrabacion,
                                                             idFuncion:=idFuncion)

            sqlPE.OrdenesProduccionEstados_U_Fact(idSucursal,
                                          IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion _
                                          , idProd _
                                          , FechaNuevoEstado _
                                          , oComprobante.IdTipoComprobante _
                                          , oComprobante.LetraComprobante _
                                          , oComprobante.CentroEmisor _
                                          , oComprobante.NumeroComprobante _
                                          , orden)

         End If
         FechaNuevoEstado = FechaNuevoEstado.AddSeconds(1)
      Next
   End Sub

   Public Sub GeneraProductoTerminado(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Integer,
                                      numeroOrdenProduccion As Long,
                                      idProducto As String,
                                      orden As Integer,
                                      estadoAnterior As Entidades.EstadoOrdenProduccion,
                                      estadoNuevo As Entidades.EstadoOrdenProduccion,
                                      cantidad As Decimal,
                                      idFormula As Integer,
                                      espmm As Decimal,
                                      largoExtAlto As Decimal,
                                      anchoIntBase As Decimal,
                                      IdResponsable As Integer,
                                      MetodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                      IdFuncion As String, IdDeposito As Integer, IdUbicacion As Integer)

      'Dim estadoNuevo As Entidades.EstadoOrdenProduccion = _cache.BuscaEstadosOrdenesProduccion(idEstadoNuevo)

      'Solo debo generar el Producto Terminado si el estado nuevo GeneraProductoTerminado.
      If estadoNuevo.GeneraProductoTerminado Then

         'Instancio el Movimiento de Compra poniendo en la Observacion el motivo de la reserva.
         Dim prod = New Entidades.Produccion With {
                .IdSucursal = actual.Sucursal.Id,
                .Fecha = Now,
                .Usuario = actual.Nombre,
                .Responsable = New Empleados(da).GetUno(IdResponsable)
            }

         Dim prodProd = New Entidades.ProduccionProducto With {
                .IdProducto = idProducto,
                .IdSucursal = actual.Sucursal.Id,
                .IdFormula = idFormula,
                .Cantidad = cantidad,
                .Orden = 1,
                .Espmm = espmm,
                .LargoExtAlto = largoExtAlto,
                .AnchoIntBase = anchoIntBase,
                .IdDeposito = IdDeposito,
                .IdUbicacion = IdUbicacion
            }

         Dim oppFormula = New OrdenesProduccionProductosFormulas(da).GetTodos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                                              idProducto, orden, soloMateriaPrima:=True)

         prodProd.Componentes = New Entidades.FormulaConverter().ConvertirFormulaOPEnProduccion(oppFormula)

         prod.Productos.Add(prodProd)

         Dim rProduccion = New Produccion(da)
         rProduccion.GrabarProduccion(prod, Now, estadoAnterior)

      End If         'If estadoNuevo.GeneraProductoTerminado Then
   End Sub

   Public Sub ActualizaPedidoOrigen(idSucursal As Integer,
                                    idTipoComprobante As String,
                                    letra As String,
                                    centroEmisor As Integer,
                                    numeroOrdenProduccion As Long,
                                    idProducto As String,
                                    orden As Integer,
                                    idEstadoAnterior As String,
                                    idEstadoNuevo As String,
                                    cantidad As Decimal,
                                    IdResponsable As Integer,
                                    idFuncion As String)
      Dim estadoOP As Entidades.EstadoOrdenProduccion = _cache.BuscaEstadosOrdenesProduccion(idEstadoNuevo)
      If Not String.IsNullOrWhiteSpace(estadoOP.IdEstadoPedido) Then
         Dim estadoPE As Entidades.EstadoPedido = _cache.BuscaEstadosPedido(estadoOP.IdEstadoPedido, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString())
         Dim rPE As Reglas.PedidosEstados = New PedidosEstados(da)
         Dim sPE As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)

         Dim dtPE As DataTable
         dtPE = sPE.PedidosEstados_G_PorComprobanteProduccion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                              idProducto, orden)
         Dim tablagrabar As DataTable = dtPE.Clone()
         For Each drPE As DataRow In dtPE.Rows
            tablagrabar.Clear()
            tablagrabar.ImportRow(drPE)
            rPE._ActualizarEstadoPedidoMasivo(estadoOP.IdEstadoPedido, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString(), actual.Nombre,
                                              String.Format("Produccion en estado ´{0}´.", idEstadoNuevo),
                                              drPE("IdCriticidad").ToString(), DateTime.Parse(drPE("FechaEntrega").ToString()), cantidad,
                                              IdResponsable, Nothing, tablagrabar, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
         Next
      End If            'If Not String.IsNullOrWhiteSpace(estadoOP.IdEstadoPedido) Then

   End Sub

   Public Sub ReservaMateriaPrima(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                  idProducto As String, orden As Integer,
                                  idEstadoAnterior As String, idEstadoNuevo As String,
                                  cantidad As Decimal, espmm As Decimal, largoExtAlto As Decimal, anchoIntBase As Decimal,
                                  metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)

      Dim estadoAnterior = _cache.BuscaEstadosOrdenesProduccion(idEstadoAnterior, AccionesSiNoExisteRegistro.Vacio)
      Dim estadoNuevo = _cache.BuscaEstadosOrdenesProduccion(idEstadoNuevo)

      'Solo debo realizar movimientos de Stock->Reservado y de Reservado->Stock si difieren en la propiedad ReservaMateriaPrima.
      'Si es igual esta propiedad significa que no cambian de un lado a otro las cantidades.
      If estadoAnterior.ReservaMateriaPrima <> estadoNuevo.ReservaMateriaPrima Then
         Dim esReserva = Not estadoAnterior.ReservaMateriaPrima And estadoNuevo.ReservaMateriaPrima

         'Si el estado actual NO reserva MP (PENDIENTE) y el nuevo SI lo hace (EN PROCESO) el coeficiente es NEGATIVO, porque se descuenta MP de Stock.
         'Si el estado actual SI reserva MP (EN PROCESO) y el nuevo NO lo hace (FINALIZADO) el coeficiente es POSITIVO, porque se incrementa MP de Stock.
         Dim coeficienteStock = If(esReserva, -1I, 1I)
         Dim idDepDestino = If(esReserva, estadoNuevo.IdDeposito, estadoAnterior.IdDeposito)
         Dim idUbiDestino = If(esReserva, estadoNuevo.IdUbicacion, estadoAnterior.IdUbicacion)
         'El movimiento de reserva tomará este coeficiente y lo multiplicará por -1 para así saber si tiene que sumar o restar en StockReservado.

         'Busco el Tipo de Movimiento que tiene el tilde en Reserva Mercaderia
         Dim tipoMovimiento = _cache.BuscaTipoMovimientoReservaMercaderia()
         If tipoMovimiento Is Nothing Then
            Throw New Exception("No está definido ningún Tipo de Movimiento con el tilde en Reserva de Mercadería. Verifique y reintente.")
         End If

         'Instancio el Movimiento de Compra poniendo en la Observacion el motivo de la reserva.
         Dim movi = New Entidades.MovimientoStock() With {
               .IdSucursal = actual.Sucursal.Id,
               .Sucursal = actual.Sucursal,
               .TipoMovimiento = tipoMovimiento,
               .FechaMovimiento = Now,
               .Usuario = actual.Nombre,
               .Observacion = String.Format("Reserva de mercadería por: {0} {1} {2:0000}-{3:00000000} Ln: {4}",
                                                idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, orden)
            }

         Dim ordenMovimiento As Integer = 1
         Using dtComposicion = New OrdenesProduccionProductosFormulas(da).GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, idProducto, orden, soloMateriaPrima:=True)
            For Each drComposicion In dtComposicion.AsEnumerable()

               '-- Recupera Datos del Producto.-
               Dim idDepOrigen = Integer.Parse(drComposicion("IdDepositoDefecto").ToString())
               Dim idUbiOrigen = Integer.Parse(drComposicion("IdUbicacionDefecto").ToString())

               For Each iSigno In {1, -1}
                  'Instancio un Movimiento de Compra Producto poniendo el producto a reservar y la cantidad del stock a descontar.
                  'Multiplico por el coeficiente antes definido. (asumo que el tipo está definido positivo)
                  Dim moviProd = New Entidades.MovimientoStockProducto With {
                       .IdSucursal = actual.Sucursal.Id,
                       .IdProducto = drComposicion.Field(Of String)("IdProductoComponente"),
                       .IdDeposito = If(iSigno > 0, idDepOrigen, idDepDestino),
                       .IdUbicacion = If(iSigno > 0, idUbiOrigen, idUbiDestino),
                       .Cantidad = drComposicion.Field(Of Decimal)("Cantidad") * coeficienteStock * cantidad * iSigno,
                       .Orden = ordenMovimiento
                   }

                  movi.Productos.Add(moviProd)
                  ordenMovimiento += 1
               Next
            Next
         End Using

         'Grabo el movimiento esperando que el mismo, al estar marcado como Reserva de Mercadería, impacte en StockReservado.
         Dim rMovimientoCompra = New MovimientosStock(da)
         rMovimientoCompra.CargarMovimientoStock(movi, metodoGrabacion, idFuncion)

      End If         'If estadoAnterior.ReservaMateriaPrima <> estadoNuevo.ReservaMateriaPrima Then
   End Sub

   Public Function GetOrdenesProduccionEstadosUno(IdSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroOrdenProduccion As Long,
                                     idProducto As String,
                                     fechaEstado As Date,
                                     orden As Integer) As DataTable

      Dim sql As SqlServer.OrdenesProduccionEstados = New SqlServer.OrdenesProduccionEstados(da)

      Return sql.GetOrdenesProduccionEstadosUno(IdSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, idProducto, fechaEstado, orden)

   End Function

   Public Function GetOrdenesProduccionMRP(idEstado As String, idCliente As Long, fechaDesde As Date?, fechaHasta As Date?, fechaDesdeEntrega As Date?, fechaHastaEntrega As Date?) As DataTable
      Dim sql = New SqlServer.OrdenesProduccionEstados(da)
      Return sql.GetOrdenesProduccionMRP(idEstado, idCliente, fechaDesde, fechaHasta, fechaDesdeEntrega, fechaHastaEntrega)
   End Function
   Public Function GetOrdenesProduccionREQ(idCliente As Long,
                                           fechaDesde As Date,
                                           fechaHasta As Date,
                                           fechaDesdeEntrega As Date,
                                           fechaHastaEntrega As Date,
                                           idPlanMaestro As Integer,
                                           fechaDesdePM As Date,
                                           fechaHastaPM As Date) As DataTable
      Dim sql = New SqlServer.OrdenesProduccionEstados(da)
      Return sql.GetOrdenesProduccionREQ(idCliente, fechaDesde, fechaHasta, fechaDesdeEntrega, fechaHastaEntrega, idPlanMaestro, fechaDesdePM, fechaHastaPM)
   End Function
   Public Function GetPlanMaestroMaximo() As Integer
      Return New SqlServer.OrdenesProduccionEstados(da).GetPlanMaestroMaximo()
   End Function
End Class