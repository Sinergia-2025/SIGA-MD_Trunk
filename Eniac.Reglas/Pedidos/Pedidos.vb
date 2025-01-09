Public Class Pedidos
   Inherits Base

#Region "Constructores"

   Public Sub New(idFuncion As String)
      Me.New()
      _idFuncion = idFuncion
   End Sub

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Pedidos"
      da = accesoDatos
      _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
      _convertirPedidoEnFacturaConservaPreciosPedido = Publicos.ConvertirPedidoEnFacturaConservaPreciosPedido
   End Sub

#End Region

   Private _categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal
   Private _convertirPedidoEnFacturaConservaPreciosPedido As Boolean
   Private _idFuncion As String

#Region "Overrides"

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.Pedido)))
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.Pedido)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.Pedido)))
   End Sub

#End Region

#Region "metodos privates"

   Private Function GetSQL() As SqlServer.Pedidos
      Return New SqlServer.Pedidos(da)
   End Function


   Public Function GetIdSiguiente(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Short) As Long
      Dim sql = GetSQL()
      Return (sql.Pedido_GetIdMaximo(idSucursal, idTipoComprobante, letraFiscal, emisor) + 1)
   End Function

   Private Function Actualiza(oPedido As Entidades.Pedido) As Entidades.Pedido
      VerificaPedidoModificable(oPedido)

      oPedido.NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)

      EjecutaSP(oPedido, TipoSP._U)

      Dim rPedProd = New PedidosProductos(da)
      rPedProd.ActualizaDetalleDesdePedido(oPedido, _idFuncion)

      Dim rPedCont = New PedidosClientesContactos(da)
      rPedCont.ActualizaContactosDesdePedido(oPedido)

      Dim rPedObs = New PedidosObservaciones(da)
      rPedObs.ActualizaObservacionesDesdePedido(oPedido)


      Return GetUno(oPedido.IdSucursal, oPedido.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor, oPedido.NumeroPedido, estadoPedido:=Nothing)
   End Function

   Private Function Actualiza_Vieja(oPedido As Entidades.Pedido) As Entidades.Pedido
      Dim pedidoResult As Entidades.Pedido
      VerificaPedidoModificable(oPedido)

      Dim sqlPE = New SqlServer.PedidosEstados(da)
      Dim rRepComp = New Reglas.RepartosComprobantes(da)

      Dim dtPresup = sqlPE.PedidosEstados_G_PorComprobanteGenerado(oPedido.IdSucursal,
                                                                   oPedido.IdTipoComprobante,
                                                                   oPedido.LetraComprobante,
                                                                   oPedido.CentroEmisor,
                                                                   oPedido.NumeroPedido)
      Dim dtRepComp = rRepComp.GetPorPedido(oPedido.IdSucursal,
                                            oPedido.IdTipoComprobante,
                                            oPedido.LetraComprobante,
                                            oPedido.CentroEmisor,
                                            oPedido.NumeroPedido)

      For Each drPresup As DataRow In dtPresup.Rows
         sqlPE.PedidosEstados_U_Ped(Integer.Parse(drPresup(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
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

      For Each drRepComp As DataRow In dtRepComp.Rows
         rRepComp.ActualizarPedido(drRepComp.ValorNumericoPorDefecto(Entidades.RepartoComprobante.Columnas.IdSucursal.ToString(), 0I),
                                   drRepComp.ValorNumericoPorDefecto(Entidades.RepartoComprobante.Columnas.IdReparto.ToString(), 0I),
                                   drRepComp.ValorNumericoPorDefecto(Entidades.RepartoComprobante.Columnas.Orden.ToString(), 0I),
                                   idTipoComprobantePedido:=String.Empty, letraPedido:=String.Empty, centroEmisorPedido:=0, numeroPedido:=0)
      Next

      Borra(oPedido)
      pedidoResult = Inserta(oPedido)

      For Each drRepComp As DataRow In dtRepComp.Rows
         rRepComp.ActualizarPedido(drRepComp.ValorNumericoPorDefecto(Entidades.RepartoComprobante.Columnas.IdSucursal.ToString(), 0I),
                                   drRepComp.ValorNumericoPorDefecto(Entidades.RepartoComprobante.Columnas.IdReparto.ToString(), 0I),
                                   drRepComp.ValorNumericoPorDefecto(Entidades.RepartoComprobante.Columnas.Orden.ToString(), 0I),
                                   drRepComp(Entidades.RepartoComprobante.Columnas.IdTipoComprobantePedido.ToString()).ToString(),
                                   drRepComp(Entidades.RepartoComprobante.Columnas.LetraPedido.ToString()).ToString(),
                                   drRepComp.ValorNumericoPorDefecto(Entidades.RepartoComprobante.Columnas.CentroEmisorPedido.ToString(), 0S),
                                   drRepComp.ValorNumericoPorDefecto(Entidades.RepartoComprobante.Columnas.NumeroPedido.ToString(), 0L))
      Next

      For Each drPresup As DataRow In dtPresup.Rows
         sqlPE.PedidosEstados_U_Ped(Integer.Parse(drPresup(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
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

      Return pedidoResult
   End Function

   Private Sub Borra(oPedido As Entidades.Pedido)
      EjecutaSP(oPedido, TipoSP._D)
   End Sub

   Public Function Inserta(oPedidos As Entidades.Pedido) As Entidades.Pedido
      'Si el Estado de Visita no adminte lineas y el pedido viene con lineas, no puedo guardar el pedido.
      If Not oPedidos.EstadoVisita.AdmintePedidoConLineas And oPedidos.PedidosProductos.Count > 0 Then
         Throw New Exception(String.Format("El estado de visita '{0}' del '{1} {2} {3:0000}-{4:00000000}' no adminte lineas. Verifique el estado de visita indicado en el Pedido.'",
                                           oPedidos.NombreEstadoVisita, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido))
      End If

      'Si el Estado de Visita no adminte sin lineas y el pedido viene sin lineas, no puedo guardar el pedido.
      If Not oPedidos.EstadoVisita.AdmitePedidoSinLineas And oPedidos.PedidosProductos.Count = 0 Then
         Throw New Exception(String.Format("El estado de visita '{0}' del '{1} {2} {3:0000}-{4:00000000}' requiere al menos una linea. Verifique el estado de visita indicado en el Pedido.'",
                                           oPedidos.NombreEstadoVisita, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido))
      End If

      If oPedidos.NumeroPedido > 0 Then
         'SPC: PEDIDOS - PENDIENTE DEFINIR SI EXISTE
         'If Me.Existe(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, _
         '               oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor, _
         '               oVentas.NumeroComprobante) Then
         '   Throw New Exception("El Numero de Comprobante " & oVentas.NumeroComprobante.ToString() & " YA Existe.")
         'End If
      End If

      If oPedidos.CentroEmisor = 0 Then
         oPedidos.CentroEmisor = oPedidos.Impresora.CentroEmisor
      End If

      Dim oVentasNumeros As Reglas.VentasNumeros = New Reglas.VentasNumeros(da)
      Dim sucursal As Entidades.Sucursal = New Reglas.Sucursales(da).GetUna(oPedidos.IdSucursal, False)
      Dim NumeroComprob As Long = oVentasNumeros.GetProximoNumero(sucursal, oPedidos.IdTipoComprobante,
                                                                  oPedidos.LetraComprobante, oPedidos.CentroEmisor)
      'Tiene que ser NO fiscal y NO haberlo digitado en la pantalla.
      If oPedidos.NumeroPedido = 0 Then
         oPedidos.NumeroPedido = Math.Max(NumeroComprob, GetIdSiguiente(oPedidos.IdSucursal, oPedidos.IdTipoComprobante,
                                                                        oPedidos.LetraComprobante, oPedidos.CentroEmisor))
      Else
         If ExistePedido(oPedidos.IdSucursal, oPedidos.IdTipoComprobante, oPedidos.NumeroPedido) Then
            oPedidos.NumeroPedido = NumeroComprob
         End If
      End If

      'actualizo el numero de venta en las tablas solo si el numero se calculo
      If oPedidos.NumeroPedido >= NumeroComprob Then
         Dim rVta As Ventas = New Ventas(da)
         rVta.ActualizarNumerosVentas(oPedidos.IdSucursal, oPedidos.IdTipoComprobante,
                                      oPedidos.LetraComprobante, oPedidos.CentroEmisor,
                                      oPedidos.NumeroPedido, oPedidos.Fecha)
      End If

      oPedidos.NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)

      EjecutaSP(oPedidos, TipoSP._I)

      'Grabo el detalle de OrdenesComprasPedidos
      If oPedidos.NumeroOrdenCompra <> 0 And Publicos.UtilizaOrdenCompraPedidos Then
         Dim rOrdenesComprasPedidos As Reglas.OrdenesCompraPedidos = New Reglas.OrdenesCompraPedidos(da)
         rOrdenesComprasPedidos.Insertar(oPedidos)
      End If

      Dim rPedProd As PedidosProductos = New PedidosProductos(da)
      rPedProd.InsertaDetalleDesdePedido(oPedidos)

      Dim rPedCont As PedidosClientesContactos = New PedidosClientesContactos(da)
      rPedCont.InsertaContactosDesdePedido(oPedidos)

      Dim rPedObs As PedidosObservaciones = New PedidosObservaciones(da)
      rPedObs.InsertaObservacionesDesdePedido(oPedidos)

      Return oPedidos
   End Function

   Public Sub EjecutaSP(oPedidos As Entidades.Pedido, tipo As TipoSP)
      Dim sql = GetSQL()

      Select Case tipo

         Case TipoSP._I
            sql.Pedidos_I(oPedidos.IdSucursal,
                          oPedidos.IdTipoComprobante,
                          oPedidos.LetraComprobante,
                          oPedidos.CentroEmisor,
                          oPedidos.NumeroPedido,
                          oPedidos.Fecha,
                          oPedidos.Observacion,
                          actual.Nombre,
                          oPedidos.DescuentoRecargo,
                          oPedidos.DescuentoRecargoPorc,
                          oPedidos.Cliente.IdCliente,
                          oPedidos.IdEmpleado,
                          oPedidos.IdCaja,
                          oPedidos.IdFormaPago,
                          oPedidos.IdTransportista,
                          oPedidos.CotizacionDolar,
                          oPedidos.IdTipoComprobanteFact,
                          oPedidos.ImporteBruto,
                          oPedidos.SubTotal,
                          oPedidos.TotalImpuestos,
                          oPedidos.TotalImpuestoInterno,
                          oPedidos.ImporteTotal,
                          oPedidos.IdEstadoVisita,
                          oPedidos.NumeroOrdenCompra,
                          oPedidos.Kilos,
                          oPedidos.ObservacionInterna,
                          oPedidos.IdMoneda,
                          oPedidos.IdClienteVinculado,
                          oPedidos.Palets,
                          oPedidos.NroVersionAplicacion,
                          oPedidos.NroVersionRemoto,
                          oPedidos.IdPedidoTiendaNube,
                          oPedidos.IdPedidoMercadoLibre,
                          oPedidos.IdLocalidad,
                          oPedidos.Direccion,
                          oPedidos.Cuit,
                          oPedidos.TipoDocCliente,
                          oPedidos.NroDocCliente,
                          oPedidos.NombreClienteGenerico,
                          oPedidos.SaldoActualCtaCte,
                          oPedidos.IdPlazoEntrega,
                          oPedidos.ValidezPresupuesto, oPedidos.IdDomicilio,
                          Date.Now, actual.Nombre)    'Estos valores no los debo tomar de la entidad. Los tomo en cada INSERT/UPDATE del sistema

         Case TipoSP._U
            Using dt = Get1(oPedidos.IdSucursal, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido)
               If dt.Count = 0 Then
                  Throw New Exception(String.Format("No existe {0}/{1} {2} {3:0000}-{4:00000000}. No es posible actualizar.",
                                                    oPedidos.IdSucursal, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido))
               End If
               Dim fechaActualizacionDB = dt.First().Field(Of Date)(Entidades.Pedido.Columnas.FechaActualizacion.ToString())
               If fechaActualizacionDB <> oPedidos.FechaActualizacion Then
                  Dim idUsuarioActualizacionDB = dt.First().Field(Of String)(Entidades.Pedido.Columnas.IdUsuarioActualizacion.ToString())

                  Throw New Exception(String.Format("El {1} {2} {3:0000}-{4:00000000} fue modificado {5:dd/MM/yyyy HH:mm:ss} por {6}. No es posible actualizar.",
                                                    oPedidos.IdSucursal, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido,
                                                    fechaActualizacionDB, idUsuarioActualizacionDB))
               End If
            End Using

            sql.Pedidos_U(oPedidos.IdSucursal,
                          oPedidos.IdTipoComprobante,
                          oPedidos.LetraComprobante,
                          oPedidos.CentroEmisor,
                          oPedidos.NumeroPedido,
                          oPedidos.Fecha,
                          oPedidos.Observacion,
                          actual.Nombre,
                          oPedidos.DescuentoRecargo,
                          oPedidos.DescuentoRecargoPorc,
                          oPedidos.Cliente.IdCliente,
                          oPedidos.IdEmpleado,
                          oPedidos.IdCaja,
                          oPedidos.IdFormaPago,
                          oPedidos.IdTransportista,
                          oPedidos.CotizacionDolar,
                          oPedidos.IdTipoComprobanteFact,
                          oPedidos.ImporteBruto,
                          oPedidos.SubTotal,
                          oPedidos.TotalImpuestos,
                          oPedidos.TotalImpuestoInterno,
                          oPedidos.ImporteTotal,
                          oPedidos.IdEstadoVisita,
                          oPedidos.NumeroOrdenCompra,
                          oPedidos.Kilos,
                          oPedidos.ObservacionInterna,
                          oPedidos.IdMoneda,
                          oPedidos.IdClienteVinculado,
                          oPedidos.Palets,
                          oPedidos.NroVersionAplicacion,
                          oPedidos.NroVersionRemoto,
                          oPedidos.IdPedidoTiendaNube,
                          oPedidos.IdPedidoMercadoLibre,
                          oPedidos.IdLocalidad,
                          oPedidos.Direccion,
                          oPedidos.Cuit,
                          oPedidos.TipoDocCliente,
                          oPedidos.NroDocCliente,
                          oPedidos.NombreClienteGenerico,
                          oPedidos.SaldoActualCtaCte,
                          oPedidos.IdPlazoEntrega,
                          oPedidos.ValidezPresupuesto,
                          Date.Now, actual.Nombre)    'Estos valores no los debo tomar de la entidad. Los tomo en cada INSERT/UPDATE del sistema

         Case TipoSP._D
            'Borro Pedidos Observaciones
            Dim sqlPO As SqlServer.PedidosObservaciones = New SqlServer.PedidosObservaciones(da)
            sqlPO.PedidosObservaciones_D(oPedidos.IdSucursal, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido, 0)

            'Borro Pedidos Contactos
            Dim sqlPCC As SqlServer.PedidosClientesContactos = New SqlServer.PedidosClientesContactos(da)
            sqlPCC.PedidosClientesContactos_D(oPedidos.IdSucursal, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido)

            'Borro Pedidos Estados
            Dim sqlPE As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)
            sqlPE.PedidosEstados_D(oPedidos.IdSucursal, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido, Nothing, String.Empty, Nothing)

            'Borro Pedidos Productos Formulas
            Dim sqlPPF As SqlServer.PedidosProductosFormulas = New SqlServer.PedidosProductosFormulas(da)
            sqlPPF.PedidosProductosFormulas_D(oPedidos.IdSucursal, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido, String.Empty, Nothing, String.Empty, String.Empty, String.Empty, String.Empty, 0, 0)

            'Borro Pedidos Productos
            Dim sqlPP As SqlServer.PedidosProductos = New SqlServer.PedidosProductos(da)
            sqlPP.PedidosProductos_D(oPedidos.IdSucursal, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido, Nothing, String.Empty)

            'Borro Pedidos
            sql.Pedidos_D(oPedidos.IdSucursal, oPedidos.IdTipoComprobante, oPedidos.LetraComprobante, oPedidos.CentroEmisor, oPedidos.NumeroPedido)
      End Select

   End Sub


   Private Sub CargarUno(o As Entidades.Pedido, dr As DataRow, estadoPedido As String)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString())
         .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString())
         .LetraComprobante = dr(Entidades.Pedido.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString())
         .Fecha = Date.Parse(dr(Entidades.Pedido.Columnas.FechaPedido.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Pedido.Columnas.IdTipoComprobanteFact.ToString()).ToString()) Then
            .TipoComprobanteFact = New Reglas.TiposComprobantes(da).GetUno(dr(Entidades.Pedido.Columnas.IdTipoComprobanteFact.ToString()).ToString())
         End If

         .Cliente = New Reglas.Clientes(da)._GetUno(Long.Parse(dr(Entidades.Pedido.Columnas.IdCliente.ToString()).ToString()))

         .CategoriaFiscal = .Cliente.CategoriaFiscal

         '>>>> Manejo para determinar la categoria fiscal del pedido segun el tipo de comprobante
         Dim tipoComprobanteFact As Entidades.TipoComprobante = .TipoComprobanteFact
         If tipoComprobanteFact Is Nothing Then
            tipoComprobanteFact = .TipoComprobante
         End If

         If tipoComprobanteFact IsNot Nothing AndAlso
            Publicos.Facturacion.FacturacionGrabaLibroNoFuerzaConsFinal And
            Not tipoComprobanteFact.GrabaLibro And Not tipoComprobanteFact.EsPreElectronico Then
            .CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(1S)
         End If
         '<<<<Manejo para determinar la categoria fiscal del pedido segun el tipo de comprobante

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Pedido.Columnas.IdVendedor.ToString()).ToString()) Then
            .Vendedor = New Reglas.Empleados(da).GetUno(Integer.Parse(dr(Entidades.Pedido.Columnas.IdVendedor.ToString()).ToString()))
         End If

         '-- REG-30529.- --
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Pedido.Columnas.IdCaja.ToString()).ToString()) Then
            '-- Asigna Caja.- --
            .Caja = New Reglas.CajasNombres(da).GetUna(actual.Sucursal.IdSucursal, Integer.Parse(dr(Entidades.Pedido.Columnas.IdCaja.ToString()).ToString()))
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Pedido.Columnas.IdTransportista.ToString()).ToString()) Then
            .Transportista = New Reglas.Transportistas(da).GetUno(Long.Parse(dr(Entidades.Pedido.Columnas.IdTransportista.ToString()).ToString()))
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Pedido.Columnas.IdFormasPago.ToString()).ToString()) Then
            .FormaPago = New Reglas.VentasFormasPago(da).GetUna(Integer.Parse(dr(Entidades.Pedido.Columnas.IdFormasPago.ToString()).ToString()))
         End If

         .DescuentoRecargo = Decimal.Parse(dr(Entidades.Pedido.Columnas.DescuentoRecargo.ToString()).ToString())
         .DescuentoRecargoPorc = Decimal.Parse(dr(Entidades.Pedido.Columnas.DescuentoRecargoPorc.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Pedido.Columnas.CotizacionDolar.ToString()).ToString()) Then
            .CotizacionDolar = Decimal.Parse(dr(Entidades.Pedido.Columnas.CotizacionDolar.ToString()).ToString())
         End If

         .Observacion = dr(Entidades.Pedido.Columnas.Observacion.ToString()).ToString()

         .IdUsuario = dr(Entidades.Pedido.Columnas.IdUsuario.ToString()).ToString()

         .PedidosProductos = New PedidosProductos(da).GetTodos(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroPedido, estadoPedido)

         If Not .CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
            For Each vp As Entidades.PedidoProducto In .PedidosProductos

               vp.Precio = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), 2)
               vp.Costo = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Costo, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), 2)
               vp.PrecioLista = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.PrecioLista, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), 2)
               vp.PrecioNeto = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.PrecioNeto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), 2)
               vp.ImporteTotal = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.ImporteTotal, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), 2)
               vp.ImporteTotalNeto = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.ImporteTotalNeto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), 2)
               vp.DescuentoRecargoProducto = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescuentoRecargoProducto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), 2)

               'vp.Precio = Math.Round(vp.Precio * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
               'vp.Costo = Math.Round(vp.Costo * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
               'vp.PrecioLista = Math.Round(vp.PrecioLista * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
               'vp.PrecioNeto = Math.Round(vp.PrecioNeto * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
               'vp.ImporteTotal = Math.Round(vp.ImporteTotal * (1 + (vp.AlicuotaImpuesto / 100)) + vp.ImporteImpuestoInterno, 2)
               'vp.ImporteTotalNeto = Math.Round(vp.ImporteTotalNeto * (1 + (vp.AlicuotaImpuesto / 100)) + vp.ImporteImpuestoInterno, 2)
               'vp.DescuentoRecargoProducto = vp.DescuentoRecargoProducto * (1 + (vp.AlicuotaImpuesto / 100))
            Next
         End If

         .ImporteBruto = Decimal.Parse(dr(Entidades.Pedido.Columnas.ImporteBruto.ToString()).ToString())
         .SubTotal = Decimal.Parse(dr(Entidades.Pedido.Columnas.SubTotal.ToString()).ToString())
         .TotalImpuestos = Decimal.Parse(dr(Entidades.Pedido.Columnas.TotalImpuestos.ToString()).ToString())
         .TotalImpuestoInterno = Decimal.Parse(dr(Entidades.Pedido.Columnas.TotalImpuestoInterno.ToString()).ToString())
         .ImporteTotal = Decimal.Parse(dr(Entidades.Pedido.Columnas.ImporteTotal.ToString()).ToString())

         .EstadoVisita = New EstadosVisitas(da).GetUno(Integer.Parse(dr(Entidades.Pedido.Columnas.IdEstadoVisita.ToString()).ToString()))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Pedido.Columnas.NumeroOrdenCompra.ToString()).ToString()) Then
            .NumeroOrdenCompra = Long.Parse(dr(Entidades.Pedido.Columnas.NumeroOrdenCompra.ToString()).ToString())
         End If
         .Kilos = Decimal.Parse(dr(Entidades.Pedido.Columnas.Kilos.ToString()).ToString())

         Dim totalKilosItems As Reglas.Ventas.TotalKilosItems = CalculaTotalKilosItems(.PedidosProductos)
         .CantidadProductos = totalKilosItems.TotalProductos

         .PedidosObservaciones = New Reglas.PedidosObservaciones(da).GetTodos(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroPedido)
         .PedidosContactos = New Reglas.PedidosClientesContactos(da).GetTodos(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroPedido)

         .ObservacionInterna = dr(Entidades.Pedido.Columnas.ObservacionInterna.ToString()).ToString()

         .IdMoneda = Integer.Parse(dr(Entidades.Pedido.Columnas.IdMoneda.ToString()).ToString())
         If IsNumeric(dr(Entidades.Pedido.Columnas.IdClienteVinculado.ToString())) Then
            .ClienteVinculado = New Reglas.Clientes(da)._GetUno(Long.Parse(dr(Entidades.Pedido.Columnas.IdClienteVinculado.ToString()).ToString()))
         End If

         .Palets = Integer.Parse(dr(Entidades.Pedido.Columnas.Palets.ToString()).ToString())
         .NroVersionAplicacion = dr(Entidades.Pedido.Columnas.NroVersionAplicacion.ToString()).ToString()
         .NroVersionRemoto = dr(Entidades.Pedido.Columnas.NroVersionRemoto.ToString()).ToString()
         .IdPedidoTiendaNube = dr.Field(Of String)(Entidades.Pedido.Columnas.IdPedidoTiendaNube.ToString())
         .IdPedidoMercadoLibre = dr.Field(Of String)(Entidades.Pedido.Columnas.IdPedidoMercadoLibre.ToString())
         .IdLocalidad = dr.Field(Of Integer?)(Entidades.Pedido.Columnas.IdLocalidad.ToString())
         .Direccion = dr.Field(Of String)(Entidades.Pedido.Columnas.Direccion.ToString())
         .Cuit = dr.Field(Of String)(Entidades.Pedido.Columnas.Cuit.ToString())
         .TipoDocCliente = dr.Field(Of String)(Entidades.Pedido.Columnas.TipoDocCliente.ToString())
         .NroDocCliente = dr.Field(Of Long?)(Entidades.Pedido.Columnas.NroDocCliente.ToString())
         .NombreClienteGenerico = dr.Field(Of String)("NombreClienteGenerico")
         If IsNumeric(dr(Entidades.Pedido.Columnas.SaldoActualCtaCte.ToString())) Then
            .SaldoActualCtaCte = Decimal.Parse(dr(Entidades.Pedido.Columnas.SaldoActualCtaCte.ToString()).ToString())
         End If

         .IdPlazoEntrega = Integer.Parse(dr(Entidades.Pedido.Columnas.IdPlazoEntrega.ToString()).ToString())
         .ValidezPresupuesto = Integer.Parse(dr(Entidades.Pedido.Columnas.ValidezPresupuesto.ToString()).ToString())

         .IdDomicilio = dr.Field(Of Integer?)(Entidades.Pedido.Columnas.IdDomicilio.ToString())

         .FechaActualizacion = dr.Field(Of Date)(Entidades.Pedido.Columnas.FechaActualizacion.ToString())
         .IdUsuarioActualizacion = dr.Field(Of String)(Entidades.Pedido.Columnas.IdUsuarioActualizacion.ToString())

      End With
   End Sub

