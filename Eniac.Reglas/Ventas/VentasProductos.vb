Public Class VentasProductos
   Inherits Base

   Private _cache As BusquedasCacheadas

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.New(accesoDatos, New BusquedasCacheadas())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess, cache As BusquedasCacheadas)
      Me.NombreEntidad = "VentasProductos"
      da = accesoDatos
      _cache = cache
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Dim oVentas As Entidades.VentaProducto = DirectCast(entidad, Entidades.VentaProducto)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(oVentas, TipoSP._I)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos"

   Friend Sub EjecutaSP(ent As Entidades.VentaProducto, tipo As TipoSP)
      Dim sql = New SqlServer.VentasProductos(da)
      Select Case tipo
         Case TipoSP._I
            sql.VentasProductos_I(ent.IdSucursal, ent.TipoComprobante, ent.Letra, ent.CentroEmisor,
                         ent.NumeroComprobante, ent.Orden, ent.Producto.IdProducto, ent.Producto.NombreProducto, ent.Cantidad, ent.Precio, If(ent.CostoParaGrabar.HasValue, ent.CostoParaGrabar.Value, ent.Costo), ent.DescRecGeneral,
                         ent.DescRecGeneralProducto, ent.DescuentoRecargo, ent.DescuentoRecargoProducto,
                         ent.DescuentoRecargoPorc1, ent.DescuentoRecargoPorc2, ent.PrecioLista, ent.PrecioNeto, ent.Utilidad,
                         ent.ImporteTotal, ent.ImporteTotalNeto, ent.Kilos, ent.TipoImpuesto.IdTipoImpuesto,
                         ent.AlicuotaImpuesto, ent.ImporteImpuesto, ent.ComisionVendedorPorc, ent.ComisionVendedor, ent.IdListaPrecios, ent.NombreListaPrecios,
                         ent.ImporteImpuestoInterno, ent.IdCentroCosto, ent.PrecioConImpuestos, ent.PrecioNetoConImpuestos, ent.ImporteTotalConImpuestos, ent.ImporteTotalNetoConImpuestos,
                         ent.PrecioVentaPorTamano, ent.Tamano, ent.IdUnidadDeMedida, ent.IdMoneda, ent.Garantia, ent.FechaEntrega, ent.PorcImpuestoInterno, ent.OrigenPorcImpInt,
                         ent.TipoOperacion.ToString(), ent.Nota, ent.NombreCortoListaPrecios, ent.IdFormula, ent.Automatico, ent.IdEstadoVenta, ent.IdOferta, ent.FechaDevolucion,
                         ent.ModificoPrecioManualmente,
                         If(ent.Conversion = 0, 1, ent.Conversion), ent.CantidadManual, ent.IdaAtributoProducto01, ent.IdaAtributoProducto02, ent.IdaAtributoProducto03, ent.IdaAtributoProducto04,
                         ent.IdDeposito, ent.IdUbicacion)
            Dim rVPF = New VentasProductosFormulas(da)
            rVPF.InsertaDesdeVentaProducto(ent)

               'Case TipoSP._U

               '   sql.VentasProductos_U(ent.IdSucursal, ent.TipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, _
               '                   ent.Orden, ent.Producto, ent.Cantidad, ent.Precio, ent.Costo, ent.DescRecGeneral, _
               '                   ent.DescRecGeneralProducto, ent.DescuentoRecargo, ent.DescuentoRecargoProducto, _
               '                   ent.DescuentoRecargoPorc, ent.PrecioLista, ent.PrecioNeto, ent.Utilidad, ent.ImporteTotal, _
               '                   ent.ImporteTotalNeto)

         Case TipoSP._D
            Dim sql6 = New SqlServer.VentasProductosLotes(da)
            'Elimino los Lotes, no se llama directo esta funcionalidad.
            sql6.VentasProductosLotes_D2(ent.IdSucursal,
                                         ent.TipoComprobante,
                                         ent.Letra,
                                         ent.CentroEmisor,
                                         ent.NumeroComprobante)

            Dim sqlPPF = New SqlServer.VentasProductosFormulas(da)
            Dim orden As Integer? = Nothing
            If ent.Orden <> 0 Then orden = ent.Orden
            sqlPPF.VentasProductosFormulas_D(ent.IdSucursal, ent.TipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.IdProducto, orden, idProductoComponente:=Nothing, idFormula:=0)
            sql.VentasProductos_D(ent.IdSucursal, ent.TipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                  ent.Orden, ent.Producto.IdProducto)
      End Select
   End Sub

   Public Function GetUna(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroComprobante As Long,
                          orden As Integer,
                          idProducto As String) As Entidades.VentaProducto

      Dim stb = New StringBuilder()

      With stb
         .AppendLine("SELECT VP.*")
         .AppendLine("	   , PS.Stock")

         .AppendLine("  FROM VentasProductos VP ")
         .AppendLine(" INNER JOIN ProductosSucursales PS WITH(NOLOCK) ON VP.IdProducto = PS.IdProducto AND PS.IdSucursal = " & idSucursal.ToString())
         .AppendLine(" WHERE VP.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND VP.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND VP.Letra = '" & letra & "'")
         .AppendLine("   AND VP.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND VP.NumeroComprobante = " & numeroComprobante.ToString())
         .AppendLine("   AND VP.Orden = " & orden.ToString())
         .AppendLine("   AND VP.IdProducto = '" & idProducto.ToString() & "'")
      End With

      Dim dtPro As DataTable = da.GetDataTable(stb.ToString())
      Dim oVP As Entidades.VentaProducto

      If dtPro.Rows.Count > 0 Then

         Dim dr As DataRow = dtPro.Rows(0)

         'Solo tiene a encontrar 1.
         oVP = New Entidades.VentaProducto()
         With oVP
            .IdSucursal = Int32.Parse(dtPro.Rows(0)("IdSucursal").ToString())
            .TipoComprobante = dtPro.Rows(0)("IdTipoComprobante").ToString()
            .Letra = dtPro.Rows(0)("Letra").ToString()
            .CentroEmisor = Short.Parse(dtPro.Rows(0)("CentroEmisor").ToString())
            .NumeroComprobante = Long.Parse(dtPro.Rows(0)("NumeroComprobante").ToString())
            .Orden = Integer.Parse(dtPro.Rows(0)("Orden").ToString())
            .Producto = New Reglas.Productos(da).GetUno(dtPro.Rows(0)("IdProducto").ToString())
            .Producto.NombreProducto = dtPro.Rows(0)("NombreProducto").ToString()
            .Cantidad = Decimal.Parse(dtPro.Rows(0)("Cantidad").ToString())
            .Costo = Decimal.Parse(dtPro.Rows(0)("Costo").ToString())
            .PrecioLista = Decimal.Parse(dtPro.Rows(0)("PrecioLista").ToString())
            .Precio = Decimal.Parse(dtPro.Rows(0)("Precio").ToString())
            .DescuentoRecargoPorc1 = Decimal.Parse(dtPro.Rows(0)("DescuentoRecargoPorc").ToString())
            .DescuentoRecargoPorc2 = Decimal.Parse(dtPro.Rows(0)("DescuentoRecargoPorc2").ToString())
            .DescuentoRecargo = Decimal.Parse(dtPro.Rows(0)("DescuentoRecargo").ToString())
            .DescuentoRecargoProducto = Decimal.Parse(dtPro.Rows(0)("DescuentoRecargoProducto").ToString())
            .DescRecGeneral = Decimal.Parse(dtPro.Rows(0)("DescRecGeneral").ToString())
            .DescRecGeneralProducto = Decimal.Parse(dtPro.Rows(0)("DescRecGeneralProducto").ToString())
            .PrecioNeto = Decimal.Parse(dtPro.Rows(0)("PrecioNeto").ToString())
            .Utilidad = Decimal.Parse(dtPro.Rows(0)("Utilidad").ToString())
            .ImporteTotal = Decimal.Parse(dtPro.Rows(0)("ImporteTotal").ToString())
            .ImporteTotalNeto = Decimal.Parse(dtPro.Rows(0)("ImporteTotalNeto").ToString())
            .ImporteImpuestoInterno = Decimal.Parse(dtPro.Rows(0)("ImporteImpuestoInterno").ToString())
            .PorcImpuestoInterno = Decimal.Parse(dtPro.Rows(0)("PorcImpuestoInterno").ToString())
            .OrigenPorcImpInt = DirectCast([Enum].Parse(GetType(Entidades.OrigenesPorcImpInt), dtPro.Rows(0)("OrigenPorcImpInt").ToString()), Entidades.OrigenesPorcImpInt)
            If Not String.IsNullOrEmpty(dtPro.Rows(0)("Stock").ToString()) Then
               .Stock = Decimal.Parse(dtPro.Rows(0)("Stock").ToString())
            End If
            If Not String.IsNullOrWhiteSpace(dtPro.Rows(0)(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).ToString()) Then
               .CentroCosto = New ContabilidadCentrosCostos(da)._GetUna(Integer.Parse(dtPro.Rows(0)(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).ToString()))
            End If

            .PrecioConImpuestos = Decimal.Parse(dtPro.Rows(0)(Entidades.VentaProducto.Columnas.PrecioConImpuestos.ToString()).ToString())
            .PrecioNetoConImpuestos = Decimal.Parse(dtPro.Rows(0)(Entidades.VentaProducto.Columnas.PrecioNetoConImpuestos.ToString()).ToString())
            .ImporteTotalConImpuestos = Decimal.Parse(dtPro.Rows(0)(Entidades.VentaProducto.Columnas.ImporteTotalConImpuestos.ToString()).ToString())
            .ImporteTotalNetoConImpuestos = Decimal.Parse(dtPro.Rows(0)(Entidades.VentaProducto.Columnas.ImporteTotalNetoConImpuestos.ToString()).ToString())

            If IsNumeric(dr(Entidades.VentaProducto.Columnas.PrecioVentaPorTamano.ToString()).ToString()) Then
               .PrecioVentaPorTamano = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.PrecioVentaPorTamano.ToString()).ToString())
            End If
            If IsNumeric(dr(Entidades.VentaProducto.Columnas.Tamano.ToString()).ToString()) Then
               .Tamano = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.Tamano.ToString()).ToString())
            End If
            If Not String.IsNullOrWhiteSpace(dr(Entidades.VentaProducto.Columnas.IdUnidadDeMedida.ToString()).ToString()) Then
               .IdUnidadDeMedida = dr(Entidades.VentaProducto.Columnas.IdUnidadDeMedida.ToString()).ToString()
            End If

            If IsNumeric(dr(Entidades.VentaProducto.Columnas.IdMoneda.ToString())) Then
               .Moneda = New Reglas.Monedas(da).GetUna(Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdMoneda.ToString()).ToString()))
            End If

            .Garantia = Integer.Parse(dr(Entidades.VentaProducto.Columnas.Garantia.ToString()).ToString())
            If Not String.IsNullOrWhiteSpace(dr(Entidades.VentaProducto.Columnas.FechaEntrega.ToString()).ToString()) Then
               .FechaEntrega = DateTime.Parse(dr(Entidades.VentaProducto.Columnas.FechaEntrega.ToString()).ToString())
            End If

            .TipoOperacion = DirectCast([Enum].Parse(GetType(Entidades.Producto.TiposOperaciones), dr(Entidades.PedidoProducto.Columnas.TipoOperacion.ToString()).ToString()), Entidades.Producto.TiposOperaciones)
            .Nota = dr(Entidades.PedidoProducto.Columnas.Nota.ToString()).ToString()

            If IsNumeric(dr(Entidades.VentaProducto.Columnas.IdFormula.ToString())) Then
               .IdFormula = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdFormula.ToString()).ToString())
               .NombreFormula = New Reglas.ProductosFormulas(da).GetUna(.IdProducto, .IdFormula, AccionesSiNoExisteRegistro.Vacio).NombreFormula
            End If

            If IsNumeric(dr(Entidades.VentaProducto.Columnas.IdEstadoVenta.ToString())) Then
               .IdEstadoVenta = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdEstadoVenta.ToString()).ToString())
            End If

            If IsNumeric(dr(Entidades.VentaProducto.Columnas.IdOferta.ToString())) Then
               .IdOferta = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdOferta.ToString()).ToString())
            End If

            .FechaDevolucion = dr.Field(Of Date?)(Entidades.VentaProducto.Columnas.FechaDevolucion.ToString())

            '# Ventas Productos Lotes
            Dim rVentasProductosLotes As Reglas.VentasProductosLotes = New Reglas.VentasProductosLotes
            .VentasProductosLotes = rVentasProductosLotes.GetTodos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden)

            .ModificoPrecioManualmente = dr.Field(Of Boolean)("ModificoPrecioManualmente")
            .Conversion = dr.Field(Of Decimal)(Entidades.VentaProducto.Columnas.Conversion.ToString())
            .CantidadManual = dr.Field(Of Decimal)(Entidades.VentaProducto.Columnas.CantidadManual.ToString())

            '-- REQ-34669.- --------------------------------------------------------------------
            .IdaAtributoProducto01 = If(Not String.IsNullOrEmpty(dr("IdaAtributoProducto01").ToString()), Integer.Parse(dr("IdaAtributoProducto01").ToString()), 0)
            .IdaAtributoProducto02 = If(Not String.IsNullOrEmpty(dr("IdaAtributoProducto02").ToString()), Integer.Parse(dr("IdaAtributoProducto02").ToString()), 0)
            .IdaAtributoProducto03 = If(Not String.IsNullOrEmpty(dr("IdaAtributoProducto03").ToString()), Integer.Parse(dr("IdaAtributoProducto03").ToString()), 0)
            .IdaAtributoProducto04 = If(Not String.IsNullOrEmpty(dr("IdaAtributoProducto04").ToString()), Integer.Parse(dr("IdaAtributoProducto04").ToString()), 0)
            '-----------------------------------------------------------------------------------

         End With

      Else
         Throw New Exception("No existe este comprobante de venta.")
      End If

      Return oVP

   End Function

   Public Function GetEstadVentasProductos(suc As List(Of Integer),
                                           cantidad As Integer,
                                           Desde As DateTime,
                                           Hasta As DateTime,
                                           idRubro As Entidades.Rubro(),
                                           idSubRubro As Entidades.SubRubro(),
                                           idMarca As Entidades.Marca(),
                                           idModelo As Int32,
                                           idCliente As Long,
                                           IdVendedor As Entidades.Empleado()) As DataTable

      Dim sql As SqlServer.VentasProductos
      Dim dt As DataTable
      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim IvaDiscriminado As Boolean
      IvaDiscriminado = oCategoriaFiscalEmpresa.IvaDiscriminado

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.VentasProductos(da)

         dt = sql.GetEstadVentasProductos(suc, cantidad, Desde, Hasta, idRubro, idSubRubro, idMarca, idModelo, idCliente, IvaDiscriminado, IdVendedor)

         dt.Columns.Add("PorcCantidad", System.Type.GetType("System.Decimal"))
         dt.Columns.Add("PorcImporte", System.Type.GetType("System.Decimal"))

         Dim sumacantidad As Decimal = 0
         Dim sumapesos As Decimal = 0

         For Each dr As DataRow In dt.Rows
            sumacantidad += Decimal.Parse(dr("Cantidad").ToString())
            sumapesos += Decimal.Parse(dr("Importe").ToString())
         Next
         For Each dr As DataRow In dt.Rows
            dr("PorcCantidad") = Decimal.Round(Decimal.Parse(dr("Cantidad").ToString()) / sumacantidad * 100, 2)
            dr("PorcImporte") = Decimal.Round(Decimal.Parse(dr("Importe").ToString()) / sumapesos * 100, 2)
         Next

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetTotalesPorProductosClientes(idSucursal As Integer,
                                                  desde As Date,
                                                  hasta As Date,
                                                  idMarca As Integer,
                                                  idModelo As Integer,
                                                  idRubro As Integer,
                                                  idSubRubro As Integer,
                                                  idZonaGeografica As String,
                                                  idTipoComprobante As String,
                                                  tipoOperacion As Entidades.Producto.TiposOperaciones?,
                                                  nota As String) As DataTable
      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim IvaDiscriminado As Boolean
      IvaDiscriminado = oCategoriaFiscalEmpresa.IvaDiscriminado

      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.VentasProductos
         sql = New SqlServer.VentasProductos(da)

         Dim dt As DataTable
         dt = sql.GetTotalesPorProductosClientes(idSucursal,
                                                 desde, hasta,
                                                 idMarca,
                                                 idModelo,
                                                 idRubro,
                                                 idSubRubro,
                                                 idZonaGeografica,
                                                 idTipoComprobante,
                                                 IvaDiscriminado,
                                                 tipoOperacion,
                                                 nota,
                                                 actual.NivelAutorizacion)
         Return dt
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetTotalesPorSubRubrosProductos(idSucursal As Integer, desde As Date, hasta As Date,
                                                   marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                                   rubros As Entidades.Rubro(), subRubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro()) As DataTable
      Return EjecutaConConexion(Function() _GetTotalesPorSubRubrosProductos(idSucursal, desde, hasta, marcas, modelos, rubros, subRubros, subSubRubros))
   End Function

   Public Function _GetTotalesPorSubRubrosProductos(idSucursal As Integer, desde As Date, hasta As Date,
                                                    marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                                    rubros As Entidades.Rubro(), subRubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro()) As DataTable
      'idMarca As Integer, idModelo As Integer, idRubro As Integer, idSubRubro As Integer) As DataTable
      Dim oCategoriaFiscalEmpresa = New CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)

      Dim sql = New SqlServer.VentasProductos(da)
      Return sql.GetTotalesPorSubRubrosProductos(idSucursal, desde, hasta,
                                                 marcas, modelos, rubros, subRubros, subSubRubros,
                                                 oCategoriaFiscalEmpresa.IvaDiscriminado)
   End Function

   Public Function GetListasPreciosVentasProductos() As DataTable
      Dim sql As SqlServer.VentasProductos
      Dim dt As DataTable
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.VentasProductos(da)

         dt = sql.GetListasPreciosVentasProductos()

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function GetListasPreciosVentasProductosDescripcion() As DataTable
      Dim sql As SqlServer.VentasProductos
      Dim dt As DataTable
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.VentasProductos(da)

         dt = sql.GetListasPreciosVentasProductosDescripcion()

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Protected Overridable Function GetSqlServer() As SqlServer.VentasProductos
      Return New SqlServer.VentasProductos(da)
   End Function
   Public Function GetDetallePorProductos(sucursales As Entidades.Sucursal(),
                                          desde As Date,
                                          hasta As Date,
                                          idCliente As Long) As DataTable
      Return GetDetallePorProductos(sucursales,
                                  desde,
                                  hasta,
                                  idProducto:=String.Empty,
                                  idMarca:=0,
                                  idModelo:=0,
                                  idRubro:=0,
                                  idSubSubRubro:=0,
                                  idZonaGeografica:=String.Empty,
                                  idTipoComprobante:=String.Empty,
                                  idVendedor:=0,
                                  vendedor:=Entidades.OrigenFK.Movimiento,
                                  idCliente:=idCliente,
                                  grabaLibro:="TODOS",
                                  afectaCaja:="SI",
                                  idFormaDePago:=0,
                                  idUsuario:=String.Empty,
                                  porcUtilidadDesde:=-1,
                                  porcUtilidadHasta:=-1,
                                  cantidad:=String.Empty,
                                  ingresosBrutos:="TODOS",
                                  prodDescRec:="TODOS",
                                  idProveedor:=0,
                                  idLocalidad:=0,
                                  idProvincia:=String.Empty,
                                  idCategoria:=0,
                                  listaPrecios:=String.Empty,
                                  categoria:=Entidades.OrigenFK.Movimiento,
                                  listaComp:=Nothing,
                                  esComercial:=Nothing,
                                  idTransportista:=0,
                                  tipoOperacion:=Nothing,
                                  nota:=String.Empty,
                                  letra:=String.Empty,
                                 centroEmisor:=0,
                                 numeroComprobante:=0,
                                 cajas:=Nothing,
                                 idSubRubro:=0,
                                 idListaPrecios:=-1,
                                 grupo:=String.Empty,
                                 idPaciente:=Nothing,
                                 idDoctor:=Nothing,
                                 fechaCirugia:=Nothing,
                                 cliente:=Entidades.Cliente.ClienteVinculado.Cliente,
                                 productoEsComercial:=Entidades.Publicos.SiNoTodos.TODOS)

   End Function

   Public Overridable Function GetDetallePorProductos(
                      sucursales As Entidades.Sucursal(), desde As Date, hasta As Date,
                      idProducto As String, idMarca As Integer, idModelo As Integer, idRubro As Integer, idSubRubro As Integer, idSubSubRubro As Integer,
                      idZonaGeografica As String,
                      idTipoComprobante As String,
                      idVendedor As Integer, vendedor As Entidades.OrigenFK, idCliente As Long,
                      grabaLibro As String, afectaCaja As String, idFormaDePago As Integer, idUsuario As String,
                      porcUtilidadDesde As Decimal, porcUtilidadHasta As Decimal,
                      cantidad As String, ingresosBrutos As String, prodDescRec As String,
                      idProveedor As Long, idLocalidad As Integer, idProvincia As String,
                      idCategoria As Integer, listaPrecios As String, categoria As Entidades.OrigenFK,
                      listaComp As List(Of Entidades.TipoComprobante),
                      esComercial As Boolean?, idTransportista As Integer,
                      tipoOperacion As Entidades.Producto.TiposOperaciones?,
                      nota As String,
                      letra As String, centroEmisor As Short, numeroComprobante As Long,
                      cajas As Entidades.CajaNombre(),
                      idListaPrecios As Integer,
                      grupo As String,
                      idPaciente As Long?, idDoctor As Long?, fechaCirugia As Date?,
                      cliente As Entidades.Cliente.ClienteVinculado,
                      productoEsComercial As Entidades.Publicos.SiNoTodos) As DataTable

      Return EjecutaConConexion(
         Function()
            Return GetSqlServer().
                        GetDetallePorProductos(sucursales, desde, hasta,
                                               idProducto, idMarca, idModelo, idRubro, idSubRubro, idSubSubRubro,
                                               idZonaGeografica,
                                               idTipoComprobante,
                                               idVendedor, vendedor, idCliente,
                                               grabaLibro, afectaCaja, idFormaDePago, idUsuario,
                                               porcUtilidadDesde, porcUtilidadHasta,
                                               cantidad, ingresosBrutos, prodDescRec,
                                               idProveedor, idLocalidad, idProvincia,
                                               idCategoria, listaPrecios, categoria,
                                               listaComp,
                                               esComercial, idTransportista,
                                               tipoOperacion,
                                               nota,
                                               letra, centroEmisor, numeroComprobante,
                                               cajas,
                                               idListaPrecios,
                                               actual.NivelAutorizacion,
                                               grupo,
                                               idPaciente, idDoctor, fechaCirugia,
                                               cliente, productoEsComercial)

         End Function)
   End Function

   Public Overridable Function GetProductosNoVendidos(sucursales As IEnumerable(Of Entidades.Sucursal),
                                                      desde As Date?, hasta As Date?,
                                                      idProveedor As Long, idCliente As Long, idProducto As String, activoProducto As Entidades.Publicos.SiNoTodos,
                                                      marcas As IEnumerable(Of Entidades.Marca), rubros As IEnumerable(Of Entidades.Rubro),
                                                      subRubros As IEnumerable(Of Entidades.SubRubro), subSubRubros As IEnumerable(Of Entidades.SubSubRubro),
                                                      idListaPrecio As Integer, stockSN As Boolean, idVendedor As Integer, idZonaGeografica As String,
                                                      idCategoria As Integer, idLocalidad As Integer, idProvincia As String, idRuta As Integer) As DataTable
      Return EjecutaConConexion(
      Function()
         Return GetSqlServer().GetProductosNoVendidos(sucursales,
                                                      desde, hasta,
                                                      idProveedor, idCliente, idProducto, activoProducto,
                                                      marcas, rubros, subRubros, subSubRubros,
                                                      idListaPrecio, stockSN, idVendedor, idZonaGeografica, idCategoria,
                                                      idLocalidad, idProvincia, idRuta)
      End Function)
   End Function

   Public Function GetUltimoDeProducto(idSucursal As Integer, idTipoComprobante As String, idProducto As String, idCliente As Long) As Decimal
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.VentasProductos(da)
            Dim precioVenta = sql.GetUltimoDeProducto(idSucursal, idTipoComprobante, idProducto, idCliente)
            Return precioVenta
         End Function)
   End Function

   Public Function UltimaVentaDelProducto(idCliente As Long, idProducto As String) As DataTable
      Return New SqlServer.VentasProductos(da).UltimaVentaDelProducto(idCliente, idProducto)
   End Function

   Public Function GetDetallePorComprobante(drComps As List(Of DataRow)) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.VentasProductos(da).GetDetallePorComprobante(drComps))
   End Function

   Public Function GetDetallePorComprobante(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Short,
                                           numerosComprobantes() As Long) As DataTable
      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.VentasProductos = New SqlServer.VentasProductos(da)

         Return sql.GetDetallePorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numerosComprobantes)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetNombresProductos(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numerosComprobante As Long) As DataTable
      Try

         Dim sql As SqlServer.VentasProductos = New SqlServer.VentasProductos(da)

         Return sql.GetNombresProductos(idSucursal, idTipoComprobante, letra, centroEmisor, numerosComprobante)

      Catch ex As Exception
         Throw
      End Try
   End Function

   Public Function GetDetalleCompletoPorComprobante(idSucursal As Integer,
                                                    idTipoComprobante As String,
                                                    letra As String,
                                                    centroEmisor As Short,
                                                    numerosComprobantes As Long) As DataTable
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then Me.da.OpenConection()
         Dim sql As SqlServer.VentasProductos = New SqlServer.VentasProductos(da)
         Return sql.GetDetalleCompletoPorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numerosComprobantes,
                                                     Publicos.ImpresiónComprobantesMiraOrdenProductos)
      Finally
         If blnAbreConexion Then Me.da.CloseConection()
      End Try
   End Function

   Public Function GetComisionesPorProducto(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date,
                                            idProducto As String, idMarca As Integer, idModelo As Integer, idRubro As Integer, idSubRubro As Integer,
                                            idZonaGeografica As String, idTipoComprobante As String, idVendedor As Integer, idCliente As Long,
                                            grabaLibro As String, afectaCaja As String, idFormaDePago As Integer, idUsuario As String,
                                            porcUtilidadDesde As Decimal, porcUtilidadHasta As Decimal,
                                            cantidad As String,
                                            ingresosBrutos As String, prodDescRec As String,
                                            idProveedor As Long, idLocalidad As Integer, idProvincia As String, idCategoria As Integer,
                                            esParcial As Boolean, tipoVendedor As String, idCobrador As Integer, tipoCobrador As String,
                                            conIva As Boolean, porVendedor As Boolean,
                                            embarcacion As Boolean, idCategoriaEmbarcacion As Integer,
                                            strCalculoComisionVendedor As String) As DataTable
      Return EjecutaConConexion(
      Function()
         Dim oCategoriaFiscalEmpresa = New CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)

         Dim sql = New SqlServer.VentasProductos(da)
         'IdSucursal
         Dim dt = sql.GetComisionesPorProducto(sucursales, desde, hasta,
                                               idProducto, idMarca, idModelo, idRubro, idSubRubro,
                                               idZonaGeografica, idTipoComprobante, idVendedor, idCliente,
                                               grabaLibro, afectaCaja, idFormaDePago, idUsuario,
                                               porcUtilidadDesde, porcUtilidadHasta,
                                               cantidad,
                                               oCategoriaFiscalEmpresa.IvaDiscriminado, ingresosBrutos, prodDescRec,
                                               idProveedor, idLocalidad, idProvincia,
                                               idCategoria, esParcial, tipoVendedor, idCobrador, tipoCobrador,
                                               conIva, porVendedor,
                                               embarcacion, idCategoriaEmbarcacion,
                                               Publicos.ComisionVendedor, strCalculoComisionVendedor)

         If esParcial Then
            dt.Columns.Add("Comision", GetType(Decimal), "ImporteTotalParcial * PorcComision / 100")
         Else
            If strCalculoComisionVendedor = "LISTADO" Then
               dt.Columns.Add("Comision", GetType(Decimal), "ImporteTotalNeto * PorcComision / 100")
            Else
               dt.Columns.Add("Comision", GetType(Decimal), "ComisionVendedor")
            End If
         End If

         Return dt
      End Function)
   End Function

   Public Function GetComisionesSobreVentas(idSucursal As Integer, desde As Date, hasta As Date,
                                            idProducto As String, idMarca As Integer, idModelo As Integer, idRubro As Integer, idSubRubro As Integer,
                                            idTipoComprobante As String, grabaLibro As Entidades.Publicos.SiNoTodos, afectaCaja As Entidades.Publicos.SiNoTodos,
                                            idCategoria As Short, idCliente As Long, idProveedor As Long,
                                            idVendedor As Integer, origenVendedor As Entidades.OrigenFK,
                                            idFormaDePago As Integer, idUsuario As String,
                                            porcUtilidadDesde As Decimal, porcUtilidadHasta As Decimal,
                                            cantidad As String, ingresosBrutos As Entidades.Publicos.SiNoTodos, prodDescRec As Entidades.Publicos.SiNoTodos,
                                            idLocalidad As Integer, idProvincia As String, idZonaGeografica As String,
                                            conIva As Boolean) As DataTable
      Return EjecutaConConexion(
      Function()
         Dim oCategoriaFiscalEmpresa = New CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
         Dim sql = New SqlServer.VentasProductos(da)
         Dim dt = sql.GetComisionesSobreVentas(
                           idSucursal, desde, hasta,
                           idProducto, idMarca, idModelo, idRubro, idSubRubro,
                           idTipoComprobante, grabaLibro, afectaCaja,
                           idCategoria, idCliente, idProveedor,
                           idVendedor, origenVendedor,
                           idFormaDePago, idUsuario,
                           porcUtilidadDesde, porcUtilidadHasta,
                           cantidad, oCategoriaFiscalEmpresa.IvaDiscriminado, ingresosBrutos, prodDescRec,
                           idLocalidad, idProvincia, idZonaGeografica,
                           conIva, Publicos.CalculoComisionVendedor, Publicos.CalculoComisionVendedor)
         If Publicos.CalculoComisionVendedor = "LISTADO" Then
            dt.Columns.Add("Comision", GetType(Decimal), "ImporteTotalNeto * PorcComision / 100")
         End If

         Return dt
      End Function)
   End Function


   Public Sub FillDetalleParaOrganizarRepartos(dtComprobantes As DataTable, dtProductos As DataTable)
      Try
         da.OpenConection()

         Dim dtTemp As DataTable

         For Each dr As DataRow In dtComprobantes.Rows
            dtTemp = New SqlServer.VentasProductos(da).GetDetalleParaOrganizarRepartos(Integer.Parse(dr("IdSucursal").ToString()),
                                                                                       dr("IdTipoComprobante").ToString(),
                                                                                       dr("Letra").ToString(),
                                                                                       Short.Parse(dr("CentroEmisor").ToString()),
                                                                                       Long.Parse(dr("NumeroComprobante").ToString()))
            dtProductos.ImportRowRange(dtTemp.Select())
         Next

         dtProductos.AcceptChanges()
      Catch
         dtProductos.RejectChanges()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   'Public Function GetDetalleParaOrganizarRepartos(idSucursal As Integer,
   '                                                idTipoComprobante As String,
   '                                                letra As String,
   '                                                centroEmisor As Short,
   '                                                numerosComprobantes As Long) As DataTable
   '   Return New SqlServer.VentasProductos(da).GetDetalleParaOrganizarRepartos(idSucursal, idTipoComprobante, letra, centroEmisor, numerosComprobantes)
   'End Function

   Public Sub DespacharComprobantes(dt As DataTable, trasportista As Entidades.Transportista, fechaEnvio As Date, nroReparto As Integer)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         Dim rCtaCte = New CuentasCorrientes(da)
         For Each dr As DataRow In dt.Rows
            sql.GrabaMercaderiaDespachada(Integer.Parse(dr("IdSucursal").ToString()),
                                          dr("IdTipoComprobante").ToString(), dr("Letra").ToString(),
                                          Short.Parse(dr("CentroEmisor").ToString()),
                                          Long.Parse(dr("NumeroComprobante").ToString()),
                                          despacho:=True,
                                          numeroReparto:=nroReparto,
                                          fechaEnvio:=fechaEnvio,
                                          idTransportista:=trasportista.idTransportista)
            rCtaCte._ActualizarNumeroReparto(dr.Field(Of Integer)("IdSucursal"),
                                             dr.Field(Of String)("IdTipoComprobante"),
                                             dr.Field(Of String)("Letra"),
                                             Short.Parse(dr("CentroEmisor").ToString()),
                                             dr.Field(Of Long)("NumeroComprobante"),
                                             numeroReparto:=nroReparto)
         Next

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         da.CloseConection()
      End Try
   End Sub


   Friend Function GetTodos(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Short,
                            numeroComprobante As Long) As List(Of Entidades.VentaProducto)
      Dim result = New List(Of Entidades.VentaProducto)()
      Dim stb = New StringBuilder()
      'Detalle de Productos
      With stb
         .AppendLine("Select VP.IdSucursal")
         .AppendLine("      ,VP.IdTipoComprobante")
         .AppendLine("      ,VP.Letra")
         .AppendLine("      ,VP.CentroEmisor")
         .AppendLine("      ,VP.NumeroComprobante")
         .AppendLine("      ,VP.Orden")
         .AppendLine("      ,VP.IdProducto")
         '.AppendLine("	    ,P.NombreProducto")
         .AppendLine("	    ,VP.NombreProducto")
         .AppendLine("      ,PPP.CodigoProductoProveedor")
         .AppendLine("      ,VP.Cantidad")
         .AppendLine("	    ,PS.Stock")
         .AppendLine("      ,VP.Costo")
         .AppendLine("      ,VP.PrecioLista")
         .AppendLine("      ,VP.Precio")
         .AppendLine("      ,VP.DescRecGeneral")
         .AppendLine("      ,VP.DescuentoRecargo")
         .AppendLine("      ,VP.DescuentoRecargoProducto")
         .AppendLine("      ,VP.DescuentoRecargoPorc ")
         .AppendLine("      ,VP.DescuentoRecargoPorc2 ")
         .AppendLine("      ,VP.DescRecGeneralProducto ")
         .AppendLine("      ,VP.PrecioNeto")
         .AppendLine("      ,VP.Utilidad")
         .AppendLine("      ,VP.ImporteTotal")
         .AppendLine("      ,VP.ImporteTotalNeto")
         .AppendLine("      ,VP.Kilos")
         .AppendLine("      ,VP.IdTipoImpuesto")
         .AppendLine("      ,VP.AlicuotaImpuesto")
         .AppendLine("      ,VP.ImporteImpuesto")
         .AppendLine("      ,VP.ComisionVendedor")
         .AppendLine("      ,VP.ComisionVendedorPorc")
         .AppendLine("       ,VP.IdListaPrecios")
         .AppendLine("       ,VP.NombreListaPrecios")
         .AppendLine("      ,VP.ImporteImpuestoInterno")
         .AppendLine("      ,VP.PorcImpuestoInterno")
         .AppendLine("      ,VP.OrigenPorcImpInt")

         .AppendLine("      ,VP.IdCentroCosto")

         .AppendLine("      ,VP.PrecioConImpuestos")
         .AppendLine("      ,VP.PrecioNetoConImpuestos")
         .AppendLine("      ,VP.ImporteTotalConImpuestos")
         .AppendLine("      ,VP.ImporteTotalNetoConImpuestos")

         .AppendLine("      ,VP.PrecioVentaPorTamano")
         .AppendLine("      ,VP.Tamano")
         .AppendLine("      ,VP.IdUnidadDeMedida")
         .AppendLine("      ,VP.IdMoneda")

         .AppendLine("      ,VP.Garantia")
         .AppendLine("      ,VP.FechaEntrega")

         .AppendLine("      ,VP.TipoOperacion")
         .AppendLine("      ,VP.Nota")

         .AppendLine("      ,VP.NombreCortoListaPrecios")
         .AppendLine("      ,VP.Automatico")

         .AppendLine("      ,VP.IdEstadoVenta")
         .AppendLine("      ,VP.IdOferta")
         .AppendLine("      ,VP.ModificoPrecioManualmente")
         .AppendLine("      ,VP.Conversion")
         .AppendLine("      ,VP.CantidadManual")
         .AppendLine("      ,VP.IdFormula")
         '-------------------------------------------------------------
         .AppendLine("      ,VP.IdaAtributoProducto01")
         .AppendLine("      ,VP.IdaAtributoProducto02")
         .AppendLine("      ,VP.IdaAtributoProducto03")
         .AppendLine("      ,VP.IdaAtributoProducto04")
         '-------------------------------------------------------------
         .AppendLine("      ,VP.IdDeposito")
         .AppendLine("      ,SD.NombreDeposito")
         .AppendLine("      ,VP.IdUbicacion")
         .AppendLine("      ,SU.NombreUbicacion")
         '-------------------------------------------------------------
         .AppendLine("     ,PSP.FechaActualizacion") '-.PE-32964.-

         .AppendLine("  FROM VentasProductos VP")
         .AppendLine(" INNER JOIN Productos P On P.IdProducto = VP.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS On P.IdProducto = PS.IdProducto And PS.IdSucursal = " & idSucursal.ToString())

         .AppendLine(" LEFT JOIN SucursalesDepositos SD On SD.IdSucursal = PS.IdSucursal And SD.IdDeposito = VP.IdDeposito")
         .AppendLine(" LEFT JOIN SucursalesUbicaciones SU On SU.IdSucursal = PS.IdSucursal And SU.IdDeposito = VP.IdDeposito And SU.IdUbicacion = VP.IdUbicacion")

         '-.PE-32964.-
         .AppendFormatLine("  LEFT JOIN ProductosSucursalesPrecios PSP On PSP.IdProducto = PS.IdProducto And PSP.IdSucursal = PS.IdSucursal And PSP.IdListaPrecios = VP.IdListaPrecios")

         .AppendFormatLine("  LEFT JOIN ProductosProveedores PPP On PPP.IdProducto = P.IdProducto And PPP.IdProveedor = P.IdProveedor")

         .AppendFormatLine(" WHERE VP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   And VP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND VP.Letra = '{0}'", letra)
         .AppendFormatLine("   AND VP.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND VP.NumeroComprobante = {0}", numeroComprobante)
         If Publicos.ImpresiónComprobantesMiraOrdenProductos Then
            .AppendLine(" ORDER BY P.Orden, VP.Orden")
         Else
            .AppendLine(" ORDER BY VP.Orden")
         End If

      End With

      Using dtPro = da.GetDataTable(stb.ToString())
         For Each dr As DataRow In dtPro.Rows
            Dim oVP = New Entidades.VentaProducto()
            With oVP
               .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
               .TipoComprobante = dr("IdTipoComprobante").ToString()
               .Letra = dr("Letra").ToString()
               .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
               .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
               .Orden = Integer.Parse(dr("Orden").ToString())
               .Producto = New Reglas.Productos(da).GetUno(dr("IdProducto").ToString())
               .Producto.NombreProducto = dr("NombreProducto").ToString()
               .CodigoProductoProveedor = dr.Field(Of String)("CodigoProductoProveedor")
               .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
               If Not String.IsNullOrEmpty(dr("Stock").ToString()) Then
                  .Stock = Decimal.Parse(dr("Stock").ToString())
               End If
               .Costo = Decimal.Parse(dr("Costo").ToString())
               .PrecioLista = Decimal.Parse(dr("PrecioLista").ToString())
               .Precio = Decimal.Parse(dr("Precio").ToString())
               .DescRecGeneral = Decimal.Parse(dr("DescRecGeneral").ToString())
               .DescuentoRecargo = Decimal.Parse(dr("DescuentoRecargo").ToString())
               .DescuentoRecargoProducto = Decimal.Parse(dr("DescuentoRecargoProducto").ToString())
               .DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
               .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
               .DescRecGeneralProducto = Decimal.Parse(dr("DescRecGeneralProducto").ToString())
               .PrecioNeto = Decimal.Parse(dr("PrecioNeto").ToString())
               .Utilidad = Decimal.Parse(dr("Utilidad").ToString())
               .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
               .ImporteTotalNeto = Decimal.Parse(dr("ImporteTotalNeto").ToString())
               .FechaActualizacion = dr.Field(Of Date?)("FechaActualizacion").IfNull(New Date()) '-.PE-32964.-

               If Not String.IsNullOrEmpty(dr("Kilos").ToString()) Then
                  .Kilos = Decimal.Parse(dr("Kilos").ToString())
               End If

               .TipoImpuesto = New Reglas.TiposImpuestos(da).GetUno(DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), dr("IdTipoImpuesto").ToString()), Entidades.TipoImpuesto.Tipos))
               .AlicuotaImpuesto = Decimal.Parse(dr("AlicuotaImpuesto").ToString())
               .ImporteImpuesto = Decimal.Parse(dr("ImporteImpuesto").ToString())
               .ComisionVendedor = Decimal.Parse(dr("ComisionVendedor").ToString())
               .ComisionVendedorPorc = Decimal.Parse(dr("ComisionVendedorPorc").ToString())
               .IdListaPrecios = Integer.Parse(dr("IdListaPrecios").ToString())
               .NombreListaPrecios = dr("NombreListaPrecios").ToString()
               .NombreCortoListaPrecios = dr("NombreCortoListaPrecios").ToString()
               .ImporteImpuestoInterno = Decimal.Parse(dr("ImporteImpuestoInterno").ToString())

               .PorcImpuestoInterno = dr.Field(Of Decimal)("PorcImpuestoInterno")
               .OrigenPorcImpInt = dr.Field(Of String)("OrigenPorcImpInt").StringToEnum(Entidades.OrigenesPorcImpInt.NETO)

               If Not String.IsNullOrWhiteSpace(dr(Entidades.VentaProducto.Columnas.IdCentroCosto.ToString()).ToString()) Then
                  .CentroCosto = New Reglas.ContabilidadCentrosCostos(da)._GetUna(Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdCentroCosto.ToString()).ToString()))
               End If

               .PrecioConImpuestos = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.PrecioConImpuestos.ToString()).ToString())
               .PrecioNetoConImpuestos = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.PrecioNetoConImpuestos.ToString()).ToString())
               .ImporteTotalConImpuestos = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.ImporteTotalConImpuestos.ToString()).ToString())
               .ImporteTotalNetoConImpuestos = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.ImporteTotalNetoConImpuestos.ToString()).ToString())

               If IsNumeric(dr(Entidades.VentaProducto.Columnas.PrecioVentaPorTamano.ToString()).ToString()) Then
                  .PrecioVentaPorTamano = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.PrecioVentaPorTamano.ToString()).ToString())
               End If
               If IsNumeric(dr(Entidades.VentaProducto.Columnas.Tamano.ToString()).ToString()) Then
                  .Tamano = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.Tamano.ToString()).ToString())
               End If
               If Not String.IsNullOrWhiteSpace(dr(Entidades.VentaProducto.Columnas.IdUnidadDeMedida.ToString()).ToString()) Then
                  .IdUnidadDeMedida = dr(Entidades.VentaProducto.Columnas.IdUnidadDeMedida.ToString()).ToString()
               End If
               If IsNumeric(dr(Entidades.VentaProducto.Columnas.IdMoneda.ToString())) Then
                  .Moneda = New Reglas.Monedas(da).GetUna(Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdMoneda.ToString()).ToString()))
               End If

               .Garantia = Integer.Parse(dr("Garantia").ToString())
               If Not String.IsNullOrWhiteSpace(dr(Entidades.VentaProducto.Columnas.FechaEntrega.ToString()).ToString()) Then
                  .FechaEntrega = DateTime.Parse(dr(Entidades.VentaProducto.Columnas.FechaEntrega.ToString()).ToString())
               End If

               .TipoOperacion = DirectCast([Enum].Parse(GetType(Eniac.Entidades.Producto.TiposOperaciones),
                                                        dr(Entidades.VentaProducto.Columnas.TipoOperacion.ToString()).ToString()),
                                           Eniac.Entidades.Producto.TiposOperaciones)
               .Nota = dr(Entidades.VentaProducto.Columnas.Nota.ToString()).ToString()

               .Automatico = Boolean.Parse(dr(Entidades.VentaProducto.Columnas.Automatico.ToString()).ToString())

               If IsNumeric(dr(Entidades.VentaProducto.Columnas.IdEstadoVenta.ToString())) Then
                  .IdEstadoVenta = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdEstadoVenta.ToString()).ToString())
               End If

               If IsNumeric(dr(Entidades.VentaProducto.Columnas.IdOferta.ToString())) Then
                  .IdOferta = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdOferta.ToString()).ToString())
               End If

               '# Productos con Nro. Serie
               .Producto.NrosSeries = Me.ObtenerProductosConNroSerie(.IdSucursal, .TipoComprobante, .Letra, centroEmisor, .NumeroComprobante, .Orden, .IdProducto)

               '# Productos Lotes
               Dim rVPL As Reglas.VentasProductosLotes = New Reglas.VentasProductosLotes(da)
               .VentasProductosLotes = rVPL.GetTodos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, .Producto.IdProducto, .Orden)


               .IdFormula = If(String.IsNullOrEmpty(dr(Entidades.VentaProducto.Columnas.IdFormula.ToString()).ToString()), 0, Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdFormula.ToString()).ToString()))

               .ModificoPrecioManualmente = dr.Field(Of Boolean)("ModificoPrecioManualmente")
               .Conversion = dr.Field(Of Decimal)(Entidades.VentaProducto.Columnas.Conversion.ToString())
               .CantidadManual = dr.Field(Of Decimal)(Entidades.VentaProducto.Columnas.CantidadManual.ToString())
               '-- REQ-34987.- --------------------------------------------------------------------
               .IdaAtributoProducto01 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto01").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto01").ToString()))
               .IdaAtributoProducto02 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto02").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto02").ToString()))
               .IdaAtributoProducto03 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto03").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto03").ToString()))
               .IdaAtributoProducto04 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto04").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto04").ToString()))
               '-----------------------------------------------------------------------------------
               .IdDeposito = If(String.IsNullOrEmpty(dr("IdDeposito").ToString()), 0, Integer.Parse(dr("IdDeposito").ToString()))
               .NombreDeposito = If(String.IsNullOrEmpty(dr("NombreDeposito").ToString()), "", dr("NombreDeposito").ToString())
               .IdUbicacion = If(String.IsNullOrEmpty(dr("IdUbicacion").ToString()), 0, Integer.Parse(dr("IdUbicacion").ToString()))
               .NombreUbicacion = If(String.IsNullOrEmpty(dr("NombreUbicacion").ToString()), "", dr("NombreUbicacion").ToString())
               '-----------------------------------------------------------------------------------

            End With
            result.Add(oVP)
         Next
      End Using

      Return result
   End Function

