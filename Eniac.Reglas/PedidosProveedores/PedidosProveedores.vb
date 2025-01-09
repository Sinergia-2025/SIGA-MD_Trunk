Public Class PedidosProveedores
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("PedidosProveedores", accesoDatos)
      _categoriaFiscalEmpresa = New CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
      _convertirPedidoEnFacturaConservaPreciosPedido = Publicos.ConvertirPedidoEnFacturaConservaPreciosPedido
   End Sub

#End Region

   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _convertirPedidoEnFacturaConservaPreciosPedido As Boolean

#Region "Overrides"

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.PedidoProveedor)))
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.PedidoProveedor)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.PedidoProveedor)))
   End Sub

#End Region

#Region "metodos privates"

   Public Function GetIdSiguiente(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Short) As Integer
      Dim sql As SqlServer.PedidosProveedores = New SqlServer.PedidosProveedores(da)
      Return (sql.PedidosProveedores_GetIdMaximo(idSucursal, idTipoComprobante, letraFiscal, emisor) + 1)
   End Function

   Private Function Actualiza(oPedido As Entidades.PedidoProveedor) As Entidades.PedidoProveedor
      Dim pedidoResult As Entidades.PedidoProveedor
      VerificaPedidoModificable(oPedido)

      Dim sqlPE As SqlServer.PedidosEstadosProveedores = New SqlServer.PedidosEstadosProveedores(da)

      Using dtPresup = sqlPE.PedidosEstadosProveedores_G_PorComprobanteGenerado(oPedido.IdSucursal,
                                                                                oPedido.IdTipoComprobante,
                                                                                oPedido.LetraComprobante,
                                                                                oPedido.CentroEmisor,
                                                                                oPedido.NumeroPedido)
         For Each drPresup In dtPresup.AsEnumerable()
            sqlPE.PedidosEstadosProveedores_U_Ped(Integer.Parse(drPresup(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                                                  drPresup(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                  drPresup(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                                                  Integer.Parse(drPresup(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                                                  Long.Parse(drPresup(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                                                  drPresup(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                                                  DateTime.Parse(drPresup(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString()),
                                                  Nothing,
                                                  Integer.Parse(drPresup(Entidades.PedidoEstado.Columnas.Orden.ToString()).ToString()),
                                                  idSucursalGenerado:=0,
                                                  idTipoComprobanteGenerado:=String.Empty,
                                                  letraGenerado:=String.Empty,
                                                  centroEmisorGenerado:=0,
                                                  numeroPedidoGenerado:=0)
         Next

         Dim dt = pedidosCabecera(actual.Sucursal.Id, "TODOS", Nothing, Nothing,
                                  oPedido.NumeroPedido,
                                  String.Empty, 0, 0, String.Empty, 0, String.Empty, 0, 0, 0,
                                  "PEDIDOSPROV",
                                  {oPedido.TipoComprobante}, oPedido.LetraComprobante, oPedido.CentroEmisor)

         _AnularPedidos(dt, "PEDIDOSPROV", "PedidosProveedores")

         Dim rReqAsig = New RequerimientosComprasProductosAsignaciones(da)
         Dim reqAsigList = rReqAsig.GetTodosPorAsignacion(oPedido.IdSucursal, oPedido.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor, oPedido.NumeroPedido)

         For Each reqAsig In reqAsigList
            rReqAsig._Borrar(reqAsig)
         Next

         Borra(oPedido)
         pedidoResult = Inserta(oPedido)

         For Each reqAsig In reqAsigList
            rReqAsig._Insertar(reqAsig)
         Next


         For Each drPresup In dtPresup.AsEnumerable()
            sqlPE.PedidosEstadosProveedores_U_Ped(Integer.Parse(drPresup(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                                                  drPresup(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                  drPresup(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                                                  Integer.Parse(drPresup(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                                                  Long.Parse(drPresup(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                                                  drPresup(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                                                  DateTime.Parse(drPresup(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString()),
                                                  Nothing,
                                                  Integer.Parse(drPresup(Entidades.PedidoEstado.Columnas.Orden.ToString()).ToString()),
                                                  idSucursalGenerado:=pedidoResult.IdSucursal,
                                                  idTipoComprobanteGenerado:=pedidoResult.IdTipoComprobante,
                                                  letraGenerado:=pedidoResult.LetraComprobante,
                                                  centroEmisorGenerado:=pedidoResult.CentroEmisor,
                                                  numeroPedidoGenerado:=pedidoResult.NumeroPedido)
         Next
      End Using

      Return pedidoResult

   End Function

   Private Sub Borra(oPedido As Entidades.PedidoProveedor)
      EjecutaSP(oPedido, TipoSP._D)
   End Sub

   Public Function Inserta(oPedido As Entidades.PedidoProveedor) As Entidades.PedidoProveedor

      'Si el Estado de Visita no adminte lineas y el pedido viene con lineas, no puedo guardar el pedido.
      If Not oPedido.EstadoVisita.AdmintePedidoConLineas And oPedido.PedidosProductos.Count > 0 Then
         Throw New Exception(String.Format("El estado de visita '{0}' del '{1} {2} {3:0000}-{4:00000000}' no adminte lineas. Verifique el estado de visita indicado en el Pedido.'",
                                           oPedido.NombreEstadoVisita, oPedido.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor, oPedido.NumeroPedido))
      End If

      'Si el Estado de Visita no adminte sin lineas y el pedido viene sin lineas, no puedo guardar el pedido.
      If Not oPedido.EstadoVisita.AdmitePedidoSinLineas And oPedido.PedidosProductos.Count = 0 Then
         Throw New Exception(String.Format("El estado de visita '{0}' del '{1} {2} {3:0000}-{4:00000000}' requiere al menos una linea. Verifique el estado de visita indicado en el Pedido.'",
                                           oPedido.NombreEstadoVisita, oPedido.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor, oPedido.NumeroPedido))
      End If

      If oPedido.NumeroPedido > 0 Then
         'SPC: PEDIDOS - PENDIENTE DEFINIR SI EXISTE
         'If Me.Existe(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, _
         '               oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor, _
         '               oVentas.NumeroComprobante) Then
         '   Throw New Exception("El Numero de Comprobante " & oVentas.NumeroComprobante.ToString() & " YA Existe.")
         'End If
      End If

      If oPedido.CentroEmisor = 0 Then
         oPedido.CentroEmisor = oPedido.Impresora.CentroEmisor
      End If

      Dim rVentasNumeros = New VentasNumeros(da)
      Dim NumeroComprob = rVentasNumeros.GetProximoNumero(New Reglas.Sucursales(da).GetUna(oPedido.IdSucursal, False),
                                                          oPedido.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor)
      'Tiene que ser NO fiscal y NO haberlo digitado en la pantalla.
      If oPedido.NumeroPedido = 0 Then
         oPedido.NumeroPedido = Math.Max(NumeroComprob, GetIdSiguiente(oPedido.IdSucursal, oPedido.IdTipoComprobante,
                                                                        oPedido.LetraComprobante, oPedido.CentroEmisor))
      End If

      'actualizo el numero de venta en las tablas solo si el numero se calculo
      If oPedido.NumeroPedido >= NumeroComprob Then
         Dim rVta As Ventas = New Ventas(da)
         rVta.ActualizarNumerosVentas(oPedido.IdSucursal, oPedido.IdTipoComprobante,
                                      oPedido.LetraComprobante, oPedido.CentroEmisor,
                                      oPedido.NumeroPedido, oPedido.Fecha)
      End If


      EjecutaSP(oPedido, TipoSP._I)

      ' '' ''Grabo el detalle de OrdenesComprasPedidos
      '' ''If oPedido.NumeroOrdenCompra <> 0 And Publicos.UtilizaOrdenCompraPedidos Then
      '' ''   Dim rOrdenesComprasPedidos As Reglas.OrdenesCompraPedidos = New Reglas.OrdenesCompraPedidos(da)
      '' ''   rOrdenesComprasPedidos.Insertar(oPedido)
      '' ''End If

      Dim rPedProd As PedidosProductosProveedores = New PedidosProductosProveedores(da)
      rPedProd.InsertaDetalleDesdePedido(oPedido)

      'Se deja disponible para cuando se implemente ProveedoresContactos
      'Dim rPedCont As PedidosClientesContactos = New PedidosClientesContactos(da)
      'rPedCont.InsertaContactosDesdePedido(oPedido)

      Dim rPedObs As PedidosObservacionesProveedores = New PedidosObservacionesProveedores(da)
      rPedObs.InsertaObservacionesDesdePedido(oPedido)

      Return oPedido
   End Function

   Public Sub EjecutaSP(oPedido As Eniac.Entidades.PedidoProveedor, tipo As TipoSP)

      Dim sql As SqlServer.PedidosProveedores = New SqlServer.PedidosProveedores(da)

      Select Case tipo

         Case TipoSP._I
            sql.PedidosProveedores_I(oPedido.IdSucursal,
                                     oPedido.IdTipoComprobante,
                                     oPedido.LetraComprobante,
                                     oPedido.CentroEmisor,
                                     oPedido.NumeroPedido,
                                     oPedido.Fecha,
                                     oPedido.Observacion,
                                     actual.Nombre,
                                     oPedido.DescuentoRecargo,
                                     oPedido.DescuentoRecargoPorc,
                                     oPedido.Proveedor.IdProveedor,
                                     oPedido.IdEmpleado,
                                     oPedido.IdFormaPago,
                                     oPedido.IdTransportista,
                                     oPedido.CotizacionDolar,
                                     oPedido.IdTipoComprobanteFact,
                                     oPedido.ImporteBruto,
                                     oPedido.SubTotal,
                                     oPedido.TotalImpuestos,
                                     oPedido.TotalImpuestoInterno,
                                     oPedido.ImporteTotal,
                                     oPedido.IdEstadoVisita,
                                     oPedido.NumeroOrdenCompra,
                                     oPedido.FechaAutorizacion,
                                     oPedido.FechaReprogramacion,
                                     oPedido.IdMoneda)

         Case TipoSP._U

         Case TipoSP._D
            Dim sqlPO As SqlServer.PedidosObservacionesProveedores = New SqlServer.PedidosObservacionesProveedores(da)
            sqlPO.PedidosObservacionesProveedores_D(oPedido.IdSucursal, oPedido.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor, oPedido.NumeroPedido, 0)
            'Se deja disponible para cuando esté implementado ProveedoresContactos
            'Dim sqlPCC As SqlServer.PedidosClientesContactos = New SqlServer.PedidosClientesContactos(da)
            'sqlPCC.PedidosClientesContactos_D(oPedido.IdSucursal, oPedido.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor, oPedido.NumeroPedido)
            Dim sqlPE As SqlServer.PedidosEstadosProveedores = New SqlServer.PedidosEstadosProveedores(da)
            sqlPE.PedidosEstadosProveedores_D(oPedido.IdSucursal, oPedido.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor, oPedido.NumeroPedido, Nothing, String.Empty, Nothing)
            Dim sqlPP As SqlServer.PedidosProductosProveedores = New SqlServer.PedidosProductosProveedores(da)
            sqlPP.PedidosProductosProveedores_D(oPedido.IdSucursal, oPedido.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor, oPedido.NumeroPedido, Nothing, String.Empty)

            sql.PedidosProveedores_D(oPedido.IdSucursal, oPedido.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor, oPedido.NumeroPedido)
      End Select

   End Sub


   Private Sub CargarUno(o As Entidades.PedidoProveedor, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).ToString())
         .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString())
         .LetraComprobante = dr(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString())
         .Fecha = Date.Parse(dr(Entidades.PedidoProveedor.Columnas.FechaPedido.ToString()).ToString())

         .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(dr(Entidades.PedidoProveedor.Columnas.IdProveedor.ToString()).ToString()))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoProveedor.Columnas.IdComprador.ToString()).ToString()) Then
            .Comprador = New Reglas.Empleados(da).GetUno(Integer.Parse(dr(Entidades.PedidoProveedor.Columnas.IdComprador.ToString()).ToString()))
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoProveedor.Columnas.IdTransportista.ToString()).ToString()) Then
            .Transportista = New Reglas.Transportistas(da).GetUno(Long.Parse(dr(Entidades.PedidoProveedor.Columnas.IdTransportista.ToString()).ToString()))
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoProveedor.Columnas.IdFormasPago.ToString()).ToString()) Then
            .FormaPago = New Reglas.VentasFormasPago(da).GetUna(Integer.Parse(dr(Entidades.PedidoProveedor.Columnas.IdFormasPago.ToString()).ToString()))
         End If

         .DescuentoRecargo = Decimal.Parse(dr(Entidades.PedidoProveedor.Columnas.DescuentoRecargo.ToString()).ToString())
         .DescuentoRecargoPorc = Decimal.Parse(dr(Entidades.PedidoProveedor.Columnas.DescuentoRecargoPorc.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoProveedor.Columnas.CotizacionDolar.ToString()).ToString()) Then
            .CotizacionDolar = Decimal.Parse(dr(Entidades.PedidoProveedor.Columnas.CotizacionDolar.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoProveedor.Columnas.IdTipoComprobanteFact.ToString()).ToString()) Then
            .TipoComprobanteFact = New Reglas.TiposComprobantes(da).GetUno(dr(Entidades.PedidoProveedor.Columnas.IdTipoComprobanteFact.ToString()).ToString())
         End If

         .Observacion = dr(Entidades.PedidoProveedor.Columnas.Observacion.ToString()).ToString()

         .IdUsuario = dr(Entidades.PedidoProveedor.Columnas.IdUsuario.ToString()).ToString()


         .PedidosProductos = New PedidosProductosProveedores(da).GetTodos(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroPedido)

         If Not .CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
            For Each vp In .PedidosProductos
               'vp.Precio = Math.Round(vp.Precio * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
               If vp.Cantidad <> 0 Then
                  vp.Costo = Math.Round(vp.Costo * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
                  vp.CostoLista = Math.Round(vp.CostoLista * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
                  vp.CostoNeto = Math.Round(vp.CostoNeto * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
               End If
               vp.PrecioPorUMCompra = Math.Round(vp.PrecioPorUMCompra * (1 + (vp.AlicuotaImpuesto / 100)), 2)
               vp.ImporteTotal = Math.Round(vp.ImporteTotal * (1 + (vp.AlicuotaImpuesto / 100)) + vp.ImporteImpuestoInterno, 2)
               vp.ImporteTotalNeto = Math.Round(vp.ImporteTotalNeto * (1 + (vp.AlicuotaImpuesto / 100)) + vp.ImporteImpuestoInterno, 2)
               vp.DescuentoRecargoProducto = vp.DescuentoRecargoProducto * (1 + (vp.AlicuotaImpuesto / 100))
            Next
         End If

         .ImporteBruto = Decimal.Parse(dr(Entidades.PedidoProveedor.Columnas.ImporteBruto.ToString()).ToString())
         .SubTotal = Decimal.Parse(dr(Entidades.PedidoProveedor.Columnas.SubTotal.ToString()).ToString())
         .TotalImpuestos = Decimal.Parse(dr(Entidades.PedidoProveedor.Columnas.TotalImpuestos.ToString()).ToString())
         .TotalImpuestoInterno = Decimal.Parse(dr(Entidades.PedidoProveedor.Columnas.TotalImpuestoInterno.ToString()).ToString())
         .ImporteTotal = Decimal.Parse(dr(Entidades.PedidoProveedor.Columnas.ImporteTotal.ToString()).ToString())

         .EstadoVisita = New EstadosVisitas(da).GetUno(Integer.Parse(dr(Entidades.PedidoProveedor.Columnas.IdEstadoVisita.ToString()).ToString()))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoProveedor.Columnas.NumeroOrdenCompra.ToString()).ToString()) Then
            .NumeroOrdenCompra = Long.Parse(dr(Entidades.PedidoProveedor.Columnas.NumeroOrdenCompra.ToString()).ToString())
         End If

         Dim totalKilosItems As Reglas.Ventas.TotalKilosItems = CalculaTotalKilosItems(.PedidosProductos)
         .CantidadProductos = totalKilosItems.TotalProductos

         .PedidosObservaciones = New Reglas.PedidosObservacionesProveedores(da).GetTodos(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroPedido)

         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoProveedor.Columnas.FechaReprogramacion.ToString()).ToString()) Then
            .FechaReprogramacion = DateTime.Parse(dr(Entidades.PedidoProveedor.Columnas.FechaReprogramacion.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoProveedor.Columnas.Idmoneda.ToString()).ToString()) Then
            .IdMoneda = Integer.Parse(dr(Entidades.PedidoProveedor.Columnas.Idmoneda.ToString()).ToString())
         End If

         'Lo dejamos para cuando se habilite la funcionalidad de ProveedoresContactos
         '.PedidosContactos = New Reglas.PedidosClientesContactosProveedores(da).GetTodos(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroPedido)

      End With
   End Sub

#End Region

#Region "metodos publicos"
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As Entidades.PedidoProveedor
      Dim sql As SqlServer.PedidosProveedores = New SqlServer.PedidosProveedores(da)
      Dim dt As DataTable = sql.PedidosProveedores_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
      Dim o As Entidades.PedidoProveedor = New Entidades.PedidoProveedor()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception(String.Format("No existe el Pedido {0}-{1:00000000}.", idSucursal, numeroPedido))
      End If
      Return o
   End Function

   Public Function _GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As DataTable
      Dim sql As SqlServer.PedidosProveedores = New SqlServer.PedidosProveedores(da)
      Dim dt As DataTable = sql.PedidosProveedores_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
      Return dt
   End Function
   <Obsolete("No se debe estar usando en ningún lado")>
   Public Overrides Function GetAll() As System.Data.DataTable
      'Dim sql As SqlServer.EstadosPedidos = New SqlServer.EstadosPedidos(da)
      'Return sql.EstadosPedidos_GA(False)
      Throw New NotImplementedException("PedidosProveedores.GetAll() no está implementado")
   End Function

   Public Sub AnularPedidos(tablaAnular As DataTable, TipoEstadoPedido As String, idFuncion As String)
      Try
         da.OpenConection()
         da.BeginTransaction()

         _AnularPedidos(tablaAnular, TipoEstadoPedido, idFuncion)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub _AnularPedidos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, tipoEstadoPedido As String, idFuncion As String)
      Dim dt = New DataTable()
      dt.Columns.Add(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString(), GetType(String))
      dt.Columns.Add(Entidades.PedidoProveedor.Columnas.Letra.ToString(), GetType(String))
      dt.Columns.Add(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString(), GetType(Long))
      dt.Rows.Add(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
      _AnularPedidos(dt, tipoEstadoPedido, idFuncion)
   End Sub

   Public Sub _AnularPedidos(tablaAnular As DataTable, TipoEstadoPedido As String, idFuncion As String)
      Dim dtAux As DataTable

      Dim rPP As Reglas.PedidosProductosProveedores = New PedidosProductosProveedores(da)
      Dim rPE As Reglas.PedidosEstadosProveedores = New PedidosEstadosProveedores(da)
      Dim sqlPE As SqlServer.PedidosEstadosProveedores = New SqlServer.PedidosEstadosProveedores(da)
      Dim sqlPP As SqlServer.PedidosProductosProveedores = New SqlServer.PedidosProductosProveedores(da)
      Dim sqlP As SqlServer.PedidosProveedores = New SqlServer.PedidosProveedores(da)
      Dim sqlPO As SqlServer.PedidosObservacionesProveedores = New SqlServer.PedidosObservacionesProveedores(da)
      'Lo mantenemos para cuando se habilite ProveedoresContactos
      'Dim sqlPCC As SqlServer.PedidosClientesContactos = New SqlServer.PedidosClientesContactos(da)

      Dim idEstadoAnterior As String
      Dim idTipoEstadoAnterior As String = Entidades.EstadoPedidoProveedor.TipoEstado.PENDIENTE ' SOLO SE PERMITE ANULAR PEDIDOS CON TIPO ESTADO 'PENDIENTE', SI ESTÁ EN 'EN PROCESO' DEBE CAMBIARSE DE ESTADO POR EL ADMIN Y LUEGO ANULARSE.
      Dim idEstadoNuevo As String = Publicos.PedidoProveedorEstadoAnulado ' EstadoPedidoProveedor.ESTADO_ANULADO '' "ANULADO"
      Dim idTipoEstadoNuevo As String = New EstadosPedidosProveedores(da).GetUno(idEstadoNuevo, TipoEstadoPedido).IdTipoEstado

      For Each filaAnula As DataRow In tablaAnular.Rows
         dtAux = sqlPE.PedidosEstadosProveedores_GA(Integer.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).ToString),
                                                    filaAnula(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                    filaAnula(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                                                    Integer.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                                                    Long.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()),
                                                    idTipoEstadoAnterior)
         For Each filaPendiente As DataRow In dtAux.Rows
            idEstadoAnterior = filaPendiente("IdEstado").ToString()
            rPE.CambiarEstado(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                              filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                              filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                              Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                              Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                              filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                              Date.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString),
                              idEstadoNuevo,
                              TipoEstadoPedido,
                              Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString),
                              Date.Now,
                              "Pedido Anulado",
                              Integer.Parse(filaPendiente("Orden").ToString),
                              filaPendiente("IdCriticidad").ToString(),
                              Date.Parse(filaPendiente("FechaEntrega").ToString), 0)
            rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                                                            filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                            filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                                                            Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                                                            Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                                                            filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                                                            Integer.Parse(filaPendiente("Orden").ToString),
                                                            idTipoEstadoAnterior, idTipoEstadoNuevo,
                                                            Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()))

            rPE.RegistraMovimientoStock(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                                    filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                                    filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                                    Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                                    Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                                    filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                                    Integer.Parse(filaPendiente("Orden").ToString),
                                    idEstadoAnterior, idEstadoNuevo, TipoEstadoPedido,
                                    Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()),
                                    Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

         Next     'For Each filaPendiente As DataRow In dtAux.Rows
         ' Ver si elimina Ordenes Compras Pedidos
         AnulaPedidoGenerador(Integer.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).ToString),
                              filaAnula(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                              filaAnula(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                              Short.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                              Long.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()),
                              idFuncion,
                              sqlP, sqlPP, sqlPE, sqlPO, rPP, rPE)
      Next        'For Each filaAnula As DataRow In tablaAnular.Rows
   End Sub


   Private Sub AnulaPedidoGenerador(idSucursal As Integer, idTipoComprobante As String, letra As String,
                                    centroEmisor As Short, numeroPedido As Long,
                                    idFuncion As String,
                                    sqlP As SqlServer.PedidosProveedores, sqlPP As SqlServer.PedidosProductosProveedores, sqlPE As SqlServer.PedidosEstadosProveedores,
                                    sqlPO As SqlServer.PedidosObservacionesProveedores,
                                    rPP As Reglas.PedidosProductosProveedores, rPE As Reglas.PedidosEstadosProveedores)
      'sqlPCC As SqlServer.PedidosClientesContactos,  Lo mantenemos para cuando se implemente ProveedoresContactos
      Dim lstPedidoEstado = rPE.GetTodosPorPedidoGenerado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
      Dim fechaNuevoEstado As Date = Now
      Dim pedidoActual As Entidades.PedidoProveedor = Nothing
      Dim observacion = String.Format("Anulación {0} {1} {2:0000}-{3:00000000}", idTipoComprobante, letra, centroEmisor, numeroPedido)

      Dim idEstadoPedidoGenerador As String = Publicos.EstadoPresupuestoAlAnularPedido

      Dim lstPedidosAResetear = New List(Of Entidades.Pedido)()

      For Each pedidoEstado In lstPedidoEstado

         If Not lstPedidosAResetear.Exists(Function(p) p.IdSucursal = pedidoEstado.IdSucursal And
                                                       p.IdTipoComprobante = pedidoEstado.IdTipoComprobante And
                                                       p.LetraComprobante = pedidoEstado.Letra And
                                                       p.CentroEmisor = pedidoEstado.CentroEmisor And
                                                       p.NumeroPedido = pedidoEstado.NumeroPedido) Then
            Dim pedido = New Entidades.Pedido With {
                    .IdSucursal = pedidoEstado.IdSucursal,
                    .TipoComprobante = New Entidades.TipoComprobante(pedidoEstado.IdTipoComprobante),
                    .LetraComprobante = pedidoEstado.Letra,
                    .CentroEmisor = pedidoEstado.CentroEmisor.ToShort(),
                    .NumeroPedido = pedidoEstado.NumeroPedido
                }
            lstPedidosAResetear.Add(pedido)
         End If
      Next        'For Each pedidoEstado As PedidoEstado In lstPedidoEstado

      'Ahora la anulación elimina PedidosEstados Original lo recrea como cuando fue generado (en Pendiente) y resetea las cantidades de PedidosProductos.
      For Each pedidoAResetear In lstPedidosAResetear
         sqlPE.PedidosEstadosProveedores_D(
                        pedidoAResetear.IdSucursal,
                        pedidoAResetear.IdTipoComprobante,
                        pedidoAResetear.LetraComprobante,
                        pedidoAResetear.CentroEmisor,
                        pedidoAResetear.NumeroPedido, Nothing, String.Empty, Nothing)
         Dim pedidosProductos = rPP.GetTodos(pedidoAResetear.IdSucursal,
                                             pedidoAResetear.IdTipoComprobante,
                                             pedidoAResetear.LetraComprobante,
                                             pedidoAResetear.CentroEmisor,
                                             pedidoAResetear.NumeroPedido)
         For Each pp In pedidosProductos
            rPE.Inserta(pp)
            sqlPP.ReseteaCantidades(pp.IdSucursal,
                                    pp.IdTipoComprobante,
                                    pp.Letra,
                                    pp.CentroEmisor,
                                    pp.NumeroPedido,
                                    pp.IdProducto,
                                    pp.Orden)
         Next
      Next

   End Sub

   'Private Sub CopiaPedido(idSucursal As Integer, idTipoComprobante As String, letra As String,
   '                        centroEmisor As Short, numeroPedido As Long,
   '                        fechaNuevoPedido As Date, observacion As String,
   '                        sqlP As SqlServer.PedidosProveedores,
   '                        sqlPP As SqlServer.PedidosProductosProveedores,
   '                        sqlPE As SqlServer.PedidosEstadosProveedores,
   '                        sqlPO As SqlServer.PedidosObservacionesProveedores,
   '                        rPP As Reglas.PedidosProductosProveedores)

   '   Dim rVentasNumeros = New VentasNumeros(da)
   '   Dim numeroPedidoNuevo = rVentasNumeros.GetProximoNumero(New Reglas.Sucursales(da).GetUna(idSucursal, False), idTipoComprobante, letra, centroEmisor)
   '   'Tiene que ser NO fiscal y NO haberlo digitado en la pantalla.

   '   'actualizo el numero de venta en las tablas solo si el numero se calculo
   '   Dim rVta As Ventas = New Ventas(da)
   '   rVta.ActualizarNumerosVentas(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedidoNuevo, fechaNuevoPedido)

   '   sqlP.CopiarPedido(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
   '                     idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedidoNuevo,
   '                     fechaNuevoPedido, observacion, actual.Nombre)

   '   sqlPP.CopiarPedidoProducto(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
   '                              idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedidoNuevo)

   '   sqlPP.CreaPedidoEstado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
   '                          idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedidoNuevo,
   '                          fechaNuevoPedido, Entidades.EstadoPedido.ESTADO_ALTA, observacion, actual.Nombre)

   '   sqlPO.CopiarPedidoObservacion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
   '                                 idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedidoNuevo)

   '   'Lo dejamos para cuando esté implementado ProveedoresContactos
   '   'sqlPCC.CopiarPedidoClientesContacto(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
   '   '                                    idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedidoNuevo)

   'End Sub


   Public Function GetPedidos(idSucursal As Integer, idEstado As String,
                              fechaDesde As Date, fechaHasta As Date, numeroPedido As Long,
                              idProducto As String, idProveedor As Long,
                              idMarca As Integer, idRubro As Integer, idSubRubro As Integer, ordenCompra As Long,
                              tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante(), letra As String, centroEmisor As Short,
                              orden As Integer, fechaEstado As Date?, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos) As DataTable
      Return GetPedidos({New Sucursales(da).GetUna(idSucursal, incluirLogo:=False)}, idEstado,
                        fechaDesde, fechaHasta, numeroPedido,
                        idProducto, idProveedor,
                        If(idMarca > 0, {New Marcas(da).GetUna(idMarca)}, {}), {},
                        If(idRubro > 0, {New Rubros(da).GetUno(idRubro)}, {}), If(idSubRubro > 0, {New SubRubros(da).GetUno(idSubRubro)}, {}), {},
                        ordenCompra, tipoTipoComprobante, tiposComprobante, letra, centroEmisor,
                        orden, fechaEstado, seguridadRol)
   End Function

   Public Function GetPedidos(sucursal As Entidades.Sucursal(), idEstado As String,
                              fechaDesde As Date, fechaHasta As Date, numeroPedido As Long,
                              idProducto As String, idProveedor As Long,
                              marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                              rubros As Entidades.Rubro(), subRubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro(),
                              ordenCompra As Long, tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante(), letra As String, centroEmisor As Short,
                              orden As Integer, fechaEstado As Date?, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos) As DataTable
      Dim sql = New SqlServer.PedidosProveedores(da)
      Dim dt = sql.GetPedidos(sucursal, idEstado,
                              fechaDesde, fechaHasta, numeroPedido,
                              idProducto, idProveedor,
                              marcas, modelos, rubros, subRubros, subSubRubros, ordenCompra,
                              tipoTipoComprobante, tiposComprobante, letra, centroEmisor,
                              orden, fechaEstado, seguridadRol)
      dt.Columns("CantidadUMCompraNuevoEstado").Expression = "CantidadUMCompra / Cantidad * CantidadNuevoEstado"
      Return dt
   End Function

   Public Sub VerificaPedidoModificable(pedido As Entidades.PedidoProveedor)
      Dim dt As DataTable = New SqlServer.PedidosProveedores(da).VerificaPedidoModificable(
                                             pedido.IdSucursal, pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido, Publicos.PedidoProveedorEstadoNuevo)
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Dim PedidosProductos As Integer
         Dim PedidosEstados As Integer
         Dim PedidosEstadosNoPendientes As Integer

         If dt.Columns.Contains("PedidosProductos") AndAlso Not String.IsNullOrWhiteSpace(dr("PedidosProductos").ToString()) Then
            PedidosProductos = Integer.Parse(dr("PedidosProductos").ToString())
         End If
         If dt.Columns.Contains("PedidosEstados") AndAlso Not String.IsNullOrWhiteSpace(dr("PedidosEstados").ToString()) Then
            PedidosEstados = Integer.Parse(dr("PedidosEstados").ToString())
         End If
         If dt.Columns.Contains("PedidosEstadosNoPendientes") AndAlso Not String.IsNullOrWhiteSpace(dr("PedidosEstadosNoPendientes").ToString()) Then
            PedidosEstadosNoPendientes = Integer.Parse(dr("PedidosEstadosNoPendientes").ToString())
         End If

         'Si la cantidad de lineas en PedidosProductos y la cantidad de lineas de PedidosEstados significa que el pedido ya se empezó a usar, entonces no permito modificar
         'En caso de que las cantidades de lineas coincidan me fijo también si hay alguna linea con estado distinto de PENDIENTE para estar seguro.
         If PedidosProductos <> PedidosEstados Or PedidosEstadosNoPendientes <> 0 Then
            Throw New Exception(String.Format("El {0} {1} {2:0000}-{3:00000000} no se puede modificar.",
                                              pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido))
         End If
      End If
   End Sub

   Public Function ExistePedido(idSucursal As Integer, IdProveedor As Long, fechaPed As DateTime) As Boolean
      Return New SqlServer.PedidosProveedores(da).ExistePedido(idSucursal, IdProveedor, fechaPed)
   End Function

   Public Function ExistePedido(idSucursal As Integer, NumeroPedido As Long) As Boolean
      Return New SqlServer.PedidosProveedores(da).ExistePedido(idSucursal, NumeroPedido)
   End Function

   Public Function ExistePedido(idSucursal As Integer, idTipoComprobante As String, numeroPedido As Long) As Boolean
      Return New SqlServer.PedidosProveedores(da).ExistePedido(idSucursal, idTipoComprobante, numeroPedido)
   End Function

   Public Function ExistePedido(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long) As Boolean
      Return New SqlServer.PedidosProveedores(da).ExistePedido(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
   End Function

   Public Sub _CancelarPedidos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, tipoEstadoPedido As String, idFuncion As String)
      Dim dt = New DataTable()
      dt.Columns.Add(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString(), GetType(String))
      dt.Columns.Add(Entidades.PedidoProveedor.Columnas.Letra.ToString(), GetType(String))
      dt.Columns.Add(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString(), GetType(Long))
      dt.Rows.Add(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
      _CancelarPedidos(dt, tipoEstadoPedido, idFuncion)
   End Sub

   Public Sub _CancelarPedidos(tablaAnular As DataTable, TipoEstadoPedido As String, idFuncion As String)
      Dim dtAux As DataTable
      Dim dtAux2 As DataTable

      Dim rPP As Reglas.PedidosProductosProveedores = New PedidosProductosProveedores(da)
      Dim rPE As Reglas.PedidosEstadosProveedores = New PedidosEstadosProveedores(da)
      Dim sqlPE As SqlServer.PedidosEstadosProveedores = New SqlServer.PedidosEstadosProveedores(da)
      Dim sqlPP As SqlServer.PedidosProductosProveedores = New SqlServer.PedidosProductosProveedores(da)
      Dim sqlP As SqlServer.PedidosProveedores = New SqlServer.PedidosProveedores(da)
      Dim sqlPO As SqlServer.PedidosObservacionesProveedores = New SqlServer.PedidosObservacionesProveedores(da)
      'Lo mantenemos para cuando se habilite ProveedoresContactos
      'Dim sqlPCC As SqlServer.PedidosClientesContactos = New SqlServer.PedidosClientesContactos(da)

      Dim idEstadoAnterior As String
      Dim idTipoEstadoAnterior As String = Entidades.EstadoPedidoProveedor.TipoEstado.PENDIENTE ' SOLO SE PERMITE ANULAR PEDIDOS CON TIPO ESTADO 'PENDIENTE', SI ESTÁ EN 'EN PROCESO' DEBE CAMBIARSE DE ESTADO POR EL ADMIN Y LUEGO ANULARSE.
      Dim idTipoEstadoAnterior2 As String = Entidades.EstadoPedidoProveedor.TipoEstado.ENPROCESO ' SOLO SE PERMITE ANULAR PEDIDOS CON TIPO ESTADO 'PENDIENTE', SI ESTÁ EN 'EN PROCESO' DEBE CAMBIARSE DE ESTADO POR EL ADMIN Y LUEGO ANULARSE.

      Dim idEstadoNuevo As String = "CANCELADO" ' EstadoPedidoProveedor.ESTADO_ANULADO '' "ANULADO"
      Dim idTipoEstadoNuevo As String = New EstadosPedidosProveedores(da).GetUno(idEstadoNuevo, TipoEstadoPedido).IdTipoEstado

      For Each filaAnula As DataRow In tablaAnular.Rows
         dtAux = sqlPE.PedidosEstadosProveedores_GA(Integer.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).ToString),
                                                    filaAnula(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                    filaAnula(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                                                    Integer.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                                                    Long.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()),
                                                    idTipoEstadoAnterior)
         For Each filaPendiente As DataRow In dtAux.Rows
            idEstadoAnterior = filaPendiente("IdEstado").ToString()
            rPE.CambiarEstado(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                              filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                              filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                              Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                              Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                              filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                              Date.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString),
                              idEstadoNuevo,
                              TipoEstadoPedido,
                              Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString),
                              Date.Now,
                              "Pedido Anulado",
                              Integer.Parse(filaPendiente("Orden").ToString),
                              filaPendiente("IdCriticidad").ToString(),
                              Date.Parse(filaPendiente("FechaEntrega").ToString), 0)
            'rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
            '                                                filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
            '                                                filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
            '                                                Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
            '                                                Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
            '                                                filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
            '                                                Integer.Parse(filaPendiente("Orden").ToString),
            '                                                idTipoEstadoAnterior, idTipoEstadoNuevo,
            '                                                Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()))

            'rPE.RegistraMovimientoStock(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
            '                        filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
            '                        filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
            '                        Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
            '                        Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
            '                        filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
            '                        Integer.Parse(filaPendiente("Orden").ToString),
            '                        idEstadoAnterior, idEstadoNuevo, TipoEstadoPedido,
            '                        Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()),
            '                        Entidad.MetodoGrabacion.Automatico, idFuncion)

         Next

         dtAux2 = sqlPE.PedidosEstadosProveedores_GA(Integer.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).ToString),
                                                    filaAnula(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                    filaAnula(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                                                    Integer.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                                                    Long.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()),
                                                    idTipoEstadoAnterior2)
         For Each filaPendiente As DataRow In dtAux2.Rows
            idEstadoAnterior = filaPendiente("IdEstado").ToString()
            rPE.CambiarEstado(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                              filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                              filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                              Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                              Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                              filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                              Date.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString),
                              idEstadoNuevo,
                              TipoEstadoPedido,
                              Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString),
                              Date.Now,
                              "Pedido Anulado",
                              Integer.Parse(filaPendiente("Orden").ToString),
                              filaPendiente("IdCriticidad").ToString(),
                              Date.Parse(filaPendiente("FechaEntrega").ToString), 0)
            'rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
            '                                                filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
            '                                                filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
            '                                                Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
            '                                                Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
            '                                                filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
            '                                                Integer.Parse(filaPendiente("Orden").ToString),
            '                                                idTipoEstadoAnterior2, idTipoEstadoNuevo,
            '                                                Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()))

            'rPE.RegistraMovimientoStock(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
            '                        filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
            '                        filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
            '                        Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
            '                        Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
            '                        filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
            '                        Integer.Parse(filaPendiente("Orden").ToString),
            '                        idEstadoAnterior, idEstadoNuevo, TipoEstadoPedido,
            '                        Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()),
            '                        Entidad.MetodoGrabacion.Automatico, idFuncion)

         Next


         'For Each filaPendiente As DataRow In dtAux.Rows
         ' Ver si elimina Ordenes Compras Pedidos
         AnulaPedidoGenerador(Integer.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).ToString),
                              filaAnula(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                              filaAnula(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                              Short.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                              Long.Parse(filaAnula(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()),
                              idFuncion,
                              sqlP, sqlPP, sqlPE, sqlPO, rPP, rPE)
      Next        'For Each filaAnula As DataRow In tablaAnular.Rows
   End Sub

#End Region

#Region "REPORTE"

   Public Function GetPedidosDetalladoXEstados(idSucursal As Integer,
                                               idEstado As String, dtpDesde As Date?, dtpHasta As Date?, dtpDesdeEntrega As Date?, dtpHastaEntrega As Date?,
                                               numeroPedido As Long,
                                               idProducto As String, idMarca As Integer, idRubro As Integer, lote As String,
                                               idProveedor As Long, idUsuario As String, idVendedor As Integer, ordenCompra As Long,
                                               tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante()) As DataTable
      Dim sql = New SqlServer.PedidosProveedores(da)
      Return sql.GetPedidosDetalladoXEstados(idSucursal,
                                             idEstado, dtpDesde, dtpHasta, dtpDesdeEntrega, dtpHastaEntrega,
                                             numeroPedido,
                                             idProducto, idMarca, idRubro, lote,
                                             idProveedor, idUsuario, idVendedor, ordenCompra,
                                             tipoTipoComprobante, tiposComprobante)
   End Function

   Public Function GetPedidosDetalladoXEstadosTodos(idSucursal As Integer, idEstado As String,
                                                    fechaDesde As Date, fechaHasta As Date, numeroPedido As Long,
                                                    idProducto As String, idMarca As Integer, idRubro As Integer, lote As String,
                                                    idProveedor As Long, idUsuario As String, tamanio As Decimal, idVendedor As Integer, ordenCompra As Long,
                                                    tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante()) As DataTable
      Dim sql = New SqlServer.PedidosProveedores(da)
      Return sql.GetPedidosDetalladoXEstadosTodos(idSucursal, idEstado,
                                                  fechaDesde, fechaHasta, numeroPedido,
                                                  idProducto, idMarca, idRubro, lote,
                                                  idProveedor, idUsuario, tamanio, idVendedor, ordenCompra,
                                                  tipoTipoComprobante, tiposComprobante)
   End Function

   Public Function GetOCDetalladoXEstadosTodos(idSucursal As Integer, idEstado As String,
                                               fechaDesde As Date, fechaHasta As Date, numeroPedido As Long,
                                               idProducto As String, idMarca As Integer, idRubro As Integer, lote As String,
                                               idProveedor As Long, idUsuario As String,
                                               tamanio As Decimal, idVendedor As Integer, ordenCompra As Long,
                                               tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante(),
                                               fechaDesdeEntrega As Date, fechaHastaEntrega As Date,
                                               importeMinimo As Decimal, importeMaximo As Decimal,
                                               fechaDesdeAutorizacion As Date, fechaHastaAutorizacion As Date) As DataTable
      Dim sql = New SqlServer.PedidosProveedores(da)
      Return sql.GetOCDetalladoXEstadosTodos(idSucursal, idEstado,
                                             fechaDesde, fechaHasta, numeroPedido,
                                             idProducto, idMarca, idRubro, lote,
                                             idProveedor, idUsuario,
                                             tamanio, idVendedor, ordenCompra,
                                             tipoTipoComprobante, tiposComprobante,
                                             fechaDesdeEntrega, fechaHastaEntrega,
                                             importeMinimo, importeMaximo,
                                             fechaDesdeAutorizacion, fechaHastaAutorizacion)
   End Function

   Public Function GetPedidosDetalleComprobante(idSucursal As Integer, idEstado As String,
                                                fechaDesde As Date, fechaHasta As Date, numeroPedido As Long,
                                                idProducto As String, idMarca As Integer, idRubro As Integer, lote As String,
                                                idProveedor As Long, idUsuario As String,
                                                tamanio As Decimal, idVendedor As Integer, ordenCompra As Long,
                                                tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante()) As DataTable
      Dim sql = New SqlServer.PedidosProveedores(da)
      Return sql.GetPedidosDetalleComprobante(idSucursal, idEstado,
                                              fechaDesde, fechaHasta, numeroPedido,
                                              idProducto, idMarca, idRubro, lote,
                                              idProveedor, idUsuario,
                                              tamanio, idVendedor, ordenCompra,
                                              tipoTipoComprobante, tiposComprobante)
   End Function

   Public Function GetPedidosDetalleComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long, idProveedor As Long) As DataTable
      Dim sql = New SqlServer.PedidosProveedores(da)
      Return sql.GetPedidosDetalleComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
   End Function
   Public Function GetPedidosxComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long, idProveedor As Long) As DataTable
      Dim sql = New SqlServer.PedidosProveedores(da)
      Return sql.GetPedidosxComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
   End Function

   Public Function pedidosCabecera(idSucursal As Integer, idEstado As String,
                                   dtpDesde As Date, dtpHasta As Date, numeroPedido As Long,
                                   idProducto As String, idMarca As Integer, idRubro As Integer, lote As String,
                                   idProveedor As Long, idUsuario As String,
                                   tamanio As Decimal, idVendedor As Integer, ordenCompra As Long,
                                   tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante(), letra As String, emisor As Short) As DataTable
      Dim sql = New SqlServer.PedidosProveedores(da)
      Return sql.pedidosCabecera(idSucursal, idEstado,
                                 dtpDesde, dtpHasta, numeroPedido,
                                 idProveedor, idUsuario,
                                 idVendedor, ordenCompra,
                                 tipoTipoComprobante, tiposComprobante, letra, emisor)
   End Function

   Public Function GetPedidosSumaPorProductos(idSucursal As Integer,
                                              IdEstado As String,
                                              dtpDesde As Date,
                                              dtpHasta As Date,
                                              IdProveedor As Long,
                                              IdVendedor As Integer,
                                              IdMarca As Integer,
                                              IdRubro As Integer,
                                              IdSubRubro As Integer,
                                              IdProducto As String,
                                              Tamanio As Decimal,
                                              OrdenCompra As Long,
                                              tipoTipoComprobante As String) As DataTable
      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.PedidosProveedores = New SqlServer.PedidosProveedores(da)
         Return sql.GetPedidosSumaPorProductos(idSucursal,
                                                IdEstado,
                                                dtpDesde, dtpHasta,
                                                IdProveedor,
                                                IdVendedor,
                                                IdMarca,
                                                IdRubro,
                                                IdSubRubro,
                                                IdProducto,
                                                Tamanio,
                                                OrdenCompra,
                                                tipoTipoComprobante)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try


   End Function

   Public Function GetPedidosParaGenerarPedidoProv(idSucursal As Integer, idProveedor As Long,
                                                   idMarca As Integer, idRubro As Integer, idSubRubro As Integer, idProducto As String,
                                                   ordenCompra As Long) As DataTable
      Return EjecutaConConexion(Function()
                                   Dim sql = New SqlServer.PedidosProveedores(da)
                                   Return sql.GetPedidosParaGenerarPedidoProv(idSucursal, idProveedor, idMarca, idRubro, idSubRubro, idProducto, ordenCompra)
                                End Function)
   End Function


