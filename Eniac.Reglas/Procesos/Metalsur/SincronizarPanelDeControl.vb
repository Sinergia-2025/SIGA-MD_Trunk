Option Strict On
Option Explicit On

Imports System.Web.Script.Serialization
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class SincronizarPanelDeControl
   Inherits Reglas.Base

   Private Const TagImpProv As String = "Imp. Proveedores"
   Private Const TagImpOC As String = "Imp. Ord. Compra"

   Private Const TagSendProv As String = "Enviar Panel de Control"
   Private Const TagSendOC As String = "Enviar Ord. Compra"

   Public Event Avance(sender As Object, e As AvanceSincronizarPanelDeControlEventArgs)

   Private _idFuncion As String

   Private _Resumen As DataTable = New DataTable()
   Private _ResumenMyL As DataTable = New DataTable()
   Private _ResumenUrbano As DataTable = New DataTable()

   Private _allMonths As List(Of DateTime)

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
   Public Sub Sincronizar(reenviar As Boolean, enviarWebPanelDeControl As Boolean, exportarPanelDeControl As Boolean,
                          enviarWebPanelDeFechasSalida As Boolean, exportarPanelDeFechasSalida As Boolean)
      'ImportarDesdeBejerman(reimportar)
      EnviarWeb(reenviar, enviarWebPanelDeControl, exportarPanelDeControl, enviarWebPanelDeFechasSalida,
                  exportarPanelDeFechasSalida)
      ' DescargarRespuestas(descargartodo)
   End Sub

#End Region