#End Region

   Private Function ObtenerProductosConNroSerie(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Integer,
                                                numeroComprobante As Long,
                                                orden As Integer,
                                                idProducto As String) As List(Of Entidades.ProductoNroSerie)
      Dim productosNrosSerie As List(Of Entidades.ProductoNroSerie) = New List(Of Entidades.ProductoNroSerie)
      Dim rVentasProductosNrosSerie As Reglas.VentasProductosNrosSerie = New Reglas.VentasProductosNrosSerie(da)
      Dim ePNS As Entidades.ProductoNroSerie
      For Each eVPNS In rVentasProductosNrosSerie.GetTodosPorComprobante(idSucursal,
                                                                         idTipoComprobante,
                                                                         letra,
                                                                         centroEmisor,
                                                                         numeroComprobante,
                                                                         orden,
                                                                         idProducto)
         ePNS = New Entidades.ProductoNroSerie
         ePNS.IdSucursal = eVPNS.IdSucursal
         ePNS.TipoComprobante.IdTipoComprobante = eVPNS.IdTipoComprobante
         ePNS.Letra = eVPNS.Letra
         ePNS.CentroEmisor = Short.Parse(eVPNS.CentroEmisor.ToString())
         ePNS.NumeroComprobante = eVPNS.NumeroComprobante
         ePNS.NroSerie = eVPNS.NroSerie
         ePNS.Producto.IdProducto = eVPNS.IdProducto
         ePNS.OrdenVenta = eVPNS.Orden
         ePNS.Sucursal = _cache.BuscaSucursal(eVPNS.IdSucursal)
         productosNrosSerie.Add(ePNS)
      Next

      Return productosNrosSerie

   End Function


End Class