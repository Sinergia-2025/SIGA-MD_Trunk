Partial Class Productos
   Public Sub Productos_CC(idProductoOrigen As String, idProductoDestino As String, base As String,
                           idFormula As Integer?)

      Dim myQuery As StringBuilder = New StringBuilder()

      Dim arrTablas(0 To 56, 0 To 6) As String, Cont As Integer, strSQL As String
      Dim strCampos As String, strValores As String, strFiltro As String
      Dim intRegistros As Integer

      'Campos ArrTablas
      '0: Nombre de Tabla.
      '1: Nombre del Campo que identifica el tipo de documento. Puede ser: TipoDocProveedor o ??.
      '2: Nombre del Campo que identifica el Numero de documento. Puede ser: IdProveedor o ??.
      '3: Indica si tiene el campo Identificador de la sucursal (IdSucursal).
      '4: Indica si el campo forma parte de la clave primaria.
      '5: Indica si la tabla tiene el campo IdProductoPrestado. Es NO PK, porque si lo fuera... no andaria.
      '6: Indica si la tabla tiene el campo IdProductoComponente. Es NO PK, porque si lo fuera... no andaria.

      'A futuro hay que automatizarlo.
      arrTablas(0, 0) = "Productos"
      arrTablas(1, 0) = "ProductosSucursales"
      arrTablas(2, 0) = "ProductosDepositos"
      arrTablas(3, 0) = "ProductosUbicaciones"
      arrTablas(4, 0) = "ProductosSucursalesPrecios"
      arrTablas(5, 0) = "ProductosNrosSerie"
      arrTablas(6, 0) = "ProductosLotes"
      arrTablas(7, 0) = "ProductosFormulas"
      arrTablas(8, 0) = "FichasProductos"
      arrTablas(9, 0) = "VentasProductos"
      arrTablas(10, 0) = "VentasProductosLotes"
      arrTablas(11, 0) = "MovimientosStockProductos"
      arrTablas(12, 0) = "ComprasProductos"
      arrTablas(13, 0) = "HistorialPrecios"
      arrTablas(14, 0) = "RecepcionNotas"
      arrTablas(15, 0) = "RecepcionNotasF"
      arrTablas(16, 0) = "ProductosComponentes"

      arrTablas(17, 0) = "ProduccionProductos"
      arrTablas(18, 0) = "ProduccionProductosComponentes"
      arrTablas(19, 0) = "ProductosProveedores"
      arrTablas(20, 0) = "AlquileresTarifasProductos"
      arrTablas(21, 0) = "Alquileres"
      arrTablas(22, 0) = "PedidosProductos"

      arrTablas(23, 0) = "PedidosProductosProveedores"
      arrTablas(24, 0) = "PedidosEstadosProveedores"
      arrTablas(25, 0) = "HistorialConsultaProductos"

      arrTablas(26, 0) = "RepartosProductosSinDescargar"
      arrTablas(27, 0) = "Calendarios"
      arrTablas(28, 0) = "TurnosCalendariosProductos"
      arrTablas(29, 0) = "CalidadListasControlProductos"
      arrTablas(30, 0) = "CalidadListasControlProductosItems"
      arrTablas(31, 0) = "Cargos"
      arrTablas(32, 0) = "Categorias"
      arrTablas(33, 0) = "Conceptos"
      arrTablas(34, 0) = "EmpleadosComisionesProductos"
      arrTablas(35, 0) = "EmpleadosComisionesProductosPrecios"

      arrTablas(36, 0) = "ProductosIdentificaciones"
      arrTablas(37, 0) = "ProductosOfertas"

      arrTablas(38, 0) = "TiposComprobantes" : arrTablas(38, 1) = "IdProductoNCred"
      arrTablas(39, 0) = "TiposComprobantes" : arrTablas(39, 1) = "IdProductoNDeb"
      arrTablas(40, 0) = "TiposComprobantesProductos"

      arrTablas(41, 0) = "MovimientosStockProductosLotes"
      arrTablas(42, 0) = "MovimientosStockProductosNrosSerie"

      arrTablas(43, 0) = "AuditoriaCalidadListasControlProductos"

      arrTablas(44, 0) = "CRMNovedades"
      arrTablas(45, 0) = "CRMNovedades" : arrTablas(47, 1) = "IdProductoNovedad"
      arrTablas(46, 0) = "CRMNovedades" : arrTablas(48, 1) = "IdProductoPrestado"
      arrTablas(47, 0) = "AuditoriaCRMNovedades"
      arrTablas(48, 0) = "AuditoriaCRMNovedades" : arrTablas(48, 1) = "IdProductoNovedad"
      arrTablas(49, 0) = "AuditoriaCRMNovedades" : arrTablas(49, 1) = "IdProductoPrestado"

      arrTablas(50, 0) = "ClientesDescuentosProductos"
      arrTablas(51, 0) = "ComprasProductosNrosSerie"

      arrTablas(52, 0) = "OrdenesProduccionProductos"
      arrTablas(53, 0) = "OrdenesProduccionEstados"
      ' arrTablas(53, 0) = "PedidosEstados"
      arrTablas(54, 0) = "PedidosEstados" : arrTablas(54, 1) = "IdProductoProduccion"

      arrTablas(55, 0) = "VentasProductosNrosSerie"


      'RecepcionNotas / IdProductoPrestado ( Ver Garante de CLIentes)

      '1-Inserto los registros con el nuevo codigo

      For Cont = 0 To (arrTablas.Length / 7).ToInteger() - 1

         'Consulto si la Tabla Existe.
         strSQL = "SELECT count(*) as Registros FROM INFORMATION_SCHEMA.TABLES "
         strSQL = strSQL & "WHERE TABLE_NAME='" & arrTablas(Cont, 0) & "'"

         Dim reader As System.Data.Common.DbDataReader

         reader = Me.ExecuteReadear(strSQL)
         reader.Read()

         intRegistros = reader.GetInt32(0)

         reader.Close()

         'La tabla no existe. Puede ser porque es generico para todos los clientes. Ejemplo Tabla: Fichas.
         If intRegistros = 0 Then

            arrTablas(Cont, 0) = "**SALTAR**"

         Else

            'Obtengo los campos que forman esta tabla.
            strSQL = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS "
            strSQL = strSQL & "where TABLE_NAME='" & arrTablas(Cont, 0) & "'"
            strSQL = strSQL & " AND COLUMNPROPERTY(OBJECT_ID(TABLE_SCHEMA+'.'+TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 0"

            reader = Me.ExecuteReadear(strSQL)

            Dim columnas As List(Of String) = New List(Of String)()

            strCampos = ""
            strValores = ""
            strFiltro = " 1=1 "
            'Por ahora NO SE UTILIZARIA!!! - IdSucursal
            arrTablas(Cont, 3) = "NO"
            arrTablas(Cont, 5) = "NO"
            arrTablas(Cont, 6) = "NO"

            Using reader
               Do While reader.Read()
                  ' NO ES MAS IDENTITY

                  ''NO hay que utilizarlo en el INSERT.
                  ''Es identity y no encuentro la vista para consultarlo.. asi que va de esta forma.. 
                  'If reader.GetString(0) <> "Orden" Then
                  '   columnas.Add(reader.GetString(0))
                  'End If
                  '---------------------------------
                  columnas.Add(reader.GetString(0))

               Loop
            End Using

            For Each col As String In columnas
               strCampos = strCampos & ", " & col

               If col = "IdProducto" Then

                  strValores = strValores & ", '" & idProductoDestino & "'"

                  arrTablas(Cont, 1) = col

                  strFiltro = strFiltro & " AND " & col & " = '" & idProductoOrigen & "'"

                  '----------------------------------------------------

                  'Averigüo si el campo forma parte de la clave primaria.
                  strSQL = "select count(*) as Registros from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE"
                  strSQL = strSQL & " where TABLE_NAME='" & arrTablas(Cont, 0) & "'"
                  strSQL = strSQL & "   and COLUMN_NAME='" & arrTablas(Cont, 1) & "'"  'Consulto solo por el TipoDocumento, seria un error de 
                  strSQL = strSQL & "   and CONSTRAINT_NAME in "
                  strSQL = strSQL & "(select CONSTRAINT_NAME from INFORMATION_SCHEMA.TABLE_CONSTRAINTS"
                  strSQL = strSQL & " where TABLE_NAME='" & arrTablas(Cont, 0) & "'"
                  strSQL = strSQL & "   and CONSTRAINT_TYPE='PRIMARY KEY'"
                  strSQL = strSQL & ")"

                  intRegistros = Int32.Parse(Me.ExecuteScalar(strSQL).ToString())

                  If intRegistros > 0 Then
                     arrTablas(Cont, 4) = "SI"
                  Else
                     arrTablas(Cont, 4) = "NO"
                  End If

                  '----------------------------------------------------

               ElseIf col = "IdFormula" AndAlso
                  (arrTablas(Cont, 0) = "Productos" OrElse
                  arrTablas(Cont, 0) = "VentasProductos") AndAlso
                  idFormula IsNot Nothing Then

                  strValores = strValores & ", NULL " '# En caso que producto tenga un IdFormula asociado, primero debo insertarlo nulo para que no de error de FK. Luego se actualiza el producto con su IdFormula correspondiente

               Else

                  strValores = strValores & ", " & col

                  'Activo la marca de que lo contiene el Campo Garante
                  If col = "IdProductoPrestado" Then
                     arrTablas(Cont, 5) = "SI"
                  ElseIf col = "IdProductoComponente" Then
                     arrTablas(Cont, 6) = "SI"
                  ElseIf col = "IdProductoProduccion" Then
                     arrTablas(Cont, 3) = "SI"
                  End If

               End If

            Next

            strCampos = strCampos.Substring(1)
            strValores = strValores.Substring(1)

            With myQuery
               .Length = 0
               .Append("INSERT INTO " & arrTablas(Cont, 0) & Chr(13))
               .Append("      (" & strCampos & ")" & Chr(13))
               .Append("(" & Chr(13))
               .Append("SELECT " & strValores & Chr(13))
               .Append("  FROM " & arrTablas(Cont, 0) & Chr(13))
               .Append(" WHERE " & strFiltro & Chr(13))
               .Append(");")
            End With

         End If

         'Si forma parte de la Clave Primaria, hace INSERT y DELETE... sino UPDATE.
         If arrTablas(Cont, 4) = "SI" And arrTablas(Cont, 0) <> "**SALTAR**" Then
            Me.Execute(myQuery.ToString())
            Me.Sincroniza_I(myQuery.ToString(), arrTablas(Cont, 0))
         End If

      Next

      '# Si el producto tiene un IdFormula, lo actualizo ahora (ya que antes no existía en ProductosFormulas)
      '# Las siguientes tablas deben tener el campo IdFormula con un valor SOLO SI ya existe en ProductosFormulas
      Dim query As StringBuilder = New StringBuilder
      With query
         If idFormula IsNot Nothing Then
            .AppendFormatLine("UPDATE Productos SET IdFormula = {0} WHERE IdProducto = '{1}'", idFormula, idProductoDestino)
            .AppendFormatLine("UPDATE VentasProductos SET IdFormula = {0} WHERE IdProducto = '{1}'", idFormula, idProductoDestino)
            Me.Execute(query.ToString())
         End If
      End With

      'INSERTO PRODUCTOSWEB

      'Por el momento queda asi ya que esta tabla se puede utilizar por fuera de la base de datos del SIGA.
      'No hay formas de hacerlo generico y tenemos que poner el script directo.
      'armo un try and catch para que el error sea claro
      Try
         With myQuery
            .Length = 0
            .AppendLine("INSERT INTO " & base & "ProductosWeb (")
            .AppendLine("   IdProducto")
            .AppendLine(" ,Caracteristica1")
            .AppendLine(" ,ValorCaracteristica1")
            .AppendLine(" ,Caracteristica2")
            .AppendLine(" ,ValorCaracteristica2")
            .AppendLine(" ,Caracteristica3")
            .AppendLine(" ,ValorCaracteristica3) ")
            .Append(" (SELECT '" & idProductoDestino & "'")
            .AppendLine(" ,Caracteristica1")
            .AppendLine(" ,ValorCaracteristica1")
            .AppendLine(" ,Caracteristica2")
            .AppendLine(" ,ValorCaracteristica2")
            .AppendLine(" ,Caracteristica3")
            .AppendLine(" ,ValorCaracteristica3")
            .Append("  FROM " & base & "ProductosWeb")
            .Append(" WHERE IdProducto =  '" & idProductoOrigen & "'")
            .Append(")")
         End With
         Me.Execute(myQuery.ToString())

         With myQuery
            .Length = 0
            .Append("DELETE FROM " & base & "ProductosWeb ")
            .Append(" WHERE IdProducto =  '" & idProductoOrigen & "'")
         End With

         Me.Execute(myQuery.ToString())
      Catch ex As Exception
         Throw New Exception(String.Format("ERROR en la tabla {0}. Error detallado {1}", base + "ProductoWeb", ex.Message), ex)
      End Try


      '2-Borro los registros con el codigo viejo, en orden inverso

      For Cont = (arrTablas.Length / 7).ToInteger() - 1 To 0 Step -1

         If arrTablas(Cont, 0) <> "**SALTAR**" Then

            If arrTablas(Cont, 3) = "SI" Then

               With myQuery
                  .Length = 0
                  .AppendLine("UPDATE " & arrTablas(Cont, 0) & " SET ")
                  .AppendLine("  IdProductoProduccion = '" & idProductoDestino & "'")
                  .AppendLine(" WHERE IdProductoProduccion = '" & idProductoOrigen & "'")
               End With

               Me.Execute(myQuery.ToString())
               Me.Sincroniza_I(myQuery.ToString(), arrTablas(Cont, 0))
            End If

            '# Antes de eliminar ProductosFormulas, debo blanquear el campo de IdFormula en el IdProducto viejo. 
            If arrTablas(Cont, 0) = "ProductosFormulas" AndAlso idFormula IsNot Nothing Then
               query = New StringBuilder
               With query
                  .AppendFormatLine("UPDATE Productos SET IdFormula = NULL WHERE IdProducto = '{0}'", idProductoOrigen)
               End With
               Me.Execute(query.ToString())
            End If

            With myQuery
               .Length = 0

               If arrTablas(Cont, 4) = "SI" Then
                  .Append("DELETE " & arrTablas(Cont, 0) & Chr(13))
               Else
                  .Append("UPDATE " & arrTablas(Cont, 0) & " SET " & Chr(13))
                  .Append(arrTablas(Cont, 1) & " = '" & idProductoDestino & "' " & Chr(13))
               End If

               .Append(" WHERE " & arrTablas(Cont, 1) & " = '" & idProductoOrigen & "'" & Chr(13))

            End With

            Me.Execute(myQuery.ToString())
            Me.Sincroniza_I(myQuery.ToString(), arrTablas(Cont, 0))

         End If

         'Tiene el campo Garante (tiene ambos campos), necesito hacer 2 actualizaciones en la misma tabla
         If arrTablas(Cont, 5) = "SI" Then

            With myQuery
               .Length = 0
               .AppendLine("UPDATE " & arrTablas(Cont, 0) & " SET ")
               .AppendLine("  IdProductoPrestado = '" & idProductoDestino & "'")
               .AppendLine(" WHERE IdProductoPrestado = '" & idProductoOrigen & "'")
            End With

            Me.Execute(myQuery.ToString())
            Me.Sincroniza_I(myQuery.ToString(), arrTablas(Cont, 0))
         End If

         If arrTablas(Cont, 6) = "SI" Then

            With myQuery
               .Length = 0
               .AppendLine("UPDATE " & arrTablas(Cont, 0) & " SET ")
               .AppendLine("  IdProductoComponente = '" & idProductoDestino & "'")
               .AppendLine(" WHERE IdProductoComponente = '" & idProductoOrigen & "'")
            End With

            Me.Execute(myQuery.ToString())
            Me.Sincroniza_I(myQuery.ToString(), arrTablas(Cont, 0))
         End If

      Next

   End Sub

   Public Function GetOrdenProductos(activos As Boolean?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("SELECT Orden")
         .AppendFormatLine("  FROM Productos")
         .AppendFormatLine(" WHERE 1 = 1")
         If activos.HasValue Then
            .AppendFormatLine("   AND Activo = '{0}'", activos.Value)
         End If
         .AppendFormatLine(" GROUP BY Orden")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Productos_G1_LivianoParaImportarProducto(idProducto As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT P.IdProducto")
         .AppendLine("     , P.NombreProducto")
         .AppendLine("     , P.Alicuota")
         .AppendLine("     , P.PrecioPorEmbalaje")
         .AppendLine("     , P.Embalaje")
         .AppendLine("     , P.EsOferta")
         .AppendLine("     , P.IdMarca")
         .AppendLine("     , P.IdRubro")
         .AppendLine("     , P.IdMoneda")
         .AppendLine("     , Mo.NombreMoneda")
         .AppendLine("     , P.IdProveedor")
         .AppendLine("     , PP.DescuentoRecargoPorc1")
         .AppendLine("     , PP.DescuentoRecargoPorc2")
         .AppendLine("     , PP.DescuentoRecargoPorc3")
         .AppendLine("     , PP.DescuentoRecargoPorc4")
         .AppendLine("     , P.AfectaStock")
         .AppendLine("     , P.Lote")
         .AppendLine("     , P.NroSerie")
         .AppendLine("     , P.Activo")
         .AppendLine("     , PS.IdSucursal IdSucursalDefecto")
         .AppendLine("     , PS.IdDepositoDefecto")
         .AppendLine("     , PS.IdUbicacionDefecto")
         .AppendLine("     , SD.CodigoDeposito CodigoDepositoDefecto")
         .AppendLine("     , SD.NombreDeposito NombreDepositoDefecto")
         .AppendLine("     , SU.CodigoUbicacion CodigoUbicacionDefecto")
         .AppendLine("     , SU.NombreUbicacion NombreUbicacionDefecto")
         .AppendLine("     , P.InformeControlCalidad")
         .AppendLine("     , P.IdUnidadDeMedidaProduccion")
         .AppendLine("     , P.FactorConversionProduccion")
         .AppendLine("     , P.IdUnidadDeMedidaCompra")
         .AppendLine("     , P.FactorConversionCompra")
         .AppendLine("     , P.ComisionPorVenta")
         .AppendLine("  FROM Productos P")
         .AppendLine("  LEFT JOIN Monedas Mo ON Mo.IdMoneda = P.IdMoneda")
         .AppendLine("  LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto AND PP.IdProveedor = P.IdProveedor")
         .AppendFormatLine("  LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = {0}", actual.Sucursal.Id)
         .AppendFormatLine("  LEFT JOIN SucursalesDepositos SD ON SD.IdSucursal = PS.IdSucursal AND SD.IdDeposito = PS.IdDepositoDefecto")
         .AppendFormatLine("  LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PS.IdSucursal AND SU.IdDeposito = PS.IdDepositoDefecto AND SU.IdUbicacion = PS.IdUbicacionDefecto")
         .AppendFormatLine(" WHERE P.IdProducto = '{0}' ", idProducto)
         .AppendLine(" ORDER BY P.NombreProducto  ")
      End With

      Return GetDataTable(myQuery)
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
                                          strAnchoIdProducto As Integer,
                                          atributo As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT S.IdSucursal	  ")
         .AppendLine("		,S.Nombre NombreSucursal	  ")
         .AppendFormat("		,RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto", strAnchoIdProducto)
         .AppendLine("		,P.IdProducto IdProductoParaComparar")
         .AppendLine("		,P.NombreProducto      ")
         .AppendLine("	   ,P.NombreCorto")
         .AppendLine("		,P.Tamano	  ")
         .AppendLine("		,P.IdMarca	  ")
         .AppendLine("		,M.NombreMarca      ")
         .AppendLine("		,P.IdRubro	  ")
         .AppendLine("		,R.NombreRubro      ")
         .AppendLine("		,P.IdUnidadDeMedida      ")
         .AppendLine("		,P.Alicuota")
         .AppendLine("		,Mo.Simbolo")
         .AppendLine("		,PS.PrecioFabrica      ")
         .AppendLine("		,PS.PrecioCosto      ")
         .AppendLine("		,PSP.PrecioVenta ")
         .AppendLine("		,PS.FechaActualizacion")

         If listas IsNot Nothing Then
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormat("		,(CASE WHEN PS.PrecioCosto>0 THEN round((L.[{0}]/PS.PrecioCosto-1) * 100,4) ELSE 0 END) AS Porc" & lis.IdListaPrecios, lis.NombreListaPrecios)
               .AppendFormat("		,L.[{0}]", lis.NombreListaPrecios)
            Next
         End If
         '-- REQ-35260.- -----------------------------------------------------------------------------
         If atributo Then
            .AppendLine("		,PSA.Stock")
            .AppendLine("     ,PSA.Stock AS NuevoStock")
         Else
            .AppendLine("		,PS.Stock")
            .AppendLine("     ,PS.Stock AS NuevoStock") '' CONVERT(DECIMAL(12,2), 0) AS NuevoStock")
         End If
         '--------------------------------------------------------------------------------------------
         .AppendLine("		,P.EsCompuesto")
         .AppendLine("     ,PS.Ubicacion")
         .AppendLine("     ,PS.Ubicacion AS NuevaUbicacion") '' AS NuevaUbicacion")

         .AppendLine("		,PS.StockMinimo")
         .AppendLine("     ,PS.StockMinimo AS NuevoStockMinimo")
         .AppendLine("		,PS.PuntoDePedido")
         .AppendLine("     ,PS.PuntoDePedido AS NuevoPuntoDePedido")
         .AppendLine("		,PS.StockMaximo")
         .AppendLine("     ,PS.StockMaximo AS NuevoStockMaximo")

         '-- REQ-35260.- -----------------------------------------------------------------------------
         If atributo Then
            .AppendLine("	 ,ISNULL(PSA.IdaAtributo01, 0) IdaAtributo01")
            .AppendLine("	 ,ATP1.Descripcion DescripcionAtributo01")
            .AppendLine("	 ,ISNULL(PSA.IdaAtributo02, 0) IdaAtributo02")
            .AppendLine("	 ,ATP2.Descripcion DescripcionAtributo02")
         End If
         '--------------------------------------------------------------------------------------------

         .AppendLine(",( SELECT TOP 1 PR.NombreProveedor  FROM ProductosProveedores PP")
         .AppendLine("   INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor ")
         .AppendLine("   WHERE PP.IdProducto = P.IdProducto ")
         .AppendLine("   ORDER BY PP.UltimaFechaCompra desc) as UltimoProv")

         .AppendLine(" FROM Productos P	")
         .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto	")
         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = P.IdProducto")
         .AppendLine("                                          AND PSP.IdSucursal = PS.IdSucursal")
         .AppendLine("                                          AND PSP.IdListaPrecios = " + idListaPrecios.ToString())

         '-- REQ-35260.- -----------------------------------------------------------------------------
         If atributo Then
            .AppendLine("	LEFT JOIN ProductosSucursalesAtributos PSA ON PSA.IdProducto = P.IdProducto and PSA.IdSucursal = PS.IdSucursal")
            .AppendLine("	LEFT JOIN AtributosProductos ATP1 ON ATP1.IdaAtributoProducto = PSA.IdaAtributo01 ")
            .AppendLine("	LEFT JOIN AtributosProductos ATP2 ON ATP2.IdaAtributoProducto = PSA.IdaAtributo02 ")
         End If
         '--------------------------------------------------------------------------------------------

         .AppendLine("	LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal	")
         .AppendLine("	LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca	")
         .AppendLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro	")
         .AppendLine("	LEFT JOIN SubRubros SR ON SR.IdRubro = p.IdRubro AND SR.IdSubRubro = P.IdSubRubro  ")
         If listas IsNot Nothing AndAlso listas.Count > 0 Then
            .Append("	LEFT JOIN (SELECT IdProducto, IdSucursal,")
            For Each lis As Entidades.ListaDePrecios In listas
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
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormat("[{0}],", lis.IdListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
            .AppendLine(") as p) AS L ON L.IdProducto = P.IdProducto and L.IdSucursal = PS.IdSucursal")
         End If

         If idProveedor <> 0 Then
            .AppendLine("	LEFT JOIN ProductosProveedores PP ON P.IdProducto = PP.IdProducto")
            .AppendLine("	LEFT JOIN Proveedores PV ON PV.IdProveedor = PP.IdProveedor")
         End If

         .AppendLine("	WHERE PS.IdSucursal in (0")
         For Each suc As Integer In sucursales
            If Integer.Parse(suc.ToString()) <> 0 Then
               .AppendLine("," & suc.ToString())
            End If
         Next
         .AppendLine(") ")
         .AppendLine("	AND P.Activo = 'True'")   'Solo permito elegir los productos Activos

         '# Excluyo los productos con Lote
         .AppendLine(" AND P.Lote = 'False' ")

         '# Excluyo los productos con Nro. Serie
         .AppendLine(" AND P.NroSerie = 'False' ")

         If marcas.Count > 0 Then
            .Append(" AND P.IdMarca IN (")
            For Each pr As Entidades.Marca In marcas
               .AppendFormat(" {0},", pr.IdMarca)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If rubros.Count > 0 Then
            .Append(" AND P.IdRubro IN (")
            For Each pr As Entidades.Rubro In rubros
               .AppendFormat(" {0},", pr.IdRubro)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If idSubRubro <> 0 Then
            .AppendLine("	AND P.IdSubRubro = " & idSubRubro.ToString())
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND P.IdProducto = '" & idProducto & "'")
         End If

         If idProveedor <> 0 Then
            .AppendLine("	AND PV.IdProveedor = " & idProveedor.ToString())
         End If

         If sinCosto Then
            .AppendLine("	AND PS.PrecioCosto = 0")
         End If

         If sinVenta Then
            .AppendLine("	AND PSP.PrecioVenta = 0")
         End If

         If compuestos <> "TODOS" Then
            .AppendLine("      AND P.EsCompuesto = " & IIf(compuestos = "SI", "1", "0").ToString())
         End If

         If conStock = "SI" Then
            .AppendLine("      AND PS.Stock > 0")
         End If

         If conStock = "NO" Then
            .AppendLine("      AND PS.Stock <= 0")
         End If

         'Por ahora filtra de la lista BASE, pero deberia ser dinamico.
         If fechaActualizadoDesde.Year > 1 Then
            .AppendLine("	 AND PS.FechaActualizacion >= '" & fechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND PS.FechaActualizacion <= '" & fechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
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
         Else
            If Not String.IsNullOrEmpty(codigoProducto) Then
               .AppendLine("	AND P.IdProducto LIKE '%" & codigoProducto & "%'")
            End If

         End If
         '-- REQ-35260.- -----------------------------------------------------------------------------
         If atributo Then
            .AppendLine("	AND (PSA.IdaAtributo01 IS NOT NULL OR PSA.IdaAtributo02 IS NOT NULL) ")
         End If
         '--------------------------------------------------------------------------------------------
         .AppendLine("	 AND ((CASE WHEN TipoAtributo01 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN GrupoAtributo01 IS NULL THEN 0 ELSE 1 END)")
         .AppendLine("	 + (CASE WHEN TipoAtributo02 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN GrupoAtributo02 IS NULL THEN 0 ELSE 1 END)")
         .AppendLine("	 + (CASE WHEN TipoAtributo03 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN GrupoAtributo03 IS NULL THEN 0 ELSE 1 END)")
         .AppendLine("	 + (CASE WHEN TipoAtributo04 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN GrupoAtributo04 IS NULL THEN 0 ELSE 1 END)")
         '-- REQ-35260.- -----------------------------------------------------------------------------
         If atributo Then
            .AppendLine("	 ) > 0")
         Else
            .AppendLine("	 ) = 0")
         End If
         '--------------------------------------------------------------------------------------------
         .AppendLine("	ORDER BY P.NombreProducto")

      End With

      Dim dt As DataTable = GetDataTable(stb.ToString())

      If atributo Then
         dt.PrimaryKey = {dt.Columns("IdProductoParaComparar"), dt.Columns("IdSucursal"), dt.Columns("IdaAtributo01"), dt.Columns("IdaAtributo02")}
      Else
         dt.PrimaryKey = {dt.Columns("IdProductoParaComparar"), dt.Columns("IdSucursal")}
      End If


      Return dt
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
                                          strAnchoIdProducto As Integer,
                                          atributo As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT S.IdSucursal	  ")
         .AppendLine("		,S.Nombre NombreSucursal	  ")
         .AppendFormat("		,RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto", strAnchoIdProducto)
         .AppendLine("		,P.IdProducto IdProductoParaComparar")
         .AppendLine("		,P.NombreProducto      ")
         .AppendLine("	   ,P.NombreCorto")
         .AppendLine("		,P.Tamano	  ")
         .AppendLine("		,P.IdMarca	  ")
         .AppendLine("		,M.NombreMarca      ")
         .AppendLine("		,P.IdRubro	  ")
         .AppendLine("		,R.NombreRubro      ")
         .AppendLine("		,P.IdUnidadDeMedida      ")
         .AppendLine("		,P.Alicuota")
         .AppendLine("		,Mo.Simbolo")
         .AppendLine("		,PS.PrecioFabrica      ")
         .AppendLine("		,PS.PrecioCosto      ")
         .AppendLine("		,PSP.PrecioVenta ")
         .AppendLine("		,PS.FechaActualizacion")

         If listas IsNot Nothing Then
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormat("		,(CASE WHEN PS.PrecioCosto>0 THEN round((L.[{0}]/PS.PrecioCosto-1) * 100,4) ELSE 0 END) AS Porc" & lis.IdListaPrecios, lis.NombreListaPrecios)
               .AppendFormat("		,L.[{0}]", lis.NombreListaPrecios)
            Next
         End If
         '-- REQ-35260.- -----------------------------------------------------------------------------
         If atributo Then
            .AppendLine("		,PSA.Stock")
            .AppendLine("     ,PSA.Stock AS NuevoStock")
         Else
            .AppendLine("		,CASE WHEN PU.stock IS NULL AND PD.Stock IS NULL THEN PS.Stock ELSE CASE WHEN PU.stock IS NULL AND PD.Stock IS NOT NULL THEN 0 ELSE PU.stock END END AS Stock ")
            .AppendLine("     ,CASE WHEN PU.stock IS NULL AND PD.Stock IS NULL THEN PS.Stock ELSE CASE WHEN PU.stock IS NULL AND PD.Stock IS NOT NULL THEN 0 ELSE PU.stock END END AS NuevoStock") '' CONVERT(DECIMAL(12,2), 0) AS NuevoStock")
         End If
         '--------------------------------------------------------------------------------------------
         .AppendLine("		,P.EsCompuesto")
         .AppendLine("		,PS.StockMinimo")
         .AppendLine("		,PS.PuntoDePedido")
         .AppendLine("		,PS.StockMaximo")
         '--------------------------------------------------------------------------------------------
         .AppendLine("     ,SD.IdDeposito ")
         .AppendLine("     ,CASE WHEN PU.IdUbicacion IS NULL THEN 1 ELSE PU.IDUbicacion END AS IdUbicacion")
         .AppendLine("     ,SU.NombreUbicacion AS NombreUbicacion")
         .AppendLine("     ,CASE WHEN PU.IdUbicacion IS NULL THEN 1 ELSE PU.IDUbicacion END AS NuevoIdUbicacion")
         .AppendLine("     ,SU.NombreUbicacion AS NuevoNombreUbicacion")

         '-- REQ-35260.- -----------------------------------------------------------------------------
         If atributo Then
            .AppendLine("	 ,ISNULL(PSA.IdaAtributo01, 0) IdaAtributo01")
            .AppendLine("	 ,ATP1.Descripcion DescripcionAtributo01")
            .AppendLine("	 ,ISNULL(PSA.IdaAtributo02, 0) IdaAtributo02")
            .AppendLine("	 ,ATP2.Descripcion DescripcionAtributo02")
         End If
         '--------------------------------------------------------------------------------------------

         .AppendLine(",( SELECT TOP 1 PR.NombreProveedor  FROM ProductosProveedores PP")
         .AppendLine("   INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor ")
         .AppendLine("   WHERE PP.IdProducto = P.IdProducto ")
         .AppendLine("   ORDER BY PP.UltimaFechaCompra desc) as UltimoProv")

         .AppendLine(" FROM Productos P	")
         .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto	")
         '--------------------------------------------------------------------------------------------
         .AppendLine("  LEFT JOIN SucursalesDepositos SD ON SD.IdSucursal = PS.IdSucursal")
         .AppendLine("  LEFT JOIN ProductosDepositos PD ON PD.IdProducto = PS.IdProducto")
         .AppendLine("  							          AND PD.IdSucursal = PS.IdSucursal ")

         .AppendLine("  LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PS.IdSucursal")
         .AppendLine("   								AND SU.IdDeposito = PD.IdDeposito")
         .AppendLine("  LEFT JOIN ProductosUbicaciones PU ON PU.IdProducto = PS.IdProducto")
         .AppendLine("  								AND  PU.IdSucursal = PS.IdSucursal")
         .AppendLine("  								AND  PU.IdDeposito = PD.IdDeposito")
         .AppendLine("  								AND  PU.IdUbicacion = SU.IdUbicacion")

         '--------------------------------------------------------------------------------------------
         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = P.IdProducto")
         .AppendLine("                                          AND PSP.IdSucursal = PS.IdSucursal")
         .AppendLine("                                          AND PSP.IdListaPrecios = " + idListaPrecios.ToString())

         '-- REQ-35260.- -----------------------------------------------------------------------------
         If atributo Then
            .AppendLine("	LEFT JOIN ProductosSucursalesAtributos PSA ON PSA.IdProducto = P.IdProducto and PSA.IdSucursal = PS.IdSucursal")
            .AppendLine("	LEFT JOIN AtributosProductos ATP1 ON ATP1.IdaAtributoProducto = PSA.IdaAtributo01 ")
            .AppendLine("	LEFT JOIN AtributosProductos ATP2 ON ATP2.IdaAtributoProducto = PSA.IdaAtributo02 ")
         End If
         '--------------------------------------------------------------------------------------------

         .AppendLine("	LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal	")
         .AppendLine("	LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca	")
         .AppendLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro	")
         .AppendLine("	LEFT JOIN SubRubros SR ON SR.IdRubro = p.IdRubro AND SR.IdSubRubro = P.IdSubRubro  ")
         If listas IsNot Nothing AndAlso listas.Count > 0 Then
            .Append("	LEFT JOIN (SELECT IdProducto, IdSucursal,")
            For Each lis As Entidades.ListaDePrecios In listas
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
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormat("[{0}],", lis.IdListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
            .AppendLine(") as p) AS L ON L.IdProducto = P.IdProducto and L.IdSucursal = PS.IdSucursal")
         End If

         If idProveedor <> 0 Then
            .AppendLine("	LEFT JOIN ProductosProveedores PP ON P.IdProducto = PP.IdProducto")
            .AppendLine("	LEFT JOIN Proveedores PV ON PV.IdProveedor = PP.IdProveedor")
         End If

         .AppendFormatLine("	WHERE PS.IdSucursal = {0}", sucursales)
         'For Each suc As Integer In sucursales
         '   If Integer.Parse(suc.ToString()) <> 0 Then
         '      .AppendLine("," & suc.ToString())
         '   End If
         'Next
         '.AppendLine(") ")
         '-- Filtra Deposito.- --------------------------------------------------------------
         .AppendFormatLine(" AND SD.IdDeposito = {0} ", deposito)
         '-----------------------------------------------------------------------------------
         .AppendLine("	AND P.Activo = 'True'")   'Solo permito elegir los productos Activos

         '# Excluyo los productos con Lote
         .AppendLine(" AND P.Lote = 'False' ")

         '# Excluyo los productos con Nro. Serie
         .AppendLine(" AND P.NroSerie = 'False' ")

         'If marcas.Count > 0 Then
         '   .Append(" AND P.IdMarca IN (")
         '   For Each pr As Entidades.Marca In marcas
         '      .AppendFormat(" {0},", pr.IdMarca)
         '   Next
         '   .Remove(.Length - 1, 1)
         '   .Append(")")
         'End If

         'If rubros.Count > 0 Then
         '   .Append(" AND P.IdRubro IN (")
         '   For Each pr As Entidades.Rubro In rubros
         '      .AppendFormat(" {0},", pr.IdRubro)
         '   Next
         '   .Remove(.Length - 1, 1)
         '   .Append(")")
         'End If

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaRubrosMultiples(stb, rubros, "P")

         If idSubRubro <> 0 Then
            .AppendLine("	AND P.IdSubRubro = " & idSubRubro.ToString())
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND P.IdProducto = '" & idProducto & "'")
         End If

         If idProveedor <> 0 Then
            .AppendLine("	AND PV.IdProveedor = " & idProveedor.ToString())
         End If

         If sinCosto Then
            .AppendLine("	AND PS.PrecioCosto = 0")
         End If

         If sinVenta Then
            .AppendLine("	AND PSP.PrecioVenta = 0")
         End If

         If compuestos <> "TODOS" Then
            .AppendLine("      AND P.EsCompuesto = " & IIf(compuestos = "SI", "1", "0").ToString())
         End If

         '.AppendLine("      AND ((PU.Stock <> 0) OR (PU.Stock = 0 AND PU.IdDeposito = PS.IdDepositoDefecto AND PU.IdUbicacion = PS.IdUbicacionDefecto))")

         'Por ahora filtra de la lista BASE, pero deberia ser dinamico.
         If fechaActualizadoDesde.Year > 1 Then
            .AppendLine("	 AND PS.FechaActualizacion >= '" & fechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND PS.FechaActualizacion <= '" & fechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
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
         Else
            If Not String.IsNullOrEmpty(codigoProducto) Then
               .AppendLine("	AND P.IdProducto LIKE '%" & codigoProducto & "%'")
            End If

         End If
         '-- REQ-35260.- -----------------------------------------------------------------------------
         If atributo Then
            .AppendLine("	AND (PSA.IdaAtributo01 IS NOT NULL OR PSA.IdaAtributo02 IS NOT NULL) ")
         End If
         '--------------------------------------------------------------------------------------------
         .AppendLine("	 AND ((CASE WHEN TipoAtributo01 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN GrupoAtributo01 IS NULL THEN 0 ELSE 1 END)")
         .AppendLine("	 + (CASE WHEN TipoAtributo02 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN GrupoAtributo02 IS NULL THEN 0 ELSE 1 END)")
         .AppendLine("	 + (CASE WHEN TipoAtributo03 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN GrupoAtributo03 IS NULL THEN 0 ELSE 1 END)")
         .AppendLine("	 + (CASE WHEN TipoAtributo04 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN GrupoAtributo04 IS NULL THEN 0 ELSE 1 END)")
         '-- REQ-35260.- -----------------------------------------------------------------------------
         If atributo Then
            .AppendLine("	 ) > 0")
         Else
            .AppendLine("	 ) = 0")
         End If
         '--------------------------------------------------------------------------------------------
         .AppendLine("	ORDER BY P.NombreProducto")

      End With

      Return GetDataTable(stb.ToString())
   End Function

End Class