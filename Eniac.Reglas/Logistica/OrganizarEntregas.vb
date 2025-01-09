Imports Eniac.Entidades

Public Class OrganizarEntregas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      da = accesoDatos
   End Sub
#End Region

   Private Function GetSql() As SqlServer.OrganizarEntregas
      Return New SqlServer.OrganizarEntregas(da)
   End Function

#Region "Metodos Publicos"

   Public Function GetPedidos(fechaDesde As Date, fechaHasta As Date) As DataTable
      Return EjecutaConConexion(Function() GetSql().GetPedidos(fechaDesde, fechaHasta))
   End Function

   Public Function GetPedidosProductos(fechaDesde As Date, fechaHasta As Date) As DataTable
      Return EjecutaConConexion(Function() GetSql().GetPedidosProductos(fechaDesde, fechaHasta, 0, 0, "", False, ""))
   End Function

   Public Function GetPedidosProductosFiltrados(fechaDesde As Date, fechaHasta As Date, distribucion As Integer,
                                       IdEmpleado As Integer, producto As String,
                                       sinStock As Boolean, NombreProducto As String) As DataTable
      Return EjecutaConConexion(Function() GetSql().GetPedidosProductosFiltrados(fechaDesde, fechaHasta, distribucion, IdEmpleado, producto, sinStock, NombreProducto))
   End Function

   Public Function GetPedidosSinFacturar(fechaDesde As Date) As DataTable
      Return EjecutaConConexion(Function() GetSql().GetPedidosSinFacturar(fechaDesde))
   End Function

   Public Function GetPedidosSinFacturarV2(fechaDesde As Date) As DataTable
      Return EjecutaConConexion(Function() GetSql().GetPedidosSinFacturarV2(fechaDesde))
   End Function

   Public Function GetPedidosFiltrados(fechaDesde As Date, fechaHasta As Date, distribucion As Integer,
                                       IdEmpleado As Integer, producto As String,
                                       sinStock As Boolean, NombreProducto As String) As DataTable
      Return EjecutaConConexion(Function() GetSql().GetPedidosFiltrados(fechaDesde, fechaHasta,
                                                                        distribucion, IdEmpleado,
                                                                        producto, sinStock, NombreProducto))
   End Function

   Public Function GetArticulosSinStock(fechaDesde As Date, fechaHasta As Date) As DataTable
      Return EjecutaConConexion(Function() GetSql().GetArticulosSinStock(fechaDesde, fechaHasta))
   End Function

   Public Function GetArticulosSinStockPedidos(fechaDesde As Date, fechaHasta As Date) As DataTable
      Return EjecutaConConexion(Function() GetSql().GetArticulosSinStockPedidos(fechaDesde, fechaHasta))
   End Function

   Public Function ArticulosSinStockFiltrados(fechaDesde As Date, fechaHasta As Date, distribucion As Integer,
                                              idEmpleado As Integer, producto As String) As DataTable
      Return EjecutaConConexion(Function() GetSql().ArticulosSinStockFiltrados(fechaDesde, fechaHasta, distribucion, idEmpleado, producto))
   End Function

   Public Function ArticulosSinStockPedidosFiltrados(fechaDesde As Date, fechaHasta As Date, distribucion As Integer,
                                                     idEmpleado As Integer, producto As String) As DataTable
      Return EjecutaConConexion(Function() GetSql().ArticulosSinStockPedidosFiltrados(fechaDesde, fechaHasta, distribucion, idEmpleado, producto))
   End Function

   Public Function ConsolidadoCargaMercaderia(idSucursal As Integer,
                                              fechaDesde As Date?, fechaHasta As Date?,
                                              nroRep As Integer(), dist As Integer, Idvend As Integer) As DataTable
      Return EjecutaConConexion(Function() GetSql().ConsolidadoCargaMercaderia(idSucursal, fechaDesde, fechaHasta, nroRep, dist, Idvend, Publicos.ProductoCodigoNumerico))
   End Function

   Public Function ListadoDeClientes(idSucursal As Integer,
                                     fechaDesde As Date?, fechaHasta As Date?,
                                     nroRep As Integer, nroRepH As Integer,
                                     dist As Integer,
                                     idvend As Integer) As DataTable
      Return EjecutaConConexion(Function() _ListadoDeClientes(idSucursal, fechaDesde, fechaHasta, nroRep, nroRepH, dist, idvend))
   End Function

   Private Function _ListadoDeClientes(idSucursal As Integer,
                                       fechaDesde As Date?, fechaHasta As Date?,
                                       nroRep As Integer, nroRepH As Integer,
                                       dist As Integer, Idvend As Integer) As DataTable
      Return GetSql().ListadoDeClientes(idSucursal, fechaDesde, fechaHasta, nroRep, nroRepH, dist, Idvend)
   End Function

   Public Function ListadoDeClientesConEnvases(idSucursal As Integer,
                                               fechaDesde As Date?, fechaHasta As Date?,
                                               nroRep As Integer, nroRepH As Integer,
                                               dist As Integer, Idvend As Integer) As DataTable
      Return EjecutaConConexion(
      Function()
         Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
         Dim cantidad As Decimal = Nothing
         Dim dtClientes As DataTable = _ListadoDeClientes(idSucursal, fechaDesde, fechaHasta, nroRep, nroRepH, dist, Idvend)

         Dim sqlVP As SqlServer.VentasProductos = New SqlServer.VentasProductos(da)

         For Each drClientes As DataRow In dtClientes.Rows
            Dim dtProductos As DataTable = sqlVP.GetProductosParaProduccion(drClientes.ValorNumericoPorDefecto("IdSucursal", actual.Sucursal.Id),
                                                                            drClientes("IdTipoComprobante").ToString(),
                                                                            drClientes("Letra").ToString(),
                                                                            drClientes.ValorNumericoPorDefecto("CentroEmisor", 0S),
                                                                            drClientes.ValorNumericoPorDefecto("NumeroComprobante", 0L))
            Dim dtComp As DataTable = New Eniac.Reglas.ProductosComponentes(da)._GetComponentesProduccion(dtProductos, Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal)
            For Each drComp As DataRow In dtComp.Rows
               Dim drProductoComp As DataRow = cache.BuscaProductoPorId(drComp("IdProductoComponente").ToString())
               If drProductoComp IsNot Nothing Then
                  Dim ordenProductoComp As Integer = drProductoComp.ValorNumericoPorDefecto("Orden", 0I)
                  AgregarCantidadEnvaseEnColumnaOrden(drClientes, ordenProductoComp, drComp.ValorNumericoPorDefecto("CantidadNec", 0D))
                  cantidad = drComp.ValorNumericoPorDefecto("CantidadNec", 0D) / drComp.ValorNumericoPorDefecto("NECESITOX1", 1D)
                  AgregarCantidadCajones(drClientes, ordenProductoComp, cantidad)
               End If
            Next
         Next

         Return dtClientes

      End Function)
   End Function

   Private Sub AgregarCantidadEnvaseEnColumnaOrden(drClientes As DataRow, orden As Integer, cantidad As Decimal)
      Dim dtClientes As DataTable = drClientes.Table
      Dim nombreColumnaOrden As String = String.Format("orden_{0}", orden)
      If Not dtClientes.Columns.Contains(nombreColumnaOrden) Then
         dtClientes.Columns.Add(nombreColumnaOrden, GetType(Decimal))
      End If
      drClientes(nombreColumnaOrden) = drClientes.ValorNumericoPorDefecto(nombreColumnaOrden, 0D) + cantidad
   End Sub

   Private Sub AgregarCantidadCajones(drClientes As DataRow, orden As Integer, cantidad As Decimal)
      Dim dtClientes As DataTable = drClientes.Table
      Dim nombreColumnaOrden As String = String.Format("orden_cajon_{0}", orden)

      If Not dtClientes.Columns.Contains(nombreColumnaOrden) Then
         dtClientes.Columns.Add(nombreColumnaOrden, GetType(Decimal))
      End If

      drClientes(nombreColumnaOrden) = drClientes.ValorNumericoPorDefecto(nombreColumnaOrden, 0D) + cantidad
   End Sub

