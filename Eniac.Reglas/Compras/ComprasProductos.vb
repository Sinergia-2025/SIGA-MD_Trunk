Public Class ComprasProductos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ComprasProductos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() GrabaDetalles(DirectCast(entidad, Entidades.CompraProducto)))
   End Sub

#End Region

#Region "Metodos"

   Friend Sub GrabaDetalles(ent As Entidades.CompraProducto)
      Try
         If Publicos.TieneModuloContabilidad Then
            If ContabilidadPublicos.UtilizaCentroCostos Then
               'solo controlo esto si el tipo de comprobante no "Genera Contabilidad"
               If ent.TipoComprobante.GeneraContabilidad Then
                  If ent.CentroCosto Is Nothing Then
                     ent.CentroCosto = ent.ProductoSucursal.Producto.CentroCosto
                  End If
                  If ent.CentroCosto Is Nothing Then
                     Throw New Exception(String.Format("El producto {0} - {1} no tiene asignado un centro de costos. Por favor verifique la configuración y reintente.",
                                                       ent.Producto.IdProducto, ent.Producto.NombreProducto))
                  End If
               End If
            End If
         End If

         If ent.IdUnidadDeMedida = ent.IdUnidadDeMedidaCompra Then
            ent.CantidadUMCompra = ent.Cantidad
            ent.FactorConversionCompra = 1
            ent.PrecioPorUMCompra = ent.Precio
         End If

         Dim sql = New SqlServer.ComprasProductos(da)
         sql.ComprasProductos_I(ent.Compra.IdSucursal, ent.Compra.TipoComprobante.IdTipoComprobante, ent.Compra.Letra, ent.Compra.CentroEmisor,
                                ent.Compra.NumeroComprobante, ent.Compra.Proveedor.IdProveedor,
                                ent.Orden, ent.ProductoSucursal.Producto.IdProducto, ent.Producto.NombreProducto, ent.Cantidad, ent.Precio,
                                ent.DescRecGeneral, ent.DescRecGeneralProducto, ent.DescuentoRecargo, ent.DescuentoRecargoProducto,
                                ent.DescuentoRecargoPorc, ent.PrecioNeto, ent.ImporteTotal, ent.ImporteTotalNeto, ent.PorcentajeIVA, ent.Iva, ent.IdConcepto,
                                ent.PasajeMovimientos, ent.MontoAplicado, ent.MontoSaldo, ent.ProporcionalImp, ent.IdCentroCosto, ent.IdaAtributoProducto01,
                                ent.IdaAtributoProducto02, ent.IdaAtributoProducto03, ent.IdaAtributoProducto04, ent.IdDeposito, ent.IdUbicacion,
                                ent.InformeCalidadNumero, ent.InformeCalidadLink, ent.IdLote, ent.FechaVencimientoLote,
                                ent.CantidadUMCompra, ent.FactorConversionCompra, ent.PrecioPorUMCompra, ent.IdUnidadDeMedida, ent.IdUnidadDeMedidaCompra)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Sub Eliminar(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                       idProveedor As Long, orden As Integer, idProducto As String)
      Dim sql = New SqlServer.ComprasProductos(da)
      sql.ComprasProductos_D(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                             idProveedor, orden, idProducto)
   End Sub

   Public Function GetDetallePorProductos(idSucursal As Integer, desde As Date?, hasta As Date?,
                                          idProducto As String,
                                          idMarca As Integer, rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subsubrubros As Entidades.SubSubRubro(),
                                          idTipoComprobante As String, idComprador As Integer, idProveedor As Long,
                                          grabaLibro As String, afectaCaja As String, idFormaDePago As Integer,
                                          cantidad As String, periodoFiscalDesde As Integer, periodoFiscalHasta As Integer,
                                          top As Integer, orderBy As Entidades.ComprasProductos_GetDetallePorProductos_OrderBy) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.ComprasProductos(da)
            Return sql.GetDetallePorProductos(
                           idSucursal, desde, hasta,
                           idProducto,
                           idMarca, rubros, subrubros, subsubrubros,
                           idTipoComprobante, idComprador, idProveedor,
                           grabaLibro, afectaCaja, idFormaDePago,
                           cantidad, actual.NivelAutorizacion, periodoFiscalDesde, periodoFiscalHasta,
                           top, orderBy)
         End Function)
   End Function

   Public Function GetCostoPromedioPonderado(idSucursal As Integer, idProducto As String,
                                             desde As Date, hasta As Date, decimalesRedondeoEnPrecio As Integer) As Decimal
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.ComprasProductos(da)
            Return sql.GetCostoPromedioPonderado(idSucursal, idProducto, desde, hasta, decimalesRedondeoEnPrecio)
         End Function)
   End Function

   Public Function GetUnaParaPasaje(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                    idProveedor As Long, orden As Long, idConcepto As Integer) As Entidades.CompraProducto
      Dim stb = New StringBuilder()
      With stb
         .Append("SELECT IdSucursal")
         .Append(" ,IdTipoComprobante")
         .Append(" ,Letra")
         .Append(" ,CentroEmisor")
         .Append(" ,NumeroComprobante")
         .Append(" ,idProveedor")
         .Append(" ,Orden")
         .Append(" ,IdConcepto")
         .Append(" ,PasajeMovimiento")
         .Append(" ,MontoAplicado")
         .Append(" ,MontoSaldo").AppendLine()
         .AppendLine(" FROM ComprasProductos ")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroComprobante = {0}", numeroComprobante).AppendLine()
         .AppendFormat("   AND IdProveedor = '{0}'", idProveedor).AppendLine()
         .AppendFormat("   AND Orden = {0}", orden).AppendLine()
         .AppendFormat("   AND IdConcepto = {0}", idConcepto).AppendLine()
      End With

      Using dt = da.GetDataTable(stb.ToString())
         Dim ComprasProductos = New Entidades.CompraProducto()
         If dt.Rows.Count > 0 Then
            With ComprasProductos
               .IdSucursal = Integer.Parse(dt.Rows(0)("IdSucursal").ToString())
               .Letra = dt.Rows(0)("Letra").ToString()
               .CentroEmisor = Short.Parse(dt.Rows(0)("CentroEmisor").ToString())
               .TipoComprobante = New Eniac.Reglas.TiposComprobantes(da).GetUno(dt.Rows(0)("IdTipoComprobante").ToString())
               .NumeroComprobante = Long.Parse(dt.Rows(0)("NumeroComprobante").ToString())
               .Compra.Proveedor.IdProveedor = Long.Parse(dt.Rows(0)("IDProveedor").ToString)
               .Orden = Integer.Parse(dt.Rows(0)("Orden").ToString)
               .IdConcepto = Integer.Parse(dt.Rows(0)("IdConcepto").ToString())
               .PasajeMovimientos = Boolean.Parse(dt.Rows(0)("PasajeMovimiento").ToString())
               .MontoAplicado = Decimal.Parse(dt.Rows(0)("MontoAplicado").ToString())
               .MontoSaldo = Decimal.Parse(dt.Rows(0)("MontoSaldo").ToString())
            End With
         Else
            Throw New Exception("No existe la linea de la compra")
         End If
         Return ComprasProductos
      End Using
   End Function

   Public Sub ModificarMontoAplicar(ent As Entidades.CompraProducto)
      EjecutaConTransaccion(Sub() _ModificarMontoAplicar(ent))
   End Sub

   Friend Sub _ModificarMontoAplicar(ent As Entidades.CompraProducto)
      Dim sql = New SqlServer.ComprasProductos(da)
      sql.ModificarMontoAplicar(ent.IdSucursal,
                                ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                ent.Compra.Proveedor.IdProveedor, ent.Orden, ent.IdConcepto,
                                ent.PasajeMovimientos, ent.MontoAplicado, ent.MontoSaldo)
   End Sub

   Public Function GetComprobantesOrdenControlCalidad(idProducto As String) As DataTable
      Return EjecutaConConexion(Function() _GetComprobantesOrdenControlCalidad(idProducto:=idProducto, agregarSeleccionMultiple:=False, fechaDesde:=Nothing, fechaHasta:=Nothing, tiposComprobantes:=Nothing, idProveedor:=0))
   End Function
   Public Function GetComprobantesOrdenControlCalidad(agregarSeleccionMultiple As Boolean, fechaDesde As Date?, fechaHasta As Date?, tiposComprobantes As Entidades.TipoComprobante(), idProveedor As Long, idProducto As String) As DataTable
      Return EjecutaConConexion(Function() _GetComprobantesOrdenControlCalidad(agregarSeleccionMultiple, fechaDesde, fechaHasta, tiposComprobantes, idProveedor, idProducto))
   End Function
   Private Function _GetComprobantesOrdenControlCalidad(agregarSeleccionMultiple As Boolean, fechaDesde As Date?, fechaHasta As Date?,
                                                        tiposComprobantes As Entidades.TipoComprobante(), idProveedor As Long, idProducto As String) As DataTable
      Dim dt = New SqlServer.ComprasProductos(da).GetComprobantesOrdenControlCalidad(fechaDesde, fechaHasta, tiposComprobantes, idProveedor, idProducto)
      If agregarSeleccionMultiple Then
         dt.Columns.Add("Selec", GetType(Boolean))
         dt.ForEach(Sub(dr) dr("Selec") = False)
      End If
      Return dt
   End Function
   Public Sub ActualizaFechaActualizacionCalidad(ent As Entidades.CalidadOrdenDeControl, fecha As Date?)
      Dim sql = New SqlServer.ComprasProductos(da)
      sql.ComprasProductos_UFechaActualizacionCalidad(ent.IdSucursalCompra, ent.IdTipoComprobanteCompra, ent.LetraCompra, ent.CentroEmisorCompra, ent.NumeroComprobanteCompra,
                                                      ent.OrdenComprobanteCompra, ent.IdProducto,
                                                      fecha)
   End Sub
#End Region

End Class