#End Region

#Region "CrearComprobanteAutomatico"
   Public Overridable Function CrearPedidoProducto(
                        producto As Entidades.Producto,
                        productoDescripcion As String,
                        descuentoRecargoPorc1 As Decimal,
                        descuentoRecargoPorc2 As Decimal,
                        costo As Decimal?,
                        cantidad As Decimal,
                        tipoImpuesto As Entidades.TipoImpuesto,
                        porcentajeIva As Decimal?,
                        criticidad As Entidades.CriticidadPedido,
                        fechaEntrega As Date?,
                        cantidadUMCompra As Decimal?,
                        factorConversionCompra As Decimal?,
                        precioPorUMCompra As Decimal?,
                        pedido As Entidades.PedidoProveedor,
                        redondeoEnCalculo As Integer) As Entidades.PedidoProductoProveedor

      cantidad = Decimal.Round(cantidad, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnCantidad)

      Dim oPedidoProducto = New Entidades.PedidoProductoProveedor()
      Dim proSuc = New ProductosSucursales(da).GetUno(actual.Sucursal.IdSucursal, producto.IdProducto, Publicos.ListaPreciosPredeterminada)

      If Not factorConversionCompra.HasValue Then
         If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
            factorConversionCompra = producto.FactorConversionCompra
         Else
            factorConversionCompra = 1
         End If
      End If

      If Not cantidadUMCompra.HasValue Then
         If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
            cantidadUMCompra = cantidad * factorConversionCompra
         Else
            cantidadUMCompra = cantidad
         End If
      End If

      If Not porcentajeIva.HasValue Then
         porcentajeIva = producto.Alicuota
      End If

      Dim precioProducto As Decimal
      If costo.HasValue Then
         If Not pedido.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
            If pedido.TipoComprobante.GrabaLibro Or pedido.TipoComprobante.EsPreElectronico Then
               precioProducto = costo.Value - producto.ImporteImpuestoInterno
            Else
               precioProducto = costo.Value
            End If
         Else
            precioProducto = costo.Value
         End If
      Else
         Dim alicuota = porcentajeIva.Value

         Dim precioVentaSinIVA = proSuc.PrecioCosto
         Dim precioVentaConIVA = proSuc.PrecioCosto

         'Si se guardan con IVA se lo quito, evito muchas preguntas posteriores.
         If Reglas.Publicos.PreciosConIVA Then
            precioVentaSinIVA = Decimal.Round(precioVentaSinIVA / (1 + alicuota / 100), redondeoEnCalculo)
         Else
            precioVentaConIVA = Decimal.Round(precioVentaConIVA * (1 + alicuota / 100), redondeoEnCalculo)
         End If

         If producto.IdModelo = Entidades.Moneda.Dolar Then
            precioVentaSinIVA = Decimal.Round(precioVentaSinIVA * pedido.CotizacionDolar, redondeoEnCalculo)
            precioVentaConIVA = Decimal.Round(precioVentaConIVA * pedido.CotizacionDolar, redondeoEnCalculo)
         End If

         If (Not pedido.Proveedor.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado) And
              pedido.Proveedor.CategoriaFiscal.UtilizaImpuestos And _categoriaFiscalEmpresa.UtilizaImpuestos And
              pedido.TipoComprobante.UtilizaImpuestos Then
            precioProducto = precioVentaConIVA
         Else
            precioProducto = precioVentaSinIVA
         End If
      End If
      'Dim precioCosto = precioProducto

      Dim impuestoInternoTotalLinea = 0D ' producto.ImporteImpuestoInterno * cantidad
      'If Not pedido.Proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
      '   impuestoInternoTotalLinea = precioProducto - (((precioProducto - producto.ImporteImpuestoInterno) / (1 + (porcentajeIva.Value / 100) + (producto.PorcImpuestoInterno / 100))) * (1 * porcentajeIva.Value))
      '   impuestoInternoTotalLinea *= cantidad
      'Else
      '   impuestoInternoTotalLinea = (precioProducto * producto.PorcImpuestoInterno / 100) + producto.ImporteImpuestoInterno
      '   impuestoInternoTotalLinea *= cantidad
      'End If

      Dim descRec1 = Decimal.Round(precioProducto * descuentoRecargoPorc1 / 100, redondeoEnCalculo)
      Dim descRec2 = Decimal.Round((precioProducto + descRec1) * descuentoRecargoPorc2 / 100, redondeoEnCalculo)
      Dim descRecG = Decimal.Round((precioProducto + descRec1 + descRec2) * pedido.DescuentoRecargoPorc / 100, redondeoEnCalculo)

      Dim precioNeto = precioProducto + descRec1 + descRec2 + descRecG
      Dim importeIVA As Decimal

      If Not pedido.Proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         importeIVA = Decimal.Round(((precioNeto * cantidad) - impuestoInternoTotalLinea) - ((precioNeto * cantidad) - impuestoInternoTotalLinea) / (1 + porcentajeIva.Value / 100), redondeoEnCalculo)
      Else
         importeIVA = Decimal.Round((precioNeto * cantidad) * porcentajeIva.Value / 100, redondeoEnCalculo)
      End If

      If Not precioPorUMCompra.HasValue Then
         If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
            precioPorUMCompra = precioProducto / factorConversionCompra '* kilos
         End If
      End If

      If Not costo.HasValue Then
         'Se toma la lógica identica a la que se usa en la carga manual del Presupuesto
         If Not pedido.Proveedor.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Or
            Not pedido.TipoComprobante.UtilizaImpuestos Or Not pedido.Proveedor.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
            porcentajeIva = 0
         End If
      End If

      With oPedidoProducto
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Producto = producto
         .Proveedor = pedido.Proveedor
         If producto.PermiteModificarDescripcion Then
            .Producto.NombreProducto = productoDescripcion   'Piso la descripcion si tiene habilitado la posibilidad de cambiarlas.
         End If
         .DescuentoRecargoPorc = descuentoRecargoPorc1
         .DescuentoRecargoPorc2 = descuentoRecargoPorc2
         ''.DescuentoRecargo = descuentoRecargo
         .Cantidad = cantidad
         .ImporteImpuesto = importeIVA
         .AlicuotaImpuesto = porcentajeIva.Value
         .TipoImpuesto = tipoImpuesto

         .Stock = proSuc.Stock
         .Costo = precioProducto
         .CostoLista = proSuc.GetPrecioVentaDeLista(Publicos.ListaPreciosPredeterminada)
         .IdUnidadDeMedida = producto.UnidadDeMedida.IdUnidadDeMedida
         .IdUnidadDeMedidaCompra = producto.UnidadDeMedidaCompra.IdUnidadDeMedida
         .CantidadUMCompra = cantidadUMCompra.IfNull()
         .FactorConversionCompra = factorConversionCompra.IfNull()
         .PrecioPorUMCompra = precioPorUMCompra.IfNull()
         .CostoNeto = precioNeto
         .ImporteTotal = precioNeto * cantidad
         .ImporteTotalNeto = .CostoNeto * cantidad
         .IdCriticidad = criticidad.IdCriticidad
         If fechaEntrega.HasValue Then
            .FechaEntrega = fechaEntrega.Value
         End If
         .FechaActualizacion = Now
         .ImporteImpuestoInterno = impuestoInternoTotalLinea ' producto.ImporteImpuestoInterno * cantidad

      End With

      Return oPedidoProducto
   End Function

   Public Overridable Function CrearPedidoProducto(producto As Eniac.Entidades.Producto,
                                    productoDescripcion As String,
                                    descuentoRecargoPorc1 As Decimal,
                                    descuentoRecargoPorc2 As Decimal,
                                    precio As Decimal,
                                    cantidad As Decimal,
                                    tipoImpuesto As Eniac.Entidades.TipoImpuesto,
                                    porcentajeIva As Decimal?,
                                    idListaDePrecios As Integer,
                                    idCriticidad As String,
                                    fechaEntrega As Date?,
                                    pedido As Entidades.Pedido,
                                    redondeoEnCalculo As Integer,
                                    kilosModif As Decimal?,
                                    precioVentaPorTamano As Decimal,
                                    tamano As Decimal,
                                    idUnidadDeMedida As String,
                                    moneda As Entidades.Moneda,
                                    espmm As Decimal,
                                    espPulgadas As String,
                                    codigoSAE As Integer,
                                    produccionProceso As Entidades.ProduccionProceso,
                                    produccionForma As Entidades.ProduccionForma,
                                    largoExtAlto As Decimal,
                                    anchoIntBase As Decimal,
                                    urlPlano As String,
                                    idFormula As Integer) As Eniac.Entidades.PedidoProducto

      Dim blnAbreConeccion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      If blnAbreConeccion Then da.OpenConection()

      Try
         Dim lp As Entidades.ListaDePrecios = New Reglas.ListasDePrecios(da).GetUno(idListaDePrecios)
         Dim crt As Entidades.CriticidadPedido = New Reglas.PedidosCriticidades(da).GetUno(idCriticidad)

         Return CrearPedidoProducto(producto,
                                    productoDescripcion,
                                    descuentoRecargoPorc1,
                                    descuentoRecargoPorc2,
                                    precio,
                                    cantidad,
                                    tipoImpuesto,
                                    porcentajeIva,
                                    lp.IdListaPrecios,
                                    crt.IdCriticidad,
                                    fechaEntrega,
                                    pedido,
                                    redondeoEnCalculo,
                                    kilosModif,
                                    precioVentaPorTamano,
                                    tamano,
                                    idUnidadDeMedida,
                                    moneda,
                                    espmm,
                                    espPulgadas,
                                    codigoSAE,
                                    produccionProceso,
                                    produccionForma,
                                    largoExtAlto,
                                    anchoIntBase,
                                    urlPlano,
                                    idFormula)
      Finally
         If blnAbreConeccion Then da.CloseConection()
      End Try
   End Function

   Public Overridable Sub AgregarLinea(pedido As Entidades.PedidoProveedor, pedidoProducto As Entidades.PedidoProductoProveedor)
      Dim bruto = 0D
      Dim neto = 0D
      Dim iva = 0D
      Dim impint = 0D
      Dim total = 0D

      'Si el Estado de Visita no adminte lineas, no puedo agregar lineas al pedido.
      If Not pedido.EstadoVisita.AdmintePedidoConLineas Then
         Throw New Exception(String.Format("El estado de visita '{0}' del '{1} {2} {3:0000}-{4:00000000} no adminte lineas. Verifique el estado de visita indicado en el Pedido.'",
                                           pedido.NombreEstadoVisita, pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido))
      End If

      pedidoProducto.Orden = pedido.PedidosProductos.Count

      pedido.PedidosProductos.Add(pedidoProducto)

      For Each vp In pedido.PedidosProductos
         If Not pedido.Proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            bruto += Math.Round((vp.ImporteTotal / ((100 + vp.AlicuotaImpuesto) / 100)), 2)
            neto += Math.Round((vp.ImporteTotalNeto / ((100 + vp.AlicuotaImpuesto) / 100)), 2)
            iva += vp.ImporteImpuesto
            impint += vp.ImporteImpuestoInterno

            total += vp.ImporteTotalNeto
         Else
            bruto += vp.ImporteTotal
            neto += vp.ImporteTotalNeto
            iva += vp.ImporteImpuesto
            impint += vp.ImporteImpuestoInterno

            total += vp.ImporteTotalNeto + vp.ImporteImpuesto + vp.ImporteImpuestoInterno
         End If
      Next

      pedido.ImporteBruto = bruto
      pedido.DescuentoRecargo = neto - bruto
      pedido.SubTotal = neto
      pedido.TotalImpuestos = iva
      pedido.TotalImpuestoInterno = impint
      pedido.ImporteTotal = total
   End Sub

   'Public Overridable Sub AgregarContacto(pedido As Entidades.Pedido, contacto As Entidades.ClienteContacto)
   '   pedido.PedidosContactos.Add(New PedidoClienteContacto(contacto))
   'End Sub

   Public Overridable Sub AgregarObservacion(pedido As Entidades.PedidoProveedor, observacion As Entidades.PedidoObservacionProveedor)
      pedido.PedidosObservaciones.Add(observacion)
   End Sub

   Public Overridable Function CrearPedido(
                        proveedor As Entidades.Proveedor, tipoComprobante As Entidades.TipoComprobante, letra As String, centroEmisor As Short?, numeroComprobante As Long?,
                        fecha As Date, vendedor As Entidades.Empleado, transportista As Entidades.Transportista, formaPago As Entidades.VentaFormaPago, tipoComprobanteFact As Entidades.TipoComprobante,
                        observaciones As String, estadoVisita As Entidades.EstadoVisita, ordenCompra As Long) As Entidades.PedidoProveedor
      Return EjecutaConConexion(Function() _CrearPedido(
                        proveedor, tipoComprobante, letra, centroEmisor, numeroComprobante,
                        fecha, vendedor, transportista, formaPago, tipoComprobanteFact,
                        observaciones, estadoVisita, ordenCompra))
   End Function

   Public Overridable Function _CrearPedido(
                        proveedor As Entidades.Proveedor, tipoComprobante As Entidades.TipoComprobante, letra As String, centroEmisor As Short?, numeroComprobante As Long?,
                        fecha As Date, vendedor As Entidades.Empleado, transportista As Entidades.Transportista, formaPago As Entidades.VentaFormaPago, tipoComprobanteFact As Entidades.TipoComprobante,
                        observaciones As String, estadoVisita As Entidades.EstadoVisita, ordenCompra As Long) As Entidades.PedidoProveedor
      Dim oPedido = New Entidades.PedidoProveedor()
      With oPedido
         'cargo el comprobante
         .TipoComprobante = tipoComprobante

         'cargo el proveedor
         .Proveedor = proveedor
         'cargo la Categoria Fiscal
         .CategoriaFiscal = proveedor.CategoriaFiscal

         .Impresora = New Impresoras(da)._GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)

         If String.IsNullOrWhiteSpace(letra) Then
            If tipoComprobante.LetrasHabilitadas.Length = 1 Then
               .LetraComprobante = tipoComprobante.LetrasHabilitadas
            Else
               .LetraComprobante = .CategoriaFiscal.LetraFiscal
            End If
         Else
            .LetraComprobante = letra
         End If

         If centroEmisor.HasValue AndAlso centroEmisor.Value > 0 Then
            .CentroEmisor = centroEmisor.Value
         End If

         If numeroComprobante.HasValue Then
            .NumeroPedido = numeroComprobante.Value
         End If

         'cargo datos generales del comprobante
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre

         'Pudo levantar la pantalla y grabar despues. Vuelvo a asignarlo para que tome la hora.
         Dim fechaServidor = New Generales().GetServerDBFechaHora
         If fecha.Date = fechaServidor.Date Then
            fecha = fechaServidor
         End If
         .Fecha = fecha

         .NumeroOrdenCompra = ordenCompra

         .Comprador = vendedor

         .EstadoVisita = estadoVisita

         .Transportista = transportista
         .FormaPago = formaPago
         .TipoComprobanteFact = tipoComprobanteFact

         .Observacion = observaciones

         .CotizacionDolar = New Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion
      End With

      Return oPedido
   End Function
