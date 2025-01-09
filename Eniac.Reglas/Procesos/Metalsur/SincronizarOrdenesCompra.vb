Imports System.Web.Script.Serialization
Public Class SincronizarOrdenesCompra
   Inherits Reglas.Base

   Private Const TagImpProv As String = "Imp. Proveedores"
   Private Const TagImpOC As String = "Imp. Ord. Compra"
   Private Const TagImpOCAutor As String = "Imp. Ord. Compra Autorizadas"


   Private Const TagSendProv As String = "Enviar Proveedores"
   Private Const TagSendOC As String = "Enviar Ord. Compra"

   Public Event Avance(sender As Object, e As AvanceSincronizarOrdenesCompraEventArgs)

   Private _idFuncion As String

#Region "Constructores"
   Public Sub New(idFuncion As String)
      Me.New(New Datos.DataAccess(), idFuncion)
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess, idFuncion As String)
      Me.NombreEntidad = ""   'No es regla de una tabla específica
      da = accesoDatos
      _idFuncion = idFuncion
   End Sub

#End Region

#Region "Sincronizar"
   Public Sub Sincronizar(reimportar As Boolean, reenviar As Boolean, enviarWebProveedores As Boolean, exportarProveedores As Boolean, enviarWebOrdenCompra As Boolean, exportarOrdenCompra As Boolean, descargartodo As Boolean)
      ImportarDesdeBejerman(reimportar)
      EnviarWeb(reenviar, enviarWebProveedores, exportarProveedores, enviarWebOrdenCompra, exportarOrdenCompra)
      DescargarRespuestas(descargartodo)
   End Sub

#End Region

