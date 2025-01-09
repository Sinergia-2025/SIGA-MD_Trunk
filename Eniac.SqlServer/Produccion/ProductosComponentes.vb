Imports Eniac.Entidades

Public Class ProductosComponentes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosComponentes_I(idProducto As String, idFormula As Integer, idProductoComponente As String, idFormulaComponente As Integer,
                                     cantidad As Decimal,
                                     segunCalculoForma As Boolean,
                                     idUnidadDeMedidaProduccion As String, cantidadUMProduccion As Decimal, factorConversionProduccion As Decimal)
      'descuentaAlFacturar As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ProductosComponentes (")
         .AppendFormatLine("     IdProducto")
         .AppendFormatLine("   , IdFormula")
         .AppendFormatLine("   , IdProductoComponente")
         .AppendFormatLine("   , IdFormulaComponente")
         .AppendFormatLine("   , Cantidad")
         .AppendFormatLine("   , SegunCalculoForma")
         .AppendFormatLine("   , IdUnidadDeMedidaProduccion")
         .AppendFormatLine("   , CantidadUMProduccion")
         .AppendFormatLine("   , FactorConversionProduccion")
         .AppendFormatLine("   ) VALUES ( ")
         .AppendFormatLine("     '{0}'", idProducto)
         .AppendFormatLine("   ,  {0} ", idFormula)
         .AppendFormatLine("   , '{0}'", idProductoComponente)
         If idFormula <> 0 Then
            .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idFormulaComponente))
         Else
            .AppendFormatLine("   , NULL")
         End If
         .AppendFormatLine("   ,  {0} ", cantidad)
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(segunCalculoForma))
         .AppendFormatLine("   , '{0}'", idUnidadDeMedidaProduccion)
         .AppendFormatLine("   ,  {0} ", cantidadUMProduccion)
         .AppendFormatLine("   ,  {0} ", factorConversionProduccion)
         .AppendFormatLine("   )")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosComponentes")
   End Sub
   Public Sub ProductosComponentes_U_FormulaComponenteDelProducto(idProducto As String, idFormula As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PC")
         .AppendFormatLine("   SET IdFormulaComponente =  {0} ", GetStringFromNumber(idFormula))
         .AppendFormatLine("  FROM ProductosComponentes PC")
         .AppendFormatLine(" WHERE PC.IdProductoComponente = '{0}'", idProducto.Trim())
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosComponentes")
   End Sub

   Public Sub ProductosComponentes_D(idProducto As String, idFormula As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM ProductosComponentes ")
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)

         If idFormula <> 0 Then
            .AppendFormatLine(" AND IdFormula = {0}", idFormula)
         End If
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosComponentes")
   End Sub

   Public Function GetComponentes(idSucursal As Integer, idProducto As String, idFormula As Integer, idListaDePrecios As Integer,
                                  blnPreciosConIVA As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT PC.*")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,P.IdUnidadDeMedida")
         .AppendLine("      ,PS.PrecioCosto")

         If blnPreciosConIVA Then
            .AppendFormatLine("      ,ROUND({0}, 2) AS PrecioCostoSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("PS.PrecioCosto", "P"))
            .AppendFormatLine("      ,PS.PrecioCosto AS PrecioCostoConIVA")
         Else
            .AppendFormatLine("      ,PS.PrecioCosto AS PrecioCostoSinIVA")
            .AppendFormatLine("      ,ROUND({0}, 2) AS PrecioCostoConIVA", CalculosImpositivos.ObtenerPrecioConImpuestos("PS.PrecioCosto", "P"))
         End If

         .AppendLine("      ,P.IdMoneda")
         .AppendLine("      ,PSP.PrecioVenta")

         If blnPreciosConIVA Then
            .AppendFormatLine("      ,ROUND({0}, 2) AS PrecioVentaSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("PS.PrecioCosto", "P"))
            .AppendFormatLine("      ,PSP.PrecioVenta AS PrecioVentaConIVA")
         Else
            .AppendFormatLine("      ,PSP.PrecioVenta AS PrecioVentaSinIVA")
            .AppendFormatLine("      ,ROUND({0}, 2) AS PrecioVentaConIVA", CalculosImpositivos.ObtenerPrecioConImpuestos("PS.PrecioCosto", "P"))
         End If

         .AppendLine("      ,Mo.NombreMoneda")
         .AppendLine("      ,Mo.FactorConversion")
         .AppendLine("      ,Mo.Simbolo")
         .AppendLine("      ,P.Tamano")
         .AppendLine("      ,CONVERT(DECIMAL(10,2), 0) as CostoLinea")
         .AppendLine("      ,CONVERT(DECIMAL(10,2), 0) as CostoLineaDolar")
         .AppendLine("      ,P.IdProduccionForma")
         .AppendLine("      ,PF.FormulaCalculoKilaje")
         .AppendLine("      ,CONVERT(BIT, 0) ComponenteAgregado")
         .AppendLine("      ,P.Lote       ComponenteUsaLote")
         .AppendLine("      ,P.NroSerie   ComponenteUsaNroSerie")
         '-- REQ-38131.- -----------------------------------------------------------------------------------------------------------------------------------------------
         .AppendLine("      ,ISNULL((PS.PrecioCosto * PC.Cantidad) / NULLIF(PCT.ImporteTotalCosto, 0) * 100, 0) PorcCostoProduccion")
         '--------------------------------------------------------------------------------------------------------------------------------------------------------------
         .AppendLine("      ,PS.IdSucursal")
         .AppendLine("      ,PS.IdDepositoDefecto")
         .AppendLine("      ,PS.IdUbicacionDefecto")

         .AppendLine("      ,PFC.NombreFormula NombreFormulaComponente")
         .AppendLine("      ,P.EsCompuesto ComponenteEsCompuesto")
         .AppendLine("      ,P.Lote ProductoConLote")
         .AppendLine("      ,P.NroSerie ProductoConNroSerie")
         .AppendLine("      ,PS.IdDepositoDefecto")
         .AppendLine("      ,SD.NombreDeposito NombreDepositoDefecto")
         .AppendLine("      ,PS.IdUbicacionDefecto")
         .AppendLine("      ,SU.NombreUbicacion NombreUbicacionDefecto")

         .AppendLine(" FROM ProductosComponentes PC ")
         .AppendLine(" LEFT JOIN Productos P ON P.IdProducto = PC.IdProductoComponente")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto")
         .AppendFormatLine(" LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal AND PSP.IdListaPrecios = {0}", idListaDePrecios)
         .AppendLine(" LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
         .AppendLine(" LEFT JOIN ProduccionFormas PF ON PF.IdProduccionForma = P.IdProduccionForma")
         .AppendLine(" LEFT JOIN ProductosFormulas PFC ON PFC.IdProducto = PC.IdProductoComponente AND PFC.IdFormula = PC.IdFormulaComponente")
         .AppendFormatLine(" LEFT JOIN SucursalesDepositos SD ON SD.IdSucursal = PS.IdSucursal AND SD.IdDeposito = PS.IdDepositoDefecto")
         .AppendFormatLine(" LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PS.IdSucursal AND SU.IdDeposito = PS.IdDepositoDefecto AND SU.IdUbicacion = PS.IdUbicacionDefecto")

         .AppendFormatLine(" INNER JOIN (SELECT PC.IdProducto, PC.IdFormula, SUM(PS.PrecioCosto * Cantidad) AS ImporteTotalCosto")
         .AppendFormatLine("              FROM ProductosComponentes PC")
         .AppendFormatLine("             CROSS JOIN (SELECT * FROM Sucursales WHERE SoyLaCentral = 1) S")
         .AppendFormatLine("             INNER JOIN ProductosSucursales PS ON PS.IdSucursal = S.IdSucursal AND PS.IdProducto = PC.IdProductoComponente")
         .AppendFormatLine("             GROUP BY PC.IdProducto, PC.IdFormula) PCT ON PCT.IdProducto = PC.IdProducto AND PCT.IdFormula = PC.IdFormula")

         .AppendFormatLine(" WHERE PS.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PC.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND PC.IdFormula = {0}", idFormula)
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function GetComponentesProduccion(productos As DataTable, sucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PC.*,")
         .AppendLine(" P.NOMBREPRODUCTO NOMBREPRODUCTO1,")
         .AppendLine(" P.NOMBREPRODUCTO,")
         .AppendLine(" PS.Stock,")
         .AppendLine(" PC.CANTIDAD NECESITOX1 ")
         .AppendLine(",P.IdProduccionForma")
         .AppendLine(",PRF.FormulaCalculoKilaje")

         .AppendLine(",PS.IdDepositoDefecto")
         .AppendLine(",PS.IdUbicacionDefecto")

         .AppendLine(" FROM ProductosFormulas PF")
         .AppendLine(" INNER JOIN ProductosComponentes PC ON PC.IdProducto = PF.IdProducto AND PC.IdFormula = PF.IdFormula ")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = PC.IdProductoComponente ")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PC.IdProductoComponente ")
         .AppendLine(" AND PS.IdSucursal = " & sucursal)
         .AppendLine("  LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = P.IdProduccionForma")
         .Append("WHERE PC.IdProducto IN (")
         For Each prod As DataRow In productos.Rows
            .AppendFormat(" '{0}',", prod("IdProducto").ToString())
         Next
         .Remove(.Length - 1, 1)
         .Append(")")
         .Append("AND PF.IdFormula IN (")
         For Each prod As DataRow In productos.Rows
            .AppendFormat(" '{0}',", prod("IdFormula").ToString())
         Next
         .Remove(.Length - 1, 1)
         .Append(")")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPorProductoComponente(idSucursal As Integer, idProducto As String, idListaDePrecios As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT PC.*")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,P.IdUnidadDeMedida")
         .AppendLine("      ,P.IdMoneda")
         .AppendLine("      ,PS.PrecioCosto")
         .AppendLine("      ,PSP.PrecioVenta")
         .AppendLine(" FROM ProductosComponentes PC ")
         .AppendLine(" LEFT JOIN Productos P ON P.IdProducto = PC.IdProductoComponente")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto")
         .AppendLine(" LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal AND PSP.IdListaPrecios = " & idListaDePrecios.ToString())
         .AppendFormatLine(" WHERE PS.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PC.IdProductoComponente = '{0}'", idProducto)
      End With
      Return GetDataTable(myQuery)
   End Function

#Region "Turismo"
   Public Function GetProductosComponente2(IdProducto As String, IdRubroPrograma As Integer, IdRubroVisita As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT N1.IdProducto, P0.NombreProducto ")
         .AppendLine(" , N1.IdProductoComponente AS IdVisita, P1.NombreProducto AS Visita")
         .AppendLine(" , N2.IdProductoComponente AS IdActividad, P2.NombreProducto AS Actividad , N1.IdFormula")
         .AppendLine(" FROM ProductosComponentes N1 ")
         .AppendLine(" INNER JOIN Productos P0 ON P0.IdProducto = N1.IdProducto ")
         .AppendLine(" LEFT JOIN ProductosComponentes N2 ON N2.IdProducto = N1.IdProductoComponente ")
         .AppendLine(" LEFT JOIN Productos P1 ON P1.IdProducto = N1.IdProductoComponente ")
         .AppendLine(" LEFT JOIN Productos P2 ON P2.IdProducto = N2.IdProductoComponente ")

         .AppendLine(" WHERE  P0.IdRubro = " & IdRubroPrograma)
         .AppendLine(" AND P1.IdRubro = " & IdRubroVisita)
         .AppendLine(" AND N1.IdProducto = '" & IdProducto & "'")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function GetProductosComponenteGastronomico(IdProducto As String, IdRubroGastronomico As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT N1.IdProducto, P0.NombreProducto, R.NombreRubro, SR.NombreSubRubro ")
         .AppendLine(" , N1.IdProductoComponente AS IdGastro, P1.NombreProducto AS Gastronomico")
         '.AppendLine(" , N2.IdProductoComponente AS IdLugar, P2.NombreProducto AS Lugar
         .AppendLine(" , N1.IdFormula")
         .AppendLine(" FROM ProductosComponentes N1 ")
         .AppendLine(" INNER JOIN Productos P0 ON P0.IdProducto = N1.IdProducto ")
         .AppendLine(" LEFT JOIN ProductosComponentes N2 ON N2.IdProducto = N1.IdProductoComponente ")
         .AppendLine(" LEFT JOIN Productos P1 ON P1.IdProducto = N1.IdProductoComponente ")
         .AppendLine("LEFT JOIN Rubros R ON R.IdRubro = P1.IdRubro ")
         .AppendLine(" LEFT JOIN Subrubros SR ON SR.IdRubro = P1.IdRubro AND SR.IdSubRubro = P1.IdSubRubro")
         '   .AppendLine(" LEFT JOIN Productos P2 ON P2.IdProducto = N2.IdProductoComponente ")

         .AppendLine(" WHERE  P1.IdRubro = " & IdRubroGastronomico)
         .AppendLine(" AND N1.IdProducto = '" & IdProducto & "'")
      End With
      Return GetDataTable(myQuery)
   End Function
#End Region

   Public Function GetInforme(idSucursal As Integer, idProducto As String, idFormula As Integer, idListaDePrecios As Integer,
                              IdProductoComponente As String, EsProducto As Boolean, marcas As Entidades.Marca(), rubros As Entidades.Rubro()) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT PC.*")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,PF.NombreFormula")
         .AppendLine("      ,P2.NombreProducto AS NombreComponente")
         .AppendLine("      	  ,M.NombreMarca
	                             ,M2.NombreMarca AS NombreMarcaComponente
	                             ,R.NombreRubro
	                             ,R2.NombreRubro AS NombreRubroComponente")
         .AppendLine(" FROM ProductosComponentes PC ")
         .AppendLine(" INNER JOIN ProductosFormulas PF ON PF.IdProducto = PC.IdProducto AND PF.IdFormula = PC.IdFormula")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = PC.IdProducto")
         .AppendLine(" INNER JOIN Productos P2 ON P2.IdProducto = PC.IdProductoComponente")
         .AppendLine(" LEFT JOIN Marcas M on M.IdMarca = P.IdMarca
                       LEFT JOIN Marcas M2 on M2.IdMarca = P2.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R on R.IdRubro = P.IdRubro
                       LEFT JOIN Rubros R2 on R2.IdRubro = P2.IdRubro")
         .AppendLine(" WHERE 1 = 1")

         GetListaMarcasMultiples(myQuery, marcas, IIf(EsProducto, "P", "P2").ToString())
         GetListaRubrosMultiples(myQuery, rubros, IIf(EsProducto, "P", "P2").ToString())

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("   AND PC.IdProducto = '{0}'", idProducto)
         End If
         If Not String.IsNullOrEmpty(IdProductoComponente) Then
            .AppendFormatLine("   AND PC.IdProductoComponente = '{0}'", IdProductoComponente)
         End If
         If idFormula > 0 Then
            .AppendFormatLine("   AND PC.IdFormula = {0}", idFormula)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PC.*")
         .AppendFormatLine("  FROM {0} PC", Entidades.ProductoComponente.NombreTabla)

         ' JOINS
         .AppendLine("INNER JOIN Productos P ON PC.IdProducto = P.IdProducto ")
      End With
   End Sub

   Public Function ProductosComponentes_GA(fechaActualizacionDesde As Date?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As DataTable
      Return ProductosComponentes_G(fechaActualizacionDesde:=fechaActualizacionDesde, publicarEn:=publicarEn)
   End Function

   Private Function ProductosComponentes_G(fechaActualizacionDesde As Date?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As DataTable
      Dim query = New StringBuilder()
      SelectTexto(query)
      With query

         If fechaActualizacionDesde.HasValue Then
            .AppendFormatLine(" AND P.{0} > '{1}'",
                              Entidades.Producto.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True))
         End If
         ProductoPublicarEn(query, publicarEn, "P")
         'If publicarEn <> Entidades.Publicos.SiNoTodos.TODOS Then
         '   .AppendFormat("   AND P.{0} = {1}",
         '                   Entidades.Producto.Columnas.PublicarEnWeb.ToString(), GetStringFromBoolean(publicarEn = Entidades.Publicos.SiNoTodos.SI)).AppendLine()
         'End If

      End With
      Return GetDataTable(query)
   End Function

   Public Function GetParaSincronizacionMovil(idRubro As Integer, activo As Boolean?, publicarEnWeb As Boolean?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT P.IdProducto  AS IdPrograma,  P.NombreProducto  AS NombrePrograma, PCP.IdFormula")
         .AppendFormatLine("     , PV.IdProducto AS IdVisita,    PV.NombreProducto AS NombreVisita")
         .AppendFormatLine("     , PVSR.IdSubRubro, PVSR.NombreSubRubro")
         .AppendFormatLine("     , PA.IdProducto AS IdActividad, PA.NombreProducto AS NombreActividad")
         .AppendFormatLine("  FROM Productos P")
         .AppendFormatLine(" INNER JOIN ProductosComponentes PCP ON PCP.IdProducto = P.IdProducto")
         .AppendFormatLine(" INNER JOIN Productos PV ON PV.IdProducto = PCP.IdProductoComponente")
         .AppendFormatLine("  LEFT JOIN SubRubros PVSR ON PVSR.IdSubRubro = PV.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN ProductosComponentes PCV ON PCV.IdProducto = PV.IdProducto")
         .AppendFormatLine("  LEFT JOIN Productos PA ON PA.IdProducto = PCV.IdProductoComponente")
         .AppendFormatLine(" WHERE 1 = 1")
         If idRubro <> 0 Then
            .AppendFormatLine("   AND P.IdRubro = {0}", idRubro)
         End If
         If activo.HasValue Then
            .AppendFormatLine("   AND P.Activo = '{0}' AND PV.Activo = '{0}' AND ISNULL(PA.Activo, 1) = '{0}'", activo.Value)
         End If
         If publicarEnWeb.HasValue Then
            'Aqui se debe cambiar y luego testear para el PE-27695
            .AppendFormatLine("   AND P.PublicarEnWeb = '{0}' AND PV.PublicarEnWeb = '{0}' AND ISNULL(PA.PublicarEnWeb, 1) = '{0}'", publicarEnWeb.Value)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Sub CopiarComponentesFormula(idProducto As String, idFormulaOrigen As Integer, idFormulaDestino As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ProductosComponentes (")
         .AppendFormatLine("      IdProducto, IdProductoComponente")
         .AppendFormatLine("    , IdFormula, IdFormulaComponente")
         .AppendFormatLine("    , Cantidad, SegunCalculoForma")
         .AppendFormatLine("    , IdUnidadDeMedidaProduccion, CantidadUMProduccion, FactorConversionProduccion")
         .AppendFormatLine("    )")
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("      IdProducto, IdProductoComponente")
         .AppendFormatLine("    , {0} IdFormula, IdFormulaComponente", idFormulaDestino)
         .AppendFormatLine("    , Cantidad, SegunCalculoForma")
         .AppendFormatLine("    , IdUnidadDeMedidaProduccion, CantidadUMProduccion, FactorConversionProduccion")
         .AppendFormatLine("  FROM ProductosComponentes")
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND IdFormula  = {0}", idFormulaOrigen)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosComponentes")
   End Sub

End Class