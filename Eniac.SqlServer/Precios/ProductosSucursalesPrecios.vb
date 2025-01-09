Public Class ProductosSucursalesPrecios
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosSucursalesPrecios_I(idProducto As String,
                                           idSucursal As Integer,
                                           idListaPrecios As Integer,
                                           precioVenta As Decimal,
                                           fechaActualizacion As DateTime,
                                           usuario As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ProductosSucursalesPrecios")
         .AppendLine("   (IdProducto")
         .AppendLine("   ,IdSucursal")
         .AppendLine("   ,IdListaPrecios")
         .AppendLine("   ,PrecioVenta")
         .AppendLine("   ,FechaActualizacion")
         .AppendLine("   ,Usuario")
         .AppendLine(" ) VALUES (")
         .AppendFormatLine("    '{0}'", idProducto)
         .AppendFormatLine("   , {0} ", idSucursal)
         .AppendFormatLine("   , {0} ", idListaPrecios)
         .AppendFormatLine("   , {0} ", precioVenta)
         .AppendFormatLine("   ,'{0}'", ObtenerFecha(fechaActualizacion, True))
         .AppendFormatLine("   ,'{0}'", usuario)
         .AppendLine(")")
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursalesPrecios")
   End Sub

   Public Sub ProductosSucursalesPrecios_U_Actualiza_Producto_PublicarEnSincronizacionSucursal(idProducto As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PS")
         .AppendFormatLine("   SET FechaActualizacionWeb = GETDATE()")
         .AppendFormatLine("  FROM ProductosSucursalesPrecios PS")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendFormatLine(" WHERE P.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND P.PublicarEnSincronizacionSucursal = 'False'")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProductosSucursalesPrecios_U(idProducto As String,
                                           idSucursal As Integer,
                                           idListaPrecios As Integer,
                                           precioVenta As Decimal,
                                           fechaActualizacion As Date,
                                           usuario As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("UPDATE ProductosSucursalesPrecios")
         .AppendLine("   SET ")
         .AppendFormatLine("      PrecioVenta = {0}", precioVenta)
         .AppendFormatLine("      ,FechaActualizacion = '{0}'", ObtenerFecha(fechaActualizacion, True))
         .AppendFormatLine("      ,Usuario = '{0}'", usuario)
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdListaPrecios = {0}", idListaPrecios)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursalesPrecios")
   End Sub

   Public Sub ProductosSucursalesPrecios_D(idProducto As String, idSucursal As Integer, idListaPrecios As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM ProductosSucursalesPrecios ")
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         If idSucursal > 0 Then
            .AppendFormatLine("   AND IdSucursal = {0}", idSucursal)
         End If
         If idListaPrecios >= 0 Then
            .AppendFormatLine("   AND IdListaPrecios = {0}", idListaPrecios)
         End If
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursalesPrecios")
   End Sub

   'Genera para la lista especificado todos los precios con precio en Cero en todas las sucursales.
   Public Sub ProductosSucursalesPrecios_IFull(idListaPrecios As Integer, usuario As String, ListaACopiar As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ProductosSucursalesPrecios  ")
         .AppendLine("(IdProducto, IdSucursal, IdListaPrecios, PrecioVenta, FechaActualizacion, Usuario)")
         .AppendLine(" SELECT PS.IdProducto, PS.IdSucursal, ")
         .AppendLine(idListaPrecios.ToString() & " as NumeroLista, ")

         'En lugar de insertar todos en 0 (cero), inserto con el precio base, para que comience a actualizarlos.
         '.AppendLine("0.00 as Precio, ")
         .AppendLine("PSP.PrecioVenta, ")

         .AppendLine("GetDATE() as Actualizacion, ")
         .AppendLine("'" & usuario & "' as Usuario")
         .AppendLine(" FROM ProductosSucursales PS ")
         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
         .AppendLine(" WHERE PSP.IdListaPrecios = " & ListaACopiar)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursalesPrecios")
   End Sub

   Public Sub ProductosSucursalesPrecios_DFull(idListaPrecios As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Append("DELETE FROM ProductosSucursalesPrecios ")
         .AppendFormat(" WHERE IdListaPrecios = {0}", idListaPrecios)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursalesPrecios")
   End Sub

   Public Sub ProductosSucursalesPrecios_IProdSuc(idProducto As String, idSucursal As Integer, usuario As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ProductosSucursalesPrecios ")
         .AppendLine("(IdProducto, IdSucursal, IdListaPrecios, PrecioVenta, FechaActualizacion, Usuario)")
         .AppendLine("SELECT PS.IdProducto, PS.IdSucursal, LdP.IdListaPrecios, ")
         .AppendLine("0.00 as Precio, ")
         .AppendLine("GetDATE() as Actualizacion, ")
         .AppendLine("'" & usuario & "' as Usuario")
         .AppendLine(" FROM ProductosSucursales PS, ListasDePrecios LdP ")
         .AppendLine(" WHERE PS.IdProducto = '" & idProducto & "' ")
         .AppendLine("   AND PS.IdSucursal = " & idSucursal.ToString())
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursalesPrecios")
   End Sub

   Public Sub ProductosSucursalesPrecios_DProdSuc(idProducto As String, idSucursal As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM ProductosSucursalesPrecios")
         .AppendLine(" WHERE IdProducto = '" & idProducto & "' ")
         If idSucursal > 0 Then
            .AppendLine("   AND IdSucursal = " & idSucursal.ToString())
         End If
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursalesPrecios")
   End Sub

   Public Sub ProductosSucursalesPrecios_DPorSucursal(idSucursal As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM ProductosSucursalesPrecios")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursalesPrecios")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, blnPreciosConIVA As Boolean, aplicarPreciosOferta As Boolean)
      With stb
         .AppendLine("SELECT PSP.IdProducto")
         .AppendLine("      ,PSP.IdSucursal")
         .AppendLine("      ,PSP.IdListaPrecios")
         .AppendLine("      ,PSP.PrecioVenta")
         .AppendLine("      ,PSP.FechaActualizacion")
         .AppendLine("      ,PSP.Usuario")
         .AppendLine("      ,LP.NombreListaPrecios")
         .AppendFormatLine("      ,PSP.{0}", Entidades.ProductoSucursalPrecio.Columnas.FechaActualizacionWeb.ToString()).AppendLine()

         Dim campoPrecio As String = "PSP.PrecioVenta"
         If aplicarPreciosOferta Then
            campoPrecio = "ISNULL(PO.PrecioOferta, PSP.PrecioVenta)"
         End If

         If blnPreciosConIVA Then
            .AppendFormatLine("  ,ROUND({0}, {1}) AS PrecioVentaSinIVA",
                              SqlServer.CalculosImpositivos.ObtenerPrecioSinImpuestos(campoPrecio, "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), 2)
            .AppendFormatLine("  ,{0} as PrecioVentaConIVA", campoPrecio)
         Else
            .AppendFormatLine("  ,{0} as PrecioVentaSinIVA", campoPrecio)
            .AppendFormatLine("  ,ROUND({0}, {1}) AS PrecioVentaConIVA",
                              SqlServer.CalculosImpositivos.ObtenerPrecioConImpuestos(campoPrecio, "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), 2)
         End If

         .AppendLine("      ,P.IdMoneda")
         .AppendLine("      ,P.PrecioPorEmbalaje")
         .AppendLine("      ,P.Embalaje")

         .AppendLine("  FROM ProductosSucursalesPrecios PSP")
         .AppendLine(" INNER JOIN Sucursales S ON PSP.IdSucursal = S.IdSucursal ")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = PSP.IdProducto ")
         .AppendLine(" INNER JOIN ListasDePrecios LP ON LP.IdListaPrecios = PSP.IdListaPrecios ")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdSucursal=PSP.IdSucursal AND PS.IdProducto=PSP.IdProducto")
         If aplicarPreciosOferta Then
            .AppendFormatLine("  LEFT JOIN (SELECT * FROM ProductosOfertas PO  ")
            .AppendFormatLine("                     WHERE PO.{0} =   {1} ", Entidades.ProductoOferta.Columnas.Activa.ToString(), GetStringFromBoolean(True))
            .AppendFormatLine("                       AND PO.{0} <= '{1}'", Entidades.ProductoOferta.Columnas.FechaDesde.ToString(), ObtenerFecha(Today, True))
            .AppendFormatLine("                       AND PO.{0} >= '{1}'", Entidades.ProductoOferta.Columnas.FechaHasta.ToString(), ObtenerFecha(Today.UltimoSegundoDelDia, True))
            .AppendFormatLine("                       AND PO.{0} < PO.{1} ", Entidades.ProductoOferta.Columnas.CantidadConsumida.ToString(), Entidades.ProductoOferta.Columnas.LimiteStock.ToString())
            .AppendFormatLine("             ) PO ON PO.IdProducto = PSP.IdProducto ")

         End If
      End With
   End Sub

   Public Function ProductosSucursalesPrecios_GA(fechaActualizacionDesde As DateTime?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros,
                                                 blnPreciosConIVA As Boolean, listaPrecioPublicarenWeb As Entidades.Publicos.SiNoTodos,
                                                 soloTraeEstoyAca As Boolean, publicarEnWebSucursal As Entidades.Publicos.SiNoTodos,
                                                 aplicarPreciosOferta As Boolean, soloProductosConStock As Boolean,
                                                 productoActivo As Boolean?, productoModulo As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, blnPreciosConIVA, aplicarPreciosOferta)
         .AppendLine(" WHERE 1 = 1")
         If soloTraeEstoyAca Then
            .AppendLine("   AND S.EstoyAca = 'True'")
         End If
         If soloProductosConStock Then
            .AppendFormatLine("   AND PS.Stock > 0")
         End If
         If fechaActualizacionDesde.HasValue Then
            .AppendFormatLine("   AND PSP.{0} > '{1}'", Entidades.ProductoSucursalPrecio.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True))
         End If
         ProductoPublicarEn(stb, publicarEn, "P")
         'If publicarEnWeb <> Entidades.Publicos.SiNoTodos.TODOS Then
         '   .AppendFormatLine("   AND P.{0} = {1}", Entidades.Producto.Columnas.PublicarEnWeb.ToString(), GetStringFromBoolean(publicarEnWeb = Entidades.Publicos.SiNoTodos.SI))
         'End If
         If listaPrecioPublicarenWeb <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND LP.PublicarenWeb = {0}", GetStringFromBoolean(listaPrecioPublicarenWeb = Entidades.Publicos.SiNoTodos.SI))
         End If
         If publicarEnWebSucursal <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND S.{0} = {1}", Entidades.Sucursal.Columnas.PublicarEnWeb.ToString(), GetStringFromBoolean(publicarEnWebSucursal = Entidades.Publicos.SiNoTodos.SI))
         End If

         If productoActivo.HasValue Then
            .AppendFormatLine("   AND P.Activo = {0}", GetStringFromBoolean(productoActivo.Value))
         End If

         If Not String.IsNullOrWhiteSpace(productoModulo) AndAlso productoModulo <> "TODOS" Then
            .AppendFormatLine("   AND P.EsDe{0} = 'True'", productoModulo)   'De Ventas o Compras
         End If

         .Append("  ORDER BY PSP.IdProducto")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function ProductosSucursalesPrecios_G1(idProducto As String, idSucursal As Integer, idListaPrecios As Integer,
                                                 blnPreciosConIVA As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, blnPreciosConIVA, aplicarPreciosOferta:=False)
         .AppendFormat(" WHERE PSP.IdProducto = '{0}'", idProducto)
         .AppendFormat("   AND PSP.IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND PSP.IdListaPrecios = {0}", idListaPrecios)
      End With

      Return GetDataTable(stb)
   End Function

   Public Function Buscar(columna As String, valor As String, blnPreciosConIVA As Boolean) As DataTable
      columna = "PSP." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, blnPreciosConIVA, aplicarPreciosOferta:=False)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub ProductosSucursalesPrecios_IFaltante(idProducto As String, usuario As String)
      'Dim listaACopiar As Integer = Int32.Parse(New SqlServer.Parametros(Me._da).GetValorPD("LISTAPRECIOSPREDETERMINADA", "0"))
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ProductosSucursalesPrecios ")
         .AppendLine("(IdProducto, IdSucursal, IdListaPrecios, PrecioVenta, FechaActualizacion, Usuario)")

         .AppendLine("SELECT F.IdProducto, ")
         .AppendLine("    F.IdSucursal, ")
         .AppendLine("    F.IdListaPrecios, ")
         .AppendLine("    0, ")
         .AppendLine("    GetDATE() as Actualizacion, ")
         .AppendLine("    '" & usuario & "' as Usuario ")
         .AppendLine("  FROM ProductosSucursales PS")

         'Genero el producto cartesiado de Productos, Sucursales y Listas
         .AppendLine(", (SELECT P.IdProducto, S.IdSucursal, LP.IdListaPrecios FROM Productos P, Sucursales S, ListasDePrecios LP ")

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine(" WHERE P.IdProducto = '" & idProducto & "'")
            .AppendLine("   AND NOT EXISTS ")
         Else

            .AppendLine(" WHERE NOT EXISTS ")
         End If


         'Me fijo cual falta en la tabla destino

         .AppendLine("   ( SELECT * FROM ProductosSucursalesPrecios PSP ")
         .AppendLine("         WHERE PSP.idproducto = P.IdProducto ")
         .AppendLine("         AND PSP.IdSucursal=S.IdSucursal ")
         .AppendLine("         AND PSP.IdListaPrecios=LP.IdListaPrecios ")
         .AppendLine("     ) ")
         .AppendLine("                               ) F ")
         .AppendLine(" WHERE PS.IdProducto = F.IdProducto ")
         .AppendLine("   AND PS.IdSucursal = F.IdSucursal ")

      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursalesPrecios")
   End Sub

   Public Sub ProductosSucursalesPrecios_IPorSucursal(IdSucursal As Integer, Usuario As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ProductosSucursalesPrecios")
         .AppendLine("            (IdProducto,")
         .AppendLine("            IdSucursal,")
         .AppendLine("            IdListaPrecios,")
         .AppendLine("            PrecioVenta,")
         .AppendLine("            FechaActualizacion,")
         .AppendLine("            Usuario)")

         .AppendLine("SELECT PS.IdProducto,")
         .AppendLine("       " & IdSucursal.ToString() & " AS Sucursal,")
         .AppendLine("       PS.IdListaPrecios,")
         .AppendLine("       PS.PrecioVenta,")
         .AppendLine("       GetDATE() as Actualizacion,")
         .AppendLine("       '" & Usuario & "' as Usuario")
         .AppendLine("  FROM ProductosSucursalesPrecios PS, Sucursales S")
         .AppendLine(" WHERE PS.IdSucursal = S.IdSucursal")
         .AppendLine("   AND S.SoyLaCentral = 'True'")   '-- Copio de la Sucursal que siempre debe estar.

      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursalesPrecios")
   End Sub

   Public Sub ProductosSucursalesPrecios_M(idProducto As String,
                                           idSucursal As Integer,
                                           idListaPrecios As Integer,
                                           precioVenta As Decimal,
                                           fechaActualizacion As DateTime,
                                           usuario As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("MERGE INTO ProductosSucursalesPrecios AS D")
         .AppendFormat("     USING (SELECT '{0}' AS IdProducto", idProducto).AppendLine()
         .AppendFormat("                  , {0}  AS IdSucursal", idSucursal).AppendLine()
         .AppendFormat("                  , {0}  AS IdListaPrecios", idListaPrecios).AppendLine()
         .AppendFormat("                  , {0}  AS PrecioVenta", precioVenta).AppendLine()
         .AppendFormat("                  ,'{0}' AS FechaActualizacion", ObtenerFecha(fechaActualizacion, False)).AppendLine()
         .AppendFormat("                  ,'{0}' AS Usuario", usuario).AppendLine()
         .AppendLine("        ) AS O")
         .AppendLine("        ON O.IdProducto = D.IdProducto AND O.IdSucursal = D.IdSucursal AND O.IdListaPrecios = D.IdListaPrecios")
         .AppendLine(" WHEN MATCHED THEN")
         .AppendLine("    UPDATE")
         .AppendLine("       SET D.PrecioVenta = O.PrecioVenta")
         .AppendLine("          ,D.FechaActualizacion = O.FechaActualizacion")
         .AppendLine("          ,D.Usuario = O.Usuario")
         .AppendLine(" WHEN NOT MATCHED THEN")
         .AppendLine("            INSERT(  IdProducto,   IdSucursal,   IdListaPrecios,   PrecioVenta,   Usuario,   FechaActualizacion)")
         .AppendLine("            VALUES(O.IdProducto, O.IdSucursal, O.IdListaPrecios, O.PrecioVenta, O.Usuario, O.FechaActualizacion);")
      End With

      Execute(myQuery.ToString())
   End Sub

End Class