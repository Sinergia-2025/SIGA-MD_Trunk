Imports System.Text

Public Class ClientesDescuentosMarcas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

    Public Sub ClientesDescuentosMarcas_I(ByVal IdCliente As Long, _
                                         ByVal IdMarca As Integer, _
                                         ByVal DescuentoRecargoPorc1 As Decimal, _
                                         ByVal DescuentoRecargoPorc2 As Decimal)

        Dim myQuery As StringBuilder = New StringBuilder("")

        With myQuery
            .Length = 0
            .AppendLine("INSERT INTO ClientesDescuentosMarcas")
            .AppendLine("   (IdCliente")
            .AppendLine("   ,IdMarca")
            .AppendLine("   ,DescuentoRecargoPorc1")
            .AppendLine("   ,DescuentoRecargoPorc2")
            .AppendLine(" ) VALUES (")
            .AppendLine("   " & IdCliente)
            .AppendLine("  ," & IdMarca.ToString())
            .AppendLine("  ," & DescuentoRecargoPorc1.ToString())
            .AppendLine("  ," & DescuentoRecargoPorc2.ToString())
            .AppendLine(")")
        End With

        Me.Execute(myQuery.ToString())
        Me.Sincroniza_I(myQuery.ToString(), "ClientesDescuentosMarcas")

    End Sub

   Public Sub ClientesDescuentosMarcas_D(ByVal IdCliente As Long, _
                                         ByVal IdMarca As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE CDM FROM ClientesDescuentosMarcas CDM")
            .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CDM.IdCliente")
         .AppendLine(" WHERE C.IdCliente = " & IdCliente)
         If IdMarca > 0 Then
            .AppendLine(" AND CDM.IdMarca = " & IdMarca.ToString())
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ClientesDescuentosMarcas")

   End Sub

   Public Function GetClientesDescuentosMarcas(idCliente As Long, grilla As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.IdCliente")
         .AppendFormatLine("     , M.IdMarca")
         .AppendFormatLine("     , M.NombreMarca")
         .AppendFormatLine("     , CD.DescuentoRecargoPorc1")
         .AppendFormatLine("     , CD.DescuentoRecargoPorc2")
         .AppendFormatLine("  FROM ClientesDescuentosMarcas CD ")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente ")
         If grilla Then
            .AppendFormatLine(" RIGHT JOIN Marcas M ON M.IdMarca = CD.IdMarca ")
         Else
            .AppendFormatLine(" INNER JOIN Marcas M ON M.IdMarca = CD.IdMarca ")
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If
         .AppendFormatLine(" ORDER BY M.NombreMarca")
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

   Public Function GetInfClientesDescuentosMarcas(ByVal IdCliente As Long, _
                                             ByVal Marcas As List(Of Entidades.Marca)) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT CD.IdCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,M.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,CD.DescuentoRecargoPorc1")
         .AppendLine("      ,CD.DescuentoRecargoPorc2")
         .AppendLine("      ,E.NombreEmpleado")
         .AppendLine("      ,C.Direccion")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,P.NombreProvincia")
         .AppendLine("      ,C.Telefono")
         .AppendLine(" FROM ClientesDescuentosMarcas CD ")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente ")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = CD.IdMarca ")
         .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = c.IdVendedor ")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine(" INNER JOIN Provincias  P ON P.IdProvincia = L.IdProvincia ")
         If IdCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & IdCliente)
         End If
         If Marcas.Count > 0 Then
            .Append(" AND CD.IdMarca IN (")
            For Each pr As Entidades.Marca In Marcas
               .AppendFormat(" {0},", pr.IdMarca)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If
         .AppendLine(" ORDER BY M.NombreMarca")
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
         .AppendLine("	AND C.IdCliente = " & IdCliente)
         .AppendLine("	AND CD.IdMarca = " & IdMarca.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
