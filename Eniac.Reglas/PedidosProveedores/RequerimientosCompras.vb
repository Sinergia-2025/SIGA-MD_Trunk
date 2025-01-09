Public Class RequerimientosCompras
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.RequerimientoCompra.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.RequerimientoCompra)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.RequerimientoCompra)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.RequerimientoCompra)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.RequerimientosCompras(da).Buscar(entidad.Columna, entidad.Valor.ToString(), filtroABM:=Nothing)
   End Function
   Public Overloads Function Buscar(entidad As Entidades.Buscar, filtroABM As Entidades.Filtros.RequerimientosComprasABMFiltros) As DataTable
      Return New SqlServer.RequerimientosCompras(da).Buscar(entidad.Columna, entidad.Valor.ToString(), filtroABM)
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.RequerimientosCompras(da).RequerimientosCompras_GA()
   End Function
   Public Overloads Function GetAll(filtroABM As Entidades.Filtros.RequerimientosComprasABMFiltros) As DataTable
      Return New SqlServer.RequerimientosCompras(da).RequerimientosCompras_GA(filtroABM)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.RequerimientoCompra, tipo As TipoSP)
      Dim sql = New SqlServer.RequerimientosCompras(da)
      Dim rRqProductos = New RequerimientosComprasProductos(da)
      Select Case tipo
         Case TipoSP._I
            en.IdRequerimientoCompra = GetCodigoMaximo() + 1

            If String.IsNullOrWhiteSpace(en.Letra) Then
               Dim tipoComprobante = New TiposComprobantes(da).GetUno(en.IdTipoComprobante)
               'Siempre tomo la primer letra ya que no hay Categoria Fiscal para determinar la letra si hay màs de una.
               en.Letra = tipoComprobante.LetrasHabilitadas.Substring(0, 1)
            End If
            If en.CentroEmisor = 0 Then
               Dim rImpresora = New Reglas.Impresoras(da)._GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, en.IdTipoComprobante)
               en.CentroEmisor = rImpresora.CentroEmisor
            End If

            Dim rVentasNumeros = New Reglas.VentasNumeros()
            Dim nroComprob = rVentasNumeros.GetProximoNumero(actual.Sucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor.ToShort())

            If en.NumeroRequerimiento = 0 Then
               en.NumeroRequerimiento = nroComprob
            End If

            'Se cambia de lugar esta validación y se quita la condición de control.
            'Originalmente solo validaba si era Manual, ahora validamos siempre por estas condiciones:
            '  Si el numerador se tiró para atrás, debe darme error de que se ya existe.
            '  Si es fiscal, se pudo resetear el fiscal o haber dado vuelta el numerador.
            If Existe(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroRequerimiento) Then
               Throw New Exception(String.Format("El Numero de {0} {1} {2:0000}-{3:00000000} YA Existe.",
                                                 en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroRequerimiento))
            End If

            'actualizo el numero de venta en las tablas solo si el numero se calculo
            If en.NumeroRequerimiento >= nroComprob Then
               ActualizarNumerosVentas(en)
            End If

            en.FechaAlta = Date.Now
            en.IdUsuarioAlta = actual.Nombre

            'Si la fecha es de hoy, le actualizo la hora para que sea la de la hora de grabación. Si tiene otra fecha, le dejo la hora que viene desde pantalla.
            If en.Fecha.Date = Date.Today Then
               en.Fecha = Date.Now
            End If

            sql.RequerimientosCompras_I(en.IdRequerimientoCompra,
                                        en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroRequerimiento,
                                        en.Fecha,
                                        en.FechaAlta, en.IdUsuarioAlta,
                                        en.Observacion)
            rRqProductos._Insertar(en)
         Case TipoSP._U
            sql.RequerimientosCompras_U(en.IdRequerimientoCompra,
                                        en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroRequerimiento,
                                        en.Fecha,
                                        en.FechaAlta, en.IdUsuarioAlta,
                                        en.Observacion)
            rRqProductos._Actualizar(en)
         Case TipoSP._D
            rRqProductos._Borrar(en)
            sql.RequerimientosCompras_D(en.IdRequerimientoCompra)
      End Select
   End Sub

   Private Sub ActualizarNumerosVentas(en As Entidades.RequerimientoCompra)
      Dim vtaNro = New Entidades.VentaNumero() With {
         .IdSucursal = en.IdSucursal,
         .IdTipoComprobante = en.IdTipoComprobante,
         .LetraFiscal = en.Letra,
         .CentroEmisor = en.CentroEmisor.ToShort(),
         .Numero = en.NumeroRequerimiento,
         .Fecha = en.Fecha
      }

      Dim rVtaNro = New VentasNumeros(da)
      rVtaNro.ActualizarNumero(vtaNro)
   End Sub

   Private Sub CargarUno(o As Entidades.RequerimientoCompra, dr As DataRow)
      With o
         .IdRequerimientoCompra = dr.Field(Of Long)(Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString())

         .IdSucursal = dr.Field(Of Integer)(Entidades.RequerimientoCompra.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.RequerimientoCompra.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.RequerimientoCompra.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.RequerimientoCompra.Columnas.CentroEmisor.ToString())
         .NumeroRequerimiento = dr.Field(Of Long)(Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString())

         .Fecha = dr.Field(Of Date)(Entidades.RequerimientoCompra.Columnas.Fecha.ToString())
         .FechaAlta = dr.Field(Of Date)(Entidades.RequerimientoCompra.Columnas.FechaAlta.ToString())
         .IdUsuarioAlta = dr.Field(Of String)(Entidades.RequerimientoCompra.Columnas.IdUsuarioAlta.ToString())
         .Observacion = dr.Field(Of String)(Entidades.RequerimientoCompra.Columnas.Observacion.ToString())

         .Productos = New RequerimientosComprasProductos(da).GetTodos(.IdRequerimientoCompra).ToConBorrados()

      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.RequerimientoCompra)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.RequerimientoCompra)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.RequerimientoCompra)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub AnularRequerimiento(rq As Entidades.RequerimientoCompra)
      EjecutaConTransaccion(Sub() _AnularRequerimiento(rq))
   End Sub
   Public Sub _AnularRequerimiento(rq As Entidades.RequerimientoCompra)
      Dim rRqProd = New RequerimientosComprasProductos(da)
      rRqProd._AnularRequerimientoProducto(rq.Productos)
   End Sub

   Public Function Existe(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroRequerimiento As Long) As Boolean
      Return Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroRequerimiento).Any()
   End Function
   Public Function Get1(idRequerimientoCompra As Long) As DataTable
      Return New SqlServer.RequerimientosCompras(da).RequerimientosCompras_G1(idRequerimientoCompra)
   End Function
   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroRequerimiento As Long) As DataTable
      Return New SqlServer.RequerimientosCompras(da).RequerimientosCompras_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroRequerimiento)
   End Function
   Public Function GetUno(idRequerimientoCompra As Long) As Entidades.RequerimientoCompra
      Return GetUno(idRequerimientoCompra, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idRequerimientoCompra As Long, accion As AccionesSiNoExisteRegistro) As Entidades.RequerimientoCompra
      Return CargaEntidad(Get1(idRequerimientoCompra), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RequerimientoCompra(),
                          accion, Function() String.Format("No existe el Requerimiento de Compra con Id {0}.", idRequerimientoCompra))
   End Function

   Public Function GetTodos() As List(Of Entidades.RequerimientoCompra)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RequerimientoCompra())
   End Function

   Public Function GetInformeRequerimietos(fechaDesde As Date?, fechaHasta As Date?, fechaEntregaDesde As Date?, fechaEntregaHasta As Date?,
                                           tiposComprobante As Entidades.TipoComprobante(), numeroRequerimiento As Long,
                                           asignados As Entidades.Publicos.SiNoTodos, idUsuario As String,
                                           idProducto As String,
                                           marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                           rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro()) As DataSet
      Dim dsResult = New DataSet()
      Dim dtRq = New SqlServer.RequerimientosCompras(da).
                        GetParaInfRequerimietos(fechaDesde, fechaHasta, fechaEntregaDesde, fechaEntregaHasta,
                                                tiposComprobante, numeroRequerimiento,
                                                asignados, idUsuario,
                                                idProducto, marcas, modelos, rubros, subrubros, subSubRubros,
                                                soloConLineasAnulables:=Entidades.Publicos.SiNo.NO)
      dtRq.TableName = "Requerimientos"
      dtRq.Columns.Add("ImprimirComp", GetType(String))

      Dim dtRqProd = New SqlServer.RequerimientosComprasProductos(da).
                        GetParaInfRequerimietos(fechaDesde, fechaHasta, fechaEntregaDesde, fechaEntregaHasta,
                                                tiposComprobante, numeroRequerimiento,
                                                asignados, idUsuario,
                                                idProducto, marcas, modelos, rubros, subrubros, subSubRubros)
      dtRqProd.TableName = "Productos"

      Dim dtRqAsig = New SqlServer.RequerimientosComprasProductosAsignaciones(da).
                        GetParaInfRequerimietos(fechaDesde, fechaHasta, fechaEntregaDesde, fechaEntregaHasta,
                                                tiposComprobante, numeroRequerimiento,
                                                asignados, idUsuario,
                                                idProducto, marcas, modelos, rubros, subrubros, subSubRubros)
      dtRqAsig.TableName = "Asignados"

      dsResult.Tables.AddRange({dtRq, dtRqProd, dtRqAsig})
      dsResult.AddRelation("Req_Prod", dtRq, dtRqProd, {"IdRequerimientoCompra"})
      dsResult.AddRelation("Prod_Asig", dtRqProd, dtRqAsig, {"IdRequerimientoCompra", "IdProducto", "Orden"})

      Return dsResult
   End Function
   Public Function GetRequerimietosParaAnular(fechaDesde As Date?, fechaHasta As Date?, fechaEntregaDesde As Date?, fechaEntregaHasta As Date?,
                                              tiposComprobante As Entidades.TipoComprobante(), numeroRequerimiento As Long,
                                              idProducto As String) As DataTable
      Return New SqlServer.RequerimientosCompras(da).
                        GetParaInfRequerimietos(fechaDesde, fechaHasta, fechaEntregaDesde, fechaEntregaHasta,
                                                tiposComprobante, numeroRequerimiento,
                                                Entidades.Publicos.SiNoTodos.TODOS, idUsuario:=String.Empty,
                                                idProducto, marcas:=Nothing, modelos:=Nothing, rubros:=Nothing, subrubros:=Nothing, subSubRubros:=Nothing,
                                                soloConLineasAnulables:=Entidades.Publicos.SiNo.SI)
   End Function
   Public Function GetInfReqDetProducto(fechaDesde As Date?, fechaHasta As Date?, fechaEntregaDesde As Date?, fechaEntregaHasta As Date?,
                                        tiposComprobante As Entidades.TipoComprobante(), numeroRequerimiento As Long,
                                        asignados As Entidades.Publicos.SiNoTodos, detallesAsignados As Entidades.Publicos.SiNoTodos, idUsuario As String,
                                        idProveedor As Long, idProducto As String,
                                        marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                        rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro(),
                                        anulados As Entidades.Publicos.SiNoTodos,
                                        agregarSelec As Boolean, incluyeDetalleAsignados As Boolean, PlanMaestroNumero As Integer?, PlanMaestroFechaDesde As Date?,
                                        PlanMaestroFechaHasta As Date?) As DataTable
      Return New SqlServer.RequerimientosCompras(da).
                     GetInfReqDetProducto(fechaDesde, fechaHasta, fechaEntregaDesde, fechaEntregaHasta,
                                          tiposComprobante, numeroRequerimiento,
                                          asignados, detallesAsignados, idUsuario,
                                          idProveedor, idProducto, marcas, modelos, rubros, subrubros, subSubRubros,
                                          anulados,
                                          agregarSelec, incluyeDetalleAsignados, PlanMaestroNumero, PlanMaestroFechaDesde,
                                          PlanMaestroFechaHasta)
   End Function
   Public Function GetCodigoMaximo() As Long
      Return New SqlServer.RequerimientosCompras(da).GetCodigoMaximo()
   End Function

   Public Sub GenerarAsignaciones(dtAsignaciones As DataTable, tipoComprobante As Entidades.TipoComprobante, formaDePago As Entidades.VentaFormaPago,
                                  vendedor As Entidades.Empleado, estadoVisita As Entidades.EstadoVisita)
      EjecutaConTransaccion(Sub() _GenerarAsignaciones(dtAsignaciones, tipoComprobante, formaDePago,
                                                       vendedor, estadoVisita))
   End Sub
   Public Sub _GenerarAsignaciones(dtAsignaciones As DataTable, tipoComprobante As Entidades.TipoComprobante, formaDePago As Entidades.VentaFormaPago,
                                   vendedor As Entidades.Empleado, estadoVisita As Entidades.EstadoVisita)
      Dim cache = New BusquedasCacheadas()

      'Obtengo una lista con los diferentes Id de Proveedores del DataTable para poner un Presupuesto para cada uno
      Dim idProveedores = dtAsignaciones.AsEnumerable().ToList().ConvertAll(Function(dr) dr.Field(Of Long)("IdProveedorAsignado")).Distinct()

      Dim rPP = New PedidosProveedores(da)
      Dim rProd = New Productos(da)
      Dim rRQAsig = New RequerimientosComprasProductosAsignaciones(da)

      'Tomo la primer criticidad ya que no se pide por pantalla
      Dim criticidad = New PedidosCriticidades(da).GetTodos().OrderBy(Function(c) c.Orden).First()

      'Por cada IdProveedor voy a poner un Presupuesto
      For Each idProveedor In idProveedores
         Dim prov = New Proveedores(da)._GetUno(idProveedor)
         Dim drProdAsigCol = dtAsignaciones.Where(Function(dr) dr.Field(Of Long)("IdProveedorAsignado") = idProveedor)

         'Preparo la lista de Asignaciones para luego poder guardar
         Dim lstRQAsig = New List(Of Entidades.RequerimientoCompraProductoAsignacion)
         'Prepara la lista de Producto a cargar en el presupuesto
         Dim lstProd = New List(Of Entidades.RequerimientoCompraProducto)

         For Each drProd In drProdAsigCol
            Dim idProducto = drProd.Field(Of String)("IdProducto")
            Dim nombreProducto = drProd.Field(Of String)("NombreProducto")
            Dim fechaEntrega = drProd.Field(Of Date)("FechaAsignacion")
            Dim cantidadAsignada = drProd.Field(Of Decimal)("CantidadAsignada")
            Dim cantidadUMCompra = drProd.Field(Of Decimal)("CantidadUMCompra")
            Dim factorConversionCompra = drProd.Field(Of Decimal)("FactorConversionCompra")

            'Agrupo los productos por Id, Nombre (*) y Fecha de Entrega y acumulo la cantidad asiganda
            '   (*) Puede haber un mismo Id con Nombre modificado
            '   Uso Entidades.RequerimientoCompraProducto para no definir una nueva clase para procesar. De ser necesario crear una.
            Dim reP = lstProd.FirstOrDefault(Function(x) x.IdProducto = idProducto AndAlso x.NombreProducto = nombreProducto AndAlso x.FechaEntrega = fechaEntrega)
            If reP Is Nothing Then
               reP = New Entidades.RequerimientoCompraProducto() With {.IdProducto = idProducto, .NombreProducto = nombreProducto, .FechaEntrega = fechaEntrega}
               lstProd.Add(reP)
            End If
            reP.Cantidad += cantidadAsignada
            reP.CantidadUMCompra += cantidadUMCompra
            reP.FactorConversionCompra = factorConversionCompra

            'Agrego las Asignaciones a la lista para almacenar luego
            lstRQAsig.Add(New Entidades.RequerimientoCompraProductoAsignacion() With {
                              .IdRequerimientoCompra = drProd.Field(Of Long)("IdRequerimientoCompra"),
                              .IdProducto = idProducto,
                              .Orden = drProd.Field(Of Integer)("Orden"),
                              .Cantidad = drProd.Field(Of Decimal)("CantidadAsignada"),
                              .FechaAsignacion = Date.Now,
                              .IdUsuarioAsignacion = actual.Nombre
                          })
         Next

         'Creo un nuevo Presupuesto
         Dim pedido = rPP._CrearPedido(prov, tipoComprobante, letra:=String.Empty, centroEmisor:=Nothing, numeroComprobante:=Nothing,
                                       fecha:=Date.Today, vendedor, transportista:=Nothing, formaDePago, tipoComprobanteFact:=Nothing,
                                       observaciones:=String.Empty, estadoVisita, ordenCompra:=0)

         'Por cada Producto (ya agrupado previamente) agrego las mismas al Pedido antes creado
         For Each drProd In lstProd
            Dim prod = cache.BuscaProductoEntidadPorId(drProd.IdProducto, da)
            Dim pedidoProd = rPP.CrearPedidoProducto(prod, drProd.NombreProducto,
                                                     descuentoRecargoPorc1:=0, descuentoRecargoPorc2:=0, costo:=Nothing,
                                                     drProd.Cantidad,
                                                     tipoImpuesto:=cache.BuscaTiposImpuestos(prod.IdTipoImpuesto), porcentajeIva:=Nothing,
                                                     criticidad, drProd.FechaEntrega, drProd.CantidadUMCompra, drProd.FactorConversionCompra, precioPorUMCompra:=Nothing,
                                                     pedido, redondeoEnCalculo:=2)
            rPP.AgregarLinea(pedido, pedidoProd)
         Next

         'Guardo el Presupuesto y así obtengo el nuevo número para agregarlo a todos los registros de Asignaciones
         Dim pedidoGuardado = rPP.Inserta(pedido)
         'Agrego la PK del Presupuesto a cada Asignación ya preparadas.
         lstRQAsig.ForEach(Sub(a)
                              a.IdSucursalPedido = pedido.IdSucursal
                              a.IdTipoComprobantePedido = pedido.IdTipoComprobante
                              a.LetraPedido = pedido.LetraComprobante
                              a.CentroEmisorPedido = pedido.CentroEmisor
                              a.NumeroPedido = pedido.NumeroPedido
                           End Sub)
         'Inserto las Asignaciones
         rRQAsig._Insertar(lstRQAsig)
      Next

   End Sub

#End Region

End Class