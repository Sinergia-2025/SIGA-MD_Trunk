Imports Eniac.Reglas.ServiciosRest.Sincronizacion
Imports Microsoft.VisualBasic.Devices

Public Class Productos
   Inherits BaseSync(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte, Entidades.JSonEntidades.Archivos.ProductoJSon)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte, Entidades.JSonEntidades.Archivos.ProductoJSon)

#Region "Enumeradores"

   Private Enum ListaPreciosColumns
      IdListaPrecios
      NombreListaPrecios
      PrecioVenta
      PrecioVentaBase
      PorcentajeBase
      PrecioCosto
      PorcentajeCosto
      PorcActual
      SobreVenta
      SobreCosto
      DesdeFormula
      PorcentajeCalculado
   End Enum

#End Region

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("Productos", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   <Obsolete("Utilizar Insertar(Entidades.Entidad, String)", True)>
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Throw New NotImplementedException("Utilizar Insertar(Entidades.Entidad, String)")
   End Sub
   Public Overloads Sub Insertar(entidad As Eniac.Entidades.Entidad, idFuncion As String)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.Producto), idFuncion))
   End Sub

   'Public Sub InsertarCalidad(entidad As Eniac.Entidades.Entidad, idCliente As Long, idFuncion As String)
   '   EjecutaConTransaccion(Sub() InsertaCalidad(DirectCast(entidad, Entidades.Producto), idCliente, idFuncion))
   'End Sub
   Public Sub Inserta(produ As Entidades.Producto, idFuncion As String)

      'Inserto el Registro en la tabla Maestra
      EjecutaSP(produ, TipoSP._I, _actualizaImagen:=True)

      'Inserto los Registros para la tabla de productos por sucursal
      Using dt = New SucursalesUbicaciones(da).GetUbicacionPredeterminadaParaSucursal(idSucursal:=0)
         Dim rProdSuc = New ProductosSucursales(da)
         Dim lstPS = New List(Of Entidades.ProductoSucursal)
         Dim prod = New Entidades.Producto() With {.IdProducto = produ.IdProducto}

         'En dt tengo las sucursales con sus primeras ubicaciones.
         'Si una ubicación está asociada a otra la segunda ubicación la trae como columna aparte indicandola como asociada y no la trae como registro.
         'Si hay dos sucursales y estan asociadas entre ellas, traerá un solo registro de la sucursal con Id menor (1) y como asociada la otra sucursal/deposito/ubicación
         'Si hay dos sucursales y NO estan asociadas entre ellas, traerá dos registro (uno por cada sucursal) y como asociada NULL
         For Each dr In dt.AsEnumerable()
            'Para crear todas las sucursales debo recorrer dos juegos de columnas, la principal y la asociada.
            For i = 0 To 1
               'Para ello hago un for de 0 a 1 y armo estos arrays que según si es 0 (principal) o 1 (secundaria) toma el nombre de columna a evaluar luego
               Dim idSucursalColumnName = {"IdSucursal", "IdSucursalAsociada"}(i)
               Dim idDepositoColumnName = {"IdDeposito", "IdDepositoAsociado"}(i)
               Dim idubicacionColumnName = {"IdUbicacion", "IdUbicacionAsociada"}(i)

               'Si la columna de IdSucursal o IdSucursalAsociada está NULL sigo la siguiente fila.
               'Esto no debería darse nunca con IdSucursal. Solo con IdSucursalAsociada cuando no haya Ubicación Asociada
               Dim idSuc = dr.Field(Of Integer?)(idSucursalColumnName)
               If Not idSuc.HasValue Then
                  Continue For
               End If

               'Creo el registro para ProductosSucursales. Se va a crear para todas las sucursales porque por cada principal entra dos veces tomando las secundarias con el nombre de columna cambiado
               Dim ps = New Entidades.ProductoSucursal With {
                  .Producto = prod,
                  .IdSucursal = idSuc.Value,
                  .Usuario = produ.Usuario,
                  .Ubicacion = produ.Ubicacion,
                  .StockMinimo = produ.StockMinimo,
                  .PuntoDePedido = produ.PuntoDePedido,
                  .StockMaximo = produ.StockMaximo,
                  .IdDepositoDefecto = dr.Field(Of Integer)(idDepositoColumnName),
                  .IdUbicacionDefecto = dr.Field(Of Integer)(idubicacionColumnName)
               }
               ps.Sucursal.Id = idSuc.Value

               lstPS.Add(ps)

            Next
         Next

         'Si de pantalla me viene IdDeposito y IdSucursal tomo esos datos y se los pongo a la sucursal actual
         'TODO: Si la sucursal está vinculada, hay que poner para la vinculada el deposito/ubicación vinculados
         If produ.IdDeposito <> 0 AndAlso produ.IdUbicacion <> 0 Then
            Dim cambiaDefecto =
               Sub(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer)
                  Dim psActual = lstPS.First(Function(ps) ps.IdSucursal = idSucursal)
                  If psActual IsNot Nothing Then
                     psActual.IdDepositoDefecto = idDeposito
                     psActual.IdUbicacionDefecto = idUbicacion
                  End If
               End Sub

            cambiaDefecto(actual.Sucursal.Id, produ.IdDeposito, produ.IdUbicacion)

            'Busco la ubicación que se define como Defecto.
            Dim ubic = New SucursalesUbicaciones(da).GetUno(produ.IdDeposito, actual.Sucursal.Id, produ.IdUbicacion)
            'Si esta tiene Deposito/Ubicación asociada, debo ajustar el dato en la Sucursal Asociada.
            If ubic.SucursalAsociada <> 0 AndAlso ubic.DepositoAsociado <> 0 AndAlso ubic.UbicacionAsociada <> 0 Then
               cambiaDefecto(ubic.SucursalAsociada, ubic.DepositoAsociado, ubic.UbicacionAsociada)
            End If
         End If

         '-- Inserta Producto Sucursales.-
         For Each ps In lstPS
            rProdSuc.EjecutaSP(ps, TipoSP._I, idFuncion)
         Next
      End Using
      GrabaPrecios(produ, idFuncion)

   End Sub

   'Public Function InsertaCalidad(idProducto As String, nombreProducto As String, observacionCompras As String, UM As String, cache As BusquedasCacheadas, idFuncion As String) As Entidades.Producto
   '   Dim produ = New Entidades.Producto()

   '   produ.IdProducto = idProducto
   '   produ.NombreProducto = nombreProducto

   '   If String.IsNullOrWhiteSpace(produ.Usuario) Then
   '      produ.Usuario = actual.Nombre
   '   End If

   '   If produ.IdProductoTipoServicio = 0 Then
   '      produ.IdProductoTipoServicio = 4
   '   End If

   '   produ.IdMarca = cache.GetPrimeraMarca().IdMarca  ' New Reglas.Marcas().GetPrimeraMarca()
   '   produ.IdRubro = cache.GetPrimerRubro().IdRubro ' New Reglas.Rubros().GetPrimerRubro()
   '   produ.Moneda = cache.BuscaMoneda(Entidades.Moneda.Peso) ' New Reglas.Monedas().GetUna(1)
   '   produ.Alicuota = Publicos.ProductoIVA  '21.0
   '   produ.IdSucursal = actual.Sucursal.Id
   '   produ.Tamano = 1
   '   If Not String.IsNullOrEmpty(UM) Then
   '      produ.UnidadDeMedida.IdUnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUno(UM).IdUnidadDeMedida
   '   Else
   '      produ.UnidadDeMedida.IdUnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
   '   End If
   '   produ.MesesGarantia = 0
   '   produ.AfectaStock = True
   '   produ.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString() ' "IVA"
   '   produ.EsServicio = False
   '   produ.PublicarEnWeb = False
   '   produ.EsDeVentas = True
   '   produ.EsDeCompras = True
   '   produ.EsCompuesto = False
   '   produ.DescontarStockComponentes = False
   '   produ.CodigoDeBarrasConPrecio = False
   '   produ.PermiteModificarDescripcion = False
   '   produ.PagaIngresosBrutos = True
   '   produ.Embalaje = 1
   '   produ.Kilos = 0
   '   produ.PublicarListaDePreciosClientes = True
   '   produ.FacturacionCantidadNegativa = False
   '   produ.SolicitaEnvase = False
   '   produ.AlertaDeCaja = False
   '   produ.EsRetornable = False
   '   produ.Observacion = ""
   '   produ.IdModelo = 0
   '   produ.EsOferta = "NO"
   '   produ.IncluirExpensas = False
   '   produ.nombreCorto = ""
   '   produ.Activo = True
   '   produ.PrecioPorEmbalaje = False
   '   produ.UnidHasta1 = 0
   '   produ.UnidHasta2 = 0
   '   produ.UnidHasta3 = 0
   '   produ.UnidHasta4 = 0
   '   produ.UnidHasta5 = 0
   '   produ.UHPorc1 = 0
   '   produ.UHPorc2 = 0
   '   produ.UHPorc3 = 0
   '   produ.UHPorc4 = 0
   '   produ.UHPorc5 = 0
   '   produ.ObservacionCompras = observacionCompras
   '   produ.SolicitaPrecioVentaPorTamano = False
   '   produ.Orden = 1

   '   InsertaCalidad(produ, 0L, idFuncion)

   '   Return produ
   'End Function

   'Public Sub InsertaCalidad(produ As Eniac.Entidades.Producto, idCliente As Long, idFuncion As String)

   '   Dim oProductoSucursal As Entidades.ProductoSucursal = New Entidades.ProductoSucursal
   '   Dim oProdSuc As Reglas.ProductosSucursales

   '   'Inserto los Registros para la tabla de productos por sucursal
   '   Dim dt As DataTable = New Reglas.Sucursales().GetAll()

   '   oProdSuc = New Reglas.ProductosSucursales(da)

   '   'Inserto el Registro en la tabla Maestra
   '   Me.EjecutaSP(produ, TipoSP._I, _actualizaImagen:=True)

   '   oProductoSucursal.Producto.IdProducto = produ.IdProducto

   '   For Each dr As DataRow In dt.Rows
   '      oProductoSucursal.Sucursal.Id = Integer.Parse(dr("IdSucursal").ToString())
   '      oProductoSucursal.Usuario = produ.Usuario
   '      oProductoSucursal.Ubicacion = produ.Ubicacion

   '      oProductoSucursal.StockMinimo = produ.StockMinimo
   '      oProductoSucursal.StockMinimo = produ.PuntoDePedido
   '      oProductoSucursal.StockMinimo = produ.StockMaximo

   '      oProdSuc.EjecutaSP(oProductoSucursal, TipoSP._I, idFuncion)
   '   Next

   '   Dim reglaPC As Reglas.ProductosClientes = New Reglas.ProductosClientes(da)
   '   Dim PC As Entidades.ProductosClientes = New Entidades.ProductosClientes()
   '   If idCliente <> 0 Then
   '      With PC
   '         .IdCliente = idCliente
   '         .IdProducto = produ.IdProducto.Trim()
   '      End With
   '      reglaPC.BorraClienteProductoCalidad(produ.IdProducto)
   '      reglaPC._Insertar(PC)
   '   End If

   '   'Inserta o actualiza Numeradores segun Tipo Servicio
   '   Dim oNumeradores As Reglas.Numeradores = New Reglas.Numeradores(da)
   '   Dim Numerador As Entidades.Numerador
   '   Dim IdNumerador As String = String.Empty
   '   Dim TipoServicio As Entidades.ProductoTipoServicio = New Reglas.ProductosTiposServicios().GetUno(produ.IdProductoTipoServicio)
   '   If produ.IdProductoTipoServicio > 1 And produ.IdProductoTipoServicio < 3 Then
   '      Numerador = oNumeradores.GetUno(String.Format("{0}-{1}", TipoServicio.Prefijo, produ.CalidadNroCarroceria.ToString()))
   '      If Numerador Is Nothing Then
   '         Numerador = New Entidades.Numerador
   '         With Numerador
   '            .IdNumerador = String.Format("{0}-{1}", TipoServicio.Prefijo, produ.CalidadNroCarroceria.ToString())
   '            .Numero = 1
   '            .Descripcion = "ABM Productos Calidad"
   '         End With
   '         oNumeradores._Insertar(Numerador)
   '      Else
   '         Numerador.Numero = Numerador.Numero + 1
   '         oNumeradores._Actualizar(Numerador)
   '      End If
   '   ElseIf produ.IdProductoTipoServicio = 3 Then
   '      Numerador = oNumeradores.GetUno(String.Format("{0}", TipoServicio.Prefijo))
   '      If Numerador Is Nothing Then
   '         Numerador = New Entidades.Numerador
   '         With Numerador
   '            .IdNumerador = String.Format("{0}", TipoServicio.Prefijo)
   '            .Numero = 1
   '            .Descripcion = "ABM Chasis Calidad"
   '         End With
   '         oNumeradores._Insertar(Numerador)
   '      Else
   '         Numerador.Numero = Numerador.Numero + 1
   '         oNumeradores._Actualizar(Numerador)
   '      End If
   '   End If
   'End Sub

   Private Sub GrabaPrecios(produ As Entidades.Producto, idFuncion As String)
      GrabaPrecios(produ, idFuncion, fuerzaActualizacionPrecio:=False)
   End Sub

   Private Sub GrabaPrecios(produ As Entidades.Producto, idFuncion As String, fuerzaActualizacionPrecio As Boolean)
      Dim precioFabrica As Decimal = 0
      Dim precioCosto As Decimal = 0

      If produ.ProductoProveedorHabitual IsNot Nothing Then
         precioFabrica = produ.ProductoProveedorHabitual.UltimoPrecioFabrica
      End If

      precioCosto = produ.PrecioCosto

      If produ.Precios IsNot Nothing Then
         Dim reglaPS As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)
         Dim precios As List(Of Entidades.ProductoSucursal) = New List(Of Entidades.ProductoSucursal)()
         Dim prc As Entidades.ProductoSucursal = New Entidades.ProductoSucursal()

         prc.Producto = produ
         prc.Sucursal.IdSucursal = actual.Sucursal.IdSucursal
         prc.Sucursal.Id = actual.Sucursal.IdSucursal
         prc.IdSucursal = actual.Sucursal.IdSucursal
         prc.Precios = New List(Of Entidades.ProductoSucursalPrecio)()
         prc.Usuario = actual.Nombre
         prc.FechaActualizacion = Now
         prc.FuerzaActualizacionPrecio = fuerzaActualizacionPrecio
         prc.PrecioFabrica = precioFabrica
         prc.PrecioCosto = precioCosto
         precios.Add(prc)

         For Each dr As DataRow In produ.Precios.Rows
            'If CInt(dr("IdListaPrecios")) = 0 Then
            '   prc.PrecioVenta = CDec(dr("PrecioVenta"))
            'End If

            Dim lprc As Entidades.ProductoSucursalPrecio = New Entidades.ProductoSucursalPrecio()
            lprc.ProductoSucursal = prc
            lprc.ListaDePrecios = New Entidades.ListaDePrecios()
            lprc.ListaDePrecios.IdListaPrecios = CInt(dr("IdListaPrecios"))
            lprc.ListaDePrecios.NombreListaPrecios = dr("NombreListaPrecios").ToString()
            lprc.PrecioVenta = CDec(dr("PrecioVenta"))
            lprc.Usuario = actual.Nombre
            lprc.IdSucursal = actual.Sucursal.IdSucursal
            lprc.FechaActualizacion = Now

            prc.Precios.Add(lprc)
         Next

         reglaPS._ModificarPrecios(precios, idFuncion)

      End If
   End Sub

   <Obsolete("Utilizar Actualizar(Entidades.Entidad, String)", True)>
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Throw New NotImplementedException("Utilizar Actualizar(Entidades.Entidad, String)")
   End Sub
   Public Overloads Sub Actualizar(entidad As Eniac.Entidades.Entidad, idFuncion As String)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.Producto), _actualizaImagen:=True, idFuncion:=idFuncion, fuerzaActualizacionPrecio:=False))
   End Sub

   'Public Sub ActualizarCalidad(entidad As Eniac.Entidades.Entidad, IdCliente As Long)
   '   EjecutaConTransaccion(Sub() ActualizaCalidad(DirectCast(entidad, Entidades.Producto), IdCliente))
   'End Sub

   'Public Sub EliminarCalidad(entidad As Eniac.Entidades.Entidad, IdCliente As Long)
   '   Dim produ As Entidades.Producto = DirectCast(entidad, Entidades.Producto)
   '   Try
   '      da.OpenConection()
   '      da.BeginTransaction()

   '      Me.EliminaCalidad(produ, IdCliente)

   '      da.CommitTransaction()

   '   Catch ex As Exception
   '      da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Sub
   Public Sub Actualiza(produ As Entidades.Producto, _actualizaImagen As Boolean, idFuncion As String, fuerzaActualizacionPrecio As Boolean)
      EjecutaSP(produ, TipoSP._U, _actualizaImagen)

      If produ.IdDeposito <> 0 AndAlso produ.IdUbicacion <> 0 Then
         Dim ubi = New SucursalesUbicaciones(da).GetUno(produ.IdDeposito, actual.Sucursal.Id, produ.IdUbicacion, AccionesSiNoExisteRegistro.Nulo)

         Dim rProdSuc = New ProductosSucursales(da)
         If ubi IsNot Nothing Then
            Dim prodSuc = rProdSuc._GetUno(actual.Sucursal.Id, produ.IdProducto)
            prodSuc.IdDepositoDefecto = ubi.IdDeposito
            prodSuc.IdUbicacionDefecto = ubi.IdUbicacion
            rProdSuc.EjecutaSP(prodSuc, TipoSP._U, idFuncion)
         End If

         If ubi.SucursalAsociada <> 0 AndAlso ubi.DepositoAsociado <> 0 AndAlso ubi.UbicacionAsociada <> 0 Then
            Dim prodSuc = rProdSuc._GetUno(ubi.SucursalAsociada, produ.IdProducto)
            prodSuc.IdDepositoDefecto = ubi.DepositoAsociado
            prodSuc.IdUbicacionDefecto = ubi.UbicacionAsociada
            rProdSuc.EjecutaSP(prodSuc, TipoSP._U, idFuncion)
         End If
      End If

      GrabaPrecios(produ, idFuncion, fuerzaActualizacionPrecio)
   End Sub

   Public Sub ActualizaCalidad(produ As Eniac.Entidades.Producto, IdCliente As Long)
      Me.EjecutaSP(produ, TipoSP._U, _actualizaImagen:=True)
      If IdCliente <> 0 Then
         Dim reglaPC As Reglas.ProductosClientes = New Reglas.ProductosClientes(da)
         Dim PC As Entidades.ProductosClientes = New Entidades.ProductosClientes()
         With PC
            .IdCliente = IdCliente
            .IdProducto = produ.IdProducto.Trim()
         End With
         reglaPC.BorraClienteProductoCalidad(produ.IdProducto)
         reglaPC._Insertar(PC)
      End If

   End Sub

   'Public Sub EliminaCalidad(produ As Eniac.Entidades.Producto, IdCliente As Long)
   '   If IdCliente <> 0 Then
   '      Dim reglaPC As Reglas.ProductosClientes = New Reglas.ProductosClientes(da)
   '      Dim PC As Entidades.ProductosClientes = New Entidades.ProductosClientes()
   '      With PC
   '         .IdCliente = IdCliente
   '         .IdProducto = produ.IdProducto.Trim()
   '      End With
   '      reglaPC.BorraClienteProductoCalidad(produ.IdProducto)

   '   End If
   '   'Inserta o actualiza Numeradores segun Tipo Servicio
   '   Dim oNumeradores As Reglas.Numeradores = New Reglas.Numeradores(da)
   '   Dim Numerador As Entidades.Numerador
   '   Dim IdNumerador As String = String.Empty
   '   Dim TipoServicio As Entidades.ProductoTipoServicio = New Reglas.ProductosTiposServicios().GetUno(produ.IdProductoTipoServicio)
   '   If produ.IdProductoTipoServicio > 1 Then

   '      Dim Cont As Integer = Integer.Parse(produ.IdProducto.Split("-"c)(1).ToString())

   '      Numerador = oNumeradores.GetUno(String.Format("{0}-{1}", TipoServicio.Prefijo, produ.CalidadNroCarroceria.ToString()))
   '      If Numerador IsNot Nothing And Cont = Numerador.Numero Then
   '         Numerador.Numero = Numerador.Numero - 1
   '         oNumeradores._Actualizar(Numerador)
   '      End If
   '   End If
   '   Me.EjecutaSP(produ, TipoSP._D, _actualizaImagen:=True)

   'End Sub

   'Public Sub ActualizaProductoCalidad(produ As Eniac.Entidades.Producto)
   '   Dim sql As SqlServer.Productos = New SqlServer.Productos(da)

   '   sql.Productos_UCalidad(produ)

   'End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Dim produ As Entidades.Producto = DirectCast(entidad, Entidades.Producto)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(produ, TipoSP._D, _actualizaImagen:=True)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Borra(produ As Eniac.Entidades.Producto)
      Me.EjecutaSP(produ, TipoSP._D, _actualizaImagen:=True)
   End Sub

   Public Sub AjustarStock(idSucursal As Integer,
                           idDeposito As Integer,
                           IdUbicacion As Integer,
                           idProducto As String,
                           tablaContabilidad As DataTable,
                           grabaAutomatico As Boolean,
                           esMultipleRubro As Boolean,
                           nuevoStock As Decimal,
                           metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                           idFuncion As String)
      Try
         da.OpenConection()
         da.BeginTransaction()

         _AjustarStock(idSucursal, idDeposito, IdUbicacion, IdUbicacion, idProducto, tablaContabilidad, grabaAutomatico, esMultipleRubro, 0, nuevoStock, metodoGrabacion, idFuncion,
                       idaAtributo01:=Nothing, idaAtributo02:=Nothing, idaAtributo03:=Nothing, idaAtributo04:=Nothing)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Sub _AjustarStock(idSucursal As Integer, idProducto As String, nuevoStock As Decimal,
                            metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)
      'MULTIDEPOSITO: Ajustar para multideposito / idDeposito:=0, idUbicOrg:=0, IdUbicDes:=0, viejoStock:=0
      _AjustarStock(idSucursal, idDeposito:=0, idUbicOrg:=0, IdUbicDes:=0, idProducto,
                    tablaContabilidad:=Nothing, grabaAutomatico:=True, esMultipleRubro:=False,
                    viejoStock:=0, nuevoStock,
                    metodoGrabacion, idFuncion,
                    idaAtributo01:=Nothing, idaAtributo02:=Nothing, idaAtributo03:=Nothing, idaAtributo04:=Nothing)
   End Sub
   Public Sub _AjustarStock(idSucursal As Integer,
                            idDeposito As Integer,
                            idUbicOrg As Integer,
                            IdUbicDes As Integer,
                            idProducto As String,
                            tablaContabilidad As DataTable,
                            grabaAutomatico As Boolean,
                            esMultipleRubro As Boolean,
                            viejoStock As Decimal,
                            nuevoStock As Decimal,
                            metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                            idFuncion As String,
                            idaAtributo01 As Integer?,
                            idaAtributo02 As Integer?,
                            idaAtributo03 As Integer?,
                            idaAtributo04 As Integer?)

      Dim TipoMovimiento As Entidades.TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno("AJUSTE")

      Dim rProdSuc As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)
      Dim prodSuc As Entidades.ProductoSucursal = rProdSuc._GetUno(idSucursal, idProducto)

      Dim lineaProductoCompra As New System.Collections.Generic.List(Of Entidades.MovimientoStockProducto)()
      Dim lineaDetalle As Entidades.MovimientoStockProducto = New Entidades.MovimientoStockProducto()

      With lineaDetalle
         .IdProducto = idProducto
         '---------------------------
         .IdDeposito = idDeposito
         .IdUbicacion = IdUbicDes
         '-- REQ-35260.- ------------
         .IdaAtributoProducto01 = idaAtributo01.IfNull
         .IdaAtributoProducto02 = idaAtributo02.IfNull
         .IdaAtributoProducto03 = idaAtributo03.IfNull
         .IdaAtributoProducto04 = idaAtributo04.IfNull
         '---------------------------
         .NombreProducto = prodSuc.Producto.NombreProducto
         .DescuentoRecargo = 0
         If TipoMovimiento.CargaPrecio = "PrecioCosto" Then
            .Precio = prodSuc.PrecioCosto
         ElseIf TipoMovimiento.CargaPrecio = "PrecioVenta" Then
            .Precio = rProdSuc.GetPrecioVentaPredeterminado(idSucursal, idProducto)
         Else
            .Precio = 0
         End If
         If idUbicOrg <> 0 AndAlso idUbicOrg <> IdUbicDes Then
            .Cantidad = nuevoStock
         Else
            .Cantidad = nuevoStock - viejoStock
         End If

         .ImporteTotal = Decimal.Round(.Precio * .Cantidad, 2)
         .PorcentajeIVA = 0
         .IVA = 0
         .TotalProducto = .ImporteTotal
         .Stock = prodSuc.Stock
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .IdLote = ""
         .VtoLote = Nothing
         .Orden = 1
      End With
      lineaProductoCompra.Add(lineaDetalle)

      '-- Carga linea de ContraMovimiento de Stock.-
      If idUbicOrg <> 0 AndAlso idUbicOrg <> IdUbicDes Then
         lineaProductoCompra.Add(CargaCambio(lineaDetalle, idUbicOrg, viejoStock))
      End If
      '---------------------------------------------

      Dim oMov As Entidades.MovimientoStock = New Entidades.MovimientoStock()
      Dim oCF As Entidades.CategoriaFiscal = Nothing

      With oMov
         .Sucursal = New Reglas.Sucursales(da).GetUna(idSucursal, False)
         '.Sucursal2 = 0

         .TipoMovimiento = TipoMovimiento
         .FechaMovimiento = Date.Now

         .DescuentoRecargo = 0

         .Total = lineaDetalle.ImporteTotal

         '.Proveedor.CategoriaFiscal.IvaDiscriminado = Me._categoriaFiscal.IvaDiscriminado

         .PercepcionIVA = 0
         .PercepcionIB = 0
         .PercepcionGanancias = 0
         .PercepcionVarias = 0

         .Comentarios = "** AJUSTE AUTOMATICO ***"
         .Observacion = "** AJUSTE AUTOMATICO ***"

         .Productos = lineaProductoCompra
         '.ProductosLotes = Nothing

         .Usuario = actual.Nombre

         'vml 3/12/12, agrego la parte contable
         .tablaContabilidad = tablaContabilidad
         ' fin parte contable

      End With

      If prodSuc.Producto.Lote Then
         'Si bien lo mas prolijo seria elegir lo que hay, por ahora (para siempre) lo limpia
         Dim sqlPL As SqlServer.ProductosLotes = New SqlServer.ProductosLotes(da)
         sqlPL.ProductosLotes_DProd(idSucursal, idProducto)
         '------------------------
      End If

      If prodSuc.Producto.NroSerie Then
         'Si bien lo mas prolijo seria elegir lo que hay, por ahora (para siempre) lo limpia
         Dim sqlPS As SqlServer.ProductosNrosSerie = New SqlServer.ProductosNrosSerie(da)
         sqlPS.ProductosNrosSerie_DProd(idSucursal, idProducto)
         '------------------------
      End If

      Dim oMovimientos = New Reglas.MovimientosStock(da)

      oMovimientos.CargarMovimientoStock(oMov, metodoGrabacion, idFuncion)

   End Sub

   Private Function CargaCambio(lineaDetalle As Entidades.MovimientoStockProducto, idUbicOrigen As Integer, viejoStock As Decimal) As Entidades.MovimientoStockProducto
      Dim lineaDetalleII = New Entidades.MovimientoStockProducto()
      With lineaDetalleII
         .IdProducto = lineaDetalle.IdProducto
         '---------------------------
         .IdDeposito = lineaDetalle.IdDeposito
         .IdUbicacion = idUbicOrigen
         '-- REQ-35260.- ------------
         .IdaAtributoProducto01 = lineaDetalle.IdaAtributoProducto01
         .IdaAtributoProducto02 = lineaDetalle.IdaAtributoProducto02
         .IdaAtributoProducto03 = lineaDetalle.IdaAtributoProducto03
         .IdaAtributoProducto04 = lineaDetalle.IdaAtributoProducto04
         '---------------------------
         .NombreProducto = lineaDetalle.NombreProducto
         .DescuentoRecargo = 0
         .Precio = lineaDetalle.Precio
         .Cantidad = (viejoStock * -1)
         .ImporteTotal = lineaDetalle.ImporteTotal + Decimal.Round(.Precio * .Cantidad, 2)
         .PorcentajeIVA = 0
         .IVA = 0
         .TotalProducto = .ImporteTotal
         .Stock = lineaDetalle.Stock
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .IdLote = ""
         .VtoLote = Nothing
         .Orden = 1
      End With
      Return lineaDetalleII
   End Function
   Public Sub _AjustarStockLote(idSucursal As Integer, idProducto As String,
                                tablaContabilidad As DataTable, grabaAutomatico As Boolean, esMultipleRubro As Boolean,
                                nuevoStock As Decimal,
                                idLote As String, fechaVencimiento As Date?,
                                idDeposito As Integer, idUbicacion As Integer,
                                metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String, cache As BusquedasCacheadas)
      Dim idTipoMovimiento = cache.BuscaTipoMovimiento("AJUSTE")

      Dim rProdSuc = New ProductosSucursales(da)
      Dim prodSuc = rProdSuc._GetUno(idSucursal, idProducto)

      Dim lstProductoCompra = New List(Of Entidades.MovimientoStockProducto)()
      Dim lstProductoCompraLote = New List(Of Entidades.ProductoLote)()

      Dim detalle = New Entidades.MovimientoStockProducto()
      With detalle
         .IdProducto = idProducto
         .NombreProducto = prodSuc.Producto.NombreProducto
         .DescuentoRecargo = 0
         If idTipoMovimiento.CargaPrecio = "PrecioCosto" Then
            .Precio = prodSuc.PrecioCosto
         ElseIf idTipoMovimiento.CargaPrecio = "PrecioVenta" Then
            .Precio = rProdSuc.GetPrecioVentaPredeterminado(idSucursal, idProducto)
         Else
            .Precio = 0
         End If

         .Cantidad = nuevoStock

         .ImporteTotal = Decimal.Round(.Precio * .Cantidad, 2)
         .PorcentajeIVA = 0
         .IVA = 0
         .TotalProducto = .ImporteTotal
         .Stock = prodSuc.Stock
         .IdSucursal = actual.Sucursal.Id
         .IdDeposito = idDeposito
         .IdUbicacion = idUbicacion
         .Usuario = actual.Nombre
         .IdLote = idLote.ToUpper()
         .VtoLote = fechaVencimiento
         .Orden = 1
      End With

      lstProductoCompra.Add(detalle)
      '---------------------------------------------

      Dim detalleLote = New Entidades.ProductoLote()
      With detalleLote
         .FechaVencimiento = fechaVencimiento
         .ProductoSucursal = prodSuc
         .IdLote = idLote.ToUpper()
         .IdDeposito = idDeposito
         .IdUbicacion = idUbicacion
         .FechaIngreso = Date.Now()
         .CantidadInicial = nuevoStock
         .CantidadActual = nuevoStock
         .Habilitado = True
      End With

      lstProductoCompraLote.Add(detalleLote)

      Dim oMov = New Entidades.MovimientoStock()
      With oMov
         .Sucursal = New Sucursales(da).GetUna(idSucursal, False)
         '.Sucursal2 = 0

         .TipoMovimiento = idTipoMovimiento
         .FechaMovimiento = Date.Now

         .DescuentoRecargo = 0

         .Total = detalle.ImporteTotal

         .PercepcionIVA = 0
         .PercepcionIB = 0
         .PercepcionGanancias = 0
         .PercepcionVarias = 0

         .Comentarios = "** IMPORTADOR LOTES ***"
         .Observacion = "** IMPORTADOR LOTES ***"

         .Productos = lstProductoCompra
         .ProductosLotes = lstProductoCompraLote

         .Usuario = actual.Nombre

         'vml 3/12/12, agrego la parte contable
         .tablaContabilidad = tablaContabilidad
         ' fin parte contable
      End With

      Dim rMovimientos = New MovimientosStock(da)
      rMovimientos.CargarMovimientoStock(oMov, metodoGrabacion, idFuncion)
   End Sub

   Public Sub BlanquearStock(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String)
      EjecutaConTransaccion(Sub() _BlanquearStock(idSucursal, idDeposito, idUbicacion, idProducto))
   End Sub
   Public Sub _BlanquearStock(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String)
      Dim sql = New SqlServer.Productos(da)
      sql.Productos_BlanquearStock(idSucursal, idDeposito, idUbicacion, idProducto)
   End Sub

   Public Function GetProductosDepositos(idProducto As String, idSucursal As Integer) As DataTable
      Return EjecutaConConexion(Function() _GetProductosDepositos(idProducto, idSucursal))
   End Function
   Public Function _GetProductosDepositos(idProducto As String, idSucursal As Integer) As DataTable
      Dim sql = New SqlServer.Productos(da)
      Return sql.GetProductosDepositos(idProducto, idSucursal, tipoDeposito:=String.Empty)
   End Function

   Public Function GetProductosDepositos(idProducto As String, idSucursal As Integer, TipoDeposito As String) As DataTable
      Return EjecutaConConexion(Function() _GetProductosDepositos(idProducto, idSucursal, TipoDeposito))
   End Function
   Public Function _GetProductosDepositos(idProducto As String, idSucursal As Integer, TipoDeposito As String) As DataTable
      Dim sql = New SqlServer.Productos(da)
      Return sql.GetProductosDepositos(idProducto, idSucursal, TipoDeposito)
   End Function

   Public Function GetProductosProveedores() As DataTable
      Return EjecutaConConexion(Function() _GetProductosProveedores())
   End Function
   Public Function _GetProductosProveedores() As DataTable
      Dim sql = New SqlServer.Productos(da)
      Return sql.GetProductosProveedores()
   End Function

   Public Function GetProductosCant(idSucursal As Integer, idListaPrecios As Integer) As DataTable
      Return EjecutaConConexion(Function() _GetProductosCant(idSucursal, idListaPrecios))
   End Function
   Public Function _GetProductosCant(idSucursal As Integer, idListaPrecios As Integer) As DataTable
      Dim sql = New SqlServer.Productos(da)
      Dim blnPreciosConIVA = Publicos.PreciosConIVA

      Return sql.GetProductosCant(blnPreciosConIVA, idSucursal, idListaPrecios)
   End Function

   Public Sub InactivarProductos(idMarca As Integer)
      Dim sql = New SqlServer.Productos(da)
      sql.Productos_InactivarProductos(idMarca)
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return Buscar(entidad, activos:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Overloads Function Buscar(entidad As Entidades.Buscar, activos As Entidades.Publicos.SiNoTodos) As DataTable

      Select Case entidad.Columna
         Case "NombreMarca"
            entidad.Columna = "M." + entidad.Columna
         Case "NombreModelo"
            entidad.Columna = "MO." + entidad.Columna
         Case "NombreRubro"
            entidad.Columna = "R." + entidad.Columna
         Case "NombreSubRubro"
            entidad.Columna = "SR." + entidad.Columna
         Case "NombreMoneda"
            entidad.Columna = "Mn." + entidad.Columna
         Case "Ubicacion", "FechaActualizacion", "StockMinimo", "PuntoDePedido", "StockMaximo"
            entidad.Columna = "PS." + entidad.Columna
         Case "StockActual"
            entidad.Columna = "PS.Stock"
         Case "NombreCentroCosto"
            entidad.Columna = "CECO." + entidad.Columna
         Case "NombreProduccionProceso"
            entidad.Columna = "PRP." + entidad.Columna
         Case "NombreProduccionForma"
            entidad.Columna = "PRF." + entidad.Columna
         Case "NombreSubSubRubro"
            entidad.Columna = "SSR." + entidad.Columna
         Case "CodigoProductoProveedor"
            entidad.Columna = "PP." + entidad.Columna
         Case Else
            entidad.Columna = "P." + entidad.Columna
      End Select

      Dim stbQuery = New StringBuilder()

      Dim consultaFoto As Boolean = False
      Dim espaciosID As Boolean = True

      With stbQuery
         Me.SelectFiltrado(stbQuery, consultaFoto, espaciosID)
         '.AppendLine("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")

         .AppendLine("  WHERE 1=1 ")

         Dim Palabras() As String = entidad.Valor.ToString.Split(" "c)

         For Each Palabra As String In Palabras
            .AppendLine("   AND " & entidad.Columna & " LIKE '%" & Palabra & "%'")
         Next

         If activos <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND P.{0} = {1}", Entidades.Producto.Columnas.Activo.ToString(), SqlServer.Comunes.GetStringFromBoolean(activos = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendLine(" ORDER BY P.NombreProducto ")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Productos(da).Productos_GA()
   End Function
   Public Overloads Function GetAll(activos As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.Productos(da).Productos_GA(activos)
   End Function

   Public Function GetProductosCalidad() As System.Data.DataTable
      Return New SqlServer.Productos(da).Productos_GProductosCalidad()
   End Function
   Public Function GetProductosCalidadSinReparaciones() As System.Data.DataTable
      Return New SqlServer.Productos(da).Productos_GProductosCalidadSinReparaciones()
   End Function

   Public Function GetChasisCalidad() As System.Data.DataTable
      Return New SqlServer.Productos(da).Productos_GChasisCalidad()
   End Function

   Public Function GetProductosGrillaFiltroMarcaRubroSubrubro(idSucursal As Integer, nombreProducto As String,
                                                              idMarca As Integer, idRubro As Integer, idSubRubro As Integer, idProducto As String) As DataTable

      Return New SqlServer.Productos(da).ProductosGrillaFiltroMarcaRubroSubRubro(idSucursal, nombreProducto, idMarca, idRubro, idSubRubro, idProducto,
                                                                                    Publicos.ListaPreciosPredeterminada, Publicos.PreciosConIVA)

   End Function

   Public Function GetProductosGrillaFiltroMultipleMarcaRubroSubrubro(idSucursal As Integer,
                                                             nombreProducto As String,
                                                              marcas As Entidades.Marca(),
                                                              rubros As Entidades.Rubro(),
                                                             idSubRubro As Integer,
                                                             idProducto As String) As System.Data.DataTable

      Return New SqlServer.Productos(da).ProductosGrillaFiltroMultipleMarcaRubroSubRubro(idSucursal, nombreProducto, marcas, rubros, idSubRubro, idProducto,
                                                                                    Publicos.ListaPreciosPredeterminada, Publicos.PreciosConIVA)

   End Function

   Public Function GetAlquilables(idProducto As String) As System.Data.DataTable

      Dim stbQuery = New StringBuilder()

      Dim consultaFoto As Boolean = False
      Dim espaciosID As Boolean = False

      With stbQuery
         Me.SelectFiltrado(stbQuery, consultaFoto, espaciosID)

         .AppendLine("  WHERE P.EsAlquilable = 'True' ")

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("  AND P.IdProducto = '" & idProducto & "'")
         End If

         .AppendLine(" ORDER BY P.NombreProducto ")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(produ As Entidades.Producto, tipo As TipoSP, _actualizaImagen As Boolean)

      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      Dim sql1 As SqlServer.ProductosConceptos = New SqlServer.ProductosConceptos(da)
      Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
      Dim sqlProductosWeb As SqlServer.ProductosWeb = New SqlServer.ProductosWeb(da)
      Dim rIdentificaciones As Reglas.ProductosIdentificaciones = New Reglas.ProductosIdentificaciones(da)
      Dim rProductoOfertas As Reglas.ProductosOfertas = New Reglas.ProductosOfertas(da)
      Dim rProductoLink = New Reglas.ProductosLinks(da)
      Dim rCalidadListaProducto = New Reglas.CalidadListasControlProductos(da)

      Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
      Dim dtAudit As DataTable = New DataTable()
      Dim OperacAudit As Entidades.OperacionesAuditorias

      Dim idProveedor As Long = 0
      If produ.Proveedor IsNot Nothing Then
         idProveedor = produ.Proveedor.IdProveedor
      End If

      Dim idCuentaCompras As Long?
      Dim idCuentaVentas As Long?
      Dim IdCuentaComprasSecundaria As Long?

      If produ.CuentaCompras IsNot Nothing AndAlso produ.CuentaCompras.IdCuenta > 0 Then idCuentaCompras = produ.CuentaCompras.IdCuenta
      If produ.CuentaVentas IsNot Nothing AndAlso produ.CuentaVentas.IdCuenta > 0 Then idCuentaVentas = produ.CuentaVentas.IdCuenta
      If produ.CuentaComprasSecundaria IsNot Nothing AndAlso produ.CuentaComprasSecundaria.IdCuenta > 0 Then IdCuentaComprasSecundaria = produ.CuentaComprasSecundaria.IdCuenta

      Select Case tipo
         Case TipoSP._I
            sql.Productos_I(produ.IdProducto, produ.NombreProducto, produ.Tamano, produ.UnidadDeMedida.IdUnidadDeMedida,
                              produ.IdMarca, produ.IdModelo, produ.IdRubro, produ.IdSubRubro, produ.MesesGarantia, produ.IdTipoImpuesto,
                              produ.Alicuota, produ.Alicuota2, produ.AfectaStock, produ.Activo, produ.Lote, produ.NroSerie, produ.CodigoDeBarras,
                              produ.EsServicio, produ.PublicarEnWeb, produ.Observacion, produ.EsCompuesto, produ.DescontarStockComponentes,
                              produ.EsDeCompras, produ.EsDeVentas, produ.Moneda.IdMoneda, produ.CodigoDeBarrasConPrecio, produ.PermiteModificarDescripcion,
                              produ.EsAlquilable, produ.EquipoMarca, produ.EquipoModelo, produ.CaractSII, produ.NumeroSerie, produ.Anio,
                              produ.PagaIngresosBrutos, produ.Embalaje, produ.Kilos, produ.KilosEsUMCompras, produ.IdFormula, produ.IdProductoMercosur, produ.IdProductoSecretaria,
                              produ.PublicarListaDePreciosClientes, produ.FacturacionCantidadNegativa, produ.SolicitaEnvase, produ.AlertaDeCaja,
                              produ.nombreCorto, produ.EsRetornable, produ.Orden, idProveedor, produ.CodigoLargoProducto, produ.ModalidadCodigoDeBarras,
                              produ.EsObservacion, produ.UnidHasta1, produ.UnidHasta2, produ.UnidHasta3, produ.UnidHasta4, produ.UnidHasta5,
                              produ.UHPorc1, produ.UHPorc2, produ.UHPorc3, produ.UHPorc4, produ.UHPorc5,
                              produ.UHListaPrecios1, produ.UHListaPrecios2, produ.UHListaPrecios3, produ.UHListaPrecios4, produ.UHListaPrecios5,
                              produ.PrecioPorEmbalaje, idCuentaCompras, idCuentaVentas, produ.ImporteImpuestoInterno, produ.EsOferta, IdCuentaComprasSecundaria,
                              produ.IncluirExpensas, produ.IdCentroCosto, produ.ObservacionCompras, produ.SolicitaPrecioVentaPorTamano,
                              produ.Espmm, produ.EspPulgadas, produ.CodigoSAE, produ.IdProduccionProceso, produ.IdProduccionForma,
                              produ.CalculaPreciosSegunFormula, produ.IdSubSubRubro, produ.PorcImpuestoInterno, produ.OrigenPorcImpInt,
                              produ.EsCambiable, produ.EsBonificable, produ.Alto, produ.Ancho, produ.Largo, produ.DescRecProducto,
                              produ.ActualizaPreciosSucursalesAsociadas, produ.CalidadStatusLiberado, produ.CalidadFechaLiberado,
                              produ.CalidadUserLiberado, produ.CalidadStatusEntregado, produ.CalidadFechaEntregado,
                              produ.CalidadUserEntregado, produ.CalidadFechaIngreso, produ.CalidadFechaEgreso,
                              produ.CalidadNroCertificado, produ.CalidadFecCertificado, produ.CalidadUsrCertificado,
                              produ.CalidadObservaciones, produ.CalidadFechaPreEnt, produ.CalidadFechaEntProg, produ.EsComercial,
                              produ.PublicarEnTiendaNube, produ.PublicarEnMercadoLibre, produ.PublicarEnArborea,
                              produ.PublicarEnGestion, produ.PublicarEnEmpresarial, produ.PublicarEnBalanza, produ.PublicarEnSincronizacionSucursal,
                              produ.CalidadNumeroChasis, produ.CalidadNroCarroceria, If(produ.UnidadDeMedida2 IsNot Nothing, produ.UnidadDeMedida2.IdUnidadDeMedida, Nothing), produ.Conversion, produ.IdProductoNumerico,
                              produ.EnviarSinCargo, produ.CodigoProductoTiendaNube, produ.CodigoProductoMercadoLibre, produ.CodigoProductoArborea, produ.IdVarianteProducto,
                              produ.IdProductoTipoServicio, produ.CalidadNroDeMotor, produ.CalidadFechaEntReProg, produ.IdProductoModelo,
                              produ.CalidadNroCertEntregado, produ.CalidadFecCertEntregado, produ.CalidadUsrCertEntregado,
                              produ.CalidadStatusLiberadoPDI, produ.CalidadFechaLiberadoPDI, produ.CalidadUserLiberadoPDI,
                              produ.CalidadNroCertEObs, produ.CalidadNroRemito, produ.TipoBonificacion, produ.idCategoriaMercadoLibre, produ.NombreProductoWeb,
                              produ.EsPerceptibleIVARes53292023, produ.IdProcesoProductivoDefecto, produ.ControlaRealizar, produ.InformeControlCalidad, produ.ValorAQL, produ.RealizaControlCalidad, produ.NivelInspeccion,
                              produ.UnidadDeMedidaCompra.IdUnidadDeMedida, produ.FactorConversionCompra, produ.UnidadDeMedidaProduccion.IdUnidadDeMedida,
                              produ.FactorConversionProduccion, produ.ComisionPorVenta, produ.EsDevuelto)


            If produ.ProductosWeb IsNot Nothing Then
               sqlProductosWeb.ProductosWeb_D(produ.IdProducto, Publicos.NombreBaseProductosWeb)
               sqlProductosWeb.ProductosWeb_I(produ.IdProducto, produ.ProductosWeb.Caracteristica1, produ.ProductosWeb.ValorCaracteristica1,
                                                     produ.ProductosWeb.Caracteristica2, produ.ProductosWeb.ValorCaracteristica2,
                                                     produ.ProductosWeb.Caracteristica3, produ.ProductosWeb.ValorCaracteristica3,
                                                     Publicos.NombreBaseProductosWeb, produ.ProductosWeb.EsParaConstructora, produ.ProductosWeb.EsParaIndustria,
                                                     produ.ProductosWeb.EsParaCooperativaElectrica, produ.ProductosWeb.EsParaMayorista,
                                                     produ.ProductosWeb.EsParaMinorista)

               sqlProductosWeb.GrabarFoto2(produ.ProductosWeb.Foto2, produ.IdProducto, Publicos.NombreBaseProductosWeb)

               sqlProductosWeb.GrabarFoto3(produ.ProductosWeb.Foto3, produ.IdProducto, Publicos.NombreBaseProductosWeb)

            End If

            rIdentificaciones.InsertaDesdeProducto(produ)

            rProductoOfertas.InsertaDesdeProducto(produ)

            '-- Adjunta Archivos del Producto.- --------
            rProductoLink.ActualizaDesdeProducto(produ)
            '-------------------------------------------
            '-- Adjunta Calidad del Producto.- --------
            rCalidadListaProducto.ActualizaDesdeProducto(produ.CalidadListaProductos, produ.IdProducto)
            '-------------------------------------------
            sql.GrabarFoto(produ.Foto, produ.IdProducto)

            rAudit.Insertar("Productos", Entidades.OperacionesAuditorias.Alta, actual.Nombre, String.Format("IdProducto = '{0}'", produ.IdProducto), conMilisegundos:=True)


            'Graba Conceptos
            '  sql1.ProductosConceptos_D(produ.IdProducto)

            For Each dr As Entidades.ProductoConcepto In produ.Conceptos
               sql1.ProductosConceptos_I(dr.IdProducto, dr.IdConcepto)
            Next

            If produ.Proveedor IsNot Nothing AndAlso produ.ProductoProveedorHabitual IsNot Nothing Then
               Dim sqlPP As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(da)
               sqlPP.ProductosProveedores_I(idProveedor, produ.IdProducto, produ.ProductoProveedorHabitual.CodigoProductoProveedor,
                                            produ.ProductoProveedorHabitual.UltimoPrecioCompra,
                                            produ.ProductoProveedorHabitual.UltimaFechaCompra,
                                            produ.ProductoProveedorHabitual.UltimoPrecioFabrica,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc1,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc2,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc3,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc4,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc5,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc6)
            End If

            Dim idProductoLong As Long
            If Long.TryParse(produ.IdProducto, idProductoLong) Then
               Dim rNumerador As Reglas.Numeradores = New Numeradores(da)
               rNumerador.ActualizarNumerador(Entidades.Numerador.TiposNumeradores.PRODUCTOS.ToString(), Long.Parse(produ.IdProducto))
            End If

         Case TipoSP._U
            If Publicos.EditaProductoNormalModificaHistorial Then
               'Modifica descripcion si producto NO PermiteModificarDescripcion
               Dim NombreProductoAnterior As String
               NombreProductoAnterior = sql.GetDescripcionProducto(produ.IdProducto)
               Dim sqlVentaProducto As SqlServer.VentasProductos = New SqlServer.VentasProductos(da)
               Dim sqlCompraProducto As SqlServer.ComprasProductos = New SqlServer.ComprasProductos(da)
               Dim sqlPedidoProducto As SqlServer.PedidosProductos = New SqlServer.PedidosProductos(da)
               Dim sqlPedidosProductosProveedores As SqlServer.PedidosProductosProveedores = New SqlServer.PedidosProductosProveedores(da)

               If NombreProductoAnterior <> produ.NombreProducto And produ.PermiteModificarDescripcion = False Then
                  sqlVentaProducto.VentasProductos_UDescripcion(produ.IdProducto, produ.NombreProducto)
                  sqlCompraProducto.ComprasProductos_UDescripcion(produ.IdProducto, produ.NombreProducto)
                  sqlPedidoProducto.PedidosProductos_UDescripcion(produ.IdProducto, produ.NombreProducto)
                  sqlPedidosProductosProveedores.PedidosProductosProveedores_UDescripcion(produ.IdProducto, produ.NombreProducto)
               End If

            End If

            If produ.PublicarEnSincronizacionSucursal Then
               Dim sqlPS = New SqlServer.ProductosSucursales(da)
               sqlPS.ProductosSucursales_U_Actualiza_Producto_PublicarEnSincronizacionSucursal(produ.IdProducto)
               Dim sqlPSP1 = New SqlServer.ProductosSucursalesPrecios(da)
               sqlPSP1.ProductosSucursalesPrecios_U_Actualiza_Producto_PublicarEnSincronizacionSucursal(produ.IdProducto)
            End If

            sql.Productos_U(produ.IdProducto, produ.NombreProducto, produ.Tamano, produ.UnidadDeMedida.IdUnidadDeMedida,
                              produ.IdMarca, produ.IdModelo, produ.IdRubro, produ.IdSubRubro, produ.MesesGarantia, produ.IdTipoImpuesto,
                              produ.Alicuota, produ.Alicuota2, produ.AfectaStock, produ.Activo, produ.Lote, produ.NroSerie, produ.CodigoDeBarras,
                              produ.EsServicio, produ.PublicarEnWeb, produ.Observacion, produ.EsCompuesto, produ.DescontarStockComponentes,
                              produ.EsDeCompras, produ.EsDeVentas, produ.Moneda.IdMoneda, produ.CodigoDeBarrasConPrecio, produ.PermiteModificarDescripcion,
                              produ.EsAlquilable, produ.EquipoMarca, produ.EquipoModelo, produ.CaractSII, produ.NumeroSerie, produ.Anio,
                              produ.PagaIngresosBrutos, produ.Embalaje, produ.Kilos, produ.KilosEsUMCompras, produ.IdFormula, produ.IdProductoMercosur, produ.IdProductoSecretaria,
                              produ.PublicarListaDePreciosClientes, produ.FacturacionCantidadNegativa, produ.SolicitaEnvase, produ.AlertaDeCaja,
                              produ.nombreCorto, produ.EsRetornable, produ.Orden, idProveedor, produ.CodigoLargoProducto, produ.ModalidadCodigoDeBarras,
                              produ.EsObservacion,
                              New Entidades.Modificable(Of Decimal)(produ.UnidHasta1),
                              New Entidades.Modificable(Of Decimal)(produ.UnidHasta2),
                              New Entidades.Modificable(Of Decimal)(produ.UnidHasta3),
                              New Entidades.Modificable(Of Decimal)(produ.UnidHasta4),
                              New Entidades.Modificable(Of Decimal)(produ.UnidHasta5),
                              New Entidades.Modificable(Of Decimal)(produ.UHPorc1),
                              New Entidades.Modificable(Of Decimal)(produ.UHPorc2),
                              New Entidades.Modificable(Of Decimal)(produ.UHPorc3),
                              New Entidades.Modificable(Of Decimal)(produ.UHPorc4),
                              New Entidades.Modificable(Of Decimal)(produ.UHPorc5),
                              produ.UHListaPrecios1, produ.UHListaPrecios2, produ.UHListaPrecios3, produ.UHListaPrecios4, produ.UHListaPrecios5,
                              produ.PrecioPorEmbalaje, idCuentaCompras, idCuentaVentas, produ.ImporteImpuestoInterno, produ.EsOferta, IdCuentaComprasSecundaria,
                              produ.IncluirExpensas, produ.IdCentroCosto, produ.ObservacionCompras, produ.SolicitaPrecioVentaPorTamano,
                              produ.Espmm, produ.EspPulgadas, produ.CodigoSAE, produ.IdProduccionProceso, produ.IdProduccionForma,
                              produ.CalculaPreciosSegunFormula, produ.IdSubSubRubro, produ.PorcImpuestoInterno, produ.OrigenPorcImpInt,
                              produ.EsCambiable, produ.EsBonificable, produ.Alto, produ.Ancho, produ.Largo,
                              New Entidades.Modificable(Of Decimal)(produ.DescRecProducto),
                              produ.ActualizaPreciosSucursalesAsociadas, produ.CalidadStatusLiberado, produ.CalidadFechaLiberado,
                              produ.CalidadUserLiberado, produ.CalidadStatusEntregado, produ.CalidadFechaEntregado,
                              produ.CalidadUserEntregado, produ.CalidadFechaIngreso, produ.CalidadFechaEgreso,
                              produ.CalidadNroCertificado, produ.CalidadFecCertificado, produ.CalidadUsrCertificado,
                              produ.CalidadObservaciones, produ.CalidadFechaPreEnt, produ.CalidadFechaEntProg, produ.EsComercial,
                              produ.PublicarEnTiendaNube, produ.PublicarEnMercadoLibre, produ.PublicarEnArborea,
                              produ.PublicarEnGestion, produ.PublicarEnEmpresarial, produ.PublicarEnBalanza, produ.PublicarEnSincronizacionSucursal,
                              produ.CalidadNumeroChasis, produ.CalidadNroCarroceria, If(produ.UnidadDeMedida2 IsNot Nothing, produ.UnidadDeMedida2.IdUnidadDeMedida, Nothing), produ.Conversion, produ.IdProductoNumerico,
                              produ.EnviarSinCargo, produ.CodigoProductoTiendaNube, produ.CodigoProductoMercadoLibre, produ.CodigoProductoArborea, produ.IdVarianteProducto,
                              produ.IdProductoTipoServicio, produ.CalidadNroDeMotor, produ.CalidadFechaEntReProg, produ.IdProductoModelo,
                              produ.CalidadNroCertEntregado, produ.CalidadFecCertEntregado, produ.CalidadUsrCertEntregado,
                              produ.CalidadStatusLiberadoPDI, produ.CalidadFechaLiberadoPDI, produ.CalidadUserLiberadoPDI,
                              produ.CalidadNroCertEObs, produ.CalidadNroRemito, produ.TipoBonificacion, produ.idCategoriaMercadoLibre, produ.NombreProductoWeb,
                              produ.EsPerceptibleIVARes53292023, produ.IdProcesoProductivoDefecto, produ.ControlaRealizar, produ.InformeControlCalidad, produ.ValorAQL, produ.RealizaControlCalidad, produ.NivelInspeccion,
                              produ.UnidadDeMedidaCompra.IdUnidadDeMedida, produ.FactorConversionCompra, produ.UnidadDeMedidaProduccion.IdUnidadDeMedida,
                              produ.FactorConversionProduccion, produ.ComisionPorVenta, produ.EsDevuelto)

            If produ.ProductosWeb IsNot Nothing Then
               sqlProductosWeb.ProductosWeb_D(produ.IdProducto, Publicos.NombreBaseProductosWeb)
               sqlProductosWeb.ProductosWeb_I(produ.IdProducto, produ.ProductosWeb.Caracteristica1, produ.ProductosWeb.ValorCaracteristica1,
                                                     produ.ProductosWeb.Caracteristica2, produ.ProductosWeb.ValorCaracteristica2,
                                                     produ.ProductosWeb.Caracteristica3, produ.ProductosWeb.ValorCaracteristica3,
                                                     Publicos.NombreBaseProductosWeb, produ.ProductosWeb.EsParaConstructora, produ.ProductosWeb.EsParaIndustria,
                                                     produ.ProductosWeb.EsParaCooperativaElectrica, produ.ProductosWeb.EsParaMayorista,
                                                     produ.ProductosWeb.EsParaMinorista)

               sqlProductosWeb.GrabarFoto2(produ.ProductosWeb.Foto2, produ.IdProducto, Publicos.NombreBaseProductosWeb)

               sqlProductosWeb.GrabarFoto3(produ.ProductosWeb.Foto3, produ.IdProducto, Publicos.NombreBaseProductosWeb)
            End If

            rIdentificaciones.Borra(produ)
            rIdentificaciones.InsertaDesdeProducto(produ)
            '-------------------------------------------
            rProductoOfertas.ActualizarDesdeProducto(produ)
            '-- Adjunta Archivos del Producto.- --------
            rProductoLink.ActualizaDesdeProducto(produ)
            '-------------------------------------------
            '-- Adjunta Calidad del Producto.- --------
            rCalidadListaProducto.ActualizaDesdeProducto(produ.CalidadListaProductos, produ.IdProducto)
            '-------------------------------------------

            If _actualizaImagen Then
               sql.GrabarFoto(produ.Foto, produ.IdProducto)
            End If

            'Por las dudas lanzo la actualizacion de los precios de listas. Esto esta por si reactive un producto inactivo.
            Dim sqlPSP As SqlServer.ProductosSucursalesPrecios = New SqlServer.ProductosSucursalesPrecios(da)
            sqlPSP.ProductosSucursalesPrecios_IFaltante(produ.IdProducto, actual.Nombre)

            'Por las dudas lanzo la actualizacion de los Lotes. Esto esta por si Califica de Lote uno con Stock.
            If produ.Lote Then
               Dim sqlPL As SqlServer.ProductosLotes = New SqlServer.ProductosLotes(da)
               sqlPL.ProductosLotes_IFaltante(produ.IdProducto)
            End If

            'Graba Conceptos
            sql1.ProductosConceptos_D(produ.IdProducto)

            For Each dr As Entidades.ProductoConcepto In produ.Conceptos
               sql1.ProductosConceptos_I(dr.IdProducto, dr.IdConcepto)
            Next

            Dim sqlProdSuc = New SqlServer.ProductosSucursales(da)
            sqlProdSuc.ProductosSucursales_UEstadistica(actual.Sucursal.Id, produ.IdProducto, produ.PuntoDePedido, produ.StockMinimo, produ.StockMaximo, New Entidades.CRMNovedad.CambioMasivo.NullableString(produ.Ubicacion))

            If actual.Sucursal.IdSucursalAsociada > 0 Then
               sqlProdSuc.ProductosSucursales_UEstadistica(actual.Sucursal.IdSucursalAsociada, produ.IdProducto, produ.PuntoDePedido, produ.StockMinimo, produ.StockMaximo, New Entidades.CRMNovedad.CambioMasivo.NullableString(produ.Ubicacion))
            End If

            'If produ.Ubicacion <> "" Then
            '   PS.ProductosSucursales_Ubicacion(produ.IdProducto, actual.Sucursal.Id, produ.Ubicacion)
            'End If

            If produ.Proveedor IsNot Nothing AndAlso produ.ProductoProveedorHabitual IsNot Nothing Then
               Dim sqlPP As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(da)
               sqlPP.ProductosProveedores_D(idProveedor, produ.IdProducto)
               sqlPP.ProductosProveedores_I(idProveedor, produ.IdProducto, produ.ProductoProveedorHabitual.CodigoProductoProveedor,
                                            produ.ProductoProveedorHabitual.UltimoPrecioCompra,
                                            produ.ProductoProveedorHabitual.UltimaFechaCompra,
                                            produ.ProductoProveedorHabitual.UltimoPrecioFabrica,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc1,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc2,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc3,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc4,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc5,
                                            produ.ProductoProveedorHabitual.DescuentoRecargoPorc6)
            End If

            'Graba Auditoria
            dtAudit = sqlAudit.Auditorias_G1("Productos", "IdProducto = '" & produ.IdProducto & "'")

            'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
            If dtAudit.Rows.Count > 0 Then

               Select Case True
                  Case Not produ.Activo And Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
                     'Lo inactivo
                     OperacAudit = Entidades.OperacionesAuditorias.Inactivar
                  Case produ.Activo And Not Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
                     'Lo activo
                     OperacAudit = Entidades.OperacionesAuditorias.Alta
                  Case Else
                     OperacAudit = Entidades.OperacionesAuditorias.Modificacion
               End Select

            Else

               OperacAudit = Entidades.OperacionesAuditorias.Alta

            End If

            rAudit.Insertar("Productos", OperacAudit, actual.Nombre, "IdProducto = '" & produ.IdProducto & "'", conMilisegundos:=False,
                            camposIgnorarComparar:={Entidades.Producto.Columnas.FechaActualizacionWeb.ToString()})



         Case TipoSP._D

            rAudit.Insertar("Productos", Entidades.OperacionesAuditorias.Baja, actual.Nombre, "IdProducto = '" & produ.IdProducto & "'", conMilisegundos:=False)

            'Si Borro de la Central... borro todo. (Por perfiles de Seguridad solo deberia ser asi...)
            Dim idSucursal As Integer = actual.Sucursal.Id
            If actual.Sucursal.SoyLaCentral Then idSucursal = 0

            sqlProductosWeb.ProductosWeb_D(produ.IdProducto, Publicos.NombreBaseProductosWeb)
            rIdentificaciones.Borra(produ)
            rProductoOfertas.BorraDesdeProducto(produ)

            sql.Productos_D(produ.IdProducto, idSucursal)

            'If IsNumeric(produ.IdProducto) Then
            '   Dim rNumerador As Reglas.Numeradores = New Numeradores(da)
            '   rNumerador.ActualizarNumerador(Entidades.Numerador.TiposNumeradores.PRODUCTOS.ToString(), Long.Parse(produ.IdProducto))
            'End If

      End Select

   End Sub

   Private Sub SelectFiltrado(ByRef stb As StringBuilder, incluirFoto As Boolean, espaciosID As Boolean)
      Dim sql = New SqlServer.Productos(da)
      sql.SelectTexto(stb, incluirFoto, espaciosID, auditoria:=False)
   End Sub

   Private Sub CargarUno(o As Entidades.Producto, dr As DataRow, incluirPrecios As Boolean)

      Dim rUM = New UnidadesDeMedidas(da)

      With o

         .IdProducto = dr.Field(Of String)("IdProducto")
         .NombreProducto = dr.Field(Of String)("NombreProducto")
         .nombreCorto = dr.Field(Of String)("NombreCorto").IfNull()
         '-- REQ-31619.-
         .NombreProductoWeb = dr.Field(Of String)("NombreProductoWeb").IfNull()

         .Tamano = dr.Field(Of Decimal?)("Tamano").IfNull()
         .UnidadDeMedida = rUM.GetUno(dr.Field(Of String)("IdUnidadDeMedida"))

         .IdMarca = dr.Field(Of Integer)("IdMarca")
         .NombreMarca = dr.Field(Of String)("NombreMarca").IfNull()
         .IdModelo = dr.Field(Of Integer?)("IdModelo").IfNull()
         .NombreModelo = dr.Field(Of String)("NombreModelo").IfNull()

         .IdRubro = dr.Field(Of Integer)("IdRubro")
         .IdSubRubro = dr.Field(Of Integer?)("IdSubRubro").IfNull()
         .IdSubSubRubro = dr.Field(Of Integer?)("IdSubSubRubro").IfNull()

         .IdTipoImpuesto = dr.Field(Of String)("IdTipoImpuesto")
         .Alicuota = dr.Field(Of Decimal)("Alicuota")
         .Alicuota2 = dr.Field(Of Decimal?)("Alicuota2").IfNull()

         .MesesGarantia = dr.Field(Of Integer)("MesesGarantia")
         .AfectaStock = dr.Field(Of Boolean)("AfectaStock")

         If Not String.IsNullOrEmpty(dr("Foto").ToString()) Then
            Dim content() As Byte = CType(dr("Foto"), Byte())
            Using stream = New System.IO.MemoryStream(content)
               .Foto = New Drawing.Bitmap(stream)
            End Using
         End If

         .PermiteModificarDescripcion = dr.Field(Of Boolean)("PermiteModificarDescripcion")
         .Lote = dr.Field(Of Boolean)("Lote")
         .NroSerie = dr.Field(Of Boolean)("NroSerie")

         .CodigoDeBarras = dr.Field(Of String)("CodigoDeBarras").IfNull()
         .CodigoDeBarrasConPrecio = dr.Field(Of Boolean)("CodigoDeBarrasConPrecio")
         .ModalidadCodigoDeBarras = dr.Field(Of String)(Entidades.Producto.Columnas.ModalidadCodigoDeBarras.ToString())

         .EsServicio = dr.Field(Of Boolean)("EsServicio")

         .PublicarEnWeb = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnWeb.ToString())
         .PublicarListaDePreciosClientes = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarListaDePreciosClientes.ToString())

         .PublicarEnTiendaNube = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnTiendaNube.ToString())
         .PublicarEnMercadoLibre = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnMercadoLibre.ToString())
         .PublicarEnArborea = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnArborea.ToString())
         .PublicarEnGestion = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnGestion.ToString())
         .PublicarEnEmpresarial = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnEmpresarial.ToString())
         .PublicarEnBalanza = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnBalanza.ToString())
         .PublicarEnSincronizacionSucursal = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnSincronizacionSucursal.ToString())

         .Observacion = dr("Observacion").ToString()
         .EsCompuesto = Boolean.Parse(dr("EsCompuesto").ToString())
         .DescontarStockComponentes = Boolean.Parse(dr("DescontarStockComponentes").ToString())
         .EsDeCompras = Boolean.Parse(dr("EsDeCompras").ToString())
         .EsDeVentas = Boolean.Parse(dr("EsDeVentas").ToString())
         .Moneda = New Reglas.Monedas(da).GetUna(Integer.Parse(dr("IdMoneda").ToString()))

         .EsAlquilable = Boolean.Parse(dr("EsAlquilable").ToString())
         .EquipoMarca = dr("EquipoMarca").ToString()
         .EquipoModelo = dr("EquipoModelo").ToString()
         .CaractSII = dr("CaractSII").ToString()
         .NumeroSerie = dr("NumeroSerie").ToString()
         .CodigoProductoArborea = dr("CodigoProductoArborea").ToString
         If Not String.IsNullOrEmpty(dr("Anio").ToString()) Then
            .Anio = Integer.Parse(dr("Anio").ToString())
         End If

         .Activo = Boolean.Parse(dr("Activo").ToString())
         .PagaIngresosBrutos = Boolean.Parse(dr("PagaIngresosBrutos").ToString())
         .Embalaje = Integer.Parse(dr("Embalaje").ToString())
         .Kilos = Decimal.Parse(dr("kilos").ToString())
         .KilosEsUMCompras = dr.Field(Of Boolean)("KilosEsUMCompras")
         If Not String.IsNullOrEmpty(dr("IdFormula").ToString()) Then
            .IdFormula = Integer.Parse(dr("IdFormula").ToString())
         End If
         .IdProductoMercosur = dr("IdProductoMercosur").ToString()
         .IdProductoSecretaria = dr("IdProductoSecretaria").ToString()

         .FacturacionCantidadNegativa = Boolean.Parse(dr("FacturacionCantidadNegativa").ToString())
         .SolicitaEnvase = Boolean.Parse(dr("SolicitaEnvase").ToString())
         .AlertaDeCaja = Boolean.Parse(dr("AlertaDeCaja").ToString())
         .Conceptos = New Reglas.ProductosConceptos(da).GetConceptos(.IdProducto)
         .EsRetornable = Boolean.Parse(dr("EsRetornable").ToString())
         .Orden = Integer.Parse(dr("Orden").ToString())
         .CodigoLargoProducto = dr(Entidades.Producto.Columnas.CodigoLargoProducto.ToString()).ToString()
         If Not IsDBNull(dr(Entidades.Producto.Columnas.IdProveedor.ToString())) AndAlso
            CLng(dr(Entidades.Producto.Columnas.IdProveedor.ToString())) > 0 Then
            .Proveedor = New Proveedores(da)._GetUno(CLng(dr(Entidades.Producto.Columnas.IdProveedor.ToString())))
            If .Proveedor IsNot Nothing Then
               .ProductoProveedorHabitual = New ProductosProveedores(da).GetUno(.Proveedor.IdProveedor, .IdProducto)
            End If
         End If

         If incluirPrecios Then
            .Precios = New SqlServer.Productos(da).GetPreciosProducto(.IdProducto, actual.Sucursal.IdSucursal)

            Dim dt As DataTable = New SqlServer.ProductosSucursales(da).ProductosSucursales_G1(.IdProducto, actual.Sucursal.IdSucursal, Publicos.ListaPreciosPredeterminada, False)
            If dt.Rows.Count > 0 Then
               .PrecioCosto = CDec(dt.Rows(0)("PrecioCosto"))
            End If

            dt = New SqlServer.HistorialPrecios(da).GetHistorialPrecios({actual.Sucursal.Id},
                                                                        fechaDesde:=Nothing, fechaHasta:=Nothing,
                                                                        idProducto:= .IdProducto.Trim(),
                                                                        idMarca:=0, idRubro:=0, usuario:="",
                                                                        listaDePrecios:=Nothing,
                                                                        cantidadRegistros:=2, ordenDescendente:=True, traerListaDeCostos:=True)
            '# Se agrega parámetro especial para traer Lista de Costos
            '# PE27174

            'Estoy pidiendo los dos registros más nuevos. 
            '     - El primero (0) es el precio de costo actual
            '     - El segundo (1) es el precio de costo anterios
            If dt.Rows.Count > 1 Then
               .PrecioCostoAnterior = Decimal.Parse(dt.Rows(1)("PrecioCosto").ToString())
               .FechaUltimoCostoAnterior = DateTime.Parse(dt.Rows(1)("FechaHora").ToString())
            Else
               .PrecioCostoAnterior = Nothing
               .FechaUltimoCostoAnterior = Nothing
            End If
         End If

         .EsObservacion = CBool(dr("EsObservacion"))
         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.UnidHasta1.ToString()).ToString()) Then
            .UnidHasta1 = Decimal.Parse(dr(Entidades.Producto.Columnas.UnidHasta1.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.UnidHasta2.ToString()).ToString()) Then
            .UnidHasta2 = Decimal.Parse(dr(Entidades.Producto.Columnas.UnidHasta2.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.UnidHasta3.ToString()).ToString()) Then
            .UnidHasta3 = Decimal.Parse(dr(Entidades.Producto.Columnas.UnidHasta3.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.UnidHasta4.ToString()).ToString()) Then
            .UnidHasta4 = Decimal.Parse(dr(Entidades.Producto.Columnas.UnidHasta4.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.UnidHasta5.ToString()).ToString()) Then
            .UnidHasta5 = Decimal.Parse(dr(Entidades.Producto.Columnas.UnidHasta5.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.UHPorc1.ToString()).ToString()) Then
            .UHPorc1 = Decimal.Parse(dr(Entidades.Producto.Columnas.UHPorc1.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.UHPorc2.ToString()).ToString()) Then
            .UHPorc2 = Decimal.Parse(dr(Entidades.Producto.Columnas.UHPorc2.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.UHPorc3.ToString()).ToString()) Then
            .UHPorc3 = Decimal.Parse(dr(Entidades.Producto.Columnas.UHPorc3.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.UHPorc4.ToString()).ToString()) Then
            .UHPorc4 = Decimal.Parse(dr(Entidades.Producto.Columnas.UHPorc4.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.UHPorc5.ToString()).ToString()) Then
            .UHPorc5 = Decimal.Parse(dr(Entidades.Producto.Columnas.UHPorc5.ToString()).ToString())
         End If
         .UHListaPrecios1 = dr.Field(Of Integer?)("UHListaPrecios1")
         .UHListaPrecios2 = dr.Field(Of Integer?)("UHListaPrecios2")
         .UHListaPrecios3 = dr.Field(Of Integer?)("UHListaPrecios3")
         .UHListaPrecios4 = dr.Field(Of Integer?)("UHListaPrecios4")
         .UHListaPrecios5 = dr.Field(Of Integer?)("UHListaPrecios5")
         .UHListaPrecios1Nombre = dr.Field(Of String)("NombreListaPrecios_1")
         .UHListaPrecios2Nombre = dr.Field(Of String)("NombreListaPrecios_2")
         .UHListaPrecios3Nombre = dr.Field(Of String)("NombreListaPrecios_3")
         .UHListaPrecios4Nombre = dr.Field(Of String)("NombreListaPrecios_4")
         .UHListaPrecios5Nombre = dr.Field(Of String)("NombreListaPrecios_5")

         .PrecioPorEmbalaje = Boolean.Parse(dr("PrecioPorEmbalaje").ToString())

         If Not IsDBNull(dr(Entidades.Producto.Columnas.IdCuentaCompras.ToString())) Then
            .CuentaCompras = New Reglas.ContabilidadCuentas(da)._GetUna(CLng(dr(Entidades.Producto.Columnas.IdCuentaCompras.ToString())))
         End If
         If Not IsDBNull(dr(Entidades.Producto.Columnas.IdCuentaVentas.ToString())) Then
            .CuentaVentas = New Reglas.ContabilidadCuentas(da)._GetUna(CLng(dr(Entidades.Producto.Columnas.IdCuentaVentas.ToString())))
         End If

         If Not IsDBNull(dr(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString())) Then
            .CuentaComprasSecundaria = New Reglas.ContabilidadCuentas(da)._GetUna(CLng(dr(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString())))
         End If

         .ImporteImpuestoInterno = Decimal.Parse(dr("ImporteImpuestoInterno").ToString())
         .EsOferta = dr("EsOferta").ToString()

         .IncluirExpensas = CBool(dr("IncluirExpensas"))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdCentroCosto.ToString()).ToString()) Then
            .CentroCosto = New Reglas.ContabilidadCentrosCostos(da)._GetUna(Integer.Parse(dr(Entidades.Producto.Columnas.IdCentroCosto.ToString()).ToString()))
         End If

         If IsNumeric(dr("StockActual")) Then
            .StockActual = Decimal.Parse(dr("StockActual").ToString())
         End If
         If IsNumeric(dr("StockMinimo")) Then
            .StockMinimo = Decimal.Parse(dr("StockMinimo").ToString())
         End If
         If IsNumeric(dr("PuntoDePedido")) Then
            .PuntoDePedido = Decimal.Parse(dr("PuntoDePedido").ToString())
         End If
         If IsNumeric(dr("StockMaximo")) Then
            .StockMaximo = Decimal.Parse(dr("StockMaximo").ToString())
         End If

         .ObservacionCompras = dr("ObservacionCompras").ToString()
         .SolicitaPrecioVentaPorTamano = Boolean.Parse(dr(Entidades.Producto.Columnas.SolicitaPrecioVentaPorTamano.ToString()).ToString())

         If IsNumeric(dr(Entidades.Producto.Columnas.Espmm.ToString())) Then
            .Espmm = Decimal.Parse(dr(Entidades.Producto.Columnas.Espmm.ToString()).ToString())
         End If
         .EspPulgadas = dr(Entidades.Producto.Columnas.EspPulgadas.ToString()).ToString()

         If Not String.IsNullOrEmpty(dr(Entidades.Producto.Columnas.CodigoSAE.ToString()).ToString()) Then
            .CodigoSAE = dr(Entidades.Producto.Columnas.CodigoSAE.ToString()).ToString()
         End If

         If IsNumeric(dr(Entidades.Producto.Columnas.IdProduccionProceso.ToString())) Then
            .IdProduccionProceso = Integer.Parse(dr(Entidades.Producto.Columnas.IdProduccionProceso.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Producto.Columnas.IdProduccionForma.ToString())) Then
            .IdProduccionForma = Integer.Parse(dr(Entidades.Producto.Columnas.IdProduccionForma.ToString()).ToString())
         End If

         .CalculaPreciosSegunFormula = Boolean.Parse(dr(Entidades.Producto.Columnas.CalculaPreciosSegunFormula.ToString()).ToString())

         If Not String.IsNullOrEmpty(dr("IdSubSubRubro").ToString()) Then
            .IdSubSubRubro = Integer.Parse(dr("IdSubSubRubro").ToString())
         End If

         .PorcImpuestoInterno = Decimal.Parse(dr(Entidades.Producto.Columnas.PorcImpuestoInterno.ToString()).ToString())
         .OrigenPorcImpInt = DirectCast([Enum].Parse(GetType(Entidades.OrigenesPorcImpInt), dr(Entidades.Producto.Columnas.OrigenPorcImpInt.ToString()).ToString()), Entidades.OrigenesPorcImpInt)

         .EsCambiable = Boolean.Parse(dr(Entidades.Producto.Columnas.EsCambiable.ToString()).ToString())
         .EsBonificable = Boolean.Parse(dr(Entidades.Producto.Columnas.EsBonificable.ToString()).ToString())
         .Alto = Decimal.Parse(dr("Alto").ToString())
         .Ancho = Decimal.Parse(dr("Ancho").ToString())
         .Largo = Decimal.Parse(dr("Largo").ToString())

         .DescRecProducto = Decimal.Parse(dr(Entidades.Producto.Columnas.DescRecProducto.ToString()).ToString())
         .ActualizaPreciosSucursalesAsociadas = Boolean.Parse(dr(Entidades.Producto.Columnas.ActualizaPreciosSucursalesAsociadas.ToString()).ToString())

         .Identificaciones = New ProductosIdentificaciones(da).GetTodos(.IdProducto.Trim())
         .ProductosOfertas = New ProductosOfertas(da).GetTodos(.IdProducto.Trim())
         .CodigoProductoArborea = dr("CodigoProductoArborea").ToString
         .CalidadStatusLiberado = Boolean.Parse(dr(Entidades.Producto.Columnas.CalidadStatusLiberado.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaLiberado.ToString()).ToString()) Then
            .CalidadFechaLiberado = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaLiberado.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadUserLiberado.ToString()).ToString()) Then
            .CalidadUserLiberado = dr(Entidades.Producto.Columnas.CalidadUserLiberado.ToString()).ToString()
         End If

         .CalidadStatusEntregado = Boolean.Parse(dr(Entidades.Producto.Columnas.CalidadStatusEntregado.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaEntregado.ToString()).ToString()) Then
            .CalidadFechaEntregado = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaEntregado.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadUserEntregado.ToString()).ToString()) Then
            .CalidadUserEntregado = dr(Entidades.Producto.Columnas.CalidadUserEntregado.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaIngreso.ToString()).ToString()) Then
            .CalidadFechaIngreso = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaIngreso.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaEgreso.ToString()).ToString()) Then
            .CalidadFechaEgreso = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaEgreso.ToString()).ToString())
         End If

         If IsNumeric(dr(Entidades.Producto.Columnas.CalidadNroCertificado.ToString()).ToString()) Then
            .CalidadNroCertificado = Integer.Parse(dr(Entidades.Producto.Columnas.CalidadNroCertificado.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFecCertificado.ToString()).ToString()) Then
            .CalidadFecCertificado = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFecCertificado.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadUsrCertificado.ToString()).ToString()) Then
            .CalidadUsrCertificado = dr(Entidades.Producto.Columnas.CalidadUsrCertificado.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadObservaciones.ToString()).ToString()) Then
            .CalidadObservaciones = dr(Entidades.Producto.Columnas.CalidadObservaciones.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaPreEnt.ToString()).ToString()) Then
            .CalidadFechaPreEnt = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaPreEnt.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaEntProg.ToString()).ToString()) Then
            .CalidadFechaEntProg = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaEntProg.ToString()).ToString())
         End If
         .Ubicacion = dr(Entidades.ProductoSucursal.Columnas.Ubicacion.ToString()).ToString()
         .EsComercial = Boolean.Parse(dr(Entidades.Producto.Columnas.EsComercial.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadNumeroChasis.ToString()).ToString()) Then
            .CalidadNumeroChasis = dr(Entidades.Producto.Columnas.CalidadNumeroChasis.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.FechaActualizacionWeb.ToString()).ToString()) Then
            .FechaActualizacionWeb = DateTime.Parse(dr(Entidades.Producto.Columnas.FechaActualizacionWeb.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Producto.Columnas.CalidadNroCarroceria.ToString()).ToString()) Then
            .CalidadNroCarroceria = Integer.Parse(dr(Entidades.Producto.Columnas.CalidadNroCarroceria.ToString()).ToString())
         End If

         .UnidadDeMedida2 = rUM.GetUno(dr.Field(Of String)(Entidades.Producto.Columnas.IdUnidadDeMedida2.ToString()))
         .Conversion = dr.Field(Of Decimal)(Entidades.Producto.Columnas.Conversion.ToString())
         .IdProductoNumerico = dr.Field(Of Long?)(Entidades.Producto.Columnas.IdProductoNumerico.ToString())
         .EnviarSinCargo = dr.Field(Of Boolean)(Entidades.Producto.Columnas.EnviarSinCargo.ToString())

         .CodigoProductoTiendaNube = dr.Field(Of String)(Entidades.Producto.Columnas.CodigoProductoTiendaNube.ToString())
         .CodigoProductoMercadoLibre = dr.Field(Of String)(Entidades.Producto.Columnas.CodigoProductoMercadoLibre.ToString())
         .idCategoriaMercadoLibre = dr.Field(Of String)(Entidades.Producto.Columnas.idCategoriaMercadoLibre.ToString())

         .IdVarianteProducto = dr.Field(Of String)(Entidades.Producto.Columnas.IdVarianteProducto.ToString())
         If IsNumeric(dr(Entidades.Producto.Columnas.IdProductoTipoServicio.ToString()).ToString()) Then
            .IdProductoTipoServicio = Integer.Parse(dr(Entidades.Producto.Columnas.IdProductoTipoServicio.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadNroDeMotor.ToString()).ToString()) Then
            .CalidadNroDeMotor = dr(Entidades.Producto.Columnas.CalidadNroDeMotor.ToString()).ToString()
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaEntReProg.ToString()).ToString()) Then
            .CalidadFechaEntReProg = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaEntReProg.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Producto.Columnas.IdProductoModelo.ToString()).ToString()) Then
            .IdProductoModelo = Integer.Parse(dr(Entidades.Producto.Columnas.IdProductoModelo.ToString()).ToString())
         End If

         If IsNumeric(dr(Entidades.Producto.Columnas.CalidadNroCertEntregado.ToString()).ToString()) Then
            .CalidadNroCertEntregado = Integer.Parse(dr(Entidades.Producto.Columnas.CalidadNroCertEntregado.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFecCertEntregado.ToString()).ToString()) Then
            .CalidadFecCertEntregado = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFecCertEntregado.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadUsrCertEntregado.ToString()).ToString()) Then
            .CalidadUsrCertEntregado = dr(Entidades.Producto.Columnas.CalidadUsrCertEntregado.ToString()).ToString()
         End If

         .CalidadStatusLiberadoPDI = Boolean.Parse(dr(Entidades.Producto.Columnas.CalidadStatusLiberadoPDI.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaLiberadoPDI.ToString()).ToString()) Then
            .CalidadFechaLiberadoPDI = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaLiberadoPDI.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadUserLiberadoPDI.ToString()).ToString()) Then
            .CalidadUserLiberadoPDI = dr(Entidades.Producto.Columnas.CalidadUserLiberadoPDI.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadNroCertEObs.ToString()).ToString()) Then
            .CalidadNroCertEObs = dr(Entidades.Producto.Columnas.CalidadNroCertEObs.ToString()).ToString()
         End If

         If IsNumeric(dr(Entidades.Producto.Columnas.CalidadNroRemito.ToString()).ToString()) Then
            .CalidadNroRemito = Long.Parse(dr(Entidades.Producto.Columnas.CalidadNroRemito.ToString()).ToString())
         End If

         Dim dt1 As DataTable = New SqlServer.ProductosSucursales(da).ProductosSucursales_G1(.IdProducto, actual.Sucursal.IdSucursal, Publicos.ListaPreciosPredeterminada, False)
         If dt1.Any() Then
            Dim dr1 = dt1.First()
            Dim idDep = dr1.Field(Of Integer?)("IdDepositoDefecto")
            Dim idUbi = dr1.Field(Of Integer?)("IdUbicacionDefecto")

            If Not idDep.HasValue Then
               Throw New Exception(String.Format("El Producto {0} - {1} no tiene Deposito por Defecto configurado para la Sucursal {2}. Contacte con Sinergia para solucionar el problema",
                                                 .IdProducto, .NombreProducto, actual.Sucursal.IdSucursal))
            End If
            If Not idUbi.HasValue Then
               Throw New Exception(String.Format("El Producto {0} - {1} no tiene Ubicación por Defecto configurado para la Sucursal {2}. Contacte con Sinergia para solucionar el problema",
                                                 .IdProducto, .NombreProducto, actual.Sucursal.IdSucursal))
            End If

            .IdDeposito = idDep.Value
            .IdUbicacion = idUbi.Value
         End If

         .TipoBonificacion = DirectCast([Enum].Parse(GetType(Entidades.Producto.TiposBonificacionesProductos), dr(Entidades.Producto.Columnas.TipoBonificacion.ToString()).ToString()), Entidades.Producto.TiposBonificacionesProductos)

         .EsPerceptibleIVARes53292023 = dr.Field(Of Boolean)("EsPerceptibleIVARes53292023")

         '-- REQ-38948.- ---------------------------------------------------------------------
         .IdProcesoProductivoDefecto = dr.Field(Of Long?)(Entidades.Producto.Columnas.IdProcesoProductivoDefecto.ToString())
         .ControlaRealizar = dr(Entidades.Producto.Columnas.ControlaRealizar.ToString()).ToString()
         .InformeControlCalidad = Boolean.Parse(dr(Entidades.Producto.Columnas.InformeControlCalidad.ToString()).ToString())
         .ValorAQL = Decimal.Parse(dr(Entidades.Producto.Columnas.ValorAQL.ToString()).ToString())
         '------------------------------------------------------------------------------------
         .ArchivosAdjuntos = New ProductosLinks(da)._GetTodas(.IdProducto.Trim())
         '------------------------------------------------------------------------------------
         .CalidadListaProductos = New Reglas.CalidadListasControlProductos(da)._GetTodos(.IdProducto.Trim())

         .NivelInspeccion = dr(Entidades.Producto.Columnas.NivelInspeccion.ToString()).ToString()
         .RealizaControlCalidad = Boolean.Parse(dr(Entidades.Producto.Columnas.RealizaControlCalidad.ToString()).ToString())

         .UnidadDeMedidaCompra = rUM.GetUno(dr.Field(Of String)(Entidades.Producto.Columnas.IdUnidadDeMedidaCompra.ToString()))
         .FactorConversionCompra = dr.Field(Of Decimal)(Entidades.Producto.Columnas.FactorConversionCompra.ToString())
         .UnidadDeMedidaProduccion = rUM.GetUno(dr.Field(Of String)(Entidades.Producto.Columnas.IdUnidadDeMedidaProduccion.ToString()))
         .FactorConversionProduccion = dr.Field(Of Decimal)(Entidades.Producto.Columnas.FactorConversionProduccion.ToString())
         .ComisionPorVenta = dr.Field(Of Decimal)(Entidades.Producto.Columnas.ComisionPorVenta.ToString())

         .EsDevuelto = Boolean.Parse(dr(Entidades.Producto.Columnas.EsDevuelto.ToString()).ToString())

      End With

   End Sub

   Private Sub RecalculaPrecios(dtListaPrecios As DataTable, IdProducto As String, txtPrecioCosto As Decimal,
                             redondeoPrecioVenta As Integer, realizaAjusteA As Boolean, ajusteA As Integer)
      For Each drPrecios As DataRow In dtListaPrecios.Rows
         If CBool(drPrecios(ListaPreciosColumns.PorcActual.ToString())) Then
            RecalculaPreciosPorcActual(drPrecios, txtPrecioCosto)
         ElseIf CBool(drPrecios(ListaPreciosColumns.SobreCosto.ToString())) Then
            RecalculaPreciosSobreCosto(drPrecios, txtPrecioCosto)
         ElseIf CBool(drPrecios(ListaPreciosColumns.SobreVenta.ToString())) Then
            RecalculaPreciosSobreVenta(drPrecios)
         ElseIf CBool(drPrecios(ListaPreciosColumns.DesdeFormula.ToString())) Then
            RecalculaPreciosDesdeFormula(drPrecios, IdProducto)
         End If

         Dim precioVentaNuevo As Decimal = CDec(drPrecios(ListaPreciosColumns.PrecioVenta.ToString()))

         precioVentaNuevo = Math.Round(precioVentaNuevo, redondeoPrecioVenta)

         If realizaAjusteA And precioVentaNuevo > 0 Then
            'Si ajustamos a 0
            If realizaAjusteA And ajusteA = 0 Then
               Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, redondeoPrecioVenta))
               precioVentaNuevo = Decimal.Parse(Split(PrecioTemporal, ".")(0).Substring(0, Split(PrecioTemporal, ".")(0).Length() - 1) + ajusteA.ToString())
            Else
               Dim PrecioTemporal As String = precioVentaNuevo.ToString("#,##0." + New String("0"c, redondeoPrecioVenta))
               precioVentaNuevo = Decimal.Parse(Strings.Mid(PrecioTemporal, 1, PrecioTemporal.Length() - 1) + ajusteA.ToString())
            End If
         End If
         If precioVentaNuevo <> 0 Then
            drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = precioVentaNuevo
         End If
      Next
   End Sub

   Private Sub RecalculaPreciosPorcActual(drPrecios As DataRow, txtPrecioCosto As Decimal)

      If Not String.IsNullOrEmpty(drPrecios(ListaPreciosColumns.PorcentajeCosto).ToString()) AndAlso Decimal.Parse(drPrecios(ListaPreciosColumns.PorcentajeCosto).ToString()) > 0 Then
         drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = txtPrecioCosto +
                                                                      (txtPrecioCosto * CDec(drPrecios(ListaPreciosColumns.PorcentajeCosto.ToString())) / 100)
      Else
         drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = 0
      End If

   End Sub

   Private Sub RecalculaPreciosSobreCosto(drPrecios As DataRow, txtPrecioCosto As Decimal)
      drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = txtPrecioCosto +
                                                              (txtPrecioCosto * CDec(drPrecios(ListaPreciosColumns.PorcentajeCalculado.ToString())) / 100)
   End Sub

   Private Sub RecalculaPreciosSobreVenta(drPrecios As DataRow)
      If Decimal.Parse(drPrecios(ListaPreciosColumns.PorcentajeCalculado.ToString()).ToString()) <> 0 Then
         drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = CDec(drPrecios(ListaPreciosColumns.PrecioVentaBase.ToString())) +
                                                                 (CDec(drPrecios(ListaPreciosColumns.PrecioVentaBase.ToString())) * CDec(drPrecios(ListaPreciosColumns.PorcentajeCalculado.ToString())) / 100)
      Else
         drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = Decimal.Parse(drPrecios(ListaPreciosColumns.PrecioVentaBase.ToString()).ToString())
      End If
   End Sub

   Private Sub RecalculaPreciosDesdeFormula(drPrecios As DataRow, IdProducto As String)
      Dim oProdComp As Reglas.ProductosComponentes = New Reglas.ProductosComponentes()

      Dim formula As Integer
      formula = New Reglas.Productos().GetUno(IdProducto).IdFormula

      Dim precioVenta As Decimal = oProdComp.GetPrecioVenta(actual.Sucursal.IdSucursal, IdProducto, formula, CInt(drPrecios(ListaPreciosColumns.IdListaPrecios.ToString())))
      Dim porcRecargo As Decimal = CDec(drPrecios(ListaPreciosColumns.PorcentajeCalculado.ToString()))
      If porcRecargo <> 0 Then
         drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = precioVenta + Decimal.Round(precioVenta * porcRecargo, 4)
      Else
         drPrecios(ListaPreciosColumns.PrecioVenta.ToString()) = precioVenta
      End If
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function Get1(idProducto As String) As DataTable
      Return New SqlServer.Productos(da).Productos_G1(idProducto, activo:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function

   Public Function GetAll_Ids() As DataTable
      Return GetAll_Ids(idProveedor:=0)
   End Function
   Public Function GetAll_Ids(idProveedor As Long) As DataTable
      Return New SqlServer.Productos(da).Productos_GA_Ids(idProveedor)
   End Function

   Public Function GetPorCodigo(idProducto As String,
                                idSucursal As Integer,
                                idListaPrecios As Integer,
                                modulo As String,
                                Optional soloCompuestos As Boolean = False,
                                Optional modalidad As String = "NORMAL",
                                Optional soloAlquilables As Boolean = False,
                                Optional tipoOperacion As Entidades.Producto.TiposOperaciones = Entidades.Producto.TiposOperaciones.NORMAL,
                                Optional publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros = Nothing,
                                Optional esObservacion As Boolean? = Nothing,
                                Optional permiteModificarDescripcion As Boolean? = Nothing,
                                Optional idRubro As Integer = 0,
                                Optional idCLiente As Long = 0,
                                Optional soloProductosConStock As Boolean = False,
                                Optional soloBuscaPorIdProducto As Boolean = False,
                                Optional idProveedor As Long = 0,
                                Optional SoloTipoCalidadCompras As Boolean = False,
                                Optional idMarca As Integer = 0) As DataTable

      Dim strAnchoIdProducto As String = New Reglas.Publicos().GetAnchoCampo("Productos", "IdProducto").ToString()
      Dim condicionParaCombinarCodigoNombre As String = " OR "

      'Para compensar que algunas lectoras no leen el ultimo digito.
      If Publicos.Facturacion.FacturacionIgnorarUltimoDigitoCB And idProducto.Length >= 10 And Publicos.ProductoUtilizaCodigoDeBarras Then
         idProducto = Strings.Left(idProducto, idProducto.Length - 1)
      End If

      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)

      Dim cotDolar = New Monedas(da).GetUna(Entidades.Moneda.Dolar).FactorConversion

      Dim dt As DataTable
      If Reglas.Publicos.ProductoBuscarPorCodigoExacto Then
         dt = sql.GetPorCodigoNombreParaBusquedas(idSucursal, idListaPrecios,
                                                  idProducto, True,
                                                  String.Empty, False,
                                                  condicionParaCombinarCodigoNombre,
                                                  modulo, soloCompuestos, modalidad,
                                                  soloAlquilables, tipoOperacion, publicarEn,
                                                  strAnchoIdProducto,
                                                  Publicos.ProductoCodigoQuitarBlancos,
                                                  Publicos.ProductoUtilizaCodigoDeBarras,
                                                  Publicos.ProductoUtilizaCodigoLargoProducto,
                                                  Publicos.ProductoFormatoLikeBuscarPorCodigoResuelto,
                                                  Publicos.ProductoFormatoLikeBuscarPorNombreResuelto,
                                                  Publicos.BuscaProductoPorProveedorHabitual,
                                                  Publicos.PreciosConIVA,
                                                  esObservacion, permiteModificarDescripcion, idRubro, idMarca,
                                                  busquedaPorCodigoProductoProveedor:=False,
                                                  idCliente:=idCLiente,
                                                  productosCliente:=Reglas.Publicos.ClienteMostrarProductosAsociados,
                                                  soloProductosConStock:=soloProductosConStock,
                                                  soloBuscaPorIdProducto:=soloBuscaPorIdProducto,
                                                  redondeoEnPreciosVenta:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio,
                                                  idProveedorDeCompra:=idProveedor,
                                                  soloCargaProductosDelProveedor:=Reglas.Publicos.ComprasSoloCargaProductosDelProveedor,
                                                  soloTipoCalidadCompras:=False,
                                                  cotDolar)

         'Si lo encontro o es Modalidad Peso (precio en el etiqueta, no puedo buscar en general)
         If dt.Rows.Count > 0 Or modalidad = "PESO" Then
            Return dt
         End If
      End If

      dt = sql.GetPorCodigoNombreParaBusquedas(idSucursal, idListaPrecios,
                                               idProducto, False,
                                               String.Empty, False,
                                               condicionParaCombinarCodigoNombre,
                                               modulo, soloCompuestos, modalidad,
                                               soloAlquilables, tipoOperacion, publicarEn,
                                               strAnchoIdProducto,
                                               Publicos.ProductoCodigoQuitarBlancos,
                                               Publicos.ProductoUtilizaCodigoDeBarras,
                                               Publicos.ProductoUtilizaCodigoLargoProducto,
                                               Publicos.ProductoFormatoLikeBuscarPorCodigoResuelto,
                                               Publicos.ProductoFormatoLikeBuscarPorNombreResuelto,
                                               Publicos.BuscaProductoPorProveedorHabitual,
                                               Publicos.PreciosConIVA,
                                               esObservacion, permiteModificarDescripcion, idRubro, idMarca,
                                               busquedaPorCodigoProductoProveedor:=False,
                                               idCliente:=idCLiente,
                                               productosCliente:=Reglas.Publicos.ClienteMostrarProductosAsociados,
                                               soloProductosConStock:=soloProductosConStock,
                                               soloBuscaPorIdProducto:=soloBuscaPorIdProducto,
                                               redondeoEnPreciosVenta:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio,
                                               idProveedorDeCompra:=idProveedor,
                                               soloCargaProductosDelProveedor:=Reglas.Publicos.ComprasSoloCargaProductosDelProveedor,
                                               soloTipoCalidadCompras:=False,
                                               cotDolar)

      Return dt

   End Function

   Public Function GetPorNombre(nombreProducto As String,
                                idSucursal As Integer,
                                idListaPrecios As Integer,
                                modulo As String,
                                Optional soloCompuestos As Boolean = False,
                                Optional soloAlquilables As Boolean = False,
                                Optional tipoOperacion As Entidades.Producto.TiposOperaciones = Entidades.Producto.TiposOperaciones.NORMAL,
                                Optional publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros = Nothing,
                                Optional esObservacion As Boolean? = Nothing,
                                Optional permiteModificarDescripcion As Boolean? = Nothing,
                                Optional idRubro As Integer = 0,
                                Optional idCliente As Long = 0,
                                Optional idProveedor As Long = 0,
                                Optional soloTipoCalidadCompras As Boolean = False,
                                Optional idMarca As Integer = 0) As DataTable

      Dim strAnchoIdProducto As String = New Reglas.Publicos().GetAnchoCampo("Productos", "IdProducto").ToString()
      Dim productoBusquedaCombinaCodigoNombre As Boolean = Publicos.ProductoBusquedaCombinaCodigoNombre
      Dim condicionParaCombinarCodigoNombre As String = " OR "

      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)

      Dim idProducto As String = String.Empty
      If productoBusquedaCombinaCodigoNombre Then
         idProducto = nombreProducto
      End If

      Dim cotDolar = New Monedas(da).GetUna(Entidades.Moneda.Dolar).FactorConversion

      Dim dt As DataTable
      dt = sql.GetPorCodigoNombreParaBusquedas(idSucursal, idListaPrecios,
                                               idProducto, False,
                                               nombreProducto, False,
                                               condicionParaCombinarCodigoNombre,
                                               modulo, soloCompuestos, "NORMAL",
                                               soloAlquilables, tipoOperacion, publicarEn,
                                               strAnchoIdProducto,
                                               Publicos.ProductoCodigoQuitarBlancos,
                                               Publicos.ProductoUtilizaCodigoDeBarras,
                                               Publicos.ProductoUtilizaCodigoLargoProducto,
                                               Publicos.ProductoFormatoLikeBuscarPorCodigoResuelto,
                                               Publicos.ProductoFormatoLikeBuscarPorNombreResuelto,
                                               Publicos.BuscaProductoPorProveedorHabitual,
                                               Publicos.PreciosConIVA,
                                               esObservacion, permiteModificarDescripcion, idRubro, idMarca,
                                               busquedaPorCodigoProductoProveedor:=False,
                                               idCliente:=idCliente,
                                               productosCliente:=Reglas.Publicos.ClienteMostrarProductosAsociados,
                                               soloProductosConStock:=False,
                                               soloBuscaPorIdProducto:=False,
                                               redondeoEnPreciosVenta:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio,
                                               idProveedorDeCompra:=idProveedor,
                                               soloCargaProductosDelProveedor:=Reglas.Publicos.ComprasSoloCargaProductosDelProveedor,
                                               soloTipoCalidadCompras:=soloTipoCalidadCompras,
                                               cotDolar)
      Return dt

   End Function

   Public Function GetPorCodigoTodos(codigo As String, sucursal As Integer, idListaPrecios As Integer) As DataTable

      Dim strAnchoIdProducto As String = New Reglas.Publicos().GetAnchoCampo("Productos", "IdProducto").ToString()
      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA
      Dim srtCatFiscalEmp As Short = Publicos.CategoriaFiscalEmpresa
      Dim redondeo As Integer = Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio

      Dim stb = New StringBuilder()
      With stb

         If Publicos.ProductoCodigoQuitarBlancos Then
            .AppendFormat("SELECT P.IdProducto as IdProducto,")
         Else
            .AppendFormat("SELECT RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto,", strAnchoIdProducto)
         End If

         .AppendLine("	P.NombreProducto,")
         .AppendLine("	P.NombreCorto,")
         .AppendLine("	P.Tamano,")
         .AppendLine("	P.IdUnidadDeMedida,")
         .AppendLine("	PS.PrecioFabrica,")
         .AppendLine("	PS.PrecioCosto,")

         .AppendLine("	PSP.PrecioVenta,")

         If blnPreciosConIVA Then
            .AppendFormat(" ROUND({0}, {1}) AS PrecioVentaSinIVA,",
                          SqlServer.CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), 2).AppendLine()
            .AppendLine("	PSP.PrecioVenta as PrecioVentaConIVA,")
         Else
            .AppendLine("	PSP.PrecioVenta as PrecioVentaSinIVA,")
            .AppendFormat(" ROUND({0}, {1}) AS PrecioVentaConIVA,",
                          SqlServer.CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), 2).AppendLine()
         End If
         .AppendLine(" P.Alicuota2,")
         .AppendLine("	PS.Stock,")
         .AppendLine("	PS.StockInicial,")
         .AppendLine("	P.IdMarca,")
         .AppendLine("	P.IdModelo,")
         .AppendLine("	P.IdRubro,")
         .AppendLine("	P.IdSubRubro,")
         .AppendLine("	P.MesesGarantia,")
         .AppendLine("	P.IdTipoImpuesto,")
         .AppendLine("	P.AfectaStock,")
         .AppendLine("	P.CodigoDeBarras,")
         .AppendLine("	P.EsServicio,")
         .AppendLine("	P.PublicarEnWeb,")
         .AppendLine("	P.PublicarListaDePreciosClientes,")

         .AppendLine("	P.PublicarEnTiendaNube,")
         .AppendLine("	P.PublicarEnMercadoLibre,")
         .AppendLine("	P.PublicarEnArborea,")
         .AppendLine("	P.PublicarEnGestion,")
         .AppendLine("	P.PublicarEnEmpresarial,")
         .AppendLine("	P.PublicarEnBalanza,")
         .AppendLine("	P.PublicarEnSincronizacionSucursal,")

         .AppendLine("	P.Observacion")
         .AppendLine("	,P.EquipoMarca")
         .AppendLine("	,P.EquipoModelo")
         .AppendLine("	,P.NumeroSerie")
         .AppendLine("	,P.CaractSII")
         .AppendLine("	,P.Anio")
         .AppendLine("	,P.Kilos")
         .AppendLine("  ,P.KilosEsUMCompras")
         .AppendLine("	,P.FacturacionCantidadNegativa")
         .AppendLine("	,P.SolicitaEnvase")
         .AppendLine("	,P.AlertaDeCaja")
         .AppendLine("  ,P.EsObservacion")
         .AppendLine("  ,P.IdCuentaCompras")
         .AppendLine("  ,CCC.NombreCuenta AS NombreCuentaCompras")
         .AppendLine("  ,P.IdCuentaVentas")
         .AppendLine("  ,CCV.NombreCuenta AS NombreCuentaVentas")
         .AppendLine("  ,P.ImporteImpuestoInterno")
         .AppendLine("  ,P.PorcImpuestoInterno")
         .AppendLine("  ,P.OrigenPorcImpInt")
         .AppendLine("  ,P.EsOferta")
         .AppendLine("  ,P.IdCuentaComprasSecundaria")
         .AppendLine("  ,CCCS.NombreCuenta AS NombreCuentaComprasSecundaria")
         .AppendLine("  ,P.IncluirExpensas")
         .AppendLine("      ,P.IdCentroCosto")
         .AppendLine("      ,CECO.NombreCentroCosto")
         .AppendLine("  ,P.ObservacionCompras")
         .AppendLine("  ,P.SolicitaPrecioVentaPorTamano")
         .AppendLine("      ,P.Espmm")
         .AppendLine("      ,P.EspPulgadas")
         .AppendLine("      ,P.CodigoSAE")
         .AppendLine("      ,P.IdProduccionProceso")
         .AppendLine("      ,P.IdProduccionForma")
         .AppendLine("      ,P.PorcImpuestoInterno")
         .AppendLine("      ,P.OrigenPorcImpInt")
         .AppendLine("      ,PRP.NombreProduccionProceso")
         .AppendLine("      ,PRF.NombreProduccionForma")
         .AppendLine("      ,P.CalculaPreciosSegunFormula")

         .AppendLine("      ,P.IdSubSubRubro")
         .AppendLine("      ,SSR.NombreSubSubRubro")

         .AppendLine("      ,P.EsCambiable")
         .AppendLine("      ,P.EsBonificable")
         .AppendLine("      ,P.DescRecProducto")
         .AppendLine("      ,P.ActualizaPreciosSucursalesAsociadas")
         .AppendLine("      ,P.IdUnidadDeMedida2")
         .AppendLine("      ,P.Conversion")
         .AppendLine("      ,P.IdVarianteProducto")
         .AppendLine("      ,P.TipoBonificacion")
         .AppendLine("  FROM Productos P")
         .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto")
         .AppendLine("   LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
         .AppendLine(" LEFT JOIN ContabilidadCuentas CCC ON CCC.IdCuenta = P.IdCuentaCompras")
         .AppendLine(" LEFT JOIN ContabilidadCuentas CCV ON CCV.IdCuenta = P.IdCuentaVentas")
         .AppendLine(" LEFT JOIN ContabilidadCuentas CCCS ON CCCS.IdCuenta = P.IdCuentaComprasSecundaria")
         .AppendLine(" LEFT JOIN ContabilidadCentrosCostos CECO ON CECO.IdCentroCosto = P.IdCentroCosto")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" LEFT JOIN SubRubros SR ON P.IdRubro = SR.IdRubro AND P.IdSubRubro = SR.IdSubRubro")
         .AppendLine(" LEFT JOIN SubSubRubros SSR ON P.IdSubRubro = SSR.IdSubRubro AND P.IdSubSubRubro = SSR.IdSubSubRubro")
         .AppendLine(" LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = P.IdProduccionForma")
         .AppendLine(" LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = P.IdProduccionProceso")

         '.AppendFormat("	WHERE P.IdProducto LIKE '%{0}%'", codigo)
         .AppendFormat("	WHERE P.IdProducto = '{0}'", codigo)
         .AppendFormat("	  AND PS.IdSucursal = {0}", sucursal)
         '.AppendLine("	AND P.Activo = 1")   'Solo permito elegir los productos Activos
         .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)
         .AppendLine("	ORDER BY P.NombreProducto")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetStocksParaActualizar(Sucursales() As Integer,
                                             Listas As List(Of Entidades.ListaDePrecios),
                                             Marcas As List(Of Entidades.Marca),
                                             Rubros As List(Of Entidades.Rubro),
                                             IdSubRubro As Integer,
                                             IdProducto As String,
                                             IdProveedor As Long,
                                             Compuestos As String) As DataTable
      Dim oPublicos As New Reglas.Publicos
      Dim strAnchoIdProducto As String

      strAnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto").ToString()

      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT S.IdSucursal	  ")
         .AppendLine("		,S.Nombre NombreSucursal	  ")
         .AppendFormat("		,RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto      ", strAnchoIdProducto)
         .AppendLine("		,P.NombreProducto      ")
         .AppendLine("	,P.NombreCorto")
         .AppendLine("		,P.Tamano	  ")
         .AppendLine("		,P.IdMarca	  ")
         .AppendLine("		,M.NombreMarca      ")
         .AppendLine("		,P.IdRubro	  ")
         .AppendLine("		,R.NombreRubro      ")
         .AppendLine("		,P.IdUnidadDeMedida      ")
         .AppendLine("		,P.Alicuota")
         .AppendLine("		,Mo.Simbolo")
         .AppendLine("		,PS.Stock  ")
         .AppendLine("		,P.EsCompuesto")
         .AppendLine(" FROM Productos P	")
         .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto	")
         .AppendLine("	LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal	")
         .AppendLine("	LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca	")
         .AppendLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro	")

         If IdProveedor > 0 Then
            .AppendLine("	LEFT JOIN ProductosProveedores PP ON P.IdProducto = PP.IdProducto")
         End If

         .AppendLine("	WHERE PS.IdSucursal in (0")
         For Each suc As Integer In Sucursales
            If Integer.Parse(suc.ToString()) <> 0 Then
               .AppendLine("," & suc.ToString())
            End If
         Next
         .AppendLine(") ")
         .AppendLine("	AND P.Activo = 'True'")   'Solo permito elegir los productos Activos

         If Marcas.Count > 0 Then
            .Append(" AND P.IdMarca IN (")
            For Each pr As Entidades.Marca In Marcas
               .AppendFormat(" {0},", pr.IdMarca)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If Rubros.Count > 0 Then
            .Append(" AND P.IdRubro IN (")
            For Each pr As Entidades.Rubro In Rubros
               .AppendFormat(" {0},", pr.IdRubro)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If IdSubRubro <> 0 Then
            .AppendLine("	AND P.IdSubRubro = " & IdSubRubro.ToString())
         End If

         If Not String.IsNullOrEmpty(IdProducto) Then
            .AppendLine("	AND P.IdProducto = '" & IdProducto & "'")
         End If

         If IdProveedor > 0 Then
            .AppendLine("	AND PP.IdProveedor = " & IdProveedor.ToString())
         End If

         If Compuestos <> "TODOS" Then
            .AppendLine("      AND P.EsCompuesto = " & IIf(Compuestos = "SI", "1", "0").ToString())
         End If

         .AppendLine("	ORDER BY P.NombreProducto")

      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetStockParaActualizar(sucursales As Integer, deposito As Integer,
                                          listas As List(Of Entidades.ListaDePrecios),
                                          marcas As Entidades.Marca(),
                                          rubros As Entidades.Rubro(),
                                          idSubRubro As Integer,
                                          idProducto As String,
                                          idProveedor As Long,
                                          sinCosto As Boolean,
                                          sinVenta As Boolean,
                                          compuestos As String,
                                          fechaActualizadoDesde As Date,
                                          fechaActualizadoHasta As Date,
                                          codigoProducto As String,
                                          nombreProducto As String,
                                          idListaPrecios As Integer,
                                          atributo As Boolean) As DataTable

      Dim strAnchoIdProducto = New Publicos().GetAnchoCampo("Productos", "IdProducto")
      Return New SqlServer.Productos(da).GetStockParaActualizar(sucursales, deposito,
                                                                listas,
                                                                marcas,
                                                                rubros,
                                                                idSubRubro,
                                                                idProducto,
                                                                idProveedor,
                                                                sinCosto,
                                                                sinVenta,
                                                                compuestos,
                                                                fechaActualizadoDesde,
                                                                fechaActualizadoHasta,
                                                                codigoProducto,
                                                                nombreProducto,
                                                                idListaPrecios,
                                                                strAnchoIdProducto,
                                                                atributo)

   End Function
   Public Function GetStockMinimoParaActualizar(sucursales() As Integer,
                                          listas As List(Of Entidades.ListaDePrecios),
                                          marcas As List(Of Entidades.Marca),
                                          rubros As List(Of Entidades.Rubro),
                                          idSubRubro As Integer,
                                          idProducto As String,
                                          idProveedor As Long,
                                          sinCosto As Boolean,
                                          sinVenta As Boolean,
                                          compuestos As String,
                                          fechaActualizadoDesde As Date,
                                          fechaActualizadoHasta As Date,
                                          codigoProducto As String,
                                          nombreProducto As String,
                                          idListaPrecios As Integer,
                                          conStock As String,
                                          atributo As Boolean) As DataTable

      Dim strAnchoIdProducto = New Publicos().GetAnchoCampo("Productos", "IdProducto")
      Return New SqlServer.Productos(da).GetStockMinimoParaActualizar(sucursales,
                                                                listas,
                                                                marcas,
                                                                rubros,
                                                                idSubRubro,
                                                                idProducto,
                                                                idProveedor,
                                                                sinCosto,
                                                                sinVenta,
                                                                compuestos,
                                                                fechaActualizadoDesde,
                                                                fechaActualizadoHasta,
                                                                codigoProducto,
                                                                nombreProducto,
                                                                idListaPrecios,
                                                                conStock,
                                                                strAnchoIdProducto,
                                                                atributo)

   End Function
   Public Function GetProductoParaAplicarDescuentosClientes(idCliente As Long,
                                                            Marcas As List(Of Entidades.Marca),
                                                         Rubros As List(Of Entidades.Rubro),
                                                     IdSubRubro As Integer,
                                                     IdProducto As String,
                                                     IdProveedor As Long,
                                                     Compuestos As String,
                                                     CodigoProducto As String,
                                                     NombreProducto As String,
                                                     Habitual As Boolean,
                                                     EsOferta As String,
                                                     codigoProductoProveedor As String) As DataTable
      Try
         Me.da.OpenConection()

         Dim sqlPro As SqlServer.Productos

         sqlPro = New SqlServer.Productos(da)

         Return sqlPro.GetProductoParaAplicarDescuentosClientes(idCliente, Marcas, Rubros,
                                                                IdSubRubro, IdProducto, IdProveedor,
                                                                Compuestos,
                                                                CodigoProducto, NombreProducto, Habitual, EsOferta, codigoProductoProveedor)


      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetProductosParaActualizarPrecios(Sucursales() As Integer,
                                                     Listas As List(Of Entidades.ListaDePrecios),
                                                     Marcas As Entidades.Marca(),
                                                     Rubros As Entidades.Rubro(),
                                                     IdSubRubro As Integer,
                                                     IdProducto As String,
                                                     IdProveedor As Long,
                                                     SinCosto As Boolean,
                                                     SinVenta As Boolean,
                                                     Compuestos As String,
                                                     FechaActualizadoDesde As Date, FechaActualizadoHasta As Date,
                                                     CodigoProducto As String,
                                                     NombreProducto As String,
                                                     Habitual As Boolean,
                                                     EsOferta As String,
                                                     codigoProductoProveedor As String,
                                                     arrProductos As Entidades.Producto()) As DataTable

      Dim oPublicos As New Reglas.Publicos
      Dim strAnchoIdProducto As String

      strAnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto").ToString()

      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT Cast(1 as bit) as Sel, S.IdSucursal	  ")
         .AppendLine("		,S.Nombre NombreSucursal	  ")
         .AppendFormat("		,RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto      ", strAnchoIdProducto)
         .AppendLine("		,P.IdProducto IdProductoSinEspacios")
         .AppendLine("     ,PP.CodigoProductoProveedor")
         .AppendLine("		,P.NombreProducto      ")
         .AppendLine("	,P.NombreCorto")
         .AppendLine("		,P.Tamano	  ")
         .AppendLine("		,P.IdMarca	  ")
         .AppendLine("		,M.NombreMarca      ")
         .AppendLine("		,P.IdRubro	  ")
         .AppendLine("		,R.NombreRubro      ")
         .AppendLine("		,P.IdUnidadDeMedida      ")
         .AppendLine("		,P.Alicuota")
         .AppendLine("		,Mo.Simbolo")
         .AppendLine("     ,EsOferta")
         .AppendLine("		,PS.PrecioFabrica      ")
         .AppendLine("     ,P.IdProveedor")
         .AppendLine("   	,PRO.NombreProveedor")
         .AppendLine("   	,PP.DescuentoRecargoPorc1")
         .AppendLine(" 		,PP.DescuentoRecargoPorc2")
         .AppendLine(" 		,PP.DescuentoRecargoPorc3")
         .AppendLine(" 		,PP.DescuentoRecargoPorc4")
         .AppendLine("		,PS.PrecioCosto      ")
         '.AppendLine("		,(CASE WHEN PS.PrecioCosto>0 THEN round((PS.PrecioVenta/PS.PrecioCosto-1) * 100,4) ELSE 0 END) AS Porc")
         '.AppendLine("		,PS.PrecioVenta ")
         .AppendLine("		,PS.FechaActualizacion")

         If Listas IsNot Nothing Then
            For Each lis As Entidades.ListaDePrecios In Listas
               .AppendFormat("		,(CASE WHEN PS.PrecioCosto>0 THEN round((L.[{0}]/PS.PrecioCosto-1) * 100,4) ELSE 0 END) AS Porc" & lis.IdListaPrecios, lis.NombreListaPrecios)
               .AppendFormat("		,L.[{0}]", lis.NombreListaPrecios)
            Next
         End If

         .AppendLine("		,PS.Stock  ")
         .AppendLine("		,P.EsCompuesto")

         .AppendLine(",( SELECT TOP 1 PR.NombreProveedor  FROM ProductosProveedores PP")
         .AppendLine("   INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor ")
         .AppendLine("   WHERE PP.IdProducto = P.IdProducto ")
         .AppendLine("   ORDER BY PP.UltimaFechaCompra desc) as UltimoProv")

         .AppendLine(" FROM Productos P	")
         .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto	")
         .AppendLine("	LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal	")
         .AppendLine("	LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca	")
         .AppendLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro	")
         .AppendLine("	LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto")
         If IdProveedor > 0 Then
            .AppendLine("   AND PP.IdProveedor = " + IdProveedor.ToString())
         Else
            .AppendLine("   AND PP.IdProveedor = P.IdProveedor")
         End If
         .AppendLine(" 	LEFT JOIN Proveedores PRO ON PRO.IdProveedor = P.IdProveedor ")
         If Listas IsNot Nothing AndAlso Listas.Count > 0 Then
            .Append("	LEFT JOIN (SELECT IdProducto, IdSucursal,")
            For Each lis As Entidades.ListaDePrecios In Listas
               .AppendFormat(" [{0}] as '{1}',", lis.IdListaPrecios, lis.NombreListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(" FROM ")
            .AppendLine("(")
            .AppendLine("    SELECT psp.IdProducto, psp.IdSucursal,  psp.IdListaPrecios, psp.PrecioVenta")
            .AppendLine("		FROM ProductosSucursalesPrecios psp")
            .AppendLine(") as t ")
            .AppendLine("pivot ")
            .AppendLine("(")
            .AppendLine("    sum(t.PrecioVenta) for IdListaPrecios in (")
            For Each lis As Entidades.ListaDePrecios In Listas
               .AppendFormat("[{0}],", lis.IdListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
            .AppendLine(") as p) AS L ON L.IdProducto = P.IdProducto and L.IdSucursal = PS.IdSucursal")
         End If

         If IdProveedor > 0 And Not Habitual Then
            ' .AppendLine("	LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto ")
            .AppendLine("	LEFT JOIN Proveedores PV ON PP.IdProveedor = PV.IdProveedor")
         End If

         .AppendLine("	WHERE PS.IdSucursal in (0")
         For Each suc As Integer In Sucursales
            If Integer.Parse(suc.ToString()) <> 0 Then
               .AppendLine("," & suc.ToString())
            End If
         Next
         .AppendLine(") ")
         .AppendLine("	AND P.Activo = 'True'")   'Solo permito elegir los productos Activos

         SqlServer.Comunes.GetListaMarcasMultiples(stb, Marcas, "P")
         'If Marcas.Count > 0 Then
         '   .Append(" AND P.IdMarca IN (")
         '   For Each pr As Entidades.Marca In Marcas
         '      .AppendFormat(" {0},", pr.IdMarca)
         '   Next
         '   .Remove(.Length - 1, 1)
         '   .Append(")")
         'End If

         SqlServer.Comunes.GetListaRubrosMultiples(stb, Rubros, "P")
         'If Rubros.Count > 0 Then
         '   .Append(" AND P.IdRubro IN (")
         '   For Each pr As Entidades.Rubro In Rubros
         '      .AppendFormat(" {0},", pr.IdRubro)
         '   Next
         '   .Remove(.Length - 1, 1)
         '   .Append(")")
         'End If

         If IdSubRubro <> 0 Then
            .AppendLine("	AND P.IdSubRubro = " & IdSubRubro.ToString())
         End If

         If Not String.IsNullOrEmpty(IdProducto) Then
            .AppendLine("	AND P.IdProducto = '" & IdProducto & "'")
         End If

         SqlServer.Comunes.GetListaMultiples(stb, arrProductos, "P")

         If IdProveedor > 0 And Not Habitual Then
            .AppendLine("	AND PV.IdProveedor = " & IdProveedor.ToString())
         End If

         If SinCosto Then
            .AppendLine("	AND PS.PrecioCosto = 0")
         End If

         If SinVenta Then
            'Controlo que alguno de los precios de venta este en cero, para eso multiplico los valores y si dan cero es porque alguna de las listas esta en cero
            .Append(" AND (")
            For Each lis As Entidades.ListaDePrecios In Listas
               .AppendFormat("L.[{0}]*", lis.NombreListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .Append(") = 0")
            '---------------
         End If

         If Compuestos <> "TODOS" Then
            .AppendLine("      AND P.EsCompuesto = " & IIf(Compuestos = "SI", "1", "0").ToString())
         End If

         'Por ahora filtra de la lista BASE, pero deberia ser dinamico.
         If FechaActualizadoDesde.Year > 1 Then
            .AppendLine("	 AND PS.FechaActualizacion >= '" & FechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND PS.FechaActualizacion <= '" & FechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If Not String.IsNullOrEmpty(NombreProducto) Then
            Dim formatoLike As String = Publicos.ProductoFormatoLikeBuscarPorNombreResuelto
            'Si contiene espacio hago una busqueda por cada palabra
            If Not NombreProducto.Contains(" ") Then
               .AppendFormatLine("   AND P.NombreProducto LIKE '{0}'", String.Format(formatoLike, NombreProducto))
            Else
               Dim Palabras() As String = NombreProducto.Split(" "c)

               .Append("   AND ( 1=1 ")
               For Each Palabra As String In Palabras
                  .AppendFormatLine("   AND P.NombreProducto LIKE '{0}'", String.Format(formatoLike, Palabra))
               Next

               .AppendLine("  )")
            End If
         End If

         If Not String.IsNullOrEmpty(CodigoProducto) Then
            Dim formatoLike As String = Publicos.ProductoFormatoLikeBuscarPorCodigoResuelto
            .AppendFormatLine("	AND P.IdProducto LIKE '{0}'", String.Format(formatoLike, CodigoProducto))
         End If


         If Habitual Then
            .AppendLine("   AND P.IdProveedor = " & IdProveedor.ToString())
         End If

         If EsOferta <> "TODOS" Then
            .AppendLine(" AND P.EsOferta = '" & EsOferta & "' ")
         End If

         If Not String.IsNullOrWhiteSpace(codigoProductoProveedor) Then
            .AppendLine(" AND PP.CodigoProductoProveedor LIKE '%" & codigoProductoProveedor & "%' ")
         End If

         .AppendLine("	ORDER BY P.NombreProducto")

      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetProductosParaActualizarPrecios2(sucursales() As Integer,
                                                      listas As List(Of Entidades.ListaDePrecios),
                                                      marcas As Entidades.Marca(),
                                                      rubros As Entidades.Rubro(),
                                                      subRubros As Entidades.SubRubro(),
                                                      subSubRubros As Entidades.SubSubRubro(),
                                                      idProducto As String,
                                                      idProveedor As Long,
                                                      sinCosto As Boolean,
                                                      sinVenta As Boolean,
                                                      compuestos As String,
                                                      fechaActualizadoDesde As Date, FechaActualizadoHasta As Date,
                                                      codigoProducto As String,
                                                      nombreProducto As String,
                                                      habitual As Boolean,
                                                      esOferta As String,
                                                      codigoProductoProveedor As String,
                                                      arrProductos As Entidades.Producto(),
                                                      idMoneda As Integer, conStock As Entidades.Publicos.SiNoTodos) As DataTable
      Dim strAnchoIdProducto As String
      strAnchoIdProducto = New Reglas.Publicos().GetAnchoCampo("Productos", "IdProducto").ToString()

      Dim dt = New SqlServer.Productos(da).GetProductosParaActualizarPrecios2(sucursales, listas,
                                                                            marcas, rubros, subRubros, subSubRubros,
                                                                            idProducto, idProveedor,
                                                                            sinCosto, sinVenta,
                                                                            compuestos,
                                                                            fechaActualizadoDesde, FechaActualizadoHasta,
                                                                            codigoProducto, nombreProducto,
                                                                            habitual,
                                                                            esOferta,
                                                                            codigoProductoProveedor,
                                                                            arrProductos,
                                                                            strAnchoIdProducto,
                                                                            Publicos.ProductoFormatoLikeBuscarPorCodigoResuelto,
                                                                            Publicos.ProductoFormatoLikeBuscarPorNombreResuelto,
                                                                            idMoneda, conStock)
      dt.Columns.Add("___ColumnasActualizadasPorImportacion", GetType(Object))
      Return dt
   End Function

   Public Function GetPreciosListasMultiples(sucursales() As Integer,
                                                marca As Integer,
                                                rubro As Integer,
                                                subRubro As Integer,
                                                producto As String,
                                                sinCosto As Boolean,
                                                sinVenta As Boolean,
                                                listas As List(Of Entidades.ListaDePrecios),
                                                costo As Boolean,
                                                stock As Boolean,
                                                idMoneda As Integer,
                                                tipoCambio As Decimal,
                                                idProveedor As Long,
                                                conIVA As Boolean,
                                                mostrarProveedorHabitual As Boolean) As DataTable
      Dim oPublicos As New Reglas.Publicos()
      Dim strAnchoIdProducto As String
      strAnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto").ToString()

      Dim dt As DataTable
      dt = New SqlServer.Productos(da).GetPreciosListasMultiples(sucursales,
                                                                 marca,
                                                                 rubro,
                                                                 subRubro,
                                                                 producto,
                                                                 sinCosto,
                                                                 sinVenta,
                                                                 listas,
                                                                 costo,
                                                                 stock,
                                                                 idMoneda,
                                                                 tipoCambio,
                                                                 Publicos.ConsultarPreciosOcultarProdNoAfectanStock,
                                                                 strAnchoIdProducto,
                                                                 idProveedor,
                                                                 conIVA, Publicos.PreciosConIVA,
                                                                 mostrarProveedorHabitual)
      For Each dc As DataColumn In dt.Columns
         If dc.ColumnName.StartsWith("pv_") Or dc.ColumnName.StartsWith("fa_") Then
            For Each lis As Entidades.ListaDePrecios In listas
               If dc.ColumnName.Equals(String.Format("pv_{0}", lis.IdListaPrecios)) Then
                  dc.Caption = String.Format("Precio {0}", lis.NombreListaPrecios)
               End If
               If dc.ColumnName.Equals(String.Format("fa_{0}", lis.IdListaPrecios)) Then
                  dc.Caption = String.Format("F.Act. {0}", lis.NombreListaPrecios)
               End If
            Next
         End If
         If dc.ColumnName.StartsWith("dr_") Then
            dc.Caption = String.Format("%")
         End If
      Next
      Return dt
   End Function

   Public Function GetPreciosListasParaClientes(agruparPor As String,
                                                ordenarPor As String,
                                                sucursales As Entidades.Sucursal(),
                                                idListaPrecios As Integer,
                                                marcas As Entidades.Marca(),
                                                rubros As Entidades.Rubro(),
                                                subRubros As Entidades.SubRubro(),
                                                subSubRubros As Entidades.SubSubRubro(),
                                                idProducto As String,
                                                conPrecio As Boolean,
                                                conStock As Boolean,
                                                idMoneda As Integer,
                                                tipoCambio As Decimal,
                                                esOferta As String,
                                                idProductoLibre As String,
                                                nombreProductoLibre As String,
                                                FechaActualizadoDesde As Date,
                                                FechaActualizadoHasta As Date,
                                                IdCliente As Long,
                                                filtrosPublicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As DataTable
      Return New SqlServer.Productos(da).GetPreciosListasParaClientes(agruparPor,
                                                                      ordenarPor,
                                                                      sucursales,
                                                                      idListaPrecios,
                                                                      marcas,
                                                                      rubros,
                                                                      subRubros,
                                                                      subSubRubros,
                                                                      idProducto,
                                                                      conPrecio,
                                                                      conStock,
                                                                      idMoneda,
                                                                      tipoCambio,
                                                                      esOferta,
                                                                      idProductoLibre,
                                                                      nombreProductoLibre,
                                                                      GetParametrosGetPrecios(),
                                                                      FechaActualizadoDesde,
                                                                      FechaActualizadoHasta,
                                                                      IdCliente,
                                                                      filtrosPublicarEn)
   End Function

   Private Function GetParametrosGetPrecios() As SqlServer.Productos.ParametrosGetPrecios
      Return New SqlServer.Productos.ParametrosGetPrecios(Publicos.PreciosConIVA,
                                                          Publicos.ProductoEmbalajeHaciaArriba,
                                                          Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio,
                                                          Publicos.ProductoUtilizaCodigoDeBarras,
                                                          Publicos.ProductoFormatoLikeBuscarPorCodigoResuelto,
                                                          Publicos.ProductoFormatoLikeBuscarPorNombreResuelto,
                                                          Publicos.ProductoUtilizaCodigoLargoProducto,
                                                          Publicos.ConsultarPreciosOcultarProdNoAfectanStock,
                                                          Publicos.ProductoCodigoNumerico)
   End Function

   Public Function GetPrecios(sucursales As List(Of Entidades.Sucursal), idListaPrecios As Integer,
                              marcas As List(Of Entidades.Marca), modelos As List(Of Entidades.Modelo),
                              rubros As List(Of Entidades.Rubro), subRubros As List(Of Entidades.SubRubro), subSubRubros As List(Of Entidades.SubSubRubro),
                              idProducto As String, nombreProducto As String,
                              conPrecio As Boolean, conStock As Boolean, incluirInactivos As Boolean, embalaje As Boolean,
                              esOferta As String, esDeVentas As String, esDeCompras As String,
                              idMoneda As Integer, tipoCambio As Decimal, afectaStock As String) As DataTable
      'Para compensar que algunas lectoras no leen el ultimo digito.
      If idProducto.Length >= 10 AndAlso Publicos.ProductoUtilizaCodigoDeBarras AndAlso Publicos.Facturacion.FacturacionIgnorarUltimoDigitoCB Then
         idProducto = Strings.Left(idProducto, idProducto.Length - 1)
      End If
      Return New SqlServer.Productos(da).GetPrecios(sucursales, idListaPrecios,
                                                    marcas, modelos, rubros, subRubros, subSubRubros,
                                                    idProducto, nombreProducto,
                                                    conPrecio, conStock, incluirInactivos, embalaje,
                                                    esOferta, esDeVentas, esDeCompras,
                                                    idMoneda, tipoCambio,
                                                    GetParametrosGetPrecios(),
                                                    Publicos.BuscaProductoPorProveedorHabitual, afectaStock)
   End Function

   '-- REQ-32953.- --------------------------------------------------------------------------
   Public Function GetTipoBonificacion() As DataTable
      Return New SqlServer.Productos(da).GetTipoBonificacion()
   End Function

   Public Function GetStockPorProducto(idProducto As String) As DataTable
      Return New SqlServer.Productos(da).GetStockPorProducto(idProducto, actual.Sucursal.IdSucursalAsociada)
   End Function

   Public Function GetPreciosSoloPorCodigoLista(idSucursal As Integer, idProducto As String, idListaPrecios As Integer?, activo As Boolean?) As DataTable
      Return New SqlServer.Productos(da).GetPreciosSoloPorCodigoLista(idSucursal, idProducto, idListaPrecios, activo, GetParametrosGetPrecios())
   End Function
   ''' <summary>
   ''' Obtienen para un producto con atributos si tiene movimientos de compras-ventas.- 
   ''' </summary>
   ''' <param name="idProductos">Id de Producto</param>
   ''' <returns></returns>
   Public Function AtributoProductoMovimiento(idProductos As String) As Integer
      Dim sql = New SqlServer.Productos(da)
      Return sql.AtributoProductoMovimiento(idProductos).Rows.Count
   End Function
   Public Function GetPreciosPorLista(marca As Integer,
                                       rubro As Integer,
                                       producto As String,
                                       sucursales() As Integer,
                                       listas As List(Of Entidades.ListaDePrecios)) As DataTable

      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT PS.IdSucursal")
         .AppendLine("		,P.IdProducto")
         .AppendLine("		,P.NombreProducto")
         .AppendLine("	,P.NombreCorto")
         .AppendLine("		,P.Tamano")
         .AppendLine("		,P.IdUnidadDeMedida")
         .AppendLine("		,P.IdMarca")
         .AppendLine("		,P.IdModelo")
         .AppendLine("		,P.IdRubro")
         .AppendLine("		,P.IdSubRubro")
         .AppendLine("		,P.MesesGarantia")
         .AppendLine("		,P.IdTipoImpuesto")
         .AppendLine("		,P.Alicuota")
         .AppendLine("		,P.AfectaStock")
         .AppendLine("		,PS.PrecioFabrica")
         .AppendLine("		,PS.PrecioCosto")
         '.AppendLine("		,PS.PrecioVenta AS VentaLista0")
         For Each lis As Entidades.ListaDePrecios In listas
            .AppendFormat("		,L.VentaLista{0}", lis.IdListaPrecios)
         Next
         .AppendLine("		,PS.Stock  ")
         .AppendLine(" FROM Productos P	")
         .AppendLine("	LEFT JOIN ProductosSucursales PS ")
         .AppendLine("			ON P.IdProducto = PS.IdProducto	")
         If listas.Count > 0 Then
            .Append("	LEFT JOIN (SELECT IdProducto, IdSucursal,")
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormat(" [{0}] as VentaLista{1},", lis.IdListaPrecios, lis.IdListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(" FROM ")
            .AppendLine("(")
            .AppendLine("    SELECT psp.IdProducto, psp.IdSucursal,  psp.IdListaPrecios, psp.PrecioVenta ")
            .AppendLine("		FROM ProductosSucursalesPrecios psp")
            .AppendLine(") as t ")
            .AppendLine("pivot ")
            .AppendLine("(")
            .AppendLine("    sum(t.PrecioVenta) for IdListaPrecios in (")
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormat("[{0}],", lis.IdListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
            .AppendLine(") as p) AS L ON L.IdProducto = P.IdProducto and L.IdSucursal = PS.IdSucursal")
         End If
         .AppendLine("	WHERE PS.IdSucursal in (0")
         For Each suc As Integer In sucursales
            If Integer.Parse(suc.ToString()) <> 0 Then
               .AppendLine("," & suc.ToString())
            End If
         Next
         .AppendLine(") ")

         .AppendLine("	AND P.Activo = 'True'")   'Solo permito elegir los productos Activos

         If Not String.IsNullOrEmpty(producto) Then
            .AppendLine("	AND P.IdProducto = '" & producto & "'")
         End If
         If marca <> 0 Then
            .AppendLine("	AND P.IdMarca = " & marca.ToString())
         End If
         If rubro <> 0 Then
            .AppendLine("	AND P.IdRubro = " & rubro.ToString())
         End If
         .AppendLine("	ORDER BY P.NombreProducto")

      End With
      Return Me.da.GetDataTable(stb.ToString())
   End Function

   Public Function GetPreciosParaConsultaPorCuotaPorListaPrecios(idSucursal As Integer, idProducto As String) As DataTable
      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA
      Dim blnProductoUtilizaPrecioBarra As Boolean = Publicos.ProductoUtilizaCodigoDeBarras
      Dim decimales As Integer = Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
      Return New SqlServer.Productos(da).GetPreciosParaConsultaPorCuotaPorListaPrecios(idSucursal, idProducto,
                                                                                       blnPreciosConIVA, blnProductoUtilizaPrecioBarra, decimales)
   End Function

   Public Function GetPreciosParaConsultaPorCuotaPorFormaPago(idSucursal As Integer, idProducto As String, idListaPrecios As Integer, categoria As Entidades.Categoria) As DataTable
      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA
      Dim blnProductoUtilizaPrecioBarra As Boolean = Publicos.ProductoUtilizaCodigoDeBarras
      Dim decimales As Integer = Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
      Dim dtResult As DataTable
      dtResult = New SqlServer.Productos(da).GetPreciosParaConsultaPorCuotaPorFormaPago(idSucursal, idProducto, idListaPrecios,
                                                                                        blnPreciosConIVA, blnProductoUtilizaPrecioBarra, decimales)

      Dim rFichas As Ventas.Fichas = New Ventas.Fichas()
      For Each drResult As DataRow In dtResult.Rows
         Dim calcInt As Ventas.Fichas.CalcularInteresesResult
         Dim calcCuota As Ventas.Fichas.CalcularImporteCuotaResult
         Dim idFormaPago As Integer = Integer.Parse(drResult("IdFormasPago").ToString())
         Dim cantCuotas As Integer = Integer.Parse(drResult("CantidadCuotas").ToString())
         'If cantCuotas = 0 Then cantCuotas = 1
         Dim subTotal As Decimal = Decimal.Parse(drResult("PrecioVentaSinIVA").ToString())

         calcInt = rFichas.CalcularIntereses(idFormaPago, cantCuotas, categoria, subTotal)
         calcCuota = rFichas.CalcularImporteCuota(cantCuotas, subTotal, calcInt.TotalIntereses)
         drResult("PrecioCuotaSinIVA") = calcCuota.ImporteCuota
         drResult("PrecioFinalSinIVA") = calcCuota.ImporteTotalCuotas

         subTotal = Decimal.Parse(drResult("PrecioVentaConIVA").ToString())
         calcInt = rFichas.CalcularIntereses(idFormaPago, cantCuotas, categoria, subTotal)
         calcCuota = rFichas.CalcularImporteCuota(cantCuotas, subTotal, calcInt.TotalIntereses)
         drResult("PrecioCuotaConIVA") = calcCuota.ImporteCuota
         drResult("PrecioFinalConIVA") = calcCuota.ImporteTotalCuotas
      Next

      Return dtResult
   End Function


   Public Function GetPreciosEtiquetas(sucursales() As Integer,
                                       idProducto As String, nombreProducto As String,
                                       marcas As Entidades.Marca(), rubros As Entidades.Rubro(),
                                       idFormaPago As Integer?, idListaPrecios As Integer,
                                       fechaActualizadoDesde As Date, fechaActualizadoHasta As Date, stock As String,
                                       idTipoComprobante As String, letra As String, emisor As Integer, numeroComprobante As Long,
                                       idProveedor As Long, imprimeLote As Boolean, mostrarProveedorHabitual As Boolean) As DataTable
      Dim oPublicos = New Publicos()

      Dim strAnchoIdProducto As String = oPublicos.GetAnchoCampo("Productos", "IdProducto").ToString()
      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA
      Dim srtCatFiscalEmp As Short = Publicos.CategoriaFiscalEmpresa
      Dim redondeo As Integer = Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio
      Dim codigoBarras As Boolean = Publicos.ProductoUtilizaCodigoDeBarras

      Return New SqlServer.Productos(da).GetPreciosEtiquetas(sucursales,
                                                             idProducto, nombreProducto,
                                                             marcas, rubros,
                                                             idFormaPago, idListaPrecios,
                                                             fechaActualizadoDesde, fechaActualizadoHasta, stock,
                                                             idTipoComprobante, letra, emisor, numeroComprobante,
                                                             idProveedor, imprimeLote,
                                                             strAnchoIdProducto, blnPreciosConIVA, srtCatFiscalEmp, redondeo,
                                                             codigoBarras, mostrarProveedorHabitual)
   End Function

   Public Function GetPreciosEtiquetas2Listas(sucursales() As Integer,
                                              idProducto As String,
                                              nombreProducto As String,
                                              marcas As Entidades.Marca(),
                                              rubros As Entidades.Rubro(),
                                              idFormaPago As Integer?,
                                              idListaPrecios As Integer,
                                              idListaPrecios2 As Integer,
                                              fechaActualizadoDesde As Date,
                                              fechaActualizadoHasta As Date,
                                              stock As String,
                                              imprimeLote As Boolean) As DataTable

      Dim oPublicos As New Reglas.Publicos

      Dim strAnchoIdProducto As String = oPublicos.GetAnchoCampo("Productos", "IdProducto").ToString()
      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA
      Dim srtCatFiscalEmp As Short = Publicos.CategoriaFiscalEmpresa
      Dim redondeo As Integer = Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
      Dim codigoBarras As Boolean = Publicos.ProductoUtilizaCodigoDeBarras

      Return New SqlServer.Productos(da).GetPreciosEtiquetas2Listas(sucursales,
                                                             idProducto,
                                                             nombreProducto,
                                                             marcas,
                                                             rubros,
                                                             idFormaPago,
                                                             idListaPrecios,
                                                             idListaPrecios2,
                                                             fechaActualizadoDesde,
                                                             fechaActualizadoHasta,
                                                             stock,
                                                             strAnchoIdProducto,
                                                             blnPreciosConIVA,
                                                             srtCatFiscalEmp,
                                                             redondeo,
                                                             codigoBarras,
                                                             imprimeLote)
   End Function

   Public Function GetStockValorizado(sucursales As Entidades.Sucursal(),
                                      depositos As Entidades.SucursalDeposito(),
                                      ubicacion As Entidades.SucursalUbicacion,
                                      idProducto As String,
                                      idMarca As Integer,
                                      idRubro As Integer,
                                      idSubRubro As Integer,
                                      fechaHasta As Date?,
                                      idProveedor As Long,
                                      idListaPrecios As Integer,
                                      habitual As Boolean,
                                      cotizacionDolar As Decimal,
                                      decimalesRedondeo As Integer,
                                      activos As Entidades.Publicos.SiNoTodos) As DataTable
      Return EjecutaConConexion(
      Function()
         Dim anchoIdProducto = New Publicos(da).GetAnchoCampo("Productos", "IdProducto").ToString()
         Dim sql = New SqlServer.Productos(da)
         Dim dt = sql.GetStockValorizado(sucursales, depositos, ubicacion,
                                         idProducto, idMarca, idRubro, idSubRubro,
                                         anchoIdProducto,
                                         fechaHasta,
                                         idListaPrecios, Publicos.PreciosConIVA,
                                         idProveedor, habitual,
                                         cotizacionDolar, decimalesRedondeo,
                                         activos)
         If dt IsNot Nothing Then
            '-- REQ-43821.- -----------------------------------------------------------------------------------------
            dt.Columns.Add("KilosProducto", GetType(Decimal), "Stock * Kilos")
            dt.Columns.Add("KilosDeposito", GetType(Decimal), "StockDeposito * Kilos")
            dt.Columns.Add("KilosUbicacion", GetType(Decimal), "StockUbicacion * Kilos")
            '--------------------------------------------------------------------------------------------------------
            dt.Columns.Add("ValorizadoFabricaConImpuestos", GetType(Decimal), "Stock * PrecioFabricaConImpuestos")
            dt.Columns.Add("ValorizadoCostoConImpuestos", GetType(Decimal), "Stock * PrecioCostoConImpuestos")
            dt.Columns.Add("ValorizadoVentaConImpuestos", GetType(Decimal), "Stock * PrecioVentaConImpuestos")
            dt.Columns.Add("ValorizadoFabricaSinImpuestos", GetType(Decimal), "Stock * PrecioFabricaSinImpuestos")
            dt.Columns.Add("ValorizadoCostoSinImpuestos", GetType(Decimal), "Stock * PrecioCostoSinImpuestos")
            dt.Columns.Add("ValorizadoVentaSinImpuestos", GetType(Decimal), "Stock * PrecioVentaSinImpuestos")
         End If

         Return dt
      End Function)
   End Function

   Public Function GetProximoCodigo(prefijo As String) As String
      Dim result As String
      Dim numero As Integer

      If String.IsNullOrWhiteSpace(prefijo) Then
         result = (GetCodigoMaximo() + 1).ToString()
      Else
         Try
            Me.da.OpenConection()

            Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
            result = sql.GetCodigoMaximo(prefijo)

            If String.IsNullOrWhiteSpace(result) Or result = prefijo Then
               result = prefijo + "0"
            End If

            If Integer.TryParse(result.Substring(prefijo.Length), numero) Then
               result = prefijo + (numero + 1).ToString(New String("0"c, result.Length - prefijo.Length))
            Else
               result = prefijo
            End If

         Catch ex As Exception
            Throw
         Finally
            Me.da.CloseConection()
         End Try
      End If

      If String.IsNullOrWhiteSpace(result) Then
         result = "1"
      End If
      Return result
   End Function

   Public Function GetCodigoMaximo() As Long
      Return New Numeradores(da).GetUno(Entidades.Numerador.TiposNumeradores.PRODUCTOS.ToString(), AccionesSiNoExisteRegistro.Vacio).Numero
   End Function

   Public Function GetLimpiaNombreMarcaRubro(idMarca As Integer,
                                             idRubro As Integer,
                                             idSubRubro As Integer,
                                             nombreProducto As String,
                                             idSucursal As Integer,
                                             idDeposito As Integer,
                                             estado As String,
                                             conStock As String) As DataTable

      Dim oPublicos As New Reglas.Publicos()

      Dim idListaPrecios As Integer = Publicos.ListaPreciosPredeterminada

      Dim strAnchoIdProducto As String
      strAnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto").ToString()

      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA

      Dim stb = New StringBuilder()

      With stb
         .AppendLine("SELECT ")
         .AppendLine("	RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") as IdProducto,")
         .AppendLine("	P.NombreProducto,")
         If blnPreciosConIVA Then
            .AppendLine("	PSP.PrecioVenta/(1+(P.Alicuota/100)) as PrecioVentaSinIVA,")
            .AppendLine("   P.Alicuota, ")
            .AppendLine("	PSP.PrecioVenta as PrecioVentaConIVA,")
         Else
            .AppendLine("	PSP.PrecioVenta as PrecioVentaSinIVA,")
            .AppendLine("   P.Alicuota, ")
            .AppendLine("	PSP.PrecioVenta*(1+(P.Alicuota/100)) as PrecioVentaConIVA,")
         End If

         .AppendLine("	PUB.Stock,")
         .AppendLine("	M.NombreMarca,")
         .AppendLine("	R.NombreRubro,")
         .AppendLine("	P.Activo, PUB.IdUbicacion, SUB.NombreUbicacion")

         .AppendLine(" FROM ProductosSucursales PS")

         .AppendLine("    LEFT JOIN ProductosUbicaciones PUB ON PUB.IdProducto = PS.IdProducto")
         .AppendLine("                                      AND PUB.IdSucursal = PS.IdSucursal")
         .AppendLine("    LEFT JOIN SucursalesUbicaciones SUB ON SUB.IdSucursal =   PUB.IdSucursal")
         .AppendLine("                                       AND SUB.IdDeposito  =  PUB.IdDeposito")
         .AppendLine("                                       AND SUB.IdUbicacion  = PUB.IdUbicacion")

         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto")
         .AppendLine("                                          AND PSP.IdSucursal = PS.IdSucursal")
         .AppendLine("                                          AND PSP.IdListaPrecios = " + idListaPrecios.ToString())
         .AppendLine("	LEFT JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendLine("	LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" WHERE PS.IdSucursal = " & idSucursal.ToString())

         .AppendFormatLine("	AND PUB.IdDeposito = {0}", idDeposito)


         If estado = "ACTIVOS" Then
            .AppendLine("	AND P.Activo = 'True'")   'Solo permito elegir los productos Activos
         End If

         If Not String.IsNullOrEmpty(nombreProducto) Then
            'Si contiene espacio hago una busqueda por cada palabra
            If Not nombreProducto.Contains(" ") Then
               .AppendLine("   AND P.NombreProducto LIKE '%" & nombreProducto & "%'")
            Else
               Dim Palabras() As String = nombreProducto.Split(" "c)

               .Append("   AND ( 1=1 ")
               For Each Palabra As String In Palabras
                  .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
               Next

               .AppendLine("  )")
            End If
         End If

         If idMarca <> 0 Then
            .AppendLine("	AND P.IdMarca = " & idMarca.ToString())
         End If

         If idRubro <> 0 Then
            .AppendLine("	AND P.IdRubro = " & idRubro.ToString())
         End If

         If idSubRubro > 0 Then
            .AppendLine("   AND P.IdSubRubro = " & idSubRubro.ToString())
         End If

         If conStock = "SI" Then
            .AppendLine("	AND PUB.Stock <> 0")
         ElseIf conStock = "NO" Then
            .AppendLine("	AND PUB.Stock = 0")
         End If

         .AppendLine(" ORDER BY P.NombreProducto")
      End With
      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombreMarcaRubro(idMarca As Integer,
                                          idRubro As Integer,
                                          idSubRubro As Integer,
                                          nombreProducto As String,
                                          idSucursal As Integer,
                                          estado As String,
                                          conStock As String) As DataTable

      Dim oPublicos As New Reglas.Publicos()

      Dim idListaPrecios As Integer = Publicos.ListaPreciosPredeterminada

      Dim strAnchoIdProducto As String
      strAnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto").ToString()

      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA

      Dim stb = New StringBuilder()

      With stb
         .AppendLine("SELECT ")
         .AppendLine("	RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") as IdProducto,")
         .AppendLine("	P.NombreProducto,")
         .AppendLine("	P.NombreCorto,")
         If blnPreciosConIVA Then
            .AppendLine("	PSP.PrecioVenta/(1+(P.Alicuota/100)) as PrecioVentaSinIVA,")
            .AppendLine("   P.Alicuota, ")
            .AppendLine("	PSP.PrecioVenta as PrecioVentaConIVA,")
         Else
            .AppendLine("	PSP.PrecioVenta as PrecioVentaSinIVA,")
            .AppendLine("   P.Alicuota, ")
            .AppendLine("	PSP.PrecioVenta*(1+(P.Alicuota/100)) as PrecioVentaConIVA,")
         End If

         .AppendLine("	PS.Stock,")
         .AppendLine("	M.NombreMarca,")
         .AppendLine("	R.NombreRubro,")
         .AppendLine("	P.Activo")

         .AppendLine(" FROM ProductosSucursales PS")
         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto")
         .AppendLine("                                          AND PSP.IdSucursal = PS.IdSucursal")
         .AppendLine("                                          AND PSP.IdListaPrecios = " + idListaPrecios.ToString())
         .AppendLine("	LEFT JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendLine("	LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" WHERE PS.IdSucursal = " & idSucursal.ToString())

         If estado = "ACTIVOS" Then
            .AppendLine("	AND P.Activo = 'True'")   'Solo permito elegir los productos Activos
         End If

         If Not String.IsNullOrEmpty(nombreProducto) Then
            'Si contiene espacio hago una busqueda por cada palabra
            If Not nombreProducto.Contains(" ") Then
               .AppendLine("   AND P.NombreProducto LIKE '%" & nombreProducto & "%'")
            Else
               Dim Palabras() As String = nombreProducto.Split(" "c)

               .Append("   AND ( 1=1 ")
               For Each Palabra As String In Palabras
                  .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
               Next

               .AppendLine("  )")
            End If
         End If

         If idMarca <> 0 Then
            .AppendLine("	AND P.IdMarca = " & idMarca.ToString())
         End If

         If idRubro <> 0 Then
            .AppendLine("	AND P.IdRubro = " & idRubro.ToString())
         End If

         If idSubRubro > 0 Then
            .AppendLine("   AND P.IdSubRubro = " & idSubRubro.ToString())
         End If

         If conStock = "SI" Then
            .AppendLine("	AND PS.Stock <> 0")
         ElseIf conStock = "NO" Then
            .AppendLine("	AND PS.Stock = 0")
         End If

         .AppendLine(" ORDER BY P.NombreProducto")
      End With
      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetUnoParaM(idProducto As String) As Entidades.ProductoLivianoParaImportarProducto
      Return GetUnoParaM(idProducto, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetUnoParaM(idProducto As String, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoLivianoParaImportarProducto
      Return EjecutaConConexion(Function() _GetUnoParaM(idProducto, accion))
   End Function
   Public Function _GetUnoParaM(idProducto As String) As Entidades.ProductoLivianoParaImportarProducto
      Return _GetUnoParaM(idProducto, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function _GetUnoParaM(idProducto As String, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoLivianoParaImportarProducto
      If String.IsNullOrWhiteSpace(idProducto) Then
         Throw New Exception(String.Format("No existe Producto con Código {0}", idProducto))
      End If
      Return CargaEntidad(New SqlServer.Productos(da).Productos_G1_LivianoParaImportarProducto(idProducto),
                             Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoLivianoParaImportarProducto(),
                             accion, Function() String.Format("No existe Producto con Código {0}", idProducto))
   End Function

   Private Sub CargarUno(o As Entidades.ProductoLivianoParaImportarProducto, dr As DataRow)

      With o
         .IdProducto = dr.Field(Of String)(Entidades.Producto.Columnas.IdProducto.ToString())
         .NombreProducto = dr.Field(Of String)(Entidades.Producto.Columnas.NombreProducto.ToString())
         .Alicuota = dr.Field(Of Decimal)(Entidades.Producto.Columnas.Alicuota.ToString())

         .Activo = dr.Field(Of Boolean)(Entidades.Producto.Columnas.Activo.ToString())

         .PrecioPorEmbalaje = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PrecioPorEmbalaje.ToString())
         .Embalaje = dr.Field(Of Integer)(Entidades.Producto.Columnas.Embalaje.ToString())

         .EsOferta = dr.Field(Of String)(Entidades.Producto.Columnas.EsOferta.ToString())

         .IdMarca = dr.Field(Of Integer)(Entidades.Producto.Columnas.IdMarca.ToString())
         .IdRubro = dr.Field(Of Integer)(Entidades.Producto.Columnas.IdRubro.ToString())

         .IdMoneda = dr.Field(Of Integer)(Entidades.Producto.Columnas.IdMoneda.ToString())
         .NombreMoneda = dr.Field(Of String)(Entidades.Moneda.Columnas.NombreMoneda.ToString())

         .IdProveedorHabitual = dr.Field(Of Long?)(Entidades.Producto.Columnas.IdProveedor.ToString())
         .DescuentoRecargoPorc1 = dr.Field(Of Decimal?)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc1.ToString())
         .DescuentoRecargoPorc2 = dr.Field(Of Decimal?)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc2.ToString())
         .DescuentoRecargoPorc3 = dr.Field(Of Decimal?)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc3.ToString())
         .DescuentoRecargoPorc4 = dr.Field(Of Decimal?)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc4.ToString())

         .AfectaStock = dr.Field(Of Boolean)(Entidades.Producto.Columnas.AfectaStock.ToString())

         .Lote = dr.Field(Of Boolean)(Entidades.Producto.Columnas.Lote.ToString())
         .NroSerie = dr.Field(Of Boolean)(Entidades.Producto.Columnas.NroSerie.ToString())

         .IdSucursal = dr.Field(Of Integer)("IdSucursalDefecto")

         .IdDepositoDefecto = dr.Field(Of Integer)("IdDepositoDefecto")
         .CodigoDepositoDefecto = dr.Field(Of String)("CodigoDepositoDefecto")
         .NombreDepositoDefecto = dr.Field(Of String)("NombreDepositoDefecto")

         .IdUbicacionDefecto = dr.Field(Of Integer)("IdUbicacionDefecto")
         .CodigoUbicacionDefecto = dr.Field(Of String)("CodigoUbicacionDefecto")
         .NombreUbicacionDefecto = dr.Field(Of String)("NombreUbicacionDefecto")
         .InformeControlCalidad = dr.Field(Of Boolean)("InformeControlCalidad")

         .IdUnidadDeMedidaProduccion = dr.Field(Of String)("IdUnidadDeMedidaProduccion")
         .FactorConversionProduccion = dr.Field(Of Decimal)("FactorConversionProduccion")
         .IdUnidadDeMedidaCompra = dr.Field(Of String)("IdUnidadDeMedidaCompra")
         .FactorConversionCompra = dr.Field(Of Decimal)("FactorConversionCompra")
         .ComisionPorVenta = dr.Field(Of Decimal)("ComisionPorVenta")

      End With

   End Sub



   Public Function GetUno(idProducto As String, Optional incluirFoto As Boolean = False, Optional incluirPrecios As Boolean = False, Optional accion As AccionesSiNoExisteRegistro = AccionesSiNoExisteRegistro.Excepcion) As Entidades.Producto
      'Pasa como parametros. Se dio vuelta para que no lo cargue. Solo se usa en ABM de Productos y en FacturacionRapida
      Dim stb = New StringBuilder()
      SelectFiltrado(stb, incluirFoto, espaciosID:=False)
      stb.AppendFormatLine(" WHERE P.IdProducto = '{0}'", idProducto)

      Using dt = da.GetDataTable(stb.ToString())
         Dim o = New Entidades.Producto()
         If dt.Rows.Count > 0 Then
            CargarUno(o, dt.Rows(0), incluirPrecios)
         Else
            If accion = AccionesSiNoExisteRegistro.Excepcion Then
               Throw New Exception(String.Format("No existe Producto con Id {0}.", idProducto))
            ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
               Return Nothing
            End If
         End If
         Return o
      End Using
   End Function

   Public Sub CambiarCodigo(idProductoOrigen As String, idProductoDestino As String, Base As String,
                            idFormula As Integer?) '# Si el producto no tiene fórmula, llegará vacio.

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
         sql.Productos_CC(idProductoOrigen, idProductoDestino, Base, idFormula)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub
   ''' <summary>
   ''' Actualiza Precio Costo (ProductosSucursales) y el IdProcesoProductivo(Productos).-
   ''' </summary>
   ''' <param name="producto">Entidad Producto</param>
   ''' <param name="costoTotalProceso">Costo de Proceso Productivo</param>
   Public Sub ActualizarPrecioProcesoProd(producto As Entidades.Producto, costoTotalProceso As Decimal)

      If producto.PrecioCosto <> costoTotalProceso Then
         Dim rProductoSuc = New Reglas.ProductosSucursales(da)
         Dim eProductoSuc = rProductoSuc._GetUno(actual.Sucursal.Id, producto.IdProducto)
         eProductoSuc.PrecioCosto = costoTotalProceso
         rProductoSuc.ActualizaPrecioCosto(eProductoSuc, Entidades.Producto.NombreTabla.ToString())
      End If
      Dim sql = New SqlServer.Productos(da)
      sql.Productos_U_ProcesoProductivo(producto.IdProducto, producto.IdProcesoProductivoDefecto)
      sql.Productos_U_EsCompuesto(producto.IdProducto, producto.IdProcesoProductivoDefecto.HasValue, FacturacionDescontarStockComp:=False)

      Dim rAudit = New Auditorias(da)
      rAudit.Insertar("Productos", Entidades.OperacionesAuditorias.Modificacion, actual.Nombre, String.Format("IdProducto = '{0}'", producto.IdProducto), conMilisegundos:=True)

   End Sub
   Public Sub ActualizarFormulaDefecto(idProducto As String, idFormula As Integer)
      EjecutaConTransaccion(Sub() _ActualizarFormulaDefecto(idProducto, idFormula))
   End Sub
   Public Sub _ActualizarFormulaDefecto(idProducto As String, idFormula As Integer)
      Dim sql = New SqlServer.Productos(da)
      sql.Productos_U_FormulaDefecto(idProducto, idFormula, Nothing)
   End Sub

   <Obsolete("Utilizar ActualizarFormulaDefecto o _ActualizarFormulaDefecto según corresponda", False)>
   Public Sub ProductoFormulaDefecto(IdProducto As String, IdFormula As Integer, Optional conConexion As Boolean = True)
      If conConexion Then
         ActualizarFormulaDefecto(IdProducto, IdFormula)
      Else
         _ActualizarFormulaDefecto(IdProducto, IdFormula)
      End If

      ''Try
      ''   If conConexion Then
      ''      da.OpenConection()
      ''      da.BeginTransaction()
      ''   End If

      ''   Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      ''   sql.Productos_U_FormulaDefecto(IdProducto, IdFormula, Nothing)

      ''   If conConexion Then
      ''      da.CommitTransaction()
      ''   End If

      ''Catch ex As Exception
      ''   If conConexion Then
      ''      da.RollbakTransaction()
      ''   End If
      ''   Throw ex
      ''Finally
      ''   If conConexion Then
      ''      da.CloseConection()
      ''   End If
      ''End Try

   End Sub

   Public Function GetProductoFormulaPorDefecto(idProducto As String) As Integer?
      Return New SqlServer.Productos(da).GetProductoFormulaPorDefecto(idProducto).Rows(0).Field(Of Integer?)(Entidades.Producto.Columnas.IdFormula.ToString())
   End Function

   Public Sub UnificarCodigos(IdSucursal As Integer,
                              IdProducto1 As String,
                              idProducto2 As String,
                              Stock As Decimal,
                              PrecioCompra As Decimal,
                              PrecioCosto As Decimal,
                              Listas As DataTable,
                              CodigoProducto As Integer,
                              DescripcionProducto As String,
                              Usuario As String)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
         sql.Productos_Unificar(IdSucursal, IdProducto1, idProducto2, Stock, PrecioCompra, PrecioCosto, Listas, CodigoProducto, DescripcionProducto, Usuario)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub CopiarProductos(idProductoOriginal As String, datos As DataTable, usuario As String, BorraProdOriginal As Boolean, idFuncion As String)

      Try

         Dim Suc As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(False)
         Dim Sucursales(0 To Suc.Count - 1) As Integer
         Dim Cont As Integer = 0, k As Integer = 0

         For Each ite As Object In Suc
            Sucursales(Cont) = DirectCast(ite, Entidades.Sucursal).Id
            Cont += 1
         Next

         Dim Listas As List(Of Entidades.ListaDePrecios)
         Dim oLista As Reglas.ListasDePrecios = New Reglas.ListasDePrecios()
         Listas = oLista.GetTodos()

         da.OpenConection()
         da.BeginTransaction()

         Dim dt As DataTable = datos

         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos(da)
         Dim dtProductos As DataTable
         Dim Producto As Entidades.Producto = New Entidades.Producto

         Dim oProdSuc As Eniac.Reglas.ProductosSucursales = New Eniac.Reglas.ProductosSucursales(da)
         Dim ProdSuc As Entidades.ProductoSucursal = New Entidades.ProductoSucursal

         Dim oProdSP As Entidades.ProductoSucursalPrecio

         Dim UM As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas(da)

         'Tomo los datos del producto original
         dtProductos = oProductos.GetPreciosPorLista(0, 0, idProductoOriginal, Sucursales, Listas)

         Producto.IdSucursal = 1
         Producto.IdMarca = Integer.Parse(dtProductos.Rows(0)("IdMarca").ToString())

         If IsNumeric(dtProductos.Rows(0)("IdModelo").ToString()) Then
            Producto.IdModelo = Integer.Parse(dtProductos.Rows(0)("IdModelo").ToString())
         End If

         Producto.IdRubro = Integer.Parse(dtProductos.Rows(0)("IdRubro").ToString())

         If IsNumeric(dtProductos.Rows(0)("IdSubRubro").ToString()) Then
            Producto.IdSubRubro = Integer.Parse(dtProductos.Rows(0)("IdSubRubro").ToString())
         End If

         Producto.MesesGarantia = Integer.Parse(dtProductos.Rows(0)("MesesGarantia").ToString())
         Producto.AfectaStock = Boolean.Parse(dtProductos.Rows(0)("AfectaStock").ToString())
         Producto.IdTipoImpuesto = dtProductos.Rows(0)("IdTipoImpuesto").ToString()
         Producto.Alicuota = Decimal.Parse(dtProductos.Rows(0)("Alicuota").ToString())

         If IsNumeric(dtProductos.Rows(0)("Alicuota2").ToString()) Then
            Producto.Alicuota2 = Decimal.Parse(dtProductos.Rows(0)("Alicuota2").ToString())
         End If

         Producto.ImporteImpuestoInterno = Decimal.Parse(dtProductos.Rows(0)("ImporteImpuestoInterno").ToString())
         Producto.PorcImpuestoInterno = Decimal.Parse(dtProductos.Rows(0)("PorcImpuestoInterno").ToString())
         Producto.OrigenPorcImpInt = DirectCast([Enum].Parse(GetType(Entidades.OrigenesPorcImpInt), dtProductos.Rows(0)("OrigenPorcImpInt").ToString()), Entidades.OrigenesPorcImpInt)

         'No puedo copiar un producto inactivo, no se puede elegir.
         Producto.Activo = True

         Producto.Usuario = usuario

         For Each dr As DataRow In dt.Rows

            System.Windows.Forms.Application.DoEvents()

            Producto.IdProducto = dr("CodigoProducto").ToString.Trim()
            Producto.NombreProducto = dr("NombreProducto").ToString.Trim()
            Producto.nombreCorto = dr("nombreCorto").ToString.Trim

            If IsNumeric(dr("Tamanio").ToString()) Then
               Producto.Tamano = Decimal.Parse(dr("Tamanio").ToString())
            End If
            If dr("UnidadDeMedida").ToString() <> "" Then
               Producto.UnidadDeMedida = UM.GetUno(dr("UnidadDeMedida").ToString())
            End If

            'Producto.Activo = True    'Si lo copia... lo deja activo.

            oProductos.Inserta(Producto, idFuncion)

            ProdSuc = New Entidades.ProductoSucursal()

            ProdSuc.Producto.IdProducto = Producto.IdProducto
            ProdSuc.Stock = 0
            ProdSuc.StockInicial = 0
            ProdSuc.Usuario = usuario

            'TERMINAR
            For k = 0 To Cont - 1

               ProdSuc.Sucursal.Id = Sucursales(k)
               ProdSuc.PrecioFabrica = Decimal.Parse(dtProductos.Rows(k)("PrecioFabrica").ToString())
               ProdSuc.PrecioCosto = Decimal.Parse(dtProductos.Rows(k)("PrecioCosto").ToString())
               'ProdSuc.PrecioVenta = Decimal.Parse(dtProductos.Rows(k)("VentaLista0").ToString())

               For Each lis As Entidades.ListaDePrecios In Listas
                  oProdSP = New Entidades.ProductoSucursalPrecio()
                  oProdSP.ProductoSucursal = ProdSuc
                  oProdSP.IdSucursal = Sucursales(k)
                  oProdSP.ListaDePrecios = lis
                  oProdSP.PrecioVenta = Decimal.Parse(dtProductos.Rows(k)("VentaLista" & lis.IdListaPrecios).ToString())
                  oProdSP.Usuario = Entidades.Usuario.Actual.Nombre
                  ProdSuc.Precios.Add(oProdSP)
               Next

               oProdSuc.ActualizaPrecios(ProdSuc, idFuncion)

            Next

         Next

         Producto.IdProducto = idProductoOriginal

         If BorraProdOriginal Then
            oProductos.Borra(Producto)
         End If

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function Existe(idProducto As String, Optional activo As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.TODOS) As Boolean
      Dim sql = New SqlServer.Productos(da)
      Return sql.Productos_G1(idProducto, activo).Any()
   End Function

   Public Function ExisteProductoProveedor(idProducto As String, IdProveedor As Long) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT COUNT(CodigoProductoProveedor) AS Existe")
         .AppendLine("  FROM ProductosProveedores")
         .AppendLine("  WHERE CodigoProductoProveedor = '" & idProducto & "'")
         .AppendLine("  AND IdProveedor = " & IdProveedor)
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Function IdProductoXProductoProveedor(idProducto As String, IdProveedor As Long) As String
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT IdProducto")
         .AppendLine("  FROM ProductosProveedores")
         .AppendLine("  WHERE CodigoProductoProveedor = '" & idProducto & "'")
         .AppendLine("  AND IdProveedor = " & IdProveedor)
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return dt.Rows(0)("IdProducto").ToString()
   End Function

   Public Function GetPorCodigoProveedor(CodigoProductoProveedor As String, IdProveedor As Long) As String
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT IdProducto")
         .AppendLine("  FROM ProductosProveedores")
         .AppendLine("  WHERE CodigoProductoProveedor = '" & CodigoProductoProveedor & "'")
         .AppendLine("  AND IdProveedor = " & IdProveedor)
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      If dt.Rows.Count <> 0 Then
         Return dt.Rows(0)("IdProducto").ToString()
      End If
      Return Nothing
   End Function


   Public Function ExisteCodigoDeBarras(idProducto As String, Optional activo As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.TODOS) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT COUNT(P.IdProducto) AS Existe")
         .AppendLine("  FROM Productos P")
         .AppendFormatLine("  WHERE P.CodigoDeBarras = '{0}'", idProducto)
         'PE-31282
         If activo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND P.Activo = {0}", If(activo = Entidades.Publicos.SiNoTodos.SI, 1, 0))
         End If
         .AppendFormatLine("   OR EXISTS(SELECT * FROM ProductosIdentificaciones PI WHERE PI.IdProducto = P.IdProducto AND PI.Identificacion = '{0}')", idProducto)

      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Function ExisteCodigoDeBarrasRepetido(idProducto As String,
                                                codigoDeBarra As String,
                                                identificaciones As List(Of Entidades.ProductoIdentificacion)) As Validaciones.ValidacionResult
      Dim result As Validaciones.ValidacionResult = New Validaciones.ValidacionResult()
      Dim stbError = New StringBuilder()
      Dim stb As StringBuilder
      Dim dt As DataTable
      If Not String.IsNullOrWhiteSpace(codigoDeBarra) Then
         stb = New StringBuilder()
         With stb
            .AppendFormatLine("SELECT IdProducto FROM Productos WHERE CodigoDeBarras = '{0}' AND IdProducto <> '{1}'", codigoDeBarra, idProducto)
         End With
         dt = Me.da.GetDataTable(stb.ToString())
         If dt.Rows.Count > 0 Then
            result.Error = True
            stbError.AppendFormatLine("El Código de Barras {0} ya fue utilizado como Código de Barras en el producto {1}", codigoDeBarra, dt.Rows(0)(0).ToString())
         End If

         stb = New StringBuilder()
         With stb
            .AppendFormatLine("SELECT IdProducto FROM ProductosIdentificaciones WHERE Identificacion = '{0}' AND IdProducto <> '{1}'", codigoDeBarra, idProducto)
         End With
         dt = Me.da.GetDataTable(stb.ToString())
         If dt.Rows.Count > 0 Then
            result.Error = True
            stbError.AppendFormatLine("El Código de Barras {0} ya fue usado como Cógigo Alternativo de {1}", codigoDeBarra, dt.Rows(0)(0).ToString())
         End If
      End If

      For Each ident As Entidades.ProductoIdentificacion In identificaciones
         If Not String.IsNullOrWhiteSpace(ident.Identificacion) Then
            stb = New StringBuilder()
            With stb
               .AppendFormatLine("SELECT IdProducto FROM Productos WHERE CodigoDeBarras = '{0}' AND IdProducto <> '{1}'", ident.Identificacion, idProducto)
            End With
            dt = Me.da.GetDataTable(stb.ToString())
            If dt.Rows.Count > 0 Then
               result.Error = True
               stbError.AppendFormatLine("El Cógigo Alternativo {0} ya fue utilizado como Código de Barras en el producto {1}", ident.Identificacion, dt.Rows(0)(0).ToString())
            End If

            stb = New StringBuilder()
            With stb
               .AppendFormatLine("SELECT IdProducto FROM ProductosIdentificaciones WHERE Identificacion = '{0}' AND IdProducto <> '{1}'", ident.Identificacion, idProducto)
            End With
            dt = Me.da.GetDataTable(stb.ToString())
            If dt.Rows.Count > 0 Then
               result.Error = True
               stbError.AppendFormatLine("El Cógigo Alternativo {0} ya fue usado como Cógigo Alternativo de {1}", ident.Identificacion, dt.Rows(0)(0).ToString())
            End If

         End If
      Next

      If result.Error Then
         result.MensajeError = stbError.ToString()
      End If

      Return result
   End Function

   Public Function ExisteNumeroChasis(NroChasis As String) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT COUNT(P.IdProducto) AS Existe")
         .AppendLine("  FROM Productos P")
         .AppendFormatLine("  WHERE P.CalidadNumeroChasis = '{0}'", NroChasis)
         '.AppendFormatLine(" AND VP.stpDep_Cod = 'PCH' ")
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Function GetNumeroChasisBejerman(NroChasis As String, base As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT * FROM " & base & ".dbo.Vista_ArtPartidas VP")
         .AppendFormat(" WHERE VP.stpDep_Cod = 'PCH' ")
         If Not String.IsNullOrEmpty(NroChasis) Then
            .AppendFormatLine("           AND VP.stp_Partida LIKE '%{0}%'", NroChasis)
         End If
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return dt
   End Function

   Public Function GetInformeDeChasis(idProducto As String, fechaDesde As DateTime?,
                                      fechaHasta As DateTime?, IdCliente As Long,
                                      Chasis As List(Of String), Modelo As Integer, base As String) As DataTable

      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      Return sql.GetInformeDeChasis(idProducto, fechaDesde, fechaHasta,
                                    IdCliente, Chasis, Modelo, base)


   End Function

   'Public Sub ImportarChasisBejerman(ByVal IdSucursal As Integer,
   '                          ByVal datos As DataTable,
   '                          ByVal usuario As String,
   '                          ByRef BarraProg As System.Windows.Forms.ProgressBar,
   '                           idFuncion As String)
   '   Try

   '      da.OpenConection()
   '      da.BeginTransaction()

   '      Dim dt As DataTable = datos

   '      Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos(da)
   '      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
   '      Dim ExisteProducto As Boolean
   '      Dim Producto As Entidades.Producto = New Entidades.Producto

   '      Dim i As Integer = 0

   '      BarraProg.Maximum = dt.Rows.Count
   '      BarraProg.Minimum = 0
   '      BarraProg.Value = 0

   '      Dim TipoServicio As Entidades.ProductoTipoServicio = New Reglas.ProductosTiposServicios().GetUno(3)
   '      Dim Numerador As DataTable = New DataTable()
   '      Dim Numero As Long = 0
   '      Dim oNumeradores As Reglas.Numeradores = New Reglas.Numeradores()
   '      Numerador = oNumeradores._getUno(String.Format("{0}", TipoServicio.Prefijo))
   '      If Numerador.Rows.Count > 0 Then
   '         Numero = Long.Parse(Numerador.Rows(0).Item("Numero").ToString()) + 1
   '      Else
   '         Numero = 1
   '      End If

   '      For Each dr As DataRow In dt.Rows

   '         i += 1
   '         BarraProg.Value = i

   '         If Boolean.Parse(dr("Importa").ToString()) Then

   '            ExisteProducto = oProductos.ExisteNumeroChasis(dr("NumeroChasis").ToString())

   '            If Not ExisteProducto Then
   '               Producto = New Entidades.Producto
   '               Producto.IdProducto = String.Format("{0}-{1}", TipoServicio.Prefijo, Numero.ToString())
   '               Producto.NombreProducto = Strings.Trim(dr("NombreProducto").ToString.Trim())
   '               Producto.CalidadNumeroChasis = dr("NumeroChasis").ToString().Trim()
   '               Producto.CalidadNroDeMotor = dr("NroDeMotor").ToString().Trim()

   '               If String.IsNullOrWhiteSpace(Producto.Usuario) Then
   '                  Producto.Usuario = actual.Nombre
   '               End If

   '               If Producto.IdProductoTipoServicio = 0 Then
   '                  Producto.IdProductoTipoServicio = 3
   '               End If

   '               Producto.IdMarca = cache.GetPrimeraMarca().IdMarca  ' New Reglas.Marcas().GetPrimeraMarca()
   '               Producto.IdRubro = cache.GetPrimerRubro().IdRubro ' New Reglas.Rubros().GetPrimerRubro()
   '               Producto.Moneda = cache.BuscaMoneda(Entidades.Moneda.Peso) ' New Reglas.Monedas().GetUna(1)
   '               Producto.Alicuota = Publicos.ProductoIVA  '21.0
   '               Producto.IdSucursal = actual.Sucursal.Id
   '               Producto.Tamano = 1
   '               Producto.UnidadDeMedida.IdUnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
   '               Producto.MesesGarantia = 0
   '               Producto.AfectaStock = True
   '               Producto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString() ' "IVA"
   '               Producto.EsServicio = False
   '               Producto.PublicarEnWeb = False
   '               Producto.EsDeVentas = True
   '               Producto.EsDeCompras = True
   '               Producto.EsCompuesto = False
   '               Producto.DescontarStockComponentes = False
   '               Producto.CodigoDeBarrasConPrecio = False
   '               Producto.PermiteModificarDescripcion = False
   '               Producto.PagaIngresosBrutos = True
   '               Producto.Embalaje = 1
   '               Producto.Kilos = 0
   '               Producto.PublicarListaDePreciosClientes = True
   '               Producto.FacturacionCantidadNegativa = False
   '               Producto.SolicitaEnvase = False
   '               Producto.AlertaDeCaja = False
   '               Producto.EsRetornable = False
   '               Producto.Observacion = ""
   '               Producto.IdModelo = 0
   '               Producto.EsOferta = "NO"
   '               Producto.IncluirExpensas = False
   '               Producto.nombreCorto = ""
   '               Producto.Activo = True
   '               Producto.PrecioPorEmbalaje = False
   '               Producto.UnidHasta1 = 0
   '               Producto.UnidHasta2 = 0
   '               Producto.UnidHasta3 = 0
   '               Producto.UnidHasta4 = 0
   '               Producto.UnidHasta5 = 0
   '               Producto.UHPorc1 = 0
   '               Producto.UHPorc2 = 0
   '               Producto.UHPorc3 = 0
   '               Producto.UHPorc4 = 0
   '               Producto.UHPorc5 = 0
   '               '    produ.ObservacionCompras = observacionCompras
   '               Producto.SolicitaPrecioVentaPorTamano = False
   '               Producto.Orden = 1

   '               oProductos.InsertaCalidad(Producto, 0, idFuncion)

   '               Numero += 1
   '            Else

   '               'Modelo = oProductosModelos.GetUnoxCodigo(dr("CodigoProductoModelo").ToString().Trim())
   '               'Modelo.NombreProductoModelo = Strings.Trim(dr("NombreProductoModelo").ToString.Trim())
   '               'oProductos._Actualiza(Modelo)

   '            End If
   '         End If
   '      Next

   '      da.CommitTransaction()

   '   Catch ex As Exception
   '      BarraProg.Value = 0
   '      da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      da.CloseConection()
   '   End Try

   'End Sub

   Public Sub ImportarProductos(idSucursal As Integer, datos As DataTable, usuario As String, idListaDePrecios As Integer, BarraProg As Windows.Forms.ProgressBar, idFuncion As String)
      Try

         da.OpenConection()
         da.BeginTransaction()

         'Dim ProductoIVA As Decimal = Decimal.Parse(New Reglas.Parametros().GetValor("PRODUCTOIVA"))

         'Encontre que en la base de Bernabe faltaban registros. 
         'Era un error de la baja logica en productos, porque estaria bien que faltan si no esta activo, pero si se reactiva no lo cargaba. 
         'Fue corregido pero por las dudas lo hago.
         Dim sqlPSP As SqlServer.ProductosSucursalesPrecios = New SqlServer.ProductosSucursalesPrecios(da)
         sqlPSP.ProductosSucursalesPrecios_IFaltante("", usuario)

         Dim dt = datos

         Dim rMarcas = New Marcas(da)
         Dim marca = New Entidades.Marca()

         Dim rRubros = New Rubros(da)
         Dim rubro = New Entidades.Rubro()

         Dim rSubRubros = New SubRubros(da)
         Dim subRubro = New Entidades.SubRubro()

         Dim rSubSubRubros = New SubSubRubros(da)
         Dim subSubRubro = New Entidades.SubSubRubro()

         Dim rProductoProveedor = New ProductosProveedores(da)
         Dim rProveedor = New Proveedores(da)
         Dim proveedor = New Entidades.Proveedor()

         Dim oProductos = New Productos(da)
         Dim producto = New Entidades.Producto()

         Dim rProdSuc = New ProductosSucursales(da)
         Dim prodSuc = New Entidades.ProductoSucursal()

         Dim rProdSucPrecios = New ProductosSucursales(da)
         Dim rHistPrec = New HistorialPrecios(da)

         Dim rDeposito = New SucursalesDepositos(da)
         Dim rUbicacion = New SucursalesUbicaciones(da)

         Dim AnchoNombreProducto As Integer = New Reglas.Publicos().GetAnchoCampo("Productos", "NombreProducto")
         Dim blnProductoUtilizaNombreCorto As Boolean = Publicos.ProductoUtilizaNombreCorto

         Dim i As Integer = 0

         BarraProg.Maximum = dt.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0

         'oProductos.InactivarProductos(idMarca)

         For Each dr As DataRow In dt.Rows

            i += 1
            BarraProg.Value = i

            If Boolean.Parse(dr("Importa").ToString()) Then

               'Si la Marca que estoy leyendo no existe, la doy de alta.

               Dim dtMarcas = rMarcas.GetPorNombreExacto(dr("NombreMarca").ToString())

               If dtMarcas.Rows.Count = 0 Then
                  marca.IdMarca = rMarcas.GetCodigoMaximo() + 1
                  marca.NombreMarca = dr("NombreMarca").ToString.Trim()

                  rMarcas.Inserta(marca)

               Else
                  marca.IdMarca = Integer.Parse(dtMarcas.Rows(0)("IdMarca").ToString())
               End If

               '-------------------------------------------------------------------------------


               'Si el Rubro que estoy leyendo no existe, lo doy de alta.

               Dim dtRubros = rRubros.GetPorNombreExacto(dr("NombreRubro").ToString())

               If dtRubros.Rows.Count = 0 Then
                  Dim IdRubro As Integer = rRubros.GetCodigoMaximo() + 1
                  rubro.IdRubro = IdRubro
                  rubro.NombreRubro = dr("NombreRubro").ToString.Trim()

                  rRubros.Inserta(rubro)

                  If Not String.IsNullOrWhiteSpace(dr("NombreSubRubro").ToString()) Then
                     subRubro.IdSubRubro = rSubRubros.GetCodigoMaximo(rubro.IdRubro) + 1
                     subRubro.IdRubro = IdRubro
                     subRubro.NombreSubRubro = dr("NombreSubRubro").ToString.Trim()
                     rSubRubros.Inserta(subRubro)


                     ' Verifico que en la planilla se haya ingresado un SubSubRubro
                     If Not String.IsNullOrWhiteSpace(dr("NombreSubSubRubro").ToString()) Then
                        ' Verifico si ya existe el subsubRubro
                        Dim dtSubSubRubros = rSubSubRubros.GetPorNombre(rubro.IdRubro, subSubRubro.IdSubRubro, dr("NombreSubSubRubro").ToString()) '?
                        If dtSubSubRubros.Rows.Count = 0 Then
                           If Not String.IsNullOrWhiteSpace(dr("NombreSubSubRubro").ToString()) Then
                              subSubRubro.IdSubSubRubro = Integer.Parse(rSubSubRubros.GetCodigoMaximo(0).ToString()) + 1
                              subSubRubro.NombreSubSubRubro = dr("NombreSubSubRubro").ToString.Trim()
                              subSubRubro.IdSubRubro = subRubro.IdSubRubro
                              rSubSubRubros._Insertar(subSubRubro)
                           End If
                        Else
                           subSubRubro.IdSubSubRubro = Integer.Parse(dtSubSubRubros.Rows(0)("IdSubSubRubro").ToString())
                        End If
                     End If
                  End If

               Else
                  rubro.IdRubro = Integer.Parse(dtRubros.Rows(0)("IdRubro").ToString())

                  If Not String.IsNullOrWhiteSpace(dr("NombreSubRubro").ToString()) Then
                     ' Sub Rubro
                     Dim dtSubRubros = rSubRubros.GetPorNombreSubrubro(rubro, dr("NombreSubRubro").ToString()) '?
                     If dtSubRubros.Rows.Count = 0 Then
                        subRubro.IdSubRubro = rSubRubros.GetCodigoMaximo(rubro.IdRubro) + 1
                        subRubro.IdRubro = rubro.IdRubro
                        subRubro.NombreSubRubro = dr("NombreSubRubro").ToString.Trim()
                        rSubRubros.Inserta(subRubro)
                     Else
                        subRubro.IdSubRubro = Integer.Parse(dtSubRubros.Rows(0)("IdSubRubro").ToString())
                     End If

                     ' Verifico que en la planilla se haya ingresado un SubSubRubro
                     If Not String.IsNullOrWhiteSpace(dr("NombreSubSubRubro").ToString()) Then
                        'SubSub Rubro
                        Dim dtSubSubRubros = rSubSubRubros.GetPorNombre(rubro.IdRubro, subSubRubro.IdSubRubro, dr("NombreSubSubRubro").ToString())
                        If dtSubSubRubros.Rows.Count = 0 Then
                           subSubRubro.IdSubSubRubro = Integer.Parse(rSubSubRubros.GetCodigoMaximo(0).ToString()) + 1
                           subSubRubro.NombreSubSubRubro = dr("NombreSubSubRubro").ToString.Trim()
                           subSubRubro.IdSubRubro = subRubro.IdSubRubro
                           rSubSubRubros._Insertar(subSubRubro)
                        Else
                           subSubRubro.IdSubSubRubro = Integer.Parse(dtSubSubRubros.Rows(0)("IdSubSubRubro").ToString())
                        End If

                     End If
                  End If
               End If

               '-------------------------------------------------------------------------------


               '-------------------------------------------------------------------------------

               'Si el producto que estoy leyendo no existe, la doy de alta.
               'dtProductos = oProductos.GetPorCodigo(dr("CodigoProducto").ToString.Trim(), IdSucursal, 0)
               Dim existeProducto = oProductos.Existe(dr("CodigoProducto").ToString.Trim())

               If existeProducto Then
                  'Seteo los campos adicionales (MesesGarantia, AfectaStock, Activo, Lote, Serie, etc)
                  producto = oProductos.GetUno(dr("CodigoProducto").ToString.Trim())
               End If

               '# Cód. Producto Numérico
               producto.IdProducto = dr("CodigoProducto").ToString.Trim()
               If IsNumeric(dr("IdProductoNumerico")) Then
                  producto.IdProductoNumerico = dr.Field(Of Long)("IdProductoNumerico")
               Else
                  producto.IdProductoNumerico = Nothing
               End If

               If Strings.Trim(dr("NombreProducto").ToString.Trim() & " " & dr("NombreProducto2").ToString()).Length > AnchoNombreProducto Then
                  producto.NombreProducto = Strings.Trim(dr("NombreProducto").ToString.Trim() & " " & dr("NombreProducto2").ToString()).Remove(AnchoNombreProducto)
               Else
                  producto.NombreProducto = Strings.Trim(dr("NombreProducto").ToString.Trim() & " " & dr("NombreProducto2").ToString())
               End If
               '-- REG-43560.- ------------------------------------------------
               producto.UnidadDeMedidaCompra = producto.UnidadDeMedida
               producto.UnidadDeMedidaProduccion = producto.UnidadDeMedida
               '---------------------------------------------------------------
               producto.IdMarca = marca.IdMarca
               producto.IdRubro = rubro.IdRubro

               If Not String.IsNullOrWhiteSpace(dr("NombreSubRubro").ToString()) Then
                  producto.IdSubRubro = subRubro.IdSubRubro
               End If

               If Not String.IsNullOrWhiteSpace(dr("NombreSubSubRubro").ToString()) Then
                  producto.IdSubSubRubro = subSubRubro.IdSubSubRubro
               End If

               producto.Usuario = usuario
               producto.Alicuota = Decimal.Parse(dr("IVA").ToString())   'ProductoIVA
               producto.CodigoDeBarras = dr("CodigoDeBarras").ToString.Trim()
               producto.Moneda = New Reglas.Monedas(da).GetUna(Integer.Parse(IIf(dr("Moneda").ToString.Trim() = "Pesos", 1, 2).ToString()))

               If Not String.IsNullOrWhiteSpace(dr("NombreProveedorHabitual").ToString()) And Not String.IsNullOrWhiteSpace(dr("CodigoProductoProveedorHabitual").ToString()) Then
                  producto.Proveedor = rProveedor.GetUnoPorNombre(dr.Field(Of String)("NombreProveedorHabitual"), True) ' # Busco el proveedor por Código Exacto

                  If producto.Proveedor.IdProveedor <> 0 Then
                     If producto.ProductoProveedorHabitual Is Nothing Then
                        producto.ProductoProveedorHabitual = New Entidades.ProductoProveedor()
                     End If
                     producto.ProductoProveedorHabitual.IdProveedor = producto.Proveedor.IdProveedor
                     producto.ProductoProveedorHabitual.IdProducto = producto.IdProducto
                     producto.ProductoProveedorHabitual.CodigoProductoProveedor = dr("CodigoProductoProveedorHabitual").ToString()
                  End If

               End If

               Dim nombreDeposito = dr.Field(Of String)("NombreDeposito")
               Dim deposito = If(String.IsNullOrWhiteSpace(nombreDeposito), Nothing, rDeposito.GetDepositoNombre(actual.Sucursal.IdSucursal, nombreDeposito))
               Dim nombreUbicacion = dr.Field(Of String)("NombreUbicacion")

               Dim ubicacion = If(String.IsNullOrWhiteSpace(nombreUbicacion), Nothing, rUbicacion.GetUbicacionNombres(actual.Sucursal.IdSucursal, nombreDeposito, nombreUbicacion))

               producto.IdDeposito = If(deposito Is Nothing, 0, deposito.IdDeposito)
               producto.IdUbicacion = If(ubicacion Is Nothing, 0, ubicacion.IdUbicacion)

               If Not existeProducto Then

                  'Producto.IdProducto = oProductos.GetCodigoMaximo() + 1

                  producto.IdSucursal = idSucursal
                  producto.Tamano = 1
                  producto.UnidadDeMedida.IdUnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
                  producto.Conversion = 1
                  producto.MesesGarantia = 0
                  producto.AfectaStock = True
                  producto.IdTipoImpuesto = "IVA"
                  producto.EsServicio = False
                  'PE-31388
                  producto.PublicarEnWeb = Publicos.ProductoPublicarWebCarrito

                  producto.PublicarEnTiendaNube = Publicos.ProductoPublicarTiendaNube
                  producto.PublicarEnMercadoLibre = Publicos.ProductoPublicarMercadoLibre
                  producto.PublicarEnArborea = Publicos.ProductoPublicarArborea
                  producto.PublicarListaDePreciosClientes = Publicos.ProductoPublicarListaPrecioClientes
                  producto.PublicarEnBalanza = Publicos.ProductoPublicarBalanza
                  producto.PublicarEnEmpresarial = Publicos.ProductoPublicarAppEmpresarial
                  producto.PublicarEnGestion = Publicos.ProductoPublicarAppGestion
                  producto.PublicarEnSincronizacionSucursal = Publicos.ProductoPublicarSincronizacionSucursal

                  producto.EsDeVentas = True
                  producto.EsDeCompras = True
                  producto.EsCompuesto = False
                  producto.DescontarStockComponentes = False
                  producto.CodigoDeBarrasConPrecio = False
                  producto.PermiteModificarDescripcion = False
                  producto.PagaIngresosBrutos = True
                  producto.Embalaje = 1
                  producto.Kilos = 0
                  producto.FacturacionCantidadNegativa = False
                  producto.SolicitaEnvase = False
                  producto.AlertaDeCaja = False
                  producto.EsRetornable = False
                  producto.Observacion = ""
                  producto.IdModelo = 0
                  producto.EsOferta = "NO"
                  producto.IncluirExpensas = False
                  producto.Orden = 1

                  If blnProductoUtilizaNombreCorto Then
                     producto.nombreCorto = Strings.Left(dr("nombreProducto").ToString.Trim, 30)
                  Else
                     producto.nombreCorto = ""
                  End If

                  producto.Activo = True
                  producto.PrecioPorEmbalaje = False
                  producto.UnidHasta1 = 0
                  producto.UnidHasta2 = 0
                  producto.UnidHasta3 = 0
                  producto.UnidHasta4 = 0
                  producto.UnidHasta5 = 0
                  producto.UHPorc1 = 0
                  producto.UHPorc2 = 0
                  producto.UHPorc3 = 0
                  producto.UHPorc4 = 0
                  producto.UHPorc5 = 0
                  producto.ObservacionCompras = ""
                  producto.SolicitaPrecioVentaPorTamano = False

                  producto.EsComercial = True

                  oProductos.Inserta(producto, idFuncion)

                  prodSuc = rProdSuc._GetUno(idSucursal, producto.IdProducto)
                  With prodSuc
                     .Usuario = usuario
                     .PrecioFabrica = 0
                     .PrecioCosto = Decimal.Parse(dr("PrecioCosto").ToString())
                     '--------------------------------------------------------------
                     .IdDepositoDefecto = ubicacion.IdDeposito
                     .IdUbicacionDefecto = ubicacion.IdUbicacion
                     '--------------------------------------------------------------
                     .PuntoDePedido = 0
                     .StockMinimo = 0
                  End With
               Else

                  oProductos.Actualiza(producto, _actualizaImagen:=False, idFuncion:=idFuncion, fuerzaActualizacionPrecio:=False)

                  If Not String.IsNullOrWhiteSpace(dr("NombreProveedorHabitual").ToString()) And Not String.IsNullOrWhiteSpace(dr("CodigoProductoProveedorHabitual").ToString()) Then
                     rProductoProveedor.ActualizaCodigoProductoProveedor(producto.Proveedor.IdProveedor, producto.IdProducto, dr("CodigoProductoProveedorHabitual").ToString())
                  End If

                  prodSuc = rProdSuc._GetUno(idSucursal, producto.IdProducto)

                  With prodSuc
                     .Usuario = usuario
                     .PrecioFabrica = 0
                     .PrecioCosto = Decimal.Parse(dr("PrecioCosto").ToString())
                     '--------------------------------------------------------------
                     .IdDepositoDefecto = ubicacion.IdDeposito
                     .IdUbicacionDefecto = ubicacion.IdUbicacion
                     '--------------------------------------------------------------
                  End With
               End If


               '-.PE-32567.- Historial de Precios -- Se inserta un registro por cada insert o update de producto
               rHistPrec.Inserta(prodSuc, idFuncion)



               Dim dt1 As DataTable = New Reglas.Sucursales().GetAll()

               If Publicos.PreciosUnificar Then

                  For Each dr1 As DataRow In dt1.Rows
                     prodSuc.IdSucursal = Integer.Parse(dr1("IdSucursal").ToString())
                     prodSuc.Sucursal.Id = Integer.Parse(dr1("IdSucursal").ToString())
                     prodSuc.Sucursal.IdSucursal = Integer.Parse(dr1("IdSucursal").ToString())

                     'If idListaDePrecios = 0 Then
                     '   oProdSuc.Actualiza(ProdSuc, idFuncion)
                     'Else
                     rProdSuc.ActualizaPrecioCosto(prodSuc, idFuncion)
                     'End If

                     'Borro el Historial que se Genero, cada corrida Genera muchos registros
                     rHistPrec.Borra(prodSuc, idListaDePrecios, idFuncion)

                     'Falto Siempre o algo se cambio que hace falta.
                     sqlPSP.ProductosSucursalesPrecios_U(producto.IdProducto, Integer.Parse(dr1("IdSucursal").ToString()), idListaDePrecios, Decimal.Parse(dr("PrecioVenta").ToString()), Date.Now, usuario)

                  Next

               Else
                  'If idListaDePrecios = 0 Then
                  '   oProdSuc.Actualiza(ProdSuc, idFuncion)
                  'Else
                  rProdSuc.ActualizaPrecioCosto(prodSuc, idFuncion)
                  'End If

                  'Borro el Historial que se Genero, cada corrida Genera muchos registros
                  'oHistPrec.Borra(ProdSuc, idListaDePrecios, idFuncion) 'Se comenta por el pendiente '-.PE-33132.- porque deberia quedar un registro de los cambios que se realizan en los productos.

                  sqlPSP.ProductosSucursalesPrecios_U(producto.IdProducto, idSucursal, idListaDePrecios, Decimal.Parse(dr("PrecioVenta").ToString()), Date.Now, usuario)
               End If

            End If

         Next

         da.CommitTransaction()

      Catch ex As Exception
         BarraProg.Value = 0
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub ImportarProductos(idSucursal As Integer, datos As DataTable, usuario As String, dtListasDePrecios As DataTable,
                                redondeoPrecioVenta As Integer, realizaAjusteA As Boolean, ajusteA As Integer,
                                BarraProg As System.Windows.Forms.ProgressBar, tiempo As System.Windows.Forms.ToolStripLabel, registroactual As System.Windows.Forms.ToolStripLabel,
                                idProveedor As Long, idFuncion As String, fuerzaActualizacionPrecio As Boolean)
      Try
         da.OpenConection()

         'Dim ProductoIVA As Decimal = Decimal.Parse(New Reglas.Parametros().GetValor("PRODUCTOIVA"))

         'Encontre que en la base de Bernabe faltaban registros. 
         'Era un error de la baja logica en productos, porque estaria bien que faltan si no esta activo, pero si se reactiva no lo cargaba. 
         'Fue corregido pero por las dudas lo hago.
         Dim sqlPSP As SqlServer.ProductosSucursalesPrecios = New SqlServer.ProductosSucursalesPrecios(da)
         sqlPSP.ProductosSucursalesPrecios_IFaltante("", usuario)

         Dim dt As DataTable = datos
         Dim precioCosto As Decimal = 0

         Dim oMarcas As Eniac.Reglas.Marcas = New Eniac.Reglas.Marcas(da)
         Dim dtMarcas As DataTable = New DataTable
         Dim Marca As Entidades.Marca = New Entidades.Marca

         Dim oRubros As Eniac.Reglas.Rubros = New Eniac.Reglas.Rubros(da)
         Dim dtRubros As DataTable = New DataTable
         Dim Rubro As Entidades.Rubro = New Entidades.Rubro

         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos(da)
         Dim ExisteProducto As Boolean
         Dim Producto As Entidades.Producto = New Entidades.Producto

         Dim oProdSuc As Eniac.Reglas.ProductosSucursales = New Eniac.Reglas.ProductosSucursales(da)
         Dim ProdSuc As Entidades.ProductoSucursal = New Entidades.ProductoSucursal

         Dim oProdSucPrecios As Eniac.Reglas.ProductosSucursales = New Eniac.Reglas.ProductosSucursales(da)

         Dim oHistPrec As Eniac.Reglas.HistorialPrecios = New Eniac.Reglas.HistorialPrecios(da)

         Dim AnchoNombreProducto As Integer = New Reglas.Publicos().GetAnchoCampo("Productos", "NombreProducto")
         Dim blnProductoUtilizaNombreCorto As Boolean = Publicos.ProductoUtilizaNombreCorto

         Dim sqlPP As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(da)

         Dim i As Integer = 0

         BarraProg.Maximum = dt.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0

         'oProductos.InactivarProductos(idMarca)

         Dim HoraInicio As DateTime = Now

         For Each dr As DataRow In dt.Rows

            i += 1
            BarraProg.Value = i
            tiempo.Text = Now.Subtract(HoraInicio).ToString()
            registroactual.Text = i.ToString() + "/"

            'If i = 150 Then
            '   Stop
            'End If

            'Threading.Thread.Sleep(10)

            System.Windows.Forms.Application.DoEvents()

            If Boolean.Parse(dr("Importa").ToString()) Then

               'Si la Marca que estoy leyendo no existe, la doy de alta.

               dtMarcas = oMarcas.GetPorNombreExacto(dr("NombreMarca").ToString())

               If dtMarcas.Rows.Count = 0 Then
                  Marca.IdMarca = oMarcas.GetCodigoMaximo() + 1
                  Marca.NombreMarca = dr("NombreMarca").ToString.Trim()

                  oMarcas.Inserta(Marca)

               Else
                  Marca.IdMarca = Integer.Parse(dtMarcas.Rows(0)("IdMarca").ToString())
               End If

               '-------------------------------------------------------------------------------


               'Si el Rubro que estoy leyendo no existe, lo doy de alta.

               dtRubros = oRubros.GetPorNombreExacto(dr("NombreRubro").ToString())

               If dtRubros.Rows.Count = 0 Then
                  Rubro.IdRubro = oRubros.GetCodigoMaximo() + 1
                  Rubro.NombreRubro = dr("NombreRubro").ToString.Trim()

                  oRubros.Inserta(Rubro)
               Else
                  Rubro.IdRubro = Integer.Parse(dtRubros.Rows(0)("IdRubro").ToString())
               End If

               '-------------------------------------------------------------------------------

               'Si el producto que estoy leyendo no existe, la doy de alta.
               'dtProductos = oProductos.GetPorCodigo(dr("CodigoProducto").ToString.Trim(), IdSucursal, 0)
               ExisteProducto = oProductos.Existe(dr("CodigoProducto").ToString.Trim())

               If ExisteProducto Then
                  'Seteo los campos adicionales (MesesGarantia, AfectaStock, Activo, Lote, Serie, etc)
                  Producto = oProductos.GetUno(dr("CodigoProducto").ToString.Trim())
               End If


               Try
                  da.BeginTransaction()

                  If IsNumeric(dr("IdProductoNumerico")) Then
                     Producto.IdProductoNumerico = dr.Field(Of Long)("IdProductoNumerico")
                  Else
                     Producto.IdProductoNumerico = Nothing
                  End If

                  If Not ExisteProducto Then

                     'Producto.IdProducto = oProductos.GetCodigoMaximo() + 1

                     Producto.IdProducto = dr("CodigoProducto").ToString.Trim()

                     If Strings.Trim(dr("NombreProducto").ToString.Trim() & " " & dr("NombreProducto2").ToString()).Length > AnchoNombreProducto Then
                        Producto.NombreProducto = Strings.Trim(dr("NombreProducto").ToString.Trim() & " " & dr("NombreProducto2").ToString()).Remove(AnchoNombreProducto)
                     Else
                        Producto.NombreProducto = Strings.Trim(dr("NombreProducto").ToString.Trim() & " " & dr("NombreProducto2").ToString())
                     End If

                     '# En caso que el nombre del producto contenga una ' la reemplazo por `.
                     Producto.NombreProducto = Producto.NombreProducto.Replace("'", "`")

                     Producto.IdMarca = Marca.IdMarca
                     Producto.IdRubro = Rubro.IdRubro
                     Producto.Usuario = usuario
                     If Not String.IsNullOrEmpty(dr("IVA").ToString()) Then
                        Producto.Alicuota = Decimal.Parse(dr("IVA").ToString())   'ProductoIVA
                     End If
                     Producto.CodigoDeBarras = dr("CodigoDeBarras").ToString.Trim()
                     Producto.Moneda = New Reglas.Monedas(da).GetUna(Integer.Parse(IIf(dr("Moneda").ToString.Trim() = "Pesos", 1, 2).ToString()))


                     Producto.IdSucursal = idSucursal
                     Producto.Tamano = 1
                     Producto.UnidadDeMedida.IdUnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
                     Producto.MesesGarantia = 0
                     Producto.AfectaStock = True
                     Producto.IdTipoImpuesto = "IVA"
                     Producto.EsServicio = False
                     'PE-31388
                     Producto.PublicarEnWeb = Publicos.ProductoPublicarWebCarrito

                     Producto.PublicarEnTiendaNube = Publicos.ProductoPublicarTiendaNube
                     Producto.PublicarEnMercadoLibre = Publicos.ProductoPublicarMercadoLibre
                     Producto.PublicarEnArborea = Publicos.ProductoPublicarArborea
                     Producto.PublicarListaDePreciosClientes = Publicos.ProductoPublicarListaPrecioClientes
                     Producto.PublicarEnBalanza = Publicos.ProductoPublicarBalanza
                     Producto.PublicarEnEmpresarial = Publicos.ProductoPublicarAppEmpresarial
                     Producto.PublicarEnGestion = Publicos.ProductoPublicarAppGestion
                     Producto.PublicarEnSincronizacionSucursal = Publicos.ProductoPublicarSincronizacionSucursal
                     Producto.EsDeVentas = True
                     Producto.EsDeCompras = True
                     Producto.EsCompuesto = False
                     Producto.DescontarStockComponentes = False
                     Producto.CodigoDeBarrasConPrecio = False
                     Producto.PermiteModificarDescripcion = False
                     Producto.PagaIngresosBrutos = True
                     Producto.Embalaje = 1
                     Producto.Kilos = 0
                     Producto.FacturacionCantidadNegativa = False
                     Producto.SolicitaEnvase = False
                     Producto.AlertaDeCaja = False
                     Producto.EsRetornable = False
                     Producto.Observacion = ""
                     Producto.IdModelo = 0
                     Producto.EsObservacion = False
                     Producto.PrecioPorEmbalaje = False
                     Producto.UnidHasta1 = 0
                     Producto.UnidHasta2 = 0
                     Producto.UnidHasta3 = 0
                     Producto.UnidHasta4 = 0
                     Producto.UnidHasta5 = 0
                     Producto.UHPorc1 = 0
                     Producto.UHPorc2 = 0
                     Producto.UHPorc3 = 0
                     Producto.UHPorc4 = 0
                     Producto.UHPorc5 = 0
                     Producto.EsOferta = "NO"
                     Producto.Orden = 1
                     Producto.IncluirExpensas = False
                     Producto.ObservacionCompras = ""
                     Producto.SolicitaPrecioVentaPorTamano = False
                     Producto.UnidadDeMedidaCompra.IdUnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
                     Producto.UnidadDeMedidaProduccion.IdUnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()

                     If blnProductoUtilizaNombreCorto Then
                        Producto.nombreCorto = Strings.Left(dr("nombreProducto").ToString.Trim, 30)
                     Else
                        Producto.nombreCorto = ""
                     End If

                     Producto.Activo = True

                     Producto.Precios = dtListasDePrecios.Copy()

                     Dim preciosProductos As DataTable = New SqlServer.Productos(da).GetPreciosProducto(Producto.IdProducto, actual.Sucursal.IdSucursal)

                     For Each drtemp As DataRow In preciosProductos.Rows
                        For Each drprecios As DataRow In Producto.Precios.Rows
                           If drtemp(ListaPreciosColumns.IdListaPrecios.ToString()).ToString() = drprecios(ListaPreciosColumns.IdListaPrecios.ToString()).ToString() Then
                              drprecios(ListaPreciosColumns.PorcentajeCosto.ToString()) = drtemp(ListaPreciosColumns.PorcentajeCosto.ToString())
                              drprecios(ListaPreciosColumns.PrecioCosto.ToString()) = drtemp(ListaPreciosColumns.PrecioCosto.ToString())
                              drprecios(ListaPreciosColumns.PrecioVenta.ToString()) = drtemp(ListaPreciosColumns.PrecioVenta.ToString())
                              drprecios(ListaPreciosColumns.PrecioVentaBase.ToString()) = drtemp(ListaPreciosColumns.PrecioVentaBase.ToString())
                           End If
                        Next
                     Next

                     If idProveedor <> 0 Then
                        Producto.Proveedor = New Reglas.Proveedores().GetUno(idProveedor)
                        Producto.ProductoProveedorHabitual = New Entidades.ProductoProveedor()
                        Producto.ProductoProveedorHabitual.IdProveedor = Producto.Proveedor.IdProveedor
                        Producto.ProductoProveedorHabitual.IdProducto = Producto.IdProducto
                        Producto.ProductoProveedorHabitual.CodigoProductoProveedor = dr("CodigoProveedor").ToString()
                        Producto.ProductoProveedorHabitual.UltimoPrecioCompra = 0

                        Producto.ProductoProveedorHabitual.UltimaFechaCompra = Date.Now()

                        If Not String.IsNullOrEmpty(dr("PrecioCompra").ToString()) Then
                           Producto.ProductoProveedorHabitual.UltimoPrecioFabrica = Decimal.Parse(dr("PrecioCompra").ToString())
                        End If
                        If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc1").ToString()) Then
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc1").ToString())
                        Else
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = 0
                        End If
                        If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc2").ToString()) Then
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
                        Else
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = 0
                        End If
                        If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc3").ToString()) Then
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = Decimal.Parse(dr("DescuentoRecargoPorc3").ToString())
                        Else
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = 0
                        End If
                        If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc4").ToString()) Then
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = Decimal.Parse(dr("DescuentoRecargoPorc4").ToString())
                        Else
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = 0
                        End If
                     End If

                     precioCosto = 0
                     Decimal.TryParse(dr("PrecioCosto").ToString(), precioCosto)

                     RecalculaPrecios(Producto.Precios, Producto.IdProducto, precioCosto, redondeoPrecioVenta, realizaAjusteA, ajusteA)

                     Producto.PrecioCosto = precioCosto

                     oProductos.Inserta(Producto, idFuncion)

                     '' ''ProdSuc = oProdSuc._GetUno(IdSucursal, Producto.IdProducto)
                     '' ''ProdSuc.Usuario = usuario
                     '' ''ProdSuc.PrecioFabrica = 0
                     '' ''ProdSuc.PrecioCosto = Decimal.Parse(dr("PrecioCosto").ToString())

                     '' ''If IdListaDePrecios = 0 Then

                     '' ''   ProdSuc.PrecioVenta = Decimal.Parse(dr("PrecioVenta").ToString())
                     '' ''Else
                     '' ''   ProdSuc.PrecioVenta = 0
                     '' ''End If

                     '' ''ProdSuc.PuntoDePedido = 0
                     '' ''ProdSuc.StockMinimo = 0

                     '-.PE-32568.- Historial de Precios -- Se inserta un registro por cada insert o update de producto
                     ProdSuc = oProdSuc._GetUno(idSucursal, Producto.IdProducto)

                     oHistPrec.Inserta(ProdSuc, idFuncion)

                     'inserto la relacion producto-proveedor
                     If idProveedor <> 0 Then
                        sqlPP.ProductosProveedores_I(idProveedor, Producto.IdProducto,
                                                     Producto.ProductoProveedorHabitual.CodigoProductoProveedor,
                                                     Producto.ProductoProveedorHabitual.UltimoPrecioCompra,
                                                     Producto.ProductoProveedorHabitual.UltimaFechaCompra,
                                                     Producto.ProductoProveedorHabitual.UltimoPrecioFabrica,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc5,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc6)
                     End If

                  Else
                     Producto.Precios = dtListasDePrecios.Copy()

                     Dim preciosProductos As DataTable = New SqlServer.Productos(da).GetPreciosProducto(Producto.IdProducto, actual.Sucursal.IdSucursal)

                     For Each drtemp As DataRow In preciosProductos.Rows
                        For Each drprecios As DataRow In Producto.Precios.Rows
                           If drtemp(ListaPreciosColumns.IdListaPrecios.ToString()).ToString() = drprecios(ListaPreciosColumns.IdListaPrecios.ToString()).ToString() Then
                              drprecios(ListaPreciosColumns.PorcentajeCosto.ToString()) = drtemp(ListaPreciosColumns.PorcentajeCosto.ToString())
                              drprecios(ListaPreciosColumns.PrecioCosto.ToString()) = drtemp(ListaPreciosColumns.PrecioCosto.ToString())
                              drprecios(ListaPreciosColumns.PrecioVenta.ToString()) = drtemp(ListaPreciosColumns.PrecioVenta.ToString())
                              drprecios(ListaPreciosColumns.PrecioVentaBase.ToString()) = drtemp(ListaPreciosColumns.PrecioVentaBase.ToString())
                           End If
                        Next
                     Next


                     If idProveedor <> 0 Then
                        If Producto.Proveedor Is Nothing Then
                           Producto.Proveedor = New Entidades.Proveedor()
                        End If
                        Producto.Proveedor = New Reglas.Proveedores().GetUno(idProveedor)

                        If Producto.ProductoProveedorHabitual Is Nothing Then
                           Producto.ProductoProveedorHabitual = New Entidades.ProductoProveedor()
                           Producto.ProductoProveedorHabitual.UltimaFechaCompra = Nothing
                           Producto.ProductoProveedorHabitual.UltimoPrecioCompra = Nothing
                        End If

                        'Producto.ProductoProveedorHabitual = New Entidades.ProductoProveedor()
                        Producto.ProductoProveedorHabitual.IdProveedor = Producto.Proveedor.IdProveedor
                        Producto.ProductoProveedorHabitual.IdProducto = Producto.IdProducto
                        Producto.ProductoProveedorHabitual.CodigoProductoProveedor = dr("CodigoProveedor").ToString()

                        Producto.ProductoProveedorHabitual.UltimaFechaCompra = Date.Now()

                        If Not String.IsNullOrEmpty(dr("PrecioCompra").ToString()) Then
                           Producto.ProductoProveedorHabitual.UltimoPrecioFabrica = Decimal.Parse(dr("PrecioCompra").ToString())
                        End If
                        If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc1").ToString()) Then
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc1").ToString())
                        Else
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = 0
                        End If
                        If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc2").ToString()) Then
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
                        Else
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = 0
                        End If
                        If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc3").ToString()) Then
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = Decimal.Parse(dr("DescuentoRecargoPorc3").ToString())
                        Else
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = 0
                        End If
                        If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc4").ToString()) Then
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = Decimal.Parse(dr("DescuentoRecargoPorc4").ToString())
                        Else
                           Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = 0
                        End If
                     End If

                     precioCosto = 0
                     Decimal.TryParse(dr("PrecioCosto").ToString(), precioCosto)
                     Producto.Usuario = usuario

                     RecalculaPrecios(Producto.Precios, Producto.IdProducto, precioCosto, redondeoPrecioVenta, realizaAjusteA, ajusteA)

                     Producto.PrecioCosto = precioCosto

                     oProductos.Actualiza(Producto, _actualizaImagen:=False, idFuncion:=idFuncion, fuerzaActualizacionPrecio:=fuerzaActualizacionPrecio)

                     '' ''ProdSuc = oProdSuc._GetUno(IdSucursal, Producto.IdProducto)

                     ' '' ''ProdSuc.Sucursal.Id = IdSucursal
                     ' '' ''ProdSuc.Producto = Producto
                     ' '' ''ProdSuc.Stock = 0
                     ' '' ''ProdSuc.StockInicial = 0
                     '' ''ProdSuc.Usuario = usuario
                     '' ''ProdSuc.PrecioFabrica = 0
                     '' ''ProdSuc.PrecioCosto = Decimal.Parse(dr("PrecioCosto").ToString())

                     '' ''If IdListaDePrecios = 0 Then
                     '' ''   ProdSuc.PrecioVenta = Decimal.Parse(dr("PrecioVenta").ToString())
                     '' ''Else
                     '' ''   ProdSuc.PrecioVenta = 0
                     '' ''End If

                     ' '' ''ProdSuc.PuntoDePedido = 0  'HACERLO !!
                     ' '' ''ProdSuc.StockMinimo = 0
                     ' '' ''ProdSuc.PuntoDePedido = Decimal.Parse(dr("PuntoDePedido").ToString())
                     ' '' ''ProdSuc.StockMinimo = Decimal.Parse(dr("StockMinimo").ToString())

                     'inserto la relacion producto-proveedor
                     If idProveedor <> 0 Then
                        sqlPP.ProductosProveedores_I(idProveedor, Producto.IdProducto,
                                                     Producto.ProductoProveedorHabitual.CodigoProductoProveedor,
                                                     Producto.ProductoProveedorHabitual.UltimoPrecioCompra,
                                                     Producto.ProductoProveedorHabitual.UltimaFechaCompra,
                                                     Producto.ProductoProveedorHabitual.UltimoPrecioFabrica,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc5,
                                                     Producto.ProductoProveedorHabitual.DescuentoRecargoPorc6)
                     End If

                  End If

                  '' ''If Publicos.PreciosUnificar Then
                  '' ''   Dim dt1 As DataTable = New Reglas.Sucursales().GetAll()

                  '' ''   For Each dr1 As DataRow In dt1.Rows
                  '' ''      ProdSuc.IdSucursal = Integer.Parse(dr1("IdSucursal").ToString())

                  '' ''      oProdSuc.Actualiza(ProdSuc)
                  '' ''      'Borro el Historial que se Genero, cada corrida Genera muchos registros
                  '' ''      oHistPrec.EjecutaSP(ProdSuc, IdListaDePrecios, TipoSP._D)

                  '' ''      'Falto Siempre o algo se cambio que hace falta.
                  '' ''      sqlPSP.ProductosSucursalesPrecios_U(Producto.IdProducto, Integer.Parse(dr1("IdSucursal").ToString()), IdListaDePrecios, Decimal.Parse(dr("PrecioVenta").ToString()), Date.Now, usuario)

                  '' ''   Next

                  '' ''Else
                  '' ''   oProdSuc.Actualiza(ProdSuc)

                  '' ''   'Borro el Historial que se Genero, cada corrida Genera muchos registros
                  '' ''   oHistPrec.EjecutaSP(ProdSuc, IdListaDePrecios, TipoSP._D)

                  '' ''   sqlPSP.ProductosSucursalesPrecios_U(Producto.IdProducto, IdSucursal, IdListaDePrecios, Decimal.Parse(dr("PrecioVenta").ToString()), Date.Now, usuario)
                  '' ''End If
                  da.CommitTransaction()
               Catch
                  da.RollbakTransaction()
                  Throw
               End Try
            End If
         Next

         ''da.CommitTransaction()

      Catch
         BarraProg.Value = 0
         ''da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub


   Public Sub ImportarProductosAiroldi(idSucursal As Integer, datos As DataTable, idMarca As Integer, usuario As String, barraProg As System.Windows.Forms.ProgressBar, idFuncion As String)
      Try

         da.OpenConection()
         da.BeginTransaction()

         'Encontre que en la base de Bernabe faltaban registros. 
         'Era un error de la baja logica en productos, porque estaria bien que faltan si no esta activo, pero si se reactiva no lo cargaba. 
         'Fue corregido pero por las dudas lo hago.
         Dim sqlPSP As SqlServer.ProductosSucursalesPrecios = New SqlServer.ProductosSucursalesPrecios(da)
         sqlPSP.ProductosSucursalesPrecios_IFaltante("", usuario)

         Dim dt As DataTable = datos

         Dim oRubros As Eniac.Reglas.Rubros = New Eniac.Reglas.Rubros(da)
         Dim dtRubros As DataTable = New DataTable
         Dim Rubro As Entidades.Rubro = New Entidades.Rubro

         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos(da)
         'Dim dtProductos As DataTable = New DataTable
         Dim ExisteProducto As Boolean
         Dim Producto As Entidades.Producto = New Entidades.Producto

         Dim oProdSuc As Eniac.Reglas.ProductosSucursales = New Eniac.Reglas.ProductosSucursales(da)
         Dim ProdSuc As Entidades.ProductoSucursal = New Entidades.ProductoSucursal

         Dim oHistPrec As Eniac.Reglas.HistorialPrecios = New Eniac.Reglas.HistorialPrecios(da)

         Dim AnchoNombreProducto As Integer = New Reglas.Publicos().GetAnchoCampo("Productos", "NombreProducto")
         Dim blnProductoUtilizaNombreCorto As Boolean = Publicos.ProductoUtilizaNombreCorto

         Dim i As Integer = 0

         barraProg.Maximum = dt.Rows.Count
         barraProg.Minimum = 0
         barraProg.Value = 0

         oProductos.InactivarProductos(idMarca) 'Porque pueden no venir algunos.

         For Each dr As DataRow In dt.Rows

            i += 1
            barraProg.Value = i

            'Threading.Thread.Sleep(10)

            'System.Windows.Forms.Application.DoEvents()

            'Si el rubro que estoy leyendo no existe, la doy de alta.
            dtRubros = oRubros.GetPorNombreExacto(dr("NombreRubro").ToString())

            If dtRubros.Rows.Count = 0 Then
               Rubro.IdRubro = oRubros.GetCodigoMaximo() + 1
               Rubro.NombreRubro = dr("NombreRubro").ToString.Trim()

               oRubros.Inserta(Rubro)
            Else
               Rubro.IdRubro = Integer.Parse(dtRubros.Rows(0)("IdRubro").ToString())
            End If

            'Si el producto que estoy leyendo no existe, la doy de alta.
            'dtProductos = oProductos.GetPorCodigo(dr("CodigoProducto").ToString.Trim(), IdSucursal, 0)
            ExisteProducto = oProductos.Existe(dr("CodigoProducto").ToString.Trim())

            If ExisteProducto Then
               'Seteo los campos adicionales (MesesGarantia, AfectaStock, Activo, Lote, Serie, etc)
               Producto = oProductos.GetUno(dr("CodigoProducto").ToString.Trim())
            End If

            Producto.IdProducto = dr("CodigoProducto").ToString.Trim()

            If dr("NombreProducto").ToString.Trim.Length > AnchoNombreProducto Then
               Producto.NombreProducto = Strings.Left(dr("NombreProducto").ToString.Trim(), AnchoNombreProducto)
            Else
               Producto.NombreProducto = dr("NombreProducto").ToString.Trim()
            End If

            Producto.IdMarca = idMarca
            Producto.IdRubro = Rubro.IdRubro
            Producto.Usuario = usuario

            Producto.Alicuota = Decimal.Parse(dr("IVA").ToString())   'ProductoIVA
            'Producto.CodigoDeBarras = dr("CodigoDeBarras").ToString.Trim()
            Producto.Moneda = New Reglas.Monedas(da).GetUna(Integer.Parse(IIf(dr("MonedaConvertida").ToString.Trim() = "Pesos", 1, 2).ToString()))

            Producto.Activo = True

            'If dtProductos.Rows.Count = 0 Then
            If Not ExisteProducto Then

               'Producto.IdProducto = oProductos.GetCodigoMaximo() + 1

               Producto.IdSucursal = idSucursal
               Producto.Tamano = 0
               Producto.UnidadDeMedida.IdUnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
               Producto.MesesGarantia = 0
               Producto.AfectaStock = True
               Producto.IdTipoImpuesto = "IVA"
               Producto.EsServicio = False
               Producto.PublicarEnWeb = False
               Producto.EsDeVentas = True
               Producto.EsDeCompras = True
               Producto.EsCompuesto = False
               Producto.DescontarStockComponentes = False
               'Producto.Moneda = New Reglas.Monedas(da).GetUna(1)
               Producto.CodigoDeBarrasConPrecio = False
               Producto.PermiteModificarDescripcion = False
               Producto.PagaIngresosBrutos = True
               Producto.Embalaje = 1
               Producto.Kilos = 0
               Producto.PublicarListaDePreciosClientes = True
               Producto.FacturacionCantidadNegativa = False
               Producto.SolicitaEnvase = False
               Producto.EsRetornable = False
               Producto.AlertaDeCaja = False
               Producto.Observacion = ""

               If blnProductoUtilizaNombreCorto Then
                  Producto.nombreCorto = Strings.Left(dr("nombreProducto").ToString.Trim, 30)
               Else
                  Producto.nombreCorto = ""
               End If

               oProductos.Inserta(Producto, idFuncion)

               ProdSuc = oProdSuc._GetUno(idSucursal, Producto.IdProducto)
               ProdSuc.Sucursal.Id = idSucursal
               ProdSuc.Usuario = usuario
               ProdSuc.PrecioCosto = Decimal.Parse(dr("CostoFinal").ToString())
               ProdSuc.PuntoDePedido = 0
               ProdSuc.StockMinimo = 0

            Else

               oProductos.Actualiza(Producto, _actualizaImagen:=False, idFuncion:=idFuncion, fuerzaActualizacionPrecio:=False)

               ProdSuc = oProdSuc._GetUno(idSucursal, Producto.IdProducto)

               'ProdSuc.Sucursal.Id = IdSucursal
               'ProdSuc.Producto = Producto
               'ProdSuc.Stock = 0
               'ProdSuc.StockInicial = 0
               ProdSuc.Usuario = usuario
               ProdSuc.PrecioFabrica = 0
               ProdSuc.PrecioCosto = Decimal.Parse(dr("CostoFinal").ToString())
               'ProdSuc.PrecioVenta = 0

               'ProdSuc.PuntoDePedido = 0  'HACERLO !!
               'ProdSuc.StockMinimo = 0
               'ProdSuc.PuntoDePedido = Decimal.Parse(dr("PuntoDePedido").ToString())
               'ProdSuc.StockMinimo = Decimal.Parse(dr("StockMinimo").ToString())

            End If

            oProdSuc.Actualiza(ProdSuc, idFuncion)

            'Borro el Historial que se Genero, cada corrida Genera muchos registros
            oHistPrec.Borra(ProdSuc, 0, idFuncion)

            'Falto Siempre o algo se cambio que hace falta.
            'sqlPSP.ProductosSucursalesPrecios_U(Producto.IdProducto, IdSucursal, 0, Decimal.Parse(dr("PrecioVenta").ToString()), Date.Now, usuario)
            sqlPSP.ProductosSucursalesPrecios_U(Producto.IdProducto, idSucursal, 0, 0, Date.Now, usuario)

         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub ImportarProductosPlantillas(idSucursal As Integer, datos As DataTable, usuario As String, idListaDePrecios As Integer,
                                          barraProg As System.Windows.Forms.ProgressBar, idProveedor As Long, idFuncion As String,
                                          fuerzaActualizacionPrecio As Boolean)
      Try

         da.OpenConection()
         da.BeginTransaction()

         'Dim ProductoIVA As Decimal = Decimal.Parse(New Reglas.Parametros().GetValor("PRODUCTOIVA"))

         'Encontre que en la base de Bernabe faltaban registros. 
         'Era un error de la baja logica en productos, porque estaria bien que faltan si no esta activo, pero si se reactiva no lo cargaba. 
         'Fue corregido pero por las dudas lo hago.
         Dim sqlPSP As SqlServer.ProductosSucursalesPrecios = New SqlServer.ProductosSucursalesPrecios(da)
         sqlPSP.ProductosSucursalesPrecios_IFaltante("", usuario)

         Dim dt As DataTable = datos

         Dim oMarcas As Eniac.Reglas.Marcas = New Eniac.Reglas.Marcas(da)
         Dim dtMarcas As DataTable = New DataTable
         Dim Marca As Entidades.Marca = New Entidades.Marca

         Dim oRubros As Eniac.Reglas.Rubros = New Eniac.Reglas.Rubros(da)
         Dim dtRubros As DataTable = New DataTable
         Dim Rubro As Entidades.Rubro = New Entidades.Rubro

         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos(da)
         Dim ExisteProducto As Boolean
         Dim Producto As Entidades.Producto = New Entidades.Producto

         Dim oProdSuc As Eniac.Reglas.ProductosSucursales = New Eniac.Reglas.ProductosSucursales(da)
         Dim ProdSuc As Entidades.ProductoSucursal = New Entidades.ProductoSucursal

         Dim oProdSucPrecios As Eniac.Reglas.ProductosSucursales = New Eniac.Reglas.ProductosSucursales(da)

         Dim oHistPrec As Eniac.Reglas.HistorialPrecios = New Eniac.Reglas.HistorialPrecios(da)

         Dim AnchoNombreProducto As Integer = New Reglas.Publicos().GetAnchoCampo("Productos", "NombreProducto")
         Dim blnProductoUtilizaNombreCorto As Boolean = Publicos.ProductoUtilizaNombreCorto

         Dim sqlPP As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(da)

         Dim i As Integer = 0

         barraProg.Maximum = dt.Rows.Count
         barraProg.Minimum = 0
         barraProg.Value = 0

         'oProductos.InactivarProductos(idMarca)

         For Each dr As DataRow In dt.Rows

            i += 1
            barraProg.Value = i

            'If i = 150 Then
            '   Stop
            'End If

            'Threading.Thread.Sleep(10)

            'System.Windows.Forms.Application.DoEvents()

            If Boolean.Parse(dr("Importa").ToString()) Then

               'Si la Marca que estoy leyendo no existe, la doy de alta.

               If dr("NombreMarca").ToString() <> "" Then
                  dtMarcas = oMarcas.GetPorNombreExacto(dr("NombreMarca").ToString())

                  If dtMarcas.Rows.Count = 0 Then
                     Marca.IdMarca = oMarcas.GetCodigoMaximo() + 1
                     Marca.NombreMarca = dr("NombreMarca").ToString.Trim()

                     oMarcas.Inserta(Marca)

                  Else
                     Marca.IdMarca = Integer.Parse(dtMarcas.Rows(0)("IdMarca").ToString())
                  End If
               End If


               '-------------------------------------------------------------------------------


               'Si el Rubro que estoy leyendo no existe, lo doy de alta.

               If dr("NombreRubro").ToString() <> "" Then
                  dtRubros = oRubros.GetPorNombreExacto(dr("NombreRubro").ToString())

                  If dtRubros.Rows.Count = 0 Then
                     Rubro.IdRubro = oRubros.GetCodigoMaximo() + 1
                     Rubro.NombreRubro = dr("NombreRubro").ToString.Trim()

                     oRubros.Inserta(Rubro)
                  Else
                     Rubro.IdRubro = Integer.Parse(dtRubros.Rows(0)("IdRubro").ToString())
                  End If
               End If


               '-------------------------------------------------------------------------------

               'Si el producto que estoy leyendo no existe, la doy de alta.
               'dtProductos = oProductos.GetPorCodigo(dr("CodigoProducto").ToString.Trim(), IdSucursal, 0)
               ExisteProducto = oProductos.Existe(dr("CodigoProducto").ToString.Trim())

               If ExisteProducto Then
                  'Seteo los campos adicionales (MesesGarantia, AfectaStock, Activo, Lote, Serie, etc)
                  Producto = oProductos.GetUno(dr("CodigoProducto").ToString.Trim())
               End If


               If Not ExisteProducto Then
                  Producto.IdProducto = dr("CodigoProducto").ToString.Trim()

                  If Strings.Trim(dr("NombreProducto").ToString.Trim() & " " & dr("NombreProducto2").ToString()).Length > AnchoNombreProducto Then
                     Producto.NombreProducto = Strings.Trim(dr("NombreProducto").ToString.Trim() & " " & dr("NombreProducto2").ToString()).Remove(AnchoNombreProducto)
                  Else
                     Producto.NombreProducto = Strings.Trim(dr("NombreProducto").ToString.Trim() & " " & dr("NombreProducto2").ToString())
                  End If

                  Producto.IdMarca = Marca.IdMarca
                  Producto.IdRubro = Rubro.IdRubro
                  Producto.Usuario = usuario
                  Producto.Alicuota = Decimal.Parse(dr("IVA").ToString())   'ProductoIVA
                  Producto.CodigoDeBarras = dr("CodigoDeBarras").ToString.Trim()

                  Producto.CodigoLargoProducto = dr("CodigoLargoProducto").ToString()
                  If Not String.IsNullOrEmpty(dr("IdProductoNumerico").ToString()) Then
                     Producto.IdProductoNumerico = Long.Parse(dr("IdProductoNumerico").ToString())
                  End If
                  Producto.Observacion = dr("Observacion").ToString()

                  Producto.Moneda = New Reglas.Monedas(da).GetUna(Integer.Parse(IIf(dr("Moneda").ToString.Trim() = "Pesos", 1, 2).ToString()))

                  'Producto.IdProducto = oProductos.GetCodigoMaximo() + 1

                  Producto.IdSucursal = idSucursal
                  Producto.Tamano = 1
                  Producto.UnidadDeMedida.IdUnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
                  Producto.MesesGarantia = 0
                  Producto.AfectaStock = True
                  Producto.IdTipoImpuesto = "IVA"
                  Producto.EsServicio = False
                  Producto.PublicarEnWeb = False
                  Producto.EsDeVentas = True
                  Producto.EsDeCompras = True
                  Producto.EsCompuesto = False
                  Producto.DescontarStockComponentes = False
                  Producto.CodigoDeBarrasConPrecio = False
                  Producto.PermiteModificarDescripcion = False
                  Producto.PagaIngresosBrutos = True
                  Producto.Embalaje = 1
                  Producto.Kilos = 0
                  Producto.PublicarListaDePreciosClientes = True
                  Producto.FacturacionCantidadNegativa = False
                  Producto.SolicitaEnvase = False
                  Producto.AlertaDeCaja = False
                  Producto.EsRetornable = False
                  Producto.IdModelo = 0
                  Producto.EsOferta = "NO"
                  Producto.Orden = 1
                  Producto.IncluirExpensas = False
                  If blnProductoUtilizaNombreCorto Then
                     Producto.nombreCorto = Strings.Left(dr("nombreProducto").ToString.Trim, 30)
                  Else
                     Producto.nombreCorto = ""
                  End If

                  Producto.Activo = True
                  Producto.PrecioPorEmbalaje = False
                  Producto.UnidHasta1 = 0
                  Producto.UnidHasta2 = 0
                  Producto.UnidHasta3 = 0
                  Producto.UnidHasta4 = 0
                  Producto.UnidHasta5 = 0
                  Producto.UHPorc1 = 0
                  Producto.UHPorc2 = 0
                  Producto.UHPorc3 = 0
                  Producto.UHPorc4 = 0
                  Producto.UHPorc5 = 0

                  If idProveedor <> 0 Then
                     Producto.Proveedor = New Reglas.Proveedores().GetUno(idProveedor)
                     Producto.ProductoProveedorHabitual = New Entidades.ProductoProveedor()
                     Producto.ProductoProveedorHabitual.IdProveedor = Producto.Proveedor.IdProveedor
                     Producto.ProductoProveedorHabitual.IdProducto = Producto.IdProducto
                     Producto.ProductoProveedorHabitual.CodigoProductoProveedor = dr("CodigoProveedor").ToString()
                     Producto.ProductoProveedorHabitual.UltimoPrecioCompra = 0
                     If Not String.IsNullOrEmpty(dr("PrecioCompra").ToString()) Then
                        Producto.ProductoProveedorHabitual.UltimoPrecioFabrica = Decimal.Parse(dr("PrecioCompra").ToString())
                     End If
                     If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc1").ToString()) Then
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc1").ToString())
                     Else
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = 0
                     End If
                     If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc2").ToString()) Then
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
                     Else
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = 0
                     End If
                     If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc3").ToString()) Then
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = Decimal.Parse(dr("DescuentoRecargoPorc3").ToString())
                     Else
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = 0
                     End If
                     If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc4").ToString()) Then
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = Decimal.Parse(dr("DescuentoRecargoPorc4").ToString())
                     Else
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = 0
                     End If
                  End If


                  oProductos.Inserta(Producto, idFuncion)

                  ProdSuc = oProdSuc._GetUno(idSucursal, Producto.IdProducto)
                  ProdSuc.Usuario = usuario
                  ProdSuc.PrecioFabrica = 0
                  ProdSuc.PrecioCosto = Decimal.Parse(dr("PrecioCosto").ToString())

                  'If IdListaDePrecios = 0 Then

                  '   ProdSuc.PrecioVenta = Decimal.Parse(dr("PrecioVenta").ToString())
                  'Else
                  '   ProdSuc.PrecioVenta = 0
                  'End If

                  ProdSuc.PuntoDePedido = 0
                  ProdSuc.StockMinimo = 0

                  '-.PE-32568.- Historial de Precios -- Se inserta un registro por cada insert o update de producto
                  oHistPrec.Inserta(ProdSuc, idFuncion)

                  'inserto la relacion producto-proveedor
                  If idProveedor <> 0 Then
                     sqlPP.ProductosProveedores_I(idProveedor, Producto.IdProducto,
                                                  Producto.ProductoProveedorHabitual.CodigoProductoProveedor,
                                                  Producto.ProductoProveedorHabitual.UltimoPrecioCompra,
                                                  Producto.ProductoProveedorHabitual.UltimaFechaCompra,
                                                  Producto.ProductoProveedorHabitual.UltimoPrecioFabrica,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc5,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc6)
                  End If
               Else
                  If idProveedor <> 0 Then
                     If Producto.Proveedor Is Nothing Then
                        Producto.Proveedor = New Entidades.Proveedor()
                     End If
                     Producto.Proveedor = New Reglas.Proveedores().GetUno(idProveedor)

                     If Producto.ProductoProveedorHabitual Is Nothing Then
                        Producto.ProductoProveedorHabitual = New Entidades.ProductoProveedor()
                        Producto.ProductoProveedorHabitual.UltimaFechaCompra = Nothing
                        Producto.ProductoProveedorHabitual.UltimoPrecioCompra = Nothing
                     End If


                     'Producto.ProductoProveedorHabitual = New ProductoProveedor()
                     Producto.ProductoProveedorHabitual.IdProveedor = Producto.Proveedor.IdProveedor
                     Producto.ProductoProveedorHabitual.IdProducto = Producto.IdProducto
                     If Not String.IsNullOrEmpty(dr("PrecioCompra").ToString()) Then
                        Producto.ProductoProveedorHabitual.UltimoPrecioFabrica = Decimal.Parse(dr("PrecioCompra").ToString())
                     End If
                     If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc1").ToString()) Then
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc1").ToString())
                     Else
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1 = 0
                     End If
                     If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc2").ToString()) Then
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
                     Else
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2 = 0
                     End If
                     If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc3").ToString()) Then
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = Decimal.Parse(dr("DescuentoRecargoPorc3").ToString())
                     Else
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3 = 0
                     End If
                     If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc4").ToString()) Then
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = Decimal.Parse(dr("DescuentoRecargoPorc4").ToString())
                     Else
                        Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4 = 0
                     End If
                  End If


                  oProductos.Actualiza(Producto, _actualizaImagen:=False, idFuncion:=idFuncion, fuerzaActualizacionPrecio:=fuerzaActualizacionPrecio)

                  ProdSuc = oProdSuc._GetUno(idSucursal, Producto.IdProducto)

                  'ProdSuc.Sucursal.Id = IdSucursal
                  'ProdSuc.Producto = Producto
                  'ProdSuc.Stock = 0
                  'ProdSuc.StockInicial = 0
                  ProdSuc.Usuario = usuario
                  ProdSuc.PrecioFabrica = 0
                  ProdSuc.PrecioCosto = Decimal.Parse(dr("PrecioCosto").ToString())

                  'inserto la relacion producto-proveedor
                  If idProveedor <> 0 Then
                     sqlPP.ProductosProveedores_I(idProveedor, Producto.IdProducto,
                                                  Producto.ProductoProveedorHabitual.CodigoProductoProveedor,
                                                  Producto.ProductoProveedorHabitual.UltimoPrecioCompra,
                                                  Producto.ProductoProveedorHabitual.UltimaFechaCompra,
                                                  Producto.ProductoProveedorHabitual.UltimoPrecioFabrica,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc5,
                                                  Producto.ProductoProveedorHabitual.DescuentoRecargoPorc6)
                  End If

               End If

               Dim dt1 As DataTable = New Reglas.Sucursales().GetAll()

               If Publicos.PreciosUnificar Then

                  For Each dr1 As DataRow In dt1.Rows
                     ProdSuc.IdSucursal = Integer.Parse(dr1("IdSucursal").ToString())

                     'If idListaDePrecios = 0 Then
                     '   oProdSuc.Actualiza(ProdSuc, idFuncion)
                     'Else
                     oProdSuc.ActualizaPrecioCosto(ProdSuc, idFuncion)
                     'End If

                     'Borro el Historial que se Genero, cada corrida Genera muchos registros
                     oHistPrec.Borra(ProdSuc, idListaDePrecios, idFuncion)

                     'Falto Siempre o algo se cambio que hace falta.
                     sqlPSP.ProductosSucursalesPrecios_U(Producto.IdProducto, Integer.Parse(dr1("IdSucursal").ToString()), idListaDePrecios, Decimal.Parse(dr("PrecioVenta").ToString()), Date.Now, usuario)

                  Next

               Else
                  'If idListaDePrecios = 0 Then
                  '   oProdSuc.Actualiza(ProdSuc, idFuncion)
                  'Else
                  oProdSuc.ActualizaPrecioCosto(ProdSuc, idFuncion)
                  'End If

                  'Borro el Historial que se Genero, cada corrida Genera muchos registros
                  oHistPrec.Borra(ProdSuc, idListaDePrecios, idFuncion)

                  sqlPSP.ProductosSucursalesPrecios_U(Producto.IdProducto, idSucursal, idListaDePrecios, Decimal.Parse(dr("PrecioVenta").ToString()), Date.Now, usuario)
               End If

               'hacer la relacion Producto-Proveedor

            End If

         Next

         da.CommitTransaction()

      Catch ex As Exception
         barraProg.Value = 0
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub InsertarProducto(idSucursal As Integer, idProducto As String,
                               nombreProducto As String, nombreMarca As String,
                               nombreRubro As String, moneda As String, IVA As Decimal,
                               usuario As String, idFuncion As String)

      Dim sqlPSP As SqlServer.ProductosSucursalesPrecios = New SqlServer.ProductosSucursalesPrecios(da)
      sqlPSP.ProductosSucursalesPrecios_IFaltante("", usuario)

      Dim oMarcas As Eniac.Reglas.Marcas = New Eniac.Reglas.Marcas(da)
      Dim dtMarcas As DataTable = New DataTable
      Dim Marca As Entidades.Marca = New Entidades.Marca

      Dim oRubros As Eniac.Reglas.Rubros = New Eniac.Reglas.Rubros(da)
      Dim dtRubros As DataTable = New DataTable
      Dim Rubro As Entidades.Rubro = New Entidades.Rubro

      Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos(da)
      Dim Producto As Entidades.Producto = New Entidades.Producto

      Dim oProdSuc As Eniac.Reglas.ProductosSucursales = New Eniac.Reglas.ProductosSucursales(da)
      Dim ProdSuc As Entidades.ProductoSucursal = New Entidades.ProductoSucursal

      Dim oProdSucPrecios As Eniac.Reglas.ProductosSucursales = New Eniac.Reglas.ProductosSucursales(da)

      Dim oHistPrec As Eniac.Reglas.HistorialPrecios = New Eniac.Reglas.HistorialPrecios(da)

      Dim AnchoNombreProducto As Integer = New Reglas.Publicos().GetAnchoCampo("Productos", "NombreProducto")
      Dim blnProductoUtilizaNombreCorto As Boolean = Publicos.ProductoUtilizaNombreCorto

      Dim sqlPP As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(da)

      dtMarcas = oMarcas.GetPorNombreExacto(nombreMarca)

      If dtMarcas.Rows.Count = 0 Then
         Marca.IdMarca = oMarcas.GetCodigoMaximo() + 1
         Marca.NombreMarca = nombreMarca

         oMarcas.Inserta(Marca)

      Else
         Marca.IdMarca = Integer.Parse(dtMarcas.Rows(0)("IdMarca").ToString())
      End If

      dtRubros = oRubros.GetPorNombreExacto(nombreRubro)

      If dtRubros.Rows.Count = 0 Then
         Rubro.IdRubro = oRubros.GetCodigoMaximo() + 1
         Rubro.NombreRubro = nombreRubro

         oRubros.Inserta(Rubro)
      Else
         Rubro.IdRubro = Integer.Parse(dtRubros.Rows(0)("IdRubro").ToString())
      End If

      Try

         Producto.IdProducto = idProducto

         If Strings.Trim(nombreProducto.Trim()).Length > AnchoNombreProducto Then
            Producto.NombreProducto = Strings.Trim(nombreProducto.ToString()).Remove(AnchoNombreProducto)
         Else
            Producto.NombreProducto = Strings.Trim(nombreProducto.Trim().ToString())
         End If

         Producto.IdMarca = Marca.IdMarca
         Producto.IdRubro = Rubro.IdRubro
         Producto.Usuario = usuario
         If Not String.IsNullOrEmpty(IVA.ToString()) Then
            Producto.Alicuota = Decimal.Parse(IVA.ToString())   'ProductoIVA
         End If
         Producto.CodigoDeBarras = ""
         Producto.Moneda = New Reglas.Monedas(da).GetUna(Integer.Parse(IIf(moneda.ToString.Trim() = "Pesos", 1, 2).ToString()))

         Producto.IdSucursal = idSucursal
         Producto.Tamano = 0
         Producto.UnidadDeMedida.IdUnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUnidadDeMedidaPorDefecto()
         Producto.MesesGarantia = 0
         Producto.AfectaStock = True
         Producto.IdTipoImpuesto = "IVA"
         Producto.EsServicio = False
         Producto.PublicarEnWeb = False
         Producto.EsDeVentas = True
         Producto.EsDeCompras = True
         Producto.EsCompuesto = False
         Producto.DescontarStockComponentes = False
         Producto.CodigoDeBarrasConPrecio = False
         Producto.PermiteModificarDescripcion = False
         Producto.PagaIngresosBrutos = True
         Producto.Embalaje = 1
         Producto.Kilos = 0
         Producto.PublicarListaDePreciosClientes = True
         Producto.FacturacionCantidadNegativa = False
         Producto.SolicitaEnvase = False
         Producto.AlertaDeCaja = False
         Producto.EsRetornable = False
         Producto.Observacion = ""
         Producto.IdModelo = 0
         Producto.EsObservacion = False
         Producto.PrecioPorEmbalaje = False
         Producto.UnidHasta1 = 0
         Producto.UnidHasta2 = 0
         Producto.UnidHasta3 = 0
         Producto.UnidHasta4 = 0
         Producto.UnidHasta5 = 0
         Producto.UHPorc1 = 0
         Producto.UHPorc2 = 0
         Producto.UHPorc3 = 0
         Producto.UHPorc4 = 0
         Producto.UHPorc5 = 0
         Producto.EsOferta = "NO"
         Producto.IncluirExpensas = False
         Producto.ObservacionCompras = ""
         Producto.SolicitaPrecioVentaPorTamano = False
         Producto.Orden = 1

         If blnProductoUtilizaNombreCorto Then
            Producto.nombreCorto = Strings.Left(nombreProducto.ToString.Trim, 30)
         Else
            Producto.nombreCorto = ""
         End If

         Producto.Activo = True

         oProductos.Inserta(Producto, idFuncion)


      Catch
         Throw
      End Try

   End Sub
   Public Function GetPorFiltrosVarios(idProducto As String,
                                       nombreProducto As String,
                                       marcas As Entidades.Marca(),
                                       rubros As Entidades.Rubro(),
                                       subRubro As Entidades.SubRubro(),
                                       embalaje As Integer,
                                       descrecproducto As Decimal?,
                                       afectaStock As String,
                                       activo As String,
                                       esServicio As String,
                                       esDeCompras As String,
                                       esDeVentas As String,
                                       esDeCambio As String,
                                       esDeBonificacion As String,
                                       modalidadCodigoBarras As String,
                                       pagaIngresosBrutos As String,
                                       permiteModificarDescripcion As String,
                                       orden As Integer,
                                       moneda As Integer,
                                       publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros,
                                       centroDeCostos As Integer,
                                       utilizaLote As String,
                                       utilizaNroSerie As String,
                                       subSubRubros As List(Of Entidades.SubSubRubro),
                                       caracteristica1 As String,
                                       caracteristica2 As String,
                                       caracteristica3 As String,
                                       idProveedor As Long,
                                       esOferta As String,
                                       sinCosto As Boolean,
                                       sinVenta As Boolean,
                                       SinProveedorHabitual As Boolean,
                                       alicuotaIva As Decimal,
                                       activoFiltroAlicIva2 As Boolean,
                                       alicuotaIva2 As Decimal?,
                                       esCompuesto As Entidades.Publicos.SiNoTodos,
                                       UM As String,
                                       esPerceptibleIVARes53292023 As Entidades.Publicos.SiNoTodos) As DataTable
      Return EjecutaConConexion(
      Function()
         Dim baseProductosWeb = Publicos.NombreBaseProductosWeb
         Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
         Dim dt = sql.GetPorFiltrosVarios(
                           idProducto, nombreProducto, marcas, rubros, subRubro, embalaje, descrecproducto, afectaStock,
                           activo, esServicio, esDeCompras, esDeVentas, esDeCambio, esDeBonificacion, modalidadCodigoBarras, pagaIngresosBrutos,
                           permiteModificarDescripcion, orden, moneda,
                           publicarEn, centroDeCostos, utilizaLote, utilizaNroSerie, subSubRubros,
                           caracteristica1, caracteristica2, caracteristica3, baseProductosWeb, idProveedor,
                           esOferta, sinCosto, sinVenta, SinProveedorHabitual, alicuotaIva, activoFiltroAlicIva2, alicuotaIva2, esCompuesto, UM,
                           esPerceptibleIVARes53292023)
         Return dt
      End Function)
   End Function

   Public Function GetProductosParaExportar(idProducto As String, nombreProducto As String,
                                            marcas As List(Of Entidades.Marca), rubros As List(Of Entidades.Rubro), idSubRubro As Integer,
                                            embalaje As Integer,
                                            afectaStock As String,
                                            activo As String,
                                            esServicio As String, esDeCompras As String, esDeVentas As String,
                                            pagaIngresosBrutos As String,
                                            permiteModificarDescripcion As String,
                                            idSucursal As Integer,
                                            idListaPrecios As Integer,
                                            idMoneda As Integer,
                                            tipoCambio As Decimal,
                                            fechaActualizadoDesde As Date,
                                            fechaActualizadoHasta As Date,
                                            publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros,
                                            subRubros As List(Of Entidades.SubRubro), subSubRubros As List(Of Entidades.SubSubRubro),
                                            exportaConIVA As Boolean,
                                            decimalesRedondeoPrecios As Integer,
                                            exportarEnviando As Entidades.Producto.ExportarEnviando,
                                            fechaEnviando As Date,
                                            consultaFoto As Boolean,
                                            formatoNombreWeb As Entidades.Producto.FormatosProductos,
                                            idListaPreciosMayorista As Integer,
                                            filtroStock As Entidades.EnumSql.Stock_TipoReporte) As DataTable

      Dim sql As SqlServer.Productos
      Dim dtDetalle As DataTable

      sql = New SqlServer.Productos(da)

      Dim base As String = Publicos.NombreBaseProductosWeb

      dtDetalle = sql.GetProductosParaExportar(idProducto, nombreProducto, marcas, rubros, idSubRubro, embalaje, afectaStock,
                                               activo, esServicio, esDeCompras, esDeVentas, pagaIngresosBrutos,
                                               permiteModificarDescripcion, idSucursal, idListaPrecios,
                                               idMoneda, tipoCambio, fechaActualizadoDesde, fechaActualizadoHasta, publicarEn, base,
                                               subRubros, subSubRubros, exportaConIVA, Publicos.PreciosConIVA, decimalesRedondeoPrecios,
                                               exportarEnviando, fechaEnviando, consultaFoto, formatoNombreWeb, idListaPreciosMayorista,
                                               filtroStock)

      Dim sr As Integer
      Dim drCl As DataRow
      Dim dt As DataTable

      dt = Me.CrearDT()

      For Each dr As DataRow In dtDetalle.Rows
         drCl = dt.NewRow()

         Integer.TryParse(dr("IdSubRubro").ToString(), sr)
         drCl("IdSucursal") = dr("IdSucursal").ToString().Trim()
         drCl("IdProducto") = dr("IdProducto").ToString().Trim()
         '-- REQ-35886.- --------------------------------------------------------------------------------
         drCl("IdProductoNumerico") = If(Not String.IsNullOrEmpty(dr("IdProductoNumerico").ToString()), Long.Parse(dr("IdProductoNumerico").ToString()), 0)
         '-----------------------------------------------------------------------------------------------
         drCl("NombreProducto") = dr("NombreProducto").ToString()
         drCl("IdMarca") = Integer.Parse(dr("IdMarca").ToString())
         drCl("NombreMarca") = dr("NombreMarca").ToString()
         drCl("IdRubro") = Integer.Parse(dr("IdRubro").ToString())
         drCl("NombreRubro") = dr("NombreRubro").ToString()
         drCl("IdSubRubro") = sr
         drCl("NombreSubRubro") = dr("NombreSubRubro").ToString()
         drCl("Activo") = IIf(Boolean.Parse(dr("Activo").ToString()), "SI", "NO").ToString()

         If Not String.IsNullOrEmpty(dr("Tamano").ToString()) Then
            drCl("Tamano") = Decimal.Parse(dr("Tamano").ToString())
            drCl("IdUnidadDeMedida") = dr("IdUnidadDeMedida").ToString()
         Else
            drCl("Tamano") = 0
            drCl("IdUnidadDeMedida") = ""
         End If
         drCl("Embalaje") = Integer.Parse(dr("Embalaje").ToString())
         drCl("Kilos") = Decimal.Parse(dr("Kilos").ToString())

         drCl("Alto") = Decimal.Parse(dr("Alto").ToString())
         drCl("Ancho") = Decimal.Parse(dr("Ancho").ToString())
         drCl("Largo") = Decimal.Parse(dr("Largo").ToString())

         drCl("AfectaStock") = IIf(Boolean.Parse(dr("AfectaStock").ToString()), "SI", "NO").ToString()
         drCl("EsServicio") = IIf(Boolean.Parse(dr("EsServicio").ToString()), "SI", "NO").ToString()
         drCl("EsDeCompras") = IIf(Boolean.Parse(dr("EsDeCompras").ToString()), "SI", "NO").ToString()
         drCl("EsDeVentas") = IIf(Boolean.Parse(dr("EsDeVentas").ToString()), "SI", "NO").ToString()
         drCl("PagaIngresosBrutos") = IIf(Boolean.Parse(dr("PagaIngresosBrutos").ToString()), "SI", "NO").ToString()
         drCl("PermiteModificarDescripcion") = IIf(Boolean.Parse(dr("PermiteModificarDescripcion").ToString()), "SI", "NO").ToString()
         drCl("PublicarListaDePreciosClientes") = IIf(Boolean.Parse(dr("PublicarListaDePreciosClientes").ToString()), "SI", "NO").ToString()
         drCl("Alicuota") = Decimal.Parse(dr("Alicuota").ToString())
         drCl("PrecioCosto") = Decimal.Parse(dr("PrecioCosto").ToString())
         drCl("PrecioVenta") = Decimal.Parse(dr("PrecioVenta").ToString())
         drCl("PrecioMayorista") = Decimal.Parse(dr("PrecioMayorista").ToString()) 'PE-32135.-

         drCl("FechaActualizacion") = Date.Parse(dr("FechaActualizacion").ToString())


         drCl("NombreMoneda") = dr("NombreMoneda").ToString()
         drCl("CodigoDeBarras") = dr("CodigoDeBarras").ToString()

         drCl("NombreMonedaCorto") = dr("NombreMonedaCorto").ToString()
         drCl("PORCENTAJE") = Decimal.Parse(dr("PORCENTAJE").ToString())
         drCl("CodigoLargoProducto") = dr("CodigoLargoProducto").ToString()
         drCl("PublicarEnWeb") = IIf(Boolean.Parse(dr("PublicarEnWeb").ToString()), "SI", "NO").ToString()
         drCl("Observacion") = dr("Observacion").ToString()
         drCl("Stock") = CInt(dr("Stock").ToString())

         If Not IsDBNull(dr("IdSubSubRubro")) Then
            drCl("IdSubSubRubro") = Integer.Parse(dr("IdSubSubRubro").ToString())
            drCl("NombreSubSubRubro") = dr("NombreSubSubRubro").ToString()
         End If

         drCl("Foto") = dr("Foto")
         drCl("ModalidadCodigoDeBarras") = dr("ModalidadCodigoDeBarras")

         If Publicos.ProductoUtilizaProductoWeb Then
            drCl("Caracteristica1") = dr("Caracteristica1").ToString()
            drCl("Caracteristica2") = dr("Caracteristica2").ToString()
            drCl("Caracteristica3") = dr("Caracteristica3").ToString()
            drCl("ValorCaracteristica1") = dr("ValorCaracteristica1").ToString()
            drCl("ValorCaracteristica2") = dr("ValorCaracteristica2").ToString()
            drCl("ValorCaracteristica3") = dr("ValorCaracteristica3").ToString()
            drCl("Foto2") = dr("Foto2")
            drCl("Foto3") = dr("Foto3")

            drCl("EsParaConstructora") = dr("EsParaConstructora")
            drCl("EsParaIndustria") = dr("EsParaIndustria")
            drCl("EsParaCooperativaElectrica") = dr("EsParaCooperativaElectrica")
            drCl("EsParaMayorista") = dr("EsParaMayorista")
            drCl("EsParaMinorista") = dr("EsParaMinorista")
         End If

         drCl("IdProductoMercosur") = dr("IdProductoMercosur").ToString()
         drCl("NombreCorto") = dr("NombreCorto").ToString()
         drCl("NombreProveedor") = dr("NombreProveedor").ToString()
         drCl("CodigoProductoProveedor") = dr("CodigoProductoProveedor").ToString()


         drCl("Check") = False

         dt.Rows.Add(drCl)
      Next

      Return dt
   End Function

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         '-- REQ-35886.- --------------------------------------------------------------------------------
         .Columns.Add("IdProductoNumerico", System.Type.GetType("System.Int64"))
         '-----------------------------------------------------------------------------------------------
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProductoWeb", System.Type.GetType("System.String"))
         .Columns.Add("IdMarca", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
         .Columns.Add("IdRubro", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
         .Columns.Add("IdSubRubro", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreSubRubro", System.Type.GetType("System.String"))
         .Columns.Add("IdSubSubRubro", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreSubSubRubro", System.Type.GetType("System.String"))
         .Columns.Add("Activo", System.Type.GetType("System.String"))
         .Columns.Add("Tamano", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdUnidadDeMedida", System.Type.GetType("System.String"))
         .Columns.Add("Embalaje", System.Type.GetType("System.Int32"))
         .Columns.Add("Kilos", System.Type.GetType("System.Decimal"))
         .Columns.Add("Alto", System.Type.GetType("System.Decimal"))
         .Columns.Add("Ancho", System.Type.GetType("System.Decimal"))
         .Columns.Add("Largo", System.Type.GetType("System.Decimal"))
         .Columns.Add("AfectaStock", System.Type.GetType("System.String"))
         .Columns.Add("EsServicio", System.Type.GetType("System.String"))
         .Columns.Add("EsDeCompras", System.Type.GetType("System.String"))
         .Columns.Add("EsDeVentas", System.Type.GetType("System.String"))
         .Columns.Add("PagaIngresosBrutos", System.Type.GetType("System.String"))
         .Columns.Add("PermiteModificarDescripcion", System.Type.GetType("System.String"))
         .Columns.Add("PublicarListaDePreciosClientes", System.Type.GetType("System.String"))
         .Columns.Add("Alicuota", System.Type.GetType("System.Decimal"))
         .Columns.Add("PrecioCosto", System.Type.GetType("System.Decimal"))
         .Columns.Add("PrecioVenta", System.Type.GetType("System.Decimal"))
         .Columns.Add("PrecioMayorista", System.Type.GetType("System.Decimal")) '-.PE-32135.-
         .Columns.Add("FechaActualizacion", System.Type.GetType("System.DateTime"))
         .Columns.Add("NombreMoneda", System.Type.GetType("System.String"))
         .Columns.Add("CodigoDeBarras", System.Type.GetType("System.String"))
         .Columns.Add("NombreMonedaCorto", System.Type.GetType("System.String"))
         .Columns.Add("PORCENTAJE", System.Type.GetType("System.Decimal"))
         .Columns.Add("CodigoLargoProducto", System.Type.GetType("System.String"))
         .Columns.Add("PublicarEnWeb", System.Type.GetType("System.String"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("Stock", System.Type.GetType("System.String"))
         .Columns.Add("Caracteristica1", System.Type.GetType("System.String"))
         .Columns.Add("Caracteristica2", System.Type.GetType("System.String"))
         .Columns.Add("Caracteristica3", System.Type.GetType("System.String"))
         .Columns.Add("ValorCaracteristica1", System.Type.GetType("System.String"))
         .Columns.Add("ValorCaracteristica2", System.Type.GetType("System.String"))
         .Columns.Add("ValorCaracteristica3", System.Type.GetType("System.String"))
         .Columns.Add("Foto", System.Type.GetType("System.Byte[]"))
         .Columns.Add("Foto2", System.Type.GetType("System.Byte[]"))
         .Columns.Add("Foto3", System.Type.GetType("System.Byte[]"))
         .Columns.Add("Check", System.Type.GetType("System.Boolean"))
         .Columns.Add("EsParaConstructora", System.Type.GetType("System.Boolean"))
         .Columns.Add("EsParaIndustria", System.Type.GetType("System.Boolean"))
         .Columns.Add("EsParaCooperativaElectrica", System.Type.GetType("System.Boolean"))
         .Columns.Add("EsParaMayorista", System.Type.GetType("System.Boolean"))
         .Columns.Add("EsParaMinorista", System.Type.GetType("System.Boolean"))
         .Columns.Add("IdProductoMercosur", System.Type.GetType("System.String"))
         .Columns.Add("NombreCorto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
         .Columns.Add("CodigoProductoProveedor", System.Type.GetType("System.String"))
         .Columns.Add("IdUnidadDeMedida2", GetType(String))
         .Columns.Add("Conversion", GetType(Decimal))
         .Columns.Add("ModalidadCodigoDeBarras", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Public Sub ActualizacionMasiva(productos As List(Of Entidades.Producto),
                                  modificoAlto As Boolean,
                                  modificoAncho As Boolean,
                                  modificoLargo As Boolean,
                                  modificoParWebPara As Boolean,
                                  actualizaFoto2 As Boolean,
                                  actualizaFoto3 As Boolean,
                                  modificoKilos As Boolean)

      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
         Dim sqlPS As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)
         Dim sql1 As SqlServer.ProductosWeb = New SqlServer.ProductosWeb(da)
         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
         Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)

         'Dim dt As DataTable

         For Each produ As Entidades.Producto In productos

            sql.Productos_UVarios(produ.IdProducto, produ.IdMarca, produ.IdRubro, produ.IdSubRubro, produ.AfectaStock,
                                  produ.Activo, produ.Embalaje, produ.DescRecProducto, produ.EsServicio, produ.EsDeCompras,
                                  produ.EsDeVentas, produ.EsCambiable, produ.EsBonificable, produ.CodigoDeBarrasConPrecio, produ.ModalidadCodigoDeBarras,
                                  produ.PagaIngresosBrutos, produ.PermiteModificarDescripcion,
                                  produ.Tamano, produ.UnidadDeMedida.IdUnidadDeMedida,
                                  modificoKilos, produ.Kilos, produ.Orden, produ.Moneda.IdMoneda, produ.ProductoProveedorHabitual.IdProveedor,
                                  produ.PublicarEnWeb, produ.PublicarEnTiendaNube, produ.PublicarEnMercadoLibre, produ.PublicarEnArborea,
                                  produ.PublicarEnGestion, produ.PublicarEnEmpresarial, produ.PublicarEnBalanza,
                                  produ.PublicarEnSincronizacionSucursal, produ.PublicarListaDePreciosClientes,
                                  produ.CentroCosto, produ.Lote, produ.NroSerie, produ.IdSubSubRubro, produ.Alto,
                                  modificoAlto, produ.Ancho, modificoAncho, produ.Largo, modificoLargo,
                                  produ.EsOferta, produ.Alicuota, produ.Alicuota2, produ.DescontarStockComponentes,
                                  produ.EsPerceptibleIVARes53292023)


            If produ.ProductosWeb IsNot Nothing Then
               Dim prodweb As DataTable = sql1.ProductosWeb_G1(produ.IdProducto, Publicos.NombreBaseProductosWeb)

               If prodweb.Rows.Count <> 0 Then
                  sql1.ProductosWeb_U(produ.IdProducto, produ.ProductosWeb.Caracteristica1, produ.ProductosWeb.ValorCaracteristica1,
                                      produ.ProductosWeb.Caracteristica2, produ.ProductosWeb.ValorCaracteristica2,
                                      produ.ProductosWeb.Caracteristica3, produ.ProductosWeb.ValorCaracteristica3,
                                      Publicos.NombreBaseProductosWeb, produ.ProductosWeb.EsParaConstructora, produ.ProductosWeb.EsParaIndustria,
                                      produ.ProductosWeb.EsParaCooperativaElectrica, produ.ProductosWeb.EsParaMayorista,
                                      produ.ProductosWeb.EsParaMinorista, modificoParWebPara)
               Else
                  sql1.ProductosWeb_I(produ.IdProducto, produ.ProductosWeb.Caracteristica1, produ.ProductosWeb.ValorCaracteristica1,
                                      produ.ProductosWeb.Caracteristica2, produ.ProductosWeb.ValorCaracteristica2,
                                      produ.ProductosWeb.Caracteristica3, produ.ProductosWeb.ValorCaracteristica3,
                                      Publicos.NombreBaseProductosWeb, produ.ProductosWeb.EsParaConstructora, produ.ProductosWeb.EsParaIndustria,
                                      produ.ProductosWeb.EsParaCooperativaElectrica, produ.ProductosWeb.EsParaMayorista,
                                      produ.ProductosWeb.EsParaMinorista)

               End If

               If actualizaFoto2 Then
                  sql1.GrabarFoto2(produ.ProductosWeb.Foto2, produ.IdProducto, Publicos.NombreBaseProductosWeb)
               End If
               If actualizaFoto3 Then
                  sql1.GrabarFoto3(produ.ProductosWeb.Foto3, produ.IdProducto, Publicos.NombreBaseProductosWeb)
               End If

            End If

            Dim idProveedor As Long = 0
            If produ.Proveedor IsNot Nothing Then
               idProveedor = produ.Proveedor.IdProveedor
            End If

            If produ.Proveedor IsNot Nothing AndAlso produ.ProductoProveedorHabitual IsNot Nothing And idProveedor > 0 Then
               Dim sqlPP As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(da)
               If sqlPP.ProductosProveedores_G1(idProveedor, produ.IdProducto).Rows.Count = 0 Then
                  sqlPP.ProductosProveedores_I(idProveedor, produ.IdProducto, produ.ProductoProveedorHabitual.CodigoProductoProveedor,
                                               produ.ProductoProveedorHabitual.UltimoPrecioCompra,
                                               produ.ProductoProveedorHabitual.UltimaFechaCompra,
                                               produ.ProductoProveedorHabitual.UltimoPrecioFabrica,
                                               produ.ProductoProveedorHabitual.DescuentoRecargoPorc1,
                                               produ.ProductoProveedorHabitual.DescuentoRecargoPorc2,
                                               produ.ProductoProveedorHabitual.DescuentoRecargoPorc3,
                                               produ.ProductoProveedorHabitual.DescuentoRecargoPorc4,
                                               produ.ProductoProveedorHabitual.DescuentoRecargoPorc5,
                                               produ.ProductoProveedorHabitual.DescuentoRecargoPorc6)
               End If
            End If

            sqlPS.ProductosSucursales_U_Varios(produ.IdProducto, actual.Sucursal.Id, produ.PuntoDePedido, produ.StockMinimo)

            'vvvvvv    Auditoria de productos    vvvvvv
            Dim OperacAudit As Entidades.OperacionesAuditorias
            Dim clavePrimariaProducto As String = String.Format("IdProducto = '{0}'", produ.IdProducto)
            'Graba Auditoria
            Using dtAudit As DataTable = sqlAudit.Auditorias_G1("Productos", clavePrimariaProducto)
               'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
               If dtAudit.Rows.Count > 0 Then
                  Select Case True
                     Case Not produ.Activo And Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
                        'Lo inactivo
                        OperacAudit = Entidades.OperacionesAuditorias.Inactivar
                     Case produ.Activo And Not Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
                        'Lo activo
                        OperacAudit = Entidades.OperacionesAuditorias.Alta
                     Case Else
                        OperacAudit = Entidades.OperacionesAuditorias.Modificacion
                  End Select
               Else
                  OperacAudit = Entidades.OperacionesAuditorias.Alta
               End If
            End Using
            rAudit.Insertar("Productos", OperacAudit, actual.Nombre, clavePrimariaProducto, conMilisegundos:=False)
            '^^^^^^    Auditoria de productos    ^^^^^^
         Next

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Function GetProductosXModelo(modelo As String) As DataTable
      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      Return sql.GetProductosXModelo(modelo)
   End Function

   Public Function GetProductosXNumeroSerie(NumeroSerie As String) As DataTable
      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      Return sql.GetProductosXNumeroSerie(NumeroSerie)
   End Function

   Public Function GetProductosXCaractSII(caractSII As String) As DataTable
      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      Return sql.GetProductosXCaractSII(caractSII)
   End Function

   Public Function GetTodos() As List(Of Entidades.Producto)
      Try
         Me.da.OpenConection()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.Producto
         Dim oLis As List(Of Entidades.Producto) = New List(Of Entidades.Producto)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.Producto()
            Me.CargarUno(o, dr, False)
            oLis.Add(o)
         Next
         Return oLis
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetTodosObservacion() As List(Of Entidades.Producto)
      Return EjecutaConConexion(Function() _GetTodosObservacion())
   End Function

   Public Function _GetTodosObservacion() As List(Of Entidades.Producto)
      'Try
      '   Me.da.OpenConection()

      Dim dt As DataTable = New SqlServer.Productos(da).Productos_GA(True)
      Dim o As Entidades.Producto
      Dim oLis As List(Of Entidades.Producto) = New List(Of Entidades.Producto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Producto()
         Me.CargarUno(o, dr, False)
         oLis.Add(o)
      Next
      Return oLis
      'Catch ex As Exception
      '   Throw
      'Finally
      '   Me.da.CloseConection()
      'End Try
   End Function

   Public Function GetAuditoriaProductos(fechaDesde As Date, fechaHasta As Date, idProducto As String) As DataTable
      Return New SqlServer.Productos(da).GetAuditoriaProductos(fechaDesde, fechaHasta, idProducto)
   End Function

   Public Sub SubirProductosAWebExperto(dias As Integer)
      Try
         My.Application.Log.WriteEntry(String.Format("Abro la conexión a la base."), TraceEventType.Information)

         Me.da.OpenConection()

         '----------------------
         ' Carga los valores como si fuera la pantalla de ExportarProductosWeb
         'datos configurables
         Dim fechaActualizadoDesde As DateTime = DateTime.Today.AddDays(dias * -1)
         Dim fechaActualizadoHasta As DateTime = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59)


         'cargo los valores que voy a consultar
         Dim IdProducto As String = ""
         Dim NombreProducto As String = ""
         Dim marcas As List(Of Entidades.Marca) = New List(Of Entidades.Marca)()
         Dim rubros As List(Of Entidades.Rubro) = New List(Of Entidades.Rubro)()
         Dim idSubRubro As Integer = 0
         Dim embalaje As Integer = 0
         Dim afectaStock As String = "TODOS"
         Dim activo As String = "TODOS"
         Dim esServicio As String = "TODOS"
         Dim esDeCompras As String = "TODOS"
         Dim esDeVentas As String = "TODOS"
         Dim pagaIngresosBrutos As String = "TODOS"
         Dim permiteModificarDescripcion As String = "TODOS"
         'Dim publicarListaDePreciosClientes As String = "TODOS"
         Dim idSucursal As Integer = 1
         Dim idListaDePrecios As Integer = 0
         Dim idMoneda As Integer = 0
         Dim tipoDeCambio As Decimal = 0
         'Dim publicarEnWeb As String = "TODOS"
         Dim subRubros As List(Of Entidades.SubRubro) = New List(Of Entidades.SubRubro)()
         Dim subSubRubros As List(Of Entidades.SubSubRubro) = New List(Of Entidades.SubSubRubro)()

         Dim carpetaImagenes As String = Entidades.Publicos.CarpetaEniac + "ImagenesWeb\"
         Dim archivoDestino As String = Entidades.Publicos.CarpetaEniac + "ArchivoAExportar.txt"

         '----------------------
         'consultar los productos a subir
         Dim dtProductosASubir As DataTable

         My.Application.Log.WriteEntry(String.Format("Consulto los productos a subir a la web."), TraceEventType.Information)

         Dim publicarEn As New Entidades.Filtros.ProductosPublicarEnFiltros() 'Se inicializa con TODOS en todos los filtros

         dtProductosASubir = Me.GetProductosParaExportar(IdProducto, NombreProducto, marcas, rubros, idSubRubro, embalaje, afectaStock, activo, esServicio, esDeCompras, esDeVentas,
                             pagaIngresosBrutos, permiteModificarDescripcion, idSucursal, idListaDePrecios, idMoneda, tipoDeCambio, fechaActualizadoDesde,
                             fechaActualizadoHasta, publicarEn, subRubros, subSubRubros, Publicos.ExportarPreciosConIVA, Reglas.Publicos.ExportarProductosDecimalesRedondeoEnPrecio,
                             Entidades.Producto.ExportarEnviando.TODOS, Today, True, Entidades.Producto.FormatosProductos.Web, 0, Entidades.EnumSql.Stock_TipoReporte.General)

         My.Application.Log.WriteEntry(String.Format("Cierro la conexión a la base."), TraceEventType.Information)

         Me.da.CloseConection()

         If dtProductosASubir.Rows.Count = 0 Then
            'salgo sin hacer nada para no ejecutar el resto del proceso
            Exit Sub
         Else
            For Each dr As DataRow In dtProductosASubir.Rows
               dr("Check") = True
            Next
         End If

         My.Application.Log.WriteEntry(String.Format("Archivos a subir = {0}.", dtProductosASubir.Rows.Count), TraceEventType.Information)

         'generar el archivo a subir
         Dim regProWeb As Reglas.ProductosWeb = New Reglas.ProductosWeb()

         Dim prodWeb As Reglas.ProductosWebArchivo
         prodWeb = New Reglas.ProductosWebExperto()

         My.Application.Log.WriteEntry(String.Format("Creo los productos para la Web."), TraceEventType.Information)

         regProWeb.CrearProductosWeb(dtProductosASubir, prodWeb, carpetaImagenes)

         If prodWeb.Lineas.Count = 0 Then
            'termino el proceso para no continuar
            Exit Sub
         End If

         My.Application.Log.WriteEntry(String.Format("Grabo el archivo."), TraceEventType.Information)

         prodWeb.GrabarArchivoWebExperto(archivoDestino)

         Dim ServidorFTP As String = Reglas.Publicos.FTPServidor
         Dim UsuarioFTP As String = Reglas.Publicos.FTPUsuario
         Dim ClaveFTP As String = Reglas.Publicos.FTPPassword
         Dim NuevoArchivo As String = Reglas.Publicos.FTPNombreArchivo
         Dim blnConexionPassivaFTP As Boolean = Reglas.Publicos.FTPConexionPasiva
         Dim carpetaRemotaFTP As String = Reglas.Publicos.FTPCarpetaRemota

         My.Application.Log.WriteEntry(String.Format("Voy subiendo los archivos a la web."), TraceEventType.Information)

         'subir a la web
         regProWeb.SubirArchivosALaWeb(ServidorFTP, UsuarioFTP, ClaveFTP, NuevoArchivo, blnConexionPassivaFTP, carpetaRemotaFTP, archivoDestino, carpetaImagenes)

      Catch ex As Exception
         Throw
      Finally
         If Me.da.Connection.State = ConnectionState.Open Then Me.da.CloseConection()
      End Try

   End Sub

   Public Function GetProductosListasControl(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                                IdestadoCalidad As Integer, Liberado As Boolean,
                                                Entregado As Boolean) As DataTable
      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      Return sql.GetProductosCalidad(idProducto, FechaDesde, FechaHasta, IdestadoCalidad, Liberado, Entregado)
   End Function

   Public Function GetVistaProductosBejerman(Base As String, NroChasis As String) As DataTable
      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      Return sql.GetVistaProductosBejerman(Base, NroChasis)
   End Function



   Public Function EsCompuesto(idProducto As String, condicion As Boolean) As Boolean
      Return New SqlServer.Productos(da).EsCompuesto(idProducto, condicion)
   End Function

   Public Function GetProductosActualizacionCodigo(idSucursal As Integer,
                                                   marcas As Entidades.Marca(),
                                                   rubros As Entidades.Rubro(),
                                                   subrubros As Entidades.SubRubro(),
                                                   idProducto As String) As DataTable
      Dim activo As Boolean = True
      Return New SqlServer.Productos(da).GetProductosActualizacionCodigo(idSucursal, marcas, rubros, subrubros, idProducto, activo)
   End Function

   Public Sub ActualizarIdProductoNumerico(idProducto As String, idProductoNumericoNuevo As Long)
      Dim sql As New SqlServer.Productos(da)
      Me.EjecutaConTransaccion(Sub() sql.ActualizarIdProductoNumerico(idProducto, idProductoNumericoNuevo))
   End Sub

   '-- REQ-33384.- --------------------------------------------------------------------------
   Public Function GetListasPreciosArborea(reenviarTodo As Boolean, TipoTienda As Entidades.TiendasWeb) As DataTable
      Dim idSucursal As Integer = actual.Sucursal.Id
      Dim idListaPrecioPredeterminada As Integer
      Dim fechaUltimaSincronizacion As Date?
      '---
      Dim preciosConIva As Boolean = Publicos.PreciosConIVA
      Dim preciosConIvaPV As Boolean = Publicos.TiendasWeb.Arborea.ArboreaPreciosConIvaPV
      Dim preciosConIvaLP1 As Boolean = Publicos.TiendasWeb.Arborea.ArboreaPreciosConIvaLP1
      Dim preciosConIvaLP2 As Boolean = Publicos.TiendasWeb.Arborea.ArboreaPreciosConIvaLP2
      Dim preciosConIvaLP3 As Boolean = Publicos.TiendasWeb.Arborea.ArboreaPreciosConIvaLP3

      Dim redondeo As Integer = Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
      '---
      If Publicos.TiendasWeb.Arborea.ArboreaListasPrecios01 = -1 Then Throw New Exception("ATENCIÓN: No existe una lista de precios configurada para la subida de Productos Arborea. Debe configurarla para poder continuar.")
      idListaPrecioPredeterminada = Publicos.TiendasWeb.Arborea.ArboreaListasPrecios01
      fechaUltimaSincronizacion = If(reenviarTodo, Nothing,
                                          New FechasSincronizaciones().GetFechaUltimaSincronizacion(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.ARBOREA.ToString(),
                                                                                                    Entidades.Producto.NombreTabla))
      '---
      Return New SqlServer.Productos(da).GetListasPreciosArborea(idSucursal, fechaUltimaSincronizacion,
                                                                     Publicos.TiendasWeb.Arborea.ArboreaListasPrecios01,
                                                                     Publicos.TiendasWeb.Arborea.ArboreaListasPrecios02, Publicos.TiendasWeb.Arborea.ArboreaListasPrecios03, Publicos.TiendasWeb.Arborea.ArboreaListasPrecios04,
                                                              preciosConIva, preciosConIvaPV, preciosConIvaLP1, preciosConIvaLP2, preciosConIvaLP3, redondeo, TipoTienda)
   End Function
   '----------------------------------------------------------------------------------------
   Public Sub CalculaProductosOfertas()
      Try
         da.OpenConection()
         da.BeginTransaction()

         Using dt = GetProductosPublicaWeb(True)
            '# Productos
            For Each dr As DataRow In dt.Rows
               Dim producto = GetUno(dr.Field(Of String)("IdProducto"))
               Dim _Ofertas = (From prodof In producto.ProductosOfertas
                               Where prodof.FechaHasta > Now.Date And prodof.Activa = True And prodof.LimiteStock <> prodof.CantidadConsumida
                               Select prodof.IdOferta).ToList()

               Dim OfertaAnterior = producto.EsOferta
               producto.EsOferta = If(_Ofertas.Count > 0, "SI", "NO")
               If producto.EsOferta <> OfertaAnterior Then
                  producto.FechaActualizacionWeb = Now.Date()
               End If
               Actualiza(producto, False, "Producto", False)
            Next
         End Using

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Function GetProductosPublicaWeb(webPublicar As Boolean) As DataTable
      Return New SqlServer.Productos(da).GetProductosPublicaWeb(webPublicar)
   End Function
   Public Function GetProductosTiendaWeb(reenviarTodo As Boolean, TipoTienda As Entidades.TiendasWeb, publicarPrecioPorEmbalaje As Boolean) As DataTable
      Dim idSucursal As Integer = actual.Sucursal.Id
      Dim idListaPrecioPredeterminada As Integer
      Dim fechaUltimaSincronizacion As Date?

      Select Case TipoTienda
         Case Entidades.TiendasWeb.TIENDANUBE
            '# Valido que existe una lista de precios por defecto configurada para Tienda Nube
            If Publicos.TiendasWeb.TiendaNube.TiendaNubeListaDePrecios = -1 Then Throw New Exception("ATENCIÓN: No existe una lista de precios configurada para la subida de Productos Tienda Nube. Debe configurarla para poder continuar.")
            idListaPrecioPredeterminada = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeListaDePrecios
            fechaUltimaSincronizacion = If(reenviarTodo, Nothing, New Reglas.FechasSincronizaciones().GetFechaUltimaSincronizacion(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.TIENDANUBE.ToString(),
                                                                                                                   Entidades.Producto.NombreTabla))
         Case Entidades.TiendasWeb.MERCADOLIBRE
            '# Valido que existe una lista de precios por defecto configurada para MercadoLibre
            If Publicos.TiendasWeb.MercadoLibre.MercadoLibreListaDePrecios = -1 Then Throw New Exception("ATENCIÓN: No existe una lista de precios configurada para la subida de Productos Mercado Libre. Debe configurarla para poder continuar.")
            idListaPrecioPredeterminada = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreListaDePrecios
            fechaUltimaSincronizacion = If(reenviarTodo, Nothing, New Reglas.FechasSincronizaciones().GetFechaUltimaSincronizacion(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.MERCADOLIBRE.ToString(),
                                                                                                                   Entidades.Producto.NombreTabla))
         Case Entidades.TiendasWeb.ARBOREA
            '# Valido que existe una lista de precios por defecto configurada para Arborea
            If Publicos.TiendasWeb.Arborea.ArboreaListasPrecios01 = -1 Then Throw New Exception("ATENCIÓN: No existe una lista de precios configurada para la subida de Productos Arborea. Debe configurarla para poder continuar.")
            idListaPrecioPredeterminada = Publicos.TiendasWeb.Arborea.ArboreaListasPrecios01
            fechaUltimaSincronizacion = If(reenviarTodo, Nothing,
                                          New FechasSincronizaciones().GetFechaUltimaSincronizacion(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.ARBOREA.ToString(),
                                                                                                    Entidades.Producto.NombreTabla))
      End Select

      Dim preciosConIva As Boolean = Publicos.PreciosConIVA
      Dim redondeo As Integer = Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio

      Return New SqlServer.Productos(da).GetProductosTiendasWeb(idSucursal, idListaPrecioPredeterminada, fechaUltimaSincronizacion,
                                                                preciosConIva, redondeo, TipoTienda, publicarPrecioPorEmbalaje)
   End Function

   Public Function GetMaxFechaActualizacionWeb() As DateTime
      Dim dr As DataRow = New SqlServer.Productos(da).GetMaxFechaActualizacionWeb().Rows(0)
      If Not IsDBNull(dr("FechaActualizacionWeb")) Then Return dr.Field(Of DateTime)("FechaActualizacionWeb")

      Return Nothing
   End Function

   Public Sub GuardarIdProductoTiendaNube(idProducto As String, idProductoTiendaNube As String)
      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      Me.EjecutaSoloConTransaccion(Function()
                                      sql.GuardarIdProductoTiendaNube(idProducto, idProductoTiendaNube)
                                      Return True
                                   End Function)
   End Sub

   Public Sub GuardarIdProductoTiendaWeb(idTiendaWeb As String, idProducto As String, idProductoTiendaWeb As String)
      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      Me.EjecutaSoloConTransaccion(Function()
                                      sql.GuardarIdProductoTiendaWeb(idTiendaWeb, idProducto, idProductoTiendaWeb)
                                      Return True
                                   End Function)
   End Sub

   Public Sub GuardarIdVarianteProducto(idProducto As String, IdVarianteProducto As String)
      Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
      Me.EjecutaSoloConTransaccion(Function()
                                      sql.GuardarIdVarianteProducto(idProducto, IdVarianteProducto)
                                      Return True
                                   End Function)
   End Sub

   Public Function GetProductoTiendaWeb(idProductoTiendaWeb As String, sTipoTienda As String) As Entidades.Producto
      Return Me.CargaEntidad(New SqlServer.Productos(da).Productos_G1TiendaWeb(idProductoTiendaWeb, sTipoTienda),
                             Sub(o, dr) CargarUno(o, dr, True), Function() New Entidades.Producto, AccionesSiNoExisteRegistro.Nulo, String.Format("No se encontró el Producto {1} {0}", idProductoTiendaWeb, sTipoTienda))
   End Function

   Public Function GetProductosServiceXCodigo(idProducto As String, buscaProductoExacto As Boolean) As DataTable
      Return GetProductosService(idProducto:=idProducto, nombreProducto:=Nothing, idSucursal:=0, idTipoComprobante:=Nothing, letra:=Nothing, centroEmisor:=0, numeroComprobante:=0, buscaProductoExacto:=buscaProductoExacto)
   End Function
   Public Function GetProductosServiceXNombre(nombreProducto As String, buscaProductoExacto As Boolean) As DataTable
      Return GetProductosService(idProducto:=Nothing, nombreProducto:=nombreProducto, idSucursal:=0, idTipoComprobante:=Nothing, letra:=Nothing, centroEmisor:=0, numeroComprobante:=0, buscaProductoExacto:=buscaProductoExacto)
   End Function
   Public Function GetProductosService(idProducto As String,
                                       nombreProducto As String,
                                       idSucursal As Integer,
                                       idTipoComprobante As String,
                                       letra As String,
                                       centroEmisor As Short,
                                       numeroComprobante As Long,
                                       buscaProductoExacto As Boolean) As DataTable
      Return New SqlServer.Productos(da).GetProductosService(idProducto, nombreProducto, idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, buscaProductoExacto)
   End Function

   Public Function Get1Calidad(idProducto As String) As DataTable
      Return New SqlServer.Productos(da).Productos_G1Calidad(idProducto)
   End Function

#End Region

End Class