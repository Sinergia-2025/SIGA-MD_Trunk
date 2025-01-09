Imports System.Text

Public Class TiposMatriculas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposMatriculas_I(ByVal idTipoMatricula As Integer, _
                                ByVal nombreTipoMatricula As String, _
                                ByVal tieneNumeros As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO TiposMatriculas ")
         .AppendLine("   (IdTipoMatricula")
         .AppendLine("   ,NombreTipoMatricula")
         .AppendLine("   ,TieneNumeros")
         .AppendLine(" ) VALUES (")
         .AppendLine(idTipoMatricula.ToString())
         .AppendLine("  ,'" & nombreTipoMatricula & "'")
         .AppendLine("  ,'" & tieneNumeros.ToString() & "'")
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposMatriculas")

   End Sub

   Public Sub TiposMatriculas_U(ByVal idTipoMatricula As Integer, _
                                ByVal nombreTipoMatricula As String, _
                                ByVal tieneNumeros As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE TiposMatriculas ")
         .AppendLine("   SET NombreTipoMatricula = '" & nombreTipoMatricula & "'")
         .AppendLine("      ,TieneNumeros = '" & tieneNumeros.ToString() & "'")
         .AppendLine(" WHERE idTipoMatricula = " & idTipoMatricula)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposMatriculas")

   End Sub

   Public Sub TiposMatriculas_D(ByVal idTipoMatricula As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM TiposMatriculas")
         .AppendLine(" WHERE idTipoMatricula = " & idTipoMatricula.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposMatriculas")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT T.IdTipoMatricula")
         .AppendLine("      ,T.NombreTipoMatricula")
         .AppendLine("      ,T.TieneNumeros")
         .AppendLine("  FROM TiposMatriculas T")
      End With
   End Sub

   Public Function TiposMatriculas_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY T.NombreTipoMatricula")
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

   Public Function TiposMatriculas_G1(ByVal IdTipoMatricula As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE T.IdTipoMatricula = " & IdTipoMatricula.ToString())
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

    Public Function GetPorNombreExacto(TipoMatricula As String) As DataTable
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            Me.SelectTexto(stb)
            .AppendFormat(" WHERE {0} = '{1}'", Entidades.TipoMatricula.Columnas.NombreTipoMatricula.ToString(), TipoMatricula)
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

End Class
