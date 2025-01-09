Public Class ParametrosSucursales
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Insert/Update/Merge/Delete"
   Public Sub ParametrosSucursales_I(idEmpresa As Integer,
                                     idSucursal As Integer,
                                     idParametro As String,
                                     valorParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0}  (", Entidades.ParametroSucursal.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.ParametroSucursal.Columnas.IdEmpresa.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ParametroSucursal.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ParametroSucursal.Columnas.IdParametro.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ParametroSucursal.Columnas.ValorParametro.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idEmpresa)
         .AppendFormatLine("           , {0} ", idSucursal)
         .AppendFormatLine("           ,'{0}'", idParametro)
         .AppendFormatLine("           ,'{0}'", valorParametro)
         .AppendFormatLine("           )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ParametrosSucursales_U(idEmpresa As Integer,
                                     idSucursal As Integer,
                                     idParametro As String,
                                     valorParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ParametroSucursal.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ParametroSucursal.Columnas.ValorParametro.ToString(), valorParametro)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ParametroSucursal.Columnas.IdEmpresa.ToString(), idEmpresa)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ParametroSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ParametroSucursal.Columnas.IdParametro.ToString(), idParametro)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ParametrosSucursales_M(idEmpresa As Integer,
                                     idSucursal As Integer,
                                     idParametro As String,
                                     valorParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO ParametrosSucursales AS D")
         .AppendFormatLine("        USING (SELECT  {1}  AS {0}", Entidades.ParametroSucursal.Columnas.IdEmpresa.ToString(), idEmpresa)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ParametroSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ParametroSucursal.Columnas.IdParametro.ToString(), idParametro)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ParametroSucursal.Columnas.ValorParametro.ToString(), valorParametro)
         .AppendFormatLine("              ) AS O ON O.IdParametro = D.IdParametro")
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.ValorParametro = O.ValorParametro")
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT (IdEmpresa, IdSucursal, IdParametro, ValorParametro) VALUES (O.IdEmpresa, O.IdSucursal, O.IdParametro, O.ValorParametro)")
         .AppendFormatLine(";")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ParametrosSucursales_D(idEmpresa As Integer,
                                     idSucursal As Integer,
                                     idParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", Entidades.ParametroSucursal.NombreTabla)
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.ParametroSucursal.Columnas.IdEmpresa.ToString(), idEmpresa)
         If idSucursal > 0 Then
            .AppendFormat("   AND {0} =  {1} ", Entidades.ParametroSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idParametro) Then
            .AppendFormat("   AND {0} = '{1}'", Entidades.ParametroSucursal.Columnas.IdParametro.ToString(), idParametro)
         End If
      End With
      Execute(myQuery)
   End Sub
#End Region

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PS.*")
         .AppendFormatLine("      ,P.CategoriaParametro")
         .AppendFormatLine("      ,P.DescripcionParametro")
         .AppendFormatLine("      ,P.ValorParametro AS ValorParametroOriginal")
         .AppendFormatLine("      ,P.UbicacionParametro")
         .AppendFormatLine("  FROM {0} AS PS", Entidades.ParametroSucursal.NombreTabla)
         .AppendFormatLine(" LEFT JOIN Parametros AS P ON P.IdParametro = PS.IdParametro")
      End With
   End Sub

#Region "GetAll"
   Public Function ParametrosSucursales_GA(idEmpresa As Integer, idSucursal As Integer) As DataTable
      Return ParametrosSucursales_G(idEmpresa, idSucursal, idParametro:=String.Empty, idExacto:=False)
   End Function
   Public Function ParametrosSucursales_GA(idEmpresa As Integer, idSucursal As Integer, idParametro As String, idExacto As Boolean) As DataTable
      Return ParametrosSucursales_G(idEmpresa, idSucursal, idParametro, idExacto)
   End Function
   Private Function ParametrosSucursales_G(idEmpresa As Integer,
                                           idSucursal As Integer,
                                           idParametro As String,
                                           idExacto As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idEmpresa > 0 Then
            .AppendFormatLine("   AND PS.{0} = {1}", Entidades.ParametroSucursal.Columnas.IdEmpresa.ToString(), idEmpresa)
         End If
         If idSucursal > 0 Then
            .AppendFormatLine("   AND PS.{0} = {1}", Entidades.ParametroSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idParametro) Then
            If idExacto Then
               .AppendFormatLine("   AND PS.{0} = '{1}'", Entidades.ParametroSucursal.Columnas.IdParametro.ToString(), idParametro)
            Else
               .AppendFormatLine("   AND PS.{0} LIKE '%{1}%'", Entidades.ParametroSucursal.Columnas.IdParametro.ToString(), idParametro)
            End If
         End If
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function ParametrosSucursales_G1(idEmpresa As Integer,
                                           idSucursal As Integer,
                                           idParametro As String) As DataTable
      Return ParametrosSucursales_G(idEmpresa, idSucursal, idParametro, idExacto:=True)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "P.",
                    New Dictionary(Of String, String) From {{"CategoriaParametro", "P.CategoriaParametro"},
                                                            {"DescripcionParametro", "P.DescripcionParametro"},
                                                            {"UbicacionParametro", "P.UbicacionParametro"},
                                                            {"ValorParametroOriginal", "P.ValorParametro"}})
   End Function
#End Region

End Class