#Region "ImportarDesdeBejerman"
   Public Sub ImportarDesdeBejerman()
      ' EjecutaConConexion(Sub() _ImportarDesdeBejerman(reimportar))
   End Sub

   Private Sub _ImportarDesdeBejerman(reimportar As Boolean)
      Dim fechaDesdeProveedor = If(reimportar, Today.AddMonths(-6), Publicos.BejermanMetalsur.FechaModificacionProveedor.IfNull(Today.AddMonths(-6)))
      Dim fechaHastaProveedor As DateTime? = Nothing 'Today.UltimoDiaMes()

      Dim fechaDesdeOrdenCompra = If(reimportar, Today.AddMonths(-6), Publicos.BejermanMetalsur.FechaModificacionOrdenCompra.IfNull(Today.AddMonths(-6)))
      Dim fechaHastaOrdenCompra As DateTime? = Nothing 'Today.UltimoDiaMes()
      Dim nombreBase As String = String.Concat(Publicos.CalidadBaseExternaClientes, ".dbo.")


      Dim fechaModProveedor = ImportarProveedoresDesdeBejerman(nombreBase, fechaDesdeProveedor, fechaHastaProveedor)
      If fechaModProveedor.HasValue Then
         Publicos.WebArchivos.GuardarFechaUltimaDescarga(fechaModProveedor.Value, Entidades.Parametro.Parametros.BEJERMANFECHAMODIFICACIONPROVEEDOR, da)
      End If
      'Dim fechaModOrdenCompra = ImportarOrdenesCompraDesdeBejerman(nombreBase, fechaDesdeOrdenCompra, fechaHastaOrdenCompra)
      'If fechaModOrdenCompra.HasValue Then
      '   Publicos.WebArchivos.GuardarFechaUltimaDescarga(fechaModOrdenCompra.Value, Entidades.Parametro.Parametros.BEJERMANFECHAMODIFICACIONORDENCOMPRA, da)
      'End If

   End Sub

   Private Function ImportarProveedoresDesdeBejerman(nombreBase As String, fechaDesde As DateTime?, fechaHasta As DateTime?) As DateTime?
      RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagImpProv, Nothing, Nothing, "Leyendo Proveedores de Bejerman"))
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

         RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagImpProv, registroActual, registrosTotal, String.Format("{0} - {1}", codigoProveedor, nombreProveedor)))

         Dim proveedor = rProvee.GetUnoPorCodigoLetras(codigoProveedor, incluirFoto:=False, accion:=AccionesSiNoExisteRegistro.Nulo)
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

      RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagImpProv, Nothing, Nothing, "Finalizó"))

      Return result
   End Function

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

   'Private Function ImportarOrdenesCompraDesdeBejerman(nombreBase As String, fechaDesde As DateTime?, fechaHasta As DateTime?) As DateTime?
   '   RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Cabeceras de Orden de Compra de Bejerman"))
   '   Using dtC = New SqlServer.SincronizarOrdenesCompra(da).GetCabecerasBejerman(nombreBase, fechaDesde, fechaHasta, fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing)
   '      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Leyendo Detalles de Orden de Compra de Bejerman"))
   '      Using dtD = New SqlServer.SincronizarOrdenesCompra(da).GetDetallesBejerman(nombreBase, fechaDesde, fechaHasta)
   '         Return EjecutaSoloConTransaccion(Function() GrabarOrdenesCompraDesdeBejerman(dtC, dtD))
   '      End Using
   '   End Using
   'End Function

   'Private Function GrabarOrdenesCompraDesdeBejerman(dtCabecera As DataTable, dtDetalle As DataTable) As DateTime?
   '   Dim result As DateTime? = Nothing
   '   Dim dicTipoComprobante = New Dictionary(Of String, Tuple(Of Entidades.TipoComprobante, String, Short))()
   '   Dim cache = New BusquedasCacheadas()

   '   'Usamos sql directamente para agilizar el uso y respetar los valores tal cual estan en Bejerman
   '   Dim sqlPedido = New SqlServer.PedidosProveedores(da)
   '   Dim sqlProducto = New SqlServer.PedidosProductosProveedores(da)
   '   Dim sqlEstado = New SqlServer.PedidosEstadosProveedores(da)

   '   Dim rFormaPago = New VentasFormasPago(da)
   '   Dim rProducto = New Productos(da)
   '   Dim col = rProducto._GetTodosObservacion()
   '   If col.Count = 0 Then
   '      Throw New Exception("No existe ningún producto configurado como Producto Observación")
   '   End If
   '   Dim productoObservacion = col(0)
   '   Dim tipoImpuesto = New TiposImpuestos(da)._GetUno(Entidades.TipoImpuesto.Tipos.IVA)
   '   Dim idCriticidad = New Reglas.PedidosCriticidades(da).GetTodos().FirstOrDefault().IdCriticidad
   '   Dim idEstadoVisita = New Reglas.EstadosVisitas(da)._GetTodos(admitePedidoSinLineas:=Nothing, admintePedidoConLineas:=Nothing).FirstOrDefault().IdEstadoVisita

   '   Dim registroActual = 0I
   '   Dim registrosTotal = dtCabecera.Rows.Count

   '   For Each dr As DataRow In dtCabecera.Rows

   '      Dim idTipoComprobante = dr.Field(Of String)("spctco_Cod")
   '      Dim numeroPedido = Long.Parse(dr.Field(Of String)("spc_Nro"))
   '      Dim fechaModificacion = dr.Field(Of DateTime?)("scc_FecMod")
   '      If Not result.HasValue Then
   '         result = fechaModificacion
   '      Else
   '         If fechaModificacion.HasValue Then
   '            If fechaModificacion.Value > result.Value Then
   '               result = fechaModificacion
   '            End If
   '         End If
   '      End If

   '      registroActual += 1
   '      RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, registroActual, registrosTotal, String.Format("{0} - {1:00000000}", idTipoComprobante, numeroPedido)))

   '      If Not dicTipoComprobante.ContainsKey(idTipoComprobante) Then
   '         AddTipoComprobante(dicTipoComprobante, idTipoComprobante, cache)
   '      End If
   '      Dim tipoComprobante = dicTipoComprobante(idTipoComprobante)

   '      If Not sqlPedido.ExistePedido(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido) Then
   '         Dim numeroInterno = dr.Field(Of Integer)("spcscc_ID")
   '         Dim fechaPedido = dr.Field(Of DateTime)("scc_FEmision")
   '         Dim fechaActualizacion = dr.Field(Of DateTime?)("scc_FecMod").IfNull(Now)
   '         Dim codigoProveedor = dr.Field(Of String)("sccpro_Cod")
   '         Dim codigoFormaPago = dr.Field(Of String)("scccpg_Cod")
   '         Dim observaciones = dr.Field(Of String)("scctxa_Texto")

   '         Dim idProveedor = cache.BuscaProveedor(codigoProveedor).IdProveedor
   '         Dim idComprador = cache.GetPrimerComprador().IdEmpleado
   '         Dim formaPago = cache.BuscaFormasPago(codigoFormaPago)
   '         If formaPago Is Nothing Then
   '            formaPago = rFormaPago._Insertar(codigoFormaPago)
   '         End If
   '         Dim idFormaPago = formaPago.IdFormasPago

   '         Dim colDrP = dtDetalle.Select(String.Format("spcemp_Codigo = '{0}' AND spcsuc_Cod = '{1}' AND spcscc_ID = {2} AND spctco_Circuito = '{3}' AND spctco_Cod = '{4}'",
   '                                                     dr.Field(Of String)("spcemp_Codigo"),
   '                                                     dr.Field(Of String)("spcsuc_Cod"),
   '                                                     dr.Field(Of Integer)("spcscc_ID"),
   '                                                     dr.Field(Of String)("spctco_Circuito"),
   '                                                     dr.Field(Of String)("spctco_Cod")))

   '         Dim importeTotal = colDrP.Sum(Function(drP) (drP.Field(Of Double)("sdc_PrecioUn") * drP.Field(Of Double)("sdc_CantUM1")).ToDecimal())
   '         sqlPedido.PedidosProveedores_I(actual.Sucursal.Id,
   '                                        tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido,
   '                                        fechaPedido, observaciones, actual.Nombre, descuentoRecargo:=0, descuentoRecargoPorc:=0,
   '                                        IdProveedor:=idProveedor, IdComprador:=idComprador, idFormaPago:=idFormaPago, idTransportista:=Nothing,
   '                                        NumeroOrdenCompra:=numeroInterno, cotizacionDolar:=cache.BuscaMoneda(Entidades.Moneda.Dolar).FactorConversion,
   '                                        idTipoComprobanteFact:="", ImporteBruto:=importeTotal, SubTotal:=importeTotal, TotalImpuestos:=0, TotalImpuestoInterno:=0, ImporteTotal:=importeTotal,
   '                                        idEstadoVisita:=idEstadoVisita, kilos:=0)

   '         For Each drP In colDrP.OrderBy(Function(x) x.Field(Of Short)("sdc_NReng"))
   '            Dim nroRenglon = drP.Field(Of Short)("sdc_NReng")
   '            Dim tipoItem = drP.Field(Of String)("sdc_TipoIt")      'Tipo de Item: A=artículo / C=Concepto / L=Leyenda / D=Descuento.
   '            Dim idArticulo = drP.Field(Of String)("sdcart_CodGen")
   '            Dim idConcepto = drP.Field(Of String)("sdccon_Cod")
   '            Dim descArtic = drP.Field(Of String)("sdc_Desc")

   '            Dim descRec1 = 0D 'drP.Field(Of Double)("sdc_TasaBon").ToDecimal()
   '            Dim descRec2 = 0D
   '            Dim cantidad = drP.Field(Of Double)("sdc_CantUM1").ToDecimal()
   '            Dim precio = drP.Field(Of Double)("sdc_PrecioUn").ToDecimal()

   '            Dim idProducto = If(tipoItem = "A", idArticulo, If(tipoItem = "C", idConcepto, productoObservacion.IdProducto))

   '            If Not cache.ExisteProductoPorIdRapido(idProducto) Then
   '               rProducto.InsertaCalidad(If(tipoItem = "A", idArticulo, idConcepto), descArtic, "OC", cache, _idFuncion)
   '               cache.AgregarParaExisteProductoPorIdRapido(idProducto)
   '            End If

   '            'Dim producto As Entidades.Producto
   '            'If tipoItem = "A" Then
   '            '   producto = cache.BuscaProductoEntidadPorId(idArticulo, AccionesSiNoExisteRegistro.Nulo)
   '            'ElseIf tipoItem = "C" Then
   '            '   producto = cache.BuscaProductoEntidadPorId(idConcepto, AccionesSiNoExisteRegistro.Nulo)
   '            'Else
   '            '   producto = productoObservacion
   '            'End If
   '            'If producto Is Nothing Then
   '            '   producto = rProducto.InsertaCalidad(If(tipoItem = "A", idArticulo, idConcepto), descArtic, cache, _idFuncion)
   '            'End If


   '            sqlProducto.PedidosProductosProveedores_I(actual.Sucursal.Id,
   '                                                      tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido,
   '                                                      idProducto, nroRenglon, idProveedor, cantidad, precio, precio, precio,
   '                                                      descRec1, descRec2,
   '                                                      FechaActualizacion:=fechaActualizacion, fechaEntrega:=fechaPedido,
   '                                                      importeTotal:=precio * cantidad, importeTotalNeto:=precio * cantidad,
   '                                                      nombreProducto:=descArtic, cantPendiente:=cantidad,
   '                                                      idTipoImpuesto:=Entidades.TipoImpuesto.Tipos.IVA, alicuotaImpuesto:=Publicos.ProductoIVA,
   '                                                      descuentoRecargoProducto:=0, descRecGeneral:=0, descRecGeneralProducto:=0,
   '                                                      importeImpuesto:=0, impuestoInterno:=0, importeImpuestoInterno:=0, porcImpuestoInterno:=0,
   '                                                      cantEntregada:=0, cantEnProceso:=0, cantAnulada:=0, kilos:=0, idCriticidad:=idCriticidad,
   '                                                      costoConImpuestos:=0, costoNetoConImpuestos:=0, importeTotalConImpuestos:=0, importeTotalNetoConImpuestos:=0)

   '            Dim idEstadoPedido = If(dr.Field(Of Boolean)("scc_CumpXPgm"), Publicos.PedidoProveedorEstadoAnulado, Entidades.EstadoPedidoProveedor.TipoEstado.PENDIENTE)

   '            sqlEstado.PedidosEstadosProveedores_I(actual.Sucursal.Id,
   '                                                  tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido,
   '                                                  idProducto, fechaPedido, idProveedor, idEstadoPedido,
   '                                                  actual.Nombre, observaciones,
   '                                                  cantidad, String.Empty, String.Empty, 0, 0,
   '                                                  nroRenglon, idCriticidad, fechaPedido, "PEDIDOSPROV",
   '                                                  0, 0, String.Empty, String.Empty, 0, 0, 0, String.Empty, String.Empty, 0, 0,
   '                                                  idEstadoProducto:=String.Empty, idEstadoCantidad:=String.Empty, idEstadoPrecio:=String.Empty, idEstadoFechaEntrega:=String.Empty,
   '                                                  fechaEstadoProducto:=Nothing, fechaEstadoCantidad:=Nothing, fechaEstadoPrecio:=Nothing, fechaEstadoFechaEntrega:=Nothing)

   '         Next
   '         dtDetalle.Rows.RemoveRowRange(colDrP)
   '      Else
   '         If dr.Field(Of Boolean)("scc_CumpXPgm") Then
   '            If sqlEstado.PedidosEstadosProveedores_GA(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, Publicos.PedidoProveedorEstadoAnulado).Rows.Count = 0 Then
   '               Dim rEstado = New Reglas.PedidosProveedores(da)
   '               rEstado._AnularPedidos(actual.Sucursal.Id, tipoComprobante.Item1.IdTipoComprobante, tipoComprobante.Item2, tipoComprobante.Item3, numeroPedido, "PEDIDOSPROV", _idFuncion)
   '            End If
   '         End If
   '      End If
   '   Next
   '   RaiseEvent Avance(Me, New AvanceSincronizarOrdenesCompraEventArgs(TagImpOC, Nothing, Nothing, "Finalizó"))
   '   Return result
   'End Function

   Private Sub AddTipoComprobante(dicTipoComprobante As Dictionary(Of String, Tuple(Of Entidades.TipoComprobante, String, Short)),
                                  idTipoComprobante As String,
                                  cache As BusquedasCacheadas)
      Dim tp = cache.BuscaTipoComprobante(idTipoComprobante)
      Dim impresoras = New Impresoras(da)._GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, idTipoComprobante)
      dicTipoComprobante.Add(idTipoComprobante, Tuple.Create(tp, tp.LetrasHabilitadas, impresoras.CentroEmisor))
   End Sub
#End Region

