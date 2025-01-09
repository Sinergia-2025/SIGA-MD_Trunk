Imports System.Text

Public Class CajasUsuarios
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CajasUsuarios_I(ByVal IdSucursal As Integer, _
                              ByVal IdCaja As Integer, _
                              ByVal IdUsuario As String, _
                              ByVal PermitirEscritura As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("CajasUsuarios  ")
         .Append("(IdSucursal, ")
         .Append("IdCaja, ")
         .Append("IdUsuario, ")
         .AppendLine(" PermitirEscritura")
         .Append(") VALUES (")
         .Append(IdSucursal & ", ")
         .Append(IdCaja & ", ")
         .Append("'" & IdUsuario.ToString() & "',")
         .AppendFormat(" {0} ", Me.GetStringFromBoolean(PermitirEscritura) & ")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CajasUsuarios")
   End Sub

   Public Sub CajasUsuarios_U(ByVal IdSucursal As Integer, _
                              ByVal IdCaja As Integer, _
                              ByVal NombreCaja As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE  ")
         .Append("CajasNombres  ")
         .Append("SET  ")

         .Append("NombreCaja = '" & NombreCaja & "'")

         .Append("WHERE ")
         .Append("IdSucursal = " & IdSucursal)
         .AppendLine(" AND IdCaja = " & IdCaja)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CajasNombres")
   End Sub

   Public Sub CajasUsuarios_D(ByVal IdSucursal As Integer, _
                              ByVal IdCaja As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM CajasUsuarios  ")
         .Append(" WHERE IdSucursal = " & IdSucursal)
         .AppendLine(" AND IdCaja = " & IdCaja)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CajasUsuarios")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT CN.IdSucursal")
         .AppendLine("        ,S.Nombre")
         .AppendLine("      ,CN.IdCaja")
         .AppendLine("      ,CN.NombreCaja")
         .AppendLine("  FROM CajasNombres CN ")
         .AppendLine(" INNER JOIN Sucursales S on S.IdSucursal = CN.IdSucursal")
      End With
   End Sub

   Public Function CajasUsuarios_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY NombreCaja ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetCajas(sucursales As Entidades.Sucursal(), ByVal usuario As String, ByVal nombrePC As String, ByVal CajasModificables As Boolean) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT DISTINCT cn.*")
         .AppendLine("      ,S.Nombre")
         .AppendLine(" FROM CajasNombres cn ")
         .AppendLine(" LEFT JOIN CajasUsuarios cu ON cn.IdCaja = cu.IdCaja AND cn.IdSucursal = cu.IdSucursal")
         .AppendLine(" LEFT JOIN Sucursales s ON s.IdSucursal = cn.IdSucursal")
         '.AppendLine(" WHERE cn.IdSucursal = " & idSucursal.ToString())
         .AppendLine("  WHERE 1 = 1")
         GetListaSucursalesMultiples(myQuery, sucursales, "CN")

         If Not String.IsNullOrEmpty(usuario) Then
            .AppendLine("   and cu.IdUsuario = '" & usuario & "'")
         End If
         If Not String.IsNullOrEmpty(nombrePC) Then
            .AppendLine("   AND cn.NombrePC = '" & nombrePC & "'")
         End If
         If CajasModificables = True Then
            .AppendLine(" AND CU.PermitirEscritura = 'True'")
         End If

         .AppendLine(" ORDER BY  cn.NombreCaja ")

      End With

      Dim dt As DataTable
      dt = Me.GetDataTable(myQuery.ToString())
      'If dt.Rows.Count > 0 Then
      '   Return dt
      'Else
      '   Throw New Exception("ATENCION: El Usuario NO tiene Caja Asociada y NO podrá continuar." & vbCrLf & vbCrLf & "Por favor contáctese con Sistemas.")
      'End If
      Return dt

   End Function

   Public Function GetCajasxNombre(ByVal NombreCaja As String, sucursales As Entidades.Sucursal(), ByVal usuario As String, ByVal nombrePC As String, ByVal CajasModificables As Boolean) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT DISTINCT cn.*")
         .AppendLine(" FROM CajasNombres cn ")
         .AppendLine(" LEFT JOIN CajasUsuarios cu ON cn.IdCaja = cu.IdCaja AND cn.IdSucursal = cu.IdSucursal")
         .AppendLine(" LEFT JOIN Sucursales s ON s.IdSucursal = cn.IdSucursal")
         '.AppendLine(" WHERE cn.IdSucursal = " & idSucursal.ToString())
         .AppendLine("  WHERE 1 = 1")
         SqlServer.Comunes.GetListaSucursalesMultiples(myQuery, sucursales, "CN")

         If Not String.IsNullOrEmpty(usuario) Then
            .AppendLine("   and cu.IdUsuario = '" & usuario & "'")
         End If
         If Not String.IsNullOrEmpty(nombrePC) Then
            .AppendLine("   AND cn.NombrePC = '" & nombrePC & "'")
         End If
         If CajasModificables = True Then
            .AppendLine(" AND CU.PermitirEscritura = 'True'")
         End If
         .AppendLine("  AND cn.NombreCaja LIKE '%" & NombreCaja & "%'")
         .AppendLine(" ORDER BY  cn.NombreCaja ")

      End With

      Dim dt As DataTable
      dt = Me.GetDataTable(myQuery.ToString())
      'If dt.Rows.Count > 0 Then
      '   Return dt
      'Else
      '   Throw New Exception("ATENCION: El Usuario NO tiene Caja Asociada y NO podrá continuar." & vbCrLf & vbCrLf & "Por favor contáctese con Sistemas.")
      'End If
      Return dt

   End Function

   Public Function CajasUsuarios_G1(ByVal IdSucursal As Integer, _
                                    ByVal IdCaja As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE IdSucursal = " & IdSucursal)
         .AppendLine(" AND IdCaja = " & IdCaja)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetCajaPorUsuario(caja As Integer,
                                     idSucursal As Integer,
                                     idUsuario As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendLine(" SELECT CU.IdSucursal, CU.IdCaja, CU.IdUsuario, U.Nombre, CU.PermitirEscritura  ")
         .AppendLine(" FROM CajasUsuarios CU  ")
         .AppendLine(" INNER JOIN Usuarios U ON U.Id = CU.IdUsuario")
         .AppendFormatLine(" WHERE IdCaja = {0}", caja)
         .AppendFormatLine(" AND IdSucursal = {0}", idSucursal)
         .AppendFormatLine(" AND IdUsuario = '{0}'", idUsuario)
         .AppendLine(" ORDER BY IdCaja")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
End Class