#Region "ImportarDesdeBejerman"
   Public Sub ImportarDesdeBejerman(reimportar As Boolean)
      EjecutaConConexion(Sub() _ImportarDesdeBejerman(reimportar))
   End Sub

   Private Sub _ImportarDesdeBejerman(reimportar As Boolean)

      Dim fechaDesdeOrdenCompraAutorizadas = If(reimportar, Today.AddMonths(-6), Publicos.BejermanMetalsur.FechaModificacionOrdenCompraAutorizadas.IfNull(Today.AddMonths(-6)))
      Dim fechaHastaOrdenCompraAutorizadas As DateTime? = Nothing

      Dim fechaDesdeProveedor = If(reimportar, Today.AddMonths(-6), Publicos.BejermanMetalsur.FechaModificacionProveedor.IfNull(Today.AddMonths(-6)))
      Dim fechaHastaProveedor As DateTime? = Nothing

      Dim fechaDesdeOrdenCompra = If(reimportar, Today.AddMonths(-6), Publicos.BejermanMetalsur.FechaModificacionOrdenCompra.IfNull(Today.AddMonths(-6)))
      Dim fechaHastaOrdenCompra As DateTime? = Nothing
      Dim nombreBase As String = String.Concat(Publicos.CalidadBaseExternaClientes, ".dbo.")


      'ImportarProveedoresDesdeBejerman
      Dim fechaModProveedor = ImportarProveedoresDesdeBejerman(nombreBase, fechaDesdeProveedor, fechaHastaProveedor)
      If fechaModProveedor.HasValue Then
         Publicos.WebArchivos.GuardarFechaUltimaDescarga(fechaModProveedor.Value, Entidades.Parametro.Parametros.BEJERMANFECHAMODIFICACIONPROVEEDOR, da)
      End If

      'ImportarOrdenesCompraAutorizadasDesdeBejerman
      Dim fechaModOrdenCompraAutorizada = ImportarOrdenesCompraAutorizadasDesdeBejerman(nombreBase, fechaDesdeOrdenCompraAutorizadas, fechaHastaOrdenCompraAutorizadas)
      If fechaModOrdenCompraAutorizada.HasValue Then
         Publicos.WebArchivos.GuardarFechaUltimaDescarga(fechaModOrdenCompraAutorizada.Value, Entidades.Parametro.Parametros.BEJERMANFECHAMODIFOCAUTORIZADAS, da)
      End If

      'ImportarOrdenesCompraDesdeBejerman
      Dim fechaModOrdenCompra = ImportarOrdenesCompraDesdeBejerman(nombreBase, fechaDesdeOrdenCompra, fechaHastaOrdenCompra)
      If fechaModOrdenCompra.HasValue Then
         Publicos.WebArchivos.GuardarFechaUltimaDescarga(fechaModOrdenCompra.Value, Entidades.Parametro.Parametros.BEJERMANFECHAMODIFICACIONORDENCOMPRA, da)
      End If

      Publicos.WebArchivos.GuardarFechaUltimaDescarga(DateTime.Now, Entidades.Parametro.Parametros.BEJERMANFECHAULTIMASINCRONIZACIONOC, da)

   End Sub

   Private Function ImportarProveedoresDesdeBejerman(nombreBase As String, fechaDesde As DateTime?, fechaHasta As DateTime?) As DateTime?
      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpProv, Nothing, Nothing, "Leyendo Proveedores de Bejerman"))
      Using dtP = New SqlServer.SincronizarOrdenesCompra(da).GetProveedoresBejerman(nombreBase, fechaDesde, fechaHasta)
         Return EjecutaSoloConTransaccion(Function() GrabarProveedoresDesdeBejerman(dtP))
      End Using
   End Function
   Private Function GrabarProveedoresDesdeBejerman(dt As DataTable) As DateTime?
      Dim result As DateTime? = Nothing
      Dim cache = New BusquedasCacheadas()
      Dim rFormaPago = New VentasFormasPago(da)
      Dim dicLocalidades = New Dictionary(Of Integer, Entidades.Localidad)()
      Dim dicMapCategorias = New Dictionary(Of Integer, Integer) From {{1, 2}, {2, 2}, {3, 2}, {4, 4}, {5, 1}, {6, 6}}

      Dim categoria = New CategoriasProveedores(da).GetPrimeroCategoria(AccionesSiNoExisteRegistro.Excepcion)
      Dim cuentaBanco = New CuentasBancos(da).GetUna(Publicos.CtaBancoTransfBancaria)
      Dim cuentaCaja = New CuentasDeCajas(da).GetUna(Publicos.CtaCajaPago)
      Dim rubroCompras = cache.GetPrimerRubroCompras()

      Dim rProvee = New Proveedores(da)
      Dim registroActual = 0I
      Dim registrosTotal = dt.Rows.Count
      For Each dr As DataRow In dt.Rows
         registroActual += 1
         Dim codigoProveedor = dr.Field(Of String)("pro_Cod")
         Dim nombreProveedor = dr.Field(Of String)("pro_RazSoc").Replace("'", "´")
         Dim fechaModificacion = dr.Field(Of DateTime?)("pro_FecMod")
         If Not result.HasValue Then
            result = fechaModificacion
         Else
            If fechaModificacion.HasValue Then
               If fechaModificacion.Value > result.Value Then
                  result = fechaModificacion
               End If
            End If
         End If

         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpProv, registroActual, registrosTotal, String.Format("{0} - {1}", codigoProveedor, nombreProveedor)))

         Dim proveedor = rProvee.GetUnoPorCodigoLetrasExacto(codigoProveedor, incluirFoto:=False, accion:=AccionesSiNoExisteRegistro.Nulo)

         If proveedor Is Nothing Then
            proveedor = New Entidades.Proveedor()
            proveedor.CodigoProveedor = -1
            proveedor.CodigoProveedorLetras = codigoProveedor
            proveedor.NombreProveedor = nombreProveedor
            proveedor.DireccionProveedor = dr.Field(Of String)("pro_Direc").Replace("'", "´")

            Dim localidad = BuscarLocalidades(dicLocalidades, cache, dr)
            proveedor.IdLocalidadProveedor = localidad.IdLocalidad
            proveedor.TelefonoProveedor = dr.Field(Of String)("pro_Tel")
            proveedor.FaxProveedor = dr.Field(Of String)("pro_Fax")
            proveedor.CorreoElectronico = dr.Field(Of String)("pro_EMail")

            Dim codigoCategoriaFiscal = dr.Field(Of String)("prosiv_Cod").ToInt32.IfNull(1)
            Dim idCategoriaFiscal = dicMapCategorias(codigoCategoriaFiscal)
            proveedor.CategoriaFiscal = cache.BuscaCategoriaFiscal(idCategoriaFiscal)
            proveedor.TipoDocProveedor = dr.Field(Of Short)("protdc_Cod").ToString()
            proveedor.NroDocProveedor = dr.Field(Of String)("pro_CUIT").ToInt64().IfNull()
            proveedor.Activo = dr.Field(Of Boolean)("pro_Habilitado")

            Dim codigoFormaPago = dr.Field(Of String)("procpg_Cod")
            Dim formaPago = cache.BuscaFormasPago(codigoFormaPago)
            If formaPago Is Nothing Then
               formaPago = rFormaPago._Insertar(codigoFormaPago)
            End If
            proveedor.IdFormasPago = formaPago.IdFormasPago
            proveedor.Categoria = categoria
            proveedor.CuentaBanco = cuentaBanco
            proveedor.CuentaDeCaja = cuentaCaja
            proveedor.RubroCompra = rubroCompras

            rProvee.Inserta(proveedor)
         Else
            proveedor.NombreProveedor = nombreProveedor
            proveedor.DireccionProveedor = dr.Field(Of String)("pro_Direc").Replace("'", "´")

            Dim localidad = BuscarLocalidades(dicLocalidades, cache, dr)
            proveedor.IdLocalidadProveedor = localidad.IdLocalidad
            proveedor.TelefonoProveedor = dr.Field(Of String)("pro_Tel")
            proveedor.FaxProveedor = dr.Field(Of String)("pro_Fax")
            proveedor.CorreoElectronico = dr.Field(Of String)("pro_EMail")

            Dim codigoCategoriaFiscal = dr.Field(Of String)("prosiv_Cod").ToInt32.IfNull(1)
            Dim idCategoriaFiscal = dicMapCategorias(codigoCategoriaFiscal)
            proveedor.CategoriaFiscal = cache.BuscaCategoriaFiscal(idCategoriaFiscal)
            proveedor.TipoDocProveedor = dr.Field(Of Short)("protdc_Cod").ToString()
            proveedor.NroDocProveedor = dr.Field(Of String)("pro_CUIT").ToInt64().IfNull()
            proveedor.Activo = dr.Field(Of Boolean)("pro_Habilitado")

            Dim codigoFormaPago = dr.Field(Of String)("procpg_Cod")
            Dim formaPago = cache.BuscaFormasPago(codigoFormaPago)
            If formaPago Is Nothing Then
               formaPago = rFormaPago._Insertar(codigoFormaPago)
            End If
            proveedor.IdFormasPago = formaPago.IdFormasPago

         End If
      Next

      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpProv, Nothing, Nothing, "Finalizó"))

      Return result
   End Function

   Public Sub ImportarDesdeBejermanOCN(reimportar As Boolean, FechaOCN As DateTime)
      EjecutaConConexion(Sub() _ImportarDesdeBejermanOCN(reimportar, FechaOCN))
   End Sub

   Private Sub _ImportarDesdeBejermanOCN(reimportar As Boolean, FechaOCN As DateTime)

      ' Dim fechaDesdeOrdenCompraAutorizadas = If(reimportar, Today.AddMonths(-6), Publicos.BejermanMetalsur.FechaModificacionOrdenCompraAutorizadas.IfNull(Today.AddMonths(-6)))
      Dim fechaDesdeOrdenCompraAutorizadas As DateTime = FechaOCN
      Dim fechaHastaOrdenCompraAutorizadas As DateTime? = Nothing 'Today.UltimoDiaMes()

      Dim nombreBase As String = String.Concat(Publicos.CalidadBaseExternaClientes, ".dbo.")

      'ImportarOrdenesCompraAutorizadasDesdeBejermanOCN
      Dim fechaModOrdenCompraAutorizada = ImportarOrdenesCompraAutorizadasDesdeBejermanOCN(nombreBase, fechaDesdeOrdenCompraAutorizadas, fechaHastaOrdenCompraAutorizadas)


   End Sub

   Public Sub ImportarDesdeBejermanFE(reimportar As Boolean, FechaFE As DateTime)
      EjecutaConConexion(Sub() _ImportarDesdeBejermanFE(reimportar, FechaFE))
   End Sub

   Private Sub _ImportarDesdeBejermanFE(reimportar As Boolean, FechaFE As DateTime)


      ' Dim fechaDesdeOrdenCompra = If(reimportar, Today.AddMonths(-6), Publicos.BejermanMetalsur.FechaModificacionOrdenCompra.IfNull(Today.AddMonths(-6)))
      Dim fechaDesdeOrdenCompra = FechaFE
      Dim fechaHastaOrdenCompra As DateTime? = Nothing 'Today.UltimoDiaMes()
      Dim nombreBase As String = String.Concat(Publicos.CalidadBaseExternaClientes, ".dbo.")

      'ImportarOrdenesCompraDesdeBejermanFE
      Dim fechaModOrdenCompra = ImportarOrdenesCompraDesdeBejermanModificacionFE(nombreBase, fechaDesdeOrdenCompra, fechaHastaOrdenCompra)

   End Sub


   Private Function BuscarLocalidades(dicLocalidades As Dictionary(Of Integer, Entidades.Localidad), cache As BusquedasCacheadas, dr As DataRow) As Entidades.Localidad
      Dim idLocalidad = dr.Field(Of String)("pro_CodPos").Replace(".", "").ToInt32().IfNull(1)
      Dim nombreLocalidad = dr.Field(Of String)("pro_Loc")
      If Not dicLocalidades.ContainsKey(idLocalidad) Then
         Dim localidad = cache.BuscaLocalidad(idLocalidad)
         If localidad Is Nothing Then
            If idLocalidad = 0 Then
               localidad = cache.BuscaLocalidadPorNombre(nombreLocalidad)
               If localidad Is Nothing Then
                  localidad = cache.BuscaLocalidad(1)
               Else
                  dicLocalidades.Add(localidad.IdLocalidad, localidad)
               End If
            Else
               Dim rLocalidad = New Localidades()
               Dim locaNueva = New Entidades.Localidad() With {.IdLocalidad = idLocalidad, .NombreLocalidad = nombreLocalidad, .IdProvincia = "1"}
               rLocalidad.Insertar(locaNueva)
               dicLocalidades.Add(idLocalidad, locaNueva)
            End If
         Else
            dicLocalidades.Add(idLocalidad, localidad)
         End If
      End If

      If Not dicLocalidades.ContainsKey(idLocalidad) Then
         Throw New Exception(String.Format("No existe localidad con Id {0} en el diccionario.", idLocalidad))
      End If

      Return dicLocalidades(idLocalidad)
   End Function

   Private Function ImportarOrdenesCompraDesdeBejerman(nombreBase As String, fechaDesde As DateTime?, fechaHasta As DateTime?) As DateTime?
      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Cabeceras de Orden de Compra de Bejerman"))
      Using dtC = New SqlServer.SincronizarOrdenesCompra(da).GetCabecerasBejerman(nombreBase, fechaDesde, fechaHasta, fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing)
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Detalles de Orden de Compra de Bejerman"))
         Using dtD = New SqlServer.SincronizarOrdenesCompra(da).GetDetallesBejerman(nombreBase, fechaDesde, fechaHasta)
            RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Orden de Compra Eliminadas de Bejerman"))
            Using dtE = New SqlServer.SincronizarOrdenesCompra(da).GetOCEliminadasBejerman(nombreBase, fechaDesde, fechaHasta)
               Return EjecutaSoloConTransaccion(Function() GrabarOrdenesCompraDesdeBejerman(dtC, dtD, dtE))
            End Using
         End Using
      End Using
   End Function

   Private Function ImportarOrdenesCompraAutorizadasDesdeBejerman(nombreBase As String, fechaDesde As DateTime?, fechaHasta As DateTime?) As DateTime?
      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Cabeceras de Orden de Compra Autorizadas de Bejerman"))
      Using dtC = New SqlServer.SincronizarOrdenesCompra(da).GetCabecerasAutorizadasBejerman(nombreBase, fechaDesde, fechaHasta, fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing)
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Detalles de Orden de Compra Autorizadas de Bejerman"))
         Using dtD = New SqlServer.SincronizarOrdenesCompra(da).GetDetallesAutorizadasBejerman(nombreBase, fechaDesde, fechaHasta)
            Return EjecutaSoloConTransaccion(Function() GrabarOrdenesCompraAutorizadasDesdeBejerman(dtC, dtD))
         End Using
      End Using
   End Function

   Private Function GrabarOrdenesCompraDesdeBejerman(dtCabecera As DataTable, dtDetalle As DataTable, dtEliminados As DataTable) As DateTime?
      Dim result As DateTime? = Nothing
      Dim dicTipoComprobante = New Dictionary(Of String, Tuple(Of Entidades.TipoComprobante, String, Short))()
      Dim cache = New BusquedasCacheadas()

      'Usamos sql directamente para agilizar el uso y respetar los valores tal cual estan en Bejerman
      Dim sqlPedido = New SqlServer.PedidosProveedores(da)
      Dim sqlProducto = New SqlServer.PedidosProductosProveedores(da)
      Dim sqlEstado = New SqlServer.PedidosEstadosProveedores(da)

      Dim rFormaPago = New VentasFormasPago(da)
      Dim rProducto = New Productos(da)
      Dim col = rProducto._GetTodosObservacion()
      If col.Count = 0 Then
         Throw New Exception("No existe ningún producto configurado como Producto Observación")
      End If
      Dim productoObservacion = col(0)
      Dim tipoImpuesto = New TiposImpuestos(da)._GetUno(Entidades.TipoImpuesto.Tipos.IVA)
      Dim idCriticidad = New Reglas.PedidosCriticidades(da).GetTodos().FirstOrDefault().IdCriticidad
      Dim idEstadoVisita = New Reglas.EstadosVisitas(da)._GetTodos(admitePedidoSinLineas:=Nothing, admintePedidoConLineas:=Nothing).FirstOrDefault().IdEstadoVisita

      Dim registroActual = 0I
      Dim registrosTotal = dtCabecera.Rows.Count

      For Each dr As DataRow In dtCabecera.Rows

         Dim idTipoComprobante = dr.Field(Of String)("spctco_Cod")
         Dim numeroPedido = Long.Parse(dr.Field(Of String)("spc_Nro"))
         Dim fechaModificacion = dr.Field(Of DateTime?)("scc_FecMod")
         Dim fechaAutorizacion = dr.Field(Of DateTime?)("usc_FecMod_Autorizacion")

         If Not result.HasValue Then
            result = fechaModificacion
         Else
            If fechaModificacion.HasValue Then
               If fechaModificacion.Value > result.Value Then
                  result = fechaModificacion
               End If
            End If
         End If

         registroActual += 1
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, registroActual, registrosTotal, String.Format("{0} - {1:00000000}", idTipoComprobante, numeroPedido)))

         If Not dicTipoComprobante.ContainsKey(idTipoComprobante) Then
            AddTipoComprobante(dicTipoComprobante, idTipoComprobante, cache)
         End If
         Dim tipoComprobante = dicTipoComprobante(idTipoComprobante)

         Dim colDrP = dtDetalle.Select(String.Format("spcemp_Codigo = '{0}' AND spcsuc_Cod = '{1}' AND spcscc_ID = {2} AND spctco_Circuito = '{3}' AND spctco_Cod = '{4}'",
                                                        dr.Field(Of String)("spcemp_Codigo"),
                                                        dr.Field(Of String)("spcsuc_Cod"),
                                                        dr.Field(Of Integer)("spcscc_ID"),
                                                        dr.Field(Of String)("spctco_Circuito"),
                                                        dr.Field(Of String)("spctco_Cod")))


         If Not sqlPedido.ExistePedido(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido) Then
            Dim numeroInterno = dr.Field(Of Integer)("spcscc_ID")
            Dim fechaPedido = dr.Field(Of DateTime)("scc_FEmision")
            Dim fechaActualizacion = dr.Field(Of DateTime?)("scc_FecMod").IfNull(Now)
            Dim codigoProveedor = dr.Field(Of String)("sccpro_Cod")
            Dim codigoFormaPago = dr.Field(Of String)("scccpg_Cod")
            Dim observaciones = dr.Field(Of String)("scctxa_Texto")
            ' Dim Moneda = dr.Field(Of Integer)("sccmon_codigo")

            Dim idProveedor = cache.BuscaProveedor(codigoProveedor).IdProveedor

            Dim idComprador = cache.GetPrimerComprador().IdEmpleado
            Dim formaPago = cache.BuscaFormasPago(codigoFormaPago)
            If formaPago Is Nothing Then
               formaPago = rFormaPago._Insertar(codigoFormaPago)
            End If
            Dim idFormaPago = formaPago.IdFormasPago


            ' Dim importeTotal = colDrP.Sum(Function(drP) (drP.Field(Of Double)("sdc_PrecioUn") * drP.Field(Of Double)("sdc_CantUM1")).ToDecimal())
            Dim importeTotal = Decimal.Parse(colDrP.Sum(Function(drP) (drP.Field(Of Double)("sdc_PrecioUn") * Double.Parse(IIf(String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()), drP("sdc_CantUM1"), drP("CantUMPrCompra")).ToString()))).ToString())

            Dim importeTotalImpuestos = Decimal.Parse(colDrP.Sum(Function(drP) (drP.Field(Of Double)("ImpTotItem_con_IVA"))).ToString())
            Dim ImporteImpuestos = importeTotalImpuestos - importeTotal


            sqlPedido.PedidosProveedores_I(actual.Sucursal.Id,
                                           tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido,
                                           fechaPedido, observaciones, actual.Nombre, descuentoRecargo:=0, descuentoRecargoPorc:=0,
                                           idProveedor:=idProveedor, idComprador:=idComprador, idFormaPago:=idFormaPago, idTransportista:=Nothing,
                                           numeroOrdenCompra:=numeroInterno, cotizacionDolar:=cache.BuscaMoneda(Entidades.Moneda.Dolar).FactorConversion,
                                           idTipoComprobanteFact:="", importeBruto:=importeTotal, subTotal:=importeTotal, totalImpuestos:=ImporteImpuestos, totalImpuestoInterno:=0, importeTotal:=importeTotalImpuestos,
                                           idEstadoVisita:=idEstadoVisita, fechaAutorizacion:=fechaAutorizacion,
                                           fechaReprogramacion:=Nothing, idMoneda:=1)

            For Each drP In colDrP.OrderBy(Function(x) x.Field(Of Short)("sdc_NReng"))
               Dim nroRenglon = drP.Field(Of Short)("sdc_NReng")
               Dim tipoItem = drP.Field(Of String)("sdc_TipoIt")      'Tipo de Item: A=artículo / C=Concepto / L=Leyenda / D=Descuento.
               Dim idArticulo = drP.Field(Of String)("sdcart_CodGen")
               Dim idConcepto = drP.Field(Of String)("sdccon_Cod")
               Dim descArtic = drP.Field(Of String)("sdc_Desc").Replace("'", "")

               Dim descRec1 = 0D 'drP.Field(Of Double)("sdc_TasaBon").ToDecimal()
               Dim descRec2 = 0D

               Dim Cantidad As Decimal = 0
               Cantidad = drP.Field(Of Double)("sdc_CantUM1").ToDecimal()
               If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                  If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                     Cantidad = drP.Field(Of Double)("sdc_CantUM2").ToDecimal()
                  End If
               End If

               Dim precio = drP.Field(Of Double)("sdc_PrecioUn").ToDecimal()
               Dim precioConImpuestos As Decimal = 0
               Dim importeImpuesto As Decimal = 0
               Dim importeTotalConImpuestos As Decimal = drP.Field(Of Double)("ImpTotItem_con_IVA").ToDecimal()

               If Cantidad <> 0 Then
                  precioConImpuestos = drP.Field(Of Double)("ImpTotItem_con_IVA").ToDecimal() / Cantidad
               End If

               importeImpuesto = precioConImpuestos - precio

               Dim PorcImpuesto As Decimal = 0
               If precio <> 0 Then
                  PorcImpuesto = Math.Round((((precioConImpuestos / precio) - 1) * 100), 2)
                  If PorcImpuesto > 30 Then
                     PorcImpuesto = Publicos.ProductoIVA
                  End If
               End If

               Dim fechaEntrega = drP.Field(Of DateTime)("sdc_FRecep")

               Dim CantPendiente As Decimal = 0
               CantPendiente = drP.Field(Of Double)("sdc_CPendRtUM1").ToDecimal()

               If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                  If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                     CantPendiente = drP.Field(Of Double)("sdc_CPendRtUM2").ToDecimal()
                  End If
               End If

               Dim UM As String = String.Empty
               UM = drP.Field(Of String)("sdcume_Cod1")
               If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                  If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                     UM = drP.Field(Of String)("sdcume_Cod2")
                  End If
               End If

               Dim UnidMed As Entidades.UnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUno(UM)
               If UnidMed Is Nothing Then
                  UM = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
               End If

               If CantPendiente < 0 Then
                  CantPendiente = 0
               End If

               Dim CantidadEntregada = Cantidad - CantPendiente

               Dim idProducto = If(tipoItem = "A", idArticulo, If(tipoItem = "C", idConcepto, productoObservacion.IdProducto))

               If Not cache.ExisteProductoPorIdRapido(idProducto) Then
                  rProducto.InsertaCalidad(If(tipoItem = "A", idArticulo, idConcepto), descArtic, "OC", UM, cache, _idFuncion)
                  cache.AgregarParaExisteProductoPorIdRapido(idProducto)
               End If


               sqlProducto.PedidosProductosProveedores_I(actual.Sucursal.Id,
                                                         tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido,
                                                         idProducto, nroRenglon, idProveedor, Cantidad, precio, precio, precio,
                                                         descRec1, descRec2,
                                                         fechaActualizacion:=fechaActualizacion, fechaEntrega:=fechaEntrega,
                                                         importeTotal:=precio * Cantidad, importeTotalNeto:=precio * Cantidad,
                                                         nombreProducto:=descArtic, cantPendiente:=Cantidad,
                                                         idTipoImpuesto:=Entidades.TipoImpuesto.Tipos.IVA, alicuotaImpuesto:=PorcImpuesto,
                                                         descuentoRecargoProducto:=0, descRecGeneral:=0, descRecGeneralProducto:=0,
                                                         importeImpuesto:=importeImpuesto, impuestoInterno:=0, importeImpuestoInterno:=0, porcImpuestoInterno:=0,
                                                         cantEntregada:=CantidadEntregada, cantEnProceso:=CantPendiente, cantAnulada:=0, kilos:=0, kilosProducto:=0, precioPorKilos:=0, idCriticidad:=idCriticidad,
                                                         costoConImpuestos:=precioConImpuestos, costoNetoConImpuestos:=precioConImpuestos,
                                                         importeTotalConImpuestos:=importeTotalConImpuestos, importeTotalNetoConImpuestos:=0,
                                                         IdUnidadDeMedida:=UM)

               Dim idEstadoPedido = If(dr.Field(Of Boolean)("scc_CumpXPgm"), "CANCELADO", If(CantidadEntregada = Cantidad, If(idProducto = productoObservacion.IdProducto, Entidades.EstadoPedidoProveedor.TipoEstado.OBSERVACION, Entidades.EstadoPedidoProveedor.TipoEstado.ENTREGADO), If(CantidadEntregada = 0, Entidades.EstadoPedidoProveedor.TipoEstado.PENDIENTE, Entidades.EstadoPedidoProveedor.TipoEstado.ENPROCESO)))

               sqlEstado.PedidosEstadosProveedores_I(actual.Sucursal.Id,
                                                     tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido,
                                                     idProducto, fechaPedido, idProveedor, idEstadoPedido,
                                                     actual.Nombre, observaciones,
                                                     CantPendiente, String.Empty, String.Empty, 0, 0,
                                                     nroRenglon, idCriticidad, fechaEntrega, "PEDIDOSPROV",
                                                     0, 0, String.Empty, String.Empty, 0, 0, 0, String.Empty, String.Empty, 0, 0,
                                                     idEstadoProducto:=String.Empty, idEstadoCantidad:=String.Empty, idEstadoPrecio:=String.Empty, idEstadoFechaEntrega:=String.Empty,
                                                     fechaEstadoProducto:=Nothing, fechaEstadoCantidad:=Nothing, fechaEstadoPrecio:=Nothing, fechaEstadoFechaEntrega:=Nothing)

            Next
            dtDetalle.Rows.RemoveRowRange(colDrP)
         Else


            'Dim OC As Entidades.PedidoProveedor = New Reglas.PedidosProveedores(da).GetUno(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido)
            Dim fechaPedido = dr.Field(Of DateTime)("scc_FEmision")

            Dim ProductosEstados As DataTable = sqlEstado.PedidosEstadosProveedores_GA(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, "CANCELADO")

            If dr.Field(Of Boolean)("scc_CumpXPgm") Then
               If ProductosEstados.Rows.Count = 0 Then
                  Dim rEstado = New Reglas.PedidosProveedores(da)
                  rEstado._CancelarPedidos(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, "PEDIDOSPROV", _idFuncion)
               End If
            Else
               'Modifica fecha de Autorizacion 
               sqlPedido.ActualizarFechaAutorizacion(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, fechaAutorizacion)

               'Modificacion de cantidad entregada y cambiar estado
               For Each drP In colDrP.OrderBy(Function(x) x.Field(Of Short)("sdc_NReng"))

                  Dim CantidadEntregada As Decimal = 0
                  Dim CantEnProceso As Decimal = 0
                  Dim CantPendiente As Decimal = 0

                  Dim nroRenglon = drP.Field(Of Short)("sdc_NReng")
                  Dim tipoItem = drP.Field(Of String)("sdc_TipoIt")      'Tipo de Item: A=artículo / C=Concepto / L=Leyenda / D=Descuento.
                  Dim idArticulo = drP.Field(Of String)("sdcart_CodGen")
                  Dim idConcepto = drP.Field(Of String)("sdccon_Cod")
                  Dim fechaEntrega = drP.Field(Of DateTime)("sdc_FRecep")
                  Dim Cantidad As Decimal = 0
                  Cantidad = drP.Field(Of Double)("sdc_CantUM1").ToDecimal()
                  If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                     If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                        Cantidad = drP.Field(Of Double)("sdc_CantUM2").ToDecimal()
                     End If
                  End If

                  Dim precio = drP.Field(Of Double)("sdc_PrecioUn").ToDecimal()

                  CantPendiente = drP.Field(Of Double)("sdc_CPendRtUM1").ToDecimal()
                  If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                     If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                        CantPendiente = drP.Field(Of Double)("sdc_CPendRtUM2").ToDecimal()
                     End If
                  End If

                  If CantPendiente < 0 Then
                     CantPendiente = 0
                  End If

                  CantidadEntregada = Cantidad - CantPendiente

                  CantEnProceso = CantPendiente

                  Dim idProducto = If(tipoItem = "A", idArticulo, If(tipoItem = "C", idConcepto, productoObservacion.IdProducto))

                  Dim CantidadEntregadaAnterior As Double = New Reglas.PedidosProductosProveedores(da).GetUno(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                                                                                         tipoComprobante.Item3, numeroPedido, nroRenglon, idProducto).CantEntregada

                  Dim FechaEntregadaAnterior As DataTable = New Reglas.PedidosEstadosProveedores(da).GetPrimerFechaEntrega(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                                                                                         tipoComprobante.Item3, numeroPedido, nroRenglon)


                  sqlProducto.ActualizarCantidadesCalidad(actual.Sucursal.Id,
                                                         tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                         tipoComprobante.Item3, numeroPedido, idProducto, nroRenglon, CantPendiente,
                                                         CantEnProceso, CantidadEntregada, 0, precio, Cantidad, fechaEntrega)



                  Dim idEstadoPedido = If(dr.Field(Of Boolean)("scc_CumpXPgm"), "CANCELADO", If(CantidadEntregada = Cantidad, Entidades.EstadoPedidoProveedor.TipoEstado.ENTREGADO, If(CantidadEntregada = 0, Entidades.EstadoPedidoProveedor.TipoEstado.PENDIENTE, Entidades.EstadoPedidoProveedor.TipoEstado.ENPROCESO)))


                  If Cantidad <> 0 Then

                     sqlEstado.PedidosEstadosProveedores_U_EstadoCalidad(actual.Sucursal.Id,
                                                           tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                           tipoComprobante.Item3, numeroPedido, idProducto, fechaPedido, idEstadoPedido,
                                                           "PEDIDOSPROV", CantPendiente, Date.Now, "", nroRenglon, idCriticidad, fechaEntrega, numeroReparto:=0)

                  End If

                  sqlEstado.PedidosEstadosProveedores_U_FechaEntrega(actual.Sucursal.Id,
                                                           tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                           tipoComprobante.Item3, numeroPedido, idProducto, fechaPedido, nroRenglon, fechaEntrega)

                  If DateTime.Parse(FechaEntregadaAnterior.Rows(0).Item("FechaEntrega").ToString()) <> fechaEntrega Then
                     sqlPedido.ActualizarFechaReprogramacion(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, fechaEntrega)
                     Dim oActivacion As Reglas.ActivacionesOC = New Reglas.ActivacionesOC(da)
                     Dim UltimaActivacion As DataTable = oActivacion.GetUltimaActivacion(actual.Sucursal.Id,
                                                           tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                           tipoComprobante.Item3, numeroPedido, 0)

                     If UltimaActivacion.Rows.Count <> 0 Then
                        oActivacion.ActualizarFechareprogramacion(actual.Sucursal.Id,
                                                           tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                           tipoComprobante.Item3, numeroPedido, 0,
                                                          Integer.Parse(UltimaActivacion.Rows(0).Item("OrdenActivacion").ToString()))
                     End If

                  End If

               Next
            End If

         End If
      Next

      'Anular OC que se eliminaron en Bejerman 
      For Each dr As DataRow In dtEliminados.Rows
         Dim idTipoComprobante = dr.Field(Of String)("inftco_Cod")
         Dim numeroPedido = Long.Parse(dr.Field(Of String)("inf_NroComp"))
         Dim fechaModificacion = dr.Field(Of DateTime?)("inf_FecMod")

         registroActual += 1
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, registroActual, registrosTotal, String.Format("{0} - {1:00000000}", idTipoComprobante, numeroPedido)))

         If Not dicTipoComprobante.ContainsKey(idTipoComprobante) Then
            AddTipoComprobante(dicTipoComprobante, idTipoComprobante, cache)
         End If
         Dim tipoComprobante = dicTipoComprobante(idTipoComprobante)

         If sqlPedido.ExistePedido(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido) Then
            Dim rEstado = New Reglas.PedidosProveedores(da)
            rEstado._AnularPedidos(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, "PEDIDOSPROV", _idFuncion)
         End If
      Next

      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Finalizó"))
      Return result
   End Function

   Private Function GrabarOrdenesCompraAutorizadasDesdeBejerman(dtCabecera As DataTable, dtDetalle As DataTable) As DateTime?
      Dim result As DateTime? = Nothing
      Dim dicTipoComprobante = New Dictionary(Of String, Tuple(Of Entidades.TipoComprobante, String, Short))()
      Dim cache = New BusquedasCacheadas()

      'Usamos sql directamente para agilizar el uso y respetar los valores tal cual estan en Bejerman
      Dim sqlPedido = New SqlServer.PedidosProveedores(da)
      Dim sqlProducto = New SqlServer.PedidosProductosProveedores(da)
      Dim sqlEstado = New SqlServer.PedidosEstadosProveedores(da)

      Dim rFormaPago = New VentasFormasPago(da)
      Dim rProducto = New Productos(da)
      Dim col = rProducto._GetTodosObservacion()
      If col.Count = 0 Then
         Throw New Exception("No existe ningún producto configurado como Producto Observación")
      End If
      Dim productoObservacion = col(0)
      Dim tipoImpuesto = New TiposImpuestos(da)._GetUno(Entidades.TipoImpuesto.Tipos.IVA)
      Dim idCriticidad = New Reglas.PedidosCriticidades(da).GetTodos().FirstOrDefault().IdCriticidad
      Dim idEstadoVisita = New Reglas.EstadosVisitas(da)._GetTodos(admitePedidoSinLineas:=Nothing, admintePedidoConLineas:=Nothing).FirstOrDefault().IdEstadoVisita

      Dim registroActual = 0I
      Dim registrosTotal = dtCabecera.Rows.Count

      For Each dr As DataRow In dtCabecera.Rows

         Dim idTipoComprobante = dr.Field(Of String)("spctco_Cod")
         Dim numeroPedido = Long.Parse(dr.Field(Of String)("spc_Nro"))
         Dim fechaModificacion = dr.Field(Of DateTime?)("scc_FecMod")
         Dim fechaAutorizacion = dr.Field(Of DateTime?)("usc_FecMod_Autorizacion")

         If Not result.HasValue Then
            result = fechaAutorizacion
         Else
            If fechaAutorizacion.HasValue Then
               If fechaAutorizacion.Value > result.Value Then
                  result = fechaAutorizacion
               End If
            End If
         End If

         registroActual += 1
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOCAutor, registroActual, registrosTotal, String.Format("{0} - {1:00000000}", idTipoComprobante, numeroPedido)))

         If Not dicTipoComprobante.ContainsKey(idTipoComprobante) Then
            AddTipoComprobante(dicTipoComprobante, idTipoComprobante, cache)
         End If
         Dim tipoComprobante = dicTipoComprobante(idTipoComprobante)

         Dim colDrP = dtDetalle.Select(String.Format("spcemp_Codigo = '{0}' AND spcsuc_Cod = '{1}' AND spcscc_ID = {2} AND spctco_Circuito = '{3}' AND spctco_Cod = '{4}'",
                                                        dr.Field(Of String)("spcemp_Codigo"),
                                                        dr.Field(Of String)("spcsuc_Cod"),
                                                        dr.Field(Of Integer)("spcscc_ID"),
                                                        dr.Field(Of String)("spctco_Circuito"),
                                                        dr.Field(Of String)("spctco_Cod")))


         If Not sqlPedido.ExistePedido(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido) Then

            Dim numeroInterno = dr.Field(Of Integer)("spcscc_ID")
            Dim fechaPedido = dr.Field(Of DateTime)("scc_FEmision")
            Dim fechaActualizacion = dr.Field(Of DateTime?)("scc_FecMod").IfNull(Now)
            Dim codigoProveedor = dr.Field(Of String)("sccpro_Cod")
            Dim codigoFormaPago = dr.Field(Of String)("scccpg_Cod")
            Dim observaciones = dr.Field(Of String)("scctxa_Texto")
            ' Dim Moneda = dr.Field(Of Integer)("sccmon_codigo")


            Dim idProveedor = cache.BuscaProveedor(codigoProveedor).IdProveedor
            '  Dim idProveedor = New Reglas.Proveedores().GetUnoPorCodigoLetras(codigoProveedor, False, AccionesSiNoExisteRegistro.Vacio).IdProveedor
            Dim idComprador = cache.GetPrimerComprador().IdEmpleado
            Dim formaPago = cache.BuscaFormasPago(codigoFormaPago)
            If formaPago Is Nothing Then
               formaPago = rFormaPago._Insertar(codigoFormaPago)
            End If
            Dim idFormaPago = formaPago.IdFormasPago

            ' Dim importeTotal = colDrP.Sum(Function(drP) (drP.Field(Of Double)("sdc_PrecioUn") * drP.Field(Of Double)("sdc_CantUM1")).ToDecimal())

            Dim importeTotal = Decimal.Parse(colDrP.Sum(Function(drP) (drP.Field(Of Double)("sdc_PrecioUn") * Double.Parse(IIf(String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()), drP("sdc_CantUM1"), drP("CantUMPrCompra")).ToString()))).ToString())

            Dim importeTotalImpuestos = Decimal.Parse(colDrP.Sum(Function(drP) (drP.Field(Of Double)("ImpTotItem_con_IVA"))).ToString())
            Dim ImporteImpuestos = importeTotalImpuestos - importeTotal

            sqlPedido.PedidosProveedores_I(actual.Sucursal.Id,
                                           tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido,
                                           fechaPedido, observaciones, actual.Nombre, descuentoRecargo:=0, descuentoRecargoPorc:=0,
                                           idProveedor:=idProveedor, idComprador:=idComprador, idFormaPago:=idFormaPago, idTransportista:=Nothing,
                                           numeroOrdenCompra:=numeroInterno, cotizacionDolar:=cache.BuscaMoneda(Entidades.Moneda.Dolar).FactorConversion,
                                           idTipoComprobanteFact:="", importeBruto:=importeTotal, subTotal:=importeTotal, totalImpuestos:=ImporteImpuestos, totalImpuestoInterno:=0, importeTotal:=importeTotalImpuestos,
                                           idEstadoVisita:=idEstadoVisita, fechaAutorizacion:=fechaAutorizacion,
                                           fechaReprogramacion:=Nothing, idMoneda:=1)

            For Each drP In colDrP.OrderBy(Function(x) x.Field(Of Short)("sdc_NReng"))
               Dim nroRenglon = drP.Field(Of Short)("sdc_NReng")
               Dim tipoItem = drP.Field(Of String)("sdc_TipoIt")      'Tipo de Item: A=artículo / C=Concepto / L=Leyenda / D=Descuento.
               Dim idArticulo = drP.Field(Of String)("sdcart_CodGen")
               Dim idConcepto = drP.Field(Of String)("sdccon_Cod")
               Dim descArtic = drP.Field(Of String)("sdc_Desc").Replace("'", "")

               Dim UM As String = String.Empty
               UM = drP.Field(Of String)("sdcume_Cod1")
               If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                  If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                     UM = drP.Field(Of String)("sdcume_Cod2")
                  End If
               End If

               Dim UnidMed As Entidades.UnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUno(UM)
               If UnidMed Is Nothing Then
                  UM = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
               End If

               Dim descRec1 = 0D 'drP.Field(Of Double)("sdc_TasaBon").ToDecimal()
               Dim descRec2 = 0D

               Dim Cantidad As Decimal = 0
               Cantidad = drP.Field(Of Double)("sdc_CantUM1").ToDecimal()
               If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                  If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                     Cantidad = drP.Field(Of Double)("sdc_CantUM2").ToDecimal()
                  End If
               End If

               Dim precio = drP.Field(Of Double)("sdc_PrecioUn").ToDecimal()
               Dim precioConImpuestos As Decimal = 0
               Dim importeImpuesto As Decimal = 0
               Dim importeTotalConImpuestos As Decimal = drP.Field(Of Double)("ImpTotItem_con_IVA").ToDecimal()

               If Cantidad <> 0 Then
                  precioConImpuestos = drP.Field(Of Double)("ImpTotItem_con_IVA").ToDecimal() / Cantidad
               End If

               importeImpuesto = precioConImpuestos - precio

               Dim PorcImpuesto As Decimal = 0
               If precio <> 0 Then
                  PorcImpuesto = Math.Round((((precioConImpuestos / precio) - 1) * 100), 2)
                  If PorcImpuesto > 30 Then
                     PorcImpuesto = Publicos.ProductoIVA
                  End If
               End If


               Dim fechaEntrega = drP.Field(Of DateTime)("sdc_FRecep")

               Dim CantPendiente As Decimal = 0
               CantPendiente = drP.Field(Of Double)("sdc_CPendRtUM1").ToDecimal()
               If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                  If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                     CantPendiente = drP.Field(Of Double)("sdc_CPendRtUM2").ToDecimal()
                  End If
               End If


               If CantPendiente < 0 Then
                  CantPendiente = 0
               End If

               Dim CantidadEntregada = Cantidad - CantPendiente

               Dim idProducto = If(tipoItem = "A", idArticulo, If(tipoItem = "C", idConcepto, productoObservacion.IdProducto))

               If Not cache.ExisteProductoPorIdRapido(idProducto) Then
                  rProducto.InsertaCalidad(If(tipoItem = "A", idArticulo, idConcepto), descArtic, "OC", UM, cache, _idFuncion)
                  cache.AgregarParaExisteProductoPorIdRapido(idProducto)
               End If


               sqlProducto.PedidosProductosProveedores_I(actual.Sucursal.Id,
                                                         tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido,
                                                         idProducto, nroRenglon, idProveedor, Cantidad, precio, precio, precio,
                                                         descRec1, descRec2,
                                                         fechaActualizacion:=fechaActualizacion, fechaEntrega:=fechaEntrega,
                                                         importeTotal:=precio * Cantidad, importeTotalNeto:=precio * Cantidad,
                                                         nombreProducto:=descArtic, cantPendiente:=Cantidad,
                                                         idTipoImpuesto:=Entidades.TipoImpuesto.Tipos.IVA, alicuotaImpuesto:=PorcImpuesto,
                                                         descuentoRecargoProducto:=0, descRecGeneral:=0, descRecGeneralProducto:=0,
                                                         importeImpuesto:=importeImpuesto, impuestoInterno:=0, importeImpuestoInterno:=0, porcImpuestoInterno:=0,
                                                         cantEntregada:=CantidadEntregada, cantEnProceso:=CantPendiente, cantAnulada:=0, kilos:=0, kilosProducto:=0, precioPorKilos:=0, idCriticidad:=idCriticidad,
                                                         costoConImpuestos:=precioConImpuestos, costoNetoConImpuestos:=precioConImpuestos,
                                                         importeTotalConImpuestos:=importeTotalConImpuestos, importeTotalNetoConImpuestos:=0,
                                                         IdUnidadDeMedida:=UM)

               Dim idEstadoPedido = If(dr.Field(Of Boolean)("scc_CumpXPgm"), "CANCELADO", If(CantidadEntregada = Cantidad, If(idProducto = productoObservacion.IdProducto, Entidades.EstadoPedidoProveedor.TipoEstado.OBSERVACION, Entidades.EstadoPedidoProveedor.TipoEstado.ENTREGADO), If(CantidadEntregada = 0, Entidades.EstadoPedidoProveedor.TipoEstado.PENDIENTE, Entidades.EstadoPedidoProveedor.TipoEstado.ENPROCESO)))

               sqlEstado.PedidosEstadosProveedores_I(actual.Sucursal.Id,
                                                     tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido,
                                                     idProducto, fechaPedido, idProveedor, idEstadoPedido,
                                                     actual.Nombre, observaciones,
                                                     CantPendiente, String.Empty, String.Empty, 0, 0,
                                                     nroRenglon, idCriticidad, fechaEntrega, "PEDIDOSPROV",
                                                     0, 0, String.Empty, String.Empty, 0, 0, 0, String.Empty, String.Empty, 0, 0,
                                                     idEstadoProducto:=String.Empty, idEstadoCantidad:=String.Empty, idEstadoPrecio:=String.Empty, idEstadoFechaEntrega:=String.Empty,
                                                     fechaEstadoProducto:=Nothing, fechaEstadoCantidad:=Nothing, fechaEstadoPrecio:=Nothing, fechaEstadoFechaEntrega:=Nothing)

            Next
            dtDetalle.Rows.RemoveRowRange(colDrP)
         Else


            'Dim OC As Entidades.PedidoProveedor = New Reglas.PedidosProveedores(da).GetUno(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido)
            Dim fechaPedido = dr.Field(Of DateTime)("scc_FEmision")

            Dim ProductosEstados As DataTable = sqlEstado.PedidosEstadosProveedores_GA(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, "CANCELADO")

            If dr.Field(Of Boolean)("scc_CumpXPgm") Then
               If ProductosEstados.Rows.Count = 0 Then
                  Dim rEstado = New Reglas.PedidosProveedores(da)
                  rEstado._CancelarPedidos(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, "PEDIDOSPROV", _idFuncion)
               End If
            Else
               'Modifica fecha de Autorizacion 
               sqlPedido.ActualizarFechaAutorizacion(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, fechaAutorizacion)

               'Modificacion de cantidad entregada y cambiar estado
               For Each drP In colDrP.OrderBy(Function(x) x.Field(Of Short)("sdc_NReng"))

                  Dim CantidadEntregada As Decimal = 0
                  Dim CantEnProceso As Decimal = 0
                  Dim CantPendiente As Decimal = 0

                  Dim nroRenglon = drP.Field(Of Short)("sdc_NReng")
                  Dim tipoItem = drP.Field(Of String)("sdc_TipoIt")      'Tipo de Item: A=artículo / C=Concepto / L=Leyenda / D=Descuento.
                  Dim idArticulo = drP.Field(Of String)("sdcart_CodGen")
                  Dim idConcepto = drP.Field(Of String)("sdccon_Cod")
                  Dim fechaEntrega = drP.Field(Of DateTime)("sdc_FRecep")

                  Dim Cantidad As Decimal = 0
                  Cantidad = drP.Field(Of Double)("sdc_CantUM1").ToDecimal()
                  If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                     If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                        Cantidad = drP.Field(Of Double)("sdc_CantUM2").ToDecimal()
                     End If
                  End If

                  Dim precio = drP.Field(Of Double)("sdc_PrecioUn").ToDecimal()

                  CantPendiente = drP.Field(Of Double)("sdc_CPendRtUM1").ToDecimal()
                  If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                     If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                        CantPendiente = drP.Field(Of Double)("sdc_CPendRtUM2").ToDecimal()
                     End If
                  End If

                  If CantPendiente < 0 Then
                     CantPendiente = 0
                  End If

                  CantidadEntregada = Cantidad - CantPendiente

                  CantEnProceso = CantPendiente

                  Dim idProducto = If(tipoItem = "A", idArticulo, If(tipoItem = "C", idConcepto, productoObservacion.IdProducto))

                  Dim CantidadEntregadaAnterior As Double = New Reglas.PedidosProductosProveedores(da).GetUno(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                                                                                         tipoComprobante.Item3, numeroPedido, nroRenglon, idProducto).CantEntregada


                  Dim FechaEntregadaAnterior As DateTime = New Reglas.PedidosProductosProveedores(da).GetUno(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                                                                                         tipoComprobante.Item3, numeroPedido, nroRenglon, idProducto).FechaEntrega


                  sqlProducto.ActualizarCantidadesCalidad(actual.Sucursal.Id,
                                                         tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                         tipoComprobante.Item3, numeroPedido, idProducto, nroRenglon, CantPendiente,
                                                         CantEnProceso, CantidadEntregada, 0, precio, Cantidad, fechaEntrega)



                  Dim idEstadoPedido = If(dr.Field(Of Boolean)("scc_CumpXPgm"), "CANCELADO", If(CantidadEntregada = Cantidad, Entidades.EstadoPedidoProveedor.TipoEstado.ENTREGADO, If(CantidadEntregada = 0, Entidades.EstadoPedidoProveedor.TipoEstado.PENDIENTE, Entidades.EstadoPedidoProveedor.TipoEstado.ENPROCESO)))


                  If Cantidad <> 0 Then

                     sqlEstado.PedidosEstadosProveedores_U_EstadoCalidad(actual.Sucursal.Id,
                                                           tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                           tipoComprobante.Item3, numeroPedido, idProducto, fechaPedido, idEstadoPedido,
                                                           "PEDIDOSPROV", CantPendiente, Date.Now, "", nroRenglon, idCriticidad, fechaEntrega, numeroReparto:=0)

                  End If

                  sqlEstado.PedidosEstadosProveedores_U_FechaEntrega(actual.Sucursal.Id,
                                                           tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                           tipoComprobante.Item3, numeroPedido, idProducto, fechaPedido, nroRenglon, fechaEntrega)

                  If FechaEntregadaAnterior <> fechaEntrega Then
                     sqlPedido.ActualizarFechaReprogramacion(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, fechaEntrega)
                     Dim oActivacion As Reglas.ActivacionesOC = New Reglas.ActivacionesOC(da)
                     Dim UltimaActivacion As DataTable = oActivacion.GetUltimaActivacion(actual.Sucursal.Id,
                                                           tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                           tipoComprobante.Item3, numeroPedido, 0)

                     If UltimaActivacion.Rows.Count <> 0 Then
                        oActivacion.ActualizarFechareprogramacion(actual.Sucursal.Id,
                                                           tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                           tipoComprobante.Item3, numeroPedido, 0,
                                                          Integer.Parse(UltimaActivacion.Rows(0).Item("OrdenActivacion").ToString()))
                     End If

                  End If

               Next
            End If

         End If
      Next
      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Finalizó"))
      Return result
   End Function

   Private Function ImportarOrdenesCompraAutorizadasDesdeBejermanOCN(nombreBase As String, fechaDesde As DateTime?, fechaHasta As DateTime?) As DateTime?
      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Cabeceras de Orden de Compra Autorizadas de Bejerman OCN"))
      Using dtC = New SqlServer.SincronizarOrdenesCompra(da).GetCabecerasAutorizadasBejermanOCN(nombreBase, fechaDesde, fechaHasta, fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing)
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Detalles de Orden de Compra Autorizadas de Bejerman OCN"))
         Using dtD = New SqlServer.SincronizarOrdenesCompra(da).GetDetallesAutorizadasBejermanOCN(nombreBase, fechaDesde, fechaHasta)
            Return EjecutaSoloConTransaccion(Function() GrabarOrdenesCompraAutorizadasDesdeBejerman(dtC, dtD))
         End Using
      End Using
   End Function

   Private Function ImportarOrdenesCompraDesdeBejermanModificacionFE(nombreBase As String, fechaDesde As DateTime?, fechaHasta As DateTime?) As DateTime?
      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Cabeceras de Orden de Compra de Bejerman para comparar modificacion Fecha Entrega"))
      Using dtC = New SqlServer.SincronizarOrdenesCompra(da).GetCabecerasBejerman(nombreBase, fechaDesde, fechaHasta, fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing)
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Detalles de Orden de Compra de Bejerman para comparar modificacion Fecha Entrega"))
         Using dtD = New SqlServer.SincronizarOrdenesCompra(da).GetDetallesBejerman(nombreBase, fechaDesde, fechaHasta)
            RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Orden de Compra Eliminadas de Bejerman"))
            Return EjecutaSoloConTransaccion(Function() GrabarOrdenesCompraDesdeBejermanFechaEntregaModificada(dtC, dtD))
         End Using
      End Using
   End Function

   Private Function GrabarOrdenesCompraDesdeBejermanFechaEntregaModificada(dtCabecera As DataTable, dtDetalle As DataTable) As DateTime?
      Dim result As DateTime? = Nothing
      Dim dicTipoComprobante = New Dictionary(Of String, Tuple(Of Entidades.TipoComprobante, String, Short))()
      Dim cache = New BusquedasCacheadas()

      'Usamos sql directamente para agilizar el uso y respetar los valores tal cual estan en Bejerman
      Dim sqlPedido = New SqlServer.PedidosProveedores(da)
      Dim sqlProducto = New SqlServer.PedidosProductosProveedores(da)
      Dim sqlEstado = New SqlServer.PedidosEstadosProveedores(da)

      Dim rFormaPago = New VentasFormasPago(da)
      Dim rProducto = New Productos(da)
      Dim col = rProducto._GetTodosObservacion()
      If col.Count = 0 Then
         Throw New Exception("No existe ningún producto configurado como Producto Observación")
      End If
      Dim productoObservacion = col(0)
      Dim tipoImpuesto = New TiposImpuestos(da)._GetUno(Entidades.TipoImpuesto.Tipos.IVA)
      Dim idCriticidad = New Reglas.PedidosCriticidades(da).GetTodos().FirstOrDefault().IdCriticidad
      Dim idEstadoVisita = New Reglas.EstadosVisitas(da)._GetTodos(admitePedidoSinLineas:=Nothing, admintePedidoConLineas:=Nothing).FirstOrDefault().IdEstadoVisita

      Dim registroActual = 0I
      Dim registrosTotal = dtCabecera.Rows.Count

      For Each dr As DataRow In dtCabecera.Rows

         Dim idTipoComprobante = dr.Field(Of String)("spctco_Cod")
         Dim numeroPedido = Long.Parse(dr.Field(Of String)("spc_Nro"))
         Dim fechaModificacion = dr.Field(Of DateTime?)("scc_FecMod")
         Dim fechaAutorizacion = dr.Field(Of DateTime?)("usc_FecMod_Autorizacion")



         If Not result.HasValue Then
            result = fechaModificacion
         Else
            If fechaModificacion.HasValue Then
               If fechaModificacion.Value > result.Value Then
                  result = fechaModificacion
               End If
            End If
         End If

         registroActual += 1
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, registroActual, registrosTotal, String.Format("{0} - {1:00000000}", idTipoComprobante, numeroPedido)))

         If Not dicTipoComprobante.ContainsKey(idTipoComprobante) Then
            AddTipoComprobante(dicTipoComprobante, idTipoComprobante, cache)
         End If
         Dim tipoComprobante = dicTipoComprobante(idTipoComprobante)

         Dim colDrP = dtDetalle.Select(String.Format("spcemp_Codigo = '{0}' AND spcsuc_Cod = '{1}' AND spcscc_ID = {2} AND spctco_Circuito = '{3}' AND spctco_Cod = '{4}'",
                                                        dr.Field(Of String)("spcemp_Codigo"),
                                                        dr.Field(Of String)("spcsuc_Cod"),
                                                        dr.Field(Of Integer)("spcscc_ID"),
                                                        dr.Field(Of String)("spctco_Circuito"),
                                                        dr.Field(Of String)("spctco_Cod")))





         If sqlPedido.ExistePedido(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido) Then

            Dim fechaPedido = dr.Field(Of DateTime)("scc_FEmision")


            Dim importeTotal = Decimal.Parse(colDrP.Sum(Function(drP) (drP.Field(Of Double)("sdc_PrecioUn") * Double.Parse(IIf(String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()), drP("sdc_CantUM1"), drP("CantUMPrCompra")).ToString()))).ToString())


            Dim importeTotalImpuestos = Decimal.Parse(colDrP.Sum(Function(drP) (drP.Field(Of Double)("ImpTotItem_con_IVA"))).ToString())
            Dim ImporteImpuestos = importeTotalImpuestos - importeTotal

            'Ver si el primer item tiene fecha de entrega diferente y modificar

            Dim dt1 As DataTable = New Reglas.PedidosEstadosProveedores(da).GetPrimerFechaEntrega(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                   tipoComprobante.Item3, numeroPedido, 1)
            Dim fechaEntregaAnterior As DateTime = DateTime.Parse(dt1.Rows(0).Item("FechaEntrega").ToString())

            sqlPedido.ActualizarImportesCalidad(actual.Sucursal.Id,
                                                      tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                      tipoComprobante.Item3, numeroPedido, importeTotal,
                                                      importeTotalImpuestos, ImporteImpuestos)

            For Each drP In colDrP.OrderBy(Function(x) x.Field(Of Short)("sdc_NReng"))

               Dim CantidadEntregada As Decimal = 0
               Dim CantEnProceso As Decimal = 0
               Dim CantPendiente As Decimal = 0

               Dim nroRenglon = drP.Field(Of Short)("sdc_NReng")
               Dim tipoItem = drP.Field(Of String)("sdc_TipoIt")      'Tipo de Item: A=artículo / C=Concepto / L=Leyenda / D=Descuento.
               Dim idArticulo = drP.Field(Of String)("sdcart_CodGen")
               Dim idConcepto = drP.Field(Of String)("sdccon_Cod")
               Dim fechaEntrega = drP.Field(Of DateTime)("sdc_FRecep")

               Dim UM As String = String.Empty
               UM = drP.Field(Of String)("sdcume_Cod1")
               If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                  If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                     UM = drP.Field(Of String)("sdcume_Cod2")
                  End If
               End If

               Dim Cantidad As Decimal = 0
               Cantidad = drP.Field(Of Double)("sdc_CantUM1").ToDecimal()

               If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                  If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                     Cantidad = drP.Field(Of Double)("sdc_CantUM2").ToDecimal()
                  End If
               End If

               Dim precio = drP.Field(Of Double)("sdc_PrecioUn").ToDecimal

               Dim precioConImpuestos As Decimal = 0
               Dim importeImpuesto As Decimal = 0
               Dim importeTotalConImpuestos As Decimal = drP.Field(Of Double)("ImpTotItem_con_IVA").ToDecimal()

               If Cantidad <> 0 Then
                  precioConImpuestos = Decimal.Parse(drP.Field(Of Double)("ImpTotItem_con_IVA").ToDecimal().ToString()) / Cantidad
               End If

               importeImpuesto = precioConImpuestos - precio

               Dim PorcImpuesto As Decimal = 0
               If precio <> 0 Then
                  PorcImpuesto = Math.Round((((precioConImpuestos / precio) - 1) * 100), 2)
                  If PorcImpuesto > 30 Then
                     PorcImpuesto = Publicos.ProductoIVA
                  End If
               End If

               CantPendiente = drP.Field(Of Double)("sdc_CPendRtUM1").ToDecimal()
               If Not String.IsNullOrEmpty(drP("cla_UMeCprPrecio").ToString()) Then
                  If Integer.Parse(drP("cla_UMeCprPrecio").ToString()) = 2 Then
                     CantPendiente = drP.Field(Of Double)("sdc_CPendRtUM2").ToDecimal()
                  End If
               End If

               If CantPendiente < 0 Then
                  CantPendiente = 0
               End If

               CantidadEntregada = Cantidad - CantPendiente

               CantEnProceso = CantPendiente

               Dim idProducto = If(tipoItem = "A", idArticulo, If(tipoItem = "C", idConcepto, productoObservacion.IdProducto))

               '  Dim CantidadEntregadaAnterior As Double = New Reglas.PedidosProductosProveedores(da).GetUno(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
               '  tipoComprobante.Item3, numeroPedido, nroRenglon, idProducto).CantEntregada


               sqlProducto.ActualizarPreciosCalidad(actual.Sucursal.Id,
                                                      tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                      tipoComprobante.Item3, numeroPedido, idProducto, nroRenglon,
                                                      importeImpuesto, precioConImpuestos, importeTotalConImpuestos,
                                                        PorcImpuesto, Cantidad, UM)

               sqlProducto.ActualizarCantidadesCalidad(actual.Sucursal.Id,
                                                         tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                         tipoComprobante.Item3, numeroPedido, idProducto, nroRenglon, CantPendiente,
                                                         CantEnProceso, CantidadEntregada, 0, precio, Cantidad, fechaEntrega)





               Dim idEstadoPedido = If(dr.Field(Of Boolean)("scc_CumpXPgm"), "CANCELADO", If(CantidadEntregada = Cantidad, Entidades.EstadoPedidoProveedor.TipoEstado.ENTREGADO, If(CantidadEntregada = 0, Entidades.EstadoPedidoProveedor.TipoEstado.PENDIENTE, Entidades.EstadoPedidoProveedor.TipoEstado.ENPROCESO)))

               If Cantidad <> 0 Then

                  sqlEstado.PedidosEstadosProveedores_U_EstadoCalidad(actual.Sucursal.Id,
                                                     tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
                                                     tipoComprobante.Item3, numeroPedido, idProducto, fechaPedido, idEstadoPedido,
                                                     "PEDIDOSPROV", CantPendiente, Date.Now, "", nroRenglon, idCriticidad, fechaEntrega, numeroReparto:=0)

               End If

               'If fechaEntregaAnterior < fechaEntrega Then

               'sqlEstado.PedidosEstadosProveedores_U_FechaEntrega(actual.Sucursal.Id,
               '                                         tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2,
               '                                         tipoComprobante.Item3, numeroPedido, idProducto, fechaPedido, nroRenglon, fechaEntrega)

               'End If

            Next
            '  End If

         End If
      Next

      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Finalizó"))
      Return result
   End Function


   Private Sub AddTipoComprobante(dicTipoComprobante As Dictionary(Of String, Tuple(Of Entidades.TipoComprobante, String, Short)),
                                  idTipoComprobante As String,
                                  cache As BusquedasCacheadas)
      Dim tp = cache.BuscaTipoComprobante(idTipoComprobante)
      Dim impresoras = New Impresoras(da)._GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, idTipoComprobante)
      dicTipoComprobante.Add(idTipoComprobante, Tuple.Create(tp, tp.LetrasHabilitadas, impresoras.CentroEmisor))
   End Sub
