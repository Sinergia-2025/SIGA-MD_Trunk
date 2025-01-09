Imports System.Text

Public Class TiposTimoneles
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposTimoneles_I(ByVal idTipoTimonel As Integer, _
                               ByVal nombreTipoTimonel As String, _
                               ByVal Prefijo As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO TiposTimoneles ")
         .AppendLine("   (IdTipoTimonel")
         .AppendLine("   ,NombreTipoTimonel")
         .AppendLine("   ,Prefijo")
         .AppendLine(" ) VALUES (")
         .AppendLine(idTipoTimonel.ToString())
         .AppendLine("  ,'" & nombreTipoTimonel & "'")
         .AppendLine("  ,'" & Prefijo & "'")
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposTimoneles")

   End Sub

   Public Sub TiposTimoneles_U(ByVal idTipoTimonel As Integer, _
                               ByVal nombreTipoTimonel As String, _
                               ByVal Prefijo As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE TiposTimoneles ")
         .AppendLine("   SET NombreTipoTimonel = '" & nombreTipoTimonel & "'")
         .AppendLine("   , Prefijo = '" & Prefijo & "'")
         .AppendLine(" WHERE idTipoTimonel = " & idTipoTimonel)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposTimoneles")

   End Sub

   Public Sub TiposTimoneles_D(ByVal idTipoTimonel As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM TiposTimoneles")
         .AppendLine(" WHERE idTipoTimonel = " & idTipoTimonel.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposTimoneles")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT T.IdTipoTimonel")
         .AppendLine("      ,T.NombreTipoTimonel")
         .AppendLine("      ,T.Prefijo")
         .AppendLine("  FROM TiposTimoneles T")
      End With
   End Sub

   Public Function TiposTimoneles_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY T.NombreTipoTimonel")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposTimoneles_G1(ByVal IdTipoTimonel As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE T.IdTipoTimonel = " & IdTipoTimonel.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "T." + columna
      'If columna = "MoV.NombreMarcaVehiculo" Then columna = columna.Replace("MoV.", "MaV.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
