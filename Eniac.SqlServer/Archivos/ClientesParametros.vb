Public Class ClientesParametros
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Insert/Update/Merge/Delete"
   Public Sub ClientesParametros_I(idCliente As Long, nombreServidor As String, baseDatos As String, idEmpresa As Integer, idParametro As String,
                                   valorParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0}  (", Entidades.ClienteParametro.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.ClienteParametro.Columnas.IdCliente.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteParametro.Columnas.NombreServidor.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteParametro.Columnas.BaseDatos.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteParametro.Columnas.IdEmpresa.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteParametro.Columnas.IdParametro.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteParametro.Columnas.ValorParametro.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idCliente)
         .AppendFormatLine("           ,'{0}'", nombreServidor)
         .AppendFormatLine("           ,'{0}'", baseDatos)
         .AppendFormatLine("           , {0} ", idEmpresa)
         .AppendFormatLine("           ,'{0}'", idParametro)
         .AppendFormatLine("           ,'{0}'", valorParametro)
         .AppendFormatLine("           )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ClientesParametros_U(idCliente As Long, nombreServidor As String, baseDatos As String, idEmpresa As Integer, idParametro As String,
                                   valorParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ClienteParametro.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ClienteParametro.Columnas.ValorParametro.ToString(), valorParametro)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteParametro.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteParametro.Columnas.NombreServidor.ToString(), nombreServidor)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteParametro.Columnas.BaseDatos.ToString(), baseDatos)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ClienteParametro.Columnas.IdEmpresa.ToString(), idEmpresa)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteParametro.Columnas.IdParametro.ToString(), idParametro)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ClientesParametros_M(idCliente As Long, nombreServidor As String, baseDatos As String, idEmpresa As Integer, idParametro As String,
                                   valorParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO {0} AS DEST", Entidades.ClienteParametro.NombreTabla)
         .AppendFormatLine("      USING (SELECT {1} AS {0}, '{3}' AS {2}, '{5}' AS {4}, {7} AS {6}, '{9}' AS {8}, '{11}' AS {10}) AS ORIG",
                           Entidades.ClienteParametro.Columnas.IdCliente.ToString(), idCliente,
                           Entidades.ClienteParametro.Columnas.NombreServidor.ToString(), nombreServidor,
                           Entidades.ClienteParametro.Columnas.BaseDatos.ToString(), baseDatos,
                           Entidades.ClienteParametro.Columnas.IdEmpresa.ToString(), idEmpresa,
                           Entidades.ClienteParametro.Columnas.IdParametro.ToString(), idParametro,
                           Entidades.ClienteParametro.Columnas.ValorParametro.ToString(), valorParametro)
         .AppendFormatLine("         ON DEST.{0} = ORIG.{0} AND DEST.{1} = ORIG.{1} AND DEST.{2} = ORIG.{2} AND DEST.{3} = ORIG.{3} AND DEST.{4} = ORIG.{4}",
                           Entidades.ClienteParametro.Columnas.IdCliente.ToString(),
                           Entidades.ClienteParametro.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteParametro.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteParametro.Columnas.IdEmpresa.ToString(),
                           Entidades.ClienteParametro.Columnas.IdParametro.ToString())
         .AppendFormatLine("      WHEN MATCHED THEN")
         .AppendFormatLine("      UPDATE SET DEST.{0} = ORIG.{0}", Entidades.ClienteParametro.Columnas.ValorParametro.ToString())
         .AppendFormatLine("      WHEN NOT MATCHED THEN")
         .AppendFormatLine("      INSERT ({0}, {1}, {2}, {3}, {4}, {5}) VALUES (ORIG.{0}, ORIG.{1}, ORIG.{2}, ORIG.{3}, ORIG.{4}, ORIG.{5})",
                           Entidades.ClienteParametro.Columnas.IdCliente.ToString(),
                           Entidades.ClienteParametro.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteParametro.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteParametro.Columnas.IdEmpresa.ToString(),
                           Entidades.ClienteParametro.Columnas.IdParametro.ToString(),
                           Entidades.ClienteParametro.Columnas.ValorParametro.ToString())
         .AppendFormatLine(";")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ClientesParametros_M(parametros As IEnumerable(Of Entidades.ClienteParametro))
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO {0} AS DEST USING (", Entidades.ClienteParametro.NombreTabla)

         Dim primero As Boolean = True
         For Each param As Entidades.ClienteParametro In parametros
            If Not primero Then
               .AppendLine(" UNION ALL ")
            End If
            .AppendFormat("      SELECT {1} AS {0}, '{3}' AS {2}, '{5}' AS {4}, {7} AS {6}, '{9}' AS {8}, '{11}' AS {10}",
                              Entidades.ClienteParametro.Columnas.IdCliente.ToString(), param.IdCliente,
                              Entidades.ClienteParametro.Columnas.NombreServidor.ToString(), param.NombreServidor,
                              Entidades.ClienteParametro.Columnas.BaseDatos.ToString(), param.BaseDatos,
                              Entidades.ClienteParametro.Columnas.IdEmpresa.ToString(), param.IdEmpresa,
                              Entidades.ClienteParametro.Columnas.IdParametro.ToString(), param.IdParametro,
                              Entidades.ClienteParametro.Columnas.ValorParametro.ToString(), param.ValorParametro)
            primero = False
         Next
         .AppendFormatLine(") AS ORIG")
         .AppendFormatLine("         ON DEST.{0} = ORIG.{0} AND DEST.{1} = ORIG.{1} AND DEST.{2} = ORIG.{2} AND DEST.{3} = ORIG.{3} AND DEST.{4} = ORIG.{4}",
                           Entidades.ClienteParametro.Columnas.IdCliente.ToString(),
                           Entidades.ClienteParametro.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteParametro.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteParametro.Columnas.IdEmpresa.ToString(),
                           Entidades.ClienteParametro.Columnas.IdParametro.ToString())
         .AppendFormatLine("      WHEN MATCHED THEN")
         .AppendFormatLine("      UPDATE SET DEST.{0} = ORIG.{0}", Entidades.ClienteParametro.Columnas.ValorParametro.ToString())
         .AppendFormatLine("      WHEN NOT MATCHED THEN")
         .AppendFormatLine("      INSERT ({0}, {1}, {2}, {3}, {4}, {5}) VALUES (ORIG.{0}, ORIG.{1}, ORIG.{2}, ORIG.{3}, ORIG.{4}, ORIG.{5})",
                           Entidades.ClienteParametro.Columnas.IdCliente.ToString(),
                           Entidades.ClienteParametro.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteParametro.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteParametro.Columnas.IdEmpresa.ToString(),
                           Entidades.ClienteParametro.Columnas.IdParametro.ToString(),
                           Entidades.ClienteParametro.Columnas.ValorParametro.ToString())
         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesParametros_D(idCliente As Long)
      ClientesParametros_D(idCliente, nombreServidor:=String.Empty, baseDatos:=String.Empty, idEmpresa:=0, idParametro:=String.Empty)
   End Sub
   Public Sub ClientesParametros_D(idCliente As Long, nombreServidor As String, baseDatos As String, idEmpresa As Integer, idParametro As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.ClienteParametro.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteParametro.Columnas.IdCliente.ToString(), idCliente)
         If Not String.IsNullOrWhiteSpace(nombreServidor) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteParametro.Columnas.NombreServidor.ToString(), nombreServidor)
         End If
         If Not String.IsNullOrWhiteSpace(baseDatos) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteParametro.Columnas.BaseDatos.ToString(), baseDatos)
         End If
         If idEmpresa > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.ClienteParametro.Columnas.IdEmpresa.ToString(), idEmpresa)
         End If
         If Not String.IsNullOrWhiteSpace(idParametro) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteParametro.Columnas.IdParametro.ToString(), idParametro)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub
#End Region

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CD.*")
         .AppendFormatLine("  FROM {0} AS CD", Entidades.ClienteParametro.NombreTabla)
         .AppendFormatLine(" INNER JOIN Clientes AS C ON C.IdCliente = CD.IdCliente")
      End With
   End Sub

#Region "GetAll"
   Public Function ClientesParametros_GA() As DataTable
      Return ClientesParametros_G(idCliente:=0, codigoCliente:=0, nombreServidor:=String.Empty, baseDatos:=String.Empty, idEmpresa:=0, idParametros:={})
   End Function
   Public Function ClientesParametros_GA(idCliente As Long, codigoCliente As Long, idParametros As String()) As DataTable
      Return ClientesParametros_G(idCliente, codigoCliente, nombreServidor:=String.Empty, baseDatos:=String.Empty, idEmpresa:=0, idParametros:=idParametros)
   End Function
   Private Function ClientesParametros_G(idCliente As Long,
                                         codigoCliente As Long,
                                         nombreServidor As String,
                                         baseDatos As String,
                                         idEmpresa As Integer,
                                         idParametros As String()) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCliente <> 0 Then
            .AppendFormatLine("   AND CD.{0} =  {1} ", Entidades.ClienteParametro.Columnas.IdCliente.ToString(), idCliente)
         End If
         If codigoCliente <> 0 Then
            .AppendFormatLine("   AND  C.{0} =  {1} ", Entidades.Cliente.Columnas.CodigoCliente.ToString(), codigoCliente)
         End If
         If Not String.IsNullOrWhiteSpace(nombreServidor) Then
            .AppendFormatLine("   AND CD.{0} = '{1}'", Entidades.ClienteParametro.Columnas.NombreServidor.ToString(), nombreServidor)
         End If
         If Not String.IsNullOrWhiteSpace(baseDatos) Then
            .AppendFormatLine("   AND CD.{0} = '{1}'", Entidades.ClienteParametro.Columnas.BaseDatos.ToString(), baseDatos)
         End If
         If idEmpresa > 0 Then
            .AppendFormatLine("   AND  C.{0} =  {1} ", Entidades.ClienteParametro.Columnas.IdEmpresa.ToString(), idEmpresa)
         End If

         GetListaMultiples(myQuery, idParametros, "CD", Entidades.ClienteParametro.Columnas.IdParametro.ToString())

      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function ClientesParametros_G1(idCliente As Long,
                                         nombreServidor As String,
                                         baseDatos As String,
                                         idEmpresa As Integer,
                                         idParametro As String) As DataTable
      Return ClientesParametros_G(idCliente, codigoCliente:=0, nombreServidor:=nombreServidor, baseDatos:=baseDatos, idEmpresa:=idEmpresa, idParametros:={idParametro})
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CD.")
   End Function
   Public Function GetInfClienteParametros(idCliente As Long, idParametro As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CP.*")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , C.NombreDeFantasia")
         .AppendFormatLine("     , C.IdZonaGeografica")
         .AppendFormatLine("     , ZG.NombreZonaGeografica")
         .AppendFormatLine("     , C.IdAplicacion")
         .AppendFormatLine("     , A.NombreAplicacion")
         .AppendFormatLine("     , C.IdCategoria")
         .AppendFormatLine("     , Cat.NombreCategoria")
         .AppendFormatLine("     , C.IdCategoriaFiscal")
         .AppendFormatLine("     , CF.NombreCategoriaFiscal")
         .AppendFormatLine("     , P.CategoriaParametro")
         .AppendFormatLine("     , P.DescripcionParametro")
         .AppendFormatLine("  FROM ClientesParametros AS CP")
         .AppendFormatLine(" INNER JOIN Clientes AS C ON CP.IdCliente = C.IdCliente")
         .AppendFormatLine("  LEFT JOIN Parametros AS P ON CP.IdParametro = P.IdParametro")
         .AppendFormatLine("  LEFT JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica")
         .AppendFormatLine("  LEFT JOIN Aplicaciones A ON A.IdAplicacion = C.IdAplicacion")
         .AppendFormatLine("  LEFT JOIN Categorias Cat ON Cat.IdCategoria = C.IdCategoria")
         .AppendFormatLine("  LEFT JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")
         .AppendFormatLine(" WHERE 1 = 1")
         If idCliente > 0 Then
            .AppendFormatLine("   AND CP.IdCliente = {0}", idCliente)
         End If
         If Not String.IsNullOrWhiteSpace(idParametro) Then
            .AppendFormatLine("   AND CP.IdParametro = '{0}' ", idParametro)
         End If
         .AppendFormatLine(" ORDER BY NombreCliente,IdParametro")
      End With

      Return GetDataTable(stb)
   End Function
#End Region

   Public Sub ActualizarCliente(codigoCliente As Long, version As String, fechaVersion As Date?, vencimientoSistema As Date?)

      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE Clientes")
         .AppendFormatLine("   SET NroVersion = '{0}'", version)
         If fechaVersion.HasValue Then
            .AppendFormatLine("     , FechaActualizacionVersion = '{0}'", ObtenerFecha(fechaVersion.Value, True))
         Else
            '.AppendFormatLine("     , FechaActualizacionVersion = NULL")
         End If
         If vencimientoSistema.HasValue Then
            .AppendFormatLine("     , VencimientoLicencia = '{0}'", ObtenerFecha(vencimientoSistema.Value, True))
         Else
            '.AppendFormatLine("     , VencimientoLicencia = NULL")
         End If

         .AppendFormatLine(" WHERE CodigoCliente = {0}", codigoCliente)

      End With
      Execute(stb)
   End Sub

End Class