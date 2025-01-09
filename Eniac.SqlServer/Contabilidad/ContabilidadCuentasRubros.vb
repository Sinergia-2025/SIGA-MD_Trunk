Public Class ContabilidadCuentasRubros
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentaRubro_I(idRubro As Integer, tipo As String, idCuenta As Long, centroEmisor As Integer)
      CuentaRubro_D(idRubro, tipo, idCuenta, centroEmisor)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ContabilidadCuentasRubros (idRubro, IdCuenta, IdPlanCuenta, Tipo, CentroEmisor)")
         .AppendFormat("     SELECT {0}, {1}, CP.IdPlanCuenta, '{2}', {3} FROM ContabilidadPlanes AS CP",
                       idRubro, idCuenta, tipo, centroEmisor)
      End With
      Execute(stb)
   End Sub



   Public Sub CuentaRubro_D(idRubro As Integer, tipo As String, idCuenta As Long, centroEmisor As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ContabilidadCuentasRubros")
         .AppendFormatLine(" WHERE Idrubro = {0}", idRubro)
         .AppendFormatLine("   AND Tipo = '{0}'", tipo)
         .AppendFormatLine("   AND IdCuenta = {0}", idCuenta)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CR.*")
         .AppendFormatLine("     , P.NombrePlanCuenta")
         .AppendFormatLine("     , R.NombreRubro")
         .AppendFormatLine("     , C.NombreCuenta")
         .AppendFormatLine("  FROM ContabilidadCuentasRubros CR")
         .AppendFormatLine(" INNER JOIN ContabilidadCuentas C ON C.IdCuenta = CR.IdCuenta")
         .AppendFormatLine(" LEFT JOIN ContabilidadPlanesCuentas CP ON CP.IdPlanCuenta = CR.IdPlanCuenta AND CP.IdCuenta = CR.IdCuenta")
         .AppendFormatLine(" INNER JOIN ContabilidadPlanes P ON P.IdPlanCuenta = CR.IdPlanCuenta")
         .AppendFormatLine(" INNER JOIN Rubros R ON R.IdRubro = CR.IdRubro")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CR.",
                    New Dictionary(Of String, String) From {{"NombrePlanCuenta", "P.NombrePlanCuenta"},
                                                            {"NombreRubro", "R.NombreRubro"},
                                                            {"NombreCuenta", "C.NombreCuenta"}})
   End Function

   Public Function CuentaRubro_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" ORDER BY P.NombrePlanCuenta, CR.Tipo, R.NombreRubro, CR.IdCuenta, CR.CentroEmisor")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function CuentaRubro_G(idRubro As Integer?, idCuenta As Long?, idPlanCuenta As Integer?, tipo As String, excluirCentroEmisor As Integer?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         If idRubro.HasValue Then
            .AppendFormatLine("    AND CR.IdRubro = {0}", idRubro.Value)
         End If
         If idCuenta.HasValue Then
            .AppendFormatLine("    AND CR.idCuenta = {0}", idCuenta.Value)
         End If
         If idPlanCuenta.HasValue Then
            .AppendFormatLine("    AND CR.IdPlanCuenta = {0}", idPlanCuenta.Value)
         End If
         If Not String.IsNullOrWhiteSpace(tipo) Then
            .AppendFormatLine("    AND CR.Tipo = '{0}'", tipo)
         End If
         If excluirCentroEmisor.HasValue Then
            .AppendFormatLine("    AND CR.CentroEmisor <> {0}", excluirCentroEmisor.Value)
         End If
         .AppendFormatLine(" ORDER BY P.NombrePlanCuenta, CR.Tipo, R.NombreRubro, CR.IdCuenta, CR.CentroEmisor")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function CuentaRubro_G1(idPlanCuenta As Integer, idrubro As Integer, tipo As String, centroEmisor As Integer?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine("   AND CR.IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND CR.Idrubro = {0}", idrubro)
         .AppendFormatLine("   AND CR.Tipo = '{0}'", tipo)
         If centroEmisor.HasValue Then
            .AppendFormatLine("   AND CR.CentroEmisor = {0}", centroEmisor)
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPorNombre(NombrePlanCuenta As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" and PC.NombrePlanCuenta LIKE '%" & NombrePlanCuenta & "%'")
         .AppendLine(" ORDER BY PC.NombrePlanCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function PlanCuenta_GetIdMaximo() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(idPlanCuenta) AS maximo ")
         .AppendLine(" FROM ContabilidadPlanesCuentas")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetTipoComprobante(traerTodos As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT distinct tipo as tipo , tipo ")
         .AppendLine(" FROM TiposComprobantes")
         'esto es para stock
         .AppendLine("union   select 'AJUSTE' as tipo, 'AJUSTE' as tipo")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class