#End Region

#Region "EnviarWeb"
   Public Sub EnviarWeb(reenviar As Boolean, enviarWebProveedores As Boolean, exportarProveedores As Boolean, enviarWebOrdenCompra As Boolean, exportarOrdenCompra As Boolean)
      EjecutaConConexion(Sub() _EnviarWeb(reenviar, enviarWebProveedores, exportarProveedores, enviarWebOrdenCompra, exportarOrdenCompra))
   End Sub
   Public Sub _EnviarWeb(reenviar As Boolean, enviarWebProveedores As Boolean, exportarProveedores As Boolean, enviarWebOrdenCompra As Boolean, exportarOrdenCompra As Boolean)
      If enviarWebProveedores Or exportarProveedores Then
         Me.EnviarWebProveedores(reenviar, enviarWebProveedores, exportarProveedores)
      End If
      If enviarWebOrdenCompra Or exportarOrdenCompra Then
         Me.EnviarWebOrdenCompra(reenviar, enviarWebOrdenCompra, exportarOrdenCompra)
      End If
   End Sub

   Private Function ArmarURL(formato As String) As String
      Return String.Format(formato, Publicos.BejermanMetalsur.MetalsurUrlBaseWebOC, Publicos.CuitEmpresa)
   End Function

   Private _serializer As JavaScriptSerializer = New JavaScriptSerializer()
   Private Sub EnviarWebProveedores(reenviar As Boolean, enviarWebProveedores As Boolean, exportarProveedores As Boolean)

      Dim servicioRest = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte)()
      Dim fechaMax As DateTime? = Nothing
      If Not reenviar Then
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendProv, Nothing, Nothing, "Obteniendo fecha máxima"))
         fechaMax = servicioRest.GetMaxFecha(ArmarURL("{0}/sigaproveedorjsonmax/CuitEmpresa/{1}/"), headers:=Nothing)
      End If

      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendProv, Nothing, Nothing, "Leyendo proveedores desde SIGA"))
      Dim dtProveedores = New SqlServer.SincronizarOrdenesCompra(da).GetProveedoresSIGA(fechaMax, fechaHasta:=Nothing)

      Dim registroActual = 0I
      Dim registrosTotal = dtProveedores.Rows.Count
      Try
         Dim provs = dtProveedores.Select().ToList().ConvertAll(Function(dr)
                                                                   Dim json = New With {.CuitEmpresa = Publicos.CuitEmpresa,
                                                                                        .IdProveedor = dr.Field(Of Long)(Entidades.Proveedor.Columnas.IdProveedor.ToString()),
                                                                                        .CodigoProveedor = dr.Field(Of Long)(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()),
                                                                                        .NombreProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.NombreProveedor.ToString()),
                                                                                        .NroDocProveedor = dr.Field(Of Long?)(Entidades.Proveedor.Columnas.NroDocProveedor.ToString()).ToString(),
                                                                                        .DireccionProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.DireccionProveedor.ToString()),
                                                                                        .TelefonoProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.TelefonoProveedor.ToString()),
                                                                                        .CorreoElectronico = dr.Field(Of String)(Entidades.Proveedor.Columnas.CorreoElectronico.ToString())}
                                                                   If String.IsNullOrWhiteSpace(json.NroDocProveedor) Then
                                                                      json.NroDocProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.CuitProveedor.ToString())
                                                                   End If
                                                                   registroActual += 1
                                                                   RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendProv, registroActual, registrosTotal, String.Format("{0} - {1}", json.CodigoProveedor, json.NombreProveedor)))
                                                                   Return New Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte() _
                                                                              With {.CuitEmpresa = Publicos.CuitEmpresa,
                                                                                    .IdProveedor = json.IdProveedor,
                                                                                    .DatosProveedor = _serializer.Serialize(json),
                                                                                    .FechaActualizacion = Now.ToStringFormatoPropio()}
                                                                End Function).Paginar(100)

         If reenviar And enviarWebProveedores Then
            RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendProv, Nothing, Nothing, "Borrando proveedores"))
            servicioRest.Delete(ArmarURL("{0}/sigaproveedorjson/CuitEmpresa/{1}/"), headers:=Nothing)
         End If

         registroActual = 0
         registrosTotal = provs.Count
         For Each p In provs
            registroActual += 1
            RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendProv, registroActual, registrosTotal, "Enviando páginas proveedores (tamaño 100)"))
            If exportarProveedores And Not String.IsNullOrWhiteSpace(Publicos.WebArchivos.CarpetaExportacion) Then
               IO.File.WriteAllText(String.Format("{0}\proveedor_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(p))
            End If
            If enviarWebProveedores Then
               servicioRest.Post(p, ArmarURL("{0}/sigaproveedorjson/"), headers:=Nothing, binario:=False)
            End If
         Next

         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendProv, Nothing, Nothing, "Finalizó"))
      Catch
         Throw
      End Try

   End Sub

   Private Sub EnviarWebOrdenCompra(reenviar As Boolean, enviarWebOrdenCompra As Boolean, exportarOrdenCompra As Boolean)

      Dim servicioRest = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.OrdenCompraJSon)()
      Dim fechaMax As DateTime? = Nothing
      If Not reenviar Then
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendOC, Nothing, Nothing, "Obteniendo fecha máxima"))
         fechaMax = servicioRest.GetMaxFecha(ArmarURL("{0}/sigaordencomprajsonmax/CuitEmpresa/{1}/"), headers:=Nothing)
      End If

      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendOC, Nothing, Nothing, "Leyendo Cabecera de O.C. desde SIGA"))
      Dim dtCabecera = New SqlServer.SincronizarOrdenesCompra(da).GetCabeceraSIGA(fechaMax, fechaHasta:=Nothing)
      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendOC, Nothing, Nothing, "Leyendo Dabecera de O.C. desde SIGA"))
      Dim dtDetalle = New SqlServer.SincronizarOrdenesCompra(da).GetDetalleSIGA(fechaMax, fechaHasta:=Nothing)

      Dim registroActual = 0I
      Dim registrosTotal = dtCabecera.Rows.Count

      Dim provs = dtCabecera.Select().ToList().
         ConvertAll(Function(dr)
                       Dim idSucursal = dr.Field(Of Integer)(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString())
                       Dim idTipoComprobante = dr.Field(Of String)(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString())
                       Dim letra = dr.Field(Of String)(Entidades.PedidoProveedor.Columnas.Letra.ToString())
                       Dim centroEmisor = dr.Field(Of Integer)(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString())
                       Dim numeroPedido = dr.Field(Of Long)(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString())

                       Dim prods = dtDetalle.Select(String.Format("{0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                                                  Entidades.PedidoProveedor.Columnas.IdSucursal.ToString(), idSucursal,
                                                                  Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString(), idTipoComprobante,
                                                                  Entidades.PedidoProveedor.Columnas.Letra.ToString(), letra,
                                                                  Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString(), centroEmisor,
                                                                  Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString(), numeroPedido)).ToList().
                                                 ConvertAll(Function(drP)
                                                               Return New Entidades.JSonEntidades.Archivos.OrdenCompraProductoJSon() With
                                                                      {
                                                                       .CuitEmpresa = Publicos.CuitEmpresa,
                                                                       .IdSucursal = idSucursal,
                                                                       .IdTipoComprobante = idTipoComprobante,
                                                                       .Letra = letra,
                                                                       .CentroEmisor = centroEmisor,
                                                                       .NumeroPedido = numeroPedido,
                                                                       .IdProducto = drP.Field(Of String)(Entidades.PedidoProductoProveedor.Columnas.IdProducto.ToString()),
                                                                       .NombreProducto = drP.Field(Of String)(Entidades.PedidoProductoProveedor.Columnas.NombreProducto.ToString()),
                                                                       .Cantidad = drP.Field(Of Decimal)(Entidades.PedidoProductoProveedor.Columnas.Cantidad.ToString()),
                                                                       .Precio = drP.Field(Of Decimal)(Entidades.PedidoProductoProveedor.Columnas.Costo.ToString()),
                                                                       .FechaEntrega = drP.Field(Of DateTime)(Entidades.PedidoEstadoProveedor.Columnas.FechaEntrega.ToString()).ToStringFormatoPropio(),
                                                                       .IdEstado = drP.Field(Of String)(Entidades.PedidoEstado.Columnas.IdEstado.ToString())
                                                                      }
                                                            End Function).ToArray()
                       registroActual += 1
                       RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendOC, registroActual, registrosTotal, String.Format("{0} {1} {2:0000}-{3:00000000}", idTipoComprobante, letra, centroEmisor, numeroPedido)))
                       Return New Entidades.JSonEntidades.Archivos.OrdenCompraJSon() _
                                  With {
                                        .CuitEmpresa = Publicos.CuitEmpresa,
                                        .IdSucursal = idSucursal,
                                        .IdTipoComprobante = idTipoComprobante,
                                        .Letra = letra,
                                        .CentroEmisor = centroEmisor,
                                        .NumeroPedido = numeroPedido,
                                        .IdProveedor = dr.Field(Of Long)(Entidades.PedidoProveedor.Columnas.IdProveedor.ToString()),
                                        .Fecha = dr.Field(Of DateTime)(Entidades.PedidoProveedor.Columnas.FechaPedido.ToString()).ToStringFormatoPropio(),
                                        .DatosOrdenCompra = prods,
                                        .FechaActualizacion = Now.ToStringFormatoPropio()
                                       }
                    End Function).Paginar(100)
      ''                                  .DatosOrdenCompra = _serializer.Serialize(prods).TrimStart("["c).TrimEnd("]"c),
      If reenviar And enviarWebOrdenCompra Then
         'servicioRest.Delete(ArmarURL("{0}/sigaordencomprajson/CuitEmpresa/{1}/"), headers:=Nothing)
      End If

      registroActual = 0
      registrosTotal = provs.Count
      For Each p In provs
         registroActual += 1
         RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendOC, registroActual, registrosTotal, "Enviando páginas orden compra (tamaño 100)"))
         If exportarOrdenCompra And Not String.IsNullOrWhiteSpace(Publicos.WebArchivos.CarpetaExportacion) Then
            IO.File.WriteAllText(String.Format("{0}\ordencompra_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(p))
         End If
         If enviarWebOrdenCompra Then
            servicioRest.Post(p, ArmarURL("{0}/sigaordencomprajson/"), headers:=Nothing, binario:=False)
         End If
      Next

      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagSendOC, Nothing, Nothing, "Finalizó"))

   End Sub

