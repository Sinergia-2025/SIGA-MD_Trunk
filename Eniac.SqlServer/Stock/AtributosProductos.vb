Public Class AtributosProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AtributosProductos_I(idAtributoProducto As Integer,
                                   idGrupoTipoAtributoProducto As Integer,
                                   idTipoAtributoProducto As Short,
                                   descripcion As String,
                                   orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5})",
                       Entidades.AtributoProducto.NombreTabla,
                       Entidades.AtributoProducto.Columnas.IdAtributoProducto.ToString(),
                       Entidades.AtributoProducto.Columnas.IdGrupoTipoAtributoProducto.ToString(),
                       Entidades.AtributoProducto.Columnas.IdTipoAtributoProducto.ToString(),
                       Entidades.AtributoProducto.Columnas.Descripcion.ToString(),
                       Entidades.AtributoProducto.Columnas.Orden.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, {1}, {2}, '{3}', {4})", idAtributoProducto, idGrupoTipoAtributoProducto, idTipoAtributoProducto, descripcion, orden)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub AtributosProductos_U(idAtributoProducto As Integer,
                                   idGrupoTipoAtributoProducto As Integer,
                                   idTipoAtributoProducto As Short,
                                   descripcion As String,
                                   orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}        ", Entidades.AtributoProducto.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.AtributoProducto.Columnas.Descripcion.ToString(), descripcion).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.AtributoProducto.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.AtributoProducto.Columnas.IdGrupoTipoAtributoProducto.ToString(), idGrupoTipoAtributoProducto).AppendLine()
         .AppendFormat("   AND {0} =  {1} ", Entidades.AtributoProducto.Columnas.IdTipoAtributoProducto.ToString(), idTipoAtributoProducto).AppendLine()
         .AppendFormat("   AND {0} =  {1} ", Entidades.AtributoProducto.Columnas.IdAtributoProducto.ToString(), idAtributoProducto).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub AtributosProductos_D(idAtributoProducto As Integer, idGrupoTipoAtributoProducto As Integer, idTipoAtributoProducto As Short)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2} AND {3} = {4} AND {5} = {6}",
                               Entidades.AtributoProducto.NombreTabla,
                               Entidades.AtributoProducto.Columnas.IdAtributoProducto.ToString(), idAtributoProducto,
                               Entidades.AtributoProducto.Columnas.IdGrupoTipoAtributoProducto.ToString(), idGrupoTipoAtributoProducto,
                               Entidades.AtributoProducto.Columnas.IdTipoAtributoProducto.ToString(), idTipoAtributoProducto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT APD.IdAtributoProducto, APD.Descripcion, APD.Orden, APD.IdaAtributoProducto,")
         .AppendLine("       GTA.IdGrupoTipoAtributoProducto, GTA.Descripcion AS DescripcionGrupo, ")
         .AppendLine("       TAP.IdTipoAtributoProducto, TAP.Descripcion AS DescripcionTipo")
         .AppendFormat("  FROM {0} AS APD               ", Entidades.AtributoProducto.NombreTabla).AppendLine()
         .AppendFormat("       INNER JOIN {0} AS GTA    ", Entidades.GrupoTipoAtributoProducto.NombreTabla).AppendLine()
         .AppendFormat("           ON APD.{0} = GTA.{1} ",
                                          Entidades.AtributoProducto.Columnas.IdGrupoTipoAtributoProducto,
                                          Entidades.GrupoTipoAtributoProducto.Columnas.IdGrupoTipoAtributoProducto).AppendLine()
         .AppendFormat("           AND APD.{0} = GTA.{1}",
                                          Entidades.AtributoProducto.Columnas.IdTipoAtributoProducto,
                                          Entidades.GrupoTipoAtributoProducto.Columnas.IdTipoAtributoProducto).AppendLine()
         .AppendFormat("       INNER JOIN {0} AS TAP    ", Entidades.TipoAtributoProducto.NombreTabla).AppendLine()
         .AppendFormat("           ON TAP.{0} = GTA.{1} ",
                                          Entidades.TipoAtributoProducto.Columnas.IdTipoAtributoProducto,
                                          Entidades.GrupoTipoAtributoProducto.Columnas.IdTipoAtributoProducto).AppendLine()
      End With
   End Sub
   Public Function AtributosProductos_GA() As DataTable
      Return AtributosProductos_G(idAtributoProducto:=0, idGrupoTipoAtributoProducto:=0, idTipoAtributoProducto:=0, descripcion:=String.Empty)
   End Function
   Private Function AtributosProductos_G(idAtributoProducto As Integer, idGrupoTipoAtributoProducto As Integer, idTipoAtributoProducto As Short, descripcion As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idGrupoTipoAtributoProducto > 0 Then
            .AppendFormat("   AND APD.IdAtributoProducto = {0}", idAtributoProducto).AppendLine()
         End If
         If idGrupoTipoAtributoProducto > 0 Then
            .AppendFormat("   AND GTA.IdGrupoTipoAtributoProducto = {0}", idGrupoTipoAtributoProducto).AppendLine()
         End If
         If idTipoAtributoProducto > 0 Then
            .AppendFormat("   AND TAP.idTipoAtributoProducto = {0}", idTipoAtributoProducto).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            .AppendFormat("   AND APD.Descripcion LIKE '%{0}%'", descripcion).AppendLine()
         End If
         .AppendFormatLine(" ORDER BY TAP.Descripcion, GTA.Descripcion, APD.Descripcion")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function GetUnoCodigoIDA(idaA As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormat("   WHERE APD.IdaAtributoProducto = {0}", idaA).AppendLine()
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetUnoCodigoIDA(idaA As Integer, idaG As Integer, IdaT As Short) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idaA > 0 Then
            .AppendFormat("   AND APD.IdAtributoProducto = {0}", idaA).AppendLine()
         End If
         If idaG > 0 Then
            .AppendFormat("   AND GTA.IdGrupoTipoAtributoProducto = {0}", idaG).AppendLine()
         End If
         If IdaT > 0 Then
            .AppendFormat("   AND TAP.IdTipoAtributoProducto = {0}", IdaT).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function GetUnoNombreIDA(idaN As String, idaG As Integer, IdaT As Short) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         If Not String.IsNullOrEmpty(idaN) Then
            .AppendFormat("   WHERE  APD.Descripcion Like '%{0}%'", idaN).AppendLine()
         End If
         If idaG > 0 Then
            .AppendFormat("   AND GTA.IdGrupoTipoAtributoProducto = {0}", idaG).AppendLine()
         End If
         If IdaT > 0 Then
            .AppendFormat("   AND TAP.IdTipoAtributoProducto = {0}", IdaT).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Function AtributosProductos_G1(idAtributoProducto As Integer, idGrupoTipoAtributoProducto As Integer, idTipoAtributoProducto As Short) As DataTable
      Return AtributosProductos_G(idAtributoProducto:=idAtributoProducto, idGrupoTipoAtributoProducto:=idGrupoTipoAtributoProducto, idTipoAtributoProducto:=idTipoAtributoProducto, descripcion:=String.Empty)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "APD." + columna
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Overloads Function GetCodigoMaximo(grupoTipoAtributoProducto As Integer, tipoAtributoProducto As Short) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.AtributoProducto.Columnas.IdAtributoProducto.ToString(),
                                             "AtributosProductos",
                                             String.Format("IdTipoAtributoProducto = {0} AND IdGrupoTipoAtributoProducto = {1}", tipoAtributoProducto, grupoTipoAtributoProducto)))
   End Function
   Public Overloads Function GetOrdenMaximo(grupoTipoAtributoProducto As Integer, tipoAtributoProducto As Short) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.AtributoProducto.Columnas.Orden.ToString(),
                                             "AtributosProductos",
                                             String.Format("IdTipoAtributoProducto = {0} AND IdGrupoTipoAtributoProducto = {1}",
                                                           tipoAtributoProducto,
                                                           grupoTipoAtributoProducto)))
   End Function
   Public Function GetStockAtributoProductos(idProducto As String, idSucursal As Integer, idGrupoAtributo01 As Integer, idTipoAtributo01 As Integer, idGrupoAtributo02 As Integer, idTipoAtributo02 As Integer) As DataTable
      Dim atrib01 = (idTipoAtributo01 + idGrupoAtributo01) > 0
      Dim atrib02 = (idTipoAtributo02 + idGrupoAtributo02) > 0

      Dim myQuery = New StringBuilder()
      With myQuery
         If atrib01 And atrib02 Then
            .AppendLine("SELECT * FROM (")
            .AppendLine("       SELECT 'Atrib1_' + CONVERT(VARCHAR(MAX), PSA.IdaAtributo01) + '_' + PSA.DescripcionAtributo01 AS IdaAtributo01, PSA.IdaAtributo02 IdAtributo, PSA.DescripcionAtributo,")
         Else
            If atrib01 Then
               .AppendLine("SELECT NULL as IdAtributo, NULL as DescripcionAtributo, * FROM (")
               .AppendLine("       SELECT 'Atrib1_' + CONVERT(VARCHAR(MAX), PSA.IdaAtributo01) + '_' + PSA.DescripcionAtributo01 AS IdaAtributo01, ")
            End If
            If atrib02 Then
               .AppendLine("SELECT IdAtributo, DescripcionAtributo, Stock FROM (")
               .AppendLine("       SELECT PSA.IdaAtributo02 IdAtributo, PSA.DescripcionAtributo,")
            End If
         End If

         .AppendLine("             CASE WHEN SUM(PSA.Stock) = 0 THEN NULL ELSE SUM(PSA.Stock) END Stock")
         .AppendLine("       		  FROM (")

         '--
         If atrib01 And atrib02 Then
            .AppendLine("                  SELECT IdaAtributo01, AP1.Descripcion DescripcionAtributo01, IdaAtributo02, AP2.Descripcion DescripcionAtributo, Stock ")
         Else
            If atrib01 Then
               .AppendLine("                  SELECT IdaAtributo01, AP1.Descripcion DescripcionAtributo01, Stock ")
            End If
            If atrib02 Then
               .AppendLine("                  SELECT IdaAtributo02, AP2.Descripcion DescripcionAtributo, Stock ")
            End If
         End If
         '--
         .AppendLine("                    FROM  ProductosSucursalesAtributos PSA")
         '--
         If atrib01 And atrib02 Then
            .AppendLine("                    LEFT JOIN AtributosProductos AP1 ON AP1.IdaAtributoProducto = PSA.IdaAtributo01")
            .AppendLine("       				   LEFT JOIN AtributosProductos AP2 ON AP2.IdaAtributoProducto = PSA.IdaAtributo02")
         Else
            If atrib01 Then
               .AppendLine("                    LEFT JOIN AtributosProductos AP1 ON AP1.IdaAtributoProducto = PSA.IdaAtributo01")
            End If
            If atrib02 Then
               .AppendLine("       				   LEFT JOIN AtributosProductos AP2 ON AP2.IdaAtributoProducto = PSA.IdaAtributo02")
            End If
         End If
         '--
         .AppendFormatLine("   	       WHERE PSA.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("              AND PSA.IdSucursal =  {0} ", idSucursal)
         If atrib01 Then
            .AppendLine("						AND PSA.IdaAtributo01 IS NOT NULL")
         End If
         If atrib02 Then
            .AppendLine("						AND PSA.IdaAtributo02 IS NOT NULL")
         End If
         '--
         .AppendLine("				       UNION")
         '--
         If atrib01 And atrib02 Then
            .AppendLine("				       SELECT A1.IdaAtributoProducto IdaAtributo01, AP1.Descripcion DescripcionAtributo01, A2.IdaAtributoProducto IdaAtributo02, AP2.Descripcion DescripcionAtributo02, 0 Stock")
            .AppendFormatLine("    	           FROM (SELECT * FROM AtributosProductos A WHERE A.IdTipoAtributoProducto = {0} AND A.IdGrupoTipoAtributoProducto = {1}) A1 ", idTipoAtributo01, idGrupoAtributo01)
            .AppendFormatLine("  	       CROSS JOIN (SELECT * FROM AtributosProductos A WHERE A.IdTipoAtributoProducto = {0} AND A.IdGrupoTipoAtributoProducto = {1}) A2 ", idTipoAtributo02, idGrupoAtributo02)
            .AppendLine("				       LEFT JOIN AtributosProductos AP1 ON AP1.IdaAtributoProducto = A1.IdaAtributoProducto")
            .AppendLine("				       LEFT JOIN AtributosProductos AP2 ON AP2.IdaAtributoProducto = A2.IdaAtributoProducto")
         Else
            If atrib01 Then
               .AppendLine("				       SELECT A1.IdaAtributoProducto IdaAtributo01, AP1.Descripcion DescripcionAtributo01, 0 Stock")
               .AppendFormatLine("  	           FROM (SELECT * FROM AtributosProductos A WHERE A.IdTipoAtributoProducto = {0} AND A.IdGrupoTipoAtributoProducto = {1}) A1 ", idTipoAtributo01, idGrupoAtributo01)
               .AppendLine("				       LEFT JOIN AtributosProductos AP1 ON AP1.IdaAtributoProducto = A1.IdaAtributoProducto")
            End If
            If atrib02 Then
               .AppendLine("				       SELECT A2.IdaAtributoProducto IdaAtributo02, AP2.Descripcion DescripcionAtributo02, 0 Stock")
               .AppendFormatLine("  	           FROM (SELECT * FROM AtributosProductos A WHERE A.IdTipoAtributoProducto = {0} AND A.IdGrupoTipoAtributoProducto = {1}) A2 ", idTipoAtributo02, idGrupoAtributo02)
               .AppendLine("				       LEFT JOIN AtributosProductos AP2 ON AP2.IdaAtributoProducto = A2.IdaAtributoProducto")
            End If
         End If
         .AppendLine("                   ) PSA")

         If atrib01 And atrib02 Then
            .AppendLine("             GROUP BY PSA.IdaAtributo01, PSA.IdaAtributo02, PSA.DescripcionAtributo01, PSA.DescripcionAtributo")
         Else
            If atrib01 Then
               .AppendLine("             GROUP BY PSA.IdaAtributo01, PSA.DescripcionAtributo01")
            End If
            If atrib02 Then
               .AppendLine("             GROUP BY PSA.IdaAtributo02, PSA.DescripcionAtributo")
            End If
         End If
         .AppendLine("         		) PSA ")
         If atrib01 Then
            .AppendFormatLine("PIVOT (SUM(Stock) FOR IdaAtributo01 IN ({0})) PSA", GetColumnasProductoAtributo(idTipoAtributo01, idGrupoAtributo01))
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetColumnasProductoAtributo(idTipoAtributo01 As Integer, idGrupoAtributo01 As Integer) As String

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT ',[Atrib1_'+ Convert(varchar(MAX), A.IdaAtributoProducto) + '_' + Descripcion + ']' FROM AtributosProductos AS A")
         .AppendFormatLine("  WHERE A.IdTipoAtributoProducto = {0} AND A.IdGrupoTipoAtributoProducto = {1}", idTipoAtributo01, idGrupoAtributo01)
         .AppendLine("           FOR XML PATH('')")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return dt.Rows(0)(0).ToString().Trim(","c)
      Else
         Return String.Empty
      End If
   End Function
End Class
