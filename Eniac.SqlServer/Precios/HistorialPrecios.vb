Public Class HistorialPrecios
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub HistorialPrecios_I(idProducto As String,
                                 idSucursal As Integer,
                                 idListaPrecios As Integer,
                                 nombreListaPrecios As String,
                                 fechaHora As Date,
                                 precioFabrica As Decimal?,
                                 precioCosto As Decimal?,
                                 precioVenta As Decimal?,
                                 usuario As String,
                                 idFuncion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO HistorialPrecios")
         .AppendLine("     (IdProducto")
         .AppendLine("     ,IdSucursal")
         .AppendLine("     ,IdListaPrecios")
         .AppendLine("     ,NombreListaPrecios")
         .AppendLine("     ,FechaHora")
         .AppendLine("     ,PrecioFabrica")
         .AppendLine("     ,PrecioCosto")
         .AppendLine("     ,PrecioVenta")
         .AppendLine("     ,Usuario")
         .AppendLine("     ,IdFuncion")
         .AppendLine("     ) VALUES (")
         .AppendFormatLine("      '{0}'", idProducto)
         .AppendFormatLine("     , {0} ", idSucursal)
         .AppendFormatLine("     , {0} ", idListaPrecios)
         .AppendFormatLine("     ,'{0}'", nombreListaPrecios)
         .AppendFormatLine("     ,'{0}'", ObtenerFecha(fechaHora, True, True))
         .AppendFormatLine("     , {0} ", GetStringFromDecimal(precioFabrica))
         .AppendFormatLine("     , {0} ", GetStringFromDecimal(precioCosto))
         .AppendFormatLine("     , {0} ", GetStringFromDecimal(precioVenta))
         .AppendFormatLine("     ,'{0}'", usuario)
         .AppendFormatLine("     , {0} ", GetStringParaQueryConComillas(idFuncion))
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub HistorialPrecios_D(idProducto As String, idSucursal As Integer)
      HistorialPrecios_D(idProducto, idSucursal, Nothing)
   End Sub
   Public Sub HistorialPrecios_D(idSucursal As Integer)
      HistorialPrecios_D(String.Empty, idSucursal, Nothing)
   End Sub
   Public Sub HistorialPrecios_DPorLista(IdListaPrecios As Integer)
      HistorialPrecios_D(String.Empty, 0, IdListaPrecios)
   End Sub
   Private Sub HistorialPrecios_D(idProducto As String, idSucursal As Integer, idListaPrecios As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM HistorialPrecios ")
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         End If
         If idSucursal > 0 Then
            .AppendFormatLine("   AND IdSucursal = {0}", idSucursal)
         End If
         If idListaPrecios.HasValue Then
            .AppendFormatLine("   AND IdListaPrecios = {0}", idListaPrecios.Value)
         End If
      End With
      Execute(myQuery)
   End Sub

   Public Function GetHistorialPrecios(sucursales As Integer(),
                                       fechaDesde As Date?, fechaHasta As Date?,
                                       idProducto As String, idMarca As Integer, idRubro As Integer,
                                       usuario As String,
                                       listaDePrecios As Entidades.ListaDePrecios(),
                                       cantidadRegistros As Integer, ordenDescendente As Boolean, traerListaDeCostos As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .Append("SELECT ")
         If cantidadRegistros > 0 Then
            .AppendFormatLine("TOP {0}", cantidadRegistros)
         End If
         .AppendLine("       HP.IdSucursal")
         .AppendLine("      ,HP.IdProducto")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,HP.IdListaPrecios")
         .AppendLine("      ,HP.NombreListaPrecios")
         .AppendLine("      ,P.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,P.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,HP.FechaHora")
         .AppendLine("      ,HP.PrecioFabrica")
         .AppendLine("      ,HP.PrecioCosto")
         .AppendLine("      ,HP.PrecioVenta")

         .AppendLine("      ,NULLIF((SELECT TOP 1 HPa.PrecioCosto")
         .AppendLine("          FROM HistorialPrecios HPa ")
         .AppendLine("         WHERE HPa.IdSucursal      = HP.IdSucursal")
         .AppendLine("           AND HPa.IdProducto      = HP.IdProducto")
         .AppendLine("           AND HPa.IdListaPrecios  = HP.IdListaPrecios")
         .AppendLine("           AND HPa.FechaHora       < HP.FechaHora")
         .AppendLine("         ORDER BY HPa.FechaHora DESC), 0) PrecioCostoAnterior")

         .AppendLine("      ,NULLIF((SELECT TOP 1 HPa.PrecioVenta")
         .AppendLine("          FROM HistorialPrecios HPa ")
         .AppendLine("         WHERE HPa.IdSucursal      = HP.IdSucursal")
         .AppendLine("           AND HPa.IdProducto      = HP.IdProducto")
         .AppendLine("           AND HPa.IdListaPrecios  = HP.IdListaPrecios")
         .AppendLine("           AND HPa.FechaHora       < HP.FechaHora")
         .AppendLine("         ORDER BY HPa.FechaHora DESC), 0) PrecioVentaAnterior")

         .AppendLine("      ,NULLIF(CASE WHEN HP.PrecioVenta = 0 THEN 0 ELSE")
         .AppendLine("       (HP.PrecioVenta - (SELECT TOP 1 HPa.PrecioCosto")
         .AppendLine("                                   FROM HistorialPrecios HPa ")
         .AppendLine("                                  WHERE HPa.IdSucursal      = HP.IdSucursal")
         .AppendLine("                                    AND HPa.IdProducto      = HP.IdProducto")
         .AppendLine("                                    AND HPa.IdListaPrecios  = -1")
         .AppendLine("                                    AND HPa.FechaHora       < HP.FechaHora")
         .AppendLine("                                  ORDER BY HPa.FechaHora DESC)) * 100 / HP.PrecioVenta")
         .AppendLine("       END, 0) AS PorcUtilidad")

         .AppendLine("      ,HP.Usuario")
         .AppendLine("      ,HP.IdFuncion")
         .AppendLine(" FROM HistorialPrecios HP")
         .AppendLine(" LEFT JOIN Productos P ON P.IdProducto = HP.IdProducto")
         .AppendLine(" LEFT JOIN Sucursales S ON S.IdSucursal = HP.IdSucursal")
         .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")

         ''.AppendLine(" LEFT JOIN ListasDePrecios LP ON LP.idListaPrecios = HP.idListaPrecios")

         If sucursales.Length = 1 Then
            .AppendFormatLine("	WHERE HP.IdSucursal = {0}", sucursales(0))
         ElseIf sucursales.Length > 1 Then
            .AppendFormatLine("	WHERE HP.IdSucursal IN ({0})", String.Join(",", sucursales.ToList.ConvertAll(Function(i) i.ToString())))
         Else
            .AppendFormatLine("	WHERE 1 = 2")
         End If

         If fechaDesde.HasValue Then
            .AppendFormatLine("    AND HP.FechaHora >= {0}", ObtenerFecha(fechaDesde, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("    AND HP.FechaHora <= {0}", ObtenerFecha(fechaHasta, True))
         End If
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("    AND HP.IdProducto = '{0}'", idProducto)
         End If
         If idMarca > 0 Then
            .AppendFormatLine("    AND P.IdMarca = {0}", idMarca)
         End If
         If idRubro > 0 Then
            .AppendFormatLine("    AND P.IdRubro = {0}", idRubro)
         End If
         If Not String.IsNullOrEmpty(usuario) Then
            .AppendFormatLine("    AND HP.usuario = '{0}'", usuario)
         End If

         ' Selección de Multiples Listas de Precios
         If listaDePrecios IsNot Nothing Then
            Dim abrirParentesis As String = If(traerListaDeCostos, "(", "")
            GetListaDePreciosMultiples(stb, listaDePrecios, "HP", abrirParentesis:=abrirParentesis)
         End If

         ' Traer la lista de costos (idListaPrecios = -1)
         If traerListaDeCostos Then
            .AppendFormatLine("	{0} HP.idListaPrecios = -1{1}", If(listaDePrecios IsNot Nothing, "OR", "AND"), If(listaDePrecios IsNot Nothing, ")", ""))
         End If

         .AppendFormatLine(" ORDER BY HP.idProducto, HP.IdSucursal, HP.FechaHora {0}, HP.IdListaPrecios", If(ordenDescendente, "DESC", "ASC"))

      End With
      Return GetDataTable(stb)
   End Function

End Class