#End Region

#Region "DescargarRespuestas"
   Public Sub DescargarRespuestas(descargartodo As Boolean)
      EjecutaConConexion(Sub() _DescargarRespuestas(descargartodo))
   End Sub
   Private Sub _DescargarRespuestas(descargartodo As Boolean)
      Dim servicioRest = New ServiciosRest.Archivos.BaseArchivosWeb(Of OrdenCompraRespuestas)()

      Dim respuestas = servicioRest.Get("", 0, 10000000, Today, headers:=Nothing)

      EjecutaSoloConTransaccion(Function()
                                   GuardarRespuestas(respuestas)
                                   Return True
                                End Function)
   End Sub

   Private Sub GuardarRespuestas(respuestas As IEnumerable(Of OrdenCompraRespuestas))
      Dim regla = New PedidosEstadosProveedores(da)
      For Each ocr In respuestas
         regla._ActualizarEstadosWeb(ocr.IdSucursal, ocr.IdTipoComprobante, ocr.Letra, ocr.CentroEmisor, ocr.NumeroPedido,
                                     ocr.IdProducto, ocr.Orden,
                                     ocr.IdEstadoProducto, ocr.IdEstadoCantidad, ocr.IdEstadoPrecio, ocr.IdEstadoFechaEntrega,
                                     ocr.FechaEstadoProducto, ocr.FechaEstadoCantidad, ocr.FechaEstadoPrecio, ocr.FechaEstadoFechaEntrega)
      Next
   End Sub