#End Region

#Region "metodos publicos"
   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As DataTable
      Return GetSQL().Pedidos_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, estadoPedido As String) As Entidades.Pedido
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, estadoPedido, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, estadoPedido As String, accion As AccionesSiNoExisteRegistro) As Entidades.Pedido
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido),
                          Sub(o, dr) CargarUno(o, dr, estadoPedido), Function() New Entidades.Pedido(),
                          accion, Function() String.Format("No existe el Pedido {0} {1} {2} {3:0000}-{4:00000000}.",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido))
   End Function

   <Obsolete("No se utiliza más. incorpora GetUno con EstadoPedido para Invocacion Masiva")>
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As Entidades.Pedido
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, estadoPedido:=Nothing)
   End Function

   <Obsolete("No se debe estar usando en ningún lado")>
   Public Overrides Function GetAll() As System.Data.DataTable
      Throw New NotImplementedException("Reglas.Pedidos.GetAll(): No se debe usar en ningún lado")
      'Dim sql As SqlServer.EstadosPedidos = New SqlServer.EstadosPedidos(da)
      'Return sql.EstadosPedidos_GA(False)
   End Function

   Public Sub AnularPedidos(tablaAnular As DataTable, tipoEstadoPedido As String, idFuncion As String)
      EjecutaConTransaccion(
      Sub()
         Dim rPP = New PedidosProductos(da)
         Dim rPE = New PedidosEstados(da)
         Dim sqlPE = New SqlServer.PedidosEstados(da)
         Dim sqlPP = New SqlServer.PedidosProductos(da)
         Dim sqlP = GetSQL()
         Dim sqlPO = New SqlServer.PedidosObservaciones(da)
         Dim sqlPCC = New SqlServer.PedidosClientesContactos(da)

         'Dim idEstadoAnterior As String
         Dim idTipoEstadoAnterior = Entidades.EstadoPedido.TipoEstado.PENDIENTE ' SOLO SE PERMITE ANULAR PEDIDOS CON TIPO ESTADO 'PENDIENTE', SI ESTÁ EN 'EN PROCESO' DEBE CAMBIARSE DE ESTADO POR EL ADMIN Y LUEGO ANULARSE.
         Dim idEstadoNuevo = Entidades.EstadoPedido.ESTADO_ANULADO '' "ANULADO"
         Dim idTipoEstadoNuevo = New EstadosPedidos(da).GetUno(idEstadoNuevo, tipoEstadoPedido).IdTipoEstado

         Dim fechaNuevoEstado = Date.Now

         For Each filaAnula As DataRow In tablaAnular.Rows
            Dim dtAux = sqlPE.PedidosEstados_GA(Integer.Parse(filaAnula(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString),
                                                filaAnula(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                filaAnula(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                Integer.Parse(filaAnula(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                Long.Parse(filaAnula(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                idTipoEstadoAnterior)
            For Each filaPendiente As DataRow In dtAux.Rows
               Dim idEstadoAnterior = filaPendiente("IdEstado").ToString()
               sqlPE.PedidosEstados_U_Estado(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                                             filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                                             filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                                             Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                                             Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                                             filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                                             Date.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString),
                                             idEstadoNuevo,
                                             tipoEstadoPedido,
                                             Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString),
                                             fechaNuevoEstado,
                                             "Pedido Anulado",
                                             Integer.Parse(filaPendiente("Orden").ToString),
                                             filaPendiente("IdCriticidad").ToString(),
                                             Date.Parse(filaPendiente("FechaEntrega").ToString),
                                             numeroReparto:=0, anulacionPorModificacion:=False)
               rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                                                               filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                               filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                                                               Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                                                               Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                                                               filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                                                               Integer.Parse(filaPendiente("Orden").ToString),
                                                               idTipoEstadoAnterior, idTipoEstadoNuevo,
                                                               Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()))

               rPE.ReservaProducto(Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.IdSucursal.ToString()).ToString()),
                                   filaPendiente(Entidades.PedidoEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                                   filaPendiente(Entidades.PedidoEstado.Columnas.Letra.ToString()).ToString(),
                                   Integer.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CentroEmisor.ToString()).ToString()),
                                   Long.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                                   filaPendiente(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                                   Integer.Parse(filaPendiente("Orden").ToString),
                                   idEstadoAnterior, idEstadoNuevo, tipoEstadoPedido,
                                   Decimal.Parse(filaPendiente(Entidades.PedidoEstado.Columnas.CantEstado.ToString()).ToString()),
                                   Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, 0, 0,
                                   filaPendiente.Field(Of Integer?)(Entidades.PedidoEstado.Columnas.IdDepositoAnterior.ToString()).IfNull(),
                                   filaPendiente.Field(Of Integer?)(Entidades.PedidoEstado.Columnas.IdUbicacionAnterior.ToString()).IfNull())
               fechaNuevoEstado = fechaNuevoEstado.AddSeconds(1)

            Next     'For Each filaPendiente As DataRow In dtAux.Rows
            ' Ver si elimina Ordenes Compras Pedidos
            AnulaPedidoGenerador(Integer.Parse(filaAnula(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString),
                                 filaAnula(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                 filaAnula(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                 Short.Parse(filaAnula(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                 Long.Parse(filaAnula(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                 idFuncion,
                                 sqlP, sqlPP, sqlPE, sqlPO, sqlPCC, rPP, rPE)
         Next        'For Each filaAnula As DataRow In tablaAnular.Rows
      End Sub)
   End Sub

   Public Sub EliminarPedidos(tablaAnular As DataTable, TipoEstadoPedido As String, idFuncion As String)
      EjecutaConTransaccion(
         Sub()
            For Each filaAnula As DataRow In tablaAnular.Rows
               Dim pedido As Entidades.Pedido
               pedido = GetUno(Integer.Parse(filaAnula(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString),
                            filaAnula(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                            filaAnula(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                            Integer.Parse(filaAnula(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                            Long.Parse(filaAnula(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                            estadoPedido:=Nothing)
               If pedido.PedidosProductos.Any(Function(pp) pp.PedidosEstados.Any(Function(pe) pe.IdEstado <> Entidades.EstadoPedido.ESTADO_ANULADO)) Then
                  Throw New Exception(String.Format("No es posible eliminar el pedido {0} {1} {2:0000}:{3:00000000} porque alguna línea está en estado diferente a {4}",
                                                    pedido.TipoComprobante.Descripcion, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido,
                                                    Entidades.EstadoPedido.ESTADO_ANULADO))
               End If
               Borra(pedido)
            Next

         End Sub)
   End Sub

   Public Sub RenumerarPedidos(drPedidosCol As DataRow(), nuevoNumeroPedido As Long, tipoEstadoPedido As String, idFuncion As String)
      EjecutaConTransaccion(Sub() _RenumerarPedidos(drPedidosCol, nuevoNumeroPedido, tipoEstadoPedido, idFuncion))
   End Sub
   Private Sub _RenumerarPedidos(drPedidosCol As DataRow(), nuevoNumeroPedido As Long, tipoEstadoPedido As String, idFuncion As String)
      Dim sql = GetSQL()

      Dim camposCambio = New Dictionary(Of String, String)() From {{Entidades.Pedido.Columnas.NumeroPedido.ToString(), nuevoNumeroPedido.ToString()}}
      Dim whereClausePedido As String
      For Each drPedido As DataRow In drPedidosCol
         whereClausePedido = String.Format(" WHERE {0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                              Entidades.Pedido.Columnas.IdSucursal.ToString(), drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString(),
                                              Entidades.Pedido.Columnas.IdTipoComprobante.ToString(), drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                              Entidades.Pedido.Columnas.Letra.ToString(), drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                              Entidades.Pedido.Columnas.CentroEmisor.ToString(), drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString(),
                                              Entidades.Pedido.Columnas.NumeroPedido.ToString(), drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString())

         sql.InsertSelect("Pedidos", camposCambio, whereClausePedido)
         sql.InsertSelect("PedidosProductos", camposCambio, whereClausePedido)

         sql.UpdatePrimaryKey("PedidosEstados", camposCambio, whereClausePedido)
         sql.UpdatePrimaryKey("PedidosProductosFormulas", camposCambio, whereClausePedido)
         sql.UpdatePrimaryKey("PedidosClientesContactos", camposCambio, whereClausePedido)
         sql.UpdatePrimaryKey("PedidosObservaciones", camposCambio, whereClausePedido)

         Try
            Dim whereClausePedidoRC = String.Format(" WHERE {0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                                    "IdSucursal", drPedido(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString(),
                                                    "IdTipoComprobantePedido", drPedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                    "LetraPedido", drPedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                    "CentroEmisorPedido", drPedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString(),
                                                    "NumeroPedido", drPedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString())
            sql.UpdatePrimaryKey("RepartosComprobantes", camposCambio, whereClausePedidoRC)
         Catch ex As SqlClient.SqlException

         End Try

         sql.DeleteGenerico("PedidosProductos", camposCambio, whereClausePedido)
         sql.DeleteGenerico("Pedidos", camposCambio, whereClausePedido)
      Next
   End Sub

   Private Sub AnulaPedidoGenerador(idSucursal As Integer, idTipoComprobante As String, letra As String,
                                    centroEmisor As Short, numeroPedido As Long,
                                    idFuncion As String,
                                    sqlP As SqlServer.Pedidos, sqlPP As SqlServer.PedidosProductos, sqlPE As SqlServer.PedidosEstados,
                                    sqlPO As SqlServer.PedidosObservaciones,
                                    sqlPCC As SqlServer.PedidosClientesContactos,
                                    rPP As Reglas.PedidosProductos, rPE As Reglas.PedidosEstados)
      Dim lstPedidoEstado = rPE.GetTodosPorPedidoGenerado(idSucursal,
                                                          idTipoComprobante,
                                                          letra,
                                                          centroEmisor,
                                                          numeroPedido)
      Dim fechaNuevoEstado As Date = Now
      Dim pedidoActual As Entidades.Pedido = Nothing
      Dim observacion As String = String.Format("Anulación {0} {1} {2:0000}-{3:00000000}", idTipoComprobante, letra, centroEmisor, numeroPedido)

      Dim idNuevoEstadoPedidoGenerador As String = Entidades.EstadoPedido.ESTADO_ALTA ' Publicos.EstadoPresupuestoAlAnularPedido

      Dim lstPedidosAResetear = New List(Of Entidades.Pedido)()

      For Each pedidoEstado In lstPedidoEstado

         'sqlPE.PedidosEstados_U_Estado(pedidoEstado.IdSucursal,
         '                              pedidoEstado.IdTipoComprobante,
         '                              pedidoEstado.Letra,
         '                              pedidoEstado.CentroEmisor,
         '                              pedidoEstado.NumeroPedido,
         '                              pedidoEstado.IdProducto,
         '                              pedidoEstado.FechaEstado,
         '                              idEstadoPedidoGenerador,
         '                              pedidoEstado.TipoEstadoPedido,
         '                              pedidoEstado.CantEstado,
         '                              fechaNuevoEstado,
         '                              observacion,
         '                              pedidoEstado.Orden,
         '                              pedidoEstado.IdCriticidad,
         '                              pedidoEstado.FechaEntrega)

         'rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(pedidoEstado.IdSucursal,
         '                                                pedidoEstado.IdTipoComprobante,
         '                                                pedidoEstado.Letra,
         '                                                pedidoEstado.CentroEmisor,
         '                                                pedidoEstado.NumeroPedido,
         '                                                pedidoEstado.IdProducto,
         '                                                pedidoEstado.Orden,
         '                                                pedidoEstado.IdEstado, idEstadoPedidoGenerador,
         '                                                pedidoEstado.CantEstado)

         rPE.ReservaProducto(pedidoEstado.IdSucursal,
                                 pedidoEstado.IdTipoComprobante,
                                 pedidoEstado.Letra,
                                 pedidoEstado.CentroEmisor,
                                 pedidoEstado.NumeroPedido,
                                 pedidoEstado.IdProducto,
                                 pedidoEstado.Orden,
                                 pedidoEstado.IdEstado, idNuevoEstadoPedidoGenerador, pedidoEstado.TipoEstadoPedido,
                                 pedidoEstado.CantEstado,
                                 Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, 0, 0, pedidoEstado.IdDepositoAnterior, pedidoEstado.IdUbicacionAnterior)

         If Not lstPedidosAResetear.Exists(Function(p) p.IdSucursal = pedidoEstado.IdSucursal And
                                                       p.IdTipoComprobante = pedidoEstado.IdTipoComprobante And
                                                       p.LetraComprobante = pedidoEstado.Letra And
                                                       p.CentroEmisor = pedidoEstado.CentroEmisor And
                                                       p.NumeroPedido = pedidoEstado.NumeroPedido) Then
            Dim pedido As New Entidades.Pedido()
            pedido.IdSucursal = pedidoEstado.IdSucursal
            pedido.TipoComprobante = New Entidades.TipoComprobante()
            pedido.TipoComprobante.IdTipoComprobante = pedidoEstado.IdTipoComprobante
            pedido.LetraComprobante = pedidoEstado.Letra
            pedido.CentroEmisor = Convert.ToInt16(pedidoEstado.CentroEmisor)
            pedido.NumeroPedido = pedidoEstado.NumeroPedido
            lstPedidosAResetear.Add(pedido)
         End If
      Next        'For Each pedidoEstado As PedidoEstado In lstPedidoEstado

      'Ahora la anulación elimina PedidosEstados Original lo recrea como cuando fue generado (en Pendiente) y resetea las cantidades de PedidosProductos.
      For Each pedidoAResetear In lstPedidosAResetear
         sqlPE.PedidosEstados_D(pedidoAResetear.IdSucursal,
                                pedidoAResetear.IdTipoComprobante,
                                pedidoAResetear.LetraComprobante,
                                pedidoAResetear.CentroEmisor,
                                pedidoAResetear.NumeroPedido, Nothing, String.Empty, Nothing)
         Dim pedidosProductos As List(Of Entidades.PedidoProducto)
         pedidosProductos = rPP.GetTodos(pedidoAResetear.IdSucursal,
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

   Public Function GetPedidos(sucursales As Entidades.Sucursal(),
                              idEstado As String,
                              fechaDesde As Date,
                              fechaHasta As Date,
                              numeroPedido As Long,
                              idProducto As String,
                              idCliente As Long,
                              tamanio As Decimal,
                              idMarca As Integer,
                              idRubro As Integer,
                              idSubRubro As Integer,
                              idVendedor As Integer,
                              tipoVendedor As Entidades.OrigenFK,
                              ordenCompra As Long,
                              tipoTipoComprobante As String,
                              tiposComprobante As Entidades.TipoComprobante(),
                              letra As String,
                              centroEmisor As Short,
                              orden As Integer,
                              fechaEstado As Date?,
                              idZonaGeografica As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos) As DataTable
      Dim sql = GetSQL()
      Return sql.GetPedidos(sucursales,
                            idEstado,
                            fechaDesde, fechaHasta,
                            numeroPedido,
                            idProducto,
                            idCliente,
                            tamanio,
                            idMarca,
                            idRubro,
                            idSubRubro,
                            idVendedor,
                            tipoVendedor,
                            ordenCompra,
                            tipoTipoComprobante,
                            tiposComprobante,
                            letra,
                            centroEmisor,
                            orden,
                            fechaEstado,
                            idZonaGeografica,
                            seguridadRol)

   End Function

   Public Function GetPedidos(idSucursal As Integer, numeroOrdenCompra As Long) As List(Of Entidades.Pedido)
      Dim result = New List(Of Entidades.Pedido)()
      For Each dr As DataRow In GetSQL().Pedidos_GA(idSucursal, numeroOrdenCompra, Nothing).Rows
         Dim o = New Entidades.Pedido()
         CargarUno(o, dr, estadoPedido:=Nothing)
         result.Add(o)
      Next
      Return result
   End Function

   Public Sub ThrowVerificaPedidoModificable(pedido As Entidades.Pedido, motivo As String)
      Throw New Exception(String.Format("El {1} {2} {3:0000}-{4:00000000} no se puede modificar:{0}{0}{5}",
                                        Environment.NewLine,
                                        pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido,
                                        motivo))
   End Sub

   Public Sub VerificaPedidoModificable(pedido As Entidades.Pedido)
      If Reglas.Publicos.PedidosPermitirModificarNoGestionados Then
         VerificaPedidoModificableParciales(pedido)
      Else
         VerificaPedidoModificableCompleto(pedido)
      End If
   End Sub
   Public Sub VerificaPedidoModificableParciales(pedido As Entidades.Pedido)
      Dim ep = New EstadosPedidos(da).GetUno(Entidades.EstadoPedido.ESTADO_ALTA, pedido.TipoComprobante.Tipo)
      If ep.ReservaStock Then
         ThrowVerificaPedidoModificable(pedido, String.Format("El Estado {0} Reserva Stock", Entidades.EstadoPedido.ESTADO_ALTA))
      End If
      If ep.Divide Then
         ThrowVerificaPedidoModificable(pedido, String.Format("El Estado {0} Divide", Entidades.EstadoPedido.ESTADO_ALTA))
      End If
      If Not String.IsNullOrWhiteSpace(ep.IdTipoComprobante) Then
         ThrowVerificaPedidoModificable(pedido, String.Format("El Estado {0} Genera Comprobante", Entidades.EstadoPedido.ESTADO_ALTA))
      End If
      If Not Publicos.PedidosConservaOrdenProductos Then
         ThrowVerificaPedidoModificable(pedido, "El perámetro Pedidos -> 'Conserva Orden de los Productos en la Grilla' debe estár tildado para poder editar pedidos.")
      End If
   End Sub
   Public Sub VerificaPedidoModificableCompleto(pedido As Entidades.Pedido)
      Dim dt = GetSQL().
                       VerificaPedidoModificable(pedido.IdSucursal,
                                                 pedido.IdTipoComprobante, pedido.LetraComprobante,
                                                 pedido.CentroEmisor, pedido.NumeroPedido)
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
            ThrowVerificaPedidoModificable(pedido, "El pedido ya fue gestionado.")
         End If
      End If
   End Sub

   Public Function ExistePedido(idSucursal As Integer, IdCliente As Long, fechaPed As Date) As Boolean
      Return GetSQL().ExistePedido(idSucursal, IdCliente, fechaPed)
   End Function

   Public Function ExistePedido(idSucursal As Integer, NumeroPedido As Long) As Boolean
      Return GetSQL().ExistePedido(idSucursal, NumeroPedido)
   End Function

   Public Function ExistePedido(idSucursal As Integer, idTipoComprobante As String, numeroPedido As Long) As Boolean
      Return GetSQL().ExistePedido(idSucursal, idTipoComprobante, numeroPedido)
   End Function

   Public Function ExistePedido(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long) As Boolean
      Return GetSQL().ExistePedido(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
   End Function
#End Region

#Region "REPORTE"

   Public Function GetPedidosDetalladoXEstados(idSucursal As Integer,
                                               idEstado As String,
                                               dtpDesde As Date,
                                               dtpHasta As Date,
                                               dtpDesdeEntrega As Date?,
                                               dtpHastaEntrega As Date?,
                                               numeroPedido As Long,
                                               idProducto As String,
                                               idMarca As Integer,
                                               idRubro As Integer,
                                               lote As String,
                                               idCliente As Long,
                                               idUsuario As String,
                                               tamanio As Decimal,
                                               idVendedor As Integer,
                                               ordenCompra As Long,
                                               tipoTipoComprobante As String,
                                               tiposComprobante As Entidades.TipoComprobante(),
                                               espPulgadas As String,
                                               espmm As Decimal?,
                                               sae As Integer?,
                                               idProceso As Integer,
                                               idproveedor As Long,
                                               idZonaGeografica As String,
                                               listaPrecios As String) As DataTable
      Dim sql = GetSQL()
      Return sql.GetPedidosDetalladoXEstados(idSucursal,
                                             idEstado,
                                             dtpDesde, dtpHasta,
                                             dtpDesdeEntrega, dtpHastaEntrega,
                                             numeroPedido,
                                             idProducto,
                                             idMarca,
                                             idRubro,
                                             lote,
                                             idCliente,
                                             idUsuario,
                                             tamanio,
                                             idVendedor,
                                             ordenCompra,
                                             tipoTipoComprobante,
                                             tiposComprobante,
                                             espPulgadas,
                                             espmm,
                                             sae,
                                             idProceso,
                                             idproveedor,
                                             idZonaGeografica,
                                             listaPrecios)
   End Function

   Public Function GetPedidosDetalladoXEstadosTodos(idSucursal As Integer,
                                                    idEstado As String,
                                                    fechaDesde As Date, fechaHasta As Date,
                                                    tiposComprobante As Entidades.TipoComprobante(), letra As String, centroEmisor As Short,
                                                    numeroPedidoDesde As Long, numeroPedidoHasta As Long,
                                                    idProducto As String, idMarca As Integer, idRubro As Integer,
                                                    lote As String,
                                                    idCliente As Long,
                                                    idUsuario As String,
                                                    tamanio As Decimal,
                                                    idVendedor As Integer, tipoVendedor As Entidades.OrigenFK,
                                                    ordenCompra As Long,
                                                    tipoTipoComprobante As String,
                                                    idProveedor As Long,
                                                    categorias As Entidades.Categoria(), origenCategorias As Entidades.OrigenFK,
                                                    numeroReparto As Integer,
                                                    numeroRepartoHasta As Integer,
                                                    idFormasPago As Integer,
                                                    idListaPrecios As Integer,
                                                    mostrarAnulacionesPorModificacion As Boolean) As DataTable
      Dim sql = GetSQL()
      Return sql.GetPedidosDetalladoXEstadosTodos(idSucursal,
                                                  idEstado,
                                                  fechaDesde, fechaHasta,
                                                  tiposComprobante, letra, centroEmisor,
                                                  numeroPedidoDesde, numeroPedidoHasta,
                                                  idProducto, idMarca, idRubro,
                                                  lote,
                                                  idCliente,
                                                  idUsuario,
                                                  tamanio,
                                                  idVendedor, tipoVendedor,
                                                  ordenCompra,
                                                  tipoTipoComprobante,
                                                  idProveedor,
                                                  categorias, origenCategorias,
                                                  numeroReparto,
                                                  numeroRepartoHasta,
                                                  idFormasPago, idListaPrecios,
                                                  mostrarAnulacionesPorModificacion)
   End Function

   Public Function GetPedidosDetalleComprobante(idSucursal As Integer,
                                                idEstado As String,
                                                fechaDesde As Date, fechaHasta As Date,
                                                numeroPedido As Long,
                                                idProducto As String, idMarca As Integer, idRubro As Integer,
                                                lote As String,
                                                idCliente As Long,
                                                idUsuario As String,
                                                tamanio As Decimal,
                                                idVendedor As Integer, tipoVendedor As Entidades.OrigenFK,
                                                ordenCompra As Long,
                                                tipoTipoComprobante As String, tiposComprobante As Entidades.TipoComprobante(),
                                                idListaPrecios As Integer,
                                                mostrarAnulacionesPorModificacion As Boolean) As DataTable
      Dim sql = GetSQL()
      Return sql.GetPedidosDetalleComprobante(idSucursal,
                                              idEstado,
                                              fechaDesde, fechaHasta,
                                              numeroPedido,
                                              idProducto, idMarca, idRubro,
                                              lote,
                                              idCliente,
                                              idUsuario,
                                              tamanio,
                                              idVendedor, tipoVendedor,
                                              ordenCompra,
                                              tipoTipoComprobante, tiposComprobante, idListaPrecios,
                                              mostrarAnulacionesPorModificacion)
   End Function

   Public Function GetPedidosDetalleComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Dim sql = GetSQL()
      Return sql.GetPedidosDetalleComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function
   Public Function GetPedidosxComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Dim sql = GetSQL()
      Return sql.GetPedidosxComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function


   <Obsolete("Usar el método que recibe colección de Sucursales")>
   Public Function pedidosCabecera(idSucursal As Integer,
                                   idEstado As String, alMenosUno_TodosSean As Boolean,
                                   dtpDesde As Date,
                                   dtpHasta As Date,
                                   tiposComprobante As Entidades.TipoComprobante(),
                                   letra As String,
                                   centroEmisor As Short,
                                   numeroPedidoDesde As Long,
                                   numeroPedidoHasta As Long,
                                   idProducto As String,
                                   idCliente As Long,
                                   idUsuario As String,
                                   idVendedor As Integer,
                                   tipoVendedor As Entidades.OrigenFK,
                                   ordenCompra As Long,
                                   tipoTipoComprobante As String,
                                   idProveedor As Long,
                                   categorias As Entidades.Categoria(),
                                   origenCategorias As Entidades.OrigenFK,
                                   numeroReparto As Integer,
                                   numeroRepartoHasta As Integer,
                                   idFormasPago As Integer,
                                   idListaPrecios As Integer,
                                   impreso As Entidades.Publicos.SiNoTodos) As DataTable
      Return pedidosCabecera({New Sucursales(da).GetUna(idSucursal, incluirLogo:=False)},
                             idEstado, alMenosUno_TodosSean, dtpDesde, dtpHasta,
                             tiposComprobante, letra, centroEmisor, numeroPedidoDesde, numeroPedidoHasta,
                             idProducto, idCliente, idUsuario, idVendedor, tipoVendedor,
                             ordenCompra, tipoTipoComprobante, idProveedor, categorias, origenCategorias,
                             numeroReparto, numeroRepartoHasta, idFormasPago, idListaPrecios, impreso)
   End Function

   Public Function pedidosCabecera(sucursales As Entidades.Sucursal(),
                                   idEstado As String, alMenosUno_TodosSean As Boolean,
                                   dtpDesde As Date,
                                   dtpHasta As Date,
                                   tiposComprobante As Entidades.TipoComprobante(),
                                   letra As String,
                                   centroEmisor As Short,
                                   numeroPedidoDesde As Long,
                                   numeroPedidoHasta As Long,
                                   idProducto As String,
                                   idCliente As Long,
                                   idUsuario As String,
                                   idVendedor As Integer,
                                   tipoVendedor As Entidades.OrigenFK,
                                   ordenCompra As Long,
                                   tipoTipoComprobante As String,
                                   idProveedor As Long,
                                   categorias As Entidades.Categoria(),
                                   origenCategorias As Entidades.OrigenFK,
                                   numeroReparto As Integer,
                                   numeroRepartoHasta As Integer,
                                   idFormasPago As Integer,
                                   idListaPrecios As Integer,
                                   impreso As Entidades.Publicos.SiNoTodos) As DataTable

      'IdMarca As Integer,
      'IdRubro As Integer,
      'lote As String,
      'Tamanio As Decimal,
      Dim sql = GetSQL()
      Return sql.pedidosCabecera(sucursales,
                                 idEstado, alMenosUno_TodosSean,
                                 dtpDesde, dtpHasta,
                                 tiposComprobante,
                                 letra,
                                 centroEmisor,
                                 numeroPedidoDesde,
                                 numeroPedidoHasta,
                                 idCliente,
                                 idUsuario,
                                 idVendedor,
                                 tipoVendedor,
                                 ordenCompra,
                                 tipoTipoComprobante,
                                 idProveedor,
                                 categorias,
                                 origenCategorias,
                                 numeroReparto,
                                 numeroRepartoHasta,
                                 idFormasPago,
                                 idListaPrecios,
                                 impreso)
   End Function

   Public Function GetPedidosSumaPorProductos(idSucursal As Integer,
                                              idEstado As String,
                                              dtpDesde As Date,
                                              dtpHasta As Date,
                                              idCliente As Long,
                                              idVendedor As Integer,
                                              idMarca As Integer,
                                              idRubro As Integer,
                                              idSubRubro As Integer,
                                              idProducto As String,
                                              tamanio As Decimal,
                                              ordenCompra As Long,
                                              tipoTipoComprobante As String,
                                              idProveedor As Long) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim sql = GetSQL()
            Return sql.GetPedidosSumaPorProductos(idSucursal,
                                                  idEstado,
                                                  dtpDesde, dtpHasta,
                                                  idCliente,
                                                  idVendedor,
                                                  idMarca,
                                                  idRubro,
                                                  idSubRubro,
                                                  idProducto,
                                                  tamanio,
                                                  ordenCompra,
                                                  tipoTipoComprobante,
                                                  idProveedor)
         End Function)
   End Function

   Public Function GetPedidosParaGenerarPedidoProv(idSucursal As Integer, idProveedor As Long,
                                                   idMarca As Integer, idRubro As Integer, idSubRubro As Integer,
                                                   idProducto As String, ordenCompra As Long,
                                                   oCObligatoria As Boolean,
                                                   fechaDesde As Date?, fechaHasta As Date?,
                                                   idEstado As String) As DataTable
      Return EjecutaConConexion(
      Function() GetSQL().GetPedidosParaGenerarPedidoProv(idSucursal, idProveedor,
                                                          idMarca, idRubro, idSubRubro,
                                                          idProducto, ordenCompra,
                                                          oCObligatoria,
                                                          fechaDesde, fechaHasta,
                                                          idEstado))
   End Function


#End Region

#Region "CrearComprobanteAutomatico"
   Public Overridable Function CrearPedidoProducto(producto As Eniac.Entidades.Producto,
                                       productoDescripcion As String,
                                       descuentoRecargoPorc1 As Decimal,
                                       descuentoRecargoPorc2 As Decimal,
                                       precio As Decimal,
                                       cantidad As Decimal,
                                       tipoImpuesto As Eniac.Entidades.TipoImpuesto,
                                       porcentajeIva As Decimal?,
                                       listaDePrecios As Eniac.Entidades.ListaDePrecios,
                                       criticidad As Eniac.Entidades.CriticidadPedido,
                                       fechaEntrega As Date?,
                                       pedido As Eniac.Entidades.Pedido,
                                       redondeoEnCalculo As Integer,
                                       kilosModif As Decimal?,
                                       precioVentaPorTamano As Decimal,
                                       tamano As Decimal,
                                       idUnidadDeMedida As String,
                                       moneda As Entidades.Moneda,
                                       espmm As Decimal,
                                       espPulgadas As String,
                                       codigoSAE As String,
                                       produccionProceso As Entidades.ProduccionProceso,
                                       produccionForma As Entidades.ProduccionForma,
                                       largoExtAlto As Decimal,
                                       anchoIntBase As Decimal,
                                       architrave As Decimal,
                                       modelo As Entidades.ProduccionModeloForma,
                                       urlPlano As String,
                                       idFormula As Integer,
                                       tipoOperacion As Entidades.Producto.TiposOperaciones,
                                       nota As String,
                                       costo As Decimal) As Eniac.Entidades.PedidoProducto

      cantidad = Decimal.Round(cantidad, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnCantidad)
      Dim rPrdSuc = New ProductosSucursales(da)
      Dim oPedidoProducto = New Entidades.PedidoProducto()
      Dim proSuc As Entidades.ProductoSucursal
      proSuc = New ProductosSucursales(da).GetUno(actual.Sucursal.IdSucursal,
                                                  producto.IdProducto,
                                                  listaDePrecios.IdListaPrecios)

      Dim kilos As Decimal = 0
      'If producto.UnidadDeMedida IsNot Nothing Then
      '   kilos = Decimal.Round(cantidad * producto.Tamano * producto.UnidadDeMedida.ConversionAKilos, 3)
      'End If

      If kilosModif.HasValue Then ' producto.PermiteModificarDescripcion AndAlso Publicos.FacturacionModificaDescripSolicitaKilos AndAlso kilosModif.HasValue Then
         kilos = kilosModif.Value
      Else
         kilos = Decimal.Round(cantidad * producto.Kilos, 3)
      End If

      If Not porcentajeIva.HasValue Then
         porcentajeIva = producto.Alicuota

         If Not pedido.Cliente.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
               Not pedido.TipoComprobante.UtilizaImpuestos Then
            porcentajeIva = 0
         End If

         If pedido.TipoComprobante.UtilizaImpuestos Then
            If Publicos.ProductoUtilizaAlicuota2 AndAlso pedido.Cliente.CategoriaFiscal().ResuelveUtilizaAlicuota2Producto(pedido.Cliente) AndAlso producto.Alicuota2.HasValue Then
               porcentajeIva = producto.Alicuota2.Value
            End If
         Else
            porcentajeIva = 0
         End If

      End If

      Dim precioProducto As Decimal
      If Not pedido.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         If pedido.TipoComprobante.GrabaLibro Or pedido.TipoComprobante.EsPreElectronico Then
            precioProducto = precio - producto.ImporteImpuestoInterno
         Else
            precioProducto = precio
         End If
      Else
         precioProducto = precio
      End If

      Dim precioCosto As Decimal
      If costo = 0 Then
         precioCosto = proSuc.PrecioCosto

         Dim PrecioCostoSinIVA As Decimal
         Dim PrecioCostoConIVA As Decimal

         If Publicos.PreciosConIVA Then
            PrecioCostoConIVA = precioCosto
            PrecioCostoSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(PrecioCostoConIVA, producto.Alicuota,
                                                                                     producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
         Else
            PrecioCostoSinIVA = precioCosto
            PrecioCostoConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioCostoSinIVA, producto.Alicuota,
                                                                                     producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
         End If
         If producto.Moneda.IdMoneda = 2 Then
            PrecioCostoConIVA = Decimal.Round(PrecioCostoConIVA * pedido.CotizacionDolar, redondeoEnCalculo)
            PrecioCostoSinIVA = Decimal.Round(PrecioCostoSinIVA * pedido.CotizacionDolar, redondeoEnCalculo)
         End If

         'If (pedido.Cliente.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
         '    Not pedido.Cliente.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
         precioCosto = PrecioCostoSinIVA
         'Else
         '   precioCosto = PrecioCostoConIVA
         'End If
      Else
         precioCosto = costo

         ''proSuc.PrecioCosto = precioCosto
         '' oPrdSuc.ActualizaPrecioCosto(proSuc)      ¿¿¿ PORQUE ???   Se puso para SAURO, pero no tiene sentido ponerlo acá y da problema a todos los otros clientes. Se debe llevar a otro lado.
      End If


      Dim impuestoInternoTotalLinea As Decimal = 0 ' producto.ImporteImpuestoInterno * cantidad
      Dim precioConImpuestos As Decimal
      If Not pedido.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         precioConImpuestos = precio
      Else
         precioConImpuestos = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(precio, porcentajeIva.Value, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
      End If

      impuestoInternoTotalLinea = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoConIVA(precioConImpuestos, porcentajeIva.Value, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt) ' - Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precioConImpuestos, porcentajeIva.Value, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno)
      impuestoInternoTotalLinea *= cantidad

      Dim precioLista As Decimal = proSuc.PrecioVentaLista
      Dim precioListaSinIVA As Decimal
      Dim precioListaConIVA As Decimal

      If Publicos.PreciosConIVA Then
         precioListaConIVA = precioLista
         precioListaSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precioListaConIVA, producto.Alicuota,
                                                                                  producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
      Else
         precioListaSinIVA = precioLista
         precioListaConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(precioListaSinIVA, producto.Alicuota,
                                                                                  producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
      End If
      If producto.Moneda.IdMoneda = 2 Then
         precioListaConIVA = Decimal.Round(precioListaConIVA * pedido.CotizacionDolar, redondeoEnCalculo)
         precioListaSinIVA = Decimal.Round(precioListaSinIVA * pedido.CotizacionDolar, redondeoEnCalculo)
      End If

      If (pedido.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
          Not pedido.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
         precioLista = precioListaSinIVA
      Else
         precioLista = precioListaConIVA
      End If


      Dim descRec1 As Decimal = Decimal.Round(precioProducto * descuentoRecargoPorc1 / 100, redondeoEnCalculo)
      Dim descRec2 As Decimal = Decimal.Round((precioProducto + descRec1) * descuentoRecargoPorc2 / 100, redondeoEnCalculo)
      Dim descRecG As Decimal = Decimal.Round((precioProducto + descRec1 + descRec2) * pedido.DescuentoRecargoPorc / 100, redondeoEnCalculo)

      Dim precioNeto As Decimal = precio + descRec1 + descRec2 + descRecG
      Dim importeIVA As Decimal

      impuestoInternoTotalLinea = impuestoInternoTotalLinea * (1 + (descuentoRecargoPorc1 / 100))
      impuestoInternoTotalLinea = impuestoInternoTotalLinea * (1 + (descuentoRecargoPorc2 / 100))
      impuestoInternoTotalLinea = impuestoInternoTotalLinea * (1 + (pedido.DescuentoRecargoPorc / 100))

      If Not pedido.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         importeIVA = Decimal.Round(((precioNeto * cantidad) - impuestoInternoTotalLinea) - ((precioNeto * cantidad) - impuestoInternoTotalLinea) / (1 + porcentajeIva.Value / 100), redondeoEnCalculo)
      Else
         importeIVA = Decimal.Round((precioNeto * cantidad) * porcentajeIva.Value / 100, redondeoEnCalculo)
      End If

      With oPedidoProducto
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Producto = producto
         If producto.PermiteModificarDescripcion Then
            .Producto.NombreProducto = productoDescripcion   'Piso la descripcion si tiene habilitado la posibilidad de cambiarlas.
         End If
         .DescuentoRecargoPorc = descuentoRecargoPorc1
         .DescuentoRecargoPorc2 = descuentoRecargoPorc2
         ''.DescuentoRecargo = descuentoRecargo
         .Precio = precio
         .Cantidad = cantidad
         .CantidadManual = cantidad '# Se iguala la Cantidad con la Cantidad Manual
         .Conversion = 1
         .ImporteTotal = (precio + descRec1 + descRec2) * cantidad
         .ImporteImpuesto = importeIVA
         .AlicuotaImpuesto = porcentajeIva.Value
         .TipoImpuesto = tipoImpuesto

         .Stock = proSuc.Stock
         .Costo = precioCosto
         .PrecioLista = precioLista 'proSuc.GetPrecioVentaDeLista(Publicos.ListaPreciosPredeterminada)
         .Kilos = kilos
         .PrecioNeto = precioNeto
         .DescuentoRecargoProducto = (.PrecioNeto - .Precio) * .Cantidad
         .ImporteTotalNeto = .PrecioNeto * cantidad
         .IdCriticidad = criticidad.IdCriticidad
         If fechaEntrega.HasValue Then
            .FechaEntrega = fechaEntrega.Value
         End If
         .IdListaPrecios = listaDePrecios.IdListaPrecios
         .NombreListaPrecios = listaDePrecios.NombreListaPrecios
         .FechaActualizacion = Now
         .PorcImpuestoInterno = producto.PorcImpuestoInterno
         .OrigenPorcImpInt = producto.OrigenPorcImpInt
         '.ImporteImpuestoInterno = producto.ImporteImpuestoInterno
         .ImporteImpuestoInterno = impuestoInternoTotalLinea ' producto.ImporteImpuestoInterno * cantidad

         .PrecioVentaPorTamano = precioVentaPorTamano
         .Tamano = tamano
         .IdUnidadDeMedida = idUnidadDeMedida
         .Moneda = moneda

         .Espmm = espmm
         .EspPulgadas = espPulgadas
         .CodigoSAE = codigoSAE
         .ProduccionProceso = produccionProceso
         .ProduccionForma = produccionForma
         .LargoExtAlto = largoExtAlto
         .AnchoIntBase = anchoIntBase
         .Architrave = architrave
         .ProduccionModeloForma = modelo
         .UrlPlano = urlPlano
         .IdFormula = idFormula
         .TipoOperacion = tipoOperacion
         .Nota = nota
      End With

      Return oPedidoProducto
   End Function

   Public Overridable Function CrearPedidoProducto(producto As Entidades.Producto,
                                    productoDescripcion As String,
                                    descuentoRecargoPorc1 As Decimal,
                                    descuentoRecargoPorc2 As Decimal,
                                    precio As Decimal,
                                    cantidad As Decimal,
                                    tipoImpuesto As Entidades.TipoImpuesto,
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
                                    codigoSAE As String,
                                    produccionProceso As Entidades.ProduccionProceso,
                                    produccionForma As Entidades.ProduccionForma,
                                    largoExtAlto As Decimal,
                                    anchoIntBase As Decimal,
                                    architrave As Decimal,
                                    modelo As Entidades.ProduccionModeloForma,
                                    urlPlano As String,
                                    idFormula As Integer,
                                    tipoOperacion As Entidades.Producto.TiposOperaciones,
                                    nota As String,
                                    costo As Decimal) As Entidades.PedidoProducto

      Dim blnAbreConeccion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      If blnAbreConeccion Then da.OpenConection()

      Try
         Dim lp = New Reglas.ListasDePrecios(da).GetUno(idListaDePrecios)
         Dim crt = New Reglas.PedidosCriticidades(da).GetUno(idCriticidad)

         Return CrearPedidoProducto(producto,
                                    productoDescripcion,
                                    descuentoRecargoPorc1,
                                    descuentoRecargoPorc2,
                                    precio,
                                    cantidad,
                                    tipoImpuesto,
                                    porcentajeIva,
                                    lp,
                                    crt,
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
                                    architrave,
                                    modelo,
                                    urlPlano,
                                    idFormula,
                                    tipoOperacion,
                                    nota,
                                    costo)
      Finally
         If blnAbreConeccion Then da.CloseConection()
      End Try
   End Function

   Public Overridable Sub AgregarLinea(pedido As Entidades.Pedido, pedidoProducto As Entidades.PedidoProducto)
      Dim bruto As Decimal = 0
      Dim neto As Decimal = 0
      Dim iva As Decimal = 0
      Dim impint As Decimal = 0
      Dim total As Decimal = 0

      'Si el Estado de Visita no adminte lineas, no puedo agregar lineas al pedido.
      If Not pedido.EstadoVisita.AdmintePedidoConLineas Then
         Throw New Exception(String.Format("El estado de visita '{0}' del '{1} {2} {3:0000}-{4:00000000} no adminte lineas. Verifique el estado de visita indicado en el Pedido.'",
                                           pedido.NombreEstadoVisita, pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido))
      End If

      pedidoProducto.Orden = pedido.PedidosProductos.Count

      pedido.PedidosProductos.Add(pedidoProducto)

      For Each vp As Eniac.Entidades.PedidoProducto In pedido.PedidosProductos
         If Not pedido.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
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
         pedido.Kilos += vp.Kilos
      Next

      pedido.ImporteBruto = bruto
      pedido.DescuentoRecargo = neto - bruto
      pedido.SubTotal = neto
      pedido.TotalImpuestos = iva
      pedido.TotalImpuestoInterno = impint
      pedido.ImporteTotal = total
   End Sub

   Public Overridable Sub AgregarContacto(pedido As Entidades.Pedido, contacto As Entidades.ClienteContacto)
      pedido.PedidosContactos.Add(New Entidades.PedidoClienteContacto(contacto))
   End Sub

   Public Overridable Sub AgregarObservacion(pedido As Entidades.Pedido, observacion As Entidades.PedidoObservacion)
      pedido.PedidosObservaciones.Add(observacion)
   End Sub

   Public Overridable Function CrearPedido(tipoComprobante As Eniac.Entidades.TipoComprobante,
                               cliente As Eniac.Entidades.Cliente,
                               letra As String,
                               centroEmisor As Short?,
                               numeroComprobante As Long?,
                               fecha As Date,
                               vendedor As Eniac.Entidades.Empleado,
                               caja As Eniac.Entidades.CajaNombre,
                               transportista As Eniac.Entidades.Transportista,
                               formaPago As Eniac.Entidades.VentaFormaPago,
                               tipoComprobanteFact As Eniac.Entidades.TipoComprobante,
                               observaciones As String,
                               estadoVisita As Eniac.Entidades.EstadoVisita,
                               ordenCompra As Long,
                               descuentoRecargoPorc As Decimal?,
                               clienteVinculado As Entidades.Cliente,
                               idMoneda As Integer, cotizacionDolar As Decimal?, IdPlazoEntrega As Integer, ValidezPresupuesto As Integer) As Eniac.Entidades.Pedido
      Dim blnAbreConeccion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      If blnAbreConeccion Then da.OpenConection()

      Try
         Dim oPedido As Eniac.Entidades.Pedido = New Eniac.Entidades.Pedido()

         With oPedido
            'cargo el comprobante
            .TipoComprobante = tipoComprobante

            'cargo el cliente
            .Cliente = cliente
            'cargo la Categoria Fiscal
            .CategoriaFiscal = cliente.CategoriaFiscal
            .Direccion = cliente.Direccion
            .IdLocalidad = cliente.Localidad.IdLocalidad

            .Impresora = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)

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

            .IdMoneda = idMoneda

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre

            'SPC: Este proceso se ejecuta por lo general automáticamente y la fecha/hora recibida es la que se espera que respete.
            '     Si en algún escenario se necesita que cambia parametrizar el comportamiento.
            ' '' ''Pudo levantar la pantalla y grabar despues. Vuelvo a asignarlo para que tome la hora.
            '' ''If fecha.Date = New Eniac.Reglas.Generales().GetServerDBFechaHora.Date Then
            '' ''   fecha = New Eniac.Reglas.Generales().GetServerDBFechaHora
            '' ''End If
            .Fecha = fecha

            .NumeroOrdenCompra = ordenCompra

            .Vendedor = vendedor

            .Caja = caja

            .EstadoVisita = estadoVisita

            If transportista Is Nothing AndAlso Publicos.PedidosSolicitaTransportista And cliente.IdTransportista <> 0 Then
               transportista = New Transportistas(da).GetUno(cliente.IdTransportista)
            End If

            .Transportista = transportista
            .FormaPago = formaPago
            .TipoComprobanteFact = tipoComprobanteFact

            '##################################################
            '# Quitar los espacios que puedan venir de la app #
            '##################################################
            .Observacion = observaciones.Replace(Chr(10), " ").Replace(Chr(13), "")

            .ClienteVinculado = clienteVinculado

            .CotizacionDolar = cotizacionDolar.IfNull(Function() New Monedas(da).GetUna(Entidades.Moneda.Dolar).FactorConversion)
            If descuentoRecargoPorc.HasValue Then
               .DescuentoRecargoPorc = descuentoRecargoPorc.Value
            Else
               .DescuentoRecargoPorc = New CalculosDescuentosRecargos().DescuentoRecargo(.Cliente, .TipoComprobante.GrabaLibro, .TipoComprobante.EsPreElectronico, .FormaPago,
                                                                                         cantidadLineasVenta:=0)
            End If
            .IdPlazoEntrega = IdPlazoEntrega
            .ValidezPresupuesto = ValidezPresupuesto
         End With

         Return oPedido
      Finally
         If blnAbreConeccion Then da.CloseConection()
      End Try
   End Function
#End Region

   Public Function Dividir(origen As Eniac.Entidades.Pedido, destinos As List(Of Eniac.Entidades.Pedido)) As List(Of Eniac.Entidades.Pedido)
      Dim result As List(Of Eniac.Entidades.Pedido) = New List(Of Eniac.Entidades.Pedido)()
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      If blnAbreConexion Then da.OpenConection()
      Try
         If blnAbreConexion Then da.BeginTransaction()

         Dim regla As Eniac.Reglas.Pedidos = New Eniac.Reglas.Pedidos(da)
         Dim sql As SqlServer.Pedidos = GetSQL()
         Dim sqlVP As Eniac.SqlServer.VentasProductos = New Eniac.SqlServer.VentasProductos(da)

         Borra(origen)
         'result.Add(Actualiza(origen))

         For Each destino As Eniac.Entidades.Pedido In destinos
            result.Add(ReleerPedido(Inserta(destino)))
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

   Public Function ConvertirPedidoEnVenta(pedido As Entidades.Pedido, idCaja As Integer, reparto As Integer) As Entidades.Venta
      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim redondeoEnCalculo As Integer = Eniac.Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
         Dim rVenta As Ventas = New Ventas(da)

         Dim fechaEnvio As Date? = Nothing
         If reparto <> 0 Then
            fechaEnvio = Today
            If pedido IsNot Nothing AndAlso pedido.PedidosProductos IsNot Nothing AndAlso pedido.PedidosProductos.Count > 0 Then
               fechaEnvio = pedido.PedidosProductos(0).FechaEntrega
            End If
         End If

         '# Asigno los datos del cliente eventual, en caso de que lo sea
         If pedido.Cliente.EsClienteGenerico Then
            With pedido.Cliente
               .NombreCliente = pedido.NombreClienteGenerico
               .Localidad.IdLocalidad = pedido.IdLocalidad.IfNull()
               .Direccion = pedido.Direccion
               .Cuit = pedido.Cuit
               .TipoDocCliente = pedido.TipoDocCliente
               .NroDocCliente = pedido.NroDocCliente.IfNull()
            End With
         End If
         '-- REQ-30527.- - Al facturar colocar caja y cobrador del pedido -
         If pedido.Caja IsNot Nothing Then
            idCaja = pedido.Caja.IdCaja
         End If
         '---------------------------------------------------------------
         Dim venta = rVenta.CreaVenta(actual.Sucursal.Id,
                                      pedido.TipoComprobanteFact,
                                      String.Empty, 0,
                                      Nothing,
                                      pedido.Cliente,
                                      Nothing,
                                      Now,
                                      pedido.Vendedor,
                                      pedido.Transportista,
                                      pedido.FormaPago,
                                      pedido.DescuentoRecargoPorc,
                                      idCaja,
                                      pedido.CotizacionDolar,
                                      mercDespachada:=reparto <> 0,
                                      numeroReparto:=reparto,
                                      fechaEnvio:=fechaEnvio,
                                      proveedor:=Nothing,
                                      observaciones:=If(pedido.TipoComprobanteFact.ImportaObservGrales, pedido.Observacion, String.Empty),
                                      cobrador:=Nothing,
                                      pedido.ClienteVinculado,
                                      pedido.NumeroOrdenCompra)

         venta.Palets = pedido.Palets

         For Each vp In pedido.PedidosProductos
            If vp.CantPendiente <> 0 Then
               Dim precio As Decimal? = Nothing
               Dim alicuotaProducto As Decimal = vp.Producto.Alicuota
               Dim utilizaAlicuota2 As Boolean = Publicos.ProductoUtilizaAlicuota2 AndAlso venta.CategoriaFiscal.ResuelveUtilizaAlicuota2Producto(venta.Cliente) AndAlso vp.Producto.Alicuota2.HasValue
               If utilizaAlicuota2 Then
                  alicuotaProducto = vp.Producto.Alicuota2.Value
               End If

               If _convertirPedidoEnFacturaConservaPreciosPedido Then
                  If pedido.CategoriaFiscal.IvaDiscriminado = venta.CategoriaFiscal.IvaDiscriminado And
                     pedido.TipoComprobante.UtilizaImpuestos = venta.TipoComprobante.UtilizaImpuestos And
                     vp.AlicuotaImpuesto = alicuotaProducto Then
                     precio = vp.Precio
                  Else

                     Dim precioPedidoConIVA As Decimal
                     Dim precioPedidoSinIVA As Decimal
                     If pedido.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado Then
                        precioPedidoSinIVA = vp.Precio
                        precioPedidoConIVA = CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.Producto)
                     Else
                        precioPedidoSinIVA = CalculosImpositivos.ObtenerPrecioSinImpuestos(vp.Precio, vp.Producto)
                        precioPedidoConIVA = vp.Precio
                     End If

                     If utilizaAlicuota2 Then
                        precioPedidoConIVA = CalculosImpositivos.ObtenerPrecioConImpuestos(precioPedidoSinIVA, vp.Producto, alicuotaProducto)
                     End If

                     If (venta.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or Not venta.TipoComprobante.UtilizaImpuestos Then
                        precio = precioPedidoSinIVA
                     Else
                        precio = precioPedidoConIVA
                     End If
                  End If
               End If

               rVenta.AgregarVentaProducto(venta,
                                           rVenta.CreaVentaProducto(vp.Producto, vp.Producto.NombreProducto,
                                                                    vp.DescuentoRecargoPorc, vp.DescuentoRecargoPorc2,
                                                                    precio, vp.CantPendiente,
                                                                    vp.TipoImpuesto, alicuotaProducto,
                                                                    cache.BuscaListaDePrecios(vp.IdListaPrecios), vp.FechaEntrega,
                                                                    vp.TipoOperacion, vp.Nota,
                                                                    DirectCast(Nothing, Integer?),
                                                                    venta, redondeoEnCalculo),
                                                                    redondeoEnCalculo)
               'Cargo los Comprobantes Facturados (tal vez ninguno)
            End If
         Next

         If pedido.Contactos IsNot Nothing Then
            For Each Contacto In pedido.Contactos
               rVenta.AgregarVentaContactos(venta, Contacto.Contacto)
            Next
         End If


         ' Si pedidosObservaciones no está vacio y está tildado el Check importaObservDeInvocados
         If pedido.PedidosObservaciones IsNot Nothing And venta.TipoComprobante.ImportaObservDeInvocados Then
            For Each observ In pedido.PedidosObservaciones
               rVenta.AgregarVentaObservacion(venta, observ.Observacion)
            Next
         End If

         '' Si pedidosObservaciones no está vacio y está tildado el Check importaObservGenerales
         'If Not String.IsNullOrWhiteSpace(pedido.Observacion) And venta.TipoComprobante.ImportaObservGrales Then
         '   rVenta.AgregarVentaObservacion(venta, pedido.Observacion)
         'End If

         rVenta.AgregarFacturable(venta, pedido)

         Return venta
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Function

   Public Sub ActualizarComprobantePorComprobante(vtaActual As Eniac.Entidades.Venta, vtaNueva As Eniac.Entidades.Venta)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()

         Dim sqlC As SqlServer.Pedidos = GetSQL()

         sqlC.ActualizarComprobantePorComprobante(vtaNueva.IdSucursal,
                                                  vtaActual.IdTipoComprobante, vtaActual.LetraComprobante, vtaActual.CentroEmisor, vtaActual.NumeroComprobante,
                                                  vtaNueva.IdTipoComprobante, vtaNueva.LetraComprobante, vtaNueva.CentroEmisor, vtaNueva.NumeroComprobante)

      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub ActualizarComprobantePorComprobanteRemito(vtaActual As Eniac.Entidades.Venta, vtaNueva As Eniac.Entidades.Venta)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()

         Dim sqlC As SqlServer.Pedidos = GetSQL()

         sqlC.ActualizarComprobantePorComprobanteRemito(vtaNueva.IdSucursal,
                                                        vtaActual.IdTipoComprobante, vtaActual.LetraComprobante, vtaActual.CentroEmisor, vtaActual.NumeroComprobante,
                                                        vtaNueva.IdTipoComprobante, vtaNueva.LetraComprobante, vtaNueva.CentroEmisor, vtaNueva.NumeroComprobante)

      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub ActualizarObservacionInterna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long,
                                           observacionInternaNueva As String)
      EjecutaConTransaccion(
         Sub()
            Dim sqlC As SqlServer.Pedidos = GetSQL()
            sqlC.ActualizarObservacionInterna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, observacionInternaNueva)
         End Sub)
   End Sub

   Public Sub ActualizaFechaImpresion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long)
      EjecutaConTransaccion(
         Sub()
            Dim sql As SqlServer.Pedidos = GetSQL()
            sql.ActualizaFechaImpresion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
         End Sub)
   End Sub

   Public Function GetPedidoOrigen(pedido As Entidades.Pedido) As Entidades.Pedido
      Dim sqlPE = New SqlServer.PedidosEstados(da)
      Dim pedidoOrigen As Entidades.Pedido = Nothing
      Using dt = sqlPE.PedidosEstados_G_PorComprobanteGenerado(
                           pedido.IdSucursal,
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
                                  Long.Parse(dr(Entidades.PedidoEstado.Columnas.NumeroPedido.ToString()).ToString()),
                                  estadoPedido:=Nothing)
         End If
      End Using
      Return pedidoOrigen
   End Function

   Public Function GetPedidosJSon(drPedidosCol As DataRow()) As List(Of Entidades.JSonEntidades.Pedidos.PedidoJSon)
      Dim lst = New List(Of Entidades.JSonEntidades.Pedidos.PedidoJSon)()

      Using dt = GetSQL().Pedidos_GA(actual.Sucursal.Id, drPedidosCol)
         Dim o As Entidades.JSonEntidades.Pedidos.PedidoJSon
         Dim cuitEmpresa As String = Publicos.CuitEmpresa
         For Each dr As DataRow In dt.Rows
            o = New Entidades.JSonEntidades.Pedidos.PedidoJSon()
            CargarUno(o, dr, cuitEmpresa)
            lst.Add(o)
         Next
      End Using

      Return lst
   End Function

   Private Sub CargarUno(o As Entidades.JSonEntidades.Pedidos.PedidoJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa
         .IdSucursal = Integer.Parse(dr(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.Pedido.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Integer.Parse(dr(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString())

         .FechaPedido = Date.Parse(dr(Entidades.Pedido.Columnas.FechaPedido.ToString()).ToString()).ToString("yyyy-MM-dd HH:mm:ss")
         .Observacion = dr(Entidades.Pedido.Columnas.Observacion.ToString()).ToString()
         .IdUsuario = dr(Entidades.Pedido.Columnas.IdUsuario.ToString()).ToString()
         .DescuentoRecargo = Decimal.Parse(dr(Entidades.Pedido.Columnas.DescuentoRecargo.ToString()).ToString())
         .DescuentoRecargoPorc = Decimal.Parse(dr(Entidades.Pedido.Columnas.DescuentoRecargoPorc.ToString()).ToString())

         '****  NO CAMBIAR HASTA QUE SE CAMBIA EL COMPORTAMIENTO GENERAL
         ' SE ENVIA EL CODIGO DE CLIENTE EN LUGAR DEL ID PORQUE LA PREVENTA NECESITA BUSCAR EL CLIENTE POR EL CODIGO
         ' EN LA WEB NO TENEMOS EL CODIGO DE CLIENTE POR LO QUE PARA PODER PASAR DE UN LADO AL OTRO EL MISMO SOLO PODEMOS REUSAR EL ID
         ' PARA CAMBIAR ESTO HAY QUE SOLICITAR EL CAMBIO EN LA CAPA INTERMEDIA DE LA WEB Y MODIFICAR EL PROCESO DE IMPORTACION DE PREVENTA
         .IdCliente = Long.Parse(dr(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString())
         '.IdCliente = Long.Parse(dr(Cliente.Columnas.IdCliente.ToString()).ToString())
         '****

         .IdVendedor = Integer.Parse(dr(Entidades.Pedido.Columnas.IdVendedor.ToString()).ToString())
         .TipoDocVendedor = dr("TipoDocVendedor").ToString()
         .NroDocVendedor = dr("NroDocVendedor").ToString()

         If IsNumeric(dr(Entidades.Pedido.Columnas.IdFormasPago.ToString()).ToString()) Then
            .IdFormasPago = Integer.Parse(dr(Entidades.Pedido.Columnas.IdFormasPago.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Pedido.Columnas.IdTransportista.ToString()).ToString()) Then
            .IdTransportista = Integer.Parse(dr(Entidades.Pedido.Columnas.IdTransportista.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Pedido.Columnas.CotizacionDolar.ToString()).ToString()) Then
            .CotizacionDolar = Decimal.Parse(dr(Entidades.Pedido.Columnas.CotizacionDolar.ToString()).ToString())
         End If
         .IdTipoComprobanteFact = dr(Entidades.Pedido.Columnas.IdTipoComprobanteFact.ToString()).ToString()
         .ImporteBruto = Decimal.Parse(dr(Entidades.Pedido.Columnas.ImporteBruto.ToString()).ToString())
         .SubTotal = Decimal.Parse(dr(Entidades.Pedido.Columnas.SubTotal.ToString()).ToString())
         .TotalImpuestos = Decimal.Parse(dr(Entidades.Pedido.Columnas.TotalImpuestos.ToString()).ToString())
         .TotalImpuestoInterno = Decimal.Parse(dr(Entidades.Pedido.Columnas.TotalImpuestoInterno.ToString()).ToString())
         .ImporteTotal = Decimal.Parse(dr(Entidades.Pedido.Columnas.ImporteTotal.ToString()).ToString())
         .IdEstadoVisita = Integer.Parse(dr(Entidades.Pedido.Columnas.IdEstadoVisita.ToString()).ToString())
         If IsNumeric(dr(Entidades.Pedido.Columnas.NumeroOrdenCompra.ToString()).ToString()) Then
            .NumeroOrdenCompra = Long.Parse(dr(Entidades.Pedido.Columnas.NumeroOrdenCompra.ToString()).ToString())
         End If
         .Kilos = Decimal.Parse(dr(Entidades.Pedido.Columnas.Kilos.ToString()).ToString())

         .IdMoneda = Integer.Parse(dr(Entidades.Pedido.Columnas.IdMoneda.ToString()).ToString())
         .IdClienteVinculado = If(IsNumeric(dr(Entidades.Pedido.Columnas.IdClienteVinculado.ToString())), Long.Parse(dr(Entidades.Pedido.Columnas.IdClienteVinculado.ToString()).ToString()), Nothing)

         .ObservacionInterna = dr(Entidades.Pedido.Columnas.ObservacionInterna.ToString()).ToString()
         .Palets = dr.ValorNumericoPorDefecto(Entidades.Pedido.Columnas.Palets.ToString(), 1I)
         .NroVersionAplicacion = dr(Entidades.Pedido.Columnas.NroVersionAplicacion.ToString()).ToString()
         .NroVersionRemoto = dr(Entidades.Pedido.Columnas.NroVersionRemoto.ToString()).ToString()
         .IdPedidoTiendaNube = dr.Field(Of String)(Entidades.Pedido.Columnas.IdPedidoTiendaNube.ToString())
         .IdPedidoMercadoLibre = dr.Field(Of String)(Entidades.Pedido.Columnas.IdPedidoMercadoLibre.ToString())
         .IdLocalidad = dr.Field(Of Integer?)(Entidades.Pedido.Columnas.IdLocalidad.ToString())
         .Direccion = dr.Field(Of String)(Entidades.Pedido.Columnas.Direccion.ToString())
         .Cuit = dr.Field(Of String)(Entidades.Pedido.Columnas.Cuit.ToString())
         .TipoDocCliente = dr.Field(Of String)(Entidades.Pedido.Columnas.TipoDocCliente.ToString())
         .NroDocCliente = dr.Field(Of Long?)(Entidades.Pedido.Columnas.NroDocCliente.ToString())
         .NombreClienteGenerico = dr.Field(Of String)("NombreClienteGenerico")

         .PedidosProductos = New Reglas.PedidosProductos(da).GetPedidosProductosJSon(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroPedido, cuitEmpresa)

         .IdDomicilio = dr.Field(Of Integer?)(Entidades.Pedido.Columnas.IdDomicilio.ToString())
      End With
   End Sub

   '# Para la alerta (Nombre de la función que le da el permiso: PedidosClientes-PedidosSinFacturar)
   Public Function GetPedidosSinFacturar(sucursales As List(Of Entidades.Sucursal)) As DataTable
      Return GetSQL().GetPedidosSinFacturar(sucursales)
   End Function

   Public Sub EnviarPedidosWeb(pedidosJ As List(Of Entidades.JSonEntidades.Pedidos.PedidoJSon),
                               tipoEstadoPedido As String,
                               idFuncion As String)
      Dim respuestaServicio As ServiciosRest.Pedidos.PedidosSiGA.WebSigaServiceResponse
      Dim rPedidosWeb = New Reglas.ServiciosRest.Pedidos.PedidosSiGA()

      respuestaServicio = rPedidosWeb.PostPedidos(pedidosJ)

      If Not respuestaServicio.status Then         'HUBO UN ERROR AL ENVIAR LOS PEDIDOS
         Throw New Exception(String.Format("Error enviado los pedidos a la web: {0}", respuestaServicio.message))
      Else                                         'SE ENVIARON EXITOSAMENTE LOS PEDIDOS

         Dim idEstadoNuevo As String = Publicos.EstadoPedidoEnviadoWebPOST      ' "NUEVO ESTADO"
         Dim fechaNuevoEstado As Date = Now
         Dim observ As String = "Pedido enviado a la Web"
         Try

            da.OpenConection()
            da.BeginTransaction()

            Dim estadoNuevo As Entidades.EstadoPedido = New Reglas.EstadosPedidos(da).GetUno(idEstadoNuevo, tipoEstadoPedido)
            Dim estadoAnterior As Entidades.EstadoPedido

            Dim sqlPE As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)
            Dim rPE As Reglas.PedidosEstados = New PedidosEstados(da)
            Dim rPP As Reglas.PedidosProductos = New PedidosProductos(da)

            Dim pedidosEstados As List(Of Entidades.PedidoEstado)

            For Each ped In pedidosJ
               For Each pedprod In ped.PedidosProductos

                  pedidosEstados = rPE.GetTodos(pedprod.IdSucursal, pedprod.IdTipoComprobante, pedprod.Letra, pedprod.CentroEmisor, pedprod.NumeroPedido)

                  For Each pedEst In pedidosEstados
                     estadoAnterior = New Reglas.EstadosPedidos(da).GetUno(pedEst.IdEstado, tipoEstadoPedido)
                     sqlPE.PedidosEstados_U_Estado(pedprod.IdSucursal,
                                                   pedprod.IdTipoComprobante, pedprod.Letra, pedprod.CentroEmisor, pedprod.NumeroPedido,
                                                   pedprod.IdProducto,
                                                   pedEst.FechaEstado,
                                                   idEstadoNuevo,
                                                   tipoEstadoPedido,
                                                   pedEst.CantEstado,
                                                   fechaNuevoEstado,
                                                   observ,
                                                   pedEst.Orden,
                                                   pedprod.IdCriticidad,
                                                   pedEst.FechaEntrega,
                                                   numeroReparto:=0, anulacionPorModificacion:=False)

                     rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(pedprod.IdSucursal, pedprod.IdTipoComprobante, pedprod.Letra, pedprod.CentroEmisor, pedprod.NumeroPedido,
                                                                     pedprod.IdProducto, pedprod.Orden,
                                                                     estadoAnterior.IdTipoEstado, estadoNuevo.IdTipoEstado, pedEst.CantEstado)

                     rPE.ReservaProducto(pedprod.IdSucursal, pedprod.IdTipoComprobante, pedprod.Letra, pedprod.CentroEmisor, pedprod.NumeroPedido,
                                             pedprod.IdProducto, pedprod.Orden,
                                             estadoAnterior.IdEstado, estadoNuevo.IdEstado, tipoEstadoPedido, pedEst.CantEstado,
                                             Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, 0, 0, pedEst.IdDepositoAnterior, pedEst.IdUbicacionAnterior)

                  Next        'For Each pedEst As Entidades.PedidoEstado In pedidosEstados
               Next           'For Each pedprod As JSonEntidades.Pedidos.PedidoProductoJSon In ped.PedidosProductos
            Next              'For Each ped As JSonEntidades.Pedidos.PedidoJSon In pedidosJ

            da.CommitTransaction()
         Catch
            da.RollbakTransaction()
            Throw
         Finally
            da.CloseConection()
         End Try

      End If         'If Not respuestaServicio.status Then

   End Sub


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

   Public Sub ValidaEliminarPedido(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long)

   End Sub

   Public Function GetPedidosPendientesConCantItems(estado As String, tieneCantFacturada As Boolean,
                                                    sucursales As List(Of Entidades.Sucursal)) As DataTable
      Return GetSQL().GetPedidosPendientesCantItemsFacturados(estado, tieneCantFacturada, sucursales)
   End Function
   Public Function GetPedidosPendientesSinCantItems(estado As String, tieneCantFacturada As Boolean,
                                                     sucursales As List(Of Entidades.Sucursal)) As DataTable
      Return GetSQL().GetPedidosPendientesCantItemsFacturados(estado, tieneCantFacturada, sucursales)
   End Function
End Class