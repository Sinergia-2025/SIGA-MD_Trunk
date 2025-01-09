Public Class CobradoresSucursales
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CobradoresSucursales_I(idSucursal As Integer, idCobrador As Integer, idCaja As Integer?, observacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.CobradorSucursal.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}, {1}, {2}, {3})",
                           Entidades.CobradorSucursal.Columnas.IdSucursal.ToString(),
                           Entidades.CobradorSucursal.Columnas.IdCobrador.ToString(),
                           Entidades.CobradorSucursal.Columnas.IdCaja.ToString(),
                           Entidades.CobradorSucursal.Columnas.Observacion.ToString())
         .AppendFormatLine("    VALUES ({0}, {1}, {2}, '{3}'",
                           idSucursal, idCobrador, GetStringFromNumber(idCaja), observacion)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CobradoresSucursales_U(idSucursal As Integer, idCobrador As Integer, idCaja As Integer?, observacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.CobradorSucursal.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.CobradorSucursal.Columnas.IdCaja.ToString(), GetStringFromNumber(idCaja))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CobradorSucursal.Columnas.Observacion.ToString(), observacion)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CobradorSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CobradorSucursal.Columnas.IdCobrador.ToString(), idCobrador)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CobradoresSucursales_M(idSucursal As Integer, idCobrador As Integer, idCaja As Integer?, observacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO CobradoresSucursales AS D")
         .AppendFormatLine("     USING (SELECT {0} AS IdSucursal, {1} AS IdCobrador, {2} AS IdCaja, '{3}' AS Observacion) AS O",
                       idSucursal, idCobrador, GetStringFromNumber(idCaja), observacion)
         .AppendFormatLine("        ON O.IdSucursal = D.IdSucursal AND O.IdCobrador = D.IdCobrador")
         .AppendFormatLine(" WHEN MATCHED THEN UPDATE SET D.IdCaja = O.IdCaja, D.Observacion = O.Observacion")
         .AppendFormatLine(" WHEN NOT MATCHED THEN INSERT (IdSucursal, IdCobrador, IdCaja, Observacion) VALUES (O.IdSucursal, O.IdCobrador, O.IdCaja, O.Observacion)")
         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CobradoresSucursales_D(idSucursal As Integer, idCobrador As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.CobradorSucursal.NombreTabla).AppendLine()
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If idSucursal > 0 Then
            .AppendFormat("   AND {0} = {1}", Entidades.CobradorSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idCobrador > 0 Then
            .AppendFormat("   AND {0} = {1}", Entidades.CobradorSucursal.Columnas.IdCobrador.ToString(), idCobrador)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT CS.*").AppendLine()
         .AppendFormat("     , S.Nombre AS NombreSucursal")
         .AppendFormat("     , C.NombreCobrador").AppendLine()
         .AppendFormat("     , CN.NombreCaja").AppendLine()
         .AppendFormat("  FROM {0} AS CS", Entidades.CobradorSucursal.NombreTabla).AppendLine()
         .AppendFormat(" INNER JOIN Sucursales AS S ON S.IdSucursal = CS.IdSucursal").AppendLine()
         .AppendFormat(" INNER JOIN Cobradores AS C ON C.IdCobrador = CS.IdCobrador").AppendLine()
         .AppendFormat("  LEFT JOIN CajasNombres AS CN ON CN.IdSucursal = CS.IdSucursal AND CN.IdCaja = CS.IdCaja").AppendLine()
      End With
   End Sub

   Public Function CobradoresSucursales_GA() As DataTable
      Return CobradoresSucursales_G(idSucursal:=0, idCobrador:=0, idCaja:=0)
   End Function
   Public Function CobradoresSucursales_GA(idSucursal As Integer) As DataTable
      Return CobradoresSucursales_G(idSucursal:=idSucursal, idCobrador:=0, idCaja:=0)
   End Function
   Private Function CobradoresSucursales_G(idSucursal As Integer, idCobrador As Integer, idCaja As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND CS.{0} = {1}", Entidades.CobradorSucursal.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         End If
         If idCobrador > 0 Then
            .AppendFormat("   AND CS.{0} = {1}", Entidades.CobradorSucursal.Columnas.IdCobrador.ToString(), idCobrador).AppendLine()
         End If
         If idCaja > 0 Then
            .AppendFormat("   AND CS.{0} = {1}", Entidades.CobradorSucursal.Columnas.IdCaja.ToString(), idCaja).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CobradoresSucursales_G1(idSucursal As Integer, idCobrador As Integer) As DataTable
      Return CobradoresSucursales_G(idSucursal:=idSucursal, idCobrador:=idCobrador, idCaja:=0)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      If columna = "NombreSucursal" Then
         columna = "S.Nombre"
      ElseIf columna = "NombreCobrador" Then
         columna = "C." + columna
      ElseIf columna = "NombreCaja" Then
         columna = "CN." + columna
      Else
         columna = "CS." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class