#End Region

End Class

Public Class OrdenCompraRespuestas
   Public Property IdSucursal As Integer
   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroPedido As Long
   Public Property IdProducto As String
   Public Property Orden As Integer


   Public Property IdEstadoProducto As String
   Public Property IdEstadoCantidad As String
   Public Property IdEstadoPrecio As String
   Public Property IdEstadoFechaEntrega As String
   Public Property FechaEstadoProducto As DateTime?
   Public Property FechaEstadoCantidad As DateTime?
   Public Property FechaEstadoPrecio As DateTime?
   Public Property FechaEstadoFechaEntrega As DateTime?

End Class

Public Class AvanceSincronizarOrdenesCompraEventArgs
   Public Property Etapa As String
   Public Property RegistroActual As Integer?
   Public Property RegistrosTotal As Integer?
   Public Property Texto As String

   Public Sub New(etapa As String)
      Me.Etapa = etapa
   End Sub
   Public Sub New(etapa As String, registroActual As Integer?, registrosTotal As Integer?, texto As String)
      Me.New(etapa)
      Me.RegistroActual = registroActual
      Me.RegistrosTotal = registrosTotal
      Me.Texto = texto
   End Sub

   Public Overrides Function ToString() As String
      Dim stb = New StringBuilder()
      stb.AppendFormat("{0}", Etapa)
      If RegistroActual.HasValue And RegistrosTotal.HasValue Then
         stb.AppendFormat(" - {0}/{1}", RegistroActual.Value, RegistrosTotal.Value)
      ElseIf RegistroActual.HasValue And Not RegistrosTotal.HasValue Then
         stb.AppendFormat(" - Actual {0}", RegistroActual.Value)
      ElseIf Not RegistroActual.HasValue And RegistrosTotal.HasValue Then
         stb.AppendFormat(" - Total {0}", RegistrosTotal.Value)
      End If
      If Not String.IsNullOrWhiteSpace(Texto) Then
         stb.AppendFormat(" - {0}", Texto)
      End If
      Return stb.ToString()
   End Function


End Class