#End Region

   Public Function Dividir(origen As Eniac.Entidades.PedidoProveedor, destinos As List(Of Eniac.Entidades.PedidoProveedor)) As List(Of Eniac.Entidades.PedidoProveedor)
      Dim result As List(Of Eniac.Entidades.PedidoProveedor) = New List(Of Eniac.Entidades.PedidoProveedor)()
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      If blnAbreConexion Then da.OpenConection()
      Try
         If blnAbreConexion Then da.BeginTransaction()

         Dim regla As Eniac.Reglas.PedidosProveedores = New Eniac.Reglas.PedidosProveedores(da)
         Dim sql As SqlServer.PedidosProveedores = New SqlServer.PedidosProveedores(da)
         Dim sqlVP As Eniac.SqlServer.VentasProductos = New Eniac.SqlServer.VentasProductos(da)

         Borra(origen)
         'result.Add(Actualiza(origen))

         For Each destino As Eniac.Entidades.PedidoProveedor In destinos
            result.Add(Inserta(destino))
         Next

         If blnAbreConexion Then da.CommitTransaction()

      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return result
   End Function

   Public Sub ActualizarComprobantePorComprobante(vtaActual As Eniac.Entidades.Venta, vtaNueva As Eniac.Entidades.Venta)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then Me.da.OpenConection()

         Dim sqlC As SqlServer.Pedidos = New SqlServer.Pedidos(da)

         sqlC.ActualizarComprobantePorComprobante(vtaNueva.IdSucursal,
                                                  vtaActual.IdTipoComprobante, vtaActual.LetraComprobante, vtaActual.CentroEmisor, vtaActual.NumeroComprobante,
                                                  vtaNueva.IdTipoComprobante, vtaNueva.LetraComprobante, vtaNueva.CentroEmisor, vtaNueva.NumeroComprobante)

      Finally
         If blnAbreConexion Then Me.da.CloseConection()
      End Try
   End Sub

   Public Function GetPedidoOrigen(pedido As Entidades.PedidoProveedor) As Entidades.PedidoProveedor
      Dim sqlPE As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)
      Dim pedidoOrigen As Entidades.PedidoProveedor = Nothing

      Dim dt As DataTable = sqlPE.PedidosEstados_G_PorComprobanteGenerado(pedido.IdSucursal,
                                                                          pedido.IdTipoComprobante,
                                                                          pedido.LetraComprobante,
                                                                          pedido.CentroEmisor,
                                                                          pedido.NumeroPedido)

      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         pedidoOrigen = GetUno(Integer.Parse(dr(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                               dr(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                               dr(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                               Integer.Parse(dr(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                               Long.Parse(dr(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()))
      End If

      Return pedidoOrigen
   End Function

   Public Sub ValidaAnulacionPedido(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open

      Try
         If blnAbreConexion Then da.OpenConection()

         Dim lstEstadoPedido = New EstadosPedidos(da).GetPorTipoComprobanteGenerado(idTipoComprobante)
         Dim lstPedidoEstado = New PedidosEstados(da).GetTodosPorPedidoGenerado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)

         Dim estadoPedido As Entidades.EstadoPedido = Nothing
         Dim ultimoTipoEstadoPedido As String = String.Empty

         For Each pedidoEstado In lstPedidoEstado
            If pedidoEstado.TipoEstadoPedido <> ultimoTipoEstadoPedido Then
               For Each estped In lstEstadoPedido
                  If estped.TipoEstadoPedido = pedidoEstado.TipoEstadoPedido Then
                     estadoPedido = estped
                     Exit For
                  End If      'If estped.TipoEstadoPedido = pedidoEstado.TipoEstadoPedido Then
               Next           'For Each estped As EstadoPedido In lstEstadoPedido
               ultimoTipoEstadoPedido = pedidoEstado.TipoEstadoPedido
            End If            'If pedidoEstado.TipoEstadoPedido <> ultimoTipoEstadoPedido Then

            If pedidoEstado.IdEstado <> estadoPedido.IdEstado Then
               Throw New Exception(String.Format("La línea {4} con producto {5} del {0} {1} {2:0000}-{3:00000000} se encuentra en estado {6}. Debería estar en estado {7}. No se puede anular.",
                                                 pedidoEstado.IdTipoComprobante, pedidoEstado.Letra, pedidoEstado.CentroEmisor, pedidoEstado.CentroEmisor,
                                                 pedidoEstado.Orden, pedidoEstado.IdProducto,
                                                 pedidoEstado.IdEstado, estadoPedido.IdEstado))
            End If
         Next              'For Each pedidoEstado As PedidoEstado In lstPedidoEstaso
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Function CalculaTotalKilosItems(_ventasProductos As List(Of Entidades.PedidoProductoProveedor)) As Ventas.TotalKilosItems
      Dim result As Ventas.TotalKilosItems = New Ventas.TotalKilosItems()

      For Each vp In _ventasProductos
         result.TotalKilos += vp.CantidadUMCompra

         'Asumimos que:
         '     SI tiene decimales es un item que se vende por peso.
         '     NO tiene decimales es un item que se vende por unidad.
         'Posible problema:
         '     Un producto que se vende por peso pero el peso es redondo (sin decimales).
         '     Ejemplo: Una horma de 4kg de queso será contado como 4 productos, si fuera 4.01 será contado como 1 producto.
         If Decimal.ToInt32(vp.Cantidad) = vp.Cantidad Then
            result.TotalProductos += Decimal.ToInt32(vp.Cantidad)
         Else
            result.TotalProductos += 1
         End If

         result.TotalItems += 1
      Next

      Return result
   End Function

   Public Function OCCabecera(idSucursal As Integer, idEstado As String,
                              dtpDesde As Date, dtpHasta As Date, numeroPedido As Long, nroHasta As Long,
                              idProducto As String, idMarca As Integer, idRubro As Integer, lote As String,
                              idProveedor As Long, idUsuario As String, tamanio As Decimal, idVendedor As Integer, ordenCompra As Long,
                              tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante(), letra As String, emisor As Short,
                              fechaDesdeEntrega As Date, fechaHastaEntrega As Date,
                              importeMinimo As Decimal, importeMaximo As Decimal,
                              fechaDesdeAutorizacion As Date, fechaHastaAutorizacion As Date,
                              correoEnviado As String,
                              fechaDesdeEnvio As Date, fechaHastaEnvio As Date,
                              verReprogramadas As Boolean) As DataTable
      Dim sql = New SqlServer.PedidosProveedores(da)
      Return sql.OCCabecera(idSucursal, idEstado,
                            dtpDesde, dtpHasta, numeroPedido, nroHasta,
                            idProveedor, idUsuario, idVendedor, ordenCompra,
                            tipoTipoComprobante, tiposComprobante, letra, emisor,
                            fechaDesdeEntrega, fechaHastaEntrega,
                            importeMinimo, importeMaximo,
                            fechaDesdeAutorizacion, fechaHastaAutorizacion,
                            correoEnviado,
                            fechaDesdeEnvio, fechaHastaEnvio,
                            verReprogramadas)
   End Function
End Class