Public Class ConcesionarioSubTiposUnidades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   'INSERT
   Public Sub SubTiposUnidades_I(idSubTipoUnidad As Integer,
                                 nombreSubTipoUnidad As String,
                                 descripcionSubTipoUnidad As String,
                                 idTipoUnidad As Integer,
                                 solicitaCantPuertasLaterales As Boolean,
                                 solicitaCantPisos As Boolean,
                                 solicitaVolumen As Boolean)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7})",
            Entidades.ConcesionarioSubTipoUnidad.NombreTabla,
            Entidades.ConcesionarioSubTipoUnidad.columnas.IdSubTipoUnidad.ToString(),
            Entidades.ConcesionarioSubTipoUnidad.columnas.NombreSubTipoUnidad.ToString(),
            Entidades.ConcesionarioSubTipoUnidad.columnas.DescripcionSubTipoUnidad.ToString(),
            Entidades.ConcesionarioSubTipoUnidad.columnas.IdTipoUnidad.ToString(),
            Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaCantPuertasLaterales.ToString(),
            Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaCantPisos.ToString(),
            Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaVolumen.ToString())

         .AppendFormat("   VALUES ({1}, '{2}', '{3}', {4}, {5}, {6}, {7})",
            Entidades.ConcesionarioSubTipoUnidad.NombreTabla, idSubTipoUnidad, nombreSubTipoUnidad, descripcionSubTipoUnidad,
            idTipoUnidad, GetStringFromBoolean(solicitaCantPuertasLaterales), GetStringFromBoolean(solicitaCantPisos), GetStringFromBoolean(solicitaVolumen))

      End With
      Me.Execute(query.ToString())
   End Sub
   'UPDATE
   Public Sub SubTipoUnidades_U(idSubTipoUnidad As Integer,
                                 nombreSubTipoUnidad As String,
                                 descripcionSubTipoUnidad As String,
                                 idTipoUnidad As Integer,
                                 solicitaCantPuertasLaterales As Boolean,
                                 solicitaCantPisos As Boolean,
                                 solicitaVolumen As Boolean)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("UPDATE {0}", Entidades.ConcesionarioSubTipoUnidad.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ConcesionarioSubTipoUnidad.columnas.NombreSubTipoUnidad.ToString(), nombreSubTipoUnidad)
         .AppendFormatLine(" , {0} = '{1}'", Entidades.ConcesionarioSubTipoUnidad.columnas.DescripcionSubTipoUnidad.ToString(), descripcionSubTipoUnidad)
         .AppendFormatLine(" , {0} = {1}", Entidades.ConcesionarioSubTipoUnidad.columnas.IdTipoUnidad.ToString(), idTipoUnidad)
         .AppendFormatLine(" , {0} = {1}", Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaCantPuertasLaterales.ToString(), GetStringFromBoolean(solicitaCantPuertasLaterales))
         .AppendFormatLine(" ,{0} = {1}", Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaCantPisos.ToString(), GetStringFromBoolean(solicitaCantPisos))
         .AppendFormatLine(" ,{0} = {1}", Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaVolumen.ToString(), GetStringFromBoolean(solicitaVolumen))
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ConcesionarioSubTipoUnidad.columnas.IdSubTipoUnidad.ToString(), idSubTipoUnidad)
      End With
      Me.Execute(query.ToString())
   End Sub
   'DELETE
   Public Sub SubTiposUnidades_D(idSubTipoUnidad As Integer, nombreSubTipoUnidad As String)
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.ConcesionarioSubTipoUnidad.NombreTabla, Entidades.ConcesionarioSubTipoUnidad.columnas.IdSubTipoUnidad.ToString(), idSubTipoUnidad)
      End With
      Me.Execute(query.ToString())
   End Sub
   'SELECT TEXT
   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ConcesionarioSubTipoUnidad.*, ConcesionarioTiposUnidades.NombreTipoUnidad FROM {0} AS ConcesionarioSubTipoUnidad", Entidades.ConcesionarioSubTipoUnidad.NombreTabla)
         .AppendLine(" INNER JOIN ConcesionarioTiposUnidades ON ConcesionarioSubTipoUnidad.IdTipoUnidad = ConcesionarioTiposUnidades.IdTipoUnidad")
      End With
   End Sub
   'G
   Private Function SubTiposUnidades_G(idSubTipoUnidad As Integer,
                                       nombreSubTipoUnidad As String,
                                       nombreExacto As Boolean,
                                       descripcionSubTipoUnidad As String,
                                       idTipoUnidad As Integer) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendFormatLine(" WHERE 1 = 1")
         If idSubTipoUnidad > 0 Then
            .AppendFormatLine("   AND ConcesionarioSubTipoUnidad.IdSubTipoUnidad = {0}", idSubTipoUnidad)
         End If
         If Not String.IsNullOrWhiteSpace(nombreSubTipoUnidad) Then
            If nombreExacto Then
               .AppendFormatLine("   AND ConcesionarioSubTipoUnidad.NombreSubTipoUnidad = '{0}'", nombreSubTipoUnidad)
            Else
               .AppendFormatLine("   AND ConcesionarioSubTipoUnidad.NombreSubTipoUnidad LIKE '%{0}%'", nombreSubTipoUnidad)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(descripcionSubTipoUnidad) Then
            .AppendFormatLine("   AND ConcesionarioSubTipoUnidad.DescripcionSubTipoUnidad LIKE '%{0}%'", descripcionSubTipoUnidad)
         End If
         If idTipoUnidad > 0 Then
            .AppendFormatLine("   AND ConcesionarioSubTipoUnidad.IdTipoUnidad = {0}", idTipoUnidad)
         End If

      End With
      Return Me.GetDataTable(query.ToString())
   End Function
   'GA
   Public Function SubTiposUnidades_GA(idTipoUnidad As Integer) As DataTable
      Return SubTiposUnidades_G(idSubTipoUnidad:=0, nombreSubTipoUnidad:=String.Empty, nombreExacto:=False, descripcionSubTipoUnidad:=String.Empty,
                                idTipoUnidad:=idTipoUnidad)
   End Function
   'GA
   Public Function SubTiposUnidades_GA() As DataTable
      Return SubTiposUnidades_G(idSubTipoUnidad:=0, nombreSubTipoUnidad:=String.Empty, nombreExacto:=False, descripcionSubTipoUnidad:=String.Empty,
                                idTipoUnidad:=0)
   End Function
   Public Function SubTiposUnidades_GA(nombreSubTipoUnidad As String, nombreExacto As Boolean) As DataTable
      Return SubTiposUnidades_G(idSubTipoUnidad:=0, nombreSubTipoUnidad:=nombreSubTipoUnidad, nombreExacto:=nombreExacto, descripcionSubTipoUnidad:=String.Empty,
                                idTipoUnidad:=0)
   End Function
   'G1
   Public Function SubTiposUnidades_G1(idSubTipoUnidad As Integer) As DataTable
      Return SubTiposUnidades_G(idSubTipoUnidad:=idSubTipoUnidad, nombreSubTipoUnidad:=String.Empty, nombreExacto:=False, descripcionSubTipoUnidad:=String.Empty,
                                idTipoUnidad:=0)
   End Function
   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "ConcesionarioSubTipoUnidad." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   'GET CODIGO MAXIMO
   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ConcesionarioSubTipoUnidad.columnas.IdSubTipoUnidad.ToString(), "ConcesionarioSubTiposUnidades"))
   End Function

   'GET NOMBRE UNIDO
   'Public Function SubTiposUnidades_GetNombreUnido() As DataTable
   '   Dim query As StringBuilder = New StringBuilder("")

   '   With query
   '      .Length = 0
   '      .AppendLine("SELECT ConcesionarioSubTipoUnidad.IdSubTipoUnidad")
   '      .AppendLine("     ,ConcesionarioSubTipoUnidad.NombreTipoUnidad + ' - ' + ConcesionarioSubTipoUnidad.NombreSubTipoUnidad AS NombreCompleto")
   '      .AppendLine(" FROM ConcesionarioSubTiposUnidades")
   '      .AppendLine("  INNER JOIN ConcesionarioTiposUnidades ON ConcesionarioSubTiposUnidades.IdTipoUnidad = ConcesionarioTiposUnidades.IdTipoUnidad")
   '      .AppendLine("ORDER BY 2")
   '   End With
   '   Return Me.GetDataTable(query.ToString())
   'End Function
End Class
