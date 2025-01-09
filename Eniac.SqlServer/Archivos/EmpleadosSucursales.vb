Public Class EmpleadosSucursales
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EmpleadosSucursales_I(idSucursal As Integer, idEmpleado As Integer, idCaja As Integer?, observacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.EmpleadoSucursal.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}, {1}, {2}, {3})",
                           Entidades.EmpleadoSucursal.Columnas.IdSucursal.ToString(),
                           Entidades.EmpleadoSucursal.Columnas.idEmpleado.ToString(),
                           Entidades.EmpleadoSucursal.Columnas.IdCaja.ToString(),
                           Entidades.EmpleadoSucursal.Columnas.Observacion.ToString())
         .AppendFormatLine("    VALUES ({0}, {1}, {2}, '{3}'",
                           idSucursal, idEmpleado, GetStringFromNumber(idCaja), observacion)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EmpleadosSucursales_U(idSucursal As Integer, idEmpleado As Integer, idCaja As Integer?, observacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.EmpleadoSucursal.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.EmpleadoSucursal.Columnas.IdCaja.ToString(), GetStringFromNumber(idCaja))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.EmpleadoSucursal.Columnas.Observacion.ToString(), observacion)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.EmpleadoSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.EmpleadoSucursal.Columnas.idEmpleado.ToString(), idEmpleado)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EmpleadosSucursales_M(idSucursal As Integer, idEmpleado As Integer, idCaja As Integer?, observacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO EmpleadosSucursales AS D")
         .AppendFormatLine("     USING (SELECT {0} AS IdSucursal, {1} AS idEmpleado, {2} AS IdCaja, '{3}' AS Observacion) AS O",
                       idSucursal, idEmpleado, GetStringFromNumber(idCaja), observacion)
         .AppendFormatLine("        ON O.IdSucursal = D.IdSucursal AND O.idEmpleado = D.idEmpleado")
         .AppendFormatLine(" WHEN MATCHED THEN UPDATE SET D.IdCaja = O.IdCaja, D.Observacion = O.Observacion")
         .AppendFormatLine(" WHEN NOT MATCHED THEN INSERT (IdSucursal, idEmpleado, IdCaja, Observacion) VALUES (O.IdSucursal, O.idEmpleado, O.IdCaja, O.Observacion)")
         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EmpleadosSucursales_D(idSucursal As Integer, idEmpleado As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.EmpleadoSucursal.NombreTabla).AppendLine()
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If idSucursal > 0 Then
            .AppendFormat("   AND {0} = {1}", Entidades.EmpleadoSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idEmpleado > 0 Then
            .AppendFormat("   AND {0} = {1}", Entidades.EmpleadoSucursal.Columnas.idEmpleado.ToString(), idEmpleado)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT CS.*").AppendLine()
         .AppendFormat("     , S.Nombre AS NombreSucursal")
         .AppendFormat("     , C.NombreEmpleado").AppendLine()
         .AppendFormat("     , CN.NombreCaja").AppendLine()
         .AppendFormat("  FROM {0} AS CS", Entidades.EmpleadoSucursal.NombreTabla).AppendLine()
         .AppendFormat(" INNER JOIN Sucursales AS S ON S.IdSucursal = CS.IdSucursal").AppendLine()
         .AppendFormat(" INNER JOIN Empleados AS C ON C.idEmpleado = CS.idEmpleado").AppendLine()
         .AppendFormat("  LEFT JOIN CajasNombres AS CN ON CN.IdSucursal = CS.IdSucursal AND CN.IdCaja = CS.IdCaja").AppendLine()
      End With
   End Sub

   Public Function EmpleadosSucursales_GA() As DataTable
      Return EmpleadosSucursales_G(idSucursal:=0, idEmpleado:=0, idCaja:=0)
   End Function
   Public Function EmpleadosSucursales_GA(idSucursal As Integer) As DataTable
      Return EmpleadosSucursales_G(idSucursal:=idSucursal, idEmpleado:=0, idCaja:=0)
   End Function
   Private Function EmpleadosSucursales_G(idSucursal As Integer, idEmpleado As Integer, idCaja As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND CS.{0} = {1}", Entidades.EmpleadoSucursal.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         End If
         If idEmpleado > 0 Then
            .AppendFormat("   AND CS.{0} = {1}", Entidades.EmpleadoSucursal.Columnas.idEmpleado.ToString(), idEmpleado).AppendLine()
         End If
         If idCaja > 0 Then
            .AppendFormat("   AND CS.{0} = {1}", Entidades.EmpleadoSucursal.Columnas.IdCaja.ToString(), idCaja).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function EmpleadosSucursales_G1(idSucursal As Integer, idEmpleado As Integer) As DataTable
      Return EmpleadosSucursales_G(idSucursal:=idSucursal, idEmpleado:=idEmpleado, idCaja:=0)
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