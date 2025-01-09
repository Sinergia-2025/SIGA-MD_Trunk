Option Strict On
Option Explicit On
Public Class TiposAdjuntos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposAdjuntos_I(idTipoAdjunto As Integer,
                              nombreTipoAdjunto As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO TiposAdjuntos ({0}, {1})",
                       Entidades.TipoAdjunto.Columnas.IdTipoAdjunto.ToString(),
                       Entidades.TipoAdjunto.Columnas.NombreTipoAdjunto.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}'",
                       idTipoAdjunto, nombreTipoAdjunto)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposAdjuntos_U(idTipoAdjunto As Integer,
                              nombreTipoAdjunto As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE TiposAdjuntos ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.TipoAdjunto.Columnas.NombreTipoAdjunto.ToString(), nombreTipoAdjunto).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TipoAdjunto.Columnas.IdTipoAdjunto.ToString(), idTipoAdjunto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposAdjuntos_D(idTipoAdjunto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM TiposAdjuntos WHERE {0} = {1}", Entidades.TipoAdjunto.Columnas.IdTipoAdjunto.ToString(), idTipoAdjunto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT TA.* FROM TiposAdjuntos AS TA").AppendLine()
      End With
   End Sub

   Public Function TiposAdjuntos_GA() As DataTable
      Return TiposAdjuntos_G(idTipoAdjunto:=Nothing, nombreTipoAdjunto:=String.Empty, nombreExacto:=False)
   End Function
   Private Function TiposAdjuntos_G(idTipoAdjunto As Integer?, nombreTipoAdjunto As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idTipoAdjunto.HasValue Then
            .AppendFormat("   AND TA.idTipoAdjunto = {0}", idTipoAdjunto.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(nombreTipoAdjunto) Then
            If nombreExacto Then
               .AppendFormat("   AND TA.NombreTipoAdjunto = '{0}'", nombreTipoAdjunto).AppendLine()
            Else
               .AppendFormat("   AND TA.NombreTipoAdjunto LIKE '%{0}%'", nombreTipoAdjunto).AppendLine()
            End If
         End If
         .AppendLine(" ORDER BY TA.NombreTipoAdjunto")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposAdjuntos_G1(idTipoAdjunto As Integer) As DataTable
      Return TiposAdjuntos_G(idTipoAdjunto:=idTipoAdjunto, nombreTipoAdjunto:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'If columna = "NombreSucursal" Then
      '   columna = "S." + columna
      'Else
      columna = "TA." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.TipoAdjunto.Columnas.IdTipoAdjunto.ToString(), "TiposAdjuntos"))
   End Function

End Class