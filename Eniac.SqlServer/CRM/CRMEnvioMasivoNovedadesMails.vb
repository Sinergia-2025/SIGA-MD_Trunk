Public Class CRMEnvioMasivoNovedadesMails
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Function GetEnvioMasivoNovedadesMail(idAplicacion As String,
                                        categorias As Entidades.Categoria(),
                                        idZonaGeografica As String,
                                        idCliente As Long,
                                        desdeNombreCliente As String,
                                        configMail As String,
                                        IdCobrador As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")

         If configMail = Entidades.Cliente.ConfiguracionMail.Principal.ToString() Then
            .AppendLine("     ,C.CorreoElectronico")
         ElseIf configMail = Entidades.Cliente.ConfiguracionMail.Administrativo.ToString() Then
            .AppendLine("     ,C.CorreoAdministrativo AS CorreoElectronico")
         ElseIf configMail = Entidades.Cliente.ConfiguracionMail.AdminyPrincipal.ToString() Then
            .AppendLine("     ,C.CorreoElectronico + ';' + C.CorreoAdministrativo AS CorreoElectronico")
         ElseIf configMail = Entidades.Cliente.ConfiguracionMail.AdminoPrincipal.ToString() Then
            .AppendLine("     ,CASE WHEN ISNULL(C.CorreoAdministrativo, '') = '' THEN C.CorreoElectronico ELSE C.CorreoAdministrativo END AS CorreoElectronico")
         End If

         .AppendLine("      ,C.IdCategoria")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,C.IdCategoriaFiscal")
         .AppendLine("      ,CF.NombreCategoriaFiscal")
         .AppendLine("      ,C.IdZonaGeografica")
         .AppendLine("      ,Z.NombreZonaGeografica")
         .AppendLine("      ,E.NombreEmpleado AS NombreVendedor")
         .AppendLine("      ,Cob.NombreEmpleado AS NombreCobrador")
         .AppendLine("      ,EC.NombreEstadocliente")
         .AppendLine("      ,C.IdAplicacion ")
         .AppendLine("      ,C.Edicion")
         .AppendLine("      ,C.NroVersion")
         .AppendLine("      ,C.FechaActualizacionVersion ")
         .AppendLine("      ,CONVERT(bit, 0) AS Envio")
         .AppendLine("  FROM Clientes AS C ")
         .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine("  LEFT JOIN CategoriasFiscales AS CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")
         .AppendLine("  LEFT JOIN ZonasGeograficas AS Z ON Z.IdZonaGeografica = c.IdZonaGeografica")
         .AppendLine("  LEFT JOIN Empleados AS E ON E.IdEmpleado = C.IdVendedor ")
         .AppendLine("  LEFT JOIN Empleados AS Cob ON Cob.IdEmpleado = C.IdCobrador")
         .AppendLine("  LEFT JOIN EstadosClientes AS EC ON EC.IdEstadoCliente = C.IdEstado")
         .AppendFormatLine(" WHERE C.IdAplicacion = '{0}'", idAplicacion)

         GetListaCategoriasMultiples(stb, categorias, "C")

         If Not String.IsNullOrWhiteSpace(idZonaGeografica) Then
            .AppendFormatLine("   AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         If idCliente > 0 Then
            .AppendFormatLine("   AND C.idCliente = {0}", idCliente)
         End If
         If Not String.IsNullOrWhiteSpace(desdeNombreCliente) Then
            .AppendFormatLine("   AND C.NombreCliente >= '{0}'", desdeNombreCliente)
         End If

         If IdCobrador > 0 Then
            .AppendFormatLine("   AND C.IdCobrador = {0}", IdCobrador)
         End If

         .AppendLine(" ORDER BY C.NombreCliente")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

End Class