#Region "EnviarWeb"
   Public Sub EnviarWeb(reenviar As Boolean, enviarWebPanelDeControl As Boolean, exportarPanelDeControl As Boolean,
                         enviarWebPanelDeFechasSalida As Boolean, exportarPanelDeFechasSalida As Boolean)
      EjecutaConConexion(Sub() _EnviarWeb(reenviar, enviarWebPanelDeControl, exportarPanelDeControl,
                                          enviarWebPanelDeFechasSalida, exportarPanelDeFechasSalida))
   End Sub
   Public Sub _EnviarWeb(reenviar As Boolean, enviarWebPanelDeControl As Boolean, exportarPanelDeControl As Boolean,
                          enviarWebPanelDeFechasSalida As Boolean, exportarPanelDeFechasSalida As Boolean)
      If enviarWebPanelDeControl Or exportarPanelDeControl Then
         Me.EnviarWebPanelDeControl(reenviar, enviarWebPanelDeControl, exportarPanelDeControl)
      End If
      If enviarWebPanelDeFechasSalida Or exportarPanelDeFechasSalida Then
         Me.EnviarWebPanelDeFechasSalida(reenviar, enviarWebPanelDeFechasSalida, exportarPanelDeFechasSalida)
      End If

      Me.DescargarAuditorias()

      'If EnviarWebOrdenCompra() Or exportarOrdenCompra Then
      '   Me.EnviarWebOrdenCompra(reenviar, EnviarWebOrdenCompra, exportarOrdenCompra)
      'End If
   End Sub

   Public Sub DescargarAuditorias()
      Me._DescargarAuditorias()
   End Sub
   Private Sub _DescargarAuditorias()
      Dim servicioRest = New ServiciosRest.Archivos.BaseArchivosWeb(Of PanelDeControlRespuestas)()
      Dim desde As String = Date.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss")
      Dim Hasta As String = Date.Now.ToString("yyyy-MM-dd HH:mm:ss")
      Try
         Dim respuestas = servicioRest.Get(Eniac.Reglas.Publicos.CalidadURLAuditoriasLoginWeb.ToString() & "FechaDesde/" & desde.ToString() & "/FechaHasta/" & Hasta.ToString() & "/", 0, 10000000, Today, headers:=Nothing)

         EjecutaSoloConTransaccion(Function()
                                      GuardarAuditorias(respuestas)
                                      Return True
                                   End Function)
      Catch ex As Exception

      End Try
   End Sub

   Private Sub GuardarAuditorias(respuestas As IEnumerable(Of PanelDeControlRespuestas))
      Dim regla = New Reglas.AuditoriaLoginWeb(da)
      Dim Auditoria As Entidades.AuditoriaLoginWeb
      Dim Audit As DataTable
      For Each ocr In respuestas
         If ocr.estado_registro = "0" Then
            Audit = regla.GetAuditoria(ocr.Id)
            If Audit.Rows.Count = 0 Then
               Auditoria = New Entidades.AuditoriaLoginWeb
               With Auditoria
                  .Id = ocr.Id
                  .sincronizado = "1"
                  .id_usuario = ocr.id_usuario
                  .nombre_usuario = ocr.nombre_usuario
                  .ip = ocr.ip
                  .pais_code = ocr.pais_code
                  .pais = ocr.pais
                  .login = Date.Parse(ocr.login.ToString())
                  If ocr.logout IsNot Nothing Then
                     .logout = Date.Parse(ocr.logout.ToString())
                  End If
                  .navegador = ocr.navegador
                  .estado_registro = "1"
               End With
               regla._Insertar(Auditoria)
            End If
         End If
      Next

      Dim Auditorias = New List(Of Entidades.JSonEntidades.Archivos.AuditoriaLoginActualizarEstadoJSon)()

      For Each ocr In respuestas
         If ocr.estado_registro = "0" Then
            Auditorias.Add(New Entidades.JSonEntidades.Archivos.AuditoriaLoginActualizarEstadoJSon With
                        {
                           .Id = ocr.Id.ToString(),
                           .Estado = "1"
                        })
         End If
      Next
      Dim servicioRestAuditoria = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporteAuditorias)()
      Dim datosAuditorias = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporteAuditorias With {.Auditorias = Auditorias}

      ' IO.File.WriteAllText(String.Format("{0}\Auditoria_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, 0), _serializer.Serialize(datosAuditorias))

      servicioRestAuditoria.Post(datosAuditorias, ArmarURL(Eniac.Reglas.Publicos.CalidadURLActualizaAuditoriasLoginWeb.ToString()), headers:=Nothing, binario:=False)

   End Sub

   Private Function ArmarURL(formato As String) As String
      Return String.Format(formato, Publicos.BejermanMetalsur.MetalsurUrlBaseWebOC, Publicos.CuitEmpresa)
   End Function

   Private _serializer As JavaScriptSerializer = New JavaScriptSerializer()
   Private Sub EnviarWebPanelDeControl(reenviar As Boolean, enviarWebPanelDeControl As Boolean, exportarPanelDeControl As Boolean)

      Dim servicioRestEncab = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeControlJSonTransporteEncab)()
      Dim servicioRestEncabURB = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeControlJSonTransporteEncab)()
      Dim servicioRestEncabMYL = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeControlJSonTransporteEncab)()

      Dim servicioRest = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeControlJSonTransporte)()

      My.Application.Log.WriteEntry(String.Format("{0} - {1}", "SincronizarPanelDeControl.EnviarWebOrdenCompra", ArmarURL("{0}/sigaordencomprajsonmax/CuitEmpresa/{1}/")), TraceEventType.Verbose)

      Dim fechaMax As DateTime? = Nothing
      If Not reenviar Then
         RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, Nothing, Nothing, "Obteniendo fecha máxima"))
         fechaMax = servicioRest.GetMaxFecha(ArmarURL("{0}/sigaproveedorjsonmax/CuitEmpresa/{1}/"), headers:=Nothing)
      End If

      RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, Nothing, Nothing, "Leyendo Panel de Control desde SIGA"))

      Dim regla = New Reglas.ListasControlProductos()

      Dim pivotResult = regla.GetPanelDeControlWeb(String.Empty, Nothing, Nothing,
                                                                 0, 0, String.Empty,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.NO, 0)

      Dim pivotResultUrbano = regla.GetPanelDeControlWeb(String.Empty, Nothing, Nothing,
                                                                 0, 0, String.Empty,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.NO, 1)

      Dim pivotResultMyL = regla.GetPanelDeControlWeb(String.Empty, Nothing, Nothing,
                                                                 0, 0, String.Empty,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.NO, 2)

      Dim Datos As DataTable = pivotResult.dtResult
      For Each dr As DataRow In Datos.Rows
         If String.IsNullOrEmpty(dr("IdListaControlTipo__1").ToString()) Then
            dr.Delete()
         End If
      Next
      Datos.AcceptChanges()
      Dim registroActual = 0I
      Dim registrosTotal = pivotResult.dtResult.Rows.Count

      Dim Totales = Me.CalcularTotales(pivotResult.dtResult, pivotResult)

      Dim TotalesUrbano = Me.CalcularTotales(pivotResultUrbano.dtResult, pivotResultUrbano)

      Dim TotalesMyL = Me.CalcularTotales(pivotResultMyL.dtResult, pivotResultMyL)

      'Armado de json
      Dim ColorEstado As System.Drawing.Color
      Dim color As System.Drawing.Color = System.Drawing.SystemColors.Control

      Dim colorPendiente = System.Drawing.Color.Red
      Dim colorEnProceso = System.Drawing.Color.Yellow
      Dim colorFinalizado = System.Drawing.Color.Green
      Dim RR, GG, BB As Byte


      Datos.Columns.Remove("IdListaControlTipo__8")

      Try
         Dim Panel = Datos.Select().ToList().ConvertAll(
            Function(dr)
               Dim fechaLiberado As String
               If String.IsNullOrEmpty(dr.Field(Of Date?)(Entidades.Producto.Columnas.CalidadFechaLiberado.ToString()).ToString()) Then
                  fechaLiberado = String.Empty
               Else
                  fechaLiberado = dr.Field(Of Date?)(Entidades.Producto.Columnas.CalidadFechaLiberado.ToString()).ToStringFormatoPropio()
               End If
               '    Modelo = Strings.Split(dr.Field(Of String)(Entidades.ProductoModelo.Columnas.NombreProductoModelo.ToString()), "-")
               Dim json = New Entidades.JSonEntidades.Archivos.PanelDeControlJSon With
                              {
                                 .Codigo = dr.Field(Of String)(Entidades.Producto.Columnas.IdProducto.ToString()),
                                 .Modelo = dr.Field(Of String)(Entidades.ProductoModelo.Columnas.NombreProductoModelo.ToString()),
                                 .TipoModelo = dr.Field(Of String)(Entidades.ProductoModeloTipo.Columnas.NombreProductoModeloTipo.ToString()),
                                 .Cliente = dr.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString()),
                                 .FechaIngreso = dr.Field(Of Date)(Entidades.Producto.Columnas.CalidadFechaIngreso.ToString()).ToStringFormatoPropio(),
                                 .FechaLiberado = fechaLiberado,
                                 .FechaEntregaReProg = .FechaLiberado
                                             }
               For Each drCol As DataColumn In dr.Table.Columns

                  If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then

                     If Not String.IsNullOrEmpty(dr.Field(Of Integer?)("E" + drCol.ColumnName).ToString()) Then
                        If Integer.Parse(dr.Field(Of Integer?)("E" + drCol.ColumnName).ToString()) = Reglas.Publicos.EstadoListaControlPendiente.ValorNumericoPorDefecto(0I) Then
                           RR = 255
                           GG = 99
                           BB = 71
                        ElseIf Integer.Parse(dr.Field(Of Integer?)("E" + drCol.ColumnName).ToString()) = Reglas.Publicos.EstadoListaControlTerminado Then
                           RR = 144
                           GG = 238
                           BB = 144
                        Else
                           RR = 255
                           GG = 246
                           BB = 122
                        End If
                     End If

                     json.Secciones.Add(New Entidades.JSonEntidades.Archivos.PanelDeControlSeccionesJSon() With
                                            {
                                                .IdColumna = drCol.ColumnName,
                                                .Fecha = dr.Field(Of Date?)(drCol.ColumnName).ToStringFormatoPropio(),
                                                .Color = RR & "," & GG & "," & BB
                                            })
                  End If
               Next

               Return json

            End Function) ''.Paginar(100)


         Dim drTotales = Totales.Rows(0)
         Dim drTotalesUrbano = TotalesUrbano.Rows(0)
         Dim drTotalesMyL = TotalesMyL.Rows(0)

         Dim tot = New List(Of Entidades.JSonEntidades.Archivos.PanelDeControlColumnasJSon)()
         Dim totUrbano = New List(Of Entidades.JSonEntidades.Archivos.PanelDeControlColumnasJSon)()
         Dim totMyL = New List(Of Entidades.JSonEntidades.Archivos.PanelDeControlColumnasJSon)()

         Dim Tipo As Integer = 0

         'Totales Generales
         For Each drCol As DataColumn In Totales.Columns
            If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then

               Tipo = Integer.Parse(drCol.ColumnName.Replace("IdListaControlTipo__", "").ToString())

               tot.Add(New Entidades.JSonEntidades.Archivos.PanelDeControlColumnasJSon With
                           {
                              .IdColumna = drCol.ColumnName,
                              .Cantidad = drTotales.Field(Of Integer?)(drCol.ColumnName).IfNull(),
                              .Etiqueta = New Reglas.ListasControlTipos().GetUno(Tipo).NombreListaControlTipo
                           })

            End If
         Next

         'Totales Generales Urbano
         For Each drCol As DataColumn In TotalesUrbano.Columns
            If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then

               Tipo = Integer.Parse(drCol.ColumnName.Replace("IdListaControlTipo__", "").ToString())

               totUrbano.Add(New Entidades.JSonEntidades.Archivos.PanelDeControlColumnasJSon With
                           {
                              .IdColumna = drCol.ColumnName,
                              .Cantidad = drTotalesUrbano.Field(Of Integer?)(drCol.ColumnName).IfNull(),
                              .Etiqueta = New Reglas.ListasControlTipos().GetUno(Tipo).NombreListaControlTipo
                           })

            End If
         Next

         'Totales Generales MyL
         For Each drCol As DataColumn In TotalesMyL.Columns
            If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then

               Tipo = Integer.Parse(drCol.ColumnName.Replace("IdListaControlTipo__", "").ToString())

               totMyL.Add(New Entidades.JSonEntidades.Archivos.PanelDeControlColumnasJSon With
                           {
                              .IdColumna = drCol.ColumnName,
                              .Cantidad = drTotalesMyL.Field(Of Integer?)(drCol.ColumnName).IfNull(),
                              .Etiqueta = New Reglas.ListasControlTipos().GetUno(Tipo).NombreListaControlTipo
                           })

            End If
         Next

         Dim datosEnviarEncab = New Entidades.JSonEntidades.Archivos.PanelDeControlJSonTransporteEncab With {.Columnas = tot}
         Dim datosEnviarEncabUrbano = New Entidades.JSonEntidades.Archivos.PanelDeControlJSonTransporteEncab With {.Columnas = totUrbano}
         Dim datosEnviarEncabMyL = New Entidades.JSonEntidades.Archivos.PanelDeControlJSonTransporteEncab With {.Columnas = totMyL}

         Dim datosEnviar = New Entidades.JSonEntidades.Archivos.PanelDeControlJSonTransporte With {.Datos = Panel}

         registroActual = 0
         registrosTotal = Panel.Count

         RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, registroActual, registrosTotal, "Enviando Panel de Control (tamaño 100)"))
         If exportarPanelDeControl And Not String.IsNullOrWhiteSpace(Publicos.WebArchivos.CarpetaExportacion) Then
            IO.File.WriteAllText(String.Format("{0}\panelcontrolEncab_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviarEncab))
            IO.File.WriteAllText(String.Format("{0}\panelcontrolEncabUrb_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviarEncabUrbano))
            IO.File.WriteAllText(String.Format("{0}\panelcontrolEncabMyL_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviarEncabMyL))
            IO.File.WriteAllText(String.Format("{0}\panelcontrol_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviar))
         End If

         If enviarWebPanelDeControl Then

            'servicioRestEncab.Post(datosEnviarEncab, ArmarURL("{0}/sigapanelcontroljson/"), headers:=Nothing, binario:=False)
            'servicioRest.Post(datosEnviar, ArmarURL("{0}/sigapanelcontroljson/"), headers:=Nothing, binario:=False)

            servicioRestEncab.Post(datosEnviarEncab, ArmarURL(Eniac.Reglas.Publicos.CalidadURLHeaderPC.ToString()), headers:=Nothing, binario:=False)
            servicioRestEncabURB.Post(datosEnviarEncabUrbano, ArmarURL(Eniac.Reglas.Publicos.CalidadURLHeaderURBPC.ToString()), headers:=Nothing, binario:=False)
            servicioRestEncabMYL.Post(datosEnviarEncabMyL, ArmarURL(Eniac.Reglas.Publicos.CalidadURLHeaderMyLPC.ToString()), headers:=Nothing, binario:=False)

            servicioRest.Post(datosEnviar, ArmarURL(Eniac.Reglas.Publicos.CalidadURLItemsPC.ToString()), headers:=Nothing, binario:=False)

            servicioRest.Post(String.Empty, ArmarURL(Eniac.Reglas.Publicos.CalidadURLSincroPC.ToString()), headers:=Nothing, binario:=False)

         End If
         '         Next

         RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, Nothing, Nothing, "Finalizó"))

      Catch ex As Exception
         Throw
      End Try

      'Dim dtProveedores = New SqlServer.SincronizarOrdenesCompra(da).GetProveedoresSIGA(fechaMax, fechaHasta:=Nothing)    
      'Dim registroActual = 0I
      ' Dim registrosTotal = dtProveedores.Rows.Count
      'Try
      '   Dim provs = dtProveedores.Select().ToList().ConvertAll(Function(dr)
      '                                                             Dim json = New With {.CuitEmpresa = Publicos.CuitEmpresa,
      '                                                                                  .IdProveedor = dr.Field(Of Long)(Entidades.Proveedor.Columnas.IdProveedor.ToString()),
      '                                                                                  .CodigoProveedor = dr.Field(Of Long)(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()),
      '                                                                                  .NombreProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.NombreProveedor.ToString()),
      '                                                                                  .NroDocProveedor = dr.Field(Of Long?)(Entidades.Proveedor.Columnas.NroDocProveedor.ToString()).ToString(),
      '                                                                                  .DireccionProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.DireccionProveedor.ToString()),
      '                                                                                  .TelefonoProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.TelefonoProveedor.ToString()),
      '                                                                                  .CorreoElectronico = dr.Field(Of String)(Entidades.Proveedor.Columnas.CorreoElectronico.ToString())}
      '                                                             If String.IsNullOrWhiteSpace(json.NroDocProveedor) Then
      '                                                                json.NroDocProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.CuitProveedor.ToString())
      '                                                             End If
      '                                                             registroActual += 1
      '                                                             RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, registroActual, registrosTotal, String.Format("{0} - {1}", json.CodigoProveedor, json.NombreProveedor)))
      '                                                             Return New Entidades.JSonEntidades.Archivos.PanelDeControlJSonTransporte() _
      '                                                                        With {.CuitEmpresa = Publicos.CuitEmpresa,
      '                                                                              .IdProveedor = json.IdProveedor,
      '                                                                              .DatosProveedor = _serializer.Serialize(json),
      '                                                                              .FechaActualizacion = Now.ToStringFormatoPropio()}
      '                                                          End Function).Paginar(100)

      '   If reenviar And enviarWebPanelDeControl Then
      '      RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, Nothing, Nothing, "Borrando proveedores"))
      '      servicioRest.Delete(ArmarURL("{0}/sigaproveedorjson/CuitEmpresa/{1}/"), headers:=Nothing)
      '   End If

      '   registroActual = 0
      '   registrosTotal = provs.Count
      '   For Each p In provs
      '      registroActual += 1
      '      RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, registroActual, registrosTotal, "Enviando páginas proveedores (tamaño 100)"))
      '      If exportarPanelDeControl And Not String.IsNullOrWhiteSpace(Publicos.WebArchivos.CarpetaExportacion) Then
      '         IO.File.WriteAllText(String.Format("{0}\proveedor_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(p))
      '      End If
      '      If enviarWebPanelDeControl Then
      '         servicioRest.Post(p, ArmarURL("{0}/sigaproveedorjson/"), headers:=Nothing, binario:=False)
      '      End If
      '   Next

      'RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, Nothing, Nothing, "Finalizó"))
      'Catch
      'Throw
      '  End Try

   End Sub

   Public Function CalcularTotales(Datos As DataTable, pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo) As DataTable


      'Tabla con totales de cada seccion
      Dim Totales As DataTable = Datos.Clone()
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         Dim colName = drColumnas("NombreColumma").ToString()
         Totales.Columns(colName).DataType = GetType(Integer)
      Next
      Totales.Columns("CalidadFechaLiberado").DataType = GetType(Integer)

      Dim dr2 As DataRow = Totales.NewRow()
      Dim _countPropio As Integer
      Dim _countDerecha As Integer
      Dim _proximaColumna As String
      Dim _resultado As Integer

      Dim Totales2 As DataTable = pivotResult.dtColumnas
      For Each dr As DataRow In Totales2.Rows
         If Integer.Parse(dr("IdListaControlTipo").ToString()) = 8 Then
            dr.Delete()
         End If
      Next
      Totales2.AcceptChanges()

      Dim dr3 As DataRow = Totales2.NewRow()
      dr3("NombreColumma") = "CalidadFechaLiberado"
      dr3("Rangohasta") = 6000
      Totales2.Rows.Add(dr3)

      For Each drColumnas As DataRow In Totales2.Rows
         Dim colName = drColumnas("NombreColumma").ToString()
         _countPropio = 0
         _countDerecha = 0
         _proximaColumna = String.Empty
         Dim colRows = Totales2.Select(String.Format("NombreColumma = '{0}'", colName))
         If colRows.Length > 0 Then
            Dim drPropio = colRows(0)
            Dim hastaPropio = drPropio.Field(Of Integer)("RangoHasta")
            Dim colMayores = Totales2.Select(String.Format("RangoHasta > {0}", hastaPropio))
            If colMayores.Length > 0 Then
               _proximaColumna = colMayores(0).Field(Of String)("NombreColumma")
            End If
         End If
         For Each dr1 As DataRow In pivotResult.dtResult.Rows
            If IsDate(dr1(colName).ToString()) Then
               _countPropio += 1
               If Not String.IsNullOrWhiteSpace(_proximaColumna) AndAlso IsDate(dr1(_proximaColumna).ToString()) Then
                  _countDerecha += 1
               End If
            End If
         Next
         _resultado = _countPropio - _countDerecha

         dr2(colName) = _resultado
      Next
      Totales.Rows.Add(dr2)
      Totales.Columns.Remove("IdListaControlTipo__8")
      Return Totales
   End Function
   Private Sub EnviarWebPanelDeFechasSalida(reenviar As Boolean, enviarWebPanelDeFechasSalida As Boolean, exportarPanelDeFechasSalida As Boolean)

      Dim servicioRestEncab = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporteEncab)()
      Dim servicioRest = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporte)()
      Dim servicioRestPeriodo = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransportePeriodos)()

      RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, Nothing, Nothing, "Leyendo Panel de Fechas de Salida desde SIGA"))

      Dim regla = New Reglas.ListasControlProductos()

      Dim pivotResult = regla.GetLeadTimeListasControlTipo(String.Empty, Nothing, Nothing,
                                                                Nothing, Nothing,
                                                                0, 0, String.Empty,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS, 0)

      Dim pivotResultMyL = regla.GetLeadTimeListasControlTipo(String.Empty, Nothing, Nothing,
                                                                Nothing, Nothing,
                                                                0, 0, String.Empty,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS, 2)

      Dim pivotResultUrbano = regla.GetLeadTimeListasControlTipo(String.Empty, Nothing, Nothing,
                                                                Nothing, Nothing,
                                                                0, 0, String.Empty,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS, 1)

      Dim Datos As DataTable = pivotResult.dtResult
      Dim DatosMyL As DataTable = pivotResultMyL.dtResult
      Dim DatosUrbano As DataTable = pivotResultUrbano.dtResult

      Me.MoverFechasSalida(pivotResult)
      Me.MoverFechasSalida(pivotResultMyL)
      Me.MoverFechasSalida(pivotResultUrbano)


      Dim CantPeriodos As Integer = 1

      Dim FechaDesde As Date
      Dim FechaAct As Date
      ' FechaDesde = New Date(Date.Today.Year, Date.Today.Month, 1)
      FechaAct = New Date(Date.Today.Year, Date.Today.Month, 1)
      FechaDesde = New Date(Date.Today.Year - 1, 12, 1)
      Dim FechaHasta As Date
      FechaHasta = FechaAct.AddMonths(1).AddSeconds(-1)


      Me.FiltroFechaSalida(pivotResult, FechaDesde, FechaHasta)
      Me.FiltroFechaSalida(pivotResultMyL, FechaDesde, FechaHasta)
      Me.FiltroFechaSalida(pivotResultUrbano, FechaDesde, FechaHasta)

      Me.ResumenFechaSalida(pivotResult, FechaDesde, FechaHasta)
      Me.ResumenFechaSalidaMyL(pivotResultMyL, FechaDesde, FechaHasta)
      Me.ResumenFechaSalidaUrbano(pivotResultUrbano, FechaDesde, FechaHasta)

      Dim registroActual = 0I
      Dim registrosTotal = pivotResult.dtResult.Rows.Count

      'Armado de json
      Try
         'Json Completo
         Dim Panel = _Resumen.Select().ToList().ConvertAll(
            Function(dr)
               Dim json = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSon With
                              {.FechaSalida = dr.Field(Of Date)("FechaSalida").ToStringFormatoPropio()
                              }
               For Each drCol As DataColumn In dr.Table.Columns
                  If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then
                     json.Secciones.Add(New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaSeccionesJSon() With
                                            {
                                                .IdColumna = drCol.ColumnName,
                                                .Cantidad = dr.Field(Of Integer)(drCol.ColumnName)
                                            })
                  End If
               Next

               Return json

            End Function) ''.Paginar(100)

         'Json MyL
         Dim PanelMyL = _ResumenMyL.Select().ToList().ConvertAll(
            Function(dr)
               Dim json = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSon With
                              {.FechaSalida = dr.Field(Of Date)("FechaSalida").ToStringFormatoPropio()
                              }
               For Each drCol As DataColumn In dr.Table.Columns
                  If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then
                     json.Secciones.Add(New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaSeccionesJSon() With
                                            {
                                                .IdColumna = drCol.ColumnName,
                                                .Cantidad = dr.Field(Of Integer)(drCol.ColumnName)
                                            })
                  End If
               Next

               Return json

            End Function) ''.Paginar(100)

         'Json Urbano
         Dim PanelUrbano = _ResumenUrbano.Select().ToList().ConvertAll(
            Function(dr)
               Dim json = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSon With
                              {.FechaSalida = dr.Field(Of Date)("FechaSalida").ToStringFormatoPropio()
                              }
               For Each drCol As DataColumn In dr.Table.Columns
                  If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then
                     json.Secciones.Add(New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaSeccionesJSon() With
                                            {
                                                .IdColumna = drCol.ColumnName,
                                                .Cantidad = dr.Field(Of Integer)(drCol.ColumnName)
                                            })
                  End If
               Next

               Return json

            End Function) ''.Paginar(100)


         '  Dim drTotales = Totales.Rows(0)
         Dim tot = New List(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaColumnasJSon)()
         Dim Tipo As Integer = 0

         For Each drCol As DataColumn In _Resumen.Columns

            If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then

               Tipo = Integer.Parse(drCol.ColumnName.Replace("IdListaControlTipo__", "").ToString())

               tot.Add(New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaColumnasJSon With
                           {
                              .IdColumna = drCol.ColumnName,
                              .Etiqueta = New Reglas.ListasControlTipos().GetUno(Tipo).NombreListaControlTipo
                           })

            End If

         Next

         Dim Periodos = New List(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaPeriodosJSon)()

         For Each fec As Date In _allMonths

            Periodos.Add(New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaPeriodosJSon With
                           {
                              .Periodo = fec.ToString("yyyyMM"),
                              .EtiquetaPeriodo = fec.GetMesEnEspanol().ToString() + " " + fec.ToString("yyyy")
                           })

         Next

         Dim fecha As DateTime = Today
         Dim mes As String = fecha.GetMonthEnEspanol()

         'Panel Completo
         Dim datosEnviarEncab = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporteEncab With {.Columnas = tot}
         Dim datosEnviar = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporte With {.Datos = Panel}
         Dim datosPeriodos = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransportePeriodos With {.Periodos = Periodos}

         'Panel MyL
         Dim datosEnviarMyL = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporte With {.Datos = PanelMyL}

         'Panel Urbano
         Dim datosEnviarUrbano = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporte With {.Datos = PanelUrbano}

         registroActual = 0
         registrosTotal = Panel.Count

         RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, registroActual, registrosTotal, "Enviando Panel de Fechas de Salida"))
         If exportarPanelDeFechasSalida And Not String.IsNullOrWhiteSpace(Publicos.WebArchivos.CarpetaExportacion) Then
            'Panel Completo
            IO.File.WriteAllText(String.Format("{0}\panelFechasSalidaEncab_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviarEncab))
            IO.File.WriteAllText(String.Format("{0}\panelFechasSalida_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviar))
            IO.File.WriteAllText(String.Format("{0}\panelFechasSalidaPeriodos_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosPeriodos))

            'Panel MyL
            IO.File.WriteAllText(String.Format("{0}\panelFechasSalidaMyL_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviarMyL))

            'Panel Urbano
            IO.File.WriteAllText(String.Format("{0}\panelFechasSalidaUrbano_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviarUrbano))

         End If
         If enviarWebPanelDeFechasSalida Then

            servicioRestEncab.Post(datosEnviarEncab, ArmarURL(Eniac.Reglas.Publicos.CalidadURLHeaderFS.ToString()), headers:=Nothing, binario:=False)

            servicioRest.Post(datosEnviar, ArmarURL(Eniac.Reglas.Publicos.CalidadURLItemsFS.ToString()), headers:=Nothing, binario:=False)

            servicioRest.Post(datosEnviarMyL, ArmarURL(Eniac.Reglas.Publicos.CalidadURLItemsFSMyL.ToString()), headers:=Nothing, binario:=False)
            servicioRest.Post(datosEnviarUrbano, ArmarURL(Eniac.Reglas.Publicos.CalidadURLItemsFSURB.ToString()), headers:=Nothing, binario:=False)

            servicioRest.Post(String.Empty, ArmarURL(Eniac.Reglas.Publicos.CalidadURLSincroFS.ToString()), headers:=Nothing, binario:=False)
            servicioRestPeriodo.Post(datosPeriodos, ArmarURL(Eniac.Reglas.Publicos.CalidadURLPeriodosFS.ToString()), headers:=Nothing, binario:=False)
            servicioRest.Post(String.Empty, ArmarURL(Eniac.Reglas.Publicos.CalidadURLPeriodosFSRT.ToString()), headers:=Nothing, binario:=False)

         End If

         RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, Nothing, Nothing, "Finalizó"))

      Catch ex As Exception
         Throw
      End Try

   End Sub


   Private Sub TraerRegistrosAuditoriaLogin()

      Dim servicioRestEncab = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporteEncab)()
      Dim servicioRest = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporte)()
      Dim servicioRestPeriodo = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransportePeriodos)()

      RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, Nothing, Nothing, "Leyendo Panel de Fechas de Salida desde SIGA"))

      Dim regla = New Reglas.ListasControlProductos()

      Dim pivotResult = regla.GetLeadTimeListasControlTipo(String.Empty, Nothing, Nothing,
                                                                Nothing, Nothing,
                                                                0, 0, String.Empty,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS, 0)

      Dim pivotResultMyL = regla.GetLeadTimeListasControlTipo(String.Empty, Nothing, Nothing,
                                                                Nothing, Nothing,
                                                                0, 0, String.Empty,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS, 2)

      Dim pivotResultUrbano = regla.GetLeadTimeListasControlTipo(String.Empty, Nothing, Nothing,
                                                                Nothing, Nothing,
                                                                0, 0, String.Empty,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS,
                                                                Entidades.Publicos.SiNoTodos.TODOS, 1)

      Dim Datos As DataTable = pivotResult.dtResult
      Dim DatosMyL As DataTable = pivotResultMyL.dtResult
      Dim DatosUrbano As DataTable = pivotResultUrbano.dtResult

      Me.MoverFechasSalida(pivotResult)
      Me.MoverFechasSalida(pivotResultMyL)
      Me.MoverFechasSalida(pivotResultUrbano)


      Dim CantPeriodos As Integer = 1

      Dim FechaDesde As Date
      Dim FechaAct As Date
      ' FechaDesde = New Date(Date.Today.Year, Date.Today.Month, 1)
      FechaAct = New Date(Date.Today.Year, Date.Today.Month, 1)
      FechaDesde = New Date(Date.Today.Year - 1, 12, 1)
      Dim FechaHasta As Date
      FechaHasta = FechaAct.AddMonths(1).AddSeconds(-1)


      Me.FiltroFechaSalida(pivotResult, FechaDesde, FechaHasta)
      Me.FiltroFechaSalida(pivotResultMyL, FechaDesde, FechaHasta)
      Me.FiltroFechaSalida(pivotResultUrbano, FechaDesde, FechaHasta)

      Me.ResumenFechaSalida(pivotResult, FechaDesde, FechaHasta)
      Me.ResumenFechaSalidaMyL(pivotResultMyL, FechaDesde, FechaHasta)
      Me.ResumenFechaSalidaUrbano(pivotResultUrbano, FechaDesde, FechaHasta)

      Dim registroActual = 0I
      Dim registrosTotal = pivotResult.dtResult.Rows.Count

      'Armado de json
      Try
         'Json Completo
         Dim Panel = _Resumen.Select().ToList().ConvertAll(
            Function(dr)
               Dim json = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSon With
                              {.FechaSalida = dr.Field(Of Date)("FechaSalida").ToStringFormatoPropio()
                              }
               For Each drCol As DataColumn In dr.Table.Columns
                  If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then
                     json.Secciones.Add(New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaSeccionesJSon() With
                                            {
                                                .IdColumna = drCol.ColumnName,
                                                .Cantidad = dr.Field(Of Integer)(drCol.ColumnName)
                                            })
                  End If
               Next

               Return json

            End Function) ''.Paginar(100)

         'Json MyL
         Dim PanelMyL = _ResumenMyL.Select().ToList().ConvertAll(
            Function(dr)
               Dim json = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSon With
                              {.FechaSalida = dr.Field(Of Date)("FechaSalida").ToStringFormatoPropio()
                              }
               For Each drCol As DataColumn In dr.Table.Columns
                  If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then
                     json.Secciones.Add(New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaSeccionesJSon() With
                                            {
                                                .IdColumna = drCol.ColumnName,
                                                .Cantidad = dr.Field(Of Integer)(drCol.ColumnName)
                                            })
                  End If
               Next

               Return json

            End Function) ''.Paginar(100)

         'Json Urbano
         Dim PanelUrbano = _ResumenUrbano.Select().ToList().ConvertAll(
            Function(dr)
               Dim json = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSon With
                              {.FechaSalida = dr.Field(Of Date)("FechaSalida").ToStringFormatoPropio()
                              }
               For Each drCol As DataColumn In dr.Table.Columns
                  If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then
                     json.Secciones.Add(New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaSeccionesJSon() With
                                            {
                                                .IdColumna = drCol.ColumnName,
                                                .Cantidad = dr.Field(Of Integer)(drCol.ColumnName)
                                            })
                  End If
               Next

               Return json

            End Function) ''.Paginar(100)


         '  Dim drTotales = Totales.Rows(0)
         Dim tot = New List(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaColumnasJSon)()
         Dim Tipo As Integer = 0

         For Each drCol As DataColumn In _Resumen.Columns

            If drCol.ColumnName.StartsWith("IdListaControlTipo__") Then

               Tipo = Integer.Parse(drCol.ColumnName.Replace("IdListaControlTipo__", "").ToString())

               tot.Add(New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaColumnasJSon With
                           {
                              .IdColumna = drCol.ColumnName,
                              .Etiqueta = New Reglas.ListasControlTipos().GetUno(Tipo).NombreListaControlTipo
                           })

            End If

         Next

         Dim Periodos = New List(Of Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaPeriodosJSon)()

         For Each fec As Date In _allMonths

            Periodos.Add(New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaPeriodosJSon With
                           {
                              .Periodo = fec.ToString("yyyyMM"),
                              .EtiquetaPeriodo = fec.GetMesEnEspanol().ToString() + " " + fec.ToString("yyyy")
                           })

         Next

         Dim fecha As DateTime = Today
         Dim mes As String = fecha.GetMonthEnEspanol()

         'Panel Completo
         Dim datosEnviarEncab = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporteEncab With {.Columnas = tot}
         Dim datosEnviar = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporte With {.Datos = Panel}
         Dim datosPeriodos = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransportePeriodos With {.Periodos = Periodos}

         'Panel MyL
         Dim datosEnviarMyL = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporte With {.Datos = PanelMyL}

         'Panel Urbano
         Dim datosEnviarUrbano = New Entidades.JSonEntidades.Archivos.PanelDeFechasSalidaJSonTransporte With {.Datos = PanelUrbano}

         registroActual = 0
         registrosTotal = Panel.Count

         RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, registroActual, registrosTotal, "Enviando Panel de Fechas de Salida"))
         '   If exportarPanelDeFechasSalida And Not String.IsNullOrWhiteSpace(Publicos.WebArchivos.CarpetaExportacion) Then
         'Panel Completo
         IO.File.WriteAllText(String.Format("{0}\panelFechasSalidaEncab_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviarEncab))
            IO.File.WriteAllText(String.Format("{0}\panelFechasSalida_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviar))
            IO.File.WriteAllText(String.Format("{0}\panelFechasSalidaPeriodos_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosPeriodos))

            'Panel MyL
            IO.File.WriteAllText(String.Format("{0}\panelFechasSalidaMyL_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviarMyL))

            'Panel Urbano
            IO.File.WriteAllText(String.Format("{0}\panelFechasSalidaUrbano_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(datosEnviarUrbano))

         '    End If
         '    If EnviarWebPanelDeFechasSalida() Then

         servicioRestEncab.Post(datosEnviarEncab, ArmarURL(Eniac.Reglas.Publicos.CalidadURLHeaderFS.ToString()), headers:=Nothing, binario:=False)

            servicioRest.Post(datosEnviar, ArmarURL(Eniac.Reglas.Publicos.CalidadURLItemsFS.ToString()), headers:=Nothing, binario:=False)

            servicioRest.Post(datosEnviarMyL, ArmarURL(Eniac.Reglas.Publicos.CalidadURLItemsFSMyL.ToString()), headers:=Nothing, binario:=False)
            servicioRest.Post(datosEnviarUrbano, ArmarURL(Eniac.Reglas.Publicos.CalidadURLItemsFSURB.ToString()), headers:=Nothing, binario:=False)

            servicioRest.Post(String.Empty, ArmarURL(Eniac.Reglas.Publicos.CalidadURLSincroFS.ToString()), headers:=Nothing, binario:=False)
            servicioRestPeriodo.Post(datosPeriodos, ArmarURL(Eniac.Reglas.Publicos.CalidadURLPeriodosFS.ToString()), headers:=Nothing, binario:=False)
            servicioRest.Post(String.Empty, ArmarURL(Eniac.Reglas.Publicos.CalidadURLPeriodosFSRT.ToString()), headers:=Nothing, binario:=False)

         '        End If

         RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendProv, Nothing, Nothing, "Finalizó"))

      Catch ex As Exception
         Throw
      End Try

   End Sub
   Private Sub MoverFechasSalida(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo)

      Dim SigColumna As Integer
      Dim FechaInicio As DateTime
      Dim Entro As Boolean = False
      Dim FechasSalida As DataTable = New DataTable()
      Dim dr2 As DataRow

      For Each dr As DataRow In pivotResult.dtResult.Rows

         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows

            Dim colName = drColumnas("NombreColumma").ToString()

            If Not String.IsNullOrEmpty(dr(drColumnas("NombreColumma").ToString()).ToString()) Then

               If Not Entro Then
                  FechaInicio = Date.Parse(dr(drColumnas("NombreColumma").ToString()).ToString())
                  Entro = True
               End If

               'SigColumna = dr(drColumnas("NombreColumma").ToString()) + 1

               SigColumna = pivotResult.dtResult.Columns(drColumnas("NombreColumma").ToString()).Ordinal + 1

               If colName = "IdListaControlTipo__11" Then
                  If Not String.IsNullOrEmpty(dr("CalidadFechaLiberado").ToString()) Then
                     dr(drColumnas("NombreColumma").ToString()) = dr("CalidadFechaLiberado")
                  Else
                     dr(drColumnas("NombreColumma").ToString()) = DBNull.Value
                  End If
                  Continue For
               End If

               If colName = "IdListaControlTipo__8" Then
                  If Not String.IsNullOrEmpty(dr("CalidadFechaLiberadoPDI").ToString()) Then
                     dr(drColumnas("NombreColumma").ToString()) = dr("CalidadFechaLiberadoPDI")
                  Else
                     dr(drColumnas("NombreColumma").ToString()) = DBNull.Value
                  End If
                  Continue For
               End If

               If IsDate(dr(SigColumna).ToString()) Then
                  dr(drColumnas("NombreColumma").ToString()) = dr(SigColumna)
               Else
                  If IsNumeric(dr(SigColumna).ToString()) Then
                     If Not String.IsNullOrEmpty(dr("CalidadFechaLiberadoPDI").ToString()) Then
                        dr(drColumnas("NombreColumma").ToString()) = dr("CalidadFechaLiberadoPDI")
                     Else
                        dr(drColumnas("NombreColumma").ToString()) = DBNull.Value
                     End If
                     Exit For
                  Else
                     Dim SigSigColumna As Integer = SigColumna + 1
                     If Not IsNumeric(dr(SigSigColumna).ToString()) Then
                        dr(drColumnas("NombreColumma").ToString()) = dr(SigSigColumna)
                     Else
                        dr(drColumnas("NombreColumma").ToString()) = DBNull.Value
                     End If
                     Continue For
                  End If
               End If
            End If
         Next
         Entro = False
      Next
   End Sub

   Private Sub FiltroFechaSalida(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                                  FechaSalidaDesde As Date?, FechaSalidahasta As Date?)


      Dim Datos As DataTable = pivotResult.dtResult


      'Dim query As EnumerableRowCollection(Of DataRow) = From order In Datos.AsEnumerable() Where order.Field(Of DateTime)("Mecanica") > FechaSalidaDesde _
      '                                                                                      And order.Field(Of DateTime)("Mecanica") < FechaSalidahasta Select order

      'Dim view As DataView = query.AsDataView()

      'ugDetalle.DataSource = view

      'view.RowFilter = Nothing



      Dim entroFecha As Boolean = False
      Dim cont As Integer = 0
      '' _TablaFechas = Datos.Copy()

      For Each dr As DataRow In pivotResult.dtResult.Rows
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            If Not String.IsNullOrEmpty(dr(drColumnas("NombreColumma").ToString()).ToString()) Then
               If IsDate(dr(drColumnas("NombreColumma").ToString()).ToString()) Then
                  If FechaSalidaDesde < Date.Parse(dr(drColumnas("NombreColumma").ToString()).ToString()) And
                     FechaSalidahasta > Date.Parse(dr(drColumnas("NombreColumma").ToString()).ToString()) Then
                     entroFecha = True
                  Else
                     dr(drColumnas("NombreColumma").ToString()) = DBNull.Value
                  End If

               End If
            End If
         Next
         If Not entroFecha Then
            dr.Delete()
         End If
         entroFecha = False
      Next

      ' ugDetalle.DataSource = Datos

   End Sub

   Private Sub ResumenFechaSalida(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                                    FechaSalidaDesde As Date?, FechaSalidahasta As Date?)

      pivotResult.dtResult.AcceptChanges()

      '  Dim Datos As DataTable = pivotResult.dtResult

      Dim dr1 As DataRow
      _Resumen.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         Dim colName = drColumnas("NombreColumma").ToString()
         _Resumen.Columns.Add(colName, System.Type.GetType("System.Int32"))
      Next

      Dim starting As DateTime = New DateTime()
      starting = Date.Parse(FechaSalidaDesde.ToString())
      Dim ending As DateTime = New DateTime()
      ending = Date.Parse(FechaSalidahasta.ToString())

      Dim dates As DateTime() = GetDatesBetween(starting, ending).ToArray()

      Dim Months As DateTime() = GetMonthsBetween(starting, ending).ToArray()

      For Each fec As Date In dates
         dr1 = _Resumen.NewRow()
         dr1("FechaSalida") = fec.ToString("dd/MM/yyyy")
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            dr1(drColumnas("NombreColumma").ToString()) = 0
         Next
         _Resumen.Rows.Add(dr1)
      Next

      For Each dr As DataRow In _Resumen.Rows

         For Each dr2 As DataRow In pivotResult.dtResult.Rows

            For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
               If Not String.IsNullOrEmpty(dr2(drColumnas("NombreColumma").ToString()).ToString()) Then
                  If Date.Parse(dr("FechaSalida").ToString()).ToString("dd/MM/yyyy") = Date.Parse(dr2(drColumnas("NombreColumma").ToString()).ToString()).ToString("dd/MM/yyyy") Then
                     dr(drColumnas("NombreColumma").ToString()) = Integer.Parse(dr(drColumnas("NombreColumma").ToString()).ToString()) + 1
                  End If
               End If
            Next
         Next

      Next

   End Sub

   Private Sub ResumenFechaSalidaMyL(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                                    FechaSalidaDesde As Date?, FechaSalidahasta As Date?)

      pivotResult.dtResult.AcceptChanges()

      '  Dim Datos As DataTable = pivotResult.dtResult

      Dim dr1 As DataRow
      _ResumenMyL.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         Dim colName = drColumnas("NombreColumma").ToString()
         _ResumenMyL.Columns.Add(colName, System.Type.GetType("System.Int32"))
      Next

      Dim starting As DateTime = New DateTime()
      starting = Date.Parse(FechaSalidaDesde.ToString())
      Dim ending As DateTime = New DateTime()
      ending = Date.Parse(FechaSalidahasta.ToString())

      Dim dates As DateTime() = GetDatesBetween(starting, ending).ToArray()

      Dim Months As DateTime() = GetMonthsBetween(starting, ending).ToArray()

      For Each fec As Date In dates
         dr1 = _ResumenMyL.NewRow()
         dr1("FechaSalida") = fec.ToString("dd/MM/yyyy")
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            dr1(drColumnas("NombreColumma").ToString()) = 0
         Next
         _ResumenMyL.Rows.Add(dr1)
      Next

      For Each dr As DataRow In _ResumenMyL.Rows

         For Each dr2 As DataRow In pivotResult.dtResult.Rows

            For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
               If Not String.IsNullOrEmpty(dr2(drColumnas("NombreColumma").ToString()).ToString()) Then
                  If Date.Parse(dr("FechaSalida").ToString()).ToString("dd/MM/yyyy") = Date.Parse(dr2(drColumnas("NombreColumma").ToString()).ToString()).ToString("dd/MM/yyyy") Then
                     dr(drColumnas("NombreColumma").ToString()) = Integer.Parse(dr(drColumnas("NombreColumma").ToString()).ToString()) + 1
                  End If
               End If
            Next
         Next

      Next

   End Sub

   Private Sub ResumenFechaSalidaUrbano(pivotResult As Reglas.ListasControlProductos.GetProductosPorListasControlPivotInfo,
                                    FechaSalidaDesde As Date?, FechaSalidahasta As Date?)

      pivotResult.dtResult.AcceptChanges()

      '  Dim Datos As DataTable = pivotResult.dtResult

      Dim dr1 As DataRow
      _ResumenUrbano.Columns.Add("FechaSalida", System.Type.GetType("System.DateTime"))
      For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
         Dim colName = drColumnas("NombreColumma").ToString()
         _ResumenUrbano.Columns.Add(colName, System.Type.GetType("System.Int32"))
      Next

      Dim starting As DateTime = New DateTime()
      starting = Date.Parse(FechaSalidaDesde.ToString())
      Dim ending As DateTime = New DateTime()
      ending = Date.Parse(FechaSalidahasta.ToString())

      Dim dates As DateTime() = GetDatesBetween(starting, ending).ToArray()

      Dim Months As DateTime() = GetMonthsBetween(starting, ending).ToArray()

      For Each fec As Date In dates
         dr1 = _ResumenUrbano.NewRow()
         dr1("FechaSalida") = fec.ToString("dd/MM/yyyy")
         For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
            dr1(drColumnas("NombreColumma").ToString()) = 0
         Next
         _ResumenUrbano.Rows.Add(dr1)
      Next

      For Each dr As DataRow In _ResumenUrbano.Rows

         For Each dr2 As DataRow In pivotResult.dtResult.Rows

            For Each drColumnas As DataRow In pivotResult.dtColumnas.Rows
               If Not String.IsNullOrEmpty(dr2(drColumnas("NombreColumma").ToString()).ToString()) Then
                  If Date.Parse(dr("FechaSalida").ToString()).ToString("dd/MM/yyyy") = Date.Parse(dr2(drColumnas("NombreColumma").ToString()).ToString()).ToString("dd/MM/yyyy") Then
                     dr(drColumnas("NombreColumma").ToString()) = Integer.Parse(dr(drColumnas("NombreColumma").ToString()).ToString()) + 1
                  End If
               End If
            Next
         Next

      Next

   End Sub
   Private Function GetDatesBetween(FechaDesde As Date, fechaHasta As Date) As Date()

      Dim allDates As List(Of DateTime) = New List(Of DateTime)()
      Dim fecha As DateTime = FechaDesde
      While fecha <= fechaHasta
         allDates.Add(fecha)
         fecha = fecha.AddDays(1)
      End While

      Return allDates.ToArray()

   End Function
   Private Function GetMonthsBetween(FechaDesde As Date, fechaHasta As Date) As Date()
      _allMonths = New List(Of DateTime)()
      Dim fecha1 As DateTime = FechaDesde
      While fecha1 <= fechaHasta
         _allMonths.Add(fecha1)
         fecha1 = fecha1.AddMonths(1)
      End While

      Return _allMonths.ToArray()
   End Function

   Private Sub EnviarWebOrdenCompra(reenviar As Boolean, enviarWebOrdenCompra As Boolean, exportarOrdenCompra As Boolean)
      Dim servicioRest = New ServiciosRest.Archivos.BaseArchivosWeb(Of Entidades.JSonEntidades.Archivos.OrdenCompraJSon)()
      Dim fechaMax As DateTime? = Nothing
      If Not reenviar Then
         RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendOC, Nothing, Nothing, "Obteniendo fecha máxima"))
         fechaMax = servicioRest.GetMaxFecha(ArmarURL("{0}/sigaordencomprajsonmax/CuitEmpresa/{1}/"), headers:=Nothing)
      End If

      RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendOC, Nothing, Nothing, "Leyendo Cabecera de O.C. desde SIGA"))
      Dim dtCabecera = New SqlServer.SincronizarOrdenesCompra(da).GetCabeceraSIGA(fechaMax, fechaHasta:=Nothing)
      RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendOC, Nothing, Nothing, "Leyendo Dabecera de O.C. desde SIGA"))
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
                       RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendOC, registroActual, registrosTotal, String.Format("{0} {1} {2:0000}-{3:00000000}", idTipoComprobante, letra, centroEmisor, numeroPedido)))
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
         RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendOC, registroActual, registrosTotal, "Enviando páginas orden compra (tamaño 100)"))
         If exportarOrdenCompra And Not String.IsNullOrWhiteSpace(Publicos.WebArchivos.CarpetaExportacion) Then
            IO.File.WriteAllText(String.Format("{0}\ordencompra_{1:0000}.json", Publicos.WebArchivos.CarpetaExportacion, registroActual), _serializer.Serialize(p))
         End If
         If enviarWebOrdenCompra Then
            servicioRest.Post(p, ArmarURL("{0}/sigaordencomprajson/"), headers:=Nothing, binario:=False)
         End If
      Next

      RaiseEvent Avance(Me, New AvanceSincronizarPanelDeControlEventArgs(TagSendOC, Nothing, Nothing, "Finalizó"))

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

Public Class PanelDeControlRespuestas

   Public Property Id As Long
   Public Property sincronizado As String
   Public Property nombre_usuario As String
   Public Property ip As String
   Public Property id_usuario As Integer
   Public Property pais_code As String
   Public Property pais As String
   Public Property login As DateTime
   Public Property logout As DateTime?
   Public Property navegador As String
   Public Property estado_registro As String


End Class

Public Class AvanceSincronizarPanelDeControlEventArgs
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