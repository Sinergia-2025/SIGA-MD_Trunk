Imports Eniac.Reglas.ServiciosRest.Sincronizacion

Public Class ProductosSucursales
   Inherits BaseSync(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte, Entidades.JSonEntidades.Archivos.ProductoSucursalJSon)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte, Entidades.JSonEntidades.Archivos.ProductoSucursalJSon)

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ProductosSucursales"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   <Obsolete("Utilizar Insertar(Entidades.Entidad, String)", True)>
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      Throw New NotImplementedException("Utilizar Insertar(Entidades.Entidad, String)")
   End Sub
   Public Overloads Sub Insertar(entidad As Entidades.Entidad, idFuncion As String)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProductoSucursal), TipoSP._I, idFuncion))
   End Sub

   <Obsolete("Utilizar Actualizar(Entidades.Entidad, String)", True)>
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      Throw New NotImplementedException("Utilizar Actualizar(Entidades.Entidad, String)")
   End Sub
   Public Overloads Sub Actualizar(entidad As Entidades.Entidad, idFuncion As String)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.ProductoSucursal), idFuncion))
   End Sub

   Public Sub Actualiza(prodSuc As Entidades.ProductoSucursal, idFuncion As String)
      EjecutaSP(prodSuc, TipoSP._U, idFuncion)
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProductoSucursal), TipoSP._D, idFuncion:=String.Empty))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim stbQuery = New StringBuilder()
      Select Case entidad.Columna
         Case "NombreProducto"
            entidad.Columna = "P." + entidad.Columna
         Case "NombreMarca"
            entidad.Columna = "M." + entidad.Columna
         Case "NombreModelo"
            entidad.Columna = "MO." + entidad.Columna
         Case "NombreRubro"
            entidad.Columna = "R." + entidad.Columna
         Case "NombreSubRubro"
            entidad.Columna = "SB." + entidad.Columna
         Case "NombreSucursal"
            entidad.Columna = "S.Nombre"
         Case "PrecioVentaLista"
            entidad.Columna = "PSP.PrecioVenta"
         Case Else
            entidad.Columna = "PS." + entidad.Columna
      End Select

      With stbQuery
         Dim lista = Publicos.ListaPreciosPredeterminada
         SelectFiltrado(stbQuery, lista)
         .AppendLine("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
         .AppendLine("  ORDER BY P.NombreProducto, S.Nombre")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ProductosSucursales(da).ProductosSucursales_GA(Publicos.ListaPreciosPredeterminada, False, Nothing)
   End Function

#End Region

#Region "Metodos Privados"

   Friend Sub EjecutaSP(ent As Entidades.ProductoSucursal, tipo As TipoSP, idFuncion As String)

      Dim sql = New SqlServer.ProductosSucursales(da)

      Select Case tipo
         Case TipoSP._I
            sql.ProductosSucursales_I(ent.Producto.IdProducto,
                                      ent.Sucursal.Id,
                                      ent.PrecioFabrica,
                                      ent.PrecioCosto,
                                      ent.Stock,
                                      ent.Stock2,
                                      ent.PuntoDePedido,
                                      ent.StockMinimo,
                                      ent.StockMaximo,
                                      ent.Usuario,
                                      ent.Ubicacion,
                                      ent.IdDepositoDefecto,
                                      ent.IdUbicacionDefecto)
            ''-- Carga Productos Deposito.- 
            'Dim rProDep = New Reglas.ProductosDepositos(da)
            'Dim eProDep = New Entidades.ProductoDeposito()

            'Dim dt As DataTable = New Reglas.SucursalesDepositos().GetDeposito(ent.Sucursal.Id)
            'For Each dr As DataRow In dt.Rows
            '   With eProDep
            '      .IdProducto = ent.Producto.IdProducto
            '      .IdSucursal = ent.Sucursal.Id
            '      .IdDeposito = Integer.Parse(dr("IdDeposito").ToString())
            '      .Stock = ent.Stock
            '      .Stock2 = ent.Stock2
            '   End With
            '   rProDep.Insertar(eProDep)
            'Next
         Case TipoSP._U
            Dim PSActual = _GetUno(ent.IdSucursal, ent.Producto.IdProducto)
            'Solo llamo al metodo estandar si cambio preico, porque graba la fecha de actualizacion.
            If PSActual.PrecioFabrica <> ent.PrecioFabrica Or PSActual.PrecioCosto <> ent.PrecioCosto Then

               sql.ProductosSucursales_U(ent.Producto.IdProducto, ent.IdSucursal, ent.PrecioFabrica, ent.PrecioCosto,
                                         ent.Stock, ent.PuntoDePedido, ent.StockMinimo, ent.StockMaximo, ent.Usuario, ent.Ubicacion,
                                         ent.IdDepositoDefecto,
                                         ent.IdUbicacionDefecto)

               'Guardo el historial de precios
               Dim oHisto As HistorialPrecios = New HistorialPrecios(da)
               oHisto.Inserta(ent, idFuncion)

            Else

               sql.ProductosSucursales_UEstadistica(ent.Sucursal.Id, ent.Producto.IdProducto, ent.PuntoDePedido, ent.StockMinimo, ent.StockMaximo, New Entidades.CRMNovedad.CambioMasivo.NullableString(ent.Ubicacion))

            End If
            sql.ProductosSucursales_DU(ent.Producto.IdProducto, ent.IdSucursal, ent.IdDepositoDefecto, ent.IdUbicacionDefecto)
         Case TipoSP._D
            '-- REQ-34747.- -- Talle Color ------------------------------------
            Dim eProSucArt = New Entidades.ProductoSucursalAtributo
            With eProSucArt
               .IdSucursal = ent.Sucursal.Id
               .IdProducto = ent.Producto.IdProducto
            End With
            Dim rProSucAtr = New ProductosSucursalesAtributos(da)
            rProSucAtr.Elimina(eProSucArt)
            '-- Elimina Productos Deposito.- 
            Dim rProDep = New Reglas.ProductosDepositos(da)
            Dim eProDep = New Entidades.ProductoDeposito()
            With eProDep
               .IdProducto = ent.Producto.IdProducto
               .IdSucursal = ent.Sucursal.Id
               '.IdDeposito = ent.IdDeposito
               '.IdUbicacion = ent.IdUbicacion
            End With
            rProDep.Borrar(eProDep)
            '------------------------------------------------------------------

            sql.ProductosSucursales_D(ent.Producto.IdProducto, ent.Sucursal.Id)
      End Select


   End Sub

   Private Sub SelectFiltrado(ByRef stb As StringBuilder, idListaPrecios As Integer)
      With stb
         .AppendLine("SELECT PS.IdProducto")
         .AppendLine("	    ,P.NombreProducto")
         .AppendLine("      ,P.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         '.AppendLine("      ,P.IdModelo")
         '.AppendLine("      ,MO.NombreModelo")
         .AppendLine("      ,P.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         '.AppendLine("      ,P.IdSubRubro")
         '.AppendLine("      ,SB.NombreSubRubro")
         .AppendLine("      ,PS.IdSucursal")
         .AppendLine("	    ,S.Nombre NombreSucursal")
         .AppendLine("      ,PS.PrecioFabrica")
         .AppendLine("      ,PS.PrecioCosto")
         .AppendLine("      ,PSP.PrecioVenta AS PrecioVentaLista")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,PS.StockInicial")
         .AppendLine("      ,PS.PuntoDePedido")
         .AppendLine("      ,PS.StockMinimo")
         .AppendLine("      ,PS.StockMaximo")
         .AppendLine("      ,PS.Usuario")
         .AppendLine("      ,PS.FechaActualizacion")
         .AppendLine("      ,PS.Ubicacion")
         .AppendLine("      ,PS.IdDepositoDefecto")
         .AppendLine("      ,PS.IdUbicacionDefecto")

         .AppendLine("  FROM ProductosSucursales PS")
         .AppendLine(" INNER JOIN ProductosSucursalesPrecios PSP ON PSP.IdSucursal = PS.IdSucursal AND PSP.IdProducto = PS.IdProducto AND PSP.IdListaPrecios = " + idListaPrecios.ToString())
         .AppendLine("	LEFT JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendLine("  LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine("  LEFT JOIN Rubros R ON P.IdRubro = R.IdRubro ")
         '.AppendLine(" LEFT OUTER JOIN Modelos MO ON P.IdModelo = MO.IdModelo")
         '.AppendLine(" LEFT OUTER JOIN SubRubros SB ON P.IdSubRubro = SB.IdSubRubro")
      End With
   End Sub

   Private _sqlProdSuc As SqlServer.ProductosSucursales
   Private _sqlProdSucPre As SqlServer.ProductosSucursalesPrecios
   Private _regHistoPre As Reglas.HistorialPrecios
   Private _sqlProdProv As SqlServer.ProductosProveedores
   Private _dtPrecios As DataTable

   Public Sub ActualizaPrecios(productoSuc As Entidades.ProductoSucursal, idFuncion As String)
      _sqlProdSuc = New SqlServer.ProductosSucursales(da)
      _sqlProdSucPre = New SqlServer.ProductosSucursalesPrecios(da)
      _sqlProdProv = New SqlServer.ProductosProveedores(da)
      _regHistoPre = New Reglas.HistorialPrecios(da)
      _ActualizaPrecios(productoSuc, idFuncion)
   End Sub

   Friend Sub _ActualizaPrecios(productoSuc As Entidades.ProductoSucursal, idFuncion As String)

      Try

         'cambiamos el objeto por un DT porque estamos en un bucle y la pantalla se esta tornando lenta
         Me._dtPrecios = Me.GetPrecios(productoSuc.Sucursal.Id, productoSuc.Producto.IdProducto.Trim())

         If Me._dtPrecios.Rows.Count = 0 Then
            'salgo porque esta modificando un producto que no esta en la tabla
            Exit Sub
         End If

         Dim dt As DataTable

         'consulto por la fila 1 ya que la consulta es por la PK 
         If Decimal.Parse(Me._dtPrecios.Rows(0)("PrecioFabrica").ToString()) <> productoSuc.PrecioFabrica _
               Or Decimal.Parse(Me._dtPrecios.Rows(0)("PrecioCosto").ToString()) <> productoSuc.PrecioCosto Or
               productoSuc.FuerzaActualizacionPrecio Then

            Me._sqlProdSuc.ProductosSucursales_UPrecios(productoSuc.Producto.IdProducto.Trim(),
                                             productoSuc.Sucursal.Id,
                                             productoSuc.PrecioFabrica,
                                             productoSuc.PrecioCosto,
                                             productoSuc.Usuario)
         End If

         'Solo llamo al metodo estandar si cambio precio, porque graba la fecha de actualizacion.
         If Decimal.Parse(Me._dtPrecios.Rows(0)("PrecioFabrica").ToString()) <> productoSuc.PrecioFabrica _
               Or Decimal.Parse(Me._dtPrecios.Rows(0)("PrecioCosto").ToString()) <> productoSuc.PrecioCosto Then
            Me._regHistoPre.Inserta(productoSuc, idFuncion)
         End If

         'actualizo el precio de todas las listas de precios

         For Each pre As Entidades.ProductoSucursalPrecio In productoSuc.Precios
            If pre.ProductoSucursal.Producto.ActualizaPreciosSucursalesAsociadas Or pre.IdSucursal = actual.Sucursal.Id Then
               dt = Me._sqlProdSucPre.ProductosSucursalesPrecios_G1(pre.ProductoSucursal.Producto.IdProducto,
                                                       pre.IdSucursal,
                                                       pre.ListaDePrecios.IdListaPrecios,
                                                       Publicos.PreciosConIVA)

               'productoSuc.PrecioVenta = pre.PrecioVenta

               If dt.Rows.Count = 0 Then

                  Me._sqlProdSucPre.ProductosSucursalesPrecios_I(pre.ProductoSucursal.Producto.IdProducto,
                                                    pre.IdSucursal,
                                                    pre.ListaDePrecios.IdListaPrecios,
                                                    pre.PrecioVenta,
                                                    Date.Now, pre.Usuario)

                  'La Lista cero se Controlo arriba
                  If pre.ListaDePrecios.IdListaPrecios > 0 Then
                     Me._regHistoPre.Inserta(pre, idFuncion)
                  End If

               Else
                  If pre.PrecioVenta <> Decimal.Parse(dt.Rows(0)("PrecioVenta").ToString()) Or
                  productoSuc.FuerzaActualizacionPrecio Then
                     Me._sqlProdSucPre.ProductosSucursalesPrecios_U(pre.ProductoSucursal.Producto.IdProducto,
                                                       pre.IdSucursal,
                                                       pre.ListaDePrecios.IdListaPrecios,
                                                       pre.PrecioVenta,
                                                       Date.Now,
                                                       pre.Usuario)
                  End If

                  'Solo llamo al metodo estandar si cambio precio, porque graba la fecha de actualizacion.
                  If Decimal.Parse(dt.Rows(0)("PrecioVenta").ToString()) <> pre.PrecioVenta Then 'And pre.ListaDePrecios.IdListaPrecios > 0 Then
                     Me._regHistoPre.Inserta(pre, idFuncion)
                  End If

               End If
            End If
            If pre.ProductoSucursal.Producto.ProductoProveedorHabitual IsNot Nothing Then
               Dim sqlPP As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(da)
               sqlPP.ProductosProveedores_D(pre.ProductoSucursal.Producto.ProductoProveedorHabitual.IdProveedor,
                                            pre.ProductoSucursal.Producto.ProductoProveedorHabitual.IdProducto)
               sqlPP.ProductosProveedores_I(pre.ProductoSucursal.Producto.ProductoProveedorHabitual.IdProveedor,
                                            pre.ProductoSucursal.Producto.ProductoProveedorHabitual.IdProducto,
                                             pre.ProductoSucursal.Producto.ProductoProveedorHabitual.CodigoProductoProveedor,
                                             pre.ProductoSucursal.Producto.ProductoProveedorHabitual.UltimoPrecioCompra,
                                             pre.ProductoSucursal.Producto.ProductoProveedorHabitual.UltimaFechaCompra,
                                             pre.ProductoSucursal.Producto.ProductoProveedorHabitual.UltimoPrecioFabrica,
                                             pre.ProductoSucursal.Producto.ProductoProveedorHabitual.DescuentoRecargoPorc1,
                                             pre.ProductoSucursal.Producto.ProductoProveedorHabitual.DescuentoRecargoPorc2,
                                             pre.ProductoSucursal.Producto.ProductoProveedorHabitual.DescuentoRecargoPorc3,
                                             pre.ProductoSucursal.Producto.ProductoProveedorHabitual.DescuentoRecargoPorc4,
                                             pre.ProductoSucursal.Producto.ProductoProveedorHabitual.DescuentoRecargoPorc5,
                                             pre.ProductoSucursal.Producto.ProductoProveedorHabitual.DescuentoRecargoPorc6)
            End If

         Next

      Catch ex As Exception
         Throw

      End Try

   End Sub

   Friend Sub ActualizaPrecioCosto(productoSuc As Entidades.ProductoSucursal, idFuncion As String)

      Try

         Dim PSActual As Entidades.ProductoSucursal = Me._GetUno(productoSuc.Sucursal.Id, productoSuc.Producto.IdProducto.Trim())
         Dim oHisto As HistorialPrecios = New HistorialPrecios(da)
         Dim sql As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)

         sql.ProductosSucursales_UPrecioCosto(productoSuc.Producto.IdProducto.Trim(), productoSuc.Sucursal.Id,
                  productoSuc.PrecioCosto, productoSuc.Usuario)

         'Solo llamo al metodo estandar si cambio precio, porque graba la fecha de actualizacion.
         If PSActual.PrecioCosto <> productoSuc.PrecioCosto Then
            oHisto.Inserta(productoSuc, idFuncion)
         End If

      Catch ex As Exception
         Throw ex

      End Try

   End Sub

   Friend Sub ActualizaPrecioVenta(productoSuc As Entidades.ProductoSucursal)

      Try

         Dim PSActual As Entidades.ProductoSucursal = Me._GetUno(productoSuc.Sucursal.Id, productoSuc.Producto.IdProducto.Trim())
         Dim sql As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)
         Dim sqlP As SqlServer.ProductosSucursalesPrecios = New SqlServer.ProductosSucursalesPrecios(da)
         Dim listPre As Integer

         listPre = Publicos.ListaPreciosPredeterminada

         'sql.ProductosSucursales_UPrecioVenta(productoSuc.Producto.IdProducto.Trim(),
         '                                     productoSuc.Sucursal.Id,
         '                                     productoSuc.GetPrecioVentaDeLista(productoSuc.,
         '                                     productoSuc.Usuario)

         sqlP.ProductosSucursalesPrecios_U(productoSuc.Producto.IdProducto,
                                            productoSuc.Sucursal.Id,
                                            listPre,
                                            productoSuc.GetPrecioVentaDeLista(listPre),
                                            Date.Now,
                                            productoSuc.Usuario)

      Catch ex As Exception
         Throw

      End Try

   End Sub

   Private Sub CargarUno(o As Entidades.ProductoSucursal, dr As DataRow)
      With o
         .Producto = New Productos(da).GetUno(dr("IdProducto").ToString())
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
         .Sucursal = New Sucursales(da).GetUna(.IdSucursal, False)
         .PrecioCosto = Decimal.Parse(dr("PrecioCosto").ToString())
         .PrecioVentaLista = Decimal.Parse(dr("PrecioVentaLista").ToString())
         .PrecioFabrica = Decimal.Parse(dr("PrecioFabrica").ToString())
         .Stock = Decimal.Parse(dr("Stock").ToString())
         .StockInicial = Decimal.Parse(dr("StockInicial").ToString())
         .PuntoDePedido = Decimal.Parse(dr("PuntoDePedido").ToString())
         .StockMinimo = Decimal.Parse(dr("StockMinimo").ToString())
         .StockMaximo = Decimal.Parse(dr("StockMaximo").ToString())
         .Usuario = dr("Usuario").ToString()
         .FechaActualizacion = Date.Parse(dr("FechaActualizacion").ToString())
         .Ubicacion = dr("Ubicacion").ToString()
         '.StockDefectuoso = Decimal.Parse(dr("StockDefectuoso").ToString())
         'If Not String.IsNullOrEmpty(dr("StockReservado").ToString()) Then
         '   .StockReservado = Decimal.Parse(dr("StockReservado").ToString())
         'End If
         '.StockFuturo = Decimal.Parse(dr("StockFuturo").ToString())
         '.StockFuturoReservado = Decimal.Parse(dr("StockFuturoReservado").ToString())

         .IdDepositoDefecto = dr.Field(Of Integer?)("IdDepositoDefecto").IfNull()
         .IdUbicacionDefecto = dr.Field(Of Integer?)("IdUbicacionDefecto").IfNull()

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub ModificarPrecios(precios As List(Of Entidades.ProductoSucursal), idFuncion As String)
      EjecutaConTransaccion(Sub() _ModificarPrecios(precios, idFuncion))
   End Sub

   Public Event AvanceModificarPrecios(sender As Object, e As AvanceModificarPreciosEventArgs)
   Public Class AvanceModificarPreciosEventArgs
      Inherits EventArgs
      Public Property Indice As Integer
      Public Property Total As Integer
      Public Property IdProducto As String
      Public Property NombreProducto As String
   End Class

   Public Sub _ModificarPrecios(precios As List(Of Entidades.ProductoSucursal), idFuncion As String)

      Dim blnPreciosUnificados = Publicos.PreciosUnificar

      'Dim lisSucursales As List(Of Integer) = New Reglas.Sucursales(da)._GetSoloIdsDeTodas()

      Dim lisSucursales As List(Of Entidades.Sucursal) = New Reglas.Sucursales(da).GetTodas(False)

      Dim NuevoPrecio As Entidades.ProductoSucursal
      Me._sqlProdSuc = New SqlServer.ProductosSucursales(da)
      Me._sqlProdSucPre = New SqlServer.ProductosSucursalesPrecios(da)
      Me._sqlProdProv = New SqlServer.ProductosProveedores(da)
      Me._regHistoPre = New Reglas.HistorialPrecios(da)

      Dim i As Integer = 0
      For Each precio As Entidades.ProductoSucursal In precios
         i += 1
         RaiseEvent AvanceModificarPrecios(Me, New AvanceModificarPreciosEventArgs() With {.Indice = i, .Total = precios.Count, .IdProducto = precio.Producto.IdProducto, .NombreProducto = precio.Producto.NombreProducto})
         If Not blnPreciosUnificados Then
            Me._ActualizaPrecios(precio, idFuncion)
         Else
            For Each suc As Entidades.Sucursal In lisSucursales

               precio.IdSucursal = suc.IdSucursal
               precio.Sucursal = suc
               'precio.Sucursal.IdSucursal = suc

               'Hacer una asignacion por favor s ehizo porque cuando hay mas d euna lista de precios se pisa el valor (adentro se hacen calculos).
               NuevoPrecio = precio.GetCopia()

               Me._ActualizaPrecios(NuevoPrecio, idFuncion)

            Next
         End If

      Next

   End Sub

   Public Sub ModificarPreciosCostoVenta(precios As List(Of Entidades.ProductoSucursal), idFuncion As String)

      Try

         Dim blnPreciosUnificados = Publicos.PreciosUnificar

         Dim lisSucursales As List(Of Integer) = New Reglas.Sucursales().GetSoloIdsDeTodas()

         Dim NuevoPrecio As Entidades.ProductoSucursal

         da.OpenConection()
         da.BeginTransaction()

         Me._sqlProdSuc = New SqlServer.ProductosSucursales(da)
         Me._sqlProdSucPre = New SqlServer.ProductosSucursalesPrecios(da)
         Me._sqlProdProv = New SqlServer.ProductosProveedores(da)
         Me._regHistoPre = New Reglas.HistorialPrecios(da)

         For Each precio As Entidades.ProductoSucursal In precios
            If Not blnPreciosUnificados Then
               Me._ActualizaPrecios(precio, idFuncion)
            Else
               For Each suc As Integer In lisSucursales
                  precio.IdSucursal = suc
                  precio.Sucursal.Id = suc
                  precio.Sucursal.IdSucursal = suc

                  'Hacer una asignacion por favor s ehizo porque cuando hay mas d euna lista de precios se pisa el valor (adentro se hacen calculos).
                  NuevoPrecio = precio.GetCopia()

                  Me._ActualizaPrecios(NuevoPrecio, idFuncion)
               Next
            End If
         Next

         da.CommitTransaction()

      Catch ex As Exception
         If da IsNot Nothing Then
            da.RollbakTransaction()
         End If
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub ModificarPrecioCosto(precios As List(Of Entidades.ProductoSucursal), idFuncion As String)

      Try

         Dim blnPreciosUnificados = Publicos.PreciosUnificar

         Dim lisSucursales As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(False)

         Dim NuevoPrecio As Entidades.ProductoSucursal

         da.OpenConection()
         da.BeginTransaction()

         For Each precio As Entidades.ProductoSucursal In precios
            If Not blnPreciosUnificados Then
               Me.ActualizaPrecioCosto(precio, idFuncion)
            Else
               For Each suc As Entidades.Sucursal In lisSucursales
                  precio.IdSucursal = suc.IdSucursal
                  precio.Sucursal.Id = suc.IdSucursal
                  precio.Sucursal.IdSucursal = suc.IdSucursal

                  'Hacer una asignacion por favor s ehizo porque cuando hay mas d euna lista de precios se pisa el valor (adentro se hacen calculos).
                  NuevoPrecio = precio.GetCopia()

                  Me.ActualizaPrecioCosto(NuevoPrecio, idFuncion)
               Next
            End If
         Next

         da.CommitTransaction()

      Catch ex As Exception
         If da IsNot Nothing Then
            da.RollbakTransaction()
         End If
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub ModificarPrecioVenta(precios As List(Of Entidades.ProductoSucursal))

      Try

         Dim blnPreciosUnificados = Publicos.PreciosUnificar

         Dim lisSucursales As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(False)

         Dim NuevoPrecio As Entidades.ProductoSucursal


         da.OpenConection()
         da.BeginTransaction()

         For Each precio As Entidades.ProductoSucursal In precios
            If Not blnPreciosUnificados Then
               Me.ActualizaPrecioVenta(precio)
            Else
               For Each suc As Entidades.Sucursal In lisSucursales
                  precio.IdSucursal = suc.IdSucursal
                  precio.Sucursal.Id = suc.IdSucursal
                  precio.Sucursal.IdSucursal = suc.IdSucursal

                  'Hacer una asignacion por favor s ehizo porque cuando hay mas d euna lista de precios se pisa el valor (adentro se hacen calculos).
                  NuevoPrecio = precio.GetCopia()


                  Me.ActualizaPrecioVenta(NuevoPrecio)

               Next
            End If
         Next

         da.CommitTransaction()

      Catch ex As Exception
         If da IsNot Nothing Then
            da.RollbakTransaction()
         End If
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function GetListadoDeStock(sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito(), idProducto As String,
                                     marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                     rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subSubrubros As Entidades.SubSubRubro(),
                                     filtroStock As Entidades.EnumSql.Stock_TipoReporte, ordenPor As Entidades.EnumSql.InformeStock_OrdenadoPor,
                                     idProveedor As Long, habitual As Boolean,
                                     listaPorDefecto As Integer,
                                     stockUnificadoPor As Entidades.EnumSql.InformeStock_UnificadoPor, tipoDeposito As Entidades.SucursalDeposito.TiposDepositos?,
                                     sucursalesSeleccionoTodos As Boolean) As DataTable

      Dim sucursalesVinculadas = Entidades.EnumSql.InformeStock_SucursalVinculada.NoAplica
      'Si seleccionó TODOS en el combo de la pantalla, debe separar las principales de las secundarias
      'Si no es todos es el usuario quien decide que sucursal/es.
      '     Si elige una él quiere ver el stock de dicha sucursal, no importa si es principal o secundaria
      '     Si elige más de una, él eligio ver dichas sucursales, no importa si es principal o secundaria
      If sucursalesSeleccionoTodos Then
         If actual.Sucursal.IdSucursalAsociada = 0 Then                                               'Escenario 3.c del PE-42047
            sucursalesVinculadas = Entidades.EnumSql.InformeStock_SucursalVinculada.Principales
         ElseIf actual.Sucursal.IdSucursal < actual.Sucursal.IdSucursalAsociada Then                  'Escenario 3.a del PE-42047
            sucursalesVinculadas = Entidades.EnumSql.InformeStock_SucursalVinculada.Principales
         Else                                                                                         'Escenario 3.b del PE-42047
            sucursalesVinculadas = Entidades.EnumSql.InformeStock_SucursalVinculada.Secundarias
         End If
      End If

      Return New SqlServer.ProductosSucursales(da).
                     GetListadoDeStock(sucursales, depositos, idProducto,
                                       marcas, modelos, rubros, subrubros, subSubrubros,
                                       filtroStock, ordenPor,
                                       idProveedor, habitual,
                                       listaPorDefecto, Publicos.PreciosConIVA, Publicos.ListaPreciosPredeterminada,
                                       stockUnificadoPor, tipoDeposito, sucursalesVinculadas)

   End Function

   Public Function GetStockValorizado(suc As List(Of Integer), cotizacionDolar As Decimal) As DataTable
      Dim sql As SqlServer.ProductosSucursales
      Dim dt As DataTable
      Try
         Me.da.OpenConection()

         sql = New SqlServer.ProductosSucursales(da)
         dt = sql.StockValorizado(suc, cotizacionDolar, Publicos.PreciosConIVA)

         Return dt
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Overloads Function Get1(idSucursal As Integer, idProducto As String) As DataRow
      Dim stbQuery As StringBuilder = New StringBuilder()
      Dim lista As Integer = Publicos.ListaPreciosPredeterminada
      Me.SelectFiltrado(stbQuery, lista)
      With stbQuery
         .AppendFormatLine("  WHERE PS.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("    AND PS.IdSucursal =  {0} ", idSucursal)
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stbQuery.ToString())
      Return If(dt.Rows.Count = 0, Nothing, dt.Rows(0))
   End Function

   Public Overloads Function GetUno(idSucursal As Integer, idProducto As String) As Entidades.ProductoSucursal
      Try
         Me.da.OpenConection()

         Return Me._GetUno(idSucursal, idProducto)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function _GetUno(idSucursal As Integer, idProducto As String) As Entidades.ProductoSucursal

      Dim stbQuery As StringBuilder = New StringBuilder("")
      Dim lista As Integer = Publicos.ListaPreciosPredeterminada

      Me.SelectFiltrado(stbQuery, lista)

      With stbQuery
         .AppendLine("  WHERE PS.IdProducto ='" & idProducto & "'")
         .AppendLine("    AND PS.IdSucursal = " & idSucursal.ToString())
      End With

      'Cambio la forma para que funcione el Importador de Productos de Berbane
      'Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())
      Dim dt As DataTable = Me.da.GetDataTable(stbQuery.ToString())

      Dim oPro As Entidades.ProductoSucursal = New Entidades.ProductoSucursal()

      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(oPro, dr)
      End If
      Return oPro
   End Function

   Public Function GetUnoCB(idSucursal As Integer, idProducto As String) As Entidades.ProductoSucursal

      Dim stbQuery = New StringBuilder()
      Dim lista = Publicos.ListaPreciosPredeterminada

      SelectFiltrado(stbQuery, lista)

      With stbQuery
         .AppendLine("  WHERE PS.IdSucursal = " & idSucursal.ToString())
         .AppendLine("    AND P.Activo = 'True'")
         If Publicos.ProductoUtilizaCodigoDeBarras Then ' Boolean.Parse(New Reglas.Parametros().GetValor("PRODUCTOUTILIZACODIGODEBARRAS")) Then
            .AppendFormatLine("	AND (P.IdProducto = '{0}' OR P.CodigoDeBarras = '{0}' OR EXISTS(SELECT * FROM ProductosIdentificaciones PI WHERE PI.IdProducto = P.IdProducto AND PI.Identificacion = '{0}'))", idProducto)
            '.AppendLine("	AND (P.IdProducto = '" & idProducto & "' OR P.CodigoDeBarras = '" & idProducto & "')")
         Else
            .AppendFormatLine("	AND P.IdProducto = '{0}'", idProducto)
         End If
      End With

      'Cambio la forma para que funcione el Importador de Productos de Berbane
      'Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())
      Using dt As DataTable = da.GetDataTable(stbQuery.ToString())
         Dim oPro = New Entidades.ProductoSucursal()
         If dt.Rows.Count > 0 Then
            CargarUno(oPro, dt.Rows(0))
         End If
         Return oPro
      End Using
   End Function

   Friend Function GetPrecios(idSucursal As Integer, idProducto As String) As DataTable
      Return Me._sqlProdSuc.GetPrecios(idSucursal, idProducto)
   End Function

   Public Overloads Function GetUno(idSucursal As Integer, idProducto As String,
                                    idListaPrecios As Integer) As Entidades.ProductoSucursal

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT PS.IdProducto")
         .AppendLine("      ,PS.IdSucursal")
         .AppendLine("      ,PS.PrecioFabrica")
         .AppendLine("      ,PS.PrecioCosto")
         .AppendLine("      ,PSP.PrecioVenta AS PrecioVentaLista")
         .AppendLine("      ,PS.Usuario")
         .AppendLine("      ,PS.FechaActualizacion")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,PS.StockInicial")
         .AppendLine("      ,PS.PuntoDePedido")
         .AppendLine("      ,PS.StockMinimo")
         .AppendLine("      ,PS.StockMaximo")
         .AppendLine("      ,PS.Usuario")
         .AppendLine("      ,PS.FechaActualizacion")
         .AppendLine("      ,PS.Ubicacion")
         .AppendLine("      ,PS.IdDepositoDefecto")
         .AppendLine("      ,PS.IdUbicacionDefecto")

         .Append("  FROM ProductosSucursales PS")
         .Append("   LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
         .Append("  WHERE PS.IdProducto ='")
         .Append(idProducto)
         .Append("'  AND PS.IdSucursal =")
         .Append(idSucursal.ToString())
         .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)
      End With

      Dim dt As DataTable = da.GetDataTable(stbQuery.ToString())
      Dim oPro As Entidades.ProductoSucursal = New Entidades.ProductoSucursal()

      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(oPro, dr)
      End If
      Return oPro
   End Function

   Public Function GetPrecioVentaPredeterminado(idSucursal As Integer, idProducto As String) As Decimal
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then Me.da.OpenConection()

         Dim lista As Integer = Reglas.Publicos.ListaPreciosPredeterminada

         Dim sql As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)
         Return sql.GetPrecioVentaPredeterminado(idSucursal, idProducto, lista)
      Finally
         If blnAbreConexion Then Me.da.CloseConection()
      End Try
   End Function

   Public Function GetPrecioCosto(idSucursal As Integer, idProducto As String) As DataTable
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then Me.da.OpenConection()

         Dim sql As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)
         Return sql.GetPrecios(idSucursal, idProducto)
      Finally
         If blnAbreConexion Then Me.da.CloseConection()
      End Try
   End Function

   Public Function ProductosSucursales_DepositoUbicacionDefecto(idSucursal As Integer, idProducto As String) As DataTable
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then Me.da.OpenConection()

         Dim sql As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)
         Return sql.ProductosSucursales_DepositoUbicacionDefecto(idSucursal, idProducto)
      Finally
         If blnAbreConexion Then Me.da.CloseConection()
      End Try
   End Function

   Public Function GetProductosSinStock(idSucursal As Integer) As DataTable

      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)
         Return sql.GetProductosSinStock(idSucursal)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetPuntoDePedidoDeProductos(sucursales As Entidades.Sucursal(),
                                               depositos As Entidades.SucursalDeposito(),
                                               ubicacion As Entidades.SucursalUbicacion,
                                               tipoPedido As String,
                                               idProducto As String,
                                               idMarca As Integer, idRubro As Integer, idSubRubro As Integer) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProductosSucursales(da).
                  GetPuntoDePedidoDeProductos(sucursales, depositos, ubicacion, tipoPedido, idProducto, idMarca, idRubro, idSubRubro))
   End Function

   Public Function GetStockMinimoDeProductos(sucursales As Entidades.Sucursal(),
                                             depositos As Entidades.SucursalDeposito(),
                                             ubicacion As Entidades.SucursalUbicacion,
                                             tipoPedido As String,
                                             idProducto As String,
                                             idMarca As Integer,
                                             idRubro As Integer,
                                             idSUbrubro As Integer,
                                             sucursalesTodas As Entidades.Sucursal(),
                                             idProveedor As Long, habitual As Boolean) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProductosSucursales(da).
                        GetStockMinimoDeProductos(sucursales, depositos, ubicacion, tipoPedido, idProducto,
                                                  idMarca, idRubro, idSUbrubro, sucursalesTodas, idProveedor, habitual))
   End Function

   Public Function GetProductosGenerarPedidos(sucursales As Entidades.Sucursal(),
                                              depositos As Entidades.SucursalDeposito(),
                                              ubicacion As Entidades.SucursalUbicacion,
                                              tipoPedido As Entidades.ProductoSucursal.SituacionDeStock,
                                              idProducto As String,
                                              idMarca As Integer, idRubro As Integer, idSUbrubro As Integer,
                                              idProveedor As Long, proveedorHabitual As Boolean,
                                              calculaCantidadesVendida As Boolean, fechaDesdeCantidadesVendida As Date?, fechaHastaCantidadesVendida As Date?) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.ProductosSucursales(da)
            Dim lSucursales As New List(Of Entidades.Sucursal)
            Dim sucEmpresa = New Reglas.Sucursales(da).GetTodas("", sucursales(0).IdEmpresa, False)
            Dim sucAsociad = New Reglas.Sucursales(da).GetUna(sucursales(0).IdSucursalAsociada, False)
            For Each eSuc In sucEmpresa
               lSucursales.Add(eSuc)
            Next
            If sucAsociad IsNot Nothing Then
               lSucursales.Add(sucAsociad)

            End If
            sucursales = lSucursales.ToArray()

            Return sql.GetProductosGenerarPedidos(sucursales, depositos, ubicacion, tipoPedido, idProducto, idMarca, idRubro, idSUbrubro, idProveedor, proveedorHabitual,
                                                  calculaCantidadesVendida, fechaDesdeCantidadesVendida, fechaHastaCantidadesVendida)
         End Function)
   End Function

   Public Function GetInconsistenciaStockVsStockLotes(idSucursal As Integer) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProductosSucursales(da).GetInconsistenciaStockVsStockLotes(idSucursal))
   End Function

   Public Function GetInconsistenciaStockVsMovimientosDeStock(idSucursal As Integer) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProductosSucursales(da).GetInconsistenciaStockVsMovimientosDeStock(idSucursal))
   End Function

   Public Function GetProductoConStock(idProducto As String, idSucursal As Integer) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProductosSucursales(da).
                                                   GetProductoConStock(idProducto, idSucursal, Publicos.ListaPreciosPredeterminada))
   End Function
   Public Function GetUbicacionesCalidad() As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProductosSucursales(da).GetUbicacionesCalidad())
   End Function

   Public Sub ActualizarPrecioCostoVenta(idProducto As String, idSucursal As Integer, precioCosto As Decimal, precioVenta As Decimal)
      Try

         Me.da.OpenConection()

         Dim sql As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)

         sql.ProductosSucursales_UPreciosCostoVenta(idProducto, idSucursal, precioCosto, precioVenta, Publicos.ListaPreciosPredeterminada)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Sub

   Public Sub ActualizarUbicacion(idProducto As String, idSucursal As Integer, ubicacion As String)
      Dim sql As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)
      sql.ProductosSucursales_Ubicacion(idProducto, idSucursal, ubicacion)
   End Sub

   Public Class GetStockPorModeloPivotInfo
      Public Property dtColumnas As DataTable
      Public Property dtResult As DataTable
   End Class
   Public Function GetStockPorModelo(sucursales As Entidades.Sucursal(),
                                     idProducto As String,
                                     idMarca As Integer,
                                     idRubro As Integer,
                                     idSubRubro As Integer) As GetStockPorModeloPivotInfo

      Dim sql As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)

      Dim pivotcolName As StringBuilder = New StringBuilder()
      Dim sumPivot As StringBuilder = New StringBuilder()

      Dim dtColumnas As DataTable = sql.GetStockPorModelo_ColumnasPivot(sucursales, idProducto, idMarca, idRubro, idSubRubro)

      If dtColumnas.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Modelos para estos filtros.")
      End If

      Dim primero As Boolean = True
      For Each drColumna As DataRow In dtColumnas.Rows
         If Not primero Then
            pivotcolName.Append(",")
            sumPivot.Append(",")
         End If
         pivotcolName.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot.AppendFormat("SUM([{0}]) as [{0}]", drColumna("NombreColumma"))
         primero = False
      Next

      Return New GetStockPorModeloPivotInfo() _
                 With {.dtColumnas = dtColumnas,
                       .dtResult = New SqlServer.ProductosSucursales(da).GetStockPorModelo(sucursales,
                                                                     idProducto,
                                                                     idMarca,
                                                                     idRubro,
                                                                     idSubRubro,
                                                                     pivotcolName.ToString(),
                                                                     sumPivot.ToString())}
   End Function

   Public Class ValidacionAjusteMasivoStockException
      Inherits Exception
      Public Sub New(mensaje As String)
         MyBase.New(mensaje)
      End Sub
   End Class

   Public Class AvanceAjusteMasivoStockEventArgs
      Inherits EventArgs
      Public Property Mensaje As String
      Public Sub New(mensaje As String)
         _Mensaje = mensaje
      End Sub
   End Class
   Public Event AvanceAjusteMasivoStock(sender As Object, e As AvanceAjusteMasivoStockEventArgs)

   Public Sub AjusteMasivoStock(dt As DataTable, ajustaUbicacion As Boolean, ajustaStockMinimoMaximo As Boolean, reprocesa As Boolean, idFuncion As String, atributo As Boolean)
      Try
         da.OpenConection()

         'Dim maxUbicacion As Integer = New Publicos().GetAnchoCampo("ProductosSucursales", "Ubicacion")

         If Not reprocesa Then
            Dim productosConStockCero = 0I
            Dim stbProductosConStockCero = New StringBuilder()

            RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("COMENZANDO VALIDACIONES")))
            For Each dr As DataRow In dt.Select(String.Format("{0} <> {1} OR {2} <> {3}", "Stock", "NuevoStock", "IdUbicacion", "NuevoIdUbicacion"))
               RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("VALIDANDO {0} - {1}", dr("IdProducto"), dr("NombreProducto"))))
               If dr.Field(Of Decimal)("Stock") > 0 And dr.Field(Of Decimal)("NuevoStock") = 0 Then
                  productosConStockCero = 0
                  stbProductosConStockCero.AppendFormatLine("{0} - {1}", dr("IdProducto"), dr("NombreProducto"))
               End If

               If dr.Field(Of Decimal)("Stock") <> dr.Field(Of Decimal)("NuevoStock") Then
                  If dr.Field(Of Decimal)("NuevoStock") < 0 Then
                     Throw New Exception(String.Format("El producto {0} - {1} tiene nuevo Stock en negativo, NO puede continuar", dr("IdProducto"), dr("NombreProducto")))
                  End If
               End If

               '-- REQ-30900 --
               'If dr.Field(Of String)("NuevaUbicacion") IsNot Nothing AndAlso dr.Field(Of String)("NuevaUbicacion").Length > maxUbicacion Then
               '   Throw New Exception(String.Format("El producto {0} - {1} tiene una ubicación muy larga (max.: {2})", dr("IdProducto"), dr("NombreProducto"), maxUbicacion))
               'End If

            Next

            If productosConStockCero > 0 Then
               Dim mensajeError As String
               If productosConStockCero = 1 Then
                  mensajeError = String.Format("El Producto {0} tiene Stock Nuevo en 0 (cero) pero el Stock Actual NO. ¿Desea continuar en este caso?", stbProductosConStockCero.ToString())
               ElseIf productosConStockCero < 5 Then
                  mensajeError = String.Format("Los Productos {0} tienen Stock Nuevo en 0 (cero) pero el Stock Actual NO. ¿Desea continuar con estos casos?", stbProductosConStockCero.ToString())
               Else
                  mensajeError = String.Format("Existen {0} Productos que tienen Stock Nuevo en 0 (cero) pero el Stock Actual NO. ¿Desea continuar con estos casos?", stbProductosConStockCero.ToString())
               End If
               Throw New ValidacionAjusteMasivoStockException(mensajeError)
            End If
         End If

         Dim cache = New BusquedasCacheadas()

         ''''For Each dr As DataRow In dt.Select(String.Format("{0} <> {1} OR {2} <> {3} OR {4} <> {5} OR {6} <> {7} OR {8} <> {9}",
         ''''                                                  "Stock", "NuevoStock", "Ubicacion", "NuevaUbicacion",
         ''''                                                  "StockMinimo", "NuevoStockMinimo", "PuntoDePedido", "NuevoPuntoDePedido", "StockMaximo", "NuevoStockMaximo"))
         For Each dr As DataRow In dt.Select().Where(Function(drWhere)
                                                        Return drWhere.Field(Of Decimal)("Stock") <> drWhere.Field(Of Decimal)("NuevoStock") OrElse
                                                               drWhere.Field(Of Integer)("IdUbicacion") <> drWhere.Field(Of Integer)("NuevoIdUbicacion")
                                                     End Function)
            Try
               da.BeginTransaction()

               RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("Producto {0} - {1} - PROCESANDO", dr("IdProducto"), dr("NombreProducto"))))

               Dim prodsuc As Entidades.ProductoSucursal = New Entidades.ProductoSucursal()
               'Cargo los valores de la grilla al objeto productosSucursales
               With prodsuc
                  .Producto.IdProducto = dr.Field(Of String)("IdProducto").Trim()
                  .Sucursal = cache.BuscaSucursal(dr.Field(Of Integer)("IdSucursal"))
                  '.Sucursal.Id = dr.ValorNumericoPorDefecto("IdSucursal", 0I)
                  .Stock = dr.Field(Of Decimal)("NuevoStock") - dr.Field(Of Decimal)("Stock")
                  .Usuario = actual.Nombre
               End With

               If dr.Field(Of Decimal)("NuevoStock") <> dr.Field(Of Decimal)("Stock") OrElse dr.Field(Of Integer)("idUbicacion") <> dr.Field(Of Integer)("NuevoIdUbicacion") Then
                  RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("Producto {0} - {1} - ACTUALIZA STOCK", dr("IdProducto"), dr("NombreProducto"))))
                  Dim rProductos = New Reglas.Productos(da)
                  '-- REQ-35260.- ---------------------------------------------
                  Dim AtributoProducto01 As Integer = Nothing
                  Dim AtributoProducto02 As Integer = Nothing
                  If atributo Then
                     AtributoProducto01 = dr.Field(Of Integer)("IdaAtributo01")
                     AtributoProducto02 = dr.Field(Of Integer)("IdaAtributo02")
                  End If
                  '------------------------------------------------------------
                  Dim IdDeposito = dr.Field(Of Integer)("IdDeposito")
                  Dim IdUbicacion As Integer = dr.Field(Of Integer)("IdUbicacion")
                  Dim IdNuevaUbic As Integer = dr.Field(Of Integer)("NuevoIdUbicacion")
                  '------------------------------------------------------------

                  rProductos._AjustarStock(prodsuc.Sucursal.Id,
                                           IdDeposito,
                                           IdUbicacion,
                                           IdNuevaUbic,
                                           prodsuc.Producto.IdProducto.ToString(),
                                           tablaContabilidad:=Nothing,
                                           grabaAutomatico:=True,
                                           esMultipleRubro:=False,
                                           viejoStock:=dr.Field(Of Decimal)("Stock"),
                                           nuevoStock:=dr.Field(Of Decimal)("NuevoStock"),
                                           metodoGrabacion:=Entidades.Entidad.MetodoGrabacion.Manual,
                                           idFuncion:=idFuncion,
                                           AtributoProducto01,
                                           AtributoProducto02,
                                           idaAtributo03:=Nothing,
                                           idaAtributo04:=Nothing)
               End If

               'If ajustaStockMinimoMaximo Then

               '   Dim seleccion = Function(dr1 As DataRow, actual As String, nuevo As String)
               '                      Dim valorNuevo = dr1.Field(Of Decimal?)(nuevo)
               '                      If dr1.Field(Of Decimal)(actual) = valorNuevo.IfNull() Then
               '                         valorNuevo = Nothing
               '                      End If
               '                      Return valorNuevo
               '                   End Function

               '   Dim stockminimo As Decimal? = seleccion(dr, "StockMinimo", "NuevoStockMinimo")
               '   Dim puntopedido As Decimal? = seleccion(dr, "PuntoDePedido", "NuevoPuntoDePedido")
               '   Dim stockmaximo As Decimal? = seleccion(dr, "StockMaximo", "NuevoStockMaximo")

               '   If stockminimo.HasValue Or puntopedido.HasValue Or stockmaximo.HasValue Then
               '      Dim sql = New SqlServer.ProductosSucursales(da)
               '      sql.ProductosSucursales_UEstadistica(prodsuc.Sucursal.Id, prodsuc.Producto.IdProducto,
               '                                           puntopedido, stockminimo, stockmaximo, New Entidades.CRMNovedad.CambioMasivo.NullableString())
               '      If prodsuc.Sucursal.IdSucursalAsociada > 0 Then
               '         sql.ProductosSucursales_UEstadistica(prodsuc.Sucursal.IdSucursalAsociada, prodsuc.Producto.IdProducto,
               '                                              puntopedido, stockminimo, stockmaximo, New Entidades.CRMNovedad.CambioMasivo.NullableString())
               '      End If
               '   End If

               'End If

               'If ajustaUbicacion Then
               '   If dr.Field(Of String)("Ubicacion") <> dr.Field(Of String)("NuevaUbicacion") Then
               '      RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("Producto {0} - {1} - ACTUALIZA UBICACION", dr("IdProducto"), dr("NombreProducto"))))
               '      ActualizarUbicacion(prodsuc.Producto.IdProducto, prodsuc.Sucursal.Id, prodsuc.Ubicacion)
               '   End If
               'End If

               da.CommitTransaction()
            Catch
               da.RollbakTransaction()
               Throw
            End Try
         Next
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub AjusteMasivoStockMinMaxPuntoPedido(dt As DataTable, ajustaUbicacion As Boolean, ajustaStockMinimoMaximo As Boolean, reprocesa As Boolean, idFuncion As String, atributo As Boolean)
      Try
         da.OpenConection()


         If Not reprocesa Then
            Dim productosConStockCero = 0I
            Dim stbProductosConStockCero = New StringBuilder()

            RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("COMENZANDO VALIDACIONES")))
         End If

         Dim cache = New BusquedasCacheadas()

         For Each dr As DataRow In dt.Select().Where(Function(drWhere)
                                                        Return (drWhere.Field(Of Decimal)("StockMinimo") <> drWhere.Field(Of Decimal)("NuevoStockMinimo") Or
                                                               drWhere.Field(Of Decimal)("PuntoDePedido") <> drWhere.Field(Of Decimal)("NuevoPuntoDePedido") Or
                                                               drWhere.Field(Of Decimal)("StockMaximo") <> drWhere.Field(Of Decimal)("NuevoStockMaximo"))
                                                     End Function)
            Try
               da.BeginTransaction()

               RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("Producto {0} - {1} - PROCESANDO", dr("IdProducto"), dr("NombreProducto"))))

               Dim prodsuc As Entidades.ProductoSucursal = New Entidades.ProductoSucursal()
               'Cargo los valores de la grilla al objeto productosSucursales
               With prodsuc
                  .Producto.IdProducto = dr.Field(Of String)("IdProducto").Trim()
                  .Sucursal = cache.BuscaSucursal(dr.Field(Of Integer)("IdSucursal"))
                  '.Sucursal.Id = dr.ValorNumericoPorDefecto("IdSucursal", 0I)
                  '  .Stock = dr.Field(Of Decimal)("NuevoStock") - dr.Field(Of Decimal)("Stock")
                  .Usuario = actual.Nombre
               End With

               If ajustaStockMinimoMaximo Then

                  Dim seleccion = Function(dr1 As DataRow, actual As String, nuevo As String)
                                     Dim valorNuevo = dr1.Field(Of Decimal?)(nuevo)
                                     If dr1.Field(Of Decimal)(actual) = valorNuevo.IfNull() Then
                                        valorNuevo = Nothing
                                     End If
                                     Return valorNuevo
                                  End Function

                  Dim stockminimo As Decimal? = seleccion(dr, "StockMinimo", "NuevoStockMinimo")
                  Dim puntopedido As Decimal? = seleccion(dr, "PuntoDePedido", "NuevoPuntoDePedido")
                  Dim stockmaximo As Decimal? = seleccion(dr, "StockMaximo", "NuevoStockMaximo")

                  If stockminimo.HasValue Or puntopedido.HasValue Or stockmaximo.HasValue Then
                     Dim sql = New SqlServer.ProductosSucursales(da)
                     sql.ProductosSucursales_UEstadistica(prodsuc.Sucursal.Id, prodsuc.Producto.IdProducto,
                                                          puntopedido, stockminimo, stockmaximo, New Entidades.CRMNovedad.CambioMasivo.NullableString())
                     If prodsuc.Sucursal.IdSucursalAsociada > 0 Then
                        sql.ProductosSucursales_UEstadistica(prodsuc.Sucursal.IdSucursalAsociada, prodsuc.Producto.IdProducto,
                                                             puntopedido, stockminimo, stockmaximo, New Entidades.CRMNovedad.CambioMasivo.NullableString())
                     End If
                  End If

               End If

               da.CommitTransaction()
            Catch
               da.RollbakTransaction()
               Throw
            End Try
         Next
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Friend"

   Public Sub ActualizarStock(idSucursal As Integer,
                              idDeposito As Integer,
                              idUbicacion As Integer,
                              idProducto As String,
                              movimiento As Decimal,
                              movimientoReservado As Decimal,
                              movimientoDefectuoso As Decimal,
                              movimientoFuturo As Decimal,
                              movimientoFuturoReservado As Decimal,
                              idaAtributo01 As Integer,
                              idaAtributo02 As Integer,
                              idaAtributo03 As Integer,
                              idaAtributo04 As Integer)

      '-- REQ-34747.- -----------------------------------------------------------
      If (idaAtributo01 + idaAtributo02 + idaAtributo03 + idaAtributo04) > 0 Then
         Dim eProSucArt = New Entidades.ProductoSucursalAtributo
         With eProSucArt
            .IdSucursal = idSucursal
            .IdProducto = idProducto
            .IdaAtributo01 = idaAtributo01
            .IdaAtributo02 = idaAtributo02
            .IdaAtributo03 = idaAtributo03
            .IdaAtributo04 = idaAtributo04
            .Stock = movimiento
            .Stock2 = 0
            .IdDeposito = idDeposito
            .IdUbicacion = idUbicacion
         End With
         Dim rProSucAtr = New ProductosSucursalesAtributos(da)
         rProSucAtr.Merge(eProSucArt)
      End If
      '--------------------------------------------------------------------------

      Dim rProd As Reglas.Productos = New Reglas.Productos(da)

      Dim prod As Entidades.Producto
      prod = rProd.GetUno(idProducto)
      If prod.AfectaStock Then
         '-- Actualiza Productos Stock.- --
         ActualizaProductosStock(idSucursal, idDeposito, idUbicacion, idProducto, movimiento, movimientoReservado, movimientoDefectuoso, movimientoFuturo, movimientoFuturoReservado)
         Dim eUbicacion = New SucursalesUbicaciones(da).GetUno(idDeposito, idSucursal, idUbicacion)
         If eUbicacion.SucursalAsociada > 0 Then
            ActualizaProductosStock(eUbicacion.SucursalAsociada, eUbicacion.DepositoAsociado, eUbicacion.UbicacionAsociada, idProducto, movimiento, movimientoReservado, movimientoDefectuoso, movimientoFuturo, movimientoFuturoReservado)
         End If
      End If
   End Sub
   Public Sub ActualizaProductosStock(idSucursal As Integer, IdDeposito As Integer, IdUbicacion As Integer,
                                      idProducto As String, movimiento As Decimal, movimientoReservado As Decimal,
                                      movimientoDefectuoso As Decimal, movimientoFuturo As Decimal, movimientoFuturoReservado As Decimal)

      Dim sqlSuc = New SqlServer.ProductosSucursales(da)
      Dim sqlDep = New SqlServer.ProductosDepositos(da)
      Dim sqlUbi = New SqlServer.ProductosUbicaciones(da)

      sqlSuc.ProductosSucursales_UStock(idSucursal, IdDeposito, idProducto, movimiento, movimientoReservado, movimientoDefectuoso, movimientoFuturo, movimientoFuturoReservado)
      sqlDep.ProductosSucursalesDepositos_UStock(idSucursal, IdDeposito, idProducto, stock:=movimiento, stock2:=0)
      sqlUbi.ProductosSucursalesUbicacion_UStock(idSucursal, IdDeposito, IdUbicacion, idProducto, stock:=movimiento, stock2:=0)
   End Sub
   Public Sub ActualizarStockInicial(idSucursal As Integer, idProducto As String, movimiento As Decimal)

      Dim rProd As Reglas.Productos = New Reglas.Productos(da)

      If rProd.GetUno(idProducto).AfectaStock Then

         Dim sql As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(da)

         sql.ProductosSucursales_UStockInicial(idSucursal, idProducto, movimiento)

         Dim IdSucAsociada As Integer = New Reglas.Sucursales(da).GetUna(idSucursal, False).IdSucursalAsociada

         If IdSucAsociada > 0 Then
            sql.ProductosSucursales_UStockInicial(IdSucAsociada, idProducto, movimiento)
         End If

      End If

   End Sub

   Public Function GetProductosPorUbicacionPredeterminada(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer) As DataTable
      Return New SqlServer.ProductosSucursales(da).GetProductosPorUbicacionPredeterminada(idSucursal, idDeposito, idUbicacion)
   End Function

   Public Function GetSucursalesDepositoStock(idSucursal As Integer, idDeposito As Integer, idProducto As String) As Decimal
      Dim dt = New SqlServer.ProductosSucursales(da).GetSucursalesDepositoStock(idSucursal, idDeposito, idProducto)
      Dim vStock As Decimal
      For Each dr As DataRow In dt.Rows
         vStock = dr.Field(Of Decimal)("Stock")
      Next
      Return vStock
   End Function

   Public Function GetSucursalProductosStock(idSucursal As Integer, idProducto As String) As Decimal
      Dim dt = New SqlServer.ProductosSucursales(da).GetSucursalProductosStock(idSucursal, idProducto)
      Dim vStock As Decimal
      For Each dr As DataRow In dt.Rows
         vStock = dr.Field(Of Decimal)("Stock")
      Next
      Return vStock
   End Function

   Public Function GetSucursalProductosDeposito(idSucursal As Integer, idProducto As String) As Integer
      Dim dt = New SqlServer.ProductosSucursales(da).GetSucursalProductosDeposito(idSucursal, idProducto)
      Dim vDeposito As Integer
      For Each dr As DataRow In dt.Rows
         vDeposito = dr.Field(Of Integer)("IdDepositoDefecto")
      Next
      Return vDeposito
   End Function

   Public Function ValidaProductosSucursalesDepositoDefecto(idSucursal As Integer, IdDeposito As Integer) As Boolean
      Dim dt = New SqlServer.ProductosSucursales(da).GetSucursalesPorDepositDefecto(idSucursal, IdDeposito)
      Return dt.Rows(0).Field(Of Integer)("Cantidad") > 0
   End Function

#End Region

End Class