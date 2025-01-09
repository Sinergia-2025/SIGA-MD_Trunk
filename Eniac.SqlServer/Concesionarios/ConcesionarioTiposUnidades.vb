Public Class ConcesionarioTiposUnidades
   Inherits Comunes
   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   'INSERT
   Public Sub TiposUnidades_I(idTipoUnidad As Integer,
                              nombreTipoUnidad As String,
                              descripcionTipoUnidad As String,
                              muestraEnCeroKm As Boolean,
                              muestraEnUsado As Boolean,
                              solicitaDistribucionEje As Boolean)
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6})",
            Entidades.ConcesionarioTipoUnidad.NombreTabla,
            Entidades.ConcesionarioTipoUnidad.columnas.IdTipoUnidad.ToString(),
            Entidades.ConcesionarioTipoUnidad.columnas.NombreTipoUnidad.ToString(),
            Entidades.ConcesionarioTipoUnidad.columnas.DescripcionTipoUnidad.ToString(),
            Entidades.ConcesionarioTipoUnidad.columnas.MuestraEnCerokm.ToString(),
            Entidades.ConcesionarioTipoUnidad.columnas.MuestraEnUsado.ToString(),
            Entidades.ConcesionarioTipoUnidad.columnas.SolicitaDistribucionEje.ToString())
         .AppendFormat("   VALUES ({0}, '{1}', '{2}', {3}, {4}, {5})",
            idTipoUnidad, nombreTipoUnidad, descripcionTipoUnidad,
            GetStringFromBoolean(muestraEnCeroKm),
            GetStringFromBoolean(muestraEnUsado),
            GetStringFromBoolean(solicitaDistribucionEje))
      End With
      Me.Execute(query.ToString())
   End Sub

   'UPDATE
   Public Sub TiposUnidades_U(idTipoUnidad As Integer,
                             nombreTipoUnidad As String,
                             descripcionTipoUnidad As String,
                             muestraEnCeroKm As Boolean,
                             muestraEnUsado As Boolean,
                             solicitaDistribucionEje As Boolean)
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE {0}", Entidades.ConcesionarioTipoUnidad.NombreTabla).AppendLine()
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ConcesionarioTipoUnidad.columnas.NombreTipoUnidad.ToString(), nombreTipoUnidad)
         .AppendFormatLine(" , {0} = '{1}'", Entidades.ConcesionarioTipoUnidad.columnas.DescripcionTipoUnidad.ToString(), descripcionTipoUnidad)
         .AppendFormatLine(" , {0} =  {1} ", Entidades.ConcesionarioTipoUnidad.columnas.MuestraEnCerokm.ToString(), GetStringFromBoolean(muestraEnCeroKm))
         .AppendFormatLine(" , {0} =  {1} ", Entidades.ConcesionarioTipoUnidad.columnas.MuestraEnUsado.ToString(), GetStringFromBoolean(muestraEnUsado))
         .AppendFormatLine(" , {0} =  {1} ", Entidades.ConcesionarioTipoUnidad.columnas.SolicitaDistribucionEje.ToString(), GetStringFromBoolean(solicitaDistribucionEje))
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ConcesionarioTipoUnidad.columnas.IdTipoUnidad.ToString(), idTipoUnidad)
      End With
      Me.Execute(query.ToString())
   End Sub
   'DELETE
   Public Sub TiposUnidades_D(idTipoUnidad As Integer, nombreTipoUnidad As String)
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.ConcesionarioTipoUnidad.NombreTabla, Entidades.ConcesionarioTipoUnidad.columnas.IdTipoUnidad.ToString(), idTipoUnidad)
      End With
      Me.Execute(query.ToString())
   End Sub
   'SELECT TEXT
   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ConcesionarioTipoUnidad.* FROM {0} AS ConcesionarioTipoUnidad", Entidades.ConcesionarioTipoUnidad.NombreTabla)
      End With
   End Sub
   'G
   Private Function TiposUnidades_G(idTipoUnidad As Integer, nombreTipoUnidad As String, nombreExacto As Boolean,
                                    descripcionTipoUnidad As String, ceroKM As Entidades.Publicos.SiNoTodos) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendFormatLine(" WHERE 1 = 1")
         If idTipoUnidad > 0 Then
            .AppendFormatLine("   AND ConcesionarioTipoUnidad.IdTipoUnidad = {0}", idTipoUnidad)
         End If
         If Not String.IsNullOrWhiteSpace(nombreTipoUnidad) Then
            If nombreExacto Then
               .AppendFormatLine("   AND ConcesionarioTipoUnidad.NombreTipoUnidad = '{0}'", nombreTipoUnidad)
            Else
               .AppendFormatLine("   AND ConcesionarioTipoUnidad.NombreTipoUnidad LIKE '%{0}%'", nombreTipoUnidad)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(descripcionTipoUnidad) Then
            .AppendFormatLine("   AND ConcesionarioTipoUnidad.DescripcionTipoUnidad LIKE '%{0}%'", descripcionTipoUnidad)
         End If
         '---
         Select Case ceroKM
            Case Entidades.Publicos.SiNoTodos.SI
               .AppendFormatLine("   AND ConcesionarioTipoUnidad.MuestraEnCeroKM = {0}", GetStringFromBoolean(True))
            Case Entidades.Publicos.SiNoTodos.NO
               .AppendFormatLine("   AND ConcesionarioTipoUnidad.MuestraEnUsado = {0}", GetStringFromBoolean(True))
         End Select
         '---
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
   'GA
   Public Function TiposUnidades_GA() As DataTable
      Return TiposUnidades_G(idTipoUnidad:=0, nombreTipoUnidad:=String.Empty, nombreExacto:=False, descripcionTipoUnidad:=String.Empty, ceroKM:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   'GA
   Public Function TiposUnidades_GA(nombreTipoUnidad As String, nombreExacto As Boolean) As DataTable
      Return TiposUnidades_G(idTipoUnidad:=0, nombreTipoUnidad:=nombreTipoUnidad, nombreExacto:=nombreExacto, descripcionTipoUnidad:=String.Empty, ceroKM:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Function TiposUnidades_GA(ceroKm As Entidades.Publicos.SiNoTodos) As DataTable
      Return TiposUnidades_G(idTipoUnidad:=0, nombreTipoUnidad:=String.Empty, nombreExacto:=False, descripcionTipoUnidad:=String.Empty, ceroKM:=ceroKm)
   End Function
   'G1
   Public Function TiposUnidades_G1(idTipoUnidad As Integer) As DataTable
      Return TiposUnidades_G(idTipoUnidad:=idTipoUnidad, nombreTipoUnidad:=String.Empty, nombreExacto:=False, descripcionTipoUnidad:=String.Empty, ceroKM:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "ConcesionarioTipoUnidad." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   'GETCODIGOMAXIMO
   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ConcesionarioTipoUnidad.columnas.IdTipoUnidad.ToString(), "ConcesionarioTiposUnidades"))
   End Function
End Class
