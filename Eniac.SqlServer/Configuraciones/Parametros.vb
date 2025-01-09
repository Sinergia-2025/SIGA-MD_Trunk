Public Class Parametros
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Parametros_I(idEmpresa As Integer,
                           idParametro As String,
                           valorParametro As String,
                           categoriaParametro As String,
                           descripcionParametro As String,
                           ubicacionParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Parametros (")
         .AppendFormatLine("       IdEmpresa")
         .AppendFormatLine("     , IdParametro")
         .AppendFormatLine("     , ValorParametro")
         .AppendFormatLine("     , CategoriaParametro")
         .AppendFormatLine("     , DescripcionParametro")
         .AppendFormatLine("     , UbicacionParametro")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("        {0} ", idEmpresa)
         .AppendFormatLine("     , '{0}'", idParametro)
         .AppendFormatLine("     , '{0}'", valorParametro)
         .AppendFormatLine("     , '{0}'", categoriaParametro)
         .AppendFormatLine("     , '{0}'", descripcionParametro)
         .AppendFormatLine("     , '{0}'", ubicacionParametro)
         .AppendLine(" )")
      End With

      Execute(myQuery)
   End Sub

   Public Sub Parametros_U(idEmpresa As Integer,
                           idParametro As String,
                           valorParametro As String,
                           categoriaParametro As String,
                           descripcionParametro As String,
                           ubicacionParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE Parametros")
         .AppendFormatLine("   SET DescripcionParametro = '{0}'", descripcionParametro)
         .AppendFormatLine("     , ValorParametro = '{0}'", valorParametro)
         If Not String.IsNullOrEmpty(categoriaParametro) Then
            .AppendFormatLine("     , CategoriaParametro = '{0}'", categoriaParametro)
         End If
         .AppendFormatLine("     , UbicacionParametro = '{0}'", ubicacionParametro)
         .AppendFormatLine(" WHERE IdParametro = '{0}'", idParametro)
         .AppendFormatLine("   AND IdEmpresa = {0}", idEmpresa)
      End With

      Execute(myQuery)
   End Sub

   Public Sub Parametros_M1(idEmpresa As Integer, idParametro As String, valorParametro As String, ubicacionParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO Parametros AS P")
         .AppendFormatLine("        USING (SELECT '{0}' AS IdParametro, '{1}' ValorParametro, {2} IdEmpresa, '{3}' UbicacionParametro) AS PT ON P.IdParametro = PT.IdParametro AND P.IdEmpresa = PT.IdEmpresa", idParametro, valorParametro, idEmpresa, ubicacionParametro)
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET P.ValorParametro = PT.ValorParametro")
         .AppendFormatLine("                 , P.UbicacionParametro = PT.UbicacionParametro")
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT (   IdEmpresa,    IdParametro,    ValorParametro, DescripcionParametro, CategoriaParametro,    UbicacionParametro)")
         .AppendFormatLine("        VALUES (PT.IdEmpresa, PT.IdParametro, PT.ValorParametro, '',                  ''                 , PT.UbicacionParametro)")
         .AppendFormatLine(";")
      End With

      Execute(myQuery)
   End Sub

   Public Function Parametros_M(idEmpresaOrigen As Integer, idEmpresaDestino As Integer) As Integer
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO Parametros AS P")
         .AppendFormatLine("        USING (SELECT *, {1} AS IdEmpresaDestino FROM Parametros WHERE IdEmpresa = {0}) AS PT ON P.IdParametro = PT.IdParametro AND P.IdEmpresa = PT.IdEmpresaDestino", idEmpresaOrigen, idEmpresaDestino)
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET P.{0} = PT.IdEmpresaDestino", Entidades.Parametro.Columnas.IdEmpresa.ToString())
         .AppendFormatLine("                  ,P.{0} = PT.{0}", Entidades.Parametro.Columnas.IdParametro.ToString())
         .AppendFormatLine("                  ,P.{0} = PT.{0}", Entidades.Parametro.Columnas.DescripcionParametro.ToString())
         .AppendFormatLine("                  ,P.{0} = PT.{0}", Entidades.Parametro.Columnas.CategoriaParametro.ToString())
         .AppendFormatLine("                  ,P.{0} = PT.{0}", Entidades.Parametro.Columnas.ValorParametro.ToString())
         .AppendFormatLine("                  ,P.{0} = PT.{0}", Entidades.Parametro.Columnas.UbicacionParametro.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}, {3}, {4}, {5}) VALUES (PT.IdEmpresaDestino, PT.{1}, PT.{2}, PT.{3}, PT.{4}, PT.{5})",
                           Entidades.Parametro.Columnas.IdEmpresa.ToString(), Entidades.Parametro.Columnas.IdParametro.ToString(),
                           Entidades.Parametro.Columnas.DescripcionParametro.ToString(), Entidades.Parametro.Columnas.CategoriaParametro.ToString(),
                           Entidades.Parametro.Columnas.ValorParametro.ToString(), Entidades.Parametro.Columnas.UbicacionParametro.ToString())
         .AppendFormatLine(";")
      End With

      Return Execute(myQuery)
   End Function

   Public Sub Parametros_D(idEmpresa As Integer, idParametro As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM Parametros ")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         If Not String.IsNullOrWhiteSpace(idParametro) Then
            .AppendFormatLine("   AND IdParametro = '{0}'", idParametro)
         End If
      End With
      Execute(myQuery)
   End Sub

   Public Function Parametros_GA(idEmpresa As Integer) As DataTable
      Return Parametros_G(idEmpresa, idParametro:=String.Empty, categoriaParametro:=String.Empty, idExacto:=True)
   End Function
   Public Function Parametros_GA(idEmpresa As Integer, idParametro As String, idExacto As Boolean) As DataTable
      Return Parametros_G(idEmpresa, idParametro, categoriaParametro:=String.Empty, idExacto:=idExacto)
   End Function
   Public Function Parametros_GA(idEmpresa As Integer, categoriaParametro As String) As DataTable
      Return Parametros_G(idEmpresa, idParametro:=String.Empty, categoriaParametro:=categoriaParametro, idExacto:=True)
   End Function
   Public Function Parametros_G1(idEmpresa As Integer, idParametro As String) As DataTable
      Return Parametros_G(idEmpresa, idParametro, categoriaParametro:=String.Empty, idExacto:=True)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT P.*")
         .AppendLine("  FROM Parametros P")
      End With
   End Sub

   Public Function Parametros_GA(idEmpresa As Integer, idParametros As IEnumerable(Of String)) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1 ")
         .AppendFormatLine("   AND IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND IdParametro IN ({0})", String.Join(",", idParametros.ToList().ConvertAll(Function(s) String.Format("'{0}'", s))))
         .AppendFormatLine(" ORDER BY CategoriaParametro, IdParametro, IdEmpresa")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function Parametros_G(idEmpresa As Integer, idParametro As String, categoriaParametro As String, idExacto As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1 ")
         If idEmpresa > 0 Then
            .AppendFormatLine("   AND IdEmpresa = {0}", idEmpresa)
         End If
         If Not String.IsNullOrWhiteSpace(idParametro) Then
            If idExacto Then
               .AppendFormatLine("   AND IdParametro = '{0}'", idParametro)
            Else
               .AppendFormatLine("   AND IdParametro LIKE '%{0}%'", idParametro)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(categoriaParametro) Then
            .AppendFormatLine("   AND CategoriaParametro = '{0}'", categoriaParametro)
         End If
         .AppendLine(" ORDER BY CategoriaParametro, IdParametro, IdEmpresa")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function Existe(idEmpresa As Integer, IdParametro As String) As Boolean
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT * FROM Parametros ")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND IdParametro = '{0}'", IdParametro)
      End With
      Dim dt = GetDataTable(myQuery)
      If dt.Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Function GetValor(idEmpresa As Integer, idParametro As String) As String
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT ValorParametro ")
         .AppendFormatLine("  FROM Parametros")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND IdParametro = '{0}'", idParametro.ToUpper.Trim())
      End With
      Dim dt = GetDataTable(stb)
      If dt.Rows.Count > 0 Then
         Return dt.Rows(0)("ValorParametro").ToString().Trim()
      Else
         Throw New Exception("ATENCION: NO existe el Parametro '" & idParametro.ToUpper.Trim() & "' y NO podrá continuar." & vbCrLf & vbCrLf & "Por favor contáctese con Sistemas.")
      End If
   End Function

   Public Overloads Function GetValorPD(idEmpresa As Integer, idParametro As String) As DataTable
      Dim dt = Parametros_G(idEmpresa, idParametro, categoriaParametro:=String.Empty, idExacto:=True)
      Return dt
      'If dt.Rows.Count > 0 Then
      '   Return dt.Rows(0)("ValorParametro").ToString().Trim()
      'Else
      '   Return porDefecto
      'End If
   End Function

   Function GetParametrosDeOrganizarEntregasv2(idEmpresa As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT DescripcionParametro as 'Parámetro', CategoriaParametro as 'Solapa' ")
         .AppendLine(" FROM Parametros")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendLine("   AND (IdParametro = 'PEDIDOSPERMITEFECHAENTREGADISTINTAS' AND ValorParametro <> 'False' OR")
         .AppendLine("        IdParametro = 'FACTURARPEDIDOSELECCIONADO' AND ValorParametro <> 'True' OR")
         .AppendLine("        IdParametro = 'PREFACTURACONSUMEPEDIDOS' AND ValorParametro <> 'True')")
      End With
      Dim dt = GetDataTable(stb)
      Return dt
   End Function

   ''' <summary>
   ''' Consulto el grupo de parametros del mail
   ''' </summary>
   ''' <param name="idParametros">Es un String concatenado con , y valores entre comillas para un IN, por ejemplo 'PAR1','PAR2','PAR3'</param>
   ''' <returns>DataTable con la información</returns>
   ''' <remarks></remarks>
   Function GetMailGenerico(idEmpresa As Integer, idParametros As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro ")
         .AppendLine(" FROM Parametros")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND IdParametro IN ({0})", idParametros)
      End With
      Dim dt = GetDataTable(stb)
      Return dt
   End Function

   'nuevo
   Private Sub SelectTexto(stb As StringBuilder, esAuditoria As Boolean, Optional campoCalculado As String = "")
      With stb
         .AppendFormatLine("SELECT AuditoriaParametros AS AP.* ")

         .AppendFormatLine(campoCalculado)

         .AppendFormatLine("  , AP.FechaAuditoria ")
         .AppendFormatLine("  , AP.OperacionAuditoria")
         .AppendFormatLine("  , AP.UsuarioAuditoria")
         .AppendFormatLine("  , AP.IdEmpresa")
         .AppendFormatLine("  , AP.IdParametro")
         .AppendFormatLine("  , AP.ValorParametro")
         .AppendFormatLine("  , AP.CategoriaParametro")
         .AppendFormatLine("  , AP.DescripcionParametro")
         .AppendFormatLine("  , AP.UbicacionParametro")

         .AppendFormatLine("  FROM {0}AuditoriasParametros AS AP", If(esAuditoria, "Auditoria", Nothing))
         .AppendFormatLine("  INNER JOIN Usuarios AS U ON AP.UsuarioAuditoria = U.id")
      End With
   End Sub

   Public Function GetAuditoriasParametros(fechaDesde As Date,
                                           fechaHasta As Date,
                                           idParametro As String,
                                           tipoOperacion As String) As DataTable

      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT ' ' as Modificado")
         .AppendFormatLine("     , AP.FechaAuditoria")
         .AppendFormatLine("     , AP.OperacionAuditoria")
         .AppendFormatLine("     , AP.UsuarioAuditoria")
         .AppendFormatLine("     , AP.IdEmpresa")
         .AppendFormatLine("     , AP.IdParametro")
         .AppendFormatLine("     , AP.ValorParametro")
         .AppendFormatLine("     , AP.CategoriaParametro")
         .AppendFormatLine("     , AP.DescripcionParametro")
         .AppendFormatLine("     , AP.UbicacionParametro")

         .AppendFormatLine(" FROM AuditoriaParametros AP")
         'deberia haber left joins?

         .AppendFormat("WHERE AP.FechaAuditoria >= '{0} 00:00:00'", fechaDesde.ToString("yyyyMMdd"))
         .AppendFormat("	 AND AP.FechaAuditoria <= '{0} 23:59:59'", fechaHasta.ToString("yyyyMMdd"))

         If idParametro <> "" Then
            .AppendFormat("    AND AP.IdParametro = '{0}'", idParametro)
         End If
         If Not String.IsNullOrEmpty(tipoOperacion) Then
            Select Case tipoOperacion
               Case Entidades.OperacionesAuditorias.Alta.ToString()
                  .AppendFormatLine(" AND AP.OperacionAuditoria = 'A'")
               Case Entidades.OperacionesAuditorias.Modificacion.ToString()
                  .AppendFormatLine(" AND AP.OperacionAuditoria = 'M'")
               Case Entidades.OperacionesAuditorias.Baja.ToString()
                  .AppendFormatLine(" AND AP.OperacionAuditoria = 'B'")
            End Select
         End If

         .AppendLine("     ORDER BY AP.IdParametro, AP.FechaAuditoria")

      End With
      Return GetDataTable(query)
   End Function

   Public Overloads Function Buscar(campo As String, valor As String) As DataTable
      Return Buscar(campo, valor, Sub(stb) SelectTexto(stb), "P.")
   End Function

End Class