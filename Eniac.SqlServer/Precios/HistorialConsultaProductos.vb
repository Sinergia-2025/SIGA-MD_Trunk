Public Class HistorialConsultaProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub HistorialConsultaProductos_I(ByVal idProducto As String, _
                                 ByVal idSucursal As Integer, _
                                 ByVal fechaHora As Date, _
                                 ByVal usuario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("HistorialConsultaProductos  ")
         .Append("(IdProducto, ")
         .Append("IdSucursal, ")
         .Append("FechaHora, ")
         .Append("Usuario ")
         .Append(") ")
         .Append("VALUES(")
         .Append("'" & idProducto & "', ")
         .Append(idSucursal.ToString() & ", ")
         .Append("'" & Me.ObtenerFecha(fechaHora, True) & "', ")
         .Append("'" & usuario & "' ")
         .Append(")  ")
      End With

      Me.Execute(myQuery.ToString())
   End Sub


   Public Function GetHistorialConsultaProductos(ByVal Sucursales As Integer(), _
                                        ByVal fechaDesde As Date, _
                                        ByVal fechaHasta As Date, _
                                        ByVal idProducto As String, _
                                        ByVal idMarca As Integer, _
                                        ByVal idRubro As Integer, _
                                        ByVal usuario As String, _
                                         ByVal OcultarProdNoStock As Boolean) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT HCP.IdSucursal")
         .AppendLine("      ,HCP.IdProducto")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,P.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,P.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,HCP.FechaHora")
         .AppendLine("      ,HCP.Usuario")
         .AppendLine(" FROM HistorialConsultaProductos HCP")
         .AppendLine(" LEFT JOIN Productos P ON P.IdProducto = HCP.IdProducto")
         .AppendLine(" LEFT JOIN Sucursales S ON S.IdSucursal = HCP.IdSucursal")
         .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")

         If Sucursales.Length = 1 Then
            .AppendLine("	WHERE HCP.IdSucursal = " & Sucursales(0).ToString())
         Else
            .AppendLine("	WHERE HCP.IdSucursal IN (")
            For Each suc As Integer In Sucursales
               .AppendFormat("{0},", suc)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         End If

         .AppendLine("    AND HCP.FechaHora >= '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("    AND HCP.FechaHora <= '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat("	AND HCP.IdProducto = '{0}'", idProducto)
         End If

         If idMarca > 0 Then
            .AppendFormat("	AND P.IdMarca = {0}", idMarca)
         End If

         If idRubro > 0 Then
            .AppendFormat("	AND P.IdRubro = {0}", idRubro)
         End If

         If Not String.IsNullOrEmpty(usuario) Then
            .AppendFormat("	AND HCP.usuario = '{0}'", usuario)
         End If

         If OcultarProdNoStock Then
            .AppendLine(" AND P.AfectaStock = 'True'")
         End If

         .AppendLine(" ORDER BY HCP.idProducto, HCP.IdSucursal, HCP.FechaHora")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
