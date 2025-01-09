Imports System.Text

Public Class ClientesDescuentosRubros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ClientesDescuentosRubros_I(ByVal IdCliente As Long, _
                                         ByVal IdRubro As Integer, _
                                         ByVal DescuentoRecargoPorc1 As Decimal, _
                                         ByVal DescuentoRecargoPorc2 As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO ClientesDescuentosRubros")
         .AppendLine("   (IdCliente")
         .AppendLine("   ,IdRubro")
         .AppendLine("   ,DescuentoRecargoPorc1")
         .AppendLine("   ,DescuentoRecargoPorc2")
         .AppendLine(" ) VALUES (")
         .AppendLine("   " & IdCliente)
         .AppendLine("  ," & IdRubro.ToString())
         .AppendLine("  ," & DescuentoRecargoPorc1.ToString())
         .AppendLine("  ," & DescuentoRecargoPorc2.ToString())
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ClientesDescuentosRubros")

   End Sub

   Public Sub ClientesDescuentosRubros_D(ByVal IdCliente As Long, _
                                         ByVal IdRubro As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE CDM FROM ClientesDescuentosRubros CDM")
         .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CDM.IdCliente")
         .AppendLine(" WHERE C.IdCliente = " & IdCliente)
         If IdRubro > 0 Then
            .AppendLine(" AND CDM.IdRubro = " & IdRubro.ToString())
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ClientesDescuentosRubros")

   End Sub

   Public Function GetClientesDescuentosRubros(idCliente As Long, grilla As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CD.IdCliente")
         .AppendFormatLine("     , CD.IdRubro")
         .AppendFormatLine("     , R.NombreRubro")
         .AppendFormatLine("     , CD.DescuentoRecargoPorc1")
         .AppendFormatLine("     , CD.DescuentoRecargoPorc2")
         .AppendFormatLine("  FROM ClientesDescuentosRubros CD ")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente ")
         If grilla Then
            .AppendFormatLine(" RIGHT JOIN Rubros R ON R.IdRubro = CD.IdRubro ")
         Else
            .AppendFormatLine(" INNER JOIN Rubros R ON R.IdRubro = CD.IdRubro ")
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If
         .AppendFormatLine(" ORDER BY R.NombreRubro")
      End With

      Dim dt = GetDataTable(stb)
      If grilla Then
         'Completo porque en el Join no viene completo.
         For Each dr As DataRow In dt.Rows
            If String.IsNullOrEmpty(dr("DescuentoRecargoPorc1").ToString()) Then
               dr("DescuentoRecargoPorc1") = 0
            End If
            If String.IsNullOrEmpty(dr("DescuentoRecargoPorc2").ToString()) Then
               dr("DescuentoRecargoPorc2") = 0
            End If
         Next
      End If
      Return dt
   End Function

   Public Function GetInfClientesDescuentosRubros(ByVal IdCliente As Long, _
                                                  ByVal Rubros As List(Of Entidades.Rubro)) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT CD.IdCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,M.IdRubro")
         .AppendLine("      ,M.NombreRubro")
         .AppendLine("      ,CD.DescuentoRecargoPorc1")
         .AppendLine("      ,CD.DescuentoRecargoPorc2")
         .AppendLine("      ,E.NombreEmpleado")
         .AppendLine("      ,C.Direccion")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,P.NombreProvincia")
         .AppendLine("      ,C.Telefono")
         .AppendLine(" FROM ClientesDescuentosRubros CD ")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente ")
         .AppendLine(" INNER JOIN Rubros M ON M.IdRubro = CD.IdRubro ")
         .AppendLine(" INNER JOIN Empleados E ON E.TipoDocEmpleado = c.TipoDocVendedor ")
         .AppendLine("                       AND E.NroDocEmpleado = C.NroDocVendedor ")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine(" INNER JOIN Provincias  P ON P.IdProvincia = L.IdProvincia ")
         If IdCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & IdCliente)
         End If
         If Rubros.Count > 0 Then
            .Append(" AND CD.IdRubro IN (")
            For Each pr As Entidades.Rubro In Rubros
               .AppendFormat(" {0},", pr.IdRubro)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If
         .AppendLine(" ORDER BY M.NombreRubro")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function


   Public Function Get1(ByVal IdCliente As Long, _
                        ByVal IdRubro As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT CD.IdCliente")
         .AppendLine("      ,CD.IdRubro")
         .AppendLine("      ,M.NombreRubro")
         .AppendLine("      ,CD.DescuentoRecargoPorc1")
         .AppendLine("      ,CD.DescuentoRecargoPorc2")
         .AppendLine(" FROM ClientesDescuentosRubros CD ")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente ")
         .AppendLine(" INNER JOIN Rubros M ON M.IdRubro = CD.IdRubro ")
         .AppendLine("	AND C.IdCliente = " & IdCliente)
         .AppendLine("	AND CD.IdRubro = " & IdRubro.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
End Class
