Public Class CalendariosSucursales
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalendariosSucursales_I(idSucursal As Integer,
                                      idCalendario As Integer,
                                      idCaja As Integer)
      Dim stb As StringBuilder = New StringBuilder
      With stb
         .AppendFormatLine("INSERT INTO CalendariosSucursales")
         .AppendFormatLine("({0},{1}",
                           Entidades.CalendarioSucursal.Columnas.IdSucursal.ToString(),
                           Entidades.CalendarioSucursal.Columnas.IdCalendario.ToString())

         If idCaja <> 0 Then
            .AppendFormatLine(",{0})", Entidades.CalendarioSucursal.Columnas.IdCaja.ToString())
         Else
            .AppendLine(") ")
         End If
         .AppendFormatLine("VALUES ({0},{1}", idSucursal, idCalendario)

         If idCaja <> 0 Then
            .AppendFormatLine(",{0})", idCaja)
         Else
            .AppendLine(") ")
         End If
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub CalendariosSucursales_U(idSucursal As Integer,
                                      idCalendario As Integer,
                                      idCaja As Integer)
      Dim stb As StringBuilder = New StringBuilder
      With stb
         .AppendFormatLine("UPDATE {0} ", Entidades.CalendarioSucursal.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.CalendarioSucursal.Columnas.IdCaja.ToString(), GetStringFromNumber(idCaja))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CalendarioSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalendarioSucursal.Columnas.IdCalendario.ToString(), idCalendario)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub CalendariosSucursales_D(idSucursal As Integer, idCalendario As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.CalendarioSucursal.NombreTabla).AppendLine()
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If idSucursal > 0 Then
            .AppendFormat("   AND {0} = {1}", Entidades.CalendarioSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idCalendario > 0 Then
            .AppendFormat("   AND {0} = {1}", Entidades.CalendarioSucursal.Columnas.IdCalendario.ToString(), idCalendario)
         End If
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function CalendariosSucursales_GA() As DataTable
      Return CalendariosSucursales_G(idSucursal:=0, idCalendario:=0, idCaja:=0)
   End Function
   Public Function CalendariosSucursales_GA(idSucursal As Integer) As DataTable
      Return CalendariosSucursales_G(idSucursal:=idSucursal, idCalendario:=0, idCaja:=0)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CS.*")

         .AppendFormatLine("     , S.Nombre as NombreSucursal")
         .AppendFormatLine("     , C.NombreCalendario")
         .AppendFormatLine("     , CN.NombreCaja")

         .AppendFormatLine("  FROM CalendariosSucursales CS")

         .AppendFormatLine(" INNER JOIN Sucursales S ON CS.IdSucursal = S.IdSucursal")
         .AppendFormatLine(" INNER JOIN Calendarios C ON CS.IdCalendario = C.IdCalendario")
         .AppendFormatLine("  LEFT JOIN CajasNombres CN ON CS.IdCaja = CN.IdCaja")

      End With
   End Sub

   Private Function CalendariosSucursales_G(idSucursal As Integer, idCalendario As Integer, idCaja As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND CS.{0} = {1}", Entidades.CalendarioSucursal.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         End If
         If idCalendario > 0 Then
            .AppendFormat("   AND CS.{0} = {1}", Entidades.CalendarioSucursal.Columnas.IdCalendario.ToString(), idCalendario).AppendLine()
         End If
         If idCaja > 0 Then
            .AppendFormat("   AND CS.{0} = {1}", Entidades.CalendarioSucursal.Columnas.IdCaja.ToString(), idCaja).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CalendariosSucursales_G1(idSucursal As Integer, idCalendario As Integer) As DataTable
      Return CalendariosSucursales_G(idSucursal:=idSucursal, idCalendario:=idCalendario, idCaja:=0)
   End Function

End Class
