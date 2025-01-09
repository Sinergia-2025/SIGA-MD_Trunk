Public Class Monedas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Monedas_I(idMoneda As Integer,
                        nombreMoneda As String,
                        idTipoMoneda As String,
                        operadorConversion As String,
                        factorConversion As Decimal,
                        idBanco As Integer,
                        simbolo As String, predeterminada As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO Monedas (")
         .AppendFormatLine("            IdMoneda")
         .AppendFormatLine("          , NombreMoneda")
         .AppendFormatLine("          , IdTipoMoneda")
         .AppendFormatLine("          , OperadorConversion")
         .AppendFormatLine("          , FactorConversion")
         .AppendFormatLine("          , IdBanco")
         .AppendFormatLine("          , Simbolo")
         .AppendFormatLine("          , Predeterminada")
         .AppendFormatLine("   ) VALUES ( ")
         .AppendFormatLine("             {0} ", idMoneda)
         .AppendFormatLine("          , '{0}'", nombreMoneda)
         .AppendFormatLine("          , '{0}'", idTipoMoneda)
         .AppendFormatLine("          , '{0}'", operadorConversion)
         .AppendFormatLine("          ,  {0} ", factorConversion)
         If idBanco > 0 Then
            .AppendFormatLine("           ,  {0} ", idBanco)
         Else
            .AppendFormatLine("           ,  NULL")
         End If
         If simbolo <> "" Then
            .AppendFormatLine("           , '{0}'", simbolo)
         Else
            .AppendFormatLine("           ,  NULL")
         End If
         .AppendFormatLine("          ,  {0} ", GetStringFromBoolean(predeterminada))



         .AppendFormatLine(" )")
      End With
      Execute(stb)
   End Sub

   Public Sub Monedas_U(idMoneda As Integer,
                        nombreMoneda As String,
                        idTipoMoneda As String,
                        operadorConversion As String,
                        factorConversion As Decimal,
                        idBanco As Integer,
                        simbolo As String, predeterminada As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE Monedas")
         .AppendFormatLine("   SET NombreMoneda       = '{0}'", nombreMoneda)
         .AppendFormatLine("     , IdTipoMoneda       = '{0}'", idTipoMoneda)
         .AppendFormatLine("     , OperadorConversion = '{0}'", operadorConversion)
         .AppendFormatLine("     , FactorConversion   =  {0} ", factorConversion)
         If idBanco > 0 Then
            .AppendFormatLine("     , IdBanco            =  {0} ", idBanco)
         Else
            .AppendFormatLine("     , IdBanco            = NULL")
         End If
         .AppendFormatLine("     , Simbolo            = '{0}'", simbolo)
         .AppendFormatLine("     , Predeterminada     =  {0} ", GetStringFromBoolean(predeterminada))

         .AppendFormatLine(" WHERE IdMoneda           =  {0} ", idMoneda)
      End With
      Execute(stb)
   End Sub

   Public Sub Monedas_D(idMoneda As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM Monedas")
         .AppendFormatLine(" WHERE IdMoneda = {0}", idMoneda)
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT M.IdMoneda")
         .AppendFormatLine("     , M.NombreMoneda")
         .AppendFormatLine("     , M.IdTipoMoneda")
         .AppendFormatLine("     , M.OperadorConversion")
         .AppendFormatLine("     , M.FactorConversion")
         .AppendFormatLine("     , M.IdBanco")
         .AppendFormatLine("     , M.Simbolo")
         .AppendFormatLine("     , M.Predeterminada")
         .AppendFormatLine("  FROM Monedas M ")
      End With
   End Sub

   Public Function Monedas_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         '.AppendFormatLine(" ORDER BY M.IdMoneda")  'PE-41913
         .AppendFormatLine(" ORDER BY M.NombreMoneda")  'PE-41913
      End With
      Return GetDataTable(stb)
   End Function

   Public Function Monedas_G1(idMoneda As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE M.IdMoneda = {0}", idMoneda)
         .AppendLine(" ORDER BY M.IdMoneda ")
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "M.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdMoneda", "Monedas"))
   End Function

   Public Function GetAuditoriasMonedas(fechaDesde As Date, fechaHasta As Date, idMoneda As Integer, tipoOperacion As String) As DataTable

      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT ' ' as Modificado")
         .AppendFormatLine("     , AM.FechaAuditoria")
         .AppendFormatLine("     , AM.OperacionAuditoria")
         .AppendFormatLine("     , AM.UsuarioAuditoria")
         .AppendFormatLine("     , AM.IdMoneda")
         .AppendFormatLine("     , AM.NombreMoneda")
         .AppendFormatLine("     , AM.FactorConversion")
         .AppendFormatLine("     , AM.Simbolo")
         .AppendFormatLine("     , AM.Predeterminada")
         .AppendFormatLine(" FROM AuditoriaMonedas AM")
         .AppendFormat("WHERE AM.FechaAuditoria >= '{0} 00:00:00'", fechaDesde.ToString("yyyyMMdd"))
         .AppendFormat("	 AND AM.FechaAuditoria <= '{0} 23:59:59'", fechaHasta.ToString("yyyyMMdd"))
         If idMoneda <> 0 Then
            .AppendFormat("    AND AM.IdMoneda = {0}", idMoneda)
         End If
         If Not String.IsNullOrEmpty(tipoOperacion) Then
            Select Case tipoOperacion
               Case Entidades.OperacionesAuditorias.Alta.ToString()
                  .AppendFormatLine(" AND AM.OperacionAuditoria = 'A'")
               Case Entidades.OperacionesAuditorias.Modificacion.ToString()
                  .AppendFormatLine(" AND AM.OperacionAuditoria = 'M'")
               Case Entidades.OperacionesAuditorias.Baja.ToString()
                  .AppendFormatLine(" AND AM.OperacionAuditoria = 'B'")
            End Select
         End If
         .AppendLine("     ORDER BY AM.IdMoneda, AM.FechaAuditoria")
      End With
      Return GetDataTable(query)
   End Function
End Class