Public Class UnidadesDeMedidas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub UnidadDeMedida_I(idUnidadDeMedida As String, nombreUnidadDeMedida As String, conversionAKilos As Decimal, idAFIP As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO UnidadesDeMedidas (")
         .AppendFormatLine("     IdUnidadDeMedida")
         .AppendFormatLine("   , NombreUnidadDeMedida")
         .AppendFormatLine("   , ConversionAKilos")
         .AppendFormatLine("   , IdAFIP")
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("     '{0}'", idUnidadDeMedida)
         .AppendFormatLine("   , '{0}'", nombreUnidadDeMedida)
         .AppendFormatLine("   ,  {0} ", conversionAKilos)
         .AppendFormatLine("   ,  {0} ", idAFIP)
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "UnidadesDeMedidas")
   End Sub
   Public Sub UnidadDeMedida_U(idUnidadDeMedida As String, nombreUnidadDeMedida As String, conversionAKilos As Decimal, idAFIP As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE UnidadesDeMedidas SET")
         .AppendFormatLine("       NombreUnidadDeMedida = '{0}'", nombreUnidadDeMedida)
         .AppendFormatLine("     , ConversionAKilos = {0}", conversionAKilos)
         .AppendFormatLine("     , IdAFIP = {0}", idAFIP)
         .AppendFormatLine(" WHERE IdUnidadDeMedida = '{0}'", idUnidadDeMedida)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "UnidadesDeMedidas")
   End Sub
   Public Sub UnidadDeMedida_D(idUnidadDeMedida As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM UnidadesDeMedidas")
         .AppendFormatLine(" WHERE IdUnidadDeMedida = '{0}'", idUnidadDeMedida)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "UnidadesDeMedidas")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT UM.*")
         .AppendFormatLine("  FROM UnidadesDeMedidas UM")
      End With
   End Sub


   Public Function UnidadDeMedida_GA() As DataTable
      Return UnidadDeMedida_G(idUnidadDeMedida:=String.Empty, nombreUnidadDeMedida:=String.Empty, idUnidadDeMedidaExacta:=True, nombreUnidadDeMedidaExacta:=True, idUnidadDeMedidaVacioEsTodos:=True)
   End Function
   Private Function UnidadDeMedida_G(idUnidadDeMedida As String, nombreUnidadDeMedida As String, idUnidadDeMedidaExacta As Boolean, nombreUnidadDeMedidaExacta As Boolean,
                                     idUnidadDeMedidaVacioEsTodos As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not idUnidadDeMedidaVacioEsTodos Or Not String.IsNullOrWhiteSpace(idUnidadDeMedida) Then
            If idUnidadDeMedidaExacta Then
               .AppendFormatLine("   AND UM.IdUnidadDeMedida = '{0}'", idUnidadDeMedida)
            Else
               .AppendFormatLine("   AND UM.IdUnidadDeMedida LIKE '%{0}%'", idUnidadDeMedida)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(nombreUnidadDeMedida) Then
            If nombreUnidadDeMedidaExacta Then
               .AppendFormatLine("   AND UM.NombreUnidadDeMedida = '{0}'", nombreUnidadDeMedida)
            Else
               .AppendFormatLine("   AND UM.NombreUnidadDeMedida LIKE '%{0}%'", nombreUnidadDeMedida)
            End If
         End If
      End With

      Return GetDataTable(myQuery)
   End Function
   Public Function UnidadDeMedida_G1(idUnidadDeMedida As String) As DataTable
      Return UnidadDeMedida_G(idUnidadDeMedida, nombreUnidadDeMedida:=String.Empty, idUnidadDeMedidaExacta:=True, nombreUnidadDeMedidaExacta:=True, idUnidadDeMedidaVacioEsTodos:=False)
   End Function
   Public Function UnidadDeMedida_GA_BuscaPorCodigo(idUnidadDeMedida As String) As DataTable
      Return UnidadDeMedida_G(idUnidadDeMedida, nombreUnidadDeMedida:=String.Empty, idUnidadDeMedidaExacta:=False, nombreUnidadDeMedidaExacta:=True, idUnidadDeMedidaVacioEsTodos:=True)
   End Function
   Public Function UnidadDeMedida_GA_BuscaPorNombre(nombreUnidadDeMedida As String) As DataTable
      Return UnidadDeMedida_G(idUnidadDeMedida:=String.Empty, nombreUnidadDeMedida, idUnidadDeMedidaExacta:=True, nombreUnidadDeMedidaExacta:=False, idUnidadDeMedidaVacioEsTodos:=True)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "UM.")
   End Function

   Public Function GetUnidadDeMedidaPorDefecto() As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DECLARE @um char(2) = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas WHERE IdUnidadDeMedida = 'UN')")
         .AppendFormatLine("IF @um IS NULL SET @um = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas)")
         .AppendFormatLine("SELECT @um IdUnidadDeMedida")
      End With
      Return GetDataTable(query)
   End Function
End Class