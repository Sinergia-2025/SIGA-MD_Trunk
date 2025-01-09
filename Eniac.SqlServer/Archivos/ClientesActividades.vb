Imports System.Text

Public Class ClientesActividades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ClientesActividades_I(ByVal IdCliente As Long, _
                                        ByVal IdProvincia As String, _
                                        ByVal IdActividad As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO ClientesActividades")
         .AppendLine("   (IdCliente")
         .AppendLine("   ,IdProvincia")
         .AppendLine("   ,IdActividad")
         .AppendLine(" ) VALUES (")
         .AppendLine("   " & IdCliente)
         .AppendLine("  ,'" & IdProvincia & "'")
         .AppendLine("  ," & IdActividad.ToString())
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ClientesActividades")

   End Sub

   Public Sub ClientesActividades_D(ByVal IdCliente As Long, _
                                        ByVal IdProvincia As String, _
                                        ByVal IdActividad As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM ClientesActividades ")
         .AppendLine(" WHERE IdCliente = " & IdCliente)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ClientesActividades")

   End Sub

   Public Function GetClientesActividades(ByVal IdCliente As Long, idProvinciaCliente As String, idProvinciaEmpresa As String, idCategoriaFiscalCliente As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0

         .AppendFormat("SELECT PEA.IdProvincia").AppendLine()
         .AppendFormat("      ,P.NombreProvincia").AppendLine()
         .AppendFormat("      ,ISNULL(CA.IdCliente, {0}) AS IdCliente", IdCliente).AppendLine()
         .AppendFormat("      ,ISNULL(CA.IdActividad, EA.IdActividad) AS IdActividad").AppendLine()
         .AppendFormat("      ,ISNULL(A.NombreActividad, AEA.NombreActividad) AS NombreActividad").AppendLine()
         .AppendFormat("      ,ISNULL(A.Porcentaje, AEA.Porcentaje) AS Porcentaje").AppendLine()
         .AppendFormat("  FROM (SELECT DISTINCT IdProvincia FROM EmpresaActividades) AS PEA").AppendLine()
         .AppendFormat(" INNER JOIN Provincias AS P ON P.IdProvincia = PEA.IdProvincia").AppendLine()
         .AppendFormat("  LEFT JOIN ClientesActividades AS CA ON CA.IdProvincia = PEA.IdProvincia AND CA.IdCliente = {0}", IdCliente).AppendLine()
         .AppendFormat("  LEFT JOIN Actividades AS A ON A.IdActividad = CA.IdActividad AND A.IdProvincia = CA.IdProvincia").AppendLine()
         .AppendFormat("  LEFT JOIN EmpresaActividades AS EA ON EA.IdProvincia = PEA.IdProvincia AND EA.Principal = 1").AppendLine()
         .AppendFormat("  LEFT JOIN Actividades AS AEA ON AEA.IdActividad = EA.IdActividad AND AEA.IdProvincia = EA.IdProvincia").AppendLine()
         .AppendFormat(" CROSS JOIN CategoriasFiscales AS CF").AppendLine()
         .AppendFormat(" WHERE PEA.IdProvincia IN ('{0}', '{1}')", idProvinciaCliente, idProvinciaEmpresa).AppendLine()
         .AppendFormat("   AND CF.IdCategoriaFiscal = {0} AND CF.EsPasiblePercIIBB = 1", idCategoriaFiscalCliente)
         .AppendFormat(" ORDER BY ISNULL(A.NombreActividad, AEA.NombreActividad)").AppendLine()


         '.AppendLine("SELECT CA.IdCliente")
         '.AppendLine("      ,CA.IdProvincia")
         '.AppendLine("      ,P.NombreProvincia")
         '.AppendLine("      ,CA.IdActividad")
         '.AppendLine("      ,A.NombreActividad")
         '.AppendLine("      ,A.Porcentaje")
         '.AppendLine(" FROM ClientesActividades CA ")
         '.AppendLine(" INNER JOIN Actividades A ON A.IdActividad = CA.IdActividad ")
         '.AppendLine("  AND A.IdProvincia = CA.IdProvincia")
         '.AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = CA.IdProvincia  ")
         'If IdCliente <> 0 Then
         '   .AppendLine("	WHERE CA.IdCliente = " & IdCliente)
         'End If
         '.AppendLine(" ORDER BY A.NombreActividad")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Get1(ByVal IdCliente As Long, _
                        ByVal IdMarca As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT CD.IdCliente")
         .AppendLine("      ,CD.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,CD.DescuentoRecargoPorc1")
         .AppendLine("      ,CD.DescuentoRecargoPorc2")
         .AppendLine(" FROM ClientesDescuentosMarcas CD ")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente ")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = CD.IdMarca ")
         .AppendLine("	AND CD.IdCliente = " & IdCliente)
         .AppendLine("	AND CD.IdMarca = " & IdMarca.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
