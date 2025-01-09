Public Class OrdenesProduccionProductos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "OrdenesProduccionProductos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.OrdenProduccionProducto)))
   End Sub
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.OrdenesProduccionProductos(da).OrdenesProduccionProductos_GA(Nothing, String.Empty, String.Empty, Nothing, Nothing)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub CargarUno(o As Entidades.OrdenProduccionProducto, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.OrdenProduccion.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.OrdenProduccion.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.OrdenProduccion.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.OrdenProduccion.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroOrdenProduccion = Long.Parse(dr(Entidades.OrdenProduccion.Columnas.NumeroOrdenProduccion.ToString()).ToString())
         .Orden = Integer.Parse(dr("Orden").ToString())
         .Producto = New Productos(da).GetUno(dr("IdProducto").ToString())
         .Producto.NombreProducto = dr("NombreProducto").ToString()

         .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
         .Precio = Decimal.Parse(dr("Precio").ToString())
         .PrecioLista = Decimal.Parse(dr("PrecioLista").ToString())
         .Costo = Decimal.Parse(dr("Costo").ToString())
         .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())

         .CantPendiente = Decimal.Parse(dr("CantPendiente").ToString())
         .CantEntregada = Decimal.Parse(dr("CantEntregada").ToString())
         .CantEnProceso = Decimal.Parse(dr("CantEnProceso").ToString())
         .CantAnulada = Decimal.Parse(dr("CantAnulada").ToString())

         .DescuentoRecargoProducto = Decimal.Parse(dr("DescuentoRecargoProducto").ToString())
         .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
         .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())

         .TipoImpuesto = New Reglas.TiposImpuestos(da).GetUno(DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), dr("IdTipoImpuesto").ToString()), Entidades.TipoImpuesto.Tipos))
         .AlicuotaImpuesto = Decimal.Parse(dr("AlicuotaImpuesto").ToString())
         .ImporteImpuesto = Decimal.Parse(dr("ImporteImpuesto").ToString())

         .ImporteImpuestoInterno = Decimal.Parse(dr("ImporteImpuestoInterno").ToString())

         If Not String.IsNullOrWhiteSpace(dr("FechaActualizacion").ToString()) Then
            .FechaActualizacion = Date.Parse(dr("FechaActualizacion").ToString())
         End If

         .IdListaPrecios = Integer.Parse(dr("IdListaPrecios").ToString())
         .NombreListaPrecios = dr("NombreListaPrecios").ToString()

         .PrecioNeto = Decimal.Parse(dr("PrecioNeto").ToString())
         .ImporteTotalNeto = Decimal.Parse(dr("ImporteTotalNeto").ToString())
         .DescRecGeneral = Decimal.Parse(dr("DescRecGeneral").ToString())
         .DescRecGeneralProducto = Decimal.Parse(dr("DescRecGeneralProducto").ToString())
         .Kilos = Decimal.Parse(dr("Kilos").ToString())

         'VERIFICO QUE ESTÉ LA COLUMNA POR SI FALTÓ AGREGARLA EN ALGÚN QUERY/DATATABLE
         If dr.Table.Columns.Contains(Entidades.VentaProducto.Columnas.CantPendiente.ToString()) AndAlso
            Not String.IsNullOrWhiteSpace(dr(Entidades.VentaProducto.Columnas.CantPendiente.ToString()).ToString()) Then
            .CantPendiente = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.CantPendiente.ToString()).ToString())
         End If

         .IdCriticidad = dr("IdCriticidad").ToString()
         .FechaEntrega = DateTime.Parse(dr("FechaEntrega").ToString())

         If IsNumeric(dr(Entidades.OrdenProduccionProducto.Columnas.IdFormula.ToString())) Then
            .IdFormula = Integer.Parse(dr(Entidades.OrdenProduccionProducto.Columnas.IdFormula.ToString()).ToString())
            .NombreFormula = dr("NombreFormula").ToString()
         End If

         If IsNumeric(dr(Entidades.OrdenProduccionProducto.Columnas.Espmm.ToString()).ToString()) Then
            .Espmm = Decimal.Parse(dr(Entidades.OrdenProduccionProducto.Columnas.Espmm.ToString()).ToString())
         End If
         .EspPies = dr(Entidades.OrdenProduccionProducto.Columnas.EspPies.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.OrdenProduccionProducto.Columnas.CodigoSAE.ToString()).ToString()) Then
            .CodigoSAE = dr(Entidades.OrdenProduccionProducto.Columnas.CodigoSAE.ToString()).ToString()
         End If
         If IsNumeric(dr(Entidades.OrdenProduccionProducto.Columnas.IdProduccionProceso.ToString()).ToString()) Then
            .IdProduccionProceso = Integer.Parse(dr(Entidades.OrdenProduccionProducto.Columnas.IdProduccionProceso.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.OrdenProduccionProducto.Columnas.IdProduccionForma.ToString()).ToString()) Then
            .IdProduccionForma = Integer.Parse(dr(Entidades.OrdenProduccionProducto.Columnas.IdProduccionForma.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.OrdenProduccionProducto.Columnas.LargoExtAlto.ToString()).ToString()) Then
            .LargoExtAlto = Decimal.Parse(dr(Entidades.OrdenProduccionProducto.Columnas.LargoExtAlto.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.OrdenProduccionProducto.Columnas.AnchoIntBase.ToString()).ToString()) Then
            .AnchoIntBase = Decimal.Parse(dr(Entidades.OrdenProduccionProducto.Columnas.AnchoIntBase.ToString()).ToString())
         End If

         .Architrave = dr.Field(Of Decimal?)(Entidades.OrdenProduccionProducto.Columnas.AnchoIntBase.ToString()).IfNull()
         .ProduccionModeloForma = New ProduccionModelosFormas(da).GetUno(dr.Field(Of Integer?)(Entidades.OrdenProduccionProducto.Columnas.IdProduccionModeloForma.ToString()).IfNull())

         .UrlPlano = dr(Entidades.PedidoProducto.Columnas.UrlPlano.ToString()).ToString()

         .IdResponsable = Integer.Parse(dr(Entidades.OrdenProduccionProducto.Columnas.IdResponsable.ToString()).ToString())

         .NombreResponsable = dr("NombreResponsable").ToString()

         .IdProcesoProductivo = dr.Field(Of Long?)(Entidades.PedidoProducto.Columnas.IdProcesoProductivo.ToString()).IfNull()
         .CodigoProcesoProductivo = dr.Field(Of String)("CodigoProcesoProductivo").IfNull()
         .DescripcionProcesoProductivo = dr.Field(Of String)("DescripcionProcesoProductivo").IfNull()
         '-- REQ-41644.- -----------------------------------------------------------------------------
         If Not String.IsNullOrEmpty(dr("IdSucursalPedido").ToString()) Then
            .IdSucursalPedido = Integer.Parse(dr("IdSucursalPedido").ToString())
            .IdTipoComprobantePedido = dr("IdTipoComprobantePedido").ToString()
            .LetraPedido = dr("LetraPedido").ToString()
            .CentroEmisorPedido = Short.Parse(dr("CentroEmisorPedido").ToString())
            .NumeroPedido = Integer.Parse(dr("NumeroPedido").ToString())
            .OrdenPedido = Integer.Parse(dr("OrdenPedido").ToString())
            .IdProductoPedido = dr("IdProductoPedido").ToString()
         End If
         '--------------------------------------------------------------------------------------------
         .OrdenesProduccionEstados = New OrdenesProduccionEstados(da).GetTodos(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroOrdenProduccion)

         .OrdenesProduccionProductosFormulas = New OrdenesProduccionProductosFormulas(da).GetTodos(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroOrdenProduccion, .IdProducto, .Orden,
                                                                                                   soloMateriaPrima:=False)

         .OrdenesProduccionMRP = New OrdenesProduccionMRP(da).GetTodas(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroOrdenProduccion, .Orden, .IdProducto)

         .PedidoEstadoQueOrigino = New PedidosEstados(da).GetTodosPorProduccionProducto(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroOrdenProduccion, .IdProducto, .Orden)

         .Stock = Decimal.Parse(dr("Stock").ToString())

      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Sub InsertaDetalleDesdeOrdenProduccion(oOrdenesProduccion As Entidades.OrdenProduccion)
      Dim CategoriaFiscalEmpresa = New CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)

      Dim orden As Integer = 0
      For Each Prod In oOrdenesProduccion.OrdenesProduccionProductos
         'grabo los productos del comprobante de venta
         Prod.IdTipoComprobante = oOrdenesProduccion.IdTipoComprobante
         Prod.Letra = oOrdenesProduccion.LetraComprobante
         Prod.CentroEmisor = oOrdenesProduccion.CentroEmisor
         Prod.NumeroOrdenProduccion = oOrdenesProduccion.NumeroOrdenProduccion

         If Not CategoriaFiscalEmpresa.IvaDiscriminado Or Not oOrdenesProduccion.CategoriaFiscal.IvaDiscriminado Then
            Prod.Precio = Decimal.Round((Prod.Precio - (Prod.ImporteImpuestoInterno / Prod.Cantidad)) / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
            Prod.DescuentoRecargoProducto = Decimal.Round(Prod.DescuentoRecargoProducto / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
            Prod.DescRecGeneral = Decimal.Round(Prod.DescRecGeneral / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
            Prod.ImporteTotal = Decimal.Round((Prod.ImporteTotal - (Prod.ImporteImpuestoInterno / Prod.Cantidad)) / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
         End If

         'Los calculo Antes.
         Prod.DescuentoRecargoProducto = Decimal.Round(Prod.DescuentoRecargoProducto / Prod.Cantidad, 2)
         Prod.DescRecGeneralProducto = Decimal.Round(Prod.DescRecGeneral / Prod.Cantidad, 2)
         Prod.PrecioNeto = Decimal.Round(Prod.Precio + Prod.DescuentoRecargoProducto + Prod.DescRecGeneralProducto, 2)
         Prod.ImporteTotalNeto = Decimal.Round(Prod.ImporteTotal + Prod.DescRecGeneral, 2)
         'NO LO USA EN OrdenesProduccion: Prod.Utilidad = Decimal.Round((Prod.PrecioNeto - Prod.Costo) * Prod.Cantidad, 2)
         '--------------------------------------------------

         orden += 1
         Prod.Orden = orden
         Inserta(Prod)

         If Prod.PedidoEstadoQueOrigino.Count > 0 Then
            Dim sqlPeP As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)
            For Each pp In Prod.PedidoEstadoQueOrigino
               sqlPeP.PedidosEstados_U_OP(pp.IdSucursal, pp.IdTipoComprobante, pp.Letra, pp.CentroEmisor, pp.NumeroPedido, pp.IdProducto, pp.FechaEstado, Nothing, pp.Orden,
                                          Prod.IdSucursal, Prod.IdTipoComprobante, Prod.Letra, Prod.CentroEmisor, Prod.NumeroOrdenProduccion, Prod.IdProducto, Prod.Orden)
            Next
         End If

      Next
   End Sub

   Public Sub Inserta(prod As Entidades.OrdenProduccionProducto)
      EjecutaSP(prod, TipoSP._I)
   End Sub

   Public Sub EjecutaSP(prod As Entidades.OrdenProduccionProducto, tipo As TipoSP)

      Dim sql = New SqlServer.OrdenesProduccionProductos(da)

      Select Case tipo
         Case TipoSP._I
            sql.OrdenesProduccionProductos_I(prod.IdSucursal,
                                             prod.IdTipoComprobante,
                                             prod.Letra,
                                             prod.CentroEmisor,
                                             prod.NumeroOrdenProduccion,
                                             prod.IdProducto,
                                             prod.Cantidad,
                                             prod.Precio,
                                             prod.PrecioLista,
                                             prod.Costo,
                                             prod.ImporteTotal,
                                             prod.NombreProducto,
                                             prod.Cantidad,
                                             0, 0, 0,
                                             prod.DescuentoRecargoProducto,
                                             prod.DescuentoRecargoPorc,
                                             prod.DescuentoRecargoPorc2,
                                             prod.TipoImpuesto.IdTipoImpuesto,
                                             prod.AlicuotaImpuesto,
                                             prod.ImporteImpuesto,
                                             prod.Orden,
                                             prod.FechaActualizacion,
                                             prod.IdListaPrecios,
                                             prod.NombreListaPrecios,
                                             prod.ImporteImpuestoInterno,
                                             prod.PrecioNeto,
                                             prod.ImporteTotalNeto,
                                             prod.DescRecGeneral,
                                             prod.DescRecGeneralProducto,
                                             prod.Kilos,
                                             prod.IdCriticidad,
                                             prod.FechaEntrega,
                                             prod.IdFormula,
                                             prod.IdProduccionProceso,
                                             prod.IdProduccionForma,
                                             prod.Espmm,
                                             prod.EspPies,
                                             prod.CodigoSAE,
                                             prod.LargoExtAlto,
                                             prod.AnchoIntBase,
                                             prod.Architrave,
                                             prod.IdProduccionModeloForma,
                                             prod.UrlPlano,
                                             prod.IdResponsable,
                                             prod.IdProcesoProductivo,
                                             prod.IdSucursalPedido,
                                             prod.IdTipoComprobantePedido,
                                             prod.LetraPedido,
                                             prod.CentroEmisorPedido,
                                             prod.NumeroPedido,
                                             prod.IdProductoPedido,
                                             prod.OrdenPedido)

            If prod.IdFormula > 0 Then
               Dim rPPF = New OrdenesProduccionProductosFormulas(da)
               rPPF.InsertaDesdeOrdenProduccionProducto(prod)
            End If

            Dim rPE = New OrdenesProduccionEstados(da)
            rPE.Inserta(prod)

            If prod.Producto.IdProcesoProductivoDefecto > 0 Then
               Dim rOPMRP = New Reglas.OrdenesProduccionMRP(da)
               rOPMRP.InsertarDesdeOrdenProduccionProductos(prod)
            End If

         Case TipoSP._U

         Case TipoSP._D

            Dim opMrp = New OrdenesProduccionMRP(da)
            opMrp._Borrar(prod)

            Dim sqlPE = New SqlServer.OrdenesProduccionEstados(da)
            sqlPE.OrdenesProduccionEstados_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroOrdenProduccion, prod.Orden, prod.IdProducto, Nothing)

            Dim sqlPPF = New SqlServer.OrdenesProduccionProductosFormulas(da)
            sqlPPF.OrdenesProduccionProductosFormulas_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroOrdenProduccion, prod.IdProducto, prod.Orden,
                                                        idProductoElaborado:=Nothing, idUnicoNodoProductoElaborado:=Nothing, idProductoComponente:=Nothing, idUnicoNodoProductoComponente:=Nothing,
                                                        idFormula:=0, secuenciaFormula:=0)

            Dim sqlPP = New SqlServer.OrdenesProduccionProductos(da)
            sqlPP.OrdenesProduccionProductos_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroOrdenProduccion, prod.Orden, prod.IdProducto)
      End Select

   End Sub

   Public Function GetUno(IdSucursal As Integer,
                          IdTipoComprobante As String, Letra As String,
                          CentroEmisor As Integer, NumeroOrdenProduccion As Long,
                          Orden As Integer, IdProducto As String) As Entidades.OrdenProduccionProducto
      Dim dt As DataTable = New SqlServer.OrdenesProduccionProductos(da).OrdenesProduccionProductos_G1(IdSucursal,
                                                                                      IdTipoComprobante, Letra,
                                                                                      CentroEmisor, NumeroOrdenProduccion,
                                                                                      Orden, IdProducto)
      Dim o As Entidades.OrdenProduccionProducto = New Entidades.OrdenProduccionProducto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(IdSucursal As Integer,
                            IdTipoComprobante As String, Letra As String,
                            CentroEmisor As Integer, NumeroOrdenProduccion As Long) As List(Of Entidades.OrdenProduccionProducto)
      Dim dt As DataTable = New SqlServer.OrdenesProduccionProductos(da).OrdenesProduccionProductos_GA(IdSucursal,
                                                                                      IdTipoComprobante, Letra,
                                                                                      CentroEmisor, NumeroOrdenProduccion)
      Dim o As Entidades.OrdenProduccionProducto
      Dim oLis As List(Of Entidades.OrdenProduccionProducto) = New List(Of Entidades.OrdenProduccionProducto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.OrdenProduccionProducto()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetOrdenesProduccionProductos(idSucursal As Integer,
                                       idTipoComprobante As String,
                                       letra As String,
                                       centroEmisor As Short,
                                       numeroComprobante As Long) As DataTable
      'Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)
      Return New SqlServer.OrdenesProduccionProductos(da).OrdenesProduccionProductos_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function
   Public Function GetUnoProduccionProductos(IdSucursal As Integer,
                          IdTipoComprobante As String, Letra As String,
                          CentroEmisor As Integer, NumeroOrdenProduccion As Long,
                          Orden As Integer, IdProducto As String) As DataTable
      Return New SqlServer.OrdenesProduccionProductos(da).OrdenesProduccionProductos_G1(IdSucursal,
                                                                                      IdTipoComprobante, Letra,
                                                                                      CentroEmisor, NumeroOrdenProduccion,
                                                                                      Orden, IdProducto)
   End Function
   Public Sub ActualizaCantidadesSegunEstadoAnteriorNuevo(idSucursal As Integer,
                                                          idTipoComprobante As String,
                                                          letra As String,
                                                          centroEmisor As Integer,
                                                          numeroOrdenProduccion As Long,
                                                          idProducto As String,
                                                          orden As Integer,
                                                          idTipoEstadoAnterior As String,
                                                          idTipoEstadoNuevo As String,
                                                          cantidad As Decimal)
      Dim sqlPP As SqlServer.OrdenesProduccionProductos = New SqlServer.OrdenesProduccionProductos(da)
      Dim deltaCantidadPendiente As Decimal = 0
      Dim deltaCantidadEnProceso As Decimal = 0
      Dim deltaCantidadEntregada As Decimal = 0
      Dim deltaCantidadAnulada As Decimal = 0

      Select Case idTipoEstadoAnterior
         Case Entidades.EstadoOrdenProduccion.TipoEstado.PENDIENTE
            deltaCantidadPendiente -= cantidad
         Case Entidades.EstadoOrdenProduccion.TipoEstado.ENPROCESO
            deltaCantidadEnProceso -= cantidad
         Case Entidades.EstadoOrdenProduccion.TipoEstado.FINALIZADO
            deltaCantidadEntregada -= cantidad
         Case Entidades.EstadoOrdenProduccion.TipoEstado.ANULADO
            deltaCantidadAnulada -= cantidad
         Case Else
      End Select

      Select Case idTipoEstadoNuevo
         Case Entidades.EstadoOrdenProduccion.TipoEstado.PENDIENTE
            deltaCantidadPendiente += cantidad
         Case Entidades.EstadoOrdenProduccion.TipoEstado.ENPROCESO
            deltaCantidadEnProceso += cantidad
         Case Entidades.EstadoOrdenProduccion.TipoEstado.FINALIZADO
            deltaCantidadEntregada += cantidad
         Case Entidades.EstadoOrdenProduccion.TipoEstado.ANULADO
            deltaCantidadAnulada += cantidad
         Case Else
      End Select

      sqlPP.ActualizarCantidades(idSucursal,
                                 idTipoComprobante,
                                 letra,
                                 centroEmisor,
                                 numeroOrdenProduccion,
                                 idProducto,
                                 orden,
                                 deltaCantidadPendiente,
                                 deltaCantidadEnProceso,
                                 deltaCantidadEntregada,
                                 deltaCantidadAnulada)
   End Sub

#End Region
End Class
