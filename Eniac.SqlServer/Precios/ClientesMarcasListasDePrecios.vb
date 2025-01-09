Imports System.Text

Public Class ClientesMarcasListasDePrecios
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

    Public Sub ClientesMarcasListasDePrecios_I(ByVal IdCliente As Long, _
                                          ByVal IdMarca As Integer, _
                                          ByVal IdListaPrecios As Decimal)

        Dim myQuery As StringBuilder = New StringBuilder("")

        With myQuery
            .Length = 0
            .AppendLine("INSERT INTO ClientesMarcasListasDePrecios (")
            .AppendLine(" IdCliente, ")
            .AppendLine("IdMarca, ")
            .AppendLine(" IdListaPrecios ")
            .AppendLine(" ) VALUES (")
            .AppendLine("" & IdCliente & ", ")
            .AppendLine("" & IdMarca & ", ")
            .AppendLine("" & IdListaPrecios & ")")

        End With

        Me.Execute(myQuery.ToString())
        Me.Sincroniza_I(myQuery.ToString(), "ClientesMarcasListasDePrecios")

    End Sub

    Public Sub ClientesMarcasListasDePrecios_D(ByVal IdCliente As Long, _
                                               ByVal IdMarca As Integer)

        Dim myQuery As StringBuilder = New StringBuilder("")

        With myQuery
            .AppendLine("DELETE FROM ClientesMarcasListasDePrecios ")
            .AppendLine(" WHERE IdCliente = " & IdCliente)
            .AppendLine(" AND IdMarca = " & IdMarca)

        End With

        Me.Execute(myQuery.ToString())
        Me.Sincroniza_I(myQuery.ToString(), "ClientesMarcasListasDePrecios")

    End Sub

   Public Function ClientesMarcasListasDePrecios(ByVal IdCliente As Long, _
                                                 ByVal IdMarca As Integer, _
                                                 ByVal IdListaDePrecios As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
            .AppendLine("SELECT CL.IdCliente")
            .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,CL.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,CL.IdListaPrecios")
         .AppendLine("      ,LP.NombreListaPrecios")
         .AppendLine(" FROM ClientesMarcasListasDePrecios CL ")
            .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CL.IdCliente ")
            .AppendLine("  INNER JOIN Marcas M ON M.IdMarca = CL.IdMarca ")
         .AppendLine("  INNER JOIN ListasDePrecios LP ON LP.IdListaPrecios = CL.IdListaPrecios ")
         If IdCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & IdCliente)
         End If
         If IdMarca > 0 Then
            .AppendLine("	AND CL.IdMarca = " & IdMarca.ToString())
         End If
         If IdListaDePrecios >= 0 Then
            .AppendLine("	AND CL.IdListaPrecios = " & IdListaDePrecios.ToString())
         End If

         .AppendLine(" ORDER BY C.NombreCliente, M.NombreMarca, CL.IdListaPrecios")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function ConsultaClientesMarcasListasDePrecios(ByVal IdCliente As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
            .AppendLine("SELECT CL.IdCliente")
            .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,CL.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,CL.IdListaPrecios")
         .AppendLine("      ,LP.NombreListaPrecios")
         .AppendLine(" FROM ClientesMarcasListasDePrecios CL ")
            .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CL.IdCliente ")
            .AppendLine("  INNER JOIN Marcas M ON M.IdMarca = CL.IdMarca ")
         .AppendLine("  INNER JOIN ListasDePrecios LP ON LP.IdListaPrecios = CL.IdListaPrecios ")
         If IdCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & IdCliente)
         End If
         .AppendLine(" ORDER BY C.NombreCliente, M.NombreMarca, CL.IdListaPrecios")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function Get1(ByVal IdCliente As Long, _
                        ByVal IdMarca As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
            .AppendLine("SELECT CL.IdCliente")
            .AppendLine("      ,CL.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,CL.IdListaPrecios")
         .AppendLine(" FROM ClientesMarcasListasDePrecios CL")
            .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CL.IdCliente ")
            .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = CL.IdMarca ")
         .AppendLine("	WHERE C.IdCliente = " & IdCliente)
         .AppendLine("	  AND CL.IdMarca = " & IdMarca.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