#End Region

   Public Function GetEsqueletos(dt As DataTable) As DataTable
      Dim dtComp = New DsOrganizarEntregas.DtComposicionMercaderiaDataTable()

      Dim dtProductos = New DataTable()
      dtProductos.Columns.Add("IdProducto", GetType(String))
      dtProductos.Columns.Add("Cantidad", GetType(Decimal))
      dtProductos.Columns.Add("IdFormula", GetType(Integer))
      Dim prevIdTransportista As Integer = 0
      Dim prevNombreTransportista As String = String.Empty
      For Each dr As DataRow In dt.Rows
         'If True Then
         '   dr("Orden") = dr("IdProducto")
         'Else
         '   dr("Orden") = dr("NombreProducto").ToString() + dr("IdProducto").ToString()
         'End If
         If prevIdTransportista = 0 Then
            prevIdTransportista = CInt(dr("IdTransportista"))
            prevNombreTransportista = dr("NombreTransportista").ToString()
         End If
         If prevIdTransportista <> CInt(dr("IdTransportista")) Then
            dtComp.Merge(New Eniac.Reglas.ProductosComponentes().GetComponentesProduccion(dtProductos, Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal))
            For Each drComp As Entidades.DsOrganizarEntregas.DtComposicionMercaderiaRow In dtComp.Rows
               If drComp.IsIdTransportistaNull Then
                  drComp.IdTransportista = prevIdTransportista
                  drComp.NombreTransportista = prevNombreTransportista
               End If
            Next
            dtProductos.Clear()
            prevIdTransportista = CInt(dr("IdTransportista"))
            prevNombreTransportista = dr("NombreTransportista").ToString()
         End If

         Dim drcol() As DataRow = dtProductos.Select("IdProducto = '" + dr("IdProducto").ToString().Trim() + "'")
         Dim drProducto As DataRow
         If drcol.Length = 0 Then
            drProducto = dtProductos.NewRow()
            drProducto("IdProducto") = dr("IdProducto").ToString().Trim()
            drProducto("Cantidad") = 0
            drProducto("IdFormula") = 1
            dtProductos.Rows.Add(drProducto)
         Else
            drProducto = drcol(0)
         End If

         drProducto("Cantidad") = CDec(drProducto("Cantidad")) + CDec(dr("Cantidad"))

      Next

      If dtProductos.Rows.Count > 0 Then
         dtComp.Merge(New ProductosComponentes().GetComponentesProduccion(dtProductos, actual.Sucursal.IdSucursal), preserveChanges:=False, MissingSchemaAction.Ignore)
         For Each drComp As Entidades.DsOrganizarEntregas.DtComposicionMercaderiaRow In dtComp.Rows
            If drComp.IsIdTransportistaNull Then
               drComp.IdTransportista = prevIdTransportista
               drComp.NombreTransportista = prevNombreTransportista
            End If
         Next
      End If
      dtProductos.Clear()

      Return dtComp
   End Function

