Imports System.Text

Public Class TiposSociedades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   'INSERT
   Public Sub TiposSociedades_I(ByVal idTipoSociedad As Integer, _
                               ByVal nombreTipoSociedad As String)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("INSERT INTO {0} ({1}, {2})",
            Entidades.TipoSociedad.NombreTabla,
            Entidades.TipoSociedad.Columnas.IdTipoSociedad.ToString(),
            Entidades.TipoSociedad.Columnas.NombreTipoSociedad.ToString())
         .AppendFormat("   VALUES ({1}, '{2}')",
            Entidades.TipoSociedad.Columnas.NombreTipoSociedad, idTipoSociedad, nombreTipoSociedad)
      End With

      Me.Execute(query.ToString())
      Me.Sincroniza_I(query.ToString(), "TiposSociedades")
   End Sub

   Public Sub TiposSociedades_U(ByVal idTipoSociedad As Integer, _
                               ByVal nombreTipoSociedad As String)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("UPDATE {0}", Entidades.TipoSociedad.NombreTabla)
         .AppendFormatLine("  SET {0} = '{1}'", Entidades.TipoSociedad.Columnas.NombreTipoSociedad.ToString(), nombreTipoSociedad)
         .AppendFormatLine("  WHERE {0} = {1}", Entidades.TipoSociedad.Columnas.IdTipoSociedad.ToString(), idTipoSociedad)
      End With

      Me.Execute(query.ToString())
      Me.Sincroniza_I(query.ToString(), "TiposSociedades")
   End Sub

   Public Sub TiposSociedades_D(ByVal idTipoSociedad As Integer)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.TipoSociedad.NombreTabla, Entidades.TipoSociedad.Columnas.IdTipoSociedad.ToString(), idTipoSociedad)
      End With

      Me.Execute(query.ToString())
      Me.Sincroniza_I(query.ToString(), "TiposSociedades")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT T.IdTipoSociedad")
         .AppendLine("      ,T.NombreTipoSociedad")
         .AppendLine("  FROM TiposSociedades T")
      End With
   End Sub

   Public Function TiposSociedades_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY T.NombreTipoSociedad")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposSociedades_G1(ByVal IdTipoSociedad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE T.IdTipoSociedad = " & IdTipoSociedad.ToString())
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
