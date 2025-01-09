Imports System.Text

Public Class TiposEmbarcaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposEmbarcacion_I(ByVal idTipoEmbarcacion As Integer, _
                                ByVal nombreTipoEmbarcacion As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO TiposEmbarcaciones ")
         .AppendLine("   (IdTipoEmbarcacion")
         .AppendLine("   ,NombreTipoEmbarcacion")
         .AppendLine(" ) VALUES (")
         .AppendLine(idTipoEmbarcacion.ToString())
         .AppendLine("  ,'" & nombreTipoEmbarcacion & "'")
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposEmbarcaciones")

   End Sub

   Public Sub TiposEmbarcacion_U(ByVal idTipoEmbarcacion As Integer, _
                                ByVal nombreTipoEmbarcacion As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE TiposEmbarcaciones ")
         .AppendLine("   SET NombreTipoEmbarcacion = '" & nombreTipoEmbarcacion & "'")
         .AppendLine(" WHERE idTipoEmbarcacion = " & idTipoEmbarcacion)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposEmbarcaciones")

   End Sub

   Public Sub TiposEmbarcacion_D(ByVal idTipoEmbarcacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM TiposEmbarcaciones")
         .AppendLine(" WHERE idTipoEmbarcacion = " & idTipoEmbarcacion.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposEmbarcaciones")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT T.IdTipoEmbarcacion")
         .AppendLine("      ,T.NombreTipoEmbarcacion")
         .AppendLine("  FROM TiposEmbarcaciones T")
      End With
   End Sub

   Public Function TiposEmbarcacion_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY T.NombreTipoEmbarcacion")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   'Public Function GetTieneNumeros(ByVal idMatricula As Integer) As Boolean
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      .AppendLine("SELECT TieneNumeros FROM TiposMatriculas T")
   '      .AppendLine("WHERE T.IdTipoMatricula = " & idMatricula)
   '   End With

   '   Dim dt As DataTable = Me.GetDataTable(stb.ToString())
   '   If dt.Rows.Count > 0 Then
   '      Return Boolean.Parse(dt.Rows(0)("TieneNumeros").ToString())
   '   Else
   '      Return True
   '   End If

   'End Function

   Public Function TiposEmbarcacion_G1(ByVal IdTipoEmbarcacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE T.IdTipoEmbarcacion = " & IdTipoEmbarcacion.ToString())
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