#Region "OrganizarEntregaV2"
   Public Function GetPedidosSolos(fechaDesde As Date, fechaHasta As Date, distribucion As Integer,
                                   IdEmpleado As Integer, producto As String,
                                   sinStock As Boolean, NombreProducto As String, pedidos As Boolean, reenvios As Boolean,
                                   ordenProducto As Integer?,
                                   IdLocalidad As Integer?,
                                   IdCliente As Long?) As DataTable
      Try
         Dim usaFechaEnvio As Boolean = Reglas.Publicos.OrganizarEntregaFiltraFechaEnvio
         Me.da.OpenConection()
         Dim sql As SqlServer.OrganizarEntregas = GetSql()
         Dim dtPedidos As DataTable = sql.GetPedidosV2(fechaDesde, fechaHasta, distribucion,
                                                       IdEmpleado, producto,
                                                       sinStock, NombreProducto, actual.Sucursal.Id,
                                                       usaFechaEnvio, pedidos, reenvios,
                                                       ordenProducto,
                                                       IdLocalidad,
                                                       IdCliente)
         Return dtPedidos
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function GetPedidosYProductos(fechaDesde As Date, fechaHasta As Date, distribucion As Integer,
                                        IdEmpleado As Integer, producto As String,
                                        sinStock As Boolean, nombreProducto As String, origen As Entidades.OrganizarEntregas.Origen,
                                        ordenProducto As Integer?,
                                        IdLocalidad As Integer?,
                                        IdCliente As Long?) As DataSet
      Try
         Dim usaFechaEnvio As Boolean = Reglas.Publicos.OrganizarEntregaFiltraFechaEnvio
         Me.da.OpenConection()
         Dim ds As DataSet = New DataSet()

         Dim pedidos As Boolean = origen = Entidades.OrganizarEntregas.Origen.TODOS Or origen = Entidades.OrganizarEntregas.Origen.PEDIDOS
         Dim reenvios As Boolean = origen = Entidades.OrganizarEntregas.Origen.TODOS Or origen = Entidades.OrganizarEntregas.Origen.VENTAS

         Dim sql As SqlServer.OrganizarEntregas = GetSql()

         Dim dtPedidos As DataTable = sql.GetPedidosV2(fechaDesde, fechaHasta, distribucion,
                                                       IdEmpleado, producto,
                                                       sinStock, nombreProducto, actual.Sucursal.Id,
                                                       usaFechaEnvio, pedidos, reenvios,
                                                       ordenProducto,
                                                       IdLocalidad,
                                                       IdCliente)
         ds.Tables.Add("Pedidos", dtPedidos)

         Dim dtProductos As DataTable = sql.GetPedidosProductosV2(fechaDesde, fechaHasta, distribucion,
                                                                  IdEmpleado, producto,
                                                                  sinStock, nombreProducto, actual.Sucursal.Id,
                                                                  usaFechaEnvio, pedidos, reenvios,
                                                                  ordenProducto,
                                                                  IdLocalidad,
                                                                  IdCliente)
         ds.Tables.Add("Productos", dtProductos)

         Dim Relacion As DataRelation
         Relacion = New DataRelation("Productos",
                                     {dtPedidos.Columns("IdSucursal"), dtPedidos.Columns("IdTipoComprobante"), dtPedidos.Columns("Letra"), dtPedidos.Columns("CentroEmisor"), dtPedidos.Columns("NumeroPedido")},
                                     {dtProductos.Columns("IdSucursal"), dtProductos.Columns("IdTipoComprobante"), dtProductos.Columns("Letra"), dtProductos.Columns("CentroEmisor"), dtProductos.Columns("NumeroPedido")})
         ds.Relations.Add(Relacion)

         Dim dtSinStock As DataTable = sql.GetArticulosSinStockV2(fechaDesde, fechaHasta, distribucion,
                                                                  IdEmpleado, producto,
                                                                  sinStock, nombreProducto, actual.Sucursal.IdSucursal,
                                                                  usaFechaEnvio, pedidos, reenvios,
                                                                  ordenProducto,
                                                                  IdLocalidad,
                                                                  IdCliente)
         ds.Tables.Add("ProductosSinStock", dtSinStock)

         Dim dtSinStockDetalle As DataTable = GetProductosSinStockDetalle(ds)
         ds.Tables.Add("ProductosSinStockDetalle", dtSinStockDetalle)

         Relacion = New DataRelation("ProductosSinStock",
                                     {dtSinStock.Columns("IdProducto")},
                                     {dtSinStockDetalle.Columns("IdProducto")})
         ds.Relations.Add(Relacion)

         Return ds
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Private Function GetProductosSinStockDetalle(ds As DataSet) As DataTable
      Dim dt As DataTable = New DataTable()
      dt.Columns.Add("IdProducto", GetType(String))
      dt.Columns.Add("NombreProducto", GetType(String))
      dt.Columns.Add("IdSucursal", GetType(Integer))
      dt.Columns.Add("IdTipoComprobante", GetType(String))
      dt.Columns.Add("Letra", GetType(String))
      dt.Columns.Add("CentroEmisor", GetType(Short))
      dt.Columns.Add("NumeroPedido", GetType(Long))
      dt.Columns.Add("Stock", GetType(Decimal))
      dt.Columns.Add("Cantidad", GetType(Decimal))
      dt.Columns.Add("IdCliente", GetType(Long))
      dt.Columns.Add("CodigoCliente", GetType(Long))
      dt.Columns.Add("NombreCliente", GetType(String))
      dt.Columns.Add("TipoOperacion", GetType(String))

      For Each drProductosSinStock As DataRow In ds.Tables("ProductosSinStock").Rows
         For Each drProductos As DataRow In ds.Tables("Productos").Select(String.Format("IdProducto = '{0}'", drProductosSinStock("IdProducto")))
            Dim dr As DataRow = dt.NewRow()
            dt.Rows.Add(dr)
            dr("IdProducto") = drProductos("IdProducto")
            dr("NombreProducto") = drProductos("NombreProducto")
            dr("IdSucursal") = drProductos("IdSucursal")
            dr("IdTipoComprobante") = drProductos("IdTipoComprobante")
            dr("Letra") = drProductos("Letra")
            dr("CentroEmisor") = drProductos("CentroEmisor")
            dr("NumeroPedido") = drProductos("NumeroPedido")
            dr("Cantidad") = drProductos("Cantidad")
            dr("Stock") = drProductosSinStock("Stock")
            dr("TipoOperacion") = drProductos("TipoOperacion")
            For Each drCliente As DataRow In ds.Tables("Pedidos").Select(String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroPedido = {4}",
                                                                                       drProductos("IdSucursal"),
                                                                                       drProductos("IdTipoComprobante"),
                                                                                       drProductos("Letra"),
                                                                                       drProductos("CentroEmisor"),
                                                                                       drProductos("NumeroPedido")))
               dr("CodigoCliente") = drCliente("CodigoCliente")
               dr("NombreCliente") = drCliente("NombreCliente")
            Next        'For Each drCliente
         Next           'For Each drProductos
      Next              'For Each drProductosSinStock

      Return dt
   End Function

#End Region

End Class
